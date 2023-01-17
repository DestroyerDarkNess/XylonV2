' ***********************************************************************
' Author   : Destroyer
' Modified : 8-June-2021
' Github   : https://github.com/DestroyerDarkNess
' Twitter  : https://twitter.com/Destroy06933000
' ***********************************************************************
' <copyright file="FileWatcherExtended.vb" company="S4Lsalsoft">
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
Imports System.IO
Imports System.Management
Imports System.Windows.Forms

#End Region

Namespace Core.Engine.Watcher

    Public Class FileWatcherExtended : Inherits NativeWindow : Implements IDisposable

#Region " Constructor "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Initializes a new instance of <see cref="DefenderWatcher"/> class.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Sub New(ByVal FileSystemW As FileSystemWatcher)

            If FileSystemW Is Nothing Then
                Throw New Exception("Object reference not set to an instance of an object.")
            Else
                FileSystemWatcher1 = FileSystemW
            End If

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

        Private WithEvents FileSystemWatcher1 As FileSystemWatcher

#Region " Events "


        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' A list of event delegates.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private ReadOnly events As EventHandlerList

        Public Custom Event FileSystemWatcherChanged As EventHandler(Of FileSystemWatcherEventArgs)

            <DebuggerNonUserCode>
            <DebuggerStepThrough>
            AddHandler(ByVal value As EventHandler(Of FileSystemWatcherEventArgs))
                Me.events.AddHandler("FileSystemWatcherEvent", value)
            End AddHandler

            <DebuggerNonUserCode>
            <DebuggerStepThrough>
            RemoveHandler(ByVal value As EventHandler(Of FileSystemWatcherEventArgs))
                Me.events.RemoveHandler("FileSystemWatcherEvent", value)
            End RemoveHandler

            <DebuggerNonUserCode>
            <DebuggerStepThrough>
            RaiseEvent(ByVal sender As Object, ByVal e As FileSystemWatcherEventArgs)
                Dim handler As EventHandler(Of FileSystemWatcherEventArgs) =
                    DirectCast(Me.events("FileSystemWatcherEvent"), EventHandler(Of FileSystemWatcherEventArgs))

                If (handler IsNot Nothing) Then
                    handler.Invoke(sender, e)
                End If
            End RaiseEvent

        End Event

#End Region

        Private Sub FileSystemWatcher1_Changed(ByVal sender As Object, ByVal e As System.IO.FileSystemEventArgs) Handles FileSystemWatcher1.Changed, FileSystemWatcher1.Created, FileSystemWatcher1.Deleted
            Try
                Dim FileCurrentEvent As FileSystemEvent = Nothing

                Select Case e.ChangeType
                    Case WatcherChangeTypes.Changed : FileCurrentEvent = FileSystemEvent.Changed
                    Case WatcherChangeTypes.Created : FileCurrentEvent = FileSystemEvent.Created
                    Case WatcherChangeTypes.Deleted : FileCurrentEvent = FileSystemEvent.Deleted
                End Select

                If Not FileCurrentEvent = Nothing Then

                    Me.OnFileSystemWatcherChanged(New FileSystemWatcherEventArgs(FileCurrentEvent, e.FullPath))

                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub FileSystemWatcher1_Renamed(ByVal sender As Object, ByVal e As System.IO.RenamedEventArgs) Handles FileSystemWatcher1.Renamed
            Try
                Me.OnFileSystemWatcherChanged(New FileSystemWatcherEventArgs(FileSystemEvent.Renamed, e.FullPath, e.OldFullPath))
            Catch ex As Exception

            End Try
        End Sub

        Private Sub FileSystemWatcher1_Error(ByVal sender As Object, ByVal e As System.IO.ErrorEventArgs) Handles FileSystemWatcher1.Error
            If FileSystemWatcher1.EnableRaisingEvents Then
                FileSystemWatcher1.EnableRaisingEvents = False
                FileSystemWatcher1.InternalBufferSize = 2 *
                FileSystemWatcher1.InternalBufferSize
                FileSystemWatcher1.EnableRaisingEvents = True
            End If
        End Sub


#Region " Event Invocators "

        <DebuggerStepThrough>
        Protected Overridable Sub OnFileSystemWatcherChanged(ByVal e As FileSystemWatcherEventArgs)

            RaiseEvent FileSystemWatcherChanged(Me, e)

        End Sub

#End Region

#Region " Events Data "

        Public NotInheritable Class FileSystemWatcherEventArgs : Inherits EventArgs

#Region " Properties "

            Private ReadOnly FileSystemEventB As FileSystemEvent
            Public ReadOnly Property FileSystemEvent As FileSystemEvent
                <DebuggerStepThrough>
                Get
                    Return Me.FileSystemEventB
                End Get
            End Property

            Private ReadOnly FilePropertie As Core.File.InfoFile
            Public ReadOnly Property CurrentInfoFile As Core.File.InfoFile
                <DebuggerStepThrough>
                Get
                    Return Me.FilePropertie
                End Get
            End Property

            Private ReadOnly OldFileStr As String
            Public ReadOnly Property FullName As String
                <DebuggerStepThrough>
                Get
                    Return Me.OldFileStr
                End Get
            End Property

#End Region

#Region " Constructors "

            <DebuggerNonUserCode>
            Private Sub New()
            End Sub

            <DebuggerStepThrough>
            Public Sub New(ByVal FileSystemE As FileSystemEvent, ByVal FilePath As String, Optional ByVal OldFIle As String = "")
                Try
                    Me.FileSystemEventB = FileSystemE
                    If FileSystemE = FileSystemEvent.Deleted Then Me.OldFileStr = FilePath Else Me.FilePropertie = New Core.File.InfoFile(FilePath)
                    If FileSystemE = FileSystemEvent.Renamed Then Me.OldFileStr = OldFIle
                Catch ex As Exception

                End Try
            End Sub

#End Region

        End Class

#End Region

#Region " Enumerations "

        Public Enum FileSystemEvent As Integer

            Changed = 0

            Created = 1

            Deleted = 2

            Renamed = 3

        End Enum

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
                FileSystemWatcher1.EnableRaisingEvents = True
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
                FileSystemWatcher1.EnableRaisingEvents = False
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


