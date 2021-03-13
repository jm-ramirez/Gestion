<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCliente
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBoxId = New System.Windows.Forms.TextBox()
        Me.TextBoxNombre = New System.Windows.Forms.TextBox()
        Me.TextBoxDomicilio = New System.Windows.Forms.TextBox()
        Me.CheckBoxActivo = New System.Windows.Forms.CheckBox()
        Me.TextBoxEmail = New System.Windows.Forms.TextBox()
        Me.TextBoxTelefono = New System.Windows.Forms.TextBox()
        Me.TextBoxDocumentoNumero = New System.Windows.Forms.TextBox()
        Me.TextBoxObservacion = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBoxIngresosBrutos = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ComboBoxCondicionIB = New System.Windows.Forms.ComboBox()
        Me.nudIIBB = New System.Windows.Forms.NumericUpDown()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.nudLimite = New System.Windows.Forms.NumericUpDown()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.nudBonif = New System.Windows.Forms.NumericUpDown()
        Me.dtpFechaUltCpra = New System.Windows.Forms.DateTimePicker()
        Me.nudDiasCC = New System.Windows.Forms.NumericUpDown()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TextBoxCodigo = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.nudInteres = New System.Windows.Forms.NumericUpDown()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cboCondVta = New Principal.CtlCustomCombo()
        Me.cboTipoDoc = New Principal.CtlCustomCombo()
        Me.cboTipoResp = New Principal.CtlCustomCombo()
        Me.cboProvincia = New Principal.CtlCustomCombo()
        Me.cboLocalidad = New Principal.CtlCustomCombo()
        Me.cboListaPrecio = New Principal.CtlCustomCombo()
        Me.cboZonas = New Principal.CtlCustomCombo()
        Me.cboVendedores = New Principal.CtlCustomCombo()
        Me.TextBoxEmail2 = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TextBoxEmail3 = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtContacto = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.ToolStripMenu.SuspendLayout()
        CType(Me.nudIIBB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudLimite, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudBonif, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDiasCC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudInteres, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnGuardar, Me.BtnCancelar})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(574, 25)
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(80, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Id"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(52, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nombre"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(47, 253)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Teléfono"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(47, 121)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Domicilio"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(64, 279)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Email"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(36, 360)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Documento"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 392)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Condición Fiscal"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(34, 679)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Observación"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(41, 221)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Localidad"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxId
        '
        Me.TextBoxId.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxId.Location = New System.Drawing.Point(105, 39)
        Me.TextBoxId.MaxLength = 10
        Me.TextBoxId.Name = "TextBoxId"
        Me.TextBoxId.Size = New System.Drawing.Size(90, 20)
        Me.TextBoxId.TabIndex = 0
        Me.TextBoxId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxNombre
        '
        Me.TextBoxNombre.Location = New System.Drawing.Point(105, 92)
        Me.TextBoxNombre.MaxLength = 80
        Me.TextBoxNombre.Name = "TextBoxNombre"
        Me.TextBoxNombre.Size = New System.Drawing.Size(445, 20)
        Me.TextBoxNombre.TabIndex = 2
        '
        'TextBoxDomicilio
        '
        Me.TextBoxDomicilio.Location = New System.Drawing.Point(105, 118)
        Me.TextBoxDomicilio.MaxLength = 255
        Me.TextBoxDomicilio.Multiline = True
        Me.TextBoxDomicilio.Name = "TextBoxDomicilio"
        Me.TextBoxDomicilio.Size = New System.Drawing.Size(445, 60)
        Me.TextBoxDomicilio.TabIndex = 3
        '
        'CheckBoxActivo
        '
        Me.CheckBoxActivo.AutoSize = True
        Me.CheckBoxActivo.Location = New System.Drawing.Point(213, 65)
        Me.CheckBoxActivo.Name = "CheckBoxActivo"
        Me.CheckBoxActivo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBoxActivo.Size = New System.Drawing.Size(56, 17)
        Me.CheckBoxActivo.TabIndex = 24
        Me.CheckBoxActivo.TabStop = False
        Me.CheckBoxActivo.Text = "Activo"
        Me.CheckBoxActivo.UseVisualStyleBackColor = True
        '
        'TextBoxEmail
        '
        Me.TextBoxEmail.Location = New System.Drawing.Point(105, 276)
        Me.TextBoxEmail.MaxLength = 100
        Me.TextBoxEmail.Name = "TextBoxEmail"
        Me.TextBoxEmail.Size = New System.Drawing.Size(443, 20)
        Me.TextBoxEmail.TabIndex = 7
        '
        'TextBoxTelefono
        '
        Me.TextBoxTelefono.Location = New System.Drawing.Point(105, 250)
        Me.TextBoxTelefono.MaxLength = 45
        Me.TextBoxTelefono.Name = "TextBoxTelefono"
        Me.TextBoxTelefono.Size = New System.Drawing.Size(443, 20)
        Me.TextBoxTelefono.TabIndex = 6
        '
        'TextBoxDocumentoNumero
        '
        Me.TextBoxDocumentoNumero.Location = New System.Drawing.Point(428, 355)
        Me.TextBoxDocumentoNumero.MaxLength = 11
        Me.TextBoxDocumentoNumero.Name = "TextBoxDocumentoNumero"
        Me.TextBoxDocumentoNumero.Size = New System.Drawing.Size(120, 20)
        Me.TextBoxDocumentoNumero.TabIndex = 11
        Me.TextBoxDocumentoNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxObservacion
        '
        Me.TextBoxObservacion.Location = New System.Drawing.Point(107, 676)
        Me.TextBoxObservacion.Multiline = True
        Me.TextBoxObservacion.Name = "TextBoxObservacion"
        Me.TextBoxObservacion.Size = New System.Drawing.Size(442, 74)
        Me.TextBoxObservacion.TabIndex = 25
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(43, 187)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Provincia"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(403, 359)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(19, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Nº"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(46, 453)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 13)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Vendedor"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(67, 484)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(32, 13)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Zona"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(279, 422)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(32, 13)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Nº IB"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxIngresosBrutos
        '
        Me.TextBoxIngresosBrutos.Location = New System.Drawing.Point(317, 419)
        Me.TextBoxIngresosBrutos.MaxLength = 11
        Me.TextBoxIngresosBrutos.Name = "TextBoxIngresosBrutos"
        Me.TextBoxIngresosBrutos.Size = New System.Drawing.Size(119, 20)
        Me.TextBoxIngresosBrutos.TabIndex = 14
        Me.TextBoxIngresosBrutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(22, 516)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(77, 13)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Lista de Precio"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(8, 421)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(89, 13)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = "Cond. Ing. Brutos"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboBoxCondicionIB
        '
        Me.ComboBoxCondicionIB.FormattingEnabled = True
        Me.ComboBoxCondicionIB.Location = New System.Drawing.Point(106, 418)
        Me.ComboBoxCondicionIB.Name = "ComboBoxCondicionIB"
        Me.ComboBoxCondicionIB.Size = New System.Drawing.Size(163, 21)
        Me.ComboBoxCondicionIB.TabIndex = 13
        '
        'nudIIBB
        '
        Me.nudIIBB.DecimalPlaces = 2
        Me.nudIIBB.Location = New System.Drawing.Point(479, 417)
        Me.nudIIBB.Name = "nudIIBB"
        Me.nudIIBB.Size = New System.Drawing.Size(71, 20)
        Me.nudIIBB.TabIndex = 15
        Me.nudIIBB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(445, 422)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(28, 13)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "% IB"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(16, 652)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(85, 13)
        Me.Label20.TabIndex = 1
        Me.Label20.Text = "Limite de Crédito"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudLimite
        '
        Me.nudLimite.DecimalPlaces = 2
        Me.nudLimite.Location = New System.Drawing.Point(107, 650)
        Me.nudLimite.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 131072})
        Me.nudLimite.Name = "nudLimite"
        Me.nudLimite.Size = New System.Drawing.Size(118, 20)
        Me.nudLimite.TabIndex = 24
        Me.nudLimite.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(18, 627)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(82, 13)
        Me.Label21.TabIndex = 1
        Me.Label21.Text = "Bonificación (%)"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudBonif
        '
        Me.nudBonif.DecimalPlaces = 2
        Me.nudBonif.Location = New System.Drawing.Point(107, 624)
        Me.nudBonif.Name = "nudBonif"
        Me.nudBonif.Size = New System.Drawing.Size(64, 20)
        Me.nudBonif.TabIndex = 22
        Me.nudBonif.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dtpFechaUltCpra
        '
        Me.dtpFechaUltCpra.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaUltCpra.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaUltCpra.Location = New System.Drawing.Point(444, 599)
        Me.dtpFechaUltCpra.Name = "dtpFechaUltCpra"
        Me.dtpFechaUltCpra.Size = New System.Drawing.Size(107, 20)
        Me.dtpFechaUltCpra.TabIndex = 21
        '
        'nudDiasCC
        '
        Me.nudDiasCC.Location = New System.Drawing.Point(107, 599)
        Me.nudDiasCC.Maximum = New Decimal(New Integer() {365, 0, 0, 0})
        Me.nudDiasCC.Name = "nudDiasCC"
        Me.nudDiasCC.Size = New System.Drawing.Size(66, 20)
        Me.nudDiasCC.TabIndex = 20
        Me.nudDiasCC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(29, 601)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(74, 13)
        Me.Label17.TabIndex = 27
        Me.Label17.Text = "Días Cta. Cte."
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(319, 602)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(123, 13)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "Fecha de Última Compra"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxCodigo
        '
        Me.TextBoxCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCodigo.Location = New System.Drawing.Point(105, 66)
        Me.TextBoxCodigo.MaxLength = 5
        Me.TextBoxCodigo.Name = "TextBoxCodigo"
        Me.TextBoxCodigo.Size = New System.Drawing.Size(90, 20)
        Me.TextBoxCodigo.TabIndex = 1
        Me.TextBoxCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(56, 69)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(40, 13)
        Me.Label22.TabIndex = 32
        Me.Label22.Text = "Código"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(3, 545)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(100, 13)
        Me.Label23.TabIndex = 33
        Me.Label23.Text = "Condición de Venta"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudInteres
        '
        Me.nudInteres.DecimalPlaces = 2
        Me.nudInteres.Location = New System.Drawing.Point(486, 624)
        Me.nudInteres.Name = "nudInteres"
        Me.nudInteres.Size = New System.Drawing.Size(64, 20)
        Me.nudInteres.TabIndex = 23
        Me.nudInteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label24.Location = New System.Drawing.Point(349, 627)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(131, 13)
        Me.Label24.TabIndex = 35
        Me.Label24.Text = "Interés Diario por Mora (%)"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboCondVta
        '
        Me.cboCondVta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.cboCondVta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.cboCondVta.BusquedaPorCodigobarra = False
        Me.cboCondVta.ColumnasExtras = Nothing
        Me.cboCondVta.CustomFormatArt = False
        Me.cboCondVta.DataSource = Nothing
        Me.cboCondVta.DisplayMember = Nothing
        Me.cboCondVta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboCondVta.FormularioDeAlta = Nothing
        Me.cboCondVta.FormularioDeBusqueda = Nothing
        Me.cboCondVta.Location = New System.Drawing.Point(107, 540)
        Me.cboCondVta.MaximumSize = New System.Drawing.Size(500, 25)
        Me.cboCondVta.MinimumSize = New System.Drawing.Size(200, 25)
        Me.cboCondVta.Name = "cboCondVta"
        Me.cboCondVta.SelectedIndex = -1
        Me.cboCondVta.SelectedItem = Nothing
        Me.cboCondVta.SelectedText = ""
        Me.cboCondVta.SelectedValue = Nothing
        Me.cboCondVta.Size = New System.Drawing.Size(442, 25)
        Me.cboCondVta.TabIndex = 19
        Me.cboCondVta.ValueMember = Nothing
        '
        'cboTipoDoc
        '
        Me.cboTipoDoc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.cboTipoDoc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.cboTipoDoc.BusquedaPorCodigobarra = False
        Me.cboTipoDoc.ColumnasExtras = Nothing
        Me.cboTipoDoc.CustomFormatArt = False
        Me.cboTipoDoc.DataSource = Nothing
        Me.cboTipoDoc.DisplayMember = Nothing
        Me.cboTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboTipoDoc.FormularioDeAlta = Nothing
        Me.cboTipoDoc.FormularioDeBusqueda = Nothing
        Me.cboTipoDoc.Location = New System.Drawing.Point(105, 354)
        Me.cboTipoDoc.MaximumSize = New System.Drawing.Size(500, 25)
        Me.cboTipoDoc.MinimumSize = New System.Drawing.Size(200, 25)
        Me.cboTipoDoc.Name = "cboTipoDoc"
        Me.cboTipoDoc.SelectedIndex = -1
        Me.cboTipoDoc.SelectedItem = Nothing
        Me.cboTipoDoc.SelectedText = ""
        Me.cboTipoDoc.SelectedValue = Nothing
        Me.cboTipoDoc.Size = New System.Drawing.Size(287, 25)
        Me.cboTipoDoc.TabIndex = 10
        Me.cboTipoDoc.ValueMember = Nothing
        '
        'cboTipoResp
        '
        Me.cboTipoResp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.cboTipoResp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.cboTipoResp.BusquedaPorCodigobarra = False
        Me.cboTipoResp.ColumnasExtras = Nothing
        Me.cboTipoResp.CustomFormatArt = False
        Me.cboTipoResp.DataSource = Nothing
        Me.cboTipoResp.DisplayMember = Nothing
        Me.cboTipoResp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboTipoResp.FormularioDeAlta = Nothing
        Me.cboTipoResp.FormularioDeBusqueda = Nothing
        Me.cboTipoResp.Location = New System.Drawing.Point(105, 386)
        Me.cboTipoResp.MaximumSize = New System.Drawing.Size(500, 25)
        Me.cboTipoResp.MinimumSize = New System.Drawing.Size(200, 25)
        Me.cboTipoResp.Name = "cboTipoResp"
        Me.cboTipoResp.SelectedIndex = -1
        Me.cboTipoResp.SelectedItem = Nothing
        Me.cboTipoResp.SelectedText = ""
        Me.cboTipoResp.SelectedValue = Nothing
        Me.cboTipoResp.Size = New System.Drawing.Size(443, 25)
        Me.cboTipoResp.TabIndex = 12
        Me.cboTipoResp.ValueMember = Nothing
        '
        'cboProvincia
        '
        Me.cboProvincia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.cboProvincia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.cboProvincia.BusquedaPorCodigobarra = False
        Me.cboProvincia.ColumnasExtras = Nothing
        Me.cboProvincia.CustomFormatArt = False
        Me.cboProvincia.DataSource = Nothing
        Me.cboProvincia.DisplayMember = Nothing
        Me.cboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboProvincia.FormularioDeAlta = Nothing
        Me.cboProvincia.FormularioDeBusqueda = Nothing
        Me.cboProvincia.Location = New System.Drawing.Point(105, 184)
        Me.cboProvincia.MaximumSize = New System.Drawing.Size(500, 25)
        Me.cboProvincia.MinimumSize = New System.Drawing.Size(200, 25)
        Me.cboProvincia.Name = "cboProvincia"
        Me.cboProvincia.SelectedIndex = -1
        Me.cboProvincia.SelectedItem = Nothing
        Me.cboProvincia.SelectedText = ""
        Me.cboProvincia.SelectedValue = Nothing
        Me.cboProvincia.Size = New System.Drawing.Size(444, 25)
        Me.cboProvincia.TabIndex = 4
        Me.cboProvincia.ValueMember = Nothing
        '
        'cboLocalidad
        '
        Me.cboLocalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.cboLocalidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.cboLocalidad.BusquedaPorCodigobarra = False
        Me.cboLocalidad.ColumnasExtras = Nothing
        Me.cboLocalidad.CustomFormatArt = False
        Me.cboLocalidad.DataSource = Nothing
        Me.cboLocalidad.DisplayMember = Nothing
        Me.cboLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboLocalidad.FormularioDeAlta = Nothing
        Me.cboLocalidad.FormularioDeBusqueda = Nothing
        Me.cboLocalidad.Location = New System.Drawing.Point(105, 217)
        Me.cboLocalidad.MaximumSize = New System.Drawing.Size(500, 25)
        Me.cboLocalidad.MinimumSize = New System.Drawing.Size(200, 25)
        Me.cboLocalidad.Name = "cboLocalidad"
        Me.cboLocalidad.SelectedIndex = -1
        Me.cboLocalidad.SelectedItem = Nothing
        Me.cboLocalidad.SelectedText = ""
        Me.cboLocalidad.SelectedValue = Nothing
        Me.cboLocalidad.Size = New System.Drawing.Size(444, 25)
        Me.cboLocalidad.TabIndex = 5
        Me.cboLocalidad.ValueMember = Nothing
        '
        'cboListaPrecio
        '
        Me.cboListaPrecio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.cboListaPrecio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.cboListaPrecio.BusquedaPorCodigobarra = False
        Me.cboListaPrecio.ColumnasExtras = Nothing
        Me.cboListaPrecio.CustomFormatArt = False
        Me.cboListaPrecio.DataSource = Nothing
        Me.cboListaPrecio.DisplayMember = Nothing
        Me.cboListaPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboListaPrecio.FormularioDeAlta = Nothing
        Me.cboListaPrecio.FormularioDeBusqueda = Nothing
        Me.cboListaPrecio.Location = New System.Drawing.Point(107, 509)
        Me.cboListaPrecio.MaximumSize = New System.Drawing.Size(500, 25)
        Me.cboListaPrecio.MinimumSize = New System.Drawing.Size(200, 25)
        Me.cboListaPrecio.Name = "cboListaPrecio"
        Me.cboListaPrecio.SelectedIndex = -1
        Me.cboListaPrecio.SelectedItem = Nothing
        Me.cboListaPrecio.SelectedText = ""
        Me.cboListaPrecio.SelectedValue = Nothing
        Me.cboListaPrecio.Size = New System.Drawing.Size(442, 25)
        Me.cboListaPrecio.TabIndex = 18
        Me.cboListaPrecio.ValueMember = Nothing
        '
        'cboZonas
        '
        Me.cboZonas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.cboZonas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.cboZonas.BusquedaPorCodigobarra = False
        Me.cboZonas.ColumnasExtras = Nothing
        Me.cboZonas.CustomFormatArt = False
        Me.cboZonas.DataSource = Nothing
        Me.cboZonas.DisplayMember = Nothing
        Me.cboZonas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboZonas.FormularioDeAlta = Nothing
        Me.cboZonas.FormularioDeBusqueda = Nothing
        Me.cboZonas.Location = New System.Drawing.Point(107, 478)
        Me.cboZonas.MaximumSize = New System.Drawing.Size(500, 25)
        Me.cboZonas.MinimumSize = New System.Drawing.Size(200, 25)
        Me.cboZonas.Name = "cboZonas"
        Me.cboZonas.SelectedIndex = -1
        Me.cboZonas.SelectedItem = Nothing
        Me.cboZonas.SelectedText = ""
        Me.cboZonas.SelectedValue = Nothing
        Me.cboZonas.Size = New System.Drawing.Size(442, 25)
        Me.cboZonas.TabIndex = 17
        Me.cboZonas.ValueMember = Nothing
        '
        'cboVendedores
        '
        Me.cboVendedores.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.cboVendedores.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.cboVendedores.BusquedaPorCodigobarra = False
        Me.cboVendedores.ColumnasExtras = Nothing
        Me.cboVendedores.CustomFormatArt = False
        Me.cboVendedores.DataSource = Nothing
        Me.cboVendedores.DisplayMember = Nothing
        Me.cboVendedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboVendedores.FormularioDeAlta = Nothing
        Me.cboVendedores.FormularioDeBusqueda = Nothing
        Me.cboVendedores.Location = New System.Drawing.Point(107, 447)
        Me.cboVendedores.MaximumSize = New System.Drawing.Size(500, 25)
        Me.cboVendedores.MinimumSize = New System.Drawing.Size(200, 25)
        Me.cboVendedores.Name = "cboVendedores"
        Me.cboVendedores.SelectedIndex = -1
        Me.cboVendedores.SelectedItem = Nothing
        Me.cboVendedores.SelectedText = ""
        Me.cboVendedores.SelectedValue = Nothing
        Me.cboVendedores.Size = New System.Drawing.Size(442, 25)
        Me.cboVendedores.TabIndex = 16
        Me.cboVendedores.ValueMember = Nothing
        '
        'TextBoxEmail2
        '
        Me.TextBoxEmail2.Location = New System.Drawing.Point(105, 302)
        Me.TextBoxEmail2.MaxLength = 100
        Me.TextBoxEmail2.Name = "TextBoxEmail2"
        Me.TextBoxEmail2.Size = New System.Drawing.Size(443, 20)
        Me.TextBoxEmail2.TabIndex = 8
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(55, 305)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(41, 13)
        Me.Label25.TabIndex = 36
        Me.Label25.Text = "Email 2"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxEmail3
        '
        Me.TextBoxEmail3.Location = New System.Drawing.Point(105, 328)
        Me.TextBoxEmail3.MaxLength = 100
        Me.TextBoxEmail3.Name = "TextBoxEmail3"
        Me.TextBoxEmail3.Size = New System.Drawing.Size(443, 20)
        Me.TextBoxEmail3.TabIndex = 9
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(55, 331)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(41, 13)
        Me.Label26.TabIndex = 38
        Me.Label26.Text = "Email 3"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtContacto
        '
        Me.txtContacto.Location = New System.Drawing.Point(106, 573)
        Me.txtContacto.MaxLength = 80
        Me.txtContacto.Name = "txtContacto"
        Me.txtContacto.Size = New System.Drawing.Size(443, 20)
        Me.txtContacto.TabIndex = 20
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(52, 576)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(50, 13)
        Me.Label27.TabIndex = 40
        Me.Label27.Text = "Contacto"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FormCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(574, 755)
        Me.Controls.Add(Me.txtContacto)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.TextBoxEmail3)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.TextBoxEmail2)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.nudInteres)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.cboCondVta)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.TextBoxCodigo)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.dtpFechaUltCpra)
        Me.Controls.Add(Me.nudDiasCC)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.cboTipoDoc)
        Me.Controls.Add(Me.cboTipoResp)
        Me.Controls.Add(Me.cboProvincia)
        Me.Controls.Add(Me.cboLocalidad)
        Me.Controls.Add(Me.nudBonif)
        Me.Controls.Add(Me.nudLimite)
        Me.Controls.Add(Me.nudIIBB)
        Me.Controls.Add(Me.cboListaPrecio)
        Me.Controls.Add(Me.cboZonas)
        Me.Controls.Add(Me.cboVendedores)
        Me.Controls.Add(Me.ComboBoxCondicionIB)
        Me.Controls.Add(Me.CheckBoxActivo)
        Me.Controls.Add(Me.TextBoxObservacion)
        Me.Controls.Add(Me.TextBoxDomicilio)
        Me.Controls.Add(Me.TextBoxTelefono)
        Me.Controls.Add(Me.TextBoxIngresosBrutos)
        Me.Controls.Add(Me.TextBoxDocumentoNumero)
        Me.Controls.Add(Me.TextBoxEmail)
        Me.Controls.Add(Me.TextBoxNombre)
        Me.Controls.Add(Me.TextBoxId)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FormCliente"
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        CType(Me.nudIIBB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudLimite, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudBonif, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDiasCC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudInteres, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBoxId As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNombre As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents CheckBoxActivo As System.Windows.Forms.CheckBox
    Friend WithEvents TextBoxEmail As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxTelefono As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxDocumentoNumero As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboVendedores As Principal.CtlCustomCombo
    Friend WithEvents cboZonas As Principal.CtlCustomCombo
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextBoxIngresosBrutos As System.Windows.Forms.TextBox
    Friend WithEvents cboListaPrecio As Principal.CtlCustomCombo
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxCondicionIB As System.Windows.Forms.ComboBox
    Private WithEvents nudIIBB As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Private WithEvents nudLimite As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Private WithEvents nudBonif As System.Windows.Forms.NumericUpDown
    Friend WithEvents cboProvincia As Principal.CtlCustomCombo
    Friend WithEvents cboLocalidad As Principal.CtlCustomCombo
    Friend WithEvents cboTipoDoc As Principal.CtlCustomCombo
    Friend WithEvents cboTipoResp As Principal.CtlCustomCombo
    Friend WithEvents dtpFechaUltCpra As System.Windows.Forms.DateTimePicker
    Private WithEvents nudDiasCC As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TextBoxCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cboCondVta As Principal.CtlCustomCombo
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Private WithEvents nudInteres As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TextBoxEmail2 As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TextBoxEmail3 As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtContacto As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
End Class
