<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DebuggingAndTracingForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DebuggingAndTracingForm))
        SplitContainer1 = New SplitContainer()
        rtbCode = New RichTextBox()
        explanation = New Label()
        lblTitle = New Label()
        txtNumber2 = New TextBox()
        txtNumber1 = New TextBox()
        btnClose = New Button()
        btnExecution = New Button()
        lblResult = New Label()
        lblNumber2 = New Label()
        lblNumber1 = New Label()
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
        SplitContainer1.Panel2.Controls.Add(txtNumber2)
        SplitContainer1.Panel2.Controls.Add(txtNumber1)
        SplitContainer1.Panel2.Controls.Add(btnClose)
        SplitContainer1.Panel2.Controls.Add(btnExecution)
        SplitContainer1.Panel2.Controls.Add(lblResult)
        SplitContainer1.Panel2.Controls.Add(lblNumber2)
        SplitContainer1.Panel2.Controls.Add(lblNumber1)
        SplitContainer1.Panel2.Controls.Add(lblExecutionTitle)
        SplitContainer1.Size = New Size(800, 450)
        SplitContainer1.SplitterDistance = 378
        SplitContainer1.TabIndex = 0
        ' 
        ' rtbCode
        ' 
        rtbCode.Location = New Point(12, 202)
        rtbCode.Name = "rtbCode"
        rtbCode.ReadOnly = True
        rtbCode.Size = New Size(250, 236)
        rtbCode.TabIndex = 2
        rtbCode.Text = resources.GetString("rtbCode.Text")
        ' 
        ' explanation
        ' 
        explanation.AutoSize = True
        explanation.Location = New Point(12, 46)
        explanation.Name = "explanation"
        explanation.Size = New Size(250, 135)
        explanation.TabIndex = 1
        explanation.Text = resources.GetString("explanation.Text")
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(12, 9)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(131, 15)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Debugging and Tracing"
        ' 
        ' txtNumber2
        ' 
        txtNumber2.Location = New Point(117, 110)
        txtNumber2.Name = "txtNumber2"
        txtNumber2.Size = New Size(150, 23)
        txtNumber2.TabIndex = 7
        ' 
        ' txtNumber1
        ' 
        txtNumber1.Location = New Point(117, 67)
        txtNumber1.Name = "txtNumber1"
        txtNumber1.Size = New Size(150, 23)
        txtNumber1.TabIndex = 6
        ' 
        ' btnClose
        ' 
        btnClose.Location = New Point(192, 158)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(75, 23)
        btnClose.TabIndex = 5
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' btnExecution
        ' 
        btnExecution.Location = New Point(48, 158)
        btnExecution.Name = "btnExecution"
        btnExecution.Size = New Size(75, 23)
        btnExecution.TabIndex = 4
        btnExecution.Text = "Execution"
        btnExecution.UseVisualStyleBackColor = True
        ' 
        ' lblResult
        ' 
        lblResult.AutoSize = True
        lblResult.Location = New Point(48, 205)
        lblResult.Name = "lblResult"
        lblResult.Size = New Size(125, 15)
        lblResult.TabIndex = 3
        lblResult.Text = "Result will appear here"
        ' 
        ' lblNumber2
        ' 
        lblNumber2.AutoSize = True
        lblNumber2.Location = New Point(48, 113)
        lblNumber2.Name = "lblNumber2"
        lblNumber2.Size = New Size(63, 15)
        lblNumber2.TabIndex = 2
        lblNumber2.Text = "Number 2:"
        ' 
        ' lblNumber1
        ' 
        lblNumber1.AutoSize = True
        lblNumber1.Location = New Point(48, 70)
        lblNumber1.Name = "lblNumber1"
        lblNumber1.Size = New Size(63, 15)
        lblNumber1.TabIndex = 1
        lblNumber1.Text = "Number 1:"
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
        ' DebuggingAndTracingForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(SplitContainer1)
        Name = "DebuggingAndTracingForm"
        Text = "DebuggingAndTracingForm"
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
    Friend WithEvents txtNumber2 As TextBox
    Friend WithEvents txtNumber1 As TextBox
    Friend WithEvents btnClose As Button
    Friend WithEvents btnExecution As Button
    Friend WithEvents lblResult As Label
    Friend WithEvents lblNumber2 As Label
    Friend WithEvents lblNumber1 As Label
    Friend WithEvents lblExecutionTitle As Label
End Class
