Imports System
Imports System.ComponentModel
Imports System.IO
' ***********************************************************************
' Author   : Destroyer
' Modified : 11-November-2015
' ***********************************************************************
' <copyright file="RegeditWatcher.vb" company="S4Lsalsoft">
'     Copyright (c) S4Lsalsoft. All rights reserved.
' </copyright>
' ***********************************************************************

Imports System.Threading
Imports System.Runtime.InteropServices
Imports Microsoft.Win32
Imports System.Security.Principal

Namespace Core.Engine.Watcher

    'Public Class MonitorSample
    ' Private Shared Sub Main()
    '  Dim monitor As RegistryMonitor = New RegistryMonitor(RegistryHive.CurrentUser, "Environment")
    '         AddHandler monitor.RegChanged, New EventHandler(AddressOf OnRegChanged)
    '         monitor.Start()

    '         While True
    '         End While
    '
    '        monitor.[Stop]()
    '  End Sub

    '  Private Sub OnRegChanged(ByVal sender As Object, ByVal e As EventArgs)
    '         Console.WriteLine("registry key has changed")
    ' End Sub
    'End Class

    Public Class RegistryMonitor
        Implements IDisposable

#Region " P/Invoke "

        <DllImport("advapi32.dll", SetLastError:=True)>
        Private Shared Function RegOpenKeyEx(ByVal hKey As IntPtr, ByVal subKey As String, ByVal options As UInteger, ByVal samDesired As Integer, <Out> ByRef phkResult As IntPtr) As Integer
        End Function

        <DllImport("advapi32.dll", SetLastError:=True)>
        Private Shared Function RegNotifyChangeKeyValue(ByVal hKey As IntPtr, ByVal bWatchSubtree As Boolean, ByVal dwNotifyFilter As RegChangeNotifyFilter, ByVal hEvent As IntPtr, ByVal fAsynchronous As Boolean) As Integer
        End Function

        <DllImport("advapi32.dll", SetLastError:=True)>
        Private Shared Function RegQueryValueEx(
    ByVal hKey As IntPtr,
    ByVal lpValueName As String,
    ByVal lpReserved As Integer,
    ByRef lpType As Integer,
    ByVal lpData As System.Text.StringBuilder,
    ByRef lpcbData As Integer) As Integer
        End Function

        <DllImport("advapi32.dll", SetLastError:=True)>
        Private Shared Function RegQueryValueEx(
    ByVal hKey As IntPtr,
    ByVal lpValueName As String,
    ByVal lpReserved As Integer,
    ByRef lpType As Integer,
    ByVal lpData As Byte(),
    ByRef lpcbData As Integer) As Integer
        End Function

        <DllImport("advapi32.dll", SetLastError:=True)>
        Private Shared Function RegCloseKey(ByVal hKey As IntPtr) As Integer
        End Function


#End Region

#Region " Const "

        Private Const KEY_QUERY_VALUE As Integer = &H1
        Private Const KEY_NOTIFY As Integer = &H10
        Private Const STANDARD_RIGHTS_READ As Integer = &H20000

#End Region

#Region " Declare's "

        Private Shared ReadOnly HKEY_CLASSES_ROOT As IntPtr = New IntPtr(CInt(&H80000000))
        Private Shared ReadOnly HKEY_CURRENT_USER As IntPtr = New IntPtr(CInt(&H80000001))
        Private Shared ReadOnly HKEY_LOCAL_MACHINE As IntPtr = New IntPtr(CInt(&H80000002))
        Private Shared ReadOnly HKEY_USERS As IntPtr = New IntPtr(CInt(&H80000003))
        Private Shared ReadOnly HKEY_PERFORMANCE_DATA As IntPtr = New IntPtr(CInt(&H80000004))
        Private Shared ReadOnly HKEY_CURRENT_CONFIG As IntPtr = New IntPtr(CInt(&H80000005))
        Private Shared ReadOnly HKEY_DYN_DATA As IntPtr = New IntPtr(CInt(&H80000006))

