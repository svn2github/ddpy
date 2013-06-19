<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnSearchPy = New System.Windows.Forms.Button()
        Me.TxtPinYin = New System.Windows.Forms.TextBox()
        Me.TxtWord = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BtnUpdatePinyin = New System.Windows.Forms.Button()
        Me.BtnExpWord = New System.Windows.Forms.Button()
        Me.BtnAddPinyin = New System.Windows.Forms.Button()
        Me.BtnSelectWordFile = New System.Windows.Forms.Button()
        Me.TxtWordFile = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FileDlgWord = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.BtnExpDuoyinzi = New System.Windows.Forms.Button()
        Me.BtnCreateWithDdpy = New System.Windows.Forms.Button()
        Me.BtnCreate = New System.Windows.Forms.Button()
        Me.BtnWordPinyin = New System.Windows.Forms.Button()
        Me.TxtWordPinyin = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.tip = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.BtnSearchPy)
        Me.GroupBox1.Controls.Add(Me.TxtPinYin)
        Me.GroupBox1.Controls.Add(Me.TxtWord)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 13)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox1.Size = New System.Drawing.Size(588, 57)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "拼音查看"
        '
        'BtnSearchPy
        '
        Me.BtnSearchPy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSearchPy.Location = New System.Drawing.Point(486, 18)
        Me.BtnSearchPy.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnSearchPy.Name = "BtnSearchPy"
        Me.BtnSearchPy.Size = New System.Drawing.Size(88, 25)
        Me.BtnSearchPy.TabIndex = 2
        Me.BtnSearchPy.Text = "查拼音"
        Me.BtnSearchPy.UseVisualStyleBackColor = True
        '
        'TxtPinYin
        '
        Me.TxtPinYin.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TxtPinYin.Location = New System.Drawing.Point(188, 20)
        Me.TxtPinYin.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TxtPinYin.Name = "TxtPinYin"
        Me.TxtPinYin.ReadOnly = True
        Me.TxtPinYin.Size = New System.Drawing.Size(287, 22)
        Me.TxtPinYin.TabIndex = 1
        Me.TxtPinYin.TabStop = False
        '
        'TxtWord
        '
        Me.TxtWord.Location = New System.Drawing.Point(64, 20)
        Me.TxtWord.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TxtWord.Name = "TxtWord"
        Me.TxtWord.Size = New System.Drawing.Size(116, 22)
        Me.TxtWord.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 24)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "字词："
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.BtnExpDuoyinzi)
        Me.GroupBox2.Controls.Add(Me.BtnUpdatePinyin)
        Me.GroupBox2.Controls.Add(Me.BtnExpWord)
        Me.GroupBox2.Controls.Add(Me.BtnAddPinyin)
        Me.GroupBox2.Controls.Add(Me.BtnSelectWordFile)
        Me.GroupBox2.Controls.Add(Me.TxtWordFile)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 76)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(588, 112)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "拼音转换"
        '
        'BtnUpdatePinyin
        '
        Me.BtnUpdatePinyin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnUpdatePinyin.Location = New System.Drawing.Point(160, 75)
        Me.BtnUpdatePinyin.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnUpdatePinyin.Name = "BtnUpdatePinyin"
        Me.BtnUpdatePinyin.Size = New System.Drawing.Size(88, 25)
        Me.BtnUpdatePinyin.TabIndex = 3
        Me.BtnUpdatePinyin.Text = "检查拼音"
        Me.BtnUpdatePinyin.UseVisualStyleBackColor = True
        '
        'BtnExpWord
        '
        Me.BtnExpWord.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExpWord.Location = New System.Drawing.Point(378, 75)
        Me.BtnExpWord.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnExpWord.Name = "BtnExpWord"
        Me.BtnExpWord.Size = New System.Drawing.Size(88, 25)
        Me.BtnExpWord.TabIndex = 3
        Me.BtnExpWord.Text = "导出文字"
        Me.BtnExpWord.UseVisualStyleBackColor = True
        '
        'BtnAddPinyin
        '
        Me.BtnAddPinyin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddPinyin.Location = New System.Drawing.Point(64, 75)
        Me.BtnAddPinyin.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnAddPinyin.Name = "BtnAddPinyin"
        Me.BtnAddPinyin.Size = New System.Drawing.Size(88, 25)
        Me.BtnAddPinyin.TabIndex = 3
        Me.BtnAddPinyin.Text = "输出拼音"
        Me.BtnAddPinyin.UseVisualStyleBackColor = True
        '
        'BtnSelectWordFile
        '
        Me.BtnSelectWordFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSelectWordFile.Location = New System.Drawing.Point(486, 19)
        Me.BtnSelectWordFile.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnSelectWordFile.Name = "BtnSelectWordFile"
        Me.BtnSelectWordFile.Size = New System.Drawing.Size(88, 25)
        Me.BtnSelectWordFile.TabIndex = 3
        Me.BtnSelectWordFile.Text = "选择文件"
        Me.BtnSelectWordFile.UseVisualStyleBackColor = True
        '
        'TxtWordFile
        '
        Me.TxtWordFile.Location = New System.Drawing.Point(64, 21)
        Me.TxtWordFile.Name = "TxtWordFile"
        Me.TxtWordFile.Size = New System.Drawing.Size(411, 22)
        Me.TxtWordFile.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(61, 46)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(246, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "（一行一词，UTF8编码Window文本格式）"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 25)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "文件："
        '
        'FileDlgWord
        '
        Me.FileDlgWord.FileName = "OpenFileDialog1"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.BtnCreateWithDdpy)
        Me.GroupBox3.Controls.Add(Me.BtnCreate)
        Me.GroupBox3.Controls.Add(Me.BtnWordPinyin)
        Me.GroupBox3.Controls.Add(Me.TxtWordPinyin)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Location = New System.Drawing.Point(14, 194)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(588, 124)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "淡定词库文件制作"
        '
        'BtnExpDuoyinzi
        '
        Me.BtnExpDuoyinzi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExpDuoyinzi.Location = New System.Drawing.Point(256, 75)
        Me.BtnExpDuoyinzi.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnExpDuoyinzi.Name = "BtnExpDuoyinzi"
        Me.BtnExpDuoyinzi.Size = New System.Drawing.Size(114, 25)
        Me.BtnExpDuoyinzi.TabIndex = 3
        Me.BtnExpDuoyinzi.Text = "检查导出多音字"
        Me.BtnExpDuoyinzi.UseVisualStyleBackColor = True
        '
        'BtnCreateWithDdpy
        '
        Me.BtnCreateWithDdpy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCreateWithDdpy.Location = New System.Drawing.Point(225, 78)
        Me.BtnCreateWithDdpy.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnCreateWithDdpy.Name = "BtnCreateWithDdpy"
        Me.BtnCreateWithDdpy.Size = New System.Drawing.Size(173, 25)
        Me.BtnCreateWithDdpy.TabIndex = 7
        Me.BtnCreateWithDdpy.Text = "补充并生成淡定词库"
        Me.BtnCreateWithDdpy.UseVisualStyleBackColor = True
        '
        'BtnCreate
        '
        Me.BtnCreate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCreate.Location = New System.Drawing.Point(63, 78)
        Me.BtnCreate.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.Size = New System.Drawing.Size(154, 25)
        Me.BtnCreate.TabIndex = 7
        Me.BtnCreate.Text = "单独生成淡定词库"
        Me.BtnCreate.UseVisualStyleBackColor = True
        '
        'BtnWordPinyin
        '
        Me.BtnWordPinyin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnWordPinyin.Location = New System.Drawing.Point(485, 22)
        Me.BtnWordPinyin.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnWordPinyin.Name = "BtnWordPinyin"
        Me.BtnWordPinyin.Size = New System.Drawing.Size(88, 25)
        Me.BtnWordPinyin.TabIndex = 8
        Me.BtnWordPinyin.Text = "选择文件"
        Me.BtnWordPinyin.UseVisualStyleBackColor = True
        '
        'TxtWordPinyin
        '
        Me.TxtWordPinyin.Location = New System.Drawing.Point(63, 24)
        Me.TxtWordPinyin.Name = "TxtWordPinyin"
        Me.TxtWordPinyin.Size = New System.Drawing.Size(411, 22)
        Me.TxtWordPinyin.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(60, 49)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(358, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "（一行至少两列，词语Tab拼音，UTF8编码Window文本格式）"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 28)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "文件："
        '
        'BtnClose
        '
        Me.BtnClose.Location = New System.Drawing.Point(247, 342)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(123, 33)
        Me.BtnClose.TabIndex = 3
        Me.BtnClose.Text = "关 闭"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(616, 397)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("宋体", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "淡定拼音工具"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnSearchPy As System.Windows.Forms.Button
    Friend WithEvents TxtPinYin As System.Windows.Forms.TextBox
    Friend WithEvents TxtWord As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnSelectWordFile As System.Windows.Forms.Button
    Friend WithEvents TxtWordFile As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FileDlgWord As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnAddPinyin As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCreateWithDdpy As System.Windows.Forms.Button
    Friend WithEvents BtnCreate As System.Windows.Forms.Button
    Friend WithEvents BtnWordPinyin As System.Windows.Forms.Button
    Friend WithEvents TxtWordPinyin As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnExpDuoyinzi As System.Windows.Forms.Button
    Friend WithEvents tip As System.Windows.Forms.ToolTip
    Friend WithEvents BtnExpWord As System.Windows.Forms.Button
    Friend WithEvents BtnUpdatePinyin As System.Windows.Forms.Button
End Class
