Imports System.Windows.Forms

Public Class FormFpDialog

    Property Importe As Double
    Property Comprobante As String
    Property FormaPago As Entidades.Financiero
    Property Tipo As Char
    Private repositorioConceptos As New CapaLogica.ConceptobancarioCLog



    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        Try

            Dim fp As New Entidades.Financiero

            If RadioButtonTarjeta.Checked Then

                If Me.ComboBoxTarjetas.SelectedItem Is Nothing Then
                    Throw New Exception("Debe seleccionar una tarjeta para la forma de pago seleccionada")
                End If

                If Me.TextBoxReferencia.Text.Trim.Length = 0 Then
                    Throw New Exception("Debe ingresar el número de cupón para la forma de pago seleccionada")
                End If

                fp.Concepto = DirectCast(Me.ComboBoxTarjetas.SelectedItem, Entidades.Conceptobancario).Codigo
                fp.Tipo = Me.Tipo 'DirectCast(Me.ComboBoxTarjetas.SelectedItem, Entidades.Conceptobancario).Tipo
                fp.Referencia = Me.TextBoxReferencia.Text.Trim
                fp.Importe = Me.Importe

                FormaPago = fp

            End If

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, LabelInput.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FormFpDialog_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            Me.TextBoxVuelto.Text = Me.Importe
            Me.TextBoxVuelto.SelectAll()
            Me.TextBoxVuelto.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    
    Private Sub FormFpDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.RadioButtonEfectivo.Checked = True
        Me.LabelImporte.Text = Importe.ToString("$ #,##0.00#")
        Me.LabelCbte.Text = Comprobante
        InicializarCombo()
    End Sub

    Private Sub InicializarCombo()

        Dim conceptosbancarios As New List(Of Entidades.Conceptobancario)
        Dim tarjetas As New List(Of Entidades.Conceptobancario)

        'If Tipo = CONCEPTO_DEUDOR Then
        conceptosbancarios = repositorioConceptos.GetConceptosDeudores
        'Else
        'conceptosbancarios = repositorioConceptos.GetConceptosAcreedores
        'End If


        For Each t As Entidades.Conceptobancario In conceptosbancarios
            If t.Nombre.Contains("TARJETA") Then
                tarjetas.Add(t)
            End If
        Next


        With Me.ComboBoxTarjetas
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .DataSource = tarjetas
            .SelectedIndex = -1
        End With
    End Sub

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        For Each c As Control In Me.Controls
            Select Case c.GetType
                Case GetType(TextBox), GetType(ComboBox)
                    AddHandler c.GotFocus, AddressOf CustomGotFocus
                    AddHandler c.LostFocus, AddressOf CustomLostFocus
                Case GetType(GroupBox)
                    For Each g As Control In c.Controls
                        Select Case g.GetType
                            Case GetType(TextBox), GetType(ComboBox), GetType(DateTimePicker)
                                AddHandler g.GotFocus, AddressOf CustomGotFocus
                                AddHandler g.LostFocus, AddressOf CustomLostFocus
                        End Select
                    Next
            End Select
        Next

    End Sub

    Private Sub CustomGotFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = Color.LightGreen

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

    Private Sub RadioButtonTarjeta_Click(sender As Object, e As System.EventArgs) Handles RadioButtonTarjeta.Click
        If RadioButtonTarjeta.Checked Then ComboBoxTarjetas.Focus()
    End Sub

   
    Private Sub TextBoxVuelto_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxVuelto.TextChanged
        Me.LabelVuelto.Text = (Val(Me.TextBoxVuelto.Text) - Me.Importe).ToString("$ #,##0.00")
    End Sub
End Class
