''' <summary>
''' 淡定拼音输入法输入逻辑封装类
''' </summary>
Friend Class CDandingPy

    Private vDispWordText As String = ""
    Private vDispPyText As String = ""
    Private vDispPyText2 As String = ""

    Private vErrorPys As String = ""
    Private vInputPys As String = ""
    Private vWordList As List(Of CWord)
    Private vWordStack As New Stack(Of CWord)
    Private vIsFinish As Boolean
    Private vMaxPageCnt As Integer = P_MAX_PAGE_CNT
    Private vMaxPyLen As Integer = P_MAX_PY_LEN
    Private vCurrentPage As Integer
    Private vFocusCand As Integer

    Private vTextEndChar As String = ""
    Private vTip As String = ""

    Private aryRegisterWordText As String()
    Private aryRegisterWordPy As String()

    Private vHasInput As Boolean = True

    Private vHasDigitComp As Boolean = False
    Private vScriptModeTitle As String
    Private vHasChange As Boolean = False

    Public Function GetFocusWord() As CWord
        Dim words As CWord() = GetCandWords()
        If words.Length = 0 OrElse words.Length < FocusCand OrElse FocusCand <= 0 Then
            Return Nothing
        End If
        Return words(FocusCand - 1)
    End Function

    Public Property HasChange() As Boolean
        Get
            Return vHasChange
        End Get
        Set(ByVal Value As Boolean)
            vHasChange = Value
        End Set
    End Property

    Public Property ScriptModeTitle() As String
        Get
            Return vScriptModeTitle
        End Get
        Set(ByVal Value As String)
            vScriptModeTitle = Value
        End Set
    End Property


    Public Property HasDigitComp() As Boolean
        Get
            Return vHasDigitComp
        End Get
        Set(ByVal Value As Boolean)
            vHasDigitComp = Value
        End Set
    End Property

    Public Function HasInput() As Boolean
        Return vInputPys.Length > 0 OrElse vDispPyText.Length > 0 OrElse vDispPyText2.Length > 0
    End Function

    Public Function HasStackWord() As Boolean
        Return vWordStack.Count > 0
    End Function

    Public Property Tip() As String
        Get
            Return vTip
        End Get
        Set(ByVal Value As String)
            vTip = Value
        End Set
    End Property

    ''' <summary>
    ''' 编辑状态下编码栏光标右边的灰色拼音
    ''' </summary>
    ''' <value>灰色拼音</value>
    ''' <returns>灰色拼音</returns>
    Public Property DispPyText2() As String
        Get
            Return vDispPyText2
        End Get
        Set(ByVal Value As String)
            vDispPyText2 = Value
        End Set
    End Property

    ''' <summary>
    ''' 编码栏光标左移一位
    ''' （移动光标编辑编码时插入空格作为分词符）
    ''' </summary>
    ''' <param name="bDel">是否删除该编码（True时相当于按退格键）</param>
    Public Function MoveCurLeft(Optional ByVal bDel As Boolean = False) As Boolean
        If vInputPys.Length = 0 OrElse (P_I_MODE AndAlso vInputPys.Equals("i")) Then
            Return False
        End If

        vInputPys = Trim(vInputPys)

        If bDel Then
            If P_I_MODE AndAlso vInputPys.Equals("i") Then
                Return False
            End If

            vInputPys = Strings.Left(vInputPys, vInputPys.Length - 1)
            If P_I_MODE AndAlso vInputPys.StartsWith("i") Then
                vDispPyText = vInputPys
            End If
        ElseIf P_I_MODE AndAlso vInputPys.StartsWith("i") Then
            If vInputPys.Equals("i") Then
                Return False
            End If

            vDispPyText2 = Strings.Right(vInputPys, 1) & vDispPyText2
            vInputPys = Strings.Left(vInputPys, vInputPys.Length - 1)
            vDispPyText = vInputPys
        ElseIf vDispPyText = "" Then
            PopWord()
        Else

            Dim sMove As String = ""

            If My.Computer.Keyboard.CtrlKeyDown Then

                Dim py As String
                Dim bEndsWithQuote As Boolean = vDispPyText.EndsWith("'")
                If bEndsWithQuote Then
                    py = BreakPys(vDispPyText.Substring(0, vDispPyText.Length - 1))
                Else
                    py = BreakPys(vDispPyText)
                End If

                If py.IndexOf(" ") > 0 Then
                    ' 如果有误拼就只左移一位
                    sMove = Strings.Right(vDispPyText, 1)
                Else
                    ' 如果没有误拼则左移一个音节
                    Dim aryPys As String() = py.Split("'")
                    Dim iLen As Integer = aryPys(aryPys.Length - 1).Length  '  最后一个音节长度
                    If bEndsWithQuote Then
                        iLen = iLen + 1
                    End If
                    sMove = Strings.Right(vDispPyText, iLen)
                End If
            Else
                sMove = Strings.Right(vDispPyText, 1)
            End If


            vDispPyText2 = sMove & vDispPyText2
            vInputPys = Strings.Left(vInputPys, vInputPys.Length - sMove.Length)

        End If

        ExecuteSearch()

        Return True
    End Function

    Public Function MoveCurHome() As Boolean
        If vInputPys.Length = 0 OrElse (P_I_MODE AndAlso "i".Equals(Trim(vInputPys))) Then
            Return False
        End If

        If P_I_MODE AndAlso vInputPys.StartsWith("i") Then
            vDispPyText2 = Trim(vInputPys.Substring(1) & vDispPyText2)
            vInputPys = "i"
            vDispPyText = ""
            ExecuteSearch()
            Return True
        End If


        If HasStackWord() Then
            vDispPyText2 = (vDispPyText & vDispPyText2).Replace(" ", "")
            vInputPys = Strings.Left(vInputPys, vInputPys.Length - vDispPyText.Length)
        Else
            vDispPyText2 = (vInputPys & vDispPyText2).Replace(" ", "")
            vInputPys = ""
        End If

        ExecuteSearch()

        Return True
    End Function

    ''' <summary>
    ''' 编码栏光标右移一位
    ''' （移动光标编辑编码时插入空格作为分词符）
    ''' </summary>
    Public Function MoveCurRight() As Boolean
        If vDispPyText2.Length <= 0 Then
            Return False
        End If

        If P_I_MODE AndAlso vInputPys.StartsWith("i") Then
            If vDispPyText2.Length > 0 Then
                vInputPys = vInputPys & Strings.Left(vDispPyText2, 1)
                vDispPyText2 = vDispPyText2.Substring(1)
            End If
        ElseIf My.Computer.Keyboard.CtrlKeyDown Then
            Dim py As String
            Dim bStartsWithQuote As Boolean = vDispPyText2.StartsWith("'")
            If bStartsWithQuote Then
                py = Strings.Split(BreakPys(vDispPyText2.Substring(1)), " ")(0)
            Else
                py = Strings.Split(BreakPys(vDispPyText2), " ")(0)
            End If
            If py.Length > 0 Then
                py = Strings.Split(py, "'")(0)
                If bStartsWithQuote Then
                    py = "'" & py
                End If

                If vDispPyText2.Length > py.Length AndAlso "'".Equals(vDispPyText2.Substring(py.Length, 1)) Then
                    py = py & "'"
                End If

            Else
                py = Strings.Left(vDispPyText2, 1)
            End If

            If vInputPys.Length > 0 AndAlso vDispPyText.Length = 0 AndAlso Not " '".Contains(Strings.Right(vInputPys, 1)) Then
                vInputPys = vInputPys & " " & py
            Else
                vInputPys = vInputPys & py
            End If
            vDispPyText2 = vDispPyText2.Substring(py.Length)
        Else
            If vInputPys.Length > 0 AndAlso vDispPyText.Length = 0 AndAlso Not " '".Contains(Strings.Right(vInputPys, 1)) Then
                vInputPys = vInputPys & " " & Strings.Left(vDispPyText2, 1)
            Else
                vInputPys = vInputPys & Strings.Left(vDispPyText2, 1)
            End If
            vDispPyText2 = vDispPyText2.Substring(1)
        End If

        ExecuteSearch()

        Return True
    End Function

    Public Function MoveCurEnd() As Boolean
        If vDispPyText2.Length = 0 Then
            Return False
        End If

        If (P_I_MODE AndAlso vInputPys.StartsWith("i")) OrElse vDispPyText.Length > 0 OrElse vInputPys.Length = 0 OrElse vInputPys.EndsWith(" ") OrElse vInputPys.EndsWith("'") Then
            vInputPys = vInputPys & vDispPyText2
        Else
            vInputPys = vInputPys & " " & vDispPyText2
        End If
        vDispPyText2 = ""

        ExecuteSearch()

        Return True
    End Function


    ''' <summary>
    ''' 初始化
    ''' </summary>
    Public Sub Clear()
        vDispWordText = ""
        vDispPyText = ""
        vErrorPys = ""
        vInputPys = ""
        vWordList = Nothing
        vWordStack.Clear()
        vIsFinish = False
        vCurrentPage = 1
        vFocusCand = 1
        vTextEndChar = ""
        vDispPyText2 = ""
        vTip = ""
    End Sub

    ''' <summary>
    ''' 附加在末尾的待上屏字符
    ''' </summary>
    ''' <value>附加在末尾的待上屏字符</value>
    ''' <returns>附加在末尾的待上屏字符</returns>
    Public Property TextEndChar() As String
        Get
            Return vTextEndChar
        End Get
        Set(ByVal Value As String)
            vTextEndChar = Value
        End Set
    End Property

    ''' <summary>
    ''' 候选文字编号（1～9）
    ''' </summary>
    ''' <value>候选文字编号</value>
    ''' <returns>候选文字编号</returns>
    Public Property FocusCand() As Integer
        Get
            Return vFocusCand
        End Get
        Set(ByVal Value As Integer)

            If Value <= 1 Then
                vFocusCand = 1
            ElseIf Value >= P_MAX_PAGE_CNT Then
                vFocusCand = P_MAX_PAGE_CNT
            Else
                vFocusCand = Value
            End If

            If (Not Me.WordList Is Nothing) AndAlso (Me.WordList.Count < (CurrentPage - 1) * P_MAX_PAGE_CNT + vFocusCand) Then
                vFocusCand = Me.WordList.Count - (CurrentPage - 1) * P_MAX_PAGE_CNT
            End If
        End Set
    End Property

    ''' <summary>
    ''' 前一个候选文字为焦点
    ''' </summary>
    Public Function FocusPreviousWord() As Boolean
        If Me.FocusCand <= 1 OrElse GetCandWords().Length <= 1 Then
            Return False
        Else
            Me.FocusCand = Me.FocusCand - 1
        End If

        Return True
    End Function

    ''' <summary>
    ''' 第一个候选文字为焦点
    ''' </summary>
    Public Sub FocusFirstWord()
        Me.FocusCand = 1
    End Sub

    ''' <summary>
    ''' 后一个候选文字为焦点
    ''' </summary>
    Public Function FocusNextWord() As Boolean
        If GetCandWords().Length <= Me.FocusCand Then
            Return False
        End If

        Me.FocusCand = Me.FocusCand + 1

        Return True
    End Function

    ''' <summary>
    ''' 输入的拼音编码
    ''' </summary>
    ''' <value>输入的拼音编码</value>
    ''' <returns>输入的拼音编码</returns>
    Public Property InputPys() As String
        Get
            Return vInputPys
        End Get
        Set(ByVal Value As String)
            vInputPys = Value
            vIsFinish = False
        End Set
    End Property

    ''' <summary>
    ''' 输入的拼音数组
    ''' </summary>
    ''' <value>输入的拼音数组</value>
    ''' <returns>输入的拼音数组</returns>
    Private ReadOnly Property InputPyAry() As String()
        Get
            Dim pys As String = vInputPys
            If pys.EndsWith(" ") Then
                pys = pys.Substring(0, pys.Length - 1)
            End If
            Dim aryPys As String() = BreakPys(pys.Replace(" ", "'")).Split(" ")
            If aryPys.Length > 1 Then
                vErrorPys = aryPys(1)
            Else
                vErrorPys = ""
            End If
            Return aryPys(0).Split("'")
        End Get
    End Property

    ''' <summary>
    ''' 取得候选文字数组
    ''' </summary>
    ''' <returns>候选文字数组</returns>
    Private Function GetCandWords() As CWord()

        Dim lst As New List(Of CWord)

        If WordList Is Nothing Then
            Return lst.ToArray
        End If

        Dim iStart As Integer = CurrentPage * P_MAX_PAGE_CNT - P_MAX_PAGE_CNT
        For i As Integer = 0 To P_MAX_PAGE_CNT - 1
            If WordList.Count > iStart + i Then
                lst.Add(WordList(iStart + i))
            End If
        Next

        Return lst.ToArray
    End Function

    ''' <summary>
    ''' 文字列表
    ''' </summary>
    ''' <value>文字列表</value>
    ''' <returns>文字列表</returns>
    Public Property WordList() As List(Of CWord)
        Get
            Return vWordList
        End Get
        Set(ByVal Value As List(Of CWord))
            vWordList = Value
        End Set
    End Property

    ''' <summary>
    ''' 选择文字
    ''' </summary>
    ''' <returns>成功/失败</returns>
    Public Function PushWord() As Boolean

        Dim words As CWord() = GetCandWords()
        If words.Length < 1 Then
            Return False
        ElseIf vFocusCand > words.Length Then
            vFocusCand = 1
        End If
        Dim word As CWord = words(vFocusCand - 1)
        vWordStack.Push(word)

        If vInputPys.StartsWith("i") Then

            If word.PinYin.Length > 0 Then
                vInputPys = vInputPys & word.PinYin
                vDispPyText = vInputPys
                vWordList = Nothing
            Else
                vDispWordText = word.Text
                vDispPyText = ""
                vDispPyText2 = ""
                vTextEndChar = ""
            End If

        ElseIf word.IsMixWord Then
            vDispWordText = word.Text
            vDispPyText = ""
            vDispPyText2 = ""
            vTextEndChar = ""
        Else
            vDispWordText = GetDispWordText()

            If vDispPyText.Length = 0 AndAlso vDispPyText2.Length > 0 Then

                If vInputPys.EndsWith(" ") OrElse vInputPys.EndsWith("'") Then
                    vInputPys = vInputPys & vDispPyText2
                Else
                    vInputPys = vInputPys & " " & vDispPyText2
                End If

                ' 剩余拼音更新为vDispPyText2，vDispPyText还是显示空
                vDispPyText = GetDispPyText(False)  ' vInputPys不拼接vDispPyText
                vDispPyText2 = vDispPyText
                vDispPyText = ""
            Else
                vDispPyText = GetDispPyText()
            End If

        End If

        If vDispPyText = "" AndAlso vDispPyText2 = "" Then
            vIsFinish = True
        Else
            vIsFinish = False
        End If

        Return True
    End Function

    ''' <summary>
    ''' 取消最近选择的文字
    ''' </summary>
    ''' <returns>最近选择的文字</returns>
    Public Function PopWord() As CWord
        Dim word As CWord = Nothing
        If vWordStack.Count > 0 Then
            word = vWordStack.Pop()
        End If

        vDispWordText = GetDispWordText()
        vDispPyText = GetDispPyText()
        vIsFinish = False

        Return word
    End Function

    ''' <summary>
    ''' 编码全部转换完成的标记
    ''' </summary>
    ''' <returns>转换完成标记</returns>
    Public ReadOnly Property IsFinish() As Boolean
        Get
            Return vIsFinish
        End Get
    End Property

    ''' <summary>
    ''' 当前显示文本（不含光标右边的灰色拼音编码）
    ''' </summary>
    ''' <returns>当前显示文本（不含光标右边的灰色拼音编码）</returns>
    Public ReadOnly Property Text() As String
        Get
            If P_I_MODE AndAlso vInputPys.StartsWith("i") AndAlso (vDispWordText & vDispPyText).Length = 0 Then
                Return vInputPys
            End If
            Return vDispWordText & vDispPyText
        End Get
    End Property

    ''' <summary>
    ''' 当前已转换文字
    ''' </summary>
    ''' <returns>当前已转换文字</returns>
    Public ReadOnly Property DispWordText() As String
        Get
            Return vDispWordText
        End Get
    End Property

    ''' <summary>
    ''' 当前待转换拼音编码
    ''' </summary>
    ''' <returns>当前待转换拼音编码</returns>
    Public ReadOnly Property DispPyText() As String
        Get
            Return vDispPyText
        End Get
    End Property

    ''' <summary>
    ''' 用户输入的文字（vbTab分割的拼音 + vbLf + vbTab分割的文字）
    ''' </summary>
    ''' <returns>用户输入的文字</returns>
    Public ReadOnly Property InputWord() As String
        Get
            Return Strings.Join(aryRegisterWordPy, vbTab) & vbLf & Strings.Join(aryRegisterWordText, vbTab)
        End Get
    End Property

    ''' <summary>
    ''' 取得已转换文字
    ''' </summary>
    ''' <returns>已转换文字</returns>
    Private Function GetDispWordText() As String
        Dim txt As String = ""

        Dim lstTxt As New List(Of String)
        Dim lstPy As New List(Of String)
        Dim py As String = ""

        Dim words As CWord() = vWordStack.ToArray()
        For i As Integer = 0 To words.Length - 1
            txt = words(i).Text & txt

            lstTxt.Add(words(i).Text)
            lstPy.Add(words(i).PinYin)

            If i = 0 Then
                py = words(i).PinYin
            Else
                py = words(i).PinYin & "'" & py
            End If
        Next

        lstTxt.Add(txt)
        lstPy.Add(py)

        aryRegisterWordText = lstTxt.ToArray
        aryRegisterWordPy = lstPy.ToArray

        Return txt
    End Function

    ''' <summary>
    ''' 取得输入的剩余待转换拼音
    ''' </summary>
    ''' <returns>输入的剩余待转换拼音</returns>
    Private Function GetDispPyText(Optional ByVal bHasDispPyText As Boolean = True) As String

        If P_I_MODE AndAlso vInputPys.StartsWith("i") Then
            Return vInputPys
        End If

        If vWordStack Is Nothing OrElse vWordStack.Count = 0 Then
            vInputPys = vInputPys.Replace(" ", "")
            Return vInputPys
        End If

        Dim pys As String() = InputPyAry        ' 按程序规则分割的正确部分拼音
        Dim iPy As Integer = 0                  ' 词条堆栈中共多少个音节
        Dim wordsPys As String = ""             ' 由词条堆栈中音节数算出的对应编码

        For i As Integer = 0 To vWordStack.Count - 1
            iPy = iPy + vWordStack.ElementAt(i).PinYin.Split("'").Length
        Next

        For i As Integer = 0 To iPy - 1
            wordsPys = wordsPys & pys(i)
        Next

        Dim tar As String = ""
        For i As Integer = wordsPys.Length To vInputPys.Length
            If wordsPys.Equals(Strings.Left(vInputPys, i).Replace("'", "").Replace(" ", "")) Then
                tar = vInputPys.Substring(i)
                If vInputPys.Length > i AndAlso "'".Equals(vInputPys.Substring(i, 1)) Then
                    wordsPys = Strings.Left(vInputPys, i + 1)
                Else
                    wordsPys = Strings.Left(vInputPys, i)
                End If

                Exit For
            End If
        Next

        If tar.StartsWith("'") Then
            tar = tar.Substring(1)
        End If
        tar = tar.Replace(" ", "")

        If bHasDispPyText Then
            If wordsPys.EndsWith("'") Then
                vInputPys = Trim(wordsPys & tar)
            Else
                vInputPys = Trim(wordsPys & " " & tar)
            End If
        Else
            vInputPys = Trim(wordsPys)
        End If

        Return tar
    End Function

    ''' <summary>
    ''' 当前页码
    ''' </summary>
    ''' <value>当前页码</value>
    ''' <returns>当前页码</returns>
    Public Property CurrentPage() As Integer
        Get
            Return vCurrentPage
        End Get
        Set(ByVal Value As Integer)
            vCurrentPage = Value
        End Set
    End Property

    ''' <summary>
    ''' 总页数
    ''' </summary>
    ''' <returns>总页数</returns>
    Public ReadOnly Property TotalPageCnt() As Integer
        Get
            If vWordList Is Nothing Then
                Return 0
            End If
            Return (vWordList.Count + vMaxPageCnt - 1) \ vMaxPageCnt
        End Get
    End Property

    ''' <summary>
    ''' 执行检索
    ''' </summary>
    Public Sub ExecuteSearch()

        If P_I_MODE AndAlso vInputPys.StartsWith("i") Then
            vDispPyText = InputPys
            Me.WordList = SrvSearchWords(Trim(vInputPys.Substring(1)), True)
            Me.CurrentPage = 1
            Me.FocusCand = 1

            Return
        End If

        If SrvIsMixInput(Me.InputPys.Replace(" ", ""), Me.DispPyText2) Then
            vDispPyText = InputPys
            Me.WordList = SrvSearchMixWords(InputPys.Replace(" ", "") & vDispPyText2)
            Me.CurrentPage = 1
            Me.FocusCand = 1
            Return
        End If

        vDispPyText = GetDispPyText()

        ' 默认按编码栏光标左边的拼音检索
        Dim searchPy As String = vDispPyText
        If "".Equals(vDispPyText) AndAlso vDispWordText.Length > 0 Then
            ' 编码栏光标左边没有拼音时，按光标右边的拼音检索
            searchPy = vDispPyText2
        End If

        Dim recommendWord As CWord = Nothing

        Dim dspPys As String() = BreakPys(searchPy).Split(" ")
        If dspPys.Length > 1 Then
            vErrorPys = dspPys(1)
        Else
            vErrorPys = ""
        End If

        Dim lst As List(Of CWord) = SrvSearchWords(dspPys(0))


        Me.WordList = lst
        Me.CurrentPage = 1
        Me.FocusCand = 1
    End Sub


    ''' <summary>
    ''' 显示下一页
    ''' </summary>
    ''' <returns>成功/失败</returns>
    Public Function ShowNextPage() As Boolean
        Me.FocusCand = 1
        If Me.CurrentPage < Me.TotalPageCnt Then
            Me.CurrentPage = Me.CurrentPage + 1
            Return True
        End If

        'Me.CurrentPage = 1
        Return False
    End Function

    ''' <summary>
    ''' 显示前一页
    ''' </summary>
    ''' <returns>成功/失败</returns>
    Public Function ShowPreviousPage() As Boolean
        Me.FocusCand = 1
        If Me.CurrentPage > 1 Then
            Me.CurrentPage = Me.CurrentPage - 1
            Return True
        End If

        Me.CurrentPage = 1
        Return False
    End Function


End Class
