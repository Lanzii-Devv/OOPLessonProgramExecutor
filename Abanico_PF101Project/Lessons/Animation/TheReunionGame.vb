Imports System.Drawing.Drawing2D
Imports System.IO

Public Class TheReunionGame

    ' ===== UI CONTROLS =====
    Private WithEvents GameTimer As New Timer()
    Private lblTitle As Label
    Private lblSubtitle As Label
    Private lblTime As Label
    Private lblStatus As Label
    Private pnlDialogue As Panel
    Private txtDialogue As TextBox
    Private pnlChronicle As Panel
    Private lblChronicleHeader As Label
    Private lblNotes As TextBox
    Private btnStart As Button
    Private btnConfirm As Button
    Private btnReset As Button
    Private btnPlayAgain As Button
    Private sealPic As PictureBox

    ' ===== MEDIEVAL PALETTE =====
    Private ReadOnly Parchment As Color = Color.FromArgb(236, 224, 196)
    Private ReadOnly ParchmentShade As Color = Color.FromArgb(210, 194, 162)
    Private ReadOnly Ink As Color = Color.FromArgb(48, 34, 22)
    Private ReadOnly Crimson As Color = Color.FromArgb(120, 30, 40)
    Private ReadOnly Gold As Color = Color.FromArgb(200, 168, 90)
    Private ReadOnly GoldDim As Color = Color.FromArgb(140, 115, 60)
    Private ReadOnly Night As Color = Color.FromArgb(18, 14, 24)
    Private ReadOnly NightDeep As Color = Color.FromArgb(10, 8, 14)
    Private ReadOnly Candlelight As Color = Color.FromArgb(255, 226, 160)
    Private ReadOnly Wood As Color = Color.FromArgb(72, 48, 30)

    ' ===== GAME STATE =====
    Private Class Person
        Public Name As String
        Public Title As String
        Public IsFake As Boolean
        Public Hint As String
        Public Story As String
        Public CordColor As Color
        Public IsWorn As Boolean
        Public GroupId As Integer
        Public WasClicked As Boolean
        Public PictureBox As PictureBox
        Public IncludeBtn As Button
        Public ExcludeBtn As Button
        Public ImagePath As String
    End Class

    Private Class Evaluation
        Public RankTitle As String
        Public RankGlyph As String
        Public HonorScore As Integer
        Public Flavor As String
    End Class

    Private people As New List(Of Person)
    Private selectedPeople As New List(Of Person)
    Private learnedClues As New List(Of String)
    Private elapsedSeconds As Integer = 0
    Private gameStarted As Boolean = False
    Private gameEnded As Boolean = False
    Private rng As New Random()
    Private lastEval As Evaluation = Nothing
    Private currentViewing As Person = Nothing

    ' ===== DIFFICULTY =====
    Private ShowHints As Boolean = True
    Private btnEasy As Button
    Private btnHard As Button

    ' ===== FORM LOAD =====
    Private Sub TheReunionGame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "The Reunion at Blackwood Keep"
        Me.ClientSize = New Size(1420, 930)
        Me.BackColor = Night
        Me.StartPosition = FormStartPosition.Manual        ' <- change to Manual
        Me.DoubleBuffered = True
        Me.Font = New Font("Georgia", 10)

        ' Center it manually on the primary screen's working area
        Dim wa As Rectangle = Screen.PrimaryScreen.WorkingArea
        Me.Location = New Point(
            Math.Max(0, wa.X + (wa.Width - Me.Width) \ 2),
            Math.Max(0, wa.Y + (wa.Height - Me.Height) \ 2))

        BuildUI()
        NewGame()

        GameTimer.Interval = 1000
        GameTimer.Enabled = False
    End Sub

    ' ===== BACKGROUND — candle-lit hall =====
    Private Sub TheReunionGame_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        ' Deep gradient background
        Using br As New LinearGradientBrush(Me.ClientRectangle,
                                            Night, NightDeep, 90)
            g.FillRectangle(br, Me.ClientRectangle)
        End Using

        ' Warm candle glow from top center
        Dim glowRect As New Rectangle(Me.ClientSize.Width \ 2 - 400, -200, 800, 700)
        Using gp As New GraphicsPath()
            gp.AddEllipse(glowRect)
            Using pgb As New PathGradientBrush(gp)
                pgb.CenterColor = Color.FromArgb(90, 220, 160, 70)
                pgb.SurroundColors = New Color() {Color.FromArgb(0, 220, 160, 70)}
                g.FillPath(pgb, gp)
            End Using
        End Using

        ' Faint stone-arch pattern lines
        Using p As New Pen(Color.FromArgb(14, 200, 170, 120), 2)
            For x As Integer = -200 To Me.ClientSize.Width + 200 Step 160
                g.DrawArc(p, New Rectangle(x, 100, 200, 400), 180, 180)
            Next
        End Using
    End Sub

    ' ===== BUILD UI =====
    Private Sub BuildUI()
        ' --- TITLE BANNER ---
        Dim banner As New Panel()
        banner.Size = New Size(1240, 92)
        banner.Location = New Point(20, 12)
        banner.BackColor = Color.Transparent
        AddHandler banner.Paint, AddressOf Banner_Paint
        Me.Controls.Add(banner)

        lblTitle = New Label()
        lblTitle.Text = "The Reunion at Blackwood Keep"
        lblTitle.Font = New Font("Georgia", 26, FontStyle.Bold Or FontStyle.Italic)
        lblTitle.ForeColor = Candlelight
        lblTitle.BackColor = Color.Transparent
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(30, 12)
        banner.Controls.Add(lblTitle)

        lblSubtitle = New Label()
        lblSubtitle.Text = "— An evening of riddles, oaths, and old friends —"
        lblSubtitle.Font = New Font("Georgia", 10, FontStyle.Italic)
        lblSubtitle.ForeColor = GoldDim
        lblSubtitle.BackColor = Color.Transparent
        lblSubtitle.AutoSize = True
        lblSubtitle.Location = New Point(34, 60)
        banner.Controls.Add(lblSubtitle)

        lblTime = New Label()
        lblTime.Text = "Candles: 00:00"
        lblTime.Font = New Font("Georgia", 14, FontStyle.Bold)
        lblTime.ForeColor = Candlelight
        lblTime.BackColor = Color.Transparent
        lblTime.AutoSize = True
        lblTime.Location = New Point(1030, 30)
        banner.Controls.Add(lblTime)

        ' --- STATUS STRIP ---
        lblStatus = New Label()
        lblStatus.Text = "Press ENTER THE KEEP to begin."
        lblStatus.Font = New Font("Georgia", 11, FontStyle.Italic)
        lblStatus.ForeColor = ParchmentShade
        lblStatus.BackColor = Color.Transparent
        lblStatus.AutoSize = False
        lblStatus.Size = New Size(1240, 26)
        lblStatus.Location = New Point(20, 136)
        Me.Controls.Add(lblStatus)

        ' --- CHRONICLE (right side) ---
        pnlChronicle = New Panel()
        pnlChronicle.Size = New Size(400, 240)
        pnlChronicle.Location = New Point(30, 610)
        pnlChronicle.BackColor = Parchment
        AddHandler pnlChronicle.Paint, AddressOf Chronicle_Paint
        Me.Controls.Add(pnlChronicle)

        lblChronicleHeader = New Label()
        lblChronicleHeader.Text = "THE  CHRONICLE"
        lblChronicleHeader.Font = New Font("Georgia", 12, FontStyle.Bold)
        lblChronicleHeader.ForeColor = Crimson
        lblChronicleHeader.BackColor = Color.Transparent
        lblChronicleHeader.AutoSize = False
        lblChronicleHeader.Size = New Size(380, 26)
        lblChronicleHeader.Location = New Point(10, 8)
        lblChronicleHeader.TextAlign = ContentAlignment.MiddleCenter
        pnlChronicle.Controls.Add(lblChronicleHeader)

        lblNotes = New TextBox()
        lblNotes.Multiline = True
        lblNotes.ReadOnly = True
        lblNotes.ScrollBars = ScrollBars.Vertical
        lblNotes.WordWrap = True
        lblNotes.Font = New Font("Georgia", 9)
        lblNotes.ForeColor = Ink
        lblNotes.BackColor = Color.FromArgb(226, 212, 180)   ' slightly darker parchment
        lblNotes.BorderStyle = BorderStyle.FixedSingle
        lblNotes.Size = New Size(380, 190)
        lblNotes.Location = New Point(10, 40)
        pnlChronicle.Controls.Add(lblNotes)

        ' --- DIALOGUE PANEL (below portraits) ---
        pnlDialogue = New Panel()
        pnlDialogue.Size = New Size(950, 240)
        pnlDialogue.Location = New Point(440, 610)
        pnlDialogue.BackColor = Parchment
        AddHandler pnlDialogue.Paint, AddressOf DialoguePanel_Paint
        Me.Controls.Add(pnlDialogue)

        txtDialogue = New TextBox()
        txtDialogue.Multiline = True
        txtDialogue.ReadOnly = True
        txtDialogue.ScrollBars = ScrollBars.Vertical
        txtDialogue.Font = New Font("Georgia", 10)
        txtDialogue.ForeColor = Ink
        txtDialogue.BackColor = Parchment
        txtDialogue.BorderStyle = BorderStyle.None
        txtDialogue.Size = New Size(910, 200)
        txtDialogue.Location = New Point(20, 20)
        pnlDialogue.Controls.Add(txtDialogue)

        ' --- DIFFICULTY SELECTOR ---
        Dim lblDifficulty As New Label()
        lblDifficulty.Text = "Difficulty:"
        lblDifficulty.Font = New Font("Georgia", 10, FontStyle.Bold)
        lblDifficulty.ForeColor = ParchmentShade
        lblDifficulty.BackColor = Color.Transparent
        lblDifficulty.AutoSize = True
        lblDifficulty.Location = New Point(620, 111)     ' same Y as buttons (aligned vertically)
        Me.Controls.Add(lblDifficulty)

        btnEasy = New Button()
        btnEasy.Text = "EASY  (with clues)"
        btnEasy.Font = New Font("Georgia", 9, FontStyle.Bold)
        btnEasy.Size = New Size(150, 26)
        btnEasy.Location = New Point(730, 108)           ' shifted right, same Y
        btnEasy.BackColor = Color.FromArgb(60, 100, 70)
        btnEasy.ForeColor = Candlelight
        btnEasy.FlatStyle = FlatStyle.Flat
        btnEasy.FlatAppearance.BorderColor = Gold
        btnEasy.FlatAppearance.BorderSize = 1
        btnEasy.Cursor = Cursors.Hand
        AddHandler btnEasy.Click, AddressOf btnEasy_Click
        Me.Controls.Add(btnEasy)

        btnHard = New Button()
        btnHard.Text = "HARD  (no clues)"
        btnHard.Font = New Font("Georgia", 9, FontStyle.Bold)
        btnHard.Size = New Size(150, 26)
        btnHard.Location = New Point(890, 108)           ' was 865, 104
        btnHard.BackColor = Color.FromArgb(60, 50, 70)
        btnHard.ForeColor = Candlelight
        btnHard.FlatStyle = FlatStyle.Flat
        btnHard.FlatAppearance.BorderColor = Gold
        btnHard.FlatAppearance.BorderSize = 1
        btnHard.Cursor = Cursors.Hand
        AddHandler btnHard.Click, AddressOf btnHard_Click
        Me.Controls.Add(btnHard)
        lblDifficulty.BringToFront()

        UpdateDifficultyButtons()

        ' --- BUTTONS ---
        btnStart = MakeOrnateButton("ENTER THE KEEP", New Point(30, 860), New Size(190, 40), Wood)
        AddHandler btnStart.Click, AddressOf btnStart_Click
        Me.Controls.Add(btnStart)

        btnConfirm = MakeOrnateButton("SEAL THE BAND (0 chosen)", New Point(230, 860), New Size(260, 40), Crimson)
        btnConfirm.Enabled = False
        AddHandler btnConfirm.Click, AddressOf btnConfirm_Click
        Me.Controls.Add(btnConfirm)

        btnReset = MakeOrnateButton("CHOOSE AGAIN", New Point(510, 860), New Size(180, 40), Color.FromArgb(60, 50, 70))
        AddHandler btnReset.Click, AddressOf btnReset_Click
        Me.Controls.Add(btnReset)

        btnPlayAgain = MakeOrnateButton("BEGIN ANEW", New Point(230, 860), New Size(260, 40),
                                        Color.FromArgb(80, 100, 140))
        btnPlayAgain.Visible = False
        AddHandler btnPlayAgain.Click, AddressOf btnPlayAgain_Click
        Me.Controls.Add(btnPlayAgain)

        ' --- SEAL ---
        sealPic = New PictureBox()
        sealPic.Size = New Size(220, 220)
        sealPic.Location = New Point(1130, 650)
        sealPic.BackColor = Color.Transparent
        sealPic.Visible = False
        AddHandler sealPic.Paint, AddressOf Seal_Paint
        Me.Controls.Add(sealPic)
        sealPic.BringToFront()
    End Sub

    Private Function MakeOrnateButton(text As String, loc As Point, sz As Size, baseColor As Color) As Button
        Dim b As New Button()
        b.Text = text
        b.Font = New Font("Georgia", 10, FontStyle.Bold)
        b.Size = sz
        b.Location = loc
        b.BackColor = baseColor
        b.ForeColor = Candlelight
        b.FlatStyle = FlatStyle.Flat
        b.FlatAppearance.BorderColor = Gold
        b.FlatAppearance.BorderSize = 1
        b.Cursor = Cursors.Hand
        Return b
    End Function

    Private Sub btnEasy_Click(sender As Object, e As EventArgs)
        ShowHints = True
        UpdateDifficultyButtons()
        RefreshNotes()   ' <- repopulate the Chronicle
        lblStatus.Text = "Difficulty set to EASY — clues will appear after each story."
        If currentViewing IsNot Nothing Then
            txtDialogue.Text = currentViewing.Story & vbCrLf & vbCrLf &
                "— WHAT YOU NOTICE —" & vbCrLf & currentViewing.Hint
        End If
    End Sub

    Private Sub btnHard_Click(sender As Object, e As EventArgs)
        ShowHints = False
        UpdateDifficultyButtons()
        RefreshNotes()   ' <- clears the Chronicle
        lblStatus.Text = "Difficulty set to HARD — no clues. Rely on your memory."
        If currentViewing IsNot Nothing Then
            txtDialogue.Text = currentViewing.Story & vbCrLf & vbCrLf &
                "— HARD MODE —" & vbCrLf &
                "No clues here. You must remember every tale yourself."
        End If
    End Sub

    Private Sub UpdateDifficultyButtons()
        If btnEasy Is Nothing OrElse btnHard Is Nothing Then Return
        If ShowHints Then
            btnEasy.BackColor = Color.FromArgb(90, 150, 100)     ' bright
            btnHard.BackColor = Color.FromArgb(60, 50, 70)       ' dim
            btnEasy.FlatAppearance.BorderColor = Candlelight
            btnHard.FlatAppearance.BorderColor = GoldDim
        Else
            btnEasy.BackColor = Color.FromArgb(60, 50, 70)       ' dim
            btnHard.BackColor = Color.FromArgb(140, 60, 70)      ' bright
            btnEasy.FlatAppearance.BorderColor = GoldDim
            btnHard.FlatAppearance.BorderColor = Candlelight
        End If
    End Sub

    ' ===== DECORATIVE PAINT HANDLERS =====
    Private Sub Banner_Paint(sender As Object, e As PaintEventArgs)
        Dim p As Panel = CType(sender, Panel)
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Using br As New LinearGradientBrush(p.ClientRectangle,
                                            Color.FromArgb(60, 40, 25),
                                            Color.FromArgb(30, 20, 14), 90)
            g.FillRectangle(br, p.ClientRectangle)
        End Using

        ' Gold top/bottom rules
        Using pen As New Pen(Gold, 2)
            g.DrawLine(pen, 8, 4, p.Width - 8, 4)
            g.DrawLine(pen, 8, p.Height - 5, p.Width - 8, p.Height - 5)
        End Using

        ' Corner diamonds
        For Each pt As Point In {New Point(12, 12), New Point(p.Width - 18, 12),
                                  New Point(12, p.Height - 18), New Point(p.Width - 18, p.Height - 18)}
            Dim dia() As Point = {New Point(pt.X + 5, pt.Y), New Point(pt.X + 10, pt.Y + 5),
                                  New Point(pt.X + 5, pt.Y + 10), New Point(pt.X, pt.Y + 5)}
            g.FillPolygon(New SolidBrush(Gold), dia)
        Next
    End Sub

    Private Sub Chronicle_Paint(sender As Object, e As PaintEventArgs)
        Dim p As Panel = CType(sender, Panel)
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        ' Parchment gradient
        Using br As New LinearGradientBrush(p.ClientRectangle,
                                            Color.FromArgb(240, 228, 200),
                                            Color.FromArgb(210, 192, 158), 90)
            g.FillRectangle(br, p.ClientRectangle)
        End Using

        ' Aged blotches
        Dim rr As New Random(4)
        For i As Integer = 0 To 30
            Dim x = rr.Next(0, p.Width)
            Dim y = rr.Next(0, p.Height)
            Dim w = rr.Next(10, 40)
            Using b As New SolidBrush(Color.FromArgb(8, 120, 90, 60))
                g.FillEllipse(b, x, y, w, w \ 2)
            End Using
        Next

        ' Ornate border
        Using pen As New Pen(Gold, 2)
            g.DrawRectangle(pen, 3, 3, p.Width - 7, p.Height - 7)
        End Using
        Using pen As New Pen(GoldDim, 1)
            g.DrawRectangle(pen, 8, 8, p.Width - 17, p.Height - 17)
        End Using

        ' Divider under header
        Using pen As New Pen(Crimson, 1)
            g.DrawLine(pen, 20, 44, p.Width - 20, 44)
        End Using
    End Sub

    Private Sub DialoguePanel_Paint(sender As Object, e As PaintEventArgs)
        Dim p As Panel = CType(sender, Panel)
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Using br As New LinearGradientBrush(p.ClientRectangle,
                                            Color.FromArgb(238, 226, 198),
                                            Color.FromArgb(212, 196, 162), 90)
            g.FillRectangle(br, p.ClientRectangle)
        End Using

        Using pen As New Pen(Gold, 2)
            g.DrawRectangle(pen, 3, 3, p.Width - 7, p.Height - 7)
        End Using
        Using pen As New Pen(GoldDim, 1)
            g.DrawRectangle(pen, 9, 9, p.Width - 19, p.Height - 19)
        End Using

        ' Quill icon top-left
        Using f As New Font("Georgia", 11, FontStyle.Italic)
            g.DrawString("✒", f, New SolidBrush(Ink), 14, 6)
        End Using
    End Sub

    Private Sub BuildPeople()
        Dim pool() As Color = {
            Color.FromArgb(140, 120, 90),
            Color.FromArgb(100, 110, 90),
            Color.FromArgb(120, 100, 110),
            Color.FromArgb(90, 100, 120),
            Color.FromArgb(150, 130, 90)
        }

        ' ===== TRUE BAND — all details line up =====

        people.Add(New Person() With {
            .Name = "Maya", .Title = "of the North Tower", .IsFake = False, .GroupId = 1,
            .CordColor = pool(rng.Next(pool.Length)), .IsWorn = True, .ImagePath = FindImage(1),
            .Story = "Maya: 'That Great Storm — three nights without a candle. Mother Alma kept us " &
                     "at her cottage by the well till it passed.'",
            .Hint = "She says the storm lasted three nights, and Mother Alma's cottage is by the well."
        })

        people.Add(New Person() With {
            .Name = "Ethan", .Title = "of the Broken Shield", .IsFake = False, .GroupId = 1,
            .CordColor = pool(rng.Next(pool.Length)), .IsWorn = True, .ImagePath = FindImage(2),
            .Story = "Ethan: 'I still carry my half of the oath-cord. We split it with my dagger behind " &
                     "the keep wall. Under the oak, our five initials — M.E.L.N.R.'",
            .Hint = "The oath-cord, split with a dagger. Five initials under the oak."
        })

        people.Add(New Person() With {
            .Name = "Lila", .Title = "of the Quiet Vale", .IsFake = False, .GroupId = 1,
            .CordColor = pool(rng.Next(pool.Length)), .IsWorn = True, .ImagePath = FindImage(3),
            .Story = "Lila: 'Mother Alma passed twelve winters ago. I rode back for her rites. She kept " &
                     "an iron chest at the cottage — the one we were never meant to see.'",
            .Hint = "Twelve winters since Mother Alma passed. An iron chest at the cottage."
        })

        people.Add(New Person() With {
            .Name = "Noah", .Title = "of the Long Road", .IsFake = False, .GroupId = 1,
            .CordColor = pool(rng.Next(pool.Length)), .IsWorn = True, .ImagePath = FindImage(4),
            .Story = "Noah: 'The iron chest — buried under the oak, not beside it. We swore to open it " &
                     "in twenty years. Maya drew the map.'",
            .Hint = "The chest is UNDER the oak. He names Maya."
        })

        people.Add(New Person() With {
            .Name = "Ruby", .Title = "of the Red Hand", .IsFake = False, .GroupId = 1,
            .CordColor = pool(rng.Next(pool.Length)), .IsWorn = True, .ImagePath = FindImage(5),
            .Story = "Ruby: 'I cut my palm carving the initials into the oak — M.E.L.N.R., all five of " &
                     "them. Ethan held the lantern. Mother Alma bound it with a strip of linen.'",
            .Hint = "Five initials. Ethan held the lantern. Mother Alma bound the wound."
        })

        ' ===== IMPOSTORS — same world, wrong details =====

        people.Add(New Person() With {
            .Name = "Julian", .Title = "the Wanderer", .IsFake = True, .GroupId = 100,
            .CordColor = pool(rng.Next(pool.Length)), .IsWorn = False, .ImagePath = FindImage(6),
            .Story = "Julian: 'The time capsule we buried beside the oak — Ethan held the shovel, don't " &
                     "you remember? And Mother Alma brought us honey cakes from her cottage by the mill.'",
            .Hint = "He says the capsule is BESIDE the oak, and Mother Alma's cottage is by the MILL."
        })

        people.Add(New Person() With {
            .Name = "Sable", .Title = "the Silent", .IsFake = True, .GroupId = 100,
            .CordColor = pool(rng.Next(pool.Length)), .IsWorn = False, .ImagePath = FindImage(7),
            .Story = "Sable: 'That storm — four nights without a flame. Mother Alma passed ten winters " &
                     "ago; I lit a candle for her at the cottage by the well.'",
            .Hint = "She says the storm lasted FOUR nights, and Mother Alma passed TEN winters ago."
        })
    End Sub

    Private Function FindImage(n As Integer) As String
        Dim bases() As String = {
            Path.Combine(Application.StartupPath, "Images"),
            Path.Combine(Application.StartupPath, "..\..\Images"),
            Path.Combine(Application.StartupPath, "..\..\..\Images")
        }
        Dim exts() As String = {".jpg", ".png", ".jpeg", ".bmp"}
        For Each b In bases
            For Each x In exts
                Dim full = Path.Combine(b, n.ToString() & x)
                If File.Exists(full) Then Return full
            Next
        Next
        Return ""
    End Function

    ' ===== LAYOUT PEOPLE (portraits grid) =====
    Private Sub LayoutPeople()
        ' Single row of 7 portraits. Form is 1420 wide.
        Dim startX As Integer = 30
        Dim gap As Integer = 170
        Dim topY As Integer = 180

        For i As Integer = 0 To 6
            Dim x As Integer = startX + i * gap

            Dim pb As New PictureBox()
            pb.Size = New Size(160, 160)
            pb.Location = New Point(x, topY)
            pb.BackColor = Color.FromArgb(50, 40, 55)
            pb.SizeMode = PictureBoxSizeMode.Zoom
            pb.Tag = i
            pb.Cursor = Cursors.Hand
            pb.Enabled = False
            AddHandler pb.Click, AddressOf Person_Click
            AddHandler pb.Paint, AddressOf Person_Paint
            Me.Controls.Add(pb)

            Dim incBtn As New Button()
            incBtn.Text = "⊕ INCLUDE"
            incBtn.Font = New Font("Georgia", 8, FontStyle.Bold)
            incBtn.Size = New Size(76, 24)
            incBtn.Location = New Point(x, topY + 164)
            incBtn.BackColor = Color.FromArgb(60, 100, 70)
            incBtn.ForeColor = Candlelight
            incBtn.FlatStyle = FlatStyle.Flat
            incBtn.FlatAppearance.BorderColor = Gold
            incBtn.FlatAppearance.BorderSize = 1
            incBtn.Cursor = Cursors.Hand
            incBtn.Visible = False
            incBtn.Tag = i
            AddHandler incBtn.Click, AddressOf IncludeBtn_Click
            Me.Controls.Add(incBtn)

            Dim excBtn As New Button()
            excBtn.Text = "⊖ EXCLUDE"
            excBtn.Font = New Font("Georgia", 8, FontStyle.Bold)
            excBtn.Size = New Size(76, 24)
            excBtn.Location = New Point(x + 80, topY + 164)
            excBtn.BackColor = Color.FromArgb(110, 50, 50)
            excBtn.ForeColor = Candlelight
            excBtn.FlatStyle = FlatStyle.Flat
            excBtn.FlatAppearance.BorderColor = Gold
            excBtn.FlatAppearance.BorderSize = 1
            excBtn.Cursor = Cursors.Hand
            excBtn.Visible = False
            excBtn.Tag = i
            AddHandler excBtn.Click, AddressOf ExcludeBtn_Click
            Me.Controls.Add(excBtn)

            If i < people.Count Then
                people(i).PictureBox = pb
                people(i).IncludeBtn = incBtn
                people(i).ExcludeBtn = excBtn
            Else
                Dim p As New Person()
                p.Name = ""
                p.PictureBox = pb
                p.IncludeBtn = incBtn
                p.ExcludeBtn = excBtn
                p.CordColor = Color.Gray
                people.Add(p)
            End If
        Next
    End Sub

    ' ===== NEW GAME =====
    Private Sub NewGame()
        ' --- Clear state ---
        people.Clear()
        selectedPeople.Clear()
        learnedClues.Clear()
        elapsedSeconds = 0
        gameStarted = False
        gameEnded = False
        lastEval = Nothing
        currentViewing = Nothing
        btnEasy.Enabled = True
        btnHard.Enabled = True

        ' --- Remove any existing portrait / include / exclude controls ---
        Dim toRemove As New List(Of Control)
        For Each c As Control In Me.Controls
            If TypeOf c Is PictureBox AndAlso c IsNot sealPic Then
                toRemove.Add(c)
            ElseIf TypeOf c Is Button Then
                Dim b As Button = CType(c, Button)
                If b.Text.Contains("INCLUDE") OrElse b.Text.Contains("EXCLUDE") Then
                    toRemove.Add(c)
                End If
            End If
        Next
        For Each c In toRemove
            Me.Controls.Remove(c)
            c.Dispose()
        Next

        ' --- Reset UI ---
        lblTime.Text = "Candles: 00:00"
        lblStatus.Text = "Press ENTER THE KEEP to begin."
        lblNotes.Text = "will be set correctly by RefreshNotes below"
        txtDialogue.Text = "The gate of Blackwood Keep stands before you..." & vbCrLf & vbCrLf &
            "Tip: Ask each person what they remember of the old days. " &
            "The true band shares one set of memories — the impostors share another."

        btnStart.Enabled = True
        btnStart.Visible = True
        btnConfirm.Enabled = False
        btnConfirm.Visible = True
        btnConfirm.Text = "SEAL THE BAND (0 chosen)"
        btnReset.Enabled = True
        btnReset.Visible = True
        btnPlayAgain.Visible = False
        sealPic.Visible = False

        ' --- Build fresh ---
        BuildPeople()       ' fills people list (has Name, Story, Btn refs left as Nothing for now)
        LayoutPeople()      ' creates PictureBoxes + INCLUDE/EXCLUDE buttons, adds Person entries with refs
        AssignPeopleToPictureBoxes()
        RefreshPictureBoxes()
        UpdateDifficultyButtons()
        RefreshNotes()
    End Sub



    Private Sub AssignPeopleToPictureBoxes()
        Dim boxes = Me.Controls.OfType(Of PictureBox)().
            Where(Function(pb) pb IsNot sealPic).
            OrderBy(Function(pb) CInt(pb.Tag)).ToList()
        For i As Integer = 0 To Math.Min(6, people.Count - 1)
            people(i).PictureBox = boxes(i)
        Next
    End Sub

    Private Sub RefreshPictureBoxes()
        For Each p In people
            If p.PictureBox IsNot Nothing Then p.PictureBox.Invalidate()
        Next
    End Sub

    ' ===== DRAW PORTRAIT =====
    Private Sub Person_Paint(sender As Object, e As PaintEventArgs)
        Dim pb As PictureBox = CType(sender, PictureBox)
        Dim idx As Integer = CInt(pb.Tag)
        If idx >= people.Count Then Return
        Dim p As Person = people(idx)
        If p.PictureBox Is Nothing Then Return

        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.InterpolationMode = InterpolationMode.HighQualityBicubic
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        ' Ornate frame background
        Using br As New LinearGradientBrush(New Rectangle(0, 0, pb.Width, pb.Height),
                                            Color.FromArgb(90, 65, 40), Color.FromArgb(40, 28, 18), 90)
            g.FillRectangle(br, New Rectangle(0, 0, pb.Width, pb.Height))
        End Using

        ' Portrait inner area
        Dim portraitRect As New Rectangle(10, 10, pb.Width - 20, pb.Height - 40)

        Dim loaded As Boolean = False
        If p.ImagePath <> "" AndAlso File.Exists(p.ImagePath) Then
            Try
                Using img As Image = Image.FromFile(p.ImagePath)
                    Dim srcRatio = img.Width / img.Height
                    Dim dstRatio = portraitRect.Width / portraitRect.Height
                    Dim srcRect As Rectangle
                    If srcRatio > dstRatio Then
                        Dim newW = CInt(img.Height * dstRatio)
                        srcRect = New Rectangle((img.Width - newW) \ 2, 0, newW, img.Height)
                    Else
                        Dim newH = CInt(img.Width / dstRatio)
                        srcRect = New Rectangle(0, (img.Height - newH) \ 2, img.Width, newH)
                    End If
                    g.DrawImage(img, portraitRect, srcRect, GraphicsUnit.Pixel)
                    loaded = True
                End Using
            Catch
                loaded = False
            End Try
        End If

        If Not loaded Then
            Using br As New SolidBrush(Color.FromArgb(40, 30, 50))
                g.FillRectangle(br, portraitRect)
            End Using
            Using br As New SolidBrush(Color.FromArgb(18, 12, 22))
                Dim cx = portraitRect.X + portraitRect.Width \ 2
                Dim cy = portraitRect.Y + portraitRect.Height \ 2
                g.FillEllipse(br, cx - 26, cy - 45, 52, 52)
                g.FillEllipse(br, cx - 40, cy + 6, 80, 80)
            End Using
            Using f As New Font("Georgia", 8, FontStyle.Italic)
                g.DrawString("portrait awaits", f, New SolidBrush(Color.FromArgb(120, 100, 80)),
                             portraitRect.X + 8, portraitRect.Y + 6)
            End Using
        End If

        ' Vignette
        Using br As New LinearGradientBrush(portraitRect,
                                            Color.FromArgb(0, 0, 0, 0),
                                            Color.FromArgb(160, 0, 0, 0),
                                            LinearGradientMode.Vertical)
            g.FillRectangle(br, portraitRect)
        End Using

        ' Gold inner frame
        g.DrawRectangle(New Pen(GoldDim, 1), portraitRect)

        ' Highlight if currently viewing
        If currentViewing Is p Then
            g.DrawRectangle(New Pen(Candlelight, 3), New Rectangle(6, 6, pb.Width - 13, pb.Height - 13))
        End If

        ' Name plate at bottom
        If p.Name <> "" Then
            Using f As New Font("Georgia", 10, FontStyle.Bold)
                Dim sz = g.MeasureString(p.Name, f)
                g.FillRectangle(New SolidBrush(Color.FromArgb(210, 30, 20, 15)),
                                0, pb.Height - 30, pb.Width, 30)
                g.DrawString(p.Name, f, New SolidBrush(Candlelight),
                             (pb.Width - sz.Width) / 2, pb.Height - 27)
            End Using
        End If

        ' Selected seal in top-right
        If selectedPeople.Contains(p) Then
            Dim sealRect As New Rectangle(pb.Width - 28, 14, 22, 22)
            g.FillEllipse(New SolidBrush(Gold), sealRect)
            g.DrawEllipse(New Pen(Color.FromArgb(90, 60, 20), 1), sealRect)
            Using f As New Font("Georgia", 10, FontStyle.Bold)
                g.DrawString("✓", f, New SolidBrush(Ink), sealRect.X + 4, sealRect.Y + 1)
            End Using
        End If
    End Sub

    ' ===== PERSON CLICKED — SHOW BACKSTORY =====
    Private Sub Person_Click(sender As Object, e As EventArgs)
        If Not gameStarted OrElse gameEnded Then Return

        Dim pb As PictureBox = CType(sender, PictureBox)
        Dim p As Person = people(CInt(pb.Tag))

        currentViewing = p
        p.WasClicked = True

        ' Always show story — no more toggling!
        If ShowHints Then
            txtDialogue.Text = p.Story & vbCrLf & vbCrLf & "— WHAT YOU NOTICE —" & vbCrLf & p.Hint
        Else
            txtDialogue.Text = p.Story & vbCrLf & vbCrLf &
                "— HARD MODE —" & vbCrLf &
                "No clues here, and the Chronicle stays blank. Remember the tales yourself."
        End If
        txtDialogue.SelectionStart = 0
        txtDialogue.ScrollToCaret()

        lblStatus.Text = "You spoke with " & p.Name & ". Use INCLUDE or EXCLUDE below their portrait."

        ' Show include/exclude buttons for this person
        If p.IncludeBtn IsNot Nothing Then p.IncludeBtn.Visible = True
        If p.ExcludeBtn IsNot Nothing Then p.ExcludeBtn.Visible = True

        ' Record note
        Dim note As String = "• " & p.Name & ":" & vbCrLf & ExtractKeyClue(p.Story)
        Dim stripped As String = note.Replace(vbCrLf, " ").Replace("  ", " ").Trim()
        If Not learnedClues.Any(Function(x) x.Replace(vbCrLf, " ").Replace("  ", " ").Trim() = stripped) Then
            learnedClues.Add(note)
        End If
        RefreshNotes()

        RefreshPictureBoxes()
    End Sub

    Private Sub IncludeBtn_Click(sender As Object, e As EventArgs)
        If Not gameStarted OrElse gameEnded Then Return
        Dim idx As Integer = CInt(CType(sender, Button).Tag)
        Dim p As Person = people(idx)
        If Not selectedPeople.Contains(p) Then selectedPeople.Add(p)
        UpdateConfirmButton()
        RefreshPictureBoxes()
        lblStatus.Text = p.Name & " has been INCLUDED in the band."
    End Sub

    Private Sub ExcludeBtn_Click(sender As Object, e As EventArgs)
        If Not gameStarted OrElse gameEnded Then Return
        Dim idx As Integer = CInt(CType(sender, Button).Tag)
        Dim p As Person = people(idx)
        selectedPeople.Remove(p)
        UpdateConfirmButton()
        RefreshPictureBoxes()
        lblStatus.Text = p.Name & " has been EXCLUDED from the band."
    End Sub

    Private Function ExtractKeyClue(story As String) As String
        Dim s As String = story.ToLower()
        Dim sb As New System.Text.StringBuilder()

        ' ---- Locations mentioned ----
        If s.Contains("keep wall") Then sb.AppendLine("   place: keep wall")
        If s.Contains("under the oak") Then sb.AppendLine("   chest: UNDER the oak")
        If s.Contains("beside the oak") Then sb.AppendLine("   chest: BESIDE the oak")
        If s.Contains("cottage by the well") Then sb.AppendLine("   cottage: by the WELL")
        If s.Contains("cottage by the mill") Then sb.AppendLine("   cottage: by the MILL")

        ' ---- Numbers ----
        If s.Contains("three nights") Then sb.AppendLine("   storm: THREE nights")
        If s.Contains("four nights") Then sb.AppendLine("   storm: FOUR nights")
        If s.Contains("twelve winters") Then sb.AppendLine("   Alma: TWELVE winters ago")
        If s.Contains("ten winters") Then sb.AppendLine("   Alma: TEN winters ago")

        ' ---- Named people ----
        Dim names As New List(Of String)
        If s.Contains("mother alma") Then names.Add("Mother Alma")
        If s.Contains("ethan") Then names.Add("Ethan")
        If s.Contains("maya") Then names.Add("Maya")
        If s.Contains("noah") Then names.Add("Noah")
        If names.Count > 0 Then sb.AppendLine("   names: " & String.Join(", ", names))

        ' ---- Items ----
        Dim items As New List(Of String)
        If s.Contains("oath-cord") Then items.Add("oath-cord")
        If s.Contains("dagger") Then items.Add("dagger")
        If s.Contains("m.e.l.n.r") Then items.Add("5 initials")
        If s.Contains("iron chest") Then items.Add("iron chest")
        If s.Contains("scar") OrElse s.Contains("cut my palm") Then items.Add("Ruby's scar")
        If items.Count > 0 Then sb.AppendLine("   item: " & String.Join(", ", items))

        If sb.Length = 0 Then Return "   an unclear memory"
        Return sb.ToString().TrimEnd()
    End Function

    Private Sub RefreshNotes()
        If Not ShowHints Then
            lblNotes.Text = "(HARD MODE)" & vbCrLf & vbCrLf &
                "The Chronicle stays blank on Hard mode — you must remember the tales yourself." & vbCrLf & vbCrLf &
                "Switch to Easy to see recorded clues."
            Return
        End If

        If learnedClues.Count = 0 Then
            lblNotes.Text = "(nothing recorded yet)"
            Return
        End If

        Dim sb As New System.Text.StringBuilder()
        For Each n In learnedClues
            sb.AppendLine(n)
            sb.AppendLine()
        Next
        lblNotes.Text = sb.ToString()
    End Sub

    Private Sub UpdateConfirmButton()
        btnConfirm.Text = "SEAL THE BAND (" & selectedPeople.Count & " chosen)"
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs)
        If gameStarted Then Return
        gameStarted = True
        btnEasy.Enabled = False
        btnHard.Enabled = False
        elapsedSeconds = 0
        GameTimer.Enabled = True

        For Each p In people
            p.PictureBox.Enabled = True
        Next

        btnStart.Enabled = False
        btnConfirm.Enabled = True

        txtDialogue.Text = "THE STORY" & vbCrLf &
            "──────────────────────────────────────────────" & vbCrLf &
            "After twenty years, you return to Blackwood Keep. Seven stand at the gate, " &
            "each claiming to be of your sworn childhood band." & vbCrLf & vbCrLf &
            "You remember the band. You do not remember every face." & vbCrLf & vbCrLf &
            "Two of them are impostors. Their stories will SOUND right — the names, " &
            "the places, the people. But small details won't match what the others say." & vbCrLf & vbCrLf &
            "» Listen for numbers, places, and directions that don't line up." & vbCrLf &
            "» Compare in THE CHRONICLE." & vbCrLf &
            "» When ready, SEAL THE BAND."

        If ShowHints Then
            txtDialogue.AppendText(vbCrLf & "Difficulty: EASY — after each person speaks, " &
                "a hint will reveal what to notice.")
        Else
            txtDialogue.AppendText(vbCrLf & "Difficulty: HARD — no hints. Read the stories carefully " &
                "and compare specific details (numbers, places, directions) in THE CHRONICLE.")
        End If

        lblStatus.Text = "Click each person to hear their tale. Compare the small details."
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs)
        If Not gameStarted OrElse gameEnded Then Return
        selectedPeople.Clear()
        For Each p In people
            If p.PictureBox IsNot Nothing Then p.PictureBox.Invalidate()
        Next
        UpdateConfirmButton()
        lblStatus.Text = "Your choice is cleared. Click the people to rebuild your band."
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs)
        If selectedPeople.Count = 0 Then
            txtDialogue.Text = "You have chosen no one. Speak with the people, then choose your band."
            Return
        End If

        Dim fakesIncluded = selectedPeople.Where(Function(p) p.IsFake).ToList()
        Dim realsIncluded = selectedPeople.Where(Function(p) Not p.IsFake).ToList()
        Dim totalReals = people.Where(Function(p) Not p.IsFake).Count()

        If fakesIncluded.Count > 0 Then
            gameEnded = True
            GameTimer.Enabled = False
            Dim fakeNames = String.Join(", ", fakesIncluded.Select(Function(p) p.Name))
            Dim ev = EvaluatePlayer(elapsedSeconds, realsIncluded.Count, totalReals, fakesIncluded.Count)
            lastEval = ev

            Dim betrayals As New List(Of String)
            If fakesIncluded.Any(Function(p) p.Name = "Julian") Then
                betrayals.Add("the chest was under the oak, not beside it — and Mother Alma's cottage stood by the well, not the mill")
            End If
            If fakesIncluded.Any(Function(p) p.Name = "Sable") Then
                betrayals.Add("the storm lasted three nights, not four — and Mother Alma passed twelve winters ago, not ten")
            End If

            txtDialogue.Text = "DEFEAT" & vbCrLf &
                "──────────────────────────────────────────────" & vbCrLf &
                "The gate groans shut behind you. " & fakeNames & " was never of the band — " &
                String.Join("; and ", betrayals) & "." & vbCrLf & vbCrLf &
                "Inside, the fires go out, one by one." & vbCrLf & vbCrLf &
                "Candles burned: " & FormatTime(elapsedSeconds) & "   |   True band found: " &
                realsIncluded.Count & " of " & totalReals & vbCrLf & vbCrLf &
                "RANK:  " & ev.RankGlyph & "  " & ev.RankTitle & vbCrLf &
                "HONOR: " & ev.HonorScore & " / 100" & vbCrLf &
                "— " & ev.Flavor

            lblStatus.Text = "GAME OVER — an impostor entered the keep."
            EndGameUI()
            Return
        End If

        If realsIncluded.Count = totalReals Then
            gameEnded = True
            GameTimer.Enabled = False
            Dim ev = EvaluatePlayer(elapsedSeconds, realsIncluded.Count, totalReals, 0)
            lastEval = ev

            txtDialogue.Text = "VICTORY" & vbCrLf &
                "──────────────────────────────────────────────" & vbCrLf &
                "The true band steps through the gate. The impostors melt into the dark." & vbCrLf & vbCrLf &
                "Within, the hearth is lit. The old tales return, one by one, as they always did." & vbCrLf & vbCrLf &
                "Candles burned: " & FormatTime(elapsedSeconds) & "   |   True band found: " &
                realsIncluded.Count & " of " & totalReals & vbCrLf & vbCrLf &
                "RANK:  " & ev.RankGlyph & "  " & ev.RankTitle & vbCrLf &
                "HONOR: " & ev.HonorScore & " / 100" & vbCrLf &
                "— " & ev.Flavor

            lblStatus.Text = "VICTORY! The true band is reunited."
            EndGameUI()
        Else
            txtDialogue.Text = "You have chosen only honest folk — yet the band feels incomplete." & vbCrLf & vbCrLf &
                "You have found " & realsIncluded.Count & " of the true band." & vbCrLf & vbCrLf &
                "Consult THE CHRONICLE. Someone here shares a memory you have not yet asked about."
            lblStatus.Text = "No impostors yet — but the band is not whole."
        End If
    End Sub

    Private Function EvaluatePlayer(seconds As Integer, found As Integer, total As Integer, fakes As Integer) As Evaluation
        Dim ev As New Evaluation()
        Dim timeBonus As Integer = Math.Max(0, 30 - (seconds \ 4))
        Dim completeness As Integer = CInt((found / Math.Max(1, total)) * 20)
        Dim penalty As Integer = fakes * 20
        ev.HonorScore = Math.Max(0, Math.Min(100, 50 + timeBonus + completeness - penalty))

        If fakes > 0 Then
            ev.RankGlyph = "X"
            ev.RankTitle = "BETRAYER OF THE KEEP"
            ev.Flavor = "You trusted a stranger's tale. The chronicle will remember."
        ElseIf seconds <= 45 AndAlso found = total Then
            ev.RankGlyph = "I"
            ev.RankTitle = "GRANDMASTER OF THE BAND"
            ev.Flavor = "You read them like a chronicler reads a page. Flawless."
        ElseIf seconds <= 90 AndAlso found = total Then
            ev.RankGlyph = "II"
            ev.RankTitle = "SWORN KNIGHT"
            ev.Flavor = "Steady of mind, swift of judgment. Well done."
        ElseIf found = total Then
            ev.RankGlyph = "III"
            ev.RankTitle = "LOYAL COMPANION"
            ev.Flavor = "Slow to trust — but you were right to be careful."
        Else
            ev.RankGlyph = "IV"
            ev.RankTitle = "HONEST FOOL"
            ev.Flavor = "No traitor crossed your threshold. But you left true friends outside."
        End If
        Return ev
    End Function

    Private Sub EndGameUI()
        For Each p In people
            If p.PictureBox IsNot Nothing Then p.PictureBox.Enabled = False
            If p.IncludeBtn IsNot Nothing Then p.IncludeBtn.Visible = False
            If p.ExcludeBtn IsNot Nothing Then p.ExcludeBtn.Visible = False
        Next
        btnConfirm.Visible = False
        btnReset.Visible = False
        btnStart.Visible = False
        btnPlayAgain.Visible = True
        btnPlayAgain.BringToFront()
        sealPic.Visible = True
        sealPic.Invalidate()
    End Sub

    Private Sub btnPlayAgain_Click(sender As Object, e As EventArgs)
        GameTimer.Enabled = False
        NewGame()
    End Sub

    Private Sub Seal_Paint(sender As Object, e As PaintEventArgs)
        If lastEval Is Nothing Then Return

        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        Dim cx As Integer = sealPic.Width \ 2
        Dim cy As Integer = sealPic.Height \ 2
        Dim outerR As Integer = 100
        Dim innerR As Integer = 84

        Dim rr As New Random(13)
        For i As Integer = 0 To 40
            Dim ang = i * Math.PI * 2 / 40
            Dim dr = outerR + rr.Next(-4, 6)
            Dim x = cx + CInt(Math.Cos(ang) * dr)
            Dim y = cy + CInt(Math.Sin(ang) * dr)
            Dim rad = rr.Next(3, 8)
            Using br As New SolidBrush(Color.FromArgb(150, 30, 30))
                g.FillEllipse(br, x - rad, y - rad, rad * 2, rad * 2)
            End Using
        Next

        Dim discRect As New Rectangle(cx - outerR, cy - outerR, outerR * 2, outerR * 2)
        Using br As New LinearGradientBrush(discRect,
                                            Color.FromArgb(170, 40, 45),
                                            Color.FromArgb(110, 20, 25), 45)
            g.FillEllipse(br, discRect)
        End Using
        g.DrawEllipse(New Pen(Color.FromArgb(80, 15, 20), 3), discRect)

        Dim innerRect As New Rectangle(cx - innerR, cy - innerR, innerR * 2, innerR * 2)
        g.DrawEllipse(New Pen(Color.FromArgb(220, 200, 150), 2), innerRect)

        Using br As New SolidBrush(Color.FromArgb(40, 255, 220, 160))
            g.FillEllipse(br, cx - innerR + 4, cy - innerR + 4, (innerR - 4) * 2, (innerR - 4) * 2)
        End Using

        Using gf As New Font("Georgia", 40, FontStyle.Bold)
            Dim gsz = g.MeasureString(lastEval.RankGlyph, gf)
            Dim gc As Color = If(lastEval.RankTitle = "BETRAYER OF THE KEEP",
                                 Color.FromArgb(255, 220, 210),
                                 Color.FromArgb(240, 220, 160))
            g.DrawString(lastEval.RankGlyph, gf, New SolidBrush(gc),
                         cx - gsz.Width / 2, cy - gsz.Height / 2 - 22)
        End Using

        Using f As New Font("Georgia", 8, FontStyle.Bold)
            Dim tsz = g.MeasureString(lastEval.RankTitle, f)
            Dim br As New RectangleF(cx - tsz.Width / 2 - 6, cy + 18, tsz.Width + 12, tsz.Height + 4)
            g.FillRectangle(New SolidBrush(Color.FromArgb(60, 10, 10)), br)
            g.DrawString(lastEval.RankTitle, f, New SolidBrush(Color.FromArgb(240, 220, 170)),
                         br.X + 6, br.Y + 2)
        End Using

        Using f As New Font("Georgia", 10, FontStyle.Italic)
            Dim s = "Honor " & lastEval.HonorScore & " / 100"
            Dim ssz = g.MeasureString(s, f)
            g.DrawString(s, f, New SolidBrush(Color.FromArgb(240, 220, 170)),
                         cx - ssz.Width / 2, cy + 40)
        End Using
    End Sub

    Private Sub GameTimer_Tick(sender As Object, e As EventArgs) Handles GameTimer.Tick
        If Not gameStarted OrElse gameEnded Then Return
        elapsedSeconds += 1
        lblTime.Text = "Candles: " & FormatTime(elapsedSeconds)
    End Sub

    Private Function FormatTime(s As Integer) As String
        Return String.Format("{0:00}:{1:00}", s \ 60, s Mod 60)
    End Function

End Class