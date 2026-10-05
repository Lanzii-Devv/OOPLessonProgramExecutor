
Public Class ExcessiveControls

    Private isReady As Boolean = False


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isReady = True
        UpdateOperatorState()
        BuildTruthTable()
        tssMessage.Text = "Choose an operator, set A and B, then press SUBMIT."
    End Sub

    Private Sub Operator_CheckedChanged(sender As Object, e As EventArgs) _
            Handles rdoAnd.CheckedChanged, rdoOr.CheckedChanged, rdoNot.CheckedChanged, rdoXor.CheckedChanged

        If Not isReady Then Return
        Dim chosen As RadioButton = CType(sender, RadioButton)
        If Not chosen.Checked Then Return

        UpdateOperatorState()
        ResetResult()
        BuildTruthTable()
        tssMessage.Text = "Operator selected: " & OperatorName()
    End Sub


    Private Sub Input_CheckedChanged(sender As Object, e As EventArgs) _
            Handles chkA.CheckedChanged, chkB.CheckedChanged

        chkA.Text = "A = " & chkA.Checked.ToString()
        chkB.Text = "B = " & chkB.Checked.ToString()
    End Sub

    ' EVENT 4: SUBMIT clicked -> evaluate and show the result
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim a As Boolean = chkA.Checked
        Dim b As Boolean = chkB.Checked
        Dim result As Boolean = Evaluate(a, b)

        Dim expression As String
        If rdoNot.Checked Then
            expression = "NOT " & a.ToString()
        Else
            expression = a.ToString() & " " & OperatorName() & " " & b.ToString()
        End If

        lblResult.Text = expression & "   =   " & result.ToString()
        If result Then
            lblResult.ForeColor = Color.DarkGreen
        Else
            lblResult.ForeColor = Color.Firebrick
        End If

        HighlightRow(a, b)
        tssMessage.Text = "Submitted: " & expression & " = " & result.ToString()
    End Sub

    ' EVENT 5: CLEAR clicked -> back to the starting state
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        rdoAnd.Checked = True          ' (if AND was not selected this also rebuilds the table)
        chkA.Checked = False
        chkB.Checked = False
        UpdateOperatorState()
        ResetResult()
        BuildTruthTable()              ' removes any highlighted row
        tssMessage.Text = "Cleared. Choose an operator to begin."
    End Sub

    ' EVENT 6: EXIT clicked -> close the form (FormClosing asks for confirmation)
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    ' EVENT 7: the form is closing (Exit button OR the window's X button)
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim answer As DialogResult = MessageBox.Show("Are you sure you want to exit?",
                                                     "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer = DialogResult.No Then
            e.Cancel = True            ' stay open
        End If
    End Sub

    ' =====================================================
    '  METHODS
    ' =====================================================

    ' NOT only uses A, so B is switched off for it
    Private Sub UpdateOperatorState()
        chkB.Enabled = Not rdoNot.Checked
        If rdoNot.Checked Then chkB.Checked = False
    End Sub

    Private Sub ResetResult()
        lblResult.Text = "Result will appear here"
        lblResult.ForeColor = Color.Gray
    End Sub

    Private Function OperatorName() As String
        If rdoAnd.Checked Then
            Return "AND"
        ElseIf rdoOr.Checked Then
            Return "OR"
        ElseIf rdoNot.Checked Then
            Return "NOT"
        Else
            Return "XOR"
        End If
    End Function

    ' The actual logical operators
    Private Function Evaluate(a As Boolean, b As Boolean) As Boolean
        If rdoAnd.Checked Then
            Return a And b
        ElseIf rdoOr.Checked Then
            Return a Or b
        ElseIf rdoNot.Checked Then
            Return Not a
        Else
            Return a Xor b
        End If
    End Function

    ' Fill the ListView with every possible combination for the chosen operator
    Private Sub BuildTruthTable()
        lvTruthTable.Items.Clear()

        If rdoNot.Checked Then
            For Each a As Boolean In {True, False}
                AddTruthRow(a, False)
            Next
        Else
            For Each a As Boolean In {True, False}
                For Each b As Boolean In {True, False}
                    AddTruthRow(a, b)
                Next
            Next
        End If
    End Sub

    Private Sub AddTruthRow(a As Boolean, b As Boolean)
        Dim result As Boolean = Evaluate(a, b)

        Dim row As New ListViewItem(a.ToString())
        If rdoNot.Checked Then
            row.SubItems.Add("-")               ' NOT has no B
        Else
            row.SubItems.Add(b.ToString())
        End If
        row.SubItems.Add(result.ToString())

        If result Then
            row.ForeColor = Color.DarkGreen
        Else
            row.ForeColor = Color.Firebrick
        End If

        lvTruthTable.Items.Add(row)
    End Sub

    ' Colour the row that matches the values you submitted
    Private Sub HighlightRow(a As Boolean, b As Boolean)
        For Each row As ListViewItem In lvTruthTable.Items
            row.BackColor = SystemColors.Window

            Dim sameA As Boolean = (row.Text = a.ToString())
            Dim sameB As Boolean = rdoNot.Checked OrElse (row.SubItems(1).Text = b.ToString())

            If sameA AndAlso sameB Then
                row.BackColor = Color.Khaki
                row.EnsureVisible()
            End If
        Next
    End Sub

End Class
