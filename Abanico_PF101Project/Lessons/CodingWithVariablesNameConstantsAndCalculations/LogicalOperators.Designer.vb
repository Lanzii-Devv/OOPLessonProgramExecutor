<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LogicalOperators
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LogicalOperators))
        SplitContainer1 = New SplitContainer()
        rtbCode = New RichTextBox()
        lblCode = New Label()
        rtbExplanation = New RichTextBox()
        explanation = New Label()
        lblTitle = New Label()
        dgvTruthTable = New DataGridView()
        grpOperator = New GroupBox()
        rbXor = New RadioButton()
        rbNot = New RadioButton()
        rbOr = New RadioButton()
        rbAnd = New RadioButton()
        lblTruthTableTitle = New Label()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        CType(dgvTruthTable, ComponentModel.ISupportInitialize).BeginInit()
        grpOperator.SuspendLayout()
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
        SplitContainer1.Panel1.Controls.Add(lblCode)
        SplitContainer1.Panel1.Controls.Add(rtbExplanation)
        SplitContainer1.Panel1.Controls.Add(explanation)
        SplitContainer1.Panel1.Controls.Add(lblTitle)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(dgvTruthTable)
        SplitContainer1.Panel2.Controls.Add(grpOperator)
        SplitContainer1.Panel2.Controls.Add(lblTruthTableTitle)
        SplitContainer1.Size = New Size(800, 450)
        SplitContainer1.SplitterDistance = 378
        SplitContainer1.TabIndex = 0
        ' 
        ' rtbCode
        ' 
        rtbCode.Location = New Point(12, 254)
        rtbCode.Name = "rtbCode"
        rtbCode.ReadOnly = True
        rtbCode.Size = New Size(353, 184)
        rtbCode.TabIndex = 4
        rtbCode.Text = resources.GetString("rtbCode.Text")
        ' 
        ' lblCode
        ' 
        lblCode.AutoSize = True
        lblCode.Location = New Point(12, 236)
        lblCode.Name = "lblCode"
        lblCode.Size = New Size(77, 15)
        lblCode.TabIndex = 3
        lblCode.Text = "Sample Code"
        ' 
        ' rtbExplanation
        ' 
        rtbExplanation.Location = New Point(12, 78)
        rtbExplanation.Name = "rtbExplanation"
        rtbExplanation.ReadOnly = True
        rtbExplanation.Size = New Size(353, 139)
        rtbExplanation.TabIndex = 2
        rtbExplanation.Text = resources.GetString("rtbExplanation.Text")
        ' 
        ' explanation
        ' 
        explanation.AutoSize = True
        explanation.Location = New Point(12, 60)
        explanation.Name = "explanation"
        explanation.Size = New Size(68, 15)
        explanation.TabIndex = 1
        explanation.Text = "Explanation"
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(12, 9)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(100, 15)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Logical Operators"
        ' 
        ' dgvTruthTable
        ' 
        dgvTruthTable.AllowUserToAddRows = False
        dgvTruthTable.AllowUserToDeleteRows = False
        dgvTruthTable.AllowUserToResizeColumns = False
        dgvTruthTable.AllowUserToResizeRows = False
        dgvTruthTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvTruthTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvTruthTable.Location = New Point(14, 132)
        dgvTruthTable.MultiSelect = False
        dgvTruthTable.Name = "dgvTruthTable"
        dgvTruthTable.ReadOnly = True
        dgvTruthTable.RowHeadersVisible = False
        dgvTruthTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvTruthTable.Size = New Size(392, 306)
        dgvTruthTable.TabIndex = 2
        ' 
        ' grpOperator
        ' 
        grpOperator.Controls.Add(rbXor)
        grpOperator.Controls.Add(rbNot)
        grpOperator.Controls.Add(rbOr)
        grpOperator.Controls.Add(rbAnd)
        grpOperator.Location = New Point(14, 40)
        grpOperator.Name = "grpOperator"
        grpOperator.Size = New Size(392, 61)
        grpOperator.TabIndex = 1
        grpOperator.TabStop = False
        grpOperator.Text = "Select Logical Operator"
        ' 
        ' rbXor
        ' 
        rbXor.AutoSize = True
        rbXor.Location = New Point(338, 25)
        rbXor.Name = "rbXor"
        rbXor.Size = New Size(48, 19)
        rbXor.TabIndex = 3
        rbXor.Text = "XOR"
        rbXor.UseVisualStyleBackColor = True
        ' 
        ' rbNot
        ' 
        rbNot.AutoSize = True
        rbNot.Location = New Point(230, 26)
        rbNot.Name = "rbNot"
        rbNot.Size = New Size(49, 19)
        rbNot.TabIndex = 2
        rbNot.Text = "NOT"
        rbNot.UseVisualStyleBackColor = True
        ' 
        ' rbOr
        ' 
        rbOr.AutoSize = True
        rbOr.Location = New Point(131, 25)
        rbOr.Name = "rbOr"
        rbOr.Size = New Size(41, 19)
        rbOr.TabIndex = 1
        rbOr.Text = "OR"
        rbOr.UseVisualStyleBackColor = True
        ' 
        ' rbAnd
        ' 
        rbAnd.AutoSize = True
        rbAnd.Checked = True
        rbAnd.Location = New Point(18, 25)
        rbAnd.Name = "rbAnd"
        rbAnd.Size = New Size(50, 19)
        rbAnd.TabIndex = 0
        rbAnd.TabStop = True
        rbAnd.Text = "AND"
        rbAnd.UseVisualStyleBackColor = True
        ' 
        ' lblTruthTableTitle
        ' 
        lblTruthTableTitle.AutoSize = True
        lblTruthTableTitle.Location = New Point(3, 9)
        lblTruthTableTitle.Name = "lblTruthTableTitle"
        lblTruthTableTitle.Size = New Size(162, 15)
        lblTruthTableTitle.TabIndex = 0
        lblTruthTableTitle.Text = "Logical Operators Truth Table"
        ' 
        ' LogicalOperators
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(SplitContainer1)
        Name = "LogicalOperators"
        Text = "LogicalOperators"
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel1.PerformLayout()
        SplitContainer1.Panel2.ResumeLayout(False)
        SplitContainer1.Panel2.PerformLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        CType(dgvTruthTable, ComponentModel.ISupportInitialize).EndInit()
        grpOperator.ResumeLayout(False)
        grpOperator.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents rtbCode As RichTextBox
    Friend WithEvents lblCode As Label
    Friend WithEvents rtbExplanation As RichTextBox
    Friend WithEvents explanation As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents grpOperator As GroupBox
    Friend WithEvents rbXor As RadioButton
    Friend WithEvents rbNot As RadioButton
    Friend WithEvents rbOr As RadioButton
    Friend WithEvents rbAnd As RadioButton
    Friend WithEvents lblTruthTableTitle As Label
    Friend WithEvents dgvTruthTable As DataGridView
End Class
