
Namespace Core.Engine.WMI

    Public Class Win32_StartupCommand

        Public Property Caption As String
        Public Property Description As String
        Public Property SettingID As String
        Public Property Command As String
        Public Property Location As String
        Public Property Name As String
        Public Property User As String
        Public Property UserSID As String

        Public Shared Function GetStartups() As List(Of Win32_StartupCommand)
            Try
                Dim WStartupList As New List(Of Win32_StartupCommand)

                Using searcher As New System.Management.ManagementObjectSearcher(New System.Management.SelectQuery("Select * From Win32_StartupCommand"))

                    For Each item As System.Management.ManagementObject In searcher.Get()
                        Try
                            Dim Result As New Win32_StartupCommand With {
                          .Caption = CType(item.Properties("Caption").Value, String),
                          .Description = CType(item.Properties("Description").Value, String),
                          .SettingID = CType(item.Properties("SettingID").Value, String),
                          .Command = CType(item.Properties("Command").Value, String),
                          .Location = CType(item.Properties("Location").Value, String),
                          .Name = CType(item.Properties("Name").Value, String),
                          .User = CType(item.Properties("User").Value, String),
                          .UserSID = CType(item.Properties("UserSID").Value, String)
                      }
                            WStartupList.Add(Result)
                        Catch ex As Exception
                            Console.WriteLine(ex.Message)
                        End Try
                    Next

                End Using

                Return WStartupList

            Catch ex As Exception
                Return Nothing
            End Try
        End Function

    End Class

End Namespace
