Imports System.ComponentModel

Namespace Engine.External.Core

    Public Class DetectionResult

        Private SignatureEX As String = String.Empty
        Public ReadOnly Property Signature As String
            <DebuggerStepThrough>
            Get
                Return Me.SignatureEX
            End Get
        End Property

        Private ResultEX As ScanResult = ScanResult.Timeout
        Public ReadOnly Property Result As ScanResult
            <DebuggerStepThrough>
            Get
                Return Me.ResultEX
            End Get
        End Property

        Private DescriptionEX As String = String.Empty
        Public ReadOnly Property Description As String
            <DebuggerStepThrough>
            Get
                Return Me.DescriptionEX
            End Get
        End Property

        Public Sub New(ByVal ResultT As ScanResult, Optional ByVal SignatureT As String = "????", Optional ByVal DescriptionT As String = "????")
            ResultEX = ResultT
            SignatureEX = SignatureT
            DescriptionEX = DescriptionT
        End Sub

    End Class


    Public Enum ScanResult
        <Description("No threat found")>
        NoThreatFound
        <Description("Threat found")>
        ThreatFound
        <Description("The file could not be found")>
        FileNotFound
        <Description("Timeout")>
        Timeout
        <Description("Error")>
        [Error]
    End Enum

End Namespace
