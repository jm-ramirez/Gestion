Imports Entidades
Imports MySql.Data.MySqlClient
Public Class CbtecabeceraCDat

    Private ExceptionClassObject As New ManejoDeErrores.ExceptionClass
    Private ExceptionErrorFileString As String = My.Application.Info.DirectoryPath & "\ErrorFile.log"
    Private WriteErrorMessageString As String
    Private ErrorMessageString As String

    Const AFIP_COD_IMPUESTO_NACIONAL As Long = 1
    Const AFIP_COD_IMPUESTO_PROVINCIAL As Long = 2
    Const AFIP_COD_IMPUESTO_MUNICIPAL As Long = 3
    Const AFIP_COD_IMPUESTO_INTERNO As Long = 4
    Const AFIP_COD_IMPUESTO_OTROS As Long = 99

    Const PER_RET_INGRESOS_BRUTOS As String = "Per./Ret. de Ingresos Brutos"

    Private Const FP_CONTADO As Integer = 1
    Private Const FP_CTACTE As Integer = 2
    Private Const PTO_VTA_ELECTRONICO As String = "E"
    Private Const PTO_VTA_FISCAL As String = "F"
    Private Const PTO_VTA_MANUAL As String = "M"
    Private Const PTO_VTA_X As String = "X"

    Public Const CONCEPTO_DEUDOR As String = "D"
    Public Const CONCEPTO_ACREEDOR As String = "C"
    Public Const CUENTA_CARTERA As String = "CARTERA"
    Public Const CONCEPTO_CHEQUE_RECIBIDO As String = "013"
    Public Const CONCEPTO_CHEQUE_PASADO As String = "014"
    Public Const CONCEPTO_CHEQUE_DEPOSITADO As String = "015"

    Private Const FACTURA_A As UInt32 = 1
    Private Const FACTURA_B As UInt32 = 6
    Private Const REMITO As UInt32 = 91
    Private Const NOTA_DEBITO_A As UInt32 = 2
    Private Const NOTA_DEBITO_B As UInt32 = 7
    Private Const TIQUE_FACTURA_A As UInt32 = 81
    Private Const TIQUE_FACTURA_B As UInt32 = 82
    Private Const NOTA_CREDITO_A As UInt32 = 3
    Private Const NOTA_CREDITO_B As UInt32 = 8
    Private Const PRESUPUESTO As UInt32 = 991
    Private Const DEVOLUCION_PRESUPUESTO As UInt32 = 992
    Private Const RECIBO As UInt32 = 993
    Private Const ORDEN_PAGO As UInt32 = 994
    Private Const RECIBO_NP As UInt32 = 995
    Private Const ORDEN_PAGO_NP As UInt32 = 996

    Dim dblCantNumSec As Double
    Dim dblCantDespacho As Double
    Dim strOrdenCompra As String
    Dim lngNroOc As UInt32
    'Dim lngSecOc As UInt16

    Public Function Insert(ByVal obj As CbteCabecera) As UInt32

        Dim id As Long
        Dim transaccion As MySqlTransaction = Nothing
        Dim cnn As MySqlConnection = Nothing
        Dim cmd As MySqlCommand
        Dim ptovta As New CbtepuntoventaCDat
        Dim lngIdMov As Long
        lngIdMov = 0

        Try

            cnn = CreateConnection()
            cnn.Open()
            transaccion = cnn.BeginTransaction
            cmd = New MySqlCommand

            With cmd
                .Connection = cnn
                .Transaction = transaccion
                .CommandType = CommandType.Text

                'actualizo la numeracion interna de comprobantes
                .CommandText = "SELECT * FROM Cbtenumeracion WHERE ptovta = @ptovta AND cbtetipo = @cbtetipo FOR UPDATE"
                .Parameters.Clear()
                .Parameters.AddWithValue("@ptovta", obj.Cbteptovta)
                .Parameters.AddWithValue("@cbtetipo", obj.Cbtetipo)
                .Parameters.AddWithValue("@cbtenumero", obj.Cbtenumero)
                .ExecuteNonQuery()

                'si es un comprobante fiscal no incremento la numeración, registro el n
                Select Case ptovta.GetByPtoVta(obj.Cbteptovta).Tipo
                    Case PTO_VTA_FISCAL : .CommandText = "UPDATE Cbtenumeracion SET numero = @cbtenumero WHERE ptovta = @ptovta AND cbtetipo = @cbtetipo"
                    Case Else : .CommandText = "UPDATE Cbtenumeracion SET numero = numero + 1 WHERE ptovta = @ptovta AND cbtetipo = @cbtetipo"
                End Select
                .ExecuteNonQuery()
       
                .CommandText = "INSERT INTO Cbtecabecera (Id,Concepto,Clienteid,Razonsocial,Domicilio,Nroremito,Documentotipo,Documentonro,"
                .CommandText &= "Cbtetipo,Cbteptovta,Cbtenumero,Cbtefecha,Formadepago,Importetotal,Importetotalconceptos,Importeneto,Importeopexentas,"
                .CommandText &= "Importeiva,Importetributos,Fechaserviciodesde,Fechaserviciohasta,Fechavtopago,Monedaid,Monedactz,Cae,Fechavtocae,"
                .CommandText &= "Observaciones,Tiporesponsable,Cuitemisor,Usuario,Vendedor,Sucursal,Descuento,Letra,Denominacion,Tipo,Importectaspropias,Importecartera,ObservacionesExtra,IdCbteFc,Kgs) VALUES (null,@Concepto,@Clienteid,@Razonsocial,@Domicilio,@Nroremito,@Documentotipo,@Documentonro,"
                .CommandText &= "@Cbtetipo,@Cbteptovta,@Cbtenumero,@Cbtefecha,@Formadepago,@Importetotal,@Importetotalconceptos,@Importeneto,@Importeopexentas,"
                .CommandText &= "@Importeiva,@Importetributos,@Fechaserviciodesde,@Fechaserviciohasta,@Fechavtopago,@Monedaid,@Monedactz,@Cae,@Fechavtocae,"
                .CommandText &= "@Observaciones,@Tiporesponsable,@Cuitemisor,@Usuario,@Vendedor,@Sucursal,@Descuento,@Letra,@Denominacion,@Tipo,@Importectaspropias,@Importecartera,@ObservacionesExtra,@IdCbteFc,@Kgs)"

                .Parameters.Clear()
                '.Parameters.AddWithValue("@Id", obj.Id)
                .Parameters.AddWithValue("@Concepto", obj.Concepto)
                .Parameters.AddWithValue("@Clienteid", obj.ClienteId)
                .Parameters.AddWithValue("@Razonsocial", obj.RazonSocial)
                .Parameters.AddWithValue("@Domicilio", obj.Domicilio)
                .Parameters.AddWithValue("@Nroremito", obj.NroRemito)
                .Parameters.AddWithValue("@Documentotipo", obj.DocumentoTipo)
                .Parameters.AddWithValue("@Documentonro", obj.DocumentoNro)
                .Parameters.AddWithValue("@Cbtetipo", obj.CbteTipo)
                .Parameters.AddWithValue("@Cbteptovta", obj.CbtePtoVta)
                .Parameters.AddWithValue("@Cbtenumero", obj.CbteNumero)
                .Parameters.AddWithValue("@Cbtefecha", obj.CbteFecha)
                .Parameters.AddWithValue("@Formadepago", obj.FormaDePago)
                .Parameters.AddWithValue("@Importetotal", obj.ImporteTotal)
                .Parameters.AddWithValue("@Importetotalconceptos", obj.ImporteTotalConceptos)
                .Parameters.AddWithValue("@Importeneto", obj.ImporteNeto)
                .Parameters.AddWithValue("@Importeopexentas", obj.ImporteOpExentas)
                .Parameters.AddWithValue("@Importeiva", obj.ImporteIVA)
                .Parameters.AddWithValue("@Importetributos", obj.ImporteTributos)
                .Parameters.AddWithValue("@Fechaserviciodesde", obj.FechaServicioDesde)
                .Parameters.AddWithValue("@Fechaserviciohasta", obj.FechaServicioHasta)
                .Parameters.AddWithValue("@Fechavtopago", obj.FechaVtoPago)
                .Parameters.AddWithValue("@Monedaid", obj.MonedaId)
                .Parameters.AddWithValue("@Monedactz", obj.MonedaCtz)
                .Parameters.AddWithValue("@Cae", obj.CAE)
                .Parameters.AddWithValue("@Fechavtocae", obj.FechaVtoCAE)
                .Parameters.AddWithValue("@Observaciones", obj.Observaciones)
                .Parameters.AddWithValue("@Tiporesponsable", obj.Tiporesponsable)
                .Parameters.AddWithValue("@Cuitemisor", obj.CuitEmisor)
                .Parameters.AddWithValue("@Usuario", obj.Usuario)
                .Parameters.AddWithValue("@Vendedor", obj.Vendedor)
                .Parameters.AddWithValue("@Sucursal", obj.Sucursal)
                .Parameters.AddWithValue("@Descuento", obj.Descuento)
                .Parameters.AddWithValue("@Letra", obj.Letra)
                .Parameters.AddWithValue("@Denominacion", obj.Denominacion)
                .Parameters.AddWithValue("@Tipo", obj.Tipo)
                .Parameters.AddWithValue("@Importectaspropias", obj.Importectaspropias)
                .Parameters.AddWithValue("@Importecartera", obj.Importecartera)
                .Parameters.AddWithValue("@ObservacionesExtra", obj.ObservacionesExtra)
                .Parameters.AddWithValue("@IdCbteFc", 0)
                .Parameters.AddWithValue("@Kgs", obj.Kgs)
                .ExecuteNonQuery()

                'recupero el id de la factura creada
                id = .LastInsertedId

                'registro las alicuotas del combrobante
                For Each objAlic As Entidades.CbteAlicuota In obj.CbteAlicuotas
                    .CommandText = "INSERT INTO Cbtealicuota (Id,Cbteid,Codigo,Descripcion,Importe,Alicuota,Baseimponible) VALUES (null,@Cbteid,@Codigo,@Descripcion,@Importe,@Alicuota,@Baseimponible)"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@Cbteid", id)
                    .Parameters.AddWithValue("@Codigo", objAlic.Codigo)
                    .Parameters.AddWithValue("@Descripcion", objAlic.Descripcion)
                    .Parameters.AddWithValue("@Importe", objAlic.Importe)
                    .Parameters.AddWithValue("@Alicuota", objAlic.Alicuota)
                    .Parameters.AddWithValue("@Baseimponible", objAlic.BaseImponible)
                    .ExecuteNonQuery()
                Next

                'registro los comprobantes asociados
                For Each objAsoc As Entidades.CbteAsociado In obj.CbteAsociados
                    .CommandText = "INSERT INTO Cbteasociado (Id,Cbteid,Numero,Ptovta,Tipo,Importe,Cbtereferencia) VALUES (null,@Cbteid,@Numero,@Ptovta,@Tipo,@Importe,@Cbtereferencia)"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@Cbteid", id)
                    .Parameters.AddWithValue("@Cbtereferencia", objAsoc.CbteReferencia)
                    .Parameters.AddWithValue("@Numero", objAsoc.Numero)
                    .Parameters.AddWithValue("@Ptovta", objAsoc.PtoVta)
                    .Parameters.AddWithValue("@Tipo", objAsoc.Tipo)
                    .Parameters.AddWithValue("@Importe", objAsoc.Importe)
                    .ExecuteNonQuery()
                Next

                'registro los tributos del combrobante
                For Each objTrib As Entidades.CbteTributo In obj.CbteTributos
                    .CommandText = "INSERT INTO Cbtetributo (Id,Cbteid,Codigo,Descripcion,Importe,Alicuota,Baseimponible,Referencia) VALUES (null,@Cbteid,@Codigo,@Descripcion,@Importe,@Alicuota,@Baseimponible,@Referencia)"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@Cbteid", id)
                    .Parameters.AddWithValue("@Codigo", objTrib.Codigo)
                    .Parameters.AddWithValue("@Descripcion", objTrib.Descripcion)
                    .Parameters.AddWithValue("@Importe", objTrib.Importe)
                    .Parameters.AddWithValue("@Alicuota", objTrib.Alicuota)
                    .Parameters.AddWithValue("@Baseimponible", objTrib.BaseImponible)
                    .Parameters.AddWithValue("@Referencia", objTrib.Referencia)
                    .ExecuteNonQuery()
                Next

                'registro los articulos del combrobante y la ficha de stock
                For Each objArt As Entidades.CbteArticulo In obj.CbteArticulos
                    .CommandText = "INSERT INTO Cbtearticulo (Id,Cbteid,Codigo,Descripcion,Cantidad,Importe,ImpIntTasaNominal,Alicuotacodigo,"
                    .CommandText &= "Alicuota,Unidad,Descuento,Listadeprecio,Comision,ImpInterno,Kgs,Numero,Codcliente) VALUES (null,@Cbteid,@Codigo,@Descripcion,@Cantidad,@Importe,@ImpIntTasaNominal,"
                    .CommandText &= "@Alicuotacodigo,@Alicuota,@Unidad,@Descuento,@Listadeprecio,@Comision,@ImpInterno,@Kgs,@Numero,@Codcliente)"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@Cbteid", id)
                    .Parameters.AddWithValue("@Codigo", objArt.Codigo)
                    .Parameters.AddWithValue("@Descripcion", objArt.Descripcion)
                    .Parameters.AddWithValue("@Cantidad", objArt.Cantidad)
                    .Parameters.AddWithValue("@Importe", objArt.Importe)
                    .Parameters.AddWithValue("@ImpIntTasaNominal", objArt.ImpIntTasaNominal)
                    .Parameters.AddWithValue("@Alicuotacodigo", objArt.AlicuotaCodigo)
                    .Parameters.AddWithValue("@Alicuota", objArt.Alicuota)
                    .Parameters.AddWithValue("@Unidad", objArt.Unidad)
                    .Parameters.AddWithValue("@Descuento", objArt.Descuento)
                    .Parameters.AddWithValue("@Listadeprecio", objArt.Listadeprecio)
                    .Parameters.AddWithValue("@Comision", objArt.Comision)
                    .Parameters.AddWithValue("@ImpInterno", objArt.ImpInterno)

                    '.Parameters.AddWithValue("@Rev", objArt.Rev)
                    .Parameters.AddWithValue("@Kgs", objArt.Kgs)
                    .Parameters.AddWithValue("@Numero", objArt.Numero)
                    '.Parameters.AddWithValue("@Secuencia", objArt.Secuencia)
                    .Parameters.AddWithValue("@Codcliente", objArt.Codcliente)
                    .ExecuteNonQuery()

                    'Actualizo el Precio del Artículo
                    If obj.Cbtetipo = FACTURA_A Or obj.Cbtetipo = FACTURA_B Then
                        .CommandText = "UPDATE articulos SET preciodeventa=@importe WHERE codigo=@codigo" ' AND codcliente=@codcliente
                        .Parameters.Clear()
                        .Parameters.AddWithValue("@codcliente", objArt.Codcliente)
                        .Parameters.AddWithValue("@codigo", objArt.Codigo)
                        '.Parameters.AddWithValue("@rev", objArt.Rev)
                        .Parameters.AddWithValue("@Importe", objArt.Importe)
                        .ExecuteNonQuery()
                    End If

                    'X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X
                    'Actualizo las OC (Remito: Tabla: MoldeoDet)
                    'X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X
                    If obj.Cbtetipo = REMITO Or obj.Cbtetipo = FACTURA_A Or obj.Cbtetipo = FACTURA_B Then
                        strOrdenCompra = ""
                        dblCantNumSec = 0
                        dblCantDespacho = 0
                        'si aplico a una orden de compra
                        If objArt.Numero <> 0 Then
                            strOrdenCompra = strOrdenCompra & objArt.Numero & " / "
                            lngNroOc = objArt.Numero
                            'lngSecOc = objArt.Secuencia

                            'Cantidad a Despachar
                            dblCantNumSec = objArt.Cantidad

                            Do While dblCantNumSec > 0
                                dblCantDespacho = GetByCantDespacho(objArt.Codcliente, lngNroOc, objArt.Codigo)

                                'si la cantidad es menor o igual a la de la orden de compra
                                If dblCantNumSec >= dblCantDespacho Then
                                    'Actualizo la Cantidad Enviada
                                    .CommandText = "UPDATE ordencompracab oc, ordencompradet od SET od.despacho=od.despacho+@Cantidad,od.CbteVta=@id "
                                    .CommandText &= "WHERE oc.id=od.idordencompra AND oc.codcliente=@cliente AND oc.`numero`=@Numero AND od.articulo=@Articulo"
                                    .Parameters.Clear()
                                    .Parameters.AddWithValue("@Cliente", objArt.Codcliente)
                                    .Parameters.AddWithValue("@Numero", lngNroOc)
                                    '.Parameters.AddWithValue("@Secuencia", lngSecOc)
                                    .Parameters.AddWithValue("@Articulo", objArt.Codigo)
                                    '.Parameters.AddWithValue("@Rev", objArt.Rev)
                                    .Parameters.AddWithValue("@Cantidad", dblCantDespacho)
                                    .Parameters.AddWithValue("@id", id)
                                    .ExecuteNonQuery()

                                    dblCantNumSec = dblCantNumSec - dblCantDespacho
                                Else
                                    'Actualizo la Cantidad Enviada
                                    .CommandText = "UPDATE ordencompracab oc, ordencompradet od SET od.despacho=od.despacho+@Cantidad,od.CbteVta=@id "
                                    .CommandText &= "WHERE oc.id=od.idordencompra AND oc.codcliente=@cliente AND oc.`numero`=@Numero AND od.articulo=@Articulo"
                                    .Parameters.Clear()
                                    .Parameters.AddWithValue("@Cliente", objArt.Codcliente)
                                    .Parameters.AddWithValue("@Numero", lngNroOc)
                                    '.Parameters.AddWithValue("@Secuencia", lngSecOc)
                                    .Parameters.AddWithValue("@Articulo", objArt.Codigo)
                                    '.Parameters.AddWithValue("@Rev", objArt.Rev)
                                    .Parameters.AddWithValue("@Cantidad", dblCantNumSec)
                                    .Parameters.AddWithValue("@id", id)
                                    .ExecuteNonQuery()
                                    dblCantNumSec = 0
                                End If

                                'Si me sobra Saldo se lo Aplico a Otras Ordenes que haya
                                If dblCantNumSec > 0 Then
                                    strOrdenCompra = GetByCantDespachoOtros(objArt.Codcliente, lngNroOc, objArt.Codigo)
                                    If strOrdenCompra IsNot Nothing And strOrdenCompra <> "" Then
                                        If Len(strOrdenCompra) = 11 Then
                                            lngNroOc = Val(Left(strOrdenCompra, 8))
                                            'lngSecOc = Val(Right(strOrdenCompra, 2))
                                        Else
                                            Exit Do
                                        End If
                                    Else
                                        Exit Do
                                    End If
                                Else
                                    Exit Do
                                End If
                            Loop

                        End If
                    End If
                    'X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X

                    'si se trata de una facturacion de remito no se debe bajar la mercaderia ya que salio por el concepto remito (91)
                    If obj.RemitoId = 0 Then

                        .CommandText = "INSERT INTO Fichastock (Id,Origen,Cbtevta,Fecha,Articulo,Cantidad,Sucursal,Usuario) VALUES (null,@Origen,@Cbtevta,@Fecha,@Articulo,@Cantidad,@Sucursal,@Usuario)"
                        .Parameters.Clear()
                        .Parameters.AddWithValue("@Origen", "VENTA")
                        .Parameters.AddWithValue("@Cbtevta", id)
                        .Parameters.AddWithValue("@Fecha", obj.Cbtefecha.Substring(0, 4) & "/" & obj.Cbtefecha.Substring(4, 2) & "/" & obj.Cbtefecha.Substring(6, 2))
                        .Parameters.AddWithValue("@Articulo", objArt.Codigo)

                        Select Case obj.Tipo
                            Case CONCEPTO_DEUDOR
                                .Parameters.AddWithValue("@Cantidad", (objArt.Cantidad * -1))
                            Case Else
                                .Parameters.AddWithValue("@Cantidad", objArt.Cantidad)
                        End Select


                        .Parameters.AddWithValue("@Sucursal", obj.Sucursal)
                        .Parameters.AddWithValue("@Usuario", obj.Usuario)
                        .ExecuteNonQuery()
                    End If

                Next

                'registro en financiero el ingreso
                If obj.Formadepago = FP_CONTADO Then

                    For Each objFinanciero As Entidades.Financiero In obj.CbteDetalleFinanciero

                        .CommandText = "INSERT INTO Financiero (Id,Origen,Cuenta,Concepto,Beneficiario,Emision,Efectivizacion,Importe,"
                        .CommandText &= "Referencia,Observacion,Usuario,Fecharegistracion,Banco,Cbtevta,Tipo,Dador,Sucursal,DocumentoNro,Localidad) VALUES (null,@Origen,@Cuenta,@Concepto,"
                        .CommandText &= "@Beneficiario,@Emision,@Efectivizacion,@Importe,@Referencia,@Observacion,@Usuario,@Fecharegistracion,@Banco,"
                        .CommandText &= "@Cbtevta,@Tipo,@Dador,@Sucursal,@DocumentoNro,@Localidad)"

                        objFinanciero.Observacion &= obj.CbteDenominacion

                        .Parameters.Clear()
                        .Parameters.AddWithValue("@Origen", objFinanciero.Origen)
                        .Parameters.AddWithValue("@Cuenta", objFinanciero.Cuenta)
                        .Parameters.AddWithValue("@Concepto", objFinanciero.Concepto)
                        .Parameters.AddWithValue("@Beneficiario", objFinanciero.Beneficiario)
                        .Parameters.AddWithValue("@Dador", objFinanciero.Dador)
                        .Parameters.AddWithValue("@Emision", objFinanciero.Emision)
                        .Parameters.AddWithValue("@Efectivizacion", objFinanciero.Efectivizacion)
                        .Parameters.AddWithValue("@Importe", objFinanciero.Importe)
                        .Parameters.AddWithValue("@Referencia", objFinanciero.Referencia)
                        .Parameters.AddWithValue("@Observacion", objFinanciero.Observacion)
                        .Parameters.AddWithValue("@Usuario", obj.Usuario)
                        .Parameters.AddWithValue("@Fecharegistracion", Date.Now)
                        .Parameters.AddWithValue("@Banco", objFinanciero.Banco)
                        .Parameters.AddWithValue("@Tipo", objFinanciero.Tipo)
                        .Parameters.AddWithValue("@Cbtevta", id)
                        .Parameters.AddWithValue("@Sucursal", obj.Sucursal)
                        .Parameters.AddWithValue("@Documentonro", objFinanciero.DocumentoNro)
                        .Parameters.AddWithValue("@Localidad", objFinanciero.Localidad)
                        .ExecuteNonQuery()

                    Next


                End If

                If obj.Cbtetipo <> RECIBO And obj.Cbtetipo <> RECIBO_NP And obj.Cbtetipo <> REMITO Then
                    'actulizo la ultima fecha de operatoria del cliente/proveedor
                    .CommandText = "UPDATE cliente SET Fechaultimacompra=@fechaultimacompra,formadepago=@Formadepago WHERE id = @id"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@id", obj.Clienteid)
                    .Parameters.AddWithValue("@Formadepago", obj.Formadepago)
                    .Parameters.AddWithValue("@fechaultimacompra", Convert.ToDateTime(obj.FechaEmision))
                    .ExecuteNonQuery()
                End If

                'actualizo el remito facturado
                If obj.RemitoId > 0 Then
                    .CommandText = "UPDATE cbtecabecera SET NroRemito = @factura,IdCbteFc=@IdFc WHERE id = @id"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@id", obj.RemitoId)
                    .Parameters.AddWithValue("@factura", obj.CbteDenominacion)
                    .Parameters.AddWithValue("@IdFc", id)
                    .ExecuteNonQuery()
                End If

                ' si cargo remito
                For Each objRemito As Entidades.Remito In obj.Remito
                    .CommandText = "INSERT INTO Remito (Id,Idremito,Fecha,Clientenombre,Clientedomicilio,Clientecodpostal,Clientelocalidad,Clienteiva,Clientecuit,Ordencompra,Unidad,Kgs,Bultos,Valordeclarado,Tipoenvio,Transportenombre,Transportedireccion,Transportecuit,Lugarentrega,Control) "
                    .CommandText &= "VALUES (null,@Idremito,@Fecha,@Clientenombre,@Clientedomicilio,@Clientecodpostal,@Clientelocalidad,@Clienteiva,@Clientecuit,@Ordencompra,@Unidad,@Kgs,@Bultos,@Valordeclarado,@Tipoenvio,@Transportenombre,@Transportedireccion,@Transportecuit,@Lugarentrega,@Control)"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@Idremito", id)
                    .Parameters.AddWithValue("@Fecha", objRemito.Fecha)
                    .Parameters.AddWithValue("@Clientenombre", objRemito.Clientenombre)
                    .Parameters.AddWithValue("@Clientedomicilio", objRemito.Clientedomicilio)
                    .Parameters.AddWithValue("@Clientecodpostal", objRemito.Clientecodpostal)
                    .Parameters.AddWithValue("@Clientelocalidad", objRemito.Clientelocalidad)
                    .Parameters.AddWithValue("@Clienteiva", objRemito.Clienteiva)
                    .Parameters.AddWithValue("@Clientecuit", objRemito.Clientecuit)
                    .Parameters.AddWithValue("@Ordencompra", objRemito.Ordencompra)
                    .Parameters.AddWithValue("@Unidad", objRemito.Unidad)
                    .Parameters.AddWithValue("@Kgs", objRemito.Kgs)
                    .Parameters.AddWithValue("@Bultos", objRemito.Bultos)
                    .Parameters.AddWithValue("@Valordeclarado", objRemito.Valordeclarado)
                    .Parameters.AddWithValue("@Tipoenvio", objRemito.Tipoenvio)
                    .Parameters.AddWithValue("@Transportenombre", objRemito.Transportenombre)
                    .Parameters.AddWithValue("@Transportedireccion", objRemito.Transportedireccion)
                    .Parameters.AddWithValue("@Transportecuit", objRemito.Transportecuit)
                    .Parameters.AddWithValue("@Lugarentrega", objRemito.Lugarentrega)
                    .Parameters.AddWithValue("@Control", objRemito.Control)
                    .ExecuteNonQuery()
                Next

            End With

            transaccion.Commit()

            Return id

        Catch exError As MySqlException

            If transaccion IsNot Nothing Then
                transaccion.Rollback()
            End If

            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cbtecabecera", _
            "Insert", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)

        Finally
            If cnn IsNot Nothing Then
                If cnn.State = ConnectionState.Open Then
                    cnn.Close()
                End If
            End If
        End Try
    End Function

    Public Function GetByCantDespacho(ByVal cliente As String, ByVal Nro As UInt32, ByVal codigo As String) As Double
        Dim dblCant As Double
        dblCant = 0
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT (od.`cantidad`-od.`despacho`) Cantidad FROM ordencompracab oc LEFT JOIN ordencompradet od ON oc.id=od.`idordencompra` "
                        .CommandText &= "WHERE oc.`codcliente`=@cliente AND oc.`numero`=@Numero AND od.articulo=@Articulo "
                        .CommandText &= "AND (od.`cantidad`-od.`despacho`)>0"
                        .Parameters.AddWithValue("@Numero", Nro)
                        '.Parameters.AddWithValue("@Secuencia", Sec)
                        .Parameters.AddWithValue("@Articulo", codigo)
                        '.Parameters.AddWithValue("@Rev", rev)
                        .Parameters.AddWithValue("@Cliente", cliente)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                dblCant = reader("Cantidad")

                                Return dblCant
                            Else
                                Return Nothing
                            End If
                        End Using
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:GetByCantDespacho", _
            "GetById", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetByCantDespachoOtros(ByVal cliente As String, ByVal NoIncNro As UInt32, ByVal codigo As String) As String
        Dim strNroOc As String
        strNroOc = ""
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT (od.`cantidad`-od.`despacho`) Cantidad,lpad(cast(oc.`numero` as char),8,'0') NroOc "
                        .CommandText &= "FROM ordencompracab oc LEFT JOIN ordencompradet od ON oc.id=od.`idordencompra` "
                        .CommandText &= "WHERE oc.`codcliente`=@cliente AND od.`articulo`=@Articulo AND (od.`cantidad`-od.`despacho`)>0"
                        '.Parameters.AddWithValue("@Numero", NoIncNro)
                        '.Parameters.AddWithValue("@Secuencia", NoIncSec)
                        .Parameters.AddWithValue("@Articulo", codigo)
                        '.Parameters.AddWithValue("@Rev", rev)
                        .Parameters.AddWithValue("@Cliente", cliente)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Do While reader.Read
                                    If reader("NroOc") = Format(NoIncNro, "00000000") Then
                                        'no la tomo
                                        strNroOc = ""
                                    Else
                                        strNroOc = reader("NroOc")
                                    End If
                                    If strNroOc <> "" Then Exit Do
                                Loop

                                Return strNroOc
                            Else
                                Return Nothing
                            End If
                        End Using
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:GetByCantDespacho", _
            "GetById", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function AplicarAnticipo(ByVal objAnticipo As CbteCabecera, ByVal cbtes As List(Of Entidades.CbteAsociado)) As UInt32

        Dim id As Long
        Dim transaccion As MySqlTransaction = Nothing
        Dim cnn As MySqlConnection = Nothing
        Dim cmd As MySqlCommand
        Dim ptovta As New CbtepuntoventaCDat

        Try

            cnn = CreateConnection()
            cnn.Open()
            transaccion = cnn.BeginTransaction
            cmd = New MySqlCommand

            With cmd
                .Connection = cnn
                .Transaction = transaccion
                .CommandType = CommandType.Text

                'registro los comprobantes asociados
                For Each objAsoc As Entidades.CbteAsociado In cbtes
                    .CommandText = "INSERT INTO Cbteasociado (Id,Cbteid,Numero,Ptovta,Tipo,Importe,Cbtereferencia) VALUES (null,@Cbteid,@Numero,@Ptovta,@Tipo,@Importe,@Cbtereferencia)"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@Cbteid", objAnticipo.Id)
                    .Parameters.AddWithValue("@Cbtereferencia", objAsoc.CbteReferencia)
                    .Parameters.AddWithValue("@Numero", objAsoc.Numero)
                    .Parameters.AddWithValue("@Ptovta", objAsoc.PtoVta)
                    .Parameters.AddWithValue("@Tipo", objAsoc.Tipo)
                    .Parameters.AddWithValue("@Importe", objAsoc.Importe)
                    .ExecuteNonQuery()
                Next

            End With

            transaccion.Commit()

            Return id

        Catch exError As MySqlException

            If transaccion IsNot Nothing Then
                transaccion.Rollback()
            End If

            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cbtecabecera", _
            "AplicarAnticipo", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)

        Finally
            If cnn IsNot Nothing Then
                If cnn.State = ConnectionState.Open Then
                    cnn.Close()
                End If
            End If
        End Try
    End Function

    Public Sub Update(ByVal obj As CbteCabecera)
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "UPDATE Cbtecabecera SET Concepto = @Concepto,Clienteid = @Clienteid,Razonsocial = @Razonsocial,"
                        .CommandText &= "Domicilio = @Domicilio,Nroremito = @Nroremito,Documentotipo = @Documentotipo,Documentonro = @Documentonro,"
                        .CommandText &= "Cbtetipo = @Cbtetipo,Cbteptovta = @Cbteptovta,Cbtenumero = @Cbtenumero,Cbtefecha = @Cbtefecha,Formadepago = @Formadepago,"
                        .CommandText &= "Importetotal = @Importetotal,Importetotalconceptos = @Importetotalconceptos,Importeneto = @Importeneto,"
                        .CommandText &= "Importeopexentas = @Importeopexentas,Importeiva = @Importeiva,Importetributos = @Importetributos,"
                        .CommandText &= "Fechaserviciodesde = @Fechaserviciodesde,Fechaserviciohasta = @Fechaserviciohasta,Fechavtopago = @Fechavtopago,"
                        .CommandText &= "Monedaid = @Monedaid,Monedactz = @Monedactz,Cae = @Cae,Fechavtocae = @Fechavtocae,"
                        .CommandText &= "Observaciones = @Observaciones,Tiporesponsable = @Tiporesponsable,Cuitemisor = @Cuitemisor WHERE Id = @Id"
                        .Parameters.AddWithValue("@Id", obj.Id)
                        .Parameters.AddWithValue("@Concepto", obj.Concepto)
                        .Parameters.AddWithValue("@Clienteid", obj.Clienteid)
                        .Parameters.AddWithValue("@Razonsocial", obj.Razonsocial)
                        .Parameters.AddWithValue("@Domicilio", obj.Domicilio)
                        .Parameters.AddWithValue("@Nroremito", obj.Nroremito)
                        .Parameters.AddWithValue("@Documentotipo", obj.Documentotipo)
                        .Parameters.AddWithValue("@Documentonro", obj.Documentonro)
                        .Parameters.AddWithValue("@Cbtetipo", obj.Cbtetipo)
                        .Parameters.AddWithValue("@Cbteptovta", obj.Cbteptovta)
                        .Parameters.AddWithValue("@Cbtenumero", obj.Cbtenumero)
                        .Parameters.AddWithValue("@Cbtefecha", obj.Cbtefecha)
                        .Parameters.AddWithValue("@Formadepago", obj.Formadepago)
                        .Parameters.AddWithValue("@Importetotal", obj.Importetotal)
                        .Parameters.AddWithValue("@Importetotalconceptos", obj.Importetotalconceptos)
                        .Parameters.AddWithValue("@Importeneto", obj.Importeneto)
                        .Parameters.AddWithValue("@Importeopexentas", obj.Importeopexentas)
                        .Parameters.AddWithValue("@Importeiva", obj.Importeiva)
                        .Parameters.AddWithValue("@Importetributos", obj.Importetributos)
                        .Parameters.AddWithValue("@Fechaserviciodesde", obj.Fechaserviciodesde)
                        .Parameters.AddWithValue("@Fechaserviciohasta", obj.Fechaserviciohasta)
                        .Parameters.AddWithValue("@Fechavtopago", obj.Fechavtopago)
                        .Parameters.AddWithValue("@Monedaid", obj.Monedaid)
                        .Parameters.AddWithValue("@Monedactz", obj.Monedactz)
                        .Parameters.AddWithValue("@Cae", obj.Cae)
                        .Parameters.AddWithValue("@Fechavtocae", obj.Fechavtocae)
                        .Parameters.AddWithValue("@Observaciones", obj.Observaciones)
                        .Parameters.AddWithValue("@Tiporesponsable", obj.Tiporesponsable)
                        .Parameters.AddWithValue("@Cuitemisor", obj.Cuitemisor)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cbtecabecera", _
            "Update", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Sub
    Public Sub Delete(ByVal id As UInt32)
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "DELETE FROM Cbtecabecera WHERE Id = @Id"
                        .Parameters.AddWithValue("@Id", id)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cbtecabecera", _
            "Delete", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Sub

    Public Function GetById(ByVal id As UInt32, Optional ByVal cargaCtaCte As Boolean = True, _
                              Optional ByVal cargaAlicuotas As Boolean = True, _
                              Optional ByVal cargaArticulos As Boolean = True, _
                              Optional ByVal cargaFinanciero As Boolean = True, _
                              Optional ByVal cargaTributos As Boolean = True, _
                              Optional ByVal cargaAsociados As Boolean = True) As CbteCabecera
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Cbtecabecera WHERE Id= @Id"
                        .Parameters.AddWithValue("@Id", id)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Dim obj As New CbteCabecera
                                'obj = Populate(reader)
                                obj = Populate(reader, cargaCtaCte, cargaAlicuotas, cargaArticulos, cargaFinanciero, cargaTributos, cargaAsociados)
                                Return obj
                            Else
                                Return Nothing
                            End If
                        End Using
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cbtecabecera", _
            "GetById", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetByNumero(ByVal cbtetipo As UInt32, ByVal cbteptovta As UInt32, ByVal cbtenumero As UInt32, _
                              Optional ByVal cargaCtaCte As Boolean = True, _
                              Optional ByVal cargaAlicuotas As Boolean = True, _
                              Optional ByVal cargaArticulos As Boolean = True, _
                              Optional ByVal cargaFinanciero As Boolean = True, _
                              Optional ByVal cargaTributos As Boolean = True, _
                              Optional ByVal cargaAsociados As Boolean = True) As CbteCabecera
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Cbtecabecera WHERE cbtetipo= @cbtetipo AND cbteptovta = @cbteptovta AND cbtenumero = @cbtenumero"
                        .Parameters.AddWithValue("@cbtetipo", cbtetipo)
                        .Parameters.AddWithValue("@cbteptovta", cbteptovta)
                        .Parameters.AddWithValue("@cbtenumero", cbtenumero)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Dim obj As New CbteCabecera
                                'obj = Populate(reader)
                                obj = Populate(reader, cargaCtaCte, cargaAlicuotas, cargaArticulos, cargaFinanciero, cargaTributos, cargaAsociados)
                                Return obj
                            Else
                                Return Nothing
                            End If
                        End Using
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cbtecabecera", _
            "GetByNumero", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetAll(Optional ByVal cargaCtaCte As Boolean = True, _
                              Optional ByVal cargaAlicuotas As Boolean = True, _
                              Optional ByVal cargaArticulos As Boolean = True, _
                              Optional ByVal cargaFinanciero As Boolean = True, _
                              Optional ByVal cargaTributos As Boolean = True, _
                              Optional ByVal cargaAsociados As Boolean = True) As List(Of CbteCabecera)
        Try
            Dim lista As New List(Of CbteCabecera)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Cbtecabecera"
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New CbteCabecera
                                    'obj = Populate(reader)
                                    obj = Populate(reader, cargaCtaCte, cargaAlicuotas, cargaArticulos, cargaFinanciero, cargaTributos, cargaAsociados)
                                    lista.Add(obj)
                                    obj = Nothing
                                Loop
                                Return lista
                            End Using
                        Finally
                            lista = Nothing
                        End Try
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cbtecabecera", _
            "GetAll", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetAllByCliente(ByVal cliente As UInt32, Optional ByVal vertodos As Boolean = False, _
                                    Optional ByVal ordenDescendete As Boolean = False, _
                                    Optional ByVal cargaCtaCte As Boolean = True, _
                                    Optional ByVal cargaAlicuotas As Boolean = True, _
                                    Optional ByVal cargaArticulos As Boolean = True, _
                                    Optional ByVal cargaFinanciero As Boolean = True, _
                                    Optional ByVal cargaTributos As Boolean = True, _
                                    Optional ByVal cargaAsociados As Boolean = True) As List(Of CbteCabecera)
        Try
            Dim lista As New List(Of CbteCabecera)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Cbtecabecera WHERE ClienteId = @cliente"

                        If Not vertodos Then
                            .CommandText &= " AND cbtetipo NOT IN (991,992,995,996)"
                        End If

                        If ordenDescendete Then
                            .CommandText &= " ORDER BY id DESC"
                        End If

                        .Parameters.AddWithValue("@cliente", cliente)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New CbteCabecera
                                    obj = Populate(reader, cargaCtaCte, cargaAlicuotas, cargaArticulos, cargaFinanciero, cargaTributos, cargaAsociados)
                                    lista.Add(obj)
                                    obj = Nothing
                                Loop
                                Return lista
                            End Using
                        Finally
                            lista = Nothing
                        End Try
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cbtecabecera", _
            "GetAllByCliente", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetAnticiposCliente(ByVal cliente As UInt32, Optional ByVal vertodos As Boolean = False, Optional ByVal ordenDescendete As Boolean = False, _
                                    Optional ByVal cargaCtaCte As Boolean = True, _
                                    Optional ByVal cargaAlicuotas As Boolean = True, _
                                    Optional ByVal cargaArticulos As Boolean = True, _
                                    Optional ByVal cargaFinanciero As Boolean = True, _
                                    Optional ByVal cargaTributos As Boolean = True, _
                                    Optional ByVal cargaAsociados As Boolean = True) As List(Of CbteCabecera)
        Try
            Dim lista As New List(Of CbteCabecera)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Cbtecabecera WHERE ClienteId = @cliente"

                        If Not vertodos Then
                            .CommandText &= " AND cbtetipo IN (993,994)"
                        Else
                            .CommandText &= " AND cbtetipo IN (993,994,995,996)"
                        End If

                        If ordenDescendete Then
                            .CommandText &= " ORDER BY id DESC"
                        End If

                        .Parameters.AddWithValue("@cliente", cliente)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New CbteCabecera
                                    'obj = Populate(reader)
                                    obj = Populate(reader, cargaCtaCte, cargaAlicuotas, cargaArticulos, cargaFinanciero, cargaTributos, cargaAsociados)
                                    lista.Add(obj)
                                    obj = Nothing
                                Loop
                                Return lista
                            End Using
                        Finally
                            lista = Nothing
                        End Try
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cbtecabecera", _
            "GetAnticiposCliente", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetCbtesCtaCteByCliente(ByVal cliente As UInt32, Optional ByVal cargaCtaCte As Boolean = True, _
                              Optional ByVal cargaAlicuotas As Boolean = True, _
                              Optional ByVal cargaArticulos As Boolean = True, _
                              Optional ByVal cargaFinanciero As Boolean = True, _
                              Optional ByVal cargaTributos As Boolean = True, _
                              Optional ByVal cargaAsociados As Boolean = True, _
                              Optional ByVal blnVerTodo As Boolean = False) As List(Of CbteCabecera)
        Try
            Dim lista As New List(Of CbteCabecera)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Cbtecabecera WHERE ClienteId = @cliente" ' AND FormaDePago<>@formapago"
                        '.CommandText = "SELECT *,CbteReferencia,SUM(Importe) Saldo FROM ( "
                        '.CommandText &= "SELECT r.*,r.`Id` CbteReferencia,IF(r.Tipo='C',r.`ImporteTotal`*-1,r.`ImporteTotal`) Importe "
                        '.CommandText &= "FROM `cbtecabecera` r,`tipocomprobante` t "
                        '.CommandText &= "WHERE r.`CbteTipo` = t.`Codigo` "
                        '.CommandText &= "AND r.`CbteTipo` IN (1,6,81,82,11,51,83,111) "
                        '.CommandText &= "AND r.ClienteId=@cliente "
                        '.CommandText &= "UNION ALL "
                        '.CommandText &= "SELECT r.*,c.`Id` CbteReferencia,IF(r.Tipo='C',c.`Importe`*-1,c.`Importe`) Importe "
                        '.CommandText &= "FROM `cbtecabecera` r,`cbteasociado` c,`tipocomprobante` t "
                        '.CommandText &= "WHERE r.id = c.`CbteId` "
                        '.CommandText &= "AND r.`CbteTipo` = t.`Codigo` "
                        '.CommandText &= "AND r.`CbteTipo` NOT IN (1,6,81,82,11,51,83,111,91) "
                        '.CommandText &= "AND r.ClienteId=@cliente "
                        '.CommandText &= "ORDER BY clienteid,CbteTipo,CbteFecha,CbtePtoVta,CbteNumero "
                        '.CommandText &= ") Pendientes "
                        '.CommandText &= "GROUP BY CbteReferencia HAVING (ABS(Saldo) " & IIf(blnVerTodo = False, ">", ">=") & " 0) "
                        '.CommandText &= "ORDER BY ClienteId,CbteTipo,CbteFecha,CbtePtoVta,CbteNumero"
                        .Parameters.Clear()
                        .Parameters.AddWithValue("@cliente", cliente)
                        .Parameters.AddWithValue("@formapago", FP_CONTADO)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New CbteCabecera
                                    'obj = Populate(reader)
                                    obj = Populate(reader, cargaCtaCte, cargaAlicuotas, cargaArticulos, cargaFinanciero, cargaTributos, cargaAsociados)
                                    lista.Add(obj)
                                    obj = Nothing
                                Loop
                                Return lista
                            End Using
                        Finally
                            lista = Nothing
                        End Try
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cbtecabecera", _
            "GetCbtesCtaCteByCliente", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetAlicuotas(ByVal Id As UInt32) As List(Of CbteAlicuota)
        Try
            Dim lista As New List(Of CbteAlicuota)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM CbteAlicuota WHERE CbteId = @Id"
                        .Parameters.AddWithValue("@Id", Id)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New CbteAlicuota
                                    obj = PopulateAlicuota(reader)
                                    lista.Add(obj)
                                    obj = Nothing
                                Loop
                                Return lista
                            End Using
                        Finally
                            lista = Nothing
                        End Try
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cbtecabecera", _
            "GetAlicuotas", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetTributos(ByVal Id As UInt32) As List(Of CbteTributo)
        Try
            Dim lista As New List(Of CbteTributo)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM CbteTributo WHERE CbteId = @Id"
                        .Parameters.AddWithValue("@Id", Id)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New CbteTributo
                                    obj = PopulateTributo(reader)
                                    lista.Add(obj)
                                    obj = Nothing
                                Loop
                                Return lista
                            End Using
                        Finally
                            lista = Nothing
                        End Try
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cbtecabecera", _
            "GetTributos", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetArticulos(ByVal Id As UInt32) As List(Of CbteArticulo)
        Try
            Dim lista As New List(Of CbteArticulo)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT CbteArticulo.*,u.`simbolo` SimboloUnidad FROM CbteArticulo "
                        .CommandText &= "LEFT JOIN `unidad` u ON CbteArticulo.`unidad`=u.`codigo` "
                        .CommandText &= "WHERE CbteId = @Id"
                        .Parameters.AddWithValue("@Id", Id)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New CbteArticulo
                                    obj = PopulateArticulo(reader)
                                    lista.Add(obj)
                                    obj = Nothing
                                Loop
                                Return lista
                            End Using
                        Finally
                            lista = Nothing
                        End Try
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cbtecabecera", _
            "GetArticulos", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetByRemitoId(ByVal id As UInt32) As Remito
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM remito WHERE idRemito= @Id"
                        .Parameters.AddWithValue("@Id", id)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Dim obj As New Remito
                                obj = PopulateRemito(reader)
                                Return obj
                            Else
                                Return Nothing
                            End If
                        End Using
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Remito", _
            "GetById", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetCbtesAsociados(ByVal Id As UInt32) As List(Of CbteAsociado)
        Try
            Dim lista As New List(Of CbteAsociado)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM CbteAsociado WHERE CbteId = @Id"
                        .Parameters.AddWithValue("@Id", Id)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New CbteAsociado
                                    obj = PopulateCbteAsociado(reader)
                                    lista.Add(obj)
                                    obj = Nothing
                                Loop
                                Return lista
                            End Using
                        Finally
                            lista = Nothing
                        End Try
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cbtecabecera", _
            "GetCbtesAsociados", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetEstadoCuenta(ByVal Id As UInt32) As List(Of CbteAsociado)
        Try
            Dim lista As New List(Of CbteAsociado)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT cbteasociado.cbteid, cbteasociado.CbteReferencia,cbtecabecera.CbteNumero Numero,cbtecabecera.CbtePtoVta PtoVta,cbtecabecera.CbteTipo Tipo, "
                        .CommandText &= "IF(cbtecabecera.tipo='C',cbteasociado.importe*-1,cbteasociado.importe) Importe, "
                        .CommandText &= "cbtecabecera.Denominacion,cbtecabecera.Letra,CAST(cbtecabecera.CbteFecha AS DATE) Fecha "
                        .CommandText &= "FROM(CbteAsociado, CbteCabecera) "
                        .CommandText &= "WHERE(CbteAsociado.cbteid = CbteCabecera.Id) "
                        .CommandText &= "AND CbteReferencia=@Id "
                        .Parameters.AddWithValue("@Id", Id)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New CbteAsociado
                                    obj = PopulateCbteAsociado(reader)
                                    lista.Add(obj)
                                    obj = Nothing
                                Loop
                                Return lista
                            End Using
                        Finally
                            lista = Nothing
                        End Try
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cbtecabecera", _
            "GetEstadoDeCuenta", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Private Function Populate(ByVal reader As MySqlDataReader, Optional ByVal cargaCtaCte As Boolean = True, _
                              Optional ByVal cargaAlicuotas As Boolean = True, _
                              Optional ByVal cargaArticulos As Boolean = True, _
                              Optional ByVal cargaFinanciero As Boolean = True, _
                              Optional ByVal cargaTributos As Boolean = True, _
                              Optional ByVal cargaAsociados As Boolean = True) As CbteCabecera

        Dim obj As New CbteCabecera
        Try
            With obj
                .Id = Convert.ToUInt32(reader("Id"))
                .Concepto = Convert.ToInt32(reader("Concepto"))
                .Clienteid = Convert.ToUInt32(reader("Clienteid"))
                .Razonsocial = Convert.ToString(reader("Razonsocial"))
                .Domicilio = Convert.ToString(reader("Domicilio"))
                .Nroremito = Convert.ToString(reader("Nroremito"))
                .Documentotipo = Convert.ToInt32(reader("Documentotipo"))
                .Documentonro = Convert.ToUInt64(reader("Documentonro"))
                .Cbtetipo = Convert.ToInt32(reader("Cbtetipo"))
                .Cbteptovta = Convert.ToInt32(reader("Cbteptovta"))
                .Cbtenumero = Convert.ToUInt32(reader("Cbtenumero"))
                .Cbtefecha = Convert.ToString(reader("Cbtefecha"))
                .Formadepago = Convert.ToUInt32(reader("Formadepago"))
                .Importetotal = Convert.ToDouble(reader("Importetotal"))
                .Importetotalconceptos = Convert.ToDouble(reader("Importetotalconceptos"))
                .Importeneto = Convert.ToDouble(reader("Importeneto"))
                .Importeopexentas = Convert.ToDouble(reader("Importeopexentas"))
                .Importeiva = Convert.ToDouble(reader("Importeiva"))
                .Importetributos = Convert.ToDouble(reader("Importetributos"))
                .Fechaserviciodesde = Convert.ToString(reader("Fechaserviciodesde"))
                .Fechaserviciohasta = Convert.ToString(reader("Fechaserviciohasta"))
                .Fechavtopago = Convert.ToString(reader("Fechavtopago"))
                .Monedaid = Convert.ToString(reader("Monedaid"))
                .Monedactz = Convert.ToDouble(reader("Monedactz"))
                .Cae = Convert.ToString(reader("Cae"))
                .Fechavtocae = Convert.ToString(reader("Fechavtocae"))
                .Observaciones = Convert.ToString(reader("Observaciones"))
                .ObservacionesExtra = Convert.ToString(reader("ObservacionesExtra"))
                .Tiporesponsable = Convert.ToUInt32(reader("Tiporesponsable"))
                .Cuitemisor = Convert.ToUInt64(reader("Cuitemisor"))
                .Usuario = Convert.ToUInt32(reader("Usuario"))
                '.Fechatransaccion = Convert.ToDateTime(reader("Fechatransaccion"))
                .Vendedor = Convert.ToUInt32(reader("Vendedor"))
                .Sucursal = Convert.ToUInt32(reader("Sucursal"))
                .Descuento = Convert.ToDouble(reader("Descuento"))
                .Letra = Convert.ToChar(reader("Letra"))
                .Denominacion = Convert.ToString(reader("Denominacion"))
                .Tipo = Convert.ToChar(reader("Tipo"))
                .IdCbteFc = Convert.ToUInt32(reader("IdCbteFc"))

                .Importectaspropias = Convert.ToDouble(reader("Importectaspropias"))
                .Importecartera = Convert.ToDouble(reader("Importecartera"))

                If cargaAlicuotas Then .CbteAlicuotas = GetAlicuotas(.Id)
                If cargaArticulos Then .CbteArticulos = GetArticulos(.Id)
                If cargaTributos Then .CbteTributos = GetTributos(.Id)
                If cargaAsociados Then .CbteAsociados = GetCbtesAsociados(.Id)
                If cargaCtaCte Then .CbteEstadoCuenta = GetEstadoCuenta(.Id)
                If cargaFinanciero Then .CbteDetalleFinanciero = GetCbteDetalleFinanciero(.Id)

            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function

    Private Function PopulateAlicuota(ByVal reader As MySqlDataReader) As CbteAlicuota
        Dim obj As New CbteAlicuota
        Try
            With obj
                .Id = Convert.ToUInt32(reader("Id"))
                '.CbteId = Convert.ToUInt32(reader("Id"))
                .Codigo = Convert.ToString(reader("Codigo"))
                .Descripcion = Convert.ToString(reader("Descripcion"))
                .Importe = Convert.ToDouble(reader("Importe"))
                .Alicuota = Convert.ToDouble(reader("Alicuota"))
                .BaseImponible = Convert.ToDouble(reader("BaseImponible"))
            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function

    Private Function PopulateTributo(ByVal reader As MySqlDataReader) As CbteTributo
        Dim obj As New CbteTributo
        Try
            With obj
                .Id = Convert.ToUInt32(reader("Id"))
                '.CbteId = Convert.ToUInt32(reader("Id"))
                .Codigo = Convert.ToString(reader("Codigo"))
                .Referencia = Convert.ToString(reader("Referencia"))
                .Descripcion = Convert.ToString(reader("Descripcion"))
                .Importe = Convert.ToDouble(reader("Importe"))
                .Alicuota = Convert.ToDouble(reader("Alicuota"))
                .BaseImponible = Convert.ToDouble(reader("BaseImponible"))
            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function

    Private Function PopulateArticulo(ByVal reader As MySqlDataReader) As CbteArticulo
        Dim obj As New CbteArticulo
        Try
            With obj
                .Id = Convert.ToUInt32(reader("Id"))
                '.CbteId = Convert.ToUInt32(reader("Id"))
                '.Rev = Convert.ToString(reader("Rev"))
                .Codigo = Convert.ToString(reader("Codigo"))
                .Codcliente = Convert.ToString(reader("codcliente"))
                .Descripcion = Convert.ToString(reader("Descripcion"))
                .Cantidad = Convert.ToDouble(reader("Cantidad"))
                .Importe = Convert.ToDouble(reader("Importe"))
                .ImpIntTasaNominal = Convert.ToDouble(reader("ImpIntTasaNominal"))
                .ImpInterno = Convert.ToDouble(reader("ImpInterno"))
                .Alicuota = Convert.ToDouble(reader("Alicuota"))
                .AlicuotaCodigo = Convert.ToInt32(reader("AlicuotaCodigo"))
                .Unidad = Convert.ToString(reader("Unidad"))
                .SimboloUnidad = Convert.ToString(reader("SimboloUnidad"))
                .Kgs = Convert.ToDouble(reader("Kgs"))
                If .Kgs > 0 And .Cantidad > 0 Then
                    .Kgsxunidad = Math.Round(.Kgs / .Cantidad, 0)
                Else
                    .Kgsxunidad = 1
                End If
                .Numero = Convert.ToUInt64(reader("numero"))
                '.Secuencia = Convert.ToUInt16(reader("secuencia"))

            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function

    Private Function PopulateCbteAsociado(ByVal reader As MySqlDataReader) As CbteAsociado
        Dim obj As New CbteAsociado
        Try
            With obj
                .Id = Convert.ToUInt32(reader("CbteId"))
                '.CbteId = Convert.ToUInt32(reader("Id"))
                .Numero = Convert.ToInt64(reader("Numero"))
                .PtoVta = Convert.ToInt32(reader("PtoVta"))
                .Importe = Convert.ToDouble(reader("Importe"))
                .Tipo = Convert.ToInt32(reader("Tipo"))
                .CbteReferencia = Convert.ToUInt32(reader("CbteReferencia"))
            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function

    Public Function GetRemitosCliente(ByVal cliente As UInt32, Optional ByVal vertodos As Boolean = False, Optional ByVal ordenDescendete As Boolean = False) As List(Of CbteCabecera)
        Try
            Dim lista As New List(Of CbteCabecera)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Cbtecabecera WHERE ClienteId = @cliente AND cbtetipo IN (@tipo) "

                        If Not vertodos Then
                            '.CommandText &= " AND NroRemito='' "
                            .CommandText &= " AND IdCbteFc=0 "
                        End If

                        If ordenDescendete Then
                            .CommandText &= " ORDER BY id DESC"
                        End If

                        .Parameters.AddWithValue("@cliente", cliente)
                        .Parameters.AddWithValue("@tipo", REMITO)

                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New CbteCabecera
                                    obj = Populate(reader)
                                    lista.Add(obj)
                                    obj = Nothing
                                Loop
                                Return lista
                            End Using
                        Finally
                            lista = Nothing
                        End Try
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cbtecabecera", _
            "GetRemitosCliente", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function Anular(ByVal obj As CbteCabecera) As UInt32

        Dim id As Long
        Dim transaccion As MySqlTransaction = Nothing
        Dim cnn As MySqlConnection = Nothing
        Dim cmd As MySqlCommand

        Try

            cnn = CreateConnection()
            cnn.Open()
            transaccion = cnn.BeginTransaction
            cmd = New MySqlCommand

            With cmd
                .Connection = cnn
                .Transaction = transaccion
                .CommandType = CommandType.Text

                'elimino las alicuotas
                .CommandText = "DELETE FROM Cbtealicuota WHERE Cbteid=@id"
                .Parameters.Clear()
                .Parameters.AddWithValue("@id", obj.Id)
                .ExecuteNonQuery()

                'elimino los comprobantes asociados
                .CommandText = "DELETE FROM Cbteasociado WHERE Cbteid=@id"
                .Parameters.Clear()
                .Parameters.AddWithValue("@id", obj.Id)
                .ExecuteNonQuery()

                'elimino los tributos del combrobante
                .CommandText = "DELETE FROM Cbtetributo WHERE Cbteid=@id"
                .Parameters.Clear()
                .Parameters.AddWithValue("@id", obj.Id)
                .ExecuteNonQuery()

                'elimino los articulos del combrobante
                .CommandText = "DELETE FROM Cbtearticulo WHERE Cbteid=@id"
                .Parameters.Clear()
                .Parameters.AddWithValue("@id", obj.Id)
                .ExecuteNonQuery()

                'elimino los articulos de la ficha de stock
                .CommandText = "DELETE FROM Fichastock WHERE CbteVta=@id"
                .Parameters.Clear()
                .Parameters.AddWithValue("@id", obj.Id)
                .ExecuteNonQuery()

                'ojo! si proviene de un pago, los cheques solo deben cambiar su estado y no generar un nuevo registro
                For Each objFinanciero As Entidades.Financiero In obj.CbteDetalleFinanciero

                    .Parameters.Clear()
                    'CUENTA_CARTERA As String = "CARTERA"
                    'CONCEPTO_CHEQUE_RECIBIDO As String = "013"
                    'CONCEPTO_CHEQUE_PASADO As String = "014"
                    'CONCEPTO_CHEQUE_DEPOSITADO As String = "015"

                    'valido los comprobantes de financiero
                    If objFinanciero.Cuenta = CUENTA_CARTERA Then

                        Select Case objFinanciero.Concepto
                            Case CONCEPTO_CHEQUE_PASADO 'vuelvo el cheque pasado a su estado anterior
                                Throw New Exception("El comprobante posee cheques que ya han sido pasados. Debe anular el pago correspondiente")
                            Case CONCEPTO_CHEQUE_DEPOSITADO
                                Throw New Exception("El comprobante posee cheques que ya han sido depositados. Debe anular el deposito correspondiente")
                            Case Else
                                .CommandText = "DELETE FROM Financiero WHERE id=@id"
                                .Parameters.AddWithValue("@id", objFinanciero.Id)
                        End Select

                    Else 'para las otras cuentas, elimino los movimientos

                        .CommandText = "DELETE FROM Financiero WHERE id=@id"
                        .Parameters.AddWithValue("@id", objFinanciero.Id)

                    End If

                    .ExecuteNonQuery()

                Next

                'elimino la cabecera al final por la integridad referencia
                .CommandText = "DELETE FROM CbteCabecera WHERE id=@id"
                .Parameters.Clear()
                .Parameters.AddWithValue("@id", obj.Id)
                .ExecuteNonQuery()

            End With

            transaccion.Commit()

            Return id

        Catch exError As MySqlException

            If transaccion IsNot Nothing Then
                transaccion.Rollback()
            End If

            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:CbteCabecera", _
            "Anular", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)

        Finally
            If cnn IsNot Nothing Then
                If cnn.State = ConnectionState.Open Then
                    cnn.Close()
                End If
            End If
        End Try
    End Function

    Public Function GetCbteDetalleFinanciero(ByVal id As UInt32) As List(Of Financiero)
        Try
            Dim lista As New List(Of Financiero)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        '.CommandText = "SELECT Financiero.* FROM Financiero WHERE cuenta = @cuenta"
                        .CommandText = "SELECT Financiero.*,IFNULL(`cbtecabecera`.`CbteTipo`,0) CptoVta,IFNULL(`cpracabecera`.`CbteTipo`,0) CptoCpra FROM Financiero LEFT JOIN `cbtecabecera` ON financiero.`CbteVta` = `cbtecabecera`.id"
                        .CommandText &= " LEFT JOIN `cpracabecera` ON financiero.`CbteCpra` = `cpracabecera`.id  WHERE CbteVta = @id"

                        .Parameters.AddWithValue("@id", id)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New Financiero
                                    obj = PopulateFinanciero(reader)
                                    lista.Add(obj)
                                    obj = Nothing
                                Loop
                                Return lista
                            End Using
                        Finally
                            lista = Nothing
                        End Try
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Financiero", _
            "GetCbteDetalleFinanciero", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Private Function PopulateFinanciero(ByVal reader As MySqlDataReader) As Financiero
        Dim obj As New Financiero
        Try
            With obj
                .Id = Convert.ToUInt32(reader("Id"))
                .Origen = Convert.ToString(reader("Origen"))
                .Cuenta = Convert.ToString(reader("Cuenta"))
                .Concepto = Convert.ToString(reader("Concepto"))
                .Beneficiario = Convert.ToString(reader("Beneficiario"))
                .Emision = Convert.ToDateTime(reader("Emision"))

                If Not IsDBNull(reader("Egreso")) Then
                    .Egreso = Convert.ToDateTime(reader("Egreso"))
                End If

                .Efectivizacion = Convert.ToDateTime(reader("Efectivizacion"))
                .Importe = Convert.ToDouble(reader("Importe"))
                .Referencia = Convert.ToString(reader("Referencia"))
                .Observacion = Convert.ToString(reader("Observacion"))
                .Usuario = Convert.ToUInt32(reader("Usuario"))
                .Fecharegistracion = Convert.ToDateTime(reader("Fecharegistracion"))
                .Banco = Convert.ToUInt32(reader("Banco"))

                If Not IsDBNull(reader("Cbtevta")) Then
                    .Cbtevta = Convert.ToUInt32(reader("Cbtevta"))
                End If

                If Not IsDBNull(reader("Cbtecpra")) Then
                    .Cbtecpra = Convert.ToUInt32(reader("Cbtecpra"))
                End If

                'If Not IsDBNull(reader("Cbterecibo")) Then
                '    .Cbterecibo = Convert.ToUInt32(reader("Cbterecibo"))
                'End If

                'If Not IsDBNull(reader("Cbtepago")) Then
                '    .Cbtepago = Convert.ToUInt32(reader("Cbtepago"))
                'End If

                If Not IsDBNull(reader("Localidad")) Then
                    .Localidad = Convert.ToUInt32(reader("Localidad"))
                End If

                .Tipo = Convert.ToString(reader("Tipo"))
                .Dador = Convert.ToString(reader("Dador"))
                .Sucursal = Convert.ToUInt32(reader("Sucursal"))

                If Not IsDBNull(reader("DocumentoNro")) Then
                    .DocumentoNro = Convert.ToString(reader("DocumentoNro"))
                End If

                .Deposito = Convert.ToUInt32(reader("Deposito"))

                If Not IsDBNull(reader("CptoVta")) Then
                    .CptoVta = Convert.ToUInt32(reader("CptoVta"))
                End If

                If Not IsDBNull(reader("CptoCpra")) Then
                    .CptoCpra = Convert.ToUInt32(reader("CptoCpra"))
                End If

            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function

    Public Function DesaplicarRecibo(ByVal obj As CbteCabecera) As UInt32

        Dim id As Long
        Dim transaccion As MySqlTransaction = Nothing
        Dim cnn As MySqlConnection = Nothing
        Dim cmd As MySqlCommand

        Try

            cnn = CreateConnection()
            cnn.Open()
            transaccion = cnn.BeginTransaction
            cmd = New MySqlCommand

            With cmd
                .Connection = cnn
                .Transaction = transaccion
                .CommandType = CommandType.Text

                'elimino los comprobantes asociados
                .CommandText = "DELETE FROM Cbteasociado WHERE Cbteid=@id"
                .Parameters.Clear()
                .Parameters.AddWithValue("@id", obj.Id)
                .ExecuteNonQuery()

            End With

            transaccion.Commit()

            Return id

        Catch exError As MySqlException

            If transaccion IsNot Nothing Then
                transaccion.Rollback()
            End If

            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:CbteCabecera", _
            "Desaplicar Recibo", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)

        Finally
            If cnn IsNot Nothing Then
                If cnn.State = ConnectionState.Open Then
                    cnn.Close()
                End If
            End If
        End Try
    End Function
    Private Function PopulateRemito(ByVal reader As MySqlDataReader) As Remito
        Dim obj As New Remito
        Try
            With obj
                .Id = Convert.ToUInt32(reader("Id"))
                .Idremito = Convert.ToUInt32(reader("Idremito"))
                .Fecha = Convert.ToDateTime(reader("Fecha"))
                .Clientenombre = Convert.ToString(reader("Clientenombre"))
                .Clientedomicilio = Convert.ToString(reader("Clientedomicilio"))
                .Clientecodpostal = Convert.ToString(reader("Clientecodpostal"))
                .Clientelocalidad = Convert.ToString(reader("Clientelocalidad"))
                .Clienteiva = Convert.ToString(reader("Clienteiva"))
                .Clientecuit = Convert.ToString(reader("Clientecuit"))
                .Ordencompra = Convert.ToString(reader("Ordencompra"))
                .Unidad = Convert.ToString(reader("Unidad"))
                .Kgs = Convert.ToString(reader("Kgs"))
                .Bultos = Convert.ToString(reader("Bultos"))
                .Valordeclarado = Convert.ToString(reader("Valordeclarado"))
                .Tipoenvio = Convert.ToString(reader("Tipoenvio"))
                .Transportenombre = Convert.ToString(reader("Transportenombre"))
                .Transportedireccion = Convert.ToString(reader("Transportedireccion"))
                .Transportecuit = Convert.ToString(reader("Transportecuit"))
                .Lugarentrega = Convert.ToString(reader("Lugarentrega"))
                .Control = Convert.ToString(reader("Control"))
            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function

End Class

