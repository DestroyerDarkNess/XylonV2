Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text

Namespace StringExtract.Library
    Public Class Extractor

        Private Minimum_Characters As Integer

        Public Property MinimumCharacters As Integer
            Get
                Return Minimum_Characters
            End Get
            Set(ByVal value As Integer)
                If value < 3 Then value = 3
                Minimum_Characters = value
            End Set
        End Property

        Public Strings As List(Of String)

        Public Sub New()
            Strings = New List(Of String)()
        End Sub

        Public Sub New(ByVal MinCharacters As Integer)
            MinimumCharacters = MinCharacters
            Strings = New List(Of String)()
        End Sub

        Public Function Extract(ByVal filePath As String) As IEnumerable(Of String)
            Try
                If File.Exists(filePath) Then

                    Using stream = New FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None)
                        Return ParseStream(stream)
                    End Using
                Else
                    '   Throw New IOException($"File does not exist: {filePath}")
                End If
                Return Nothing
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Function Extract(ByVal fileBytes As Byte()) As IEnumerable(Of String)
            Try
                Using stream = New MemoryStream(fileBytes)
                    Return ParseStream(stream)
                End Using
                Return Nothing
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Private Function ParseStream(ByVal stream As MemoryStream) As IEnumerable(Of String)
            Try
                Const MAX_BUFFER_SIZE As Integer = 32768
                Dim buffer As Byte() = New Byte(32767) {}
                Dim bufferSize As Integer

                Do
                    bufferSize = stream.Read(buffer, 0, MAX_BUFFER_SIZE)

                    If bufferSize > 0 Then
                        Return ProcessBuffer(buffer, bufferSize)
                    End If
                Loop While bufferSize = MAX_BUFFER_SIZE

                Return New List(Of String)()
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Private Function ParseStream(ByVal stream As FileStream) As IEnumerable(Of String)
            Try
                Const MAX_BUFFER_SIZE As Integer = 32768
                Dim buffer As Byte() = New Byte(32767) {}
                Dim bufferSize As Integer

                Do
                    bufferSize = stream.Read(buffer, 0, MAX_BUFFER_SIZE)

                    If bufferSize > 0 Then
                        Return ProcessBuffer(buffer, bufferSize)
                    End If
                Loop While bufferSize = MAX_BUFFER_SIZE

                Return New List(Of String)()
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Private Iterator Function ProcessBuffer(ByVal buffer As Byte(), ByVal bufferSize As Integer) As IEnumerable(Of String)
            Try
                Dim offset As Integer = 0
                Dim stringSize As Integer = 0

                While offset + Minimum_Characters < bufferSize
                    Dim outputString = String.Empty
                    Dim stringDiskSpace As Integer = ProcessString(buffer, bufferSize, offset, stringSize, outputString)

                    If stringSize >= Minimum_Characters Then
                        Yield outputString
                        offset += stringDiskSpace
                    Else
                        offset += 1
                    End If
                End While
            Catch ex As Exception

            End Try
        End Function

        Private Function ProcessString(ByVal buffer As Byte(), ByVal bufferSize As Integer, ByVal offset As Integer, ByRef stringSize As Integer, ByRef outputString As String) As Integer
            On Error Resume Next

            Dim i As Integer = 0
            Dim builder As StringBuilder = New StringBuilder()

            If Globals.isAscii(buffer(offset)) Then

                If buffer(offset + 1) = &H0 Then

                    While offset + i + 1 < bufferSize AndAlso i / 2 < Globals.MaxStringSize AndAlso Globals.isAscii(buffer(offset + i)) AndAlso buffer(offset + i + 1) = 0 AndAlso i / 2 + 1 < Globals.MaxStringSize
                        builder.Append(ChrW(buffer(offset + i)))
                        i += 2
                    End While

                    outputString = builder.ToString()
                    stringSize = i / 2
                    Return i
                Else
                    i = offset

                    While i < bufferSize AndAlso Globals.isAscii(buffer(i))
                        i += 1
                    End While

                    stringSize = i - offset
                    If stringSize > Globals.MaxStringSize Then stringSize = Globals.MaxStringSize
                    outputString = Encoding.ASCII.GetString(buffer, offset, stringSize)
                    Return stringSize
                End If
            End If


            stringSize = 0
            Return 0

        End Function
    End Class
End Namespace
