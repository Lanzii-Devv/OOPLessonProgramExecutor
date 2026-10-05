' ============================================================
' Player.vb
' The player's faction: name and gold.
' ============================================================

Public Class Player

    Public Const RecruitCost As Integer = 5   ' gold per soldier
    Private Const StartingGold As Integer = 150

    Public Property Name As String
    Public Property Gold As Integer

    Public Sub New(name As String)
        Me.Name = name
        Me.Gold = StartingGold
    End Sub

    Public Function CanAfford(cost As Integer) As Boolean
        Return Gold >= cost
    End Function

    Public Sub Spend(cost As Integer)
        Gold -= cost
    End Sub

    Public Sub Earn(amount As Integer)
        Gold += amount
    End Sub

    Public Sub Reset()
        Gold = StartingGold
    End Sub

End Class
