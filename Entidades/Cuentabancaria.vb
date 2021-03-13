Public Class Cuentabancaria

    Property Id As UInt32
    Property Codigo As String
    Property Nombre As String
    Property Descripcion As String
    Property Activo As Boolean

    Public Overrides Function ToString() As String
        Return Codigo
    End Function

    Public ReadOnly Property NombreyCodigo As String
        Get
            Return Me.Nombre & " [" & Me.Codigo & "]"
        End Get
    End Property

End Class
