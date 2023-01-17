Imports Microsoft.Win32

Namespace Engine.Windows

    Public Enum CortanaState
        Unknown = -1
        Disabled = 0
        Enabled = 1
    End Enum

    Public Enum SystemType
        AllUsers = 0
        CurrentUser = 1
    End Enum

    Public Enum SystemState
        Unknown = -1
        Disabled = 0
        Enabled = 1
    End Enum

    Public Class Functions

#Region " Cortana "

        Private Const Cortana_KeyName0 As String = "SOFTWARE\Policies\Microsoft\Windows\Windows Search"
        Private Const Cortana_ValueName0 As String = "AllowCortana"

        Private Const Cortana_KeyName1 As String = "SOFTWARE\Microsoft\Personalization\Settings"
        Private Const Cortana_ValueName1 As String = "AcceptedPrivacyPolicy"

        Private Const Cortana_KeyName2 As String = "SOFTWARE\Microsoft\InputPersonalization"
        Private Const Cortana_ValueName2 As String = "RestrictImplicitTextCollection"
        Private Const Cortana_ValueName2_0 As String = "RestrictImplicitInkCollection"

        Private Const Cortana_KeyName3 As String = "SOFTWARE\Microsoft\InputPersonalization\TrainedDataStore"
        Private Const Cortana_ValueName3 As String = "HarvestContacts"

        Public Shared Function GetAllowCortana() As CortanaState
            Dim Result As CortanaState = CortanaState.Unknown

            Dim Cortana0 As Integer = CortanaState.Unknown
            Using key = Registry.LocalMachine.OpenSubKey(Cortana_KeyName0)
                Cortana0 = CInt((If(key?.GetValue(Cortana_ValueName0), -1)))
            End Using

            Dim Cortana1 As Integer = CortanaState.Unknown

            Using key = Registry.CurrentUser.OpenSubKey(Cortana_KeyName1)
                Cortana1 = CInt((If(key?.GetValue(Cortana_ValueName1), -1)))
            End Using

            Dim Cortana2 As Integer = CortanaState.Unknown
            Dim Cortana2_0 As Integer = CortanaState.Unknown

            Using key = Registry.CurrentUser.OpenSubKey(Cortana_KeyName2)
                Cortana2 = CInt((If(key?.GetValue(Cortana_ValueName2), -1)))
                Cortana2_0 = CInt((If(key?.GetValue(Cortana_ValueName2_0), -1)))
            End Using

            Dim Cortana3 As Integer = CortanaState.Unknown

            Using key = Registry.CurrentUser.OpenSubKey(Cortana_KeyName3)
                Cortana3 = CInt((If(key?.GetValue(Cortana_ValueName3), -1)))
            End Using

            If Cortana0 = CortanaState.Enabled Or Cortana1 = CortanaState.Enabled And Cortana3 = CortanaState.Enabled Then

                If Cortana2 = CortanaState.Enabled And Cortana2_0 = CortanaState.Enabled Then

                    Result = CortanaState.Unknown

                Else

                    Result = CortanaState.Enabled

                End If

            Else

                Result = CortanaState.Disabled

            End If

            Return Result

        End Function

        Public Shared Sub SetAllowCortana(ByVal valueData As CortanaState, Optional ByVal ResetExplorer As Boolean = False)

            Using key = Registry.LocalMachine.CreateSubKey(Cortana_KeyName0, True)
                key.SetValue(Cortana_ValueName0, CInt(valueData))
            End Using

            Using key = Registry.CurrentUser.CreateSubKey(Cortana_KeyName1, True)
                key.SetValue(Cortana_ValueName1, CInt(valueData))
            End Using

            Using key = Registry.CurrentUser.CreateSubKey(Cortana_KeyName2, True)
                Dim WriteInt As Integer = CInt(valueData)
                If WriteInt = 1 Then
                    WriteInt = 0
                Else
                    WriteInt = 1
                End If
                key.SetValue(Cortana_ValueName2, CInt(WriteInt))
                key.SetValue(Cortana_ValueName2_0, CInt(WriteInt))
            End Using

            Using key = Registry.CurrentUser.CreateSubKey(Cortana_KeyName3, True)
                key.SetValue(Cortana_ValueName3, CInt(valueData))
            End Using

            If ResetExplorer = True Then
                Process.GetProcessesByName("explorer").FirstOrDefault.Kill()
                Process.Start("explorer")
            End If

        End Sub

#End Region

