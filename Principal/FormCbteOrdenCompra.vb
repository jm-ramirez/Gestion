Public Class FormCbteOrdenCompra
    Private _repositorioCli As New CapaLogica.ClienteCLog
    Private _repositorioArt As New CapaLogica.ArticuloCLog

    Property Entidad As Entidades.OrdenCompracab
    Property EntidadDet As Entidades.OrdenCompradet

    Private _repositorio As New CapaLogica.OrdencompracabCLog
    Private dblTotal As Double
    Public _Lista As List(Of Entidades.OrdenCompradet)

    Private blnModifica As Boolean

    Private Sub InicializarFormulario()

        'limpieza de controles
        For Each c As Control In Me.GroupBoxDatosCliente.Controls
            Select Case c.GetType
                Case GetType(TextBox) : DirectCast(c, TextBox).Text = ""
                Case GetType(ComboBox) : DirectCast(c, ComboBox).SelectedIndex = -1
                Case GetType(CheckBox) : DirectCast(c, CheckBox).Checked = False
                Case GetType(NumericUpDown) : DirectCast(c, NumericUpDown).Value = DirectCast(c, NumericUpDown).Minimum
            End Select
        Next

        For Each c As Control In Me.GroupBoxDatosArticulos.Controls
            Select Case c.GetType
                Case GetType(TextBox) : DirectCast(c, TextBox).Text = ""
                Case GetType(ComboBox) : DirectCast(c, ComboBox).SelectedIndex = -1
                Case GetType(CheckBox) : DirectCast(c, CheckBox).Checked = False
                Case GetType(NumericUpDown) : DirectCast(c, NumericUpDown).Value = DirectCast(c, NumericUpDown).Minimum
            End Select
        Next

        InicializarComboCliente()
        InicializarComboDocumentos()

        _Lista = New List(Of Entidades.OrdenCompradet)

        ConfigurarGrilla()

        Me.Text = "Orden de Compra (Clientes)"

        If Not Entidad Is Nothing Then
            dblTotal = 0

            blnModifica = False

            Me.GroupBoxDatosCliente.Enabled = False
            Me.GroupBoxDatosArticulos.Enabled = True

            Me.ComboBoxCliente.SelectedValue = Entidad.Codcliente
            Me.TextBoxDocumento.Text = Entidad.CuitCliente
            Me.TextBoxNombre.Text = Entidad.NombreCliente
            Me.TextBoxDomicilio.Text = Entidad.DomicilioCliente
            Me.TextBoxTelefono.Text = Entidad.TelefonoCliente
            Me.DTPFecha.Value = Entidad.Fecha
            Me.TextBoxNumero.Text = Format(CInt(Entidad.Numero), "00000000")
            'Me.TextBoxSecuencia.Text = Format(CInt(Entidad.Secuencia), "00")

            _Lista = _repositorio.GetAllSemanaProducto(Entidad.Id)

            For Each list As Entidades.OrdenCompradet In _Lista
                dblTotal = dblTotal + list.Subtotal
            Next

            Me.LabelTotal.Text = "Importe total del comprobante >> " & dblTotal.ToString("$ #,##0.00") & " <<"

            Me.TextBoxUnidad.Text = ""
            Me.TextBoxKxU.Text = "0.00"
            'Me.TextBoxKgs.Text = "0.00"
            Me.TextBoxCantidad.Text = "0.00"
            Me.TextBoxPrecio.Text = "0.00"
            Me.TextBoxSubtotalArticulo.Text = "0.00"

            PoblarGrilla()

            InicializarComboArticulo()

            Me.ComboBoxArticulos.FocoDetalle()


        Else 'nuevo registro, valores por defecto

            LimpiarFormulario()
        End If

        



        'Me.DTPFecha.Value = Now

        'Me.GroupBoxDatosArticulos.Enabled = False
        'Me.TextBoxPedido.Text = "00000000"
    End Sub

    Private Sub CustomGotFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = Color.LightGreen

        If sender.GetType = GetType(TextBox) Then
            DirectCast(sender, TextBox).Font = New Font(DirectCast(sender, TextBox).Font, FontStyle.Bold)
        ElseIf sender.GetType = GetType(NumericUpDown) Then
            DirectCast(sender, NumericUpDown).Font = New Font(DirectCast(sender, NumericUpDown).Font, FontStyle.Bold)
            DirectCast(sender, NumericUpDown).Select(0, DirectCast(sender, NumericUpDown).Text.Length)
        End If

    End Sub

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        For Each c As Control In Me.GroupBoxDatosCliente.Controls
            Select Case c.GetType
                Case GetType(TextBox), GetType(CheckBox), GetType(ComboBox), GetType(NumericUpDown)
                    AddHandler c.GotFocus, AddressOf CustomGotFocus
                    AddHandler c.LostFocus, AddressOf CustomLostFocus
            End Select
        Next

        For Each c As Control In Me.GroupBoxDatosArticulos.Controls
            Select Case c.GetType
                Case GetType(TextBox), GetType(CheckBox), GetType(ComboBox), GetType(NumericUpDown)
                    AddHandler c.GotFocus, AddressOf CustomGotFocus
                    AddHandler c.LostFocus, AddressOf CustomLostFocus
            End Select
        Next

        AddHandler Me.KeyDown, AddressOf FormularioKeyDown

    End Sub

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F12 : AutorizaOrdenCompra()
            Case Keys.Escape : Cancelar()
            Case Keys.Delete : EliminarGrilla()
            Case Keys.Return : SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub CustomLostFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = SystemColors.Window

        If sender.GetType = GetType(TextBox) Then
            DirectCast(sender, TextBox).Font = New Font(DirectCast(sender, TextBox).Font, FontStyle.Regular)
        ElseIf sender.GetType = GetType(NumericUpDown) Then
            DirectCast(sender, NumericUpDown).Font = New Font(DirectCast(sender, NumericUpDown).Font, FontStyle.Regular)
        End If

    End Sub

    Private Sub FormCbteOrdenCompra_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InicializarFormulario()
    End Sub

    Private Sub InicializarComboCliente()

        With Me.ComboBoxCliente
            .ValueMember = "Codigo"
            .DisplayMember = "NombreyCodigo"
            .DataSource = _repositorioCli.GetAll()
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            '.DropDownStyle = ComboBoxStyle.DropDownList
            .FormularioDeAlta = FormCliente
            .Inicializar()
            .SelectedIndex = -1
        End With

        Me.ComboBoxDomicilios.DataSource = Nothing

    End Sub
    Private Sub InicializarComboArticulo()

        With Me.ComboBoxArticulos
            .ValueMember = "Id"
            .DisplayMember = "CodigoyNombre"
            'If Me.ComboBoxCliente.SelectedIndex >= 0 Then
            .DataSource = _repositorioArt.GetAll 'ByCliente(ComboBoxCliente.SelectedValue, )
            'End If
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            .SelectedIndex = -1

        End With

    End Sub
    Private Sub InicializarComboDocumentos()
        Dim repositorio As New CapaLogica.TipodocumentoCLog

        With Me.ComboBoxDocumento
            .ValueMember = "Codigo"
            .DisplayMember = "Descripcion"
            .DataSource = repositorio.GetAll
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub CargaDatosCliente()
        Dim e As New Entidades.Cliente
        Dim cbtetipo As UInt32 = 0

        e = DirectCast(Me.ComboBoxCliente.SelectedItem, Entidades.Cliente)

        If e IsNot Nothing Then
            Me.TextBoxDocumento.Text = e.Documento
            Me.ComboBoxDocumento.SelectedValue = e.Tipodocumento
            Me.ComboBoxDomicilios.DataSource = e.Domicilio.Split(New String() {Environment.NewLine},
                                       StringSplitOptions.None)
            Me.TextBoxDomicilio.Text = e.Domicilio.Split(New String() {Environment.NewLine},
                                       StringSplitOptions.None)(0)
            Me.TextBoxNombre.Text = e.Nombre
            Me.TextBoxTelefono.Text = e.Telefono
            blnModifica = False
        Else

            Me.TextBoxDocumento.Text = ""
            Me.ComboBoxDocumento.SelectedIndex = -1
            Me.ComboBoxDomicilios.SelectedIndex = -1
            Me.TextBoxDomicilio.Text = ""
            Me.TextBoxNombre.Text = ""
            Me.TextBoxTelefono.Text = ""
        End If

    End Sub

    Private Sub CargaDatosArticulo()
        Dim e As New Entidades.Articulo
        Dim cbtetipo As UInt32 = 0

        e = DirectCast(Me.ComboBoxArticulos.SelectedItem, Entidades.Articulo)

        If e IsNot Nothing Then
            Me.TextBoxUnidad.Text = e.SimboloUnidad
            Me.TextBoxKxU.Text = Format(CDbl(e.Pesoneto), "0.00")
            Me.TextBoxPrecio.Text = Format(CDbl(e.Preciodeventa), "0.00")


            'Me.ComboBoxDomicilios.DataSource = e.Domicilio.Split(New String() {Environment.NewLine},
            '                           StringSplitOptions.None)
            'Me.TextBoxDomicilio.Text = e.Domicilio.Split(New String() {Environment.NewLine},
            '                           StringSplitOptions.None)(0)
            'Me.TextBoxNombre.Text = e.Nombre
            'Me.TextBoxTelefono.Text = e.Telefono

        Else

            Me.TextBoxUnidad.Text = ""
            Me.TextBoxKxU.Text = "0.00"
            'Me.TextBoxKgs.Text = "0.00"
            Me.TextBoxCantidad.Text = "0.00"
            Me.TextBoxPrecio.Text = "0.00"
            Me.TextBoxSubtotalArticulo.Text = "0.00"

        End If

    End Sub

    Private Sub Cancelar()
        If blnModifica = True Then
            If MessageBox.Show("Desea Salir?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Me.Close()
            End If
        Else
            If MessageBox.Show("Cancelar comprobante?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                LimpiarFormulario()
            End If
        End If
        
    End Sub
    Private Sub LimpiarFormulario()
        '_Lista = New List(Of Entidades.Moldeodet)
        _Lista.Clear()
        'ConfigurarGrilla()
        dblTotal = 0
        Me.LabelTotal.Text = "0.00"
        Me.ComboBoxCliente.SelectedIndex = -1

        Me.ComboBoxDocumento.SelectedIndex = -1

        Me.TextBoxNombre.Text = ""

        Me.ComboBoxDomicilios.SelectedIndex = -1

        Me.TextBoxTelefono.Text = ""

        Me.TextBoxDocumento.Text = ""

        Me.TextBoxDomicilio.Text = ""

        Me.DTPFecha.Value = Now

        Me.ComboBoxArticulos.SelectedIndex = -1

        Me.GroupBoxDatosCliente.Enabled = True

        Me.GroupBoxDatosArticulos.Enabled = False

        Me.TextBoxNumero.Text = "00000000"
        'Me.TextBoxSecuencia.Text = "00"

        Me.TextBoxUnidad.Text = ""
        Me.TextBoxKxU.Text = "0.00"
        'Me.TextBoxKgs.Text = "0.00"
        Me.TextBoxCantidad.Text = "0.00"
        Me.TextBoxPrecio.Text = "0.00"
        Me.TextBoxSubtotalArticulo.Text = "0.00"

        blnModifica = True

        'Me.FOLVArticulos.Clear()
        PoblarGrilla()
        Me.ComboBoxCliente.FocoDetalle()

        Application.DoEvents()

    End Sub
    Private Sub ConfigurarGrilla()
        CrearColumnas()

        With FOLVArticulos
            .FullRowSelect = True
            .UseFiltering = True
            .CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick
            .CellEditEnterChangesRows = True
            .ClearObjects()
        End With

    End Sub
    Private Sub PoblarGrilla()
        Me.FOLVArticulos.ModelFilter = Nothing
        Me.FOLVArticulos.Objects = _Lista
        Me.FOLVArticulos.AutoResizeColumns()
    End Sub
    Private Sub CrearColumnas()

        Dim c As BrightIdeasSoftware.OLVColumn

        With FOLVArticulos

            .Columns.Clear()

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Articulo"
            c.AspectName = "Articulo"
            c.MinimumWidth = 118
            c.MaximumWidth = 118
            c.AutoResize(ColumnHeaderAutoResizeStyle.None)
            c.FillsFreeSpace = True
            c.IsEditable = False
            .Columns.Add(c)


            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Descripción"
            c.AspectName = "NombreArticulo"
            c.MinimumWidth = 355
            c.MaximumWidth = 355
            c.AutoResize(ColumnHeaderAutoResizeStyle.None)
            c.FillsFreeSpace = True
            c.IsEditable = False
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Cantidad"
            c.AspectName = "Cantidad"
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Right
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("#,##0.00#")
                                        End Function
            'c.AspectToStringFormat = "{0.00}"
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = True
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "KxU"
            c.AspectName = "Kgsxunidad"
            c.MinimumWidth = 70
            c.TextAlign = HorizontalAlignment.Right
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("#,##0.00#")
                                        End Function
            'c.AspectToStringFormat = "{0.00}"
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = False
            .Columns.Add(c)

            'c = New BrightIdeasSoftware.OLVColumn
            'c.Text = "Kgs"
            'c.AspectName = "Kgs"
            'c.MinimumWidth = 80
            'c.TextAlign = HorizontalAlignment.Right
            'c.AspectToStringConverter = Function(x As Double)
            '                                Return x.ToString("#,##0.00#")
            '                            End Function
            ''c.AspectToStringFormat = "{0.00}"
            'c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            'c.IsEditable = True
            '.Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Precio"
            c.AspectName = "Precio"
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Right
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("#,##0.00#")
                                        End Function
            'c.AspectToStringFormat = "{0.00}"
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = True
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Subtotal"
            c.AspectName = "Subtotal"
            c.MinimumWidth = 110
            c.TextAlign = HorizontalAlignment.Right
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("#,##0.00#")
                                        End Function
            'c.AspectToStringFormat = "{0.00}"
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = False
            .Columns.Add(c)

        End With
    End Sub
    Private Sub CargaGrilla()

        If ComboBoxArticulos.SelectedItem Is Nothing Then
            MessageBox.Show("Debe Ingresar Un Artículo Válido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ComboBoxArticulos.Focus()
        ElseIf Valida(DirectCast(ComboBoxArticulos.SelectedItem, Entidades.Articulo).Codigo) = 1 Then
            MessageBox.Show("No puede cargar más de una vez un artículo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ComboBoxArticulos.Focus()
        ElseIf Val(Me.TextBoxCantidad.Text) <= 0 Then
            MessageBox.Show("Debe ingresar una Cantidad válida", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBoxCantidad.Focus()
        Else

            EntidadDet = New Entidades.OrdenCompradet

            EntidadDet.Articulo = DirectCast(ComboBoxArticulos.SelectedItem, Entidades.Articulo).Codigo
            'EntidadDet.Rev = DirectCast(ComboBoxArticulos.SelectedItem, Entidades.Articulo).Rev
            EntidadDet.Precio = CDbl(Me.TextBoxPrecio.Text)
            EntidadDet.Cantidad = CDbl(Me.TextBoxCantidad.Text)
            EntidadDet.Cantsaldo = CDbl(Me.TextBoxCantidad.Text)
            EntidadDet.Cantacum = 0
            EntidadDet.Descarte = 0
            EntidadDet.Despacho = 0
            EntidadDet.Kgsxunidad = CDbl(Me.TextBoxKxU.Text)
            'EntidadDet.Kgs = CDbl(Me.TextBoxKgs.Text)
            EntidadDet.Codunidad = DirectCast(ComboBoxArticulos.SelectedItem, Entidades.Articulo).Codunidad
            EntidadDet.Expedicion = 0
            EntidadDet.Cbtevta = 0
            EntidadDet.NombreArticulo = DirectCast(ComboBoxArticulos.SelectedItem, Entidades.Articulo).Nombre
            EntidadDet.Subtotal = CDbl(Me.TextBoxSubtotalArticulo.Text)

            dblTotal = dblTotal + CDbl(Me.TextBoxSubtotalArticulo.Text)

            _Lista.Add(EntidadDet)

            Me.ComboBoxArticulos.SelectedIndex = -1
            'Me.numCantidad.Value = 1
            Me.ComboBoxArticulos.Focus()

            PoblarGrilla()

            dblTotal = dblTotal + CDbl(Me.TextBoxSubtotalArticulo.Text)

            Me.LabelTotal.Text = "Importe total del comprobante >> " & dblTotal.ToString("$ #,##0.00") & " <<"
        End If

    End Sub
    Private Sub AutorizaOrdenCompra()
        Dim mlngCopias As Integer
        Try
            If FOLVArticulos.Items.Count = 0 Then
                MessageBox.Show("No cargó ningun artículo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.ComboBoxArticulos.Focus()

            Else

                mlngCopias = -1
                frmImpresion.mstrConcepto = "CARGA DE ORDEN DE COMPRA"
                frmImpresion.mlngNumero = Convert.ToInt32(Me.TextBoxNumero.Text)
                If frmImpresion.ShowDialog(Me) = Windows.Forms.DialogResult.Cancel Then
                    Exit Sub
                End If

                mlngCopias = frmImpresion.mlngCopias

                If Entidad Is Nothing Then
                    Entidad = New Entidades.OrdenCompracab
                End If

                Entidad.Codcliente = DirectCast(ComboBoxCliente.SelectedItem, Entidades.Cliente).Codigo
                Entidad.Numero = CInt(Me.TextBoxNumero.Text)
                'Entidad.Secuencia = CInt(Me.TextBoxSecuencia.Text)
                Entidad.Fecha = Me.DTPFecha.Value
                Entidad.Observacion = Me.TextBoxObservacion.Text
                Entidad.OrdenCompradet = _Lista

                _repositorio.Save(Entidad)

                If _repositorio.HasError Then

                    MessageBox.Show(_repositorio.mensajes.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

                Else

                    MessageBox.Show("La operación ha finalizado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                    If mlngCopias > 0 Then
                        Call EmisionCbteOrdenCompra(Entidad.Id, False, mlngCopias)
                        'Reporte(mlngCopias)
                    End If

                    Me.Close()

                End If
            End If


        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    'Private Sub Reporte(Optional ByVal copies As Short = -1)

    '    Try

    '        Dim r As New GeneradorReportes.Reporte

    '        r.Nombre = Me.Text

    '        r.SourceFile = My.Settings.RutaReportes & "\infCargaCompra.rdl"

    '        SetearEncabezadosReporte(r)

    '        r.Parametros.Add(New GeneradorReportes.Parametro("titulo", Me.Text))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("fecha", Format(Me.DTPFecha.Value, "dd/MM/yyyy")))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("NroCbte", Format(CInt(Me.TextBoxNumero.Text), "00000000") & "-" & Format(CInt(Me.TextBoxSecuencia.Text), "00")))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("clienteNombre", Me.TextBoxNombre.Text))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("clienteDomicilio", Me.TextBoxDomicilio.Text))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("clienteCodpostal", DirectCast(ComboBoxCliente.SelectedItem, Entidades.Cliente).CodigoPostal))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("clienteLocalidad", DirectCast(ComboBoxCliente.SelectedItem, Entidades.Cliente).NombreLocalidad))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("clienteTelefono", Me.TextBoxTelefono.Text))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("clienteCuit", Me.TextBoxDocumento.Text))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("cbteId", Entidad.Id))
    '        r.Parametros.Add(New GeneradorReportes.Parametro("observaciones", Me.TextBoxObservacion.Text))

    '        r.PrintReport(copies)

    '        Me.Close()

    '    Catch ex As Exception
    '        MessageBox.Show("Se produjo el siguiente error: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub
    Private Sub EliminarGrilla()
        If Me.FOLVArticulos.SelectedIndex < 0 Then
            MessageBox.Show("No Seleccionó ningún Registro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else

            dblTotal = dblTotal - CDbl(_Lista.Item(Me.FOLVArticulos.SelectedIndex).Subtotal)

            Me.LabelTotal.Text = "Importe total del comprobante >> " & dblTotal.ToString("$ #,##0.00") & " <<"

            _Lista.Remove(_Lista.Item(Me.FOLVArticulos.SelectedIndex))

            PoblarGrilla()
            Me.ComboBoxArticulos.FocoDetalle()
        End If
    End Sub
    Private Function Valida(ByRef Articulo As String) As Integer
        Dim a = 0
        For i As Integer = 0 To Me.FOLVArticulos.Items.Count - 1 Step 1
            If DirectCast(Me.FOLVArticulos.Objects(i), Entidades.OrdenCompradet).Articulo = Articulo Then
                a = 1
                Exit For
            End If

        Next

        Return a
    End Function
    Private Sub ComboBoxDomicilios_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBoxDomicilios.SelectedIndexChanged
        Me.TextBoxDomicilio.Text = Me.ComboBoxDomicilios.Text
    End Sub

    Private Sub ComboBoxCliente_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles ComboBoxCliente.KeyUp

    End Sub

    Private Sub ComboBoxCliente_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ComboBoxCliente.SelectedIndexChanged
        CargaDatosCliente()
        'InicializarComboArticulo()
    End Sub

    Private Sub TextBoxSecuencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxNumero_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxNumero.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxNumero_LostFocus(sender As Object, e As System.EventArgs) Handles TextBoxNumero.LostFocus
        If Me.TextBoxNumero.Text = "" Then
            Me.TextBoxNumero.Text = "00000000"
        Else
            Me.TextBoxNumero.Text = Format(CInt(Me.TextBoxNumero.Text), "00000000")
        End If

        If _repositorio.GetValidarOrdenCompra(CInt(Me.TextBoxNumero.Text)) = True Then
            MessageBox.Show("El Número de comprobante y secuencia ya han sido cargados!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.TextBoxNumero.Focus()
        Else
            If DirectCast(Me.ComboBoxCliente.SelectedItem, Entidades.Cliente) IsNot Nothing And Val(Me.TextBoxNumero.Text) > 0 Then
                If MessageBox.Show("Confirma datos ingresados?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    Me.GroupBoxDatosCliente.Enabled = False
                    Me.GroupBoxDatosArticulos.Enabled = True
                    'blnModifica = False
                    InicializarComboArticulo()
                    Me.ComboBoxArticulos.FocoDetalle()
                    'MsgBox("La operación ha sido cancelada por el usuario")
                End If
            End If
        End If

    End Sub

    Private Sub TextBoxKxU_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxKgs_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxCantidad_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxCantidad.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxPrecio_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxPrecio.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxSubtotalArticulo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxSubtotalArticulo.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub

    'Private Sub TextBoxKgs_LostFocus(sender As Object, e As System.EventArgs)
    '    If Me.TextBoxKgs.Text = "" Then
    '        Me.TextBoxKgs.Text = "0.00"
    '    Else
    '        Me.TextBoxKgs.Text = Format(CDbl(Me.TextBoxKgs.Text), "0.00")
    '    End If

    '    If DirectCast(Me.ComboBoxArticulos.SelectedItem, Entidades.Articulo) IsNot Nothing And Me.TextBoxUnidad.Text = "KG" Then
    '        Me.TextBoxSubtotalArticulo.Text = Format(CDbl(Val(Me.TextBoxKgs.Text) * Val(Me.TextBoxPrecio.Text)), "0.00")
    '        'ElseIf DirectCast(Me.ComboBoxArticulos.SelectedItem, Entidades.Articulo) IsNot Nothing And Me.TextBoxUnidad.Text <> "Kg" Then
    '        If Val(Me.TextBoxKxU.Text) > 0 Then
    '            Me.TextBoxCantidad.Text = Format(CInt(CDbl(Val(Me.TextBoxKgs.Text) / Val(Me.TextBoxKxU.Text))), "0.00")
    '        End If
    '    End If
    'End Sub

    Private Sub TextBoxCantidad_LostFocus(sender As Object, e As System.EventArgs) Handles TextBoxCantidad.LostFocus
        If Me.TextBoxCantidad.Text = "" Then
            Me.TextBoxCantidad.Text = "0.00"
        Else
            Me.TextBoxCantidad.Text = Format(CDbl(Me.TextBoxCantidad.Text), "0.00")
        End If

        Me.TextBoxSubtotalArticulo.Text = Format(CDbl(Val(Me.TextBoxCantidad.Text) * Val(Me.TextBoxPrecio.Text)), "0.00")

    End Sub

    Private Sub TextBoxPrecio_LostFocus(sender As Object, e As System.EventArgs) Handles TextBoxPrecio.LostFocus
        If Me.TextBoxPrecio.Text = "" Then
            Me.TextBoxPrecio.Text = "0.00"
        Else
            Me.TextBoxPrecio.Text = Format(CDbl(Me.TextBoxPrecio.Text), "0.00")
        End If

        Me.TextBoxSubtotalArticulo.Text = Format(CDbl(Val(Me.TextBoxCantidad.Text) * Val(Me.TextBoxPrecio.Text)), "0.00")

    End Sub

    Private Sub TextBoxSubtotalArticulo_LostFocus(sender As Object, e As System.EventArgs) Handles TextBoxSubtotalArticulo.LostFocus
        If Me.TextBoxSubtotalArticulo.Text = "" Then
            Me.TextBoxSubtotalArticulo.Text = "0.00"
        Else
            Me.TextBoxSubtotalArticulo.Text = Format(CDbl(Me.TextBoxSubtotalArticulo.Text), "0.00")
        End If
    End Sub

    Private Sub ToolStripButtonCancelar_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButtonCancelar.Click
        Cancelar()
    End Sub

    Private Sub ComboBoxArticulos_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ComboBoxArticulos.SelectedIndexChanged
        CargaDatosArticulo()
    End Sub

    Private Sub TextBoxKxU_LostFocus(sender As Object, e As System.EventArgs) Handles TextBoxKxU.LostFocus
        If Me.TextBoxKxU.Text = "" Then
            Me.TextBoxKxU.Text = "0.00"
        Else
            Me.TextBoxKxU.Text = Format(CDbl(Me.TextBoxKxU.Text), "0.00")
        End If
    End Sub

    Private Sub BtnAgregarArticulo_Click(sender As System.Object, e As System.EventArgs) Handles BtnAgregarArticulo.Click
        CargaGrilla()
    End Sub

    Private Sub ToolStripButtonAutorizar_Click(sender As Object, e As System.EventArgs) Handles ToolStripButtonAutorizar.Click
        AutorizaOrdenCompra()
    End Sub

    Private Sub TextBoxSecuencia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBoxNumero_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBoxNumero.TextChanged

    End Sub

    Private Sub FOLVArticulos_CellEditFinishing(sender As Object, e As BrightIdeasSoftware.CellEditEventArgs) Handles FOLVArticulos.CellEditFinishing
        If Not e.Cancel Then
            If e.Column.AspectName = "Kgs" Then
                If (e.NewValue >= 0 And e.NewValue <= 9999999) And DirectCast(e.RowObject, Entidades.OrdenCompradet).Codunidad = "01" Then
                    DirectCast(e.RowObject, Entidades.OrdenCompradet).Cantidad = CInt(Val(e.NewValue) / Val(DirectCast(e.RowObject, Entidades.OrdenCompradet).Kgsxunidad))
                    DirectCast(e.RowObject, Entidades.OrdenCompradet).Subtotal = CInt(Val(e.NewValue) * Val(DirectCast(e.RowObject, Entidades.OrdenCompradet).Precio))
                ElseIf (e.NewValue >= 0 And e.NewValue <= 9999999) And DirectCast(e.RowObject, Entidades.OrdenCompradet).Codunidad <> "01" Then
                    DirectCast(e.RowObject, Entidades.OrdenCompradet).Subtotal = CInt(Val(DirectCast(e.RowObject, Entidades.OrdenCompradet).Cantidad) * Val(DirectCast(e.RowObject, Entidades.OrdenCompradet).Precio))
                End If
            End If

            If e.Column.AspectName = "Cantidad" Then
                If (e.NewValue >= 0 And e.NewValue <= 9999999) And DirectCast(e.RowObject, Entidades.OrdenCompradet).Codunidad <> "01" Then
                    DirectCast(e.RowObject, Entidades.OrdenCompradet).Subtotal = CInt(Val(e.NewValue) * Val(DirectCast(e.RowObject, Entidades.OrdenCompradet).Precio))
                End If
            End If

            If e.Column.AspectName = "Precio" Then
                If (e.NewValue >= 0 And e.NewValue <= 9999999) And DirectCast(e.RowObject, Entidades.OrdenCompradet).Codunidad = "01" Then
                    DirectCast(e.RowObject, Entidades.OrdenCompradet).Subtotal = CInt(Val(DirectCast(e.RowObject, Entidades.OrdenCompradet).Kgs) * Val(e.NewValue))
                ElseIf (e.NewValue >= 0 And e.NewValue <= 9999999) And DirectCast(e.RowObject, Entidades.OrdenCompradet).Codunidad <> "01" Then
                    DirectCast(e.RowObject, Entidades.OrdenCompradet).Subtotal = CInt(Val(DirectCast(e.RowObject, Entidades.OrdenCompradet).Cantidad) * Val(e.NewValue))
                End If
            End If

            Me.FOLVArticulos.RefreshObject(Me.FOLVArticulos.SelectedObject)
            Me.FOLVArticulos.Refresh()
            'My.Application.DoEvents()

            'If DirectCast(Me.ComboBoxArticulos.SelectedItem, Entidades.Articulo) IsNot Nothing And Me.TextBoxUnidad.Text = "KG" Then
            '    Me.TextBoxSubtotalArticulo.Text = Format(CDbl(Val(Me.TextBoxKgs.Text) * Val(Me.TextBoxPrecio.Text)), "0.00")
            'ElseIf DirectCast(Me.ComboBoxArticulos.SelectedItem, Entidades.Articulo) IsNot Nothing And Me.TextBoxUnidad.Text <> "Kg" Then
            '    Me.TextBoxSubtotalArticulo.Text = Format(CDbl(Val(Me.TextBoxCantidad.Text) * Val(Me.TextBoxPrecio.Text)), "0.00")
            'End If
        End If
    End Sub

    Private Sub FOLVArticulos_CellEditStarting(sender As Object, e As BrightIdeasSoftware.CellEditEventArgs) Handles FOLVArticulos.CellEditStarting
        e.Control.BackColor = Color.LightGreen

        If e.Control.GetType = GetType(BrightIdeasSoftware.FloatCellEditor) Then
            DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Font = New Font(DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Font, FontStyle.Bold)
            DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Select(0, DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Text.Length)
        End If
    End Sub

    Private Sub TextBoxCantidad_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBoxCantidad.TextChanged

    End Sub

    Private Sub FOLVArticulos_CellEditValidating(sender As Object, e As BrightIdeasSoftware.CellEditEventArgs) Handles FOLVArticulos.CellEditValidating
        Select Case e.Column.AspectName
            Case "Cantidad"
                If e.NewValue < 0 Or e.NewValue > 99999 Or DirectCast(e.RowObject, Entidades.OrdenCompradet).Codunidad = "01" Then
                    'If e.Control.GetType = GetType(BrightIdeasSoftware.FloatCellEditor) Then
                    '    DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).BackColor = Color.Red
                    '    DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Select(0, DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Text.Length)
                    '    MessageBox.Show("No puede modificar la cantidad!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'End If
                    e.Cancel = True
                End If
        End Select
    End Sub

    Private Sub TextBoxPrecio_Resize(sender As Object, e As System.EventArgs) Handles TextBoxPrecio.Resize

    End Sub

    Private Sub TextBoxPrecio_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBoxPrecio.TextChanged

    End Sub
End Class