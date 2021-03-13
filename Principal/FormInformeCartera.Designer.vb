<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInformeCartera
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
        Me.BtnReporte = New System.Windows.Forms.ToolStripButton()
        Me.BtnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.DateTimePickerDesde = New System.Windows.Forms.DateTimePicker()
        Me.LabelDesde = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePickerHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBoxComprobantes = New System.Windows.Forms.GroupBox()
        Me.RadioButtonT = New System.Windows.Forms.RadioButton()
        Me.RadioButtonR = New System.Windows.Forms.RadioButton()
        Me.RadioButtonC = New System.Windows.Forms.RadioButton()
        Me.RadioButtonP = New System.Windows.Forms.RadioButton()
        Me.RadioButtonD = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButtonEgreso = New System.Windows.Forms.RadioButton()
        Me.RadioButtonIngreso = New System.Windows.Forms.RadioButton()
        Me.RadioButtonCheque = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CheckBoxCuentas = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CtlComboCuentasBancarias = New Principal.CtlCustomCombo()
        Me.ComboBoxBancoHasta = New Principal.CtlCustomCombo()
        Me.ComboBoxBancoDesde = New Principal.CtlCustomCombo()
        Me.ToolStripMenu.SuspendLayout()
        Me.GroupBoxComprobantes.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnReporte, Me.BtnCancelar})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(595, 25)
        Me.ToolStripMenu.TabIndex = 0
        Me.ToolStripMenu.Text = "ToolStrip1"
        '
        'BtnReporte
        '
        Me.BtnReporte.Image = Global.Principal.My.Resources.Resources.report
        Me.BtnReporte.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnReporte.Name = "BtnReporte"
        Me.BtnReporte.Size = New System.Drawing.Size(137, 22)
        Me.BtnReporte.Text = "Generar Reporte [F12]"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = Global.Principal.My.Resources.Resources.cancel
        Me.BtnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(96, 22)
        Me.BtnCancelar.Text = "Cancelar [Esc]"
        '
        'DateTimePickerDesde
        '
        Me.DateTimePickerDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerDesde.Location = New System.Drawing.Point(154, 60)
        Me.DateTimePickerDesde.Name = "DateTimePickerDesde"
        Me.DateTimePickerDesde.Size = New System.Drawing.Size(142, 20)
        Me.DateTimePickerDesde.TabIndex = 0
        '
        'LabelDesde
        '
        Me.LabelDesde.AutoSize = True
        Me.LabelDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDesde.Location = New System.Drawing.Point(26, 34)
        Me.LabelDesde.Name = "LabelDesde"
        Me.LabelDesde.Size = New System.Drawing.Size(114, 13)
        Me.LabelDesde.TabIndex = 1
        Me.LabelDesde.Text = "Entorno de Fechas"
        Me.LabelDesde.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(103, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Desde"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DateTimePickerHasta
        '
        Me.DateTimePickerHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerHasta.Location = New System.Drawing.Point(154, 86)
        Me.DateTimePickerHasta.Name = "DateTimePickerHasta"
        Me.DateTimePickerHasta.Size = New System.Drawing.Size(142, 20)
        Me.DateTimePickerHasta.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(106, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Hasta"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBoxComprobantes
        '
        Me.GroupBoxComprobantes.Controls.Add(Me.RadioButtonT)
        Me.GroupBoxComprobantes.Controls.Add(Me.RadioButtonR)
        Me.GroupBoxComprobantes.Controls.Add(Me.RadioButtonC)
        Me.GroupBoxComprobantes.Controls.Add(Me.RadioButtonP)
        Me.GroupBoxComprobantes.Controls.Add(Me.RadioButtonD)
        Me.GroupBoxComprobantes.Location = New System.Drawing.Point(13, 123)
        Me.GroupBoxComprobantes.Name = "GroupBoxComprobantes"
        Me.GroupBoxComprobantes.Size = New System.Drawing.Size(516, 45)
        Me.GroupBoxComprobantes.TabIndex = 5
        Me.GroupBoxComprobantes.TabStop = False
        Me.GroupBoxComprobantes.Text = "Estados de Cartera: "
        '
        'RadioButtonT
        '
        Me.RadioButtonT.AutoSize = True
        Me.RadioButtonT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonT.Location = New System.Drawing.Point(414, 18)
        Me.RadioButtonT.Name = "RadioButtonT"
        Me.RadioButtonT.Size = New System.Drawing.Size(55, 17)
        Me.RadioButtonT.TabIndex = 9
        Me.RadioButtonT.Text = "Todos"
        Me.RadioButtonT.UseVisualStyleBackColor = True
        '
        'RadioButtonR
        '
        Me.RadioButtonR.AutoSize = True
        Me.RadioButtonR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonR.Location = New System.Drawing.Point(310, 18)
        Me.RadioButtonR.Name = "RadioButtonR"
        Me.RadioButtonR.Size = New System.Drawing.Size(85, 17)
        Me.RadioButtonR.TabIndex = 8
        Me.RadioButtonR.Text = "Rechazados"
        Me.RadioButtonR.UseVisualStyleBackColor = True
        '
        'RadioButtonC
        '
        Me.RadioButtonC.AutoSize = True
        Me.RadioButtonC.Checked = True
        Me.RadioButtonC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonC.Location = New System.Drawing.Point(32, 18)
        Me.RadioButtonC.Name = "RadioButtonC"
        Me.RadioButtonC.Size = New System.Drawing.Size(74, 17)
        Me.RadioButtonC.TabIndex = 5
        Me.RadioButtonC.TabStop = True
        Me.RadioButtonC.Text = "En cartera"
        Me.RadioButtonC.UseVisualStyleBackColor = True
        '
        'RadioButtonP
        '
        Me.RadioButtonP.AutoSize = True
        Me.RadioButtonP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonP.Location = New System.Drawing.Point(126, 18)
        Me.RadioButtonP.Name = "RadioButtonP"
        Me.RadioButtonP.Size = New System.Drawing.Size(66, 17)
        Me.RadioButtonP.TabIndex = 6
        Me.RadioButtonP.Text = "Pasados"
        Me.RadioButtonP.UseVisualStyleBackColor = True
        '
        'RadioButtonD
        '
        Me.RadioButtonD.AutoSize = True
        Me.RadioButtonD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonD.Location = New System.Drawing.Point(210, 18)
        Me.RadioButtonD.Name = "RadioButtonD"
        Me.RadioButtonD.Size = New System.Drawing.Size(84, 17)
        Me.RadioButtonD.TabIndex = 7
        Me.RadioButtonD.Text = "Depositados"
        Me.RadioButtonD.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButtonEgreso)
        Me.GroupBox1.Controls.Add(Me.RadioButtonIngreso)
        Me.GroupBox1.Controls.Add(Me.RadioButtonCheque)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(337, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(192, 83)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo de Fecha: "
        '
        'RadioButtonEgreso
        '
        Me.RadioButtonEgreso.AutoSize = True
        Me.RadioButtonEgreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonEgreso.Location = New System.Drawing.Point(27, 58)
        Me.RadioButtonEgreso.Name = "RadioButtonEgreso"
        Me.RadioButtonEgreso.Size = New System.Drawing.Size(124, 17)
        Me.RadioButtonEgreso.TabIndex = 4
        Me.RadioButtonEgreso.Text = "Fecha de Egreso"
        Me.RadioButtonEgreso.UseVisualStyleBackColor = True
        '
        'RadioButtonIngreso
        '
        Me.RadioButtonIngreso.AutoSize = True
        Me.RadioButtonIngreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonIngreso.Location = New System.Drawing.Point(27, 37)
        Me.RadioButtonIngreso.Name = "RadioButtonIngreso"
        Me.RadioButtonIngreso.Size = New System.Drawing.Size(126, 17)
        Me.RadioButtonIngreso.TabIndex = 3
        Me.RadioButtonIngreso.Text = "Fecha de Ingreso"
        Me.RadioButtonIngreso.UseVisualStyleBackColor = True
        '
        'RadioButtonCheque
        '
        Me.RadioButtonCheque.AutoSize = True
        Me.RadioButtonCheque.Checked = True
        Me.RadioButtonCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonCheque.Location = New System.Drawing.Point(27, 18)
        Me.RadioButtonCheque.Name = "RadioButtonCheque"
        Me.RadioButtonCheque.Size = New System.Drawing.Size(131, 17)
        Me.RadioButtonCheque.TabIndex = 2
        Me.RadioButtonCheque.TabStop = True
        Me.RadioButtonCheque.Text = "Fecha del Cheque"
        Me.RadioButtonCheque.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(26, 175)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Destino Depósito"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(26, 256)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Entorno de Bancos"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(106, 315)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Hasta"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(103, 285)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Desde"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CheckBoxCuentas
        '
        Me.CheckBoxCuentas.Checked = True
        Me.CheckBoxCuentas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxCuentas.Enabled = False
        Me.CheckBoxCuentas.Location = New System.Drawing.Point(13, 195)
        Me.CheckBoxCuentas.Name = "CheckBoxCuentas"
        Me.CheckBoxCuentas.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBoxCuentas.Size = New System.Drawing.Size(146, 17)
        Me.CheckBoxCuentas.TabIndex = 10
        Me.CheckBoxCuentas.Text = "Todos"
        Me.CheckBoxCuentas.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(45, 225)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 13)
        Me.Label8.TabIndex = 73
        Me.Label8.Text = "Uno Determinado"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CtlComboCuentasBancarias
        '
        Me.CtlComboCuentasBancarias.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlComboCuentasBancarias.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlComboCuentasBancarias.BusquedaPorCodigobarra = False
        Me.CtlComboCuentasBancarias.ColumnasExtras = Nothing
        Me.CtlComboCuentasBancarias.CustomFormatArt = False
        Me.CtlComboCuentasBancarias.DataSource = Nothing
        Me.CtlComboCuentasBancarias.DisplayMember = Nothing
        Me.CtlComboCuentasBancarias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CtlComboCuentasBancarias.Enabled = False
        Me.CtlComboCuentasBancarias.FormularioDeAlta = Nothing
        Me.CtlComboCuentasBancarias.FormularioDeBusqueda = Nothing
        Me.CtlComboCuentasBancarias.Location = New System.Drawing.Point(154, 219)
        Me.CtlComboCuentasBancarias.MaximumSize = New System.Drawing.Size(583, 25)
        Me.CtlComboCuentasBancarias.MinimumSize = New System.Drawing.Size(233, 25)
        Me.CtlComboCuentasBancarias.Name = "CtlComboCuentasBancarias"
        Me.CtlComboCuentasBancarias.SelectedIndex = -1
        Me.CtlComboCuentasBancarias.SelectedItem = Nothing
        Me.CtlComboCuentasBancarias.SelectedText = ""
        Me.CtlComboCuentasBancarias.SelectedValue = Nothing
        Me.CtlComboCuentasBancarias.Size = New System.Drawing.Size(415, 25)
        Me.CtlComboCuentasBancarias.TabIndex = 11
        Me.CtlComboCuentasBancarias.ValueMember = Nothing
        '
        'ComboBoxBancoHasta
        '
        Me.ComboBoxBancoHasta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.ComboBoxBancoHasta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.ComboBoxBancoHasta.BusquedaPorCodigobarra = False
        Me.ComboBoxBancoHasta.ColumnasExtras = Nothing
        Me.ComboBoxBancoHasta.CustomFormatArt = False
        Me.ComboBoxBancoHasta.DataSource = Nothing
        Me.ComboBoxBancoHasta.DisplayMember = Nothing
        Me.ComboBoxBancoHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ComboBoxBancoHasta.FormularioDeAlta = Nothing
        Me.ComboBoxBancoHasta.FormularioDeBusqueda = Nothing
        Me.ComboBoxBancoHasta.Location = New System.Drawing.Point(154, 310)
        Me.ComboBoxBancoHasta.MaximumSize = New System.Drawing.Size(583, 25)
        Me.ComboBoxBancoHasta.MinimumSize = New System.Drawing.Size(233, 25)
        Me.ComboBoxBancoHasta.Name = "ComboBoxBancoHasta"
        Me.ComboBoxBancoHasta.SelectedIndex = -1
        Me.ComboBoxBancoHasta.SelectedItem = Nothing
        Me.ComboBoxBancoHasta.SelectedText = ""
        Me.ComboBoxBancoHasta.SelectedValue = Nothing
        Me.ComboBoxBancoHasta.Size = New System.Drawing.Size(415, 25)
        Me.ComboBoxBancoHasta.TabIndex = 13
        Me.ComboBoxBancoHasta.ValueMember = Nothing
        '
        'ComboBoxBancoDesde
        '
        Me.ComboBoxBancoDesde.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.ComboBoxBancoDesde.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.ComboBoxBancoDesde.BusquedaPorCodigobarra = False
        Me.ComboBoxBancoDesde.ColumnasExtras = Nothing
        Me.ComboBoxBancoDesde.CustomFormatArt = False
        Me.ComboBoxBancoDesde.DataSource = Nothing
        Me.ComboBoxBancoDesde.DisplayMember = Nothing
        Me.ComboBoxBancoDesde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ComboBoxBancoDesde.FormularioDeAlta = Nothing
        Me.ComboBoxBancoDesde.FormularioDeBusqueda = Nothing
        Me.ComboBoxBancoDesde.Location = New System.Drawing.Point(154, 279)
        Me.ComboBoxBancoDesde.MaximumSize = New System.Drawing.Size(583, 25)
        Me.ComboBoxBancoDesde.MinimumSize = New System.Drawing.Size(233, 25)
        Me.ComboBoxBancoDesde.Name = "ComboBoxBancoDesde"
        Me.ComboBoxBancoDesde.SelectedIndex = -1
        Me.ComboBoxBancoDesde.SelectedItem = Nothing
        Me.ComboBoxBancoDesde.SelectedText = ""
        Me.ComboBoxBancoDesde.SelectedValue = Nothing
        Me.ComboBoxBancoDesde.Size = New System.Drawing.Size(415, 25)
        Me.ComboBoxBancoDesde.TabIndex = 12
        Me.ComboBoxBancoDesde.ValueMember = Nothing
        '
        'FormInformeCartera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(595, 344)
        Me.Controls.Add(Me.CheckBoxCuentas)
        Me.Controls.Add(Me.CtlComboCuentasBancarias)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ComboBoxBancoHasta)
        Me.Controls.Add(Me.ComboBoxBancoDesde)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBoxComprobantes)
        Me.Controls.Add(Me.DateTimePickerHasta)
        Me.Controls.Add(Me.DateTimePickerDesde)
        Me.Controls.Add(Me.LabelDesde)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormInformeCartera"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormArticulo"
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.GroupBoxComprobantes.ResumeLayout(False)
        Me.GroupBoxComprobantes.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnReporte As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents DateTimePickerDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelDesde As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxComprobantes As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButtonT As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonP As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonD As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonR As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonC As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButtonEgreso As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonIngreso As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonCheque As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxBancoDesde As Principal.CtlCustomCombo
    Friend WithEvents ComboBoxBancoHasta As Principal.CtlCustomCombo
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxCuentas As System.Windows.Forms.CheckBox
    Friend WithEvents CtlComboCuentasBancarias As Principal.CtlCustomCombo
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
