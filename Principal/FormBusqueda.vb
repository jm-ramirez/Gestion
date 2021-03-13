
Public Class FormBusqueda

    Property SelectedItem As Object = Nothing
    Property DataSource As Object
    Property ValueMember As String
    Property DisplayMember As String
    Property Columnas As List(Of BrightIdeasSoftware.OLVColumn) = Nothing
    Property CustomFormatArt As Boolean


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

    Private Sub SeleccionarItem()
        If Not FOLVRegistros.SelectedObject Is Nothing Then

            Me.SelectedItem = Me.FOLVRegistros.SelectedObject
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        Else

            'MessageBox.Show("Debe seleccionar un registro", "Seleccionar registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.FOLVRegistros.Focus()

        End If

    End Sub

    Private Sub Salir()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Filtrar(Optional ByVal autofocus As Boolean = True)
        If Me.TextBoxFilter.TextLength = 0 Then
            BorrarFiltros()
            Me.TextBoxFilter.Focus()
        Else
            'aplico el filtro
            Dim filter As BrightIdeasSoftware.TextMatchFilter = BrightIdeasSoftware.TextMatchFilter.Contains(FOLVRegistros, TextBoxFilter.Text)
            FOLVRegistros.ModelFilter = filter
            FOLVRegistros.DefaultRenderer = New BrightIdeasSoftware.HighlightTextRenderer(filter)

            If autofocus Then FOLVRegistros.Focus()

        End If

        ActualizarEstados()

    End Sub

    Private Sub InicializarFormulario()
        ConfigurarGrilla()
        PoblarGrilla()
    End Sub

    Private Sub ConfigurarGrilla()

        CrearColumnas()

        With FOLVRegistros

            If CustomFormatArt Then
                .UseCellFormatEvents = True
                .RowHeight = 55
            End If

            .FullRowSelect = True
            .UseFiltering = True
        End With

    End Sub

    Private Sub PoblarGrilla()
        Me.FOLVRegistros.Objects = Me.DataSource
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

            If Not CustomFormatArt Then
                c = New BrightIdeasSoftware.OLVColumn
                c.Text = Me.ValueMember
                c.AspectName = Me.ValueMember
                c.MinimumWidth = 120
                c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                .Columns.Add(c)

                c = New BrightIdeasSoftware.OLVColumn
                c.Text = "Nombre/Descripción"
                c.AspectName = Me.DisplayMember
                c.FillsFreeSpace = True
                .Columns.Add(c)
            Else
                c = New BrightIdeasSoftware.OLVColumn
                c.Text = Me.ValueMember
                c.AspectName = Me.ValueMember
                c.MaximumWidth = 0
                c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                .Columns.Add(c)

                c = New BrightIdeasSoftware.OLVColumn
                c.Text = "Nombre/Descripción"
                c.AspectName = Me.DisplayMember
                c.MaximumWidth = 0
                c.Searchable = True
                c.UseFiltering = True
                .Columns.Add(c)
            End If
            

            If Columnas IsNot Nothing Then
                For Each col As BrightIdeasSoftware.OLVColumn In Columnas
                    .Columns.Add(col)
                Next
            End If


        End With
    End Sub

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        AddHandler Me.BtnSalir.Click, AddressOf MenuClick
        AddHandler Me.BtnBorrarFiltro.Click, AddressOf MenuClick
        AddHandler Me.BtnFiltrar.Click, AddressOf MenuClick
        AddHandler Me.KeyDown, AddressOf FormularioKeyDown
    End Sub

    Private Sub FormBusqueda_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.TextBoxFilter.Focus()
    End Sub

    Private Sub FormABMCliente_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InicializarFormulario()
    End Sub

    Private Sub FOLVRegistros_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles FOLVRegistros.DoubleClick
        SeleccionarItem()
    End Sub

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Escape : Salir()
            Case Keys.Enter : SeleccionarItem()
        End Select
    End Sub

    Private Sub BtnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltrar.Click

    End Sub

    Private Sub TextBoxFilter_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxFilter.TextChanged
        Filtrar(False)
    End Sub

    Private Sub FOLVRegistros_FormatCell(ByVal sender As Object, ByVal e As BrightIdeasSoftware.FormatCellEventArgs) Handles FOLVRegistros.FormatCell

        If CustomFormatArt Then
            Select Case e.Column.AspectName
                Case "NombreDescripcion"
                    'Dim art As Entidades.Articulo = DirectCast(e.Model, Entidades.Articulo)
                    'Dim decoration As NamedDescriptionDecoration = New NamedDescriptionDecoration()
                    'decoration.ImageList = Nothing
                    'decoration.Title = art.Nombre
                    'decoration.ImageName = ""
                    'decoration.Description = art.Descripcion
                    'e.SubItem.Decoration = decoration
            End Select
        End If
    End Sub
End Class