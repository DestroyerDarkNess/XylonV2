Imports System.Runtime.CompilerServices

Module StringExtensions
    <Extension()>
    Function Contains(ByVal source As String, ByVal toCheck As String, ByVal comp As StringComparison) As Boolean
        Return source?.IndexOf(toCheck, comp) >= 0
    End Function
End Module