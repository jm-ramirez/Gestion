Public Class FormInformeEdoCta

    Property ReporteDiario As ReporteDiario

    'repositorios de tablas
    Private _repositorioCuentas As New CapaLogica.CuentabancariaCLog

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

        Me.DateTimePickerDesde.Value = CDate("01/01/" & Date.Today.Year)
        Me.DateTimePickerHasta.Value = CDate("31/12/" & Date.Today.Year)
        Me.DateTimePickerEmision.Value = Date.Today
        Me.CheckBoxCuentas.Checked = True
        Me.CheckBoxConceptos.Checked = True

        Me.DateTimePickerDesde.Focus()

    End Sub

    Private Sub InicializarComboCuentas()
        With Me.CtlComboCuentas
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = _repositorioCuentas.GetAll.Where(Function(x As Entidades.Cuentabancaria) x.Codigo <> CUENTA_CARTERA).ToList()
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            .SelectedIndex = -1
        End With
    End Sub
    Private Sub FormVendedor_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        Me.DateTimePickerDesde.Focus()
        'Select Case Me.ReporteDiario
        '    Case General.ReporteDiario.VENDEDOR
        'Me.Text = "Informe Diario de Ventas por Vendedor"
        '    Case General.ReporteDiario.VENDEDOR_TOTAL
        Me.Text = "Estado de Cuenta"
        'End Select

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

            If Me.CtlComboCuentas.SelectedItem Is Nothing And Not CheckBoxCuentas.Checked Then
                Throw New Exception("La cuenta bancaria seleccionada no es válida")
            End If

            If Me.CtlComboConceptos.SelectedItem Is Nothing And Not CheckBoxConceptos.Checked Then
                Throw New Exception("El concepto bancario seleccionado no es válido")
            End If

            Dim r As New GeneradorReportes.Reporte

            SetearEncabezadosReporte(r)

            r.Nombre = Me.Text
            r.SourceFile = My.Settings.RutaReportes & "\infedocta.rdl"
            
            Dim c As Entidades.Cuentabancaria = DirectCast(Me.CtlComboCuentas.SelectedItem, Entidades.Cuentabancaria)
            Dim l As Entidades.Conceptobancario = DirectCast(Me.CtlComboConceptos.SelectedItem, Entidades.Conceptobancario)

            If Not CheckBoxCuentas.Checked Then
                r.Parametros.Add(New GeneradorReportes.Parametro("cuenta", c.Codigo))
            End If

            If Not CheckBoxConceptos.Checked Then
                r.Parametros.Add(New GeneradorReportes.Parametro("concepto", l.Codigo))
            End If

            'r.Parametros.Add(New GeneradorReportes.Parametro("titulo", Me.Text))
            r.Parametros.Add(New GeneradorReportes.Parametro("fdesde", Me.DateTimePickerDesde.Value))
            r.Parametros.Add(New GeneradorReportes.Parametro("fhasta", Me.DateTimePickerHasta.Value))
            r.Parametros.Add(New GeneradorReportes.Parametro("emision", Me.DateTimePickerEmision.Value))
            r.Parametros.Add(New GeneradorReportes.Parametro("cartera", CUENTA_CARTERA))

            r.ShowReport()

            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub InicializarComboConceptos()
        Dim repositorio As New CapaLogica.ConceptobancarioCLog
        Dim c As BrightIdeasSoftware.OLVColumn = Nothing


        With Me.CtlComboConceptos
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = repositorio.GetAll
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReporte.Click
        Reporte()
    End Sub

    Private Sub InicializarCombos()
        InicializarComboCuentas()
        InicializarComboConceptos()
    End Sub

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F12 : Reporte()
            Case Keys.Escape : Cancelar()
            Case Keys.Return : SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub CheckBoxCuentas_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBoxCuentas.CheckedChanged
        If Not CheckBoxCuentas.Checked Then
            Me.CtlComboCuentas.Enabled = True
            Me.CtlComboCuentas.FocoDetalle()
        Else
            Me.CtlComboCuentas.Enabled = False
        End If
    End Sub

    Private Sub CheckBoxConceptos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBoxConceptos.CheckedChanged
        If Not CheckBoxConceptos.Checked Then
            Me.CtlComboConceptos.Enabled = True
            Me.CtlComboConceptos.FocoDetalle()
        Else
            Me.CtlComboConceptos.Enabled = False
        End If
    End Sub
End Class