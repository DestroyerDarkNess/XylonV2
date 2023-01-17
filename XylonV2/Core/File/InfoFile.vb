Imports System.IO

Namespace Core.File
    Public Class InfoFile

#Region " Usage Example "

        ' [ InfoFile ]
        '
        ' Examples:
        '
        ' MsgBox(New InfoFile("C:\Test.txt").Name) ' Result: Test
        ' MsgBox(InfoFile.Get_Info("C:\Test.txt", InfoFile.Info.Extension_Without_Dot)) ' Result: txt
        ' MsgBox(InfoFile.Get_Info("C:\Test.txt", InfoFile.Info.FileName)) ' Result: Test.txt
        ' MsgBox(InfoFile.Get_Info("C:\Test.txt", InfoFile.Info.Directory)) ' Result: C:\
        ' MsgBox(InfoFile.Get_Info("C:\Test.txt", InfoFile.Info.DriveRoot)) ' Result: C:\
        ' MsgBox(InfoFile.Get_Info("C:\Test.txt", InfoFile.Info.DriveLetter)) ' Result: C
        ' MsgBox(InfoFile.Get_Info("C:\Test.txt", InfoFile.Info.FullName)) ' Result: C:\Test.txt
        ' MsgBox(InfoFile.Get_Info("C:\Test.txt", InfoFile.Info.ShortName)) ' Result: Test.txt
        ' MsgBox(InfoFile.Get_Info("C:\Test.txt", InfoFile.Info.ShortPath)) ' Result: C:\Test.txt
        ' MsgBox(InfoFile.Get_Info("C:\Test.txt", InfoFile.Info.Name_Length)) ' Result: 8
        ' MsgBox(InfoFile.Get_Info("C:\Test.txt", InfoFile.Info.Extension_Without_Dot_Length)) ' Result: 3
        ' MsgBox(InfoFile.Get_Info("C:\Test.txt", InfoFile.Info.FileName_Length)) ' Result: 8
        ' MsgBox(InfoFile.Get_Info("C:\Test.txt", InfoFile.Info.Directory_Length)) ' Result: 3
        ' MsgBox(InfoFile.Get_Info("C:\Test.txt", InfoFile.Info.FullName_Length)) ' Result: 11
        ' MsgBox(InfoFile.Get_Info("C:\Test.txt", InfoFile.Info.FileSize_Byte)) ' Result: 5.127.975
        ' MsgBox(InfoFile.Get_Info("C:\Test.txt", InfoFile.Info.FileSize_KB)) ' Result: 5.007.79
        ' MsgBox(InfoFile.Get_Info("C:\Test.txt", InfoFile.Info.FileSize_MB)) ' Result: 4,89
        ' MsgBox(InfoFile.Get_Info("C:\Test.txt", InfoFile.Info.FileSize_GB)) ' Result: 0,00
        ' MsgBox(InfoFile.Get_Info("C:\Test.txt", InfoFile.Info.FileSize_TB)) ' Result: 0,00
        ' MsgBox(InfoFile.Get_Info("C:\Test.txt", InfoFile.Info.FileVersion)) ' Result: ""
        ' MsgBox(InfoFile.Get_Info("C:\Test.txt", InfoFile.Info.Attributes_Enum)) ' Result: 8224
        ' MsgBox(InfoFile.Get_Info("C:\Test.txt", InfoFile.Info.Attributes_String)) ' Result: Archive, NotContentIndexed
        ' MsgBox(InfoFile.Get_Info("C:\Test.txt", InfoFile.Info.CreationTime)) ' Result: 16/09/2012  8:28:17 
        ' MsgBox(InfoFile.Get_Info("C:\Test.txt", InfoFile.Info.LastAccessTime)) ' Result: 16/09/2012 10:51:17
        ' MsgBox(InfoFile.Get_Info("C:\Test.txt", InfoFile.Info.LastModifyTime)) ' Result: 16/09/2012 10:51:17
        ' MsgBox(InfoFile.Get_Info("C:\Test.txt", InfoFile.Info.Has_Extension)) ' Result: True

#End Region

