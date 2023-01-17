
Imports XylonV2.StartupManager
Imports XylonV2.StartupManager.Services.Directories
Imports XylonV2.StartupManager.Services.Registries
Imports XylonV2.StartupManager.Services.Schedulers

Public Class SM_Tester

    Private Shared RegistryService As RegistryService = New RegistryService()
    Private Shared DirectoryService As DirectoryService = New DirectoryService()
    Private Shared TaskSchedulerService As TaskSchedulerService = New TaskSchedulerService()

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim startupPrograms As List(Of Models.StartupList) = New List(Of Models.StartupList)

        Dim startupStates = RegistryService.GetStartupProgramStates()
        Dim registryStartups = RegistryService.GetStartupPrograms(startupStates)

        If registryStartups IsNot Nothing Then
            startupPrograms.AddRange(registryStartups)
        End If

        Dim shellStartups = DirectoryService.GetStartupPrograms(startupStates)
        If shellStartups IsNot Nothing Then
            startupPrograms.AddRange(shellStartups)
        End If

        Dim taskSchedulerStartups = TaskSchedulerService.GetStartupPrograms(False)
        If taskSchedulerStartups IsNot Nothing Then
            startupPrograms.AddRange(taskSchedulerStartups)
        End If

        For Each ItemStartup As Models.StartupList In startupPrograms

            Dim ItemString As String = String.Empty
            ItemString += "/////////////////////////////////////////////////////////////////////////////////////" & vbNewLine
            ItemString += "Name: " & ItemStartup.Name & vbNewLine
            ItemString += "Path: " & ItemStartup.Path & vbNewLine
            ItemString += "RegistryName: " & ItemStartup.RegistryName & vbNewLine
            ItemString += "RegistryPath: " & ItemStartup.RegistryPath & vbNewLine
            ItemString += "RequireAdministrator: " & ItemStartup.RequireAdministrator & vbNewLine
            ItemString += "Type: " & ItemStartup.Type.ToString & vbNewLine
            ItemString += "/////////////////////////////////////////////////////////////////////////////////////" & vbNewLine & vbNewLine
            TextBox1.Text += ItemString

        Next

    End Sub

    Private Sub SM_Tester_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class