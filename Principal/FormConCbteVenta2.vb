
Public Class FormConCbteVenta2

    Property TipoConsulta As TipoEmisionCbte
    Private _repositorio As New CapaLogica.CbteCabecera2CLog
    Private _editForm As Object 'FormCliente
    Private Const SI As String = "SI"
    Private Const NO As String = "NO"

    Private Sub MenuClick(ByVal sender As Object, ByVal e As EventArgs)
        Select Case DirectCast(sender, ToolStripButton).Name
            Case "BtnSalir" : Salir()
            Case "BtnImprimir" : Imprimir()
            Case "BtnEliminar" : Eliminar()
            Case "BtnEmail" : Email()
            Case "BtnModificar" : Modificar()
            Case "BtnBase" : NuevoBase()
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
            Dim filter As BrightIdeasSoftware.TextMatchFilter = BrightIdeasSoftware.TextMatchFilter.Prefix(OLVRegistros, TextBoxFilter.Text)
            OLVRegistros.ModelFilter = filter
            OLVRegistros.DefaultRenderer = New BrightIdeasSoftware.HighlightTextRenderer(filter)
            ActualizarEstados()
        End If
    End Sub


    Private Sub InicializarFormulario()

        Select Case TipoConsulta
            Case TipoEmisionCbte.PRESUPUESTO : Me.Text = "Consulta / Reimpresión / Anulación de Presupuestos"
        End Select

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
        Me.OLVRegistros.Groups.Clear()
        Me.OLVRegistros.Objects = GetCbtes() '.OrderByDescending(Function(x) x.FechaEmision)
        Me.OLVRegistros.AutoResizeColumns()
        ActualizarEstados()
    End Sub

    Private Function GetCbtes() As List(Of PresCon)

        Dim ret As New List(Of PresCon)
        Dim rc As PresCon

        Dim tipo As UInteger

        Select Case TipoConsulta
            Case TipoEmisionCbte.PRESUPUESTO : tipo = PRESUPUESTO
        End Select

        For Each r As Entidades.CbteCabecera2 In Me._repositorio.GetAllByTipo(tipo:=tipo, cargaAlicuotas:=False, cargaArticulos:=True, cargaAsociados:=False, cargaCtaCte:=False, cargaFinanciero:=False, cargaTributos:=False).OrderByDescending(Function(x) x.Cbtenumero).ToList()

            For Each a As Entidades.CbteArticulo2 In r.CbteArticulos2 '.OrderBy(Function(x) x.Id).ToList()

                rc = New PresCon
                rc.Id = r.Id
                rc.CbteNumero = r.CbteNumeroFmt
                rc.FechaEmision = r.FechaEmision
                rc.Razonsocial = r.Razonsocial
                rc.FechaVigencia = r.FechaVigencia
                rc.Codigo = a.Codigo
                rc.Articulo = a.Descripcion
                'rc.Material = a.Material
                rc.Unidad = a.Unidad
                rc.Moneda = a.Moneda
                'rc.Cantidad = a.Cantidad
                rc.Importe = a.ImporteFinal

                ret.Add(rc)

            Next a

        Next r

        Return ret

    End Function

    Private Sub ActualizarEstados()
        Me.StatusLabelRegistros.Text = "Nº de Registros: " & Me.OLVRegistros.Items.Count
    End Sub

    Private Class PresCon
        Property Id As UInt32
        Property CbteNumero As String
        Property FechaEmision As Date
        Property Codigo As String
        Property Razonsocial As String
        Property FechaVigencia As Date
        Property Articulo As String
        'Property Material As String
        Property Unidad As String
        Property Moneda As String
        Property Cantidad As Double
        Property Importe As Double
    End Class

    Private Sub CrearColumnas()

        Dim c As BrightIdeasSoftware.OLVColumn

        With OLVRegistros

            .Columns.Clear()

            'c = New BrightIdeasSoftware.OLVColumn
            'c.Text = "Id"
            'c.AspectName = "ArtId"
            'c.MinimumWidth = 60
            'c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            'c.IsVisible = False
            'c.Groupable = False
            '.Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Comprobante"
            c.AspectName = "CbteNumero"
            c.MinimumWidth = 90
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Fecha"
            c.AspectName = "FechaEmision"
            c.AspectToStringConverter = Function(x As Date)
                                            Return x.ToString("dd/MM/yy")
                                        End Function
            c.MinimumWidth = 60
            c.TextAlign = HorizontalAlignment.Center
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Razón Social"
            c.AspectName = "Razonsocial"
            c.IsEditable = False
            c.FillsFreeSpace = True
            c.MinimumWidth = 80
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Vigencia"
            c.AspectName = "FechaVigencia"
            c.AspectToStringConverter = Function(x As Date)
                                            Return x.ToString("dd/MM/yy")
                                        End Function
            c.MinimumWidth = 60
            c.TextAlign = HorizontalAlignment.Center
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Código"
            c.AspectName = "Codigo"
            c.IsEditable = False
            c.MinimumWidth = 110
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Articulo"
            c.AspectName = "Articulo"
            c.IsEditable = False
            c.MinimumWidth = 180
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            'c = New BrightIdeasSoftware.OLVColumn
            'c.Text = "Material"
            'c.AspectName = "Material"
            'c.MinimumWidth = 160
            'c.IsEditable = False
            'c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            '.Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Un."
            c.AspectName = "Unidad"
            c.IsEditable = False
            c.MinimumWidth = 40
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Moneda"
            c.AspectName = "Moneda"
            c.IsEditable = False
            c.MinimumWidth = 40
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            'c = New BrightIdeasSoftware.OLVColumn
            'c.Text = "Cantidad"
            'c.AspectName = "Cantidad"
            'c.AspectToStringConverter = Function(x As Double)
            '                                Return x.ToString("#,##0.00#")
            '                            End Function
            'c.IsEditable = True
            'c.MinimumWidth = 80
            'c.TextAlign = HorizontalAlignment.Right
            'c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            '.Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Importe"
            c.AspectName = "Importe"
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("#,##0.00#")
                                        End Function
            c.IsEditable = True
            c.MinimumWidth = 80
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            'c = New BrightIdeasSoftware.OLVColumn
            'c.Text = "Estado"
            'c.AspectName = "Estado"
            'c.MinimumWidth = 100
            'c.TextAlign = HorizontalAlignment.Center
            'c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            '.Columns.Add(c)


        End With
    End Sub

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'AddHandler Me.BtnNuevo.Click, AddressOf MenuClick
        AddHandler Me.BtnSalir.Click, AddressOf MenuClick
        AddHandler Me.BtnImprimir.Click, AddressOf MenuClick
        AddHandler Me.BtnAnular.Click, AddressOf MenuClick
        AddHandler Me.BtnEmail.Click, AddressOf MenuClick
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

                If Me.OLVRegistros.IsFiltering Then
                    BorrarFiltros()
                Else
                    Salir()
                End If

            Case Keys.F5 : Imprimir()
            Case Keys.F3 : Modificar()
            Case Keys.F10 : NuevoBase()
            Case Keys.Delete : Eliminar()
            Case Keys.F12 : Email()
            Case Keys.Enter
                If sender Is Me.TextBoxFilter Then
                    Filtrar()
                End If
        End Select
    End Sub

    Private Sub FormConCbteVenta2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If OLVRegistros.SelectedObject Is Nothing Then InicializarFormulario()
    End Sub

    Private Sub FormConCbteVenta2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'InicializarFormulario()
    End Sub

    Private Sub OLVRegistros_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles OLVRegistros.DoubleClick
        Imprimir()
    End Sub

    Private Sub FormularioActivo(ByVal sender As Object, ByVal e As EventArgs)
        Me.TextBoxFilter.Focus()
    End Sub

    'Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
    '    Imprimir()
    'End Sub

    Private Sub ToolStripMenuItemVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemVisualizar.Click
        VisualizarComprobantes()
    End Sub

    Private Sub VisualizarComprobantes()
        'For Each o As Object In Me.OLVRegistros.SelectedObjects

        If Me.OLVRegistros.SelectedObject Is Nothing Then
            MessageBox.Show("Debe seleccionar un registro", "Visualizar comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Call EmisionCbtePres(DirectCast(Me.OLVRegistros.SelectedObject, PresCon).Id, True)
        End If


        'Next
    End Sub

    Private Sub AnularComprobantes()

        Try

            If Not OLVRegistros.SelectedObject Is Nothing Then

                If MessageBox.Show("Desea eliminar el registro seleccionado?", "Eliminar registro", _
                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                                       MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then


                    'Dim o As Entidades.CbteCabecera = DirectCast(OLVRegistros.SelectedObject, Entidades.CbteCabecera)

                    'Elimino el objeto seleccionado
                    '_repositorio.Delete(o.Id)
                    _repositorio.Delete(DirectCast(OLVRegistros.SelectedObject, PresCon).Id)

                    If _repositorio.HasError Then

                        MessageBox.Show(_repositorio.mensajes.ToString, "Eliminar registro", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Else

                        OLVRegistros.RemoveObject(OLVRegistros.SelectedObject)

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

    Private Sub BtnAnular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAnular.Click
        Eliminar()
    End Sub

    Private Sub ToolStripMenuItemAnular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemAnular.Click
        Eliminar()
    End Sub

    Private Sub TextBoxFilter_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxFilter.TextChanged
        Filtrar()
    End Sub

    Private Sub Email()
        If Not OLVRegistros.SelectedObject Is Nothing Then
            Dim f As New FormEmail
            f.Modo = 2
            f.Cbte = _repositorio.GetById(DirectCast(OLVRegistros.SelectedObject, PresCon).Id, False, False, False, False, False, False)
            f.ShowDialog()
            f.Dispose()
        Else
            MessageBox.Show("Debe seleccionar un registro", "Enviar Comprobante por Email", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub EnviarComprobantePorEmailToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EnviarComprobantePorEmailToolStripMenuItem.Click
        Email()
    End Sub

    Private Sub CancelarComprobanteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelarComprobanteToolStripMenuItem.Click
        'If Not OLVRegistros.SelectedObject Is Nothing Then
        '    If MessageBox.Show("Confirma la cancelación del comprobante actual?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Yes Then

        '        _repositorio.CambiarEstado(DirectCast(OLVRegistros.SelectedObject, Entidades.CbteCabecera), CBTE_CANCELADO)

        '        If _repositorio.HasError Then
        '            MessageBox.Show(_repositorio.mensajes.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Else
        '            PoblarGrilla()
        '        End If

        '    End If
        'End If
    End Sub

    Private Sub ToolStripMenuItemModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemModificar.Click
        Modificar()
    End Sub

    Private Sub NuevoBase()
        Try

            If Not OLVRegistros.SelectedObject Is Nothing Then


                Dim f As New FormCbteVenta2
                Dim o As Entidades.CbteCabecera2 = _repositorio.GetById(DirectCast(OLVRegistros.SelectedObject, PresCon).Id, True, True, True, True, True, True)

                f.Entidad = o
                f.TipoCbte = Me.TipoConsulta
                f.mblnBase = True
                f.ShowDialog()

                PoblarGrilla()

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Modificar()
        Try

            If Not OLVRegistros.SelectedObject Is Nothing Then


                Dim f As New FormCbteVenta2
                Dim o As Entidades.CbteCabecera2 = _repositorio.GetById(DirectCast(OLVRegistros.SelectedObject, PresCon).Id, True, True, True, True, True, True)

                f.Entidad = o
                f.TipoCbte = Me.TipoConsulta
                f.mblnBase = False
                f.ShowDialog()

                PoblarGrilla()

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Modificar()
    End Sub

    Private Sub btnBase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBase.Click
        NuevoBase()
    End Sub

    Private Sub OLVRegistros_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles OLVRegistros.SelectedIndexChanged

    End Sub
End Class