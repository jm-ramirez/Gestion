Imports Entidades
Imports System.Text
Imports CapaDatos
Public Class TransporteCLog

    Private _TransporteCDat As New TransporteCDat
    Public ReadOnly mensajes As New StringBuilder()
    Public Sub Save(ByRef obj As Transporte)
        Try
            If (IsValid(obj)) Then
                If (_TransporteCDat.GetById(obj.Id) Is Nothing) Then
                    obj.Id = _TransporteCDat.Insert(obj)
                Else
                    _TransporteCDat.Update(obj)
                End If
            End If
        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
        End Try
    End Sub

    Public Function GetAll() As List(Of Transporte)
        Return _TransporteCDat.GetAll()
    End Function

    Public Function GetById(ByVal id As UInt32) As Transporte
        mensajes.Clear()
        If (id = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            Return _TransporteCDat.GetById(id)
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
            _TransporteCDat.Delete(id)
        End If

    End Sub
    Private Function IsValid(ByVal obj As Transporte) As Boolean
        mensajes.Clear()

        If (obj.Nombre.Length = 0) Then
            mensajes.AppendLine("El campo Nombre es de ingreso obligatorio")
        End If

        If (obj.Domicilio.Length = 0) Then
            mensajes.AppendLine("El campo Domicilio es de ingreso obligatorio")
        End If

        If (obj.Telefono.Length = 0) Then
            mensajes.AppendLine("El campo Telefono es de ingreso obligatorio")
        End If

        If (obj.Provincia = 0) Then
            mensajes.AppendLine("El campo Provincia es de ingreso obligatorio")
        End If

        If (obj.Localidad = 0) Then
            mensajes.AppendLine("El campo Localidad es de ingreso obligatorio")
        End If

        If (obj.Tiporesponsable = 0) Then
            mensajes.AppendLine("El campo Tipo de Responsable es de ingreso obligatorio")
        End If

        If (obj.Tipodocumento = 0) Then
            mensajes.AppendLine("El campo Tipo de Documento es de ingreso obligatorio")
        End If

        If (obj.Zona = 0) Then
            mensajes.AppendLine("El campo Zona es de ingreso obligatorio")
        End If
    
        Return (mensajes.Length = 0)
    End Function

    Public Function HasError() As Boolean
        Return Not (mensajes.Length = 0)
    End Function
End Class

