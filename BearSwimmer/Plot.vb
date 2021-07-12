Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Math
Imports System.Threading

Public Class Plot
    Public WithEvents Problem As Problem
    Public WithEvents Puzzle As Puzzle
    Private Lock As New Object
    Public Sub New()
        InitializeComponent()
        Init()
    End Sub
    Public Sub New(pic As Bitmap)
        InitializeComponent()
        Init()
        Draw(pic)
    End Sub
    Public Sub Draw(pic As Bitmap)
        Using g As Graphics = Graphics.FromImage(PictureBox1.Image)
            Dim size As Integer = Min(Me.ClientSize.Width, Me.ClientSize.Height)
            g.DrawImage(pic, 0, 0, size, size)
        End Using
        Refresh()
    End Sub
    Public Sub Draw() Handles Problem.Drew
        Try
            If InvokeRequired Then
                Invoke(Sub() Draw1())
            Else
                Draw1()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Draw1()
        Try
            Problem.PictureLock.EnterWriteLock()
            Using g As Graphics = Graphics.FromImage(PictureBox1.Image)
                Dim size As Integer = Min(Me.ClientSize.Width, Me.ClientSize.Height)
                g.DrawImage(Problem.Picture, 0, 0, size, size)
            End Using
            Refresh()
        Catch ex As Exception
            Throw
        Finally
            Problem.PictureLock.ExitWriteLock()
        End Try
    End Sub
    Private Sub Init()
        PictureBox1.Image = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Using g As Graphics = Graphics.FromImage(PictureBox1.Image)
            g.Clear(Color.White)
        End Using
    End Sub
End Class