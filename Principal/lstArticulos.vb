Public Class lstArticulos
    'repositorios de tablas
    Private _repoCli As New CapaLogica.ClienteCLog
    Private _repoPiezas As New CapaLogica.ArticuloCLog
    Private _repositorioCategorias As New CapaLogica.CategoriaCLog

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

        Me.Text = "Listado de Artículos"

        optId.Checked = True
        'optComercial.Checked = True
        Me.CheckBoxCategorias.Checked = True
        Me.cboPD.Select()

    End Sub

    Private Sub InicializarCombos()
        
        With Me.cboPD
            .ValueMember = "Codigo"
            .DisplayMember = "NombreyCodigo"
            .DataSource = _repoPiezas.GetAll().OrderBy(Function(x) x.CodigoRev).ToList()
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            If .Items.Count <> 0 Then .SelectedIndex = 0
        End With

        With Me.cboPH
            .ValueMember = "Codigo"
            .DisplayMember = "NombreyCodigo"
            .DataSource = _repoPiezas.GetAll().OrderBy(Function(x) x.CodigoRev).ToList()
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            If .Items.Count <> 0 Then .SelectedIndex = .Items.Count - 1
        End With

        With Me.CtlComboCategorias
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = _repositorioCategorias.GetAll()
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            .SelectedIndex = -1
            If .Items.Count <> 0 Then .SelectedIndex = .Items.Count - 1
        End With

    End Sub

    Private Sub lstArticulos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
                Case GetType(TextBox), GetType(CheckBox), GetType(ComboBox)
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


            If Me.cboPD.SelectedItem Is Nothing Then
                Throw New Exception("La Pieza seleccionada no es válida")
            End If

            If Me.cboPH.SelectedItem Is Nothing Then
                Throw New Exception("La Pieza seleccionada no es válida")
            End If

            If Me.CtlComboCategorias.SelectedItem Is Nothing And Not CheckBoxCategorias.Checked Then
                Throw New Exception("La categoria seleccionada no es válida")
            End If

            Dim r As New GeneradorReportes.Reporte
            Dim c As Entidades.Categoria = DirectCast(Me.CtlComboCategorias.SelectedItem, Entidades.Categoria)
            r.Nombre = Me.Text

            r.SourceFile = My.Settings.RutaReportes & "\lstArticulo.rdl"
            
            SetearEncabezadosReporte(r)

            r.Parametros.Add(New GeneradorReportes.Parametro("titulo", Me.Text))

            r.Parametros.Add(New GeneradorReportes.Parametro("ldesde", Me.cboPD.SelectedValue))
            r.Parametros.Add(New GeneradorReportes.Parametro("lhasta", Me.cboPH.SelectedValue))
            r.Parametros.Add(New GeneradorReportes.Parametro("corden", If(optId.Checked = True, 0, 1)))

            If Not CheckBoxCategorias.Checked Then
                r.Parametros.Add(New GeneradorReportes.Parametro("categoria", c.Codigo))
            End If

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

    Private Sub CheckBoxCategorias_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxCategorias.CheckedChanged
        If Not CheckBoxCategorias.Checked Then
            Me.CtlComboCategorias.Enabled = True
            Me.CtlComboCategorias.FocoDetalle()
        Else
            Me.CtlComboCategorias.Enabled = False
        End If
    End Sub
End Class