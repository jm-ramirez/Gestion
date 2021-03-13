Public Class FormCbteRemito

    Private _repositorioCli As New CapaLogica.ClienteCLog
    Private _repositorioArt As New CapaLogica.ArticuloCLog
    Private _repositorioVen As New CapaLogica.VendedorCLog
    Private _repositorioTra As New CapaLogica.TransporteCLog

    Property Entidad As Entidades.CbteCabecera

    Property EntidadDet As Entidades.CbteArticulo

    Property EntidadRemito As Entidades.Remito

    Private _repositorio As New CapaLogica.ordencompracabCLog

    Private _repositorioCbte As New CapaLogica.CbtecabeceraCLog

    Private dblTotal As Double
    Private dblCantTotal As Double
    Private dblUnidad As Double
    Private dblKgs As Double
    Public _Lista As List(Of Entidades.CbteArticulo)
    Private _ListaRemito As List(Of Entidades.Remito)
    Private _ListaNroOrden As List(Of Entidades.OrdenCompracab)

    Private blnModifica As Boolean

    Private strOrdenCompra As String = ""
    Private strOrdenCompra1 As String = ""
    Private strOrdenCompra2 As String = ""
    Private strOrdenCompra3 As String = ""
    Private strOrdenCompra4 As String = ""
    Private strOrdenCompra5 As String = ""

    Private Sub InicializarFormulario()

        'limpieza de controles
        For Each c As Control In Me.GroupBoxDatosCliente.Controls
            Select Case c.GetType
                Case GetType(TextBox) : DirectCast(c, TextBox).Text = ""
                Case GetType(ComboBox) : DirectCast(c, ComboBox).SelectedIndex = -1
                Case GetType(CheckBox) : DirectCast(c, CheckBox).Checked = False
                Case GetType(NumericUpDown) : DirectCast(c, NumericUpDown).Value = DirectCast(c, NumericUpDown).Minimum
            End Select
        Next

        For Each c As Control In Me.GroupBoxDatosArticulos.Controls
            Select Case c.GetType
                Case GetType(TextBox) : DirectCast(c, TextBox).Text = ""
                Case GetType(ComboBox) : DirectCast(c, ComboBox).SelectedIndex = -1
                Case GetType(CheckBox) : DirectCast(c, CheckBox).Checked = False
                Case GetType(NumericUpDown) : DirectCast(c, NumericUpDown).Value = DirectCast(c, NumericUpDown).Minimum
            End Select
        Next

        For Each c As Control In Me.GroupBoxDatosTransporte.Controls
            Select Case c.GetType
                Case GetType(TextBox) : DirectCast(c, TextBox).Text = ""
                Case GetType(ComboBox) : DirectCast(c, ComboBox).SelectedIndex = -1
                Case GetType(CheckBox) : DirectCast(c, CheckBox).Checked = False
                Case GetType(NumericUpDown) : DirectCast(c, NumericUpDown).Value = DirectCast(c, NumericUpDown).Minimum
            End Select
        Next
        Me.TextBoxPrecio.ReadOnly = True
        ActualizaNumeracion()
        InicializarComboCliente()
        InicializarComboVendedor()
        InicializarComboTransporte()
        InicializarComboDocumentos()

        _Lista = New List(Of Entidades.CbteArticulo)
        _ListaNroOrden = New List(Of Entidades.OrdenCompracab)
        _ListaRemito = New List(Of Entidades.Remito)

        ConfigurarGrilla()

        Me.Text = "Remito"

        'If Not Entidad Is Nothing Then
        dblTotal = 0
        dblCantTotal = 0
        dblUnidad = 0
        dblKgs = 0

        'Me.TextBoxRemito.Text = "00000000"

        Me.TextBoxUnidad.Text = ""
        Me.TextBoxKxU.Text = "0.00"
        'Me.TextBoxKgs.Text = "0.00"
        Me.TextBoxCantidad.Text = "0.00"
        Me.TextBoxPrecio.Text = "0.00"
        '_ListaNroOrden.Clear()
        'InicializarComboOrdenCompra()
        'Me.TextBoxOrdenCompra.Text = "00000000"
        'Me.TextBoxSecuencia.Text = "00"
        Me.TextBoxSubtotalArticulo.Text = "0.00"

        blnModifica = True

        Me.GroupBoxDatosCliente.Enabled = True
        Me.GroupBoxDatosArticulos.Enabled = False

        'Me.ComboBoxCliente.SelectedValue = Entidad.Codcliente
        'Me.TextBoxDocumento.Text = Entidad.CuitCliente
        'Me.TextBoxNombre.Text = Entidad.NombreCliente
        'Me.TextBoxDomicilio.Text = Entidad.DomicilioCliente
        'Me.TextBoxTelefono.Text = Entidad.TelefonoCliente
        'Me.DTPFecha.Value = Entidad.Fecha
        ''Me.TextBoxNumero.Text = Format(CInt(Entidad.Numero), "00000000")
        'Me.TextBoxRemito.Text = Format(CInt(Entidad.Secuencia), "00")

        '_Lista = _repositorio.GetAllSemanaProducto(Entidad.Id)

        'For Each list As Entidades.Moldeodet In _Lista
        '    dblTotal = dblTotal + list.Subtotal
        'Next

        'Me.LabelTotal.Text = "Importe total del comprobante >> " & dblTotal.ToString("$ #,##0.00") & " <<"

        'Me.TextBoxUnidad.Text = ""
        'Me.TextBoxKxU.Text = "0.00"
        'Me.TextBoxKgs.Text = "0.00"
        'Me.TextBoxCantidad.Text = "0.00"
        'Me.TextBoxPrecio.Text = "0.00"

        'Me.ComboBoxNroOrden.SelectedItem = -1

        ''Me.TextBoxOrdenCompra.Text = "00000000"
        ''Me.TextBoxSecuencia.Text = "00"
        'Me.TextBoxSubtotalArticulo.Text = "0.00"

        'PoblarGrilla()

        'InicializarComboArticulo()

        'Me.ComboBoxArticulos.FocoDetalle()


        'Else 'nuevo registro, valores por defecto
        'blnModifica = False
        'LimpiarFormulario()
        'End If





        'Me.DTPFecha.Value = Now

        'Me.GroupBoxDatosArticulos.Enabled = False
        'Me.TextBoxPedido.Text = "00000000"
    End Sub

    Private Sub CustomGotFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = Color.LightGreen

        If sender.GetType = GetType(TextBox) Then
            DirectCast(sender, TextBox).Font = New Font(DirectCast(sender, TextBox).Font, FontStyle.Bold)
        ElseIf sender.GetType = GetType(NumericUpDown) Then
            DirectCast(sender, NumericUpDown).Font = New Font(DirectCast(sender, NumericUpDown).Font, FontStyle.Bold)
            DirectCast(sender, NumericUpDown).Select(0, DirectCast(sender, NumericUpDown).Text.Length)
        End If

    End Sub

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        For Each c As Control In Me.GroupBoxDatosCliente.Controls
            Select Case c.GetType
                Case GetType(TextBox), GetType(CheckBox), GetType(ComboBox), GetType(NumericUpDown)
                    AddHandler c.GotFocus, AddressOf CustomGotFocus
                    AddHandler c.LostFocus, AddressOf CustomLostFocus
            End Select
        Next

        For Each c As Control In Me.GroupBoxDatosArticulos.Controls
            Select Case c.GetType
                Case GetType(TextBox), GetType(CheckBox), GetType(ComboBox), GetType(NumericUpDown)
                    AddHandler c.GotFocus, AddressOf CustomGotFocus
                    AddHandler c.LostFocus, AddressOf CustomLostFocus
            End Select
        Next

        For Each c As Control In Me.GroupBoxDatosTransporte.Controls
            Select Case c.GetType
                Case GetType(TextBox), GetType(CheckBox), GetType(ComboBox), GetType(NumericUpDown)
                    AddHandler c.GotFocus, AddressOf CustomGotFocus
                    AddHandler c.LostFocus, AddressOf CustomLostFocus
            End Select
        Next

        AddHandler Me.KeyDown, AddressOf FormularioKeyDown

    End Sub

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F12 : AutorizandoCbte()
            Case Keys.Escape : Cancelar()
            Case Keys.Delete : EliminarGrilla()
            Case Keys.Return : SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub CustomLostFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = SystemColors.Window

        If sender.GetType = GetType(TextBox) Then
            DirectCast(sender, TextBox).Font = New Font(DirectCast(sender, TextBox).Font, FontStyle.Regular)
        ElseIf sender.GetType = GetType(NumericUpDown) Then
            DirectCast(sender, NumericUpDown).Font = New Font(DirectCast(sender, NumericUpDown).Font, FontStyle.Regular)
        End If

    End Sub

    Private Sub FormCbteOrdenCompra_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InicializarFormulario()
    End Sub

    Private Sub InicializarComboCliente()

        With Me.ComboBoxCliente
            .ValueMember = "Id"
            .DisplayMember = "NombreyCodigo"
            .DataSource = _repositorioCli.GetAll()
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            '.DropDownStyle = ComboBoxStyle.DropDownList
            .FormularioDeAlta = FormCliente
            .Inicializar()
            .SelectedIndex = -1
        End With

        Me.ComboBoxDomicilios.DataSource = Nothing

    End Sub
    Private Sub InicializarComboVendedor()

        With Me.ComboBoxVendedores
            .ValueMember = "Id"
            .DisplayMember = "NombreyCodigo"
            .DataSource = _repositorioVen.GetAll()
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            '.DropDownStyle = ComboBoxStyle.DropDownList
            '.FormularioDeAlta = FormCliente
            .Inicializar()
            .SelectedIndex = -1
        End With

    End Sub
    Private Sub InicializarComboTransporte()

        With Me.ComboBoxTranportista
            .ValueMember = "Id"
            .DisplayMember = "NombreyCodigo"
            .DataSource = _repositorioTra.GetAll()
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            '.DropDownStyle = ComboBoxStyle.DropDownList
            '.FormularioDeAlta = FormCliente
            .Inicializar()
            If .Items.Count > 0 Then
                .SelectedIndex = 0
                CargarDatosTransporte()
            Else
                .SelectedIndex = -1
            End If
        End With

    End Sub
    Private Sub InicializarComboArticulo()

        With Me.ComboBoxArticulos
            .ValueMember = "Id"
            .DisplayMember = "CodigoyNombre"
            If Me.ComboBoxCliente.SelectedIndex >= 0 Then
                .DataSource = _repositorioArt.GetAll '(DirectCast(ComboBoxCliente.SelectedItem, Entidades.Cliente).Codigo, , True)
            End If
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            .SelectedIndex = -1
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

        With Me.ComboBoxDocumentoTransporte
            .ValueMember = "Codigo"
            .DisplayMember = "Descripcion"
            .DataSource = repositorio.GetAll
            .SelectedIndex = -1
        End With
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

    Private Sub CargaDatosCliente()
        Dim e As New Entidades.Cliente
        Dim cbtetipo As UInt32 = 0

        e = DirectCast(Me.ComboBoxCliente.SelectedItem, Entidades.Cliente)

        If e IsNot Nothing Then
            blnModifica = False
            Me.ComboBoxVendedores.SelectedValue = e.Vendedor
            Me.TextBoxDocumento.Text = e.Documento
            Me.ComboBoxDocumento.SelectedValue = e.Tipodocumento
            Me.ComboBoxDomicilios.DataSource = e.Domicilio.Split(New String() {Environment.NewLine},
                                       StringSplitOptions.None)
            Me.TextBoxDomicilio.Text = e.Domicilio.Split(New String() {Environment.NewLine},
                                       StringSplitOptions.None)(0)
            Me.TextBoxNombre.Text = e.Nombre
            Me.TextBoxTelefono.Text = e.Telefono
            Me.TextBoxLocalidad.Text = "[" & e.CodigoPostal & "] " & e.NombreLocalidad
        Else
            Me.ComboBoxVendedores.SelectedIndex = -1
            Me.TextBoxDocumento.Text = ""
            Me.ComboBoxDocumento.SelectedIndex = -1
            Me.ComboBoxDomicilios.SelectedIndex = -1
            Me.TextBoxDomicilio.Text = ""
            Me.TextBoxNombre.Text = ""
            Me.TextBoxTelefono.Text = ""
            Me.TextBoxLocalidad.Text = ""
        End If

    End Sub

    Private Sub CargaDatosArticulo()
        Dim e As New Entidades.Articulo
        Dim cbtetipo As UInt32 = 0

        If ComboBoxArticulos.SelectedItem Is Nothing Then Exit Sub

        e = DirectCast(Me.ComboBoxArticulos.SelectedItem, Entidades.Articulo)

        If e IsNot Nothing Then

            If e.Codigo = "999999999999999" Then
                Me.TextBoxPrecio.ReadOnly = False
            Else
                Me.TextBoxPrecio.ReadOnly = True
            End If

            'Me.TextBoxKgs.Text = "0.00"
            Me.TextBoxCantidad.Text = "0.00"

            Me.TextBoxUnidad.Text = e.SimboloUnidad
            Me.TextBoxKxU.Text = Format(CDbl(e.Pesoneto), "0.00")
            Me.TextBoxPrecio.Text = Format(CDbl(e.Preciodeventa), "0.00")

            'Lleno la Ayuda de las OC
            _ListaNroOrden = _repositorio.GetByNroOrden(DirectCast(ComboBoxCliente.SelectedItem, Entidades.Cliente).Codigo, DirectCast(Me.ComboBoxArticulos.SelectedItem, Entidades.Articulo).Codigo)
            InicializarComboOrdenCompra(True)

            'Lleno el Combo con la Cantidad
            _ListaNroOrden = _repositorio.GetByArticulosPendientes(DirectCast(ComboBoxCliente.SelectedItem, Entidades.Cliente).Codigo, DirectCast(Me.ComboBoxArticulos.SelectedItem, Entidades.Articulo).Codigo)
            For Each art In _ListaNroOrden
                Me.TextBoxCantidad.Text += art.Cantidad
            Next
            Me.TextBoxCantidad.Text = Format(Convert.ToDouble(Me.TextBoxCantidad.Text), "0.00")
            'Me.TextBoxKgs.Text = Format(e.Pesoneto * Val(Me.TextBoxCantidad.Text), "0.00")

            'Me.ComboBoxDomicilios.DataSource = e.Domicilio.Split(New String() {Environment.NewLine},
            '                           StringSplitOptions.None)
            'Me.TextBoxDomicilio.Text = e.Domicilio.Split(New String() {Environment.NewLine},
            '                           StringSplitOptions.None)(0)
            'Me.TextBoxNombre.Text = e.Nombre
            'Me.TextBoxTelefono.Text = e.Telefono

        Else
            Me.TextBoxPrecio.ReadOnly = True

            Me.TextBoxUnidad.Text = ""
            Me.TextBoxKxU.Text = "0.00"
            'Me.TextBoxKgs.Text = "0.00"
            Me.TextBoxCantidad.Text = "0.00"
            Me.TextBoxPrecio.Text = "0.00"
            Me.ComboBoxNroOrden.SelectedItem = -1
            'Me.TextBoxOrdenCompra.Text = "00000000"
            'Me.TextBoxSecuencia.Text = "00"
            Me.TextBoxSubtotalArticulo.Text = "0.00"

        End If

    End Sub

    Private Sub CargarDatosTransporte()
        Dim e As New Entidades.Transporte
        Dim cbtetipo As UInt32 = 0

        e = DirectCast(Me.ComboBoxTranportista.SelectedItem, Entidades.Transporte)

        If e IsNot Nothing Then
            Me.TextBoxDocumentoTransporte.Text = e.Documento
            Me.ComboBoxDocumentoTransporte.SelectedValue = e.Tipodocumento
            Me.TextBoxDomicilioTransporte.Text = e.Domicilio.Split(New String() {Environment.NewLine},
                                       StringSplitOptions.None)(0)
            If ComboBoxCliente.SelectedIndex >= 0 Then Me.TextBoxLugarEntrega.Text = DirectCast(Me.ComboBoxCliente.SelectedItem, Entidades.Cliente).Domicilio & " - (" & DirectCast(Me.ComboBoxCliente.SelectedItem, Entidades.Cliente).Localidad & ") " & DirectCast(Me.ComboBoxCliente.SelectedItem, Entidades.Cliente).NombreLocalidad
            'Me.TextBoxValorDeclarado.Text = "0.00"
            'Me.TextBoxBultos.Text = "0"
        Else
            Me.TextBoxDocumentoTransporte.Text = ""
            Me.ComboBoxDocumentoTransporte.SelectedIndex = -1
            Me.TextBoxDomicilioTransporte.Text = ""
            Me.TextBoxLugarEntrega.Text = ""
            'Me.TextBoxValorDeclarado.Text = "0.00"
            'Me.TextBoxBultos.Text = "0"
        End If

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
    Private Sub LimpiarFormulario()
        '_Lista = New List(Of Entidades.Moldeodet)
        _Lista.Clear()
        _ListaNroOrden.Clear()
        _ListaRemito.Clear()
        'ConfigurarGrilla()
        dblTotal = 0
        dblCantTotal = 0
        dblUnidad = 0
        dblKgs = 0
        blnModifica = True

        strOrdenCompra = ""
        strOrdenCompra1 = ""
        strOrdenCompra2 = ""
        strOrdenCompra3 = ""
        strOrdenCompra4 = ""
        strOrdenCompra5 = ""

        Me.LabelTotal.Text = "0.00"
        Me.TextBoxBultos.Text = "0.00"
        Me.TextBoxValorDeclarado.Text = "0.00"
        Me.LabelTotal.Text = "0.00"
        Me.ComboBoxCliente.SelectedIndex = -1

        Me.ComboBoxDocumento.SelectedIndex = -1

        Me.TextBoxNombre.Text = ""

        Me.ComboBoxDomicilios.SelectedIndex = -1

        Me.TextBoxTelefono.Text = ""

        Me.TextBoxLocalidad.Text = ""

        Me.TextBoxDocumento.Text = ""

        Me.TextBoxDomicilio.Text = ""

        Me.DTPFecha.Value = Now

        Me.ComboBoxArticulos.SelectedIndex = -1

        Me.ComboBoxTranportista.SelectedIndex = -1
        Me.ComboBoxDocumentoTransporte.SelectedIndex = -1
        Me.TextBoxDocumentoTransporte.Text = ""
        Me.TextBoxDomicilioTransporte.Text = ""
        Me.TextBoxLugarEntrega.Text = ""
        Me.TextBoxValorDeclarado.Text = "0.00"
        Me.TextBoxBultos.Text = "0.00"

        Me.GroupBoxDatosCliente.Enabled = True

        Me.GroupBoxDatosArticulos.Enabled = False

        'Me.TextBoxNumero.Text = "00000000"
        ActualizaNumeracion()

        Me.TextBoxUnidad.Text = ""
        Me.TextBoxKxU.Text = "0.00"
        'Me.TextBoxKgs.Text = "0.00"
        Me.TextBoxCantidad.Text = "0.00"
        Me.TextBoxPrecio.Text = "0.00"
        _ListaNroOrden.Clear()
        InicializarComboOrdenCompra(False)
        'Me.TextBoxOrdenCompra.Text = "00000000"
        'Me.TextBoxSecuencia.Text = "00"
        Me.TextBoxSubtotalArticulo.Text = "0.00"

        'Me.FOLVArticulos.Clear()
        PoblarGrilla()
        Me.ComboBoxCliente.FocoDetalle()

        Application.DoEvents()

    End Sub
    Private Sub ConfigurarGrilla()
        CrearColumnas()

        With FOLVArticulos
            .FullRowSelect = True
            .UseFiltering = True
            .CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick
            .CellEditEnterChangesRows = False 'True
            .ClearObjects()
        End With

    End Sub
    Private Sub PoblarGrilla()
        Me.FOLVArticulos.ModelFilter = Nothing
        Me.FOLVArticulos.Objects = _Lista
        Me.FOLVArticulos.AutoResizeColumns()
    End Sub
    Private Sub CrearColumnas()

        Dim c As BrightIdeasSoftware.OLVColumn

        With FOLVArticulos

            .Columns.Clear()

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Cantidad"
            c.AspectName = "Cantidad"
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Right
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("#,##0.00#")
                                        End Function
            'c.AspectToStringFormat = "{0.00}"
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = False
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Articulo"
            c.AspectName = "Codigo"
            c.MinimumWidth = 100
            c.MaximumWidth = 100
            c.AutoResize(ColumnHeaderAutoResizeStyle.None)
            c.FillsFreeSpace = True
            c.IsEditable = False
            .Columns.Add(c)

            'c = New BrightIdeasSoftware.OLVColumn
            'c.Text = "Rev"
            'c.AspectName = "Rev"
            'c.MinimumWidth = 34
            'c.MaximumWidth = 34
            'c.AutoResize(ColumnHeaderAutoResizeStyle.None)
            'c.FillsFreeSpace = True
            'c.IsEditable = False
            '.Columns.Add(c)


            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Descripción"
            c.AspectName = "Descripcion"
            c.MinimumWidth = 305
            c.MaximumWidth = 305
            c.AutoResize(ColumnHeaderAutoResizeStyle.None)
            c.FillsFreeSpace = True
            c.IsEditable = True
            .Columns.Add(c)

            'c = New BrightIdeasSoftware.OLVColumn
            'c.Text = "Unidad"
            'c.AspectName = "Rev"
            'c.MinimumWidth = 34
            'c.MaximumWidth = 34
            'c.AutoResize(ColumnHeaderAutoResizeStyle.None)
            'c.FillsFreeSpace = True
            'c.IsEditable = False
            '.Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "KxU"
            c.AspectName = "Kgsxunidad"
            c.MinimumWidth = 60
            c.TextAlign = HorizontalAlignment.Right
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("#,##0.00#")
                                        End Function
            'c.AspectToStringFormat = "{0.00}"
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = False
            .Columns.Add(c)

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
            c.Text = "Numero"
            c.AspectName = "Numero"
            c.MinimumWidth = 80
            c.MaximumWidth = 80
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.None)
            c.FillsFreeSpace = True
            c.IsEditable = False
            .Columns.Add(c)

            'c = New BrightIdeasSoftware.OLVColumn
            'c.Text = "Sec."
            'c.AspectName = "Secuencia"
            'c.MinimumWidth = 40
            'c.MaximumWidth = 40
            'c.TextAlign = HorizontalAlignment.Right
            'c.AutoResize(ColumnHeaderAutoResizeStyle.None)
            'c.FillsFreeSpace = True
            'c.IsEditable = False
            '.Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Precio"
            c.AspectName = "Importe"
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Right
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("#,##0.00#")
                                        End Function
            'c.AspectToStringFormat = "{0.00}"
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = False
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Subtotal"
            c.AspectName = "Subtotal2"
            c.MinimumWidth = 110
            c.TextAlign = HorizontalAlignment.Right
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("#,##0.00#")
                                        End Function
            'c.AspectToStringFormat = "{0.00}"
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = False
            .Columns.Add(c)

        End With
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

    Private Sub FOLVArticulos_FormatCell(ByVal sender As Object, ByVal e As BrightIdeasSoftware.FormatCellEventArgs) Handles FOLVArticulos.FormatCell
        Select Case e.Column.AspectName
            Case "SubtotalFinal", "Codigo", "Cantidad"
                e.SubItem.Font = New System.Drawing.Font(e.SubItem.Font.Name, e.SubItem.Font.Size, FontStyle.Bold)
        End Select
    End Sub

    Private Sub CargaGrilla()

        Dim art As New Entidades.Articulo

        If ComboBoxArticulos.SelectedItem Is Nothing Then
            MessageBox.Show("Debe Ingresar Un Artículo Válido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ComboBoxArticulos.Focus()
        ElseIf Valida(DirectCast(ComboBoxArticulos.SelectedItem, Entidades.Articulo).Codigo) = 1 Then
            MessageBox.Show("No puede cargar más de una vez un artículo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ComboBoxArticulos.Focus()
        ElseIf Val(Me.TextBoxCantidad.Text) <= 0 Then
            MessageBox.Show("Debe ingresar una Cantidad válida", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBoxCantidad.Focus()
        Else

            art = DirectCast(Me.ComboBoxArticulos.SelectedItem, Entidades.Articulo)

            EntidadDet = New Entidades.CbteArticulo

            EntidadDet.Codigo = art.Codigo
            EntidadDet.Codcliente = DirectCast(ComboBoxCliente.SelectedItem, Entidades.Cliente).Codigo
            EntidadDet.Descripcion = art.Nombre
            EntidadDet.Cantidad = CDbl(Me.TextBoxCantidad.Text)
            EntidadDet.Importe = CDbl(Me.TextBoxPrecio.Text)
            EntidadDet.Descuento = art.Descuento
            EntidadDet.ImpIntTasaNominal = art.Impinttasanominal
            EntidadDet.ImpInterno = art.Impuestointerno
            EntidadDet.AlicuotaCodigo = art.Alicuotaiva
            EntidadDet.Alicuota = art.Alicuota
            EntidadDet.Unidad = art.SimboloUnidad
            EntidadDet.Listadeprecio = 1

            EntidadDet.Comision = DirectCast(Me.ComboBoxVendedores.SelectedItem, Entidades.Vendedor).Comision

            EntidadDet.Comision2 = 0
            EntidadDet.Comision3 = 0
            'EntidadDet.Rev = art.Rev
            'EntidadDet.Kgs = CDbl(Me.TextBoxKgs.Text)
            EntidadDet.Kgsxunidad = CDbl(Me.TextBoxKxU.Text)
            EntidadDet.Subtotal2 = CDbl(Me.TextBoxSubtotalArticulo.Text)
            For Each Moldeo In _repositorio.GetByNumero(Me.ComboBoxNroOrden.SelectedValue)
                EntidadDet.Numero = Moldeo.Numero
                'EntidadDet.Secuencia = Moldeo.Secuencia
            Next

            'EntidadDet.Articulo = art.Plu
            'EntidadDet.Rev = art.Rev
            'EntidadDet.Precio = CDbl(Me.TextBoxPrecio.Text)
            'EntidadDet.Cantidad = CDbl(Me.TextBoxCantidad.Text)
            'EntidadDet.Cantsaldo = CDbl(Me.TextBoxCantidad.Text)
            'EntidadDet.Cantacum = 0
            'EntidadDet.Descarte = 0
            'EntidadDet.Despacho = 0
            'EntidadDet.Kgsxunidad = CDbl(Me.TextBoxKxU.Text)
            'EntidadDet.Kgs = CDbl(Me.TextBoxKgs.Text)
            'EntidadDet.Codunidad = DirectCast(ComboBoxArticulos.SelectedItem, Entidades.Articulo).Codunidad
            'EntidadDet.Expedicion = 0
            'EntidadDet.Cbtevta = 0
            'EntidadDet.NombreArticulo = DirectCast(ComboBoxArticulos.SelectedItem, Entidades.Articulo).Nombre
            'EntidadDet.Subtotal = CDbl(Me.TextBoxSubtotalArticulo.Text)

            dblTotal = dblTotal + CDbl(Me.TextBoxSubtotalArticulo.Text)
            dblCantTotal = dblCantTotal + CDbl(Me.TextBoxCantidad.Text)

            'If Me.TextBoxUnidad.Text = "KG" Then
            '    dblKgs = dblKgs + CDbl(Me.TextBoxKgs.Text)
            'Else
            dblUnidad = dblUnidad + CDbl(Me.TextBoxCantidad.Text)
            'End If

            If Me.ComboBoxNroOrden.Text <> "0 - 0" Then
                If Me.ComboBoxNroOrden.Text <> strOrdenCompra1 And Me.ComboBoxNroOrden.Text <> strOrdenCompra2 And Me.ComboBoxNroOrden.Text <> strOrdenCompra3 And Me.ComboBoxNroOrden.Text <> strOrdenCompra4 And Me.ComboBoxNroOrden.Text <> strOrdenCompra5 Then
                    If strOrdenCompra1 = "" Then
                        strOrdenCompra = Me.ComboBoxNroOrden.Text
                        strOrdenCompra1 = Me.ComboBoxNroOrden.Text
                    ElseIf strOrdenCompra2 = "" Then
                        strOrdenCompra = strOrdenCompra & " / " & Me.ComboBoxNroOrden.Text
                        strOrdenCompra2 = Me.ComboBoxNroOrden.Text
                    ElseIf strOrdenCompra3 = "" Then
                        strOrdenCompra = strOrdenCompra & " / " & Me.ComboBoxNroOrden.Text
                        strOrdenCompra3 = Me.ComboBoxNroOrden.Text
                    ElseIf strOrdenCompra4 = "" Then
                        strOrdenCompra = strOrdenCompra & " / " & Me.ComboBoxNroOrden.Text
                        strOrdenCompra4 = Me.ComboBoxNroOrden.Text
                    ElseIf strOrdenCompra5 = "" Then
                        strOrdenCompra = strOrdenCompra & " / " & Me.ComboBoxNroOrden.Text
                        strOrdenCompra5 = Me.ComboBoxNroOrden.Text
                    End If
                End If
            End If

            _Lista.Add(EntidadDet)

            Me.ComboBoxArticulos.SelectedIndex = -1
            'Me.numCantidad.Value = 1
            Me.ComboBoxArticulos.Focus()

            PoblarGrilla()

            'dblTotal = dblTotal + CDbl(Me.TextBoxSubtotalArticulo.Text)

            Me.LabelTotal.Text = "Importe total del comprobante >> " & dblTotal.ToString("$ #,##0.00") & " <<"

            Me.TextBoxValorDeclarado.Text = Format(dblTotal, "0.00")

            Me.TextBoxBultos.Text = Format(dblCantTotal, "0.00")

        End If

    End Sub
    'Private Sub AutorizaOrdenCompra()
    '    Dim mlngCopias As Integer
    '    Try
    '        If FOLVArticulos.Items.Count = 0 Then
    '            MessageBox.Show("No cargó ningun artículo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            Me.ComboBoxArticulos.Focus()

    '        Else

    '            mlngCopias = -1
    '            frmImpresion.mstrConcepto = "CARGA DE ORDEN DE COMPRA"
    '            frmImpresion.mlngNumero = Convert.ToInt32(Me.TextBoxNumero.Text)
    '            If frmImpresion.ShowDialog(Me) = Windows.Forms.DialogResult.Cancel Then
    '                Exit Sub
    '            End If

    '            mlngCopias = frmImpresion.mlngCopias

    '            If Entidad Is Nothing Then
    '                Entidad = New Entidades.Moldeocab
    '            End If

    '            Entidad.Codcliente = DirectCast(ComboBoxCliente.SelectedItem, Entidades.Cliente).Codigo
    '            Entidad.Numero = CInt(Me.TextBoxNumero.Text)
    '            Entidad.Secuencia = CInt(Me.TextBoxRemito.Text)
    '            Entidad.Fecha = Me.DTPFecha.Value
    '            Entidad.Observacion = Me.TextBoxObservacion.Text
    '            Entidad.Moldeodet = _Lista

    '            _repositorio.Save(Entidad)

    '            If _repositorio.HasError Then

    '                MessageBox.Show(_repositorio.mensajes.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

    '            Else

    '                MessageBox.Show("La operación ha finalizado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

    '                If mlngCopias > 0 Then
    '                    Call EmisionCbteOrdenCompra(Entidad.Id, False, mlngCopias)
    '                    'Reporte(mlngCopias)
    '                End If

    '                Me.Close()

    '            End If
    '        End If


    '    Catch ex As Exception
    '        MessageBox.Show("Se produjo el siguiente error: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub
    'Private Sub Reporte(ByVal id As UInt32, Optional ByVal copies As Short = -1)

    '    Try

    '        Dim r As New GeneradorReportes.Reporte

    '        r.Nombre = Me.Text

    '        r.SourceFile = My.Settings.RutaReportes & "\infRemito.rdl"

    '        r.Parametros.Add(New GeneradorReportes.Parametro("fecha", Format(Me.DTPFecha.Value, "dd/MM/yyyy")))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("cbteId", id))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("clienteNombre", Me.TextBoxNombre.Text))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("clienteDomicilio", Me.TextBoxDomicilio.Text))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("clienteCodpostal", DirectCast(ComboBoxCliente.SelectedItem, Entidades.Cliente).CodigoPostal))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("clienteLocalidad", DirectCast(ComboBoxCliente.SelectedItem, Entidades.Cliente).NombreLocalidad))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("clienteIva", DirectCast(ComboBoxCliente.SelectedItem, Entidades.Cliente).DescripcionIva))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("clienteCuit", Me.TextBoxDocumento.Text))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("OrdenCompra", strOrdenCompra))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("xUnidad", dblUnidad.ToString("0.00")))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("xKgs", dblKgs.ToString("0.00")))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("Bultos", Me.TextBoxBultos.Text))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("valorDeclarado", Me.TextBoxValorDeclarado.Text))
    '        If Me.RadioButtonDestino.Checked = True Then
    '            r.Parametros.Add(New GeneradorReportes.Parametro("tipoEnvio", "FLETE A PAGAR A DESTINO"))
    '        ElseIf Me.RadioButtonNuestroCargo.Checked = True Then
    '            r.Parametros.Add(New GeneradorReportes.Parametro("tipoEnvio", "FLETE A NUESTRO CARGO"))
    '        Else
    '            r.Parametros.Add(New GeneradorReportes.Parametro("tipoEnvio", "RETIRA EN PLANTA"))
    '        End If
    '        r.Parametros.Add(New GeneradorReportes.Parametro("transporteNombre", DirectCast(ComboBoxTranportista.SelectedItem, Entidades.Transporte).Nombre))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("transporteDireccion", Me.TextBoxDomicilioTransporte.Text))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("transporteCuit", Me.TextBoxDocumentoTransporte.Text))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("lugarEntrega", Me.TextBoxLugarEntrega.Text))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("control", Me.TextBoxRemito.Text))

    '        r.PrintReport(copies)

    '        'Me.Close()

    '    Catch ex As Exception
    '        MessageBox.Show("Se produjo el siguiente error: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub
    Private Sub EliminarGrilla()
        If Me.FOLVArticulos.SelectedIndex < 0 Then
            MessageBox.Show("No Seleccionó ningún Registro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else

            dblTotal = dblTotal - CDbl(_Lista.Item(Me.FOLVArticulos.SelectedIndex).Subtotal2)
            dblCantTotal = dblCantTotal - CDbl(_Lista.Item(Me.FOLVArticulos.SelectedIndex).Cantidad)

            If _Lista.Item(Me.FOLVArticulos.SelectedIndex).Unidad = "KG" Then
                dblKgs = dblKgs - -CDbl(_Lista.Item(Me.FOLVArticulos.SelectedIndex).Kgs)
            Else
                dblUnidad = dblUnidad - -CDbl(_Lista.Item(Me.FOLVArticulos.SelectedIndex).Cantidad)
            End If


            Me.LabelTotal.Text = "Importe total del comprobante >> " & dblTotal.ToString("$ #,##0.00") & " <<"

            Me.TextBoxValorDeclarado.Text = Format(dblTotal, "0.00")

            Me.TextBoxBultos.Text = Format(dblCantTotal, "0.00")

            _Lista.Remove(_Lista.Item(Me.FOLVArticulos.SelectedIndex))

            PoblarGrilla()
            Me.ComboBoxArticulos.FocoDetalle()
        End If
    End Sub
    Private Function Valida(ByRef Articulo As String) As Integer
        Dim a = 0
        For i As Integer = 0 To Me.FOLVArticulos.Items.Count - 1 Step 1
            If DirectCast(Me.FOLVArticulos.Objects(i), Entidades.CbteArticulo).Codigo = Articulo Then
                a = 1
                Exit For
            End If

        Next

        Return a
    End Function

    Private Function UltimoCbteAutorizado() As Int32

        Dim ret As Int32 = 0
        Dim reponumeracion As New CapaLogica.CbtenumeracionCLog
        Dim ptovta As UInt32
        Dim cbtetipo As UInt32
        Dim numeracion As Entidades.Cbtenumeracion

        Try

            ptovta = 1
            cbtetipo = REMITO

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

    Private Sub ActualizaNumeracion()

        Dim cbte As Int32

        cbte = UltimoCbteAutorizado()

        If cbte >= 0 Then
            Me.TextBoxRemito.Text = Format(cbte + 1, "00000000")
        End If

    End Sub
    Private Function CrearComprobante() As Entidades.CbteCabecera
        Dim cbte As New Entidades.CbteCabecera

        Try

            ActualizaNumeracion()

            EntidadRemito = New Entidades.Remito

            EntidadRemito.Fecha = Me.DTPFecha.Value
            EntidadRemito.Clientenombre = DirectCast(ComboBoxCliente.SelectedItem, Entidades.Cliente).Nombre
            EntidadRemito.Clientedomicilio = DirectCast(ComboBoxCliente.SelectedItem, Entidades.Cliente).Domicilio
            EntidadRemito.Clientecodpostal = DirectCast(ComboBoxCliente.SelectedItem, Entidades.Cliente).CodigoPostal
            EntidadRemito.Clientelocalidad = DirectCast(ComboBoxCliente.SelectedItem, Entidades.Cliente).NombreLocalidad
            EntidadRemito.Clienteiva = DirectCast(ComboBoxCliente.SelectedItem, Entidades.Cliente).DescripcionIva
            EntidadRemito.Clientecuit = DirectCast(ComboBoxCliente.SelectedItem, Entidades.Cliente).Documento
            EntidadRemito.Ordencompra = strOrdenCompra
            EntidadRemito.Unidad = dblUnidad.ToString("0.00")
            EntidadRemito.Kgs = dblKgs.ToString("0.00")
            EntidadRemito.Bultos = Me.TextBoxBultos.Text
            EntidadRemito.Valordeclarado = Me.TextBoxValorDeclarado.Text
            If Me.RadioButtonDestino.Checked = True Then
                EntidadRemito.Tipoenvio = "FLETE A PAGAR A DESTINO"
            ElseIf Me.RadioButtonNuestroCargo.Checked = True Then
                EntidadRemito.Tipoenvio = "FLETE A NUESTRO CARGO"
            Else
                EntidadRemito.Tipoenvio = "RETIRA EN PLANTA"
            End If
            EntidadRemito.Transportenombre = DirectCast(ComboBoxTranportista.SelectedItem, Entidades.Transporte).Nombre
            EntidadRemito.Transportedireccion = Me.TextBoxDomicilioTransporte.Text
            EntidadRemito.Transportecuit = Me.TextBoxDocumentoTransporte.Text
            EntidadRemito.Lugarentrega = Me.TextBoxLugarEntrega.Text
            EntidadRemito.Control = Me.TextBoxRemito.Text

            _ListaRemito.Add(EntidadRemito)

            With cbte

                .Concepto = 1 '"Productos" 'Convert.ToUInt32(Me.ComboBoxConceptos.SelectedValue)
                .Clienteid = Convert.ToUInt32(Me.ComboBoxCliente.SelectedValue)
                .Razonsocial = Me.TextBoxNombre.Text
                .Domicilio = Me.TextBoxDomicilio.Text
                .Nroremito = "" 'Me.TextBoxRemito.Text
                .Documentotipo = Convert.ToUInt32(Me.ComboBoxDocumento.SelectedValue)
                .Documentonro = Convert.ToUInt64(Me.TextBoxDocumento.Text)
                .Cbtetipo = REMITO 'tipoCbte.Codigo
                .Cbteptovta = 1
                .Cbtenumero = Convert.ToUInt32(Me.TextBoxRemito.Text)
                .Cbtefecha = Me.DTPFecha.Value.ToString("yyyyMMdd")
                .Formadepago = 2 'Convert.ToUInt32(Me.ComboBoxFormaPago.SelectedValue)
                .Importetotal = dblTotal
                .Importetotalconceptos = 0 '_nogravado
                .Importeneto = dblTotal
                .Importeopexentas = 0 ' _exento
                .Importeiva = 0 '_iva
                .Importetributos = 0 ' _otrostributos
                .Fechaserviciodesde = Format(Now, "yyyyMMdd")
                .Fechaserviciohasta = Format(Now, "yyyyMMdd") ' Me.DateTimePickerPeriodoHasta.Value.ToString("yyyyMMdd")
                .Fechavtopago = Me.DTPFecha.Value.ToString("yyyyMMdd")
                .Monedaid = "PES"
                .Monedactz = 1
                .Cae = ""
                .Fechavtocae = ""
                .Observaciones = "" ' Me.CtlCbteDetalle.Observaciones
                .Tiporesponsable = Convert.ToUInt32(DirectCast(Me.ComboBoxCliente.SelectedItem, Entidades.Cliente).Tiporesponsable) 'Me.ComboBoxResponsabilidadIVA.SelectedValue)
                .Cuitemisor = 0
                .Usuario = gUsuario.Id

                .Vendedor = Convert.ToUInt32(Me.ComboBoxVendedores.SelectedValue)
                .Sucursal = My.Settings.CodigoSucursal
                .Descuento = 0 'Convert.ToDouble(Me.TextBoxDescuentoGral.Text)
                .Letra = "R" 'tipoCbte.Letra
                .Denominacion = "REMITO" 'tipoCbte.Denominacion
                .Tipo = "D" 'tipoCbte.Tipo


                .ObservacionesExtra = "" ' Me.CtlCbteDetalle.Observaciones

                .CbteArticulos = _Lista

                .Remito = _ListaRemito

            End With

            Return cbte

        Catch ex As Exception

            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return Nothing

        End Try
    End Function
    Private Sub AutorizandoCbte()

        ActualizaNumeracion()

        If FOLVArticulos.Items.Count = 0 Then
            MessageBox.Show("No cargó ningun artículo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.ComboBoxArticulos.Focus()
        ElseIf DirectCast(Me.ComboBoxTranportista.SelectedItem, Entidades.Transporte) Is Nothing Then
            MessageBox.Show("Debe seleccionar un transporte", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.ComboBoxTranportista.Focus()
        Else

            Dim cbte As Entidades.CbteCabecera = CrearComprobante()

            If cbte IsNot Nothing Then
                AutorizarCbte(cbte)
            End If

        End If

    End Sub
    Private Sub AutorizarCbte(ByVal cbte As Entidades.CbteCabecera)
        Dim mlngCopias As Integer
        'strOrdenCompra = ""

        mlngCopias = -1
        frmImpresion.mstrConcepto = "CARGA DE REMITO"
        frmImpresion.mlngNumero = Convert.ToInt32(Me.TextBoxRemito.Text)
        If frmImpresion.ShowDialog(Me) = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        mlngCopias = frmImpresion.mlngCopias

        Try
            'envio los nuevos datos al repositor para actualizar
            _repositorioCbte.Save(cbte)

            If _repositorioCbte.HasError Then

                MessageBox.Show(_repositorioCbte.mensajes.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                If mlngCopias > 0 Then
                    EmisionCbteRemito(cbte.Id, mlngCopias, False)
                    'Reporte(cbte.Id, mlngCopias)
                End If

                MessageBox.Show("La carga del remito ha finalizado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                LimpiarFormulario()


            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub ComboBoxDomicilios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxDomicilios.SelectedIndexChanged
        Me.TextBoxDomicilio.Text = Me.ComboBoxDomicilios.Text
    End Sub

    Private Sub ComboBoxCliente_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBoxCliente.KeyUp

    End Sub

    Private Sub ComboBoxCliente_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxCliente.SelectedIndexChanged
        CargaDatosCliente()
        'InicializarComboArticulo()
    End Sub




    Private Sub TextBoxKxU_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxKgs_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxCantidad.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxPrecio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxPrecio.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxSubtotalArticulo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxSubtotalArticulo.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub

    'Private Sub TextBoxKgs_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Me.TextBoxKgs.Text = "" Then
    '        Me.TextBoxKgs.Text = "0.00"
    '    Else
    '        Me.TextBoxKgs.Text = Format(CDbl(Me.TextBoxKgs.Text), "0.00")
    '    End If

    '    If DirectCast(Me.ComboBoxArticulos.SelectedItem, Entidades.Articulo) IsNot Nothing And Me.TextBoxUnidad.Text = "KG" Then
    '        Me.TextBoxSubtotalArticulo.Text = Format(CDbl(Val(Me.TextBoxKgs.Text) * Val(Me.TextBoxPrecio.Text)), "0.00")
    '        'ElseIf DirectCast(Me.ComboBoxArticulos.SelectedItem, Entidades.Articulo) IsNot Nothing And Me.TextBoxUnidad.Text <> "Kg" Then
    '        If Val(Me.TextBoxKxU.Text) > 0 Then
    '            Me.TextBoxCantidad.Text = Format(CInt(CDbl(Val(Me.TextBoxKgs.Text) / Val(Me.TextBoxKxU.Text))), "0.00")
    '        End If
    '    End If
    'End Sub

    Private Sub TextBoxCantidad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxCantidad.LostFocus
        If Me.TextBoxCantidad.Text = "" Then
            Me.TextBoxCantidad.Text = "0.00"
        Else
            Me.TextBoxCantidad.Text = Format(CDbl(Me.TextBoxCantidad.Text), "0.00")
        End If

        'If DirectCast(Me.ComboBoxArticulos.SelectedItem, Entidades.Articulo) IsNot Nothing And Me.TextBoxUnidad.Text <> "KG" Then
        Me.TextBoxSubtotalArticulo.Text = Format(CDbl(Val(Me.TextBoxCantidad.Text) * Val(Me.TextBoxPrecio.Text)), "0.00")
        'ElseIf DirectCast(Me.ComboBoxArticulos.SelectedItem, Entidades.Articulo) IsNot Nothing And Me.TextBoxUnidad.Text = "KG" Then
        'If Val(Me.TextBoxKxU.Text) > 0 Then
        '    Me.TextBoxCantidad.Text = Format(CInt(CDbl(Val(Me.TextBoxKgs.Text) / Val(Me.TextBoxKxU.Text))), "0.00")
        'End If
        'If Val(Me.TextBoxKgs.Text) = 0 Then
        '    Me.TextBoxKgs.Text = Format(CInt(CDbl(Val(Me.TextBoxCantidad.Text) * Val(Me.TextBoxKxU.Text))), "0.00")
        '    '    Me.TextBoxSubtotalArticulo.Text = Format(CDbl(Val(Me.TextBoxKgs.Text) * Val(Me.TextBoxPrecio.Text)), "0.00")
        '    '    'Me.TextBoxSubtotalArticulo.Text = Format(CDbl(Val(Me.TextBoxCantidad.Text) * Val(Me.TextBoxPrecio.Text)), "0.00")
        '    'Else
        '    '    Me.TextBoxSubtotalArticulo.Text = Format(CDbl(Val(Me.TextBoxCantidad.Text) * Val(Me.TextBoxPrecio.Text) * Val(Me.TextBoxKxU.Text)), "0.00")
        'End If
        'Me.TextBoxSubtotalArticulo.Text = Format(CDbl(Val(Me.TextBoxKgs.Text) * Val(Me.TextBoxPrecio.Text)), "0.00")

        'End If

    End Sub

    Private Sub TextBoxPrecio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxPrecio.LostFocus
        If Me.TextBoxPrecio.Text = "" Then
            Me.TextBoxPrecio.Text = "0.00"
        Else
            Me.TextBoxPrecio.Text = Format(CDbl(Me.TextBoxPrecio.Text), "0.00")
        End If

        'If DirectCast(Me.ComboBoxArticulos.SelectedItem, Entidades.Articulo) IsNot Nothing And Me.TextBoxUnidad.Text = "KG" Then
        '    Me.TextBoxSubtotalArticulo.Text = Format(CDbl(Val(Me.TextBoxKgs.Text) * Val(Me.TextBoxPrecio.Text)), "0.00")
        'ElseIf DirectCast(Me.ComboBoxArticulos.SelectedItem, Entidades.Articulo) IsNot Nothing And Me.TextBoxUnidad.Text <> "Kg" Then
        Me.TextBoxSubtotalArticulo.Text = Format(CDbl(Val(Me.TextBoxCantidad.Text) * Val(Me.TextBoxPrecio.Text)), "0.00")
        'End If
    End Sub

    Private Sub TextBoxSubtotalArticulo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxSubtotalArticulo.LostFocus
        If Me.TextBoxSubtotalArticulo.Text = "" Then
            Me.TextBoxSubtotalArticulo.Text = "0.00"
        Else
            Me.TextBoxSubtotalArticulo.Text = Format(CDbl(Me.TextBoxSubtotalArticulo.Text), "0.00")
        End If
    End Sub

    Private Sub ToolStripButtonCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonCancelar.Click
        Cancelar()
    End Sub

    Private Sub ComboBoxArticulos_CodigoEncontrado() Handles ComboBoxArticulos.CodigoEncontrado
        CargaDatosArticulo()
    End Sub

    Private Sub ComboBoxArticulos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxArticulos.SelectedIndexChanged
        'CargaDatosArticulo()
    End Sub

    Private Sub TextBoxKxU_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxKxU.LostFocus
        If Me.TextBoxKxU.Text = "" Then
            Me.TextBoxKxU.Text = "0.00"
        Else
            Me.TextBoxKxU.Text = Format(CDbl(Me.TextBoxKxU.Text), "0.00")
        End If
    End Sub

    Private Sub BtnAgregarArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarArticulo.Click
        CargaGrilla()
    End Sub

    Private Sub ToolStripButtonAutorizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripButtonAutorizar.Click
        AutorizandoCbte()
    End Sub

    Private Sub ComboBoxTranportista_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxTranportista.SelectedIndexChanged
        CargarDatosTransporte()
    End Sub

    Private Sub TextBoxBultos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxBultos.KeyPress
        'If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
        '    e.Handled = True
        'End If
    End Sub

    Private Sub TextBoxValorDeclarado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxValorDeclarado.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxOrdenCompra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
    End Sub

    'Private Sub TextBoxOrdenCompra_LostFocus(sender As Object, e As System.EventArgs)
    '    If Me.TextBoxOrdenCompra.Text = "" Then
    '        Me.TextBoxOrdenCompra.Text = "00000000"
    '    Else
    '        Me.TextBoxOrdenCompra.Text = Format(CInt(Me.TextBoxOrdenCompra.Text), "00000000")
    '    End If
    'End Sub


    Private Sub TextBoxSecuencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
    End Sub

    'Private Sub TextBoxSecuencia_LostFocus(sender As Object, e As System.EventArgs)
    '    If Me.TextBoxSecuencia.Text = "" Then
    '        Me.TextBoxSecuencia.Text = "00"
    '    Else
    '        Me.TextBoxSecuencia.Text = Format(CInt(Me.TextBoxSecuencia.Text), "00")
    '    End If
    'End Sub

    Private Sub TextBoxRemito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxRemito.TextChanged

    End Sub

    Private Sub DTPFecha_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPFecha.LostFocus
        If DirectCast(Me.ComboBoxCliente.SelectedItem, Entidades.Cliente) IsNot Nothing And Val(Me.TextBoxRemito.Text) > 0 Then
            If MessageBox.Show("Confirma datos ingresados?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                Me.GroupBoxDatosCliente.Enabled = False
                Me.GroupBoxDatosArticulos.Enabled = True
                InicializarComboArticulo()
                Me.ComboBoxArticulos.FocoDetalle()
                'MsgBox("La operación ha sido cancelada por el usuario")
            End If
        End If
    End Sub

    Private Sub TextBoxKgs_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub TextBoxBultos_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBoxBultos.TextChanged

    End Sub

    Private Sub EmisionRemito(p1 As UInteger, mlngCopias As Integer)
        Throw New NotImplementedException
    End Sub

End Class