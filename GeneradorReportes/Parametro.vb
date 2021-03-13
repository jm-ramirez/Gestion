Public Class Parametro
    Property Nombre As String
    Property Valor As String

    Public Sub New(ByVal nombre As String, ByVal valor As String)
        Me.Nombre = nombre
        Me.Valor = valor
    End Sub

    Public Sub New()

    End Sub

    Public Overrides Function ToString() As String
        'Return MyBase.ToString()
        Return Nombre & "=" & Valor
    End Function

End Class
