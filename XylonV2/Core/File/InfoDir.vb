
Namespace Core.Folder
    Public Class InfoDir

#Region " InfoDir "

        ' [ InfoDir ]
        '
        ' // By Elektro H@cker
        '
        ' Examples:
        '
        ' MsgBox(InfoDir.Get_Info("C:\Test Parent\Test", InfoDir.Info.Name)) ' Result: Test
        ' MsgBox(InfoDir.Get_Info("C:\Test Parent\Test", InfoDir.Info.Parent)) ' Result: Test Parent
        ' MsgBox(InfoDir.Get_Info("C:\Test Parent\Test", InfoDir.Info.FullName)) ' Result: C:\Test Parent\Test
        ' MsgBox(InfoDir.Get_Info("C:\Test Parent\Test", InfoDir.Info.DriveRoot)) ' Result: C:\
        ' MsgBox(InfoDir.Get_Info("C:\Test Parent\Test", InfoDir.Info.DriveLetter)) ' Result: C
        ' MsgBox(InfoDir.Get_Info("C:\Test Parent\Test", InfoDir.Info.Name_Length)) ' Result: 4
        ' MsgBox(InfoDir.Get_Info("C:\Test Parent\Test", InfoDir.Info.FullName_Length)) ' Result: 19
        ' MsgBox(InfoDir.Get_Info("C:\Test Parent\Test", InfoDir.Info.Attributes_Enum)) ' Result: 8208
        ' MsgBox(InfoDir.Get_Info("C:\Test Parent\Test", InfoDir.Info.Attributes_String)) ' Result: Directory, NotContentIndexed
        ' MsgBox(InfoDir.Get_Info("C:\Test Parent\Test", InfoDir.Info.CreationTime)) ' Result: 16/09/2012  8:28:17 
        ' MsgBox(InfoDir.Get_Info("C:\Test Parent\Test", InfoDir.Info.LastAccessTime)) ' Result: 16/09/2012 10:51:17
        ' MsgBox(InfoDir.Get_Info("C:\Test Parent\Test", InfoDir.Info.LastModifyTime)) ' Result: 16/09/2012 10:51:17
        ' MsgBox(InfoDir.Get_Info("C:\Test Parent\Test", InfoDir.Info.FileSize_Byte)) ' Result: 5.127.975
        ' MsgBox(InfoDir.Get_Info("C:\Test Parent\Test", InfoDir.Info.FileSize_KB)) ' Result: 5.007.79
        ' MsgBox(InfoDir.Get_Info("C:\Test Parent\Test", InfoDir.Info.FileSize_MB)) ' Result: 4,89
        ' MsgBox(InfoDir.Get_Info("C:\Test Parent\Test", InfoDir.Info.FileSize_GB)) ' Result: 0,00
        ' MsgBox(InfoDir.Get_Info("C:\Test Parent\Test", InfoDir.Info.FileSize_TB)) ' Result: 0,00

        Public Enum Info

            Name                  ' Folder name
            FullName              ' Directory path
            Parent                ' Parent directory

            DriveRoot             ' Drive letter
            DriveLetter           ' Drive letter (only 1 character)

            Name_Length                  ' Length of directory name
            FullName_Length              ' Length of full directory path

            FileSize_Byte ' Size in Bytes     (including subfolders)
            FileSize_KB   ' Size in KiloBytes (including subfolders)
            FileSize_MB   ' Size in MegaBytes (including subfolders)
            FileSize_GB   ' Size in GigaBytes (including subfolders)
            FileSize_TB   ' Size in TeraBytes (including subfolders)

            Attributes_Enum   ' Attributes as numbers
            Attributes_String ' Attributes as descriptions

            CreationTime   ' Date Creation time
            LastAccessTime ' Date Last Access time
            LastModifyTime ' Date Last Modify time

        End Enum

        Public Shared Function Get_Info(ByVal Dir As String, ByVal Information As Info) As String

            Dim Dir_Info As IO.DirectoryInfo = New IO.DirectoryInfo(Dir)

            Select Case Information

                Case Info.Name : Return Dir_Info.Name
                Case Info.FullName : Return Dir_Info.FullName
                Case Info.Parent : Return Dir_Info.Parent.ToString
                Case Info.DriveRoot : Return Dir_Info.Root.ToString
                Case Info.DriveLetter : Return Dir_Info.Root.ToString.Substring(0, 1)
                Case Info.Name_Length : Return Dir_Info.Name.Length
                Case Info.FullName_Length : Return Dir_Info.FullName.Length
                Case Info.FileSize_Byte : Return Convert.ToDouble(Get_Directory_Size(Dir_Info)).ToString("n0")
                Case Info.FileSize_KB : Return (Convert.ToDouble(Get_Directory_Size(Dir_Info)) / 1024L).ToString("n2")
                Case Info.FileSize_MB : Return (Convert.ToDouble(Get_Directory_Size(Dir_Info)) / 1024L ^ 2).ToString("n2")
                Case Info.FileSize_GB : Return (Convert.ToDouble(Get_Directory_Size(Dir_Info)) / 1024L ^ 3).ToString("n2")
                Case Info.FileSize_TB : Return (Convert.ToDouble(Get_Directory_Size(Dir_Info)) / 1024L ^ 4).ToString("n2")
                Case Info.Attributes_Enum : Return Dir_Info.Attributes
                Case Info.Attributes_String : Return Dir_Info.Attributes.ToString
                Case Info.CreationTime : Return Dir_Info.CreationTime
                Case Info.LastAccessTime : Return Dir_Info.LastAccessTime
                Case Info.LastModifyTime : Return Dir_Info.LastWriteTime

                Case Else : Return String.Empty

            End Select

        End Function

        Private Shared Function Get_Directory_Size(Directory As IO.DirectoryInfo) As Long
            Try
                Dim Dir_Total_Size As Long = Directory.EnumerateFiles().Sum(Function(file) file.Length)
                Dir_Total_Size += Directory.EnumerateDirectories().Sum(Function(dir) Get_Directory_Size(dir))
                Return Dir_Total_Size
            Catch
            End Try
            Return -1
        End Function

#End Region

    End Class
End Namespace
