Public Class FormInfSaldoConcepto

    Private _repositorioCtoBanc As New CapaLogica.ConceptobancarioCLog
    Private _repositorioCtaBanc As New CapaLogica.CuentabancariaCLog

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

    Private Sub FormInfSaldoConcepto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InicializarFormulario()
    End Sub

    Private Sub FormEmisionFichaStock_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Text = "Lista de Saldos por Conceptos"
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
    Private Sub InicializarComboConceptosBancarios()

        With Me.CtlComboConceptoBancDesde
            .ValueMember = "Codigo"
            .DisplayMember = "NombreyCodigo"
            .DataSource = _repositorioCtoBanc.GetAll
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

        With Me.CtlComboConceptoBancHasta
            .ValueMember = "Codigo"
            .DisplayMember = "NombreyCodigo"
            .DataSource = _repositorioCtoBanc.GetAll
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

    Private Sub InicializarComboCuentasBancarias()

        With Me.CtlComboCuentasBancariasDesde
            .ValueMember = "Codigo"
            .DisplayMember = "NombreyCodigo"
            '.DataSource = _repositorioCtaBanc.GetAll
            .DataSource = _repositorioCtaBanc.GetAll().Where(Function(x As Entidades.Cuentabancaria) x.Codigo <> CUENTA_CARTERA).ToList()
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

        With Me.CtlComboCuentasBancariasHasta
            .ValueMember = "Codigo"
            .DisplayMember = "NombreyCodigo"
            .DataSource = _repositorioCtaBanc.GetAll().Where(Function(x As Entidades.Cuentabancaria) x.Codigo <> CUENTA_CARTERA).ToList()
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
                Throw New Exception("Las fechas ingresadas no son válidas")
                Me.DateTimePickerDesde.Focus()
            End If

            If Me.CtlComboConceptoBancDesde.SelectedItem Is Nothing Then
                Throw New Exception("El Concepto seleccionado no es válido")
                Me.CtlComboConceptoBancDesde.Focus()
            End If

            If Me.CtlComboConceptoBancHasta.SelectedItem Is Nothing Then
                Throw New Exception("El Concepto seleccionado no es válido")
                Me.CtlComboConceptoBancHasta.Focus()
            End If

            If Me.CtlComboCuentasBancariasDesde.SelectedItem Is Nothing Then
                Throw New Exception("La Cuenta seleccionada no es válida")
                Me.CtlComboCuentasBancariasDesde.Focus()
            End If

            If Me.CtlComboCuentasBancariasHasta.SelectedItem Is Nothing Then
                Throw New Exception("La Cuenta seleccionada no es válida")
                Me.CtlComboCuentasBancariasHasta.Focus()
            End If
            

            Dim r As New GeneradorReportes.Reporte

            r.Nombre = Me.Text

            r.SourceFile = My.Settings.RutaReportes & "\infSaldosConceptos.rdl"

            SetearEncabezadosReporte(r)

            r.Parametros.Add(New GeneradorReportes.Parametro("titulo", Me.Text))

            r.Parametros.Add(New GeneradorReportes.Parametro("fdesde", Format(Me.DateTimePickerDesde.Value, "yyyy/MM/dd")))
            r.Parametros.Add(New GeneradorReportes.Parametro("fhasta", Format(Me.DateTimePickerHasta.Value, "yyyy/MM/dd")))

            r.Parametros.Add(New GeneradorReportes.Parametro("conceptodesde", Me.CtlComboConceptoBancDesde.SelectedValue))
            r.Parametros.Add(New GeneradorReportes.Parametro("conceptohasta", Me.CtlComboConceptoBancHasta.SelectedValue))

            r.Parametros.Add(New GeneradorReportes.Parametro("cartera", CUENTA_CARTERA))

            r.Parametros.Add(New GeneradorReportes.Parametro("cuentadesde", DirectCast(Me.CtlComboCuentasBancariasDesde.SelectedItem, Entidades.Cuentabancaria).Id))
            r.Parametros.Add(New GeneradorReportes.Parametro("cuentahasta", DirectCast(Me.CtlComboCuentasBancariasHasta.SelectedItem, Entidades.Cuentabancaria).Id))
            r.Parametros.Add(New GeneradorReportes.Parametro("titcuenta", "Desde la cuenta: " & Me.CtlComboCuentasBancariasDesde.SelectedValue & " a la: " & Me.CtlComboCuentasBancariasHasta.SelectedValue))

            If Me.RadioButtonDetallado.Checked = True Then
                r.Parametros.Add(New GeneradorReportes.Parametro("totalizado", 1))
            Else
                r.Parametros.Add(New GeneradorReportes.Parametro("totalizado", 0))
            End If

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
        InicializarComboConceptosBancarios()
        InicializarComboCuentasBancarias()

    End Sub


    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F12 : Reporte()
            Case Keys.Escape : Cancelar()
            Case Keys.Return : SendKeys.Send("{TAB}")
        End Select
    End Sub

End Class