Public Class Cliente
    Property Id As UInt32
    Property Codigo As String
    Property Nombre As String
    Property Domicilio As String
    Property Telefono As String
    Property Email As String
    Property Email2 As String
    Property Email3 As String
    Property Tipodocumento As UInt32
    Property Documento As String
    Property Contacto As String
    Property Activo As Boolean
    Property Tiporesponsable As UInt32
    Property Observacion As String
    Property Localidad As UInt32
    Property NombreLocalidad As String
    Property CodigoPostal As String
    Property Provincia As UInt32
    Property FormadePago As UInt32
    Property Zona As UInt32
    Property Vendedor As UInt32
    Property Fechaultimacompra As Date
    Property Listadeprecio As UInt32
    Property Diasctacte As UInt32
    Property Ingresosbrutosnro As String
    Property Limitecredito As Double
    Property Descuento As Double
    Property Interesmora As Double
    Property Codigoingresosbrutos As Char
    Property Ingresosbrutosalic As Double

    Property DescripcionIva As String

    Public ReadOnly Property NombreyCodigo As String
        Get
            Return Me.Nombre & " [" & Me.Codigo & "]"
        End Get
    End Property
End Class
