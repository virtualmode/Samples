VERSION 5.00
Object = "{3B7C8863-D78F-101B-B9B5-04021C009402}#1.2#0"; "RICHTX32.OCX"
Begin VB.Form frmTCR 
   BackColor       =   &H00000000&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Утилита создания тестов"
   ClientHeight    =   10710
   ClientLeft      =   45
   ClientTop       =   435
   ClientWidth     =   11055
   BeginProperty Font 
      Name            =   "Arial"
      Size            =   8.25
      Charset         =   204
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   ForeColor       =   &H00FFFFFF&
   Icon            =   "frmTCR.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   ScaleHeight     =   10710
   ScaleWidth      =   11055
   StartUpPosition =   2  'CenterScreen
   Begin VB.TextBox txtAnswer 
      Appearance      =   0  'Flat
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   14.25
         Charset         =   204
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   465
      Left            =   120
      TabIndex        =   18
      Top             =   8400
      Visible         =   0   'False
      Width           =   10815
   End
   Begin VB.TextBox txtD 
      Appearance      =   0  'Flat
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   14.25
         Charset         =   204
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   465
      Left            =   6240
      TabIndex        =   16
      Top             =   8640
      Visible         =   0   'False
      Width           =   4695
   End
   Begin VB.TextBox txtB 
      Appearance      =   0  'Flat
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   14.25
         Charset         =   204
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   465
      Left            =   6240
      TabIndex        =   14
      Top             =   7800
      Visible         =   0   'False
      Width           =   4695
   End
   Begin VB.TextBox txtC 
      Appearance      =   0  'Flat
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   14.25
         Charset         =   204
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   465
      Left            =   720
      TabIndex        =   12
      Top             =   8640
      Visible         =   0   'False
      Width           =   4695
   End
   Begin VB.TextBox txtA 
      Appearance      =   0  'Flat
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   14.25
         Charset         =   204
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   465
      Left            =   720
      TabIndex        =   10
      Top             =   7800
      Visible         =   0   'False
      Width           =   4695
   End
   Begin RichTextLib.RichTextBox txtQuestion 
      Height          =   2895
      Left            =   120
      TabIndex        =   7
      Top             =   3960
      Visible         =   0   'False
      Width           =   10815
      _ExtentX        =   19076
      _ExtentY        =   5106
      _Version        =   393217
      Enabled         =   -1  'True
      ScrollBars      =   2
      Appearance      =   0
      TextRTF         =   $"frmTCR.frx":5122
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "Arial"
         Size            =   14.25
         Charset         =   204
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
   End
   Begin VB.FileListBox flTest 
      Appearance      =   0  'Flat
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   14.25
         Charset         =   204
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2010
      Left            =   120
      Pattern         =   "*.iqt"
      TabIndex        =   3
      Top             =   600
      Width           =   10815
   End
   Begin VB.Label lblTime 
      Alignment       =   1  'Right Justify
      BackColor       =   &H00000000&
      BackStyle       =   0  'Transparent
      Caption         =   "30 минут(а) на тест"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   15.75
         Charset         =   204
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   495
      Left            =   5520
      TabIndex        =   24
      Top             =   3480
      Visible         =   0   'False
      Width           =   5415
   End
   Begin VB.Label lblBack 
      BackColor       =   &H00000000&
      BackStyle       =   0  'Transparent
      Caption         =   "Назад"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   15.75
         Charset         =   204
         Weight          =   400
         Underline       =   -1  'True
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   495
      Left            =   240
      TabIndex        =   22
      Top             =   9360
      Visible         =   0   'False
      Width           =   1455
   End
   Begin VB.Label lblForward 
      Alignment       =   1  'Right Justify
      BackColor       =   &H00000000&
      BackStyle       =   0  'Transparent
      Caption         =   "Далее"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   15.75
         Charset         =   204
         Weight          =   400
         Underline       =   -1  'True
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   495
      Left            =   9120
      TabIndex        =   21
      Top             =   9360
      Visible         =   0   'False
      Width           =   1695
   End
   Begin VB.Label lblInfo 
      BackColor       =   &H00000000&
      BackStyle       =   0  'Transparent
      Caption         =   "Доп. информация"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   15.75
         Charset         =   204
         Weight          =   400
         Underline       =   -1  'True
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   495
      Left            =   240
      TabIndex        =   20
      Top             =   2760
      Visible         =   0   'False
      Width           =   2775
   End
   Begin VB.Label lblAnswer 
      BackColor       =   &H00000000&
      BackStyle       =   0  'Transparent
      Caption         =   "Ответ:"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   15.75
         Charset         =   204
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   495
      Left            =   120
      TabIndex        =   19
      Top             =   7920
      Visible         =   0   'False
      Width           =   3015
   End
   Begin VB.Label lblD 
      BackColor       =   &H00000000&
      BackStyle       =   0  'Transparent
      Caption         =   "D:"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   15.75
         Charset         =   204
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   495
      Left            =   5760
      TabIndex        =   17
      Top             =   8690
      Visible         =   0   'False
      Width           =   375
   End
   Begin VB.Label lblB 
      BackColor       =   &H00000000&
      BackStyle       =   0  'Transparent
      Caption         =   "B:"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   15.75
         Charset         =   204
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   495
      Left            =   5760
      TabIndex        =   15
      Top             =   7850
      Visible         =   0   'False
      Width           =   375
   End
   Begin VB.Label lblC 
      BackColor       =   &H00000000&
      BackStyle       =   0  'Transparent
      Caption         =   "C:"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   15.75
         Charset         =   204
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   495
      Left            =   240
      TabIndex        =   13
      Top             =   8690
      Visible         =   0   'False
      Width           =   375
   End
   Begin VB.Label lblA 
      BackColor       =   &H00000000&
      BackStyle       =   0  'Transparent
      Caption         =   "A:"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   15.75
         Charset         =   204
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   495
      Left            =   240
      TabIndex        =   11
      Top             =   7850
      Visible         =   0   'False
      Width           =   375
   End
   Begin VB.Label lblType 
      BackColor       =   &H00000000&
      BackStyle       =   0  'Transparent
      Caption         =   "(A) вопрос"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   15.75
         Charset         =   204
         Weight          =   400
         Underline       =   -1  'True
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   495
      Left            =   240
      TabIndex        =   9
      Top             =   6960
      Visible         =   0   'False
      Width           =   1575
   End
   Begin VB.Label lblQuestion 
      BackColor       =   &H00000000&
      BackStyle       =   0  'Transparent
      Caption         =   "Вопрос 1 из 1:"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   15.75
         Charset         =   204
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   615
      Left            =   120
      TabIndex        =   8
      Top             =   3480
      Visible         =   0   'False
      Width           =   5295
   End
   Begin VB.Label lblRename 
      BackColor       =   &H00000000&
      BackStyle       =   0  'Transparent
      Caption         =   "Переименовать"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   15.75
         Charset         =   204
         Weight          =   400
         Underline       =   -1  'True
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   495
      Left            =   6960
      TabIndex        =   6
      Top             =   2760
      Width           =   2415
   End
   Begin VB.Label lblDel 
      BackColor       =   &H00000000&
      BackStyle       =   0  'Transparent
      Caption         =   "Удалить"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   15.75
         Charset         =   204
         Weight          =   400
         Underline       =   -1  'True
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   495
      Left            =   9600
      TabIndex        =   5
      Top             =   2760
      Width           =   1335
   End
   Begin VB.Label lblCreate 
      BackColor       =   &H00000000&
      BackStyle       =   0  'Transparent
      Caption         =   "Создать"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   15.75
         Charset         =   204
         Weight          =   400
         Underline       =   -1  'True
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   495
      Left            =   5400
      TabIndex        =   4
      Top             =   2760
      Width           =   1335
   End
   Begin VB.Label lblName 
      BackColor       =   &H00000000&
      BackStyle       =   0  'Transparent
      Caption         =   "Название теста:"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   15.75
         Charset         =   204
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   615
      Left            =   120
      TabIndex        =   2
      Top             =   120
      Width           =   3015
   End
   Begin VB.Label lblYear 
      BackColor       =   &H00000000&
      BackStyle       =   0  'Transparent
      Caption         =   "2005"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   24
         Charset         =   204
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFBB8E&
      Height          =   615
      Left            =   9720
      TabIndex        =   1
      Top             =   9960
      Width           =   1215
   End
   Begin VB.Label lblVirtualmode 
      Alignment       =   2  'Center
      BackColor       =   &H00000000&
      BackStyle       =   0  'Transparent
      Caption         =   "© virtualmode"
      ForeColor       =   &H00FFBB8E&
      Height          =   735
      Left            =   165
      TabIndex        =   0
      Top             =   9840
      Width           =   4215
   End
   Begin VB.Label lblMark 
      Alignment       =   1  'Right Justify
      BackColor       =   &H00000000&
      BackStyle       =   0  'Transparent
      Caption         =   "1 балл(а, ов)"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   15.75
         Charset         =   204
         Weight          =   400
         Underline       =   -1  'True
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   495
      Left            =   8160
      TabIndex        =   23
      Top             =   6960
      Visible         =   0   'False
      Width           =   2655
   End
   Begin VB.Shape shpD 
      FillColor       =   &H00FFFFFF&
      Height          =   495
      Left            =   5640
      Top             =   8640
      Visible         =   0   'False
      Width           =   495
   End
   Begin VB.Shape shpC 
      FillColor       =   &H00FFFFFF&
      Height          =   495
      Left            =   120
      Top             =   8640
      Visible         =   0   'False
      Width           =   495
   End
   Begin VB.Shape shpB 
      FillColor       =   &H00FFFFFF&
      Height          =   495
      Left            =   5640
      Top             =   7800
      Visible         =   0   'False
      Width           =   495
   End
   Begin VB.Shape shpA 
      FillColor       =   &H00FFFFFF&
      Height          =   495
      Left            =   120
      Top             =   7800
      Visible         =   0   'False
      Width           =   495
   End
