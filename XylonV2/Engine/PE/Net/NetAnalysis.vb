Imports dnlib.DotNet
Imports XylonV2.Engine.PE.AVEnums

Namespace Engine.PE.Net.Core

    Public Class NetAnalysis

        Public Shared Async Function NetScannerAsync(ByVal FilePath As String) As Task(Of Engine.External.Core.DetectionResult)
            Return NetScanner(FilePath)
        End Function

        Public Shared Function NetScanner(ByVal FilePath As String) As Engine.External.Core.DetectionResult
            Try
                Dim Descriptor As String = String.Empty
                Dim Signature As String = String.Empty

                If IO.File.Exists(FilePath) = True Then

                    Dim Result As Engine.External.Core.ScanResult = Engine.External.Core.ScanResult.Timeout

                    Dim AssemblyModule As ModuleDefMD = ModuleDefMD.Load(FilePath)

                    If AssemblyModule.IsILOnly = False Then
                        Signature = "Win32:MSIL/Program"
                        Descriptor += "[Suspicius]  " & FilePath & "  ->  " & " Obfuscate MSIL " & Environment.NewLine
                        Result = Engine.External.Core.ScanResult.ThreatFound
                    End If

                    If Not Result = Engine.External.Core.ScanResult.ThreatFound Then

                        Dim TypesClass As IEnumerable(Of TypeDef) = AssemblyModule.GetTypes()
                        For Each Classes As TypeDef In TypesClass
                            Dim MethodList As IList(Of MethodDef) = Classes.Methods

                            For Each Method As MethodDef In MethodList

                                If Not String.Equals(Method.Name.ToString, ".ctor", StringComparison.OrdinalIgnoreCase) Then

                                    Try
                                        Dim RootNamespace = Classes.Name.ToString & "." & Method.Name.ToString

                                        If Method.IsPinvokeImpl = True Then

                                            Dim IsSuspicius As Boolean = IsHackEntry(Method.Name.ToString, Descriptor)

                                            If IsSuspicius = True Then
                                                Signature = "HackTool:MSIL/Hack"
                                                Descriptor += "[ Hack ]  " & RootNamespace & "  ->  " & " Trainer Memory " & Environment.NewLine
                                                Result = Engine.External.Core.ScanResult.ThreatFound
                                            End If

                                        Else

                                            Dim GetAllVariableNames As List(Of String) = Method.Body.Variables.Select(Function(x) x.Name).ToList
                                            Dim IsSuspicius As Boolean = IsInjectorEntry(GetAllVariableNames, Descriptor)

                                            If IsSuspicius = True Then
                                                Signature = "HackTool:MSIL/Injector"
                                                Descriptor += "[Injector Detection]  " & RootNamespace & "  ->  " & "Injector" & Environment.NewLine
                                                Result = Engine.External.Core.ScanResult.ThreatFound
                                            End If

                                        End If

                                    Catch ex As Exception

                                    End Try

                                End If

                            Next

                        Next

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

        Private Shared Function IsHackEntry(ByVal ValNamer As String, ByRef DetectionEx As String) As Boolean
            Dim IsSuspicius As Boolean = False

            Dim PinvokeTypeList As List(Of Object) = [Enum].GetValues(GetType(HackEntry)).Cast(Of Object)().ToList()
            Dim CounterCalcule As Integer = 0

            For Each Pinvoke As Object In PinvokeTypeList
                If ValNamer.Contains(Pinvoke.ToString, StringComparison.OrdinalIgnoreCase) Then
                    DetectionEx += "[IsSuspicius]  " & ValNamer & "  ->  " & Pinvoke & Environment.NewLine
                    CounterCalcule += 1
                End If
            Next

            Return (CounterCalcule >= (PinvokeTypeList.Count / 2))
        End Function

        Private Shared Function IsInjectorEntry(ByVal ValNamers As List(Of String), ByRef DetectionEx As String) As Boolean
            Dim IsSuspicius As Boolean = False

            Dim PinvokeTypeList As List(Of Object) = [Enum].GetValues(GetType(InjectorEntry)).Cast(Of Object)().ToList()
            Dim CounterCalcule As Integer = 0

            For Each ValNamer As Object In ValNamers
                For Each Pinvoke As Object In PinvokeTypeList
                    If ValNamer.ToString.Contains(Pinvoke.ToString, StringComparison.OrdinalIgnoreCase) Then
                        DetectionEx += "[IsSuspicius]  " & ValNamer & "  ->  " & Pinvoke & Environment.NewLine
                        CounterCalcule += 1
                    End If
                Next
            Next

            Return (CounterCalcule >= (PinvokeTypeList.Count / 2))
        End Function

    End Class

End Namespace