#Region " TaskManager "

        Private Const TaskMgr_KeyName As String = "Software\Microsoft\Windows\CurrentVersion\Policies\System"
        Private Const TaskMgr_ValueName As String = "DisableTaskMgr"


        Public Shared Function GetAllowTaskMgr(ByVal WindowsType As SystemType) As SystemState
            Dim Result As SystemState = SystemState.Unknown
            Dim TaskState As Integer = SystemState.Unknown

            If WindowsType = SystemType.AllUsers Then
                Using key = Registry.LocalMachine.OpenSubKey(TaskMgr_KeyName)
                    TaskState = CInt((If(key?.GetValue(TaskMgr_ValueName), -1)))
                End Using
            Else
                Using key = Registry.CurrentUser.OpenSubKey(TaskMgr_KeyName)
                    TaskState = CInt((If(key?.GetValue(TaskMgr_ValueName), -1)))
                End Using
            End If

            If TaskState = 0 Then
                TaskState = 1
            Else
                TaskState = 0
            End If


            Result = TaskState

            Return Result

        End Function

        Public Shared Sub SetAllowTaskMgr(ByVal WindowsType As SystemType, ByVal valueData As SystemState)

            If valueData = SystemState.Enabled Then
                valueData = SystemState.Disabled
            Else
                valueData = SystemState.Enabled
            End If

            If WindowsType = SystemType.AllUsers Then
                Using key = Registry.LocalMachine.CreateSubKey(TaskMgr_KeyName, True)
                    key.SetValue(TaskMgr_ValueName, CInt(valueData))
                End Using
            Else
                Using key = Registry.CurrentUser.CreateSubKey(TaskMgr_KeyName, True)
                    key.SetValue(TaskMgr_ValueName, CInt(valueData))
                End Using
            End If

        End Sub

#End Region

#Region " RegistryTools "

        Private Const RegistryTools_KeyName As String = "Software\Microsoft\Windows\CurrentVersion\Policies\System"
        Private Const RegistryTools_ValueName As String = "DisableRegistryTools"


        Public Shared Function GetAllowRegistryTools(ByVal WindowsType As SystemType) As SystemState
            Dim Result As SystemState = SystemState.Unknown

            Dim TaskState As Integer = SystemState.Unknown

            If WindowsType = SystemType.AllUsers Then
                Using key = Registry.LocalMachine.OpenSubKey(RegistryTools_KeyName)
                    TaskState = CInt((If(key?.GetValue(RegistryTools_ValueName), -1)))
                End Using
            Else
                Using key = Registry.CurrentUser.OpenSubKey(RegistryTools_KeyName)
                    TaskState = CInt((If(key?.GetValue(RegistryTools_ValueName), -1)))
                End Using
            End If

            If TaskState = 0 Then
                TaskState = 1
            Else
                TaskState = 0
            End If

            Result = TaskState

            Return Result

        End Function

        Public Shared Sub SetAllowRegistryTools(ByVal WindowsType As SystemType, ByVal valueData As SystemState)

            If valueData = SystemState.Enabled Then
                valueData = SystemState.Disabled
            Else
                valueData = SystemState.Enabled
            End If

            If WindowsType = SystemType.AllUsers Then
                Using key = Registry.LocalMachine.CreateSubKey(RegistryTools_KeyName, True)
                    key.SetValue(RegistryTools_ValueName, CInt(valueData))
                End Using
            Else
                Using key = Registry.CurrentUser.CreateSubKey(RegistryTools_KeyName, True)
                    key.SetValue(RegistryTools_ValueName, CInt(valueData))
                End Using
            End If

        End Sub

#End Region

