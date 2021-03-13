Public Class Rubrogcia
    Property Id As UInt32
    Property Nombre As String
    Property Descripcion As String
    Property Nosujeto As Double
    Property Minimo As Double
    Property Noinscripto As Double
    Property Tope1 As Double
    Property Tope2 As Double
    Property Tope3 As Double
    Property Tope4 As Double
    Property Tope5 As Double
    Property Tope6 As Double
    Property Tope7 As Double
    Property Tope1alic As Double
    Property Tope2alic As Double
    Property Tope3alic As Double
    Property Tope4alic As Double
    Property Tope5alic As Double
    Property Tope6alic As Double
    Property Tope7alic As Double
    Property Activo As Boolean

    Public ReadOnly Property NombreyCodigo As String
        Get
            Return Me.Nombre & " [" & Convert.ToString(Me.Id) & "]"
        End Get
    End Property

End Class