End
Attribute VB_Name = "frmTCR"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Long, ByVal lpFileName As String) As Long
Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As Any, ByVal lpFileName As String) As Long

Private pq As Integer
Private aq As Integer


Public Function ReadINI(Section As String, Key As String, FileName As String) As String
    
    Dim sRet As String
    sRet = String(255, Chr(0))
    ReadINI = Left(sRet, GetPrivateProfileString(Section, ByVal Key, "", sRet, Len(sRet), FileName))

End Function

Public Sub WriteINI(Section As String, Key As String, Data As String, FileName As String)

    WritePrivateProfileString Section, Key, Data, FileName
    
End Sub

Private Sub Hide0()

    shpA.Visible = False
    shpB.Visible = False
    shpC.Visible = False
    shpD.Visible = False
    lblTime.Visible = False
    lblType.Visible = False
    lblMark.Visible = False
    lblInfo.Visible = False
    lblQuestion.Visible = False
    txtQuestion.Visible = False
    lblA.Visible = False
    txtA.Visible = False
    lblB.Visible = False
    txtB.Visible = False
    lblC.Visible = False
    txtC.Visible = False
    lblD.Visible = False
    txtD.Visible = False
    lblAnswer.Visible = False
    txtAnswer.Visible = False
    lblBack.Visible = False
    lblForward.Visible = False

