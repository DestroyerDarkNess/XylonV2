Imports System
Imports System.Management

Namespace ComputerInfo.WMI
    Public Class RAM
        Private Shared ReadOnly info As Microsoft.VisualBasic.Devices.ComputerInfo = New Microsoft.VisualBasic.Devices.ComputerInfo()

        Public Sub New()
            Update()
        End Sub

        Public Function Update() As Boolean
            Try
                Dim iter = ComputerInfo.Define.WMIQuery.WMIExecQuery(ComputerInfo.Define.WMIQuery.RAM.Query).GetEnumerator()

                While iter.MoveNext()
                    Dim wmi = iter.Current
                    Speed = wmi(ComputerInfo.Define.WMIQuery.RAM.Speed)
                    Dim Vol As String = wmi(ComputerInfo.Define.WMIQuery.RAM.ConfiguredVoltage)
                    If Vol Is Nothing Then Voltage = String.Empty Else Voltage = Vol '.Insert(1, ".").ToString
                    Manufacturer = wmi(ComputerInfo.Define.WMIQuery.RAM.Manufacturer)
                End While

                PysicalSize = info.TotalPhysicalMemory
                VirtualSize = info.TotalVirtualMemory
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Property PysicalSize As UInt64
        Public Property VirtualSize As UInt64

        Public ReadOnly Property AvailablePhysicalSize As UInt64
            Get
                Return info.AvailablePhysicalMemory
            End Get
        End Property

        Public ReadOnly Property AvailableVirtualSize As UInt64
            Get
                Return info.AvailableVirtualMemory
            End Get
        End Property

        Public Property Speed As String = String.Empty
        Public Property Voltage As String = String.Empty
        Public Property Manufacturer As String = String.Empty
    End Class
End Namespace
