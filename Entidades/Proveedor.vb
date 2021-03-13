Public Class Proveedor
    Property Id As UInt32
    Property Codigo As String
    Property Nombre As String
    Property Domicilio As String
    Property Telefono As String
    Property Email As String
    Property Tipodocumento As UInt32
    Property Documento As String
    Property Activo As Boolean
    Property Tiporesponsable As UInt32
    Property Observacion As String
    Property Localidad As UInt32
    Property Provincia As UInt32
    Property Fechaultimacompra As Date
    Property Diasctacte As UInt32
    Property Ingresosbrutosnro As String
    Property Ingresosbrutosalic As Double
    Property Conveniomultilateral As Boolean
    Property Ganancias As Char
    Property Rubrogcia As UInteger
    Property Retivaalic As Double

    Public ReadOnly Property CodigoyNombre As String
        Get
            Return "[" & Me.Codigo & "] " & Me.Nombre
        End Get
    End Property

    Public ReadOnly Property NombreyCodigo As String
        Get
            Return Me.Nombre & " [" & Me.Codigo & "]"
        End Get
    End Property

End Class
