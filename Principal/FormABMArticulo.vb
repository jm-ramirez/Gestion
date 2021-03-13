
Public Class FormABMArticulo

    Private _repositorio As New CapaLogica.ArticuloCLog
    Private _editForm As FormArticulo
    Property Consulta As Boolean = False

    Private Sub MenuClick(ByVal sender As Object, ByVal e As EventArgs)
        Select Case DirectCast(sender, ToolStripButton).Name
            Case "BtnNuevo" : Nuevo()
            Case "BtnVer" : Ver()
            Case "BtnSalir" : Salir()
            Case "BtnImprimir" : Imprimir()
            Case "BtnEliminar" : Eliminar()
            Case "BtnEditar" : Editar()
            Case "BtnFiltrar" : Filtrar()
            Case "BtnBorrarFiltro" : BorrarFiltros()
        End Select
    End Sub

    Private Sub BorrarFiltros()
        Me.FOLVRegistros.ResetColumnFiltering()
    End Sub

    Private Sub Nuevo()
        _editForm = New FormArticulo
        _editForm.Entidad = Nothing

        If _editForm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            PoblarGrilla()
            'Me.FOLVRegistros.RefreshObject(_editForm.Entidad)
            'ActualizarEstados()
        End If

    End Sub

    Private Sub Editar()

        

        If Not FOLVRegistros.SelectedObject Is Nothing Then

            _editForm = New FormArticulo
            _editForm.Entidad = DirectCast(Me.FOLVRegistros.SelectedObject, Entidades.Articulo)

            If _editForm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                PoblarGrilla()
                'Me.FOLVRegistros.RefreshObject(_editForm.Entidad)
                'ActualizarEstados()
            End If

        Else

            MessageBox.Show("Debe seleccionar un registro", "Editar registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If

    End Sub

    Private Sub Eliminar()

        If Not FOLVRegistros.SelectedObject Is Nothing Then

            If MessageBox.Show("Desea eliminar el registro seleccionado?", "Eliminar registro", _
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                               MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

                'Elimino el objeto seleccionado
                _repositorio.Delete(DirectCast(FOLVRegistros.SelectedObject, Entidades.Articulo).Id)

                If _repositorio.HasError Then

                    MessageBox.Show(_repositorio.mensajes.ToString, "Eliminar registro", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Else

                    FOLVRegistros.RemoveObject(FOLVRegistros.SelectedObject)

                    ActualizarEstados()

                    MessageBox.Show("El registro se ha eliminado", "Eliminar registro", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            End If

        Else

            MessageBox.Show("Debe seleccionar un registro", "Eliminar registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If

    End Sub

    Private Sub Salir()
        Me.Close()
    End Sub

    Private Sub Imprimir()

        Dim r As New GeneradorReportes.Reporte
        r.SourceFile = My.Settings.RutaReportes & "\lstarticulo.rdl"
        r.Nombre = "Listado de Artículos"

        r.Parametros.Add(New GeneradorReportes.Parametro("titulo", r.Nombre))
        SetearEncabezadosReporte(r)

        r.ShowReport()
    End Sub

    Private Sub Filtrar()
        If Me.TextBoxFilter.TextLength = 0 Then
            BorrarFiltros()
            Me.TextBoxFilter.Focus()
        Else
            'aplico el filtro
            Dim filter As BrightIdeasSoftware.TextMatchFilter = BrightIdeasSoftware.TextMatchFilter.Contains(FOLVRegistros, TextBoxFilter.Text)
            FOLVRegistros.ModelFilter = filter
            FOLVRegistros.DefaultRenderer = New BrightIdeasSoftware.HighlightTextRenderer(filter)
        End If

        ActualizarEstados()

    End Sub


    Private Sub InicializarFormulario()

        If Me.Consulta Then
            Me.Text = "Consulta de Artículos"
        Else
            Me.Text = "ABM de Artículos"
        End If

        BtnEditar.Enabled = Not Consulta
        BtnEliminar.Enabled = Not Consulta
        BtnNuevo.Enabled = Not Consulta

        ConfigurarGrilla()
        PoblarGrilla()
    End Sub

    Private Sub ConfigurarGrilla()
        CrearColumnas()

        With FOLVRegistros

            'If Consulta Then
            .RowHeight = 55
            'End If

            .FullRowSelect = True
            .UseFiltering = True
        End With

    End Sub

    Private Sub PoblarGrilla()
        If Consulta Then
            Me.FOLVRegistros.Objects = _repositorio.GetArticulosConExistencia.OrderBy(Function(x) x.Nombre).ToList()
        Else
            Me.FOLVRegistros.Objects = _repositorio.GetAll.OrderBy(Function(x) x.Nombre).ToList()
        End If

        Me.FOLVRegistros.AutoResizeColumns()
        ActualizarEstados()
    End Sub

    Private Sub ActualizarEstados()
        Me.StatusLabelRegistros.Text = "Nº de Registros: " & Me.FOLVRegistros.Items.Count
    End Sub

    Private Sub CrearColumnas()

        Dim c As BrightIdeasSoftware.OLVColumn

        With FOLVRegistros

            .Columns.Clear()

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Id"
            c.AspectName = "Id"
            c.MinimumWidth = 50
            c.IsVisible = False
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Código"
            c.AspectName = "Codigo"
            c.MinimumWidth = 120
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Nombre"
            c.AspectName = "Nombre"
            c.MaximumWidth = 0
            c.UseFiltering = True
            'c.IsVisible = False
            c.Searchable = True
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Descripción"
            c.AspectName = "Descripcion"
            c.MaximumWidth = 0
            c.UseFiltering = True
            c.Searchable = True
            'c.IsVisible = False
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Nombre / Descripción"
            c.AspectName = "NombreDescripcion"
            c.AspectToStringConverter = Function(x As String)
                                            Return ""
                                        End Function
            c.UseFiltering = False
            c.MinimumWidth = 200
            c.Searchable = False
            c.FillsFreeSpace = True
            .Columns.Add(c)
            

            'c = New BrightIdeasSoftware.OLVColumn
            'c.Text = "Descripción"
            'c.AspectName = "Descripcion"
            'c.MinimumWidth = 150
            'c.TextAlign = HorizontalAlignment.Left
            'c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            '.Columns.Add(c)

            If Consulta Then
                c = New BrightIdeasSoftware.OLVColumn
                c.Text = "Existencia"
                c.AspectName = "ExistenciaActual"
                c.AspectToStringConverter = Function(x As Double)
                                                Return x.ToString("#,##0.00#")
                                            End Function
                c.MinimumWidth = 70
                c.TextAlign = HorizontalAlignment.Center
                c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                c.UseFiltering = False
                .Columns.Add(c)
            End If

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Pcio. [1]"
            'c.AspectName = "ImporteFinalRevendedor"
            c.AspectName = "ImporteFinalLista1"
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("$ #,##0.00#")
                                        End Function
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Pcio. [2]"
            'c.AspectName = "ImporteFinalKiosko"
            c.AspectName = "ImporteFinalLista2"
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("$ #,##0.00#")
                                        End Function
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Pcio. [3]"
            'c.AspectName = "ImporteFinalMostrador"
            c.AspectName = "ImporteFinalLista3"
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("$ #,##0.00#")
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
        AddHandler Me.BtnVer.Click, AddressOf MenuClick
        AddHandler Me.BtnNuevo.Click, AddressOf MenuClick
        AddHandler Me.BtnSalir.Click, AddressOf MenuClick
        AddHandler Me.BtnImprimir.Click, AddressOf MenuClick
        AddHandler Me.BtnEliminar.Click, AddressOf MenuClick
        AddHandler Me.BtnEditar.Click, AddressOf MenuClick
        AddHandler Me.BtnBorrarFiltro.Click, AddressOf MenuClick
        AddHandler Me.BtnFiltrar.Click, AddressOf MenuClick
        AddHandler Me.Activated, AddressOf FormularioActivo
        AddHandler Me.KeyDown, AddressOf FormularioKeyDown
    End Sub

    Private Sub FormABMArticulo_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

    End Sub

    Private Sub FormABMArticulo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InicializarFormulario()
    End Sub

    Private Sub FOLVRegistros_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles FOLVRegistros.DoubleClick

        If Me.Consulta Then
            Ver()
        Else
            Editar()
        End If

    End Sub


   

    Private Sub FormularioActivo(ByVal sender As Object, ByVal e As EventArgs)
        Me.TextBoxFilter.Focus()
    End Sub

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F2 : If Not Consulta Then Nuevo()
            Case Keys.Escape : Salir()
            Case Keys.F5 : Imprimir()
            Case Keys.F7 : Ver()
            Case Keys.Delete : If Not Consulta Then Eliminar()
            Case Keys.F3 : If Not Consulta Then Editar()
            Case Keys.Return : SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click

    End Sub

    Private Sub Ver()
        If Not FOLVRegistros.SelectedObject Is Nothing Then

            _editForm = New FormArticulo
            _editForm.Entidad = DirectCast(Me.FOLVRegistros.SelectedObject, Entidades.Articulo)
            _editForm.Consulta = True

            If _editForm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Me.FOLVRegistros.RefreshObject(_editForm.Entidad)
                ActualizarEstados()
            End If

        Else

            MessageBox.Show("Debe seleccionar un registro", "Ver registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If
    End Sub

    Private Sub FOLVRegistros_FormatCell(ByVal sender As Object, ByVal e As BrightIdeasSoftware.FormatCellEventArgs) Handles FOLVRegistros.FormatCell
        Select Case e.Column.AspectName
            Case "Codigo", "ImporteFinalKiosko", "ImporteFinalRevendedor", "ImporteFinalMostrador"
                e.SubItem.Font = New System.Drawing.Font(e.SubItem.Font.Name, e.SubItem.Font.Size, FontStyle.Bold)
                'Case "Nombre"
                '    If Consulta Then
                '        e.SubItem.Font = New System.Drawing.Font(e.SubItem.Font.Name, 10)
                '    End If
            Case "ExistenciaActual"

                e.SubItem.Font = New System.Drawing.Font(e.SubItem.Font.Name, e.SubItem.Font.Size, FontStyle.Bold)

                If Convert.ToDouble(e.CellValue) < 0 Then
                    e.SubItem.BackColor = Color.Salmon
                    e.SubItem.ForeColor = Color.DarkRed
                Else
                    e.SubItem.BackColor = Color.LightGreen
                    e.SubItem.ForeColor = Color.DarkGreen
                End If
            Case "NombreDescripcion"
                Dim art As Entidades.Articulo = DirectCast(e.Model, Entidades.Articulo)
                Dim decoration As NamedDescriptionDecoration = New NamedDescriptionDecoration()
                decoration.ImageList = Nothing
                decoration.Title = art.Nombre
                decoration.ImageName = ""
                decoration.Description = art.Descripcion
                e.SubItem.Decoration = decoration
        End Select
    End Sub

    Private Sub TextBoxFilter_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextBoxFilter.TextChanged
        If Len(Trim(TextBoxFilter.Text)) = 0 Then
            BorrarFiltros()
        Else
            Filtrar()
        End If
        TextBoxFilter.Focus()
    End Sub

End Class