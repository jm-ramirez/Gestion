Public Class Conceptobancario
    Property Id As UInt32
    Property Codigo As String
    Property Nombre As String
    Property Descripcion As String
    Property Tipo As String
    Property Activo As Boolean
    Property Alicuota As Double
    Property Plazo As UInt16
    Property Tt As Double

    Public ReadOnly Property NombreyCodigo As String
        Get
            Return Me.Nombre & " [" & Me.Codigo & "]"
        End Get
    End Property

    Public ReadOnly Property TipoyNombre As String
        Get
            If Me.Tipo = "D" Then
                Return "[ING.] " & Me.Nombre
            Else
                Return "[EGR.] " & Me.Nombre
            End If
        End Get
    End Property

End Class
