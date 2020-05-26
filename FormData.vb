Public Class FormData
    Property FormVersion As String = "0.1.0"

#Region "Armies"
    Property ArmyNames As List(Of String)
    Property ArmyLists As List(Of ArmyList)
    Property Units As List(Of KowUnit)
#End Region
End Class
