Public Class FormPersonal

    'entidad
    Property Entidad As Entidades.Personal

    'repositorios de tablas
    Private _repositorio As New CapaLogica.PersonalCLog
    Private _repositorioPerfiles As New CapaLogica.PerfilCLog

    'inicializar tablas foraneas
    Private Sub InicializarCombos()

        InicializarComboPerfiles()

    End Sub

    Private Sub InicializarComboPerfiles()
        With Me.CtlComboPerfil
            .ValueMember = "Id"
            .DisplayMember = "Nombre"
            .DataSource = _repositorioPerfiles.GetAll
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            '.FormularioDeAlta = FormListas
            .Inicializar()
            .SelectedIndex = -1
        End With
    End Sub

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

        'el campo id no se puede modificar cuando es autoincremental
        Me.TextBoxId.Enabled = False

        'editar registro
        If Not Entidad Is Nothing Then
            Me.CheckBoxActivo.Checked = Entidad.Activo
            Me.TextBoxId.Text = Entidad.Id
            Me.TextBoxNombre.Text = Entidad.Nombre
            Me.TextBoxDomicilio.Text = Entidad.Domicilio
            Me.TextBoxTelefono.Text = Entidad.Telefono
            Me.TextBoxEmail.Text = Entidad.Email
            Me.CtlComboPerfil.SelectedValue = Entidad.Perfil
            Me.TextBoxPassword.Text = Entidad.Password
            Me.TextBoxLogin.Text = Entidad.Login
            Me.TextBoxLogin.Enabled = False
            Me.CheckBoxNotaCredito.Checked = Entidad.Notadecredito
            Me.CheckBoxDtoGral.Checked = Entidad.DescuentoGral
            Me.NumericUpDownDto.Value = Entidad.DescuentoTope
            Me.Text = "Editar registro"

        Else 'nuevo registro, valores por defecto
            Me.TextBoxLogin.Enabled = True
            Me.Text = "Nuevo registro"
            Me.TextBoxId.Text = "0"
            Me.CheckBoxActivo.Checked = True

        End If

        Me.TextBoxNombre.Focus()

    End Sub

    Private Sub FormPersonal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
                Case GetType(TextBox), GetType(CheckBox), GetType(ComboBox), GetType(NumericUpDown)
                    AddHandler c.GotFocus, AddressOf CustomGotFocus
                    AddHandler c.LostFocus, AddressOf CustomLostFocus
                    AddHandler c.PreviewKeyDown, AddressOf CustomPreviewKeyDown
            End Select
        Next

        AddHandler Me.KeyDown, AddressOf FormularioKeyDown

    End Sub

    Private Sub CustomPreviewKeyDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs)
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
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

            'actualizo los valores de la entidad que se desea persistir
            If Entidad Is Nothing Then
                Entidad = New Entidades.Personal
            End If

            Entidad.Nombre = Me.TextBoxNombre.Text
            Entidad.Domicilio = Me.TextBoxDomicilio.Text
            Entidad.Activo = Me.CheckBoxActivo.Checked
            Entidad.Email = Me.TextBoxEmail.Text
            Entidad.Telefono = Me.TextBoxTelefono.Text
            Entidad.Perfil = Convert.ToUInt32(Me.CtlComboPerfil.SelectedValue)
            Entidad.Password = Me.TextBoxPassword.Text
            Entidad.Login = Me.TextBoxLogin.Text
            Entidad.Notadecredito = Me.CheckBoxNotaCredito.Checked
            Entidad.DescuentoGral = Me.CheckBoxDtoGral.Checked
            Entidad.DescuentoTope = Me.NumericUpDownDto.Value
            'envio los nuevos datos al repositor para actualizar
            _repositorio.Save(Entidad)

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

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F12 : Guardar()
            Case Keys.Escape : Cancelar()
            Case Keys.Return : SendKeys.Send("{TAB}")
        End Select
    End Sub
   

End Class