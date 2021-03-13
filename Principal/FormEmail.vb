Public Class FormEmail
    'modo 1: informe de clientes
    'modo 2: envio de presupuestos
    Property Modo As Integer

    Property Cbte As Entidades.CbteCabecera2
    Property mstrEmail As String

    'datos para enviar mail de informe a cliente
    Property ReporteAGenerar As ReporteCtaCte
    Property fechaDesde As String
    Property fechaHasta As String
    Property idCliente As Integer
    Property nombreCliente As String
    Property Email As String

    Private _repoCliente As New CapaLogica.ClienteCLog
    Private _cliente As New Entidades.Cliente

    'inicializo formulario, limpieza o carga de valores
    Private Sub InicializarFormulario()
        Try


            'limpieza de controles
            For Each c As Control In Me.Controls
                Select Case c.GetType
                    Case GetType(TextBox) : DirectCast(c, TextBox).Text = ""
                    Case GetType(ComboBox) : DirectCast(c, ComboBox).SelectedIndex = -1
                    Case GetType(CheckBox) : DirectCast(c, CheckBox).Checked = False
                End Select
            Next
            If Modo = 1 Then
                Me.Text = "Enviar email a " & nombreCliente
                Me.TextBoxMailTo.Text = Email

                Me.TextBoxMailSubject.Text = "Envio de Informes" 'My.Settings.MailSubject
                Me.TextBoxMailMessage.Text = My.Settings.MailMessage
                Me.LabelAttach.Text = EnviarInfCliente(ReporteAGenerar, fechaDesde, fechaHasta, idCliente, nombreCliente)
            ElseIf Modo = 2 Then
                If Cbte.Clienteid = "" Then
                    Me.Text = "Enviar email a " & Cbte.Razonsocial
                    Me.TextBoxMailTo.Text = Cbte.Email
                Else
                    _cliente = _repoCliente.GetByCodigo(Cbte.Clienteid)

                    If _cliente IsNot Nothing Then
                        Me.Text = "Enviar email a " & _cliente.NombreyCodigo
                        Me.TextBoxMailTo.Text = _cliente.Email & IIf(Len(_cliente.Email2) > 0, ", " & _cliente.Email2, "") & IIf(Len(_cliente.Email3) > 0, ", " & _cliente.Email3, "")
                    Else
                        Me.TextBoxMailTo.Text = mstrEmail
                    End If
                End If

                Me.TextBoxMailSubject.Text = My.Settings.MailSubject
                Me.TextBoxMailMessage.Text = My.Settings.MailMessage
                Me.LabelAttach.Text = ExportarCbteToPDF(Cbte.Id)
            End If

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub FormEmail_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'iniciar formulario
        InicializarFormulario()
    End Sub

    Private Sub CustomGotFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = Color.LightSteelBlue

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

            Dim mail As New MailSender
            mail.Username = My.Settings.SmtpUser
            mail.UseSSL = My.Settings.SmtpUseSSL
            mail.Password = My.Settings.SmtpPassword
            mail.MailTo = Me.TextBoxMailTo.Text.Trim
            mail.MailSubject = Me.TextBoxMailSubject.Text.Trim
            mail.MailFrom = My.Settings.MailFrom
            mail.Attachs.Add(Me.LabelAttach.Text)
            mail.MailMessage = Me.TextBoxMailMessage.Text.Trim
            mail.SmtpPort = My.Settings.SmtpPort
            mail.SmtpHost = My.Settings.SmtpHost
            mail.SendEmailMessage()

            MessageBox.Show("Proceso finalizado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.Close()

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
        End Select
    End Sub

End Class