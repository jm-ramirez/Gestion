Public Class FormPagoProveedorCtaCte

    'repositorios de tablas
    Private _repositorioProveedores As New CapaLogica.ProveedorCLog

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

        Me.DateTimePickerDesde.Value = Convert.ToDateTime("01/01/" & Now.Year())
        Me.DateTimePickerHasta.Value = Date.Today

        'Select Case Me.ReporteAGenerar
        '    Case ReporteCtaCte.SALDOS, ReporteCtaCte.PENDIENTES, ReporteCtaCte.ANTICIPOS
        '        Me.LabelDesde.Visible = False
        '        Me.DateTimePickerDesde.Visible = False
        'End Select

        'If gUsuario.GodMode Then
        'GroupBoxComprobantes.Visible = True
        'RadioButtonT.Checked = True
        'Else
        'GroupBoxComprobantes.Visible = False
        'Me.RadioButtonProveedor.Checked = True
        'End If

        Me.CheckBoxTodos.Checked = True
        Me.CtlComboProveedores.Enabled = False

        Me.DateTimePickerDesde.Focus()
        Me.DateTimePickerDesde.Select()
    End Sub

    Private Sub FormPagoProveedorCtaCte_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        Me.DateTimePickerDesde.Focus()

        Me.Text = "Resumen de Pago a Proveedores (en Cta. Cte.)"
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
                If Me.CtlComboProveedores.SelectedItem Is Nothing Then
                    Throw New Exception("El Proveedor seleccionado no es válido")
                    Me.CtlComboProveedores.FocoDetalle()
                End If
            End If

            Dim r As New GeneradorReportes.Reporte
            Dim c As Entidades.Proveedor = DirectCast(Me.CtlComboProveedores.SelectedItem, Entidades.Proveedor)

            r.Nombre = Me.Text

            r.SourceFile = My.Settings.RutaReportes & "\infpagoproveedorctacte.rdl"
            r.Parametros.Add(New GeneradorReportes.Parametro("titulo", "Estado de Cuenta de Proveedores al " & Me.DateTimePickerHasta.Value.Date))

            r.Parametros.Add(New GeneradorReportes.Parametro("fdesde", Me.DateTimePickerDesde.Value.ToString("yyyy/MM/dd")))
            r.Parametros.Add(New GeneradorReportes.Parametro("fhasta", Me.DateTimePickerHasta.Value.ToString("yyyy/MM/dd")))

            If Me.CheckBoxTodos.Checked Then
                'Id=0 Es Proveedor de Varios
                r.Parametros.Add(New GeneradorReportes.Parametro("cdesde", "0"))
                r.Parametros.Add(New GeneradorReportes.Parametro("chasta", "999999"))
            Else
                r.Parametros.Add(New GeneradorReportes.Parametro("cdesde", c.Id))
                r.Parametros.Add(New GeneradorReportes.Parametro("chasta", c.Id))
                r.Parametros.Add(New GeneradorReportes.Parametro("nombre", c.Nombre))
            End If

            r.Parametros.Add(New GeneradorReportes.Parametro("tipo", "F"))
            
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
        InicializarComboProveedores()
    End Sub

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F12 : Reporte()
            Case Keys.Escape : Cancelar()
            Case Keys.Return : SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub InicializarComboProveedores()
        Dim repoparametro As New CapaLogica.ParametroCLog
        With Me.CtlComboProveedores
            .ValueMember = "Id"
            .DisplayMember = "NombreyCodigo"
            .DataSource = _repositorioProveedores.GetAll.Where(Function(x) x.Id <> repoparametro.GetByNombre("ProveedorGastos").Valorpredeterminado).ToList()
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub CheckBoxTodos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBoxTodos.CheckedChanged
        If Not CheckBoxTodos.Checked Then
            Me.CtlComboProveedores.Enabled = True
            Me.CtlComboProveedores.FocoDetalle()
        Else
            Me.CtlComboProveedores.Enabled = False
        End If
    End Sub

    Private Sub FormPagoProveedorCtaCte_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InicializarFormulario()
    End Sub
End Class