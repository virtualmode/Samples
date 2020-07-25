Public Class frmHelp
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
    Friend WithEvents txtHelp As System.Windows.Forms.RichTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmHelp))
        Me.txtHelp = New System.Windows.Forms.RichTextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtHelp
        '
        Me.txtHelp.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtHelp.Location = New System.Drawing.Point(16, 16)
        Me.txtHelp.Name = "txtHelp"
        Me.txtHelp.Size = New System.Drawing.Size(520, 480)
        Me.txtHelp.TabIndex = 0
        Me.txtHelp.Text = ""
        '
        'btnClose
        '
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(482, 520)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(64, 24)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Закрыть"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(538, 504)
        Me.Label1.TabIndex = 2
        '
        'frmHelp
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(556, 553)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClose, Me.txtHelp, Me.Label1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHelp"
        Me.ShowInTaskbar = False
        Me.Text = "Справка по RdEye"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmHelp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = frmRdEye.ActiveForm.Top + 11
        Me.Left = frmRdEye.ActiveForm.Left + 11
        On Error Resume Next
        txtHelp.LoadFile("Справка.rtf")
        If Trim(txtHelp.Text) = "" Then
            Dim dlgOpen As New OpenFileDialog()
            dlgOpen.Filter = "Файл справки по RdEye (Справка.rtf)|Справка.rtf"
            dlgOpen.FilterIndex = 1
            dlgOpen.RestoreDirectory = True
            If dlgOpen.ShowDialog() = DialogResult.OK Then
                txtHelp.LoadFile(dlgOpen.FileName)
            End If
            dlgOpen.Dispose()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class
