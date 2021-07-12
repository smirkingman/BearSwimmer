Imports System.Math
Imports MathNet.Spatial.Euclidean
Imports MathNet.Spatial.Units
Imports Force.DeepCloner
Imports System.Drawing.Imaging
Imports System.Threading

Public Class Problem

    Public Event Advanced(sender As Problem, e As AdvanceArgs)
    Public Event Drew(sender As Problem)
    Public Event Message(sender As Problem, text As String)
    Public Event Complete(sender As Problem)

    Public Bear As State
    Public Swim As State
    Public Previous As History
    Public PictureLock As New ReaderWriterLockSlim()
    Public Sub New(parms As Parameters)
        Me.Parameters = parms
        Size = Parameters.Size
        Reset()
    End Sub
    Public Property Aborted As Boolean
    Public Sub Advance()

        If Aborted Then
            Result = "Cancelled"
            Finished = True
        End If

        Try
            Dim swimvector As Vector2D = Parameters.PredictSwim()
            Swim.Move(swimvector)

            Dim bearvector As Vector2D = PredictBear(Swim)
            Bear.Move(bearvector)

        Catch ex As Exception
            Send("Error updating positions " & ex.Message)
            Finished = True
            Result = ex.Message
        End Try

        Dim bearline As New LineSegment2D(Previous.Bear.Location, Bear.Location)
        Dim closest As Point2D = bearline.ClosestPointTo(Swim.Location)

        If (Swim.Location - closest).Length <= Swim.Moved.Length Then

            Result = $"Bear's dinner at {Swim.Location.X:0.0},{Swim.Location.Y:0.0}"
            Finished = True

        ElseIf Swim.Location.ToVector2D.Length > Radius Then
            Result = "Escaped"
            Finished = True
            Success = True

        ElseIf Elapsed > Parameters.Timeout Then
            Result = "Timeout"
            Finished = True
        End If

        Dim e As New AdvanceArgs(Delta)
        RaiseEvent Advanced(Me, e)

        If e.Cancelled Then
            Bear = Previous.Bear
            Swim = Previous.Swim
            Exit Sub
        End If

        Steps += 1
        Elapsed += Delta

        Draw()

        If Animation Then
            RaiseEvent Drew(Me)
        End If

        If Finished Then
            Draw()
            DrawFinal()
            RaiseEvent Drew(Me)
        End If

        Dim ready As Boolean = Stopwatch.ElapsedMilliseconds > 333 ' Keep to reasonable FPS
        If ready Then
            Stopwatch.Restart()
        End If

        If Parameters.WriteImages AndAlso ready Then
            Picture.Save($"{Name}{Steps:00000}.jpg", Imaging.ImageFormat.Jpeg)
        End If
        'Debug.WriteLine(Bear)
        'Debug.WriteLine(Swim)
        Previous.Bear = Bear
        Previous.Swim = Swim
    End Sub
    Public ReadOnly Property Circumference As Double
        Get
            Return Radius * 2 * PI
        End Get
    End Property
    Public Function Clone() As Problem
        Dim result As Problem = Me.ShallowClone
        Return result
    End Function
    Public Property DashAngle As Angle
    Public Property DashAt As Point2D
    Public Property DashStart As Double
    Public ReadOnly Property Delta As Double
        Get
            Return Parameters.Delta
        End Get
    End Property
    Public ReadOnly Property Animation As Boolean
        Get
            Return Parameters.Animation
        End Get
    End Property
    Public Property Elapsed As Double
    Public ReadOnly Property Fade As Boolean
        Get
            Return Parameters.Fade
        End Get
    End Property
    Public Property Finished As Boolean
    Public Property Name As String
    Public Parameters As Parameters
    Public Property Picture As Bitmap
    Protected Function PredictBear(swim As State) As Vector2D

        ' Determine bear's action
        ' Chase clockwise or anti-clockwise?
        Dim bv As Vector2D = Bear.Location.ToVector2D
        Dim sv As Vector2D = swim.Location.ToVector2D
        Dim a As Angle = bv.Rotation(sv)

        Dim clockwise As Boolean = a.Radians >= 0

        ' How far shall I run?
        Dim beardistance As Double = Delta * Bear.Speed

        ' What is the subtended angle on the circumference that I ran?
        Dim theta As Angle = Angle.FromRadians((beardistance / Circumference) * 2 * PI)

        ' Where have I ran to?
        Dim bearvector As Vector2D = Bear.Location.ToVector2D
        If Not clockwise Then
            theta = -theta
        End If
        bearvector = bearvector.Rotate(theta)
        Dim move As Vector2D = bearvector.ToPoint2D - Bear.Location
        Return move
    End Function
    Public ReadOnly Property Radius As Double
        Get
            Return Parameters.Radius
        End Get
    End Property
    Public Sub Reset()
        Swim = New State("Swimmer", New Point2D(0, 0), Parameters.SwimSpeed, Angle.FromDegrees(180))
        Bear = New State("Bear", New Point2D(Radius, 0), Parameters.SwimSpeed * Parameters.BearFactor, Angle.FromDegrees(90))
        Previous.Swim = Swim
        Previous.Bear = Bear
        Aborted = False
        DashAngle = ANGLEZERO
        DashAt = POINT2DZERO
        DashStart = 0
        Elapsed = 0
        Finished = False
        Result = ""
        Steps = 0
        Stopwatch = Stopwatch.StartNew
        Success = False
        Size = _Size
    End Sub
    Public Property Result As String
    Public Sub Run()
        If Animation Then
            Draw()
            RaiseEvent Drew(Me)
        End If
        Do
            Advance()
            If Finished Then
                RaiseEvent Complete(Me)
            End If
        Loop Until Finished
    End Sub
    Public ReadOnly Property Separation As Double
        Get
            Return (Bear.Location - Swim.Location).Length
        End Get
    End Property
    Private _Size As Integer
    Public Property Size As Integer
        Get
            Return _Size
        End Get
        Set(value As Integer)
            PictureLock.EnterWriteLock()
            _Size = value
            BlobSize = 2 * ((Size \ 150) + 1) \ 2
            BlobSize2 = BlobSize \ 2
            Picture = New Bitmap(Size, Size + Margin, PixelFormat.Format32bppArgb)
            Bounds = Size - 2 * Border
            Centre = New Point(Border + Bounds \ 2, Margin + Border + Bounds \ 2)
            Scale = CInt(Bounds / (2.0 * Radius))

            Ring = New Bitmap(Size, Size + Margin, PixelFormat.Format32bppArgb)
            Using g As Graphics = Graphics.FromImage(Ring)
                Using b As New SolidBrush(Color.FromArgb(Max(1, CInt(Delta * 50)), Color.White))
                    g.FillEllipse(b, CInt(Centre.X - BlobSize - Radius * Scale) - 1,
                                 CInt(Centre.Y - BlobSize - Radius * Scale) - 1,
                                 CInt(2 * Radius * Scale + 2 * BlobSize) + 2,
                                 CInt(2 * Radius * Scale + 2 * BlobSize) + 2)
                End Using
                Using b As New SolidBrush(Color.FromArgb(0, Color.Black))
                    g.FillEllipse(b, CInt(Centre.X + BlobSize2 - Radius * Scale) + 1,
                                 CInt(Centre.Y + BlobSize2 - Radius * Scale) + 1,
                                 CInt(2 * Radius * Scale - BlobSize) - 2,
                                 CInt(2 * Radius * Scale - BlobSize) - 2)
                End Using
            End Using
            Using g As Graphics = Graphics.FromImage(Picture)
                g.Clear(Color.White)
                Using p As New Pen(Color.LightGray)
                    Dim x As Integer = 2 * CInt(Radius * Scale)
                    Dim y As Integer = 2 * CInt(Radius * Scale)
                    g.DrawEllipse(p, Border - BlobSize2, Margin + Border - BlobSize2, x, y)
                End Using
            End Using
            PictureLock.ExitWriteLock()
        End Set
    End Property
    Public Property Steps As Integer
    Public Stopwatch As New Stopwatch
    Public Property Success As Boolean
    Public Sub Send(text As String)
        RaiseEvent Message(Me, text)
    End Sub
    Public Overrides Function ToString() As String
        Return $"{Name} {Result} Time {Elapsed:0.000} swam {Swim.Travel:0.000} turned {Swim.Turned.Degrees:0.0}° lead {Separation():0.000}"
    End Function
End Class
