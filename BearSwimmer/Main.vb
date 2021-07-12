Imports System.ComponentModel
Imports System.Runtime.Remoting
Imports System.Math
Imports System.Reflection
Imports MathNet.Spatial.Euclidean
Imports MathNet.Spatial.Units

Public Class Main
    Sub New()
        InitializeComponent()
    End Sub
    Private PuzzleName As String
    Private WithEvents Puzzle As Puzzle
    Private Puzzles As List(Of Type)
    Private Radius As Double
    Private SwimSpeed As Double
    Private Delta As Double
    Private Plot As Plot
    Private Best As Problem
    Private BestPlot As Plot
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        Puzzles =
            AppDomain.
            CurrentDomain.
            GetAssemblies.
            SelectMany(Function(q) q.GetTypes).
            Where(Function(q) q.IsSubclassOf(GetType(Puzzle))).
            ToList

        Dim puzzlenames As List(Of String) = Puzzles.Select(Function(q) q.Name).OrderBy(Function(q) q).ToList
        cmbPuzzle.DataSource = puzzlenames
        cmbPuzzle.SelectedItem = puzzlenames.First

        txtBearRatio.Text = "4.5"
        txtRadius.Text = "4.5"
        txtSwimSpeed.Text = "1.0"
        txtDelta.Text = "0.001"
        txtAmin.Text = "0.1"
        txtAmax.Text = "5"
        txtBmin.Text = "0.01"
        txtBmax.Text = "4"
        Clock = Stopwatch.StartNew()
    End Sub
    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click

        If btnGo.Text = "Go" Then
            btnGo.Text = "Stop"
            Try
                Best = Nothing
                Try
                    If BestPlot IsNot Nothing Then
                        BestPlot.Close()
                    End If
                Catch ex As Exception
                End Try
                BestPlot = Nothing
                Parameters = New Parameters
                Dim puzzletype As Type = Puzzles.Where(Function(q) q.Name = PuzzleName).Single

                Plotter = New Plot()
                Plotter.Show()

                With Parameters
                    .Animation = chkAnimation.Checked
                    .BearFactor = CDbl(txtBearRatio.Text)
                    .Delta = CDbl(txtDelta.Text)
                    .Fade = chkFade.Checked
                    .PuzzleName = puzzletype.Name
                    .Radius = CDbl(txtRadius.Text)
                    .SwimSpeed = CDbl(txtSwimSpeed.Text)
                    .WriteImages = chkWriteImages.Checked
                    .Amin = CDbl(txtAmin.Text)
                    .Amax = CDbl(txtAmax.Text)
                    .Bmin = CDbl(txtBmin.Text)
                    .Bmax = CDbl(txtBmax.Text)
                    .Size = Plotter.ClientSize.Width
                End With

                Dim args() As Object = {Parameters}
                Puzzle = DirectCast(Activator.CreateInstance(puzzletype, args), Puzzle)

                Plotter.Puzzle = Puzzle
                Plotter.Problem = Puzzle.Problem
                Plotter.Text = Puzzle.Name
                txtMsg.Clear()
                txtMsg.Refresh()

                Worker.RunWorkerAsync(Puzzle)

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        Else
            Worker.CancelAsync()
            Puzzle.Problem.Aborted = True
            btnGo.Text = "Go"
        End If

    End Sub
    Private Sub cmbPuzzle_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbPuzzle.SelectedValueChanged
        PuzzleName = cmbPuzzle.SelectedValue.ToString
    End Sub
    Private Sub Message(text As String)
        Puzzle_Message(Puzzle, text)
    End Sub
    Public Parameters As Parameters
    Public Property Plotter As Plot
    Private Sub Puzzle_Complete(sender As Puzzle) Handles Puzzle.Complete
        Invoke(Sub()
                   btnGo.Text = "Go"
                   Refresh()
               End Sub)
    End Sub
    Private Sub Puzzle_Message(sender As Puzzle, text As String) Handles Puzzle.Message
        Invoke(
            Sub()
                If String.IsNullOrWhiteSpace(txtMsg.Text) Then
                    txtMsg.Text = text
                Else
                    txtMsg.AppendText(vbCrLf & text)
                End If
                If txtMsg.Text.Length > 10000 Then
                    txtMsg.Text = txtMsg.Text.Substring(5000)
                End If
                txtMsg.Refresh()
            End Sub)
    End Sub
    Private Sub Puzzle_StatusChanged(sender As Puzzle, text As String) Handles Puzzle.StatusChanged
        Invoke(
            Sub()
                txtStatus.Text = text
                txtStatus.Refresh()
            End Sub)
    End Sub
    Private Sub txt_Validating(sender As Object, e As CancelEventArgs) Handles txtBearRatio.Validating,
                                                                               txtRadius.Validating,
                                                                               txtSwimSpeed.Validating,
                                                                               txtDelta.Validating,
                                                                               txtAmin.Validating,
                                                                               txtAmax.Validating,
                                                                               txtBmin.Validating,
                                                                               txtBmax.Validating
        Dim box As TextBox = DirectCast(sender, TextBox)
        Dim val As Double
        If Double.TryParse(box.Text, val) Then
            Exit Sub
        End If
        e.Cancel = True
        MsgBox("Invalid number")
    End Sub
    Private Sub Worker_DoWork(sender As Object, e As DoWorkEventArgs) Handles Worker.DoWork
        Dim bw As BackgroundWorker = DirectCast(sender, BackgroundWorker)
        Dim work As Puzzle = DirectCast(e.Argument, Puzzle)
        work.Run(bw)
        If bw.CancellationPending Then
            e.Cancel = True
        End If
    End Sub
    Private Sub Worker_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles Worker.ProgressChanged
        Invoke(
                Sub()
                    If e.UserState Is Nothing Then
                        Plotter.Draw()
                    Else
                        Try
                            Puzzle.Problem.PictureLock.EnterWriteLock()
                            Best = DirectCast(e.UserState, Problem)
                            Message("Improved at " & Best.ToString)
                            If BestPlot Is Nothing Then
                                BestPlot = New Plot(Puzzle.Problem.Picture)
                                BestPlot.Text = $"{Puzzle.Problem.Name} Best so far"
                                BestPlot.Show()
                            Else
                                BestPlot.Draw(Puzzle.Problem.Picture)
                            End If
                        Finally
                            Puzzle.Problem.PictureLock.ExitWriteLock()
                        End Try
                    End If
                End Sub)
    End Sub
    Private Sub Worker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        Dim bw As BackgroundWorker = DirectCast(sender, BackgroundWorker)
        If e.Cancelled Then
            Debug.WriteLine($"{Puzzle.Name} cancelled")
        ElseIf e.Error IsNot Nothing Then
            Debug.WriteLine($"{Puzzle.Name} failed {e.Error.Message}")
        Else
            Debug.WriteLine($"{Puzzle.Name} success")
        End If
    End Sub

End Class
