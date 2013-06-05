Imports System.Runtime.InteropServices

''' <summary>
''' 文字类型
''' </summary>
Friend Enum WordType
    ''' <summary>
    ''' 不明类型
    ''' </summary>
    UNKNOW = &H0
    ''' <summary>
    ''' 系统类型
    ''' </summary>
    SYS = &H10
    ''' <summary>
    ''' 导入类型
    ''' </summary>
    IMP = &H1
    ''' <summary>
    ''' 用户类型
    ''' </summary>
    USR = &H100
    ''' <summary>
    ''' 固顶类型
    ''' </summary>
    TOP = &H1000
End Enum


''' <summary>
''' 文字类
''' </summary>
''' <remarks></remarks>
Friend Class CWord
    Implements IComparable

    Private vText As String                         ' 文字
    Private vSearchKey As String                    ' 检索串
    Private vPinYin As String                       ' 全拼
    Private vOrder As Integer                       ' 词频
    Private vImpOrder As Integer                    ' 词频
    Private vUsrOrder As Integer                    ' 词频
    Private vTopOrder As Integer                    ' 词频
    Private vWordType As WordType = WordType.UNKNOW ' 类型
    Private vIsMixWord As Boolean                   ' 混合输入
    Private vShowDigit As Boolean = True            ' 
    Private vDispText As String

    Public Property DispText() As String
        Get
            Return vDispText
        End Get
        Set(ByVal Value As String)
            vDispText = Value
        End Set
    End Property

    Public Property ShowDigit() As Boolean
        Get
            Return vShowDigit
        End Get
        Set(ByVal Value As Boolean)
            vShowDigit = Value
        End Set
    End Property

    ''' <summary>
    ''' 频率
    ''' </summary>
    ''' <value>频率</value>
    ''' <returns>频率</returns>
    Public Property TopOrder() As Integer
        Get
            Return (vTopOrder)
        End Get
        Set(ByVal Value As Integer)
            vTopOrder = Value
        End Set
    End Property

    ''' <summary>
    ''' 频率
    ''' </summary>
    ''' <value>频率</value>
    ''' <returns>频率</returns>
    Public Property ImpOrder() As Integer
        Get
            Return (vImpOrder)
        End Get
        Set(ByVal Value As Integer)
            vImpOrder = Value
        End Set
    End Property

    ''' <summary>
    ''' 频率
    ''' </summary>
    ''' <value>频率</value>
    ''' <returns>频率</returns>
    Public Property UsrOrder() As Integer
        Get
            Return vUsrOrder
        End Get
        Set(ByVal Value As Integer)
            vUsrOrder = Value
        End Set
    End Property


    ''' <summary>
    ''' 构造函数
    ''' </summary>
    Public Sub New()
    End Sub

    ''' <summary>
    ''' 构造函数
    ''' </summary>
    ''' <param name="line">文字行（文字Tab全拼Tab词频Tab类型Tab是否混合输入）</param>
    Public Sub New(ByVal line As String)

        ' 文字 全拼 类型 混合输入
        Dim cols As String() = line.Split(vbTab)
        vText = cols(0)
        vPinYin = cols(1)
        vWordType = cols(2)
        vIsMixWord = CBool(cols(3))
        If cols.Length > 4 Then
            vShowDigit = CBool(cols(4))
        End If
        If cols.Length > 5 Then
            vDispText = cols(5)
        End If
    End Sub

    Public Property IsMixWord() As Boolean
        Get
            Return vIsMixWord
        End Get
        Set(ByVal Value As Boolean)
            vIsMixWord = Value
        End Set
    End Property

    ''' <summary>
    ''' 文字
    ''' </summary>
    ''' <value>文字</value>
    ''' <returns>文字</returns>
    Public Property Text() As String
        Get
            Return vText
        End Get
        Set(ByVal Value As String)
            vText = Value
        End Set
    End Property

    ' ''' <summary>
    ' ''' 检索串
    ' ''' </summary>
    ' ''' <value>检索串</value>
    ' ''' <returns>检索串</returns>
    'Public Property SearchKey() As String
    '    Get
    '        Return vSearchKey
    '    End Get
    '    Set(ByVal Value As String)
    '        vSearchKey = Value
    '    End Set
    'End Property

    ''' <summary>
    ''' 全拼
    ''' </summary>
    ''' <value>全拼</value>
    ''' <returns>全拼</returns>
    Public Property PinYin() As String
        Get
            Return vPinYin
        End Get
        Set(ByVal Value As String)
            vPinYin = Value
        End Set
    End Property


    ''' <summary>
    ''' 字词类型
    ''' </summary>
    ''' <value>字词类型</value>
    ''' <returns>字词类型</returns>
    Public Property WordType() As WordType
        Get
            Return vWordType
        End Get
        Set(ByVal Value As WordType)
            vWordType = Value
        End Set
    End Property

    ''' <summary>
    ''' 频率
    ''' </summary>
    ''' <value>频率</value>
    ''' <returns>频率</returns>
    Public Property Order() As Integer
        Get
            Return vOrder
        End Get
        Set(ByVal Value As Integer)
            vOrder = Value
        End Set
    End Property


    'Public Function CompareTo(ByVal obj As Object) As Integer Implements IComparable.CompareTo
    '    Dim word As CWord = obj
    '    If Me.ShortPinYin > word.ShortPinYin Then
    '        Return 1
    '    ElseIf Me.ShortPinYin < word.ShortPinYin Then
    '        Return -1
    '    ElseIf Me.Order > word.Order Then
    '        Return 1
    '    ElseIf Me.Order < word.Order Then
    '        Return -1
    '    ElseIf Me.PinYin > word.PinYin Then
    '        Return 1
    '    ElseIf Me.PinYin < word.PinYin Then
    '        Return -1
    '    ElseIf Me.Text > word.Text Then
    '        Return 1
    '    ElseIf Me.Text < word.Text Then
    '        Return -1
    '    Else
    '        Return 0
    '    End If
    'End Function

    ''' <summary>
    ''' 排序用比较方法
    ''' </summary>
    ''' <param name="obj">文字对象</param>
    ''' <returns>比较结果</returns>
    Public Function CompareTo(ByVal obj As Object) As Integer Implements IComparable.CompareTo
        Dim word As CWord = obj

        If Me.WordType And WordType.TOP Then
            If word.WordType And WordType.TOP Then
                Return Me.TopOrder > word.TopOrder
            Else
                Return -1
            End If
        ElseIf Me.WordType And WordType.USR Then
            If word.WordType And WordType.TOP Then
                Return 1
            ElseIf word.WordType And WordType.USR Then
                Return Me.UsrOrder > word.UsrOrder
            Else
                Return -1
            End If
        ElseIf Me.WordType And WordType.SYS Then

            If word.WordType And (WordType.USR Or WordType.TOP) Then
                Return 1
            ElseIf word.WordType And WordType.SYS Then
                Return Me.Order > word.Order
            Else
                Return -1
            End If
        ElseIf Me.WordType And WordType.IMP Then
            If word.WordType And (WordType.USR Or WordType.TOP Or WordType.SYS) Then
                Return 1
            ElseIf word.WordType And WordType.IMP Then
                Return Me.ImpOrder > word.ImpOrder
            Else
                Return -1
            End If
        Else
            Return -1
        End If

    End Function

    Public Overrides Function ToString() As String
        Return Me.Text & vbTab & Me.PinYin & vbTab & Me.WordType & vbTab & IIf(Me.IsMixWord, 1, 0)
    End Function

    ''' <summary>
    ''' 文字对象比较
    ''' </summary>
    ''' <param name="obj">文字对象</param>
    ''' <returns>比较结果</returns>
    Public Overloads Function Equals(ByVal obj As Object) As Boolean

        If Not obj.GetType.Equals(Me.GetType) Then
            Return False
        End If

        Dim word As CWord = obj

        Return Me.Text.Equals(word.Text) AndAlso Me.PinYin.Equals(word.PinYin)
    End Function

End Class