End Sub

Private Sub ShowG()

    'lblTime.Visible = True
    lblType.Visible = True
    lblMark.Visible = True
    lblQuestion.Visible = True
    txtQuestion.Visible = True
    lblBack.Visible = True
    lblForward.Visible = True

End Sub

Private Sub HideG()

    'lblTime.Visible = False
    lblType.Visible = False
    lblMark.Visible = False
    lblQuestion.Visible = False
    txtQuestion.Visible = False
    lblBack.Visible = False
    lblForward.Visible = False

End Sub

Private Sub ShowA()

    shpA.Visible = True
    shpB.Visible = True
    shpC.Visible = True
    shpD.Visible = True
    lblA.Visible = True
    txtA.Visible = True
    lblB.Visible = True
    txtB.Visible = True
    lblC.Visible = True
    txtC.Visible = True
    lblD.Visible = True
    txtD.Visible = True

End Sub

Private Sub HideA()

    shpA.Visible = False
    shpB.Visible = False
    shpC.Visible = False
    shpD.Visible = False
    lblA.Visible = False
    txtA.Visible = False
    lblB.Visible = False
    txtB.Visible = False
    lblC.Visible = False
    txtC.Visible = False
    lblD.Visible = False
    txtD.Visible = False

End Sub

Private Sub ShowB()

    lblAnswer.Visible = True
    txtAnswer.Visible = True

