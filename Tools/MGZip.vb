Imports System.IO
Imports System.IO.Compression
Imports System.Text

Module MGZip

    Public Function GZipCompress(ByVal str As String, Optional ByVal encode As String = "utf-8") As Byte()
        Dim ms As New MemoryStream()
        Dim gzip As New GZipStream(ms, CompressionMode.Compress)
        Dim bytes As Byte() = Encoding.GetEncoding(encode).GetBytes(str)
        gzip.Write(bytes, 0, bytes.Length)

        Dim ret As Byte() = ms.ToArray
        gzip.Close()

        Return ret
    End Function

    Public Function GZipDecompress(ByVal bytes As Byte(), Optional ByVal encode As String = "utf-8") As String

        Dim ms As New MemoryStream()
        Dim gzip As New GZipStream(New MemoryStream(bytes), CompressionMode.Decompress)
        gzip.CopyTo(ms)

        Dim ret As String = Encoding.GetEncoding(encode).GetString(ms.ToArray)
        gzip.Close()

        Return ret
    End Function

End Module
