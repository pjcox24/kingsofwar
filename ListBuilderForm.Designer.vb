<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListEditorForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ListBox_Units = New System.Windows.Forms.ListBox()
        Me.ComboBox_UnitType = New System.Windows.Forms.ComboBox()
        Me.Button_AddUnit = New System.Windows.Forms.Button()
        Me.Button_RemoveUnit = New System.Windows.Forms.Button()
        Me.TextBox_Unlocks = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox_Name = New System.Windows.Forms.TextBox()
        Me.TextBox_US = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox_Speed = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox_Melee = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox_Range = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox_Defense = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox_Attacks = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox_Nerve = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox_Points = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ComboBox_Army = New System.Windows.Forms.ComboBox()
        Me.Label_ArmyName = New System.Windows.Forms.Label()
        Me.Label_LivingLegend = New System.Windows.Forms.Label()
        Me.Label_Irregular = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox_TotalPoints = New System.Windows.Forms.TextBox()
        Me.CheckedListBox_Options = New System.Windows.Forms.CheckedListBox()
        Me.Label_Type = New System.Windows.Forms.Label()
        Me.TextBox_Height = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ComboBox_MagicalArtifacts = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Button_WriteToWord = New System.Windows.Forms.Button()
        Me.Button_SaveToText = New System.Windows.Forms.Button()
        Me.Button_LoadArmy = New System.Windows.Forms.Button()
        Me.ListBox_SpecialRules = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'ListBox_Units
        '
        Me.ListBox_Units.FormattingEnabled = True
        Me.ListBox_Units.Location = New System.Drawing.Point(439, 31)
        Me.ListBox_Units.Name = "ListBox_Units"
        Me.ListBox_Units.Size = New System.Drawing.Size(208, 277)
        Me.ListBox_Units.TabIndex = 0
        '
        'ComboBox_UnitType
        '
        Me.ComboBox_UnitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_UnitType.FormattingEnabled = True
        Me.ComboBox_UnitType.Location = New System.Drawing.Point(13, 46)
        Me.ComboBox_UnitType.Name = "ComboBox_UnitType"
        Me.ComboBox_UnitType.Size = New System.Drawing.Size(187, 21)
        Me.ComboBox_UnitType.TabIndex = 1
        '
        'Button_AddUnit
        '
        Me.Button_AddUnit.Location = New System.Drawing.Point(217, 31)
        Me.Button_AddUnit.Name = "Button_AddUnit"
        Me.Button_AddUnit.Size = New System.Drawing.Size(75, 36)
        Me.Button_AddUnit.TabIndex = 3
        Me.Button_AddUnit.Text = "Add Unit"
        Me.Button_AddUnit.UseVisualStyleBackColor = True
        '
        'Button_RemoveUnit
        '
        Me.Button_RemoveUnit.Location = New System.Drawing.Point(298, 31)
        Me.Button_RemoveUnit.Name = "Button_RemoveUnit"
        Me.Button_RemoveUnit.Size = New System.Drawing.Size(75, 36)
        Me.Button_RemoveUnit.TabIndex = 4
        Me.Button_RemoveUnit.Text = "Remove Unit"
        Me.Button_RemoveUnit.UseVisualStyleBackColor = True
        '
        'TextBox_Unlocks
        '
        Me.TextBox_Unlocks.Location = New System.Drawing.Point(439, 314)
        Me.TextBox_Unlocks.Multiline = True
        Me.TextBox_Unlocks.Name = "TextBox_Unlocks"
        Me.TextBox_Unlocks.Size = New System.Drawing.Size(208, 109)
        Me.TextBox_Unlocks.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Unit Name"
        '
        'TextBox_Name
        '
        Me.TextBox_Name.Location = New System.Drawing.Point(78, 76)
        Me.TextBox_Name.Name = "TextBox_Name"
        Me.TextBox_Name.ReadOnly = True
        Me.TextBox_Name.Size = New System.Drawing.Size(146, 20)
        Me.TextBox_Name.TabIndex = 7
        '
        'TextBox_US
        '
        Me.TextBox_US.Location = New System.Drawing.Point(178, 115)
        Me.TextBox_US.Name = "TextBox_US"
        Me.TextBox_US.ReadOnly = True
        Me.TextBox_US.Size = New System.Drawing.Size(59, 20)
        Me.TextBox_US.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(125, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "US"
        '
        'TextBox_Speed
        '
        Me.TextBox_Speed.Location = New System.Drawing.Point(58, 115)
        Me.TextBox_Speed.Name = "TextBox_Speed"
        Me.TextBox_Speed.ReadOnly = True
        Me.TextBox_Speed.Size = New System.Drawing.Size(53, 20)
        Me.TextBox_Speed.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Speed"
        '
        'TextBox_Melee
        '
        Me.TextBox_Melee.Location = New System.Drawing.Point(58, 141)
        Me.TextBox_Melee.Name = "TextBox_Melee"
        Me.TextBox_Melee.ReadOnly = True
        Me.TextBox_Melee.Size = New System.Drawing.Size(53, 20)
        Me.TextBox_Melee.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Melee"
        '
        'TextBox_Range
        '
        Me.TextBox_Range.Location = New System.Drawing.Point(58, 167)
        Me.TextBox_Range.Name = "TextBox_Range"
        Me.TextBox_Range.ReadOnly = True
        Me.TextBox_Range.Size = New System.Drawing.Size(53, 20)
        Me.TextBox_Range.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 170)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Range"
        '
        'TextBox_Defense
        '
        Me.TextBox_Defense.Location = New System.Drawing.Point(58, 193)
        Me.TextBox_Defense.Name = "TextBox_Defense"
        Me.TextBox_Defense.ReadOnly = True
        Me.TextBox_Defense.Size = New System.Drawing.Size(53, 20)
        Me.TextBox_Defense.TabIndex = 17
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 196)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Defense"
        '
        'TextBox_Attacks
        '
        Me.TextBox_Attacks.Location = New System.Drawing.Point(178, 141)
        Me.TextBox_Attacks.Name = "TextBox_Attacks"
        Me.TextBox_Attacks.ReadOnly = True
        Me.TextBox_Attacks.Size = New System.Drawing.Size(59, 20)
        Me.TextBox_Attacks.TabIndex = 19
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(125, 144)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Attacks"
        '
        'TextBox_Nerve
        '
        Me.TextBox_Nerve.Location = New System.Drawing.Point(178, 167)
        Me.TextBox_Nerve.Name = "TextBox_Nerve"
        Me.TextBox_Nerve.ReadOnly = True
        Me.TextBox_Nerve.Size = New System.Drawing.Size(59, 20)
        Me.TextBox_Nerve.TabIndex = 21
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(125, 170)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Nerve"
        '
        'TextBox_Points
        '
        Me.TextBox_Points.Location = New System.Drawing.Point(303, 115)
        Me.TextBox_Points.Name = "TextBox_Points"
        Me.TextBox_Points.ReadOnly = True
        Me.TextBox_Points.Size = New System.Drawing.Size(59, 20)
        Me.TextBox_Points.TabIndex = 23
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(250, 118)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Points"
        '
        'ComboBox_Army
        '
        Me.ComboBox_Army.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Army.FormattingEnabled = True
        Me.ComboBox_Army.Location = New System.Drawing.Point(13, 12)
        Me.ComboBox_Army.Name = "ComboBox_Army"
        Me.ComboBox_Army.Size = New System.Drawing.Size(187, 21)
        Me.ComboBox_Army.TabIndex = 27
        '
        'Label_ArmyName
        '
        Me.Label_ArmyName.AutoSize = True
        Me.Label_ArmyName.Location = New System.Drawing.Point(439, 12)
        Me.Label_ArmyName.Name = "Label_ArmyName"
        Me.Label_ArmyName.Size = New System.Drawing.Size(49, 13)
        Me.Label_ArmyName.TabIndex = 28
        Me.Label_ArmyName.Text = "Army List"
        '
        'Label_LivingLegend
        '
        Me.Label_LivingLegend.AutoSize = True
        Me.Label_LivingLegend.Location = New System.Drawing.Point(230, 79)
        Me.Label_LivingLegend.Name = "Label_LivingLegend"
        Me.Label_LivingLegend.Size = New System.Drawing.Size(71, 13)
        Me.Label_LivingLegend.TabIndex = 29
        Me.Label_LivingLegend.Text = "LivingLegend"
        '
        'Label_Irregular
        '
        Me.Label_Irregular.AutoSize = True
        Me.Label_Irregular.Location = New System.Drawing.Point(317, 79)
        Me.Label_Irregular.Name = "Label_Irregular"
        Me.Label_Irregular.Size = New System.Drawing.Size(45, 13)
        Me.Label_Irregular.TabIndex = 30
        Me.Label_Irregular.Text = "Irregular"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(474, 433)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 13)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "Total Points:"
        '
        'TextBox_TotalPoints
        '
        Me.TextBox_TotalPoints.Location = New System.Drawing.Point(547, 429)
        Me.TextBox_TotalPoints.Name = "TextBox_TotalPoints"
        Me.TextBox_TotalPoints.ReadOnly = True
        Me.TextBox_TotalPoints.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_TotalPoints.TabIndex = 32
        '
        'CheckedListBox_Options
        '
        Me.CheckedListBox_Options.CheckOnClick = True
        Me.CheckedListBox_Options.FormattingEnabled = True
        Me.CheckedListBox_Options.HorizontalScrollbar = True
        Me.CheckedListBox_Options.Location = New System.Drawing.Point(12, 315)
        Me.CheckedListBox_Options.Name = "CheckedListBox_Options"
        Me.CheckedListBox_Options.Size = New System.Drawing.Size(421, 109)
        Me.CheckedListBox_Options.TabIndex = 34
        '
        'Label_Type
        '
        Me.Label_Type.AutoSize = True
        Me.Label_Type.Location = New System.Drawing.Point(75, 99)
        Me.Label_Type.Name = "Label_Type"
        Me.Label_Type.Size = New System.Drawing.Size(31, 13)
        Me.Label_Type.TabIndex = 35
        Me.Label_Type.Text = "Type"
        '
        'TextBox_Height
        '
        Me.TextBox_Height.Location = New System.Drawing.Point(178, 193)
        Me.TextBox_Height.Name = "TextBox_Height"
        Me.TextBox_Height.ReadOnly = True
        Me.TextBox_Height.Size = New System.Drawing.Size(59, 20)
        Me.TextBox_Height.TabIndex = 37
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(125, 196)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 13)
        Me.Label11.TabIndex = 36
        Me.Label11.Text = "Height"
        '
        'ComboBox_MagicalArtifacts
        '
        Me.ComboBox_MagicalArtifacts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_MagicalArtifacts.FormattingEnabled = True
        Me.ComboBox_MagicalArtifacts.Location = New System.Drawing.Point(253, 170)
        Me.ComboBox_MagicalArtifacts.Name = "ComboBox_MagicalArtifacts"
        Me.ComboBox_MagicalArtifacts.Size = New System.Drawing.Size(169, 21)
        Me.ComboBox_MagicalArtifacts.TabIndex = 38
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(250, 154)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 13)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "Magical Artifact"
        '
        'Button_WriteToWord
        '
        Me.Button_WriteToWord.Location = New System.Drawing.Point(333, 429)
        Me.Button_WriteToWord.Name = "Button_WriteToWord"
        Me.Button_WriteToWord.Size = New System.Drawing.Size(100, 23)
        Me.Button_WriteToWord.TabIndex = 40
        Me.Button_WriteToWord.Text = "Write To Word"
        Me.Button_WriteToWord.UseVisualStyleBackColor = True
        '
        'Button_SaveToText
        '
        Me.Button_SaveToText.Location = New System.Drawing.Point(227, 429)
        Me.Button_SaveToText.Name = "Button_SaveToText"
        Me.Button_SaveToText.Size = New System.Drawing.Size(100, 23)
        Me.Button_SaveToText.TabIndex = 41
        Me.Button_SaveToText.Text = "Save To Text File"
        Me.Button_SaveToText.UseVisualStyleBackColor = True
        '
        'Button_LoadArmy
        '
        Me.Button_LoadArmy.Location = New System.Drawing.Point(121, 429)
        Me.Button_LoadArmy.Name = "Button_LoadArmy"
        Me.Button_LoadArmy.Size = New System.Drawing.Size(100, 23)
        Me.Button_LoadArmy.TabIndex = 42
        Me.Button_LoadArmy.Text = "Load Army List"
        Me.Button_LoadArmy.UseVisualStyleBackColor = True
        '
        'ListBox_SpecialRules
        '
        Me.ListBox_SpecialRules.FormattingEnabled = True
        Me.ListBox_SpecialRules.Location = New System.Drawing.Point(13, 226)
        Me.ListBox_SpecialRules.Name = "ListBox_SpecialRules"
        Me.ListBox_SpecialRules.Size = New System.Drawing.Size(420, 82)
        Me.ListBox_SpecialRules.TabIndex = 43
        '
        'ListEditorForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(659, 455)
        Me.Controls.Add(Me.ListBox_SpecialRules)
        Me.Controls.Add(Me.Button_LoadArmy)
        Me.Controls.Add(Me.Button_SaveToText)
        Me.Controls.Add(Me.Button_WriteToWord)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.ComboBox_MagicalArtifacts)
        Me.Controls.Add(Me.TextBox_Height)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label_Type)
        Me.Controls.Add(Me.CheckedListBox_Options)
        Me.Controls.Add(Me.TextBox_TotalPoints)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label_Irregular)
        Me.Controls.Add(Me.Label_LivingLegend)
        Me.Controls.Add(Me.Label_ArmyName)
        Me.Controls.Add(Me.ComboBox_Army)
        Me.Controls.Add(Me.TextBox_Points)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TextBox_Nerve)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextBox_Attacks)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextBox_Defense)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBox_Range)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBox_Melee)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBox_Speed)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox_US)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox_Name)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox_Unlocks)
        Me.Controls.Add(Me.Button_RemoveUnit)
        Me.Controls.Add(Me.Button_AddUnit)
        Me.Controls.Add(Me.ComboBox_UnitType)
        Me.Controls.Add(Me.ListBox_Units)
        Me.Name = "ListEditorForm"
        Me.Text = "List Builder"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ListBox_Units As ListBox
    Friend WithEvents ComboBox_UnitType As ComboBox
    Friend WithEvents Button_AddUnit As Button
    Friend WithEvents Button_RemoveUnit As Button
    Friend WithEvents TextBox_Unlocks As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox_Name As TextBox
    Friend WithEvents TextBox_US As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox_Speed As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox_Melee As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox_Range As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox_Defense As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox_Attacks As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBox_Nerve As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBox_Points As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents ComboBox_Army As ComboBox
    Friend WithEvents Label_ArmyName As Label
    Friend WithEvents Label_LivingLegend As Label
    Friend WithEvents Label_Irregular As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents TextBox_TotalPoints As TextBox
    Friend WithEvents CheckedListBox_Options As CheckedListBox
    Friend WithEvents Label_Type As Label
    Friend WithEvents TextBox_Height As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents ComboBox_MagicalArtifacts As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Button_WriteToWord As Button
    Friend WithEvents Button_SaveToText As Button
    Friend WithEvents Button_LoadArmy As Button
    Friend WithEvents ListBox_SpecialRules As ListBox
End Class
