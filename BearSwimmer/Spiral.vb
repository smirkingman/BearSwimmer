Imports System.Math
Imports MathNet.Spatial.Euclidean
Imports MathNet.Spatial.Units
Public Class Spiral
    Inherits Puzzle

    Private VA As Double
    Private VB As Double
    Private Quickest As Problem
    Private Safest As Problem
    Private BestTime As Double = 20
    Private Farthest As Double = 0
    Public Sub New(parameters As Parameters)
        MyBase.New(parameters)
        parameters.PredictSwim = AddressOf PredictSwim
    End Sub
    Public Overrides Sub Advanced(problem As Problem, e As AdvanceArgs)
    End Sub
    Public Overrides Sub Go()

        Dim a As Double = Parameters.Amin
        Dim astep As Double = Fractional(a)
        Do
            VA = a
            Dim b As Double = Parameters.Bmin
            Dim bstep As Double = Fractional(b)
            Do
                VB = b
                Status($"A {a} B {b}")

                Problem.Name = $"{Me.GetType.Name} {Radius} A {VA:0.000} B {VB:0.000}"
                Problem.Reset()
                Problem.Run()

                If Worker.CancellationPending Then
                    Done()
                    Exit Sub
                End If

                Worker.ReportProgress(0, Nothing)

                If Problem.Success Then
                    If Problem.Separation > Farthest Then
                        Try
                            Send($"Improved {Problem}")
                            Problem.PictureLock.EnterWriteLock()
                            Dim pic As Bitmap = Problem.Picture

                            If Problem.Elapsed < BestTime Then
                                Quickest = Problem.Clone
                                BestTime = Problem.Elapsed
                                Worker.ReportProgress(0, Quickest)
                                Problem.Parameters.Timeout = Quickest.Elapsed

                            ElseIf Problem.Separation > Farthest Then
                                Safest = Problem.Clone
                                Farthest = Problem.Separation
                                Worker.ReportProgress(0, Safest)
                            End If
                        Finally
                            Problem.PictureLock.ExitWriteLock()
                        End Try
                    End If
                End If

                b += Pow(10, -bstep)
                b = Round(b, 13)

            Loop Until b >= Parameters.Bmax

            a += Pow(10, -astep)
            a = Round(a, 13)

        Loop Until a >= Parameters.Amax
        Quickest.Picture.Save(Name & " Fast.jpg", Imaging.ImageFormat.Jpeg)
        Safest.Picture.Save(Name & " Safe.jpg", Imaging.ImageFormat.Jpeg)
        Done()
    End Sub
    Public Overrides Function PredictSwim() As Vector2D
        Dim result As Vector2D
        Dim swimmer As State = Problem.Swim
        Dim theta As Angle = swimmer.Location.ToVector2D.GetAngle
        Dim x As Double = VA * Exp(VB * theta.Radians) * Cos(theta.Radians)
        Dim y As Double = VA * Exp(VB * theta.Radians) * Sin(theta.Radians)
        Dim theta1 As Angle = theta + Angle.FromRadians(1 * ToRadians)
        Dim x1 As Double = VA * Exp(VB * theta1.Radians) * Cos(theta1.Radians)
        Dim y1 As Double = VA * Exp(VB * theta1.Radians) * Sin(theta1.Radians)
        Dim v1 As New Vector2D(x1 - x, y1 - y)
        result = v1.Normalize * Delta * swimmer.Speed
        Dim ra As Angle = result.GetAngle
        'Debug.WriteLine($"{swimmer.Location.X:0.000},{swimmer.Location.Y:0.000} {swimmer.Angle.Degrees:0.000} -> {ra.Degrees:0.0000}")
        Return result
    End Function
End Class
