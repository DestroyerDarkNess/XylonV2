Public Class Modules

    Public Shared ExceptionINI As String = String.Empty

    Public Shared Function Initialization(Optional ByVal Key As String = "") As Boolean
        Try
            Core.CheckAPI.ExMan = Key
            Dim MEntryDependency As String = Core.CheckAPI.Activactor.Msage
            Reflection.Assembly.Load(My.Resources.dnlib)
            Reflection.Assembly.Load(My.Resources.Microsoft_Win32_TaskScheduler)
            Return True
        Catch ex As Exception
            ExceptionINI = ex.Message
            Return False
        End Try
    End Function

End Class
