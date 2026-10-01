Imports System.Drawing.Drawing2D
Imports System.Linq

Public Class TheRoyalRoadDilemma

    Private Enum Pg
        Home = 0
        Help = 1
        Play = 2
        Result = 3
    End Enum

    Private Class Person
        Public IsWife As Boolean
        Public Side As Integer
        Public X, Y, TX, TY As Single
    End Class

    Private Const LeftDock As Single = 230
    Private Const RightDock As Single = 490
    Private Const CarW As Single = 180
    Private Const OptimalMoves As Integer = 11

    Private WithEvents tmrAnim As New System.Windows.Forms.Timer With {.Interval = 30}
    Private WithEvents tmrClock As New System.Windows.Forms.Timer With {.Interval = 1000}

    Private scene As BufferedPanel
    Private cur As Pg = Pg.Home
    Private people As New List(Of Person)
    Private carSide As Integer = 0
    Private carX As Single = LeftDock
    Private facing As Integer = 1
    Private moving, failed, won As Boolean
    Private moves, seconds, scandals, failTicks, winTicks, shake, tick As Integer
    Private message As String = ""
    Private wheelAngle, cloudX As Single
    Private homeX As Single = -200
    Private rnd As New Random()

    Private score As Integer
    Private rankTitle, rankNote, rankNum As String
    Private rankColor As Color

    Private ReadOnly fTitle As New Font("Georgia", 34, FontStyle.Bold)
    Private ReadOnly fBig As New Font("Georgia", 22, FontStyle.Bold)
    Private ReadOnly fMid As New Font("Georgia", 13, FontStyle.Bold)
    Private ReadOnly fSm As New Font("Georgia", 10, FontStyle.Bold)
    Private ReadOnly fTxt As New Font("Georgia", 10.5F)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = "The Royal Road Dilemma"
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        ClientSize = New Size(900, 560)
        StartPosition = FormStartPosition.CenterScreen

        scene = New BufferedPanel With {.Dock = DockStyle.Fill}
        Controls.Add(scene)
        AddHandler scene.Paint, AddressOf DrawScene
        AddHandler scene.MouseClick, AddressOf SceneClick

        MakeBtn("Begin Journey", 350, 170, 200, Pg.Home, Sub() StartGame())
        MakeBtn("How to Play", 350, 218, 200, Pg.Home, Sub() SetScreen(Pg.Help))
        MakeBtn("Leave Realm", 350, 266, 200, Pg.Home, Sub() Close())
        MakeBtn("Back", 350, 500, 200, Pg.Help, Sub() SetScreen(Pg.Home))
        MakeBtn("Drive Carriage", 300, 500, 180, Pg.Play, Sub() DriveCarriage())
        MakeBtn("Restart", 490, 500, 120, Pg.Play, Sub() RetryPuzzle())
        MakeBtn("Menu", 620, 500, 100, Pg.Play, Sub() SetScreen(Pg.Home))
        MakeBtn("Play Again", 250, 500, 190, Pg.Result, Sub() StartGame())
        MakeBtn("Main Menu", 460, 500, 190, Pg.Result, Sub() SetScreen(Pg.Home))

        tmrAnim.Start()
        tmrClock.Start()
        SetScreen(Pg.Home)
    End Sub

    Private Function MakeBtn(txt As String, x As Integer, y As Integer, w As Integer, page As Pg, act As Action) As Button
        Dim b As New Button With {
            .Text = txt, .Left = x, .Top = y, .Width = w, .Height = 40,
            .Tag = CInt(page), .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.FromArgb(92, 58, 30), .ForeColor = Color.Gold,
            .Font = New Font("Georgia", 12, FontStyle.Bold), .Cursor = Cursors.Hand}
        b.FlatAppearance.BorderColor = Color.Gold
        AddHandler b.Click, Sub() act()
        scene.Controls.Add(b)
        Return b
    End Function

    Private Sub SetScreen(p As Pg)
        cur = p
        For Each c As Control In scene.Controls
            c.Visible = (CInt(c.Tag) = CInt(p))
        Next
    End Sub

    Private Sub StartGame()
        seconds = 0
        scandals = 0
        RetryPuzzle()
        SetScreen(Pg.Play)
    End Sub

    Private Sub RetryPuzzle()
        people.Clear()
        For i = 1 To 3 : people.Add(New Person With {.IsWife = True}) : Next
        For i = 1 To 3 : people.Add(New Person With {.IsWife = False}) : Next
        carSide = 0 : carX = LeftDock : facing = 1
        moving = False : failed = False : won = False : moves = 0
        Retarget()
        For Each p As Person In people
            p.X = p.TX : p.Y = p.TY
        Next
        message = "Click a lady to seat her in the carriage, then press Drive Carriage."
    End Sub

    Private Function Scandal(side As Integer, withCar As Boolean) As Boolean
        Dim w = 0, m = 0
        For Each p As Person In people
            If p.Side = side OrElse (withCar AndAlso p.Side = 2 AndAlso carSide = side) Then
                If p.IsWife Then w += 1 Else m += 1
            End If
        Next
        Return w > 0 AndAlso m > w
    End Function

    Private Sub DriveCarriage()
        If moving OrElse failed OrElse won Then Return
        If CountOnCarriage() = 0 Then
            message = "Someone must drive! Seat at least one lady first."
            Return
        End If
        If Scandal(carSide, False) Then Fail(carSide) : Return
        facing = If(carSide = 0, 1, -1)
        moving = True
        moves += 1
        message = "The carriage rolls along the road..."
    End Sub

    Private Function CountOnCarriage() As Integer
        Dim n = 0
        For Each p As Person In people
            If p.Side = 2 Then n += 1
        Next
        Return n
    End Function

    Private Sub Arrive()
        If Scandal(0, True) Then Fail(0) : Return
        If Scandal(1, True) Then Fail(1) : Return
        message = "Arrived safely. Unload or load passengers."
        CheckWin()
    End Sub

    Private Sub Fail(side As Integer)
        scandals += 1
        failed = True
        failTicks = 90
        shake = 25
        message = "Scandal at the " & If(side = 0, "Castle Keep", "Village Market") & "! Everyone returns to the start."
    End Sub

    Private Sub CheckWin()
        If carSide = 1 AndAlso Not moving AndAlso AllLeftCastle() Then
            won = True
            winTicks = 60
            message = "Everyone has reached the Village Market!"
        End If
    End Sub

    Private Function AllLeftCastle() As Boolean
        For Each p As Person In people
            If p.Side = 0 Then Return False
        Next
        Return True
    End Function

    Private Sub ShowResult()
        Dim extra = Math.Max(0, moves - OptimalMoves)
        score = Math.Max(0, 1000 - extra * 40 - scandals * 75 - Math.Max(0, seconds - 120))
        Select Case score
            Case Is >= 900
                rankTitle = "Grand Sage of the Realm" : rankNum = "V" : rankColor = Color.Goldenrod
                rankNote = "A flawless strategist! The king himself asks for your counsel."
            Case Is >= 750
                rankTitle = "Duke of Diplomacy" : rankNum = "IV" : rankColor = Color.MediumPurple
                rankNote = "Smooth and graceful. Hardly a feather was ruffled."
            Case Is >= 550
                rankTitle = "Knight of the Open Road" : rankNum = "III" : rankColor = Color.SteelBlue
                rankNote = "Honorable work, though the road had a few bumps."
            Case Is >= 300
                rankTitle = "Squire of the Stables" : rankNum = "II" : rankColor = Color.Sienna
                rankNote = "Everyone got across... eventually."
            Case Else
                rankTitle = "Wandering Peasant" : rankNum = "I" : rankColor = Color.Gray
                rankNote = "The ladies made it, but the gossip will last for years."
        End Select
        SetScreen(Pg.Result)
    End Sub

    Private Sub SceneClick(sender As Object, e As MouseEventArgs)
        If cur <> Pg.Play OrElse moving OrElse failed OrElse won Then Return
        Dim hit As Person = Nothing
        For Each p As Person In people
            If New RectangleF(p.X, p.Y - 12, 40, 82).Contains(e.X, e.Y) Then hit = p
        Next
        If hit Is Nothing Then Return

        If hit.Side = 2 Then
            hit.Side = carSide
            message = "Stepped off the carriage."
        ElseIf hit.Side <> carSide Then
            message = "The carriage is parked on the other side of the road!"
        ElseIf CountOnCarriage() >= 2 Then
            message = "The carriage only seats two!"
        Else
            hit.Side = 2
            message = "Seated. Press Drive Carriage when ready."
        End If
        CheckWin()
    End Sub

    Private Sub tmrClock_Tick(sender As Object, e As EventArgs) Handles tmrClock.Tick
        If cur = Pg.Play AndAlso Not failed AndAlso Not won Then seconds += 1
    End Sub

    Private Sub tmrAnim_Tick(sender As Object, e As EventArgs) Handles tmrAnim.Tick
        tick += 1
        cloudX = (cloudX + 0.6F) Mod 1100

        If cur = Pg.Home Then
            homeX += 3
            If homeX > 900 Then homeX = -220
            wheelAngle += 0.15F
        ElseIf cur = Pg.Play Then
            If moving Then
                carX += facing * 7
                wheelAngle += 0.28F
                Dim target = If(carSide = 0, RightDock, LeftDock)
                If (facing = 1 AndAlso carX >= target) OrElse (facing = -1 AndAlso carX <= target) Then
                    carX = target
                    moving = False
                    carSide = 1 - carSide
                    Arrive()
                End If
            End If

            Retarget()
            For Each p As Person In people
                If moving AndAlso p.Side = 2 Then
                    p.X = p.TX
                    p.Y = p.TY + CSng(Math.Sin(tick * 0.9)) * 2
                Else
                    p.X += (p.TX - p.X) * 0.25F
                    p.Y += (p.TY - p.Y) * 0.25F
                End If
            Next

            If shake > 0 Then shake -= 1
            If failed Then
                failTicks -= 1
                If failTicks <= 0 Then RetryPuzzle()
            End If
            If won Then
                winTicks -= 1
                If winTicks <= 0 Then won = False : ShowResult()
            End If
        End If
        scene.Invalidate()
    End Sub

    Private Sub Retarget()
        Dim cnt(1, 1) As Integer
        Dim seat = 0
        For Each p As Person In people
            If p.Side = 2 Then
                p.TX = SeatX(seat) : p.TY = 312 : seat += 1
            Else
                Dim row = If(p.IsWife, 0, 1)
                p.TX = If(p.Side = 0, 15, 690) + cnt(p.Side, row) * 65
                p.TY = If(p.IsWife, 205, 272)
                cnt(p.Side, row) += 1
            End If
        Next
    End Sub

    Private Function SeatX(i As Integer) As Single
        Return If(facing = 1, carX + 10 + i * 45, carX + CarW - 50 - i * 45)
    End Function

    Private Sub DrawScene(sender As Object, e As PaintEventArgs)
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        If shake > 0 Then g.TranslateTransform(rnd.Next(-4, 5), rnd.Next(-4, 5))
        DrawBackground(g)
        Select Case cur
            Case Pg.Home : DrawHome(g)
            Case Pg.Help : DrawHelp(g)
            Case Pg.Play : DrawPlay(g)
            Case Pg.Result : DrawResult(g)
        End Select
    End Sub

    Private Sub FR(g As Graphics, c As Color, x As Single, y As Single, w As Single, h As Single)
        Using b As New SolidBrush(c) : g.FillRectangle(b, x, y, w, h) : End Using
    End Sub
    Private Sub FE(g As Graphics, c As Color, x As Single, y As Single, w As Single, h As Single)
        Using b As New SolidBrush(c) : g.FillEllipse(b, x, y, w, h) : End Using
    End Sub
    Private Sub FP(g As Graphics, c As Color, ParamArray pts() As PointF)
        Using b As New SolidBrush(c) : g.FillPolygon(b, pts) : End Using
    End Sub
    Private Function P(x As Single, y As Single) As PointF
        Return New PointF(x, y)
    End Function
    Private Sub Txt(g As Graphics, s As String, f As Font, c As Color, x As Single, y As Single, w As Single, h As Single, Optional centered As Boolean = True)
        Using b As New SolidBrush(c), sf As New StringFormat
            sf.Alignment = If(centered, StringAlignment.Center, StringAlignment.Near)
            g.DrawString(s, f, b, New RectangleF(x, y, w, h), sf)
        End Using
    End Sub

    Private Sub DrawBackground(g As Graphics)
        Using sky As New LinearGradientBrush(New Rectangle(0, 0, 900, 260), Color.FromArgb(120, 180, 235), Color.FromArgb(255, 230, 190), 90.0F)
            g.FillRectangle(sky, 0, 0, 900, 260)
        End Using
        FE(g, Color.FromArgb(255, 235, 140), 740, 40, 70, 70)
        For i = 0 To 2
            Dim x = ((cloudX + i * 380) Mod 1100) - 150
            FE(g, Color.FromArgb(210, 255, 255, 255), x, 60 + i * 26, 90, 30)
            FE(g, Color.FromArgb(210, 255, 255, 255), x + 25, 48 + i * 26, 60, 34)
        Next
        FE(g, Color.FromArgb(110, 160, 110), -100, 190, 600, 140)
        FE(g, Color.FromArgb(95, 150, 100), 350, 200, 700, 130)
        FR(g, Color.FromArgb(105, 170, 80), 0, 250, 900, 190)
        FR(g, Color.FromArgb(150, 115, 75), 0, 340, 900, 80)
        FR(g, Color.FromArgb(110, 80, 50), 0, 340, 900, 4)
        FR(g, Color.FromArgb(110, 80, 50), 0, 416, 900, 4)
        For x = 0 To 900 Step 70 : FR(g, Color.FromArgb(172, 138, 98), x, 380, 30, 5) : Next

        Dim stone = Color.FromArgb(150, 150, 165), dark = Color.FromArgb(115, 115, 130)
        FR(g, stone, 10, 100, 150, 130)
        FR(g, dark, 0, 70, 40, 160) : FR(g, dark, 130, 70, 40, 160)
        For x = 0 To 20 Step 20 : FR(g, dark, x, 58, 12, 14) : FR(g, dark, x + 130, 58, 12, 14) : Next
        FR(g, Color.FromArgb(70, 45, 25), 62, 165, 46, 65)
        FR(g, Color.Black, 19, 28, 3, 30)
        FP(g, Color.Firebrick, P(22, 28), P(42, 35), P(22, 42))

        FR(g, Color.Cornsilk, 705, 150, 70, 80) : FP(g, Color.Firebrick, P(697, 150), P(740, 108), P(783, 150))
        FR(g, Color.FromArgb(70, 45, 25), 730, 190, 20, 40)
        FR(g, Color.Cornsilk, 800, 170, 70, 60) : FP(g, Color.SaddleBrown, P(792, 170), P(835, 135), P(878, 170))
        FR(g, Color.FromArgb(70, 45, 25), 825, 195, 20, 35)

        FR(g, Color.FromArgb(60, 40, 25), 0, 440, 900, 120)
        FR(g, Color.Gold, 0, 440, 900, 3)
    End Sub

    Private Sub DrawHome(g As Graphics)
        Txt(g, "The Royal Road Dilemma", fTitle, Color.Black, 3, 33, 900, 60)
        Txt(g, "The Royal Road Dilemma", fTitle, Color.Gold, 0, 30, 900, 60)
        Txt(g, "A medieval tale of wives, mistresses and one very small carriage", fMid, Color.FromArgb(60, 30, 10), 0, 100, 900, 28)
        DrawCarriage(g, homeX, 1)
        Txt(g, "Cross the road without causing a scandal.", fSm, Color.Cornsilk, 0, 470, 900, 24)
    End Sub

    Private Sub DrawHelp(g As Graphics)
        FR(g, Color.FromArgb(240, 225, 190), 90, 20, 720, 410)
        Using pn As New Pen(Color.FromArgb(120, 80, 40), 4) : g.DrawRectangle(pn, 90, 20, 720, 410) : End Using
        Txt(g, "How to Play", fBig, Color.FromArgb(90, 50, 20), 90, 28, 720, 34)
        Dim t = String.Join(vbCrLf, {
            "THE STORY",
            "Three noble wives and their three rivals, the mistresses, must travel from the Castle Keep to the Village Market. The road has only one horse-drawn carriage.",
            "",
            "THE GOAL: get all six ladies to the Village Market.",
            "",
            "THE RULES",
            "1. The carriage seats two ladies at most.",
            "2. It cannot travel empty - someone must drive it.",
            "3. If mistresses outnumber the wives on one side of the road (with at least one wife present), a SCANDAL erupts and the trip is ruined.",
            "4. The carriage counts as part of the side where it is parked.",
            "",
            "CONTROLS: click a lady to seat her (the carriage must be on her side) or to step her off. Press Drive Carriage to roll across. Restart resets the road, but your time and scandals still count.",
            "",
            "YOUR RANK: fewer moves, fewer scandals and a faster time earn a higher rank, from Wandering Peasant up to Grand Sage of the Realm."})
        Txt(g, t, fTxt, Color.FromArgb(50, 30, 15), 115, 70, 670, 355, False)
    End Sub

    Private Sub DrawPlay(g As Graphics)
        FR(g, Color.FromArgb(180, 40, 25, 15), 0, 0, 900, 36)
        Txt(g, String.Format("Moves: {0}      Time: {1:00}:{2:00}      Scandals: {3}", moves, seconds \ 60, seconds Mod 60, scandals), fMid, Color.Gold, 0, 7, 900, 24)
        Txt(g, "CASTLE KEEP", fSm, Color.White, 10, 422, 200, 18, False)
        Txt(g, "VILLAGE MARKET", fSm, Color.White, 690, 422, 200, 18, False)

        DrawCarriage(g, carX, facing)
        For Each p As Person In people : DrawPerson(g, p) : Next
        Dim fx = If(facing = 1, carX, carX + CarW - 110)
        FR(g, Color.FromArgb(130, 85, 45), fx, 352, 110, 30)
        FR(g, Color.FromArgb(90, 55, 25), fx, 352, 110, 3)

        Txt(g, message, fMid, Color.Cornsilk, 20, 452, 860, 44)

        If failed Then
            FR(g, Color.FromArgb(225, 130, 20, 20), 150, 140, 600, 90)
            Txt(g, "SCANDAL!", fBig, Color.White, 150, 150, 600, 36)
            Txt(g, "The mistresses outnumbered the wives.", fMid, Color.White, 150, 192, 600, 28)
        ElseIf won Then
            FR(g, Color.FromArgb(225, 30, 100, 40), 150, 140, 600, 80)
            Txt(g, "The whole court has crossed!", fBig, Color.White, 150, 165, 600, 40)
        End If
    End Sub

    Private Sub DrawPerson(g As Graphics, pr As Person)
        Dim x = pr.X, y = pr.Y
        Dim dress = If(pr.IsWife, Color.FromArgb(110, 60, 160), Color.FromArgb(200, 35, 70))
        If Not pr.IsWife Then FE(g, Color.FromArgb(150, 70, 30), x + 8, y + 1, 24, 30)
        FP(g, dress, P(x + 20, y + 22), P(x + 38, y + 70), P(x + 2, y + 70))
        FR(g, Color.FromArgb(235, 200, 160), x + 17, y + 20, 6, 6)
        FE(g, Color.FromArgb(245, 215, 175), x + 11, y + 3, 18, 20)
        FE(g, Color.Black, x + 16, y + 12, 2, 2) : FE(g, Color.Black, x + 22, y + 12, 2, 2)
        If pr.IsWife Then
            FP(g, Color.Gold, P(x + 11, y + 8), P(x + 20, y - 12), P(x + 29, y + 8))
        Else
            FE(g, Color.HotPink, x + 26, y + 5, 9, 9)
        End If
        Txt(g, If(pr.IsWife, "W", "M"), fSm, Color.White, x, y + 46, 40, 16)
    End Sub

    Private Sub DrawCarriage(g As Graphics, cx As Single, face As Integer)
        Dim rolling = (cur = Pg.Home OrElse moving)
        Dim bob = If(rolling, CSng(Math.Sin(wheelAngle * 3)) * 1.5F, 0.0F)
        Dim st = g.Save()
        If face = -1 Then
            g.TranslateTransform(cx + CarW, bob) : g.ScaleTransform(-1, 1)
        Else
            g.TranslateTransform(cx, bob)
        End If
        Dim wood = Color.FromArgb(120, 75, 40)

        FR(g, wood, 4, 298, 5, 54) : FR(g, wood, 101, 298, 5, 54)
        FR(g, wood, 0, 350, 110, 32)
        FP(g, Color.Firebrick, P(-6, 298), P(116, 298), P(100, 278), P(10, 278))
        FR(g, wood, 110, 362, 18, 4)
        FE(g, Color.FromArgb(120, 80, 50), 118, 336, 40, 26)
        FP(g, Color.FromArgb(120, 80, 50), P(148, 342), P(158, 316), P(170, 320), P(158, 346))
        FE(g, Color.FromArgb(120, 80, 50), 158, 312, 20, 12)
        FE(g, Color.Black, 170, 314, 3, 3)
        Using pn As New Pen(Color.FromArgb(90, 55, 25), 4)
            g.DrawLine(pn, 119, 344, 108, 364)
            For k = 0 To 3
                Dim legX As Single = {126, 134, 148, 154}(k)
                Dim swing = If(rolling, CSng(Math.Sin(wheelAngle * 1.5 + k * Math.PI / 2)) * 8, 0.0F)
                g.DrawLine(pn, legX, 358, legX + swing, 388)
            Next
        End Using
        DrawWheel(g, 28, 392, 24) : DrawWheel(g, 88, 392, 24)
        g.Restore(st)
    End Sub

    Private Sub DrawWheel(g As Graphics, x As Single, y As Single, r As Single)
        Using pn As New Pen(Color.FromArgb(70, 40, 15), 4)
            g.DrawEllipse(pn, x - r, y - r, 2 * r, 2 * r)
            For k = 0 To 5
                Dim a = wheelAngle + k * Math.PI / 3
                g.DrawLine(pn, x, y, x + CSng(Math.Cos(a)) * r, y + CSng(Math.Sin(a)) * r)
            Next
        End Using
    End Sub

    Private Sub DrawResult(g As Graphics)
        FR(g, Color.FromArgb(240, 225, 190), 100, 20, 700, 405)
        Using pn As New Pen(Color.FromArgb(120, 80, 40), 4) : g.DrawRectangle(pn, 100, 20, 700, 405) : End Using
        Dim brown = Color.FromArgb(70, 40, 20)
        Txt(g, "Journey Complete!", fBig, brown, 100, 32, 700, 36)

        DrawSeal(g, 220, 200, 78)
        Txt(g, "Rank " & rankNum & " of V", fSm, brown, 130, 295, 180, 20)

        Txt(g, rankTitle, fBig, brown, 340, 95, 450, 36, False)
        Txt(g, rankNote, fTxt, brown, 340, 135, 440, 40, False)
        Txt(g, String.Format("Moves: {0}   (the perfect route takes {1})", moves, OptimalMoves), fMid, brown, 340, 190, 450, 26, False)
        Txt(g, "Scandals: " & scandals, fMid, brown, 340, 220, 450, 26, False)
        Txt(g, String.Format("Time: {0:00}:{1:00}", seconds \ 60, seconds Mod 60), fMid, brown, 340, 250, 450, 26, False)
        Txt(g, "Court Favour: " & score & " / 1000", fMid, brown, 340, 295, 450, 26, False)
        FR(g, Color.FromArgb(200, 180, 140), 340, 330, 420, 22)
        FR(g, rankColor, 340, 330, 420 * score / 1000, 22)
        Using pn As New Pen(brown, 2) : g.DrawRectangle(pn, 340, 330, 420, 22) : End Using
    End Sub

    Private Sub DrawSeal(g As Graphics, cx As Single, cy As Single, r As Single)
        Dim pts(63) As PointF
        For i = 0 To 63
            Dim rad = If(i Mod 2 = 0, r, r - 9)
            Dim a = i * Math.PI / 32
            pts(i) = New PointF(cx + CSng(Math.Cos(a) * rad), cy + CSng(Math.Sin(a) * rad))
        Next
        FP(g, rankColor, pts)
        Using pn As New Pen(Color.FromArgb(210, 255, 255, 255), 3)
            g.DrawEllipse(pn, cx - r + 16, cy - r + 16, 2 * (r - 16), 2 * (r - 16))
        End Using
        Txt(g, rankNum, fTitle, Color.White, cx - r, cy - 28, 2 * r, 60)
    End Sub

End Class

Friend Class BufferedPanel
    Inherits Panel
    Public Sub New()
        DoubleBuffered = True
        SetStyle(ControlStyles.ResizeRedraw, True)
    End Sub
End Class