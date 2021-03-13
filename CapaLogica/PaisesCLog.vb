Imports Entidades
Imports System.Text
Imports CapaDatos
Public Class PaisesCLog
    Private _PaisesCDat As New PaisesCDat
    Public ReadOnly mensajes As New StringBuilder()
    Public Sub Save(ByVal obj As Paises)
        Try
            If (IsValid(obj)) Then
                If (_PaisesCDat.GetById(obj.Id) Is Nothing) Then
                    _PaisesCDat.Insert(obj)
                Else
                    _PaisesCDat.Update(obj)
                End If
            End If
        Catch ex As Exception
            mensajes.Append(ex.Message)
        End Try
    End Sub
    Public Function GetAll() As List(Of Paises)
        Return _PaisesCDat.GetAll()
    End Function
    Public Function GetById(ByVal id As UInt32) As Paises
        mensajes.Clear()
        If (id = 0) Then
            mensajes.Append("Ingrese un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            Return _PaisesCDat.GetById(id)
        Else
            Return Nothing
        End If
    End Function
    Public Sub Delete(ByVal id As UInt32)
        mensajes.Clear()
        If (id = 0) Then
            mensajes.Append("Ingrese un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            _PaisesCDat.Delete(id)
        End If
    End Sub
    Private Function IsValid(ByVal obj As Paises) As Boolean
        mensajes.Clear()
        'implementar validaciones
        Return (mensajes.Length = 0)
    End Function
    Public Function HasError() As Boolean
        Return Not (mensajes.Length = 0)
    End Function
End Class

