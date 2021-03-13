<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMovimientoEntreCtas
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxObservacion = New System.Windows.Forms.TextBox()
        Me.ComboBoxCtaExtraccion = New Principal.CtlCustomCombo()
        Me.ComboBoxCptoExtraccion = New Principal.CtlCustomCombo()
        Me.DtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBoxExtraccion = New System.Windows.Forms.GroupBox()
        Me.GroupBoxDeposito = New System.Windows.Forms.GroupBox()
        Me.ComboBoxCtaDeposito = New Principal.CtlCustomCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBoxCptoDeposito = New Principal.CtlCustomCombo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBoxReferencia = New System.Windows.Forms.TextBox()
        Me.TextBoxNumero = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.nudImporte = New System.Windows.Forms.NumericUpDown()
        Me.ToolStripMenu.SuspendLayout()
        Me.GroupBoxExtraccion.SuspendLayout()
        Me.GroupBoxDeposito.SuspendLayout()
        CType(Me.nudImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnGuardar, Me.BtnCancelar})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(488, 25)
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(76, 329)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Importe"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(51, 355)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Observación"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxObservacion
        '
        Me.TextBoxObservacion.Location = New System.Drawing.Point(124, 352)
        Me.TextBoxObservacion.MaxLength = 255
        Me.TextBoxObservacion.Multiline = True
        Me.TextBoxObservacion.Name = "TextBoxObservacion"
        Me.TextBoxObservacion.Size = New System.Drawing.Size(300, 60)
        Me.TextBoxObservacion.TabIndex = 7
        '
        'ComboBoxCtaExtraccion
        '
        Me.ComboBoxCtaExtraccion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.ComboBoxCtaExtraccion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.ComboBoxCtaExtraccion.BusquedaPorCodigobarra = False
        Me.ComboBoxCtaExtraccion.ColumnasExtras = Nothing
        Me.ComboBoxCtaExtraccion.CustomFormatArt = False
        Me.ComboBoxCtaExtraccion.DataSource = Nothing
        Me.ComboBoxCtaExtraccion.DisplayMember = Nothing
        Me.ComboBoxCtaExtraccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ComboBoxCtaExtraccion.FormularioDeAlta = Nothing
        Me.ComboBoxCtaExtraccion.FormularioDeBusqueda = Nothing
        Me.ComboBoxCtaExtraccion.Location = New System.Drawing.Point(112, 25)
        Me.ComboBoxCtaExtraccion.MaximumSize = New System.Drawing.Size(500, 25)
        Me.ComboBoxCtaExtraccion.MinimumSize = New System.Drawing.Size(200, 25)
        Me.ComboBoxCtaExtraccion.Name = "ComboBoxCtaExtraccion"
        Me.ComboBoxCtaExtraccion.SelectedIndex = -1
        Me.ComboBoxCtaExtraccion.SelectedItem = Nothing
        Me.ComboBoxCtaExtraccion.SelectedText = ""
        Me.ComboBoxCtaExtraccion.SelectedValue = Nothing
        Me.ComboBoxCtaExtraccion.Size = New System.Drawing.Size(300, 25)
        Me.ComboBoxCtaExtraccion.TabIndex = 1
        Me.ComboBoxCtaExtraccion.ValueMember = Nothing
        '
        'ComboBoxCptoExtraccion
        '
        Me.ComboBoxCptoExtraccion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.ComboBoxCptoExtraccion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.ComboBoxCptoExtraccion.BusquedaPorCodigobarra = False
        Me.ComboBoxCptoExtraccion.ColumnasExtras = Nothing
        Me.ComboBoxCptoExtraccion.CustomFormatArt = False
        Me.ComboBoxCptoExtraccion.DataSource = Nothing
        Me.ComboBoxCptoExtraccion.DisplayMember = Nothing
        Me.ComboBoxCptoExtraccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ComboBoxCptoExtraccion.FormularioDeAlta = Nothing
        Me.ComboBoxCptoExtraccion.FormularioDeBusqueda = Nothing
        Me.ComboBoxCptoExtraccion.Location = New System.Drawing.Point(111, 56)
        Me.ComboBoxCptoExtraccion.MaximumSize = New System.Drawing.Size(500, 25)
        Me.ComboBoxCptoExtraccion.MinimumSize = New System.Drawing.Size(200, 25)
        Me.ComboBoxCptoExtraccion.Name = "ComboBoxCptoExtraccion"
        Me.ComboBoxCptoExtraccion.SelectedIndex = -1
        Me.ComboBoxCptoExtraccion.SelectedItem = Nothing
        Me.ComboBoxCptoExtraccion.SelectedText = ""
        Me.ComboBoxCptoExtraccion.SelectedValue = Nothing
        Me.ComboBoxCptoExtraccion.Size = New System.Drawing.Size(300, 25)
        Me.ComboBoxCptoExtraccion.TabIndex = 2
        Me.ComboBoxCptoExtraccion.ValueMember = Nothing
        '
        'DtpFecha
        '
        Me.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFecha.Location = New System.Drawing.Point(123, 41)
        Me.DtpFecha.Name = "DtpFecha"
        Me.DtpFecha.Size = New System.Drawing.Size(100, 20)
        Me.DtpFecha.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(53, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Concepto"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(65, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Cuenta"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Fecha de transacción"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBoxExtraccion
        '
        Me.GroupBoxExtraccion.Controls.Add(Me.ComboBoxCtaExtraccion)
        Me.GroupBoxExtraccion.Controls.Add(Me.Label1)
        Me.GroupBoxExtraccion.Controls.Add(Me.ComboBoxCptoExtraccion)
        Me.GroupBoxExtraccion.Controls.Add(Me.Label3)
        Me.GroupBoxExtraccion.Location = New System.Drawing.Point(12, 67)
        Me.GroupBoxExtraccion.Name = "GroupBoxExtraccion"
        Me.GroupBoxExtraccion.Size = New System.Drawing.Size(464, 106)
        Me.GroupBoxExtraccion.TabIndex = 2
        Me.GroupBoxExtraccion.TabStop = False
        Me.GroupBoxExtraccion.Text = "Seleccionar cuenta y concepto de extracción"
        '
        'GroupBoxDeposito
        '
        Me.GroupBoxDeposito.Controls.Add(Me.ComboBoxCtaDeposito)
        Me.GroupBoxDeposito.Controls.Add(Me.Label6)
        Me.GroupBoxDeposito.Controls.Add(Me.ComboBoxCptoDeposito)
        Me.GroupBoxDeposito.Controls.Add(Me.Label7)
        Me.GroupBoxDeposito.Location = New System.Drawing.Point(12, 179)
        Me.GroupBoxDeposito.Name = "GroupBoxDeposito"
        Me.GroupBoxDeposito.Size = New System.Drawing.Size(464, 109)
        Me.GroupBoxDeposito.TabIndex = 3
        Me.GroupBoxDeposito.TabStop = False
        Me.GroupBoxDeposito.Text = "Seleccionar cuenta y concepto de depósito"
        '
        'ComboBoxCtaDeposito
        '
        Me.ComboBoxCtaDeposito.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.ComboBoxCtaDeposito.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.ComboBoxCtaDeposito.BusquedaPorCodigobarra = False
        Me.ComboBoxCtaDeposito.ColumnasExtras = Nothing
        Me.ComboBoxCtaDeposito.CustomFormatArt = False
        Me.ComboBoxCtaDeposito.DataSource = Nothing
        Me.ComboBoxCtaDeposito.DisplayMember = Nothing
        Me.ComboBoxCtaDeposito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ComboBoxCtaDeposito.FormularioDeAlta = Nothing
        Me.ComboBoxCtaDeposito.FormularioDeBusqueda = Nothing
        Me.ComboBoxCtaDeposito.Location = New System.Drawing.Point(112, 25)
        Me.ComboBoxCtaDeposito.MaximumSize = New System.Drawing.Size(500, 25)
        Me.ComboBoxCtaDeposito.MinimumSize = New System.Drawing.Size(200, 25)
        Me.ComboBoxCtaDeposito.Name = "ComboBoxCtaDeposito"
        Me.ComboBoxCtaDeposito.SelectedIndex = -1
        Me.ComboBoxCtaDeposito.SelectedItem = Nothing
        Me.ComboBoxCtaDeposito.SelectedText = ""
        Me.ComboBoxCtaDeposito.SelectedValue = Nothing
        Me.ComboBoxCtaDeposito.Size = New System.Drawing.Size(300, 25)
        Me.ComboBoxCtaDeposito.TabIndex = 3
        Me.ComboBoxCtaDeposito.ValueMember = Nothing
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(53, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Concepto"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboBoxCptoDeposito
        '
        Me.ComboBoxCptoDeposito.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.ComboBoxCptoDeposito.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.ComboBoxCptoDeposito.BusquedaPorCodigobarra = False
        Me.ComboBoxCptoDeposito.ColumnasExtras = Nothing
        Me.ComboBoxCptoDeposito.CustomFormatArt = False
        Me.ComboBoxCptoDeposito.DataSource = Nothing
        Me.ComboBoxCptoDeposito.DisplayMember = Nothing
        Me.ComboBoxCptoDeposito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ComboBoxCptoDeposito.FormularioDeAlta = Nothing
        Me.ComboBoxCptoDeposito.FormularioDeBusqueda = Nothing
        Me.ComboBoxCptoDeposito.Location = New System.Drawing.Point(111, 56)
        Me.ComboBoxCptoDeposito.MaximumSize = New System.Drawing.Size(500, 25)
        Me.ComboBoxCptoDeposito.MinimumSize = New System.Drawing.Size(200, 25)
        Me.ComboBoxCptoDeposito.Name = "ComboBoxCptoDeposito"
        Me.ComboBoxCptoDeposito.SelectedIndex = -1
        Me.ComboBoxCptoDeposito.SelectedItem = Nothing
        Me.ComboBoxCptoDeposito.SelectedText = ""
        Me.ComboBoxCptoDeposito.SelectedValue = Nothing
        Me.ComboBoxCptoDeposito.Size = New System.Drawing.Size(300, 25)
        Me.ComboBoxCptoDeposito.TabIndex = 4
        Me.ComboBoxCptoDeposito.ValueMember = Nothing
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(65, 31)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Cuenta"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(59, 300)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Referencia"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxReferencia
        '
        Me.TextBoxReferencia.Location = New System.Drawing.Point(124, 297)
        Me.TextBoxReferencia.MaxLength = 15
        Me.TextBoxReferencia.Name = "TextBoxReferencia"
        Me.TextBoxReferencia.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxReferencia.TabIndex = 5
        Me.TextBoxReferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBoxNumero
        '
        Me.TextBoxNumero.Location = New System.Drawing.Point(323, 41)
        Me.TextBoxNumero.MaxLength = 15
        Me.TextBoxNumero.Name = "TextBoxNumero"
        Me.TextBoxNumero.ReadOnly = True
        Me.TextBoxNumero.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxNumero.TabIndex = 8
        Me.TextBoxNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(235, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Nro. Movimiento"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudImporte
        '
        Me.nudImporte.DecimalPlaces = 2
        Me.nudImporte.Location = New System.Drawing.Point(124, 324)
        Me.nudImporte.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.nudImporte.Name = "nudImporte"
        Me.nudImporte.Size = New System.Drawing.Size(100, 20)
        Me.nudImporte.TabIndex = 6
        Me.nudImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudImporte.ThousandsSeparator = True
        Me.nudImporte.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'FormMovimientoEntreCtas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(488, 431)
        Me.Controls.Add(Me.nudImporte)
        Me.Controls.Add(Me.TextBoxNumero)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBoxDeposito)
        Me.Controls.Add(Me.GroupBoxExtraccion)
        Me.Controls.Add(Me.DtpFecha)
        Me.Controls.Add(Me.TextBoxObservacion)
        Me.Controls.Add(Me.TextBoxReferencia)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormMovimientoEntreCtas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormArticulo"
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.GroupBoxExtraccion.ResumeLayout(False)
        Me.GroupBoxExtraccion.PerformLayout()
        Me.GroupBoxDeposito.ResumeLayout(False)
        Me.GroupBoxDeposito.PerformLayout()
        CType(Me.nudImporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxObservacion As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxCtaExtraccion As Principal.CtlCustomCombo
    Friend WithEvents ComboBoxCptoExtraccion As Principal.CtlCustomCombo
    Friend WithEvents DtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxExtraccion As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBoxDeposito As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBoxCtaDeposito As Principal.CtlCustomCombo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxCptoDeposito As Principal.CtlCustomCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBoxReferencia As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents nudImporte As System.Windows.Forms.NumericUpDown
End Class
