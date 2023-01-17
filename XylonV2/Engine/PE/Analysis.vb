
Imports XylonV2.Engine.External.WindowsDefender
Imports XylonV2.Engine.PE.AVEnums

Namespace Engine.PE

    Public Class Analysis

        Private Shared exeLocation As String = Engine.External.WindowsDefender.WindowsDefenderScanner.GetDefenderPath()

        Public Shared Async Function StringAnalizerAsync(ByVal FilePath As String) As Task(Of Engine.External.Core.DetectionResult)
            Return StringScan(FilePath)
        End Function

        Public Shared Async Function ScanAsync(ByVal FilePath As String) As Task(Of Engine.External.Core.DetectionResult)
            Return Scan(FilePath)
        End Function

        Public Shared Function Scan(ByVal FilePath As String) As Engine.External.Core.DetectionResult

            Dim Descriptor As String = String.Empty
            Dim Signature As String = String.Empty
            Dim Result As Engine.External.Core.ScanResult = External.Core.ScanResult.NoThreatFound

            If exeLocation = String.Empty Then

                Return StringScan(FilePath)

            Else

                Dim scanner As WindowsDefenderScanner = New WindowsDefenderScanner(exeLocation)

                Result = scanner.Scan(FilePath)

                If Result = Engine.External.Core.ScanResult.ThreatFound Then
                    Signature = scanner.ResultParsed
                    Descriptor += "[ Malware ]  " & FilePath & "  ->  " & " Suspicius " & Environment.NewLine
                End If

            End If

            Dim DetectResult As New Engine.External.Core.DetectionResult(Result, Signature, Descriptor)

            Return DetectResult
        End Function

        Public Shared Function StringScan(ByVal FileBytes As Byte()) As Engine.External.Core.DetectionResult
            Try

                Dim Descriptor As String = String.Empty
                Dim Signature As String = String.Empty

                Dim Result As Engine.External.Core.ScanResult = Engine.External.Core.ScanResult.Timeout

                Dim StrExtractor As StringExtract.Library.Extractor = New StringExtract.Library.Extractor(3)
                Dim ExtractStrings As List(Of String) = StrExtractor.Extract(FileBytes).ToList

                Dim IsSuspicius As Boolean = IsHackString(ExtractStrings, Descriptor)

                If IsSuspicius = True Then

                    Signature = "HackTool:Win32/Gamehack"
                    Result = Engine.External.Core.ScanResult.ThreatFound

                End If

                If IsSuspicius = False Then
                    IsSuspicius = IsInjectorEntry(ExtractStrings, Descriptor)

                    If IsSuspicius = True Then
                        Signature = "HackTool:Win32/Injector"
                        Result = Engine.External.Core.ScanResult.ThreatFound
                    End If
                End If

                If IsSuspicius = False Then
                    IsSuspicius = IsHackEntry(ExtractStrings, Descriptor)

                    If IsSuspicius = True Then
                        Signature = "HackTool:Win32/Gamehack"
                        Result = Engine.External.Core.ScanResult.ThreatFound
                    End If

                End If

                If IsSuspicius = False Then
                    IsSuspicius = IsBrowserStealer(ExtractStrings, Descriptor)

                    If IsSuspicius = True Then
                        Signature = "Strings:BrowserStealer/Gen"
                        Result = Engine.External.Core.ScanResult.ThreatFound
                    End If

                End If

                If IsSuspicius = False Then
                    IsSuspicius = IsWalletStealer(ExtractStrings, Descriptor)

                    If IsSuspicius = True Then
                        Signature = "Strings:WalletStealer/Gen"
                        Result = Engine.External.Core.ScanResult.ThreatFound
                    End If

                End If

                If IsSuspicius = False Then
                    IsSuspicius = IsSuspiciusCall(ExtractStrings, Descriptor)

                    If IsSuspicius = True Then
                        Signature = "Strings:Caller/Gen"
                        Result = Engine.External.Core.ScanResult.ThreatFound
                    End If

                End If

                If IsSuspicius = False Then
                    IsSuspicius = IsSuspiciusInvoke(ExtractStrings, Descriptor)

                    If IsSuspicius = True Then
                        Signature = "Strings:Invoke/Gen"
                        Result = Engine.External.Core.ScanResult.ThreatFound
                    End If

                End If

                If IsSuspicius = False Then
                    IsSuspicius = IsSuspiciusPacker(ExtractStrings, Descriptor)

                    If IsSuspicius = True Then
                        Signature = "Strings:Packer/Gen"
                        Result = Engine.External.Core.ScanResult.ThreatFound
                    End If

                End If

                If IsSuspicius = False Then
                    IsSuspicius = IsCrypto(ExtractStrings, Descriptor)

                    If IsSuspicius = True Then
                        Signature = "Strings:Crypter/Gen"
                        Result = Engine.External.Core.ScanResult.ThreatFound
                    End If

                End If

                If IsSuspicius = False Then
                    IsSuspicius = IsSuspiciusStr(ExtractStrings, Descriptor)

                    If IsSuspicius = True Then
                        Signature = "Strings:Str/Gen"
                        Result = Engine.External.Core.ScanResult.ThreatFound
                    End If

                End If

                If IsSuspicius = False Then
                    IsSuspicius = IsSuspiciusShell(ExtractStrings, Descriptor)

                    If IsSuspicius = True Then
                        Signature = "Strings:Shell/Gen"
                        Result = Engine.External.Core.ScanResult.ThreatFound
                    End If

                End If

                If IsSuspicius = False Then
                    IsSuspicius = IsSuspiciusGeneric(ExtractStrings, Descriptor)

                    If IsSuspicius = True Then
                        Signature = "Strings:Malstr/Gen"
                        Result = Engine.External.Core.ScanResult.ThreatFound
                    End If

                End If

                If Result = Engine.External.Core.ScanResult.Timeout Then
                    Result = Engine.External.Core.ScanResult.NoThreatFound
                End If

                Dim DetectResult As New Engine.External.Core.DetectionResult(Result, Signature, Descriptor)

                Return DetectResult

            Catch ex As Exception
                Dim DetectResult As New Engine.External.Core.DetectionResult(Engine.External.Core.ScanResult.Error, "Error", ex.Message)
                Return DetectResult
            End Try
        End Function

        Public Shared Function StringScan(ByVal FilePath As String) As Engine.External.Core.DetectionResult
            Try

                Dim Descriptor As String = String.Empty
                Dim Signature As String = String.Empty

                If IO.File.Exists(FilePath) = True Then

                    Dim Result As Engine.External.Core.ScanResult = Engine.External.Core.ScanResult.Timeout

                    Dim StrExtractor As StringExtract.Library.Extractor = New StringExtract.Library.Extractor(3)
                    Dim ExtractStrings As List(Of String) = StrExtractor.Extract(FilePath).ToList

                    Dim IsSuspicius As Boolean = IsHackString(ExtractStrings, Descriptor)

                    If IsSuspicius = True Then

                        Signature = "HackTool:Win32/Gamehack" & "!" & IO.Path.GetExtension(FilePath)
                        Descriptor += "[ Hack ]  " & FilePath & "  ->  " & " Memory Editor " & Environment.NewLine
                        Result = Engine.External.Core.ScanResult.ThreatFound

                    End If

                    If IsSuspicius = False Then
                        IsSuspicius = IsInjectorEntry(ExtractStrings, Descriptor)

                        If IsSuspicius = True Then
                            Signature = "HackTool:Win32/Injector" & "!" & IO.Path.GetExtension(FilePath)
                            Descriptor += "[Injector Detection]  " & FilePath & "  ->  " & "Injector" & Environment.NewLine
                            Result = Engine.External.Core.ScanResult.ThreatFound
                        End If

                    End If

                    If IsSuspicius = False Then
                        IsSuspicius = IsHackEntry(ExtractStrings, Descriptor)

                        If IsSuspicius = True Then
                            Signature = "HackTool:Win32/Gamehack" & "!" & IO.Path.GetExtension(FilePath)
                            Descriptor += "[ Hack ]  " & FilePath & "  ->  " & " Memory Editor " & Environment.NewLine
                            Result = Engine.External.Core.ScanResult.ThreatFound
                        End If
                    End If

                    If IsSuspicius = False Then
                        IsSuspicius = IsBrowserStealer(ExtractStrings, Descriptor)

                        If IsSuspicius = True Then
                            Signature = "Strings:BrowserStealer/Gen" & "!" & IO.Path.GetExtension(FilePath)
                            Descriptor += "[ Malware ]  " & FilePath & Environment.NewLine
                            Result = Engine.External.Core.ScanResult.ThreatFound
                        End If

                    End If

                    If IsSuspicius = False Then
                        IsSuspicius = IsWalletStealer(ExtractStrings, Descriptor)

                        If IsSuspicius = True Then
                            Signature = "Strings:WalletStealer/Gen" & "!" & IO.Path.GetExtension(FilePath)
                            Descriptor += "[ Malware ]  " & FilePath & Environment.NewLine
                            Result = Engine.External.Core.ScanResult.ThreatFound
                        End If

                    End If

                    If IsSuspicius = False Then
                        IsSuspicius = IsSuspiciusInvoke(ExtractStrings, Descriptor)

                        If IsSuspicius = True Then
                            Signature = "Strings:Invoke/Gen" & "!" & IO.Path.GetExtension(FilePath)
                            Descriptor += "[ Malware ]  " & FilePath & Environment.NewLine
                            Result = Engine.External.Core.ScanResult.ThreatFound
                        End If

                    End If

                    If IsSuspicius = False Then
                        IsSuspicius = IsSuspiciusPacker(ExtractStrings, Descriptor)

                        If IsSuspicius = True Then
                            Signature = "Strings:Packer/Gen" & "!" & IO.Path.GetExtension(FilePath)
                            Descriptor += "[ Malware ]  " & FilePath & Environment.NewLine
                            Result = Engine.External.Core.ScanResult.ThreatFound
                        End If

                    End If

                    If IsSuspicius = False Then
                        IsSuspicius = IsCrypto(ExtractStrings, Descriptor)

                        If IsSuspicius = True Then
                            Signature = "Strings:Crypter/Gen" & "!" & IO.Path.GetExtension(FilePath)
                            Descriptor += "[ Malware ]  " & FilePath & Environment.NewLine
                            Result = Engine.External.Core.ScanResult.ThreatFound
                        End If

                    End If

                    If IsSuspicius = False Then
                        IsSuspicius = IsSuspiciusStr(ExtractStrings, Descriptor)

                        If IsSuspicius = True Then
                            Signature = "Strings:Str/Gen" & "!" & IO.Path.GetExtension(FilePath)
                            Descriptor += "[ Malware ]  " & FilePath & "  ->  " & " Protector " & Environment.NewLine
                            Result = Engine.External.Core.ScanResult.ThreatFound
                        End If

                    End If

                    If IsSuspicius = False Then
                        IsSuspicius = IsSuspiciusShell(ExtractStrings, Descriptor)

                        If IsSuspicius = True Then
                            Signature = "Strings:Shell/Gen" & "!" & IO.Path.GetExtension(FilePath)
                            Descriptor += "[ Malware ]  " & FilePath & Environment.NewLine
                            Result = Engine.External.Core.ScanResult.ThreatFound
                        End If

                    End If

                    If IsSuspicius = False Then
                        IsSuspicius = IsSuspiciusGeneric(ExtractStrings, Descriptor)

                        If IsSuspicius = True Then
                            Signature = "Strings:Malstr/Gen" & "!" & IO.Path.GetExtension(FilePath)
                            Descriptor += "[ Malware ]  " & FilePath & Environment.NewLine
                            Result = Engine.External.Core.ScanResult.ThreatFound
                        End If

                    End If

                    If IsSuspicius = False Then
                        IsSuspicius = IsSuspiciusCall(ExtractStrings, Descriptor)

                        If IsSuspicius = True Then
                            Signature = "Strings:Caller/Gen" & "!" & IO.Path.GetExtension(FilePath)
                            Descriptor += "[ Malware ]  " & FilePath & Environment.NewLine
                            Result = Engine.External.Core.ScanResult.ThreatFound
                        End If

                    End If

                    If Result = Engine.External.Core.ScanResult.Timeout Then
                        Result = Engine.External.Core.ScanResult.NoThreatFound
                    End If

                    Dim DetectResult As New Engine.External.Core.DetectionResult(Result, Signature, Descriptor)

                    Return DetectResult


                Else

                    Dim DetectResult As New Engine.External.Core.DetectionResult(Engine.External.Core.ScanResult.FileNotFound)
                    Return DetectResult

                End If
            Catch ex As Exception
                Dim DetectResult As New Engine.External.Core.DetectionResult(Engine.External.Core.ScanResult.Error, "Error", ex.Message)
                Return DetectResult
            End Try
        End Function

        Private Shared Function IsSuspiciusStr(ByVal ValNamers As List(Of String), ByRef DetectionEx As String) As Boolean
            Dim IsSuspicius As Boolean = False

            Dim MalSTRTypeList As List(Of Object) = [Enum].GetValues(GetType(MaliciusString)).Cast(Of Object)().ToList()
            Dim CounterCalcule As Integer = 0

            For Each ValNamer As String In ValNamers
                For Each MalSTR As Object In MalSTRTypeList
                    If ValNamer.Contains(MalSTR.ToString, StringComparison.OrdinalIgnoreCase) Then
                        DetectionEx += "[IsSuspicius]  " & ValNamer & "  ->  " & MalSTR & Environment.NewLine
                        CounterCalcule += 1
                    End If
                Next
            Next

            Return (Not CounterCalcule = 0)
        End Function

        Private Shared Function IsHackString(ByVal ValNamers As List(Of String), ByRef DetectionEx As String) As Boolean
            Dim IsSuspicius As Boolean = False

            Dim PinvokeTypeList As List(Of Object) = [Enum].GetValues(GetType(HackString)).Cast(Of Object)().ToList()
            Dim CounterCalcule As Integer = 0

            For Each ValNamer As Object In ValNamers
                For Each Pinvoke As Object In PinvokeTypeList
                    If ValNamer.ToString.Contains(Pinvoke.ToString, StringComparison.OrdinalIgnoreCase) Then
                        DetectionEx += "[IsCheatHack]  " & ValNamer & "  ->  " & Pinvoke & Environment.NewLine
                        CounterCalcule += 1
                    End If
                Next
            Next

            Return (CounterCalcule >= 5)
        End Function

        Private Shared Function IsHackEntry(ByVal ValNamers As List(Of String), ByRef DetectionEx As String) As Boolean
            Dim IsSuspicius As Boolean = False

            Dim PinvokeTypeList As List(Of Object) = [Enum].GetValues(GetType(HackEntry)).Cast(Of Object)().ToList()
            Dim CounterCalcule As Integer = 0

            For Each ValNamer As Object In ValNamers
                For Each Pinvoke As Object In PinvokeTypeList
                    If ValNamer.ToString.Contains(Pinvoke.ToString, StringComparison.OrdinalIgnoreCase) Then
                        DetectionEx += "[IsHack]  " & ValNamer & "  ->  " & Pinvoke & Environment.NewLine
                        CounterCalcule += 1
                    End If
                Next
            Next

            Return (CounterCalcule >= 3)
        End Function

        Private Shared Function IsInjectorEntry(ByVal ValNamers As List(Of String), ByRef DetectionEx As String) As Boolean
            Dim IsSuspicius As Boolean = False

            Dim PinvokeTypeList As List(Of Object) = [Enum].GetValues(GetType(InjectorEntry)).Cast(Of Object)().ToList()
            Dim CounterCalcule As Integer = 0

            For Each ValNamer As Object In ValNamers
                For Each Pinvoke As Object In PinvokeTypeList
                    If ValNamer.ToString.Contains(Pinvoke.ToString, StringComparison.OrdinalIgnoreCase) Then
                        DetectionEx += "[IsInjector]  " & ValNamer & "  ->  " & Pinvoke & Environment.NewLine
                        CounterCalcule += 1
                    End If
                Next
            Next

            Return (CounterCalcule >= 3)
        End Function


        Private Shared Function IsSuspiciusShell(ByVal ValNamers As List(Of String), ByRef DetectionEx As String) As Boolean
            Dim IsSuspicius As Boolean = False

            Dim MalSTRTypeList As List(Of Object) = [Enum].GetValues(GetType(ShellStr)).Cast(Of Object)().ToList()
            Dim CounterCalcule As Integer = 0

            For Each ValNamer As String In ValNamers
                For Each MalSTR As Object In MalSTRTypeList
                    If ValNamer.Contains(MalSTR.ToString, StringComparison.OrdinalIgnoreCase) Then
                        DetectionEx += "[IsSuspiciusShell]  " & ValNamer & "  ->  " & MalSTR & Environment.NewLine
                        CounterCalcule += 1
                    End If
                Next
            Next

            Return (Not CounterCalcule = 0)
        End Function

        Private Shared Function IsBrowserStealer(ByVal ValNamers As List(Of String), ByRef DetectionEx As String) As Boolean
            Dim IsSuspicius As Boolean = False

            Dim MalSTRTypeList As List(Of Object) = [Enum].GetValues(GetType(BrowserStealer)).Cast(Of Object)().ToList()
            Dim CounterCalcule As Integer = 0

            For Each ValNamer As String In ValNamers
                For Each MalSTR As Object In MalSTRTypeList
                    If ValNamer.Contains(MalSTR.ToString, StringComparison.OrdinalIgnoreCase) Then
                        DetectionEx += "[BrowserStealer]  " & ValNamer & "  ->  " & MalSTR & Environment.NewLine
                        CounterCalcule += 1
                    End If
                Next
            Next

            Return (CounterCalcule >= 5)
        End Function

        Private Shared Function IsWalletStealer(ByVal ValNamers As List(Of String), ByRef DetectionEx As String) As Boolean
            Dim IsSuspicius As Boolean = False

            Dim MalSTRTypeList As List(Of Object) = [Enum].GetValues(GetType(WalletStealer)).Cast(Of Object)().ToList()
            Dim CounterCalcule As Integer = 0

            For Each ValNamer As String In ValNamers
                For Each MalSTR As Object In MalSTRTypeList
                    If ValNamer.Contains(MalSTR.ToString, StringComparison.OrdinalIgnoreCase) Then
                        DetectionEx += "[WalletStealer]  " & ValNamer & "  ->  " & MalSTR & Environment.NewLine
                        CounterCalcule += 1
                    End If
                Next
            Next

            Return (Not CounterCalcule = 0) '(CounterCalcule >= (MalSTRTypeList.Count / 2))
        End Function

        Private Shared Function IsSuspiciusGeneric(ByVal ValNamers As List(Of String), ByRef DetectionEx As String) As Boolean
            Dim IsSuspicius As Boolean = False

            Dim MalSTRTypeList As List(Of Object) = [Enum].GetValues(GetType(GenericString)).Cast(Of Object)().ToList()
            Dim CounterCalcule As Integer = 0

            For Each ValNamer As String In ValNamers
                For Each MalSTR As Object In MalSTRTypeList
                    If ValNamer.Contains(MalSTR.ToString, StringComparison.OrdinalIgnoreCase) Then
                        DetectionEx += "[SuspiciusGeneric]  " & ValNamer & "  ->  " & MalSTR & Environment.NewLine
                        CounterCalcule += 1
                    End If
                Next
            Next

            Return (CounterCalcule >= (MalSTRTypeList.Count / 2))
        End Function

        Private Shared Function IsSuspiciusCall(ByVal ValNamers As List(Of String), ByRef DetectionEx As String) As Boolean
            Dim IsSuspicius As Boolean = False

            Dim MalSTRTypeList As List(Of Object) = [Enum].GetValues(GetType(SystemExeString)).Cast(Of Object)().ToList()
            Dim CounterCalcule As Integer = 0

            For Each ValNamer As String In ValNamers
                For Each MalSTR As Object In MalSTRTypeList
                    If ValNamer.Contains(MalSTR.ToString, StringComparison.OrdinalIgnoreCase) Then
                        DetectionEx += "[IsSuspiciusCall]  " & ValNamer & "  ->  " & MalSTR & Environment.NewLine
                        CounterCalcule += 1
                    End If
                Next
            Next

            Return (Not CounterCalcule = 0)
        End Function

        Private Shared Function IsSuspiciusInvoke(ByVal ValNamers As List(Of String), ByRef DetectionEx As String) As Boolean
            Dim IsSuspicius As Boolean = False

            Dim MalSTRTypeList As List(Of Object) = [Enum].GetValues(GetType(NetImportsString)).Cast(Of Object)().ToList()
            Dim CounterCalcule As Integer = 0

            For Each ValNamer As String In ValNamers
                For Each MalSTR As Object In MalSTRTypeList
                    If ValNamer.Contains(MalSTR.ToString, StringComparison.OrdinalIgnoreCase) Then
                        DetectionEx += "[IsSuspiciusInvoke]  " & ValNamer & "  ->  " & MalSTR & Environment.NewLine
                        CounterCalcule += 1
                    End If
                Next
            Next

            Return (Not CounterCalcule = 0)
        End Function

        Private Shared Function IsSuspiciusPacker(ByVal ValNamers As List(Of String), ByRef DetectionEx As String) As Boolean
            Dim IsSuspicius As Boolean = False

            Dim MalSTRTypeList As List(Of Object) = [Enum].GetValues(GetType(NetPackerString)).Cast(Of Object)().ToList()
            Dim CounterCalcule As Integer = 0

            For Each ValNamer As String In ValNamers
                For Each MalSTR As Object In MalSTRTypeList
                    If ValNamer.Contains(MalSTR.ToString, StringComparison.OrdinalIgnoreCase) Then
                        DetectionEx += "[IsSuspiciusPacker]  " & ValNamer & "  ->  " & MalSTR & Environment.NewLine
                        CounterCalcule += 1
                    End If
                Next
            Next

            Return (Not CounterCalcule = 0)
        End Function

        Private Shared Function IsCrypto(ByVal ValNamers As List(Of String), ByRef DetectionEx As String) As Boolean
            Dim IsSuspicius As Boolean = False

            Dim MalSTRTypeList As List(Of Object) = [Enum].GetValues(GetType(CriptoString)).Cast(Of Object)().ToList()
            Dim CounterCalcule As Integer = 0

            For Each ValNamer As String In ValNamers
                For Each MalSTR As Object In MalSTRTypeList
                    If ValNamer.Contains(MalSTR.ToString, StringComparison.OrdinalIgnoreCase) Then
                        DetectionEx += "[IsCrypto]  " & ValNamer & "  ->  " & MalSTR & Environment.NewLine
                        CounterCalcule += 1
                    End If
                Next
            Next

            Return (CounterCalcule >= 3)
        End Function

    End Class

End Namespace

