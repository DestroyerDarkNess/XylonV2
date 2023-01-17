Imports XylonV2.Engine.External.Avast
Imports XylonV2.Engine.External.AVG
Imports XylonV2.Engine.External.Core
Imports XylonV2.Engine.External.WindowsDefender

Public Class Tester

    Dim SWCounter As Stopwatch = New Stopwatch

    Public Sub MainEsx()
        Dim days As List(Of Object) = [Enum].GetValues(GetType(ScanResult)).Cast(Of Object).ToList()

        For Each Day As ScanResult In days
            MsgBox(Day.ToString() & "   ")
        Next
    End Sub


    Private Sub Tester_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = GetType(Tester).Module.Assembly.FullName
        Me.ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim FileToScan As List(Of String) = Core.Helper.Util.OpenFile
        If FileToScan IsNot Nothing Then
            TextBox1.Text = FileToScan(0)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim CurrentFile As String = TextBox1.Text

        If IO.File.Exists(CurrentFile) = True Then

            SWCounter.Start()

            Dim ItemIndex As Integer = ComboBox1.SelectedIndex
            Dim EngineSelect As String = ComboBox1.Items.Item(ItemIndex)
            Dim result As ScanResult = ScanResult.NoThreatFound
            Dim InfoParsed As String = String.Empty

            Label3.Text = "Scanning please wait ..."

            Select Case EngineSelect
                Case "Defender"
                    Dim exeLocation As String = "C:\Program Files\Windows Defender\MpCmdRun.exe"
                    Dim scanner As WindowsDefenderScanner = New WindowsDefenderScanner(exeLocation)
                    result = scanner.Scan(CurrentFile)
                    InfoParsed = scanner.ResultParsed
                Case "Avast"
                    Dim exeLocation As String = "C:\Program Files\AVAST Software\Avast\ashcmd.exe"
                    Dim scanner As AvastScanner = New AvastScanner(exeLocation)
                    result = scanner.Scan(CurrentFile)
                Case "AVG"
                    Dim exeLocation As String = String.Empty
                    If Core.Helper.Util.InternalCheckIsWow64 = True Then
                        exeLocation = "C:\Program Files (x86)\AVG\Av\avgscanx.exe"
                    Else
                        exeLocation = "C:\Program Files (x64)\AVG\Av\avgscanx.exe"
                    End If
                    Dim scanner As AVGScanner = New AVGScanner(exeLocation)
                    result = scanner.Scan(CurrentFile)
            End Select

            Label3.Text = result.ToString & "   /   " & InfoParsed & "   /   Time: " & SWCounter.ElapsedMilliseconds & "ms"

            SWCounter.Stop()
            SWCounter.Restart()
        End If


    End Sub


End Class