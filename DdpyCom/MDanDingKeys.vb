﻿Imports System.Windows.Forms

''' <summary>
''' 按键处理模块
''' </summary>
Module MDanDingKeys

    Friend isLeftQte As Boolean = True
    Friend isDot As Boolean = False

    Friend ddPy As New CDandingPy

    Private UnDispKey As String = ""
    Private hasInputWithShift As Boolean = False


    ''' <summary>
    ''' 按键处理
    ''' </summary>
    ''' <param name="iKey">按键</param>
    ''' <param name="ikr">按键处理结果</param>
    Friend Sub ComProcessKey(ByVal iKey As UInteger, ByRef ikr As ImeKeyResult)


        ' 处理CapsLock按键
        If HandleCapsLockKey(iKey, ikr) Then
            Return
        End If

        ' 处理非编码按键
        If HandleNotImeKey(iKey, ikr) Then
            Return
        End If

        ' 处理编码按键
        If IsCompKey(iKey) Then

            ' 超过输入长度限制时不处理
            If ddPy.InputPys.Length + ddPy.DispPyText2.Length >= P_MAX_PY_LEN Then
                SetIkrFlag(ikr, True, True, False)
                Return
            End If

            ' 无奈处理
            If Not frmInput.Visible AndAlso IsNeedSendStartEndMsg(Process.GetCurrentProcess().ProcessName) Then
                NotifyIme(&H100, 1)
            End If

            ' 拼接编码后检索
            ddPy.InputPys = ddPy.InputPys & ConvertDefaultChar(iKey)
            ddPy.ExecuteSearch()

            SetIkrFlag(ikr, True, True, False)
            Return
        End If

        ' 处理非编码按键
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
                EnterWithChar(ikr, True, iKey)    ' 附加字符上屏
            Case Keys.Oemcomma
                EnterWithChar(ikr, True, iKey)    ' 附加字符上屏
            Case Keys.OemPeriod
                If ddPy.InputPys.Equals("vb", StringComparison.OrdinalIgnoreCase) Then
                    If My.Computer.Keyboard.ShiftKeyDown Then
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

                SetIkrFlag(ikr, False, False, False)   ' 交还系统处理
        End Select


        ComDebug("ComProcessKey:" & ikr.IsProcessKey & ", InputStart:" & ikr.IsInputStart & ", InputEnd:" & ikr.IsInputEnd)

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
    Private Function IsCompKey(ByVal iKey As UInteger) As Boolean

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



    Private Function IsNumPadKey(ByVal iKey As UInteger) As Boolean
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

    Private Function IsAlphaKey(ByVal iKey As UInteger) As Boolean
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



    Private Function ConvertChar(ByVal iKey As UInteger) As String
        Dim sRet As String = ""

        Dim bLowerCase As Boolean = IIf(My.Computer.Keyboard.CapsLock, IIf(My.Computer.Keyboard.ShiftKeyDown, True, False), IIf(My.Computer.Keyboard.ShiftKeyDown, False, True))


        If IsNumPadKey(iKey) Then
            ' 按小键盘输入可见字符，任何时候都不作转换
            sRet = ToDefaultCharOfNumPad(iKey)

        ElseIf My.Computer.Keyboard.CapsLock OrElse (Not P_LNG_CN) Then
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

        Return sRet
    End Function

    Private Function ToCnChar(ByVal iKey As UInteger) As String
        Dim sRet As String = ""

        Dim bShiftKeyDown As Boolean = My.Computer.Keyboard.ShiftKeyDown
        Dim bLowerCase As Boolean = IIf(My.Computer.Keyboard.CapsLock, IIf(My.Computer.Keyboard.ShiftKeyDown, True, False), IIf(My.Computer.Keyboard.ShiftKeyDown, False, True))


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

            Case Windows.Forms.Keys.NumPad0
                sRet = IIf(My.Computer.Keyboard.NumLock, "0", "")
            Case Windows.Forms.Keys.NumPad1
                sRet = IIf(My.Computer.Keyboard.NumLock, "1", "")
            Case Windows.Forms.Keys.NumPad2
                sRet = IIf(My.Computer.Keyboard.NumLock, "2", "")
            Case Windows.Forms.Keys.NumPad3
                sRet = IIf(My.Computer.Keyboard.NumLock, "3", "")
            Case Windows.Forms.Keys.NumPad4
                sRet = IIf(My.Computer.Keyboard.NumLock, "4", "")
            Case Windows.Forms.Keys.NumPad5
                sRet = IIf(My.Computer.Keyboard.NumLock, "5", "")
            Case Windows.Forms.Keys.NumPad6
                sRet = IIf(My.Computer.Keyboard.NumLock, "6", "")
            Case Windows.Forms.Keys.NumPad7
                sRet = IIf(My.Computer.Keyboard.NumLock, "7", "")
            Case Windows.Forms.Keys.NumPad8
                sRet = IIf(My.Computer.Keyboard.NumLock, "8", "")
            Case Windows.Forms.Keys.NumPad9
                sRet = IIf(My.Computer.Keyboard.NumLock, "9", "")

        End Select

        Return sRet
    End Function

    Friend Function ConvertDefaultChar(ByVal iKey As UInteger) As String

        Dim sRet As String = UnDispKey
        Dim bShiftKeyDown As Boolean = My.Computer.Keyboard.ShiftKeyDown
        Dim bLowerCase As Boolean = IIf(My.Computer.Keyboard.CapsLock, IIf(My.Computer.Keyboard.ShiftKeyDown, True, False), IIf(My.Computer.Keyboard.ShiftKeyDown, False, True))

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
                sRet = IIf(My.Computer.Keyboard.NumLock, UnDispKey, "0")
            Case Windows.Forms.Keys.NumPad1             ' 小键盘
                sRet = IIf(My.Computer.Keyboard.NumLock, UnDispKey, "1")
            Case Windows.Forms.Keys.NumPad2             ' 小键盘
                sRet = IIf(My.Computer.Keyboard.NumLock, UnDispKey, "2")
            Case Windows.Forms.Keys.NumPad3             ' 小键盘
                sRet = IIf(My.Computer.Keyboard.NumLock, UnDispKey, "3")
            Case Windows.Forms.Keys.NumPad4             ' 小键盘
                sRet = IIf(My.Computer.Keyboard.NumLock, UnDispKey, "4")
            Case Windows.Forms.Keys.NumPad5             ' 小键盘
                sRet = IIf(My.Computer.Keyboard.NumLock, UnDispKey, "5")
            Case Windows.Forms.Keys.NumPad6             ' 小键盘
                sRet = IIf(My.Computer.Keyboard.NumLock, UnDispKey, "6")
            Case Windows.Forms.Keys.NumPad7             ' 小键盘
                sRet = IIf(My.Computer.Keyboard.NumLock, UnDispKey, "7")
            Case Windows.Forms.Keys.NumPad8             ' 小键盘
                sRet = IIf(My.Computer.Keyboard.NumLock, UnDispKey, "8")
            Case Windows.Forms.Keys.NumPad9             ' 小键盘
                sRet = IIf(My.Computer.Keyboard.NumLock, UnDispKey, "9")

            Case Else


        End Select

        Return sRet
    End Function



    ' 处理CapsLock按键
    Private Function HandleCapsLockKey(ByVal iKey As UInteger, ByRef ikr As ImeKeyResult) As Boolean

        If Not iKey = Keys.CapsLock Then
            Return False
        End If

        ' 刷新输入法状态窗口
        UpdateStatusWindow()

        SetIkrFlag(ikr, False, False, False)   ' 交还系统处理

        isDot = False
        Return True
    End Function

    Private Function HandleNotImeKey(ByVal iKey As UInteger, ByRef ikr As ImeKeyResult) As Boolean

        ' 打开输入法1秒内，不处理Ctrl键和Shift键
        If (Now.Ticks - initStartTime < 10000 * 1000) AndAlso (iKey = Keys.ControlKey OrElse iKey = Keys.ShiftKey) Then
            SetIkrFlag(ikr, False, False, False)   ' 交还系统处理

            isDot = False
            Return True
        End If

        ' 不处理Alt组合键、Ctrl组合键
        If My.Computer.Keyboard.AltKeyDown OrElse My.Computer.Keyboard.CtrlKeyDown Then
            SetIkrFlag(ikr, False, False, False)   ' 交还系统处理

            isDot = False
            Return True
        End If

        ' Shift按键松开
        If iKey = Keys.ShiftKey Then

            If My.Computer.Keyboard.ShiftKeyDown Then
                SetIkrFlag(ikr, False, False, False)   ' 交还系统处理
            ElseIf hasInputWithShift Then
                ' 按Shift组合键松开
                SetIkrFlag(ikr, False, False, False)   ' 交还系统处理
                hasInputWithShift = False
            Else
                ' 单键Shift按键松开
                P_LNG_CN = Not P_LNG_CN                ' 切换中/英模式

                ' 刷新输入法状态窗口
                UpdateStatusWindow()

                SetIkrFlag(ikr, False, False, False)

            End If

            isDot = False
            Return True
        End If

        ' Ctrl按键松开时
        If iKey = Keys.ControlKey Then
            SetIkrFlag(ikr, False, False, False)   ' 交还系统处理

            isDot = False
            Return True
        End If

        If My.Computer.Keyboard.ShiftKeyDown Then
            hasInputWithShift = True
        End If

        ' 初次输入单个非编码字符
        If Not frmInput.Visible AndAlso (Not IsAlphaKey(iKey) _
                                         OrElse My.Computer.Keyboard.CapsLock _
                                         OrElse (Not P_LNG_CN) _
                                         ) Then

            Dim sChar As String = ConvertChar(iKey)
            If sChar.Length = 0 Then
                ' 无法显示字符的按键
                SetIkrFlag(ikr, False, False, False)    ' 交还系统处理
            Else
                ' 可显示字符
                SetIkrFlag(ikr, True, True, True)       ' 直接转换
                ddPy.TextEndChar = sChar
            End If

            isDot = IsNumeric(sChar)
            Return True
        End If


        isDot = False
        Return False

    End Function



End Module
