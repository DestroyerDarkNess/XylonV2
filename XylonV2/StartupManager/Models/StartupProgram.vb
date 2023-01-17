Imports System.IO

Namespace StartupManager.Models
    Public Class StartupProgram
        Public Property Name As String
        Public Property File As FileInfo
        Public Property Arguments As String
        Public Property Administrator As Boolean
        Public Property AllUsers As Boolean

        Public Sub New(ByVal name As String, ByVal file As FileInfo, ByVal arguments As String, ByVal administrator As Boolean, ByVal allUsers As Boolean)
            Me.Name = name
            Me.File = file
            Me.Arguments = arguments
            Me.Administrator = administrator
            Me.AllUsers = allUsers
        End Sub
    End Class
End Namespace
