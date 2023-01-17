Public Class WMI_Tester

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For Each StartupItem As Core.Engine.WMI.Win32_StartupCommand In Core.Engine.WMI.Win32_StartupCommand.GetStartups
            TextBox1.Text += "Name: " & StartupItem.Name & vbNewLine & "Caption: " & StartupItem.Caption & vbNewLine & "Path: " & StartupItem.Location & vbNewLine & vbNewLine & vbNewLine
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ComputerInfo As Core.Engine.WMI.Win32_ComputerSystem = Core.Engine.WMI.Win32_ComputerSystem.GetComputerSystemInfo

        If ComputerInfo IsNot Nothing Then
            TextBox1.Text += "Computer Manufacturer: " & ComputerInfo.Manufacturer & vbNewLine
        End If

    End Sub

    Private Sub WMI_Tester_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        XylonV2.Modules.Initialization()
    End Sub

End Class