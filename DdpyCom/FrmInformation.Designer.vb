<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInformation
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
        Me.LblClose = New System.Windows.Forms.Label()
        Me.LblText = New System.Windows.Forms.Label()
        Me.LblExecText = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'LblClose
        '
        Me.LblClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LblClose.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClose.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.LblClose.Location = New System.Drawing.Point(165, -1)
        Me.LblClose.Name = "LblClose"
        Me.LblClose.Size = New System.Drawing.Size(18, 14)
        Me.LblClose.TabIndex = 0
        Me.LblClose.Text = "×"
        Me.LblClose.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LblText
        '
        Me.LblText.AutoSize = True
        Me.LblText.BackColor = System.Drawing.SystemColors.Control
        Me.LblText.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblText.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblText.Location = New System.Drawing.Point(3, 16)
        Me.LblText.Name = "LblText"
        Me.LblText.Size = New System.Drawing.Size(56, 16)
        Me.LblText.TabIndex = 0
        Me.LblText.Text = "Label1"
        '
        'LblExecText
        '
        Me.LblExecText.AutoSize = True
        Me.LblExecText.BackColor = System.Drawing.SystemColors.Control
        Me.LblExecText.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LblExecText.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblExecText.ForeColor = System.Drawing.Color.Blue
        Me.LblExecText.Location = New System.Drawing.Point(3, 35)
        Me.LblExecText.Name = "LblExecText"
        Me.LblExecText.Size = New System.Drawing.Size(56, 16)
        Me.LblExecText.TabIndex = 3
        Me.LblExecText.Text = "Label1"
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(179, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 1)
        Me.Panel1.TabIndex = 4
        '
        'FrmInformation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(180, 60)
        Me.Controls.Add(Me.LblExecText)
        Me.Controls.Add(Me.LblText)
        Me.Controls.Add(Me.LblClose)
        Me.Controls.Add(Me.Panel1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("宋体", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmInformation"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblClose As System.Windows.Forms.Label
    Friend WithEvents LblText As System.Windows.Forms.Label
    Friend WithEvents LblExecText As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
