''' <summary>
''' 拼音比较模块
''' </summary>
Module MPinYinMatch

    ''' <summary>
    ''' 比较单字拼音
    ''' </summary>
    ''' <param name="cd">拼音编码</param>
    ''' <param name="shotCd">简拼</param>
    ''' <param name="py">全拼</param>
    ''' <returns>比较结果</returns>
    Private Function MatchSinglePinYin(ByVal cd As String, ByVal shotCd As String, ByVal py As String) As Boolean

        Dim sCd As String = cd
        Dim sPy As String = py

        ' z=zh, c=ch, s=sh
        If P_ZCS_ZHCHSH Then
            If sCd.StartsWith("zh") OrElse sCd.StartsWith("ch") OrElse sCd.StartsWith("sh") Then
                sCd = Strings.Left(sCd, 1) & sCd.Substring(2)
            End If
            If sPy.StartsWith("zh") OrElse sPy.StartsWith("ch") OrElse sPy.StartsWith("sh") Then
                sPy = Strings.Left(sPy, 1) & sPy.Substring(2)
            End If
        End If

        ' zi=ze, ci=ce, si=se
        If P_ZHICHISHI_ZHECHESHE Then
            If sCd.Equals("zhe") OrElse sCd.Equals("che") OrElse sCd.Equals("she") Then
                sCd = Strings.Left(sCd, 2) & "i"
            End If
            If sPy.Equals("zhe") OrElse sPy.Equals("che") OrElse sPy.Equals("she") Then
                sPy = Strings.Left(sPy, 2) & "i"
            End If
        End If

        ' zi=ze, ci=ce, si=se
        If P_ZICISI_ZECESE Then
            If sCd.Equals("ze") OrElse sCd.Equals("ce") OrElse sCd.Equals("se") Then
                sCd = Strings.Left(sCd, 1) & "i"
            End If
            If sPy.Equals("ze") OrElse sPy.Equals("ce") OrElse sPy.Equals("se") Then
                sPy = Strings.Left(sPy, 1) & "i"
            End If
        End If

        ' an=ang
        If P_AN_ANG Then
            If sCd.EndsWith("ang") Then
                sCd = Strings.Left(sCd, sCd.Length - 1)
            End If
            If sPy.EndsWith("ang") Then
                sPy = Strings.Left(sPy, sPy.Length - 1)
            End If
        End If
        ' en=eng
        If P_EN_ENG Then
            If sCd.EndsWith("eng") Then
                sCd = Strings.Left(sCd, sCd.Length - 1)
            End If
            If sPy.EndsWith("eng") Then
                sPy = Strings.Left(sPy, sPy.Length - 1)
            End If
        End If
        ' in=ing
        If P_IN_ING Then
            If sCd.EndsWith("ing") Then
                sCd = Strings.Left(sCd, sCd.Length - 1)
            End If
            If sPy.EndsWith("ing") Then
                sPy = Strings.Left(sPy, sPy.Length - 1)
            End If
        End If
        ' ri=re
        If P_RI_RE Then
            If sCd.Equals("re") Then
                sCd = "ri"
            End If
            If sPy.Equals("re") Then
                sPy = "ri"
            End If
        End If
        ' yuan=yan
        If P_YUAN_YAN Then
            If sCd.Equals("yuan") Then
                sCd = "yan"
            End If
            If sPy.Equals("yuan") Then
                sPy = "yan"
            End If
        End If

        ' 比较
        If "a,o,e".Contains(Strings.Left(sCd, 1)) Then
            Return sPy.Equals(sCd)
        ElseIf sCd.Length > 1 Then
            Return sPy.Equals(sCd)
        Else
            Return sPy.StartsWith(sCd)
        End If

    End Function

    ''' <summary>
    ''' 比较多字拼音
    ''' </summary>
    ''' <param name="cds">拼音编码数组</param>
    ''' <param name="shotCds">简拼数组</param>
    ''' <param name="pys">全拼数组</param>
    ''' <returns>比较结果</returns>
    Public Function MatchMutilPinYin(ByVal cds As String(), ByVal shotCds As String(), ByVal pys As String(), ByVal text As String) As Boolean
        If cds.Length = 1 AndAlso cds(0).Length = 1 AndAlso text.Length > 1 Then
            Return False    ' 避免单个字母查出词语的情形，如x查出‘西安’
        End If


        For i As Integer = 0 To pys.Length - 1

            If Not MatchSinglePinYin(cds(i), shotCds(i), pys(i)) Then
                Return False
            End If
        Next

        Return True
    End Function

End Module
