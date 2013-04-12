<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImeDebug
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
        Me.TxtInfo = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'TxtInfo
        '
        Me.TxtInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtInfo.Enabled = False
        Me.TxtInfo.Location = New System.Drawing.Point(0, 0)
        Me.TxtInfo.Multiline = True
        Me.TxtInfo.Name = "TxtInfo"
        Me.TxtInfo.ReadOnly = True
        Me.TxtInfo.Size = New System.Drawing.Size(406, 800)
        Me.TxtInfo.TabIndex = 0
        Me.TxtInfo.TabStop = False
        '
        'FrmImeDebug
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(406, 800)
        Me.Controls.Add(Me.TxtInfo)
        Me.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmImeDebug"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtInfo As System.Windows.Forms.TextBox
End Class
