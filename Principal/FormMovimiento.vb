Public Class FormMovimiento

    'entidad
    Property Entidad As Entidades.Financiero

    'repositorios de tablas
    Private _repositorio As New CapaLogica.FinancieroCLog
    Private _repositorioCtas As New CapaLogica.CuentabancariaCLog
    Private _repositorioCptos As New CapaLogica.ConceptobancarioCLog
    Private _repositorioParam As New CapaLogica.ParametroCLog

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

        Me.Text = "Movimiento de caja"

        Me.DtpFecha.Focus()

    End Sub

    

    Private Sub FormZona_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

    Private Sub Guardar()

        Try

            'actualizo los valores de la entidad que se desea persistir
            Entidad = New Entidades.Financiero

            Entidad.Origen = ORIGEN_FINANCIERO_MOVIM
            Entidad.Cuenta = DirectCast(Me.ComboBoxCta.SelectedItem, Entidades.Cuentabancaria).Codigo
            Entidad.Concepto = DirectCast(Me.ComboBoxCpto.SelectedItem, Entidades.Conceptobancario).Codigo
            Entidad.Tipo = DirectCast(Me.ComboBoxCpto.SelectedItem, Entidades.Conceptobancario).Tipo
            Entidad.Emision = Me.DtpFecha.Value
            Entidad.Efectivizacion = Me.DtpFecha.Value
            Entidad.Importe = Convert.ToDouble(Me.TextBoxImporte.Text)
            Entidad.Observacion = Me.TextBoxObservacion.Text
            Entidad.Usuario = gUsuario.Id
            Entidad.Sucursal = My.Settings.CodigoSucursal
            Entidad.Cbtevta = Nothing
            Entidad.Cbtecpra = Nothing
            'Entidad.Cbtepago = Nothing
            'Entidad.Cbterecibo = Nothing

            'envio los nuevos datos al repositor para actualizar
            _repositorio.Save(Entidad)

            If _repositorio.HasError Then

                MessageBox.Show(_repositorio.mensajes.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                MessageBox.Show("La operación ha finalizado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                Me.DialogResult = Windows.Forms.DialogResult.OK

                Me.Close()

            End If

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Guardar()
    End Sub

    Private Sub ComboBoxZonas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub InicializarCombos()
        InicializarComboCuentas()
        InicializarComboConceptos()
    End Sub

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F12 : Guardar()
            Case Keys.Escape : Cancelar()
            Case Keys.Return : SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub InicializarComboCuentas()
        With Me.ComboBoxCta
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"

            'limito las cuentas al perfil mostrador
            If gUsuario.Perfil = PERFIL_MOSTRADOR Then
                .DataSource = _repositorioCtas.GetAllWithValue(_repositorioParam.GetByNombre("CuentaBancariaMostrador").Valorpredeterminado)
            Else
                .DataSource = _repositorioCtas.GetAll
            End If

            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems

            .Inicializar()

            .SelectedIndex = -1

            If .Items.Count <> 0 Then
                If gUsuario.Perfil = PERFIL_MOSTRADOR Then
                    .SelectedIndex = 0
                End If
            End If

        End With
    End Sub

    Private Sub InicializarComboConceptos()
        With Me.ComboBoxCpto
            .ValueMember = "Codigo"
            .DisplayMember = "TipoyNombre"
            .DataSource = _repositorioCptos.GetAll
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            .SelectedIndex = -1
        End With
    End Sub

End Class