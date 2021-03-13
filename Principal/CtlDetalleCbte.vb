Public Class CtlDetalleCbte

    Private AJUSTES_CUENTA_BCO As String
    Private AJUSTES_CPTO_DEUDOR As String
    Private AJUSTES_CPTO_ACREEDOR As String

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

    Const AFIP_IVA_RESPONSABLE_INSCRIPTO As Long = 1

    Const IIBB_NO_INSC_NO_OBLIGADO As Char = "3"
    Const GCIAS_NO_PASIBLE_RETENCION As Char = "P"
    Const GCIAS_INSCRIPTO_RETENCION As Char = "I"
    Const GCIAS_NO_INSCRIPTO_RETENCION As Char = "N"


    'Private CATEGORIA_CIGARRILLO As UInteger
    Private _dtoPredeterminado As Double = 0.0
    Private _verTodos As Boolean
    Property VerCuentaCta As Boolean
    Property CompraANoInscripto As Boolean
    Property AnularDepositoNro As Int32
    Private _montoNoSujetoRetIB As Double
    Private _montoMinimoRetIva As Double
    Private _NroCbteRetIB As UInteger
    Private _NroCbteRetGcia As UInteger
    Private _NroCbteRetIva As UInteger

    Private _repositorio As New CapaLogica.OrdencompracabCLog
    Private _ListaNroOrden As New List(Of Entidades.OrdenCompracab)
    Private strOrdenCompra As String
    Dim mblnPrecargaRemito As Boolean

    'totalizadores del comprobante
    Private _cantidad As Double = 0.0
    ReadOnly Property Cantidad As Double
        Get
            Return _cantidad
        End Get
    End Property

    'totalizadores del comprobante
    Private _subtotal As Double = 0.0
    ReadOnly Property Subtotal As Double
        Get
            Return _subtotal
        End Get
    End Property

    Private _noinscripto As Double = 0.0
    ReadOnly Property Noinscripto As Double
        Get
            Return _noinscripto
        End Get
    End Property

    Private _iva As Double = 0.0
    ReadOnly Property Iva As Double
        Get
            Return _iva
        End Get
    End Property

    Private _otrostributos As Double = 0.0
    ReadOnly Property OtrosTributos As Double
        Get
            Return _otrostributos
        End Get
    End Property

    Private _exento As Double = 0.0
    ReadOnly Property Exento As Double
        Get
            Return _exento
        End Get
    End Property

    Private _nogravado As Double = 0.0
    ReadOnly Property NoGravado As Double
        Get
            Return _nogravado
        End Get
    End Property

    Private _total As Double = 0.0
    ReadOnly Property Total As Double
        Get
            Return _total
        End Get
    End Property

    Private _totalaplicado As Double = 0.0
    ReadOnly Property TotalAplicado As Double
        Get
            Return _totalaplicado
        End Get
    End Property

    Private _totalctaspropias As Double = 0.0
    ReadOnly Property TotalCtasPropias As Double
        Get
            Return _totalctaspropias
        End Get
    End Property

    Private _totalcartera As Double = 0.0
    ReadOnly Property TotalCartera As Double
        Get
            Return _totalcartera
        End Get
    End Property

    Private _articulos As New List(Of Entidades.CbteArticulo)
    ReadOnly Property Articulos As List(Of Entidades.CbteArticulo)
        Get
            Return _articulos
        End Get
    End Property

    Private _alicuotas As New List(Of Entidades.CbteAlicuota)
    ReadOnly Property Alicuotas As List(Of Entidades.CbteAlicuota)
        Get
            Return _alicuotas
        End Get
    End Property

    Private _importes As New List(Of Importes)
    ReadOnly Property Importes As List(Of Importes)
        Get
            Return _importes
        End Get
    End Property

    Private _tributos As New List(Of Entidades.CbteTributo)
    ReadOnly Property Tributos As List(Of Entidades.CbteTributo)
        Get
            Return _tributos
        End Get
    End Property

    Private _cbtesasociados As New List(Of Entidades.CbteAsociado)
    ReadOnly Property CbtesAsociados As List(Of Entidades.CbteAsociado)
        Get
            Return _cbtesasociados
        End Get
    End Property

    Private _cuentaspropias As New List(Of Entidades.Financiero)
    ReadOnly Property Cuentaspropias As List(Of Entidades.Financiero)
        Get
            Return _cuentaspropias
        End Get
    End Property

    Private _cartera As New List(Of Entidades.Financiero)
    ReadOnly Property Cartera As List(Of Entidades.Financiero)
        Get
            Return _cartera
        End Get
    End Property

    Event Totalizado()

    Private _decimalSeparator As Char
    Private _negativeSign As Char

    ReadOnly Property Observaciones As String
        Get
            Return Me.TextBoxObservaciones.Text.Trim
        End Get
    End Property

    Enum ListaPrecios
        LISTA1 = 1
        LISTA2 = 2
        LISTA3 = 3
        COSTO = 4
    End Enum

    Enum TipoCbte
        CBTEVTA = 1
        CBTECPRA = 2
    End Enum

    Property CtaBcoPredeterminada As Entidades.Cuentabancaria
    Property CptoBcoIngPredetermiando As Entidades.Conceptobancario
    Property CptoBcoEgrPredetermiando As Entidades.Conceptobancario
    Property TipoCargaCbte As TipoEmisionCbte
    Property ListaDePrecio As ListaPrecios = ListaPrecios.LISTA1
    Property TipoDeCbte As TipoCbte = TipoCbte.CBTEVTA
    Property MaximoItems As UInt16 = 25
    Property DescuentoGral As Double = 0.0
    Property Vendedor As Entidades.Vendedor = Nothing
    Property Cliente As Entidades.Cliente = Nothing
    Property Proveedor As Entidades.Proveedor = Nothing
    Property AgrupaArticulosDetalle As Boolean
    Property FechaComprobante As Date = Date.Today
    Private hiddenPages As New List(Of TabPage)

    Private Sub EnablePage(ByVal page As TabPage, ByVal enable As Boolean)
        If (enable) Then
            Me.TabControlDetalleCbte.TabPages.Add(page)
            hiddenPages.Remove(page)
        Else
            Me.TabControlDetalleCbte.TabPages.Remove(page)
            hiddenPages.Add(page)
        End If
    End Sub

    Public Sub Inicializar()
        mblnPrecargaRemito = False
        CrearGrillas()

        InicializarParametros()
        InicializarCombos()

        Me.TextBoxSubtotalArticulo.ReadOnly = True
        Me.TextBoxImporte.ReadOnly = (Me.TipoDeCbte = TipoCbte.CBTEVTA)
        Me.TextBoxImporteImpInt.ReadOnly = (Me.TipoDeCbte = TipoCbte.CBTEVTA)
        Me.ComboBoxArticuloAlicuota.Enabled = Not (Me.TipoDeCbte = TipoCbte.CBTEVTA)

        Select Case Me.TipoCargaCbte
            Case TipoEmisionCbte.RECIBO, TipoEmisionCbte.RECIBO_PRESUPUESTO, TipoEmisionCbte.RECIBO_NO_FISCAL, TipoEmisionCbte.ORDEN_DE_PAGO, TipoEmisionCbte.PAGO_PRESUPUESTO, TipoEmisionCbte.AJUSTE_ACREEDOR, TipoEmisionCbte.AJUSTE_DEUDOR

                EnablePage(TabPageArt, False)
                'EnablePage(TabPageObs, False)
                EnablePage(TabPageAlicuotas, False)
                EnablePage(TabPageImportes, False)

                If Me.TipoCargaCbte = TipoEmisionCbte.PAGO_PRESUPUESTO Or Me.TipoCargaCbte = TipoEmisionCbte.ORDEN_DE_PAGO Then
                    Me.TableLayoutPanelCartera.RowStyles(0).SizeType = SizeType.Absolute
                    Me.TableLayoutPanelCartera.RowStyles(0).Height = 0
                End If

                If Me.TipoCargaCbte = TipoEmisionCbte.AJUSTE_ACREEDOR Or Me.TipoCargaCbte = TipoEmisionCbte.AJUSTE_DEUDOR Then
                    EnablePage(TabPageCartera, False)
                    EnablePage(TabPageImportes, False)
                    EnablePage(TabPageOtros, False)
                End If


            Case TipoEmisionCbte.DEPOSITO_CARTERA

                EnablePage(TabPageArt, False)
                EnablePage(TabPageObs, False)
                EnablePage(TabPageAlicuotas, False)
                EnablePage(TabPageCtasPropias, False)
                EnablePage(TabPageOtros, False)
                EnablePage(TabPageCompAsoc, False)
                EnablePage(TabPageImportes, False)
                Me.TableLayoutPanelCartera.RowStyles(0).SizeType = SizeType.Absolute
                Me.TableLayoutPanelCartera.RowStyles(0).Height = 0

            Case Else

                EnablePage(TabPageCartera, False)
                EnablePage(TabPageCtasPropias, False)

                If Me.TipoDeCbte <> TipoCbte.CBTECPRA Then
                    EnablePage(TabPageImportes, False)
                Else
                    EnablePage(TabPageOtros, False)
                    EnablePage(TabPageAlicuotas, False)
                End If


                'TabControlDetalleCbte.SelectedTab = TabPageArt

        End Select



    End Sub

    Public Sub Limpiar()

        'articulos
        For Each c As Control In Me.PanelCabecera.Controls
            Select Case c.GetType
                Case GetType(TextBox) : DirectCast(c, TextBox).Text = ""
                Case GetType(ComboBox) : DirectCast(c, ComboBox).SelectedIndex = -1
                Case GetType(CheckBox) : DirectCast(c, CheckBox).Checked = False
                Case GetType(DateTimePicker) : DirectCast(c, DateTimePicker).Value = Date.Now
                Case GetType(GroupBox)
                    For Each g As Control In c.Controls
                        Select Case g.GetType
                            Case GetType(TextBox) : DirectCast(g, TextBox).Text = ""
                            Case GetType(ComboBox) : DirectCast(g, ComboBox).SelectedIndex = -1
                            Case GetType(CheckBox) : DirectCast(g, CheckBox).Checked = False
                        End Select
                    Next
            End Select
        Next

        'tributos
        For Each c As Control In Me.PanelCabeceraTributos.Controls
            Select Case c.GetType
                Case GetType(TextBox) : DirectCast(c, TextBox).Text = ""
                Case GetType(ComboBox) : DirectCast(c, ComboBox).SelectedIndex = -1
                Case GetType(CheckBox) : DirectCast(c, CheckBox).Checked = False
                Case GetType(DateTimePicker) : DirectCast(c, DateTimePicker).Value = Date.Now
                Case GetType(GroupBox)
                    For Each g As Control In c.Controls
                        Select Case g.GetType
                            Case GetType(TextBox) : DirectCast(g, TextBox).Text = ""
                            Case GetType(ComboBox) : DirectCast(g, ComboBox).SelectedIndex = -1
                            Case GetType(CheckBox) : DirectCast(g, CheckBox).Checked = False
                        End Select
                    Next
            End Select
        Next

        'ctas propias
        For Each c As Control In Me.PanelCabeceraCtasPropias.Controls
            Select Case c.GetType
                Case GetType(TextBox) : DirectCast(c, TextBox).Text = ""
                Case GetType(ComboBox) : DirectCast(c, ComboBox).SelectedIndex = -1
                Case GetType(CheckBox) : DirectCast(c, CheckBox).Checked = False
                Case GetType(DateTimePicker) : DirectCast(c, DateTimePicker).Value = Date.Now
                Case GetType(GroupBox)
                    For Each g As Control In c.Controls
                        Select Case g.GetType
                            Case GetType(TextBox) : DirectCast(g, TextBox).Text = ""
                            Case GetType(ComboBox) : DirectCast(g, ComboBox).SelectedIndex = -1
                            Case GetType(CheckBox) : DirectCast(g, CheckBox).Checked = False
                        End Select
                    Next
            End Select
        Next

        'cartera
        For Each c As Control In Me.PanelCabeceraCartera.Controls
            Select Case c.GetType
                Case GetType(TextBox) : DirectCast(c, TextBox).Text = ""
                Case GetType(ComboBox) : DirectCast(c, ComboBox).SelectedIndex = -1
                Case GetType(CheckBox) : DirectCast(c, CheckBox).Checked = False
                Case GetType(DateTimePicker) : DirectCast(c, DateTimePicker).Value = Date.Now
                Case GetType(GroupBox)
                    For Each g As Control In c.Controls
                        Select Case g.GetType
                            Case GetType(TextBox) : DirectCast(g, TextBox).Text = ""
                            Case GetType(ComboBox) : DirectCast(g, ComboBox).SelectedIndex = -1
                            Case GetType(CheckBox) : DirectCast(g, CheckBox).Checked = False
                        End Select
                    Next
            End Select
        Next

        _articulos.Clear()
        _alicuotas.Clear()
        _tributos.Clear()
        _cbtesasociados.Clear()
        _cuentaspropias.Clear()
        _cartera.Clear()
        _importes.Clear()

        'articulos cabecera
        Me.ComboBoxArticulos.SelectedIndex = -1
        Me.TextBoxCantidad.Text = 1
        Me.TextBoxImporte.Text = 0.0
        Me.TextBoxImporteImpInt.Text = 0.0
        Me.TextBoxDto.Text = 0.0
        Me.ComboBoxArticuloAlicuota.SelectedIndex = -1
        'tributos cabecera
        Me.ComboBoxTributos.SelectedIndex = -1
        Me.ComboBoxDescTributo.Text = ""
        Me.TextBoxImporteTributo.Text = 0.0
        Me.TextBoxBaseTributo.Text = 0.0
        Me.TextBoxTributoAlic.Text = 0.0
        'asociados cabecera
        _verTodos = False
        Me.CheckBoxVerTodos.Checked = _verTodos
        Me.CheckBoxCtaCte.Checked = VerCuentaCta
        Me.ComboBoxAsoc.DataSource = Nothing
        Me.ComboBoxAsoc.SelectedIndex = -1
        Me.TextBoxImporteAsoc.Text = 0.0
        'ctas propias, seteos los valores predeterminados
        Select Case Me.TipoCargaCbte
            Case TipoEmisionCbte.RECIBO, TipoEmisionCbte.RECIBO_PRESUPUESTO, TipoEmisionCbte.RECIBO_NO_FISCAL

                If Me.CtaBcoPredeterminada IsNot Nothing Then
                    Me.ComboBoxCtaBancaria.SelectedValue = Me.CtaBcoPredeterminada.Codigo
                Else
                    Me.ComboBoxCtaBancaria.SelectedIndex = -1
                End If

                If Me.CptoBcoIngPredetermiando IsNot Nothing Then
                    Me.ComboBoxConceptoBancario.SelectedValue = Me.CptoBcoIngPredetermiando.Codigo
                Else
                    Me.ComboBoxConceptoBancario.SelectedIndex = -1
                End If

            Case TipoEmisionCbte.AJUSTE_ACREEDOR


                Me.ComboBoxCtaBancaria.SelectedValue = AJUSTES_CUENTA_BCO
                Me.ComboBoxConceptoBancario.SelectedValue = AJUSTES_CPTO_ACREEDOR

            Case TipoEmisionCbte.AJUSTE_DEUDOR


                Me.ComboBoxCtaBancaria.SelectedValue = AJUSTES_CUENTA_BCO
                Me.ComboBoxConceptoBancario.SelectedValue = AJUSTES_CPTO_DEUDOR

            Case TipoEmisionCbte.ORDEN_DE_PAGO, TipoEmisionCbte.PAGO_PRESUPUESTO

                If Me.CtaBcoPredeterminada IsNot Nothing Then
                    Me.ComboBoxCtaBancaria.SelectedValue = Me.CtaBcoPredeterminada.Codigo
                Else
                    Me.ComboBoxCtaBancaria.SelectedIndex = -1
                End If

                If Me.CptoBcoEgrPredetermiando IsNot Nothing Then
                    Me.ComboBoxConceptoBancario.SelectedValue = Me.CptoBcoEgrPredetermiando.Codigo
                Else
                    Me.ComboBoxConceptoBancario.SelectedIndex = -1
                End If

            Case Else
                Me.ComboBoxConceptoBancario.SelectedIndex = -1
                Me.ComboBoxCtaBancaria.SelectedIndex = -1
        End Select

        Me.TextBoxImporteCtaPropia.Text = 0.0
        Me.TextBoxReferencia.Text = ""
        Me.DateTimePickerEfectivizacion.Value = Date.Today
        'cartera
        Me.ComboBoxBancos.SelectedIndex = -1
        Me.ComboBoxLocalidad.SelectedIndex = -1
        Me.TextBoxImporteCartera.Text = 0.0
        Me.TextBoxReferenciaCartera.Text = ""
        Me.DateTimePickerFechaCheque.Value = Date.Today
        Me.TextBoxCUITLibrador.Text = ""
        Me.TextBoxDador.Text = ""

        'observaciones
        Me.TextBoxObservaciones.Text = ""

        InicializarParametros()

        CargarAlicuotas()
        CargarImportes()

        Select Case Me.TipoCargaCbte
            Case TipoEmisionCbte.DEPOSITO_CARTERA, TipoEmisionCbte.PAGO_PRESUPUESTO, TipoEmisionCbte.ORDEN_DE_PAGO
                CargarCartera()
        End Select

        'If Me.TipoCargaCbte = TipoEmisionCbte.PAGO_PRESUPUESTO Or Me.TipoCargaCbte = TipoEmisionCbte.ORDEN_DE_PAGO Or TipoEmisionCbte.DEPOSITO_CARTERA Then

        '    CargarCartera()

        'End If

        PoblarGrillas()

        'limpio totales
        Totalizar()

        Select Case Me.TipoCargaCbte
            Case TipoEmisionCbte.RECIBO_NO_FISCAL, TipoEmisionCbte.RECIBO, TipoEmisionCbte.RECIBO_PRESUPUESTO, TipoEmisionCbte.ORDEN_DE_PAGO, TipoEmisionCbte.PAGO_PRESUPUESTO, TipoEmisionCbte.PAGO_PRESUPUESTO, TipoEmisionCbte.AJUSTE_ACREEDOR, TipoEmisionCbte.AJUSTE_DEUDOR
                TabControlDetalleCbte.SelectedTab = TabPageCtasPropias
            Case TipoEmisionCbte.DEPOSITO_CARTERA
                TabControlDetalleCbte.SelectedTab = TabPageCartera
            Case Else
                TabControlDetalleCbte.SelectedTab = TabPageArt
        End Select

    End Sub

    Public Sub Totalizar()

        Dim subtotal As Double = 0.0
        Dim otrostributos As Double = 0.0
        Dim iva As Double = 0.0
        Dim total As Double = 0.0
        Dim exento As Double = 0
        Dim nogravado As Double = 0
        Dim noinscripto As Double = 0
        Dim totalaplicado As Double = 0.0
        Dim totalcartera As Double = 0.0
        Dim totalctaspropias As Double = 0.0
        Dim cantidad As Double = 0.0

        If (Me.TipoCargaCbte = TipoEmisionCbte.COMPRA Or Me.TipoCargaCbte = TipoEmisionCbte.PRESUPUESTO) And Me.TipoDeCbte = TipoCbte.CBTECPRA Then

            'los totales de compras se ingresan manualmente
            _alicuotas.Clear()
            _tributos.Clear()

            Dim a As Entidades.CbteAlicuota
            Dim t As Entidades.CbteTributo

            For Each i As Importes In _importes
                Select Case i.Tipo
                    Case TiposImportes.NO_INSCRIPTO
                        noinscripto += i.Importe
                    Case TiposImportes.NETO_GRAVADO
                        subtotal += i.Importe
                    Case TiposImportes.IVA
                        iva += i.Importe

                        If i.Importe <> 0 Then
                            a = New Entidades.CbteAlicuota
                            a.Alicuota = i.Alicuota
                            a.BaseImponible = i.CalcularBaseImponible
                            a.Codigo = i.Codigo
                            a.Descripcion = Math.Round(i.Alicuota, 2).ToString & "%"
                            a.Importe = i.Importe
                            _alicuotas.Add(a)
                        End If

                    Case TiposImportes.NO_GRAVADO
                        nogravado += i.Importe
                    Case TiposImportes.EXENTO
                        exento += i.Importe
                    Case TiposImportes.TRIBUTO
                        otrostributos += i.Importe

                        If i.Importe <> 0 Then
                            t = New Entidades.CbteTributo
                            t.Alicuota = i.Alicuota
                            t.BaseImponible = i.Baseimponible
                            t.Codigo = i.Codigo
                            t.Descripcion = i.Detalle
                            t.Importe = i.Importe
                            t.Referencia = i.Referencia
                            _tributos.Add(t)
                        End If

                End Select


            Next i

            For Each o As Entidades.CbteAsociado In _cbtesasociados

                totalaplicado += o.Importe

            Next

        Else

            For Each o As Entidades.CbteArticulo In _articulos

                subtotal += o.Subtotal
                exento += o.SubtotalExento
                nogravado += o.SubtotalNoGravado
                cantidad += o.Cantidad

            Next

            For Each o As Entidades.CbteAlicuota In _alicuotas

                iva += o.Importe

            Next

            For Each o As Entidades.Financiero In _cuentaspropias

                totalctaspropias += o.Importe

            Next

            For Each o As Entidades.Financiero In _cartera

                Select Case Me.TipoCargaCbte
                    Case TipoEmisionCbte.DEPOSITO_CARTERA, TipoEmisionCbte.PAGO_PRESUPUESTO, TipoEmisionCbte.ORDEN_DE_PAGO
                        If o.Checked Then
                            totalcartera += o.Importe
                        End If
                    Case Else
                        totalcartera += o.Importe
                End Select

            Next

            For Each o As Entidades.CbteAsociado In _cbtesasociados

                totalaplicado += o.Importe

            Next

            'Cálculo de IIBB
            CalculoIngresosBrutos(subtotal, iva, totalctaspropias, totalcartera)

            If Me.TipoCargaCbte = TipoEmisionCbte.ORDEN_DE_PAGO Then
                'Cálculo de Ret. de Gcias.
                CalculoRetencionGcias(totalctaspropias, totalcartera)

                'Cálculo de Ret. de Ivas
                CalculoRetencionIvas(totalctaspropias, totalcartera)
            End If

            For Each o As Entidades.CbteTributo In _tributos

                otrostributos += o.Importe

            Next

        End If


        _subtotal = Math.Round(subtotal, 2)
        _iva = Math.Round(iva, 2)
        _otrostributos = Math.Round(otrostributos, 2)
        _exento = Math.Round(exento, 2)
        _nogravado = Math.Round(nogravado, 2)
        _totalaplicado = Math.Round(totalaplicado, 2)
        _totalctaspropias = Math.Round(totalctaspropias, 2)
        _totalcartera = Math.Round(totalcartera, 2)
        _cantidad = Math.Round(cantidad, 2)
        _noinscripto = Math.Round(noinscripto, 2)

        total = _subtotal + _iva + _otrostributos + _exento + _nogravado + _noinscripto

        _total = Math.Round(total, 2)

        RaiseEvent Totalizado()

    End Sub

    Public Sub ArticulosDelVendedor(ByVal vendedor As Entidades.Vendedor)
        Me.Vendedor = vendedor
        InicializarComboArticulos(vendedor)
    End Sub

    Public Sub CbtesDelCliente(ByVal cliente As Entidades.Cliente)
        Me.Cliente = cliente
        InicializarComboCbteCliente(cliente)

        Me.TextBoxCUITLibrador.Text = cliente.Documento
        Me.TextBoxDador.Text = cliente.Nombre
    End Sub

    Public Sub CbtesDelProveedor(ByVal proveedor As Entidades.Proveedor)
        Me.Proveedor = proveedor
        InicializarComboCbteProveedor(proveedor)

        Me.TextBoxCUITLibrador.Text = proveedor.Documento
        Me.TextBoxDador.Text = proveedor.Nombre
    End Sub

    Private Sub AgregarArticulo(ByVal plngNumero As UInt32, Optional ByVal strDetalleVarios As String = "")
        Dim e As New Entidades.CbteArticulo
        Dim a As New Entidades.CbteAlicuota
        Dim t As New Entidades.CbteTributo
        Dim art As New Entidades.Articulo
        Dim encontro As Boolean = False

        Try

            If Me.ComboBoxArticulos.SelectedItem Is Nothing Then
                Me.ComboBoxArticulos.Focus()
                Throw New Exception("El artículo seleccionado no es válido")
            End If

            'If Not IsNumeric(Me.TextBoxKgs.Text) Then
            '    Me.TextBoxKgs.Focus()
            '    Throw New Exception("Los Kgs ingresados no son válido")
            'End If

            If Not IsNumeric(Me.TextBoxCantidad.Text) Then
                Me.TextBoxCantidad.Focus()
                Throw New Exception("La cantidad ingresada no es válida")
            End If

            If Convert.ToDouble(Me.TextBoxCantidad.Text) = 0 Then
                Me.TextBoxCantidad.Focus()
                Throw New Exception("La cantidad ingresada no es válida")
            End If

            If _articulos.Count >= Me.MaximoItems And Convert.ToDouble(Me.TextBoxCantidad.Text) > 0 Then
                Me.ComboBoxArticulos.Focus()
                Throw New Exception("Se alcanzo el limite de artículos para el comprobante")
            End If

            If Not IsNumeric(Me.TextBoxImporte.Text) Then
                Me.TextBoxImporte.Focus()
                Throw New Exception("El importe ingresado no es válido")
            End If

            If Not IsNumeric(Me.TextBoxDto.Text) Then
                Me.TextBoxDto.Focus()
                Throw New Exception("El descuento ingresado no es válido")
            End If

            If Convert.ToDouble(Me.TextBoxDto.Text) < 0 Or Convert.ToDouble(Me.TextBoxDto.Text) > 100 Then
                Me.TextBoxDto.Focus()
                Throw New Exception("El descuento ingresado no es válido")
            End If

            If Me.TipoDeCbte = TipoCbte.CBTEVTA Then
                If Convert.ToDouble(Me.TextBoxDto.Text) > gUsuario.DescuentoTope And Convert.ToDouble(Me.TextBoxDto.Text) > _dtoPredeterminado Then
                    If Not AutorizarPermiso(PermisoUsuario.TOPE_DESCUENTO, Convert.ToDouble(Me.TextBoxDto.Text)) Then
                        Me.TextBoxDto.Focus()
                        Throw New Exception("El descuento ingresado supera el máximo autorizado")
                    End If
                End If
            End If

            If Not IsNumeric(Me.TextBoxImporteImpInt.Text) Then
                Me.TextBoxImporteImpInt.Focus()
                Throw New Exception("El importe para el impuesto interno ingresado no es válido")
            End If

            If Me.ComboBoxArticuloAlicuota.SelectedItem Is Nothing Then
                Me.ComboBoxArticuloAlicuota.Focus()
                Throw New Exception("La alícuota de IVA no es válida")
            End If

            If Cliente.Codigo = "" Or Cliente.Codigo Is Nothing Then
                Throw New Exception("El Cliente no es válido")
            End If

            art = DirectCast(Me.ComboBoxArticulos.SelectedItem, Entidades.Articulo)

            e.Codigo = art.Codigo
            'e.Rev = art.Rev
            e.Codcliente = Cliente.Codigo
            e.Alicuota = DirectCast(Me.ComboBoxArticuloAlicuota.SelectedItem, Entidades.Tipocondicioniva).Alicuota
            e.AlicuotaCodigo = DirectCast(Me.ComboBoxArticuloAlicuota.SelectedItem, Entidades.Tipocondicioniva).Codigo
            e.Cantidad = Convert.ToDouble(Me.TextBoxCantidad.Text)
            e.Cantidad = Math.Round(e.Cantidad, 3)
            'e.Kgs = Convert.ToDouble(Me.TextBoxKgs.Text)
            e.Kgsxunidad = 0 'Convert.ToDouble(Me.TextBoxKxU.Text)
            If plngNumero = 0 Then
                For Each Moldeo In _repositorio.GetByNumero(Me.ComboBoxNroOrden.SelectedValue)
                    e.Numero = Moldeo.Numero
                    'e.Secuencia = Moldeo.Secuencia
                Next
            Else
                e.Numero = plngNumero
                'e.Secuencia = plngSec
            End If
            'If gUsuario.Perfil = PERFIL_MOSTRADOR Then
            e.Modificable = art.Preciomodificable
            'Else
            'e.Modificable = True
            'End If

            'If Me.ComboBoxArticulos.SelectedItem IsNot Nothing Then
            e.ImpIntTasaNominal = art.Impinttasanominal
            e.ImpInterno = art.Impuestointerno
            e.Unidad = "02" ' art.Codunidad
            e.SimboloUnidad = "UN" 'art.SimboloUnidad
            'End If

            e.Descuento = Convert.ToDouble(Me.TextBoxDto.Text)

            'si el descuento es del 100 % se anula el imp. interno
            'If e.Descuento >= 100 Then
            '    e.ImpIntTasaNominal = 0
            '    e.ImpInterno = 0
            'End If

            If Len(Trim(strDetalleVarios)) > 0 Then
                e.Descripcion = strDetalleVarios
            Else
                e.Descripcion = DirectCast(Me.ComboBoxArticulos.SelectedItem, Entidades.Articulo).Nombre ' Me.ComboBoxArticulos.Texto
            End If

            If art.Nombrecorto.Trim.Length = 0 Then
                e.DescriptorIF = art.Nombre.Trim
            Else
                e.DescriptorIF = art.Nombrecorto.Trim
            End If


            'e.Importe = Convert.ToDouble(Me.TextBoxImporte.Text)
            'e.Importe = e.Importe '?

            e.Listadeprecio = ListaDePrecio

            'x Si Viene del Remito
            e.Importe = Val(Me.TextBoxImporte.Text)

            If Me.TipoDeCbte = TipoCbte.CBTEVTA Then
                If e.Importe = 0 Then
                    Select Case ListaDePrecio
                        Case ListaPrecios.LISTA1
                            e.Importe = art.BasicoLista1
                        Case ListaPrecios.LISTA2
                            e.Importe = art.BasicoLista2
                        Case ListaPrecios.LISTA3
                            e.Importe = art.BasicoLista3
                        Case ListaPrecios.COSTO
                            e.Importe = art.Preciodecosto
                            e.Comision = 0
                        Case Else
                            e.Importe = art.BasicoLista1
                    End Select

                    'si se trata del ingreso de un articulo modificable tomo
                    'el precio de venta que se ingreso manualmente
                    'If e.Modificable Then
                    ' e.Importe = Convert.ToDouble(Me.TextBoxImporte.Text)
                    'End If
                End If
            Else 'cbtecpra
                e.Importe = Convert.ToDouble(Me.TextBoxImporte.Text) 'art.Preciodecosto
                e.ImpInterno = Convert.ToDouble(Me.TextBoxImporteImpInt.Text) 'art.Preciodecosto
            End If

            a.Codigo = e.AlicuotaCodigo
            a.Descripcion = DirectCast(Me.ComboBoxArticuloAlicuota.SelectedItem, Entidades.Tipocondicioniva).Descripcion
            a.BaseImponible = e.Subtotal
            a.Importe = Math.Round(a.BaseImponible * (e.Alicuota / 100), 3, MidpointRounding.ToEven)

            If AgrupaArticulosDetalle Or e.Cantidad < 0 Then

                encontro = False

                For Each articulo As Entidades.CbteArticulo In _articulos
                    If e.Codigo = articulo.Codigo And e.Importe = articulo.Importe And e.Alicuota = articulo.Alicuota And e.Descripcion = articulo.Descripcion And e.Descuento = articulo.Descuento Then

                        If articulo.Unidad = "01" Then
                            If articulo.Kgs + e.Kgs <= 0 Or articulo.Cantidad + e.Cantidad <= 0 Then
                                QuitarArticulo(articulo)
                                GoTo Final
                            Else
                                articulo.Kgs += e.Kgs
                                articulo.Cantidad += e.Cantidad
                            End If
                        Else
                            If articulo.Cantidad + e.Cantidad <= 0 Then
                                QuitarArticulo(articulo)
                                GoTo Final
                            Else
                                articulo.Cantidad += e.Cantidad
                            End If
                        End If

                        encontro = True
                        Exit For
                    End If
                Next

                If (e.Cantidad < 0 Or e.Kgs < 0) And Not encontro Then
                    Throw New Exception("No existe un artículo previo para descontar. Verifique artículo y precio del artículo")
                End If

                If Not encontro Then
                    _articulos.Add(e)
                End If

            Else
                _articulos.Add(e)
            End If



            For Each o As Entidades.CbteAlicuota In _alicuotas
                If o.Codigo = a.Codigo Then
                    o.Importe += a.Importe
                    o.BaseImponible += a.BaseImponible
                End If
            Next

            'pretotalizo los importes de compras

            If (Me.TipoCargaCbte = TipoEmisionCbte.COMPRA Or Me.TipoCargaCbte = TipoEmisionCbte.PRESUPUESTO) And Me.TipoDeCbte = TipoCbte.CBTECPRA Then

                For Each o As Importes In _importes
                    Select Case o.Tipo
                        Case TiposImportes.EXENTO
                            o.Importe += e.SubtotalExento
                        Case TiposImportes.NO_GRAVADO
                            o.Importe += e.SubtotalNoGravado
                        Case TiposImportes.NETO_GRAVADO
                            o.Importe += e.Subtotal
                        Case TiposImportes.IVA
                            If o.Codigo = e.AlicuotaCodigo.ToString Then
                                o.Importe += e.SubtotalIVA
                            End If
                        Case TiposImportes.TRIBUTO
                            If o.Codigo = AFIP_COD_IMPUESTO_INTERNO Then
                                o.Importe += e.SubtotalImpuestoInterno
                            End If
                    End Select
                Next o

            End If

            If e.ImpuestoInterno > 0 Then
                t.Codigo = AFIP_COD_IMPUESTO_INTERNO
                t.Descripcion = "Impuestos internos"
                t.Importe = e.SubtotalImpuestoInterno
                t.BaseImponible = e.BaseImponibleImpInterno
                t.Alicuota = e.ImpIntTasaNominal

                AgregarTributo(t)

            End If

