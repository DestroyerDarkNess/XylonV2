Imports System.Text
Imports XylonV2.Core.Engine.Watcher

Public Class TesterPendrive

    Friend WithEvents DriveMon As New DriveWatcher

    Private Sub TesterPendrive_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub StartMon_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button_StartMon.Click

        Me.DriveMon.Start()

    End Sub

    Private Sub StopMon_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button_StopMon.Click

        Me.DriveMon.Stop()

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="DriveWatcher.DriveStatusChanged"/> event of the <see cref="DriveMon"/> instance.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="DriveWatcher.DriveStatusChangedEventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub DriveMon_DriveStatusChanged(ByVal sender As Object, ByVal e As DriveWatcher.DriveStatusChangedEventArgs) Handles DriveMon.DriveStatusChanged

        Select Case e.DeviceEvent

            Case DriveWatcher.DeviceEvents.Arrival
                Dim sb As New StringBuilder
                sb.AppendLine("New drive connected...'")
                sb.AppendLine(String.Format("Type......: {0}", e.DriveInfo.DriveType.ToString))
                sb.AppendLine(String.Format("Label.....: {0}", e.DriveInfo.VolumeLabel))
                sb.AppendLine(String.Format("Name......: {0}", e.DriveInfo.Name))
                sb.AppendLine(String.Format("Root......: {0}", e.DriveInfo.RootDirectory))
                sb.AppendLine(String.Format("FileSystem: {0}", e.DriveInfo.DriveFormat))
                sb.AppendLine(String.Format("Size......: {0} GB", (e.DriveInfo.TotalSize / (1024 ^ 3)).ToString("n1")))
                sb.AppendLine(String.Format("Free space: {0} GB", (e.DriveInfo.AvailableFreeSpace / (1024 ^ 3)).ToString("n1")))
                TextBox1.Text += (sb.ToString) & Environment.NewLine

            Case DriveWatcher.DeviceEvents.RemoveComplete
                Dim sb As New StringBuilder
                sb.AppendLine("Drive disconnected...'")
                sb.AppendLine(String.Format("Name: {0}", e.DriveInfo.Name))
                sb.AppendLine(String.Format("Root: {0}", e.DriveInfo.RootDirectory))
                TextBox1.Text += (sb.ToString) & Environment.NewLine

        End Select

    End Sub

End Class