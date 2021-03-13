Public Class FormInformeConsumoArticulo
    Private _repositorioArt As New CapaLogica.ArticuloCLog

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
        InicializarComboArticulo()
        Me.DateTimePickerDesde.Value = CDate("01/" & Date.Today.Month & "/" & Date.Today.Year)
        Me.DateTimePickerHasta.Value = CDate(Date.Today)
        Me.CheckBoxTodos.Checked = True

        Me.DateTimePickerDesde.Focus()
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
  
    Private Sub InicializarComboArticulo()

        With Me.CtlComboArticulo
            .ValueMember = "Codigo"
            .DisplayMember = "NombreyCodigo"
            .DataSource = _repositorioArt.GetAll.OrderBy(Function(x) x.Codigo).ToList()
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .DropDownStyle = ComboBoxStyle.DropDownList
            '.FormularioDeAlta = FormMatCpra
            .Inicializar()
            .SelectedIndex = -1
        End With

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
            If Me.DateTimePickerDesde.Value > Me.DateTimePickerHasta.Value Then
                Me.DateTimePickerDesde.Focus()
                Throw New Exception("Las fechas ingresadas no son válidas")
            End If

            If Me.CheckBoxTodos.Checked = False And Me.CtlComboArticulo.SelectedItem Is Nothing Then
                Me.CtlComboArticulo.FocoDetalle()
                Throw New Exception("El Artículo seleccionado no es válido")
            End If

            Dim r As New GeneradorReportes.Reporte

            r.Nombre = Me.Text

            r.SourceFile = My.Settings.RutaReportes & "\infConsumoArticulo.rdl"

            SetearEncabezadosReporte(r)

            r.Parametros.Add(New GeneradorReportes.Parametro("titulo", Me.Text))

            r.Parametros.Add(New GeneradorReportes.Parametro("fdesde", Format(Me.DateTimePickerDesde.Value, "yyyy/MM/dd")))
            r.Parametros.Add(New GeneradorReportes.Parametro("fhasta", Format(Me.DateTimePickerHasta.Value, "yyyy/MM/dd")))

            If Me.CheckBoxTodos.Checked = False Then
                r.Parametros.Add(New GeneradorReportes.Parametro("filtra", 1))
                r.Parametros.Add(New GeneradorReportes.Parametro("codMat", Me.CtlComboArticulo.SelectedValue))
                r.Parametros.Add(New GeneradorReportes.Parametro("titulo2", "Artículo: (" & Me.CtlComboArticulo.SelectedValue & ") " & DirectCast(Me.CtlComboArticulo.SelectedItem, Entidades.Articulo).Nombre))
            Else
                r.Parametros.Add(New GeneradorReportes.Parametro("filtra", 0))
                r.Parametros.Add(New GeneradorReportes.Parametro("titulo2", "Todos los Artículos"))
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


    Private Sub CheckBoxTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxTodos.CheckedChanged
        If Not CheckBoxTodos.Checked Then
            Me.CtlComboArticulo.Enabled = True
            Me.CtlComboArticulo.FocoDetalle()
        Else
            Me.CtlComboArticulo.Enabled = False
        End If
    End Sub

    Private Sub FormInformeConsumoArticulo_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        Me.Text = "Informe de Consumo por Artículo"
    End Sub

    Private Sub FormInformeConsumoArticulo_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InicializarFormulario()
    End Sub
End Class