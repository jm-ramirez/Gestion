Public Class FormInformeDiario

    Property ReporteDiario As ReporteDiario

    'repositorios de tablas
    'Private _repositorioRepartidores As New CapaLogica.RepartidorCLog

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

        Me.DateTimePickerDesde.Value = "01/" & Date.Today.ToString("MM/yyyy")
        Me.DateTimePickerHasta.Value = Date.Today
        Me.DateTimePickerPeríodo.Value = Date.Today

        Me.RadioButtonF.Checked = True

        If gUsuario.GodMode Then
            Me.GroupBoxComprobantes.Visible = True
        Else
            Me.GroupBoxComprobantes.Visible = False
        End If

        Me.CheckBoxTodos.Checked = True
        Me.CheckBoxConceptos.Checked = True

        Me.CheckBoxDomicilio.Checked = False
        Me.CheckBoxDomicilio.Visible = Me.ReporteDiario = General.ReporteDiario.IVAVENTAS
        Me.CheckBoxSoloTotales.Visible = Me.ReporteDiario = General.ReporteDiario.IVAVENTAS

        If Me.ReporteDiario = General.ReporteDiario.IVAVENTAS Then
            Me.GroupBoxConceptos.Visible = True
        Else
            Me.GroupBoxConceptos.Visible = False
        End If

        If Me.ReporteDiario = General.ReporteDiario.IVACOMPRAS Then
            Me.RadioButtonPeriodo.Checked = True
            Me.DateTimePickerPeríodo.Select()

            Me.RadioButtonPeriodo.Visible = True
            Me.LabelPeriodo.Visible = True
            Me.DateTimePickerPeríodo.Visible = True
            Me.CheckBoxRet.Visible = True
            Me.CheckBoxTodosGastosVar.Checked = True
            Me.GroupBoxGasVar.Visible = True

        Else
            Me.RadioButtonFecha.Checked = True
            Me.DateTimePickerDesde.Select()

            Me.RadioButtonPeriodo.Visible = False
            Me.LabelPeriodo.Visible = False
            Me.DateTimePickerPeríodo.Visible = False
            Me.CheckBoxRet.Visible = False
            Me.GroupBoxGasVar.Visible = False
        End If
        a_Ingreso()

    End Sub

    Private Sub FormVendedor_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        Select Case Me.ReporteDiario
            Case General.ReporteDiario.COBRANZAS
                Me.Text = "Informe Diario de Cobranzas"
                Me.GroupBoxCliPro.Text = "Cliente"
            Case General.ReporteDiario.IVACOMPRAS
                Me.Text = "Informe Diario de Compras"
                Me.GroupBoxCliPro.Text = "Proveedor"
            Case General.ReporteDiario.IVAVENTAS
                Me.Text = "Informe Diario de Ventas"
                Me.GroupBoxCliPro.Text = "Cliente"
            Case General.ReporteDiario.REMITOS
                Me.Text = "Informe Diario de Remitos"
                Me.GroupBoxCliPro.Text = "Cliente"
            Case General.ReporteDiario.PAGOS
                Me.Text = "Informe Diario de Pagos"
                Me.GroupBoxCliPro.Text = "Proveedor"
        End Select

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

            If CheckBoxTodos.Checked = False And Me.CtlComboCodigo.SelectedItem Is Nothing Then
                Throw New Exception("Debe seleccionar un " & Me.GroupBoxCliPro.Text)
                Me.CtlComboCodigo.FocoDetalle()
            End If

            If CheckBoxTodosGastosVar.Checked = False And Me.CtlComboGastosVar.SelectedItem Is Nothing And Me.ReporteDiario = General.ReporteDiario.IVACOMPRAS Then
                Throw New Exception("Debe seleccionar un Gasto Variable")
                Me.CtlComboGastosVar.FocoDetalle()
            End If

            If CheckBoxConceptos.Checked = False And Me.CtlComboConceptos.SelectedItem Is Nothing And Me.ReporteDiario = General.ReporteDiario.IVAVENTAS Then
                Throw New Exception("Debe seleccionar un Concepto")
                Me.CtlComboConceptos.FocoDetalle()
            End If

            Dim r As New GeneradorReportes.Reporte

            r.Nombre = Me.Text

            Select Case Me.ReporteDiario
                Case General.ReporteDiario.COBRANZAS
                    r.Parametros.Add(New GeneradorReportes.Parametro("titulo", "Diario de Cobranzas"))
                    r.SourceFile = My.Settings.RutaReportes & "\infcobranzas.rdl"
                Case General.ReporteDiario.IVACOMPRAS
                    r.Parametros.Add(New GeneradorReportes.Parametro("titulo", "Diario de Compras"))

                    If Me.CheckBoxRet.Checked Then
                        r.Parametros.Add(New GeneradorReportes.Parametro("listaret", "1"))
                    End If

                    r.SourceFile = My.Settings.RutaReportes & "\infivacompras.rdl"
                Case General.ReporteDiario.REMITOS
                    r.Parametros.Add(New GeneradorReportes.Parametro("titulo", "Diario de Remitos"))
                    r.SourceFile = My.Settings.RutaReportes & "\infremitos.rdl"
                Case General.ReporteDiario.IVAVENTAS
                    r.Parametros.Add(New GeneradorReportes.Parametro("titulo", "Diario de Ventas"))
                    If Me.CheckBoxDomicilio.Checked Then
                        r.SourceFile = My.Settings.RutaReportes & "\infivaventasdomicilio.rdl"
                    Else
                        If Me.CheckBoxSoloTotales.Checked Then
                            r.SourceFile = My.Settings.RutaReportes & "\infivaventasfinal.rdl"
                        Else
                            r.SourceFile = My.Settings.RutaReportes & "\infivaventas.rdl"
                        End If

                    End If
                Case General.ReporteDiario.PAGOS
                    r.Parametros.Add(New GeneradorReportes.Parametro("titulo", "Diario de Pagos"))
                    r.SourceFile = My.Settings.RutaReportes & "\infpagos.rdl"
            End Select

            If Me.ReporteDiario = General.ReporteDiario.IVACOMPRAS Then
                If Me.CheckBoxTodosGastosVar.Checked = True Then
                    r.Parametros.Add(New GeneradorReportes.Parametro("filtraGasto", 0))
                Else
                    r.Parametros.Add(New GeneradorReportes.Parametro("filtraGasto", 1))
                    r.Parametros.Add(New GeneradorReportes.Parametro("codGastoV", CtlComboGastosVar.SelectedValue))
                End If
                If Me.RadioButtonPeriodo.Checked Then
                    r.Parametros.Add(New GeneradorReportes.Parametro("periodo", Me.DateTimePickerPeríodo.Value.ToString("yyyyMM")))
                    r.Parametros.Add(New GeneradorReportes.Parametro("fdesde", Me.DateTimePickerDesde.MinDate))
                    r.Parametros.Add(New GeneradorReportes.Parametro("fhasta", Me.DateTimePickerHasta.MaxDate))
                Else
                    r.Parametros.Add(New GeneradorReportes.Parametro("periodo", "%"))
                    r.Parametros.Add(New GeneradorReportes.Parametro("fdesde", Me.DateTimePickerDesde.Value))
                    r.Parametros.Add(New GeneradorReportes.Parametro("fhasta", Me.DateTimePickerHasta.Value))
                End If
            Else
                r.Parametros.Add(New GeneradorReportes.Parametro("fdesde", Me.DateTimePickerDesde.Value))
                r.Parametros.Add(New GeneradorReportes.Parametro("fhasta", Me.DateTimePickerHasta.Value))
            End If
            

            If CheckBoxTodos.Checked = False Then
                r.Parametros.Add(New GeneradorReportes.Parametro("cdesde", Me.CtlComboCodigo.SelectedValue))
                r.Parametros.Add(New GeneradorReportes.Parametro("chasta", Me.CtlComboCodigo.SelectedValue))
            End If

            If Me.CheckBoxConceptos.Checked = True Then
                If RadioButtonT.Checked Then
                    r.Parametros.Add(New GeneradorReportes.Parametro("tipo", "T"))
                ElseIf RadioButtonP.Checked Then
                    r.Parametros.Add(New GeneradorReportes.Parametro("tipo", "P"))
                Else
                    r.Parametros.Add(New GeneradorReportes.Parametro("tipo", "F"))
                End If
            Else
                r.Parametros.Add(New GeneradorReportes.Parametro("tipo", "U"))
                r.Parametros.Add(New GeneradorReportes.Parametro("concepto", Me.CtlComboConceptos.SelectedValue))
            End If
            

            SetearEncabezadosReporte(r)

            r.ShowReport()

            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Atención: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReporte.Click
        Reporte()
    End Sub

    Private Sub InicializarCombos()
        Select Case Me.ReporteDiario
            Case General.ReporteDiario.COBRANZAS, General.ReporteDiario.IVAVENTAS
                InicializarComboCliente()
                InicializarComboConcepto()
            Case General.ReporteDiario.IVACOMPRAS
                InicializarComboProveedor()
                InicializarComboGastoVariable()
            Case General.ReporteDiario.PAGOS
                InicializarComboProveedor()
        End Select
    End Sub

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F12 : Reporte()
            Case Keys.Escape : Cancelar()
            Case Keys.Return : SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub InicializarComboProveedor()

        Dim repositorio As New CapaLogica.ProveedorCLog

        With Me.CtlComboCodigo
            .ValueMember = "Id"
            .DisplayMember = "NombreyCodigo"
            .DataSource = repositorio.GetAll
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub InicializarComboCliente()
        Dim repositorio As New CapaLogica.ClienteCLog

        With Me.CtlComboCodigo
            .ValueMember = "Id"
            .DisplayMember = "NombreyCodigo"
            .DataSource = repositorio.GetAll
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            .SelectedIndex = -1
        End With

    End Sub

    Private Sub InicializarComboGastoVariable()
        'Dim repositorio As New CapaLogica.GastosvCLog
        'With Me.CtlComboGastosVar
        '    .ValueMember = "Codigo"
        '    .DisplayMember = "NombreyCodigo"
        '    .DataSource = repositorio.GetAll()
        '    .AutoCompleteMode = AutoCompleteMode.Suggest
        '    .AutoCompleteSource = AutoCompleteSource.ListItems
        '    .Inicializar()
        '    .SelectedIndex = -1
        'End With
    End Sub

    Private Sub InicializarComboConcepto()

        Dim repositorio As New CapaLogica.TipocomprobanteCLog

        With Me.CtlComboConceptos
            .ValueMember = "Codigo"
            .DisplayMember = "Descripcion"
            .DataSource = repositorio.GetCbtesElectronicos
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub CheckBoxTodos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBoxTodos.CheckedChanged
        If Not CheckBoxTodos.Checked Then
            Me.CtlComboCodigo.Enabled = True
            Me.CtlComboCodigo.FocoDetalle()
        Else
            Me.CtlComboCodigo.Enabled = False
        End If
    End Sub

    Private Sub CheckBoxTodosGastosVar_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxTodosGastosVar.CheckedChanged
        If Not CheckBoxTodosGastosVar.Checked Then
            Me.CtlComboGastosVar.Enabled = True
            Me.CtlComboGastosVar.FocoDetalle()
        Else
            Me.CtlComboGastosVar.Enabled = False
        End If
    End Sub

    Private Sub RadioButtonPeriodo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonPeriodo.CheckedChanged
        a_Ingreso()
    End Sub

    Private Sub RadioButtonFecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonFecha.CheckedChanged
        a_Ingreso()
    End Sub

    Private Sub a_Ingreso()
        'Período
        If RadioButtonPeriodo.Checked = True Then
            DateTimePickerPeríodo.Enabled = True
            DateTimePickerPeríodo.Focus()
        Else
            DateTimePickerPeríodo.Enabled = False
        End If

        'Entorno de Fechas
        If RadioButtonFecha.Checked = True Then
            DateTimePickerDesde.Enabled = True
            DateTimePickerHasta.Enabled = True
            DateTimePickerDesde.Focus()
        Else
            DateTimePickerDesde.Enabled = False
            DateTimePickerHasta.Enabled = False
        End If
    End Sub

    Private Sub CheckBoxConceptos_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxConceptos.CheckedChanged
        If Not CheckBoxConceptos.Checked Then
            Me.CtlComboConceptos.Enabled = True
            Me.CtlComboConceptos.FocoDetalle()
        Else
            Me.CtlComboConceptos.Enabled = False
        End If
    End Sub
End Class