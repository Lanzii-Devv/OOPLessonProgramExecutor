Public Class PolymorphismForm
    Private Sub PolymorphismForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cmbAnimal.Items.Add("Dog")
        cmbAnimal.Items.Add("Cat")

        cmbAnimal.SelectedIndex = 0

    End Sub

    Private Sub btnExecution_Click(sender As Object, e As EventArgs) Handles btnExecution.Click

        Dim animal As Animal

        If cmbAnimal.SelectedItem.ToString() = "Dog" Then
            animal = New Dog()
        Else
            animal = New Cat()
        End If

        lblResult.Text = animal.Speak()

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class