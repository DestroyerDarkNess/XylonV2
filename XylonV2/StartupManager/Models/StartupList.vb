Imports System.Diagnostics.CodeAnalysis

Namespace StartupManager.Models
    Public Class StartupList
        Private _name As String = String.Empty

        Public Property Name As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = ParseName(value)
            End Set
        End Property

        Public Property Path As String
        Public Property RequireAdministrator As Boolean
        Public Property Disabled As Boolean
        Public Property AllUsers As Boolean
        Public Property RegistryPath As String
        Public Property DisabledRegistryPath As String
        Public Property RegistryName As String
        Public Property Type As StartupType
        Public Property Task As Microsoft.Win32.TaskScheduler.Task

        Public Sub New(ByVal nameEX As String, ByVal pathEX As String, ByVal requireAdministratorEX As Boolean, ByVal disabledEX As Boolean, ByVal typeEX As StartupType, ByVal allUsersEX As Boolean, ByVal registryPathEX As String, ByVal disabledRegistryPathEX As String, ByVal registryNameEX As String)
            Path = If(pathEX, String.Empty)
            RequireAdministrator = requireAdministratorEX
            Disabled = disabledEX
            Type = typeEX
            AllUsers = allUsersEX
            Name = nameEX
            RegistryPath = registryPathEX
            DisabledRegistryPath = disabledRegistryPathEX
            RegistryName = registryNameEX
        End Sub

        Public Sub New(ByVal nameEX As String, ByVal pathEX As String, ByVal requireAdministratorEX As Boolean, ByVal disabledEX As Boolean, ByVal typeEX As StartupType, ByVal allUsersEX As Boolean, Optional ByVal taskEx As Microsoft.Win32.TaskScheduler.Task = Nothing)
            Path = If(pathEX, String.Empty)
            RequireAdministrator = requireAdministratorEX
            Disabled = disabledEX
            Type = typeEX
            AllUsers = allUsersEX
            Name = nameEX
            RegistryPath = String.Empty
            DisabledRegistryPath = String.Empty
            RegistryName = String.Empty
            Task = taskEx
        End Sub

        Private Function ParseName(ByVal name As String) As String
            Dim parsedName = If(name = String.Empty, "(Default)", name)

            If String.IsNullOrWhiteSpace(parsedName) Then
                parsedName = "'" & parsedName & "'"
            End If

            Return parsedName
        End Function

        Public Enum StartupType
            Shortcut
            Regedit
            TaskScheduler
        End Enum

        Public Function GetParsedPath() As String
            Dim Result As String = String.Empty
            Dim FileName As String = Path
            Try

                If IO.File.Exists(Path) Then

                    Result = Path

                Else

                    Dim subValue() As String = FileName.Split("""")
                    subValue(1) = subValue(1).TrimEnd("""")
                    Result = subValue(1)

                End If

            Catch ex As Exception
                Dim intermediatesplits As String() = FileName.Split(New String() {" "}, StringSplitOptions.RemoveEmptyEntries)
                Result = intermediatesplits(0)
            End Try
            Return Result
        End Function

    End Class
End Namespace
