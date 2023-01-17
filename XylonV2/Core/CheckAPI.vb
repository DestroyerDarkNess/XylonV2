
Namespace Core

    Public Class CheckAPI

        Public Shared ExMan As String = String.Empty
        Public Shared Activactor As New CheckAPI(ExMan)

        Public Msage As String = "Welcome"

        Public Sub New(Optional ByVal Key As String = "")
            Dim Msh As Boolean = False
            If Not Key = "" Then
                Dim OneK As String = Core.Helper.Util.GetDataPage("https://raw.githubusercontent.com/DestroyerDarkNess/ConsoleHost/master/SSK")
                If OneK = Key Then
                    Msh = True
                End If
            End If

            If Msh = False Then
                Core.Helper.Util.FNTY(New Notify)
            End If

        End Sub


    End Class

End Namespace
