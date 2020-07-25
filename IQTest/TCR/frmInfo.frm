VERSION 5.00
Object = "{3B7C8863-D78F-101B-B9B5-04021C009402}#1.2#0"; "RICHTX32.OCX"
Begin VB.Form frmInfo 
   BackColor       =   &H00000000&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Доп. информация"
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
   Icon            =   "frmInfo.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   10710
   ScaleWidth      =   11055
   StartUpPosition =   2  'CenterScreen
   Begin VB.TextBox txtTopic 
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
      TabIndex        =   0
      Top             =   600
      Width           =   10815
   End
   Begin RichTextLib.RichTextBox txtText 
      Height          =   7455
      Left            =   120
      TabIndex        =   1
      Top             =   1680
      Width           =   10815
      _ExtentX        =   19076
      _ExtentY        =   13150
      _Version        =   393217
      Enabled         =   -1  'True
      ScrollBars      =   2
      Appearance      =   0
      TextRTF         =   $"frmInfo.frx":5122
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
   Begin VB.Label lblOk 
      BackColor       =   &H00000000&
      BackStyle       =   0  'Transparent
      Caption         =   "Ok"
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
      Left            =   10440
      TabIndex        =   7
      Top             =   9240
      Width           =   495
   End
   Begin VB.Label lblDelete 
      BackColor       =   &H00000000&
      BackStyle       =   0  'Transparent
      Caption         =   "Очистить доп. информацию"
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
      Left            =   120
      TabIndex        =   6
      Top             =   9240
      Width           =   4095
   End
   Begin VB.Label lblVirtualmode 
      Alignment       =   2  'Center
      BackColor       =   &H00000000&
      BackStyle       =   0  'Transparent
      Caption         =   "© virtualmode"
      ForeColor       =   &H00FFBB8E&
      Height          =   735
      Left            =   165
      TabIndex        =   5
      Top             =   9840
      Width           =   4215
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
      TabIndex        =   4
      Top             =   9960
      Width           =   1215
   End
   Begin VB.Label Label1 
      BackColor       =   &H00000000&
      BackStyle       =   0  'Transparent
      Caption         =   "Текст:"
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
      TabIndex        =   3
      Top             =   1200
      Width           =   1095
   End
   Begin VB.Label lblName 
      BackColor       =   &H00000000&
      BackStyle       =   0  'Transparent
      Caption         =   "Заголовок:"
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
      Width           =   1695
   End
End
Attribute VB_Name = "frmInfo"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Long, ByVal lpFileName As String) As Long
Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As Any, ByVal lpFileName As String) As Long

Public Function ReadINI(Section As String, Key As String, FileName As String) As String
    
    Dim sRet As String
    sRet = String(255, Chr(0))
    ReadINI = Left(sRet, GetPrivateProfileString(Section, ByVal Key, "", sRet, Len(sRet), FileName))

End Function

Public Sub WriteINI(Section As String, Key As String, Data As String, FileName As String)

    WritePrivateProfileString Section, Key, Data, FileName
    
End Sub

Private Sub Deselect()

    lblDelete.ForeColor = RGB(255, 255, 255)
    lblOk.ForeColor = RGB(255, 255, 255)

End Sub

Private Sub Form_Load()

    Draw Me, 0, RGB(0, 0, 0), RGB(1, 100, 248)
    lblVirtualmode.Caption = "IQT 1.2" + Chr(13) + Chr(10) + "Группа разработчиков программного обеспечения" + Chr(13) + Chr(10) + "Острог, 2005 - 2006 :)"
    If (Trim(ReadINI("Init", "i", App.Path + "\" + frmTCR.flTest.FileName)) = "1") Then
        txtTopic.Text = Trim(ReadINI("Intro", "t", App.Path + "\" + frmTCR.flTest.FileName))
        txtText.Text = Trim(ReadINI("Intro", "i", App.Path + "\" + frmTCR.flTest.FileName))
    End If

End Sub

Private Sub Form_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    Deselect

End Sub

Private Sub Label2_Click()

End Sub

Private Sub lblDelete_Click()

    If (MsgBox("Вы уверены, что хотите удалить доп.информацию" + Chr$(10) + "из теста?", vbYesNo, "Запрос на удаление") = vbYes) Then
        WriteINI "Init", "i", "0", App.Path + "\" + frmTCR.flTest.FileName
        WriteINI "Intro", "t", "0", App.Path + "\" + frmTCR.flTest.FileName
        WriteINI "Intro", "i", "0", App.Path + "\" + frmTCR.flTest.FileName
        txtTopic.Text = ""
        txtText.Text = ""
    End If

End Sub

Private Sub lblDelete_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    Deselect
    lblDelete.ForeColor = RGB(142, 187, 255)

End Sub

Private Sub lblOk_Click()

    Unload Me

End Sub

Private Sub lblOk_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    Deselect
    lblOk.ForeColor = RGB(142, 187, 255)

End Sub

Private Sub txtText_Change()

    WriteINI "Init", "i", "1", App.Path + "\" + frmTCR.flTest.FileName
    WriteINI "Intro", "i", txtText.Text, App.Path + "\" + frmTCR.flTest.FileName

End Sub

Private Sub txtTopic_Change()

    WriteINI "Init", "i", "1", App.Path + "\" + frmTCR.flTest.FileName
    WriteINI "Intro", "t", txtTopic.Text, App.Path + "\" + frmTCR.flTest.FileName

End Sub
