Public Class Provincias
    Property Id As UInt32
    Property Codigo As String
    Property Nombre As String
    Property Pais As UInt32

    Public ReadOnly Property NombreyCodigo As String
        Get
            Return Me.Nombre & " [" & Convert.ToString(Me.Codigo) & "]"
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return NombreyCodigo
    End Function

End Class
