Imports MathNet.Spatial.Euclidean

Public Class Puzzle1
    Inherits Puzzle
    'Puzzle 1
    'A. How can the swimmer apply the squirrel strategy to Ggt into the best position To escape?
    'B. What kind Of path does the swimmer trace In doing so?
    'C. How many full turns will the swimmer make before the squirrel strategy stops being Of any further help?
    'D. How long does it take to reach that point?
    'E. Can the swimmer Finally evade the bear?
    Public Sub New(parameters As Parameters)
        MyBase.New(parameters)
        parameters.PredictSwim = AddressOf PredictSwim
    End Sub
    Public Overrides Sub Advanced(problem As Problem, e As AdvanceArgs)
        If problem.DashStart > 0 Then ' We are already dashing
            Exit Sub
        End If
        If problem.Separation < (problem.Previous.Bear.Location - problem.Previous.Swim.Location).Length Then ' We're not gaining on him any more
            problem.DashAngle = problem.Swim.Location.ToVector2D.GetAngle
            problem.DashStart = problem.Elapsed
            problem.DashAt = problem.Swim.Location
            e.Cancelled = True
        End If
    End Sub
    Public Overrides Sub Go()
        Problem.Run()
        Send($"Dashed after {Problem.DashStart:0.000} from {Problem.DashAt:0.000} towards {Problem.DashAngle.Degrees:0.0}°")
        Problem.Picture.Save(Name & ".jpg", Imaging.ImageFormat.Jpeg)
        Done()
    End Sub
    Public Overrides Function PredictSwim() As Vector2D
        Dim result As Vector2D
        With Problem
            If .DashStart = 0 Then
                result = (.Swim.Location - .Bear.Location).Normalize * Delta * .Swim.Speed
            Else
                result = Vector2D.FromPolar(Delta * .Swim.Speed, .DashAngle)
            End If
        End With
        Return result
    End Function
End Class
