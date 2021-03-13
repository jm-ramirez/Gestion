Public Class lstPrimario
    Property mlngTipoListado As Listados

    'repositorios de tablas
    Private _repConcBanc As New CapaLogica.ConceptobancarioCLog
    Private _repZonas As New CapaLogica.ZonaCLog
    Private _repRubGcias As New CapaLogica.RubrogciaCLog
    Private _repFormasPago As New CapaLogica.FormadepagoCLog
    Private _repRubMaestroArt As New CapaLogica.RubromaestroCLog
    Private _repCategoArt As New CapaLogica.CategoriaCLog
    'Private _repMateriales As New CapaLogica.MaterialesCLog
    'Private _repMatCpra As New CapaLogica.MaterialcpraCLog
    'Private _repRubMatCpra As New CapaLogica.RubromaterialCLog
    Private _repProvincias As New CapaLogica.ProvinciasCLog
    Private _repCuentasFi As New CapaLogica.CuentabancariaCLog
    Private _repBancos As New CapaLogica.BancoCLog
    'Private _repGastosV As New CapaLogica.GastosvCLog
    'Private _repGastosF As New CapaLogica.GastosfCLog
    'Private _repImputa As New CapaLogica.ImputacionCLog
    'Private _repImputaEg As New CapaLogica.ImputacionegCLog
    Private _repVendedores As New CapaLogica.VendedorCLog
    Private _repTransportes As New CapaLogica.TransporteCLog
    Private _repProveedores As New CapaLogica.ProveedorCLog
    Private _repClientes As New CapaLogica.ClienteCLog

    Dim mstrTitulo As String
    Dim mstrReporte As String

    'inicializo formulario, limpieza o carga de valores
    Private Sub InicializarFormulario()

        'limpieza de controles
        For Each c As Control In Me.Controls
            Select Case c.GetType
                Case GetType(TextBox) : DirectCast(c, TextBox).Text = ""
                Case GetType(ComboBox) : DirectCast(c, ComboBox).SelectedIndex = -1
                Case GetType(CheckBox) : DirectCast(c, CheckBox).Checked = False
            End Select
        Next

        InicializarCombos()

        mstrTitulo = ""
        mstrReporte = ""
        Select Case mlngTipoListado
            Case Listados.CLIENTES
                mstrTitulo = "Clientes"
                mstrReporte = "lstClientes"
            Case Listados.PROVEEDORES
                mstrTitulo = "Proveedores"
                mstrReporte = "lstProveedores"
            Case Listados.TRANSPORTES
                mstrTitulo = "Transportes"
                mstrReporte = "lstTransportes"
            Case Listados.VENDEDORES
                mstrTitulo = "Vendedores"
                mstrReporte = "lstVendedores"
            Case Listados.CONCEPTOS_FINANCIEROS
                mstrTitulo = "Conceptos Financieros"
                mstrReporte = "lstconceptobancario"
            Case Listados.CUENTAS_FINANCIEROS
                mstrTitulo = "Cuentas Financieras"
                mstrReporte = "lstcuentabancaria"
            Case Listados.ZONAS
                mstrTitulo = "Zonas"
                mstrReporte = "lstZonas"
            Case Listados.BANCOS
                mstrTitulo = "Bancos"
                mstrReporte = "lstBancos"
            Case Listados.CATEGORIAS_ART
                mstrTitulo = "Categorías de Artículos"
                mstrReporte = "lstCategoriasArt"
            Case Listados.FORMAS_PAGOS
                mstrTitulo = "Formas de Pago"
                mstrReporte = "lstFormasdePago"
            Case Listados.PROVINCIAS
                mstrTitulo = "Provincias"
                mstrReporte = "lstProvincias"
            Case Listados.RUBROS_MAESTRO_ART
                mstrTitulo = "Rubros Maestros de Artículos"
                mstrReporte = "lstRubrosMaestro"
            Case Listados.RUBROS_GCIAS
                mstrTitulo = "Rubros de Ganancias"
                mstrReporte = "lstRubGcias"
        End Select

        Me.LabelTituloFiltro.Text = "Entorno de " & mstrTitulo
        Me.Text = "Listado de " & mstrTitulo

        optDetalle.Checked = True

        Me.CtlComboDesde.Select()

    End Sub

    Private Sub InicializarCombos()
        With Me.CtlComboDesde
            Select Case mlngTipoListado
                Case Listados.CLIENTES
                    .ValueMember = "Codigo"
                    .DisplayMember = "NombreyCodigo"
                    .DataSource = _repClientes.GetAll
                Case Listados.PROVEEDORES
                    .ValueMember = "Codigo"
                    .DisplayMember = "NombreyCodigo"
                    .DataSource = _repProveedores.GetAll
                Case Listados.TRANSPORTES
                    .ValueMember = "Id"
                    .DisplayMember = "NombreyCodigo"
                    .DataSource = _repTransportes.GetAll
                Case Listados.VENDEDORES
                    .ValueMember = "Id"
                    .DisplayMember = "NombreyCodigo"
                    .DataSource = _repVendedores.GetAll
                Case Listados.CONCEPTOS_FINANCIEROS
                    .ValueMember = "Codigo"
                    .DisplayMember = "NombreyCodigo"
                    .DataSource = _repConcBanc.GetAll.OrderBy(Function(x) x.Codigo).ToList()
                Case Listados.ZONAS
                    .ValueMember = "Id"
                    .DisplayMember = "NombreyCodigo"
                    .DataSource = _repZonas.GetAll
                Case Listados.CUENTAS_FINANCIEROS
                    .ValueMember = "Codigo"
                    .DisplayMember = "NombreyCodigo"
                    .DataSource = _repCuentasFi.GetAll.OrderBy(Function(x) x.Codigo).ToList()
                Case Listados.PROVINCIAS
                    .ValueMember = "Codigo"
                    .DisplayMember = "NombreyCodigo"
                    .DataSource = _repProvincias.GetAll.OrderBy(Function(x) x.Codigo).ToList()
                Case Listados.RUBROS_GCIAS
                    .ValueMember = "Id"
                    .DisplayMember = "NombreyCodigo"
                    .DataSource = _repRubGcias.GetAll
                Case Listados.FORMAS_PAGOS
                    .ValueMember = "Id"
                    .DisplayMember = "NombreyCodigo"
                    .DataSource = _repFormasPago.GetAll
                Case Listados.RUBROS_MAESTRO_ART
                    .ValueMember = "Id"
                    .DisplayMember = "NombreyCodigo"
                    .DataSource = _repRubMaestroArt.GetAll
                Case Listados.CATEGORIAS_ART
                    .ValueMember = "Codigo"
                    .DisplayMember = "NombreyCodigo"
                    .DataSource = _repCategoArt.GetAll
                Case Listados.BANCOS
                    .ValueMember = "Codigo"
                    .DisplayMember = "NombreyCodigo"
                    .DataSource = _repBancos.GetAll.OrderBy(Function(x) x.Codigo).ToList()
            End Select
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            If .Items.Count <> 0 Then .SelectedIndex = 0
        End With

        With Me.CtlComboHasta
            Select Case mlngTipoListado
                Case Listados.CLIENTES
                    .ValueMember = "Codigo"
                    .DisplayMember = "NombreyCodigo"
                    .DataSource = _repClientes.GetAll
                Case Listados.PROVEEDORES
                    .ValueMember = "Codigo"
                    .DisplayMember = "NombreyCodigo"
                    .DataSource = _repProveedores.GetAll
                Case Listados.TRANSPORTES
                    .ValueMember = "Id"
                    .DisplayMember = "NombreyCodigo"
                    .DataSource = _repTransportes.GetAll
                Case Listados.VENDEDORES
                    .ValueMember = "Id"
                    .DisplayMember = "NombreyCodigo"
                    .DataSource = _repVendedores.GetAll
                Case Listados.CONCEPTOS_FINANCIEROS
                    .ValueMember = "Codigo"
                    .DisplayMember = "NombreyCodigo"
                    .DataSource = _repConcBanc.GetAll.OrderBy(Function(x) x.Codigo).ToList()
                Case Listados.ZONAS
                    .ValueMember = "Id"
                    .DisplayMember = "NombreyCodigo"
                    .DataSource = _repZonas.GetAll
                Case Listados.CUENTAS_FINANCIEROS
                    .ValueMember = "Codigo"
                    .DisplayMember = "NombreyCodigo"
                    .DataSource = _repCuentasFi.GetAll.OrderBy(Function(x) x.Codigo).ToList()
                Case Listados.PROVINCIAS
                    .ValueMember = "Codigo"
                    .DisplayMember = "NombreyCodigo"
                    .DataSource = _repProvincias.GetAll.OrderBy(Function(x) x.Codigo).ToList()
                Case Listados.RUBROS_GCIAS
                    .ValueMember = "Id"
                    .DisplayMember = "NombreyCodigo"
                    .DataSource = _repRubGcias.GetAll
                Case Listados.FORMAS_PAGOS
                    .ValueMember = "Id"
                    .DisplayMember = "NombreyCodigo"
                    .DataSource = _repFormasPago.GetAll
                Case Listados.RUBROS_MAESTRO_ART
                    .ValueMember = "Id"
                    .DisplayMember = "NombreyCodigo"
                    .DataSource = _repRubMaestroArt.GetAll
                Case Listados.CATEGORIAS_ART
                    .ValueMember = "Codigo"
                    .DisplayMember = "NombreyCodigo"
                    .DataSource = _repCategoArt.GetAll
                Case Listados.BANCOS
                    .ValueMember = "Codigo"
                    .DisplayMember = "NombreyCodigo"
                    .DataSource = _repBancos.GetAll.OrderBy(Function(x) x.Codigo).ToList()
                
            End Select
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            If .Items.Count <> 0 Then .SelectedIndex = .Items.Count - 1
        End With

    End Sub

    Private Sub lstPrimario_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'iniciar formulario
        InicializarFormulario()
    End Sub

    Private Sub CustomGotFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = Color.LightSteelBlue

        If sender.GetType = GetType(TextBox) Then
            DirectCast(sender, TextBox).Font = New Font(DirectCast(sender, TextBox).Font, FontStyle.Bold)
        End If

    End Sub

    Private Sub CustomLostFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = SystemColors.Window

        If sender.GetType = GetType(TextBox) Then
            DirectCast(sender, TextBox).Font = New Font(DirectCast(sender, TextBox).Font, FontStyle.Regular)
        End If

    End Sub

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        For Each c As Control In Me.Controls
            Select Case c.GetType
                Case GetType(TextBox), GetType(CheckBox), GetType(ComboBox), GetType(NumericUpDown)
                    AddHandler c.GotFocus, AddressOf CustomGotFocus
                    AddHandler c.LostFocus, AddressOf CustomLostFocus
            End Select
        Next

        AddHandler Me.KeyDown, AddressOf FormularioKeyDown
        AddHandler Me.BtnReporte.Click, AddressOf MenuClick
        AddHandler Me.BtnCancelar.Click, AddressOf MenuClick

    End Sub

    Private Sub Cancelar()
        Me.Close()
    End Sub

    Private Sub Reporte()

        Dim repoparametros As New CapaLogica.ParametroCLog

        Try

            If Me.CtlComboDesde.SelectedItem Is Nothing Then
                Throw New Exception("El dato DESDE de " & mstrTitulo & " seleccionado no es válido")
            End If

            If Me.CtlComboHasta.SelectedItem Is Nothing Then
                Throw New Exception("El dato HASTA de " & mstrTitulo & " seleccionado no es válido")
            End If

            Dim r As New GeneradorReportes.Reporte

            r.Nombre = Me.Text

            r.SourceFile = My.Settings.RutaReportes & "\" & mstrReporte & ".rdl"

            SetearEncabezadosReporte(r)

            r.Parametros.Add(New GeneradorReportes.Parametro("titulo", Me.Text))

            r.Parametros.Add(New GeneradorReportes.Parametro("cdesde", Me.CtlComboDesde.SelectedValue))
            r.Parametros.Add(New GeneradorReportes.Parametro("chasta", Me.CtlComboHasta.SelectedValue))
            r.Parametros.Add(New GeneradorReportes.Parametro("corden", If(optId.Checked = True, 0, 1)))

            r.ShowReport()

            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F12 : Reporte()
            Case Keys.Escape : Cancelar()
            Case Keys.Return : SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub MenuClick(ByVal sender As Object, ByVal e As EventArgs)
        Select Case DirectCast(sender, ToolStripButton).Name
            Case "BtnReporte" : Reporte()
            Case "BtnCancelar" : Cancelar()
        End Select
    End Sub

End Class