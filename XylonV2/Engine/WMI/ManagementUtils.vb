Namespace Core.Engine.WMI
    Friend Class ManagementUtils

        Friend Shared Function ToDateTime(value As Object) As DateTime?
            If (value Is Nothing) Then
                Return CType(Nothing, DateTime?)
            End If
            Return System.Management.ManagementDateTimeConverter.ToDateTime(CType(value, String))
        End Function

    End Class
End Namespace
