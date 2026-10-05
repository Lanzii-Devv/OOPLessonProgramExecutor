<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InheritanceForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InheritanceForm))
        SplitContainer1 = New SplitContainer()
        rtbCode = New RichTextBox()
        explanation = New Label()
        lblTitle = New Label()
        lblResult = New Label()
        btnClose = New Button()
        btnExecute = New Button()
        txtStudentID = New TextBox()
        lblStudentID = New Label()
        txtAge = New TextBox()
        txtName = New TextBox()
        lblAge = New Label()
        lblName = New Label()
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
        SplitContainer1.Panel2.Controls.Add(lblResult)
        SplitContainer1.Panel2.Controls.Add(btnClose)
        SplitContainer1.Panel2.Controls.Add(btnExecute)
        SplitContainer1.Panel2.Controls.Add(txtStudentID)
        SplitContainer1.Panel2.Controls.Add(lblStudentID)
        SplitContainer1.Panel2.Controls.Add(txtAge)
        SplitContainer1.Panel2.Controls.Add(txtName)
        SplitContainer1.Panel2.Controls.Add(lblAge)
        SplitContainer1.Panel2.Controls.Add(lblName)
        SplitContainer1.Panel2.Controls.Add(lblExecutionTitle)
        SplitContainer1.Size = New Size(800, 450)
        SplitContainer1.SplitterDistance = 378
        SplitContainer1.TabIndex = 0
        ' 
        ' rtbCode
        ' 
        rtbCode.Location = New Point(12, 192)
        rtbCode.Name = "rtbCode"
        rtbCode.ReadOnly = True
        rtbCode.Size = New Size(241, 246)
        rtbCode.TabIndex = 2
        rtbCode.Text = resources.GetString("rtbCode.Text")
        ' 
        ' explanation
        ' 
        explanation.AutoSize = True
        explanation.Location = New Point(12, 40)
        explanation.Name = "explanation"
        explanation.Size = New Size(241, 135)
        explanation.TabIndex = 1
        explanation.Text = resources.GetString("explanation.Text")
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(12, 9)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(66, 15)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Inheritance"
        ' 
        ' lblResult
        ' 
        lblResult.AutoSize = True
        lblResult.Location = New Point(14, 205)
        lblResult.Name = "lblResult"
        lblResult.Size = New Size(125, 15)
        lblResult.TabIndex = 9
        lblResult.Text = "Result will appear here"
        ' 
        ' btnClose
        ' 
        btnClose.Location = New Point(167, 148)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(75, 23)
        btnClose.TabIndex = 8
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' btnExecute
        ' 
        btnExecute.Location = New Point(14, 152)
        btnExecute.Name = "btnExecute"
        btnExecute.Size = New Size(75, 23)
        btnExecute.TabIndex = 7
        btnExecute.Text = "Execute"
        btnExecute.UseVisualStyleBackColor = True
        ' 
        ' txtStudentID
        ' 
        txtStudentID.Location = New Point(92, 95)
        txtStudentID.Name = "txtStudentID"
        txtStudentID.Size = New Size(150, 23)
        txtStudentID.TabIndex = 6
        ' 
        ' lblStudentID
        ' 
        lblStudentID.AutoSize = True
        lblStudentID.Location = New Point(14, 100)
        lblStudentID.Name = "lblStudentID"
        lblStudentID.Size = New Size(65, 15)
        lblStudentID.TabIndex = 5
        lblStudentID.Text = "Student ID:"
        ' 
        ' txtAge
        ' 
        txtAge.Location = New Point(92, 66)
        txtAge.Name = "txtAge"
        txtAge.Size = New Size(150, 23)
        txtAge.TabIndex = 4
        ' 
        ' txtName
        ' 
        txtName.Location = New Point(92, 40)
        txtName.Name = "txtName"
        txtName.Size = New Size(150, 23)
        txtName.TabIndex = 3
        ' 
        ' lblAge
        ' 
        lblAge.AutoSize = True
        lblAge.Location = New Point(48, 69)
        lblAge.Name = "lblAge"
        lblAge.Size = New Size(31, 15)
        lblAge.TabIndex = 2
        lblAge.Text = "Age:"
        ' 
        ' lblName
        ' 
        lblName.AutoSize = True
        lblName.Location = New Point(37, 40)
        lblName.Name = "lblName"
        lblName.Size = New Size(42, 15)
        lblName.TabIndex = 1
        lblName.Text = "Name:"
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
        ' InheritanceForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(SplitContainer1)
        Name = "InheritanceForm"
        Text = "InheritanceForm"
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
    Friend WithEvents lblExecutionTitle As Label
    Friend WithEvents lblResult As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents btnExecute As Button
    Friend WithEvents txtStudentID As TextBox
    Friend WithEvents lblStudentID As Label
    Friend WithEvents txtAge As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents lblAge As Label
    Friend WithEvents lblName As Label
End Class
