Imports Entidades
Imports System.Text
Imports CapaDatos
Public Class CbteCabecera2CLog

    Private _CbteCabecera2CDat As New CbteCabecera2CDat
    Public ReadOnly mensajes As New StringBuilder()

    Public Sub Save(ByRef obj As CbteCabecera2)
        Try
            If (IsValid(obj)) Then
                If (_CbteCabecera2CDat.GetById(obj.Id) Is Nothing) Then
                    obj.Id = _CbteCabecera2CDat.Insert(obj)
                Else
                    _CbteCabecera2CDat.Update(obj)
                End If
            End If
        Catch ex As Exception
            mensajes.Append(ex.Message)
        End Try
    End Sub

    Public Sub Anular(ByRef obj As CbteCabecera2)
        Try
            If (IsValid(obj)) Then

                _CbteCabecera2CDat.Anular(obj)

            End If
        Catch ex As Exception
            mensajes.Append(ex.Message)
        End Try
    End Sub

    Public Function GetRemitosCliente(ByVal cliente As UInt32, Optional ByVal vertodos As Boolean = False, Optional ByVal ordenDescendete As Boolean = False) As List(Of CbteCabecera2)
        Return _CbteCabecera2CDat.GetRemitosCliente(cliente, vertodos, ordenDescendete)
    End Function


    Public Function GetAll(Optional ByVal cargaCtaCte As Boolean = True, _
                                    Optional ByVal cargaAlicuotas As Boolean = True, _
                                    Optional ByVal cargaArticulos As Boolean = True, _
                                    Optional ByVal cargaFinanciero As Boolean = True, _
                                    Optional ByVal cargaTributos As Boolean = True, _
                                    Optional ByVal cargaAsociados As Boolean = True) As List(Of CbteCabecera2)

        Return _CbteCabecera2CDat.GetAll(cargaCtaCte, cargaAlicuotas, cargaArticulos, cargaFinanciero, cargaTributos, cargaAsociados)

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="cliente">Código del cliente</param>
    ''' <param name="ordenDescendete">Orden Ascendente/Descente</param>
    ''' <param name="cargaCtaCte">Carga el estado de cuenta por comprobante</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAllByCliente(ByVal cliente As UInt32, _
                                    Optional ByVal ordenDescendete As Boolean = False, _
                                    Optional ByVal cargaCtaCte As Boolean = True, _
                                    Optional ByVal cargaAlicuotas As Boolean = True, _
                                    Optional ByVal cargaArticulos As Boolean = True, _
                                    Optional ByVal cargaFinanciero As Boolean = True, _
                                    Optional ByVal cargaTributos As Boolean = True, _
                                    Optional ByVal cargaAsociados As Boolean = True) As List(Of CbteCabecera2)
        Return _CbteCabecera2CDat.GetAllByCliente(cliente, ordenDescendete, cargaCtaCte, cargaAlicuotas, cargaArticulos, cargaFinanciero, cargaTributos, cargaAsociados)
    End Function
    Public Function GetAllByTipo(ByVal tipo As UInt32, _
                                    Optional ByVal ordenDescendete As Boolean = False, _
                                    Optional ByVal cargaCtaCte As Boolean = True, _
                                    Optional ByVal cargaAlicuotas As Boolean = True, _
                                    Optional ByVal cargaArticulos As Boolean = True, _
                                    Optional ByVal cargaFinanciero As Boolean = True, _
                                    Optional ByVal cargaTributos As Boolean = True, _
                                    Optional ByVal cargaAsociados As Boolean = True) As List(Of CbteCabecera2)
        Return _CbteCabecera2CDat.GetAllByTipo(tipo, ordenDescendete, cargaCtaCte, cargaAlicuotas, cargaArticulos, cargaFinanciero, cargaTributos, cargaAsociados)
    End Function

    Public Function GetAnticiposCliente(ByVal cliente As UInt32, Optional ByVal vertodos As Boolean = False, Optional ByVal ordenDescendete As Boolean = False, _
                                    Optional ByVal cargaCtaCte As Boolean = True, _
                                    Optional ByVal cargaAlicuotas As Boolean = True, _
                                    Optional ByVal cargaArticulos As Boolean = True, _
                                    Optional ByVal cargaFinanciero As Boolean = True, _
                                    Optional ByVal cargaTributos As Boolean = True, _
                                    Optional ByVal cargaAsociados As Boolean = True) As List(Of CbteCabecera2)
        Return _CbteCabecera2CDat.GetAnticiposCliente(cliente, vertodos, ordenDescendete, cargaCtaCte, cargaAlicuotas, cargaArticulos, cargaFinanciero, cargaTributos, cargaAsociados)
    End Function

    Public Sub AplicarAnticipo(ByVal objAnticipo As CbteCabecera2, ByVal cbtes As List(Of Entidades.CbteAsociado2))
        Try
            _CbteCabecera2CDat.AplicarAnticipo(objAnticipo, cbtes)
        Catch ex As Exception
            mensajes.Append(ex.Message)
        End Try
    End Sub

    Public Function GetCbtesCtaCteByCliente(ByVal cliente As UInt32, _
                                            Optional ByVal cargaCtaCte As Boolean = True, _
                                            Optional ByVal cargaAlicuotas As Boolean = True, _
                                            Optional ByVal cargaArticulos As Boolean = True, _
                                            Optional ByVal cargaFinanciero As Boolean = True, _
                                            Optional ByVal cargaTributos As Boolean = True, _
                                            Optional ByVal cargaAsociados As Boolean = True) As List(Of CbteCabecera2)
        Return _CbteCabecera2CDat.GetCbtesCtaCteByCliente(cliente, cargaCtaCte, cargaAlicuotas, cargaArticulos, cargaFinanciero, cargaTributos, cargaAsociados)
    End Function

    Public Function GetById(ByVal id As UInt32, _
                            Optional ByVal cargaCtaCte As Boolean = True, _
                            Optional ByVal cargaAlicuotas As Boolean = True, _
                            Optional ByVal cargaArticulos As Boolean = True, _
                            Optional ByVal cargaFinanciero As Boolean = True, _
                            Optional ByVal cargaTributos As Boolean = True, _
                            Optional ByVal cargaAsociados As Boolean = True) As CbteCabecera2
        mensajes.Clear()
        If (id = 0) Then
            mensajes.Append("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            Return _CbteCabecera2CDat.GetById(id, cargaCtaCte, cargaAlicuotas, cargaArticulos, cargaFinanciero, cargaTributos, cargaAsociados)
        Else
            Return Nothing
        End If
    End Function

    Public Function GetByNumero(ByVal cbtetipo As UInt32, ByVal cbteptovta As UInt32, ByVal cbtenumero As UInt32, _
                                Optional ByVal cargaCtaCte As Boolean = True, _
                            Optional ByVal cargaAlicuotas As Boolean = True, _
                            Optional ByVal cargaArticulos As Boolean = True, _
                            Optional ByVal cargaFinanciero As Boolean = True, _
                            Optional ByVal cargaTributos As Boolean = True, _
                            Optional ByVal cargaAsociados As Boolean = True) As CbteCabecera2

        mensajes.Clear()

        If (cbtetipo = 0) Then
            mensajes.Append("Por favor proporcione un tipo de comprobante válido")
        End If

        If (cbteptovta = 0) Then
            mensajes.Append("Por favor proporcione un punto de venta válido")
        End If

        If (cbtenumero = 0) Then
            mensajes.Append("Por favor proporcione un número de comprobante válido")
        End If

        If (mensajes.Length = 0) Then
            Return _CbteCabecera2CDat.GetByNumero(cbtetipo, cbteptovta, cbtenumero, cargaCtaCte, cargaAlicuotas, cargaArticulos, cargaFinanciero, cargaTributos, cargaAsociados)
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
            _CbteCabecera2CDat.Delete(id)
        End If

    End Sub

    Public Sub CambiarEstado(ByVal obj As Entidades.CbteCabecera2, ByVal nuevoestado As String)

        Try
            _CbteCabecera2CDat.CambiarEstado(obj, nuevoestado)
        Catch ex As Exception
            mensajes.Append(ex.Message)
        End Try



    End Sub

    Private Function IsValid(ByVal obj As CbteCabecera2) As Boolean
        mensajes.Clear()
        'implementar validaciones
        Return (mensajes.Length = 0)
    End Function

    Public Function HasError() As Boolean
        Return Not (mensajes.Length = 0)
    End Function

End Class

