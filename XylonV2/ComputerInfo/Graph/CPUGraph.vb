Imports System
Imports System.Diagnostics

Namespace ComputerInfo.Graph
    Public Class CPUGraph

        Public Property CPU_Usage As Integer = 0
        Public Property ErrorOnCounter As Boolean = False

        Dim cpuCounter As PerformanceCounter = Nothing

        Public Sub New()
            cpuCounter = New PerformanceCounter With {
            .CategoryName = "Processor",
            .CounterName = "% Processor Time",
            .InstanceName = "_Total"
        }
        End Sub

        Public Sub RefreshGraph()

            Try
                Dim percent As Double = cpuCounter.NextValue()
                Dim usage As Integer = Convert.ToInt32(percent)
                CPU_Usage = usage
            Catch ex As Exception

                ErrorOnCounter = True

            End Try

        End Sub

    End Class
End Namespace
