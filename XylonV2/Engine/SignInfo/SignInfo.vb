Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.IO
Imports System.Reflection
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports System.Runtime.InteropServices

Namespace Engine

    Public Enum SignResult
        FileNotFound = -1
        FileSignedAndVerified = 0
        FileNotSigned = 1
        FileSignatureNotVerified = 2
    End Enum

    Public Class Sign
        Public Property Result As SignResult = SignResult.FileNotSigned
        Public Property Status As String = String.Empty
        Public Property Publisher As String = String.Empty
    End Class


    Public Class SignInfo
        Private ReadOnly backupColor As ConsoleColor
        Public Property ShowFileHashes As Boolean
        Public Property ShowSigningChain As Boolean
        Public Property ShowExtendedVersionInfo As Boolean
        Public Property ShowHelp As Boolean
        Public Property FileSpec As String
        Public Property NoBanner As Boolean

        Public Shared Function AnalyzeFile(ByVal FilePath As String, Optional ByVal BuildMode As X509RevocationMode = X509RevocationMode.NoCheck) As Sign
            Dim ResultSign As Sign = New Sign

            Dim FileInstance As IO.FileInfo = New FileInfo(FilePath)

            If Not FileInstance.Exists Then
                ResultSign.Result = SignResult.FileNotFound
                Return ResultSign
            End If

            Dim returnValue As SignResult

            Try
                Dim cert = X509Certificate.CreateFromSignedFile(FilePath)
                Dim cert2 = New X509Certificate2(cert)
                Dim validChain As String = BuildCertificateChain(cert2, BuildMode)
                returnValue = If((validChain = "Signed"), SignResult.FileSignedAndVerified, SignResult.FileSignatureNotVerified)

                ResultSign.Result = returnValue
                ResultSign.Status = validChain
                ResultSign.Publisher = GetFriendlyCertificateName(cert2)

                cert2.Dispose()
                cert.Dispose()
            Catch ex As Exception
                ResultSign.Status = ($"Unsigned ({ex.Message})")
                ResultSign.Result = SignResult.FileNotSigned
                ResultSign.Publisher = String.Empty
            End Try

            Return ResultSign
        End Function

        Private Shared Function BuildCertificateChain(ByVal cert As X509Certificate2, ByVal CheckMode As X509RevocationMode) As String
            Dim chain = New X509Chain()
            chain.ChainPolicy.RevocationMode = CheckMode
            Dim built As Boolean = chain.Build(cert)

            If built = False Then
                Return "Unsigned"
            End If

            Return "Signed"
        End Function

        Private Shared Function GetFriendlyCertificateName(ByVal cert As X509Certificate2) As String
            Dim data = cert.SubjectName.Decode(X500DistinguishedNameFlags.UseNewLines)

            If String.IsNullOrEmpty(data) Then
                Return "???"
            End If

            Dim lines = data.Split(vbLf)

            For Each line In lines

                If line.StartsWith("CN=") Then
                    Return line.Substring(3)
                End If
            Next

            Return "???"
        End Function

        Private Shared Function GetUsageString(ByVal cert As X509Certificate2) As String
            Dim usageText = "Unknown"

            For Each certExtension In cert.Extensions

                If TypeOf certExtension Is X509KeyUsageExtension Then
                    usageText = DirectCast(certExtension, X509KeyUsageExtension).KeyUsages.ToString()
                End If

            Next

            Return usageText
        End Function

    End Class
End Namespace
