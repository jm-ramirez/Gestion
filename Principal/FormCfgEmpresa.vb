Public Class FormCfgEmpresa

    'entidad
    Property Entidad As Entidades.Rubro

    'repositorios de tablas
    Private _repositorio As New CapaLogica.ParametroCLog

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

        Dim p As Entidades.Parametro

        p = _repositorio.GetByNombre("RazonSocialEmisor")

        Me.TextBoxRazonSocial.Text = p.Valorpredeterminado
        Me.TextBoxRazonSocial.Tag = p

        p = _repositorio.GetByNombre("NombreDeFantasiaEmisor")

        Me.TextBoxNombreFantasia.Text = p.Valorpredeterminado
        Me.TextBoxNombreFantasia.Tag = p

        p = _repositorio.GetByNombre("DomicilioComercialEmisor")

        Me.TextBoxDomicilio.Text = p.Valorpredeterminado
        Me.TextBoxDomicilio.Tag = p

        p = _repositorio.GetByNombre("CuitEmisor")

        Me.TextBoxCUIT.Text = p.Valorpredeterminado
        Me.TextBoxCUIT.Tag = p

        p = _repositorio.GetByNombre("CondicionIVAEmisor")
        Me.TextBoxCondicionIVA.Text = p.Valorpredeterminado
        Me.TextBoxCondicionIVA.Tag = p

        p = _repositorio.GetByNombre("IVAInscripto")
        Me.CheckBoxIVA.Checked = CBool(p.Valorpredeterminado)
        Me.CheckBoxIVA.Tag = p

        p = _repositorio.GetByNombre("EmailEmisor")
        Me.TextBoxEmail.Text = p.Valorpredeterminado
        Me.TextBoxEmail.Tag = p

        p = _repositorio.GetByNombre("SitioWebEmisor")
        Me.TextBoxWeb.Text = p.Valorpredeterminado
        Me.TextBoxWeb.Tag = p

        p = _repositorio.GetByNombre("IngresosBrutosEmisor")
        Me.TextBoxIIBB.Text = p.Valorpredeterminado
        Me.TextBoxIIBB.Tag = p

        p = _repositorio.GetByNombre("TelefonoEmisor")
        Me.TextBoxTelefono.Text = p.Valorpredeterminado
        Me.TextBoxTelefono.Tag = p

        Try

            p = _repositorio.GetByNombre("InicioActividadesEmisor")
            Me.DateTimePickerInicio.Value = CDate(p.Valorpredeterminado)
            Me.DateTimePickerInicio.Tag = p

        Catch ex As Exception

        End Try

    End Sub


    Private Sub FormRubro_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        For Each c As Control In Me.GroupBoxEmpresa.Controls
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

        Try

            If Not VerificaCuit(Me.TextBoxCUIT.Text) Then
                Throw New Exception("La CUIT ingresada no es válida")
            End If

            Dim p As Entidades.Parametro

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            For Each c As Control In Me.GroupBoxEmpresa.Controls
                Select Case c.GetType
                    Case GetType(TextBox), GetType(DateTimePicker), GetType(CheckBox)
                        p = DirectCast(c.Tag, Entidades.Parametro)

                        If c.GetType = GetType(DateTimePicker) Then
                            p.Valorpredeterminado = DirectCast(c, DateTimePicker).Value.ToString("dd/MM/yyyy")
                        ElseIf c.GetType = GetType(CheckBox) Then
                            p.Valorpredeterminado = DirectCast(c, CheckBox).Checked.ToString
                        Else
                            p.Valorpredeterminado = DirectCast(c, TextBox).Text.Trim
                        End If

                        _repositorio.Save(p)

                        If _repositorio.HasError Then
                            Throw New Exception(_repositorio.mensajes.ToString)
                        End If
                End Select
            Next

            CargarDatosEmpresa()

            MessageBox.Show("La operación ha finalizado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.DialogResult = Windows.Forms.DialogResult.OK

            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Guardar()
    End Sub

    

    Private Sub InicializarCombos()
        'configuracion controlador fiscal        
    End Sub



    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F12 : Guardar()
            Case Keys.Escape : Cancelar()
        End Select
    End Sub

    

    

    
End Class