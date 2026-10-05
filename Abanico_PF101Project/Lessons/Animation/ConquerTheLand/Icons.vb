Imports System.Drawing.Drawing2D

' ============================================================
' Icons.vb
' All the game's "pictures" are DRAWN IN CODE with GDI+ (the
' Graphics class), so you don't need any image files.
'
' Big idea: each terrain icon is drawn on an imaginary canvas
' that is 100 wide x 60 tall. DrawTerrain() then scales that
' canvas to whatever size we need. So "Capital" is written once
' and looks right on a tile, in the info panel, or in a toolbar.
' ============================================================

Public Class Icons

    ' ---------- tiny drawing helpers ----------
    Private Shared Function Pt(x As Single, y As Single) As PointF
        Return New PointF(x, y)
    End Function

    Private Shared Sub FillPoly(g As Graphics, c As Color, ParamArray pts() As PointF)
        Using b As New SolidBrush(c)
            g.FillPolygon(b, pts)
        End Using
    End Sub

    Private Shared Sub FillRect(g As Graphics, c As Color, x As Single, y As Single, w As Single, h As Single)
        Using b As New SolidBrush(c)
            g.FillRectangle(b, x, y, w, h)
        End Using
    End Sub

    Private Shared Sub FillOval(g As Graphics, c As Color, x As Single, y As Single, w As Single, h As Single)
        Using b As New SolidBrush(c)
            g.FillEllipse(b, x, y, w, h)
        End Using
    End Sub

    Private Shared Sub DrawLn(g As Graphics, c As Color, width As Single,
                              x1 As Single, y1 As Single, x2 As Single, y2 As Single)
        Using p As New Pen(c, width)
            p.StartCap = LineCap.Round
            p.EndCap = LineCap.Round
            g.DrawLine(p, x1, y1, x2, y2)
        End Using
    End Sub

    ' A wavy water line across the 100-wide canvas
    Private Shared Sub Wave(g As Graphics, c As Color, width As Single, y As Single)
        Dim pts() As PointF = {Pt(5, y), Pt(20, y - 5), Pt(35, y), Pt(50, y + 5),
                               Pt(65, y), Pt(80, y - 5), Pt(95, y)}
        Using p As New Pen(c, width)
            p.StartCap = LineCap.Round
            p.EndCap = LineCap.Round
            g.DrawCurve(p, pts, 0.5F)
        End Using
    End Sub

    Public Shared Function RoundedRect(r As RectangleF, radius As Single) As GraphicsPath
        Dim d As Single = radius * 2
        Dim path As New GraphicsPath()
        path.AddArc(r.X, r.Y, d, d, 180, 90)
        path.AddArc(r.Right - d, r.Y, d, d, 270, 90)
        path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90)
        path.AddArc(r.X, r.Bottom - d, d, d, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    ' ---------- background colors for each terrain ----------
    Public Shared Sub TerrainColors(name As String, ByRef c1 As Color, ByRef c2 As Color)
        Select Case name
            Case "Capital"
                c1 = Color.FromArgb(150, 200, 250)
                c2 = Color.FromArgb(215, 232, 250)
            Case "Fortress"
                c1 = Color.FromArgb(150, 150, 170)
                c2 = Color.FromArgb(105, 105, 130)
            Case "Forest"
                c1 = Color.FromArgb(150, 205, 150)
                c2 = Color.FromArgb(95, 160, 100)
            Case "Hill"
                c1 = Color.FromArgb(190, 230, 160)
                c2 = Color.FromArgb(140, 200, 120)
            Case "Mountains"
                c1 = Color.FromArgb(175, 190, 205)
                c2 = Color.FromArgb(130, 145, 165)
            Case "Farmland"
                c1 = Color.FromArgb(240, 225, 150)
                c2 = Color.FromArgb(205, 180, 95)
            Case "Riverlands"
                c1 = Color.FromArgb(170, 215, 240)
                c2 = Color.FromArgb(110, 170, 215)
            Case "Iron Valley"
                c1 = Color.FromArgb(170, 170, 185)
                c2 = Color.FromArgb(115, 120, 140)
            Case "Golden Plains"
                c1 = Color.FromArgb(255, 235, 150)
                c2 = Color.FromArgb(240, 200, 90)
            Case "Village"
                c1 = Color.FromArgb(200, 225, 180)
                c2 = Color.FromArgb(160, 200, 150)
            Case "Wasteland"
                c1 = Color.FromArgb(215, 195, 160)
                c2 = Color.FromArgb(170, 145, 110)
            Case "Harbor"
                c1 = Color.FromArgb(160, 210, 240)
                c2 = Color.FromArgb(100, 160, 210)
            Case Else
                c1 = Color.LightGray
                c2 = Color.Gray
        End Select
    End Sub

    ' ---------- terrain icons (100 x 60 canvas) ----------
    Public Shared Sub DrawTerrain(g As Graphics, name As String, r As RectangleF)
        Dim s As Single = Math.Min(r.Width / 100.0F, r.Height / 60.0F)
        If s <= 0 Then Return

        Dim ox As Single = r.X + (r.Width - 100 * s) / 2
        Dim oy As Single = r.Y + (r.Height - 60 * s) / 2

        Dim state As GraphicsState = g.Save()
        g.TranslateTransform(ox, oy)
        g.ScaleTransform(s, s)
        g.SetClip(New RectangleF(0, 0, 100, 60))   ' nothing may spill outside the canvas

        Select Case name
            Case "Capital"
                Castle(g, False)
            Case "Fortress"
                Castle(g, True)
            Case "Forest"
                ForestIcon(g)
            Case "Hill"
                HillIcon(g)
            Case "Mountains"
                MountainIcon(g)
            Case "Farmland"
                FarmIcon(g)
            Case "Riverlands"
                RiverIcon(g)
            Case "Iron Valley"
                AnvilIcon(g)
            Case "Golden Plains"
                PlainsIcon(g)
            Case "Village"
                VillageIcon(g)
            Case "Wasteland"
                WasteIcon(g)
            Case "Harbor"
                HarborIcon(g)
        End Select

        g.Restore(state)
    End Sub

    Private Shared Sub Castle(g As Graphics, fortress As Boolean)
        Dim stone As Color = If(fortress, Color.FromArgb(95, 95, 110), Color.FromArgb(195, 195, 205))
        Dim wall As Color = If(fortress, Color.FromArgb(70, 70, 85), Color.FromArgb(150, 150, 165))
        Dim flagC As Color = If(fortress, Color.FromArgb(175, 30, 30), Color.FromArgb(245, 195, 40))

        FillRect(g, Color.FromArgb(90, 150, 70), 0, 54, 100, 6)       ' grass

        ' center wall + battlements
        FillRect(g, wall, 28, 22, 44, 33)
        For i As Integer = 0 To 4
            FillRect(g, wall, 30 + i * 8.5F, 17, 5, 5)
        Next

        ' two towers + battlements
        FillRect(g, stone, 12, 12, 18, 43)
        FillRect(g, stone, 70, 12, 18, 43)
        For i As Integer = 0 To 2
            FillRect(g, stone, 12 + i * 6.5F, 7, 4.5F, 6)
            FillRect(g, stone, 70 + i * 6.5F, 7, 4.5F, 6)
        Next

        ' windows and door
        FillRect(g, Color.FromArgb(40, 40, 60), 18, 22, 6, 9)
        FillRect(g, Color.FromArgb(40, 40, 60), 76, 22, 6, 9)
        FillRect(g, Color.FromArgb(90, 55, 30), 44, 40, 12, 15)
        FillOval(g, Color.FromArgb(90, 55, 30), 44, 34, 12, 12)

        ' flag
        DrawLn(g, Color.FromArgb(70, 50, 30), 2, 50, 22, 50, 3)
        FillPoly(g, flagC, Pt(50, 3), Pt(66, 8), Pt(50, 13))
    End Sub

    Private Shared Sub Tree(g As Graphics, cx As Single, baseY As Single, k As Single)
        FillRect(g, Color.FromArgb(110, 75, 40), cx - 2.5F * k, baseY - 8 * k, 5 * k, 9 * k)
        FillPoly(g, Color.FromArgb(40, 140, 65),
                 Pt(cx, baseY - 32 * k), Pt(cx - 16 * k, baseY - 6 * k), Pt(cx + 16 * k, baseY - 6 * k))
        FillPoly(g, Color.FromArgb(25, 105, 50),
                 Pt(cx, baseY - 44 * k), Pt(cx - 12 * k, baseY - 18 * k), Pt(cx + 12 * k, baseY - 18 * k))
    End Sub

    Private Shared Sub ForestIcon(g As Graphics)
        FillRect(g, Color.FromArgb(70, 120, 55), 0, 54, 100, 6)
        Tree(g, 24, 52, 0.85F)
        Tree(g, 76, 52, 0.85F)
        Tree(g, 50, 57, 1.1F)
    End Sub

    Private Shared Sub HillIcon(g As Graphics)
        FillOval(g, Color.FromArgb(110, 185, 80), 0, 26, 100, 70)
        FillOval(g, Color.FromArgb(80, 160, 70), 40, 38, 80, 60)
        DrawLn(g, Color.FromArgb(90, 60, 30), 2, 45, 28, 45, 8)
        FillPoly(g, Color.FromArgb(220, 60, 60), Pt(45, 8), Pt(60, 13), Pt(45, 18))
    End Sub

    Private Shared Sub MountainIcon(g As Graphics)
        ' back mountain
        FillPoly(g, Color.FromArgb(135, 125, 120), Pt(30, 20), Pt(4, 56), Pt(56, 56))
        FillPoly(g, Color.White, Pt(30, 20), Pt(23, 31), Pt(29, 28), Pt(35, 32))
        ' front mountain
        FillPoly(g, Color.FromArgb(110, 100, 95), Pt(66, 5), Pt(32, 56), Pt(100, 56))
        FillPoly(g, Color.FromArgb(80, 72, 68), Pt(66, 5), Pt(100, 56), Pt(66, 56))   ' shadow side
        FillPoly(g, Color.White, Pt(66, 5), Pt(55, 22), Pt(62, 18), Pt(67, 24), Pt(73, 18), Pt(77, 22))
    End Sub

    Private Shared Sub FarmIcon(g As Graphics)
        ' barn
        FillRect(g, Color.FromArgb(190, 60, 50), 62, 12, 28, 20)
        FillPoly(g, Color.FromArgb(90, 40, 30), Pt(58, 13), Pt(76, 1), Pt(94, 13))
        FillRect(g, Color.FromArgb(240, 230, 220), 71, 19, 10, 13)
        ' soil and crop rows
        FillRect(g, Color.FromArgb(150, 105, 60), 4, 32, 92, 26)
        For i As Integer = 0 To 3
            FillRect(g, Color.FromArgb(205, 195, 70), 8, 35 + i * 6, 84, 3)
        Next
    End Sub

    Private Shared Sub RiverIcon(g As Graphics)
        FillRect(g, Color.FromArgb(110, 175, 90), 0, 0, 100, 5)
        Wave(g, Color.FromArgb(40, 120, 200), 5, 18)
        Wave(g, Color.FromArgb(90, 165, 235), 5, 32)
        Wave(g, Color.FromArgb(40, 120, 200), 5, 46)
        ' reeds
        DrawLn(g, Color.FromArgb(70, 120, 50), 2, 90, 12, 92, 2)
        DrawLn(g, Color.FromArgb(70, 120, 50), 2, 94, 12, 96, 3)
    End Sub

    Private Shared Sub AnvilIcon(g As Graphics)
        ' sparks
        Dim spark As Color = Color.FromArgb(255, 170, 40)
        DrawLn(g, spark, 2.5F, 50, 16, 50, 4)
        DrawLn(g, spark, 2.5F, 50, 16, 38, 8)
        DrawLn(g, spark, 2.5F, 50, 16, 62, 8)
        DrawLn(g, spark, 2.5F, 50, 16, 32, 16)
        DrawLn(g, spark, 2.5F, 50, 16, 68, 16)
        ' anvil body
        FillPoly(g, Color.FromArgb(70, 75, 90),
                 Pt(6, 24), Pt(25, 22), Pt(92, 22), Pt(76, 31), Pt(63, 33), Pt(63, 43),
                 Pt(74, 50), Pt(74, 56), Pt(26, 56), Pt(26, 50), Pt(37, 43), Pt(37, 33), Pt(24, 31))
        DrawLn(g, Color.FromArgb(170, 175, 190), 2.5F, 25, 23, 90, 23)   ' shiny top
    End Sub

    Private Shared Sub PlainsIcon(g As Graphics)
        ' sun
        For a As Integer = 0 To 7
            Dim ang As Double = a * Math.PI / 4
            DrawLn(g, Color.FromArgb(255, 200, 40), 2,
                   CSng(70 + 14 * Math.Cos(ang)), CSng(16 + 14 * Math.Sin(ang)),
                   CSng(70 + 20 * Math.Cos(ang)), CSng(16 + 20 * Math.Sin(ang)))
        Next
        FillOval(g, Color.FromArgb(255, 215, 60), 58, 4, 24, 24)
        ' ground and wheat
        FillRect(g, Color.FromArgb(225, 175, 55), 0, 40, 100, 20)
        For i As Integer = 0 To 9
            DrawLn(g, Color.FromArgb(185, 130, 25), 2.5F, 8 + i * 9, 58, 10 + i * 9, 40)
        Next
        DrawCoin(g, New RectangleF(8, 6, 26, 26))
    End Sub

    Private Shared Sub House(g As Graphics, x As Single, y As Single, w As Single, h As Single,
                             wall As Color, roof As Color)
        FillRect(g, wall, x, y, w, h)
        FillPoly(g, roof, Pt(x - 3, y), Pt(x + w / 2, y - 13), Pt(x + w + 3, y))
        FillRect(g, Color.FromArgb(90, 55, 30), x + w / 2 - 4, y + h - 12, 8, 12)
        FillRect(g, Color.FromArgb(255, 235, 150), x + 4, y + 5, 6, 6)
    End Sub

    Private Shared Sub VillageIcon(g As Graphics)
        FillRect(g, Color.FromArgb(100, 160, 80), 0, 52, 100, 8)
        House(g, 10, 32, 30, 22, Color.FromArgb(240, 225, 190), Color.FromArgb(170, 70, 50))
        House(g, 52, 24, 38, 30, Color.FromArgb(225, 205, 170), Color.FromArgb(70, 70, 95))
    End Sub

    Private Shared Sub WasteIcon(g As Graphics)
        FillRect(g, Color.FromArgb(150, 125, 95), 0, 44, 100, 16)
        ' cracks in the ground
        DrawLn(g, Color.FromArgb(90, 70, 50), 1.5F, 8, 50, 22, 54)
        DrawLn(g, Color.FromArgb(90, 70, 50), 1.5F, 22, 54, 30, 58)
        DrawLn(g, Color.FromArgb(90, 70, 50), 1.5F, 70, 48, 84, 54)
        ' dead tree
        Dim bark As Color = Color.FromArgb(80, 55, 35)
        DrawLn(g, bark, 4, 30, 50, 30, 20)
        DrawLn(g, bark, 2.5F, 30, 36, 18, 24)
        DrawLn(g, bark, 2.5F, 30, 31, 42, 16)
        DrawLn(g, bark, 2.5F, 30, 25, 24, 12)
        ' boulders
        FillOval(g, Color.FromArgb(120, 115, 110), 58, 38, 22, 14)
        FillOval(g, Color.FromArgb(140, 135, 130), 78, 44, 16, 10)
    End Sub

    Private Shared Sub HarborIcon(g As Graphics)
        ' sails and mast
        DrawLn(g, Color.FromArgb(90, 60, 30), 2, 50, 36, 50, 5)
        FillPoly(g, Color.White, Pt(52, 7), Pt(52, 33), Pt(76, 33))
        FillPoly(g, Color.FromArgb(235, 235, 225), Pt(48, 13), Pt(48, 33), Pt(30, 33))
        ' hull
        FillPoly(g, Color.FromArgb(130, 85, 45), Pt(20, 34), Pt(80, 34), Pt(70, 49), Pt(30, 49))
        ' sea
        Wave(g, Color.FromArgb(40, 120, 200), 5, 50)
        Wave(g, Color.FromArgb(90, 165, 235), 5, 57)
    End Sub

    ' ---------- small icons ----------
    Public Shared Sub DrawCoin(g As Graphics, r As RectangleF)
        FillOval(g, Color.FromArgb(255, 205, 40), r.X, r.Y, r.Width, r.Height)
        Using p As New Pen(Color.FromArgb(170, 115, 10), Math.Max(1.5F, r.Width / 10))
            g.DrawEllipse(p, r.X, r.Y, r.Width, r.Height)
            Dim inset As Single = r.Width * 0.22F
            g.DrawEllipse(p, r.X + inset, r.Y + inset, r.Width - 2 * inset, r.Height - 2 * inset)
        End Using
        FillOval(g, Color.FromArgb(120, 255, 255, 255), r.X + r.Width * 0.2F, r.Y + r.Height * 0.12F,
                 r.Width * 0.25F, r.Height * 0.15F)
    End Sub

    Public Shared Sub DrawSoldier(g As Graphics, r As RectangleF)
        Dim cx As Single = r.X + r.Width * 0.45F
        Dim d As Single = r.Width * 0.4F
        Dim headY As Single = r.Y + r.Height * 0.12F

        ' spear
        DrawLn(g, Color.FromArgb(120, 85, 50), Math.Max(1.5F, r.Width * 0.07F),
               r.X + r.Width * 0.88F, r.Y + r.Height, r.X + r.Width * 0.88F, r.Y + r.Height * 0.05F)
        FillPoly(g, Color.Silver, Pt(r.X + r.Width * 0.88F, r.Y),
                 Pt(r.X + r.Width * 0.8F, r.Y + r.Height * 0.2F),
                 Pt(r.X + r.Width * 0.96F, r.Y + r.Height * 0.2F))
        ' body
        FillRect(g, Color.FromArgb(60, 100, 200), cx - r.Width * 0.27F, r.Y + r.Height * 0.52F,
                 r.Width * 0.54F, r.Height * 0.48F)
        ' head + helmet
        FillOval(g, Color.FromArgb(240, 200, 160), cx - d / 2, headY, d, d)
        Using b As New SolidBrush(Color.FromArgb(170, 175, 190))
            g.FillPie(b, cx - d / 2 - 1, headY - 1, d + 2, d + 2, 180, 180)
        End Using
    End Sub

    Public Shared Sub DrawSwords(g As Graphics, r As RectangleF)
        Dim w As Single = Math.Max(2.5F, r.Width * 0.08F)
        Dim brown As Color = Color.FromArgb(110, 70, 30)
        ' blades
        DrawLn(g, Color.Gainsboro, w, r.X + r.Width * 0.2F, r.Y + r.Height * 0.8F, r.X + r.Width * 0.9F, r.Y + r.Height * 0.1F)
        DrawLn(g, Color.Gainsboro, w, r.X + r.Width * 0.8F, r.Y + r.Height * 0.8F, r.X + r.Width * 0.1F, r.Y + r.Height * 0.1F)
        ' cross-guards and handles
        DrawLn(g, brown, w, r.X + r.Width * 0.12F, r.Y + r.Height * 0.72F, r.X + r.Width * 0.28F, r.Y + r.Height * 0.88F)
        DrawLn(g, brown, w, r.X + r.Width * 0.2F, r.Y + r.Height * 0.8F, r.X + r.Width * 0.08F, r.Y + r.Height * 0.92F)
        DrawLn(g, brown, w, r.X + r.Width * 0.72F, r.Y + r.Height * 0.88F, r.X + r.Width * 0.88F, r.Y + r.Height * 0.72F)
        DrawLn(g, brown, w, r.X + r.Width * 0.8F, r.Y + r.Height * 0.8F, r.X + r.Width * 0.92F, r.Y + r.Height * 0.92F)
    End Sub

    Public Shared Sub DrawFlag(g As Graphics, r As RectangleF, c As Color)
        DrawLn(g, Color.FromArgb(230, 230, 230), Math.Max(2.0F, r.Width * 0.09F),
               r.X + r.Width * 0.2F, r.Y + r.Height, r.X + r.Width * 0.2F, r.Y)
        FillPoly(g, c, Pt(r.X + r.Width * 0.2F, r.Y), Pt(r.X + r.Width * 0.95F, r.Y + r.Height * 0.25F),
                 Pt(r.X + r.Width * 0.2F, r.Y + r.Height * 0.5F))
    End Sub

    Public Shared Sub DrawClock(g As Graphics, r As RectangleF)
        FillOval(g, Color.WhiteSmoke, r.X, r.Y, r.Width, r.Height)
        Using p As New Pen(Color.FromArgb(60, 60, 80), Math.Max(1.5F, r.Width / 10))
            g.DrawEllipse(p, r.X, r.Y, r.Width, r.Height)
        End Using
        Dim cx As Single = r.X + r.Width / 2
        Dim cy As Single = r.Y + r.Height / 2
        DrawLn(g, Color.FromArgb(60, 60, 80), 2, cx, cy, cx, r.Y + r.Height * 0.2F)
        DrawLn(g, Color.FromArgb(60, 60, 80), 2, cx, cy, r.X + r.Width * 0.75F, cy)
    End Sub

    ' ---------- make a ready-to-use Bitmap (for PictureBoxes) ----------
    Public Shared Function MakeBitmap(kind As String, w As Integer, h As Integer) As Bitmap
        Dim bmp As New Bitmap(w, h)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.SmoothingMode = SmoothingMode.AntiAlias
            Dim r As New RectangleF(1, 1, w - 2, h - 2)

            Select Case kind
                Case "coin"
                    DrawCoin(g, r)
                Case "soldier"
                    DrawSoldier(g, r)
                Case "swords"
                    DrawSwords(g, r)
                Case "flag"
                    DrawFlag(g, r, Color.FromArgb(70, 130, 255))
                Case "clock"
                    DrawClock(g, r)
                Case Else
                    DrawTerrain(g, kind, r)   ' e.g. "Capital"
            End Select
        End Using
        Return bmp
    End Function

    ' A terrain picture with its own background (for the info panel)
    Public Shared Function MakeTerrainBitmap(name As String, w As Integer, h As Integer) As Bitmap
        Dim bmp As New Bitmap(w, h)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.SmoothingMode = SmoothingMode.AntiAlias

            Dim c1 As Color
            Dim c2 As Color
            TerrainColors(name, c1, c2)

            Dim rect As New RectangleF(1, 1, w - 3, h - 3)
            Using path As GraphicsPath = RoundedRect(rect, 10)
                Using b As New LinearGradientBrush(rect, c1, c2, 90.0F)
                    g.FillPath(b, path)
                End Using
                Using p As New Pen(Color.FromArgb(60, 40, 20), 2)
                    g.DrawPath(p, path)
                End Using
            End Using

            DrawTerrain(g, name, New RectangleF(8, 6, w - 16, h - 12))
        End Using
        Return bmp
    End Function

End Class
