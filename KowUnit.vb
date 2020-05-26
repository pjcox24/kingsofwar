Public Class KowUnit


    Protected _Name As String
    Protected _Size As UnitSize
    Protected _PointCost As Integer
    Protected _UnitStrength As Integer
    Protected _Nerve As String
    Protected _Speed As Integer
    Protected _Attacks As String
    Protected _Melee As Integer
    Protected _Range As Integer
    Protected _Defense As Integer
    Protected _Specials As List(Of String)
    Protected _Options As New List(Of UnitOption)
    Protected _Type As UnitType
    Protected _LivingLegend As Boolean
    Protected _Irregular As Boolean
    Protected _GeneratedUnlocks As Unlocks
    Protected _Height As Integer
    Private _EquipedArtifact As MagicalArtifact



#Region "Properties"
    Public ReadOnly Property Name As String
        Get
            Return _Name
        End Get
    End Property
    Public ReadOnly Property Size As UnitSize
        Get
            Return _Size
        End Get
    End Property
    Public ReadOnly Property UnitStrength As String
        Get
            Return _UnitStrength
        End Get
    End Property

    Public ReadOnly Property Speed As String
        Get
            Return _Speed
        End Get
    End Property

    Public ReadOnly Property Melee As String
        Get
            Return _Melee
        End Get
    End Property
    Public ReadOnly Property Range As String
        Get
            Return _Range
        End Get
    End Property

    Public ReadOnly Property Defense As String
        Get
            Return _Defense
        End Get
    End Property

    Public ReadOnly Property Attacks As String
        Get
            Return _Attacks
        End Get
    End Property

    Public ReadOnly Property Nerve As String
        Get
            Return _Nerve
        End Get
    End Property

    Public ReadOnly Property PointCost As String
        Get
            If _EquipedArtifact IsNot Nothing Then
                Return _PointCost + _EquipedArtifact.Cost
            Else
                Return _PointCost
            End If
        End Get
    End Property

    Public ReadOnly Property Height As String
        Get
            Return _Height
        End Get
    End Property

    Public ReadOnly Property TypeAsString As String
        Get
            Return _Type.ToDisplayString
        End Get
    End Property

    Public ReadOnly Property Type As UnitType
        Get
            Return _Type
        End Get
    End Property

    Public ReadOnly Property LivingLegend As Boolean
        Get
            Return _LivingLegend
        End Get
    End Property

    Public ReadOnly Property Irregular As Boolean
        Get
            Return _Irregular
        End Get
    End Property

    Public ReadOnly Property GeneratedUnlocks As Unlocks
        Get
            Return _GeneratedUnlocks
        End Get
    End Property

    Public ReadOnly Property SpecialRules As List(Of String)
        Get
            Return _Specials
        End Get
    End Property

    Public ReadOnly Property Options As List(Of UnitOption)
        Get
            Return _Options
        End Get
    End Property

    Public ReadOnly Property EquipedArtifact As MagicalArtifact
        Get
            Return _EquipedArtifact
        End Get
    End Property

