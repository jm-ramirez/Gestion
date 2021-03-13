Public Class FormListaPrecios

    'repositorios de tablas
    Private _repositorioRubros As New CapaLogica.RubroCLog
    Private _repositorioProveedores As New CapaLogica.ProveedorCLog
    Private _repositorioListas As New CapaLogica.ListadeprecioCLog

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

        
        Me.CheckBoxTodos.Checked = True
        Me.DateTimePickerEmision.Value = Date.Today
        Me.CheckBoxSinImp.Checked = True
        Me.CheckBoxOferta.Checked = False
        Me.CheckBoxRubro.Checked = False
    End Sub

    Private Sub FormVendedor_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        Me.Text = "Emisión de Lista de Precios"
    End Sub

    Private Sub FormVendedor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'iniciar formulario
        InicializarFormulario()
    End Sub

    Private Sub CustomGotFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = Color.LightGreen

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
                Case GetType(TextBox), GetType(CheckBox), GetType(ComboBox)
                    AddHandler c.GotFocus, AddressOf CustomGotFocus
                    AddHandler c.LostFocus, AddressOf CustomLostFocus
            End Select
        Next

        AddHandler Me.KeyDown, AddressOf FormularioKeyDown

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Cancelar()
    End Sub

    Private Sub Cancelar()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Reporte()

        Try

            If Me.CtlComboRubroDesde.SelectedItem Is Nothing And Not CheckBoxTodos.Checked Then
                Throw New Exception("El rubro seleccionado no es válido")
            End If

            If Me.CtlComboRubroHasta.SelectedItem Is Nothing And Not CheckBoxTodos.Checked Then
                Throw New Exception("El rubro seleccionado no es válido")
            End If

            If Me.CtlComboLista.SelectedItem Is Nothing Then
                Throw New Exception("La lista de precios seleccionada no es válida")
            End If

            Dim r As New GeneradorReportes.Reporte
            Dim c As Entidades.Rubro
            Dim p As Entidades.Proveedor
            Dim l As Entidades.Listadeprecio = DirectCast(Me.CtlComboLista.SelectedItem, Entidades.Listadeprecio)

            r.Nombre = Me.Text
            If CheckBoxRubro.Checked = True Then
                r.SourceFile = My.Settings.RutaReportes & "\lstpreciofinal(agrup).rdl"
            Else
                r.SourceFile = My.Settings.RutaReportes & "\lstpreciofinal.rdl"
            End If

            If optCodigo.Checked = True Then
                r.Parametros.Add(New GeneradorReportes.Parametro("orden", 0))
            Else
                r.Parametros.Add(New GeneradorReportes.Parametro("orden", 1))
            End If
            r.Parametros.Add(New GeneradorReportes.Parametro("emision", Me.DateTimePickerEmision.Value))



            Select Case l.Id
                Case 1 'R
                    r.Parametros.Add(New GeneradorReportes.Parametro("tipo", "R"))
                Case 2 'K
                    r.Parametros.Add(New GeneradorReportes.Parametro("tipo", "K"))
                Case 3 'M
                    r.Parametros.Add(New GeneradorReportes.Parametro("tipo", "M"))
            End Select

            If Not CheckBoxTodos.Checked Then

                c = DirectCast(Me.CtlComboRubroDesde.SelectedItem, Entidades.Rubro)
                r.Parametros.Add(New GeneradorReportes.Parametro("rdesde", c.Codigo))

                c = DirectCast(Me.CtlComboRubroHasta.SelectedItem, Entidades.Rubro)
                r.Parametros.Add(New GeneradorReportes.Parametro("rhasta", c.Codigo))

            End If

            'If Not CheckBoxProveedores.Checked Then

            '    p = DirectCast(Me.CtlComboProveedorDesde.SelectedItem, Entidades.Proveedor)
            '    r.Parametros.Add(New GeneradorReportes.Parametro("pdesde", p.Codigo))

            '    p = DirectCast(Me.CtlComboProveedorHasta.SelectedItem, Entidades.Proveedor)
            '    r.Parametros.Add(New GeneradorReportes.Parametro("phasta", p.Codigo))
            'End If

            If CheckBoxOferta.Checked Then
                r.Parametros.Add(New GeneradorReportes.Parametro("odesde", 1))
                r.Parametros.Add(New GeneradorReportes.Parametro("ohasta", 1))
            End If

            r.Parametros.Add(New GeneradorReportes.Parametro("sinimp", Not CheckBoxSinImp.Checked))


            r.ShowReport()

            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReporte.Click
        Reporte()
    End Sub

    Private Sub InicializarCombos()
        InicializarComboRubros()
        InicializarComboListas()
        'InicializarComboProveedores()
    End Sub

    Private Sub InicializarComboListas()
        With Me.CtlComboLista
            .ValueMember = "Id"
            .DisplayMember = "Nombre"
            .DataSource = _repositorioListas.GetAll
            .AutoCompleteMode = AutoCompleteMode.Append
            .AutoCompleteSource = AutoCompleteSource.ListItems
            '.FormularioDeAlta = FormListas
            .Inicializar()
            .SelectedIndex = 0
        End With
    End Sub

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F12 : Reporte()
            Case Keys.Escape : Cancelar()
        End Select
    End Sub

    Private Sub InicializarComboRubros()

        With Me.CtlComboRubroDesde
            .ValueMember = "Codigo"
            .DisplayMember = "CodigoyNombre"
            .DataSource = _repositorioRubros.GetAll.OrderBy(Function(x) x.Codigo).ToList()
            .AutoCompleteMode = AutoCompleteMode.Append
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            If .Items.Count <> 0 Then .SelectedIndex = 0
        End With

        With Me.CtlComboRubroHasta
            .ValueMember = "Codigo"
            .DisplayMember = "CodigoyNombre"
            .DataSource = _repositorioRubros.GetAll.OrderBy(Function(x) x.Codigo).ToList()
            .AutoCompleteMode = AutoCompleteMode.Append
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            If .Items.Count <> 0 Then .SelectedIndex = .Items.Count - 1
        End With
    End Sub

    'Private Sub InicializarComboProveedores()

    '    With Me.CtlComboProveedorDesde
    '        .ValueMember = "Codigo"
    '        .DisplayMember = "CodigoyNombre"
    '        .DataSource = _repositorioProveedores.GetAll.OrderBy(Function(x) x.Codigo).ToList()
    '        .AutoCompleteMode = AutoCompleteMode.Append
    '        .AutoCompleteSource = AutoCompleteSource.ListItems
    '        .Inicializar()
    '        If .Items.Count <> 0 Then .SelectedIndex = 0
    '    End With

    '    With Me.CtlComboProveedorHasta
    '        .ValueMember = "Codigo"
    '        .DisplayMember = "CodigoyNombre"
    '        .DataSource = _repositorioProveedores.GetAll.OrderBy(Function(x) x.Codigo).ToList()
    '        .AutoCompleteMode = AutoCompleteMode.Append
    '        .AutoCompleteSource = AutoCompleteSource.ListItems
    '        .Inicializar()
    '        If .Items.Count <> 0 Then .SelectedIndex = .Items.Count - 1
    '    End With
    'End Sub

    Private Sub CheckBoxTodos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBoxTodos.CheckedChanged
        If Not CheckBoxTodos.Checked Then
            Me.CtlComboRubroDesde.FocoDetalle()
        End If
    End Sub

    'Private Sub CheckBoxProveedores_CheckedChanged(sender As System.Object, e As System.EventArgs)
    '    If Not CheckBoxProveedores.Checked Then
    '        Me.CtlComboProveedorDesde.FocoDetalle()
    '    End If
    'End Sub
End Class