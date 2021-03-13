Public Class FormDepositoCartera

    'entidad
    Property Entidad As Entidades.Financiero

    'repositorios de tablas
    Private _repositorio As New CapaLogica.FinancieroCLog
    Private _repositorioCtas As New CapaLogica.CuentabancariaCLog
    Private _repositorioCptos As New CapaLogica.ConceptobancarioCLog
    Private _repositorioParam As New CapaLogica.ParametroCLog
    Private _importeTotal As Double

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

        Me.CtlCartera.TipoCargaCbte = TipoEmisionCbte.DEPOSITO_CARTERA
        Me.CtlCartera.Inicializar()
        Me.CtlCartera.Limpiar()

        InicializarCombos()

        InicializarValoresPredeterminados()

        Me.Text = "Depósito de Cheques en Cartera"

        Me.DtpFecha.Focus()

    End Sub

    Private Sub InicializarValoresPredeterminados()
        Me.DtpFecha.Value = Date.Today
        Me.DtpEfectivizacion.Value = Me.DtpFecha.Value
        Me.ComboBoxCtaDeposito.SelectedValue = Convert.ToString(_repositorioParam.GetByNombre("CuentaChequeDepositado").Valorpredeterminado)
        Me.ComboBoxCptoDeposito.SelectedValue = Convert.ToString(_repositorioParam.GetByNombre("ConceptoDepositoCheque").Valorpredeterminado)

        Me.TextBoxReferencia.Text = GetNroDeposito()

    End Sub

    Private Function GetNroDeposito() As UInt32
        Try
            Return Convert.ToInt32(_repositorioParam.GetByNombre("NroDepositoCartera").Valorpredeterminado) + 1
        Catch ex As Exception
            Return 0
        End Try

    End Function

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

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Cancelar()
    End Sub

    Private Sub Cancelar()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Guardar()

        Dim objList As List(Of Entidades.Financiero) = Nothing
        Dim nroDeposito As UInt32 = 0

        Try

            If MessageBox.Show("Confirma la operación?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            nroDeposito = GetNroDeposito()

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

            objList = New List(Of Entidades.Financiero)

            For Each f As Entidades.Financiero In Me.CtlCartera.Cartera
                If f.Checked Then

                    'actualizo los valores de la entidad que se desea persistir
                    'cuenta de extraccion
                    f.Deposito = nroDeposito
                    f.Concepto = CONCEPTO_CHEQUE_DEPOSITADO
                    f.Egreso = Me.DtpFecha.Value

                    objList.Add(f)

                End If
            Next

            'cuenta de deposito
            Entidad = New Entidades.Financiero
            Entidad.Referencia = Me.TextBoxReferencia.Text
            Entidad.Origen = ORIGEN_FINANCIERO_MOVIM
            Entidad.Cuenta = DirectCast(Me.ComboBoxCtaDeposito.SelectedItem, Entidades.Cuentabancaria).Codigo
            Entidad.Concepto = DirectCast(Me.ComboBoxCptoDeposito.SelectedItem, Entidades.Conceptobancario).Codigo
            Entidad.Tipo = DirectCast(Me.ComboBoxCptoDeposito.SelectedItem, Entidades.Conceptobancario).Tipo
            Entidad.Emision = Me.DtpFecha.Value
            Entidad.Efectivizacion = Me.DtpEfectivizacion.Value
            Entidad.Fecharegistracion = Date.Now
            Entidad.Importe = _importeTotal
            Entidad.Observacion = Me.TextBoxObservacion.Text
            Entidad.Usuario = gUsuario.Id
            Entidad.Sucursal = My.Settings.CodigoSucursal
            Entidad.Dador = "* DEPOSITO CARTERA " & nroDeposito.ToString
            Entidad.Beneficiario = "CUENTA " & Me.ComboBoxCtaDeposito.SelectedValue
            Entidad.Deposito = nroDeposito

            'envio los nuevos datos al repositor para actualizar
            nroDeposito = _repositorio.DepositoCartera(objList, Entidad)

            If _repositorio.HasError Then

                MessageBox.Show(_repositorio.mensajes.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                EmisionDeposito(nroDeposito, Me.DtpFecha.Value, True)

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
    End Sub

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F12 : Guardar()
            Case Keys.Escape : Cancelar()
            Case Keys.Return
                If Me.ActiveControl.Name <> "TextBoxObservacion" Then
                    SendKeys.Send("{TAB}")
                End If
        End Select
    End Sub

    Private Sub InicializarComboCuentas()

        With Me.ComboBoxCtaDeposito
            .ValueMember = "Codigo"
            .DisplayMember = "NombreyCodigo"

            'limito las cuentas al perfil mostrador
            'If gUsuario.Perfil = PERFIL_MOSTRADOR Then
            '.DataSource = _repositorioCtas.GetAllWithValue(_repositorioParam.GetByNombre("CuentaBancariaMostrador").Valorpredeterminado)
            'Else
            .DataSource = _repositorioCtas.GetAll().Where(Function(x As Entidades.Cuentabancaria) x.Codigo <> CUENTA_CARTERA).ToList()
            'End If

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
            .DisplayMember = "NombreyCodigo"
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

End Class