Public Class Banco
    Property Id As UInt32
    Property Codigo As UInt32
    Property Nombre As String

    Public ReadOnly Property NombreyCodigo As String
        Get
            Return Me.Nombre & " [" & Convert.ToString(Me.Codigo) & "]"
        End Get
    End Property
End Class
