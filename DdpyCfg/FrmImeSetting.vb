Imports Microsoft.Win32

''' <summary>
''' 淡定拼音输入法配置窗口
''' </summary>
Public Class FrmSetting

    Private sSrvSetting As String = ""

    ''' <summary>
    ''' 初始化
    ''' </summary>
    Private Sub FrmSetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Dim server = CreateObject("DdpySrv.ComClass")
            sSrvSetting = server.SrvGetSettingInfo()

            Dim ary As String() = sSrvSetting.Split(vbTab)

            ChkAn.Checked = CBool(ary(0))
            ChkEn.Checked = CBool(ary(1))
            ChkIn.Checked = CBool(ary(2))
            ChkZzh.Checked = CBool(ary(3))
            ChkZize.Checked = CBool(ary(4))
            ChkZhizhe.Checked = CBool(ary(5))
            ChkRiRe.Checked = CBool(ary(6))

            NumPyLen.Value = CInt(ary(7))
            NumPageCnt.Value = CInt(ary(8))

            ChkVshow.Checked = CBool(ary(9))

            TxtTitle.Text = CStr(ary(10))

            ChkSrvMemory.Checked = CBool(ary(11))

            If Trim(ary(12)).Replace(",", "").Length = (ary(12).Length - 2) Then
                TxtCandFont.Text = ary(12)
            End If

            ChkHideStatus.Checked = CBool(ary(13))
            ChkAutoPosition.Checked = CBool(ary(14))

            ChkCandLimit.Checked = CBool(ary(15))
            NumCandLimit.Value = CInt(ary(16))
            NumCandLimit.Enabled = ChkCandLimit.Checked

            ChkAddFirstWordIdx.Checked = CBool(ary(17))
            ChkAutoCreateWord.Checked = CBool(ary(18))
            ChkIMode.Checked = CBool(ary(19))
            ChkShowInfoWin.Checked = CBool(ary(20))
            If Trim(ary(21)).Replace(",", "").Length = (ary(21).Length - 2) Then
                TxtInfoFont.Text = ary(21)
            End If
            ChkAutoShowPyTextInfo.Checked = CBool(ary(22))
            NumMaxExtsWidth.Value = CInt(ary(23))
            NumMaxExtsHeight.Value = CInt(ary(24))

            ChkYuanYan.Checked = CBool(ary(25))

        Catch ex As Exception
            ' MsgBox("初始显示发生异常" & vbNewLine & "(错误消息:" & ex.Message & ")", MsgBoxStyle.Exclamation, "淡定")
        End Try

        If GetSetting().Equals(sSrvSetting) Then
            BtnApply.Enabled = False
        Else
            BtnApply.Enabled = True
        End If

    End Sub

    Private Function GetSetting() As String
        Dim lst As New ArrayList
        lst.Add(ChkAn.Checked)
        lst.Add(ChkEn.Checked)
        lst.Add(ChkIn.Checked)
        lst.Add(ChkZzh.Checked)
        lst.Add(ChkZize.Checked)
        lst.Add(ChkZhizhe.Checked)
        lst.Add(ChkRiRe.Checked)

        lst.Add(NumPyLen.Value)
        lst.Add(NumPageCnt.Value)

        lst.Add(ChkVshow.Checked)

        lst.Add(TxtTitle.Text)

        lst.Add(ChkSrvMemory.Checked)

        lst.Add(TxtCandFont.Text)
        lst.Add(ChkHideStatus.Checked)
        lst.Add(ChkAutoPosition.Checked)
        lst.Add(ChkCandLimit.Checked)
        lst.Add(NumCandLimit.Value)
        lst.Add(ChkAddFirstWordIdx.Checked)
        lst.Add(ChkAutoCreateWord.Checked)
        lst.Add(ChkIMode.Checked)
        lst.Add(ChkShowInfoWin.Checked)
        lst.Add(TxtInfoFont.Text)
        lst.Add(ChkAutoShowPyTextInfo.Checked)
        lst.Add(NumMaxExtsWidth.Value)
        lst.Add(NumMaxExtsHeight.Value)

        lst.Add(ChkYuanYan.Checked)

        Return Strings.Join(lst.ToArray, vbTab)
    End Function

    Private Sub BtnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnApply.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim sSeting As String = GetSetting()
            Dim server = CreateObject("DdpySrv.ComClass")
            server.SrvSetSettingInfo(sSeting)

            sSrvSetting = sSeting
            BtnApply.Enabled = False
        Catch ex As Exception
            MsgBox("配置信息保存失败" & vbNewLine & "(错误消息:" & ex.Message & ")", MsgBoxStyle.Exclamation, "淡定")
        Finally
            Cursor = Cursors.Arrow
        End Try
    End Sub

    ''' <summary>
    ''' 设定
    ''' </summary>
    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim server = CreateObject("DdpySrv.ComClass")
            server.SrvSetSettingInfo(GetSetting())

            Me.Close()
        Catch ex As Exception
            Cursor = Cursors.Arrow
            MsgBox("配置信息保存失败" & vbNewLine & "(错误消息:" & ex.Message & ")", MsgBoxStyle.Exclamation, "淡定")
        End Try

    End Sub


    Private Sub BtnFontCand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFontCand.Click

        Try
            Dim sFont As String() = Strings.Split(TxtCandFont.Text, ",")
            Dim sName As String = sFont(0)
            Dim iSize As Single = sFont(1)
            Dim iStyle As FontStyle = sFont(2)

            FontDlgCand.Font = New Font(sName, iSize, iStyle)
        Catch ex As Exception
            FontDlgCand.Font = New Font("宋体", 12, FontStyle.Regular)
        End Try

        If FontDlgCand.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TxtCandFont.Text = FontDlgCand.Font.Name & "," & FontDlgCand.Font.Size & "," & FontDlgCand.Font.Style
        End If

    End Sub

#Region "关闭窗口"

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

#End Region

#Region "打开主页"

    Private Sub HomePage_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        ' 打开主页
        System.Diagnostics.Process.Start(LinkLabel1.Text)
    End Sub

#End Region

#Region "缺字添加"

    Private Sub BtnAddWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddWord.Click

        Try

            If Not IsValidPinYin(Trim(TxtPinYin.Text).ToLower) Then
                BtnAddWord.Enabled = False
                MsgBox("拼音『" & TxtPinYin.Text & "』有误，请修正拼音后再添加", MsgBoxStyle.Exclamation, "淡定")
                TxtPinYin.Focus()
                TxtPinYin.SelectAll()
                Return
            End If

            Dim server As Object = CreateObject("DdpySrv.ComClass")
            server.SrvRegisterWords(Trim(TxtPinYin.Text).ToLower & vbLf & Trim(TxtWord.Text))
            MsgBox("『" & TxtWord.Text & "』字已经添加成功", MsgBoxStyle.Information, "淡定")
        Catch ex As Exception
            MsgBox("『" & TxtWord.Text & "』字添加失败" & vbNewLine & "(错误消息:" & ex.Message & ")", MsgBoxStyle.Exclamation, "淡定")
        End Try


    End Sub

    Private Sub TxtWord_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtWord.TextChanged, TxtPinYin.TextChanged
        If "".Equals(Trim(TxtWord.Text)) OrElse "".Equals(Trim(TxtPinYin.Text)) Then
            BtnAddWord.Enabled = False
        Else
            BtnAddWord.Enabled = True
        End If
    End Sub

    Private Function IsValidPinYin(ByVal py As String) As Boolean
        Dim map As New Hashtable

        map("pin") = True
        map("qin") = True
        map("cou") = True
        map("dou") = True
        map("zhui") = True
        map("gou") = True
        map("shuai") = True
        map("piao") = True
        map("jin") = True
        map("lin") = True
        map("min") = True
        map("shui") = True
        map("tiao") = True
        map("bin") = True
        map("zei") = True
        map("niao") = True
        map("huai") = True
        map("biao") = True
        map("kuai") = True
        map("chui") = True
        map("shang") = True
        map("guai") = True
        map("ya") = True
        map("za") = True
        map("fei") = True
        map("gei") = True
        map("ra") = True
        map("sa") = True
        map("ta") = True
        map("wa") = True
        map("ha") = True
        map("qun") = True
        map("ka") = True
        map("la") = True
        map("chuang") = True
        map("na") = True
        map("jiong") = True
        map("ba") = True
        map("ca") = True
        map("da") = True
        map("fa") = True
        map("ga") = True
        map("ji") = True
        map("cao") = True
        map("dao") = True
        map("dun") = True
        map("zhua") = True
        map("pen") = True
        map("xiu") = True
        map("ren") = True
        map("sen") = True
        map("jue") = True
        map("qiu") = True
        map("ken") = True
        map("men") = True
        map("nen") = True
        map("neng") = True
        map("jiu") = True
        map("liu") = True
        map("miu") = True
        map("fen") = True
        map("gen") = True
        map("ying") = True
        map("diu") = True
        map("an") = True
        map("qiang") = True
        map("en") = True
        map("zhuai") = True
        map("zong") = True
        map("zhong") = True
        map("zuo") = True
        map("fou") = True
        map("ruo") = True
        map("suo") = True
        map("tuo") = True
        map("gun") = True
        map("huo") = True
        map("kuo") = True
        map("luo") = True
        map("yo") = True
        map("nuo") = True
        map("cuo") = True
        map("duo") = True
        map("can") = True
        map("guo") = True
        map("zh") = True
        map("huang") = True
        map("sh") = True
        map("y") = True
        map("z") = True
        map("yang") = True
        map("zang") = True
        map("q") = True
        map("r") = True
        map("pang") = True
        map("t") = True
        map("rang") = True
        map("sang") = True
        map("tang") = True
        map("h") = True
        map("wang") = True
        map("hang") = True
        map("l") = True
        map("m") = True
        map("kang") = True
        map("lang") = True
        map("miao") = True
        map("nang") = True
        map("xing") = True
        map("ying") = True
        map("bang") = True
        map("cang") = True
        map("dang") = True
        map("fang") = True
        map("gang") = True
        map("mie") = True
        map("xiong") = True
        map("zhuang") = True
        map("zhe") = True
        map("ye") = True
        map("ze") = True
        map("xu") = True
        map("yu") = True
        map("zu") = True
        map("s") = True
        map("pe") = True
        map("she") = True
        map("re") = True
        map("pu") = True
        map("qu") = True
        map("ru") = True
        map("su") = True
        map("tu") = True
        map("he") = True
        map("wu") = True
        map("hu") = True
        map("le") = True
        map("ju") = True
        map("ne") = True
        map("lu") = True
        map("mu") = True
        map("che") = True
        map("ou") = True
        map("ce") = True
        map("de") = True
        map("bu") = True
        map("cu") = True
        map("du") = True
        map("fu") = True
        map("gu") = True
        map("niang") = True
        map("rui") = True
        map("tui") = True
        map("hui") = True
        map("zhen") = True
        map("bo") = True
        map("xue") = True
        map("yue") = True
        map("shen") = True
        map("cui") = True
        map("dui") = True
        map("gui") = True
        map("que") = True
        map("chen") = True
        map("chan") = True
        map("lue") = True
        map("er") = True
        map("zun") = True
        map("kuang") = True
        map("run") = True
        map("sun") = True
        map("tun") = True
        map("pa") = True
        map("hun") = True
        map("zha") = True
        map("cheng") = True
        map("lun") = True
        map("sha") = True
        map("po") = True
        map("ma") = True
        map("ro") = True
        map("so") = True
        map("to") = True
        map("wo") = True
        map("ho") = True
        map("zhao") = True
        map("ko") = True
        map("lo") = True
        map("mo") = True
        map("cha") = True
        map("chua") = True
        map("ao") = True
        map("shao") = True
        map("fo") = True
        map("go") = True
        map("hen") = True
        map("chao") = True
        map("kong") = True
        map("shuang") = True
        map("zhan") = True
        map("den") = True
        map("zai") = True
        map("shan") = True
        map("pai") = True
        map("zhou") = True
        map("sai") = True
        map("tai") = True
        map("wai") = True
        map("yan") = True
        map("zan") = True
        map("shou") = True
        map("kai") = True
        map("lai") = True
        map("mai") = True
        map("nai") = True
        map("pan") = True
        map("zeng") = True
        map("bai") = True
        map("tan") = True
        map("dai") = True
        map("wan") = True
        map("gai") = True
        map("reng") = True
        map("chou") = True
        map("lan") = True
        map("man") = True
        map("nan") = True
        map("weng") = True
        map("heng") = True
        map("ban") = True
        map("keng") = True
        map("leng") = True
        map("meng") = True
        map("fan") = True
        map("gan") = True
        map("beng") = True
        map("ceng") = True
        map("deng") = True
        map("xuan") = True
        map("geng") = True
        map("zuan") = True
        map("gua") = True
        map("qiong") = True
        map("chang") = True
        map("suan") = True
        map("tuan") = True
        map("xi") = True
        map("yi") = True
        map("zi") = True
        map("huan") = True
        map("juan") = True
        map("kuan") = True
        map("luan") = True
        map("pi") = True
        map("qi") = True
        map("ri") = True
        map("si") = True
        map("ti") = True
        map("cuan") = True
        map("duan") = True
        map("guan") = True
        map("ki") = True
        map("li") = True
        map("mi") = True
        map("ni") = True
        map("kua") = True
        map("ai") = True
        map("bi") = True
        map("ci") = True
        map("di") = True
        map("ei") = True
        map("gi") = True
        map("hua") = True
        map("te") = True
        map("liang") = True
        map("nin") = True
        map("yang") = True
        map("ke") = True
        map("me") = True
        map("xie") = True
        map("sang") = True
        map("pie") = True
        map("qie") = True
        map("ge") = True
        map("tie") = True
        map("jie") = True
        map("tang") = True
        map("lie") = True
        map("yong") = True
        map("nie") = True
        map("eng") = True
        map("hang") = True
        map("lv") = True
        map("bie") = True
        map("nv") = True
        map("die") = True
        map("chuai") = True
        map("rong") = True
        map("song") = True
        map("tong") = True
        map("hong") = True
        map("mang") = True
        map("long") = True
        map("nong") = True
        map("cong") = True
        map("dong") = True
        map("gong") = True
        map("zheng") = True
        map("zhi") = True
        map("jiang") = True
        map("qiang") = True
        map("xia") = True
        map("shi") = True
        map("lve") = True
        map("nve") = True
        map("chi") = True
        map("jia") = True
        map("dia") = True
        map("yuan") = True
        map("x") = True
        map("quan") = True
        map("ruan") = True
        map("zui") = True
        map("pei") = True
        map("p") = True
        map("sei") = True
        map("zhuan") = True
        map("qia") = True
        map("sui") = True
        map("wei") = True
        map("hei") = True
        map("zen") = True
        map("xun") = True
        map("yun") = True
        map("lei") = True
        map("mei") = True
        map("nei") = True
        map("xiao") = True
        map("lia") = True
        map("o") = True
        map("bei") = True
        map("a") = True
        map("dei") = True
        map("shua") = True
        map("wen") = True
        map("e") = True
        map("qiao") = True
        map("g") = True
        map("ping") = True
        map("qing") = True
        map("jun") = True
        map("kun") = True
        map("ting") = True
        map("nun") = True
        map("jiao") = True
        map("cen") = True
        map("liao") = True
        map("jing") = True
        map("cun") = True
        map("ling") = True
        map("ming") = True
        map("ning") = True
        map("gun") = True
        map("guang") = True
        map("diao") = True
        map("bing") = True
        map("xian") = True
        map("ding") = True
        map("w") = True
        map("ong") = True
        map("zhang") = True
        map("ang") = True
        map("k") = True
        map("zhu") = True
        map("qian") = True
        map("n") = True
        map("tian") = True
        map("b") = True
        map("shu") = True
        map("jian") = True
        map("lian") = True
        map("peng") = True
        map("nian") = True
        map("seng") = True
        map("teng") = True
        map("bian") = True
        map("zhuo") = True
        map("dian") = True
        map("chu") = True
        map("shuo") = True
        map("ben") = True
        map("zhei") = True
        map("shuan") = True
        map("feng") = True
        map("j") = True
        map("ch") = True
        map("shei") = True
        map("chuo") = True
        map("zhun") = True
        map("c") = True
        map("d") = True
        map("f") = True
        map("shun") = True
        map("hai") = True
        map("chun") = True
        map("cai") = True
        map("se") = True
        map("we") = True
        map("xiang") = True
        map("chong") = True
        map("pian") = True
        map("ku") = True
        map("nu") = True
        map("mian") = True
        map("sheng") = True
        map("tei") = True
        map("nuan") = True
        map("ran") = True
        map("san") = True
        map("han") = True
        map("chuan") = True
        map("niu") = True
        map("kan") = True
        map("yao") = True
        map("zao") = True
        map("dan") = True
        map("kui") = True
        map("zhai") = True
        map("pao") = True
        map("rao") = True
        map("sao") = True
        map("tao") = True
        map("shai") = True
        map("hao") = True
        map("kao") = True
        map("lao") = True
        map("mao") = True
        map("nao") = True
        map("bao") = True
        map("you") = True
        map("zou") = True
        map("chai") = True
        map("gao") = True
        map("pou") = True
        map("rou") = True
        map("sou") = True
        map("tou") = True
        map("hou") = True
        map("xin") = True
        map("yin") = True
        map("kou") = True
        map("lou") = True
        map("mou") = True
        map("nou") = True

        Return map.ContainsKey(py.ToLower)
    End Function

#End Region

    Private Sub BtnCloseServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCloseServer.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim server As Object = CreateObject("DdpySrv.ComClass")
            server.Close()
            MsgBox("后台服务程序已关闭 （需要时会自行启动）", MsgBoxStyle.Information, "淡定")
        Catch ex As Exception
        Finally
            Cursor = Cursors.Arrow
        End Try


    End Sub

    Private Sub ChkAn_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ChkAn.MouseClick, ChkEn.MouseClick, ChkIn.MouseClick, ChkSrvMemory.MouseClick, ChkVshow.MouseClick, ChkZhizhe.MouseClick, ChkZize.MouseClick, ChkZzh.MouseClick, ChkHideStatus.MouseClick, ChkAutoPosition.MouseClick, ChkRiRe.MouseClick, ChkCandLimit.MouseClick, ChkAddFirstWordIdx.MouseClick, ChkAutoCreateWord.MouseClick, ChkIMode.MouseClick, ChkShowInfoWin.MouseClick, ChkAutoShowPyTextInfo.MouseClick, ChkYuanYan.MouseClick

        NumCandLimit.Enabled = ChkCandLimit.Checked

        If GetSetting().Equals(sSrvSetting) Then
            BtnApply.Enabled = False
        Else
            BtnApply.Enabled = True
        End If
    End Sub

    Private Sub TxtFont_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCandFont.TextChanged, TxtTitle.TextChanged, TxtInfoFont.TextChanged
        If GetSetting().Equals(sSrvSetting) Then
            BtnApply.Enabled = False
        Else
            BtnApply.Enabled = True
        End If
    End Sub

    Private Sub NumPageCnt_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumPageCnt.ValueChanged, NumPyLen.ValueChanged, NumCandLimit.ValueChanged, NumMaxExtsHeight.ValueChanged, NumMaxExtsWidth.ValueChanged
        If GetSetting().Equals(sSrvSetting) Then
            BtnApply.Enabled = False
        Else
            BtnApply.Enabled = True
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If keyData = Keys.F12 Then
            CopyFromScreen(Me)
            Return True
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub BtnFontExtsInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFontExtsInfo.Click
        Try
            Dim sFont As String() = Strings.Split(TxtInfoFont.Text, ",")
            Dim sName As String = sFont(0)
            Dim iSize As Single = sFont(1)
            Dim iStyle As FontStyle = sFont(2)

            FontDlgCand.Font = New Font(sName, iSize, iStyle)
        Catch ex As Exception
            FontDlgCand.Font = New Font("宋体", 12, FontStyle.Regular)
        End Try

        If FontDlgCand.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TxtInfoFont.Text = FontDlgCand.Font.Name & "," & FontDlgCand.Font.Size & "," & FontDlgCand.Font.Style
        End If
    End Sub
End Class
