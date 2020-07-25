Public Class frmOptions
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
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents tcOptions As System.Windows.Forms.TabControl
    Friend WithEvents lblBrushType As System.Windows.Forms.Label
    Friend WithEvents cntNASize As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblBrushColor As System.Windows.Forms.Label
    Friend WithEvents rdoCircle As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSquare As System.Windows.Forms.RadioButton
    Friend WithEvents tpNoAuto As System.Windows.Forms.TabPage
    Friend WithEvents tpNrAuto As System.Windows.Forms.TabPage
    Friend WithEvents tpAuto As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cntClearSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents rdoCCircle As System.Windows.Forms.RadioButton
    Friend WithEvents rdoCSquare As System.Windows.Forms.RadioButton
    Friend WithEvents pctZColor As System.Windows.Forms.PictureBox
    Friend WithEvents lblZColor As System.Windows.Forms.Label
    Friend WithEvents chcPix As System.Windows.Forms.CheckBox
    Friend WithEvents pctColor As System.Windows.Forms.PictureBox
    Friend WithEvents lblEyeColor As System.Windows.Forms.Label
    Friend WithEvents tpClear As System.Windows.Forms.TabPage
    Friend WithEvents tbMain As System.Windows.Forms.TabPage
    Friend WithEvents chcNAFilter As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtBrightness As System.Windows.Forms.TextBox
    Friend WithEvents cntFault As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtWBrightness As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cntW As System.Windows.Forms.GroupBox
    Friend WithEvents cntWFault As System.Windows.Forms.NumericUpDown
    Friend WithEvents chcMiter As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cntS As System.Windows.Forms.NumericUpDown
    Friend WithEvents pb1 As System.Windows.Forms.Label
    Friend WithEvents pb2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents chcFSens As System.Windows.Forms.CheckBox
    Friend WithEvents cntArea As System.Windows.Forms.NumericUpDown
    Friend WithEvents chcArea As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cntEyeSh As System.Windows.Forms.NumericUpDown
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmOptions))
        Me.btnClose = New System.Windows.Forms.Button()
        Me.tcOptions = New System.Windows.Forms.TabControl()
        Me.tbMain = New System.Windows.Forms.TabPage()
        Me.pb2 = New System.Windows.Forms.Label()
        Me.pb1 = New System.Windows.Forms.Label()
        Me.cntW = New System.Windows.Forms.GroupBox()
        Me.txtWBrightness = New System.Windows.Forms.TextBox()
        Me.cntWFault = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtBrightness = New System.Windows.Forms.TextBox()
        Me.cntFault = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pctZColor = New System.Windows.Forms.PictureBox()
        Me.lblZColor = New System.Windows.Forms.Label()
        Me.chcPix = New System.Windows.Forms.CheckBox()
        Me.pctColor = New System.Windows.Forms.PictureBox()
        Me.lblEyeColor = New System.Windows.Forms.Label()
        Me.tpNoAuto = New System.Windows.Forms.TabPage()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.chcMiter = New System.Windows.Forms.CheckBox()
        Me.chcNAFilter = New System.Windows.Forms.CheckBox()
        Me.lblBrushType = New System.Windows.Forms.Label()
        Me.cntNASize = New System.Windows.Forms.NumericUpDown()
        Me.lblBrushColor = New System.Windows.Forms.Label()
        Me.rdoCircle = New System.Windows.Forms.RadioButton()
        Me.rdoSquare = New System.Windows.Forms.RadioButton()
        Me.tpAuto = New System.Windows.Forms.TabPage()
        Me.chcArea = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cntArea = New System.Windows.Forms.NumericUpDown()
        Me.chcFSens = New System.Windows.Forms.CheckBox()
        Me.tpNrAuto = New System.Windows.Forms.TabPage()
        Me.cntS = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tpClear = New System.Windows.Forms.TabPage()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rdoCCircle = New System.Windows.Forms.RadioButton()
        Me.rdoCSquare = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cntClearSize = New System.Windows.Forms.NumericUpDown()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cntEyeSh = New System.Windows.Forms.NumericUpDown()
        Me.tcOptions.SuspendLayout()
        Me.tbMain.SuspendLayout()
        Me.cntW.SuspendLayout()
        CType(Me.cntWFault, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cntFault, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpNoAuto.SuspendLayout()
        CType(Me.cntNASize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpAuto.SuspendLayout()
        CType(Me.cntArea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpNrAuto.SuspendLayout()
        CType(Me.cntS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpClear.SuspendLayout()
        CType(Me.cntClearSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cntEyeSh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(480, 256)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(64, 24)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "Закрыть"
        '
        'tcOptions
        '
        Me.tcOptions.Controls.AddRange(New System.Windows.Forms.Control() {Me.tbMain, Me.tpNoAuto, Me.tpAuto, Me.tpNrAuto, Me.tpClear})
        Me.tcOptions.Location = New System.Drawing.Point(8, 8)
        Me.tcOptions.Name = "tcOptions"
        Me.tcOptions.SelectedIndex = 0
        Me.tcOptions.Size = New System.Drawing.Size(536, 240)
        Me.tcOptions.TabIndex = 14
        '
        'tbMain
        '
        Me.tbMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.pb2, Me.pb1, Me.cntW, Me.GroupBox1, Me.pctZColor, Me.lblZColor, Me.chcPix, Me.pctColor, Me.lblEyeColor})
        Me.tbMain.Location = New System.Drawing.Point(4, 22)
        Me.tbMain.Name = "tbMain"
        Me.tbMain.Size = New System.Drawing.Size(528, 214)
        Me.tbMain.TabIndex = 4
        Me.tbMain.Text = "Основные"
        '
        'pb2
        '
        Me.pb2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pb2.Location = New System.Drawing.Point(96, 72)
        Me.pb2.Name = "pb2"
        Me.pb2.Size = New System.Drawing.Size(112, 18)
        Me.pb2.TabIndex = 35
        Me.pb2.Text = "Очистка маски..."
        Me.pb2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.pb2.Visible = False
        '
        'pb1
        '
        Me.pb1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pb1.Location = New System.Drawing.Point(96, 48)
        Me.pb1.Name = "pb1"
        Me.pb1.Size = New System.Drawing.Size(112, 18)
        Me.pb1.TabIndex = 34
        Me.pb1.Text = "Очистка маски..."
        Me.pb1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.pb1.Visible = False
        '
        'cntW
        '
        Me.cntW.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtWBrightness, Me.cntWFault, Me.Label1, Me.Label2})
        Me.cntW.Location = New System.Drawing.Point(224, 112)
        Me.cntW.Name = "cntW"
        Me.cntW.Size = New System.Drawing.Size(192, 88)
        Me.cntW.TabIndex = 33
        Me.cntW.TabStop = False
        Me.cntW.Text = "Определение белого цвета:"
        '
        'txtWBrightness
        '
        Me.txtWBrightness.Location = New System.Drawing.Point(104, 56)
        Me.txtWBrightness.Name = "txtWBrightness"
        Me.txtWBrightness.Size = New System.Drawing.Size(72, 20)
        Me.txtWBrightness.TabIndex = 3
        Me.txtWBrightness.Text = "0.000"
        '
        'cntWFault
        '
        Me.cntWFault.Location = New System.Drawing.Point(104, 24)
        Me.cntWFault.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.cntWFault.Name = "cntWFault"
        Me.cntWFault.Size = New System.Drawing.Size(72, 20)
        Me.cntWFault.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Мин. яркость:"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Погрешность:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtBrightness, Me.cntFault, Me.Label6, Me.Label5})
        Me.GroupBox1.Location = New System.Drawing.Point(16, 112)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(192, 88)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Определение красного цвета:"
        '
        'txtBrightness
        '
        Me.txtBrightness.Location = New System.Drawing.Point(104, 56)
        Me.txtBrightness.Name = "txtBrightness"
        Me.txtBrightness.Size = New System.Drawing.Size(72, 20)
        Me.txtBrightness.TabIndex = 3
        Me.txtBrightness.Text = "0.000"
        '
        'cntFault
        '
        Me.cntFault.Location = New System.Drawing.Point(104, 24)
        Me.cntFault.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.cntFault.Name = "cntFault"
        Me.cntFault.Size = New System.Drawing.Size(72, 20)
        Me.cntFault.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 16)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Мин. яркость:"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Погрешность:"
        '
        'pctZColor
        '
        Me.pctZColor.BackColor = System.Drawing.Color.Black
        Me.pctZColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pctZColor.Location = New System.Drawing.Point(96, 72)
        Me.pctZColor.Name = "pctZColor"
        Me.pctZColor.Size = New System.Drawing.Size(112, 18)
        Me.pctZColor.TabIndex = 29
        Me.pctZColor.TabStop = False
        '
        'lblZColor
        '
        Me.lblZColor.Location = New System.Drawing.Point(16, 80)
        Me.lblZColor.Name = "lblZColor"
        Me.lblZColor.Size = New System.Drawing.Size(80, 16)
        Me.lblZColor.TabIndex = 28
        Me.lblZColor.Text = "Цвет зрачка:"
        '
        'chcPix
        '
        Me.chcPix.Location = New System.Drawing.Point(16, 16)
        Me.chcPix.Name = "chcPix"
        Me.chcPix.Size = New System.Drawing.Size(155, 16)
        Me.chcPix.TabIndex = 27
        Me.chcPix.Text = "Подсветка пикселей"
        '
        'pctColor
        '
        Me.pctColor.BackColor = System.Drawing.Color.Lavender
        Me.pctColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pctColor.Location = New System.Drawing.Point(96, 48)
        Me.pctColor.Name = "pctColor"
        Me.pctColor.Size = New System.Drawing.Size(112, 18)
        Me.pctColor.TabIndex = 25
        Me.pctColor.TabStop = False
        '
        'lblEyeColor
        '
        Me.lblEyeColor.Location = New System.Drawing.Point(16, 48)
        Me.lblEyeColor.Name = "lblEyeColor"
        Me.lblEyeColor.Size = New System.Drawing.Size(80, 16)
        Me.lblEyeColor.TabIndex = 26
        Me.lblEyeColor.Text = "Цвет глаза:"
        '
        'tpNoAuto
        '
        Me.tpNoAuto.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label10, Me.chcMiter, Me.chcNAFilter, Me.lblBrushType, Me.cntNASize, Me.lblBrushColor, Me.rdoCircle, Me.rdoSquare})
        Me.tpNoAuto.Location = New System.Drawing.Point(4, 22)
        Me.tpNoAuto.Name = "tpNoAuto"
        Me.tpNoAuto.Size = New System.Drawing.Size(528, 214)
        Me.tpNoAuto.TabIndex = 0
        Me.tpNoAuto.Text = "Ручная обработка"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(218, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 16)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "пикс."
        '
        'chcMiter
        '
        Me.chcMiter.Location = New System.Drawing.Point(16, 136)
        Me.chcMiter.Name = "chcMiter"
        Me.chcMiter.Size = New System.Drawing.Size(192, 16)
        Me.chcMiter.TabIndex = 21
        Me.chcMiter.Text = "Сглаживание границ"
        '
        'chcNAFilter
        '
        Me.chcNAFilter.Location = New System.Drawing.Point(16, 112)
        Me.chcNAFilter.Name = "chcNAFilter"
        Me.chcNAFilter.Size = New System.Drawing.Size(128, 16)
        Me.chcNAFilter.TabIndex = 18
        Me.chcNAFilter.Text = "Фильтрация цвета"
        '
        'lblBrushType
        '
        Me.lblBrushType.Location = New System.Drawing.Point(16, 56)
        Me.lblBrushType.Name = "lblBrushType"
        Me.lblBrushType.Size = New System.Drawing.Size(80, 16)
        Me.lblBrushType.TabIndex = 17
        Me.lblBrushType.Text = "Вид кисти:"
        '
        'cntNASize
        '
        Me.cntNASize.Location = New System.Drawing.Point(144, 16)
        Me.cntNASize.Name = "cntNASize"
        Me.cntNASize.Size = New System.Drawing.Size(72, 20)
        Me.cntNASize.TabIndex = 16
        Me.cntNASize.Value = New Decimal(New Integer() {7, 0, 0, 0})
        '
        'lblBrushColor
        '
        Me.lblBrushColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblBrushColor.Location = New System.Drawing.Point(16, 16)
        Me.lblBrushColor.Name = "lblBrushColor"
        Me.lblBrushColor.Size = New System.Drawing.Size(128, 16)
        Me.lblBrushColor.TabIndex = 15
        Me.lblBrushColor.Text = "Размер кисти (радиус):"
        '
        'rdoCircle
        '
        Me.rdoCircle.Checked = True
        Me.rdoCircle.Location = New System.Drawing.Point(104, 72)
        Me.rdoCircle.Name = "rdoCircle"
        Me.rdoCircle.Size = New System.Drawing.Size(48, 24)
        Me.rdoCircle.TabIndex = 14
        Me.rdoCircle.TabStop = True
        Me.rdoCircle.Text = "Круг"
        '
        'rdoSquare
        '
        Me.rdoSquare.Location = New System.Drawing.Point(16, 72)
        Me.rdoSquare.Name = "rdoSquare"
        Me.rdoSquare.Size = New System.Drawing.Size(72, 24)
        Me.rdoSquare.TabIndex = 13
        Me.rdoSquare.Text = "Квадрат"
        '
        'tpAuto
        '
        Me.tpAuto.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label12, Me.Label13, Me.cntEyeSh, Me.chcArea, Me.Label11, Me.Label8, Me.cntArea, Me.chcFSens})
        Me.tpAuto.Location = New System.Drawing.Point(4, 22)
        Me.tpAuto.Name = "tpAuto"
        Me.tpAuto.Size = New System.Drawing.Size(528, 214)
        Me.tpAuto.TabIndex = 2
        Me.tpAuto.Text = "Автоматическая обработка"
        '
        'chcArea
        '
        Me.chcArea.Location = New System.Drawing.Point(16, 88)
        Me.chcArea.Name = "chcArea"
        Me.chcArea.Size = New System.Drawing.Size(224, 16)
        Me.chcArea.TabIndex = 32
        Me.chcArea.Text = "Контроль заполняемости"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(216, 48)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 16)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "пикс.^2"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(16, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 16)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Макс. площадь глаза:"
        '
        'cntArea
        '
        Me.cntArea.Location = New System.Drawing.Point(144, 48)
        Me.cntArea.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.cntArea.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.cntArea.Name = "cntArea"
        Me.cntArea.Size = New System.Drawing.Size(72, 20)
        Me.cntArea.TabIndex = 1
        Me.cntArea.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'chcFSens
        '
        Me.chcFSens.Location = New System.Drawing.Point(16, 112)
        Me.chcFSens.Name = "chcFSens"
        Me.chcFSens.Size = New System.Drawing.Size(176, 16)
        Me.chcFSens.TabIndex = 0
        Me.chcFSens.Text = "Чувствительность к бликам"
        '
        'tpNrAuto
        '
        Me.tpNrAuto.Controls.AddRange(New System.Windows.Forms.Control() {Me.cntS, Me.Label7})
        Me.tpNrAuto.Location = New System.Drawing.Point(4, 22)
        Me.tpNrAuto.Name = "tpNrAuto"
        Me.tpNrAuto.Size = New System.Drawing.Size(528, 214)
        Me.tpNrAuto.TabIndex = 1
        Me.tpNrAuto.Text = "Заливка"
        '
        'cntS
        '
        Me.cntS.Location = New System.Drawing.Point(144, 16)
        Me.cntS.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.cntS.Name = "cntS"
        Me.cntS.Size = New System.Drawing.Size(72, 20)
        Me.cntS.TabIndex = 18
        Me.cntS.Value = New Decimal(New Integer() {23, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 16)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Чувствительность:"
        '
        'tpClear
        '
        Me.tpClear.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label9, Me.Label4, Me.rdoCCircle, Me.rdoCSquare, Me.Label3, Me.cntClearSize})
        Me.tpClear.Location = New System.Drawing.Point(4, 22)
        Me.tpClear.Name = "tpClear"
        Me.tpClear.Size = New System.Drawing.Size(528, 214)
        Me.tpClear.TabIndex = 3
        Me.tpClear.Text = "Инструмент очистки"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(218, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 16)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "пикс."
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Вид кисти:"
        '
        'rdoCCircle
        '
        Me.rdoCCircle.Checked = True
        Me.rdoCCircle.Location = New System.Drawing.Point(104, 72)
        Me.rdoCCircle.Name = "rdoCCircle"
        Me.rdoCCircle.Size = New System.Drawing.Size(48, 24)
        Me.rdoCCircle.TabIndex = 28
        Me.rdoCCircle.TabStop = True
        Me.rdoCCircle.Text = "Круг"
        '
        'rdoCSquare
        '
        Me.rdoCSquare.Location = New System.Drawing.Point(16, 72)
        Me.rdoCSquare.Name = "rdoCSquare"
        Me.rdoCSquare.Size = New System.Drawing.Size(72, 24)
        Me.rdoCSquare.TabIndex = 27
        Me.rdoCSquare.Text = "Квадрат"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 16)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Размер кисти (радиус):"
        '
        'cntClearSize
        '
        Me.cntClearSize.Location = New System.Drawing.Point(144, 16)
        Me.cntClearSize.Name = "cntClearSize"
        Me.cntClearSize.Size = New System.Drawing.Size(72, 20)
        Me.cntClearSize.TabIndex = 25
        Me.cntClearSize.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(216, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(32, 16)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "пикс."
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(16, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(120, 16)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "Доп. к форме глаза:"
        '
        'cntEyeSh
        '
        Me.cntEyeSh.Location = New System.Drawing.Point(144, 16)
        Me.cntEyeSh.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.cntEyeSh.Name = "cntEyeSh"
        Me.cntEyeSh.Size = New System.Drawing.Size(72, 20)
        Me.cntEyeSh.TabIndex = 33
        Me.cntEyeSh.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'frmOptions
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(556, 288)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tcOptions, Me.btnClose})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOptions"
        Me.ShowInTaskbar = False
        Me.Text = "Настройки"
        Me.tcOptions.ResumeLayout(False)
        Me.tbMain.ResumeLayout(False)
        Me.cntW.ResumeLayout(False)
        CType(Me.cntWFault, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.cntFault, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpNoAuto.ResumeLayout(False)
        CType(Me.cntNASize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpAuto.ResumeLayout(False)
        CType(Me.cntArea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpNrAuto.ResumeLayout(False)
        CType(Me.cntS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpClear.ResumeLayout(False)
        CType(Me.cntClearSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cntEyeSh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = frmRdEye.ActiveForm.Top + 11
        Me.Left = frmRdEye.ActiveForm.Left + 11
        cntEyeSh.Value = frmRdEye.iEyeSh
        cntArea.Value = frmRdEye.iMaxEyeArea
        chcArea.Checked = frmRdEye.bArea
        chcArea.Text = "Контроль заполняемости ( =" + Str(frmRdEye.lArea) + " )"
        chcFSens.Checked = frmRdEye.bFSens
        cntFault.Value = frmRdEye.iFault
        cntWFault.Value = frmRdEye.iWFault
        txtBrightness.Text = Trim(Str(frmRdEye.sBrightness))
        txtWBrightness.Text = Trim(Str(frmRdEye.sWBrightness))
        pctColor.BackColor = frmRdEye.sdcEyeColor
        pctZColor.BackColor = frmRdEye.sdcPupilColor
        chcPix.Checked = frmRdEye.bPixelShow
        chcNAFilter.Checked = frmRdEye.bNAFilter
        chcMiter.Checked = frmRdEye.bNAMiter
        chcMiter.Text = "Сглаживание границ ( =" + Str(frmRdEye.bNAMiterCnt) + " )"
        cntNASize.Value = frmRdEye.iNABrushSize
        cntClearSize.Value = frmRdEye.iClearSize
        cntS.Value = frmRdEye.iNrSens
        Select Case frmRdEye.bNABrushType
            Case 0
                rdoSquare.Checked = True
                rdoCircle.Checked = False
            Case 1
                rdoSquare.Checked = False
                rdoCircle.Checked = True
        End Select
        Select Case frmRdEye.bClearType
            Case 0
                rdoCSquare.Checked = True
                rdoCCircle.Checked = False
            Case 1
                rdoCSquare.Checked = False
                rdoCCircle.Checked = True
        End Select
    End Sub

    Private Sub frmOptions_Unload(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        On Error Resume Next
        frmRdEye.sBrightness = Val(txtBrightness.Text)
        frmRdEye.sWBrightness = Val(txtWBrightness.Text)
        frmRdEye.iNABrushSize = cntNASize.Value
        frmRdEye.iClearSize = cntClearSize.Value
        frmRdEye.iNrSens = cntS.Value
        frmRdEye.iFault = cntFault.Value
        frmRdEye.iWFault = cntWFault.Value
        frmRdEye.iMaxEyeArea = cntArea.Value
        frmRdEye.iEyeSh = cntEyeSh.Value
        If rdoSquare.Checked = True Then
            frmRdEye.bNABrushType = 0
        Else
            frmRdEye.bNABrushType = 1
        End If
        If rdoCSquare.Checked = True Then
            frmRdEye.bClearType = 0
        Else
            frmRdEye.bClearType = 1
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub chcNAFilter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chcNAFilter.CheckedChanged
        frmRdEye.bNAFilter = chcNAFilter.Checked
    End Sub

    Private Sub chcPix_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chcPix.CheckedChanged
        frmRdEye.bPixelShow = chcPix.Checked
    End Sub

    Private Sub pctColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctColor.Click
        Dim dlgGetColor As New ColorDialog()
        Dim i, j As Integer
        If dlgGetColor.ShowDialog() = DialogResult.OK Then
            frmRdEye.sdcEyeColor = dlgGetColor.Color
            pctColor.BackColor = dlgGetColor.Color
            If frmRdEye.bpctRdEye = True Then
                pb1.Visible = True
                pb1.Refresh()
                For i = 0 To frmRdEye.bmpMask.Height - 1
                    For j = 0 To frmRdEye.bmpMask.Width - 1
                        frmRdEye.bmpMask.SetPixel(j, i, Color.White)
                    Next
                Next
                pb1.Visible = False
            End If
        End If
        dlgGetColor.Dispose()
    End Sub

    Private Sub pctZColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctZColor.Click
        Dim dlgGetColor As New ColorDialog()
        Dim i, j As Integer
        If dlgGetColor.ShowDialog() = DialogResult.OK Then
            frmRdEye.sdcPupilColor = dlgGetColor.Color
            pctZColor.BackColor = dlgGetColor.Color
            If frmRdEye.bpctRdEye = True Then
                pb2.Visible = True
                pb2.Refresh()
                For i = 0 To frmRdEye.bmpMask.Height - 1
                    For j = 0 To frmRdEye.bmpMask.Width - 1
                        frmRdEye.bmpMask.SetPixel(j, i, Color.White)
                    Next
                Next
                pb2.Visible = False
            End If
        End If
        dlgGetColor.Dispose()
    End Sub

    Private Sub chcMiter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chcMiter.CheckedChanged
        frmRdEye.bNAMiter = chcMiter.Checked
        chcMiter.Text = "Сглаживание границ ( = " + Trim(Str(frmRdEye.bNAMiterCnt)) + " )"
    End Sub

    Private Sub chcMiter_Click(ByVal sender As Object, ByVal e As EventArgs) Handles chcMiter.Click
        If chcMiter.Checked = True Then
            frmRdEye.bNAMiterCnt = Val(InputBox("Введите величину сглаживания границ между белым и красным цветами:", "Инициализация сглаживания", Trim(Str(frmRdEye.bNAMiterCnt))))
            chcMiter.Text = "Сглаживание границ ( = " + Trim(Str(frmRdEye.bNAMiterCnt)) + " )"
        End If
    End Sub

    Private Sub chcArea_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chcArea.CheckedChanged
        frmRdEye.bArea = chcArea.Checked
        chcArea.Text = "Контроль заполняемости ( =" + Str(frmRdEye.lArea) + " )"
    End Sub

    Private Sub chcArea_Click(ByVal sender As Object, ByVal e As EventArgs) Handles chcArea.Click
        If chcArea.Checked = True Then
            frmRdEye.lArea = Val(InputBox("Введите допустимую погрешность площадей:", "Инициализация контроля заполняемости", Trim(Str(frmRdEye.lArea))))
            chcArea.Text = "Контроль заполняемости ( =" + Str(frmRdEye.lArea) + " )"
        End If
    End Sub

    Private Sub chcFSens_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chcFSens.CheckedChanged
        frmRdEye.bFSens = chcFSens.Checked
    End Sub

End Class
