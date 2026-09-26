Public Class ClassesAndObjectsForm

    Private Sub btnExecute_Click(sender As Object, e As EventArgs) Handles btnExecute.Click

        'Object creation
        Dim person1 As New Person()

        person1.Name = txtName.Text
        person1.Age = CInt(txtAge.Text)

        lblResult.Text = "Name: " & person1.Name & vbCrLf &
                 "Age: " & person1.Age

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class