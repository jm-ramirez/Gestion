Public Class FormAutorizar

    Property Permiso As PermisoUsuario
    Property Valor As Double
    Property Usuario As New Entidades.Personal

    ' TODO: inserte el código para realizar autenticación personalizada usando el nombre de usuario y la contraseña proporcionada 
    ' (Consulte http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' El objeto principal personalizado se puede adjuntar al objeto principal del subproceso actual como se indica a continuación: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' donde CustomPrincipal es la implementación de IPrincipal utilizada para realizar la autenticación. 
    ' Posteriormente, My.User devolverá la información de identidad encapsulada en el objeto CustomPrincipal
    ' como el nombre de usuario, nombre para mostrar, etc.

    Private _repositorio As New CapaLogica.PersonalCLog

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        Try

            Usuario = _repositorio.DoLogin(Me.UsernameTextBox.Text, Me.PasswordTextBox.Text)

            If Usuario IsNot Nothing Then
                Usuario.Sucursal = My.Settings.CodigoSucursal
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                If _repositorio.HasError Then
                    MessageBox.Show(_repositorio.mensajes.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    MessageBox.Show("Usuario o contraseña incorrecto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If

                Me.UsernameTextBox.Focus()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub CustomGotFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = Color.LightGreen

        If sender.GetType = GetType(TextBox) Then

            If sender Is Me.UsernameTextBox Then
                If sender.Text = "Nombre de usuario" Then
                    sender.ForeColor = Color.Black
                    sender.Text = ""
                End If
            End If

            If sender Is Me.PasswordTextBox Then
                If sender.Text = "Contraseña" Then
                    sender.PasswordChar = "*"
                    sender.ForeColor = Color.Black
                    sender.Text = ""
                End If
            End If

            DirectCast(sender, TextBox).Font = New Font(DirectCast(sender, TextBox).Font, FontStyle.Bold)
            DirectCast(sender, TextBox).SelectAll()
        End If

    End Sub

    Private Sub CustomLostFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = SystemColors.Window

        If sender.GetType = GetType(TextBox) Then

            If sender Is Me.UsernameTextBox Then
                If sender.Text = "" Then
                    sender.ForeColor = Color.Gray
                    sender.Text = "Nombre de usuario"
                End If
            End If

            If sender Is Me.PasswordTextBox Then
                If sender.Text = "" Then
                    sender.ForeColor = Color.Gray
                    sender.Text = "Contraseña"
                    sender.PasswordChar = ""
                End If
            End If

            DirectCast(sender, TextBox).Font = New Font(DirectCast(sender, TextBox).Font, FontStyle.Regular)
        End If

    End Sub
    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        For Each c As Control In Me.Controls
            Select Case c.GetType
                Case GetType(TextBox), GetType(CheckBox), GetType(ComboBox)
                    AddHandler c.GotFocus, AddressOf CustomGotFocus
                    AddHandler c.LostFocus, AddressOf CustomLostFocus
            End Select
        Next
    End Sub

    Private Sub UsernameTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsernameTextBox.TextChanged

    End Sub

    Private Sub FormAutorizar_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Select Case Permiso
            Case PermisoUsuario.TOPE_DESCUENTO
                Me.LabelTitulo.Text = "Autorizar Dto. Superior"
            Case PermisoUsuario.EMITE_NOTA_CREDITO
                Me.LabelTitulo.Text = "Autorizar Nota de Crédito"
        End Select
    End Sub
End Class
