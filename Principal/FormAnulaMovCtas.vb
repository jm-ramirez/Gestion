Public Class FormAnulaMovCtas
    Private _repositorio As New CapaLogica.FinancieroCLog

    Private Sub MenuClick(ByVal sender As Object, ByVal e As EventArgs)
        Select Case DirectCast(sender, ToolStripButton).Name
            Case "BtnSalir" : Salir()
            Case "BtnImprimir" : Imprimir()
            Case "BtnAnular" : Eliminar()
            Case "BtnFiltrar" : Filtrar()
            Case "BtnBorrarFiltro" : BorrarFiltros()
        End Select
    End Sub

    Private Sub BorrarFiltros()
        Me.OLVRegistros.ResetColumnFiltering()
        Me.TextBoxFilter.Focus()
    End Sub

    Private Sub Eliminar()
        AnularComprobantes()
    End Sub

    Private Sub Salir()
        Me.Close()
    End Sub

    Private Sub Imprimir()
        VisualizarComprobantes()
    End Sub

    Private Sub Filtrar()
        If Me.TextBoxFilter.TextLength = 0 Then
            Me.TextBoxFilter.Focus()
        Else
            'aplico el filtro
            Dim filter As BrightIdeasSoftware.TextMatchFilter = BrightIdeasSoftware.TextMatchFilter.Contains(OLVRegistros, TextBoxFilter.Text)
            OLVRegistros.ModelFilter = filter
            OLVRegistros.DefaultRenderer = New BrightIdeasSoftware.HighlightTextRenderer(filter)
            ActualizarEstados()
        End If
    End Sub

    Private Sub InicializarFormulario()
        ConfigurarGrilla()
        PoblarGrilla()
    End Sub

    Private Sub ConfigurarGrilla()
        CrearColumnas()

        With OLVRegistros
            .FullRowSelect = True
            .UseFiltering = True
        End With

    End Sub

    Private Sub PoblarGrilla()
        Me.OLVRegistros.Objects = _repositorio.GetMovCtas
        Me.OLVRegistros.AutoResizeColumns()
        ActualizarEstados()
    End Sub

    Private Sub ActualizarEstados()
        Me.StatusLabelRegistros.Text = "Nº de Registros: " & Me.OLVRegistros.Items.Count
    End Sub

    Private Sub CrearColumnas()

        Dim c As BrightIdeasSoftware.OLVColumn

        With OLVRegistros

            .Columns.Clear()

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Nº Movimiento"
            c.AspectName = "CbteMovCtas"
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Fecha"
            c.AspectName = "Emision"
            c.AspectToStringConverter = Function(x As Date)
                                            Return x.ToString("dd/MM/yyyy")
                                        End Function
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Center
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Fecha Ef."
            c.AspectName = "Efectivizacion"
            c.AspectToStringConverter = Function(x As Date)
                                            Return x.ToString("dd/MM/yyyy")
                                        End Function
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Center
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Dador"
            c.AspectName = "Dador"
            c.MinimumWidth = 150
            c.TextAlign = HorizontalAlignment.Left
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Destino"
            c.AspectName = "Beneficiario"
            c.MinimumWidth = 150
            c.TextAlign = HorizontalAlignment.Left
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Total"
            c.AspectName = "Importe"
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("#,##0.00")
                                        End Function
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

        End With
    End Sub

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        AddHandler Me.BtnSalir.Click, AddressOf MenuClick
        AddHandler Me.BtnImprimir.Click, AddressOf MenuClick
        AddHandler Me.BtnAnular.Click, AddressOf MenuClick
        AddHandler Me.BtnBorrarFiltro.Click, AddressOf MenuClick
        AddHandler Me.BtnFiltrar.Click, AddressOf MenuClick

        AddHandler Me.Activated, AddressOf FormularioActivo
        AddHandler Me.KeyDown, AddressOf FormularioKeyDown
    End Sub

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Escape

                If Me.OLVRegistros.IsFiltering Then
                    BorrarFiltros()
                Else
                    Salir()
                End If

            Case Keys.F5 : Imprimir()
            Case Keys.Delete : Eliminar()
            Case Keys.Enter
                If sender Is Me.TextBoxFilter Then
                    Filtrar()
                End If
        End Select
    End Sub

    Private Sub comAnulaDeposito_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InicializarFormulario()
    End Sub

    Private Sub OLVRegistros_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles OLVRegistros.DoubleClick
        Imprimir()
    End Sub

    Private Sub FormularioActivo(ByVal sender As Object, ByVal e As EventArgs)
        Me.TextBoxFilter.Focus()
    End Sub

    Private Sub ToolStripMenuItemVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemVisualizar.Click
        VisualizarComprobantes()
    End Sub

    Private Sub VisualizarComprobantes()
        If Not OLVRegistros.SelectedObject Is Nothing Then
            'For Each o As Object In Me.OLVRegistros.SelectedObjects
            'Call EmisionDeposito(DirectCast(o, Entidades.Movim).Deposito, DirectCast(o, Entidades.Movim).Emision, True)
            'Next
            Call EmisionMovCtas(DirectCast(OLVRegistros.SelectedObject, Entidades.Financiero).CbteMovCtas, DirectCast(OLVRegistros.SelectedObject, Entidades.Financiero).Emision, DirectCast(OLVRegistros.SelectedObject, Entidades.Financiero).Efectivizacion, True, True)
        Else
            MessageBox.Show("Debe seleccionar un registro", "Eliminar registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub AnularComprobantes()

        Try

            If Not OLVRegistros.SelectedObject Is Nothing Then

                If MessageBox.Show("Confirma la Anulación del Movimiento entre Cuentas Nº: " & DirectCast(OLVRegistros.SelectedObject, Entidades.Financiero).CbteMovCtas & "?", "Anular registro", _
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                                   MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

                    If MessageBox.Show("Está seguro que desea realizar la Anulación del Movimiento entre Cuentas Nº: " & DirectCast(OLVRegistros.SelectedObject, Entidades.Financiero).CbteMovCtas & "?", "Anular registro", _
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                                       MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

                        'Elimino el objeto seleccionado
                        _repositorio.AnulaMovCtas(DirectCast(OLVRegistros.SelectedObject, Entidades.Financiero).CbteMovCtas)

                        If _repositorio.HasError Then

                            MessageBox.Show(_repositorio.mensajes.ToString, "Eliminar registro", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        Else

                            OLVRegistros.RemoveObject(OLVRegistros.SelectedObject)

                            ActualizarEstados()

                            MessageBox.Show("El registro se ha eliminado", "Eliminar registro", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        End If

                    End If
                End If

            Else

                MessageBox.Show("Debe seleccionar un registro", "Eliminar registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Eliminar registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ToolStripMenuItemAnular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemAnular.Click
        Eliminar()
    End Sub

    Private Sub TextBoxFilter_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxFilter.TextChanged
        Filtrar()
    End Sub
End Class