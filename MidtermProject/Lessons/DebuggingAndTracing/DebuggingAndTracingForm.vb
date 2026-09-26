Public Class DebuggingAndTracingForm
    Private Sub btnExecution_Click(sender As Object, e As EventArgs) Handles btnExecution.Click

        Dim number1 As Integer = CInt(txtNumber1.Text)
        Dim number2 As Integer = CInt(txtNumber2.Text)

        Dim result As Integer = number1 + number2

        lblResult.Text = "Number 1: " & number1 & vbCrLf &
                         "Number 2: " & number2 & vbCrLf &
                         "Result: " & result

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class