' ***********************************************************************
' Author   : Elektro
' Modified : 14-April-2015
' ***********************************************************************
' <copyright file="ServiceUtils.vb" company="Elektro Studios">
'     Copyright (c) Elektro Studios. All rights reserved.
' </copyright>
' ***********************************************************************

#Region " Usage Examples "

'Dim svcName As String = "themes"
'Dim svcDisplayName As String = ServiceUtils.GetDisplayName(svcName)
'Dim svcStatus As ServiceControllerStatus = ServiceUtils.GetStatus(svcName)
'Dim svcStartMode As ServiceUtils.SvcStartMode = ServiceUtils.GetStartMode(svcName)

'ServiceUtils.SetStartMode(svcName, ServiceUtils.SvcStartMode.Automatic)
'ServiceUtils.SetStatus(svcName, ServiceUtils.SvcStatus.Stop, wait:=True, throwOnStatusMissmatch:=True)

#End Region

#Region " Option Statements "

Option Strict On
Option Explicit On
Option Infer Off

#End Region

#Region " Imports "

Imports Microsoft.Win32
Imports System.ServiceProcess

#End Region

''' <summary>
''' Contains related Windows service tools.
''' </summary>
Public NotInheritable Class ServiceUtils

#Region " Enumerations "

    ''' <summary>
    ''' Indicates the status of a service.
    ''' </summary>
    Public Enum SvcStatus

        ''' <summary>
        ''' The service is running.
        ''' </summary>
        Start

        ''' <summary>
        ''' The service is stopped.
        ''' </summary>
        [Stop]

    End Enum

    ''' <summary>
    ''' Indicates the start mode of a service.
    ''' </summary>
    Public Enum SvcStartMode As Integer

        ''' <summary>
        ''' Indicates that the service has not a start mode defined.
        ''' Since a service should have a start mode defined, this means an error occured retrieving the start mode.
        ''' </summary>
        Undefinied = 0

        ''' <summary>
        ''' Indicates that the service is to be started (or was started) by the operating system, at system start-up.
        ''' The service is started after other auto-start services are started plus a short delay.
        ''' </summary>
        AutomaticDelayed = 1

        ''' <summary>
        ''' Indicates that the service is to be started (or was started) by the operating system, at system start-up. 
        ''' If an automatically started service depends on a manually started service, 
        ''' the manually started service is also started automatically at system startup.
        ''' </summary>
        Automatic = 2 'ServiceStartMode.Automatic

        ''' <summary>
        ''' Indicates that the service is started only manually, 
        ''' by a user (using the Service Control Manager) or by an application.
        ''' </summary>
        Manual = 3 'ServiceStartMode.Manual

        ''' <summary>
        ''' Indicates that the service is disabled, so that it cannot be started by a user or application.
        ''' </summary>
        Disabled = 4 ' ServiceStartMode.Disabled

    End Enum

#End Region

#Region " Public Methods "

    ''' <summary>
    ''' Retrieves all the services on the local computer, except for the device driver services.
    ''' </summary>
    ''' <returns>IEnumerable(Of ServiceController).</returns>
    Public Shared Function GetServices() As IEnumerable(Of ServiceController)

        Return ServiceController.GetServices.AsEnumerable

    End Function

    ''' <summary>
    ''' Gets the name of a service.
    ''' </summary>
    ''' <param name="svcDisplayName">The service's display name.</param>
    ''' <returns>The service name.</returns>
    ''' <exception cref="ArgumentException">Any service found with the specified display name.;svcDisplayName</exception>
    Public Shared Function GetName(ByVal svcDisplayName As String) As String

        Dim svc As ServiceController = (From service As ServiceController In ServiceController.GetServices()
                                        Where service.DisplayName.Equals(svcDisplayName, StringComparison.OrdinalIgnoreCase)
                                        ).FirstOrDefault

        If svc Is Nothing Then
            Throw New ArgumentException("Any service found with the specified display name.", "svcDisplayName")

        Else
            Using svc
                Return svc.ServiceName
            End Using

        End If

    End Function

    ''' <summary>
    ''' Gets the display name of a service.
    ''' </summary>
    ''' <param name="svcName">The service name.</param>
    ''' <returns>The service's display name.</returns>
    ''' <exception cref="ArgumentException">Any service found with the specified name.;svcName</exception>
    Public Shared Function GetDisplayName(ByVal svcName As String) As String

        Dim svc As ServiceController = (From service As ServiceController In ServiceController.GetServices()
                                        Where service.ServiceName.Equals(svcName, StringComparison.OrdinalIgnoreCase)
                                        ).FirstOrDefault

        If svc Is Nothing Then
            Throw New ArgumentException("Any service found with the specified name.", "svcName")

        Else
            Using svc
                Return svc.DisplayName
            End Using

        End If

    End Function

    ''' <summary>
    ''' Gets the status of a service.
    ''' </summary>
    ''' <param name="svcName">The service name.</param>
    ''' <returns>The service status.</returns>
    ''' <exception cref="ArgumentException">Any service found with the specified name.;svcName</exception>
    Public Shared Function GetStatus(ByVal svcName As String) As ServiceControllerStatus

        Dim svc As ServiceController =
            (From service As ServiceController In ServiceController.GetServices()
             Where service.ServiceName.Equals(svcName, StringComparison.OrdinalIgnoreCase)
            ).FirstOrDefault

        If svc Is Nothing Then
            Throw New ArgumentException("Any service found with the specified name.", "svcName")

        Else
            Using svc
                Return svc.Status
            End Using

        End If

    End Function

    ''' <summary>
    ''' Gets the start mode of a service.
    ''' </summary>
    ''' <param name="svcName">The service name.</param>
    ''' <returns>The service's start mode.</returns>
    ''' <exception cref="ArgumentException">Any service found with the specified name.</exception>
    ''' <exception cref="Exception">Registry value "Start" not found for service.</exception>
    ''' <exception cref="Exception">Registry value "DelayedAutoStart" not found for service.</exception>
    Public Shared Function GetStartMode(ByVal svcName As String) As SvcStartMode

        Dim reg As RegistryKey = Nothing
        Dim startModeValue As Integer = 0
        Dim delayedAutoStartValue As Integer = 0

        Try
            reg = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\" & svcName, writable:=False)

            If reg Is Nothing Then
                Throw New ArgumentException("Any service found with the specified name.", paramName:="svcName")

            Else
                startModeValue = Convert.ToInt32(reg.GetValue("Start", defaultValue:=-1))
                delayedAutoStartValue = Convert.ToInt32(reg.GetValue("DelayedAutoStart", defaultValue:=0))

                If startModeValue = -1 Then
                    Throw New Exception(String.Format("Registry value ""Start"" not found for service '{0}'.", svcName))
                    Return SvcStartMode.Undefinied

                Else
                    Return DirectCast([Enum].Parse(GetType(SvcStartMode),
                                                   (startModeValue - delayedAutoStartValue).ToString), SvcStartMode)

                End If

            End If

        Catch ex As Exception
            Throw

        Finally
            If reg IsNot Nothing Then
                reg.Dispose()
            End If

        End Try

    End Function

    ''' <summary>
    ''' Gets the start mode of a service.
    ''' </summary>
    ''' <param name="svc">The service.</param>
    ''' <returns>The service's start mode.</returns>
    Public Shared Function GetStartMode(ByVal svc As ServiceController) As SvcStartMode

        Return GetStartMode(svc.ServiceName)

    End Function

    ''' <summary>
    ''' Sets the start mode of a service.
    ''' </summary>
    ''' <param name="svcName">The service name.</param>
    ''' <param name="startMode">The start mode.</param>
    ''' <exception cref="ArgumentException">Any service found with the specified name.</exception>
    ''' <exception cref="ArgumentException">Unexpected value.</exception>
    Public Shared Sub SetStartMode(ByVal svcName As String,
                                   ByVal startMode As SvcStartMode)

        Dim reg As RegistryKey = Nothing

        Try
            reg = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\" & svcName, writable:=True)

            If reg Is Nothing Then
                Throw New ArgumentException("Any service found with the specified name.", paramName:="svcName")

            Else

                Select Case startMode

                    Case SvcStartMode.AutomaticDelayed
                        reg.SetValue("DelayedAutoStart", 1, RegistryValueKind.DWord)
                        reg.SetValue("Start", SvcStartMode.Automatic, RegistryValueKind.DWord)

                    Case SvcStartMode.Automatic, SvcStartMode.Manual, SvcStartMode.Disabled
                        reg.SetValue("DelayedAutoStart", 0, RegistryValueKind.DWord)
                        reg.SetValue("Start", startMode, RegistryValueKind.DWord)

                    Case Else
                        Throw New ArgumentException("Unexpected value.", paramName:="startMode")

                End Select

            End If

        Catch ex As Exception
            Throw

        Finally
            If reg IsNot Nothing Then
                reg.Dispose()
            End If

        End Try

    End Sub

    ''' <summary>
    ''' Sets the start mode of a service.
    ''' </summary>
    ''' <param name="svc">The service.</param>
    ''' <param name="startMode">The start mode.</param>
    Public Shared Sub SetStartMode(ByVal svc As ServiceController,
                                   ByVal startMode As SvcStartMode)

        SetStartMode(svc.ServiceName, startMode)

    End Sub

    ''' <summary>
    ''' Sets the status of a service.
    ''' </summary>
    ''' <param name="svcName">The service name.</param>
    ''' <param name="status">The desired service status.</param>
    ''' <param name="wait">if set to <c>true</c> waits for the status change completition.</param>
    ''' <param name="throwOnStatusMissmatch">
    ''' If set to <c>true</c> throws an error when attempting to start a service that is started, 
    ''' or attempting to stop a service that is stopped.
    ''' </param>
    ''' <exception cref="ArgumentException">Any service found with the specified name.;svcName</exception>
    ''' <exception cref="ArgumentException">Cannot start service because it is disabled.</exception>
    ''' <exception cref="ArgumentException">Cannot start service because a dependant service is disabled.</exception>
    ''' <exception cref="ArgumentException">The service is already running or pendng to run it.</exception>
    ''' <exception cref="ArgumentException">The service is already stopped or pendng to stop it.</exception>
    ''' <exception cref="ArgumentException">Unexpected enumeration value.</exception>
    ''' <exception cref="Exception"></exception>
    Public Shared Sub SetStatus(ByVal svcName As String,
                                ByVal status As SvcStatus,
                                Optional wait As Boolean = False,
                                Optional ByVal throwOnStatusMissmatch As Boolean = False)

        Dim svc As ServiceController = Nothing

        Try
            svc = (From service As ServiceController In ServiceController.GetServices()
                   Where service.ServiceName.Equals(svcName, StringComparison.OrdinalIgnoreCase)
                  ).FirstOrDefault

            If svc Is Nothing Then
                Throw New ArgumentException("Any service found with the specified name.", "svcName")

            ElseIf GetStartMode(svc) = SvcStartMode.Disabled Then
                Throw New Exception(String.Format("Cannot start or stop service '{0}' because it is disabled.", svcName))

            Else

                Select Case status

                    Case SvcStatus.Start

                        Select Case svc.Status

                            Case ServiceControllerStatus.Stopped,
                                 ServiceControllerStatus.StopPending,
                                 ServiceControllerStatus.Paused,
                                 ServiceControllerStatus.PausePending

                                For Each dependantSvc As ServiceController In svc.ServicesDependedOn

                                    If GetStartMode(dependantSvc) = SvcStartMode.Disabled Then
                                        Throw New Exception(String.Format("Cannot start service '{0}' because a dependant service '{1}' is disabled.",
                                                                          svcName, dependantSvc.ServiceName))
                                        Exit Select
                                    End If

                                Next dependantSvc

                                svc.Start()
                                If wait Then
                                    svc.WaitForStatus(ServiceControllerStatus.Running)
                                End If

                            Case ServiceControllerStatus.Running,
                                 ServiceControllerStatus.StartPending,
                                 ServiceControllerStatus.ContinuePending

                                If throwOnStatusMissmatch Then
                                    Throw New Exception(String.Format("The service '{0}' is already running or pendng to run it.", svcName))
                                End If

                        End Select

                    Case SvcStatus.Stop

                        Select Case svc.Status

                            Case ServiceControllerStatus.Running,
                                 ServiceControllerStatus.StartPending,
                                 ServiceControllerStatus.ContinuePending

                                svc.Stop()
                                If wait Then
                                    svc.WaitForStatus(ServiceControllerStatus.Stopped)
                                End If

                            Case ServiceControllerStatus.Stopped,
                                 ServiceControllerStatus.StopPending,
                                 ServiceControllerStatus.Paused,
                                 ServiceControllerStatus.PausePending

                                If throwOnStatusMissmatch Then
                                    Throw New Exception(String.Format("The service '{0}' is already stopped or pendng to stop it.", svcName))
                                End If

                        End Select

                    Case Else
                        Throw New ArgumentException("Unexpected enumeration value.", paramName:="status")

                End Select

            End If

        Catch ex As Exception
            Throw

        Finally
            If svc IsNot Nothing Then
                svc.Close()
            End If

        End Try

    End Sub

#End Region

End Class