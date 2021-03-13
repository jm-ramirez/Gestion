Public Class FormInformeComprasRubArt
    Private _repositorioArt As New CapaLogica.ArticuloCLog
    Private _repositorioRub As New CapaLogica.RubroCLog

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
        Me.DateTimePickerDesde.Value = CDate("01/" & Date.Today.Month & "/" & Date.Today.Year)
        Me.DateTimePickerHasta.Value = CDate(Date.Today)


        Me.DateTimePickerDesde.Focus()
    End Sub

    Private Sub InicializarCombos()
        InicializarComboArticulos()
        InicializarComboRubros()

    End Sub
    Private Sub CustomGotFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = Color.LightGreen

        If sender.GetType = GetType(TextBox) Then
            DirectCast(sender, TextBox).Font = New Font(DirectCast(sender, TextBox).Font, FontStyle.Bold)
        ElseIf sender.GetType = GetType(DateTimePicker) Then
            DirectCast(sender, DateTimePicker).Font = New Font(DirectCast(sender, DateTimePicker).Font, FontStyle.Bold)
        End If

    End Sub

    Private Sub CustomLostFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = SystemColors.Window

        If sender.GetType = GetType(TextBox) Then
            DirectCast(sender, TextBox).Font = New Font(DirectCast(sender, TextBox).Font, FontStyle.Regular)
        ElseIf sender.GetType = GetType(DateTimePicker) Then
            DirectCast(sender, DateTimePicker).Font = New Font(DirectCast(sender, DateTimePicker).Font, FontStyle.Regular)
        End If

    End Sub
    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        For Each c As Control In Me.Controls
            Select Case c.GetType
                Case GetType(TextBox), GetType(CheckBox), GetType(ComboBox), GetType(DateTimePicker)
                    AddHandler c.GotFocus, AddressOf CustomGotFocus
                    AddHandler c.LostFocus, AddressOf CustomLostFocus
                    AddHandler c.PreviewKeyDown, AddressOf CustomPreviewKeyDown
                Case GetType(GroupBox)
                    ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
                    For Each d As Control In c.Controls
                        Select Case d.GetType
                            Case GetType(TextBox), GetType(ComboBox), GetType(DateTimePicker)
                                AddHandler d.GotFocus, AddressOf CustomGotFocus
                                AddHandler d.LostFocus, AddressOf CustomLostFocus
                                AddHandler d.PreviewKeyDown, AddressOf CustomPreviewKeyDown
                        End Select
                    Next
            End Select
        Next

        AddHandler Me.KeyDown, AddressOf FormularioKeyDown

    End Sub
    Private Sub InicializarComboArticulos()
        With Me.CtlComboArticulosDesde
            .ValueMember = "Codigo"
            .DisplayMember = "NombreyCodigo"
            .DataSource = _repositorioArt.GetAll.OrderBy(Function(x) x.Codigo).ToList()
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .DropDownStyle = ComboBoxStyle.DropDownList
            '.FormularioDeAlta = FormCliente
            .Inicializar()
            If .Items.Count > 0 Then
                .SelectedIndex = 0
            Else
                .SelectedIndex = -1
            End If

        End With

        With Me.CtlComboArticulosHasta
            .ValueMember = "Codigo"
            .DisplayMember = "NombreyCodigo"
            .DataSource = _repositorioArt.GetAll.OrderBy(Function(x) x.Codigo).ToList()
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .DropDownStyle = ComboBoxStyle.DropDownList
            '.FormularioDeAlta = FormCliente
            .Inicializar()
            If .Items.Count > 0 Then
                .SelectedIndex = .Items.Count - 1
            Else
                .SelectedIndex = -1
            End If
        End With
    End Sub
    Private Sub InicializarComboRubros()

        With Me.CtlComboRubrosDesde
            .ValueMember = "Codigo"
            .DisplayMember = "NombreyCodigo"
            .DataSource = _repositorioRub.GetAll.OrderBy(Function(x) x.Codigo).ToList()
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .DropDownStyle = ComboBoxStyle.DropDownList
            '.FormularioDeAlta = FormCliente
            .Inicializar()
            If .Items.Count > 0 Then
                .SelectedIndex = 0
            Else
                .SelectedIndex = -1
            End If

        End With

        With Me.CtlComboRubrosHasta
            .ValueMember = "Codigo"
            .DisplayMember = "NombreyCodigo"
            .DataSource = _repositorioRub.GetAll.OrderBy(Function(x) x.Codigo).ToList()
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .DropDownStyle = ComboBoxStyle.DropDownList
            '.FormularioDeAlta = FormCliente
            .Inicializar()
            If .Items.Count > 0 Then
                .SelectedIndex = .Items.Count - 1
            Else
                .SelectedIndex = -1
            End If
        End With

    End Sub
    Private Sub CustomPreviewKeyDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs)
        'If e.KeyCode = Keys.Enter Then
        '    SendKeys.Send("{TAB}")
        'End If
    End Sub
    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Cancelar()
    End Sub

    Private Sub Cancelar()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Reporte()

        Dim repoparametros As New CapaLogica.ParametroCLog

        Try
            If Me.DateTimePickerDesde.Value > Me.DateTimePickerHasta.Value Then
                Me.DateTimePickerDesde.Focus()
                Throw New Exception("Las fechas ingresadas no son válidas")
            End If

            If Me.CtlComboArticulosDesde.SelectedItem Is Nothing Then
                Throw New Exception("El Material seleccionado no es válido")
                Me.CtlComboArticulosDesde.Focus()
            End If

            If Me.CtlComboArticulosHasta.SelectedItem Is Nothing Then
                Throw New Exception("El Material seleccionado no es válido")
                Me.CtlComboArticulosHasta.Focus()
            End If

            If Me.CtlComboRubrosDesde.SelectedItem Is Nothing Then
                Throw New Exception("El Rubro seleccionada no es válido")
                Me.CtlComboRubrosDesde.Focus()
            End If

            If Me.CtlComboRubrosHasta.SelectedItem Is Nothing Then
                Throw New Exception("El Rubro seleccionada no es válido")
                Me.CtlComboRubrosHasta.Focus()
            End If

            Dim r As New GeneradorReportes.Reporte

            r.Nombre = Me.Text

            r.SourceFile = My.Settings.RutaReportes & "\infComprasRubroArticulo.rdl"

            SetearEncabezadosReporte(r)

            r.Parametros.Add(New GeneradorReportes.Parametro("titulo", Me.Text))

            r.Parametros.Add(New GeneradorReportes.Parametro("fdesde", Format(Me.DateTimePickerDesde.Value, "yyyy/MM/dd")))
            r.Parametros.Add(New GeneradorReportes.Parametro("fhasta", Format(Me.DateTimePickerHasta.Value, "yyyy/MM/dd")))

            r.Parametros.Add(New GeneradorReportes.Parametro("mdesde", Me.CtlComboArticulosDesde.SelectedValue))
            r.Parametros.Add(New GeneradorReportes.Parametro("mhasta", Me.CtlComboArticulosHasta.SelectedValue))
            r.Parametros.Add(New GeneradorReportes.Parametro("rdesde", Me.CtlComboRubrosDesde.SelectedValue))
            r.Parametros.Add(New GeneradorReportes.Parametro("rhasta", Me.CtlComboRubrosHasta.SelectedValue))

            r.ShowReport()

            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReporte.Click
        Reporte()
    End Sub



    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F12 : Reporte()
            Case Keys.Escape : Cancelar()
            Case Keys.Return : SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub FormInformeComprasRubArt_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        Me.Text = "Informe de Compras por Rubro y Artículo"
    End Sub

    Private Sub FormInformeComprasRubArt_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InicializarFormulario()
    End Sub
End Class