VERSION 5.00
Begin VB.Form Label1 
   BackColor       =   &H00000000&
   BorderStyle     =   0  'None
   Caption         =   "IQT $1.0"
   ClientHeight    =   15360
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   19200
   BeginProperty Font 
      Name            =   "Arial"
      Size            =   8.25
      Charset         =   204
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   Icon            =   "frmIQT.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   15360
   ScaleWidth      =   19200
   StartUpPosition =   2  'CenterScreen
   Begin VB.TextBox txtYA 
      Appearance      =   0  'Flat
      BackColor       =   &H00FFFFFF&
      BorderStyle     =   0  'None
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   15.75
         Charset         =   204
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   405
      Left            =   4920
      TabIndex        =   26
      Top             =   3480
      Visible         =   0   'False
      Width           =   9615
   End
   Begin VB.Timer tmrTime 
      Enabled         =   0   'False
      Interval        =   1000
      Left            =   120
      Top             =   120
   End
   Begin VB.FileListBox flTest 
      Appearance      =   0  'Flat
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   15.75
         Charset         =   204
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   5070
      Left            =   4800
      Pattern         =   "*.iqt"
      TabIndex        =   6
      Top             =   5760
      Width           =   9855
   End
   Begin VB.TextBox txtName 
      Appearance      =   0  'Flat
      BackColor       =   &H00FFFFFF&
      BorderStyle     =   0  'None
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   15.75
         Charset         =   204
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   405
      Left            =   4920
      TabIndex        =   5
      Top             =   4605
      Width           =   9615
   End
   Begin VB.Label lblM 
      Alignment       =   2  'Center
      BackColor       =   &H00000000&
      BackStyle       =   0  'Transparent
      Caption         =   "IQT 1.02"
      ForeColor       =   &H00FFBB8E&
      Height          =   975
      Left            =   5160
      TabIndex        =   28
      Top             =   14160
      Width           =   4575
   End
   Begin VB.Label lblYA 
      BackStyle       =   0  'Transparent
      Caption         =   "Ваш ответ:"
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
      Left            =   4800
      TabIndex        =   27
      Top             =   2760
      Visible         =   0   'False
      Width           =   2175
   End
   Begin VB.Shape shpYA 
      BackStyle       =   1  'Opaque
      BorderColor     =   &H00000000&
      Height          =   465
      Left            =   4800
      Top             =   3360
      Visible         =   0   'False
      Width           =   9855
   End
   Begin VB.Image imgQuest 
      Height          =   450
      Left            =   120
      Picture         =   "frmIQT.frx":558A
      Top             =   480
      Width           =   450
   End
   Begin VB.Label lblInfo 
      Alignment       =   2  'Center
      BackStyle       =   0  'Transparent
      Caption         =   "(История 10 класс)"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   12
         Charset         =   204
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFBB8E&
      Height          =   375
      Left            =   1320
      TabIndex        =   25
      Top             =   2760
      Visible         =   0   'False
      Width           =   18015
   End
   Begin VB.Label lblQN 
      Alignment       =   2  'Center
      BackStyle       =   0  'Transparent
      Caption         =   "Вопрос 0 из 0"
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
      Left            =   8040
      TabIndex        =   23
      Top             =   12840
      Visible         =   0   'False
      Width           =   3135
   End
   Begin VB.Label lblSD 
      BackStyle       =   0  'Transparent
      Height          =   495
      Left            =   12060
      TabIndex        =   22
      Top             =   10560
      Visible         =   0   'False
      Width           =   495
   End
   Begin VB.Label lblSB 
      BackStyle       =   0  'Transparent
      Height          =   495
      Left            =   12060
      TabIndex        =   21
      Top             =   9120
      Visible         =   0   'False
      Width           =   495
   End
   Begin VB.Label lblSC 
      BackStyle       =   0  'Transparent
      Height          =   495
      Left            =   4800
      TabIndex        =   20
      Top             =   10560
      Visible         =   0   'False
      Width           =   495
   End
   Begin VB.Label lblSA 
      BackStyle       =   0  'Transparent
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   4800
      TabIndex        =   19
      Top             =   9120
      Visible         =   0   'False
      Width           =   495
   End
   Begin VB.Label lblB 
      BackStyle       =   0  'Transparent
      Caption         =   "Variant"
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
      Left            =   12675
      TabIndex        =   18
      Top             =   9165
      Visible         =   0   'False
      Width           =   10000
   End
   Begin VB.Label lblD 
      BackStyle       =   0  'Transparent
      Caption         =   "Variant"
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
      Left            =   12675
      TabIndex        =   17
      Top             =   10605
      Visible         =   0   'False
      Width           =   10000
   End
   Begin VB.Label lblC 
      BackStyle       =   0  'Transparent
      Caption         =   "Variant"
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
      Left            =   5400
      TabIndex        =   16
      Top             =   10605
      Visible         =   0   'False
      Width           =   10000
   End
   Begin VB.Label lblA 
      BackStyle       =   0  'Transparent
      Caption         =   "Variant"
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
      Left            =   5400
      TabIndex        =   15
      Top             =   9165
      Visible         =   0   'False
      Width           =   10000
   End
   Begin VB.Shape shpD 
      FillColor       =   &H00FFFFFF&
      Height          =   495
      Left            =   12060
      Top             =   10560
      Visible         =   0   'False
      Width           =   495
   End
   Begin VB.Shape shpB 
      FillColor       =   &H00FFFFFF&
      Height          =   495
      Left            =   12060
      Top             =   9120
      Visible         =   0   'False
      Width           =   495
   End
   Begin VB.Shape shpA 
      FillColor       =   &H00FFFFFF&
      Height          =   495
      Left            =   4800
      Top             =   9120
      Visible         =   0   'False
      Width           =   495
   End
   Begin VB.Shape shpC 
      FillColor       =   &H00FFFFFF&
      Height          =   495
      Left            =   4800
      Top             =   10560
      Visible         =   0   'False
      Width           =   495
   End
   Begin VB.Label lblCont 
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
      Left            =   13680
      TabIndex        =   14
      Top             =   12720
      Visible         =   0   'False
      Width           =   975
   End
   Begin VB.Label lblTime 
      Alignment       =   2  'Center
      BackStyle       =   0  'Transparent
      Caption         =   "30:00"
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
      Left            =   8880
      TabIndex        =   12
      Top             =   12360
      Visible         =   0   'False
      Width           =   1335
   End
   Begin VB.Label lblBack 
      BackStyle       =   0  'Transparent
      Caption         =   "< Назад"
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
      Left            =   12000
      TabIndex        =   10
      Top             =   12360
      Visible         =   0   'False
      Width           =   1215
   End
   Begin VB.Label lblState 
      Alignment       =   2  'Center
      BackStyle       =   0  'Transparent
      Caption         =   "Ввод данных"
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
      Left            =   600
      TabIndex        =   9
      Top             =   2160
      Width           =   17775
   End
   Begin VB.Label lblInstr 
      BackStyle       =   0  'Transparent
      Caption         =   "Инструкция"
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
      Left            =   4800
      TabIndex        =   8
      Top             =   12360
      Width           =   1815
   End
   Begin VB.Label lblStart 
      BackStyle       =   0  'Transparent
      Caption         =   "Запуск"
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
      Left            =   13680
      TabIndex        =   7
      Top             =   12360
      Width           =   975
   End
   Begin VB.Image Image2 
      Height          =   315
      Left            =   17640
      Picture         =   "frmIQT.frx":6094
      Top             =   480
      Width           =   315
   End
   Begin VB.Image Image1 
      Height          =   315
      Left            =   18000
      Picture         =   "frmIQT.frx":6616
      Top             =   480
      Width           =   315
   End
   Begin VB.Image lblExit 
      Height          =   315
      Left            =   18360
      Picture         =   "frmIQT.frx":6B98
      Top             =   480
      Width           =   315
   End
   Begin VB.Shape shpName 
      BackStyle       =   1  'Opaque
      BorderColor     =   &H00000000&
      Height          =   465
      Left            =   4800
      Top             =   4560
      Width           =   9855
   End
   Begin VB.Label lblTest 
      BackStyle       =   0  'Transparent
      Caption         =   "Выберите тест:"
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
      Left            =   4800
      TabIndex        =   4
      Top             =   5280
      Width           =   3015
   End
   Begin VB.Label lblName 
      BackStyle       =   0  'Transparent
      Caption         =   "Введите свое имя:"
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
      Left            =   4800
      TabIndex        =   3
      Top             =   4080
      Width           =   3615
   End
   Begin VB.Label lblPN 
      BackStyle       =   0  'Transparent
      Caption         =   "IQ Tест 1.2"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   24
         Charset         =   204
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   735
      Left            =   480
      TabIndex        =   2
      Top             =   360
      Width           =   6975
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
      Left            =   17640
      TabIndex        =   1
      Top             =   14280
      Width           =   1215
   End
   Begin VB.Label lblVirtualmode 
      BackColor       =   &H00000000&
      BackStyle       =   0  'Transparent
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
      Left            =   480
      TabIndex        =   0
      ToolTipText     =   "virtualmode"
      Top             =   14280
      Width           =   975
   End
   Begin VB.Label lblForward 
      BackStyle       =   0  'Transparent
      Caption         =   "Далее >"
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
      Left            =   13440
      TabIndex        =   11
      Top             =   12360
      Visible         =   0   'False
      Width           =   1215
   End
   Begin VB.Label lblCheck 
      BackStyle       =   0  'Transparent
      Caption         =   "Проверить тест"
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
      Left            =   4800
      TabIndex        =   24
      Top             =   12360
      Visible         =   0   'False
      Width           =   2415
   End
   Begin VB.Label lblQuestion 
      BackStyle       =   0  'Transparent
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   12
         Charset         =   204
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   7575
      Left            =   1440
      TabIndex        =   13
      Top             =   3600
      Visible         =   0   'False
      Width           =   16215
      WordWrap        =   -1  'True
   End
