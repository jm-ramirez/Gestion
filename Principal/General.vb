Imports System.Text

Public Module General

    Const TRIBUTO_PERC_RET_IIBB As String = "Per./Ret. de Ingresos Brutos"
    Const TRIBUTO_PERC_RET_GCIAS As String = "Per./Ret. de Impuesto a las Ganancias"
    Const TRIBUTO_PERC_RET_IVA As String = "Per./Ret. de IVA"
    Const TRIBUTO_IMPUESTOS_INTERNOS As String = "Impuestos Internos"
    Const TRIBUTO_IMPUESTOS_MUNICIPALES As String = "Impuestos Municipales"

    Const AFIP_COD_IMPUESTO_NACIONAL As Long = 1
    Const AFIP_COD_IMPUESTO_PROVINCIAL As Long = 2
    Const AFIP_COD_IMPUESTO_MUNICIPAL As Long = 3
    Const AFIP_COD_IMPUESTO_INTERNO As Long = 4
    Const AFIP_COD_IMPUESTO_OTROS As Long = 99

    Public gUsuario As Entidades.Personal = Nothing
    Public gEmpresa As Entidades.Empresa = Nothing

    Public Const ORIGEN_FINANCIERO_MOVIM As String = "MOVIM"
    Public Const ORIGEN_FINANCIERO_VENTA As String = "VENTA"
    Public Const ORIGEN_FINANCIERO_COMPRA As String = "COMPRA"
    Public Const ORIGEN_FINANCIERO_COBRANZA As String = "COBRO"
    Public Const ORIGEN_FINANCIERO_PAGO As String = "PAGO"

    Public Const PERFIL_PREDETERMINADO As UInt16 = 1
    Public Const PERFIL_MOSTRADOR As UInt16 = 2

    Public Const CONCEPTO_DEUDOR As String = "D"
    Public Const CONCEPTO_ACREEDOR As String = "C"

    Public Const ARTICULO_VARIOS As String = "999999999999999"

    Public Const FACTURA_A As UInt32 = 1
    Public Const FACTURA_B As UInt32 = 6
    Public Const FACTURA_C As UInt32 = 11
    Public Const FACTURA_M As UInt32 = 51
    Public Const NOTA_DEBITO_A As UInt32 = 2
    Public Const NOTA_DEBITO_B As UInt32 = 7
    Public Const NOTA_DEBITO_C As UInt32 = 12
    Public Const TIQUE_FACTURA_A As UInt32 = 81
    Public Const TIQUE_FACTURA_B As UInt32 = 82
    Public Const TIQUE_FACTURA_C As UInt32 = 111
    Public Const TIQUE_NOTA_CREDITO As UInt32 = 110
    Public Const TIQUE_NOTA_CREDITO_A As UInt32 = 112
    Public Const TIQUE_NOTA_CREDITO_B As UInt32 = 113
    Public Const TIQUE As UInt32 = 83
    Public Const NOTA_CREDITO_A As UInt32 = 3
    Public Const NOTA_CREDITO_B As UInt32 = 8
    Public Const NOTA_CREDITO_C As UInt32 = 13
    Public Const PRESUPUESTO As UInt32 = 991
    Public Const DEVOLUCION_PRESUPUESTO As UInt32 = 992
    Public Const RECIBO_COBRANZA As UInt32 = 993
    Public Const ORDEN_PAGO As UInt32 = 994
    Public Const RECIBO_PRESUPUESTO As UInt32 = 995
    Public Const PAGO_PRESUPUESTO As UInt32 = 996
    Public Const REMITO As UInt32 = 91

    Public Const COMPROBANTE_X As UInt32 = 800
    Public Const NOTA_DEBITO_X As UInt32 = 801
    Public Const NOTA_CREDITO_X As UInt32 = 802
    Public Const RECIBO_DE_COBRANZA_X As UInt32 = 803
    Public Const ORDEN_DE_PAGO_X As UInt32 = 804

    Public Const IVA_0 As UInt32 = 3 '0%
    Public Const IVA_105 As UInt32 = 4 '10.5%
    Public Const IVA_21 As UInt32 = 5 '21%
    Public Const IVA_27 As UInt32 = 6 '27%
    Public Const IVA_5 As UInt32 = 8 '5%
    Public Const IVA_25 As UInt32 = 9 '2.5%                                

    Public Const CUENTA_CARTERA As String = "CARTERA"
    Public Const CONCEPTO_CHEQUE_RECIBIDO As String = "013"
    Public Const CONCEPTO_CHEQUE_PASADO As String = "014"
    Public Const CONCEPTO_CHEQUE_DEPOSITADO As String = "015"
    Public Const CONCEPTO_CHEQUE_RECHAZADO As String = "017"

    Public Const CH_CARTERA As String = "EN CARTERA"
    Public Const CH_DEPOSITADO As String = "DEPOSITADO"
    Public Const CH_PASADO As String = "PASADO"
    Public Const CH_RECHAZADO As String = "RECHAZADO"

    Public Const DOCUMENTO_CUIT As UInt32 = 80
    Public Const DOCUMENTO_DNI As UInt32 = 96
    Public Const DOCUMENTO_SIN As UInt32 = 99

    Enum TiposImportes
        NETO_GRAVADO = 0
        IVA = 1
        EXENTO = 2
        NO_GRAVADO = 3
        TRIBUTO = 4
        TOTAL = 5
        NO_INSCRIPTO = 6
    End Enum

    Enum ReporteCtaCte
        SALDOS = 0
        EDOCTA = 1
        EDOREF = 2
        PENDIENTES = 3
        ANTICIPOS = 4
        VENCIMIENTO = 5
    End Enum

    Enum DesignFile
        IIBB = 0
        SICORE = 1
    End Enum

    Enum ReporteStock
        EXISTENCIAS = 0
        FICHA_STOCK = 1
        FALTANTES = 2
        INVENTARIO = 3
    End Enum

    Enum ReporteDiario
        IVAVENTAS = 0
        IVACOMPRAS = 1
        COBRANZAS = 2
        PAGOS = 3
        VENDEDOR = 4
        VENDEDOR_TOTAL = 5
        VENTAS_ARTICULOS_VENDEDOR = 6
        COMPRAS_ARTICULOS_PROVEEDOR = 7
        VENTAS_ZONAS = 8
        VENTAS_RUBROS = 9
        VENTAS_CATEGORIAS = 10
        REMITOS = 11
    End Enum

    Enum TipoEmisionCbte
        ELECTRONICO = 0
        FISCAL = 1
        PREIMPRESO = 2
        PRESUPUESTO = 3
        RECIBO = 4
        RECIBO_PRESUPUESTO = 5
        ORDEN_DE_PAGO = 6
        PAGO_PRESUPUESTO = 7
        COMPRA = 8
        DEPOSITO_CARTERA = 9
        AJUSTE_DEUDOR = 10
        AJUSTE_ACREEDOR = 11
        NO_FISCAL = 12
        RECIBO_NO_FISCAL = 13
        PAGO_NO_FISCAL = 14
    End Enum

    Enum UtilidadFiscal
        CIERRE_Z = 0
        CIERRE_X = 1
        AUDITORIA = 2
    End Enum

    Enum PermisoUsuario
        TOPE_DESCUENTO = 0
        EMITE_NOTA_CREDITO = 1
    End Enum

    Enum Listados
        CONCEPTOS_FINANCIEROS = 0
        CUENTAS_FINANCIEROS = 1
        RUBROS_GCIAS = 2
        FORMAS_PAGOS = 3
        RUBROS_ART = 4
        RUBROS_MAESTRO_ART = 5
        MATERIALES_ART = 6
        CATEGORIAS_ART = 7
        BANCOS = 8
        PROVINCIAS = 9
        MATERIALES_CPRA = 10
        GASTOS_VARIABLES = 11
        GASTOS_FIJOS = 12
        CODIGOS_IMPUTACION = 13
        RUBROS_MATERIALES = 14
        ZONAS = 15
        CODIGOS_IMPUTACION_EGRESO = 16
        VENDEDORES = 17
        TRANSPORTES = 18
        PROVEEDORES = 19
        CLIENTES = 20
    End Enum

    Public Function ParseStringToDate(ByVal dateString As String) As Date
        Dim format As String
        Dim result As Date
        Dim provider As Globalization.CultureInfo = Globalization.CultureInfo.InvariantCulture

        format = "yyyyMMdd"

        Try
            result = Date.ParseExact(dateString, format, provider).Date
            Return result
        Catch e As FormatException
            MessageBox.Show(e.Message, "ParseStringToDate", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

    Public Function VerificaCuit(ByVal cuit As String) As Boolean

        Dim ret As Boolean = False
        Dim coeficiente(10) As Integer
        Dim i, sumador, veri_nro, Resultado, verificador As Integer
        Dim cuit_rearmado As String

        Try

            coeficiente(1) = 5
            coeficiente(2) = 4
            coeficiente(3) = 3
            coeficiente(4) = 2
            coeficiente(5) = 7
            coeficiente(6) = 6
            coeficiente(7) = 5
            coeficiente(8) = 4
            coeficiente(9) = 3
            coeficiente(10) = 2
            cuit = Trim(cuit)
            cuit_rearmado = ""

            For i = 1 To cuit.Length  'separo cualquier caracter que no tenga que ver con numero
                If Asc(Mid(cuit, i, 1)) >= 48 And Asc(Mid(cuit, i, 1)) <= 57 Then
                    cuit_rearmado &= Mid(cuit, i, 1)
                End If
            Next

            cuit_rearmado = Trim(cuit_rearmado)

            If cuit_rearmado.Length <> 11 Then
                Return False
            Else
                sumador = 0
                verificador = Val(Mid(cuit_rearmado, 11, 1)) 'tomo el digito verificador

                For i = 1 To 10
                    sumador = sumador + Val(Mid(cuit_rearmado, i, 1)) * coeficiente(i)
                    'separo cada digito y lo multiplico por el coeficiente
                Next

                Resultado = sumador Mod 11
                Resultado = 11 - Resultado  'saco el digito verificador

                If (Resultado = 11) Then Resultado = 0
                If (Resultado = 10) Then Resultado = 9

                veri_nro = Val(verificador)
                If veri_nro <> Resultado Then
                    Return False
                End If
            End If

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "VerificaCuit", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Public Function a_DetalleConcepto(ByVal pConcepto As String) As String

        a_DetalleConcepto = pConcepto

    End Function

    Public Sub EmisionCbteOrdenCompra(ByVal id As UInt32, Optional ByVal preview As Boolean = False, Optional ByVal copies As Short = -1)
        Try
            Dim repositorio As New CapaLogica.OrdencompracabCLog
            Dim r As New GeneradorReportes.Reporte
            Dim cbte As New Entidades.OrdenCompracab

            cbte = repositorio.GetById(id)

            If cbte Is Nothing Then
                Throw New Exception("El id de cbte solicitado no existe. ID " & id.ToString)
            End If

            r.Nombre = "Orden de Compra (Clientes)"

            r.SourceFile = My.Settings.RutaReportes & "\infCargaCompra.rdl"

            SetearEncabezadosReporte(r)

            'parametros
            With cbte
                r.Parametros.Add(New GeneradorReportes.Parametro("titulo", "Orden de Compra (Clientes)"))
                r.Parametros.Add(New GeneradorReportes.Parametro("fecha", Format(.Fecha, "dd/MM/yyyy")))
                r.Parametros.Add(New GeneradorReportes.Parametro("NroCbte", Format(CInt(.Numero), "00000000"))) ' & "-" & Format(CInt(.Secuencia), "00")))
                r.Parametros.Add(New GeneradorReportes.Parametro("clienteNombre", .NombreCliente))
                r.Parametros.Add(New GeneradorReportes.Parametro("clienteDomicilio", DirectCast(cbte, Entidades.OrdenCompracab).DomicilioCliente))
                r.Parametros.Add(New GeneradorReportes.Parametro("clienteCodpostal", DirectCast(cbte, Entidades.OrdenCompracab).CodpostalCliente))
                r.Parametros.Add(New GeneradorReportes.Parametro("clienteLocalidad", DirectCast(cbte, Entidades.OrdenCompracab).LocalidadCliente))
                r.Parametros.Add(New GeneradorReportes.Parametro("clienteTelefono", DirectCast(cbte, Entidades.OrdenCompracab).TelefonoCliente))
                r.Parametros.Add(New GeneradorReportes.Parametro("clienteCuit", DirectCast(cbte, Entidades.OrdenCompracab).CuitCliente))
                r.Parametros.Add(New GeneradorReportes.Parametro("cbteId", .Id))
                r.Parametros.Add(New GeneradorReportes.Parametro("observaciones", .Observacion))
            End With


            If preview Then
                r.ShowReport()
            Else
                If copies > 0 Then
                    r.PrintReport(copies)
                End If

            End If


            'Me.Close()

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Orden de Compra (Clientes)", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Private Sub Reporte(Optional ByVal copies As Short = -1)

    '    Try

    '        Dim r As New GeneradorReportes.Reporte

    '        r.Nombre = Me.Text

    '        r.SourceFile = My.Settings.RutaReportes & "\infCargaCompra.rdl"

    '        SetearEncabezadosReporte(r)

    '        r.Parametros.Add(New GeneradorReportes.Parametro("titulo", Me.Text))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("fecha", Format(Me.DTPFecha.Value, "dd/MM/yyyy")))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("NroCbte", Format(CInt(Me.TextBoxNumero.Text), "00000000") & "-" & Format(CInt(Me.TextBoxSecuencia.Text), "00")))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("clienteNombre", Me.TextBoxNombre.Text))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("clienteDomicilio", Me.TextBoxDomicilio.Text))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("clienteCodpostal", DirectCast(ComboBoxCliente.SelectedItem, Entidades.Cliente).CodigoPostal))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("clienteLocalidad", DirectCast(ComboBoxCliente.SelectedItem, Entidades.Cliente).NombreLocalidad))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("clienteTelefono", Me.TextBoxTelefono.Text))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("clienteCuit", Me.TextBoxDocumento.Text))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("cbteId", Entidad.Id))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("observaciones", Me.TextBoxObservacion.Text))

    '        r.PrintReport(copies)

    '        Me.Close()

    '    Catch ex As Exception
    '        MessageBox.Show("Se produjo el siguiente error: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub

    Public Sub EmisionCbteRemito(ByVal id As UInt32, Optional ByVal copies As Short = -1, Optional ByVal preview As Boolean = False)
        Dim cbteRemito As New Entidades.Remito
        Dim repositorio As New CapaLogica.CbtecabeceraCLog

        Try

            Dim r As New GeneradorReportes.Reporte

            r.Nombre = "Remito"

            r.SourceFile = My.Settings.RutaReportes & "\infRemito.rdl"

            cbteRemito = repositorio.GetByRemitoId(id)

            If cbteRemito Is Nothing Then
                Throw New Exception("El id de cbte (IMPRESION REMITO) solicitado no existe. ID" & id.ToString)
            End If

            'parametros
            With cbteRemito

                r.Parametros.Add(New GeneradorReportes.Parametro("fecha", Format(.Fecha, "dd/MM/yyyy")))
                r.Parametros.Add(New GeneradorReportes.Parametro("cbteId", id))
                r.Parametros.Add(New GeneradorReportes.Parametro("clienteNombre", .Clientenombre))
                r.Parametros.Add(New GeneradorReportes.Parametro("clienteDomicilio", .Clientedomicilio))
                r.Parametros.Add(New GeneradorReportes.Parametro("clienteCodpostal", .Clientecodpostal))
                r.Parametros.Add(New GeneradorReportes.Parametro("clienteLocalidad", .Clientelocalidad))
                r.Parametros.Add(New GeneradorReportes.Parametro("clienteIva", .Clienteiva))
                r.Parametros.Add(New GeneradorReportes.Parametro("clienteCuit", .Clientecuit))
                r.Parametros.Add(New GeneradorReportes.Parametro("OrdenCompra", .Ordencompra))
                r.Parametros.Add(New GeneradorReportes.Parametro("xUnidad", .Unidad))
                r.Parametros.Add(New GeneradorReportes.Parametro("xKgs", .Kgs))
                r.Parametros.Add(New GeneradorReportes.Parametro("Bultos", .Bultos))
                r.Parametros.Add(New GeneradorReportes.Parametro("valorDeclarado", .Valordeclarado))
                r.Parametros.Add(New GeneradorReportes.Parametro("tipoEnvio", .Tipoenvio))
                r.Parametros.Add(New GeneradorReportes.Parametro("transporteNombre", .Transportenombre))
                r.Parametros.Add(New GeneradorReportes.Parametro("transporteDireccion", .Transportedireccion))
                r.Parametros.Add(New GeneradorReportes.Parametro("transporteCuit", .Transportecuit))
                r.Parametros.Add(New GeneradorReportes.Parametro("lugarEntrega", .Lugarentrega))
                r.Parametros.Add(New GeneradorReportes.Parametro("control", .Control))

            End With

            If preview Then
                r.ShowReport()
            Else
                r.PrintReport(copies)
            End If



        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Remito", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub EmisionCbte(ByVal id As UInt32, Optional ByVal preview As Boolean = False, Optional ByVal copies As Short = -1)
        Dim repositorio As New CapaLogica.CbtecabeceraCLog
        Dim repotipodto As New CapaLogica.TipodocumentoCLog
        Dim repoformapago As New CapaLogica.FormadepagoCLog
        Dim repotiporesp As New CapaLogica.TiporesponsableCLog
        Dim repoparametros As New CapaLogica.ParametroCLog
        Dim cbte As New Entidades.CbteCabecera
        Dim r As GeneradorReportes.Reporte
        Dim docTipo As String = ""
        Dim letra As String = ""
        Dim denominacion As String = ""
        Dim copias As Short = 0
        Dim plantilla As String = ""
        Dim saveAsPdf As Boolean = False

        Try

            cbte = repositorio.GetById(id)

            If cbte Is Nothing Then
                Throw New Exception("El id de cbte solicitado no existe. ID " & id.ToString)
            End If

            'parametros
            With cbte

                letra = .Letra
                denominacion = .Denominacion

                Select Case .Cbtetipo
                    Case FACTURA_A, FACTURA_B, PRESUPUESTO, NOTA_CREDITO_A, NOTA_CREDITO_B, NOTA_DEBITO_A, NOTA_DEBITO_B, DEVOLUCION_PRESUPUESTO
                        Select Case letra
                            Case "A"
                                plantilla = My.Settings.RutaReportes & "\cbtea.rdl"
                                copias = Convert.ToInt16(repoparametros.GetByNombre("CopiasCbtesElectronicosA").Valorpredeterminado)
                            Case "B"
                                plantilla = My.Settings.RutaReportes & "\cbteb.rdl"
                                copias = Convert.ToInt16(repoparametros.GetByNombre("CopiasCbtesElectronicosA").Valorpredeterminado)
                            Case Else
                                plantilla = My.Settings.RutaReportes & "\cbtex.rdl"
                                copias = Convert.ToInt16(repoparametros.GetByNombre("CopiasCbtesPresupuestos").Valorpredeterminado)
                        End Select
                    Case REMITO
                        'plantilla = My.Settings.RutaReportes & "\cbter.rdl"
                        plantilla = My.Settings.RutaReportes & "\infRemito.rdl"
                        copias = Convert.ToInt16(repoparametros.GetByNombre("CopiasCbtesRemitos").Valorpredeterminado)
                    Case RECIBO_COBRANZA
                        plantilla = My.Settings.RutaReportes & "\cbterecibo.rdl"
                        copias = Convert.ToInt16(repoparametros.GetByNombre("CopiasCbtesRecibos").Valorpredeterminado)
                    Case RECIBO_PRESUPUESTO
                        plantilla = My.Settings.RutaReportes & "\cbterecibopres.rdl"
                        copias = Convert.ToInt16(repoparametros.GetByNombre("CopiasCbtesRecibosPres").Valorpredeterminado)
                    Case ORDEN_PAGO
                        plantilla = My.Settings.RutaReportes & "\cbteordenpago.rdl"
                        copias = Convert.ToInt16(repoparametros.GetByNombre("CopiasCbtesOrdenPago").Valorpredeterminado)
                    Case PAGO_PRESUPUESTO
                        plantilla = My.Settings.RutaReportes & "\cbteordenpagopres.rdl"
                        copias = Convert.ToInt16(repoparametros.GetByNombre("CopiasCbtesOrdenPagoPres").Valorpredeterminado)
                    Case COMPROBANTE_X
                        plantilla = My.Settings.RutaReportes & "\cbtecomprobantenofiscal.rdl"
                        'copias = Convert.ToInt16(repoparametros.GetByNombre("CopiasCbtesNoFiscal").Valorpredeterminado)
                    Case Else
                        Throw New Exception("Tipo de cbte. no contemplado para la emisión")
                End Select

                If copies > 0 Then
                    copias = copies
                End If

                If preview Then
                    copias = 1
                Else
                    If copias = 0 Then
                        saveAsPdf = True
                        copias = 1
                    End If
                End If

                For copia As Integer = 1 To copias


                    r = New GeneradorReportes.Reporte

                    r.SourceFile = plantilla

                    r.Nombre = .Letra & .Cbtetipo.ToString & .Cbteptovta.ToString("0000") & "-" & .Cbtenumero.ToString("00000000")

                    'id para detalle
                    r.Parametros.Add(New GeneradorReportes.Parametro("cbteid", .Id))

                    'datos del emisor
                    r.Parametros.Add(New GeneradorReportes.Parametro("NombreFantasia", repoparametros.GetByNombre("NombreDeFantasiaEmisor").Valorpredeterminado))
                    r.Parametros.Add(New GeneradorReportes.Parametro("RazonSocialEmisor", repoparametros.GetByNombre("RazonSocialEmisor").Valorpredeterminado))
                    r.Parametros.Add(New GeneradorReportes.Parametro("Email", repoparametros.GetByNombre("EmailEmisor").Valorpredeterminado))
                    r.Parametros.Add(New GeneradorReportes.Parametro("DomicilioEmisor", repoparametros.GetByNombre("DomicilioComercialEmisor").Valorpredeterminado))
                    r.Parametros.Add(New GeneradorReportes.Parametro("CondicionIvaEmisor", repoparametros.GetByNombre("CondicionIvaEmisor").Valorpredeterminado))
                    r.Parametros.Add(New GeneradorReportes.Parametro("CuitEmisor", repoparametros.GetByNombre("CuitEmisor").Valorpredeterminado))
                    r.Parametros.Add(New GeneradorReportes.Parametro("IngresosBrutos", repoparametros.GetByNombre("IngresosBrutosEmisor").Valorpredeterminado))
                    r.Parametros.Add(New GeneradorReportes.Parametro("InicioActividades", repoparametros.GetByNombre("InicioActividadesEmisor").Valorpredeterminado))

                    'cabecera
                    r.Parametros.Add(New GeneradorReportes.Parametro("CbteNumero", .Cbtenumero))
                    r.Parametros.Add(New GeneradorReportes.Parametro("CbtePtoVta", .Cbteptovta))
                    r.Parametros.Add(New GeneradorReportes.Parametro("CbteFecha", ParseStringToDate(.Cbtefecha)))
                    r.Parametros.Add(New GeneradorReportes.Parametro("CbteTipo", .Cbtetipo))
                    r.Parametros.Add(New GeneradorReportes.Parametro("Letra", letra))
                    r.Parametros.Add(New GeneradorReportes.Parametro("Denominacion", denominacion))

                    'si se trata de una factura de servicio o producto y servicio
                    If .Concepto = 2 Or .Concepto = 3 Then
                        r.Parametros.Add(New GeneradorReportes.Parametro("FechaServicioDesde", ParseStringToDate(.Fechaserviciodesde)))
                        r.Parametros.Add(New GeneradorReportes.Parametro("FechaServicioHasta", ParseStringToDate(.Fechaserviciohasta)))
                    End If

                    r.Parametros.Add(New GeneradorReportes.Parametro("FechaVtoPago", ParseStringToDate(.Fechavtopago)))
                    r.Parametros.Add(New GeneradorReportes.Parametro("CondicionVta", repoformapago.GetById(.Formadepago).Nombre))

                    'datos del receptor
                    r.Parametros.Add(New GeneradorReportes.Parametro("RazonSocial", .Razonsocial & Space(10) & " [Cód. " & .Clienteid & "]"))
                    r.Parametros.Add(New GeneradorReportes.Parametro("CondicionIva", repotiporesp.GetByCodigo(.Tiporesponsable).Descripcion))

                    If .Cbtetipo = RECIBO_COBRANZA Then
                        r.Parametros.Add(New GeneradorReportes.Parametro("clienteId", .Clienteid))
                    End If

                    Select Case .Documentotipo
                        Case 80 : docTipo = "CUIT:"
                        Case 96 : docTipo = "DNI:"
                        Case Else : docTipo = "OTRO:"
                    End Select

                    r.Parametros.Add(New GeneradorReportes.Parametro("DocumentoTipo", docTipo))
                    r.Parametros.Add(New GeneradorReportes.Parametro("DocumentoNro", .Documentonro))
                    r.Parametros.Add(New GeneradorReportes.Parametro("DomicilioCliente", .Domicilio))
                    r.Parametros.Add(New GeneradorReportes.Parametro("NroRemito", .Nroremito))
                    r.Parametros.Add(New GeneradorReportes.Parametro("Observaciones", .ObservacionesExtra))

                    Select Case .Cbtetipo
                        Case FACTURA_A, FACTURA_B
                            If .Monedactz <> 1 And .Monedactz <> 0 Then
                                r.Parametros.Add(New GeneradorReportes.Parametro("ObsCotiza", "Base Dólar: " & Format(.Monedactz, "0.00") & " - Este comprobante equivale a " & Format(.Importetotal / .Monedactz, "0.00") & " Dólares"))
                            End If
                    End Select

                    'Select Case .Cbtetipo
                    '    Case FACTURA_A, FACTURA_B, PRESUPUESTO, NOTA_CREDITO_A, NOTA_CREDITO_B, NOTA_DEBITO_A, NOTA_DEBITO_B, DEVOLUCION_PRESUPUESTO
                    '        Dim strlet As New Numalet
                    '        strlet.MascaraSalidaDecimal = "00/100"
                    '        strlet.SeparadorDecimalSalida = "con"
                    '        strlet.ConvertirDecimales = False
                    '        strlet.LetraCapital = True
                    '        'MessageBox.Show(strlet.ToCustomCardinal(.Importetotal))
                    '        r.Parametros.Add(New GeneradorReportes.Parametro("LetraImporte", strlet.ToCustomCardinal(.Importetotal)))
                    'End Select

                    'importes
                    r.Parametros.Add(New GeneradorReportes.Parametro("ImporteNeto", .Importeneto))
                    r.Parametros.Add(New GeneradorReportes.Parametro("ImporteTributos", .Importetributos))
                    r.Parametros.Add(New GeneradorReportes.Parametro("ImporteExento", .Importeopexentas))
                    r.Parametros.Add(New GeneradorReportes.Parametro("ImporteNoGravado", .Importetotalconceptos))
                    r.Parametros.Add(New GeneradorReportes.Parametro("ImporteTotal", .Importetotal))

                    'alicuotas
                    For Each a As Entidades.CbteAlicuota In .CbteAlicuotas
                        Select Case a.Codigo
                            Case IVA_0 '0%
                                r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA0", a.Importe))
                            Case IVA_105 '10.5%
                                r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA105", a.Importe))
                            Case IVA_21 '21%
                                r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA21", a.Importe))
                            Case IVA_27 '27%
                                r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA27", a.Importe))
                            Case IVA_5 '5%
                                r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA5", a.Importe))
                            Case IVA_25 '2.5%
                                r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA25", a.Importe))
                        End Select
                    Next

                    Select Case .Cbtetipo
                        Case RECIBO_COBRANZA, RECIBO_PRESUPUESTO, ORDEN_PAGO, PAGO_PRESUPUESTO
                            r.Parametros.Add(New GeneradorReportes.Parametro("ImporteCtasPropias", .Importectaspropias))
                            r.Parametros.Add(New GeneradorReportes.Parametro("ImporteCartera", .Importecartera))
                    End Select

                    'si es un comprobante oficial
                    If letra = "A" Or letra = "B" Or letra = "C" Then
                        If .Cae <> "" Then
                            r.Parametros.Add(New GeneradorReportes.Parametro("CAE", .Cae))
                            r.Parametros.Add(New GeneradorReportes.Parametro("FechaVtoCAE", ParseStringToDate(.Fechavtocae)))
                            r.Parametros.Add(New GeneradorReportes.Parametro("BarCode", r.CrearBarCode(.CodigoBarras)))
                        End If
                    End If

                    Select Case copia
                        Case 1
                            r.Parametros.Add(New GeneradorReportes.Parametro("Copia", "ORIGINAL"))
                        Case 2
                            r.Parametros.Add(New GeneradorReportes.Parametro("Copia", "DUPLICADO"))
                        Case 3
                            r.Parametros.Add(New GeneradorReportes.Parametro("Copia", "TRIPLICADO"))
                        Case Else
                            r.Parametros.Add(New GeneradorReportes.Parametro("Copia", "COPIA Nº " & copia))
                    End Select

                    If preview Then
                        r.ShowReport()
                    Else
                        If Not saveAsPdf Then
                            r.PrintReport(1)
                        Else
                            r.SaveAsPDF()
                        End If
                    End If

                Next

            End With



        Catch ex As Exception

            MessageBox.Show(ex.Message, "Emisión de Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Public Sub EmisionCbteProforma(ByVal cbte As Entidades.CbteCabecera)

        Dim repotipodto As New CapaLogica.TipodocumentoCLog
        Dim repoformapago As New CapaLogica.FormadepagoCLog
        Dim repotiporesp As New CapaLogica.TiporesponsableCLog
        Dim repoparametros As New CapaLogica.ParametroCLog

        Dim r As GeneradorReportes.Reporte
        Dim docTipo As String = ""
        Dim letra As String = ""
        Dim denominacion As String = ""
        Dim copias As Short = 0
        Dim plantilla As String = ""
        Dim saveAsPdf As Boolean = False

        Try



            'parametros
            With cbte

                letra = .Letra
                denominacion = "PROFORMA" '.Denominacion

                Select Case .Cbtetipo
                    Case FACTURA_A, FACTURA_B, FACTURA_C, PRESUPUESTO, NOTA_CREDITO_A, NOTA_CREDITO_B, NOTA_DEBITO_A, NOTA_DEBITO_B, DEVOLUCION_PRESUPUESTO
                        Select Case letra
                            Case "A"
                                plantilla = My.Settings.RutaReportes & "\proformaa.rdl"
                            Case "B", "C"
                                plantilla = My.Settings.RutaReportes & "\proformab.rdl"
                            Case Else
                                plantilla = My.Settings.RutaReportes & "\proformax.rdl"
                        End Select
                    Case Else
                        Throw New Exception("Tipo de cbte. no contemplado para la emisión")
                End Select



                r = New GeneradorReportes.Reporte

                r.SourceFile = plantilla

                r.Nombre = .Letra & .Cbtetipo.ToString & .Cbteptovta.ToString("0000") & "-" & .Cbtenumero.ToString("00000000")

                'id para detalle
                r.Parametros.Add(New GeneradorReportes.Parametro("cbteid", .Id))

                'datos del emisor
                r.Parametros.Add(New GeneradorReportes.Parametro("NombreFantasia", repoparametros.GetByNombre("NombreDeFantasiaEmisor").Valorpredeterminado))
                r.Parametros.Add(New GeneradorReportes.Parametro("RazonSocialEmisor", repoparametros.GetByNombre("RazonSocialEmisor").Valorpredeterminado))
                r.Parametros.Add(New GeneradorReportes.Parametro("Email", repoparametros.GetByNombre("EmailEmisor").Valorpredeterminado))
                r.Parametros.Add(New GeneradorReportes.Parametro("DomicilioEmisor", repoparametros.GetByNombre("DomicilioComercialEmisor").Valorpredeterminado))
                r.Parametros.Add(New GeneradorReportes.Parametro("CondicionIvaEmisor", repoparametros.GetByNombre("CondicionIvaEmisor").Valorpredeterminado))
                r.Parametros.Add(New GeneradorReportes.Parametro("CuitEmisor", repoparametros.GetByNombre("CuitEmisor").Valorpredeterminado))
                r.Parametros.Add(New GeneradorReportes.Parametro("IngresosBrutos", repoparametros.GetByNombre("IngresosBrutosEmisor").Valorpredeterminado))
                r.Parametros.Add(New GeneradorReportes.Parametro("InicioActividades", repoparametros.GetByNombre("InicioActividadesEmisor").Valorpredeterminado))

                'cabecera
                r.Parametros.Add(New GeneradorReportes.Parametro("CbteNumero", .Cbtenumero))
                r.Parametros.Add(New GeneradorReportes.Parametro("CbtePtoVta", .Cbteptovta))
                r.Parametros.Add(New GeneradorReportes.Parametro("CbteFecha", ParseStringToDate(.Cbtefecha)))
                r.Parametros.Add(New GeneradorReportes.Parametro("CbteTipo", .Cbtetipo))
                r.Parametros.Add(New GeneradorReportes.Parametro("Letra", letra))
                r.Parametros.Add(New GeneradorReportes.Parametro("Denominacion", denominacion))

                'si se trata de una factura de servicio o producto y servicio
                If .Concepto = 2 Or .Concepto = 3 Then
                    r.Parametros.Add(New GeneradorReportes.Parametro("FechaServicioDesde", ParseStringToDate(.Fechaserviciodesde)))
                    r.Parametros.Add(New GeneradorReportes.Parametro("FechaServicioHasta", ParseStringToDate(.Fechaserviciohasta)))
                End If

                r.Parametros.Add(New GeneradorReportes.Parametro("FechaVtoPago", ParseStringToDate(.Fechavtopago)))
                r.Parametros.Add(New GeneradorReportes.Parametro("CondicionVta", repoformapago.GetById(.Formadepago).Nombre))

                'datos del receptor
                r.Parametros.Add(New GeneradorReportes.Parametro("RazonSocial", .Razonsocial & Space(10) & " [Cód. " & .Clienteid & "]"))
                r.Parametros.Add(New GeneradorReportes.Parametro("CondicionIva", repotiporesp.GetByCodigo(.Tiporesponsable).Descripcion))

                Select Case .Documentotipo
                    Case 80 : docTipo = "CUIT:"
                    Case 96 : docTipo = "DNI:"
                    Case Else : docTipo = "OTRO:"
                End Select

                r.Parametros.Add(New GeneradorReportes.Parametro("DocumentoTipo", docTipo))
                r.Parametros.Add(New GeneradorReportes.Parametro("DocumentoNro", .Documentonro))
                r.Parametros.Add(New GeneradorReportes.Parametro("DomicilioCliente", .Domicilio))
                r.Parametros.Add(New GeneradorReportes.Parametro("NroRemito", .Nroremito))
                r.Parametros.Add(New GeneradorReportes.Parametro("Observaciones", .ObservacionesExtra))


                'importes
                r.Parametros.Add(New GeneradorReportes.Parametro("ImporteNeto", .Importeneto))
                r.Parametros.Add(New GeneradorReportes.Parametro("ImporteTributos", .Importetributos))
                r.Parametros.Add(New GeneradorReportes.Parametro("ImporteExento", .Importeopexentas))
                r.Parametros.Add(New GeneradorReportes.Parametro("ImporteNoGravado", .Importetotalconceptos))
                r.Parametros.Add(New GeneradorReportes.Parametro("ImporteTotal", .Importetotal))

                'alicuotas
                For Each a As Entidades.CbteAlicuota In .CbteAlicuotas
                    Select Case a.Codigo
                        Case IVA_0 '0%
                            r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA0", a.Importe))
                        Case IVA_105 '10.5%
                            r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA105", a.Importe))
                        Case IVA_21 '21%
                            r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA21", a.Importe))
                        Case IVA_27 '27%
                            r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA27", a.Importe))
                        Case IVA_5 '5%
                            r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA5", a.Importe))
                        Case IVA_25 '2.5%
                            r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA25", a.Importe))
                    End Select
                Next

                Select Case .Cbtetipo
                    Case RECIBO_COBRANZA, RECIBO_PRESUPUESTO, ORDEN_PAGO, PAGO_PRESUPUESTO
                        r.Parametros.Add(New GeneradorReportes.Parametro("ImporteCtasPropias", .Importectaspropias))
                        r.Parametros.Add(New GeneradorReportes.Parametro("ImporteCartera", .Importecartera))
                End Select

                'si es un comprobante oficial
                If letra = "A" Or letra = "B" Or letra = "C" Then
                    If .Cae <> "" Then
                        r.Parametros.Add(New GeneradorReportes.Parametro("CAE", .Cae))
                        r.Parametros.Add(New GeneradorReportes.Parametro("FechaVtoCAE", ParseStringToDate(.Fechavtocae)))
                        r.Parametros.Add(New GeneradorReportes.Parametro("BarCode", r.CrearBarCode(.CodigoBarras)))
                    End If
                End If


                r.Parametros.Add(New GeneradorReportes.Parametro("Copia", "PROFORMA"))


                r.ShowReport()



            End With



        Catch ex As Exception

            MessageBox.Show(ex.Message, "Emisión de Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Public Sub EmisionCompra(ByVal id As UInt32, Optional ByVal preview As Boolean = False, Optional ByVal copies As Short = -1)
        Dim repositorio As New CapaLogica.CpracabeceraCLog
        Dim repotipodto As New CapaLogica.TipodocumentoCLog
        Dim repoformapago As New CapaLogica.FormadepagoCLog
        Dim repotiporesp As New CapaLogica.TiporesponsableCLog
        Dim repoparametros As New CapaLogica.ParametroCLog
        Dim repoproveedor As New CapaLogica.ProveedorCLog
        Dim repolocalidad As New CapaLogica.LocalidadCLog
        Dim repotipoiva As New CapaLogica.TiporesponsableCLog
        Dim reporubrogcia As New CapaLogica.RubrogciaCLog
        Dim cbte As New Entidades.CpraCabecera
        Dim prov As New Entidades.Proveedor
        Dim local As New Entidades.Localidad
        Dim tipoiva As New Entidades.Tiporesponsable
        Dim rubrogcia As New Entidades.Rubrogcia
        Dim tributo As New Entidades.CbteTributo
        Dim r As GeneradorReportes.Reporte
        Dim docTipo As String = ""
        Dim letra As String = ""
        Dim denominacion As String = ""
        Dim copias As Short = 0
        Dim copiasGcias As Short = 0
        Dim copiasIva As Short = 0
        Dim copiasIngBrutos As Short = 0
        Dim plantilla As String = ""
        Dim saveAsPdf As Boolean = False

        Try

            cbte = repositorio.GetById(id)

            If cbte Is Nothing Then
                Throw New Exception("El id de cbte solicitado no existe. ID " & id.ToString)
            End If

            'parametros
            With cbte

                letra = .Letra
                denominacion = .Denominacion

                Select Case .Cbtetipo
                    Case FACTURA_A, FACTURA_B, PRESUPUESTO, NOTA_CREDITO_A, NOTA_CREDITO_B, NOTA_DEBITO_A, NOTA_DEBITO_B, DEVOLUCION_PRESUPUESTO, REMITO, FACTURA_C
                        Select Case letra
                            Case "A", "B", "R", "C"
                                plantilla = My.Settings.RutaReportes & "\cpraa.rdl"
                                copias = 1
                            Case Else
                                plantilla = My.Settings.RutaReportes & "\cprax.rdl"
                                copias = Convert.ToInt16(repoparametros.GetByNombre("CopiasCbtesPresupuestos").Valorpredeterminado)
                        End Select
                    Case RECIBO_COBRANZA
                        plantilla = My.Settings.RutaReportes & "\cbterecibo.rdl"
                        copias = Convert.ToInt16(repoparametros.GetByNombre("CopiasCbtesRecibos").Valorpredeterminado)
                    Case RECIBO_PRESUPUESTO
                        plantilla = My.Settings.RutaReportes & "\cbterecibopres.rdl"
                        copias = Convert.ToInt16(repoparametros.GetByNombre("CopiasCbtesRecibosPres").Valorpredeterminado)
                    Case ORDEN_PAGO
                        plantilla = My.Settings.RutaReportes & "\cbteordenpago.rdl"
                        copias = copies 'Convert.ToInt16(repoparametros.GetByNombre("CopiasCbtesOrdenPago").Valorpredeterminado)
                    Case PAGO_PRESUPUESTO
                        plantilla = My.Settings.RutaReportes & "\cbteordenpagopres.rdl"
                        copias = Convert.ToInt16(repoparametros.GetByNombre("CopiasCbtesOrdenPagoPres").Valorpredeterminado)
                    Case Else
                        Throw New Exception("Tipo de cbte. no contemplado para la emisión")
                End Select

                If preview Then
                    copias = 1
                Else
                    If copias = 0 Then
                        saveAsPdf = True
                        copias = 1
                    End If
                End If

                For copia As Integer = 1 To copias


                    r = New GeneradorReportes.Reporte

                    r.SourceFile = plantilla

                    r.Nombre = .Denominacion

                    'id para detalle
                    r.Parametros.Add(New GeneradorReportes.Parametro("cbteid", .Id))

                    'datos del emisor
                    r.Parametros.Add(New GeneradorReportes.Parametro("NombreFantasia", repoparametros.GetByNombre("NombreDeFantasiaEmisor").Valorpredeterminado))
                    r.Parametros.Add(New GeneradorReportes.Parametro("RazonSocialEmisor", repoparametros.GetByNombre("RazonSocialEmisor").Valorpredeterminado))
                    r.Parametros.Add(New GeneradorReportes.Parametro("Email", repoparametros.GetByNombre("EmailEmisor").Valorpredeterminado))
                    r.Parametros.Add(New GeneradorReportes.Parametro("DomicilioEmisor", repoparametros.GetByNombre("DomicilioComercialEmisor").Valorpredeterminado))
                    r.Parametros.Add(New GeneradorReportes.Parametro("CondicionIvaEmisor", repoparametros.GetByNombre("CondicionIvaEmisor").Valorpredeterminado))
                    r.Parametros.Add(New GeneradorReportes.Parametro("CuitEmisor", repoparametros.GetByNombre("CuitEmisor").Valorpredeterminado))
                    r.Parametros.Add(New GeneradorReportes.Parametro("IngresosBrutos", repoparametros.GetByNombre("IngresosBrutosEmisor").Valorpredeterminado))
                    r.Parametros.Add(New GeneradorReportes.Parametro("InicioActividades", repoparametros.GetByNombre("InicioActividadesEmisor").Valorpredeterminado))

                    'cabecera
                    r.Parametros.Add(New GeneradorReportes.Parametro("CbteNumero", .Cbtenumero))
                    r.Parametros.Add(New GeneradorReportes.Parametro("CbtePtoVta", .Cbteptovta))
                    r.Parametros.Add(New GeneradorReportes.Parametro("CbteFecha", ParseStringToDate(.Cbtefecha)))
                    r.Parametros.Add(New GeneradorReportes.Parametro("CbteTipo", .Cbtetipo))
                    r.Parametros.Add(New GeneradorReportes.Parametro("Letra", letra))
                    r.Parametros.Add(New GeneradorReportes.Parametro("Denominacion", denominacion))

                    'si se trata de una factura de servicio o producto y servicio
                    'If .Concepto = 2 Or .Concepto = 3 Then
                    r.Parametros.Add(New GeneradorReportes.Parametro("FechaServicioDesde", ParseStringToDate(.Fechaserviciodesde)))
                    r.Parametros.Add(New GeneradorReportes.Parametro("FechaServicioHasta", ParseStringToDate(.Fechaserviciohasta)))
                    'End If

                    r.Parametros.Add(New GeneradorReportes.Parametro("FechaVtoPago", ParseStringToDate(.Fechavtopago)))
                    r.Parametros.Add(New GeneradorReportes.Parametro("CondicionVta", repoformapago.GetById(.Formadepago).Nombre))

                    'datos del receptor
                    r.Parametros.Add(New GeneradorReportes.Parametro("RazonSocial", .Razonsocial))
                    r.Parametros.Add(New GeneradorReportes.Parametro("CondicionIva", repotiporesp.GetByCodigo(.Tiporesponsable).Descripcion))
                    If .Cbtetipo = ORDEN_PAGO Then
                        r.Parametros.Add(New GeneradorReportes.Parametro("provId", .ProveedorId))
                    End If
                    Select Case .Documentotipo
                        Case 80 : docTipo = "CUIT:"
                        Case 96 : docTipo = "DNI:"
                        Case Else : docTipo = "OTRO:"
                    End Select

                    r.Parametros.Add(New GeneradorReportes.Parametro("DocumentoTipo", docTipo))
                    r.Parametros.Add(New GeneradorReportes.Parametro("DocumentoNro", .Documentonro))
                    r.Parametros.Add(New GeneradorReportes.Parametro("DomicilioCliente", .Domicilio))
                    r.Parametros.Add(New GeneradorReportes.Parametro("NroRemito", .Nroremito))
                    r.Parametros.Add(New GeneradorReportes.Parametro("Observaciones", .ObservacionesExtra))


                    'importes
                    r.Parametros.Add(New GeneradorReportes.Parametro("ImporteNeto", .Importeneto))
                    r.Parametros.Add(New GeneradorReportes.Parametro("ImporteTributos", .Importetributos))
                    r.Parametros.Add(New GeneradorReportes.Parametro("ImporteExento", .Importeopexentas))
                    r.Parametros.Add(New GeneradorReportes.Parametro("ImporteNoGravado", .Importetotalconceptos))
                    r.Parametros.Add(New GeneradorReportes.Parametro("ImporteTotal", .Importetotal))

                    'alicuotas
                    For Each a As Entidades.CbteAlicuota In .CbteAlicuotas
                        Select Case a.Codigo
                            Case IVA_0 '0%
                                r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA0", a.Importe))
                            Case IVA_105 '10.5%
                                r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA105", a.Importe))
                            Case IVA_21 '21%
                                r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA21", a.Importe))
                            Case IVA_27 '27%
                                r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA27", a.Importe))
                            Case IVA_5 '5%
                                r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA5", a.Importe))
                            Case IVA_25 '2.5%
                                r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA25", a.Importe))
                        End Select
                    Next

                    Select Case .Cbtetipo
                        Case RECIBO_COBRANZA, RECIBO_PRESUPUESTO, ORDEN_PAGO, PAGO_PRESUPUESTO
                            r.Parametros.Add(New GeneradorReportes.Parametro("ImporteCtasPropias", .Importectaspropias))
                            r.Parametros.Add(New GeneradorReportes.Parametro("ImporteCartera", .Importecartera))
                    End Select

                    'si es un comprobante oficial
                    If letra = "A" Or letra = "B" Then
                        r.Parametros.Add(New GeneradorReportes.Parametro("CAE", .Cae))
                        If .Fechavtocae <> "" Then
                            r.Parametros.Add(New GeneradorReportes.Parametro("FechaVtoCAE", ParseStringToDate(.Fechavtocae)))
                        End If
                    End If

                    Select Case copia
                        Case 1
                            r.Parametros.Add(New GeneradorReportes.Parametro("Copia", "ORIGINAL"))
                        Case 2
                            r.Parametros.Add(New GeneradorReportes.Parametro("Copia", "DUPLICADO"))
                        Case 3
                            r.Parametros.Add(New GeneradorReportes.Parametro("Copia", "TRIPLICADO"))
                        Case Else
                            r.Parametros.Add(New GeneradorReportes.Parametro("Copia", "COPIA Nº " & copia))
                    End Select



                    If preview Then
                        r.ShowReport()
                    Else
                        If Not saveAsPdf Then
                            r.PrintReport(1)
                        Else
                            r.SaveAsPDF()
                        End If
                    End If

                Next

                '''''impuesto a las ganancias

                copiasGcias = Convert.ToInt16(repoparametros.GetByNombre("CopiaComprobanteRetencionGanancia").Valorpredeterminado)

                If preview Then
                    copiasGcias = 1
                Else
                    If copiasGcias = 0 Then
                        saveAsPdf = True
                        copiasGcias = 1
                    End If
                End If

                For copia As Integer = 1 To copiasGcias
                    prov = repoproveedor.GetById(cbte.ProveedorId)
                    local = repolocalidad.GetById(prov.Localidad)
                    tipoiva = repotipoiva.GetById(prov.Tiporesponsable)
                    rubrogcia = reporubrogcia.GetById(prov.Rubrogcia)

                    For Each tributo In .CbteTributos
                        If tributo.Codigo = AFIP_COD_IMPUESTO_NACIONAL And tributo.Descripcion = TRIBUTO_PERC_RET_GCIAS Then
                            Dim t As New GeneradorReportes.Reporte

                            t.SourceFile = My.Settings.RutaReportes & "\lstRetencionesGciasAfip.rdl"
                            t.Nombre = "Retenciones Ganancias"
                            't.Parametros.Add(New GeneradorReportes.Parametro("titulo", "Listado de Clientes"))
                            t.Parametros.Add(New GeneradorReportes.Parametro("certificado", tributo.Referencia))
                            t.Parametros.Add(New GeneradorReportes.Parametro("localidad", gEmpresa.Localidad))
                            t.Parametros.Add(New GeneradorReportes.Parametro("fecha", cbte.Cbtefecha))
                            t.Parametros.Add(New GeneradorReportes.Parametro("categoria", tipoiva.Descripcion))
                            t.Parametros.Add(New GeneradorReportes.Parametro("nombreAgente", gEmpresa.RazonSocial))
                            t.Parametros.Add(New GeneradorReportes.Parametro("cuitAgente", gEmpresa.NroCuit))
                            t.Parametros.Add(New GeneradorReportes.Parametro("domicilioAgente", gEmpresa.DomicilioComercial))
                            t.Parametros.Add(New GeneradorReportes.Parametro("localidadAgente", gEmpresa.Localidad))
                            t.Parametros.Add(New GeneradorReportes.Parametro("provinciaAgente", gEmpresa.Provincia))
                            t.Parametros.Add(New GeneradorReportes.Parametro("cpostalAgente", gEmpresa.CodigoPostal))
                            t.Parametros.Add(New GeneradorReportes.Parametro("nombreSujeto", prov.Nombre))
                            t.Parametros.Add(New GeneradorReportes.Parametro("cuitSujeto", prov.Documento))
                            t.Parametros.Add(New GeneradorReportes.Parametro("domicilioSujeto", prov.Domicilio))
                            t.Parametros.Add(New GeneradorReportes.Parametro("localidadSujeto", local.Nombre))
                            t.Parametros.Add(New GeneradorReportes.Parametro("provinciaSujeto", local.Provincia))
                            t.Parametros.Add(New GeneradorReportes.Parametro("cpostalSujeto", local.Codigopostal))
                            t.Parametros.Add(New GeneradorReportes.Parametro("impuesto", "Impuesto a las ganancias"))
                            t.Parametros.Add(New GeneradorReportes.Parametro("regimen", rubrogcia.Nombre))
                            t.Parametros.Add(New GeneradorReportes.Parametro("comprobRetencion", cbte.Denominacion & " Nro. " & Format(cbte.Cbtenumero, "00000000")))
                            t.Parametros.Add(New GeneradorReportes.Parametro("montoOriginaRetencion", tributo.BaseImponible.ToString("#,##0.00")))
                            t.Parametros.Add(New GeneradorReportes.Parametro("montoRetencion", tributo.Importe.ToString("#,##0.00")))
                            If copia = 1 Then
                                t.Parametros.Add(New GeneradorReportes.Parametro("tipoDocumento", "Original"))
                            ElseIf copia = 2 Then
                                t.Parametros.Add(New GeneradorReportes.Parametro("tipoDocumento", "Duplicado"))
                            End If

                            If preview Then
                                t.ShowReport()
                            Else
                                If Not saveAsPdf Then
                                    t.PrintReport(1)
                                Else
                                    t.SaveAsPDF()
                                End If
                            End If
                        End If
                    Next
                Next

                '''''Retención de IVA

                copiasIva = Convert.ToInt16(repoparametros.GetByNombre("CopiaComprobanteRetencionIva").Valorpredeterminado)

                If preview Then
                    copiasIva = 1
                Else
                    If copiasIva = 0 Then
                        saveAsPdf = True
                        copiasIva = 1
                    End If
                End If

                For copia As Integer = 1 To copiasIva
                    prov = repoproveedor.GetById(cbte.ProveedorId)
                    local = repolocalidad.GetById(prov.Localidad)
                    tipoiva = repotipoiva.GetById(prov.Tiporesponsable)

                    For Each tributo In .CbteTributos
                        If tributo.Codigo = AFIP_COD_IMPUESTO_NACIONAL And tributo.Descripcion = TRIBUTO_PERC_RET_IVA Then
                            Dim i As New GeneradorReportes.Reporte

                            i.SourceFile = My.Settings.RutaReportes & "\lstRetencionesIvaAfip.rdl"
                            i.Nombre = "Retención IVA"
                            't.Parametros.Add(New GeneradorReportes.Parametro("titulo", "Listado de Clientes"))
                            i.Parametros.Add(New GeneradorReportes.Parametro("certificado", tributo.Referencia))
                            i.Parametros.Add(New GeneradorReportes.Parametro("localidad", gEmpresa.Localidad))
                            i.Parametros.Add(New GeneradorReportes.Parametro("fecha", cbte.Cbtefecha))
                            i.Parametros.Add(New GeneradorReportes.Parametro("categoria", tipoiva.Descripcion))
                            i.Parametros.Add(New GeneradorReportes.Parametro("nombreAgente", gEmpresa.RazonSocial))
                            i.Parametros.Add(New GeneradorReportes.Parametro("cuitAgente", gEmpresa.NroCuit))
                            i.Parametros.Add(New GeneradorReportes.Parametro("domicilioAgente", gEmpresa.DomicilioComercial))
                            i.Parametros.Add(New GeneradorReportes.Parametro("localidadAgente", gEmpresa.Localidad))
                            i.Parametros.Add(New GeneradorReportes.Parametro("provinciaAgente", gEmpresa.Provincia))
                            i.Parametros.Add(New GeneradorReportes.Parametro("cpostalAgente", gEmpresa.CodigoPostal))
                            i.Parametros.Add(New GeneradorReportes.Parametro("nombreSujeto", prov.Nombre))
                            i.Parametros.Add(New GeneradorReportes.Parametro("cuitSujeto", prov.Documento))
                            i.Parametros.Add(New GeneradorReportes.Parametro("domicilioSujeto", prov.Domicilio))
                            i.Parametros.Add(New GeneradorReportes.Parametro("localidadSujeto", local.Nombre))
                            i.Parametros.Add(New GeneradorReportes.Parametro("provinciaSujeto", local.Provincia))
                            i.Parametros.Add(New GeneradorReportes.Parametro("cpostalSujeto", local.Codigopostal))
                            i.Parametros.Add(New GeneradorReportes.Parametro("impuesto", "Impuesto Retención de IVA"))
                            i.Parametros.Add(New GeneradorReportes.Parametro("regimen", "Retención IVA"))
                            i.Parametros.Add(New GeneradorReportes.Parametro("comprobRetencion", cbte.Denominacion & " Nro. " & Format(cbte.Cbtenumero, "00000000")))
                            i.Parametros.Add(New GeneradorReportes.Parametro("montoOriginaRetencion", tributo.BaseImponible.ToString("#,##0.00")))
                            i.Parametros.Add(New GeneradorReportes.Parametro("montoRetencion", tributo.Importe.ToString("#,##0.00")))
                            i.Parametros.Add(New GeneradorReportes.Parametro("alicuota", tributo.Alicuota.ToString("#,##0.00")))
                            If copia = 1 Then
                                i.Parametros.Add(New GeneradorReportes.Parametro("tipoDocumento", "Original"))
                            ElseIf copia = 2 Then
                                i.Parametros.Add(New GeneradorReportes.Parametro("tipoDocumento", "Duplicado"))
                            End If

                            If preview Then
                                i.ShowReport()
                            Else
                                If Not saveAsPdf Then
                                    i.PrintReport(1)
                                Else
                                    i.SaveAsPDF()
                                End If
                            End If
                        End If
                    Next
                Next

                ''''''ingresos brutos

                copiasIngBrutos = Convert.ToInt16(repoparametros.GetByNombre("CopiaComprobanteRetencionIngBrutos").Valorpredeterminado)

                If preview Then
                    copiasIngBrutos = 1
                Else
                    If copiasIngBrutos = 0 Then
                        saveAsPdf = True
                        copiasIngBrutos = 1
                    End If
                End If

                For copia As Integer = 1 To copiasIngBrutos
                    prov = repoproveedor.GetById(cbte.ProveedorId)
                    local = repolocalidad.GetById(prov.Localidad)
                    tipoiva = repotipoiva.GetById(prov.Tiporesponsable)
                    rubrogcia = reporubrogcia.GetById(prov.Rubrogcia)

                    For Each tributo In .CbteTributos
                        If tributo.Codigo = AFIP_COD_IMPUESTO_PROVINCIAL And tributo.Descripcion = TRIBUTO_PERC_RET_IIBB Then
                            Dim o As New GeneradorReportes.Reporte

                            o.SourceFile = My.Settings.RutaReportes & "\lstRetencionesIngBruApi.rdl"
                            o.Nombre = "Retenciones Ganancias"

                            o.Parametros.Add(New GeneradorReportes.Parametro("certificado", tributo.Referencia))
                            o.Parametros.Add(New GeneradorReportes.Parametro("fecha", cbte.Cbtefecha))
                            o.Parametros.Add(New GeneradorReportes.Parametro("nombreAgente", gEmpresa.RazonSocial))
                            o.Parametros.Add(New GeneradorReportes.Parametro("cuitAgente", gEmpresa.NroCuit))
                            o.Parametros.Add(New GeneradorReportes.Parametro("nroInscripcionAgente", gEmpresa.NroIngBrutos))
                            o.Parametros.Add(New GeneradorReportes.Parametro("domicilioAgente", gEmpresa.DomicilioComercial))
                            o.Parametros.Add(New GeneradorReportes.Parametro("localidadAgente", gEmpresa.Localidad))
                            o.Parametros.Add(New GeneradorReportes.Parametro("provinciaAgente", gEmpresa.Provincia))
                            o.Parametros.Add(New GeneradorReportes.Parametro("cpostalAgente", gEmpresa.CodigoPostal))
                            o.Parametros.Add(New GeneradorReportes.Parametro("nombreSujeto", prov.Nombre))
                            o.Parametros.Add(New GeneradorReportes.Parametro("cuitSujeto", prov.Documento))
                            o.Parametros.Add(New GeneradorReportes.Parametro("nroInscripcionSujeto", prov.Ingresosbrutosnro))
                            o.Parametros.Add(New GeneradorReportes.Parametro("domicilioSujeto", prov.Domicilio))
                            o.Parametros.Add(New GeneradorReportes.Parametro("localidadSujeto", local.Nombre))
                            o.Parametros.Add(New GeneradorReportes.Parametro("provinciaSujeto", local.Provincia))
                            o.Parametros.Add(New GeneradorReportes.Parametro("cpostalSujeto", local.Codigopostal))
                            o.Parametros.Add(New GeneradorReportes.Parametro("comprobRetencion", cbte.Denominacion))
                            o.Parametros.Add(New GeneradorReportes.Parametro("nroComprobRetencion", Format(cbte.Cbtenumero, "00000000")))
                            o.Parametros.Add(New GeneradorReportes.Parametro("montoOriginaRetencion", tributo.BaseImponible.ToString("#,##0.00")))
                            o.Parametros.Add(New GeneradorReportes.Parametro("montoRetencion", tributo.Importe.ToString("#,##0.00")))
                            If copia = 1 Then
                                o.Parametros.Add(New GeneradorReportes.Parametro("tipoDocumento", "Original"))
                            ElseIf copia = 2 Then
                                o.Parametros.Add(New GeneradorReportes.Parametro("tipoDocumento", "Duplicado"))
                            End If
                            o.Parametros.Add(New GeneradorReportes.Parametro("disposicion", rubrogcia.Nombre))
                            o.Parametros.Add(New GeneradorReportes.Parametro("montoImponible", tributo.Importe.ToString("#,##0.00")))
                            o.Parametros.Add(New GeneradorReportes.Parametro("alicuota", tributo.Alicuota.ToString("#,##0.00")))
                            o.Parametros.Add(New GeneradorReportes.Parametro("fechaImpresion", tributo.Importe.ToString("#,##0.00")))

                            If preview Then
                                o.ShowReport()
                            Else
                                If Not saveAsPdf Then
                                    o.PrintReport(1)
                                Else
                                    o.SaveAsPDF()
                                End If
                            End If
                        End If
                    Next
                Next
            End With

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Emisión de Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Public Function DescomponerCodigoBarra(ByVal codigobarra As String) As wscdc.CmpDatos
        Dim cbte As wscdc.CmpDatos

        Try

            cbte = New wscdc.CmpDatos
            cbte.CuitEmisor = codigobarra.Substring(0, 11)
            cbte.CbteTipo = codigobarra.Substring(11, 2)
            cbte.PtoVta = codigobarra.Substring(13, 4)
            cbte.CodAutorizacion = codigobarra.Substring(17, 14)
            cbte.CbteFch = codigobarra.Substring(31, 8) 'vto. cae

            Return cbte

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Descomponer código de barra", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Public Sub EmisionMovCtas(ByVal id As UInt32, ByVal fecha As Date, ByVal fechaEf As Date, Optional ByVal preview As Boolean = False, Optional ByVal blnReimp As Boolean = False)

        Dim repoparametros As New CapaLogica.ParametroCLog

        Dim r As GeneradorReportes.Reporte
        Dim copias As Short = 0
        Dim plantilla As String = ""
        Dim saveAsPdf As Boolean = False

        Try

            If Trim(id) = "" Then
                Throw New Exception("El nro. de Mov. Entre Cuentas no es válido")
            End If

            plantilla = My.Settings.RutaReportes & "\comMovCtas.rdl"
            copias = Convert.ToInt16(repoparametros.GetByNombre("CopiasCbtesMovCtas").Valorpredeterminado)

            If preview Then
                copias = 1
            Else
                If copias = 0 Then
                    saveAsPdf = True
                    copias = 1
                End If
            End If

            For copia As Integer = 1 To copias

                r = New GeneradorReportes.Reporte

                r.SourceFile = plantilla

                r.Nombre = "MOV. ENTRE CUENTAS"

                Select Case copia
                    Case 1
                        r.Parametros.Add(New GeneradorReportes.Parametro("NombreCopia", "ORIGINAL"))
                    Case 2
                        r.Parametros.Add(New GeneradorReportes.Parametro("NombreCopia", "DUPLICADO"))
                    Case 3
                        r.Parametros.Add(New GeneradorReportes.Parametro("NombreCopia", "TRIPLICADO"))
                    Case 4
                        r.Parametros.Add(New GeneradorReportes.Parametro("NombreCopia", "CUADRUPLICADO"))
                    Case Else
                        r.Parametros.Add(New GeneradorReportes.Parametro("NombreCopia", "COPIA Nº " & copia.ToString))
                End Select

                'datos del emisor
                r.Parametros.Add(New GeneradorReportes.Parametro("NombreFantasia", repoparametros.GetByNombre("NombreDeFantasiaEmisor").Valorpredeterminado))
                r.Parametros.Add(New GeneradorReportes.Parametro("RazonSocialEmisor", repoparametros.GetByNombre("RazonSocialEmisor").Valorpredeterminado))
                r.Parametros.Add(New GeneradorReportes.Parametro("Email", repoparametros.GetByNombre("EmailEmisor").Valorpredeterminado))
                r.Parametros.Add(New GeneradorReportes.Parametro("DomicilioEmisor", repoparametros.GetByNombre("DomicilioComercialEmisor").Valorpredeterminado))
                r.Parametros.Add(New GeneradorReportes.Parametro("CondicionIvaEmisor", repoparametros.GetByNombre("CondicionIvaEmisor").Valorpredeterminado))
                r.Parametros.Add(New GeneradorReportes.Parametro("IngresosBrutos", repoparametros.GetByNombre("IngresosBrutosEmisor").Valorpredeterminado))
                r.Parametros.Add(New GeneradorReportes.Parametro("InicioActividades", repoparametros.GetByNombre("InicioActividadesEmisor").Valorpredeterminado))

                'cabecera
                r.Parametros.Add(New GeneradorReportes.Parametro("CbteNumero", id))
                r.Parametros.Add(New GeneradorReportes.Parametro("Origen", ORIGEN_FINANCIERO_MOVIM))
                r.Parametros.Add(New GeneradorReportes.Parametro("CbteFecha", Format(fecha, "dd/MM/yyyy")))
                r.Parametros.Add(New GeneradorReportes.Parametro("CbteFechaEf", Format(fechaEf, "dd/MM/yyyy")))
                r.Parametros.Add(New GeneradorReportes.Parametro("Denominacion", "MOVIMIENTO ENTRE CUENTAS"))

                r.Parametros.Add(New GeneradorReportes.Parametro("titulo", r.Nombre))
                r.Parametros.Add(New GeneradorReportes.Parametro("titulo2", "Fecha de Efectivización: " & Format(fechaEf, "dd/MM/yyyy")))

                r.Parametros.Add(New GeneradorReportes.Parametro("reimpresion", IIf(blnReimp = False, "", "(Reimpresión)")))

                If preview Then
                    r.ShowReport()
                Else
                    If Not saveAsPdf Then
                        r.PrintReport(1)
                    Else
                        r.SaveAsPDF()
                    End If
                End If

            Next

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Emisión de Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Public Sub EmisionDeposito(ByVal id As UInt32, ByVal fecha As Date, Optional ByVal preview As Boolean = False, Optional ByVal blnReimp As Boolean = False)

        Dim repoparametros As New CapaLogica.ParametroCLog
        Dim r As GeneradorReportes.Reporte
        Dim copias As Short = 0
        Dim plantilla As String = ""
        Dim saveAsPdf As Boolean = False

        Try

            If id = 0 Then
                Throw New Exception("El nro. de depósito no es válido")
            End If

            plantilla = My.Settings.RutaReportes & "\cbtedeposito.rdl"
            copias = Convert.ToInt16(repoparametros.GetByNombre("CopiasCbtesDepositoCartera").Valorpredeterminado)

            If preview Then
                copias = 1
            Else
                If copias = 0 Then
                    saveAsPdf = True
                    copias = 1
                End If
            End If

            For copia As Integer = 1 To copias

                r = New GeneradorReportes.Reporte

                r.SourceFile = plantilla

                r.Nombre = "DEPOSITO"

                Select Case copia
                    Case 1
                        r.Parametros.Add(New GeneradorReportes.Parametro("NombreCopia", "ORIGINAL"))
                    Case 2
                        r.Parametros.Add(New GeneradorReportes.Parametro("NombreCopia", "DUPLICADO"))
                    Case 3
                        r.Parametros.Add(New GeneradorReportes.Parametro("NombreCopia", "TRIPLICADO"))
                    Case 4
                        r.Parametros.Add(New GeneradorReportes.Parametro("NombreCopia", "CUADRUPLICADO"))
                    Case Else
                        r.Parametros.Add(New GeneradorReportes.Parametro("NombreCopia", "COPIA Nº " & copia.ToString))
                End Select

                'id para detalle
                r.Parametros.Add(New GeneradorReportes.Parametro("Deposito", id))

                'datos del emisor
                r.Parametros.Add(New GeneradorReportes.Parametro("NombreFantasia", repoparametros.GetByNombre("NombreDeFantasiaEmisor").Valorpredeterminado))
                r.Parametros.Add(New GeneradorReportes.Parametro("RazonSocialEmisor", repoparametros.GetByNombre("RazonSocialEmisor").Valorpredeterminado))
                r.Parametros.Add(New GeneradorReportes.Parametro("Email", repoparametros.GetByNombre("EmailEmisor").Valorpredeterminado))
                r.Parametros.Add(New GeneradorReportes.Parametro("DomicilioEmisor", repoparametros.GetByNombre("DomicilioComercialEmisor").Valorpredeterminado))
                r.Parametros.Add(New GeneradorReportes.Parametro("CondicionIvaEmisor", repoparametros.GetByNombre("CondicionIvaEmisor").Valorpredeterminado))
                r.Parametros.Add(New GeneradorReportes.Parametro("IngresosBrutos", repoparametros.GetByNombre("IngresosBrutosEmisor").Valorpredeterminado))
                r.Parametros.Add(New GeneradorReportes.Parametro("InicioActividades", repoparametros.GetByNombre("InicioActividadesEmisor").Valorpredeterminado))

                'cabecera
                r.Parametros.Add(New GeneradorReportes.Parametro("CbteNumero", id))
                r.Parametros.Add(New GeneradorReportes.Parametro("CbteFecha", fecha))
                r.Parametros.Add(New GeneradorReportes.Parametro("Denominacion", "DEPOSITO DE CHEQUES"))

                r.Parametros.Add(New GeneradorReportes.Parametro("Cuenta", CUENTA_CARTERA))
                r.Parametros.Add(New GeneradorReportes.Parametro("Concepto", CONCEPTO_CHEQUE_DEPOSITADO))

                r.Parametros.Add(New GeneradorReportes.Parametro("reimpresion", IIf(blnReimp = False, "", "(Reimpresión)")))

                If preview Then
                    r.ShowReport()
                Else
                    If Not saveAsPdf Then
                        r.PrintReport(1)
                    Else
                        r.SaveAsPDF()
                    End If
                End If

            Next


        Catch ex As Exception

            MessageBox.Show(ex.Message, "Emisión de Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Public Sub CargarDatosEmpresa()
        Dim repositorio As New CapaLogica.ParametroCLog

        Try
            gEmpresa = New Entidades.Empresa
            gEmpresa.RazonSocial = repositorio.GetByNombre("RazonSocialEmisor").Valorpredeterminado
            gEmpresa.InicioActividad = repositorio.GetByNombre("InicioActividadesEmisor").Valorpredeterminado
            gEmpresa.NombreFantasia = repositorio.GetByNombre("NombreDeFantasiaEmisor").Valorpredeterminado
            gEmpresa.DomicilioComercial = repositorio.GetByNombre("DomicilioComercialEmisor").Valorpredeterminado
            gEmpresa.Localidad = repositorio.GetByNombre("LocalidadEmisor").Valorpredeterminado
            gEmpresa.Provincia = repositorio.GetByNombre("ProvinciaEmisor").Valorpredeterminado
            gEmpresa.CodigoPostal = repositorio.GetByNombre("CodigoPostalEmisor").Valorpredeterminado
            gEmpresa.NroCuit = repositorio.GetByNombre("CuitEmisor").Valorpredeterminado
            gEmpresa.CondicionIVA = repositorio.GetByNombre("CondicionIVAEmisor").Valorpredeterminado
            gEmpresa.IvaInscripto = CBool(repositorio.GetByNombre("IVAInscripto").Valorpredeterminado)
            gEmpresa.Email = repositorio.GetByNombre("EmailEmisor").Valorpredeterminado
            gEmpresa.Website = repositorio.GetByNombre("SitioWebEmisor").Valorpredeterminado
            gEmpresa.NroIngBrutos = repositorio.GetByNombre("IngresosBrutosEmisor").Valorpredeterminado
            gEmpresa.Telefono = repositorio.GetByNombre("TelefonoEmisor").Valorpredeterminado
            gEmpresa.Actividad = repositorio.GetByNombre("ActividadEmisor").Valorpredeterminado
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Cargar datos empresa", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            repositorio = Nothing
        End Try

    End Sub

    Public Function AutorizarPermiso(ByVal permiso As PermisoUsuario, Optional ByVal valor As Double = 0.0) As Boolean
        Dim f As New FormAutorizar
        Dim ret As Boolean
        f.Permiso = permiso
        f.Valor = valor

        If f.ShowDialog = Windows.Forms.DialogResult.OK Then
            Select Case permiso
                Case PermisoUsuario.TOPE_DESCUENTO
                    ret = (f.Usuario.DescuentoTope >= valor)
                Case PermisoUsuario.EMITE_NOTA_CREDITO
                    ret = f.Usuario.Notadecredito
                Case Else : ret = False
            End Select
        Else
            ret = False
        End If

        f.Close()
        f = Nothing

        Return ret

    End Function

    Public Sub SetearEncabezadosReporte(ByRef reporte As GeneradorReportes.Reporte)
        reporte.Parametros.Add(New GeneradorReportes.Parametro("enca1", gEmpresa.RazonSocial))
        reporte.Parametros.Add(New GeneradorReportes.Parametro("enca2", gEmpresa.DomicilioComercial))
        reporte.Parametros.Add(New GeneradorReportes.Parametro("enca3", "Tel.: " & gEmpresa.Telefono))
        reporte.Parametros.Add(New GeneradorReportes.Parametro("enca4", "Email: " & gEmpresa.Email))
    End Sub

    Function ValidateEmail(ByVal email As String, Optional ByVal pblnValidaVacio As Boolean = False) As Boolean

        If pblnValidaVacio = False Then
            If email.ToString.Length = 0 Then Return True
        End If

        Dim emailRegex As New System.Text.RegularExpressions.Regex(
            "^(?<user>[^@]+)@(?<host>.+)$")
        Dim emailMatch As System.Text.RegularExpressions.Match =
           emailRegex.Match(email)
        Return emailMatch.Success
    End Function
    Public Function EnviarInfCliente(ByVal ReporteAGenerar As ReporteCtaCte,
                                    ByVal fechaDesde As String,
                                    ByVal fechaHasta As String,
                                    ByVal idCliente As Integer,
                                    ByVal nombreCliente As String) As String

        'Try

        '    Dim r As New GeneradorReportes.Reporte

        '    Select Case ReporteAGenerar
        '        Case ReporteCtaCte.SALDOS
        '            r.Nombre = "Saldos"
        '            r.SourceFile = My.Settings.RutaReportes & "\infsaldoscliente.rdl"
        '            r.Parametros.Add(New GeneradorReportes.Parametro("titulo", "Informe de Saldos de Clientes al " & fechaHasta)) 'Me.DateTimePickerHasta.Value.Date))

        '            r.Parametros.Add(New GeneradorReportes.Parametro("fdesde", fechaHasta)) 'Me.DateTimePickerHasta.Value.ToString("yyyy/MM/dd")))
        '            r.Parametros.Add(New GeneradorReportes.Parametro("fhasta", fechaHasta)) 'Me.DateTimePickerHasta.Value.ToString("yyyy/MM/dd")))

        '        Case ReporteCtaCte.EDOCTA
        '            r.Nombre = "Estado de Cuenta"
        '            r.SourceFile = My.Settings.RutaReportes & "\infedoctacliente.rdl"
        '            r.Parametros.Add(New GeneradorReportes.Parametro("titulo", "Estado de Cuenta de Clientes - " & fechaDesde & " al " & fechaHasta))

        '            r.Parametros.Add(New GeneradorReportes.Parametro("fdesde", fechaDesde))
        '            r.Parametros.Add(New GeneradorReportes.Parametro("fhasta", fechaHasta))
        '        Case ReporteCtaCte.EDOREF
        '            r.Nombre = "Estado de Cuenta por Referencia"
        '            r.SourceFile = My.Settings.RutaReportes & "\infedorefcliente.rdl"
        '            r.Parametros.Add(New GeneradorReportes.Parametro("titulo", "Estado de Cuenta por Ref. de Clientes - " & fechaDesde & " al " & fechaHasta))

        '            r.Parametros.Add(New GeneradorReportes.Parametro("fdesde", fechaDesde))
        '            r.Parametros.Add(New GeneradorReportes.Parametro("fhasta", fechaHasta))
        '        Case ReporteCtaCte.PENDIENTES
        '            r.Nombre = "Facturas Pendientes"
        '            r.SourceFile = My.Settings.RutaReportes & "\infpendientescliente.rdl"
        '            r.Parametros.Add(New GeneradorReportes.Parametro("titulo", "Facturas Pendientes de Clientes al " & fechaHasta))

        '            r.Parametros.Add(New GeneradorReportes.Parametro("fdesde", fechaHasta))
        '            r.Parametros.Add(New GeneradorReportes.Parametro("fhasta", fechaHasta))

        '        Case ReporteCtaCte.VENCIMIENTO
        '            r.Nombre = "Facturas Pendientes x Vto."
        '            r.SourceFile = My.Settings.RutaReportes & "\infpendientesvtocliente.rdl"
        '            r.Parametros.Add(New GeneradorReportes.Parametro("titulo", "Facturas Pendientes x Vto. de Clientes al " & fechaHasta))

        '            r.Parametros.Add(New GeneradorReportes.Parametro("fdesde", fechaHasta))
        '            r.Parametros.Add(New GeneradorReportes.Parametro("fhasta", fechaHasta))


        '        Case ReporteCtaCte.ANTICIPOS
        '            r.Nombre = "Anticipos"
        '            r.SourceFile = My.Settings.RutaReportes & "\infanticiposcliente.rdl"
        '            r.Parametros.Add(New GeneradorReportes.Parametro("titulo", "Anticipos de Clientes al " & fechaHasta))

        '            r.Parametros.Add(New GeneradorReportes.Parametro("fdesde", fechaHasta))
        '            r.Parametros.Add(New GeneradorReportes.Parametro("fhasta", fechaHasta))
        '    End Select

        '    r.Parametros.Add(New GeneradorReportes.Parametro("cdesde", idCliente))
        '    r.Parametros.Add(New GeneradorReportes.Parametro("chasta", idCliente))
        '    r.Parametros.Add(New GeneradorReportes.Parametro("nombre", nombreCliente))

        '    r.Parametros.Add(New GeneradorReportes.Parametro("tipo", "F"))

        '    SetearEncabezadosReporte(r)

        '    Return r.SaveAsPDF()

        '    'r.ShowReport()

        '    'Me.Close()

        'Catch ex As Exception
        '    MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Enviar Informe por Mail", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Return ""
        'End Try

    End Function
    Public Function ExportarCbteToPDF(ByVal id As UInt32) As String
        Dim repositorio As New CapaLogica.CbteCabecera2CLog
        'Dim repotipodto As New CapaLogica.TipodocumentoCLog
        'Dim repoformapago As New CapaLogica.FormadepagoCLog
        'Dim repotiporesp As New CapaLogica.TiporesponsableCLog
        Dim repoparametros As New CapaLogica.ParametroCLog
        Dim cbte As New Entidades.CbteCabecera2
        Dim r As GeneradorReportes.Reporte
        Dim docTipo As String = ""
        Dim letra As String = ""
        Dim denominacion As String = ""
        Dim copias As Short = 1
        Dim plantilla As String = ""
        Dim saveAsPdf As Boolean = False

        Try

            cbte = repositorio.GetById(id)

            If cbte Is Nothing Then
                Throw New Exception("El id de cbte solicitado no existe. ID " & id.ToString)
            End If

            'parametros
            With cbte

                letra = .Letra
                denominacion = .Denominacion

                Select Case .Cbtetipo
                    Case PRESUPUESTO
                        plantilla = My.Settings.RutaReportes & "\cbtepresupuesto.rdl"
                        copias = Convert.ToInt16(repoparametros.GetByNombre("CopiasCbtesPresupuestos").Valorpredeterminado)
                    Case Else
                        Throw New Exception("Tipo de cbte. no contemplado para la emisión")
                End Select


                r = New GeneradorReportes.Reporte

                r.SourceFile = plantilla

                'r.Nombre = .Letra & .Cbtetipo.ToString & .Cbteptovta.ToString("0000") & "-" & .Cbtenumero.ToString("00000000")

                ''id para detalle
                'r.Parametros.Add(New GeneradorReportes.Parametro("cbteid", .Id))

                ''datos del emisor
                'r.Parametros.Add(New GeneradorReportes.Parametro("NombreFantasia", repoparametros.GetByNombre("NombreDeFantasiaEmisor").Valor_param))
                'r.Parametros.Add(New GeneradorReportes.Parametro("RazonSocialEmisor", repoparametros.GetByNombre("RazonSocialEmisor").Valor_param))
                'r.Parametros.Add(New GeneradorReportes.Parametro("Email", repoparametros.GetByNombre("EmailEmisor").Valor_param))
                'r.Parametros.Add(New GeneradorReportes.Parametro("DomicilioEmisor", repoparametros.GetByNombre("DomicilioComercialEmisor").Valor_param))
                'r.Parametros.Add(New GeneradorReportes.Parametro("CondicionIvaEmisor", repoparametros.GetByNombre("CondicionIvaEmisor").Valor_param))
                'r.Parametros.Add(New GeneradorReportes.Parametro("CuitEmisor", repoparametros.GetByNombre("CuitEmisor").Valor_param))
                'r.Parametros.Add(New GeneradorReportes.Parametro("IngresosBrutos", repoparametros.GetByNombre("IngresosBrutosEmisor").Valor_param))
                'r.Parametros.Add(New GeneradorReportes.Parametro("InicioActividades", repoparametros.GetByNombre("InicioActividadesEmisor").Valor_param))

                ''cabecera
                'r.Parametros.Add(New GeneradorReportes.Parametro("CbteNumero", .Cbtenumero))
                'r.Parametros.Add(New GeneradorReportes.Parametro("CbtePtoVta", .Cbteptovta))
                'r.Parametros.Add(New GeneradorReportes.Parametro("CbteFecha", ParseStringToDate(.Cbtefecha)))
                'r.Parametros.Add(New GeneradorReportes.Parametro("CbteTipo", .Cbtetipo))
                'r.Parametros.Add(New GeneradorReportes.Parametro("Letra", letra))
                'r.Parametros.Add(New GeneradorReportes.Parametro("Denominacion", denominacion))

                ''si se trata de una factura de servicio o producto y servicio
                'If .Concepto = 2 Or .Concepto = 3 Then
                '    r.Parametros.Add(New GeneradorReportes.Parametro("FechaServicioDesde", ParseStringToDate(.Fechaserviciodesde)))
                '    r.Parametros.Add(New GeneradorReportes.Parametro("FechaServicioHasta", ParseStringToDate(.Fechaserviciohasta)))
                'End If

                'r.Parametros.Add(New GeneradorReportes.Parametro("FechaVtoPago", ParseStringToDate(.Fechavtopago)))
                'r.Parametros.Add(New GeneradorReportes.Parametro("CondicionVta", .CondicionesPago))

                ''datos del receptor
                'r.Parametros.Add(New GeneradorReportes.Parametro("RazonSocial", .Razonsocial & Space(10) & " [Cód. " & .Clienteid & "]"))
                'r.Parametros.Add(New GeneradorReportes.Parametro("CondicionIva", .Tiporesponsable))



                'r.Parametros.Add(New GeneradorReportes.Parametro("DocumentoTipo", .Documentotipo))
                'r.Parametros.Add(New GeneradorReportes.Parametro("DocumentoNro", .Documentonro))
                'r.Parametros.Add(New GeneradorReportes.Parametro("DomicilioCliente", .Domicilio))
                'r.Parametros.Add(New GeneradorReportes.Parametro("NroRemito", .Nroremito))
                'r.Parametros.Add(New GeneradorReportes.Parametro("Observaciones", .ObservacionesExtra))


                ''importes
                'r.Parametros.Add(New GeneradorReportes.Parametro("ImporteNeto", .Importeneto))
                'r.Parametros.Add(New GeneradorReportes.Parametro("ImporteTributos", .Importetributos))
                'r.Parametros.Add(New GeneradorReportes.Parametro("ImporteExento", .Importeopexentas))
                'r.Parametros.Add(New GeneradorReportes.Parametro("ImporteNoGravado", .Importetotalconceptos))
                'r.Parametros.Add(New GeneradorReportes.Parametro("ImporteTotal", .Importetotal))

                'r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA21", .Importeiva))

                ''alicuotas
                ''For Each a As Entidades.CbteAlicuota In .CbteAlicuotas
                ''    Select Case a.Codigo
                ''        Case IVA_0 '0%
                ''            r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA0", a.Importe))
                ''        Case IVA_105 '10.5%
                ''            r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA105", a.Importe))
                ''        Case IVA_21 '21%
                ''            r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA21", a.Importe))
                ''        Case IVA_27 '27%
                ''            r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA27", a.Importe))
                ''        Case IVA_5 '5%
                ''            r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA5", a.Importe))
                ''        Case IVA_25 '2.5%
                ''            r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA25", a.Importe))
                ''    End Select
                ''Next

                'Select Case .Cbtetipo
                '    Case RECIBO_COBRANZA, RECIBO_PRESUPUESTO, ORDEN_PAGO, PAGO_PRESUPUESTO
                '        r.Parametros.Add(New GeneradorReportes.Parametro("ImporteCtasPropias", .Importectaspropias))
                '        r.Parametros.Add(New GeneradorReportes.Parametro("ImporteCartera", .Importecartera))
                'End Select

                ''si es un comprobante oficial
                'If letra = "A" Or letra = "B" Or letra = "C" Then
                '    If .Cae <> "" Then
                '        r.Parametros.Add(New GeneradorReportes.Parametro("CAE", .Cae))
                '        r.Parametros.Add(New GeneradorReportes.Parametro("FechaVtoCAE", ParseStringToDate(.Fechavtocae)))
                '        r.Parametros.Add(New GeneradorReportes.Parametro("BarCode", r.CrearBarCode(.CodigoBarras)))
                '    End If
                'End If

                'r.Parametros.Add(New GeneradorReportes.Parametro("Copia", "ORIGINAL"))

                r.Nombre = .Letra & .Cbtetipo.ToString & .Cbteptovta.ToString("0000") & "-" & .Cbtenumero.ToString("00000000")

                'id para detalle
                r.Parametros.Add(New GeneradorReportes.Parametro("cbteid", .Id))

                'datos del emisor
                r.Parametros.Add(New GeneradorReportes.Parametro("NombreFantasia", repoparametros.GetByNombre("NombreDeFantasiaEmisor").Valorpredeterminado))
                r.Parametros.Add(New GeneradorReportes.Parametro("RazonSocialEmisor", repoparametros.GetByNombre("RazonSocialEmisor").Valorpredeterminado))
                r.Parametros.Add(New GeneradorReportes.Parametro("Email", repoparametros.GetByNombre("EmailEmisor").Valorpredeterminado))
                r.Parametros.Add(New GeneradorReportes.Parametro("DomicilioEmisor", repoparametros.GetByNombre("DomicilioComercialEmisor").Valorpredeterminado))
                r.Parametros.Add(New GeneradorReportes.Parametro("CondicionIvaEmisor", repoparametros.GetByNombre("CondicionIvaEmisor").Valorpredeterminado))
                r.Parametros.Add(New GeneradorReportes.Parametro("Telefono", repoparametros.GetByNombre("TelefonoContacto").Valorpredeterminado))
                r.Parametros.Add(New GeneradorReportes.Parametro("CuitEmisor", repoparametros.GetByNombre("CuitEmisor").Valorpredeterminado))
                r.Parametros.Add(New GeneradorReportes.Parametro("IngresosBrutos", repoparametros.GetByNombre("IngresosBrutosEmisor").Valorpredeterminado))
                r.Parametros.Add(New GeneradorReportes.Parametro("InicioActividades", repoparametros.GetByNombre("InicioActividadesEmisor").Valorpredeterminado))

                'cabecera
                r.Parametros.Add(New GeneradorReportes.Parametro("CbteNumero", .Cbtenumero))
                r.Parametros.Add(New GeneradorReportes.Parametro("CbtePtoVta", .Cbteptovta))
                r.Parametros.Add(New GeneradorReportes.Parametro("CbteFecha", ParseStringToDate(.Cbtefecha)))
                r.Parametros.Add(New GeneradorReportes.Parametro("CbteTipo", .Cbtetipo))
                r.Parametros.Add(New GeneradorReportes.Parametro("Letra", letra))
                r.Parametros.Add(New GeneradorReportes.Parametro("Denominacion", denominacion))

                'si se trata de una factura de servicio o producto y servicio
                If .Concepto = 2 Or .Concepto = 3 Then
                    r.Parametros.Add(New GeneradorReportes.Parametro("FechaServicioDesde", ParseStringToDate(.Fechaserviciodesde)))
                    r.Parametros.Add(New GeneradorReportes.Parametro("FechaServicioHasta", ParseStringToDate(.Fechaserviciohasta)))
                Else
                    r.Parametros.Add(New GeneradorReportes.Parametro("FechaServicioDesde", ""))
                    r.Parametros.Add(New GeneradorReportes.Parametro("FechaServicioHasta", ""))
                End If

                r.Parametros.Add(New GeneradorReportes.Parametro("FechaVtoPago", ParseStringToDate(.Fechavtopago)))

                'datos del receptor
                r.Parametros.Add(New GeneradorReportes.Parametro("RazonSocial", .Razonsocial & Space(10) & " [Cód. " & .Clienteid & "]"))
                r.Parametros.Add(New GeneradorReportes.Parametro("CondicionIva", .Tiporesponsable))

                r.Parametros.Add(New GeneradorReportes.Parametro("TelCliente", .Telefono))
                r.Parametros.Add(New GeneradorReportes.Parametro("EmailCliente", .Email))
                r.Parametros.Add(New GeneradorReportes.Parametro("Contacto", .Contacto))
                r.Parametros.Add(New GeneradorReportes.Parametro("DocumentoTipo", .Documentotipo))
                r.Parametros.Add(New GeneradorReportes.Parametro("DocumentoNro", .Documentonro))
                r.Parametros.Add(New GeneradorReportes.Parametro("DomicilioCliente", .Domicilio))
                r.Parametros.Add(New GeneradorReportes.Parametro("NroRemito", .Nroremito))
                r.Parametros.Add(New GeneradorReportes.Parametro("Observaciones", .Observaciones))

                'importes
                r.Parametros.Add(New GeneradorReportes.Parametro("ImporteNeto", .Importeneto))
                r.Parametros.Add(New GeneradorReportes.Parametro("ImporteTributos", .Importetributos))
                r.Parametros.Add(New GeneradorReportes.Parametro("ImporteExento", .Importeopexentas))
                r.Parametros.Add(New GeneradorReportes.Parametro("ImporteNoGravado", .Importetotalconceptos))
                r.Parametros.Add(New GeneradorReportes.Parametro("ImporteTotal", .Importetotal))

                'alicuotas
                r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA21", .Importeiva))

                Select Case .Cbtetipo
                    Case RECIBO_COBRANZA, RECIBO_PRESUPUESTO, ORDEN_PAGO, PAGO_PRESUPUESTO
                        r.Parametros.Add(New GeneradorReportes.Parametro("ImporteCtasPropias", .Importectaspropias))
                        r.Parametros.Add(New GeneradorReportes.Parametro("ImporteCartera", .Importecartera))
                End Select

                'si es un comprobante oficial
                If letra = "A" Or letra = "B" Or letra = "C" Then
                    If .Cae <> "" Then
                        r.Parametros.Add(New GeneradorReportes.Parametro("CAE", .Cae))
                        r.Parametros.Add(New GeneradorReportes.Parametro("FechaVtoCAE", ParseStringToDate(.Fechavtocae)))
                        r.Parametros.Add(New GeneradorReportes.Parametro("BarCode", r.CrearBarCode(.CodigoBarras)))
                    Else
                        r.Parametros.Add(New GeneradorReportes.Parametro("CAE", ""))
                        r.Parametros.Add(New GeneradorReportes.Parametro("FechaVtoCAE", ""))
                        r.Parametros.Add(New GeneradorReportes.Parametro("BarCode", ""))
                    End If
                End If

                r.Parametros.Add(New GeneradorReportes.Parametro("condicionespago", .CondicionesPago))
                r.Parametros.Add(New GeneradorReportes.Parametro("plazosentrega", .PlazosEntrega))
                r.Parametros.Add(New GeneradorReportes.Parametro("lugarentrega", .LugarEntrega))
                r.Parametros.Add(New GeneradorReportes.Parametro("mantenimientooferta", .MantenimientoOferta))

                r.Parametros.Add(New GeneradorReportes.Parametro("Copia", "ORIGINAL"))

                Return r.SaveAsPDF()

            End With


        Catch ex As Exception

            MessageBox.Show(ex.Message, "Emisión de Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return ""

        End Try
    End Function

    Public Sub EmisionCbtePres(ByVal id As UInt32, Optional ByVal preview As Boolean = False)
        Dim repositorio As New CapaLogica.CbteCabecera2CLog
        'Dim repotipodto As New CapaLogica.TipodocumentoCLog
        'Dim repoformapago As New CapaLogica.FormadepagoCLog
        'Dim repotiporesp As New CapaLogica.TiporesponsableCLog
        Dim repoparametros As New CapaLogica.ParametroCLog
        Dim cbte As New Entidades.CbteCabecera2
        Dim r As GeneradorReportes.Reporte
        Dim docTipo As String = ""
        Dim letra As String = ""
        Dim denominacion As String = ""
        Dim copias As Short = 0
        Dim plantilla As String = ""
        Dim saveAsPdf As Boolean = False

        Try

            cbte = repositorio.GetById(id)

            If cbte Is Nothing Then
                Throw New Exception("El id de cbte solicitado no existe. ID " & id.ToString)
            End If

            'parametros
            With cbte

                letra = .Letra
                denominacion = .Denominacion

                Select Case .Cbtetipo
                    'Case FACTURA_A, FACTURA_B, PRESUPUESTO, NOTA_CREDITO_A, NOTA_CREDITO_B, NOTA_DEBITO_A, NOTA_DEBITO_B, DEVOLUCION_PRESUPUESTO
                    '    Select Case letra
                    '        Case "A"
                    '            plantilla = My.Settings.RutaReportes & "\cbtea.rdl"
                    '            copias = Convert.ToInt16(repoparametros.GetByNombre("CopiasCbtesElectronicosA").Valorpredeterminado)
                    '        Case "B"
                    '            plantilla = My.Settings.RutaReportes & "\cbteb.rdl"
                    '            copias = Convert.ToInt16(repoparametros.GetByNombre("CopiasCbtesElectronicosA").Valorpredeterminado)
                    '        Case Else
                    '            plantilla = My.Settings.RutaReportes & "\cbtex.rdl"
                    '            copias = Convert.ToInt16(repoparametros.GetByNombre("CopiasCbtesPresupuestos").Valorpredeterminado)
                    '    End Select
                    Case PRESUPUESTO
                        plantilla = My.Settings.RutaReportes & "\cbtepresupuesto.rdl"
                        copias = Convert.ToInt16(repoparametros.GetByNombre("CopiasCbtesPresupuestos").Valorpredeterminado)
                    Case Else
                        Throw New Exception("Tipo de cbte. no contemplado para la emisión")
                End Select

                If Not preview Then copias = GetCopias(cbte)

                If preview Then
                    copias = 1
                Else
                    If copias = 0 Then
                        saveAsPdf = True
                        copias = 1
                    End If
                End If

                For copia As Integer = 1 To copias


                    r = New GeneradorReportes.Reporte

                    r.SourceFile = plantilla

                    r.Nombre = .Letra & .Cbtetipo.ToString & .Cbteptovta.ToString("0000") & "-" & .Cbtenumero.ToString("00000000")

                    'id para detalle
                    r.Parametros.Add(New GeneradorReportes.Parametro("cbteid", .Id))

                    'datos del emisor
                    r.Parametros.Add(New GeneradorReportes.Parametro("NombreFantasia", repoparametros.GetByNombre("NombreDeFantasiaEmisor").Valorpredeterminado))
                    r.Parametros.Add(New GeneradorReportes.Parametro("RazonSocialEmisor", repoparametros.GetByNombre("RazonSocialEmisor").Valorpredeterminado))
                    r.Parametros.Add(New GeneradorReportes.Parametro("Email", repoparametros.GetByNombre("EmailEmisor").Valorpredeterminado))
                    r.Parametros.Add(New GeneradorReportes.Parametro("DomicilioEmisor", repoparametros.GetByNombre("DomicilioComercialEmisor").Valorpredeterminado))
                    r.Parametros.Add(New GeneradorReportes.Parametro("CondicionIvaEmisor", repoparametros.GetByNombre("CondicionIvaEmisor").Valorpredeterminado))
                    r.Parametros.Add(New GeneradorReportes.Parametro("CuitEmisor", repoparametros.GetByNombre("CuitEmisor").Valorpredeterminado))
                    r.Parametros.Add(New GeneradorReportes.Parametro("Telefono", repoparametros.GetByNombre("TelefonoContacto").Valorpredeterminado))
                    r.Parametros.Add(New GeneradorReportes.Parametro("IngresosBrutos", repoparametros.GetByNombre("IngresosBrutosEmisor").Valorpredeterminado))
                    r.Parametros.Add(New GeneradorReportes.Parametro("InicioActividades", repoparametros.GetByNombre("InicioActividadesEmisor").Valorpredeterminado))

                    'r.Parametros.Add(New GeneradorReportes.Parametro("NombreFantasia", repoparametros.GetByNombre("NombreDeFantasiaEmisor").Valorpredeterminado))
                    'r.Parametros.Add(New GeneradorReportes.Parametro("RazonSocialEmisor", repoparametros.GetByNombre("RazonSocialEmisor").Valorpredeterminado))
                    'r.Parametros.Add(New GeneradorReportes.Parametro("Email", repoparametros.GetByNombre("EmailEmisor").Valorpredeterminado))
                    'r.Parametros.Add(New GeneradorReportes.Parametro("DomicilioEmisor", repoparametros.GetByNombre("DomicilioComercialEmisor").Valorpredeterminado))
                    'r.Parametros.Add(New GeneradorReportes.Parametro("CondicionIvaEmisor", repoparametros.GetByNombre("CondicionIvaEmisor").Valorpredeterminado))
                    'r.Parametros.Add(New GeneradorReportes.Parametro("CuitEmisor", .Cuitemisor))
                    'r.Parametros.Add(New GeneradorReportes.Parametro("IngresosBrutos", repoparametros.GetByNombre("IngresosBrutosEmisor").Valorpredeterminado))
                    'r.Parametros.Add(New GeneradorReportes.Parametro("InicioActividades", repoparametr

                    'cabecera
                    r.Parametros.Add(New GeneradorReportes.Parametro("CbteNumero", .Cbtenumero))
                    r.Parametros.Add(New GeneradorReportes.Parametro("CbtePtoVta", .Cbteptovta))
                    r.Parametros.Add(New GeneradorReportes.Parametro("CbteFecha", ParseStringToDate(.Cbtefecha)))
                    r.Parametros.Add(New GeneradorReportes.Parametro("CbteTipo", .Cbtetipo))
                    r.Parametros.Add(New GeneradorReportes.Parametro("Letra", letra))
                    r.Parametros.Add(New GeneradorReportes.Parametro("Denominacion", denominacion))

                    'si se trata de una factura de servicio o producto y servicio
                    If .Concepto = 2 Or .Concepto = 3 Then
                        r.Parametros.Add(New GeneradorReportes.Parametro("FechaServicioDesde", ParseStringToDate(.Fechaserviciodesde)))
                        r.Parametros.Add(New GeneradorReportes.Parametro("FechaServicioHasta", ParseStringToDate(.Fechaserviciohasta)))
                    Else
                        r.Parametros.Add(New GeneradorReportes.Parametro("FechaServicioDesde", ""))
                        r.Parametros.Add(New GeneradorReportes.Parametro("FechaServicioHasta", ""))
                    End If

                    r.Parametros.Add(New GeneradorReportes.Parametro("FechaVtoPago", ParseStringToDate(.Fechavtopago)))
                    'r.Parametros.Add(New GeneradorReportes.Parametro("CondicionVta", "CONTADO"))
                    'r.Parametros.Add(New GeneradorReportes.Parametro("CondicionVta", repoformapago.GetById(.Formadepago).Nombre))

                    'datos del receptor
                    r.Parametros.Add(New GeneradorReportes.Parametro("RazonSocial", .Razonsocial & Space(10) & " [Cód. " & .Clienteid & "]"))
                    r.Parametros.Add(New GeneradorReportes.Parametro("CondicionIva", .Tiporesponsable))

                    r.Parametros.Add(New GeneradorReportes.Parametro("TelCliente", .Telefono))
                    r.Parametros.Add(New GeneradorReportes.Parametro("EmailCliente", .Email))
                    r.Parametros.Add(New GeneradorReportes.Parametro("Contacto", .Contacto))
                    r.Parametros.Add(New GeneradorReportes.Parametro("DocumentoTipo", .Documentotipo))
                    r.Parametros.Add(New GeneradorReportes.Parametro("DocumentoNro", .Documentonro))
                    r.Parametros.Add(New GeneradorReportes.Parametro("DomicilioCliente", .Domicilio))
                    r.Parametros.Add(New GeneradorReportes.Parametro("NroRemito", .Nroremito))
                    r.Parametros.Add(New GeneradorReportes.Parametro("Observaciones", .Observaciones))

                    'importes
                    r.Parametros.Add(New GeneradorReportes.Parametro("ImporteNeto", .Importeneto))
                    r.Parametros.Add(New GeneradorReportes.Parametro("ImporteTributos", .Importetributos))
                    r.Parametros.Add(New GeneradorReportes.Parametro("ImporteExento", .Importeopexentas))
                    r.Parametros.Add(New GeneradorReportes.Parametro("ImporteNoGravado", .Importetotalconceptos))
                    r.Parametros.Add(New GeneradorReportes.Parametro("ImporteTotal", .Importetotal))

                    'alicuotas
                    r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA21", .Importeiva))
                    'For Each a As Entidades.CbteAlicuota In .CbteAlicuotas
                    '    Select Case a.Codigo
                    '        Case IVA_0 '0%
                    '            r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA0", a.Importe))
                    '        Case IVA_105 '10.5%
                    '            r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA105", a.Importe))
                    '        Case IVA_21 '21%
                    '            r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA21", a.Importe))
                    '        Case IVA_27 '27%
                    '            r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA27", a.Importe))
                    '        Case IVA_5 '5%
                    '            r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA5", a.Importe))
                    '        Case IVA_25 '2.5%
                    '            r.Parametros.Add(New GeneradorReportes.Parametro("ImporteIVA25", a.Importe))
                    '    End Select
                    'Next

                    Select Case .Cbtetipo
                        Case RECIBO_COBRANZA, RECIBO_PRESUPUESTO, ORDEN_PAGO, PAGO_PRESUPUESTO
                            r.Parametros.Add(New GeneradorReportes.Parametro("ImporteCtasPropias", .Importectaspropias))
                            r.Parametros.Add(New GeneradorReportes.Parametro("ImporteCartera", .Importecartera))
                    End Select

                    'si es un comprobante oficial
                    If letra = "A" Or letra = "B" Or letra = "C" Then
                        If .Cae <> "" Then
                            r.Parametros.Add(New GeneradorReportes.Parametro("CAE", .Cae))
                            r.Parametros.Add(New GeneradorReportes.Parametro("FechaVtoCAE", ParseStringToDate(.Fechavtocae)))
                            r.Parametros.Add(New GeneradorReportes.Parametro("BarCode", r.CrearBarCode(.CodigoBarras)))
                        Else
                            r.Parametros.Add(New GeneradorReportes.Parametro("CAE", ""))
                            r.Parametros.Add(New GeneradorReportes.Parametro("FechaVtoCAE", ""))
                            r.Parametros.Add(New GeneradorReportes.Parametro("BarCode", ""))
                        End If
                    End If

                    Select Case copia
                        Case 1
                            r.Parametros.Add(New GeneradorReportes.Parametro("Copia", "ORIGINAL"))
                        Case 2
                            r.Parametros.Add(New GeneradorReportes.Parametro("Copia", "DUPLICADO"))
                        Case 3
                            r.Parametros.Add(New GeneradorReportes.Parametro("Copia", "TRIPLICADO"))
                        Case Else
                            r.Parametros.Add(New GeneradorReportes.Parametro("Copia", "COPIA Nº " & copia))
                    End Select

                    r.Parametros.Add(New GeneradorReportes.Parametro("condicionespago", .CondicionesPago))
                    r.Parametros.Add(New GeneradorReportes.Parametro("plazosentrega", .PlazosEntrega))
                    r.Parametros.Add(New GeneradorReportes.Parametro("lugarentrega", .LugarEntrega))
                    r.Parametros.Add(New GeneradorReportes.Parametro("mantenimientooferta", .MantenimientoOferta))

                    'If .Monedaid <> "PES" Then
                    '    'r.Parametros.Add(New GeneradorReportes.Parametro("MonedaRef", "Divisa: " & .Monedaid))
                    '    r.Parametros.Add(New GeneradorReportes.Parametro("MonedaRef", "Moneda: DOLAR"))
                    'Else
                    '    r.Parametros.Add(New GeneradorReportes.Parametro("MonedaRef", "Moneda: PESOS"))
                    'End If

                    If preview Then
                        r.ShowReport()
                    Else
                        If Not saveAsPdf Then
                            r.PrintReport(1)
                        Else
                            r.SaveAsPDF()
                        End If
                    End If

                Next

            End With



        Catch ex As Exception

            MessageBox.Show(ex.Message, "Emisión de Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Function GetCopias(ByVal cbte As Entidades.CbteCabecera2) As Short
        Dim dlg As New PrintDialog()
        Dim repositorio As New CapaLogica.ParametroCLog
        Dim repoparametros As New CapaLogica.ParametroCLog
        Try

            'dlg.Document = pd
            dlg.AllowSelection = False
            dlg.AllowSomePages = False
            dlg.AllowCurrentPage = False
            dlg.AllowPrintToFile = False
            'dlg.PrinterSettings.is()

            'Dim p As New System.Drawing.Printing.PrinterSettings
            'p.PrinterName = dlg.PrinterSettings.PrinterName

            Select Case cbte.Cbtetipo
                Case PRESUPUESTO
                    dlg.PrinterSettings.Copies = Convert.ToInt16(repoparametros.GetByNombre("CopiasCbtesPresupuestos").Valorpredeterminado)
                Case Else
                    Throw New Exception("Tipo de cbte. no contemplado para la emisión")
            End Select

            If (dlg.ShowDialog() = DialogResult.OK) Then

                Return dlg.PrinterSettings.Copies

            Else
                Return 0
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function

End Module
