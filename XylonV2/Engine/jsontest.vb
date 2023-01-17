Imports System.Web.Script.Serialization

Public Class jsontest

    Public Shared JsonCode As String = <a><![CDATA[
{  
   "key": "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAnF7RGLAxIon0/XeNZ4MLdP3DMkoORzEAKVg0sb89JpA/W2osTHr91Wqwdc9lW0mFcSpCYS9Y3e7cUMFo/M2ETASIuZncMiUzX2/0rrWtGQ3UuEj3KSe5PdaVZfisyJw/FebvHwirEWrhqcgzVUj9fL9YjE0G45d1zMKcc1umKvLqPyTznNuKBZ9GJREdGLRJCBmUgCkI8iwtwC+QZTUppmaD50/ksnEUXv+QkgGN07/KoNA5oAgo49Jf1XBoMv4QXtVZQlBYZl84zAsI82hb63a6Gu29U/4qMWDdI7+3Ne5TRvo6Zi3EI4M2NQNplJhik105qrz+eTLJJxvf4slrWwIDAQAB",
   "manifest_version": 2,
   "name": "__MSG_extName__",
  "popup": {  
    "matches": [ "https://docs.google.com/*", "https://drive.google.com/*" ]
  }  
}
 ]]></a>.Value

#Region " JsonLoader "

    Public Enum StateLoaded
        Indeterminate = 0
        Loaded = 1
        Failed = 2
    End Enum

    <Serializable()>
    Public NotInheritable Class MenuJson

#Region " ExProperties "

        ' // Required
        Public Property Key As String = String.Empty
        Public Property manifest_version As String = String.Empty
        Public Property name As String = String.Empty
        Public Property popup As popupClass = Nothing

#End Region

#Region " Child Classes "

        Public NotInheritable Class popupClass
            Public Property matches As List(Of String)
        End Class

#End Region

    End Class

    Public NotInheritable Class MenuJsonLoader

#Region " Properties "

        Private ManifestData As MenuJson
        Public ReadOnly Property ManifestJson As MenuJson
            <DebuggerStepThrough>
            Get
                Return Me.ManifestData
            End Get
        End Property

        Private LoadStateEx As StateLoaded = StateLoaded.Indeterminate
        Public ReadOnly Property LoadState As StateLoaded
            <DebuggerStepThrough>
            Get
                Return Me.LoadStateEx
            End Get
        End Property

        Private ExeptionInfoEx As String = String.Empty
        Public ReadOnly Property ExeptionInfo As String
            <DebuggerStepThrough>
            Get
                Return Me.ExeptionInfoEx
            End Get
        End Property

#End Region

#Region " Constructors "

        <DebuggerNonUserCode>
        Private Sub New()
        End Sub

        <DebuggerStepThrough>
        Public Sub New(ByVal FileJson As IO.FileInfo)

            Try
                Dim FileData As String = IO.File.ReadAllText(FileJson.FullName)
                ManifestData = New JavaScriptSerializer().Deserialize(Of MenuJson)(FileData)
                LoadStateEx = StateLoaded.Loaded

            Catch ex As Exception
                LoadStateEx = StateLoaded.Failed
                ExeptionInfoEx = ex.Message
            End Try

        End Sub

        <DebuggerStepThrough>
        Public Sub New(ByVal JsonCode As String)

            Try

                ManifestData = New JavaScriptSerializer().Deserialize(Of MenuJson)(JsonCode)
                LoadStateEx = StateLoaded.Loaded

            Catch ex As Exception
                LoadStateEx = StateLoaded.Failed
                ExeptionInfoEx = ex.Message
            End Try

        End Sub

        Public Overrides Function ToString() As String
            Return New JavaScriptSerializer().Serialize(ManifestData).ToString
        End Function

#End Region

    End Class

#End Region

End Class
