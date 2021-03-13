Public Class Localidad
    Property Id As UInt32
    Property Nombre As String
    Property Codigopostal As String
    Property Pcia As UInt32
    Property Provincia As String

    Property EntPcia As Entidades.Provincias

    Public ReadOnly Property NombreyCodigo As String
        Get
            Return Me.Nombre & " [" & Convert.ToString(Me.Id) & "]"
        End Get
    End Property

End Class
