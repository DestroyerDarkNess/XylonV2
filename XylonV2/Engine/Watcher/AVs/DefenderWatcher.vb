' ***********************************************************************
' Author   : Destroyer
' Modified : 8-June-2021
' Github   : https://github.com/DestroyerDarkNess
' Twitter  : https://twitter.com/Destroy06933000
' ***********************************************************************
' <copyright file="DefenderWatcher.vb" company="S4Lsalsoft">
'     Copyright (c) S4Lsalsoft. All rights reserved.
' </copyright>
' ***********************************************************************

#Region " Usage Examples "

' ''' <summary>
' ''' The DefenderWatcher instance to monitor Windows Defender Realtime Status Changed.
' ''' </summary>
'Friend WithEvents DefenderMon As New DefenderWatcher

' ''' ----------------------------------------------------------------------------------------------------
' ''' <summary>
' ''' Handles the <see cref="DefenderWatcher.DefenderStatusChanged"/> event of the <see cref="DefenderMon"/> instance.
' ''' </summary>
' ''' ----------------------------------------------------------------------------------------------------
' ''' <param name="sender">
' ''' The source of the event.
' ''' </param>
' ''' 
' ''' <param name="e">
' ''' The <see cref="DefenderWatcher.DefenderStatusChangedEventArgs"/> instance containing the event data.
' ''' </param>
' ''' ----------------------------------------------------------------------------------------------------
'Private Sub DefenderMon_DefenderStatusChanged(ByVal sender As Object, ByVal e As DefenderWatcher.DefenderStatusChangedEventArgs) Handles DefenderMon.DefenderStatusChanged
'    Dim sb As New System.Text.StringBuilder
'    sb.AppendLine(" Defender Configuration change -  Windows Defender RealtimeMonitoring")
'    sb.AppendLine(String.Format("DisableRealtimeMonitoring......: {0}", e.TargetInstance.ToString))
'    sb.AppendLine(String.Format("Old Value......................: {0}", e.PreviousInstance.ToString))
'    Me.BeginInvoke(Sub()
'                       TextBox1.Text += (sb.ToString) & Environment.NewLine & Environment.NewLine
'                   End Sub)
'End Sub

#End Region

#Region " Imports "

Imports System.ComponentModel
Imports System.Management
Imports System.Windows.Forms

#End Region

Namespace Core.Engine.Watcher

    Public Class DefenderWatcher : Inherits NativeWindow : Implements IDisposable

#Region " Constructor "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Initializes a new instance of <see cref="DefenderWatcher"/> class.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Sub New(Optional ByVal GuardWDefender As Boolean = False)

            Me.GuardDefender = GuardWDefender
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

        Private Scope As New ManagementScope("root\Microsoft\Windows\Defender")
        Private WithEvents DefenderState As ManagementEventWatcher = New ManagementEventWatcher(Scope, New WqlEventQuery("SELECT * FROM __InstanceModificationEvent WITHIN 5 WHERE TargetInstance ISA 'MSFT_MpPreference' AND TargetInstance.DisableRealtimeMonitoring=True"))
        Private GuardDefender As Boolean = False

#Region " Events "


        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' A list of event delegates.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private ReadOnly events As EventHandlerList

        Public Custom Event DefenderStatusChanged As EventHandler(Of DefenderStatusChangedEventArgs)

            <DebuggerNonUserCode>
            <DebuggerStepThrough>
            AddHandler(ByVal value As EventHandler(Of DefenderStatusChangedEventArgs))
                Me.events.AddHandler("DefenderStatusChangedEvent", value)
            End AddHandler

            <DebuggerNonUserCode>
            <DebuggerStepThrough>
            RemoveHandler(ByVal value As EventHandler(Of DefenderStatusChangedEventArgs))
                Me.events.RemoveHandler("DefenderStatusChangedEvent", value)
            End RemoveHandler

            <DebuggerNonUserCode>
            <DebuggerStepThrough>
            RaiseEvent(ByVal sender As Object, ByVal e As DefenderStatusChangedEventArgs)
                Dim handler As EventHandler(Of DefenderStatusChangedEventArgs) =
                    DirectCast(Me.events("DefenderStatusChangedEvent"), EventHandler(Of DefenderStatusChangedEventArgs))

                If (handler IsNot Nothing) Then
                    handler.Invoke(sender, e)
                End If
            End RaiseEvent

        End Event

#End Region

        '   Dim oInterfaceType As String = TIBase?.Properties("DisableRealtimeMonitoring")?.Value.ToString() ' Prevent Defender Disable

        Public Sub DefenderState_EventArrived(ByVal sender As Object, ByVal e As EventArrivedEventArgs) Handles DefenderState.EventArrived
            Dim DefenderTargetInstance As Boolean = Nothing
            Dim DefenderPreviousInstance As Boolean = Nothing

            Using TIBase = CType(e.NewEvent.Properties("TargetInstance").Value, ManagementBaseObject)
                DefenderTargetInstance = CBool(TIBase.Properties("DisableRealtimeMonitoring").Value)
                If GuardDefender = True Then TIBase.Properties("DisableRealtimeMonitoring").Value = True
            End Using

            Using PIBase = CType(e.NewEvent.Properties("PreviousInstance").Value, ManagementBaseObject)
                DefenderPreviousInstance = CBool(PIBase.Properties("DisableRealtimeMonitoring").Value)
            End Using

            Me.OnDefenderStatusChanged(New DefenderStatusChangedEventArgs(DefenderTargetInstance, DefenderPreviousInstance))

        End Sub

#Region " Event Invocators "

        <DebuggerStepThrough>
        Protected Overridable Sub OnDefenderStatusChanged(ByVal e As DefenderStatusChangedEventArgs)

            RaiseEvent DefenderStatusChanged(Me, e)

        End Sub

#End Region

#Region " Events Data "

        Public NotInheritable Class DefenderStatusChangedEventArgs : Inherits EventArgs

#Region " Properties "

            Private ReadOnly TargetInstanceB As Boolean
            Public ReadOnly Property TargetInstance As Boolean
                <DebuggerStepThrough>
                Get
                    Return Me.TargetInstanceB
                End Get
            End Property

            Private ReadOnly PreviousInstanceB As Boolean
            Public ReadOnly Property PreviousInstance As Boolean
                <DebuggerStepThrough>
                Get
                    Return Me.PreviousInstanceB
                End Get
            End Property

#End Region

#Region " Constructors "

            <DebuggerNonUserCode>
            Private Sub New()
            End Sub

            <DebuggerStepThrough>
            Public Sub New(ByVal TI As Boolean, ByVal PI As Boolean)

                Me.TargetInstanceB = TI
                Me.PreviousInstanceB = PI

            End Sub

#End Region

        End Class

#End Region

#Region " Public Methods "

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
                DefenderState.Start()
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
                DefenderState.Stop()
                MyBase.DestroyHandle()
                Me.isRunningB = False

            Else
                Throw New Exception(message:="Monitor is already stopped.")

            End If

        End Sub

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

