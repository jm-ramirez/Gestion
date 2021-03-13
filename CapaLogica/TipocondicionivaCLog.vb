Imports Entidades
Imports System.Text
Imports CapaDatos

Public Class TipocondicionivaCLog

    Private _TipocondicionivaCDat As New TipocondicionivaCDat
    Public ReadOnly mensajes As New StringBuilder()
    Public Sub Save(ByRef obj As Tipocondicioniva)
        Try
            If (IsValid(obj)) Then
                If (_TipocondicionivaCDat.GetById(obj.Id) Is Nothing) Then
                    _TipocondicionivaCDat.Insert(obj)
                Else
                    _TipocondicionivaCDat.Update(obj)
                End If
            End If
        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
        End Try
    End Sub
    Public Function GetAll() As List(Of Tipocondicioniva)
        Return _TipocondicionivaCDat.GetAll()
    End Function
    Public Function GetById(ByVal id As UInt32) As Tipocondicioniva
        mensajes.Clear()
        If (id = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            Return _TipocondicionivaCDat.GetById(id)
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
            _TipocondicionivaCDat.Delete(id)
        End If
    End Sub
    Private Function IsValid(ByVal obj As Tipocondicioniva) As Boolean
        mensajes.Clear()
        'implementar validaciones
        Return (mensajes.Length = 0)
    End Function
End Class

