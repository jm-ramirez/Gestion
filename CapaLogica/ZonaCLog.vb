Imports Entidades
Imports System.Text
Imports CapaDatos
Public Class ZonaCLog

    Private _ZonaCDat As New ZonaCDat
    Public ReadOnly mensajes As New StringBuilder()
    Public Sub Save(ByRef obj As Zona)
        Try
            If (IsValid(obj)) Then
                If (_ZonaCDat.GetById(obj.Id) Is Nothing) Then
                    obj.Id = _ZonaCDat.Insert(obj)
                Else
                    _ZonaCDat.Update(obj)
                End If
            End If
        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
        End Try
    End Sub
    Public Function GetAll() As List(Of Zona)
        Return _ZonaCDat.GetAll()
    End Function
    Public Function GetById(ByVal id As UInt32) As Zona
        mensajes.Clear()
        If (id = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            Return _ZonaCDat.GetById(id)
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
            _ZonaCDat.Delete(id)
        End If
    End Sub
    Private Function IsValid(ByVal obj As Zona) As Boolean
        mensajes.Clear()
        'implementar validaciones
        Return (mensajes.Length = 0)
    End Function

    Public Function HasError() As Boolean
        Return Not (mensajes.Length = 0)
    End Function
End Class

