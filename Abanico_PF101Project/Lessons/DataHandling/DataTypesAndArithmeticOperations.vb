Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar

Public Class DataTypesAndArithmeticOperations

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click

        If String.IsNullOrWhiteSpace(txtFirstNumber.Text) OrElse
            String.IsNullOrWhiteSpace(txtSecondNumber.Text) Then

            MessageBox.Show("Please enter both numbers.",
                            "Missing Input",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)

            Exit Sub
        End If

        Dim firstNumber As Double
        Dim secondNumber As Double
        Dim validInput As Boolean = False

        Select Case True

            Case rbInteger.Checked

                Dim num1 As Integer
                Dim num2 As Integer

                validInput = Integer.TryParse(txtFirstNumber.Text, num1) AndAlso
                     Integer.TryParse(txtSecondNumber.Text, num2)

                If validInput Then
                    firstNumber = num1
                    secondNumber = num2
                End If

            Case rbDouble.Checked

                validInput = Double.TryParse(txtFirstNumber.Text, firstNumber) AndAlso
                     Double.TryParse(txtSecondNumber.Text, secondNumber)

            Case rbSingle.Checked

                Dim num1 As Single
                Dim num2 As Single

                validInput = Single.TryParse(txtFirstNumber.Text, num1) AndAlso
                     Single.TryParse(txtSecondNumber.Text, num2)

                If validInput Then
                    firstNumber = num1
                    secondNumber = num2
                End If

            Case rbDecimal.Checked

                Dim num1 As Decimal
                Dim num2 As Decimal

                validInput = Decimal.TryParse(txtFirstNumber.Text, num1) AndAlso
                     Decimal.TryParse(txtSecondNumber.Text, num2)

                If validInput Then
                    firstNumber = CDbl(num1)
                    secondNumber = CDbl(num2)
                End If

        End Select

        If Not validInput Then
            MessageBox.Show("Please enter valid numbers for the selected data type.",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)

            Exit Sub
        End If

        Dim result As Double

        Select Case True

            Case rbAdd.Checked
                result = firstNumber + secondNumber

            Case rbSubtract.Checked
                result = firstNumber - secondNumber

            Case rbMultiply.Checked
                result = firstNumber * secondNumber

            Case rbDivide.Checked

                If secondNumber = 0 Then
                    MessageBox.Show("Cannot divide by zero.",
                        "Math Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)

                    Exit Sub
                End If

                If rbInteger.Checked Then
                    result = firstNumber \ secondNumber
                Else
                    result = firstNumber / secondNumber
                End If

        End Select

        lblResult.Text = result.ToString()

    End Sub

End Class