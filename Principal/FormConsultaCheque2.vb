
Public Class FormConsultaCheque

    Private _repositorio As New CapaLogica.FinancieroCLog

    Private Sub MenuClick(ByVal sender As Object, ByVal e As EventArgs)
        Select Case DirectCast(sender, ToolStripButton).Name
            Case "BtnSalir" : Salir()
            Case "BtnFiltrar" : Filtrar()
            Case "BtnBorrarFiltro" : BorrarFiltros()
        End Select
    End Sub

    Private Sub BorrarFiltros()
        Me.FOLVRegistros.ResetColumnFiltering()
    End Sub


    Private Sub Salir()
        Me.Close()
    End Sub

    Private Sub Filtrar()
        If Me.TextBoxFilter.TextLength = 0 Then
            Me.TextBoxFilter.Focus()
        Else
            'aplico el filtro
            Dim filter As BrightIdeasSoftware.TextMatchFilter = BrightIdeasSoftware.TextMatchFilter.Contains(FOLVRegistros, TextBoxFilter.Text)
            FOLVRegistros.ModelFilter = filter
            FOLVRegistros.DefaultRenderer = New BrightIdeasSoftware.HighlightTextRenderer(filter)
            ActualizarEstados()
        End If
    End Sub

    Private Sub InicializarFormulario()
        ConfigurarGrilla()
        PoblarGrilla()
    End Sub

    Private Sub ConfigurarGrilla()
        CrearColumnas()

        With FOLVRegistros
            .FullRowSelect = True
            .UseFiltering = True
        End With

    End Sub

    Private Sub PoblarGrilla()
        Me.FOLVRegistros.Objects = _repositorio.GetAllCheques.OrderByDescending(Function(x) x.Efectivizacion).ToList()
        Me.FOLVRegistros.AutoResizeColumns()
        ActualizarEstados()
    End Sub

    Private Sub FOLVRegistros_FormatCell(ByVal sender As Object, ByVal e As BrightIdeasSoftware.FormatCellEventArgs) Handles FOLVRegistros.FormatCell
        Select Case e.Column.AspectName
            Case "EstadoDet"
                Select Case e.SubItem.Text
                    Case CH_PASADO
                        e.SubItem.BackColor = Color.LightYellow
                        e.SubItem.ForeColor = Color.DarkGreen
                    Case CH_DEPOSITADO
                        e.SubItem.BackColor = Color.LightBlue
                        e.SubItem.ForeColor = Color.DarkBlue
                    Case CH_RECHAZADO
                        e.SubItem.BackColor = Color.LightSalmon
                        e.SubItem.ForeColor = Color.DarkRed
                End Select
            Case "Referencia", "Fecha"
                e.SubItem.Font = New System.Drawing.Font(e.SubItem.Font.Name, e.SubItem.Font.Size, FontStyle.Bold)
        End Select
    End Sub

    Private Sub ActualizarEstados()
        Me.StatusLabelRegistros.Text = "Nº de Registros: " & Me.FOLVRegistros.Items.Count
        If Not FOLVRegistros.SelectedObject Is Nothing Then
            Me.lblSel.Text = "   | Nº de Cheque: " & DirectCast(FOLVRegistros.SelectedObject, Entidades.Financiero).Referencia & " - Fecha del Cheque: " & Format(DirectCast(FOLVRegistros.SelectedObject, Entidades.Financiero).Efectivizacion, "dd/MM/yyyy") & " - Importe: " & Format(DirectCast(FOLVRegistros.SelectedObject, Entidades.Financiero).Importe, "#,##0.00")
        Else
            Me.lblSel.Text = "   |"
        End If
    End Sub
    Private Sub CrearColumnas()

        Dim c As BrightIdeasSoftware.OLVColumn

        With FOLVRegistros

            .Columns.Clear()

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Nº Cheque"
            c.AspectName = "Referencia"
            c.MinimumWidth = 120
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Fecha Ch."
            c.AspectName = "Efectivizacion"
            c.AspectToStringConverter = Function(x As Date)
                                            Return x.ToString("dd/MM/yyyy")
                                        End Function
            c.MinimumWidth = 80
            c.TextAlign = HorizontalAlignment.Center
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Ingreso"
            c.AspectName = "Emision"
            c.AspectToStringConverter = Function(x As Date)
                                            Return x.ToString("dd/MM/yyyy")
                                        End Function
            c.MinimumWidth = 80
            c.TextAlign = HorizontalAlignment.Center
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Dador"
            c.AspectName = "Dador"
            c.MinimumWidth = 120
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Importe"
            c.AspectName = "Importe"
            c.MinimumWidth = 80
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("#,##0.00")
                                        End Function
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Estado"
            c.AspectName = "EstadoDet"
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Center
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Banco"
            c.AspectName = "NombreBanco"
            c.MinimumWidth = 120
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Localidad"
            c.AspectName = "NombreLocalidad"
            c.MinimumWidth = 120
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Cliente"
            c.AspectName = "Cliente"
            c.MinimumWidth = 120
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Librador"
            c.AspectName = "Librador"
            c.MinimumWidth = 120
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Doc. Lib."
            c.AspectName = "DocumentoNro"
            c.MinimumWidth = 120
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Nº Cuenta"
            c.AspectName = "Nroctabco"
            c.MinimumWidth = 120
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Egreso"
            c.AspectName = "Egreso"
            c.AspectToStringConverter = Function(x As Date)
                                            Return If(x.ToString("dd/MM/yyyy") = "01/01/0001", "", x.ToString("dd/MM/yyyy"))
                                        End Function
            c.MinimumWidth = 80
            c.TextAlign = HorizontalAlignment.Center
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Destino"
            c.AspectName = "Beneficiario"
            c.MinimumWidth = 120
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Proveedor"
            c.AspectName = "Proveedor"
            c.MinimumWidth = 120
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Nº Recibo"
            c.AspectName = "NroRecibo"
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Center
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Nº OP"
            c.AspectName = "NroOp"
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Center
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Observaciones"
            c.AspectName = "Observacion"
            c.MinimumWidth = 250
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

        End With
    End Sub

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        AddHandler Me.BtnSalir.Click, AddressOf MenuClick
        AddHandler Me.BtnBorrarFiltro.Click, AddressOf MenuClick
        AddHandler Me.BtnFiltrar.Click, AddressOf MenuClick
        AddHandler Me.Activated, AddressOf FormularioActivo
        AddHandler Me.KeyDown, AddressOf FormularioKeyDown
    End Sub

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Escape : Salir()
            Case Keys.Return : SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub FormABMCliente_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InicializarFormulario()
    End Sub

    Private Sub BtnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltrar.Click

    End Sub

    Private Sub FormularioActivo(ByVal sender As Object, ByVal e As EventArgs)
        Me.TextBoxFilter.Focus()
    End Sub

    Private Sub TextBoxFilter_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextBoxFilter.TextChanged
        If Len(Trim(TextBoxFilter.Text)) = 0 Then
            BorrarFiltros()
        Else
            Filtrar()
        End If
        TextBoxFilter.Focus()
    End Sub

    Private Sub FOLVRegistros_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles FOLVRegistros.SelectedIndexChanged
        ActualizarEstados()
    End Sub
End Class