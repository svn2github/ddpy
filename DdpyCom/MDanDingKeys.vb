Imports System.Windows.Forms

''' <summary>
''' 按键处理模块
''' </summary>
Module MDanDingKeys

    Private bCapsLock As Boolean
    Private bShiftKeyDown As Boolean
    Private bLowerCase As Boolean
    Private bNumLock As Boolean

    Friend isLeftQte As Boolean = True
    Friend isDot As Boolean = False

    Friend ddPy As New CDandingPy

  
    ''' <summary>
    ''' 按键处理
    ''' </summary>
    ''' <param name="iKey">按键</param>
    ''' <param name="ikr">按键处理结果</param>
    ''' <returns>淡定拼音类</returns>
    Friend Function ComProcessKey(ByVal iKey As UInteger, ByRef ikr As ImeKeyResult) As CDandingPy

        bShiftKeyDown = IsShiftKeyDown()    ' My.Computer.Keyboard.ShiftKeyDown
        bLowerCase = (Not bShiftKeyDown)


        ' 初次输入单个非编码字符，直接转换结束
        If Not frmInput.Visible AndAlso (Not IsAlphaKey(iKey) _
                                         OrElse My.Computer.Keyboard.CapsLock _
                                         OrElse (Not P_LNG_CN) _
                                         ) Then

            Dim sChar As String = ConvertChar(iKey)
            If "".Equals(sChar) Then
                SetIkrFlag(ikr, False, False, False)
                isDot = False
            Else
                SetIkrFlag(ikr, True, True, True)
                ddPy.TextEndChar = sChar
            End If

            Return ddPy
        End If



        If IsCompKey(iKey) Then

            ' 编码输入(非主键盘的1～9按下时作编码处理)
            If ddPy.InputPys.Length + ddPy.DispPyText2.Length >= P_MAX_PY_LEN Then
                ' 超过输入长度限制时不处理
                SetIkrFlag(ikr, True, True, False)
                Return ddPy
            End If

            ddPy.InputPys = ddPy.InputPys & IIf(iKey = Keys.OemQuotes, "'", Strings.StrConv(ConvertChar(iKey), VbStrConv.Narrow))
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
                        EnterWithChar(ikr, False, iKey)    ' 回车上屏
                    End If
                Case Keys.Return    ' 小键盘回车
                    If ddPy.InputPys.Length = 0 AndAlso ddPy.DispPyText2.Length = 0 Then
                        ddPy.Clear()
                        SetIkrFlag(ikr, False, False, False)
                    Else
                        EnterWithChar(ikr, False, iKey)    ' 回车上屏
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
                            EnterWithChar(ikr, False, iKey)    ' 回车上屏
                        End If

                    ElseIf ddPy.DispPyText2.Length > 0 Then
                        EnterWithChar(ikr, False, iKey)    ' 回车上屏
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
                    If My.Computer.Keyboard.ShiftKeyDown Then
                        EnterWithChar(ikr, True, iKey)    ' 附加字符上屏
                    Else
                        If ddPy.InputPys.Length = 0 Then
                            SetIkrFlag(ikr, False, False, False)
                        Else
                            ddPy.ShowNextPage()                     ' 后页
                            SetIkrFlag(ikr, True, True, False)
                        End If
                    End If

                Case Keys.PageUp
                    If ddPy.InputPys.Length = 0 Then
                        SetIkrFlag(ikr, False, False, False)
                    Else
                        ddPy.ShowPreviousPage()                 ' 前页
                        SetIkrFlag(ikr, True, True, False)
                    End If
                Case Keys.OemMinus
                    If My.Computer.Keyboard.ShiftKeyDown Then
                        EnterWithChar(ikr, True, iKey)    ' 附加字符上屏
                    Else
                        If ddPy.InputPys.Length = 0 Then
                            SetIkrFlag(ikr, False, False, False)
                        Else
                            ddPy.ShowPreviousPage()                 ' 前页
                            SetIkrFlag(ikr, True, True, False)
                        End If
                    End If

                Case Keys.Oemtilde
                    EnterWithChar(ikr, True, iKey)    ' 附加字符上屏
                Case Keys.OemPipe
                    EnterWithChar(ikr, True, iKey)    ' 附加字符上屏
                Case Keys.OemOpenBrackets
                    EnterWithChar(ikr, True, iKey)    ' 附加字符上屏
                Case Keys.OemCloseBrackets
                    EnterWithChar(ikr, True, iKey)    ' 附加字符上屏
                Case Keys.OemSemicolon
                    EnterWithChar(ikr, True, iKey)    ' 附加字符上屏
                Case Keys.OemQuotes
                    If bQuote Then
                        EnterWithChar(ikr, True, iKey)    ' 附加字符上屏
                    Else
                        EnterWithChar(ikr, True, iKey)    ' 附加字符上屏
                    End If
                    bQuote = Not bQuote
                Case Keys.Oemcomma
                    EnterWithChar(ikr, True, iKey)    ' 附加字符上屏
                Case Keys.OemPeriod
                    If ddPy.InputPys.Equals("vb", StringComparison.OrdinalIgnoreCase) Then
                        If bShiftKeyDown Then
                            EnterWithChar(ikr, False, iKey)    ' 附加字符上屏
                        Else
                            ddPy.InputPys = ddPy.InputPys & "."
                            SetIkrFlag(ikr, True, True, False)
                            ddPy.ExecuteSearch()
                        End If
                    Else
                        EnterWithChar(ikr, True, iKey)    ' 附加字符上屏
                    End If
                Case Keys.OemQuestion
                    EnterWithChar(ikr, False, iKey)    ' 附加字符上屏

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
    Private Sub EnterWithChar(ByRef ikr As ImeKeyResult, ByVal bConvert As Boolean, ByVal iKey As UInteger)

        If ddPy.InputPys = "" Then

            If Not ddPy.DispPyText2 = "" Then
                ' 处理结束，拼接字符后上屏
                SetIkrFlag(ikr, True, True, True)
                ddPy.TextEndChar = IIf(iKey = Keys.Space, "", ConvertChar(iKey))
            Else
                SetIkrFlag(ikr, False, False, False)
            End If

        Else
            If bConvert Then
                ddPy.PushWord()
            End If
            ' 处理结束，拼接字符后上屏
            SetIkrFlag(ikr, True, True, True)
            ddPy.TextEndChar = IIf(iKey = Keys.Space, "", ConvertChar(iKey))
        End If

    End Sub

    ''' <summary>
    ''' 判断是否为编码字符
    ''' </summary>
    ''' <param name="iKey">按键</param>
    ''' <returns>True：作为编码字符</returns>
    Friend Function IsCompKey(ByVal iKey As UInteger) As Boolean

        Dim bRet As Boolean = False
        Select Case iKey
            Case Windows.Forms.Keys.A
                bRet = True
            Case Windows.Forms.Keys.B
                bRet = True
            Case Windows.Forms.Keys.C
                bRet = True
            Case Windows.Forms.Keys.D
                bRet = True
            Case Windows.Forms.Keys.E
                bRet = True
            Case Windows.Forms.Keys.F
                bRet = True
            Case Windows.Forms.Keys.G
                bRet = True
            Case Windows.Forms.Keys.H
                bRet = True
            Case Windows.Forms.Keys.I
                bRet = True
            Case Windows.Forms.Keys.J
                bRet = True
            Case Windows.Forms.Keys.K
                bRet = True
            Case Windows.Forms.Keys.L
                bRet = True
            Case Windows.Forms.Keys.M
                bRet = True
            Case Windows.Forms.Keys.N
                bRet = True
            Case Windows.Forms.Keys.O
                bRet = True
            Case Windows.Forms.Keys.P
                bRet = True
            Case Windows.Forms.Keys.Q
                bRet = True
            Case Windows.Forms.Keys.R
                bRet = True
            Case Windows.Forms.Keys.S
                bRet = True
            Case Windows.Forms.Keys.T
                bRet = True
            Case Windows.Forms.Keys.U
                bRet = True
            Case Windows.Forms.Keys.V
                bRet = True
            Case Windows.Forms.Keys.W
                bRet = True
            Case Windows.Forms.Keys.X
                bRet = True
            Case Windows.Forms.Keys.Y
                bRet = True
            Case Windows.Forms.Keys.Z
                bRet = True
            Case Windows.Forms.Keys.OemQuotes
                If My.Computer.Keyboard.ShiftKeyDown Then
                    bRet = False
                Else
                    bRet = True
                End If

            Case Else
                bRet = IsNumPadKey(iKey)
        End Select

        Return bRet

    End Function



    Friend Function IsNumPadKey(ByVal iKey As UInteger) As Boolean
        Dim bRet As Boolean = False

        Select Case iKey
            Case Windows.Forms.Keys.Divide              ' 小键盘
                bRet = True
            Case Windows.Forms.Keys.Multiply            ' 小键盘
                bRet = True
            Case Windows.Forms.Keys.Subtract            ' 小键盘
                bRet = True
            Case Windows.Forms.Keys.Add                 ' 小键盘
                bRet = True
            Case Windows.Forms.Keys.Decimal             ' 小键盘
                bRet = True

            Case Windows.Forms.Keys.NumPad0             ' 小键盘
                bRet = True
            Case Windows.Forms.Keys.NumPad1             ' 小键盘
                bRet = True
            Case Windows.Forms.Keys.NumPad2             ' 小键盘
                bRet = True
            Case Windows.Forms.Keys.NumPad3             ' 小键盘
                bRet = True
            Case Windows.Forms.Keys.NumPad4             ' 小键盘
                bRet = True
            Case Windows.Forms.Keys.NumPad5             ' 小键盘
                bRet = True
            Case Windows.Forms.Keys.NumPad6             ' 小键盘
                bRet = True
            Case Windows.Forms.Keys.NumPad7             ' 小键盘
                bRet = True
            Case Windows.Forms.Keys.NumPad8             ' 小键盘
                bRet = True
            Case Windows.Forms.Keys.NumPad9             ' 小键盘
                bRet = True

        End Select

        Return bRet
    End Function

    Friend Function IsAlphaKey(ByVal iKey As UInteger) As Boolean
        Dim bRet As Boolean = False

        Select Case iKey
            Case Windows.Forms.Keys.A
                bRet = True
            Case Windows.Forms.Keys.B
                bRet = True
            Case Windows.Forms.Keys.C
                bRet = True
            Case Windows.Forms.Keys.D
                bRet = True
            Case Windows.Forms.Keys.E
                bRet = True
            Case Windows.Forms.Keys.F
                bRet = True
            Case Windows.Forms.Keys.G
                bRet = True
            Case Windows.Forms.Keys.H
                bRet = True
            Case Windows.Forms.Keys.I
                bRet = True
            Case Windows.Forms.Keys.J
                bRet = True
            Case Windows.Forms.Keys.K
                bRet = True
            Case Windows.Forms.Keys.L
                bRet = True
            Case Windows.Forms.Keys.M
                bRet = True
            Case Windows.Forms.Keys.N
                bRet = True
            Case Windows.Forms.Keys.O
                bRet = True
            Case Windows.Forms.Keys.P
                bRet = True
            Case Windows.Forms.Keys.Q
                bRet = True
            Case Windows.Forms.Keys.R
                bRet = True
            Case Windows.Forms.Keys.S
                bRet = True
            Case Windows.Forms.Keys.T
                bRet = True
            Case Windows.Forms.Keys.U
                bRet = True
            Case Windows.Forms.Keys.V
                bRet = True
            Case Windows.Forms.Keys.W
                bRet = True
            Case Windows.Forms.Keys.X
                bRet = True
            Case Windows.Forms.Keys.Y
                bRet = True
            Case Windows.Forms.Keys.Z
                bRet = True

        End Select

        Return bRet
    End Function



    Friend Function ConvertChar(ByVal iKey As UInteger) As String
        Dim sRet As String = ""

        bCapsLock = My.Computer.Keyboard.CapsLock
        bShiftKeyDown = My.Computer.Keyboard.ShiftKeyDown
        bLowerCase = IIf(bCapsLock, IIf(bShiftKeyDown, True, False), IIf(bShiftKeyDown, False, True))
        bNumLock = My.Computer.Keyboard.NumLock


        If IsNumPadKey(iKey) Then
            ' 按小键盘输入可见字符，任何时候都不作转换
            sRet = ToDefaultCharOfNumPad(iKey)

        ElseIf bCapsLock OrElse (Not P_LNG_CN) Then
            ' EN
            If P_MODE_FULL Then
                sRet = Strings.StrConv(ConvertDefaultChar(iKey), IIf(bLowerCase, VbStrConv.Lowercase + VbStrConv.Wide, VbStrConv.Uppercase + VbStrConv.Wide))
            Else
                sRet = Strings.StrConv(ConvertDefaultChar(iKey), IIf(bLowerCase, VbStrConv.Lowercase, VbStrConv.Uppercase))
            End If

        Else
            ' CN
            sRet = ToCnChar(iKey)

        End If


        If Not "".Equals(sRet) AndAlso "0123456789".Contains(sRet) Then
            isDot = True
        Else
            isDot = False
        End If

        Return sRet
    End Function

    Private Function ToCnChar(ByVal iKey As UInteger) As String
        Dim sRet As String = ""

        Select Case iKey
            Case Windows.Forms.Keys.Oemtilde
                If P_BD_FULL Then
                    sRet = IIf(Not bShiftKeyDown, IIf(P_MODE_FULL, "｀", "·"), "～")
                Else
                    sRet = IIf(Not bShiftKeyDown, IIf(P_MODE_FULL, "｀", "`"), "~")
                End If
            Case Windows.Forms.Keys.D1
                If P_BD_FULL Then
                    sRet = IIf(Not bShiftKeyDown, "1", "！")
                Else
                    sRet = IIf(Not bShiftKeyDown, "1", "!")
                End If
            Case Windows.Forms.Keys.D4
                If P_BD_FULL Then
                    sRet = IIf(Not bShiftKeyDown, "4", "￥")
                Else
                    sRet = IIf(Not bShiftKeyDown, "4", "$")
                End If
            Case Windows.Forms.Keys.D6
                If P_BD_FULL Then
                    sRet = IIf(Not bShiftKeyDown, "6", "……")
                Else
                    sRet = IIf(Not bShiftKeyDown, "6", "^")
                End If
            Case Windows.Forms.Keys.D8
                If P_BD_FULL Then
                    sRet = IIf(Not bShiftKeyDown, "8", "×")
                Else
                    sRet = IIf(Not bShiftKeyDown, "8", "*")
                End If
            Case Windows.Forms.Keys.D9
                If P_BD_FULL Then
                    sRet = IIf(Not bShiftKeyDown, "9", "（")
                Else
                    sRet = IIf(Not bShiftKeyDown, "9", "(")
                End If
            Case Windows.Forms.Keys.D0
                If P_BD_FULL Then
                    sRet = IIf(Not bShiftKeyDown, "0", "）")
                Else
                    sRet = IIf(Not bShiftKeyDown, "0", ")")
                End If
            Case Windows.Forms.Keys.OemMinus
                If P_BD_FULL Then
                    sRet = IIf(Not bShiftKeyDown, "-", "——")
                Else
                    sRet = IIf(Not bShiftKeyDown, "-", "_")
                End If
            Case Windows.Forms.Keys.OemPipe
                If P_BD_FULL Then
                    sRet = IIf(Not bShiftKeyDown, "、", "|")
                Else
                    sRet = IIf(Not bShiftKeyDown, "\", "|")
                End If
            Case Windows.Forms.Keys.OemOpenBrackets
                If P_BD_FULL Then
                    sRet = IIf(Not bShiftKeyDown, "【", "『")
                Else
                    sRet = IIf(Not bShiftKeyDown, "[", "{")
                End If
            Case Windows.Forms.Keys.OemCloseBrackets
                If P_BD_FULL Then
                    sRet = IIf(Not bShiftKeyDown, "】", "』")
                Else
                    sRet = IIf(Not bShiftKeyDown, "]", "}")
                End If
            Case Windows.Forms.Keys.OemSemicolon
                If P_BD_FULL Then
                    sRet = IIf(Not bShiftKeyDown, "；", "：")
                Else
                    sRet = IIf(Not bShiftKeyDown, ";", ":")
                End If

            Case Windows.Forms.Keys.OemQuotes
                If P_BD_FULL Then
                    If isLeftQte Then
                        sRet = IIf(Not bShiftKeyDown, "‘", ChrW(8220))
                    Else
                        sRet = IIf(Not bShiftKeyDown, "’", ChrW(8221))
                    End If
                    isLeftQte = Not isLeftQte
                Else
                    sRet = IIf(Not bShiftKeyDown, "'", """")
                End If

            Case Windows.Forms.Keys.Oemcomma
                If P_BD_FULL Then
                    sRet = IIf(Not bShiftKeyDown, "，", "《")
                Else
                    sRet = IIf(Not bShiftKeyDown, ",", "<")
                End If
            Case Windows.Forms.Keys.OemPeriod

                If bShiftKeyDown Then
                    sRet = IIf(P_BD_FULL, "》", ">")
                ElseIf isDot Then
                    sRet = "."
                    isDot = False
                    Return sRet         ' 小数点特别处理
                Else
                    sRet = IIf(P_BD_FULL, "。", ".")
                End If
            Case Windows.Forms.Keys.OemQuestion
                If P_BD_FULL Then
                    sRet = IIf(Not bShiftKeyDown, "/", "？")
                Else
                    sRet = IIf(Not bShiftKeyDown, ",", "?")
                End If

            Case Else
                sRet = ConvertDefaultChar(iKey)

        End Select

        If P_MODE_FULL Then
            sRet = Strings.StrConv(sRet, IIf(bLowerCase, VbStrConv.Lowercase + VbStrConv.Wide, VbStrConv.Uppercase + VbStrConv.Wide))
        Else
            sRet = Strings.StrConv(sRet, IIf(bLowerCase, VbStrConv.Lowercase, VbStrConv.Uppercase))
        End If

        Return sRet
    End Function


    Private Function ToDefaultCharOfNumPad(ByVal iKey As UInteger) As String
        Dim sRet As String = ""

        Select Case iKey
            Case Windows.Forms.Keys.Divide              ' 小键盘
                sRet = "/"
            Case Windows.Forms.Keys.Multiply            ' 小键盘
                sRet = "*"
            Case Windows.Forms.Keys.Subtract            ' 小键盘
                sRet = "-"
            Case Windows.Forms.Keys.Add                 ' 小键盘
                sRet = "+"
            Case Windows.Forms.Keys.Decimal             ' 小键盘
                sRet = "."

            Case Windows.Forms.Keys.NumPad0             ' 小键盘
                sRet = IIf(bNumLock, "0", "")
            Case Windows.Forms.Keys.NumPad1             ' 小键盘
                sRet = IIf(bNumLock, "1", "")
            Case Windows.Forms.Keys.NumPad2             ' 小键盘
                sRet = IIf(bNumLock, "2", "")
            Case Windows.Forms.Keys.NumPad3             ' 小键盘
                sRet = IIf(bNumLock, "3", "")
            Case Windows.Forms.Keys.NumPad4             ' 小键盘
                sRet = IIf(bNumLock, "4", "")
            Case Windows.Forms.Keys.NumPad5             ' 小键盘
                sRet = IIf(bNumLock, "5", "")
            Case Windows.Forms.Keys.NumPad6             ' 小键盘
                sRet = IIf(bNumLock, "6", "")
            Case Windows.Forms.Keys.NumPad7             ' 小键盘
                sRet = IIf(bNumLock, "7", "")
            Case Windows.Forms.Keys.NumPad8             ' 小键盘
                sRet = IIf(bNumLock, "8", "")
            Case Windows.Forms.Keys.NumPad9             ' 小键盘
                sRet = IIf(bNumLock, "9", "")

        End Select

        Return sRet
    End Function

    Friend Function ConvertDefaultChar(ByVal iKey As UInteger) As String

        Dim sRet As String = ""

        Select Case iKey
            Case Windows.Forms.Keys.A
                sRet = IIf(bLowerCase, "a", "A")
            Case Windows.Forms.Keys.B
                sRet = IIf(bLowerCase, "b", "B")
            Case Windows.Forms.Keys.C
                sRet = IIf(bLowerCase, "c", "C")
            Case Windows.Forms.Keys.D
                sRet = IIf(bLowerCase, "d", "D")
            Case Windows.Forms.Keys.E
                sRet = IIf(bLowerCase, "e", "E")
            Case Windows.Forms.Keys.F
                sRet = IIf(bLowerCase, "f", "F")
            Case Windows.Forms.Keys.G
                sRet = IIf(bLowerCase, "g", "G")
            Case Windows.Forms.Keys.H
                sRet = IIf(bLowerCase, "h", "H")
            Case Windows.Forms.Keys.I
                sRet = IIf(bLowerCase, "i", "I")
            Case Windows.Forms.Keys.J
                sRet = IIf(bLowerCase, "j", "J")
            Case Windows.Forms.Keys.K
                sRet = IIf(bLowerCase, "k", "K")
            Case Windows.Forms.Keys.L
                sRet = IIf(bLowerCase, "l", "L")
            Case Windows.Forms.Keys.M
                sRet = IIf(bLowerCase, "m", "M")
            Case Windows.Forms.Keys.N
                sRet = IIf(bLowerCase, "n", "N")
            Case Windows.Forms.Keys.O
                sRet = IIf(bLowerCase, "o", "O")
            Case Windows.Forms.Keys.P
                sRet = IIf(bLowerCase, "p", "P")
            Case Windows.Forms.Keys.Q
                sRet = IIf(bLowerCase, "q", "Q")
            Case Windows.Forms.Keys.R
                sRet = IIf(bLowerCase, "r", "R")
            Case Windows.Forms.Keys.S
                sRet = IIf(bLowerCase, "s", "S")
            Case Windows.Forms.Keys.T
                sRet = IIf(bLowerCase, "t", "T")
            Case Windows.Forms.Keys.U
                sRet = IIf(bLowerCase, "u", "U")
            Case Windows.Forms.Keys.V
                sRet = IIf(bLowerCase, "v", "V")
            Case Windows.Forms.Keys.W
                sRet = IIf(bLowerCase, "w", "W")
            Case Windows.Forms.Keys.X
                sRet = IIf(bLowerCase, "x", "X")
            Case Windows.Forms.Keys.Y
                sRet = IIf(bLowerCase, "y", "Y")
            Case Windows.Forms.Keys.Z
                sRet = IIf(bLowerCase, "z", "Z")

            Case Windows.Forms.Keys.Oemtilde
                sRet = IIf(Not bShiftKeyDown, "`", "~")

            Case Windows.Forms.Keys.D1
                sRet = IIf(Not bShiftKeyDown, "1", "!")
            Case Windows.Forms.Keys.D2
                sRet = IIf(Not bShiftKeyDown, "2", "@")
            Case Windows.Forms.Keys.D3
                sRet = IIf(Not bShiftKeyDown, "3", "#")
            Case Windows.Forms.Keys.D4
                sRet = IIf(Not bShiftKeyDown, "4", "$")
            Case Windows.Forms.Keys.D5
                sRet = IIf(Not bShiftKeyDown, "5", "%")
            Case Windows.Forms.Keys.D6
                sRet = IIf(Not bShiftKeyDown, "6", "^")
            Case Windows.Forms.Keys.D7
                sRet = IIf(Not bShiftKeyDown, "7", "&")
            Case Windows.Forms.Keys.D8
                sRet = IIf(Not bShiftKeyDown, "8", "*")
            Case Windows.Forms.Keys.D9
                sRet = IIf(Not bShiftKeyDown, "9", "(")
            Case Windows.Forms.Keys.D0
                sRet = IIf(Not bShiftKeyDown, "0", ")")

            Case Windows.Forms.Keys.OemMinus
                sRet = IIf(Not bShiftKeyDown, "-", "_")
            Case Windows.Forms.Keys.Oemplus
                sRet = IIf(Not bShiftKeyDown, "=", "+")
            Case Windows.Forms.Keys.OemPipe
                sRet = IIf(Not bShiftKeyDown, "\", "|")

            Case Windows.Forms.Keys.OemOpenBrackets
                sRet = IIf(Not bShiftKeyDown, "[", "{")
            Case Windows.Forms.Keys.OemCloseBrackets
                sRet = IIf(Not bShiftKeyDown, "]", "}")

            Case Windows.Forms.Keys.OemSemicolon
                sRet = IIf(Not bShiftKeyDown, ";", ":")
            Case Windows.Forms.Keys.OemQuotes
                sRet = IIf(Not bShiftKeyDown, "'", """")

            Case Windows.Forms.Keys.Oemcomma
                sRet = IIf(Not bShiftKeyDown, ",", "<")
            Case Windows.Forms.Keys.OemPeriod
                sRet = IIf(Not bShiftKeyDown, ".", ">")
            Case Windows.Forms.Keys.OemQuestion
                sRet = IIf(Not bShiftKeyDown, "/", "?")


            Case Windows.Forms.Keys.Space
                sRet = " "

            Case Windows.Forms.Keys.Divide              ' 小键盘
                sRet = "/"
            Case Windows.Forms.Keys.Multiply            ' 小键盘
                sRet = "*"
            Case Windows.Forms.Keys.Subtract            ' 小键盘
                sRet = "-"
            Case Windows.Forms.Keys.Add                 ' 小键盘
                sRet = "+"
            Case Windows.Forms.Keys.Decimal             ' 小键盘
                sRet = "."

            Case Windows.Forms.Keys.NumPad0             ' 小键盘
                sRet = IIf(bNumLock, "", "0")
            Case Windows.Forms.Keys.NumPad1             ' 小键盘
                sRet = IIf(bNumLock, "", "1")
            Case Windows.Forms.Keys.NumPad2             ' 小键盘
                sRet = IIf(bNumLock, "", "2")
            Case Windows.Forms.Keys.NumPad3             ' 小键盘
                sRet = IIf(bNumLock, "", "3")
            Case Windows.Forms.Keys.NumPad4             ' 小键盘
                sRet = IIf(bNumLock, "", "4")
            Case Windows.Forms.Keys.NumPad5             ' 小键盘
                sRet = IIf(bNumLock, "", "5")
            Case Windows.Forms.Keys.NumPad6             ' 小键盘
                sRet = IIf(bNumLock, "", "6")
            Case Windows.Forms.Keys.NumPad7             ' 小键盘
                sRet = IIf(bNumLock, "", "7")
            Case Windows.Forms.Keys.NumPad8             ' 小键盘
                sRet = IIf(bNumLock, "", "8")
            Case Windows.Forms.Keys.NumPad9             ' 小键盘
                sRet = IIf(bNumLock, "", "9")

            Case Else


        End Select

        Return sRet
    End Function

End Module
