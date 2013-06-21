''' <summary>
''' 拼音分解模块
''' </summary>
Module MPinYinBreak

    Private mapPy As Hashtable

    ''' <summary>
    ''' 取得简拼连拼
    ''' </summary>
    ''' <param name="fullPys">全拼连拼（单引号分隔）</param>
    ''' <returns>简拼连拼（单引号分隔）</returns>
    Friend Function GetMutilShotPys(ByVal fullPys As String) As String()

        Dim pys As String() = fullPys.Split("'")

        For i As Integer = 0 To pys.Length - 1
            pys(i) = GetSingleShotPy(pys(i))
        Next

        Return pys
    End Function

    ''' <summary>
    ''' 取得简拼连拼
    ''' </summary>
    ''' <param name="fullPys">全拼连拼（单引号分隔）</param>
    ''' <returns>简拼连拼（单引号分隔）</returns>
    Friend Function GetMutilShotPys2(ByVal fullPys As String) As String()

        If Not P_ADD_FIRST_WORD_IDX Then
            Return GetMutilShotPys(fullPys)
        End If

        Dim pys As String() = fullPys.Split("'")

        For i As Integer = 0 To pys.Length - 1
            If i = 0 Then
                pys(i) = GetPinYinKey(pys(i))
            Else
                pys(i) = GetSingleShotPy(pys(i))
            End If
        Next

        Return pys
    End Function

    Private Function GetPinYinKey(ByVal singlePy As String) As String

        Dim sCd As String = singlePy

        ' zh,ch,sh -> z,c,s
        If sCd.StartsWith("zh") OrElse sCd.StartsWith("ch") OrElse sCd.StartsWith("sh") Then
            sCd = Strings.Left(sCd, 1) & sCd.Substring(2)
        End If

        ' ze,ce,se -> zi,ci,si
        If sCd.Equals("ze") OrElse sCd.Equals("ce") OrElse sCd.Equals("se") Then
            sCd = Strings.Left(sCd, 1) & "i"
        End If

        ' ang,eng,ing -> an,en,in
        If sCd.EndsWith("ang") OrElse sCd.EndsWith("eng") OrElse sCd.EndsWith("ing") Then
            sCd = Strings.Left(sCd, sCd.Length - 1)
        End If

        ' re -> ri
        If sCd.Equals("re") Then
            sCd = "ri"
        End If

        ' yuan -> yan
        If sCd.Equals("yuan") Then
            sCd = "yan"
        End If

        Return sCd
    End Function

    ''' <summary>
    ''' 取得单字简拼
    ''' </summary>
    ''' <param name="fullPy">单字全拼</param>
    ''' <returns>单字简拼</returns>
    Friend Function GetSingleShotPy(ByVal fullPy As String) As String

        Dim sRet As String = Strings.Left(fullPy, 1)

        If "a,o,e".Contains(sRet) Then
            sRet = fullPy
        End If

        ' 简拼 ang->an, eng->en 
        If "ang".Equals(sRet) OrElse "eng".Equals(sRet) Then
            sRet = Strings.Left(sRet, 2)
        End If

        Return sRet
    End Function


    ''' <summary>
    ''' 按字分解拼音
    ''' </summary>
    ''' <param name="inPys">连拼多字拼音</param>
    ''' <returns>单引号分隔的拼音串（误拼部分空格后连接）</returns>
    Friend Function BreakPys(ByVal inPys As String) As String

        If mapPy Is Nothing Then
            mapPy = GetRightWordPyMap()
        End If

        Dim lst As New List(Of String)

        Dim errPy As String = ""
        Dim wordPy As String
        Dim pyTmp As String = inPys
        Dim sPys As String() = inPys.Split("'")
        For i As Integer = 0 To sPys.Length - 1

            pyTmp = sPys(i)
            If pyTmp = "" Then
                errPy = "'"
            End If

            While (pyTmp <> "") AndAlso (errPy = "")

                wordPy = GetRightPy(pyTmp)
                If wordPy = "" Then
                    errPy = pyTmp
                    pyTmp = ""
                Else
                    lst.Add(wordPy)
                    pyTmp = pyTmp.Substring(wordPy.Replace("'", "").Length)
                End If

            End While

            If errPy.Length > 0 Then

                For j As Integer = i + 1 To sPys.Length - 1
                    errPy = errPy & "'" & sPys(j)
                Next

                ' Break For
                Exit For
            End If

        Next


        If errPy = "" Then
            Return Join(lst.ToArray(), "'")
        Else
            Return Join(lst.ToArray(), "'") & " " & errPy
        End If

    End Function


    Private mapCustBreakPy As Hashtable = Nothing
    Private mapStartWithNoEr As Hashtable = Nothing
    Private Function GetCustBreakPy(ByVal codes As String) As String
        If mapCustBreakPy Is Nothing Then
            mapCustBreakPy = New Hashtable
            mapStartWithNoEr = New Hashtable

            mapCustBreakPy("ani") = "a"
            mapCustBreakPy("anu") = "a"
            mapCustBreakPy("anv") = "a"
            mapCustBreakPy("angu") = "an"

            mapCustBreakPy("eni") = "e"
            mapCustBreakPy("enu") = "e"
            mapCustBreakPy("env") = "e"
            mapCustBreakPy("engu") = "en"

            mapCustBreakPy("eri") = "e"
            mapCustBreakPy("eru") = "e"


            mapCustBreakPy("quni") = "qu"
            mapCustBreakPy("qunu") = "qu"
            mapCustBreakPy("qunv") = "qu"
            mapCustBreakPy("qunan") = "qu"
            mapCustBreakPy("qunao") = "qu"
            mapCustBreakPy("qunong") = "qu"
            mapCustBreakPy("qunei") = "qu"
            mapCustBreakPy("qunen") = "qu"
            
            mapCustBreakPy("runi") = "ru"
            mapCustBreakPy("runu") = "ru"
            mapCustBreakPy("runv") = "ru"
            mapCustBreakPy("runan") = "ru"
            mapCustBreakPy("runao") = "ru"
            mapCustBreakPy("runong") = "ru"
            mapCustBreakPy("runei") = "ru"
            mapCustBreakPy("runen") = "ru"
            mapCustBreakPy("ruou") = "ru"


            mapCustBreakPy("tuni") = "tu"
            mapCustBreakPy("tunu") = "tu"
            mapCustBreakPy("tunv") = "tu"
            mapCustBreakPy("tunan") = "tu"
            mapCustBreakPy("tunao") = "tu"
            mapCustBreakPy("tunong") = "tu"
            mapCustBreakPy("tunei") = "tu"
            mapCustBreakPy("tunen") = "tu"
            mapCustBreakPy("tuou") = "tu"

            mapCustBreakPy("yuni") = "yu"
            mapCustBreakPy("yunu") = "yu"
            mapCustBreakPy("yunv") = "yu"
            mapCustBreakPy("yunan") = "yu"
            mapCustBreakPy("yunao") = "yu"
            mapCustBreakPy("yunong") = "yu"
            mapCustBreakPy("yunei") = "yu"
            mapCustBreakPy("yunen") = "yu"

            mapCustBreakPy("suni") = "su"
            mapCustBreakPy("sunu") = "su"
            mapCustBreakPy("sunv") = "su"
            mapCustBreakPy("sunan") = "su"
            mapCustBreakPy("sunao") = "su"
            mapCustBreakPy("sunong") = "su"
            mapCustBreakPy("sunei") = "su"
            mapCustBreakPy("sunen") = "su"
            mapCustBreakPy("suou") = "su"

            mapCustBreakPy("shuni") = "shu"
            mapCustBreakPy("shunu") = "shu"
            mapCustBreakPy("shunv") = "shu"
            mapCustBreakPy("shunan") = "shu"
            mapCustBreakPy("shunao") = "shu"
            mapCustBreakPy("shunong") = "shu"
            mapCustBreakPy("shunei") = "shu"
            mapCustBreakPy("shunen") = "shu"
            mapCustBreakPy("shuou") = "shu"

            mapCustBreakPy("duni") = "du"
            mapCustBreakPy("dunu") = "du"
            mapCustBreakPy("dunv") = "du"
            mapCustBreakPy("dunan") = "du"
            mapCustBreakPy("dunao") = "du"
            mapCustBreakPy("dunong") = "du"
            mapCustBreakPy("dunei") = "du"
            mapCustBreakPy("dunen") = "du"
            mapCustBreakPy("duou") = "du"

            mapCustBreakPy("guni") = "gu"
            mapCustBreakPy("gunu") = "gu"
            mapCustBreakPy("gunv") = "gu"
            mapCustBreakPy("gunan") = "gu"
            'mapCustBreakPy("gunao") = "gu"
            mapCustBreakPy("gunong") = "gu"
            mapCustBreakPy("gunei") = "gu"
            mapCustBreakPy("gunen") = "gu"
            mapCustBreakPy("guou") = "gu"

            mapCustBreakPy("huni") = "hu"
            mapCustBreakPy("hunu") = "hu"
            mapCustBreakPy("hunv") = "hu"
            'mapCustBreakPy("hunan") = "hu"
            mapCustBreakPy("hunao") = "hu"
            mapCustBreakPy("hunong") = "hu"
            mapCustBreakPy("hunei") = "hu"
            mapCustBreakPy("hunen") = "hu"
            mapCustBreakPy("huou") = "hu"

            mapCustBreakPy("juni") = "ju"
            mapCustBreakPy("junu") = "ju"
            mapCustBreakPy("junv") = "ju"
            mapCustBreakPy("junan") = "ju"
            mapCustBreakPy("junao") = "ju"
            mapCustBreakPy("junong") = "ju"
            mapCustBreakPy("junei") = "ju"
            mapCustBreakPy("junen") = "ju"

            mapCustBreakPy("kuni") = "ku"
            mapCustBreakPy("kunu") = "ku"
            mapCustBreakPy("kunv") = "ku"
            mapCustBreakPy("kunan") = "ku"
            mapCustBreakPy("kunao") = "ku"
            mapCustBreakPy("kunong") = "ku"
            mapCustBreakPy("kunei") = "ku"
            mapCustBreakPy("kunen") = "ku"
            mapCustBreakPy("kuou") = "ku"

            mapCustBreakPy("luni") = "lu"
            mapCustBreakPy("lunu") = "lu"
            mapCustBreakPy("lunv") = "lu"
            mapCustBreakPy("lunan") = "lu"
            mapCustBreakPy("lunao") = "lu"
            mapCustBreakPy("lunong") = "lu"
            mapCustBreakPy("lunei") = "lu"
            mapCustBreakPy("lunen") = "lu"
            mapCustBreakPy("luou") = "lu"

            mapCustBreakPy("zuni") = "zu"
            mapCustBreakPy("zunu") = "zu"
            mapCustBreakPy("zunv") = "zu"
            mapCustBreakPy("zunan") = "zu"
            mapCustBreakPy("zunao") = "zu"
            mapCustBreakPy("zunong") = "zu"
            mapCustBreakPy("zunei") = "zu"
            mapCustBreakPy("zunen") = "zu"
            mapCustBreakPy("zuou") = "zu"

            mapCustBreakPy("xuni") = "xu"
            mapCustBreakPy("xunu") = "xu"
            mapCustBreakPy("xunv") = "xu"
            mapCustBreakPy("xunan") = "xu"
            mapCustBreakPy("xunao") = "xu"
            mapCustBreakPy("xunong") = "xu"
            mapCustBreakPy("xunei") = "xu"
            mapCustBreakPy("xunen") = "xu"

            mapCustBreakPy("cuni") = "cu"
            mapCustBreakPy("cunu") = "cu"
            mapCustBreakPy("cunv") = "cu"
            mapCustBreakPy("cunan") = "cu"
            mapCustBreakPy("cunao") = "cu"
            mapCustBreakPy("cunong") = "cu"
            mapCustBreakPy("cunei") = "cu"
            mapCustBreakPy("cunen") = "cu"
            mapCustBreakPy("cuou") = "cu"

            mapCustBreakPy("chuni") = "chu"
            mapCustBreakPy("chunu") = "chu"
            mapCustBreakPy("chunv") = "chu"
            mapCustBreakPy("chunan") = "chu"
            mapCustBreakPy("chunao") = "chu"
            mapCustBreakPy("chunong") = "chu"
            mapCustBreakPy("chunei") = "chu"
            mapCustBreakPy("chunen") = "chu"
            mapCustBreakPy("chuou") = "chu"

            'mapCustBreakPy("qina") = "qi"
            'mapCustBreakPy("qinai") = "qi"
            mapCustBreakPy("qinao") = "qi"
            'mapCustBreakPy("qinan") = "qi"
            mapCustBreakPy("qinang") = "qi"
            'mapCustBreakPy("qino") = "qi"
            'mapCustBreakPy("qinou") = "qi"
            mapCustBreakPy("qinong") = "qi"
            mapCustBreakPy("qinei") = "qi"
            mapCustBreakPy("qinen") = "qi"
            'mapCustBreakPy("qineng") = "qi"
            mapCustBreakPy("qini") = "qi"
            mapCustBreakPy("qinu") = "qi"
            mapCustBreakPy("qinv") = "qi"

            'mapCustBreakPy("qinga") = "qin"
            'mapCustBreakPy("qingai") = "qin"
            mapCustBreakPy("qingao") = "qin"
            'mapCustBreakPy("qingan") = "qin"
            mapCustBreakPy("qingang") = "qin"
            'mapCustBreakPy("qingo") = "qin"
            'mapCustBreakPy("qingou") = "qin"
            mapCustBreakPy("qingong") = "qin"
            mapCustBreakPy("qingei") = "qin"
            mapCustBreakPy("qingen") = "qin"
            'mapCustBreakPy("qingeng") = "qin"
            mapCustBreakPy("qingu") = "qin"
            'mapCustBreakPy("qingun") = "qin"
            'mapCustBreakPy("qinguo") = "qin"
            'mapCustBreakPy("qingv") = "qin"
            'mapCustBreakPy("qingve") = "qin"


            'mapCustBreakPy("yina") = "yi"
            'mapCustBreakPy("yinai") = "yi"
            'mapCustBreakPy("yinao") = "yi"
            'mapCustBreakPy("yinan") = "yi"
            'mapCustBreakPy("yinang") = "yi"
            'mapCustBreakPy("yino") = "yi"
            'mapCustBreakPy("yinou") = "yi"
            mapCustBreakPy("yinong") = "yi"
            'mapCustBreakPy("yine") = "yi"
            mapCustBreakPy("yinei") = "yi"
            mapCustBreakPy("yinen") = "yi"
            mapCustBreakPy("yineng") = "yi"
            mapCustBreakPy("yini") = "yi"
            mapCustBreakPy("yinu") = "yi"
            mapCustBreakPy("yinv") = "yi"


            'mapCustBreakPy("yinga") = "yin"
            mapCustBreakPy("yingai") = "yin"
            mapCustBreakPy("yingao") = "yin"
            'mapCustBreakPy("yingan") = "yin"
            mapCustBreakPy("yingang") = "yin"
            'mapCustBreakPy("yingo") = "yin"
            mapCustBreakPy("yingou") = "yin"
            mapCustBreakPy("yingong") = "yin"
            mapCustBreakPy("yingei") = "yin"
            mapCustBreakPy("yingen") = "yin"
            'mapCustBreakPy("yingeng") = "yin"
            mapCustBreakPy("yingu") = "yin"
            'mapCustBreakPy("yingun") = "yin"
            'mapCustBreakPy("yinguo") = "yin"
            'mapCustBreakPy("yingv") = "yin"
            'mapCustBreakPy("yingve") = "yin"



            'mapCustBreakPy("pina") = "pi"
            'mapCustBreakPy("pinai") = "pi"
            'mapCustBreakPy("pinao") = "pi"
            'mapCustBreakPy("pinan") = "pi"
            'mapCustBreakPy("pinang") = "pi"
            'mapCustBreakPy("pino") = "pi"
            'mapCustBreakPy("pinou") = "pi"
            mapCustBreakPy("pinong") = "pi"
            mapCustBreakPy("pinei") = "pi"
            mapCustBreakPy("pinen") = "pi"
            'mapCustBreakPy("pineng") = "pi"
            mapCustBreakPy("pini") = "pi"
            mapCustBreakPy("pinu") = "pi"
            mapCustBreakPy("pinv") = "pi"


            'mapCustBreakPy("pinga") = "pin"
            'mapCustBreakPy("pingai") = "pin"
            'mapCustBreakPy("pingao") = "pin"
            'mapCustBreakPy("pingan") = "pin"
            mapCustBreakPy("pingang") = "pin"
            'mapCustBreakPy("pingo") = "pin"
            mapCustBreakPy("pingou") = "pin"
            mapCustBreakPy("pingong") = "pin"
            mapCustBreakPy("pingei") = "pin"
            mapCustBreakPy("pingen") = "pin"
            'mapCustBreakPy("pingeng") = "pin"
            mapCustBreakPy("pingu") = "pin"
            'mapCustBreakPy("pingun") = "pin"
            'mapCustBreakPy("pinguo") = "pin"
            'mapCustBreakPy("pingv") = "pin"
            'mapCustBreakPy("pingve") = "pin"



            'mapCustBreakPy("dina") = "di"
            'mapCustBreakPy("dinai") = "di"
            'mapCustBreakPy("dinao") = "di"
            'mapCustBreakPy("dinan") = "di"
            'mapCustBreakPy("dinang") = "di"
            'mapCustBreakPy("dino") = "di"
            'mapCustBreakPy("dinou") = "di"
            '   mapCustBreakPy("dinong") = "di"
            '  mapCustBreakPy("dine") = "di"
            'mapCustBreakPy("dinei") = "di"
            'mapCustBreakPy("dinen") = "di"
            'mapCustBreakPy("dineng") = "di"
            mapCustBreakPy("dini") = "di"
            mapCustBreakPy("dinu") = "di"
            mapCustBreakPy("dinv") = "di"


            'mapCustBreakPy("jina") = "ji"
            'mapCustBreakPy("jinai") = "ji"
            mapCustBreakPy("jinao") = "ji"
            'mapCustBreakPy("jinan") = "ji"
            'mapCustBreakPy("jinang") = "ji"
            'mapCustBreakPy("jino") = "ji"
            'mapCustBreakPy("jinou") = "ji"
            mapCustBreakPy("jinong") = "ji"
            'mapCustBreakPy("jine") = "ji"
            mapCustBreakPy("jinei") = "ji"
            mapCustBreakPy("jinen") = "ji"
            'mapCustBreakPy("jineng") = "ji"
            mapCustBreakPy("jini") = "ji"
            mapCustBreakPy("jinu") = "ji"
            mapCustBreakPy("jinv") = "ji"

            'mapCustBreakPy("jinga") = "jin"
            'mapCustBreakPy("jingai") = "jin"
            mapCustBreakPy("jingao") = "jin"
            mapCustBreakPy("jingan") = "jin"
            'mapCustBreakPy("jingang") = "jin"
            'mapCustBreakPy("jingo") = "jin"
            mapCustBreakPy("jingou") = "jin"
            mapCustBreakPy("jingong") = "jin"
            'mapCustBreakPy("jinge") = "jin"
            mapCustBreakPy("jingei") = "jin"
            mapCustBreakPy("jingen") = "jin"
            mapCustBreakPy("jingeng") = "jin"
            mapCustBreakPy("jingu") = "jin"
            'mapCustBreakPy("jingun") = "jin"
            'mapCustBreakPy("jinguo") = "jin"
            'mapCustBreakPy("jingv") = "jin"
            'mapCustBreakPy("jingve") = "jin"


            'mapCustBreakPy("lina") = "li"
            'mapCustBreakPy("linai") = "li"
            'mapCustBreakPy("linao") = "li"
            'mapCustBreakPy("linan") = "li"
            'mapCustBreakPy("linang") = "li"
            'mapCustBreakPy("lino") = "li"
            'mapCustBreakPy("linou") = "li"
            mapCustBreakPy("linong") = "li"
            mapCustBreakPy("linei") = "li"
            mapCustBreakPy("linen") = "li"
            'mapCustBreakPy("lineng") = "li"
            mapCustBreakPy("lini") = "li"
            mapCustBreakPy("linu") = "li"
            mapCustBreakPy("linv") = "li"

            'mapCustBreakPy("linga") = "lin"
            'mapCustBreakPy("lingai") = "lin"
            mapCustBreakPy("lingao") = "lin"
            mapCustBreakPy("lingan") = "lin"
            'mapCustBreakPy("lingang") = "lin"
            'mapCustBreakPy("lingo") = "lin"
            mapCustBreakPy("lingou") = "lin"
            mapCustBreakPy("lingong") = "lin"
            mapCustBreakPy("lingei") = "lin"
            mapCustBreakPy("lingen") = "lin"
            'mapCustBreakPy("lingeng") = "lin"
            mapCustBreakPy("lingu") = "lin"
            'mapCustBreakPy("lingun") = "lin"
            'mapCustBreakPy("linguo") = "lin"
            'mapCustBreakPy("lingv") = "lin"
            'mapCustBreakPy("lingve") = "lin"


            'mapCustBreakPy("xina") = "xi"
            'mapCustBreakPy("xinai") = "xi"
            mapCustBreakPy("xinao") = "xi"
            'mapCustBreakPy("xinan") = "xi"
            'mapCustBreakPy("xinang") = "xi"
            'mapCustBreakPy("xino") = "xi"
            'mapCustBreakPy("xinou") = "xi"
            mapCustBreakPy("xinong") = "xi"
            'mapCustBreakPy("xine") = "xi"
            mapCustBreakPy("xinei") = "xi"
            mapCustBreakPy("xinen") = "xi"
            'mapCustBreakPy("xineng") = "xi"
            mapCustBreakPy("xini") = "xi"
            mapCustBreakPy("xinu") = "xi"
            mapCustBreakPy("xinv") = "xi"

            'mapCustBreakPy("xinga") = "xin"
            'mapCustBreakPy("xingai") = "xin"
            'mapCustBreakPy("xingao") = "xin"
            mapCustBreakPy("xingan") = "xin"
            'mapCustBreakPy("xingang") = "xin"
            'mapCustBreakPy("xingo") = "xin"
            mapCustBreakPy("xingou") = "xin"
            mapCustBreakPy("xingong") = "xin"
            mapCustBreakPy("xingei") = "xin"
            mapCustBreakPy("xingen") = "xin"
            'mapCustBreakPy("xingeng") = "xin"
            mapCustBreakPy("xingu") = "xin"
            'mapCustBreakPy("xingun") = "xin"
            'mapCustBreakPy("xinguo") = "xin"
            'mapCustBreakPy("xingv") = "xin"
            'mapCustBreakPy("xingve") = "xin"


            'mapCustBreakPy("bina") = "bi"
            'mapCustBreakPy("binai") = "bi"
            mapCustBreakPy("binao") = "bi"
            'mapCustBreakPy("binan") = "bi"
            'mapCustBreakPy("binang") = "bi"
            'mapCustBreakPy("bino") = "bi"
            'mapCustBreakPy("binou") = "bi"
            mapCustBreakPy("binong") = "bi"
            'mapCustBreakPy("bine") = "bi"
            mapCustBreakPy("binei") = "bi"
            mapCustBreakPy("binen") = "bi"
            'mapCustBreakPy("bineng") = "bi"
            mapCustBreakPy("bini") = "bi"
            mapCustBreakPy("binu") = "bi"
            mapCustBreakPy("binv") = "bi"

            'mapCustBreakPy("binga") = "bin"
            'mapCustBreakPy("bingai") = "bin"
            'mapCustBreakPy("bingao") = "bin"
            'mapCustBreakPy("bingan") = "bin"
            mapCustBreakPy("bingang") = "bin"
            'mapCustBreakPy("bingo") = "bin"
            mapCustBreakPy("bingou") = "bin"
            mapCustBreakPy("bingong") = "bin"
            mapCustBreakPy("bingei") = "bin"
            mapCustBreakPy("bingen") = "bin"
            'mapCustBreakPy("bingeng") = "bin"
            mapCustBreakPy("bingu") = "bin"
            'mapCustBreakPy("bingun") = "bin"
            'mapCustBreakPy("binguo") = "bin"
            'mapCustBreakPy("bingv") = "bin"
            'mapCustBreakPy("bingve") = "bin"


            'mapCustBreakPy("nina") = "ni"
            mapCustBreakPy("ninai") = "ni"
            mapCustBreakPy("ninao") = "ni"
            mapCustBreakPy("ninan") = "ni"
            'mapCustBreakPy("ninang") = "ni"
            'mapCustBreakPy("nino") = "ni"
            'mapCustBreakPy("ninou") = "ni"
            mapCustBreakPy("ninong") = "ni"
            mapCustBreakPy("ninei") = "ni"
            mapCustBreakPy("ninen") = "ni"
            'mapCustBreakPy("nineng") = "ni"
            mapCustBreakPy("nini") = "ni"
            mapCustBreakPy("ninu") = "ni"
            mapCustBreakPy("ninv") = "ni"

            'mapCustBreakPy("ninga") = "nin"
            'mapCustBreakPy("ningai") = "nin"
            'mapCustBreakPy("ningao") = "nin"
            'mapCustBreakPy("ningan") = "nin"
            mapCustBreakPy("ningang") = "nin"
            'mapCustBreakPy("ningo") = "nin"
            mapCustBreakPy("ningou") = "nin"
            mapCustBreakPy("ningong") = "nin"
            mapCustBreakPy("ningei") = "nin"
            mapCustBreakPy("ningen") = "nin"
            'mapCustBreakPy("ningeng") = "nin"
            mapCustBreakPy("ningu") = "nin"
            'mapCustBreakPy("ningun") = "nin"
            'mapCustBreakPy("ninguo") = "nin"
            'mapCustBreakPy("ningv") = "nin"
            'mapCustBreakPy("ningve") = "nin"


            'mapCustBreakPy("mina") = "mi"
            'mapCustBreakPy("minai") = "mi"
            'mapCustBreakPy("minao") = "mi"
            'mapCustBreakPy("minan") = "mi"
            'mapCustBreakPy("minang") = "mi"
            'mapCustBreakPy("mino") = "mi"
            'mapCustBreakPy("minou") = "mi"
            mapCustBreakPy("minong") = "mi"
            'mapCustBreakPy("mine") = "mi"
            mapCustBreakPy("minei") = "mi"
            'mapCustBreakPy("minen") = "mi"
            'mapCustBreakPy("mineng") = "mi"
            mapCustBreakPy("mini") = "mi"
            mapCustBreakPy("minu") = "mi"
            mapCustBreakPy("minv") = "mi"

            'mapCustBreakPy("minga") = "min"
            'mapCustBreakPy("mingai") = "min"
            mapCustBreakPy("mingao") = "min"
            'mapCustBreakPy("mingan") = "min"
            mapCustBreakPy("mingang") = "min"
            'mapCustBreakPy("mingo") = "min"
            mapCustBreakPy("mingou") = "min"
            mapCustBreakPy("mingong") = "min"
            'mapCustBreakPy("minge") = "min"
            mapCustBreakPy("mingei") = "min"
            mapCustBreakPy("mingen") = "min"
            'mapCustBreakPy("mingeng") = "min"
            mapCustBreakPy("mingu") = "min"
            'mapCustBreakPy("mingun") = "min"
            'mapCustBreakPy("minguo") = "min"
            'mapCustBreakPy("mingv") = "min"
            'mapCustBreakPy("mingve") = "min"


            'mapCustBreakPy("wenga") = "wen"
            mapCustBreakPy("wengai") = "wen"
            mapCustBreakPy("wengao") = "wen"
            mapCustBreakPy("wengan") = "wen"
            'mapCustBreakPy("wengang") = "wen"
            'mapCustBreakPy("wengo") = "wen"
            mapCustBreakPy("wengou") = "wen"
            mapCustBreakPy("wengong") = "wen"
            mapCustBreakPy("wengei") = "wen"
            mapCustBreakPy("wengen") = "wen"
            'mapCustBreakPy("wengeng") = "wen"
            mapCustBreakPy("wengu") = "wen"
            'mapCustBreakPy("wengun") = "wen"
            'mapCustBreakPy("wenguo") = "wen"
            'mapCustBreakPy("wengv") = "wen"
            'mapCustBreakPy("wengve") = "wen"


            'mapCustBreakPy("rena") = "re"
            'mapCustBreakPy("renai") = "re"
            mapCustBreakPy("renao") = "re"
            'mapCustBreakPy("renan") = "re"
            mapCustBreakPy("renang") = "re"
            'mapCustBreakPy("reno") = "re"
            'mapCustBreakPy("renou") = "re"
            mapCustBreakPy("renong") = "re"
            mapCustBreakPy("renei") = "re"
            mapCustBreakPy("renen") = "re"
            'mapCustBreakPy("reneng") = "re"
            mapCustBreakPy("reni") = "re"
            mapCustBreakPy("renu") = "re"
            mapCustBreakPy("renv") = "re"

            'mapCustBreakPy("renga") = "ren"
            'mapCustBreakPy("rengai") = "ren"
            mapCustBreakPy("rengao") = "ren"
            mapCustBreakPy("rengan") = "ren"
            'mapCustBreakPy("rengang") = "ren"
            mapCustBreakPy("rengou") = "ren"
            mapCustBreakPy("rengong") = "ren"
            mapCustBreakPy("rengei") = "ren"
            mapCustBreakPy("rengen") = "ren"
            'mapCustBreakPy("rengeng") = "ren"
            mapCustBreakPy("rengu") = "ren"


            'mapCustBreakPy("penga") = "pen"
            'mapCustBreakPy("pengai") = "pen"
            mapCustBreakPy("pengao") = "pen"
            mapCustBreakPy("pengan") = "pen"
            'mapCustBreakPy("pengang") = "pen"
            mapCustBreakPy("pengou") = "pen"
            mapCustBreakPy("pengong") = "pen"
            'mapCustBreakPy("penge") = "pen" 
            mapCustBreakPy("pengei") = "pen"
            mapCustBreakPy("pengen") = "pen"
            'mapCustBreakPy("pengeng") = "pen"
            mapCustBreakPy("pengu") = "pen"


            'mapCustBreakPy("sena") = "se"
            'mapCustBreakPy("senai") = "se"
            'mapCustBreakPy("senao") = "se"
            'mapCustBreakPy("senan") = "se"
            mapCustBreakPy("senang") = "se"
            'mapCustBreakPy("seno") = "se"
            'mapCustBreakPy("senou") = "se"
            mapCustBreakPy("senong") = "se"
            mapCustBreakPy("senei") = "se"
            mapCustBreakPy("senen") = "se"
            'mapCustBreakPy("seneng") = "se"
            mapCustBreakPy("seni") = "se"
            mapCustBreakPy("senu") = "se"
            mapCustBreakPy("senv") = "se"

            'mapCustBreakPy("senga") = "sen"
            mapCustBreakPy("sengai") = "sen"
            mapCustBreakPy("sengao") = "sen"
            mapCustBreakPy("sengan") = "sen"
            'mapCustBreakPy("sengang") = "sen"
            mapCustBreakPy("sengou") = "sen"
            mapCustBreakPy("sengong") = "sen"
            'mapCustBreakPy("senge") = "sen"
            mapCustBreakPy("sengei") = "sen"
            'mapCustBreakPy("sengen") = "sen"
            mapCustBreakPy("sengeng") = "sen"
            mapCustBreakPy("sengu") = "sen"

            mapCustBreakPy("shenang") = "she"
            mapCustBreakPy("shenong") = "she"
            mapCustBreakPy("shenei") = "she"
            mapCustBreakPy("shenen") = "she"
            mapCustBreakPy("sheni") = "she"
            mapCustBreakPy("shenu") = "she"
            mapCustBreakPy("shenv") = "she"

            mapCustBreakPy("shengai") = "shen"
            mapCustBreakPy("shengao") = "shen"
            mapCustBreakPy("shengan") = "shen"
            mapCustBreakPy("shengou") = "shen"
            mapCustBreakPy("shengong") = "shen"
            mapCustBreakPy("shengei") = "shen"
            mapCustBreakPy("shengeng") = "shen"
            mapCustBreakPy("shengu") = "shen"


            'mapCustBreakPy("dena") = "de"
            mapCustBreakPy("denai") = "de"
            mapCustBreakPy("denao") = "de"
            mapCustBreakPy("denan") = "de"
            'mapCustBreakPy("denang") = "de"
            'mapCustBreakPy("deno") = "de"
            'mapCustBreakPy("denou") = "de"
            mapCustBreakPy("denong") = "de"
            mapCustBreakPy("denei") = "de"
            'mapCustBreakPy("denen") = "de"
            'mapCustBreakPy("deneng") = "de"
            mapCustBreakPy("deni") = "de"
            mapCustBreakPy("denu") = "de"
            mapCustBreakPy("denv") = "de"

            mapCustBreakPy("dengu") = "den"


            mapCustBreakPy("feni") = "fe"
            mapCustBreakPy("fenu") = "fe"
            mapCustBreakPy("fenv") = "fe"

            'mapCustBreakPy("fenga") = "fen"
            mapCustBreakPy("fengai") = "fen"
            mapCustBreakPy("fengao") = "fen"
            mapCustBreakPy("fengan") = "fen"
            'mapCustBreakPy("fengang") = "fen"
            mapCustBreakPy("fengou") = "fen"
            mapCustBreakPy("fengong") = "fen"
            mapCustBreakPy("fengei") = "fen"
            'mapCustBreakPy("fengen") = "fen"
            mapCustBreakPy("fengeng") = "fen"
            mapCustBreakPy("fengu") = "fen"


            'mapCustBreakPy("gena") = "ge"
            'mapCustBreakPy("genai") = "ge"
            'mapCustBreakPy("genao") = "ge"
            'mapCustBreakPy("genan") = "ge"
            mapCustBreakPy("genang") = "ge"
            mapCustBreakPy("genong") = "ge"
            mapCustBreakPy("genei") = "ge"
            mapCustBreakPy("genen") = "ge"
            'mapCustBreakPy("geneng") = "ge"
            mapCustBreakPy("geni") = "ge"
            mapCustBreakPy("genu") = "ge"
            mapCustBreakPy("genv") = "ge"

            'mapCustBreakPy("genga") = "gen"
            'mapCustBreakPy("gengai") = "gen"
            mapCustBreakPy("gengao") = "gen"
            mapCustBreakPy("gengan") = "gen"
            'mapCustBreakPy("gengang") = "gen"
            mapCustBreakPy("gengou") = "gen"
            mapCustBreakPy("gengong") = "gen"
            'mapCustBreakPy("genge") = "gen"
            mapCustBreakPy("gengei") = "gen"
            mapCustBreakPy("gengen") = "gen"
            'mapCustBreakPy("gengeng") = "gen"
            mapCustBreakPy("gengu") = "gen"


            'mapCustBreakPy("hena") = "he"
            'mapCustBreakPy("henai") = "he"
            'mapCustBreakPy("henao") = "he"
            'mapCustBreakPy("henan") = "he"
            'mapCustBreakPy("henang") = "he"
            mapCustBreakPy("henong") = "he"
            'mapCustBreakPy("hene") = "he"
            mapCustBreakPy("henei") = "he"
            'mapCustBreakPy("henen") = "he"
            mapCustBreakPy("heneng") = "he"
            mapCustBreakPy("heni") = "he"
            mapCustBreakPy("henu") = "he"
            mapCustBreakPy("henv") = "he"

            'mapCustBreakPy("henga") = "hen"
            mapCustBreakPy("hengai") = "hen"
            mapCustBreakPy("hengao") = "hen"
            mapCustBreakPy("hengan") = "hen"
            'mapCustBreakPy("hengang") = "hen"
            mapCustBreakPy("hengou") = "hen"
            mapCustBreakPy("hengong") = "hen"
            'mapCustBreakPy("henge") = "hen"
            mapCustBreakPy("hengei") = "hen"
            mapCustBreakPy("hengen") = "hen"
            'mapCustBreakPy("hengeng") = "hen"
            mapCustBreakPy("hengu") = "hen"


            'mapCustBreakPy("kena") = "ke"
            mapCustBreakPy("kenai") = "ke"
            mapCustBreakPy("kenao") = "ke"
            mapCustBreakPy("kenan") = "ke"
            'mapCustBreakPy("kenang") = "ke"
            mapCustBreakPy("kenong") = "ke"
            mapCustBreakPy("kenei") = "ke"
            mapCustBreakPy("kenen") = "ke"
            'mapCustBreakPy("keneng") = "ke"
            mapCustBreakPy("keni") = "ke"
            mapCustBreakPy("kenu") = "ke"
            mapCustBreakPy("kenv") = "ke"

            'mapCustBreakPy("kenga") = "ken"
            mapCustBreakPy("kengai") = "ken"
            mapCustBreakPy("kengao") = "ken"
            mapCustBreakPy("kengan") = "ken"
            'mapCustBreakPy("kengang") = "ken"
            mapCustBreakPy("kengou") = "ken"
            mapCustBreakPy("kengong") = "ken"
            'mapCustBreakPy("kenge") = "ken"
            mapCustBreakPy("kengei") = "ken"
            mapCustBreakPy("kengen") = "ken"
            'mapCustBreakPy("kengeng") = "ken"
            mapCustBreakPy("kengu") = "ken"


            'mapCustBreakPy("zena") = "ze"
            'mapCustBreakPy("zenai") = "ze"
            mapCustBreakPy("zenao") = "ze"
            mapCustBreakPy("zenan") = "ze"
            'mapCustBreakPy("zenang") = "ze"
            mapCustBreakPy("zenong") = "ze"
            'mapCustBreakPy("zene") = "ze"
            mapCustBreakPy("zenei") = "ze"
            mapCustBreakPy("zenen") = "ze"
            'mapCustBreakPy("zeneng") = "ze"
            mapCustBreakPy("zeni") = "ze"
            mapCustBreakPy("zenu") = "ze"
            mapCustBreakPy("zenv") = "ze"

            'mapCustBreakPy("zenga") = "zen"
            'mapCustBreakPy("zengai") = "zen"
            mapCustBreakPy("zengao") = "zen"
            'mapCustBreakPy("zengan") = "zen"
            'mapCustBreakPy("zengang") = "zen"
            mapCustBreakPy("zengou") = "zen"
            mapCustBreakPy("zengong") = "zen"
            mapCustBreakPy("zengei") = "zen"
            mapCustBreakPy("zengen") = "zen"
            'mapCustBreakPy("zengeng") = "zen"
            mapCustBreakPy("zengu") = "zen"

            mapCustBreakPy("zhenao") = "zhe"
            mapCustBreakPy("zhenan") = "zhe"
            mapCustBreakPy("zhenong") = "zhe"
            mapCustBreakPy("zhenei") = "zhe"
            mapCustBreakPy("zhenen") = "zhe"
            mapCustBreakPy("zheni") = "zhe"
            mapCustBreakPy("zhenu") = "zhe"
            mapCustBreakPy("zhenv") = "zhe"

            mapCustBreakPy("zhengao") = "zhen"
            mapCustBreakPy("zhengou") = "zhen"
            mapCustBreakPy("zhengong") = "zhen"
            mapCustBreakPy("zhengei") = "zhen"
            mapCustBreakPy("zhengen") = "zhen"
            mapCustBreakPy("zhengu") = "zhen"


            'mapCustBreakPy("cena") = "ce"
            mapCustBreakPy("cenai") = "ce"
            mapCustBreakPy("cenao") = "ce"
            mapCustBreakPy("cenan") = "ce"
            'mapCustBreakPy("cenang") = "ce"
            mapCustBreakPy("cenong") = "ce"
            mapCustBreakPy("cenei") = "ce"
            mapCustBreakPy("cenen") = "ce"
            'mapCustBreakPy("ceneng") = "ce"
            mapCustBreakPy("ceni") = "ce"
            mapCustBreakPy("cenu") = "ce"
            mapCustBreakPy("cenv") = "ce"

            ' 模糊音适用
            'mapCustBreakPy("cenga") = "cen"
            'mapCustBreakPy("cengai") = "cen"
            mapCustBreakPy("cengao") = "cen"
            mapCustBreakPy("cengan") = "cen"
            'mapCustBreakPy("cengang") = "cen"
            mapCustBreakPy("cengou") = "cen"
            mapCustBreakPy("cengong") = "cen"
            'mapCustBreakPy("cenge") = "cen"
            mapCustBreakPy("cengei") = "cen"
            mapCustBreakPy("cengen") = "cen"
            'mapCustBreakPy("cengeng") = "cen"
            mapCustBreakPy("cengu") = "cen"

            'mapCustBreakPy("chena") = "che"
            mapCustBreakPy("chenao") = "che"
            mapCustBreakPy("chenan") = "che"
            mapCustBreakPy("chenong") = "che"
            mapCustBreakPy("cengei") = "cen"
            mapCustBreakPy("cengen") = "cen"
            mapCustBreakPy("cheni") = "che"
            mapCustBreakPy("chenu") = "che"
            mapCustBreakPy("chenv") = "che"

            mapCustBreakPy("chengao") = "chen"
            mapCustBreakPy("chengan") = "chen"
            mapCustBreakPy("chengou") = "chen"
            mapCustBreakPy("chengong") = "chen"
            mapCustBreakPy("chengei") = "chen"
            mapCustBreakPy("chengen") = "chen"
            mapCustBreakPy("chengu") = "chen"


            'mapCustBreakPy("bena") = "be"
            'mapCustBreakPy("benai") = "be"
            'mapCustBreakPy("benao") = "be"
            'mapCustBreakPy("benan") = "be"
            'mapCustBreakPy("benang") = "be"
            'mapCustBreakPy("benong") = "be"
            'mapCustBreakPy("bene") = "be"
            'mapCustBreakPy("benei") = "be"
            'mapCustBreakPy("benen") = "be"
            'mapCustBreakPy("beneng") = "be"
            mapCustBreakPy("beni") = "b"
            mapCustBreakPy("benu") = "b"
            mapCustBreakPy("benv") = "b"

            'mapCustBreakPy("benga") = "ben"
            mapCustBreakPy("bengai") = "ben"
            mapCustBreakPy("bengao") = "ben"
            mapCustBreakPy("bengan") = "ben"
            'mapCustBreakPy("bengang") = "ben"
            mapCustBreakPy("bengou") = "ben"
            mapCustBreakPy("bengong") = "ben"
            'mapCustBreakPy("benge") = "ben"
            mapCustBreakPy("bengei") = "ben"
            mapCustBreakPy("bengen") = "ben"
            'mapCustBreakPy("bengeng") = "ben"
            mapCustBreakPy("bengu") = "ben"


            'mapCustBreakPy("nena") = "ne"
            'mapCustBreakPy("nenai") = "ne"
            'mapCustBreakPy("nenao") = "ne"
            'mapCustBreakPy("nenan") = "ne"
            mapCustBreakPy("nenang") = "ne"
            mapCustBreakPy("nenong") = "ne"
            'mapCustBreakPy("nene") = "ne"
            'mapCustBreakPy("nenei") = "ne"
            'mapCustBreakPy("nenen") = "ne"
            mapCustBreakPy("neneng") = "ne"
            mapCustBreakPy("neni") = "ne"
            mapCustBreakPy("nenu") = "ne"
            mapCustBreakPy("nenv") = "ne"

            'mapCustBreakPy("nenga") = "nen"
            'mapCustBreakPy("nengai") = "nen"
            'mapCustBreakPy("nengao") = "nen"
            'mapCustBreakPy("nengan") = "nen"
            'mapCustBreakPy("nengang") = "nen"
            mapCustBreakPy("nengou") = "nen"
            mapCustBreakPy("nengong") = "nen"
            'mapCustBreakPy("nenge") = "nen"
            mapCustBreakPy("nengei") = "nen"
            mapCustBreakPy("nengen") = "nen"
            'mapCustBreakPy("nengeng") = "nen"
            mapCustBreakPy("nengu") = "nen"


            'mapCustBreakPy("mena") = "me"
            'mapCustBreakPy("menai") = "me"
            mapCustBreakPy("menao") = "me"
            mapCustBreakPy("menan") = "me"
            'mapCustBreakPy("menang") = "me"
            mapCustBreakPy("menong") = "me"
            mapCustBreakPy("menei") = "me"
            mapCustBreakPy("menen") = "me"
            'mapCustBreakPy("meneng") = "me"
            mapCustBreakPy("meni") = "me"
            mapCustBreakPy("menu") = "me"
            mapCustBreakPy("menv") = "me"

            'mapCustBreakPy("menga") = "men"
            'mapCustBreakPy("mengai") = "men"
            mapCustBreakPy("mengao") = "men"
            mapCustBreakPy("mengan") = "men"
            'mapCustBreakPy("mengang") = "men"
            mapCustBreakPy("mengou") = "men"
            mapCustBreakPy("mengong") = "men"
            'mapCustBreakPy("menge") = "men"
            mapCustBreakPy("mengei") = "men"
            mapCustBreakPy("mengen") = "men"
            'mapCustBreakPy("mengeng") = "men"
            mapCustBreakPy("mengu") = "men"


            'mapCustBreakPy("wana") = "wa"
            'mapCustBreakPy("wanai") = "wa"
            'mapCustBreakPy("wanao") = "wa"
            'mapCustBreakPy("wanan") = "wa"
            mapCustBreakPy("wanang") = "wa"
            mapCustBreakPy("wanong") = "wa"
            'mapCustBreakPy("wanou") = "wa"
            'mapCustBreakPy("wane") = "wa"
            mapCustBreakPy("wanei") = "wa"
            'mapCustBreakPy("wanen") = "wa"
            mapCustBreakPy("waneng") = "wa"
            mapCustBreakPy("wani") = "wa"
            mapCustBreakPy("wanu") = "wa"
            mapCustBreakPy("wanv") = "wa"

            'mapCustBreakPy("wanga") = "wan"
            'mapCustBreakPy("wangai") = "wan"
            mapCustBreakPy("wangao") = "wan"
            mapCustBreakPy("wangan") = "wan"
            'mapCustBreakPy("wangang") = "wan"
            mapCustBreakPy("wangou") = "wan"
            mapCustBreakPy("wangong") = "wan"
            mapCustBreakPy("wangei") = "wan"
            mapCustBreakPy("wangen") = "wan"
            'mapCustBreakPy("wangeng") = "wan"
            mapCustBreakPy("wangu") = "wan"


            mapCustBreakPy("rani") = "r"
            mapCustBreakPy("ranu") = "r"
            mapCustBreakPy("ranv") = "r"

            'mapCustBreakPy("ranga") = "ran"
            'mapCustBreakPy("rangai") = "ran"
            'mapCustBreakPy("rangao") = "ran"
            'mapCustBreakPy("rangan") = "ran"
            mapCustBreakPy("rangang") = "ran"
            'mapCustBreakPy("rangou") = "ran"
            mapCustBreakPy("rangong") = "ran"
            'mapCustBreakPy("range") = "ran"
            mapCustBreakPy("rangei") = "ran"
            mapCustBreakPy("rangen") = "ran"
            'mapCustBreakPy("rangeng") = "ran"
            mapCustBreakPy("rangu") = "ran"


            'mapCustBreakPy("tana") = "ta"
            'mapCustBreakPy("tanai") = "ta"
            mapCustBreakPy("tanao") = "ta"
            mapCustBreakPy("tanan") = "ta"
            'mapCustBreakPy("tanang") = "ta"
            'mapCustBreakPy("tano") = "ta"
            'mapCustBreakPy("tanou") = "ta"
            mapCustBreakPy("tanong") = "ta"
            mapCustBreakPy("tanei") = "ta"
            mapCustBreakPy("tanen") = "ta"
            'mapCustBreakPy("taneng") = "ta"
            mapCustBreakPy("tani") = "ta"
            mapCustBreakPy("tanu") = "ta"
            mapCustBreakPy("tanv") = "ta"

            'mapCustBreakPy("tanga") = "tan"
            'mapCustBreakPy("tangai") = "tan"
            mapCustBreakPy("tangao") = "tan"
            mapCustBreakPy("tangan") = "tan"
            'mapCustBreakPy("tangang") = "tan"
            'mapCustBreakPy("tango") = "tan"
            mapCustBreakPy("tangou") = "tan"
            mapCustBreakPy("tangong") = "tan"
            mapCustBreakPy("tangei") = "tan"
            mapCustBreakPy("tangen") = "tan"
            'mapCustBreakPy("tangeng") = "tan"
            mapCustBreakPy("tangu") = "tan"


            'mapCustBreakPy("yana") = "ya"
            'mapCustBreakPy("yanai") = "ya"
            'mapCustBreakPy("yanao") = "ya"
            'mapCustBreakPy("yanan") = "ya"
            'mapCustBreakPy("yanang") = "ya"
            'mapCustBreakPy("yano") = "ya"
            'mapCustBreakPy("yanou") = "ya"
            mapCustBreakPy("yanong") = "ya"
            'mapCustBreakPy("yane") = "ya"
            mapCustBreakPy("yanei") = "ya"
            'mapCustBreakPy("yanen") = "ya"
            mapCustBreakPy("yaneng") = "ya"
            mapCustBreakPy("yani") = "ya"
            mapCustBreakPy("yanu") = "ya"
            mapCustBreakPy("yanv") = "ya"

            'mapCustBreakPy("yanga") = "yan"
            'mapCustBreakPy("yangai") = "yan"
            mapCustBreakPy("yangao") = "yan"
            mapCustBreakPy("yangan") = "yan"
            'mapCustBreakPy("yangang") = "yan"
            'mapCustBreakPy("yango") = "yan"
            mapCustBreakPy("yangou") = "yan"
            mapCustBreakPy("yangong") = "yan"
            'mapCustBreakPy("yange") = "yan"
            mapCustBreakPy("yangei") = "yan"
            mapCustBreakPy("yangen") = "yan"
            'mapCustBreakPy("yangeng") = "yan"
            mapCustBreakPy("yangu") = "yan"


            'mapCustBreakPy("pana") = "pa"
            mapCustBreakPy("panai") = "pa"
            mapCustBreakPy("panao") = "pa"
            mapCustBreakPy("panan") = "pa"
            'mapCustBreakPy("panang") = "pa"
            'mapCustBreakPy("pano") = "pa"
            'mapCustBreakPy("panou") = "pa"
            mapCustBreakPy("panong") = "pa"
            mapCustBreakPy("panei") = "pa"
            mapCustBreakPy("panen") = "pa"
            'mapCustBreakPy("paneng") = "pa"
            mapCustBreakPy("pani") = "pa"
            mapCustBreakPy("panu") = "pa"
            mapCustBreakPy("panv") = "pa"

            'mapCustBreakPy("panga") = "pan"
            'mapCustBreakPy("pangai") = "pan"
            mapCustBreakPy("pangao") = "pan"
            mapCustBreakPy("pangan") = "pan"
            'mapCustBreakPy("pangang") = "pan"
            'mapCustBreakPy("pango") = "pan"
            'mapCustBreakPy("pangou") = "pan"
            mapCustBreakPy("pangong") = "pan"
            'mapCustBreakPy("pange") = "pan"
            mapCustBreakPy("pangei") = "pan"
            mapCustBreakPy("pangen") = "pan"
            'mapCustBreakPy("pangeng") = "pan"
            mapCustBreakPy("pangu") = "pan"


            'mapCustBreakPy("sana") = "sa"
            'mapCustBreakPy("sanai") = "sa"
            'mapCustBreakPy("sanao") = "sa"
            'mapCustBreakPy("sanan") = "sa"
            'mapCustBreakPy("sanang") = "sa"
            'mapCustBreakPy("sanou") = "sa"
            mapCustBreakPy("sanong") = "sa"
            'mapCustBreakPy("sane") = "sa"
            mapCustBreakPy("sanei") = "sa"
            'mapCustBreakPy("sanen") = "sa"
            mapCustBreakPy("saneng") = "sa"
            mapCustBreakPy("sani") = "sa"
            mapCustBreakPy("sanu") = "sa"
            mapCustBreakPy("sanv") = "sa"

            'mapCustBreakPy("sanga") = "san"
            'mapCustBreakPy("sangai") = "san"
            mapCustBreakPy("sangao") = "san"
            mapCustBreakPy("sangan") = "san"
            'mapCustBreakPy("sangang") = "san"
            mapCustBreakPy("sangou") = "san"
            mapCustBreakPy("sangong") = "san"
            mapCustBreakPy("sangei") = "san"
            mapCustBreakPy("sangen") = "san"
            'mapCustBreakPy("sangeng") = "san"
            mapCustBreakPy("sangu") = "san"

            mapCustBreakPy("shanong") = "sha"
            mapCustBreakPy("shanei") = "sha"
            mapCustBreakPy("shaneng") = "sha"
            mapCustBreakPy("shani") = "sha"
            mapCustBreakPy("shanu") = "sha"
            mapCustBreakPy("shanv") = "sha"

            mapCustBreakPy("shangao") = "shan"
            mapCustBreakPy("shangan") = "shan"
            mapCustBreakPy("shangou") = "shan"
            mapCustBreakPy("shangong") = "shan"
            mapCustBreakPy("shangei") = "shan"
            mapCustBreakPy("shangen") = "shan"
            mapCustBreakPy("shangu") = "shan"


            'mapCustBreakPy("dana") = "da"
            mapCustBreakPy("danai") = "da"
            mapCustBreakPy("danao") = "da"
            mapCustBreakPy("danan") = "da"
            'mapCustBreakPy("danang") = "da"
            'mapCustBreakPy("danou") = "da"
            mapCustBreakPy("danong") = "da"
            mapCustBreakPy("danei") = "da"
            mapCustBreakPy("danen") = "da"
            'mapCustBreakPy("daneng") = "da"
            mapCustBreakPy("dani") = "da"
            mapCustBreakPy("danu") = "da"
            mapCustBreakPy("danv") = "da"

            'mapCustBreakPy("danga") = "dan"
            'mapCustBreakPy("dangai") = "dan"
            mapCustBreakPy("dangao") = "dan"
            'mapCustBreakPy("dangan") = "dan"
            mapCustBreakPy("dangang") = "dan"
            mapCustBreakPy("dangou") = "dan"
            mapCustBreakPy("dangong") = "dan"
            mapCustBreakPy("dangei") = "dan"
            mapCustBreakPy("dangen") = "dan"
            'mapCustBreakPy("dangeng") = "dan"
            mapCustBreakPy("dangu") = "dan"


            'mapCustBreakPy("fana") = "fa"
            'mapCustBreakPy("fanai") = "fa"
            mapCustBreakPy("fanao") = "fa"
            'mapCustBreakPy("fanan") = "fa"
            mapCustBreakPy("fanang") = "fa"
            'mapCustBreakPy("fanou") = "fa"
            mapCustBreakPy("fanong") = "fa"
            'mapCustBreakPy("fane") = "fa"
            mapCustBreakPy("fanei") = "fa"
            mapCustBreakPy("fanen") = "fa"
            'mapCustBreakPy("faneng") = "fa"
            mapCustBreakPy("fani") = "fa"
            mapCustBreakPy("fanu") = "fa"
            mapCustBreakPy("fanv") = "fa"

            'mapCustBreakPy("fanga") = "fan"
            mapCustBreakPy("fangai") = "fan"
            mapCustBreakPy("fangao") = "fan"
            'mapCustBreakPy("fangan") = "fan"
            mapCustBreakPy("fangang") = "fan"
            mapCustBreakPy("fangou") = "fan"
            mapCustBreakPy("fangong") = "fan"
            'mapCustBreakPy("fange") = "fan"
            mapCustBreakPy("fangei") = "fan"
            mapCustBreakPy("fangen") = "fan"
            'mapCustBreakPy("fangeng") = "fan"
            mapCustBreakPy("fangu") = "fan"


            'mapCustBreakPy("gana") = "ga"
            'mapCustBreakPy("ganai") = "ga"
            'mapCustBreakPy("ganao") = "ga"
            'mapCustBreakPy("ganan") = "ga"
            'mapCustBreakPy("ganang") = "ga"
            'mapCustBreakPy("ganou") = "ga"
            mapCustBreakPy("ganong") = "ga"
            'mapCustBreakPy("gane") = "ga"
            'mapCustBreakPy("ganei") = "ga"
            'mapCustBreakPy("ganen") = "ga"
            'mapCustBreakPy("ganeng") = "ga"
            mapCustBreakPy("gani") = "ga"
            mapCustBreakPy("ganu") = "ga"
            mapCustBreakPy("ganv") = "ga"

            'mapCustBreakPy("ganga") = "gan"
            'mapCustBreakPy("gangai") = "gan"
            'mapCustBreakPy("gangao") = "gan"
            mapCustBreakPy("gangan") = "gan"
            mapCustBreakPy("gangang") = "gan"
            mapCustBreakPy("gangou") = "gan"
            mapCustBreakPy("gangong") = "gan"
            mapCustBreakPy("gangei") = "gan"
            mapCustBreakPy("gangen") = "gan"
            'mapCustBreakPy("gangeng") = "gan"
            mapCustBreakPy("gangu") = "gan"


            'mapCustBreakPy("hana") = "ha"
            'mapCustBreakPy("hanai") = "ha"
            'mapCustBreakPy("hanao") = "ha"
            'mapCustBreakPy("hanan") = "ha"
            'mapCustBreakPy("hanang") = "ha"
            'mapCustBreakPy("hanou") = "ha"
            mapCustBreakPy("hanong") = "ha"
            'mapCustBreakPy("hane") = "ha"
            mapCustBreakPy("hanei") = "ha"
            mapCustBreakPy("hanen") = "ha"
            'mapCustBreakPy("haneng") = "ha"
            mapCustBreakPy("hani") = "ha"
            mapCustBreakPy("hanu") = "ha"
            mapCustBreakPy("hanv") = "ha"

            'mapCustBreakPy("hanga") = "han"
            mapCustBreakPy("hangai") = "han"
            mapCustBreakPy("hangao") = "han"
            mapCustBreakPy("hangan") = "han"
            'mapCustBreakPy("hangang") = "han"
            mapCustBreakPy("hangou") = "han"
            mapCustBreakPy("hangong") = "han"
            'mapCustBreakPy("hange") = "han"
            mapCustBreakPy("hangei") = "han"
            mapCustBreakPy("hangen") = "han"
            'mapCustBreakPy("hangeng") = "han"
            mapCustBreakPy("hangu") = "han"


            'mapCustBreakPy("kana") = "ka"
            'mapCustBreakPy("kanai") = "ka"
            'mapCustBreakPy("kanao") = "ka"
            'mapCustBreakPy("kanan") = "ka"
            'mapCustBreakPy("kanang") = "ka"
            'mapCustBreakPy("kanou") = "ka"
            mapCustBreakPy("kanong") = "ka"
            'mapCustBreakPy("kane") = "ka"
            mapCustBreakPy("kanei") = "ka"
            mapCustBreakPy("kanen") = "ka"
            'mapCustBreakPy("kaneng") = "ka"
            mapCustBreakPy("kani") = "ka"
            mapCustBreakPy("kanu") = "ka"
            mapCustBreakPy("kanv") = "ka"

            'mapCustBreakPy("kanga") = "kan"
            'mapCustBreakPy("kangai") = "kan"
            mapCustBreakPy("kangao") = "kan"
            mapCustBreakPy("kangan") = "kan"
            'mapCustBreakPy("kangang") = "kan"
            mapCustBreakPy("kango") = "kan"
            'mapCustBreakPy("kangou") = "kan"
            'mapCustBreakPy("kangong") = "kan"
            mapCustBreakPy("kangei") = "kan"
            mapCustBreakPy("kangen") = "kan"
            'mapCustBreakPy("kangeng") = "kan"
            mapCustBreakPy("kangu") = "kan"


            'mapCustBreakPy("lana") = "la"
            'mapCustBreakPy("lanai") = "la"
            'mapCustBreakPy("lanao") = "la"
            'mapCustBreakPy("lanan") = "la"
            'mapCustBreakPy("lanang") = "la"
            'mapCustBreakPy("lanou") = "la"
            mapCustBreakPy("lanong") = "la"
            'mapCustBreakPy("lane") = "la"
            mapCustBreakPy("lanei") = "la"
            'mapCustBreakPy("lanen") = "la"
            mapCustBreakPy("laneng") = "la"
            mapCustBreakPy("lani") = "la"
            mapCustBreakPy("lanu") = "la"
            mapCustBreakPy("lanv") = "la"

            'mapCustBreakPy("langa") = "lan"
            'mapCustBreakPy("langai") = "lan"
            mapCustBreakPy("langao") = "lan"
            mapCustBreakPy("langan") = "lan"
            'mapCustBreakPy("langang") = "lan"
            mapCustBreakPy("lango") = "lan"
            'mapCustBreakPy("langou") = "lan"
            'mapCustBreakPy("langong") = "lan"
            'mapCustBreakPy("lange") = "lan"
            mapCustBreakPy("langei") = "lan"
            'mapCustBreakPy("langen") = "lan"
            'mapCustBreakPy("langeng") = "lan"
            mapCustBreakPy("langu") = "lan"


            'mapCustBreakPy("zana") = "za"
            'mapCustBreakPy("zanai") = "za"
            mapCustBreakPy("zanao") = "za"
            'mapCustBreakPy("zanan") = "za"
            'mapCustBreakPy("zanang") = "za"
            'mapCustBreakPy("zanou") = "za"
            mapCustBreakPy("zanong") = "za"
            'mapCustBreakPy("zane") = "za"
            'mapCustBreakPy("zaner") = "za"
            mapCustBreakPy("zanei") = "za"
            mapCustBreakPy("zanen") = "za"
            'mapCustBreakPy("zaneng") = "za"
            mapCustBreakPy("zani") = "za"
            mapCustBreakPy("zanu") = "za"
            mapCustBreakPy("zanv") = "za"

            'mapCustBreakPy("zanga") = "zan"
            mapCustBreakPy("zangai") = "zan"
            mapCustBreakPy("zangao") = "zan"
            mapCustBreakPy("zangan") = "zan"
            'mapCustBreakPy("zangang") = "zan"
            'mapCustBreakPy("zango") = "zan"
            mapCustBreakPy("zangou") = "zan"
            mapCustBreakPy("zangong") = "zan"
            mapCustBreakPy("zangei") = "zan"
            mapCustBreakPy("zangen") = "zan"
            'mapCustBreakPy("zangeng") = "zan"
            mapCustBreakPy("zangu") = "zan"

            mapCustBreakPy("zhanao") = "zha"
            mapCustBreakPy("zhanong") = "zha"
            mapCustBreakPy("zhanei") = "zha"
            mapCustBreakPy("zhanen") = "zha"
            mapCustBreakPy("zhani") = "zha"
            mapCustBreakPy("zhanu") = "zha"
            mapCustBreakPy("zhanv") = "zha"

            mapCustBreakPy("zhangai") = "zhan"
            mapCustBreakPy("zhangao") = "zhan"
            mapCustBreakPy("zhangan") = "zhan"
            mapCustBreakPy("zhangou") = "zhan"
            mapCustBreakPy("zhangong") = "zhan"
            mapCustBreakPy("zhangei") = "zhan"
            mapCustBreakPy("zhangen") = "zhan"
            mapCustBreakPy("zhangu") = "zhan"


            'mapCustBreakPy("cana") = "ca"
            'mapCustBreakPy("canai") = "ca"
            mapCustBreakPy("canao") = "ca"
            'mapCustBreakPy("canan") = "ca"
            'mapCustBreakPy("canang") = "ca"
            'mapCustBreakPy("canou") = "ca"
            mapCustBreakPy("canong") = "ca"
            'mapCustBreakPy("cane") = "ca"
            'mapCustBreakPy("caner") = "ca"
            mapCustBreakPy("canei") = "ca"
            mapCustBreakPy("canen") = "ca"
            'mapCustBreakPy("caneng") = "ca"
            mapCustBreakPy("cani") = "ca"
            mapCustBreakPy("canu") = "ca"
            mapCustBreakPy("canv") = "ca"

            'mapCustBreakPy("canga") = "can"
            'mapCustBreakPy("cangai") = "can"
            mapCustBreakPy("cangao") = "can"
            'mapCustBreakPy("cangan") = "can"
            mapCustBreakPy("cangang") = "can"
            'mapCustBreakPy("cango") = "can"
            'mapCustBreakPy("cangou") = "can"
            mapCustBreakPy("cangong") = "can"
            'mapCustBreakPy("cange") = "can"
            mapCustBreakPy("cangei") = "can"
            mapCustBreakPy("cangen") = "can"
            'mapCustBreakPy("cangeng") = "can"
            mapCustBreakPy("cangu") = "can"

            mapCustBreakPy("chanao") = "cha"
            mapCustBreakPy("chanong") = "cha"
            mapCustBreakPy("chanei") = "cha"
            mapCustBreakPy("chanen") = "cha"
            mapCustBreakPy("chani") = "cha"
            mapCustBreakPy("chanu") = "cha"
            mapCustBreakPy("chanv") = "cha"

            mapCustBreakPy("changao") = "chan"
            mapCustBreakPy("changang") = "chan"
            mapCustBreakPy("changong") = "chan"
            mapCustBreakPy("changei") = "chan"
            mapCustBreakPy("changen") = "chan"
            mapCustBreakPy("changu") = "chan"


            'mapCustBreakPy("banai") = "ba"
            'mapCustBreakPy("banao") = "ba"
            'mapCustBreakPy("banan") = "ba"
            'mapCustBreakPy("banang") = "ba"
            'mapCustBreakPy("banou") = "ba"
            mapCustBreakPy("banong") = "ba"
            'mapCustBreakPy("bane") = "ba"
            mapCustBreakPy("banei") = "ba"
            mapCustBreakPy("banen") = "ba"
            'mapCustBreakPy("baneng") = "ba"
            mapCustBreakPy("bani") = "ba"
            mapCustBreakPy("banu") = "ba"
            mapCustBreakPy("banv") = "ba"

            'mapCustBreakPy("banga") = "ban"
            'mapCustBreakPy("bangai") = "ban"
            mapCustBreakPy("bangao") = "ban"
            'mapCustBreakPy("bangan") = "ban"
            mapCustBreakPy("bangang") = "ban"
            'mapCustBreakPy("bango") = "ban"
            'mapCustBreakPy("bangou") = "ban"
            mapCustBreakPy("bangong") = "ban"
            mapCustBreakPy("bange") = "ban"
            'mapCustBreakPy("banger") = "ban"
            'mapCustBreakPy("bangei") = "ban"
            'mapCustBreakPy("bangen") = "ban"
            'mapCustBreakPy("bangeng") = "ban"
            mapCustBreakPy("bangu") = "ban"


            'mapCustBreakPy("nana") = "na"  
            'mapCustBreakPy("nanai") = "na"
            'mapCustBreakPy("nanao") = "na"
            'mapCustBreakPy("nanan") = "na"
            'mapCustBreakPy("nanang") = "na"
            'mapCustBreakPy("nanou") = "na"
            mapCustBreakPy("nanong") = "na"
            'mapCustBreakPy("nane") = "na"
            'mapCustBreakPy("naner") = "na"
            mapCustBreakPy("nanei") = "na"
            mapCustBreakPy("nanen") = "na"
            'mapCustBreakPy("naneng") = "na"
            mapCustBreakPy("nani") = "na"
            mapCustBreakPy("nanu") = "na"
            mapCustBreakPy("nanv") = "na"

            mapCustBreakPy("nanga") = "nan"
            'mapCustBreakPy("nangai") = "nan"
            'mapCustBreakPy("nangao") = "nan"
            'mapCustBreakPy("nangan") = "nan"
            'mapCustBreakPy("nangang") = "nan"
            'mapCustBreakPy("nango") = "nan"
            'mapCustBreakPy("nangou") = "nan"
            mapCustBreakPy("nangong") = "nan"
            mapCustBreakPy("nange") = "nan"
            'mapCustBreakPy("nanger") = "nan"
            'mapCustBreakPy("nangei") = "nan"
            'mapCustBreakPy("nangen") = "nan"
            'mapCustBreakPy("nangeng") = "nan"
            mapCustBreakPy("nangu") = "nan"


            'mapCustBreakPy("mana") = "ma"  
            mapCustBreakPy("manai") = "ma"
            mapCustBreakPy("manao") = "ma"
            'mapCustBreakPy("manan") = "ma"
            mapCustBreakPy("manang") = "ma"
            'mapCustBreakPy("manou") = "ma"
            mapCustBreakPy("manong") = "ma"
            'mapCustBreakPy("mane") = "ma"
            'mapCustBreakPy("maner") = "ma"
            mapCustBreakPy("manei") = "ma"
            'mapCustBreakPy("manen") = "ma"
            mapCustBreakPy("maneng") = "ma"
            mapCustBreakPy("mani") = "ma"
            mapCustBreakPy("manu") = "ma"
            mapCustBreakPy("manv") = "ma"

            'mapCustBreakPy("manga") = "man"
            'mapCustBreakPy("mangai") = "man"
            'mapCustBreakPy("mangao") = "man"
            mapCustBreakPy("mangan") = "man"
            'mapCustBreakPy("mangang") = "man"
            'mapCustBreakPy("mango") = "man"
            'mapCustBreakPy("mangou") = "man"
            mapCustBreakPy("mangong") = "man"
            'mapCustBreakPy("mange") = "man"
            mapCustBreakPy("manger") = "man"
            mapCustBreakPy("mangei") = "man"
            mapCustBreakPy("mangen") = "man"
            'mapCustBreakPy("mangeng") = "man"
            mapCustBreakPy("mangu") = "man"



            'mapCustBreakPy("qiana") = "qia"  
            'mapCustBreakPy("qianai") = "qia"
            'mapCustBreakPy("qianao") = "qia"
            'mapCustBreakPy("qianan") = "qia"
            'mapCustBreakPy("qianang") = "qia"
            mapCustBreakPy("qianou") = "qia"
            mapCustBreakPy("qianong") = "qia"
            'mapCustBreakPy("qiane") = "qia"
            'mapCustBreakPy("qianer") = "qia"
            mapCustBreakPy("qianei") = "qia"
            'mapCustBreakPy("qianen") = "qia"
            mapCustBreakPy("qianeng") = "qia"
            mapCustBreakPy("qiani") = "qia"
            mapCustBreakPy("qianu") = "qia"
            mapCustBreakPy("qianv") = "qia"

            'mapCustBreakPy("qianga") = "qian"
            'mapCustBreakPy("qiangai") = "qian"
            'mapCustBreakPy("qiangao") = "qian"
            'mapCustBreakPy("qiangan") = "qian"
            mapCustBreakPy("qiangang") = "qian"
            'mapCustBreakPy("qiango") = "qian"
            mapCustBreakPy("qiangou") = "qian"
            mapCustBreakPy("qiangong") = "qian"
            mapCustBreakPy("qiange") = "qian"
            mapCustBreakPy("qianger") = "qiang"
            'mapCustBreakPy("qiangei") = "qian"
            'mapCustBreakPy("qiangen") = "qian"
            'mapCustBreakPy("qiangeng") = "qian"
            mapCustBreakPy("qiangu") = "qian"


            mapCustBreakPy("tiani") = "ti"
            mapCustBreakPy("tianu") = "ti"
            mapCustBreakPy("tianv") = "ti"

            mapCustBreakPy("piani") = "pi"
            mapCustBreakPy("pianu") = "pi"
            mapCustBreakPy("pianv") = "pi"

            mapCustBreakPy("diani") = "di"
            mapCustBreakPy("dianu") = "di"
            mapCustBreakPy("dianv") = "di"


            'mapCustBreakPy("jiana") = "jia"  
            'mapCustBreakPy("jianai") = "jia"
            'mapCustBreakPy("jianao") = "jia"
            'mapCustBreakPy("jianan") = "jia"
            'mapCustBreakPy("jianang") = "jia"
            'mapCustBreakPy("jianou") = "jia"
            mapCustBreakPy("jianong") = "jia"
            'mapCustBreakPy("jiane") = "jia"
            'mapCustBreakPy("jianer") = "jian"
            mapCustBreakPy("jianei") = "jia"
            mapCustBreakPy("jianen") = "jia"
            'mapCustBreakPy("jianeng") = "jia"
            mapCustBreakPy("jiani") = "jia"
            mapCustBreakPy("jianu") = "jia"
            mapCustBreakPy("jianv") = "jia"

            'mapCustBreakPy("jianga") = "jian"
            'mapCustBreakPy("jiangai") = "jian"
            'mapCustBreakPy("jiangao") = "jian"
            'mapCustBreakPy("jiangan") = "jian"
            'mapCustBreakPy("jiangang") = "jian"
            'mapCustBreakPy("jiango") = "jian"
            'mapCustBreakPy("jiangou") = "jian"
            mapCustBreakPy("jiangong") = "jian"
            mapCustBreakPy("jiange") = "jian"
            mapCustBreakPy("jianger") = "jiang"
            'mapCustBreakPy("jiangei") = "jian"
            'mapCustBreakPy("jiangen") = "jian"
            'mapCustBreakPy("jiangeng") = "jian"
            mapCustBreakPy("jiangu") = "jian"


            'mapCustBreakPy("liana") = "lia"  
            'mapCustBreakPy("lianai") = "lia"
            'mapCustBreakPy("lianao") = "lia"
            'mapCustBreakPy("lianan") = "lia"
            'mapCustBreakPy("lianang") = "lia"
            'mapCustBreakPy("lianou") = "lia"
            mapCustBreakPy("lianong") = "lia"
            'mapCustBreakPy("liane") = "lia"
            'mapCustBreakPy("lianer") = "lia"
            mapCustBreakPy("lianei") = "lia"
            'mapCustBreakPy("lianen") = "lia"
            'mapCustBreakPy("lianeng") = "lia"
            mapCustBreakPy("liani") = "lia"
            mapCustBreakPy("lianu") = "lia"
            mapCustBreakPy("lianv") = "lia"

            'mapCustBreakPy("lianga") = "lian"
            'mapCustBreakPy("liangai") = "lian"
            'mapCustBreakPy("liangao") = "lian"
            'mapCustBreakPy("liangan") = "lian"
            mapCustBreakPy("liangang") = "lian"
            'mapCustBreakPy("liango") = "lian"
            'mapCustBreakPy("liangou") = "lian"
            mapCustBreakPy("liangong") = "lian"
            mapCustBreakPy("liange") = "lian"
            mapCustBreakPy("lianger") = "liang"
            'mapCustBreakPy("liangei") = "lian"
            'mapCustBreakPy("liangen") = "lian"
            'mapCustBreakPy("liangeng") = "lian"
            mapCustBreakPy("liangu") = "lian"


            mapCustBreakPy("xiani") = "xia"
            mapCustBreakPy("xianu") = "xia"
            mapCustBreakPy("xianv") = "xia"
            mapCustBreakPy("xianei") = "xia"
            mapCustBreakPy("xianong") = "xia"
            mapCustBreakPy("xiangong") = "xian"
            mapCustBreakPy("xiange") = "xian"
            mapCustBreakPy("xianger") = "xiang"
            mapCustBreakPy("xiangu") = "xian"


            mapCustBreakPy("biani") = "bi"
            mapCustBreakPy("bianu") = "bi"
            mapCustBreakPy("bianv") = "bi"


            'mapCustBreakPy("niana") = "ni"  
            'mapCustBreakPy("nianai") = "ni"
            'mapCustBreakPy("nianao") = "ni"
            'mapCustBreakPy("nianan") = "ni"
            'mapCustBreakPy("nianang") = "ni"
            'mapCustBreakPy("nianou") = "ni"
            mapCustBreakPy("nianong") = "ni"
            'mapCustBreakPy("niane") = "ni"
            'mapCustBreakPy("nianer") = "ni"
            mapCustBreakPy("nianei") = "ni"
            'mapCustBreakPy("nianen") = "ni"
            'mapCustBreakPy("nianeng") = "ni"
            mapCustBreakPy("niani") = "ni"
            mapCustBreakPy("nianu") = "ni"
            mapCustBreakPy("nianv") = "ni"

            'mapCustBreakPy("nianga") = "nian"
            mapCustBreakPy("niangai") = "nian"
            mapCustBreakPy("niangao") = "nian"
            mapCustBreakPy("niangan") = "nian"
            'mapCustBreakPy("niangang") = "nian"
            'mapCustBreakPy("niango") = "nian"
            mapCustBreakPy("niangou") = "nian"
            mapCustBreakPy("niangong") = "nian"
            mapCustBreakPy("niange") = "nian"
            mapCustBreakPy("nianger") = "niang"
            'mapCustBreakPy("niangei") = "nian"
            'mapCustBreakPy("niangen") = "nian"
            'mapCustBreakPy("niangeng") = "nian"
            mapCustBreakPy("niangu") = "nian"

            mapCustBreakPy("miani") = "mi"
            mapCustBreakPy("mianu") = "mi"
            mapCustBreakPy("mianv") = "mi"


            mapCustBreakPy("quani") = "qu"
            mapCustBreakPy("quanu") = "qu"
            mapCustBreakPy("quanv") = "qu"

            mapCustBreakPy("ruani") = "ru"
            mapCustBreakPy("ruanu") = "ru"
            mapCustBreakPy("ruanv") = "ru"

            mapCustBreakPy("tuani") = "tu"
            mapCustBreakPy("tuanu") = "tu"
            mapCustBreakPy("tuanv") = "tu"

            mapCustBreakPy("yuani") = "yu"
            mapCustBreakPy("yuanu") = "yu"
            mapCustBreakPy("yuanv") = "yu"


            mapCustBreakPy("suani") = "su"
            mapCustBreakPy("suanu") = "su"
            mapCustBreakPy("suanv") = "su"

            mapCustBreakPy("shuanong") = "shua"
            mapCustBreakPy("shuanei") = "shua"
            mapCustBreakPy("shuani") = "shu"
            mapCustBreakPy("shuanu") = "shu"
            mapCustBreakPy("shuanv") = "shu"
            mapCustBreakPy("shuangei") = "shuan"
            mapCustBreakPy("shuangi") = "shuan"
            mapCustBreakPy("shuangu") = "shuan"
            mapCustBreakPy("shuou") = "shu"


            mapCustBreakPy("duani") = "du"
            mapCustBreakPy("duanu") = "du"
            mapCustBreakPy("duanv") = "du"
            mapCustBreakPy("duou") = "du"


            'mapCustBreakPy("guana") = "gua"  
            'mapCustBreakPy("guanai") = "gua"
            'mapCustBreakPy("guanao") = "gua"
            mapCustBreakPy("guanan") = "gua"
            'mapCustBreakPy("guanang") = "gua"
            'mapCustBreakPy("guanou") = "gua"
            mapCustBreakPy("guanong") = "gua"
            'mapCustBreakPy("guane") = "gua"
            'mapCustBreakPy("guaner") = "gua"
            mapCustBreakPy("guanei") = "gua"
            'mapCustBreakPy("guanen") = "gua"
            'mapCustBreakPy("guaneng") = "gua"
            mapCustBreakPy("guani") = "gu"
            mapCustBreakPy("guanu") = "gu"
            mapCustBreakPy("guanv") = "gu"
            mapCustBreakPy("guou") = "gu"

            'mapCustBreakPy("guanga") = "guan"
            mapCustBreakPy("guangai") = "guan"
            mapCustBreakPy("guangao") = "guan"
            mapCustBreakPy("guangan") = "guan"
            'mapCustBreakPy("guangang") = "guan"
            'mapCustBreakPy("guango") = "guan"
            mapCustBreakPy("guangou") = "guan"
            mapCustBreakPy("guangong") = "guan"
            'mapCustBreakPy("guange") = "guan"
            'mapCustBreakPy("guanger") = "guang"
            mapCustBreakPy("guangei") = "guan"
            mapCustBreakPy("guangen") = "guan"
            'mapCustBreakPy("guangeng") = "guan"
            mapCustBreakPy("guangu") = "guan"


            'mapCustBreakPy("huana") = "hua"  
            'mapCustBreakPy("huanai") = "hua"
            mapCustBreakPy("huanao") = "hua"
            mapCustBreakPy("huanan") = "hua"
            'mapCustBreakPy("huanang") = "hua"
            'mapCustBreakPy("huanou") = "hua"
            mapCustBreakPy("huanong") = "hua"
            mapCustBreakPy("huane") = "hua"
            mapCustBreakPy("huaner") = "hua"
            'mapCustBreakPy("huanei") = "hua"
            'mapCustBreakPy("huanen") = "hua"
            'mapCustBreakPy("huaneng") = "hua"
            mapCustBreakPy("huani") = "hu"
            mapCustBreakPy("huanu") = "hu"
            mapCustBreakPy("huanv") = "hu"
            mapCustBreakPy("huou") = "hu"

            'mapCustBreakPy("huanga") = "huan"
            'mapCustBreakPy("huangai") = "huan"
            'mapCustBreakPy("huangao") = "huan"
            'mapCustBreakPy("huangan") = "huan"
            'mapCustBreakPy("huangang") = "huan"
            'mapCustBreakPy("huango") = "huan"
            'mapCustBreakPy("huangou") = "huan"
            mapCustBreakPy("huangong") = "huan"
            mapCustBreakPy("huange") = "huan"
            mapCustBreakPy("huanger") = "huang"
            'mapCustBreakPy("huangei") = "huan"
            mapCustBreakPy("huangen") = "huang"
            'mapCustBreakPy("huangeng") = "huan"
            mapCustBreakPy("huangu") = "huan"


            mapCustBreakPy("juani") = "ju"
            mapCustBreakPy("juanu") = "ju"
            mapCustBreakPy("juanv") = "ju"


            'mapCustBreakPy("kuana") = "kua"  
            'mapCustBreakPy("kuanai") = "kua"
            'mapCustBreakPy("kuanao") = "kua"
            'mapCustBreakPy("kuanan") = "kua"
            'mapCustBreakPy("kuanang") = "kua"
            'mapCustBreakPy("kuanou") = "kua"
            mapCustBreakPy("kuanong") = "kua"
            'mapCustBreakPy("kuane") = "kua"
            'mapCustBreakPy("kuaner") = "kua"
            mapCustBreakPy("kuanei") = "kua"
            'mapCustBreakPy("kuanen") = "kua"
            'mapCustBreakPy("kuaneng") = "kua"
            mapCustBreakPy("kuani") = "ku"
            mapCustBreakPy("kuanu") = "ku"
            mapCustBreakPy("kuanv") = "ku"
            mapCustBreakPy("kuou") = "ku"

            'mapCustBreakPy("kuanga") = "kuan"
            'mapCustBreakPy("kuangai") = "kuan"
            'mapCustBreakPy("kuangao") = "kuan"
            'mapCustBreakPy("kuangan") = "kuan"
            'mapCustBreakPy("kuangang") = "kuan"
            'mapCustBreakPy("kuango") = "kuan"
            mapCustBreakPy("kuangou") = "kuan"
            mapCustBreakPy("kuangong") = "kuan"
            'mapCustBreakPy("kuange") = "kuan"
            'mapCustBreakPy("kuanger") = "kuang"
            mapCustBreakPy("kuangei") = "kuan"
            'mapCustBreakPy("kuangen") = "kuang"
            'mapCustBreakPy("kuangeng") = "kuan"
            mapCustBreakPy("kuangu") = "kuan"


            mapCustBreakPy("luani") = "lu"
            mapCustBreakPy("luanu") = "lu"
            mapCustBreakPy("luanv") = "lu"
            mapCustBreakPy("luou") = "lu"

            mapCustBreakPy("zuani") = "zu"
            mapCustBreakPy("zuanu") = "zu"
            mapCustBreakPy("zuanv") = "zu"
            mapCustBreakPy("zhuani") = "zhua"
            mapCustBreakPy("zhuanu") = "zhua"
            mapCustBreakPy("zhuanv") = "zhua"
            mapCustBreakPy("zhuangi") = "zhuan"
            mapCustBreakPy("zhuangu") = "zhuan"
            mapCustBreakPy("zhuou") = "zhu"

            mapCustBreakPy("xuani") = "xu"
            mapCustBreakPy("xuanu") = "xu"
            mapCustBreakPy("xuanv") = "xu"

            mapCustBreakPy("cuani") = "cu"
            mapCustBreakPy("cuanu") = "cu"
            mapCustBreakPy("cuanv") = "cu"
            mapCustBreakPy("chuani") = "chu"
            mapCustBreakPy("chuanu") = "chu"
            mapCustBreakPy("chuanv") = "chu"
            mapCustBreakPy("chuangi") = "chuan"
            mapCustBreakPy("chuangu") = "chuan"
            mapCustBreakPy("chuou") = "chu"

            mapCustBreakPy("nuani") = "nu"
            mapCustBreakPy("nuanu") = "nu"
            mapCustBreakPy("nuanv") = "nu"
            mapCustBreakPy("nuou") = "nu"

            mapStartWithNoEr("qine") = "qi"
            mapStartWithNoEr("qinge") = "qin"
            mapStartWithNoEr("yinge") = "yin"
            mapStartWithNoEr("pine") = "pi"
            mapStartWithNoEr("pinge") = "pin"
            mapStartWithNoEr("line") = "li"
            mapStartWithNoEr("linge") = "lin"
            mapStartWithNoEr("xinge") = "xin"
            mapStartWithNoEr("binge") = "bin"
            mapStartWithNoEr("nine") = "ni"
            mapStartWithNoEr("ninge") = "nin"
            mapStartWithNoEr("wenge") = "wen"
            mapStartWithNoEr("rene") = "re"
            mapStartWithNoEr("renge") = "ren"
            mapStartWithNoEr("sene") = "se"
            mapStartWithNoEr("shene") = "she"
            mapStartWithNoEr("dene") = "de"
            mapStartWithNoEr("gene") = "ge"
            mapStartWithNoEr("kene") = "ke"
            mapStartWithNoEr("fenge") = "fen"
            mapStartWithNoEr("zenge") = "zen"
            mapStartWithNoEr("zhene") = "zhe"
            mapStartWithNoEr("zhenge") = "zhen"
            mapStartWithNoEr("cene") = "ce"
            mapStartWithNoEr("chene") = "che"
            mapStartWithNoEr("mene") = "me"
            mapStartWithNoEr("wange") = "wan"
            mapStartWithNoEr("tane") = "ta"
            mapStartWithNoEr("tange") = "tan"
            mapStartWithNoEr("pane") = "pa"
            mapStartWithNoEr("sange") = "san"
            mapStartWithNoEr("shange") = "shan"
            mapStartWithNoEr("dane") = "da"
            mapStartWithNoEr("dange") = "dan"
            mapStartWithNoEr("gange") = "gan"
            mapStartWithNoEr("kange") = "kan"
            mapStartWithNoEr("zange") = "zan"

            mapCustBreakPy("bier") = "bi"
            mapCustBreakPy("dier") = "di"
            mapCustBreakPy("huaner") = "huan"
            mapCustBreakPy("pier") = "pi"
            mapCustBreakPy("qier") = "qi"
            mapCustBreakPy("quer") = "qu"
            mapCustBreakPy("qiner") = "qin"
            mapCustBreakPy("qinger") = "qing"
            mapCustBreakPy("yinger") = "ying"
            mapCustBreakPy("piner") = "pin"
            mapCustBreakPy("pinger") = "ping"
            mapCustBreakPy("liner") = "lin"
            mapCustBreakPy("lier") = "li"
            mapCustBreakPy("luer") = "lu"
            mapCustBreakPy("linger") = "ling"
            mapCustBreakPy("xinger") = "xing"
            mapCustBreakPy("binger") = "bing"
            mapCustBreakPy("mier") = "mi"
            mapCustBreakPy("nier") = "ni"
            mapCustBreakPy("nuer") = "nu"
            mapCustBreakPy("niner") = "nin"
            mapCustBreakPy("ninger") = "ning"
            mapCustBreakPy("wenger") = "weng"
            mapCustBreakPy("rener") = "ren"
            mapCustBreakPy("renger") = "reng"
            mapCustBreakPy("sener") = "sen"
            mapCustBreakPy("shener") = "shen"
            mapCustBreakPy("dener") = "den"
            mapCustBreakPy("gener") = "gen"
            mapCustBreakPy("jier") = "ji"
            mapCustBreakPy("tier") = "ti"
            mapCustBreakPy("juer") = "ju"
            mapCustBreakPy("kener") = "ken"
            mapCustBreakPy("fenger") = "feng"
            mapCustBreakPy("zenger") = "zeng"
            mapCustBreakPy("zhener") = "zhen"
            mapCustBreakPy("zhenger") = "zheng"
            mapCustBreakPy("cener") = "cen"
            mapCustBreakPy("chener") = "chen"
            mapCustBreakPy("mener") = "men"
            mapCustBreakPy("wanger") = "wang"
            mapCustBreakPy("taner") = "tan"
            mapCustBreakPy("tanger") = "tang"
            mapCustBreakPy("paner") = "pan"
            mapCustBreakPy("sanger") = "sang"
            mapCustBreakPy("shanger") = "shang"
            mapCustBreakPy("daner") = "dan"
            mapCustBreakPy("danger") = "dang"
            mapCustBreakPy("ganger") = "gang"
            mapCustBreakPy("kanger") = "kang"
            mapCustBreakPy("zanger") = "zang"
            mapCustBreakPy("xier") = "xi"
            mapCustBreakPy("xuer") = "xu"
            mapCustBreakPy("yuer") = "yu"

        End If

        Dim sKey As String

        If codes.Length >= 14 Then
            sKey = Strings.Left(codes, 14)
            If mapCustBreakPy.ContainsKey(sKey) Then
                Return mapCustBreakPy(sKey)
            End If
        End If
        'If codes.Length >= 13 Then
        '    sKey = Strings.Left(codes, 13)
        '    If mapCustBreakPy.ContainsKey(sKey) Then
        '        Return mapCustBreakPy(sKey)
        '    End If
        'End If
        If codes.Length >= 12 Then
            sKey = Strings.Left(codes, 12)
            If mapCustBreakPy.ContainsKey(sKey) Then
                Return mapCustBreakPy(sKey)
            End If
        End If
        If codes.Length >= 11 Then
            sKey = Strings.Left(codes, 11)
            If mapCustBreakPy.ContainsKey(sKey) Then
                Return mapCustBreakPy(sKey)
            End If
        End If
        If codes.Length >= 10 Then
            sKey = Strings.Left(codes, 10)
            If mapCustBreakPy.ContainsKey(sKey) Then
                Return mapCustBreakPy(sKey)
            End If
        End If


        If codes.Length >= 8 Then
            sKey = Strings.Left(codes, 8)
            If mapCustBreakPy.ContainsKey(sKey) Then
                Return mapCustBreakPy(sKey)
            End If
        End If

        If codes.Length >= 7 Then
            sKey = Strings.Left(codes, 7)
            If mapCustBreakPy.ContainsKey(sKey) Then
                Return mapCustBreakPy(sKey)
            End If
        End If

        If codes.Length >= 6 Then
            sKey = Strings.Left(codes, 6)
            If mapCustBreakPy.ContainsKey(sKey) Then
                Return mapCustBreakPy(sKey)
            End If

            If mapStartWithNoEr.ContainsKey(sKey) Then
                Return mapStartWithNoEr(sKey)
            End If

        End If

        If codes.Length >= 5 Then
            sKey = Strings.Left(codes, 5)
            If mapCustBreakPy.ContainsKey(sKey) Then
                Return mapCustBreakPy(sKey)
            End If

            If mapStartWithNoEr.ContainsKey(sKey) Then
                Return mapStartWithNoEr(sKey)
            End If

            ' 仅模糊音适用 din
            If P_IN_ING Then
                If codes.StartsWith("dingang") OrElse codes.StartsWith("dingou") _
                    OrElse codes.StartsWith("dingong") OrElse codes.StartsWith("dingu") _
                    OrElse (codes.StartsWith("dinge") AndAlso Not codes.StartsWith("dinger")) Then
                    Return "din"
                End If
            End If

        End If

        If codes.Length >= 4 Then
            sKey = Strings.Left(codes, 4)
            If mapCustBreakPy.ContainsKey(sKey) Then
                Return mapCustBreakPy(sKey)
            End If

            If mapStartWithNoEr.ContainsKey(sKey) Then
                Return mapStartWithNoEr(sKey)
            End If
        End If

        If codes.Length >= 3 Then
            sKey = Strings.Left(codes, 3)
            If mapCustBreakPy.ContainsKey(sKey) Then
                Return mapCustBreakPy(sKey)
            End If
        End If

        Return ""

    End Function

    ''' <summary>
    ''' 取得一个正确的单字拼音
    ''' </summary>
    ''' <param name="codes">拼音编码（无分隔符）</param>
    ''' <returns>单字拼音（完全误拼返回空串）</returns>
    Private Function GetRightPy(ByVal codes As String) As String

        Dim custBk As String = GetCustBreakPy(codes)
        If Not "".Equals(custBk) Then
            Return custBk
        End If


        Dim sKey As String
        If codes.Length >= 6 Then
            sKey = Strings.Left(codes, 6)
            If mapPy(sKey) Then
                Return sKey
            End If
        End If

        If codes.Length >= 5 Then
            sKey = Strings.Left(codes, 5)
            If mapPy(sKey) Then
                Return sKey
            End If
        End If

        If codes.Length >= 4 Then
            sKey = Strings.Left(codes, 4)
            If mapPy(sKey) Then
                Return sKey
            End If
        End If

        If codes.Length >= 3 Then
            sKey = Strings.Left(codes, 3)
            If mapPy(sKey) Then
                Return sKey
            End If

            ' 实际没有 din 这个拼音，仅为模糊音 in=ing 用
            If P_IN_ING AndAlso sKey.Equals("din") Then
                 Return sKey
            End If

            ' 仅模糊音适用 zua, cua, sua
            If P_ZCS_ZHCHSH Then
                If codes.StartsWith("zua") OrElse codes.StartsWith("cua") OrElse codes.StartsWith("sua") Then
                    Return sKey
                End If
            End If

        End If

        If codes.Length >= 2 Then
            sKey = Strings.Left(codes, 2)
            If mapPy(sKey) Then
                Return sKey
            End If
        End If

        If codes.Length >= 1 Then
            sKey = Strings.Left(codes, 1)
            If mapPy(sKey) Then
                Return sKey
            End If
        End If

        Return ""
    End Function

    ''' <summary>
    ''' 合法单字拼音
    ''' </summary>
    ''' <returns>合法单字拼音</returns>
    Private Function GetRightWordPyMap() As Hashtable
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
        map("huang") = True
        'map("zh") = True
        'map("ch") = True
        'map("sh") = True
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
        map("lue") = True
        map("nue") = True
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
        map("kei") = True

        Return map
    End Function

End Module