#Region " NoFolderOptions "

        Private Const NoFolderOptions_KeyName As String = "Software\Microsoft\Windows\CurrentVersion\Policies\System"
        Private Const NoFolderOptions_ValueName As String = "NoFolderOptions"


        Public Shared Function GetAllowNoFolderOptions(ByVal WindowsType As SystemType) As SystemState
            Dim Result As SystemState = SystemState.Unknown

            Dim TaskState As Integer = SystemState.Unknown

            If WindowsType = SystemType.AllUsers Then
                Using key = Registry.LocalMachine.OpenSubKey(NoFolderOptions_KeyName)
                    TaskState = CInt((If(key?.GetValue(NoFolderOptions_ValueName), -1)))
                End Using
            Else
                Using key = Registry.CurrentUser.OpenSubKey(NoFolderOptions_KeyName)
                    TaskState = CInt((If(key?.GetValue(NoFolderOptions_ValueName), -1)))
                End Using
            End If

            If TaskState = 0 Then
                TaskState = 1
            Else
                TaskState = 0
            End If

            Result = TaskState

            Return Result

        End Function

        Public Shared Sub SetAllowNoFolderOptions(ByVal WindowsType As SystemType, ByVal valueData As SystemState)

            If valueData = SystemState.Enabled Then
                valueData = SystemState.Disabled
            Else
                valueData = SystemState.Enabled
            End If

            If WindowsType = SystemType.AllUsers Then
                Using key = Registry.LocalMachine.CreateSubKey(NoFolderOptions_KeyName, True)
                    key.SetValue(NoFolderOptions_ValueName, CInt(valueData))
                End Using
            Else
                Using key = Registry.CurrentUser.CreateSubKey(NoFolderOptions_KeyName, True)
                    key.SetValue(NoFolderOptions_ValueName, CInt(valueData))
                End Using
            End If

        End Sub

#End Region

#Region " DisableCMD "

        Private Const DisableCMD_KeyName As String = "Software\Microsoft\Windows\CurrentVersion\Policies\System"
        Private Const DisableCMD_ValueName As String = "DisableCMD"


        Public Shared Function GetAllowDisableCMD(ByVal WindowsType As SystemType) As SystemState
            Dim Result As SystemState = SystemState.Unknown

            Dim TaskState As Integer = SystemState.Unknown

            If WindowsType = SystemType.AllUsers Then
                Using key = Registry.LocalMachine.OpenSubKey(DisableCMD_KeyName)
                    TaskState = CInt((If(key?.GetValue(DisableCMD_ValueName), -1)))
                End Using
            Else
                Using key = Registry.CurrentUser.OpenSubKey(DisableCMD_KeyName)
                    TaskState = CInt((If(key?.GetValue(DisableCMD_ValueName), -1)))
                End Using
            End If

            If TaskState = 0 Then
                TaskState = 1
            Else
                TaskState = 0
            End If

            Result = TaskState

            Return Result

        End Function

        Public Shared Sub SetAllowDisableCMD(ByVal WindowsType As SystemType, ByVal valueData As SystemState)

            If valueData = SystemState.Enabled Then
                valueData = SystemState.Disabled
            Else
                valueData = SystemState.Enabled
            End If

            If WindowsType = SystemType.AllUsers Then
                Using key = Registry.LocalMachine.CreateSubKey(DisableCMD_KeyName, True)
                    key.SetValue(DisableCMD_ValueName, CInt(valueData))
                End Using
            Else
                Using key = Registry.CurrentUser.CreateSubKey(DisableCMD_KeyName, True)
                    key.SetValue(DisableCMD_ValueName, CInt(valueData))
                End Using
            End If

        End Sub

#End Region

#Region " Windows Script Host "

        Private Const WSH_KeyName As String = "Software\Microsoft\Windows Script Host\Settings"
        Private Const WSH_ValueName As String = "Enabled"


        Public Shared Function GetAllowWSH(ByVal WindowsType As SystemType) As SystemState
            Dim Result As SystemState = SystemState.Unknown

            Dim TaskState As Integer = SystemState.Unknown

            If WindowsType = SystemType.AllUsers Then
                Using key = Registry.LocalMachine.OpenSubKey(WSH_KeyName)
                    TaskState = CInt((If(key?.GetValue(WSH_ValueName), -1)))
                End Using
            Else
                Using key = Registry.CurrentUser.OpenSubKey(WSH_KeyName)
                    TaskState = CInt((If(key?.GetValue(WSH_ValueName), -1)))
                End Using
            End If

            If TaskState = 0 Then
                TaskState = 1
            Else
                TaskState = 0
            End If

            Result = TaskState

            Return Result

        End Function

        Public Shared Sub SetAllowWSH(ByVal WindowsType As SystemType, ByVal valueData As SystemState)

            If valueData = SystemState.Enabled Then
                valueData = SystemState.Disabled
            Else
                valueData = SystemState.Enabled
            End If

            If WindowsType = SystemType.AllUsers Then
                Using key = Registry.LocalMachine.CreateSubKey(WSH_KeyName, True)
                    key.SetValue(WSH_ValueName, CInt(valueData))
                End Using
            Else
                Using key = Registry.CurrentUser.CreateSubKey(WSH_KeyName, True)
                    key.SetValue(WSH_ValueName, CInt(valueData))
                End Using
            End If

        End Sub

#End Region

    End Class
End Namespace

