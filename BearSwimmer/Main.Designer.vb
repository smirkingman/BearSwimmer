<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbPuzzle = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDelta = New System.Windows.Forms.TextBox()
        Me.txtRadius = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSwimSpeed = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtBearRatio = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnGo = New System.Windows.Forms.Button()
        Me.txtMsg = New System.Windows.Forms.TextBox()
        Me.chkFade = New System.Windows.Forms.CheckBox()
        Me.chkAnimation = New System.Windows.Forms.CheckBox()
        Me.chkWriteImages = New System.Windows.Forms.CheckBox()
        Me.Worker = New System.ComponentModel.BackgroundWorker()
        Me.txtAmin = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtAmax = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtBmax = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtBmin = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(60, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Puzzle"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbPuzzle
        '
        Me.cmbPuzzle.FormattingEnabled = True
        Me.cmbPuzzle.Location = New System.Drawing.Point(106, 12)
        Me.cmbPuzzle.Name = "cmbPuzzle"
        Me.cmbPuzzle.Size = New System.Drawing.Size(100, 23)
        Me.cmbPuzzle.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(42, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Time step"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDelta
        '
        Me.txtDelta.Location = New System.Drawing.Point(106, 41)
        Me.txtDelta.Name = "txtDelta"
        Me.txtDelta.Size = New System.Drawing.Size(100, 23)
        Me.txtDelta.TabIndex = 3
        '
        'txtRadius
        '
        Me.txtRadius.Location = New System.Drawing.Point(106, 70)
        Me.txtRadius.Name = "txtRadius"
        Me.txtRadius.Size = New System.Drawing.Size(100, 23)
        Me.txtRadius.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(58, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Radius"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSwimSpeed
        '
        Me.txtSwimSpeed.Location = New System.Drawing.Point(106, 99)
        Me.txtSwimSpeed.Name = "txtSwimSpeed"
        Me.txtSwimSpeed.Size = New System.Drawing.Size(100, 23)
        Me.txtSwimSpeed.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Swimmer speed"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBearRatio
        '
        Me.txtBearRatio.Location = New System.Drawing.Point(106, 128)
        Me.txtBearRatio.Name = "txtBearRatio"
        Me.txtBearRatio.Size = New System.Drawing.Size(100, 23)
        Me.txtBearRatio.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(34, 131)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 15)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Bear Factor"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnGo
        '
        Me.btnGo.Location = New System.Drawing.Point(106, 352)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(75, 23)
        Me.btnGo.TabIndex = 10
        Me.btnGo.Text = "Go"
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'txtMsg
        '
        Me.txtMsg.Location = New System.Drawing.Point(212, 12)
        Me.txtMsg.Multiline = True
        Me.txtMsg.Name = "txtMsg"
        Me.txtMsg.ReadOnly = True
        Me.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtMsg.Size = New System.Drawing.Size(776, 334)
        Me.txtMsg.TabIndex = 11
        Me.txtMsg.TabStop = False
        '
        'chkFade
        '
        Me.chkFade.AutoSize = True
        Me.chkFade.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkFade.Location = New System.Drawing.Point(69, 277)
        Me.chkFade.Name = "chkFade"
        Me.chkFade.Size = New System.Drawing.Size(51, 19)
        Me.chkFade.TabIndex = 12
        Me.chkFade.Text = "Fade"
        Me.chkFade.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkFade.UseVisualStyleBackColor = True
        '
        'chkAnimation
        '
        Me.chkAnimation.AutoSize = True
        Me.chkAnimation.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAnimation.Location = New System.Drawing.Point(38, 302)
        Me.chkAnimation.Name = "chkAnimation"
        Me.chkAnimation.Size = New System.Drawing.Size(82, 19)
        Me.chkAnimation.TabIndex = 13
        Me.chkAnimation.Text = "Animation"
        Me.chkAnimation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAnimation.UseVisualStyleBackColor = True
        '
        'chkWriteImages
        '
        Me.chkWriteImages.AutoSize = True
        Me.chkWriteImages.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkWriteImages.Location = New System.Drawing.Point(25, 327)
        Me.chkWriteImages.Name = "chkWriteImages"
        Me.chkWriteImages.Size = New System.Drawing.Size(95, 19)
        Me.chkWriteImages.TabIndex = 14
        Me.chkWriteImages.Text = "Write images"
        Me.chkWriteImages.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkWriteImages.UseVisualStyleBackColor = True
        '
        'Worker
        '
        Me.Worker.WorkerReportsProgress = True
        Me.Worker.WorkerSupportsCancellation = True
        '
        'txtAmin
        '
        Me.txtAmin.Location = New System.Drawing.Point(106, 157)
        Me.txtAmin.Name = "txtAmin"
        Me.txtAmin.Size = New System.Drawing.Size(100, 23)
        Me.txtAmin.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(61, 160)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 15)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "A Min"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAmax
        '
        Me.txtAmax.Location = New System.Drawing.Point(106, 186)
        Me.txtAmax.Name = "txtAmax"
        Me.txtAmax.Size = New System.Drawing.Size(100, 23)
        Me.txtAmax.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(59, 189)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "A Max"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBmax
        '
        Me.txtBmax.Location = New System.Drawing.Point(106, 244)
        Me.txtBmax.Name = "txtBmax"
        Me.txtBmax.Size = New System.Drawing.Size(100, 23)
        Me.txtBmax.TabIndex = 22
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(59, 247)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 15)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "B Max"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBmin
        '
        Me.txtBmin.Location = New System.Drawing.Point(106, 215)
        Me.txtBmin.Name = "txtBmin"
        Me.txtBmin.Size = New System.Drawing.Size(100, 23)
        Me.txtBmin.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(61, 218)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 15)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "B Min"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.SystemColors.Control
        Me.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStatus.Location = New System.Drawing.Point(212, 352)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(776, 23)
        Me.txtStatus.TabIndex = 27
        Me.txtStatus.TabStop = False
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 385)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.txtBmax)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtBmin)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtAmax)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtAmin)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.chkWriteImages)
        Me.Controls.Add(Me.chkAnimation)
        Me.Controls.Add(Me.chkFade)
        Me.Controls.Add(Me.txtMsg)
        Me.Controls.Add(Me.btnGo)
        Me.Controls.Add(Me.txtBearRatio)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtSwimSpeed)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtRadius)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDelta)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbPuzzle)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Main"
        Me.Text = "The Swimmer and the Bear, or the Duck and the Dog"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cmbPuzzle As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDelta As TextBox
    Friend WithEvents txtRadius As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSwimSpeed As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtBearRatio As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnGo As Button
    Friend WithEvents txtMsg As TextBox
    Friend WithEvents chkFade As CheckBox
    Friend WithEvents chkAnimation As CheckBox
    Friend WithEvents chkWriteImages As CheckBox
    Friend WithEvents Worker As System.ComponentModel.BackgroundWorker
    Friend WithEvents txtAmin As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtAmax As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtBmax As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtBmin As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtStatus As TextBox
End Class
