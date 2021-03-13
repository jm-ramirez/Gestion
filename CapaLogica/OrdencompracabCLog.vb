Imports Entidades
Imports System.Text
Imports CapaDatos
Public Class OrdencompracabCLog
    Private _OrdencompracabCDat As New OrdencompracabCDat
    Public ReadOnly mensajes As New StringBuilder()
    Public Sub Save(ByVal obj As OrdenCompracab)
        Try
            If (IsValid(obj)) Then
                If (_OrdencompracabCDat.GetById(obj.Id) Is Nothing) Then
                    obj.Id = _OrdencompracabCDat.Insert(obj)
                Else
                    '_MoldeocabCDat.DeleteMoldeodet(obj.Id)
                    _OrdencompracabCDat.Update(obj)
                End If
            End If
        Catch ex As Exception
            mensajes.Append(ex.Message)
        End Try
    End Sub
    Public Function GetAll() As List(Of OrdenCompracab)
        Return _OrdencompracabCDat.GetAll()
    End Function

    Public Function GetByUltimoNroCbte(ByVal Param As String) As UInt32
        mensajes.Clear()

        Return _OrdencompracabCDat.GetByUltimoNroCbte(Param)

    End Function

    Public Function GetById(ByVal id As UInt32) As OrdenCompracab
        mensajes.Clear()
        If (id = 0) Then
            mensajes.Append("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            Return _OrdencompracabCDat.GetById(id)
        Else
            Return Nothing
        End If
    End Function
    Public Function GetByNroOrden(ByVal Cliente As String, ByVal Articulo As String) As List(Of OrdenCompracab)
        Return _OrdencompracabCDat.GetByNroOrden(Cliente, Articulo)
    End Function
    Public Function GetByArticulosPendientes(ByVal Cliente As String, ByVal Articulo As String) As List(Of OrdenCompracab)
        Return _OrdencompracabCDat.GetByArticulosPendientes(Cliente, Articulo)
    End Function
    Public Function GetByCantDespacho(ByVal cliente As String, ByVal Numero As Integer, ByVal Articulo As String) As Double
        Return _OrdencompracabCDat.GetByCantDespacho(cliente, Numero, Articulo)
    End Function

    Public Function GetByNumero(ByVal Id As Integer) As List(Of OrdenCompracab)
        Return _OrdencompracabCDat.GetByNumero(Id)
    End Function
    Public Sub Delete(ByVal id As UInt32)
        mensajes.Clear()
        If (id = 0) Then
            mensajes.Append("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            _OrdencompracabCDat.Delete(id)
        End If
    End Sub
    Private Function IsValid(ByVal obj As OrdenCompracab) As Boolean
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
    Public Function GetValidarOrdenCompra(ByVal Numero As Integer) As Boolean

        Return _OrdencompracabCDat.GetValidarOrdenCompra(Numero)

    End Function
    Public Function GetAllSemanaProducto(ByVal idOrdencompra As Integer) As List(Of OrdenCompradet)
        Return _OrdencompracabCDat.GetOrdencompraDetalle(idOrdencompra)
    End Function

    Public Sub UpdateExpedicion(ByVal fDesde As Date, ByVal fHasta As Date, ByVal cDesde As String, ByVal cHasta As String)
        Try
            _OrdencompracabCDat.UpdateExpedicion(fDesde, fHasta, cDesde, cHasta)

        Catch ex As Exception
            mensajes.Append(ex.Message)
        End Try
    End Sub

    'Public Sub UpdateDespachoOrdenCompra(ByVal Cantidad As Double, ByVal Numero As Integer, ByVal Secuencia As Integer, ByVal Articulo As String, ByVal Rev As String)
    '    Try
    '        _MoldeocabCDat.UpdateDespachoOrdenCompra(Cantidad, Numero, Secuencia, Articulo, Rev)

    '    Catch ex As Exception
    '        mensajes.Append(ex.Message)
    '    End Try
    'End Sub

    Public Sub ReinicioExpedicion(ByVal fDesde As Date, ByVal fHasta As Date)
        Try
            _OrdencompracabCDat.ReinicioExpedicion(fDesde, fHasta)

        Catch ex As Exception
            mensajes.Append(ex.Message)
        End Try
    End Sub
End Class

