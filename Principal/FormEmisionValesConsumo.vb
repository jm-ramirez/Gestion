Public Class FormEmisionValesConsumo
    '    Private _repositorioMat As New CapaLogica.MaterialcpraCLog
    '    Private _repositorioImpEg As New CapaLogica.ImputacionegCLog
    '    Private _repositorioArt As New CapaLogica.ArticuloCLog

    '    Property Entidad As Entidades.Ingresoscab
    '    Property EntidadDet As Entidades.Ingresosdet

    '    Private _repositorio As New CapaLogica.IngresoscabCLog

    '    Public _Lista As List(Of Entidades.Ingresosdet)

    '    inicializo formulario, limpieza o carga de valores
    '    Private Sub InicializarFormulario()

    '        limpieza de controles
    '        For Each c As Control In Me.GroupBoxCDC.Controls
    '            Select Case c.GetType
    '                Case GetType(TextBox) : DirectCast(c, TextBox).Text = ""
    '                Case GetType(ComboBox) : DirectCast(c, ComboBox).SelectedIndex = -1
    '                Case GetType(CheckBox) : DirectCast(c, CheckBox).Checked = False
    '                Case GetType(NumericUpDown) : DirectCast(c, NumericUpDown).Value = DirectCast(c, NumericUpDown).Minimum
    '            End Select
    '        Next
    '        ActualizaNumeracion()
    '        InicializarCombos()
    '        _Lista = New List(Of Entidades.Ingresosdet)
    '        _Lista.Clear()
    '        ConfigurarGrilla()
    '        Me.DTPFecha.Value = Now
    '        Me.Text = "Emisión de vales de consumo"
    '    End Sub

    '    Private Sub FormEmisionValesConsumo_Load(sender As Object, e As System.EventArgs) Handles Me.Load
    '        InicializarFormulario()
    '    End Sub

    '    Private Sub InicializarComboMateriales()

    '        With Me.CtlComboMaterial
    '            .ValueMember = "Codigo"
    '            .DisplayMember = "NombreyCodigo"
    '            .DataSource = _repositorioMat.GetAll().Where(Function(x As Entidades.Materialcpra) x.Mficha = True).ToList()
    '            .AutoCompleteMode = AutoCompleteMode.Suggest
    '            .AutoCompleteSource = AutoCompleteSource.ListItems
    '            .DropDownStyle = ComboBoxStyle.DropDownList
    '            .FormularioDeAlta = FormMatCpra
    '            .Inicializar()
    '            .SelectedIndex = -1
    '        End With

    '    End Sub

    '    Private Sub InicializarComboImputNegativos()

    '        With Me.CtlComboImpNegativa
    '            .ValueMember = "Codigo"
    '            .DisplayMember = "NombreyCodigo"
    '            .DataSource = _repositorioImpEg.GetAll()
    '            .AutoCompleteMode = AutoCompleteMode.Suggest
    '            .AutoCompleteSource = AutoCompleteSource.ListItems
    '            .DropDownStyle = ComboBoxStyle.DropDownList
    '            .FormularioDeAlta = FormImputaEg
    '            .Inicializar()
    '            .SelectedIndex = -1
    '        End With

    '    End Sub

    '    Private Sub ConfigurarGrilla()
    '        CrearColumnas()

    '        With FOLVRegistros
    '            .FullRowSelect = True
    '            .UseFiltering = True
    '            .CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick
    '            .CellEditEnterChangesRows = True
    '            .ClearObjects()
    '        End With

    '    End Sub
    '    Private Sub PoblarGrilla()
    '        Me.FOLVRegistros.ModelFilter = Nothing
    '        Me.FOLVRegistros.Objects = _Lista
    '        Me.FOLVRegistros.AutoResizeColumns()
    '    End Sub
    '    Private Sub CrearColumnas()

    '        Dim c As BrightIdeasSoftware.OLVColumn

    '        With FOLVRegistros

    '            .Columns.Clear()

    '            c = New BrightIdeasSoftware.OLVColumn
    '            c.Text = "Codigo"
    '            c.AspectName = "Codmaterial"
    '            c.MinimumWidth = 60
    '            c.MaximumWidth = 60
    '            c.AutoResize(ColumnHeaderAutoResizeStyle.None)
    '            c.FillsFreeSpace = True
    '            c.IsEditable = False
    '            .Columns.Add(c)

    '            c = New BrightIdeasSoftware.OLVColumn
    '            c.Text = "Detalle"
    '            c.AspectName = "NombreMaterial"
    '            c.MinimumWidth = 225
    '            c.MaximumWidth = 225
    '            c.AutoResize(ColumnHeaderAutoResizeStyle.None)
    '            c.FillsFreeSpace = True
    '            c.IsEditable = False
    '            .Columns.Add(c)

    '            c = New BrightIdeasSoftware.OLVColumn
    '            c.Text = "Unidad"
    '            c.AspectName = "Unidad"
    '            c.MinimumWidth = 50
    '            c.MaximumWidth = 50
    '            c.AutoResize(ColumnHeaderAutoResizeStyle.None)
    '            c.FillsFreeSpace = True
    '            c.IsEditable = False
    '            .Columns.Add(c)

    '            c = New BrightIdeasSoftware.OLVColumn
    '            c.Text = "Cantidad"
    '            c.AspectName = "Cantidad"
    '            c.HeaderTextAlign = HorizontalAlignment.Right
    '            c.TextAlign = HorizontalAlignment.Right
    '            c.AspectToStringConverter = Function(x As Double)
    '                                            If x <= 0 Or x > 9999.99 Then
    '                                                x = 1
    '                                            End If
    '                                            Return Format(x, "0.00")
    '                                        End Function
    '            c.MinimumWidth = 60
    '            c.MaximumWidth = 60
    '            c.AutoResize(ColumnHeaderAutoResizeStyle.None)
    '            c.FillsFreeSpace = True
    '            c.IsEditable = True
    '            .Columns.Add(c)



    '            c = New BrightIdeasSoftware.OLVColumn
    '            c.Text = "Stock Min."
    '            c.AspectName = "PuntoMinimo"
    '            c.HeaderTextAlign = HorizontalAlignment.Right
    '            c.TextAlign = HorizontalAlignment.Right
    '            c.AspectToStringConverter = Function(x As Double)
    '                                            Return x.ToString("0.00")
    '                                        End Function
    '            c.MinimumWidth = 65
    '            c.MaximumWidth = 65
    '            c.AutoResize(ColumnHeaderAutoResizeStyle.None)
    '            c.FillsFreeSpace = True
    '            c.IsEditable = False
    '            .Columns.Add(c)

    '            c = New BrightIdeasSoftware.OLVColumn
    '            c.Text = "Existencia"
    '            c.AspectName = "Existencia"
    '            c.HeaderTextAlign = HorizontalAlignment.Right
    '            c.TextAlign = HorizontalAlignment.Right
    '            c.AspectToStringConverter = Function(x As Double)
    '                                            Return x.ToString("0.00")
    '                                        End Function
    '            c.MinimumWidth = 60
    '            c.MaximumWidth = 60
    '            c.AutoResize(ColumnHeaderAutoResizeStyle.None)
    '            c.FillsFreeSpace = True
    '            c.IsEditable = False
    '            .Columns.Add(c)

    '            c = New BrightIdeasSoftware.OLVColumn
    '            c.Text = "Observacion"
    '            c.AspectName = "Observacion"
    '            c.MinimumWidth = 100
    '            c.MaximumWidth = 100
    '            c.AutoResize(ColumnHeaderAutoResizeStyle.None)
    '            c.FillsFreeSpace = True
    '            c.IsEditable = False
    '            .Columns.Add(c)

    '            .CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick
    '            .CellEditEnterChangesRows = True
    '        End With
    '    End Sub

    '    Private Sub CustomGotFocus(ByVal sender As Object, ByVal e As EventArgs)
    '        sender.BackColor = Color.LightGreen

    '        If sender.GetType = GetType(TextBox) Then
    '            DirectCast(sender, TextBox).Font = New Font(DirectCast(sender, TextBox).Font, FontStyle.Bold)
    '        ElseIf sender.GetType = GetType(NumericUpDown) Then
    '            DirectCast(sender, NumericUpDown).Font = New Font(DirectCast(sender, NumericUpDown).Font, FontStyle.Bold)
    '            DirectCast(sender, NumericUpDown).Select(0, DirectCast(sender, NumericUpDown).Text.Length)
    '        End If

    '    End Sub

    '    Private Sub CustomLostFocus(ByVal sender As Object, ByVal e As EventArgs)
    '        sender.BackColor = SystemColors.Window

    '        If sender.GetType = GetType(TextBox) Then
    '            DirectCast(sender, TextBox).Font = New Font(DirectCast(sender, TextBox).Font, FontStyle.Regular)
    '        ElseIf sender.GetType = GetType(NumericUpDown) Then
    '            DirectCast(sender, NumericUpDown).Font = New Font(DirectCast(sender, NumericUpDown).Font, FontStyle.Regular)
    '        End If

    '    End Sub

    '    Public Sub New()

    '         Llamada necesaria para el diseñador.
    '        InitializeComponent()

    '         Agregue cualquier inicialización después de la llamada a InitializeComponent().
    '        For Each c As Control In Me.GroupBoxCDC.Controls
    '            Select Case c.GetType
    '                Case GetType(TextBox), GetType(CheckBox), GetType(ComboBox), GetType(NumericUpDown)
    '                    AddHandler c.GotFocus, AddressOf CustomGotFocus
    '                    AddHandler c.LostFocus, AddressOf CustomLostFocus
    '            End Select
    '        Next

    '        AddHandler Me.KeyDown, AddressOf FormularioKeyDown

    '    End Sub

    '    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
    '        Cancelar()
    '    End Sub

    '    Private Sub Cancelar()
    '        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    '        Me.Close()
    '    End Sub

    '    Private Sub InicializarCombos()
    '        InicializarComboMateriales()
    '        InicializarComboImputNegativos()
    '    End Sub


    '    Private Sub CargaGrilla()

    '        If FOLVRegistros.Items.Count = 30 Then
    '            MessageBox.Show("No Puede cargar mas de 30 Materiales", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        ElseIf CtlComboMaterial.SelectedItem Is Nothing Then
    '            MessageBox.Show("Debe Ingresar Un Material Válido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            CtlComboMaterial.Focus()
    '        ElseIf Valida(DirectCast(CtlComboMaterial.SelectedItem, Entidades.Materialcpra).Codigo) = 1 Then
    '            MessageBox.Show("No puede cargar un material dos veces ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            CtlComboMaterial.Focus()
    '        Else

    '            EntidadDet = New Entidades.Ingresosdet

    '            EntidadDet.Codmaterial = Me.CtlComboMaterial.SelectedValue
    '            EntidadDet.Cantidad = Me.numCantidad.Value
    '            EntidadDet.Precio = DirectCast(CtlComboMaterial.SelectedItem, Entidades.Materialcpra).Precioultcompra
    '            EntidadDet.Cbtetipo = _repositorio.GetByParam("ConceptoValeConsumo")
    '            EntidadDet.Cbteptovta = 0
    '            EntidadDet.Cbtenumero = 0
    '            EntidadDet.NombreMaterial = DirectCast(CtlComboMaterial.SelectedItem, Entidades.Materialcpra).Nombre
    '            EntidadDet.Unidad = DirectCast(CtlComboMaterial.SelectedItem, Entidades.Materialcpra).SimboloUnidad
    '            EntidadDet.PuntoMinimo = DirectCast(CtlComboMaterial.SelectedItem, Entidades.Materialcpra).Puntominimo
    '            EntidadDet.Existencia = _repositorio.GetByExistencia(CtlComboMaterial.SelectedValue)

    '            If (EntidadDet.Existencia - EntidadDet.Cantidad) < EntidadDet.PuntoMinimo Then
    '                EntidadDet.Observacion = "ATENCIÓN"
    '            End If
    '            If (EntidadDet.Existencia - EntidadDet.Cantidad) < 0 Then
    '                EntidadDet.Observacion = "FALTANTE"
    '            End If

    '            _Lista.Add(EntidadDet)

    '            Me.CtlComboMaterial.SelectedIndex = -1
    '            Me.numCantidad.Value = 1
    '            Me.CtlComboMaterial.Focus()

    '            PoblarGrilla()
    '        End If

    '    End Sub

    '    Private Sub EliminarGrilla()
    '        If Me.FOLVRegistros.SelectedIndex < 0 Then
    '            MessageBox.Show("No Seleccionó ningún Registro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Else
    '            _Lista.Remove(_Lista.Item(Me.FOLVRegistros.SelectedIndex))
    '            PoblarGrilla()
    '        End If
    '    End Sub
    '    Private Function Valida(ByRef Material As String) As Integer
    '        Dim a = 0
    '        For i As Integer = 0 To Me.FOLVRegistros.Items.Count - 1 Step 1
    '            If DirectCast(Me.FOLVRegistros.Objects(i), Entidades.Ingresosdet).Codmaterial = Material Then
    '                a = 1
    '                Exit For
    '            End If

    '        Next

    '        Return a
    '    End Function
    '    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)

    '        Select Case e.KeyCode
    '            Case Keys.F12 : CargarIngreso()
    '            Case Keys.Escape : Cancelar()
    '            Case Keys.Return
    '                If Not Me.ActiveControl.Tag = "observacion" Then
    '                    SendKeys.Send("{TAB}")
    '                End If
    '            Case Keys.Delete
    '                EliminarGrilla()
    '        End Select
    '    End Sub


    '    Private Sub ActualizaNumeracion()

    '        Dim cbte As Int32

    '        cbte = _repositorio.GetByParam("UltNroValesConsumo")

    '        If cbte >= 0 Then
    '            Me.TextBoxVale.Text = Format(cbte + 1, "00000000")
    '        End If

    '    End Sub
    '    Private Sub BtnCargar_Click(sender As System.Object, e As System.EventArgs) Handles BtnCargar.Click
    '        CargarIngreso()
    '    End Sub
    '    Private Sub CargarIngreso()
    '        Dim mlngCopias As Integer
    '        Try
    '            If FOLVRegistros.Items.Count = 0 Then
    '                MessageBox.Show("No cargó ningun artículo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                Me.CtlComboMaterial.Focus()
    '            ElseIf CtlComboImpNegativa.SelectedItem Is Nothing Then
    '                MessageBox.Show("Debe Ingresar Una Imputación de Egreso", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                CtlComboImpNegativa.Focus()
    '            Else
    '                ActualizaNumeracion()
    '                mlngCopias = -1
    '                frmImpresion.mstrConcepto = "EMISIÓN VALE DE CONSUMO"
    '                frmImpresion.mlngNumero = Convert.ToInt32(Me.TextBoxVale.Text)
    '                If frmImpresion.ShowDialog(Me) = Windows.Forms.DialogResult.Cancel Then
    '                    Exit Sub
    '                End If

    '                mlngCopias = frmImpresion.mlngCopias

    '                If Entidad Is Nothing Then
    '                    Entidad = New Entidades.Ingresoscab
    '                End If

    '                Entidad.Fecha = Me.DTPFecha.Value
    '                Entidad.Tipo = "E"
    '                Entidad.Codimpeg = Me.CtlComboImpNegativa.SelectedValue
    '                Entidad.Cbte = Me.TextBoxVale.Text
    '                Entidad.Observacion = Me.TextBoxObservacion.Text
    '                Entidad.Parametro = "UltNroValesConsumo"
    '                Entidad.Ingresosdet = _Lista

    '                _repositorio.Save(Entidad)

    '                If _repositorio.HasError Then

    '                    MessageBox.Show(_repositorio.mensajes.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

    '                Else

    '                    MessageBox.Show("La operación ha finalizado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

    '                    If mlngCopias > 0 Then
    '                        Reporte(mlngCopias)
    '                    End If

    '                    Me.Close()

    '                End If
    '            End If


    '        Catch ex As Exception
    '            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End Try
    '    End Sub
    '    Private Sub Reporte(Optional ByVal copies As Short = -1)

    '        Try

    '            Dim r As New GeneradorReportes.Reporte

    '            r.Nombre = Me.Text

    '            r.SourceFile = My.Settings.RutaReportes & "\infEmisionValesConsumo.rdl"

    '            r.Parametros.Add(New GeneradorReportes.Parametro("titulo", "VALE DE CONSUMO Nº " & Format(CInt(Me.TextBoxVale.Text), "00000000")))
    '            r.Parametros.Add(New GeneradorReportes.Parametro("IdCbte", Entidad.Id))
    '            r.Parametros.Add(New GeneradorReportes.Parametro("CodImpNeg", DirectCast(CtlComboImpNegativa.SelectedItem, Entidades.Imputacioneg).Codigo & " - " & DirectCast(CtlComboImpNegativa.SelectedItem, Entidades.Imputacioneg).Nombre))
    '            r.Parametros.Add(New GeneradorReportes.Parametro("fecha", Format(Me.DTPFecha.Value, "dd/MM/yy")))
    '            r.Parametros.Add(New GeneradorReportes.Parametro("observaciones", Me.TextBoxObservacion.Text))

    '            SetearEncabezadosReporte(r)

    '            r.PrintReport(copies)
    '            r.ShowReport()

    '            Me.Close()

    '        Catch ex As Exception
    '            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End Try

    '    End Sub
    '    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
    '        CargaGrilla()
    '    End Sub

    '    Private Sub btnQuitar_Click(sender As System.Object, e As System.EventArgs) Handles btnQuitar.Click
    '        EliminarGrilla()
    '    End Sub

    '    Private Sub FOLVRegistros_CellEditFinishing(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles FOLVRegistros.CellEditFinishing

    '        If e.Column.AspectName = "Cantidad" Then
    '            If e.NewValue >= 0.01 And e.NewValue <= 9999.99 Then
    '                DirectCast(e.RowObject, Entidades.Ingresosdet).Cantidad = e.NewValue
    '            End If
    '        End If

    '        Me.FOLVRegistros.RefreshObject(Me.FOLVRegistros.SelectedObject)
    '        Me.FOLVRegistros.Refresh()

    '    End Sub

    '    Private Sub FOLVRegistros_CellEditStarting(sender As Object, e As BrightIdeasSoftware.CellEditEventArgs) Handles FOLVRegistros.CellEditStarting
    '        e.Control.BackColor = Color.LightGreen

    '        If e.Control.GetType = GetType(BrightIdeasSoftware.FloatCellEditor) Then
    '            DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Font = New Font(DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Font, FontStyle.Bold)
    '            DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Select(0, DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Text.Length)
    '        End If
    '    End Sub

    '    Private Sub FOLVRegistros_CellEditValidating(sender As Object, e As BrightIdeasSoftware.CellEditEventArgs) Handles FOLVRegistros.CellEditValidating

    '        Select Case e.Column.AspectName
    '            Case "Cantidad"
    '                If e.NewValue <= 0 Or e.NewValue > 9999.99 Then
    '                    If e.Control.GetType = GetType(BrightIdeasSoftware.FloatCellEditor) Then
    '                        DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).BackColor = Color.Red
    '                        DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Select(0, DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Text.Length)
    '                    End If
    '                    e.Cancel = True
    '                End If
    '        End Select

    '    End Sub

    '    Private Sub TextBoxVale_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxVale.KeyPress

    '        If Not IsNumeric(e.KeyChar) Then
    '            e.Handled = True
    '        End If

    '    End Sub

    '    Private Sub FOLVRegistros_FormatCell(sender As Object, e As BrightIdeasSoftware.FormatCellEventArgs) Handles FOLVRegistros.FormatCell

    '        If e.Column.AspectName = "Observacion" Then
    '            Pongo en Negrita
    '            e.SubItem.Font = New System.Drawing.Font(e.SubItem.Font.Name, e.SubItem.Font.Size, FontStyle.Bold)
    '            e.Item.SubItems(e.ColumnIndex).Font = New System.Drawing.Font(e.SubItem.Font.Name, e.SubItem.Font.Size, FontStyle.Bold)

    '            Select Case e.SubItem.Text
    '                Case "ATENCIÓN"
    '                    e.SubItem.BackColor = Color.Orange
    '                    e.SubItem.ForeColor = Color.White
    '                Case "FALTANTE"
    '                    e.SubItem.BackColor = Color.Red
    '                    e.SubItem.ForeColor = Color.White
    '                Case Else
    '                    e.SubItem.BackColor = Color.White
    '                    e.SubItem.ForeColor = Color.Black
    '            End Select
    '        End If
    '    End Sub


End Class