' ***********************************************************************
' Author   : Destroyer
' Modified : 5-February-2017
' ***********************************************************************
' <copyright file="WindowsDetection.vb" company="S4Lsalsoft">
'     Copyright (c) S4lsalsoft. All rights reserved.
' </copyright>
' ***********************************************************************

Namespace Core

    Public Class WindowsDetection

        Public Enum WindowsSystem
            Windows_95 = 0
            Windows_98SE = 1
            Windows_98 = 2
            Windows_ME = 3
            Windows_NT_3_51 = 4
            Windows_NT_4_0 = 5
            Windows_2000 = 6
            Windows_XP = 7
            Windows_Vista = 8
            Windows_7 = 9
            Windows_8 = 10
            Windows_8_1 = 11
            Windows_10 = 12
            Windows_11 = 13
            Undetected = 14
        End Enum


        Public Shared Function GetOSInfo() As WindowsSystem
            Dim os As OperatingSystem = Environment.OSVersion
            Dim vs As Version = os.Version
            Dim operatingSystem As String = String.Empty
            Dim WindowsResult As WindowsSystem = WindowsSystem.Undetected

            If os.Platform = PlatformID.Win32Windows Then

                Select Case vs.Minor
                    Case 0
                        WindowsResult = WindowsSystem.Windows_95
                        operatingSystem = "95"
                    Case 10

                        If vs.Revision.ToString() = "2222A" Then
                            WindowsResult = WindowsSystem.Windows_98SE
                            operatingSystem = "98SE"
                        Else
                            WindowsResult = WindowsSystem.Windows_98
                            operatingSystem = "98"
                        End If

                    Case 90
                        WindowsResult = WindowsSystem.Windows_ME
                        operatingSystem = "Me"
                    Case Else
                End Select
            ElseIf os.Platform = PlatformID.Win32NT Then

                Select Case vs.Major
                    Case 3
                        WindowsResult = WindowsSystem.Windows_NT_3_51
                        operatingSystem = "NT 3.51"
                    Case 4
                        WindowsResult = WindowsSystem.Windows_NT_4_0
                        operatingSystem = "NT 4.0"
                    Case 5

                        If vs.Minor = 0 Then
                            WindowsResult = WindowsSystem.Windows_2000
                            operatingSystem = "2000"
                        Else
                            WindowsResult = WindowsSystem.Windows_XP
                            operatingSystem = "XP"
                        End If

                    Case 6

                        If vs.Minor = 0 Then
                            WindowsResult = WindowsSystem.Windows_Vista
                            operatingSystem = "Vista"
                        ElseIf vs.Minor = 1 Then
                            WindowsResult = WindowsSystem.Windows_7
                            operatingSystem = "7"
                        ElseIf vs.Minor = 2 Then
                            WindowsResult = WindowsSystem.Windows_8
                            operatingSystem = "8"
                        Else
                            WindowsResult = WindowsSystem.Windows_8_1
                            operatingSystem = "8.1"
                        End If

                    Case 10
                        WindowsResult = WindowsSystem.Windows_10
                        operatingSystem = "10"

                    Case 11
                        WindowsResult = WindowsSystem.Windows_11
                        operatingSystem = "11"

                    Case Else
                End Select
            End If

            If operatingSystem <> "" Then
                operatingSystem = "Windows " & operatingSystem

                If os.ServicePack <> "" Then
                    operatingSystem += " " & os.ServicePack
                End If
            End If

            Return WindowsResult
        End Function

    End Class

End Namespace

