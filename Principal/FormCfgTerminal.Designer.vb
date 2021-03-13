<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCfgTerminal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ToolStripMenu = New System.Windows.Forms.ToolStrip()
        Me.BtnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.BtnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ComboBoxPuertoFiscal = New System.Windows.Forms.ComboBox()
        Me.GroupBoxFiscal = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBoxPtoVtaFiscal = New System.Windows.Forms.ComboBox()
        Me.GroupBoxElect = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ComboBoxPtoVtaElectronico = New System.Windows.Forms.ComboBox()
        Me.TextBoxPasswordCert = New System.Windows.Forms.TextBox()
        Me.LabelSalidasWs = New System.Windows.Forms.Label()
        Me.BtnSalidas = New System.Windows.Forms.Button()
        Me.LabelRutaTicket = New System.Windows.Forms.Label()
        Me.BtnTicket = New System.Windows.Forms.Button()
        Me.LabelCertificadoRuta = New System.Windows.Forms.Label()
        Me.BtnCertificado = New System.Windows.Forms.Button()
        Me.TextBoxUrlFev1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBoxUrlCDC = New System.Windows.Forms.TextBox()
        Me.TextBoxUrlLogin = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBoxServicioWSCDC = New System.Windows.Forms.ComboBox()
        Me.ComboBoxServicioWS = New System.Windows.Forms.ComboBox()
        Me.FBDRuta = New System.Windows.Forms.FolderBrowserDialog()
        Me.OFDArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBoxReportes = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ComboBoxSucursal = New System.Windows.Forms.ComboBox()
        Me.LabelRutaReportes = New System.Windows.Forms.Label()
        Me.ComboBoxPtoVtaRto = New System.Windows.Forms.ComboBox()
        Me.ComboBoxPtoVtaManual = New System.Windows.Forms.ComboBox()
        Me.BtnReportes = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBoxApariencia = New System.Windows.Forms.GroupBox()
        Me.PictureBoxImagen = New System.Windows.Forms.PictureBox()
        Me.BtnColor = New System.Windows.Forms.Button()
        Me.LabelColorFondo = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.BtnBorrarImagen = New System.Windows.Forms.Button()
        Me.BtnImagen = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ColorDialog = New System.Windows.Forms.ColorDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.chkSSL = New System.Windows.Forms.CheckBox()
        Me.TextBoxMailMessage = New System.Windows.Forms.TextBox()
        Me.TextBoxMailSubject = New System.Windows.Forms.TextBox()
        Me.TextBoxMailSmtpPassword = New System.Windows.Forms.TextBox()
        Me.TextBoxMailSmtpUsername = New System.Windows.Forms.TextBox()
        Me.TextBoxMailSmtpPort = New System.Windows.Forms.TextBox()
        Me.TextBoxMailSmtpHost = New System.Windows.Forms.TextBox()
        Me.TextBoxMailFrom = New System.Windows.Forms.TextBox()
        Me.ToolStripMenu.SuspendLayout()
        Me.GroupBoxFiscal.SuspendLayout()
        Me.GroupBoxElect.SuspendLayout()
        Me.GroupBoxReportes.SuspendLayout()
        Me.GroupBoxApariencia.SuspendLayout()
        CType(Me.PictureBoxImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnGuardar, Me.BtnCancelar})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(958, 25)
        Me.ToolStripMenu.TabIndex = 0
        Me.ToolStripMenu.Text = "ToolStrip1"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Image = Global.Principal.My.Resources.Resources.disk
        Me.BtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(95, 22)
        Me.BtnGuardar.Text = "Guardar [F12]"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = Global.Principal.My.Resources.Resources.cancel
        Me.BtnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(96, 22)
        Me.BtnCancelar.Text = "Cancelar [Esc]"
        '
        'ComboBoxPuertoFiscal
        '
        Me.ComboBoxPuertoFiscal.FormattingEnabled = True
        Me.ComboBoxPuertoFiscal.Location = New System.Drawing.Point(135, 19)
        Me.ComboBoxPuertoFiscal.Name = "ComboBoxPuertoFiscal"
        Me.ComboBoxPuertoFiscal.Size = New System.Drawing.Size(81, 21)
        Me.ComboBoxPuertoFiscal.TabIndex = 30
        '
        'GroupBoxFiscal
        '
        Me.GroupBoxFiscal.Controls.Add(Me.Label2)
        Me.GroupBoxFiscal.Controls.Add(Me.Label1)
        Me.GroupBoxFiscal.Controls.Add(Me.ComboBoxPuertoFiscal)
        Me.GroupBoxFiscal.Controls.Add(Me.ComboBoxPtoVtaFiscal)
        Me.GroupBoxFiscal.Location = New System.Drawing.Point(12, 301)
        Me.GroupBoxFiscal.Name = "GroupBoxFiscal"
        Me.GroupBoxFiscal.Size = New System.Drawing.Size(296, 84)
        Me.GroupBoxFiscal.TabIndex = 2
        Me.GroupBoxFiscal.TabStop = False
        Me.GroupBoxFiscal.Text = "Parametros de Configuración - Controlador Fiscal"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(48, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Punto de Venta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Puerto de Comunicación"
        '
        'ComboBoxPtoVtaFiscal
        '
        Me.ComboBoxPtoVtaFiscal.FormattingEnabled = True
        Me.ComboBoxPtoVtaFiscal.Location = New System.Drawing.Point(135, 48)
        Me.ComboBoxPtoVtaFiscal.Name = "ComboBoxPtoVtaFiscal"
        Me.ComboBoxPtoVtaFiscal.Size = New System.Drawing.Size(81, 21)
        Me.ComboBoxPtoVtaFiscal.TabIndex = 31
        '
        'GroupBoxElect
        '
        Me.GroupBoxElect.Controls.Add(Me.Label14)
        Me.GroupBoxElect.Controls.Add(Me.ComboBoxPtoVtaElectronico)
        Me.GroupBoxElect.Controls.Add(Me.TextBoxPasswordCert)
        Me.GroupBoxElect.Controls.Add(Me.LabelSalidasWs)
        Me.GroupBoxElect.Controls.Add(Me.BtnSalidas)
        Me.GroupBoxElect.Controls.Add(Me.LabelRutaTicket)
        Me.GroupBoxElect.Controls.Add(Me.BtnTicket)
        Me.GroupBoxElect.Controls.Add(Me.LabelCertificadoRuta)
        Me.GroupBoxElect.Controls.Add(Me.BtnCertificado)
        Me.GroupBoxElect.Controls.Add(Me.TextBoxUrlFev1)
        Me.GroupBoxElect.Controls.Add(Me.Label8)
        Me.GroupBoxElect.Controls.Add(Me.TextBoxUrlCDC)
        Me.GroupBoxElect.Controls.Add(Me.TextBoxUrlLogin)
        Me.GroupBoxElect.Controls.Add(Me.Label7)
        Me.GroupBoxElect.Controls.Add(Me.Label6)
        Me.GroupBoxElect.Controls.Add(Me.Label5)
        Me.GroupBoxElect.Controls.Add(Me.Label13)
        Me.GroupBoxElect.Controls.Add(Me.Label4)
        Me.GroupBoxElect.Controls.Add(Me.Label3)
        Me.GroupBoxElect.Controls.Add(Me.ComboBoxServicioWSCDC)
        Me.GroupBoxElect.Controls.Add(Me.ComboBoxServicioWS)
        Me.GroupBoxElect.Location = New System.Drawing.Point(12, 29)
        Me.GroupBoxElect.Name = "GroupBoxElect"
        Me.GroupBoxElect.Size = New System.Drawing.Size(464, 266)
        Me.GroupBoxElect.TabIndex = 0
        Me.GroupBoxElect.TabStop = False
        Me.GroupBoxElect.Text = "Parametros de Configuración - Facturación Electrónica"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(246, 145)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(81, 13)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "Punto de Venta"
        '
        'ComboBoxPtoVtaElectronico
        '
        Me.ComboBoxPtoVtaElectronico.FormattingEnabled = True
        Me.ComboBoxPtoVtaElectronico.Location = New System.Drawing.Point(333, 142)
        Me.ComboBoxPtoVtaElectronico.Name = "ComboBoxPtoVtaElectronico"
        Me.ComboBoxPtoVtaElectronico.Size = New System.Drawing.Size(81, 21)
        Me.ComboBoxPtoVtaElectronico.TabIndex = 8
        '
        'TextBoxPasswordCert
        '
        Me.TextBoxPasswordCert.Location = New System.Drawing.Point(91, 143)
        Me.TextBoxPasswordCert.Name = "TextBoxPasswordCert"
        Me.TextBoxPasswordCert.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxPasswordCert.Size = New System.Drawing.Size(125, 20)
        Me.TextBoxPasswordCert.TabIndex = 7
        Me.TextBoxPasswordCert.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelSalidasWs
        '
        Me.LabelSalidasWs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSalidasWs.Location = New System.Drawing.Point(91, 211)
        Me.LabelSalidasWs.Name = "LabelSalidasWs"
        Me.LabelSalidasWs.Size = New System.Drawing.Size(325, 45)
        Me.LabelSalidasWs.TabIndex = 11
        '
        'BtnSalidas
        '
        Me.BtnSalidas.FlatAppearance.BorderSize = 0
        Me.BtnSalidas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSalidas.Image = Global.Principal.My.Resources.Resources.folder_explore
        Me.BtnSalidas.Location = New System.Drawing.Point(422, 211)
        Me.BtnSalidas.Name = "BtnSalidas"
        Me.BtnSalidas.Size = New System.Drawing.Size(36, 20)
        Me.BtnSalidas.TabIndex = 12
        Me.BtnSalidas.UseVisualStyleBackColor = True
        '
        'LabelRutaTicket
        '
        Me.LabelRutaTicket.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelRutaTicket.Location = New System.Drawing.Point(91, 166)
        Me.LabelRutaTicket.Name = "LabelRutaTicket"
        Me.LabelRutaTicket.Size = New System.Drawing.Size(325, 45)
        Me.LabelRutaTicket.TabIndex = 9
        '
        'BtnTicket
        '
        Me.BtnTicket.FlatAppearance.BorderSize = 0
        Me.BtnTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnTicket.Image = Global.Principal.My.Resources.Resources.folder_explore
        Me.BtnTicket.Location = New System.Drawing.Point(422, 166)
        Me.BtnTicket.Name = "BtnTicket"
        Me.BtnTicket.Size = New System.Drawing.Size(36, 20)
        Me.BtnTicket.TabIndex = 10
        Me.BtnTicket.UseVisualStyleBackColor = True
        '
        'LabelCertificadoRuta
        '
        Me.LabelCertificadoRuta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelCertificadoRuta.Location = New System.Drawing.Point(91, 95)
        Me.LabelCertificadoRuta.Name = "LabelCertificadoRuta"
        Me.LabelCertificadoRuta.Size = New System.Drawing.Size(325, 45)
        Me.LabelCertificadoRuta.TabIndex = 5
        '
        'BtnCertificado
        '
        Me.BtnCertificado.FlatAppearance.BorderSize = 0
        Me.BtnCertificado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCertificado.Image = Global.Principal.My.Resources.Resources.folder_explore
        Me.BtnCertificado.Location = New System.Drawing.Point(422, 95)
        Me.BtnCertificado.Name = "BtnCertificado"
        Me.BtnCertificado.Size = New System.Drawing.Size(36, 20)
        Me.BtnCertificado.TabIndex = 6
        Me.BtnCertificado.UseVisualStyleBackColor = True
        '
        'TextBoxUrlFev1
        '
        Me.TextBoxUrlFev1.Location = New System.Drawing.Point(91, 68)
        Me.TextBoxUrlFev1.Name = "TextBoxUrlFev1"
        Me.TextBoxUrlFev1.Size = New System.Drawing.Size(301, 20)
        Me.TextBoxUrlFev1.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(23, 215)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 13)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Salidas WS"
        '
        'TextBoxUrlCDC
        '
        Me.TextBoxUrlCDC.Location = New System.Drawing.Point(91, 42)
        Me.TextBoxUrlCDC.Name = "TextBoxUrlCDC"
        Me.TextBoxUrlCDC.Size = New System.Drawing.Size(301, 20)
        Me.TextBoxUrlCDC.TabIndex = 1
        '
        'TextBoxUrlLogin
        '
        Me.TextBoxUrlLogin.Location = New System.Drawing.Point(91, 16)
        Me.TextBoxUrlLogin.Name = "TextBoxUrlLogin"
        Me.TextBoxUrlLogin.Size = New System.Drawing.Size(367, 20)
        Me.TextBoxUrlLogin.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(22, 170)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Ruta Ticket"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(26, 146)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Clave Cert."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Certificado"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(10, 45)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 13)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "URL WS CDC"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "URL WS Fev1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "URL WS Login"
        '
        'ComboBoxServicioWSCDC
        '
        Me.ComboBoxServicioWSCDC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxServicioWSCDC.FormattingEnabled = True
        Me.ComboBoxServicioWSCDC.Items.AddRange(New Object() {"wscdc"})
        Me.ComboBoxServicioWSCDC.Location = New System.Drawing.Point(398, 41)
        Me.ComboBoxServicioWSCDC.Name = "ComboBoxServicioWSCDC"
        Me.ComboBoxServicioWSCDC.Size = New System.Drawing.Size(60, 21)
        Me.ComboBoxServicioWSCDC.TabIndex = 2
        '
        'ComboBoxServicioWS
        '
        Me.ComboBoxServicioWS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxServicioWS.FormattingEnabled = True
        Me.ComboBoxServicioWS.Items.AddRange(New Object() {"wsfe"})
        Me.ComboBoxServicioWS.Location = New System.Drawing.Point(398, 68)
        Me.ComboBoxServicioWS.Name = "ComboBoxServicioWS"
        Me.ComboBoxServicioWS.Size = New System.Drawing.Size(60, 21)
        Me.ComboBoxServicioWS.TabIndex = 4
        '
        'OFDArchivo
        '
        Me.OFDArchivo.Filter = "Certificados p12|*.p12"
        '
        'GroupBoxReportes
        '
        Me.GroupBoxReportes.Controls.Add(Me.Label16)
        Me.GroupBoxReportes.Controls.Add(Me.Label15)
        Me.GroupBoxReportes.Controls.Add(Me.ComboBoxSucursal)
        Me.GroupBoxReportes.Controls.Add(Me.LabelRutaReportes)
        Me.GroupBoxReportes.Controls.Add(Me.ComboBoxPtoVtaRto)
        Me.GroupBoxReportes.Controls.Add(Me.ComboBoxPtoVtaManual)
        Me.GroupBoxReportes.Controls.Add(Me.BtnReportes)
        Me.GroupBoxReportes.Controls.Add(Me.Label9)
        Me.GroupBoxReportes.Controls.Add(Me.Label10)
        Me.GroupBoxReportes.Location = New System.Drawing.Point(482, 29)
        Me.GroupBoxReportes.Name = "GroupBoxReportes"
        Me.GroupBoxReportes.Size = New System.Drawing.Size(464, 107)
        Me.GroupBoxReportes.TabIndex = 1
        Me.GroupBoxReportes.TabStop = False
        Me.GroupBoxReportes.Text = "Parametros de Configuración - Terminal"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(203, 82)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(122, 13)
        Me.Label16.TabIndex = 3
        Me.Label16.Text = "Punto de Venta Remitos"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(179, 55)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(146, 13)
        Me.Label15.TabIndex = 3
        Me.Label15.Text = "Pto. de Vta. Recibos / Pagos"
        '
        'ComboBoxSucursal
        '
        Me.ComboBoxSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxSucursal.FormattingEnabled = True
        Me.ComboBoxSucursal.Items.AddRange(New Object() {"0", "1"})
        Me.ComboBoxSucursal.Location = New System.Drawing.Point(91, 52)
        Me.ComboBoxSucursal.Name = "ComboBoxSucursal"
        Me.ComboBoxSucursal.Size = New System.Drawing.Size(60, 21)
        Me.ComboBoxSucursal.TabIndex = 23
        '
        'LabelRutaReportes
        '
        Me.LabelRutaReportes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelRutaReportes.Location = New System.Drawing.Point(91, 16)
        Me.LabelRutaReportes.Name = "LabelRutaReportes"
        Me.LabelRutaReportes.Size = New System.Drawing.Size(325, 33)
        Me.LabelRutaReportes.TabIndex = 21
        '
        'ComboBoxPtoVtaRto
        '
        Me.ComboBoxPtoVtaRto.FormattingEnabled = True
        Me.ComboBoxPtoVtaRto.Location = New System.Drawing.Point(335, 79)
        Me.ComboBoxPtoVtaRto.Name = "ComboBoxPtoVtaRto"
        Me.ComboBoxPtoVtaRto.Size = New System.Drawing.Size(81, 21)
        Me.ComboBoxPtoVtaRto.TabIndex = 25
        '
        'ComboBoxPtoVtaManual
        '
        Me.ComboBoxPtoVtaManual.FormattingEnabled = True
        Me.ComboBoxPtoVtaManual.Location = New System.Drawing.Point(335, 52)
        Me.ComboBoxPtoVtaManual.Name = "ComboBoxPtoVtaManual"
        Me.ComboBoxPtoVtaManual.Size = New System.Drawing.Size(81, 21)
        Me.ComboBoxPtoVtaManual.TabIndex = 24
        '
        'BtnReportes
        '
        Me.BtnReportes.FlatAppearance.BorderSize = 0
        Me.BtnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnReportes.Image = Global.Principal.My.Resources.Resources.folder_explore
        Me.BtnReportes.Location = New System.Drawing.Point(422, 16)
        Me.BtnReportes.Name = "BtnReportes"
        Me.BtnReportes.Size = New System.Drawing.Size(36, 20)
        Me.BtnReportes.TabIndex = 22
        Me.BtnReportes.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 55)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Cód. Sucursal"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(15, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 32)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Carpeta de Reportes"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBoxApariencia
        '
        Me.GroupBoxApariencia.Controls.Add(Me.PictureBoxImagen)
        Me.GroupBoxApariencia.Controls.Add(Me.BtnColor)
        Me.GroupBoxApariencia.Controls.Add(Me.LabelColorFondo)
        Me.GroupBoxApariencia.Controls.Add(Me.Label12)
        Me.GroupBoxApariencia.Controls.Add(Me.BtnBorrarImagen)
        Me.GroupBoxApariencia.Controls.Add(Me.BtnImagen)
        Me.GroupBoxApariencia.Controls.Add(Me.Label11)
        Me.GroupBoxApariencia.Location = New System.Drawing.Point(482, 140)
        Me.GroupBoxApariencia.Name = "GroupBoxApariencia"
        Me.GroupBoxApariencia.Size = New System.Drawing.Size(464, 155)
        Me.GroupBoxApariencia.TabIndex = 3
        Me.GroupBoxApariencia.TabStop = False
        Me.GroupBoxApariencia.Text = "Parametros de Configuración - Apariencia"
        '
        'PictureBoxImagen
        '
        Me.PictureBoxImagen.Location = New System.Drawing.Point(288, 17)
        Me.PictureBoxImagen.Name = "PictureBoxImagen"
        Me.PictureBoxImagen.Size = New System.Drawing.Size(128, 128)
        Me.PictureBoxImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxImagen.TabIndex = 11
        Me.PictureBoxImagen.TabStop = False
        '
        'BtnColor
        '
        Me.BtnColor.FlatAppearance.BorderSize = 0
        Me.BtnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnColor.Image = Global.Principal.My.Resources.Resources.color_swatch
        Me.BtnColor.Location = New System.Drawing.Point(226, 17)
        Me.BtnColor.Name = "BtnColor"
        Me.BtnColor.Size = New System.Drawing.Size(36, 20)
        Me.BtnColor.TabIndex = 27
        Me.BtnColor.UseVisualStyleBackColor = True
        '
        'LabelColorFondo
        '
        Me.LabelColorFondo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelColorFondo.Location = New System.Drawing.Point(92, 18)
        Me.LabelColorFondo.Name = "LabelColorFondo"
        Me.LabelColorFondo.Size = New System.Drawing.Size(128, 20)
        Me.LabelColorFondo.TabIndex = 26
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(200, 37)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(82, 33)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Imagen de fondo"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnBorrarImagen
        '
        Me.BtnBorrarImagen.FlatAppearance.BorderSize = 0
        Me.BtnBorrarImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBorrarImagen.Image = Global.Principal.My.Resources.Resources.picture_delete
        Me.BtnBorrarImagen.Location = New System.Drawing.Point(422, 43)
        Me.BtnBorrarImagen.Name = "BtnBorrarImagen"
        Me.BtnBorrarImagen.Size = New System.Drawing.Size(36, 20)
        Me.BtnBorrarImagen.TabIndex = 29
        Me.BtnBorrarImagen.UseVisualStyleBackColor = True
        '
        'BtnImagen
        '
        Me.BtnImagen.FlatAppearance.BorderSize = 0
        Me.BtnImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnImagen.Image = Global.Principal.My.Resources.Resources.picture_add
        Me.BtnImagen.Location = New System.Drawing.Point(422, 17)
        Me.BtnImagen.Name = "BtnImagen"
        Me.BtnImagen.Size = New System.Drawing.Size(36, 20)
        Me.BtnImagen.TabIndex = 28
        Me.BtnImagen.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(12, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 21)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Color de fondo"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.chkSSL)
        Me.GroupBox1.Controls.Add(Me.TextBoxMailMessage)
        Me.GroupBox1.Controls.Add(Me.TextBoxMailSubject)
        Me.GroupBox1.Controls.Add(Me.TextBoxMailSmtpPassword)
        Me.GroupBox1.Controls.Add(Me.TextBoxMailSmtpUsername)
        Me.GroupBox1.Controls.Add(Me.TextBoxMailSmtpPort)
        Me.GroupBox1.Controls.Add(Me.TextBoxMailSmtpHost)
        Me.GroupBox1.Controls.Add(Me.TextBoxMailFrom)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(314, 301)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(632, 285)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parametros de Configuración - Email"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(323, 140)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(80, 13)
        Me.Label21.TabIndex = 11
        Me.Label21.Text = "Password Smtp"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(323, 101)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(70, 13)
        Me.Label20.TabIndex = 12
        Me.Label20.Text = "Usuario Smtp"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(320, 62)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(65, 13)
        Me.Label19.TabIndex = 13
        Me.Label19.Text = "Puerto Smtp"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(13, 101)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(81, 13)
        Me.Label24.TabIndex = 14
        Me.Label24.Text = "Mensaje [Pred.]"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(13, 62)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(74, 13)
        Me.Label23.TabIndex = 15
        Me.Label23.Text = "Asunto [Pred.]"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(15, 23)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(66, 13)
        Me.Label22.TabIndex = 16
        Me.Label22.Text = "Email [Pred.]"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(320, 23)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(73, 13)
        Me.Label25.TabIndex = 17
        Me.Label25.Text = "Servidor Smtp"
        '
        'chkSSL
        '
        Me.chkSSL.AutoSize = True
        Me.chkSSL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSSL.Location = New System.Drawing.Point(326, 182)
        Me.chkSSL.Name = "chkSSL"
        Me.chkSSL.Size = New System.Drawing.Size(88, 17)
        Me.chkSSL.TabIndex = 20
        Me.chkSSL.Text = "Enabled SSL"
        Me.chkSSL.UseVisualStyleBackColor = True
        '
        'TextBoxMailMessage
        '
        Me.TextBoxMailMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxMailMessage.Location = New System.Drawing.Point(15, 117)
        Me.TextBoxMailMessage.Multiline = True
        Me.TextBoxMailMessage.Name = "TextBoxMailMessage"
        Me.TextBoxMailMessage.Size = New System.Drawing.Size(301, 158)
        Me.TextBoxMailMessage.TabIndex = 15
        Me.TextBoxMailMessage.Text = "MailMessage"
        '
        'TextBoxMailSubject
        '
        Me.TextBoxMailSubject.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxMailSubject.Location = New System.Drawing.Point(15, 78)
        Me.TextBoxMailSubject.Name = "TextBoxMailSubject"
        Me.TextBoxMailSubject.Size = New System.Drawing.Size(301, 20)
        Me.TextBoxMailSubject.TabIndex = 14
        Me.TextBoxMailSubject.Text = "MailSubject"
        '
        'TextBoxMailSmtpPassword
        '
        Me.TextBoxMailSmtpPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxMailSmtpPassword.Location = New System.Drawing.Point(326, 156)
        Me.TextBoxMailSmtpPassword.Name = "TextBoxMailSmtpPassword"
        Me.TextBoxMailSmtpPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxMailSmtpPassword.Size = New System.Drawing.Size(301, 20)
        Me.TextBoxMailSmtpPassword.TabIndex = 19
        Me.TextBoxMailSmtpPassword.Text = "MailSmtpPassword"
        '
        'TextBoxMailSmtpUsername
        '
        Me.TextBoxMailSmtpUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxMailSmtpUsername.Location = New System.Drawing.Point(326, 117)
        Me.TextBoxMailSmtpUsername.Name = "TextBoxMailSmtpUsername"
        Me.TextBoxMailSmtpUsername.Size = New System.Drawing.Size(301, 20)
        Me.TextBoxMailSmtpUsername.TabIndex = 18
        Me.TextBoxMailSmtpUsername.Text = "MailSmtpUser"
        '
        'TextBoxMailSmtpPort
        '
        Me.TextBoxMailSmtpPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxMailSmtpPort.Location = New System.Drawing.Point(323, 78)
        Me.TextBoxMailSmtpPort.Name = "TextBoxMailSmtpPort"
        Me.TextBoxMailSmtpPort.Size = New System.Drawing.Size(301, 20)
        Me.TextBoxMailSmtpPort.TabIndex = 17
        Me.TextBoxMailSmtpPort.Text = "MailSmtpPort"
        '
        'TextBoxMailSmtpHost
        '
        Me.TextBoxMailSmtpHost.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxMailSmtpHost.Location = New System.Drawing.Point(323, 39)
        Me.TextBoxMailSmtpHost.Name = "TextBoxMailSmtpHost"
        Me.TextBoxMailSmtpHost.Size = New System.Drawing.Size(301, 20)
        Me.TextBoxMailSmtpHost.TabIndex = 16
        Me.TextBoxMailSmtpHost.Text = "MailSmtpHost"
        '
        'TextBoxMailFrom
        '
        Me.TextBoxMailFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxMailFrom.Location = New System.Drawing.Point(16, 39)
        Me.TextBoxMailFrom.Name = "TextBoxMailFrom"
        Me.TextBoxMailFrom.Size = New System.Drawing.Size(301, 20)
        Me.TextBoxMailFrom.TabIndex = 13
        Me.TextBoxMailFrom.Text = "MailFrom"
        '
        'FormCfgTerminal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(958, 592)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBoxApariencia)
        Me.Controls.Add(Me.GroupBoxReportes)
        Me.Controls.Add(Me.GroupBoxElect)
        Me.Controls.Add(Me.GroupBoxFiscal)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormCfgTerminal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración de Terminal"
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.GroupBoxFiscal.ResumeLayout(False)
        Me.GroupBoxFiscal.PerformLayout()
        Me.GroupBoxElect.ResumeLayout(False)
        Me.GroupBoxElect.PerformLayout()
        Me.GroupBoxReportes.ResumeLayout(False)
        Me.GroupBoxReportes.PerformLayout()
        Me.GroupBoxApariencia.ResumeLayout(False)
        CType(Me.PictureBoxImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ComboBoxPuertoFiscal As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBoxFiscal As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxElect As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBoxServicioWS As System.Windows.Forms.ComboBox
    Friend WithEvents TextBoxUrlLogin As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxUrlFev1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents FBDRuta As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents LabelCertificadoRuta As System.Windows.Forms.Label
    Friend WithEvents BtnCertificado As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents OFDArchivo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TextBoxPasswordCert As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LabelSalidasWs As System.Windows.Forms.Label
    Friend WithEvents BtnSalidas As System.Windows.Forms.Button
    Friend WithEvents LabelRutaTicket As System.Windows.Forms.Label
    Friend WithEvents BtnTicket As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxReportes As System.Windows.Forms.GroupBox
    Friend WithEvents LabelRutaReportes As System.Windows.Forms.Label
    Friend WithEvents BtnReportes As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxApariencia As System.Windows.Forms.GroupBox
    Friend WithEvents ColorDialog As System.Windows.Forms.ColorDialog
    Friend WithEvents BtnColor As System.Windows.Forms.Button
    Friend WithEvents LabelColorFondo As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents BtnImagen As System.Windows.Forms.Button
    Friend WithEvents PictureBoxImagen As System.Windows.Forms.PictureBox
    Friend WithEvents BtnBorrarImagen As System.Windows.Forms.Button
    Friend WithEvents TextBoxUrlCDC As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxServicioWSCDC As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxPtoVtaFiscal As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxPtoVtaElectronico As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxPtoVtaManual As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxPtoVtaRto As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Private WithEvents chkSSL As System.Windows.Forms.CheckBox
    Private WithEvents TextBoxMailMessage As System.Windows.Forms.TextBox
    Private WithEvents TextBoxMailSubject As System.Windows.Forms.TextBox
    Private WithEvents TextBoxMailSmtpPassword As System.Windows.Forms.TextBox
    Private WithEvents TextBoxMailSmtpUsername As System.Windows.Forms.TextBox
    Private WithEvents TextBoxMailSmtpPort As System.Windows.Forms.TextBox
    Private WithEvents TextBoxMailSmtpHost As System.Windows.Forms.TextBox
    Private WithEvents TextBoxMailFrom As System.Windows.Forms.TextBox
End Class
