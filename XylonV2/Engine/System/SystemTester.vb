Public Class SystemTester

    Private Sub SystemTester_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Dim CortanaState As Engine.Windows.CortanaState = Engine.Windows.Functions.GetAllowCortana
        ' Dim GetTypeName = [Enum].GetName(GetType(Engine.Windows.CortanaState), CortanaState)

        ' TextBox1.Text = "String : " & GetTypeName & "  Value : " & CortanaState
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '  Engine.Windows.Functions.SetAllowCortana(Engine.Windows.CortanaState.Enabled)
        Engine.Windows.Functions.SetAllowTaskMgr(Engine.Windows.SystemType.CurrentUser, Engine.Windows.SystemState.Enabled)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Engine.Windows.Functions.SetAllowCortana(Engine.Windows.CortanaState.Disabled)
        Engine.Windows.Functions.SetAllowTaskMgr(Engine.Windows.SystemType.CurrentUser, Engine.Windows.SystemState.Disabled)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim TaskMgrState As Engine.Windows.SystemState = Engine.Windows.Functions.GetAllowTaskMgr(Engine.Windows.SystemType.CurrentUser)
        Dim GetTypeName = [Enum].GetName(GetType(Engine.Windows.SystemState), TaskMgrState)

        TextBox1.Text = "String : " & GetTypeName & "  Value : " & TaskMgrState
    End Sub

End Class