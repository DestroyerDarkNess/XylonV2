' ***********************************************************************
' Author   : Original: http://filetypedetective.codeplex.com/ 
'            Source translated, revised and extended by Elektro.
'
' Modified : 03-06-2014
' ***********************************************************************
' <copyright file="FileTypeDetective.vb" company="Elektro Studios">
'     Copyright (c) Elektro Studios. All rights reserved.
' </copyright>
' ***********************************************************************

#Region " Info "

' file headers are taken from here:
'http://www.garykessler.net/library/file_sigs.html

' mime types are taken from here:
' http://www.webmaster-toolkit.com/mime-types.shtml

#End Region

#Region " Usage Examples "

'Imports FileTypeDetective

'Public Class Form1

'    Private Sub Test() Handles MyBase.Load

'        MessageBox.Show(Detective.isType("C:\File.reg", FileType.REG)) ' NOTE: The regfile should be Unicode, not ANSI.
'        MessageBox.Show(Detective.GetFileType("C:\File.reg").mime)

'    End Sub

'End Class

#End Region

#Region " Imports "

Imports System.IO

#End Region

#Region " FileType Detective "

''' <summary>
''' Little data structure to hold information about file types. 
''' Holds information about binary header at the start of the file
''' </summary>
Public Class FileType


    Public Shared ReadOnly WORDX As FileType = New FileType(New Byte?(-1) {}, 512, "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
    Public Shared ReadOnly EXCELX As FileType = New FileType(New Byte?(-1) {}, 512, "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
    Public Shared ReadOnly ODT As FileType = New FileType(New Byte?(-1) {}, 512, "odt", "application/vnd.oasis.opendocument.text")
    Public Shared ReadOnly ODS As FileType = New FileType(New Byte?(-1) {}, 512, "ods", "application/vnd.oasis.opendocument.spreadsheet")
    Public Shared ReadOnly MSDOC As FileType = New FileType(New Byte?() {&HD0, &HCF, &H11, &HE0, &HA1, &HB1, &H1A, &HE1}, "", "application/octet-stream")
    Public Shared ReadOnly XML As FileType = New FileType(New Byte?() {&H72, &H73, &H69, &H6F, &H6E, &H3D, &H22, &H31, &H2E, &H30, &H22, &H3F, &H3E}, "xml,xul", "text/xml")
    Public Shared ReadOnly TXT As FileType = New FileType(New Byte?(-1) {}, "txt", "text/plain")
    Public Shared ReadOnly TXT_UTF8 As FileType = New FileType(New Byte?() {&HEF, &HBB, &HBF}, "txt", "text/plain")
    Public Shared ReadOnly TXT_UTF16_BE As FileType = New FileType(New Byte?() {&HFE, &HFF}, "txt", "text/plain")
    Public Shared ReadOnly TXT_UTF16_LE As FileType = New FileType(New Byte?() {&HFF, &HFE}, "txt", "text/plain")
    Public Shared ReadOnly TXT_UTF32_BE As FileType = New FileType(New Byte?() {&H0, &H0, &HFE, &HFF}, "txt", "text/plain")
    Public Shared ReadOnly TXT_UTF32_LE As FileType = New FileType(New Byte?() {&HFF, &HFE, &H0, &H0}, "txt", "text/plain")
    Public Shared ReadOnly BMP As FileType = New FileType(New Byte?() {66, 77}, "bmp", "image/gif")
    Public Shared ReadOnly ICO As FileType = New FileType(New Byte?() {0, 0, 1, 0}, "ico", "image/x-icon")
    Public Shared ReadOnly GZ_TGZ As FileType = New FileType(New Byte?() {&H1F, &H8B, &H8}, "gz, tgz", "application/x-gz")
    Public Shared ReadOnly ZIP_7z As FileType = New FileType(New Byte?() {66, 77}, "7z", "application/x-compressed")
    Public Shared ReadOnly ZIP_7z_2 As FileType = New FileType(New Byte?() {&H37, &H7A, &HBC, &HAF, &H27, &H1C}, "7z", "application/x-compressed")
    Public Shared ReadOnly DLL_EXE As FileType = New FileType(New Byte?() {&H4D, &H5A}, "dll, exe", "application/octet-stream")
    Public Shared ReadOnly TAR_ZV As FileType = New FileType(New Byte?() {&H1F, &H9D}, "tar.z", "application/x-tar")
    Public Shared ReadOnly TAR_ZH As FileType = New FileType(New Byte?() {&H1F, &HA0}, "tar.z", "application/x-tar")
    Public Shared ReadOnly BZ2 As FileType = New FileType(New Byte?() {&H42, &H5A, &H68}, "bz2,tar,bz2,tbz2,tb2", "application/x-bzip2")
    Public Shared ReadOnly OGG As FileType = New FileType(New Byte?() {103, 103, 83, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0}, "oga,ogg,ogv,ogx", "application/ogg")
    Public Shared ReadOnly MIDI As FileType = New FileType(New Byte?() {&H4D, &H54, &H68, &H64}, "midi,mid", "audio/midi")
    Public Shared ReadOnly FLV As FileType = New FileType(New Byte?() {&H46, &H4C, &H56, &H1}, "flv", "application/unknown")
    Public Shared ReadOnly WAVE As FileType = New FileType(New Byte?() {&H52, &H49, &H46, &H46, Nothing, Nothing, Nothing, Nothing, &H57, &H41, &H56, &H45, &H66, &H6D, &H74, &H20}, "wav", "audio/wav")
    Public Shared ReadOnly PST As FileType = New FileType(New Byte?() {&H21, &H42, &H44, &H4E}, "pst", "application/octet-stream")
    Public Shared ReadOnly DWG As FileType = New FileType(New Byte?() {&H41, &H43, &H31, &H30}, "dwg", "application/acad")
    Public Shared ReadOnly PSD As FileType = New FileType(New Byte?() {&H38, &H42, &H50, &H53}, "psd", "application/octet-stream")
    Public Shared ReadOnly LIB_COFF As FileType = New FileType(New Byte?() {&H21, &H3C, &H61, &H72, &H63, &H68, &H3E, &HA}, "lib", "application/octet-stream")
    Public Shared ReadOnly AES As FileType = New FileType(New Byte?() {&H41, &H45, &H53}, "aes", "application/octet-stream")
    Public Shared ReadOnly SKR As FileType = New FileType(New Byte?() {&H95, &H0}, "skr", "application/octet-stream")
    Public Shared ReadOnly SKR_2 As FileType = New FileType(New Byte?() {&H95, &H1}, "skr", "application/octet-stream")
    Public Shared ReadOnly PKR As FileType = New FileType(New Byte?() {&H99, &H1}, "pkr", "application/octet-stream")
    Public Shared ReadOnly EML_FROM As FileType = New FileType(New Byte?() {&H46, &H72, &H6F, &H6D}, "eml", "message/rfc822")
    Public Shared ReadOnly ELF As FileType = New FileType(New Byte?() {&H45, &H6C, &H66, &H46, &H69, &H6C, &H65, &H0}, "elf", "text/plain")

    ' MS Office files
    Public Shared ReadOnly WORD As New FileType(
        New Nullable(Of Byte)() {&HEC, &HA5, &HC1, &H0}, 512I, "doc", "application/msword")

    Public Shared ReadOnly EXCEL As New FileType(
        New Nullable(Of Byte)() {&H9, &H8, &H10, &H0, &H0, &H6, &H5, &H0}, 512I, "xls", "application/excel")

    Public Shared ReadOnly PPT As New FileType(
        New Nullable(Of Byte)() {&HFD, &HFF, &HFF, &HFF, Nothing, &H0, &H0, &H0}, 512I, "ppt", "application/mspowerpoint")

    ' common documents
    Public Shared ReadOnly RTF As New FileType(
        New Nullable(Of Byte)() {&H7B, &H5C, &H72, &H74, &H66, &H31}, "rtf", "application/rtf")

    Public Shared ReadOnly PDF As New FileType(
        New Nullable(Of Byte)() {&H25, &H50, &H44, &H46}, "pdf", "application/pdf")

    Public Shared ReadOnly REG As New FileType(
        New Nullable(Of Byte)() {&HFF, &HFE}, "reg", "text/plain")

    ' grafics
    Public Shared ReadOnly JPEG As New FileType(
        New Nullable(Of Byte)() {&HFF, &HD8, &HFF}, "jpg", "image/jpeg")

    Public Shared ReadOnly PNG As New FileType(
        New Nullable(Of Byte)() {&H89, &H50, &H4E, &H47, &HD, &HA, &H1A, &HA}, "png", "image/png")

    Public Shared ReadOnly GIF As New FileType(
        New Nullable(Of Byte)() {&H47, &H49, &H46, &H38, Nothing, &H61}, "gif", "image/gif")

    ' Compressed
    Public Shared ReadOnly ZIP As New FileType(
        New Nullable(Of Byte)() {&H50, &H4B, &H3, &H4}, "zip", "application/x-compressed")

    Public Shared ReadOnly RAR As New FileType(
        New Nullable(Of Byte)() {&H52, &H61, &H72, &H21}, "rar", "application/x-compressed")

#Region " Types "

    Friend Shared ReadOnly types As New List(Of FileType)() From {
                PDF,
                WORD,
                EXCEL,
                JPEG,
                ZIP,
                RAR,
                RTF,
                PNG,
                PPT,
                GIF,
                DLL_EXE,
                MSDOC,
                BMP,
                DLL_EXE,
                ZIP_7z,
                ZIP_7z_2,
                GZ_TGZ,
                TAR_ZH,
                TAR_ZV,
                OGG,
                ICO,
                XML,
                MIDI,
                FLV,
                WAVE,
                DWG,
                LIB_COFF,
                PST,
                PSD,
                AES,
                SKR,
                SKR_2,
                PKR,
                EML_FROM,
                ELF,
                TXT_UTF8,
                TXT_UTF16_BE,
                TXT_UTF16_LE,
                TXT_UTF32_BE,
                TXT_UTF32_LE
            }

#End Region

    ' number of bytes we read from a file
    Friend Const MaxHeaderSize As Integer = 560
    ' some file formats have headers offset to 512 bytes

    ' most of the times we only need first 8 bytes, but sometimes extend for 16
    Private m_header As Nullable(Of Byte)()
    Public Property header() As Nullable(Of Byte)()
        Get
            Return m_header
        End Get
        Private Set(value As Nullable(Of Byte)())
            m_header = value
        End Set
    End Property

    Private m_headerOffset As Integer
    Public Property headerOffset() As Integer
        Get
            Return m_headerOffset
        End Get
        Private Set(value As Integer)
            m_headerOffset = value
        End Set
    End Property

    Private m_extension As String
    Public Property extension() As String
        Get
            Return m_extension
        End Get
        Private Set(value As String)
            m_extension = value
        End Set
    End Property

    Private m_mime As String
    Public Property mime() As String
        Get
            Return m_mime
        End Get
        Private Set(value As String)
            m_mime = value
        End Set
    End Property

#Region " Constructors "

    ''' <summary>
    ''' Initializes a new instance of the <see cref="FileType"/> class.
    ''' Default construction with the header offset being set to zero by default
    ''' </summary>
    ''' <param name="header">Byte array with header.</param>
    ''' <param name="extension">String with extension.</param>
    ''' <param name="mime">The description of MIME.</param>
    Public Sub New(header As Nullable(Of Byte)(), extension As String, mime As String)
        Me.header = header
        Me.extension = extension
        Me.mime = mime
        Me.headerOffset = 0
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the <see cref="FileType"/> struct.
    ''' Takes the details of offset for the header
    ''' </summary>
    ''' <param name="header">Byte array with header.</param>
    ''' <param name="offset">The header offset - how far into the file we need to read the header</param>
    ''' <param name="extension">String with extension.</param>
    ''' <param name="mime">The description of MIME.</param>
    Public Sub New(header As Nullable(Of Byte)(), offset As Integer, extension As String, mime As String)
        Me.header = Nothing
        Me.header = header
        Me.headerOffset = offset
        Me.extension = extension
        Me.mime = mime
    End Sub

#End Region

    Public Overrides Function Equals(other As Object) As Boolean

        If Not MyBase.Equals(other) Then
            Return False
        End If

        If Not (TypeOf other Is FileType) Then
            Return False
        End If

        Dim otherType As FileType = DirectCast(other, FileType)

        If Not Me.header Is otherType.header Then
            Return False
        End If

        If Me.headerOffset <> otherType.headerOffset Then
            Return False
        End If

        If Me.extension <> otherType.extension Then
            Return False
        End If

        If Me.mime <> otherType.mime Then
            Return False
        End If

        Return True

    End Function

    Public Overrides Function ToString() As String
        Return extension
    End Function

End Class

''' <summary>
''' Helper class to identify file type by the file header, not file extension.
''' </summary>
''' 
Public NotInheritable Class FileTypeDetective

    ''' <summary>
    ''' Prevents a default instance of the <see cref="FileTypeDetective"/> class from being created.
    ''' </summary>
    Private Sub New()
    End Sub

#Region "Main Methods"

    ''' <summary>
    ''' Gets the list of FileTypes based on list of extensions in Comma-Separated-Values string
    ''' </summary>
    ''' <param name="CSV">The CSV String with extensions</param>
    ''' <returns>List of FileTypes</returns>
    Private Shared Function GetFileTypesByExtensions(CSV As String) As List(Of FileType)
        Dim extensions As [String]() = CSV.ToUpper().Replace(" ", "").Split(","c)

        Dim result As New List(Of FileType)()

        For Each type As FileType In FileType.types
            If extensions.Contains(type.extension.ToUpper()) Then
                result.Add(type)
            End If
        Next
        Return result
    End Function

    ''' <summary>
    ''' Reads the file header - first (16) bytes from the file
    ''' </summary>
    ''' <param name="file">The file to work with</param>
    ''' <returns>Array of bytes</returns>
    Private Shared Function ReadFileHeader(file As FileInfo, MaxHeaderSize As Integer) As [Byte]()
        Dim header As [Byte]() = New Byte(MaxHeaderSize - 1) {}
        Try
            ' read file
            Using fsSource As New FileStream(file.FullName, FileMode.Open, FileAccess.Read)
                ' read first symbols from file into array of bytes.
                fsSource.Read(header, 0, MaxHeaderSize)
                ' close the file stream
            End Using
        Catch e As Exception
            ' file could not be found/read
            Throw New ApplicationException("Could not read file : " & e.Message)
        End Try

        Return header
    End Function

    ''' <summary>
    ''' Read header of a file and depending on the information in the header
    ''' return object FileType.
    ''' Return null in case when the file type is not identified. 
    ''' Throws Application exception if the file can not be read or does not exist
    ''' </summary>
    ''' <param name="file">The FileInfo object.</param>
    ''' <returns>FileType or null not identified</returns>
    Public Shared Function GetFileType(file As FileInfo) As FileType
        ' read first n-bytes from the file
        Dim fileHeader As [Byte]() = ReadFileHeader(file, FileType.MaxHeaderSize)

        ' compare the file header to the stored file headers
        For Each type As FileType In FileType.types
            Dim matchingCount As Integer = 0
            For i As Integer = 0 To type.header.Length - 1
                ' if file offset is not set to zero, we need to take this into account when comparing.
                ' if byte in type.header is set to null, means this byte is variable, ignore it
                If type.header(i) IsNot Nothing AndAlso type.header(i) <> fileHeader(i + type.headerOffset) Then
                    ' if one of the bytes does not match, move on to the next type
                    matchingCount = 0
                    Exit For
                Else
                    matchingCount += 1
                End If
            Next
            If matchingCount = type.header.Length Then
                ' if all the bytes match, return the type
                Return type
            End If
        Next
        ' if none of the types match, return null
        Return Nothing
    End Function

    ''' <summary>
    ''' Read header of a file and depending on the information in the header
    ''' return object FileType.
    ''' Return null in case when the file type is not identified. 
    ''' Throws Application exception if the file can not be read or does not exist
    ''' </summary>
    ''' <param name="file">The FileInfo object.</param>
    ''' <returns>FileType or null not identified</returns>
    Public Shared Function GetFileType(file As String) As FileType
        Return GetFileType(New FileInfo(file))
    End Function

    ''' <summary>
    ''' Determines whether provided file belongs to one of the provided list of files
    ''' </summary>
    ''' <param name="file">The file.</param>
    ''' <param name="requiredTypes">The required types.</param>
    ''' <returns>
    '''   <c>true</c> if file of the one of the provided types; otherwise, <c>false</c>.
    ''' </returns>
    Public Shared Function isFileOfTypes(file As FileInfo, requiredTypes As List(Of FileType)) As Boolean

        Dim currentType As FileType = GetFileType(file)

        If currentType Is Nothing Then
            Return False
        End If

        Return requiredTypes.Contains(currentType)

    End Function

    ''' <summary>
    ''' Determines whether provided file belongs to one of the provided list of files,
    ''' where list of files provided by string with Comma-Separated-Values of extensions
    ''' </summary>
    ''' <param name="file">The file.</param>
    ''' <returns>
    '''   <c>true</c> if file of the one of the provided types; otherwise, <c>false</c>.
    ''' </returns>
    Public Shared Function isFileOfTypes(file As FileInfo, CSV As String) As Boolean

        Dim providedTypes As List(Of FileType) = GetFileTypesByExtensions(CSV)

        Return isFileOfTypes(file, providedTypes)

    End Function

#End Region

#Region "isType functions"

    ''' <summary>
    ''' Determines whether the specified file is of provided type
    ''' </summary>
    ''' <param name="file">The file.</param>
    ''' <param name="type">The FileType</param>
    ''' <returns>
    '''   <c>true</c> if the specified file is type; otherwise, <c>false</c>.
    ''' </returns>
    Public Shared Function isType(file As FileInfo, type As FileType) As Boolean

        Dim actualType As FileType = GetFileType(file)

        If actualType Is Nothing Then
            Return False
        End If

        Return (actualType.Equals(type))

    End Function

    ''' <summary>
    ''' Determines whether the specified file is of provided type
    ''' </summary>
    ''' <param name="file">The file.</param>
    ''' <param name="type">The FileType</param>
    ''' <returns>
    '''   <c>true</c> if the specified file is type; otherwise, <c>false</c>.
    ''' </returns>
    Public Shared Function isType(file As String, type As FileType) As Boolean

        Return isType(New FileInfo(file), type)

    End Function

#End Region

End Class

#End Region
