<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImeStatus
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImeStatus))
        Me.PanMode = New System.Windows.Forms.Panel()
        Me.PanLng = New System.Windows.Forms.Panel()
        Me.PanLogo = New System.Windows.Forms.Panel()
        Me.PanBd = New System.Windows.Forms.Panel()
        Me.PanSetting = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'PanMode
        '
        Me.PanMode.BackgroundImage = Global.DdpyCom.My.Resources.Resources.MdHalfF
        Me.PanMode.Location = New System.Drawing.Point(49, 0)
        Me.PanMode.Name = "PanMode"
        Me.PanMode.Size = New System.Drawing.Size(24, 23)
        Me.PanMode.TabIndex = 4
        '
        'PanLng
        '
        Me.PanLng.BackgroundImage = Global.DdpyCom.My.Resources.Resources.LngCnF
        Me.PanLng.Location = New System.Drawing.Point(26, 0)
        Me.PanLng.Name = "PanLng"
        Me.PanLng.Size = New System.Drawing.Size(23, 23)
        Me.PanLng.TabIndex = 3
        '
        'PanLogo
        '
        Me.PanLogo.BackgroundImage = Global.DdpyCom.My.Resources.Resources.Pin
        Me.PanLogo.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.PanLogo.Location = New System.Drawing.Point(0, 0)
        Me.PanLogo.Name = "PanLogo"
        Me.PanLogo.Size = New System.Drawing.Size(26, 23)
        Me.PanLogo.TabIndex = 2
        '
        'PanBd
        '
        Me.PanBd.BackgroundImage = CType(resources.GetObject("PanBd.BackgroundImage"), System.Drawing.Image)
        Me.PanBd.Location = New System.Drawing.Point(73, 0)
        Me.PanBd.Name = "PanBd"
        Me.PanBd.Size = New System.Drawing.Size(24, 23)
        Me.PanBd.TabIndex = 1
        '
        'PanSetting
        '
        Me.PanSetting.BackgroundImage = Global.DdpyCom.My.Resources.Resources.SetF
        Me.PanSetting.Location = New System.Drawing.Point(97, 0)
        Me.PanSetting.Name = "PanSetting"
        Me.PanSetting.Size = New System.Drawing.Size(24, 23)
        Me.PanSetting.TabIndex = 6
        '
        'FrmImeStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.BackColor = System.Drawing.Color.MistyRose
        Me.ClientSize = New System.Drawing.Size(122, 23)
        Me.Controls.Add(Me.PanSetting)
        Me.Controls.Add(Me.PanMode)
        Me.Controls.Add(Me.PanLng)
        Me.Controls.Add(Me.PanLogo)
        Me.Controls.Add(Me.PanBd)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Location = New System.Drawing.Point(1000, 900)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmImeStatus"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanBd As System.Windows.Forms.Panel
    Friend WithEvents PanLogo As System.Windows.Forms.Panel
    Friend WithEvents PanLng As System.Windows.Forms.Panel
    Friend WithEvents PanMode As System.Windows.Forms.Panel
    Friend WithEvents PanSetting As System.Windows.Forms.Panel
End Class
