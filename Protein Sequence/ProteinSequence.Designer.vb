<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProteinSequence
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
        Me.gbInputs = New System.Windows.Forms.GroupBox()
        Me.txtDrawingAmount = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtProteinLength = New System.Windows.Forms.TextBox()
        Me.txtTargetValue = New System.Windows.Forms.TextBox()
        Me.txtMaximumIteration = New System.Windows.Forms.TextBox()
        Me.txtMutationRate = New System.Windows.Forms.TextBox()
        Me.txtEliteRate = New System.Windows.Forms.TextBox()
        Me.txtCrossOverRate = New System.Windows.Forms.TextBox()
        Me.txtPopulationSize = New System.Windows.Forms.TextBox()
        Me.lblMaximumIteration = New System.Windows.Forms.Label()
        Me.lblTargetValue = New System.Windows.Forms.Label()
        Me.lblProteinLength = New System.Windows.Forms.Label()
        Me.lblMutationRate = New System.Windows.Forms.Label()
        Me.lblCrossOverRate = New System.Windows.Forms.Label()
        Me.lblEliteRate = New System.Windows.Forms.Label()
        Me.lblPopulationSize = New System.Windows.Forms.Label()
        Me.gbDrawing = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Start = New System.Windows.Forms.Button()
        Me.gbReadProtein = New System.Windows.Forms.GroupBox()
        Me.txtInputLocation = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblFitness1 = New System.Windows.Forms.Label()
        Me.btnNextDrawing = New System.Windows.Forms.Button()
        Me.btnNextSequence = New System.Windows.Forms.Button()
        Me.lblSequence1 = New System.Windows.Forms.Label()
        Me.lblDrawing1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pbHydrophilic = New System.Windows.Forms.PictureBox()
        Me.pbHydrophobic = New System.Windows.Forms.PictureBox()
        Me.gbInputs.SuspendLayout()
        Me.gbDrawing.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbReadProtein.SuspendLayout()
        CType(Me.pbHydrophilic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbHydrophobic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbInputs
        '
        Me.gbInputs.Controls.Add(Me.txtDrawingAmount)
        Me.gbInputs.Controls.Add(Me.Label2)
        Me.gbInputs.Controls.Add(Me.txtProteinLength)
        Me.gbInputs.Controls.Add(Me.txtTargetValue)
        Me.gbInputs.Controls.Add(Me.txtMaximumIteration)
        Me.gbInputs.Controls.Add(Me.txtMutationRate)
        Me.gbInputs.Controls.Add(Me.txtEliteRate)
        Me.gbInputs.Controls.Add(Me.txtCrossOverRate)
        Me.gbInputs.Controls.Add(Me.txtPopulationSize)
        Me.gbInputs.Controls.Add(Me.lblMaximumIteration)
        Me.gbInputs.Controls.Add(Me.lblTargetValue)
        Me.gbInputs.Controls.Add(Me.lblProteinLength)
        Me.gbInputs.Controls.Add(Me.lblMutationRate)
        Me.gbInputs.Controls.Add(Me.lblCrossOverRate)
        Me.gbInputs.Controls.Add(Me.lblEliteRate)
        Me.gbInputs.Controls.Add(Me.lblPopulationSize)
        Me.gbInputs.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.gbInputs.Location = New System.Drawing.Point(13, 9)
        Me.gbInputs.Name = "gbInputs"
        Me.gbInputs.Size = New System.Drawing.Size(386, 184)
        Me.gbInputs.TabIndex = 0
        Me.gbInputs.TabStop = False
        Me.gbInputs.Text = "Inputs"
        '
        'txtDrawingAmount
        '
        Me.txtDrawingAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDrawingAmount.Location = New System.Drawing.Point(312, 146)
        Me.txtDrawingAmount.Name = "txtDrawingAmount"
        Me.txtDrawingAmount.Size = New System.Drawing.Size(66, 26)
        Me.txtDrawingAmount.TabIndex = 15
        Me.txtDrawingAmount.Text = "10"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(191, 146)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 30)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Number of Drawings " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Per Sequence"
        '
        'txtProteinLength
        '
        Me.txtProteinLength.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProteinLength.Location = New System.Drawing.Point(314, 44)
        Me.txtProteinLength.Name = "txtProteinLength"
        Me.txtProteinLength.Size = New System.Drawing.Size(66, 26)
        Me.txtProteinLength.TabIndex = 13
        '
        'txtTargetValue
        '
        Me.txtTargetValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTargetValue.Location = New System.Drawing.Point(314, 79)
        Me.txtTargetValue.Name = "txtTargetValue"
        Me.txtTargetValue.Size = New System.Drawing.Size(66, 26)
        Me.txtTargetValue.TabIndex = 12
        '
        'txtMaximumIteration
        '
        Me.txtMaximumIteration.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaximumIteration.Location = New System.Drawing.Point(312, 114)
        Me.txtMaximumIteration.Name = "txtMaximumIteration"
        Me.txtMaximumIteration.Size = New System.Drawing.Size(66, 22)
        Me.txtMaximumIteration.TabIndex = 11
        Me.txtMaximumIteration.Text = "9000000"
        '
        'txtMutationRate
        '
        Me.txtMutationRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMutationRate.Location = New System.Drawing.Point(109, 140)
        Me.txtMutationRate.Name = "txtMutationRate"
        Me.txtMutationRate.Size = New System.Drawing.Size(66, 26)
        Me.txtMutationRate.TabIndex = 10
        Me.txtMutationRate.Text = "0.5"
        '
        'txtEliteRate
        '
        Me.txtEliteRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEliteRate.Location = New System.Drawing.Point(109, 70)
        Me.txtEliteRate.Name = "txtEliteRate"
        Me.txtEliteRate.Size = New System.Drawing.Size(66, 26)
        Me.txtEliteRate.TabIndex = 9
        Me.txtEliteRate.Text = "0.10"
        '
        'txtCrossOverRate
        '
        Me.txtCrossOverRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCrossOverRate.Location = New System.Drawing.Point(109, 105)
        Me.txtCrossOverRate.Name = "txtCrossOverRate"
        Me.txtCrossOverRate.Size = New System.Drawing.Size(66, 26)
        Me.txtCrossOverRate.TabIndex = 8
        Me.txtCrossOverRate.Text = "1.00"
        '
        'txtPopulationSize
        '
        Me.txtPopulationSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPopulationSize.Location = New System.Drawing.Point(109, 35)
        Me.txtPopulationSize.Name = "txtPopulationSize"
        Me.txtPopulationSize.Size = New System.Drawing.Size(66, 26)
        Me.txtPopulationSize.TabIndex = 7
        Me.txtPopulationSize.Text = "200"
        '
        'lblMaximumIteration
        '
        Me.lblMaximumIteration.AutoSize = True
        Me.lblMaximumIteration.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaximumIteration.Location = New System.Drawing.Point(191, 114)
        Me.lblMaximumIteration.Name = "lblMaximumIteration"
        Me.lblMaximumIteration.Size = New System.Drawing.Size(115, 16)
        Me.lblMaximumIteration.TabIndex = 6
        Me.lblMaximumIteration.Text = "Maximum Iteration"
        '
        'lblTargetValue
        '
        Me.lblTargetValue.AutoSize = True
        Me.lblTargetValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTargetValue.Location = New System.Drawing.Point(220, 79)
        Me.lblTargetValue.Name = "lblTargetValue"
        Me.lblTargetValue.Size = New System.Drawing.Size(86, 16)
        Me.lblTargetValue.TabIndex = 5
        Me.lblTargetValue.Text = "Target Value"
        '
        'lblProteinLength
        '
        Me.lblProteinLength.AutoSize = True
        Me.lblProteinLength.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProteinLength.Location = New System.Drawing.Point(213, 44)
        Me.lblProteinLength.Name = "lblProteinLength"
        Me.lblProteinLength.Size = New System.Drawing.Size(93, 16)
        Me.lblProteinLength.TabIndex = 4
        Me.lblProteinLength.Text = "Protein Length"
        '
        'lblMutationRate
        '
        Me.lblMutationRate.AutoSize = True
        Me.lblMutationRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMutationRate.Location = New System.Drawing.Point(13, 140)
        Me.lblMutationRate.Name = "lblMutationRate"
        Me.lblMutationRate.Size = New System.Drawing.Size(90, 16)
        Me.lblMutationRate.TabIndex = 3
        Me.lblMutationRate.Text = "Mutation Rate"
        '
        'lblCrossOverRate
        '
        Me.lblCrossOverRate.AutoSize = True
        Me.lblCrossOverRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCrossOverRate.Location = New System.Drawing.Point(2, 107)
        Me.lblCrossOverRate.Name = "lblCrossOverRate"
        Me.lblCrossOverRate.Size = New System.Drawing.Size(104, 16)
        Me.lblCrossOverRate.TabIndex = 2
        Me.lblCrossOverRate.Text = "CrossOver Rate"
        '
        'lblEliteRate
        '
        Me.lblEliteRate.AutoSize = True
        Me.lblEliteRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEliteRate.Location = New System.Drawing.Point(37, 70)
        Me.lblEliteRate.Name = "lblEliteRate"
        Me.lblEliteRate.Size = New System.Drawing.Size(66, 16)
        Me.lblEliteRate.TabIndex = 1
        Me.lblEliteRate.Text = "Elite Rate"
        '
        'lblPopulationSize
        '
        Me.lblPopulationSize.AutoSize = True
        Me.lblPopulationSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPopulationSize.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblPopulationSize.Location = New System.Drawing.Point(2, 35)
        Me.lblPopulationSize.Name = "lblPopulationSize"
        Me.lblPopulationSize.Size = New System.Drawing.Size(101, 16)
        Me.lblPopulationSize.TabIndex = 0
        Me.lblPopulationSize.Text = "Population Size"
        '
        'gbDrawing
        '
        Me.gbDrawing.Controls.Add(Me.PictureBox1)
        Me.gbDrawing.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.gbDrawing.Location = New System.Drawing.Point(5, 227)
        Me.gbDrawing.Name = "gbDrawing"
        Me.gbDrawing.Size = New System.Drawing.Size(774, 473)
        Me.gbDrawing.TabIndex = 1
        Me.gbDrawing.TabStop = False
        Me.gbDrawing.Text = "Drawing"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(7, 28)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(761, 439)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Start
        '
        Me.Start.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Start.Location = New System.Drawing.Point(19, 199)
        Me.Start.Name = "Start"
        Me.Start.Size = New System.Drawing.Size(82, 31)
        Me.Start.TabIndex = 2
        Me.Start.Text = "Start"
        Me.Start.UseVisualStyleBackColor = True
        '
        'gbReadProtein
        '
        Me.gbReadProtein.Controls.Add(Me.txtInputLocation)
        Me.gbReadProtein.Controls.Add(Me.Label1)
        Me.gbReadProtein.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbReadProtein.Location = New System.Drawing.Point(427, 21)
        Me.gbReadProtein.Name = "gbReadProtein"
        Me.gbReadProtein.Size = New System.Drawing.Size(268, 111)
        Me.gbReadProtein.TabIndex = 4
        Me.gbReadProtein.TabStop = False
        Me.gbReadProtein.Text = "Read Protein"
        '
        'txtInputLocation
        '
        Me.txtInputLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtInputLocation.ForeColor = System.Drawing.Color.Crimson
        Me.txtInputLocation.Location = New System.Drawing.Point(13, 65)
        Me.txtInputLocation.Name = "txtInputLocation"
        Me.txtInputLocation.Size = New System.Drawing.Size(227, 23)
        Me.txtInputLocation.TabIndex = 1
        Me.txtInputLocation.Text = "C:\Users\Austin\Desktop\Input.txt"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(6, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(196, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter input file location below:"
        '
        'lblFitness1
        '
        Me.lblFitness1.AutoSize = True
        Me.lblFitness1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFitness1.Location = New System.Drawing.Point(451, 135)
        Me.lblFitness1.Name = "lblFitness1"
        Me.lblFitness1.Size = New System.Drawing.Size(75, 24)
        Me.lblFitness1.TabIndex = 5
        Me.lblFitness1.Text = "Fitness:"
        '
        'btnNextDrawing
        '
        Me.btnNextDrawing.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btnNextDrawing.Location = New System.Drawing.Point(122, 199)
        Me.btnNextDrawing.Name = "btnNextDrawing"
        Me.btnNextDrawing.Size = New System.Drawing.Size(120, 31)
        Me.btnNextDrawing.TabIndex = 6
        Me.btnNextDrawing.Text = "Next Drawing"
        Me.btnNextDrawing.UseVisualStyleBackColor = True
        '
        'btnNextSequence
        '
        Me.btnNextSequence.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNextSequence.Location = New System.Drawing.Point(257, 199)
        Me.btnNextSequence.Name = "btnNextSequence"
        Me.btnNextSequence.Size = New System.Drawing.Size(142, 31)
        Me.btnNextSequence.TabIndex = 7
        Me.btnNextSequence.Text = "Next Sequence"
        Me.btnNextSequence.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNextSequence.UseVisualStyleBackColor = True
        '
        'lblSequence1
        '
        Me.lblSequence1.AutoSize = True
        Me.lblSequence1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSequence1.Location = New System.Drawing.Point(423, 169)
        Me.lblSequence1.Name = "lblSequence1"
        Me.lblSequence1.Size = New System.Drawing.Size(103, 24)
        Me.lblSequence1.TabIndex = 8
        Me.lblSequence1.Text = "Sequence:"
        '
        'lblDrawing1
        '
        Me.lblDrawing1.AutoSize = True
        Me.lblDrawing1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDrawing1.Location = New System.Drawing.Point(442, 206)
        Me.lblDrawing1.Name = "lblDrawing1"
        Me.lblDrawing1.Size = New System.Drawing.Size(84, 24)
        Me.lblDrawing1.TabIndex = 9
        Me.lblDrawing1.Text = "Drawing:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(627, 199)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 16)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Hydrophobic:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(637, 169)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Hydrophilic:"
        '
        'pbHydrophilic
        '
        Me.pbHydrophilic.BackColor = System.Drawing.Color.Green
        Me.pbHydrophilic.Location = New System.Drawing.Point(713, 169)
        Me.pbHydrophilic.Name = "pbHydrophilic"
        Me.pbHydrophilic.Size = New System.Drawing.Size(18, 16)
        Me.pbHydrophilic.TabIndex = 12
        Me.pbHydrophilic.TabStop = False
        '
        'pbHydrophobic
        '
        Me.pbHydrophobic.BackColor = System.Drawing.Color.Red
        Me.pbHydrophobic.Location = New System.Drawing.Point(713, 199)
        Me.pbHydrophobic.Name = "pbHydrophobic"
        Me.pbHydrophobic.Size = New System.Drawing.Size(18, 16)
        Me.pbHydrophobic.TabIndex = 13
        Me.pbHydrophobic.TabStop = False
        '
        'ProteinSequence
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(783, 702)
        Me.Controls.Add(Me.pbHydrophobic)
        Me.Controls.Add(Me.pbHydrophilic)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblDrawing1)
        Me.Controls.Add(Me.lblSequence1)
        Me.Controls.Add(Me.btnNextSequence)
        Me.Controls.Add(Me.lblFitness1)
        Me.Controls.Add(Me.btnNextDrawing)
        Me.Controls.Add(Me.gbReadProtein)
        Me.Controls.Add(Me.Start)
        Me.Controls.Add(Me.gbDrawing)
        Me.Controls.Add(Me.gbInputs)
        Me.Name = "ProteinSequence"
        Me.Text = "Protein Sequence"
        Me.gbInputs.ResumeLayout(False)
        Me.gbInputs.PerformLayout()
        Me.gbDrawing.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbReadProtein.ResumeLayout(False)
        Me.gbReadProtein.PerformLayout()
        CType(Me.pbHydrophilic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbHydrophobic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gbInputs As GroupBox
    Friend WithEvents gbDrawing As GroupBox
    Friend WithEvents Start As Button
    Friend WithEvents lblPopulationSize As Label
    Friend WithEvents lblMaximumIteration As Label
    Friend WithEvents lblTargetValue As Label
    Friend WithEvents lblProteinLength As Label
    Friend WithEvents lblMutationRate As Label
    Friend WithEvents lblCrossOverRate As Label
    Friend WithEvents lblEliteRate As Label
    Friend WithEvents txtPopulationSize As TextBox
    Friend WithEvents txtProteinLength As TextBox
    Friend WithEvents txtTargetValue As TextBox
    Friend WithEvents txtMaximumIteration As TextBox
    Friend WithEvents txtMutationRate As TextBox
    Friend WithEvents txtEliteRate As TextBox
    Friend WithEvents txtCrossOverRate As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents gbReadProtein As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtInputLocation As TextBox
    Friend WithEvents lblFitness1 As Label
    Friend WithEvents btnNextDrawing As Button
    Friend WithEvents btnNextSequence As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDrawingAmount As TextBox
    Friend WithEvents lblSequence1 As Label
    Friend WithEvents lblDrawing1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents pbHydrophilic As PictureBox
    Friend WithEvents pbHydrophobic As PictureBox
End Class
