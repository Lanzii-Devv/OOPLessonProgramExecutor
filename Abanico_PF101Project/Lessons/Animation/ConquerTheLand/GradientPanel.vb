Imports System.Drawing.Drawing2D

' A FlowLayoutPanel that paints a left-to-right color gradient
' as its background (used for the top information bar).
Public Class GradientPanel
    Inherits FlowLayoutPanel

    Public Property Color1 As Color = Color.FromArgb(25, 30, 60)
    Public Property Color2 As Color = Color.FromArgb(85, 60, 110)

    Public Sub New()
        Me.DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
        If ClientRectangle.Width > 0 AndAlso ClientRectangle.Height > 0 Then
            Using b As New LinearGradientBrush(ClientRectangle, Color1, Color2, 0.0F)
                e.Graphics.FillRectangle(b, ClientRectangle)
            End Using
        End If
    End Sub

    Protected Overrides Sub OnResize(eventargs As EventArgs)
        MyBase.OnResize(eventargs)
        Me.Invalidate()
    End Sub

End Class
