Public Class Personal
    Property Id As UInt32
    Property Nombre As String
    Property Domicilio As String
    Property Telefono As String
    Property Email As String
    Property Login As String
    Property Password As String
    Property Activo As Boolean
    Property Perfil As UInt16
    Property LoginDate As Date
    Property GodMode As Boolean
    Property Sucursal As UInteger
    Property Permisos As New List(Of Entidades.Perfilpermiso)
    'Permisos de usuario
    Property Notadecredito As Boolean
    Property DescuentoGral As Boolean
    Property DescuentoTope As Double

    Public ReadOnly Property NombreyCodigo As String
        Get
            Return Me.Nombre & " [" & Convert.ToString(Me.Id) & "]"
        End Get
    End Property

End Class
