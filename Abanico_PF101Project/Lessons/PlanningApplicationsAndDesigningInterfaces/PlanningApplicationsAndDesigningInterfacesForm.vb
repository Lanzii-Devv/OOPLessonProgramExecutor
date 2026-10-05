Public Class PlanningApplicationsAndDesigningInterfacesForm
    Private Sub btnExecution_Click(sender As Object, e As EventArgs) Handles btnExecution.Click

        lblResult.Text = "Student Information" & vbCrLf &
                     "Name: " & txtName.Text & vbCrLf &
                     "Course: " & txtCourse.Text

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class