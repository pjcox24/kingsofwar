Imports InheritancePractice

Public Class MagicalArtifact
    Private _Name As String
    Private _Cost As Integer
    Private _DisplayText As New List(Of String)
    Private _Restrictions As New Dictionary(Of String, List(Of String))
    Public Property SpecialStringHandled As Boolean = False
    Private _ChangesToUnit As New List(Of UnitStatChange)

    Public ReadOnly Property Name As String
        Get
            Return _Name
        End Get
    End Property

    Public ReadOnly Property Cost As Integer
        Get
            Return _Cost
        End Get
    End Property

    Public ReadOnly Property DisplayText As List(Of String)
        Get
            Return _DisplayText
        End Get
    End Property

    Public ReadOnly Property ChangesToUnit As List(Of UnitStatChange)
        Get
            Return _ChangesToUnit
        End Get
    End Property

    Public Sub New(name As String, restrictionString As String, cost As String, incEffect As String, originalStats As Dictionary(Of String, String))
        _Name = name
        _Cost = cost
        If restrictionString IsNot Nothing Then

            Dim restrictions As List(Of String) = restrictionString.Split("}").ToList
            For Each restriction As String In restrictions
                If restriction <> "" Then
                    Dim tempRestriction = restriction.Split("{").LastOrDefault
                    Dim restrictionType As String = tempRestriction.Split(":").FirstOrDefault
                    Dim allowedValues As List(Of String) = tempRestriction.Split(":").LastOrDefault.Split(",").ToList
                    Dim trimedAllowedValues As New List(Of String)
                    For Each aValue As String In allowedValues
                        trimedAllowedValues.Add(aValue.Trim)
                    Next
                    _Restrictions.Add(restrictionType, trimedAllowedValues)
                End If
            Next
        End If

        If incEffect IsNot Nothing Then
            Dim effects As New List(Of String)
            If incEffect.Contains(",") Then
                effects = incEffect.Split(",").ToList
            Else
                effects.Add(incEffect)
            End If

            For Each effect As String In effects
                If effect IsNot Nothing AndAlso effect.Contains("}") Then
                    Dim tempStrings As List(Of String) = effect.Split("{").ToList
                    For Each statChange As String In tempStrings
                        If statChange.Contains("}") Then
                            statChange = statChange.Split("}").FirstOrDefault
                            Dim statName As String = statChange.Split(" ").FirstOrDefault
                            If statName = "Special" Then
                                _ChangesToUnit.Add(New UnitStatChange(statName, statChange.Split(" ").LastOrDefault, String.Empty))
                                SpecialStringHandled = True
                            Else
                                _ChangesToUnit.Add(New UnitStatChange(statName, statChange.Split(" ").LastOrDefault, originalStats(statName)))
                            End If
                        Else
                            _DisplayText.Add(statChange.Trim)
                        End If
                    Next
                Else
                    _DisplayText.Add(If(effect Is Nothing, "", effect.Trim))
                End If
            Next
        End If


    End Sub

    Public Sub New(artifactToCopy As MagicalArtifact)
        _Name = artifactToCopy.Name
        _Cost = artifactToCopy.Cost
        _DisplayText = artifactToCopy.DisplayText
        SpecialStringHandled = artifactToCopy.SpecialStringHandled

        _Restrictions = New Dictionary(Of String, List(Of String))
        For Each kvp As KeyValuePair(Of String, List(Of String)) In artifactToCopy._Restrictions
            Dim copiedValues As New List(Of String)
            For Each value As String In kvp.Value
                copiedValues.Add(value)
            Next
            _Restrictions.Add(kvp.Key, copiedValues)
        Next

        _ChangesToUnit = New List(Of UnitStatChange)
        For Each change As UnitStatChange In artifactToCopy.ChangesToUnit
            _ChangesToUnit.Add(New UnitStatChange(change))
        Next
    End Sub

    Public Overrides Function ToString() As String
        Return _Name & " - " & _Cost
    End Function

    Public Sub AddOriginalStatsToChangesToUnits(stats As Dictionary(Of String, String))
        For Each sChange As UnitStatChange In _ChangesToUnit
            sChange.OriginalStatValue = stats(sChange.StatName)
        Next
    End Sub

    Public Function MeetsRestrictions(kUnit As KowUnit) As Boolean

        For Each key As String In _Restrictions.Keys
            Dim unitsValue As String = ""
            Dim restrictionMet As Boolean = False
            Select Case key
                Case "Type"
                    unitsValue = kUnit.Type.ToString
                Case "Size"
                    unitsValue = kUnit.Size.ToString
                Case "Special"
                    'Nothing is needed here
            End Select
            For Each acceptedValue As String In _Restrictions(key)
                If key = "Special" Then
                    If kUnit.SpecialRules.Contains(acceptedValue) Then
                        restrictionMet = True
                        Exit For
                    End If
                Else
                    If unitsValue = acceptedValue Then
                        restrictionMet = True
                        Exit For
                    End If
                End If
            Next
            If Not restrictionMet Then
                Return False
            End If
        Next
        Return True
    End Function
End Class
