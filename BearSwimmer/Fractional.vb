Imports System.Math
Public Module Fractional_
    Public Function Fractional(x As Double) As Integer
        Dim t As Double = Round(x, 13)
        Dim s As String = t.ToString
        Dim p As Integer = s.IndexOf(".")
        s = s.Substring(p + 1)
        Dim l As Integer = s.Length
        Return l
    End Function

End Module
