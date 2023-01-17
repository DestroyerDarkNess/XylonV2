Imports System.Drawing
Imports XylonV2.Core.Engine.WebBrowser.Chrome
Imports System.Text.RegularExpressions

Public Class ChromeTester

    Dim ChromeExtensionManager As New Core.Engine.WebBrowser.Chrome

    Private Sub ChromeTester_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TestExtension()
        Exit Sub
        Dim GetDataTest As Core.Engine.WebBrowser.Chrome.ChromeExtension = ChromeExtensionManager.Extensions(12)

        If GetDataTest.LoadState = Core.Engine.WebBrowser.Chrome.StateLoaded.Loaded Then
            'TextBox1.Text = GetDataTest.ManifestJson.ToString
            Me.Text = IO.Path.GetFileName(GetDataTest.FullPath)
            Me.Icon = Core.Helper.Util.ToIcon(GetDataTest.IconToList.LastOrDefault, True, Color.Transparent)
            ' TextBox1.Text += GetDataTest.ManifestJson.ToString

        End If

        For Each Gextensions As ChromeExtension In ChromeExtensionManager.Extensions
            If Gextensions.LoadState = Core.Engine.WebBrowser.Chrome.StateLoaded.Loaded Then

                Dim GScanner As ChromeScanner = New ChromeScanner
                Dim ResultGScan As Boolean = GScanner.IsSuspiciusExtension(Gextensions)

                TextBox1.Text += Gextensions.ManifestJson.FilePathJson

                If ResultGScan = True Then
                    TextBox2.Text += " Suspicius Extension : " & Gextensions.MainFolder & vbNewLine & "Result: " & GScanner.SuspiciusInfo & vbNewLine & vbNewLine
                End If

            End If

        Next

        ' Me.Icon = Core.Helper.Util.ToIcon(GetDataTest.ManifestJson.browser_action.default_iconImage, True, Color.Transparent)
    End Sub


    Private Sub TestExtension()
        Dim GetExtensions As List(Of Core.Engine.WebBrowser.Chrome.ChromeExtension) = ChromeExtensionManager.Extensions()

        For Each ChromeExtension As Core.Engine.WebBrowser.Chrome.ChromeExtension In GetExtensions

            If ChromeExtension.LoadState = Core.Engine.WebBrowser.Chrome.StateLoaded.Loaded Then
                ' Dim ManifestData As String = ChromeExtension.ManifestJson.ToString
                ' Extension Properties Data :
                ' Dim ManifestPermissions As List(Of String) = ChromeExtension.ManifestJson.permissions
                Dim ExtensionPath As String = ChromeExtension.FullPath
                Dim ExtensionIcon As Image = Core.Helper.Util.ToIcon(ChromeExtension.IconToList.LastOrDefault, True, Color.Transparent).ToBitmap
                Dim ExtensionName As String = ChromeExtension.ManifestJson.name
                TextBox1.Text += "Name: " & ExtensionName & vbNewLine & "Description: " & ChromeExtension.ManifestJson.description & vbNewLine & "Path: " & ExtensionPath & vbNewLine & vbNewLine
                ' IO.Directory.Delete(ExtensionPath, true)
                AVExtensionScanner(ChromeExtension)

            End If

        Next

    End Sub

    Private Sub AVExtensionScanner(ByVal Extension As Core.Engine.WebBrowser.Chrome.ChromeExtension)
        Dim GScanner As ChromeScanner = New ChromeScanner
        Dim ResultGScan As Boolean = GScanner.IsSuspiciusExtension(Extension)
        If ResultGScan = True Then
            TextBox2.Text += " Suspicius Extension : " & Extension.MainFolder & vbNewLine & "Result: " & GScanner.SuspiciusInfo & vbNewLine & vbNewLine
        End If
    End Sub


End Class