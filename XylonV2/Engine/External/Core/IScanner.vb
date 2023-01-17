Namespace Engine.External.Core

    Friend Interface IScanner

        Function Scan(ByVal file As String, ByVal Optional timeoutInMs As Integer = 30000) As ScanResult

    End Interface

End Namespace
