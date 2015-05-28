Public Class Interaction_Interface
    Function friction(ball As Obstacle.Ball, surface As Obstacle.Surface) 'still need surface object
        Dim tot As Integer = ball.history.Length
        protected v1 as Integer=ball.gethistory(tot-)-ball.gethistory(tot-2)
        protected frict as Integer=surface.getfriction();
        protected out As Integer=-frict+v1+ball.gethistory(tot-1);
        Return out
    End Function
End Class
