Imports System.Text
Imports XylonV2.Core.Engine.Watcher

Public Class ProcessTester

    Friend WithEvents ProcessMon As New ProcessWatcher


    '  Private PrivManager As New Core.Helper.PrivilegesManager

    Private Sub ProcessTester_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '  PrivManager.AcquireShutdownPrivilege(Process.GetCurrentProcess.Handle)
    End Sub

    Private Sub Button_StartMon_Click(sender As Object, e As EventArgs) Handles Button_StartMon.Click
        ProcessMon.Start()
    End Sub

    Private Sub Button_StopMon_Click(sender As Object, e As EventArgs) Handles Button_StopMon.Click
        ProcessMon.Stop()
    End Sub



    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="ProcessWatcher.ProcessStatusChanged"/> event of the <see cref="ProcessMon"/> instance.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="ProcessWatcher.ProcessStatusChangedEventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ProcessMon_ProcessStatusChanged(ByVal sender As Object, ByVal e As ProcessWatcher.ProcessStatusChangedEventArgs) Handles ProcessMon.ProcessStatusChanged

        Select Case e.ProcessEvent

            Case ProcessWatcher.ProcessEvents.Arrival

                Me.BeginInvoke(Sub()
                                   Try
                                       Dim ProcessPath As String = e.Win32Info.ExecutablePath

                                       Dim sb As New StringBuilder
                                       sb.AppendLine("Process Arrived...'")
                                       sb.AppendLine(String.Format("Name......: {0}", e.ProcessInfo.ProcessName.ToString))
                                       sb.AppendLine(String.Format("ID.....: {0}", e.ProcessID))
                                       sb.AppendLine(String.Format("Path......: {0}", ProcessPath))

                                       Dim Arguments As String = e.ProcessInfo.StartInfo.Arguments.ToString

                                       If Not Arguments = String.Empty Then
                                           sb.AppendLine(String.Format("Arguments: {0}", e.ProcessInfo.StartInfo.Arguments.ToString))
                                       End If

                                       TextBox1.Text += sb.ToString & vbNewLine & vbNewLine

                                   Catch ex As Exception
                                       TextBox1.Text += "[ERROR]  " & ex.Message & vbNewLine & vbNewLine
                                   End Try
                               End Sub)


            Case ProcessWatcher.ProcessEvents.Stopped

                Me.BeginInvoke(Sub()
                                   Try

                                       Dim sb As New StringBuilder
                                       sb.AppendLine("Process Stopped...'")
                                       sb.AppendLine(String.Format("Name......: {0}", e.ProcessInfo.ProcessName.ToString))
                                       sb.AppendLine(String.Format("ID.....: {0}", e.ProcessID))

                                       TextBox1.Text += sb.ToString & vbNewLine & vbNewLine

                                   Catch ex As Exception
                                       TextBox1.Text += "[ERROR]  " & ex.Message & vbNewLine & vbNewLine
                                   End Try
                               End Sub)


        End Select

    End Sub

End Class