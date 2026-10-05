<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ExcessiveControls
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

    'NOTE: The following procedure is required by the Windows Form Designer.
    'It can be modified using the Windows Form Designer. Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExcessiveControls))
        tlpMain = New TableLayoutPanel()
        tlpLeft = New TableLayoutPanel()
        lblLeftTitle = New Label()
        lblExplanation = New Label()
        txtExplanation = New TextBox()
        lblSampleCode = New Label()
        txtSampleCode = New TextBox()
        tlpRight = New TableLayoutPanel()
        lblTruthTableTitle = New Label()
        grpOperator = New GroupBox()
        tlpOperators = New TableLayoutPanel()
        rdoAnd = New RadioButton()
        rdoOr = New RadioButton()
        rdoNot = New RadioButton()
        rdoXor = New RadioButton()
        grpInputs = New GroupBox()
        tlpInputs = New TableLayoutPanel()
        chkA = New CheckBox()
        chkB = New CheckBox()
        tlpButtons = New TableLayoutPanel()
        btnSubmit = New Button()
        btnClear = New Button()
        btnExit = New Button()
        lblResult = New Label()
        lvTruthTable = New ListView()
        colA = New ColumnHeader()
        colB = New ColumnHeader()
        colResult = New ColumnHeader()
        statusMain = New StatusStrip()
        tssMessage = New ToolStripStatusLabel()
        tipMain = New ToolTip(components)
        tlpMain.SuspendLayout()
        tlpLeft.SuspendLayout()
        tlpRight.SuspendLayout()
        grpOperator.SuspendLayout()
        tlpOperators.SuspendLayout()
        grpInputs.SuspendLayout()
        tlpInputs.SuspendLayout()
        tlpButtons.SuspendLayout()
        statusMain.SuspendLayout()
        SuspendLayout()
        ' 
        ' tlpMain
        ' 
        tlpMain.ColumnCount = 2
        tlpMain.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        tlpMain.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        tlpMain.Controls.Add(tlpLeft, 0, 0)
        tlpMain.Controls.Add(tlpRight, 1, 0)
        tlpMain.Controls.Add(statusMain, 0, 1)
        tlpMain.Dock = DockStyle.Fill
        tlpMain.Location = New Point(0, 0)
        tlpMain.Name = "tlpMain"
        tlpMain.Padding = New Padding(8)
        tlpMain.RowCount = 2
        tlpMain.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        tlpMain.RowStyles.Add(New RowStyle(SizeType.Absolute, 26.0F))
        tlpMain.Size = New Size(940, 601)
        tlpMain.TabIndex = 0
        ' 
        ' tlpLeft
        ' 
        tlpLeft.ColumnCount = 1
        tlpLeft.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        tlpLeft.Controls.Add(lblLeftTitle, 0, 0)
        tlpLeft.Controls.Add(lblExplanation, 0, 1)
        tlpLeft.Controls.Add(txtExplanation, 0, 2)
        tlpLeft.Controls.Add(lblSampleCode, 0, 3)
        tlpLeft.Controls.Add(txtSampleCode, 0, 4)
        tlpLeft.Dock = DockStyle.Fill
        tlpLeft.Location = New Point(11, 11)
        tlpLeft.Name = "tlpLeft"
        tlpLeft.RowCount = 5
        tlpLeft.RowStyles.Add(New RowStyle(SizeType.Absolute, 32.0F))
        tlpLeft.RowStyles.Add(New RowStyle(SizeType.Absolute, 26.0F))
        tlpLeft.RowStyles.Add(New RowStyle(SizeType.Percent, 55.0F))
        tlpLeft.RowStyles.Add(New RowStyle(SizeType.Absolute, 26.0F))
        tlpLeft.RowStyles.Add(New RowStyle(SizeType.Percent, 45.0F))
        tlpLeft.Size = New Size(456, 553)
        tlpLeft.TabIndex = 0
        ' 
        ' lblLeftTitle
        ' 
        lblLeftTitle.Dock = DockStyle.Fill
        lblLeftTitle.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold)
        lblLeftTitle.ForeColor = Color.FromArgb(CByte(31), CByte(78), CByte(121))
        lblLeftTitle.Location = New Point(3, 0)
        lblLeftTitle.Name = "lblLeftTitle"
        lblLeftTitle.Size = New Size(450, 32)
        lblLeftTitle.TabIndex = 0
        lblLeftTitle.Text = "Logical Operators"
        lblLeftTitle.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblExplanation
        ' 
        lblExplanation.Dock = DockStyle.Fill
        lblExplanation.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        lblExplanation.Location = New Point(3, 32)
        lblExplanation.Name = "lblExplanation"
        lblExplanation.Size = New Size(450, 26)
        lblExplanation.TabIndex = 1
        lblExplanation.Text = "Explanation"
        lblExplanation.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' txtExplanation
        ' 
        txtExplanation.BackColor = SystemColors.Window
        txtExplanation.Dock = DockStyle.Fill
        txtExplanation.Font = New Font("Segoe UI", 10.0F)
        txtExplanation.Location = New Point(3, 61)
        txtExplanation.Multiline = True
        txtExplanation.Name = "txtExplanation"
        txtExplanation.ReadOnly = True
        txtExplanation.ScrollBars = ScrollBars.Vertical
        txtExplanation.Size = New Size(450, 251)
        txtExplanation.TabIndex = 2
        txtExplanation.Text = resources.GetString("txtExplanation.Text")
        ' 
        ' lblSampleCode
        ' 
        lblSampleCode.Dock = DockStyle.Fill
        lblSampleCode.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        lblSampleCode.Location = New Point(3, 315)
        lblSampleCode.Name = "lblSampleCode"
        lblSampleCode.Size = New Size(450, 26)
        lblSampleCode.TabIndex = 3
        lblSampleCode.Text = "Sample Code"
        lblSampleCode.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' txtSampleCode
        ' 
        txtSampleCode.BackColor = SystemColors.Window
        txtSampleCode.Dock = DockStyle.Fill
        txtSampleCode.Font = New Font("Consolas", 10.0F)
        txtSampleCode.Location = New Point(3, 344)
        txtSampleCode.Multiline = True
        txtSampleCode.Name = "txtSampleCode"
        txtSampleCode.ReadOnly = True
        txtSampleCode.ScrollBars = ScrollBars.Both
        txtSampleCode.Size = New Size(450, 206)
        txtSampleCode.TabIndex = 4
        txtSampleCode.Text = resources.GetString("txtSampleCode.Text")
        txtSampleCode.WordWrap = False
        ' 
        ' tlpRight
        ' 
        tlpRight.ColumnCount = 1
        tlpRight.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        tlpRight.Controls.Add(lblTruthTableTitle, 0, 0)
        tlpRight.Controls.Add(grpOperator, 0, 1)
        tlpRight.Controls.Add(grpInputs, 0, 2)
        tlpRight.Controls.Add(tlpButtons, 0, 3)
        tlpRight.Controls.Add(lblResult, 0, 4)
        tlpRight.Controls.Add(lvTruthTable, 0, 5)
        tlpRight.Dock = DockStyle.Fill
        tlpRight.Location = New Point(473, 11)
        tlpRight.Name = "tlpRight"
        tlpRight.RowCount = 6
        tlpRight.RowStyles.Add(New RowStyle(SizeType.Absolute, 32.0F))
        tlpRight.RowStyles.Add(New RowStyle(SizeType.Absolute, 70.0F))
        tlpRight.RowStyles.Add(New RowStyle(SizeType.Absolute, 70.0F))
        tlpRight.RowStyles.Add(New RowStyle(SizeType.Absolute, 56.0F))
        tlpRight.RowStyles.Add(New RowStyle(SizeType.Absolute, 48.0F))
        tlpRight.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        tlpRight.Size = New Size(456, 553)
        tlpRight.TabIndex = 1
        ' 
        ' lblTruthTableTitle
        ' 
        lblTruthTableTitle.Dock = DockStyle.Fill
        lblTruthTableTitle.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold)
        lblTruthTableTitle.ForeColor = Color.FromArgb(CByte(31), CByte(78), CByte(121))
        lblTruthTableTitle.Location = New Point(3, 0)
        lblTruthTableTitle.Name = "lblTruthTableTitle"
        lblTruthTableTitle.Size = New Size(450, 32)
        lblTruthTableTitle.TabIndex = 0
        lblTruthTableTitle.Text = "Logical Operators Truth Table"
        lblTruthTableTitle.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' grpOperator
        ' 
        grpOperator.Controls.Add(tlpOperators)
        grpOperator.Dock = DockStyle.Fill
        grpOperator.Location = New Point(3, 35)
        grpOperator.Name = "grpOperator"
        grpOperator.Size = New Size(450, 64)
        grpOperator.TabIndex = 1
        grpOperator.TabStop = False
        grpOperator.Text = "Select Logical Operator"
        ' 
        ' tlpOperators
        ' 
        tlpOperators.ColumnCount = 4
        tlpOperators.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))
        tlpOperators.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))
        tlpOperators.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))
        tlpOperators.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))
        tlpOperators.Controls.Add(rdoAnd, 0, 0)
        tlpOperators.Controls.Add(rdoOr, 1, 0)
        tlpOperators.Controls.Add(rdoNot, 2, 0)
        tlpOperators.Controls.Add(rdoXor, 3, 0)
        tlpOperators.Dock = DockStyle.Fill
        tlpOperators.Location = New Point(3, 19)
        tlpOperators.Name = "tlpOperators"
        tlpOperators.RowCount = 1
        tlpOperators.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        tlpOperators.Size = New Size(444, 42)
        tlpOperators.TabIndex = 0
        ' 
        ' rdoAnd
        ' 
        rdoAnd.Anchor = AnchorStyles.Left
        rdoAnd.AutoSize = True
        rdoAnd.Checked = True
        rdoAnd.Location = New Point(3, 11)
        rdoAnd.Name = "rdoAnd"
        rdoAnd.Size = New Size(50, 19)
        rdoAnd.TabIndex = 0
        rdoAnd.TabStop = True
        rdoAnd.Text = "AND"
        tipMain.SetToolTip(rdoAnd, "True only when BOTH are True")
        rdoAnd.UseVisualStyleBackColor = True
        ' 
        ' rdoOr
        ' 
        rdoOr.Anchor = AnchorStyles.Left
        rdoOr.AutoSize = True
        rdoOr.Location = New Point(114, 11)
        rdoOr.Name = "rdoOr"
        rdoOr.Size = New Size(41, 19)
        rdoOr.TabIndex = 1
        rdoOr.Text = "OR"
        tipMain.SetToolTip(rdoOr, "True when AT LEAST ONE is True")
        rdoOr.UseVisualStyleBackColor = True
        ' 
        ' rdoNot
        ' 
        rdoNot.Anchor = AnchorStyles.Left
        rdoNot.AutoSize = True
        rdoNot.Location = New Point(225, 11)
        rdoNot.Name = "rdoNot"
        rdoNot.Size = New Size(49, 19)
        rdoNot.TabIndex = 2
        rdoNot.Text = "NOT"
        tipMain.SetToolTip(rdoNot, "Reverses A (B is not used)")
        rdoNot.UseVisualStyleBackColor = True
        ' 
        ' rdoXor
        ' 
        rdoXor.Anchor = AnchorStyles.Left
        rdoXor.AutoSize = True
        rdoXor.Location = New Point(336, 11)
        rdoXor.Name = "rdoXor"
        rdoXor.Size = New Size(48, 19)
        rdoXor.TabIndex = 3
        rdoXor.Text = "XOR"
        tipMain.SetToolTip(rdoXor, "True only when A and B are DIFFERENT")
        rdoXor.UseVisualStyleBackColor = True
        ' 
        ' grpInputs
        ' 
        grpInputs.Controls.Add(tlpInputs)
        grpInputs.Dock = DockStyle.Fill
        grpInputs.Location = New Point(3, 105)
        grpInputs.Name = "grpInputs"
        grpInputs.Size = New Size(450, 64)
        grpInputs.TabIndex = 2
        grpInputs.TabStop = False
        grpInputs.Text = "Input Values  (ticked = True, unticked = False)"
        ' 
        ' tlpInputs
        ' 
        tlpInputs.ColumnCount = 2
        tlpInputs.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        tlpInputs.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        tlpInputs.Controls.Add(chkA, 0, 0)
        tlpInputs.Controls.Add(chkB, 1, 0)
        tlpInputs.Dock = DockStyle.Fill
        tlpInputs.Location = New Point(3, 19)
        tlpInputs.Name = "tlpInputs"
        tlpInputs.RowCount = 1
        tlpInputs.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        tlpInputs.Size = New Size(444, 42)
        tlpInputs.TabIndex = 0
        ' 
        ' chkA
        ' 
        chkA.Anchor = AnchorStyles.Left
        chkA.AutoSize = True
        chkA.Location = New Point(3, 11)
        chkA.Name = "chkA"
        chkA.Size = New Size(74, 19)
        chkA.TabIndex = 0
        chkA.Text = "A = False"
        tipMain.SetToolTip(chkA, "Value of A")
        chkA.UseVisualStyleBackColor = True
        ' 
        ' chkB
        ' 
        chkB.Anchor = AnchorStyles.Left
        chkB.AutoSize = True
        chkB.Location = New Point(225, 11)
        chkB.Name = "chkB"
        chkB.Size = New Size(73, 19)
        chkB.TabIndex = 1
        chkB.Text = "B = False"
        tipMain.SetToolTip(chkB, "Value of B")
        chkB.UseVisualStyleBackColor = True
        ' 
        ' tlpButtons
        ' 
        tlpButtons.ColumnCount = 3
        tlpButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33F))
        tlpButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33F))
        tlpButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.34F))
        tlpButtons.Controls.Add(btnSubmit, 0, 0)
        tlpButtons.Controls.Add(btnClear, 1, 0)
        tlpButtons.Controls.Add(btnExit, 2, 0)
        tlpButtons.Dock = DockStyle.Fill
        tlpButtons.Location = New Point(3, 175)
        tlpButtons.Name = "tlpButtons"
        tlpButtons.RowCount = 1
        tlpButtons.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        tlpButtons.Size = New Size(450, 50)
        tlpButtons.TabIndex = 3
        ' 
        ' btnSubmit
        ' 
        btnSubmit.BackColor = Color.FromArgb(CByte(46), CByte(125), CByte(50))
        btnSubmit.Dock = DockStyle.Fill
        btnSubmit.FlatAppearance.BorderSize = 0
        btnSubmit.FlatStyle = FlatStyle.Flat
        btnSubmit.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnSubmit.ForeColor = Color.White
        btnSubmit.Location = New Point(4, 4)
        btnSubmit.Margin = New Padding(4)
        btnSubmit.Name = "btnSubmit"
        btnSubmit.Size = New Size(141, 42)
        btnSubmit.TabIndex = 0
        btnSubmit.Text = "SUBMIT"
        tipMain.SetToolTip(btnSubmit, "Evaluate the chosen operator using A and B")
        btnSubmit.UseVisualStyleBackColor = False
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = Color.FromArgb(CByte(230), CByte(126), CByte(34))
        btnClear.Dock = DockStyle.Fill
        btnClear.FlatAppearance.BorderSize = 0
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnClear.ForeColor = Color.White
        btnClear.Location = New Point(153, 4)
        btnClear.Margin = New Padding(4)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(141, 42)
        btnClear.TabIndex = 1
        btnClear.Text = "CLEAR"
        tipMain.SetToolTip(btnClear, "Reset the operator, inputs and result")
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' btnExit
        ' 
        btnExit.BackColor = Color.FromArgb(CByte(192), CByte(57), CByte(43))
        btnExit.Dock = DockStyle.Fill
        btnExit.FlatAppearance.BorderSize = 0
        btnExit.FlatStyle = FlatStyle.Flat
        btnExit.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnExit.ForeColor = Color.White
        btnExit.Location = New Point(302, 4)
        btnExit.Margin = New Padding(4)
        btnExit.Name = "btnExit"
        btnExit.Size = New Size(144, 42)
        btnExit.TabIndex = 2
        btnExit.Text = "EXIT"
        tipMain.SetToolTip(btnExit, "Close the program")
        btnExit.UseVisualStyleBackColor = False
        ' 
        ' lblResult
        ' 
        lblResult.BackColor = Color.WhiteSmoke
        lblResult.BorderStyle = BorderStyle.FixedSingle
        lblResult.Dock = DockStyle.Fill
        lblResult.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        lblResult.ForeColor = Color.Gray
        lblResult.Location = New Point(3, 228)
        lblResult.Name = "lblResult"
        lblResult.Size = New Size(450, 48)
        lblResult.TabIndex = 4
        lblResult.Text = "Result will appear here"
        lblResult.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lvTruthTable
        ' 
        lvTruthTable.Columns.AddRange(New ColumnHeader() {colA, colB, colResult})
        lvTruthTable.Dock = DockStyle.Fill
        lvTruthTable.Font = New Font("Segoe UI", 12.0F)
        lvTruthTable.FullRowSelect = True
        lvTruthTable.GridLines = True
        lvTruthTable.Location = New Point(3, 279)
        lvTruthTable.Name = "lvTruthTable"
        lvTruthTable.Size = New Size(450, 271)
        lvTruthTable.TabIndex = 5
        lvTruthTable.UseCompatibleStateImageBehavior = False
        lvTruthTable.View = View.Details
        ' 
        ' colA
        ' 
        colA.Text = "A"
        colA.Width = 120
        ' 
        ' colB
        ' 
        colB.Text = "B"
        colB.Width = 120
        ' 
        ' colResult
        ' 
        colResult.Text = "Result"
        colResult.Width = 180
        ' 
        ' statusMain
        ' 
        tlpMain.SetColumnSpan(statusMain, 2)
        statusMain.Dock = DockStyle.Fill
        statusMain.Items.AddRange(New ToolStripItem() {tssMessage})
        statusMain.Location = New Point(8, 567)
        statusMain.Name = "statusMain"
        statusMain.Size = New Size(924, 26)
        statusMain.SizingGrip = False
        statusMain.TabIndex = 2
        ' 
        ' tssMessage
        ' 
        tssMessage.Name = "tssMessage"
        tssMessage.Size = New Size(42, 21)
        tssMessage.Text = "Ready."
        ' 
        ' ExcessiveControls
        ' 
        AcceptButton = btnSubmit
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(940, 601)
        Controls.Add(tlpMain)
        Font = New Font("Segoe UI", 9.0F)
        MinimumSize = New Size(880, 640)
        Name = "ExcessiveControls"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Logical Operators"
        tlpMain.ResumeLayout(False)
        tlpMain.PerformLayout()
        tlpLeft.ResumeLayout(False)
        tlpLeft.PerformLayout()
        tlpRight.ResumeLayout(False)
        grpOperator.ResumeLayout(False)
        tlpOperators.ResumeLayout(False)
        tlpOperators.PerformLayout()
        grpInputs.ResumeLayout(False)
        tlpInputs.ResumeLayout(False)
        tlpInputs.PerformLayout()
        tlpButtons.ResumeLayout(False)
        statusMain.ResumeLayout(False)
        statusMain.PerformLayout()
        ResumeLayout(False)

    End Sub

    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlpLeft As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblLeftTitle As System.Windows.Forms.Label
    Friend WithEvents lblExplanation As System.Windows.Forms.Label
    Friend WithEvents txtExplanation As System.Windows.Forms.TextBox
    Friend WithEvents lblSampleCode As System.Windows.Forms.Label
    Friend WithEvents txtSampleCode As System.Windows.Forms.TextBox
    Friend WithEvents tlpRight As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblTruthTableTitle As System.Windows.Forms.Label
    Friend WithEvents grpOperator As System.Windows.Forms.GroupBox
    Friend WithEvents tlpOperators As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rdoAnd As System.Windows.Forms.RadioButton
    Friend WithEvents rdoOr As System.Windows.Forms.RadioButton
    Friend WithEvents rdoNot As System.Windows.Forms.RadioButton
    Friend WithEvents rdoXor As System.Windows.Forms.RadioButton
    Friend WithEvents grpInputs As System.Windows.Forms.GroupBox
    Friend WithEvents tlpInputs As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents chkA As System.Windows.Forms.CheckBox
    Friend WithEvents chkB As System.Windows.Forms.CheckBox
    Friend WithEvents tlpButtons As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents lblResult As System.Windows.Forms.Label
    Friend WithEvents lvTruthTable As System.Windows.Forms.ListView
    Friend WithEvents colA As System.Windows.Forms.ColumnHeader
    Friend WithEvents colB As System.Windows.Forms.ColumnHeader
    Friend WithEvents colResult As System.Windows.Forms.ColumnHeader
    Friend WithEvents statusMain As System.Windows.Forms.StatusStrip
    Friend WithEvents tssMessage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tipMain As System.Windows.Forms.ToolTip

End Class
