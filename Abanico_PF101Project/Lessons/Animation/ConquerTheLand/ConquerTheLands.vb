' ============================================================
' Form1.vb  -  CONQUER THE LAND
'
' The Form is the "game director":
'   * builds the screen
'   * listens for clicks and the Timer
'   * asks the classes (Territory, Battle, Player, Enemy) to do the work
'   * redraws everything in RefreshAll()
'
' HOW TO USE: replace the contents of the Form1.vb that Visual Studio
' created with this file. Leave Form1.Designer.vb alone - all controls
' are created in code in BuildInterface().
' ============================================================

Public Class ConquerTheLands

    ' ---------- Game settings (change these to tune the game) ----------
    Private Const TurnSeconds As Integer = 5          ' gold + soldier growth every 5 sec
    Private Const EnemyActionSeconds As Integer = 8   ' enemy picks a new target every 8 sec
    Private Const WarningSeconds As Integer = 3       ' enemy WARNS you this long before it strikes
    Private Const GraceSeconds As Integer = 20        ' enemy does not attack during the first 20 sec
    Private Const MaxLogLines As Integer = 40

    ' ---------- Game data ----------
    Private territories As New List(Of Territory)
    Private human As Player
    Private ai As Enemy
    Private rng As New Random()

    Private selected As Territory     ' your chosen territory (left-click)
    Private target As Territory       ' the target territory (right-click)

    Private gameSeconds As Integer
    Private isPaused As Boolean
    Private isGameOver As Boolean
    Private pausedByHelp As Boolean         ' the guide tab paused the game for you

    Private pendingPlan As AttackPlan       ' an enemy attack that has been announced
    Private pendingSeconds As Integer
    Private dragSource As Territory         ' territory you are dragging FROM
    Private sendPercent As Integer = 50     ' how much of the army an order uses

    ' ---------- The ONE main game timer ----------
    Private WithEvents tmrGame As New Timer()

    ' ---------- Controls (created in BuildInterface) ----------
    Private tiles As New List(Of TerritoryTile)
    Private pbSelected As PictureBox
    Private iconShownFor As Territory

    Private lblFaction As Label
    Private lblGold As Label
    Private lblSoldiers As Label
    Private lblTerritories As Label
    Private lblTime As Label
    Private lblStatus As Label

    Private lblInfo As Label
    Private lblHelp As Label
    Private lblMessage As Label
    Private lblSendPreview As Label
    Private pctButtons As New List(Of Button)
    Private lstLog As ListBox

    Private WithEvents btnAttack As New Button()
    Private WithEvents btnMove As New Button()
    Private WithEvents btnRecruit As New Button()
    Private WithEvents btnRecruitMax As New Button()

    ' Two tabs: the game itself and the beginner's guide
    Private WithEvents tabMain As New TabControl()
    Private tabGame As New TabPage("GAME")
    Private tabHelp As New TabPage("HOW TO PLAY")
    Private WithEvents btnStartPlaying As New Button()
    Private WithEvents btnPause As New Button()
    Private WithEvents btnRestart As New Button()

    ' =====================================================
    '  STARTUP
    ' =====================================================
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateTerritories()
        BuildInterface()

        human = New Player("Blue Kingdom")
        ai = New Enemy("Red Empire")

        tmrGame.Interval = 1000   ' 1000 ms = 1 second
        StartNewGame()
    End Sub

    ' Creates the 12 territories and links neighbors.
    Private Sub CreateTerritories()
        ' Order matters: it matches the grid (4 columns x 3 rows)
        '   Row 0:  Capital   Forest        Hill       Fortress
        '   Row 1:  Farmland  Riverlands    Iron Valley Mountains
        '   Row 2:  Village   Golden Plains Wasteland   Harbor
        '                      name,            description,                owner,            soldiers, max, gold, growth, defense
        territories.Add(New Territory("Capital", "Seat of power", OwnerType.Player, 20, 40, 10, 2, 1.2))
        territories.Add(New Territory("Forest", "Moderate resources", OwnerType.Player, 10, 25, 3, 1, 1.1))
        territories.Add(New Territory("Hill", "Good lookout point", OwnerType.Neutral, 8, 20, 2, 1, 1.2))
        territories.Add(New Territory("Fortress", "Enemy stronghold", OwnerType.Enemy, 20, 40, 10, 2, 1.3))

        territories.Add(New Territory("Farmland", "Feeds new soldiers", OwnerType.Player, 8, 25, 5, 2, 1.0))
        territories.Add(New Territory("Riverlands", "Balanced resources", OwnerType.Neutral, 8, 25, 4, 1, 1.0))
        territories.Add(New Territory("Iron Valley", "Iron for armies", OwnerType.Enemy, 12, 30, 5, 1, 1.1))
        territories.Add(New Territory("Mountains", "Hard to capture", OwnerType.Enemy, 15, 30, 2, 1, 1.5))

        territories.Add(New Territory("Village", "Small settlement", OwnerType.Neutral, 6, 20, 3, 1, 1.0))
        territories.Add(New Territory("Golden Plains", "Huge gold output", OwnerType.Neutral, 10, 25, 8, 1, 1.0))
        territories.Add(New Territory("Wasteland", "Poor, but a useful path", OwnerType.Neutral, 4, 15, 1, 0, 1.0))
        territories.Add(New Territory("Harbor", "Trade port", OwnerType.Neutral, 8, 25, 5, 1, 1.0))

        ' Neighbors = the tile to the right and the tile below
        ' (AddNeighbor links BOTH directions automatically)
        For i As Integer = 0 To territories.Count - 1
            Dim row As Integer = i \ 4
            Dim col As Integer = i Mod 4
            If col < 3 Then territories(i).AddNeighbor(territories(i + 1))
            If row < 2 Then territories(i).AddNeighbor(territories(i + 4))
        Next
    End Sub

    ' Builds every control in code (no designer needed)
    Private Sub BuildInterface()
        Me.Text = "Conquer the Land"
        Me.ClientSize = New Size(1040, 810)
        Me.MinimumSize = New Size(960, 730)
        Me.BackColor = Color.FromArgb(24, 28, 44)
        Me.KeyPreview = True   ' the form sees key presses first (for shortcuts)
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Root layout: 4 rows x 2 columns
        Dim root As New TableLayoutPanel()
        root.Dock = DockStyle.Fill
        root.ColumnCount = 2
        root.RowCount = 4
        root.BackColor = Color.FromArgb(24, 28, 44)
        root.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))
        root.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 300))
        root.RowStyles.Add(New RowStyle(SizeType.Absolute, 50))
        root.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
        root.RowStyles.Add(New RowStyle(SizeType.Absolute, 120))
        root.RowStyles.Add(New RowStyle(SizeType.Absolute, 64))
        ' The whole game screen lives on the first tab
        tabMain.Dock = DockStyle.Fill
        tabMain.DrawMode = TabDrawMode.OwnerDrawFixed     ' we paint the tab headers ourselves
        tabMain.SizeMode = TabSizeMode.Fixed
        tabMain.ItemSize = New Size(170, 34)
        tabGame.BackColor = Color.FromArgb(24, 28, 44)
        tabGame.Padding = New Padding(0)
        tabHelp.Padding = New Padding(0)
        tabMain.TabPages.Add(tabGame)
        tabMain.TabPages.Add(tabHelp)
        tabGame.Controls.Add(root)
        Me.Controls.Add(tabMain)

        ' ----- Row 0: top information bar -----
        Dim flowTop As New GradientPanel()
        flowTop.Dock = DockStyle.Fill
        lblFaction = MakeTopLabel(flowTop, "Capital")
        lblGold = MakeTopLabel(flowTop, "coin")
        lblSoldiers = MakeTopLabel(flowTop, "soldier")
        lblTerritories = MakeTopLabel(flowTop, "flag")
        lblTime = MakeTopLabel(flowTop, "clock")
        lblStatus = MakeTopLabel(flowTop, "swords")
        root.Controls.Add(flowTop, 0, 0)
        root.SetColumnSpan(flowTop, 2)

        ' ----- Row 1, column 0: the map (4 x 3 grid of panels) -----
        Dim mapTable As New TableLayoutPanel()
        mapTable.Dock = DockStyle.Fill
        mapTable.BackColor = Color.FromArgb(30, 60, 95)   ' the 'sea' between tiles
        mapTable.ColumnCount = 4
        mapTable.RowCount = 3
        For c As Integer = 0 To 3
            mapTable.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25))
        Next
        For r As Integer = 0 To 2
            mapTable.RowStyles.Add(New RowStyle(SizeType.Percent, 33.33))
        Next

        For i As Integer = 0 To territories.Count - 1
            ' Each tile is a custom control that paints itself (see TerritoryTile.vb)
            Dim tile As New TerritoryTile()
            tile.Dock = DockStyle.Fill
            tile.Margin = New Padding(2)
            tile.Data = territories(i)
            tile.Tag = i

            AddHandler tile.MouseDown, AddressOf Territory_MouseDown
            AddHandler tile.MouseMove, AddressOf Territory_MouseMove
            AddHandler tile.MouseUp, AddressOf Territory_MouseUp

            tiles.Add(tile)
            mapTable.Controls.Add(tile, i Mod 4, i \ 4)
        Next
        root.Controls.Add(mapTable, 0, 1)

        ' ----- Row 1, column 1: info panel (top) + actions panel (bottom) -----
        Dim rightTable As New TableLayoutPanel()
        rightTable.Dock = DockStyle.Fill
        rightTable.ColumnCount = 1
        rightTable.RowCount = 2
        rightTable.RowStyles.Add(New RowStyle(SizeType.Percent, 66))
        rightTable.RowStyles.Add(New RowStyle(SizeType.Percent, 34))

        Dim grpInfo As New GroupBox()
        grpInfo.Text = "Territory Info"
        grpInfo.ForeColor = Color.White
        grpInfo.Dock = DockStyle.Fill
        ' Picture of the selected terrain (top) + text (below)
        Dim infoTable As New TableLayoutPanel()
        infoTable.Dock = DockStyle.Fill
        infoTable.ColumnCount = 1
        infoTable.RowCount = 2
        infoTable.RowStyles.Add(New RowStyle(SizeType.Absolute, 92))
        infoTable.RowStyles.Add(New RowStyle(SizeType.Percent, 100))

        pbSelected = New PictureBox()
        pbSelected.Dock = DockStyle.Fill
        pbSelected.SizeMode = PictureBoxSizeMode.Zoom
        infoTable.Controls.Add(pbSelected, 0, 0)

        lblInfo = New Label()
        lblInfo.Dock = DockStyle.Fill
        lblInfo.Font = New Font("Consolas", 9.0F)
        lblInfo.BackColor = Color.FromArgb(245, 236, 210)   ' parchment
        lblInfo.ForeColor = Color.FromArgb(50, 40, 30)
        lblInfo.Padding = New Padding(8)
        infoTable.Controls.Add(lblInfo, 0, 1)

        grpInfo.Controls.Add(infoTable)
        rightTable.Controls.Add(grpInfo, 0, 0)

        Dim grpActions As New GroupBox()
        grpActions.Text = "Actions"
        grpActions.ForeColor = Color.White
        grpActions.Dock = DockStyle.Fill

        lblHelp = New Label()
        lblHelp.Location = New Point(8, 18)
        lblHelp.Size = New Size(280, 34)
        lblHelp.ForeColor = Color.Gainsboro
        lblHelp.Text = "DRAG from your territory onto a neighbor to attack or move."
        grpActions.Controls.Add(lblHelp)

        Dim lblSend As New Label()
        lblSend.Text = "Send how many soldiers?  (keys 1-4)"
        lblSend.Location = New Point(8, 54)
        lblSend.AutoSize = True
        grpActions.Controls.Add(lblSend)

        ' Quick-pick buttons: 25% / 50% / 75% / ALL
        Dim pcts() As Integer = {25, 50, 75, 100}
        For k As Integer = 0 To 3
            Dim pb As New Button()
            pb.Text = If(pcts(k) = 100, "ALL", pcts(k) & "%")
            pb.Tag = pcts(k)
            pb.Size = New Size(64, 28)
            pb.Location = New Point(8 + k * 69, 74)
            pb.FlatStyle = FlatStyle.Flat
            pb.FlatAppearance.BorderSize = 0
            pb.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
            pb.Cursor = Cursors.Hand
            pb.TabStop = False
            AddHandler pb.Click, AddressOf PercentButton_Click
            pctButtons.Add(pb)
            grpActions.Controls.Add(pb)
        Next

        lblSendPreview = New Label()
        lblSendPreview.Location = New Point(8, 106)
        lblSendPreview.Size = New Size(280, 18)
        lblSendPreview.ForeColor = Color.Gold
        grpActions.Controls.Add(lblSendPreview)

        lblMessage = New Label()
        lblMessage.Location = New Point(8, 126)
        lblMessage.Size = New Size(280, 34)
        lblMessage.ForeColor = Color.Tomato
        grpActions.Controls.Add(lblMessage)

        rightTable.Controls.Add(grpActions, 0, 1)
        root.Controls.Add(rightTable, 1, 1)

        ' ----- Row 2: game log -----
        Dim grpLog As New GroupBox()
        grpLog.Text = "Game Log"
        grpLog.ForeColor = Color.White
        grpLog.Dock = DockStyle.Fill
        lstLog = New ListBox()
        lstLog.Dock = DockStyle.Fill
        lstLog.IntegralHeight = False
        lstLog.BackColor = Color.FromArgb(18, 20, 32)
        lstLog.ForeColor = Color.FromArgb(190, 230, 190)
        lstLog.Font = New Font("Consolas", 9.0F)
        grpLog.Controls.Add(lstLog)
        root.Controls.Add(grpLog, 0, 2)
        root.SetColumnSpan(grpLog, 2)

        ' ----- Row 3: buttons -----
        Dim flowButtons As New FlowLayoutPanel()
        flowButtons.Dock = DockStyle.Fill
        flowButtons.BackColor = Color.FromArgb(24, 28, 44)
        SetupButton(btnAttack, "ATTACK (Q)", Color.FromArgb(190, 50, 50), flowButtons)
        SetupButton(btnMove, "MOVE (W)", Color.FromArgb(50, 110, 190), flowButtons)
        SetupButton(btnRecruit, "RECRUIT +5 (E)", Color.FromArgb(50, 150, 80), flowButtons)
        SetupButton(btnRecruitMax, "RECRUIT MAX (R)", Color.FromArgb(35, 120, 65), flowButtons)
        SetupButton(btnPause, "PAUSE (Space)", Color.FromArgb(210, 140, 30), flowButtons)
        SetupButton(btnRestart, "RESTART GAME", Color.FromArgb(100, 100, 120), flowButtons)
        root.Controls.Add(flowButtons, 0, 3)
        root.SetColumnSpan(flowButtons, 2)

        BuildHelpTab()
    End Sub

    Private Function MakeTopLabel(parent As FlowLayoutPanel, iconName As String) As Label
        ' small icon (drawn by the Icons class) followed by the text label
        Dim pic As New PictureBox()
        pic.Size = New Size(30, 30)
        pic.BackColor = Color.Transparent
        pic.Margin = New Padding(14, 9, 0, 0)
        pic.Image = Icons.MakeBitmap(iconName, 30, 30)
        parent.Controls.Add(pic)

        Dim lbl As New Label()
        lbl.AutoSize = True
        lbl.BackColor = Color.Transparent
        lbl.ForeColor = Color.White
        lbl.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        lbl.Margin = New Padding(4, 12, 6, 0)
        parent.Controls.Add(lbl)
        Return lbl
    End Function

    Private Sub SetupButton(btn As Button, text As String, color As Color, parent As FlowLayoutPanel)
        btn.Text = text
        btn.Size = New Size(142, 42)
        btn.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.BackColor = color
        btn.ForeColor = Color.White
        btn.Cursor = Cursors.Hand
        btn.TabStop = False   ' so the Space key never 'clicks' a focused button
        btn.Margin = New Padding(6, 8, 6, 6)
        parent.Controls.Add(btn)
    End Sub

    ' =====================================================
    '  START / RESTART
    ' =====================================================
    Private Sub StartNewGame()
        For Each t As Territory In territories
            t.ResetToStart()
        Next
        human.Reset()

        gameSeconds = 0
        isPaused = False
        isGameOver = False
        pendingPlan = Nothing
        dragSource = Nothing
        selected = Nothing
        target = Nothing

        btnPause.Text = "PAUSE (Space)"
        lblMessage.Text = ""
        lstLog.Items.Clear()
        AddLog("The war for the land begins!")
        AddLog("New here? Open the HOW TO PLAY tab.")

        tmrGame.Start()
        RefreshAll()
    End Sub

    ' =====================================================
    '  THE MAIN GAME TIMER  (fires every 1 second)
    ' =====================================================
    Private Sub tmrGame_Tick(sender As Object, e As EventArgs) Handles tmrGame.Tick
        If isPaused OrElse isGameOver Then Return

        gameSeconds += 1

        For Each t As Territory In territories
            t.TickTimers()
        Next

        ' Every "turn": produce gold and grow armies
        If gameSeconds Mod TurnSeconds = 0 Then
            ProcessTurn()
        End If

        ' The enemy plans, WARNS you, then strikes (see EnemyUpdate)
        EnemyUpdate()

        CheckGameOver()
        RefreshAll()
    End Sub

    Private Sub ProcessTurn()
        Dim income As Integer = 0

        For Each t As Territory In territories
            If t.Owner = OwnerType.Player Then
                income += t.GoldProduction
            End If
            ' Player AND enemy territories train new soldiers
            If t.Owner <> OwnerType.Neutral Then
                t.AddSoldiers(t.SoldierGrowth)
            End If
        Next

        If income > 0 Then
            human.Earn(income)
            AddLog("You gained " & income & " Gold.")
        End If
    End Sub

    ' The enemy works in two steps so you always get a chance to react:
    '   1) it picks a target and WARNS you (the tile flashes "ENEMY INCOMING")
    '   2) a few seconds later the attack really happens
    Private Sub EnemyUpdate()
        ' Step 2: an announced attack is counting down
        If pendingPlan IsNot Nothing Then
            pendingSeconds -= 1
            If pendingSeconds <= 0 Then
                ExecuteEnemyAttack(pendingPlan)
                pendingPlan = Nothing
            End If
            Return
        End If

        ' Step 1: pick a new target (not during the grace period)
        If gameSeconds < GraceSeconds Then Return
        If gameSeconds Mod EnemyActionSeconds <> 0 Then Return

        Dim plan As AttackPlan = ai.ChoosePlan(territories)
        If plan Is Nothing Then Return

        pendingPlan = plan
        pendingSeconds = WarningSeconds
        plan.Target.ThreatSeconds = WarningSeconds

        If plan.Target.Owner = OwnerType.Player Then
            AddLog("WARNING: Enemy is about to attack " & plan.Target.Name & "!")
            lblMessage.Text = "WARNING: Enemy attacks " & plan.Target.Name & " in " & WarningSeconds & " seconds!"
        Else
            AddLog("Enemy is preparing to take " & plan.Target.Name & ".")
        End If
    End Sub

    Private Sub ExecuteEnemyAttack(plan As AttackPlan)
        plan.Target.ThreatSeconds = 0

        ' The situation may have changed while the warning counted down
        If plan.Source.Owner <> OwnerType.Enemy Then Return
        If plan.Target.Owner = OwnerType.Enemy Then Return
        Dim count As Integer = Math.Min(plan.Count, plan.Source.Soldiers - 1)
        If count < 1 Then Return

        Dim defenderWas As OwnerType = plan.Target.Owner
        Dim name As String = plan.Target.Name

        AddLog("Enemy attacked " & name & "!")
        Dim result As BattleResult = Battle.Attack(plan.Source, plan.Target, count, rng)

        If result.AttackerWon Then
            If defenderWas = OwnerType.Player Then
                AddLog(name & " has been captured by the enemy!")
                lblMessage.Text = name & " has been captured by the enemy!"
            Else
                AddLog("Enemy captured " & name & ".")
            End If
            If target Is plan.Target Then target = Nothing
        Else
            If defenderWas = OwnerType.Player Then
                AddLog("You successfully defended " & name & ".")
                lblMessage.Text = "You successfully defended " & name & "."
            Else
                AddLog("Enemy attack on " & name & " failed.")
            End If
        End If
    End Sub

    Private Sub CheckGameOver()
        Dim owned As Integer = CountPlayerTerritories()

        If owned = 0 Then
            EndGame("YOUR LAND HAS FALLEN")
        ElseIf owned = territories.Count Then
            EndGame("YOU CONQUERED THE LAND!")
        End If
    End Sub

    Private Sub EndGame(message As String)
        isGameOver = True
        tmrGame.Stop()
        lblStatus.Text = "Status: " & message
        AddLog(message)
        RefreshAll()
        MessageBox.Show(message, "Conquer the Land")
    End Sub

    ' =====================================================
    '  CLICKING TERRITORIES
    ' =====================================================
    Private Sub Territory_MouseDown(sender As Object, e As MouseEventArgs)
        Dim index As Integer = CInt(CType(sender, Control).Tag)
        Dim clicked As Territory = territories(index)

        If e.Button = MouseButtons.Right Then
            ' Right-click = set the TARGET (alternative to dragging)
            If selected Is Nothing Then
                lblMessage.Text = "Left-click one of your territories first."
                Return
            End If
            target = clicked
        Else
            selected = clicked
            If target Is selected Then target = Nothing

            ' Pressing on YOUR territory may start a drag
            If clicked.Owner = OwnerType.Player Then
                dragSource = clicked
            Else
                dragSource = Nothing
            End If
        End If

        lblMessage.Text = ""
        RefreshAll()
    End Sub

    ' While dragging, the territory under the mouse becomes the (orange) target
    Private Sub Territory_MouseMove(sender As Object, e As MouseEventArgs)
        If dragSource Is Nothing OrElse e.Button <> MouseButtons.Left Then Return

        Dim over As Territory = TerritoryAtCursor()
        Dim newTarget As Territory = Nothing
        If over IsNot Nothing AndAlso over IsNot dragSource Then newTarget = over

        If newTarget IsNot target Then
            target = newTarget
            RefreshAll()
        End If
    End Sub

    ' Releasing the mouse on another territory = carry out the order
    Private Sub Territory_MouseUp(sender As Object, e As MouseEventArgs)
        If dragSource Is Nothing OrElse e.Button <> MouseButtons.Left Then Return

        Dim src As Territory = dragSource
        dragSource = Nothing
        Dim dropped As Territory = TerritoryAtCursor()

        If dropped Is Nothing OrElse dropped Is src Then
            target = Nothing        ' it was only a click
            RefreshAll()
            Return
        End If

        selected = src
        target = dropped
        If dropped.Owner = OwnerType.Player Then
            DoMove(src, dropped)
        Else
            DoAttack(src, dropped)
        End If
    End Sub

    ' Which territory is the mouse pointer over right now?
    Private Function TerritoryAtCursor() As Territory
        For i As Integer = 0 To tiles.Count - 1
            Dim area As Rectangle = tiles(i).RectangleToScreen(tiles(i).ClientRectangle)
            If area.Contains(Cursor.Position) Then Return territories(i)
        Next
        Return Nothing
    End Function

    ' =====================================================
    '  BUTTONS
    ' =====================================================
    ' Orders are allowed while PAUSED (active pause): freeze the clock,
    ' think, give your orders, then resume.
    Private Function CanAct() As Boolean
        If isGameOver Then
            lblMessage.Text = "The game is over. Press RESTART GAME."
            Return False
        End If
        Return True
    End Function

    Private Sub btnAttack_Click(sender As Object, e As EventArgs) Handles btnAttack.Click
        If selected Is Nothing OrElse target Is Nothing Then
            lblMessage.Text = "Pick your territory and a target first (or just drag)."
            Return
        End If
        DoAttack(selected, target)
    End Sub

    Private Sub btnMove_Click(sender As Object, e As EventArgs) Handles btnMove.Click
        If selected Is Nothing OrElse target Is Nothing Then
            lblMessage.Text = "Pick your territory and a destination first (or just drag)."
            Return
        End If
        DoMove(selected, target)
    End Sub

    Private Sub btnRecruit_Click(sender As Object, e As EventArgs) Handles btnRecruit.Click
        DoRecruit(False)
    End Sub

    Private Sub btnRecruitMax_Click(sender As Object, e As EventArgs) Handles btnRecruitMax.Click
        DoRecruit(True)
    End Sub

    Private Sub PercentButton_Click(sender As Object, e As EventArgs)
        SetPercent(CInt(CType(sender, Button).Tag))
    End Sub

    Private Sub SetPercent(percent As Integer)
        sendPercent = percent
        RefreshAll()
    End Sub

    ' How many soldiers an order uses: a % of what can leave (1 always stays home)
    Private Function SendAmount(src As Territory) As Integer
        Dim available As Integer = src.Soldiers - 1
        If available <= 0 Then Return 0
        Return Math.Max(1, CInt(Math.Ceiling(available * sendPercent / 100.0)))
    End Function

    Private Sub DoAttack(src As Territory, dst As Territory)
        If Not CanAct() Then Return

        If src.Owner <> OwnerType.Player Then
            lblMessage.Text = "You can only attack from your own territory."
            Return
        End If
        If dst.Owner = OwnerType.Player Then
            lblMessage.Text = "That territory is already yours."
            Return
        End If
        If Not src.IsNeighborOf(dst) Then
            lblMessage.Text = "You can only attack neighboring territories."
            Return
        End If

        Dim count As Integer = SendAmount(src)
        If count < 1 Then
            lblMessage.Text = src.Name & " has no spare soldiers (it must keep 1)."
            Return
        End If

        Dim name As String = dst.Name
        AddLog("You attacked " & name & " with " & count & " soldiers.")
        Dim result As BattleResult = Battle.Attack(src, dst, count, rng)

        If result.AttackerWon Then
            AddLog("You captured " & name & ".")
            lblMessage.Text = "You captured " & name & "!"
            target = Nothing
        Else
            AddLog("Your attack on " & name & " failed.")
            lblMessage.Text = "Your attack on " & name & " failed."
        End If

        CheckGameOver()
        RefreshAll()
    End Sub

    Private Sub DoMove(src As Territory, dst As Territory)
        If Not CanAct() Then Return

        If src.Owner <> OwnerType.Player OrElse dst.Owner <> OwnerType.Player Then
            lblMessage.Text = "You can only move soldiers between your own territories."
            Return
        End If
        If src Is dst OrElse Not src.IsNeighborOf(dst) Then
            lblMessage.Text = "You can only move soldiers to a neighboring territory."
            Return
        End If

        Dim count As Integer = SendAmount(src)
        If count < 1 Then
            lblMessage.Text = src.Name & " has no spare soldiers (it must keep 1)."
            Return
        End If
        If dst.FreeSpace <= 0 Then
            lblMessage.Text = dst.Name & " is already full."
            Return
        End If

        Dim moved As Integer = dst.AddSoldiers(count)
        src.Soldiers -= moved
        AddLog("You moved " & moved & " soldiers from " & src.Name & " to " & dst.Name & ".")
        lblMessage.Text = ""
        RefreshAll()
    End Sub

    ' wantMax = False: recruit 5.   wantMax = True: as many as gold and space allow.
    Private Sub DoRecruit(wantMax As Boolean)
        If Not CanAct() Then Return

        If selected Is Nothing OrElse selected.Owner <> OwnerType.Player Then
            lblMessage.Text = "Select one of your own territories to recruit."
            Return
        End If
        If selected.FreeSpace <= 0 Then
            lblMessage.Text = selected.Name & " is at full capacity."
            Return
        End If

        Dim count As Integer
        If wantMax Then
            count = Math.Min(selected.FreeSpace, human.Gold \ Player.RecruitCost)
        Else
            count = Math.Min(5, selected.FreeSpace)
        End If

        Dim cost As Integer = count * Player.RecruitCost
        If count < 1 OrElse Not human.CanAfford(cost) Then
            lblMessage.Text = "Not enough gold. (1 soldier costs " & Player.RecruitCost & ")"
            Return
        End If

        human.Spend(cost)
        selected.AddSoldiers(count)
        AddLog("You recruited " & count & " soldiers in " & selected.Name & " for " & cost & " gold.")
        lblMessage.Text = ""
        RefreshAll()
    End Sub

    Private Sub btnPause_Click(sender As Object, e As EventArgs) Handles btnPause.Click
        TogglePause()
    End Sub

    Private Sub TogglePause()
        If isGameOver Then Return

        isPaused = Not isPaused

        If isPaused Then
            tmrGame.Stop()
            btnPause.Text = "RESUME (Space)"
            AddLog("Game paused. You can still give orders.")
        Else
            tmrGame.Start()
            btnPause.Text = "PAUSE (Space)"
            AddLog("Game resumed.")
        End If

        RefreshAll()
    End Sub

    Private Sub btnRestart_Click(sender As Object, e As EventArgs) Handles btnRestart.Click
        StartNewGame()
    End Sub

    ' =====================================================
    '  UPDATING THE SCREEN
    ' =====================================================
    Private Sub RefreshAll()
        ' ----- the map: tell each tile its state, then ask it to repaint -----
        For i As Integer = 0 To territories.Count - 1
            tiles(i).IsSelected = (territories(i) Is selected)
            tiles(i).IsTarget = (territories(i) Is target)
            tiles(i).Invalidate()
        Next
        UpdateSelectedIcon()

        ' ----- top bar -----
        lblFaction.Text = human.Name
        lblGold.Text = "Gold: " & human.Gold
        lblSoldiers.Text = "Soldiers: " & CountPlayerSoldiers()
        lblTerritories.Text = "Territories: " & CountPlayerTerritories() & " / " & territories.Count
        lblTime.Text = "Time: " & (gameSeconds \ 60).ToString("00") & ":" & (gameSeconds Mod 60).ToString("00")

        If isGameOver Then
            ' lblStatus was already set by EndGame
        ElseIf isPaused Then
            lblStatus.Text = "Status: PAUSED"
        Else
            lblStatus.Text = "Status: Running"
        End If

        ' ----- info panel -----
        lblInfo.Text = BuildInfoText()
        UpdateSendUI()
    End Sub

    Private Sub UpdateSelectedIcon()
        If selected Is iconShownFor Then Return
        iconShownFor = selected

        If pbSelected.Image IsNot Nothing Then
            pbSelected.Image.Dispose()
            pbSelected.Image = Nothing
        End If

        If selected IsNot Nothing Then
            pbSelected.Image = Icons.MakeTerrainBitmap(selected.Name, 240, 84)
        End If
    End Sub

    Private Function BuildInfoText() As String
        If selected Is Nothing Then
            Return "Left-click a territory to see its information."
        End If

        Dim s As String = DescribeTerritory(selected) & vbCrLf & vbCrLf & "Actions: "
        If selected.Owner = OwnerType.Player Then
            s &= "Attack / Move / Recruit"
        Else
            s &= "none (not yours)"
        End If

        If target IsNot Nothing Then
            s &= vbCrLf & vbCrLf & "TARGET: " & target.Name.ToUpper() & vbCrLf &
                 target.OwnerText & ", " & target.Soldiers & " soldiers" & vbCrLf &
                 "Neighbor: " & If(selected.IsNeighborOf(target), "Yes", "No")
        End If

        Return s
    End Function

    Private Function DescribeTerritory(t As Territory) As String
        Dim names As New List(Of String)
        For Each n As Territory In t.Neighbors
            names.Add(n.Name)
        Next

        Return t.Name.ToUpper() & vbCrLf &
               "(" & t.Description & ")" & vbCrLf &
               "Owner: " & t.OwnerText & vbCrLf &
               "Soldiers: " & t.Soldiers & " / " & t.MaxSoldiers & " max" & vbCrLf &
               "Gold: +" & t.GoldProduction & "/turn" & vbCrLf &
               "Growth: +" & t.SoldierGrowth & " soldiers/turn" & vbCrLf &
               "Defense: x" & t.DefenseBonus.ToString("0.0") & vbCrLf &
               "Under attack: " & If(t.IsUnderAttack, "YES", "No") & vbCrLf &
               "Neighbors: " & String.Join(", ", names)
    End Function

    ' =====================================================
    '  SMALL HELPERS
    ' =====================================================
    Private Function CountPlayerTerritories() As Integer
        Dim count As Integer = 0
        For Each t As Territory In territories
            If t.Owner = OwnerType.Player Then count += 1
        Next
        Return count
    End Function

    Private Function CountPlayerSoldiers() As Integer
        Dim total As Integer = 0
        For Each t As Territory In territories
            If t.Owner = OwnerType.Player Then total += t.Soldiers
        Next
        Return total
    End Function

    Private Sub AddLog(message As String)
        Dim stamp As String = (gameSeconds \ 60).ToString("00") & ":" & (gameSeconds Mod 60).ToString("00")
        lstLog.Items.Add(stamp & " - " & message)

        ' Keep the log from growing forever
        Do While lstLog.Items.Count > MaxLogLines
            lstLog.Items.RemoveAt(0)
        Loop

        ' Scroll to the newest message
        lstLog.TopIndex = lstLog.Items.Count - 1
    End Sub

    ' Highlight the chosen % button and preview the exact number of soldiers
    Private Sub UpdateSendUI()
        For Each b As Button In pctButtons
            If CInt(b.Tag) = sendPercent Then
                b.BackColor = Color.FromArgb(235, 175, 40)
                b.ForeColor = Color.Black
            Else
                b.BackColor = Color.FromArgb(70, 75, 100)
                b.ForeColor = Color.White
            End If
        Next

        If selected IsNot Nothing AndAlso selected.Owner = OwnerType.Player Then
            lblSendPreview.Text = "= " & SendAmount(selected) & " of " & selected.Soldiers & " soldiers in " & selected.Name
        Else
            lblSendPreview.Text = "(select one of your territories)"
        End If
    End Sub

    ' =====================================================
    '  KEYBOARD SHORTCUTS
    ' =====================================================
    ' All shortcuts sit together under the left hand:
    '      1  2  3  4     how many soldiers   (25% / 50% / 75% / ALL)
    '      Q  W  E  R     Attack / Move / Recruit +5 / Recruit MAX
    '      Space          Pause          X  Clear selection
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If tabMain.SelectedTab IsNot tabGame Then Return   ' ignore keys while reading the guide

        Select Case e.KeyCode
            Case Keys.Q
                btnAttack.PerformClick()
            Case Keys.W
                btnMove.PerformClick()
            Case Keys.E
                btnRecruit.PerformClick()
            Case Keys.R
                btnRecruitMax.PerformClick()
            Case Keys.Space
                TogglePause()
            Case Keys.D1
                SetPercent(25)
            Case Keys.D2
                SetPercent(50)
            Case Keys.D3
                SetPercent(75)
            Case Keys.D4
                SetPercent(100)
            Case Keys.X, Keys.Escape
                selected = Nothing
                target = Nothing
                RefreshAll()
            Case Else
                Return
        End Select

        e.Handled = True
        e.SuppressKeyPress = True
    End Sub

    ' =====================================================
    '  TABS
    ' =====================================================

    ' Opening the guide pauses the game; going back resumes it
    Private Sub tabMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabMain.SelectedIndexChanged
        If tabMain.SelectedTab Is tabHelp Then
            If Not isPaused AndAlso Not isGameOver Then
                TogglePause()
                pausedByHelp = True
            End If
        ElseIf pausedByHelp Then
            pausedByHelp = False
            If isPaused AndAlso Not isGameOver Then TogglePause()
        End If
    End Sub

    Private Sub btnStartPlaying_Click(sender As Object, e As EventArgs) Handles btnStartPlaying.Click
        tabMain.SelectedTab = tabGame
    End Sub

    ' Paint the tab headers (dark theme, gold when selected)
    Private Sub tabMain_DrawItem(sender As Object, e As DrawItemEventArgs) Handles tabMain.DrawItem
        Dim isSel As Boolean = (e.Index = tabMain.SelectedIndex)
        Dim back As Color = If(isSel, Color.FromArgb(235, 175, 40), Color.FromArgb(50, 55, 80))
        Dim fore As Color = If(isSel, Color.Black, Color.White)

        Using b As New SolidBrush(back)
            e.Graphics.FillRectangle(b, e.Bounds)
        End Using

        Using f As New Font("Segoe UI", 10.0F, FontStyle.Bold)
            Using sf As New StringFormat()
                sf.Alignment = StringAlignment.Center
                sf.LineAlignment = StringAlignment.Center
                Using fb As New SolidBrush(fore)
                    e.Graphics.DrawString(tabMain.TabPages(e.Index).Text, f, fb,
                                          New RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), sf)
                End Using
            End Using
        End Using
    End Sub

    ' =====================================================
    '  HOW TO PLAY TAB
    ' =====================================================
    Private Sub BuildHelpTab()
        tabHelp.BackColor = Color.FromArgb(24, 28, 44)

        Dim layout As New TableLayoutPanel()
        layout.Dock = DockStyle.Fill
        layout.ColumnCount = 1
        layout.RowCount = 2
        layout.Padding = New Padding(12)
        layout.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
        layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 62))

        ' "paper" panel gives the text some breathing room
        Dim paper As New Panel()
        paper.Dock = DockStyle.Fill
        paper.BackColor = Color.FromArgb(245, 236, 210)
        paper.Padding = New Padding(22, 14, 22, 14)

        Dim rtb As New RichTextBox()
        rtb.Dock = DockStyle.Fill
        rtb.ReadOnly = True
        rtb.BorderStyle = BorderStyle.None
        rtb.BackColor = Color.FromArgb(245, 236, 210)
        rtb.DetectUrls = False
        rtb.TabStop = False
        paper.Controls.Add(rtb)
        layout.Controls.Add(paper, 0, 0)

        ' ---------- the guide text ----------
        HelpTitle(rtb, "CONQUER THE LAND  -  HOW TO PLAY")
        HelpText(rtb, "Two armies, one map. Capture territories, grow your income, and beat the enemy before it beats you.")

        HelpHeading(rtb, "1. YOUR GOAL")
        HelpText(rtb, "  - WIN: own all " & territories.Count & " territories.")
        HelpText(rtb, "  - LOSE: the enemy captures every territory you own.")

        HelpHeading(rtb, "2. READING THE MAP")
        HelpText(rtb, "  - The ribbon on top of each card shows the owner: [P] Player (blue), [E] Enemy (red), [N] Neutral (gray).")
        HelpText(rtb, "  - Soldier icon: soldiers stationed there / the most it can hold. The bar at the bottom shows how full it is.")
        HelpText(rtb, "  - Coin icon: gold the territory gives you each turn (a turn is " & TurnSeconds & " seconds).")
        HelpText(rtb, "  - Gold border = your selection.  Orange border = your target.  Red flash with swords = a battle just happened.  Yellow triangle = ENEMY INCOMING.")

        HelpHeading(rtb, "3. GIVING ORDERS")
        HelpText(rtb, "  - SELECT: left-click one of your blue territories. Its details appear on the right.")
        HelpText(rtb, "  - ATTACK or MOVE: drag from your territory onto a neighbor. Drop on an enemy or neutral territory to attack, or on your own territory to move soldiers there.")
        HelpText(rtb, "  - Prefer clicking? Right-click a territory to make it the target, then press ATTACK or MOVE.")
        HelpText(rtb, "  - HOW MANY: choose 25%, 50%, 75% or ALL. One soldier always stays behind to guard.")
        HelpText(rtb, "  - RECRUIT: select your territory, then press RECRUIT +5 (or RECRUIT MAX to spend as much gold as you can). Each soldier costs " & Player.RecruitCost & " gold.")
        HelpText(rtb, "  - You can only attack or move to NEIGHBORS, so you must expand step by step.")

        HelpHeading(rtb, "4. KEYBOARD SHORTCUTS  (all under your left hand)")
        HelpMono(rtb, "     1     2     3     4         how many: 25% / 50% / 75% / ALL")
        HelpMono(rtb, "     Q     W     E     R         Attack / Move / Recruit +5 / Recruit MAX")
        HelpMono(rtb, "   SPACE = Pause / Resume        X = clear selection")

        HelpHeading(rtb, "5. BATTLES")
        HelpText(rtb, "  - Attack power = soldiers you send + a random 0 to 5.")
        HelpText(rtb, "  - Defense power = defenders x terrain bonus + a random 0 to 5.")
        HelpText(rtb, "  - Higher attack wins: the survivors take over the territory. Otherwise your attackers are lost (the defenders lose some soldiers too).")
        HelpText(rtb, "  - Terrain with a high defense bonus, like Mountains, needs a much bigger army.")

        HelpHeading(rtb, "6. THE ENEMY")
        HelpText(rtb, "  - The enemy does not attack for the first " & GraceSeconds & " seconds. Use that time to recruit and expand.")
        HelpText(rtb, "  - After that it picks a target and WARNS you " & WarningSeconds & " seconds ahead: the target flashes ENEMY INCOMING. Reinforce it with RECRUIT or MOVE!")
        HelpText(rtb, "  - PAUSE freezes the clock, gold and enemy, and you can still give orders while paused. Opening this tab pauses the game for you.")

        HelpHeading(rtb, "7. GOLD AND SOLDIERS")
        HelpText(rtb, "  - Every " & TurnSeconds & " seconds you earn gold from each territory you own. Owned territories also train free soldiers, up to their capacity (neutral ones do not).")
        HelpText(rtb, "  - Spend your gold on soldiers. A big pile of unused gold does not stop an attack!")

        HelpHeading(rtb, "8. THE TERRITORIES")
        For Each ter As Territory In territories
            HelpMono(rtb, "  " & ter.Name.PadRight(14) & " +" & ter.GoldProduction.ToString().PadRight(3) & " gold   +" &
                          ter.SoldierGrowth & " soldiers   defense x" & ter.DefenseBonus.ToString("0.0") & "   " & ter.Description)
        Next

        HelpHeading(rtb, "9. TIPS FOR NEW PLAYERS")
        HelpText(rtb, "  - Capture weak neutral territories early: they are cheap and they raise your income. Golden Plains pays the most.")
        HelpText(rtb, "  - Keep your biggest armies on the borders that touch the enemy.")
        HelpText(rtb, "  - Use MOVE to shift soldiers from safe back territories to the front line.")
        HelpText(rtb, "  - When ENEMY INCOMING appears, compare the numbers. If the attackers look stronger, reinforce right away.")
        HelpText(rtb, "  - Never leave your Capital weak: it makes the most gold.")
        HelpText(rtb, "  - Wasteland gives almost nothing, but it can be a useful shortcut.")

        HelpText(rtb, vbCrLf & "Good luck, commander! Press START PLAYING to return to the game.")

        rtb.SelectionStart = 0
        rtb.SelectionLength = 0
        rtb.ScrollToCaret()

        ' ---------- big button at the bottom ----------
        btnStartPlaying.Text = "START PLAYING"
        btnStartPlaying.Size = New Size(240, 44)
        btnStartPlaying.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        btnStartPlaying.FlatStyle = FlatStyle.Flat
        btnStartPlaying.FlatAppearance.BorderSize = 0
        btnStartPlaying.BackColor = Color.FromArgb(50, 150, 80)
        btnStartPlaying.ForeColor = Color.White
        btnStartPlaying.Cursor = Cursors.Hand
        btnStartPlaying.TabStop = False
        btnStartPlaying.Anchor = AnchorStyles.None        ' centered in its cell
        layout.Controls.Add(btnStartPlaying, 0, 1)

        tabHelp.Controls.Add(layout)
    End Sub

    ' --- small helpers that add formatted text to the RichTextBox ---
    Private Sub HelpAdd(rtb As RichTextBox, text As String, f As Font, c As Color)
        rtb.SelectionStart = rtb.TextLength
        rtb.SelectionLength = 0
        rtb.SelectionFont = f
        rtb.SelectionColor = c
        rtb.AppendText(text & vbCrLf)
    End Sub

    Private Sub HelpTitle(rtb As RichTextBox, text As String)
        HelpAdd(rtb, text, New Font("Segoe UI", 18.0F, FontStyle.Bold), Color.FromArgb(120, 50, 20))
    End Sub

    Private Sub HelpHeading(rtb As RichTextBox, text As String)
        HelpAdd(rtb, vbCrLf & text, New Font("Segoe UI", 12.5F, FontStyle.Bold), Color.FromArgb(150, 60, 20))
    End Sub

    Private Sub HelpText(rtb As RichTextBox, text As String)
        HelpAdd(rtb, text, New Font("Segoe UI", 10.5F), Color.FromArgb(40, 35, 30))
    End Sub

    Private Sub HelpMono(rtb As RichTextBox, text As String)
        HelpAdd(rtb, text, New Font("Consolas", 10.0F, FontStyle.Bold), Color.FromArgb(30, 60, 110))
    End Sub

End Class