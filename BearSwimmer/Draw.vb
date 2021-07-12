Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Math
Partial Public Class Problem
    Public Property Font As New Font("Arial Narrow", 10)
    Public Const Border As Integer = 10
    Public BlobSize As Integer
    Public BlobSize2 As Integer
    Public Property Bounds As Integer
    Public Property Centre As Point
    Public Property Margin As Integer = 20
    Public Property Ring As Bitmap
    Public Property Scale As Integer
    Public Sub Draw()

        Try
            PictureLock.EnterWriteLock()

            Using g As Graphics = Graphics.FromImage(Picture)

                GDIBestQuality(g)

                If Fade Then
                    g.CompositingMode = CompositingMode.SourceOver
                    g.DrawImage(Ring, 0, 0)
                    g.CompositingMode = CompositingMode.SourceCopy
                End If

                Dim bearx As Integer = CInt(Centre.X + Bear.Location.X * Scale)
                Dim beary As Integer = CInt(Centre.Y + Bear.Location.Y * Scale)
                Dim c As Color = Color.Red
                If Bear.Clockwise Then
                    c = Color.Blue
                End If
                Using b As New SolidBrush(c)
                    g.FillEllipse(b, bearx - BlobSize2, beary - BlobSize2, BlobSize, BlobSize)
                    'If Bear.Moved <> VECTOR2DZERO Then
                    '    Using p As New Pen(b, blobsize2)
                    '        Using ba As New AdjustableArrowCap(1, 1)
                    '            ba.WidthScale = 3
                    '            p.CustomEndCap = ba
                    '        End Using
                    '        Dim len As Single = 4 * blobsize
                    '        Dim a As Double = Bear.Angle.Radians
                    '        'If Not Bear.Clockwise Then
                    '        '    a += 180 * ToRadians
                    '        'End If
                    '        g.DrawLine(p, bearx, beary, bearx + len * CSng(Cos(a)), beary + len * CSng(Sin(a)))
                    '    End Using
                    'End If
                End Using

                Dim swimx As Integer = CInt(Centre.X + Swim.Location.X * Scale)
                Dim swimy As Integer = CInt(Centre.Y + Swim.Location.Y * Scale)
                Using b As New SolidBrush(Color.Lime)
                    g.FillEllipse(b, swimx - BlobSize2, swimy - BlobSize2, BlobSize, BlobSize)
                    'Using p As New Pen(b, 3.0)
                    '    Using ba As New AdjustableArrowCap(1, 1)
                    '        ba.WidthScale = 3
                    '        p.CustomEndCap = ba
                    '    End Using
                    '    Dim len As Single = 15
                    '    Dim a As Double = Swim.Angle.Radians
                    '    If Swim.Clockwise Then
                    '        a += 180 * ToRadians
                    '    End If
                    '    g.DrawLine(p, swimx, swimy, swimx + len * CSng(Cos(a)), swimy + len * CSng(Sin(a)))
                    'End Using
                End Using
                'Dim pc As Color = Color.Blue
                'If Bear.Clockwise Then
                '    pc = Color.Magenta
                'End If
                'Using p As New Pen(pc)
                '    g.DrawLine(p, bearx, beary, swimx, swimy)
                'End Using
            End Using

            Using g As Graphics = Graphics.FromImage(Picture) ' DrawString croaks with CompositingMode
                GDIBestQuality(g)
                Using b As New SolidBrush(Color.White)
                    g.FillRectangle(b, 0, 0, Picture.Width, Margin)
                End Using
                Using b As New SolidBrush(Color.Black)
                    g.DrawString(Me.ToString, Me.Font, b, New PointF(2, 2))
                End Using
            End Using
        Catch ex As Exception
            Throw
        Finally
            PictureLock.ExitWriteLock()
        End Try
    End Sub

    Public Sub DrawFinal()
        Try
            PictureLock.EnterWriteLock()

            Using g As Graphics = Graphics.FromImage(Picture)
                GDIBestQuality(g)
                Using p As New Pen(Color.Magenta, 2)
                    Using ba As New AdjustableArrowCap(1, 1)
                        ba.WidthScale = 3
                        p.CustomEndCap = ba
                    End Using
                    Dim x1 As Integer = CInt(Centre.X + Previous.Bear.Location.X * Scale)
                    Dim y1 As Integer = CInt(Centre.Y + Previous.Bear.Location.Y * Scale)
                    Dim x2 As Integer = CInt(Centre.X + Bear.Location.X * Scale)
                    Dim y2 As Integer = CInt(Centre.Y + Bear.Location.Y * Scale)
                    g.DrawLine(p, x1, y1, x2, y2)
                    Dim x3 As Integer = CInt(Centre.X + Previous.Swim.Location.X * Scale)
                    Dim y3 As Integer = CInt(Centre.Y + Previous.Swim.Location.Y * Scale)
                    Dim x4 As Integer = CInt(Centre.X + Swim.Location.X * Scale)
                    Dim y4 As Integer = CInt(Centre.Y + Swim.Location.Y * Scale)
                    g.DrawLine(p, x3, y3, x4, y4)
                End Using
            End Using
        Finally
            PictureLock.ExitWriteLock()
        End Try
    End Sub

End Class
