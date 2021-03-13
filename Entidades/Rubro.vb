Public Class Rubro
    Property Id As UInt32
    Property Codigo As String
    Property Nombre As String
    Property Descripcion As String
    Property Maestro As UInt32
    Public ReadOnly Property CodigoyNombre As String
        Get
            Return "[" & Me.Codigo & "] " & Me.Nombre
        End Get
    End Property
    Public ReadOnly Property NombreyCodigo As String
        Get
            Return Me.Nombre & " [" & Trim(Me.Codigo) & "]"
        End Get
    End Property
End Class
