''' <summary>
''' 候选文字类，保存输入法窗口显示所需要的基本信息
''' </summary>
Friend Class CCand

    Private vText As String
    Private vDispPyText2 As String
    Private vInputPys As String
    Private vIsFinish As Boolean
    Private vWordList As List(Of CWord)
    Private vCurrentPage As Integer
    Private vTotalPageCnt As Integer
    Private vFocusCand As Integer
    Private vCurIndex As Integer = 0

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
    ''' 候选文字编号（1～9）
    ''' </summary>
    ''' <value>候选文字编号</value>
    ''' <returns>候选文字编号</returns>
    Public Property FocusCand() As Integer
        Get
            Return vFocusCand
        End Get
        Set(ByVal Value As Integer)
            vFocusCand = Value
        End Set
    End Property

    Public Property CurrentPage() As Integer
        Get
            Return vCurrentPage
        End Get
        Set(ByVal Value As Integer)
            vCurrentPage = Value
        End Set
    End Property

    Public Property TotalPageCnt() As Integer
        Get
            Return vTotalPageCnt
        End Get
        Set(ByVal Value As Integer)
            vTotalPageCnt = Value
        End Set
    End Property

    Public Property WordList() As List(Of CWord)
        Get
            Return vWordList
        End Get
        Set(ByVal Value As List(Of CWord))
            vWordList = Value
        End Set
    End Property


    Public Property Text() As String
        Get
            Return vText
        End Get
        Set(ByVal Value As String)
            vText = Value
        End Set
    End Property

    Public Property InputPys() As String
        Get
            Return vInputPys
        End Get
        Set(ByVal Value As String)
            vInputPys = Value
        End Set
    End Property

    Public Property IsFinish() As Boolean
        Get
            Return vIsFinish
        End Get
        Set(ByVal Value As Boolean)
            vIsFinish = Value
        End Set
    End Property


End Class
