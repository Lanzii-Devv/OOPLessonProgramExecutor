' ============================================================
' Enemy.vb
' Very simple rule-based AI. It does NOT move anything itself;
' it only DECIDES what to do and returns an AttackPlan.
' The Form carries out the plan.
' ============================================================

Public Class AttackPlan
    Public Property Source As Territory
    Public Property Target As Territory
    Public Property Count As Integer
End Class

Public Class Enemy

    Public Property Name As String
    Private rng As New Random()

    Public Sub New(name As String)
        Me.Name = name
    End Sub

    ' Looks at every enemy territory and every neighbor, gives each
    ' possible attack a score, and returns the best one (or Nothing).
    Public Function ChoosePlan(territories As List(Of Territory)) As AttackPlan
        Dim bestPlan As AttackPlan = Nothing
        Dim bestScore As Integer = Integer.MinValue

        For Each t As Territory In territories
            If t.Owner = OwnerType.Enemy AndAlso t.Soldiers >= 4 Then

                Dim sendCount As Integer = t.Soldiers - 1   ' always leave 1 at home

                For Each n As Territory In t.Neighbors
                    If n.Owner <> OwnerType.Enemy Then

                        ' Only attack when clearly stronger than the defense
                        If sendCount > n.Soldiers * n.DefenseBonus + 2 Then

                            Dim score As Integer = n.GoldProduction * 2 - n.Soldiers
                            If n.Owner = OwnerType.Neutral Then score += 4   ' likes free land
                            If n.Owner = OwnerType.Player Then score += 6    ' likes hurting you
                            score += rng.Next(0, 3)                          ' a little randomness

                            If score > bestScore Then
                                bestScore = score
                                bestPlan = New AttackPlan()
                                bestPlan.Source = t
                                bestPlan.Target = n
                                bestPlan.Count = sendCount
                            End If
                        End If
                    End If
                Next
            End If
        Next

        Return bestPlan
    End Function

End Class
