Imports Microsoft.VisualBasic

Public Class ObstacleTests
    Public Shared Function preformAllTests()
        testBounds()
    End Function

    Private Shared Sub testBounds()
        Dim target = New Obstacle(New Point(0, 0), New Size(100, 100))
    End Sub
End Class