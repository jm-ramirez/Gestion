Public Class FormInformeCartera

    Property ReporteDiario As ReporteDiario

    'repositorios de tablas
    'Private _repositorioCuentas As New CapaLogica.CuentabancariaCLog
    Private _repositorioBancos As New CapaLogica.BancoCLog
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

        Me.DateTimePickerDesde.Value = CDate("01/01/" & Date.Today.Year)
        Me.DateTimePickerHasta.Value = CDate("31/12/" & Date.Today.Year)

    End Sub
    
    Private Sub FormVendedor_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        Me.DateTimePickerDesde.Focus()
       
        Me.Text = "Emisión de Cartera"


    End Sub

    Private Sub FormInformeCartera_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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


            Dim r As New GeneradorReportes.Reporte

            If Me.DateTimePickerDesde.Value > Me.DateTimePickerHasta.Value Then
                Throw New Exception("Las fechas ingresadas no son válidas")
                Me.DateTimePickerDesde.Focus()
            End If

            If Me.ComboBoxBancoDesde.SelectedItem Is Nothing Then
                Throw New Exception("El Banco seleccionado no es válido")
                Me.ComboBoxBancoDesde.Focus()
            End If

            If Me.ComboBoxBancoHasta.SelectedItem Is Nothing Then
                Throw New Exception("El Banco seleccionado no es válido")
                Me.ComboBoxBancoHasta.Focus()
            End If

            If Me.RadioButtonD.Checked = True Then
                If Me.CheckBoxCuentas.Checked = False Then
                    If Me.CtlComboCuentasBancarias.SelectedItem Is Nothing And Not CheckBoxCuentas.Checked Then
                        Throw New Exception("La Cuenta seleccionada no es válida")
                        Me.CtlComboCuentasBancarias.Focus()
                    End If
                End If
            End If

            If Me.RadioButtonC.Checked = True And Me.RadioButtonEgreso.Checked = True Then
                Throw New Exception("Los Cheque en Cartera no Poseen Fecha de Egreso")
                Me.RadioButtonC.Focus()
            End If

            r.Nombre = Me.Text
            r.SourceFile = My.Settings.RutaReportes & "\infcartera.rdl"

            r.Parametros.Add(New GeneradorReportes.Parametro("titulo", Me.Text))
            r.Parametros.Add(New GeneradorReportes.Parametro("fdesde", Me.DateTimePickerDesde.Value))
            r.Parametros.Add(New GeneradorReportes.Parametro("fhasta", Me.DateTimePickerHasta.Value))

            r.Parametros.Add(New GeneradorReportes.Parametro("ConcC", CONCEPTO_CHEQUE_RECIBIDO))
            r.Parametros.Add(New GeneradorReportes.Parametro("ConcP", CONCEPTO_CHEQUE_PASADO))
            r.Parametros.Add(New GeneradorReportes.Parametro("ConcD", CONCEPTO_CHEQUE_DEPOSITADO))
            r.Parametros.Add(New GeneradorReportes.Parametro("ConcR", CONCEPTO_CHEQUE_RECHAZADO))
            r.Parametros.Add(New GeneradorReportes.Parametro("Cartera", CUENTA_CARTERA))

            If RadioButtonT.Checked Then
                r.Parametros.Add(New GeneradorReportes.Parametro("cheque", 5))
            ElseIf RadioButtonP.Checked Then
                r.Parametros.Add(New GeneradorReportes.Parametro("cheque", 2))
            ElseIf RadioButtonC.Checked Then
                r.Parametros.Add(New GeneradorReportes.Parametro("cheque", 1))
            ElseIf RadioButtonD.Checked Then
                r.Parametros.Add(New GeneradorReportes.Parametro("cheque", 3))
            Else
                r.Parametros.Add(New GeneradorReportes.Parametro("cheque", 4))
            End If

            If RadioButtonCheque.Checked Then
                r.Parametros.Add(New GeneradorReportes.Parametro("fecha", 1))
            ElseIf RadioButtonIngreso.Checked Then
                r.Parametros.Add(New GeneradorReportes.Parametro("fecha", 2))
            Else
                r.Parametros.Add(New GeneradorReportes.Parametro("fecha", 3))
            End If

            If Me.RadioButtonD.Checked = True Then
                If Me.CheckBoxCuentas.Checked Then
                    r.Parametros.Add(New GeneradorReportes.Parametro("deposito", 1))
                Else
                    r.Parametros.Add(New GeneradorReportes.Parametro("deposito", 2))
                    r.Parametros.Add(New GeneradorReportes.Parametro("codDeposito", Me.CtlComboCuentasBancarias.SelectedValue))
                End If
            End If
            
            SetearEncabezadosReporte(r)

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
        InicializarComboBancos()
        InicializarComboCuentasBancarias()
    End Sub
    Private Sub InicializarComboBancos()


        With Me.ComboBoxBancoDesde
            .ValueMember = "Codigo"
            .DisplayMember = "NombreyCodigo"

            .DataSource = _repositorioBancos.GetAll
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            If .Items.Count > 0 Then
                .SelectedIndex = 0
            Else
                .SelectedIndex = -1
            End If

        End With

        With Me.ComboBoxBancoHasta
            .ValueMember = "Codigo"
            .DisplayMember = "NombreyCodigo"

            .DataSource = _repositorioBancos.GetAll
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            If .Items.Count > 0 Then
                .SelectedIndex = .Items.Count - 1
            Else
                .SelectedIndex = -1
            End If

        End With
    End Sub
    Private Sub InicializarComboCuentasBancarias()

        With Me.CtlComboCuentasBancarias
            .ValueMember = "Codigo"
            .DisplayMember = "NombreyCodigo"
            .DataSource = _repositorioCtaBanc.GetAll().Where(Function(x As Entidades.Cuentabancaria) x.Codigo <> CUENTA_CARTERA).ToList()
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .DropDownStyle = ComboBoxStyle.DropDownList
            .Inicializar()
            .SelectedIndex = -1
        End With

    End Sub
    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F12 : Reporte()
            Case Keys.Escape : Cancelar()
            Case Keys.Return : SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub CheckBoxCuentas_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBoxCuentas.CheckedChanged
        If Not CheckBoxCuentas.Checked And Me.RadioButtonD.Checked = True Then
            Me.CtlComboCuentasBancarias.Enabled = True
            Me.CtlComboCuentasBancarias.FocoDetalle()
        Else
            Me.CtlComboCuentasBancarias.Enabled = False
        End If
    End Sub

    Private Sub RadioButtonD_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButtonD.CheckedChanged
        If Me.RadioButtonD.Checked = True Then
            Me.CheckBoxCuentas.Enabled = True
            Me.CheckBoxCuentas.Checked = True
            Me.CtlComboCuentasBancarias.Enabled = False
        Else
            Me.CheckBoxCuentas.Enabled = False
            Me.CtlComboCuentasBancarias.Enabled = False
        End If
    End Sub
End Class