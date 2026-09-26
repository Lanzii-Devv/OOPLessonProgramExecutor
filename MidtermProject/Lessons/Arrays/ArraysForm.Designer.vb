<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ArraysForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArraysForm))
        SplitContainer1 = New SplitContainer()
        rtbCode = New RichTextBox()
        explanation = New Label()
        lblTitle = New Label()
        txtName3 = New TextBox()
        txtName2 = New TextBox()
        txtName1 = New TextBox()
        btnClose = New Button()
        btnExecution = New Button()
        lblResult = New Label()
        lblName3 = New Label()
        lblName2 = New Label()
        lblName1 = New Label()
        lblExecutionTitle = New Label()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
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
        SplitContainer1.Panel1.Controls.Add(explanation)
        SplitContainer1.Panel1.Controls.Add(lblTitle)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(txtName3)
        SplitContainer1.Panel2.Controls.Add(txtName2)
        SplitContainer1.Panel2.Controls.Add(txtName1)
        SplitContainer1.Panel2.Controls.Add(btnClose)
        SplitContainer1.Panel2.Controls.Add(btnExecution)
        SplitContainer1.Panel2.Controls.Add(lblResult)
        SplitContainer1.Panel2.Controls.Add(lblName3)
        SplitContainer1.Panel2.Controls.Add(lblName2)
        SplitContainer1.Panel2.Controls.Add(lblName1)
        SplitContainer1.Panel2.Controls.Add(lblExecutionTitle)
        SplitContainer1.Size = New Size(800, 450)
        SplitContainer1.SplitterDistance = 378
        SplitContainer1.TabIndex = 0
        ' 
        ' rtbCode
        ' 
        rtbCode.Location = New Point(12, 184)
        rtbCode.Name = "rtbCode"
        rtbCode.ReadOnly = True
        rtbCode.Size = New Size(226, 254)
        rtbCode.TabIndex = 2
        rtbCode.Text = resources.GetString("rtbCode.Text")
        ' 
        ' explanation
        ' 
        explanation.AutoSize = True
        explanation.Location = New Point(11, 43)
        explanation.Name = "explanation"
        explanation.Size = New Size(227, 120)
        explanation.TabIndex = 1
        explanation.Text = resources.GetString("explanation.Text")
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(12, 9)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(40, 15)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Arrays"
        ' 
        ' txtName3
        ' 
        txtName3.Location = New Point(119, 157)
        txtName3.Name = "txtName3"
        txtName3.Size = New Size(150, 23)
        txtName3.TabIndex = 9
        ' 
        ' txtName2
        ' 
        txtName2.Location = New Point(119, 112)
        txtName2.Name = "txtName2"
        txtName2.Size = New Size(150, 23)
        txtName2.TabIndex = 8
        ' 
        ' txtName1
        ' 
        txtName1.Location = New Point(119, 70)
        txtName1.Name = "txtName1"
        txtName1.Size = New Size(150, 23)
        txtName1.TabIndex = 7
        ' 
        ' btnClose
        ' 
        btnClose.Location = New Point(194, 206)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(75, 23)
        btnClose.TabIndex = 6
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' btnExecution
        ' 
        btnExecution.Location = New Point(53, 206)
        btnExecution.Name = "btnExecution"
        btnExecution.Size = New Size(75, 23)
        btnExecution.TabIndex = 5
        btnExecution.Text = "Execution"
        btnExecution.UseVisualStyleBackColor = True
        ' 
        ' lblResult
        ' 
        lblResult.AutoSize = True
        lblResult.Location = New Point(53, 261)
        lblResult.Name = "lblResult"
        lblResult.Size = New Size(125, 15)
        lblResult.TabIndex = 4
        lblResult.Text = "Result will appear here"
        ' 
        ' lblName3
        ' 
        lblName3.AutoSize = True
        lblName3.Location = New Point(53, 160)
        lblName3.Name = "lblName3"
        lblName3.Size = New Size(60, 15)
        lblName3.TabIndex = 3
        lblName3.Text = "Student 3:"
        ' 
        ' lblName2
        ' 
        lblName2.AutoSize = True
        lblName2.Location = New Point(53, 115)
        lblName2.Name = "lblName2"
        lblName2.Size = New Size(60, 15)
        lblName2.TabIndex = 2
        lblName2.Text = "Student 2:"
        ' 
        ' lblName1
        ' 
        lblName1.AutoSize = True
        lblName1.Location = New Point(53, 73)
        lblName1.Name = "lblName1"
        lblName1.Size = New Size(60, 15)
        lblName1.TabIndex = 1
        lblName1.Text = "Student 1:"
        ' 
        ' lblExecutionTitle
        ' 
        lblExecutionTitle.AutoSize = True
        lblExecutionTitle.Location = New Point(3, 9)
        lblExecutionTitle.Name = "lblExecutionTitle"
        lblExecutionTitle.Size = New Size(94, 15)
        lblExecutionTitle.TabIndex = 0
        lblExecutionTitle.Text = "Execute Example"
        ' 
        ' ArraysForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(SplitContainer1)
        Name = "ArraysForm"
        Text = "ArraysForm"
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel1.PerformLayout()
        SplitContainer1.Panel2.ResumeLayout(False)
        SplitContainer1.Panel2.PerformLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents rtbCode As RichTextBox
    Friend WithEvents explanation As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents txtName3 As TextBox
    Friend WithEvents txtName2 As TextBox
    Friend WithEvents txtName1 As TextBox
    Friend WithEvents btnClose As Button
    Friend WithEvents btnExecution As Button
    Friend WithEvents lblResult As Label
    Friend WithEvents lblName3 As Label
    Friend WithEvents lblName2 As Label
    Friend WithEvents lblName1 As Label
    Friend WithEvents lblExecutionTitle As Label
End Class
