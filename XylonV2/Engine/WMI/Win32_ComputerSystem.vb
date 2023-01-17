Namespace Core.Engine.WMI

    Public Class Win32_ComputerSystem

        Public Property AdminPasswordStatus As Integer
        Public Property AutomaticManagedPagefile As Boolean
        Public Property AutomaticResetBootOption As Boolean
        Public Property AutomaticResetCapability As Boolean
        Public Property BootOptionOnLimit As Integer
        Public Property BootOptionOnWatchDog As Integer
        Public Property BootROMSupported As Boolean
        Public Property BootupState As String
        Public Property BootStatus As Integer
        Public Property Caption As String
        Public Property ChassisBootupState As Integer
        Public Property ChassisSKUNumber As String
        Public Property CreationClassName As String
        Public Property CurrentTimeZone As Integer
        Public Property DaylightInEffect As Boolean
        Public Property Description As String
        Public Property DNSHostName As String
        Public Property Domain As String
        Public Property DomainRole As Integer
        Public Property EnableDaylightSavingsTime As Boolean
        Public Property FrontPanelResetStatus As Integer
        Public Property HypervisorPresent As Boolean
        Public Property InfraredSupported As Boolean
        Public Property InitialLoadInfo As String
        Public Property InstallDate As DateTime
        Public Property KeyboardPasswordStatus As Integer
        Public Property LastLoadInfo As String
        Public Property Manufacturer As String
        Public Property Model As String
        Public Property Name As String
        Public Property NameFormat As String
        Public Property NetworkServerModeEnabled As Boolean
        Public Property NumberOfLogicalProcessors As Integer
        Public Property NumberOfProcessors As Integer
        Public Property OEMLogoBitmap As Integer
        Public Property OEMStringArray As String()
        Public Property PartOfDomain As Boolean
        Public Property PauseAfterReset As Integer
        Public Property PCSystemType As Integer
        Public Property PCSystemTypeEx As Integer
        Public Property PowerManagementCapabilities As Integer
        Public Property PowerManagementSupported As Boolean
        Public Property PowerOnPasswordStatus As Integer
        Public Property PowerState As Integer
        Public Property PowerSupplyState As Integer
        Public Property PrimaryOwnerContact As String
        Public Property PrimaryOwnerName As String
        Public Property ResetCapability As Integer
        Public Property ResetCount As Integer
        Public Property ResetLimit As Integer
        Public Property Roles As String()
        Public Property Status As String
        Public Property SupportContactDescription As String
        Public Property SystemFamily As String
        Public Property SystemSKUNumber As String
        Public Property SystemStartupDelay As Integer
        Public Property SystemStartupOptions As String
        Public Property SystemStartupSetting As Integer
        Public Property SystemType As String
        Public Property ThermalState As Integer
        Public Property TotalPhysicalMemory As ULong
        Public Property UserName As String
        Public Property WakeUpType As ULong
        Public Property Workgroup As String

        Public Shared Function GetComputerSystemInfo() As Win32_ComputerSystem
            Dim item As System.Management.ManagementObject

            Try
                item = New System.Management.ManagementObject("ROOT\CIMV2:Win32_ComputerSystem.Name='" & Environment.MachineName & "'")
            Catch ex As Exception
                Return Nothing
            End Try

            Dim Result As New Win32_ComputerSystem
            Try
                Result.AdminPasswordStatus = CType(item.Properties("AdminPasswordStatus").Value, UInt16)
            Catch ex As Exception
                Result.AdminPasswordStatus = 0
            End Try
            Try
                Result.AutomaticManagedPagefile = CType(item.Properties("AutomaticManagedPagefile").Value, Boolean)
            Catch ex As Exception
                Result.AutomaticManagedPagefile = False
            End Try
            Try
                Result.AutomaticResetBootOption = CType(item.Properties("AutomaticResetBootOption").Value, Boolean)
            Catch ex As Exception
                Result.AutomaticResetBootOption = False
            End Try
            Try
                Result.AutomaticResetCapability = CType(item.Properties("AutomaticResetCapability").Value, Boolean)
            Catch ex As Exception
                Result.AutomaticResetCapability = False
            End Try
            Try
                Result.BootOptionOnLimit = CType(item.Properties("BootOptionOnLimit").Value, Integer)
            Catch ex As Exception
                Result.BootOptionOnLimit = 0
            End Try
            Try
                Result.BootOptionOnWatchDog = CType(item.Properties("BootOptionOnWatchDog").Value, Integer)
            Catch ex As Exception
                Result.BootOptionOnWatchDog = 0
            End Try
            Try
                Result.BootROMSupported = CType(item.Properties("BootROMSupported").Value, Boolean)
            Catch ex As Exception
                Result.BootROMSupported = False
            End Try
            Try
                Result.BootupState = CType(item.Properties("BootupState").Value, String)
            Catch ex As Exception
                Result.BootupState = String.Empty
            End Try
            Try
                Result.BootStatus = CType(item.Properties("BootStatu").Value, Integer)
            Catch ex As Exception
                Result.BootStatus = 0
            End Try
            Try
                Result.Caption = CType(item.Properties("Caption").Value, String)
            Catch ex As Exception
                Result.Caption = String.Empty
            End Try
            Try
                Result.ChassisBootupState = CType(item.Properties("ChassisBootupState").Value, Integer)
            Catch ex As Exception
                Result.ChassisBootupState = 0
            End Try
            Try
                Result.ChassisSKUNumber = CType(item.Properties("ChassisSKUNumber").Value, String)
            Catch ex As Exception
                Result.ChassisSKUNumber = String.Empty
            End Try
            Try
                Result.CreationClassName = CType(item.Properties("CreationClassName").Value, String)
            Catch ex As Exception
                Result.CreationClassName = String.Empty
            End Try
            Try
                Result.CurrentTimeZone = CType(item.Properties("CurrentTimeZone").Value, Integer)
            Catch ex As Exception
                Result.CurrentTimeZone = 0
            End Try
            Try
                Result.DaylightInEffect = CType(item.Properties("DaylightInEffect").Value, Boolean)
            Catch ex As Exception
                Result.DaylightInEffect = False
            End Try
            Try
                Result.Description = CType(item.Properties("Description").Value, String)
            Catch ex As Exception
                Result.Description = String.Empty
            End Try
            Try
                Result.DNSHostName = CType(item.Properties("DNSHostName").Value, String)
            Catch ex As Exception
                Result.DNSHostName = String.Empty
            End Try
            Try
                Result.Domain = CType(item.Properties("Domain").Value, String)
            Catch ex As Exception
                Result.Domain = String.Empty
            End Try
            Try
                Result.DomainRole = CType(item.Properties("DomainRole").Value, Integer)
            Catch ex As Exception
                Result.DomainRole = 0
            End Try
            Try
                Result.EnableDaylightSavingsTime = CType(item.Properties("EnableDaylightSavingsTime").Value, Boolean)
            Catch ex As Exception
                Result.EnableDaylightSavingsTime = 0
            End Try
            Try
                Result.FrontPanelResetStatus = CType(item.Properties("FrontPanelResetStatus").Value, Integer)
            Catch ex As Exception
                Result.FrontPanelResetStatus = 0
            End Try
            Try
                Result.HypervisorPresent = CType(item.Properties("HypervisorPresent").Value, Boolean)
            Catch ex As Exception
                Result.HypervisorPresent = False
            End Try
            Try
                Result.InfraredSupported = CType(item.Properties("InfraredSupported").Value, Boolean)
            Catch ex As Exception
                Result.InfraredSupported = False
            End Try
            Try
                Result.InitialLoadInfo = CType(item.Properties("InitialLoadInfo").Value, String)
            Catch ex As Exception
                Result.InitialLoadInfo = String.Empty
            End Try
            Try
                Result.InstallDate = CType(item.Properties("InstallDate").Value, Date)
            Catch ex As Exception
                Result.InstallDate = Nothing
            End Try
            Try
                Result.KeyboardPasswordStatus = CType(item.Properties("KeyboardPasswordStatus").Value, Integer)
            Catch ex As Exception
                Result.KeyboardPasswordStatus = 0
            End Try
            Try
                Result.LastLoadInfo = CType(item.Properties("LastLoadInfo").Value, String)
            Catch ex As Exception
                Result.LastLoadInfo = String.Empty
            End Try
            Try
                Result.Manufacturer = CType(item.Properties("Manufacturer").Value, String)
            Catch ex As Exception
                Result.Manufacturer = String.Empty
            End Try
            Try
                Result.Model = CType(item.Properties("Model").Value, String)
            Catch ex As Exception
                Result.Model = String.Empty
            End Try
            Try
                Result.Name = CType(item.Properties("Name").Value, String)
            Catch ex As Exception
                Result.Name = String.Empty
            End Try
            Try
                Result.NameFormat = CType(item.Properties("NameFormat").Value, String)
            Catch ex As Exception
                Result.NameFormat = String.Empty
            End Try
            Try
                Result.NetworkServerModeEnabled = CType(item.Properties("NetworkServerModeEnabled").Value, Boolean)
            Catch ex As Exception
                Result.NetworkServerModeEnabled = False
            End Try
            Try
                Result.NumberOfLogicalProcessors = CType(item.Properties("NumberOfLogicalProcessors").Value, Integer)
            Catch ex As Exception
                Result.NumberOfLogicalProcessors = 1
            End Try
            Try
                Result.NumberOfProcessors = CType(item.Properties("NumberOfProcessors").Value, Integer)
            Catch ex As Exception
                Result.NumberOfProcessors = 1
            End Try
            Try
                Result.OEMLogoBitmap = CType(item.Properties("OEMLogoBitmap").Value, Integer)
            Catch ex As Exception
                Result.OEMLogoBitmap = 1
            End Try
            Try
                Result.OEMStringArray = CType(item.Properties("OEMStringArray").Value, String())
            Catch ex As Exception
                Result.OEMStringArray = Nothing
            End Try
            Try
                Result.PartOfDomain = CType(item.Properties("PartOfDomain").Value, Boolean)
            Catch ex As Exception
                Result.PartOfDomain = False
            End Try
            Try
                Result.PauseAfterReset = CType(item.Properties("PauseAfterReset").Value, Integer)
            Catch ex As Exception
                Result.PauseAfterReset = 0
            End Try
            Try
                Result.PCSystemType = CType(item.Properties("PCSystemType").Value, Integer)
            Catch ex As Exception
                Result.PCSystemType = 0
            End Try
            Try
                Result.PCSystemTypeEx = CType(item.Properties("PCSystemTypeEx").Value, Integer)
            Catch ex As Exception
                Result.PCSystemTypeEx = 0
            End Try
            Try
                Result.PowerManagementCapabilities = CType(item.Properties("PowerManagementCapabilities").Value, Integer)
            Catch ex As Exception
                Result.PowerManagementCapabilities = 0
            End Try
            Try
                Result.PowerManagementSupported = CType(item.Properties("PowerManagementSupported").Value, Boolean)
            Catch ex As Exception
                Result.PowerManagementSupported = False
            End Try
            Try
                Result.PowerOnPasswordStatus = CType(item.Properties("PowerOnPasswordStatus").Value, Integer)
            Catch ex As Exception
                Result.PowerOnPasswordStatus = 0
            End Try
            Try
                Result.PowerState = CType(item.Properties("PowerState").Value, Integer)
            Catch ex As Exception
                Result.PowerState = 0
            End Try
            Try
                Result.PowerSupplyState = CType(item.Properties("PowerSupplyState").Value, Integer)
            Catch ex As Exception
                Result.PowerSupplyState = 0
            End Try
            Try
                Result.PrimaryOwnerContact = CType(item.Properties("PrimaryOwnerContact").Value, String)
            Catch ex As Exception
                Result.PrimaryOwnerContact = String.Empty
            End Try
            Try
                Result.PrimaryOwnerName = CType(item.Properties("PrimaryOwnerName").Value, String)
            Catch ex As Exception
                Result.PrimaryOwnerName = String.Empty
            End Try
            Try
                Result.ResetCapability = CType(item.Properties("ResetCapability").Value, Integer)
            Catch ex As Exception
                Result.ResetCapability = 0
            End Try
            Try
                Result.ResetCount = CType(item.Properties("ResetCount").Value, Integer)
            Catch ex As Exception
                Result.ResetCount = 0
            End Try
            Try
                Result.ResetLimit = CType(item.Properties("ResetLimit").Value, Integer)
            Catch ex As Exception
                Result.ResetLimit = 0
            End Try
            Try
                Result.Roles = CType(item.Properties("Roles").Value, String())
            Catch ex As Exception
                Result.Roles = Nothing
            End Try
            Try
                Result.Status = CType(item.Properties("Status").Value, String)
            Catch ex As Exception
                Result.Status = String.Empty
            End Try
            Try
                Result.SupportContactDescription = CType(item.Properties("SupportContactDescription").Value, String)
            Catch ex As Exception
                Result.SupportContactDescription = String.Empty
            End Try
            Try
                Result.SystemFamily = CType(item.Properties("SystemFamily").Value, String)
            Catch ex As Exception
                Result.SystemFamily = String.Empty
            End Try
            Try
                Result.SystemSKUNumber = CType(item.Properties("SystemSKUNumber").Value, String)
            Catch ex As Exception
                Result.SystemSKUNumber = String.Empty
            End Try
            Try
                Result.SystemStartupDelay = CType(item.Properties("SystemStartupDelay").Value, Integer)
            Catch ex As Exception
                Result.SystemStartupDelay = 0
            End Try
            Try
                Result.SystemStartupOptions = CType(item.Properties("SystemStartupOptions").Value, String)
            Catch ex As Exception
                Result.SystemStartupOptions = String.Empty
            End Try
            Try
                Result.SystemStartupSetting = CType(item.Properties("SystemStartupSetting").Value, Integer)
            Catch ex As Exception
                Result.SystemStartupSetting = 0
            End Try
            Try
                Result.SystemType = CType(item.Properties("SystemType").Value, String)
            Catch ex As Exception
                Result.SystemType = String.Empty
            End Try
            Try
                Result.ThermalState = CType(item.Properties("ThermalState").Value, Integer)
            Catch ex As Exception
                Result.ThermalState = 0
            End Try
            Try
                Result.TotalPhysicalMemory = CType(item.Properties("TotalPhysicalMemory").Value, ULong)
            Catch ex As Exception
                Result.TotalPhysicalMemory = 0
            End Try
            Try
                Result.UserName = CType(item.Properties("UserName").Value, String)
            Catch ex As Exception
                Result.UserName = String.Empty
            End Try
            Try
                Result.WakeUpType = CType(item.Properties("WakeUpType").Value, ULong)
            Catch ex As Exception
                Result.WakeUpType = 0
            End Try
            Try
                Result.Workgroup = CType(item.Properties("Workgroup").Value, String)
            Catch ex As Exception
                Result.Workgroup = String.Empty
            End Try

            Return Result

        End Function


    End Class

End Namespace

