Namespace Core.Helper
    Public Class Paths

        Public Shared ReadOnly DocumentsPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        Public Shared ReadOnly DownloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Downloads\"
        Public Shared ReadOnly PicturesPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        Public Shared ReadOnly MusicPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyMusic)
        Public Shared ReadOnly VideosPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyVideos)

    End Class
End Namespace

