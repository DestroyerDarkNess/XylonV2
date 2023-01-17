

Namespace Engine.External


    ' ResHacker.All_Resources_Extract("C:\File.exe", ResHacker.ResourceType.ICON)
    ' ResHacker.All_Resources_Extract("C:\File.dll", ResHacker.ResourceType.BITMAP, "C:\Temp\")
    ' ResHacker.MainIcon_Delete("C:\Old.exe", "C:\New.exe")
    ' ResHacker.MainIcon_Extract("C:\Program.exe", "C:\Icon.ico")
    ' ResHacker.MainIcon_Replace("C:\Old.exe", "C:\New.exe", "C:\Icon.ico")
    ' ResHacker.Resource_Add("C:\Old.exe", "C:\New.exe", "C:\Icon.ico", ResHacker.ResourceType.ICON, "Test", 1033)
    ' ResHacker.Resource_Delete("C:\Old.exe", "C:\New.exe", ResHacker.ResourceType.ICON, "MAINICON", 0)
    ' ResHacker.Resource_Extract("C:\Old.exe", "C:\New.exe", ResHacker.ResourceType.ICON, "MAINICON", 0)
    ' ResHacker.Resource_Replace("C:\Old.exe", "C:\New.exe", "C:\Icon.ico", ResHacker.ResourceType.ICON, "MAINICON", 0)
    ' ResHacker.Run_Script("C:\Reshacker.txt")
    ' ResHacker.Check_Last_Error()

