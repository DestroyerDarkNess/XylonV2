Imports System
Imports System.Linq
Imports System.Management

Namespace ComputerInfo.WMI
    Public Class OS
        Public Sub New()
            Dim MUI As String()
            Dim iter = ComputerInfo.Define.WMIQuery.WMIExecQuery(ComputerInfo.Define.WMIQuery.OS.Query).GetEnumerator()

            While iter.MoveNext()
                Dim wmi = iter.Current
                Caption = wmi(ComputerInfo.Define.WMIQuery.OS.Caption)
                Architecture = wmi(ComputerInfo.Define.WMIQuery.OS.Architecture)
                BuildNumber = wmi(ComputerInfo.Define.WMIQuery.OS.BuildNumber)
                Version = wmi(ComputerInfo.Define.WMIQuery.OS.Version)
                SerialNumber = wmi(ComputerInfo.Define.WMIQuery.OS.SerialNumber)
                LastBootUpTime = wmi(ComputerInfo.Define.WMIQuery.OS.LastBootUpTime)
                ContryCode = wmi(ComputerInfo.Define.WMIQuery.OS.CountryCode)
                CurrentTimeZone = wmi(ComputerInfo.Define.WMIQuery.OS.CurrentTimeZone)
                MUI = CType(wmi(ComputerInfo.Define.WMIQuery.OS.MUILanguages), String())
                Language = wmi(ComputerInfo.Define.WMIQuery.OS.Language)
                InstallTime = ManagementDateTimeConverter.ToDateTime(wmi(ComputerInfo.Define.WMIQuery.OS.InstallDate))
                MUILanguages = String.Join(", ", MUI)
            End While
        End Sub

        Public Property Caption As String = String.Empty
        Public Property Architecture As String = String.Empty
        Public Property BuildNumber As String = String.Empty
        Public Property Version As String = String.Empty
        Public Property SerialNumber As String = String.Empty
        Public Property ProductKey As String = String.Empty
        Public Property ContryCode As String = String.Empty
        Public Property CurrentTimeZone As String = String.Empty
        Public Property MUILanguages As String = String.Empty
        Public Property Language As String = String.Empty
        Public Property LastBootUpTime As String = String.Empty
        Public Property InstallTime As DateTime = Nothing
    End Class
End Namespace
