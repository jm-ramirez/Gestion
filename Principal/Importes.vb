Public Class Importes
    Property Tipo As TiposImportes
    Property Codigo As String
    Property Detalle As String
    Property Importe As Double
    Property Alicuota As Double
    Property Referencia As String
    Property Baseimponible As Double

    Public Function CalcularBaseImponible() As Double

        Dim ret As Double = 0.0

        If Alicuota <> 0 Then
            ret = Math.Round((Importe * 100) / Alicuota, 2)
        End If

        Return ret

    End Function

End Class
