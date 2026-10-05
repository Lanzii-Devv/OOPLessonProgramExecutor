<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Orientation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Orientation))
        SplitContainer1 = New SplitContainer()
        rtbBaseline = New RichTextBox()
        rtbVisionMission = New RichTextBox()
        lblBaselineTitle = New Label()
        lblVisionTitle = New Label()
        lblTitle = New Label()
        rtbCoreValueDescription = New RichTextBox()
        cmbCoreValues = New ComboBox()
        lblBaselineInteractiveTitle = New Label()
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
        SplitContainer1.Panel1.Controls.Add(rtbBaseline)
        SplitContainer1.Panel1.Controls.Add(rtbVisionMission)
        SplitContainer1.Panel1.Controls.Add(lblBaselineTitle)
        SplitContainer1.Panel1.Controls.Add(lblVisionTitle)
        SplitContainer1.Panel1.Controls.Add(lblTitle)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(rtbCoreValueDescription)
        SplitContainer1.Panel2.Controls.Add(cmbCoreValues)
        SplitContainer1.Panel2.Controls.Add(lblBaselineInteractiveTitle)
        SplitContainer1.Size = New Size(800, 450)
        SplitContainer1.SplitterDistance = 378
        SplitContainer1.TabIndex = 0
        ' 
        ' rtbBaseline
        ' 
        rtbBaseline.Location = New Point(12, 256)
        rtbBaseline.Name = "rtbBaseline"
        rtbBaseline.ReadOnly = True
        rtbBaseline.Size = New Size(348, 159)
        rtbBaseline.TabIndex = 4
        rtbBaseline.Text = "SUBJECT BASELINE" & vbLf & vbLf & "The subject is guided by the following core values:" & vbLf & vbLf & "• Resiliency" & vbLf & "• Innovativeness" & vbLf & "• Stewardship" & vbLf & "• Equity"
        ' 
        ' rtbVisionMission
        ' 
        rtbVisionMission.Location = New Point(12, 65)
        rtbVisionMission.Name = "rtbVisionMission"
        rtbVisionMission.ReadOnly = True
        rtbVisionMission.Size = New Size(348, 159)
        rtbVisionMission.TabIndex = 3
        rtbVisionMission.Text = resources.GetString("rtbVisionMission.Text")
        ' 
        ' lblBaselineTitle
        ' 
        lblBaselineTitle.AutoSize = True
        lblBaselineTitle.Location = New Point(12, 238)
        lblBaselineTitle.Name = "lblBaselineTitle"
        lblBaselineTitle.Size = New Size(92, 15)
        lblBaselineTitle.TabIndex = 2
        lblBaselineTitle.Text = "Subject Baseline"
        ' 
        ' lblVisionTitle
        ' 
        lblVisionTitle.AutoSize = True
        lblVisionTitle.Location = New Point(12, 47)
        lblVisionTitle.Name = "lblVisionTitle"
        lblVisionTitle.Size = New Size(115, 15)
        lblVisionTitle.TabIndex = 1
        lblVisionTitle.Text = "Vission annd Misson"
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(12, 9)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(97, 15)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Class Orientation"
        ' 
        ' rtbCoreValueDescription
        ' 
        rtbCoreValueDescription.Location = New Point(24, 118)
        rtbCoreValueDescription.Name = "rtbCoreValueDescription"
        rtbCoreValueDescription.ReadOnly = True
        rtbCoreValueDescription.Size = New Size(382, 188)
        rtbCoreValueDescription.TabIndex = 2
        rtbCoreValueDescription.Text = ""
        ' 
        ' cmbCoreValues
        ' 
        cmbCoreValues.DropDownStyle = ComboBoxStyle.DropDownList
        cmbCoreValues.FormattingEnabled = True
        cmbCoreValues.Location = New Point(24, 78)
        cmbCoreValues.Name = "cmbCoreValues"
        cmbCoreValues.Size = New Size(121, 23)
        cmbCoreValues.TabIndex = 1
        ' 
        ' lblBaselineInteractiveTitle
        ' 
        lblBaselineInteractiveTitle.AutoSize = True
        lblBaselineInteractiveTitle.Location = New Point(24, 60)
        lblBaselineInteractiveTitle.Name = "lblBaselineInteractiveTitle"
        lblBaselineInteractiveTitle.Size = New Size(68, 15)
        lblBaselineInteractiveTitle.TabIndex = 0
        lblBaselineInteractiveTitle.Text = "Core Values"
        ' 
        ' Orientation
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(SplitContainer1)
        Name = "Orientation"
        Text = "Orientation"
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel1.PerformLayout()
        SplitContainer1.Panel2.ResumeLayout(False)
        SplitContainer1.Panel2.PerformLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents rtbBaseline As RichTextBox
    Friend WithEvents rtbVisionMission As RichTextBox
    Friend WithEvents lblBaselineTitle As Label
    Friend WithEvents lblVisionTitle As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents rtbCoreValueDescription As RichTextBox
    Friend WithEvents cmbCoreValues As ComboBox
    Friend WithEvents lblBaselineInteractiveTitle As Label
End Class
