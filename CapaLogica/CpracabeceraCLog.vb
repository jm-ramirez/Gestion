Imports Entidades
Imports System.Text
Imports CapaDatos
Public Class CpracabeceraCLog

    Private _CpracabeceraCDat As New CpracabeceraCDat
    Public ReadOnly mensajes As New StringBuilder()

    Public Sub Save(ByRef obj As CpraCabecera)
        Try
            If (IsValid(obj)) Then
                If (_CpracabeceraCDat.GetById(obj.Id) Is Nothing) Then
                    obj.Id = _CpracabeceraCDat.Insert(obj)
                Else
                    _CpracabeceraCDat.Update(obj)
                End If
            End If
        Catch ex As Exception
            mensajes.Append(ex.Message)
        End Try
    End Sub

    Public Sub DesaplicarPago(ByRef obj As CpraCabecera)
        Try
            If (IsValid(obj)) Then
                _CpracabeceraCDat.DesaplicarPago(obj)
            End If
        Catch ex As Exception
            mensajes.Append(ex.Message)
        End Try
    End Sub

    Public Sub UpdatePeriodo(ByRef obj As CpraCabecera)
        Try
            If (IsValid(obj)) Then
                _CpracabeceraCDat.UpdatePeriodo(obj)
            End If
        Catch ex As Exception
            mensajes.Append(ex.Message)
        End Try
    End Sub

    Public Sub Anular(ByRef obj As CpraCabecera)
        Try
            If (IsValid(obj)) Then
                _CpracabeceraCDat.Anular(obj)
            End If
        Catch ex As Exception
            mensajes.Append(ex.Message)
        End Try
    End Sub


    Public Function GetAll(Optional ByVal cargaCtaCte As Boolean = True, _
                              Optional ByVal cargaAlicuotas As Boolean = True, _
                              Optional ByVal cargaArticulos As Boolean = True, _
                              Optional ByVal cargaFinanciero As Boolean = True, _
                              Optional ByVal cargaTributos As Boolean = True, _
                              Optional ByVal cargaAsociados As Boolean = True) As List(Of CpraCabecera)
        Return _CpracabeceraCDat.GetAll(cargaCtaCte:=cargaCtaCte, cargaAlicuotas:=cargaAlicuotas, cargaArticulos:=cargaArticulos, cargaAsociados:=cargaAsociados, cargaFinanciero:=cargaFinanciero, cargaTributos:=cargaTributos)
    End Function

    Public Function GetAllByProveedor(ByVal Proveedor As UInt32, Optional ByVal vertodos As Boolean = False, _
                              Optional ByVal cargaCtaCte As Boolean = True, _
                              Optional ByVal cargaAlicuotas As Boolean = True, _
                              Optional ByVal cargaArticulos As Boolean = True, _
                              Optional ByVal cargaFinanciero As Boolean = True, _
                              Optional ByVal cargaTributos As Boolean = True, _
                              Optional ByVal cargaAsociados As Boolean = True) As List(Of CpraCabecera)
        Return _CpracabeceraCDat.GetAllByProveedor(Proveedor:=Proveedor, vertodos:=vertodos, cargaCtaCte:=cargaCtaCte, cargaAlicuotas:=cargaAlicuotas, cargaArticulos:=cargaArticulos, cargaAsociados:=cargaAsociados, cargaFinanciero:=cargaFinanciero, cargaTributos:=cargaTributos)
    End Function

    Public Function GetCprasCtaCteByProveedor(ByVal Proveedor As UInt32, _
                              Optional ByVal cargaCtaCte As Boolean = True, _
                              Optional ByVal cargaAlicuotas As Boolean = True, _
                              Optional ByVal cargaArticulos As Boolean = True, _
                              Optional ByVal cargaFinanciero As Boolean = True, _
                              Optional ByVal cargaTributos As Boolean = True, _
                              Optional ByVal cargaAsociados As Boolean = True, _
                              Optional ByVal blnVerTodo As Boolean = False) As List(Of CpraCabecera)
        Return _CpracabeceraCDat.GetCbtesCtaCteByProveedor(Proveedor:=Proveedor, cargaCtaCte:=cargaCtaCte, cargaAlicuotas:=cargaAlicuotas, cargaArticulos:=cargaArticulos, cargaAsociados:=cargaAsociados, cargaFinanciero:=cargaFinanciero, cargaTributos:=cargaTributos, blnVerTodo:=blnVerTodo)
    End Function

    Public Function GetById(ByVal id As UInt32, _
                              Optional ByVal cargaCtaCte As Boolean = True, _
                              Optional ByVal cargaAlicuotas As Boolean = True, _
                              Optional ByVal cargaArticulos As Boolean = True, _
                              Optional ByVal cargaFinanciero As Boolean = True, _
                              Optional ByVal cargaTributos As Boolean = True, _
                              Optional ByVal cargaAsociados As Boolean = True) As CpraCabecera
        mensajes.Clear()
        If (id = 0) Then
            mensajes.Append("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            Return _CpracabeceraCDat.GetById(id:=id, cargaCtaCte:=cargaCtaCte, cargaAlicuotas:=cargaAlicuotas, cargaArticulos:=cargaArticulos, cargaAsociados:=cargaAsociados, cargaFinanciero:=cargaFinanciero, cargaTributos:=cargaTributos)
        Else
            Return Nothing
        End If
    End Function

    Public Overloads Function GetByNumero(ByVal Proveedor As UInt32, ByVal Cpratipo As UInt32, ByVal Cpraptovta As UInt32, ByVal Cpranumero As UInt32, _
                              Optional ByVal cargaCtaCte As Boolean = True, _
                              Optional ByVal cargaAlicuotas As Boolean = True, _
                              Optional ByVal cargaArticulos As Boolean = True, _
                              Optional ByVal cargaFinanciero As Boolean = True, _
                              Optional ByVal cargaTributos As Boolean = True, _
                              Optional ByVal cargaAsociados As Boolean = True) As CpraCabecera

        mensajes.Clear()

        If (Proveedor = 0) Then
            mensajes.Append("Por favor proporcione un proveedor válido")
        End If

        If (Cpratipo = 0) Then
            mensajes.Append("Por favor proporcione un tipo de comprobante válido")
        End If

        If (Cpraptovta = 0) Then
            mensajes.Append("Por favor proporcione un punto de venta válido")
        End If

        If (Cpranumero = 0) Then
            mensajes.Append("Por favor proporcione un número de comprobante válido")
        End If

        If (mensajes.Length = 0) Then
            Return _CpracabeceraCDat.GetByNumero(Proveedor:=Proveedor, cbtetipo:=Cpratipo, cbteptovta:=Cpraptovta, cbtenumero:=Cpranumero, _
                                                 cargaCtaCte:=cargaCtaCte, cargaAlicuotas:=cargaAlicuotas, cargaArticulos:=cargaArticulos, cargaAsociados:=cargaAsociados, cargaFinanciero:=cargaFinanciero, cargaTributos:=cargaTributos)
        Else
            Return Nothing
        End If

    End Function

    Public Function GetTotalIvaCbteRef(ByVal proveedor As UInt32, ByVal pIdCbteRef As UInt64) As Double


        Return _CpracabeceraCDat.GetTotalIvaCbteRef(proveedor:=proveedor, pIdCbteRef:=pIdCbteRef)

    End Function

    Public Function GetTotalPagosPeriodo(ByVal proveedor As UInt32, ByVal periodo As Date) As Double


        Return _CpracabeceraCDat.GetTotalPagosPeriodo(proveedor:=proveedor, periodo:=periodo)

    End Function

    Public Function GetTotalRetGciasPeriodo(ByVal proveedor As UInt32, ByVal periodo As Date) As Double


        Return _CpracabeceraCDat.GetTotalRetGciasPeriodo(proveedor:=proveedor, periodo:=periodo)

    End Function


    Public Overloads Function GetByNumero(ByVal Cpratipo As UInt32, ByVal Cpraptovta As UInt32, ByVal Cpranumero As UInt32, _
                              Optional ByVal cargaCtaCte As Boolean = False, _
                              Optional ByVal cargaAlicuotas As Boolean = False, _
                              Optional ByVal cargaArticulos As Boolean = False, _
                              Optional ByVal cargaFinanciero As Boolean = False, _
                              Optional ByVal cargaTributos As Boolean = False, _
                              Optional ByVal cargaAsociados As Boolean = False) As CpraCabecera

        mensajes.Clear()
        
        If (Cpratipo = 0) Then
            mensajes.Append("Por favor proporcione un tipo de comprobante válido")
        End If

        If (Cpraptovta = 0) Then
            mensajes.Append("Por favor proporcione un punto de venta válido")
        End If

        If (Cpranumero = 0) Then
            mensajes.Append("Por favor proporcione un número de comprobante válido")
        End If

        If (mensajes.Length = 0) Then
            Return _CpracabeceraCDat.GetByNumero(cbtetipo:=Cpratipo, cbteptovta:=Cpraptovta, cbtenumero:=Cpranumero, _
                                                 cargaCtaCte:=cargaCtaCte, cargaAlicuotas:=cargaAlicuotas, cargaArticulos:=cargaArticulos, cargaAsociados:=cargaAsociados, cargaFinanciero:=cargaFinanciero, cargaTributos:=cargaTributos)
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
            _CpracabeceraCDat.Delete(id)
        End If

    End Sub

    Private Function IsValid(ByVal obj As CpraCabecera) As Boolean
        mensajes.Clear()
        'implementar validaciones
        Return (mensajes.Length = 0)
    End Function

    Public Function HasError() As Boolean
        Return Not (mensajes.Length = 0)
    End Function

    Public Function GetAnticiposProveedor(ByVal proveedor As UInt32, Optional ByVal vertodos As Boolean = False, Optional ByVal ordenDescendete As Boolean = False, _
                              Optional ByVal cargaCtaCte As Boolean = True, _
                              Optional ByVal cargaAlicuotas As Boolean = True, _
                              Optional ByVal cargaArticulos As Boolean = True, _
                              Optional ByVal cargaFinanciero As Boolean = True, _
                              Optional ByVal cargaTributos As Boolean = True, _
                              Optional ByVal cargaAsociados As Boolean = True) As List(Of CpraCabecera)
        Return _CpracabeceraCDat.GetAnticiposProveedor(proveedor:=proveedor, vertodos:=vertodos, ordenDescendete:=ordenDescendete, _
                                                       cargaCtaCte:=cargaCtaCte, cargaAlicuotas:=cargaAlicuotas, cargaArticulos:=cargaArticulos, cargaAsociados:=cargaAsociados, cargaFinanciero:=cargaFinanciero, cargaTributos:=cargaTributos)
    End Function

    Public Sub AplicarAnticipo(ByVal objAnticipo As CpraCabecera, ByVal cbtes As List(Of Entidades.CbteAsociado))
        Try
            _CpracabeceraCDat.AplicarAnticipo(objAnticipo, cbtes)
        Catch ex As Exception
            mensajes.Append(ex.Message)
        End Try
    End Sub

End Class

