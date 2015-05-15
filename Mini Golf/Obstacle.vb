Public Class Obstacle
    Public Property position As Point 'The point of the center of the object
    Public Property size As Size 'The size of an object, this should be the distance from the center to the edge
    Public Property image As Image 'Not entirely sure if this should be in the general class
    Public Property bounds As ArrayList 'Very general, overide this property for a specific shape, if we decide to make a ball not a cube

    Public Sub New(position As Point, size As Size) 'This initializes the class, overide
        Me.position = position
        Me.size = size
        Me.bounds = New ArrayList()

        generateBounds()
    End Sub

    Public Sub generateBounds() 'This sub finds the points (or edges) of the obstacle
        Dim xincrement As Array = {-Me.size.Width, -Me.size.Width, Me.size.Width, Me.size.Width}
        Dim yincrement As Array = {-Me.size.Height, Me.size.Height, Me.size.Height, -Me.size.Height}

        For i As Integer = 0 To 3
            Dim xvalue As Integer
            Dim yvalue As Integer
            xvalue = Me.position.X + xincrement(i)
            yvalue = Me.position.Y + yincrement(i)

            Me.bounds.Add(New Point(xvalue, yvalue))
        Next
    End Sub
End Class

Public Class CircularObstacle
    Inherits Obstacle

    Public Sub New(position As Point, size As Size) 'For the future, disregard this for the time being
        MyBase.New(position, size)
    End Sub
End Class