#End Region

#Region " Event handling "

        Public Event RegChanged As EventHandler

        Protected Overridable Sub OnRegChanged(ByVal Info As RegistryStatusChangedEventArgs)
            RaiseEvent RegChanged(Me, Info)
        End Sub

        Public Event ErrorEvent As ErrorEventHandler

        Protected Overridable Sub OnError(ByVal e As Exception)
            RaiseEvent ErrorEvent(Me, New ErrorEventArgs(e))
        End Sub

#End Region

#Region " Private Variables "

        Private _registryHive As IntPtr
        Private _registrySubName As String
        Private _threadLock As Object = New Object()
        Private _thread As Thread
        Private _disposed As Boolean = False
        Private _eventTerminate As ManualResetEvent = New ManualResetEvent(False)
        Private _regFilter As RegChangeNotifyFilter = RegChangeNotifyFilter.Key Or RegChangeNotifyFilter.Attribute Or RegChangeNotifyFilter.Value Or RegChangeNotifyFilter.Security

#End Region

        Public Sub New(ByVal registryKey As RegistryKey)
            InitRegistryKey(registryKey.Name)
        End Sub

        Public Sub New(ByVal name As String)
            If name Is Nothing OrElse name.Length = 0 Then Throw New ArgumentNullException("name")
            InitRegistryKey(name)
        End Sub

        Public Sub New(ByVal registryHive As RegistryHive, ByVal subKey As String)
            InitRegistryKey(registryHive, subKey)
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            [Stop]()
            _disposed = True
            GC.SuppressFinalize(Me)
        End Sub

        Public Property RegChangedNotifyFilter As RegChangeNotifyFilter
            Get
                Return _regFilter
            End Get
            Set(ByVal value As RegChangeNotifyFilter)

                SyncLock _threadLock
                    If IsMonitoring Then Throw New InvalidOperationException("Monitoring thread is already running")
                    _regFilter = value
                End SyncLock
            End Set
        End Property

