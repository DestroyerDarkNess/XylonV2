
Namespace ComputerInfo.Graph
    Public Class RAMGraph

        Public Property ErrorOnCounter As Boolean = False

        Public Sub New()

        End Sub

        Public Property Ram_Physical_Usage As Integer = 0
        Public Property Ram_Virtual_Usage As Integer = 0
        Public Property Ram_Physical_Used_Size As String = String.Empty
        Public Property Ram_Virtual_Used_Size As String = String.Empty

        Public Sub RefreshGraph(ByVal ram As WMI.RAM)
            Try
                Dim physicalTotal As UInt64 = ram.PysicalSize
                Dim physicalAvailable As UInt64 = ram.AvailablePhysicalSize
                Dim virtualTotal As UInt64 = ram.VirtualSize
                Dim virtualAvailable As UInt64 = ram.AvailableVirtualSize
                Dim physicalPercentage As Double = (physicalTotal - physicalAvailable) * 100 / physicalTotal
                Dim virtualPercentage As Double = (virtualTotal - virtualAvailable) * 100 / virtualTotal
                Ram_Physical_Usage = CInt(physicalPercentage)
                Ram_Virtual_Usage = CInt(virtualPercentage)
                Ram_Physical_Used_Size = String.Format("{0:F2} GB in use", (physicalTotal - physicalAvailable) / 1024.0F / 1024.0F / 1024.0F)
                Ram_Virtual_Used_Size = String.Format("{0:F2} GB in use", (virtualTotal - virtualAvailable) / 1024.0F / 1024.0F / 1024.0F)
            Catch ex As Exception

                ErrorOnCounter = True

            End Try
        End Sub

    End Class
End Namespace
