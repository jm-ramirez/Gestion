Public Class FormAplicacionAnticipos

    Dim _guardando As Boolean


    'entidad
    'Property Entidad As Entidades.Reparto

    Private _repositorioClientes As New CapaLogica.ClienteCLog
    Private _repositorioCbtes As New CapaLogica.CbtecabeceraCLog
    Private _cbtesasociados As New List(Of Entidades.CbteAsociado)
    Private _totalanticipo As Double
    Private _totalaplicado As Double
    Private _cbteanticipo As Entidades.CbteCabecera

    'inicializo formulario, limpieza o carga de valores
    Private Sub InicializarFormulario()

        Me.Text = "Aplicación de Anticipos"

        'limpieza de controles
        For Each c As Control In Me.Controls
            Select Case c.GetType
                Case GetType(TextBox) : DirectCast(c, TextBox).Text = ""
                Case GetType(ComboBox) : DirectCast(c, ComboBox).SelectedIndex = -1
                Case GetType(CheckBox) : DirectCast(c, CheckBox).Checked = False
            End Select
        Next

        InicializarCombos()
        CrearGrillaCompAnticipos()
        CrearGrillaCompAsoc()

        _cbteanticipo = Nothing
        _totalanticipo = 0
        _totalanticipo = 0
        _guardando = False
        Totalizar()

    End Sub

    Private Sub CrearGrillaCompAsoc()


        Dim c As BrightIdeasSoftware.OLVColumn

        With FOLVCompPendientes

            .Columns.Clear()

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Comprobante"
            c.AspectName = "Denominacion"
            c.MinimumWidth = 100
            c.FillsFreeSpace = True
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = False
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Fecha"
            c.AspectName = "Fecha"

            c.MinimumWidth = 100
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = False
            .Columns.Add(c)


            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Importe Orig."
            c.AspectName = "ImporteOriginal"
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("$ #,##0.00#")
                                        End Function
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = False
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Saldo"
            c.AspectName = "Saldo"
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("$ #,##0.00#")
                                        End Function
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = False
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Aplicado"
            c.AspectName = "Importe"
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("$ #,##0.00#")
                                        End Function
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            'c.AspectToStringFormat = "{0:C}"
            c.IsEditable = True
            .Columns.Add(c)

            'If Me.TipoCargaCbte = TipoEmisionCbte.COMPRA Then
            .CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick
            .CellEditEnterChangesRows = True
            'End If

            .FullRowSelect = True
            .UseFiltering = False
            .ClearObjects()

        End With


    End Sub


    Private Sub FormAplicacionAnticipos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'iniciar formulario
        InicializarFormulario()
    End Sub

    Private Sub CustomGotFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = Color.LightGreen

        If sender.GetType = GetType(TextBox) Then
            DirectCast(sender, TextBox).Font = New Font(DirectCast(sender, TextBox).Font, FontStyle.Bold)
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
        For Each c As Control In Me.Controls
            Select Case c.GetType
                Case GetType(TextBox), GetType(CheckBox), GetType(ComboBox)
                    AddHandler c.GotFocus, AddressOf CustomGotFocus
                    AddHandler c.LostFocus, AddressOf CustomLostFocus
            End Select
        Next

        AddHandler Me.KeyDown, AddressOf FormularioKeyDown

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        If Not _guardando Then Cancelar()
    End Sub

    Private Sub Cancelar()
        If Not Me.FOLVCompPendientes.IsCellEditing Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    

    Private Sub InicializarCombos()

        InicializarComboCliente()

    End Sub


    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F12 : If Not _guardando Then Guardar()
            Case Keys.Escape : If Not _guardando Then Cancelar()
        End Select
    End Sub

    Private Sub InicializarComboCliente()
        With Me.CtlCustomComboCliente
            .ValueMember = "Id"
            .DisplayMember = "NombreyCodigo"
            .DataSource = _repositorioClientes.GetAllOrderByNombre
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            .SelectedIndex = -1
        End With
    End Sub


    Private Sub CtlCustomComboCliente_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtlCustomComboCliente.SelectedIndexChanged
        CargarComprobantes()
    End Sub

    Private Sub CargarComprobantes()
        If Not CtlCustomComboCliente.SelectedItem Is Nothing Then
            CargaDatosCbte(DirectCast(CtlCustomComboCliente.SelectedItem, Entidades.Cliente).Id)
        End If
    End Sub


    Private Sub CrearGrillaCompAnticipos()


        Dim c As BrightIdeasSoftware.OLVColumn

        With FOLVCompAnticipos

            .Columns.Clear()

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Comprobante"
            c.AspectName = "CbteDenominacion"
            c.MinimumWidth = 100
            c.FillsFreeSpace = True
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            'c.IsEditable = False
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Fecha"
            c.AspectName = "Cbtefecha"
            c.AspectToStringConverter = Function(x As String)
                                            Return ParseStringToDate(x)
                                        End Function
            c.MinimumWidth = 100
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            'c.IsEditable = False
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Vencimiento"
            c.AspectName = "Fechavtopago"
            c.AspectToStringConverter = Function(x As String)
                                            Return ParseStringToDate(x)
                                        End Function
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            'c.IsEditable = False
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Importe Total"
            c.AspectName = "Importetotal"
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("$ #,##0.00#")
                                        End Function
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            'c.IsEditable = False
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Saldo Anticipo"
            c.AspectName = "SaldoAsociado"
            c.AspectToStringConverter = Function(x As Double)
                                            Return x.ToString("$ #,##0.00#")
                                        End Function
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            'c.IsEditable = False
            .Columns.Add(c)



            'If Me.TipoCargaCbte = TipoEmisionCbte.COMPRA Then
            '.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick
            '.CellEditEnterChangesRows = True
            'End If

            .FullRowSelect = True
            .UseFiltering = False
            .ClearObjects()

        End With

    End Sub

    Private Sub Guardar()
        Try
            _guardando = True

            If _cbteanticipo Is Nothing Then
                Throw New Exception("Debe seleccionar un anticipo")
            End If

            If Me.FOLVCompPendientes.IsCellEditing Then
                Throw New Exception("Finalice la edición del comprobante aplicado al anticipo con la tecla [Escape] para continuar")
            End If

            If _totalaplicado <= 0 Then
                Throw New Exception("El total aplicado no puede ser cero")
            End If

            If _cbteanticipo.SaldoAsociado < _totalaplicado Then
                Throw New Exception("El total aplicado supera el saldo del anticipo")
            End If

            If MessageBox.Show("Confirma la aplicación del anticipo?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Throw New Exception("Aplicación cancelada por el usuario")
            End If

            Dim cbtes As New List(Of Entidades.CbteAsociado)

            For Each c As Entidades.CbteAsociado In _cbtesasociados
                If c.Importe > 0 Then
                    cbtes.Add(c)
                End If
            Next

            _repositorioCbtes.AplicarAnticipo(_cbteanticipo, cbtes)

            If _repositorioCbtes.HasError Then
                Throw New Exception(_repositorioCbtes.mensajes.ToString)
            End If

            MessageBox.Show("La operación ha finalizado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            _guardando = False

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            _guardando = False
        End Try
    End Sub

    Private Sub CargaDatosCbte(ByVal id As UInteger)
        Dim cbtes As New List(Of Entidades.CbteCabecera)

        For Each c As Entidades.CbteCabecera In _repositorioCbtes.GetAnticiposCliente(id, gUsuario.GodMode, False)
            If c.SaldoAsociado > 0 Then
                cbtes.Add(c)
            End If
        Next

        Me.FOLVCompAnticipos.Objects = cbtes

        If cbtes.Count <> 0 Then
            InicializarCbteCliente(id)
        End If

    End Sub
    

    Private Sub FOLVCompAnticipos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FOLVCompAnticipos.SelectedIndexChanged
        SetearAnticipo()
    End Sub

    Private Sub SetearAnticipo()
        _totalanticipo = 0
        _totalaplicado = 0

        If Not FOLVCompAnticipos.SelectedObject Is Nothing Then
            _cbteanticipo = DirectCast(FOLVCompAnticipos.SelectedObject, Entidades.CbteCabecera)
            Me.LabelAnticipo.Text = _cbteanticipo.CbteDenominacion
            Me.LabelAnticipoSaldo.Text = "Saldo del Anticipo: " & _cbteanticipo.SaldoAsociado.ToString("$ #,##0.00#")
        End If

        BorrarAplicacion()

        Totalizar()

    End Sub

    Private Sub BorrarAplicacion()

        For Each c As Entidades.CbteAsociado In Me._cbtesasociados
            c.Importe = 0
        Next

        PoblarGrillaCompPendientes()

    End Sub

    

    Private Sub FOLVCompPendientes_CellEditFinishing(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles FOLVCompPendientes.CellEditFinishing
        Totalizar()
    End Sub

    Private Sub FOLVCompPendientes_CellEditStarting(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles FOLVCompPendientes.CellEditStarting
        e.Control.BackColor = Color.LightGreen


        If e.Control.GetType = GetType(BrightIdeasSoftware.FloatCellEditor) Then
            DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Font = New Font(DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Font, FontStyle.Bold)
            DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Select(0, DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Text.Length)
        End If

    End Sub

    Private Sub FOLVCompPendientes_CellEditValidating(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles FOLVCompPendientes.CellEditValidating

        'validación por tipo de comprobantes
        If _cbteanticipo Is Nothing Then
            MessageBox.Show("Debe seleccionar un anticipo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
            Exit Sub
        End If

        Select Case _cbteanticipo.Cbtetipo
            Case RECIBO_PRESUPUESTO, PAGO_PRESUPUESTO
                If DirectCast(e.RowObject, Entidades.CbteAsociado).Tipo <> PRESUPUESTO Then
                    e.Cancel = True
                    Exit Sub
                End If
            Case Else
                If DirectCast(e.RowObject, Entidades.CbteAsociado).Tipo = PRESUPUESTO Then
                    e.Cancel = True
                    Exit Sub
                End If
        End Select

        If Val(e.NewValue) > DirectCast(e.RowObject, Entidades.CbteAsociado).Saldo Or Val(e.NewValue) < 0 Then
            If e.Control.GetType = GetType(BrightIdeasSoftware.FloatCellEditor) Then
                DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).BackColor = Color.Red
                DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Select(0, DirectCast(e.Control, BrightIdeasSoftware.FloatCellEditor).Text.Length)
            End If
            e.Cancel = True
        End If

    End Sub

    Private Sub Totalizar()
        _totalaplicado = 0

        For Each c As Entidades.CbteAsociado In Me.FOLVCompPendientes.Objects
            _totalaplicado += c.Importe
        Next

        If Not _cbteanticipo Is Nothing Then
            Me.LabelTotal.Text = "Importe TOTAL Aplicado: " & _totalaplicado.ToString("$ #,##0.00#") & " - Sin aplicar: " & (_cbteanticipo.SaldoAsociado - _totalaplicado).ToString("$ #,##0.00#")
        Else
            Me.LabelTotal.Text = "Importe TOTAL Aplicado: " & _totalaplicado.ToString("$ #,##0.00#") & " - Sin aplicar: " & (-_totalaplicado).ToString("$ #,##0.00#")
        End If



    End Sub

    Private Sub InicializarCbteCliente(ByVal id As UInteger)

        Dim repositorio As New CapaLogica.CbtecabeceraCLog
        Dim c As BrightIdeasSoftware.OLVColumn = Nothing
        Dim cols As New List(Of BrightIdeasSoftware.OLVColumn)
        Dim cbtes As New List(Of Entidades.CbteCabecera)
        Dim asoc As Entidades.CbteAsociado

        For Each cbte As Entidades.CbteCabecera In repositorio.GetCbtesCtaCteByCliente(id)

            Select Case cbte.Cbtetipo
                Case PRESUPUESTO
                    If gUsuario.GodMode Then
                        If cbte.SaldoEstadoCuenta <> 0 Then
                            cbtes.Add(cbte)
                        End If
                    End If
                Case FACTURA_A, FACTURA_B, TIQUE_FACTURA_A, TIQUE_FACTURA_B
                    If cbte.SaldoEstadoCuenta <> 0 Then
                        cbtes.Add(cbte)
                    End If
            End Select

        Next

        _cbtesasociados.Clear()

        For Each cbte As Entidades.CbteCabecera In cbtes
            asoc = New Entidades.CbteAsociado
            asoc.Tipo = cbte.Cbtetipo
            asoc.PtoVta = cbte.Cbteptovta
            asoc.Numero = cbte.Cbtenumero
            asoc.CbteReferencia = cbte.Id
            asoc.Importe = 0
            asoc.Denominacion = cbte.CbteDenominacion
            asoc.ImporteOriginal = cbte.Importetotal
            asoc.Fecha = ParseStringToDate(cbte.Cbtefecha)
            asoc.Saldo = cbte.SaldoEstadoCuenta
            _cbtesasociados.Add(asoc)
        Next

        PoblarGrillaCompPendientes()


    End Sub

    Private Sub PoblarGrillaCompPendientes()
        FOLVCompPendientes.Objects = _cbtesasociados
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If Not _guardando Then Guardar()
    End Sub
End Class