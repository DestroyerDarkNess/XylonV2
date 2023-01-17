Imports System.IO
Imports XylonV2.Engine.External.Core

Namespace Engine.External.WindowsDefender
    Public Class WindowsDefenderScanner
        '   Implements IScanner

        Private Shared DefenderExeLocation As String = "C:\Program Files\Windows Defender\MpCmdRun.exe"

        Public Shared Function GetDefenderPath() As String
            Return DefenderExeLocation
        End Function

        Public ResultParsed As String = String.Empty
        Private ReadOnly mpcmdrunLocation As String

        Public Sub New(ByVal mpcmdrunLocation As String)
            If Not File.Exists(mpcmdrunLocation) Then
                Throw New FileNotFoundException()
            End If

            Me.mpcmdrunLocation = New FileInfo(mpcmdrunLocation).FullName
        End Sub

        Public Function Scan(ByVal file As String, ByVal Optional timeoutInMs As Integer = 30000) As ScanResult
            Try
                If Not IO.File.Exists(file) Then
                    Return ScanResult.FileNotFound
                End If
                Dim fileInfo = New FileInfo(file)
                Dim process = New Process()
                Dim startInfo = New ProcessStartInfo(Me.mpcmdrunLocation) With {
                    .Arguments = "-Scan -ScanType 3 -File " & """" & fileInfo.FullName & """" & " -DisableRemediation",
                    .CreateNoWindow = True,
                    .ErrorDialog = False,
                    .WindowStyle = ProcessWindowStyle.Normal,
                    .UseShellExecute = False,
                     .RedirectStandardOutput = True
                }
                process.StartInfo = startInfo
                process.Start()
                process.WaitForExit(timeoutInMs)

                If Not process.HasExited Then
                    process.Kill()
                    Return ScanResult.Timeout
                End If

                Dim HostOutput As String = process.StandardOutput.ReadToEnd
                ResultParsed = ParseInfo(HostOutput)

                Select Case process.ExitCode
                    Case 0
                        Return ScanResult.NoThreatFound
                    Case 2
                        Return ScanResult.ThreatFound
                    Case Else
                        Return ScanResult.[Error]
                End Select
            Catch ex As Exception
                Return ScanResult.[Error]
            End Try
        End Function

        Private Function ParseInfo(ByVal Output As String) As String
            Try
                Dim IdentifierLine As String = "Threat"
                Dim FoundLine As String = Output.Split(vbLf).LastOrDefault(Function(x) x.Contains(IdentifierLine))
                Dim ParseStr As String = RemoveWhitespace(FoundLine).Replace(IdentifierLine, "").Remove(0, 1)
                Return ParseStr
            Catch ex As Exception
                Return String.Empty
            End Try
        End Function

        Function RemoveWhitespace(fullString As String) As String
            Return New String(fullString.Where(Function(x) Not Char.IsWhiteSpace(x)).ToArray())
        End Function

    End Class
End Namespace
