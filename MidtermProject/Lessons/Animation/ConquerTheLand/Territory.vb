' ============================================================
' Territory.vb
' Holds ALL the data (and small behaviors) of one territory.
' Think of a Territory object as one "card" on the board.
' ============================================================

Public Enum OwnerType
    Neutral
    Player
    Enemy
End Enum

Public Class Territory

    ' ---------- Properties (the data each territory has) ----------
    Public Property Name As String
    Public Property Description As String          ' e.g. "Rich farmland"
    Public Property Owner As OwnerType
    Public Property Soldiers As Integer
    Public Property MaxSoldiers As Integer
    Public Property GoldProduction As Integer      ' gold per turn
    Public Property SoldierGrowth As Integer       ' free soldiers per turn
    Public Property DefenseBonus As Double         ' 1.0 = normal, 1.5 = Mountains
    Public Property UnderAttackSeconds As Integer  ' counts down after a battle
    Public Property ThreatSeconds As Integer       ' enemy has WARNED it will attack soon
    Public ReadOnly Property Neighbors As New List(Of Territory)

    ' Remembered so RESTART can put everything back
    Private startOwner As OwnerType
    Private startSoldiers As Integer

    ' ---------- Constructor ----------
    Public Sub New(name As String, description As String, owner As OwnerType,
                   soldiers As Integer, maxSoldiers As Integer,
                   goldProduction As Integer, soldierGrowth As Integer,
                   defenseBonus As Double)
        Me.Name = name
        Me.Description = description
        Me.Owner = owner
        Me.Soldiers = soldiers
        Me.MaxSoldiers = maxSoldiers
        Me.GoldProduction = goldProduction
        Me.SoldierGrowth = soldierGrowth
        Me.DefenseBonus = defenseBonus
        Me.UnderAttackSeconds = 0

        startOwner = owner
        startSoldiers = soldiers
    End Sub

    ' ---------- Read-only helper properties ----------
    Public ReadOnly Property IsUnderAttack As Boolean
        Get
            Return UnderAttackSeconds > 0
        End Get
    End Property

    Public ReadOnly Property IsThreatened As Boolean
        Get
            Return ThreatSeconds > 0
        End Get
    End Property

    Public ReadOnly Property OwnerText As String
        Get
            Select Case Owner
                Case OwnerType.Player
                    Return "Player"
                Case OwnerType.Enemy
                    Return "Enemy"
                Case Else
                    Return "Neutral"
            End Select
        End Get
    End Property

    ' A symbol so ownership is clear even without colors
    Public ReadOnly Property OwnerSymbol As String
        Get
            Select Case Owner
                Case OwnerType.Player
                    Return "P"
                Case OwnerType.Enemy
                    Return "E"
                Case Else
                    Return "N"
            End Select
        End Get
    End Property

    Public ReadOnly Property FreeSpace As Integer
        Get
            Return MaxSoldiers - Soldiers
        End Get
    End Property

    ' ---------- Methods ----------

    ' Makes two territories neighbors of each other (both directions)
    Public Sub AddNeighbor(other As Territory)
        If Not Neighbors.Contains(other) Then
            Neighbors.Add(other)
            other.Neighbors.Add(Me)
        End If
    End Sub

    Public Function IsNeighborOf(other As Territory) As Boolean
        Return Neighbors.Contains(other)
    End Function

    ' Adds soldiers but never above MaxSoldiers.
    ' Returns how many were really added.
    Public Function AddSoldiers(amount As Integer) As Integer
        Dim added As Integer = Math.Min(amount, FreeSpace)
        If added < 0 Then added = 0
        Soldiers += added
        Return added
    End Function

    Public Sub MarkUnderAttack()
        UnderAttackSeconds = 2
    End Sub

    ' Called once per timer tick
    Public Sub TickTimers()
        If UnderAttackSeconds > 0 Then
            UnderAttackSeconds -= 1
        End If
        If ThreatSeconds > 0 Then
            ThreatSeconds -= 1
        End If
    End Sub

    ' Used by RESTART
    Public Sub ResetToStart()
        Owner = startOwner
        Soldiers = startSoldiers
        UnderAttackSeconds = 0
        ThreatSeconds = 0
    End Sub

End Class