#Region " ResHacker class "

    Public Class ResHacker

        ''' <summary>
        ''' Set the location of ResHacker executable [Default: ".\Reshacker.exe"].
        ''' </summary>
        Public Shared ResHacker_Location As String = ".\ResHacker.exe"
        ''' <summary>
        ''' Set the location of ResHacker log file [Default: ".\Reshacker.log"].
        ''' </summary>
        Public Shared ResHacker_Log_Location As String = ResHacker_Location.Substring(0, ResHacker_Location.Length - 4) & ".log"

        ' Most Known ResourceTypes
        ''' <summary>
        ''' The most known ResourceTypes.
        ''' </summary>
        Enum ResourceType
            ASFW
            AVI
            BINARY
            BINDATA
            BITMAP
            CURSOR
            DIALOG
            DXNAVBARSKINS
            FILE
            FONT
            FTR
            GIF
            HTML
            IBC
            ICON
            IMAGE
            JAVACLASS
            JPGTYPE
            LIBRARY
            MASK
            MENU
            MUI
            ORDERSTREAM
            PNG
            RCDATA
            REGINST
            REGISTRY
            STRINGTABLE
            RT_RCDATA
            SHADER
            STYLE_XML
            TYPELIB
            UIFILE
            VCLSTYLE
            WAVE
            WEVT_TEMPLATE
            XML
            XMLWRITE
        End Enum

        ' ------------------
        ' MainIcon functions
        ' ------------------

        ''' <summary>
        ''' Extract the main icon from file.
        ''' </summary>
        Public Shared Function MainIcon_Extract(ByVal InputFile As String,
                                         ByVal OutputIcon As String) As Boolean

            Try
                Dim ResHacker As New Process()
                Dim ResHacker_Info As New ProcessStartInfo()

                ResHacker_Info.FileName = ResHacker_Location
                ResHacker_Info.Arguments = "-extract " & """" & InputFile & """" & ", " & """" & OutputIcon & """" & ", ICONGROUP, MAINICON, 0"
                ResHacker_Info.UseShellExecute = False
                ResHacker.StartInfo = ResHacker_Info
                ResHacker.Start()
                ResHacker.WaitForExit()

                Return Check_Last_Error()

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Function

        ''' <summary>
        ''' Delete the main icon of file.
        ''' </summary>
        Public Shared Function MainIcon_Delete(ByVal InputFile As String,
                                            ByVal OutputFile As String) As Boolean

            Try
                Dim ResHacker As New Process()
                Dim ResHacker_Info As New ProcessStartInfo()

                ResHacker_Info.FileName = ResHacker_Location
                ResHacker_Info.Arguments = "-delete " & """" & InputFile & """" & ", " & """" & OutputFile & """" & ", ICONGROUP, MAINICON, 0"
                ResHacker_Info.UseShellExecute = False
                ResHacker.StartInfo = ResHacker_Info
                ResHacker.Start()
                ResHacker.WaitForExit()

                Return Check_Last_Error()

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Function

        ''' <summary>
        ''' Replace the main icon of file.
        ''' </summary>
        Public Shared Function MainIcon_Replace(ByVal InputFile As String,
                                        ByVal OutputFile As String,
                                        ByVal IconFile As String) As Boolean

            Try
                Dim ResHacker As New Process()
                Dim ResHacker_Info As New ProcessStartInfo()

                ResHacker_Info.FileName = ResHacker_Location
                ResHacker_Info.Arguments = "-addoverwrite " & """" & InputFile & """" & ", " & """" & OutputFile & """" & ", " & """" & IconFile & """" & ", ICONGROUP, MAINICON, 0"
                ResHacker_Info.UseShellExecute = False
                ResHacker.StartInfo = ResHacker_Info
                ResHacker.Start()
                ResHacker.WaitForExit()

                Return Check_Last_Error()

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Function

        ' ----------------------
        ' ResourceType functions
        ' ----------------------

        ''' <summary>
        ''' Add a resource to file.
        ''' </summary>
        Public Shared Function Resource_Add(ByVal InputFile As String,
                                        ByVal OutputFile As String,
                                        ByVal ResourceFile As String,
                                        ByVal ResourceType As ResourceType,
                                        ByVal ResourceName As String,
                                        Optional ByVal LanguageID As Int32 = 0) As Boolean

            Try
                Dim ResHacker As New Process()
                Dim ResHacker_Info As New ProcessStartInfo()

                ResHacker_Info.FileName = ResHacker_Location
                ResHacker_Info.Arguments = "-add " & """" & InputFile & """" & ", " & """" & OutputFile & """" & ", " & """" & ResourceFile & """" & ", " & ResourceType.ToString & ", " & """" & ResourceName & """" & ", " & LanguageID
                ResHacker_Info.UseShellExecute = False
                ResHacker.StartInfo = ResHacker_Info
                ResHacker.Start()
                ResHacker.WaitForExit()

                Return Check_Last_Error()

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Function

        ''' <summary>
        ''' Delete a resource from file.
        ''' </summary>
        Public Shared Function Resource_Delete(ByVal InputFile As String,
                                    ByVal OutputFile As String,
                                    ByVal ResourceType As ResourceType,
                                    ByVal ResourceName As String,
                                    Optional ByVal LanguageID As Int32 = 0) As Boolean

            Try
                Dim ResHacker As New Process()
                Dim ResHacker_Info As New ProcessStartInfo()

                ResHacker_Info.FileName = ResHacker_Location
                ResHacker_Info.Arguments = "-delete " & """" & InputFile & """" & ", " & """" & OutputFile & """" & ", " & ResourceType.ToString & ", " & """" & ResourceName & """" & ", " & LanguageID
                ResHacker_Info.UseShellExecute = False
                ResHacker.StartInfo = ResHacker_Info
                ResHacker.Start()
                ResHacker.WaitForExit()

                Return Check_Last_Error()

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Function

        ''' <summary>
        ''' Extract a resource from file.
        ''' </summary>
        Public Shared Function Resource_Extract(ByVal InputFile As String,
                                  ByVal OutputFile As String,
                                  ByVal ResourceType As ResourceType,
                                  ByVal ResourceName As String,
                                  Optional ByVal LanguageID As Int32 = 0) As Boolean

            Try
                Dim ResHacker As New Process()
                Dim ResHacker_Info As New ProcessStartInfo()

                ResHacker_Info.FileName = ResHacker_Location
                ResHacker_Info.Arguments = "-extract " & """" & InputFile & """" & ", " & """" & OutputFile & """" & ", " & ResourceType.ToString & ", " & """" & ResourceName & """" & ", " & LanguageID
                ResHacker_Info.UseShellExecute = False
                ResHacker.StartInfo = ResHacker_Info
                ResHacker.Start()
                ResHacker.WaitForExit()

                Return Check_Last_Error()

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Function

        ''' <summary>
        ''' Replace a resource from file.
        ''' </summary>
        Public Shared Function Resource_Replace(ByVal InputFile As String,
                              ByVal OutputFile As String,
                              ByVal ResourceFile As String,
                              ByVal ResourceType As ResourceType,
                              ByVal ResourceName As String,
                              Optional ByVal LanguageID As Int32 = 0) As Boolean

            Try
                Dim ResHacker As New Process()
                Dim ResHacker_Info As New ProcessStartInfo()

                ResHacker_Info.FileName = ResHacker_Location
                ResHacker_Info.Arguments = "-addoverwrite " & """" & InputFile & """" & ", " & """" & OutputFile & """" & ", " & """" & ResourceFile & """" & ", " & ResourceType.ToString & ", " & """" & ResourceName & """" & ", " & LanguageID
                ResHacker_Info.UseShellExecute = False
                ResHacker.StartInfo = ResHacker_Info
                ResHacker.Start()
                ResHacker.WaitForExit()

                Return Check_Last_Error()

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Function

        ' ----------------------
        ' All resources function
        ' ----------------------

        ''' <summary>
        ''' Extract all kind of resource from file.
        ''' </summary>
        Public Shared Function All_Resources_Extract(ByVal InputFile As String,
                                                 ByVal ResourceType As ResourceType,
                             Optional ByVal OutputDir As String = Nothing) As Boolean

            If OutputDir Is Nothing Then
                OutputDir = InputFile.Substring(0, InputFile.LastIndexOf("\")) _
                & "\" _
                & InputFile.Split("\").Last.Substring(0, InputFile.Split("\").Last.LastIndexOf(".")) _
                & ".rc"
            Else
                If OutputDir.EndsWith("\") Then OutputDir = OutputDir.Substring(0, OutputDir.Length - 1)
                OutputDir += "\" & InputFile.Split("\").Last.Substring(0, InputFile.Split("\").Last.LastIndexOf(".")) & ".rc"
            End If

            Try
                Dim ResHacker As New Process()
                Dim ResHacker_Info As New ProcessStartInfo()

                ResHacker_Info.FileName = ResHacker_Location
                ResHacker_Info.Arguments = "-extract " & """" & InputFile & """" & ", " & """" & OutputDir & """" & ", " & ResourceType.ToString & ",,"
                ResHacker_Info.UseShellExecute = False
                ResHacker.StartInfo = ResHacker_Info
                ResHacker.Start()
                ResHacker.WaitForExit()

                Return Check_Last_Error()

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Function

        ' ---------------
        ' Script function
        ' ---------------

        ''' <summary>
        ''' Run a ResHacker script file.
        ''' </summary>
        Public Shared Function Run_Script(ByVal ScriptFile As String) As Boolean

            Try
                Dim ResHacker As New Process()
                Dim ResHacker_Info As New ProcessStartInfo()

                ResHacker_Info.FileName = ResHacker_Location
                ResHacker_Info.Arguments = "-script " & """" & ScriptFile & """"
                ResHacker_Info.UseShellExecute = False
                ResHacker.StartInfo = ResHacker_Info
                ResHacker.Start()
                ResHacker.WaitForExit()

                Return Check_Last_Error()

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Function

        ' -------------------------
        ' Check Last Error function
        ' -------------------------

        ''' <summary>
        ''' Return the last operation error if any [False = ERROR, True = Ok].
        ''' </summary>
        Shared Function Check_Last_Error()
            Dim Line As String = Nothing
            Dim Text As IO.StreamReader = IO.File.OpenText(ResHacker_Log_Location)

            Do Until Text.EndOfStream
                Line = Text.ReadLine()
                If Line.ToString.StartsWith("Error: ") Then
                    MsgBox(Line)
                    Return False
                End If
            Loop

            Text.Close()
            Text.Dispose()
            Return True

        End Function

    End Class

#End Region

End Namespace
