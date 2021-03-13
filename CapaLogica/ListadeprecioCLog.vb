Imports Entidades
Imports System.Text
Imports CapaDatos
Public Class ListadeprecioCLog
Private _ListadeprecioCDat As New ListadeprecioCDat
Public ReadOnly mensajes As New StringBuilder()
Public Sub Save(ByRef obj As Listadeprecio)
    Try
        If (IsValid(obj)) Then
            If (_ListadeprecioCDat.GetById(obj.Id) Is Nothing) Then
                    obj.Id = _ListadeprecioCDat.Insert(obj)
            Else
                _ListadeprecioCDat.Update(obj)
            End If
        End If
    Catch ex As Exception
        mensajes.AppendLine(ex.Message)
    End Try
End Sub
Public Function GetAll() As List(Of Listadeprecio)
    Return _ListadeprecioCDat.GetAll()
End Function
Public Function GetById(ByVal id As UInt32) As Listadeprecio
    mensajes.Clear()
    If (id = 0) Then
        mensajes.AppendLine("Por favor proporcione un valor de Id válido")
    End If
    If (mensajes.Length = 0) Then
        Return _ListadeprecioCDat.GetById(id)
    Else
        Return Nothing
    End If
End Function
Public Sub Delete(ByVal id As UInt32)
    mensajes.Clear()
    If (id = 0) Then
        mensajes.AppendLine("Por favor proporcione un valor de Id válido")
    End If
    If (mensajes.Length = 0) Then
        _ListadeprecioCDat.Delete(id)
    End If
End Sub
Private Function IsValid(ByVal obj As Listadeprecio) As Boolean
    mensajes.Clear()
    'implementar validaciones
    Return (mensajes.Length = 0)
End Function

    Public Function HasError() As Boolean
        Return Not (mensajes.Length = 0)
    End Function
End Class

