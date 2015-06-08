Public Class Captain
    Private Property balls As ArrayList
    Private Property walls As ArrayList
    Private Property surfaces As ArrayList
    Private Property holes As ArrayList

    Dim path As ArrayList 'Test, come back to this when you know what you are doing
    Public Function inCollisionWith(target As Object) As Boolean 'Function assumes a rectangular hitbox, will update for circular later.  Also, assumes the obstacle is a rect.
        Dim type As Type = target.GetType()
        If Me.GetType().Name = "Obstacle" And type.Name = "Ball" Then 'If the object can be used with this function.  Used to prevent errors
            Dim xDistance As Integer = Math.Abs(Me.position.X - target.position.X)
            Dim yDistance As Integer = Math.Abs(Me.position.Y - target.position.Y)
            Dim xCollideDistance As Integer = Me.size.Width + target.size.Width
            Dim yCollideDistance As Integer = Me.size.Height + target.size.Height
            If xDistance <= xCollideDistance And yDistance <= yCollideDistance Then
                Return True
            End If
            Return False
        End If
        Dim err As Exception = New Exception("Type " & type.Name & " is not compatable with this method") 'Throws an error when the wrong type is used
        Throw err
    End Function
    Public Sub findNear(ball As Ball)
        'Check all surroudings and call proper physics functions
        'Split into separate functions that find the nearest walls, surfaces, and holes
    End Sub
End Class
