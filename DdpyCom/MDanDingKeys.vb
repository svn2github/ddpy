Imports System.Windows.Forms

''' <summary>
''' 按键处理模块
''' </summary>
Module MDanDingKeys

    Friend ddPy As New CDandingPy

    Private bShiftKeyDown As Boolean
    Private bLowerCase As Boolean

    Private bQuote As Boolean = True

    ''' <summary>
    ''' 按键处理
    ''' </summary>
    ''' <param name="iKey">按键</param>
    ''' <param name="ikr">按键处理结果</param>
    ''' <returns>淡定拼音类</returns>
    Friend Function ComProcessKey(ByVal iKey As UInteger, ByRef ikr As ImeKeyResult) As CDandingPy

        bShiftKeyDown = IsShiftKeyDown()    ' My.Computer.Keyboard.ShiftKeyDown
        bLowerCase = (Not bShiftKeyDown)

        Dim key As String = KeyToString(iKey)
        ComDebug("ComProcessKey(" & iKey & ":" & key & ")")

        If key <> "" Then

            ' 编码输入
            If ddPy.InputPys.Length + ddPy.DispPyText2.Length >= P_MAX_PY_LEN Then
                ' 超过输入长度限制时不处理
                SetIkrFlag(ikr, True, True, False)
                Return ddPy
            End If

            ddPy.InputPys = ddPy.InputPys & key
            ddPy.ExecuteSearch()  ' 检索

            SetIkrFlag(ikr, True, True, False)
        Else

            ' 非编码输入
            Select Case iKey
                Case Keys.Back

                    If ddPy.InputPys.Length = 0 Then
                        If ddPy.DispPyText2.Length > 1 Then
                            SetIkrFlag(ikr, True, True, False)
                        Else
                            SetIkrFlag(ikr, False, False, False)
                        End If
                    Else

                        If ddPy.DispPyText2.Length = 0 Then

                            Dim word As CWord = ddPy.PopWord()
                            If word Is Nothing Then
                                ddPy.InputPys = Left(ddPy.InputPys, ddPy.InputPys.Length - 1)
                                If ddPy.InputPys.Length = 0 Then
                                    SetIkrFlag(ikr, True, False, False)
                                Else
                                    ddPy.ExecuteSearch() ' 检索
                                    SetIkrFlag(ikr, True, True, False)
                                End If
                            Else
                                ddPy.ExecuteSearch() ' 检索
                                SetIkrFlag(ikr, True, True, False)
                            End If

                        Else

                            ddPy.MoveCurLeft(True)
                            SetIkrFlag(ikr, True, True, False)
                        End If
                    End If

                Case Keys.Delete
                    If ddPy.DispPyText2.Length > 0 Then
                        ddPy.DispPyText2 = ddPy.DispPyText2.Substring(1)
                    End If

                    If ddPy.InputPys.Length > 0 OrElse ddPy.DispPyText2.Length > 0 Then
                        SetIkrFlag(ikr, True, True, False)
                    Else
                        SetIkrFlag(ikr, True, False, False)
                    End If

                Case Keys.Enter
                    If ddPy.InputPys.Length = 0 AndAlso ddPy.DispPyText2.Length = 0 Then
                        ddPy.Clear()
                        SetIkrFlag(ikr, False, False, False)
                    Else
                        EnterWithChar(ikr, False)    ' 回车上屏
                    End If
                Case Keys.Space
                    If ddPy.InputPys.Length > 0 Then

                        If ddPy.PushWord() Then
                            SetIkrFlag(ikr, True, True, True)
                            If Not ddPy.IsFinish Then
                                ikr.IsInputEnd = False
                                ddPy.ExecuteSearch()
                            End If
                        Else
                            ' 转换失败时，作回车上屏处理
                            EnterWithChar(ikr, False)    ' 回车上屏
                        End If

                    ElseIf ddPy.DispPyText2.Length > 0 Then
                        EnterWithChar(ikr, False)    ' 回车上屏
                    Else
                        SetIkrFlag(ikr, False, False, False)
                    End If

                Case Keys.Escape
                    If ddPy.InputPys.Length = 0 AndAlso ddPy.DispPyText2.Length = 0 Then
                        SetIkrFlag(ikr, False, False, False)
                    Else
                        ddPy.Clear()
                        SetIkrFlag(ikr, True, False, False)
                    End If

                Case Keys.Left
                    ddPy.MoveCurLeft()
                    SetIkrFlag(ikr, True, True, False)
                Case Keys.Right
                    ddPy.MoveCurRight()
                    SetIkrFlag(ikr, True, True, False)

                Case Keys.Down
                    If ddPy.InputPys.Length = 0 Then
                        SetIkrFlag(ikr, False, False, False)
                    Else
                        ddPy.FocusNextWord()                    ' 高亮显示下一个候选
                        SetIkrFlag(ikr, True, True, False)
                    End If
                Case Keys.Up
                    If ddPy.InputPys.Length = 0 Then
                        SetIkrFlag(ikr, False, False, False)
                    Else
                        ddPy.FocusPreviousWord()                ' 高亮显示前一个候选
                        SetIkrFlag(ikr, True, True, False)
                    End If

                Case Keys.PageDown
                    If ddPy.InputPys.Length = 0 Then
                        SetIkrFlag(ikr, False, False, False)
                    Else
                        ddPy.ShowNextPage()                     ' 后页
                        SetIkrFlag(ikr, True, True, False)
                    End If
                Case Keys.Oemplus
                    If ddPy.InputPys.Length = 0 Then
                        SetIkrFlag(ikr, False, False, False)
                    Else
                        ddPy.ShowNextPage()                     ' 后页
                        SetIkrFlag(ikr, True, True, False)
                    End If

                Case Keys.PageUp
                    If ddPy.InputPys.Length = 0 Then
                        SetIkrFlag(ikr, False, False, False)
                    Else
                        ddPy.ShowPreviousPage()                 ' 前页
                        SetIkrFlag(ikr, True, True, False)
                    End If
                Case Keys.OemMinus
                    If ddPy.InputPys.Length = 0 Then
                        SetIkrFlag(ikr, False, False, False)
                    Else
                        ddPy.ShowPreviousPage()                 ' 前页
                        SetIkrFlag(ikr, True, True, False)
                    End If

                Case Keys.Oemtilde
                    EnterWithChar(ikr, True, "·", "～", "`", "~")    ' 附加字符上屏
                Case Keys.OemPipe
                    EnterWithChar(ikr, True, "、", "|", "\", "|")    ' 附加字符上屏
                Case Keys.OemOpenBrackets
                    EnterWithChar(ikr, True, "【", "『", "[", "{")    ' 附加字符上屏
                Case Keys.OemCloseBrackets
                    EnterWithChar(ikr, True, "】", "』", "]", "}")    ' 附加字符上屏
                Case Keys.OemSemicolon
                    EnterWithChar(ikr, True, "；", "：", ";", ":")    ' 附加字符上屏
                Case Keys.OemQuotes
                    If bQuote Then
                        EnterWithChar(ikr, True, "‘", ChrW(8220), "'", """")    ' 附加字符上屏
                    Else
                        EnterWithChar(ikr, True, "’", ChrW(8221), "'", """")    ' 附加字符上屏
                    End If
                    bQuote = Not bQuote
                Case Keys.Oemcomma
                    EnterWithChar(ikr, True, "，", "《", ",", "<")    ' 附加字符上屏
                Case Keys.OemPeriod
                    If ddPy.InputPys.Equals("vb", StringComparison.OrdinalIgnoreCase) Then
                        If bShiftKeyDown Then
                            EnterWithChar(ikr, False, "》", "》", "》", "》")    ' 附加字符上屏
                        Else
                            ddPy.InputPys = ddPy.InputPys & "."
                            SetIkrFlag(ikr, True, True, False)
                            ddPy.ExecuteSearch()
                        End If
                    Else
                        EnterWithChar(ikr, True, "。", "》", ".", ">")    ' 附加字符上屏
                    End If
                Case Keys.OemQuestion
                    EnterWithChar(ikr, False, "/", "？", "/", "?")    ' 附加字符上屏

                Case Else
                    If iKey >= Keys.D0 And iKey <= Keys.D9 Then
                        ProcessDigitKey(iKey, ikr)
                    Else
                        ComDebug("无厘头输入？盖之")
                        SetIkrFlag(ikr, True, True, False)
                    End If
            End Select

        End If


        ComDebug("ComProcessKey:" & ikr.IsProcessKey & ", InputStart:" & ikr.IsInputStart & ", InputEnd:" & ikr.IsInputEnd)
        Return ddPy

    End Function

    ''' <summary>
    ''' 数字键处理
    ''' </summary>
    ''' <param name="iKey">按键</param>
    ''' <param name="ikr">按键处理结果</param>
    Private Sub ProcessDigitKey(ByVal iKey As UInteger, ByRef ikr As ImeKeyResult)

        If iKey >= Keys.D1 And iKey <= Keys.D9 Then

            If ddPy.InputPys = "" Then
                SetIkrFlag(ikr, False, False, False)
            Else
                If bShiftKeyDown Then
                    ddPy.TextEndChar = {"！", "@", "#", "￥", "%", "……", "&", "×", "（", "）"}(iKey - Keys.D1)
                    ddPy.FocusCand = 1
                    ddPy.PushWord()
                    SetIkrFlag(ikr, True, True, True)
                Else
                    ddPy.FocusCand = iKey - Keys.D0
                    ddPy.PushWord()
                    SetIkrFlag(ikr, True, True, True)

                    If Not ddPy.IsFinish Then
                        ikr.IsInputEnd = False
                        ddPy.ExecuteSearch()
                    End If
                End If

            End If

        ElseIf iKey = Keys.D0 Then

            If ddPy.InputPys = "" Then
                SetIkrFlag(ikr, False, False, False)
            Else
                ddPy.TextEndChar = IIf(P_MODE_FULL, IIf(bShiftKeyDown, "）", "０"), IIf(bShiftKeyDown, "0", ")"))
                ddPy.FocusCand = 1
                ddPy.PushWord()
                SetIkrFlag(ikr, True, True, True)

            End If

        End If
    End Sub

    ''' <summary>
    ''' ImeKeyResult处理标志设定
    ''' </summary>
    ''' <param name="ikr">ImeKeyResult</param>
    ''' <param name="isProcessKey">是否处理按键</param>
    ''' <param name="isInputStart">输入是否开始</param>
    ''' <param name="isInputEnd">输入是否结束</param>
    Friend Sub SetIkrFlag(ByRef ikr As ImeKeyResult, ByVal isProcessKey As Boolean, ByVal isInputStart As Boolean, ByVal isInputEnd As Boolean)
        ikr.IsProcessKey = isProcessKey
        ikr.IsInputStart = isInputStart
        ikr.IsInputEnd = isInputEnd
    End Sub


    ''' <summary>
    ''' 附加字符后上屏
    ''' </summary>
    ''' <param name="ikr">ImeKeyResult</param>
    ''' <param name="bConvert">是否转换当前候选</param>
    ''' <param name="fullCharLower">附加字符（全角小写）</param>
    ''' <param name="fullCharUpper">附加字符（全角大写）</param>
    ''' <param name="charLower">附加字符（半角小写）</param>
    ''' <param name="charUpper">附加字符（半角大写）</param>
    Private Sub EnterWithChar(ByRef ikr As ImeKeyResult, ByVal bConvert As Boolean _
                              , Optional ByVal fullCharLower As String = "" _
                              , Optional ByVal fullCharUpper As String = "" _
                              , Optional ByVal charLower As String = "" _
                              , Optional ByVal charUpper As String = "")

        If ddPy.InputPys = "" Then
            'If bConvert Then
            '    ' 处理结束，拼接字符后上屏
            '    SetIkrFlag(ikr, True, True, True)
            '    ddPy.TextEndChar = IIf(P_BD_FULL, IIf(bLowerCase, fullCharLower, fullCharUpper), IIf(bLowerCase, charLower, charUpper))
            'Else
            '    SetIkrFlag(ikr, False, False, False)
            '    ddPy.TextEndChar = ""
            'End If

            If Not ddPy.DispPyText2 = "" Then
                ' 处理结束，拼接字符后上屏
                SetIkrFlag(ikr, True, True, True)
                ddPy.TextEndChar = IIf(P_BD_FULL, IIf(bLowerCase, fullCharLower, fullCharUpper), IIf(bLowerCase, charLower, charUpper))
            Else
                SetIkrFlag(ikr, False, False, False)
                ddPy.TextEndChar = ""
            End If
        Else
            If bConvert Then
                ddPy.PushWord()
            End If
            ' 处理结束，拼接字符后上屏
            SetIkrFlag(ikr, True, True, True)
            ddPy.TextEndChar = IIf(P_BD_FULL, IIf(bLowerCase, fullCharLower, fullCharUpper), IIf(bLowerCase, charLower, charUpper))
        End If

    End Sub

    ''' <summary>
    ''' 转换按键为拼音编码（非拼音编码返回空串）
    ''' </summary>
    ''' <param name="iKey">按键</param>
    ''' <returns>拼音编码（非拼音编码返回空串）</returns>
    Friend Function KeyToString(ByVal iKey As UInteger) As String

        Dim key As String = ""
        Select Case iKey
            Case Windows.Forms.Keys.A
                key = IIf(bLowerCase, "a", "A")
            Case Windows.Forms.Keys.B
                key = IIf(bLowerCase, "b", "B")
            Case Windows.Forms.Keys.C
                key = IIf(bLowerCase, "c", "C")
            Case Windows.Forms.Keys.D
                key = IIf(bLowerCase, "d", "D")
            Case Windows.Forms.Keys.E
                key = IIf(bLowerCase, "e", "E")
            Case Windows.Forms.Keys.F
                key = IIf(bLowerCase, "f", "F")
            Case Windows.Forms.Keys.G
                key = IIf(bLowerCase, "g", "G")
            Case Windows.Forms.Keys.H
                key = IIf(bLowerCase, "h", "H")
            Case Windows.Forms.Keys.I
                key = IIf(bLowerCase, "i", "I")
            Case Windows.Forms.Keys.J
                key = IIf(bLowerCase, "j", "J")
            Case Windows.Forms.Keys.K
                key = IIf(bLowerCase, "k", "K")
            Case Windows.Forms.Keys.L
                key = IIf(bLowerCase, "l", "L")
            Case Windows.Forms.Keys.M
                key = IIf(bLowerCase, "m", "M")
            Case Windows.Forms.Keys.N
                key = IIf(bLowerCase, "n", "N")
            Case Windows.Forms.Keys.O
                key = IIf(bLowerCase, "o", "O")
            Case Windows.Forms.Keys.P
                key = IIf(bLowerCase, "p", "P")
            Case Windows.Forms.Keys.Q
                key = IIf(bLowerCase, "q", "Q")
            Case Windows.Forms.Keys.R
                key = IIf(bLowerCase, "r", "R")
            Case Windows.Forms.Keys.S
                key = IIf(bLowerCase, "s", "S")
            Case Windows.Forms.Keys.T
                key = IIf(bLowerCase, "t", "T")
            Case Windows.Forms.Keys.U
                key = IIf(bLowerCase, "u", "U")
            Case Windows.Forms.Keys.V
                key = IIf(bLowerCase, "v", "V")
            Case Windows.Forms.Keys.W
                key = IIf(bLowerCase, "w", "W")
            Case Windows.Forms.Keys.X
                key = IIf(bLowerCase, "x", "X")
            Case Windows.Forms.Keys.Y
                key = IIf(bLowerCase, "y", "Y")
            Case Windows.Forms.Keys.Z
                key = IIf(bLowerCase, "z", "Z")

            Case Windows.Forms.Keys.OemQuotes
                If Not ddPy.InputPys = "" Then
                    key = "'"
                End If
            Case Else
                '
        End Select

        Return key

    End Function


End Module
