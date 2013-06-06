Imports System.Text
Imports System.Drawing

''' <summary>
''' 输入法配置模块
''' </summary>
Module MConfig

    ''' <summary>
    ''' 模糊音标志 an=ang
    ''' </summary>
    Friend P_AN_ANG As Boolean = True

    ''' <summary>
    ''' 模糊音标志 in=ing
    ''' </summary>
    Friend P_IN_ING As Boolean = True

    ''' <summary>
    ''' 模糊音标志 en=eng
    ''' </summary>
    Friend P_EN_ENG As Boolean = True

    ''' <summary>
    ''' 模糊音标志 z=zh, c=ch, s=sh
    ''' </summary>
    Friend P_ZCS_ZHCHSH As Boolean = True

    ''' <summary>
    ''' 模糊音标志 zi=ze, ci=ce, si=se
    ''' </summary>
    Friend P_ZICISI_ZECESE As Boolean = True

    ''' <summary>
    ''' 模糊音标志 zhi=zhe, chi=che, shi=she
    ''' </summary>
    Friend P_ZHICHISHI_ZHECHESHE As Boolean = True

    ''' <summary>
    ''' 模糊音标志 ri=re
    ''' </summary>
    Friend P_RI_RE As Boolean = True


    ''' <summary>
    ''' 中文模式
    ''' </summary>
    Friend P_LNG_CN As Boolean = True

    ''' <summary>
    ''' 全角模式
    ''' </summary>
    Friend P_MODE_FULL As Boolean = False

    ''' <summary>
    ''' 标点模式
    ''' </summary>
    Friend P_BD_FULL As Boolean = True

    ''' <summary>
    ''' 能输入的拼音最大长度
    ''' </summary>
    Friend P_MAX_PY_LEN As Integer = 30

    ''' <summary>
    ''' 每页最大候选件数
    ''' </summary>
    Friend P_MAX_PAGE_CNT As Integer = 9

    ''' <summary>
    ''' 是否垂直显示
    ''' </summary>
    Friend P_V_SHOW As Boolean = False

    ''' <summary>
    ''' 输入法窗口标题
    ''' </summary>
    Friend P_TITLE As String = ""



    ''' <summary>
    ''' 系统告知的焦点X坐标
    ''' </summary>
    Friend PosX As Integer = 0

    ''' <summary>
    ''' 系统告知的焦点Y坐标
    ''' </summary>
    Friend PosY As Integer = 0

    ''' <summary>
    ''' 系统告知的焦点字体高度
    ''' </summary>
    Friend PosH As Integer = 0


    Private lstApp As List(Of String)
    Friend fontCand As New Font("宋体", 12, FontStyle.Regular)
    Friend P_HIDE_STATUS As Boolean = False
    Friend P_AUTO_POSITION As Boolean = True

    Friend P_ADD_FIRST_WORD_IDX As Boolean = False
    Friend P_AUTO_CREATE_WORD As Boolean = True
    Friend P_I_MODE As Boolean = True

    ''' <summary>
    ''' 取得最新配置信息
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub UpdateSettingInfo()
        Try
            Dim server = CreateObject("DdpySrv.ComClass")
            Dim ary As String() = server.SrvGetSettingInfo().Split(vbTab)

            P_AN_ANG = CBool(ary(0))
            P_EN_ENG = CBool(ary(1))
            P_IN_ING = CBool(ary(2))
            P_ZCS_ZHCHSH = CBool(ary(3))
            P_ZICISI_ZECESE = CBool(ary(4))
            P_ZHICHISHI_ZHECHESHE = CBool(ary(5))
            P_RI_RE = CBool(ary(6))

            P_MAX_PY_LEN = CInt(ary(7))
            P_MAX_PAGE_CNT = CInt(ary(8))

            P_V_SHOW = CBool(ary(9))

            P_TITLE = CStr(ary(10))
            ' 11: Memory
            Dim sFont As String() = Strings.Split(ary(12), ",")
            Dim sFontName As String = sFont(0)
            Dim sFontSize As Single = sFont(1)
            Dim sFontStyle As FontStyle = sFont(2)
            fontCand = New Font(sFontName, sFontSize, sFontStyle)

            P_HIDE_STATUS = CBool(ary(13))
            P_AUTO_POSITION = CBool(ary(14))
            ' 15 是否限制非单字候选个数
            ' 16 限制非单字候选个数值
            P_ADD_FIRST_WORD_IDX = CBool(ary(17))
            P_AUTO_CREATE_WORD = CBool(ary(18))
            P_I_MODE = CBool(ary(19))

        Catch ex As Exception
            ComDebug(ex)
        End Try

    End Sub

    ''' <summary>
    ''' 打开输入法配置窗口
    ''' </summary>
    Friend Sub OpenSettingDlg()
        Try
            Dim info As New System.Diagnostics.ProcessStartInfo
            info.FileName = SvrGetDdpyCfgExePath()
            System.Diagnostics.Process.Start(info)
        Catch ex As Exception
            ComDebug(ex)
        End Try
    End Sub


    Friend Function IsNeedSendStartEndMsg(ByVal appName As String) As Boolean

        If lstApp Is Nothing Then
            lstApp = New List(Of String)

            lstApp.Add("devenv")   ' VS
            lstApp.Add("firefox")  ' firefox
            lstApp.Add("WINWORD")  ' Word
            lstApp.Add("EXCEL")  ' Excel
            lstApp.Add("chrome")  ' Chrome
        End If

        For Each name As String In lstApp
            If name.Equals(appName & "", StringComparison.OrdinalIgnoreCase) Then
                Return True
            End If
        Next
        Return False
    End Function

End Module
