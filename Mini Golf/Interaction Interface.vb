Public Class Interaction_Interface
    Function friction(ball As Obstacle.Ball, surface As Obstacle.Surface) 'still need surface object            Returns x and y separate
        Dim initVelocities As Array = getVelocities(ball.historyX, ball.historyY)
        Dim frict As Integer = surface.friction
        Dim out As Array = {initVelocities(0) - frict, initVelocities(1) - frict}
        Return out
    End Function
    Function collide(ball As Obstacle.Ball, obstacle As Obstacle.Obstacle)
        'call reorient, gives me the value to negate...I may as well just stick that in here?
        Return vbNull
    End Function
    Function reorient(obstacle As Obstacle.Obstacle, ball As Obstacle.Ball) 'If we ever move beyond 90 degrees
        Dim preTurnV As Array = getVelocities(ball.historyX, ball.historyY)
        Dim angle As Double = obstacle.angle
        Dim postTurnVX As Integer = preTurnV(0) * Math.Cos(angle) + preTurnV(1) * Math.Sin(angle) 'turning the ball veolocity vectors
        Dim postTurnVY As Integer = -(preTurnV(0) * Math.Sin(angle) + preTurnV(1) * Math.Cos(angle)) 'velocity y always flips
        Dim reTurnVX As Integer = postTurnVX * Math.Cos(angle) + postTurnVY * Math.Sin(angle)
        Dim reTurnVY As Integer = postTurnVX * Math.Sin(angle) + postTurnVY * Math.Cos(angle)
        Dim out As Array = {reTurnVX, reTurnVY}
        Return out
    End Function
    Private Function getVelocities(x As Array, y As Array)
        Dim xVelocity As Integer = x(-1) - x(-2)
        Dim yVelocity As Integer = y(-1) - y(-2)
        Dim out As Array = {xVelocity, yVelocity}
        Return out
    End Function
End Class
