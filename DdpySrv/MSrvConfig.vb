Imports System.Text

''' <summary>
''' 输入法配置模块
''' </summary>
Module MSrvConfig

    ''' <summary>
    ''' 模糊音标志 an=ang
    ''' </summary>
    Friend P_AN_ANG As Boolean = False

    ''' <summary>
    ''' 模糊音标志 en=eng
    ''' </summary>
    Friend P_EN_ENG As Boolean = True

    ''' <summary>
    ''' 模糊音标志 in=ing
    ''' </summary>
    Friend P_IN_ING As Boolean = True

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
    ''' 能输入的拼音最大长度
    ''' </summary>
    Private P_MAX_PY_LEN As Integer = 30

    ''' <summary>
    ''' 每页最大候选件数
    ''' </summary>
    Private P_MAX_PAGE_CNT As Integer = 9

    ''' <summary>
    ''' 是否垂直显示
    ''' </summary>
    Private P_V_SHOW As Boolean = False

    ''' <summary>
    ''' 输入法窗口标题
    ''' </summary>
    Private P_TITLE As String = ""

    Friend P_MEMORY As Boolean = False

    ''' <summary>
    ''' 取得输入法配置信息
    ''' </summary>
    ''' <returns>输入法配置信息</returns>
    Public Function GetSettingInfo() As String
        Dim lst As New ArrayList

        lst.Add(P_AN_ANG)
        lst.Add(P_EN_ENG)
        lst.Add(P_IN_ING)
        lst.Add(P_ZCS_ZHCHSH)
        lst.Add(P_ZICISI_ZECESE)
        lst.Add(P_ZHICHISHI_ZHECHESHE)

        lst.Add(P_MAX_PY_LEN)
        lst.Add(P_MAX_PAGE_CNT)

        lst.Add(P_V_SHOW)

        lst.Add(P_TITLE)

        lst.Add(P_MEMORY)

        Return Strings.Join(lst.ToArray, vbTab)
    End Function

    ''' <summary>
    ''' 设定输入法配置
    ''' </summary>
    ''' <param name="conf">输入法配置信息</param>
    Public Sub SetSettingInfo(ByVal conf As String)
        Try
            Dim ary As String() = conf.Split(vbTab)

            P_AN_ANG = CBool(ary(0))
            P_EN_ENG = CBool(ary(1))
            P_IN_ING = CBool(ary(2))
            P_ZCS_ZHCHSH = CBool(ary(3))
            P_ZICISI_ZECESE = CBool(ary(4))
            P_ZHICHISHI_ZHECHESHE = CBool(ary(5))

            P_MAX_PY_LEN = CInt(ary(6))
            P_MAX_PAGE_CNT = CInt(ary(7))

            P_V_SHOW = CBool(ary(8))

            P_TITLE = CStr(ary(9))
            P_MEMORY = CBool(ary(10))

            ' 保存配置信息
            Dim sFileCfg As String = My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData & "\\DanDingConfig.txt"
            My.Computer.FileSystem.WriteAllText(sFileCfg, GetSettingInfo(), False, Encoding.UTF8)

        Catch ex As Exception
            ComError("SetSettingInfo(" & conf & ")失败。配置文件恢复成默认配置", ex)

            ' 保存默认配置信息
            Dim sFileCfg As String = My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData & "\\DanDingConfig.txt"
            My.Computer.FileSystem.WriteAllText(sFileCfg, GetSettingInfo(), False, Encoding.UTF8)
        End Try

    End Sub


End Module