Final:
            PoblarGrillas()

            Totalizar()

            'articulos cabecera
            Me.ComboBoxArticulos.SelectedIndex = -1
            Me.TextBoxCantidad.Text = 1
            Me.TextBoxImporte.Text = 0.0
            Me.TextBoxImporteImpInt.Text = 0.0
            Me.TextBoxDto.Text = 0.0
            Me.ComboBoxArticuloAlicuota.SelectedIndex = -1
            Me.ComboBoxNroOrden.SelectedItem = -1

            Me.ComboBoxArticulos.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Agregar Artículo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub AgregarMaterial()
        Dim e As New Entidades.CbteArticulo
        Dim a As New Entidades.CbteAlicuota
        Dim t As New Entidades.CbteTributo
        Dim art As New Entidades.Articulo
        Dim encontro As Boolean = False

        Try

            If Me.ComboBoxArticulos.SelectedItem Is Nothing Then
                Me.ComboBoxArticulos.Focus()
                Throw New Exception("El material seleccionado no es válido")
            End If

            If Not IsNumeric(Me.TextBoxCantidad.Text) Then
                Me.TextBoxCantidad.Focus()
                Throw New Exception("La cantidad ingresada no es válida")
            End If

            If Convert.ToDouble(Me.TextBoxCantidad.Text) = 0 Then
                Me.TextBoxCantidad.Focus()
                Throw New Exception("La cantidad ingresada no es válida")
            End If

            If _articulos.Count >= Me.MaximoItems And Convert.ToDouble(Me.TextBoxCantidad.Text) > 0 Then
                Me.ComboBoxArticulos.Focus()
                Throw New Exception("Se alcanzo el limite de materiales para el comprobante")
            End If

            If Not IsNumeric(Me.TextBoxImporte.Text) Then
                Me.TextBoxImporte.Focus()
                Throw New Exception("El importe ingresado no es válido")
            End If

            If Not IsNumeric(Me.TextBoxDto.Text) Then
                Me.TextBoxDto.Focus()
                Throw New Exception("El descuento ingresado no es válido")
            End If

            If Convert.ToDouble(Me.TextBoxDto.Text) < 0 Or Convert.ToDouble(Me.TextBoxDto.Text) > 100 Then
                Me.TextBoxDto.Focus()
                Throw New Exception("El descuento ingresado no es válido")
            End If

            If Not IsNumeric(Me.TextBoxImporteImpInt.Text) Then
                Me.TextBoxImporteImpInt.Focus()
                Throw New Exception("El importe para el impuesto interno ingresado no es válido")
            End If

            If Me.ComboBoxArticuloAlicuota.SelectedItem Is Nothing Then
                Me.ComboBoxArticuloAlicuota.Focus()
                Throw New Exception("La alícuota de IVA no es válida")
            End If

            art = DirectCast(Me.ComboBoxArticulos.SelectedItem, Entidades.Articulo)

            e.Alicuota = DirectCast(Me.ComboBoxArticuloAlicuota.SelectedItem, Entidades.Tipocondicioniva).Alicuota
            e.AlicuotaCodigo = DirectCast(Me.ComboBoxArticuloAlicuota.SelectedItem, Entidades.Tipocondicioniva).Codigo
            e.Cantidad = Convert.ToDouble(Me.TextBoxCantidad.Text)
            e.Cantidad = Math.Round(e.Cantidad, 3)
            e.Kgs = e.Cantidad
            e.Modificable = True
            'If Me.ComboBoxArticulos.SelectedItem IsNot Nothing Then
            e.Codigo = art.Codigo
            e.ImpIntTasaNominal = 0
            e.ImpInterno = 0
            e.Unidad = art.Codunidad

            e.SimboloUnidad = art.SimboloUnidad
            'End If

            e.Descuento = Convert.ToDouble(Me.TextBoxDto.Text)

            e.Descripcion = Me.ComboBoxArticulos.Texto

            e.DescriptorIF = art.Nombre.Trim

            e.Listadeprecio = ListaDePrecio

            e.Importe = Convert.ToDouble(Me.TextBoxImporte.Text) 'art.Preciodecosto
            e.ImpInterno = Convert.ToDouble(Me.TextBoxImporteImpInt.Text) 'art.Preciodecosto

            a.Codigo = e.AlicuotaCodigo
            a.Descripcion = DirectCast(Me.ComboBoxArticuloAlicuota.SelectedItem, Entidades.Tipocondicioniva).Descripcion
            a.BaseImponible = e.Subtotal
            a.Importe = Math.Round(a.BaseImponible * (e.Alicuota / 100), 3, MidpointRounding.ToEven)

            If AgrupaArticulosDetalle Or e.Cantidad < 0 Then

                encontro = False

                For Each articulo As Entidades.CbteArticulo In _articulos
                    If e.Codigo = articulo.Codigo And e.Importe = articulo.Importe And e.Alicuota = articulo.Alicuota And e.Descripcion = articulo.Descripcion And e.Descuento = articulo.Descuento Then

                        If articulo.Cantidad + e.Cantidad <= 0 Then
                            QuitarArticulo(articulo)
                            GoTo Final
                        Else
                            articulo.Cantidad += e.Cantidad
                        End If

                        encontro = True
                        Exit For
                    End If
                Next

                If e.Cantidad < 0 And Not encontro Then
                    Throw New Exception("No existe un material previo para descontar. Verifique artículo y precio del material")
                End If

                If Not encontro Then
                    _articulos.Add(e)
                End If

            Else
                _articulos.Add(e)
            End If

            For Each o As Entidades.CbteAlicuota In _alicuotas
                If o.Codigo = a.Codigo Then
                    o.Importe += a.Importe
                    o.BaseImponible += a.BaseImponible
                End If
            Next

            'pretotalizo los importes de compras

            If (Me.TipoCargaCbte = TipoEmisionCbte.COMPRA Or Me.TipoCargaCbte = TipoEmisionCbte.PRESUPUESTO) And Me.TipoDeCbte = TipoCbte.CBTECPRA Then

                For Each o As Importes In _importes
                    Select Case o.Tipo
                        Case TiposImportes.EXENTO
                            o.Importe += e.SubtotalExento
                        Case TiposImportes.NO_GRAVADO
                            o.Importe += e.SubtotalNoGravado
                        Case TiposImportes.NETO_GRAVADO
                            o.Importe += e.Subtotal
                        Case TiposImportes.IVA
                            If o.Codigo = e.AlicuotaCodigo.ToString Then
                                o.Importe += e.SubtotalIVA
                            End If
                        Case TiposImportes.TRIBUTO
                            If o.Codigo = AFIP_COD_IMPUESTO_INTERNO Then
                                o.Importe += e.SubtotalImpuestoInterno
                            End If
                    End Select
                Next o

            End If

            If e.ImpuestoInterno > 0 Then
                t.Codigo = AFIP_COD_IMPUESTO_INTERNO
                t.Descripcion = "Impuestos internos"
                t.Importe = e.SubtotalImpuestoInterno
                t.BaseImponible = e.BaseImponibleImpInterno
                t.Alicuota = e.ImpIntTasaNominal

                AgregarTributo(t)

            End If

