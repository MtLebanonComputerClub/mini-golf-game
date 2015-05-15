Public Class Interaction_Interface
    Public Sub friction(ball As Ball, surface as Surface)'Still need Ball object, Surface object
        'using Java syntax, since there is no autofill on this
        Dim i as Int=ball.getHistory.length()
        Dim v1 as Int=ball.getHistory[i-1]-ball.getHistory[i-2]
        Dim frict as Int=surface.getFriction();
        Dim out=-frict+v1+ball.getHistory[i-1];
        return out
    End Sub
End Class