#Region " Enum "

        Public Enum Info

            Name                  ' Filename without extension
            Extension_With_Dot    ' File-Extension (with dot included)
            Extension_Without_Dot ' File-Extension (without dot)
            FileName              ' Filename.extension
            Directory             ' Directory name
            FullName              ' Directory path + Filename

            DriveRoot             ' Drive letter
            DriveLetter           ' Drive letter (only 1 character)

            ShortName ' DOS8.3 Filename
            ShortPath ' DOS8.3 Path Name

            Name_Length                  ' Length of Filename without extension
            Extension_With_Dot_Length    ' Length of File-Extension (with dot included)
            Extension_Without_Dot_Length ' Length of File-Extension (without dot)
            FileName_Length              ' Length of Filename.extension
            Directory_Length             ' Length of Directory name
            FullName_Length              ' Length of Directory path + Filename

            FileSize_Byte ' Size in Bytes
            FileSize_KB   ' Size in KiloBytes
            FileSize_MB   ' Size in MegaBytes
            FileSize_GB   ' Size in GigaBytes
            FileSize_TB   ' Size in TeraBytes

            FileVersion ' Version for DLL or EXE files

            Attributes_Enum   ' Attributes as numbers
            Attributes_String ' Attributes as descriptions

            CreationTime   ' Date Creation time
            LastAccessTime ' Date Last Access time
            LastModifyTime ' Date Last Modify time

            Has_Extension  ' Checks if file have a file-extension.

        End Enum

#End Region

#Region " Declare "

        Private CurrentFile As String = String.Empty
        Private File_Info As IO.FileInfo = Nothing

#End Region

#Region " Constructor "

        Public Sub New(Optional ByVal File As String = "")
            Try
                If Not File = "" Then
                    If IO.File.Exists(File) Then
                        CurrentFile = File
                        File_Info = New IO.FileInfo(File)
                    End If
                End If
            Catch ex As Exception

            End Try
        End Sub


        Public Shared Function Get_Info(ByVal File As String, ByVal Information As Info) As String

            Dim File_Info = My.Computer.FileSystem.GetFileInfo(File)

            Select Case Information

                Case Info.Name : Return File_Info.Name.Substring(0, File_Info.Name.LastIndexOf("."))
                Case Info.Extension_With_Dot : Return File_Info.Extension
                Case Info.Extension_Without_Dot : Return File_Info.Extension.Split(".").Last
                Case Info.FileName : Return File_Info.Name
                Case Info.Directory : Return File_Info.DirectoryName
                Case Info.DriveRoot : Return File_Info.Directory.Root.ToString
                Case Info.DriveLetter : Return File_Info.Directory.Root.ToString.Substring(0, 1)
                Case Info.FullName : Return File_Info.FullName
                Case Info.ShortName : Return CreateObject("Scripting.FileSystemObject").GetFile(File).ShortName
                Case Info.ShortPath : Return CreateObject("Scripting.FileSystemObject").GetFile(File).ShortPath
                Case Info.Name_Length : Return File_Info.Name.Length
                Case Info.Extension_With_Dot_Length : Return File_Info.Extension.Length
                Case Info.Extension_Without_Dot_Length : Return File_Info.Extension.Split(".").Last.Length
                Case Info.FileName_Length : Return File_Info.Name.Length
                Case Info.Directory_Length : Return File_Info.DirectoryName.Length
                Case Info.FullName_Length : Return File_Info.FullName.Length
                Case Info.FileSize_Byte : Return Convert.ToDouble(File_Info.Length).ToString("n0")
                Case Info.FileSize_KB : Return (Convert.ToDouble(File_Info.Length) / 1024L).ToString("n2")
                Case Info.FileSize_MB : Return (Convert.ToDouble(File_Info.Length) / 1024L ^ 2).ToString("n2")
                Case Info.FileSize_GB : Return (Convert.ToDouble(File_Info.Length) / 1024L ^ 3).ToString("n2")
                Case Info.FileSize_TB : Return (Convert.ToDouble(File_Info.Length) / 1024L ^ 4).ToString("n2")
                Case Info.FileVersion : Return CreateObject("Scripting.FileSystemObject").GetFileVersion(File)
                Case Info.Attributes_Enum : Return File_Info.Attributes
                Case Info.Attributes_String : Return File_Info.Attributes.ToString
                Case Info.CreationTime : Return File_Info.CreationTime
                Case Info.LastAccessTime : Return File_Info.LastAccessTime
                Case Info.LastModifyTime : Return File_Info.LastWriteTime
                Case Info.Has_Extension : Return IO.Path.HasExtension(File)

                Case Else : Return String.Empty

            End Select

        End Function

#End Region

