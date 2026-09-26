Public Class EncapsulationForm

    Private Sub btnExecute_Click(sender As Object, e As EventArgs) Handles btnExecute.Click

        Dim person1 As New PersonEncapsulated()

        person1.Name = txtName.Text
        person1.Age = CInt(txtAge.Text)

        lblResult.Text = "Name: " & person1.Name & vbCrLf &
                         "Age: " & person1.Age

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class