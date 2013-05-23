Imports System.Text

Public Class FrmTest


    Private Sub FrmTest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DebugTimeStart()
        Try
            ' 读写配置文件
            Dim sFileCfg As String = My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData & "\\淡定配置.txt"
            If Not My.Computer.FileSystem.FileExists(sFileCfg) Then
                My.Computer.FileSystem.WriteAllText(sFileCfg, GetSettingInfo(), False, Encoding.UTF8)
            Else
                SetSettingInfo(My.Computer.FileSystem.ReadAllText(sFileCfg, Encoding.UTF8))
            End If


            ' 初始化字库词库
            ImportDanDingFile()
            InitMixInputFile()

        Catch ex As Exception
            ComError("New()", ex)
        Finally
            ComDebug("初始化时间共: " & DebugTimeEnd() & " 毫秒")
        End Try
    End Sub


    ''' <summary>
    ''' 指定拼音编码查找候选文字
    ''' </summary>
    ''' <param name="codes">拼音编码</param>
    ''' <returns>候选文字列表</returns>
    Public Function SrvSearchWords(ByVal codes As String) As String
        Try
            Dim ret As String = ""

            Dim okPys As String = BreakPys(codes).Split(" ")(0)  ' Get Right Py Only
            Dim aryPy As String() = okPys.Split("'")

            Dim stack As New Stack(Of List(Of CWord))
            Dim py As String = ""
            For i As Integer = 0 To aryPy.Length - 1
                If i = 0 Then
                    py = aryPy(i)
                Else
                    py = py & "'" & aryPy(i)
                End If

                Dim tmp As List(Of CWord) = SearchWords(py)
                If tmp.Count > 0 Then
                    stack.Push(tmp)
                End If
            Next


            Dim lst As New List(Of CWord)
            Dim wordRecom As CWord = GetRecommendWord(aryPy)
            If Not wordRecom Is Nothing Then
                lst.Add(wordRecom)
            End If
            Do While stack.Count > 0
                lst.AddRange(stack.Pop())
            Loop


            ' 拼接成字符串作为结果返回给客户端
            Dim buf As New StringBuilder
            For i As Integer = 0 To lst.Count - 1
                If i = 0 Then
                    buf.Append(lst(i).ToString)
                Else
                    buf.Append(vbLf & lst(i).ToString)
                End If
            Next

            Return buf.ToString

        Catch ex As Exception
            ComError("SrvSearchWords(" & codes & ")", ex)
            Return ""
        End Try
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ddd As String = BreakPys(TextBox1.Text)
        Dim sss As String = SrvSearchWords(TextBox1.Text)

        Dim lst As New List(Of CWord)

        Dim lines As String() = sss.Split(vbLf)
        For i As Integer = 0 To lines.Length - 1
            lst.Add(New CWord(lines(i)))
        Next




    End Sub
End Class