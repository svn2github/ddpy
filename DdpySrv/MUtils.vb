Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions

Module MUtils

    <Extension()> _
    Public Function IsBlank(ByVal aString As String) As Boolean
        Return (aString Is Nothing) OrElse (aString.Trim().Length = 0)
    End Function

    ''' <summary>
    ''' 取得右端Trim处理后的字符串
    ''' （Nothing处理后返回String.Empty）
    ''' </summary>
    ''' <param name="aString">String对象本身</param>
    ''' <returns>右端Trim处理后的字符串</returns>
    <Extension()> _
    Public Function TrimR(ByVal aString As String) As String
        Return Strings.RTrim(aString)
    End Function

    ''' <summary>
    ''' 取得左端Trim处理后的字符串
    ''' （Nothing处理后返回String.Empty）
    ''' </summary>
    ''' <param name="aString">String对象本身</param>
    ''' <returns>Strings.LTrim处理后的字符串</returns>
    <Extension()> _
    Public Function TrimL(ByVal aString As String) As String
        Return Strings.LTrim(aString)
    End Function

    ''' <summary>
    ''' 使用Strings.Left，从字符串左边截取指定文字数的字符串
    ''' （Nothing处理后返回String.Empty）
    ''' </summary>
    ''' <param name="aString">String对象本身</param>
    ''' <param name="iLen">要截取的文字数长度</param>
    ''' <returns>Strings.Left处理后的字符串</returns>
    <Extension()> _
    Public Function Left(ByVal aString As String, ByVal iLen As Integer) As String
        Return Strings.Left(aString, iLen)
    End Function

    ''' <summary>
    ''' 使用Strings.Right，从字符串右边截取指定文字数的字符串
    ''' （Nothing处理后返回String.Empty）
    ''' </summary>
    ''' <param name="aString">String对象本身</param>
    ''' <param name="iLen">要截取的文字数长度</param>
    ''' <returns>Strings.Right处理后的字符串</returns>
    <Extension()> _
    Public Function Right(ByVal aString As String, ByVal iLen As Integer) As String
        Return Strings.Right(aString, iLen)
    End Function

    ''' <summary>
    ''' 判断是否为半角数字
    ''' </summary>
    ''' <param name="aString">String对象本身</param>
    ''' <param name="acceptNullOrEmpty">True：Nothing或空白时返回Ture、False：Nothing或空串时返回False</param>
    ''' <returns>True：半角数字</returns>
    <Extension()> _
    Public Function IsHalfDigit(ByVal aString As String, _
                                  Optional ByVal acceptNullOrEmpty As Boolean = False) As Boolean
        If String.IsNullOrEmpty(aString) Then
            Return acceptNullOrEmpty
        End If
        Return Regex.IsMatch(aString, "^[0-9]+$")
    End Function

    ''' <summary>
    ''' 判断是否为半角英文字母
    ''' </summary>
    ''' <param name="aString">String对象本身</param>
    ''' <param name="acceptNullOrEmpty">True：Nothing或空白时返回Ture、False：Nothing或空串时返回False</param>
    ''' <returns>True：半角英文字母</returns>
    <Extension()> _
    Public Function IsHalfAlpha(ByVal aString As String, _
                                  Optional ByVal acceptNullOrEmpty As Boolean = False) As Boolean
        If String.IsNullOrEmpty(aString) Then
            Return acceptNullOrEmpty
        End If
        Return Regex.IsMatch(aString, "^[a-zA-Z]+$")
    End Function

    ''' <summary>
    ''' 判断是否为半角英数
    ''' </summary>
    ''' <param name="aString">String对象本身</param>
    ''' <param name="acceptNullOrEmpty">True：Nothing或空白时返回Ture、False：Nothing或空串时返回False</param>
    ''' <returns>True：半角英数</returns>
    <Extension()> _
    Public Function IsHalfAlphaDigit(ByVal aString As String, _
                                  Optional ByVal acceptNullOrEmpty As Boolean = False) As Boolean
        If String.IsNullOrEmpty(aString) Then
            Return acceptNullOrEmpty
        End If
        Return Regex.IsMatch(aString, "^[0-9a-zA-Z]+$")
    End Function

    Private mapChar As New Hashtable
    <Extension()> _
    Public Function ToStringArray(ByVal aString As String) As String()
        Dim lst As New List(Of String)

        If aString = Nothing Then
            Return lst.ToArray()
        End If

        Dim sTmp As String
        For i As Integer = 0 To aString.Length - 1
            sTmp = aString.Substring(i, 1)
            If Not mapChar.ContainsKey(sTmp) Then
                mapChar(sTmp) = sTmp
            End If

            lst.Add(mapChar(sTmp))
        Next

        Return lst.ToArray()
    End Function

    <Extension()> _
    Public Function Join(ByVal aString As String(), Optional ByVal delimiter As String = "") As String
        Dim lst As New List(Of String)

        If aString Is Nothing Then
            Return String.Empty
        End If

        Return Strings.Join(aString, delimiter)
    End Function

End Module
