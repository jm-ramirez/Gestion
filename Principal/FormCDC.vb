Public Class FormCDC

    'repositorios de tablas
    Private WithEvents _cbteElectronico As New CbteElectronico

    'inicializo formulario, limpieza o carga de valores
    Private Sub InicializarFormulario()

        'limpieza de controles
        For Each c As Control In Me.GroupBoxCDC.Controls
            Select Case c.GetType
                Case GetType(TextBox) : DirectCast(c, TextBox).Text = ""
                Case GetType(ComboBox) : DirectCast(c, ComboBox).SelectedIndex = -1
                Case GetType(CheckBox) : DirectCast(c, CheckBox).Checked = False
            End Select
        Next

        InicializarCombos()

        Me.Text = "WSCDC - Constatación de Comprobantes Eletrónicos"

    End Sub

    

    Private Sub FormVendedor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'iniciar formulario
        InicializarFormulario()
    End Sub

    Private Sub InicializarComboDocumentos()
        Dim repositorio As New CapaLogica.TipodocumentoCLog

        With Me.ComboBoxTipoDoc
            .ValueMember = "Codigo"
            .DisplayMember = "Descripcion"
            .DataSource = repositorio.GetAll
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub CustomGotFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = Color.LightGreen

        If sender.GetType = GetType(TextBox) Then
            DirectCast(sender, TextBox).Font = New Font(DirectCast(sender, TextBox).Font, FontStyle.Bold)
            If sender IsNot TextBoxRespuesta Then
                DirectCast(sender, TextBox).SelectAll()
            End If
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
        For Each c As Control In Me.GroupBoxCDC.Controls
            Select Case c.GetType
                Case GetType(TextBox), GetType(CheckBox), GetType(ComboBox)
                    AddHandler c.GotFocus, AddressOf CustomGotFocus
                    AddHandler c.LostFocus, AddressOf CustomLostFocus
            End Select
        Next

        AddHandler Me.KeyDown, AddressOf FormularioKeyDown
        AddHandler Me.TextBoxCodigobarra.KeyDown, AddressOf FormularioKeyDown

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Cancelar()
    End Sub

    Private Sub Cancelar()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ConstatarCbte()

        Dim response As wscdc.CmpResponse
        Dim request As wscdc.CmpDatos

        Try

            Me.GroupBoxCDC.Enabled = False

            request = New wscdc.CmpDatos

            With request
                .CbteFch = Me.DateTimePickerFecha.Value.ToString("yyyyMMdd")
                .CbteModo = Me.ComboBoxModo.Text
                .CbteNro = Convert.ToUInt32(Me.TextBoxNumero.Text)
                .CbteTipo = Convert.ToInt32(Me.ComboBoxTipo.SelectedValue)
                .CodAutorizacion = Me.TextBoxCodAutorizacion.Text.Trim
                .CuitEmisor = Convert.ToUInt64(Me.TextBoxCuitEmisor.Text)
                .ImpTotal = Convert.ToDouble(Me.TextBoxImpTotal.Text)
                .PtoVta = Convert.ToInt32(Me.TextBoxPtoVta.Text)
                .DocTipoReceptor = Me.ComboBoxTipoDoc.SelectedValue
                .DocNroReceptor = Me.TextBoxDocReceptor.Text.Trim
            End With

            response = _cbteElectronico.ConstatacionDeComprobante(request)

            Me.TextBoxRespuesta.Text = ""

            If response IsNot Nothing Then
                Me.TextBoxRespuesta.Text = "Resultado: " & response.Resultado & vbNewLine

                If response.Observaciones IsNot Nothing Then
                    Me.TextBoxRespuesta.Text &= "Observaciones:" & vbNewLine
                    For i As Integer = 0 To response.Observaciones.Length - 1
                        Me.TextBoxRespuesta.Text &= "Cód.: " & response.Observaciones(i).Code & " - " & response.Observaciones(i).Msg & vbNewLine
                    Next
                End If

                If response.Errors IsNot Nothing Then
                    Me.TextBoxRespuesta.Text &= "Errores:" & vbNewLine
                    For i As Integer = 0 To response.Errors.Length - 1
                        Me.TextBoxRespuesta.Text &= "Cód.: " & response.Errors(i).Code & " - " & response.Errors(i).Msg & vbNewLine
                    Next
                End If

            End If

            Me.GroupBoxCDC.Enabled = True

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.GroupBoxCDC.Enabled = True
        Finally
            response = Nothing
            request = Nothing
        End Try

    End Sub

    Private Sub BtnConstatar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConstatar.Click
        ConstatarCbte()
    End Sub

    Private Sub InicializarCombos()
        InicializarComboDocumentos()
        InicializarComboTipoCbte()
    End Sub

    Private Sub InicializarComboTipoCbte()
        Dim repositorio As New CapaLogica.TipocomprobanteCLog

        With Me.ComboBoxTipo
            .ValueMember = "Codigo"
            .DisplayMember = "Descripcion"
            .DataSource = repositorio.GetCbtesElectronicos
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F12 : ConstatarCbte()
            Case Keys.Escape : Cancelar()
            Case Keys.Enter
                If sender Is TextBoxCodigobarra Then
                    Descomponer()
                End If
        End Select
    End Sub

    Private Sub Descomponer()
        Try
            If Me.TextBoxCodigobarra.Text.Trim.Length = 0 Then
                Exit Sub
            End If

            Dim cbte As wscdc.CmpDatos = DescomponerCodigoBarra(Me.TextBoxCodigobarra.Text.Trim)

            Me.TextBoxCodAutorizacion.Text = cbte.CodAutorizacion
            Me.TextBoxCuitEmisor.Text = cbte.CuitEmisor
            Me.TextBoxPtoVta.Text = cbte.PtoVta
            Me.ComboBoxTipo.SelectedValue = Convert.ToUInt32(cbte.CbteTipo)


        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Descomponer código de barras", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    
    Private Sub BtnCodigo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCodigo.Click
        Descomponer()
    End Sub
End Class