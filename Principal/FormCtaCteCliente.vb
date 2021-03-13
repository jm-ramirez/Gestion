Public Class FormCtaCteCliente

    'repositorios de tablas
    Private _repositorioClientes As New CapaLogica.ClienteCLog

    Property ReporteAGenerar As ReporteCtaCte = ReporteCtaCte.SALDOS

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

        If ReporteAGenerar = ReporteCtaCte.PENDIENTES Then
            Me.BtnEmail.Visible = True
            Me.ToolStripSeparator6.Visible = True
        Else
            Me.BtnEmail.Visible = False
            Me.ToolStripSeparator6.Visible = False
        End If

        If ReporteAGenerar = ReporteCtaCte.EDOREF Then
            Me.DateTimePickerDesde.Value = Convert.ToDateTime("01/01/2000")
        Else
            Me.DateTimePickerDesde.Value = Convert.ToDateTime("01/01/" & Now.Year())
        End If
        Me.DateTimePickerHasta.Value = Date.Today

        Select Case Me.ReporteAGenerar
            Case ReporteCtaCte.SALDOS, ReporteCtaCte.PENDIENTES, ReporteCtaCte.VENCIMIENTO, ReporteCtaCte.ANTICIPOS
                Me.LabelDesde.Visible = False
                Me.DateTimePickerDesde.Visible = False
        End Select

        If gUsuario.GodMode Then
            GroupBoxComprobantes.Visible = True
            RadioButtonT.Checked = True
        Else
            GroupBoxComprobantes.Visible = False
            RadioButtonF.Checked = True
        End If

        Me.CheckBoxTodos.Checked = True
        Me.CtlComboClientes.Enabled = False

        Select Case Me.ReporteAGenerar
            Case ReporteCtaCte.SALDOS, ReporteCtaCte.PENDIENTES, ReporteCtaCte.VENCIMIENTO, ReporteCtaCte.ANTICIPOS
                Me.DateTimePickerHasta.Focus()
                Me.DateTimePickerHasta.Select()
            Case Else
                Me.DateTimePickerDesde.Focus()
                Me.DateTimePickerDesde.Select()
        End Select

    End Sub

    Private Sub FormCtaCteCliente_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        Me.DateTimePickerDesde.Focus()

        Select Case Me.ReporteAGenerar
            Case ReporteCtaCte.EDOCTA
                Me.Text = "Estado de Cuenta"
            Case ReporteCtaCte.EDOREF
                Me.Text = "Estado de Cuenta por Referencia"
            Case ReporteCtaCte.PENDIENTES
                Me.Text = "Facturas Pendientes"
            Case ReporteCtaCte.VENCIMIENTO
                Me.Text = "Facturas Pendientes x Vto."
            Case ReporteCtaCte.SALDOS
                Me.Text = "Saldos"
            Case ReporteCtaCte.ANTICIPOS
                Me.Text = "Anticipos"
        End Select

    End Sub

    Private Sub FormCtaCteCliente_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
                    AddHandler c.PreviewKeyDown, AddressOf CustomPreviewKeyDown
            End Select
        Next

        AddHandler Me.KeyDown, AddressOf FormularioKeyDown

    End Sub

    Private Sub CustomPreviewKeyDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs)
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
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

            If Not Me.CheckBoxTodos.Checked Then
                If Me.CtlComboClientes.SelectedItem Is Nothing Then
                    Throw New Exception("El cliente seleccionado no es válido")
                End If
            End If

            Dim r As New GeneradorReportes.Reporte
            Dim c As Entidades.Cliente = DirectCast(Me.CtlComboClientes.SelectedItem, Entidades.Cliente)

            r.Nombre = Me.Text

            Select Case ReporteAGenerar
                Case ReporteCtaCte.SALDOS
                    r.SourceFile = My.Settings.RutaReportes & "\infsaldoscliente.rdl"
                    r.Parametros.Add(New GeneradorReportes.Parametro("titulo", "Informe de Saldos de Clientes al " & Me.DateTimePickerHasta.Value.Date))

                    r.Parametros.Add(New GeneradorReportes.Parametro("fdesde", Me.DateTimePickerHasta.Value.ToString("yyyy/MM/dd")))
                    r.Parametros.Add(New GeneradorReportes.Parametro("fhasta", Me.DateTimePickerHasta.Value.ToString("yyyy/MM/dd")))

                Case ReporteCtaCte.EDOCTA
                    r.SourceFile = My.Settings.RutaReportes & "\infedoctacliente.rdl"
                    r.Parametros.Add(New GeneradorReportes.Parametro("titulo", "Estado de Cuenta de Clientes - " & Me.DateTimePickerDesde.Value.Date & " al " & Me.DateTimePickerHasta.Value.Date))

                    r.Parametros.Add(New GeneradorReportes.Parametro("fdesde", Me.DateTimePickerDesde.Value.ToString("yyyy/MM/dd")))
                    r.Parametros.Add(New GeneradorReportes.Parametro("fhasta", Me.DateTimePickerHasta.Value.ToString("yyyy/MM/dd")))
                Case ReporteCtaCte.EDOREF
                    r.SourceFile = My.Settings.RutaReportes & "\infedorefcliente.rdl"
                    r.Parametros.Add(New GeneradorReportes.Parametro("titulo", "Estado de Cuenta por Ref. de Clientes - " & Me.DateTimePickerDesde.Value.Date & " al " & Me.DateTimePickerHasta.Value.Date))

                    r.Parametros.Add(New GeneradorReportes.Parametro("fdesde", Me.DateTimePickerDesde.Value.ToString("yyyy/MM/dd")))
                    r.Parametros.Add(New GeneradorReportes.Parametro("fhasta", Me.DateTimePickerHasta.Value.ToString("yyyy/MM/dd")))
                Case ReporteCtaCte.PENDIENTES
                    r.SourceFile = My.Settings.RutaReportes & "\infpendientescliente.rdl"
                    r.Parametros.Add(New GeneradorReportes.Parametro("titulo", "Facturas Pendientes de Clientes al " & Me.DateTimePickerHasta.Value.Date))

                    r.Parametros.Add(New GeneradorReportes.Parametro("fdesde", Me.DateTimePickerHasta.Value.ToString("yyyy/MM/dd")))
                    r.Parametros.Add(New GeneradorReportes.Parametro("fhasta", Me.DateTimePickerHasta.Value.ToString("yyyy/MM/dd")))

                Case ReporteCtaCte.VENCIMIENTO
                    r.SourceFile = My.Settings.RutaReportes & "\infpendientesvtocliente.rdl"
                    r.Parametros.Add(New GeneradorReportes.Parametro("titulo", "Facturas Pendientes x Vto. de Clientes al " & Me.DateTimePickerHasta.Value.Date))

                    r.Parametros.Add(New GeneradorReportes.Parametro("fdesde", Me.DateTimePickerHasta.Value.ToString("yyyy/MM/dd")))
                    r.Parametros.Add(New GeneradorReportes.Parametro("fhasta", Me.DateTimePickerHasta.Value.ToString("yyyy/MM/dd")))


                Case ReporteCtaCte.ANTICIPOS
                    r.SourceFile = My.Settings.RutaReportes & "\infanticiposcliente.rdl"
                    r.Parametros.Add(New GeneradorReportes.Parametro("titulo", "Anticipos de Clientes al " & Me.DateTimePickerHasta.Value.Date))

                    r.Parametros.Add(New GeneradorReportes.Parametro("fdesde", Me.DateTimePickerHasta.Value.ToString("yyyy/MM/dd")))
                    r.Parametros.Add(New GeneradorReportes.Parametro("fhasta", Me.DateTimePickerHasta.Value.ToString("yyyy/MM/dd")))
            End Select

            If Me.CheckBoxTodos.Checked Then

                r.Parametros.Add(New GeneradorReportes.Parametro("cdesde", "2"))
                r.Parametros.Add(New GeneradorReportes.Parametro("chasta", "999999"))
                r.Parametros.Add(New GeneradorReportes.Parametro("nombre", "Todos"))
            Else
                r.Parametros.Add(New GeneradorReportes.Parametro("cdesde", c.Id))
                r.Parametros.Add(New GeneradorReportes.Parametro("chasta", c.Id))
                r.Parametros.Add(New GeneradorReportes.Parametro("nombre", c.Nombre))
            End If

            If RadioButtonT.Checked Then
                r.Parametros.Add(New GeneradorReportes.Parametro("tipo", "T"))
            ElseIf RadioButtonP.Checked Then
                r.Parametros.Add(New GeneradorReportes.Parametro("tipo", "P"))
            Else
                r.Parametros.Add(New GeneradorReportes.Parametro("tipo", "F"))
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
        InicializarComboClientes()
    End Sub

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F12 : Reporte()
            Case Keys.F8
                If ReporteAGenerar = ReporteCtaCte.PENDIENTES Then
                    Email()
                End If
            Case Keys.Escape : Cancelar()
            Case Keys.Return : SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub Email()
        Try

            If Me.CheckBoxTodos.Checked Then
                Throw New Exception("Debe Seleccionar solo un cliente")
            End If

            If Not Me.CheckBoxTodos.Checked Then
                If Me.CtlComboClientes.SelectedItem Is Nothing Then
                    Throw New Exception("El cliente seleccionado no es válido")
                End If
            End If

            Dim f As New FormEmail
            f.Modo = 1
            f.ReporteAGenerar = ReporteAGenerar
            f.fechaDesde = Me.DateTimePickerDesde.Value.ToString("yyyy/MM/dd")
            f.fechaHasta = Me.DateTimePickerHasta.Value.ToString("yyyy/MM/dd")
            f.idCliente = DirectCast(Me.CtlComboClientes.SelectedItem, Entidades.Cliente).Id
            f.nombreCliente = DirectCast(Me.CtlComboClientes.SelectedItem, Entidades.Cliente).Nombre
            f.Email = DirectCast(Me.CtlComboClientes.SelectedItem, Entidades.Cliente).Email & IIf(Len(DirectCast(Me.CtlComboClientes.SelectedItem, Entidades.Cliente).Email2) > 0, ", " & DirectCast(Me.CtlComboClientes.SelectedItem, Entidades.Cliente).Email2, "") & IIf(Len(DirectCast(Me.CtlComboClientes.SelectedItem, Entidades.Cliente).Email3) > 0, ", " & DirectCast(Me.CtlComboClientes.SelectedItem, Entidades.Cliente).Email3, "")

            f.ShowDialog()
            f.Dispose()

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub InicializarComboClientes()
        Dim repoparametro As New CapaLogica.ParametroCLog
        With Me.CtlComboClientes
            .ValueMember = "Id"
            .DisplayMember = "NombreyCodigo"
            .DataSource = _repositorioClientes.GetAll.Where(Function(x) x.Id <> repoparametro.GetByNombre("ClienteVarios").Valorpredeterminado).ToList()
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub CheckBoxTodos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBoxTodos.CheckedChanged
        If Not CheckBoxTodos.Checked Then
            Me.CtlComboClientes.Enabled = True
            Me.CtlComboClientes.FocoDetalle()
        Else
            Me.CtlComboClientes.Enabled = False
        End If
    End Sub

    Private Sub BtnEmail_Click(sender As System.Object, e As System.EventArgs) Handles BtnEmail.Click
        Email()
    End Sub
End Class