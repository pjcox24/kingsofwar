Public Class Unlocks


#Region "Properties"
    Public Property UnlockTroop As Integer

    Public Property UnlockHero As Integer

    Public Property UnlockMonster As Integer

    Public Property UnlockTitan As Integer

    Public Property UnlockWarEngine As Integer

    Public Property UnlockMonTitan As Integer

    Public Property UnlockWild As Integer

    Public Property UnlockDoubleWild As Integer

    Public Property DoubleWildTypes As New List(Of UnitType)

    Public Property DoubleWildUnlockUsed As Boolean



#End Region


    Public Sub New(troopUnlock As Integer, heroUnlock As Integer, monsterUnlock As Integer, titanUnlock As Integer, warmachineUnlock As Integer,
                   monTitanUnlock As Integer, wildUnlock As Integer, doubleWildUnlock As Integer)
        UnlockTroop = troopUnlock
        UnlockHero = heroUnlock
        UnlockMonster = monsterUnlock
        UnlockTitan = titanUnlock
        UnlockWarEngine = warmachineUnlock
        UnlockMonTitan = monTitanUnlock
        UnlockWild = wildUnlock
        UnlockDoubleWild = doubleWildUnlock



    End Sub

    Public Sub New()
        UnlockTroop = 0
        UnlockHero = 0
        UnlockMonster = 0
        UnlockTitan = 0
        UnlockWarEngine = 0
        UnlockMonTitan = 0
        UnlockWild = 0
        UnlockDoubleWild = 0
    End Sub

    Public Function Copy() As Unlocks
        Dim copiedUnlocks As New Unlocks(UnlockTroop, UnlockHero, UnlockMonster, UnlockTitan, UnlockWarEngine, UnlockMonTitan, UnlockWild, UnlockDoubleWild)

        Return copiedUnlocks
    End Function

    Public Shared Operator +(A As Unlocks, B As Unlocks) As Unlocks

        Dim combinedUnlock As New Unlocks(A.UnlockTroop + B.UnlockTroop, A.UnlockHero + B.UnlockHero, A.UnlockMonster + B.UnlockMonster, A.UnlockTitan + B.UnlockTitan,
                           A.UnlockWarEngine + B.UnlockWarEngine, A.UnlockMonTitan + B.UnlockMonTitan, A.UnlockWild + B.UnlockWild,
                           A.UnlockDoubleWild + B.UnlockDoubleWild)

        Return combinedUnlock
    End Operator

    Public Overrides Function ToString() As String
        Return "Troop: " & Me.UnlockTroop & vbCrLf &
            "Hero: " & Me.UnlockHero & vbCrLf &
            "Monster: " & Me.UnlockMonster & vbCrLf &
            "Titan: " & Me.UnlockTitan & vbCrLf &
            "War Engine: " & Me.UnlockWarEngine & vbCrLf &
            "MonTitan: " & Me.UnlockMonTitan & vbCrLf &
            "Wild: " & Me.UnlockWild & vbCrLf &
            "DoubleWild: " & Me.UnlockDoubleWild

    End Function
    Public Function ToCommaString() As String
        Return "Troop: " & Me.UnlockTroop & ", " &
            "Hero: " & Me.UnlockHero & ", " &
            "Monster: " & Me.UnlockMonster & ", " &
            "Titan: " & Me.UnlockTitan & ", " &
            "War Engine: " & Me.UnlockWarEngine & ", " &
            "MonTitan: " & Me.UnlockMonTitan & ", " &
            "Wild: " & Me.UnlockWild & ", " &
            "DoubleWild: " & Me.UnlockDoubleWild

    End Function

    Public Shared Operator =(A As Unlocks, B As Unlocks) As Boolean
        If A.UnlockTroop = B.UnlockTroop AndAlso
                A.UnlockHero = B.UnlockHero AndAlso
                A.UnlockMonster = B.UnlockMonster AndAlso
                A.UnlockTitan = B.UnlockTitan AndAlso
                A.UnlockWarEngine = B.UnlockWarEngine AndAlso
                A.UnlockMonTitan = B.UnlockMonTitan AndAlso
                A.UnlockWild = B.UnlockWild AndAlso
                A.UnlockDoubleWild = B.UnlockDoubleWild Then
            Return True
        Else
            Return False
        End If

    End Operator

    Public Shared Operator <>(A As Unlocks, B As Unlocks) As Boolean
        Return Not A = B
    End Operator

End Class
