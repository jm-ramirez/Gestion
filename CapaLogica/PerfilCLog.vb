Imports Entidades
Imports System.Text
Imports CapaDatos
Public Class PerfilCLog
    Private _PerfilCDat As New PerfilCDat
    Public ReadOnly mensajes As New StringBuilder()
    Public Sub Save(ByRef obj As Perfil)
        Try
            If (IsValid(obj)) Then
                If (_PerfilCDat.GetById(obj.Id) Is Nothing) Then
                    obj.Id = _PerfilCDat.Insert(obj)
                Else
                    _PerfilCDat.Update(obj)
                End If
            End If
        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
        End Try
    End Sub
    Public Function GetAll() As List(Of Perfil)
        Return _PerfilCDat.GetAll()
    End Function
    Public Function GetById(ByVal id As UInt32) As Perfil
        mensajes.Clear()
        If (id = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            Return _PerfilCDat.GetById(id)
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
            _PerfilCDat.Delete(id)
        End If
    End Sub
    Private Function IsValid(ByVal obj As Perfil) As Boolean
        mensajes.Clear()

        If (obj.Nombre.Length = 0) Then
            mensajes.AppendLine("Ingrese un Detalle válido")
        End If

        If Not (mensajes.Length = 0) Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function HasError() As Boolean
        Return Not (mensajes.Length = 0)
    End Function
End Class

