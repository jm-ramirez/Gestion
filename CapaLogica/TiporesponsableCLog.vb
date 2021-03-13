Imports Entidades
Imports System.Text
Imports CapaDatos
Public Class TiporesponsableCLog
Private _TiporesponsableCDat As New TiporesponsableCDat
Public ReadOnly mensajes As New StringBuilder()
    Public Sub Save(ByRef obj As Tiporesponsable)
        Try
            If (IsValid(obj)) Then
                If (_TiporesponsableCDat.GetById(obj.Id) Is Nothing) Then
                    _TiporesponsableCDat.Insert(obj)
                Else
                    _TiporesponsableCDat.Update(obj)
                End If
            End If
        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
        End Try
    End Sub
    Public Function GetAll() As List(Of Tiporesponsable)
        Return _TiporesponsableCDat.GetAll()
    End Function
    Public Function GetById(ByVal id As UInt32) As Tiporesponsable
        mensajes.Clear()
        If (id = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            Return _TiporesponsableCDat.GetById(id)
        Else
            Return Nothing
        End If
    End Function

    Public Function GetByCodigo(ByVal codigo As UInt32) As Tiporesponsable
        mensajes.Clear()
        If (codigo = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Código válido")
        End If

        If (mensajes.Length = 0) Then
            Return _TiporesponsableCDat.GetByCodigo(codigo)
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
            _TiporesponsableCDat.Delete(id)
        End If
    End Sub
Private Function IsValid(ByVal obj As Tiporesponsable) As Boolean
    mensajes.Clear()
    'implementar validaciones
    Return (mensajes.Length = 0)
End Function
End Class

