Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Engine.Pinvoke

    Public Class Scanner

        Private pinvokesInfo As Pinvoke.Info = New Pinvoke.Info()

        Private pinvokesList As List(Of Object) = Nothing
        Private listEx As List(Of String) = Nothing

        Public Sub New()
            pinvokesList = GetPinvokeList()
            listEx = EnumToList(pinvokesList).Distinct().ToList()
        End Sub

#Region " Private Methods "

        Private Function EX(ByVal Text As String) As String

            Dim stringBuilder As StringBuilder = New StringBuilder()

            Dim num2 As Integer = Text.Length - 1

            For Each TextByte As String In Text.Split(" ")
                Dim StrHex As String = "&H" + TextByte
                Dim ValConverted As Double = Math.Round(Conversion.Val(StrHex))
                Dim ToChar As String = Strings.Chr(CInt(ValConverted))
                stringBuilder.Append(ToChar)

            Next

            Return stringBuilder.ToString()
        End Function

        Private Function ӗ(ByVal Text As String) As String
            Return New String(Text.Where(AddressOf IsWhiteSpace).ToArray())
        End Function

        Private Shared Function IsWhiteSpace(ӓ As Char) As Boolean
            Return Not Char.IsWhiteSpace(ӓ)
        End Function

        Private Function GetPinvokeList() As List(Of Object)
            Return New List(Of Object)() From {Pinvoke.Info.advapi32.AbortSystemShutdown,
                Pinvoke.Info.avifil32.AVIFileCreateStream,
                Pinvoke.Info.cards.CardsWrappe,
                Pinvoke.Info.cfgmgr32.CM_Enumerate_Classes,
                Pinvoke.Info.comctl32.CreatePropertySheetPage,
                Pinvoke.Info.comdlg32.ChooseFont,
                Pinvoke.Info.credui.CredPackAuthenticationBuffer,
                Pinvoke.Info.crypt32.CertAddEncodedCertificateToStore,
                Pinvoke.Info.dbghelp.dll_MiniDumpWriteDump,
                Pinvoke.Info.dbghlp.none,
                Pinvoke.Info.dbghlp32.UnDecorateSymbolName,
                Pinvoke.Info.dhcpsapi.DATE_TIME,
                Pinvoke.Info.difxapi.DIFLOGCALLBACK,
                Pinvoke.Info.dmcl40.dmAPIDeInit,
                Pinvoke.Info.dnsapi.DnsFlushResolverCache,
                Pinvoke.Info.dtl.DTL_C_DEFINE,
                Pinvoke.Info.dwmapi.DwmDefWindowProc,
                Pinvoke.Info.faultrep.AddERExcludedApplication,
                Pinvoke.Info.fbwflib.FbwfAddExclusion,
                Pinvoke.Info.fltlib.FilterLoad,
                Pinvoke.Info.fwpuclnt.None,
                Pinvoke.Info.gdi32.AbortDoc,
                Pinvoke.Info.gdiplus.GdipAddPathArc,
                Pinvoke.Info.getuname.GetUName,
                Pinvoke.Info.glu32.gluDeleteQuadric,
                Pinvoke.Info.glut32.None,
                Pinvoke.Info.gsapi.gsapi_delete_instance,
                Pinvoke.Info.hhctrl.HtmlHelp,
                Pinvoke.Info.hid.HIDD_ATTRIBUTES,
                Pinvoke.Info.hlink.None,
                Pinvoke.Info.httpapi.HttpDeleteServiceConfiguration,
                Pinvoke.Info.icmp.IcmpCloseHandle,
                Pinvoke.Info.imm32.ImmConfigureIME,
                Pinvoke.Info.iphlpapi.AddIPAddress,
                Pinvoke.Info.iprop.PropVariantClear,
                Pinvoke.Info.irprops.BluetoothAuthenticateDevice,
                Pinvoke.Info.kernel32.ActivateActCtx,
                Pinvoke.Info.mapi32.HrGetAutoDiscoverXML,
                Pinvoke.Info.MinCore.GetFileVersionInfoSize,
                Pinvoke.Info.mpr.DllImport,
                Pinvoke.Info.mqrt.MQGetQueueSecurity,
                Pinvoke.Info.mscorsn.GetPermissionRequests,
                Pinvoke.Info.msdelta.ApplyDeltaW,
                Pinvoke.Info.msdrm.DRMCreateClientSession,
                Pinvoke.Info.msi.INSTALLLOGATTRIBUTES,
                Pinvoke.Info.msports.ComDBClaimNextFreePort,
                Pinvoke.Info.msvcrt.fclose,
                Pinvoke.Info.ncrypt.NCryptCreatePersistedKey,
                Pinvoke.Info.netapi32.DsAddressToSiteNames,
                Pinvoke.Info.ntdll.IsProcessCritical,
                Pinvoke.Info.ntdsapi.DsBind,
                Pinvoke.Info.odbc32.penis,
                Pinvoke.Info.odbccp32.DataSources,
                Pinvoke.Info.ole32.BindMoniker,
                Pinvoke.Info.oleacc.AccessibleChildren,
                Pinvoke.Info.oleaut32.GetActiveObject,
                Pinvoke.Info.opengl32.OpenGL,
                Pinvoke.Info.pdh.PdhLookupPerfNameByIndex,
                Pinvoke.Info.powrprof.CallNtPowerInformation,
                Pinvoke.Info.printui.PrintUIEntryW,
                Pinvoke.Info.propsys.PSGetItemPropertyHandler,
                Pinvoke.Info.psapi.EmptyWorkingSet,
                Pinvoke.Info.pstorec.PStoreCreateInstance,
                Pinvoke.Info.query.LoadIFilter,
                Pinvoke.Info.quickusb.Close,
                Pinvoke.Info.rasapi32.RasDial,
                Pinvoke.Info.rpcrt4.UuidCreate,
                Pinvoke.Info.scarddlg.None,
                Pinvoke.Info.secur32.AcceptSecurityContext,
                Pinvoke.Info.setupapi.CM_Get_Child,
                Pinvoke.Info.shell32.api,
                Pinvoke.Info.shlwapi.AssocCreate,
                Pinvoke.Info.twain_32.DSMparent,
                Pinvoke.Info.unicows.None,
                Pinvoke.Info.urlmon.cointernetsetfactureenabled,
                Pinvoke.Info.user32.ActivateKeyboardLayout,
                Pinvoke.Info.userenv.CreateEnvironmentBlock,
                Pinvoke.Info.uxtheme.BeginBufferedAnimation,
                Pinvoke.Info.version.GetFileVersionInfoSize,
                Pinvoke.Info.wer.WerAddExcludedApplication,
                Pinvoke.Info.wevtapi.None,
                Pinvoke.Info.winfax.FaxAbort,
                Pinvoke.Info.winhttp.WinHttpAddRequestHeaders,
                Pinvoke.Info.wininet.DeleteUrlCacheEntry,
                Pinvoke.Info.winmm.LD83,
                Pinvoke.Info.winscard.ASCIIEncoding,
                Pinvoke.Info.winspool.AbortPrinter,
                Pinvoke.Info.wintrust.IsCatalogFile,
                Pinvoke.Info.winusb.WinUsb_Free,
                Pinvoke.Info.wlanapi.EapHostPeerInvokeConfigUI,
                Pinvoke.Info.ws2_32.accept,
                Pinvoke.Info.wtsapi32.addfunction,
                Pinvoke.Info.xolehlp.DtcGetTransactionManager,
                Pinvoke.Info.xpsprint.None}
        End Function

        Private Function EnumToList(ByVal EnumType As List(Of Object)) As List(Of String)
            Dim lista As List(Of String) = New List(Of String)()
            Dim num As Integer = 0
            Dim num2 As Integer = EnumType.Count - 1

            For Each TypeName As Object In EnumType
                Dim list2 As List(Of String) = [Enum].GetNames(TypeName.GetType).ToList()
                Try
                    For Each item As String In list2
                        lista.Add(item)
                    Next
                Catch ex As Exception

                End Try
            Next

            Return lista
        End Function

#End Region

#Region " Public Methods "

        Public Async Function ScanPinvokesAsync(ByVal FileBytes As Byte()) As Task(Of List(Of String))
            Return ScanPinvokes(FileBytes)
        End Function

        Public Async Function ScanPinvokesAsync(ByVal FilePath As String) As Task(Of List(Of String))
            Return ScanPinvokes(FilePath)
        End Function

        Public Function ScanPinvokes(ByVal FileBytes As Byte()) As List(Of String)
            Dim result As List(Of String)
            Dim FileHex As String = Core.Helper.Util.BytesToHex(FileBytes)
            Try

                Dim hexNames As String() = Array.ConvertAll(listEx.ToArray, Function(str) BitConverter.ToString(Encoding.Default.GetBytes(str)).Replace("-"c, " "c))

                Dim list2 As New List(Of String)


                For Each text2 As String In hexNames

                    Dim value As String = EX(text2)
                    Dim HexParsed As String = text2.Replace(" ", "")

                    If FileHex.Contains(HexParsed, StringComparison.OrdinalIgnoreCase) Then
                        list2.Add(value)
                    End If

                Next

                result = list2.Distinct().ToList()

            Catch ex As Exception
                result = Nothing
            End Try
            Return result
        End Function

        Public Function ScanPinvokes(ByVal FilePath As String) As List(Of String)
            Dim result As List(Of String)

            Dim FileHex As String = Core.Helper.Util.BytesToHex(IO.File.ReadAllBytes(FilePath))

            Try

                Dim hexNames As String() = Array.ConvertAll(listEx.ToArray, Function(str) BitConverter.ToString(Encoding.Default.GetBytes(str)).Replace("-"c, " "c))

                Dim list2 As New List(Of String)


                For Each text2 As String In hexNames

                    Dim value As String = EX(text2)
                    Dim HexParsed As String = text2.Replace(" ", "")

                    If FileHex.Contains(HexParsed, StringComparison.OrdinalIgnoreCase) Then
                        list2.Add(value)
                    End If

                Next

                result = list2.Distinct().ToList()

            Catch ex As Exception

                result = Nothing
            End Try
            Return result
        End Function

