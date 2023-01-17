Imports System.Web.Script.Serialization
Imports System.Text.RegularExpressions

Namespace Core.Engine.WebBrowser
    Public Class Edge

#Region " Properties "

        Private ReadOnly ExtensionsColllection As New List(Of EdgeExtension)
        Public ReadOnly Property Extensions As List(Of EdgeExtension)
            <DebuggerStepThrough>
            Get
                Return Me.ExtensionsColllection
            End Get
        End Property

#End Region

#Region " Declare's "

        Public Shared ReadOnly ExtensionsPath = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "AppData\Local\Microsoft\Edge\User Data\Default\Extensions\")

        Private ExtensionsFolders As List(Of String) = FileDirSearcher.GetDirPaths(ExtensionsPath, IO.SearchOption.TopDirectoryOnly).ToList

#End Region


        Public Sub New(Optional ByVal ProcMethod As ProcesorMethod = ProcesorMethod.Sync)

            For Each ExFolder As String In ExtensionsFolders

                Dim ChoEx As New EdgeExtension(ExFolder, ProcMethod)
                ExtensionsColllection.Add(ChoEx)

            Next


        End Sub

#Region " Extension Data "

        <Serializable()>
        Public NotInheritable Class Manifest

#Region " ExProperties "

            Private FilePath As String = String.Empty
            Public Property FilePathJson As String
                <DebuggerStepThrough>
                Get
                    Return Me.FilePath
                End Get
                Set(value As String)
                    FilePath = value
                End Set
            End Property

#End Region


#Region " Child Classes "

            Public Class backgroundC
                Public Property persistent As Boolean
                Public Property scripts As List(Of String)
                Public Property allow_js_access As Boolean

                Public Overrides Function ToString() As String
                    Return New JavaScriptSerializer().Serialize(Me).ToString
                End Function
            End Class

            Public Class externally_connectableC
                Public Property ids As List(Of String)
                Public Property matches As List(Of String)

                Public Overrides Function ToString() As String
                    Return New JavaScriptSerializer().Serialize(Me).ToString
                End Function
            End Class

            Public Class oauth2C
                Public Property client_id As String
                Public Property scopes As List(Of String)
                Public Overrides Function ToString() As String
                    Return New JavaScriptSerializer().Serialize(Me).ToString
                End Function
            End Class

            Public Class appC
                Public Property launch As launchC
                Public Property web_content As web_contentC
                Public Property urls As List(Of String)

                Public Overrides Function ToString() As String
                    Return New JavaScriptSerializer().Serialize(Me).ToString
                End Function

                Public Class launchC
                    Public Property local_path As String
                    Public Property container As String
                    Public Property web_url As String

                    Public Overrides Function ToString() As String
                        Return New JavaScriptSerializer().Serialize(Me).ToString
                    End Function
                End Class

                Public Class web_contentC
                    Public Property enabled As Boolean
                    Public Property origin As String

                    Public Overrides Function ToString() As String
                        Return New JavaScriptSerializer().Serialize(Me).ToString
                    End Function
                End Class

            End Class

            Public Class browser_actionC
                ' Public Property default_icon As Dictionary(Of Integer, String)
                Public Property default_popup As String
                Public Property default_title As String

                Public Overrides Function ToString() As String
                    Return New JavaScriptSerializer().Serialize(Me).ToString
                End Function
            End Class

            Public Class content_scriptsC
                Public Property css As List(Of String)
                Public Property exclude_globs As List(Of String)
                Public Property include_globs As List(Of String)
                Public Property js As List(Of String)
                Public Property matches As List(Of String)
                Public Property run_at As String
                Public Property all_frames As Boolean
                Public Property match_about_blank As Boolean

                Public Overrides Function ToString() As String
                    Return New JavaScriptSerializer().Serialize(Me).ToString
                End Function

            End Class

            Public Class options_uiC
                Public Property chrome_style As Boolean
                Public Property open_in_tab As Boolean
                Public Property page As String

                Public Overrides Function ToString() As String
                    Return New JavaScriptSerializer().Serialize(Me).ToString
                End Function
            End Class

            Public Class browser_specific_settingsC
                Public Property gecko As geckoC


                Public Overrides Function ToString() As String
                    Return New JavaScriptSerializer().Serialize(Me).ToString
                End Function


                Public Class geckoC
                    Public Property id As String
                    Public Property strict_min_version As String

                    Public Overrides Function ToString() As String
                        Return New JavaScriptSerializer().Serialize(Me).ToString
                    End Function
                End Class

            End Class

            Public Class chrome_settings_overridesC
                Public Property homepage As String
                Public Property startup_pages As List(Of String)
                Public Property search_provider As search_providerC

                Public Overrides Function ToString() As String
                    Return New JavaScriptSerializer().Serialize(Me).ToString
                End Function

                Public Class search_providerC
                    Public Property encoding As String
                    Public Property favicon_url As String
                    Public Property is_default As Boolean
                    Public Property keyword As String
                    Public Property name As String
                    Public Property search_url As String
                    Public Property suggest_url As String
                    Public Property instant_url As String
                    Public Property image_url As String
                    Public Property search_url_post_params As String
                    Public Property suggest_url_post_params As String
                    Public Property instant_url_post_params As String
                    Public Property alternate_urls As List(Of String)

                    Public Overrides Function ToString() As String
                        Return New JavaScriptSerializer().Serialize(Me).ToString
                    End Function
                End Class


            End Class

            Public Class chrome_url_overridesC
                Public Property newtab As String

                Public Overrides Function ToString() As String
                    Return New JavaScriptSerializer().Serialize(Me).ToString
                End Function

            End Class

            Public Class storageC
                Public Property managed_schema As String

                Public Overrides Function ToString() As String
                    Return New JavaScriptSerializer().Serialize(Me).ToString
                End Function

            End Class

            Public Class authorC
                Public Property email As String

                Public Overrides Function ToString() As String
                    Return New JavaScriptSerializer().Serialize(Me).ToString
                End Function

            End Class

            Public Class content_capabilitiesC
                Public Property matches As List(Of String)
                Public Property permissions As List(Of String)

                Public Overrides Function ToString() As String
                    Return New JavaScriptSerializer().Serialize(Me).ToString
                End Function

            End Class

            Public Class omniboxC
                Public Property keyword As String

                Public Overrides Function ToString() As String
                    Return New JavaScriptSerializer().Serialize(Me).ToString
                End Function

            End Class

