Imports System
Imports System.Collections.Generic
Imports System.Diagnostics.CodeAnalysis
Imports System.Linq
Imports Microsoft.Win32
Imports XylonV2.StartupManager.Models

#Disable Warning BC30668

Namespace StartupManager.Services.Registries
    Public Class RegistryService
        '  Inherits IRegistryService

        Private Shared StartupRegistryPaths As String() = {"Software\Microsoft\Windows\CurrentVersion\Run", "Software\Microsoft\Windows\CurrentVersion\RunOnce", "Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\Run", "SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Run", "SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\RunOnce"}

        Private Shared ReadOnly Property StartupRegistryPath As String
            Get
                Return "Software\Microsoft\Windows\CurrentVersion\Run"
            End Get
        End Property

        Private Const DisabledStartupRegistryItems As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\StartupApproved\Run"
        Private Const DisabledStartupFolderItems As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\StartupApproved\StartupFolder"

        Private Shared ReadOnly Property EnabledBytes As Byte()
            Get
                Return New Byte() {&H2, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0}
            End Get
        End Property

        Public Sub AddProgramToStartup(ByVal program As StartupProgram)
            Using key = GetWriteRegistryKey(StartupRegistryPath, program.AllUsers)
                key.SetValue(program.Name, "\" & program.File.FullName & "\" & program.Arguments) '   key.SetValue(program.Name, $"\"{program.File.FullName}\" {program.Arguments}")
            End Using
        End Sub

        Public Sub RemoveProgramFromStartup(ByVal program As StartupList)
            Using key = GetWriteRegistryKey(program.RegistryPath, program.AllUsers)
                key.DeleteValue(program.RegistryName)
            End Using
        End Sub

        Public Function ToggleStartupState(ByVal program As StartupList, ByVal enable As Boolean) As StateChange
            Try

                Using reg = GetWriteRegistryKey(program.DisabledRegistryPath, program.AllUsers)
                    Dim bytes As Byte()

                    If enable Then
                        bytes = EnabledBytes
                    Else
                        bytes = MakeDisabledBytes()
                    End If

                    Dim currentValue = CType(reg.GetValue(program.RegistryName), Byte())

                    If currentValue Is Nothing Then
                        reg.SetValue(program.RegistryName, bytes)
                        Return StateChange.Success
                    End If

                    Dim isAlreadyTheRequestState As Boolean = False ' New ReadOnlySpan(Of Byte)(bytes.Take(4).ToArray()).SequenceEqual(currentValue.Take(4).ToArray())

                    If isAlreadyTheRequestState Then
                        Return StateChange.SameState
                    Else
                        reg.SetValue(program.RegistryName, bytes)
                        Return StateChange.Success
                    End If
                End Using

            Catch __unusedUnauthorizedAccessException1__ As UnauthorizedAccessException
                Return StateChange.Unauthorized
            End Try
        End Function

        Public Function GetStartupPrograms(ByVal programStates As IEnumerable(Of StartupState)) As IEnumerable(Of StartupList)
            Dim startupPrograms = New List(Of StartupList)()
            Dim startupStates = programStates

            For Each path In StartupRegistryPaths
                Dim currentUser = GetStartups(path, allUsers:=False, startupStates:=startupStates)

                If currentUser IsNot Nothing Then
                    startupPrograms.AddRange(currentUser)
                End If

                Dim allUsers = GetStartups(path, allUsers:=True, startupStates:=startupStates)

                If allUsers IsNot Nothing Then
                    startupPrograms.AddRange(allUsers)
                End If
            Next

            Return startupPrograms
        End Function

        Public Function GetStartupPrograms() As IEnumerable(Of StartupList)
            Dim startupStates = GetStartupProgramStates()
            Return GetStartupPrograms(startupStates)
        End Function

        Public Function GetStartupByName(ByVal name As String, ByVal programStates As IEnumerable(Of StartupState)) As StartupList
            Dim namePredicate As Func(Of String, Boolean) = Function(x) x.Equals(name, StringComparison.OrdinalIgnoreCase)
            Dim disabledPredicate As Func(Of StartupState, Boolean) = Function(x) x.Name.Equals(name, StringComparison.OrdinalIgnoreCase) AndAlso x.Disabled
            Return GetStartupByPredicate(namePredicate, disabledPredicate, programStates)
        End Function

        Public Function GetStartupByName(ByVal name As String) As StartupList
            Dim startupStates = GetStartupProgramStates()
            Return GetStartupByName(name, startupStates)
        End Function

        Public Function GetStartupByPredicate(ByVal predicate As Func(Of String, Boolean), ByVal disabledPredicate As Func(Of StartupState, Boolean), ByVal programStates As IEnumerable(Of StartupState)) As StartupList
            Dim program = FindStartupList(predicate, disabledPredicate, False, programStates)

            If program Is Nothing Then
                program = FindStartupList(predicate, disabledPredicate, True, programStates)
            End If

            Return program
        End Function

        Public Function GetStartupByPredicate(ByVal predicate As Func(Of String, Boolean), ByVal disabledPredicate As Func(Of StartupState, Boolean)) As StartupList
            Dim startupStates = GetStartupProgramStates()
            Return GetStartupByPredicate(predicate, disabledPredicate, startupStates)
        End Function

        Private Function FindStartupList(ByVal predicate As Func(Of String, Boolean), ByVal disabledPredicate As Func(Of StartupState, Boolean), ByVal allUsers As Boolean, ByVal startupStates As IEnumerable(Of StartupState)) As StartupList
            Dim startupRegistryKeys = GetReadRegistryKeys(allUsers, StartupRegistryPaths)

            For Each registry In startupRegistryKeys

                Using registry
                    If registry Is Nothing Then Continue For
                    Dim startupValues = registry.GetValueNames()
                    Dim name = startupValues.FirstOrDefault(predicate)

                    If name IsNot Nothing Then
                        Dim path = registry.GetValue(name).ToString()
                        Dim disabled = startupStates.Any(disabledPredicate)
                        Return New StartupList(name, path, allUsers, disabled, StartupList.StartupType.Regedit, allUsers, StartupRegistryPaths.First(Function(x) registry.Name.Contains(x)), DisabledStartupRegistryItems, name)
                    End If
                End Using
            Next

            Return Nothing
        End Function

        Public Function GetStartupProgramStates() As IEnumerable(Of StartupState)
            Dim startupStates = New List(Of StartupState)()

            Using currentUserDisabledReg = GetReadRegistryKey(DisabledStartupRegistryItems, allUsers:=False)

                Using allUserDisabledReg = GetReadRegistryKey(DisabledStartupRegistryItems, allUsers:=True)

                    Using currentUserShellDisabledReg = GetReadRegistryKey(DisabledStartupFolderItems, allUsers:=False)

                        Using allUserShellDisabledReg = GetReadRegistryKey(DisabledStartupFolderItems, allUsers:=True)
                            Dim currentUsers = currentUserDisabledReg.GetValueNames().[Select](Function(x) GetStartupState(currentUserDisabledReg, x))
                            Dim allUsers = Nothing

                            Try
                                allUsers = allUserDisabledReg.GetValueNames().[Select](Function(x) GetStartupState(allUserDisabledReg, x))
                            Catch ex As Exception

                            End Try

                            Dim currentUsersShell = currentUserShellDisabledReg.GetValueNames().[Select](Function(x) GetStartupState(currentUserShellDisabledReg, x))
                            Dim allUsersShell = Nothing

                            Try
                                allUsersShell = allUserShellDisabledReg.GetValueNames().[Select](Function(x) GetStartupState(allUserShellDisabledReg, x))
                            Catch ex As Exception

                            End Try


                            If currentUsers IsNot Nothing Then
                                startupStates.AddRange(currentUsers)
                            End If

                            If currentUsersShell IsNot Nothing Then
                                startupStates.AddRange(currentUsersShell)
                            End If

                            If allUsers IsNot Nothing Then
                                startupStates.AddRange(allUsers)
                            End If

                            If allUsersShell IsNot Nothing Then
                                startupStates.AddRange(allUsersShell)
                            End If

                        End Using
                    End Using
                End Using
            End Using

            Return startupStates
        End Function

        Private Function GetStartups(ByVal registryPath As String, ByVal allUsers As Boolean, ByVal startupStates As IEnumerable(Of StartupState)) As IEnumerable(Of StartupList)
            Dim programs = New List(Of StartupList)()
            Dim startupRegistryKeys = GetReadRegistryKeys(allUsers, registryPath)

            For Each registry In startupRegistryKeys

                Using registry
                    If registry Is Nothing Then Continue For
                    Dim startupValues = registry.GetValueNames()
                    Dim startupPrograms = startupValues.[Select](Function(name)
                                                                     Dim path = registry.GetValue(name).ToString()
                                                                     Dim disabled = False
                                                                     Try
                                                                         disabled = startupStates.Any(Function(x) x.Name.Equals(name, StringComparison.OrdinalIgnoreCase) AndAlso x.Disabled)
                                                                     Catch ex As Exception

                                                                     End Try
                                                                     Return New StartupList(name, path, allUsers, disabled, StartupList.StartupType.Regedit, allUsers, StartupRegistryPaths.First(Function(x) registry.Name.Contains(x)), DisabledStartupRegistryItems, name)
                                                                 End Function).Where(Function(x) Not String.IsNullOrWhiteSpace(x.Path)).ToList()
                    programs.AddRange(startupPrograms)
                End Using
            Next

            Return programs
        End Function

        Private Shared Function GetWriteRegistryKey(ByVal registryPath As String, ByVal allUsers As Boolean) As RegistryKey
            If allUsers Then
                Return Registry.LocalMachine.CreateSubKey(registryPath)
            Else
                Return Registry.CurrentUser.CreateSubKey(registryPath)
            End If
        End Function

        Private Shared Function GetReadRegistryKey(ByVal registryPath As String, ByVal allUsers As Boolean) As RegistryKey
            If allUsers Then
                Return Registry.LocalMachine.OpenSubKey(registryPath)
            Else
                Return Registry.CurrentUser.OpenSubKey(registryPath)
            End If
        End Function

        Private Shared Sub DeleteRegistryKey(ByVal program As StartupList)
            Using key = GetWriteRegistryKey(program.RegistryPath, program.AllUsers)
                key.DeleteValue(program.RegistryName)
            End Using
        End Sub

        Private Shared Function GetReadRegistryKeys(ByVal allUsers As Boolean, ParamArray registryKeys As String()) As IEnumerable(Of RegistryKey)
            If allUsers Then
                Return registryKeys.[Select](Function(x) Registry.LocalMachine.OpenSubKey(x))
            Else
                Return registryKeys.[Select](Function(x) Registry.CurrentUser.OpenSubKey(x))
            End If
        End Function

        Private Function GetStartupState(ByVal disabledReg As RegistryKey, ByVal name As String) As StartupState
            Dim bytes = TryCast(disabledReg.GetValue(name), Byte())
            Dim disabled = CheckIfDisabled(bytes)
            Return New StartupState(name, disabled)
        End Function

        Private Shared Function CheckIfDisabled(ByVal bytes As Byte()) As Boolean
            Dim disabled = False

            If bytes IsNot Nothing Then
                disabled = bytes.Skip(4).Any(Function(x) x <> &H0)
            End If

            Return disabled
        End Function

        Private Shared Function MakeDisabledBytes() As Byte()
            Dim startBytes = New Byte() {&H3, &H0, &H0, &H0}
            Dim now = DateTime.Now.Ticks
            Dim timeBytes = BitConverter.GetBytes(now)
            Dim bytes = startBytes.Concat(timeBytes).ToArray()
            Return bytes
        End Function
    End Class
End Namespace
