Imports System.Runtime.InteropServices

Namespace Core.Helper
    Public Class PrivilegesManager
        'This routine enables the Shutdown privilege for the current process,
        'which is necessary if you want to call ExitWindowsEx.

        Public Const ANYSIZE_ARRAY As Integer = 1
        Public Const TOKEN_QUERY As Integer = &H8
        Public Const TOKEN_ADJUST_PRIVILEGES As Integer = &H20
        Public Const SE_SHUTDOWN_NAME As String = "SeShutdownPrivilege"
        Public Const SE_PRIVILEGE_ENABLED As Integer = &H2

        <StructLayout(LayoutKind.Sequential)>
        Public Structure LUID
            Public LowPart As UInt32
            Public HighPart As UInt32
        End Structure

        <StructLayout(LayoutKind.Sequential)>
        Public Structure LUID_AND_ATTRIBUTES
            Public Luid As LUID
            Public Attributes As UInt32
        End Structure

        <StructLayout(LayoutKind.Sequential)>
        Public Structure TOKEN_PRIVILEGES
            Public PrivilegeCount As UInt32
            <MarshalAs(UnmanagedType.ByValArray, SizeConst:=ANYSIZE_ARRAY)>
            Public Privileges() As LUID_AND_ATTRIBUTES
        End Structure

        <DllImport("advapi32.dll", SetLastError:=True)>
        Public Shared Function LookupPrivilegeValue(
         ByVal lpSystemName As String,
         ByVal lpName As String,
         ByRef lpLuid As LUID
          ) As Boolean
        End Function

        <DllImport("advapi32.dll", SetLastError:=True)>
        Public Shared Function OpenProcessToken(
         ByVal ProcessHandle As IntPtr,
         ByVal DesiredAccess As Integer,
         ByRef TokenHandle As IntPtr
          ) As Boolean
        End Function

        <DllImport("kernel32.dll", SetLastError:=True)>
        Public Shared Function CloseHandle(ByVal hHandle As IntPtr) As Boolean
        End Function

        <DllImport("advapi32.dll", SetLastError:=True)>
        Public Shared Function AdjustTokenPrivileges(
           ByVal TokenHandle As IntPtr,
           ByVal DisableAllPrivileges As Boolean,
           ByRef NewState As TOKEN_PRIVILEGES,
           ByVal BufferLength As Integer,
           ByRef PreviousState As TOKEN_PRIVILEGES,
           ByRef ReturnLength As IntPtr
         ) As Boolean
        End Function

        Public Sub AcquireShutdownPrivilege(ByVal hProc As IntPtr)

            Dim lastWin32Error As Integer = 0

            'Get the LUID that corresponds to the Shutdown privilege, if it exists.
            Dim luid_Shutdown As LUID
            If Not LookupPrivilegeValue(Nothing, SE_SHUTDOWN_NAME, luid_Shutdown) Then
                lastWin32Error = Marshal.GetLastWin32Error()
                Throw New System.ComponentModel.Win32Exception(lastWin32Error,
                 "LookupPrivilegeValue failed with error " & lastWin32Error.ToString & ".")
            End If

            'Get the current process's token.
            'Dim hProc As IntPtr = Process.GetCurrentProcess().Handle

            Dim hToken As IntPtr

            If Not OpenProcessToken(hProc, TOKEN_ADJUST_PRIVILEGES Or TOKEN_QUERY, hToken) Then
                lastWin32Error = Marshal.GetLastWin32Error()
                Throw New System.ComponentModel.Win32Exception(lastWin32Error, "OpenProcessToken failed with error " & lastWin32Error.ToString & ".")
            End If

            Try

                'Set up a LUID_AND_ATTRIBUTES structure containing the Shutdown privilege, marked as enabled.
                Dim luaAttr As New LUID_AND_ATTRIBUTES
                luaAttr.Luid = luid_Shutdown
                luaAttr.Attributes = SE_PRIVILEGE_ENABLED

                'Set up a TOKEN_PRIVILEGES structure containing only the shutdown privilege.
                Dim newState As New TOKEN_PRIVILEGES
                newState.PrivilegeCount = 1
                newState.Privileges = New LUID_AND_ATTRIBUTES() {luaAttr}

                'Set up a TOKEN_PRIVILEGES structure for the returned (modified) privileges.
                Dim prevState As TOKEN_PRIVILEGES = New TOKEN_PRIVILEGES
                ReDim prevState.Privileges(CInt(newState.PrivilegeCount))

                'Apply the TOKEN_PRIVILEGES structure to the current process's token.
                Dim returnLength As IntPtr
                If Not AdjustTokenPrivileges(hToken, False, newState, Marshal.SizeOf(prevState), prevState, returnLength) Then
                    lastWin32Error = Marshal.GetLastWin32Error()
                    Throw New System.ComponentModel.Win32Exception(lastWin32Error, "AdjustTokenPrivileges failed with error " & lastWin32Error.ToString & ".")
                End If

            Finally
                CloseHandle(hToken)
            End Try

        End Sub

    End Class
End Namespace