#End Region


            ' // Required
            Public Property manifest_version As String
            Public Property app As appC
            Public Property version As String
            Public Property name As String
            ' Public Property author As authorc

            ' // Recommended
            Public Property action As String
            Public Property default_locale As String
            Public Property description As String
            Public Property icons As Dictionary(Of String, String)

            Public Property persistent As Boolean
            Public Property scripts As String()

            ' // Optional
            Public Property automation As String
            Public Property background As backgroundC
            Public Property externally_connectable As externally_connectableC
            Public Property api_console_project_id As String
            Public Property container As String
            Public Property browser_action As browser_actionC
            Public Property differential_fingerprint As String
            Public Property browser_specific_settings As browser_specific_settingsC

            Public Property chrome_settings_overrides As chrome_settings_overridesC
            Public Property chrome_url_overrides As chrome_url_overridesC
            '  Public Property commands As String
            Public Property content_capabilities As content_capabilitiesC
            Public Property content_scripts As List(Of content_scriptsC)
            Public Property content_security_policy As String
            '     Public Property converted_from_user_script As String
            Public Property current_locale As String
            '  Public Property declarative_net_request As String
            Public Property devtools_page As String
            Public Property event_rules As String
            '  Public Property file_browser_handlers As String

            '  Public Property file_system_provider_capabilities As String

            Public Property homepage_url As String
            '  Public Property host_permissions As String
            '  Public Property import As String
            Public Property incognito As String
            '  Public Property input_componentss As String
            Public Property key As String
            Public Property minimum_chrome_version As String
            ' Public Property nacl_modules As String
            '  Public Property natively_connectable As String
            Public Property oauth2 As oauth2C
            Public Property offline_enabled As Boolean
            Public Property omnibox As omniboxC
            '  Public Property optional_permissions As String
            Public Property options_page As String
            Public Property options_ui As options_uiC
            Public Property permissions As List(Of String)
            '  Public Property platforms As String
            '  Public Property replacement_web_app As String
            '  Public Property requirements As String
            '  Public Property sandbox As String
            Public Property short_name As String
            Public Property storage As storageC
            '   Public Property system_indicator As String
            '  Public Property tts_engine As String
            Public Property update_url As String
            '  Public Property version_name As String
            Public Property web_accessible_resources As List(Of String)


            Public Sub New()

            End Sub

            Public Overrides Function ToString() As String
                Return New JavaScriptSerializer().Serialize(Me).ToString
            End Function

        End Class

        Public NotInheritable Class EdgeExtension

