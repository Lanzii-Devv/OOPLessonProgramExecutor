Public Class Orientation
    Private Sub Orientation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cmbCoreValues.Items.Add("Resiliency")
        cmbCoreValues.Items.Add("Innovativeness")
        cmbCoreValues.Items.Add("Stewardship")
        cmbCoreValues.Items.Add("Equity")

        cmbCoreValues.SelectedIndex = 0

    End Sub

    Private Sub cmbCoreValues_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCoreValues.SelectedIndexChanged

        Select Case cmbCoreValues.SelectedItem.ToString()

            Case "Resiliency"
                rtbCoreValueDescription.Text =
        "Resiliency means being able to recover when things don't go as planned. " &
        "As a student, this means learning from mistakes, handling challenges, " &
        "and continuing to work toward your goals."

            Case "Innovativeness"
                rtbCoreValueDescription.Text =
        "Innovativeness means being open to new ideas and finding better ways " &
        "to solve problems. As a student, this means being creative, trying " &
        "different approaches, and looking for ways to improve your work."

            Case "Stewardship"
                rtbCoreValueDescription.Text =
        "Stewardship means taking responsibility for what has been entrusted " &
        "to you. As a student, this means taking care of school resources, " &
        "using technology responsibly, and doing your part to help others."

            Case "Equity"
                rtbCoreValueDescription.Text =
        "Equity means treating people fairly and recognizing that people may " &
        "have different needs and circumstances. As a student, this means " &
        "respecting others and helping create a fair and inclusive environment."

        End Select

    End Sub
End Class