<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormVendedor
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBoxDomicilio = New System.Windows.Forms.TextBox()
        Me.TextBoxTelefono = New System.Windows.Forms.TextBox()
        Me.TextBoxEmail = New System.Windows.Forms.TextBox()
        Me.TextBoxNombre = New System.Windows.Forms.TextBox()
        Me.TextBoxId = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBoxObservacion = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.NumericUpDownComision = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBoxDocumentoNumero = New System.Windows.Forms.TextBox()
        Me.cboProvincia = New Principal.CtlCustomCombo()
        Me.cboLocalidad = New Principal.CtlCustomCombo()
        Me.cboTipoDoc = New Principal.CtlCustomCombo()
        Me.cboTipoResp = New Principal.CtlCustomCombo()
        Me.cboZonas = New Principal.CtlCustomCombo()
        Me.ToolStripMenu.SuspendLayout()
        CType(Me.NumericUpDownComision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnGuardar, Me.BtnCancelar})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(497, 25)
        Me.ToolStripMenu.TabIndex = 0
        Me.ToolStripMenu.Text = "ToolStrip1"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Image = Global.Principal.My.Resources.Resources.disk
        Me.BtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(98, 22)
        Me.BtnGuardar.Text = "Guardar [F12]"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = Global.Principal.My.Resources.Resources.cancel
        Me.BtnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(101, 22)
        Me.BtnCancelar.Text = "Cancelar [Esc]"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(61, 344)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 13)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Zona"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxDomicilio
        '
        Me.TextBoxDomicilio.Location = New System.Drawing.Point(102, 88)
        Me.TextBoxDomicilio.MaxLength = 255
        Me.TextBoxDomicilio.Multiline = True
        Me.TextBoxDomicilio.Name = "TextBoxDomicilio"
        Me.TextBoxDomicilio.Size = New System.Drawing.Size(371, 60)
        Me.TextBoxDomicilio.TabIndex = 2
        '
        'TextBoxTelefono
        '
        Me.TextBoxTelefono.Location = New System.Drawing.Point(102, 221)
        Me.TextBoxTelefono.MaxLength = 45
        Me.TextBoxTelefono.Name = "TextBoxTelefono"
        Me.TextBoxTelefono.Size = New System.Drawing.Size(371, 20)
        Me.TextBoxTelefono.TabIndex = 5
        '
        'TextBoxEmail
        '
        Me.TextBoxEmail.Location = New System.Drawing.Point(102, 247)
        Me.TextBoxEmail.MaxLength = 100
        Me.TextBoxEmail.Name = "TextBoxEmail"
        Me.TextBoxEmail.Size = New System.Drawing.Size(371, 20)
        Me.TextBoxEmail.TabIndex = 6
        '
        'TextBoxNombre
        '
        Me.TextBoxNombre.Location = New System.Drawing.Point(102, 62)
        Me.TextBoxNombre.MaxLength = 80
        Me.TextBoxNombre.Name = "TextBoxNombre"
        Me.TextBoxNombre.Size = New System.Drawing.Size(371, 20)
        Me.TextBoxNombre.TabIndex = 1
        '
        'TextBoxId
        '
        Me.TextBoxId.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxId.Location = New System.Drawing.Point(102, 36)
        Me.TextBoxId.MaxLength = 10
        Me.TextBoxId.Name = "TextBoxId"
        Me.TextBoxId.Size = New System.Drawing.Size(63, 20)
        Me.TextBoxId.TabIndex = 0
        Me.TextBoxId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 163)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Provincia"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(41, 193)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Localidad"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 316)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Condición Fiscal"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(33, 284)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Documento"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(61, 250)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Email"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(44, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Domicilio"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(45, 224)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 13)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "Teléfono"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(49, 65)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 13)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "Nombre"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(77, 39)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(16, 13)
        Me.Label13.TabIndex = 32
        Me.Label13.Text = "Id"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxObservacion
        '
        Me.TextBoxObservacion.Location = New System.Drawing.Point(102, 395)
        Me.TextBoxObservacion.Multiline = True
        Me.TextBoxObservacion.Name = "TextBoxObservacion"
        Me.TextBoxObservacion.Size = New System.Drawing.Size(371, 74)
        Me.TextBoxObservacion.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(29, 398)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 13)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "Observación"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(357, 279)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(19, 13)
        Me.Label15.TabIndex = 44
        Me.Label15.Text = "Nº"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'NumericUpDownComision
        '
        Me.NumericUpDownComision.DecimalPlaces = 2
        Me.NumericUpDownComision.Location = New System.Drawing.Point(102, 369)
        Me.NumericUpDownComision.Name = "NumericUpDownComision"
        Me.NumericUpDownComision.Size = New System.Drawing.Size(102, 20)
        Me.NumericUpDownComision.TabIndex = 13
        Me.NumericUpDownComision.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(33, 371)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 13)
        Me.Label8.TabIndex = 45
        Me.Label8.Text = "% Comisión"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxDocumentoNumero
        '
        Me.TextBoxDocumentoNumero.Location = New System.Drawing.Point(380, 277)
        Me.TextBoxDocumentoNumero.MaxLength = 11
        Me.TextBoxDocumentoNumero.Name = "TextBoxDocumentoNumero"
        Me.TextBoxDocumentoNumero.Size = New System.Drawing.Size(92, 20)
        Me.TextBoxDocumentoNumero.TabIndex = 8
        Me.TextBoxDocumentoNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.cboProvincia.Location = New System.Drawing.Point(102, 154)
        Me.cboProvincia.MaximumSize = New System.Drawing.Size(500, 25)
        Me.cboProvincia.MinimumSize = New System.Drawing.Size(200, 25)
        Me.cboProvincia.Name = "cboProvincia"
        Me.cboProvincia.SelectedIndex = -1
        Me.cboProvincia.SelectedItem = Nothing
        Me.cboProvincia.SelectedText = ""
        Me.cboProvincia.SelectedValue = Nothing
        Me.cboProvincia.Size = New System.Drawing.Size(371, 25)
        Me.cboProvincia.TabIndex = 3
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
        Me.cboLocalidad.Location = New System.Drawing.Point(102, 187)
        Me.cboLocalidad.MaximumSize = New System.Drawing.Size(500, 25)
        Me.cboLocalidad.MinimumSize = New System.Drawing.Size(200, 25)
        Me.cboLocalidad.Name = "cboLocalidad"
        Me.cboLocalidad.SelectedIndex = -1
        Me.cboLocalidad.SelectedItem = Nothing
        Me.cboLocalidad.SelectedText = ""
        Me.cboLocalidad.SelectedValue = Nothing
        Me.cboLocalidad.Size = New System.Drawing.Size(371, 25)
        Me.cboLocalidad.TabIndex = 4
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
        Me.cboTipoDoc.Location = New System.Drawing.Point(103, 276)
        Me.cboTipoDoc.MaximumSize = New System.Drawing.Size(500, 25)
        Me.cboTipoDoc.MinimumSize = New System.Drawing.Size(200, 25)
        Me.cboTipoDoc.Name = "cboTipoDoc"
        Me.cboTipoDoc.SelectedIndex = -1
        Me.cboTipoDoc.SelectedItem = Nothing
        Me.cboTipoDoc.SelectedText = ""
        Me.cboTipoDoc.SelectedValue = Nothing
        Me.cboTipoDoc.Size = New System.Drawing.Size(251, 25)
        Me.cboTipoDoc.TabIndex = 7
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
        Me.cboTipoResp.Location = New System.Drawing.Point(102, 307)
        Me.cboTipoResp.MaximumSize = New System.Drawing.Size(500, 25)
        Me.cboTipoResp.MinimumSize = New System.Drawing.Size(200, 25)
        Me.cboTipoResp.Name = "cboTipoResp"
        Me.cboTipoResp.SelectedIndex = -1
        Me.cboTipoResp.SelectedItem = Nothing
        Me.cboTipoResp.SelectedText = ""
        Me.cboTipoResp.SelectedValue = Nothing
        Me.cboTipoResp.Size = New System.Drawing.Size(371, 25)
        Me.cboTipoResp.TabIndex = 9
        Me.cboTipoResp.ValueMember = Nothing
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
        Me.cboZonas.Location = New System.Drawing.Point(102, 338)
        Me.cboZonas.MaximumSize = New System.Drawing.Size(500, 25)
        Me.cboZonas.MinimumSize = New System.Drawing.Size(200, 25)
        Me.cboZonas.Name = "cboZonas"
        Me.cboZonas.SelectedIndex = -1
        Me.cboZonas.SelectedItem = Nothing
        Me.cboZonas.SelectedText = ""
        Me.cboZonas.SelectedValue = Nothing
        Me.cboZonas.Size = New System.Drawing.Size(371, 25)
        Me.cboZonas.TabIndex = 10
        Me.cboZonas.ValueMember = Nothing
        '
        'FormVendedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(497, 497)
        Me.Controls.Add(Me.cboProvincia)
        Me.Controls.Add(Me.cboLocalidad)
        Me.Controls.Add(Me.cboTipoDoc)
        Me.Controls.Add(Me.cboTipoResp)
        Me.Controls.Add(Me.TextBoxDocumentoNumero)
        Me.Controls.Add(Me.NumericUpDownComision)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TextBoxObservacion)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TextBoxDomicilio)
        Me.Controls.Add(Me.TextBoxTelefono)
        Me.Controls.Add(Me.TextBoxEmail)
        Me.Controls.Add(Me.TextBoxNombre)
        Me.Controls.Add(Me.TextBoxId)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cboZonas)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormVendedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FormVendedor"
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        CType(Me.NumericUpDownComision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents cboZonas As Principal.CtlCustomCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBoxDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxTelefono As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxEmail As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNombre As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxId As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextBoxObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Private WithEvents NumericUpDownComision As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBoxDocumentoNumero As System.Windows.Forms.TextBox
    Friend WithEvents cboTipoResp As Principal.CtlCustomCombo
    Friend WithEvents cboTipoDoc As Principal.CtlCustomCombo
    Friend WithEvents cboLocalidad As Principal.CtlCustomCombo
    Friend WithEvents cboProvincia As Principal.CtlCustomCombo
End Class
