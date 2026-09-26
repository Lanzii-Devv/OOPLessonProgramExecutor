<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MonthsListbox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MonthsListbox))
        SplitContainer1 = New SplitContainer()
        rtbCode = New RichTextBox()
        lblCode = New Label()
        rtbExplanation = New RichTextBox()
        explanation = New Label()
        lblTitle = New Label()
        chkShowIndex = New CheckBox()
        lstMonths = New ListBox()
        lblMonthsTitle = New Label()
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
        SplitContainer1.Panel1.Controls.Add(lblCode)
        SplitContainer1.Panel1.Controls.Add(rtbExplanation)
        SplitContainer1.Panel1.Controls.Add(explanation)
        SplitContainer1.Panel1.Controls.Add(lblTitle)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(chkShowIndex)
        SplitContainer1.Panel2.Controls.Add(lstMonths)
        SplitContainer1.Panel2.Controls.Add(lblMonthsTitle)
        SplitContainer1.Size = New Size(800, 450)
        SplitContainer1.SplitterDistance = 378
        SplitContainer1.TabIndex = 0
        ' 
        ' rtbCode
        ' 
        rtbCode.Location = New Point(12, 243)
        rtbCode.Name = "rtbCode"
        rtbCode.ReadOnly = True
        rtbCode.Size = New Size(348, 144)
        rtbCode.TabIndex = 4
        rtbCode.Text = resources.GetString("rtbCode.Text")
        ' 
        ' lblCode
        ' 
        lblCode.AutoSize = True
        lblCode.Location = New Point(12, 225)
        lblCode.Name = "lblCode"
        lblCode.Size = New Size(77, 15)
        lblCode.TabIndex = 3
        lblCode.Text = "Sample Code"
        ' 
        ' rtbExplanation
        ' 
        rtbExplanation.Location = New Point(12, 61)
        rtbExplanation.Name = "rtbExplanation"
        rtbExplanation.ReadOnly = True
        rtbExplanation.Size = New Size(348, 144)
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
        lblTitle.Size = New Size(76, 15)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Array Format"
        ' 
        ' chkShowIndex
        ' 
        chkShowIndex.AutoSize = True
        chkShowIndex.Location = New Point(18, 318)
        chkShowIndex.Name = "chkShowIndex"
        chkShowIndex.Size = New Size(117, 19)
        chkShowIndex.TabIndex = 3
        chkShowIndex.Text = "Show Array Index"
        chkShowIndex.UseVisualStyleBackColor = True
        ' 
        ' lstMonths
        ' 
        lstMonths.FormattingEnabled = True
        lstMonths.Location = New Point(18, 43)
        lstMonths.Name = "lstMonths"
        lstMonths.Size = New Size(374, 259)
        lstMonths.TabIndex = 2
        ' 
        ' lblMonthsTitle
        ' 
        lblMonthsTitle.AutoSize = True
        lblMonthsTitle.Location = New Point(3, 9)
        lblMonthsTitle.Name = "lblMonthsTitle"
        lblMonthsTitle.Size = New Size(107, 15)
        lblMonthsTitle.TabIndex = 1
        lblMonthsTitle.Text = "Months of the Year"
        ' 
        ' MonthsListbox
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(SplitContainer1)
        Name = "MonthsListbox"
        Text = "MonthsListbox"
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
    Friend WithEvents rtbExplanation As RichTextBox
    Friend WithEvents rtbCode As RichTextBox
    Friend WithEvents lblCode As Label
    Friend WithEvents lblMonthsTitle As Label
    Friend WithEvents chkShowIndex As CheckBox
    Friend WithEvents lstMonths As ListBox
End Class
