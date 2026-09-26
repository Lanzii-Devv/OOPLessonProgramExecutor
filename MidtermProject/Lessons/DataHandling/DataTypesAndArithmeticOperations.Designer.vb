<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataTypesAndArithmeticOperations
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DataTypesAndArithmeticOperations))
        SplitContainer1 = New SplitContainer()
        rtbExplanation = New RichTextBox()
        explanation = New Label()
        lblTitle = New Label()
        grpDataType = New GroupBox()
        lblResult = New Label()
        lblResultTitle = New Label()
        btnCalculate = New Button()
        grpOperation = New GroupBox()
        rbDivide = New RadioButton()
        rbMultiply = New RadioButton()
        rbSubtract = New RadioButton()
        rbAdd = New RadioButton()
        txtFirstNumber = New TextBox()
        txtSecondNumber = New TextBox()
        lblSecondNumber = New Label()
        lblFirstNumber = New Label()
        rbDecimal = New RadioButton()
        rbSingle = New RadioButton()
        rbDouble = New RadioButton()
        rbInteger = New RadioButton()
        lblExecutionTitle = New Label()
        lblSampleCode = New Label()
        rtbCode = New RichTextBox()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        grpDataType.SuspendLayout()
        grpOperation.SuspendLayout()
        SuspendLayout()
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.Location = New Point(0, 0)
        SplitContainer1.Name = "SplitContainer1"
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.Controls.Add(rtbCode)
        SplitContainer1.Panel1.Controls.Add(lblSampleCode)
        SplitContainer1.Panel1.Controls.Add(rtbExplanation)
        SplitContainer1.Panel1.Controls.Add(explanation)
        SplitContainer1.Panel1.Controls.Add(lblTitle)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(grpDataType)
        SplitContainer1.Panel2.Controls.Add(lblExecutionTitle)
        SplitContainer1.Size = New Size(896, 631)
        SplitContainer1.SplitterDistance = 423
        SplitContainer1.TabIndex = 0
        ' 
        ' rtbExplanation
        ' 
        rtbExplanation.Font = New Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        rtbExplanation.Location = New Point(12, 66)
        rtbExplanation.Name = "rtbExplanation"
        rtbExplanation.ReadOnly = True
        rtbExplanation.ScrollBars = RichTextBoxScrollBars.Vertical
        rtbExplanation.Size = New Size(393, 209)
        rtbExplanation.TabIndex = 2
        rtbExplanation.Text = resources.GetString("rtbExplanation.Text")
        ' 
        ' explanation
        ' 
        explanation.AutoSize = True
        explanation.Location = New Point(12, 43)
        explanation.Name = "explanation"
        explanation.Size = New Size(71, 15)
        explanation.TabIndex = 1
        explanation.Text = "Explanation:"
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(12, 9)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(228, 15)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Data Handling And Arithmetic Operations"
        ' 
        ' grpDataType
        ' 
        grpDataType.Controls.Add(lblResult)
        grpDataType.Controls.Add(lblResultTitle)
        grpDataType.Controls.Add(btnCalculate)
        grpDataType.Controls.Add(grpOperation)
        grpDataType.Controls.Add(txtFirstNumber)
        grpDataType.Controls.Add(txtSecondNumber)
        grpDataType.Controls.Add(lblSecondNumber)
        grpDataType.Controls.Add(lblFirstNumber)
        grpDataType.Controls.Add(rbDecimal)
        grpDataType.Controls.Add(rbSingle)
        grpDataType.Controls.Add(rbDouble)
        grpDataType.Controls.Add(rbInteger)
        grpDataType.Location = New Point(13, 43)
        grpDataType.Name = "grpDataType"
        grpDataType.Size = New Size(444, 576)
        grpDataType.TabIndex = 1
        grpDataType.TabStop = False
        grpDataType.Text = "Select Data Type"
        ' 
        ' lblResult
        ' 
        lblResult.AutoSize = True
        lblResult.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblResult.Location = New Point(76, 417)
        lblResult.Name = "lblResult"
        lblResult.Size = New Size(16, 21)
        lblResult.TabIndex = 11
        lblResult.Text = "-"
        ' 
        ' lblResultTitle
        ' 
        lblResultTitle.AutoSize = True
        lblResultTitle.Location = New Point(17, 422)
        lblResultTitle.Name = "lblResultTitle"
        lblResultTitle.Size = New Size(42, 15)
        lblResultTitle.TabIndex = 10
        lblResultTitle.Text = "Result:"
        ' 
        ' btnCalculate
        ' 
        btnCalculate.Location = New Point(17, 378)
        btnCalculate.Name = "btnCalculate"
        btnCalculate.Size = New Size(75, 23)
        btnCalculate.TabIndex = 9
        btnCalculate.Text = "Calculate"
        btnCalculate.UseVisualStyleBackColor = True
        ' 
        ' grpOperation
        ' 
        grpOperation.Controls.Add(rbDivide)
        grpOperation.Controls.Add(rbMultiply)
        grpOperation.Controls.Add(rbSubtract)
        grpOperation.Controls.Add(rbAdd)
        grpOperation.Location = New Point(17, 250)
        grpOperation.Name = "grpOperation"
        grpOperation.Size = New Size(421, 100)
        grpOperation.TabIndex = 8
        grpOperation.TabStop = False
        grpOperation.Text = "Select Operation"
        ' 
        ' rbDivide
        ' 
        rbDivide.AutoSize = True
        rbDivide.Location = New Point(196, 63)
        rbDivide.Name = "rbDivide"
        rbDivide.Size = New Size(78, 19)
        rbDivide.TabIndex = 3
        rbDivide.Text = "÷ Division"
        rbDivide.UseVisualStyleBackColor = True
        ' 
        ' rbMultiply
        ' 
        rbMultiply.AutoSize = True
        rbMultiply.Location = New Point(6, 63)
        rbMultiply.Name = "rbMultiply"
        rbMultiply.Size = New Size(107, 19)
        rbMultiply.TabIndex = 2
        rbMultiply.Text = "x Multiplication"
        rbMultiply.UseVisualStyleBackColor = True
        ' 
        ' rbSubtract
        ' 
        rbSubtract.AutoSize = True
        rbSubtract.Location = New Point(196, 22)
        rbSubtract.Name = "rbSubtract"
        rbSubtract.Size = New Size(94, 19)
        rbSubtract.TabIndex = 1
        rbSubtract.Text = "- Subtraction"
        rbSubtract.UseVisualStyleBackColor = True
        ' 
        ' rbAdd
        ' 
        rbAdd.AutoSize = True
        rbAdd.Checked = True
        rbAdd.Location = New Point(6, 22)
        rbAdd.Name = "rbAdd"
        rbAdd.Size = New Size(82, 19)
        rbAdd.TabIndex = 0
        rbAdd.TabStop = True
        rbAdd.Text = "+ Addition"
        rbAdd.UseVisualStyleBackColor = True
        ' 
        ' txtFirstNumber
        ' 
        txtFirstNumber.Location = New Point(17, 144)
        txtFirstNumber.Name = "txtFirstNumber"
        txtFirstNumber.Size = New Size(150, 23)
        txtFirstNumber.TabIndex = 7
        ' 
        ' txtSecondNumber
        ' 
        txtSecondNumber.Location = New Point(17, 209)
        txtSecondNumber.Name = "txtSecondNumber"
        txtSecondNumber.Size = New Size(150, 23)
        txtSecondNumber.TabIndex = 6
        ' 
        ' lblSecondNumber
        ' 
        lblSecondNumber.AutoSize = True
        lblSecondNumber.Location = New Point(17, 182)
        lblSecondNumber.Name = "lblSecondNumber"
        lblSecondNumber.Size = New Size(93, 15)
        lblSecondNumber.TabIndex = 5
        lblSecondNumber.Text = "Second Number"
        ' 
        ' lblFirstNumber
        ' 
        lblFirstNumber.AutoSize = True
        lblFirstNumber.Location = New Point(17, 113)
        lblFirstNumber.Name = "lblFirstNumber"
        lblFirstNumber.Size = New Size(76, 15)
        lblFirstNumber.TabIndex = 4
        lblFirstNumber.Text = "First Number"
        ' 
        ' rbDecimal
        ' 
        rbDecimal.AutoSize = True
        rbDecimal.Location = New Point(138, 55)
        rbDecimal.Name = "rbDecimal"
        rbDecimal.Size = New Size(68, 19)
        rbDecimal.TabIndex = 3
        rbDecimal.Text = "Decimal"
        rbDecimal.UseVisualStyleBackColor = True
        ' 
        ' rbSingle
        ' 
        rbSingle.AutoSize = True
        rbSingle.Location = New Point(17, 55)
        rbSingle.Name = "rbSingle"
        rbSingle.Size = New Size(57, 19)
        rbSingle.TabIndex = 2
        rbSingle.Text = "Single"
        rbSingle.UseVisualStyleBackColor = True
        ' 
        ' rbDouble
        ' 
        rbDouble.AutoSize = True
        rbDouble.Location = New Point(138, 22)
        rbDouble.Name = "rbDouble"
        rbDouble.Size = New Size(63, 19)
        rbDouble.TabIndex = 1
        rbDouble.Text = "Double"
        rbDouble.UseVisualStyleBackColor = True
        ' 
        ' rbInteger
        ' 
        rbInteger.AutoSize = True
        rbInteger.Checked = True
        rbInteger.Location = New Point(17, 20)
        rbInteger.Name = "rbInteger"
        rbInteger.Size = New Size(62, 19)
        rbInteger.TabIndex = 0
        rbInteger.TabStop = True
        rbInteger.Text = "Integer"
        rbInteger.UseVisualStyleBackColor = True
        ' 
        ' lblExecutionTitle
        ' 
        lblExecutionTitle.AutoSize = True
        lblExecutionTitle.Location = New Point(3, 9)
        lblExecutionTitle.Name = "lblExecutionTitle"
        lblExecutionTitle.Size = New Size(105, 15)
        lblExecutionTitle.TabIndex = 0
        lblExecutionTitle.Text = "Execution Example"
        ' 
        ' lblSampleCode
        ' 
        lblSampleCode.AutoSize = True
        lblSampleCode.Location = New Point(12, 293)
        lblSampleCode.Name = "lblSampleCode"
        lblSampleCode.Size = New Size(77, 15)
        lblSampleCode.TabIndex = 3
        lblSampleCode.Text = "Sample Code"
        ' 
        ' rtbCode
        ' 
        rtbCode.Font = New Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        rtbCode.Location = New Point(12, 315)
        rtbCode.Name = "rtbCode"
        rtbCode.ReadOnly = True
        rtbCode.ScrollBars = RichTextBoxScrollBars.Vertical
        rtbCode.Size = New Size(393, 209)
        rtbCode.TabIndex = 4
        rtbCode.Text = resources.GetString("rtbCode.Text")
        ' 
        ' DataTypesAndArithmeticOperations
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(896, 631)
        Controls.Add(SplitContainer1)
        Name = "DataTypesAndArithmeticOperations"
        Text = "DataTypesAndArithmeticOperations"
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel1.PerformLayout()
        SplitContainer1.Panel2.ResumeLayout(False)
        SplitContainer1.Panel2.PerformLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        grpDataType.ResumeLayout(False)
        grpDataType.PerformLayout()
        grpOperation.ResumeLayout(False)
        grpOperation.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents rtbExplanation As RichTextBox
    Friend WithEvents explanation As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblExecutionTitle As Label
    Friend WithEvents grpDataType As GroupBox
    Friend WithEvents rbDecimal As RadioButton
    Friend WithEvents rbSingle As RadioButton
    Friend WithEvents rbDouble As RadioButton
    Friend WithEvents rbInteger As RadioButton
    Friend WithEvents txtFirstNumber As TextBox
    Friend WithEvents txtSecondNumber As TextBox
    Friend WithEvents lblSecondNumber As Label
    Friend WithEvents lblFirstNumber As Label
    Friend WithEvents grpOperation As GroupBox
    Friend WithEvents lblResultTitle As Label
    Friend WithEvents btnCalculate As Button
    Friend WithEvents rbDivide As RadioButton
    Friend WithEvents rbMultiply As RadioButton
    Friend WithEvents rbSubtract As RadioButton
    Friend WithEvents rbAdd As RadioButton
    Friend WithEvents lblResult As Label
    Friend WithEvents rtbCode As RichTextBox
    Friend WithEvents lblSampleCode As Label
End Class
