Public Class Course_Item
    Public Property position As Point 'The point of the center of the object
    Public Property size As Size 'The size of an object, this should be the distance from the center to the edge
    Public Property image As Image 'Not entirely sure if this should be in the general class
    Public Property bounds As ArrayList 'Very general, overide this property for a specific shape, if we decide to make a ball not a cube
    Public Property angle As Integer 'Degree measurment that tilts the object

    Public Sub New(position As Point, size As Size) 'This initializes the class, overide
        Me.position = position
        Me.size = size
        Me.bounds = New ArrayList()
        Me.angle = 0

        generateBounds()
    End Sub
    'DO NOT USE THIS METHOD!  It has never been tested and probably doesn't work :)
    Public Sub generateSkewedBounds() 'This sub finds the points (or edges) of the obstacle
        Dim xincrement As Array = {Me.size.Width * Math.Cos(Me.angle), Me.size.Height * Math.Cos(180 - Me.angle), -Me.size.Width * Math.Cos(Me.angle), -Me.size.Height * Math.Cos(180 - Me.angle)}
        Dim yincrement As Array = {Me.size.Width * Math.Sin(Me.angle), Me.size.Height * Math.Sin(180 - Me.angle), -Me.size.Width * Math.Sin(Me.angle), -Me.size.Height * Math.Sin(180 - Me.angle)}

        For i As Integer = 0 To 3
            Dim xvalue As Integer
            Dim yvalue As Integer
            xvalue = Me.position.X + xincrement(i)
            yvalue = Me.position.Y + yincrement(i)

            Me.bounds.Add(New Point(xvalue, yvalue))
        Next
    End Sub

    Public Sub generateBounds() 'TODO: Eliminate the extra "/2"s
        Dim height As Double = Me.size.Height / 2
        Dim width As Double = Me.size.Width / 2
        Dim xIncrement As Array = {width, width, -width, -width}
        Dim yIncrement As Array = {height, -height, height, -height}

        For i As Integer = 0 To 3
            Me.bounds.Add(New Point(Me.position.X + xIncrement(i), Me.position.Y + yIncrement(i)))
        Next
    End Sub

    Public Sub rotate(angle As Integer)
        Me.angle = angle
        Me.generateBounds()
    End Sub

    Public Function distance(point1 As Point, point2 As Point) As Decimal 'Returns the distance between two objects (will remove from this object)
        Return Math.Sqrt(Math.Pow((point2.X - point1.X), 2) + Math.Pow((point2.Y - point1.Y), 2))
    End Function
End Class

Public Class Obstacle
    Inherits Course_Item
    Dim bouciness As Decimal 'Maybe use this value later
    Dim soundFilePath As String 'The path of the sound file to be played when the ball hits the obstacle

    Public Sub New(position As Point, size As Size)
        MyBase.New(position, size)
    End Sub

    Public Function playSound() As Boolean
        If Me.soundFilePath Then
            My.Computer.Audio.Play(Me.soundFilePath, AudioPlayMode.Background)
            Return True
        Else
            Return False
        End If
    End Function
End Class

Public Class Circular_Obstacle 'For the future, disregard this for the time being.  This is also for the hole or a circular item on the board
    Inherits Course_Item
    Dim radius As Decimal

    Public Sub New(position As Point, size As Size)
        MyBase.New(position, size)
    End Sub
End Class

Public Class Hole
    Inherits Circular_Obstacle
    Dim radius As Decimal

    Public Sub New(position As Point, size As Size)
        MyBase.New(position, size)
        Me.radius = Me.size.Width 'Or the height, both are the same
    End Sub

    Public Overloads Sub generateBounds()

    End Sub
End Class

Public Class Ball 'The class for the golf bal
    Inherits Course_Item
    Dim player As String
    Dim player_number As Integer

    Public Sub New(position As Point, size As Size)
        MyBase.New(position, size)
    End Sub

End Class
