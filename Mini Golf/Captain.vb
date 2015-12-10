Public Class Captain
    Private Property balls As ArrayList 'The list that contains all the balls
    Private Property walls As ArrayList 'Contains all the walls (regular obstacles)
    Private Property surfaces As ArrayList 'Contains all the surfaces
    Private Property holes As ArrayList 'Contains all the holes

    Dim path As ArrayList

    Public Sub findNear(ball As Label)
        'Check all surroudings and call proper physics functions
        'Split into separate functions that find the nearest walls, surfaces, and holes
    End Sub
End Class
