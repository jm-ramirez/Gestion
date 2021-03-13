Public Class FormConsultaComprobantes


    'entidad
    'Property Entidad As Entidades.Reparto

    Private _repositorioClientes As New CapaLogica.ClienteCLog
    Private _repositorioCbtes As New CapaLogica.CbtecabeceraCLog

    'inicializo formulario, limpieza o carga de valores
    Private Sub InicializarFormulario()

        Me.Text = "Consulta de Comprobantes"

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
    
    Private Sub ComboBoxRepartos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub InicializarCombos()

        InicializarComboCliente()

    End Sub


    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F12 : Ver()
            Case Keys.Escape : Cancelar()
            Case Keys.Return : SendKeys.Send("{TAB}")
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
            .UseFiltering = False
            .ClearObjects()

        End With


    End Sub

    Private Sub Ver()
        If Not FOLVCompAsoc.SelectedObject Is Nothing Then
            If DirectCast(FOLVCompAsoc.SelectedObject, Entidades.CbteCabecera).Cbtetipo = 91 Then
                Call EmisionCbteRemito(DirectCast(FOLVCompAsoc.SelectedObject, Entidades.CbteCabecera).Id, , True)
            Else
                Call EmisionCbte(DirectCast(FOLVCompAsoc.SelectedObject, Entidades.CbteCabecera).Id, True)
            End If
        End If
    End Sub

   

    Private Sub CargaDatosCbte(id As UInteger)
        'Me.FOLVCompAsoc.Objects = _repositorioCbtes.GetAllByCliente(cliente:=id, vertodos:=gUsuario.GodMode, ordenDescendete:=True, _
        '                                                             cargaAlicuotas:=False, cargaArticulos:=False, cargaAsociados:=False, _
        '                                                             cargaCtaCte:=False, cargaFinanciero:=True, cargaTributos:=False).OrderByDescending(Function(x) x.Cbtefecha).ToList()

        Me.FOLVCompAsoc.Objects = _repositorioCbtes.GetAllByCliente(cliente:=id, vertodos:=gUsuario.GodMode, ordenDescendete:=True, _
                                                                     cargaAlicuotas:=False, cargaArticulos:=False, cargaAsociados:=False, _
                                                                     cargaCtaCte:=False, cargaFinanciero:=True, cargaTributos:=False).OrderByDescending(Function(x) x.Cbtefecha).ToList()
    End Sub

    Private Sub BtnVer_Click(sender As Object, e As System.EventArgs) Handles BtnVer.Click
        Ver()
    End Sub

    Private Sub FOLVCompAsoc_DoubleClick(sender As Object, e As System.EventArgs) Handles FOLVCompAsoc.DoubleClick
        Ver()
    End Sub

    Private Sub FOLVCompAsoc_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles FOLVCompAsoc.SelectedIndexChanged

    End Sub

    Private Sub ContextMenuItemVer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContextMenuItemVer.Click
        Ver()
    End Sub

    Private Sub ContextMenuItemAnular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContextMenuItemAnular.Click
        Anular()
    End Sub

    Private Sub Anular()

        Try
            If Not FOLVCompAsoc.SelectedObject Is Nothing Then

                Dim c As Entidades.CbteCabecera = DirectCast(FOLVCompAsoc.SelectedObject, Entidades.CbteCabecera)

                Select Case c.Cbtetipo
                    Case ORDEN_PAGO, RECIBO_COBRANZA, RECIBO_PRESUPUESTO, PAGO_PRESUPUESTO, PRESUPUESTO, REMITO, DEVOLUCION_PRESUPUESTO

                        If MessageBox.Show("Confirma la anulación del comprobante " & c.CbteDenominacion & "?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                            Exit Sub
                        End If

                        _repositorioCbtes.Anular(c)

                        If _repositorioCbtes.HasError Then
                            Throw New Exception(_repositorioCbtes.mensajes.ToString)
                        Else
                            MessageBox.Show("La operación ha finalizado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                            CargarComprobantes()

                        End If

                    Case Else
                        Throw New Exception("El tipo de comprobante seleccionado no puede ser anulado")
                End Select

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DesaplicarRecibo()

        Try
            If Not FOLVCompAsoc.SelectedObject Is Nothing Then

                Dim c As Entidades.CbteCabecera = DirectCast(FOLVCompAsoc.SelectedObject, Entidades.CbteCabecera)

                Select Case c.Cbtetipo
                    Case RECIBO_COBRANZA, RECIBO_PRESUPUESTO, PAGO_PRESUPUESTO, ORDEN_PAGO

                        If c.Denominacion.Contains("AJUSTE") = True Then
                            Throw New Exception("El tipo de comprobante seleccionado no es un Recibo/Orden de Pago")
                        End If

                        If MessageBox.Show("Generar anticipo del comprobante " & c.CbteDenominacion & "?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                            Exit Sub
                        End If

                        _repositorioCbtes.DesaplicarRecibo(c)

                        If _repositorioCbtes.HasError Then
                            Throw New Exception(_repositorioCbtes.mensajes.ToString)
                        Else
                            MessageBox.Show("La operación ha finalizado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                            CargarComprobantes()

                        End If

                    Case Else
                        Throw New Exception("El tipo de comprobante seleccionado no es un Recibo/Orden de Pago")
                End Select

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub ContextMenuItemDesaplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenuItemDesaplicar.Click
        DesaplicarRecibo()
    End Sub
End Class