Imports Entidades
Imports System.Text
Imports CapaDatos
Public Class OrdencompradetCLog
    Private _OrdencompradetCDat As New OrdencompradetCDat
    Public ReadOnly mensajes As New StringBuilder()
    Public Sub Save(ByVal obj As List(Of OrdenCompradet))
        Try
            _ordencompradetCDat.UpdateordencompraDescarte(obj)
        Catch ex As Exception
            mensajes.Append(ex.Message)
        End Try
    End Sub
    Public Function GetAll() As List(Of OrdenCompradet)
        Return _OrdencompradetCDat.GetAll()
    End Function

    Public Function GetOrdencompraDescarte(ByVal Todos As Boolean, ByVal ClienteDesde As String, ByVal ClienteHasta As String) As List(Of OrdenCompradet)
        Return _OrdencompradetCDat.GetOrdencompraDescarte(Todos, ClienteDesde, ClienteHasta)
    End Function

    Public Function GetById(ByVal id As UInt32) As OrdenCompradet
        mensajes.Clear()
        If (id = 0) Then
            mensajes.Append("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            Return _OrdencompradetCDat.GetById(id)
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
            _OrdencompradetCDat.Delete(id)
        End If
    End Sub
    Private Function IsValid(ByVal obj As OrdenCompradet) As Boolean
        mensajes.Clear()
        'implementar validaciones
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

