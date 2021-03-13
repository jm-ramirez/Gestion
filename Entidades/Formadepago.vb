Public Class Formadepago
    Property Id As UInt32
    Property Nombre As String
    Property Descripcion As String
    Property Dias1 As UInt32
    Property Paga1 As Double
    Property Dias2 As UInt32
    Property Paga2 As Double
    Property Dias3 As UInt32
    Property Paga3 As Double
    Property Dias4 As UInt32
    Property Paga4 As Double
    Property Dias5 As UInt32
    Property Paga5 As Double
    Property Dias6 As UInt32
    Property Paga6 As Double
    Property Activo As Boolean

    Public ReadOnly Property NombreyCodigo As String
        Get
            Return Me.Nombre & " [" & Convert.ToString(Me.Id) & "]"
        End Get
    End Property

End Class
