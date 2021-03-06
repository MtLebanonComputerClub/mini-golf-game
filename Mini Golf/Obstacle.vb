﻿Public Class Velocity
    Public Property X As Double
    Public Property Y As Double
End Class

Public Class Course_Item
    Public Property position As Point 'The position of the object
    Public Property size As Size 'The size of an object, this should be the distance from the center to the edge
    Public Property graphic As Image 'Not entirely sure if this should be in the general class
    Public Property bounds As ArrayList 'Very general, overide this property for a specific shape, if we decide to make a ball not a cube
    Public Property angle As Integer 'Degree measurment that tilts the object

    Public Sub New(position As Point, size As Size) 'This initializes the class, overide
        Me.position = position
        Me.size = size
        Me.bounds = New ArrayList()
        Me.angle = 0

        generateBounds()
    End Sub

    Public Sub New(x As Integer, y As Integer, size As Size) 'A different init
        Me.New(New Point(x, y), size)
    End Sub

    'DO NOT USE THIS SUB!  It has never been tested and probably doesn't work :)
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

    Public Sub generateBounds()
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
        Me.generateSkewedBounds()
    End Sub

    Public Sub moveToAbsolutePosition(x As Integer, y As Integer)
        Me.position = New Point(x, y)
    End Sub

    Public Sub moveByIncrements(xIncrement As Integer, yIncrement As Integer)
        Me.position = New Point(Me.position.X + xIncrement, Me.position.Y + yIncrement)
    End Sub


    Public Function distance(point1 As Point, point2 As Point) As Decimal 'Returns the distance between two objects (will remove from this object)
        Return Math.Sqrt(Math.Pow((point2.X - point1.X), 2) + Math.Pow((point2.Y - point1.Y), 2))
    End Function
End Class

Public Class Surface
    Inherits Course_Item
    Public Property friction As Double

    Public Sub New(position As Point, size As Size, friction As Double)
        MyBase.New(position, size)
        Me.friction = friction
    End Sub
End Class

Public Class Obstacle 'The obstacle position represents the top left corner of the rectangle
    Inherits Course_Item
    Public Overloads Property graphic As Rectangle 'The actual drawing shape of the obstacle
    Public Property bouciness As Decimal 'Maybe use this value later
    Public Property soundFilePath As String 'The path of the sound file to be played when the ball hits the obstacle
    Public Property color As Color

    Public Sub New(position As Point, size As Size)
        MyBase.New(position, size)
        graphic = New Rectangle(Me.position, Me.size)
    End Sub

    Public Sub Draw(graphics As Graphics)
        graphics.FillRectangle(New SolidBrush(Me.color), Me.graphic)
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
    Public Property radius As Integer
    Public Property color As Color

    Public Sub New(position As Point, radius As Integer)
        MyBase.New(position, New Size(radius, radius)) 'Might not want to call the super constructor here
        Me.radius = radius
    End Sub

    Public Sub Draw(graphics As Graphics)
        graphics.FillEllipse(New SolidBrush(Me.color), Me.position.X - radius, Me.position.Y - radius, Me.radius, Me.radius)
    End Sub
End Class

Public Class Hole
    Inherits Circular_Obstacle

    Public Sub New(position As Point, radius As Integer)
        MyBase.New(position, radius)
        Me.radius = Me.size.Width 'Or the height, both are the same
    End Sub

    Public Overloads Sub generateBounds() 'TODO: Decide if we will use a square hitbox or make it circular

    End Sub
End Class

Public Class Ball 'The class for the golf ball 
    Inherits Course_Item

    Public Property radius As Integer
    Public Property velocity As Velocity
    Public Property player As String
    Public Property player_number As Integer

    Public Sub New(position As Point, radius As Integer)
        MyBase.New(position, New Size(radius, radius))
    End Sub

End Class
