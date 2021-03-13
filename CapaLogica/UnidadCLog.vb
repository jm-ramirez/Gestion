Imports Entidades
Imports System.Text
Imports CapaDatos
Public Class UnidadCLog
    Private _UnidadCDat As New UnidadCDat
    Public ReadOnly mensajes As New StringBuilder()
    Public Sub Save(ByRef obj As Unidad)
        Try
            If (IsValid(obj)) Then
                If (_UnidadCDat.GetById(obj.Id) Is Nothing) Then
                    _UnidadCDat.Insert(obj)
                Else
                    _UnidadCDat.Update(obj)
                End If
            End If
        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
        End Try
    End Sub
    Public Function GetAll() As List(Of Unidad)
        Return _UnidadCDat.GetAll()
    End Function
    Public Function GetById(ByVal id As UInt32) As Unidad
        mensajes.Clear()
        If (id = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            Return _UnidadCDat.GetById(id)
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
            _UnidadCDat.Delete(id)
        End If
    End Sub
    Private Function IsValid(ByVal obj As Unidad) As Boolean
        mensajes.Clear()

        If (obj.Codigo.Length = 0) Then
            mensajes.AppendLine("Ingrese un Código válido")
        End If

        If (obj.Nombre.Length = 0) Then
            mensajes.AppendLine("Ingrese un Detalle válido")
        End If

        If Not (mensajes.Length = 0) Then
            Return False
        Else
            Return True
        End If
    End Function
End Class

