Public Class ArraysForm
    Private Sub btnExecution_Click(sender As Object, e As EventArgs) Handles btnExecution.Click

        Dim students() As String = {
        txtName1.Text,
        txtName2.Text,
        txtName3.Text
    }

        lblResult.Text = "Student List" & vbCrLf &
                         "1. " & students(0) & vbCrLf &
                         "2. " & students(1) & vbCrLf &
                         "3. " & students(2)

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class