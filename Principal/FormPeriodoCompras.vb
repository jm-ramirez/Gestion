Public Class FormPeriodoCompras


    'entidad
    'Property Entidad As Entidades.Reparto

    Private _repositorioProveedors As New CapaLogica.ProveedorCLog
    Private _repositorioCbtes As New CapaLogica.CpracabeceraCLog

    'inicializo formulario, limpieza o carga de valores
    Private Sub InicializarFormulario()

        Me.Text = "Modificación de Período de Compras"

        'limpieza de controles
        For Each c As Control In Me.Controls
            Select Case c.GetType
                Case GetType(TextBox) : DirectCast(c, TextBox).Text = ""
                Case GetType(ComboBox) : DirectCast(c, ComboBox).SelectedIndex = -1
                Case GetType(CheckBox) : DirectCast(c, CheckBox).Checked = False
            End Select
        Next

        InicializarCombos()
        CrearGrillaCompAsoc()

        'valores predeterminados
        Me.DateTimePickerPeriodoDesde.Value = CDate("01/" & Date.Today.Month & "/" & Date.Today.Year)
        Me.DateTimePickerPeriodoHasta.Value = CDate(Date.DaysInMonth(Date.Today.Year, Date.Today.Month) & "/" & Date.Today.Month & "/" & Date.Today.Year)

        Me.CtlCustomComboProveedor.FocoDetalle()

    End Sub


    Private Sub FormReparto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        Cancelar()
    End Sub

    Private Sub Cancelar()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    

    Private Sub InicializarCombos()

        InicializarComboProveedor()

    End Sub


    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F12 : Ver()
            Case Keys.Escape : Cancelar()
            Case Keys.Return : SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub InicializarComboProveedor()
        With Me.CtlCustomComboProveedor
            .ValueMember = "Id"
            .DisplayMember = "NombreyCodigo"
            .DataSource = _repositorioProveedors.GetAllOrderByNombre
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub CtlCustomComboProveedor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtlCustomComboProveedor.SelectedIndexChanged
        CargarComprobantes()
    End Sub

    Private Sub CargarComprobantes()
        If Not CtlCustomComboProveedor.SelectedItem Is Nothing Then
            CargaDatosCbte(DirectCast(CtlCustomComboProveedor.SelectedItem, Entidades.Proveedor).Id)
        End If
    End Sub

    Private Sub CrearGrillaCompAsoc()

        Dim c As BrightIdeasSoftware.OLVColumn

        With FOLVCompAsoc

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
            c.Text = "Per.Desde"
            c.AspectName = "Fechaserviciodesde"
            c.AspectToStringConverter = Function(x As String)
                                            Return ParseStringToDate(x)
                                        End Function
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Right
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            'c.IsEditable = False
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Per.Hasta"
            c.AspectName = "Fechaserviciohasta"
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



            'If Me.TipoCargaCbte = TipoEmisionCbte.COMPRA Then
            '.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick
            '.CellEditEnterChangesRows = True
            'End If

            .FullRowSelect = True
            .UseFiltering = True
            .ClearObjects()

        End With


    End Sub

    Private Sub Ver()
        If Not FOLVCompAsoc.SelectedObject Is Nothing Then
            Call EmisionCompra(DirectCast(FOLVCompAsoc.SelectedObject, Entidades.CpraCabecera).Id, True)
        End If
    End Sub

    Private Sub CargaDatosCbte(ByVal id As UInteger)
        Me.FOLVCompAsoc.ModelFilter = New BrightIdeasSoftware.ModelFilter(Function(x As Object)
                                                                              Select Case DirectCast(x, Entidades.CpraCabecera).Cbtetipo
                                                                                  Case FACTURA_A, TIQUE_FACTURA_A, NOTA_CREDITO_A, NOTA_DEBITO_A, FACTURA_B, TIQUE_FACTURA_B, NOTA_CREDITO_B, NOTA_DEBITO_B, FACTURA_C, TIQUE_FACTURA_C, NOTA_CREDITO_C, NOTA_DEBITO_C
                                                                                      Return True
                                                                                  Case Else
                                                                                      Return False
                                                                              End Select
                                                                          End Function)
        Me.FOLVCompAsoc.Objects = _repositorioCbtes.GetAllByProveedor(Proveedor:=id, vertodos:=False, cargaAlicuotas:=False, cargaArticulos:=False, cargaAsociados:=False, cargaCtaCte:=False, cargaFinanciero:=False, cargaTributos:=False)
    End Sub

    Private Sub BtnVer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnVer.Click
        Ver()
    End Sub

    Private Sub FOLVCompAsoc_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles FOLVCompAsoc.DoubleClick
        Ver()
    End Sub

    Private Sub ContextMenuItemVer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContextMenuItemVer.Click
        Ver()
    End Sub

    
    Private Sub FOLVCompAsoc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FOLVCompAsoc.SelectedIndexChanged
        CargarDatos()
    End Sub

    Private Sub CargarDatos()

        Try

            If FOLVCompAsoc.SelectedObject Is Nothing Then Exit Sub

            Me.DateTimePickerPeriodoDesde.Value = ParseStringToDate(DirectCast(FOLVCompAsoc.SelectedObject, Entidades.CpraCabecera).Fechaserviciodesde)
            Me.DateTimePickerPeriodoHasta.Value = ParseStringToDate(DirectCast(FOLVCompAsoc.SelectedObject, Entidades.CpraCabecera).Fechaserviciohasta)

        Catch ex As Exception

            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Try
            If FOLVCompAsoc.SelectedObject Is Nothing Then Throw New Exception("Debe seleccionar un comprobante")
            If Me.DateTimePickerPeriodoDesde.Value > Me.DateTimePickerPeriodoHasta.Value Then Throw New Exception("El período ingresado no es válido")
            If MessageBox.Show("Confirma el cambio del período fiscal para el comprobante seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub

            Dim obj As Entidades.CpraCabecera

            obj = DirectCast(FOLVCompAsoc.SelectedObject, Entidades.CpraCabecera)
            obj.Fechaserviciodesde = Me.DateTimePickerPeriodoDesde.Value.ToString("yyyyMMdd")
            obj.Fechaserviciohasta = Me.DateTimePickerPeriodoHasta.Value.ToString("yyyyMMdd")

            _repositorioCbtes.UpdatePeriodo(obj)

            If _repositorioCbtes.HasError Then
                Throw New Exception(_repositorioCbtes.mensajes.ToString)
            Else
                MessageBox.Show("La operación ha finalizado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                InicializarFormulario()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class