Imports System.IO
Imports System.Security.Cryptography

Namespace Core.Hash

    Public Class FileHashCalculator


#Region " Properties "

        Private MD5_EX As String = String.Empty
        Public ReadOnly Property MD5 As String
            <DebuggerStepThrough>
            Get
                Return MD5_EX
            End Get
        End Property

        Private SHA1_EX As String = String.Empty
        Public ReadOnly Property SHA1 As String
            <DebuggerStepThrough>
            Get
                Return SHA1_EX
            End Get
        End Property

        Private SHA256_EX As String = String.Empty
        Public ReadOnly Property SHA256 As String
            <DebuggerStepThrough>
            Get
                Return SHA256_EX
            End Get
        End Property

        Private SHA384_EX As String = String.Empty
        Public ReadOnly Property SHA384 As String
            <DebuggerStepThrough>
            Get
                Return SHA384_EX
            End Get
        End Property

        Private SHA512_EX As String = String.Empty
        Public ReadOnly Property SHA512 As String
            <DebuggerStepThrough>
            Get
                Return SHA512_EX
            End Get
        End Property

#End Region

        Public Sub New(ByVal FilePath As String, Optional ByVal Delimiter As String = "")

            Try

                Dim MD5_Algo As HashAlgorithm = New MD5CryptoServiceProvider()
                MD5_EX = GetHash(FilePath, MD5_Algo, Delimiter)

                Dim sha1_Algo As HashAlgorithm = New SHA1CryptoServiceProvider()
                SHA1_EX = GetHash(FilePath, sha1_Algo, Delimiter)

                Dim sha256_Algo As HashAlgorithm = New SHA256CryptoServiceProvider()
                SHA256_EX = GetHash(FilePath, sha256_Algo, Delimiter)

                Dim sha384_Algo As HashAlgorithm = New SHA384CryptoServiceProvider()
                SHA384_EX = GetHash(FilePath, sha384_Algo, Delimiter)

                Dim sha512_Algo As HashAlgorithm = New SHA512CryptoServiceProvider()
                SHA512_EX = GetHash(FilePath, sha512_Algo, Delimiter)

            Catch ex As Exception
                Throw New Exception("Error :( " & vbNewLine & ex.Message)
            End Try

        End Sub

        Private Function GetHash(ByVal filePath As String, ByVal hasher As HashAlgorithm, Optional ByVal Delimit As String = "") As String
            Try
                Using fs = New FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                    Return GetHash(fs, hasher, Delimit)
                End Using
            Catch ex As Exception
                Return ex.Message
            End Try
        End Function

        Private Function GetHash(ByVal s As Stream, ByVal hasher As HashAlgorithm, Optional ByVal Delimit As String = "") As String
            Dim hash = hasher.ComputeHash(s)
            Return BitConverter.ToString(hash).Replace("-", Delimit).ToLowerInvariant()
        End Function

    End Class

End Namespace

