Public Class UnitStatChange
    Private _StatName As String
    Private _AlteredStatValue As String
    Private _OriginalStatValue As String

    Public ReadOnly Property StatName As String
        Get
            Return _StatName
        End Get
    End Property
    Public ReadOnly Property AlteredStatValue As String
        Get
            Dim altStatToReturn As String = _AlteredStatValue
            If _AlteredStatValue.StartsWith("+") OrElse _AlteredStatValue.StartsWith("-") Then
                Select Case StatName
                    Case "UnitStrength"
                        Dim altStat As Integer = _AlteredStatValue
                        altStatToReturn = _OriginalStatValue + altStat
                    Case "Nerve"
                        If OriginalStatValue = "" Then
                            OriginalStatValue = "0/0"
                        End If

                        Dim oWaver As Integer = _OriginalStatValue.Split("/").FirstOrDefault
                        Dim oRout As Integer = _OriginalStatValue.Split("/").LastOrDefault

                        Dim altWaver As Integer = _AlteredStatValue.Split("/").FirstOrDefault
                        Dim altRout As Integer = _AlteredStatValue.Split("/").LastOrDefault

                        altStatToReturn = oWaver + altWaver & "/" & oRout + altRout
                    Case "Speed"
                        Dim altStat As Integer = _AlteredStatValue
                        altStatToReturn = _OriginalStatValue + altStat
                    Case "Attacks"
                        Dim altStat As Integer = _AlteredStatValue
                        altStatToReturn = _OriginalStatValue + altStat
                    Case "Melee"
                        Dim altStat As Integer = _AlteredStatValue
                        altStatToReturn = _OriginalStatValue + altStat
                    Case "Range"
                        Dim altStat As Integer = _AlteredStatValue
                        altStatToReturn = _OriginalStatValue + altStat
                    Case "Defense"
                        Dim altStat As Integer = _AlteredStatValue
                        altStatToReturn = _OriginalStatValue + altStat
                    Case "Height"
                        Dim altStat As Integer = _AlteredStatValue
                        altStatToReturn = _OriginalStatValue + altStat
                End Select
            End If
            Return altStatToReturn
        End Get
    End Property
    Public Property OriginalStatValue As String
        Get
            Return _OriginalStatValue
        End Get
        Set(value As String)
            _OriginalStatValue = value
        End Set
    End Property

    Public Sub New(statName As String, alteredStatValue As String, originalStatValue As String)
        _StatName = statName
        _OriginalStatValue = originalStatValue
        _AlteredStatValue = alteredStatValue
    End Sub

    Public Sub New(unitStatChangeToCopy As UnitStatChange)
        _StatName = unitStatChangeToCopy.StatName
        _AlteredStatValue = unitStatChangeToCopy._AlteredStatValue
        _OriginalStatValue = unitStatChangeToCopy.OriginalStatValue
    End Sub
End Class
