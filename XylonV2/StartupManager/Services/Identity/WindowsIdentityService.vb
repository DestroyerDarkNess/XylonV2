Imports System.Security.Principal

Namespace StartupManager.Services.Identity
    Public Class WindowsIdentityService

        Public Function IsElevated() As Boolean
            Using identity As WindowsIdentity = WindowsIdentity.GetCurrent()
                Dim principal As WindowsPrincipal = New WindowsPrincipal(identity)
                Dim isElevatedex As Boolean = principal.IsInRole(WindowsBuiltInRole.Administrator)
                Return isElevatedex
            End Using
        End Function

        Public Function CurrentUser() As String
            Using identity As WindowsIdentity = WindowsIdentity.GetCurrent()
                Dim principal As WindowsPrincipal = New WindowsPrincipal(identity)
                Return identity.Name
            End Using
        End Function
    End Class
End Namespace
