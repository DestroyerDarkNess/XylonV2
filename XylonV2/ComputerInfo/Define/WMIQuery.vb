Imports System
Imports System.Collections.Generic
Imports System.Management

Namespace ComputerInfo.Define
    Public Class WMIQuery
        Public Shared Function WMIExecQuery(ByVal query As String) As List(Of ManagementBaseObject)
            Dim ResultList As New List(Of ManagementBaseObject)
            Using searcher = New ManagementObjectSearcher(query)

                Using collection = searcher.[Get]()

                    For Each item As ManagementBaseObject In collection
                        ResultList.Add(item)
                    Next
                End Using
            End Using
            Return ResultList
        End Function

        Public Class CPU
            Public Shared ReadOnly Query As String = "select * from  Win32_Processor"
            Public Shared ReadOnly Name As String = "Name"
            Public Shared ReadOnly MaxClock As String = "MaxClockSpeed"
            Public Shared ReadOnly Voltage As String = "CurrentVoltage"
            Public Shared ReadOnly L2CacheSize As String = "L2CacheSize"
            Public Shared ReadOnly L3CacheSize As String = "L3CacheSize"
            Public Shared ReadOnly NumberOfCores As String = "NumberOfCores"
            Public Shared ReadOnly ThreadCount As String = "ThreadCount"
        End Class

        Public Class Bios
            Public Shared ReadOnly Query As String = "HARDWARE\DESCRIPTION\System\BIOS"
            Public Shared ReadOnly BaseBoardManufacturer As String = "BaseBoardManufacturer"
            Public Shared ReadOnly BaseBoardProduct As String = "BaseBoardProduct"
            Public Shared ReadOnly BaseBoardVersion As String = "BaseBoardVersion"
            Public Shared ReadOnly BiosReleaseDate As String = "BIOSReleaseDate"
            Public Shared ReadOnly BiosVersion As String = "BIOSVersion"
            Public Shared ReadOnly BiosVendor As String = "BIOSVendor"
            Public Shared ReadOnly SystemProductName As String = "SystemProductName"
            Public Shared ReadOnly SystemManufacturer As String = "SystemManufacturer"
            Public Shared ReadOnly SystemVersion As String = "SystemVersion"
        End Class

        Public Class RAM
            Public Shared ReadOnly Query As String = "select * from  Win32_PhysicalMemory"
            Public Shared ReadOnly Speed As String = "Speed"
            Public Shared ReadOnly ConfiguredVoltage As String = "ConfiguredVoltage"
            Public Shared ReadOnly Manufacturer As String = "Manufacturer"
        End Class

        Public Class Disk
            Public Shared ReadOnly DiskDriveQuery As String = "select * from  Win32_DiskDrive"
            Public Shared ReadOnly LogicalDiskQuery As String = "select * from  Win32_LogicalDisk"
            Public Shared ReadOnly LogicalToPartitionQuery As String = "select * from  Win32_LogicalDiskToPartition"
            Public Shared ReadOnly Caption As String = "Caption"
            Public Shared ReadOnly DeviceID As String = "DeviceID"
            Public Shared ReadOnly Model As String = "Model"
            Public Shared ReadOnly FileSystem As String = "FileSystem"
            Public Shared ReadOnly VolumeName As String = "VolumeName"
            Public Shared ReadOnly Size As String = "Size"
            Public Shared ReadOnly FreeSpace As String = "FreeSpace"
            Public Shared ReadOnly Status As String = "Status"
            Public Shared ReadOnly SystemName As String = "SystemName"
            Public Shared ReadOnly Name As String = "Name"
            Public Shared ReadOnly SerialNumber As String = "SerialNumber"
            Public Shared ReadOnly VolumeSerialNumber As String = "VolumeSerialNumber"
            Public Shared ReadOnly Signature As String = "Signature"
        End Class

        Public Class GPU
            Public Shared ReadOnly Query As String = "select * from  Win32_VideoController"
            Public Shared ReadOnly AdapterCompatibility As String = "AdapterCompatibility"
            Public Shared ReadOnly AdapterRAM As String = "AdapterRAM"
            Public Shared ReadOnly Caption As String = "Caption"
            Public Shared ReadOnly CurrentRefreshRate As String = "CurrentRefreshRate"
            Public Shared ReadOnly DriverDate As String = "DriverDate"
            Public Shared ReadOnly DriverVersion As String = "DriverVersion"
            Public Shared ReadOnly MaxRefreshRate As String = "MaxRefreshRate"
            Public Shared ReadOnly MinRefreshRate As String = "MinRefreshRate"
            Public Shared ReadOnly VideoProcessor As String = "VideoProcessor"
            Public Shared ReadOnly VideoModeDescription As String = "VideoModeDescription"
        End Class

        Public Class OS
            Public Shared ReadOnly Query As String = "select * from  Win32_OperatingSystem"
            Public Shared ReadOnly Caption As String = "Caption"
            Public Shared ReadOnly Architecture As String = "OSArchitecture"
            Public Shared ReadOnly BuildNumber As String = "BuildNumber"
            Public Shared ReadOnly Version As String = "Version"
            Public Shared ReadOnly SerialNumber As String = "SerialNumber"
            Public Shared ReadOnly LastBootUpTime As String = "LastBootUpTime"
            Public Shared ReadOnly CountryCode As String = "CountryCode"
            Public Shared ReadOnly CurrentTimeZone As String = "CurrentTimeZone"
            Public Shared ReadOnly MUILanguages As String = "MUILanguages"
            Public Shared ReadOnly Language As String = "OSLanguage"
            Public Shared ReadOnly InstallDate As String = "InstallDate"
        End Class
    End Class
End Namespace
