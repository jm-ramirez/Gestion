Public Class Transporte
    Property Id As UInt32
    Property Nombre As String
    Property Domicilio As String
    Property Telefono As String
    Property Email As String
    Property Tipodocumento As UInt32
    Property Documento As String
    Property Tiporesponsable As UInt32
    Property Observacion As String
    Property Localidad As UInt32
    Property Provincia As UInt32
    Property Zona As UInt32

    Public ReadOnly Property NombreyCodigo As String
        Get
            Return Me.Nombre & " [" & Convert.ToString(Me.Id) & "]"
        End Get
    End Property

End Class
