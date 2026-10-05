Public Class LogicalOperators
    Private Sub LogicalOperators_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        rbAnd.Checked = True
        UpdateTruthTable("AND")

    End Sub

    Private Sub Operator_CheckedChanged(
    sender As Object, e As EventArgs
    ) Handles rbAnd.CheckedChanged,
              rbOr.CheckedChanged,
              rbNot.CheckedChanged,
              rbXor.CheckedChanged

        Dim selectedRadio As RadioButton =
        DirectCast(sender, RadioButton)

        If Not selectedRadio.Checked Then Return

        Select Case selectedRadio.Name
            Case "rbAnd"
                UpdateTruthTable("AND")

            Case "rbOr"
                UpdateTruthTable("OR")

            Case "rbNot"
                UpdateTruthTable("NOT")

            Case "rbXor"
                UpdateTruthTable("XOR")
        End Select

    End Sub

    Private Sub UpdateTruthTable(operatorName As String)

        dgvTruthTable.Columns.Clear()
        dgvTruthTable.Rows.Clear()

        dgvTruthTable.Columns.Add("A", "A")

        If operatorName <> "NOT" Then
            dgvTruthTable.Columns.Add("B", "B")
        End If

        dgvTruthTable.Columns.Add("Result", "Result")

        Dim values As Boolean() = {True, False}

        For Each a As Boolean In values

            If operatorName = "NOT" Then

                dgvTruthTable.Rows.Add(a, Not a)

            Else

                For Each b As Boolean In values

                    Dim result As Boolean = False

                    Select Case operatorName
                        Case "AND"
                            result = a And b

                        Case "OR"
                            result = a Or b

                        Case "XOR"
                            result = a Xor b
                    End Select

                    dgvTruthTable.Rows.Add(a, b, result)

                Next

            End If

        Next

    End Sub

End Class