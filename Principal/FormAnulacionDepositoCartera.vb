Public Class FormAnulacionDepositoCartera

    'entidad
    Property Entidad As Entidades.Financiero

    'repositorios de tablas
    Private _repositorio As New CapaLogica.FinancieroCLog
    Private _repositorioCtas As New CapaLogica.CuentabancariaCLog
    Private _repositorioCptos As New CapaLogica.ConceptobancarioCLog
    Private _repositorioParam As New CapaLogica.ParametroCLog
    Private _importeTotal As Double

    Dim nroDeposito As UInt32

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

        For Each c As Control In Me.GroupBoxExtraccion.Controls
            Select Case c.GetType
                Case GetType(TextBox) : DirectCast(c, TextBox).Text = ""
                Case GetType(ComboBox) : DirectCast(c, ComboBox).SelectedIndex = -1
                Case GetType(CheckBox) : DirectCast(c, CheckBox).Checked = False
            End Select
        Next

        For Each c As Control In Me.GroupBoxDeposito.Controls
            Select Case c.GetType
                Case GetType(TextBox) : DirectCast(c, TextBox).Text = ""
                Case GetType(ComboBox) : DirectCast(c, ComboBox).SelectedIndex = -1
                Case GetType(CheckBox) : DirectCast(c, CheckBox).Checked = False
            End Select
        Next

        InicializarValoresPredeterminados()

    End Sub

    Private Sub InicializarValoresPredeterminados()
        Me.DtpFecha.Value = Date.Today
        Me.DtpEfectivizacion.Value = Me.DtpFecha.Value

        'Me.TextBoxReferencia.Text = GetNroDeposito()

        Me.CtlCartera.TipoCargaCbte = TipoEmisionCbte.DEPOSITO_CARTERA
        Me.CtlCartera.AnularDepositoNro = -1
        Me.CtlCartera.Inicializar()
        Me.CtlCartera.Limpiar()

        InicializarCombos()

        Me.Text = "Anulación de Depósitos de Cheques en Cartera"

        Me.GroupBoxDeposito.Enabled = False
        Me.GroupBoxExtraccion.Enabled = False
        Me.GroupBoxImporte.Enabled = False
        Me.DtpEfectivizacion.Enabled = False
        Me.DtpFecha.Enabled = False

        Me.DtpFecha.Focus()

    End Sub

    'Private Function GetNroDeposito() As UInt32
    '    Try
    '        Return Convert.ToInt32(_repositorioParam.GetByNombre("NroDepositoCartera").Valorpredeterminado) + 1
    '    Catch ex As Exception
    '        Return 0
    '    End Try

    'End Function

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

        For Each c As Control In Me.GroupBoxExtraccion.Controls
            Select Case c.GetType
                Case GetType(TextBox), GetType(CheckBox), GetType(ComboBox)
                    AddHandler c.GotFocus, AddressOf CustomGotFocus
                    AddHandler c.LostFocus, AddressOf CustomLostFocus
            End Select
        Next

        For Each c As Control In Me.GroupBoxDeposito.Controls
            Select Case c.GetType
                Case GetType(TextBox), GetType(CheckBox), GetType(ComboBox)
                    AddHandler c.GotFocus, AddressOf CustomGotFocus
                    AddHandler c.LostFocus, AddressOf CustomLostFocus
            End Select
        Next

        For Each c As Control In Me.GroupBoxImporte.Controls
            Select Case c.GetType
                Case GetType(TextBox), GetType(CheckBox), GetType(ComboBox)
                    AddHandler c.GotFocus, AddressOf CustomGotFocus
                    AddHandler c.LostFocus, AddressOf CustomLostFocus
            End Select
        Next

        AddHandler Me.KeyDown, AddressOf FormularioKeyDown

    End Sub

    Private Sub Guardar()

        Dim objList As List(Of Entidades.Financiero) = Nothing

        Try

            nroDeposito = Me.ComboBoxDeposito.SelectedValue

            If nroDeposito = 0 Then
                Throw New Exception("El nro. de depósito no puede ser cero")
            End If

            If Me.ComboBoxCtaDeposito.SelectedItem Is Nothing Then
                Throw New Exception("La cuenta de depósito no es válida")
            End If

            If Me.ComboBoxCptoDeposito.SelectedItem Is Nothing Then
                Throw New Exception("El concepto de depósito no es válido")
            End If

            If Me.CtlCartera.TotalCartera = 0 Then
                Throw New Exception("El importe total a depositar no puede ser cero")
            End If

            If MessageBox.Show("Confirma la anulación del depósito " & nroDeposito.ToString & "?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            If MessageBox.Show("Está seguro que desea realizar la anulación del depósito " & nroDeposito.ToString & "?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            objList = New List(Of Entidades.Financiero)

            For Each f As Entidades.Financiero In Me.CtlCartera.Cartera
                If f.Checked Then

                    'actualizo los valores de la entidad que se desea persistir
                    'cuenta de extraccion
                    f.Deposito = nroDeposito
                    f.Concepto = CONCEPTO_CHEQUE_RECIBIDO
                    f.Egreso = Nothing

                    objList.Add(f)

                End If
            Next

            'cuenta de deposito
            Entidad = New Entidades.Financiero
            Entidad.Referencia = nroDeposito
            Entidad.Origen = ORIGEN_FINANCIERO_MOVIM
            Entidad.Cuenta = DirectCast(Me.ComboBoxCtaDeposito.SelectedItem, Entidades.Cuentabancaria).Codigo
            Entidad.Concepto = DirectCast(Me.ComboBoxCptoDeposito.SelectedItem, Entidades.Conceptobancario).Codigo
            Entidad.Tipo = CONCEPTO_ACREEDOR 'DirectCast(Me.ComboBoxCptoDeposito.SelectedItem, Entidades.Conceptobancario).Tipo
            Entidad.Emision = Me.DtpFecha.Value
            Entidad.Efectivizacion = Me.DtpEfectivizacion.Value
            Entidad.Fecharegistracion = Date.Now
            Entidad.Importe = _importeTotal
            Entidad.Observacion = Me.TextBoxObservacion.Text
            Entidad.Usuario = gUsuario.Id
            Entidad.Sucursal = My.Settings.CodigoSucursal
            Entidad.Dador = "CUENTA " & Me.ComboBoxCtaDeposito.SelectedValue
            Entidad.Beneficiario = "* ANULACION DEP. CARTERA " & nroDeposito.ToString
            Entidad.Deposito = nroDeposito

            'envio los nuevos datos al repositor para actualizar
            _repositorio.AnulaDepositoCartera(objList, Entidad)

            If _repositorio.HasError Then

                MessageBox.Show(_repositorio.mensajes.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                'EmisionDeposito(nroDeposito, Me.DtpFecha.Value, True)

                MessageBox.Show("La operación ha finalizado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                Me.DialogResult = Windows.Forms.DialogResult.OK

                Me.Close()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Guardar()
    End Sub

    Private Sub InicializarCombos()
        InicializarComboCuentas()
        InicializarComboConceptos()
        InicilizarComboDepositos()
    End Sub

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Delete : Guardar()
            Case Keys.Escape
                Salir()
            Case Keys.F5 : VisualizarComprobantes()
        End Select
    End Sub

    Private Sub BtnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVisualizar.Click
        VisualizarComprobantes()
    End Sub

    Private Sub VisualizarComprobantes()
        nroDeposito = Me.ComboBoxDeposito.SelectedValue

        If nroDeposito = 0 Then
            MessageBox.Show("Debe seleccionar un registro", "Visualizar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Call EmisionDeposito(nroDeposito, DtpFecha.Value, True, True)
        End If

    End Sub

    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Salir()
    End Sub

    Private Sub Salir()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Imprimir()
        VisualizarComprobantes()
    End Sub

    Private Sub InicializarComboCuentas()

        With Me.ComboBoxCtaDeposito
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

        With Me.ComboBoxCptoDeposito
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = _repositorioCptos.GetConceptosDeudores
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            .SelectedIndex = -1
        End With

    End Sub

    Private Sub CtlCartera_Totalizado() Handles CtlCartera.Totalizado
        Totalizar()
    End Sub

    Private Sub Totalizar()

        Dim qty As Integer = 0

        _importeTotal = Me.CtlCartera.TotalCartera
        Me.TextBoxImporte.Text = _importeTotal.ToString("$ #,##0.00#")


        For Each f As Entidades.Financiero In Me.CtlCartera.Cartera
            If f.Checked Then qty += 1
        Next

        Me.LabelCheques.Text = "* " & qty & " Cheques seleccionados de " & Me.CtlCartera.Cartera.Count

    End Sub

    Private Sub ComboBoxCptoDeposito_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxCptoDeposito.SelectedIndexChanged
        If ComboBoxCptoDeposito.SelectedItem IsNot Nothing Then
            'seteo la fecha de efectivizacion segun los plazos del concepto
            Me.DtpEfectivizacion.Value = Date.Today.AddDays(DirectCast(ComboBoxCptoDeposito.SelectedItem, Entidades.Conceptobancario).Plazo)
        End If
    End Sub

    Private Sub InicilizarComboDepositos()
        Me.ComboBoxDeposito.Items.Clear()
        Me.ComboBoxDeposito.DataSource = _repositorio.GetNroDepositos
        'Me.ComboBoxDeposito.SelectedIndex = 0
        CargarDatosDeposito()
    End Sub

    Private Sub ComboBoxDeposito_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxDeposito.SelectedIndexChanged
        CargarDatosDeposito()
    End Sub

    Private Sub CargarDatosDeposito()

        If Me.ComboBoxDeposito.SelectedItem Is Nothing Then Exit Sub

        For Each f As Entidades.Financiero In _repositorio.GetDeposito(Me.ComboBoxDeposito.SelectedValue).Where(Function(x As Entidades.Financiero) x.Cuenta <> CUENTA_CARTERA).ToList
            Me.DtpFecha.Value = f.Emision
            Me.DtpEfectivizacion.Value = f.Efectivizacion
            Me.ComboBoxCtaDeposito.SelectedValue = f.Cuenta
            Me.ComboBoxCptoDeposito.SelectedValue = f.Concepto
            Me.TextBoxImporte.Text = f.Importe.ToString("$ #,##0.00#")
            Me.TextBoxObservacion.Text = f.Observacion
            Me.CtlCartera.TipoCargaCbte = TipoEmisionCbte.DEPOSITO_CARTERA
            Me.CtlCartera.AnularDepositoNro = Me.ComboBoxDeposito.SelectedValue
            Me.CtlCartera.Inicializar()
            Me.CtlCartera.Limpiar()
            Exit For
        Next
    End Sub

End Class