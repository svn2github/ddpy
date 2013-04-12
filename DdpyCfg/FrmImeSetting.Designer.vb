<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSetting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSetting))
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ChkIn = New System.Windows.Forms.CheckBox()
        Me.ChkZhizhe = New System.Windows.Forms.CheckBox()
        Me.ChkZize = New System.Windows.Forms.CheckBox()
        Me.ChkZzh = New System.Windows.Forms.CheckBox()
        Me.ChkAn = New System.Windows.Forms.CheckBox()
        Me.ChkEn = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NumPyLen = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NumPageCnt = New System.Windows.Forms.NumericUpDown()
        Me.ChkVshow = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtTitle = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumPyLen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumPageCnt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(41, 239)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(75, 23)
        Me.BtnOK.TabIndex = 1
        Me.BtnOK.Text = "设定"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.Location = New System.Drawing.Point(166, 239)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(75, 23)
        Me.BtnClose.TabIndex = 2
        Me.BtnClose.Text = "关闭"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChkIn)
        Me.GroupBox1.Controls.Add(Me.ChkZhizhe)
        Me.GroupBox1.Controls.Add(Me.ChkZize)
        Me.GroupBox1.Controls.Add(Me.ChkZzh)
        Me.GroupBox1.Controls.Add(Me.ChkAn)
        Me.GroupBox1.Controls.Add(Me.ChkEn)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(263, 100)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "模糊音"
        '
        'ChkIn
        '
        Me.ChkIn.AutoSize = True
        Me.ChkIn.Location = New System.Drawing.Point(10, 62)
        Me.ChkIn.Name = "ChkIn"
        Me.ChkIn.Size = New System.Drawing.Size(62, 16)
        Me.ChkIn.TabIndex = 0
        Me.ChkIn.Text = "in = ing"
        Me.ChkIn.UseVisualStyleBackColor = True
        '
        'ChkZhizhe
        '
        Me.ChkZhizhe.AutoSize = True
        Me.ChkZhizhe.Location = New System.Drawing.Point(112, 62)
        Me.ChkZhizhe.Name = "ChkZhizhe"
        Me.ChkZhizhe.Size = New System.Drawing.Size(143, 16)
        Me.ChkZhizhe.TabIndex = 0
        Me.ChkZhizhe.Text = "zhi,chi,shi = zhe,che,she"
        Me.ChkZhizhe.UseVisualStyleBackColor = True
        '
        'ChkZize
        '
        Me.ChkZize.AutoSize = True
        Me.ChkZize.Location = New System.Drawing.Point(112, 40)
        Me.ChkZize.Name = "ChkZize"
        Me.ChkZize.Size = New System.Drawing.Size(107, 16)
        Me.ChkZize.TabIndex = 0
        Me.ChkZize.Text = "zi,ci,si = ze,ce,se"
        Me.ChkZize.UseVisualStyleBackColor = True
        '
        'ChkZzh
        '
        Me.ChkZzh.AutoSize = True
        Me.ChkZzh.Location = New System.Drawing.Point(112, 18)
        Me.ChkZzh.Name = "ChkZzh"
        Me.ChkZzh.Size = New System.Drawing.Size(98, 16)
        Me.ChkZzh.TabIndex = 0
        Me.ChkZzh.Text = "z,c,s = zh,ch,sh"
        Me.ChkZzh.UseVisualStyleBackColor = True
        '
        'ChkAn
        '
        Me.ChkAn.AutoSize = True
        Me.ChkAn.Location = New System.Drawing.Point(10, 18)
        Me.ChkAn.Name = "ChkAn"
        Me.ChkAn.Size = New System.Drawing.Size(68, 16)
        Me.ChkAn.TabIndex = 0
        Me.ChkAn.Text = "an = ang"
        Me.ChkAn.UseVisualStyleBackColor = True
        '
        'ChkEn
        '
        Me.ChkEn.AutoSize = True
        Me.ChkEn.Location = New System.Drawing.Point(10, 40)
        Me.ChkEn.Name = "ChkEn"
        Me.ChkEn.Size = New System.Drawing.Size(68, 16)
        Me.ChkEn.TabIndex = 0
        Me.ChkEn.Text = "en = eng"
        Me.ChkEn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 124)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 12)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "最大拼音输入长度："
        '
        'NumPyLen
        '
        Me.NumPyLen.Location = New System.Drawing.Point(133, 122)
        Me.NumPyLen.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.NumPyLen.Minimum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.NumPyLen.Name = "NumPyLen"
        Me.NumPyLen.Size = New System.Drawing.Size(36, 19)
        Me.NumPyLen.TabIndex = 5
        Me.NumPyLen.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 157)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "候选文字数："
        '
        'NumPageCnt
        '
        Me.NumPageCnt.Location = New System.Drawing.Point(133, 155)
        Me.NumPageCnt.Maximum = New Decimal(New Integer() {9, 0, 0, 0})
        Me.NumPageCnt.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.NumPageCnt.Name = "NumPageCnt"
        Me.NumPageCnt.Size = New System.Drawing.Size(36, 19)
        Me.NumPageCnt.TabIndex = 5
        Me.NumPageCnt.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'ChkVshow
        '
        Me.ChkVshow.AutoSize = True
        Me.ChkVshow.Location = New System.Drawing.Point(199, 156)
        Me.ChkVshow.Name = "ChkVshow"
        Me.ChkVshow.Size = New System.Drawing.Size(72, 16)
        Me.ChkVshow.TabIndex = 0
        Me.ChkVshow.Text = "竖直显示"
        Me.ChkVshow.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 195)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "自定义窗口标题："
        '
        'TxtTitle
        '
        Me.TxtTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TxtTitle.Location = New System.Drawing.Point(124, 192)
        Me.TxtTitle.MaxLength = 20
        Me.TxtTitle.Name = "TxtTitle"
        Me.TxtTitle.Size = New System.Drawing.Size(151, 19)
        Me.TxtTitle.TabIndex = 6
        '
        'FrmSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(288, 288)
        Me.Controls.Add(Me.TxtTitle)
        Me.Controls.Add(Me.NumPageCnt)
        Me.Controls.Add(Me.NumPyLen)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ChkVshow)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSetting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "设置"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumPyLen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumPageCnt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkIn As System.Windows.Forms.CheckBox
    Friend WithEvents ChkZize As System.Windows.Forms.CheckBox
    Friend WithEvents ChkZzh As System.Windows.Forms.CheckBox
    Friend WithEvents ChkEn As System.Windows.Forms.CheckBox
    Friend WithEvents ChkZhizhe As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAn As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumPyLen As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NumPageCnt As System.Windows.Forms.NumericUpDown
    Friend WithEvents ChkVshow As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtTitle As System.Windows.Forms.TextBox

End Class
