Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraBars.Controls

Namespace WindowsFormsApplication39
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
            AddHandler Me.MouseMove, AddressOf Form1_MouseMove
            AddHandler Me.Paint, AddressOf Form1_Paint
            AddHandler bar1.VisibleChanged, AddressOf bar1_VisibleChanged

            bar1.Visible = False
        End Sub

        Private Sub bar1_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs)
            If bar1.Visible Then
                Dim control As CustomBarControl = bar1.GetBarControl()
                AddHandler control.MouseLeave, AddressOf control_MouseLeave
            End If
        End Sub

        Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim rect As Rectangle = Me.ClientRectangle
            rect.Width = 20
            If rect.Contains(e.Location) Then
                ShowBar()
            End If
        End Sub
        Private Sub control_MouseLeave(ByVal sender As Object, ByVal e As EventArgs)
            HideBar()
        End Sub

        Private Sub ShowBar()
            bar1.Visible = True
        End Sub

        Private Sub HideBar()
            bar1.Visible = False
        End Sub

        Private Sub Form1_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)
            Dim rect As Rectangle = Me.ClientRectangle
            rect.Width = 20
            e.Graphics.FillRectangle(Brushes.AliceBlue, rect)

            Dim drawString As String = "Hover this region to show Bar"

            Dim drawBrush As New System.Drawing.SolidBrush(System.Drawing.Color.Black)
            Dim drawFormat As New System.Drawing.StringFormat(StringFormatFlags.DirectionVertical)
            e.Graphics.DrawString(drawString, Me.Font, drawBrush, 3, 3, drawFormat)
        End Sub
    End Class
End Namespace
