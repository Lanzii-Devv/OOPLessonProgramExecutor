Public Class DataHandlingForm
    Private Sub btnExecution_Click(sender As Object, e As EventArgs) Handles btnExecution.Click

        Dim name As String = txtName.Text
        Dim age As Integer = CInt(txtAge.Text)

        lblResult.Text = "Name: " & name & vbCrLf &
                         "Age: " & age

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class