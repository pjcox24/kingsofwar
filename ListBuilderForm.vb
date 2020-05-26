Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel
Imports Word = Microsoft.Office.Interop.Word
Imports System.Reflection
Imports Microsoft.Office.Interop.Excel

Public Class ListEditorForm

    Private newArmyList As New ArmyList("New Army List")
    'Keep the application object and the workbook object global, so you can  
    'retrieve the data in Button2_Click that was set in Button1_Click.
    Private _FocusedUnit As KowUnit
    Private _ProgramaticCheck As Boolean = False
    Private _MagicalArtifacts As List(Of MagicalArtifact)
    Private _ValidArtifacts As New List(Of MagicalArtifact)

    Private Sub ListEditorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadXml()
        ComboBox_Army.SelectedIndex = 0
        ComboBox_UnitType.SelectedIndex = 0
    End Sub

    Private Sub Button_AddUnit_Click(sender As Object, e As EventArgs) Handles Button_AddUnit.Click

        Dim selectedUnit As KowUnit = CType(ComboBox_UnitType.SelectedItem, KowUnit)

        'If newArmyList.DoubleWildsUsed.Count <> 0 Then
        '    For Each kUnit As KowUnit In newArmyList.Units
        '        kUnit.GeneratedUnlocks.DoubleWildTypes.Clear()
        '    Next
        'End If
        'newArmyList.DoubleWildsUsed.Clear()

        Dim addedUnit As New KowUnit(selectedUnit)
        AddUnitToList(addedUnit)

        Dim currentUnlockStatus As Unlocks = newArmyList.GetUnlocksRemaining(newArmyList)
        TextBox_Unlocks.Text = "Unlocks" & currentUnlockStatus.ToString
        TextBox_TotalPoints.Text = newArmyList.GetPointsTotal
    End Sub

    Private Sub Button_RemoveUnit_Click(sender As Object, e As EventArgs) Handles Button_RemoveUnit.Click
        If Not ListBox_Units.SelectedIndex = -1 Then
            Dim removedUnit As KowUnit = ListBox_Units.Items(ListBox_Units.SelectedIndex)
            Dim removedUnitType As UnitType = removedUnit.Type

            'If newArmyList.DoubleWildsUsed.Contains(removedUnitType) Then
            '    For Each kUnit As KowUnit In newArmyList.Units
            '        If kUnit.GeneratedUnlocks.DoubleWildTypes.Contains(removedUnitType) Then
            '            kUnit.GeneratedUnlocks.DoubleWildTypes.Clear() 'Remove(removedUnitType)
            '            newArmyList.DoubleWildsUsed.Remove(removedUnitType)
            '            Exit For
            '        End If
            '    Next
            'End If



            newArmyList.RemoveUnit(ListBox_Units.SelectedIndex)
                ListBox_Units.Items.RemoveAt(ListBox_Units.SelectedIndex)

            Dim currentUnlockStatus As Unlocks = newArmyList.GetUnlocksRemaining(newArmyList)
            TextBox_Unlocks.Text = "Unlocks" & currentUnlockStatus.ToString
                TextBox_TotalPoints.Text = newArmyList.GetPointsTotal
            End If

    End Sub

    Private Sub AddUnitToList(newUnit As KowUnit)
        ListBox_Units.Items.Add(newUnit)
        newArmyList.AddUnit(newUnit)
    End Sub

    Private Sub ListBox_Units_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox_Units.SelectedIndexChanged
        PopulateFocusedUnit(True)
        PopulateMagicalArtifact()
    End Sub

    Private Sub ComboBox_UnitType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_UnitType.SelectedIndexChanged
        ListBox_Units.SelectedIndex = -1
        PopulateFocusedUnit(True)
        PopulateMagicalArtifact()
    End Sub

    Private Sub ComboBox_Army_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Army.SelectedIndexChanged
        PopulateFocusedArmy()
    End Sub

    Private Sub CheckedListBox_Options_SelectedIndexChanged(sender As Object, e As ItemCheckEventArgs) Handles CheckedListBox_Options.ItemCheck
        If _ProgramaticCheck Then
            _ProgramaticCheck = False
        Else
            Dim checkedOption As UnitOption = CheckedListBox_Options.Items.Item(e.Index)
            If _FocusedUnit IsNot Nothing Then
                _FocusedUnit.ApplyOption(checkedOption, e.NewValue)
                PopulateFocusedUnit(False)
            End If
        End If

    End Sub

    Private Sub ComboBox_MagicalArtifacts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_MagicalArtifacts.SelectedIndexChanged
        If _ProgramaticCheck = False Then
            If _FocusedUnit IsNot Nothing Then
                Dim oldArtifact As MagicalArtifact = _FocusedUnit.EquipedArtifact
                '_FocusedUnit.EquipedArtifact = _MagicalArtifacts(ComboBox_MagicalArtifacts.SelectedIndex)
                Dim newArtifact As New MagicalArtifact(_ValidArtifacts(ComboBox_MagicalArtifacts.SelectedIndex))
                newArtifact.AddOriginalStatsToChangesToUnits(_FocusedUnit.GetStats())
                _FocusedUnit.SetEquippedArtifact(oldArtifact, newArtifact)
                PopulateFocusedUnit(False)
            End If
        Else
            _ProgramaticCheck = False
        End If

    End Sub

    Private Sub Button_WriteToWord_Click(sender As Object, e As EventArgs) Handles Button_WriteToWord.Click
        Dim word_app As Word._Application = New Word.Application

        ' Make Word visible (optional).
        word_app.Visible = True

        ' Create the Word document.
        Dim word_doc As Word._Document = word_app.Documents.Add()
        word_doc.Sections.PageSetup.LeftMargin = 20
        word_doc.Sections.PageSetup.TopMargin = 40
        word_doc.Sections.PageSetup.BottomMargin = 40

        ' Create a header paragraph.
        Dim para As Word.Paragraph = word_doc.Paragraphs.Add()
        para.Range.Text = Label_ArmyName.Text
        para.Range.Style = "Title"
        para.Range.InsertParagraphAfter()

        ' Add more text.
        para.Range.Text = "Points Total: " & newArmyList.GetPointsTotal
        para.Range.InsertParagraphAfter()
        ' Add more text.
        para.Range.Text = "Unlock Status: " & newArmyList.GetUnlocksRemaining(newArmyList).ToCommaString
        para.Range.InsertParagraphAfter()

        ' Save the current font and start using Courier New.
        Dim old_font As String = para.Range.Font.Name
        para.Range.Font.Name = "Courier New"

        'Add Table
        Dim table As Word.Table
        Dim rowCount As Integer = newArmyList.UnitCount + 1
        Dim columnCount As Integer = 9

        table = word_doc.Tables.Add(para.Range, rowCount, columnCount)
        table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleThickThinSmallGap
        table.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle
        table.Columns.PreferredWidth = 25
        table.Columns.Item(7).PreferredWidth = 35
        table.Columns.Item(8).PreferredWidth = 45
        table.Columns.Item(9).PreferredWidth = 40
        table.Columns.First.PreferredWidth = 330

        table.Cell(1, 1).Range.Text = "Unit Name"
        table.Cell(1, 2).Range.Text = "US"
        table.Cell(1, 3).Range.Text = "Sp"
        table.Cell(1, 4).Range.Text = "Me"
        table.Cell(1, 5).Range.Text = "Ra"
        table.Cell(1, 6).Range.Text = "De"
        table.Cell(1, 7).Range.Text = "Att"
        table.Cell(1, 8).Range.Text = "Ne"
        table.Cell(1, 9).Range.Text = "Pts"

        Dim row As Integer = 2
        For Each kUnit As KowUnit In newArmyList.Units
            Dim unitName As Word.Paragraph = word_doc.Paragraphs.Add()
            'para.Range.Bold

            table.Cell(row, 1).Range.Text = kUnit.ToString & vbCrLf & kUnit.SpecialsToString
            table.Cell(row, 2).Range.Text = kUnit.UnitStrength
            table.Cell(row, 3).Range.Text = kUnit.Speed
            table.Cell(row, 4).Range.Text = kUnit.Melee
            table.Cell(row, 5).Range.Text = kUnit.Range
            table.Cell(row, 6).Range.Text = kUnit.Defense
            table.Cell(row, 7).Range.Text = kUnit.Attacks
            table.Cell(row, 8).Range.Text = kUnit.Nerve
            table.Cell(row, 9).Range.Text = kUnit.PointCost
            row += 1
        Next


        ' Start a new paragraph and then switch back to the
        ' original font.
        para.Range.InsertParagraphAfter()
        para.Range.Font.Name = old_font

        ' Save the document.
        'Dim filename As Object = Path.GetFullPath(Path.Combine("C:\Users\PhilipCox\Desktop\Other\ArmyLists") & "\test.doc")
        'word_doc.SaveAs(FileName:=filename)

        ' Close.
        'Dim save_changes As Object = False
        'word_doc.Close(save_changes)
        'word_app.Quit(save_changes)
    End Sub

    Private Sub PopulateFocusedArmy()
        ComboBox_UnitType.Items.Clear()
        Dim selectedArmy As ArmyList = CType(ComboBox_Army.SelectedItem, ArmyList)
        For Each armyUnit As KowUnit In selectedArmy.Units
            ComboBox_UnitType.Items.Add(armyUnit)
        Next
        ComboBox_UnitType.SelectedIndex = 0
    End Sub

    Private Sub PopulateFocusedUnit(updateOptions As Boolean)
        Dim selectedKowUnit As KowUnit = CType(ListBox_Units.SelectedItem, KowUnit)
        If selectedKowUnit Is Nothing Then
            selectedKowUnit = CType(ComboBox_UnitType.SelectedItem, KowUnit)
        End If
        If selectedKowUnit Is Nothing Then
            _FocusedUnit = Nothing
            TextBox_Name.Text = String.Empty
            TextBox_US.Text = String.Empty
            TextBox_Speed.Text = String.Empty
            TextBox_Melee.Text = String.Empty
            TextBox_Range.Text = String.Empty
            TextBox_Defense.Text = String.Empty
            TextBox_Attacks.Text = String.Empty
            TextBox_Nerve.Text = String.Empty
            TextBox_Points.Text = String.Empty
            TextBox_Height.Text = String.Empty
            Label_Type.Text = "Type"
            Label_LivingLegend.Hide()
            Label_Irregular.Hide()
            ListBox_SpecialRules.Items.Clear()
            CheckedListBox_Options.Items.Clear()
        Else
            _FocusedUnit = selectedKowUnit
            TextBox_Name.Text = selectedKowUnit.Name
            TextBox_US.Text = selectedKowUnit.UnitStrength
            TextBox_Speed.Text = selectedKowUnit.Speed
            TextBox_Melee.Text = selectedKowUnit.Melee
            TextBox_Range.Text = selectedKowUnit.Range
            TextBox_Defense.Text = selectedKowUnit.Defense
            TextBox_Attacks.Text = selectedKowUnit.Attacks
            TextBox_Nerve.Text = selectedKowUnit.Nerve
            TextBox_Points.Text = selectedKowUnit.PointCost
            TextBox_Height.Text = selectedKowUnit.Height
            Label_Type.Text = selectedKowUnit.TypeAsString
            If selectedKowUnit.LivingLegend Then
                Label_LivingLegend.Show()
            Else
                Label_LivingLegend.Hide()
            End If
            If selectedKowUnit.Irregular Then
                Label_Irregular.Show()
            Else
                Label_Irregular.Hide()
            End If
            ListBox_SpecialRules.Items.Clear()



            'Dim correctedSpecials As New List(Of String)
            'Dim combinedCrStrInteger As Integer = 0
            'Dim combinedCrStrString As String = ""
            'For Each specialRule As String In selectedKowUnit.SpecialRules
            '    If specialRule.StartsWith("Crushing Strength") OrElse specialRule.StartsWith("CrushingStrength") Then
            '        Dim crStrInner As String = specialRule.Split("(").LastOrDefault.Split(")").FirstOrDefault
            '        Dim innerInteger As Integer = Nothing
            '        Try
            '            innerInteger = crStrInner
            '            combinedCrStrInteger = combinedCrStrInteger + innerInteger
            '        Catch ex As Exception
            '            combinedCrStrString = combinedCrStrString & crStrInner
            '        End Try
            '    Else
            '        correctedSpecials.Add(specialRule)
            '    End If
            'Next
            'Dim combinedCrushingStrength As String = ""
            'If combinedCrStrInteger = 0 Then
            '    combinedCrushingStrength = "Crushing Strength(" & If(combinedCrStrString.StartsWith("+"), combinedCrStrString.TrimStart("+"c), combinedCrStrString) & ")"
            'Else
            '    combinedCrushingStrength = "Crushing Strength(" & combinedCrStrInteger & combinedCrStrString & ")"
            'End If

            'If Not combinedCrushingStrength = "Crushing Strength()" Then
            '    correctedSpecials.Add(combinedCrushingStrength)
            'End If

            For Each specialRule As String In selectedKowUnit.GetConsolidatedSpecialRules()
                ListBox_SpecialRules.Items.Add(specialRule)
            Next


            If updateOptions Then
                CheckedListBox_Options.Items.Clear()
                Dim index As Integer = 0
                For Each ruleOption As UnitOption In selectedKowUnit.Options
                    CheckedListBox_Options.Items.Add(ruleOption)
                    If ruleOption.Purchased Then
                        _ProgramaticCheck = True
                        CheckedListBox_Options.SetItemChecked(index, True)
                    End If
                    index += 1
                Next
            End If

        End If
    End Sub

    Private Sub PopulateMagicalArtifact()
        _ProgramaticCheck = True
        ComboBox_MagicalArtifacts.Items.Clear()

        _ValidArtifacts.Clear()

        For Each artifact As MagicalArtifact In _MagicalArtifacts
            If artifact.MeetsRestrictions(_FocusedUnit) Then
                _ValidArtifacts.Add(artifact)
            End If
        Next

        ComboBox_MagicalArtifacts.Items.AddRange(_ValidArtifacts.ToArray)

        If _FocusedUnit IsNot Nothing Then
            If _FocusedUnit.EquipedArtifact IsNot Nothing Then
                ComboBox_MagicalArtifacts.SelectedIndex = _ValidArtifacts.IndexOf(_FocusedUnit.EquipedArtifact)
            Else
                ComboBox_MagicalArtifacts.SelectedIndex = 0
            End If
        End If

    End Sub

    Private Sub LoadXml()
        Dim xlApp As Excel.Application = New Excel.Application()
        Dim xlWorkBook As Excel.Workbook = xlApp.Workbooks.Open("C:\Users\PhilipCox\Desktop\Other\KowInput.xlsx")

        Dim Armies As New List(Of ArmyList)

        For Each sht As Excel.Worksheet In xlWorkBook.Sheets
            If sht.Name = "Magical Artifacts" Then
                _MagicalArtifacts = LoadArtifactSheet(sht)
            Else
                Dim importedArmyList As ArmyList = LoadArmySheet(sht)
                Armies.Add(importedArmyList)
            End If

        Next

        For Each army As ArmyList In Armies
            ComboBox_Army.Items.Add(army)
        Next

        'Dim xlWorkSheet = xlWorkBook.Worksheets("Order of the Green Lady")
        'xlWorkBook. = True  UnitStrength	Attacks	Nerve	PointCost	LivingLegend	Specials



        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)

    End Sub

    Private Function LoadArtifactSheet(xlWorkSheet As Worksheet) As List(Of MagicalArtifact)
        Dim magicalArtifacts As New List(Of MagicalArtifact)
        Dim row As Integer = 2
        While xlWorkSheet.Cells(row, 1).value <> ""
            Dim artifactName As String = xlWorkSheet.Cells(row, 1).value
            Dim restriction As String = xlWorkSheet.Cells(row, 2).value
            Dim costString As String = xlWorkSheet.Cells(row, 3).value
            Dim effectString As String = xlWorkSheet.Cells(row, 4).value
            Dim blankUnit As New KowUnit()
            Dim newArtifact As New MagicalArtifact(artifactName, restriction, costString, effectString, blankUnit.GetStats)
            magicalArtifacts.Add(newArtifact)
            ComboBox_MagicalArtifacts.Items.Add(newArtifact)
            row += 1
        End While

        releaseObject(xlWorkSheet)
        Return magicalArtifacts
    End Function

    Private Function LoadArmySheet(xlWorkSheet As Excel.Worksheet) As ArmyList
        Dim armyList1 As New ArmyList(xlWorkSheet.Name)

        Dim row As Integer = 2
        While xlWorkSheet.Cells(row, 1).value <> ""
            Dim unitName As String = xlWorkSheet.Cells(row, 1).value
            Dim unitSize As UnitSize = StringToUnitSize(xlWorkSheet.Cells(row, 2).value)
            Dim type As UnitType = StringToUnitType(xlWorkSheet.Cells(row, 3).value)
            Dim speed As String = xlWorkSheet.Cells(row, 4).value
            Dim melee As String = xlWorkSheet.Cells(row, 5).value
            Dim range As String = xlWorkSheet.Cells(row, 6).value
            Dim defense As String = xlWorkSheet.Cells(row, 7).value
            Dim unitStrength As String = xlWorkSheet.Cells(row, 8).value
            Dim attacks As String = xlWorkSheet.Cells(row, 9).value
            Dim nerve As String = xlWorkSheet.Cells(row, 10).value
            Dim height As Integer = xlWorkSheet.Cells(row, 11).value
            Dim pointsCost As String = xlWorkSheet.Cells(row, 12).value
            Dim livingLegend As Boolean = xlWorkSheet.Cells(row, 13).value
            Dim irregular As Boolean = xlWorkSheet.Cells(row, 14).value

            Dim specialsString As String = xlWorkSheet.Cells(row, 15).value
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

            Dim optionsString As String = xlWorkSheet.Cells(row, 16).value
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

            Dim kowUnit1 As New KowUnit(unitName, unitSize, pointsCost, unitStrength, nerve, speed, attacks, melee, range, defense, specialRules, optionalRules, type,
                                        livingLegend, irregular, height)
            armyList1.AddUnit(kowUnit1)
            row += 1
        End While

        'MsgBox("Army has " & armyList1.UnitCount & " Units.")

        releaseObject(xlWorkSheet)
        Return armyList1
    End Function

    Private Sub Button_SaveToText_Click(sender As Object, e As EventArgs) Handles Button_SaveToText.Click
        ' Displays a SaveFileDialog so the user can save the Image
        ' assigned to Button2.
        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Filter = "Text File|*.txt"
        saveFileDialog1.Title = "Save Army List as a Text File"
        saveFileDialog1.ShowDialog()

        ' If the file name is not an empty string open it for saving.
        If saveFileDialog1.FileName <> "" Then
            ' Saves the Image via a FileStream created by the OpenFile method.
            Dim fs As System.IO.FileStream = CType(saveFileDialog1.OpenFile(), System.IO.FileStream)
            fs.Close()
            Dim fileStrmWritr As System.IO.StreamWriter
            fileStrmWritr = My.Computer.FileSystem.OpenTextFileWriter(saveFileDialog1.FileName, True)
            fileStrmWritr.WriteLine(newArmyList.Name)
            For Each kUnit As KowUnit In newArmyList.Units
                Dim unitString As String = kUnit.Name & ";" & kUnit.Size.ToDisplayString & ";" & kUnit.Type.ToDisplayString & ";" & kUnit.Speed & ";" & kUnit.Melee & ";" & kUnit.Range & ";" &
                                        kUnit.Defense & ";" & kUnit.UnitStrength & ";" & kUnit.Attacks & ";" & kUnit.Nerve & ";" & kUnit.Height & ";" &
                                        kUnit.PointCost & ";" & kUnit.LivingLegend & ";" & kUnit.Irregular

                If kUnit.SpecialRules.Count > 0 Then
                    unitString = unitString & ";" & kUnit.SpecialsToString
                End If
                If kUnit.Options.Count > 0 Then
                    unitString = unitString & ";" & kUnit.OptionsToString
                End If

                fileStrmWritr.WriteLine(unitString)
            Next
            fileStrmWritr.Close()

        End If

        'Dim path As String = "C:\Users\PhilipCox\Desktop\Other\ArmyLists\ArmyList1.txt"


    End Sub

    Private Sub Button_LoadArmy_Click(sender As Object, e As EventArgs) Handles Button_LoadArmy.Click
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.InitialDirectory = "C:\Users\PhilipCox\Desktop\Other\ArmyLists\"
        openFileDialog1.Filter = "txt files (*.txt)|*.txt"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim unitStrings As New List(Of String)
            Try
                Dim path As String = openFileDialog1.FileName
                If (path IsNot Nothing) Then

                    ' Create an instance of StreamReader to read from a file.
                    Dim sr As StreamReader = New StreamReader(path)
                    ' Read and display the lines from the file until the end of the file is reached.

                    Dim line As String = sr.ReadLine()
                    Do While line IsNot Nothing
                        unitStrings.Add(line)
                        line = sr.ReadLine()
                        'MsgBox(unitStrings.LastOrDefault)
                    Loop
                    sr.Close()


                End If
            Catch Ex As Exception
                MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open.
            End Try

            Dim loadedArmyList As New ArmyList(unitStrings.FirstOrDefault)
            unitStrings.RemoveAt(0)
            For Each unitStr As String In unitStrings
                AddUnitToList(New KowUnit(unitStr))
                'loadedArmyList.AddUnit(New KowUnit(unitStr))

            Next

        End If

    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub


End Class
