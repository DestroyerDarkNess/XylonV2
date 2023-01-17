Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports XylonV2.StartupManager.Models
Imports XylonV2.StartupManager.Services.Registries

Namespace StartupManager.Services.Directories
    Public Class DirectoryService
        'Inherits IDirectoryService

        Private Const DisabledStartupFolderItems As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\StartupApproved\StartupFolder"
        Private Shared ExecuteableSearchPatterns As String() = {"*.exe", "*.lnk", "*.ps1", "*.cmd", "*.bat", "*.vbs", "*.wsf", "*.hta", "*.js"}
        Private Shared RegistryService As RegistryService = New RegistryService()
        Private Shared CurrentUserStartup As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup)
        Private Shared AllUsersStartup As String = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup)

        Public Function GetStartupByPredicate(ByVal filePredicate As Func(Of String, Boolean), ByVal disabledPredicate As Func(Of StartupState, Boolean), ByVal startupStates As IEnumerable(Of StartupState)) As StartupList
            Dim files = GetFiles(CurrentUserStartup, ExecuteableSearchPatterns)
            Dim path = files.FirstOrDefault(filePredicate)

            If path Is Nothing Then
                files = GetFiles(AllUsersStartup, ExecuteableSearchPatterns)
                path = files.FirstOrDefault(filePredicate)

                If path Is Nothing Then
                    Return Nothing
                End If

                Dim fileName = System.IO.Path.GetFileName(path)
                Dim parsedName = System.IO.Path.GetFileNameWithoutExtension(path)
                Dim disabled = startupStates.Any(disabledPredicate)
                Return New StartupList(parsedName, path, True, disabled, StartupList.StartupType.Shortcut, True, String.Empty, DisabledStartupFolderItems, fileName)
            Else
                Dim parsedName = System.IO.Path.GetFileNameWithoutExtension(path)
                Dim fileName = System.IO.Path.GetFileName(path)
                Dim disabledEx = startupStates.Any(disabledPredicate)
                Return New StartupList(parsedName, path, False, disabledEx, StartupList.StartupType.Shortcut, False, String.Empty, DisabledStartupFolderItems, fileName)
            End If
        End Function

        Public Function GetStartupByPredicate(ByVal predicate As Func(Of String, Boolean), ByVal disabledPredicate As Func(Of StartupState, Boolean)) As StartupList
            Dim startupStates = RegistryService.GetStartupProgramStates()
            Return GetStartupByPredicate(predicate, disabledPredicate, startupStates)
        End Function

        Public Function GetStartupByName(ByVal name As String, ByVal startupStates As IEnumerable(Of StartupState)) As StartupList
            Dim namePredicate As Func(Of String, Boolean) = Function(x) Path.GetFileNameWithoutExtension(x).Equals(name, StringComparison.OrdinalIgnoreCase)
            Dim disabledPredicate As Func(Of StartupState, Boolean) = Function(x) x.Name.Equals(name, StringComparison.OrdinalIgnoreCase) AndAlso x.Disabled
            Return GetStartupByPredicate(namePredicate, disabledPredicate, startupStates)
        End Function

        Public Function GetStartupByName(ByVal name As String) As StartupList
            Dim startupStates = RegistryService.GetStartupProgramStates()
            Return GetStartupByName(name, startupStates)
        End Function

        Public Function GetStartupPrograms() As IEnumerable(Of StartupList)
            Dim startupStates = RegistryService.GetStartupProgramStates()
            Return GetStartupPrograms(startupStates)
        End Function

        Public Function GetStartupPrograms(ByVal startupStates As IEnumerable(Of StartupState)) As IEnumerable(Of StartupList)
            Dim programs = New List(Of StartupList)()
            Dim currentUserStartups = GetShellStartup(allUsers:=False, path:=CurrentUserStartup, startupStates:=startupStates)
            programs.AddRange(currentUserStartups)
            Dim allUserStartups = GetShellStartup(allUsers:=True, path:=AllUsersStartup, startupStates:=startupStates)
            programs.AddRange(allUserStartups)
            Return programs
        End Function


        Public Shared Function GetShellStartup(ByVal allUsers As Boolean, ByVal path As String, ByVal startupStates As IEnumerable(Of StartupState)) As IEnumerable(Of StartupList)


            Dim currentStartups As IEnumerable(Of StartupList) = GetFiles(path, {"*"}).[Select](Function(name)
                                                                                                    Dim fileNameExaaa As String = System.IO.Path.GetFileName(name)
                                                                                                    Dim StItem As StartupList = New StartupList(System.IO.Path.GetFileNameWithoutExtension(name), name, allUsers, False, StartupList.StartupType.Shortcut, allUsers, DisabledStartupFolderItems, String.Empty, fileNameExaaa)
                                                                                                    Return StItem
                                                                                                End Function)

            Return currentStartups.ToList()
        End Function

        Public Shared Function GetShellStartupMalicius(ByVal allUsers As Boolean, ByVal path As String, ByVal startupStates As IEnumerable(Of StartupState)) As IEnumerable(Of StartupList)


            Dim currentStartups As IEnumerable(Of StartupList) = GetFiles(path, ExecuteableSearchPatterns).[Select](Function(name)
                                                                                                                        Dim fileNameExaaa As String = System.IO.Path.GetFileName(name)
                                                                                                                        Dim disabledEx As Boolean = startupStates.Any(Function(x)
                                                                                                                                                                          If x.Name Is Nothing Then Return False
                                                                                                                                                                          Return x.Name.Equals(fileNameExaaa, StringComparison.Ordinal) AndAlso x.Disabled
                                                                                                                                                                      End Function)
                                                                                                                        Return New StartupList(System.IO.Path.GetFileNameWithoutExtension(name), name, allUsers, disabledEx, StartupList.StartupType.Shortcut, allUsers, DisabledStartupFolderItems, String.Empty, fileNameExaaa)
                                                                                                                    End Function)
            Return currentStartups.ToList()
        End Function

        Public Shared Function GetFiles(ByVal path As String, ByVal searchPatterns As String(), ByVal Optional searchOption As SearchOption = SearchOption.TopDirectoryOnly) As IEnumerable(Of String)
            If String.IsNullOrWhiteSpace(path) Then Return New String(-1) {}

            Dim FilesEx As IEnumerable(Of FileInfo) = FileDirSearcher.GetFiles(dirPath:=path,
            searchOption:=searchOption,
            fileNamePatterns:={"*"},
            fileExtPatterns:=searchPatterns.ToList,
            ignoreCase:=True,
            throwOnError:=True)

            Return FilesEx.[Select](Function(File)
                                        Return File.FullName
                                    End Function)

            ' Return searchPatterns.SelectMany(Function(searchPattern) Directory.EnumerateFiles(path, searchPattern, searchOption))
        End Function

        Public Sub RemoveProgramFromStartup(ByVal program As StartupList)
            File.Delete(program.Path)
        End Sub
    End Class
End Namespace
