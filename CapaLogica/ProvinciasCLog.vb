Imports Entidades
Imports System.Text
Imports CapaDatos
Public Class ProvinciasCLog
    Private _ProvinciasCDat As New ProvinciasCDat
    Public ReadOnly mensajes As New StringBuilder()
    Public Sub Save(ByVal obj As Provincias)
        Try
            If (IsValid(obj)) Then
                If (_ProvinciasCDat.GetById(obj.Id) Is Nothing) Then
                    _ProvinciasCDat.Insert(obj)
                Else
                    _ProvinciasCDat.Update(obj)
                End If
            End If
        Catch ex As Exception
            mensajes.Append(ex.Message)
        End Try
    End Sub
    Public Function GetAll() As List(Of Provincias)
        Return _ProvinciasCDat.GetAll()
    End Function
    Public Function GetById(ByVal id As UInt32) As Provincias
        mensajes.Clear()
        If (id = 0) Then
            mensajes.Append("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            Return _ProvinciasCDat.GetById(id)
        Else
            Return Nothing
        End If
    End Function
    Public Sub Delete(ByVal id As UInt32)
        mensajes.Clear()

        If (id = 0) Then
            mensajes.Append("Por favor proporcione un valor de Id válido")
        End If

        If (mensajes.Length = 0) Then
            _ProvinciasCDat.Delete(id)
        End If
    End Sub
    Private Function IsValid(ByVal obj As Provincias) As Boolean
        mensajes.Clear()

        If (obj.Codigo.Length = 0) Then
            mensajes.AppendLine("Ingrese un Código válido")
        End If

        If (obj.Nombre.Length = 0) Then
            mensajes.AppendLine("Ingrese un Detalle válido")
        End If

        If Not IsNumeric(obj.Pais) Then
            mensajes.AppendLine("Ingrese un Código de País válido")
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

