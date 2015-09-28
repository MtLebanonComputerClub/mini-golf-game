
Imports Mini_Golf.Obstacle
Public Class MiniGolf 'Title Screen

    Private Sub MiniGolf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim test As Obstacle = New Obstacle(New Point(32, 42), New Size(32, 432))
        Console.WriteLine(test.bounds(0))
        Dim ball As Ball = New Ball(New Point(32, 23), New Size(32, 42))
        'test.inCollisionWith(ball)
    End Sub
End Class
