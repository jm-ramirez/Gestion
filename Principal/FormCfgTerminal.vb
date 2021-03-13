Public Class FormCfgTerminal

    'entidad
    Property Entidad As Entidades.Rubro

    'repositorios de tablas
    Private _repositorio As New CapaLogica.RubroCLog

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

        'seteo valores de configuracion
        'facturacion electronica
        Me.ComboBoxServicioWS.SelectedItem = My.Settings.WsaaIdServicio
        Me.ComboBoxServicioWSCDC.SelectedItem = My.Settings.WscdcIdServicio
        Me.TextBoxUrlLogin.Text = My.Settings.UrlWsaa
        Me.TextBoxUrlCDC.Text = My.Settings.UrlWscdc
        Me.TextBoxUrlFev1.Text = My.Settings.UrlWsfe
        Me.LabelCertificadoRuta.Text = My.Settings.WsaaCertificado
        Me.TextBoxPasswordCert.Text = My.Settings.WsaaCertificadoPassword
        Me.LabelRutaTicket.Text = My.Settings.WsaaRutaTicket
        Me.LabelSalidasWs.Text = My.Settings.WsfeRutaSalidas
        Me.LabelRutaReportes.Text = My.Settings.RutaReportes
        Me.ComboBoxSucursal.SelectedItem = My.Settings.CodigoSucursal.ToString
        Me.LabelColorFondo.BackColor = My.Settings.BackgroundColor

        Me.TextBoxMailFrom.Text = My.Settings.MailFrom
        Me.TextBoxMailSubject.Text = My.Settings.MailSubject
        Me.TextBoxMailMessage.Text = My.Settings.MailMessage
        Me.TextBoxMailSmtpHost.Text = My.Settings.SmtpHost
        Me.TextBoxMailSmtpPassword.Text = My.Settings.SmtpPassword
        Me.TextBoxMailSmtpPort.Text = My.Settings.SmtpPort
        Me.TextBoxMailSmtpUsername.Text = My.Settings.SmtpUser
        Me.chkSSL.Checked = My.Settings.SmtpUseSSL

        Try
            Me.PictureBoxImagen.Image = Image.FromFile(My.Settings.BackgroundImage)
            Me.PictureBoxImagen.Tag = My.Settings.BackgroundImage
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
        For Each c As Control In Me.GroupBoxElect.Controls
            Select Case c.GetType
                Case GetType(TextBox), GetType(CheckBox), GetType(ComboBox)
                    AddHandler c.GotFocus, AddressOf CustomGotFocus
                    AddHandler c.LostFocus, AddressOf CustomLostFocus
            End Select
        Next

        For Each c As Control In Me.GroupBoxFiscal.Controls
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

            'configuracion fiscal
            My.Settings.PuertoCommFiscal = Me.ComboBoxPuertoFiscal.SelectedItem

            'configuracion electronica
            My.Settings.UrlWsaa = Me.TextBoxUrlLogin.Text
            My.Settings.UrlWscdc = Me.TextBoxUrlCDC.Text
            My.Settings.UrlWsfe = Me.TextBoxUrlFev1.Text
            My.Settings.WsaaCertificado = Me.LabelCertificadoRuta.Text
            My.Settings.WsaaCertificadoPassword = Me.TextBoxPasswordCert.Text
            My.Settings.WsaaIdServicio = Me.ComboBoxServicioWS.Text
            My.Settings.WscdcIdServicio = Me.ComboBoxServicioWSCDC.Text
            My.Settings.WsaaCertificadoPassword = Me.TextBoxPasswordCert.Text
            My.Settings.WsaaRutaTicket = Me.LabelRutaTicket.Text
            My.Settings.WsfeRutaSalidas = Me.LabelSalidasWs.Text
            My.Settings.RutaReportes = Me.LabelRutaReportes.Text
            My.Settings.CodigoSucursal = Me.ComboBoxSucursal.Text

            My.Settings.BackgroundColor = Me.LabelColorFondo.BackColor
            My.Settings.BackgroundImage = Me.PictureBoxImagen.Tag

            My.Settings.PuntoVtaMayorista = Me.ComboBoxPtoVtaElectronico.SelectedValue
            My.Settings.PuntoVtaMinorista = Me.ComboBoxPtoVtaFiscal.SelectedValue
            My.Settings.PuntoVtaManual = Me.ComboBoxPtoVtaManual.SelectedValue
            My.Settings.PuntoVtaRto = Me.ComboBoxPtoVtaRto.SelectedValue

            My.Settings.MailFrom = Me.TextBoxMailFrom.Text
            My.Settings.MailSubject = Me.TextBoxMailSubject.Text
            My.Settings.MailMessage = Me.TextBoxMailMessage.Text
            My.Settings.SmtpHost = Me.TextBoxMailSmtpHost.Text
            My.Settings.SmtpPassword = Me.TextBoxMailSmtpPassword.Text
            My.Settings.SmtpPort = Me.TextBoxMailSmtpPort.Text
            My.Settings.SmtpUser = Me.TextBoxMailSmtpUsername.Text
            My.Settings.SmtpUseSSL = Me.chkSSL.Checked

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

    Private Sub ComboBoxRubros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub InicializarCombos()
        'configuracion controlador fiscal
        ComboBoxPuertoFiscal.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxPuertoFiscal.DataSource = [Enum].GetValues(GetType(EpsonFPHostControlX.TxCommPort))
        ComboBoxPuertoFiscal.SelectedItem = My.Settings.PuertoCommFiscal

        Dim repositorio As New CapaLogica.CbtepuntoventaCLog
        Dim puntos As New List(Of Entidades.Cbtepuntoventa)

        Dim p As New Entidades.Cbtepuntoventa
        p.Ptovta = 0

        puntos = repositorio.GetPtosElectronicos
        puntos.Add(p)

        With Me.ComboBoxPtoVtaElectronico
            .ValueMember = "Ptovta"
            .DisplayMember = "Ptovta"
            .DataSource = puntos
            .SelectedValue = My.Settings.PuntoVtaMayorista
        End With

        puntos = repositorio.GetPtosFiscales
        puntos.Add(p)

        With Me.ComboBoxPtoVtaFiscal
            .ValueMember = "Ptovta"
            .DisplayMember = "Ptovta"
            .DataSource = puntos
            .SelectedValue = My.Settings.PuntoVtaMinorista
        End With

        puntos = repositorio.GetAll
        puntos.Add(p)

        With Me.ComboBoxPtoVtaManual
            .ValueMember = "Ptovta"
            .DisplayMember = "Ptovta"
            .DataSource = puntos
            .SelectedValue = My.Settings.PuntoVtaManual
        End With

        puntos = repositorio.GetAll
        puntos.Add(p)

        With Me.ComboBoxPtoVtaRto
            .ValueMember = "Ptovta"
            .DisplayMember = "Ptovta"
            .DataSource = puntos
            .SelectedValue = My.Settings.PuntoVtaRto
        End With

    End Sub

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F12 : Guardar()
            Case Keys.Escape : Cancelar()
            Case Keys.Enter
                If Me.ActiveControl.Name <> "TextBoxMailMessage" Then
                    SendKeys.Send("{TAB}")
                End If
        End Select
    End Sub

    Private Sub BtnCertificado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCertificado.Click

        Try


            With OFDArchivo

                .CheckFileExists = True
                .CheckPathExists = True
                .FileName = ""
                .Filter = "Certificados p12|*.p12"
                If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Me.LabelCertificadoRuta.Text = .FileName
                End If
            End With
        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub BtnTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTicket.Click
        Try
            With FBDRuta

                If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Me.LabelRutaTicket.Text = .SelectedPath
                End If
            End With
        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnSalidas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalidas.Click
        Try


            With FBDRuta
                If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Me.LabelSalidasWs.Text = .SelectedPath
                End If
            End With
        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnReportes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnReportes.Click
        Try


            With FBDRuta
                If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Me.LabelRutaReportes.Text = .SelectedPath
                End If
            End With
        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnColor.Click
        Try
            With ColorDialog

                If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Me.LabelColorFondo.BackColor = .Color
                End If

            End With
        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnImagen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnImagen.Click
        Try


            With OFDArchivo

                .CheckFileExists = True
                .CheckPathExists = True
                .FileName = ""
                .Filter = "Imagenes|*.jpg;*.png|PNG|*.png|JPEG|*.jpg"
                If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Try
                        Me.PictureBoxImagen.Image = Image.FromFile(.FileName)
                        Me.PictureBoxImagen.Tag = .FileName
                    Catch ex As Exception
                    End Try
                End If
            End With
        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnBorrarImagen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBorrarImagen.Click
        Me.PictureBoxImagen.Image = Nothing
        Me.PictureBoxImagen.Tag = ""
    End Sub



End Class