Public Class WorkingWithControlsAndPropertiesForm
    Private Sub btnExecution_Click(sender As Object, e As EventArgs) Handles btnExecution.Click

        lblResult.Text = txtInput.Text
        lblResult.Font = New Font("Arial", 16, FontStyle.Bold)

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class