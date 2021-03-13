Public Class OrdenCompradet

    Property Id As UInt32
    Property IdordenCompra As UInt32
    Property Articulo As String
    Property Precio As Double
    Property Cantidad As Double
    Property Cantsaldo As Double
    Property Cantacum As Double
    Property Descarte As Double
    Property Despacho As Double
    Property Kgsxunidad As Double
    Property Kgs As Double
    Property Codunidad As String
    Property Expedicion As Boolean
    Property Cbtevta As UInt32
    Property NombreArticulo As String
    Property Subtotal As Double

    Property codcliente As String
    Property NombreCliente As String
    Property NroPedido As String

    Property Lunes As Double
    Property Martes As Double
    Property Miercoles As Double
    Property Jueves As Double
    Property Viernes As Double
    Property Sabado As Double

    Public ReadOnly Property Pendiente As Double
        Get
            Return (Me.Cantidad - Me.Cantacum)
        End Get
    End Property

End Class
