Public Class Categoria
    Property Id As UInt32
    Property Codigo As String
    Property Nombre As String
    Property Descripcion As String

    Public ReadOnly Property NombreyCodigo As String
        Get
            Return Me.Nombre & " [" & Trim(Me.Codigo) & "]"
        End Get
    End Property

End Class