Final:
            PoblarGrillas()

            Totalizar()

            'articulos cabecera
            Me.ComboBoxArticulos.SelectedIndex = -1
            Me.TextBoxCantidad.Text = 1
            Me.TextBoxImporte.Text = 0.0
            Me.TextBoxImporteImpInt.Text = 0.0
            Me.TextBoxDto.Text = 0.0
            Me.ComboBoxArticuloAlicuota.SelectedIndex = -1

            Me.ComboBoxArticulos.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Agregar Artículo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub AgregarTributo(ByVal tributo As Entidades.CbteTributo, Optional ByVal reemplazar As Boolean = False)

        Dim encontro As Boolean = False

        For Each o As Entidades.CbteTributo In _tributos
            If o.Codigo = tributo.Codigo And o.Alicuota = tributo.Alicuota And o.Descripcion = tributo.Descripcion And o.Referencia = tributo.Referencia Then

                If reemplazar Then
                    o.Importe = tributo.Importe
                    o.BaseImponible = tributo.BaseImponible
                Else
                    o.Importe += tributo.Importe
                    o.BaseImponible += tributo.BaseImponible
                End If
                encontro = True
                Exit For
            End If
        Next

        If Not encontro Then
            _tributos.Add(tributo)
        End If



    End Sub

    Private Sub AgregarCbteAsoc(ByVal cbteasoc As Entidades.CbteAsociado)

        Dim encontro As Boolean = False

        For Each o As Entidades.CbteAsociado In _cbtesasociados
            If o.Tipo = cbteasoc.Tipo And o.PtoVta = cbteasoc.PtoVta And o.Numero = cbteasoc.Numero Then
                o.Importe = cbteasoc.Importe
                encontro = True
                Exit For
            End If
        Next

        If Not encontro Then
            _cbtesasociados.Add(cbteasoc)
        End If

    End Sub

    Private Sub AgregarCtaPropia(ByVal ctapropia As Entidades.Financiero)

        Dim encontro As Boolean = False

        For Each o As Entidades.Financiero In _cuentaspropias
            If o.Cuenta = ctapropia.Cuenta And o.Concepto = ctapropia.Concepto _
                And o.Efectivizacion = ctapropia.Efectivizacion And o.Referencia = ctapropia.Referencia Then
                o.Importe = ctapropia.Importe
                encontro = True
                Exit For
            End If
        Next

        If Not encontro Then
            _cuentaspropias.Add(ctapropia)
        End If

    End Sub

    Private Sub AgregarCtaCheque(ByVal cheque As Entidades.Financiero)

        Dim encontro As Boolean = False

        For Each o As Entidades.Financiero In _cartera
            If o.Cuenta = cheque.Cuenta And o.Concepto = cheque.Concepto _
                And o.Efectivizacion = cheque.Efectivizacion And o.Emision = cheque.Emision And o.Referencia = cheque.Referencia And
                o.Localidad = cheque.Localidad And o.Banco = cheque.Banco And o.DocumentoNro = cheque.DocumentoNro And o.Dador = cheque.Dador Then
                o.Importe = cheque.Importe
                encontro = True
                Exit For
            End If
        Next

        If Not encontro Then
            _cartera.Add(cheque)
        End If

    End Sub

    Private Sub PoblarGrillas()
        PoblarGrillaArticulo()
        PoblarGrillaAlicuotas()
        PoblarGrillaTributos()
        PoblarGrillaCompAsoc()
        PoblarGrillaCtasPropias()
        PoblarGrillaCartera()
        PoblarGrillaImportes()
    End Sub

    Private Sub InicializarComboOrdenCompra(Optional ByVal Limpia As Boolean = True)
        With Me.ComboBoxNroOrden
            .ValueMember = "Id"
            .DisplayMember = "Numero"
            .DataSource = _ListaNroOrden
            .DropDownStyle = ComboBoxStyle.DropDownList
            .AutoCompleteSource = AutoCompleteSource.ListItems
            If Limpia = True Then
                If _ListaNroOrden.Count > 1 Then
                    .SelectedIndex = 1
                Else
                    .SelectedIndex = 0
                End If
            Else
                .SelectedIndex = -1
            End If
        End With
    End Sub

    Private Sub InicializarComboAlicuotas()
        Dim repositorio As New CapaLogica.TipocondicionivaCLog

        With Me.ComboBoxArticuloAlicuota
            .ValueMember = "Codigo"
            .DisplayMember = "Descripcion"
            .DropDownStyle = ComboBoxStyle.DropDownList
            .DataSource = repositorio.GetAll
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub InicializarComboCbteCliente(ByVal cliente As Entidades.Cliente)

        Dim repositorio As New CapaLogica.CbtecabeceraCLog
        Dim c As BrightIdeasSoftware.OLVColumn = Nothing
        Dim cols As New List(Of BrightIdeasSoftware.OLVColumn)
        Dim cbtes As New List(Of Entidades.CbteCabecera)
        Dim asoc As Entidades.CbteAsociado

        With Me.ComboBoxAsoc

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Fecha"
            c.AspectName = "FechaEmision"
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Center
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            cols.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Fecha Vto."
            c.AspectName = "FechaVencimiento"
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Center
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            cols.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Imp. Original"
            c.AspectName = "Importetotal"
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            cols.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Saldo"
            c.AspectName = "SaldoEstadoCuenta"
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            cols.Add(c)

            .ColumnasExtras = cols

            .ValueMember = "Id"
            .DisplayMember = "CbteDenominacion"

            If Me.Cliente IsNot Nothing And VerCuentaCta Then

                For Each cbte As Entidades.CbteCabecera In repositorio.GetCbtesCtaCteByCliente(cliente:=Me.Cliente.Id, cargaAlicuotas:=False, cargaArticulos:=False, cargaAsociados:=False, cargaCtaCte:=True, cargaFinanciero:=False, cargaTributos:=False, blnverTodo:=_verTodos)
                    If Me.TipoCargaCbte = TipoEmisionCbte.PRESUPUESTO Or Me.TipoCargaCbte = TipoEmisionCbte.RECIBO_PRESUPUESTO Then
                        Select Case cbte.Cbtetipo
                            Case PRESUPUESTO
                                If cbte.SaldoEstadoCuenta <> 0 Or _verTodos Then
                                    cbtes.Add(cbte)
                                End If
                        End Select
                    Else
                        Select Case cbte.Cbtetipo
                            Case FACTURA_A, FACTURA_B, TIQUE_FACTURA_A, TIQUE_FACTURA_B, FACTURA_C, FACTURA_M, TIQUE_FACTURA_C
                                If cbte.SaldoEstadoCuenta <> 0 Or _verTodos Then
                                    cbtes.Add(cbte)
                                End If
                        End Select
                    End If

                    ShowWait()

                Next

            End If

            .DataSource = cbtes

            .DropDownStyle = ComboBoxStyle.DropDownList
            '.FormularioDeAlta = FormRepartidor
            .Inicializar()
            .SelectedIndex = -1

            _cbtesasociados.Clear()

            For Each cbte As Entidades.CbteCabecera In cbtes
                asoc = New Entidades.CbteAsociado
                asoc.Tipo = cbte.Cbtetipo
                asoc.PtoVta = cbte.Cbteptovta
                asoc.Numero = cbte.Cbtenumero
                asoc.CbteReferencia = cbte.Id
                asoc.Importe = 0
                asoc.Denominacion = cbte.CbteDenominacion
                asoc.ImporteOriginal = cbte.Importetotal
                asoc.Fecha = ParseStringToDate(cbte.Cbtefecha)
                asoc.Saldo = cbte.SaldoEstadoCuenta
                _cbtesasociados.Add(asoc)
            Next

            PoblarGrillaCompAsoc()

        End With

        HideWait()

    End Sub

    Private Sub ShowWait()

        Select Case LabelCtaCte.Text
            Case "" : LabelCtaCte.Text = "Cargando datos, espere."
            Case "Cargando datos, espere." : LabelCtaCte.Text = "Cargando datos, espere.."
            Case "Cargando datos, espere.." : LabelCtaCte.Text = "Cargando datos, espere..."
            Case Else : LabelCtaCte.Text = ""
        End Select

        Application.DoEvents()

    End Sub

    Private Sub HideWait()
        Me.LabelCtaCte.Text = ""
    End Sub

    Private Sub InicializarComboCbteProveedor(ByVal proveedor As Entidades.Proveedor)

        Dim repositorio As New CapaLogica.CpracabeceraCLog
        Dim c As BrightIdeasSoftware.OLVColumn = Nothing
        Dim cols As New List(Of BrightIdeasSoftware.OLVColumn)
        Dim cbtes As New List(Of Entidades.CpraCabecera)
        Dim asoc As Entidades.CbteAsociado

        With Me.ComboBoxAsoc

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Fecha"
            c.AspectName = "FechaEmision"
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Center
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            cols.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Imp. Original"
            c.AspectName = "Importetotal"
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            cols.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Saldo"
            c.AspectName = "SaldoEstadoCuenta"
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            cols.Add(c)

            .ColumnasExtras = cols

            .ValueMember = "Id"
            .DisplayMember = "CbteDenominacion"

            If Me.Proveedor IsNot Nothing And VerCuentaCta Then

                For Each cbte As Entidades.CpraCabecera In repositorio.GetCprasCtaCteByProveedor(Proveedor:=Me.Proveedor.Id, cargaAlicuotas:=False, cargaArticulos:=False, cargaAsociados:=False, cargaCtaCte:=True, cargaFinanciero:=False, cargaTributos:=False, blnVerTodo:=_verTodos)
                    If Me.TipoCargaCbte = TipoEmisionCbte.PRESUPUESTO Or Me.TipoCargaCbte = TipoEmisionCbte.RECIBO_PRESUPUESTO Or Me.TipoCargaCbte = TipoEmisionCbte.PAGO_PRESUPUESTO Then
                        Select Case cbte.Cbtetipo
                            Case PRESUPUESTO
                                If cbte.SaldoEstadoCuenta <> 0 Or _verTodos Then
                                    cbtes.Add(cbte)
                                End If
                        End Select
                    Else
                        Select Case cbte.Cbtetipo
                            Case FACTURA_A, FACTURA_B, TIQUE_FACTURA_A, TIQUE_FACTURA_B, FACTURA_C, FACTURA_M, TIQUE, TIQUE_FACTURA_C
                                If cbte.SaldoEstadoCuenta <> 0 Or _verTodos Then
                                    cbtes.Add(cbte)
                                End If
                        End Select
                    End If

                    ShowWait()

                Next

            End If

            .DataSource = cbtes

            .DropDownStyle = ComboBoxStyle.DropDownList
            '.FormularioDeAlta = FormRepartidor
            .Inicializar()
            .SelectedIndex = -1

            _cbtesasociados.Clear()

            For Each cbte As Entidades.CpraCabecera In cbtes
                asoc = New Entidades.CbteAsociado
                asoc.Tipo = cbte.Cbtetipo
                asoc.PtoVta = cbte.Cbteptovta
                asoc.Numero = cbte.Cbtenumero
                asoc.CbteReferencia = cbte.Id
                asoc.Importe = 0
                asoc.Denominacion = cbte.CbteDenominacion
                asoc.ImporteOriginal = cbte.Importetotal
                asoc.Fecha = ParseStringToDate(cbte.Cbtefecha)
                asoc.Saldo = cbte.SaldoEstadoCuenta
                _cbtesasociados.Add(asoc)
            Next

            PoblarGrillaCompAsoc()

        End With

        HideWait()

    End Sub

    Private Sub InicializarComboTributos()
        Dim repositorio As New CapaLogica.TipotributoCLog

        With Me.ComboBoxTributos
            .ValueMember = "Codigo"
            .DisplayMember = "Descripcion"
            .DropDownStyle = ComboBoxStyle.DropDownList
            .DataSource = repositorio.GetAll
            .SelectedIndex = -1
        End With

        With Me.ComboBoxDescTributo
            .Items.Clear()
            .Items.Add("Per./Ret. de Impuesto a las Ganancias")
            .Items.Add("Per./Ret. de IVA")
            .Items.Add("Per./Ret. de Ingresos Brutos")
            .Items.Add("Impuestos Internos")
            .Items.Add("Impuestos Municipales")
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With

    End Sub

    Private Sub InicializarComboCuentasBancarias()
        Dim repositorio As New CapaLogica.CuentabancariaCLog

        With Me.ComboBoxCtaBancaria
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            If Me.TipoCargaCbte = TipoEmisionCbte.AJUSTE_ACREEDOR Or Me.TipoCargaCbte = TipoEmisionCbte.AJUSTE_DEUDOR Then
                .DataSource = repositorio.GetAllWithValue(AJUSTES_CUENTA_BCO)
            Else
                .DataSource = repositorio.GetCuentasDisponibles
            End If
            .Inicializar()
            .SelectedIndex = -1
        End With

    End Sub

    Private Sub InicializarComboConceptosBancarios()
        Dim repositorio As New CapaLogica.ConceptobancarioCLog

        With Me.ComboBoxConceptoBancario
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems

            Select Case Me.TipoCargaCbte
                Case TipoEmisionCbte.RECIBO, TipoEmisionCbte.RECIBO_PRESUPUESTO, TipoEmisionCbte.RECIBO_NO_FISCAL, TipoEmisionCbte.AJUSTE_DEUDOR
                    .DataSource = repositorio.GetConceptosDeudores
                Case TipoEmisionCbte.ORDEN_DE_PAGO, TipoEmisionCbte.PAGO_PRESUPUESTO, TipoEmisionCbte.AJUSTE_ACREEDOR
                    .DataSource = repositorio.GetConceptosAcreedores
                Case Else
                    .DataSource = repositorio.GetAll
            End Select

            .Inicializar()


            If Me.TipoCargaCbte = TipoEmisionCbte.AJUSTE_ACREEDOR Then
                .SelectedValue = AJUSTES_CPTO_ACREEDOR
            ElseIf Me.TipoCargaCbte = TipoEmisionCbte.AJUSTE_DEUDOR Then
                .SelectedValue = AJUSTES_CPTO_DEUDOR
            Else
                .SelectedIndex = -1
            End If

        End With

    End Sub

    Public Sub InicializarComboArticulos(Optional ByVal vendedor As Entidades.Vendedor = Nothing)
        Dim repositorio As New CapaLogica.ArticuloCLog
        Dim c As BrightIdeasSoftware.OLVColumn = Nothing
        Dim cols As New List(Of BrightIdeasSoftware.OLVColumn)

        With Me.ComboBoxArticulos
            .ValueMember = "Id"
            .DisplayMember = "NombreyCodigo"
            .CustomFormatArt = True

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Codigo"
            c.AspectName = "Codigo"
            'c.MaximumWidth = 0
            c.MinimumWidth = 70
            c.UseFiltering = True
            c.Searchable = True
            'c.IsVisible = False
            cols.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Nombre / Descripción"
            c.AspectName = "NombreDescripcion"
            'c.AspectToStringConverter = Function(x As String)
            '                                Return ""
            '                            End Function
            c.UseFiltering = False
            c.MinimumWidth = 200
            c.Searchable = False
            c.FillsFreeSpace = True
            cols.Add(c)

            If Me.TipoDeCbte = TipoCbte.CBTEVTA Then

                c = New BrightIdeasSoftware.OLVColumn
                c.Text = "Precio"
                c.AspectName = "ImporteConIVALista1"
                c.AspectToStringConverter = Function(x As Double)
                                                Return x.ToString("$ #,##0.00#")
                                            End Function
                c.MinimumWidth = 75
                c.TextAlign = HorizontalAlignment.Right
                c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                cols.Add(c)
            Else
                c = New BrightIdeasSoftware.OLVColumn
                c.Text = "Pcio. Costo"
                c.AspectName = "Preciodecosto"
                c.AspectToStringConverter = Function(x As Double)
                                                Return x.ToString("$ #,##0.00#")
                                            End Function
                c.MinimumWidth = 100
                c.TextAlign = HorizontalAlignment.Right
                c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                cols.Add(c)

                c = New BrightIdeasSoftware.OLVColumn
                c.Text = "Pcio. Compra"
                c.AspectName = "Preciodecompra"
                c.AspectToStringConverter = Function(x As Double)
                                                Return x.ToString("$ #,##0.00#")
                                            End Function
                c.MinimumWidth = 100
                c.TextAlign = HorizontalAlignment.Right
                c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                cols.Add(c)

                c = New BrightIdeasSoftware.OLVColumn
                c.Text = "Ult. Compra"
                c.AspectName = "Fechaultimacompra"
                c.MinimumWidth = 100
                c.TextAlign = HorizontalAlignment.Center
                c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                cols.Add(c)

                .FormularioDeAlta = FormArticulo

            End If

            .ColumnasExtras = cols

            'If Me.TipoDeCbte = TipoCbte.CBTEVTA Then
            '    'If Cliente IsNot Nothing Then
            '    '    '.DataSource = repositorio.GetByCliente(Me.Cliente.Codigo, , True)
            '    'Else
            '    .DataSource = repositorio.GetById(0)
            '    'End If
            'Else
            .DataSource = repositorio.GetAll.OrderBy(Function(x) x.Nombre).ToList()
            'End If

            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .BusquedaPorCodigobarra = True
            .Inicializar()
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub InicializarComboMateriales()
        'Dim repositorio As New CapaLogica.MaterialcpraCLog
        'Dim c As BrightIdeasSoftware.OLVColumn = Nothing
        'Dim cols As New List(Of BrightIdeasSoftware.OLVColumn)

        'With Me.ComboBoxArticulos
        '    .ValueMember = "Codigo"
        '    .DisplayMember = "NombreyCodigo"
        '    .DataSource = repositorio.GetAll()
        '    .AutoCompleteMode = AutoCompleteMode.Suggest
        '    .AutoCompleteSource = AutoCompleteSource.ListItems
        '    .DropDownStyle = ComboBoxStyle.DropDownList
        '    .FormularioDeAlta = FormMatCpra
        '    .Inicializar()
        '    .SelectedIndex = -1
        'End With
    End Sub

    Private Sub PoblarGrillaArticulo()
        Me.FOLVArticulos.Objects = _articulos
    End Sub

    Private Sub PoblarGrillaAlicuotas()
        Me.FOLVAlicuotas.Objects = _alicuotas
    End Sub

    Private Sub PoblarGrillaImportes()
        Me.FOLVImportes.Objects = _importes
    End Sub

    Private Sub PoblarGrillaTributos()
        Me.FOLVOtrosTributos.Objects = _tributos
    End Sub

    Private Sub PoblarGrillaCompAsoc()
        Me.FOLVCompAsoc.Objects = _cbtesasociados
    End Sub

    Private Sub PoblarGrillaCtasPropias()
        Me.FOLVCtasPropias.Objects = _cuentaspropias
    End Sub

    Private Sub PoblarGrillaCartera()
        Me.FOLVCartera.Objects = _cartera
    End Sub

    Private Sub a_Vista()
        Dim blnVer As Boolean
        blnVer = True
        If Me.TipoDeCbte = TipoCbte.CBTECPRA Then
            blnVer = False
            'Reacomodo los controles
            ComboBoxArticulos.Width = 442
            lblCant.Left = ComboBoxArticulos.Width + 8
            TextBoxCantidad.Left = ComboBoxArticulos.Width + 8
        Else
            ComboBoxArticulos.Width = 352
            lblCant.Left = ComboBoxArticulos.Width + 10
            TextBoxCantidad.Left = ComboBoxArticulos.Width + 10
            'lblOc.Left = ComboBoxArticulos.Width + TextBoxCantidad.Width + 5
            'ComboBoxNroOrden.Left = ComboBoxArticulos.Width + TextBoxCantidad.Width + 5
        End If

        lblUnidad.Visible = False 'blnVer
        lblKxU.Visible = False 'blnVer
        'lblKgs.Visible = blnVer
        lblOc.Visible = blnVer

        TextBoxUnidad.Visible = False 'blnVer
        TextBoxKxU.Visible = False 'blnVer
        'TextBoxKgs.Visible = blnVer
        ComboBoxNroOrden.Visible = blnVer
    End Sub

    Private Sub CrearGrillaArticulos()

        Dim c As BrightIdeasSoftware.OLVColumn

        a_Vista()

        With FOLVArticulos

            .Columns.Clear()

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Id"
            c.AspectName = "Id"
            c.MinimumWidth = 0
            c.MaximumWidth = 0
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = False
            .Columns.Add(c)

            If Me.TipoDeCbte = TipoCbte.CBTECPRA Then
                c = New BrightIdeasSoftware.OLVColumn
                c.Text = "Cantidad"
                c.AspectName = "Cantidad"
                c.MinimumWidth = 75
                c.TextAlign = HorizontalAlignment.Right
                c.AspectToStringConverter = Function(x As Double)
                                                Return x.ToString("#,##0.00#")
                                            End Function
                'c.AspectToStringFormat = "{0.00}"
                c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                c.IsEditable = False
                .Columns.Add(c)

                c = New BrightIdeasSoftware.OLVColumn
                c.Text = "Código"
                c.AspectName = "Codigo"
                c.MinimumWidth = 80
                c.MaximumWidth = 80
                c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                c.IsEditable = False
                .Columns.Add(c)

                c = New BrightIdeasSoftware.OLVColumn
                c.Text = "Nombre/Descripción"
                c.AspectName = "Descripcion"
                c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                c.FillsFreeSpace = True
                c.IsEditable = True
                .Columns.Add(c)

                'c = New BrightIdeasSoftware.OLVColumn
                'c.Text = "Un."
                'c.AspectName = "SimboloUnidad" '"Unidad"
                'c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                'c.MinimumWidth = 40
                'c.MaximumWidth = 40
                'c.IsEditable = False
                '.Columns.Add(c)

                c = New BrightIdeasSoftware.OLVColumn
                c.Text = "Importe Final"
                c.AspectName = "ImporteBruto"
                c.MinimumWidth = 75
                c.TextAlign = HorizontalAlignment.Right
                c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                c.AspectToStringConverter = Function(x As Double)
                                                Return x.ToString("$ #,##0.00#")
                                            End Function
                c.IsEditable = False
                'c.AspectToStringFormat = "{0:C}"
                .Columns.Add(c)

                c = New BrightIdeasSoftware.OLVColumn
                c.Text = "Imp.Int"
                c.AspectName = "ImpInterno"

                c.MinimumWidth = 75
                c.TextAlign = HorizontalAlignment.Center
                c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                c.AspectToStringConverter = Function(x As Double)
                                                Return x.ToString("$ #,##0.00##")
                                            End Function
                c.IsEditable = False
                .Columns.Add(c)

                c = New BrightIdeasSoftware.OLVColumn
                c.Text = "Dto %"
                c.AspectName = "Descuento"
                c.MinimumWidth = 50
                c.TextAlign = HorizontalAlignment.Center
                c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                c.AspectToStringConverter = Function(x As Double)
                                                Return x.ToString("0.00")
                                            End Function
                c.IsEditable = False
                'c.AspectToStringFormat = "{0:C}"
                .Columns.Add(c)

                c = New BrightIdeasSoftware.OLVColumn
                c.Text = "IVA %"
                c.AspectName = "Alicuota"
                c.MinimumWidth = 50
                c.TextAlign = HorizontalAlignment.Center
                c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                c.IsEditable = False
                .Columns.Add(c)

                c = New BrightIdeasSoftware.OLVColumn
                c.Text = "Subtotal"
                c.AspectName = "SubtotalFinal"
                c.AspectToStringConverter = Function(x As Double)
                                                Return x.ToString("$ #,##0.00#")
                                            End Function
                c.MinimumWidth = 120
                c.MaximumWidth = 120
                c.TextAlign = HorizontalAlignment.Right
                c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                c.IsEditable = False
                'c.AspectToStringFormat = "{0:C}"
                .Columns.Add(c)

            Else

                c = New BrightIdeasSoftware.OLVColumn
                c.Text = "Cantidad"
                c.AspectName = "Cantidad"
                c.MinimumWidth = 65
                c.TextAlign = HorizontalAlignment.Right
                c.AspectToStringConverter = Function(x As Double)
                                                Return x.ToString("#,##0.00#")
                                            End Function
                'c.AspectToStringFormat = "{0.00}"
                c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                c.IsEditable = False
                .Columns.Add(c)

                c = New BrightIdeasSoftware.OLVColumn
                c.Text = "Código"
                c.AspectName = "Codigo"
                c.MinimumWidth = 120
                c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                c.IsEditable = False
                .Columns.Add(c)

                'c = New BrightIdeasSoftware.OLVColumn
                'c.Text = "Rev"
                'c.AspectName = "Rev"
                'c.MinimumWidth = 34
                'c.MaximumWidth = 34
                'c.AutoResize(ColumnHeaderAutoResizeStyle.None)
                'c.IsEditable = False
                '.Columns.Add(c)

                c = New BrightIdeasSoftware.OLVColumn
                c.Text = "Nombre/Descripción"
                c.AspectName = "Descripcion"
                c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                c.MinimumWidth = 160
                c.FillsFreeSpace = True
                c.IsEditable = True
                .Columns.Add(c)

                'c = New BrightIdeasSoftware.OLVColumn
                'c.Text = "Un."
                'c.AspectName = "SimboloUnidad" '"Unidad"
                'c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                'c.MinimumWidth = 40
                'c.MaximumWidth = 40
                'c.IsEditable = False
                '.Columns.Add(c)

                'c = New BrightIdeasSoftware.OLVColumn
                'c.Text = "KxU"
                'c.AspectName = "Kgsxunidad"
                'c.MinimumWidth = 30
                'c.TextAlign = HorizontalAlignment.Right
                'c.AspectToStringConverter = Function(x As Double)
                '                                Return x.ToString("#,##0.00#")
                '                            End Function
                ''c.AspectToStringFormat = "{0.00}"
                'c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                'c.IsEditable = False
                '.Columns.Add(c)

                'c = New BrightIdeasSoftware.OLVColumn
                'c.Text = "Kgs"
                'c.AspectName = "Kgs"
                'c.MinimumWidth = 60
                'c.TextAlign = HorizontalAlignment.Right
                'c.AspectToStringConverter = Function(x As Double)
                '                                Return x.ToString("#,##0.00#")
                '                            End Function
                ''c.AspectToStringFormat = "{0.00}"
                'c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                'c.IsEditable = False
                '.Columns.Add(c)

                c = New BrightIdeasSoftware.OLVColumn
                c.Text = "Precio"
                c.AspectName = "ImporteBruto"
                c.MinimumWidth = 75
                c.TextAlign = HorizontalAlignment.Right
                c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                c.AspectToStringConverter = Function(x As Double)
                                                Return x.ToString("$ #,##0.00#")
                                            End Function
                c.IsEditable = False
                'c.AspectToStringFormat = "{0:C}"
                .Columns.Add(c)

                'c = New BrightIdeasSoftware.OLVColumn
                'c.Text = "Imp.Int"
                'c.AspectName = "ImpInterno"

                'c.MinimumWidth = 75
                'c.TextAlign = HorizontalAlignment.Center
                'c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                'c.AspectToStringConverter = Function(x As Double)
                'Return x.ToString("$ #,##0.00##")

                'c.IsEditable = False
                '.Columns.Add(c)

                c = New BrightIdeasSoftware.OLVColumn
                c.Text = "Dto %"
                c.AspectName = "Descuento"
                c.MinimumWidth = 50
                c.TextAlign = HorizontalAlignment.Center
                c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                c.AspectToStringConverter = Function(x As Double)
                                                Return x.ToString("0.00")
                                            End Function
                c.IsEditable = False
                'c.AspectToStringFormat = "{0:C}"
                .Columns.Add(c)

                c = New BrightIdeasSoftware.OLVColumn
                c.Text = "IVA %"
                c.AspectName = "Alicuota"
                c.MinimumWidth = 25
                c.TextAlign = HorizontalAlignment.Center
                c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                c.IsEditable = False
                .Columns.Add(c)

                c = New BrightIdeasSoftware.OLVColumn
                c.Text = "Subtotal"
                c.AspectName = "SubtotalFinal"
                c.AspectToStringConverter = Function(x As Double)
                                                Return x.ToString("$ #,##0.00#")
                                            End Function
                c.MinimumWidth = 90
                c.TextAlign = HorizontalAlignment.Right
                c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                c.IsEditable = False
                'c.AspectToStringFormat = "{0:C}"
                .Columns.Add(c)

                c = New BrightIdeasSoftware.OLVColumn
                c.Text = "Numero"
                c.AspectName = "Numero"
                c.MinimumWidth = 60
                c.MaximumWidth = 60
                c.TextAlign = HorizontalAlignment.Right
                c.AutoResize(ColumnHeaderAutoResizeStyle.None)
                c.IsEditable = False
                .Columns.Add(c)

                'c = New BrightIdeasSoftware.OLVColumn
                'c.Text = "Sec."
                'c.AspectName = "Secuencia"
                'c.MinimumWidth = 30
                'c.MaximumWidth = 30
                'c.TextAlign = HorizontalAlignment.Right
                'c.AutoResize(ColumnHeaderAutoResizeStyle.None)
                'c.IsEditable = False
                '.Columns.Add(c)

            End If

            If Me.TipoDeCbte = TipoCbte.CBTEVTA Then
                .CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick
                .CellEditEnterChangesRows = False 'True
            End If

            .FullRowSelect = True
            .UseFiltering = False
            .ClearObjects()
        End With

    End Sub

    Private Sub CrearGrillaAlicuotas()

        Dim c As BrightIdeasSoftware.OLVColumn

        With FOLVAlicuotas

            .Columns.Clear()

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Id"
            c.AspectName = "Id"
            c.MinimumWidth = 0
            c.MaximumWidth = 0
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = False
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Código"
            c.AspectName = "Codigo"
            c.MinimumWidth = 50
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = False
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Descripción"
            c.AspectName = "Descripcion"
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.MinimumWidth = 200
            'c.FillsFreeSpace = True
            c.IsEditable = False
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Base Imp."
            c.AspectName = "BaseImponible"
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("$ #,##0.00#")
                                        End Function
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            'c.AspectToStringFormat = "{0:C}"
            c.IsEditable = (Me.TipoCargaCbte = TipoEmisionCbte.COMPRA)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Imp. Alic."
            c.AspectName = "Importe"
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("$ #,##0.00#")
                                        End Function
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = (Me.TipoCargaCbte = TipoEmisionCbte.COMPRA)
            'c.AspectToStringFormat = "{0:C}"
            .Columns.Add(c)

            .FullRowSelect = True
            .UseFiltering = False

            If Me.TipoCargaCbte = TipoEmisionCbte.COMPRA Then
                .CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick
                .CellEditEnterChangesRows = True
            End If

            .ClearObjects()
        End With

        CargarAlicuotas()

        PoblarGrillaAlicuotas()

    End Sub

    Private Sub CrearGrillaImportes()

        Dim c As BrightIdeasSoftware.OLVColumn

        With FOLVImportes

            .Columns.Clear()

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Descripción Importe"
            c.TextAlign = HorizontalAlignment.Right
            c.AspectName = "Detalle"
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.Sortable = False
            c.MinimumWidth = 200
            c.IsEditable = False
            .Columns.Add(c)


            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Importe"
            c.AspectName = "Importe"
            c.Sortable = False
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("$ #,##0.00#")
                                        End Function
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = (Me.TipoDeCbte = TipoCbte.CBTECPRA)
            .Columns.Add(c)

            .FullRowSelect = True
            .UseFiltering = False

            If Me.TipoDeCbte = TipoCbte.CBTECPRA Then
                .CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick
                .CellEditEnterChangesRows = True
            End If

            .ClearObjects()
        End With

        CargarImportes()

        PoblarGrillaImportes()

    End Sub

    Private Sub CrearGrillaCtasPropias()

        Dim c As BrightIdeasSoftware.OLVColumn

        With FOLVCtasPropias

            .Columns.Clear()

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Cuenta"
            c.AspectName = "Cuenta"
            c.MinimumWidth = 75
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Detalle"
            c.AspectName = "DetalleCuenta"
            c.MinimumWidth = 125
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Concepto"
            c.AspectName = "Concepto"
            c.MinimumWidth = 75
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Detalle"
            c.AspectName = "DetalleConcepto"
            c.MinimumWidth = 125
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Efectivización"
            c.AspectName = "Efectivizacion"
            c.AspectToStringConverter = Function(x As Date)
                                            Return x.ToString("dd/MM/yyyy")
                                        End Function
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.MinimumWidth = 100

            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Referencia"
            c.AspectName = "Referencia"
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.MinimumWidth = 100
            c.FillsFreeSpace = True
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Importe"
            c.AspectName = "Importe"
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("$ #,##0.00#")
                                        End Function
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            .FullRowSelect = True
            .UseFiltering = False
            .ClearObjects()
        End With


    End Sub

    Private Sub CrearGrillaCartera()

        Dim c As BrightIdeasSoftware.OLVColumn

        With FOLVCartera

            .Columns.Clear()


            If Me.TipoCargaCbte = TipoEmisionCbte.PAGO_PRESUPUESTO Or Me.TipoCargaCbte = TipoEmisionCbte.ORDEN_DE_PAGO Or Me.TipoCargaCbte = TipoEmisionCbte.DEPOSITO_CARTERA Then

                .CheckBoxes = True
                .CheckedAspectName = "Checked"

                'c = New BrightIdeasSoftware.OLVColumn
                'c.Text = ""
                'c.AspectName = "Checked"
                ''c.AspectGetter = Function(x As Object)
                ''                     Return DirectCast(x, Entidades.Financiero).Checked
                ''                 End Function

                'c.AspectToStringConverter = Function(x As Object)
                '                                Return String.Empty
                '                            End Function

                ''c.ImageGetter = Function(x As Object)
                ''                    Select Case DirectCast(x, Entidades.Financiero).Checked
                ''                        Case True
                ''                            Return "checked"
                ''                        Case Else
                ''                            Return "unchecked"
                ''                    End Select
                ''                End Function

                'c.MinimumWidth = 10
                'c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                ''c.IsEditable = True
                '.Columns.Add(c)

            End If

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Cuenta"
            c.AspectName = "Cuenta"
            c.MinimumWidth = 100
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = False
            .Columns.Add(c)

            'c = New BrightIdeasSoftware.OLVColumn
            'c.Text = "Detalle"
            'c.AspectName = "DetalleCuenta"
            'c.MinimumWidth = 125
            'c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            'c.IsVisible = False
            'c.IsEditable = False
            '.Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Concepto"
            c.AspectName = "Concepto"
            c.MinimumWidth = 75
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = False
            .Columns.Add(c)

            'c = New BrightIdeasSoftware.OLVColumn
            'c.Text = "Detalle"
            'c.AspectName = "DetalleConcepto"
            'c.MinimumWidth = 125
            'c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            'c.IsEditable = False
            'c.IsVisible = False
            '.Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Dador"
            c.AspectName = "Dador"
            c.MinimumWidth = 200
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = False
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Fecha de Cobro"
            c.AspectName = "Efectivizacion"
            c.AspectToStringConverter = Function(x As Date)
                                            Return x.ToString("dd/MM/yyyy")
                                        End Function

            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = False
            c.MinimumWidth = 100
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Nro. de Cheque"
            c.AspectName = "Referencia"
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.MinimumWidth = 100
            c.IsEditable = False
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Importe"
            c.AspectName = "Importe"
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("$ #,##0.00#")
                                        End Function

            c.MinimumWidth = 100
            c.FillsFreeSpace = True
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = False
            .Columns.Add(c)

            .FullRowSelect = True
            .UseFiltering = False

            'If Me.TipoCargaCbte = TipoEmisionCbte.PAGO_PRESUPUESTO Or Me.TipoCargaCbte = TipoEmisionCbte.ORDEN_DE_PAGO Then
            '    .CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick
            '    .CellEditEnterChangesRows = True
            'End If

            .ClearObjects()
        End With



    End Sub

    Private Sub CargarAlicuotas()
        Dim repositorio As New CapaLogica.TipocondicionivaCLog
        'cargo las alicuotas por defecto
        '3,4,5,6,8,9 son los codigos admitidos por wsfev1
        Dim a As Entidades.CbteAlicuota
        Dim l As List(Of Entidades.Tipocondicioniva) = repositorio.GetAll
        _alicuotas.Clear()


        For Each e As Entidades.Tipocondicioniva In l
            Select Case e.Codigo
                Case 3, 4, 5, 6, 8, 9
                    a = New Entidades.CbteAlicuota
                    a.Codigo = e.Codigo
                    a.Descripcion = e.Descripcion
                    a.Importe = 0.0
                    a.Alicuota = e.Alicuota

                    _alicuotas.Add(a)
            End Select
        Next
    End Sub

    Private Sub CrearGrillaTributos()

        Dim c As BrightIdeasSoftware.OLVColumn

        With FOLVOtrosTributos

            .Columns.Clear()

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Id"
            c.AspectName = "Id"
            c.MinimumWidth = 0
            c.MaximumWidth = 0
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Código"
            c.AspectName = "Codigo"
            c.MinimumWidth = 50
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Descripción"
            c.AspectName = "Descripcion"
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.MinimumWidth = 200
            'c.FillsFreeSpace = True
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Referencia"
            c.AspectName = "Referencia"
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Center
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Alicuota"
            c.AspectName = "Alicuota"
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("0.00")
                                        End Function
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            'c.AspectToStringFormat = "{0:C}"
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Importe"
            c.AspectName = "Importe"
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("$ #,##0.00#")
                                        End Function
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            'c.AspectToStringFormat = "{0:C}"
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Base Imp."
            c.AspectName = "BaseImponible"
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("$ #,##0.00#")
                                        End Function
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            'c.AspectToStringFormat = "{0:C}"
            .Columns.Add(c)

            .FullRowSelect = True
            .UseFiltering = False
            .ClearObjects()

        End With


    End Sub

    Private Sub CrearGrillaCompAsoc()


        Dim c As BrightIdeasSoftware.OLVColumn

        With FOLVCompAsoc

            .Columns.Clear()

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Comprobante"
            c.AspectName = "Denominacion"
            c.MinimumWidth = 100
            c.FillsFreeSpace = True
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = False
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Fecha"
            c.AspectName = "Fecha"

            c.MinimumWidth = 100
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = False
            .Columns.Add(c)


            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Importe Orig."
            c.AspectName = "ImporteOriginal"
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("$ #,##0.00#")
                                        End Function
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = False
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Saldo"
            c.AspectName = "Saldo"
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("$ #,##0.00#")
                                        End Function
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = False
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Aplicado"
            c.AspectName = "Importe"
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("$ #,##0.00#")
                                        End Function
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            'c.AspectToStringFormat = "{0:C}"
            c.IsEditable = True
            .Columns.Add(c)

            'If Me.TipoCargaCbte = TipoEmisionCbte.COMPRA Then
            .CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick
            .CellEditEnterChangesRows = True
            'End If

            .FullRowSelect = True
            .UseFiltering = False
            .ClearObjects()

        End With


    End Sub



    Private Sub QuitarArticulo()

        If FOLVArticulos.SelectedObject IsNot Nothing Then

            For Each o As Entidades.CbteAlicuota In _alicuotas
                If o.Codigo = DirectCast(FOLVArticulos.SelectedObject, Entidades.CbteArticulo).AlicuotaCodigo Then
                    o.Importe -= DirectCast(FOLVArticulos.SelectedObject, Entidades.CbteArticulo).SubtotalIVA
                    o.BaseImponible -= DirectCast(FOLVArticulos.SelectedObject, Entidades.CbteArticulo).Subtotal
                    o.Importe = Math.Round(o.Importe, 2)
                    o.BaseImponible = Math.Round(o.BaseImponible, 2)
                End If
            Next

            For Each o As Entidades.CbteTributo In _tributos

                If DirectCast(FOLVArticulos.SelectedObject, Entidades.CbteArticulo).ImpuestoInterno > 0 Then

                    If o.Codigo = Convert.ToString(AFIP_COD_IMPUESTO_INTERNO) And o.Alicuota = DirectCast(FOLVArticulos.SelectedObject, Entidades.CbteArticulo).ImpIntTasaNominal Then
                        o.Importe -= DirectCast(FOLVArticulos.SelectedObject, Entidades.CbteArticulo).SubtotalImpuestoInterno
                        o.BaseImponible -= DirectCast(FOLVArticulos.SelectedObject, Entidades.CbteArticulo).BaseImponibleImpInterno
                        o.Importe = Math.Round(o.Importe, 2)
                        o.BaseImponible = Math.Round(o.BaseImponible, 2)
                        Exit For
                    End If

                End If
            Next

            If (Me.TipoCargaCbte = TipoEmisionCbte.COMPRA Or Me.TipoCargaCbte = TipoEmisionCbte.PRESUPUESTO) And Me.TipoDeCbte = TipoCbte.CBTECPRA Then
                'pretotalizo los importes de compras

                Dim e As Entidades.CbteArticulo = DirectCast(Me.FOLVArticulos.SelectedObject, Entidades.CbteArticulo)

                For Each o As Importes In _importes
                    Select Case o.Tipo
                        Case TiposImportes.EXENTO
                            o.Importe -= e.SubtotalExento
                        Case TiposImportes.NO_GRAVADO
                            o.Importe -= e.SubtotalNoGravado
                        Case TiposImportes.NETO_GRAVADO
                            o.Importe -= e.Subtotal
                        Case TiposImportes.IVA
                            If o.Codigo = e.AlicuotaCodigo.ToString Then
                                o.Importe -= e.SubtotalIVA
                            End If
                        Case TiposImportes.TRIBUTO
                            If o.Codigo = AFIP_COD_IMPUESTO_INTERNO Then
                                o.Importe -= e.SubtotalImpuestoInterno
                            End If
                    End Select

                    If o.Importe < 0 Then
                        o.Importe = 0
                    End If

                Next o
            End If

            _articulos.Remove(DirectCast(Me.FOLVArticulos.SelectedObject, Entidades.CbteArticulo))

            PoblarGrillas()

            Totalizar()

        End If

    End Sub

    Private Sub QuitarArticulo(ByVal articulo As Entidades.CbteArticulo)


        For Each o As Entidades.CbteAlicuota In _alicuotas
            If o.Codigo = articulo.AlicuotaCodigo Then
                o.Importe -= articulo.SubtotalIVA
                o.BaseImponible -= articulo.Subtotal
                o.Importe = Math.Round(o.Importe, 2)
                o.BaseImponible = Math.Round(o.BaseImponible, 2)
            End If
        Next

        For Each o As Entidades.CbteTributo In _tributos

            If articulo.ImpuestoInterno > 0 Then

                If o.Codigo = Convert.ToString(AFIP_COD_IMPUESTO_INTERNO) And o.Alicuota = articulo.ImpIntTasaNominal Then
                    o.Importe -= articulo.SubtotalImpuestoInterno
                    o.BaseImponible -= articulo.BaseImponibleImpInterno
                    o.Importe = Math.Round(o.Importe, 2)
                    o.BaseImponible = Math.Round(o.BaseImponible, 2)
                    Exit For
                End If

            End If
        Next

        If (Me.TipoCargaCbte = TipoEmisionCbte.COMPRA Or Me.TipoCargaCbte = TipoEmisionCbte.PRESUPUESTO) And Me.TipoDeCbte = TipoCbte.CBTECPRA Then
            'pretotalizo los importes de compras

            Dim e As Entidades.CbteArticulo = articulo

            For Each o As Importes In _importes
                Select Case o.Tipo
                    Case TiposImportes.EXENTO
                        o.Importe -= e.SubtotalExento
                    Case TiposImportes.NO_GRAVADO
                        o.Importe -= e.SubtotalNoGravado
                    Case TiposImportes.NETO_GRAVADO
                        o.Importe -= e.Subtotal
                    Case TiposImportes.IVA
                        If o.Codigo = e.AlicuotaCodigo.ToString Then
                            o.Importe -= e.SubtotalIVA
                        End If
                    Case TiposImportes.TRIBUTO
                        If o.Codigo = AFIP_COD_IMPUESTO_INTERNO Then
                            o.Importe -= e.SubtotalImpuestoInterno
                        End If
                End Select

                If o.Importe < 0 Then
                    o.Importe = 0
                End If

            Next o
        End If

        _articulos.Remove(articulo)

        PoblarGrillas()

        Totalizar()

    End Sub


    Private Sub QuitarTributo()
        Try
            If FOLVOtrosTributos.SelectedObject IsNot Nothing Then

                If Me.TipoCargaCbte = TipoEmisionCbte.FISCAL Then
                    Me.ComboBoxTributos.Focus()
                    Throw New Exception("La opción de quitar de tributos no esta disponible para la emisión de cbtes. por controlador fiscal")
                End If

                _tributos.Remove(DirectCast(Me.FOLVOtrosTributos.SelectedObject, Entidades.CbteTributo))

                PoblarGrillas()

                Totalizar()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Quitar Tributo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub QuitarCtaPropia()

        If FOLVCtasPropias.SelectedObject IsNot Nothing Then

            _cuentaspropias.Remove(DirectCast(Me.FOLVCtasPropias.SelectedObject, Entidades.Financiero))

            PoblarGrillas()

            Totalizar()

        End If

    End Sub

    Private Sub QuitarCheque()

        If FOLVCartera.SelectedObject IsNot Nothing Then

            _cartera.Remove(DirectCast(Me.FOLVCartera.SelectedObject, Entidades.Financiero))

            PoblarGrillas()

            Totalizar()

        End If

    End Sub

    Private Sub QuitarAsociado()

        If FOLVCompAsoc.SelectedObject IsNot Nothing Then

            _cbtesasociados.Remove(DirectCast(Me.FOLVCompAsoc.SelectedObject, Entidades.CbteAsociado))

            PoblarGrillas()

            Totalizar()

        End If

    End Sub

    Private Sub ComboBoxArticulos_CodigobarraEncontrado() Handles ComboBoxArticulos.CodigobarraEncontrado

        'Me.TextBoxCantidad.Text = "1"

        If Me.TipoDeCbte = TipoCbte.CBTECPRA Then
            AgregarMaterial()
        Else
            AgregarArticulo(0)
        End If

        Application.DoEvents()

        Me.ComboBoxArticulos.Focus()

    End Sub

    Private Sub ComboBoxArticulos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxArticulos.SelectedIndexChanged
        'If Me.TipoDeCbte = TipoCbte.CBTECPRA Then
        '    CargaDatosMaterial()
        'Else
        '    CargaDatosArticulo()
        'End If
    End Sub

    'Private Sub TextBoxImporte_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxImporte.TextChanged, TextBoxImporteImpInt.TextChanged
    '    TotalizarLinea()
    'End Sub

    'Private Sub TextBoxCantidad_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxCantidad.TextChanged
    '    TotalizarLinea()
    'End Sub

    'Private Sub TextBoxKgs_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Me.TipoDeCbte = TipoCbte.CBTEVTA Then
    '        If Me.TextBoxKgs.Text = "" Then
    '            Me.TextBoxKgs.Text = "0.00"
    '        Else
    '            Me.TextBoxKgs.Text = Format(CDbl(Me.TextBoxKgs.Text), "0.00")
    '        End If

    '        If DirectCast(Me.ComboBoxArticulos.SelectedItem, Entidades.Articulo) IsNot Nothing And Me.TextBoxUnidad.Text = "KG" Then
    '            If Val(Me.TextBoxKxU.Text) > 0 Then
    '                Me.TextBoxCantidad.Text = Format(CInt(CDbl(Val(Me.TextBoxKgs.Text) / Val(Me.TextBoxKxU.Text))), "0.00")
    '            End If
    '        End If
    '    End If
    'End Sub

    Private Sub TextBoxCantidad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxCantidad.LostFocus
        If Me.TipoDeCbte = TipoCbte.CBTEVTA Or Me.TipoDeCbte = TipoCbte.CBTECPRA Then

            If Me.TextBoxCantidad.Text = "" Then
                Me.TextBoxCantidad.Text = "0.00"
            Else
                Me.TextBoxCantidad.Text = Format(CDbl(Me.TextBoxCantidad.Text), "0.00")
            End If

            'If DirectCast(Me.ComboBoxArticulos.SelectedItem, Entidades.Articulo) IsNot Nothing And Me.TextBoxUnidad.Text = "KG" Then
            '    If Val(Me.TextBoxKxU.Text) > 0 Then
            '        Me.TextBoxCantidad.Text = Format(CInt(CDbl(Val(Me.TextBoxKgs.Text) / Val(Me.TextBoxKxU.Text))), "0.00")
            '    End If
            'End If

            'If DirectCast(Me.ComboBoxArticulos.SelectedItem, Entidades.Articulo) IsNot Nothing And Me.TextBoxUnidad.Text <> "KG" Then
            Me.TextBoxSubtotalArticulo.Text = Format(CDbl(Val(Me.TextBoxCantidad.Text) * Val(Me.TextBoxImporte.Text)), "0.00")
            'ElseIf DirectCast(Me.ComboBoxArticulos.SelectedItem, Entidades.Articulo) IsNot Nothing And Me.TextBoxUnidad.Text = "KG" Then
            '    If Val(Me.TextBoxKgs.Text) = 0 Then
            '        Me.TextBoxKgs.Text = Format(CInt(CDbl(Val(Me.TextBoxCantidad.Text) * Val(Me.TextBoxKxU.Text))), "0.00")
            '    End If
            '    'Me.TextBoxSubtotalArticulo.Text = Format(CDbl(Val(Me.TextBoxKgs.Text) * Val(Me.TextBoxImporte.Text)), "0.00")

            'End If
        End If
    End Sub
    Private Sub CargaDatosMaterial()
        Dim e As New Entidades.Articulo
        Dim precio As Double = 0.0
        Dim dto As Double = 0.0

        e = DirectCast(Me.ComboBoxArticulos.SelectedItem, Entidades.Articulo)

        If e IsNot Nothing Then
            precio = e.Preciodecompra

            Me.TextBoxCantidad.Text = "1.00"
            Me.TextBoxImporte.Text = Format(precio, "0.00")
            Me.TextBoxImporteImpInt.Text = 0
            If Me.ComboBoxArticuloAlicuota.Items.Count > 0 Then
                Me.ComboBoxArticuloAlicuota.SelectedValue = e.Alicuotaiva
            Else
                Me.ComboBoxArticuloAlicuota.SelectedIndex = -1
            End If
            Me.TextBoxDto.Text = "0"
            'Me.TextBoxCantidad.Focus()
        Else
            precio = 0

            Me.TextBoxImporte.Text = Format(precio, "0.00")
            Me.TextBoxImporteImpInt.Text = 0
            Me.ComboBoxArticuloAlicuota.SelectedIndex = -1
            Me.TextBoxDto.Text = "0"
            Me.TextBoxSubtotalArticulo.Text = "0.00"
        End If
    End Sub

    Private Sub CargaDatosArticulo()
        Dim e As New Entidades.Articulo
        Dim precio As Double = 0.0
        Dim dto As Double = 0.0

        e = DirectCast(Me.ComboBoxArticulos.SelectedItem, Entidades.Articulo)

        If e IsNot Nothing Then

            If Me.TipoDeCbte = TipoCbte.CBTEVTA Then
                If e.Codigo = "999999999999999" Then
                    Me.TextBoxImporte.ReadOnly = False
                Else
                    Me.TextBoxImporte.ReadOnly = True
                End If

                'Me.TextBoxKgs.Text = "0.00"
                Me.TextBoxCantidad.Text = "0.00"

                Me.TextBoxUnidad.Text = e.SimboloUnidad
                Me.TextBoxKxU.Text = Format(CDbl(e.Pesoneto), "0.00")
                Me.TextBoxImporte.Text = Format(CDbl(e.Preciodeventa), "0.00")


                'Me.TextBoxUnidad.Text = e.SimboloUnidad
                'Me.TextBoxKxU.Text = Format(CDbl(e.Pesoneto), "0.00")

                If mblnPrecargaRemito = False And Cliente IsNot Nothing Then
                    'Lleno la Ayuda de las OC
                    _ListaNroOrden = _repositorio.GetByNroOrden(Cliente.Codigo, DirectCast(Me.ComboBoxArticulos.SelectedItem, Entidades.Articulo).Codigo)
                    InicializarComboOrdenCompra(True)

                    'Lleno el Combo con la Cantidad
                    _ListaNroOrden = _repositorio.GetByArticulosPendientes(Cliente.Codigo, DirectCast(Me.ComboBoxArticulos.SelectedItem, Entidades.Articulo).Codigo)
                    For Each art In _ListaNroOrden
                        Me.TextBoxCantidad.Text += art.Cantidad
                    Next
                    Me.TextBoxCantidad.Text = Format(Convert.ToDouble(Me.TextBoxCantidad.Text), "0.00")
                    '''''''''
                    '_ListaNroOrden = _repositorio.GetByNroOrden(Cliente.Codigo, DirectCast(Me.ComboBoxArticulos.SelectedItem, Entidades.Articulo).Codigo)
                    'InicializarComboOrdenCompra(True)
                    ''''''''
                End If

                If mblnPrecargaRemito = False Or Val(Me.TextBoxImporte.Text) = 0 Then
                    Select Case ListaDePrecio
                        Case ListaPrecios.LISTA1 : precio = e.ImporteFinalLista1
                        Case ListaPrecios.LISTA2 : precio = e.ImporteFinalLista2
                        Case ListaPrecios.LISTA3 : precio = e.ImporteFinalLista3
                        Case Else : precio = e.ImporteFinalLista1
                    End Select

                    'en las ventas, los articulos que admiten modificacion de precios
                    'modifican la carga, asigno el precio basico
                    If e.Preciomodificable Or gUsuario.Perfil <> PERFIL_MOSTRADOR Then
                        Me.TextBoxImporte.ReadOnly = False
                        Me.ComboBoxArticuloAlicuota.Enabled = True

                        Select Case ListaDePrecio
                            Case ListaPrecios.LISTA1 : precio = e.BasicoLista1
                            Case ListaPrecios.LISTA2 : precio = e.BasicoLista2
                            Case ListaPrecios.LISTA3 : precio = e.BasicoLista3
                            Case Else : precio = e.BasicoLista1
                        End Select

                    Else
                        Me.TextBoxImporte.ReadOnly = (Me.TipoDeCbte = TipoCbte.CBTEVTA)
                        Me.TextBoxImporteImpInt.ReadOnly = (Me.TipoDeCbte = TipoCbte.CBTEVTA)
                        Me.ComboBoxArticuloAlicuota.Enabled = Not (Me.TipoDeCbte = TipoCbte.CBTEVTA)
                    End If
                End If

            Else 'cbtecpra
                'e.Preciodecosto 23/05/2016 El precio de compra es que se muestra
                precio = e.Preciodecompra
            End If

            If mblnPrecargaRemito = False Or Val(Me.TextBoxImporte.Text) = 0 Then
                Me.TextBoxImporte.Text = Format(precio, "0.00")
                Me.TextBoxImporteImpInt.Text = e.Impuestointerno

                Me.ComboBoxArticuloAlicuota.SelectedValue = e.Alicuotaiva
                'traer el dto. solo en comprobantes de venta
                If Me.TipoDeCbte <> TipoCbte.CBTECPRA Then

                    'obtengo el descuento por lista de precio
                    Select Case ListaDePrecio
                        Case ListaPrecios.LISTA1 : dto = e.Descuento
                        Case ListaPrecios.LISTA2 : dto = e.Descuento2
                        Case ListaPrecios.LISTA3 : dto = e.Descuento3
                        Case Else : dto = e.Descuento
                    End Select

                    _dtoPredeterminado = dto

                    If Me.DescuentoGral <> 0 And dto <= 0 Then
                        'la categoría cigarrillo no aplica descuento general
                        'If e.Categoria <> CATEGORIA_CIGARRILLO Then
                        Me.TextBoxDto.Text = Me.DescuentoGral
                        'End If
                    Else
                        Me.TextBoxDto.Text = dto
                    End If

                Else
                    Me.TextBoxDto.Text = "0"
                End If
            End If

        Else
            Me.TextBoxUnidad.Text = ""
            Me.TextBoxKxU.Text = "0.00"
            Me.TextBoxCantidad.Text = "0.00"
            Me.ComboBoxNroOrden.SelectedItem = -1
            Me.TextBoxImporte.Text = ""
            Me.TextBoxDto.Text = "0"
            Me.TextBoxSubtotalArticulo.Text = "0.00"
        End If

    End Sub

    
    Private Sub TotalizarLinea(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim c As Double
        Dim i As Double
        Dim ii As Double
        Dim dto As Double
        Dim s As Double

        If Me.TipoDeCbte = TipoCbte.CBTEVTA Then
            'If Me.TextBoxUnidad.Text = "KG" Then
            '    c = Val(Me.TextBoxKgs.Text)
            'Else
            c = Val(Me.TextBoxCantidad.Text)
            'End If

            i = Val(Me.TextBoxImporte.Text)
            ii = Val(Me.TextBoxImporteImpInt.Text)
            dto = Math.Round(Val(Me.TextBoxImporte.Text) * (Val(Me.TextBoxDto.Text) / 100), 2)
            i -= dto
            s = c * (i + ii)

        Else
            c = Val(Me.TextBoxCantidad.Text)
            i = Val(Me.TextBoxImporte.Text)
            ii = Val(Me.TextBoxImporteImpInt.Text)
            dto = Math.Round(Val(Me.TextBoxImporte.Text) * (Val(Me.TextBoxDto.Text) / 100), 2)
            i -= dto
            s = c * (i + ii)

        End If

        Me.TextBoxSubtotalArticulo.Text = Format(s, "0.00")

    End Sub

    Private Sub CustomKeyPressOnlyNumbers(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If sender Is TextBoxCantidad Then
            If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(_decimalSeparator) Or e.KeyChar.Equals(_negativeSign) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
        Else
            If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(_decimalSeparator) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
        End If

    End Sub

    Private Sub BtnAgregarArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarArticulo.Click
        If Me.TipoDeCbte = TipoCbte.CBTECPRA Then
            'AgregarArticulo(0)
            AgregarMaterial()
        Else
            AgregarArticulo(0)
        End If
    End Sub

    Private Sub CustomGotFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = Color.LightGreen

        If sender.GetType = GetType(TextBox) Then
            DirectCast(sender, TextBox).Font = New Font(DirectCast(sender, TextBox).Font, FontStyle.Bold)
            DirectCast(sender, TextBox).SelectAll()
        End If

    End Sub

    Private Sub CustomLostFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = SystemColors.Window

        If sender.GetType = GetType(TextBox) Then
            DirectCast(sender, TextBox).Font = New Font(DirectCast(sender, TextBox).Font, FontStyle.Regular)
        End If

    End Sub

    Private Sub ComboBoxArticulos_CodigoEncontrado() Handles ComboBoxArticulos.CodigoEncontrado
        If Me.TipoDeCbte = TipoCbte.CBTECPRA Then
            CargaDatosMaterial()
            'CargaDatosArticulo()
        Else
            CargaDatosArticulo()
        End If
        Me.TextBoxCantidad.Focus()
    End Sub

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        For Each c As Control In Me.PanelCabecera.Controls
            Select Case c.GetType
                Case GetType(TextBox), GetType(ComboBox)
                    AddHandler c.GotFocus, AddressOf CustomGotFocus
                    AddHandler c.LostFocus, AddressOf CustomLostFocus
                Case GetType(GroupBox)
                    For Each g As Control In c.Controls
                        Select Case g.GetType
                            Case GetType(TextBox), GetType(ComboBox)
                                AddHandler g.GotFocus, AddressOf CustomGotFocus
                                AddHandler g.LostFocus, AddressOf CustomLostFocus
                        End Select
                    Next
            End Select
        Next


        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        For Each c As Control In Me.PanelCabeceraTributos.Controls
            Select Case c.GetType
                Case GetType(TextBox), GetType(ComboBox)
                    AddHandler c.GotFocus, AddressOf CustomGotFocus
                    AddHandler c.LostFocus, AddressOf CustomLostFocus
                Case GetType(GroupBox)
                    For Each g As Control In c.Controls
                        Select Case g.GetType
                            Case GetType(TextBox), GetType(ComboBox)
                                AddHandler g.GotFocus, AddressOf CustomGotFocus
                                AddHandler g.LostFocus, AddressOf CustomLostFocus
                        End Select
                    Next
            End Select
        Next

        For Each c As Control In Me.PanelCabeceraAsoc.Controls
            Select Case c.GetType
                Case GetType(TextBox), GetType(ComboBox)
                    AddHandler c.GotFocus, AddressOf CustomGotFocus
                    AddHandler c.LostFocus, AddressOf CustomLostFocus
                Case GetType(GroupBox)
                    For Each g As Control In c.Controls
                        Select Case g.GetType
                            Case GetType(TextBox), GetType(ComboBox)
                                AddHandler g.GotFocus, AddressOf CustomGotFocus
                                AddHandler g.LostFocus, AddressOf CustomLostFocus
                        End Select
                    Next
            End Select
        Next

        For Each c As Control In Me.PanelCabeceraCtasPropias.Controls
            Select Case c.GetType
                Case GetType(TextBox), GetType(ComboBox)
                    AddHandler c.GotFocus, AddressOf CustomGotFocus
                    AddHandler c.LostFocus, AddressOf CustomLostFocus
                Case GetType(GroupBox)
                    For Each g As Control In c.Controls
                        Select Case g.GetType
                            Case GetType(TextBox), GetType(ComboBox)
                                AddHandler g.GotFocus, AddressOf CustomGotFocus
                                AddHandler g.LostFocus, AddressOf CustomLostFocus
                        End Select
                    Next
            End Select
        Next

        For Each c As Control In Me.PanelCabeceraCartera.Controls
            Select Case c.GetType
                Case GetType(TextBox), GetType(ComboBox)
                    AddHandler c.GotFocus, AddressOf CustomGotFocus
                    AddHandler c.LostFocus, AddressOf CustomLostFocus
                Case GetType(GroupBox)
                    For Each g As Control In c.Controls
                        Select Case g.GetType
                            Case GetType(TextBox), GetType(ComboBox)
                                AddHandler g.GotFocus, AddressOf CustomGotFocus
                                AddHandler g.LostFocus, AddressOf CustomLostFocus
                        End Select
                    Next
            End Select
        Next

        AddHandler Me.TextBoxObservaciones.GotFocus, AddressOf CustomGotFocus
        AddHandler Me.TextBoxObservaciones.LostFocus, AddressOf CustomLostFocus

        'inputs solo numeros
        AddHandler Me.TextBoxDto.KeyPress, AddressOf CustomKeyPressOnlyNumbers
        AddHandler Me.TextBoxImporte.KeyPress, AddressOf CustomKeyPressOnlyNumbers
        AddHandler Me.TextBoxImporteImpInt.KeyPress, AddressOf CustomKeyPressOnlyNumbers
        AddHandler Me.TextBoxCantidad.KeyPress, AddressOf CustomKeyPressOnlyNumbers
        'AddHandler Me.TextBoxKgs.KeyPress, AddressOf CustomKeyPressOnlyNumbers
        AddHandler Me.TextBoxSubtotalArticulo.KeyPress, AddressOf CustomKeyPressOnlyNumbers
        AddHandler Me.TextBoxImporteTributo.KeyPress, AddressOf CustomKeyPressOnlyNumbers
        AddHandler Me.TextBoxBaseTributo.KeyPress, AddressOf CustomKeyPressOnlyNumbers
        AddHandler Me.TextBoxTributoAlic.KeyPress, AddressOf CustomKeyPressOnlyNumbers
        AddHandler Me.TextBoxImporteCtaPropia.KeyPress, AddressOf CustomKeyPressOnlyNumbers
        AddHandler Me.TextBoxImporteCartera.KeyPress, AddressOf CustomKeyPressOnlyNumbers

        'keydown
        AddHandler Me.ComboBoxArticulos.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.ComboBoxArticuloAlicuota.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.TextBoxDto.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.TextBoxImporte.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.TextBoxImporteImpInt.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.TextBoxCantidad.KeyDown, AddressOf CustomKeyDown
        'AddHandler Me.TextBoxKgs.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.ComboBoxNroOrden.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.TextBoxSubtotalArticulo.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.TextBoxImporteCtaPropia.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.TextBoxImporteCartera.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.TextBoxImporteAsoc.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.TextBoxReferencia.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.TextBoxReferenciaCartera.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.TextBoxDador.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.TextBoxCUITLibrador.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.DateTimePickerEfectivizacion.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.DateTimePickerFechaCheque.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.TextBoxTributoAlic.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.ComboBoxTributos.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.ComboBoxDescTributo.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.TextBoxBaseTributo.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.TextBoxImporteTributo.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.TextBoxRefTributo.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.ComboBoxCtaBancaria.CodigoEncontrado, AddressOf a_EnviaEnter
        AddHandler Me.ComboBoxConceptoBancario.CodigoEncontrado, AddressOf a_EnviaEnter

        'totalizar linea
        'AddHandler Me.TextBoxKgs.TextChanged, AddressOf TotalizarLinea
        AddHandler Me.TextBoxImporte.TextChanged, AddressOf TotalizarLinea
        AddHandler Me.TextBoxImporteImpInt.TextChanged, AddressOf TotalizarLinea
        AddHandler Me.TextBoxCantidad.TextChanged, AddressOf TotalizarLinea
        AddHandler Me.TextBoxDto.TextChanged, AddressOf TotalizarLinea


        _decimalSeparator = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
        _negativeSign = Application.CurrentCulture.NumberFormat.NegativeSign

    End Sub

    Private Sub FOLVArticulos_CellEditFinishing(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles FOLVArticulos.CellEditFinishing
        Totalizar()
    End Sub

    Private Sub FOLVArticulos_CellEditValidating(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles FOLVArticulos.CellEditValidating

        If e.Column.AspectName = "Cantidad" Then
            If Val(e.NewValue) <= 0 Then
                If e.Control.GetType = GetType(BrightIdeasSoftware.FloatCellEditor) Then
                    DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).BackColor = Color.Red
                    DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Select(0, DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Text.Length)
                End If
                e.Cancel = True
            End If
        ElseIf e.Column.AspectName = "Descripcion" Then
            If Len(e.NewValue) < 1 Or Len(e.NewValue) > 80 Then
                If e.Control.GetType = GetType(BrightIdeasSoftware.FloatCellEditor) Then
                    DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).BackColor = Color.Red
                    DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Select(0, DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Text.Length)
                End If
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub FOLVArticulos_FormatCell(ByVal sender As Object, ByVal e As BrightIdeasSoftware.FormatCellEventArgs) Handles FOLVArticulos.FormatCell
        Select Case e.Column.AspectName
            Case "SubtotalFinal", "Codigo", "Cantidad"
                e.SubItem.Font = New System.Drawing.Font(e.SubItem.Font.Name, e.SubItem.Font.Size, FontStyle.Bold)
        End Select
    End Sub

    Private Sub FOLVArticulos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FOLVArticulos.KeyDown
        If e.KeyCode = Keys.Delete Then
            QuitarArticulo()
        End If
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub BtnAgregarTributo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAgregarTributo.Click
        CrearTributo()
    End Sub

    Private Sub CrearTributo()
        Dim t As New Entidades.CbteTributo

        Try

            If Me.TipoCargaCbte = TipoEmisionCbte.FISCAL Then
                Me.ComboBoxTributos.Focus()
                Throw New Exception("La opción de carga de tributos no es disponible para la emisión de cbtes. por controlador fiscal")
            End If

            If Me.ComboBoxTributos.SelectedItem Is Nothing Then
                Me.ComboBoxTributos.Focus()
                Throw New Exception("El tributo seleccionado no es válido")
            End If

            If Not IsNumeric(Me.TextBoxImporteTributo.Text) Then
                Me.TextBoxImporteTributo.Focus()
                Throw New Exception("El importe ingresado no es válido")
            End If

            If Convert.ToDouble(Me.TextBoxImporteTributo.Text) <= 0 Then
                Me.TextBoxImporteTributo.Focus()
                Throw New Exception("El importe ingresado no es válido")
            End If

            If Not IsNumeric(Me.TextBoxBaseTributo.Text) Then
                Me.TextBoxBaseTributo.Focus()
                Throw New Exception("El importe base imponible ingresado no es válido")
            End If

            If Convert.ToDouble(Me.TextBoxBaseTributo.Text) < 0 Then
                Me.TextBoxBaseTributo.Focus()
                Throw New Exception("El importe base imponible ingresado no es válido")
            End If

            If Not IsNumeric(Me.TextBoxTributoAlic.Text) Then
                Me.TextBoxTributoAlic.Focus()
                Throw New Exception("El valor de alicuota ingresado no es válido")
            End If

            If Convert.ToDouble(Me.TextBoxTributoAlic.Text) < 0 Then
                Me.TextBoxTributoAlic.Focus()
                Throw New Exception("El valor de alicuota ingresado no es válido")
            End If

            t.Referencia = Me.TextBoxRefTributo.Text.Trim
            t.Codigo = ComboBoxTributos.SelectedValue
            t.Descripcion = Me.ComboBoxDescTributo.Text.Trim
            t.Importe = Convert.ToDouble(Me.TextBoxImporteTributo.Text)
            t.BaseImponible = Convert.ToDouble(Me.TextBoxBaseTributo.Text)
            t.Alicuota = Convert.ToDouble(Me.TextBoxTributoAlic.Text)

            AgregarTributo(t)

            PoblarGrillas()

            Totalizar()

            Me.ComboBoxTributos.SelectedIndex = -1
            Me.ComboBoxDescTributo.SelectedIndex = -1
            Me.TextBoxBaseTributo.Text = 0.0
            Me.TextBoxImporteTributo.Text = 0.0
            Me.TextBoxTributoAlic.Text = 0.0
            Me.TextBoxRefTributo.Text = ""

            Me.ComboBoxTributos.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Crear Tributo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CrearCbteAsoc()
        Dim c As New Entidades.CbteAsociado
        Dim cbte As Object

        Try

            If Me.ComboBoxAsoc.SelectedItem Is Nothing Then
                Me.ComboBoxAsoc.Focus()
                Throw New Exception("El comprobante seleccionado no es válido")
            End If

            If Not IsNumeric(Me.TextBoxImporteAsoc.Text) Then
                Me.TextBoxImporteAsoc.Focus()
                Throw New Exception("El importe ingresado no es válido")
            End If

            If Convert.ToDouble(Me.TextBoxImporteAsoc.Text) <= 0 Then
                Me.TextBoxImporteAsoc.Focus()
                Throw New Exception("El importe ingresado no es válido")
            End If

            If Me.TipoDeCbte = TipoCbte.CBTEVTA Then
                cbte = DirectCast(Me.ComboBoxAsoc.SelectedItem, Entidades.CbteCabecera)
            Else
                cbte = DirectCast(Me.ComboBoxAsoc.SelectedItem, Entidades.CpraCabecera)
            End If

            c.Tipo = cbte.Cbtetipo
            c.PtoVta = cbte.Cbteptovta
            c.Numero = cbte.Cbtenumero
            c.CbteReferencia = cbte.Id
            c.Importe = Convert.ToDouble(Me.TextBoxImporteAsoc.Text)
            c.Denominacion = cbte.CbteDenominacion
            c.ImporteOriginal = cbte.Importetotal
            c.Fecha = ParseStringToDate(cbte.Cbtefecha)
            c.Saldo = cbte.SaldoEstadoCuenta

            AgregarCbteAsoc(c)

            PoblarGrillas()

            Totalizar()

            Me.ComboBoxAsoc.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Crear Cbte. Asociado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CrearCuentaPropia()
        Dim c As New Entidades.Financiero
        Dim concepto As Entidades.Conceptobancario
        Dim cuenta As Entidades.Cuentabancaria

        Try

            If Me.ComboBoxCtaBancaria.SelectedItem Is Nothing Then
                Me.ComboBoxCtaBancaria.Focus()
                Throw New Exception("La cuenta bancaria no es válido")
            End If

            If Me.ComboBoxConceptoBancario.SelectedItem Is Nothing Then
                Me.ComboBoxConceptoBancario.Focus()
                Throw New Exception("El concepto bancario no es válido")
            End If

            If Me.DateTimePickerEfectivizacion.Value < Date.Today Then
                If MessageBox.Show("La fecha de efectivización es menor a la fecha actual, continua?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                End If
            End If

            If Not IsNumeric(Me.TextBoxImporteCtaPropia.Text) Then
                Me.TextBoxImporteCtaPropia.Focus()
                Throw New Exception("El importe ingresado no es válido")
            End If

            If Convert.ToDouble(Me.TextBoxImporteCtaPropia.Text) <= 0 Then
                Me.TextBoxImporteCtaPropia.Focus()
                Throw New Exception("El importe ingresado no es válido")
            End If

            concepto = DirectCast(Me.ComboBoxConceptoBancario.SelectedItem, Entidades.Conceptobancario)
            cuenta = DirectCast(Me.ComboBoxCtaBancaria.SelectedItem, Entidades.Cuentabancaria)

            c.Tipo = concepto.Tipo
            c.Concepto = concepto.Codigo
            c.DetalleConcepto = concepto.Nombre
            c.Cuenta = cuenta.Codigo
            c.DetalleCuenta = cuenta.Nombre
            c.Referencia = Me.TextBoxReferencia.Text.Trim
            c.Efectivizacion = Me.DateTimePickerEfectivizacion.Value.Date
            c.Importe = Convert.ToDouble(Me.TextBoxImporteCtaPropia.Text)
            c.Sucursal = My.Settings.CodigoConsFinal
            c.Usuario = gUsuario.Id

            Select Case Me.TipoCargaCbte
                Case TipoEmisionCbte.RECIBO, TipoEmisionCbte.RECIBO_PRESUPUESTO, TipoEmisionCbte.RECIBO_NO_FISCAL
                    c.Origen = ORIGEN_FINANCIERO_COBRANZA
                Case TipoEmisionCbte.ORDEN_DE_PAGO, TipoEmisionCbte.PAGO_PRESUPUESTO
                    c.Origen = ORIGEN_FINANCIERO_PAGO
                Case Else
                    c.Origen = ORIGEN_FINANCIERO_VENTA
            End Select

            AgregarCtaPropia(c)

            PoblarGrillas()

            Totalizar()

            Me.ComboBoxCtaBancaria.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Crear Cuenta Propia", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub CrearCheque()
        Dim c As New Entidades.Financiero
        Dim cuenta As Entidades.Cuentabancaria
        Dim concepto As Entidades.Conceptobancario
        Dim repositorioCpto As New CapaLogica.ConceptobancarioCLog
        Dim repositorioCuenta As New CapaLogica.CuentabancariaCLog

        Try

            If Me.ComboBoxBancos.SelectedItem Is Nothing Then
                Me.ComboBoxBancos.Focus()
                Throw New Exception("El banco no es válido")
            End If

            If Me.ComboBoxLocalidad.SelectedItem Is Nothing Then
                Me.ComboBoxLocalidad.Focus()
                Throw New Exception("La localidad no es válida")
            End If

            If Me.TextBoxDador.Text.Trim.Length = 0 Then
                Me.TextBoxDador.Focus()
                Throw New Exception("El dador ingresado no es válido")
            End If

            If Me.TextBoxCUITLibrador.Text.Trim.Length = 0 Then
                Me.TextBoxCUITLibrador.Focus()
                Throw New Exception("El CUIT del librador ingresado no es válido")
            End If

            If (Date.Today - Me.DateTimePickerFechaCheque.Value).Days > 30 Then
                If MessageBox.Show("La fecha de cobro del cheque es correcta?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                End If
            End If

            If (Me.DateTimePickerFechaCheque.Value - Date.Today).Days >= 365 Then
                If MessageBox.Show("La fecha de cobro del cheque es correcta?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                End If
            End If

            If Not IsNumeric(Me.TextBoxImporteCartera.Text) Then
                Me.TextBoxImporteCartera.Focus()
                Throw New Exception("El importe ingresado no es válido")
            End If

            If Convert.ToDouble(Me.TextBoxImporteCartera.Text) <= 0 Then
                Me.TextBoxImporteCartera.Focus()
                Throw New Exception("El importe ingresado no es válido")
            End If

            concepto = repositorioCpto.GetByCodigo(CONCEPTO_CHEQUE_RECIBIDO)
            cuenta = repositorioCuenta.GetByCodigo(CUENTA_CARTERA)

            c.DocumentoNro = Me.TextBoxCUITLibrador.Text.Trim
            c.Dador = Me.TextBoxDador.Text.Trim
            c.Banco = DirectCast(Me.ComboBoxBancos.SelectedItem, Entidades.Banco).Codigo
            c.Localidad = DirectCast(Me.ComboBoxLocalidad.SelectedItem, Entidades.Localidad).Id
            c.Tipo = concepto.Tipo
            c.Concepto = concepto.Codigo
            c.DetalleConcepto = concepto.Nombre
            c.Cuenta = cuenta.Codigo
            c.DetalleCuenta = cuenta.Nombre
            c.Referencia = Me.TextBoxReferenciaCartera.Text.Trim
            c.Efectivizacion = Me.DateTimePickerFechaCheque.Value.Date
            c.Importe = Convert.ToDouble(Me.TextBoxImporteCartera.Text)
            c.Sucursal = My.Settings.CodigoConsFinal
            c.Usuario = gUsuario.Id

            Select Case Me.TipoCargaCbte
                Case TipoEmisionCbte.RECIBO, TipoEmisionCbte.RECIBO_PRESUPUESTO, TipoEmisionCbte.RECIBO_NO_FISCAL
                    c.Origen = ORIGEN_FINANCIERO_COBRANZA
                Case TipoEmisionCbte.ORDEN_DE_PAGO, TipoEmisionCbte.PAGO_PRESUPUESTO
                    c.Origen = ORIGEN_FINANCIERO_PAGO
                Case Else
                    c.Origen = ORIGEN_FINANCIERO_VENTA
            End Select

            AgregarCtaCheque(c)

            PoblarGrillas()

            Totalizar()

            Me.ComboBoxBancos.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Crear Cuenta Propia", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarCartera()
        Dim c As Entidades.Financiero
        Dim cuenta As Entidades.Cuentabancaria
        Dim concepto As Entidades.Conceptobancario
        Dim repositorioCpto As CapaLogica.ConceptobancarioCLog
        Dim repositorioCuenta As CapaLogica.CuentabancariaCLog
        Dim repositorio As CapaLogica.FinancieroCLog

        Try

            repositorioCpto = New CapaLogica.ConceptobancarioCLog
            repositorioCuenta = New CapaLogica.CuentabancariaCLog
            repositorio = New CapaLogica.FinancieroCLog

            concepto = repositorioCpto.GetByCodigo(CONCEPTO_CHEQUE_RECIBIDO)
            cuenta = repositorioCuenta.GetByCodigo(CUENTA_CARTERA)

            If Me.AnularDepositoNro <> 0 Then

                concepto = repositorioCpto.GetByCodigo(CONCEPTO_CHEQUE_DEPOSITADO)
                cuenta = repositorioCuenta.GetByCodigo(CUENTA_CARTERA)

                For Each c In repositorio.GetChequesDeposito(CUENTA_CARTERA, CONCEPTO_CHEQUE_DEPOSITADO, AnularDepositoNro)

                    If c.Concepto = concepto.Codigo Then

                        c.Checked = True
                        c.DetalleCuenta = cuenta.Nombre
                        c.DetalleConcepto = concepto.Nombre

                        'filtro los cheques en cartera por concepto de ingreso
                        If Me.TipoCargaCbte = TipoEmisionCbte.ORDEN_DE_PAGO Then
                            If c.CptoVta = RECIBO_COBRANZA Then
                                AgregarCtaCheque(c)
                            End If
                        ElseIf Me.TipoCargaCbte = TipoEmisionCbte.PAGO_PRESUPUESTO Then
                            If c.CptoVta = RECIBO_PRESUPUESTO Then
                                AgregarCtaCheque(c)
                            End If
                        Else 'Deposito cartera
                            AgregarCtaCheque(c)
                        End If

                    End If

                Next
            Else

                For Each c In repositorio.GetByCuenta(cuenta.Codigo)

                    If c.Concepto = concepto.Codigo Then

                        c.DetalleCuenta = cuenta.Nombre
                        c.DetalleConcepto = concepto.Nombre

                        'filtro los cheques en cartera por concepto de ingreso
                        If Me.TipoCargaCbte = TipoEmisionCbte.ORDEN_DE_PAGO Then
                            If c.CptoVta = RECIBO_COBRANZA Then
                                AgregarCtaCheque(c)
                            End If
                        ElseIf Me.TipoCargaCbte = TipoEmisionCbte.PAGO_PRESUPUESTO Then
                            If c.CptoVta = RECIBO_PRESUPUESTO Then
                                AgregarCtaCheque(c)
                            End If
                        Else 'Deposito cartera
                            AgregarCtaCheque(c)
                        End If

                    End If

                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Crear Cuenta Propia", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            repositorioCpto = Nothing
            repositorioCuenta = Nothing
            repositorio = Nothing
        End Try
    End Sub

    Private Sub FOLVOtrosTributos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FOLVOtrosTributos.KeyDown
        If e.KeyCode = Keys.Delete Then
            QuitarTributo()
        End If
    End Sub

    Private Sub TabPageOtros_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPageOtros.Click
        Me.ComboBoxTributos.Focus()
    End Sub

    Private Sub TabPageArt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPageArt.Click
        Me.ComboBoxArticulos.Focus()
    End Sub

    Public Sub FocoArticulo()
        Me.ActiveControl = Me.TabControlDetalleCbte
        Me.TabControlDetalleCbte.SelectedTab = Me.TabPageArt
        Me.ComboBoxArticulos.Select()
        Me.ComboBoxArticulos.Focus()
        Application.DoEvents()
    End Sub

    Public Sub FocoCuentasPropias()
        Me.ActiveControl = Me.TabControlDetalleCbte
        Me.TabControlDetalleCbte.SelectedTab = Me.TabPageCtasPropias
        Me.ComboBoxCtaBancaria.Select()
        Me.ComboBoxCtaBancaria.Focus()
        Application.DoEvents()
    End Sub

    Private Sub CustomKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Return
                If sender Is ComboBoxArticulos Then
                    'If Me.TipoDeCbte = TipoCbte.CBTECPRA Then
                    TextBoxCantidad.Focus()
                    'Else
                    '    TextBoxKgs.Focus()
                    'End If
                    'ElseIf sender Is TextBoxKgs Then
                    'TextBoxCantidad.Focus()
                ElseIf sender Is TextBoxCantidad Then
                    If Me.TipoDeCbte = TipoCbte.CBTEVTA Then
                        ComboBoxNroOrden.Focus()
                    Else
                        If TextBoxImporte.ReadOnly Then
                            TextBoxSubtotalArticulo.Focus()
                        Else
                            TextBoxImporte.Focus()
                        End If
                    End If
                ElseIf sender Is ComboBoxNroOrden Then
                    If TextBoxImporte.ReadOnly Then
                        TextBoxSubtotalArticulo.Focus()
                    Else
                        TextBoxImporte.Focus()
                    End If
                ElseIf sender Is TextBoxImporte Then
                    TextBoxDto.Focus()
                ElseIf sender Is TextBoxDto Then
                    'If TextBoxImporteImpInt.Enabled And Not TextBoxImporteImpInt.ReadOnly Then
                    '    TextBoxImporteImpInt.Focus()
                    'Else
                    If Me.TipoDeCbte = TipoCbte.CBTEVTA Then
                        TextBoxSubtotalArticulo.Focus()
                    Else
                        If ComboBoxArticuloAlicuota.Enabled Then
                            ComboBoxArticuloAlicuota.Focus()
                        Else
                            TextBoxSubtotalArticulo.Focus()
                        End If
                    End If
                    'End If
                ElseIf sender Is TextBoxImporteImpInt Then
                    If ComboBoxArticuloAlicuota.Enabled Then
                        ComboBoxArticuloAlicuota.Focus()
                    Else
                        TextBoxSubtotalArticulo.Focus()
                    End If
                ElseIf sender Is ComboBoxArticuloAlicuota Then
                    TextBoxSubtotalArticulo.Focus()
                ElseIf sender Is ComboBoxAsoc Then
                    TextBoxImporteAsoc.Focus()
                ElseIf sender Is ComboBoxTributos Then
                    ComboBoxDescTributo.Focus()
                ElseIf sender Is ComboBoxDescTributo Then
                    TextBoxRefTributo.Focus()
                ElseIf sender Is TextBoxRefTributo Then
                    TextBoxImporteTributo.Focus()
                ElseIf sender Is TextBoxImporteTributo Then
                    TextBoxBaseTributo.Focus()
                ElseIf sender Is TextBoxBaseTributo Then
                    TextBoxTributoAlic.Focus()
                ElseIf sender Is DateTimePickerEfectivizacion Then
                    TextBoxReferencia.Focus()
                ElseIf sender Is TextBoxReferencia Then
                    TextBoxImporteCtaPropia.Focus()
                ElseIf sender Is TextBoxDador Then
                    TextBoxCUITLibrador.Focus()
                ElseIf sender Is TextBoxCUITLibrador Then
                    TextBoxReferenciaCartera.Focus()
                ElseIf sender Is TextBoxReferenciaCartera Then
                    DateTimePickerFechaCheque.Focus()
                ElseIf sender Is DateTimePickerFechaCheque Then
                    TextBoxImporteCartera.Focus()
                ElseIf sender Is TextBoxImporteCartera Then
                    Call CrearCheque()
                ElseIf sender Is TextBoxSubtotalArticulo Then
                    If Me.TipoDeCbte = TipoCbte.CBTECPRA Then
                        AgregarMaterial()
                    Else
                        AgregarArticulo(0)
                    End If
                ElseIf sender Is TextBoxImporteAsoc Then
                    Call CrearCbteAsoc()
                ElseIf sender Is TextBoxImporteCtaPropia Then
                    Call CrearCuentaPropia()
                ElseIf sender Is TextBoxTributoAlic Then
                    Call CrearTributo()
                End If
        End Select
    End Sub

    Private Sub a_EnviaEnter()
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub BtnAgregarAsoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAgregarAsoc.Click
        CrearCbteAsoc()
    End Sub

    Private Sub FOLVCompAsoc_CellEditFinishing(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles FOLVCompAsoc.CellEditFinishing
        If Not e.Cancel Then

            Select Case e.Column.AspectName
                Case "Importe"
                    DirectCast(e.RowObject, Entidades.CbteAsociado).Importe = Convert.ToDouble(e.NewValue)
            End Select

            Me.FOLVCompAsoc.RefreshObject(Me.FOLVCompAsoc.SelectedObject)
            Me.FOLVCompAsoc.Refresh()
            My.Application.DoEvents()
        End If
        Totalizar()
    End Sub

    Private Sub FOLVCompAsoc_CellEditStarting(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles FOLVCompAsoc.CellEditStarting
        e.Control.BackColor = Color.LightGreen


        If e.Control.GetType = GetType(BrightIdeasSoftware.FloatCellEditor) Then
            DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Font = New Font(DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Font, FontStyle.Bold)
            DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Select(0, DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Text.Length)
        End If

    End Sub

    Private Sub FOLVCompAsoc_CellEditValidating(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles FOLVCompAsoc.CellEditValidating
        If (Val(e.NewValue) > DirectCast(e.RowObject, Entidades.CbteAsociado).Saldo And Not _verTodos) Or Val(e.NewValue) < 0 Then
            If e.Control.GetType = GetType(BrightIdeasSoftware.FloatCellEditor) Then
                DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).BackColor = Color.Red
                DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Select(0, DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Text.Length)
            End If
            e.Cancel = True
            'Else
            '    DirectCast(e.RowObject, Entidades.CbteAsociado).Importe = Convert.ToDouble(e.NewValue)
        End If
    End Sub

    Private Sub FOLVCompAsoc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FOLVCompAsoc.KeyDown
        If e.KeyCode = Keys.Delete Then
            QuitarAsociado()
        End If
    End Sub

    Private Sub InicializarCombos()

        Select Case TipoCargaCbte
            Case TipoEmisionCbte.ORDEN_DE_PAGO, TipoEmisionCbte.PAGO_PRESUPUESTO, TipoEmisionCbte.RECIBO, TipoEmisionCbte.RECIBO_PRESUPUESTO, TipoEmisionCbte.RECIBO_NO_FISCAL, TipoEmisionCbte.AJUSTE_ACREEDOR, TipoEmisionCbte.AJUSTE_DEUDOR

                If TipoCargaCbte = TipoEmisionCbte.RECIBO Or TipoCargaCbte = TipoEmisionCbte.RECIBO_PRESUPUESTO Or TipoEmisionCbte.RECIBO_NO_FISCAL Then
                    InicializarComboBancos()
                    InicializarComboLocalidades()
                End If

                InicializarComboCuentasBancarias()
                InicializarComboConceptosBancarios()
            Case TipoEmisionCbte.COMPRA
                InicializarComboArticulos()
                InicializarComboAlicuotas()
            Case Else
                InicializarComboArticulos()
                InicializarComboAlicuotas()
        End Select

        InicializarComboTributos()

    End Sub

    Private Sub CrearGrillas()
        CrearGrillaArticulos()
        CrearGrillaAlicuotas()
        CrearGrillaTributos()
        CrearGrillaCompAsoc()
        CrearGrillaCtasPropias()
        CrearGrillaCartera()
        CrearGrillaImportes()
    End Sub

    Private Sub BtnAgregarCtaPropia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAgregarCtaPropia.Click
        CrearCuentaPropia()
    End Sub

    Private Sub FOLVCtasPropias_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FOLVCtasPropias.KeyDown
        If e.KeyCode = Keys.Delete Then
            QuitarCtaPropia()
        End If
    End Sub

    Private Sub FOLVCartera_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles FOLVCartera.ItemCheck

    End Sub

    Private Sub FOLVCartera_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles FOLVCartera.ItemChecked
        Totalizar()
    End Sub

    Private Sub FOLVCartera_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FOLVCartera.KeyDown
        If e.KeyCode = Keys.Delete Then
            QuitarCheque()
        End If
    End Sub

    Private Sub InicializarComboBancos()
        Dim repositorio As New CapaLogica.BancoCLog

        With Me.ComboBoxBancos
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"

            .DataSource = repositorio.GetAll
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            .SelectedIndex = -1

        End With
    End Sub

    Private Sub InicializarComboLocalidades()
        Dim repositorio As New CapaLogica.LocalidadCLog
        Dim c As BrightIdeasSoftware.OLVColumn = Nothing
        Dim cols As New List(Of BrightIdeasSoftware.OLVColumn)

        With Me.ComboBoxLocalidad
            .ValueMember = "Id"
            .DisplayMember = "Nombre"

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Cód. Postal"
            c.AspectName = "Codigopostal"
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Center
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            cols.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Provincia"
            c.AspectName = "Provincia"
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Center
            c.FillsFreeSpace = True
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            cols.Add(c)

            .ColumnasExtras = cols
            .DataSource = repositorio.GetAll
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub BtnAgregarCheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarCheque.Click
        CrearCheque()
    End Sub

    Private Sub ComboBoxAsoc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxAsoc.SelectedIndexChanged
        If ComboBoxAsoc.SelectedItem IsNot Nothing Then
            If Me.TipoDeCbte = TipoCbte.CBTEVTA Then
                Me.TextBoxImporteAsoc.Text = DirectCast(ComboBoxAsoc.SelectedItem, Entidades.CbteCabecera).SaldoEstadoCuenta
            ElseIf Me.TipoDeCbte = TipoCbte.CBTECPRA Then
                Me.TextBoxImporteAsoc.Text = DirectCast(ComboBoxAsoc.SelectedItem, Entidades.CpraCabecera).SaldoEstadoCuenta
            End If
        Else
            Me.TextBoxImporteAsoc.Text = "0"
        End If
    End Sub

    Private Sub FOLVAlicuotas_CellEditFinishing(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles FOLVAlicuotas.CellEditFinishing
        Totalizar()
    End Sub

    Private Sub FOLVAlicuotas_CellEditStarting(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles FOLVAlicuotas.CellEditStarting
        e.Control.BackColor = Color.LightGreen
        If e.Control.GetType = GetType(BrightIdeasSoftware.FloatCellEditor) Then
            DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Font = New Font(DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Font, FontStyle.Bold)
            DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Select(0, DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Text.Length)
        End If

    End Sub

    Private Sub FOLVAlicuotas_CellEditValidating(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles FOLVAlicuotas.CellEditValidating
        If Val(e.NewValue) < 0 Then
            If e.Control.GetType = GetType(BrightIdeasSoftware.FloatCellEditor) Then
                DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).BackColor = Color.Red
                DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Select(0, DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Text.Length)
            End If
            e.Cancel = True
        End If
    End Sub

    Private Sub FOLVArticulos_CellEditStarting(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles FOLVArticulos.CellEditStarting

        If FOLVArticulos.SelectedObject IsNot Nothing Then
            If DirectCast(FOLVArticulos.SelectedObject, Entidades.CbteArticulo).Modificable Or _
                DirectCast(FOLVArticulos.SelectedObject, Entidades.CbteArticulo).Codigo = ARTICULO_VARIOS Then
                e.Control.BackColor = Color.LightGreen
                e.Control.Font = New Font(e.Control.Font, FontStyle.Bold)
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = True
        End If

    End Sub

    Private Sub ComboBoxConceptoBancario_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxConceptoBancario.SelectedIndexChanged
        'calculo la fecha de efectivizacion en base a la fecha actual mas los dias de plazo
        If Me.ComboBoxConceptoBancario.SelectedItem IsNot Nothing Then
            Me.DateTimePickerEfectivizacion.Value = Date.Today.AddDays(DirectCast(Me.ComboBoxConceptoBancario.SelectedItem, Entidades.Conceptobancario).Plazo)
        End If
    End Sub

    Private Sub CargarImportes()
        Dim i As Importes

        _importes.Clear()

        i = New Importes
        i.Tipo = TiposImportes.NETO_GRAVADO
        i.Detalle = "Neto Gravado"
        i.Importe = 0

        _importes.Add(i)

        i = New Importes
        i.Tipo = TiposImportes.IVA
        i.Detalle = "I.V.A. al 2.50%"
        i.Codigo = IVA_25
        i.Alicuota = 2.5
        i.Importe = 0

        _importes.Add(i)

        i = New Importes
        i.Tipo = TiposImportes.IVA
        i.Detalle = "I.V.A. al 5.00%"
        i.Codigo = IVA_5
        i.Alicuota = 5
        i.Importe = 0

        _importes.Add(i)

        i = New Importes
        i.Tipo = TiposImportes.IVA
        i.Detalle = "I.V.A. al 10.50%"
        i.Codigo = IVA_105
        i.Alicuota = 10.5
        i.Importe = 0

        _importes.Add(i)

        i = New Importes
        i.Tipo = TiposImportes.IVA
        i.Detalle = "I.V.A. al 21.00%"
        i.Codigo = IVA_21
        i.Alicuota = 21.0
        i.Importe = 0

        _importes.Add(i)

        i = New Importes
        i.Tipo = TiposImportes.IVA
        i.Detalle = "I.V.A. al 27.00%"
        i.Codigo = IVA_27
        i.Alicuota = 27.0
        i.Importe = 0

        _importes.Add(i)

        i = New Importes
        i.Tipo = TiposImportes.EXENTO
        i.Detalle = "Exento"
        i.Codigo = 0
        i.Importe = 0

        _importes.Add(i)

        i = New Importes
        i.Tipo = TiposImportes.NO_GRAVADO
        i.Detalle = "No Gravado"
        i.Codigo = 0
        i.Importe = 0

        _importes.Add(i)

        i = New Importes
        i.Tipo = TiposImportes.TRIBUTO
        i.Detalle = "Per./Ret. de Impuesto a las Ganancias"
        i.Codigo = AFIP_COD_IMPUESTO_NACIONAL
        i.Importe = 0

        _importes.Add(i)

        i = New Importes
        i.Tipo = TiposImportes.TRIBUTO
        i.Detalle = "Per./Ret. de IVA"
        i.Codigo = AFIP_COD_IMPUESTO_NACIONAL
        i.Importe = 0

        _importes.Add(i)

        i = New Importes
        i.Tipo = TiposImportes.TRIBUTO
        i.Detalle = "Per./Ret. Ley 25413"
        i.Codigo = AFIP_COD_IMPUESTO_NACIONAL
        i.Importe = 0

        _importes.Add(i)

        i = New Importes
        i.Tipo = TiposImportes.TRIBUTO
        i.Detalle = "Per./Ret. de Ingresos Brutos"
        i.Codigo = AFIP_COD_IMPUESTO_PROVINCIAL
        i.Importe = 0

        _importes.Add(i)

        i = New Importes
        i.Tipo = TiposImportes.TRIBUTO
        i.Detalle = "Impuestos Municipales"
        i.Codigo = AFIP_COD_IMPUESTO_MUNICIPAL
        i.Importe = 0

        _importes.Add(i)

        i = New Importes
        i.Tipo = TiposImportes.TRIBUTO
        i.Detalle = "Impuestos Internos"
        i.Codigo = AFIP_COD_IMPUESTO_INTERNO
        i.Importe = 0

        _importes.Add(i)

        i = New Importes
        i.Tipo = TiposImportes.TRIBUTO
        i.Detalle = "Otros Tributos"
        i.Codigo = AFIP_COD_IMPUESTO_OTROS
        i.Importe = 0

        _importes.Add(i)

        i = New Importes
        i.Tipo = TiposImportes.NO_INSCRIPTO
        i.Detalle = "Otras Compras"
        i.Codigo = 0
        i.Importe = 0

        _importes.Add(i)

        'i = New Importes
        'i.Tipo = TiposImportes.TOTAL
        'i.Detalle = "Importe Total"
        'i.Importe = 0

        '_importes.Add(i)

    End Sub

    Private Sub FOLVImportes_CellEditFinishing(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles FOLVImportes.CellEditFinishing
        Totalizar()
    End Sub

    Private Sub FOLVImportes_CellEditStarting(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles FOLVImportes.CellEditStarting

        e.Control.BackColor = Color.LightGreen

        If e.Control.GetType = GetType(BrightIdeasSoftware.FloatCellEditor) Then
            DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Font = New Font(DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Font, FontStyle.Bold)
            DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Select(0, DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Text.Length)
        End If

    End Sub

    Private Sub FOLVImportes_CellEditValidating(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles FOLVImportes.CellEditValidating
        If Val(e.NewValue) < 0 Then
            If e.Control.GetType = GetType(BrightIdeasSoftware.FloatCellEditor) Then
                DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).BackColor = Color.Red
                DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Select(0, DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Text.Length)
            End If
            e.Cancel = True
        End If
    End Sub

    Public Sub CargarArticulosRemito(ByVal id As UInt32)
        Dim repositorio As CapaLogica.CbtecabeceraCLog
        Dim cbte As Entidades.CbteCabecera
        Dim repo As New CapaLogica.ArticuloCLog
        'Dim _Lista As Entidades.Moldeocab

        Try
            repositorio = New CapaLogica.CbtecabeceraCLog
            cbte = repositorio.GetById(id)

            mblnPrecargaRemito = True
            'Recorro los Artículos y voy cargando a la grilla
            For Each articulo As Entidades.CbteArticulo In cbte.CbteArticulos
                'articulos cabecera
                'If articulo.Codigo <> ARTICULO_VARIOS Then
                '    Me.ComboBoxArticulos.SelectedValue = repo.GetByCodigoBarra(articulo.Codigo, articulo.Codcliente).Id
                'Else
                Me.ComboBoxArticulos.SelectedValue = repo.GetByCodigo(articulo.Codigo).Id
                'End If

                '_ListaNroOrden.Clear()
                '_Lista = New Entidades.Moldeocab
                '_Lista.Id = 0
                '_Lista.Numero = articulo.Numero
                '_Lista.Secuencia = articulo.Secuencia
                '_ListaNroOrden.Add(_Lista)
                'InicializarComboOrdenCompra(True)

                Me.TextBoxCantidad.Text = articulo.Cantidad
                'Me.TextBoxKgs.Text = articulo.Kgs
                Me.TextBoxKxU.Text = articulo.Kgsxunidad
                Me.TextBoxImporte.Text = articulo.Importe
                Me.TextBoxImporteImpInt.Text = articulo.ImpInterno
                Me.TextBoxDto.Text = articulo.Descuento
                Me.ComboBoxArticuloAlicuota.SelectedValue = articulo.AlicuotaCodigo
                My.Application.DoEvents()

                AgregarArticulo(articulo.Numero, articulo.Descripcion)
            Next
            mblnPrecargaRemito = False

            '_articulos = cbte.CbteArticulos
            '_tributos = cbte.CbteTributos
            '_alicuotas = cbte.CbteAlicuotas

            'PoblarGrillas()

            'Totalizar()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Cargar artículos del remito", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            repositorio = Nothing
        End Try

    End Sub

    Private Sub FOLVImportes_FormatCell(ByVal sender As Object, ByVal e As BrightIdeasSoftware.FormatCellEventArgs) Handles FOLVImportes.FormatCell
        Select Case e.Column.AspectName
            Case "Importe"
                If e.CellValue <> 0 Then
                    e.SubItem.Font = New System.Drawing.Font(e.SubItem.Font.Name, e.SubItem.Font.Size, FontStyle.Bold)
                Else
                    e.SubItem.Font = New System.Drawing.Font(e.SubItem.Font.Name, e.SubItem.Font.Size, FontStyle.Regular)
                End If
        End Select
    End Sub

    'Private Sub TabControlDetalleCbte_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControlDetalleCbte.TabIndexChanged
    '    If TabControlDetalleCbte.SelectedTab Is TabPageCartera Then
    '        Select Me.TipoCargaCbte
    '            Case TipoEmisionCbte.RECIBO, TipoEmisionCbte.RECIBO_PRESUPUESTO
    '                Me.ComboBoxBancos.FocoDetalle()
    '        End Select
    '    ElseIf TabControlDetalleCbte.SelectedTab Is TabPageCtasPropias Then
    '        Me.ComboBoxCtaBancaria.FocoDetalle()
    '    ElseIf TabControlDetalleCbte.SelectedTab Is TabPageArt Then
    '        Me.ComboBoxArticulos.FocoDetalle()
    '    End If
    'End Sub

    Private Sub InicializarParametros()

        Dim repositorio As New CapaLogica.ParametroCLog

        Try
            _montoNoSujetoRetIB = repositorio.GetMinimoNoSujetoIIBB
            _montoMinimoRetIva = repositorio.GetMinimoRetIva

            If Me.TipoCargaCbte = TipoEmisionCbte.ORDEN_DE_PAGO Then
                _NroCbteRetIB = repositorio.GetNroCbteRetIB + 1
                _NroCbteRetIva = repositorio.GetNroCbteRetIva + 1
                _NroCbteRetGcia = repositorio.GetNroCbteRetGcia + 1
            End If

            AJUSTES_CPTO_DEUDOR = repositorio.GetByNombre("ConceptoAjusteIngreso").Valorpredeterminado
            AJUSTES_CPTO_ACREEDOR = repositorio.GetByNombre("ConceptoAjusteEgreso").Valorpredeterminado
            AJUSTES_CUENTA_BCO = repositorio.GetByNombre("CuentaBancariaAjuste").Valorpredeterminado

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Inicializar Parametros", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            repositorio = Nothing
        End Try

    End Sub

    Private Sub CheckBoxVerTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxVerTodos.Click
        _verTodos = CheckBoxVerTodos.Checked

        If Me.TipoDeCbte = TipoCbte.CBTECPRA Then
            InicializarComboCbteProveedor(Me.Proveedor)
        Else
            InicializarComboCbteCliente(Me.Cliente)
        End If

    End Sub

    Private Sub CheckBoxCtaCte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxCtaCte.Click
        VerCuentaCta = CheckBoxCtaCte.Checked

        If Me.TipoDeCbte = TipoCbte.CBTECPRA Then
            InicializarComboCbteProveedor(Me.Proveedor)
        Else
            InicializarComboCbteCliente(Me.Cliente)
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    ''' <summary>
    ''' Sobre el minimo no imponible, se aplica el porcentaje sobre el neto para los Responsables Inscriptos y sobre el neto + iva para el resto
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Private Sub CalculoIngresosBrutos(ByVal subtotal As Double, ByVal iva As Double, ByVal ctaspropias As Double, ByVal cartera As Double)
        Dim ret As New Entidades.CbteTributo
        Dim base As Double = 0.0
        Dim alicuota As Double = 0.0

        If TipoDeCbte = TipoCbte.CBTEVTA Then
            If Me.TipoCargaCbte = TipoEmisionCbte.ELECTRONICO Or Me.TipoCargaCbte = TipoEmisionCbte.FISCAL Or Me.TipoCargaCbte = TipoEmisionCbte.PREIMPRESO Then
                If Me.Cliente IsNot Nothing Then
                    If Me.Cliente.Codigoingresosbrutos <> IIBB_NO_INSC_NO_OBLIGADO Then
                        If Me.Cliente.Tiporesponsable = AFIP_IVA_RESPONSABLE_INSCRIPTO Then
                            base = subtotal
                        Else
                            base = (subtotal + iva)
                        End If

                        If (base <= 0 Or base <= _montoNoSujetoRetIB) Then base = 0

                        ret.Alicuota = Me.Cliente.Ingresosbrutosalic
                        ret.BaseImponible = base
                        ret.Importe = Math.Round((ret.BaseImponible * ret.Alicuota) / 100, 2)
                        ret.Codigo = AFIP_COD_IMPUESTO_PROVINCIAL
                        ret.Descripcion = TRIBUTO_PERC_RET_IIBB '"Per./Ret. de Ingresos Brutos"
                        ret.Referencia = _NroCbteRetIB.ToString

                        'If ret.Importe > 0 Then
                        AgregarTributo(ret, True)
                        PoblarGrillaTributos()
                        'End If


                    End If
                End If
            End If
        End If

        If TipoDeCbte = TipoCbte.CBTECPRA Then
            If Me.TipoCargaCbte = TipoEmisionCbte.ORDEN_DE_PAGO Then
                If Me.Proveedor IsNot Nothing Then
                    If Me.Proveedor.Ingresosbrutosalic > 0 And (ctaspropias + cartera) > _montoNoSujetoRetIB Then
                        If Me.Proveedor.Ingresosbrutosalic <> 100 And Me.Proveedor.Ingresosbrutosalic <> 0.7 Then
                            base = Math.Round(((Me.Proveedor.Ingresosbrutosalic * ((ctaspropias + cartera) / 1.21)) / 100), 2)
                            ret.Alicuota = Me.Proveedor.Ingresosbrutosalic
                            '        UJIJI=((Wpormul*(Wtotal/1.21))/100)
                            '        Wreico=ROUND((UJIJI*WMIB)/100,2)
                            '        Xcalculo=UJIJI
                        Else

                            '        IF Wregesp=[N]
                            '           Wreico=ROUND((WTotal/1.21)*WMIB/100,2)
                            '           Xcalculo=(WTotal/1.21)
                            '        ELSE
                            '           UJIJI=((Wpormul*Wtotal)/100)
                            '           Wreico=ROUND((UJIJI*WMIB)/100,2)
                            '           Xcalculo=UJIJI

                            If Not Me.Proveedor.Conveniomultilateral Then
                                base = Math.Round((((ctaspropias + cartera) / 1.21) / 100), 2)
                                ret.Alicuota = Me.Proveedor.Ingresosbrutosalic
                            Else
                                base = Math.Round(((Me.Proveedor.Ingresosbrutosalic * (ctaspropias + cartera)) / 100), 2)
                                ret.Alicuota = Me.Proveedor.Ingresosbrutosalic
                            End If
                        End If

                        If (base <= 0 Or base <= _montoNoSujetoRetIB) Then base = 0

                        ret.BaseImponible = base
                        ret.Importe = Math.Round((ret.BaseImponible * ret.Alicuota) / 100, 2)
                        ret.Codigo = AFIP_COD_IMPUESTO_PROVINCIAL
                        ret.Descripcion = TRIBUTO_PERC_RET_IIBB
                        ret.Referencia = _NroCbteRetIB.ToString

                        'If ret.Importe > 0 Then
                        AgregarTributo(ret, True)
                        PoblarGrillaTributos()
                        'End If
                    End If
                End If
            End If
        End If


    End Sub

    ''' <summary>
    ''' Sobre el minimo no imponible, se aplica el porcentaje sobre el iva para los Responsables Inscriptos
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Private Sub CalculoRetencionIvas(ByVal ctaspropias As Double, ByVal cartera As Double)
        Dim ret As New Entidades.CbteTributo
        Dim repoIva As New CapaLogica.CpracabeceraCLog
        Dim base As Double = 0.0
        Dim alicuota As Double = 0.0

        Dim impIva As Double = 0.0
        Dim dblPorc As Double = 0.0
        Dim dblRetIva As Double = 0.0

        If TipoDeCbte = TipoCbte.CBTECPRA Then
            If Me.TipoCargaCbte = TipoEmisionCbte.ORDEN_DE_PAGO Then
                If Me.Proveedor IsNot Nothing Then
                    If Me.Proveedor.Tiporesponsable = AFIP_IVA_RESPONSABLE_INSCRIPTO Then
                        'If Me.Proveedor.Retivaalic > 0 And (ctaspropias + cartera) > 0 Then
                        If Me.Proveedor.Retivaalic > 0 And (_totalaplicado) > 0 Then

                            For Each o As Entidades.CbteAsociado In _cbtesasociados
                                'Recupero el Iva del Comprobante Asociado
                                impIva = repoIva.GetTotalIvaCbteRef(Me.Proveedor.Id, o.CbteReferencia)

                                'Veo que % le aplica del Pago
                                dblPorc = Math.Round(((o.Importe * 100) / o.Saldo) / 100, 4)

                                'Aplico el % al Iva de los Cbtes. Asociados
                                dblRetIva += Math.Round(impIva * dblPorc, 2)
                            Next

                            'Calculo la Retención de IVA del Proveedor
                            base = dblRetIva
                            dblRetIva = Math.Round(dblRetIva * (Me.Proveedor.Retivaalic / 100), 2)

                            If (dblRetIva <= 0 Or dblRetIva <= _montoMinimoRetIva) Then dblRetIva = 0
                            If base <= 0 Then base = 0

                            ret.Alicuota = Me.Proveedor.Retivaalic
                            ret.BaseImponible = base
                            ret.Importe = dblRetIva
                            ret.Codigo = AFIP_COD_IMPUESTO_NACIONAL
                            ret.Descripcion = TRIBUTO_PERC_RET_IVA
                            ret.Referencia = _NroCbteRetIva.ToString

                            'If ret.Importe > 0 Then
                            AgregarTributo(ret, True)
                            PoblarGrillaTributos()
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub CalculoRetencionGcias(ByVal ctaspropias As Double, ByVal cartera As Double)
        Dim ret As New Entidades.CbteTributo
        Dim I As Long
        Dim a As Long
        Dim alicuota As Double
        Dim alicuotaActividad As Double
        Dim alfa As Double
        'Dim mstrMa As String
        'Dim mdblTop0 As Double
        Dim topeAnterior As Double
        Dim topeActividad As Double

        Dim dblTot As Double
        Dim base As Double
        Dim base1 As Double
        Dim base2 As Double
        Dim iva As Double
        Dim porcentajeIva As Double = 21
        Dim per1 As Double, per2 As Double, RG2784 As Double
        Dim nosujeto As Double
        Dim pagosanteriores As Double
        Dim retencionesanteriores As Double
        Dim pagototal As Double
        Dim reporubroganancias As New CapaLogica.RubrogciaCLog
        Dim rubroganancias As New Entidades.Rubrogcia
        Dim repositorio As New CapaLogica.CpracabeceraCLog

        If Me.Proveedor Is Nothing Then Exit Sub

        dblTot = ctaspropias + cartera

        If Me.Proveedor.Tiporesponsable = AFIP_IVA_RESPONSABLE_INSCRIPTO Then
            base = Math.Round(dblTot / (1 + (porcentajeIva / 100)), 2)
            iva = Math.Round(dblTot - base, 2)
        Else
            base = dblTot
            iva = 0
        End If

        base1 = 0
        base2 = 0
        per1 = 0
        per2 = 0
        RG2784 = 0

        If Me.Proveedor.Ganancias = GCIAS_NO_PASIBLE_RETENCION Then Exit Sub

        rubroganancias = reporubroganancias.GetById(Me.Proveedor.Rubrogcia)

        If rubroganancias Is Nothing Then Exit Sub

        nosujeto = rubroganancias.Nosujeto

        'Calculo los Pagos Anteriores en CuentasP
        pagosanteriores = repositorio.GetTotalPagosPeriodo(Me.Proveedor.Id, FechaComprobante) '0.0 'a_TotalPagoCtasP(mstrIdProveedor, CStr(Month(mdatFechaComp)), CStr(Year(mdatFechaComp)), mstrIva, porcentajeIva)

        'Calculo las Retenciones de Pagos Anteriores en Pagos
        retencionesanteriores = repositorio.GetTotalRetGciasPeriodo(Me.Proveedor.Id, FechaComprobante) '0.0 'a_TotalPagos(mstrIdProveedor, CStr(Month(mdatFechaComp)), CStr(Year(mdatFechaComp)))

        'Calculo el Pago Total (Actual + Anterior)
        pagototal = base + pagosanteriores

        If pagototal > nosujeto Then
            If Me.Proveedor.Ganancias = GCIAS_NO_INSCRIPTO_RETENCION Then
                per1 = 0
                per2 = 0

                base1 = Math.Round(pagototal - nosujeto, 2)
                base2 = Math.Round(pagosanteriores - nosujeto, 2)
                alicuota = rubroganancias.Noinscripto
                If base2 < 0 Then
                    base2 = 0
                Else
                    per2 = Math.Round(base2 * (alicuota / 100), 2)
                End If

                per1 = Math.Round(base1 * (alicuota / 100), 2)
                base = base1 - base2
                RG2784 = per1 - per2
            Else 'si es incripto
                per1 = 0
                per2 = 0
                base1 = Math.Round(pagototal - nosujeto, 2)
                base2 = Math.Round(pagosanteriores - nosujeto, 2)

                If base2 < 0 Then
                    base2 = 0
                Else
                    I = 1
                    For I = 1 To 7
                        Select Case I
                            Case 1
                                alicuota = rubroganancias.Tope1alic
                                topeActividad = rubroganancias.Tope1
                            Case 2
                                alicuota = rubroganancias.Tope2alic
                                topeActividad = rubroganancias.Tope2
                            Case 3
                                alicuota = rubroganancias.Tope3alic
                                topeActividad = rubroganancias.Tope3
                            Case 4
                                alicuota = rubroganancias.Tope4alic
                                topeActividad = rubroganancias.Tope4
                            Case 5
                                alicuota = rubroganancias.Tope5alic
                                topeActividad = rubroganancias.Tope5
                            Case 6
                                alicuota = rubroganancias.Tope6alic
                                topeActividad = rubroganancias.Tope6
                            Case 7
                                alicuota = rubroganancias.Tope7alic
                                topeActividad = rubroganancias.Tope7
                        End Select

                        If base2 <= topeActividad Then
                            alfa = 0
                            'mstrMa = "0"
                            'mdblTop0 = 0
                            topeAnterior = 0
                            topeActividad = 0
                            alicuotaActividad = 0
                            For a = 1 To I - 1
                                Select Case a
                                    Case 1
                                        topeAnterior = 0
                                        alicuota = rubroganancias.Tope1alic
                                        topeActividad = rubroganancias.Tope1
                                    Case 2
                                        topeAnterior = rubroganancias.Tope1
                                        alicuota = rubroganancias.Tope2alic
                                        topeActividad = rubroganancias.Tope2
                                    Case 3
                                        topeAnterior = rubroganancias.Tope2
                                        alicuota = rubroganancias.Tope3alic
                                        topeActividad = rubroganancias.Tope3
                                    Case 4
                                        topeAnterior = rubroganancias.Tope3
                                        alicuota = rubroganancias.Tope4alic
                                        topeActividad = rubroganancias.Tope4
                                    Case 5
                                        topeAnterior = rubroganancias.Tope4
                                        alicuota = rubroganancias.Tope5alic
                                        topeActividad = rubroganancias.Tope5
                                    Case 6
                                        topeAnterior = rubroganancias.Tope5
                                        alicuota = rubroganancias.Tope6alic
                                        topeActividad = rubroganancias.Tope6
                                    Case 7
                                        topeAnterior = rubroganancias.Tope6
                                        alicuota = rubroganancias.Tope7alic
                                        topeActividad = rubroganancias.Tope7
                                End Select

                                alfa = alfa + ((topeActividad - topeAnterior) * (alicuotaActividad / 100))
                            Next a
                            per2 = Math.Round(alfa + ((base2 - topeActividad) * (alicuota / 100)), 2)
                            Exit For
                        End If
                    Next I
                End If

                I = 1
                For I = 1 To 7
                    Select Case I
                        Case 1
                            alicuota = rubroganancias.Tope1alic
                            topeActividad = rubroganancias.Tope1
                        Case 2
                            alicuota = rubroganancias.Tope2alic
                            topeActividad = rubroganancias.Tope2
                        Case 3
                            alicuota = rubroganancias.Tope3alic
                            topeActividad = rubroganancias.Tope3
                        Case 4
                            alicuota = rubroganancias.Tope4alic
                            topeActividad = rubroganancias.Tope4
                        Case 5
                            alicuota = rubroganancias.Tope5alic
                            topeActividad = rubroganancias.Tope5
                        Case 6
                            alicuota = rubroganancias.Tope6alic
                            topeActividad = rubroganancias.Tope6
                        Case 7
                            alicuota = rubroganancias.Tope7alic
                            topeActividad = rubroganancias.Tope7
                    End Select

                    If base1 <= topeActividad Then
                        alfa = 0
                        'mstrMa = "0"
                        'mdblTop0 = 0
                        topeAnterior = 0
                        topeActividad = 0
                        alicuotaActividad = 0
                        For a = 1 To I - 1
                            Select Case a
                                Case 1
                                    topeAnterior = 0
                                    alicuota = rubroganancias.Tope1alic
                                    topeActividad = rubroganancias.Tope1
                                Case 2
                                    topeAnterior = rubroganancias.Tope1
                                    alicuota = rubroganancias.Tope2alic
                                    topeActividad = rubroganancias.Tope2
                                Case 3
                                    topeAnterior = rubroganancias.Tope2
                                    alicuota = rubroganancias.Tope3alic
                                    topeActividad = rubroganancias.Tope3
                                Case 4
                                    topeAnterior = rubroganancias.Tope3
                                    alicuota = rubroganancias.Tope4alic
                                    topeActividad = rubroganancias.Tope4
                                Case 5
                                    topeAnterior = rubroganancias.Tope4
                                    alicuota = rubroganancias.Tope5alic
                                    topeActividad = rubroganancias.Tope5
                                Case 6
                                    topeAnterior = rubroganancias.Tope5
                                    alicuota = rubroganancias.Tope6alic
                                    topeActividad = rubroganancias.Tope6
                                Case 7
                                    topeAnterior = rubroganancias.Tope6
                                    alicuota = rubroganancias.Tope7alic
                                    topeActividad = rubroganancias.Tope7
                            End Select

                            alfa = alfa + ((topeActividad - topeAnterior) * (alicuotaActividad / 100))
                        Next a
                        per1 = Math.Round(alfa + ((base1 - topeActividad) * (alicuota / 100)), 2)
                        Exit For
                    End If
                Next I
                base = base1 - base2
                RG2784 = per1 - per2
            End If
        End If

        If RG2784 <= rubroganancias.Minimo Then
            RG2784 = 0
        End If

        ret.BaseImponible = base
        If base > 0 Then
            ret.Alicuota = Math.Round((RG2784 / base) * 100, 2)
        Else
            ret.Alicuota = 0
        End If

        ret.Importe = RG2784 'Math.Round((ret.BaseImponible * ret.Alicuota) / 100, 2)
        ret.Codigo = AFIP_COD_IMPUESTO_NACIONAL
        ret.Descripcion = TRIBUTO_PERC_RET_GCIAS
        ret.Referencia = _NroCbteRetGcia.ToString

        AgregarTributo(ret, True)
        PoblarGrillaTributos()


        reporubroganancias = Nothing

    End Sub

End Class
