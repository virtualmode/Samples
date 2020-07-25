'RdEye - утилита, предназначенная для удаления "эффекта красных глаз". 
'Автор: virtualmode.
'Дата начала работы над проектом: 6.09.05 г.
'
'Алгоритм удаления "эффекта красных глаз" подписан комментарием и выделен в регион
'для упрощения его поиска в коде.

Public Class frmRdEye

    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents mnuRdEye As System.Windows.Forms.MainMenu
    Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
    Friend WithEvents mnuOpen As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
    Friend WithEvents tbrRdEye As System.Windows.Forms.ToolBar
    Friend WithEvents tbrOpen As System.Windows.Forms.ToolBarButton
    Friend WithEvents ilsRdEye As System.Windows.Forms.ImageList
    Friend WithEvents mnuClose As System.Windows.Forms.MenuItem
    Friend WithEvents pctRdEye As System.Windows.Forms.PictureBox
    Friend WithEvents pctBack As System.Windows.Forms.PictureBox
    Friend WithEvents tbrOptions As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbrAuto As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbrNoAuto As System.Windows.Forms.ToolBarButton
    Friend WithEvents mnuSaveAs As System.Windows.Forms.MenuItem
    Friend WithEvents tbrSaveAs As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbrNrAuto As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbrClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents mnuTools As System.Windows.Forms.MenuItem
    Friend WithEvents mnuNoAuto As System.Windows.Forms.MenuItem
    Friend WithEvents mnuNrAuto As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAuto As System.Windows.Forms.MenuItem
    Friend WithEvents mnuOptions As System.Windows.Forms.MenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAbout As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSpr1 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSpr2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuReference As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSpr3 As System.Windows.Forms.MenuItem
    Friend WithEvents lblBack As System.Windows.Forms.Label
    Friend WithEvents tbrSpr1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbrSpr2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbrSpr3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbrReference As System.Windows.Forms.ToolBarButton
    Friend WithEvents mnuClear As System.Windows.Forms.MenuItem
    Friend WithEvents tbrClear As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmRdEye))
        Me.mnuRdEye = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuOpen = New System.Windows.Forms.MenuItem()
        Me.mnuSaveAs = New System.Windows.Forms.MenuItem()
        Me.mnuClose = New System.Windows.Forms.MenuItem()
        Me.mnuSpr1 = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuTools = New System.Windows.Forms.MenuItem()
        Me.mnuNoAuto = New System.Windows.Forms.MenuItem()
        Me.mnuNrAuto = New System.Windows.Forms.MenuItem()
        Me.mnuAuto = New System.Windows.Forms.MenuItem()
        Me.mnuClear = New System.Windows.Forms.MenuItem()
        Me.mnuSpr2 = New System.Windows.Forms.MenuItem()
        Me.mnuOptions = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuReference = New System.Windows.Forms.MenuItem()
        Me.mnuSpr3 = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.pctBack = New System.Windows.Forms.PictureBox()
        Me.tbrRdEye = New System.Windows.Forms.ToolBar()
        Me.tbrOpen = New System.Windows.Forms.ToolBarButton()
        Me.tbrSaveAs = New System.Windows.Forms.ToolBarButton()
        Me.tbrClose = New System.Windows.Forms.ToolBarButton()
        Me.tbrSpr1 = New System.Windows.Forms.ToolBarButton()
        Me.tbrOptions = New System.Windows.Forms.ToolBarButton()
        Me.tbrSpr2 = New System.Windows.Forms.ToolBarButton()
        Me.tbrNoAuto = New System.Windows.Forms.ToolBarButton()
        Me.tbrNrAuto = New System.Windows.Forms.ToolBarButton()
        Me.tbrAuto = New System.Windows.Forms.ToolBarButton()
        Me.tbrClear = New System.Windows.Forms.ToolBarButton()
        Me.tbrSpr3 = New System.Windows.Forms.ToolBarButton()
        Me.tbrReference = New System.Windows.Forms.ToolBarButton()
        Me.ilsRdEye = New System.Windows.Forms.ImageList(Me.components)
        Me.pctRdEye = New System.Windows.Forms.PictureBox()
        Me.lblBack = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'mnuRdEye
        '
        Me.mnuRdEye.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuTools, Me.mnuHelp})
        '
        'mnuFile
        '
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuOpen, Me.mnuSaveAs, Me.mnuClose, Me.mnuSpr1, Me.mnuExit})
        Me.mnuFile.Text = "Файл"
        '
        'mnuOpen
        '
        Me.mnuOpen.Index = 0
        Me.mnuOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO
        Me.mnuOpen.Text = "Открыть"
        '
        'mnuSaveAs
        '
        Me.mnuSaveAs.Enabled = False
        Me.mnuSaveAs.Index = 1
        Me.mnuSaveAs.Shortcut = System.Windows.Forms.Shortcut.CtrlS
        Me.mnuSaveAs.Text = "Сохранить как..."
        '
        'mnuClose
        '
        Me.mnuClose.Enabled = False
        Me.mnuClose.Index = 2
        Me.mnuClose.Text = "Закрыть"
        '
        'mnuSpr1
        '
        Me.mnuSpr1.Index = 3
        Me.mnuSpr1.Text = "-"
        '
        'mnuExit
        '
        Me.mnuExit.Index = 4
        Me.mnuExit.Text = "Выход"
        '
        'mnuTools
        '
        Me.mnuTools.Index = 1
        Me.mnuTools.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuNoAuto, Me.mnuNrAuto, Me.mnuAuto, Me.mnuClear, Me.mnuSpr2, Me.mnuOptions})
        Me.mnuTools.Text = "Инструменты"
        '
        'mnuNoAuto
        '
        Me.mnuNoAuto.Enabled = False
        Me.mnuNoAuto.Index = 0
        Me.mnuNoAuto.Shortcut = System.Windows.Forms.Shortcut.CtrlM
        Me.mnuNoAuto.Text = "Ручная обработка"
        '
        'mnuNrAuto
        '
        Me.mnuNrAuto.Enabled = False
        Me.mnuNrAuto.Index = 1
        Me.mnuNrAuto.Shortcut = System.Windows.Forms.Shortcut.CtrlF
        Me.mnuNrAuto.Text = "Заливка"
        '
        'mnuAuto
        '
        Me.mnuAuto.Enabled = False
        Me.mnuAuto.Index = 2
        Me.mnuAuto.Shortcut = System.Windows.Forms.Shortcut.CtrlA
        Me.mnuAuto.Text = "Автоматическая обработка изображения"
        '
        'mnuClear
        '
        Me.mnuClear.Enabled = False
        Me.mnuClear.Index = 3
        Me.mnuClear.Shortcut = System.Windows.Forms.Shortcut.CtrlC
        Me.mnuClear.Text = "Очиститка"
        '
        'mnuSpr2
        '
        Me.mnuSpr2.Index = 4
        Me.mnuSpr2.Text = "-"
        '
        'mnuOptions
        '
        Me.mnuOptions.Index = 5
        Me.mnuOptions.Text = "Настройки"
        '
        'mnuHelp
        '
        Me.mnuHelp.Index = 2
        Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuReference, Me.mnuSpr3, Me.mnuAbout})
        Me.mnuHelp.Text = "Помощь"
        '
        'mnuReference
        '
        Me.mnuReference.Index = 0
        Me.mnuReference.Shortcut = System.Windows.Forms.Shortcut.F1
        Me.mnuReference.Text = "Справка"
        '
        'mnuSpr3
        '
        Me.mnuSpr3.Index = 1
        Me.mnuSpr3.Text = "-"
        '
        'mnuAbout
        '
        Me.mnuAbout.Index = 2
        Me.mnuAbout.Text = "О RdEye..."
        '
        'pctBack
        '
        Me.pctBack.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.pctBack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pctBack.Location = New System.Drawing.Point(0, 40)
        Me.pctBack.Name = "pctBack"
        Me.pctBack.Size = New System.Drawing.Size(472, 48)
        Me.pctBack.TabIndex = 0
        Me.pctBack.TabStop = False
        '
        'tbrRdEye
        '
        Me.tbrRdEye.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbrRdEye.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbrOpen, Me.tbrSaveAs, Me.tbrClose, Me.tbrSpr1, Me.tbrOptions, Me.tbrSpr2, Me.tbrNoAuto, Me.tbrNrAuto, Me.tbrAuto, Me.tbrClear, Me.tbrSpr3, Me.tbrReference})
        Me.tbrRdEye.ButtonSize = New System.Drawing.Size(48, 48)
        Me.tbrRdEye.DropDownArrows = True
        Me.tbrRdEye.ImageList = Me.ilsRdEye
        Me.tbrRdEye.Name = "tbrRdEye"
        Me.tbrRdEye.ShowToolTips = True
        Me.tbrRdEye.Size = New System.Drawing.Size(576, 41)
        Me.tbrRdEye.TabIndex = 1
        Me.tbrRdEye.Wrappable = False
        '
        'tbrOpen
        '
        Me.tbrOpen.ImageIndex = 0
        Me.tbrOpen.ToolTipText = "Открыть файл с изображением"
        '
        'tbrSaveAs
        '
        Me.tbrSaveAs.Enabled = False
        Me.tbrSaveAs.ImageIndex = 1
        Me.tbrSaveAs.ToolTipText = "Сохранить изображение в файл"
        '
        'tbrClose
        '
        Me.tbrClose.Enabled = False
        Me.tbrClose.ImageIndex = 2
        Me.tbrClose.ToolTipText = "Закрыть файл"
        '
        'tbrSpr1
        '
        Me.tbrSpr1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbrOptions
        '
        Me.tbrOptions.ImageIndex = 3
        Me.tbrOptions.ToolTipText = "Настройки"
        '
        'tbrSpr2
        '
        Me.tbrSpr2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbrNoAuto
        '
        Me.tbrNoAuto.Enabled = False
        Me.tbrNoAuto.ImageIndex = 4
        Me.tbrNoAuto.ToolTipText = "Ручная обработка"
        '
        'tbrNrAuto
        '
        Me.tbrNrAuto.Enabled = False
        Me.tbrNrAuto.ImageIndex = 5
        Me.tbrNrAuto.ToolTipText = "Заливка"
        '
        'tbrAuto
        '
        Me.tbrAuto.Enabled = False
        Me.tbrAuto.ImageIndex = 6
        Me.tbrAuto.ToolTipText = "Автоматическая обработка изображения"
        '
        'tbrClear
        '
        Me.tbrClear.Enabled = False
        Me.tbrClear.ImageIndex = 7
        Me.tbrClear.ToolTipText = "Очиститка"
        '
        'tbrSpr3
        '
        Me.tbrSpr3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbrReference
        '
        Me.tbrReference.ImageIndex = 8
        Me.tbrReference.ToolTipText = "Справка"
        '
        'ilsRdEye
        '
        Me.ilsRdEye.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
        Me.ilsRdEye.ImageSize = New System.Drawing.Size(32, 32)
        Me.ilsRdEye.ImageStream = CType(resources.GetObject("ilsRdEye.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilsRdEye.TransparentColor = System.Drawing.Color.Transparent
        '
        'pctRdEye
        '
        Me.pctRdEye.BackColor = System.Drawing.SystemColors.Window
        Me.pctRdEye.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pctRdEye.Location = New System.Drawing.Point(8, 48)
        Me.pctRdEye.Name = "pctRdEye"
        Me.pctRdEye.Size = New System.Drawing.Size(456, 32)
        Me.pctRdEye.TabIndex = 2
        Me.pctRdEye.TabStop = False
        '
        'lblBack
        '
        Me.lblBack.BackColor = System.Drawing.SystemColors.Window
        Me.lblBack.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblBack.Location = New System.Drawing.Point(16, 56)
        Me.lblBack.Name = "lblBack"
        Me.lblBack.Size = New System.Drawing.Size(432, 16)
        Me.lblBack.TabIndex = 3
        Me.lblBack.Text = "Изображение для редактирования отсутствует."
        '
        'frmRdEye
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(576, 553)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblBack, Me.pctRdEye, Me.tbrRdEye, Me.pctBack})
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.mnuRdEye
        Me.Name = "frmRdEye"
        Me.Text = "RdEye - утилита устранения ""эффекта красных глаз"""
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Основной регион с алгоритмом устранения ""эффекта красных глаз"" "

    Dim bmpRdEye As Bitmap 'Редактируемое изображение.
    Public Shared bmpMask As Bitmap 'Маска изображения для заливки.
    Public Shared sdcEyeColor As System.Drawing.Color 'Новый цвет глаз.
    Public Shared sdcPupilColor As System.Drawing.Color 'Новый чвет зрачка.
    Public Shared bPixelShow As Boolean 'Флаг подсвечивания обработанных пикселей.
    Public Shared iFault As Integer 'Погрешность красного цвета.
    Public Shared sBrightness As Single 'Яркость красного цвета.
    Public Shared iWFault As Integer 'Погрешность белого цвета.
    Public Shared sWBrightness As Single 'Яркость белого цвета.
    'Переменные ручной кисти:
    Public Shared iNABrushSize As Integer 'Размер ручной кисти.
    Public Shared bNABrushType As Byte 'Тип ручной кисти.
    Public Shared bNAFilter As Boolean 'Флаг фильтрации цвета.
    Public Shared bNAMiter As Boolean 'Флаг сглаживания границ между белым и красным.
    Public Shared bNAMiterCnt As Byte 'Величина сглаживания.
    'Переменные инструмента заливки.
    Public Shared iNrSens As Integer 'Чувствительность заливки.
    'Переменные инструмента очистки:
    Public Shared iClearSize As Integer
    Public Shared bClearType As Byte
    'Переменные автоматической обработки.
    Public Shared iEyeSh As Integer 'Дополнительные пикселы к форме глаза.
    Public Shared iMaxEyeArea As Long 'Максимальная площадь глаза.
    Public Shared bArea As Boolean 'Флаг контроля заполняемости.
    Public Shared lArea As Long 'Погрешность заполняемости.
    Public Shared bFSens As Boolean 'Чувствительность к бликам.
    Dim lLength As Long 'Площадь найденного пятна.
    Dim iL, iR, iT, iB As Integer 'Прямоугольная область пятна.

    'Функция преобразования целых чисел в числа типа Byte путем отсекания.
    Function fnByte(ByVal n As Integer) As Byte
        If n > 255 Then
            n = 255
        Else
            If n < 0 Then
                n = 0
            End If
        End If
        fnByte = n
    End Function

    'Функция детектирования красного цвета.
    Private Function fnRed(ByVal sdc As System.Drawing.Color, ByVal iCollision As Integer, ByVal sBrightness As Single) As Boolean
        If (Int(sdc.R) + iCollision >= Int(sdc.G) + Int(sdc.B)) And (sdc.GetBrightness > sBrightness) Then
            fnRed = True
        Else
            fnRed = False
        End If
    End Function

    'Функция детектирования белого цвета.
    Private Function fnWhite(ByVal sdc As System.Drawing.Color, ByVal iCollision As Integer, ByVal sBrightness As Single) As Boolean
        If (Math.Abs(Int(sdc.R) - Int(sdc.G)) < iCollision) And (Math.Abs(Int(sdc.G) - Int(sdc.B)) < iCollision) And (sdc.GetBrightness > sBrightness) Then
            fnWhite = True
        Else
            fnWhite = False
        End If
    End Function

    'Функция преобразования цвета в выбранную цветовую схему.
    Private Function fnTransColor(ByVal sdc1 As System.Drawing.Color, ByVal sdc2 As System.Drawing.Color) As System.Drawing.Color
        Dim iMin As Integer
        iMin = Int(Math.Min(Math.Min(sdc2.R, sdc2.G), sdc2.B)) - Int(Math.Min(Math.Min(sdc1.R, sdc1.G), sdc1.B))
        If (fnWhite(sdc1, iWFault, sWBrightness) = True) And (bNAMiter = True) Then
            iMin = iMin - 100
        End If
        sdc2 = Color.FromArgb(fnByte(Int(sdc2.R) - iMin), fnByte(Int(sdc2.G) - iMin), fnByte(Int(sdc2.B) - iMin))
        fnTransColor = sdc2
    End Function

    'Процедура подсветки пикселей.
    Private Sub sLightUp(ByVal x As Integer, ByVal y As Integer)
        Dim sdc As System.Drawing.Color
        sdc = bmpOriginal.GetPixel(x, y)
        sdc = Color.FromArgb(fnByte(sdc.R + 100), fnByte(sdc.G + 100), fnByte(sdc.B + 100))
        bmpRdEye.SetPixel(x, y, sdc)
    End Sub

    'Функция определяющая подобные цвета.
    Private Function fnLike(ByVal sdc1 As System.Drawing.Color, ByVal sdc2 As System.Drawing.Color, ByVal iCollision As Integer) As Boolean
        If (Math.Abs(Int(sdc1.R) - Int(sdc2.R)) < iCollision) And (Math.Abs(Int(sdc1.G) - Int(sdc2.G)) < iCollision) And (Math.Abs(Int(sdc1.B) - Int(sdc2.B)) < iCollision) Then
            fnLike = True
        Else
            fnLike = False
        End If
    End Function

    'Процедура ручной обработки глаза.
    Private Sub UseNoAuto(ByVal x As Integer, ByVal y As Integer, ByVal mbLeft As Boolean)
        If mbLeft = True Then 'Нажата левая кнопка мыши.
            If bPixelShow = True Then
                sLightUp(x, y)
            Else
                If bNAFilter = True Then
                    If (fnRed(bmpOriginal.GetPixel(x, y), iFault, sBrightness) = True) Then
                        bmpRdEye.SetPixel(x, y, fnTransColor(bmpOriginal.GetPixel(x, y), sdcEyeColor))
                    End If
                Else
                    bmpRdEye.SetPixel(x, y, fnTransColor(bmpOriginal.GetPixel(x, y), sdcEyeColor))
                End If
            End If
        Else 'Нажата правая кнопка мыши.
            If bPixelShow = True Then
                sLightUp(x, y)
            Else
                If bNAFilter = True Then
                    If (fnRed(bmpOriginal.GetPixel(x, y), iFault, sBrightness) = False) Then
                        bmpRdEye.SetPixel(x, y, fnTransColor(bmpOriginal.GetPixel(x, y), sdcPupilColor))
                    End If
                Else
                    bmpRdEye.SetPixel(x, y, fnTransColor(bmpOriginal.GetPixel(x, y), sdcPupilColor))
                End If
            End If
        End If
    End Sub

    'Процедура заливки.
    Private Sub UseNrAuto(ByVal x As Integer, ByVal y As Integer, ByVal sdc As System.Drawing.Color, ByVal iDepth As Integer, ByVal mbLeft As Boolean)
        If (x >= 0) And (x < bmpRdEye.Width) And (y >= 0) And (y < bmpRdEye.Height) And (iDepth < 2048) Then
            If (fnRed(bmpOriginal.GetPixel(x, y), iFault, sBrightness) = True And mbLeft = True) Or (fnWhite(bmpOriginal.GetPixel(x, y), iFault, sBrightness) = True And mbLeft = False) Then
                bmpMask.SetPixel(x, y, Color.Black)
                If bPixelShow = True Then
                    sLightUp(x, y)
                Else
                    If (mbLeft = True) Then
                        bmpRdEye.SetPixel(x, y, fnTransColor(bmpOriginal.GetPixel(x, y), sdcEyeColor))
                    Else
                        bmpRdEye.SetPixel(x, y, fnTransColor(bmpOriginal.GetPixel(x, y), sdcPupilColor))
                    End If
                End If
                'Обработка волны.
                If (y - 1 >= 0) Then
                    If (fnLike(sdc, bmpRdEye.GetPixel(x, y - 1), fnByte(iNrSens)) = True) And (bmpMask.GetPixel(x, y - 1).R = 255) Then
                        UseNrAuto(x, y - 1, sdc, iDepth + 1, mbLeft)
                    End If
                End If
                If (x + 1 < bmpRdEye.Width) Then
                    If (fnLike(sdc, bmpRdEye.GetPixel(x + 1, y), fnByte(iNrSens)) = True) And (bmpMask.GetPixel(x + 1, y).R = 255) Then
                        UseNrAuto(x + 1, y, sdc, iDepth + 1, mbLeft)
                    End If
                End If
                If (y + 1 < bmpRdEye.Height) Then
                    If (fnLike(sdc, bmpRdEye.GetPixel(x, y + 1), fnByte(iNrSens)) = True) And (bmpMask.GetPixel(x, y + 1).R = 255) Then
                        UseNrAuto(x, y + 1, sdc, iDepth + 1, mbLeft)
                    End If
                End If
                If (x - 1 >= 0) Then
                    If (fnLike(sdc, bmpRdEye.GetPixel(x - 1, y), fnByte(iNrSens)) = True) And (bmpMask.GetPixel(x - 1, y).R = 255) Then
                        UseNrAuto(x - 1, y, sdc, iDepth + 1, mbLeft)
                    End If
                End If
            End If
        End If
    End Sub

    'Можно сказать та же процедура заливки, только вместо фото используется маска.
    'Это дает возможность анализа найденных путем использования волны пятен.
    Private Sub SetWave(ByVal x As Integer, ByVal y As Integer, ByVal iDepth As Integer)
        If iDepth < 2048 Then
            bmpMask.SetPixel(x, y, Color.Black)
            'bmpRdEye.SetPixel(x, y, Color.LightGreen)
            lLength = lLength + 1
            If x < iL Then
                iL = x
            End If
            If x > iR Then
                iR = x
            End If
            If y < iT Then
                iT = y
            End If
            If y > iB Then
                iB = y
            End If
            'Обработка волны.
            If (y - 1 >= 0) Then
                If (fnRed(bmpOriginal.GetPixel(x, y - 1), iFault, sBrightness) = True) And (bmpMask.GetPixel(x, y - 1).R = 255) Then
                    SetWave(x, y - 1, iDepth + 1)
                End If
            End If
            If (x + 1 < bmpRdEye.Width) Then
                If (fnRed(bmpOriginal.GetPixel(x + 1, y), iFault, sBrightness) = True) And (bmpMask.GetPixel(x + 1, y).R = 255) Then
                    SetWave(x + 1, y, iDepth + 1)
                End If
            End If
            If (y + 1 < bmpRdEye.Height) Then
                If (fnRed(bmpOriginal.GetPixel(x, y + 1), iFault, sBrightness) = True) And (bmpMask.GetPixel(x, y + 1).R = 255) Then
                    SetWave(x, y + 1, iDepth + 1)
                End If
            End If
            If (x - 1 >= 0) Then
                If (fnRed(bmpOriginal.GetPixel(x - 1, y), iFault, sBrightness) = True) And (bmpMask.GetPixel(x - 1, y).R = 255) Then
                    SetWave(x - 1, y, iDepth + 1)
                End If
            End If
        End If
    End Sub

    'Процедура автоматической обработки изображения.
    Private Sub UseAuto()
        'Вспомогательные переменные.
        Dim i, j, i0, j0 As Integer
        Dim bEye As Boolean
        'Вывод сопровождающей информации.
        pctRdEye.Image = bmpEmpty
        lblBack.Text = "Идет обработка изображения..."
        lblBack.Visible = True
        tbrRdEye.Refresh()
        pctRdEye.Refresh()
        lblBack.Refresh()
        'Тело основного алгоритма.
        For i = 0 To bmpRdEye.Height - 1
            For j = 0 To bmpRdEye.Width - 1
                If (fnRed(bmpRdEye.GetPixel(j, i), iFault, sBrightness) = True) And (bmpMask.GetPixel(j, i).R = 255) Then
                    iL = bmpRdEye.Width - 1
                    iR = 0
                    iT = bmpRdEye.Height - 1
                    iB = 0
                    lLength = 0
                    If bFSens = True Then
                        bEye = False
                    Else
                        bEye = True
                    End If
                    SetWave(j, i, 0)
                    'Проверка на наличие бликов.
                    For i0 = iT To iB
                        For j0 = iL To iR
                            If fnWhite(bmpOriginal.GetPixel(j0, i0), iWFault, sWBrightness) Then
                                bEye = True
                                Exit For
                            End If
                        Next
                    Next
                    'Проверка макс. площади.
                    If (lLength > iMaxEyeArea) Then
                        bEye = False
                    End If
                    'Контроль заполняемости.
                    If (bArea = True) And (((iB - iT) / 2) * ((iB - iT) / 2) * Math.PI + lArea < lLength) Then
                        bEye = False
                    End If
                    'Последняя проверка. Если все ок, закрашиваем глаз.
                    If (bEye = True) And (Math.Abs(iR - iL - iB + iT) < iEyeSh) Then
                        For i0 = iT To iB
                            For j0 = iL To iR
                                If bmpMask.GetPixel(j0, i0).R = 0 Then
                                    If bPixelShow = True Then
                                        sLightUp(j0, i0)
                                    Else
                                        bmpRdEye.SetPixel(j0, i0, fnTransColor(bmpOriginal.GetPixel(j0, i0), sdcEyeColor))
                                    End If
                                End If
                            Next
                        Next
                    End If
                End If
            Next
        Next
        'Вывод результата на экран.
        lblBack.Visible = False
        lblBack.Text = "Изображение для редактирования отсутствует."
        pctRdEye.Image = bmpRdEye
    End Sub

