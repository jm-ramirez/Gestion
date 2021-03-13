Public Class OrdenCompracab

    Property Id As UInt32
    Property Codcliente As String
    Property Numero As UInt32
    Property Fecha As Date
    Property Observacion As String
    Property NombreCliente As String
    Property DomicilioCliente As String
    Property CodpostalCliente As String
    Property LocalidadCliente As String
    Property TelefonoCliente As String
    Property CuitCliente As String

    Property Cantidad As Double

    Property OrdenCompradet As New List(Of Entidades.OrdenCompradet)

    'Public ReadOnly Property NumeroySecuencia As String
    '    Get
    '        Return Me.Numero & " - " & Me.Secuencia
    '    End Get
    'End Property


End Class
