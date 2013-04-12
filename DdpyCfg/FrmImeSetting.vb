Imports Microsoft.Win32

''' <summary>
''' 淡定拼音输入法配置窗口
''' </summary>
Public Class FrmSetting

    ''' <summary>
    ''' 初始化
    ''' </summary>
    Private Sub FrmSetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Dim server = CreateObject("DdpySrv.ComClass")
            Dim ary As String() = server.SrvGetSettingInfo().Split(vbTab)

            ChkAn.Checked = CBool(ary(0))
            ChkEn.Checked = CBool(ary(1))
            ChkIn.Checked = CBool(ary(2))
            ChkZzh.Checked = CBool(ary(3))
            ChkZize.Checked = CBool(ary(4))
            ChkZhizhe.Checked = CBool(ary(5))

            NumPyLen.Value = CInt(ary(6))
            NumPageCnt.Value = CInt(ary(7))

            ChkVshow.Checked = CBool(ary(8))

            TxtTitle.Text = CStr(ary(9))

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 设定
    ''' </summary>
    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        Try

            Dim server = CreateObject("DdpySrv.ComClass")

            Dim lst As New ArrayList
            lst.Add(ChkAn.Checked)
            lst.Add(ChkEn.Checked)
            lst.Add(ChkIn.Checked)
            lst.Add(ChkZzh.Checked)
            lst.Add(ChkZize.Checked)
            lst.Add(ChkZhizhe.Checked)

            lst.Add(NumPyLen.Value)
            lst.Add(NumPageCnt.Value)

            lst.Add(ChkVshow.Checked)

            lst.Add(Trim(TxtTitle.Text))

            server.SrvSetSettingInfo(Strings.Join(lst.ToArray, vbTab))

            MsgBox("设定成功                ", MsgBoxStyle.Information, "确认信息")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 关闭
    ''' </summary>
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

End Class
