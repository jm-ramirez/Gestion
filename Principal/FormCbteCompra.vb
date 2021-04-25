Imports Microsoft.VisualBasic.FileIO.FileSystem
Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO
Imports System.Text
Imports System.Security

Public Class FormCbteCompra

    Property TipoCbte As TipoEmisionCbte

    Private _decimalSeparator As Char
    'totalizadores del comprobante
    Private _subtotal As Double = 0.0
    Private _iva As Double = 0.0
    Private _otrostributos As Double = 0.0
    Private _exento As Double = 0.0
    Private _nogravado As Double = 0.0
    Private _total As Double = 0.0
    Private _totalaplicado As Double = 0.0
    Private _noinscripto As Double = 0.0

    Private _repositorio As New CapaLogica.CpracabeceraCLog
    Private _repositorioTipocomprobante As New CapaLogica.TipocomprobanteCLog
    Private _repositorioConcepto As New CapaLogica.ConceptobancarioCLog
    Private _repositorioCuenta As New CapaLogica.CuentabancariaCLog
    Private _repositorioPuntoventa As New CapaLogica.CbtepuntoventaCLog
    Private Const FP_CONTADO As UInteger = 1
    Private Const FP_CTACTE As UInteger = 2
    Private Const PTO_VTA_ELECTRONICO As String = "E"
    Private Const PTO_VTA_FISCAL As String = "F"
    Private Const PTO_VTA_MANUAL As String = "M"
    Private Const PTO_VTA_X As String = "X"

    Private Const PRODUCTOS As Integer = 1
    Private Const SERVICIOS As Integer = 2
    Private Const PRODUCTOS_Y_SERVICIOS As Integer = 3

    'Case 1, 2, 6, 7, 81, 82 'facturas y notas de debito
    '3 y 8 notas de credito

    Private blnModifica As Boolean

    Private Const RESPONSABLE_INSCRIPTO As UInt32 = 1

    Private _autorizandoCbte As Boolean
    Private _ctabcopredeterminada As Entidades.Cuentabancaria
    Private _cptobcoingpredetermiando As Entidades.Conceptobancario
    Private _cptobcoegrpredetermiando As Entidades.Conceptobancario

    Private Sub LockScreen(ByVal lock As Boolean)
        Me.ToolStripButtonAutorizar.Enabled = Not lock
        Me.ToolStripButtonCancelar.Enabled = Not lock
        Me.ToolStripButtonBarCode.Enabled = Not lock
        Me.PanelControles.Enabled = Not lock
        Me.ComboBoxProveedor.FocoDetalle()
        Application.DoEvents()
    End Sub

    Private Sub LockDatosProveedor(ByVal lock As Boolean)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        For Each c As Control In Me.GroupBoxDatosProveedor.Controls
            Select Case c.GetType
                Case GetType(TextBox)
                    DirectCast(c, TextBox).ReadOnly = lock
                Case GetType(ComboBox)
                    DirectCast(c, ComboBox).Enabled = Not lock
                Case GetType(CtlCustomCombo)
                    DirectCast(c, CtlCustomCombo).Enabled = Not lock
            End Select
        Next
    End Sub

    Private Sub InicializarFormulario()

        Select Case Me.TipoCbte
            Case TipoEmisionCbte.ELECTRONICO : Me.Text = "Emisión de comprobante electrónico por Web Service"
            Case TipoEmisionCbte.FISCAL : Me.Text = "Emisión de comprobante por controlador fiscal"
            Case TipoEmisionCbte.PREIMPRESO : Me.Text = "Emisión de Cbte. Preimpreso"
            Case TipoEmisionCbte.PRESUPUESTO : Me.Text = "Carga de Nota de Pedido"
            Case TipoEmisionCbte.COMPRA : Me.Text = "Carga de Comprobante de Compras"
            Case Else : Me.Text = "Operación no definida"
        End Select


        'Me.ToolStripButtonCancelar.Enabled = _conectado
        'Me.ToolStripButtonAutorizar.Enabled = _conectado
        'Me.ToolStripButtonConectarWSAA.Enabled = Not conectado

        'cambios de estados
        'ChequearStatusServer()

        'InicializarValoresPredeterminados()

        'inicio los combos solo si estoy conectado al ws
        'Me.PanelControles.Enabled = _conectado
        blnModifica = True
        'If _conectado Then
        Me.CtlCbteDetalle.VerCuentaCta = False
        Me.CtlCbteDetalle.TipoDeCbte = CtlDetalleCbte.TipoCbte.CBTECPRA
        Me.CtlCbteDetalle.TipoCargaCbte = Me.TipoCbte
        Me.CtlCbteDetalle.MaximoItems = My.Settings.MaximoItemsCompra
        Me.CtlCbteDetalle.Inicializar()
        InicializarComboPuntosDeVenta()
        InicializarComboTiposDeCbte()
        InicializarComboProveedores()
        InicializarComboDocumentos()
        InicializarComboResponsabilidades()
        InicializarComboFormasDePago()
        InicializarComboConceptos()
        InicializarComboGastoVariable()

        'End If

        LimpiarFormulario()

    End Sub

    Private Sub LimpiarFormulario()
        For Each c As Control In Me.PanelControles.Controls
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

        blnModifica = True
        'limpio grilla articulos
        Me.CtlCbteDetalle.Limpiar()

        Me.ComboBoxProveedor.SelectedIndex = -1

        'valores predeterminados
        Me.DateTimePickerPeriodoDesde.Value = CDate("01/" & Date.Today.Month & "/" & Date.Today.Year)
        Me.DateTimePickerPeriodoHasta.Value = CDate(Date.DaysInMonth(Date.Today.Year, Date.Today.Month) & "/" & Date.Today.Month & "/" & Date.Today.Year)

        'If ComboBoxFormaPago.Items.Count > 0 Then
        '    Me.ComboBoxFormaPago.SelectedIndex = 0
        '    'Sólo Cta.Cte. porque si es de contado no está programado que genere la OP
        '    Me.ComboBoxFormaPago.Enabled = False
        'End If

        If ComboBoxConceptos.Items.Count > 0 Then
            ComboBoxConceptos.SelectedIndex = 0
        End If

        If ComboBoxPtoVta.Items.Count > 0 Then
            ComboBoxPtoVta.SelectedIndex = 0
        End If

        If ComboBoxTipoCbte.Items.Count > 0 Then
            ComboBoxTipoCbte.SelectedIndex = 0
        End If

        Me.ToolStripLabelStatus.Text = ""

        InicializarValoresPredeterminados()

        Me.ComboBoxProveedor.Select()

        Application.DoEvents()

    End Sub

    'Private Sub FormCbteVenta_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    '    If Me.TipoCbte = TipoEmisionCbte.FISCAL Then
    '        Me.CtlCbteDetalle.FocoArticulo()
    '    Else
    '        Me.ComboBoxProveedor.Focus()
    '    End If
    'End Sub


    Private Sub FormCbteElectronico_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If Not ConexionConAFIP() Then
        '    CrearConexionAFIP()
        'End If

        InicializarFormulario()
    End Sub

    Private Sub InicializarComboTiposDeCbte()
        Dim repositorio As New CapaLogica.TipocomprobanteCLog

        With Me.ComboBoxTipoCbte
            .ValueMember = "Codigo"
            .DisplayMember = "Descripcion"

            If Me.TipoCbte = TipoEmisionCbte.COMPRA Then
                .DataSource = repositorio.GetCbtesOficiales
            ElseIf Me.TipoCbte = TipoEmisionCbte.PRESUPUESTO Then
                .DataSource = repositorio.GetCbtesPresupuestos
            End If

            If .Items.Count > 0 Then
                .SelectedIndex = 0
            End If

        End With

    End Sub

    Private Sub InicializarComboPuntosDeVenta()
        Me.ComboBoxPtoVta.Items.Clear()
        Me.ComboBoxPtoVta.Text = ""
    End Sub

    Private Sub InicializarComboConceptos()

        Dim conceptos As New List(Of Entidades.Tipoconcepto)
        Dim c As Entidades.Tipoconcepto

        Try

            c = New Entidades.Tipoconcepto
            c.Codigo = 1
            c.Descripcion = "Productos"
            conceptos.Add(c)

            c = New Entidades.Tipoconcepto
            c.Codigo = 2
            c.Descripcion = "Servicios"
            conceptos.Add(c)

            c = New Entidades.Tipoconcepto
            c.Codigo = 3
            c.Descripcion = "Productos y Servicios"
            conceptos.Add(c)

            ComboBoxConceptos.DisplayMember = "Descripcion"
            ComboBoxConceptos.ValueMember = "Codigo"
            ComboBoxConceptos.DropDownStyle = ComboBoxStyle.DropDownList
            ComboBoxConceptos.DataSource = conceptos

            If ComboBoxConceptos.Items.Count > 0 Then
                ComboBoxConceptos.SelectedIndex = 0
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub InicializarComboDocumentos()
        Dim repositorio As New CapaLogica.TipodocumentoCLog

        With Me.ComboBoxDocumento
            .ValueMember = "Codigo"
            .DisplayMember = "Descripcion"
            .DataSource = repositorio.GetAll
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub InicializarComboGastoVariable()
        'Dim repositorio As New CapaLogica.GastosvCLog
        'With Me.ctlGastoVariable
        '    .ValueMember = "Codigo"
        '    .DisplayMember = "NombreyCodigo"
        '    .DataSource = repositorio.GetAll()
        '    .AutoCompleteMode = AutoCompleteMode.Suggest
        '    .AutoCompleteSource = AutoCompleteSource.ListItems
        '    .Inicializar()
        '    .SelectedIndex = -1
        'End With
    End Sub

    Private Sub InicializarComboFormasDePago2()
        Dim repositorio As New CapaLogica.FormadepagoCLog

        With Me.ComboBoxFormaPago
            .ValueMember = "Id"
            .DisplayMember = "Nombre"
            .DataSource = repositorio.GetAll

            If .Items.Count > 0 Then
                .SelectedIndex = 0 'contado predeterminado
            End If

        End With
    End Sub

    Private Sub InicializarComboFormasDePago()

        Dim fp As New List(Of Entidades.Formadepago)
        Dim c As Entidades.Formadepago

        Try

            c = New Entidades.Formadepago
            c.Id = 1
            c.Nombre = "CONTADO"
            fp.Add(c)

            c = New Entidades.Formadepago
            c.Id = 2
            c.Nombre = "CUENTA CORRIENTE"
            fp.Add(c)

            ComboBoxFormaPago.DisplayMember = "Nombre"
            ComboBoxFormaPago.ValueMember = "Id"
            ComboBoxFormaPago.DropDownStyle = ComboBoxStyle.DropDownList
            ComboBoxFormaPago.DataSource = fp

            If ComboBoxFormaPago.Items.Count > 0 Then
                ComboBoxFormaPago.SelectedIndex = 0
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub InicializarComboResponsabilidades()
        Dim repositorio As New CapaLogica.TiporesponsableCLog

        With Me.ComboBoxResponsabilidadIVA
            .ValueMember = "Codigo"
            .DisplayMember = "Descripcion"
            .DataSource = repositorio.GetAll
            .SelectedIndex = -1
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .DropDownStyle = ComboBoxStyle.DropDownList
        End With
    End Sub

    Private Sub InicializarComboProveedores()
        Dim repositorio As New CapaLogica.ProveedorCLog
        Dim c As BrightIdeasSoftware.OLVColumn = Nothing
        Dim cols As New List(Of BrightIdeasSoftware.OLVColumn)

        c = New BrightIdeasSoftware.OLVColumn
        c.Text = "Teléfono"
        c.AspectName = "Telefono"
        c.MinimumWidth = 150
        c.TextAlign = HorizontalAlignment.Center
        c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        cols.Add(c)

        c = New BrightIdeasSoftware.OLVColumn
        c.Text = "Domicilio"
        c.AspectName = "Domicilio"
        c.MinimumWidth = 250
        c.TextAlign = HorizontalAlignment.Left
        c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        cols.Add(c)

        With Me.ComboBoxProveedor
            .ValueMember = "Id"
            .DisplayMember = "NombreyCodigo"
            .ColumnasExtras = cols
            .DataSource = repositorio.GetAllOrderByNombre(soloActivos:=True)
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            '.DropDownStyle = ComboBoxStyle.DropDownList
            .Inicializar()
            .SelectedIndex = -1
        End With

    End Sub



    Private Function UltimoCbteAutorizado() As Int32

        Dim ret As Int32 = 0
        Dim reponumeracion As New CapaLogica.CbtenumeracionCLog
        Dim ptovta As UInt32
        Dim cbtetipo As UInt32
        Dim numeracion As Entidades.Cbtenumeracion

        Try

            ptovta = Convert.ToUInt32(Me.ComboBoxPtoVta.SelectedValue)
            cbtetipo = Convert.ToUInt32(Me.ComboBoxTipoCbte.SelectedValue)

            numeracion = reponumeracion.GetByUltimoNroCbte(ptovta, cbtetipo)

            If numeracion IsNot Nothing Then
                Return numeracion.Numero
            Else
                Throw New Exception("No existe númeracion creada para el tipo de comprobante y punto de venta seleccionado")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        Finally
            reponumeracion = Nothing
        End Try
    End Function

    Private Sub CargaDatosProveedor()
        Dim e As New Entidades.Proveedor
        Dim cbtetipo As UInt32 = 0

        e = DirectCast(Me.ComboBoxProveedor.SelectedItem, Entidades.Proveedor)

        If e IsNot Nothing Then
            Me.TextBoxNombre.Text = e.Nombre
            Me.TextBoxDocumento.Text = e.Documento
            Me.ComboBoxDocumento.SelectedValue = e.Tipodocumento
            Me.ComboBoxResponsabilidadIVA.SelectedValue = e.Tiporesponsable
            Me.TextBoxDomicilio.Text = e.Domicilio

            If e.Tiporesponsable = RESPONSABLE_INSCRIPTO Then 'seteo comprobante A
                Select Case Me.TipoCbte
                    Case TipoEmisionCbte.ELECTRONICO, TipoEmisionCbte.PREIMPRESO : cbtetipo = FACTURA_A
                    Case TipoEmisionCbte.FISCAL : cbtetipo = TIQUE_FACTURA_A
                    Case TipoEmisionCbte.PRESUPUESTO : cbtetipo = PRESUPUESTO
                    Case TipoEmisionCbte.COMPRA : cbtetipo = FACTURA_A
                End Select
            Else 'seteo comprobante B
                Select Case Me.TipoCbte
                    Case TipoEmisionCbte.ELECTRONICO, TipoEmisionCbte.PREIMPRESO : cbtetipo = FACTURA_C
                    Case TipoEmisionCbte.FISCAL : cbtetipo = TIQUE_FACTURA_B
                    Case TipoEmisionCbte.PRESUPUESTO : cbtetipo = PRESUPUESTO
                    Case TipoEmisionCbte.COMPRA : cbtetipo = FACTURA_C
                End Select
            End If

            Me.DateTimePickerVto.Value.AddDays(e.Diasctacte)
            Me.ComboBoxTipoCbte.SelectedValue = cbtetipo
            Me.CtlCbteDetalle.ListaDePrecio = CtlDetalleCbte.ListaPrecios.COSTO
            Me.CtlCbteDetalle.CbtesDelProveedor(e)

            blnModifica = False
            'Me.ComboBoxPtoVta.Select()
        Else
            Me.TextBoxNombre.Text = ""
            Me.TextBoxDocumento.Text = ""
            Me.ComboBoxDocumento.SelectedIndex = -1
            Me.ComboBoxResponsabilidadIVA.SelectedIndex = -1
            Me.TextBoxDomicilio.Text = ""

        End If

    End Sub

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        For Each c As Control In Me.PanelControles.Controls
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

        _decimalSeparator = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator

        AddHandler Me.KeyDown, AddressOf FormularioKeyDown


        AddHandler Me.ComboBoxDocumento.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.ComboBoxTipoCbte.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.ComboBoxPtoVta.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.TextBoxNumero.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.DateTimePickerFecha.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.DateTimePickerIngreso.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.DateTimePickerPeriodoDesde.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.DateTimePickerPeriodoHasta.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.DateTimePickerVto.KeyDown, AddressOf CustomKeyDown


    End Sub

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F5 : If Not _autorizandoCbte Then DescomponerCB()
            Case Keys.F12 : If Not _autorizandoCbte Then AutorizandoCbte()
            Case Keys.Escape : If Not _autorizandoCbte Then Cancelar()
            Case Keys.Enter
                '    e.Handled = True
                If Me.ActiveControl.Name = "ComboBoxProveedor" Then
                    SendKeys.Send(vbTab)
                End If

        End Select
    End Sub

    Private Sub DescomponerCB()
        Try

            Dim codigo As String = FormInputDialog.ShowInput("Ingrese el código de barras del comprobante electrónico")

            If codigo.Trim.Length = 0 Then Exit Sub

            Dim c As wscdc.CmpDatos = DescomponerCodigoBarra(codigo)

            'cargo los datos
            If c IsNot Nothing Then

                Me.TextBoxCAE.Text = c.CodAutorizacion
                Me.ComboBoxTipoCbte.SelectedValue = Convert.ToUInt32(c.CbteTipo)
                Me.ComboBoxPtoVta.Text = c.PtoVta
                Me.TextBoxCAEVto.Text = c.CbteFch

                Dim r As New CapaLogica.ProveedorCLog
                Dim p As Entidades.Proveedor = r.GetByDocumento(DOCUMENTO_CUIT, c.CuitEmisor)

                If p IsNot Nothing Then
                    Me.ComboBoxProveedor.SelectedValue = p.Id
                End If

                r = Nothing
                p = Nothing

                TextBoxNumero.Focus()

            End If

        Catch ex As Exception
            MessageBox.Show("Se produjo el sig. error: " & ex.Message, "Descomponer Cód. de Barras", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Cancelar()
        If blnModifica = True Then
            If MessageBox.Show("Desea Salir?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Me.Close()
            End If
        Else
            If MessageBox.Show("Cancelar comprobante?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                LimpiarFormulario()
            End If
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

    Private Sub ComboBoxTipoCbte_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxTipoCbte.SelectedIndexChanged

        'recupero el tipo de comprobante
        If Me.ComboBoxTipoCbte.SelectedItem IsNot Nothing Then
            Select Case DirectCast(Me.ComboBoxTipoCbte.SelectedItem, Entidades.Tipocomprobante).Letra
                Case "B", "C"
                    Me.CtlCbteDetalle.CompraANoInscripto = True
                Case Else
                    Me.CtlCbteDetalle.CompraANoInscripto = False
            End Select

            'Pagor Imputación de Gasto Variable
            'Select Case DirectCast(Me.ComboBoxTipoCbte.SelectedItem, Entidades.Tipocomprobante).Codigo
            '    Case DEVOLUCION_PRESUPUESTO, NOTA_CREDITO_A, NOTA_CREDITO_B, NOTA_CREDITO_C
            '        Me.ctlGastoVariable.Enabled = False
            '        Me.ctlGastoVariable.SelectedIndex = -1
            '    Case Else
            '        Me.ctlGastoVariable.Enabled = True
            'End Select
        End If

    End Sub

    Private Function CrearComprobante() As Entidades.CpraCabecera
        Dim cbte As New Entidades.CpraCabecera
        Dim financiero As Entidades.Financiero
        Dim tipoCbte As Entidades.Tipocomprobante

        Try
            tipoCbte = DirectCast(Me.ComboBoxTipoCbte.SelectedItem, Entidades.Tipocomprobante)

            With cbte

                .Usuario = gUsuario.Id
                .Sucursal = My.Settings.CodigoSucursal
                .ProveedorId = Convert.ToUInt32(Me.ComboBoxProveedor.SelectedValue)
                .Vendedor = 0
                .Razonsocial = Me.TextBoxNombre.Text
                .Domicilio = Me.TextBoxDomicilio.Text

                If tipoCbte.Codigo = REMITO Then
                    .Nroremito = Me.TextBoxNumero.Text
                Else
                    .Nroremito = ""
                End If

                .Cbtefecha = Me.DateTimePickerFecha.Value.ToString("yyyyMMdd")
                .Cbtefechaingreso = Me.DateTimePickerIngreso.Value.ToString("yyyyMMdd")
                .Cbtenumero = Convert.ToUInt32(Me.TextBoxNumero.Text)
                .Cbteptovta = Convert.ToUInt32(Me.ComboBoxPtoVta.Text)
                .Cbtetipo = tipoCbte.Codigo
                .Letra = tipoCbte.Letra
                .Denominacion = tipoCbte.Denominacion
                .Tipo = tipoCbte.Tipo
                .Concepto = Convert.ToUInt32(Me.ComboBoxConceptos.SelectedValue)
                .Documentonro = Convert.ToUInt64(Me.TextBoxDocumento.Text)
                .Documentotipo = Convert.ToUInt32(Me.ComboBoxDocumento.SelectedValue)
                .Tiporesponsable = Convert.ToUInt32(Me.ComboBoxResponsabilidadIVA.SelectedValue)
                .Fechaserviciodesde = Me.DateTimePickerPeriodoDesde.Value.ToString("yyyyMMdd")
                .Fechaserviciohasta = Me.DateTimePickerPeriodoHasta.Value.ToString("yyyyMMdd")
                .Fechavtopago = Me.DateTimePickerVto.Value.ToString("yyyyMMdd")
                .Formadepago = Convert.ToUInt32(Me.ComboBoxFormaPago.SelectedValue)
                .Importeiva = _iva
                .Importeneto = _subtotal
                .Importetributos = _otrostributos
                .Importeopexentas = _exento
                .Importetotalconceptos = _nogravado
                .Importenoinscripto = _noinscripto
                .Importetotal = _total
                .Monedactz = 1
                .Monedaid = "PES"
                .Descuento = 0
                .Cae = Me.TextBoxCAE.Text
                .ObservacionesExtra = Me.CtlCbteDetalle.Observaciones
                .CodGastoV = "" 'Convert.ToString(Me.ctlGastoVariable.SelectedValue)

                'agrego todas las alicuotas del comprobante
                For Each o As Entidades.CbteAlicuota In Me.CtlCbteDetalle.Alicuotas
                    If o.BaseImponible > 0 Then
                        .CbteAlicuotas.Add(o)
                    End If
                Next

                'agrego todos los tributos del comprobante
                For Each o As Entidades.CbteTributo In Me.CtlCbteDetalle.Tributos
                    If o.Importe > 0 Then
                        .CbteTributos.Add(o)
                    End If
                Next

                'agrego todos los cbtes. asociados del comprobante
                For Each o As Entidades.CbteAsociado In Me.CtlCbteDetalle.CbtesAsociados
                    If o.Importe > 0 Then
                        .CbteAsociados.Add(o)
                    End If
                Next

                'agrego todos los articulos del comprobante
                For Each o As Entidades.CbteArticulo In Me.CtlCbteDetalle.Articulos
                    .CbteArticulos.Add(o)
                Next

                'If .Formadepago = FP_CONTADO And .Cbtetipo <> REMITO Then

                '    financiero = New Entidades.Financiero

                '    financiero.Origen = ORIGEN_FINANCIERO_COMPRA
                '    financiero.Cuenta = _ctabcopredeterminada.Codigo

                '    Select Case .Tipo
                '        Case CONCEPTO_ACREEDOR
                '            financiero.Concepto = _cptobcoingpredetermiando.Codigo
                '            financiero.Tipo = _cptobcoingpredetermiando.Tipo
                '        Case Else '3,8,992 notas de credito
                '            financiero.Concepto = _cptobcoegrpredetermiando.Codigo
                '            financiero.Tipo = _cptobcoegrpredetermiando.Tipo
                '    End Select

                '    financiero.Fecharegistracion = Me.DateTimePickerFecha.Value
                '    financiero.Efectivizacion = Me.DateTimePickerFecha.Value
                '    financiero.Emision = Me.DateTimePickerFecha.Value
                '    financiero.Importe = .Importetotal

                '    .CbteDetalleFinanciero.Add(financiero)

                'End If

            End With

            Return cbte

        Catch ex As Exception

            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return Nothing

        End Try
    End Function

    Private Function CrearComprobantePago(cbteTipo As UInt32, cbteAntRef As UInt32, cbteAntNro As UInt32, cbteAntPtoVta As UInt32, cbteAntTipo As UInt32) As Entidades.CpraCabecera
        Dim cbte As New Entidades.CpraCabecera
        Dim tipoCbte As Entidades.Tipocomprobante
        Dim reponumeracion As New CapaLogica.CbtenumeracionCLog
        Dim repocbtepuntoventa As New CapaLogica.CbtepuntoventaCLog
        Dim cbteNro As UInt32
        Dim ptovta As UInt32

        Try

            'ActualizaNumeracion()
            If Me.TipoCbte = TipoEmisionCbte.COMPRA Then
                ptovta = repocbtepuntoventa.GetByTipo("M").Ptovta
            Else 'If Me.TipoCbte = TipoEmisionCbte.PRESUPUESTO Then
                ptovta = repocbtepuntoventa.GetByTipo("X").Ptovta
            End If

            cbteNro = reponumeracion.GetByUltimoNroCbte(ptovta, cbteTipo).Numero + 1
            tipoCbte = _repositorioTipocomprobante.GetByCodigo(cbteTipo) 'DirectCast(Me.ComboBoxTipoCbte.SelectedItem, Entidades.Tipocomprobante)

            With cbte

                .Usuario = gUsuario.Id
                .Sucursal = My.Settings.CodigoSucursal
                .ProveedorId = Convert.ToUInt32(Me.ComboBoxProveedor.SelectedValue)
                .Razonsocial = Me.TextBoxNombre.Text
                .Domicilio = Me.TextBoxDomicilio.Text
                .Nroremito = ""
                .Cbtefecha = Me.DateTimePickerFecha.Value.ToString("yyyyMMdd")
                .Cbtenumero = cbteNro 'Convert.ToUInt32(Me.TextBoxNumero.Text)
                .Cbteptovta = ptovta 'Convert.ToUInt32(Me.ComboBoxPtoVta.SelectedValue)
                .Cbtetipo = tipoCbte.Codigo
                .Letra = tipoCbte.Letra
                .Denominacion = tipoCbte.Denominacion
                .Tipo = tipoCbte.Tipo
                .Concepto = PRODUCTOS
                .Documentonro = Convert.ToUInt64(Me.TextBoxDocumento.Text)
                .Documentotipo = Convert.ToUInt32(Me.ComboBoxDocumento.SelectedValue)
                .Tiporesponsable = Convert.ToUInt32(Me.ComboBoxResponsabilidadIVA.SelectedValue)
                .Fechaserviciodesde = .Cbtefecha
                .Fechaserviciohasta = .Cbtefecha
                .Fechavtopago = .Cbtefecha
                .Formadepago = FP_CONTADO
                .Importeiva = _iva
                .Importeneto = _subtotal
                .Importetributos = _otrostributos
                .Importeopexentas = _exento
                .Importetotalconceptos = _nogravado
                .Importetotal = _total
                .Importecartera = 0 '_cartera
                .Importectaspropias = 0 '_cuentaspropias
                .Monedactz = 1
                .Monedaid = "PES"
                .Descuento = 0
                .ObservacionesExtra = Me.CtlCbteDetalle.Observaciones
                .CodImp = "" 'Convert.ToString(Me.ctlImputacion.SelectedValue)

                'agrego todas las alicuotas del comprobante
                For Each o As Entidades.CbteAlicuota In Me.CtlCbteDetalle.Alicuotas
                    If o.BaseImponible > 0 Then
                        .CbteAlicuotas.Add(o)
                    End If
                Next

                'agrego todos los tributos del comprobante
                For Each o As Entidades.CbteTributo In Me.CtlCbteDetalle.Tributos
                    If o.Importe > 0 Then
                        .CbteTributos.Add(o)
                    End If
                Next

                Dim cbteAs As New Entidades.CbteAsociado
                cbteAs.CbteReferencia = cbteAntRef
                cbteAs.Numero = cbteAntNro
                cbteAs.PtoVta = cbteAntPtoVta
                cbteAs.Tipo = cbteAntTipo
                cbteAs.Importe = _total

                .CbteAsociados.Add(cbteAs)
                'agrego todos los cbtes. asociados del comprobante
                'For Each o As Entidades.CbteAsociado In Me.CtlCbteDetalle.CbtesAsociados
                '    If o.Importe > 0 Then
                '        .CbteAsociados.Add(o)
                '    End If
                'Next

                'agrego todos los articulos del comprobante
                'For Each o As Entidades.CbteArticulo In Me.CtlCbteDetalle.Articulos
                '    .CbteArticulos.Add(o)
                'Next


                Dim fin As New Entidades.Financiero
                Dim concepto As Entidades.Conceptobancario
                Dim cuenta As Entidades.Cuentabancaria

                concepto = _repositorioConcepto.GetByCodigo("002") 'DirectCast(Me.ComboBoxConceptoBancario.SelectedItem, Entidades.Conceptobancario)
                cuenta = _repositorioCuenta.GetByCodigo("CAJA") 'DirectCast(Me.ComboBoxCtaBancaria.SelectedItem, Entidades.Cuentabancaria)

                fin.Emision = Me.DateTimePickerFecha.Value
                fin.Tipo = concepto.Tipo
                fin.Concepto = concepto.Codigo
                fin.DetalleConcepto = concepto.Nombre
                fin.Cuenta = cuenta.Codigo
                fin.DetalleCuenta = cuenta.Nombre
                fin.Referencia = "" 'Me.TextBoxReferencia.Text.Trim
                fin.Efectivizacion = Me.DateTimePickerFecha.Value.Date
                fin.Importe = _total
                fin.Sucursal = My.Settings.CodigoConsFinal
                fin.Usuario = gUsuario.Id
                fin.Origen = ORIGEN_FINANCIERO_PAGO

                .CbteDetalleFinanciero.Add(fin)
                ''agrego todos los movimientos por ctas. propias
                'For Each financiero As Entidades.Financiero In Me.CtlCbteDetalle.Cuentaspropias

                '    financiero.Emision = Me.DateTimePickerFecha.Value

                '    .CbteDetalleFinanciero.Add(financiero)

                'Next

                'agrego todos los cheques recibidos en el comprobante
                For Each cheque As Entidades.Financiero In Me.CtlCbteDetalle.Cartera

                    If cheque.Checked Then

                        cheque.Emision = Me.DateTimePickerFecha.Value
                        cheque.Concepto = CONCEPTO_CHEQUE_PASADO
                        cheque.Tipo = CONCEPTO_ACREEDOR
                        cheque.Beneficiario = .Razonsocial

                        .CbteDetalleFinanciero.Add(cheque)

                    End If

                Next

            End With

            Return cbte

        Catch ex As Exception

            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return Nothing

        End Try
    End Function

    Private Sub AutorizarCbte(ByVal cbte As Entidades.CpraCabecera)
        Dim mensajes As New StringBuilder
        Dim tipoPtoVta As String = ""

        Try

            'envio los nuevos datos al repositor para actualizar
            _repositorio.Save(cbte)

            If _repositorio.HasError Then

                MessageBox.Show(_repositorio.mensajes.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                If ComboBoxFormaPago.SelectedValue = FP_CONTADO And ((Me.TipoCbte = TipoEmisionCbte.COMPRA) Or Me.TipoCbte = (TipoEmisionCbte.PRESUPUESTO)) Then
                    Dim cbte2 As Entidades.CpraCabecera

                    Select Case Me.TipoCbte
                        Case TipoEmisionCbte.COMPRA
                            cbte2 = CrearComprobantePago(ORDEN_PAGO, cbte.Id, cbte.Cbtenumero, cbte.Cbteptovta, cbte.Cbtetipo)
                        Case TipoEmisionCbte.PRESUPUESTO
                            cbte2 = CrearComprobantePago(PAGO_PRESUPUESTO, cbte.Id, cbte.Cbtenumero, cbte.Cbteptovta, cbte.Cbtetipo)
                    End Select


                    If cbte2 IsNot Nothing Then
                        AutorizarCbtePago(cbte2)
                    End If
                End If

                MessageBox.Show("La operación ha finalizado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)


                LimpiarFormulario()



            End If



            Me.ToolStripLabelStatus.Text = ""

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub AutorizarCbtePago(ByVal cbte As Entidades.CpraCabecera)
        Dim mensajes As New StringBuilder
        Dim tipoPtoVta As String = ""
        Dim mlngCopias As Integer

        Try

            'If _subtotal > 0 Then
            '    If Not Me.ToolStripButtonGastos.Checked Then
            '        MessageBox.Show("Se creará un anticipo por " & _subtotal.ToString("$ #,##0.00"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    End If
            'End If

            'If MessageBox.Show("Confirma la carga del comprobante?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
            '    Throw New Exception("La operación ha sido cancelada por el usuario")
            'End If            

            'mlngCopias = -1
            'frmImpresion.mstrConcepto = "ORDEN DE PAGO"
            'frmImpresion.mlngNumero = Convert.ToInt32(Me.TextBoxNumero.Text)
            'If frmImpresion.ShowDialog(Me) = Windows.Forms.DialogResult.Cancel Then
            '    Exit Sub
            'End If

            'mlngCopias = frmImpresion.mlngCopias

            'chequeo el numero del comprobante antes de guardarlo, si existe arrojo un error de validación
            If _repositorio.GetByNumero(cbte.Cbtetipo, cbte.Cbteptovta, cbte.Cbtenumero) IsNot Nothing Then
                Throw New Exception("El comprobante que intenta registrar ya existe. Chequeo de numeración")
            End If

            'envio los nuevos datos al repositor para actualizar
            _repositorio.Save(cbte)

            If _repositorio.HasError Then

                MessageBox.Show(_repositorio.mensajes.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                'emision del comprobante
                'If MessageBox.Show("Emitir comprobante de pago?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                '    EmisionCompra(cbte.Id)
                'End If

                'If mlngCopias > 0 Then
                '    EmisionCompra(cbte.Id, False, mlngCopias)
                '    'Call EmisionCbteOrdenCompra(Entidad.Id, False, mlngCopias)
                'End If

                'MessageBox.Show("La operación ha finalizado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                'LimpiarFormulario()

            End If

            'Me.ToolStripLabelStatus.Text = ""

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub ToolStripButtonAutorizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripButtonAutorizar.Click
        AutorizandoCbte()
    End Sub

    Private Sub AutorizandoCbte()

        _autorizandoCbte = True

        LockScreen(_autorizandoCbte)

        If ValidarCbte() Then

            Dim cbte As Entidades.CpraCabecera = CrearComprobante()

            If cbte IsNot Nothing Then
                AutorizarCbte(cbte)
            End If

        End If

        _autorizandoCbte = False

        LockScreen(_autorizandoCbte)

    End Sub

    Private Sub ToolStripButtonCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonCancelar.Click
        Cancelar()
    End Sub


    Private Sub ComboBoxProveedor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxProveedor.SelectedIndexChanged
        CargaDatosProveedor()
    End Sub

    Private Sub InicializarValoresPredeterminados()
        Dim repoctasbco As New CapaLogica.CuentabancariaCLog
        Dim repocptobco As New CapaLogica.ConceptobancarioCLog
        Dim repoProveedor As New CapaLogica.ProveedorCLog
        Dim repoparametro As New CapaLogica.ParametroCLog

        '_cptobcoingpredetermiando = repocptobco.GetByCodigo(My.Settings.CptoBancarioIngresoPredeterminado)
        '_cptobcoegrpredetermiando = repocptobco.GetByCodigo(My.Settings.CptoBancarioEgresoPredeterminado)
        '_ctabcopredeterminada = repoctasbco.GetByCodigo(My.Settings.CtaBancariaPredeterminada)

        If gUsuario.Perfil = PERFIL_MOSTRADOR Then
            _cptobcoingpredetermiando = repocptobco.GetByCodigo(repoparametro.GetByNombre("ConceptoIngresoPorVentaMostrador").Valorpredeterminado)
            _cptobcoegrpredetermiando = repocptobco.GetByCodigo(repoparametro.GetByNombre("ConceptoEgresoMostrador").Valorpredeterminado)
            _ctabcopredeterminada = repoctasbco.GetByCodigo(repoparametro.GetByNombre("CuentaBancariaMostrador").Valorpredeterminado)
        Else
            _cptobcoingpredetermiando = repocptobco.GetByCodigo(repoparametro.GetByNombre("ConceptoIngreso").Valorpredeterminado)
            _cptobcoegrpredetermiando = repocptobco.GetByCodigo(repoparametro.GetByNombre("ConceptoEgreso").Valorpredeterminado)
            _ctabcopredeterminada = repoctasbco.GetByCodigo(repoparametro.GetByNombre("CuentaBancariaCaja").Valorpredeterminado)
        End If


        'If Me.TipoCbte = TipoEmisionCbte.FISCAL Then
        'seteo codigo de Proveedor predeterminado
        'Me.ComboBoxProveedor.SelectedValue = Convert.ToUInt32(My.Settings.CodigoConsFinal)
        Me.ComboBoxFormaPago.SelectedValue = FP_CONTADO
        'Else
        'Me.ComboBoxFormaPago.SelectedValue = FP_CTACTE
        'End If

        Me.DateTimePickerFecha.Enabled = Not (Me.TipoCbte = TipoEmisionCbte.FISCAL)
        Me.DateTimePickerPeriodoDesde.Enabled = Not (Me.TipoCbte = TipoEmisionCbte.FISCAL)
        Me.DateTimePickerPeriodoHasta.Enabled = Not (Me.TipoCbte = TipoEmisionCbte.FISCAL)
        Me.DateTimePickerVto.Enabled = Not (Me.TipoCbte = TipoEmisionCbte.FISCAL)

        Me.ComboBoxPtoVta.Text = ""
        Me.TextBoxNumero.Text = ""

        'Me.ctlGastoVariable.SelectedIndex = -1


    End Sub

    Private Function ValidarCbte() As Boolean

        Dim ret As New StringBuilder

        If Me.CtlCbteDetalle.FOLVCompAsoc.IsCellEditing Then
            ret.AppendLine("Debe finalizar la edición en la grilla de comprobantes asociados")
        End If

        If Me.CtlCbteDetalle.FOLVAlicuotas.IsCellEditing Then
            ret.AppendLine("Debe finalizar la edición en la grilla de alicuotas")
        End If

        If Me.CtlCbteDetalle.FOLVArticulos.IsCellEditing Then
            ret.AppendLine("Debe finalizar la edición en la grilla de artículos")
        End If

        'validar datos del receptor
        If Me.ComboBoxProveedor.SelectedItem Is Nothing Then
            ret.AppendLine("El Proveedor seleccionado no es válido")
        End If

        If Me.ComboBoxDocumento.SelectedItem Is Nothing Then
            ret.AppendLine("El tipo de documento seleccionado no es válido")
        Else
            'validar el cuit cuando no es una nota de pedido
            If Me.TipoCbte <> TipoEmisionCbte.PRESUPUESTO Then
                Select Case DirectCast(Me.ComboBoxDocumento.SelectedItem, Entidades.Tipodocumento).Codigo
                    Case DOCUMENTO_CUIT
                        If Me.TextBoxDocumento.Text.Length <> 11 Then
                            ret.AppendLine("El nro. de CUIT ingresado no es correcto")
                        ElseIf IsNumeric(Me.TextBoxDocumento.Text) = False Then
                            ret.AppendLine("El nro. de CUIT ingresado no es correcto")
                        Else
                            If Not General.VerificaCuit(Me.TextBoxDocumento.Text) Then
                                ret.AppendLine("El nro. de CUIT ingresado no es válido")
                            End If
                        End If
                    Case DOCUMENTO_DNI
                        If Me.TextBoxDocumento.Text.Length = 0 Then
                            ret.AppendLine("El nro. de documento ingresado no es correcto")
                        End If
                End Select
            End If
        End If

        If Me.ComboBoxResponsabilidadIVA.SelectedItem Is Nothing Then
            ret.AppendLine("El tipo de responsabilidad de IVA del receptor no es válido")
        End If

        If Me.TextBoxNombre.Text.Length = 0 Then
            ret.AppendLine("El nombre o razón social del receptor no es correcto")
        End If

        'validar cbte. tipo, numeracion, concepto, fechas
        If Me.ComboBoxTipoCbte.SelectedItem Is Nothing Then
            ret.AppendLine("El tipo de comprobante seleccionado no es válido")
        End If

        If Not IsNumeric(Me.ComboBoxPtoVta.Text) Then
            ret.AppendLine("El punto de venta del comprobante seleccionado no es válido")
        End If

        If Not IsNumeric(Me.TextBoxNumero.Text) Then
            ret.AppendLine("El número del comprobante no es válido")
        Else
            If Convert.ToUInt32(Me.TextBoxNumero.Text) <= 0 Then
                ret.AppendLine("El número del comprobante no es válido")
            End If
        End If

        If Me.ComboBoxConceptos.SelectedItem Is Nothing Then
            ret.AppendLine("El concepto del comprobante seleccionado no es válido")
        Else
            'Select Case DirectCast(Me.ComboBoxConceptos.SelectedItem, Entidades.Tipoconcepto).Codigo
            '    Case PRODUCTOS
            '        If Math.Abs((DateTimePickerFecha.Value - Date.Today).TotalDays) > 5 Then
            '            ret.AppendLine("La fecha del comprobante seleccionado no es válida. Para el tipo de concepto PRODUCTOS, la fecha no puede diferir en más de 5 días con la fecha actual.")
            '        End If
            '    Case SERVICIOS, PRODUCTOS_Y_SERVICIOS
            '        If Math.Abs((DateTimePickerFecha.Value - Date.Today).TotalDays) > 10 Then
            '            ret.AppendLine("La fecha del comprobante seleccionado no es válida. Para el tipo de concepto SERVICIOS, la fecha no puede diferir en más de 10 días con la fecha actual.")
            '        End If
            'End Select
        End If

        If Math.Abs(DateDiff(DateInterval.Month, Me.DateTimePickerFecha.Value, Date.Today, FirstDayOfWeek.Monday)) > 1 Or Format(Me.DateTimePickerFecha.Value, "yyyy/MM/dd") > Format(Date.Today, "yyyy/MM/dd") Then
            If MessageBox.Show("La fecha ingresada del comprobante es correcta?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                ret.AppendLine("La fecha del comprobante seleccionado no es válida")
            End If
        End If

        If Me.TipoCbte = TipoEmisionCbte.FISCAL Then
            If Format(Me.DateTimePickerFecha.Value, "yyyy/MM/dd") <> Format(Date.Today, "yyyy/MM/dd") Then
                ret.AppendLine("La fecha del comprobante seleccionado no es válida")
            End If
        End If

        If Format(Me.DateTimePickerVto.Value, "yyyy/MM/dd") < Format(Me.DateTimePickerFecha.Value, "yyyy/MM/dd") Then
            ret.AppendLine("La fecha de vto. para el Pago del comprobante no puede ser inferior a la fecha del comprobante")
        End If

        'validar articulos, alicuotas, otros tributos, cbte. asoc.
        If Me.ComboBoxTipoCbte.SelectedValue = REMITO Then
            If Me.CtlCbteDetalle.Articulos.Count = 0 Then
                ret.AppendLine("Debe ingresar un artículo al comprobante")
            End If
        End If

        If Me.CtlCbteDetalle.CbtesAsociados.Count <> 0 And _totalaplicado <> 0 Then
            'De enviarse el tag <CbtesAsoc>, entonces el campo "código de tipo de comprobante" <CbteTipo> a autorizar tiene que ser 02, 03, 07, 08, 12 o 13.
            'Para 02 y 03 pueden asociarse los tipos de comprobante 01, 02, 03, 04, 05, 34, 39, 60, 63.
            'Para 07 y 08 pueden asociarse 06, 07, 08, 09, 10, 35, 40, 61 y 64.
            'Para 12 o 13 pueden asociarse 11, 12, 13 y 15.
            Select Case DirectCast(Me.ComboBoxTipoCbte.SelectedItem, Entidades.Tipocomprobante).Codigo
                Case NOTA_CREDITO_A, NOTA_DEBITO_A
                    For Each obj As Entidades.CbteAsociado In Me.CtlCbteDetalle.CbtesAsociados
                        Select Case obj.Tipo
                            Case FACTURA_B, TIQUE_FACTURA_B, NOTA_CREDITO_B, NOTA_DEBITO_B, PRESUPUESTO
                                ret.AppendLine("Para el tipo de comprobante seleccionado solo se admiten comprobantes tipo A. " & obj.Denominacion & " no es un cbte. válido.")
                        End Select
                    Next
                Case NOTA_CREDITO_B, NOTA_DEBITO_B
                    For Each obj As Entidades.CbteAsociado In Me.CtlCbteDetalle.CbtesAsociados
                        Select Case obj.Tipo
                            Case FACTURA_A, TIQUE_FACTURA_A, NOTA_CREDITO_A, NOTA_DEBITO_A, PRESUPUESTO
                                ret.AppendLine("Para el tipo de comprobante seleccionado solo se admiten comprobantes tipo B. " & obj.Denominacion & " no es un cbte. válido.")
                        End Select
                    Next
                Case DEVOLUCION_PRESUPUESTO
                    For Each obj As Entidades.CbteAsociado In Me.CtlCbteDetalle.CbtesAsociados
                        Select Case obj.Tipo
                            Case Is <> PRESUPUESTO
                                ret.AppendLine("Para el tipo de comprobante seleccionado solo se admiten comprobantes tipo PRESUPUESTO. " & obj.Denominacion & " no es un cbte. válido.")
                        End Select
                    Next
                Case Else
                    ret.AppendLine("Para el tipo de comprobante seleccionado no se admiten comprobantes asociados")
            End Select

            'validar totales
            If _total <> _totalaplicado Then
                ret.AppendLine("El total del comprobante no coincide con el total aplicado a los comprobantes asociados")
            End If

        End If

        Select Case DirectCast(Me.ComboBoxTipoCbte.SelectedItem, Entidades.Tipocomprobante).Codigo
            Case DEVOLUCION_PRESUPUESTO, NOTA_CREDITO_A, NOTA_CREDITO_B, NOTA_CREDITO_C, NOTA_DEBITO_A, NOTA_DEBITO_B, NOTA_DEBITO_C
                If Math.abs(_total - _totalaplicado) >= 0.01 Then 'And Me.ComboBoxFormaPago.SelectedValue <> FP_CONTADO Then
                    'If MessageBox.Show("No se imputo ningún comprobante a la NOTA DE COMPRA. Desea continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = vbNo Then
                    ret.AppendLine("Debe imputar el importe del cbte. a algún cbte. pendiente")
                    'End If
                End If
        End Select


        'Select Case DirectCast(Me.ComboBoxTipoCbte.SelectedItem, Entidades.Tipocomprobante).Codigo
        '    Case DEVOLUCION_PRESUPUESTO, NOTA_CREDITO_A, NOTA_CREDITO_B, NOTA_CREDITO_C, NOTA_DEBITO_A, NOTA_DEBITO_B, NOTA_DEBITO_C
        '        If _totalaplicado = 0 Then
        '            ret.AppendLine("Debe imputar el importe del cbte. a algún cbte. pendiente")
        '        End If
        'End Select

        ValidarAlicuotasIVA(ret)

        'validar totales
        If _total <= 0 Then
            ret.AppendLine("El total del comprobante no puede ser cero")
        End If

        'validar Imputación de Gasto Variable
        Select Case DirectCast(Me.ComboBoxTipoCbte.SelectedItem, Entidades.Tipocomprobante).Codigo
            Case DEVOLUCION_PRESUPUESTO, NOTA_CREDITO_A, NOTA_CREDITO_B, NOTA_CREDITO_C
                'No pido Gasto Variable
            Case Else
                'If Me.ctlGastoVariable.SelectedItem Is Nothing Then
                '    ret.AppendLine("El Gasto Variable seleccionado no es válido")
                'End If
        End Select

        If Not (ret.Length = 0) Then
            MessageBox.Show("Validación del comprobante" & vbNewLine & ret.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else

            'validacion de comprobante preexistente una vez que haya superado la valiación de tipos
            Dim c As Entidades.CpraCabecera = _repositorio.GetByNumero(Convert.ToUInt32(Me.ComboBoxProveedor.SelectedValue), Me.ComboBoxTipoCbte.SelectedValue, _
                                                                      Convert.ToUInt32(Me.ComboBoxPtoVta.Text), Convert.ToUInt32(Me.TextBoxNumero.Text))

            If c IsNot Nothing Then
                If MessageBox.Show("El comprobante que intenta cargar ya existe" & vbNewLine & _
                                   "Comprobante: " & c.CbteDenominacion & vbNewLine & _
                                   "Fecha del cbte.: " & ParseStringToDate(c.Cbtefecha) & vbNewLine & _
                                   "Importe total: " & c.Importetotal.ToString("$ #,##0.00#") & vbNewLine & _
                                   "Desea continuar?" _
                                   , Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                    Return False
                End If
            Else

                If MessageBox.Show("¿Confirma la carga del comprobante?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                    Return False
                End If

            End If

        End If

        Return (ret.Length = 0)

    End Function

    Private Sub ValidarAlicuotasIVA(ByRef ret As StringBuilder)

        Dim baseImponible As Double = 0.0

        For Each a As Entidades.CbteAlicuota In Me.CtlCbteDetalle.Alicuotas
            If a.Alicuota <> 0 Then
                baseImponible += Math.Round(a.Importe / (a.Alicuota / 100), 2)
            Else
                baseImponible += a.BaseImponible
            End If
        Next

        'If Math.Abs(baseImponible - _subtotal) > 0.1 Then
        '    ret.AppendLine("El importe neto gravado no coincide con las alicuotas aplicadas. Importe esperado: " & baseImponible.ToString("$ #,##0.00"))
        'End If

    End Sub


    Private Sub DateTimePickerFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePickerFecha.ValueChanged
        Me.DateTimePickerIngreso.Value = DateTimePickerFecha.Value
    End Sub

    Private Sub CustomKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Return
                If sender Is Me.ComboBoxDocumento Then
                    Me.ComboBoxTipoCbte.Focus()
                ElseIf sender Is Me.ComboBoxTipoCbte Then
                    Me.ComboBoxPtoVta.Focus()
                ElseIf sender Is Me.ComboBoxPtoVta Then
                    Me.TextBoxNumero.Focus()
                ElseIf sender Is Me.TextBoxNumero Then
                    Me.DateTimePickerFecha.Focus()
                ElseIf sender Is Me.DateTimePickerFecha Then
                    Me.DateTimePickerPeriodoDesde.Focus()
                ElseIf sender Is Me.DateTimePickerPeriodoDesde Then
                    Me.DateTimePickerPeriodoHasta.Focus()
                ElseIf sender Is Me.DateTimePickerPeriodoHasta Then
                    Me.DateTimePickerIngreso.Focus()
                ElseIf sender Is Me.DateTimePickerIngreso Then
                    Me.DateTimePickerVto.Focus()
                ElseIf sender Is Me.DateTimePickerVto Then
                    Me.CtlCbteDetalle.FocoArticulo()
                End If
        End Select
    End Sub

    Private Sub ToolStripButtonBarCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonBarCode.Click
        DescomponerCB()
    End Sub

    Private Sub ComboBoxPtoVta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxPtoVta.LostFocus
        TextBoxNumero.Focus()
        TextBoxNumero.Select()
    End Sub

    Private Sub FormCbteCompra_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = _autorizandoCbte
    End Sub

    Private Sub CtlCbteDetalle_Totalizado() Handles CtlCbteDetalle.Totalizado
        With CtlCbteDetalle
            _subtotal = .Subtotal
            _iva = .Iva
            _otrostributos = .OtrosTributos
            _exento = .Exento
            _nogravado = .NoGravado
            _noinscripto = .Noinscripto
            _total = .Total
            _totalaplicado = .TotalAplicado
            Call LockDatosProveedor(Not .Articulos.Count = 0)
        End With

        Me.TextBoxSubtotal.Text = _subtotal.ToString("$ #,##0.00")
        Me.TextBoxIVAFacturado.Text = _iva.ToString("$ #,##0.00")
        Me.TextBoxOtrosTributos.Text = _otrostributos.ToString("$ #,##0.00")
        Me.TextBoxExento.Text = _exento.ToString("$ #,##0.00")
        Me.TextBoxNogravado.Text = _nogravado.ToString("$ #,##0.00")
        Me.TextBoxTotal.Text = _total.ToString("$ #,##0.00")
        Me.LabelTotal.Text = "Items ingresados " & CtlCbteDetalle.Articulos.Count & ", por cargar " & CtlCbteDetalle.MaximoItems - CtlCbteDetalle.Articulos.Count & ". Esta Compra >> " & _total.ToString("$ #,##0.00") & " <<"
    End Sub
End Class