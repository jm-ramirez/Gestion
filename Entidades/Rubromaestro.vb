Public Class Rubromaestro
    Property Id As UInt32
    Property Nombre As String
    Property Descripcion As String

    Public ReadOnly Property NombreyCodigo As String
        Get
            Return Me.Nombre & " [" & Convert.ToString(Me.Id) & "]"
        End Get
    End Property

End Class
