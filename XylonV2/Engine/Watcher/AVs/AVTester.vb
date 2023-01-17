Imports System.Management
Imports XylonV2.Core.Engine.Watcher

Public Class AVTester

    Private WithEvents DefenderMon As New DefenderWatcher


    Private Sub AVTester_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button_StartMon_Click(sender As Object, e As EventArgs) Handles Button_StartMon.Click
        DefenderMon.Start()
    End Sub

    Private Sub Button_StopMon_Click(sender As Object, e As EventArgs) Handles Button_StopMon.Click
        DefenderMon.Stop()
    End Sub


    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="DefenderWatcher.DefenderStatusChanged"/> event of the <see cref="DefenderMon"/> instance.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="DefenderWatcher.DefenderStatusChangedEventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub DefenderMon_DefenderStatusChanged(ByVal sender As Object, ByVal e As DefenderWatcher.DefenderStatusChangedEventArgs) Handles DefenderMon.DefenderStatusChanged

        Dim sb As New System.Text.StringBuilder
        sb.AppendLine(" Defender Configuration change -  Windows Defender RealtimeMonitoring")
        sb.AppendLine(String.Format("DisableRealtimeMonitoring......: {0}", e.TargetInstance.ToString))
        sb.AppendLine(String.Format("Old Value......................: {0}", e.PreviousInstance.ToString))
        Me.BeginInvoke(Sub()
                           TextBox1.Text += (sb.ToString) & Environment.NewLine & Environment.NewLine
                       End Sub)
    End Sub


End Class