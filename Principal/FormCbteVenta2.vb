Imports Microsoft.VisualBasic.FileIO.FileSystem
Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO
Imports System.Text
Imports System.Security

Public Class FormCbteVenta2

    Property Entidad As Entidades.CbteCabecera2

    Property PreCompra As Boolean
    Property ClientePreCompra As String

    Property TipoCbte As TipoEmisionCbte

    Property mblnBase As Boolean

    Private _decimalSeparator As Char
    'totalizadores del comprobante
    Private _subtotal As Double = 0.0
    Private _iva As Double = 0.0
    Private _otrostributos As Double = 0.0
    Private _exento As Double = 0.0
    Private _descuento As Double = 0.0
    Private _nogravado As Double = 0.0
    Private _total As Double = 0.0
    Private _totalaplicado As Double

    Private _repositorio As New CapaLogica.CbteCabecera2CLog
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

    Private Const RESPONSABLE_INSCRIPTO As UInt32 = 1
    Private Const MONOTRIBUTISTA As UInt32 = 3
    Private Const EXENTO As UInt32 = 4
    Private Const NO_CATEGORIZADO As UInt32 = 5

    Private _autorizandoCbte As Boolean
    Dim mblnOk As Boolean
    Dim mstrUltIdCli As String

    Private Sub LockScreen(ByVal lock As Boolean)
        Me.ToolStripButtonAutorizar.Enabled = Not lock
        Me.ToolStripButtonCancelar.Enabled = Not lock
        Me.ToolStripButtonSalir.Enabled = Not lock
        Me.PanelControles.Enabled = Not lock
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

        Dim titulo As String = ""

        Select Case Me.TipoCbte
            Case TipoEmisionCbte.PRESUPUESTO : titulo = "Emisión de Presupuesto"
            Case Else : titulo = "Operación no definida"
        End Select

        Me.Text = titulo


        'Me.ToolStripButtonCancelar.Enabled = _conectado
        'Me.ToolStripButtonAutorizar.Enabled = _conectado
        'Me.ToolStripButtonConectarWSAA.Enabled = Not conectado

        'cambios de estados
        'ChequearStatusServer()

        'InicializarValoresPredeterminados()

        'inicio los combos solo si estoy conectado al ws
        'Me.PanelControles.Enabled = _conectado

        'If _conectado Then
        'Me.CtlArticulos1.TipoDeCbte = CtlArticulos1.TipoCbte.CBTEVTA


        ComboBoxCliente.Enabled = True
        mstrUltIdCli = ""

        '
        InicializarComboPuntosDeVenta()
        InicializarComboTiposDeCbte()
        InicializarComboClientes()
        InicializarComboMonedas()
        InicializarArticulos()
        'InicializarComboConceptos()

        'End If

        LimpiarFormulario()

    End Sub

    Private Sub InicializarArticulos()
        'limpio grilla articulos
        Me.CtlArticulos1.idCliente = ComboBoxCliente.SelectedValue
        Me.CtlArticulos1.TipoCargaCbte = Me.TipoCbte
        Me.CtlArticulos1.MaximoItems = 15
        Me.CtlArticulos1.Inicializar()
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

        'limpio grilla articulos
        Me.CtlArticulos1.Limpiar()

        Me.ComboBoxCliente.SelectedIndex = -1

        If ComboBoxPtoVta.Items.Count > 0 Then
            ComboBoxPtoVta.SelectedIndex = 0
        End If

        If ComboBoxTipoCbte.Items.Count > 0 Then
            ComboBoxTipoCbte.SelectedIndex = 0
        End If

        Me.ToolStripLabelStatus.Text = ""

        'Selecciono PESOS
        ComboBoxMoneda.SelectedIndex = 0

        InicializarValoresPredeterminados()

        If Entidad IsNot Nothing Then

            If mblnBase = False Then
                Me.DateTimePickerFecha.Value = ParseStringToDate(Entidad.Cbtefecha)
                Me.DateTimePickerVigencia.Value = Entidad.FechaVigencia
            End If

            Me.ComboBoxCliente.SelectedValue = Entidad.Clienteid
            If Len(Trim(Entidad.Clienteid)) = 0 Then
                Me.TextBoxNombre.Text = Entidad.Razonsocial
                Me.TextBoxDocumento.Text = Entidad.Documentonro
                Me.TextBoxTipoDoc.Text = Entidad.Documentotipo
                Me.TextBoxTipoIVA.Text = Entidad.Tiporesponsable
                Me.TextBoxDomicilio.Text = Entidad.Domicilio
                Me.TextBoxTelefono.Text = Entidad.Telefono
                Me.TextBoxContacto.Text = Entidad.Contacto
                Me.TextBoxEmail.Text = Entidad.Email
            Else
                CargaDatosCliente()
            End If

            InicializarArticulos()

            Me.ComboBoxMoneda.SelectedIndex = IIf(Entidad.Monedaid = "PES", 0, 1)
            Me.txtObs.Text = Entidad.Observaciones
            Me.txtNotas.Text = Entidad.ObservacionesExtra
            Me.TextBoxCondicionesPago.Text = Entidad.CondicionesPago
            Me.TextBoxLugarEntrega.Text = Entidad.LugarEntrega
            Me.TextBoxMantenimientoOferta.Text = Entidad.MantenimientoOferta
            Me.TextBoxPlazosEntrega.Text = Entidad.PlazosEntrega
            Me.CtlArticulos1.ArticulosVenta = Entidad.CbteArticulos2
            Me.CtlArticulos1.PoblarGrillas()
            Me.CtlArticulos1.Totalizar()
            Me.CtlArticulos1.FocoArticulo()

            If mblnBase = False Then
                Me.ComboBoxTipoCbte.Enabled = False
                Me.DateTimePickerFecha.Enabled = False
                Me.ComboBoxPtoVta.Enabled = False
                Me.TextBoxNumero.Enabled = False
            Else

                Me.ComboBoxTipoCbte.Enabled = True
                Me.DateTimePickerFecha.Enabled = True

                Me.ComboBoxCliente.Focus()
                Me.ComboBoxCliente.Select()
                Application.DoEvents()
            End If
        Else
            Me.ComboBoxCliente.Focus()
            Me.ComboBoxCliente.Select()
            Application.DoEvents()
        End If

    End Sub

    Private Sub InicializarComboMonedas()
        With Me.ComboBoxMoneda
            .DropDownStyle = ComboBoxStyle.DropDownList
            .Items.Clear()
            .Items.Add("PES")
            .Items.Add("DOL")
            .SelectedIndex = 0
        End With
    End Sub

    Private Sub FormCbteVenta2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.ComboBoxCliente.Focus()
        Me.ComboBoxCliente.Select()
        Application.DoEvents()
    End Sub

    'Private Sub FormCbteVenta2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    '    If Me.TipoCbte = TipoEmisionCbte.FISCAL Then
    '        Me.CtlCbteDetalle.FocoArticulo()
    '    Else
    '        Me.ComboBoxCliente.Focus()
    '    End If
    'End Sub

    Private Sub FormCbteVenta2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = _autorizandoCbte
    End Sub

    Private Sub FormCbteElectronico_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If Not ConexionConAFIP() Then
        '    CrearConexionAFIP()
        'End If

        InicializarFormulario()
    End Sub

    Private Sub InicializarComboTiposDeCbte()

        Dim repositorio As New CapaLogica.TipocomprobanteCLog
        Dim Codigo As UInteger

        Select Case Me.TipoCbte
            Case TipoEmisionCbte.PRESUPUESTO : Codigo = PRESUPUESTO
        End Select

        With Me.ComboBoxTipoCbte

            .ValueMember = "Codigo"
            .DisplayMember = "Denominacion"
            .DropDownStyle = ComboBoxStyle.DropDownList
            '.AutoCompleteMode = AutoCompleteMode.Suggest
            '.AutoCompleteSource = AutoCompleteSource.ListItems
            .DataSource = repositorio.GetAll().Where(Function(x) x.Codigo = Codigo).ToList
            .SelectedIndex = 0

        End With

    End Sub

    Private Sub InicializarComboPuntosDeVenta()
        With Me.ComboBoxPtoVta

            .DropDownStyle = ComboBoxStyle.DropDownList
            .Items.Clear()
            .Items.Add("0001")

            If .Items.Count > 0 Then
                .SelectedIndex = 0
            End If

        End With
    End Sub

    
    Private Sub InicializarComboClientes()
        Dim repositorio As New CapaLogica.ClienteCLog
        Dim c As BrightIdeasSoftware.OLVColumn = Nothing
        Dim cols As New List(Of BrightIdeasSoftware.OLVColumn)

        c = New BrightIdeasSoftware.OLVColumn
        c.Text = "Documento/CUIT"
        c.AspectName = "Documento"
        c.MinimumWidth = 100
        c.TextAlign = HorizontalAlignment.Center
        c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        cols.Add(c)

        c = New BrightIdeasSoftware.OLVColumn
        c.Text = "Teléfono"
        c.AspectName = "Telefono"
        c.MinimumWidth = 120
        c.TextAlign = HorizontalAlignment.Left
        c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        cols.Add(c)

        c = New BrightIdeasSoftware.OLVColumn
        c.Text = "Domicilio"
        c.AspectName = "Domicilio"
        c.MinimumWidth = 200
        c.TextAlign = HorizontalAlignment.Left
        c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        cols.Add(c)

        With Me.ComboBoxCliente
            .ValueMember = "Codigo"
            .DisplayMember = "NombreyCodigo"
            .ColumnasExtras = cols
            .DataSource = repositorio.GetAll.OrderBy(Function(x) x.Nombre).ToList()
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            '.DropDownStyle = ComboBoxStyle.DropDownList
            .Inicializar()
            .SelectedIndex = -1
        End With

    End Sub

    Private Function UltimoCbteAutorizado() As Int32

        Dim ret As Int32 = 0
        Dim reponumeracion As New CapaLogica.ParametroCLog
        'Dim ptovta As UInt32
        Dim numeracion As UInt32

        Try

            Select Case Me.TipoCbte
                Case TipoEmisionCbte.PRESUPUESTO : numeracion = reponumeracion.GetByNombre("Ult_Nro_Presupuesto").Valorpredeterminado
            End Select


            numeracion += 1

            Return numeracion

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
            'Me.TextBoxNombre.Text = e.Nombre
            Me.TextBoxDocumento.Text = e.Documento
            Me.TextBoxTipoDoc.Text = "DNI"
            Select Case e.Tiporesponsable
                Case RESPONSABLE_INSCRIPTO
                    Me.TextBoxTipoIVA.Text = "RESP. INSCRIPTO"
                    Me.TextBoxTipoDoc.Text = "CUIT"
                Case MONOTRIBUTISTA
                    Me.TextBoxTipoIVA.Text = "RESP. MONOTRIBUTO"
                    Me.TextBoxTipoDoc.Text = "CUIT"
                Case NO_CATEGORIZADO
                    Me.TextBoxTipoIVA.Text = "NO CATEGORIZADO"
                    Me.TextBoxTipoDoc.Text = "DNI"
                Case EXENTO
                    Me.TextBoxTipoIVA.Text = "RESP. EXENTO"
                    Me.TextBoxTipoDoc.Text = "CUIT"
                Case Else
                    Me.TextBoxTipoIVA.Text = e.Tiporesponsable.ToString
            End Select

            Me.CtlArticulos1.ListaDePrecio = CtlArticulos.ListaPrecios.LISTA_A

            Me.TextBoxNombre.Text = e.Nombre
            Me.TextBoxDomicilio.Text = e.Domicilio
            Me.TextBoxTelefono.Text = e.Telefono
            Me.TextBoxContacto.Text = e.Contacto
            Me.TextBoxEmail.Text = e.Email

            Me.DateTimePickerVigencia.Value.AddDays(0)

            If mblnBase = False Then
                Me.TextBoxDocumento.ReadOnly = True
                Me.TextBoxTipoDoc.ReadOnly = True
                Me.TextBoxTipoIVA.ReadOnly = True
                Me.TextBoxNombre.ReadOnly = True
                Me.TextBoxDomicilio.ReadOnly = True
                Me.TextBoxTelefono.ReadOnly = True
                Me.TextBoxContacto.ReadOnly = True
                Me.TextBoxEmail.ReadOnly = True
            Else
                Me.TextBoxDocumento.ReadOnly = False
                Me.TextBoxTipoDoc.ReadOnly = False
                Me.TextBoxTipoIVA.ReadOnly = False
                Me.TextBoxNombre.ReadOnly = False
                Me.TextBoxDomicilio.ReadOnly = False
                Me.TextBoxTelefono.ReadOnly = False
                Me.TextBoxContacto.ReadOnly = False
                Me.TextBoxEmail.ReadOnly = False
            End If



        Else

            'Me.TextBoxNombre.Text = ""
            Me.TextBoxDocumento.Text = ""
            Me.TextBoxTipoDoc.Text = ""
            Me.TextBoxTipoIVA.Text = ""
            Me.TextBoxDomicilio.Text = ""
            Me.TextBoxTelefono.Text = ""
            Me.TextBoxContacto.Text = ""
            Me.TextBoxEmail.Text = ""

            Me.TextBoxDocumento.ReadOnly = False
            Me.TextBoxTipoDoc.ReadOnly = False
            Me.TextBoxTipoIVA.ReadOnly = False
            Me.TextBoxNombre.ReadOnly = False
            Me.TextBoxDomicilio.ReadOnly = False
            Me.TextBoxTelefono.ReadOnly = False
            Me.TextBoxContacto.ReadOnly = False
            Me.TextBoxEmail.ReadOnly = False

        End If

    End Sub

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        For Each c As Control In Me.PanelControles.Controls
            Select Case c.GetType
                Case GetType(TextBox), GetType(ComboBox), GetType(NumericUpDown)
                    AddHandler c.GotFocus, AddressOf CustomGotFocus
                    AddHandler c.LostFocus, AddressOf CustomLostFocus
                Case GetType(GroupBox)
                    For Each g As Control In c.Controls
                        Select Case g.GetType
                            Case GetType(TextBox), GetType(ComboBox), GetType(NumericUpDown)
                                AddHandler g.GotFocus, AddressOf CustomGotFocus
                                AddHandler g.LostFocus, AddressOf CustomLostFocus
                        End Select
                    Next
            End Select
        Next

        _decimalSeparator = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator

        AddHandler Me.KeyDown, AddressOf FormularioKeyDown
        AddHandler Me.CtlArticulos1.KeyDown, AddressOf FormularioKeyDown
        
    End Sub

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F12 : If Not _autorizandoCbte Then AutorizandoCbte()
            Case Keys.Escape
                If Not _autorizandoCbte Then
                    If Me.ComboBoxCliente.SelectedItem Is Nothing Then
                        Salir()
                    Else
                        Cancelar()
                    End If
                End If
            Case Keys.Enter
                'If Me.ActiveControl.Name = Me.CtlArticulos1.Name Or Me.ActiveControl.Name = Me.ComboBoxCliente.Name Then
                'If Me.ActiveControl.Name = Me.ComboBoxCliente.Name Then
                '    Exit Sub
                'End If
                If Not Me.CtlArticulos1.FOLVArticulos.IsCellEditing And Me.ActiveControl.Name <> Me.txtObs.Name And Me.ActiveControl.Name <> Me.txtNotas.Name Then SendKeys.Send(vbTab)
        End Select
    End Sub

    Private Sub Cancelar()
        If MessageBox.Show("Cancelar comprobante?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            LimpiarFormulario()
        End If
    End Sub

    Private Sub CustomGotFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = Color.LightSteelBlue

        If sender.GetType = GetType(TextBox) Then
            DirectCast(sender, TextBox).Font = New Font(DirectCast(sender, TextBox).Font, FontStyle.Bold)
            DirectCast(sender, TextBox).SelectAll()
        ElseIf sender.GetType = GetType(NumericUpDown) Then
            DirectCast(sender, NumericUpDown).Font = New Font(DirectCast(sender, NumericUpDown).Font, FontStyle.Bold)
            DirectCast(sender, NumericUpDown).Select(0, DirectCast(sender, NumericUpDown).Text.Length)
        End If

    End Sub

    Private Sub CustomLostFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = SystemColors.Window

        If sender.GetType = GetType(TextBox) Then

            If sender Is Me.TextBoxNumero Then
                DirectCast(sender, TextBox).Font = New Font(DirectCast(sender, TextBox).Font, FontStyle.Bold)
            Else
                DirectCast(sender, TextBox).Font = New Font(DirectCast(sender, TextBox).Font, FontStyle.Regular)
            End If

        ElseIf sender.GetType = GetType(NumericUpDown) Then
            DirectCast(sender, NumericUpDown).Font = New Font(DirectCast(sender, NumericUpDown).Font, FontStyle.Regular)
        End If



    End Sub

    Private Function CrearComprobante() As Entidades.CbteCabecera2
        Dim cbte As New Entidades.CbteCabecera2
        'Dim financiero As Entidades.Financiero
        Dim tipoCbte As Entidades.Tipocomprobante

        Try

            ActualizaNumeracion()

            tipoCbte = DirectCast(Me.ComboBoxTipoCbte.SelectedItem, Entidades.Tipocomprobante)

            With cbte

                If Entidad IsNot Nothing And mblnBase = False Then
                    .Id = Entidad.Id
                End If

                .Usuario = gUsuario.Id
                .Sucursal = 0 'My.Settings.CodigoSucursal
                .Clienteid = Convert.ToString(Me.ComboBoxCliente.SelectedValue)
                .Vendedor = 0
                .Razonsocial = Me.TextBoxNombre.Text 'DirectCast(Me.ComboBoxCliente.SelectedItem, Entidades.Clientes).Nombre
                .Domicilio = Me.TextBoxDomicilio.Text
                .Telefono = Me.TextBoxTelefono.Text
                .Contacto = Me.TextBoxContacto.Text
                .Email = Me.TextBoxEmail.Text

                .Nroremito = ""
                .RemitoId = 0
                .Cbtefecha = Me.DateTimePickerFecha.Value.ToString("yyyyMMdd")
                .FechaVigencia = Me.DateTimePickerVigencia.Value
                .Cbtenumero = Convert.ToUInt32(Me.TextBoxNumero.Text)
                .Cbteptovta = Convert.ToUInt32(Me.ComboBoxPtoVta.SelectedItem)
                .Cbtetipo = tipoCbte.Codigo
                .Letra = tipoCbte.Letra
                .Denominacion = tipoCbte.Denominacion
                .Tipo = tipoCbte.Tipo
                .Concepto = 0 'Convert.ToUInt32(Me.ComboBoxConceptos.SelectedValue)
                .Documentonro = Me.TextBoxDocumento.Text.Trim
                .Documentotipo = Me.TextBoxTipoDoc.Text.Trim
                .Tiporesponsable = Me.TextBoxTipoIVA.Text.Trim
                .Fechaserviciodesde = Me.DateTimePickerFecha.Value.ToString("yyyyMMdd")
                .Fechaserviciohasta = Me.DateTimePickerFecha.Value.ToString("yyyyMMdd")
                .Fechavtopago = Me.DateTimePickerFecha.Value.ToString("yyyyMMdd")
                .Formadepago = 0 'Convert.ToUInt32(Me.ComboBoxFormaPago.SelectedValue)
                .Importeiva = _iva
                .Importeneto = _subtotal
                .Importetributos = _otrostributos
                .Importeopexentas = _exento
                .Importetotalconceptos = _nogravado
                .Importetotal = _total
                .Monedactz = 1
                .Monedaid = "PES"
                .Descuento = 0 'Convert.ToDouble(Me.TextBoxDescuentoGral.Text)
                .Observaciones = Me.txtObs.Text
                .ObservacionesExtra = Me.txtNotas.Text
                .CondicionesPago = Me.TextBoxCondicionesPago.Text.Trim
                .PlazosEntrega = Me.TextBoxPlazosEntrega.Text.Trim
                .LugarEntrega = Me.TextBoxLugarEntrega.Text.Trim
                .MantenimientoOferta = Me.TextBoxMantenimientoOferta.Text.Trim
                .Estado = "ABIERTO"
                .Monedaid = Me.ComboBoxMoneda.Text

                'agrego todos los articulos del comprobante
                For Each o As Entidades.CbteArticulo2 In Me.CtlArticulos1.ArticulosVenta
                    .CbteArticulos2.Add(o)
                Next

            End With

            Return cbte

        Catch ex As Exception

            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return Nothing

        End Try
    End Function

    Private Sub CtlArticulos1_ExitControl() Handles CtlArticulos1.ExitControl
        Application.DoEvents()
        Me.TextBoxCondicionesPago.Focus()
    End Sub

    Private Sub CtlArticulos1_Totalizado() Handles CtlArticulos1.Totalizado

        With CtlArticulos1
            _subtotal = .Subtotal
            _iva = 0 '.Iva
            _otrostributos = 0 '.OtrosTributos
            _exento = 0 '.Exento
            _descuento = 0 '.Descuento
            _nogravado = 0 '.NoGravado
            _total = .Total
            _totalaplicado = 0 '.TotalAplicado
            Call LockDatosCliente(Not .ArticulosVenta.Count = 0)
        End With

        'Me.TextBoxSubtotal.Text = _subtotal.ToString("$ #,##0.00")
        'Me.TextBoxIVAFacturado.Text = _iva.ToString("$ #,##0.00")
        'Me.TextBoxOtrosTributos.Text = _otrostributos.ToString("$ #,##0.00")
        'Me.TextBoxExento.Text = _exento.ToString("$ #,##0.00")
        'Me.TextBoxNogravado.Text = _nogravado.ToString("$ #,##0.00")
        'Me.TextBoxTotal.Text = _total.ToString("$ #,##0.00")
        'Me.LabelTotal.Text = "Items ingresados " & CtlArticulos1.ArticulosVenta.Count & ", por cargar " & CtlArticulos1.MaximoItems - CtlArticulos1.ArticulosVenta.Count & ". Esta Venta >> " & _total.ToString("$ #,##0.00") & " <<"

        Me.TextBoxSubtotal.Text = _subtotal.ToString("#,##0.00")
        Me.TextBoxIVAFacturado.Text = _iva.ToString("#,##0.00")
        Me.TextBoxOtrosTributos.Text = _otrostributos.ToString("#,##0.00")
        Me.TextBoxExento.Text = _exento.ToString("#,##0.00")
        Me.TextBoxNogravado.Text = _nogravado.ToString("#,##0.00")
        Me.TextBoxTotal.Text = _total.ToString("#,##0.00")
        Me.LabelTotal.Text = "Items ingresados " & CtlArticulos1.ArticulosVenta.Count & ", por cargar " & CtlArticulos1.MaximoItems - CtlArticulos1.ArticulosVenta.Count & ". Esta Venta >> " & _total.ToString("#,##0.00") & " <<"

    End Sub

    Private Sub AutorizarCbte(ByVal cbte As Entidades.CbteCabecera2)
        Dim mensajes As New StringBuilder
        Dim tipoPtoVta As String = ""

        Try

            mblnOk = False
            'envio los nuevos datos al repositor para actualizar
            _repositorio.Save(cbte)

            If _repositorio.HasError Then

                MessageBox.Show(_repositorio.mensajes.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                If MessageBox.Show("La operación ha finalizado correctamente. Desea imprimir el comprobante?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    EmisionCbtePres(cbte.Id)
                End If

                If MessageBox.Show("Desea Enviar el comprobante por email?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim f As New FormEmail
                    f.Modo = 2
                    f.Cbte = _repositorio.GetById(cbte.Id, False, False, False, False, False, False)
                    f.mstrEmail = Me.TextBoxEmail.Text
                    f.ShowDialog()
                    f.Dispose()
                End If

                If Me.Entidad IsNot Nothing Then
                    _autorizandoCbte = False
                    Me.Close()
                Else
                    LimpiarFormulario()
                    mblnOk = True
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

            Dim cbte As Entidades.CbteCabecera2 = CrearComprobante()

            If cbte IsNot Nothing Then
                AutorizarCbte(cbte)
            End If

        End If

        _autorizandoCbte = False

        LockScreen(_autorizandoCbte)

        If mblnOk = True Then Me.Close()

    End Sub

    Private Sub ToolStripButtonCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonCancelar.Click
        Cancelar()
    End Sub

    Private Sub ComboBoxCliente_CodigoEncontrado() Handles ComboBoxCliente.CodigoEncontrado
        If Me.ComboBoxCliente.SelectedValue <> mstrUltIdCli Then
            Me.CtlArticulos1.Limpiar()
            InicializarArticulos()
        End If
        CargaDatosCliente()
        ComboBoxCliente.Enabled = False
        
        ComboBoxPtoVta.Focus()
    End Sub

    Private Sub ComboBoxCliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxCliente.LostFocus
        If ComboBoxCliente.SelectedValue Is Nothing Then
            Me.TextBoxTipoDoc.Text = "DNI"
            Me.TextBoxTipoIVA.Text = "CONSUMIDOR FINAL"
        End If
    End Sub

    Private Sub ComboBoxCliente_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxCliente.SelectedIndexChanged
        'CargaDatosCliente()

    End Sub

    Private Sub InicializarValoresPredeterminados()

        Dim repoCliente As New CapaLogica.ClienteCLog
        Dim repoparametro As New CapaLogica.ParametroCLog

        Me.DateTimePickerFecha.Enabled = Not (Me.TipoCbte = TipoEmisionCbte.FISCAL)
        Me.DateTimePickerVigencia.Enabled = Not (Me.TipoCbte = TipoEmisionCbte.FISCAL)

        Me.ComboBoxPtoVta.SelectedIndex = 0
        If Entidad IsNot Nothing And mblnBase = False Then
            Me.TextBoxNumero.Text = Entidad.Cbtenumero.ToString("00000000")
        Else
            Me.TextBoxNumero.Text = UltimoCbteAutorizado.ToString("00000000")
        End If
        Me.TextBoxNumero.ReadOnly = True

        Me.TextBoxLugarEntrega.Text = "Nuestro establecimiento"
        Me.TextBoxPlazosEntrega.Text = "A convenir"
        Me.TextBoxMantenimientoOferta.Text = "15 días"
        Me.TextBoxCondicionesPago.Text = "Las habituales"

    End Sub

    Private Function ValidarCbte() As Boolean

        Dim ret As New StringBuilder

        'validar datos del receptor
        If Me.ComboBoxCliente.SelectedItem Is Nothing And Len(Trim(Me.TextBoxNombre.Text)) = 0 Then
            ret.AppendLine("El Cliente seleccionado no es válido")
        End If

        If Me.ComboBoxMoneda.SelectedIndex = -1 Then
            ret.AppendLine("La Moneda ingresada no es válida")
        End If

        If Me.CtlArticulos1.FOLVArticulos.IsCellEditing Then
            ret.AppendLine("Debe finalizar la edición en la grilla de artículos")
        End If

        'If Me.ComboBoxDocumento.SelectedItem Is Nothing Then
        '    ret.AppendLine("El tipo de documento seleccionado no es válido")
        'Else
        '    Select Case DirectCast(Me.ComboBoxDocumento.SelectedItem, Entidades.Tipodocumento).Codigo
        '        Case DOCUMENTO_CUIT
        '            If Me.TextBoxDocumento.Text.Length <> 11 Then
        '                ret.AppendLine("El nro. de CUIT ingresado no es correcto")
        '            ElseIf IsNumeric(Me.TextBoxDocumento.Text) = False Then
        '                ret.AppendLine("El nro. de CUIT ingresado no es correcto")
        '            Else
        '                If Not General.VerificaCuit(Me.TextBoxDocumento.Text) Then
        '                    ret.AppendLine("El nro. de CUIT ingresado no es válido")
        '                End If
        '            End If
        '        Case DOCUMENTO_DNI
        '            If Me.TextBoxDocumento.Text.Length = 0 Then
        '                ret.AppendLine("El nro. de documento ingresado no es correcto")
        '            End If
        '    End Select
        'End If

        'If Me.ComboBoxResponsabilidadIVA.SelectedItem Is Nothing Then
        '    ret.AppendLine("El tipo de responsabilidad de IVA del receptor no es válido")
        'End If

        'If Me.ComboBoxCliente.Text.Length = 0 Then
        '    ret.AppendLine("El nombre o razón social del receptor no es correcto")
        'End If

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

        If Me.TipoCbte = TipoEmisionCbte.FISCAL Then
            If Me.DateTimePickerFecha.Value <> Date.Today Then
                ret.AppendLine("La fecha del comprobante seleccionado no es válida")
            End If
        End If

        If Format(Me.DateTimePickerVigencia.Value, "yyyy/MM/dd") < Format(Me.DateTimePickerFecha.Value, "yyyy/MM/dd") Then
            ret.AppendLine("La fecha de vigencia del comprobante no puede ser inferior a la fecha del comprobante")
        End If

        If Me.CtlArticulos1.ArticulosVenta.Count = 0 Then
            ret.AppendLine("Debe ingresar un artículo al comprobante")
        End If

        'ValidarAlicuotasIVA(ret)

        'validar totales
        'If _total <= 0 Then
        '    ret.AppendLine("El total del comprobante no puede ser cero")
        'End If

        If Not (ret.Length = 0) Then
            MessageBox.Show("Validación del comprobante" & vbNewLine & ret.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else

            ''validacion de comprobante preexistente una vez que haya superado la valiación de tipos
            'Dim c As Entidades.Cbtecabecera = _repositorio.GetByNumero(Convert.ToUInt32(Me.ComboBoxCliente.SelectedValue), Me.ComboBoxTipoCbte.SelectedValue, _
            'Convert.ToUInt32(Me.ComboBoxPtoVta.Text), Convert.ToUInt32(Me.TextBoxNumero.Text))

            'If c IsNot Nothing Then
            '    If MessageBox.Show("El comprobante que intenta cargar ya existe" & vbNewLine & _
            '                       "Comprobante: " & c.CbteDenominacion & vbNewLine & _
            '                       "Fecha del cbte.: " & ParseStringToDate(c.Cbtefecha) & vbNewLine & _
            '                       "Importe total: " & c.Importetotal.ToString("$ #,##0.00#") & vbNewLine & _
            '                       "Desea continuar?" _
            '                       , Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
            '        Return False
            '    End If
            'Else

            If MessageBox.Show("¿Confirma la carga del comprobante?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                Return False
            End If

            'End If

        End If

        Return (ret.Length = 0)

    End Function

    Private Sub ValidarAlicuotasIVA(ByRef ret As StringBuilder)

        Dim baseImponible As Double = 0.0

        baseImponible = 0

        'If Math.Abs(baseImponible - _subtotal) > 0.1 Then
        '    'ret.AppendLine("El importe neto gravado no coincide con las alicuotas aplicadas. Importe esperado: " & baseImponible.ToString("$ #,##0.00"))
        '    ret.AppendLine("El importe neto gravado no coincide con las alicuotas aplicadas. Importe esperado: " & baseImponible.ToString("#,##0.00"))
        'End If

    End Sub

    Private Sub Salir()
        If MessageBox.Show("Salir del comprobante?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub ToolStripButtonSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonSalir.Click
        Salir()
    End Sub

    Private Sub ActualizaNumeracion()
        If Entidad IsNot Nothing And mblnBase = False Then
            Me.TextBoxNumero.Text = Entidad.Cbtenumero.ToString("00000000")
        Else
            Me.TextBoxNumero.Text = UltimoCbteAutorizado.ToString("00000000")
        End If
    End Sub

    Private Sub DateTimePickerVigencia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePickerVigencia.LostFocus
        Me.CtlArticulos1.Totalizar()
        Me.CtlArticulos1.FocoArticulo()
    End Sub

    Private Sub ComboBoxCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxCliente.Load

    End Sub

    Private Sub CtlArticulos1_Load(sender As System.Object, e As System.EventArgs) Handles CtlArticulos1.Load

    End Sub
End Class