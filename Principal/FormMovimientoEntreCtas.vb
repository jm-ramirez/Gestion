Public Class FormMovimientoEntreCtas

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

        Me.DtpFecha.Value = Date.Today

        InicializarCombos()

        Me.TextBoxNumero.Text = GetNro()

        Me.Text = "Movimiento entre Cuentas"

        Me.nudImporte.Value = Format(0, "0.00")

        Me.DtpFecha.Focus()

    End Sub

    Private Function GetNro() As UInt32
        Try
            Return Convert.ToInt32(_repositorioParam.GetByNombre("NroMovCuentas").Valorpredeterminado) + 1
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
        Dim nroMovCtas As UInt32 = 0

        Try

            nroMovCtas = GetNro()

            If nroMovCtas = 0 Then
                Throw New Exception("El nro. de movimiento entre cuentas no puede ser cero")
            End If

            If Trim(Me.TextBoxReferencia.Text) = "" Then
                Throw New Exception("El Nº de Referencia ingresado no es válido")
            End If

            If Me.ComboBoxCtaExtraccion.SelectedItem Is Nothing Then
                Throw New Exception("La Cuenta Financiera de Extracción ingresada no es válida")
            End If

            If Me.ComboBoxCptoExtraccion.SelectedItem Is Nothing Then
                Throw New Exception("El Concepto Financiero de Extracción ingresado no es válido")
            End If

            If Me.ComboBoxCtaDeposito.SelectedItem Is Nothing Then
                Throw New Exception("La Cuenta Financiera de Depósito ingresada no es válida")
            End If

            If Me.ComboBoxCptoDeposito.SelectedItem Is Nothing Then
                Throw New Exception("El Concepto Financiero de Depósito ingresado no es válido")
            End If

            If Val(Me.nudImporte.Value) = 0 Then
                Throw New Exception("El Importe ingresado no es válido")
            End If

            If MessageBox.Show("Confirma la operación?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            objList = New List(Of Entidades.Financiero)

            'actualizo los valores de la entidad que se desea persistir
            'cuenta de extraccion
            Entidad = New Entidades.Financiero
            Entidad.CbteMovCtas = nroMovCtas
            Entidad.Referencia = Me.TextBoxReferencia.Text
            Entidad.Origen = ORIGEN_FINANCIERO_MOVIM
            Entidad.Cuenta = DirectCast(Me.ComboBoxCtaExtraccion.SelectedItem, Entidades.Cuentabancaria).Codigo
            Entidad.Concepto = DirectCast(Me.ComboBoxCptoExtraccion.SelectedItem, Entidades.Conceptobancario).Codigo
            Entidad.Tipo = DirectCast(Me.ComboBoxCptoExtraccion.SelectedItem, Entidades.Conceptobancario).Tipo
            Entidad.Emision = Me.DtpFecha.Value
            Entidad.Efectivizacion = Me.DtpFecha.Value
            Entidad.Fecharegistracion = Nothing
            Entidad.Importe = Convert.ToDouble(Me.nudImporte.Value)
            Entidad.Observacion = Me.TextBoxObservacion.Text
            Entidad.Usuario = gUsuario.Id
            Entidad.Sucursal = My.Settings.CodigoSucursal
            Entidad.Dador = "CUENTA " & Me.ComboBoxCtaExtraccion.SelectedValue
            Entidad.Beneficiario = "CUENTA " & Me.ComboBoxCtaDeposito.SelectedValue

            objList.Add(Entidad)

            'cuenta de deposito
            Entidad = New Entidades.Financiero
            Entidad.CbteMovCtas = nroMovCtas
            Entidad.Referencia = Me.TextBoxReferencia.Text
            Entidad.Origen = ORIGEN_FINANCIERO_MOVIM
            Entidad.Cuenta = DirectCast(Me.ComboBoxCtaDeposito.SelectedItem, Entidades.Cuentabancaria).Codigo
            Entidad.Concepto = DirectCast(Me.ComboBoxCptoDeposito.SelectedItem, Entidades.Conceptobancario).Codigo
            Entidad.Tipo = DirectCast(Me.ComboBoxCptoDeposito.SelectedItem, Entidades.Conceptobancario).Tipo
            Entidad.Emision = Me.DtpFecha.Value
            Entidad.Efectivizacion = Me.DtpFecha.Value
            Entidad.Fecharegistracion = Nothing
            Entidad.Importe = Convert.ToDouble(Me.nudImporte.Value)
            Entidad.Observacion = Me.TextBoxObservacion.Text
            Entidad.Usuario = gUsuario.Id
            Entidad.Sucursal = My.Settings.CodigoSucursal
            Entidad.Dador = "CUENTA " & Me.ComboBoxCtaExtraccion.SelectedValue
            Entidad.Beneficiario = "CUENTA " & Me.ComboBoxCtaDeposito.SelectedValue

            objList.Add(Entidad)

            'envio los nuevos datos al repositor para actualizar
            nroMovCtas = _repositorio.SaveList(objList)

            If _repositorio.HasError Then

                MessageBox.Show(_repositorio.mensajes.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                'If MessageBox.Show("Desea Emitir el Comprobante del Movimiento?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                EmisionMovCtas(nroMovCtas, DtpFecha.Value, DtpFecha.Value, True)
                'End If

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
        With Me.ComboBoxCtaExtraccion
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
        With Me.ComboBoxCptoExtraccion
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = _repositorioCptos.GetConceptosAcreedores
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            .SelectedIndex = -1
        End With

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

End Class