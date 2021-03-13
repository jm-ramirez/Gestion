<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAnulacionDepositoCartera
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
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnVisualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxImporte = New System.Windows.Forms.TextBox()
        Me.TextBoxObservacion = New System.Windows.Forms.TextBox()
        Me.DtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBoxDeposito = New System.Windows.Forms.GroupBox()
        Me.ComboBoxCtaDeposito = New Principal.CtlCustomCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBoxCptoDeposito = New Principal.CtlCustomCombo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBoxExtraccion = New System.Windows.Forms.GroupBox()
        Me.LabelCheques = New System.Windows.Forms.Label()
        Me.CtlCartera = New Principal.CtlDetalleCbte()
        Me.GroupBoxImporte = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtpEfectivizacion = New System.Windows.Forms.DateTimePicker()
        Me.ComboBoxDeposito = New System.Windows.Forms.ComboBox()
        Me.ToolStripMenu.SuspendLayout()
        Me.GroupBoxDeposito.SuspendLayout()
        Me.GroupBoxExtraccion.SuspendLayout()
        Me.GroupBoxImporte.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnVisualizar, Me.ToolStripSeparator1, Me.BtnGuardar, Me.ToolStripSeparator2, Me.BtnCerrar})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(819, 25)
        Me.ToolStripMenu.TabIndex = 0
        Me.ToolStripMenu.Text = "ToolStrip1"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Image = Global.Principal.My.Resources.Resources.delete
        Me.BtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(129, 22)
        Me.BtnGuardar.Text = "Anular Depósito [Del]"
        Me.BtnGuardar.ToolTipText = "Anular Depósito [Del]"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BtnVisualizar
        '
        Me.BtnVisualizar.Image = Global.Principal.My.Resources.Resources.printer
        Me.BtnVisualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnVisualizar.Name = "BtnVisualizar"
        Me.BtnVisualizar.Size = New System.Drawing.Size(94, 22)
        Me.BtnVisualizar.Text = "Visualizar [F5]"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'BtnCerrar
        '
        Me.BtnCerrar.Image = Global.Principal.My.Resources.Resources.door_out
        Me.BtnCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(74, 22)
        Me.BtnCerrar.Text = "Salir [Esc]"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Importe"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Observación"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxImporte
        '
        Me.TextBoxImporte.Location = New System.Drawing.Point(78, 19)
        Me.TextBoxImporte.Name = "TextBoxImporte"
        Me.TextBoxImporte.ReadOnly = True
        Me.TextBoxImporte.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxImporte.TabIndex = 0
        Me.TextBoxImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBoxObservacion
        '
        Me.TextBoxObservacion.Location = New System.Drawing.Point(78, 45)
        Me.TextBoxObservacion.MaxLength = 255
        Me.TextBoxObservacion.Multiline = True
        Me.TextBoxObservacion.Name = "TextBoxObservacion"
        Me.TextBoxObservacion.Size = New System.Drawing.Size(236, 58)
        Me.TextBoxObservacion.TabIndex = 1
        '
        'DtpFecha
        '
        Me.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFecha.Location = New System.Drawing.Point(123, 41)
        Me.DtpFecha.Name = "DtpFecha"
        Me.DtpFecha.Size = New System.Drawing.Size(100, 20)
        Me.DtpFecha.TabIndex = 0
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
        'GroupBoxDeposito
        '
        Me.GroupBoxDeposito.Controls.Add(Me.ComboBoxCtaDeposito)
        Me.GroupBoxDeposito.Controls.Add(Me.Label6)
        Me.GroupBoxDeposito.Controls.Add(Me.ComboBoxCptoDeposito)
        Me.GroupBoxDeposito.Controls.Add(Me.Label7)
        Me.GroupBoxDeposito.Location = New System.Drawing.Point(12, 67)
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
        Me.ComboBoxCtaDeposito.TabIndex = 0
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
        Me.ComboBoxCptoDeposito.TabIndex = 1
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
        Me.Label8.Location = New System.Drawing.Point(483, 45)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Nro. Depósito"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBoxExtraccion
        '
        Me.GroupBoxExtraccion.Controls.Add(Me.LabelCheques)
        Me.GroupBoxExtraccion.Controls.Add(Me.CtlCartera)
        Me.GroupBoxExtraccion.Location = New System.Drawing.Point(12, 182)
        Me.GroupBoxExtraccion.Name = "GroupBoxExtraccion"
        Me.GroupBoxExtraccion.Size = New System.Drawing.Size(798, 306)
        Me.GroupBoxExtraccion.TabIndex = 5
        Me.GroupBoxExtraccion.TabStop = False
        Me.GroupBoxExtraccion.Text = "Seleccionar los cheques en cartera a depositar"
        '
        'LabelCheques
        '
        Me.LabelCheques.AutoSize = True
        Me.LabelCheques.Location = New System.Drawing.Point(6, 276)
        Me.LabelCheques.Name = "LabelCheques"
        Me.LabelCheques.Size = New System.Drawing.Size(127, 13)
        Me.LabelCheques.TabIndex = 1
        Me.LabelCheques.Text = "* Cheques seleccionados"
        '
        'CtlCartera
        '
        Me.CtlCartera.AgrupaArticulosDetalle = False
        Me.CtlCartera.AnularDepositoNro = 0
        Me.CtlCartera.Cliente = Nothing
        Me.CtlCartera.CompraANoInscripto = False
        Me.CtlCartera.CptoBcoEgrPredetermiando = Nothing
        Me.CtlCartera.CptoBcoIngPredetermiando = Nothing
        Me.CtlCartera.CtaBcoPredeterminada = Nothing
        Me.CtlCartera.DescuentoGral = 0.0R
        Me.CtlCartera.FechaComprobante = New Date(2017, 10, 26, 0, 0, 0, 0)
        Me.CtlCartera.ListaDePrecio = Principal.CtlDetalleCbte.ListaPrecios.LISTA1
        Me.CtlCartera.Location = New System.Drawing.Point(6, 22)
        Me.CtlCartera.MaximoItems = CType(25US, UShort)
        Me.CtlCartera.Name = "CtlCartera"
        Me.CtlCartera.Proveedor = Nothing
        Me.CtlCartera.Size = New System.Drawing.Size(778, 251)
        Me.CtlCartera.TabIndex = 0
        Me.CtlCartera.TipoCargaCbte = Principal.General.TipoEmisionCbte.ELECTRONICO
        Me.CtlCartera.TipoDeCbte = Principal.CtlDetalleCbte.TipoCbte.CBTEVTA
        Me.CtlCartera.Vendedor = Nothing
        Me.CtlCartera.VerCuentaCta = False
        '
        'GroupBoxImporte
        '
        Me.GroupBoxImporte.Controls.Add(Me.TextBoxImporte)
        Me.GroupBoxImporte.Controls.Add(Me.Label2)
        Me.GroupBoxImporte.Controls.Add(Me.Label4)
        Me.GroupBoxImporte.Controls.Add(Me.TextBoxObservacion)
        Me.GroupBoxImporte.Location = New System.Drawing.Point(482, 67)
        Me.GroupBoxImporte.Name = "GroupBoxImporte"
        Me.GroupBoxImporte.Size = New System.Drawing.Size(328, 109)
        Me.GroupBoxImporte.TabIndex = 4
        Me.GroupBoxImporte.TabStop = False
        Me.GroupBoxImporte.Text = "Importe a depositar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(233, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Fecha de efectivización"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DtpEfectivizacion
        '
        Me.DtpEfectivizacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpEfectivizacion.Location = New System.Drawing.Point(359, 41)
        Me.DtpEfectivizacion.Name = "DtpEfectivizacion"
        Me.DtpEfectivizacion.Size = New System.Drawing.Size(100, 20)
        Me.DtpEfectivizacion.TabIndex = 1
        '
        'ComboBoxDeposito
        '
        Me.ComboBoxDeposito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDeposito.FormattingEnabled = True
        Me.ComboBoxDeposito.Location = New System.Drawing.Point(561, 42)
        Me.ComboBoxDeposito.Name = "ComboBoxDeposito"
        Me.ComboBoxDeposito.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxDeposito.TabIndex = 2
        '
        'FormAnulacionDepositoCartera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(819, 500)
        Me.Controls.Add(Me.ComboBoxDeposito)
        Me.Controls.Add(Me.GroupBoxImporte)
        Me.Controls.Add(Me.GroupBoxExtraccion)
        Me.Controls.Add(Me.GroupBoxDeposito)
        Me.Controls.Add(Me.DtpEfectivizacion)
        Me.Controls.Add(Me.DtpFecha)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormAnulacionDepositoCartera"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormArticulo"
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.GroupBoxDeposito.ResumeLayout(False)
        Me.GroupBoxDeposito.PerformLayout()
        Me.GroupBoxExtraccion.ResumeLayout(False)
        Me.GroupBoxExtraccion.PerformLayout()
        Me.GroupBoxImporte.ResumeLayout(False)
        Me.GroupBoxImporte.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxImporte As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxObservacion As System.Windows.Forms.TextBox
    Friend WithEvents DtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxDeposito As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBoxCtaDeposito As Principal.CtlCustomCombo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxCptoDeposito As Principal.CtlCustomCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxExtraccion As System.Windows.Forms.GroupBox
    Friend WithEvents CtlCartera As Principal.CtlDetalleCbte
    Friend WithEvents GroupBoxImporte As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtpEfectivizacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelCheques As System.Windows.Forms.Label
    Private WithEvents ComboBoxDeposito As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnVisualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnCerrar As System.Windows.Forms.ToolStripButton
End Class
