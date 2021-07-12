Imports System.Math
Imports MathNet.Spatial.Euclidean
Imports MathNet.Spatial.Units
Public Class Puzzle3C
    Inherits Puzzle

    Private MyTime As Double
    Private Best As Problem
    Private MyDash As Angle
    Private Farthest As Double = 0
    Public Sub New(parameters As Parameters)
        MyBase.New(parameters)
        parameters.PredictSwim = AddressOf PredictSwim
    End Sub
    Public Overrides Sub Advanced(problem As Problem, e As AdvanceArgs)
        If problem.DashStart = 0 Then
            If problem.Elapsed >= MyTime Then
                problem.DashStart = problem.Elapsed
                problem.DashAngle = problem.Swim.Angle + MyDash
                problem.DashAt = problem.Swim.Location
                e.Cancelled = True
            End If
        End If
    End Sub
    Public Overrides Sub Go()

        For time As Double = 1 To 0.1 Step -0.1

            MyTime = time

            For i As Integer = -90 To 179

                MyDash = Angle.FromDegrees(i)
                Problem.Name = $"{Me.GetType.Name} {Radius} {i}° after {MyTime:0.000}"
                Status($"{i}°")
                Problem.Reset()
                MyDash = Angle.FromDegrees(i)
                Problem.Run()

                If Worker.CancellationPending Then
                    Done()
                    Exit Sub
                End If

                If Problem.Success Then
                    Send($"Success {Problem}")
                    If Problem.Separation > Farthest Then
                        Try
                            Problem.PictureLock.EnterWriteLock()
                            Dim pic As Bitmap = Problem.Picture
                            Send($"Dashed after {Problem.DashStart:0.000} from {Problem.DashAt:0.000} towards {Problem.DashAngle.Degrees:0.0}°")
                            Best = Problem.Clone
                            Farthest = Problem.Separation
                            Worker.ReportProgress(0, Best)
                        Finally
                            Problem.PictureLock.ExitWriteLock()
                        End Try
                    End If
                End If
            Next
        Next time
        Best.Picture.Save(Name & ".jpg", Imaging.ImageFormat.Jpeg)
        Done()
    End Sub
    Public Overrides Function PredictSwim() As Vector2D
        Dim result As Vector2D
        If Problem.DashStart = 0 Then
            result = (Problem.Swim.Location - Problem.Bear.Location).Normalize * Delta * Problem.Swim.Speed
        Else
            result = Vector2D.FromPolar(Delta * Problem.Swim.Speed, Problem.DashAngle)
        End If
        Return result
    End Function
End Class
