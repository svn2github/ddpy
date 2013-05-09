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
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPageNormal = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.BtnFontCand = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtFont = New System.Windows.Forms.TextBox()
        Me.ChkHideStatus = New System.Windows.Forms.CheckBox()
        Me.TabPageWordDic = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BtnAddWord = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtPinYin = New System.Windows.Forms.TextBox()
        Me.TxtWord = New System.Windows.Forms.TextBox()
        Me.TabPageAdvanced = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.BtnCloseServer = New System.Windows.Forms.Button()
        Me.ChkSrvMemory = New System.Windows.Forms.CheckBox()
        Me.TabPageHelp = New System.Windows.Forms.TabPage()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.FontDlgCand = New System.Windows.Forms.FontDialog()
        Me.BtnApply = New System.Windows.Forms.Button()
        Me.ChkAutoPosition = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumPyLen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumPageCnt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPageNormal.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabPageWordDic.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPageAdvanced.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.TabPageHelp.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Location = New System.Drawing.Point(182, 310)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(80, 23)
        Me.BtnOK.TabIndex = 1
        Me.BtnOK.Text = "确  定"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.Location = New System.Drawing.Point(263, 310)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(80, 23)
        Me.BtnClose.TabIndex = 2
        Me.BtnClose.Text = "取  消"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.ChkIn)
        Me.GroupBox1.Controls.Add(Me.ChkZhizhe)
        Me.GroupBox1.Controls.Add(Me.ChkZize)
        Me.GroupBox1.Controls.Add(Me.ChkZzh)
        Me.GroupBox1.Controls.Add(Me.ChkAn)
        Me.GroupBox1.Controls.Add(Me.ChkEn)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(393, 93)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "模糊音设定"
        '
        'ChkIn
        '
        Me.ChkIn.AutoSize = True
        Me.ChkIn.Location = New System.Drawing.Point(15, 65)
        Me.ChkIn.Name = "ChkIn"
        Me.ChkIn.Size = New System.Drawing.Size(62, 16)
        Me.ChkIn.TabIndex = 0
        Me.ChkIn.Text = "in = ing"
        Me.ChkIn.UseVisualStyleBackColor = True
        '
        'ChkZhizhe
        '
        Me.ChkZhizhe.AutoSize = True
        Me.ChkZhizhe.Location = New System.Drawing.Point(127, 65)
        Me.ChkZhizhe.Name = "ChkZhizhe"
        Me.ChkZhizhe.Size = New System.Drawing.Size(143, 16)
        Me.ChkZhizhe.TabIndex = 0
        Me.ChkZhizhe.Text = "zhi,chi,shi = zhe,che,she"
        Me.ChkZhizhe.UseVisualStyleBackColor = True
        '
        'ChkZize
        '
        Me.ChkZize.AutoSize = True
        Me.ChkZize.Location = New System.Drawing.Point(127, 43)
        Me.ChkZize.Name = "ChkZize"
        Me.ChkZize.Size = New System.Drawing.Size(107, 16)
        Me.ChkZize.TabIndex = 0
        Me.ChkZize.Text = "zi,ci,si = ze,ce,se"
        Me.ChkZize.UseVisualStyleBackColor = True
        '
        'ChkZzh
        '
        Me.ChkZzh.AutoSize = True
        Me.ChkZzh.Location = New System.Drawing.Point(127, 21)
        Me.ChkZzh.Name = "ChkZzh"
        Me.ChkZzh.Size = New System.Drawing.Size(98, 16)
        Me.ChkZzh.TabIndex = 0
        Me.ChkZzh.Text = "z,c,s = zh,ch,sh"
        Me.ChkZzh.UseVisualStyleBackColor = True
        '
        'ChkAn
        '
        Me.ChkAn.AutoSize = True
        Me.ChkAn.Location = New System.Drawing.Point(15, 21)
        Me.ChkAn.Name = "ChkAn"
        Me.ChkAn.Size = New System.Drawing.Size(68, 16)
        Me.ChkAn.TabIndex = 0
        Me.ChkAn.Text = "an = ang"
        Me.ChkAn.UseVisualStyleBackColor = True
        '
        'ChkEn
        '
        Me.ChkEn.AutoSize = True
        Me.ChkEn.Location = New System.Drawing.Point(15, 43)
        Me.ChkEn.Name = "ChkEn"
        Me.ChkEn.Size = New System.Drawing.Size(68, 16)
        Me.ChkEn.TabIndex = 0
        Me.ChkEn.Text = "en = eng"
        Me.ChkEn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 12)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "最大拼音输入长度："
        '
        'NumPyLen
        '
        Me.NumPyLen.Location = New System.Drawing.Point(127, 19)
        Me.NumPyLen.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.NumPyLen.Minimum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.NumPyLen.Name = "NumPyLen"
        Me.NumPyLen.Size = New System.Drawing.Size(36, 19)
        Me.NumPyLen.TabIndex = 5
        Me.NumPyLen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumPyLen.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "候选项显示个数："
        '
        'NumPageCnt
        '
        Me.NumPageCnt.Location = New System.Drawing.Point(127, 48)
        Me.NumPageCnt.Maximum = New Decimal(New Integer() {9, 0, 0, 0})
        Me.NumPageCnt.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.NumPageCnt.Name = "NumPageCnt"
        Me.NumPageCnt.Size = New System.Drawing.Size(36, 19)
        Me.NumPageCnt.TabIndex = 5
        Me.NumPageCnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumPageCnt.Value = New Decimal(New Integer() {9, 0, 0, 0})
        '
        'ChkVshow
        '
        Me.ChkVshow.AutoSize = True
        Me.ChkVshow.Location = New System.Drawing.Point(222, 22)
        Me.ChkVshow.Name = "ChkVshow"
        Me.ChkVshow.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkVshow.Size = New System.Drawing.Size(114, 16)
        Me.ChkVshow.TabIndex = 0
        Me.ChkVshow.Text = "：候选项竖直显示"
        Me.ChkVshow.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "自定义窗口标题："
        '
        'TxtTitle
        '
        Me.TxtTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TxtTitle.Location = New System.Drawing.Point(127, 77)
        Me.TxtTitle.MaxLength = 20
        Me.TxtTitle.Name = "TxtTitle"
        Me.TxtTitle.Size = New System.Drawing.Size(209, 19)
        Me.TxtTitle.TabIndex = 6
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(151, 187)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(169, 12)
        Me.LinkLabel1.TabIndex = 7
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "http://code.google.com/p/ddpy/"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(85, 188)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 12)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "项目主页："
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPageNormal)
        Me.TabControl1.Controls.Add(Me.TabPageWordDic)
        Me.TabControl1.Controls.Add(Me.TabPageAdvanced)
        Me.TabControl1.Controls.Add(Me.TabPageHelp)
        Me.TabControl1.Location = New System.Drawing.Point(12, 8)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(415, 292)
        Me.TabControl1.TabIndex = 9
        '
        'TabPageNormal
        '
        Me.TabPageNormal.Controls.Add(Me.GroupBox3)
        Me.TabPageNormal.Controls.Add(Me.GroupBox1)
        Me.TabPageNormal.Location = New System.Drawing.Point(4, 21)
        Me.TabPageNormal.Name = "TabPageNormal"
        Me.TabPageNormal.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageNormal.Size = New System.Drawing.Size(407, 267)
        Me.TabPageNormal.TabIndex = 0
        Me.TabPageNormal.Text = "常用设定"
        Me.TabPageNormal.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.BtnFontCand)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.TxtFont)
        Me.GroupBox3.Controls.Add(Me.NumPageCnt)
        Me.GroupBox3.Controls.Add(Me.NumPyLen)
        Me.GroupBox3.Controls.Add(Me.TxtTitle)
        Me.GroupBox3.Controls.Add(Me.ChkAutoPosition)
        Me.GroupBox3.Controls.Add(Me.ChkHideStatus)
        Me.GroupBox3.Controls.Add(Me.ChkVshow)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 112)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(393, 139)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "外观显示"
        '
        'BtnFontCand
        '
        Me.BtnFontCand.Location = New System.Drawing.Point(342, 47)
        Me.BtnFontCand.Name = "BtnFontCand"
        Me.BtnFontCand.Size = New System.Drawing.Size(40, 23)
        Me.BtnFontCand.TabIndex = 8
        Me.BtnFontCand.Text = "变更"
        Me.BtnFontCand.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(190, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 12)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "候选字体："
        '
        'TxtFont
        '
        Me.TxtFont.Location = New System.Drawing.Point(255, 49)
        Me.TxtFont.Name = "TxtFont"
        Me.TxtFont.ReadOnly = True
        Me.TxtFont.Size = New System.Drawing.Size(81, 19)
        Me.TxtFont.TabIndex = 10
        Me.TxtFont.Text = "宋体,12,0"
        '
        'ChkHideStatus
        '
        Me.ChkHideStatus.AutoSize = True
        Me.ChkHideStatus.Location = New System.Drawing.Point(16, 108)
        Me.ChkHideStatus.Name = "ChkHideStatus"
        Me.ChkHideStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkHideStatus.Size = New System.Drawing.Size(126, 16)
        Me.ChkHideStatus.TabIndex = 0
        Me.ChkHideStatus.Text = "：隐藏输入法状态栏"
        Me.ChkHideStatus.UseVisualStyleBackColor = True
        '
        'TabPageWordDic
        '
        Me.TabPageWordDic.Controls.Add(Me.GroupBox4)
        Me.TabPageWordDic.Controls.Add(Me.GroupBox2)
        Me.TabPageWordDic.Location = New System.Drawing.Point(4, 21)
        Me.TabPageWordDic.Name = "TabPageWordDic"
        Me.TabPageWordDic.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageWordDic.Size = New System.Drawing.Size(407, 267)
        Me.TabPageWordDic.TabIndex = 1
        Me.TabPageWordDic.Text = "词典管理"
        Me.TabPageWordDic.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 73)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(393, 178)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "词典管理"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.BtnAddWord)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.TxtPinYin)
        Me.GroupBox2.Controls.Add(Me.TxtWord)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(393, 57)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "缺字添加"
        '
        'BtnAddWord
        '
        Me.BtnAddWord.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddWord.Enabled = False
        Me.BtnAddWord.Location = New System.Drawing.Point(279, 20)
        Me.BtnAddWord.Name = "BtnAddWord"
        Me.BtnAddWord.Size = New System.Drawing.Size(100, 23)
        Me.BtnAddWord.TabIndex = 3
        Me.BtnAddWord.Text = "添加到用户词库"
        Me.BtnAddWord.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(93, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 12)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "拼音："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 12)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "汉字："
        '
        'TxtPinYin
        '
        Me.TxtPinYin.Location = New System.Drawing.Point(134, 22)
        Me.TxtPinYin.MaxLength = 6
        Me.TxtPinYin.Name = "TxtPinYin"
        Me.TxtPinYin.Size = New System.Drawing.Size(66, 19)
        Me.TxtPinYin.TabIndex = 1
        '
        'TxtWord
        '
        Me.TxtWord.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TxtWord.Location = New System.Drawing.Point(52, 22)
        Me.TxtWord.MaxLength = 1
        Me.TxtWord.Name = "TxtWord"
        Me.TxtWord.Size = New System.Drawing.Size(20, 19)
        Me.TxtWord.TabIndex = 0
        Me.TxtWord.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabPageAdvanced
        '
        Me.TabPageAdvanced.Controls.Add(Me.GroupBox6)
        Me.TabPageAdvanced.Controls.Add(Me.GroupBox5)
        Me.TabPageAdvanced.Location = New System.Drawing.Point(4, 21)
        Me.TabPageAdvanced.Name = "TabPageAdvanced"
        Me.TabPageAdvanced.Size = New System.Drawing.Size(407, 267)
        Me.TabPageAdvanced.TabIndex = 3
        Me.TabPageAdvanced.Text = "高级设定"
        Me.TabPageAdvanced.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Location = New System.Drawing.Point(7, 76)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(393, 175)
        Me.GroupBox6.TabIndex = 2
        Me.GroupBox6.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.BtnCloseServer)
        Me.GroupBox5.Controls.Add(Me.ChkSrvMemory)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 8)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(393, 62)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "后台服务管理"
        '
        'BtnCloseServer
        '
        Me.BtnCloseServer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCloseServer.Location = New System.Drawing.Point(237, 21)
        Me.BtnCloseServer.Name = "BtnCloseServer"
        Me.BtnCloseServer.Size = New System.Drawing.Size(140, 23)
        Me.BtnCloseServer.TabIndex = 0
        Me.BtnCloseServer.Text = "关闭后台服务程序"
        Me.BtnCloseServer.UseVisualStyleBackColor = True
        '
        'ChkSrvMemory
        '
        Me.ChkSrvMemory.AutoSize = True
        Me.ChkSrvMemory.Location = New System.Drawing.Point(9, 25)
        Me.ChkSrvMemory.Name = "ChkSrvMemory"
        Me.ChkSrvMemory.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkSrvMemory.Size = New System.Drawing.Size(102, 16)
        Me.ChkSrvMemory.TabIndex = 0
        Me.ChkSrvMemory.Text = "：节省内存模式"
        Me.ChkSrvMemory.UseVisualStyleBackColor = True
        '
        'TabPageHelp
        '
        Me.TabPageHelp.Controls.Add(Me.GroupBox7)
        Me.TabPageHelp.Controls.Add(Me.Label4)
        Me.TabPageHelp.Controls.Add(Me.LinkLabel1)
        Me.TabPageHelp.Location = New System.Drawing.Point(4, 21)
        Me.TabPageHelp.Name = "TabPageHelp"
        Me.TabPageHelp.Size = New System.Drawing.Size(407, 267)
        Me.TabPageHelp.TabIndex = 2
        Me.TabPageHelp.Text = "帮助"
        Me.TabPageHelp.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox7.Location = New System.Drawing.Point(7, 13)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(393, 124)
        Me.GroupBox7.TabIndex = 9
        Me.GroupBox7.TabStop = False
        '
        'FontDlgCand
        '
        Me.FontDlgCand.AllowVectorFonts = False
        Me.FontDlgCand.AllowVerticalFonts = False
        Me.FontDlgCand.FontMustExist = True
        Me.FontDlgCand.ShowEffects = False
        '
        'BtnApply
        '
        Me.BtnApply.Enabled = False
        Me.BtnApply.Location = New System.Drawing.Point(344, 310)
        Me.BtnApply.Name = "BtnApply"
        Me.BtnApply.Size = New System.Drawing.Size(80, 23)
        Me.BtnApply.TabIndex = 2
        Me.BtnApply.Text = "应  用"
        Me.BtnApply.UseVisualStyleBackColor = True
        '
        'ChkAutoPosition
        '
        Me.ChkAutoPosition.AutoSize = True
        Me.ChkAutoPosition.Checked = True
        Me.ChkAutoPosition.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkAutoPosition.Location = New System.Drawing.Point(198, 108)
        Me.ChkAutoPosition.Name = "ChkAutoPosition"
        Me.ChkAutoPosition.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkAutoPosition.Size = New System.Drawing.Size(138, 16)
        Me.ChkAutoPosition.TabIndex = 0
        Me.ChkAutoPosition.Text = "：输入法窗口光标跟随"
        Me.ChkAutoPosition.UseVisualStyleBackColor = True
        '
        'FrmSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(436, 345)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.BtnApply)
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
        Me.TabControl1.ResumeLayout(False)
        Me.TabPageNormal.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabPageWordDic.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPageAdvanced.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.TabPageHelp.ResumeLayout(False)
        Me.TabPageHelp.PerformLayout()
        Me.ResumeLayout(False)

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
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPageNormal As System.Windows.Forms.TabPage
    Friend WithEvents TabPageWordDic As System.Windows.Forms.TabPage
    Friend WithEvents TabPageHelp As System.Windows.Forms.TabPage
    Friend WithEvents TabPageAdvanced As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAddWord As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtPinYin As System.Windows.Forms.TextBox
    Friend WithEvents TxtWord As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCloseServer As System.Windows.Forms.Button
    Friend WithEvents ChkSrvMemory As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents FontDlgCand As System.Windows.Forms.FontDialog
    Friend WithEvents BtnFontCand As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtFont As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnApply As System.Windows.Forms.Button
    Friend WithEvents ChkHideStatus As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAutoPosition As System.Windows.Forms.CheckBox

End Class
