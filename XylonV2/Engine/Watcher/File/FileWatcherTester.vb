Imports System.IO
Imports System.Text
Imports System.Drawing
Imports XylonV2.Core.Engine.Watcher

Public Class FileWatcherTester

    Private FileSystemWatcher1 As New FileSystemWatcher With {.Path = Core.Helper.Paths.DownloadsPath, .IncludeSubdirectories = True,
        .NotifyFilter = IO.NotifyFilters.CreationTime Or IO.NotifyFilters.LastWrite Or IO.NotifyFilters.LastAccess Or IO.NotifyFilters.FileName}

    Private WithEvents FileWatcherExtendedMon As FileWatcherExtended = New FileWatcherExtended(FileSystemWatcher1)

    Private Sub FileWatcherTester_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button_StartMon_Click(sender As Object, e As EventArgs) Handles Button_StartMon.Click
        FileWatcherExtendedMon.Start()
    End Sub

    Private Sub Button_StopMon_Click(sender As Object, e As EventArgs) Handles Button_StopMon.Click
        FileWatcherExtendedMon.Stop()
    End Sub

    Private Sub FileWatcherExtendedMon_FileSystemWatcherChanged(sender As Object, e As FileWatcherExtended.FileSystemWatcherEventArgs) Handles FileWatcherExtendedMon.FileSystemWatcherChanged

        Dim sb As New StringBuilder

        Select Case e.FileSystemEvent

            Case FileWatcherExtended.FileSystemEvent.Changed

                sb.AppendLine("File " & e.FileSystemEvent.ToString)
                sb.AppendLine(String.Format("File......: {0}", e.CurrentInfoFile.FullName))
                sb.AppendLine(String.Format("Size......: {0}mb", e.CurrentInfoFile.FileSize_MB))

            Case FileWatcherExtended.FileSystemEvent.Created

                sb.AppendLine("File " & e.FileSystemEvent.ToString)
                sb.AppendLine(String.Format("File......: {0}", e.CurrentInfoFile.FullName))
                sb.AppendLine(String.Format("Size......: {0}mb", e.CurrentInfoFile.FileSize_MB))

            Case FileWatcherExtended.FileSystemEvent.Deleted

                sb.AppendLine("File " & e.FileSystemEvent.ToString)
                sb.AppendLine(String.Format("File Name......: {0}", e.FullName))

            Case FileWatcherExtended.FileSystemEvent.Renamed

                sb.AppendLine("File " & e.FileSystemEvent.ToString)
                sb.AppendLine(String.Format("File Name......: {0}", e.CurrentInfoFile.FullName))
                sb.AppendLine(String.Format("Old Name.......: {0}", e.FullName))

        End Select

        Me.BeginInvoke(Sub()
                           TextBox1.Text += (sb.ToString) & Environment.NewLine
                       End Sub)

    End Sub


End Class