<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TextPropertiesManipulator
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TextPropertiesManipulator))
        SplitContainer1 = New SplitContainer()
        rtbCode = New RichTextBox()
        rtbExplanation = New RichTextBox()
        lblSampleCodeTite = New Label()
        explanation = New Label()
        lblTitle = New Label()
        lblFontColor = New Label()
        btnFontColor = New Button()
        lblFont = New Label()
        cmbFont = New ComboBox()
        lblFontSize = New Label()
        nudFontSize = New NumericUpDown()
        lblPreview = New Label()
        ColorDialog1 = New ColorDialog()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        CType(nudFontSize, ComponentModel.ISupportInitialize).BeginInit()
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
        SplitContainer1.Panel1.Controls.Add(rtbExplanation)
        SplitContainer1.Panel1.Controls.Add(lblSampleCodeTite)
        SplitContainer1.Panel1.Controls.Add(explanation)
        SplitContainer1.Panel1.Controls.Add(lblTitle)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(lblFontColor)
        SplitContainer1.Panel2.Controls.Add(btnFontColor)
        SplitContainer1.Panel2.Controls.Add(lblFont)
        SplitContainer1.Panel2.Controls.Add(cmbFont)
        SplitContainer1.Panel2.Controls.Add(lblFontSize)
        SplitContainer1.Panel2.Controls.Add(nudFontSize)
        SplitContainer1.Panel2.Controls.Add(lblPreview)
        SplitContainer1.Size = New Size(800, 450)
        SplitContainer1.SplitterDistance = 378
        SplitContainer1.TabIndex = 0
        ' 
        ' rtbCode
        ' 
        rtbCode.Location = New Point(12, 268)
        rtbCode.Name = "rtbCode"
        rtbCode.ReadOnly = True
        rtbCode.Size = New Size(340, 166)
        rtbCode.TabIndex = 4
        rtbCode.Text = "lblPreview.Font = New Font(""Arial"", 24)" & vbLf & vbLf & "lblPreview.ForeColor = Color.Blue" & vbLf & vbLf & "lblPreview.Text = ""Preview Text"""
        ' 
        ' rtbExplanation
        ' 
        rtbExplanation.Location = New Point(12, 71)
        rtbExplanation.Name = "rtbExplanation"
        rtbExplanation.ReadOnly = True
        rtbExplanation.Size = New Size(340, 166)
        rtbExplanation.TabIndex = 3
        rtbExplanation.Text = resources.GetString("rtbExplanation.Text")
        ' 
        ' lblSampleCodeTite
        ' 
        lblSampleCodeTite.AutoSize = True
        lblSampleCodeTite.Location = New Point(12, 250)
        lblSampleCodeTite.Name = "lblSampleCodeTite"
        lblSampleCodeTite.Size = New Size(77, 15)
        lblSampleCodeTite.TabIndex = 2
        lblSampleCodeTite.Text = "Sample Code"
        ' 
        ' explanation
        ' 
        explanation.AutoSize = True
        explanation.Location = New Point(12, 53)
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
        lblTitle.Size = New Size(205, 15)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Working with Controls and Properties"
        ' 
        ' lblFontColor
        ' 
        lblFontColor.AutoSize = True
        lblFontColor.Location = New Point(10, 284)
        lblFontColor.Name = "lblFontColor"
        lblFontColor.Size = New Size(66, 15)
        lblFontColor.TabIndex = 6
        lblFontColor.Text = "Font Color:"
        ' 
        ' btnFontColor
        ' 
        btnFontColor.AutoSize = True
        btnFontColor.Location = New Point(81, 279)
        btnFontColor.Name = "btnFontColor"
        btnFontColor.Size = New Size(116, 25)
        btnFontColor.TabIndex = 5
        btnFontColor.Text = "Choose Font Color"
        btnFontColor.UseVisualStyleBackColor = True
        ' 
        ' lblFont
        ' 
        lblFont.AutoSize = True
        lblFont.Location = New Point(42, 235)
        lblFont.Name = "lblFont"
        lblFont.Size = New Size(34, 15)
        lblFont.TabIndex = 4
        lblFont.Text = "Font:"
        ' 
        ' cmbFont
        ' 
        cmbFont.DropDownStyle = ComboBoxStyle.DropDownList
        cmbFont.FormattingEnabled = True
        cmbFont.Location = New Point(81, 232)
        cmbFont.Name = "cmbFont"
        cmbFont.Size = New Size(121, 23)
        cmbFont.TabIndex = 3
        ' 
        ' lblFontSize
        ' 
        lblFontSize.AutoSize = True
        lblFontSize.Location = New Point(19, 185)
        lblFontSize.Name = "lblFontSize"
        lblFontSize.Size = New Size(57, 15)
        lblFontSize.TabIndex = 2
        lblFontSize.Text = "Font Size:"
        ' 
        ' nudFontSize
        ' 
        nudFontSize.Location = New Point(82, 183)
        nudFontSize.Maximum = New Decimal(New Integer() {72, 0, 0, 0})
        nudFontSize.Minimum = New Decimal(New Integer() {8, 0, 0, 0})
        nudFontSize.Name = "nudFontSize"
        nudFontSize.Size = New Size(120, 23)
        nudFontSize.TabIndex = 1
        nudFontSize.Value = New Decimal(New Integer() {24, 0, 0, 0})
        ' 
        ' lblPreview
        ' 
        lblPreview.AutoSize = True
        lblPreview.Font = New Font("Arial Narrow", 24F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPreview.ForeColor = SystemColors.MenuHighlight
        lblPreview.Location = New Point(118, 53)
        lblPreview.Name = "lblPreview"
        lblPreview.Size = New Size(170, 37)
        lblPreview.TabIndex = 0
        lblPreview.Text = "Preview Text"
        ' 
        ' TextPropertiesManipulator
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(SplitContainer1)
        Name = "TextPropertiesManipulator"
        Text = "TextPropertiesManipulator"
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel1.PerformLayout()
        SplitContainer1.Panel2.ResumeLayout(False)
        SplitContainer1.Panel2.PerformLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        CType(nudFontSize, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents rtbExplanation As RichTextBox
    Friend WithEvents lblSampleCodeTite As Label
    Friend WithEvents explanation As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents rtbCode As RichTextBox
    Friend WithEvents nudFontSize As NumericUpDown
    Friend WithEvents lblPreview As Label
    Friend WithEvents lblFontSize As Label
    Friend WithEvents cmbFont As ComboBox
    Friend WithEvents lblFont As Label
    Friend WithEvents lblFontColor As Label
    Friend WithEvents btnFontColor As Button
    Friend WithEvents ColorDialog1 As ColorDialog
End Class
