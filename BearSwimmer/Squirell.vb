Imports MathNet.Spatial.Euclidean

Public Class Squirell
    Inherits Puzzle
    Public Sub New(parameters As Parameters)
        MyBase.New(parameters)
        parameters.PredictSwim = AddressOf PredictSwim
    End Sub
    Public Overrides Sub Advanced(problem As Problem, e As AdvanceArgs)
    End Sub
    Public Overrides Sub Go()
        Problem.Parameters.Timeout = 9999
        Problem.Run()
        Done()
    End Sub
    Public Overrides Function PredictSwim() As Vector2D
        Dim result As Vector2D
        result = (Problem.Swim.Location - Problem.Bear.Location).Normalize * Delta * Problem.Swim.Speed
        Return result
    End Function
End Class
