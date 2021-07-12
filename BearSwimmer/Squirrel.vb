Imports MathNet.Spatial.Euclidean
Imports MathNet.Spatial.Units
Public Class Squirrel
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
        If Worker.CancellationPending Then
            problem.Picture.Save("Squirrel.jpg", Imaging.ImageFormat.Jpeg)
            Done()
        End If
    End Sub
    Public Overrides Sub Go()
        Problem.Strategy = Strategies.Squirrel
        Problem.Run()
        Problem.Picture.Save("Squirrel.jpg", Imaging.ImageFormat.Jpeg)
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
