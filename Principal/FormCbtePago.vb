Imports Microsoft.VisualBasic.FileIO.FileSystem
Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO
Imports System.Text
Imports System.Security

Public Class FormCbtePago

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
    Private _cuentaspropias As Double = 0.0
    Private _cartera As Double = 0.0
    Private _totalrecibido As Double = 0.0

    Private _repositorio As New CapaLogica.CpracabeceraCLog
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

    Private Const DOCUMENTO_CUIT As UInt32 = 80
    Private Const DOCUMENTO_DNI As UInt32 = 96
    Private Const DOCUMENTO_SIN As UInt32 = 99

    Private _autorizandoCbte As Boolean
    Private _ctabcopredeterminada As Entidades.Cuentabancaria
    Private _cptobcoingpredetermiando As Entidades.Conceptobancario
    Private _cptobcoegrpredetermiando As Entidades.Conceptobancario
    Private _proveedorGastos As Entidades.Proveedor

    Private Sub LockScreen(ByVal lock As Boolean)
        Me.ToolStripButtonAutorizar.Enabled = Not lock
        Me.ToolStripButtonCancelar.Enabled = Not lock
        Me.ToolStripButtonGastos.Enabled = Not lock
        Me.PanelControles.Enabled = Not lock
        Me.ComboBoxProveedor.FocoDetalle()
        Application.DoEvents()
    End Sub

    Private Sub LockDatosCliente(ByVal lock As Boolean)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        For Each c As Control In Me.GroupBoxDatosCliente.Controls
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
            Case TipoEmisionCbte.ELECTRONICO : Me.Text = "Emisión de Cbte. Electrónico por Web Service"
            Case TipoEmisionCbte.FISCAL : Me.Text = "Emisión de Cbte. por Controlador Fiscal"
            Case TipoEmisionCbte.PREIMPRESO : Me.Text = "Emisión de Cbte. Preimpreso"
            Case TipoEmisionCbte.PRESUPUESTO : Me.Text = "Emisión de Cbte. Presupuesto"
            Case TipoEmisionCbte.RECIBO : Me.Text = "Emisión de Recibo de Cobranza"
            Case TipoEmisionCbte.RECIBO_PRESUPUESTO : Me.Text = "Emisión de Recibo - Nota de Pedido"
            Case TipoEmisionCbte.ORDEN_DE_PAGO : Me.Text = "Emisión de Orden de Pago"
            Case TipoEmisionCbte.PAGO_PRESUPUESTO : Me.Text = "Emisión de Pago - Nota de Pedido"
            Case TipoEmisionCbte.AJUSTE_ACREEDOR : Me.Text = "Ajuste de Saldo ACREEDOR"
            Case TipoEmisionCbte.AJUSTE_DEUDOR : Me.Text = "Ajuste de Saldo DEUDOR"
            Case Else : Me.Text = "Operación no definida"
        End Select

        blnModifica = True
        Me.CtlCbteDetalle.VerCuentaCta = True
        Me.CtlCbteDetalle.TipoDeCbte = CtlDetalleCbte.TipoCbte.CBTECPRA
        Me.CtlCbteDetalle.TipoCargaCbte = Me.TipoCbte
        Me.CtlCbteDetalle.Inicializar()

        InicializarCombos()

        'If Me.TipoCbte = TipoEmisionCbte.ORDEN_DE_PAGO Then
        '    Me.ctlImputacion.Enabled = True
        'Else
        '    Me.ctlImputacion.Enabled = False
        '    Me.ctlImputacion.SelectedIndex = -1
        'End If

        LimpiarFormulario()

        If Me.TipoCbte = TipoEmisionCbte.AJUSTE_DEUDOR Or Me.TipoCbte = TipoEmisionCbte.AJUSTE_ACREEDOR Then
            ToolStripButtonGastos.Visible = False
        Else
            ToolStripButtonGastos.Visible = True
        End If

        Me.GroupBoxImporte.Visible = False

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
        Me.LabelAnticipo.Visible = False

        Me.TextBoxImporteRecibido.Text = 0.0

        Me.ComboBoxProveedor.SelectedIndex = -1

        If ComboBoxPtoVta.Items.Count > 0 Then
            ComboBoxPtoVta.SelectedIndex = 0
        End If

        If ComboBoxTipoCbte.Items.Count > 0 Then
            ComboBoxTipoCbte.SelectedIndex = 0
        End If

        Me.ToolStripLabelStatus.Text = ""

        InicializarValoresPredeterminados()

        'limpio grilla detalle
        Me.CtlCbteDetalle.Limpiar()

        Me.ToolStripButtonGastos.Checked = False

        Me.ComboBoxProveedor.FocoDetalle()

        'Me.ctlImputacion.SelectedIndex = -1

        Application.DoEvents()

    End Sub

    Private Sub FormCbtePago_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = _autorizandoCbte
    End Sub

    Private Sub FormCbtePago_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If Not ConexionConAFIP() Then
        '    CrearConexionAFIP()
        'End If

        InicializarFormulario()
    End Sub

    Private Sub InicializarComboTiposDeCbte()
        Dim repositorio As New CapaLogica.TipocomprobanteCLog
        Dim tipos As New List(Of Entidades.Tipocomprobante)

        With Me.ComboBoxTipoCbte
            .ValueMember = "Codigo"
            .DisplayMember = "Descripcion"

            Select Case Me.TipoCbte
                Case TipoEmisionCbte.ELECTRONICO
                    tipos = repositorio.GetCbtesElectronicos
                Case TipoEmisionCbte.FISCAL
                    tipos = repositorio.GetCbtesFiscales
                Case TipoEmisionCbte.PRESUPUESTO
                    tipos = repositorio.GetCbtesPresupuestos
                Case TipoEmisionCbte.RECIBO
                    tipos.Add(repositorio.GetByCodigo(RECIBO_COBRANZA))
                Case TipoEmisionCbte.RECIBO_PRESUPUESTO
                    tipos.Add(repositorio.GetByCodigo(RECIBO_PRESUPUESTO))
                Case TipoEmisionCbte.ORDEN_DE_PAGO
                    tipos.Add(repositorio.GetByCodigo(ORDEN_PAGO))
                Case TipoEmisionCbte.PAGO_PRESUPUESTO
                    tipos.Add(repositorio.GetByCodigo(PAGO_PRESUPUESTO))
                Case TipoEmisionCbte.AJUSTE_ACREEDOR, TipoEmisionCbte.AJUSTE_DEUDOR
                    Dim c As Entidades.Tipocomprobante = repositorio.GetByCodigo(ORDEN_PAGO)
                    c.Descripcion = "AJUSTE DE SALDO"

                    If TipoCbte = TipoEmisionCbte.AJUSTE_ACREEDOR Then
                        c.Denominacion = "AJUSTE A."
                        c.Tipo = CONCEPTO_ACREEDOR
                    Else
                        c.Denominacion = "AJUSTE D."
                        c.Tipo = CONCEPTO_DEUDOR
                    End If

                    tipos.Add(c)
            End Select

            .DataSource = tipos


            If .Items.Count > 0 Then
                .SelectedIndex = 0
            End If

        End With

    End Sub

    Private Sub InicializarComboPuntosDeVenta()
        Dim repositorio As New CapaLogica.CbtepuntoventaCLog
        Dim list As New List(Of Entidades.Cbtepuntoventa)

        With Me.ComboBoxPtoVta
            .ValueMember = "Ptovta"
            .DisplayMember = "Ptovta"

            Select Case Me.TipoCbte
                Case TipoEmisionCbte.ELECTRONICO
                    list = repositorio.GetPtosElectronicos
                Case TipoEmisionCbte.FISCAL
                    list = repositorio.GetPtosFiscales
                Case TipoEmisionCbte.PRESUPUESTO
                    list = repositorio.GetPtosPresupuestos
                Case TipoEmisionCbte.RECIBO, TipoEmisionCbte.ORDEN_DE_PAGO
                    list.Add(repositorio.GetByPtoVta(My.Settings.PuntoVtaManual))
                Case TipoEmisionCbte.RECIBO_PRESUPUESTO, TipoEmisionCbte.PAGO_PRESUPUESTO
                    list = repositorio.GetPtosPresupuestos
                Case TipoEmisionCbte.AJUSTE_ACREEDOR, TipoEmisionCbte.AJUSTE_DEUDOR
                    list.Add(repositorio.GetByPtoVta(My.Settings.PuntoVtaAjustesProv))
            End Select

            .DataSource = list

            If .Items.Count > 0 Then
                .SelectedIndex = 0
            End If

        End With

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
            .DataSource = repositorio.GetAllOrderByNombre
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            '.DropDownStyle = ComboBoxStyle.DropDownList
            .SelectedIndex = -1
            .Inicializar()
        End With

    End Sub

    'Private Sub InicializarComboGastoVariable()
    '    Dim repositorio As New CapaLogica.ImputacionCLog
    '    With Me.ctlImputacion
    '        .ValueMember = "Codigo"
    '        .DisplayMember = "NombreyCodigo"
    '        .DataSource = repositorio.GetAll()
    '        .AutoCompleteMode = AutoCompleteMode.Suggest
    '        .AutoCompleteSource = AutoCompleteSource.ListItems
    '        .Inicializar()
    '        .SelectedIndex = -1
    '    End With
    'End Sub

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
            Me.CtlCbteDetalle.CbtesDelProveedor(e)

            If Not Me.ToolStripButtonGastos.Checked Then
                PoseeAnticipos(e.Id)
            Else
                Me.LabelAnticipo.Visible = False
            End If
            blnModifica = False
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
        AddHandler Me.TextBoxImporteRecibido.KeyPress, AddressOf CustomKeyPressOnlyNumbers

        AddHandler Me.ComboBoxDocumento.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.ComboBoxTipoCbte.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.ComboBoxPtoVta.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.TextBoxNumero.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.DateTimePickerFecha.KeyDown, AddressOf CustomKeyDown

    End Sub

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F12 : If Not _autorizandoCbte Then AutorizandoCbte()
            Case Keys.Escape : If Not _autorizandoCbte Then Cancelar()
            Case Keys.F5
                If ToolStripButtonGastos.Visible = True Then If Not _autorizandoCbte Then GastosVarios()
            Case Keys.Enter
                '    e.Handled = True
                If Me.ActiveControl.Name <> "CtlCbteDetalle" Then
                    SendKeys.Send(vbTab)
                End If
        End Select
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

        ActualizaNumeracion()

    End Sub

    Private Sub ActualizaNumeracion()

        If ComboBoxTipoCbte.SelectedIndex = -1 Then
            Exit Sub
        End If

        Dim cbte As Int32

        cbte = UltimoCbteAutorizado()

        If cbte >= 0 Then
            Me.TextBoxNumero.Text = cbte + 1
        End If

    End Sub

    Private Function CrearComprobante() As Entidades.CpraCabecera
        Dim cbte As New Entidades.CpraCabecera
        Dim tipoCbte As Entidades.Tipocomprobante

        Try

            ActualizaNumeracion()

            tipoCbte = DirectCast(Me.ComboBoxTipoCbte.SelectedItem, Entidades.Tipocomprobante)

            With cbte

                .Usuario = gUsuario.Id
                .Sucursal = My.Settings.CodigoSucursal
                .ProveedorId = Convert.ToUInt32(Me.ComboBoxProveedor.SelectedValue)
                .Razonsocial = Me.TextBoxNombre.Text
                .Domicilio = Me.TextBoxDomicilio.Text
                .Nroremito = ""
                .Cbtefecha = Me.DateTimePickerFecha.Value.ToString("yyyyMMdd")
                .Cbtenumero = Convert.ToUInt32(Me.TextBoxNumero.Text)
                .Cbteptovta = Convert.ToUInt32(Me.ComboBoxPtoVta.SelectedValue)
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
                .Importecartera = _cartera
                .Importectaspropias = _cuentaspropias
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

                'agrego todos los movimientos por ctas. propias
                For Each financiero As Entidades.Financiero In Me.CtlCbteDetalle.Cuentaspropias

                    financiero.Emision = Me.DateTimePickerFecha.Value

                    .CbteDetalleFinanciero.Add(financiero)

                Next

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
        Dim mlngCopias As Integer

        Try

            If _subtotal > 0 Then
                If Not Me.ToolStripButtonGastos.Checked Then
                    MessageBox.Show("Se creará un anticipo por " & _subtotal.ToString("$ #,##0.00"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

            'If MessageBox.Show("Confirma la carga del comprobante?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
            '    Throw New Exception("La operación ha sido cancelada por el usuario")
            'End If            

            mlngCopias = -1
            frmImpresion.mstrConcepto = "ORDEN DE PAGO"
            frmImpresion.mlngNumero = Convert.ToInt32(Me.TextBoxNumero.Text)
            If frmImpresion.ShowDialog(Me) = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            mlngCopias = frmImpresion.mlngCopias

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

                If mlngCopias > 0 Then
                    EmisionCompra(cbte.Id, False, mlngCopias)
                    'Call EmisionCbteOrdenCompra(Entidad.Id, False, mlngCopias)
                End If

                MessageBox.Show("La operación ha finalizado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                LimpiarFormulario()

            End If

            Me.ToolStripLabelStatus.Text = ""

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

    Private Sub CtlCbteDetalle_Totalizado() Handles CtlCbteDetalle.Totalizado

        Totalizador()

    End Sub

    Private Sub Totalizador()
        Try

            _totalrecibido = Val(Me.TextBoxImporteRecibido.Text)

            With CtlCbteDetalle
                _subtotal = .Subtotal
                _iva = .Iva
                _otrostributos = .OtrosTributos
                _exento = .Exento
                _nogravado = .NoGravado
                _totalaplicado = .TotalAplicado
                _cuentaspropias = .TotalCtasPropias
                _cartera = .TotalCartera
                '_total = _totalrecibido
                _total = Math.Round(_otrostributos + _cuentaspropias + _cartera, 2)

                'Call LockDatosCliente(_totalrecibido > 0)
                Call LockDatosCliente(_total > 0)
            End With

            '_subtotal = Math.Round(_total - _otrostributos - _cuentaspropias - _cartera, 2)
            _subtotal = Math.Round(_total - _totalaplicado, 2)

            Me.TextBoxSinAplicar.Text = _subtotal.ToString("$ #,##0.00")
            Me.TextBoxAplicado.Text = _totalaplicado.ToString("$ #,##0.00")
            Me.TextBoxOtrosTributos.Text = _otrostributos.ToString("$ #,##0.00")
            Me.TextBoxCtasPropias.Text = _cuentaspropias.ToString("$ #,##0.00")
            Me.TextBoxCartera.Text = _cartera.ToString("$ #,##0.00")
            Me.TextBoxTotal.Text = _total.ToString("$ #,##0.00")
            Me.LabelTotal.Text = "Importe total del comprobante >> " & _total.ToString("$ #,##0.00") & " <<"

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ComboBoxProveedor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxProveedor.SelectedIndexChanged
        CargaDatosProveedor()
    End Sub


    Private Sub InicializarValoresPredeterminados()

        Dim repoctasbco As New CapaLogica.CuentabancariaCLog
        Dim repocptobco As New CapaLogica.ConceptobancarioCLog
        Dim repocliente As New CapaLogica.ClienteCLog
        Dim repoparametro As New CapaLogica.ParametroCLog
        Dim repoproveedor As New CapaLogica.ProveedorCLog

        Try

            If Me.TipoCbte = TipoEmisionCbte.AJUSTE_ACREEDOR Or Me.TipoCbte = TipoEmisionCbte.AJUSTE_DEUDOR Then
                _cptobcoingpredetermiando = repocptobco.GetByCodigo(repoparametro.GetByNombre("ConceptoAjusteIngreso").Valorpredeterminado)
                _cptobcoegrpredetermiando = repocptobco.GetByCodigo(repoparametro.GetByNombre("ConceptoAjusteEgreso").Valorpredeterminado)
                _ctabcopredeterminada = repoctasbco.GetByCodigo(repoparametro.GetByNombre("CuentaBancariaAjuste").Valorpredeterminado)
            Else
                _cptobcoingpredetermiando = repocptobco.GetByCodigo(repoparametro.GetByNombre("ConceptoIngreso").Valorpredeterminado)
                _cptobcoegrpredetermiando = repocptobco.GetByCodigo(repoparametro.GetByNombre("ConceptoEgreso").Valorpredeterminado)
                _ctabcopredeterminada = repoctasbco.GetByCodigo(repoparametro.GetByNombre("CuentaBancariaCaja").Valorpredeterminado)
            End If

            _proveedorGastos = repoproveedor.GetById(Convert.ToUInt32(repoparametro.GetByNombre("ProveedorGastos").Valorpredeterminado))

            If Me.TipoCbte = TipoEmisionCbte.FISCAL Then
                'seteo codigo de cliente predeterminado
                Me.ComboBoxProveedor.SelectedValue = Convert.ToUInt32(My.Settings.CodigoConsFinal)
            Else

            End If

            Me.CtlCbteDetalle.CptoBcoIngPredetermiando = _cptobcoingpredetermiando
            Me.CtlCbteDetalle.CptoBcoEgrPredetermiando = _cptobcoegrpredetermiando
            Me.CtlCbteDetalle.CtaBcoPredeterminada = _ctabcopredeterminada

            Me.DateTimePickerFecha.Enabled = Not (Me.TipoCbte = TipoEmisionCbte.FISCAL)

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            repoctasbco = Nothing
            repocptobco = Nothing
            repocliente = Nothing
            repoparametro = Nothing
            repoproveedor = Nothing
        End Try

    End Sub



    Private Function ValidarCbte() As Boolean

        Dim ret As New StringBuilder

        Totalizador()

        If Me.CtlCbteDetalle.FOLVCompAsoc.IsCellEditing Then
            ret.AppendLine("Debe finalizar la edición en la grilla de comprobantes asociados")
        End If

        'validar datos del receptor
        If Me.ComboBoxProveedor.SelectedItem Is Nothing Then
            ret.AppendLine("El cliente seleccionado no es válido")
        End If

        If Me.ComboBoxDocumento.SelectedItem Is Nothing Then
            ret.AppendLine("El tipo de documento seleccionado no es válido")
        Else
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

        If Me.ComboBoxPtoVta.SelectedItem Is Nothing Then
            ret.AppendLine("El punto de venta del comprobante seleccionado no es válido")
        End If

        If Not IsNumeric(Me.TextBoxNumero.Text) Then
            ret.AppendLine("El número del comprobante no es válido")
        Else
            If Convert.ToUInt32(Me.TextBoxNumero.Text) <= 0 Then
                ret.AppendLine("El número del comprobante no es válido")
            End If
        End If

        'recupero el ultimo numero de comprobante
        ActualizaNumeracion()

        If Me.TipoCbte = TipoEmisionCbte.FISCAL Then
            If Me.DateTimePickerFecha.Value <> Date.Today Then
                ret.AppendLine("La fecha del comprobante seleccionado no es válida")
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
                Case RECIBO_COBRANZA, ORDEN_PAGO
                    For Each obj As Entidades.CbteAsociado In Me.CtlCbteDetalle.CbtesAsociados
                        Select Case obj.Tipo
                            Case PRESUPUESTO
                                ret.AppendLine("Para el tipo de comprobante seleccionado solo se admiten comprobantes tipo A y B. " & obj.Denominacion & " no es un cbte. válido.")
                        End Select
                    Next
                Case RECIBO_PRESUPUESTO, PAGO_PRESUPUESTO
                    For Each obj As Entidades.CbteAsociado In Me.CtlCbteDetalle.CbtesAsociados
                        Select Case obj.Tipo
                            Case Is <> PRESUPUESTO
                                ret.AppendLine("Para el tipo de comprobante seleccionado solo se admiten comprobantes tipo PRESUPUESTO. " & obj.Denominacion & " no es un cbte. válido.")
                        End Select
                    Next
                Case Else
                    ret.AppendLine("Para el tipo de comprobante seleccionado no se admiten comprobantes asociados")
            End Select



        End If

        'validar totales
        'If _subtotal = _total Then
        '    ret.AppendLine("No se detallo ningun valor para el importe recibido. Ingrese importes por cuentas propias, cartera u otros tributos.")
        'End If

        'validar totales
        If _subtotal < 0 Then
            ret.AppendLine("El total aplicado no puede superar al importe total recibido")
        End If

        If Me.TipoCbte = TipoEmisionCbte.AJUSTE_ACREEDOR Or Me.TipoCbte = TipoEmisionCbte.AJUSTE_DEUDOR Then
            If _subtotal > 0 Then
                ret.AppendLine("Debe aplicar la totalidad del ajuste")
            End If
        End If

        'validar totales
        'If _subtotal > 0 Then
        '    ret.AppendLine("El total aplicado no puede ser inferior al importe total recibido")
        'End If

        'validar totales
        If _totalaplicado > _total Then
            ret.AppendLine("El total aplicado a comprobantes no puede superar el importe total recibido")
        End If

        'validar totales
        If _total <= 0 Then
            ret.AppendLine("El total del comprobante no puede ser cero")
        End If

        'If MessageBox.Show("Confirma el comprobante?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
        'ret.AppendLine("Comprobante cancelado por el usuario: " & gUsuario.Nombre)
        'End If

        'validar Imputación de Gasto Variable
        'If Me.TipoCbte = TipoEmisionCbte.ORDEN_DE_PAGO Then
        '    If Me.ctlImputacion.SelectedItem Is Nothing Then
        '        ret.AppendLine("El Código de Imputación seleccionado no es válido")
        '    End If
        'End If

        If Not (ret.Length = 0) Then
            MessageBox.Show("Validación del comprobante" & vbNewLine & ret.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return (ret.Length = 0)

    End Function

    Private Sub InicializarCombos()
        InicializarComboPuntosDeVenta()
        InicializarComboTiposDeCbte()
        InicializarComboProveedores()
        InicializarComboDocumentos()
        InicializarComboResponsabilidades()
        'InicializarComboGastoVariable()
    End Sub

    'Private Sub TextBoxImporteRecibido_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxImporteRecibido.TextChanged
    '    Totalizador()
    'End Sub

    Private Sub CustomKeyPressOnlyNumbers(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(_decimalSeparator) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
    End Sub

    Private Sub GastosVarios()
        If Not Me.ToolStripButtonGastos.Checked Then

            Me.TextBoxNombre.Select()

            Application.DoEvents()

            Me.ToolStripButtonGastos.Checked = True

            If _proveedorGastos IsNot Nothing Then
                Me.ComboBoxProveedor.SelectedValue = _proveedorGastos.Id
            Else
                MessageBox.Show("Falta definir el proveedor de gastos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            Me.TextBoxNombre.Text = ""

        Else

            Cancelar()

        End If
    End Sub

    Private Sub ToolStripButtonGastos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripButtonGastos.Click
        If ToolStripButtonGastos.Visible = True Then
            GastosVarios()
        End If
    End Sub

    Private Sub PoseeAnticipos(ByVal id As UInt32)
        Dim totalAnticipo As Double = 0.0

        For Each c As Entidades.CpraCabecera In _repositorio.GetAnticiposProveedor(id, gUsuario.GodMode, False)
            totalAnticipo += c.SaldoAsociado
        Next

        Me.LabelAnticipo.Text = "El proveedor posee anticipos por " & totalAnticipo.ToString("$ #,##0.00")
        Me.LabelAnticipo.Visible = totalAnticipo > 0


        If totalAnticipo > 0 Then
            MessageBox.Show(Me.LabelAnticipo.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

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
                    Me.CtlCbteDetalle.FocoCuentasPropias()
                End If
        End Select
    End Sub

    Private Sub DateTimePickerFecha_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePickerFecha.ValueChanged
        Me.CtlCbteDetalle.FechaComprobante = DateTimePickerFecha.Value
    End Sub
End Class