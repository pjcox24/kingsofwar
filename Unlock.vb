Public Class Unlock
    Private _Used As Boolean
    Private _Types As List(Of UnitType)
    Private _DoubleUnlock As Boolean
    Private _FirstType As UnitType

    Public Sub New(types As List(Of UnitType), doubleUnlock As Boolean)
        _Types = types
        _DoubleUnlock = doubleUnlock
    End Sub



End Class
