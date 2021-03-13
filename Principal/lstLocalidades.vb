Public Class lstLocalidades
    'repositorios de tablas
    Private _repoLocalidades As New CapaLogica.LocalidadCLog
    Private _repoProvincias As New CapaLogica.ProvinciasCLog

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

        'If Me.ReporteDiario = General.ReporteDiario.lstRubros Then
        Me.Text = "Listado de Localidades"
        'End If

        optId.Checked = True

        Me.cboLocD.Select()

    End Sub

    Private Sub InicializarCombos()
        With Me.cboLocD
            .ValueMember = "Codigopostal"
            .DisplayMember = "NombreyCodigo"
            .DataSource = _repoLocalidades.GetAll
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            If .Items.Count <> 0 Then .SelectedIndex = 0
        End With

        With Me.cboLocH
            .ValueMember = "Codigopostal"
            .DisplayMember = "NombreyCodigo"
            .DataSource = _repoLocalidades.GetAll
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            If .Items.Count <> 0 Then .SelectedIndex = .Items.Count - 1
        End With

        With Me.cboPciaD
            .ValueMember = "Codigo"
            .DisplayMember = "NombreyCodigo"
            .DataSource = _repoProvincias.GetAll
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            If .Items.Count <> 0 Then .SelectedIndex = 0
        End With

        With Me.cboPciaH
            .ValueMember = "Codigo"
            .DisplayMember = "NombreyCodigo"
            .DataSource = _repoProvincias.GetAll
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            If .Items.Count <> 0 Then .SelectedIndex = .Items.Count - 1
        End With
    End Sub

    Private Sub lstLocalidades_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'iniciar formulario
        InicializarFormulario()
    End Sub

    Private Sub CustomGotFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = Color.LightYellow

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

            If Me.cboLocD.SelectedItem Is Nothing Then
                Throw New Exception("La Localidad seleccionada no es válida")
            End If

            If Me.cboLocH.SelectedItem Is Nothing Then
                Throw New Exception("La Localidad seleccionada no es válida")
            End If

            If Me.cboPciaD.SelectedItem Is Nothing Then
                Throw New Exception("La Provincia seleccionada no es válida")
            End If

            If Me.cboPciaH.SelectedItem Is Nothing Then
                Throw New Exception("La Provincia seleccionada no es válida")
            End If

            Dim r As New GeneradorReportes.Reporte

            r.Nombre = Me.Text

            r.SourceFile = My.Settings.RutaReportes & "\lstLocalidades.rdl"

            r.Parametros.Add(New GeneradorReportes.Parametro("titulo", Me.Text))

            r.Parametros.Add(New GeneradorReportes.Parametro("pdesde", Me.cboPciaD.SelectedValue))
            r.Parametros.Add(New GeneradorReportes.Parametro("phasta", Me.cboPciaH.SelectedValue))
            r.Parametros.Add(New GeneradorReportes.Parametro("cdesde", Me.cboLocD.SelectedValue))
            r.Parametros.Add(New GeneradorReportes.Parametro("chasta", Me.cboLocH.SelectedValue))
            r.Parametros.Add(New GeneradorReportes.Parametro("corden", If(optId.Checked = True, 0, 1)))

            SetearEncabezadosReporte(r)

            r.ShowReport()

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