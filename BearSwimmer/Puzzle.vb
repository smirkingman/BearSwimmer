Imports System.ComponentModel
Imports MathNet.Spatial.Euclidean

Public MustInherit Class Puzzle

    Public MustOverride Sub Advanced(problem As Problem, e As AdvanceArgs)
    Public MustOverride Function PredictSwim() As Vector2D

    Public MustOverride Sub Go()
    Public Event Complete(sender As Puzzle)
    Public Event Message(sender As Puzzle, text As String)
    Public Event StatusChanged(sender As Puzzle, text As String)
    Public Sub New(parameters As Parameters)
        _Parameters = parameters
        Problem = New Problem(parameters)
        Problem.Name = $"{Me.GetType.Name} {Radius.ToString}"
    End Sub
    Public Sub Abort()
        Status("Aborted")
        Problem.Aborted = True
        RaiseEvent Complete(Me)
    End Sub
    Public ReadOnly Property Animation As Boolean
        Get
            Return Parameters.Animation
        End Get
    End Property
    Public ReadOnly Property BearFactor As Double
        Get
            Return Parameters.BearFactor
        End Get
    End Property
    Public ReadOnly Property BearSpeed As Double
        Get
            Return SwimSpeed * BearFactor
        End Get
    End Property
    Public ReadOnly Property Delta As Double
        Get
            Return Parameters.Delta
        End Get
    End Property
    Public Sub Done()
        Status("Done")
        RaiseEvent Complete(Me)
    End Sub
    Public ReadOnly Property Fade As Boolean
        Get
            Return Parameters.Fade
        End Get
    End Property
    Public ReadOnly Property Name As String
        Get
            Return Problem.Name
        End Get
    End Property
    Public ReadOnly Property Parameters As Parameters
    Public WithEvents Problem As Problem
    Private Sub Problem_Advanced(sender As Problem, e As AdvanceArgs) Handles Problem.Advanced
        Advanced(Problem, e)
    End Sub
    Private Sub Problem_Message(sender As Problem, text As String) Handles Problem.Message
        Send(text)
    End Sub
    Public ReadOnly Property Radius As Double
        Get
            Return Parameters.Radius
        End Get
    End Property
    Public Sub Run(bw As BackgroundWorker)
        Worker = bw
        Go()
    End Sub
    Public Sub Send(text As String)
        RaiseEvent Message(Me, text)
    End Sub
    Public Sub Status(text As String)
        RaiseEvent StatusChanged(Me, text)
    End Sub
    Public ReadOnly Property SwimSpeed As Double
        Get
            Return Parameters.SwimSpeed
        End Get
    End Property
    Public Worker As BackgroundWorker
    Public ReadOnly Property WriteImages As Boolean
        Get
            Return Parameters.WriteImages
        End Get
    End Property
End Class
