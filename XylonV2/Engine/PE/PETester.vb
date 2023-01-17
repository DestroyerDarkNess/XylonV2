Public Class PETester

    Dim PinvokeScan As New Engine.Pinvoke.Scanner

    Private Sub PETester_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Dim exa As New StartupManagerExam
        ' exa.ShowDialog()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim FileToScan As List(Of String) = Core.Helper.Util.OpenFile
        If FileToScan IsNot Nothing Then
            TextBox1.Text = FileToScan(0)
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If IO.File.Exists(TextBox1.Text) Then
            Dim IsNetPE As Boolean = Engine.PE.Binary.PEChecker.IsNetAssembly(TextBox1.Text)

            If IsNetPE = True Then

                'ScanFileNet(TextBox1.Text)




            End If


        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If IO.File.Exists(TextBox1.Text) Then

            Dim GetFileInvokes As List(Of String) = PinvokeScan.ScanPinvokes(TextBox1.Text)
            If GetFileInvokes IsNot Nothing Then
                For Each PinvokeStr As String In GetFileInvokes
                    TextBox2.Text += PinvokeStr & vbNewLine
                Next
            End If

        End If
    End Sub

End Class