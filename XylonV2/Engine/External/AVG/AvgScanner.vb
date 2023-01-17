Imports System.IO
Imports XylonV2.Engine.External.Core

Namespace Engine.External.AVG
    Public Class AVGScanner
        'Inherits IScanner

        Private Const RETURNCODE_OK As Integer = 0
        Private Const RETURNCODE_USERSTOP As Integer = 1
        Private Const RETURNCODE_ERROR As Integer = 2
        Private Const RETURNCODE_WARNING As Integer = 3
        Private Const RETURNCODE_PUPDETECTED As Integer = 4
        Private Const RETURNCODE_VIRUSDETECTED As Integer = 5
        Private Const RETURNCODE_PWDARCHIVE As Integer = 6
        Private ReadOnly avgscanLocation As String

        Public Sub New(ByVal avgscanLocation As String)
            If Not File.Exists(avgscanLocation) Then
                Throw New FileNotFoundException()
            End If

            Me.avgscanLocation = New FileInfo(avgscanLocation).FullName
        End Sub

        Public Function Scan(ByVal file As String, ByVal Optional timeoutInMs As Integer = 30000) As ScanResult
            If Not IO.File.Exists(file) Then
                Return ScanResult.FileNotFound
            End If

            Dim fileInfo = New FileInfo(file)
            Dim process = New Process()
            Dim startInfo = New ProcessStartInfo(Me.avgscanLocation) With {
                .Arguments = "SCAN=" & fileInfo.FullName,
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
                Case RETURNCODE_OK
                    Return ScanResult.NoThreatFound
                Case RETURNCODE_VIRUSDETECTED, RETURNCODE_PUPDETECTED
                    Return ScanResult.ThreatFound
                Case Else
                    Return ScanResult.[Error]
            End Select
        End Function
    End Class
End Namespace
