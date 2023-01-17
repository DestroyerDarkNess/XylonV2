Imports XylonV2.Engine.PE.AVEnums

Public Class StringExtractorTester

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim FileToScan As List(Of String) = Core.Helper.Util.OpenFile
        If FileToScan IsNot Nothing Then
            TextBox1.Text = FileToScan(0)
        End If
        If IO.File.Exists(TextBox1.Text) Then
            TextBox2.Text = ""
            Dim StrExtractor As StringExtract.Library.Extractor = New StringExtract.Library.Extractor(5)
            Dim ExtractStrings As List(Of String) = StrExtractor.Extract(IO.File.ReadAllBytes(TextBox1.Text)).ToList

            For Each Estr As String In ExtractStrings

                TextBox2.Text += Estr & vbNewLine

            Next

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ScanResult As Engine.External.Core.DetectionResult = Engine.PE.Analysis.StringScan(IO.File.ReadAllBytes(TextBox1.Text))
        TextBox3.Text = ScanResult.Result.ToString
        TextBox2.Text = "Signature:  " & ScanResult.Signature & vbNewLine & "Descriptor:  " & ScanResult.Description
    End Sub

    Private Sub StringExtractorTester_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim SignScanResult As Engine.Sign = Engine.SignInfo.AnalyzeFile(TextBox1.Text, Security.Cryptography.X509Certificates.X509RevocationMode.NoCheck)
        TextBox2.Text = "Result: " & SignScanResult.Result.ToString & vbNewLine & " Status: " & SignScanResult.Status & vbNewLine & " Publishier: " & SignScanResult.Publisher
    End Sub

End Class