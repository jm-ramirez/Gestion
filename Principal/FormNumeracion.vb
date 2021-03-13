Public Class FormNumeracion

    'repositorios de tablas
    Private _repositorio As New CapaLogica.CbtenumeracionCLog
    Private WithEvents _WSFEV As New CbteElectronico

    'inicializo formulario, limpieza o carga de valores
    Private Sub InicializarFormulario()

        'limpieza de controles
        For Each c As Control In Me.Controls
            Select Case c.GetType
                Case GetType(TextBox) : DirectCast(c, TextBox).Text = ""
                Case GetType(ComboBox) : DirectCast(c, ComboBox).SelectedIndex = -1
                Case GetType(CheckBox) : DirectCast(c, CheckBox).Checked = False
            End Select
        Next

        InicializarCombos()
        
        Me.Text = "Control de numeración de comprobantes"

        ConfigurarGrilla()
        PoblarGrilla()

    End Sub

    Private Sub FormComisionDetale_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.TextBoxFilter.Focus()
    End Sub

    Private Sub FormComisionDetale_AutoSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.AutoSizeChanged

    End Sub

    Private Sub FormVendedor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

    Private Sub Guardar()

        Dim objList As List(Of Entidades.Cbtenumeracion)

        Try
            If MessageBox.Show("Confirma los cambios realizados en la numeración de comprobantes?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Throw New Exception("actualización cancelada por el usuario")
            End If

            objList = New List(Of Entidades.Cbtenumeracion)

            For Each obj As Object In Me.FOLVRegistros.Objects
                objList.Add(DirectCast(obj, Entidades.Cbtenumeracion))
            Next

            'envio los nuevos datos al repositor para actualizar
            _repositorio.SaveAll(objList)

            If _repositorio.HasError Then

                MessageBox.Show(_repositorio.mensajes.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

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

    Private Sub InicializarCombos()
        '
    End Sub

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F12 : Guardar()
            Case Keys.Escape : Cancelar()
            Case Keys.Return : SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub ConfigurarGrilla()
        CrearColumnas()

        With FOLVRegistros
            .FullRowSelect = True
            .UseFiltering = True
            .CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick
        End With

    End Sub

    Private Sub PoblarGrilla()

        If gUsuario.GodMode Then
            Me.FOLVRegistros.Objects = _repositorio.GetAll
        Else
            Me.FOLVRegistros.Objects = _repositorio.GetAll2
        End If


        Me.FOLVRegistros.AutoResizeColumns()
    End Sub

    Private Sub CrearColumnas()

        Dim c As BrightIdeasSoftware.OLVColumn

        With FOLVRegistros

            .Columns.Clear()

            'Property Id as UInt32
            'Property Ptovta As UInt32
            'Property Cbtetipo As UInt32
            'Property Numero As UInt32

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Id"
            c.AspectName = "Id"
            c.MinimumWidth = 35
            c.IsVisible = False
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = False
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Pto. Venta"
            c.AspectName = "Ptovta"
            c.TextAlign = HorizontalAlignment.Center
            c.AspectToStringConverter = Function(x As UInt32)
                                            Return x.ToString("0000")
                                        End Function
            c.MinimumWidth = 75
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = False
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Tipo Cbte."
            c.AspectName = "Cbtetipo"
            c.TextAlign = HorizontalAlignment.Center
            c.AspectToStringConverter = Function(x As UInt32)
                                            Return x.ToString("000")
                                        End Function
            c.MinimumWidth = 75
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = False
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Denominación"
            c.AspectName = "Denominacion"
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Left
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.FillsFreeSpace = True
            c.IsEditable = False
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Número"
            c.AspectName = "Numero"
            c.MinimumWidth = 100
            c.TextAlign = HorizontalAlignment.Center
            c.AspectToStringConverter = Function(x As UInt32)
                                            Return x.ToString("00000000")
                                        End Function
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns.Add(c)

            c = New BrightIdeasSoftware.OLVColumn
            c.Text = "Ult. Cbte. AFIP"
            c.AspectName = "NumeroAfip"
            c.MinimumWidth = 125
            c.TextAlign = HorizontalAlignment.Center
            c.AspectToStringConverter = Function(x As UInt32)
                                            Return x.ToString("00000000")
                                        End Function
            c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            c.IsEditable = False
            .Columns.Add(c)
            

        End With
    End Sub

    Private Sub BtnBorrarFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBorrarFiltro.Click
        Me.FOLVRegistros.ResetColumnFiltering()
    End Sub

    Private Sub FOLVRegistros_CellEditStarting(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles FOLVRegistros.CellEditStarting
        e.Control.BackColor = Color.LightGreen
        e.Control.Font = New Font(e.Control.Font, FontStyle.Bold)
    End Sub

    Private Sub FOLVRegistros_CellEditValidating(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles FOLVRegistros.CellEditValidating
        If Val(e.NewValue) < 0 Then
            'If e.Control.GetType = GetType(BrightIdeasSoftware.IntUpDown) Then
            e.Control.BackColor = Color.Red
            'DirectCast(e.Control, BrightIdeasSoftware.IntUpDown).Select(0, DirectCast(e.Control, BrightIdeasSoftware.IntUpDown).Text.Length)
            'End If
            e.Cancel = True
        End If
    End Sub

    Private Sub BtnFiltrar_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFiltrar.Click
        If Me.TextBoxFilter.TextLength = 0 Then
            Me.TextBoxFilter.Focus()
        Else
            'aplico el filtro
            Dim filter As BrightIdeasSoftware.TextMatchFilter = BrightIdeasSoftware.TextMatchFilter.Contains(FOLVRegistros, TextBoxFilter.Text)
            FOLVRegistros.ModelFilter = filter
            FOLVRegistros.DefaultRenderer = New BrightIdeasSoftware.HighlightTextRenderer(filter)
        End If
    End Sub

    Private Sub _WSFEV_Status(ByVal status As String) Handles _WSFEV.Status
        Me.StatusBarNumeracion.Text = status
        Application.DoEvents()
    End Sub

    Private Sub BtnAfip_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAfip.Click
        If Not _WSFEV.ConexionConAFIP Then
            _WSFEV.CrearConexionAFIP()
        End If

        Dim numeracion As New List(Of Entidades.Cbtenumeracion)

        If gUsuario.GodMode Then
            numeracion = _repositorio.GetAll
        Else
            numeracion = _repositorio.GetAll2
        End If

        For Each n As Entidades.Cbtenumeracion In numeracion
            If n.Ptovta = My.Settings.PuntoVtaMayorista Then
                n.NumeroAfip = _WSFEV.UltimoCbteAutorizado(n.Ptovta, n.Cbtetipo)
            End If
        Next

        Me.FOLVRegistros.Objects = numeracion

        Me.FOLVRegistros.AutoResizeColumns()
        

    End Sub
End Class