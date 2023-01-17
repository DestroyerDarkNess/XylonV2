Imports System
Imports System.Management

Namespace ComputerInfo.WMI
    Public Class GPU
        Public Sub New()
            Dim iter = ComputerInfo.Define.WMIQuery.WMIExecQuery(ComputerInfo.Define.WMIQuery.GPU.Query).GetEnumerator()

            While iter.MoveNext()
                Dim wmi = iter.Current
                AdapterCompatiability = wmi(ComputerInfo.Define.WMIQuery.GPU.AdapterCompatibility)
                AdapterRAM = wmi(ComputerInfo.Define.WMIQuery.GPU.AdapterRAM)
                Caption = wmi(ComputerInfo.Define.WMIQuery.GPU.Caption)
                CurrentRefreshRate = wmi(ComputerInfo.Define.WMIQuery.GPU.CurrentRefreshRate)
                DriverDate = wmi(ComputerInfo.Define.WMIQuery.GPU.DriverDate)
                DriverVersion = wmi(ComputerInfo.Define.WMIQuery.GPU.DriverVersion)
                MaxRefreshRate = wmi(ComputerInfo.Define.WMIQuery.GPU.MaxRefreshRate)
                MinRefreshRate = wmi(ComputerInfo.Define.WMIQuery.GPU.MinRefreshRate)
                VideoModeDescription = wmi(ComputerInfo.Define.WMIQuery.GPU.VideoModeDescription)
                VideoProcessor = wmi(ComputerInfo.Define.WMIQuery.GPU.VideoProcessor)
            End While

            DriverDate = DriverDate.Split("."c)(0)
        End Sub

        Public Property AdapterCompatiability As String = String.Empty
        Public Property AdapterRAM As String = String.Empty
        Public Property Caption As String = String.Empty
        Public Property CurrentRefreshRate As String = String.Empty
        Public Property DriverDate As String = String.Empty
        Public Property DriverVersion As String = String.Empty
        Public Property MaxRefreshRate As String = String.Empty
        Public Property MinRefreshRate As String = String.Empty
        Public Property VideoModeDescription As String = String.Empty
        Public Property VideoProcessor As String = String.Empty
    End Class
End Namespace
