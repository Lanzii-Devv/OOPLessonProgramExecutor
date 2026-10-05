Public Class InheritanceForm
    Private Sub btnExecute_Click(sender As Object, e As EventArgs) Handles btnExecute.Click

        Dim student1 As New Student()

        student1.Name = txtName.Text
        student1.Age = CInt(txtAge.Text)
        student1.StudentID = txtStudentID.Text

        lblResult.Text = "Name: " & student1.Name & vbCrLf &
                         "Age: " & student1.Age & vbCrLf &
                         "Student ID: " & student1.StudentID

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class