#Region " Properties "

#Region " Icons "

            Private ReadOnly IconX16 As Image = Nothing
            Public ReadOnly Property Icon16 As Image
                <DebuggerStepThrough>
                Get
                    Return Me.IconX16
                End Get
            End Property

            Private ReadOnly IconX48 As Image = Nothing
            Public ReadOnly Property Icon48 As Image
                <DebuggerStepThrough>
                Get
                    Return Me.IconX48
                End Get
            End Property

            Private ReadOnly IconX128 As Image = Nothing
            Public ReadOnly Property Icon128 As Image
                <DebuggerStepThrough>
                Get
                    Return Me.IconX128
                End Get
            End Property

            Private ReadOnly IconX32 As Image = Nothing
            Public ReadOnly Property Icon32 As Image
                <DebuggerStepThrough>
                Get
                    Return Me.IconX32
                End Get
            End Property

            Private ReadOnly IconX64 As Image = Nothing
            Public ReadOnly Property Icon64 As Image
                <DebuggerStepThrough>
                Get
                    Return Me.IconX64
                End Get
            End Property

            Private ReadOnly IconX256 As Image = Nothing
            Public ReadOnly Property Icon256 As Image
                <DebuggerStepThrough>
                Get
                    Return Me.IconX256
                End Get
            End Property

            Private ReadOnly IconX512 As Image = Nothing
            Public ReadOnly Property Icon512 As Image
                <DebuggerStepThrough>
                Get
                    Return Me.IconX512
                End Get
            End Property

#End Region

            Private ReadOnly ExtensionPath As String
            Public ReadOnly Property FullPath As String
                <DebuggerStepThrough>
                Get
                    Return Me.ExtensionPath
                End Get
            End Property

            Private ReadOnly MainFolderEx As String
            Public ReadOnly Property MainFolder As String
                <DebuggerStepThrough>
                Get
                    Return Me.MainFolderEx
                End Get
            End Property

            Private ManifestData As Manifest
            Public ReadOnly Property ManifestJson As Manifest
                <DebuggerStepThrough>
                Get
                    Return Me.ManifestData
                End Get
            End Property

            Private LoadStateEx As StateLoaded = StateLoaded.Indeterminate
            Public ReadOnly Property LoadState As StateLoaded
                <DebuggerStepThrough>
                Get
                    Return Me.LoadStateEx
                End Get
            End Property


            Private ExeptionInfoEx As String = String.Empty
            Public ReadOnly Property ExeptionInfo As String
                <DebuggerStepThrough>
                Get
                    Return Me.ExeptionInfoEx
                End Get
            End Property

#End Region

