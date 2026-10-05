<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClassesAndObjectsForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClassesAndObjectsForm))
        SplitContainer1 = New SplitContainer()
        rtbCode = New RichTextBox()
        explanation = New Label()
        lblTitle = New Label()
        lblResult = New Label()
        btnClose = New Button()
        btnExecute = New Button()
        txtAge = New TextBox()
        lblAge = New Label()
        txtName = New TextBox()
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
        SplitContainer1.Panel2.Controls.Add(lblExecutionTitle)
        SplitContainer1.Panel2.Controls.Add(lblResult)
        SplitContainer1.Panel2.Controls.Add(btnClose)
        SplitContainer1.Panel2.Controls.Add(btnExecute)
        SplitContainer1.Panel2.Controls.Add(txtAge)
        SplitContainer1.Panel2.Controls.Add(lblAge)
        SplitContainer1.Panel2.Controls.Add(txtName)
        SplitContainer1.Panel2.Controls.Add(lblName)
        SplitContainer1.Panel2.Tag = ""
        SplitContainer1.Size = New Size(899, 611)
        SplitContainer1.SplitterDistance = 378
        SplitContainer1.TabIndex = 0
        ' 
        ' rtbCode
        ' 
        rtbCode.Location = New Point(12, 213)
        rtbCode.Name = "rtbCode"
        rtbCode.ReadOnly = True
        rtbCode.Size = New Size(253, 259)
        rtbCode.TabIndex = 2
        rtbCode.Tag = ""
        rtbCode.Text = "Public Class Person" & vbLf & vbLf & "    Public Name As String" & vbLf & "    Public Age As Integer" & vbLf & vbLf & "End Class" & vbLf & vbLf & vbLf & "' Creating an object" & vbLf & vbLf & "Dim person1 As New Person()" & vbLf & vbLf & "person1.Name = txtName.Text" & vbLf & "person1.Age = CInt(txtAge.Text)"
        ' 
        ' explanation
        ' 
        explanation.Location = New Point(12, 37)
        explanation.Name = "explanation"
        explanation.Size = New Size(239, 173)
        explanation.TabIndex = 1
        explanation.Text = resources.GetString("explanation.Text")
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(12, 9)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(111, 15)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Classes and Objects"
        ' 
        ' lblResult
        ' 
        lblResult.AutoSize = True
        lblResult.Location = New Point(53, 258)
        lblResult.Name = "lblResult"
        lblResult.Size = New Size(125, 15)
        lblResult.TabIndex = 6
        lblResult.Text = "Result will appear here"
        ' 
        ' btnClose
        ' 
        btnClose.Location = New Point(176, 166)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(75, 23)
        btnClose.TabIndex = 5
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' btnExecute
        ' 
        btnExecute.Location = New Point(53, 166)
        btnExecute.Name = "btnExecute"
        btnExecute.Size = New Size(75, 23)
        btnExecute.TabIndex = 4
        btnExecute.Text = "Execute"
        btnExecute.UseVisualStyleBackColor = True
        ' 
        ' txtAge
        ' 
        txtAge.Location = New Point(101, 107)
        txtAge.Name = "txtAge"
        txtAge.Size = New Size(150, 23)
        txtAge.TabIndex = 3
        ' 
        ' lblAge
        ' 
        lblAge.AutoSize = True
        lblAge.Location = New Point(64, 110)
        lblAge.Name = "lblAge"
        lblAge.Size = New Size(31, 15)
        lblAge.TabIndex = 2
        lblAge.Text = "Age:"
        ' 
        ' txtName
        ' 
        txtName.Location = New Point(101, 72)
        txtName.Name = "txtName"
        txtName.Size = New Size(150, 23)
        txtName.TabIndex = 1
        ' 
        ' lblName
        ' 
        lblName.AutoSize = True
        lblName.Location = New Point(53, 75)
        lblName.Name = "lblName"
        lblName.Size = New Size(42, 15)
        lblName.TabIndex = 0
        lblName.Text = "Name:"
        ' 
        ' lblExecutionTitle
        ' 
        lblExecutionTitle.AutoSize = True
        lblExecutionTitle.Location = New Point(3, 9)
        lblExecutionTitle.Name = "lblExecutionTitle"
        lblExecutionTitle.Size = New Size(94, 15)
        lblExecutionTitle.TabIndex = 7
        lblExecutionTitle.Text = "Execute Example"
        ' 
        ' ClassesAndObjectsForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(899, 611)
        Controls.Add(SplitContainer1)
        Name = "ClassesAndObjectsForm"
        Text = "ClassesAndObjectsForm"
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel1.PerformLayout()
        SplitContainer1.Panel2.ResumeLayout(False)
        SplitContainer1.Panel2.PerformLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents explanation As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents rtbCode As RichTextBox
    Friend WithEvents lblName As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents btnExecute As Button
    Friend WithEvents txtAge As TextBox
    Friend WithEvents lblAge As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents lblResult As Label
    Friend WithEvents lblExecutionTitle As Label
End Class
