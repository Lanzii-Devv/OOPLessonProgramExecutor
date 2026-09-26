Public Class Form1

    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub ClassesAndObjectsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClassesAndObjectsToolStripMenuItem.Click

        Dim lesson As New ClassesAndObjectsForm()
        lesson.Show()

    End Sub

    Private Sub EncapsulationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EncapsulationToolStripMenuItem.Click

        Dim lesson As New EncapsulationForm()
        lesson.Show()

    End Sub

    Private Sub InheritanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InheritanceToolStripMenuItem.Click

        Dim lesson As New InheritanceForm()
        lesson.Show()

    End Sub

    Private Sub PolymorphismToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PolymorphismToolStripMenuItem.Click

        Dim lesson As New PolymorphismForm()
        lesson.Show()

    End Sub

    Private Sub GettingStartedWithMicrosoftVisualBasicNETToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GettingStartedWithMicrosoftVisualBasicNETToolStripMenuItem.Click

        Dim lesson As New GettingStartedWithVBNetForm()
        lesson.Show()

    End Sub

    Private Sub PlanningApplicationsAndDesigningInterfacesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlanningApplicationsAndDesigningInterfacesToolStripMenuItem.Click

        Dim lesson As New PlanningApplicationsAndDesigningInterfacesForm()
        lesson.Show()

    End Sub

    Private Sub PrimaryExampleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrimaryExampleToolStripMenuItem.Click

        Dim lesson As New DataHandlingForm()
        lesson.Show()

    End Sub

    Private Sub DifferentDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DifferentDataToolStripMenuItem.Click

        Dim lesson As New DataTypesAndArithmeticOperations()
        lesson.Show()

    End Sub

    Private Sub CodingWithVariablesNameConstantsAndCalculationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CodingWithVariablesNameConstantsAndCalculationsToolStripMenuItem.Click

        Dim lesson As New CodingWithVariablesNameConstantsAndCalculationsForm()
        lesson.Show()

    End Sub

    Private Sub ArraysToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArraysToolStripMenuItem.Click

        Dim Lesson As New ArraysForm()
        Lesson.Show()

    End Sub

    Private Sub WorkingWithControlsAndPropertiesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WorkingWithControlsAndPropertiesToolStripMenuItem.Click

        Dim Lesson As New WorkingWithControlsAndPropertiesForm()
        Lesson.Show()

    End Sub

    Private Sub DebuggingAndTracingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DebuggingAndTracingToolStripMenuItem.Click

        Dim Lesson As New DebuggingAndTracingForm()
        Lesson.Show()

    End Sub

End Class
