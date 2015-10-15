
Imports Mini_Golf.Obstacle
Imports Mini_Golf.ObstacleTests

Public Class MiniGolf 'Title Screen
    Public Property graphics As Graphics
    Private Sub MiniGolf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.graphics = Me.CreateGraphics()
        Me.tmrTest.Start()
        'test.inCollisionWith(ball)
    End Sub

    Private Sub btnDraw_Click(sender As Object, e As EventArgs) Handles btnDraw.Click
        Dim obs = New Obstacle(New Point(50, 50), New Size(100, 15))
        Dim circle = New Circular_Obstacle(New Point(100, 100), 20)
        obs.color = Drawing.Color.DarkBlue
        circle.color = Drawing.Color.Cyan
        circle.Draw(graphics)
        obs.Draw(graphics)
    End Sub

    Private Sub tmrTest_Tick(sender As Object, e As EventArgs) Handles tmrTest.Tick
        Me.Title.Location = New Point(Me.Title.Location.X + 1, Me.Title.Location.Y)
    End Sub
End Class