#End Region

    End Class

    Public Class Info

        Public Enum advapi32
            ' Token: 0x04000042 RID: 66
            AbortSystemShutdown
            ' Token: 0x04000043 RID: 67
            AccessCheck
            ' Token: 0x04000044 RID: 68
            AccessCheckAndAuditAlarm
            ' Token: 0x04000045 RID: 69
            AddAccessAllowedAce
            ' Token: 0x04000046 RID: 70
            AddAce
            ' Token: 0x04000047 RID: 71
            AdjustTokenPrivileges
            ' Token: 0x04000048 RID: 72
            AllocateAndInitializeSid
            ' Token: 0x04000049 RID: 73
            AuditEnumerateCategories
            ' Token: 0x0400004A RID: 74
            BackupEventLog
            ' Token: 0x0400004B RID: 75
            BuildExplicitAccessWithName
            ' Token: 0x0400004C RID: 76
            BuildTrusteeWithSid
            ' Token: 0x0400004D RID: 77
            CertSrvIsServerOnline
            ' Token: 0x0400004E RID: 78
            CERT_CREDENTIAL_INFO
            ' Token: 0x0400004F RID: 79
            ChangeServiceConfig
            ' Token: 0x04000050 RID: 80
            ChangeServiceConfig2
            ' Token: 0x04000051 RID: 81
            CheckTokenMembership
            ' Token: 0x04000052 RID: 82
            ClearEventLog
            ' Token: 0x04000053 RID: 83
            CloseEventLog
            ' Token: 0x04000054 RID: 84
            CloseServiceHandle
            ' Token: 0x04000055 RID: 85
            ControlService
            ' Token: 0x04000056 RID: 86
            ConvertSecurityDescriptorToStringSecurityDescriptor
            ' Token: 0x04000057 RID: 87
            ConvertSidToStringSid
            ' Token: 0x04000058 RID: 88
            ConvertStringSecurityDescriptorToSecurityDescriptor
            ' Token: 0x04000059 RID: 89
            ConvertStringSidToSid
            ' Token: 0x0400005A RID: 90
            CopySid
            ' Token: 0x0400005B RID: 91
            CreateProcessAsUser
            ' Token: 0x0400005C RID: 92
            CreateProcessWithLogonW
            ' Token: 0x0400005D RID: 93
            CreateService
            ' Token: 0x0400005E RID: 94
            CreateWellKnownSid
            ' Token: 0x0400005F RID: 95
            CREATE_PROCESS_FLAGS
            ' Token: 0x04000060 RID: 96
            CredDelete
            ' Token: 0x04000061 RID: 97
            CredFree
            ' Token: 0x04000062 RID: 98
            CredMarshalCredential
            ' Token: 0x04000063 RID: 99
            CredRead
            ' Token: 0x04000064 RID: 100
            CredWrite
            ' Token: 0x04000065 RID: 101
            CryptAcquireContext
            ' Token: 0x04000066 RID: 102
            CryptAcquireContextA
            ' Token: 0x04000067 RID: 103
            CryptCreateHash
            ' Token: 0x04000068 RID: 104
            CryptDecrypt
            ' Token: 0x04000069 RID: 105
            CryptDeriveKey
            ' Token: 0x0400006A RID: 106
            CryptDestroyHash
            ' Token: 0x0400006B RID: 107
            CryptDestroyKey
            ' Token: 0x0400006C RID: 108
            CryptDuplicateKey
            ' Token: 0x0400006D RID: 109
            CryptEncrypt
            ' Token: 0x0400006E RID: 110
            CryptEnumProviders
            ' Token: 0x0400006F RID: 111
            CryptEnumProviderTypes
            ' Token: 0x04000070 RID: 112
            CryptExportKey
            ' Token: 0x04000071 RID: 113
            CryptGenKey
            ' Token: 0x04000072 RID: 114
            CryptGenRandom
            ' Token: 0x04000073 RID: 115
            CryptGetDefaultProvider
            ' Token: 0x04000074 RID: 116
            CryptGetHashParam
            ' Token: 0x04000075 RID: 117
            CryptGetKeyParam
            ' Token: 0x04000076 RID: 118
            CryptGetProvParam
            ' Token: 0x04000077 RID: 119
            CryptGetUserKey
            ' Token: 0x04000078 RID: 120
            CryptHashData
            ' Token: 0x04000079 RID: 121
            CryptHashSessionKey
            ' Token: 0x0400007A RID: 122
            CryptImportKey
            ' Token: 0x0400007B RID: 123
            CryptReleaseContext
            ' Token: 0x0400007C RID: 124
            CryptSetKeyParam
            ' Token: 0x0400007D RID: 125
            CryptSetProvParam
            ' Token: 0x0400007E RID: 126
            CryptSignHash
            ' Token: 0x0400007F RID: 127
            CryptUninstallDefaultContextA
            ' Token: 0x04000080 RID: 128
            CryptVerifySignature
            ' Token: 0x04000081 RID: 129
            DefaultPassword
            ' Token: 0x04000082 RID: 130
            DeleteAce
            ' Token: 0x04000083 RID: 131
            DeleteService
            ' Token: 0x04000084 RID: 132
            DuplicateToken
            ' Token: 0x04000085 RID: 133
            DuplicateTokenEx
            ' Token: 0x04000086 RID: 134
            Encryptfile
            ' Token: 0x04000087 RID: 135
            EntryPoint
            ' Token: 0x04000088 RID: 136
            EnumDependentServices
            ' Token: 0x04000089 RID: 137
            EnumServicesStatus
            ' Token: 0x0400008A RID: 138
            EqualSid
            ' Token: 0x0400008B RID: 139
            ewqr
            ' Token: 0x0400008C RID: 140
            FreeSid
            ' Token: 0x0400008D RID: 141
            GetAce
            ' Token: 0x0400008E RID: 142
            GetAclInformation
            ' Token: 0x0400008F RID: 143
            GetCurrentHwProfile
            ' Token: 0x04000090 RID: 144
            GetEffectiveRightsFromAcl
            ' Token: 0x04000091 RID: 145
            GetExplicitEntriesFromAcl
            ' Token: 0x04000092 RID: 146
            GetLengthSid
            ' Token: 0x04000093 RID: 147
            GetNamedSecurityInfo
            ' Token: 0x04000094 RID: 148
            GetSecurityDescriptorLength
            ' Token: 0x04000095 RID: 149
            GetSecurityInfo
            ' Token: 0x04000096 RID: 150
            GetSidIdentifierAuthority
            ' Token: 0x04000097 RID: 151
            GetSidLengthRequired
            ' Token: 0x04000098 RID: 152
            GetSidSubAuthority
            ' Token: 0x04000099 RID: 153
            GetSidSubAuthorityCount
            ' Token: 0x0400009A RID: 154
            GetTokenInformation
            ' Token: 0x0400009B RID: 155
            GetTraceEnableFlags
            ' Token: 0x0400009C RID: 156
            GetTraceEnableLevel
            ' Token: 0x0400009D RID: 157
            GetUserName
            ' Token: 0x0400009E RID: 158
            HoldImpersonationCloak
            ' Token: 0x0400009F RID: 159
            ImpersonateLoggedOnUser
            ' Token: 0x040000A0 RID: 160
            InitializeAcl
            ' Token: 0x040000A1 RID: 161
            InitializeSecurityDescriptor
            ' Token: 0x040000A2 RID: 162
            InitializeSid
            ' Token: 0x040000A3 RID: 163
            InitiateShutdown
            ' Token: 0x040000A4 RID: 164
            InitiateSystemShutdown
            ' Token: 0x040000A5 RID: 165
            InitiateSystemShutdownEx
            ' Token: 0x040000A6 RID: 166
            IsTextUnicode
            ' Token: 0x040000A7 RID: 167
            IsValidSid
            ' Token: 0x040000A8 RID: 168
            LockServiceDatabase
            ' Token: 0x040000A9 RID: 169
            LogonUser
            ' Token: 0x040000AA RID: 170
            LogonUserA
            ' Token: 0x040000AB RID: 171
            LogonUserEx
            ' Token: 0x040000AC RID: 172
            LOGON_PROVIDER
            ' Token: 0x040000AD RID: 173
            LOGON_TYPE
            ' Token: 0x040000AE RID: 174
            lolilol
            ' Token: 0x040000AF RID: 175
            LookupAccountName
            ' Token: 0x040000B0 RID: 176
            LookupAccountSid
            ' Token: 0x040000B1 RID: 177
            LookupPrivilegeDisplayName
            ' Token: 0x040000B2 RID: 178
            LookupPrivilegeName
            ' Token: 0x040000B3 RID: 179
            LookupPrivilegeValue
            ' Token: 0x040000B4 RID: 180
            LsaAddAccountRights
            ' Token: 0x040000B5 RID: 181
            LsaClose
            ' Token: 0x040000B6 RID: 182
            LsaEnumerateAccountRights
            ' Token: 0x040000B7 RID: 183
            LsaEnumerateAccountsWithUserRight
            ' Token: 0x040000B8 RID: 184
            LsaFreeMemory
            ' Token: 0x040000B9 RID: 185
            LsaLookupSids
            ' Token: 0x040000BA RID: 186
            LsaNtStatusToWinError
            ' Token: 0x040000BB RID: 187
            LsaOpenPolicy
            ' Token: 0x040000BC RID: 188
            LsaRemoveAccountRights
            ' Token: 0x040000BD RID: 189
            LSARetrievePrivateData
            ' Token: 0x040000BE RID: 190
            LsaStorePrivateData
            ' Token: 0x040000BF RID: 191
            MachineName
            ' Token: 0x040000C0 RID: 192
            MapGenericMask
            ' Token: 0x040000C1 RID: 193
            NetValidatePasswordPolicy
            ' Token: 0x040000C2 RID: 194
            NotifyServiceStatusChange
            ' Token: 0x040000C3 RID: 195
            OpenBackupEventLog
            ' Token: 0x040000C4 RID: 196
            OpenEventLog
            ' Token: 0x040000C5 RID: 197
            OpenProcessToken
            ' Token: 0x040000C6 RID: 198
            OpenSCManager
            ' Token: 0x040000C7 RID: 199
            OpenService
            ' Token: 0x040000C8 RID: 200
            OpenThreadToken
            ' Token: 0x040000C9 RID: 201
            OpenTrace
            ' Token: 0x040000CA RID: 202
            pcap_lookupdev
            ' Token: 0x040000CB RID: 203
            PrivilegeNames
            ' Token: 0x040000CC RID: 204
            PROV_ENUMALGS_EX
            ' Token: 0x040000CD RID: 205
            QueryServiceConfig
            ' Token: 0x040000CE RID: 206
            QueryServiceConfig2
            ' Token: 0x040000CF RID: 207
            QueryServiceObjectSecurity
            ' Token: 0x040000D0 RID: 208
            QueryServiceStatus
            ' Token: 0x040000D1 RID: 209
            QueryServiceStatusEx
            ' Token: 0x040000D2 RID: 210
            ReadEventLog
            ' Token: 0x040000D3 RID: 211
            RegCloseKey
            ' Token: 0x040000D4 RID: 212
            RegConnectRegistry
            ' Token: 0x040000D5 RID: 213
            RegCopyTree
            ' Token: 0x040000D6 RID: 214
            RegCreateKeyA
            ' Token: 0x040000D7 RID: 215
            RegCreateKeyEx
            ' Token: 0x040000D8 RID: 216
            RegDeleteKey
            ' Token: 0x040000D9 RID: 217
            RegDeleteKeyA
            ' Token: 0x040000DA RID: 218
            RegDeleteKeyEx
            ' Token: 0x040000DB RID: 219
            RegDeleteTree
            ' Token: 0x040000DC RID: 220
            RegDisableReflectionKey
            ' Token: 0x040000DD RID: 221
            RegEnableReflectionKey
            ' Token: 0x040000DE RID: 222
            RegEnumKeyEx
            ' Token: 0x040000DF RID: 223
            RegEnumKeyExA
            ' Token: 0x040000E0 RID: 224
            RegEnumValue
            ' Token: 0x040000E1 RID: 225
            RegGetKeySecurity
            ' Token: 0x040000E2 RID: 226
            RegGetValue
            ' Token: 0x040000E3 RID: 227
            RegisterTraceGuids
            ' Token: 0x040000E4 RID: 228
            RegistryChangeMonitor
            ' Token: 0x040000E5 RID: 229
            RegLoadKey
            ' Token: 0x040000E6 RID: 230
            RegNotifyChangeKeyValue
            ' Token: 0x040000E7 RID: 231
            RegOpenKey
            ' Token: 0x040000E8 RID: 232
            RegOpenKeyEx
            ' Token: 0x040000E9 RID: 233
            RegOverridePredefKey
            ' Token: 0x040000EA RID: 234
            RegQueryInfoKey
            ' Token: 0x040000EB RID: 235
            RegQueryValue
            ' Token: 0x040000EC RID: 236
            RegQueryValueEx
            ' Token: 0x040000ED RID: 237
            RegSetKeySecurity
            ' Token: 0x040000EE RID: 238
            RegSetValueEx
            ' Token: 0x040000EF RID: 239
            RegUnLoadKey
            ' Token: 0x040000F0 RID: 240
            ReleasePowerRequirement
            ' Token: 0x040000F1 RID: 241
            ReportEvent
            ' Token: 0x040000F2 RID: 242
            RevertToSelf
            ' Token: 0x040000F3 RID: 243
            SaferCloseLevel
            ' Token: 0x040000F4 RID: 244
            SaferComputeTokenFromLevel
            ' Token: 0x040000F5 RID: 245
            SaferCreateLevel
            ' Token: 0x040000F6 RID: 246
            SaferiIsExecutableFileType
            ' Token: 0x040000F7 RID: 247
            SC_ACTION
            ' Token: 0x040000F8 RID: 248
            SECURITY_IMPERSONATION_LEVEL
            ' Token: 0x040000F9 RID: 249
            SERVICE_FAILURE_ACTIONS
            ' Token: 0x040000FA RID: 250
            SERVICE_STATUS_PROCESS
            ' Token: 0x040000FB RID: 251
            SetEntriesInAcl
            ' Token: 0x040000FC RID: 252
            SetFileSecurity
            ' Token: 0x040000FD RID: 253
            SetNamedSecurityInfo
            ' Token: 0x040000FE RID: 254
            SetPowerRequirement
            ' Token: 0x040000FF RID: 255
            SetSecurityDescriptorDacl
            ' Token: 0x04000100 RID: 256
            SetServiceObjectSecurity
            ' Token: 0x04000101 RID: 257
            SetTokenInformation
            ' Token: 0x04000102 RID: 258
            ShutDown
            ' Token: 0x04000103 RID: 259
            StartService
            ' Token: 0x04000104 RID: 260
            SymCleanup
            ' Token: 0x04000105 RID: 261
            SymmetricAlgorithm
            ' Token: 0x04000106 RID: 262
            TraceEvent
            ' Token: 0x04000107 RID: 263
            TreeSetNamedSecurityInfo
            ' Token: 0x04000108 RID: 264
            UnregisterTraceGuids
            ' Token: 0x04000109 RID: 265
            UserID
            ' Token: 0x0400010A RID: 266
            V0guy
            ' Token: 0x0400010B RID: 267
            Windows0Services
            ' Token: 0x0400010C RID: 268
            Windows
            ' Token: 0x0400010D RID: 269
            WNetGetUniversalName
        End Enum

        ' Token: 0x02000018 RID: 24
        Public Enum avifil32
            ' Token: 0x0400010F RID: 271
            AVIFileCreateStream
            ' Token: 0x04000110 RID: 272
            AVIFileExit
            ' Token: 0x04000111 RID: 273
            AVIFileInit
            ' Token: 0x04000112 RID: 274
            AVIFileOpen
            ' Token: 0x04000113 RID: 275
            AVIFileOpenW
            ' Token: 0x04000114 RID: 276
            AVIFileRelease
            ' Token: 0x04000115 RID: 277
            AVIGetStreamInfo
            ' Token: 0x04000116 RID: 278
            AVIInfo
            ' Token: 0x04000117 RID: 279
            AVIStreamExit
            ' Token: 0x04000118 RID: 280
            AVIStreamGetFrameOpen
            ' Token: 0x04000119 RID: 281
            AVIStreamLength
            ' Token: 0x0400011A RID: 282
            AVIStreamRead
            ' Token: 0x0400011B RID: 283
            AVIStreamReadFormat
            ' Token: 0x0400011C RID: 284
            AVIStreamRelease
            ' Token: 0x0400011D RID: 285
            BluetoothFindFirstRadio
            ' Token: 0x0400011E RID: 286
            BluetoothFindRadioClose
            ' Token: 0x0400011F RID: 287
            BluetoothGetRadioInfo
            ' Token: 0x04000120 RID: 288
            Mierda
        End Enum

        ' Token: 0x02000019 RID: 25
        Public Enum cards
            ' Token: 0x04000122 RID: 290
            CardsWrappe
            ' Token: 0x04000123 RID: 291
            CardsWrapper
            ' Token: 0x04000124 RID: 292
            cdtAnimate
            ' Token: 0x04000125 RID: 293
            cdtDraw
            ' Token: 0x04000126 RID: 294
            cdtDrawExt
            ' Token: 0x04000127 RID: 295
            cdtInit
            ' Token: 0x04000128 RID: 296
            cdtTerm
            ' Token: 0x04000129 RID: 297
            DlgTemplate
        End Enum

        ' Token: 0x0200001A RID: 26
        Public Enum cfgmgr32
            ' Token: 0x0400012B RID: 299
            CM_Enumerate_Classes
            ' Token: 0x0400012C RID: 300
            CM_Get_Device_ID_List
            ' Token: 0x0400012D RID: 301
            CM_Get_Device_ID_List_Size
            ' Token: 0x0400012E RID: 302
            CM_Get_Device_Interface_List
            ' Token: 0x0400012F RID: 303
            CM_Get_Device_Interface_List_Size
            ' Token: 0x04000130 RID: 304
            CM_Get_DevNode_Property
            ' Token: 0x04000131 RID: 305
            CM_Open_DevNode_Key
            ' Token: 0x04000132 RID: 306
            CM_Query_And_Remove_SubTree_Ex
            ' Token: 0x04000133 RID: 307
            CM_Request_Eject_PC
            ' Token: 0x04000134 RID: 308
            CM_Setup_DevNode
        End Enum

        ' Token: 0x0200001B RID: 27
        Public Enum comctl32
            ' Token: 0x04000136 RID: 310
            CreatePropertySheetPage
            ' Token: 0x04000137 RID: 311
            DestroyPropertySheetPage
            ' Token: 0x04000138 RID: 312
            DoReaderMode
            ' Token: 0x04000139 RID: 313
            ImageList_Add
            ' Token: 0x0400013A RID: 314
            ImageList_AddIcon
            ' Token: 0x0400013B RID: 315
            ImageList_AddMasked
            ' Token: 0x0400013C RID: 316
            ImageList_BeginDrag
            ' Token: 0x0400013D RID: 317
            ImageList_Create
            ' Token: 0x0400013E RID: 318
            ImageList_DragEnter
            ' Token: 0x0400013F RID: 319
            ImageList_DragLeave
            ' Token: 0x04000140 RID: 320
            ImageList_DragMove
            ' Token: 0x04000141 RID: 321
            ImageList_DragShowNolock
            ' Token: 0x04000142 RID: 322
            ImageList_DrawEx
            ' Token: 0x04000143 RID: 323
            ImageList_Duplicate
            ' Token: 0x04000144 RID: 324
            ImageList_EndDrag
            ' Token: 0x04000145 RID: 325
            ImageList_GetIcon
            ' Token: 0x04000146 RID: 326
            ImageList_GetIconSize
            ' Token: 0x04000147 RID: 327
            ImageList_SetIconSize
            ' Token: 0x04000148 RID: 328
            ImageList_SetOverlayImage
            ' Token: 0x04000149 RID: 329
            InitCommonControlsEx
            ' Token: 0x0400014A RID: 330
            TaskDialog
            ' Token: 0x0400014B RID: 331
            TaskDialogIndirect
            ' Token: 0x0400014C RID: 332
            WindowsAPICodePack
        End Enum

        ' Token: 0x0200001C RID: 28
        Public Enum comdlg32
            ' Token: 0x0400014E RID: 334
            ChooseFont
            ' Token: 0x0400014F RID: 335
            CommDlgExtendedError
            ' Token: 0x04000150 RID: 336
            FtpCommand
            ' Token: 0x04000151 RID: 337
            GetOpenFileName
            ' Token: 0x04000152 RID: 338
            GetSaveFileName
            ' Token: 0x04000153 RID: 339
            NetShareAdd
            ' Token: 0x04000154 RID: 340
            PageSetupDlg
            ' Token: 0x04000155 RID: 341
            PrintDlg
            ' Token: 0x04000156 RID: 342
            PrintDlgEx
            ' Token: 0x04000157 RID: 343
            QueryPathOfRegTypeLib
        End Enum

        ' Token: 0x0200001D RID: 29
        Public Enum credui
            ' Token: 0x04000159 RID: 345
            CredPackAuthenticationBuffer
            ' Token: 0x0400015A RID: 346
            CredUIConfirmCredentials
            ' Token: 0x0400015B RID: 347
            CredUIParseUserName
            ' Token: 0x0400015C RID: 348
            CredUIPromptForCredentials
            ' Token: 0x0400015D RID: 349
            CredUIPromptForCredentialsW
            ' Token: 0x0400015E RID: 350
            CredUIPromptForWindowsCredentials
            ' Token: 0x0400015F RID: 351
            CredUnPackAuthenticationBuffer
        End Enum

        ' Token: 0x0200001E RID: 30
        Public Enum crypt32
            ' Token: 0x04000161 RID: 353
            CertAddEncodedCertificateToStore
            ' Token: 0x04000162 RID: 354
            CertAlgIdToOID
            ' Token: 0x04000163 RID: 355
            CertCloseStore
            ' Token: 0x04000164 RID: 356
            CertCreateCertificateContext
            ' Token: 0x04000165 RID: 357
            CertCreateCRLContext
            ' Token: 0x04000166 RID: 358
            CertCreateCTLContext
            ' Token: 0x04000167 RID: 359
            CertDuplicateStore
            ' Token: 0x04000168 RID: 360
            CertEnumCertificatesInStore
            ' Token: 0x04000169 RID: 361
            CertFindCertificateInCRL
            ' Token: 0x0400016A RID: 362
            CertFindCertificateInStore
            ' Token: 0x0400016B RID: 363
            CertFreeCertificateContext
            ' Token: 0x0400016C RID: 364
            CertFreeCRLContext
            ' Token: 0x0400016D RID: 365
            CertFreeCTLContext
            ' Token: 0x0400016E RID: 366
            CertGetNameString
            ' Token: 0x0400016F RID: 367
            CertNameToStr
            ' Token: 0x04000170 RID: 368
            CertOpenStore
            ' Token: 0x04000171 RID: 369
            CertOpenSystemStore
            ' Token: 0x04000172 RID: 370
            CertStrToName
            ' Token: 0x04000173 RID: 371
            CertVerifyCRLRevocation
            ' Token: 0x04000174 RID: 372
            CertVerifyRevocation
            ' Token: 0x04000175 RID: 373
            CMSG_SIGNED_ENCODE_INFO
            ' Token: 0x04000176 RID: 374
            CryptAcquireCertificatePrivateKey
            ' Token: 0x04000177 RID: 375
            CryptDecodeObject
            ' Token: 0x04000178 RID: 376
            CryptDecodeObjectEx
            ' Token: 0x04000179 RID: 377
            CryptDecryptMessage
            ' Token: 0x0400017A RID: 378
            CryptEncodeObject
            ' Token: 0x0400017B RID: 379
            CryptEncryptMessage
            ' Token: 0x0400017C RID: 380
            CryptFindOIDInfo
            ' Token: 0x0400017D RID: 381
            CryptHashPublicKeyInfo
            ' Token: 0x0400017E RID: 382
            CryptMsgClose
            ' Token: 0x0400017F RID: 383
            CryptMsgGetParam
            ' Token: 0x04000180 RID: 384
            CryptMsgOpenToDecode
            ' Token: 0x04000181 RID: 385
            CryptMsgOpenToEncode
            ' Token: 0x04000182 RID: 386
            CryptMsgUpdate
            ' Token: 0x04000183 RID: 387
            CryptoAPI
            ' Token: 0x04000184 RID: 388
            CryptProtectData
            ' Token: 0x04000185 RID: 389
            CryptQueryObject
            ' Token: 0x04000186 RID: 390
            CryptSignAndEncryptMessage
            ' Token: 0x04000187 RID: 391
            CryptStringToBinary
            ' Token: 0x04000188 RID: 392
            CryptUnprotectData
            ' Token: 0x04000189 RID: 393
            CryptVerifyDetachedMessageSignature
            ' Token: 0x0400018A RID: 394
            CryptVerifyMessageSignature
            ' Token: 0x0400018B RID: 395
            CRYPT_DATA_BLOB
            ' Token: 0x0400018C RID: 396
            CTL_CONTEXT
            ' Token: 0x0400018D RID: 397
            CTL_INFO
            ' Token: 0x0400018E RID: 398
            PFXImportCertStore
            ' Token: 0x0400018F RID: 399
            PFXIsPFXBlob
        End Enum

        ' Token: 0x0200001F RID: 31
        Public Enum dbghelp
            ' Token: 0x04000191 RID: 401
            dll_MiniDumpWriteDump
            ' Token: 0x04000192 RID: 402
            MiniDumpWriteDump
        End Enum

        ' Token: 0x02000020 RID: 32
        Public Enum dbghlp
            ' Token: 0x04000194 RID: 404
            none
        End Enum

        ' Token: 0x02000021 RID: 33
        Public Enum dbghlp32
            ' Token: 0x04000196 RID: 406
            UnDecorateSymbolName
        End Enum

        ' Token: 0x02000022 RID: 34
        Public Enum dhcpsapi
            ' Token: 0x04000198 RID: 408
            DATE_TIME
            ' Token: 0x04000199 RID: 409
            DhcpAddSubnetElementV5
            ' Token: 0x0400019A RID: 410
            DhcpDeleteClientInfo
            ' Token: 0x0400019B RID: 411
            DhcpEnumServers
            ' Token: 0x0400019C RID: 412
            DhcpEnumSubnetClients
            ' Token: 0x0400019D RID: 413
            DhcpEnumSubnetElementsV5
            ' Token: 0x0400019E RID: 414
            DhcpEnumSubnets
            ' Token: 0x0400019F RID: 415
            DhcpGetClientInfo
            ' Token: 0x040001A0 RID: 416
            DhcpGetVersion
            ' Token: 0x040001A1 RID: 417
            DhcpRemoveSubnetElementV5
            ' Token: 0x040001A2 RID: 418
            DhcpRpcFreeMemory
            ' Token: 0x040001A3 RID: 419
            DHCP_BINARY_DATA
            ' Token: 0x040001A4 RID: 420
            DHCP_CLIENT_INFO
            ' Token: 0x040001A5 RID: 421
            DHCP_CLIENT_SEARCH_IP_ADDRESS
            ' Token: 0x040001A6 RID: 422
            DHCP_SEARCH_INFO
        End Enum

        ' Token: 0x02000023 RID: 35
        Public Enum difxapi
            ' Token: 0x040001A8 RID: 424
            DIFLOGCALLBACK
            ' Token: 0x040001A9 RID: 425
            DIFXAPILOGCALLBACK
            ' Token: 0x040001AA RID: 426
            DIFXAPISetLogCallback
            ' Token: 0x040001AB RID: 427
            DriverPackageGetPath
            ' Token: 0x040001AC RID: 428
            DriverPackageInstall
            ' Token: 0x040001AD RID: 429
            DriverPackagePreinstall
            ' Token: 0x040001AE RID: 430
            DriverPackageUninstall
            ' Token: 0x040001AF RID: 431
            DriverStore
            ' Token: 0x040001B0 RID: 432
            SetDifxLogCallback
        End Enum

        ' Token: 0x02000024 RID: 36
        Public Enum dmcl40
            ' Token: 0x040001B2 RID: 434
            dmAPIDeInit
            ' Token: 0x040001B3 RID: 435
            dmAPIExec
            ' Token: 0x040001B4 RID: 436
            dmAPIGet
            ' Token: 0x040001B5 RID: 437
            dmAPIInit
        End Enum

        ' Token: 0x02000025 RID: 37
        Public Enum dnsapi
            ' Token: 0x040001B7 RID: 439
            DnsFlushResolverCache
            ' Token: 0x040001B8 RID: 440
            DnsFlushResolverCacheEntry
            ' Token: 0x040001B9 RID: 441
            DnsQuery
            ' Token: 0x040001BA RID: 442
            DnsQueryEx
        End Enum

        ' Token: 0x02000026 RID: 38
        Public Enum dtl
            ' Token: 0x040001BC RID: 444
            DTL_C_DEFINE
            ' Token: 0x040001BD RID: 445
            DTL_DRIVER_CLOSE
            ' Token: 0x040001BE RID: 446
            DTL_DRIVER_OPEN
            ' Token: 0x040001BF RID: 447
            DTL_ERROR_S
            ' Token: 0x040001C0 RID: 448
            DTL_INIT
            ' Token: 0x040001C1 RID: 449
            DTL_READ_W
            ' Token: 0x040001C2 RID: 450
            DTL_UNDEF
            ' Token: 0x040001C3 RID: 451
            DTL_UNINIT
            ' Token: 0x040001C4 RID: 452
            DTL_VERSION
            ' Token: 0x040001C5 RID: 453
            DTL_WRITE_W
        End Enum

        ' Token: 0x02000027 RID: 39
        Public Enum dwmapi
            ' Token: 0x040001C7 RID: 455
            DwmDefWindowProc
            ' Token: 0x040001C8 RID: 456
            DwmEnableBlurBehindWindow
            ' Token: 0x040001C9 RID: 457
            DwmEnableComposition
            ' Token: 0x040001CA RID: 458
            DwmExtendFrameIntoClientArea
            ' Token: 0x040001CB RID: 459
            DwmGetColorizationColor
            ' Token: 0x040001CC RID: 460
            DwmGetColorizationParameters
            ' Token: 0x040001CD RID: 461
            DwmGetCompositionTimingInfo
            ' Token: 0x040001CE RID: 462
            DwmGetWindowAttribute
            ' Token: 0x040001CF RID: 463
            DwmIsCompositionEnabled
            ' Token: 0x040001D0 RID: 464
            DwmpSetColorization
            ' Token: 0x040001D1 RID: 465
            DwmQueryThumbnailSourceSize
            ' Token: 0x040001D2 RID: 466
            DwmRegisterThumbnail
            ' Token: 0x040001D3 RID: 467
            DwmSetColorizationParameters
            ' Token: 0x040001D4 RID: 468
            DwmUnregisterThumbnail
            ' Token: 0x040001D5 RID: 469
            DwmUpdateThumbnailProperties
            ' Token: 0x040001D6 RID: 470
            TaskDialog
            ' Token: 0x040001D7 RID: 471
            VistaBridge
        End Enum

        ' Token: 0x02000028 RID: 40
        Public Enum faultrep
            ' Token: 0x040001D9 RID: 473
            AddERExcludedApplication
            ' Token: 0x040001DA RID: 474
            ReportFault
        End Enum

        ' Token: 0x02000029 RID: 41
        Public Enum fbwflib
            ' Token: 0x040001DC RID: 476
            FbwfAddExclusion
            ' Token: 0x040001DD RID: 477
            FbwfCacheThresholdNotification
            ' Token: 0x040001DE RID: 478
            FbwfDisableCompression
            ' Token: 0x040001DF RID: 479
            FbwfDisableFilter
            ' Token: 0x040001E0 RID: 480
            FbwfEnableCompression
            ' Token: 0x040001E1 RID: 481
            FbwfEnableFilter
            ' Token: 0x040001E2 RID: 482
            FbwfGetExclusionList
            ' Token: 0x040001E3 RID: 483
            FbwfGetMemoryUsage
            ' Token: 0x040001E4 RID: 484
            FbwfGetVolumeList
            ' Token: 0x040001E5 RID: 485
            FbwfIsFilterEnabled
            ' Token: 0x040001E6 RID: 486
            FbwfMemoryUsage
            ' Token: 0x040001E7 RID: 487
            FbwfProtectVolume
            ' Token: 0x040001E8 RID: 488
            FbwfRemoveExclusion
            ' Token: 0x040001E9 RID: 489
            FbwfSetCacheThreshold
            ' Token: 0x040001EA RID: 490
            FbwfUnprotectVolume
        End Enum

        ' Token: 0x0200002A RID: 42
        Public Enum fltlib
            ' Token: 0x040001EC RID: 492
            FilterLoad
        End Enum

        ' Token: 0x0200002B RID: 43
        Public Enum fwpuclnt
            ' Token: 0x040001EE RID: 494
            None
        End Enum

        ' Token: 0x0200002C RID: 44
        Public Enum gdi32
            ' Token: 0x040001F0 RID: 496
            AbortDoc
            ' Token: 0x040001F1 RID: 497
            AbortPath
            ' Token: 0x040001F2 RID: 498
            AddFontMemResourceEx
            ' Token: 0x040001F3 RID: 499
            AddFontResource
            ' Token: 0x040001F4 RID: 500
            AlphaBlend
            ' Token: 0x040001F5 RID: 501
            AngleArc
            ' Token: 0x040001F6 RID: 502
            AnimatePalette
            ' Token: 0x040001F7 RID: 503
            Arc
            ' Token: 0x040001F8 RID: 504
            ArcTo
            ' Token: 0x040001F9 RID: 505
            BeginPath
            ' Token: 0x040001FA RID: 506
            BitBlt
            ' Token: 0x040001FB RID: 507
            CancelDC
            ' Token: 0x040001FC RID: 508
            CheckColorsInGamut
            ' Token: 0x040001FD RID: 509
            ChoosePixelFormat
            ' Token: 0x040001FE RID: 510
            Chord
            ' Token: 0x040001FF RID: 511
            CloseEnhMetaFile
            ' Token: 0x04000200 RID: 512
            CloseFigure
            ' Token: 0x04000201 RID: 513
            CloseMetaFile
            ' Token: 0x04000202 RID: 514
            ColorCorrectPalette
            ' Token: 0x04000203 RID: 515
            CombineRgn
            ' Token: 0x04000204 RID: 516
            CopyEnhMetaFile
            ' Token: 0x04000205 RID: 517
            CopyMetaFile
            ' Token: 0x04000206 RID: 518
            CreateBitmap
            ' Token: 0x04000207 RID: 519
            CreateBrushIndirect
            ' Token: 0x04000208 RID: 520
            CreateCompatibleBitmap
            ' Token: 0x04000209 RID: 521
            CreateCompatibleDC
            ' Token: 0x0400020A RID: 522
            CreateDC
            ' Token: 0x0400020B RID: 523
            CreateDIBitmap
            ' Token: 0x0400020C RID: 524
            CreateDIBSection
            ' Token: 0x0400020D RID: 525
            CreateEllipticRgn
            ' Token: 0x0400020E RID: 526
            CreateFont
            ' Token: 0x0400020F RID: 527
            CreateFontIndirect
            ' Token: 0x04000210 RID: 528
            CreateIC
            ' Token: 0x04000211 RID: 529
            CreatePalette
            ' Token: 0x04000212 RID: 530
            CreatePatternBrush
            ' Token: 0x04000213 RID: 531
            CreatePen
            ' Token: 0x04000214 RID: 532
            CreatePolygonRgn
            ' Token: 0x04000215 RID: 533
            CreatePolyPolygonRgn
            ' Token: 0x04000216 RID: 534
            CreateRectRgn
            ' Token: 0x04000217 RID: 535
            CreateRoundRectRgn
            ' Token: 0x04000218 RID: 536
            CreateScalableFontResource
            ' Token: 0x04000219 RID: 537
            CreateSolidBrush
            ' Token: 0x0400021A RID: 538
            DeleteDC
            ' Token: 0x0400021B RID: 539
            DeleteEnhMetaFile
            ' Token: 0x0400021C RID: 540
            DeleteMetaFile
            ' Token: 0x0400021D RID: 541
            DeleteObject
            ' Token: 0x0400021E RID: 542
            DeviceContext
            ' Token: 0x0400021F RID: 543
            DPtoLP
            ' Token: 0x04000220 RID: 544
            DrawArc
            ' Token: 0x04000221 RID: 545
            Ellipse
            ' Token: 0x04000222 RID: 546
            EndDoc
            ' Token: 0x04000223 RID: 547
            EnumFontFamilies
            ' Token: 0x04000224 RID: 548
            EnumFontFamiliesEx
            ' Token: 0x04000225 RID: 549
            EnumFonts
            ' Token: 0x04000226 RID: 550
            EnumObjects
            ' Token: 0x04000227 RID: 551
            Escape
            ' Token: 0x04000228 RID: 552
            ExtCreatePen
            ' Token: 0x04000229 RID: 553
            ExtEscape
            ' Token: 0x0400022A RID: 554
            ExtFloodFill
            ' Token: 0x0400022B RID: 555
            ExtTextOut
            ' Token: 0x0400022C RID: 556
            FillRgn
            ' Token: 0x0400022D RID: 557
            FloodFill
            ' Token: 0x0400022E RID: 558
            gdi32
            ' Token: 0x0400022F RID: 559
            GdipLoadImage
            ' Token: 0x04000230 RID: 560
            GetBkColor
            ' Token: 0x04000231 RID: 561
            GetBkMode
            ' Token: 0x04000232 RID: 562
            GetBrushOrgEx
            ' Token: 0x04000233 RID: 563
            GetCharABCWidths
            ' Token: 0x04000234 RID: 564
            GetCharABCWidthsFloat
            ' Token: 0x04000235 RID: 565
            GetCharacterPlacement
            ' Token: 0x04000236 RID: 566
            GetCharWidth
            ' Token: 0x04000237 RID: 567
            GetClipBox
            ' Token: 0x04000238 RID: 568
            GetClipRgn
            ' Token: 0x04000239 RID: 569
            GetCurrentObject
            ' Token: 0x0400023A RID: 570
            GetCurrentPositionEx
            ' Token: 0x0400023B RID: 571
            GetDC
            ' Token: 0x0400023C RID: 572
            GetDCBrushColor
            ' Token: 0x0400023D RID: 573
            GetDeviceCaps
            ' Token: 0x0400023E RID: 574
            GetDeviceGammaRamp
            ' Token: 0x0400023F RID: 575
            GetDIBits
            ' Token: 0x04000240 RID: 576
            GetEnhMetaFile
            ' Token: 0x04000241 RID: 577
            GetEnhMetaFileBits
            ' Token: 0x04000242 RID: 578
            GetFontData
            ' Token: 0x04000243 RID: 579
            GetFontUnicodeRanges
            ' Token: 0x04000244 RID: 580
            GetGlyphOutline
            ' Token: 0x04000245 RID: 581
            GetKerningPairs
            ' Token: 0x04000246 RID: 582
            GetObject
            ' Token: 0x04000247 RID: 583
            GetOutlineTextMetrics
            ' Token: 0x04000248 RID: 584
            GetPath
            ' Token: 0x04000249 RID: 585
            GetPixel
            ' Token: 0x0400024A RID: 586
            GetRegionData
            ' Token: 0x0400024B RID: 587
            GetStockObject
            ' Token: 0x0400024C RID: 588
            GetTextCharset
            ' Token: 0x0400024D RID: 589
            GetTextColor
            ' Token: 0x0400024E RID: 590
            GetTextExtentExPoint
            ' Token: 0x0400024F RID: 591
            GetTextExtentPoint
            ' Token: 0x04000250 RID: 592
            GetTextExtentPoint32
            ' Token: 0x04000251 RID: 593
            GetTextMetrics
            ' Token: 0x04000252 RID: 594
            GetViewportExtEx
            ' Token: 0x04000253 RID: 595
            GetViewportOrgEx
            ' Token: 0x04000254 RID: 596
            GetWindowExtEx
            ' Token: 0x04000255 RID: 597
            GetWindowOrgEx
            ' Token: 0x04000256 RID: 598
            GetWinMetaFileBits
            ' Token: 0x04000257 RID: 599
            GetWorldTransform
            ' Token: 0x04000258 RID: 600
            gluErrorString
            ' Token: 0x04000259 RID: 601
            GM_
            ' Token: 0x0400025A RID: 602
            GradientFill
            ' Token: 0x0400025B RID: 603
            HBitmap
            ' Token: 0x0400025C RID: 604
            DrawEscape
            ' Token: 0x0400025D RID: 605
            LineDDA
            ' Token: 0x0400025E RID: 606
            LineTo
            ' Token: 0x0400025F RID: 607
            LPtoDP
            ' Token: 0x04000260 RID: 608
            MapModes
            ' Token: 0x04000261 RID: 609
            ModifyWorldTransform
            ' Token: 0x04000262 RID: 610
            MoveToEx
            ' Token: 0x04000263 RID: 611
            MWT_
            ' Token: 0x04000264 RID: 612
            OffsetRgn
            ' Token: 0x04000265 RID: 613
            OffsetViewportOrgEx
            ' Token: 0x04000266 RID: 614
            OffsetWindowOrgEx
            ' Token: 0x04000267 RID: 615
            PatBlt
            ' Token: 0x04000268 RID: 616
            Pie
            ' Token: 0x04000269 RID: 617
            PlayEnhMetaFile
            ' Token: 0x0400026A RID: 618
            PlgBlt
            ' Token: 0x0400026B RID: 619
            PolyBezier
            ' Token: 0x0400026C RID: 620
            PolyDraw
            ' Token: 0x0400026D RID: 621
            Polygon
            ' Token: 0x0400026E RID: 622
            Polyline
            ' Token: 0x0400026F RID: 623
            PolyPolygon
            ' Token: 0x04000270 RID: 624
            PolyPolyline
            ' Token: 0x04000271 RID: 625
            PostScript
            ' Token: 0x04000272 RID: 626
            Rectangle
            ' Token: 0x04000273 RID: 627
            RectInRegion
            ' Token: 0x04000274 RID: 628
            RemoveFontResource
            ' Token: 0x04000275 RID: 629
            RestoreDC
            ' Token: 0x04000276 RID: 630
            RoundRect
            ' Token: 0x04000277 RID: 631
            SelectClipRgn
            ' Token: 0x04000278 RID: 632
            SelectObject
            ' Token: 0x04000279 RID: 633
            SelectPalette
            ' Token: 0x0400027A RID: 634
            SetAbortProc
            ' Token: 0x0400027B RID: 635
            SetArcDirection
            ' Token: 0x0400027C RID: 636
            SetBitmapBits
            ' Token: 0x0400027D RID: 637
            SetBkColor
            ' Token: 0x0400027E RID: 638
            SetBkMode
            ' Token: 0x0400027F RID: 639
            SetDeviceGammaRamp
            ' Token: 0x04000280 RID: 640
            SetDIBits
            ' Token: 0x04000281 RID: 641
            SetGraphicsMode
            ' Token: 0x04000282 RID: 642
            SetMapMode
            ' Token: 0x04000283 RID: 643
            SetMetaFileBitsEx
            ' Token: 0x04000284 RID: 644
            SetPixel
            ' Token: 0x04000285 RID: 645
            SetROP2
            ' Token: 0x04000286 RID: 646
            SetStretchBltMode
            ' Token: 0x04000287 RID: 647
            SetTextAlign
            ' Token: 0x04000288 RID: 648
            SetTextCharacterExtra
            ' Token: 0x04000289 RID: 649
            SetTextColor
            ' Token: 0x0400028A RID: 650
            SetViewportOrgEx
            ' Token: 0x0400028B RID: 651
            SetWindowOrgEx
            ' Token: 0x0400028C RID: 652
            SetWorldTransform
            ' Token: 0x0400028D RID: 653
            StartDoc
            ' Token: 0x0400028E RID: 654
            StartPage
            ' Token: 0x0400028F RID: 655
            StretchBlt
            ' Token: 0x04000290 RID: 656
            StretchDIBits
            ' Token: 0x04000291 RID: 657
            TextOut
            ' Token: 0x04000292 RID: 658
            TextOutA
            ' Token: 0x04000293 RID: 659
            WidenPath
            ' Token: 0x04000294 RID: 660
            WmfPlaceableFileHeader
            ' Token: 0x04000295 RID: 661
            XFORM
        End Enum

        ' Token: 0x0200002D RID: 45
        Public Enum gdiplus
            ' Token: 0x04000297 RID: 663
            GdipAddPathArc
            ' Token: 0x04000298 RID: 664
            GdipAddPathArcI
            ' Token: 0x04000299 RID: 665
            GdipAddPathBezier
            ' Token: 0x0400029A RID: 666
            GdipAddPathBezierI
            ' Token: 0x0400029B RID: 667
            GdipAddPathBeziers
            ' Token: 0x0400029C RID: 668
            GdipAddPathClosedCurve
            ' Token: 0x0400029D RID: 669
            GdipAddPathClosedCurve2
            ' Token: 0x0400029E RID: 670
            GdipAddPathCurve
            ' Token: 0x0400029F RID: 671
            GdipAddPathCurve2
            ' Token: 0x040002A0 RID: 672
            GdipAddPathCurve3
            ' Token: 0x040002A1 RID: 673
            GdipAddPathEllipse
            ' Token: 0x040002A2 RID: 674
            GdipAddPathLine
            ' Token: 0x040002A3 RID: 675
            GdipAddPathLine2
            ' Token: 0x040002A4 RID: 676
            GdipAddPathPath
            ' Token: 0x040002A5 RID: 677
            GdipAddPathPie
            ' Token: 0x040002A6 RID: 678
            GdipAddPathPolygon
            ' Token: 0x040002A7 RID: 679
            GdipAddPathRectangle
            ' Token: 0x040002A8 RID: 680
            GdipAddPathRectangleI
            ' Token: 0x040002A9 RID: 681
            GdipAddPathRectangles
            ' Token: 0x040002AA RID: 682
            GdipAddPathString
            ' Token: 0x040002AB RID: 683
            GdipBeginContainer
            ' Token: 0x040002AC RID: 684
            GdipBeginContainer2
            ' Token: 0x040002AD RID: 685
            GdipBitmapGetPixel
            ' Token: 0x040002AE RID: 686
            GdipBitmapLockBits
            ' Token: 0x040002AF RID: 687
            GdipBitmapSetPixel
            ' Token: 0x040002B0 RID: 688
            GdipBitmapSetResolution
            ' Token: 0x040002B1 RID: 689
            GdipBitmapUnlockBits
            ' Token: 0x040002B2 RID: 690
            GdipClearPathMarkers
            ' Token: 0x040002B3 RID: 691
            GdipCloneBitmapArea
            ' Token: 0x040002B4 RID: 692
            GdipCloneBrush
            ' Token: 0x040002B5 RID: 693
            GdipCloneCustomLineCap
            ' Token: 0x040002B6 RID: 694
            GdipCloneFont
            ' Token: 0x040002B7 RID: 695
            GdipCloneImage
            ' Token: 0x040002B8 RID: 696
            GdipCloneMatrix
            ' Token: 0x040002B9 RID: 697
            GdipClonePath
            ' Token: 0x040002BA RID: 698
            GdipClonePen
            ' Token: 0x040002BB RID: 699
            GdipCloneRegion
            ' Token: 0x040002BC RID: 700
            GdipCloneStringFormat
            ' Token: 0x040002BD RID: 701
            GdipClosePathFigure
            ' Token: 0x040002BE RID: 702
            GdipCombineRegionPath
            ' Token: 0x040002BF RID: 703
            GdipCombineRegionRect
            ' Token: 0x040002C0 RID: 704
            GdipCombineRegionRegion
            ' Token: 0x040002C1 RID: 705
            GdipComment
            ' Token: 0x040002C2 RID: 706
            GdipCreateAdjustableArrowCap
            ' Token: 0x040002C3 RID: 707
            GdipCreateBitmapFromFile
            ' Token: 0x040002C4 RID: 708
            GdipCreateBitmapFromGdiDib
            ' Token: 0x040002C5 RID: 709
            GdipCreateBitmapFromGraphics
            ' Token: 0x040002C6 RID: 710
            GdipCreateBitmapFromHBITMAP
            ' Token: 0x040002C7 RID: 711
            GdipCreateBitmapFromHICON
            ' Token: 0x040002C8 RID: 712
            GdipEmfToWmfBits
            ' Token: 0x040002C9 RID: 713
            GdiplusShutdown
            ' Token: 0x040002CA RID: 714
            GdiplusStartup
            ' Token: 0x040002CB RID: 715
            GdipMeasureString
        End Enum

        ' Token: 0x0200002E RID: 46
        Public Enum getuname
            ' Token: 0x040002CD RID: 717
            GetUName
        End Enum

        ' Token: 0x0200002F RID: 47
        Public Enum glu32
            ' Token: 0x040002CF RID: 719
            gluDeleteQuadric
            ' Token: 0x040002D0 RID: 720
            gluErrorString
            ' Token: 0x040002D1 RID: 721
            gluNewQuadric
            ' Token: 0x040002D2 RID: 722
            gluQuadricDrawStyle
            ' Token: 0x040002D3 RID: 723
            gluSphere
        End Enum

        ' Token: 0x02000030 RID: 48
        Public Enum glut32
            ' Token: 0x040002D5 RID: 725
            None
        End Enum

        ' Token: 0x02000031 RID: 49
        Public Enum gsapi
            ' Token: 0x040002D7 RID: 727
            gsapi_delete_instance
            ' Token: 0x040002D8 RID: 728
            gsapi_exit
            ' Token: 0x040002D9 RID: 729
            gsapi_init_with_args
            ' Token: 0x040002DA RID: 730
            gsapi_new_instance
            ' Token: 0x040002DB RID: 731
            gsapi_revision
        End Enum

        ' Token: 0x02000032 RID: 50
        Public Enum hhctrl
            ' Token: 0x040002DD RID: 733
            HtmlHelp
            ' Token: 0x040002DE RID: 734
            writers
        End Enum

        ' Token: 0x02000033 RID: 51
        Public Enum hid
            ' Token: 0x040002E0 RID: 736
            HIDD_ATTRIBUTES
            ' Token: 0x040002E1 RID: 737
            HidD_FlushQueue
            ' Token: 0x040002E2 RID: 738
            HidD_FreePreparsedData
            ' Token: 0x040002E3 RID: 739
            HidD_GetAttributes
            ' Token: 0x040002E4 RID: 740
            HidD_GetFeature
            ' Token: 0x040002E5 RID: 741
            HidD_GetHidGuid
            ' Token: 0x040002E6 RID: 742
            HidD_GetIndexedString
            ' Token: 0x040002E7 RID: 743
            HidD_GetInputReport
            ' Token: 0x040002E8 RID: 744
            HidD_GetManufacturerString
            ' Token: 0x040002E9 RID: 745
            HidD_GetNumInputBuffers
            ' Token: 0x040002EA RID: 746
            HidD_GetPhysicalDescriptor
            ' Token: 0x040002EB RID: 747
            HidD_GetPreparsedData
            ' Token: 0x040002EC RID: 748
            HidD_GetProductString
            ' Token: 0x040002ED RID: 749
            HidD_GetSerialNumberString
            ' Token: 0x040002EE RID: 750
            HidD_SetFeature
            ' Token: 0x040002EF RID: 751
            HidD_SetNumInputBuffers
            ' Token: 0x040002F0 RID: 752
            HidD_SetOutputReport
            ' Token: 0x040002F1 RID: 753
            HIDP_CAPS
            ' Token: 0x040002F2 RID: 754
            HidP_GetCaps
        End Enum

        ' Token: 0x02000034 RID: 52
        Public Enum hlink
            ' Token: 0x040002F4 RID: 756
            None
        End Enum

        ' Token: 0x02000035 RID: 53
        Public Enum httpapi
            ' Token: 0x040002F6 RID: 758
            HttpDeleteServiceConfiguration
            ' Token: 0x040002F7 RID: 759
            HttpInitialize
            ' Token: 0x040002F8 RID: 760
            HttpQueryServiceConfiguration
            ' Token: 0x040002F9 RID: 761
            HttpSetServiceConfiguration
            ' Token: 0x040002FA RID: 762
            HttpTerminate
        End Enum

        ' Token: 0x02000036 RID: 54
        Public Enum icmp
            ' Token: 0x040002FC RID: 764
            IcmpCloseHandle
            ' Token: 0x040002FD RID: 765
            IcmpCreateFile
            ' Token: 0x040002FE RID: 766
            ICMPPing
            ' Token: 0x040002FF RID: 767
            IcmpSendEcho
        End Enum

        ' Token: 0x02000037 RID: 55
        Public Enum imm32
            ' Token: 0x04000301 RID: 769
            ImmConfigureIME
            ' Token: 0x04000302 RID: 770
            ImmGetCompositionString
            ' Token: 0x04000303 RID: 771
            ImmGetContext
            ' Token: 0x04000304 RID: 772
            ImmGetConversionList
            ' Token: 0x04000305 RID: 773
            ImmReleaseContext
        End Enum

        ' Token: 0x02000038 RID: 56
        Public Enum iphlpapi
            ' Token: 0x04000307 RID: 775
            AddIPAddress
            ' Token: 0x04000308 RID: 776
            EnableRouter
            ' Token: 0x04000309 RID: 777
            FIXED_INFO
            ' Token: 0x0400030A RID: 778
            GetAdapterIndex
            ' Token: 0x0400030B RID: 779
            GetAdaptersAddresses
            ' Token: 0x0400030C RID: 780
            GetAdaptersInfo
            ' Token: 0x0400030D RID: 781
            GetBestInterface
            ' Token: 0x0400030E RID: 782
            GetExtendedTcpTable
            ' Token: 0x0400030F RID: 783
            GetIfTable
            ' Token: 0x04000310 RID: 784
            GetInterfaceInfo
            ' Token: 0x04000311 RID: 785
            GetIpAddrTable
            ' Token: 0x04000312 RID: 786
            GetIpNetTable
            ' Token: 0x04000313 RID: 787
            GetNetworkParams
            ' Token: 0x04000314 RID: 788
            IPAddress
            ' Token: 0x04000315 RID: 789
            IpReleaseAddress
            ' Token: 0x04000316 RID: 790
            MAX_HOSTNAME_LEN
            ' Token: 0x04000317 RID: 791
            MIB_IPNETROW
            ' Token: 0x04000318 RID: 792
            NetworkInformation
            ' Token: 0x04000319 RID: 793
            PfAddFiltersToInterface
            ' Token: 0x0400031A RID: 794
            PfBindInterfaceToIPAddress
            ' Token: 0x0400031B RID: 795
            PfCreateInterface
            ' Token: 0x0400031C RID: 796
            PfDeleteInterface
            ' Token: 0x0400031D RID: 797
            PfRemoveFiltersFromInterface
            ' Token: 0x0400031E RID: 798
            PfTestPacket
            ' Token: 0x0400031F RID: 799
            SendARP
            ' Token: 0x04000320 RID: 800
            SetTCPEntry
            ' Token: 0x04000321 RID: 801
            ShowMessage
            ' Token: 0x04000322 RID: 802
            UnenableRouter
        End Enum

        ' Token: 0x02000039 RID: 57
        Public Enum iprop
            ' Token: 0x04000324 RID: 804
            PropVariantClear
        End Enum

        ' Token: 0x0200003A RID: 58
        Public Enum irprops
            ' Token: 0x04000326 RID: 806
            BluetoothAuthenticateDevice
            ' Token: 0x04000327 RID: 807
            BluetoothAuthenticateDeviceEx
            ' Token: 0x04000328 RID: 808
            BluetoothEnableDiscovery
            ' Token: 0x04000329 RID: 809
            BluetoothEnableIncomingConnections
            ' Token: 0x0400032A RID: 810
            BluetoothEnumerateInstalledServices
            ' Token: 0x0400032B RID: 811
            BluetoothFindDeviceClose
            ' Token: 0x0400032C RID: 812
            BluetoothFindFirstDevice
            ' Token: 0x0400032D RID: 813
            BluetoothFindFirstRadio
            ' Token: 0x0400032E RID: 814
            BluetoothFindNextDevice
            ' Token: 0x0400032F RID: 815
            BluetoothFindNextRadio
            ' Token: 0x04000330 RID: 816
            BluetoothFindRadioClose
            ' Token: 0x04000331 RID: 817
            BluetoothGetDeviceInfo
            ' Token: 0x04000332 RID: 818
            BluetoothGetRadioInfo
            ' Token: 0x04000333 RID: 819
            BluetoothIsConnectable
            ' Token: 0x04000334 RID: 820
            BluetoothIsDiscoverable
            ' Token: 0x04000335 RID: 821
            BluetoothRemoveDevice
            ' Token: 0x04000336 RID: 822
            BluetoothSetServiceState
            ' Token: 0x04000337 RID: 823
            BluetoothUpdateDeviceRecord
        End Enum

        ' Token: 0x0200003B RID: 59
        Public Enum kernel32
            ' Token: 0x04000339 RID: 825
            ActivateActCtx
            ' Token: 0x0400033A RID: 826
            ActiveActCtx
            ' Token: 0x0400033B RID: 827
            AddAtom
            ' Token: 0x0400033C RID: 828
            AddConsoleAlias
            ' Token: 0x0400033D RID: 829
            AddLocalAlternateComputerName
            ' Token: 0x0400033E RID: 830
            AllocateUserPhysicalPages
            ' Token: 0x0400033F RID: 831
            AllocConsole
            ' Token: 0x04000340 RID: 832
            APIGetVersionEx
            ' Token: 0x04000341 RID: 833
            AreFileApisANSI
            ' Token: 0x04000342 RID: 834
            AssignProcessToJobObject
            ' Token: 0x04000343 RID: 835
            AttachConsole
            ' Token: 0x04000344 RID: 836
            BackupRead
            ' Token: 0x04000345 RID: 837
            BackupWrite
            ' Token: 0x04000346 RID: 838
            Beep
            ' Token: 0x04000347 RID: 839
            begerw4224sda3r
            ' Token: 0x04000348 RID: 840
            BeginUpdateResource
            ' Token: 0x04000349 RID: 841
            bruh
            ' Token: 0x0400034A RID: 842
            BuildCommDCB
            ' Token: 0x0400034B RID: 843
            CancelIo
            ' Token: 0x0400034C RID: 844
            CancelWaitableTimer
            ' Token: 0x0400034D RID: 845
            CheckRemoteDebuggerPresent
            ' Token: 0x0400034E RID: 846
            ClearCommBreak
            ' Token: 0x0400034F RID: 847
            ClearCommError
            ' Token: 0x04000350 RID: 848
            CloseHandle
            ' Token: 0x04000351 RID: 849
            CloudNet
            ' Token: 0x04000352 RID: 850
            CommConfigDialog
            ' Token: 0x04000353 RID: 851
            CompareString
            ' Token: 0x04000354 RID: 852
            CompareStringEx
            ' Token: 0x04000355 RID: 853
            ConnectNamedPipe
            ' Token: 0x04000356 RID: 854
            ConsoleFunctions
            ' Token: 0x04000357 RID: 855
            ContinueDebugEvent
            ' Token: 0x04000358 RID: 856
            ContinueStatus
            ' Token: 0x04000359 RID: 857
            ConvertThreadToFiber
            ' Token: 0x0400035A RID: 858
            COORD
            ' Token: 0x0400035B RID: 859
            CopyFile
            ' Token: 0x0400035C RID: 860
            CopyFileEx
            ' Token: 0x0400035D RID: 861
            CreateActCtxW
            ' Token: 0x0400035E RID: 862
            CreateConsoleScreenBuffer
            ' Token: 0x0400035F RID: 863
            CreateDirectory
            ' Token: 0x04000360 RID: 864
            CreateDirectoryEx
            ' Token: 0x04000361 RID: 865
            CreateEvent
            ' Token: 0x04000362 RID: 866
            CreateFiber
            ' Token: 0x04000363 RID: 867
            CreateFile
            ' Token: 0x04000364 RID: 868
            CreateFileMapping
            ' Token: 0x04000365 RID: 869
            CreateHardLink
            ' Token: 0x04000366 RID: 870
            CreateIoCompletionPort
            ' Token: 0x04000367 RID: 871
            CreateJobObject
            ' Token: 0x04000368 RID: 872
            CreateMailslot
            ' Token: 0x04000369 RID: 873
            CreateMemoryResourceNotification
            ' Token: 0x0400036A RID: 874
            CreateMutex
            ' Token: 0x0400036B RID: 875
            CreateNamedPipe
            ' Token: 0x0400036C RID: 876
            CreatePipe
            ' Token: 0x0400036D RID: 877
            CreateProcess
            ' Token: 0x0400036E RID: 878
            CreateRemoteThread
            ' Token: 0x0400036F RID: 879
            CreateSymbolicLink
            ' Token: 0x04000370 RID: 880
            CreateThread
            ' Token: 0x04000371 RID: 881
            CreateTimerQueue
            ' Token: 0x04000372 RID: 882
            CreateTimerQueueTimer
            ' Token: 0x04000373 RID: 883
            CreateToolhelp32Snapshot
            ' Token: 0x04000374 RID: 884
            CreateWaitableTimer
            ' Token: 0x04000375 RID: 885
            csepeli
            ' Token: 0x04000376 RID: 886
            DeactivateActCtx
            ' Token: 0x04000377 RID: 887
            DebugActiveProcess
            ' Token: 0x04000378 RID: 888
            DebugActiveProcessStop
            ' Token: 0x04000379 RID: 889
            DebugBreak
            ' Token: 0x0400037A RID: 890
            DebugSetProcessKillOnExit
            ' Token: 0x0400037B RID: 891
            DecryptFile
            ' Token: 0x0400037C RID: 892
            DefineDosDevice
            ' Token: 0x0400037D RID: 893
            DeleteAtom
            ' Token: 0x0400037E RID: 894
            DeleteCriticalSection
            ' Token: 0x0400037F RID: 895
            DeleteFile
            ' Token: 0x04000380 RID: 896
            DeleteVolumeMountPoint
            ' Token: 0x04000381 RID: 897
            DeviceIoControl
            ' Token: 0x04000382 RID: 898
            DisableThreadLibraryCalls
            ' Token: 0x04000383 RID: 899
            DisconnectNamedPipe
            ' Token: 0x04000384 RID: 900
            DLLs
            ' Token: 0x04000385 RID: 901
            dll_
            ' Token: 0x04000386 RID: 902
            DnsHostnameToComputerName
            ' Token: 0x04000387 RID: 903
            DosDateTimeToFileTime
            ' Token: 0x04000388 RID: 904
            DriveLetter
            ' Token: 0x04000389 RID: 905
            DuplicateHandle
            ' Token: 0x0400038A RID: 906
            EndUpdateResource
            ' Token: 0x0400038B RID: 907
            EnterCriticalSection
            ' Token: 0x0400038C RID: 908
            EnumDateFormats
            ' Token: 0x0400038D RID: 909
            EnumerateLocalComputerNames
            ' Token: 0x0400038E RID: 910
            EnumResourceLanguages
            ' Token: 0x0400038F RID: 911
            EnumResourceNames
            ' Token: 0x04000390 RID: 912
            EnumResourceTypes
            ' Token: 0x04000391 RID: 913
            EnumSystemCodePages
            ' Token: 0x04000392 RID: 914
            EnumSystemLocales
            ' Token: 0x04000393 RID: 915
            EnumSystemLocalesEx
            ' Token: 0x04000394 RID: 916
            EnumUILanguages
            ' Token: 0x04000395 RID: 917
            EscapeCommFunction
            ' Token: 0x04000396 RID: 918
            ExitProcess
            ' Token: 0x04000397 RID: 919
            ExpandEnvironmentStrings
            ' Token: 0x04000398 RID: 920
            ExpandEnvironmentStringsA
            ' Token: 0x04000399 RID: 921
            FatalExit
            ' Token: 0x0400039A RID: 922
            FileStream
            ' Token: 0x0400039B RID: 923
            FileTimeToDosDateTime
            ' Token: 0x0400039C RID: 924
            FileTimeToLocalFileTime
            ' Token: 0x0400039D RID: 925
            FileTimeToSystemTime
            ' Token: 0x0400039E RID: 926
            FindAtom
            ' Token: 0x0400039F RID: 927
            FindClose
            ' Token: 0x040003A0 RID: 928
            FindCloseChangeNotification
            ' Token: 0x040003A1 RID: 929
            FindFirstChangeNotification
            ' Token: 0x040003A2 RID: 930
            FindFirstFile
            ' Token: 0x040003A3 RID: 931
            FindFirstFileEx
            ' Token: 0x040003A4 RID: 932
            FindFirstVolume
            ' Token: 0x040003A5 RID: 933
            FindNextChangeNotification
            ' Token: 0x040003A6 RID: 934
            FindNextFile
            ' Token: 0x040003A7 RID: 935
            FindNextVolume
            ' Token: 0x040003A8 RID: 936
            FindResource
            ' Token: 0x040003A9 RID: 937
            FindResourceEx
            ' Token: 0x040003AA RID: 938
            findwindow
            ' Token: 0x040003AB RID: 939
            FlushConsoleInputBuffer
            ' Token: 0x040003AC RID: 940
            FlushFileBuffers
            ' Token: 0x040003AD RID: 941
            FlushInstructionCache
            ' Token: 0x040003AE RID: 942
            FlushViewOfFile
            ' Token: 0x040003AF RID: 943
            FoldStringW
            ' Token: 0x040003B0 RID: 944
            FormatMessage
            ' Token: 0x040003B1 RID: 945
            FormatMessageA
            ' Token: 0x040003B2 RID: 946
            FreeConsole
            ' Token: 0x040003B3 RID: 947
            FreeLibrary
            ' Token: 0x040003B4 RID: 948
            FreeUserPhysicalPages
            ' Token: 0x040003B5 RID: 949
            GenerateConsoleCtrlEvent
            ' Token: 0x040003B6 RID: 950
            GetApplicationUserModelId
            ' Token: 0x040003B7 RID: 951
            GetAtomName
            ' Token: 0x040003B8 RID: 952
            GetBinaryType
            ' Token: 0x040003B9 RID: 953
            GetClipboardData
            ' Token: 0x040003BA RID: 954
            GetCommandLine
            ' Token: 0x040003BB RID: 955
            GetCommConfig
            ' Token: 0x040003BC RID: 956
            GetCommModemStatus
            ' Token: 0x040003BD RID: 957
            GetCommProperties
            ' Token: 0x040003BE RID: 958
            GetCommState
            ' Token: 0x040003BF RID: 959
            GetCommTimeouts
            ' Token: 0x040003C0 RID: 960
            GetCompressedFileSize
            ' Token: 0x040003C1 RID: 961
            GetComputerName
            ' Token: 0x040003C2 RID: 962
            GetComputerNameEx
            ' Token: 0x040003C3 RID: 963
            GetConsoleAlias
            ' Token: 0x040003C4 RID: 964
            GetConsoleAliases
            ' Token: 0x040003C5 RID: 965
            GetConsoleAliasExes
            ' Token: 0x040003C6 RID: 966
            GetConsoleCP
            ' Token: 0x040003C7 RID: 967
            GetConsoleCursorInfo
            ' Token: 0x040003C8 RID: 968
            GetConsoleDisplayMode
            ' Token: 0x040003C9 RID: 969
            GetConsoleFontSize
            ' Token: 0x040003CA RID: 970
            GetConsoleHistoryInfo
            ' Token: 0x040003CB RID: 971
            GetConsoleMode
            ' Token: 0x040003CC RID: 972
            GetConsoleOriginalTitle
            ' Token: 0x040003CD RID: 973
            GetConsoleProcessList
            ' Token: 0x040003CE RID: 974
            GetConsoleScreenBufferInfo
            ' Token: 0x040003CF RID: 975
            GetConsoleScreenBufferInfoEx
            ' Token: 0x040003D0 RID: 976
            GetConsoleSelectionInfo
            ' Token: 0x040003D1 RID: 977
            GetConsoleTitle
            ' Token: 0x040003D2 RID: 978
            GetConsoleWindow
            ' Token: 0x040003D3 RID: 979
            GetCPInfo
            ' Token: 0x040003D4 RID: 980
            GetCPInfoEx
            ' Token: 0x040003D5 RID: 981
            GetCurrencyFormat
            ' Token: 0x040003D6 RID: 982
            GetCurrentActCtx
            ' Token: 0x040003D7 RID: 983
            GetCurrentApplicationUserModelId
            ' Token: 0x040003D8 RID: 984
            GetCurrentConsoleFont
            ' Token: 0x040003D9 RID: 985
            GetCurrentConsoleFontEx
            ' Token: 0x040003DA RID: 986
            GetCurrentDirectory
            ' Token: 0x040003DB RID: 987
            GetCurrentProcess
            ' Token: 0x040003DC RID: 988
            GetCurrentProcessId
            ' Token: 0x040003DD RID: 989
            GetCurrentThread
            ' Token: 0x040003DE RID: 990
            GetCurrentThreadId
            ' Token: 0x040003DF RID: 991
            GetDateFormat
            ' Token: 0x040003E0 RID: 992
            GetDefaultCommConfig
            ' Token: 0x040003E1 RID: 993
            GetDevicePowerState
            ' Token: 0x040003E2 RID: 994
            GetDiskFreeSpace
            ' Token: 0x040003E3 RID: 995
            GetDiskFreeSpaceEx
            ' Token: 0x040003E4 RID: 996
            GetDriveType
            ' Token: 0x040003E5 RID: 997
            GetEnvironmentVariable
            ' Token: 0x040003E6 RID: 998
            GetExitCodeProcess
            ' Token: 0x040003E7 RID: 999
            GetExitCodeThread
            ' Token: 0x040003E8 RID: 1000
            GetFileAttributes
            ' Token: 0x040003E9 RID: 1001
            GetFileAttributesEx
            ' Token: 0x040003EA RID: 1002
            GetFileInformationByHandle
            ' Token: 0x040003EB RID: 1003
            GetFileInformationByHandleEx
            ' Token: 0x040003EC RID: 1004
            GetFileSize
            ' Token: 0x040003ED RID: 1005
            GetFileSizeEx
            ' Token: 0x040003EE RID: 1006
            GetFileTime
            ' Token: 0x040003EF RID: 1007
            GetFileType
            ' Token: 0x040003F0 RID: 1008
            GetFileVersionInfo
            ' Token: 0x040003F1 RID: 1009
            GetFullPathName
            ' Token: 0x040003F2 RID: 1010
            GetHandleInformation
            ' Token: 0x040003F3 RID: 1011
            GetKeyboardTyре
            ' Token: 0x040003F4 RID: 1012
            GetLargePageMinimum
            ' Token: 0x040003F5 RID: 1013
            GetLastError
            ' Token: 0x040003F6 RID: 1014
            GetLocaleInfo
            ' Token: 0x040003F7 RID: 1015
            GetLocaleInfoEx
            ' Token: 0x040003F8 RID: 1016
            GetLocalTime
            ' Token: 0x040003F9 RID: 1017
            GetLogicalDrives
            ' Token: 0x040003FA RID: 1018
            GetLogicalDriveStrings
            ' Token: 0x040003FB RID: 1019
            GetLogicalProzessorInformation
            ' Token: 0x040003FC RID: 1020
            GetLongPathName
            ' Token: 0x040003FD RID: 1021
            GetMailslotInfo
            ' Token: 0x040003FE RID: 1022
            GetModuleFileName
            ' Token: 0x040003FF RID: 1023
            GetModuleHandle
            ' Token: 0x04000400 RID: 1024
            GetNamedPipeClientProcessId
            ' Token: 0x04000401 RID: 1025
            GetNativeSystemInfo
            ' Token: 0x04000402 RID: 1026
            GetNumaHighestNodeNumber
            ' Token: 0x04000403 RID: 1027
            GetNumberOfConsoleMouseButtons
            ' Token: 0x04000404 RID: 1028
            GetOverlappedResult
            ' Token: 0x04000405 RID: 1029
            GetPhysicallyInstalledSystemMemory
            ' Token: 0x04000406 RID: 1030
            GetPriorityClass
            ' Token: 0x04000407 RID: 1031
            GetPrivateProfileInt
            ' Token: 0x04000408 RID: 1032
            GetPrivateProfileSection
            ' Token: 0x04000409 RID: 1033
            GetPrivateProfileSectionNames
            ' Token: 0x0400040A RID: 1034
            GetPrivateProfileString
            ' Token: 0x0400040B RID: 1035
            GetProcAddress
            ' Token: 0x0400040C RID: 1036
            GetProcessAffinityMask
            ' Token: 0x0400040D RID: 1037
            GetProcessDEPPolicy
            ' Token: 0x0400040E RID: 1038
            GetProcessHandleCount
            ' Token: 0x0400040F RID: 1039
            GetProcessHeap
            ' Token: 0x04000410 RID: 1040
            GetProcessHeaps
            ' Token: 0x04000411 RID: 1041
            GetProcessId
            ' Token: 0x04000412 RID: 1042
            GetProcessIdOfThread
            ' Token: 0x04000413 RID: 1043
            GetProcessIoCounters
            ' Token: 0x04000414 RID: 1044
            GetProcessShutdownParameters
            ' Token: 0x04000415 RID: 1045
            GetProcessTimes
            ' Token: 0x04000416 RID: 1046
            GetProductInfo
            ' Token: 0x04000417 RID: 1047
            GetQueuedCompletionStatus
            ' Token: 0x04000418 RID: 1048
            GetShortPathName
            ' Token: 0x04000419 RID: 1049
            GetStartupInfo
            ' Token: 0x0400041A RID: 1050
            GetStdHandle
            ' Token: 0x0400041B RID: 1051
            GetStringType
            ' Token: 0x0400041C RID: 1052
            GetStringTypeEx
            ' Token: 0x0400041D RID: 1053
            GetSystemDefaultLangID
            ' Token: 0x0400041E RID: 1054
            GetSystemDefaultLCID
            ' Token: 0x0400041F RID: 1055
            GetSystemDefaultUILanguage
            ' Token: 0x04000420 RID: 1056
            GetSystemDirectory
            ' Token: 0x04000421 RID: 1057
            GetSystemFileCacheSize
            ' Token: 0x04000422 RID: 1058
            GetSystemInfo
            ' Token: 0x04000423 RID: 1059
            GetSystemPowerStatus
            ' Token: 0x04000424 RID: 1060
            GetSystemPreferredUILanguages
            ' Token: 0x04000425 RID: 1061
            GetSystemTime
            ' Token: 0x04000426 RID: 1062
            GetSystemTimeAsFileTime
            ' Token: 0x04000427 RID: 1063
            GetSystemTimePreciseAsFileTime
            ' Token: 0x04000428 RID: 1064
            GetSystemTimes
            ' Token: 0x04000429 RID: 1065
            GetSystemWindowsDirectory
            ' Token: 0x0400042A RID: 1066
            GetSystemWow64Directory
            ' Token: 0x0400042B RID: 1067
            GetTapePosition
            ' Token: 0x0400042C RID: 1068
            GetTempFileName
            ' Token: 0x0400042D RID: 1069
            GetTempPath
            ' Token: 0x0400042E RID: 1070
            GetThreadContext
            ' Token: 0x0400042F RID: 1071
            GetThreadLocale
            ' Token: 0x04000430 RID: 1072
            GetThreadPriority
            ' Token: 0x04000431 RID: 1073
            GetThreadSelectorEntry
            ' Token: 0x04000432 RID: 1074
            GetThreadTimes
            ' Token: 0x04000433 RID: 1075
            GetTickCount
            ' Token: 0x04000434 RID: 1076
            GetTimeFormat
            ' Token: 0x04000435 RID: 1077
            GetTimeZoneInformation
            ' Token: 0x04000436 RID: 1078
            GetUserDefaultLCID
            ' Token: 0x04000437 RID: 1079
            GetUserPreferredUILanguages
            ' Token: 0x04000438 RID: 1080
            GetVersion
            ' Token: 0x04000439 RID: 1081
            GetVersionEx
            ' Token: 0x0400043A RID: 1082
            GetVolumeInformation
            ' Token: 0x0400043B RID: 1083
            GetVolumeNameForVolumeMountPoint
            ' Token: 0x0400043C RID: 1084
            GetVolumePathName
            ' Token: 0x0400043D RID: 1085
            GetVolumePathNamesForVolumeName
            ' Token: 0x0400043E RID: 1086
            GetWindowsDirectory
            ' Token: 0x0400043F RID: 1087
            GetWriteWatch
            ' Token: 0x04000440 RID: 1088
            GlobalAddAtom
            ' Token: 0x04000441 RID: 1089
            GlobalAlloc
            ' Token: 0x04000442 RID: 1090
            GlobalDeleteAtom
            ' Token: 0x04000443 RID: 1091
            GlobalFindAtom
            ' Token: 0x04000444 RID: 1092
            GlobalFree
            ' Token: 0x04000445 RID: 1093
            GlobalGetAtomName
            ' Token: 0x04000446 RID: 1094
            GlobalHandle
            ' Token: 0x04000447 RID: 1095
            GlobalLock
            ' Token: 0x04000448 RID: 1096
            GlobalMemoryStatus
            ' Token: 0x04000449 RID: 1097
            GlobalMemoryStatusEx
            ' Token: 0x0400044A RID: 1098
            GlobalUnlock
            ' Token: 0x0400044B RID: 1099
            HandlerRoutine
            ' Token: 0x0400044C RID: 1100
            Heap32ListFirst
            ' Token: 0x0400044D RID: 1101
            Heap32ListNext
            ' Token: 0x0400044E RID: 1102
            HeapAlloc
            ' Token: 0x0400044F RID: 1103
            HeapCreate
            ' Token: 0x04000450 RID: 1104
            HeapDestroy
            ' Token: 0x04000451 RID: 1105
            HeapFree
            ' Token: 0x04000452 RID: 1106
            heapwalk
            ' Token: 0x04000453 RID: 1107
            Hi
            ' Token: 0x04000454 RID: 1108
            InitAtomTable
            ' Token: 0x04000455 RID: 1109
            InitializeCriticalSection
            ' Token: 0x04000456 RID: 1110
            InitializeProcThreadAttributeList
            ' Token: 0x04000457 RID: 1111
            InterlockedDecrement
            ' Token: 0x04000458 RID: 1112
            InterlockedIncrement
            ' Token: 0x04000459 RID: 1113
            InterlockedOr64
            ' Token: 0x0400045A RID: 1114
            IO_COUNTERS
            ' Token: 0x0400045B RID: 1115
            IsBadCodePtr
            ' Token: 0x0400045C RID: 1116
            IsDebuggerPresent
            ' Token: 0x0400045D RID: 1117
            IsProcessInJob
            ' Token: 0x0400045E RID: 1118
            IsProcessorFeaturePresent
            ' Token: 0x0400045F RID: 1119
            IsValidLocale
            ' Token: 0x04000460 RID: 1120
            IsWow64Process
            ' Token: 0x04000461 RID: 1121
            J6mTbD
            ' Token: 0x04000462 RID: 1122
            JOBOBJECTINFOCLASS
            ' Token: 0x04000463 RID: 1123
            JOBOBJECTLIMIT
            ' Token: 0x04000464 RID: 1124
            JOBOBJECT_BASIC_LIMIT_INFORMATION
            ' Token: 0x04000465 RID: 1125
            JOBOBJECT_EXTENDED_LIMIT_INFORMATION
            ' Token: 0x04000466 RID: 1126
            LCIDToLocaleName
            ' Token: 0x04000467 RID: 1127
            LCMapString
            ' Token: 0x04000468 RID: 1128
            LCMapStringEx
            ' Token: 0x04000469 RID: 1129
            LeaveCriticalSection
            ' Token: 0x0400046A RID: 1130
            LoadLibrary
            ' Token: 0x0400046B RID: 1131
            LoadLibraryEx
            ' Token: 0x0400046C RID: 1132
            LoadResource
            ' Token: 0x0400046D RID: 1133
            LocalAlloc
            ' Token: 0x0400046E RID: 1134
            LocalFree
            ' Token: 0x0400046F RID: 1135
            LockFile
            ' Token: 0x04000470 RID: 1136
            LockFileEx
            ' Token: 0x04000471 RID: 1137
            LockResource
            ' Token: 0x04000472 RID: 1138
            lstrcat
            ' Token: 0x04000473 RID: 1139
            lstrcmp
            ' Token: 0x04000474 RID: 1140
            lstrcpy
            ' Token: 0x04000475 RID: 1141
            lstrcpyn
            ' Token: 0x04000476 RID: 1142
            lstrlen
            ' Token: 0x04000477 RID: 1143
            MapUserPhysicalPages
            ' Token: 0x04000478 RID: 1144
            MapViewOfFile
            ' Token: 0x04000479 RID: 1145
            MDbg
            ' Token: 0x0400047A RID: 1146
            Module32First
            ' Token: 0x0400047B RID: 1147
            Module32Next
            ' Token: 0x0400047C RID: 1148
            MODULEENTRY32
            ' Token: 0x0400047D RID: 1149
            MoveFile
            ' Token: 0x0400047E RID: 1150
            MoveFileEx
            ' Token: 0x0400047F RID: 1151
            MoveFileWithProgress
            ' Token: 0x04000480 RID: 1152
            MoveMemory
            ' Token: 0x04000481 RID: 1153
            MultiByteToWideChar
            ' Token: 0x04000482 RID: 1154
            MyApplication
            ' Token: 0x04000483 RID: 1155
            NativeOverlapped
            ' Token: 0x04000484 RID: 1156
            NetBIOS
            ' Token: 0x04000485 RID: 1157
            nigger
            ' Token: 0x04000486 RID: 1158
            OpenEvent
            ' Token: 0x04000487 RID: 1159
            OpenFile
            ' Token: 0x04000488 RID: 1160
            openfileex
            ' Token: 0x04000489 RID: 1161
            OpenFileMapping
            ' Token: 0x0400048A RID: 1162
            OpenMutex
            ' Token: 0x0400048B RID: 1163
            OpenProcess
            ' Token: 0x0400048C RID: 1164
            OpenSemaphore
            ' Token: 0x0400048D RID: 1165
            OpenThread
            ' Token: 0x0400048E RID: 1166
            OutputDebugString
            ' Token: 0x0400048F RID: 1167
            PackageFamilyNameFromId
            ' Token: 0x04000490 RID: 1168
            PackageFullNameFromId
            ' Token: 0x04000491 RID: 1169
            PACKAGE_ID
            ' Token: 0x04000492 RID: 1170
            PeekConsoleInput
            ' Token: 0x04000493 RID: 1171
            PeekNamedPipe
            ' Token: 0x04000494 RID: 1172
            PlatformSDK
            ' Token: 0x04000495 RID: 1173
            PostQueuedCompletionStatus
            ' Token: 0x04000496 RID: 1174
            Process32First
            ' Token: 0x04000497 RID: 1175
            Process32Next
            ' Token: 0x04000498 RID: 1176
            PROCESSENTRY32
            ' Token: 0x04000499 RID: 1177
            ProcessIdToSessionId
            ' Token: 0x0400049A RID: 1178
            ProcessMemoryChunk
            ' Token: 0x0400049B RID: 1179
            PulseEvent
            ' Token: 0x0400049C RID: 1180
            PurgeComm
            ' Token: 0x0400049D RID: 1181
            QueryDosDevice
            ' Token: 0x0400049E RID: 1182
            QueryFullProcessImageName
            ' Token: 0x0400049F RID: 1183
            QueryMemoryResourceNotification
            ' Token: 0x040004A0 RID: 1184
            QueryPerformanceCounter
            ' Token: 0x040004A1 RID: 1185
            QueryPerformanceFrequency
            ' Token: 0x040004A2 RID: 1186
            ReadConsole
            ' Token: 0x040004A3 RID: 1187
            ReadConsoleInput
            ' Token: 0x040004A4 RID: 1188
            ReadConsoleOutput
            ' Token: 0x040004A5 RID: 1189
            ReadConsoleOutputCharacter
            ' Token: 0x040004A6 RID: 1190
            ReadDirectoryChangesW
            ' Token: 0x040004A7 RID: 1191
            ReadFile
            ' Token: 0x040004A8 RID: 1192
            ReadFileEx
            ' Token: 0x040004A9 RID: 1193
            ReadFileScatter
            ' Token: 0x040004AA RID: 1194
            ReadProcessMemory
            ' Token: 0x040004AB RID: 1195
            RegisterApplicationRestart
            ' Token: 0x040004AC RID: 1196
            RegisterServiceProcess
            ' Token: 0x040004AD RID: 1197
            ReleaseActCtx
            ' Token: 0x040004AE RID: 1198
            ReleaseMutex
            ' Token: 0x040004AF RID: 1199
            RemoteDebugger
            ' Token: 0x040004B0 RID: 1200
            RemoveDirectory
            ' Token: 0x040004B1 RID: 1201
            RemoveLocalAlternateComputerName
            ' Token: 0x040004B2 RID: 1202
            REPARER
            ' Token: 0x040004B3 RID: 1203
            ReplaceFile
            ' Token: 0x040004B4 RID: 1204
            ResetEvent
            ' Token: 0x040004B5 RID: 1205
            ResumeThread
            ' Token: 0x040004B6 RID: 1206
            RtlAddFunctionTable
            ' Token: 0x040004B7 RID: 1207
            SafeFileHandle
            ' Token: 0x040004B8 RID: 1208
            SearchPath
            ' Token: 0x040004B9 RID: 1209
            SecureZeroMemory
            ' Token: 0x040004BA RID: 1210
            SetCommBreak
            ' Token: 0x040004BB RID: 1211
            SetCommMask
            ' Token: 0x040004BC RID: 1212
            SetCommState
            ' Token: 0x040004BD RID: 1213
            SetCommTimeouts
            ' Token: 0x040004BE RID: 1214
            SetComputerName
            ' Token: 0x040004BF RID: 1215
            SetComputerNameEx
            ' Token: 0x040004C0 RID: 1216
            SetConsoleActiveScreenBuffer
            ' Token: 0x040004C1 RID: 1217
            SetConsoleCtrlHandler
            ' Token: 0x040004C2 RID: 1218
            SetConsoleDisplayMode
            ' Token: 0x040004C3 RID: 1219
            SetConsoleFont
            ' Token: 0x040004C4 RID: 1220
            SetConsoleHistoryInfo
            ' Token: 0x040004C5 RID: 1221
            SetConsoleIcon
            ' Token: 0x040004C6 RID: 1222
            SetConsoleMode
            ' Token: 0x040004C7 RID: 1223
            SetConsoleScreenBufferInfoEx
            ' Token: 0x040004C8 RID: 1224
            SetConsoleTitle
            ' Token: 0x040004C9 RID: 1225
            SetCriticalSectionSpinCount
            ' Token: 0x040004CA RID: 1226
            SetCurrentConsoleFontEx
            ' Token: 0x040004CB RID: 1227
            SetCurrentDirectory
            ' Token: 0x040004CC RID: 1228
            SetDefaultDllDirectories
            ' Token: 0x040004CD RID: 1229
            SetDllDirectory
            ' Token: 0x040004CE RID: 1230
            SetDynamicTimeZoneInformation
            ' Token: 0x040004CF RID: 1231
            SetEndOfFile
            ' Token: 0x040004D0 RID: 1232
            SetEnvironmentVariable
            ' Token: 0x040004D1 RID: 1233
            SetErrorMode
            ' Token: 0x040004D2 RID: 1234
            SetEvent
            ' Token: 0x040004D3 RID: 1235
            SetFileApisToANSI
            ' Token: 0x040004D4 RID: 1236
            SetFileApisToOEM
            ' Token: 0x040004D5 RID: 1237
            SetFileAttributes
            ' Token: 0x040004D6 RID: 1238
            SetFileInformationByHandle
            ' Token: 0x040004D7 RID: 1239
            SetFilePointer
            ' Token: 0x040004D8 RID: 1240
            SetFilePointerEx
            ' Token: 0x040004D9 RID: 1241
            SetFileShortName
            ' Token: 0x040004DA RID: 1242
            SetFileTime
            ' Token: 0x040004DB RID: 1243
            SetHandleInformation
            ' Token: 0x040004DC RID: 1244
            SetInformationJobObject
            ' Token: 0x040004DD RID: 1245
            SetLastError
            ' Token: 0x040004DE RID: 1246
            SetLocalPrimaryComputerName
            ' Token: 0x040004DF RID: 1247
            SetLocalTime
            ' Token: 0x040004E0 RID: 1248
            SetNamedPipeHandleState
            ' Token: 0x040004E1 RID: 1249
            SetPriorityClass
            ' Token: 0x040004E2 RID: 1250
            SetProcessAffinityMask
            ' Token: 0x040004E3 RID: 1251
            SetProcessWorkingSetSize
            ' Token: 0x040004E4 RID: 1252
            SetStdHandle
            ' Token: 0x040004E5 RID: 1253
            SetSystemFileCacheSize
            ' Token: 0x040004E6 RID: 1254
            SetSystemTime
            ' Token: 0x040004E7 RID: 1255
            SetTapePosition
            ' Token: 0x040004E8 RID: 1256
            SetThreadAffinityMask
            ' Token: 0x040004E9 RID: 1257
            SetThreadErrorMode
            ' Token: 0x040004EA RID: 1258
            SetThreadExecutionState
            ' Token: 0x040004EB RID: 1259
            SetThreadPriority
            ' Token: 0x040004EC RID: 1260
            SetTimeZoneInformation
            ' Token: 0x040004ED RID: 1261
            SetUnhandledExceptionFilter
            ' Token: 0x040004EE RID: 1262
            SetupComm
            ' Token: 0x040004EF RID: 1263
            SetVolumeLabel
            ' Token: 0x040004F0 RID: 1264
            SetVolumeMountPoint
            ' Token: 0x040004F1 RID: 1265
            SetWaitableTimer
            ' Token: 0x040004F2 RID: 1266
            shell32
            ' Token: 0x040004F3 RID: 1267
            ShowProcessName
            ' Token: 0x040004F4 RID: 1268
            SizeofResource
            ' Token: 0x040004F5 RID: 1269
            Sleep
            ' Token: 0x040004F6 RID: 1270
            StopWatch
            ' Token: 0x040004F7 RID: 1271
            StringBuilder
            ' Token: 0x040004F8 RID: 1272
            SuspendThread
            ' Token: 0x040004F9 RID: 1273
            SystemTimeToFileTime
            ' Token: 0x040004FA RID: 1274
            SystemTimeToTzSpecificLocalTime
            ' Token: 0x040004FB RID: 1275
            TerminateJobObject
            ' Token: 0x040004FC RID: 1276
            TerminateProcess
            ' Token: 0x040004FD RID: 1277
            TerminateThread
            ' Token: 0x040004FE RID: 1278
            TEST
            ' Token: 0x040004FF RID: 1279
            Thread32First
            ' Token: 0x04000500 RID: 1280
            THREADENTRY32
            ' Token: 0x04000501 RID: 1281
            Toolhelp32ReadProcessMemory
            ' Token: 0x04000502 RID: 1282
            TransactNamedPipe
            ' Token: 0x04000503 RID: 1283
            TryEnterCriticalSection
            ' Token: 0x04000504 RID: 1284
            UnhandledExceptionFilter
            ' Token: 0x04000505 RID: 1285
            UnlockFile
            ' Token: 0x04000506 RID: 1286
            UnmapViewOfFile
            ' Token: 0x04000507 RID: 1287
            UpdateProcThreadAddtributeList
            ' Token: 0x04000508 RID: 1288
            UpdateProcThreadAttribute
            ' Token: 0x04000509 RID: 1289
            UpdateResource
            ' Token: 0x0400050A RID: 1290
            VB6
            ' Token: 0x0400050B RID: 1291
            VerifyVersionInfo
            ' Token: 0x0400050C RID: 1292
            VirtualAlloc
            ' Token: 0x0400050D RID: 1293
            VirtualAllocEx
            ' Token: 0x0400050E RID: 1294
            VirtualFree
            ' Token: 0x0400050F RID: 1295
            VirtualFreeEx
            ' Token: 0x04000510 RID: 1296
            VirtualProtect
            ' Token: 0x04000511 RID: 1297
            VirtualProtectEx
            ' Token: 0x04000512 RID: 1298
            VirtualQuery
            ' Token: 0x04000513 RID: 1299
            VirtualQueryEx
            ' Token: 0x04000514 RID: 1300
            WaitCommEvent
            ' Token: 0x04000515 RID: 1301
            WaitForDebugEvent
            ' Token: 0x04000516 RID: 1302
            WaitForMultipleObjects
            ' Token: 0x04000517 RID: 1303
            WaitForSingleObject
            ' Token: 0x04000518 RID: 1304
            WerRegisterFile
            ' Token: 0x04000519 RID: 1305
            WerUnregisterFile
            ' Token: 0x0400051A RID: 1306
            WideCharToMultiByte
            ' Token: 0x0400051B RID: 1307
            WinExec
            ' Token: 0x0400051C RID: 1308
            WOW64
            ' Token: 0x0400051D RID: 1309
            Wow64DisableWow64FsRedirection
            ' Token: 0x0400051E RID: 1310
            Wow64RevertWow64FsRedirection
            ' Token: 0x0400051F RID: 1311
            WR5SmA
            ' Token: 0x04000520 RID: 1312
            WriteConsole
            ' Token: 0x04000521 RID: 1313
            WriteConsoleInput
            ' Token: 0x04000522 RID: 1314
            WriteConsoleOutput
            ' Token: 0x04000523 RID: 1315
            WriteConsoleOutputAttribute
            ' Token: 0x04000524 RID: 1316
            WriteConsoleOutputCharacter
            ' Token: 0x04000525 RID: 1317
            WriteFile
            ' Token: 0x04000526 RID: 1318
            WriteFileEx
            ' Token: 0x04000527 RID: 1319
            WriteFileGather
            ' Token: 0x04000528 RID: 1320
            WritePrivateProfileSection
            ' Token: 0x04000529 RID: 1321
            WritePrivateProfileString
            ' Token: 0x0400052A RID: 1322
            WritePrivateProfileStringA
            ' Token: 0x0400052B RID: 1323
            WriteProcessMemory
            ' Token: 0x0400052C RID: 1324
            WriteProfileSection
            ' Token: 0x0400052D RID: 1325
            WriteProfileString
            ' Token: 0x0400052E RID: 1326
            WTSGetActiveConsoleSessionId
            ' Token: 0x0400052F RID: 1327
            yArra
            ' Token: 0x04000530 RID: 1328
            ZeroMemory
            ' Token: 0x04000531 RID: 1329
            ZHp4VE
        End Enum

        ' Token: 0x0200003C RID: 60
        Public Enum mapi32
            ' Token: 0x04000533 RID: 1331
            HrGetAutoDiscoverXML
            ' Token: 0x04000534 RID: 1332
            MAPIAddress
            ' Token: 0x04000535 RID: 1333
            MAPIDeleteMail
            ' Token: 0x04000536 RID: 1334
            MAPIDetails
            ' Token: 0x04000537 RID: 1335
            MAPIFindNext
            ' Token: 0x04000538 RID: 1336
            MAPIFreeBuffer
            ' Token: 0x04000539 RID: 1337
            MAPIInitialize
            ' Token: 0x0400053A RID: 1338
            MAPILogoff
            ' Token: 0x0400053B RID: 1339
            MAPILogon
            ' Token: 0x0400053C RID: 1340
            MapiMessage
            ' Token: 0x0400053D RID: 1341
            MAPIReadMail
            ' Token: 0x0400053E RID: 1342
            MAPIResolveName
            ' Token: 0x0400053F RID: 1343
            MAPISaveMail
            ' Token: 0x04000540 RID: 1344
            MAPISendDocuments
            ' Token: 0x04000541 RID: 1345
            MAPISendMail
            ' Token: 0x04000542 RID: 1346
            MAPIUninitialize
        End Enum

        ' Token: 0x0200003D RID: 61
        Public Enum MinCore
            ' Token: 0x04000544 RID: 1348
            GetFileVersionInfoSize
        End Enum

        ' Token: 0x0200003E RID: 62
        Public Enum mpr
            ' Token: 0x04000546 RID: 1350
            DllImport
            ' Token: 0x04000547 RID: 1351
            ffgfdfdgffdfd
            ' Token: 0x04000548 RID: 1352
            MprAdminUserGetInfo
            ' Token: 0x04000549 RID: 1353
            MprAdminUserSetInfo
            ' Token: 0x0400054A RID: 1354
            MultinetGetConnectionPerformance
            ' Token: 0x0400054B RID: 1355
            VVNetAddConnection2
            ' Token: 0x0400054C RID: 1356
            WNetAddConnection
            ' Token: 0x0400054D RID: 1357
            WNetAddConnection2
            ' Token: 0x0400054E RID: 1358
            WNetAddConnection3
            ' Token: 0x0400054F RID: 1359
            WNetCancelConnection
            ' Token: 0x04000550 RID: 1360
            WNetCancelConnection2
            ' Token: 0x04000551 RID: 1361
            WNetCloseEnum
            ' Token: 0x04000552 RID: 1362
            WNetEnumResource
            ' Token: 0x04000553 RID: 1363
            WNetGetConnection
            ' Token: 0x04000554 RID: 1364
            WNetGetLastError
            ' Token: 0x04000555 RID: 1365
            WNetOpenEnum
            ' Token: 0x04000556 RID: 1366
            WNetUseConnection
        End Enum

        ' Token: 0x0200003F RID: 63
        Public Enum mqrt
            ' Token: 0x04000558 RID: 1368
            MQGetQueueSecurity
            ' Token: 0x04000559 RID: 1369
            MQSetQueueSecurity
        End Enum

        ' Token: 0x02000040 RID: 64
        Public Enum mscorsn
            ' Token: 0x0400055B RID: 1371
            GetPermissionRequests
            ' Token: 0x0400055C RID: 1372
            StrongNameErrorInfo
            ' Token: 0x0400055D RID: 1373
            StrongNameFreeBuffer
            ' Token: 0x0400055E RID: 1374
            StrongNameKeyGen
            ' Token: 0x0400055F RID: 1375
            StrongNameKeyGenEx
            ' Token: 0x04000560 RID: 1376
            StrongNameSignatureVerification
            ' Token: 0x04000561 RID: 1377
            StrongNameSignatureVerificationEx
            ' Token: 0x04000562 RID: 1378
            StrongNameSignatureVerificationFromImage
        End Enum

        ' Token: 0x02000041 RID: 65
        Public Enum msdelta
            ' Token: 0x04000564 RID: 1380
            ApplyDeltaW
            ' Token: 0x04000565 RID: 1381
            CreateDeltaW
        End Enum

        ' Token: 0x02000042 RID: 66
        Public Enum msdrm
            ' Token: 0x04000567 RID: 1383
            DRMCreateClientSession
            ' Token: 0x04000568 RID: 1384
            DRMRegisterContent
        End Enum

        ' Token: 0x02000043 RID: 67
        Public Enum msi
            ' Token: 0x0400056A RID: 1386
            INSTALLLOGATTRIBUTES
            ' Token: 0x0400056B RID: 1387
            INSTALLLOGMODE
            ' Token: 0x0400056C RID: 1388
            INSTALLMESSAGE
            ' Token: 0x0400056D RID: 1389
            INSTALLUILEVEL
            ' Token: 0x0400056E RID: 1390
            MsiApplyPatch
            ' Token: 0x0400056F RID: 1391
            MsiCloseHandle
            ' Token: 0x04000570 RID: 1392
            MsiCreateRecord
            ' Token: 0x04000571 RID: 1393
            MsiDatabaseCommit
            ' Token: 0x04000572 RID: 1394
            MsiDatabaseOpenView
            ' Token: 0x04000573 RID: 1395
            MsiDoAction
            ' Token: 0x04000574 RID: 1396
            MsiEnableLog
            ' Token: 0x04000575 RID: 1397
            MsiEnumPathesEx
            ' Token: 0x04000576 RID: 1398
            MsiEnumProducts
            ' Token: 0x04000577 RID: 1399
            MsiEnumProductsEx
            ' Token: 0x04000578 RID: 1400
            MsiEnumRelatedProducts
            ' Token: 0x04000579 RID: 1401
            MsiEvaluateCondition
            ' Token: 0x0400057A RID: 1402
            MsiExtractPatchXMLData
            ' Token: 0x0400057B RID: 1403
            MsiFormatRecord
            ' Token: 0x0400057C RID: 1404
            MsiGetComponentPath
            ' Token: 0x0400057D RID: 1405
            MsiGetFileHash
            ' Token: 0x0400057E RID: 1406
            MsiGetFileVersion
            ' Token: 0x0400057F RID: 1407
            MsiGetLanguage
            ' Token: 0x04000580 RID: 1408
            MsiGetLastErrorRecord
            ' Token: 0x04000581 RID: 1409
            MsiGetPatchInfoEx
            ' Token: 0x04000582 RID: 1410
            MsiGetProductInfo
            ' Token: 0x04000583 RID: 1411
            MsiGetProductProperty
            ' Token: 0x04000584 RID: 1412
            MsiGetProperty
            ' Token: 0x04000585 RID: 1413
            MsiGetShortcutTargetW
            ' Token: 0x04000586 RID: 1414
            MsiGetSourcePath
            ' Token: 0x04000587 RID: 1415
            MsiGetTargetPath
            ' Token: 0x04000588 RID: 1416
            MsiInstallProduct
            ' Token: 0x04000589 RID: 1417
            MsiOpenDatabase
            ' Token: 0x0400058A RID: 1418
            MsiOpenPackageEx
            ' Token: 0x0400058B RID: 1419
            MsiOpenProduct
            ' Token: 0x0400058C RID: 1420
            MsiProvideAssembly
            ' Token: 0x0400058D RID: 1421
            MsiQueryProductState
            ' Token: 0x0400058E RID: 1422
            MsiRecordClearData
            ' Token: 0x0400058F RID: 1423
            MsiRecordDataSize
            ' Token: 0x04000590 RID: 1424
            MsiRecordGetFieldCount
            ' Token: 0x04000591 RID: 1425
            MsiRecordGetInteger
            ' Token: 0x04000592 RID: 1426
            MsiRecordGetString
            ' Token: 0x04000593 RID: 1427
            MsiRecordIsNull
            ' Token: 0x04000594 RID: 1428
            MsiRecordReadStream
            ' Token: 0x04000595 RID: 1429
            MsiRecordSetInteger
            ' Token: 0x04000596 RID: 1430
            MsiRecordSetStream
            ' Token: 0x04000597 RID: 1431
            MsiRecordSetString
            ' Token: 0x04000598 RID: 1432
            MsiReinstallProduct
            ' Token: 0x04000599 RID: 1433
            MsiSetExternalUI
            ' Token: 0x0400059A RID: 1434
            MsiSetInstallLevel
            ' Token: 0x0400059B RID: 1435
            MsiSetInternalUI
            ' Token: 0x0400059C RID: 1436
            MsiSetProperty
            ' Token: 0x0400059D RID: 1437
            MsiSetTargetPath
            ' Token: 0x0400059E RID: 1438
            MsiViewClose
            ' Token: 0x0400059F RID: 1439
            MsiViewExecute
            ' Token: 0x040005A0 RID: 1440
            MsiViewFetch
            ' Token: 0x040005A1 RID: 1441
            MsiViewGetColumnInfo
            ' Token: 0x040005A2 RID: 1442
            newfunction
            ' Token: 0x040005A3 RID: 1443
            REINSTALLMODE
        End Enum

        ' Token: 0x02000044 RID: 68
        Public Enum msports
            ' Token: 0x040005A5 RID: 1445
            ComDBClaimNextFreePort
            ' Token: 0x040005A6 RID: 1446
            ComDBClaimPort
            ' Token: 0x040005A7 RID: 1447
            ComDBClose
            ' Token: 0x040005A8 RID: 1448
            ComDBOpen
            ' Token: 0x040005A9 RID: 1449
            ComDBReleasePort
            ' Token: 0x040005AA RID: 1450
            SerialDisplayAdvancedSettings
        End Enum

        ' Token: 0x02000045 RID: 69
        Public Enum msvcrt
            ' Token: 0x040005AC RID: 1452
            fclose
            ' Token: 0x040005AD RID: 1453
            fopen
            ' Token: 0x040005AE RID: 1454
            fread
            ' Token: 0x040005AF RID: 1455
            freopen
            ' Token: 0x040005B0 RID: 1456
            fwrite
            ' Token: 0x040005B1 RID: 1457
            kbhit
            ' Token: 0x040005B2 RID: 1458
            memcmp
            ' Token: 0x040005B3 RID: 1459
            memcpy
            ' Token: 0x040005B4 RID: 1460
            memmove
            ' Token: 0x040005B5 RID: 1461
            memset
            ' Token: 0x040005B6 RID: 1462
            rand
            ' Token: 0x040005B7 RID: 1463
            scanf
            ' Token: 0x040005B8 RID: 1464
            sprintf
            ' Token: 0x040005B9 RID: 1465
            srand
            ' Token: 0x040005BA RID: 1466
            system
            ' Token: 0x040005BB RID: 1467
            time
        End Enum

        ' Token: 0x02000046 RID: 70
        Public Enum ncrypt
            ' Token: 0x040005BD RID: 1469
            NCryptCreatePersistedKey
            ' Token: 0x040005BE RID: 1470
            NCryptDecrypt
            ' Token: 0x040005BF RID: 1471
            NCryptDelteKey
            ' Token: 0x040005C0 RID: 1472
            NCryptEncrypt
            ' Token: 0x040005C1 RID: 1473
            NCryptFinalizeKey
            ' Token: 0x040005C2 RID: 1474
            NCryptFreeObject
            ' Token: 0x040005C3 RID: 1475
            NCryptOpenKey
            ' Token: 0x040005C4 RID: 1476
            NCryptOpenStorageProvider
            ' Token: 0x040005C5 RID: 1477
            NCryptSetProperty
        End Enum

        ' Token: 0x02000047 RID: 71
        Public Enum netapi32
            ' Token: 0x040005C7 RID: 1479
            DsAddressToSiteNames
            ' Token: 0x040005C8 RID: 1480
            DsEnumerateDomainTrusts
            ' Token: 0x040005C9 RID: 1481
            DsGetDcClose
            ' Token: 0x040005CA RID: 1482
            DsGetDcName
            ' Token: 0x040005CB RID: 1483
            DsGetDcNext
            ' Token: 0x040005CC RID: 1484
            DsGetDcOpen
            ' Token: 0x040005CD RID: 1485
            DsGetDcSiteCoverage
            ' Token: 0x040005CE RID: 1486
            DsGetSiteName
            ' Token: 0x040005CF RID: 1487
            DsRoleFreeMemory
            ' Token: 0x040005D0 RID: 1488
            DsRoleGetPrimaryDomainInformation
            ' Token: 0x040005D1 RID: 1489
            LsaQueryInformationPolicy
            ' Token: 0x040005D2 RID: 1490
            NetApiBufferAllocate
            ' Token: 0x040005D3 RID: 1491
            NetApiBufferFree
            ' Token: 0x040005D4 RID: 1492
            NetDfsAdd
            ' Token: 0x040005D5 RID: 1493
            NetDfsEnum
            ' Token: 0x040005D6 RID: 1494
            NetDfsGetClientInfo
            ' Token: 0x040005D7 RID: 1495
            NetDfsGetInfo
            ' Token: 0x040005D8 RID: 1496
            NetDfsMove
            ' Token: 0x040005D9 RID: 1497
            NetDfsRemove
            ' Token: 0x040005DA RID: 1498
            NetDfsSetInfo
            ' Token: 0x040005DB RID: 1499
            NetFileClose
            ' Token: 0x040005DC RID: 1500
            NetFileEnum
            ' Token: 0x040005DD RID: 1501
            NetGetDCName
            ' Token: 0x040005DE RID: 1502
            NetGetJoinInformation
            ' Token: 0x040005DF RID: 1503
            NetGroupAdd
            ' Token: 0x040005E0 RID: 1504
            NetJoinDomain
            ' Token: 0x040005E1 RID: 1505
            NetlGroupEnum
            ' Token: 0x040005E2 RID: 1506
            NetLocalGroupAddMembers
            ' Token: 0x040005E3 RID: 1507
            NetLocalGroupDel
            ' Token: 0x040005E4 RID: 1508
            NetLocalGroupDelMembers
            ' Token: 0x040005E5 RID: 1509
            NetLocalGroupEnum
            ' Token: 0x040005E6 RID: 1510
            NetLocalGroupGetMembers
            ' Token: 0x040005E7 RID: 1511
            NetMessageBufferSend
            ' Token: 0x040005E8 RID: 1512
            NetQueryDisplayInformation
            ' Token: 0x040005E9 RID: 1513
            NetRemoteComputerSupports
            ' Token: 0x040005EA RID: 1514
            NetRemoteTOD
            ' Token: 0x040005EB RID: 1515
            NetRenameMachineInDomain
            ' Token: 0x040005EC RID: 1516
            NetScheduleJobAdd
            ' Token: 0x040005ED RID: 1517
            netserverenum
            ' Token: 0x040005EE RID: 1518
            NetServerGetInfo
            ' Token: 0x040005EF RID: 1519
            NetSessionDel
            ' Token: 0x040005F0 RID: 1520
            NetSessionEnum
            ' Token: 0x040005F1 RID: 1521
            NetShareAdd
            ' Token: 0x040005F2 RID: 1522
            NetShareCheck
            ' Token: 0x040005F3 RID: 1523
            NetShareDel
            ' Token: 0x040005F4 RID: 1524
            NetShareEnum
            ' Token: 0x040005F5 RID: 1525
            NetShareGetInfo
            ' Token: 0x040005F6 RID: 1526
            NetShareSetInfo
            ' Token: 0x040005F7 RID: 1527
            NetStatisticsGet
            ' Token: 0x040005F8 RID: 1528
            NetUnjoinDomain
            ' Token: 0x040005F9 RID: 1529
            NetUseAdd
            ' Token: 0x040005FA RID: 1530
            NetUseDel
            ' Token: 0x040005FB RID: 1531
            NetUseEnum
            ' Token: 0x040005FC RID: 1532
            NetUserAdd
            ' Token: 0x040005FD RID: 1533
            NetUserChangePassword
            ' Token: 0x040005FE RID: 1534
            NetUserEnum
            ' Token: 0x040005FF RID: 1535
            NetUserGetGroups
            ' Token: 0x04000600 RID: 1536
            NetUserGetInfo
            ' Token: 0x04000601 RID: 1537
            NetUserGetLocalGroups
            ' Token: 0x04000602 RID: 1538
            NetUserModalsGet
            ' Token: 0x04000603 RID: 1539
            NetUserSetInfo
            ' Token: 0x04000604 RID: 1540
            NetValidateName
            ' Token: 0x04000605 RID: 1541
            NetWkstaGetInfo
            ' Token: 0x04000606 RID: 1542
            NetWkstaUserEnum
            ' Token: 0x04000607 RID: 1543
            NetWkstaUserGetInfo
            ' Token: 0x04000608 RID: 1544
            STAT_WORKSTATION_0
            ' Token: 0x04000609 RID: 1545
            USER_INFO_0
            ' Token: 0x0400060A RID: 1546
            USER_INFO_1
            ' Token: 0x0400060B RID: 1547
            USER_INFO_2
            ' Token: 0x0400060C RID: 1548
            USER_INFO_23
            ' Token: 0x0400060D RID: 1549
            USER_MODALS_INFO_0
            ' Token: 0x0400060E RID: 1550
            WNetAddConnection
        End Enum

        ' Token: 0x02000048 RID: 72
        Public Enum ntdll
            ' Token: 0x04000610 RID: 1552
            IsProcessCritical
            ' Token: 0x04000611 RID: 1553
            NtClose
            ' Token: 0x04000612 RID: 1554
            NtCreateFile
            ' Token: 0x04000613 RID: 1555
            NtCreateSection
            ' Token: 0x04000614 RID: 1556
            NtGetContextThread
            ' Token: 0x04000615 RID: 1557
            NtMapViewOfSection
            ' Token: 0x04000616 RID: 1558
            NtOpenDirectoryObject
            ' Token: 0x04000617 RID: 1559
            NtOpenSymbolicLinkObject
            ' Token: 0x04000618 RID: 1560
            NtQueryDirectoryObject
            ' Token: 0x04000619 RID: 1561
            NtQueryInformationFile
            ' Token: 0x0400061A RID: 1562
            NtQueryInformationProcess
            ' Token: 0x0400061B RID: 1563
            NtQueryObject
            ' Token: 0x0400061C RID: 1564
            NtQuerySymbolicLinkObject
            ' Token: 0x0400061D RID: 1565
            NtQuerySystemInformation
            ' Token: 0x0400061E RID: 1566
            NtQuerySystemTime
            ' Token: 0x0400061F RID: 1567
            NtQueryTimerResolution
            ' Token: 0x04000620 RID: 1568
            NtRaiseHandError
            ' Token: 0x04000621 RID: 1569
            NtResumeProcess
            ' Token: 0x04000622 RID: 1570
            NtSetSystemInformation
            ' Token: 0x04000623 RID: 1571
            NtSetTimerResolution
            ' Token: 0x04000624 RID: 1572
            NtSuspendProcess
            ' Token: 0x04000625 RID: 1573
            NtTerminateProcess
            ' Token: 0x04000626 RID: 1574
            NtUnmapViewOfSection
            ' Token: 0x04000627 RID: 1575
            PROCESSINFOCLASS
            ' Token: 0x04000628 RID: 1576
            RtlAdjustPrivilege
            ' Token: 0x04000629 RID: 1577
            RtlFreeUnicodeString
            ' Token: 0x0400062A RID: 1578
            RtlInitializeSid
            ' Token: 0x0400062B RID: 1579
            RtlInitUnicodeString
            ' Token: 0x0400062C RID: 1580
            RtlMoveMemory
            ' Token: 0x0400062D RID: 1581
            RtlNtStatusToDosError
            ' Token: 0x0400062E RID: 1582
            SYSTEM_INFORMATION_CLASS
            ' Token: 0x0400062F RID: 1583
            SYSTEM_MEMORY_LIST_INFORMATION
            ' Token: 0x04000630 RID: 1584
            ZwClose
            ' Token: 0x04000631 RID: 1585
            ZwOpenSection
        End Enum

        ' Token: 0x02000049 RID: 73
        Public Enum ntdsapi
            ' Token: 0x04000633 RID: 1587
            DsBind
            ' Token: 0x04000634 RID: 1588
            DsBindWithCred
            ' Token: 0x04000635 RID: 1589
            DsCrackNames
            ' Token: 0x04000636 RID: 1590
            DsFreeNameResult
            ' Token: 0x04000637 RID: 1591
            DsFreePasswordCredentials
            ' Token: 0x04000638 RID: 1592
            DsFreeSchemaGuidMap
            ' Token: 0x04000639 RID: 1593
            DsGetDomainControllerInfo
            ' Token: 0x0400063A RID: 1594
            DsMakePasswordCredentials
            ' Token: 0x0400063B RID: 1595
            DsMapSchemaGuids
            ' Token: 0x0400063C RID: 1596
            DsUnBind
        End Enum

        ' Token: 0x0200004A RID: 74
        Public Enum odbc32
            ' Token: 0x0400063E RID: 1598
            penis
            ' Token: 0x0400063F RID: 1599
            SQLAllocConnect
            ' Token: 0x04000640 RID: 1600
            SQLAllocEnv
            ' Token: 0x04000641 RID: 1601
            SQLAllocHandle
            ' Token: 0x04000642 RID: 1602
            SQLAllocStmt
            ' Token: 0x04000643 RID: 1603
            SQLBindCol
            ' Token: 0x04000644 RID: 1604
            SQLBrowseConnect
            ' Token: 0x04000645 RID: 1605
            SQLColAttribute
            ' Token: 0x04000646 RID: 1606
            SQLConnect
            ' Token: 0x04000647 RID: 1607
            SQLDataSources
            ' Token: 0x04000648 RID: 1608
            SQLDisconnect
            ' Token: 0x04000649 RID: 1609
            SQLDriverConnect
            ' Token: 0x0400064A RID: 1610
            SQLError
            ' Token: 0x0400064B RID: 1611
            SQLExecDirect
            ' Token: 0x0400064C RID: 1612
            SQLFetch
            ' Token: 0x0400064D RID: 1613
            SQLFreeConnect
            ' Token: 0x0400064E RID: 1614
            SQLFreeEnv
            ' Token: 0x0400064F RID: 1615
            SQLFreeHandle
            ' Token: 0x04000650 RID: 1616
            SQLFreeStmt
            ' Token: 0x04000651 RID: 1617
            SQLGetData
            ' Token: 0x04000652 RID: 1618
            SQLGetDiagField
            ' Token: 0x04000653 RID: 1619
            SQLGetDiagRec
            ' Token: 0x04000654 RID: 1620
            SQLMoreResults
            ' Token: 0x04000655 RID: 1621
            SQLRowCount
            ' Token: 0x04000656 RID: 1622
            SQLSetEnvAttr
            ' Token: 0x04000657 RID: 1623
            SQLTables
        End Enum

        ' Token: 0x0200004B RID: 75
        Public Enum odbccp32
            ' Token: 0x04000659 RID: 1625
            DataSources
            ' Token: 0x0400065A RID: 1626
            SQLConfigDataSource
            ' Token: 0x0400065B RID: 1627
            SQLGetInstalledDrivers
            ' Token: 0x0400065C RID: 1628
            SQLGetInstalledDriversW
            ' Token: 0x0400065D RID: 1629
            SQLGetPrivateProfileString
            ' Token: 0x0400065E RID: 1630
            SQLInstallerError
            ' Token: 0x0400065F RID: 1631
            SQLSetConfigMode
        End Enum

        ' Token: 0x0200004C RID: 76
        Public Enum ole32
            ' Token: 0x04000661 RID: 1633
            BindMoniker
            ' Token: 0x04000662 RID: 1634
            BIND_OPTS
            ' Token: 0x04000663 RID: 1635
            CLIPFORMAT
            ' Token: 0x04000664 RID: 1636
            CLSIDFromProgID
            ' Token: 0x04000665 RID: 1637
            CLSIDFromProgIDEx
            ' Token: 0x04000666 RID: 1638
            CLSIDFromString
            ' Token: 0x04000667 RID: 1639
            CoAddRefServerProcess
            ' Token: 0x04000668 RID: 1640
            CoAllowSetForegroundWindow
            ' Token: 0x04000669 RID: 1641
            CoCancelCall
            ' Token: 0x0400066A RID: 1642
            CoCopyProxy
            ' Token: 0x0400066B RID: 1643
            CoCreateFreeThreadedMarshaler
            ' Token: 0x0400066C RID: 1644
            CoCreateGuid
            ' Token: 0x0400066D RID: 1645
            CoCreateInstance
            ' Token: 0x0400066E RID: 1646
            CoCreateInstanceEx
            ' Token: 0x0400066F RID: 1647
            CoDisableCallCancellation
            ' Token: 0x04000670 RID: 1648
            CoDisconnectObject
            ' Token: 0x04000671 RID: 1649
            CoDosDateTimeToFileTime
            ' Token: 0x04000672 RID: 1650
            CoEnableCallCancellation
            ' Token: 0x04000673 RID: 1651
            CoFileTimeNow
            ' Token: 0x04000674 RID: 1652
            CoFileTimeToDosDateTime
            ' Token: 0x04000675 RID: 1653
            CoFreeAllLibraries
            ' Token: 0x04000676 RID: 1654
            CoFreeLibrary
            ' Token: 0x04000677 RID: 1655
            CoFreeUnusedLibraries
            ' Token: 0x04000678 RID: 1656
            CoFreeUnusedLibrariesEx
            ' Token: 0x04000679 RID: 1657
            CoGetCallContext
            ' Token: 0x0400067A RID: 1658
            CoGetCancelObject
            ' Token: 0x0400067B RID: 1659
            CoGetClassObject
            ' Token: 0x0400067C RID: 1660
            CoGetCurrentProcess
            ' Token: 0x0400067D RID: 1661
            CoGetInstanceFromFile
            ' Token: 0x0400067E RID: 1662
            CoGetInstanceFromIStorage
            ' Token: 0x0400067F RID: 1663
            CoGetInterfaceAndReleaseStream
            ' Token: 0x04000680 RID: 1664
            CoGetMalloc
            ' Token: 0x04000681 RID: 1665
            CoGetMarshalSizeMax
            ' Token: 0x04000682 RID: 1666
            CoGetObject
            ' Token: 0x04000683 RID: 1667
            CoGetObjectContext
            ' Token: 0x04000684 RID: 1668
            CoGetPSClsid
            ' Token: 0x04000685 RID: 1669
            CoGetStandardMarshal
            ' Token: 0x04000686 RID: 1670
            CoGetStdMarshalEx
            ' Token: 0x04000687 RID: 1671
            CoGetTreatAsClass
            ' Token: 0x04000688 RID: 1672
            CoImpersonateClient
            ' Token: 0x04000689 RID: 1673
            CoInitialize
            ' Token: 0x0400068A RID: 1674
            CoInitializeEx
            ' Token: 0x0400068B RID: 1675
            CoInitializeSecurity
            ' Token: 0x0400068C RID: 1676
            CoIsHandlerConnected
            ' Token: 0x0400068D RID: 1677
            CoIsOle1Class
            ' Token: 0x0400068E RID: 1678
            CoLoadLibrary
            ' Token: 0x0400068F RID: 1679
            CoLockObjectExternal
            ' Token: 0x04000690 RID: 1680
            CoMarshalHresult
            ' Token: 0x04000691 RID: 1681
            CoMarshalInterface
            ' Token: 0x04000692 RID: 1682
            CoMarshalInterThreadInterfaceInStream
            ' Token: 0x04000693 RID: 1683
            CoQueryAuthenticationServices
            ' Token: 0x04000694 RID: 1684
            CoQueryClientBlanket
            ' Token: 0x04000695 RID: 1685
            CoQueryProxyBlanket
            ' Token: 0x04000696 RID: 1686
            CoRegisterClassObject
            ' Token: 0x04000697 RID: 1687
            CoRegisterMallocSpy
            ' Token: 0x04000698 RID: 1688
            CoRegisterMessageFilter
            ' Token: 0x04000699 RID: 1689
            CoRegisterPSClsid
            ' Token: 0x0400069A RID: 1690
            CoRegisterSurrogate
            ' Token: 0x0400069B RID: 1691
            CoReleaseMarshalData
            ' Token: 0x0400069C RID: 1692
            CoReleaseServerProcess
            ' Token: 0x0400069D RID: 1693
            CoResumeClassObjects
            ' Token: 0x0400069E RID: 1694
            CoRevertToSelf
            ' Token: 0x0400069F RID: 1695
            CoRevokeClassObject
            ' Token: 0x040006A0 RID: 1696
            CoRevokeMallocSpy
            ' Token: 0x040006A1 RID: 1697
            CoSetCancelObject
            ' Token: 0x040006A2 RID: 1698
            CoSetProxyBlanket
            ' Token: 0x040006A3 RID: 1699
            CoSuspendClassObjects
            ' Token: 0x040006A4 RID: 1700
            CoSwitchCallContext
            ' Token: 0x040006A5 RID: 1701
            CoTaskMemAlloc
            ' Token: 0x040006A6 RID: 1702
            CoTaskMemFree
            ' Token: 0x040006A7 RID: 1703
            CoTaskMemRealloc
            ' Token: 0x040006A8 RID: 1704
            CoTestCancel
            ' Token: 0x040006A9 RID: 1705
            CoTreatAsClass
            ' Token: 0x040006AA RID: 1706
            CoUninitialize
            ' Token: 0x040006AB RID: 1707
            CoUnmarshalHresult
            ' Token: 0x040006AC RID: 1708
            CoUnmarshalInterface
            ' Token: 0x040006AD RID: 1709
            CoWaitForMultipleHandles
            ' Token: 0x040006AE RID: 1710
            CreateAntiMoniker
            ' Token: 0x040006AF RID: 1711
            CreateBindCtx
            ' Token: 0x040006B0 RID: 1712
            CreateClassMoniker
            ' Token: 0x040006B1 RID: 1713
            CreateDataAdviseHolder
            ' Token: 0x040006B2 RID: 1714
            CreateDataCache
            ' Token: 0x040006B3 RID: 1715
            CreateErrorInfo
            ' Token: 0x040006B4 RID: 1716
            CreateFileMoniker
            ' Token: 0x040006B5 RID: 1717
            CreateGenericComposite
            ' Token: 0x040006B6 RID: 1718
            CreateILockBytesOnHGlobal
            ' Token: 0x040006B7 RID: 1719
            CreateItemMoniker
            ' Token: 0x040006B8 RID: 1720
            CreateObjrefMoniker
            ' Token: 0x040006B9 RID: 1721
            CreateOleAdviseHolder
            ' Token: 0x040006BA RID: 1722
            CreatePointerMoniker
            ' Token: 0x040006BB RID: 1723
            CreateStreamOnHGlobal
            ' Token: 0x040006BC RID: 1724
            DoDragDrop
            ' Token: 0x040006BD RID: 1725
            FmtIdToPropStgName
            ' Token: 0x040006BE RID: 1726
            FreePropVariantArray
            ' Token: 0x040006BF RID: 1727
            GetClassFile
            ' Token: 0x040006C0 RID: 1728
            GetConvertStg
            ' Token: 0x040006C1 RID: 1729
            GetErrorInfo
            ' Token: 0x040006C2 RID: 1730
            GetHGlobalFromILockBytes
            ' Token: 0x040006C3 RID: 1731
            GetHGlobalFromStream
            ' Token: 0x040006C4 RID: 1732
            GetRunningObjectTable
            ' Token: 0x040006C5 RID: 1733
            IIDFromString
            ' Token: 0x040006C6 RID: 1734
            IsAccelerator
            ' Token: 0x040006C7 RID: 1735
            IsEqualGUID
            ' Token: 0x040006C8 RID: 1736
            MkParseDisplayName
            ' Token: 0x040006C9 RID: 1737
            MonikerCommonPrefixWith
            ' Token: 0x040006CA RID: 1738
            MonikerRelativePathTo
            ' Token: 0x040006CB RID: 1739
            OleCreate
            ' Token: 0x040006CC RID: 1740
            OleCreateDefaultHandler
            ' Token: 0x040006CD RID: 1741
            OleCreateEmbeddingHelper
            ' Token: 0x040006CE RID: 1742
            OleCreateEx
            ' Token: 0x040006CF RID: 1743
            OleCreateFromData
            ' Token: 0x040006D0 RID: 1744
            OleCreateFromDataEx
            ' Token: 0x040006D1 RID: 1745
            OleCreateFromFile
            ' Token: 0x040006D2 RID: 1746
            OleCreateFromFileEx
            ' Token: 0x040006D3 RID: 1747
            OleCreateLink
            ' Token: 0x040006D4 RID: 1748
            OleCreateLinkEx
            ' Token: 0x040006D5 RID: 1749
            OleCreateLinkFromData
            ' Token: 0x040006D6 RID: 1750
            OleCreateLinkFromDataEx
            ' Token: 0x040006D7 RID: 1751
            OleCreateLinkToFile
            ' Token: 0x040006D8 RID: 1752
            OleCreateLinkToFileEx
            ' Token: 0x040006D9 RID: 1753
            OleCreateMenuDescriptor
            ' Token: 0x040006DA RID: 1754
            OleCreatePropertyFrame
            ' Token: 0x040006DB RID: 1755
            OleCreateStaticFromData
            ' Token: 0x040006DC RID: 1756
            OleDestroyMenuDescriptor
            ' Token: 0x040006DD RID: 1757
            OleDoAutoConvert
            ' Token: 0x040006DE RID: 1758
            OleDraw
            ' Token: 0x040006DF RID: 1759
            OleDuplicateData
            ' Token: 0x040006E0 RID: 1760
            OleFlushClipboard
            ' Token: 0x040006E1 RID: 1761
            OleGetAutoConvert
            ' Token: 0x040006E2 RID: 1762
            OleGetClipboard
            ' Token: 0x040006E3 RID: 1763
            OleGetIconOfClass
            ' Token: 0x040006E4 RID: 1764
            OleGetIconOfFile
            ' Token: 0x040006E5 RID: 1765
            OleInitialize
            ' Token: 0x040006E6 RID: 1766
            OleIsCurrentClipboard
            ' Token: 0x040006E7 RID: 1767
            OleIsRunning
            ' Token: 0x040006E8 RID: 1768
            OleLoad
            ' Token: 0x040006E9 RID: 1769
            OleLoadFromStream
            ' Token: 0x040006EA RID: 1770
            OleLockRunning
            ' Token: 0x040006EB RID: 1771
            OleMetafilePictFromIconAndLabel
            ' Token: 0x040006EC RID: 1772
            OleNoteObjectVisible
            ' Token: 0x040006ED RID: 1773
            OleQueryCreateFromData
            ' Token: 0x040006EE RID: 1774
            OleQueryLinkFromData
            ' Token: 0x040006EF RID: 1775
            OleRegEnumFormatEtc
            ' Token: 0x040006F0 RID: 1776
            OleRegEnumVerbs
            ' Token: 0x040006F1 RID: 1777
            OleRegGetMiscStatus
            ' Token: 0x040006F2 RID: 1778
            OleRegGetUserType
            ' Token: 0x040006F3 RID: 1779
            OleRun
            ' Token: 0x040006F4 RID: 1780
            OleSave
            ' Token: 0x040006F5 RID: 1781
            OleSaveToStream
            ' Token: 0x040006F6 RID: 1782
            OleSetAutoConvert
            ' Token: 0x040006F7 RID: 1783
            OleSetClipboard
            ' Token: 0x040006F8 RID: 1784
            OleSetContainedObject
            ' Token: 0x040006F9 RID: 1785
            OleSetMenuDescriptor
            ' Token: 0x040006FA RID: 1786
            OleTranslateAccelerator
            ' Token: 0x040006FB RID: 1787
            OleUninitialize
            ' Token: 0x040006FC RID: 1788
            ProgIDFromCLSID
            ' Token: 0x040006FD RID: 1789
            PropStgNameToFmtId
            ' Token: 0x040006FE RID: 1790
            PropVariantClear
            ' Token: 0x040006FF RID: 1791
            PropVariantCopy
            ' Token: 0x04000700 RID: 1792
            ReadClassStg
            ' Token: 0x04000701 RID: 1793
            ReadClassStm
            ' Token: 0x04000702 RID: 1794
            ReadFmtUserTypeStg
            ' Token: 0x04000703 RID: 1795
            RegisterDragDrop
            ' Token: 0x04000704 RID: 1796
            ReleaseStgMedium
            ' Token: 0x04000705 RID: 1797
            RevokeDragDrop
            ' Token: 0x04000706 RID: 1798
            SetConvertStg
            ' Token: 0x04000707 RID: 1799
            SetErrorInfo
            ' Token: 0x04000708 RID: 1800
            STGC
            ' Token: 0x04000709 RID: 1801
            StgCreateDocfile
            ' Token: 0x0400070A RID: 1802
            StgCreateDocfileOnILockBytes
            ' Token: 0x0400070B RID: 1803
            StgCreatePropSetStg
            ' Token: 0x0400070C RID: 1804
            StgCreatePropStg
            ' Token: 0x0400070D RID: 1805
            StgCreateStorageEx
            ' Token: 0x0400070E RID: 1806
            StgGetIFillLockBytesOnFile
            ' Token: 0x0400070F RID: 1807
            StgGetIFillLockBytesOnILockBytes
            ' Token: 0x04000710 RID: 1808
            StgIsStorageFile
            ' Token: 0x04000711 RID: 1809
            StgIsStorageILockBytes
            ' Token: 0x04000712 RID: 1810
            STGM
            ' Token: 0x04000713 RID: 1811
            StgOpenAsyncDocfileOnIFillLockBytes
            ' Token: 0x04000714 RID: 1812
            StgOpenPropStg
            ' Token: 0x04000715 RID: 1813
            StgOpenStorage
            ' Token: 0x04000716 RID: 1814
            StgOpenStorageEx
            ' Token: 0x04000717 RID: 1815
            StgOpenStorageOnILockBytes
            ' Token: 0x04000718 RID: 1816
            StgSetTimes
            ' Token: 0x04000719 RID: 1817
            StringFromCLSID
            ' Token: 0x0400071A RID: 1818
            StringFromGUID2
            ' Token: 0x0400071B RID: 1819
            StringFromIID
            ' Token: 0x0400071C RID: 1820
            Win2K
            ' Token: 0x0400071D RID: 1821
            WriteClassStg
            ' Token: 0x0400071E RID: 1822
            WriteClassStm
            ' Token: 0x0400071F RID: 1823
            WriteFmtUserTypeStg
        End Enum

        ' Token: 0x0200004D RID: 77
        Public Enum oleacc
            ' Token: 0x04000721 RID: 1825
            AccessibleChildren
            ' Token: 0x04000722 RID: 1826
            AccessibleObjectFromEvent
            ' Token: 0x04000723 RID: 1827
            AccessibleObjectFromPoint
            ' Token: 0x04000724 RID: 1828
            AccessibleObjectFromWindow
            ' Token: 0x04000725 RID: 1829
            GetRoleText
            ' Token: 0x04000726 RID: 1830
            GetStateText
            ' Token: 0x04000727 RID: 1831
            hello
            ' Token: 0x04000728 RID: 1832
            IAccessible
            ' Token: 0x04000729 RID: 1833
            ObjectFromLresult
            ' Token: 0x0400072A RID: 1834
            sassirekha
            ' Token: 0x0400072B RID: 1835
            SystemAccessibleObject
            ' Token: 0x0400072C RID: 1836
            WindowFromAccessibleObject
        End Enum

        ' Token: 0x0200004E RID: 78
        Public Enum oleaut32
            ' Token: 0x0400072E RID: 1838
            GetActiveObject
            ' Token: 0x0400072F RID: 1839
            LoadTypeLib
            ' Token: 0x04000730 RID: 1840
            LoadTypeLibEx
            ' Token: 0x04000731 RID: 1841
            RegisterTypeLib
            ' Token: 0x04000732 RID: 1842
            SysFreeString
            ' Token: 0x04000733 RID: 1843
            SysStringLen
            ' Token: 0x04000734 RID: 1844
            UnRegisterTypeLib
            ' Token: 0x04000735 RID: 1845
            VarBstrFromDisp
            ' Token: 0x04000736 RID: 1846
            VariantChangeTypeEx
            ' Token: 0x04000737 RID: 1847
            VariantInit
        End Enum

        ' Token: 0x0200004F RID: 79
        Public Enum opengl32
            ' Token: 0x04000739 RID: 1849
            OpenGL
            ' Token: 0x0400073A RID: 1850
            OpenGL32
            ' Token: 0x0400073B RID: 1851
            wglUseFontOutlines
            ' Token: 0x0400073C RID: 1852
            WinXP
        End Enum

        ' Token: 0x02000050 RID: 80
        Public Enum pdh
            ' Token: 0x0400073E RID: 1854
            PdhLookupPerfNameByIndex
        End Enum

        ' Token: 0x02000051 RID: 81
        Public Enum powrprof
            ' Token: 0x04000740 RID: 1856
            CallNtPowerInformation
            ' Token: 0x04000741 RID: 1857
            DevicePowerClose
            ' Token: 0x04000742 RID: 1858
            DevicePowerEnumDevices
            ' Token: 0x04000743 RID: 1859
            EnumPwrSchemes
            ' Token: 0x04000744 RID: 1860
            GetActivePwrScheme
            ' Token: 0x04000745 RID: 1861
            GetCurrentPowerPolicies
            ' Token: 0x04000746 RID: 1862
            GetPwrCapabilities
            ' Token: 0x04000747 RID: 1863
            IsPwrHibernateAllowed
            ' Token: 0x04000748 RID: 1864
            IsPwrShutdownAllowed
            ' Token: 0x04000749 RID: 1865
            IsPwrSuspendAllowed
            ' Token: 0x0400074A RID: 1866
            PowerDuplicateScheme
            ' Token: 0x0400074B RID: 1867
            PowerEnumerate
            ' Token: 0x0400074C RID: 1868
            PowerGetActiveScheme
            ' Token: 0x0400074D RID: 1869
            PowerReadFriendlyName
            ' Token: 0x0400074E RID: 1870
            PowerRegisterSuspendResumeNotification
            ' Token: 0x0400074F RID: 1871
            PowerSettingAccessCheck
            ' Token: 0x04000750 RID: 1872
            PowerSettingRegisterNotification
            ' Token: 0x04000751 RID: 1873
            PowerWriteFriendlyName
            ' Token: 0x04000752 RID: 1874
            POWER_INFORMATION_LEVEL
            ' Token: 0x04000753 RID: 1875
            QueryFlags
            ' Token: 0x04000754 RID: 1876
            QueryInterpretationFlags
            ' Token: 0x04000755 RID: 1877
            ReadGlobalPwrPolicy
            ' Token: 0x04000756 RID: 1878
            ReadPwrScheme
            ' Token: 0x04000757 RID: 1879
            SetActivePwrScheme
            ' Token: 0x04000758 RID: 1880
            SetSuspendState
            ' Token: 0x04000759 RID: 1881
            wetrewrt
            ' Token: 0x0400075A RID: 1882
            WriteGlobalPwrPolicy
        End Enum

        ' Token: 0x02000052 RID: 82
        Public Enum printui
            ' Token: 0x0400075C RID: 1884
            PrintUIEntryW
        End Enum

        ' Token: 0x02000053 RID: 83
        Public Enum propsys
            ' Token: 0x0400075E RID: 1886
            PSGetItemPropertyHandler
        End Enum

        ' Token: 0x02000054 RID: 84
        Public Enum psapi
            ' Token: 0x04000760 RID: 1888
            EmptyWorkingSet
            ' Token: 0x04000761 RID: 1889
            EnumDeviceDrivers
            ' Token: 0x04000762 RID: 1890
            EnumProcesses
            ' Token: 0x04000763 RID: 1891
            EnumProcessModules
            ' Token: 0x04000764 RID: 1892
            GetDeviceDriverBaseName
            ' Token: 0x04000765 RID: 1893
            GetModuleBaseName
            ' Token: 0x04000766 RID: 1894
            GetModuleFileNameEx
            ' Token: 0x04000767 RID: 1895
            GetModuleInformation
            ' Token: 0x04000768 RID: 1896
            GetPerformanceInfo
            ' Token: 0x04000769 RID: 1897
            GetProcessImageFileName
            ' Token: 0x0400076A RID: 1898
            GetProcessMemoryInfo
        End Enum

        ' Token: 0x02000055 RID: 85
        Public Enum pstorec
            ' Token: 0x0400076C RID: 1900
            PStoreCreateInstance
        End Enum

        ' Token: 0x02000056 RID: 86
        Public Enum query
            ' Token: 0x0400076E RID: 1902
            LoadIFilter
        End Enum

        ' Token: 0x02000057 RID: 87
        Public Enum quickusb
            ' Token: 0x04000770 RID: 1904
            Close
            ' Token: 0x04000771 RID: 1905
            QuickUSB
            ' Token: 0x04000772 RID: 1906
            QuickUsbClose
            ' Token: 0x04000773 RID: 1907
            QuickUsbFindModules
            ' Token: 0x04000774 RID: 1908
            QuickUsbOpen
            ' Token: 0x04000775 RID: 1909
            QuickUsbReadData
            ' Token: 0x04000776 RID: 1910
            QuickUsbWriteData
        End Enum

        ' Token: 0x02000058 RID: 88
        Public Enum rasapi32
            ' Token: 0x04000778 RID: 1912
            RasDial
            ' Token: 0x04000779 RID: 1913
            RasDialDlg
            ' Token: 0x0400077A RID: 1914
            RasEnumConnections
            ' Token: 0x0400077B RID: 1915
            RasEnumDevices
            ' Token: 0x0400077C RID: 1916
            RasEnumEntries
            ' Token: 0x0400077D RID: 1917
            RasGetConnectionStatistics
            ' Token: 0x0400077E RID: 1918
            RasGetConnectStatus
            ' Token: 0x0400077F RID: 1919
            RasGetEntryDialParams
            ' Token: 0x04000780 RID: 1920
            RasGetEntryProperties
            ' Token: 0x04000781 RID: 1921
            RasGetErrorString
            ' Token: 0x04000782 RID: 1922
            RasGetProjectionInfo
            ' Token: 0x04000783 RID: 1923
            RasHangUp
            ' Token: 0x04000784 RID: 1924
            RasSetEntryProperties
            ' Token: 0x04000785 RID: 1925
            RasValidateEntryName
        End Enum

        ' Token: 0x02000059 RID: 89
        Public Enum rpcrt4
            ' Token: 0x04000787 RID: 1927
            UuidCreate
            ' Token: 0x04000788 RID: 1928
            UuidCreateSequential
            ' Token: 0x04000789 RID: 1929
            UuidFromStringA
        End Enum

        ' Token: 0x0200005A RID: 90
        Public Enum scarddlg
            ' Token: 0x0400078B RID: 1931
            None
        End Enum

        ' Token: 0x0200005B RID: 91
        Public Enum secur32
            ' Token: 0x0400078D RID: 1933
            AcceptSecurityContext
            ' Token: 0x0400078E RID: 1934
            AcquireCredentialsHandle
            ' Token: 0x0400078F RID: 1935
            DecryptMessage
            ' Token: 0x04000790 RID: 1936
            EncryptMessage
            ' Token: 0x04000791 RID: 1937
            GetUserNameEx
            ' Token: 0x04000792 RID: 1938
            ImpersonateSecurityContext
            ' Token: 0x04000793 RID: 1939
            InitializeSecurityContext
            ' Token: 0x04000794 RID: 1940
            LsaCallAuthenticationPackage
            ' Token: 0x04000795 RID: 1941
            LsaConnectUntrusted
            ' Token: 0x04000796 RID: 1942
            LsaDeregisterLogonProcess
            ' Token: 0x04000797 RID: 1943
            LsaEnumerateLogonSessions
            ' Token: 0x04000798 RID: 1944
            LsaFreeReturnBuffer
            ' Token: 0x04000799 RID: 1945
            LsaGetLogonSessionData
            ' Token: 0x0400079A RID: 1946
            LsaLogonUser
            ' Token: 0x0400079B RID: 1947
            LsaLookupAuthenticationPackage
            ' Token: 0x0400079C RID: 1948
            LsaRegisterLogonProcess
            ' Token: 0x0400079D RID: 1949
            LSA_STRING
            ' Token: 0x0400079E RID: 1950
            NegotiateStream
            ' Token: 0x0400079F RID: 1951
            QuerySecurityPackageInfo
            ' Token: 0x040007A0 RID: 1952
            TranslateName
        End Enum

        ' Token: 0x0200005C RID: 92
        Public Enum setupapi
            ' Token: 0x040007A2 RID: 1954
            CM_Get_Child
            ' Token: 0x040007A3 RID: 1955
            CM_Get_Device_ID
            ' Token: 0x040007A4 RID: 1956
            CM_Get_Device_IDA
            ' Token: 0x040007A5 RID: 1957
            CM_Get_Device_ID_List_Size
            ' Token: 0x040007A6 RID: 1958
            CM_Get_Device_ID_Size
            ' Token: 0x040007A7 RID: 1959
            CM_Get_DevNode_Registry_Property
            ' Token: 0x040007A8 RID: 1960
            CM_Get_DevNode_Status
            ' Token: 0x040007A9 RID: 1961
            CM_Get_Parent
            ' Token: 0x040007AA RID: 1962
            CM_Get_Sibling
            ' Token: 0x040007AB RID: 1963
            CM_Locate_DevNodeA
            ' Token: 0x040007AC RID: 1964
            CM_Reenumerate_DevNode_Ex
            ' Token: 0x040007AD RID: 1965
            CM_Request_Device_Eject
            ' Token: 0x040007AE RID: 1966
            DeviceHandle
            ' Token: 0x040007AF RID: 1967
            DevicePowerOpen
            ' Token: 0x040007B0 RID: 1968
            SetupCloseInfFile
            ' Token: 0x040007B1 RID: 1969
            SetupCopyOEMInf
            ' Token: 0x040007B2 RID: 1970
            SetupDiBuildClassInfoList
            ' Token: 0x040007B3 RID: 1971
            SetupDiCallClassInstaller
            ' Token: 0x040007B4 RID: 1972
            SetupDiClassGuidsFromName
            ' Token: 0x040007B5 RID: 1973
            SetupDiClassNameFromGuid
            ' Token: 0x040007B6 RID: 1974
            SetupDiDestroyDeviceInfoList
            ' Token: 0x040007B7 RID: 1975
            SetupDiEnumDeviceInfo
            ' Token: 0x040007B8 RID: 1976
            SetupDiEnumDeviceInterfaces
            ' Token: 0x040007B9 RID: 1977
            SetupDiGetClassDevs
            ' Token: 0x040007BA RID: 1978
            SetupDiGetDeviceInstallParams
            ' Token: 0x040007BB RID: 1979
            SetupDiGetDeviceInstanceId
            ' Token: 0x040007BC RID: 1980
            SetupDiGetDeviceInterfaceDetail
            ' Token: 0x040007BD RID: 1981
            SetupDiGetDeviceProperty
            ' Token: 0x040007BE RID: 1982
            SetupDiGetDeviceRegistryProperty
            ' Token: 0x040007BF RID: 1983
            SetupDiOpenClassRegKeyEx
            ' Token: 0x040007C0 RID: 1984
            SetupDiOpenDevRegKey
            ' Token: 0x040007C1 RID: 1985
            SetupDiSetClassInstallParam
            ' Token: 0x040007C2 RID: 1986
            SetupDiSetClassInstallParams
            ' Token: 0x040007C3 RID: 1987
            SetupFindFirstLine
            ' Token: 0x040007C4 RID: 1988
            SetupFindNextLine
            ' Token: 0x040007C5 RID: 1989
            SetupFindNextMatchLine
            ' Token: 0x040007C6 RID: 1990
            SetupGetStringField
            ' Token: 0x040007C7 RID: 1991
            SetupOpenInfFile
            ' Token: 0x040007C8 RID: 1992
            SetupUninstallOEMInf
        End Enum

        ' Token: 0x0200005D RID: 93
        Public Enum shell32
            ' Token: 0x040007CA RID: 1994
            api
            ' Token: 0x040007CB RID: 1995
            APPBARDATA
            ' Token: 0x040007CC RID: 1996
            BatchExec
            ' Token: 0x040007CD RID: 1997
            CharSet
            ' Token: 0x040007CE RID: 1998
            CommandLineToArgvW
            ' Token: 0x040007CF RID: 1999
            CSIDL
            ' Token: 0x040007D0 RID: 2000
            DllGetVersion
            ' Token: 0x040007D1 RID: 2001
            DLLGETVERSIONINFO
            ' Token: 0x040007D2 RID: 2002
            DoEnvironmentSubst
            ' Token: 0x040007D3 RID: 2003
            DragAcceptFiles
            ' Token: 0x040007D4 RID: 2004
            DragFinish
            ' Token: 0x040007D5 RID: 2005
            DragQueryFile
            ' Token: 0x040007D6 RID: 2006
            DragQueryPoint
            ' Token: 0x040007D7 RID: 2007
            DuplicateIcon
            ' Token: 0x040007D8 RID: 2008
            EnumFontFamExProc
            ' Token: 0x040007D9 RID: 2009
            ERazMA
            ' Token: 0x040007DA RID: 2010
            ExtendedFileInfo
            ' Token: 0x040007DB RID: 2011
            ExtractAssociatedIcon
            ' Token: 0x040007DC RID: 2012
            ExtractIcon
            ' Token: 0x040007DD RID: 2013
            ExtractIconEx
            ' Token: 0x040007DE RID: 2014
            FileSystemWatcher
            ' Token: 0x040007DF RID: 2015
            FindExecutable
            ' Token: 0x040007E0 RID: 2016
            FZ79pQ
            ' Token: 0x040007E1 RID: 2017
            GetFinalPathNameByHandle
            ' Token: 0x040007E2 RID: 2018
            HChangeNotifyEventID
            ' Token: 0x040007E3 RID: 2019
            HChangeNotifyFlags
            ' Token: 0x040007E4 RID: 2020
            IShellIcon
            ' Token: 0x040007E5 RID: 2021
            IsNetDrive
            ' Token: 0x040007E6 RID: 2022
            IsUserAnAdmin
            ' Token: 0x040007E7 RID: 2023
            ITaskbarList
            ' Token: 0x040007E8 RID: 2024
            ITaskbarList2
            ' Token: 0x040007E9 RID: 2025
            ITaskbarList3
            ' Token: 0x040007EA RID: 2026
            ITaskbarList4
            ' Token: 0x040007EB RID: 2027
            ljlsjsf
            ' Token: 0x040007EC RID: 2028
            PathCleanupSpec
            ' Token: 0x040007ED RID: 2029
            PathIsExe
            ' Token: 0x040007EE RID: 2030
            PathMakeUniqueName
            ' Token: 0x040007EF RID: 2031
            PathYetAnotherMakeUniqueName
            ' Token: 0x040007F0 RID: 2032
            PickIconDlg
            ' Token: 0x040007F1 RID: 2033
            Run
            ' Token: 0x040007F2 RID: 2034
            SetCurrentProcessExplicitAppUserModelID
            ' Token: 0x040007F3 RID: 2035
            SHAddToRecentDocs
            ' Token: 0x040007F4 RID: 2036
            SHAppBarMessage
            ' Token: 0x040007F5 RID: 2037
            SHBindToParent
            ' Token: 0x040007F6 RID: 2038
            SHBrowseForFolder
            ' Token: 0x040007F7 RID: 2039
            SHChangeNotify
            ' Token: 0x040007F8 RID: 2040
            SHChangeNotifyRegister
            ' Token: 0x040007F9 RID: 2041
            SHChangeNotifyUnregister
            ' Token: 0x040007FA RID: 2042
            SHCNRF
            ' Token: 0x040007FB RID: 2043
            SHCreateDirectoryEx
            ' Token: 0x040007FC RID: 2044
            SHCreateItemFromIDList
            ' Token: 0x040007FD RID: 2045
            SHCreateItemFromParsingName
            ' Token: 0x040007FE RID: 2046
            SHCreateItemWithParent
            ' Token: 0x040007FF RID: 2047
            SHCreateProcessAsUserW
            ' Token: 0x04000800 RID: 2048
            ShellAbout
            ' Token: 0x04000801 RID: 2049
            ShellExecute
            ' Token: 0x04000802 RID: 2050
            ShellExecuteEx
            ' Token: 0x04000803 RID: 2051
            ShellExecuteExW
            ' Token: 0x04000804 RID: 2052
            Shell_NotifyIcon
            ' Token: 0x04000805 RID: 2053
            Shell_NotifyIconGetRect
            ' Token: 0x04000806 RID: 2054
            SHEmptyRecycleBin
            ' Token: 0x04000807 RID: 2055
            SHFileOperation
            ' Token: 0x04000808 RID: 2056
            SHFormatDrive
            ' Token: 0x04000809 RID: 2057
            SHFreeNameMappings
            ' Token: 0x0400080A RID: 2058
            SHGetDataFromIDList
            ' Token: 0x0400080B RID: 2059
            SHGetDesktopFolder
            ' Token: 0x0400080C RID: 2060
            SHGetDiskFreeSpace
            ' Token: 0x0400080D RID: 2061
            SHGetFileInfo
            ' Token: 0x0400080E RID: 2062
            SHGetFileInfoA
            ' Token: 0x0400080F RID: 2063
            SHGetFolderLocation
            ' Token: 0x04000810 RID: 2064
            SHGetFolderPath
            ' Token: 0x04000811 RID: 2065
            SHGetIconOverlayIndex
            ' Token: 0x04000812 RID: 2066
            SHGetImageList
            ' Token: 0x04000813 RID: 2067
            SHGetInstanceExplorer
            ' Token: 0x04000814 RID: 2068
            SHGetKnownFolderPath
            ' Token: 0x04000815 RID: 2069
            SHGetMalloc
            ' Token: 0x04000816 RID: 2070
            SHGetNameFromIDList
            ' Token: 0x04000817 RID: 2071
            SHGetNewLinkInfo
            ' Token: 0x04000818 RID: 2072
            SHGetPathFromIDList
            ' Token: 0x04000819 RID: 2073
            SHGetPropertyStoreFromParsingNamehtml
            ' Token: 0x0400081A RID: 2074
            SHGetRealIDL
            ' Token: 0x0400081B RID: 2075
            SHGetSetSettings
            ' Token: 0x0400081C RID: 2076
            SHGetSettings
            ' Token: 0x0400081D RID: 2077
            SHGetSpecialFolderLocation
            ' Token: 0x0400081E RID: 2078
            SHGetSpecialFolderPath
            ' Token: 0x0400081F RID: 2079
            SHGetSpecialFolderPathA
            ' Token: 0x04000820 RID: 2080
            SHGetStockIconInfo
            ' Token: 0x04000821 RID: 2081
            SHInvokePrinterCommand
            ' Token: 0x04000822 RID: 2082
            SHIsFileAvailableOffline
            ' Token: 0x04000823 RID: 2083
            SHLoadInProc
            ' Token: 0x04000824 RID: 2084
            SHLoadNonloadedIconOverlayIdentifiers
            ' Token: 0x04000825 RID: 2085
            SHObjectProperties
            ' Token: 0x04000826 RID: 2086
            SHOpenFolderAndSelectItems
            ' Token: 0x04000827 RID: 2087
            SHOpenWithDialog
            ' Token: 0x04000828 RID: 2088
            SHParseDisplayName
            ' Token: 0x04000829 RID: 2089
            SHPathPrepareForWrite
            ' Token: 0x0400082A RID: 2090
            SHQueryRecycleBin
            ' Token: 0x0400082B RID: 2091
            SHQueryUserNotificationState
            ' Token: 0x0400082C RID: 2092
            SHRunFileDialog
            ' Token: 0x0400082D RID: 2093
            SHSetKnownFolderPath
            ' Token: 0x0400082E RID: 2094
            SHSetUnreadMailCount
            ' Token: 0x0400082F RID: 2095
            StartInfo
            ' Token: 0x04000830 RID: 2096
            THUMBBUTTON
            ' Token: 0x04000831 RID: 2097
            ultimate
        End Enum

        ' Token: 0x0200005E RID: 94
        Public Enum shlwapi
            ' Token: 0x04000833 RID: 2099
            AssocCreate
            ' Token: 0x04000834 RID: 2100
            AssocGetPerceivedType
            ' Token: 0x04000835 RID: 2101
            AssocQueryString
            ' Token: 0x04000836 RID: 2102
            ColorHLSToRGB
            ' Token: 0x04000837 RID: 2103
            ColorRGBToHLS
            ' Token: 0x04000838 RID: 2104
            HashData
            ' Token: 0x04000839 RID: 2105
            IPreviewHandler
            ' Token: 0x0400083A RID: 2106
            IsOS
            ' Token: 0x0400083B RID: 2107
            PathAddBackslash
            ' Token: 0x0400083C RID: 2108
            PathAppend
            ' Token: 0x0400083D RID: 2109
            PathBuildRoot
            ' Token: 0x0400083E RID: 2110
            PathCanonicalize
            ' Token: 0x0400083F RID: 2111
            PathCombine
            ' Token: 0x04000840 RID: 2112
            PathCommonPrefix
            ' Token: 0x04000841 RID: 2113
            PathCompactPath
            ' Token: 0x04000842 RID: 2114
            PathCompactPathEx
            ' Token: 0x04000843 RID: 2115
            PathCreateFromUrl
            ' Token: 0x04000844 RID: 2116
            PathFileExists
            ' Token: 0x04000845 RID: 2117
            PathFindNextComponent
            ' Token: 0x04000846 RID: 2118
            PathFindOnPath
            ' Token: 0x04000847 RID: 2119
            PathGetArgs
            ' Token: 0x04000848 RID: 2120
            PathIsDirectory
            ' Token: 0x04000849 RID: 2121
            PathIsFileSpec
            ' Token: 0x0400084A RID: 2122
            PathIsHTMLFile
            ' Token: 0x0400084B RID: 2123
            PathIsNetworkPath
            ' Token: 0x0400084C RID: 2124
            PathIsRelative
            ' Token: 0x0400084D RID: 2125
            PathIsRoot
            ' Token: 0x0400084E RID: 2126
            PathIsSameRoot
            ' Token: 0x0400084F RID: 2127
            PathIsUNC
            ' Token: 0x04000850 RID: 2128
            PathIsUNCServer
            ' Token: 0x04000851 RID: 2129
            PathIsUNCServerShare
            ' Token: 0x04000852 RID: 2130
            PathIsURL
            ' Token: 0x04000853 RID: 2131
            PathMatchSpec
            ' Token: 0x04000854 RID: 2132
            PathQuoteSpaces
            ' Token: 0x04000855 RID: 2133
            PathRelativePathTo
            ' Token: 0x04000856 RID: 2134
            PathRemoveArgs
            ' Token: 0x04000857 RID: 2135
            PathRemoveBackslash
            ' Token: 0x04000858 RID: 2136
            PathRemoveBlanks
            ' Token: 0x04000859 RID: 2137
            PathRemoveExtension
            ' Token: 0x0400085A RID: 2138
            PathRemoveFileSpec
            ' Token: 0x0400085B RID: 2139
            PathRenameExtension
            ' Token: 0x0400085C RID: 2140
            PathStripPath
            ' Token: 0x0400085D RID: 2141
            PathStripToRoot
            ' Token: 0x0400085E RID: 2142
            PathUndecorate
            ' Token: 0x0400085F RID: 2143
            PathUnExpandEnvStrings
            ' Token: 0x04000860 RID: 2144
            PathUnQuoteSpaces
            ' Token: 0x04000861 RID: 2145
            SHAutoComplete
            ' Token: 0x04000862 RID: 2146
            SHCreateStreamOnFile
            ' Token: 0x04000863 RID: 2147
            SHCreateStreamOnFileEx
            ' Token: 0x04000864 RID: 2148
            SHLoadIndirectString
            ' Token: 0x04000865 RID: 2149
            SHMessageBoxCheck
            ' Token: 0x04000866 RID: 2150
            StrCmpLogicalW
            ' Token: 0x04000867 RID: 2151
            StrFormatByteSize
            ' Token: 0x04000868 RID: 2152
            StrFormatByteSizeA
            ' Token: 0x04000869 RID: 2153
            StrFromTimeInterval
            ' Token: 0x0400086A RID: 2154
            UrlCreateFromPath
        End Enum

        ' Token: 0x0200005F RID: 95
        Public Enum twain_32
            ' Token: 0x0400086C RID: 2156
            DSMparent
            ' Token: 0x0400086D RID: 2157
            TwIdentity
            ' Token: 0x0400086E RID: 2158
            TwRC
        End Enum

        ' Token: 0x02000060 RID: 96
        Public Enum unicows
            ' Token: 0x04000870 RID: 2160
            None
        End Enum

        ' Token: 0x02000061 RID: 97
        Public Enum urlmon
            ' Token: 0x04000872 RID: 2162
            cointernetsetfactureenabled
            ' Token: 0x04000873 RID: 2163
            CoInternetSetFeatureEnabled
            ' Token: 0x04000874 RID: 2164
            CopyMemory
            ' Token: 0x04000875 RID: 2165
            CreateUri
            ' Token: 0x04000876 RID: 2166
            FindMimeFromData
            ' Token: 0x04000877 RID: 2167
            SnFLas
            ' Token: 0x04000878 RID: 2168
            URLDownloadToFile
            ' Token: 0x04000879 RID: 2169
            UrlMkGetSessionOption
            ' Token: 0x0400087A RID: 2170
            URLOpenBlockingStream
        End Enum

        ' Token: 0x02000062 RID: 98
        Public Enum user32
            ' Token: 0x0400087C RID: 2172
            ActivateKeyboardLayout
            ' Token: 0x0400087D RID: 2173
            AddClipboardFormatListener
            ' Token: 0x0400087E RID: 2174
            AdjustWindowRect
            ' Token: 0x0400087F RID: 2175
            AdjustWindowRectEx
            ' Token: 0x04000880 RID: 2176
            AlignRects
            ' Token: 0x04000881 RID: 2177
            AllowForegroundActivation
            ' Token: 0x04000882 RID: 2178
            AllowSetForegroundWindow
            ' Token: 0x04000883 RID: 2179
            AlphaWindow
            ' Token: 0x04000884 RID: 2180
            AnimateWindow
            ' Token: 0x04000885 RID: 2181
            AnyPopup
            ' Token: 0x04000886 RID: 2182
            AppendMenu
            ' Token: 0x04000887 RID: 2183
            ArrangeIconicWindows
            ' Token: 0x04000888 RID: 2184
            AttachThreadInput
            ' Token: 0x04000889 RID: 2185
            BeginDeferWindowPos
            ' Token: 0x0400088A RID: 2186
            BeginPaint
            ' Token: 0x0400088B RID: 2187
            BlockInput
            ' Token: 0x0400088C RID: 2188
            Boshit
            ' Token: 0x0400088D RID: 2189
            BringWindowToTop
            ' Token: 0x0400088E RID: 2190
            BroadcastSystemMessage
            ' Token: 0x0400088F RID: 2191
            BroadcastSystemMessageEx
            ' Token: 0x04000890 RID: 2192
            CallBackPtr
            ' Token: 0x04000891 RID: 2193
            CallMsgFilter
            ' Token: 0x04000892 RID: 2194
            CallNextHookEx
            ' Token: 0x04000893 RID: 2195
            CallWindowProc
            ' Token: 0x04000894 RID: 2196
            CallWndRetProc
            ' Token: 0x04000895 RID: 2197
            CancelShutdown
            ' Token: 0x04000896 RID: 2198
            CascadeChildWindows
            ' Token: 0x04000897 RID: 2199
            CascadeWindows
            ' Token: 0x04000898 RID: 2200
            cbcb
            ' Token: 0x04000899 RID: 2201
            CBTProc
            ' Token: 0x0400089A RID: 2202
            ChangeClipboardChain
            ' Token: 0x0400089B RID: 2203
            ChangeDisplaySettings
            ' Token: 0x0400089C RID: 2204
            ChangeDisplaySettingsEx
            ' Token: 0x0400089D RID: 2205
            ChangeDisplaySettingsFlags
            ' Token: 0x0400089E RID: 2206
            ChangeMenu
            ' Token: 0x0400089F RID: 2207
            ChangeWindowMessageFilter
            ' Token: 0x040008A0 RID: 2208
            ChangeWindowMessageFilterEx
            ' Token: 0x040008A1 RID: 2209
            CharLower
            ' Token: 0x040008A2 RID: 2210
            CharLowerBuff
            ' Token: 0x040008A3 RID: 2211
            CharNext
            ' Token: 0x040008A4 RID: 2212
            CharNextEx
            ' Token: 0x040008A5 RID: 2213
            CharPrev
            ' Token: 0x040008A6 RID: 2214
            CharPrevEx
            ' Token: 0x040008A7 RID: 2215
            CharToOem
            ' Token: 0x040008A8 RID: 2216
            CharToOemBuff
            ' Token: 0x040008A9 RID: 2217
            CharUpper
            ' Token: 0x040008AA RID: 2218
            CharUpperBuff
            ' Token: 0x040008AB RID: 2219
            CheckAppInitBlockedServiceIdentity
            ' Token: 0x040008AC RID: 2220
            CheckDesktopByThreadId
            ' Token: 0x040008AD RID: 2221
            CheckDlgButton
            ' Token: 0x040008AE RID: 2222
            CheckMenuItem
            ' Token: 0x040008AF RID: 2223
            CheckMenuRadioItem
            ' Token: 0x040008B0 RID: 2224
            CheckRadioButton
            ' Token: 0x040008B1 RID: 2225
            CheckWindowThreadDesktop
            ' Token: 0x040008B2 RID: 2226
            ChildWindowFromPoint
            ' Token: 0x040008B3 RID: 2227
            ChildWindowFromPointEx
            ' Token: 0x040008B4 RID: 2228
            ClientRectangle
            ' Token: 0x040008B5 RID: 2229
            ClientThreadSetup
            ' Token: 0x040008B6 RID: 2230
            ClientToScreen
            ' Token: 0x040008B7 RID: 2231
            CliImmSetHotKey
            ' Token: 0x040008B8 RID: 2232
            ClipCursor
            ' Token: 0x040008B9 RID: 2233
            CloseClipboard
            ' Token: 0x040008BA RID: 2234
            CloseDesktop
            ' Token: 0x040008BB RID: 2235
            CloseHandle
            ' Token: 0x040008BC RID: 2236
            CloseWindow
            ' Token: 0x040008BD RID: 2237
            CloseWindowStation
            ' Token: 0x040008BE RID: 2238
            code
            ' Token: 0x040008BF RID: 2239
            CopyAcceleratorTable
            ' Token: 0x040008C0 RID: 2240
            CopyIcon
            ' Token: 0x040008C1 RID: 2241
            CopyImage
            ' Token: 0x040008C2 RID: 2242
            CopyRect
            ' Token: 0x040008C3 RID: 2243
            CountClipboardFormats
            ' Token: 0x040008C4 RID: 2244
            CreateAcceleratorTable
            ' Token: 0x040008C5 RID: 2245
            CreateCaret
            ' Token: 0x040008C6 RID: 2246
            CreateCursor
            ' Token: 0x040008C7 RID: 2247
            CreateDesktop
            ' Token: 0x040008C8 RID: 2248
            CreateDialogIndirectParam
            ' Token: 0x040008C9 RID: 2249
            CreateDialogParam
            ' Token: 0x040008CA RID: 2250
            CreateIcon
            ' Token: 0x040008CB RID: 2251
            CreateIconFromResource
            ' Token: 0x040008CC RID: 2252
            CreateIconFromResourceEx
            ' Token: 0x040008CD RID: 2253
            CreateIconIndirect
            ' Token: 0x040008CE RID: 2254
            CreateMDIWindow
            ' Token: 0x040008CF RID: 2255
            CreateMenu
            ' Token: 0x040008D0 RID: 2256
            CreatePopupMenu
            ' Token: 0x040008D1 RID: 2257
            CreateRegion
            ' Token: 0x040008D2 RID: 2258
            CreateWindow
            ' Token: 0x040008D3 RID: 2259
            CreateWindowEx
            ' Token: 0x040008D4 RID: 2260
            CreateWindowStation
            ' Token: 0x040008D5 RID: 2261
            CREATE_GAY
            ' Token: 0x040008D6 RID: 2262
            DdeAbandonTransaction
            ' Token: 0x040008D7 RID: 2263
            DdeAccessData
            ' Token: 0x040008D8 RID: 2264
            DdeAddData
            ' Token: 0x040008D9 RID: 2265
            DdeClientTransaction
            ' Token: 0x040008DA RID: 2266
            DdeCmpStringHandles
            ' Token: 0x040008DB RID: 2267
            DdeConnect
            ' Token: 0x040008DC RID: 2268
            DdeConnectList
            ' Token: 0x040008DD RID: 2269
            DdeCreateDataHandle
            ' Token: 0x040008DE RID: 2270
            DdeCreateStringHandle
            ' Token: 0x040008DF RID: 2271
            DdeDisconnect
            ' Token: 0x040008E0 RID: 2272
            DdeDisconnectList
            ' Token: 0x040008E1 RID: 2273
            DdeEnableCallback
            ' Token: 0x040008E2 RID: 2274
            DdeFreeDataHandle
            ' Token: 0x040008E3 RID: 2275
            DdeFreeStringHandle
            ' Token: 0x040008E4 RID: 2276
            DdeGetData
            ' Token: 0x040008E5 RID: 2277
            DdeGetLastError
            ' Token: 0x040008E6 RID: 2278
            DdeImpersonateClient
            ' Token: 0x040008E7 RID: 2279
            DdeInitialize
            ' Token: 0x040008E8 RID: 2280
            DdeKeepStringHandle
            ' Token: 0x040008E9 RID: 2281
            DdeNameService
            ' Token: 0x040008EA RID: 2282
            DdePostAdvise
            ' Token: 0x040008EB RID: 2283
            DdeQueryConvInfo
            ' Token: 0x040008EC RID: 2284
            DdeQueryNextServer
            ' Token: 0x040008ED RID: 2285
            DdeQueryString
            ' Token: 0x040008EE RID: 2286
            DdeReconnect
            ' Token: 0x040008EF RID: 2287
            DdeSetQualityOfService
            ' Token: 0x040008F0 RID: 2288
            DdeSetUserHandle
            ' Token: 0x040008F1 RID: 2289
            DdeUnaccessData
            ' Token: 0x040008F2 RID: 2290
            DdeUninitialize
            ' Token: 0x040008F3 RID: 2291
            death
            ' Token: 0x040008F4 RID: 2292
            DebugProc
            ' Token: 0x040008F5 RID: 2293
            DefDlgProc
            ' Token: 0x040008F6 RID: 2294
            DeferWindowPos
            ' Token: 0x040008F7 RID: 2295
            DeferWindowPosCommands
            ' Token: 0x040008F8 RID: 2296
            DefFrameProc
            ' Token: 0x040008F9 RID: 2297
            DefMDIChildProc
            ' Token: 0x040008FA RID: 2298
            DefWindowProc
            ' Token: 0x040008FB RID: 2299
            DeleteMenu
            ' Token: 0x040008FC RID: 2300
            DeregisterShellHookWindow
            ' Token: 0x040008FD RID: 2301
            DestroyAcceleratorTable
            ' Token: 0x040008FE RID: 2302
            DestroyCaret
            ' Token: 0x040008FF RID: 2303
            DestroyCursor
            ' Token: 0x04000900 RID: 2304
            DestroyIcon
            ' Token: 0x04000901 RID: 2305
            DestroyMenu
            ' Token: 0x04000902 RID: 2306
            DestroyWindow
            ' Token: 0x04000903 RID: 2307
            DevBroadcastDeviceInterfaceBuffer
            ' Token: 0x04000904 RID: 2308
            DialogBoxIndirectParam
            ' Token: 0x04000905 RID: 2309
            DialogBoxParam
            ' Token: 0x04000906 RID: 2310
            Dicas_xHarbour
            ' Token: 0x04000907 RID: 2311
            DispatchMessage
            ' Token: 0x04000908 RID: 2312
            DlgDirList
            ' Token: 0x04000909 RID: 2313
            DlgDirListComboBox
            ' Token: 0x0400090A RID: 2314
            DlgDirSelectComboBoxEx
            ' Token: 0x0400090B RID: 2315
            DlgDirSelectEx
            ' Token: 0x0400090C RID: 2316
            dll
            ' Token: 0x0400090D RID: 2317
            DragDetect
            ' Token: 0x0400090E RID: 2318
            DrawAnimatedRects
            ' Token: 0x0400090F RID: 2319
            DrawCaption
            ' Token: 0x04000910 RID: 2320
            DrawEdge
            ' Token: 0x04000911 RID: 2321
            DrawFocusRect
            ' Token: 0x04000912 RID: 2322
            DrawFrameControl
            ' Token: 0x04000913 RID: 2323
            DrawFrameControlStates
            ' Token: 0x04000914 RID: 2324
            DrawFrameControlTypes
            ' Token: 0x04000915 RID: 2325
            DrawIcon
            ' Token: 0x04000916 RID: 2326
            DrawIconEx
            ' Token: 0x04000917 RID: 2327
            DrawMenuBar
            ' Token: 0x04000918 RID: 2328
            DrawState
            ' Token: 0x04000919 RID: 2329
            DrawText
            ' Token: 0x0400091A RID: 2330
            DrawTextA
            ' Token: 0x0400091B RID: 2331
            DrawTextEx
            ' Token: 0x0400091C RID: 2332
            EmptyClipboard
            ' Token: 0x0400091D RID: 2333
            EnableMenuItem
            ' Token: 0x0400091E RID: 2334
            EnableScrollBar
            ' Token: 0x0400091F RID: 2335
            EnableWindow
            ' Token: 0x04000920 RID: 2336
            EndDeferWindowPos
            ' Token: 0x04000921 RID: 2337
            EndDialog
            ' Token: 0x04000922 RID: 2338
            EndMenu
            ' Token: 0x04000923 RID: 2339
            EndPaint
            ' Token: 0x04000924 RID: 2340
            EndTask
            ' Token: 0x04000925 RID: 2341
            EnumChildWindows
            ' Token: 0x04000926 RID: 2342
            EnumClipboardFormats
            ' Token: 0x04000927 RID: 2343
            EnumDesktops
            ' Token: 0x04000928 RID: 2344
            EnumDesktopWindows
            ' Token: 0x04000929 RID: 2345
            EnumDisplayDevices
            ' Token: 0x0400092A RID: 2346
            EnumDisplayMonitors
            ' Token: 0x0400092B RID: 2347
            EnumDisplaySettings
            ' Token: 0x0400092C RID: 2348
            EnumDisplaySettingsEx
            ' Token: 0x0400092D RID: 2349
            EnumProc
            ' Token: 0x0400092E RID: 2350
            EnumProps
            ' Token: 0x0400092F RID: 2351
            EnumPropsEx
            ' Token: 0x04000930 RID: 2352
            EnumReport
            ' Token: 0x04000931 RID: 2353
            EnumThreadDelegate
            ' Token: 0x04000932 RID: 2354
            EnumThreadWindows
            ' Token: 0x04000933 RID: 2355
            EnumWindows
            ' Token: 0x04000934 RID: 2356
            EnumWindowStations
            ' Token: 0x04000935 RID: 2357
            EqualRect
            ' Token: 0x04000936 RID: 2358
            ExcludeUpdateRgn
            ' Token: 0x04000937 RID: 2359
            ExitWindowsEx
            ' Token: 0x04000938 RID: 2360
            FillRect
            ' Token: 0x04000939 RID: 2361
            FindWindow
            ' Token: 0x0400093A RID: 2362
            FindWindowA
            ' Token: 0x0400093B RID: 2363
            FindWindowEx
            ' Token: 0x0400093C RID: 2364
            Flags
            ' Token: 0x0400093D RID: 2365
            FlashWindow
            ' Token: 0x0400093E RID: 2366
            FlashWindowEx
            ' Token: 0x0400093F RID: 2367
            ForegroundIdleProc
            ' Token: 0x04000940 RID: 2368
            FrameRect
            ' Token: 0x04000941 RID: 2369
            FreeDDElParam
            ' Token: 0x04000942 RID: 2370
            GetActiveWindow
            ' Token: 0x04000943 RID: 2371
            GetAltTabInfo
            ' Token: 0x04000944 RID: 2372
            GetAncestor
            ' Token: 0x04000945 RID: 2373
            GetAsyncKeyState
            ' Token: 0x04000946 RID: 2374
            GetCapture
            ' Token: 0x04000947 RID: 2375
            GetCaretBlinkTime
            ' Token: 0x04000948 RID: 2376
            GetCaretPos
            ' Token: 0x04000949 RID: 2377
            GetClassInfo
            ' Token: 0x0400094A RID: 2378
            GetClassInfoEx
            ' Token: 0x0400094B RID: 2379
            GetClassLong
            ' Token: 0x0400094C RID: 2380
            GetClassLongPtr
            ' Token: 0x0400094D RID: 2381
            GetClassName
            ' Token: 0x0400094E RID: 2382
            GetClassWord
            ' Token: 0x0400094F RID: 2383
            GetClientRect
            ' Token: 0x04000950 RID: 2384
            GetClipboardData
            ' Token: 0x04000951 RID: 2385
            GetClipboardFormatName
            ' Token: 0x04000952 RID: 2386
            GetClipboardOwner
            ' Token: 0x04000953 RID: 2387
            GetClipboardSequenceNumber
            ' Token: 0x04000954 RID: 2388
            GetClipboardViewer
            ' Token: 0x04000955 RID: 2389
            GetClipCursor
            ' Token: 0x04000956 RID: 2390
            GetComboBoxInfo
            ' Token: 0x04000957 RID: 2391
            GetCurrentThread
            ' Token: 0x04000958 RID: 2392
            GetCursor
            ' Token: 0x04000959 RID: 2393
            GetCursorInfo
            ' Token: 0x0400095A RID: 2394
            GetCursorPos
            ' Token: 0x0400095B RID: 2395
            GetDC
            ' Token: 0x0400095C RID: 2396
            GetDCEx
            ' Token: 0x0400095D RID: 2397
            GetDesktopWindow
            ' Token: 0x0400095E RID: 2398
            GetDialogBaseUnits
            ' Token: 0x0400095F RID: 2399
            GetDlgCtrlID
            ' Token: 0x04000960 RID: 2400
            GetDlgItem
            ' Token: 0x04000961 RID: 2401
            GetDlgItemInt
            ' Token: 0x04000962 RID: 2402
            GetDlgItemText
            ' Token: 0x04000963 RID: 2403
            GetDoubleClickTime
            ' Token: 0x04000964 RID: 2404
            GetFocus
            ' Token: 0x04000965 RID: 2405
            GetForegroundWindow
            ' Token: 0x04000966 RID: 2406
            GetGuiResources
            ' Token: 0x04000967 RID: 2407
            GetGUIThreadInfo
            ' Token: 0x04000968 RID: 2408
            GetIconInfo
            ' Token: 0x04000969 RID: 2409
            GetInputState
            ' Token: 0x0400096A RID: 2410
            GetKBCodePage
            ' Token: 0x0400096B RID: 2411
            GetKeyboardLayout
            ' Token: 0x0400096C RID: 2412
            GetKeyboardLayoutList
            ' Token: 0x0400096D RID: 2413
            GetKeyboardLayoutName
            ' Token: 0x0400096E RID: 2414
            GetKeyboardState
            ' Token: 0x0400096F RID: 2415
            GetKeyboardType
            ' Token: 0x04000970 RID: 2416
            GetKeyNameText
            ' Token: 0x04000971 RID: 2417
            GetKeyState
            ' Token: 0x04000972 RID: 2418
            GetLastActivePopup
            ' Token: 0x04000973 RID: 2419
            GetLastError
            ' Token: 0x04000974 RID: 2420
            GetLastInputInfo
            ' Token: 0x04000975 RID: 2421
            GetLayeredWindowAttributes
            ' Token: 0x04000976 RID: 2422
            GetListBoxInfo
            ' Token: 0x04000977 RID: 2423
            GetMenu
            ' Token: 0x04000978 RID: 2424
            GetMenuBarInfo
            ' Token: 0x04000979 RID: 2425
            GetMenuCheckMarkDimensions
            ' Token: 0x0400097A RID: 2426
            GetMenuContextHelpId
            ' Token: 0x0400097B RID: 2427
            GetMenuDefaultItem
            ' Token: 0x0400097C RID: 2428
            GetMenuInfo
            ' Token: 0x0400097D RID: 2429
            GetMenuItemCount
            ' Token: 0x0400097E RID: 2430
            GetMenuItemID
            ' Token: 0x0400097F RID: 2431
            GetMenuItemInfo
            ' Token: 0x04000980 RID: 2432
            GetMenuItemRect
            ' Token: 0x04000981 RID: 2433
            GetMenuState
            ' Token: 0x04000982 RID: 2434
            GetMenuString
            ' Token: 0x04000983 RID: 2435
            GetMessage
            ' Token: 0x04000984 RID: 2436
            GetMessageExtraInfo
            ' Token: 0x04000985 RID: 2437
            GetMessagePos
            ' Token: 0x04000986 RID: 2438
            GetMessageTime
            ' Token: 0x04000987 RID: 2439
            GetModuleHandleW
            ' Token: 0x04000988 RID: 2440
            GetMonitorInfo
            ' Token: 0x04000989 RID: 2441
            GetMouseMovePointsEx
            ' Token: 0x0400098A RID: 2442
            GetMsgProc
            ' Token: 0x0400098B RID: 2443
            GetNextDlgGroupItem
            ' Token: 0x0400098C RID: 2444
            GetNextDlgTabItem
            ' Token: 0x0400098D RID: 2445
            GetNextWindow
            ' Token: 0x0400098E RID: 2446
            GetOpenClipboardWindow
            ' Token: 0x0400098F RID: 2447
            GetParent
            ' Token: 0x04000990 RID: 2448
            GetPriorityClipboardFormat
            ' Token: 0x04000991 RID: 2449
            GetProcAddressW
            ' Token: 0x04000992 RID: 2450
            GetProcessDefaultLayout
            ' Token: 0x04000993 RID: 2451
            GetProcessWindowStation
            ' Token: 0x04000994 RID: 2452
            GetProp
            ' Token: 0x04000995 RID: 2453
            GetQueueStatus
            ' Token: 0x04000996 RID: 2454
            GetRawInputData
            ' Token: 0x04000997 RID: 2455
            GetRawInputDeviceInfo
            ' Token: 0x04000998 RID: 2456
            GetRawInputDeviceList
            ' Token: 0x04000999 RID: 2457
            GetScrollBarInfo
            ' Token: 0x0400099A RID: 2458
            GetScrollInfo
            ' Token: 0x0400099B RID: 2459
            GetScrollPos
            ' Token: 0x0400099C RID: 2460
            GetScrollRange
            ' Token: 0x0400099D RID: 2461
            GetShellWindow
            ' Token: 0x0400099E RID: 2462
            GetSubMenu
            ' Token: 0x0400099F RID: 2463
            GetSysColor
            ' Token: 0x040009A0 RID: 2464
            GetSysColorBrush
            ' Token: 0x040009A1 RID: 2465
            GetSystemMenu
            ' Token: 0x040009A2 RID: 2466
            GetSystemMetrics
            ' Token: 0x040009A3 RID: 2467
            GetTabbedTextExtent
            ' Token: 0x040009A4 RID: 2468
            GetThreadDesktop
            ' Token: 0x040009A5 RID: 2469
            GetTitleBarInfo
            ' Token: 0x040009A6 RID: 2470
            GetTopWindow
            ' Token: 0x040009A7 RID: 2471
            GetUpdateRect
            ' Token: 0x040009A8 RID: 2472
            GetUpdateRgn
            ' Token: 0x040009A9 RID: 2473
            GetUserObjectInformation
            ' Token: 0x040009AA RID: 2474
            GetUserObjectSecurity
            ' Token: 0x040009AB RID: 2475
            GetWindow
            ' Token: 0x040009AC RID: 2476
            GetWindowContextHelpId
            ' Token: 0x040009AD RID: 2477
            GetWindowDC
            ' Token: 0x040009AE RID: 2478
            GetWindowInfo
            ' Token: 0x040009AF RID: 2479
            GetWindowLong
            ' Token: 0x040009B0 RID: 2480
            GetWindowLongPtr
            ' Token: 0x040009B1 RID: 2481
            GetWindowModuleFileName
            ' Token: 0x040009B2 RID: 2482
            GetWindowPlacement
            ' Token: 0x040009B3 RID: 2483
            GetWindowPos
            ' Token: 0x040009B4 RID: 2484
            GetWindowRect
            ' Token: 0x040009B5 RID: 2485
            GetWindowRgn
            ' Token: 0x040009B6 RID: 2486
            GetWindowTex
            ' Token: 0x040009B7 RID: 2487
            GetWindowText
            ' Token: 0x040009B8 RID: 2488
            GetWindowTextLength
            ' Token: 0x040009B9 RID: 2489
            GetWindowThreadProcessId
            ' Token: 0x040009BA RID: 2490
            GrayString
            ' Token: 0x040009BB RID: 2491
            HandleRef
            ' Token: 0x040009BC RID: 2492
            Hello
            ' Token: 0x040009BD RID: 2493
            HelloWin
            ' Token: 0x040009BE RID: 2494
            HideCaret
            ' Token: 0x040009BF RID: 2495
            HiliteMenuItem
            ' Token: 0x040009C0 RID: 2496
            ImpersonateDdeClientWindow
            ' Token: 0x040009C1 RID: 2497
            InflateRect
            ' Token: 0x040009C2 RID: 2498
            InSendMessage
            ' Token: 0x040009C3 RID: 2499
            InSendMessageEx
            ' Token: 0x040009C4 RID: 2500
            InsertMenu
            ' Token: 0x040009C5 RID: 2501
            InsertMenuItem
            ' Token: 0x040009C6 RID: 2502
            IntersectRect
            ' Token: 0x040009C7 RID: 2503
            IntPtr
            ' Token: 0x040009C8 RID: 2504
            InvalidateRect
            ' Token: 0x040009C9 RID: 2505
            InvalidateRgn
            ' Token: 0x040009CA RID: 2506
            InvertRect
            ' Token: 0x040009CB RID: 2507
            IsCharAlpha
            ' Token: 0x040009CC RID: 2508
            IsCharAlphaNumeric
            ' Token: 0x040009CD RID: 2509
            IsCharLower
            ' Token: 0x040009CE RID: 2510
            IsCharUpper
            ' Token: 0x040009CF RID: 2511
            IsChild
            ' Token: 0x040009D0 RID: 2512
            IsClipboardFormatAvailable
            ' Token: 0x040009D1 RID: 2513
            IsDialogMessage
            ' Token: 0x040009D2 RID: 2514
            IsDlgButtonChecked
            ' Token: 0x040009D3 RID: 2515
            IsHungAppWindow
            ' Token: 0x040009D4 RID: 2516
            IsIconic
            ' Token: 0x040009D5 RID: 2517
            IsMenu
            ' Token: 0x040009D6 RID: 2518
            IsRectEmpty
            ' Token: 0x040009D7 RID: 2519
            IsWindow
            ' Token: 0x040009D8 RID: 2520
            IsWindowEnabled
            ' Token: 0x040009D9 RID: 2521
            IsWindowUnicode
            ' Token: 0x040009DA RID: 2522
            IsWindowVisible
            ' Token: 0x040009DB RID: 2523
            IsZoomed
            ' Token: 0x040009DC RID: 2524
            ITCactus
            ' Token: 0x040009DD RID: 2525
            JournalPlaybackProc
            ' Token: 0x040009DE RID: 2526
            keybd_event
            ' Token: 0x040009DF RID: 2527
            KeyboardKey
            ' Token: 0x040009E0 RID: 2528
            KeyboardProc
            ' Token: 0x040009E1 RID: 2529
            KillTimer
            ' Token: 0x040009E2 RID: 2530
            LoadAccelerators
            ' Token: 0x040009E3 RID: 2531
            LoadBitmap
            ' Token: 0x040009E4 RID: 2532
            LoadCursor
            ' Token: 0x040009E5 RID: 2533
            LoadCursorFromFile
            ' Token: 0x040009E6 RID: 2534
            LoadIcon
            ' Token: 0x040009E7 RID: 2535
            LoadImage
            ' Token: 0x040009E8 RID: 2536
            LoadKeyboardLayout
            ' Token: 0x040009E9 RID: 2537
            LoadMenu
            ' Token: 0x040009EA RID: 2538
            LoadMenuIndirect
            ' Token: 0x040009EB RID: 2539
            LoadString
            ' Token: 0x040009EC RID: 2540
            LockSetForegroundWindow
            ' Token: 0x040009ED RID: 2541
            LockWindowUpdate
            ' Token: 0x040009EE RID: 2542
            LockWorkStation
            ' Token: 0x040009EF RID: 2543
            LookupIconIdFromDirectory
            ' Token: 0x040009F0 RID: 2544
            LookupIconIdFromDirectoryEx
            ' Token: 0x040009F1 RID: 2545
            LowLevelKeyboardProc
            ' Token: 0x040009F2 RID: 2546
            LowLevelMouseProc
            ' Token: 0x040009F3 RID: 2547
            ManagedWindowsApi
            ' Token: 0x040009F4 RID: 2548
            MapDialogRect
            ' Token: 0x040009F5 RID: 2549
            MapVirtualKey
            ' Token: 0x040009F6 RID: 2550
            MapVirtualKeyEx
            ' Token: 0x040009F7 RID: 2551
            MapWindowPoints
            ' Token: 0x040009F8 RID: 2552
            MB_GetString
            ' Token: 0x040009F9 RID: 2553
            MenuItemFromPoint
            ' Token: 0x040009FA RID: 2554
            MessageBeep
            ' Token: 0x040009FB RID: 2555
            MessageBox
            ' Token: 0x040009FC RID: 2556
            MessageBoxEx
            ' Token: 0x040009FD RID: 2557
            MessageBoxIndirect
            ' Token: 0x040009FE RID: 2558
            MessageBoxTimeout
            ' Token: 0x040009FF RID: 2559
            MessageProc
            ' Token: 0x04000A00 RID: 2560
            minaisabutt
            ' Token: 0x04000A01 RID: 2561
            ModifyMenu
            ' Token: 0x04000A02 RID: 2562
            MonitorFromPoint
            ' Token: 0x04000A03 RID: 2563
            MonitorFromRect
            ' Token: 0x04000A04 RID: 2564
            MonitorFromWindow
            ' Token: 0x04000A05 RID: 2565
            MONITORINFO
            ' Token: 0x04000A06 RID: 2566
            MONITORINFOEX
            ' Token: 0x04000A07 RID: 2567
            MouseProc
            ' Token: 0x04000A08 RID: 2568
            mouse_event
            ' Token: 0x04000A09 RID: 2569
            MoveWindow
            ' Token: 0x04000A0A RID: 2570
            MsgWaitForMultipleObjects
            ' Token: 0x04000A0B RID: 2571
            MsgWaitForMultipleObjectsEx
            ' Token: 0x04000A0C RID: 2572
            mypage
            ' Token: 0x04000A0D RID: 2573
            NativeMethods
            ' Token: 0x04000A0E RID: 2574
            NotifyWinEvent
            ' Token: 0x04000A0F RID: 2575
            OemKeyScan
            ' Token: 0x04000A10 RID: 2576
            OemToChar
            ' Token: 0x04000A11 RID: 2577
            OemToCharBuff
            ' Token: 0x04000A12 RID: 2578
            OffsetRect
            ' Token: 0x04000A13 RID: 2579
            OpenClipboard
            ' Token: 0x04000A14 RID: 2580
            OpenDesktop
            ' Token: 0x04000A15 RID: 2581
            OpenIcon
            ' Token: 0x04000A16 RID: 2582
            OpenInputDesktop
            ' Token: 0x04000A17 RID: 2583
            OpenProcess
            ' Token: 0x04000A18 RID: 2584
            OpenWindowStation
            ' Token: 0x04000A19 RID: 2585
            PackDDElParam
            ' Token: 0x04000A1A RID: 2586
            PaintDesktop
            ' Token: 0x04000A1B RID: 2587
            patrick
            ' Token: 0x04000A1C RID: 2588
            PointL
            ' Token: 0x04000A1D RID: 2589
            PostMessage
            ' Token: 0x04000A1E RID: 2590
            PostMessageA
            ' Token: 0x04000A1F RID: 2591
            PostQuitMessage
            ' Token: 0x04000A20 RID: 2592
            PostThreadMessage
            ' Token: 0x04000A21 RID: 2593
            PrintWindow
            ' Token: 0x04000A22 RID: 2594
            PropSheet
            ' Token: 0x04000A23 RID: 2595
            PtInRect
            ' Token: 0x04000A24 RID: 2596
            ReadProcessMemory
            ' Token: 0x04000A25 RID: 2597
            RealChildWindowFromPoint
            ' Token: 0x04000A26 RID: 2598
            RealGetWindowClass
            ' Token: 0x04000A27 RID: 2599
            RedrawWindow
            ' Token: 0x04000A28 RID: 2600
            RegisterClass
            ' Token: 0x04000A29 RID: 2601
            RegisterClassEx
            ' Token: 0x04000A2A RID: 2602
            RegisterClipboardFormat
            ' Token: 0x04000A2B RID: 2603
            RegisterDeviceNotification
            ' Token: 0x04000A2C RID: 2604
            RegisterHotKey
            ' Token: 0x04000A2D RID: 2605
            RegisterHotKeyaspx
            ' Token: 0x04000A2E RID: 2606
            RegisterPowerSettingNotification
            ' Token: 0x04000A2F RID: 2607
            RegisterRawInputDevices
            ' Token: 0x04000A30 RID: 2608
            RegisterShellHookWindow
            ' Token: 0x04000A31 RID: 2609
            RegisterTouchWindow
            ' Token: 0x04000A32 RID: 2610
            RegisterWindowMessage
            ' Token: 0x04000A33 RID: 2611
            ReleaseCapture
            ' Token: 0x04000A34 RID: 2612
            ReleaseDC
            ' Token: 0x04000A35 RID: 2613
            RemoveClipboardFormatListener
            ' Token: 0x04000A36 RID: 2614
            RemoveMenu
            ' Token: 0x04000A37 RID: 2615
            RemoveProp
            ' Token: 0x04000A38 RID: 2616
            ReplyMessage
            ' Token: 0x04000A39 RID: 2617
            ReuseDDElParam
            ' Token: 0x04000A3A RID: 2618
            SAO
            ' Token: 0x04000A3B RID: 2619
            SB_GETTEXT
            ' Token: 0x04000A3C RID: 2620
            ScreenToClient
            ' Token: 0x04000A3D RID: 2621
            ScrollDC
            ' Token: 0x04000A3E RID: 2622
            ScrollInfoMask
            ' Token: 0x04000A3F RID: 2623
            ScrollWindow
            ' Token: 0x04000A40 RID: 2624
            ScrollWindowEx
            ' Token: 0x04000A41 RID: 2625
            ScrollWindows
            ' Token: 0x04000A42 RID: 2626
            SendDlgItemMessage
            ' Token: 0x04000A43 RID: 2627
            SendInput
            ' Token: 0x04000A44 RID: 2628
            SendMessage
            ' Token: 0x04000A45 RID: 2629
            SendMessageA
            ' Token: 0x04000A46 RID: 2630
            SendMessageCallback
            ' Token: 0x04000A47 RID: 2631
            SendMessageTimeout
            ' Token: 0x04000A48 RID: 2632
            SendNotifyMessage
            ' Token: 0x04000A49 RID: 2633
            SetActiveWindow
            ' Token: 0x04000A4A RID: 2634
            SetCapture
            ' Token: 0x04000A4B RID: 2635
            SetCaretBlinkTime
            ' Token: 0x04000A4C RID: 2636
            SetCaretPos
            ' Token: 0x04000A4D RID: 2637
            SetCaretPosition
            ' Token: 0x04000A4E RID: 2638
            SetClassLong
            ' Token: 0x04000A4F RID: 2639
            SetClassLongPtr
            ' Token: 0x04000A50 RID: 2640
            SetClassWord
            ' Token: 0x04000A51 RID: 2641
            SetClipboardData
            ' Token: 0x04000A52 RID: 2642
            SetClipboardViewer
            ' Token: 0x04000A53 RID: 2643
            SetCursor
            ' Token: 0x04000A54 RID: 2644
            SetCursorPos
            ' Token: 0x04000A55 RID: 2645
            SetDlgItemInt
            ' Token: 0x04000A56 RID: 2646
            SetDlgItemText
            ' Token: 0x04000A57 RID: 2647
            SetDoubleClickTime
            ' Token: 0x04000A58 RID: 2648
            SetFocus
            ' Token: 0x04000A59 RID: 2649
            SetForegroundWindow
            ' Token: 0x04000A5A RID: 2650
            SetKeyboardState
            ' Token: 0x04000A5B RID: 2651
            SetLastErrorEx
            ' Token: 0x04000A5C RID: 2652
            SetLayeredWindowAttributes
            ' Token: 0x04000A5D RID: 2653
            SetMenu
            ' Token: 0x04000A5E RID: 2654
            SetMenuContextHelpId
            ' Token: 0x04000A5F RID: 2655
            SetMenuDefaultItem
            ' Token: 0x04000A60 RID: 2656
            SetMenuInfo
            ' Token: 0x04000A61 RID: 2657
            SetMenuItemBitmaps
            ' Token: 0x04000A62 RID: 2658
            SetMenuItemInfo
            ' Token: 0x04000A63 RID: 2659
            SetMessageExtraInfo
            ' Token: 0x04000A64 RID: 2660
            SetParent
            ' Token: 0x04000A65 RID: 2661
            SetProcessDefaultLayout
            ' Token: 0x04000A66 RID: 2662
            SetProcessDPIAware
            ' Token: 0x04000A67 RID: 2663
            SetProcessWindowStation
            ' Token: 0x04000A68 RID: 2664
            SetProp
            ' Token: 0x04000A69 RID: 2665
            SetRect
            ' Token: 0x04000A6A RID: 2666
            SetRectEmpty
            ' Token: 0x04000A6B RID: 2667
            SetScrollInfo
            ' Token: 0x04000A6C RID: 2668
            SetScrollPos
            ' Token: 0x04000A6D RID: 2669
            SetScrollRange
            ' Token: 0x04000A6E RID: 2670
            SetSysColors
            ' Token: 0x04000A6F RID: 2671
            SetSystemCursor
            ' Token: 0x04000A70 RID: 2672
            SetThreadDesktop
            ' Token: 0x04000A71 RID: 2673
            SetTimer
            ' Token: 0x04000A72 RID: 2674
            SetUserObjectInformation
            ' Token: 0x04000A73 RID: 2675
            SetUserObjectSecurity
            ' Token: 0x04000A74 RID: 2676
            SetWindowContextHelpId
            ' Token: 0x04000A75 RID: 2677
            SetWindowDisplayAffinity
            ' Token: 0x04000A76 RID: 2678
            SetWindowLong
            ' Token: 0x04000A77 RID: 2679
            SetWindowLongA
            ' Token: 0x04000A78 RID: 2680
            SetWindowLongPtr
            ' Token: 0x04000A79 RID: 2681
            SetWindowPlacement
            ' Token: 0x04000A7A RID: 2682
            SetWindowPos
            ' Token: 0x04000A7B RID: 2683
            SetWindowRgn
            ' Token: 0x04000A7C RID: 2684
            SetWindowsHookEx
            ' Token: 0x04000A7D RID: 2685
            SetWindowText
            ' Token: 0x04000A7E RID: 2686
            SetWinEventHook
            ' Token: 0x04000A7F RID: 2687
            ShellProc
            ' Token: 0x04000A80 RID: 2688
            ShowCaret
            ' Token: 0x04000A81 RID: 2689
            ShowCursor
            ' Token: 0x04000A82 RID: 2690
            ShowOwnedPopups
            ' Token: 0x04000A83 RID: 2691
            ShowScrollBar
            ' Token: 0x04000A84 RID: 2692
            ShowState
            ' Token: 0x04000A85 RID: 2693
            ShowWindow
            ' Token: 0x04000A86 RID: 2694
            ShowWindowAsync
            ' Token: 0x04000A87 RID: 2695
            ShowWithoutActivation
            ' Token: 0x04000A88 RID: 2696
            ShutdownBlockReasonCreate
            ' Token: 0x04000A89 RID: 2697
            ShutdownBlockReasonDestroy
            ' Token: 0x04000A8A RID: 2698
            sounds
            ' Token: 0x04000A8B RID: 2699
            SubtractRect
            ' Token: 0x04000A8C RID: 2700
            sucuni
            ' Token: 0x04000A8D RID: 2701
            SwapMouseButton
            ' Token: 0x04000A8E RID: 2702
            SwitchDesktop
            ' Token: 0x04000A8F RID: 2703
            SwitchToThisWindow
            ' Token: 0x04000A90 RID: 2704
            SysMSGProc
            ' Token: 0x04000A91 RID: 2705
            SystemIcons
            ' Token: 0x04000A92 RID: 2706
            SystemInformation
            ' Token: 0x04000A93 RID: 2707
            SystemParametersInfo
            ' Token: 0x04000A94 RID: 2708
            SystemParametrInfo
            ' Token: 0x04000A95 RID: 2709
            TabbedTextOut
            ' Token: 0x04000A96 RID: 2710
            TCITEM
            ' Token: 0x04000A97 RID: 2711
            TileWindows
            ' Token: 0x04000A98 RID: 2712
            ToAscii
            ' Token: 0x04000A99 RID: 2713
            ToAsciiEx
            ' Token: 0x04000A9A RID: 2714
            ToUnicode
            ' Token: 0x04000A9B RID: 2715
            ToUnicodeEx
            ' Token: 0x04000A9C RID: 2716
            TrackMouseEvent
            ' Token: 0x04000A9D RID: 2717
            TrackPopupMenu
            ' Token: 0x04000A9E RID: 2718
            TrackPopupMenuEx
            ' Token: 0x04000A9F RID: 2719
            TranslateAccelerator
            ' Token: 0x04000AA0 RID: 2720
            TranslateMDISysAccel
            ' Token: 0x04000AA1 RID: 2721
            TranslateMessage
            ' Token: 0x04000AA2 RID: 2722
            TransparencyKey
            ' Token: 0x04000AA3 RID: 2723
            tree
            ' Token: 0x04000AA4 RID: 2724
            UIntPtr
            ' Token: 0x04000AA5 RID: 2725
            UIntrPtr
            ' Token: 0x04000AA6 RID: 2726
            UnhookWindowsHookEx
            ' Token: 0x04000AA7 RID: 2727
            UnhookWinEvent
            ' Token: 0x04000AA8 RID: 2728
            UnionRect
            ' Token: 0x04000AA9 RID: 2729
            UnloadKeyboardLayout
            ' Token: 0x04000AAA RID: 2730
            UnpackDDElParam
            ' Token: 0x04000AAB RID: 2731
            UnregisterClass
            ' Token: 0x04000AAC RID: 2732
            unregisterClassEx
            ' Token: 0x04000AAD RID: 2733
            UnregisterDeviceNotification
            ' Token: 0x04000AAE RID: 2734
            UnregisterHotKey
            ' Token: 0x04000AAF RID: 2735
            UnregisterPowerSettingNotification
            ' Token: 0x04000AB0 RID: 2736
            UnregisterTouchWindow
            ' Token: 0x04000AB1 RID: 2737
            UpdateLayeredWindow
            ' Token: 0x04000AB2 RID: 2738
            UpdateWindow
            ' Token: 0x04000AB3 RID: 2739
            user32
            ' Token: 0x04000AB4 RID: 2740
            UserHandleGrantAccess
            ' Token: 0x04000AB5 RID: 2741
            ValidateRect
            ' Token: 0x04000AB6 RID: 2742
            ValidateRgn
            ' Token: 0x04000AB7 RID: 2743
            VirtualKeyCodes
            ' Token: 0x04000AB8 RID: 2744
            VkKeyScan
            ' Token: 0x04000AB9 RID: 2745
            VkKeyScanEx
            ' Token: 0x04000ABA RID: 2746
            WaitForInputIdle
            ' Token: 0x04000ABB RID: 2747
            WaitMessage
            ' Token: 0x04000ABC RID: 2748
            why
            ' Token: 0x04000ABD RID: 2749
            WindowFromDC
            ' Token: 0x04000ABE RID: 2750
            WindowFromPoint
            ' Token: 0x04000ABF RID: 2751
            WindowsAPI
            ' Token: 0x04000AC0 RID: 2752
            WindowsApplication1
            ' Token: 0x04000AC1 RID: 2753
            WinEventDelegate
            ' Token: 0x04000AC2 RID: 2754
            WinForm
            ' Token: 0x04000AC3 RID: 2755
            WinHelp
            ' Token: 0x04000AC4 RID: 2756
            WinHelpCommands
            ' Token: 0x04000AC5 RID: 2757
            WNDCLASS
            ' Token: 0x04000AC6 RID: 2758
            WndProcDelegate
            ' Token: 0x04000AC7 RID: 2759
            wow
            ' Token: 0x04000AC8 RID: 2760
            wra
            ' Token: 0x04000AC9 RID: 2761
            wsprintf
            ' Token: 0x04000ACA RID: 2762
            Yegor
        End Enum

        ' Token: 0x02000063 RID: 99
        Public Enum userenv
            ' Token: 0x04000ACC RID: 2764
            CreateEnvironmentBlock
            ' Token: 0x04000ACD RID: 2765
            CreateProfile
            ' Token: 0x04000ACE RID: 2766
            DeleteProfile
            ' Token: 0x04000ACF RID: 2767
            DestroyEnvironmentBlock
            ' Token: 0x04000AD0 RID: 2768
            FreeGPOList
            ' Token: 0x04000AD1 RID: 2769
            GetAppliedGPOList
            ' Token: 0x04000AD2 RID: 2770
            GetGPOList
            ' Token: 0x04000AD3 RID: 2771
            GetProfilesDirectory
            ' Token: 0x04000AD4 RID: 2772
            GetUserProfileDirectory
            ' Token: 0x04000AD5 RID: 2773
            LoadUserProfile
            ' Token: 0x04000AD6 RID: 2774
            UnloadUserProfile
        End Enum

        ' Token: 0x02000064 RID: 100
        Public Enum uxtheme
            ' Token: 0x04000AD8 RID: 2776
            BeginBufferedAnimation
            ' Token: 0x04000AD9 RID: 2777
            BeginBufferedPaint
            ' Token: 0x04000ADA RID: 2778
            BufferedPaintInit
            ' Token: 0x04000ADB RID: 2779
            BufferedPaintRenderAnimation
            ' Token: 0x04000ADC RID: 2780
            BufferedPaintSetAlpha
            ' Token: 0x04000ADD RID: 2781
            BufferedPaintStopAllAnimations
            ' Token: 0x04000ADE RID: 2782
            BufferedPaintUnInit
            ' Token: 0x04000ADF RID: 2783
            CloseThemeData
            ' Token: 0x04000AE0 RID: 2784
            DrawThemeBackground
            ' Token: 0x04000AE1 RID: 2785
            DrawThemeBackgroundEx
            ' Token: 0x04000AE2 RID: 2786
            DrawThemeEdge
            ' Token: 0x04000AE3 RID: 2787
            DrawThemeIcon
            ' Token: 0x04000AE4 RID: 2788
            DrawThemeParentBackground
            ' Token: 0x04000AE5 RID: 2789
            DrawThemeText
            ' Token: 0x04000AE6 RID: 2790
            DrawThemeTextEx
            ' Token: 0x04000AE7 RID: 2791
            EnableThemeDialogTexture
            ' Token: 0x04000AE8 RID: 2792
            EnableTheming
            ' Token: 0x04000AE9 RID: 2793
            EndBufferedAnimation
            ' Token: 0x04000AEA RID: 2794
            EndBufferedPaint
            ' Token: 0x04000AEB RID: 2795
            GetCurrentThemeName
            ' Token: 0x04000AEC RID: 2796
            GetThemeAppProperties
            ' Token: 0x04000AED RID: 2797
            GetThemeBackgroundContentRect
            ' Token: 0x04000AEE RID: 2798
            GetThemeBackgroundExtent
            ' Token: 0x04000AEF RID: 2799
            GetThemeBackgroundRegion
            ' Token: 0x04000AF0 RID: 2800
            GetThemeBool
            ' Token: 0x04000AF1 RID: 2801
            GetThemeColor
            ' Token: 0x04000AF2 RID: 2802
            GetThemeDocumentationProperty
            ' Token: 0x04000AF3 RID: 2803
            GetThemeEnumValue
            ' Token: 0x04000AF4 RID: 2804
            GetThemeFilename
            ' Token: 0x04000AF5 RID: 2805
            GetThemeFont
            ' Token: 0x04000AF6 RID: 2806
            GetThemeInt
            ' Token: 0x04000AF7 RID: 2807
            GetThemeIntList
            ' Token: 0x04000AF8 RID: 2808
            GetThemeMargins
            ' Token: 0x04000AF9 RID: 2809
            GetThemeMetric
            ' Token: 0x04000AFA RID: 2810
            GetThemePartSize
            ' Token: 0x04000AFB RID: 2811
            GetThemePosition
            ' Token: 0x04000AFC RID: 2812
            GetThemePropertyOrigin
            ' Token: 0x04000AFD RID: 2813
            GetThemeRect
            ' Token: 0x04000AFE RID: 2814
            GetThemeString
            ' Token: 0x04000AFF RID: 2815
            GetThemeSysBool
            ' Token: 0x04000B00 RID: 2816
            GetThemeSysBrush
            ' Token: 0x04000B01 RID: 2817
            GetThemeSysColor
            ' Token: 0x04000B02 RID: 2818
            GetThemeSysFont
            ' Token: 0x04000B03 RID: 2819
            GetThemeSysInt
            ' Token: 0x04000B04 RID: 2820
            GetThemeSysSize
            ' Token: 0x04000B05 RID: 2821
            GetThemeSysString
            ' Token: 0x04000B06 RID: 2822
            GetThemeTextExtent
            ' Token: 0x04000B07 RID: 2823
            GetThemeTextMetrics
            ' Token: 0x04000B08 RID: 2824
            GetThemeTransitionDuration
            ' Token: 0x04000B09 RID: 2825
            GetWindowTheme
            ' Token: 0x04000B0A RID: 2826
            HitTestThemeBackground
            ' Token: 0x04000B0B RID: 2827
            IsAppThemed
            ' Token: 0x04000B0C RID: 2828
            IsThemeActive
            ' Token: 0x04000B0D RID: 2829
            IsThemeBackgroundPartiallyTransparent
            ' Token: 0x04000B0E RID: 2830
            IsThemeDialogTextureEnabled
            ' Token: 0x04000B0F RID: 2831
            IsThemePartDefined
            ' Token: 0x04000B10 RID: 2832
            OpenThemeData
            ' Token: 0x04000B11 RID: 2833
            OpenThemeFile
            ' Token: 0x04000B12 RID: 2834
            SetSystemVisualStyle
            ' Token: 0x04000B13 RID: 2835
            SetThemeAppProperties
            ' Token: 0x04000B14 RID: 2836
            SetWindowTheme
            ' Token: 0x04000B15 RID: 2837
            SetWindowThemeAttribute
            ' Token: 0x04000B16 RID: 2838
            tujjj
        End Enum

        ' Token: 0x02000065 RID: 101
        Public Enum version
            ' Token: 0x04000B18 RID: 2840
            GetFileVersionInfoSize
        End Enum

        ' Token: 0x02000066 RID: 102
        Public Enum wer
            ' Token: 0x04000B1A RID: 2842
            WerAddExcludedApplication
            ' Token: 0x04000B1B RID: 2843
            WerReportAddDump
            ' Token: 0x04000B1C RID: 2844
            WerReportCreate
            ' Token: 0x04000B1D RID: 2845
            WerReportSetParameter
            ' Token: 0x04000B1E RID: 2846
            WerReportSubmit
        End Enum

        ' Token: 0x02000067 RID: 103
        Public Enum wevtapi
            ' Token: 0x04000B20 RID: 2848
            None
        End Enum

        ' Token: 0x02000068 RID: 104
        Public Enum winfax
            ' Token: 0x04000B22 RID: 2850
            FaxAbort
            ' Token: 0x04000B23 RID: 2851
            FaxAccessCheck
            ' Token: 0x04000B24 RID: 2852
            FaxClose
            ' Token: 0x04000B25 RID: 2853
            FaxCompleteJobParams
            ' Token: 0x04000B26 RID: 2854
            FaxConnectFaxServer
            ' Token: 0x04000B27 RID: 2855
            FaxEnableRoutingMethod
            ' Token: 0x04000B28 RID: 2856
            FaxEnumGlobalRoutingInfo
            ' Token: 0x04000B29 RID: 2857
            FaxEnumJobs
            ' Token: 0x04000B2A RID: 2858
            FaxEnumPorts
            ' Token: 0x04000B2B RID: 2859
            FaxEnumRoutingMethods
            ' Token: 0x04000B2C RID: 2860
            FaxFreeBuffer
            ' Token: 0x04000B2D RID: 2861
            FaxGetConfiguration
            ' Token: 0x04000B2E RID: 2862
            FaxGetDeviceStatus
            ' Token: 0x04000B2F RID: 2863
            FaxGetJob
            ' Token: 0x04000B30 RID: 2864
            FaxGetLoggingCategories
            ' Token: 0x04000B31 RID: 2865
            FaxGetPageData
            ' Token: 0x04000B32 RID: 2866
            FaxGetPort
            ' Token: 0x04000B33 RID: 2867
            FaxGetRoutingInfo
            ' Token: 0x04000B34 RID: 2868
            FaxInitializeEventQueue
            ' Token: 0x04000B35 RID: 2869
            FaxOpenPort
            ' Token: 0x04000B36 RID: 2870
            FaxPrintCoverPage
            ' Token: 0x04000B37 RID: 2871
            FaxSendDocument
            ' Token: 0x04000B38 RID: 2872
            FaxSendDocumentForBroadcast
            ' Token: 0x04000B39 RID: 2873
            FaxSetConfiguration
            ' Token: 0x04000B3A RID: 2874
            FaxSetGlobalRoutingInfo
            ' Token: 0x04000B3B RID: 2875
            FaxSetJob
            ' Token: 0x04000B3C RID: 2876
            FaxSetLoggingCategories
            ' Token: 0x04000B3D RID: 2877
            FaxSetPort
            ' Token: 0x04000B3E RID: 2878
            FaxSetRoutingInfo
            ' Token: 0x04000B3F RID: 2879
            FaxStartPrintJob
            ' Token: 0x04000B40 RID: 2880
            FAX_PRINT_INFO
        End Enum

        ' Token: 0x02000069 RID: 105
        Public Enum winhttp
            ' Token: 0x04000B42 RID: 2882
            WinHttpAddRequestHeaders
            ' Token: 0x04000B43 RID: 2883
            WinHttpCloseHandle
            ' Token: 0x04000B44 RID: 2884
            WinHttpConnect
            ' Token: 0x04000B45 RID: 2885
            WinHttpGetIEProxyConfigForCurrentUser
            ' Token: 0x04000B46 RID: 2886
            WinHttpGetProxyForUrl
            ' Token: 0x04000B47 RID: 2887
            WinHttpOpen
            ' Token: 0x04000B48 RID: 2888
            WinHttpOpenRequest
            ' Token: 0x04000B49 RID: 2889
            WinHttpQueryDataAvailable
            ' Token: 0x04000B4A RID: 2890
            WinHttpQueryHeaders
            ' Token: 0x04000B4B RID: 2891
            WinHttpQueryOption
            ' Token: 0x04000B4C RID: 2892
            WinHttpReadData
            ' Token: 0x04000B4D RID: 2893
            WinHttpReceiveResponse
            ' Token: 0x04000B4E RID: 2894
            WinHttpSendRequest
            ' Token: 0x04000B4F RID: 2895
            WinHttpSetOption
            ' Token: 0x04000B50 RID: 2896
            WinHttpSetTimeouts
            ' Token: 0x04000B51 RID: 2897
            WinHttpWriteData
            ' Token: 0x04000B52 RID: 2898
            WINHTTP_CURRENT_USER_IE_PROXY_CONFIG
        End Enum

        ' Token: 0x0200006A RID: 106
        Public Enum wininet
            ' Token: 0x04000B54 RID: 2900
            DeleteUrlCacheEntry
            ' Token: 0x04000B55 RID: 2901
            DeleteUrlCacheGroup
            ' Token: 0x04000B56 RID: 2902
            FindFirstUrlCacheEntry
            ' Token: 0x04000B57 RID: 2903
            FindFirstUrlCacheGroup
            ' Token: 0x04000B58 RID: 2904
            FindNextUrlCacheEntry
            ' Token: 0x04000B59 RID: 2905
            FindNextUrlCacheGroup
            ' Token: 0x04000B5A RID: 2906
            FtpCommand
            ' Token: 0x04000B5B RID: 2907
            FtpCreateDirectory
            ' Token: 0x04000B5C RID: 2908
            FtpDeleteFile
            ' Token: 0x04000B5D RID: 2909
            FtpFindFirstFile
            ' Token: 0x04000B5E RID: 2910
            FtpGetCurrentDirectory
            ' Token: 0x04000B5F RID: 2911
            FtpGetFile
            ' Token: 0x04000B60 RID: 2912
            FtpPutFile
            ' Token: 0x04000B61 RID: 2913
            FtpRemoveDirectory
            ' Token: 0x04000B62 RID: 2914
            FtpRenameFile
            ' Token: 0x04000B63 RID: 2915
            FtpSetCurrentDirectory
            ' Token: 0x04000B64 RID: 2916
            HttpOpenRequest
            ' Token: 0x04000B65 RID: 2917
            HttpQueryInfo
            ' Token: 0x04000B66 RID: 2918
            HttpSendRequest
            ' Token: 0x04000B67 RID: 2919
            InternetAttemptConnect
            ' Token: 0x04000B68 RID: 2920
            InternetAutoDial
            ' Token: 0x04000B69 RID: 2921
            InternetAutoDialHangup
            ' Token: 0x04000B6A RID: 2922
            InternetCheckConnection
            ' Token: 0x04000B6B RID: 2923
            InternetCloseHandle
            ' Token: 0x04000B6C RID: 2924
            InternetConnect
            ' Token: 0x04000B6D RID: 2925
            InternetCrackUrl
            ' Token: 0x04000B6E RID: 2926
            InternetDial
            ' Token: 0x04000B6F RID: 2927
            InternetFindNextFile
            ' Token: 0x04000B70 RID: 2928
            InternetGetConnectedState
            ' Token: 0x04000B71 RID: 2929
            InternetGetCookie
            ' Token: 0x04000B72 RID: 2930
            InternetGetCookieEx
            ' Token: 0x04000B73 RID: 2931
            InternetGetLastResponseInfo
            ' Token: 0x04000B74 RID: 2932
            InternetHangUp
            ' Token: 0x04000B75 RID: 2933
            InternetOpen
            ' Token: 0x04000B76 RID: 2934
            InternetPerConnOptionList
            ' Token: 0x04000B77 RID: 2935
            InternetQueryOption
            ' Token: 0x04000B78 RID: 2936
            InternetSetCookie
            ' Token: 0x04000B79 RID: 2937
            InternetSetOption
            ' Token: 0x04000B7A RID: 2938
            INTERNET_CACHE_ENTRY_INFO
            ' Token: 0x04000B7B RID: 2939
            INTERNET_CACHE_ENTRY_INFOA
            ' Token: 0x04000B7C RID: 2940
            INTERNET_FLAG_RELOAD
            ' Token: 0x04000B7D RID: 2941
            INTERNET_SCHEME
            ' Token: 0x04000B7E RID: 2942
            PrivacyGetZonePreference
            ' Token: 0x04000B7F RID: 2943
            PrivacySetZonePreference
            ' Token: 0x04000B80 RID: 2944
            URL_COMPONENTS
        End Enum

        ' Token: 0x0200006B RID: 107
        Public Enum winmm
            ' Token: 0x04000B82 RID: 2946
            LD83
            ' Token: 0x04000B83 RID: 2947
            mciGetErrorString
            ' Token: 0x04000B84 RID: 2948
            mciSendString
            ' Token: 0x04000B85 RID: 2949
            midiConnect
            ' Token: 0x04000B86 RID: 2950
            midiDisconnect
            ' Token: 0x04000B87 RID: 2951
            MIDIHDR
            ' Token: 0x04000B88 RID: 2952
            midiInClose
            ' Token: 0x04000B89 RID: 2953
            midiInGetDevCaps
            ' Token: 0x04000B8A RID: 2954
            midiInGetNumDevs
            ' Token: 0x04000B8B RID: 2955
            midiInOpen
            ' Token: 0x04000B8C RID: 2956
            midiInReset
            ' Token: 0x04000B8D RID: 2957
            midiInStart
            ' Token: 0x04000B8E RID: 2958
            MIDIOUTCAPS
            ' Token: 0x04000B8F RID: 2959
            midiOutClose
            ' Token: 0x04000B90 RID: 2960
            midiOutGetDevCaps
            ' Token: 0x04000B91 RID: 2961
            midiOutGetErrorText
            ' Token: 0x04000B92 RID: 2962
            midiOutGetNumDevs
            ' Token: 0x04000B93 RID: 2963
            midiOutLongMsg
            ' Token: 0x04000B94 RID: 2964
            midiOutOpen
            ' Token: 0x04000B95 RID: 2965
            midiOutPrepareHeader
            ' Token: 0x04000B96 RID: 2966
            midiOutReset
            ' Token: 0x04000B97 RID: 2967
            midiOutShortMsg
            ' Token: 0x04000B98 RID: 2968
            midiOutUnprepareHeader
            ' Token: 0x04000B99 RID: 2969
            midiStreamClose
            ' Token: 0x04000B9A RID: 2970
            midiStreamOpen
            ' Token: 0x04000B9B RID: 2971
            midiStreamOut
            ' Token: 0x04000B9C RID: 2972
            midiStreamPause
            ' Token: 0x04000B9D RID: 2973
            midiStreamPosition
            ' Token: 0x04000B9E RID: 2974
            midiStreamProperty
            ' Token: 0x04000B9F RID: 2975
            midiStreamRestart
            ' Token: 0x04000BA0 RID: 2976
            midiStreamStop
            ' Token: 0x04000BA1 RID: 2977
            mixerClose
            ' Token: 0x04000BA2 RID: 2978
            MixerFlags
            ' Token: 0x04000BA3 RID: 2979
            mixerGetControlDetails
            ' Token: 0x04000BA4 RID: 2980
            mixerGetDevCaps
            ' Token: 0x04000BA5 RID: 2981
            mixerGetID
            ' Token: 0x04000BA6 RID: 2982
            mixerGetLineControls
            ' Token: 0x04000BA7 RID: 2983
            mixerGetLineInfo
            ' Token: 0x04000BA8 RID: 2984
            mixerGetNumDevs
            ' Token: 0x04000BA9 RID: 2985
            mixerOpen
            ' Token: 0x04000BAA RID: 2986
            mixerSetControlDetails
            ' Token: 0x04000BAB RID: 2987
            MMRESULT
            ' Token: 0x04000BAC RID: 2988
            PlaySound
            ' Token: 0x04000BAD RID: 2989
            timeBeginPeriod
            ' Token: 0x04000BAE RID: 2990
            timeEndPeriod
            ' Token: 0x04000BAF RID: 2991
            timeGetDevCaps
            ' Token: 0x04000BB0 RID: 2992
            timeGetSystemTime
            ' Token: 0x04000BB1 RID: 2993
            timeGetTime
            ' Token: 0x04000BB2 RID: 2994
            timeKillEvent
            ' Token: 0x04000BB3 RID: 2995
            timeSetEvent
            ' Token: 0x04000BB4 RID: 2996
            waveInAddBuffer
            ' Token: 0x04000BB5 RID: 2997
            waveInClose
            ' Token: 0x04000BB6 RID: 2998
            waveInGetNumDevs
            ' Token: 0x04000BB7 RID: 2999
            waveInOpen
            ' Token: 0x04000BB8 RID: 3000
            WaveInOpenFlags
            ' Token: 0x04000BB9 RID: 3001
            waveInPrepareHeader
            ' Token: 0x04000BBA RID: 3002
            waveInPrepareHeader3
            ' Token: 0x04000BBB RID: 3003
            waveInProc
            ' Token: 0x04000BBC RID: 3004
            waveInReset
            ' Token: 0x04000BBD RID: 3005
            waveInStart
            ' Token: 0x04000BBE RID: 3006
            waveInUnprepareHeader
            ' Token: 0x04000BBF RID: 3007
            waveOutClose
            ' Token: 0x04000BC0 RID: 3008
            waveOutGetDevCaps
            ' Token: 0x04000BC1 RID: 3009
            waveOutGetErrorText
            ' Token: 0x04000BC2 RID: 3010
            waveOutGetNumDevs
            ' Token: 0x04000BC3 RID: 3011
            waveOutGetPlaybackRate
            ' Token: 0x04000BC4 RID: 3012
            waveOutGetVolume
            ' Token: 0x04000BC5 RID: 3013
            waveOutOpen
            ' Token: 0x04000BC6 RID: 3014
            waveOutPause
            ' Token: 0x04000BC7 RID: 3015
            waveOutPrepareHeader
            ' Token: 0x04000BC8 RID: 3016
            waveOutReset
            ' Token: 0x04000BC9 RID: 3017
            waveOutSetPlaybackRate
            ' Token: 0x04000BCA RID: 3018
            waveOutSetVolume
            ' Token: 0x04000BCB RID: 3019
            waveOutUnprepareHeader
            ' Token: 0x04000BCC RID: 3020
            waveOutWrite
            ' Token: 0x04000BCD RID: 3021
            WIMMessages
        End Enum

        ' Token: 0x0200006C RID: 108
        Public Enum winscard
            ' Token: 0x04000BCF RID: 3023
            ASCIIEncoding
            ' Token: 0x04000BD0 RID: 3024
            lookupprivilegevalue
            ' Token: 0x04000BD1 RID: 3025
            SCardBeginTransaction
            ' Token: 0x04000BD2 RID: 3026
            SCardConnect
            ' Token: 0x04000BD3 RID: 3027
            SCARDCONTEXT
            ' Token: 0x04000BD4 RID: 3028
            SCardDisconnect
            ' Token: 0x04000BD5 RID: 3029
            SCardEndTransaction
            ' Token: 0x04000BD6 RID: 3030
            SCardEstablishContext
            ' Token: 0x04000BD7 RID: 3031
            SCardFreeMemory
            ' Token: 0x04000BD8 RID: 3032
            SCardGetAttrib
            ' Token: 0x04000BD9 RID: 3033
            SCardGetStatusChange
            ' Token: 0x04000BDA RID: 3034
            SCARDHANDLE
            ' Token: 0x04000BDB RID: 3035
            SCardListReaders
            ' Token: 0x04000BDC RID: 3036
            SCardReleaseContext
            ' Token: 0x04000BDD RID: 3037
            SCardStatus
            ' Token: 0x04000BDE RID: 3038
            SCardTransmit
            ' Token: 0x04000BDF RID: 3039
            WinSCard
        End Enum

        ' Token: 0x0200006D RID: 109
        Public Enum winspool
            ' Token: 0x04000BE1 RID: 3041
            AbortPrinter
            ' Token: 0x04000BE2 RID: 3042
            AddMonitor
            ' Token: 0x04000BE3 RID: 3043
            AddPrinter
            ' Token: 0x04000BE4 RID: 3044
            AddPrinterConnection
            ' Token: 0x04000BE5 RID: 3045
            ClosePrinter
            ' Token: 0x04000BE6 RID: 3046
            DeleteMonitor
            ' Token: 0x04000BE7 RID: 3047
            DeletePrinter
            ' Token: 0x04000BE8 RID: 3048
            DeletePrinterConnection
            ' Token: 0x04000BE9 RID: 3049
            DocumentProperties
            ' Token: 0x04000BEA RID: 3050
            DRIVER_INFO_1
            ' Token: 0x04000BEB RID: 3051
            DRIVER_INFO_2
            ' Token: 0x04000BEC RID: 3052
            DRIVER_INFO_3
            ' Token: 0x04000BED RID: 3053
            DRIVER_INFO_5
            ' Token: 0x04000BEE RID: 3054
            DRIVER_INFO_6
            ' Token: 0x04000BEF RID: 3055
            DRIVER_INFO_8
            ' Token: 0x04000BF0 RID: 3056
            EndDocPrinter
            ' Token: 0x04000BF1 RID: 3057
            EndPagePrinter
            ' Token: 0x04000BF2 RID: 3058
            EnumJobs
            ' Token: 0x04000BF3 RID: 3059
            EnumMonitors
            ' Token: 0x04000BF4 RID: 3060
            EnumPorts
            ' Token: 0x04000BF5 RID: 3061
            EnumPrinterData
            ' Token: 0x04000BF6 RID: 3062
            EnumPrinterDrivers
            ' Token: 0x04000BF7 RID: 3063
            EnumPrinters
            ' Token: 0x04000BF8 RID: 3064
            EnumPrintProcessorDatatypes
            ' Token: 0x04000BF9 RID: 3065
            EnumPrintProcessors
            ' Token: 0x04000BFA RID: 3066
            FindFirstPrinterChangeNotification
            ' Token: 0x04000BFB RID: 3067
            FlushPrinter
            ' Token: 0x04000BFC RID: 3068
            GadgetNews
            ' Token: 0x04000BFD RID: 3069
            GetDefaultPrinter
            ' Token: 0x04000BFE RID: 3070
            GetPrinter
            ' Token: 0x04000BFF RID: 3071
            GetPrinterData
            ' Token: 0x04000C00 RID: 3072
            GetPrinterDriver
            ' Token: 0x04000C01 RID: 3073
            GetPrinterDriverDir
            ' Token: 0x04000C02 RID: 3074
            GetPrintProcessorDirectory
            ' Token: 0x04000C03 RID: 3075
            OpenPrinter
            ' Token: 0x04000C04 RID: 3076
            print
            ' Token: 0x04000C05 RID: 3077
            PRINTPROCESSOR_INFO_1
            ' Token: 0x04000C06 RID: 3078
            ReadPrinter
            ' Token: 0x04000C07 RID: 3079
            ResetPrinter
            ' Token: 0x04000C08 RID: 3080
            SetDefaultPrinter
            ' Token: 0x04000C09 RID: 3081
            SetJob
            ' Token: 0x04000C0A RID: 3082
            SetPrinter
            ' Token: 0x04000C0B RID: 3083
            SetPrinterData
            ' Token: 0x04000C0C RID: 3084
            StartDocPrinter
            ' Token: 0x04000C0D RID: 3085
            WritePrinter
            ' Token: 0x04000C0E RID: 3086
            XcvData
        End Enum

        ' Token: 0x0200006E RID: 110
        Public Enum wintrust
            ' Token: 0x04000C10 RID: 3088
            IsCatalogFile
            ' Token: 0x04000C11 RID: 3089
            WinVerifyTrust
        End Enum

        ' Token: 0x0200006F RID: 111
        Public Enum winusb
            ' Token: 0x04000C13 RID: 3091
            WinUsb_Free
            ' Token: 0x04000C14 RID: 3092
            WinUsb_GetAssociatedInterface
            ' Token: 0x04000C15 RID: 3093
            WinUsb_Initialize
        End Enum

        ' Token: 0x02000070 RID: 112
        Public Enum wlanapi
            ' Token: 0x04000C17 RID: 3095
            EapHostPeerInvokeConfigUI
            ' Token: 0x04000C18 RID: 3096
            WlanCloseHandle
            ' Token: 0x04000C19 RID: 3097
            WlanConnect
            ' Token: 0x04000C1A RID: 3098
            WlanDeleteProfile
            ' Token: 0x04000C1B RID: 3099
            WlanDisconnect
            ' Token: 0x04000C1C RID: 3100
            WlanEnumInterfaces
            ' Token: 0x04000C1D RID: 3101
            WlanFreeMemory
            ' Token: 0x04000C1E RID: 3102
            WlanGetAvailableNetworkList
            ' Token: 0x04000C1F RID: 3103
            WlanGetNetworkBssList
            ' Token: 0x04000C20 RID: 3104
            WlanGetProfile
            ' Token: 0x04000C21 RID: 3105
            WlanGetProfileList
            ' Token: 0x04000C22 RID: 3106
            WlanHostedNetworkForceStart
            ' Token: 0x04000C23 RID: 3107
            WlanHostedNetworkForceStop
            ' Token: 0x04000C24 RID: 3108
            WlanHostedNetworkInitSettings
            ' Token: 0x04000C25 RID: 3109
            WlanHostedNetworkQuerySecondaryKey
            ' Token: 0x04000C26 RID: 3110
            WlanHostedNetworkQueryStatus
            ' Token: 0x04000C27 RID: 3111
            WlanHostedNetworkRefreshSecuritySettings
            ' Token: 0x04000C28 RID: 3112
            WlanHostedNetworkSetProperty
            ' Token: 0x04000C29 RID: 3113
            WlanHostedNetworkStartUsing
            ' Token: 0x04000C2A RID: 3114
            WlanHostedNetworkStopUsing
            ' Token: 0x04000C2B RID: 3115
            WlanOpenHandle
            ' Token: 0x04000C2C RID: 3116
            WlanQueryInterface
            ' Token: 0x04000C2D RID: 3117
            WlanReasonCodeToString
            ' Token: 0x04000C2E RID: 3118
            WlanRegisterNotification
            ' Token: 0x04000C2F RID: 3119
            WlanRegisterVirtualStationNotification
            ' Token: 0x04000C30 RID: 3120
            WlanScan
            ' Token: 0x04000C31 RID: 3121
            WlanSetInterface
            ' Token: 0x04000C32 RID: 3122
            WlanSetProfile
            ' Token: 0x04000C33 RID: 3123
            WlanSetProfileList
            ' Token: 0x04000C34 RID: 3124
            WlanSetProfilePosition
            ' Token: 0x04000C35 RID: 3125
            WLAN_RADIO_STATE
            ' Token: 0x04000C36 RID: 3126
            WLAN_STATISTICS
        End Enum

        ' Token: 0x02000071 RID: 113
        Public Enum ws2_32
            ' Token: 0x04000C38 RID: 3128
            accept
            ' Token: 0x04000C39 RID: 3129
            ADDRESS_FAMILIES
            ' Token: 0x04000C3A RID: 3130
            bind
            ' Token: 0x04000C3B RID: 3131
            closesocket
            ' Token: 0x04000C3C RID: 3132
            Command
            ' Token: 0x04000C3D RID: 3133
            connect
            ' Token: 0x04000C3E RID: 3134
            ControlCode
            ' Token: 0x04000C3F RID: 3135
            gethostname
            ' Token: 0x04000C40 RID: 3136
            getsockopt
            ' Token: 0x04000C41 RID: 3137
            htonl
            ' Token: 0x04000C42 RID: 3138
            htons
            ' Token: 0x04000C43 RID: 3139
            InetNtop
            ' Token: 0x04000C44 RID: 3140
            inet_addr
            ' Token: 0x04000C45 RID: 3141
            inet_ntoa
            ' Token: 0x04000C46 RID: 3142
            inet_pton
            ' Token: 0x04000C47 RID: 3143
            INTERFACE_INFO
            ' Token: 0x04000C48 RID: 3144
            ioCommand
            ' Token: 0x04000C49 RID: 3145
            ioctlsocket
            ' Token: 0x04000C4A RID: 3146
            listen
            ' Token: 0x04000C4B RID: 3147
            MsgFlags
            ' Token: 0x04000C4C RID: 3148
            ntohl
            ' Token: 0x04000C4D RID: 3149
            ntohs
            ' Token: 0x04000C4E RID: 3150
            PROTOCOL
            ' Token: 0x04000C4F RID: 3151
            recv
            ' Token: 0x04000C50 RID: 3152
            RecvFrom
            ' Token: 0x04000C51 RID: 3153
            send
            ' Token: 0x04000C52 RID: 3154
            SendTo
            ' Token: 0x04000C53 RID: 3155
            setsockopt
            ' Token: 0x04000C54 RID: 3156
            shutdown
            ' Token: 0x04000C55 RID: 3157
            socket
            ' Token: 0x04000C56 RID: 3158
            SocketOptionLevel
            ' Token: 0x04000C57 RID: 3159
            SocketOptionName
            ' Token: 0x04000C58 RID: 3160
            SOCKET_OPTION_NAME
            ' Token: 0x04000C59 RID: 3161
            SOCKET_TYPE
            ' Token: 0x04000C5A RID: 3162
            tcp_keepalive
            ' Token: 0x04000C5B RID: 3163
            WSAAddressToString
            ' Token: 0x04000C5C RID: 3164
            WSACleanup
            ' Token: 0x04000C5D RID: 3165
            WSAData
            ' Token: 0x04000C5E RID: 3166
            WSAEnumNameSpaceProviders
            ' Token: 0x04000C5F RID: 3167
            WSAGetLastError
            ' Token: 0x04000C60 RID: 3168
            WSAIoctl
            ' Token: 0x04000C61 RID: 3169
            WSALookupServiceBegin
            ' Token: 0x04000C62 RID: 3170
            WSALookupServiceEnd
            ' Token: 0x04000C63 RID: 3171
            WSALookupServiceNext
            ' Token: 0x04000C64 RID: 3172
            WSANSIoctl
            ' Token: 0x04000C65 RID: 3173
            WSAPROTOCOL_INFO
            ' Token: 0x04000C66 RID: 3174
            WSASocket
            ' Token: 0x04000C67 RID: 3175
            WSAStartup
            ' Token: 0x04000C68 RID: 3176
            WSAStringToAddress
        End Enum

        ' Token: 0x02000072 RID: 114
        Public Enum wtsapi32
            ' Token: 0x04000C6A RID: 3178
            addfunction
            ' Token: 0x04000C6B RID: 3179
            TerminalServices
            ' Token: 0x04000C6C RID: 3180
            WTSCloseServer
            ' Token: 0x04000C6D RID: 3181
            WTSDisconnectSession
            ' Token: 0x04000C6E RID: 3182
            WTSEnumerateListeners
            ' Token: 0x04000C6F RID: 3183
            WTSEnumerateProcesses
            ' Token: 0x04000C70 RID: 3184
            WTSEnumerateServers
            ' Token: 0x04000C71 RID: 3185
            WTSEnumerateSessions
            ' Token: 0x04000C72 RID: 3186
            WTSFreeMemory
            ' Token: 0x04000C73 RID: 3187
            WTSLogoffSession
            ' Token: 0x04000C74 RID: 3188
            WTSOpenServer
            ' Token: 0x04000C75 RID: 3189
            WTSQuerySessionInformation
            ' Token: 0x04000C76 RID: 3190
            WTSQueryUserToken
            ' Token: 0x04000C77 RID: 3191
            WTSRegisterSessionNotification
            ' Token: 0x04000C78 RID: 3192
            WTSSendMessage
            ' Token: 0x04000C79 RID: 3193
            WTSShutdownSystem
            ' Token: 0x04000C7A RID: 3194
            WTSTerminateProcess
            ' Token: 0x04000C7B RID: 3195
            WTSUnRegisterSessionNotification
            ' Token: 0x04000C7C RID: 3196
            WTSVirtualChannelClose
            ' Token: 0x04000C7D RID: 3197
            WTSVirtualChannelOpen
            ' Token: 0x04000C7E RID: 3198
            WTSVirtualChannelRead
            ' Token: 0x04000C7F RID: 3199
            WTSVirtualChannelWrite
            ' Token: 0x04000C80 RID: 3200
            WTS_CLIENT_ADDRESS
            ' Token: 0x04000C81 RID: 3201
            WTS_CONNECTSTATE_CLASS
            ' Token: 0x04000C82 RID: 3202
            WTS_INFO_CLASS
            ' Token: 0x04000C83 RID: 3203
            WTS_PROCESS_INFO
        End Enum

        ' Token: 0x02000073 RID: 115
        Public Enum xolehlp
            ' Token: 0x04000C85 RID: 3205
            DtcGetTransactionManager
        End Enum

        ' Token: 0x02000074 RID: 116
        Public Enum xpsprint
            ' Token: 0x04000C87 RID: 3207
            None
        End Enum
    End Class

End Namespace

