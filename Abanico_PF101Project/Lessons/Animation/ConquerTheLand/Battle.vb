' ============================================================
' Battle.vb
' The simple battle rules, used by BOTH the player and the enemy.
' ============================================================

Public Class BattleResult
    Public Property AttackerWon As Boolean
    Public Property AttackPower As Integer
    Public Property DefensePower As Integer
    Public Property SurvivingAttackers As Integer
End Class

Public Class Battle

    ' Sends 'attackers' soldiers from 'source' into 'target'.
    '
    '   Attack Power  = attackers + random(0..5)
    '   Defense Power = defenders * DefenseBonus + random(0..5)
    '
    ' Attacker wins if Attack Power > Defense Power.
    Public Shared Function Attack(source As Territory, target As Territory,
                                  attackers As Integer, rng As Random) As BattleResult
        Dim result As New BattleResult()

        ' The soldiers leave the source territory no matter what happens
        source.Soldiers -= attackers

        result.AttackPower = attackers + rng.Next(0, 6)
        result.DefensePower = CInt(Math.Round(target.Soldiers * target.DefenseBonus)) + rng.Next(0, 6)

        target.MarkUnderAttack()

        If result.AttackPower > result.DefensePower Then
            ' ---- Attacker wins: territory is captured ----
            result.AttackerWon = True
            result.SurvivingAttackers = Math.Max(1, attackers - target.Soldiers \ 2)
            target.Owner = source.Owner
            target.Soldiers = Math.Min(result.SurvivingAttackers, target.MaxSoldiers)
        Else
            ' ---- Defender survives; attackers are wiped out ----
            result.AttackerWon = False
            result.SurvivingAttackers = 0
            target.Soldiers = Math.Max(1, target.Soldiers - attackers \ 2)
        End If

        Return result
    End Function

End Class
