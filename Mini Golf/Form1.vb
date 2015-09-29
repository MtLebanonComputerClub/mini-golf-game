
Imports Mini_Golf.Obstacle
Public Class MiniGolf 'Title Screen
    Public Property graphics As Graphics
    Private Sub MiniGolf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.graphics = Me.CreateGraphics()
        'test.inCollisionWith(ball)
    End Sub

    Private Sub btnDraw_Click(sender As Object, e As EventArgs) Handles btnDraw.Click
        Dim obs = New Obstacle(New Point(0, 0), New Size(100, 100))
        Dim black = New Pen(Brushes.Black, 1)
        graphics.DrawRectangle(black, obs.graphic)
    End Sub
End Class
