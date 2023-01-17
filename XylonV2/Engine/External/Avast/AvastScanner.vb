Imports System.IO
Imports XylonV2.Engine.External.Core

Namespace Engine.External.Avast
    Public Class AvastScanner
        '   Inherits IScanner

        Private ReadOnly ashCmdLocation As String

        Public Sub New(ByVal ashCmdLocation As String)
            If Not File.Exists(ashCmdLocation) Then
                Throw New FileNotFoundException()
            End If

            Me.ashCmdLocation = New FileInfo(ashCmdLocation).FullName
        End Sub

        Public Function Scan(ByVal file As String, ByVal Optional timeoutInMs As Integer = 30000) As ScanResult
            If Not IO.File.Exists(file) Then
                Return ScanResult.FileNotFound
            End If

            Dim fileInfo = New FileInfo(file)
            Dim process = New Process()
            Dim startInfo = New ProcessStartInfo(Me.ashCmdLocation) With {
                .Arguments = fileInfo.FullName & " /p=4 /s",
                .CreateNoWindow = True,
                .ErrorDialog = False,
                .WindowStyle = ProcessWindowStyle.Hidden,
                .UseShellExecute = False
            }

            process.StartInfo = startInfo
            process.Start()
            process.WaitForExit(timeoutInMs)

            If Not process.HasExited Then
                process.Kill()
                Return ScanResult.Timeout
            End If

            Select Case process.ExitCode
                Case 0
                    Return ScanResult.NoThreatFound
                Case 1
                    Return ScanResult.ThreatFound
                Case Else
                    Return ScanResult.[Error]
            End Select

        End Function
    End Class
End Namespace
