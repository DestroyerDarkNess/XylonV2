Namespace StartupManager.Models
    Public Class StartupState
        Public Property Name As String
        Public Property Disabled As Boolean

        Public Sub New(ByVal name As String, ByVal disabled As Boolean)
            name = name
            disabled = disabled
        End Sub
    End Class
End Namespace
