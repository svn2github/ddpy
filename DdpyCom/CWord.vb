Imports System.Runtime.InteropServices

''' <summary>
''' 文字类型
''' </summary>
Friend Enum WordType
    ''' <summary>
    ''' 字典类型
    ''' </summary>
    DIC = 0
    ''' <summary>
    ''' 用户类型
    ''' </summary>
    USR = 9
End Enum


''' <summary>
''' 文字类
''' </summary>
''' <remarks></remarks>
<Serializable()> _
Friend Class CWord
    Implements IComparable

    Private vText As String                 ' 文字
    Private vShortPinYin As String          ' 简拼
    Private vPinYin As String               ' 全拼
    Private vOrder As Integer               ' 词频
    Private vWordType As WordType = WordType.DIC          ' 类型
    Private vIsMixWord As Boolean

    ''' <summary>
    ''' 构造函数
    ''' </summary>
    Public Sub New()
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
    ''' 构造函数
    ''' </summary>
    ''' <param name="line">文字行（文字Tab简拼Tab全拼Tab词频Tab类型）</param>
    Public Sub New(ByVal line As String)

        ' 文字 简拼 全拼 词频 类型
        Dim cols As String() = line.Split(vbTab)
        vText = cols(0)
        vShortPinYin = cols(1)
        vPinYin = cols(2)
        vOrder = cols(3)

        If cols.Length > 4 Then
            vWordType = cols(4)
        End If
    End Sub

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

    ''' <summary>
    ''' 简拼
    ''' </summary>
    ''' <value>简拼</value>
    ''' <returns>简拼</returns>
    Public Property ShortPinYin() As String
        Get
            Return vShortPinYin
        End Get
        Set(ByVal Value As String)
            vShortPinYin = Value
        End Set
    End Property

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
        If Me.WordType > word.WordType Then
            Return -1
        ElseIf Me.WordType < word.WordType Then
            Return 1
        Else
            Return Me.Order > word.Order
        End If
    End Function

    Public Overrides Function ToString() As String
        Return Me.Text & vbTab & Me.ShortPinYin & vbTab & Me.PinYin & vbTab & Me.Order & vbTab & Me.WordType
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
