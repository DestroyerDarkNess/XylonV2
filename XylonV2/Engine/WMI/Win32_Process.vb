

Namespace Core.Engine.WMI

    Public Class Win32_Process

        Public Property Caption() As String
        Public Property CommandLine() As String
        Public Property CreationClassName() As String
        Public Property CreationDate() As DateTime?
        Public Property CSCreationClassName() As String
        Public Property CSName() As String
        Public Property Description() As String
        Public Property ExecutablePath() As String = String.Empty
        Public Property ExecutionState() As UInt16?
        Public Property Handle() As String
        Public Property HandleCount() As UInt32?
        Public Property InstallDate() As DateTime?
        Public Property KernelModeTime() As UInt64?
        Public Property MaximumWorkingSetSize() As UInt32?
        Public Property MinimumWorkingSetSize() As UInt32?
        Public Property Name() As String
        Public Property OSCreationClassName() As String
        Public Property OSName() As String
        Public Property OtherOperationCount() As UInt64?
        Public Property OtherTransferCount() As UInt64?
        Public Property PageFaults() As UInt32?
        Public Property PageFileUsage() As UInt32?
        Public Property ParentProcessId() As UInt32?
        Public Property PeakPageFileUsage() As UInt32?
        Public Property PeakVirtualSize() As UInt64?
        Public Property PeakWorkingSetSize() As UInt32?
        Public Property Priority() As UInt32?
        Public Property PrivatePageCount() As UInt64?
        Public Property ProcessId() As UInt32?
        Public Property QuotaNonPagedPoolUsage() As UInt32?
        Public Property QuotaPagedPoolUsage() As UInt32?
        Public Property QuotaPeakNonPagedPoolUsage() As UInt32?
        Public Property QuotaPeakPagedPoolUsage() As UInt32?
        Public Property ReadOperationCount() As UInt64?
        Public Property ReadTransferCount() As UInt64?
        Public Property SessionId() As UInt32?
        Public Property Status() As String
        Public Property TerminationDate() As DateTime?
        Public Property ThreadCount() As UInt32?
        Public Property UserModeTime() As UInt64?
        Public Property VirtualSize() As UInt64?
        Public Property WindowsVersion() As String
        Public Property WorkingSetSize() As UInt64?
        Public Property WriteOperationCount() As UInt64?
        Public Property WriteTransferCount() As UInt64?

        Public Shared Function GetProcesses(ByVal ProcessID As Integer) As Win32_Process
            Try

                Using searcher As New System.Management.ManagementObjectSearcher("Select * from Win32_Process Where ProcessId = '" & ProcessID & "'")

                    For Each item As System.Management.ManagementObject In searcher.Get()
                        Dim Result As New Win32_Process With {
                            .Caption = CType(item.Properties("Caption").Value, String),
                            .CommandLine = CType(item.Properties("CommandLine").Value, String),
                            .CreationClassName = CType(item.Properties("CreationClassName").Value, String),
                            .CreationDate = ManagementUtils.ToDateTime(item.Properties("CreationDate").Value),
                            .CSCreationClassName = CType(item.Properties("CSCreationClassName").Value, String),
                            .CSName = CType(item.Properties("CSName").Value, String),
                            .Description = CType(item.Properties("Description").Value, String),
                            .ExecutablePath = CType(item.Properties("ExecutablePath").Value, String),
                            .ExecutionState = CType(item.Properties("ExecutionState").Value, UInt16?),
                            .Handle = CType(item.Properties("Handle").Value, String),
                            .HandleCount = CType(item.Properties("HandleCount").Value, UInt32?),
                            .InstallDate = ManagementUtils.ToDateTime(item.Properties("InstallDate").Value),
                            .KernelModeTime = CType(item.Properties("KernelModeTime").Value, UInt64?),
                            .MaximumWorkingSetSize = CType(item.Properties("MaximumWorkingSetSize").Value, UInt32?),
                            .MinimumWorkingSetSize = CType(item.Properties("MinimumWorkingSetSize").Value, UInt32?),
                            .Name = CType(item.Properties("Name").Value, String),
                            .OSCreationClassName = CType(item.Properties("OSCreationClassName").Value, String),
                            .OSName = CType(item.Properties("OSName").Value, String),
                            .OtherOperationCount = CType(item.Properties("OtherOperationCount").Value, UInt64?),
                            .OtherTransferCount = CType(item.Properties("OtherTransferCount").Value, UInt64?),
                            .PageFaults = CType(item.Properties("PageFaults").Value, UInt32?),
                            .PageFileUsage = CType(item.Properties("PageFileUsage").Value, UInt32?),
                            .ParentProcessId = CType(item.Properties("ParentProcessId").Value, UInt32?),
                            .PeakPageFileUsage = CType(item.Properties("PeakPageFileUsage").Value, UInt32?),
                            .PeakVirtualSize = CType(item.Properties("PeakVirtualSize").Value, UInt64?),
                            .PeakWorkingSetSize = CType(item.Properties("PeakWorkingSetSize").Value, UInt32?),
                            .Priority = CType(item.Properties("Priority").Value, UInt32?),
                            .PrivatePageCount = CType(item.Properties("PrivatePageCount").Value, UInt64?),
                            .ProcessId = CType(item.Properties("ProcessId").Value, UInt32?),
                            .QuotaNonPagedPoolUsage = CType(item.Properties("QuotaNonPagedPoolUsage").Value, UInt32?),
                            .QuotaPagedPoolUsage = CType(item.Properties("QuotaPagedPoolUsage").Value, UInt32?),
                            .QuotaPeakNonPagedPoolUsage = CType(item.Properties("QuotaPeakNonPagedPoolUsage").Value, UInt32?),
                            .QuotaPeakPagedPoolUsage = CType(item.Properties("QuotaPeakPagedPoolUsage").Value, UInt32?),
                            .ReadOperationCount = CType(item.Properties("ReadOperationCount").Value, UInt64?),
                            .ReadTransferCount = CType(item.Properties("ReadTransferCount").Value, UInt64?),
                            .SessionId = CType(item.Properties("SessionId").Value, UInt32?),
                            .Status = CType(item.Properties("Status").Value, String),
                            .TerminationDate = ManagementUtils.ToDateTime(item.Properties("TerminationDate").Value),
                            .ThreadCount = CType(item.Properties("ThreadCount").Value, UInt32?),
                            .UserModeTime = CType(item.Properties("UserModeTime").Value, UInt64?),
                            .VirtualSize = CType(item.Properties("VirtualSize").Value, UInt64?),
                            .WindowsVersion = CType(item.Properties("WindowsVersion").Value, String),
                            .WorkingSetSize = CType(item.Properties("WorkingSetSize").Value, UInt64?),
                            .WriteOperationCount = CType(item.Properties("WriteOperationCount").Value, UInt64?),
                            .WriteTransferCount = CType(item.Properties("WriteTransferCount").Value, UInt64?)
                        }
                        Return Result
                    Next

                End Using

                Return Nothing

            Catch ex As Exception
                Return Nothing
            End Try
        End Function

    End Class

End Namespace
