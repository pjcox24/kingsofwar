Public Class ArmyList
    Public Property Name As String
    Private _Units As New List(Of KowUnit)

    Property DoubleWildsUsed As New List(Of UnitType)
    Public ReadOnly Property UnitCount() As Integer
        Get
            Return _Units.Count
        End Get
    End Property

    Public ReadOnly Property Units() As List(Of KowUnit)
        Get
            Return _Units
        End Get
    End Property

    Public Sub New(incName As String)
        Name = incName
    End Sub

    Public Sub AddUnit(newUnit As KowUnit)
        _Units.Add(newUnit)
    End Sub

    Public Sub RemoveUnit(unitToRemove As KowUnit)
        For Each kowUnit As KowUnit In _Units
            If kowUnit = unitToRemove Then
                _Units.Remove(kowUnit)
            End If
        Next
    End Sub
    Public Sub RemoveUnit(unitIndex As Integer)
        _Units.RemoveAt(unitIndex)
    End Sub

    Public Function GetPointsTotal() As Integer
        Dim totalPoints As Integer = 0
        For Each kUnit As KowUnit In Units
            totalPoints += kUnit.PointCost
        Next
        Return totalPoints
    End Function

    Public Function GetUnlocksRemaining(newArmyList As ArmyList) As Unlocks
        Dim remainingUnlocks As Unlocks = GetUnlockTotals()
        Dim unlocksLastState As New Unlocks()
        While remainingUnlocks <> unlocksLastState
            unlocksLastState = remainingUnlocks.Copy
            AllocateWildUnlock(remainingUnlocks)
            'MsgBox(remainingUnlocks.ToString)
        End While

        If newArmyList.DoubleWildsUsed.Count <> 0 Then
            For Each kUnit As KowUnit In newArmyList.Units
                kUnit.GeneratedUnlocks.DoubleWildTypes.Clear()
            Next
        End If
        newArmyList.DoubleWildsUsed.Clear()

        Return remainingUnlocks
    End Function

    Private Sub AllocateWildUnlock(remainingUnlocks As Unlocks)
        If remainingUnlocks.UnlockMonster < 0 Then
            If remainingUnlocks.UnlockMonTitan > 0 Then
                remainingUnlocks.UnlockMonster += 1
                remainingUnlocks.UnlockMonTitan -= 1
            ElseIf remainingUnlocks.UnlockDoubleWild > 0 Then
                setDoubleWildUnlocks(UnitType.Monster, remainingUnlocks)

            ElseIf remainingUnlocks.UnlockWild > 0 Then
                remainingUnlocks.UnlockMonster += 1
                remainingUnlocks.UnlockWild -= 1
            Else
                'Not enough unlocks
            End If
        End If
        If remainingUnlocks.UnlockTitan < 0 Then
            If remainingUnlocks.UnlockMonTitan > 0 Then
                remainingUnlocks.UnlockTitan += 1
                remainingUnlocks.UnlockMonTitan -= 1
            ElseIf remainingUnlocks.UnlockDoubleWild > 0 Then
                setDoubleWildUnlocks(UnitType.Titan, remainingUnlocks)
            ElseIf remainingUnlocks.UnlockWild > 0 Then
                remainingUnlocks.UnlockTitan += 1
                remainingUnlocks.UnlockWild -= 1
            Else
                'Not enough unlocks
            End If
        End If
        If remainingUnlocks.UnlockHero < 0 Then
            If remainingUnlocks.UnlockDoubleWild > 0 Then
                setDoubleWildUnlocks(UnitType.HeroInf, remainingUnlocks)
            ElseIf remainingUnlocks.UnlockWild > 0 Then
                remainingUnlocks.UnlockHero += 1
                remainingUnlocks.UnlockWild -= 1
            Else
                'Not enough unlocks
            End If
        End If

        If remainingUnlocks.UnlockWarEngine < 0 Then
            If remainingUnlocks.UnlockDoubleWild > 0 Then
                setDoubleWildUnlocks(UnitType.WarEngine, remainingUnlocks)
            ElseIf remainingUnlocks.UnlockWild > 0 Then
                remainingUnlocks.UnlockWarEngine += 1
                remainingUnlocks.UnlockWild -= 1
            Else
                'Not enough unlocks
            End If
        End If
    End Sub

    Private Function setDoubleWildUnlocks(xType As UnitType, remainingUnlocks As Unlocks) As Unlocks
        For Each kUnit As KowUnit In _Units
            If kUnit.Type = UnitType.LargeInfantry OrElse kUnit.Type = UnitType.MonstrousInfantry OrElse kUnit.Type = UnitType.LargeCavalry Then

                Dim tList As List(Of UnitType) = kUnit.GeneratedUnlocks.DoubleWildTypes
                If tList.Count <= 2 AndAlso Not tList.Contains(xType) Then
                    remainingUnlocks.UnlockDoubleWild -= 1
                    Select Case xType
                        Case UnitType.Monster
                            remainingUnlocks.UnlockMonster += 1
                        Case UnitType.Titan
                            remainingUnlocks.UnlockTitan += 1
                        Case UnitType.HeroInf
                            remainingUnlocks.UnlockHero += 1
                        Case UnitType.WarEngine
                            remainingUnlocks.UnlockWarEngine += 1
                    End Select
                    tList.Add(xType)
                    DoubleWildsUsed.Add(xType)
                    Return remainingUnlocks
                End If
            End If
        Next
        Return remainingUnlocks
    End Function

    Public Function GetUnlockTotals() As Unlocks
        Dim remainingUnlocks As New Unlocks()
        For Each kUnit As KowUnit In _Units
            remainingUnlocks = kUnit.GeneratedUnlocks + remainingUnlocks
        Next
        Return remainingUnlocks
    End Function




    Public Overrides Function ToString() As String
        Return Name
    End Function

End Class
