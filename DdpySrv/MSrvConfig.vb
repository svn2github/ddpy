﻿Imports System.Text

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
    ''' 模糊音标志 ri=re
    ''' </summary>
    Friend P_RI_RE As Boolean = True

    ''' <summary>
    ''' 模糊音标志 yuan=yan
    ''' </summary>
    Friend P_YUAN_YAN As Boolean = True

    ''' <summary>
    ''' 能输入的拼音最大长度
    ''' </summary>
    Private P_MAX_PY_LEN As Integer = 50

    ''' <summary>
    ''' 每页最大候选件数
    ''' </summary>
    Friend P_MAX_PAGE_CNT As Integer = 9

    ''' <summary>
    ''' 是否垂直显示
    ''' </summary>
    Private P_V_SHOW As Boolean = False

    ''' <summary>
    ''' 输入法窗口标题
    ''' </summary>
    Private P_TITLE As String = ""

    Friend P_MEMORY As Boolean = False

    Private P_FONT As String = "宋体,12,0"

    Private P_HIDE_STATUS As Boolean = False
    Private P_AUTO_POSITION As Boolean = True

    Friend P_CAND_LIMIT As Boolean = True
    Friend P_CAND_LIMIT_NUM As Integer = 30

    Friend P_ADD_FIRST_WORD_IDX As Boolean = False
    Friend P_AUTO_CREATE_WORD As Boolean = True

    Friend P_I_MODE As Boolean = True

    Private P_SHOW_INFO As Boolean = False
    Private P_FONT_INFO_WIN As String = "宋体,12,0"
    Private P_SHOW_INFO_WITH_PY_TEXT As Boolean = False
    Private P_MAX_EXTS_WIN_WIDTH As Integer = 530
    Private P_MAX_EXTS_WIN_HEIGHT As Integer = 300

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
        lst.Add(P_RI_RE)

        lst.Add(P_MAX_PY_LEN)
        lst.Add(P_MAX_PAGE_CNT)

        lst.Add(P_V_SHOW)

        lst.Add(P_TITLE)

        lst.Add(P_MEMORY)

        lst.Add(P_FONT)
        lst.Add(P_HIDE_STATUS)
        lst.Add(P_AUTO_POSITION)

        lst.Add(P_CAND_LIMIT)
        lst.Add(P_CAND_LIMIT_NUM)
        lst.Add(P_ADD_FIRST_WORD_IDX)
        lst.Add(P_AUTO_CREATE_WORD)
        lst.Add(P_I_MODE)

        lst.Add(P_SHOW_INFO)
        lst.Add(P_FONT_INFO_WIN)
        lst.Add(P_SHOW_INFO_WITH_PY_TEXT)
        lst.Add(P_MAX_EXTS_WIN_WIDTH)
        lst.Add(P_MAX_EXTS_WIN_HEIGHT)

        lst.Add(P_YUAN_YAN)

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
            P_RI_RE = CBool(ary(6))

            P_MAX_PY_LEN = CInt(ary(7))
            P_MAX_PAGE_CNT = CInt(ary(8))

            P_V_SHOW = CBool(ary(9))

            P_TITLE = CStr(ary(10))
            P_MEMORY = CBool(ary(11))
            P_FONT = CStr(ary(12))
            P_HIDE_STATUS = CBool(ary(13))
            P_AUTO_POSITION = CBool(ary(14))

            P_CAND_LIMIT = CBool(ary(15))
            P_CAND_LIMIT_NUM = CInt(ary(16))
            P_ADD_FIRST_WORD_IDX = CBool(ary(17))
            P_AUTO_CREATE_WORD = CBool(ary(18))
            P_I_MODE = CBool(ary(19))

            P_SHOW_INFO = CBool(ary(20))
            P_FONT_INFO_WIN = CStr(ary(21))
            P_SHOW_INFO_WITH_PY_TEXT = CBool(ary(22))
            P_MAX_EXTS_WIN_WIDTH = CInt(ary(23))
            P_MAX_EXTS_WIN_HEIGHT = CInt(ary(24))

            P_YUAN_YAN = CBool(ary(25))

            ' 保存配置信息
            My.Computer.FileSystem.WriteAllText(GetDdpyConfigFile(), GetSettingInfo(), False, Encoding.UTF8)

        Catch ex As Exception
            ' ComError("SetSettingInfo(" & conf & ")失败。配置文件恢复成默认配置", ex)

            ' 保存默认配置信息
            My.Computer.FileSystem.WriteAllText(GetDdpyConfigFile(), GetSettingInfo(), False, Encoding.UTF8)
        End Try

    End Sub


End Module
