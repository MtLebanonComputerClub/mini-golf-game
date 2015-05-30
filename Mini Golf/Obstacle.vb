Public Class Obstacle   'COPIED FROM COURSEOBJECTS BRANCH AS OF 27/5/2015
    Public Class Course_Item
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

        Public Sub generateBounds() 'This sub finds the points (or edges) of the obstacle ToDo: Add the microsoft's included hitboxes to the mix
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

    Public Class Obstacle
        Inherits Course_Item
        Dim bouciness As Decimal 'Maybe use this value later
        Dim soundFilePath As String 'The path of the sound file to be played when the ball hits the obstacle
        Public angle As Double                                                                                                                                    'NEED THIS, make getter method later
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

    Public Class Ball 'The class for the golf ball (yeah)
        Inherits Course_Item
        Dim player As String
        Dim player_number As Integer
        Public historyX As Array                                                                                                                                'NEED THESE
        Public historyY As Array

        Public Sub New(position As Point, size As Size, historyX As Array, historyY As Array)
            MyBase.New(position, size)
            Me.historyX = historyX
            Me.historyY = historyY
        End Sub

    End Class
    Public Class Surface                                                                                                                                        'NEED THIS
        Inherits Course_Item
        Public friction As Integer
        Public Sub New(position As Point, size As Size, friction As Integer)
            MyBase.New(position, size)
            Me.friction = friction
        End Sub
    End Class
End Class