#Region " Initialization "

        Private Sub InitRegistryKey(ByVal hive As RegistryHive, ByVal name As String)
            Select Case hive
                Case RegistryHive.ClassesRoot
                    _registryHive = HKEY_CLASSES_ROOT
                Case RegistryHive.CurrentConfig
                    _registryHive = HKEY_CURRENT_CONFIG
                Case RegistryHive.CurrentUser
                    _registryHive = HKEY_CURRENT_USER
                Case RegistryHive.DynData
                    _registryHive = HKEY_DYN_DATA
                Case RegistryHive.LocalMachine
                    _registryHive = HKEY_LOCAL_MACHINE
                Case RegistryHive.PerformanceData
                    _registryHive = HKEY_PERFORMANCE_DATA
                Case RegistryHive.Users
                    _registryHive = HKEY_USERS
                Case Else
                    Throw New InvalidEnumArgumentException("hive", CInt(hive), GetType(RegistryHive))
            End Select

            _registrySubName = name
        End Sub

        Private Sub InitRegistryKey(ByVal name As String)
            Dim nameParts As String() = name.Split("\"c)

            Select Case nameParts(0)
                Case "HKEY_CLASSES_ROOT", "HKCR"
                    _registryHive = HKEY_CLASSES_ROOT
                Case "HKEY_CURRENT_USER", "HKCU"
                    _registryHive = HKEY_CURRENT_USER
                Case "HKEY_LOCAL_MACHINE", "HKLM"
                    _registryHive = HKEY_LOCAL_MACHINE
                Case "HKEY_USERS"
                    _registryHive = HKEY_USERS
                Case "HKEY_CURRENT_CONFIG"
                    _registryHive = HKEY_CURRENT_CONFIG
                Case Else
                    _registryHive = IntPtr.Zero
                    Throw New ArgumentException("The registry hive '" & nameParts(0) & "' is not supported", "value")
            End Select

            _registrySubName = String.Join("\", nameParts, 1, nameParts.Length - 1)
        End Sub

#End Region

#Region " Enum "

        ''' <summary>
        ''' Filter for notifications reported by <see cref="RegistryMonitor"/>.
        ''' </summary>
        <Flags>
        Public Enum RegChangeNotifyFilter
            ''' <summary>Notify the caller if a subkey is added or deleted.</summary>
            Key = 1
            ''' <summary>Notify the caller of changes to the attributes of the key,
            ''' such as the security descriptor information.</summary>
            Attribute = 2
            ''' <summary>Notify the caller of changes to a value of the key. This can
            ''' include adding Or deleting a value, Or changing an existing value.</summary>
            Value = 4
            ''' <summary>Notify the caller of changes to the security descriptor
            ''' of the key.</summary>
            Security = 8
        End Enum

#End Region

#Region " Properties "

        Public ReadOnly Property IsMonitoring As Boolean
            Get
                Return _thread IsNot Nothing
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub Start()
            If _disposed Then Throw New ObjectDisposedException(Nothing, "This instance is already disposed")

            SyncLock _threadLock

                If Not IsMonitoring Then
                    _eventTerminate.Reset()
                    _thread = New Thread(New ThreadStart(AddressOf MonitorThread))
                    _thread.IsBackground = True
                    _thread.Start()
                End If
            End SyncLock
        End Sub

        Public Sub [Stop]()
            If _disposed Then Throw New ObjectDisposedException(Nothing, "This instance is already disposed")

            SyncLock _threadLock
                Dim thread As Thread = _thread

                If thread IsNot Nothing Then
                    _eventTerminate.[Set]()
                    thread.Join()
                End If
            End SyncLock
        End Sub

        Private Sub MonitorThread()
            Try
                ThreadLoop()
            Catch e As Exception
                OnError(e)
            End Try

            _thread = Nothing
        End Sub

        Private Sub ThreadLoop()
            Dim registryKey As IntPtr
            Dim result As Integer = RegOpenKeyEx(_registryHive, _registrySubName, 0, STANDARD_RIGHTS_READ Or KEY_QUERY_VALUE Or KEY_NOTIFY, registryKey)
            If result <> 0 Then Throw New Win32Exception(result)

            Try
                Dim _eventNotify As AutoResetEvent = New AutoResetEvent(False)
                Dim waitHandles As WaitHandle() = New WaitHandle() {_eventNotify, _eventTerminate}

                While Not _eventTerminate.WaitOne(0, True)
                    result = RegNotifyChangeKeyValue(registryKey, True, _regFilter, _eventNotify.Handle, True)
                    If result <> 0 Then Throw New Win32Exception(result)

                    If WaitHandle.WaitAny(waitHandles) = 0 Then
                        Dim StrInfo As String = "Path: " & _registryHive.ToString & "\" & _registrySubName
                        Dim InfoReg As New RegistryStatusChangedEventArgs(StrInfo)
                        OnRegChanged(InfoReg)
                    End If
                End While

            Finally

                If registryKey <> IntPtr.Zero Then
                    RegCloseKey(registryKey)
                End If
            End Try
        End Sub

#End Region

#Region " Events Data "

#Region " DriveStatusChangedEventArgs "

        Public NotInheritable Class RegistryStatusChangedEventArgs : Inherits EventArgs

#Region " Properties "

            Private ReadOnly RegeditInfoB As String = String.Empty
            Public ReadOnly Property RegeditInfo As String
                <DebuggerStepThrough>
                Get
                    Return Me.RegeditInfoB
                End Get
            End Property

#End Region

#Region " Constructors "

            Private Sub New()
            End Sub

            Public Sub New(ByVal RegeditInfo As String)

                Me.RegeditInfoB = RegeditInfo

            End Sub

#End Region

        End Class

#End Region

#End Region

    End Class




End Namespace