#End Region

#Region " Код графического интерфейса "

    Dim bmpEmpty As Bitmap 'Пустой снимок.
    Dim bmpOriginal As Bitmap 'Загружаемый снимок.
    Public Math As System.Math
    Public Shared bpctRdEye = False 'Флаг визуализации граф. файла.
    Dim spctFileName = "" 'Путь к открытому файлу.
    Dim i, j, x, y As Integer 'Переменные цикла.
    Dim sdgGraphics As System.Drawing.Graphics
    Dim sdpPen As New System.Drawing.Pen(Color.White)

        'Открытие графического файла.
    Private Sub OpenGraphics()
        Dim dlgOpen As New OpenFileDialog()
        Dim i, j As Integer
        dlgOpen.Filter = "Все файлы (*.*)|*.*"
        dlgOpen.FilterIndex = 1
        dlgOpen.RestoreDirectory = True
        If dlgOpen.ShowDialog() = DialogResult.OK Then
            If (bpctRdEye = True) Then
                CloseGraphics()
                pctRdEye.Refresh()
            End If
            lblBack.Text = "Подождите. Идет загрузка изображения..."
            lblBack.Refresh()
            bmpOriginal = New Bitmap(dlgOpen.FileName)
            bmpRdEye = New Bitmap(dlgOpen.FileName)
            bmpMask = New Bitmap(dlgOpen.FileName)
            For i = 0 To bmpMask.Height - 1
                For j = 0 To bmpMask.Width - 1
                    bmpMask.SetPixel(j, i, Color.White)
                Next
            Next
            pctRdEye.Image = bmpRdEye
            spctFileName = dlgOpen.FileName
            lblBack.Visible = False
            mnuSaveAs.Enabled = True
            mnuClose.Enabled = True
            tbrRdEye.Buttons(1).Enabled = True
            tbrRdEye.Buttons(2).Enabled = True
            tbrRdEye.Buttons(6).Enabled = True
            'DEMO VERSION.
            tbrRdEye.Buttons(7).Enabled = True
            tbrRdEye.Buttons(8).Enabled = True
            tbrRdEye.Buttons(9).Enabled = True
            mnuNoAuto.Enabled = True
            mnuNrAuto.Enabled = True
            mnuAuto.Enabled = True
            mnuClear.Enabled = True
            bpctRdEye = True
            lblBack.Text = "Изображение для редактирования отсутствует."
        End If
        dlgOpen.Dispose()
    End Sub

    'Сохранение графики в файл.
    Private Sub SaveGraphics()
        Dim dlgSaveAs As New SaveFileDialog()
        dlgSaveAs.Filter = "Все файлы (*.*)|*.*"
        dlgSaveAs.FilterIndex = 1
        dlgSaveAs.RestoreDirectory = True
        If dlgSaveAs.ShowDialog() = DialogResult.OK Then
            On Error Resume Next 'Сохранение в открытый файл запрещено!
            bmpRdEye.Save(dlgSaveAs.FileName)
        End If
        dlgSaveAs.Dispose()
    End Sub

    'Закрытие графического файла.
    Private Sub CloseGraphics()
        pctRdEye.Image = bmpEmpty
        bpctRdEye = False
        spctFileName = ""
        lblBack.Visible = True
        mnuSaveAs.Enabled = False
        mnuClose.Enabled = False
        tbrRdEye.Buttons(1).Enabled = False
        tbrRdEye.Buttons(2).Enabled = False
        tbrRdEye.Buttons(6).Enabled = False
        tbrRdEye.Buttons(6).Pushed = False
        tbrRdEye.Buttons(7).Enabled = False
        tbrRdEye.Buttons(7).Pushed = False
        tbrRdEye.Buttons(8).Enabled = False
        tbrRdEye.Buttons(8).Pushed = False
        tbrRdEye.Buttons(9).Enabled = False
        tbrRdEye.Buttons(9).Pushed = False
        mnuNoAuto.Enabled = False
        mnuNoAuto.Checked = False
        mnuNrAuto.Enabled = False
        mnuNrAuto.Checked = False
        mnuAuto.Enabled = False
        mnuAuto.Checked = False
        mnuClear.Enabled = False
        mnuClear.Checked = False
        pctRdEye.Cursor = Cursors.Default
        bmpRdEye.Dispose()
        bmpOriginal.Dispose()
        bmpMask.Dispose()
    End Sub

    'Выбор инструмента "ручной обработки глаза".
    Private Sub CheckNoAuto()
        If mnuNoAuto.Checked = False Then
            mnuNoAuto.Checked = True
            tbrRdEye.Buttons(6).Pushed = True
            pctRdEye.Cursor = Cursors.Cross
        Else
            mnuNoAuto.Checked = False
            tbrRdEye.Buttons(6).Pushed = False
            pctRdEye.Cursor = Cursors.Default
        End If
        mnuNrAuto.Checked = False
        mnuAuto.Checked = False
        mnuClear.Checked = False
        tbrRdEye.Buttons(7).Pushed = False
        tbrRdEye.Buttons(8).Pushed = False
        tbrRdEye.Buttons(9).Pushed = False
    End Sub

    'Выбор инструмента "заливки глаза".
    Private Sub CheckNrAuto()
        If mnuNrAuto.Checked = False Then
            mnuNrAuto.Checked = True
            tbrRdEye.Buttons(7).Pushed = True
            pctRdEye.Cursor = Cursors.Cross
        Else
            mnuNrAuto.Checked = False
            tbrRdEye.Buttons(7).Pushed = False
            pctRdEye.Cursor = Cursors.Default
        End If
        mnuNoAuto.Checked = False
        mnuAuto.Checked = False
        mnuClear.Checked = False
        tbrRdEye.Buttons(6).Pushed = False
        tbrRdEye.Buttons(8).Pushed = False
        tbrRdEye.Buttons(9).Pushed = False
    End Sub

    'Выбор инструмента "автоматической обработки изображения".
    Private Sub CheckAuto()
        mnuNoAuto.Checked = False
        mnuNrAuto.Checked = False
        mnuClear.Checked = False
        tbrRdEye.Buttons(6).Pushed = False
        tbrRdEye.Buttons(7).Pushed = False
        tbrRdEye.Buttons(9).Pushed = False
        pctRdEye.Cursor = Cursors.Default
        'Действия...
        UseAuto()
    End Sub

    'Выбор инструмента "очистки".
    Private Sub CheckClear()
        If mnuClear.Checked = False Then
            mnuClear.Checked = True
            tbrRdEye.Buttons(9).Pushed = True
            pctRdEye.Cursor = Cursors.Cross
        Else
            mnuClear.Checked = False
            tbrRdEye.Buttons(9).Pushed = False
            pctRdEye.Cursor = Cursors.Default
        End If
        mnuNoAuto.Checked = False
        mnuNrAuto.Checked = False
        mnuAuto.Checked = False
        tbrRdEye.Buttons(6).Pushed = False
        tbrRdEye.Buttons(7).Pushed = False
        tbrRdEye.Buttons(8).Pushed = False
    End Sub

    'Загрузка формы.
    Private Sub frmRdEye_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Инициализация ручной кисти.
        bNAFilter = False
        bNAMiter = False
        iNABrushSize = 7
        bNABrushType = 1
        'Инициализация кисти очистки.
        iClearSize = 10
        bClearType = 1
        'Автоинструмент.
        iMaxEyeArea = 700
        iEyeSh = 15
        bArea = False
        lArea = 100
        bFSens = True
        'Основная инициализация.
        x = 0
        y = 0
        iFault = 20
        iWFault = 55
        sBrightness = 0.2
        sWBrightness = 0.7
        bNAMiterCnt = 70
        iNrSens = 80
        lblBack.TextAlign = ContentAlignment.MiddleCenter
        sdcEyeColor = Color.Black
        sdcPupilColor = Color.Black
        bPixelShow = False
        pctBack.Top = tbrRdEye.Height
        pctBack.Left = -10
        pctBack.Width = Me.Width + 10
        pctBack.Height = Me.Height - tbrRdEye.Height
        pctRdEye.Top = tbrRdEye.Height + 9
        pctRdEye.Left = 7
        pctRdEye.Width = Me.Width - 22
        pctRdEye.Height = Me.Height - tbrRdEye.Height - 70
        lblBack.Top = tbrRdEye.Height + 16
        lblBack.Left = 14
        lblBack.Width = pctRdEye.Width - 14
        lblBack.Height = pctRdEye.Height - 14
        sdgGraphics = pctRdEye.CreateGraphics
    End Sub

    'Реакция на изменение размеров формы (Выравнивает объекты на форме).
    Private Sub frmRdEye_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        pctBack.Top = tbrRdEye.Height
        pctBack.Width = Me.Width + 10
        pctBack.Height = Me.Height - tbrRdEye.Height
        pctRdEye.Top = tbrRdEye.Height + 9
        pctRdEye.Width = Me.Width - 22
        pctRdEye.Height = Me.Height - tbrRdEye.Height - 70
        lblBack.Top = tbrRdEye.Height + 16
        lblBack.Width = pctRdEye.Width - 14
        lblBack.Height = pctRdEye.Height - 14
        sdgGraphics = pctRdEye.CreateGraphics
    End Sub

    'Private Sub frmRdEye_Closed(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Closed
    'End Sub

    'Реакция на нажатие "Открыть" в меню (Открывает изображение).
    Private Sub mnuOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOpen.Click
        OpenGraphics()
    End Sub

    Private Sub mnuSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSaveAs.Click
        SaveGraphics()
    End Sub

    'Реакция на нажатие "Закрыть" в меню (Закрывает изображение).
    Private Sub mnuClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClose.Click
        CloseGraphics()
    End Sub

    'Реакция на нажатие "Выход" в меню (Завершает работу приложения).
    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        Application.Exit()
    End Sub

    'Реакция на нажатие "О RdEye..." в меню.
    Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
        Dim dlgAbout = New frmAbout()
        dlgAbout.ShowDialog(Me)
        dlgAbout.Dispose()
    End Sub

    'Реакция на нажатие "Настройки" в меню.
    Private Sub mnuOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOptions.Click
        Dim dlgOptions = New frmOptions()
        dlgOptions.ShowDialog(Me)
        dlgOptions.Dispose()
    End Sub

    'Реакция на нажатие "Ручная обработка глаза" в меню.
    Private Sub mnuNoAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNoAuto.Click
        CheckNoAuto()
    End Sub

    'Реакция на нажатие "Заливка глаза" в меню.
    Private Sub mnuNrAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNrAuto.Click
        CheckNrAuto()
    End Sub

    'Реакция на нажатие "Автоматическая обработка изображения" в меню.
    Private Sub mnuAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAuto.Click
        CheckAuto()
    End Sub

    'Реакция на нажатие "Очистка" в меню.
    Private Sub mnuClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClear.Click
        CheckClear()
    End Sub

    Private Sub frmRdEye_Unload(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        sdpPen.Dispose()
        sdgGraphics.Dispose()
    End Sub

    'Реакция на нажатие кнопок toolbar'а (Открывает изображение).
    Private Sub tbrRdEye_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrRdEye.ButtonClick
        Dim dlgOpen As New OpenFileDialog()
        Select Case e.Button.ImageIndex
            Case 0 'Открыть графический файл.
                OpenGraphics()
            Case 1 'Сохранить графику в файл.
                SaveGraphics()
            Case 2 'Закрыть файл.
                CloseGraphics()
            Case 3 'Опции.
                Dim dlgOptions = New frmOptions()
                dlgOptions.ShowDialog(Me)
                dlgOptions.Dispose()
            Case 4 'Ручная кисть.
                CheckNoAuto()
            Case 5 'Заливка глаза.
                CheckNrAuto()
            Case 6 'Автоматическая обработка области.
                CheckAuto()
            Case 7 'Очистка.
                CheckClear()
            Case 8 'Вызов справки.
                Dim dlgHelp = New frmHelp()
                dlgHelp.ShowDialog(Me)
                dlgHelp.Dispose()
        End Select
    End Sub

    Private Sub ClearBrush(ByVal iBrushSize As Integer)
        For i = y - iBrushSize To y + iBrushSize
            For j = x - iBrushSize To x + iBrushSize - 1
                If (j >= 0) And (j < bmpRdEye.Width - 1) And (i >= 0) And (i < bmpRdEye.Height) Then
                    sdpPen.Color = bmpRdEye.GetPixel(j, i)
                    sdgGraphics.DrawLine(sdpPen, j, i, j + 1, i)
                End If
            Next
        Next
    End Sub

    Private Sub DrawBrush()
        If (mnuNoAuto.Checked = True) Or (mnuClear.Checked = True) Then
            'Прединициализация области с графикой.
            If mnuNoAuto.Checked = True Then
                ClearBrush(iNABrushSize)
            Else
                ClearBrush(iClearSize)
            End If
            x = pctRdEye.MousePosition.X - Me.Left - 12
            y = pctRdEye.MousePosition.Y - Me.Top - 101
            If (x >= 0) And (x < bmpRdEye.Width) And (y >= 0) And (y < bmpRdEye.Height) Then
                If (bmpRdEye.GetPixel(x, y).GetBrightness < 0.5) Then
                    sdpPen.Color = Color.White
                Else
                    sdpPen.Color = Color.Black
                End If
            End If
            'Тело обработки кисти.
            If (mnuNoAuto.Checked = True) Then
                For i = y - iNABrushSize To y + iNABrushSize
                    For j = x - iNABrushSize To x + iNABrushSize
                        If (j >= 0) And (j < bmpRdEye.Width) And (i >= 0) And (i < bmpRdEye.Height) Then
                            If bNABrushType = 0 Then
                                If (pctRdEye.MouseButtons = MouseButtons.Left) Then
                                    UseNoAuto(j, i, True)
                                    bmpMask.SetPixel(j, i, Color.White)
                                Else
                                    If (pctRdEye.MouseButtons = MouseButtons.Right) Then
                                        UseNoAuto(j, i, False)
                                        bmpMask.SetPixel(j, i, Color.White)
                                    End If
                                End If
                            Else
                                If (iNABrushSize >= Math.Sqrt((x - j) * (x - j) + (y - i) * (y - i))) Then
                                    If (pctRdEye.MouseButtons = MouseButtons.Left) Then
                                        UseNoAuto(j, i, True)
                                        bmpMask.SetPixel(j, i, Color.White)
                                    Else
                                        If (pctRdEye.MouseButtons = MouseButtons.Right) Then
                                            UseNoAuto(j, i, False)
                                            bmpMask.SetPixel(j, i, Color.White)
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Next
                Next
                If (x - iNABrushSize >= 0) And (x + iNABrushSize < bmpRdEye.Width) And (y - iNABrushSize >= 0) And (y + iNABrushSize < bmpRdEye.Height) Then
                    If (bNABrushType = 0) Then
                        sdgGraphics.DrawRectangle(sdpPen, x - iNABrushSize, y - iNABrushSize, 2 * iNABrushSize, 2 * iNABrushSize)
                    Else
                        sdgGraphics.DrawEllipse(sdpPen, x - iNABrushSize, y - iNABrushSize, 2 * iNABrushSize, 2 * iNABrushSize)
                    End If
                End If
            Else
                If (mnuClear.Checked = True) Then
                    For i = y - iClearSize To y + iClearSize
                        For j = x - iClearSize To x + iClearSize
                            If (j >= 0) And (j < bmpRdEye.Width) And (i >= 0) And (i < bmpRdEye.Height) Then
                                If bClearType = 0 Then
                                    If (pctRdEye.MouseButtons = MouseButtons.Left) Then
                                        bmpRdEye.SetPixel(j, i, bmpOriginal.GetPixel(j, i))
                                        bmpMask.SetPixel(j, i, Color.White)
                                    End If
                                Else
                                    If (iClearSize >= Math.Sqrt((x - j) * (x - j) + (y - i) * (y - i))) Then
                                        If (pctRdEye.MouseButtons = MouseButtons.Left) Then
                                            bmpRdEye.SetPixel(j, i, bmpOriginal.GetPixel(j, i))
                                            bmpMask.SetPixel(j, i, Color.White)
                                        End If
                                    End If
                                End If
                            End If
                        Next
                    Next
                    If (x - iClearSize >= 0) And (x + iClearSize < bmpRdEye.Width) And (y - iClearSize >= 0) And (y + iClearSize < bmpRdEye.Height) Then
                        If bClearType = 0 Then
                            sdgGraphics.DrawRectangle(sdpPen, x - iClearSize, y - iClearSize, 2 * iClearSize, 2 * iClearSize)
                        Else
                            sdgGraphics.DrawEllipse(sdpPen, x - iClearSize, y - iClearSize, 2 * iClearSize, 2 * iClearSize)
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub mnuReference_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReference.Click
        Dim dlgHelp = New frmHelp()
        dlgHelp.ShowDialog(Me)
        dlgHelp.Dispose()
    End Sub

    Private Sub pctRdEye_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles pctRdEye.MouseDown
        Dim sdc As Color
        DrawBrush()
        If mnuNrAuto.Checked = True Then
            sdc = bmpRdEye.GetPixel(pctRdEye.MousePosition.X - Me.Left - 12, pctRdEye.MousePosition.Y - Me.Top - 101)
            If e.Button = MouseButtons.Left Then
                UseNrAuto(pctRdEye.MousePosition.X - Me.Left - 12, pctRdEye.MousePosition.Y - Me.Top - 101, sdc, 0, True)
            Else
                UseNrAuto(pctRdEye.MousePosition.X - Me.Left - 12, pctRdEye.MousePosition.Y - Me.Top - 101, sdc, 0, False)
            End If
        End If
        pctRdEye.Refresh()
    End Sub

    Private Sub pctRdEye_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles pctRdEye.MouseMove
        DrawBrush()
    End Sub

#End Region

End Class