End
Attribute VB_Name = "Label1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private a(100) As String
Private m, s As Integer
Private tio As Boolean
Private mark As Integer
Private pnt As Integer
Private aq As Integer
Private qq As Integer
Private bkdoor As Boolean
Private FSize As Integer

Private Sub InitA()

    Dim i As Integer
    For i = 1 To 100
        a(i) = "0000"
    Next i

End Sub

Private Sub Initialize()

    lblM.Caption = "IQT 1.2" + Chr(13) + Chr(10) + "Группа разработчиков программного обеспечения" + Chr(13) + Chr(10) + "Острог, 2005 - 2006."

    flTest.Path = App.Path

    lblVirtualmode.ToolTipText = "Группа разработчиков программного обеспечения 'Острог', 2005 - 2006."

    Me.Left = 0
    Me.Width = Screen.Width
    Me.Top = 0
    Me.Height = Screen.Height
    
    Draw Me, 0, RGB(0, 0, 0), RGB(1, 100, 248)

    'font size
    bkdoor = False
    FSize = 0
    If ((Screen.Width / Screen.TwipsPerPixelX) < 1279) Then
        If ((Screen.Width / Screen.TwipsPerPixelX) < 801) Then
            FSize = 4
        Else
            FSize = 1
        End If
    End If
    lblQuestion.FontSize = lblQuestion.FontSize - FSize
    lblPN.FontSize = lblPN.FontSize - FSize
    lblState.FontSize = lblState.FontSize - FSize
    lblInfo.FontSize = lblInfo.FontSize - FSize
    'lblName.FontSize = lblName.FontSize - FSize
    'lblTest.FontSize = lblTest.FontSize - FSize
    lblVirtualmode.FontSize = lblVirtualmode.FontSize - FSize
    lblYear.FontSize = lblYear.FontSize - FSize
    lblA.FontSize = lblA.FontSize - FSize
    lblB.FontSize = lblB.FontSize - FSize
    lblC.FontSize = lblC.FontSize - FSize
    lblD.FontSize = lblD.FontSize - FSize
    lblCheck.FontSize = lblCheck.FontSize - FSize
    lblInstr.FontSize = lblInstr.FontSize - FSize
    lblTime.FontSize = lblTime.FontSize - FSize
    lblQN.FontSize = lblQN.FontSize - FSize
    lblBack.FontSize = lblBack.FontSize - FSize
    lblForward.FontSize = lblForward.FontSize - FSize
    lblCont.FontSize = lblCont.FontSize - FSize
    lblStart.FontSize = lblStart.FontSize - FSize
    
    'other
    lblQuestion.Width = Screen.Width - 2880
    txtName.Width = Screen.Width - 2880
    shpName.Width = txtName.Width + 60
    flTest.Width = shpName.Width
    flTest.Height = Screen.Height / 3
    shpYA.Width = flTest.Width
    txtYA.Width = shpYA.Width - 100
    lblM.Top = Screen.Height - lblM.Height - 150
    lblM.Left = (Screen.Width / 2) - (lblM.Width / 2)
    
    'Horizontal
    imgQuest.Left = 480
    lblPN.Left = 480 + 170 + imgQuest.Width
    lblPN.Top = 400
    lblVirtualmode.Left = 480
    lblVirtualmode.Top = Screen.Height - 380 - lblVirtualmode.Height
    lblYear.Left = Screen.Width - lblYear.Width - 480
    lblYear.Top = Screen.Height - 380 - lblYear.Height
    lblExit.Left = Screen.Width - 840
    Image1.Left = Screen.Width - 840 - 360
    Image2.Left = Screen.Width - 840 - 720
    lblState.Left = Screen.Width / 2 - lblState.Width / 2
    txtName.Left = 50 + Screen.Width / 2 - txtName.Width / 2
    lblName.Left = txtName.Left - 50
    shpName.Left = lblName.Left
    lblTest.Left = lblName.Left
    flTest.Left = lblName.Left
    shpYA.Left = flTest.Left
    lblYA.Left = shpYA.Left
    txtYA.Left = shpYA.Left + 50
    lblQuestion.Left = Screen.Width / 2 - lblQuestion.Width / 2
    lblCheck.Left = lblName.Left
    lblInstr.Left = lblName.Left
    lblTime.Left = Screen.Width / 2 - lblTime.Width / 2
    lblQN.Left = Screen.Width / 2 - lblQN.Width / 2
    lblStart.Left = flTest.Left + flTest.Width - lblStart.Width
    lblCont.Left = flTest.Left + flTest.Width - lblCont.Width
    lblForward.Left = flTest.Left + flTest.Width - lblForward.Width
    lblBack.Left = lblForward.Left - 1440
    lblSA.Left = lblName.Left
    lblSC.Left = lblName.Left
    shpA.Left = lblName.Left
    shpC.Left = lblName.Left
    lblA.Left = lblSA.Left + lblSA.Width + 130
    lblC.Left = lblA.Left
    shpB.Left = Screen.Width / 2 + 1440
    shpD.Left = shpB.Left
    lblSB.Left = shpB.Left
    lblSD.Left = shpD.Left
    lblB.Left = lblSB.Left + lblSB.Width + 130
    lblD.Left = lblB.Left
    lblInfo.Left = Screen.Width / 2 - lblInfo.Width / 2
        
    'Vertical
    lblName.Top = Screen.Height / 2 - (flTest.Top + flTest.Height - lblName.Top) / 2.5
    txtName.Top = lblName.Top + lblName.Height + 45
    shpName.Top = txtName.Top - 45
    lblState.Top = lblPN.Top + lblPN.Height + (lblName.Top - lblPN.Top - lblPN.Height) / 2 - 300
    lblTest.Top = shpName.Top + shpName.Height + 150
    flTest.Top = lblTest.Top + lblTest.Height
    lblStart.Top = flTest.Top + flTest.Height + 45
    lblCont.Top = lblStart.Top
    lblForward.Top = lblStart.Top
    lblBack.Top = lblStart.Top
    lblInstr.Top = lblStart.Top
    lblCheck.Top = lblStart.Top
    lblTime.Top = lblStart.Top
    lblQN.Top = lblStart.Top + lblStart.Height
    lblQuestion.Top = lblState.Top + lblState.Height + 700
    lblInfo.Top = lblState.Top + lblState.Height
    shpC.Top = lblCheck.Top - shpC.Height - 650
    lblSC.Top = shpC.Top
    lblC.Top = shpC.Top + 50
    shpD.Top = shpC.Top
    lblSD.Top = shpD.Top
    lblD.Top = lblC.Top
    shpA.Top = shpC.Top - shpA.Height - 850
    lblSA.Top = shpA.Top
    lblA.Top = shpA.Top + 50
    shpB.Top = shpA.Top
    lblSB.Top = shpA.Top
    lblB.Top = lblA.Top
    lblYA.Top = shpA.Top + 450
    shpYA.Top = lblYA.Top + lblYA.Height
    txtYA.Top = shpYA.Top + 40
    
