Public Class Cbtepuntoventa

    Property Id As UInt32
    Property Ptovta As UInt32
    Property Tipo As Char
    Property Idserviciows As String
    Property Urlws As String
    Property Activo As Boolean

    'propiedades relacionadas con otras tablas de detalle
    Property PtoNumeracion As New List(Of Entidades.Cbtenumeracion)

End Class
