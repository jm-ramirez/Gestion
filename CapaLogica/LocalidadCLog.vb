Imports Entidades
Imports System.Text
Imports CapaDatos
Public Class LocalidadCLog

    Private _LocalidadCDat As New LocalidadCDat
    Public ReadOnly mensajes As New StringBuilder()
    Public Sub Save(ByRef obj As Localidad)
        Try
            If (IsValid(obj)) Then
                If (_LocalidadCDat.GetById(obj.Id) Is Nothing) Then
                    obj.Id = _LocalidadCDat.Insert(obj)
                Else
                    _LocalidadCDat.Update(obj)
                End If
            End If
        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
        End Try
    End Sub

    Public Function GetAll() As List(Of Localidad)
        Return _LocalidadCDat.GetAll()
    End Function

    'Public Function GetAllByClientes() As List(Of Localidad)
    '    Return _LocalidadCDat.GetAllByClientes()
    'End Function

    Public Function GetByProvincia(ByVal provincia As UInt32) As List(Of Localidad)
        Return _LocalidadCDat.GetByProvincia(provincia)
    End Function

    Public Function GetProvincias() As List(Of Provincias)
        Return _LocalidadCDat.GetProvincias()
    End Function

    Public Function GetById(ByVal id As UInt32) As Localidad
        mensajes.Clear()
        If (id = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            Return _LocalidadCDat.GetById(id)
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
            _LocalidadCDat.Delete(id)
        End If
    End Sub
    Private Function IsValid(ByVal obj As Localidad) As Boolean
        mensajes.Clear()

        If (obj.Codigopostal.Length = 0) Then
            mensajes.AppendLine("Ingrese un Código Postal válido")
        End If

        If (obj.Nombre.Length = 0) Then
            mensajes.AppendLine("Ingrese un Detalle válido")
        End If

        If Not IsNumeric(obj.Pcia) Or obj.Pcia = 0 Then
            mensajes.AppendLine("Ingrese un Código de Provincia válido")
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

