Public Class FormDiario



    'entidad
    Property Entidad As Entidades.Vendedor

    'repositorios de tablas
    Private _repositorio As New CapaLogica.FinancieroCLog
    Private _repositorioCtas As New CapaLogica.CuentabancariaCLog
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

        Me.Text = "Diario de Cuenta Financiera"

        Me.ComboBoxCbte.Visible = gUsuario.GodMode

        'If gUsuario.Perfil = PERFIL_MOSTRADOR Then
        '    VerMovimientos()
        'End If


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

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Cancelar()
    End Sub

    Private Sub Cancelar()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub VerMovimientos()

        If Not Me.ComboBoxCuentas.SelectedItem Is Nothing Then
            PoblarGrilla()
        Else
            Me.ComboBoxCuentas.Focus()
        End If

    End Sub

    Private Sub BtnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsultar.Click
        VerMovimientos()
    End Sub

    Private Sub ComboBoxVendedors_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub InicializarCombos()
        InicializarComboCuentas()
        InicializarComboFechas()
    End Sub

    Private Sub InicializarComboFechas()
        Dim ydesde, yhasta As Integer

        ydesde = 2015
        yhasta = Date.Today.Year

        Me.ComboBoxFecha.Items.Clear()

        For y As Integer = ydesde To yhasta
            For m As Integer = 1 To 12
                For d As Integer = 1 To Date.DaysInMonth(y, m)
                    Me.ComboBoxFecha.Items.Add(CDate(d.ToString.PadLeft(2, "0") & "/" & m.ToString.PadLeft(2, "0") & "/" & y.ToString.PadLeft(4, "0")).ToString("dd/MM/yyyy"))
                Next
            Next
        Next

        Me.ComboBoxFecha.SelectedItem = Date.Today.ToString("dd/MM/yyyy")

    End Sub

    Private Sub InicializarComboCuentas()

        Dim source As List(Of Entidades.Cuentabancaria)

        With Me.ComboBoxCuentas

            .Items.Clear()

            'limito las cuentas al perfil mostrador
            'If gUsuario.Perfil = PERFIL_MOSTRADOR Then
            '    source = _repositorioCtas.GetAllWithValue(_repositorioParam.GetByNombre("CuentaBancariaMostrador").Valorpredeterminado)
            'Else
            source = _repositorioCtas.GetCuentasDisponibles
            'End If

            For Each c As Entidades.Cuentabancaria In source
                If c.Codigo <> CUENTA_CARTERA Then
                    .Items.Add(c)
                End If
            Next

            .DropDownStyle = ComboBoxStyle.DropDownList

            .SelectedIndex = -1

            'If .Items.Count <> 0 Then
            '    If gUsuario.Perfil = PERFIL_MOSTRADOR Then
            '        .SelectedIndex = 0
            '    End If
            'End If

        End With
    End Sub

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F12 : VerMovimientos()
            Case Keys.F3 : Buscar()
            Case Keys.F5 : Imprimir()
            Case Keys.Escape : Cancelar()
            Case Keys.Return : SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub PoblarGrilla()

        Dim report As New GeneradorReportes.Reporte
        Dim saldoanterior As Double = 0

        Try

            'cuenta,fecha,titulo,saldoanterior

            saldoanterior = _repositorio.GetSaldo(Me.ComboBoxCuentas.Text, CDate(Me.ComboBoxFecha.Text).AddDays(-1))

            report.Nombre = Me.Text
            report.SourceFile = My.Settings.RutaReportes & "\infdiario.rdl"
            report.Parametros.Add(New GeneradorReportes.Parametro("titulo", "Diario de Caja de la Cuenta " & Me.ComboBoxCuentas.Text))
            report.Parametros.Add(New GeneradorReportes.Parametro("cuenta", Me.ComboBoxCuentas.Text))
            report.Parametros.Add(New GeneradorReportes.Parametro("fecha", CDate(Me.ComboBoxFecha.Text).ToString("yyyy/MM/dd")))
            report.Parametros.Add(New GeneradorReportes.Parametro("saldoanterior", saldoanterior))

            If gUsuario.GodMode Then
                Select Case Me.ComboBoxCbte.SelectedIndex
                    Case 1
                        report.Parametros.Add(New GeneradorReportes.Parametro("tipo", "F"))
                    Case 2
                        report.Parametros.Add(New GeneradorReportes.Parametro("tipo", "P"))
                    Case Else
                        report.Parametros.Add(New GeneradorReportes.Parametro("tipo", "T"))
                End Select
            Else
                report.Parametros.Add(New GeneradorReportes.Parametro("tipo", "F"))
            End If


            Me.ReportViewer.Parameters = report.Parametros.ToString
            Me.ReportViewer.SourceFile = New Uri(report.SourceFile)
            Me.ReportViewer.ReportName = report.Nombre
            Me.ReportViewer.Show()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    
    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        Call Imprimir()
    End Sub

    Private Sub Imprimir()

        If Me.ComboBoxCuentas.SelectedItem Is Nothing Then
            Exit Sub
        End If

        Dim pd As New Printing.PrintDocument()
        pd.DocumentName = ReportViewer.ReportName
        pd.PrinterSettings.FromPage = 1
        pd.PrinterSettings.ToPage = ReportViewer.PageCount
        pd.PrinterSettings.MaximumPage = ReportViewer.PageCount
        pd.PrinterSettings.MinimumPage = 1

        If (ReportViewer.PageWidth > ReportViewer.PageHeight) Then
            pd.DefaultPageSettings.Landscape = True
        Else
            pd.DefaultPageSettings.Landscape = False
        End If

        Dim dlg As New PrintDialog()
        dlg.Document = pd
        dlg.AllowSelection = True
        dlg.AllowSomePages = True
        If (dlg.ShowDialog() = DialogResult.OK) Then
            Try
                If (pd.PrinterSettings.PrintRange = Printing.PrintRange.Selection) Then
                    pd.PrinterSettings.FromPage = ReportViewer.PageCurrent
                End If

                ReportViewer.Print(pd)

            Catch ex As Exception
                MessageBox.Show("Print error: " + ex.Message)
            End Try

        End If



    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Buscar()
    End Sub

    Private Sub Buscar()
        Me.ReportViewer.ShowFindPanel = Not Me.ReportViewer.ShowFindPanel
    End Sub
End Class