End Sub

Private Sub HideB()

    lblAnswer.Visible = False
    txtAnswer.Visible = False

End Sub

Private Sub UpdateShp()

    Dim s As String
    s = ReadINI("q" + Trim(Str(aq)), "a", App.Path + "\" + flTest.FileName)
    If (Mid(s, 1, 1) = "1") Then
        shpA.BackStyle = 1
    Else
        shpA.BackStyle = 0
    End If
    If (Mid(s, 2, 1) = "1") Then
        shpB.BackStyle = 1
    Else
        shpB.BackStyle = 0
    End If
    If (Mid(s, 3, 1) = "1") Then
        shpC.BackStyle = 1
    Else
        shpC.BackStyle = 0
    End If
    If (Mid(s, 4, 1) = "1") Then
        shpD.BackStyle = 1
    Else
        shpD.BackStyle = 0
    End If

End Sub

Private Sub AddShp()

Dim s As String
s = ""
If (shpA.BackStyle = 1) Then
    s = s + "1"
Else
    s = s + "0"
End If
If (shpB.BackStyle = 1) Then
    s = s + "1"
Else
    s = s + "0"
End If
If (shpC.BackStyle = 1) Then
    s = s + "1"
Else
    s = s + "0"
End If
If (shpD.BackStyle = 1) Then
    s = s + "1"
Else
    s = s + "0"
End If
WriteINI "q" + Trim(Str(aq)), "a", s, App.Path + "\" + flTest.FileName

End Sub

Private Sub ShowQuestion(n As Integer)

    ShowG
    aq = n
    lblQuestion.Caption = "Вопрос " + Trim(Str(n)) + " из " + Trim(Str(pq))
    txtQuestion.Text = ReadINI("q" + Trim(Str(n)), "q", App.Path + "\" + flTest.FileName)
    lblMark.Caption = ReadINI("q" + Trim(Str(n)), "b", App.Path + "\" + flTest.FileName) + " балл(а, ов)"
    If (Mid(ReadINI("q" + Trim(Str(n)), "a", App.Path + "\" + flTest.FileName), 1, 1) = "$") Then
        lblType.Caption = "(B) вопрос"
        HideA
        ShowB
        txtAnswer.Text = Mid(ReadINI("q" + Trim(Str(n)), "a", App.Path + "\" + flTest.FileName), 2)
    Else
        lblType.Caption = "(A) вопрос"
        HideB
        ShowA
        UpdateShp
        txtA.Text = ReadINI("q" + Trim(Str(n)), "a1", App.Path + "\" + flTest.FileName)
        txtB.Text = ReadINI("q" + Trim(Str(n)), "a2", App.Path + "\" + flTest.FileName)
        txtC.Text = ReadINI("q" + Trim(Str(n)), "a3", App.Path + "\" + flTest.FileName)
        txtD.Text = ReadINI("q" + Trim(Str(n)), "a4", App.Path + "\" + flTest.FileName)
    End If
    If (aq = 1) Then
        lblBack.Enabled = False
        lblBack.ForeColor = RGB(100, 100, 100)
    Else
        lblBack.Enabled = True
        lblBack.ForeColor = RGB(255, 255, 255)
    End If
    If (aq = pq) Then
        lblForward.Caption = "Добавить"
    Else
        lblForward.Caption = "Далее"
    End If

End Sub

Private Sub Initialize()

    pq = Val(ReadINI("Init", "q", App.Path + "\" + flTest.FileName))
    lblInfo.Visible = True
    lblTime.Visible = True
    lblTime.Caption = Trim(ReadINI("Init", "t", App.Path + "\" + flTest.FileName)) + " минут(а) на тест"
    If (Trim(ReadINI("Init", "q", App.Path + "\" + flTest.FileName)) = "0") Then
        HideA
        HideB
        HideG
        lblForward.Visible = True
        lblForward.Caption = "Добавить"
    Else
        ShowQuestion 1
    End If

End Sub

Private Sub flTest_Click()

    If Not (Trim(flTest.FileName) = "") Then
        Initialize
    End If

End Sub

Private Sub Form_Load()

    flTest.Path = App.Path
    Draw Me, 0, RGB(0, 0, 0), RGB(1, 100, 248)
    lblVirtualmode.Caption = "IQT 1.2" + Chr(13) + Chr(10) + "Группа разработчиков программного обеспечения" + Chr(13) + Chr(10) + "Острог, 2005 - 2006 :)"

End Sub

Private Sub Deselect()

    lblCreate.ForeColor = RGB(255, 255, 255)
    lblInfo.ForeColor = RGB(255, 255, 255)
    lblType.ForeColor = RGB(255, 255, 255)
    lblDel.ForeColor = RGB(255, 255, 255)
    lblBack.ForeColor = RGB(255, 255, 255)
    lblForward.ForeColor = RGB(255, 255, 255)
    lblRename.ForeColor = RGB(255, 255, 255)
    lblMark.ForeColor = RGB(255, 255, 255)
    lblA.ForeColor = RGB(255, 255, 255)
    lblB.ForeColor = RGB(255, 255, 255)
    lblC.ForeColor = RGB(255, 255, 255)
    lblD.ForeColor = RGB(255, 255, 255)
    lblQuestion.ForeColor = RGB(255, 255, 255)
    lblTime.ForeColor = RGB(255, 255, 255)
    
End Sub

Private Sub Form_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    Deselect

End Sub

Private Sub lblA_Click()

    If (shpA.BackStyle = 1) Then
        shpA.BackStyle = 0
    Else
        shpA.BackStyle = 1
    End If
    AddShp
    
End Sub

Private Sub lblA_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    Deselect
    lblA.ForeColor = RGB(142, 187, 255)
    
End Sub

Private Sub lblB_Click()

    If (shpB.BackStyle = 1) Then
        shpB.BackStyle = 0
    Else
        shpB.BackStyle = 1
    End If
    AddShp

End Sub

Private Sub lblB_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    Deselect
    lblB.ForeColor = RGB(142, 187, 255)

End Sub

Private Sub lblBack_Click()

    If (aq > 1) Then
        ShowQuestion aq - 1
    End If

End Sub

Private Sub lblBack_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    Deselect
    lblBack.ForeColor = RGB(142, 187, 255)

End Sub

Private Sub lblC_Click()

    If (shpC.BackStyle = 1) Then
        shpC.BackStyle = 0
    Else
        shpC.BackStyle = 1
    End If
    AddShp

End Sub

Private Sub lblC_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    Deselect
    lblC.ForeColor = RGB(142, 187, 255)

End Sub

Private Sub lblCreate_Click()

    Dim s As String
    s = InputBox("Введите имя теста:", "Создание теста")
    s = Trim(s)
    If Not (s = "") Then
        WriteINI "Init", "q", "0", App.Path + "\" + s + ".iqt"
        WriteINI "Init", "t", "0", App.Path + "\" + s + ".iqt"
    Else
        MsgBox "Имя теста не было введено. Файл не создан!", vbInformation, "Нет данных"
    End If
    flTest.Refresh

End Sub

Private Sub lblCreate_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    Deselect
    lblCreate.ForeColor = RGB(142, 187, 255)

End Sub

Private Sub lblD_Click()

    If (shpD.BackStyle = 1) Then
        shpD.BackStyle = 0
    Else
        shpD.BackStyle = 1
    End If
    AddShp

End Sub

Private Sub lblD_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    Deselect
    lblD.ForeColor = RGB(142, 187, 255)

End Sub

Private Sub lblDel_Click()

    If Not (Trim(flTest.FileName) = "") Then
        If (MsgBox("Удалить файл " + flTest.FileName + "?", vbYesNo, "Подтверждение") = vbYes) Then Kill App.Path + "\" + flTest.FileName
        flTest.Refresh
        Hide0
    Else
        MsgBox "Файл не выбран!", vbInformation, "Нет данных"
    End If

End Sub

Private Sub lblDel_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    Deselect
    lblDel.ForeColor = RGB(142, 187, 255)

End Sub

Private Sub lblForward_Click()

    If (aq < pq) Then
        ShowQuestion aq + 1
    Else
        pq = pq + 1
        WriteINI "Init", "q", Trim(Str(pq)), App.Path + "\" + flTest.FileName
        WriteINI "q" + Trim(Str(pq)), "q", "[Введите в это поле вопрос. <Enter> использовать запрещено!]", App.Path + "\" + flTest.FileName
        WriteINI "q" + Trim(Str(pq)), "a", "0000", App.Path + "\" + flTest.FileName
        WriteINI "q" + Trim(Str(pq)), "b", "1", App.Path + "\" + flTest.FileName
        WriteINI "q" + Trim(Str(pq)), "a1", "[Ответ A]", App.Path + "\" + flTest.FileName
        WriteINI "q" + Trim(Str(pq)), "a2", "[Ответ B]", App.Path + "\" + flTest.FileName
        WriteINI "q" + Trim(Str(pq)), "a3", "[Ответ C]", App.Path + "\" + flTest.FileName
        WriteINI "q" + Trim(Str(pq)), "a4", "[Ответ D]", App.Path + "\" + flTest.FileName
        ShowQuestion pq
    End If

End Sub

Private Sub lblForward_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    Deselect
    lblForward.ForeColor = RGB(142, 187, 255)

End Sub

Private Sub lblInfo_Click()

    frmInfo.Show 1, Me
    
End Sub

Private Sub lblInfo_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    Deselect
    lblInfo.ForeColor = RGB(142, 187, 255)
    
End Sub

Private Sub lblMark_Click()

    Dim m As Integer
    m = Val(InputBox("Введите кол-во баллов за данный вопрос:", "Балл за вопрос"))
    WriteINI "q" + Trim(Str(aq)), "b", Trim(Str(m)), App.Path + "\" + flTest.FileName
    ShowQuestion aq

End Sub

Private Sub lblMark_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    Deselect
    lblMark.ForeColor = RGB(142, 187, 255)

End Sub

Private Sub lblQuestion_Click()

    Dim i As Integer
    i = Val(InputBox("Введите номер вопроса:", "Переход к вопросу"))
    If (i > 0) And (i <= pq) Then
        ShowQuestion i
    Else
        MsgBox "Вопроса" + Str(i) + " не существует!", vbInformation, "Ошибка"
    End If

End Sub

Private Sub lblQuestion_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    Deselect
    lblQuestion.ForeColor = RGB(142, 187, 255)

End Sub

Private Sub lblRename_Click()

    Dim s As String
    If Not (Trim(flTest.FileName) = "") Then
        s = InputBox("Введите новое имя для файла " + flTest.FileName + ":", "Введите новое имя")
        If (Trim(s) = "") Then
            MsgBox "Новое имя теста не задано. Файл не переименован!", vbInformation, "Нет данных"
        Else
            FileCopy App.Path + "\" + flTest.FileName, App.Path + "\" + s + ".iqt"
            Kill App.Path + "\" + flTest.FileName
        End If
        flTest.Refresh
    Else
        MsgBox "Файл не выбран!", vbInformation, "Нет данных"
    End If

End Sub

Private Sub lblRename_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    Deselect
    lblRename.ForeColor = RGB(142, 187, 255)

End Sub

Private Sub lblTime_Click()

    Dim i As Integer
    i = Val(InputBox("Введите время на выполнение теста:", "Время на выполнение теста"))
    If (i >= 0) Then
        WriteINI "Init", "t", Trim(Str(i)), App.Path + "\" + flTest.FileName
        lblTime.Caption = Trim(Str(i)) + " минут(а) на тест"
    Else
        MsgBox "Время не может быть отрицательным!", vbInformation, "Ошибка"
    End If

End Sub

Private Sub lblTime_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    Deselect
    lblTime.ForeColor = RGB(142, 187, 255)

End Sub

Private Sub lblType_Click()

    If (MsgBox("Изменить тип вопроса?", vbYesNo, "Тип вопроса") = vbYes) Then
        If (Mid(lblType.Caption, 1, 3) = "(A)") Then
            lblType.Caption = "(B) вопрос"
            WriteINI "q" + Trim(Str(aq)), "a", "$[Ответ]", App.Path + "\" + flTest.FileName
            ShowQuestion aq
        Else
            lblType.Caption = "(A) вопрос"
            WriteINI "q" + Trim(Str(aq)), "a", "0000", App.Path + "\" + flTest.FileName
            WriteINI "q" + Trim(Str(aq)), "a1", "[Ответ A]", App.Path + "\" + flTest.FileName
            WriteINI "q" + Trim(Str(aq)), "a2", "[Ответ B]", App.Path + "\" + flTest.FileName
            WriteINI "q" + Trim(Str(aq)), "a3", "[Ответ C]", App.Path + "\" + flTest.FileName
            WriteINI "q" + Trim(Str(aq)), "a4", "[Ответ D]", App.Path + "\" + flTest.FileName
            ShowQuestion aq
        End If
    End If

End Sub

Private Sub lblType_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    Deselect
    lblType.ForeColor = RGB(142, 187, 255)

End Sub

Private Sub txtA_Change()

    WriteINI "q" + Trim(Str(aq)), "a1", txtA.Text, App.Path + "\" + flTest.FileName

End Sub

Private Sub txtAnswer_Change()

    WriteINI "q" + Trim(Str(aq)), "a", "$" + txtAnswer.Text, App.Path + "\" + flTest.FileName

End Sub

Private Sub txtB_Change()

    WriteINI "q" + Trim(Str(aq)), "a2", txtB.Text, App.Path + "\" + flTest.FileName

End Sub

Private Sub txtC_Change()

    WriteINI "q" + Trim(Str(aq)), "a3", txtC.Text, App.Path + "\" + flTest.FileName

End Sub

Private Sub txtD_Change()

    WriteINI "q" + Trim(Str(aq)), "a4", txtD.Text, App.Path + "\" + flTest.FileName

End Sub

Private Sub txtQuestion_Change()

    WriteINI "q" + Trim(Str(aq)), "q", txtQuestion.Text, App.Path + "\" + flTest.FileName
    If (Trim(txtQuestion.Text) = "") And (aq = pq) And (Not (pq = 1)) Then
        If (MsgBox("Удалить этот вопрос?", vbYesNo, "Удаление") = vbYes) Then
            pq = pq - 1
            WriteINI "Init", "q", Trim(Str(pq)), App.Path + "\" + flTest.FileName
            ShowQuestion pq
        End If
    End If

End Sub

Private Sub txtQuestion_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    Deselect

End Sub
