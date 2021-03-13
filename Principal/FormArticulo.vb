Public Class FormArticulo

    'entidad
    Property Entidad As Entidades.Articulo

    'repositorios de tablas
    Private _repositorio As New CapaLogica.ArticuloCLog
    Private _repositorioUnidades As New CapaLogica.UnidadCLog
    Private _repositorioRubros As New CapaLogica.RubroCLog
    Private _repositorioAlicuotas As New CapaLogica.TipocondicionivaCLog
    Private _repositorioCondicionesIVA As New CapaLogica.TiporesponsableCLog
    Private _repositorioCategoria As New CapaLogica.CategoriaCLog
    'Private _Articulos As New List(Of Entidades.ArticulosEnlazados)

    Private _margenK As Double
    Private _margenR As Double
    Private _margenM As Double

    Property Consulta As Boolean = False

    'inicializar tablas foraneas
    Private Sub InicializarCombos()

        InicializarComboRubros()
        InicializarComboUnidades()
        InicializarComboAlicuotas()
        InicializarComboCategorias()
        'InicializarComboProveedores()

    End Sub

    'Private Sub InicializarComboProveedores()
    '    Dim repositorio As New CapaLogica.ProveedorCLog
    '    Dim c As BrightIdeasSoftware.OLVColumn = Nothing
    '    Dim cols As New List(Of BrightIdeasSoftware.OLVColumn)

    '    c = New BrightIdeasSoftware.OLVColumn
    '    c.Text = "Teléfono"
    '    c.AspectName = "Telefono"
    '    c.MinimumWidth = 150
    '    c.TextAlign = HorizontalAlignment.Center
    '    c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
    '    cols.Add(c)

    '    c = New BrightIdeasSoftware.OLVColumn
    '    c.Text = "Domicilio"
    '    c.AspectName = "Domicilio"
    '    c.MinimumWidth = 250
    '    c.TextAlign = HorizontalAlignment.Left
    '    c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
    '    cols.Add(c)

    '    With Me.ComboBoxProveedor
    '        .ValueMember = "Id"
    '        .DisplayMember = "NombreyCodigo"
    '        .ColumnasExtras = cols
    '        .DataSource = repositorio.GetAllOrderByNombre(soloActivos:=True)
    '        .AutoCompleteMode = AutoCompleteMode.Suggest
    '        .AutoCompleteSource = AutoCompleteSource.ListItems
    '        '.DropDownStyle = ComboBoxStyle.DropDownList
    '        If Not Consulta Then .FormularioDeAlta = FormProveedor
    '        .Inicializar()
    '        .SelectedIndex = -1
    '    End With
    'End Sub

    Private Sub InicializarComboUnidades()
        With Me.ComboBoxUnidades
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = _repositorioUnidades.GetAll
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub InicializarComboRubros()
        With Me.ComboBoxRubros
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = _repositorioRubros.GetAll
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            If Not Consulta Then .FormularioDeAlta = FormRubro
            .Inicializar()
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub InicializarComboCategorias()
        With Me.CtlComboCategoria
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = _repositorioCategoria.GetAll
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            If Not Consulta Then .FormularioDeAlta = FormCategoria
            .Inicializar()
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub InicializarComboAlicuotas()
        'documentos
        With Me.ComboBoxAlicuotas
            .ValueMember = "Codigo"
            .DisplayMember = "Descripcion"
            .DataSource = _repositorioAlicuotas.GetAll
            .DropDownStyle = ComboBoxStyle.DropDownList
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub InicializarMargenes()

        Dim repositorio As CapaLogica.ParametroCLog

        Try

            repositorio = New CapaLogica.ParametroCLog

            _margenR = 1 + (Convert.ToDouble(repositorio.GetByNombre("MargenUtilidadListaR").Valorpredeterminado) / 100)
            _margenK = 1 + (Convert.ToDouble(repositorio.GetByNombre("MargenUtilidadListaK").Valorpredeterminado) / 100)
            _margenM = 1 + (Convert.ToDouble(repositorio.GetByNombre("MargenUtilidadListaM").Valorpredeterminado) / 100)

        Catch ex As Exception

            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    'inicializo formulario, limpieza o carga de valores
    Private Sub InicializarFormulario()

        ImageList1.Images.Add(My.Resources.delete)

        Me.BtnGuardar.Enabled = Not Consulta

        'limpieza de controles
        For Each c As Control In Me.Controls
            Select Case c.GetType
                Case GetType(TextBox) : DirectCast(c, TextBox).Text = ""
                Case GetType(ComboBox) : DirectCast(c, ComboBox).SelectedIndex = -1
                Case GetType(CheckBox) : DirectCast(c, CheckBox).Checked = False
                Case GetType(NumericUpDown) : DirectCast(c, NumericUpDown).Value = 0
            End Select
        Next

        InicializarCombos()
        InicializarMargenes()

        'el campo id no se puede modificar cuando es autoincremental
        Me.TextBoxId.Enabled = False

        'editar registro
        If Not Entidad Is Nothing Then
            Me.CheckBoxActivo.Checked = Entidad.Activo
            Me.CheckBoxModifica.Checked = Entidad.Preciomodificable
            Me.TextBoxId.Text = Entidad.Id
            Me.TextBoxCodigo.Text = Entidad.Codigo
            Me.TextBoxCodigoBarra.Text = Entidad.Codigobarra
            Me.TextBoxNombre.Text = Entidad.Nombre
            'Me.TextBoxNombreCorto.Text = Entidad.Nombrecorto
            Me.TextBoxDescripcion.Text = Entidad.Descripcion
            Me.ComboBoxUnidades.SelectedValue = Entidad.Codunidad
            Me.ComboBoxAlicuotas.SelectedValue = Entidad.Alicuotaiva
            Me.ComboBoxRubros.SelectedValue = Entidad.Codrubro
            'Me.ComboBoxProveedor.SelectedValue = Entidad.Codproveedor
            Me.numPrecioVta.Value = Entidad.ImporteConIVALista1
            Me.numPrecioVta2.Value = Entidad.ImporteConIVALista2
            Me.numPrecioVta3.Value = Entidad.ImporteConIVALista3
            'Me.TextBoxPrecioVtaSug.Text = Entidad.Preciosugerido
            'Me.TextBoxPrecioCosto.Text = Entidad.Preciodecosto
            'Me.TextBoxImpuestoInterno.Text = Entidad.Impinttasanominal
            Me.CtlComboCategoria.SelectedValue = Entidad.Codcategoria
            'Me.TextBoxCantidadBulto.Text = Entidad.CantidadBulto
            'Me.TextBoxPrecioCompra.Text = Entidad.Preciodecompra
            'Me.TextBoxPtoMinimo.Text = Entidad.Puntominimo
            'Me.TextBoxDescuento.Text = Entidad.Descuento
            'Me.TextBoxDescuento2.Text = Entidad.Descuento2
            'Me.TextBoxDescuento3.Text = Entidad.Descuento3
            'Me.TextBoxRenta1.Text = Entidad.Rentabilidad1
            'Me.TextBoxRenta2.Text = Entidad.Rentabilidad2
            'Me.TextBoxRenta3.Text = Entidad.Rentabilidad3
            'Me.TextBoxDtoCompra1.Text = Entidad.Descuentocompra1
            'Me.TextBoxDtoCompra2.Text = Entidad.Descuentocompra2
            'Me.TextBoxDtoCompra3.Text = Entidad.Descuentocompra3
            'Me.TextBoxDtoCompra4.Text = Entidad.Descuentocompra4
            Me.numCoeficienteKg.Value = Entidad.CoeficienteKG
            'Me.TextBoxPesoNeto.Text = Entidad.Pesoneto
            'Me.TextBoxPrecioCostoDolar.Text = Entidad.PreciocostoUS
            'Me.CheckBoxFlete.Checked = Entidad.Flete
            'Me.TextBoxUnidad.Text = Entidad.Unidaddescripcion
            'Me._Articulos = Entidad.ArticulosEnlazados

            'Me.DTPUltCompra.Value = Entidad.Fechaultimacompra
            'Me.TextBoxImpuestoInternoImp.Text = Entidad.Impuestointerno
            Me.Text = "Editar registro"

            If Me.Consulta Then
                Me.Text = "Consulta de Artículo"
            End If

            Me.TextBoxCodigo.Enabled = False
            Me.CheckBoxOferta.Checked = Entidad.Oferta
            MostrarTotales()
            Me.TextBoxCodigo.Select()
        Else 'nuevo registro, valores por defecto

            Me.Text = "Nuevo registro"
            Me.TextBoxId.Text = "0"
            Me.CheckBoxActivo.Checked = True
            Me.CheckBoxModifica.Checked = True
            Me.TextBoxCodigo.Enabled = True
            Me.TextBoxCodigo.Text = _repositorio.GetNextCodigo
            Me.TextBoxCodigoBarra.Text = ""
            Me.numPrecioVta.Value = 0
            Me.numPrecioVta2.Value = 0
            Me.numPrecioVta3.Value = 0
            'Me.TextBoxPrecioVtaSug.Text = 0.0
            'Me.TextBoxPrecioCosto.Text = 0.0
            'Me.TextBoxImpuestoInterno.Text = 0.0
            'Me.TextBoxImpuestoInternoImp.Text = 0.0
            'Me.TextBoxPrecioCompra.Text = 0.0
            'Me.TextBoxCantidadBulto.Text = 1.0
            'Me.TextBoxPtoMinimo.Text = 0.0
            'Me.TextBoxDescuento.Text = 0.0
            'Me.TextBoxDescuento2.Text = 0.0
            'Me.TextBoxDescuento3.Text = 0.0
            'Me.TextBoxDtoCompra1.Text = 0.0
            'Me.TextBoxDtoCompra2.Text = 0.0
            'Me.TextBoxDtoCompra3.Text = 0.0
            'Me.TextBoxDtoCompra4.Text = 0.0
            'Me.TextBoxRenta1.Text = 0.0
            'Me.TextBoxRenta2.Text = 0.0
            'Me.TextBoxRenta3.Text = 0.0
            numCoeficienteKg.Value = 0
            'Me.TextBoxPesoNeto.Text = 0.0
            'Me.TextBoxPrecioCostoDolar.Text = 0.0
            'Me.CheckBoxFlete.Checked = False

            Me.CheckBoxOferta.Checked = False
            Me.ComboBoxAlicuotas.SelectedValue = IVA_21
            Me.ComboBoxUnidades.SelectedValue = "00"
            'Me._Articulos.Clear()
            Me.TextBoxCodigo.Select()
        End If
    End Sub


    Private Sub FormArticulo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'iniciar formulario
        InicializarFormulario()
    End Sub

    Private Sub CustomGotFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = Color.LightGreen

        If sender.GetType = GetType(TextBox) Then
            DirectCast(sender, TextBox).Font = New Font(DirectCast(sender, TextBox).Font, FontStyle.Bold)
            If sender Is Me.TextBoxDescripcion Then
                DirectCast(sender, TextBox).Select(DirectCast(sender, TextBox).TextLength, 0)
            Else
                DirectCast(sender, TextBox).SelectAll()
            End If

        ElseIf sender.GetType = GetType(NumericUpDown) Then
            'DirectCast(sender, NumericUpDown).Font = New Font(DirectCast(sender, NumericUpDown).Font, FontStyle.Bold)
            DirectCast(sender, NumericUpDown).Select(0, DirectCast(sender, NumericUpDown).Text.Length)

        End If




    End Sub

    Private Sub CustomLostFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = SystemColors.Window

        If sender.GetType = GetType(TextBox) Then
            DirectCast(sender, TextBox).Font = New Font(DirectCast(sender, TextBox).Font, FontStyle.Regular)

            If sender Is Me.TextBoxDescripcion Then
                Me.TextBoxDescripcion.Text = Me.TextBoxDescripcion.Text.Trim
            End If
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
                    AddHandler c.PreviewKeyDown, AddressOf CustomPreviewKeyDown
            End Select
        Next

        AddHandler Me.KeyDown, AddressOf FormularioKeyDown

        'AddHandler Me.TextBoxCantidadBulto.TextChanged, AddressOf CalculoCambioCosto
        'AddHandler Me.TextBoxPrecioCompra.TextChanged, AddressOf CalculoCambioCosto
        'AddHandler Me.TextBoxDtoCompra1.TextChanged, AddressOf CalculoCambioCosto
        'AddHandler Me.TextBoxDtoCompra2.TextChanged, AddressOf CalculoCambioCosto
        'AddHandler Me.TextBoxDtoCompra3.TextChanged, AddressOf CalculoCambioCosto
        'AddHandler Me.TextBoxDtoCompra4.TextChanged, AddressOf CalculoCambioCosto

        'AddHandler Me.TextBoxPrecioCosto.TextChanged, AddressOf CalculoCambioCosto
        'AddHandler Me.TextBoxRenta1.TextChanged, AddressOf CalculoCambioCosto
        'AddHandler Me.TextBoxRenta2.TextChanged, AddressOf CalculoCambioCosto
        'AddHandler Me.TextBoxRenta3.TextChanged, AddressOf CalculoCambioCosto

        'AddHandler Me.TextBoxDescuento.TextChanged, AddressOf CalculoCambioCosto
        'AddHandler Me.TextBoxDescuento2.TextChanged, AddressOf CalculoCambioCosto
        'AddHandler Me.TextBoxDescuento3.TextChanged, AddressOf CalculoCambioCosto
        'AddHandler Me.numPrecioVta.TextChanged, AddressOf CalculoCambioCosto
        'AddHandler Me.numPrecioVta.TextChanged, AddressOf CalculoCambioCosto
        'AddHandler Me.numPrecioVta.TextChanged, AddressOf CalculoCambioCosto
        'AddHandler Me.ComboBoxAlicuotas.SelectedValueChanged, AddressOf CalculoCambioCosto
        'AddHandler Me.TextBoxImpuestoInternoImp.TextChanged, AddressOf CalculoCambioCosto




    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Cancelar()
    End Sub

    Private Sub Cancelar()
        Me.Consulta = False
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Guardar()

        Try
            Dim iva As Double = (Val(DirectCast(ComboBoxAlicuotas.SelectedItem, Entidades.Tipocondicioniva).Alicuota / 100) + 1)
            'actualizo los valores de la entidad que se desea persistir
            If Entidad Is Nothing Then
                Entidad = New Entidades.Articulo
            End If

            Entidad.Codigo = Convert.ToString(Me.TextBoxCodigo.Text.Trim)
            Entidad.Codigobarra = Me.TextBoxCodigoBarra.Text.Trim
            Entidad.Nombre = Me.TextBoxNombre.Text.Trim
            Entidad.Nombrecorto = Entidad.Nombre 'Me.TextBoxNombreCorto.Text
            Entidad.Descripcion = Me.TextBoxDescripcion.Text.Trim
            Entidad.Activo = Me.CheckBoxActivo.Checked
            Entidad.Preciomodificable = Me.CheckBoxModifica.Checked
            Entidad.Codcategoria = Convert.ToString(Me.CtlComboCategoria.SelectedValue)
            Entidad.Codrubro = Convert.ToString(Me.ComboBoxRubros.SelectedValue)
            Entidad.Alicuotaiva = Convert.ToUInt32(Me.ComboBoxAlicuotas.SelectedValue)
            Entidad.Codunidad = Convert.ToString(Me.ComboBoxUnidades.SelectedValue)
            Entidad.Impuestointerno = 0 'Convert.ToDouble(Me.TextBoxImpuestoInternoImp.Text)
            Entidad.Preciodecosto = 0 'Convert.ToDouble(Me.TextBoxPrecioCosto.Text)
            'Entidad.peso
            If Entidad.Preciodeventa = numPrecioVta.Value / iva = False Then
                Entidad.Precioventaanterior = Entidad.Preciodeventa / iva
            End If

            Entidad.Preciodeventa = numPrecioVta.Value / iva ' Math.Round(numPrecioVta.Value * (DirectCast(ComboBoxAlicuotas.SelectedItem, Entidades.Tipocondicioniva).Alicuota / 100), 3)

            If Entidad.Preciodeventa2 = numPrecioVta2.Value / iva = False Then
                Entidad.Precioventaanterior2 = Entidad.Preciodeventa2 / iva
            End If
            Entidad.Preciodeventa2 = numPrecioVta2.Value / iva

            If Entidad.Preciodeventa3 = numPrecioVta3.Value / iva = False Then
                Entidad.Precioventaanterior3 = Entidad.Preciodeventa3 / iva
            End If
            Entidad.Preciodeventa3 = numPrecioVta3.Value / iva
            Entidad.Preciosugerido = 0 'Convert.ToDouble(Me.TextBoxPrecioVtaSug.Text)
            Entidad.Preciodecompra = 0 'Convert.ToDouble(Me.TextBoxPrecioCompra.Text)
            Entidad.CantidadBulto = 0 'Convert.ToDouble(Me.TextBoxCantidadBulto.Text)
            Entidad.Puntominimo = 0 'Convert.ToDouble(Me.TextBoxPtoMinimo.Text)
            Entidad.Descuento = 0 'Convert.ToDouble(Me.TextBoxDescuento.Text)
            Entidad.Descuento2 = 0 'Convert.ToDouble(Me.TextBoxDescuento2.Text)
            Entidad.Descuento3 = 0 'Convert.ToDouble(Me.TextBoxDescuento3.Text)
            Entidad.Descuentocompra1 = 0 'Convert.ToDouble(Me.TextBoxDtoCompra1.Text)
            Entidad.Descuentocompra2 = 0 'Convert.ToDouble(Me.TextBoxDtoCompra2.Text)
            Entidad.Descuentocompra3 = 0 'Convert.ToDouble(Me.TextBoxDtoCompra3.Text)
            Entidad.Descuentocompra4 = 0 'Convert.ToDouble(Me.TextBoxDtoCompra4.Text)
            Entidad.Rentabilidad1 = 0 'Convert.ToDouble(Me.TextBoxRenta1.Text)
            Entidad.Rentabilidad2 = 0 'Convert.ToDouble(Me.TextBoxRenta2.Text)
            Entidad.Rentabilidad3 = 0 'Convert.ToDouble(Me.TextBoxRenta3.Text)
            'Entidad.Codproveedor = Convert.ToString(Me.ComboBoxProveedor.SelectedValue)
            Entidad.Fechaultimacompra = Format(Date.Now, "yyyy/MM/dd HH:mm:ss") 'Me.DTPUltCompra.Value
            Entidad.Oferta = Me.CheckBoxOferta.Checked

            Entidad.CoeficienteKG = numCoeficienteKg.Value
            'Entidad.Pesoneto = Convert.ToDouble(Me.TextBoxPesoNeto.Text)
            'Entidad.PreciocostoUS = Convert.ToDouble(Me.TextBoxPrecioCostoDolar.Text)
            'Entidad.Flete = CheckBoxFlete.Checked
            Entidad.FechaAlta = Format(Date.Now, "yyyy/MM/dd HH:mm:ss")
            'Entidad.Unidaddescripcion = Me.TextBoxUnidad.Text.Trim

            'Entidad.Impinttasanominal = Convert.ToDouble(Me.TextBoxImpuestoInterno.Text)
            If (Entidad.Impuestointerno + Entidad.Preciodecosto) <> 0 Then
                Entidad.Impinttasanominal = Math.Round((Entidad.Impuestointerno * 100) / (Entidad.Impuestointerno + Entidad.Preciodecosto), 2)
            End If
            'Entidad.ArticulosEnlazados = _Articulos

            'envio los nuevos datos al repositor para actualizar
            _repositorio.Save(Entidad)

            If _repositorio.HasError Then

                MessageBox.Show(_repositorio.mensajes.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                'MostrarImportes()

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

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F12 : If Not Consulta Then Guardar()
            Case Keys.Escape : Cancelar()
        End Select
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub MostrarTotales()

        'MostrarImportes()

        MostrarExistencia()

    End Sub

    'Private Sub MostrarImportes()
    '    Me.lblFinalRevendedor.Text = Me.Entidad.ImporteFinalRevendedor.ToString("$ #,##0.000")
    '    Me.lblFinalKiosko.Text = Me.Entidad.ImporteFinalKiosko.ToString("$ #,##0.000")
    '    Me.lblFinalMostrador.Text = Me.Entidad.ImporteFinalMostrador.ToString("$ #,##0.000")
    'End Sub

    'Private Sub MostrarImportes()

    '    Dim articulo As New Entidades.Articulo

    '    If Not Me.ComboBoxAlicuotas.SelectedValue Is Nothing Then articulo.Alicuotaiva = Me.ComboBoxAlicuotas.SelectedValue
    '    articulo.Preciodecosto = 0 'Val(Me.TextBoxPrecioCosto.Text)
    '    articulo.Impuestointerno = 0 'Val(Me.TextBoxImpuestoInternoImp.Text)
    '    articulo.Descuento = 0 'Val(Me.TextBoxDescuento.Text)
    '    articulo.Descuento2 = 0 'Val(Me.TextBoxDescuento2.Text)
    '    articulo.Descuento3 = 0 'Val(Me.TextBoxDescuento3.Text)
    '    articulo.Preciodeventa = 0 'Val(Me.TextBoxPrecioVta.Text)
    '    articulo.Preciodeventa2 = 0 'Val(Me.TextBoxPrecioVta2.Text)
    '    articulo.Preciodeventa3 = 0 'Val(Me.TextBoxPrecioVta3.Text)

    '    Me.lblFinalRevendedor.Text = articulo.Preciodeventa.ToString("$ #,##0.000") ' articulo.ImporteFinalLista1.ToString("$ #,##0.000") & " [ Dto. " & articulo.Descuento.ToString("0.00") & "% " & (articulo.ImporteFinalConDescuentoLista1).ToString("$ #,##0.000") & " ]"
    '    Me.lblFinalKiosko.Text = articulo.Preciodeventa2.ToString("$ #,##0.000") 'articulo.ImporteFinalLista2.ToString("$ #,##0.000") & " [ Dto. " & articulo.Descuento2.ToString("0.00") & "% " & (articulo.ImporteFinalConDescuentoLista2).ToString("$ #,##0.000") & "]"
    '    Me.lblFinalMostrador.Text = articulo.Preciodeventa3.ToString("$ #,##0.000") 'articulo.ImporteFinalLista3.ToString("$ #,##0.000") & " [ Dto. " & articulo.Descuento3.ToString("0.00") & "% " & (articulo.ImporteFinalConDescuentoLista3).ToString("$ #,##0.000") & " ]"


    'End Sub

    Private Sub MostrarExistencia()
        Dim stock As Double = _repositorio.GetExistencia(Entidad.Codigo)

        If stock < 0 Then
            Me.PanelStock.BackColor = Color.Salmon
            Me.lblExistencia.ForeColor = Color.DarkRed
            Me.lblExistenciaActual.ForeColor = Color.DarkRed
        Else
            Me.PanelStock.BackColor = Color.LightGreen
            Me.lblExistencia.ForeColor = Color.DarkGreen
            Me.lblExistenciaActual.ForeColor = Color.DarkGreen
        End If

        Me.lblExistenciaActual.Text = stock.ToString("#,##0.00")

    End Sub


    'Private Sub BtnMargenes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If IsNumeric(Me.TextBoxPrecioCosto.Text) Then
    '        If MessageBox.Show("Aplicar margenes de utilidad sobre el precio de costo actual?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '            CalculoMargenes()
    '        End If
    '    End If
    'End Sub

    'Private Sub BtnDesglose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If IsNumeric(Me.TextBoxPrecioVtaSug.Text) Then
    '        If MessageBox.Show("Calcular precio neto sobre el precio de venta sugerido actual?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '            CalculoNetos()
    '        End If
    '    End If
    'End Sub

    'Private Sub CalculoNetos()
    '    Try

    '        Dim alicuota As Entidades.Tipocondicioniva = DirectCast(Me.ComboBoxAlicuotas.SelectedItem, Entidades.Tipocondicioniva)
    '        Dim impint As Double = Convert.ToDouble(Me.TextBoxImpuestoInternoImp.Text)
    '        Dim precio As Double = Convert.ToDouble(Me.TextBoxPrecioVtaSug.Text)

    '        precio -= impint
    '        precio = precio / (1 + (alicuota.Alicuota / 100))

    '        Me.TextBoxPrecioVta.Text = Math.Round(precio, 3)
    '        Me.TextBoxPrecioVta2.Text = Math.Round(precio, 3)
    '        Me.TextBoxPrecioVta3.Text = Math.Round(precio, 3)

    '        Me.Entidad.Preciodeventa = Math.Round(precio, 3)
    '        Me.Entidad.Preciodeventa2 = Math.Round(precio, 3)
    '        Me.Entidad.Preciodeventa3 = Math.Round(precio, 3)
    '        Me.Entidad.Alicuotaiva = alicuota.Codigo
    '        Me.Entidad.Impuestointerno = impint

    '        MostrarTotales()

    '    Catch ex As Exception
    '        MessageBox.Show("Se produjo el siguiente error: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    'Private Sub CalculoMargenes()
    '    Try


    '        Dim u1, u2, u3 As Double
    '        Dim s1, s2, s3 As Double
    '        Dim c2 As Double

    '        c2 = Val(Me.TextBoxPrecioCosto.Text)


    '        u1 = Val(Me.TextBoxRenta1.Text)
    '        u2 = Val(Me.TextBoxRenta2.Text)
    '        u3 = Val(Me.TextBoxRenta3.Text)

    '        c2 = Val(Me.TextBoxPrecioCosto.Text)
    '        s1 = Math.Round(c2 * (1 + (u1 / 100)), 3)
    '        s2 = Math.Round(c2 * (1 + (u2 / 100)), 3)
    '        s3 = Math.Round(c2 * (1 + (u3 / 100)), 3)

    '        Me.TextBoxPrecioVta.Text = s1
    '        Me.TextBoxPrecioVta2.Text = s2
    '        Me.TextBoxPrecioVta3.Text = s3

    '        'MostrarTotales()

    '    Catch ex As Exception
    '        MessageBox.Show("Se produjo el siguiente error: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    Private Sub Label28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    'Private Sub CalculoCambioCosto(ByVal sender As Object, ByVal e As EventArgs)

    '    Dim d1, d2, d3, d4 As Double
    '    Dim b1, b2, b3 As Double
    '    Dim u1, u2, u3 As Double
    '    Dim s1, s2, s3 As Double
    '    Dim c1, c2 As Double


    '    'If Val(Me.TextBoxCantidadBulto.Text) > 0 Then
    '    '    c1 = Math.Round(Val(Me.TextBoxPrecioCompra.Text) / Val(Me.TextBoxCantidadBulto.Text), 5)
    '    'Else
    '    '    c1 = Val(Me.TextBoxPrecioCompra.Text)
    '    'End If

    '    ''c1 = Val(Me.TextBoxPrecioCompra.Text)
    '    'd1 = Val(Me.TextBoxDtoCompra1.Text)
    '    'd2 = Val(Me.TextBoxDtoCompra2.Text)
    '    'd3 = Val(Me.TextBoxDtoCompra3.Text)
    '    'd4 = Val(Me.TextBoxDtoCompra4.Text)


    '    'c2 = Val(Me.TextBoxPrecioCosto.Text)
    '    'c2 = Math.Round(c1 - (c1 * (d1 / 100)), 5)
    '    'c2 = Math.Round(c2 - (c2 * (d2 / 100)), 5)
    '    'c2 = Math.Round(c2 - (c2 * (d3 / 100)), 5)
    '    'c2 = Math.Round(c2 - (c2 * (d4 / 100)), 5)
    '    'Me.TextBoxPrecioCosto.Text = c2

    '    'b1 = Val(Me.TextBoxPrecioVta.Text)
    '    'b2 = Val(Me.TextBoxPrecioVta2.Text)
    '    'b3 = Val(Me.TextBoxPrecioVta3.Text)

    '    'u1 = Val(Me.TextBoxRenta1.Text)
    '    'u2 = Val(Me.TextBoxRenta2.Text)
    '    'u3 = Val(Me.TextBoxRenta3.Text)

    '    's1 = Math.Round(c2 * (1 + (u1 / 100)), 3)
    '    's2 = Math.Round(c2 * (1 + (u2 / 100)), 3)
    '    's3 = Math.Round(c2 * (1 + (u3 / 100)), 3)

    '    'Me.LabelSug1.Text = s1.ToString("#,##0.00#")
    '    'Me.LabelSug2.Text = s2.ToString("#,##0.00#")
    '    'Me.LabelSug3.Text = s3.ToString("#,##0.00#")

    '    'If s1 > b1 Then
    '    '    Me.LabelSug1.BackColor = Color.Salmon
    '    'Else
    '    '    Me.LabelSug1.BackColor = Color.LightGreen
    '    'End If

    '    'If s2 > b2 Then
    '    '    Me.LabelSug2.BackColor = Color.Salmon
    '    'Else
    '    '    Me.LabelSug2.BackColor = Color.LightGreen
    '    'End If

    '    'If s3 > b3 Then
    '    '    Me.LabelSug3.BackColor = Color.Salmon
    '    'Else
    '    '    Me.LabelSug3.BackColor = Color.LightGreen
    '    'End If


    '    MostrarImportes()

    'End Sub

    Private Sub CustomPreviewKeyDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs)
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub ComboBoxUnidades_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxUnidades.SelectedIndexChanged
        If ComboBoxUnidades.SelectedItem IsNot Nothing Then
            If DirectCast(ComboBoxUnidades.SelectedItem, Entidades.Unidad).Codigo = "01" Then
                numCoeficienteKg.Enabled = True
            Else
                numCoeficienteKg.Enabled = False
            End If
        End If
    End Sub
End Class