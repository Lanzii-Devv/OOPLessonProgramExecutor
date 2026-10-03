Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Public Class TextPropertiesManipulator

    Private Sub TextPropertiesManipulator_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cmbFont.Items.Add("Arial")
        cmbFont.Items.Add("Calibri")
        cmbFont.Items.Add("Consolas")
        cmbFont.Items.Add("Courier New")
        cmbFont.Items.Add("Times New Roman")

        cmbFont.SelectedItem = "Arial"

    End Sub

    Private Sub nudFontSize_ValueChanged(sender As Object, e As EventArgs) Handles nudFontSize.ValueChanged

        lblPreview.Font = New Font(
        lblPreview.Font.FontFamily,
        CSng(nudFontSize.Value)
    )

    End Sub

    Private Sub cmbFont_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFont.SelectedIndexChanged

        lblPreview.Font = New Font(
            cmbFont.SelectedItem.ToString(),
            lblPreview.Font.Size
        )

    End Sub

    Private Sub btnFontColor_Click(sender As Object, e As EventArgs) Handles btnFontColor.Click

        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            lblPreview.ForeColor = ColorDialog1.Color
        End If

    End Sub
End Class