#End Region

    Public Sub New()
        _Name = ""
        _Size = UnitSize.Solo
        _PointCost = 0
        _UnitStrength = 0
        _Nerve = ""
        _Speed = 0
        _Attacks = ""
        _Melee = 0
        _Range = 0
        _Defense = 0
        _Specials = New List(Of String)
        _Height = 0
        _Type = UnitType.Infantry
        _LivingLegend = False
        _Irregular = False

    End Sub

    Public Sub New(name As String, size As UnitSize, pointCost As Integer, unitStrength As Integer, nerve As String, speed As Integer, attacks As String,
                   melee As Integer, range As Integer, defense As Integer, specials As List(Of String), options As List(Of UnitOption), type As UnitType,
                   livingLegend As Boolean, irregular As Boolean, height As Integer)

        _Name = name
        _Size = size
        _PointCost = pointCost
        _UnitStrength = unitStrength
        _Nerve = nerve
        _Speed = speed
        _Attacks = attacks
        _Melee = melee
        _Range = range
        _Defense = defense
        _Specials = specials
        _Height = height
        _Type = type
        _LivingLegend = livingLegend
        _Irregular = irregular
        _GeneratedUnlocks = GetUnlocks()

        For Each inputedOption As UnitOption In options
            Dim ruleOption As New UnitOption(inputedOption)
            _Options.Add(ruleOption)
        Next



    End Sub

    Public Sub New(name As String, size As UnitSize, pointCost As Integer, unitStrength As Integer, nerve As String, speed As Integer, attacks As String,
                   melee As Integer, range As Integer, defense As Integer, specials As List(Of String), options As List(Of String), type As UnitType,
                   livingLegend As Boolean, irregular As Boolean, height As Integer)
        _Name = name
        _Size = size
        _PointCost = pointCost
        _UnitStrength = unitStrength
        _Nerve = nerve
        _Speed = speed
        _Attacks = attacks
        _Melee = melee
        _Range = range
        _Defense = defense
        _Specials = specials
        _Height = height
        _Type = type
        _LivingLegend = livingLegend
        _Irregular = irregular
        _GeneratedUnlocks = GetUnlocks()


        For Each inputedOption As String In options
            Dim ruleOption As New UnitOption(inputedOption, GetStats())
            _Options.Add(ruleOption)
        Next

    End Sub

    Public Sub New(savedUnit As String)
        Dim input As List(Of String) = savedUnit.Split(";").ToList

        _Name = input(0)
        _Size = StringToUnitSize(input(1))
        _Type = StringToUnitType(input(2))
        _Speed = input(3)
        _Melee = input(4)
        _Range = input(5)
        _Defense = input(6)
        _UnitStrength = input(7)
        _Attacks = input(8)
        _Nerve = input(9)
        _Height = input(10)
        _PointCost = input(11)
        _LivingLegend = input(12)
        _Irregular = input(13)
        _GeneratedUnlocks = GetUnlocks()

        'Dim Stats As New Dictionary(Of String, String)
        'Stats.Add("PointCost", _PointCost)
        'Stats.Add("UnitStrength", _UnitStrength)
        'Stats.Add("Nerve", _Nerve)
        'Stats.Add("Speed", _Speed)
        'Stats.Add("Attacks", _Attacks)
        'Stats.Add("Melee", _Melee)
        'Stats.Add("Range", _Range)
        'Stats.Add("Defense", _Defense)
        'Stats.Add("Height", _Height)
        'Stats.Add("Type", _Type.ToDisplayString)
        'Stats.Add("LivingLegend", _LivingLegend)

        If input.Count > 14 Then
            Dim specialsString As String = input(14)
            Dim specials As List(Of String)
            If specialsString = "" Then
                specials = New List(Of String)
            Else
                specials = specialsString.Split(",").ToList
            End If

            Dim specialRules As New List(Of String)
            For Each specialRule As String In specials
                If specialRule.FirstOrDefault = " " Then
                    specialRule = specialRule.Trim()
                End If
                specialRules.Add(specialRule)
            Next
            _Specials = specialRules
        End If

        If input.Count > 15 Then
            Dim optionsString As String = input(15)
            Dim options As List(Of String)
            If optionsString = "" Then
                options = New List(Of String)
            Else
                options = optionsString.Split(",").ToList
            End If
            Dim optionalRules As New List(Of String)
            For Each optionalRule As String In options
                If optionalRule.FirstOrDefault = " " Then
                    optionalRule = optionalRule.Trim()
                End If
                optionalRules.Add(optionalRule)
            Next
            For Each inputedOption As String In optionalRules
                Dim ruleOption As New UnitOption(inputedOption, GetStats())
                _Options.Add(ruleOption)
                If ruleOption.Purchased Then
                    _Specials.Add(ruleOption.ToSpecialString)
                End If
            Next
        End If

    End Sub

    Public Sub New(unitToCopy As KowUnit)

        Me.New(unitToCopy.Name, unitToCopy.Size, unitToCopy.PointCost, unitToCopy.UnitStrength, unitToCopy.Nerve, unitToCopy.Speed,
               unitToCopy.Attacks, unitToCopy.Melee, unitToCopy.Range, unitToCopy.Defense, CopyListofString(unitToCopy.SpecialRules), unitToCopy.Options,
               unitToCopy.Type, unitToCopy.LivingLegend, unitToCopy.Irregular, unitToCopy.Height)
        _EquipedArtifact = unitToCopy._EquipedArtifact
    End Sub

    Public Sub SetEquippedArtifact(oldArtifact As MagicalArtifact, newArtifact As MagicalArtifact)
        _EquipedArtifact = newArtifact
        If oldArtifact IsNot Nothing Then
            For Each alteredStat As UnitStatChange In oldArtifact.ChangesToUnit
                Select Case alteredStat.StatName
                    Case "Type"
                        _Type = StringToUnitType(alteredStat.OriginalStatValue)
                    Case "Speed"
                        _Speed = alteredStat.OriginalStatValue
                    Case "Melee"
                        _Melee = alteredStat.OriginalStatValue
                    Case "Range"
                        _Range = alteredStat.OriginalStatValue
                    Case "Defense"
                        _Defense = alteredStat.OriginalStatValue
                    Case "UnitStrength"
                        _UnitStrength = alteredStat.OriginalStatValue
                    Case "Attacks"
                        _Attacks = alteredStat.OriginalStatValue
                    Case "Nerve"
                        _Nerve = alteredStat.OriginalStatValue
                    Case "Height"
                        _Height = alteredStat.OriginalStatValue
                    Case "LivingLegend"
                        _LivingLegend = alteredStat.OriginalStatValue
                        'Case "Special"
                        '    If checked Then
                        '        _Specials.Add(alteredStat.AlteredStatValue)
                        '    Else
                        '        _Specials.Remove(alteredStat.AlteredStatValue)
                        '    End If

                End Select
            Next
            For Each artifactRule As String In oldArtifact.DisplayText
                For Each sRule As String In _Specials
                    If oldArtifact.DisplayText.Contains(sRule) Then
                        _Specials.Remove(sRule)
                        Exit For
                    End If
                Next
            Next

        End If
        For Each alteredStat As UnitStatChange In newArtifact.ChangesToUnit
            Select Case alteredStat.StatName
                Case "Type"
                    _Type = StringToUnitType(alteredStat.AlteredStatValue)
                Case "Speed"
                    _Speed = alteredStat.AlteredStatValue
                Case "Melee"
                    _Melee = alteredStat.AlteredStatValue
                Case "Range"
                    _Range = alteredStat.AlteredStatValue
                Case "Defense"
                    _Defense = alteredStat.AlteredStatValue
                Case "UnitStrength"
                    _UnitStrength = alteredStat.AlteredStatValue
                Case "Attacks"
                    _Attacks = alteredStat.AlteredStatValue
                Case "Nerve"
                    _Nerve = alteredStat.AlteredStatValue
                Case "Height"
                    _Height = alteredStat.AlteredStatValue
                Case "LivingLegend"
                    _LivingLegend = alteredStat.AlteredStatValue
                    'Case "Special"
                    '    If checked Then
                    '        _Specials.Add(alteredStat.AlteredStatValue)
                    '    Else
                    '        _Specials.Remove(alteredStat.AlteredStatValue)
                    '    End If

            End Select
        Next
        _Specials.AddRange(newArtifact.DisplayText)
    End Sub

    Public Function GetConsolidatedSpecialRules() As List(Of String)
        Dim combinedRuleKeys As New List(Of String)
        Dim completedRules As New List(Of String)
        For Each special As String In _Specials
            If Not combinedRuleKeys.Contains(special.Split("(").FirstOrDefault.Trim) Then
                Dim combinedRule As String = GetCombinedSpecialRule(special, _Specials)
                completedRules.Add(combinedRule)
                If special <> combinedRule Then
                    combinedRuleKeys.Add(combinedRule.Split("(").FirstOrDefault.Trim)
                End If
            End If
        Next
        Return completedRules
    End Function

    Public Function GetCombinedSpecialRule(specialRule As String, specialRules As List(Of String)) As String
        If specialRule.Contains("(") Then
            Dim key As String = specialRule.Split("(").FirstOrDefault.Trim
            Dim combinedStringValue As String = ""
            Dim combinedIntegerValue As Integer = 0
            For Each rule As String In specialRules
                If rule.StartsWith(key) Then
                    Dim valueStr As String = rule.Split("(").LastOrDefault.Split(")").FirstOrDefault
                    Dim valueInteger As Integer = Nothing
                    Try
                        valueInteger = valueStr
                        combinedIntegerValue = combinedIntegerValue + valueInteger
                    Catch ex As Exception
                        combinedStringValue = combinedStringValue & valueStr
                    End Try
                End If
            Next
            Dim combinedCRules As String = ""
            If combinedIntegerValue = 0 Then
                combinedCRules = key & "(" & If(combinedStringValue.StartsWith("+"), combinedStringValue.TrimStart("+"c), combinedStringValue) & ")"
            Else
                combinedCRules = key & "(" & combinedIntegerValue & combinedStringValue & ")"
            End If
            Return combinedCRules
        Else
            Return specialRule
        End If
    End Function


    Public Sub ApplyOption(toggledOption As UnitOption, checked As Boolean)

        _PointCost = If(checked, _PointCost + toggledOption.Cost, _PointCost - toggledOption.Cost)
        toggledOption.Purchased = checked
        For Each alteredStat As UnitStatChange In toggledOption.ChangesToUnit
            Select Case alteredStat.StatName
                'Case "PointCost"
                '    _PointCost = If(checked, alteredStat.AlteredStatValue, alteredStat.OriginalStatValue)
                Case "Type"
                    _Type = StringToUnitType(If(checked, alteredStat.AlteredStatValue, alteredStat.OriginalStatValue))
                Case "Speed"
                    _Speed = If(checked, alteredStat.AlteredStatValue, alteredStat.OriginalStatValue)
                Case "Melee"
                    _Melee = If(checked, alteredStat.AlteredStatValue, alteredStat.OriginalStatValue)
                Case "Range"
                    _Range = If(checked, alteredStat.AlteredStatValue, alteredStat.OriginalStatValue)
                Case "Defense"
                    _Defense = If(checked, alteredStat.AlteredStatValue, alteredStat.OriginalStatValue)
                Case "UnitStrength"
                    _UnitStrength = If(checked, alteredStat.AlteredStatValue, alteredStat.OriginalStatValue)
                Case "Attacks"
                    _Attacks = If(checked, alteredStat.AlteredStatValue, alteredStat.OriginalStatValue)
                Case "Nerve"
                    _Nerve = If(checked, alteredStat.AlteredStatValue, alteredStat.OriginalStatValue)
                Case "Height"
                    _Height = If(checked, alteredStat.AlteredStatValue, alteredStat.OriginalStatValue)
                Case "LivingLegend"
                    _LivingLegend = If(checked, alteredStat.AlteredStatValue, alteredStat.OriginalStatValue)
                Case "Special"
                    If checked Then
                        _Specials.Add(alteredStat.AlteredStatValue)
                    Else
                        _Specials.Remove(alteredStat.AlteredStatValue)
                    End If

            End Select
        Next
        If checked Then
            If Not toggledOption.SpecialStringHandled Then
                _Specials.Add(toggledOption.ToSpecialString)
            Else
                'logic where if there are special stat changes and more text
            End If
        Else
            If Not toggledOption.SpecialStringHandled Then
                For Each sRule As String In _Specials
                    If sRule = toggledOption.ToSpecialString Then
                        _Specials.Remove(sRule)
                        Exit For
                    End If
                Next
            Else
                'logic where if there are special stat changes and more text
                'MsgBox("RemoveOptionToSpecialLogic")
            End If

        End If


    End Sub

    Public Function GetStats() As Dictionary(Of String, String)
        Dim stats As New Dictionary(Of String, String)
        stats.Add("PointCost", _PointCost)
        stats.Add("UnitStrength", _UnitStrength)
        stats.Add("Nerve", _Nerve)
        stats.Add("Speed", _Speed)
        stats.Add("Attacks", _Attacks)
        stats.Add("Melee", _Melee)
        stats.Add("Range", _Range)
        stats.Add("Defense", _Defense)
        stats.Add("Height", _Height)
        stats.Add("Type", _Type.ToDisplayString)
        stats.Add("LivingLegend", _LivingLegend)
        Return stats
    End Function

    Private Function GetUnlocks() As Unlocks
        If _Type = UnitType.Infantry OrElse _Type = UnitType.HeavyInfantry OrElse _Type = UnitType.Cavalry OrElse _Type = UnitType.Chariot Then
            If _Size = UnitSize.Troop Then
                Return New Unlocks(-1, 0, 0, 0, 0, 0, 0, 0)
            ElseIf _Size = UnitSize.Regiment Then
                Return New Unlocks(2, 0, 0, 0, 0, 0, 1, 0)
            ElseIf _Size = UnitSize.Horde Then
                Return New Unlocks(4, 1, 0, 0, 1, 1, 0, 0)
            ElseIf _Size = UnitSize.Legion Then
                Return New Unlocks(4, 1, 0, 0, 1, 1, 0, 0)
            End If
        ElseIf _Type = UnitType.LargeInfantry OrElse _Type = UnitType.MonstrousInfantry OrElse _Type = UnitType.LargeCavalry Then
            If _Size = UnitSize.Regiment Then
                Return New Unlocks(0, 0, 0, 0, 0, 0, 0, 0)
            ElseIf _Size = UnitSize.Horde Then
                Return New Unlocks(2, 0, 0, 0, 0, 0, 0, 2)
            ElseIf _Size = UnitSize.Legion Then
                Return New Unlocks(4, 0, 0, 0, 0, 0, 0, 2)
            End If
        ElseIf _Type = UnitType.HeroInf OrElse _Type = UnitType.HeroLargeInf OrElse _Type = UnitType.HeroCav OrElse _Type = UnitType.HeroLargeCav OrElse
            _Type = UnitType.HeroMonster OrElse _Type = UnitType.HeroTitan Then

            Return New Unlocks(0, -1, 0, 0, 0, 0, 0, 0)
        ElseIf _Type = UnitType.Monster Then
            Return New Unlocks(0, 0, -1, 0, 0, 0, 0, 0)
        ElseIf _Type = UnitType.Titan Then
            Return New Unlocks(0, 0, 0, -1, 0, 0, 0, 0)
        ElseIf _Type = UnitType.WarEngine Then
            Return New Unlocks(0, 0, 0, 0, -1, 0, 0, 0)
        End If
        Return New Unlocks
    End Function

    Public Function SpecialsToString() As String
        Dim outString As String = ""
        For Each spStr As String In _Specials
            outString = outString & spStr & ", "
        Next
        Dim charsToTrim As New List(Of Char)
        charsToTrim.Add(" ")
        charsToTrim.Add(",")
        Return outString.TrimEnd(charsToTrim.ToArray)
    End Function

    Public Function OptionsToString() As String
        Dim outString As String = ""
        For Each opt As UnitOption In _Options
            outString = outString & opt.ToSaveString & ", "
        Next
        Dim charsToTrim As New List(Of Char)
        charsToTrim.Add(" ")
        charsToTrim.Add(",")
        Return outString.TrimEnd(charsToTrim.ToArray)
    End Function

    Public Overrides Function ToString() As String
        If _Size = UnitSize.Solo Then
            Return _Name
        Else
            Return _Name & " " & _Size.ToString
        End If
    End Function

    Public Shared Operator =(A As KowUnit, B As KowUnit) As Boolean
        If A.Name = B.Name Then
            ' && A.Size = B.Size
            Return True
        Else
            Return False
        End If

    End Operator

    Public Shared Operator <>(A As KowUnit, B As KowUnit) As Boolean
        Return Not A = B
    End Operator

End Class
