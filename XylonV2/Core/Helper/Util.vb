Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace Core.Helper

    Public Class Util

#Region " Architecture check "

        Private is64BitProcess As Boolean = (IntPtr.Size = 8)
        Private is64BitOperatingSystem As Boolean = is64BitProcess OrElse InternalCheckIsWow64()

        <DllImport("Kernel32.dll", SetLastError:=True, CallingConvention:=CallingConvention.Winapi)>
        Public Shared Function IsWow64Process(
    ByVal hProcess As IntPtr,
    ByRef wow64Process As Boolean) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        Public Shared Function InternalCheckIsWow64() As Boolean
            If (Environment.OSVersion.Version.Major = 5 AndAlso Environment.OSVersion.Version.Minor >= 1) OrElse Environment.OSVersion.Version.Major >= 6 Then
                Using p As Process = Process.GetCurrentProcess()
                    Dim retVal As Boolean
                    If Not IsWow64Process(p.Handle, retVal) Then
                        Return False
                    End If
                    Return retVal
                End Using
            Else
                Return False
            End If
        End Function

        Public Shared Sub FNTY(ByVal f As Object)
            Dim fh As Form = TryCast(f, Form)
            fh.Opacity = 0 / 100
            fh.ShowInTaskbar = False
            fh.Show()
            fh.Location = New Point(CInt((Screen.PrimaryScreen.WorkingArea.Width / 1) - (f.Width / 1)), CInt((Screen.PrimaryScreen.WorkingArea.Height / 1) - (f.Height / 1)))
            fh.Opacity = 100 / 100
        End Sub

#End Region

#Region " Sleep "

        ' [ Sleep ]
        '
        '
        ' Examples :
        ' Sleep(5) : MsgBox("Test")
        ' Sleep(5, Measure.Seconds) : MsgBox("Test")

        Public Enum Measure
            Milliseconds = 1
            Seconds = 2
            Minutes = 3
            Hours = 4
        End Enum

        Public Shared Sub Sleep(ByVal Duration As Int64, Optional ByVal Measure As Measure = Measure.Seconds)

            Dim Starttime = DateTime.Now

            Select Case Measure
                Case Measure.Milliseconds : Do While (DateTime.Now - Starttime).TotalMilliseconds < Duration : Application.DoEvents() : Loop
                Case Measure.Seconds : Do While (DateTime.Now - Starttime).TotalSeconds < Duration : Application.DoEvents() : Loop
                Case Measure.Minutes : Do While (DateTime.Now - Starttime).TotalMinutes < Duration : Application.DoEvents() : Loop
                Case Measure.Hours : Do While (DateTime.Now - Starttime).TotalHours < Duration : Application.DoEvents() : Loop
                Case Else
            End Select

        End Sub

#End Region

#Region " File Funcs "

        Public Shared FileManagerEx As String = String.Empty

        Public Shared Function BytesToHex(Input As Byte()) As String
            Dim stringBuilder As System.Text.StringBuilder = New System.Text.StringBuilder(Input.Length * 2)
            For Each number As Byte In Input
                Dim text As String = Conversion.Hex(number)
                If text.Length = 1 Then
                    text = "0" + text
                End If
                stringBuilder.Append(text)
            Next
            Return stringBuilder.ToString()
        End Function

        Public Shared Function File_to_HexEditorFormat(File As String, Optional InvalidChar As Char = "."c) As String
            If IO.File.Exists(File) Then
                Dim array As Byte() = IO.File.ReadAllBytes(File)
                Return String.Join(Nothing, New String() {New String(array.ConvertAll(Of Byte, Char)(array, Function(b As Byte)
                                                                                                                Dim c As Char = Convert.ToChar(b)
                                                                                                                If Char.IsControl(c) Then
                                                                                                                    Return InvalidChar
                                                                                                                End If
                                                                                                                Return c
                                                                                                            End Function))})
            End If
            Throw New Exception("File No Found")
        End Function

        Public Shared Function FileWriteText(ByVal FileDir As String, Optional ByVal ContentText As String = "") As Boolean
            Try
                Dim swEx As New IO.StreamWriter(FileDir, False)
                swEx.Write(ContentText)
                swEx.Close()
                Return True
            Catch ex As Exception
                FileManagerEx = ex.Message
                Return False
            End Try
        End Function

        Public Shared Function FileReadText(ByVal FileDir As String) As String
            Try
                Dim swEx As New IO.StreamReader(FileDir, False)
                Dim ReadAllText As String = swEx.ReadToEnd
                swEx.Close()
                Return ReadAllText
            Catch ex As Exception
                FileManagerEx = ex.Message
                Return String.Empty
            End Try
        End Function

        Public Shared Async Function FileReadTextAsync(ByVal FileDir As String) As Task(Of String)
            Try
                Dim swEx As New IO.StreamReader(FileDir, False)
                Dim ReadAllText As String = Await swEx.ReadToEndAsync()
                swEx.Close()
                Return ReadAllText
            Catch ex As Exception
                FileManagerEx = ex.Message
                Return String.Empty
            End Try
        End Function

        Public Shared Function OpenFile(Optional ByVal Filter As String = "All Files|*.*") As List(Of String)
            Dim OpenFileDialog1 As New OpenFileDialog
            OpenFileDialog1.FileName = ""
            '  OpenFileDialog1.InitialDirectory = "c:\"
            OpenFileDialog1.Title = "Select file"
            OpenFileDialog1.Filter = Filter
            Dim ListFiles As New List(Of String)

            If Not OpenFileDialog1.ShowDialog() = DialogResult.Cancel Then
                ListFiles.AddRange(OpenFileDialog1.FileNames)
                Return ListFiles
            End If

            Return Nothing

        End Function

#End Region

        Public Shared Function IsFolder(ByVal path As String) As Boolean
            Return ((IO.File.GetAttributes(path) And IO.FileAttributes.Directory) = IO.FileAttributes.Directory)
        End Function

        Public Shared Function ToIcon(img As Bitmap, makeTransparent As Boolean, colorToMakeTransparent As Color) As Icon
            If makeTransparent Then
                img.MakeTransparent(colorToMakeTransparent)
            End If
            Dim iconHandle = img.GetHicon()
            Return Icon.FromHandle(iconHandle)
        End Function

        Public Shared Function GetDataPage(ByVal Url As String) As String
            Try
                Dim UrlHost As String = New Uri(Url).Host
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12
                Dim cookieJar As CookieContainer = New CookieContainer()
                Dim request As HttpWebRequest = CType(WebRequest.Create(Url), HttpWebRequest)
                request.UseDefaultCredentials = True
                request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials
                request.CookieContainer = cookieJar
                request.Accept = "text/html, application/xhtml+xml, */*"
                request.Referer = "https://" + UrlHost + "/"
                request.Headers.Add("Accept-Language", "en-GB")
                request.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)"
                request.Host = UrlHost
                Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                Dim htmlString As String = String.Empty

                Using reader = New StreamReader(response.GetResponseStream())
                    htmlString = reader.ReadToEnd()
                End Using

                Return htmlString
            Catch ex As Exception
                Return String.Empty
            End Try
        End Function

    End Class

End Namespace
