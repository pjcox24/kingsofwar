Public Class UnitOption
    Private _DisplayText As String
    Private _Cost As Integer
    Public Property Purchased As Boolean
    Public Property SpecialStringHandled As Boolean = False
    Private _ChangesToUnit As New List(Of UnitStatChange)

    Public ReadOnly Property ChangesToUnit As List(Of UnitStatChange)
        Get
            Return _ChangesToUnit
        End Get
    End Property

    Public ReadOnly Property Cost As Integer
        Get
            Return _Cost
        End Get
    End Property


    Public Sub New(optionString As String, originalStats As Dictionary(Of String, String))
        If optionString = String.Empty Then

        Else
            If optionString.Contains("<") Then
                Dim boolStr As String = optionString.Split("<").LastOrDefault.Split(">").FirstOrDefault
                Purchased = If(boolStr = "True", True, False)

            End If
                Dim pointsStr = optionString.Split("]").FirstOrDefault
            _Cost = pointsStr.Split("[").LastOrDefault
            'Dim originalPointCost As Integer = originalStats("PointCost")
            '_ChangesToUnit.Add(New UnitStatChange("PointCost", _Cost + originalPointCost, originalPointCost))
            Dim textStr = optionString.Split("]").LastOrDefault
            If textStr.Contains("}") Then
                Dim tempStrings As List(Of String) = textStr.Split("{").ToList
                For Each statChange As String In tempStrings
                    If statChange.Contains("}") Then
                        statChange = statChange.Split("}").FirstOrDefault
                        Dim statName As String = statChange.Split(":").FirstOrDefault
                        If statName = "Special" Then
                            _ChangesToUnit.Add(New UnitStatChange(statName, statChange.Split(":").LastOrDefault, String.Empty))
                            SpecialStringHandled = True
                        Else
                            _ChangesToUnit.Add(New UnitStatChange(statName, statChange.Split(":").LastOrDefault, originalStats(statName)))
                        End If
                    Else
                        _DisplayText = statChange.Trim
                    End If
                Next
            Else
                _DisplayText = textStr
            End If
        End If

    End Sub

    Public Sub New(optionToCopy As UnitOption)
        _DisplayText = optionToCopy._DisplayText
        _Cost = optionToCopy.Cost
        Purchased = optionToCopy.Purchased
        _ChangesToUnit = optionToCopy.ChangesToUnit
        SpecialStringHandled = optionToCopy.SpecialStringHandled
    End Sub

    Public Function ToSaveString() As String
        Dim unitChanges As String = ""
        For Each chg As UnitStatChange In ChangesToUnit
            unitChanges = unitChanges & "{" & chg.StatName & " " & chg.AlteredStatValue & "}"
        Next
        Return "[" & _Cost & "] " & _DisplayText & unitChanges & "<" & Purchased & ">"
    End Function

    Public Function ToSpecialString() As String
        Return _DisplayText
    End Function

    Public Overrides Function ToString() As String
        Return "(" & _Cost & ") " & _DisplayText
    End Function


End Class
