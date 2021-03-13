Public Class FormInventario


    'repositorios de tablas
    Private _repositorio As New CapaLogica.ArticuloCLog
    Private _articulos As New List(Of Entidades.Articulo)
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

        _articulos = _repositorio.GetArticulosConExistencia

        InicializarCombos()
        
        Me.Text = "Carga de Inventario de Artículos"

        ConfigurarGrilla()

        PoblarGrilla()

        Me.ActiveControl = Me.CtlComboArticulo
        Me.CtlComboArticulo.FocoDetalle()

    End Sub

    Private Sub FormComisionDetale_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'Me.TextBoxFilter.Focus()
    End Sub

    Private Sub FormComisionDetale_AutoSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.AutoSizeChanged

    End Sub

    Private Sub FormVendedor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'iniciar formulario
        InicializarFormulario()
    End Sub

    Private Sub CustomGotFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = Color.LightGreen

        If sender.GetType = GetType(TextBox) Then
            DirectCast(sender, TextBox).Font = New Font(DirectCast(sender, TextBox).Font, FontStyle.Bold)
            DirectCast(sender, TextBox).SelectAll()
        ElseIf sender.GetType = GetType(NumericUpDown) Then
            DirectCast(sender, NumericUpDown).Select(0, DirectCast(sender, NumericUpDown).Value.ToString.Length)
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
                Case GetType(TextBox), GetType(CheckBox), GetType(ComboBox), GetType(NumericUpDown)
                    AddHandler c.GotFocus, AddressOf CustomGotFocus
                    AddHandler c.LostFocus, AddressOf CustomLostFocus
            End Select
        Next

        For Each c As Control In Me.GroupBoxArticulo.Controls
            Select Case c.GetType
                Case GetType(TextBox), GetType(CheckBox), GetType(ComboBox), GetType(NumericUpDown)
                    AddHandler c.GotFocus, AddressOf CustomGotFocus
                    AddHandler c.LostFocus, AddressOf CustomLostFocus
            End Select
        Next

        AddHandler Me.KeyDown, AddressOf FormularioKeyDown
        AddHandler Me.CtlComboArticulo.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.NumericUpDownActual.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.NumericUpDownReal.KeyDown, AddressOf CustomKeyDown


    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Cancelar()
    End Sub

    Private Sub Cancelar()

        If MessageBox.Show("Desea abandonar la carga del inventario?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Guardar()

        Dim objList As List(Of Entidades.Articulo)
        Dim a As Entidades.Articulo
        Dim id As UInt32

        Try

            If MessageBox.Show("Confirmar la carga del inventario, las existencias modificadas serán actulizadas. Continua?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            objList = New List(Of Entidades.Articulo)

            For Each obj As Object In Me.FOLVRegistros.Objects

                a = DirectCast(obj, Entidades.Articulo)

                If a.ExistenciaDiferencia <> 0 Then
                    objList.Add(a)
                End If
            Next

            'envio los nuevos datos al repositor para actualizar y visualizo el reporte
            id = _repositorio.SaveInventario(objList, gUsuario)

            If _repositorio.HasError Then

                MessageBox.Show(_repositorio.mensajes.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                If id <> 0 Then
                    Reporte(id)
                End If

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

    Private Sub Reporte(ByVal numero As UInt32)

        Try

            Dim r As New GeneradorReportes.Reporte

            r.Nombre = Me.Text
            r.SourceFile = My.Settings.RutaReportes & "\lstinventarios.rdl"
            r.Parametros.Add(New GeneradorReportes.Parametro("fhasta", Date.Today))
            r.Parametros.Add(New GeneradorReportes.Parametro("numero", numero))

            r.ShowReport()

            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub InicializarCombos()
        With Me.CtlComboArticulo
            .ComboBoxDetalle.Tag = "YesFocus"
            .ValueMember = "Codigo"
            .DisplayMember = "CodigoyNombre"
            .DataSource = _articulos
            .AutoCompleteMode = AutoCompleteMode.Append
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            .SelectedIndex = -1
        End With
    End Sub

    

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F12 : Guardar()
            Case Keys.Escape : Cancelar()
                'Case Keys.Return
                '    If Not sender Is Me.NumericUpDownActual Or Not sender Is Me.NumericUpDownReal Then
                '        SendKeys.Send("{TAB}")
                '    End If
        End Select
    End Sub

    Private Sub ConfigurarGrilla()
        CrearColumnas()

        With FOLVRegistros
            .FullRowSelect = True
            .UseFiltering = True
            .CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick
            .CellEditEnterChangesRows = True
        End With

    End Sub

    Private Sub PoblarGrilla()

        If Me.CheckBoxTodos.Checked = False Then
            Me.FOLVRegistros.ModelFilter = New BrightIdeasSoftware.ModelFilter(Function(x As Object)
                                                                                   Return CBool(DirectCast(x, Entidades.Articulo).ExistenciaDiferencia <> 0)
                                                                               End Function)
        Else
            Me.FOLVRegistros.ModelFilter = Nothing
        End If

        Me.FOLVRegistros.Objects = _articulos
        Me.FOLVRegistros.AutoResizeColumns()
    End Sub

    Private Sub CrearColumnas()

        Dim c As BrightIdeasSoftware.OLVColumn

        With FOLVRegistros

            .Columns.Clear()

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Id"
            c.AspectName = "Id"
            c.MinimumWidth = 35
            c.IsVisible = False
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = False
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Artículo"
            c.AspectName = "Codigo"
            c.MinimumWidth = 75
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = False
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Nombre"
            c.AspectName = "Nombre"
            c.MinimumWidth = 200
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.FillsFreeSpace = True
            c.IsEditable = False
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Rubro"
            c.AspectName = "Codrubro"
            c.MinimumWidth = 50
            c.IsEditable = False
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Existencia"
            c.AspectName = "ExistenciaActual"
            c.MinimumWidth = 100
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("#,##0.00#")
                                        End Function
            c.IsEditable = False
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Existencia Real"
            c.AspectName = "ExistenciaReal"
            c.MinimumWidth = 100
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("#,##0.00#")
                                        End Function
            c.IsEditable = True
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Diferencia"
            c.AspectName = "ExistenciaDiferencia"
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("#,##0.00#")
                                        End Function
            c.MinimumWidth = 100
            c.IsEditable = False
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

        End With
    End Sub

    Private Sub BtnBorrarFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBorrarFiltro.Click
        Me.FOLVRegistros.ResetColumnFiltering()
    End Sub

    Private Sub Filtrar()
        Dim filter As BrightIdeasSoftware.TextMatchFilter = BrightIdeasSoftware.TextMatchFilter.Prefix(FOLVRegistros, TextBoxFilter.Text)
        FOLVRegistros.ModelFilter = filter
        FOLVRegistros.DefaultRenderer = New BrightIdeasSoftware.HighlightTextRenderer(filter)
    End Sub

    Private Sub FOLVRegistros_CellEditFinishing(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs)
        'Me.FOLVRegistros.RefreshObjects(Me.FOLVRegistros.Objects)
    End Sub

    Private Sub FOLVRegistros_CellEditStarting(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs)
        e.Control.BackColor = Color.LightGreen

        If e.Control.GetType = GetType(BrightIdeasSoftware.FloatCellEditor) Then
            DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Font = New Font(DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Font, FontStyle.Bold)
            DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Select(0, DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Text.Length)
        End If

    End Sub

    Private Sub FOLVRegistros_CellEditValidating(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs)
        'If Val(e.NewValue) > DirectCast(e.RowObject, Entidades.CbteAsociado).Saldo Or Val(e.NewValue) < 0 Then
        ' If e.Control.GetType = GetType(BrightIdeasSoftware.FloatCellEditor) Then
        ' DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).BackColor = Color.Red
        ' DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Select(0, DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Text.Length)
        ' End If
        ' e.Cancel = True
        ' End If
    End Sub

    Private Sub CtlComboArticulo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtlComboArticulo.SelectedIndexChanged

        If CtlComboArticulo.SelectedItem IsNot Nothing Then
            CargarDatosArticulo()
        Else
            NumericUpDownActual.Value = 0.0
            NumericUpDownReal.Value = 0.0

            NumericUpDownActual.BackColor = Color.White

        End If

    End Sub

    Private Sub CargarDatosArticulo()

        Dim a As Entidades.Articulo
        a = DirectCast(Me.CtlComboArticulo.SelectedItem, Entidades.Articulo)
        NumericUpDownActual.Value = a.ExistenciaActual
        NumericUpDownReal.Value = a.ExistenciaReal

        'If NumericUpDownActual.Value < 0 Then
        '    NumericUpDownActual.BackColor = Color.LightSalmon
        '    NumericUpDownActual.ForeColor = Color.DarkSalmon
        'Else
        '    NumericUpDownActual.BackColor = Color.LightGreen
        '    NumericUpDownActual.ForeColor = Color.DarkGreen
        'End If


        


    End Sub

    Private Sub BtnActualizarArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizarArticulo.Click
        ActualizarArticulo()
    End Sub

    Private Sub ActualizarArticulo()

        DirectCast(Me.CtlComboArticulo.SelectedItem, Entidades.Articulo).ExistenciaReal = Me.NumericUpDownReal.Value
        Me.CtlComboArticulo.SelectedIndex = -1
        Me.CtlComboArticulo.FocoDetalle()
        PoblarGrilla()
    End Sub

    Private Sub CustomKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Return
                If sender Is Me.CtlComboArticulo Then
                    Me.NumericUpDownActual.Focus()
                ElseIf sender Is Me.NumericUpDownActual Then
                    Me.NumericUpDownReal.Focus()
                ElseIf sender Is Me.NumericUpDownReal Then
                    Me.BtnActualizarArticulo.Focus()
                End If
        End Select
    End Sub

    Private Sub CheckBoxTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxTodos.Click
        PoblarGrilla()
    End Sub

    Private Sub CheckBoxTodos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBoxTodos.CheckedChanged
        If Not CheckBoxTodos.Checked Then
            Me.CtlComboArticulo.FocoDetalle()
        End If
    End Sub

    Private Sub BtnFiltrar_Click(sender As Object, e As System.EventArgs) Handles BtnFiltrar.Click
        Filtrar()
    End Sub

    Private Sub TextBoxFilter_TextChanged(sender As Object, e As System.EventArgs) Handles TextBoxFilter.TextChanged
        Filtrar()
    End Sub
End Class