#Region " Constructors "

            <DebuggerNonUserCode>
            Private Sub New()
            End Sub

            <DebuggerStepThrough>
            Public Sub New(ByVal ExPath As String, ByVal ProcMethod As ProcesorMethod)

                ExtensionPath = ExPath

                Dim ExtensionFiles As List(Of String) = FileDirSearcher.GetFilePaths(ExPath, IO.SearchOption.AllDirectories).ToList

                For Each FileCurrent As String In ExtensionFiles

                    If String.Equals(IO.Path.GetFileName(FileCurrent), "manifest.json", StringComparison.OrdinalIgnoreCase) = True Then

                        Dim ExtensionVersionFolder As String = IO.Path.GetDirectoryName(FileCurrent)

                        MainFolderEx = ExtensionVersionFolder

                        If ProcMethod = ProcesorMethod.Sync Then

                            Try

                                Dim JsonCode As String = Core.Helper.Util.FileReadText(FileCurrent)

                                ManifestData = New JavaScriptSerializer().Deserialize(Of Manifest)(JsonCode)
                                ManifestData.FilePathJson = FileCurrent

                                If ManifestData.icons IsNot Nothing Then

                                    For Each IconsEx In ManifestData.icons

                                        Select Case CInt(IconsEx.Key)
                                            Case 16 : If IO.File.Exists(IO.Path.Combine(ExtensionVersionFolder, IconsEx.Value.ToString)) Then IconX16 = Image.FromFile(IO.Path.Combine(ExtensionVersionFolder, IconsEx.Value.ToString))
                                            Case 32 : If IO.File.Exists(IO.Path.Combine(ExtensionVersionFolder, IconsEx.Value.ToString)) Then IconX32 = Image.FromFile(IO.Path.Combine(ExtensionVersionFolder, IconsEx.Value.ToString))
                                            Case 48 : If IO.File.Exists(IO.Path.Combine(ExtensionVersionFolder, IconsEx.Value.ToString)) Then IconX48 = Image.FromFile(IO.Path.Combine(ExtensionVersionFolder, IconsEx.Value.ToString))
                                            Case 64 : If IO.File.Exists(IO.Path.Combine(ExtensionVersionFolder, IconsEx.Value.ToString)) Then IconX64 = Image.FromFile(IO.Path.Combine(ExtensionVersionFolder, IconsEx.Value.ToString))
                                            Case 128 : If IO.File.Exists(IO.Path.Combine(ExtensionVersionFolder, IconsEx.Value.ToString)) Then IconX128 = Image.FromFile(IO.Path.Combine(ExtensionVersionFolder, IconsEx.Value.ToString))
                                            Case 256 : If IO.File.Exists(IO.Path.Combine(ExtensionVersionFolder, IconsEx.Value.ToString)) Then IconX256 = Image.FromFile(IO.Path.Combine(ExtensionVersionFolder, IconsEx.Value.ToString))
                                            Case 512 : If IO.File.Exists(IO.Path.Combine(ExtensionVersionFolder, IconsEx.Value.ToString)) Then IconX512 = Image.FromFile(IO.Path.Combine(ExtensionVersionFolder, IconsEx.Value.ToString))
                                        End Select

                                    Next

                                End If

                                ' If ManifestData.browser_action IsNot Nothing Then
                                '  MsgBox("asd")
                                ' If Not ManifestData.browser_action.default_icon.ToString = String.Empty Then
                                '  If IO.File.Exists(IO.Path.Combine(ExtensionVersionFolder, ManifestData.browser_action.default_icon)) Then
                                '    ManifestData.browser_action.default_iconImage = Image.FromFile(IO.Path.Combine(ExtensionVersionFolder, ManifestData.browser_action.default_icon))
                                'End If
                                'End If
                                'End If

                                LoadStateEx = StateLoaded.Loaded
                            Catch ex As Exception
                                LoadStateEx = StateLoaded.Failed
                                Console.WriteLine(ex.Message)
                                ExeptionInfoEx += ex.Message & vbNewLine
                            End Try

                        ElseIf ProcMethod = ProcesorMethod.Async Then

                            Dim Asynctask As New Task(New Action(Async Function()
                                                                     Try
                                                                         Dim FileAsyncText As String = Await Core.Helper.Util.FileReadTextAsync(FileCurrent)
                                                                         ManifestData = New JavaScriptSerializer().Deserialize(Of Manifest)(FileAsyncText)
                                                                         ManifestData.FilePathJson = FileCurrent

                                                                         LoadStateEx = StateLoaded.Loaded
                                                                     Catch ex As Exception
                                                                         LoadStateEx = StateLoaded.Failed
                                                                         Console.WriteLine(ex.Message)
                                                                         ExeptionInfoEx += ex.Message & vbNewLine
                                                                     End Try

                                                                 End Function), TaskCreationOptions.PreferFairness)
                            Asynctask.Start()

                        End If

                    End If

                Next

            End Sub

            Public Function IconToList() As List(Of Image)
                Dim List As New List(Of Image)

                If IconX16 IsNot Nothing Then
                    List.Add(IconX16)
                End If

                If IconX32 IsNot Nothing Then
                    List.Add(IconX32)
                End If

                If IconX48 IsNot Nothing Then
                    List.Add(IconX48)
                End If

                If IconX64 IsNot Nothing Then
                    List.Add(IconX64)
                End If

                If IconX128 IsNot Nothing Then
                    List.Add(IconX128)
                End If

                If IconX256 IsNot Nothing Then
                    List.Add(IconX256)
                End If

                If IconX512 IsNot Nothing Then
                    List.Add(IconX512)
                End If

                If List.Count = 0 Then
                    Return Nothing
                Else
                    Return List
                End If
            End Function


            Public Overrides Function ToString() As String
                Return New JavaScriptSerializer().Serialize(Me).ToString
            End Function

