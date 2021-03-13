Imports Entidades
Imports System.Text
Imports CapaDatos
Public Class TipocomprobanteCLog

    Private _TipocomprobanteCDat As New TipocomprobanteCDat
    Public ReadOnly mensajes As New StringBuilder()
    Public Sub Save(ByRef obj As Tipocomprobante)
        Try
            If (IsValid(obj)) Then
                If (_TipocomprobanteCDat.GetById(obj.Id) Is Nothing) Then
                    obj.Id = _TipocomprobanteCDat.Insert(obj)
                Else
                    _TipocomprobanteCDat.Update(obj)
                End If
            End If
        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
        End Try
    End Sub

    Public Function GetAll() As List(Of Tipocomprobante)
        Return _TipocomprobanteCDat.GetAll()
    End Function

    Public Function GetCbtesElectronicos() As List(Of Tipocomprobante)
        Return _TipocomprobanteCDat.GetCbtesElectronicos
    End Function

    Public Function GetCbtesNoFiscales() As List(Of Tipocomprobante)
        Return _TipocomprobanteCDat.GetCbtesNoFiscales
    End Function

    Public Function GetCbtesOficiales() As List(Of Tipocomprobante)
        Return _TipocomprobanteCDat.GetCbtesOficiales
    End Function

    Public Function GetCbtesFiscales() As List(Of Tipocomprobante)
        Return _TipocomprobanteCDat.GetCbtesFiscales
    End Function

    Public Function GetCbtesPresupuestos() As List(Of Tipocomprobante)
        Return _TipocomprobanteCDat.GetCbtesPresupuestos
    End Function

    Public Function GetById(ByVal id As UInt32) As Tipocomprobante
        mensajes.Clear()
        If (id = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            Return _TipocomprobanteCDat.GetById(id)
        Else
            Return Nothing
        End If
    End Function

    Public Function GetByCodigo(ByVal codigo As UInt32) As Tipocomprobante
        mensajes.Clear()
        If (codigo = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Código válido")
        End If
        If (mensajes.Length = 0) Then
            Return _TipocomprobanteCDat.GetByCodigo(codigo)
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
            _TipocomprobanteCDat.Delete(id)
        End If
    End Sub
    Private Function IsValid(ByVal obj As Tipocomprobante) As Boolean
        mensajes.Clear()
        'implementar validaciones
        Return (mensajes.Length = 0)
    End Function
    Public Function HasError() As Boolean
        Return Not (mensajes.Length = 0)
    End Function
End Class

