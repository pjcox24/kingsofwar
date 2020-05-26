Imports System.Runtime.CompilerServices

Public Module ProjectEnums
    Enum UnitType
        Infantry
        HeavyInfantry
        LargeInfantry
        MonstrousInfantry
        Cavalry
        LargeCavalry
        Chariot
        Monster
        Titan
        WarEngine
        Swarm
        HeroInf
        HeroHeavyInf
        HeroLargeInf
        HeroCav
        HeroLargeCav
        HeroChariot
        HeroMonster
        HeroTitan
    End Enum
    <Extension()> Public Function ToDisplayString(uType As UnitType) As String
        Select Case uType
            Case UnitType.Cavalry
                Return "Cavalry"
            Case UnitType.Chariot
                Return "Chariot"
            Case UnitType.HeavyInfantry
                Return "HeavyInfantry"
            Case UnitType.HeroCav
                Return "HeroCav"
            Case UnitType.HeroChariot
                Return "HeroChariot"
            Case UnitType.HeroInf
                Return "HeroInf"
            Case UnitType.HeroHeavyInf
                Return "HeroHeavyInf"
            Case UnitType.HeroLargeCav
                Return "HeroLargeCav"
            Case UnitType.HeroLargeInf
                Return "HeroLargeInf"
            Case UnitType.HeroMonster
                Return "HeroMonster"
            Case UnitType.HeroTitan
                Return "HeroTitan"
            Case UnitType.Infantry
                Return "Infantry"
            Case UnitType.LargeCavalry
                Return "LargeCavalry"
            Case UnitType.LargeInfantry
                Return "LargeInfantry"
            Case UnitType.Monster
                Return "Monster"
            Case UnitType.MonstrousInfantry
                Return "MonstrousInfantry"
            Case UnitType.Swarm
                Return "Swarm"
            Case UnitType.Titan
                Return "Titan"
            Case UnitType.WarEngine
                Return "WarEngine"
            Case Else
                Return ""
        End Select
    End Function


    Enum UnitSize
        Solo
        Troop
        Regiment
        Horde
        Legion
    End Enum

    <Extension()> Public Function ToDisplayString(size As UnitSize) As String
        Select Case size
            Case UnitSize.Solo
                Return "Solo"
            Case UnitSize.Troop
                Return "Troop"
            Case UnitSize.Regiment
                Return "Regiment"
            Case UnitSize.Horde
                Return "Horde"
            Case UnitSize.Legion
                Return "Legion"
            Case Else
                Return ""
        End Select
    End Function

    Public Function StringToUnitSize(size As String) As UnitSize
        Select Case size
            Case "Solo"
                Return UnitSize.Solo
            Case "Troop"
                Return UnitSize.Troop
            Case "Regiment"
                Return UnitSize.Regiment
            Case "Horde"
                Return UnitSize.Horde
            Case "Legion"
                Return UnitSize.Legion
            Case Else
                Return ""
        End Select
    End Function

    Public Function StringToUnitType(type As String) As UnitType
        type = type.Trim
        Select Case type
            Case "Cavalry"
                Return UnitType.Cavalry
            Case "Chariot"
                Return UnitType.Chariot
            Case "HeavyInfantry"
                Return UnitType.HeavyInfantry
            Case "HvyInf"
                Return UnitType.HeavyInfantry
            Case "HeroCav"
                Return UnitType.HeroCav
            Case "HeroInf"
                Return UnitType.HeroInf
            Case "HeroHeavyInf"
                Return UnitType.HeroHeavyInf
            Case "HeroHvyInf"
                Return UnitType.HeroHeavyInf
            Case "HeroLargeCav"
                Return UnitType.HeroLargeCav
            Case "HeroLrgCav"
                Return UnitType.HeroLargeCav
            Case "HeroChariot"
                Return UnitType.HeroChariot
            Case "HeroCht"
                Return UnitType.HeroChariot
            Case "HeroLargeInf"
                Return UnitType.HeroLargeInf
            Case "HeroLrgInf"
                Return UnitType.HeroLargeInf
            Case "HeroMonster"
                Return UnitType.HeroMonster
            Case "HeroMon"
                Return UnitType.HeroMonster
            Case "HeroTtn"
                Return UnitType.HeroTitan
            Case "HeroTitan"
                Return UnitType.HeroTitan
            Case "Infantry"
                Return UnitType.Infantry
            Case "LargeCavalry"
                Return UnitType.LargeCavalry
            Case "LrgCav"
                Return UnitType.LargeCavalry
            Case "LargeInfantry"
                Return UnitType.LargeInfantry
            Case "LrgInf"
                Return UnitType.LargeInfantry
            Case "MonstrousInfantry"
                Return UnitType.MonstrousInfantry
            Case "Monster"
                Return UnitType.Monster
            Case "Swarm"
                Return UnitType.Swarm
            Case "Titan"
                Return UnitType.Titan
            Case "WarEngine"
                Return UnitType.WarEngine
            Case Else
                MsgBox("UnitType Error: " & type)
        End Select

    End Function

    Public Function CopyListofListofUnitType(listOfLists As List(Of List(Of UnitType))) As List(Of List(Of UnitType))
        Dim newListOfLists As New List(Of List(Of UnitType))
        For Each tList As List(Of UnitType) In newListOfLists
            Dim newTList As New List(Of UnitType)
            For Each xType As UnitType In tList
                newTList.Add(xType)
            Next
            newListOfLists.Add(newTList)
        Next
        Return newListOfLists
    End Function

    Public Function CopyListofString(listOfString As List(Of String)) As List(Of String)
        Dim outList As New List(Of String)
        For Each str As String In listOfString
            outList.Add(str)
        Next
        Return outList
    End Function

End Module