#End Region

        End Class

#End Region


        Public Class EdgeScanner

            Private SuspiciusInfoEx As String = String.Empty
            Public ReadOnly Property SuspiciusInfo As String
                <DebuggerStepThrough>
                Get
                    Return Me.SuspiciusInfoEx
                End Get
            End Property

            Private Function GetMaliciusPermision() As List(Of String)
                Dim MPermision As New List(Of String)
                MPermision.AddRange({"https://*/*", "http//*/*", "tabs"})
                Return MPermision
            End Function

            Public Function IsSuspiciusExtension(ByVal GExtensions As EdgeExtension) As Boolean
                '  On Error Resume Next

                Dim MaliciusPermision As List(Of String) = GetMaliciusPermision()

                If GExtensions.ManifestJson.chrome_settings_overrides IsNot Nothing Then
                    If Not GExtensions.ManifestJson.chrome_settings_overrides.homepage = String.Empty Then
                        SuspiciusInfoEx += "Startup.Changer" & vbNewLine
                        Return True
                    End If
                End If

                Dim MPCount As Integer = 0

                If GExtensions.ManifestJson.permissions IsNot Nothing Then

                    For Each PerMision As String In GExtensions.ManifestJson.permissions

                        For Each MPstr As String In MaliciusPermision
                            If String.Equals(PerMision, MPstr, StringComparison.OrdinalIgnoreCase) = True Then
                                MPCount += 1
                            End If
                        Next

                    Next

                    If MPCount >= 3 Then
                        Return True
                    End If

                End If

                If GExtensions.ManifestJson.web_accessible_resources IsNot Nothing Then

                    For Each ScriptCurrent As String In GExtensions.ManifestJson.web_accessible_resources

                        Dim SourceText As String = Core.Helper.Util.FileReadText(IO.Path.Combine(GExtensions.MainFolder, ScriptCurrent.Replace("/", "\")))

                        Dim FoundLines As String() = SourceText.Split(vbLf)

                        For Each LineStr As String In FoundLines

                            Dim CurrentLine As String = LCase(LineStr)

                            If CurrentLine.Contains(LCase("innerText")) = True Then

                                If CurrentLine.Contains("password") = True Then
                                    SuspiciusInfoEx += "SCRIPT.Stealer" & vbNewLine
                                    Return True
                                End If

                            ElseIf CurrentLine.Contains(LCase("innerHTML")) = True Then

                                SuspiciusInfoEx += "HTML.Injection" & vbNewLine
                                Return True

                            ElseIf CurrentLine.Contains(LCase("createElement('script')")) = True Then

                                SuspiciusInfoEx += "SCRIPT.Injection" & vbNewLine
                                Return True

                            ElseIf CurrentLine.Contains(LCase("tabs.executeScript")) = True Then

                                SuspiciusInfoEx += "SCRIPT.Execute" & vbNewLine
                                Return True

                            ElseIf ContainsAddress(CurrentLine) = True Then

                                SuspiciusInfoEx += "Possible.Stealer" & vbNewLine
                                Return True

                            End If

                        Next


                    Next
                End If

                Return False

            End Function

            Private Shared ReadOnly Pattern As Regex = New Regex("((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)")

            Private Shared Function ContainsAddress(ByVal line As String) As Boolean
                Return Pattern.IsMatch(line)
            End Function

        End Class


        Public Enum ProcesorMethod
            Sync = 0
            Async = 1
        End Enum

        Public Enum StateLoaded
            Indeterminate = 0
            Loaded = 1
            Failed = 2
        End Enum

    End Class
End Namespace

