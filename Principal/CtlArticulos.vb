Public Class CtlArticulos

    Private _importes As New List(Of Importes)
    ReadOnly Property Importes As List(Of Importes)
        Get
            Return _importes
        End Get
    End Property

    'totalizadores del comprobante
    Private _cantidad As Double = 0.0
    ReadOnly Property Cantidad As Double
        Get
            Return _cantidad
        End Get
    End Property

    'totalizadores del comprobante
    Private _subtotal As Double = 0.0
    ReadOnly Property Subtotal As Double
        Get
            Return _subtotal
        End Get
    End Property

    Private _articulosventa As New List(Of Entidades.CbteArticulo2)
    Property ArticulosVenta As List(Of Entidades.CbteArticulo2)
        Set(ByVal value As List(Of Entidades.CbteArticulo2))
            _articulosventa = value
        End Set
        Get
            Return _articulosventa
        End Get
    End Property

    Private _total As Double = 0.0
    ReadOnly Property Total As Double
        Get
            Return _total
        End Get
    End Property

    Event Totalizado()
    Event ExitControl()

    Private _decimalSeparator As Char

    Enum ListaPrecios
        LISTA_A = 1
        LISTA_B = 2
        LISTA_C = 3
        COSTO = 4
    End Enum

    Enum TipoCbte
        CBTEVTA = 1
        CBTECPRA = 2
    End Enum

    Enum TipoCbteCpra
        CBTEPRESUPUESTO = 1
    End Enum

    Property TipoCargaCbte As TipoEmisionCbte
    Property ListaDePrecio As ListaPrecios = ListaPrecios.LISTA_A
    Property TipoDeCbte As TipoCbte = TipoCbte.CBTEVTA
    Property MaximoItems As UInt16 = 25
    Property DescuentoGral As Double = 0.0
    Private hiddenPages As New List(Of TabPage)
    Property idCliente As String

    Public Sub Inicializar()

        CrearGrillas()

        InicializarCombos()

        Me.TextBoxSubtotalArticulo.ReadOnly = True
        Me.ComboBoxUnidad.Enabled = Me.TipoDeCbte '= TipoCbte.CBTEVTA
        Me.ComboBoxMoneda.Enabled = Me.TipoDeCbte

    End Sub

    Public Sub Limpiar()

        'articulos
        For Each c As Control In Me.Panel1.Controls
            Select Case c.GetType
                Case GetType(TextBox) : DirectCast(c, TextBox).Text = ""
                Case GetType(ComboBox) : DirectCast(c, ComboBox).SelectedIndex = -1
                Case GetType(CheckBox) : DirectCast(c, CheckBox).Checked = False
                Case GetType(DateTimePicker) : DirectCast(c, DateTimePicker).Value = Date.Now
                Case GetType(GroupBox)
                    For Each g As Control In c.Controls
                        Select Case g.GetType
                            Case GetType(TextBox) : DirectCast(g, TextBox).Text = ""
                            Case GetType(ComboBox) : DirectCast(g, ComboBox).SelectedIndex = -1
                            Case GetType(CheckBox) : DirectCast(g, CheckBox).Checked = False
                        End Select
                    Next
            End Select
        Next

        _articulosventa.Clear()
        _importes.Clear()

        'articulos cabecera
        Me.TextBoxCantidad.Text = ""
        Me.TextBoxImporte.Text = 0.0
        Me.ComboBoxUnidad.SelectedIndex = 0
        Me.ComboBoxMoneda.SelectedIndex = 0

        PoblarGrillas()

        'limpio totales
        Totalizar()

    End Sub

    Public Sub Totalizar()

        Dim subtotal As Double = 0.0
        Dim otrostributos As Double = 0.0
        Dim iva As Double = 0.0
        Dim total As Double = 0.0
        Dim exento As Double = 0
        Dim nogravado As Double = 0
        Dim totalaplicado As Double = 0.0
        Dim totalcartera As Double = 0.0
        Dim totalctaspropias As Double = 0.0
        Dim cantidad As Double = 0.0
        Dim descuento As Double = 0.0

        Dim mblnPesos As Boolean
        Dim mblnDolares As Boolean
        mblnPesos = False
        mblnDolares = False

        Select Case Me.TipoCargaCbte
            Case TipoEmisionCbte.PRESUPUESTO
                For Each a As Entidades.CbteArticulo2 In _articulosventa
                    If a.Moneda = "PES" Then mblnPesos = True
                    If a.Moneda = "DOL" Then mblnDolares = True

                    If a.Unidad = "KG" Then
                        subtotal = 0
                        exento = 0
                        iva = 0
                        descuento = 0
                        Exit For
                    End If
                    subtotal += a.Subtotal
                    exento += a.SubtotalExento
                    iva += a.SubtotalIVA
                    descuento += a.ImporteDescuento
                Next

                'Si es BiMoneda, dejo en Cero el Presupuesto
                If mblnPesos = True And mblnDolares = True Then
                    subtotal = 0
                    exento = 0
                    iva = 0
                    descuento = 0
                End If
        End Select

        _subtotal = Math.Round(subtotal, 2)
        _cantidad = Math.Round(cantidad, 2)

        total = _subtotal '+ _iva + _otrostributos + _exento + _nogravado

        _total = Math.Round(total, 2)

        RaiseEvent Totalizado()

    End Sub

    Private Sub AgregarArticulo()

        Select Case Me.TipoCargaCbte
            Case TipoEmisionCbte.PRESUPUESTO : AgregarArticuloVenta()
                'Case Else : AgregarArticuloCompra()
        End Select



    End Sub

    Public Sub PoblarGrillas()
        PoblarGrillaArticulo()
    End Sub

    Private Sub InicializarComboUnidades()

        With Me.ComboBoxUnidad
            .DropDownStyle = ComboBoxStyle.DropDownList
            .Items.Clear()
            .Items.Add("C/U")
            .Items.Add("KG")
            .SelectedIndex = 0
        End With

        With Me.ComboBoxMoneda
            .DropDownStyle = ComboBoxStyle.DropDownList
            .Items.Clear()
            .Items.Add("PES")
            .Items.Add("DOL")
            .SelectedIndex = 0
        End With

    End Sub

    Private Sub PoblarGrillaArticulo()
        Select Case Me.TipoCargaCbte
            Case TipoEmisionCbte.PRESUPUESTO
                Me.FOLVArticulos.Objects = _articulosventa
        End Select

    End Sub

    Private Sub CrearGrillaArticulos()

        Dim c As BrightIdeasSoftware.OLVColumn

        With FOLVArticulos

            .Columns.Clear()

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Id"
            c.AspectName = "Id"
            c.MinimumWidth = 0
            c.MaximumWidth = 0
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = False
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Cant."
            c.AspectName = "Cantidad"
            c.IsEditable = True
            c.MinimumWidth = 20
            '            c.AspectToStringConverter = Function(x As Double)
            '                                            Return x.ToString("#,##0.00")
            '                                        End Function
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Código"
            c.AspectName = "Codigo"
            c.MinimumWidth = 110
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = True
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Artículo"
            c.AspectName = "Descripcion"
            c.MinimumWidth = 320
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = True
            .Columns.Add(c)

            'c = New BrightIdeasSoftware.OLVColumn
            'c.Text = "Material"
            'c.AspectName = "Material"
            'c.IsEditable = True
            'c.MinimumWidth = 160
            ''c.WordWrap = True
            'c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            'c.FillsFreeSpace = True
            '.Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Un."
            c.AspectName = "Unidad"
            c.MinimumWidth = 10
            c.TextAlign = HorizontalAlignment.Center
            c.AutoResize(ColumnHeaderAutoResizeStyle.None)
            c.IsEditable = False
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Moneda"
            c.AspectName = "Moneda"
            c.MinimumWidth = 10
            c.TextAlign = HorizontalAlignment.Center
            c.AutoResize(ColumnHeaderAutoResizeStyle.None)
            c.IsEditable = True 'False
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Precio"
            c.AspectName = "Importe"
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("#,##0.00")
                                        End Function
            c.MinimumWidth = 75
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsVisible = True
            c.IsEditable = True
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Subtotal"
            c.AspectName = "Subtotal"
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("#,##0.00")
                                        End Function
            c.MinimumWidth = 75
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = False
            c.IsVisible = True
            .Columns.Add(c)

            .CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick
            .CellEditEnterChangesRows = True
            'End If
            .RowHeight = 32
            .FullRowSelect = True
            .UseFiltering = False
            .ClearObjects()
            .Refresh()
        End With

    End Sub

    Private Sub QuitarArticulo()

        If FOLVArticulos.SelectedObject IsNot Nothing Then

            Select Case Me.TipoCargaCbte
                Case TipoEmisionCbte.PRESUPUESTO
                    _articulosventa.Remove(DirectCast(Me.FOLVArticulos.SelectedObject, Entidades.CbteArticulo2))
            End Select

            PoblarGrillas()

            Totalizar()

        End If

    End Sub

    Private Sub TotalizarLinea()
        Dim c As Double
        Dim i As Double
        Dim ii As Double
        Dim dto As Double
        Dim dto2 As Double
        Dim dto3 As Double
        Dim s As Double

        c = Val(Me.TextBoxCantidad.Text)
        i = Val(Me.TextBoxImporte.Text)
        dto = 0 'Math.Round(i * (Val(Me.TextBoxDto.Text) / 100), 2)
        dto2 = 0 'Math.Round((i - dto) * (Val(Me.TextBoxDto2.Text) / 100), 2)
        dto3 = 0 'Math.Round((i - (dto + dto2)) * (Val(Me.TextBoxDto3.Text) / 100), 2)
        i -= (dto + dto2 + dto3)
        s = c * (i + ii)

        Select Case Me.TipoCargaCbte
            Case TipoEmisionCbte.PRESUPUESTO

                If Me.ComboBoxUnidad.SelectedIndex = 1 Then
                    'Si es Kgs no totaliza
                    Me.TextBoxSubtotalArticulo.Text = ""
                    s = 0
                Else
                    Me.TextBoxSubtotalArticulo.Text = s
                End If
            Case Else
                Me.TextBoxSubtotalArticulo.Text = s
        End Select

    End Sub

    Private Sub CustomKeyPressOnlyNumbers(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(_decimalSeparator) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
    End Sub

    Private Sub BtnAgregarArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarArticulo.Click
        AgregarArticulo()
    End Sub

    Private Sub CustomGotFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = Color.LightSteelBlue

        If sender.GetType = GetType(TextBox) Then
            DirectCast(sender, TextBox).Font = New Font(DirectCast(sender, TextBox).Font, FontStyle.Bold)
            DirectCast(sender, TextBox).SelectAll()
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
        For Each c As Control In Me.Panel1.Controls
            Select Case c.GetType
                Case GetType(TextBox), GetType(ComboBox)
                    AddHandler c.GotFocus, AddressOf CustomGotFocus
                    AddHandler c.LostFocus, AddressOf CustomLostFocus
                Case GetType(GroupBox)
                    For Each g As Control In c.Controls
                        Select Case g.GetType
                            Case GetType(TextBox), GetType(ComboBox)
                                AddHandler g.GotFocus, AddressOf CustomGotFocus
                                AddHandler g.LostFocus, AddressOf CustomLostFocus
                        End Select
                    Next
            End Select
        Next



        'inputs solo numeros
        AddHandler Me.TextBoxImporte.KeyPress, AddressOf CustomKeyPressOnlyNumbers
        AddHandler Me.TextBoxCantidad.KeyPress, AddressOf CustomKeyPressOnlyNumbers
        AddHandler Me.TextBoxSubtotalArticulo.KeyPress, AddressOf CustomKeyPressOnlyNumbers

        'textchanged
        AddHandler Me.TextBoxImporte.TextChanged, AddressOf CustomTextChange
        AddHandler Me.TextBoxCantidad.TextChanged, AddressOf CustomTextChange

        'keydown
        'AddHandler Me.cboMaterial.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.cboArticulo.KeyDown, AddressOf CustomKeyDown
        'AddHandler Me.txtCodigo.KeyDown, AddressOf CustomKeyDown
        'AddHandler Me.txtPieza.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.TextBoxImporte.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.TextBoxCantidad.KeyDown, AddressOf CustomKeyDown
        AddHandler Me.TextBoxSubtotalArticulo.KeyDown, AddressOf CustomKeyDown

        _decimalSeparator = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator

    End Sub

    Private Sub FOLVArticulos_CellEditFinishing(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles FOLVArticulos.CellEditFinishing

        Select Case e.Column.AspectName
            Case "Codigo"
                DirectCast(e.RowObject, Entidades.CbteArticulo2).Codigo = e.NewValue
            Case "Descripcion"
                DirectCast(e.RowObject, Entidades.CbteArticulo2).Descripcion = e.NewValue
                'Case "Material"
                '    DirectCast(e.RowObject, Entidades.CbteArticulo2).Material = e.NewValue
            Case "Cantidad"
                DirectCast(e.RowObject, Entidades.CbteArticulo2).Cantidad = e.NewValue
            Case "Moneda"
                DirectCast(e.RowObject, Entidades.CbteArticulo2).Moneda = e.NewValue
            Case "Importe"
                DirectCast(e.RowObject, Entidades.CbteArticulo2).Importe = e.NewValue
        End Select

        Me.FOLVArticulos.RefreshObject(Me.FOLVArticulos.SelectedObject)
        Me.FOLVArticulos.Refresh()

        Totalizar()

        Me.TextBoxCantidad.Focus()
        Me.TextBoxCantidad.Select()
        Application.DoEvents()
    End Sub

    Private Sub FOLVArticulos_CellEditValidating(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles FOLVArticulos.CellEditValidating

        Select Case e.Column.AspectName
            Case "Codigo"
                If Len(Trim(e.NewValue)) > 15 Then
                    If e.Control.GetType = GetType(BrightIdeasSoftware.FloatCellEditor) Then
                        DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).BackColor = Color.Red
                        DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Select(0, DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Text.Length)
                    End If
                    e.Cancel = True
                End If
            Case "Descripcion"
                If Len(Trim(e.NewValue)) > 80 Then
                    If e.Control.GetType = GetType(BrightIdeasSoftware.FloatCellEditor) Then
                        DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).BackColor = Color.Red
                        DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Select(0, DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Text.Length)
                    End If
                    e.Cancel = True
                End If
            Case "Material"
                If Len(Trim(e.NewValue)) > 30 Then
                    If e.Control.GetType = GetType(BrightIdeasSoftware.FloatCellEditor) Then
                        DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).BackColor = Color.Red
                        DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Select(0, DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Text.Length)
                    End If
                    e.Cancel = True
                End If
            Case "Cantidad", "Importe"
                If Val(e.NewValue) < 0 Then
                    If e.Control.GetType = GetType(BrightIdeasSoftware.FloatCellEditor) Then
                        DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).BackColor = Color.Red
                        DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Select(0, DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Text.Length)
                    End If
                    e.Cancel = True
                End If
                'Case "Descuento1", "Descuento2", "Descuento3"
                '    If Val(e.NewValue) < 0 Or Val(e.NewValue) > 100 Then
                '        If e.Control.GetType = GetType(BrightIdeasSoftware.FloatCellEditor) Then
                '            DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).BackColor = Color.Red
                '            DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Select(0, DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Text.Length)
                '        End If
                '        e.Cancel = True
                '    End If
        End Select
    End Sub

    Private Sub FOLVArticulos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FOLVArticulos.KeyDown
        If e.KeyCode = Keys.Delete Then

            QuitarArticulo()

        End If
    End Sub

    Private Sub TabPage1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage1.Click
        Me.cboArticulo.Focus()
    End Sub

    Public Sub FocoArticulo()
        Me.TabControl1.SelectedTab = Me.TabPage1
        Me.cboArticulo.Focus()
        'Application.DoEvents()
    End Sub

    Private Sub CustomKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Return
                If sender Is cboArticulo Then
                    Me.TextBoxCantidad.Focus()
                    'If txtCodigo.Text.Length = 0 And txtPieza.Text.Length = 0 And txtMaterial.Text.Length = 0 Then
                    '    RaiseEvent ExitControl()
                    'End If
                ElseIf sender Is TextBoxImporte Then
                    Call AgregarArticulo()
                Else
                    SendKeys.Send(vbTab)
                End If
        End Select
    End Sub

    Private Sub InicializarCombos()
        InicializarComboUnidades()
        InicializarComboPiezas()
        'InicializarComboMateriales()
    End Sub
    'Private Sub InicializarComboMateriales(ByVal Codigo As String)
    '    Dim _repositorioMaterial As New CapaLogica.MaterialesCLog
    '    With Me.cboMaterial
    '        .ValueMember = "Codigo"
    '        .DisplayMember = "CodigoyNombre"
    '        .DataSource = _repositorioMaterial.GetByCodigo(Codigo)
    '        .AutoCompleteMode = AutoCompleteMode.Suggest
    '        .AutoCompleteSource = AutoCompleteSource.ListItems
    '        .DropDownStyle = ComboBoxStyle.DropDownList
    '        '.FormularioDeAlta = FormMateriales
    '        .Inicializar()
    '        If cboMaterial.Items.Count > 0 Then
    '            .SelectedIndex = 0
    '        Else
    '            .SelectedIndex = -1
    '        End If

    '    End With
    'End Sub
    Private Sub InicializarComboPiezas()
        Dim _repoArt As New CapaLogica.ArticuloCLog
        With Me.cboArticulo
            .ValueMember = "Codigo"
            .DisplayMember = "CodigoyNombre"
            .DataSource = _repoArt.GetAll.OrderBy(Function(x) x.Codigo).ToList()
            '.DataSource = _repoArt.GetAll(False, False).Where(Function(x) x.Codcliente = IIf(idCliente Is Nothing, 0, idCliente)).OrderBy(Function(x) x.Codigo).ToList()
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .DropDownStyle = ComboBoxStyle.DropDownList
            .FormularioDeAlta = FormArticulo
            .Inicializar()
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub CrearGrillas()

        If Me.TipoCargaCbte = TipoEmisionCbte.PRESUPUESTO Then
            CrearGrillaArticulos()
        End If
    End Sub

    Private Sub FOLVArticulos_CellEditStarting(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles FOLVArticulos.CellEditStarting

        If FOLVArticulos.SelectedObject IsNot Nothing Then

            Select Case e.Column.AspectName
                Case "Importe", "Cantidad", "Descripcion", "Material"
                Case "Moneda"
                    Dim cb As New ComboBox
                    cb.SetBounds(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height)
                    cb.Font = sender.font
                    cb.ValueMember = "Codigo"
                    cb.DisplayMember = "Nombre"
                    cb.DataSource = GetMonedas()
                    cb.DropDownStyle = ComboBoxStyle.DropDownList
                    cb.SelectedValue = e.Value
                    e.Control = cb
                Case Else
                    e.Cancel = True
            End Select

            e.Control.BackColor = Color.LightSteelBlue

            If e.Control.GetType = GetType(BrightIdeasSoftware.FloatCellEditor) Then
                DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Font = New Font(DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Font, FontStyle.Bold)
                DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Select(0, DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Text.Length)
            End If

        Else
            e.Cancel = True
        End If

    End Sub

    Private Sub CustomTextChange(ByVal sender As Object, ByVal e As EventArgs)
        TotalizarLinea()
    End Sub

    Private Sub AgregarArticuloVenta()
        Dim e As New Entidades.CbteArticulo2

        Dim encontro As Boolean = False

        Try

            'If Me.txtCodigo.Text.Length = 0 Then
            '    Me.txtCodigo.Focus()
            '    Throw New Exception("El Código ingresado no es válido")
            'End If

            If Me.cboArticulo.SelectedItem Is Nothing Then
                Me.cboArticulo.Focus()
                Throw New Exception("Debe seleccionar una pieza")
            End If

            If _articulosventa.Count >= Me.MaximoItems Then
                Me.TextBoxCantidad.Focus()
                Throw New Exception("Se alcanzo el limite de artículos para el comprobante")
            End If

            If Not IsNumeric(Me.TextBoxCantidad.Text) Then
                'Me.TextBoxCantidad.Focus()
                'Throw New Exception("La cantidad ingresada no es válida")
                Me.TextBoxCantidad.Text = "0"
            End If

            If Convert.ToDouble(Me.TextBoxCantidad.Text) < 0 Then
                Me.TextBoxCantidad.Focus()
                Throw New Exception("La cantidad ingresada no es válida")
            End If

            If Not IsNumeric(Me.TextBoxImporte.Text) Then
                Me.TextBoxImporte.Focus()
                Throw New Exception("El importe ingresado no es válido")
            End If

            If Me.ComboBoxUnidad.SelectedItem Is Nothing Then
                Me.ComboBoxUnidad.Focus()
                Throw New Exception("La Unidad no es válida")
            End If

            If Me.ComboBoxMoneda.SelectedItem Is Nothing Then
                Me.ComboBoxMoneda.Focus()
                Throw New Exception("La Moneda no es válida")
            End If

            e.Cantidad = Convert.ToDouble(Me.TextBoxCantidad.Text)
            e.Cantidad = Math.Round(e.Cantidad, 2)
            e.Codigo = DirectCast(Me.cboArticulo.SelectedItem, Entidades.Articulo).Codigo 'Me.txtCodigo.Text
            e.Descripcion = DirectCast(Me.cboArticulo.SelectedItem, Entidades.Articulo).Nombre 'Me.txtPieza.Text
            'e.Material = DirectCast(Me.cboMaterial.SelectedItem, Entidades.Materiales).Nombre
            e.Unidad = Convert.ToString(ComboBoxUnidad.SelectedItem)
            e.Moneda = Convert.ToString(ComboBoxMoneda.SelectedItem)
            e.Importe = Convert.ToDouble(Me.TextBoxImporte.Text)

            _articulosventa.Add(e)

            PoblarGrillas()

            Totalizar()

            'articulos cabecera
            'Me.cboPieza.SelectedIndex = 0
            'Me.txtCodigo.Text = ""
            'Me.txtPieza.Text = ""
            'Me.cboMaterial.SelectedIndex = 0
            Me.ComboBoxUnidad.SelectedIndex = 0
            Me.ComboBoxMoneda.SelectedIndex = 0
            Me.TextBoxCantidad.Text = ""
            Me.TextBoxImporte.Text = 0.0

            Me.cboArticulo.FocoDetalle()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Agregar Artículo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Private Sub cboPieza_CodigoEncontrado()

    '    If DirectCast(Me.cboPieza.SelectedItem, Entidades.Articulo).Codunidad = "01" Then 'kg
    '        Me.ComboBoxUnidad.SelectedIndex = 1
    '    ElseIf DirectCast(Me.cboPieza.SelectedItem, Entidades.Articulo).Codunidad = "02" Then 'unidad
    '        Me.ComboBoxUnidad.SelectedIndex = 0
    '    End If

    '    Me.TextBoxImporte.Text = Format(DirectCast(Me.cboPieza.SelectedItem, Entidades.Articulo).Preciodeventa, "0.00")

    '    cboMaterial.SelectedValue = DirectCast(Me.cboPieza.SelectedItem, Entidades.Articulo).Codmaterial

    '    Me.cboMaterial.Focus()
    '    Me.cboMaterial.Select()
    '    'Me.txtPieza.Text = cboPieza.SelectedValue
    '    Application.DoEvents()
    '    Me.cboMaterial.Focus()
    '    Me.cboMaterial.Select()

    'End Sub

    Private Function GetMonedas() As List(Of TempItem)
        Dim ret As New List(Of TempItem)
        Dim i As TempItem

        i = New TempItem
        i.Codigo = "PES"
        i.Nombre = "PES"

        ret.Add(i)

        i = New TempItem
        i.Codigo = "DOL"
        i.Nombre = "DOL"

        ret.Add(i)

        Return ret

    End Function

    Private Class TempItem
        Property Codigo As String
        Property Nombre As String
    End Class

    Private Sub TextBoxImporte_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles TextBoxImporte.MouseClick
        Me.TextBoxImporte.Select(0, Me.TextBoxImporte.Text.Length)
    End Sub

    Private Sub cboPieza_CodigoEncontrado() Handles cboArticulo.CodigoEncontrado
        'If DirectCast(Me.cboPieza.SelectedItem, Entidades.Articulo) IsNot Nothing Then
        '    If DirectCast(Me.cboPieza.SelectedItem, Entidades.Articulo).Codunidad = "01" Then 'kg
        '        Me.ComboBoxUnidad.SelectedIndex = 1
        '    ElseIf DirectCast(Me.cboPieza.SelectedItem, Entidades.Articulo).Codunidad = "02" Then 'unidad
        '        Me.ComboBoxUnidad.SelectedIndex = 0
        '    End If

        '    Me.TextBoxImporte.Text = Format(DirectCast(Me.cboPieza.SelectedItem, Entidades.Articulo).Preciodeventa, "0.00")

        '    InicializarComboMateriales(DirectCast(Me.cboPieza.SelectedItem, Entidades.Articulo).Codmaterial)

        '    Me.cboMaterial.Focus()
        '    Me.cboMaterial.Select()
        '    'Me.txtPieza.Text = cboPieza.SelectedValue
        '    Application.DoEvents()
        '    Me.cboMaterial.Focus()
        '    Me.cboMaterial.Select()
        'End If


    End Sub

    Private Sub cboPieza_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboArticulo.SelectedIndexChanged
        If DirectCast(Me.cboArticulo.SelectedItem, Entidades.Articulo) IsNot Nothing Then
            If DirectCast(Me.cboArticulo.SelectedItem, Entidades.Articulo).Codunidad = "01" Then 'kg
                Me.ComboBoxUnidad.SelectedIndex = 1
            ElseIf DirectCast(Me.cboArticulo.SelectedItem, Entidades.Articulo).Codunidad = "02" Then 'unidad
                Me.ComboBoxUnidad.SelectedIndex = 0
            End If

            Me.TextBoxImporte.Text = Format(DirectCast(Me.cboArticulo.SelectedItem, Entidades.Articulo).Preciodeventa, "0.00")

            'InicializarComboMateriales(DirectCast(Me.cboPieza.SelectedItem, Entidades.Articulo).Codmaterial)


        End If
    End Sub
End Class
