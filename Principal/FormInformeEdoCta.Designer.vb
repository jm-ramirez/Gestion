<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInformeEdoCta
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateTimePickerEmision = New System.Windows.Forms.DateTimePicker()
        Me.CheckBoxCuentas = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CheckBoxConceptos = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CtlComboConceptos = New Principal.CtlCustomCombo()
        Me.CtlComboCuentas = New Principal.CtlCustomCombo()
        Me.ToolStripMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnReporte, Me.BtnCancelar})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(485, 25)
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
        Me.DateTimePickerDesde.Location = New System.Drawing.Point(139, 60)
        Me.DateTimePickerDesde.Name = "DateTimePickerDesde"
        Me.DateTimePickerDesde.Size = New System.Drawing.Size(122, 20)
        Me.DateTimePickerDesde.TabIndex = 0
        '
        'LabelDesde
        '
        Me.LabelDesde.AutoSize = True
        Me.LabelDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDesde.Location = New System.Drawing.Point(77, 34)
        Me.LabelDesde.Name = "LabelDesde"
        Me.LabelDesde.Size = New System.Drawing.Size(216, 13)
        Me.LabelDesde.TabIndex = 1
        Me.LabelDesde.Text = "Entorno de Fechas de Efectivización"
        Me.LabelDesde.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(95, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Desde"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DateTimePickerHasta
        '
        Me.DateTimePickerHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerHasta.Location = New System.Drawing.Point(139, 86)
        Me.DateTimePickerHasta.Name = "DateTimePickerHasta"
        Me.DateTimePickerHasta.Size = New System.Drawing.Size(122, 20)
        Me.DateTimePickerHasta.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(98, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Hasta"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(292, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Emisión"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DateTimePickerEmision
        '
        Me.DateTimePickerEmision.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerEmision.Location = New System.Drawing.Point(341, 57)
        Me.DateTimePickerEmision.Name = "DateTimePickerEmision"
        Me.DateTimePickerEmision.Size = New System.Drawing.Size(122, 20)
        Me.DateTimePickerEmision.TabIndex = 6
        '
        'CheckBoxCuentas
        '
        Me.CheckBoxCuentas.AutoSize = True
        Me.CheckBoxCuentas.Location = New System.Drawing.Point(37, 134)
        Me.CheckBoxCuentas.Name = "CheckBoxCuentas"
        Me.CheckBoxCuentas.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBoxCuentas.Size = New System.Drawing.Size(114, 17)
        Me.CheckBoxCuentas.TabIndex = 2
        Me.CheckBoxCuentas.Text = "Todas las Cuentas"
        Me.CheckBoxCuentas.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(90, 164)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Cuenta"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(78, 118)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(203, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Ingrese filtro de Cuenta Financiera"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(79, 202)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(217, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Ingrese filtro de Concepto Financiero"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CheckBoxConceptos
        '
        Me.CheckBoxConceptos.AutoSize = True
        Me.CheckBoxConceptos.Location = New System.Drawing.Point(26, 218)
        Me.CheckBoxConceptos.Name = "CheckBoxConceptos"
        Me.CheckBoxConceptos.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBoxConceptos.Size = New System.Drawing.Size(126, 17)
        Me.CheckBoxConceptos.TabIndex = 4
        Me.CheckBoxConceptos.Text = "Todos los Conceptos"
        Me.CheckBoxConceptos.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(79, 247)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Concepto"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CtlComboConceptos
        '
        Me.CtlComboConceptos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlComboConceptos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlComboConceptos.BusquedaPorCodigobarra = False
        Me.CtlComboConceptos.ColumnasExtras = Nothing
        Me.CtlComboConceptos.CustomFormatArt = False
        Me.CtlComboConceptos.DataSource = Nothing
        Me.CtlComboConceptos.DisplayMember = Nothing
        Me.CtlComboConceptos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CtlComboConceptos.FormularioDeAlta = Nothing
        Me.CtlComboConceptos.FormularioDeBusqueda = Nothing
        Me.CtlComboConceptos.Location = New System.Drawing.Point(138, 241)
        Me.CtlComboConceptos.MaximumSize = New System.Drawing.Size(500, 25)
        Me.CtlComboConceptos.MinimumSize = New System.Drawing.Size(200, 25)
        Me.CtlComboConceptos.Name = "CtlComboConceptos"
        Me.CtlComboConceptos.SelectedIndex = -1
        Me.CtlComboConceptos.SelectedItem = Nothing
        Me.CtlComboConceptos.SelectedText = ""
        Me.CtlComboConceptos.SelectedValue = Nothing
        Me.CtlComboConceptos.Size = New System.Drawing.Size(324, 25)
        Me.CtlComboConceptos.TabIndex = 5
        Me.CtlComboConceptos.ValueMember = Nothing
        '
        'CtlComboCuentas
        '
        Me.CtlComboCuentas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlComboCuentas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlComboCuentas.BusquedaPorCodigobarra = False
        Me.CtlComboCuentas.ColumnasExtras = Nothing
        Me.CtlComboCuentas.CustomFormatArt = False
        Me.CtlComboCuentas.DataSource = Nothing
        Me.CtlComboCuentas.DisplayMember = Nothing
        Me.CtlComboCuentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CtlComboCuentas.FormularioDeAlta = Nothing
        Me.CtlComboCuentas.FormularioDeBusqueda = Nothing
        Me.CtlComboCuentas.Location = New System.Drawing.Point(137, 158)
        Me.CtlComboCuentas.MaximumSize = New System.Drawing.Size(500, 25)
        Me.CtlComboCuentas.MinimumSize = New System.Drawing.Size(200, 25)
        Me.CtlComboCuentas.Name = "CtlComboCuentas"
        Me.CtlComboCuentas.SelectedIndex = -1
        Me.CtlComboCuentas.SelectedItem = Nothing
        Me.CtlComboCuentas.SelectedText = ""
        Me.CtlComboCuentas.SelectedValue = Nothing
        Me.CtlComboCuentas.Size = New System.Drawing.Size(324, 25)
        Me.CtlComboCuentas.TabIndex = 3
        Me.CtlComboCuentas.ValueMember = Nothing
        '
        'FormInformeEdoCta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(485, 281)
        Me.Controls.Add(Me.CheckBoxConceptos)
        Me.Controls.Add(Me.CheckBoxCuentas)
        Me.Controls.Add(Me.CtlComboConceptos)
        Me.Controls.Add(Me.CtlComboCuentas)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DateTimePickerEmision)
        Me.Controls.Add(Me.DateTimePickerHasta)
        Me.Controls.Add(Me.DateTimePickerDesde)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LabelDesde)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormInformeEdoCta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormArticulo"
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerEmision As System.Windows.Forms.DateTimePicker
    Friend WithEvents CheckBoxCuentas As System.Windows.Forms.CheckBox
    Friend WithEvents CtlComboCuentas As Principal.CtlCustomCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxConceptos As System.Windows.Forms.CheckBox
    Friend WithEvents CtlComboConceptos As Principal.CtlCustomCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
