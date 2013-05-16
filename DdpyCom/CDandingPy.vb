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

    Private aryRegisterWordText As String()
    Private aryRegisterWordPy As String()

    Private vHasInput As Boolean = True

    Public Function HasInput() As Boolean
        Return vInputPys.Length > 0 OrElse vDispPyText.Length > 0 OrElse vDispPyText2.Length > 0
    End Function

    Public Function HasStackWord() As Boolean
        Return vWordStack.Count > 0
    End Function

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
    Public Sub MoveCurLeft(Optional ByVal bDel As Boolean = False)
        If vInputPys.Length <= 0 Then
            Return
        End If

        vInputPys = Strings.RTrim(vInputPys)

        If bDel Then

            vInputPys = Strings.Left(vInputPys, vInputPys.Length - 1)
        ElseIf vDispPyText = "" Then

            PopWord()
        Else

            Dim sMove As String = ""

            If My.Computer.Keyboard.CtrlKeyDown Then
                Dim pys As String = BreakPys(vInputPys)
                If pys.IndexOf(" ") > 0 Then
                    sMove = Strings.Right(vInputPys, 1)
                Else
                    Dim aryPys As String() = pys.Split("'")
                    Dim iLen As Integer = aryPys(aryPys.Length - 1).Length
                    sMove = Strings.Right(vInputPys, iLen)
                End If
            Else
                sMove = Strings.Right(vInputPys, 1)
            End If


            vDispPyText2 = sMove & vDispPyText2
            vInputPys = Strings.Left(vInputPys, vInputPys.Length - sMove.Length)

        End If

        ExecuteSearch()
    End Sub

    Public Sub MoveCurHome()
        If vInputPys.Length <= 0 Then
            Return
        End If


        If HasStackWord() Then
            vDispPyText2 = vDispPyText & vDispPyText2
            vInputPys = Strings.Left(vInputPys, vInputPys.Length - vDispPyText.Length)
        Else
            vDispPyText2 = vInputPys & vDispPyText2
            vInputPys = ""
        End If

        ExecuteSearch()
    End Sub

    ''' <summary>
    ''' 编码栏光标右移一位
    ''' （移动光标编辑编码时插入空格作为分词符）
    ''' </summary>
    Public Sub MoveCurRight()
        If vDispPyText2.Length <= 0 Then
            Return
        End If

        If vWordStack.Count > 0 AndAlso vDispPyText = "" AndAlso Not vInputPys.EndsWith(" ") Then
            vInputPys = vInputPys & " " & Strings.Left(vDispPyText2, 1)
            vDispPyText2 = Strings.Right(vDispPyText2, vDispPyText2.Length - 1)
        Else
            If My.Computer.Keyboard.CtrlKeyDown Then
                Dim py As String = Strings.Split(BreakPys(vDispPyText2), "'")(0)
                vInputPys = vInputPys & py
                vDispPyText2 = Strings.Right(vDispPyText2, vDispPyText2.Length - py.Length)
            Else
                vInputPys = vInputPys & Strings.Left(vDispPyText2, 1)
                vDispPyText2 = Strings.Right(vDispPyText2, vDispPyText2.Length - 1)
            End If
        End If

        ExecuteSearch()
    End Sub

    Public Sub MoveCurEnd()
        If vDispPyText2.Length <= 0 Then
            Return
        End If

        vInputPys = vInputPys & vDispPyText2
        vDispPyText2 = ""

        ExecuteSearch()
    End Sub


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
    Public Sub FocusPreviousWord()
        If Me.FocusCand <= 1 Then
            Me.FocusCand = 1
        Else
            Me.FocusCand = Me.FocusCand - 1
        End If
    End Sub

    ''' <summary>
    ''' 第一个候选文字为焦点
    ''' </summary>
    Public Sub FocusFirstWord()
        Me.FocusCand = 1
    End Sub

    ''' <summary>
    ''' 后一个候选文字为焦点
    ''' </summary>
    Public Sub FocusNextWord()
        Me.FocusCand = Me.FocusCand + 1
    End Sub

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
            Dim pys As String() = BreakPys(InputPys.Replace(" ", "'")).Split(" ")
            If pys.Length > 1 Then
                vErrorPys = pys(1)
            Else
                vErrorPys = ""
            End If
            Return pys(0).Split("'")
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


        If word.IsMixWord Then
            vDispWordText = word.Text
            vDispPyText = ""
            vDispPyText2 = ""
            vTextEndChar = ""
        Else
            vDispWordText = GetDispWordText()
            vDispPyText = GetDispPyText()
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
    Private Function GetDispPyText() As String

        If vWordStack Is Nothing OrElse vWordStack.Count = 0 Then
            Return InputPys.Replace(" ", "")
        End If

        Dim tmp As String = ""
        Dim pys As String() = InputPyAry
        Dim iPy As Integer = 0
        For i As Integer = 0 To vWordStack.Count - 1
            iPy = iPy + vWordStack.ElementAt(i).PinYin.Split("'").Length
        Next
        For i As Integer = 0 To iPy - 1
            tmp = tmp & pys(i)
        Next

        Dim tar As String = ""
        For i As Integer = tmp.Length To InputPys.Length
            If tmp.Equals(Strings.Left(InputPys, i).Replace("'", "").Replace(" ", "")) Then
                tar = InputPys.Substring(i)
            End If
        Next

        If tar.StartsWith("'") Then
            tar = tar.Substring(1)
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

        If SrvIsMixInput(Me.InputPys.Replace(" ", ""), Me.DispPyText2) Then
            vDispPyText = InputPys
            Me.WordList = SrvSearchMixWords(InputPys.Replace(" ", "") & vDispPyText2)
            Me.CurrentPage = 1
            Me.FocusCand = 1
            Return
        End If

        vDispPyText = GetDispPyText()
        If "".Equals(vDispPyText) AndAlso vDispWordText.Length > 0 Then
            vDispPyText = vDispPyText2
            vDispPyText2 = ""
        End If

        Dim recommendWord As CWord = Nothing

        Dim dspPys As String() = BreakPys(vDispPyText).Split(" ")
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
