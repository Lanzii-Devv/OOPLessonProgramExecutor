Public Class MonthsListbox

    Private Sub MonthsListbox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateMonths()
    End Sub

    Private Sub chkShowIndex_CheckedChanged(
        sender As Object, e As EventArgs
    ) Handles chkShowIndex.CheckedChanged

        PopulateMonths()

    End Sub

    Private Sub PopulateMonths()

        Dim months As String() = {
            "January", "February", "March",
            "April", "May", "June",
            "July", "August", "September",
            "October", "November", "December"
        }

        lstMonths.Items.Clear()

        For index As Integer = 0 To months.Length - 1

            If chkShowIndex.Checked Then
                lstMonths.Items.Add(
                    index & " - " & months(index)
                )
            Else
                lstMonths.Items.Add(months(index))
            End If

        Next

    End Sub

End Class