Imports System.Management
Imports System.Security.Principal
Imports Microsoft.Win32
Imports XylonV2.Core.Engine.Watcher


Public Class RegeditTester

    Friend WithEvents RegeditMon As New RegeditWatcher

    Friend WithEvents RegMonitor As New RegistryMonitor(Microsoft.Win32.RegistryHive.LocalMachine, "SOFTWARE\Microsoft\Windows\CurrentVersion\Run")

    Private PrivManager As New Core.Helper.PrivilegesManager

    Private Sub RegMonitor_RegChanged(ByVal sender As Object, ByVal e As RegistryMonitor.RegistryStatusChangedEventArgs) Handles RegMonitor.RegChanged
        TextBox1.Text += "registry key has changed" & vbNewLine & e.RegeditInfo & vbNewLine
    End Sub

    Private Sub RegeditTester_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PrivManager.AcquireShutdownPrivilege(Process.GetCurrentProcess.Handle)
        Starting()
    End Sub

    Private Sub Button_StartMon_Click(sender As Object, e As EventArgs) Handles Button_StartMon.Click
        RegMonitor.Start()
    End Sub

    Private Sub Button_StopMon_Click(sender As Object, e As EventArgs) Handles Button_StopMon.Click
        RegMonitor.[Stop]()
    End Sub

    ' Private Const query As String = "SELECT * FROM RegistryTreeChangeEvent " & "WHERE Hive='HKEY_LOCAL_MACHINE' " & "AND RootPath='SOFTWARE'"
    Private Const query As String = "SELECT * FROM RegistryKeyChangeEvent " & "WHERE Hive='HKEY_LOCAL_MACHINE' " & "AND KeyPath='SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run'" '\\Microsoft
    Private watcher As ManagementEventWatcher

    Public Sub Starting()
        watcher = New ManagementEventWatcher(query)
        AddHandler watcher.EventArrived, New EventArrivedEventHandler(AddressOf registryEventHandler)
        watcher.Start()
    End Sub

    Private Sub registryEventHandler(ByVal sender As Object, ByVal e As EventArrivedEventArgs)
        Me.BeginInvoke(Sub()
                           Try
                               TextBox1.Text += "Received an event:" & vbNewLine

                               For Each prop In e.NewEvent.Properties
                                   TextBox1.Text += prop.Name & ":" & prop.Value.ToString() & vbNewLine
                               Next
                           Catch ex As Exception
                               TextBox1.Text += ex.Message & vbNewLine
                           End Try
                       End Sub)
    End Sub

End Class