#Region " Properties "

        Public ReadOnly Property Name As String
            <DebuggerStepThrough>
            Get
                Return File_Info.Name.Substring(0, File_Info.Name.LastIndexOf("."))
            End Get
        End Property

        Public ReadOnly Property Extension_With_Dot As String
            <DebuggerStepThrough>
            Get
                Return File_Info.Extension
            End Get
        End Property

        Public ReadOnly Property Extension_Without_Dot As String
            <DebuggerStepThrough>
            Get
                Return File_Info.Extension.Split(".").Last
            End Get
        End Property

        Public ReadOnly Property FileName As String
            <DebuggerStepThrough>
            Get
                Return File_Info.Name
            End Get
        End Property

        Public ReadOnly Property Directory As String
            <DebuggerStepThrough>
            Get
                Return File_Info.DirectoryName
            End Get
        End Property

        Public ReadOnly Property DriveRoot As String
            <DebuggerStepThrough>
            Get
                Return File_Info.Directory.Root.ToString
            End Get
        End Property

        Public ReadOnly Property DriveLetter As String
            <DebuggerStepThrough>
            Get
                Return File_Info.Directory.Root.ToString.Substring(0, 1)
            End Get
        End Property

        Public ReadOnly Property FullName As String
            <DebuggerStepThrough>
            Get
                Return File_Info.FullName
            End Get
        End Property

        Public ReadOnly Property ShortName As String
            <DebuggerStepThrough>
            Get
                Return CreateObject("Scripting.FileSystemObject").GetFile(CurrentFile).ShortName
            End Get
        End Property

        Public ReadOnly Property ShortPath As String
            <DebuggerStepThrough>
            Get
                Return CreateObject("Scripting.FileSystemObject").GetFile(CurrentFile).ShortPath
            End Get
        End Property

        Public ReadOnly Property Name_Length As Integer
            <DebuggerStepThrough>
            Get
                Return File_Info.Name.Length
            End Get
        End Property

        Public ReadOnly Property Extension_With_Dot_Length As Integer
            <DebuggerStepThrough>
            Get
                Return File_Info.Extension.Length
            End Get
        End Property

        Public ReadOnly Property Extension_Without_Dot_Length As Integer
            <DebuggerStepThrough>
            Get
                Return File_Info.Extension.Split(".").Last.Length
            End Get
        End Property


        Public ReadOnly Property FileName_Length As Integer
            <DebuggerStepThrough>
            Get
                Return File_Info.Name.Length
            End Get
        End Property

        Public ReadOnly Property Directory_Length As Integer
            <DebuggerStepThrough>
            Get
                Return File_Info.DirectoryName.Length
            End Get
        End Property

        Public ReadOnly Property FullName_Length As Integer
            <DebuggerStepThrough>
            Get
                Return File_Info.FullName.Length
            End Get
        End Property

        Public ReadOnly Property FileSize_Byte As String
            <DebuggerStepThrough>
            Get
                Return Convert.ToDouble(File_Info.Length).ToString("n0")
            End Get
        End Property

        Public ReadOnly Property FileSize_KB As String
            <DebuggerStepThrough>
            Get
                Return (Convert.ToDouble(File_Info.Length) / 1024L).ToString("n2")
            End Get
        End Property

        Public ReadOnly Property FileSize_MB As String
            <DebuggerStepThrough>
            Get
                Return (Convert.ToDouble(File_Info.Length) / 1024L ^ 2).ToString("n2")
            End Get
        End Property

        Public ReadOnly Property FileSize_GB As String
            <DebuggerStepThrough>
            Get
                Return (Convert.ToDouble(File_Info.Length) / 1024L ^ 3).ToString("n2")
            End Get
        End Property

        Public ReadOnly Property FileSize_TB As String
            <DebuggerStepThrough>
            Get
                Return (Convert.ToDouble(File_Info.Length) / 1024L ^ 4).ToString("n2")
            End Get
        End Property

        Public ReadOnly Property FileVersion As String
            <DebuggerStepThrough>
            Get
                Return CreateObject("Scripting.FileSystemObject").GetFileVersion(CurrentFile)
            End Get
        End Property

        Public ReadOnly Property Attributes_Enum As IO.FileAttributes
            <DebuggerStepThrough>
            Get
                Return File_Info.Attributes
            End Get
        End Property

        Public ReadOnly Property Attributes_String As String
            <DebuggerStepThrough>
            Get
                Return File_Info.Attributes.ToString
            End Get
        End Property

        Public ReadOnly Property CreationTime As Date
            <DebuggerStepThrough>
            Get
                Return File_Info.CreationTime
            End Get
        End Property

        Public ReadOnly Property LastAccessTime As Date
            <DebuggerStepThrough>
            Get
                Return File_Info.LastAccessTime
            End Get
        End Property

        Public ReadOnly Property LastWriteTime As Date
            <DebuggerStepThrough>
            Get
                Return File_Info.LastWriteTime
            End Get
        End Property

        Public ReadOnly Property LastModifyTime As Date
            <DebuggerStepThrough>
            Get
                Return File_Info.LastWriteTime
            End Get
        End Property

        Public ReadOnly Property Has_Extension As Boolean
            <DebuggerStepThrough>
            Get
                Return IO.Path.HasExtension(CurrentFile)
            End Get
        End Property

#End Region

        Public Function ToFileInfo() As IO.FileInfo
            If Not CurrentFile = "" Then
                If IO.File.Exists(CurrentFile) Then
                    Return New IO.FileInfo(CurrentFile)
                End If
            End If
            Throw New Exception("File Not Exits")
        End Function

    End Class
End Namespace
