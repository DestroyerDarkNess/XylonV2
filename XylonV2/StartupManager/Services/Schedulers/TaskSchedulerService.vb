Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports Microsoft.Win32.TaskScheduler
Imports XylonV2.StartupManager.Models
Imports XylonV2.StartupManager.Services.Identity

Namespace StartupManager.Services.Schedulers
    Public Class TaskSchedulerService
        ' Inherits ITaskSchedulerService

        Private Shared WindowsIdentityService As WindowsIdentityService = New WindowsIdentityService()
        Private Const TaskSchedulerFolder As String = "StartupManager"

        Public Function GetStartupByPredicate(ByVal predicate As Func(Of Task, Boolean)) As StartupList
            Dim startupList = GetStartupList(predicate, GetFolderPredicate(False))

            If startupList Is Nothing Then
                Return Nothing
            End If

            Return startupList
        End Function

        Public Function GetStartupByName(ByVal name As String) As StartupList
            Dim namePredicate As Func(Of Task, Boolean) = Function(x) x.Name.Equals(name, StringComparison.OrdinalIgnoreCase) AndAlso x.Definition.Triggers.Any(Function(Y) Y.TriggerType = TaskTriggerType.Logon)
            Return GetStartupByPredicate(namePredicate)
        End Function

        Public Function GetStartupPrograms(ByVal includeWindows As Boolean) As IEnumerable(Of StartupList)
            Return GetAllTasks(includeWindows).[Select](Function(x) Convert(x)).ToList()
        End Function

        Public Sub RemoveProgramFromStartup(ByVal name As String)
            Using taskService = New TaskService()
                Dim task = taskService.FindTask(name)
                taskService.RootFolder.DeleteTask(task.Path)
            End Using
        End Sub

        Public Function ToggleStartupState(ByVal program As StartupList, ByVal enable As Boolean) As StateChange
            Try

                Using taskService = New TaskService()
                    Dim namePredicate As Func(Of Task, Boolean) = Function(x) x.Name.Equals(program.Name, StringComparison.OrdinalIgnoreCase) AndAlso x.Definition.Triggers.Any(Function(y) y.TriggerType = TaskTriggerType.Logon)
                    Dim task = GetTaskFromFolder(taskService.Instance.RootFolder, namePredicate, GetFolderPredicate(False))

                    Dim isAlreadyTheRequestState As Boolean = (task.Enabled = enable)

                    If isAlreadyTheRequestState Then
                        Return StateChange.SameState
                    Else
                        task.Enabled = enable
                        Return StateChange.Success
                    End If
                End Using

            Catch __unusedUnauthorizedAccessException1__ As UnauthorizedAccessException
                Return StateChange.Unauthorized
            End Try
        End Function

        Public Function AddProgramToStartup(ByVal program As StartupProgram) As Task
            Using taskService = New TaskService()
                Dim currentUser = WindowsIdentityService.CurrentUser()
                Dim taskDef = taskService.NewTask()
                taskDef.RegistrationInfo.Author = $"StartupManager"
                taskDef.RegistrationInfo.Description = $"Runs {program.Name} ({program.File.FullName}) at logon of user {currentUser}"
                taskDef.Principal.RunLevel = TaskRunLevel.Highest
                taskDef.Settings.ExecutionTimeLimit = TimeSpan.Zero
                taskDef.Settings.StartWhenAvailable = True
                taskDef.Settings.StopIfGoingOnBatteries = False
                Dim action = taskDef.Actions.Add(program.File.FullName, program.Arguments, program.File.DirectoryName)
                Dim logonTrigger = CType(taskDef.Triggers.AddNew(TaskTriggerType.Logon), LogonTrigger)
                logonTrigger.UserId = currentUser
                Return taskService.RootFolder.RegisterTaskDefinition($"{TaskSchedulerFolder}\\{program.Name}", taskDef)
            End Using
        End Function

        Private Function GetStartupList(ByVal taskPredicate As Func(Of Task, Boolean), ByVal folderPredicate As Func(Of TaskFolder, Boolean)) As StartupList
            Dim taskex = GetTaskFromFolder(TaskService.Instance.RootFolder, taskPredicate, folderPredicate)

            If taskex IsNot Nothing Then
                Return Convert(taskex)
            End If

            Return Nothing
        End Function

        Private Function GetTaskFromFolder(ByVal folder As TaskFolder, ByVal taskPredicate As Func(Of Task, Boolean), ByVal folderPredicate As Func(Of TaskFolder, Boolean)) As Task
            Dim task As Task = folder.Tasks.FirstOrDefault(taskPredicate)

            If task Is Nothing Then

                For Each subFolder In folder.SubFolders.Where(folderPredicate)
                    task = GetTaskFromFolder(subFolder, taskPredicate, folderPredicate)

                    If task IsNot Nothing Then
                        Return task
                    End If
                Next
            End If

            Return task
        End Function

        Private Shared Function GetAllTasks(ByVal includeWindows As Boolean) As IEnumerable(Of Task)
            Dim predicate = GetFolderPredicate(includeWindows)
            Return GetFolderTasks(TaskService.Instance.RootFolder, predicate)
        End Function

        Private Shared Function GetFolderTasks(ByVal folder As TaskFolder, ByVal predicate As Func(Of TaskFolder, Boolean)) As IEnumerable(Of Task)
            Dim tasks = New List(Of Task)()
            tasks.AddRange(folder.Tasks.Where(Function(x) x.Definition.Triggers.Any(Function(y) y.TriggerType = TaskTriggerType.Logon)))

            For Each subFolder As TaskFolder In folder.SubFolders.Where(predicate)
                tasks.AddRange(GetFolderTasks(subFolder, predicate))
            Next

            Return tasks
        End Function

        Private Shared Function GetFolderPredicate(ByVal includeWindows As Boolean) As Func(Of TaskFolder, Boolean)
            If includeWindows Then
                Return Function(x) True
            Else
                Return Function(x) Not x.Name.Contains("Microsoft", StringComparison.OrdinalIgnoreCase)
            End If
        End Function

        Private Shared Function Convert(ByVal task As Task) As StartupList
            Dim PathTask As String = String.Join(" | ", task.Definition.Actions.[Select](Function(a) GetPathFromAction(a))) ' task.Definition.RegistrationInfo.Author ' 
            Return New StartupList(task.Name, PathTask, True, Not task.Enabled, StartupList.StartupType.TaskScheduler, task.Definition.Triggers.Where(Function(t) t.TriggerType = TaskTriggerType.Logon).All(Function(x) (CType(x, LogonTrigger)).UserId IsNot Nothing), task)
        End Function

        Public Shared Function GetStartupTaskScheduler(ByVal includeWindows As Boolean) As List(Of StartupList)
            Dim tasks = GetAllTasks(includeWindows)
            Return tasks.[Select](Function(x) Convert(x)).ToList()
        End Function

        Private Shared Function GetPathFromAction(ByVal action As Microsoft.Win32.TaskScheduler.Action) As String

            Select Case action.ActionType
                Case TaskActionType.Execute
                    Dim Act As ExecAction = CType(action, ExecAction)
                    Return """" & Act.Path & """" & " " & Act.Arguments
                Case TaskActionType.SendEmail
                    Dim Act As EmailAction = CType(action, EmailAction)
                    Return "Email To: " & Act.[To] & " From: " & Act.From & " Subject: " & Act.Subject
                Case TaskActionType.ComHandler
                    Dim Act As ComHandlerAction = CType(action, ComHandlerAction)
                    Return """" & action.ActionType.ToString & " - " & Act.ToString & """"
                Case TaskActionType.ShowMessage
                    Dim Act As ShowMessageAction = CType(action, ShowMessageAction)
                    Return """" & action.ActionType.ToString & " - " & Act.ToString & """"
                Case Else
                    Return "Unknown action type: '" & action.ActionType.ToString & "'"
            End Select

        End Function

    End Class
End Namespace
