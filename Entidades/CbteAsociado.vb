Public Class CbteAsociado
    Property Id As UInt32
    Property CbteReferencia As UInt32
    Property Numero As Long
    Property PtoVta As Integer
    Property Tipo As Integer
    Property Importe As Double
    Property Fecha As String
    Property Denominacion As String
    Property ImporteOriginal As Double
    Property Saldo As Double

    Public ReadOnly Property DetalleCbte
        Get
            Return Denominacion & " " & PtoVta.ToString.PadLeft(4, "0") & "-" & Numero.ToString.PadLeft(8, "0")
        End Get
    End Property

End Class