End Sub

Private Sub Calculate()

    Dim res As Boolean
    Dim i As Integer
    Dim j As Integer
    For i = 1 To aq
        If Not (Mid(Trim(ReadINI("q" + Trim(Str(i)), "a", App.Path + "\" + flTest.FileName)), 1, 1) = "$") Then
            res = True
            For j = 1 To 4
                If Not (Mid(a(i), j, 1) = Mid(ReadINI("q" + Trim(Str(i)), "a", App.Path + "\" + flTest.FileName), j, 1)) Then
                    res = False
                End If
            Next j
            If (res = True) Then
                mark = mark + 1
                pnt = pnt + Val(ReadINI("q" + Trim(Str(i)), "b", App.Path + "\" + flTest.FileName))
            End If
        Else
            If (Mid(Trim(ReadINI("q" + Trim(Str(i)), "a", App.Path + "\" + flTest.FileName)), 2) = a(i)) Then
                mark = mark + 1
                pnt = pnt + Val(ReadINI("q" + Trim(Str(i)), "b", App.Path + "\" + flTest.FileName))
            End If
        End If
    Next i

End Sub

Private Sub WriteA(answer As Integer, n As Integer, what As Integer)

    Dim ss As String
    If (n = 1) Then
        ss = Trim(Str(what)) + Mid(a(answer), 2, 3)
    Else
        If (n = 4) Then
            ss = Mid(a(answer), 1, 3) + Trim(Str(what))
        Else
            ss = Mid(a(answer), 1, n - 1) + Trim(Str(what)) + Mid(a(answer), n + 1, 4 - n)
        End If
    End If
    a(answer) = ss

End Sub

Private Sub UpdateBF()

    If (qq = aq) Then
        lblForward.ForeColor = RGB(100, 100, 100)
        lblForward.Enabled = False
    Else
        lblForward.ForeColor = RGB(255, 255, 255)
        lblForward.Enabled = True
    End If
    If (qq = 1) Then
        lblBack.ForeColor = RGB(100, 100, 100)
        lblBack.Enabled = False
    Else
        lblBack.ForeColor = RGB(255, 255, 255)
        lblBack.Enabled = True
    End If

End Sub

Private Sub ShowQuestion(n As Integer)

    lblQuestion.FontSize = 16 - FSize
    lblQuestion.Caption = ReadINI("q" + Trim(Str(n)), "q", App.Path + "\" + flTest.FileName)
    If (Mid(Trim(ReadINI("q" + Trim(Str(n)), "a", App.Path + "\" + flTest.FileName)), 1, 1) = "$") Then
        HideW03
        ShowW04
        lblQN = "(B) Вопрос" + Str(n) + " из" + Str(aq)
        If Not (a(n) = "0000") Then
            txtYA.Text = a(n)
        Else
            txtYA.Text = ""
        End If
    Else
        lblQN = "(A) Вопрос" + Str(n) + " из" + Str(aq)
        lblA.Caption = ReadINI("q" + Trim(Str(n)), "a1", App.Path + "\" + flTest.FileName)
        lblB.Caption = ReadINI("q" + Trim(Str(n)), "a2", App.Path + "\" + flTest.FileName)
        lblC.Caption = ReadINI("q" + Trim(Str(n)), "a3", App.Path + "\" + flTest.FileName)
        lblD.Caption = ReadINI("q" + Trim(Str(n)), "a4", App.Path + "\" + flTest.FileName)
        If (Mid(a(n), 1, 1) = "1") Then
            shpA.FillStyle = 0
        Else
            shpA.FillStyle = 1
        End If
     
        If (Mid(a(n), 2, 1) = "1") Then
            shpB.FillStyle = 0
        Else
            shpB.FillStyle = 1
        End If
    
        If (Mid(a(n), 3, 1) = "1") Then
            shpC.FillStyle = 0
        Else
            shpC.FillStyle = 1
        End If
    
        If (Mid(a(n), 4, 1) = "1") Then
            shpD.FillStyle = 0
        Else
            shpD.FillStyle = 1
        End If
        ShowW03
        HideW04
    End If
    
End Sub

Private Sub ShowResult()

    Dim i As Integer
    Dim j As Integer
    Dim ba As Integer
    Dim mk As Integer
    ba = 0
    i = ReadINI("Init", "q", App.Path + "\" + flTest.FileName)
    For j = 1 To i
        ba = ba + Val(ReadINI("q" + Trim(Str(j)), "b", App.Path + "\" + flTest.FileName))
    Next j
    mk = Round((pnt * 5) / ba)
    If (mk = 0 Or mk = 1) Then mk = 2
    HideW03
    HideW04
    lblState.Caption = "Результат"
    lblQuestion.Caption = txtName + ", вы ответили правильно на" + Str(mark) + " вопрос(а,ов) из" + Str(i) + "." + Chr$(10)
    lblQuestion.Caption = lblQuestion.Caption + "Общее количество баллов" + Str(pnt) + " (из " + Trim(Str(ba)) + ")." + Chr$(10)
    lblQuestion.Caption = lblQuestion.Caption + "Затраченное время" + Str(Val(ReadINI("Init", "t", App.Path + "\" + flTest.FileName)) - m) + " минут(а,ы)" + Chr$(10) + Chr$(10)
    lblQuestion.Caption = lblQuestion.Caption + "Ваша оценка" + Str(mk) + "."

End Sub

Private Sub bSelect(n As Integer)

    bDeselect
    Select Case n
    Case Is = 1
        lblStart.ForeColor = RGB(142, 187, 255)
    Case Is = 2
        lblInstr.ForeColor = RGB(142, 187, 255)
    Case Is = 3
        lblForward.ForeColor = RGB(142, 187, 255)
    Case Is = 4
        lblBack.ForeColor = RGB(142, 187, 255)
    Case Is = 5
        lblCont.ForeColor = RGB(142, 187, 255)
    Case Is = 6
        lblA.ForeColor = RGB(142, 187, 255)
    Case Is = 7
        lblB.ForeColor = RGB(142, 187, 255)
    Case Is = 8
        lblC.ForeColor = RGB(142, 187, 255)
    Case Is = 9
        lblD.ForeColor = RGB(142, 187, 255)
    Case Is = 10
        lblCheck.ForeColor = RGB(142, 187, 255)
    End Select
    
End Sub

Private Sub bDeselect()

    lblStart.ForeColor = RGB(255, 255, 255)
    lblInstr.ForeColor = RGB(255, 255, 255)
    lblForward.ForeColor = RGB(255, 255, 255)
    lblBack.ForeColor = RGB(255, 255, 255)
    lblCont.ForeColor = RGB(255, 255, 255)
    lblA.ForeColor = RGB(255, 255, 255)
    lblB.ForeColor = RGB(255, 255, 255)
    lblC.ForeColor = RGB(255, 255, 255)
    lblD.ForeColor = RGB(255, 255, 255)
    lblCheck.ForeColor = RGB(255, 255, 255)

End Sub

Private Sub HideW01()
    
    flTest.Visible = False
    lblTest.Visible = False
    txtName.Visible = False
    shpName.Visible = False
    lblName.Visible = False
    
End Sub

Private Sub ShowW01()
    
    flTest.Visible = True
    lblTest.Visible = True
    txtName.Visible = True
    shpName.Visible = True
    lblName.Visible = True
    
End Sub

Private Sub HideW02()

    lblQuestion.Visible = False

End Sub

Private Sub ShowW02()

    lblQuestion.Visible = True
    lblQuestion.Caption = "У вас есть n минут, чтобы ответить на все вопросы, поэтому работайте как можно быстрее. Не засиживайтесь слишком долго над каким-нибудь вопросом -возможно вы выбрали неверный метод решения, а следующую задачу вы сделаете лучше. С другой стороны, не сдавайтесь слишком легко - большинство задач можно решить, имея немного терпения. Полагайтесь лишь на свой здравый смысл, чтобы решить, когда отказаться от нерешенной задачи. И помните, что в целом сложность задач возрастает к концу теста. Все задачи имеют решение."
    lblQuestion.Caption = lblQuestion.Caption + Chr$(10) + "Если вы не можете ответить на вопрос, не стройте догадок и пропустите его (в этом случае после n задач вам снова будут предложены те из них, которые остались без ответа, чтобы в оставшееся время вы могли снова попытаться решить их) Однако, если у вас есть идея, но вы не уверены полностью, что это действительно правильный ответ, все равно лучше укажите ее. В тестах нет 'хитрых' вопросов, но вам всегда придется рассматривать множество путей подхода к решению задачи. Убедитесь, что вы понимаете, что от вас требуется, прежде чем приступать к решению задачи - вы зря потратите время, если сразу перейдете к решению, не попробовав выяснить, в чем заключается задача."
    lblQuestion.Caption = lblQuestion.Caption + Chr$(10) + "Количество минут, оставшихся до конца тестирования, высвечивается на таймере в нижней части экрана (таймер запускается нажатием кнопки 'Запуск' на следующей странице). Ответ, введенный после истечения отведенного времени, засчитан не будет."
    lblQuestion.Caption = lblQuestion.Caption + Chr$(10) + "Вы можете прекратить тест, нажав кнопку 'Проверить тест' в левом нижнем углу ( кнопка активна после запуска таймера). В этом случае результаты тестирования все равно выводятся на экран."

End Sub

Private Sub ShowW03()

    shpA.Visible = True
    shpB.Visible = True
    shpC.Visible = True
    shpD.Visible = True
    lblA.Visible = True
    lblB.Visible = True
    lblC.Visible = True
    lblD.Visible = True
    lblSA.Visible = True
    lblSB.Visible = True
    lblSC.Visible = True
    lblSD.Visible = True
    
End Sub

Private Sub HideW03()

    shpA.Visible = False
    shpB.Visible = False
    shpC.Visible = False
    shpD.Visible = False
    lblA.Visible = False
    lblB.Visible = False
    lblC.Visible = False
    lblD.Visible = False
    lblSA.Visible = False
    lblSB.Visible = False
    lblSC.Visible = False
    lblSD.Visible = False
    
End Sub

Private Sub ShowW04()

    shpYA.Visible = True
    txtYA.Visible = True
    lblYA.Visible = True

End Sub

Private Sub HideW04()

    shpYA.Visible = False
    txtYA.Visible = False
    lblYA.Visible = False

End Sub

Private Sub Form_Load()
    
    Initialize
        
End Sub

Private Sub Form_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    bDeselect
    
End Sub

Private Sub Image2_Click()
    
    Me.WindowState = 1
    
End Sub

Private Sub imgQuest_Click()

    If (lblStart.Visible = True) Then
        If (bkdoor = True) Then
            bkdoor = False
        Else
            bkdoor = True
        End If
    Else
        bkdoor = False
    End If

End Sub

Private Sub lblA_Click()

    If (shpA.FillStyle = 0) Then
        shpA.FillStyle = 1
        WriteA qq, 1, 0
    Else
        shpA.FillStyle = 0
        WriteA qq, 1, 1
    End If

End Sub

Private Sub lblA_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    bSelect 6

End Sub

Private Sub lblB_Click()

    If (shpB.FillStyle = 0) Then
        shpB.FillStyle = 1
        WriteA qq, 2, 0
    Else
        shpB.FillStyle = 0
        WriteA qq, 2, 1
    End If

End Sub

Private Sub lblB_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    bSelect 7

End Sub

Private Sub lblBack_Click()

    qq = qq - 1
    UpdateBF
    ShowQuestion qq

End Sub

Private Sub lblBack_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    bSelect 4

End Sub

Private Sub lblC_Click()

    If (shpC.FillStyle = 0) Then
        shpC.FillStyle = 1
        WriteA qq, 3, 0
    Else
        shpC.FillStyle = 0
        WriteA qq, 3, 1
    End If

End Sub

Private Sub lblC_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    bSelect 8

End Sub

Private Sub lblCheck_Click()

    tmrTime.Enabled = False
    If (MsgBox("Вы уверены, что хотите" + Chr$(10) + "проверить работу?", vbYesNo, "Проверка работы") = vbYes) Then
        Calculate
        tmrTime.Enabled = False
        ShowResult
        lblTime.Visible = False
        lblBack.Visible = False
        lblForward.Visible = False
        lblCheck.Visible = False
        lblQN.Visible = False
        lblInstr.Visible = True
        lblInstr.Caption = "Назад"
    Else
        tmrTime.Enabled = True
    End If

End Sub

Private Sub lblCheck_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    bSelect 10

End Sub

Private Sub lblCont_Click()

    lblState = "Тестирование"
    lblForward.Visible = True
    lblBack.Visible = True
    lblTime.Visible = True
    lblCont.Visible = False
    lblQuestion.Caption = ""
    ShowW03
    ShowQuestion 1
    tmrTime.Enabled = True
    lblQN.Visible = True
    UpdateBF
    lblCheck.Visible = True
    lblInstr.Visible = False

End Sub

Private Sub lblCont_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    bSelect 5

End Sub

Private Sub lblD_Click()

    If (shpD.FillStyle = 0) Then
        shpD.FillStyle = 1
        WriteA qq, 4, 0
    Else
        shpD.FillStyle = 0
        WriteA qq, 4, 1
    End If

End Sub

Private Sub lblD_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    bSelect 9

End Sub

Private Sub lblExit_Click()

    tmrTime.Enabled = False
    If (lblA.Visible = True) Then
        If (MsgBox("Вы уверены, что хотите" + Chr$(10) + "закончить тест?", vbYesNo, "Завершение работы") = vbYes) Then
            Unload Me
        Else
            tmrTime.Enabled = True
        End If
    Else
        Unload Me
    End If
    
End Sub

Private Sub lblForward_Click()

    qq = qq + 1
    UpdateBF
    ShowQuestion qq

End Sub

Private Sub lblForward_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    bSelect 3

End Sub

Private Sub lblInstr_Click()

    If (lblInstr.Caption = "Инструкция") Then
        HideW01
        ShowW02
        lblState.Caption = "Инструкция"
        lblStart.Visible = False
        lblInstr.Caption = "Назад"
    Else
        HideW02
        ShowW01
        lblQuestion.FontSize = 12 - FSize
        lblQuestion.Visible = False
        lblCont.Visible = False
        lblInfo.Visible = False
        lblState.Caption = "Ввод данных"
        lblStart.Visible = True
        lblInstr.Caption = "Инструкция"
    End If

End Sub

Private Sub lblInstr_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    bSelect 2

End Sub

Private Sub lblVirtualmode_DblClick()

    Dim command As String
    Dim i As Integer
    Dim j As Integer
    Dim ba As Integer
    If ((bkdoor = True) And (lblInstr.Visible = False) And (lblQuestion.Visible = True)) Then
        If (InputBox("Введите ключ для активизации скрытых программных функций:", "Введите ключ") = "12369000") Then
            command = InputBox("Функции активизированы. Введите команду:", "Коммандный процессор")
            ba = 0
            i = ReadINI("Init", "q", App.Path + "\" + flTest.FileName)
            For j = 1 To i
                ba = ba + Val(ReadINI("q" + Trim(Str(j)), "b", App.Path + "\" + flTest.FileName))
            Next j
            pnt = Round((Val(command) * ba) / 100)
            mark = Round((Val(ReadINI("Init", "q", App.Path + "\" + flTest.FileName)) * Val(command)) / 100)
        End If
    End If
    
End Sub

Private Sub lblSA_Click()
    
    If (shpA.FillStyle = 0) Then
        shpA.FillStyle = 1
        WriteA qq, 1, 0
    Else
        shpA.FillStyle = 0
        WriteA qq, 1, 1
    End If
    
End Sub

Private Sub lblSB_Click()

    If (shpB.FillStyle = 0) Then
        shpB.FillStyle = 1
        WriteA qq, 2, 0
    Else
        shpB.FillStyle = 0
        WriteA qq, 2, 1
    End If

End Sub

Private Sub lblSC_Click()

    If (shpC.FillStyle = 0) Then
        shpC.FillStyle = 1
        WriteA qq, 3, 0
    Else
        shpC.FillStyle = 0
        WriteA qq, 3, 1
    End If

End Sub

Private Sub lblSD_Click()

    If (shpD.FillStyle = 0) Then
        shpD.FillStyle = 1
        WriteA qq, 4, 0
    Else
        shpD.FillStyle = 0
        WriteA qq, 4, 1
    End If

End Sub

Private Sub UpdateTime()

    Dim st As String
    If (Len(Str(m)) = 2) Then
        st = "0" + Trim(Str(m))
    Else
        st = Trim(Str(m))
    End If
    st = st + ":"
    If (Len(Str(s)) = 2) Then
        st = st + "0" + Trim(Str(s))
    Else
        st = st + Trim(Str(s))
    End If
    lblTime.Caption = st

End Sub

Private Sub DecreaseTime()

    If (s = 0) Then
        s = 59
        If (m = 0) Then
            tio = True
        Else
            m = m - 1
        End If
    Else
        s = s - 1
    End If

End Sub

Private Sub lblStart_Click()

    If (Trim(txtName.Text) = "") Then
        MsgBox "Введите свое имя!", vbInformation, "Имя не введено"
    Else
        If (Trim(flTest.FileName) = "") Then
            MsgBox "Выберите тест!", vbInformation, "Тест не выбран"
        Else
            If (Trim(ReadINI("Init", "q", App.Path + "\" + flTest.FileName)) = "0") Then
                MsgBox "Данный тест не имеет вопросов и не может быть запущен!", vbInformation, "Ошибка"
            Else
                HideW01
                HideW02
                lblInfo.Caption = flTest.FileName
                lblInfo.Visible = True
                lblStart.Visible = False
                lblInstr.Visible = False
                lblState = "Загрузка..."
                InitA
                aq = ReadINI("Init", "q", App.Path + "\" + flTest.FileName)
                qq = 1
                s = 0
                m = Val(ReadINI("Init", "t", App.Path + "\" + flTest.FileName))
                If (ReadINI("Init", "i", App.Path + "\" + flTest.FileName) = "1") Then
                    lblState.Caption = ReadINI("Intro", "t", App.Path + "\" + flTest.FileName)
                    lblQuestion.Caption = ReadINI("Intro", "i", App.Path + "\" + flTest.FileName)
                    lblQuestion.Visible = True
                    lblCont.Visible = True
                    lblInstr.Caption = "Назад"
                    lblInstr.Visible = True
                Else
                    lblQuestion.Caption = ""
                    lblQuestion.Visible = True
                    lblState = "Тестирование"
                    lblForward.Visible = True
                    lblBack.Visible = True
                    lblTime.Visible = True
                    lblCont.Visible = False
                    lblQuestion.Caption = ""
                    ShowW03
                    ShowQuestion 1
                    lblQN.Visible = True
                    tmrTime.Enabled = True
                    UpdateBF
                    lblCheck.Visible = True
                End If
            End If
        End If
    End If
    UpdateTime
    tio = False
    mark = 0
    pnt = 0
    
End Sub

Private Sub lblStart_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)

    bSelect 1
    
End Sub

Private Sub tmrTime_Timer()

    If (tio = True) Then
        Calculate
        MsgBox "Время вышло!", vbInformation, "Работа закончена"
        tmrTime.Enabled = False
        ShowResult
        lblTime.Visible = False
        lblBack.Visible = False
        lblForward.Visible = False
        lblCheck.Visible = False
        lblQN.Visible = False
        lblInstr.Visible = True
        lblInstr.Caption = "Назад"
    End If
    UpdateTime
    DecreaseTime
    
End Sub

Private Sub txtYA_Change()

    a(qq) = txtYA.Text

End Sub
