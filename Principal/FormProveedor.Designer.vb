<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProveedor
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
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBoxIngresosBrutos = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.NumericUpDownIIBB = New System.Windows.Forms.NumericUpDown()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chkConvenioMultilateral = New System.Windows.Forms.CheckBox()
        Me.nudDiasCC = New System.Windows.Forms.NumericUpDown()
        Me.ComboBoxCondgcias = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TextBoxCodigo = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.dtpFechaUltCpra = New System.Windows.Forms.DateTimePicker()
        Me.cboRubGcias = New Principal.CtlCustomCombo()
        Me.cboProvincia = New Principal.CtlCustomCombo()
        Me.cboLocalidad = New Principal.CtlCustomCombo()
        Me.cboTipoDoc = New Principal.CtlCustomCombo()
        Me.cboTipoResp = New Principal.CtlCustomCombo()
        Me.nudRetIva = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ToolStripMenu.SuspendLayout()
        CType(Me.NumericUpDownIIBB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDiasCC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudRetIva, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnGuardar, Me.BtnCancelar})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(521, 25)
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
        Me.Label1.Location = New System.Drawing.Point(80, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Id"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(52, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nombre"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(47, 252)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Teléfono"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(47, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Domicilio"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(64, 278)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Email"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(34, 306)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Documento"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 338)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Condición Fiscal"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(31, 478)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Observación"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(42, 223)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Localidad"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxId
        '
        Me.TextBoxId.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxId.Location = New System.Drawing.Point(105, 38)
        Me.TextBoxId.MaxLength = 10
        Me.TextBoxId.Name = "TextBoxId"
        Me.TextBoxId.Size = New System.Drawing.Size(90, 20)
        Me.TextBoxId.TabIndex = 0
        Me.TextBoxId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxNombre
        '
        Me.TextBoxNombre.Location = New System.Drawing.Point(105, 91)
        Me.TextBoxNombre.MaxLength = 80
        Me.TextBoxNombre.Name = "TextBoxNombre"
        Me.TextBoxNombre.Size = New System.Drawing.Size(398, 20)
        Me.TextBoxNombre.TabIndex = 3
        '
        'TextBoxDomicilio
        '
        Me.TextBoxDomicilio.Location = New System.Drawing.Point(105, 117)
        Me.TextBoxDomicilio.MaxLength = 255
        Me.TextBoxDomicilio.Multiline = True
        Me.TextBoxDomicilio.Name = "TextBoxDomicilio"
        Me.TextBoxDomicilio.Size = New System.Drawing.Size(398, 60)
        Me.TextBoxDomicilio.TabIndex = 4
        '
        'CheckBoxActivo
        '
        Me.CheckBoxActivo.AutoSize = True
        Me.CheckBoxActivo.Location = New System.Drawing.Point(206, 65)
        Me.CheckBoxActivo.Name = "CheckBoxActivo"
        Me.CheckBoxActivo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBoxActivo.Size = New System.Drawing.Size(56, 17)
        Me.CheckBoxActivo.TabIndex = 2
        Me.CheckBoxActivo.TabStop = False
        Me.CheckBoxActivo.Text = "Activo"
        Me.CheckBoxActivo.UseVisualStyleBackColor = True
        '
        'TextBoxEmail
        '
        Me.TextBoxEmail.Location = New System.Drawing.Point(105, 274)
        Me.TextBoxEmail.MaxLength = 100
        Me.TextBoxEmail.Name = "TextBoxEmail"
        Me.TextBoxEmail.Size = New System.Drawing.Size(398, 20)
        Me.TextBoxEmail.TabIndex = 8
        '
        'TextBoxTelefono
        '
        Me.TextBoxTelefono.Location = New System.Drawing.Point(105, 249)
        Me.TextBoxTelefono.MaxLength = 45
        Me.TextBoxTelefono.Name = "TextBoxTelefono"
        Me.TextBoxTelefono.Size = New System.Drawing.Size(398, 20)
        Me.TextBoxTelefono.TabIndex = 7
        '
        'TextBoxDocumentoNumero
        '
        Me.TextBoxDocumentoNumero.Location = New System.Drawing.Point(383, 301)
        Me.TextBoxDocumentoNumero.MaxLength = 11
        Me.TextBoxDocumentoNumero.Name = "TextBoxDocumentoNumero"
        Me.TextBoxDocumentoNumero.Size = New System.Drawing.Size(119, 20)
        Me.TextBoxDocumentoNumero.TabIndex = 10
        Me.TextBoxDocumentoNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxObservacion
        '
        Me.TextBoxObservacion.Location = New System.Drawing.Point(105, 478)
        Me.TextBoxObservacion.Multiline = True
        Me.TextBoxObservacion.Name = "TextBoxObservacion"
        Me.TextBoxObservacion.Size = New System.Drawing.Size(399, 74)
        Me.TextBoxObservacion.TabIndex = 20
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(43, 189)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Provincia"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(362, 305)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(19, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Nº"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(63, 367)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(32, 13)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Nº IB"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxIngresosBrutos
        '
        Me.TextBoxIngresosBrutos.Location = New System.Drawing.Point(105, 363)
        Me.TextBoxIngresosBrutos.MaxLength = 11
        Me.TextBoxIngresosBrutos.Name = "TextBoxIngresosBrutos"
        Me.TextBoxIngresosBrutos.Size = New System.Drawing.Size(119, 20)
        Me.TextBoxIngresosBrutos.TabIndex = 12
        Me.TextBoxIngresosBrutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(305, 454)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(75, 13)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "Última Compra"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(26, 453)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(74, 13)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "Días Cta. Cte."
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'NumericUpDownIIBB
        '
        Me.NumericUpDownIIBB.DecimalPlaces = 2
        Me.NumericUpDownIIBB.Location = New System.Drawing.Point(299, 363)
        Me.NumericUpDownIIBB.Name = "NumericUpDownIIBB"
        Me.NumericUpDownIIBB.Size = New System.Drawing.Size(66, 20)
        Me.NumericUpDownIIBB.TabIndex = 13
        Me.NumericUpDownIIBB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(246, 365)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 13)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Ret. IB %"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkConvenioMultilateral
        '
        Me.chkConvenioMultilateral.AutoSize = True
        Me.chkConvenioMultilateral.Location = New System.Drawing.Point(379, 365)
        Me.chkConvenioMultilateral.Name = "chkConvenioMultilateral"
        Me.chkConvenioMultilateral.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkConvenioMultilateral.Size = New System.Drawing.Size(124, 17)
        Me.chkConvenioMultilateral.TabIndex = 14
        Me.chkConvenioMultilateral.Text = "Convenio Multilateral"
        Me.chkConvenioMultilateral.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkConvenioMultilateral.UseVisualStyleBackColor = True
        '
        'nudDiasCC
        '
        Me.nudDiasCC.Location = New System.Drawing.Point(105, 451)
        Me.nudDiasCC.Maximum = New Decimal(New Integer() {365, 0, 0, 0})
        Me.nudDiasCC.Name = "nudDiasCC"
        Me.nudDiasCC.Size = New System.Drawing.Size(64, 20)
        Me.nudDiasCC.TabIndex = 18
        Me.nudDiasCC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ComboBoxCondgcias
        '
        Me.ComboBoxCondgcias.FormattingEnabled = True
        Me.ComboBoxCondgcias.Location = New System.Drawing.Point(357, 388)
        Me.ComboBoxCondgcias.Name = "ComboBoxCondgcias"
        Me.ComboBoxCondgcias.Size = New System.Drawing.Size(146, 21)
        Me.ComboBoxCondgcias.TabIndex = 16
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(259, 391)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(89, 13)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Cond. Ganancias"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(30, 422)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(66, 13)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = "Rubro Gcias"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxCodigo
        '
        Me.TextBoxCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCodigo.Location = New System.Drawing.Point(105, 65)
        Me.TextBoxCodigo.MaxLength = 8
        Me.TextBoxCodigo.Name = "TextBoxCodigo"
        Me.TextBoxCodigo.Size = New System.Drawing.Size(90, 20)
        Me.TextBoxCodigo.TabIndex = 1
        Me.TextBoxCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(56, 68)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(40, 13)
        Me.Label19.TabIndex = 26
        Me.Label19.Text = "Código"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFechaUltCpra
        '
        Me.dtpFechaUltCpra.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaUltCpra.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaUltCpra.Location = New System.Drawing.Point(383, 451)
        Me.dtpFechaUltCpra.Name = "dtpFechaUltCpra"
        Me.dtpFechaUltCpra.Size = New System.Drawing.Size(121, 20)
        Me.dtpFechaUltCpra.TabIndex = 19
        '
        'cboRubGcias
        '
        Me.cboRubGcias.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.cboRubGcias.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.cboRubGcias.BusquedaPorCodigobarra = False
        Me.cboRubGcias.ColumnasExtras = Nothing
        Me.cboRubGcias.CustomFormatArt = False
        Me.cboRubGcias.DataSource = Nothing
        Me.cboRubGcias.DisplayMember = Nothing
        Me.cboRubGcias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboRubGcias.FormularioDeAlta = Nothing
        Me.cboRubGcias.FormularioDeBusqueda = Nothing
        Me.cboRubGcias.Location = New System.Drawing.Point(105, 417)
        Me.cboRubGcias.MaximumSize = New System.Drawing.Size(500, 25)
        Me.cboRubGcias.MinimumSize = New System.Drawing.Size(200, 25)
        Me.cboRubGcias.Name = "cboRubGcias"
        Me.cboRubGcias.SelectedIndex = -1
        Me.cboRubGcias.SelectedItem = Nothing
        Me.cboRubGcias.SelectedText = ""
        Me.cboRubGcias.SelectedValue = Nothing
        Me.cboRubGcias.Size = New System.Drawing.Size(397, 25)
        Me.cboRubGcias.TabIndex = 17
        Me.cboRubGcias.ValueMember = Nothing
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
        Me.cboProvincia.Size = New System.Drawing.Size(398, 25)
        Me.cboProvincia.TabIndex = 5
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
        Me.cboLocalidad.Size = New System.Drawing.Size(398, 25)
        Me.cboLocalidad.TabIndex = 6
        Me.cboLocalidad.ValueMember = Nothing
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
        Me.cboTipoDoc.Location = New System.Drawing.Point(105, 301)
        Me.cboTipoDoc.MaximumSize = New System.Drawing.Size(500, 25)
        Me.cboTipoDoc.MinimumSize = New System.Drawing.Size(200, 25)
        Me.cboTipoDoc.Name = "cboTipoDoc"
        Me.cboTipoDoc.SelectedIndex = -1
        Me.cboTipoDoc.SelectedItem = Nothing
        Me.cboTipoDoc.SelectedText = ""
        Me.cboTipoDoc.SelectedValue = Nothing
        Me.cboTipoDoc.Size = New System.Drawing.Size(251, 25)
        Me.cboTipoDoc.TabIndex = 9
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
        Me.cboTipoResp.Location = New System.Drawing.Point(105, 331)
        Me.cboTipoResp.MaximumSize = New System.Drawing.Size(500, 25)
        Me.cboTipoResp.MinimumSize = New System.Drawing.Size(200, 25)
        Me.cboTipoResp.Name = "cboTipoResp"
        Me.cboTipoResp.SelectedIndex = -1
        Me.cboTipoResp.SelectedItem = Nothing
        Me.cboTipoResp.SelectedText = ""
        Me.cboTipoResp.SelectedValue = Nothing
        Me.cboTipoResp.Size = New System.Drawing.Size(398, 25)
        Me.cboTipoResp.TabIndex = 11
        Me.cboTipoResp.ValueMember = Nothing
        '
        'nudRetIva
        '
        Me.nudRetIva.DecimalPlaces = 2
        Me.nudRetIva.Location = New System.Drawing.Point(105, 390)
        Me.nudRetIva.Name = "nudRetIva"
        Me.nudRetIva.Size = New System.Drawing.Size(66, 20)
        Me.nudRetIva.TabIndex = 15
        Me.nudRetIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(45, 392)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 13)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "Ret. IVA %"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FormProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(521, 562)
        Me.Controls.Add(Me.nudRetIva)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.dtpFechaUltCpra)
        Me.Controls.Add(Me.TextBoxCodigo)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.cboRubGcias)
        Me.Controls.Add(Me.cboProvincia)
        Me.Controls.Add(Me.cboLocalidad)
        Me.Controls.Add(Me.cboTipoDoc)
        Me.Controls.Add(Me.cboTipoResp)
        Me.Controls.Add(Me.chkConvenioMultilateral)
        Me.Controls.Add(Me.nudDiasCC)
        Me.Controls.Add(Me.NumericUpDownIIBB)
        Me.Controls.Add(Me.ComboBoxCondgcias)
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
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label12)
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
        Me.Name = "FormProveedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FormProveedor"
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        CType(Me.NumericUpDownIIBB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDiasCC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudRetIva, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextBoxIngresosBrutos As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Private WithEvents NumericUpDownIIBB As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Private WithEvents chkConvenioMultilateral As System.Windows.Forms.CheckBox
    Private WithEvents nudDiasCC As System.Windows.Forms.NumericUpDown
    Friend WithEvents ComboBoxCondgcias As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboProvincia As Principal.CtlCustomCombo
    Friend WithEvents cboLocalidad As Principal.CtlCustomCombo
    Friend WithEvents cboTipoDoc As Principal.CtlCustomCombo
    Friend WithEvents cboTipoResp As Principal.CtlCustomCombo
    Friend WithEvents cboRubGcias As Principal.CtlCustomCombo
    Friend WithEvents TextBoxCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaUltCpra As System.Windows.Forms.DateTimePicker
    Private WithEvents nudRetIva As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
