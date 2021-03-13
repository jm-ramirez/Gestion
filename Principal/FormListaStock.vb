Public Class FormListaStock

    Property TipoReporte As ReporteStock

    'repositorios de tablas
    Private _repositorioRubros As New CapaLogica.RubroCLog
    Private _repositorioArticulos As New CapaLogica.ArticuloCLog
    Private _repositorioListas As New CapaLogica.ListadeprecioCLog

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

        Me.CheckBoxTodos.Checked = True
        Me.CheckBoxArticulos.Checked = True

        Me.DateTimePickeInicial.Value = "01/" & Date.Today.ToString("MM/yyyy")
        Me.DateTimePickerTope.Value = Date.Today

        Me.LabelInicial.Visible = (Me.TipoReporte = ReporteStock.FICHA_STOCK)
        Me.DateTimePickeInicial.Visible = (Me.TipoReporte = ReporteStock.FICHA_STOCK)
        'Me.GroupBoxValorizado.Visible = (Me.TipoReporte = ReporteStock.EXISTENCIAS)

        If gUsuario.GodMode Then
            GroupBoxComprobantes.Visible = True
            RadioButtonT.Checked = True
        Else
            GroupBoxComprobantes.Visible = False
            RadioButtonF.Checked = True
        End If
    End Sub

    Private Sub FormVendedor_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        Select Case Me.TipoReporte
            Case ReporteStock.EXISTENCIAS
                Me.Text = "Listado de Existencia de Artículos"
            Case ReporteStock.FICHA_STOCK
                Me.Text = "Ficha de Movimientos de Artículos"
            Case ReporteStock.FALTANTES
                Me.Text = "Listado de Artículos Faltantes"
            Case ReporteStock.INVENTARIO
                Me.Text = "Listado de Inventarios de Artículos"
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

            If Me.CtlComboRubro.SelectedItem Is Nothing And Not CheckBoxTodos.Checked Then
                Throw New Exception("El rubro seleccionado no es válido")
            End If

            If Me.CtlCustomArticulo.SelectedItem Is Nothing And Not CheckBoxArticulos.Checked Then
                Throw New Exception("El artículo seleccionado no es válido")
            End If

            Dim r As New GeneradorReportes.Reporte
            Dim c As Entidades.Rubro = DirectCast(Me.CtlComboRubro.SelectedItem, Entidades.Rubro)
            Dim a As Entidades.Articulo = DirectCast(Me.CtlCustomArticulo.SelectedItem, Entidades.Articulo)


            r.Nombre = Me.Text

            Select Case Me.TipoReporte
                Case ReporteStock.EXISTENCIAS
                    r.SourceFile = My.Settings.RutaReportes & "\lstexistencia.rdl"

                    'If RadioButtonCosto.Checked Then
                    '    r.Parametros.Add(New GeneradorReportes.Parametro("valorizado", "C"))
                    'ElseIf RadioButtonK.Checked Then
                    '    r.Parametros.Add(New GeneradorReportes.Parametro("valorizado", "K"))
                    'ElseIf RadioButtonM.Checked Then
                    '    r.Parametros.Add(New GeneradorReportes.Parametro("valorizado", "M"))
                    'ElseIf RadioButtonNo.Checked Then
                    '    r.Parametros.Add(New GeneradorReportes.Parametro("valorizado", "N"))
                    'Else
                    '    r.Parametros.Add(New GeneradorReportes.Parametro("valorizado", "R"))
                    'End If


                Case ReporteStock.FICHA_STOCK
                    r.SourceFile = My.Settings.RutaReportes & "\lstfichamovimiento.rdl"
                    r.Parametros.Add(New GeneradorReportes.Parametro("fdesde", Me.DateTimePickeInicial.Value))
                Case ReporteStock.FALTANTES
                    r.SourceFile = My.Settings.RutaReportes & "\lstfaltantes.rdl"
                Case ReporteStock.INVENTARIO
                    r.SourceFile = My.Settings.RutaReportes & "\lstinventarios.rdl"
            End Select


            r.Parametros.Add(New GeneradorReportes.Parametro("fhasta", Me.DateTimePickerTope.Value))

            If CheckBoxTodos.Checked Then
                r.Parametros.Add(New GeneradorReportes.Parametro("trubro", 0))
            Else
                r.Parametros.Add(New GeneradorReportes.Parametro("trubro", 1))
                r.Parametros.Add(New GeneradorReportes.Parametro("codRubro", c.Codigo))
            End If

            If CheckBoxArticulos.Checked Then
                r.Parametros.Add(New GeneradorReportes.Parametro("tarticulo", 0))
            Else
                r.Parametros.Add(New GeneradorReportes.Parametro("tarticulo", 1))
                r.Parametros.Add(New GeneradorReportes.Parametro("codArticulo", a.Codigo))
            End If

            If RadioButtonT.Checked Then
                r.Parametros.Add(New GeneradorReportes.Parametro("tipo", "T"))
            ElseIf RadioButtonP.Checked Then
                r.Parametros.Add(New GeneradorReportes.Parametro("tipo", "P"))
            Else
                r.Parametros.Add(New GeneradorReportes.Parametro("tipo", "F"))
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

    Private Sub InicializarCombos()
        InicializarComboRubros()
        InicializarComboArticulos()
    End Sub

    

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F12 : Reporte()
            Case Keys.Escape : Cancelar()
        End Select
    End Sub

    Private Sub InicializarComboRubros()
        With Me.CtlComboRubro
            .ValueMember = "Codigo"
            .DisplayMember = "CodigoyNombre"
            .DataSource = _repositorioRubros.GetAll.OrderBy(Function(x) x.Codigo).ToList()
            .AutoCompleteMode = AutoCompleteMode.Append
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub InicializarComboArticulos()
        With Me.CtlCustomArticulo
            .ValueMember = "Codigo"
            .DisplayMember = "CodigoyNombre"
            .DataSource = _repositorioArticulos.GetAll.OrderBy(Function(x) x.Codigo).ToList()
            .AutoCompleteMode = AutoCompleteMode.Append
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            .SelectedIndex = -1
        End With
    End Sub


    Private Sub CheckBoxTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxTodos.CheckedChanged
        If Not CheckBoxTodos.Checked Then
            Me.CtlComboRubro.FocoDetalle()
        End If
    End Sub

    Private Sub CheckBoxArticulos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxArticulos.CheckedChanged
        If Not CheckBoxArticulos.Checked Then
            Me.CtlCustomArticulo.FocoDetalle()
        End If
    End Sub
End Class