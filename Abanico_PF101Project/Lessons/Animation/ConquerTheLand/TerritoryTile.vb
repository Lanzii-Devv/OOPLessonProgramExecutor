Imports System.Drawing.Drawing2D
Imports System.Drawing.Text

' ============================================================
' TerritoryTile.vb
' A custom control that DRAWS one territory card.
'
' Instead of a Panel + Label, we override OnPaint and draw
' everything ourselves with GDI+. Windows calls OnPaint whenever
' the control needs redrawing; the Form just calls Invalidate()
' to say "my data changed, please redraw".
' ============================================================

Public Class TerritoryTile
    Inherits Control

    Public Property Data As Territory       ' the territory this tile shows
    Public Property IsSelected As Boolean
    Public Property IsTarget As Boolean

    Private isHover As Boolean

    Public Sub New()
        ' DoubleBuffered painting = no flicker
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.UserPaint Or
                    ControlStyles.OptimizedDoubleBuffer Or
                    ControlStyles.ResizeRedraw, True)
        Me.Cursor = Cursors.Hand
    End Sub

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        isHover = True
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        isHover = False
        Invalidate()
    End Sub

    ' ---------- color choices by owner ----------
    Private Function RibbonColor(o As OwnerType) As Color
        Select Case o
            Case OwnerType.Player
                Return Color.FromArgb(40, 100, 220)
            Case OwnerType.Enemy
                Return Color.FromArgb(190, 40, 40)
            Case Else
                Return Color.FromArgb(110, 110, 115)
        End Select
    End Function

    Private Function TintColor(o As OwnerType) As Color
        Select Case o
            Case OwnerType.Player
                Return Color.FromArgb(70, 60, 130, 255)
            Case OwnerType.Enemy
                Return Color.FromArgb(80, 240, 60, 60)
            Case Else
                Return Color.FromArgb(50, 110, 110, 110)
        End Select
    End Function

    ' ---------- the drawing ----------
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        If Data Is Nothing OrElse Width < 60 OrElse Height < 80 Then Return

        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit

        Dim t As Territory = Data
        Dim card As New RectangleF(5, 5, Width - 11, Height - 11)

        Dim c1 As Color
        Dim c2 As Color
        Icons.TerrainColors(t.Name, c1, c2)

        Const RibbonH As Single = 24
        Const PanelH As Single = 52
        Dim panelTop As Single = card.Bottom - PanelH

        Using path As GraphicsPath = Icons.RoundedRect(card, 12)

            ' 1) terrain background + owner tint
            Using b As New LinearGradientBrush(card, c1, c2, 90.0F)
                g.FillPath(b, path)
            End Using
            Using b As New SolidBrush(TintColor(t.Owner))
                g.FillPath(b, path)
            End Using

            ' Everything until ResetClip stays inside the rounded card
            g.SetClip(path)

            ' 2) terrain icon
            Dim iconRect As New RectangleF(card.X + 10, card.Y + RibbonH + 4,
                                           card.Width - 20, panelTop - (card.Y + RibbonH) - 8)
            If iconRect.Height > 10 Then
                Icons.DrawTerrain(g, t.Name, iconRect)
            End If

            ' 3) owner ribbon (top)
            Using b As New SolidBrush(RibbonColor(t.Owner))
                g.FillRectangle(b, card.X, card.Y, card.Width, RibbonH)
            End Using
            DrawLabel(g, "[" & t.OwnerSymbol & "] " & t.OwnerText.ToUpper(), 9, Color.White,
                      New RectangleF(card.X, card.Y, card.Width, RibbonH), StringAlignment.Center)

            ' 4) dark info panel (bottom)
            Using b As New SolidBrush(Color.FromArgb(185, 18, 18, 30))
                g.FillRectangle(b, card.X, panelTop, card.Width, PanelH)
            End Using

            DrawLabel(g, t.Name.ToUpper(), 10, Color.White,
                      New RectangleF(card.X + 4, panelTop + 2, card.Width - 8, 22), StringAlignment.Center)

            Dim rowY As Single = panelTop + 25
            Dim halfX As Single = card.X + card.Width / 2

            Icons.DrawSoldier(g, New RectangleF(card.X + 8, rowY, 20, 20))
            DrawLabel(g, t.Soldiers & "/" & t.MaxSoldiers, 9, Color.White,
                      New RectangleF(card.X + 32, rowY, halfX - card.X - 34, 20), StringAlignment.Near)

            Icons.DrawCoin(g, New RectangleF(halfX + 2, rowY, 20, 20))
            DrawLabel(g, "+" & t.GoldProduction & "/turn", 9, Color.Gold,
                      New RectangleF(halfX + 26, rowY, card.Right - halfX - 28, 20), StringAlignment.Near)

            ' soldier capacity bar
            Dim barX As Single = card.X + 8
            Dim barW As Single = card.Width - 16
            Dim barY As Single = card.Bottom - 7
            Dim ratio As Single = 0
            If t.MaxSoldiers > 0 Then ratio = CSng(t.Soldiers) / t.MaxSoldiers
            ratio = Math.Max(0, Math.Min(1, ratio))

            Using b As New SolidBrush(Color.FromArgb(70, 255, 255, 255))
                g.FillRectangle(b, barX, barY, barW, 4)
            End Using
            Dim barColor As Color = Color.FromArgb(200, 200, 200)
            If t.Owner = OwnerType.Player Then barColor = Color.FromArgb(90, 170, 255)
            If t.Owner = OwnerType.Enemy Then barColor = Color.FromArgb(255, 110, 110)
            Using b As New SolidBrush(barColor)
                g.FillRectangle(b, barX, barY, barW * ratio, 4)
            End Using

            ' 5) battle overlay
            If t.IsUnderAttack Then
                Using b As New SolidBrush(Color.FromArgb(110, 255, 20, 20))
                    g.FillRectangle(b, card)
                End Using
                Dim sz As Single = Math.Min(48.0F, Math.Max(20.0F, iconRect.Height - 14))
                Icons.DrawSwords(g, New RectangleF(card.X + (card.Width - sz) / 2, iconRect.Y + 2, sz, sz))
                DrawLabel(g, "UNDER ATTACK!", 9, Color.White,
                          New RectangleF(card.X, panelTop - 20, card.Width, 18), StringAlignment.Center)
            End If

            ' 5b) enemy warning: the enemy has picked this territory as its next target
            If t.IsThreatened AndAlso Not t.IsUnderAttack Then
                Using b As New SolidBrush(Color.FromArgb(70, 255, 170, 0))
                    g.FillRectangle(b, card)
                End Using

                Dim sz As Single = Math.Min(44.0F, Math.Max(20.0F, iconRect.Height - 14))
                Dim cx As Single = card.X + card.Width / 2
                Dim top As Single = iconRect.Y + 2
                Dim tri() As PointF = {New PointF(cx, top),
                                       New PointF(cx - sz / 2, top + sz * 0.85F),
                                       New PointF(cx + sz / 2, top + sz * 0.85F)}
                Using b As New SolidBrush(Color.FromArgb(255, 210, 0))
                    g.FillPolygon(b, tri)
                End Using
                Using p As New Pen(Color.FromArgb(120, 70, 0), 2)
                    g.DrawPolygon(p, tri)
                End Using
                DrawLabel(g, "!", 13, Color.Black, New RectangleF(cx - 15, top + sz * 0.3F, 30, sz * 0.55F), StringAlignment.Center)
                DrawLabel(g, "ENEMY INCOMING " & t.ThreatSeconds, 9, Color.Yellow,
                          New RectangleF(card.X, panelTop - 20, card.Width, 18), StringAlignment.Center)
            End If

            ' 6) hover glow
            If isHover Then
                Using b As New SolidBrush(Color.FromArgb(35, 255, 255, 255))
                    g.FillRectangle(b, card)
                End Using
            End If

            g.ResetClip()

            ' 7) border: gold = selected, orange = target, red = battle
            Dim borderColor As Color = Color.FromArgb(40, 40, 55)
            Dim borderWidth As Single = 3
            If t.Owner = OwnerType.Player Then borderColor = Color.FromArgb(30, 80, 190)
            If t.Owner = OwnerType.Enemy Then borderColor = Color.FromArgb(150, 30, 30)
            If t.IsUnderAttack Then
                borderColor = Color.FromArgb(255, 40, 40)
                borderWidth = 4
            End If
            If IsTarget Then
                borderColor = Color.FromArgb(255, 140, 0)
                borderWidth = 5
            End If
            If IsSelected Then
                borderColor = Color.FromArgb(255, 215, 0)
                borderWidth = 5
                Using glow As New Pen(Color.FromArgb(100, 255, 215, 0), 11)
                    g.DrawPath(glow, path)
                End Using
            End If

            Using p As New Pen(borderColor, borderWidth)
                g.DrawPath(p, path)
            End Using
        End Using
    End Sub

    ' Text with a little drop-shadow so it's readable on any background
    Private Sub DrawLabel(g As Graphics, text As String, size As Single, c As Color,
                          r As RectangleF, align As StringAlignment)
        Using f As New Font("Segoe UI", size, FontStyle.Bold)
            Using sf As New StringFormat()
                sf.Alignment = align
                sf.LineAlignment = StringAlignment.Center
                sf.Trimming = StringTrimming.EllipsisCharacter
                sf.FormatFlags = StringFormatFlags.NoWrap

                Using sb As New SolidBrush(Color.FromArgb(170, 0, 0, 0))
                    g.DrawString(text, f, sb, New RectangleF(r.X + 1, r.Y + 1, r.Width, r.Height), sf)
                End Using
                Using b As New SolidBrush(c)
                    g.DrawString(text, f, b, r, sf)
                End Using
            End Using
        End Using
    End Sub

End Class