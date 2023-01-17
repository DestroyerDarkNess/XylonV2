Imports System.IO
Imports XylonV2.Engine.External.Core

Namespace Engine.External.EsetScanner
    Public Class EsetScanner
        '  Inherits IScanner

        Private ReadOnly esetClsLocation As String

        Public Sub New(ByVal esetClsLocation As String)
            If Not File.Exists(esetClsLocation) Then
                Throw New FileNotFoundException()
            End If

            Me.esetClsLocation = New FileInfo(esetClsLocation).FullName
        End Sub

        Public Function Scan(ByVal file As String, ByVal Optional timeoutInMs As Integer = 30000) As ScanResult
            If Not IO.File.Exists(file) Then
                Return ScanResult.FileNotFound
            End If

            Dim fileInfo = New FileInfo(file)
            Dim process = New Process()
            Dim startInfo = New ProcessStartInfo(Me.esetClsLocation) With {
                .Arguments = fileInfo.FullName & " /no-log-console /preserve-time",
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
                Case 1, 50
                    Return ScanResult.ThreatFound
                Case 10, 100
                    Return ScanResult.[Error]
                Case Else
                    Return ScanResult.[Error]
            End Select
        End Function
    End Class
End Namespace
