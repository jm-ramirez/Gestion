Public Class FormConsultaOrdenCompra
    Private _repositorio As New CapaLogica.OrdencompracabCLog
    Private _editForm As New FormCbteOrdenCompra

    Private Sub MenuClick(ByVal sender As Object, ByVal e As EventArgs)
        'Select Case DirectCast(sender, ToolStripButton).Name
        '    Case "BtnSalir" : Salir()
        '    Case "BtnImprimir" : Imprimir()
        '    Case "BtnEliminar" : Eliminar()
        '        'Case "BtnEmail" : Email()
        '    Case "BtnModificar" : Modificar()
        '        'Case "BtnBase" : NuevoBase()
        '    Case "BtnFiltrar" : Filtrar()
        '    Case "BtnBorrarFiltro" : BorrarFiltros()
        'End Select
    End Sub

    Private Sub BorrarFiltros()
        Me.FOLVRegistros.ResetColumnFiltering()
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
            Dim filter As BrightIdeasSoftware.TextMatchFilter = BrightIdeasSoftware.TextMatchFilter.Contains(FOLVRegistros, TextBoxFilter.Text)
            FOLVRegistros.ModelFilter = filter
            FOLVRegistros.DefaultRenderer = New BrightIdeasSoftware.HighlightTextRenderer(filter)
            ActualizarEstados()
        End If
    End Sub

    Private Sub InicializarFormulario()

        Me.Text = "Consulta / Modificación / Anulación de Ordenes de Compra"

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
        Me.FOLVRegistros.Objects = _repositorio.GetAll.OrderByDescending(Function(x) x.Fecha).ToList
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
            c.Text = "Número"
            c.AspectName = "Numero"
            c.MinimumWidth = 80
            c.TextAlign = HorizontalAlignment.Center
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.AspectToStringConverter = Function(x As Integer)
                                            Return x.ToString("00000000")
                                        End Function
            c.IsEditable = False
            'c.AspectToStringFormat = "{0:C}"
            .Columns.Add(c)

            'c = New BrightIdeasSoftware.OLVColumn
            'c.Text = "Secuencia"
            'c.AspectName = "Secuencia"
            'c.MinimumWidth = 80
            'c.TextAlign = HorizontalAlignment.Center
            'c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            'c.AspectToStringConverter = Function(x As Integer)
            '                                Return x.ToString("00")
            '                            End Function
            'c.IsEditable = False
            ''c.AspectToStringFormat = "{0:C}"
            '.Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Fecha"
            c.AspectName = "Fecha"
            c.MinimumWidth = 100
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.AspectToStringConverter = Function(x As Date)
                                            Return x.ToString("dd/MM/yyyy")
                                        End Function
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Cliente"
            c.AspectName = "Codcliente"
            c.MinimumWidth = 90
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Nombre"
            c.AspectName = "NombreCliente"
            c.MinimumWidth = 300
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)


        End With
    End Sub


    Private Sub Editar()
        If Not FOLVRegistros.SelectedObject Is Nothing Then

            _editForm.Entidad = DirectCast(Me.FOLVRegistros.SelectedObject, Entidades.OrdenCompracab)

            If _editForm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                PoblarGrilla()
                'Me.FOLVRegistros.RefreshObject(_editForm.Entidad)
                'ActualizarEstados()
            End If

        Else

            MessageBox.Show("Debe seleccionar un registro", "Eliminar registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If

    End Sub

    'Private Sub Eliminar()

    '    If Not FOLVRegistros.SelectedObject Is Nothing Then

    '        If MessageBox.Show("Desea eliminar el registro seleccionado?", "Eliminar registro", _
    '                           MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
    '                           MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

    '            'Elimino el objeto seleccionado
    '            _repositorio.Delete(DirectCast(FOLVRegistros.SelectedObject, Entidades.Formadepago).Id)

    '            If _repositorio.HasError Then

    '                MessageBox.Show(_repositorio.mensajes.ToString, "Eliminar registro", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '            Else

    '                FOLVRegistros.RemoveObject(FOLVRegistros.SelectedObject)

    '                ActualizarEstados()

    '                MessageBox.Show("El registro se ha eliminado", "Eliminar registro", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '            End If

    '        End If

    '    Else

    '        MessageBox.Show("Debe seleccionar un registro", "Eliminar registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    '    End If

    'End Sub


    'Private Sub Imprimir()
    '    Try

    '        If FOLVRegistros.SelectedObject Is Nothing Then
    '            Throw New Exception("Debe seleccionar un registro para visualizar")
    '        End If

    '        Dim r As New GeneradorReportes.Reporte

    '        r.SourceFile = My.Settings.RutaReportes & "\lstFormasdePago.rdl"
    '        r.Nombre = "Listado de Formas de Pago"

    '        Dim repoparametros As New CapaLogica.ParametroCLog

    '        SetearEncabezadosReporte(r)

    '        r.Parametros.Add(New GeneradorReportes.Parametro("titulo", r.Nombre))

    '        r.Parametros.Add(New GeneradorReportes.Parametro("cdesde", DirectCast(FOLVRegistros.SelectedObject, Entidades.Formadepago).Id))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("chasta", DirectCast(FOLVRegistros.SelectedObject, Entidades.Formadepago).Id))

    '        r.ShowReport()

    '    Catch ex As Exception
    '        MessageBox.Show("Se produjo el siguiente error: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    'Private Sub Filtrar()
    '    If Me.TextBoxFilter.TextLength = 0 Then
    '        Me.TextBoxFilter.Focus()
    '    Else
    '        'aplico el filtro
    '        Dim filter As BrightIdeasSoftware.TextMatchFilter = BrightIdeasSoftware.TextMatchFilter.Contains(FOLVRegistros, TextBoxFilter.Text)
    '        FOLVRegistros.ModelFilter = filter
    '        FOLVRegistros.DefaultRenderer = New BrightIdeasSoftware.HighlightTextRenderer(filter)
    '        ActualizarEstados()
    '    End If
    'End Sub

    'Private Sub InicializarFormulario()
    '    ConfigurarGrilla()
    '    PoblarGrilla()
    'End Sub

    'Private Sub ConfigurarGrilla()
    '    CrearColumnas()

    '    With FOLVRegistros
    '        .FullRowSelect = True
    '        .UseFiltering = True
    '    End With

    'End Sub

    

    
    

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        AddHandler Me.BtnSalir.Click, AddressOf MenuClick
        AddHandler Me.BtnImprimir.Click, AddressOf MenuClick
        AddHandler Me.BtnAnular.Click, AddressOf MenuClick
        'AddHandler Me.BtnEmail.Click, AddressOf MenuClick
        'AddHandler Me.BtnEditar.Click, AddressOf MenuClick
        AddHandler Me.BtnBorrarFiltro.Click, AddressOf MenuClick
        AddHandler Me.BtnFiltrar.Click, AddressOf MenuClick
        AddHandler Me.Activated, AddressOf FormularioActivo
        AddHandler Me.KeyDown, AddressOf FormularioKeyDown
        AddHandler Me.TextBoxFilter.KeyDown, AddressOf FormularioKeyDown
    End Sub

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            'Case Keys.F2 : Nuevo()
            Case Keys.Escape

                If Me.FOLVRegistros.IsFiltering Then
                    BorrarFiltros()
                Else
                    Salir()
                End If

            Case Keys.F5 : Imprimir()
            Case Keys.F3 : Modificar()
                'Case Keys.F10 : NuevoBase()
            Case Keys.Delete : Eliminar()
                'Case Keys.F12 : Email()
            Case Keys.Enter
                If sender Is Me.TextBoxFilter Then
                    Filtrar()
                End If
        End Select
    End Sub

    Private Sub FormConsultaOrdenCompra_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        If FOLVRegistros.SelectedObject Is Nothing Then InicializarFormulario()
    End Sub

    Private Sub FormABMFormaPago_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InicializarFormulario()
    End Sub

    Private Sub FOLVRegistros_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles FOLVRegistros.DoubleClick
        Editar()
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

    Private Sub Modificar()
        Try

            If Not FOLVRegistros.SelectedObject Is Nothing Then
                _editForm.Entidad = DirectCast(Me.FOLVRegistros.SelectedObject, Entidades.OrdenCompracab)

                If _editForm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    PoblarGrilla()
                    'Me.FOLVRegistros.RefreshObject(_editForm.Entidad)
                    'ActualizarEstados()
                End If
                'Dim f As New FormCbteVenta
                ''Dim o As Entidades.CbteCabecera = _repositorio.GetById(DirectCast(FOLVRegistros.SelectedObject, PresCon).Id, True, True, True, True, True, True)

                ''f.Entidad = o
                ''f.TipoCbte = Me.TipoConsulta
                ''f.mblnBase = False
                ''f.ShowDialog()

                'PoblarGrilla()
            Else

                MessageBox.Show("Debe seleccionar un registro", "Editar registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
   
    Private Sub BtnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles BtnImprimir.Click
        Imprimir()
    End Sub
    Private Sub VisualizarComprobantes()
        'For Each o As Object In Me.OLVRegistros.SelectedObjects

        If Me.FOLVRegistros.SelectedObject Is Nothing Then
            MessageBox.Show("Debe seleccionar un registro", "Visualizar comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Call EmisionCbteOrdenCompra(DirectCast(Me.FOLVRegistros.SelectedObject, Entidades.OrdenCompracab).Id, True)
        End If


        'Next
    End Sub
    Private Sub AnularComprobantes()

        Try

            If Not FOLVRegistros.SelectedObject Is Nothing Then

                If MessageBox.Show("Desea eliminar el registro seleccionado?", "Eliminar registro", _
                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                                       MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

                    'Elimino el objeto seleccionado
                    _repositorio.Delete(DirectCast(FOLVRegistros.SelectedObject, Entidades.OrdenCompracab).Id)

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

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Eliminar registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub BtnAnular_Click(sender As System.Object, e As System.EventArgs) Handles BtnAnular.Click
        Eliminar()
    End Sub

    Private Sub btnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        Modificar()
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Salir()
    End Sub
End Class