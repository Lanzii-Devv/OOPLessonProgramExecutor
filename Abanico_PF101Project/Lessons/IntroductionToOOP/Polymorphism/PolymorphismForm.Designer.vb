<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PolymorphismForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PolymorphismForm))
        SplitContainer1 = New SplitContainer()
        rtbCode = New RichTextBox()
        lblTitle = New Label()
        explanation = New Label()
        lblResult = New Label()
        btnClose = New Button()
        btnExecution = New Button()
        cmbAnimal = New ComboBox()
        lblAnimal = New Label()
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
        SplitContainer1.Panel1.Controls.Add(lblTitle)
        SplitContainer1.Panel1.Controls.Add(explanation)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(lblResult)
        SplitContainer1.Panel2.Controls.Add(btnClose)
        SplitContainer1.Panel2.Controls.Add(btnExecution)
        SplitContainer1.Panel2.Controls.Add(cmbAnimal)
        SplitContainer1.Panel2.Controls.Add(lblAnimal)
        SplitContainer1.Panel2.Controls.Add(lblExecutionTitle)
        SplitContainer1.Size = New Size(800, 450)
        SplitContainer1.SplitterDistance = 378
        SplitContainer1.TabIndex = 0
        ' 
        ' rtbCode
        ' 
        rtbCode.Location = New Point(12, 198)
        rtbCode.Name = "rtbCode"
        rtbCode.ReadOnly = True
        rtbCode.Size = New Size(252, 240)
        rtbCode.TabIndex = 2
        rtbCode.Text = resources.GetString("rtbCode.Text")
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(12, 9)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(85, 15)
        lblTitle.TabIndex = 1
        lblTitle.Text = "Polymorphism"
        ' 
        ' explanation
        ' 
        explanation.AutoSize = True
        explanation.Location = New Point(12, 41)
        explanation.Name = "explanation"
        explanation.Size = New Size(252, 135)
        explanation.TabIndex = 0
        explanation.Text = resources.GetString("explanation.Text")
        ' 
        ' lblResult
        ' 
        lblResult.AutoSize = True
        lblResult.Location = New Point(32, 143)
        lblResult.Name = "lblResult"
        lblResult.Size = New Size(125, 15)
        lblResult.TabIndex = 5
        lblResult.Text = "Result will appear here"
        ' 
        ' btnClose
        ' 
        btnClose.Location = New Point(175, 87)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(75, 23)
        btnClose.TabIndex = 4
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' btnExecution
        ' 
        btnExecution.Location = New Point(32, 87)
        btnExecution.Name = "btnExecution"
        btnExecution.Size = New Size(75, 23)
        btnExecution.TabIndex = 3
        btnExecution.Text = "Execution"
        btnExecution.UseVisualStyleBackColor = True
        ' 
        ' cmbAnimal
        ' 
        cmbAnimal.FormattingEnabled = True
        cmbAnimal.Location = New Point(129, 41)
        cmbAnimal.Name = "cmbAnimal"
        cmbAnimal.Size = New Size(121, 23)
        cmbAnimal.TabIndex = 2
        ' 
        ' lblAnimal
        ' 
        lblAnimal.AutoSize = True
        lblAnimal.Location = New Point(32, 44)
        lblAnimal.Name = "lblAnimal"
        lblAnimal.Size = New Size(91, 15)
        lblAnimal.TabIndex = 1
        lblAnimal.Text = "Choose Animal:"
        ' 
        ' lblExecutionTitle
        ' 
        lblExecutionTitle.AutoSize = True
        lblExecutionTitle.Location = New Point(3, 9)
        lblExecutionTitle.Name = "lblExecutionTitle"
        lblExecutionTitle.Size = New Size(100, 15)
        lblExecutionTitle.TabIndex = 0
        lblExecutionTitle.Text = "Execution Sample"
        ' 
        ' PolymorphismForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(SplitContainer1)
        Name = "PolymorphismForm"
        Text = "PolymorphismForm"
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
    Friend WithEvents lblTitle As Label
    Friend WithEvents explanation As Label
    Friend WithEvents cmbAnimal As ComboBox
    Friend WithEvents lblAnimal As Label
    Friend WithEvents lblExecutionTitle As Label
    Friend WithEvents lblResult As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents btnExecution As Button
End Class
