Imports System
Imports System.Management

Namespace ComputerInfo.WMI
    Public Class CPU
        Public Sub New()
            Dim iter = ComputerInfo.Define.WMIQuery.WMIExecQuery(ComputerInfo.Define.WMIQuery.CPU.Query).GetEnumerator()

            While iter.MoveNext()
                Dim wmi = iter.Current
                Name = wmi(ComputerInfo.Define.WMIQuery.CPU.Name).ToString().Trim()
                CurrentClock = Convert.ToInt32(wmi(ComputerInfo.Define.WMIQuery.CPU.MaxClock))
                Voltage = Convert.ToDouble(wmi(ComputerInfo.Define.WMIQuery.CPU.Voltage)) / 10
                L2CacheSize = Convert.ToInt32(wmi(ComputerInfo.Define.WMIQuery.CPU.L2CacheSize))
                L3CacheSize = Convert.ToInt32(wmi(ComputerInfo.Define.WMIQuery.CPU.L3CacheSize))
                CoreCount = Convert.ToInt32(wmi(ComputerInfo.Define.WMIQuery.CPU.NumberOfCores))
                ThreadCount = Convert.ToInt32(wmi(ComputerInfo.Define.WMIQuery.CPU.ThreadCount))
            End While
        End Sub

        Public Property Name As String = String.Empty
        Public Property CurrentClock As Int32 = IntPtr.Zero
        Public Property Voltage As Double = Nothing
        Public Property L2CacheSize As Int32 = IntPtr.Zero
        Public Property L3CacheSize As Int32 = IntPtr.Zero
        Public Property CoreCount As Int32 = IntPtr.Zero
        Public Property ThreadCount As Int32 = IntPtr.Zero
    End Class
End Namespace
