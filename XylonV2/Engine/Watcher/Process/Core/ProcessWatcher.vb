' ***********************************************************************
' Author   : Destroyer
' Modified : 11-November-2015
' ***********************************************************************
' <copyright file="DriveWatcher.vb" company="S4Lsalsoft">
'     Copyright (c) S4Lsalsoft. All rights reserved.
' </copyright>
' ***********************************************************************

' Example
'  ProcessStartWatcher.Start()
'  ProcessStopWatcher.Start()
'

Imports System.ComponentModel
Imports System.Management
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms

Namespace Core.Engine.Watcher
    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' A device insertion and removal monitor.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Public Class ProcessWatcher : Inherits NativeWindow : Implements IDisposable


#Region " Constructor "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Initializes a new instance of <see cref="ProcessWatcher"/> class.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Sub New()

            Me.events = New EventHandlerList

        End Sub

#End Region

#Region " Properties "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets a value that determines whether the monitor is running.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Public ReadOnly Property IsRunning As Boolean
            <DebuggerStepThrough>
            Get
                Return Me.isRunningB
            End Get
        End Property
        Private isRunningB As Boolean

#End Region

        Private WithEvents ProcessStartWatcher As ManagementEventWatcher = New ManagementEventWatcher(New WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace"))

        Private WithEvents ProcessStopWatcher As ManagementEventWatcher = New System.Management.ManagementEventWatcher(New WqlEventQuery("SELECT * FROM Win32_ProcessStopTrace"))

#Region " Events "


        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' A list of event delegates.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private ReadOnly events As EventHandlerList

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Occurs when a drive is inserted, removed, or changed.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Public Custom Event ProcessStatusChanged As EventHandler(Of ProcessStatusChangedEventArgs)

            <DebuggerNonUserCode>
            <DebuggerStepThrough>
            AddHandler(ByVal value As EventHandler(Of ProcessStatusChangedEventArgs))
                Me.events.AddHandler("ProcessStatusChangedEvent", value)
            End AddHandler

            <DebuggerNonUserCode>
            <DebuggerStepThrough>
            RemoveHandler(ByVal value As EventHandler(Of ProcessStatusChangedEventArgs))
                Me.events.RemoveHandler("ProcessStatusChangedEvent", value)
            End RemoveHandler

            <DebuggerNonUserCode>
            <DebuggerStepThrough>
            RaiseEvent(ByVal sender As Object, ByVal e As ProcessStatusChangedEventArgs)
                Dim handler As EventHandler(Of ProcessStatusChangedEventArgs) = DirectCast(Me.events("ProcessStatusChangedEvent"), EventHandler(Of ProcessStatusChangedEventArgs))

                If (handler IsNot Nothing) Then
                    handler.Invoke(sender, e)
                End If
            End RaiseEvent

        End Event

#End Region

        Private ProcessHistory As New List(Of Process)
        Private ProcessTempHistory As New List(Of Process)

        Public Sub ProcessStartWatcher_EventArrived(ByVal sender As Object, ByVal e As EventArrivedEventArgs) Handles ProcessStartWatcher.EventArrived
            ' MsgBox(String.Format("Process : {0}", e.NewEvent.Properties("ProcessID").Value.ToString))
            Try

                Dim ProcID As String = e.NewEvent.Properties("ProcessID").Value
                Dim deviceEvent As ProcessEvents = ProcessEvents.Arrival
                Dim driveInfo As Process = Process.GetProcessById(ProcID)

                ProcessHistory.Add(driveInfo)
                ProcessTempHistory.Add(driveInfo)


                Dim NewProcessEvent As New ProcessStatusChangedEventArgs(deviceEvent, driveInfo)
                NewProcessEvent.ProcessID = ProcID

                Me.OnProcessStatusChanged(NewProcessEvent)

            Catch ex As Exception
                '  MsgBox(ex.Message)
            End Try

        End Sub

        Private Sub ProcessStopWatcher_Stopped(ByVal sender As Object, ByVal e As EventArrivedEventArgs) Handles ProcessStopWatcher.EventArrived
            ' MsgBox(String.Format("Process : {0}", e.NewEvent.Properties("ProcessID").Value.ToString))
            Try
                Dim ProcID As String = e.NewEvent.Properties("ProcessID").Value
                Dim deviceEvent As ProcessEvents = ProcessEvents.Stopped

                Dim driveInfo As Process = ProcessTempHistory.Where(Function(x) x.Id = ProcID).FirstOrDefault
                Dim NewProcessEvent As New ProcessStatusChangedEventArgs(deviceEvent, driveInfo)
                NewProcessEvent.ProcessID = ProcID
                Me.OnProcessStatusChanged(NewProcessEvent)

                ProcessTempHistory.Remove(driveInfo)
            Catch ex As Exception

            End Try

        End Sub


#Region " Event Invocators "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Raises <see cref="ProcessStatusChanged"/> event.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="e">
        ''' The <see cref="ProcessStatusChangedEventArgs"/> instance containing the event data.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Protected Overridable Sub OnProcessStatusChanged(ByVal e As ProcessStatusChangedEventArgs)

            RaiseEvent ProcessStatusChanged(Me, e)

        End Sub

#End Region

#Region " Events Data "

        <DllImport("psapi.dll", SetLastError:=True)>
        Public Shared Function EnumProcessModules(ByVal hProcess As IntPtr, <MarshalAs(UnmanagedType.LPArray, ArraySubType:=UnmanagedType.U4)> <[In]()> <Out()> ByVal lphModule As IntPtr, ByVal cb As UInteger, <MarshalAs(UnmanagedType.U4)> ByRef lpcbNeeded As UInteger) As Boolean
        End Function

        <DllImport("psapi.dll")>
        Public Shared Function GetModuleFileNameEx(ByVal hProcess As IntPtr, ByVal hModule As IntPtr, <Out()> ByVal lpBaseName As StringBuilder, <[In]()> <MarshalAs(UnmanagedType.U4)> ByVal nSize As Integer) As UInteger
        End Function

#Region " ProcessStatusChangedEventArgs "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Contains the event-data of a <see cref="ProcessStatusChanged"/> event.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Public NotInheritable Class ProcessStatusChangedEventArgs : Inherits EventArgs

#Region " Properties "

            Public ProcessID As String = String.Empty

            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' Gets the device event that occurred.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            ''' <value>
            ''' The drive info.
            ''' </value>
            ''' ----------------------------------------------------------------------------------------------------
            Public ReadOnly Property ProcessEvent As ProcessEvents
                <DebuggerStepThrough>
                Get
                    Return Me.ProcessEventsB
                End Get
            End Property
            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' ( Backing field )
            ''' The device event that occurred.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            Private ReadOnly ProcessEventsB As ProcessEvents

            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' Gets the drive info.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            ''' <value>
            ''' The drive info.
            ''' </value>
            ''' ----------------------------------------------------------------------------------------------------
            Public ReadOnly Property ProcessInfo As Process
                <DebuggerStepThrough>
                Get
                    Return Me.ProcessInfoB
                End Get
            End Property
            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' ( Backing field )
            ''' The drive info.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------

            Private ReadOnly ProcessInfoB As Process

            Private ReadOnly Win32InfoB As Core.Engine.WMI.Win32_Process = Nothing

            Public ReadOnly Property Win32Info As Core.Engine.WMI.Win32_Process
                <DebuggerStepThrough>
                Get
                    Return Me.Win32InfoB
                End Get
            End Property


#End Region

#Region " Constructors "

            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' Prevents a default instance of the <see cref="ProcessStatusChangedEventArgs"/> class from being created.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            <DebuggerNonUserCode>
            Private Sub New()
            End Sub

            ''' ----------------------------------------------------------------------------------------------------
            ''' <summary>
            ''' Initializes a new instance of the <see cref="ProcessStatusChangedEventArgs"/> class.
            ''' </summary>
            ''' ----------------------------------------------------------------------------------------------------
            ''' <param name="ProcessInfo">
            ''' The Process info.
            ''' </param>
            ''' ----------------------------------------------------------------------------------------------------
            <DebuggerStepThrough>
            Public Sub New(ByVal deviceEvent As ProcessEvents, ByVal ProcessInfo As Process)
                Me.ProcessEventsB = deviceEvent
                Me.ProcessInfoB = ProcessInfo

                Try
                    If deviceEvent = ProcessEvents.Arrival Then
                        Win32InfoB = Core.Engine.WMI.Win32_Process.GetProcesses(ProcessInfo.Id)

                        If Win32InfoB Is Nothing Then
                            ' MsgBox("Query Error: " & ProcessInfo.ProcessName)
                        End If
                    End If
                Catch ex As Exception
                    ' Throw New Exception(ex.Message)
                End Try

            End Sub

#End Region

        End Class

#End Region

#End Region

#Region " Enumerations "

        Public Enum ProcessEvents As Integer

            ''' <summary>
            ''' A device or piece of media has been inserted and becomes available.
            ''' </summary>
            Arrival = 0

            ''' <summary>
            ''' Request permission to remove a device or piece of media.
            ''' <para></para>
            ''' This message is the last chance for applications and drivers to prepare for this removal.
            ''' However, any application can deny this request and cancel the operation.
            ''' </summary>
            Stopped = 1

        End Enum

#End Region

#Region " Methods "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Starts monitoring.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <exception cref="Exception">
        ''' Monitor is already running.
        ''' </exception>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Overridable Sub Start()

            If (Me.Handle = IntPtr.Zero) Then
                MyBase.CreateHandle(New CreateParams)
                ProcessStartWatcher.Start()
                ProcessStopWatcher.Start()
                ProcessTempHistory.AddRange(Process.GetProcesses.ToList)
                Me.isRunningB = True

            Else
                Throw New Exception(message:="Monitor is already running.")

            End If

        End Sub

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Stops monitoring.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <exception cref="Exception">
        ''' Monitor is already stopped.
        ''' </exception>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Overridable Sub [Stop]()

            If (Me.Handle <> IntPtr.Zero) Then
                ProcessStartWatcher.Stop()
                ProcessStopWatcher.Stop()
                MyBase.DestroyHandle()
                Me.isRunningB = False

            Else
                Throw New Exception(message:="Monitor is already stopped.")

            End If

        End Sub

        <DebuggerStepThrough>
        Public Function GetProcessHistory() As List(Of Process)
            Return ProcessHistory
        End Function

#End Region

#Region " IDisposable Implementation "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' To detect redundant calls when disposing.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private isDisposed As Boolean

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Releases all the resources used by this instance.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Sub Dispose() Implements IDisposable.Dispose

            Me.Dispose(isDisposing:=True)
            GC.SuppressFinalize(obj:=Me)

        End Sub

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        ''' Releases unmanaged and - optionally - managed resources.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="isDisposing">
        ''' <see langword="True"/>  to release both managed and unmanaged resources; 
        ''' <see langword="False"/> to release only unmanaged resources.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Protected Overridable Sub Dispose(ByVal isDisposing As Boolean)

            If (Not Me.isDisposed) AndAlso (isDisposing) Then

                Me.events.Dispose()
                Me.Stop()

            End If

            Me.isDisposed = True

        End Sub

#End Region

    End Class

End Namespace
