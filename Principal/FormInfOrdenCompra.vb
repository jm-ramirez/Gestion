Public Class FormInfOrdenCompra

    Private _repositorioCli As New CapaLogica.ClienteCLog
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

        InicializarComboClientes()

        Me.CtlComboClientesDesde.Focus()

    End Sub

    Private Sub FormInfSaldoConcepto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InicializarFormulario()
    End Sub

    Private Sub FormEmisionFichaStock_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Text = "Informe de Ordenes de Compra"
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
    Private Sub InicializarComboClientes()

        With Me.CtlComboClientesDesde
            .ValueMember = "Codigo"
            .DisplayMember = "NombreyCodigo"
            .DataSource = _repositorioCli.GetAll()
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            '.DropDownStyle = ComboBoxStyle.DropDownList
            .FormularioDeAlta = FormCliente
            .Inicializar()
            If .Items.Count > 0 Then
                .SelectedIndex = 0
            Else
                .SelectedIndex = -1
            End If
            '.SelectedIndex = -1
        End With

        With Me.CtlComboClientesHasta
            .ValueMember = "Codigo"
            .DisplayMember = "NombreyCodigo"
            .DataSource = _repositorioCli.GetAll()
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            '.DropDownStyle = ComboBoxStyle.DropDownList
            .FormularioDeAlta = FormCliente
            .Inicializar()
            If .Items.Count > 0 Then
                .SelectedIndex = .Items.Count - 1
            Else
                .SelectedIndex = -1
            End If
            '.SelectedIndex = -1
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
            
            If Me.CtlComboClientesDesde.SelectedItem Is Nothing Then
                Throw New Exception("El Cliente seleccionado no es válido")
                Me.CtlComboClientesDesde.Focus()
            End If

            If Me.CtlComboClientesHasta.SelectedItem Is Nothing Then
                Throw New Exception("El Cliente seleccionado no es válido")
                Me.CtlComboClientesHasta.Focus()
            End If

            Dim r As New GeneradorReportes.Reporte

            r.Nombre = Me.Text

            r.SourceFile = My.Settings.RutaReportes & "\infOrdenCompra.rdl"

            SetearEncabezadosReporte(r)



            r.Parametros.Add(New GeneradorReportes.Parametro("cdesde", DirectCast(Me.CtlComboClientesDesde.SelectedItem, Entidades.Cliente).Codigo))
            r.Parametros.Add(New GeneradorReportes.Parametro("chasta", DirectCast(Me.CtlComboClientesHasta.SelectedItem, Entidades.Cliente).Codigo))

            If Me.RadioButtonPendientes.Checked = True Then
                r.Parametros.Add(New GeneradorReportes.Parametro("filtro", 0))
                r.Parametros.Add(New GeneradorReportes.Parametro("titulo", "Informe de Ordenes de Compra Pendientes"))
            ElseIf Me.RadioButtonSatisfechas.Checked = True Then
                r.Parametros.Add(New GeneradorReportes.Parametro("filtro", 1))
                r.Parametros.Add(New GeneradorReportes.Parametro("titulo", "Informe de Ordenes de Compra Satisfechas"))
            ElseIf Me.RadioButtonTodas.Checked = True Then
                r.Parametros.Add(New GeneradorReportes.Parametro("filtro", 2))
                r.Parametros.Add(New GeneradorReportes.Parametro("titulo", "Informe de Ordenes de Compra"))
            End If

            If Me.RadioButtonPedido.Checked = True Then
                r.Parametros.Add(New GeneradorReportes.Parametro("visible", 1))
            ElseIf Me.RadioButtonArticulo.Checked = True Then
                r.Parametros.Add(New GeneradorReportes.Parametro("visible", 0))
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


    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F12 : Reporte()
            Case Keys.Escape : Cancelar()
            Case Keys.Return : SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub FormInfOrdenCompra_PaddingChanged(sender As Object, e As System.EventArgs) Handles Me.PaddingChanged

    End Sub
End Class