Public Class Parametros
    Inherits List(Of Parametro)

    Public Overrides Function ToString() As String
        Dim ret As String = ""

        For Each p As Parametro In Me
            ret &= p.ToString & "&"
        Next

        If ret.Length > 0 Then
            ret = ret.Substring(0, ret.Length - 1)
        End If

        Return ret
    End Function

End Class
