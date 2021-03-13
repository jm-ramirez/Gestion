Imports Microsoft.VisualBasic.FileIO.FileSystem
Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO
Imports System.Text
Imports System.Security
Imports System.Data

Public Class FormCbteVentaNF

    Property TipoCbte As TipoEmisionCbte

    Private WithEvents objWSFEV As New CbteElectronico
    Private _decimalSeparator As Char
    'totalizadores del comprobante
    Private _subtotal As Double = 0.0
    Private _iva As Double = 0.0
    Private _otrostributos As Double = 0.0
    Private _exento As Double = 0.0
    Private _nogravado As Double = 0.0
    Private _total As Double = 0.0
    Private _totalaplicado As Double
    Private _totalKgs As Double = 0.0

    Private _repositorio As New CapaLogica.CbtecabeceraCLog
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
    Private _cargaReparto As String
    Private _topeFacturacionSinDocumento As Double
    Private _agrupaArticulosDetalle As Boolean
    Private _formadepago As Entidades.Financiero

    Private Sub LockScreen(ByVal lock As Boolean)
        Me.ToolStripButtonAutorizar.Enabled = Not lock
        Me.ToolStripButtonCancelar.Enabled = Not lock
        Me.PanelControles.Enabled = Not lock

        If Not lock Then
            If Me.TipoCbte = TipoEmisionCbte.FISCAL Then
                Me.CtlCbteDetalle.FocoArticulo()
            Else
                Me.ComboBoxCliente.FocoDetalle()
            End If
        End If

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
            Case TipoEmisionCbte.NO_FISCAL : Me.Text = "Emisión de Cbte."
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
        Me.CtlCbteDetalle.TipoCargaCbte = Me.TipoCbte

        If Me.TipoCbte = TipoEmisionCbte.FISCAL Then
            Me.CtlCbteDetalle.MaximoItems = My.Settings.MaximoItemsFiscal
        Else
            Me.CtlCbteDetalle.MaximoItems = My.Settings.MaximoItemsMayorista
        End If

        Me.CtlCbteDetalle.Inicializar()

        InicializarComboPuntosDeVenta()
        InicializarComboTiposDeCbte()
        InicializarComboClientes()
        InicializarComboDocumentos()
        'InicializarComboResponsabilidades()
        'InicializarComboFormasDePago()
        'InicializarComboConceptos()
        InicializarComboVendedores()
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

        Application.DoEvents()

        Me.nudDolar.Value = 1

        Me.ComboBoxCliente.SelectedIndex = -1

        Me.ComboBoxRemitos.Enabled = True
        Me.BtnArtRemito.Enabled = True

        'valores predeterminados
        'Me.DateTimePickerPeriodoDesde.Value = CDate("01/" & Date.Today.Month & "/" & Date.Today.Year)
        'Me.DateTimePickerPeriodoHasta.Value = CDate(Date.DaysInMonth(Date.Today.Year, Date.Today.Month) & "/" & Date.Today.Month & "/" & Date.Today.Year)

        'If ComboBoxFormaPago.Items.Count > 0 Then
        '    Me.ComboBoxFormaPago.SelectedIndex = 0
        'End If

        'If ComboBoxConceptos.Items.Count > 0 Then
        '    ComboBoxConceptos.SelectedIndex = 0
        'End If

        If ComboBoxPtoVta.Items.Count > 0 Then
            ComboBoxPtoVta.SelectedIndex = 0
        End If

        If ComboBoxTipoCbte.Items.Count > 0 Then
            ComboBoxTipoCbte.SelectedIndex = 0
        End If

        Me.ToolStripLabelStatus.Text = ""

        InicializarValoresPredeterminados()

        Application.DoEvents()

        If Me.TipoCbte = TipoEmisionCbte.FISCAL Then

            'Me.ActiveControl = Me.CtlCbteDetalle
            'Me.CtlCbteDetalle.Select()
            'Me.CtlCbteDetalle.FocoArticulo()

            Me.ActiveControl = Me.TextBoxDocumento
            Me.TextBoxDocumento.Select()
            Me.TextBoxDocumento.Focus()

        Else
            Me.ActiveControl = Me.ComboBoxCliente
            Me.ComboBoxCliente.Select()
            Me.ComboBoxCliente.FocoDetalle()
        End If

    End Sub

    'Private Sub FormCbteVentaNF_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    '    If Me.TipoCbte = TipoEmisionCbte.FISCAL Then
    '        Me.CtlCbteDetalle.FocoArticulo()
    '    Else
    '        Me.ComboBoxCliente.Focus()
    '    End If
    'End Sub

    Private Sub FormCbteVentaNF_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = _autorizandoCbte
    End Sub

    Private Sub FormCbteElectronico_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If Not ConexionConAFIP() Then
        '    CrearConexionAFIP()
        'End If

        InicializarFormulario()


    End Sub

    Private Sub ToolStripLabelWSAAStatus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripLabelStatus.Click
        'If objWSFEV.mensajes.Length <> 0 Then
        '    MessageBox.Show(objWSFEV.mensajes.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        'End If
    End Sub

    Private Sub InicializarComboTiposDeCbte()
        Dim repositorio As New CapaLogica.TipocomprobanteCLog

        With Me.ComboBoxTipoCbte
            .ValueMember = "Codigo"
            .DisplayMember = "Descripcion"

            .DataSource = repositorio.GetCbtesNoFiscales
            'If Me.TipoCbte = TipoEmisionCbte.ELECTRONICO Then
            '    .DataSource = repositorio.GetCbtesElectronicos
            'ElseIf Me.TipoCbte = TipoEmisionCbte.FISCAL Then
            '    .DataSource = repositorio.GetCbtesFiscales
            'ElseIf Me.TipoCbte = TipoEmisionCbte.PRESUPUESTO Then
            '    .DataSource = repositorio.GetCbtesPresupuestos
            'ElseIf Me.TipoCbte = TipoEmisionCbte.PREIMPRESO Then
            '    .DataSource = repositorio.GetCbtesElectronicos
            'End If

            If .Items.Count > 0 Then
                .SelectedIndex = 0
            End If

        End With

    End Sub

    Private Sub InicializarComboPuntosDeVenta()
        Dim repositorio As New CapaLogica.CbtepuntoventaCLog
        Dim puntos As New List(Of Entidades.Cbtepuntoventa)

        With Me.ComboBoxPtoVta
            .ValueMember = "Ptovta"
            .DisplayMember = "Ptovta"

            .DataSource = repositorio.GetPtosNoFiscales

            If .Items.Count > 0 Then
                .SelectedIndex = 0
            End If

        End With

    End Sub

    'Private Sub InicializarComboConceptos()

    '    Dim conceptos As New List(Of Entidades.Tipoconcepto)
    '    Dim c As Entidades.Tipoconcepto

    '    Try

    '        c = New Entidades.Tipoconcepto
    '        c.Codigo = 1
    '        c.Descripcion = "Productos"
    '        conceptos.Add(c)

    '        c = New Entidades.Tipoconcepto
    '        c.Codigo = 2
    '        c.Descripcion = "Servicios"
    '        conceptos.Add(c)

    '        c = New Entidades.Tipoconcepto
    '        c.Codigo = 3
    '        c.Descripcion = "Productos y Servicios"
    '        conceptos.Add(c)

    '        ComboBoxConceptos.DisplayMember = "Descripcion"
    '        ComboBoxConceptos.ValueMember = "Codigo"
    '        ComboBoxConceptos.DropDownStyle = ComboBoxStyle.DropDownList
    '        ComboBoxConceptos.DataSource = conceptos

    '        If ComboBoxConceptos.Items.Count > 0 Then
    '            ComboBoxConceptos.SelectedIndex = 0
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    Private Sub InicializarComboDocumentos()
        Dim repositorio As New CapaLogica.TipodocumentoCLog

        With Me.ComboBoxDocumento
            .ValueMember = "Codigo"
            .DisplayMember = "Descripcion"
            .DataSource = repositorio.GetAll
            .SelectedIndex = -1
        End With
    End Sub

    'Private Sub InicializarComboFormasDePago()
    '    Dim repositorio As New CapaLogica.FormadepagoCLog

    '    With Me.ComboBoxFormaPago
    '        .ValueMember = "Id"
    '        .DisplayMember = "Nombre"
    '        .DataSource = repositorio.GetAll

    '        If .Items.Count > 0 Then
    '            .SelectedIndex = 0 'contado predeterminado
    '        End If

    '    End With
    'End Sub

    'Private Sub InicializarComboResponsabilidades()
    '    Dim repositorio As New CapaLogica.TiporesponsableCLog

    '    With Me.ComboBoxResponsabilidadIVA
    '        .ValueMember = "Codigo"
    '        .DisplayMember = "Descripcion"
    '        .DataSource = repositorio.GetAll
    '        .SelectedIndex = -1
    '        .AutoCompleteMode = AutoCompleteMode.Suggest
    '        .AutoCompleteSource = AutoCompleteSource.ListItems
    '        .DropDownStyle = ComboBoxStyle.DropDownList
    '    End With
    'End Sub

    Private Sub InicializarComboClientes()
        Dim repositorio As New CapaLogica.ClienteCLog
        Dim c As BrightIdeasSoftware.OLVColumn = Nothing
        Dim cols As New List(Of BrightIdeasSoftware.OLVColumn)

        c = New BrightIdeasSoftware.OLVColumn
        c.Text = "CUIT/DNI"
        c.AspectName = "Documento"
        c.MinimumWidth = 100
        c.TextAlign = HorizontalAlignment.Center
        c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        cols.Add(c)

        c = New BrightIdeasSoftware.OLVColumn
        c.Text = "Teléfono"
        c.AspectName = "Telefono"
        c.MinimumWidth = 100
        c.TextAlign = HorizontalAlignment.Center
        c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        cols.Add(c)

        c = New BrightIdeasSoftware.OLVColumn
        c.Text = "Domicilio"
        c.AspectName = "Domicilio"
        c.MinimumWidth = 150
        c.TextAlign = HorizontalAlignment.Left
        c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        cols.Add(c)

        With Me.ComboBoxCliente
            .ColumnasExtras = cols
            .ValueMember = "Id"
            .DisplayMember = "NombreyCodigo"
            .DataSource = repositorio.GetAllOrderByNombre(soloActivos:=True)
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            '.DropDownStyle = ComboBoxStyle.DropDownList
            .FormularioDeAlta = FormCliente
            .Inicializar()
            .SelectedIndex = -1
        End With

        Me.ComboBoxDomicilios.DataSource = Nothing

    End Sub

    Private Sub InicializarComboVendedores()
        Dim repositorio As New CapaLogica.VendedorCLog

        With Me.ComboBoxVendedor
            .ValueMember = "Id"
            .DisplayMember = "Nombre"
            .DataSource = repositorio.GetAll
            '.AutoCompleteMode = AutoCompleteMode.Suggest
            '.AutoCompleteSource = AutoCompleteSource.ListItems
            .DropDownStyle = ComboBoxStyle.DropDownList
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

    Private Sub CargaDatosCliente()
        Dim e As New Entidades.Cliente
        Dim cbtetipo As UInt32 = 0

        e = DirectCast(Me.ComboBoxCliente.SelectedItem, Entidades.Cliente)

        If e IsNot Nothing Then
            Me.TextBoxNombre.Text = e.Nombre
            Me.TextBoxDocumento.Text = e.Documento
            Me.ComboBoxDocumento.SelectedValue = e.Tipodocumento
            'Me.ComboBoxResponsabilidadIVA.SelectedValue = e.Tiporesponsable
            Me.ComboBoxVendedor.SelectedValue = e.Vendedor

            If e.Tiporesponsable = RESPONSABLE_INSCRIPTO Then 'seteo comprobante A
                Select Case Me.TipoCbte
                    Case TipoEmisionCbte.ELECTRONICO, TipoEmisionCbte.PREIMPRESO : cbtetipo = FACTURA_A
                    Case TipoEmisionCbte.FISCAL : cbtetipo = My.Settings.CbteDefaultA_Fiscal 'TIQUE_FACTURA_A
                    Case TipoEmisionCbte.PRESUPUESTO : cbtetipo = PRESUPUESTO
                End Select
            Else 'seteo comprobante B
                Select Case Me.TipoCbte
                    Case TipoEmisionCbte.ELECTRONICO, TipoEmisionCbte.PREIMPRESO : cbtetipo = FACTURA_B
                    Case TipoEmisionCbte.FISCAL : cbtetipo = My.Settings.CbteDefaultB_Fiscal 'TIQUE_FACTURA_B
                    Case TipoEmisionCbte.PRESUPUESTO : cbtetipo = PRESUPUESTO
                End Select
            End If

            Me.TextBoxDescuentoGral.Text = e.Descuento

            'Me.ComboBoxFormaPago.SelectedValue = e.FormadePago
            'Me.DateTimePickerVto.Value = Me.DateTimePickerVto.Value.AddDays(e.Diasctacte)
            'Me.ComboBoxTipoCbte.SelectedValue = cbtetipo
            Me.CtlCbteDetalle.ListaDePrecio = e.Listadeprecio
            Me.CtlCbteDetalle.CbtesDelCliente(e)

            Me.CtlCbteDetalle.Cliente = e
            Me.CtlCbteDetalle.InicializarComboArticulos()

            Me.ComboBoxDomicilios.DataSource = e.Domicilio.Split(New String() {Environment.NewLine},
                                       StringSplitOptions.None)
            Me.TextBoxDomicilio.Text = e.Domicilio.Split(New String() {Environment.NewLine},
                                       StringSplitOptions.None)(0)

            Me.ComboBoxRemitos.DataSource = Nothing
            Me.ComboBoxRemitos.DropDownStyle = ComboBoxStyle.DropDownList
            Me.ComboBoxRemitos.ValueMember = "id"
            Me.ComboBoxRemitos.DisplayMember = "CbteNumeroFmt"
            Me.ComboBoxRemitos.DataSource = _repositorio.GetRemitosCliente(e.Id)
            Me.ComboBoxRemitos.SelectedIndex = -1
            blnModifica = False
        Else
            Me.TextBoxNombre.Text = ""
            Me.TextBoxDocumento.Text = ""
            Me.ComboBoxDocumento.SelectedIndex = -1
            'Me.ComboBoxResponsabilidadIVA.SelectedIndex = -1
            Me.TextBoxDomicilio.Text = ""
            Me.ComboBoxVendedor.SelectedIndex = -1
            Me.ComboBoxRemitos.DataSource = Nothing
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
                    AddHandler c.KeyDown, AddressOf CustomKeyDown
                    'Case GetType(CtlDetalleCbte), GetType(CtlCustomCombo)
                    '    AddHandler c.KeyDown, AddressOf CustomKeyDown
                Case GetType(GroupBox)
                    For Each g As Control In c.Controls
                        Select Case g.GetType
                            Case GetType(TextBox), GetType(ComboBox), GetType(DateTimePicker)
                                AddHandler g.GotFocus, AddressOf CustomGotFocus
                                AddHandler g.LostFocus, AddressOf CustomLostFocus
                                AddHandler g.KeyDown, AddressOf CustomKeyDown
                                'Case GetType(CtlDetalleCbte), GetType(CtlCustomCombo)
                                '    AddHandler c.KeyDown, AddressOf CustomKeyDown
                        End Select
                    Next
            End Select
        Next

        _decimalSeparator = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator

        AddHandler Me.KeyDown, AddressOf FormularioKeyDown
        AddHandler Me.BtnArtRemito.Click, AddressOf CargarArticulosRemito
    End Sub

    Private Sub CargarArticulosRemito(ByVal sender As Object, ByVal e As EventArgs)

        If Me.ComboBoxRemitos.SelectedItem Is Nothing Then Exit Sub

        Select Case ComboBoxTipoCbte.SelectedValue
            Case NOTA_CREDITO_A, NOTA_CREDITO_B, NOTA_CREDITO_C, NOTA_DEBITO_A, NOTA_DEBITO_B, NOTA_DEBITO_C, NOTA_CREDITO_X, NOTA_DEBITO_X
                ComboBoxRemitos.SelectedIndex = -1
                Exit Sub
        End Select

        If MessageBox.Show("Los artículos del remito seleccionado serán agregados al comprobante actual. Desea continuar?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
            ComboBoxRemitos.SelectedIndex = -1
            Exit Sub
        End If

        Me.CtlCbteDetalle.CargarArticulosRemito(Me.ComboBoxRemitos.SelectedValue)
        Me.ComboBoxRemitos.Enabled = False
        Me.BtnArtRemito.Enabled = False

    End Sub

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F12 : If Not _autorizandoCbte Then AutorizandoCbte()
            Case Keys.Escape : If Not _autorizandoCbte Then Cancelar()
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

        'If Not _conectado Then
        '    Exit Sub
        'End If

        ActualizaNumeracion()

    End Sub

    Private Function CrearComprobante() As Entidades.CbteCabecera
        Dim cbte As New Entidades.CbteCabecera
        'Dim financiero As Entidades.Financiero
        Dim tipoCbte As Entidades.Tipocomprobante

        Try

            ActualizaNumeracion()

            tipoCbte = DirectCast(Me.ComboBoxTipoCbte.SelectedItem, Entidades.Tipocomprobante)

            With cbte

                .Usuario = gUsuario.Id
                .Sucursal = My.Settings.CodigoSucursal
                .Clienteid = Convert.ToUInt32(Me.ComboBoxCliente.SelectedValue)
                .Vendedor = Convert.ToUInt32(Me.ComboBoxVendedor.SelectedValue)
                .Razonsocial = Me.TextBoxNombre.Text
                .Domicilio = Me.TextBoxDomicilio.Text

                If Me.ComboBoxRemitos.SelectedItem IsNot Nothing Then
                    Select Case DirectCast(Me.ComboBoxTipoCbte.SelectedItem, Entidades.Tipocomprobante).Codigo
                        Case FACTURA_A, TIQUE_FACTURA_A, FACTURA_B, TIQUE_FACTURA_B, FACTURA_C, TIQUE_FACTURA_C, FACTURA_M, COMPROBANTE_X
                            .RemitoId = Me.ComboBoxRemitos.SelectedValue
                            .Nroremito = Me.ComboBoxRemitos.Text
                        Case Else
                            .RemitoId = 0
                            .Nroremito = ""
                    End Select
                Else
                    .RemitoId = 0
                    .Nroremito = ""
                End If

                .Cbtefecha = Me.DateTimePickerFecha.Value.ToString("yyyyMMdd")
                .Cbtenumero = Convert.ToUInt32(Me.TextBoxNumero.Text)
                .Cbteptovta = Convert.ToUInt32(Me.ComboBoxPtoVta.SelectedValue)
                .Cbtetipo = tipoCbte.Codigo
                .Letra = tipoCbte.Letra
                .Denominacion = tipoCbte.Denominacion
                .Tipo = tipoCbte.Tipo
                .Concepto = 3 ' PRODUCTOS Y SERVICIOS   Convert.ToUInt32(Me.ComboBoxConceptos.SelectedValue)
                .Documentonro = Convert.ToUInt64(Me.TextBoxDocumento.Text)
                .Documentotipo = Convert.ToUInt32(Me.ComboBoxDocumento.SelectedValue)
                .Tiporesponsable = 5 'Consumidor Final  Convert.ToUInt32(Me.ComboBoxResponsabilidadIVA.SelectedValue)
                .Fechaserviciodesde = Me.DateTimePickerFecha.Value.ToString("yyyyMMdd")
                .Fechaserviciohasta = Me.DateTimePickerFecha.Value.ToString("yyyyMMdd")
                .Fechavtopago = Me.DateTimePickerFecha.Value.ToString("yyyyMMdd")
                .Formadepago = 1 'CONTADO Convert.ToUInt32(Me.ComboBoxFormaPago.SelectedValue)
                .Importeiva = _iva
                .Importeneto = _subtotal
                .Importetributos = _otrostributos
                .Importeopexentas = _exento
                .Importetotalconceptos = _nogravado
                .Importetotal = _total
                .Monedactz = 1
                .Monedaid = "PES"
                .Descuento = Convert.ToDouble(Me.TextBoxDescuentoGral.Text)
                .ObservacionesExtra = Me.CtlCbteDetalle.Observaciones

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
                _totalKgs = 0
                For Each o As Entidades.CbteArticulo In Me.CtlCbteDetalle.Articulos
                    _totalKgs = _totalKgs + o.Kgs
                    .CbteArticulos.Add(o)
                Next
                .Kgs = _totalKgs

                'If .Formadepago = FP_CONTADO Then

                'financiero = New Entidades.Financiero

                'financiero.Origen = ORIGEN_FINANCIERO_VENTA
                'financiero.Cuenta = _ctabcopredeterminada.Codigo

                'Select Case .Tipo
                '    Case CONCEPTO_DEUDOR 'FACTURA_A, FACTURA_B, NOTA_DEBITO_A, NOTA_DEBITO_B, TIQUE_FACTURA_A, TIQUE_FACTURA_B, PRESUPUESTO 'facturas y notas de debito

                'If _formadepago IsNot Nothing Then
                ' financiero.Concepto = _formadepago.Concepto
                ' financiero.Tipo = _formadepago.Tipo
                'financiero.Referencia = _formadepago.Referencia
                'Else
                'financiero.Concepto = _cptobcoingpredetermiando.Codigo
                'financiero.Tipo = _cptobcoingpredetermiando.Tipo
                'End If


                '    Case Else '3,8,992 notas de credito
                'If _formadepago IsNot Nothing Then
                ' financiero.Concepto = _formadepago.Concepto
                ' financiero.Tipo = _formadepago.Tipo
                ' financiero.Referencia = _formadepago.Referencia
                ' Else
                ' financiero.Concepto = _cptobcoegrpredetermiando.Codigo
                ' financiero.Tipo = _cptobcoegrpredetermiando.Tipo
                ' End If
                ' End Select

                'financiero.Fecharegistracion = Me.DateTimePickerFecha.Value
                'financiero.Efectivizacion = Me.DateTimePickerFecha.Value
                'financiero.Emision = Me.DateTimePickerFecha.Value
                'financiero.Importe = .Importetotal

                '.CbteDetalleFinanciero.Add(financiero)

                'End If

            End With

            Return cbte

        Catch ex As Exception

            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return Nothing

        End Try
    End Function

    Private Sub AutorizarCbte(ByVal cbte As Entidades.CbteCabecera)
        Dim mensajes As New StringBuilder
        Dim tipoPtoVta As String = ""

        Try
            cbte.Resultado = "A"

            tipoPtoVta = DirectCast(Me.ComboBoxPtoVta.SelectedItem, Entidades.Cbtepuntoventa).Tipo


            ' TODO revisar el comportamiento al actulizar, orden de los mensajes de bloqueo
            If Not (cbte.Resultado = "A") Then

                MessageBox.Show(mensajes.ToString, "Autorizar Cbte.", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                If tipoPtoVta = PTO_VTA_ELECTRONICO Or tipoPtoVta = PTO_VTA_FISCAL Then
                    MessageBox.Show(mensajes.ToString, "Autorizar Cbte.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                Dim mlngCopias As Integer
                'strOrdenCompra = ""

                mlngCopias = -1
                frmImpresion.mstrConcepto = "CARGA DE COMPROBANTE X"
                frmImpresion.mlngNumero = Convert.ToInt32(Me.TextBoxNumero.Text)
                If frmImpresion.ShowDialog(Me) = Windows.Forms.DialogResult.Cancel Then
                    Exit Sub
                End If

                mlngCopias = frmImpresion.mlngCopias

                'envio los nuevos datos al repositor para actualizar
                _repositorio.Save(cbte)

                If _repositorio.HasError Then

                    MessageBox.Show(_repositorio.mensajes.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

                Else

                    'para ventas mayoristas y cbte. tipo factura se dispara la carga de repartos
                    Select Case Me.TipoCbte
                        Case TipoEmisionCbte.NO_FISCAL, TipoEmisionCbte.ELECTRONICO, TipoEmisionCbte.PREIMPRESO, TipoEmisionCbte.PRESUPUESTO

                            'emision del comprobante
                            EmisionCbte(cbte.Id,, mlngCopias)

                            Select Case _cargaReparto
                                Case "1"    'pregunto por la carga de reparto
                                    'If MessageBox.Show("La operación ha finalizado correctamente. Asignar comprobante a un reparto?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                    MessageBox.Show("La operación ha finalizado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    'CargaDeReparto(cbte)
                                    'End If
                                Case "2"    'ingreso a la carga de reparto directamente
                                    'CargaDeReparto(cbte)
                                Case Else   'carga de repartos deshabilitada
                                    MessageBox.Show("La operación ha finalizado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End Select


                        Case Else
                            MessageBox.Show("La operación ha finalizado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Select

                    LimpiarFormulario()

                End If

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

            Dim cbte As Entidades.CbteCabecera = CrearComprobante()

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

        With CtlCbteDetalle
            _subtotal = .Subtotal
            _iva = .Iva
            _otrostributos = .OtrosTributos
            _exento = .Exento
            _nogravado = .NoGravado
            _total = .Total
            _totalaplicado = .TotalAplicado
            Call LockDatosCliente(Not .Articulos.Count = 0)
        End With

        Me.TextBoxSubtotal.Text = _subtotal.ToString("$ #,##0.00")
        Me.TextBoxIVAFacturado.Text = _iva.ToString("$ #,##0.00")
        Me.TextBoxOtrosTributos.Text = _otrostributos.ToString("$ #,##0.00")
        Me.TextBoxExento.Text = _exento.ToString("$ #,##0.00")
        Me.TextBoxNogravado.Text = _nogravado.ToString("$ #,##0.00")
        Me.TextBoxTotal.Text = _total.ToString("$ #,##0.00")
        Me.LabelTotal.Text = "Items ingresados " & CtlCbteDetalle.Articulos.Count & ", por cargar " & CtlCbteDetalle.MaximoItems - CtlCbteDetalle.Articulos.Count & ". Esta Venta >> " & _total.ToString("$ #,##0.00") & " <<"

    End Sub

    Private Sub ComboBoxCliente_AltadeRegistroFinalizada() Handles ComboBoxCliente.AltadeRegistroFinalizada
        'InicializarComboClientes()
    End Sub

    Private Sub ComboBoxCliente_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxCliente.SelectedIndexChanged
        CargaDatosCliente()
    End Sub

    'Private Sub objWSFEV_Status(ByVal status As String) Handles objWSFEV.Status
    '    Me.ToolStripLabelStatus.Text = status
    '    Application.DoEvents()
    'End Sub

    Private Sub InicializarValoresPredeterminados()

        Try

            Dim repoctasbco As New CapaLogica.CuentabancariaCLog
            Dim repocptobco As New CapaLogica.ConceptobancarioCLog
            Dim repocliente As New CapaLogica.ClienteCLog
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


            _agrupaArticulosDetalle = Convert.ToBoolean(repoparametro.GetByNombre("AgrupaArticulosDetalle").Valorpredeterminado)

            _topeFacturacionSinDocumento = Convert.ToDouble(repoparametro.GetByNombre("TopeFacturacionSinDocumento").Valorpredeterminado)


            _cargaReparto = repoparametro.GetByNombre("CargaRepartoMayorista").Valorpredeterminado

            'If Me.TipoCbte = TipoEmisionCbte.FISCAL Or gUsuario.Perfil = PERFIL_MOSTRADOR Then
            'seteo codigo de cliente predeterminado
            'Me.ComboBoxCliente.SelectedValue = Convert.ToUInt32(My.Settings.CodigoConsFinal)
            Me.ComboBoxCliente.SelectedIndex = -1
            'Me.ComboBoxFormaPago.SelectedValue = FP_CONTADO
            'Else
            'Me.ComboBoxFormaPago.SelectedValue = FP_CTACTE
            'End If

            Me.CtlCbteDetalle.AgrupaArticulosDetalle = _agrupaArticulosDetalle

            Me.TextBoxDescuentoGral.Text = 0.0
            Me.TextBoxDescuentoGral.Enabled = gUsuario.DescuentoGral
            Me.DateTimePickerFecha.Enabled = Not (Me.TipoCbte = TipoEmisionCbte.FISCAL)
            'Me.DateTimePickerPeriodoDesde.Enabled = Not (Me.TipoCbte = TipoEmisionCbte.FISCAL)
            'Me.DateTimePickerPeriodoHasta.Enabled = Not (Me.TipoCbte = TipoEmisionCbte.FISCAL)
            'Me.DateTimePickerVto.Enabled = Not (Me.TipoCbte = TipoEmisionCbte.FISCAL)

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Function ValidarCbte() As Boolean

        Dim ret As New StringBuilder

        If Me.CtlCbteDetalle.FOLVArticulos.IsCellEditing Then
            ret.AppendLine("Debe finalizar la edición en la grilla de artículos")
        End If

        If Me.CtlCbteDetalle.FOLVCompAsoc.IsCellEditing Then
            ret.AppendLine("Debe finalizar la edición en la grilla de comprobantes asociados")
        End If

        'validar datos del receptor
        If Me.ComboBoxCliente.SelectedItem Is Nothing Then
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

                    'If Val(Me.TextBoxDocumento.Text) = 0 Then
                    '    If Me.TipoCbte <> TipoEmisionCbte.PRESUPUESTO Then
                    '        If _total >= _topeFacturacionSinDocumento Then
                    '            ret.AppendLine("El importe máximo de facturación sin documento es de " & _topeFacturacionSinDocumento.ToString("$ #,##0.00"))
                    '        End If
                    '    End If
                    'End If

                Case DOCUMENTO_SIN

                    'If Me.TipoCbte <> TipoEmisionCbte.PRESUPUESTO Then
                    '    If _total >= _topeFacturacionSinDocumento Then
                    '        ret.AppendLine("El importe máximo de facturación sin documento es de " & _topeFacturacionSinDocumento.ToString("$ #,##0.00"))
                    '    End If
                    'End If

            End Select
        End If

        'If Me.ComboBoxResponsabilidadIVA.SelectedItem Is Nothing Then
        '    ret.AppendLine("El tipo de responsabilidad de IVA del receptor no es válido")
        'End If

        If Me.ComboBoxVendedor.SelectedItem Is Nothing Then
            ret.AppendLine("El vendedor seleccionado no es válido")
        End If

        If Me.TextBoxNombre.Text.Length = 0 Then
            ret.AppendLine("El nombre o razón social del receptor no es correcto")
        End If

        If Me.TextBoxDescuentoGral.Text.Length = 0 Then
            ret.AppendLine("El descuento gral. ingresado no es válido")
        End If

        If IsNumeric(Me.TextBoxDescuentoGral.Text) Then
            If Convert.ToDouble(Me.TextBoxDescuentoGral.Text) < 0 Or Convert.ToDouble(Me.TextBoxDescuentoGral.Text) > 100 Then
                ret.AppendLine("El descuento gral. ingresado no es válido. Rango permitido de 0 a 100")
            End If
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

        'If Me.ComboBoxConceptos.SelectedItem Is Nothing Then
        '    ret.AppendLine("El concepto del comprobante seleccionado no es válido")
        'Else
        '    Select Case DirectCast(Me.ComboBoxConceptos.SelectedItem, Entidades.Tipoconcepto).Codigo
        '        Case PRODUCTOS
        '            If Math.Abs((DateTimePickerFecha.Value - Date.Today).TotalDays) > 5 Then
        '                ret.AppendLine("La fecha del comprobante seleccionado no es válida. Para el tipo de concepto PRODUCTOS, la fecha no puede diferir en más de 5 días con la fecha actual.")
        '            End If
        '        Case SERVICIOS, PRODUCTOS_Y_SERVICIOS
        '            If Math.Abs((DateTimePickerFecha.Value - Date.Today).TotalDays) > 10 Then
        '                ret.AppendLine("La fecha del comprobante seleccionado no es válida. Para el tipo de concepto SERVICIOS, la fecha no puede diferir en más de 10 días con la fecha actual.")
        '            End If
        '    End Select
        'End If

        'If Me.TipoCbte = TipoEmisionCbte.FISCAL Then
        '    If Math.Abs((DateTimePickerFecha.Value.Date - Date.Today).TotalDays) <> 0 Then
        '        ret.AppendLine("La fecha del comprobante seleccionado no es válida")
        '    End If
        'End If

        'If Me.DateTimePickerVto.Value < Me.DateTimePickerFecha.Value Then
        '    ret.AppendLine("La fecha de vto. para el Pago del comprobante no puede ser inferior a la fecha del comprobante")
        'End If

        'validar articulos, alicuotas, otros tributos, cbte. asoc.
        If Me.CtlCbteDetalle.Articulos.Count = 0 Then
            ret.AppendLine("Debe ingresar un artículo al comprobante")
        End If

        Select Case DirectCast(Me.ComboBoxTipoCbte.SelectedItem, Entidades.Tipocomprobante).Codigo
            Case FACTURA_A, TIQUE_FACTURA_A, FACTURA_B, TIQUE_FACTURA_B, FACTURA_C, TIQUE_FACTURA_C, FACTURA_M, COMPROBANTE_X
                If nudDolar.Value < 0.01 Or nudDolar.Value > 99.99 Then
                    ret.AppendLine("La Cotización ingresada no es válida")
                End If

                'If Me.ComboBoxRemitos.SelectedItem Is Nothing Then
                '    If MessageBox.Show("No hay ningún Remito seleccionado. Desea continuar?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                '        ret.AppendLine("No hay ningún Remito seleccionado")
                '    End If
                'End If
        End Select

        If Me.CtlCbteDetalle.CbtesAsociados.Count <> 0 And _totalaplicado <> 0 Then
            'De enviarse el tag <CbtesAsoc>, entonces el campo "código de tipo de comprobante" <CbteTipo> a autorizar tiene que ser 02, 03, 07, 08, 12 o 13.
            'Para 02 y 03 pueden asociarse los tipos de comprobante 01, 02, 03, 04, 05, 34, 39, 60, 63.
            'Para 07 y 08 pueden asociarse 06, 07, 08, 09, 10, 35, 40, 61 y 64.
            'Para 12 o 13 pueden asociarse 11, 12, 13 y 15.
            Select Case DirectCast(Me.ComboBoxTipoCbte.SelectedItem, Entidades.Tipocomprobante).Codigo
                Case NOTA_CREDITO_A, NOTA_DEBITO_A, TIQUE_NOTA_CREDITO_A
                    For Each obj As Entidades.CbteAsociado In Me.CtlCbteDetalle.CbtesAsociados
                        Select Case obj.Tipo
                            Case FACTURA_B, TIQUE_FACTURA_B, NOTA_CREDITO_B, NOTA_DEBITO_B, PRESUPUESTO
                                If obj.Importe <> 0 Then
                                    ret.AppendLine("Para el tipo de comprobante seleccionado solo se admiten comprobantes tipo A. " & obj.Denominacion & " no es un cbte. válido.")
                                End If
                        End Select
                    Next
                Case NOTA_CREDITO_B, NOTA_DEBITO_B, TIQUE_NOTA_CREDITO_B
                    For Each obj As Entidades.CbteAsociado In Me.CtlCbteDetalle.CbtesAsociados
                        Select Case obj.Tipo
                            Case FACTURA_A, TIQUE_FACTURA_A, NOTA_CREDITO_A, NOTA_DEBITO_A, PRESUPUESTO
                                If obj.Importe <> 0 Then
                                    ret.AppendLine("Para el tipo de comprobante seleccionado solo se admiten comprobantes tipo B. " & obj.Denominacion & " no es un cbte. válido.")
                                End If
                        End Select
                    Next
                Case DEVOLUCION_PRESUPUESTO
                    For Each obj As Entidades.CbteAsociado In Me.CtlCbteDetalle.CbtesAsociados
                        Select Case obj.Tipo
                            Case Is <> PRESUPUESTO
                                If obj.Importe <> 0 Then
                                    ret.AppendLine("Para el tipo de comprobante seleccionado solo se admiten comprobantes tipo PRESUPUESTO. " & obj.Denominacion & " no es un cbte. válido.")
                                End If
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
            Case DEVOLUCION_PRESUPUESTO, NOTA_CREDITO_A, NOTA_CREDITO_B, NOTA_CREDITO_C, NOTA_DEBITO_A, NOTA_DEBITO_B, NOTA_DEBITO_C, TIQUE_NOTA_CREDITO, TIQUE_NOTA_CREDITO_A, TIQUE_NOTA_CREDITO_B, NOTA_DEBITO_X, NOTA_CREDITO_X
                If _totalaplicado = 0 Then 'And Me.ComboBoxFormaPago.SelectedValue <> FP_CONTADO Then
                    ret.AppendLine("Debe imputar el importe del cbte. a algún cbte. pendiente")
                End If
        End Select

        'validar totales
        If _total <= 0 Then
            ret.AppendLine("El total del comprobante no puede ser cero")
        End If

        'si no tengo permisos para emitir las notas de credito valido las credenciales
        Select Case DirectCast(Me.ComboBoxTipoCbte.SelectedItem, Entidades.Tipocomprobante).Codigo
            Case DEVOLUCION_PRESUPUESTO, NOTA_CREDITO_A, NOTA_CREDITO_B, NOTA_CREDITO_C, TIQUE_NOTA_CREDITO, TIQUE_NOTA_CREDITO_A, TIQUE_NOTA_CREDITO_B, NOTA_CREDITO_X
                If Not gUsuario.Notadecredito Then
                    If Not AutorizarPermiso(PermisoUsuario.EMITE_NOTA_CREDITO) Then
                        ret.AppendLine("No tiene permisos para emitir el tipo de comprobante seleccionado")
                    End If
                End If
        End Select

        'las ventas al contado permiten seleccionar la forma de pago. Efectivo o tarjeta
        If ret.Length = 0 Then

            Dim fp As New FormFpDialog

            _formadepago = Nothing

            'If Me.ComboBoxFormaPago.SelectedValue = FP_CONTADO And Me.TipoCbte <> TipoEmisionCbte.PRESUPUESTO Then

            '    fp.Importe = _total
            '    fp.Comprobante = DirectCast(Me.ComboBoxTipoCbte.SelectedItem, Entidades.Tipocomprobante).Denominacion
            '    fp.Comprobante &= " " & DirectCast(Me.ComboBoxTipoCbte.SelectedItem, Entidades.Tipocomprobante).Letra
            '    fp.Comprobante &= " " & Me.ComboBoxPtoVta.Text.PadLeft(4, "0") & "-" & Me.TextBoxNumero.Text.PadLeft(8, "0")

            '    fp.Tipo = DirectCast(Me.ComboBoxTipoCbte.SelectedItem, Entidades.Tipocomprobante).Tipo

            '    If fp.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            '        ret.AppendLine("Comprobante cancelado por el usuario: " & gUsuario.Nombre)
            '    Else
            '        _formadepago = fp.FormaPago
            '    End If

            'Else

            If MessageBox.Show("Confirma el comprobante?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                ret.AppendLine("Comprobante cancelado por el usuario: " & gUsuario.Nombre)
            End If

            'End If

        End If

        If Not (ret.Length = 0) Then
            MessageBox.Show("Validación del comprobante" & vbNewLine & ret.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return (ret.Length = 0)

    End Function

    Private Sub TextBoxDescuentoGral_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxDescuentoGral.LostFocus
        If Convert.ToDouble(Me.TextBoxDescuentoGral.Text) <> 0 And Convert.ToDouble(Me.TextBoxDescuentoGral.Text) > gUsuario.DescuentoTope Then
            If ChequearPermiso(PermisoUsuario.TOPE_DESCUENTO, Convert.ToDouble(Me.TextBoxDescuentoGral.Text)) Then
                Me.CtlCbteDetalle.DescuentoGral = Convert.ToDouble(Me.TextBoxDescuentoGral.Text)
            Else
                Me.TextBoxDescuentoGral.Focus()
            End If
        End If
    End Sub



    Private Sub TextBoxDescuentoGral_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxDescuentoGral.TextChanged
        If IsNumeric(Me.TextBoxDescuentoGral.Text) Then
            If Convert.ToDouble(Me.TextBoxDescuentoGral.Text) >= 0 And Convert.ToDouble(Me.TextBoxDescuentoGral.Text) <= 100 Then
                Me.CtlCbteDetalle.DescuentoGral = Convert.ToDouble(Me.TextBoxDescuentoGral.Text)
            Else
                Me.CtlCbteDetalle.DescuentoGral = 0.0
            End If
        End If
    End Sub

    Private Sub ComboBoxVendedor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxVendedor.SelectedIndexChanged
        CargaDatosVendedor()
    End Sub

    Private Sub CargaDatosVendedor()
        If ComboBoxVendedor.SelectedItem IsNot Nothing Then
            Me.CtlCbteDetalle.ArticulosDelVendedor(DirectCast(ComboBoxVendedor.SelectedItem, Entidades.Vendedor))
        End If
    End Sub

    Private Sub CustomKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then

            If sender Is Me.ComboBoxRemitos Then
                If Me.TextBoxDescuentoGral.Enabled Then
                    Me.TextBoxDescuentoGral.Focus()
                Else
                    Me.CtlCbteDetalle.FocoArticulo()
                End If
            ElseIf sender Is Me.TextBoxDocumento Then
                Me.TextBoxNombre.Focus()
            ElseIf sender Is Me.TextBoxNombre Then
                Me.CtlCbteDetalle.FocoArticulo()
            ElseIf sender Is Me.TextBoxDescuentoGral Then
                Me.CtlCbteDetalle.FocoArticulo()
            Else
                e.SuppressKeyPress = True
            End If

            'SendKeys.Send(vbTab)

        End If
    End Sub

    Private Sub ComboBoxDomicilios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxDomicilios.SelectedIndexChanged
        Me.TextBoxDomicilio.Text = Me.ComboBoxDomicilios.Text
    End Sub

    Private Function ChequearPermiso(ByVal permiso As PermisoUsuario, Optional ByVal valor As Double = 0.0) As Boolean
        Select Case permiso
            Case PermisoUsuario.TOPE_DESCUENTO
                If valor <= gUsuario.DescuentoTope Then
                    Return True
                Else
                    Return AutorizarPermiso(permiso, valor)
                End If
            Case PermisoUsuario.EMITE_NOTA_CREDITO
                Return gUsuario.Notadecredito
            Case Else : Return False
        End Select
    End Function

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



    Private Sub ToolStripButtonProforma_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripButtonProforma.Click
        Proforma()
    End Sub

    Private Sub Proforma()


        Try

            Dim c As Entidades.CbteCabecera = CrearComprobante()
            Dim myData As New DataSet
            Dim myAdapter As New OleDb.OleDbDataAdapter

            myData.DataSetName = "Rows"
            myData.Tables.Add("Row")
            myData.Tables("Row").Columns.Add("Codigo", GetType(String))
            myData.Tables("Row").Columns.Add("Descripcion", GetType(String))
            myData.Tables("Row").Columns.Add("Importe", GetType(Double))
            myData.Tables("Row").Columns.Add("Descuento", GetType(Double))
            myData.Tables("Row").Columns.Add("ImpInterno", GetType(Double))
            myData.Tables("Row").Columns.Add("Alicuota", GetType(Double))
            myData.Tables("Row").Columns.Add("Cantidad", GetType(Double))
            myData.Tables("Row").Columns.Add("ImporteFinal", GetType(Double))
            myData.Tables("Row").Columns.Add("SubtotalSinIVA", GetType(Double))
            myData.Tables("Row").Columns.Add("ImporteConIVA", GetType(Double))
            myData.Tables("Row").Columns.Add("SubtotalFinal", GetType(Double))
            myData.Tables("Row").Columns.Add("ImporteBruto", GetType(Double))

            Dim dr As DataRow


            For Each a As Entidades.CbteArticulo In c.CbteArticulos
                dr = myData.Tables("Row").NewRow()
                dr("Codigo") = a.Codigo
                dr("Descripcion") = a.Descripcion
                dr("Importe") = a.Importe
                dr("Descuento") = a.Descuento
                dr("ImpInterno") = a.ImpInterno
                dr("Alicuota") = a.Alicuota
                dr("Cantidad") = a.Cantidad
                dr("ImporteFinal") = a.ImporteFinal
                dr("SubtotalSinIVA") = a.SubtotalSinIVA
                dr("ImporteConIVA") = a.ImporteConIVA
                dr("SubtotalFinal") = a.SubtotalFinal
                dr("ImporteBruto") = a.ImporteBruto

                myData.Tables("Row").Rows.Add(dr)

            Next

            myData.WriteXml(My.Settings.RutaReportes & "\proforma_art.xml", XmlWriteMode.IgnoreSchema)

            Call EmisionCbteProforma(c)

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub ComboBoxRemitos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxRemitos.LostFocus
        CargarArticulosRemito(sender, e)
    End Sub

    Private Sub BtnArtRemito_Click(sender As System.Object, e As System.EventArgs) Handles BtnArtRemito.Click

    End Sub
End Class