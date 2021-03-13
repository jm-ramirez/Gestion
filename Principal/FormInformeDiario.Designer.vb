<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInformeDiario
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePickerHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBoxComprobantes = New System.Windows.Forms.GroupBox()
        Me.RadioButtonT = New System.Windows.Forms.RadioButton()
        Me.RadioButtonP = New System.Windows.Forms.RadioButton()
        Me.RadioButtonF = New System.Windows.Forms.RadioButton()
        Me.GroupBoxCliPro = New System.Windows.Forms.GroupBox()
        Me.CheckBoxDomicilio = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CheckBoxTodos = New System.Windows.Forms.CheckBox()
        Me.RadioButtonFecha = New System.Windows.Forms.RadioButton()
        Me.RadioButtonPeriodo = New System.Windows.Forms.RadioButton()
        Me.LabelPeriodo = New System.Windows.Forms.Label()
        Me.DateTimePickerPeríodo = New System.Windows.Forms.DateTimePicker()
        Me.CheckBoxRet = New System.Windows.Forms.CheckBox()
        Me.CheckBoxSoloTotales = New System.Windows.Forms.CheckBox()
        Me.GroupBoxGasVar = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CheckBoxTodosGastosVar = New System.Windows.Forms.CheckBox()
        Me.GroupBoxConceptos = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CheckBoxConceptos = New System.Windows.Forms.CheckBox()
        Me.CtlComboConceptos = New Principal.CtlCustomCombo()
        Me.CtlComboGastosVar = New Principal.CtlCustomCombo()
        Me.CtlComboCodigo = New Principal.CtlCustomCombo()
        Me.ToolStripMenu.SuspendLayout()
        Me.GroupBoxComprobantes.SuspendLayout()
        Me.GroupBoxCliPro.SuspendLayout()
        Me.GroupBoxGasVar.SuspendLayout()
        Me.GroupBoxConceptos.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnReporte, Me.BtnCancelar})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(434, 25)
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
        Me.DateTimePickerDesde.Location = New System.Drawing.Point(87, 64)
        Me.DateTimePickerDesde.Name = "DateTimePickerDesde"
        Me.DateTimePickerDesde.Size = New System.Drawing.Size(122, 20)
        Me.DateTimePickerDesde.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Desde"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DateTimePickerHasta
        '
        Me.DateTimePickerHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerHasta.Location = New System.Drawing.Point(87, 90)
        Me.DateTimePickerHasta.Name = "DateTimePickerHasta"
        Me.DateTimePickerHasta.Size = New System.Drawing.Size(122, 20)
        Me.DateTimePickerHasta.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(46, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Hasta"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBoxComprobantes
        '
        Me.GroupBoxComprobantes.Controls.Add(Me.RadioButtonT)
        Me.GroupBoxComprobantes.Controls.Add(Me.RadioButtonP)
        Me.GroupBoxComprobantes.Controls.Add(Me.RadioButtonF)
        Me.GroupBoxComprobantes.Location = New System.Drawing.Point(12, 348)
        Me.GroupBoxComprobantes.Name = "GroupBoxComprobantes"
        Me.GroupBoxComprobantes.Size = New System.Drawing.Size(410, 50)
        Me.GroupBoxComprobantes.TabIndex = 10
        Me.GroupBoxComprobantes.TabStop = False
        Me.GroupBoxComprobantes.Text = "Tipos de comprobantes"
        Me.GroupBoxComprobantes.Visible = False
        '
        'RadioButtonT
        '
        Me.RadioButtonT.AutoSize = True
        Me.RadioButtonT.Location = New System.Drawing.Point(273, 17)
        Me.RadioButtonT.Name = "RadioButtonT"
        Me.RadioButtonT.Size = New System.Drawing.Size(55, 17)
        Me.RadioButtonT.TabIndex = 2
        Me.RadioButtonT.TabStop = True
        Me.RadioButtonT.Text = "Todos"
        Me.RadioButtonT.UseVisualStyleBackColor = True
        '
        'RadioButtonP
        '
        Me.RadioButtonP.AutoSize = True
        Me.RadioButtonP.Location = New System.Drawing.Point(166, 17)
        Me.RadioButtonP.Name = "RadioButtonP"
        Me.RadioButtonP.Size = New System.Drawing.Size(89, 17)
        Me.RadioButtonP.TabIndex = 1
        Me.RadioButtonP.TabStop = True
        Me.RadioButtonP.Text = "Presupuestos"
        Me.RadioButtonP.UseVisualStyleBackColor = True
        '
        'RadioButtonF
        '
        Me.RadioButtonF.AutoSize = True
        Me.RadioButtonF.Location = New System.Drawing.Point(82, 17)
        Me.RadioButtonF.Name = "RadioButtonF"
        Me.RadioButtonF.Size = New System.Drawing.Size(66, 17)
        Me.RadioButtonF.TabIndex = 0
        Me.RadioButtonF.TabStop = True
        Me.RadioButtonF.Text = "Facturas"
        Me.RadioButtonF.UseVisualStyleBackColor = True
        '
        'GroupBoxCliPro
        '
        Me.GroupBoxCliPro.Controls.Add(Me.CheckBoxDomicilio)
        Me.GroupBoxCliPro.Controls.Add(Me.Label3)
        Me.GroupBoxCliPro.Controls.Add(Me.CtlComboCodigo)
        Me.GroupBoxCliPro.Controls.Add(Me.CheckBoxTodos)
        Me.GroupBoxCliPro.Location = New System.Drawing.Point(12, 116)
        Me.GroupBoxCliPro.Name = "GroupBoxCliPro"
        Me.GroupBoxCliPro.Size = New System.Drawing.Size(410, 89)
        Me.GroupBoxCliPro.TabIndex = 6
        Me.GroupBoxCliPro.TabStop = False
        Me.GroupBoxCliPro.Text = "Cliente / Proveedor"
        '
        'CheckBoxDomicilio
        '
        Me.CheckBoxDomicilio.AutoSize = True
        Me.CheckBoxDomicilio.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxDomicilio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxDomicilio.Location = New System.Drawing.Point(173, 20)
        Me.CheckBoxDomicilio.Name = "CheckBoxDomicilio"
        Me.CheckBoxDomicilio.Size = New System.Drawing.Size(231, 17)
        Me.CheckBoxDomicilio.TabIndex = 3
        Me.CheckBoxDomicilio.Text = "Agrupar por domicilio de facturación"
        Me.CheckBoxDomicilio.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(22, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Código"
        '
        'CheckBoxTodos
        '
        Me.CheckBoxTodos.AutoSize = True
        Me.CheckBoxTodos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxTodos.Location = New System.Drawing.Point(28, 20)
        Me.CheckBoxTodos.Name = "CheckBoxTodos"
        Me.CheckBoxTodos.Size = New System.Drawing.Size(61, 17)
        Me.CheckBoxTodos.TabIndex = 0
        Me.CheckBoxTodos.Text = "Todos"
        Me.CheckBoxTodos.UseVisualStyleBackColor = True
        '
        'RadioButtonFecha
        '
        Me.RadioButtonFecha.AutoSize = True
        Me.RadioButtonFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonFecha.Location = New System.Drawing.Point(12, 41)
        Me.RadioButtonFecha.Name = "RadioButtonFecha"
        Me.RadioButtonFecha.Size = New System.Drawing.Size(250, 17)
        Me.RadioButtonFecha.TabIndex = 1
        Me.RadioButtonFecha.TabStop = True
        Me.RadioButtonFecha.Text = "Entorno de fechas de los comprobantes"
        Me.RadioButtonFecha.UseVisualStyleBackColor = True
        '
        'RadioButtonPeriodo
        '
        Me.RadioButtonPeriodo.AutoSize = True
        Me.RadioButtonPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonPeriodo.Location = New System.Drawing.Point(268, 41)
        Me.RadioButtonPeriodo.Name = "RadioButtonPeriodo"
        Me.RadioButtonPeriodo.Size = New System.Drawing.Size(141, 17)
        Me.RadioButtonPeriodo.TabIndex = 2
        Me.RadioButtonPeriodo.TabStop = True
        Me.RadioButtonPeriodo.Text = "Período Facturación"
        Me.RadioButtonPeriodo.UseVisualStyleBackColor = True
        '
        'LabelPeriodo
        '
        Me.LabelPeriodo.AutoSize = True
        Me.LabelPeriodo.Location = New System.Drawing.Point(282, 68)
        Me.LabelPeriodo.Name = "LabelPeriodo"
        Me.LabelPeriodo.Size = New System.Drawing.Size(45, 13)
        Me.LabelPeriodo.TabIndex = 1
        Me.LabelPeriodo.Text = "Período"
        Me.LabelPeriodo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DateTimePickerPeríodo
        '
        Me.DateTimePickerPeríodo.CustomFormat = "MM/yyyy"
        Me.DateTimePickerPeríodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerPeríodo.Location = New System.Drawing.Point(333, 64)
        Me.DateTimePickerPeríodo.Name = "DateTimePickerPeríodo"
        Me.DateTimePickerPeríodo.ShowUpDown = True
        Me.DateTimePickerPeríodo.Size = New System.Drawing.Size(76, 20)
        Me.DateTimePickerPeríodo.TabIndex = 5
        '
        'CheckBoxRet
        '
        Me.CheckBoxRet.AutoSize = True
        Me.CheckBoxRet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxRet.Location = New System.Drawing.Point(12, 211)
        Me.CheckBoxRet.Name = "CheckBoxRet"
        Me.CheckBoxRet.Size = New System.Drawing.Size(272, 17)
        Me.CheckBoxRet.TabIndex = 7
        Me.CheckBoxRet.Text = "Incluir listado de percepciones/retenciones"
        Me.CheckBoxRet.UseVisualStyleBackColor = True
        '
        'CheckBoxSoloTotales
        '
        Me.CheckBoxSoloTotales.AutoSize = True
        Me.CheckBoxSoloTotales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxSoloTotales.Location = New System.Drawing.Point(12, 211)
        Me.CheckBoxSoloTotales.Name = "CheckBoxSoloTotales"
        Me.CheckBoxSoloTotales.Size = New System.Drawing.Size(161, 17)
        Me.CheckBoxSoloTotales.TabIndex = 8
        Me.CheckBoxSoloTotales.Text = "Emitir informe totalizado"
        Me.CheckBoxSoloTotales.UseVisualStyleBackColor = True
        '
        'GroupBoxGasVar
        '
        Me.GroupBoxGasVar.Controls.Add(Me.Label4)
        Me.GroupBoxGasVar.Controls.Add(Me.CtlComboGastosVar)
        Me.GroupBoxGasVar.Controls.Add(Me.CheckBoxTodosGastosVar)
        Me.GroupBoxGasVar.Location = New System.Drawing.Point(12, 236)
        Me.GroupBoxGasVar.Name = "GroupBoxGasVar"
        Me.GroupBoxGasVar.Size = New System.Drawing.Size(410, 89)
        Me.GroupBoxGasVar.TabIndex = 9
        Me.GroupBoxGasVar.TabStop = False
        Me.GroupBoxGasVar.Text = "Gastos Variables"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(22, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Código"
        '
        'CheckBoxTodosGastosVar
        '
        Me.CheckBoxTodosGastosVar.AutoSize = True
        Me.CheckBoxTodosGastosVar.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxTodosGastosVar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxTodosGastosVar.Location = New System.Drawing.Point(28, 20)
        Me.CheckBoxTodosGastosVar.Name = "CheckBoxTodosGastosVar"
        Me.CheckBoxTodosGastosVar.Size = New System.Drawing.Size(61, 17)
        Me.CheckBoxTodosGastosVar.TabIndex = 0
        Me.CheckBoxTodosGastosVar.Text = "Todos"
        Me.CheckBoxTodosGastosVar.UseVisualStyleBackColor = True
        '
        'GroupBoxConceptos
        '
        Me.GroupBoxConceptos.Controls.Add(Me.Label5)
        Me.GroupBoxConceptos.Controls.Add(Me.CtlComboConceptos)
        Me.GroupBoxConceptos.Controls.Add(Me.CheckBoxConceptos)
        Me.GroupBoxConceptos.Location = New System.Drawing.Point(12, 253)
        Me.GroupBoxConceptos.Name = "GroupBoxConceptos"
        Me.GroupBoxConceptos.Size = New System.Drawing.Size(410, 89)
        Me.GroupBoxConceptos.TabIndex = 12
        Me.GroupBoxConceptos.TabStop = False
        Me.GroupBoxConceptos.Text = "Conceptos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(22, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Código"
        '
        'CheckBoxConceptos
        '
        Me.CheckBoxConceptos.AutoSize = True
        Me.CheckBoxConceptos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxConceptos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxConceptos.Location = New System.Drawing.Point(28, 20)
        Me.CheckBoxConceptos.Name = "CheckBoxConceptos"
        Me.CheckBoxConceptos.Size = New System.Drawing.Size(61, 17)
        Me.CheckBoxConceptos.TabIndex = 0
        Me.CheckBoxConceptos.Text = "Todos"
        Me.CheckBoxConceptos.UseVisualStyleBackColor = True
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
        Me.CtlComboConceptos.Location = New System.Drawing.Point(75, 43)
        Me.CtlComboConceptos.MaximumSize = New System.Drawing.Size(500, 25)
        Me.CtlComboConceptos.MinimumSize = New System.Drawing.Size(200, 25)
        Me.CtlComboConceptos.Name = "CtlComboConceptos"
        Me.CtlComboConceptos.SelectedIndex = -1
        Me.CtlComboConceptos.SelectedItem = Nothing
        Me.CtlComboConceptos.SelectedText = ""
        Me.CtlComboConceptos.SelectedValue = Nothing
        Me.CtlComboConceptos.Size = New System.Drawing.Size(329, 25)
        Me.CtlComboConceptos.TabIndex = 1
        Me.CtlComboConceptos.ValueMember = Nothing
        '
        'CtlComboGastosVar
        '
        Me.CtlComboGastosVar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlComboGastosVar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlComboGastosVar.BusquedaPorCodigobarra = False
        Me.CtlComboGastosVar.ColumnasExtras = Nothing
        Me.CtlComboGastosVar.CustomFormatArt = False
        Me.CtlComboGastosVar.DataSource = Nothing
        Me.CtlComboGastosVar.DisplayMember = Nothing
        Me.CtlComboGastosVar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CtlComboGastosVar.FormularioDeAlta = Nothing
        Me.CtlComboGastosVar.FormularioDeBusqueda = Nothing
        Me.CtlComboGastosVar.Location = New System.Drawing.Point(75, 43)
        Me.CtlComboGastosVar.MaximumSize = New System.Drawing.Size(500, 25)
        Me.CtlComboGastosVar.MinimumSize = New System.Drawing.Size(200, 25)
        Me.CtlComboGastosVar.Name = "CtlComboGastosVar"
        Me.CtlComboGastosVar.SelectedIndex = -1
        Me.CtlComboGastosVar.SelectedItem = Nothing
        Me.CtlComboGastosVar.SelectedText = ""
        Me.CtlComboGastosVar.SelectedValue = Nothing
        Me.CtlComboGastosVar.Size = New System.Drawing.Size(329, 25)
        Me.CtlComboGastosVar.TabIndex = 1
        Me.CtlComboGastosVar.ValueMember = Nothing
        '
        'CtlComboCodigo
        '
        Me.CtlComboCodigo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlComboCodigo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlComboCodigo.BusquedaPorCodigobarra = False
        Me.CtlComboCodigo.ColumnasExtras = Nothing
        Me.CtlComboCodigo.CustomFormatArt = False
        Me.CtlComboCodigo.DataSource = Nothing
        Me.CtlComboCodigo.DisplayMember = Nothing
        Me.CtlComboCodigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CtlComboCodigo.FormularioDeAlta = Nothing
        Me.CtlComboCodigo.FormularioDeBusqueda = Nothing
        Me.CtlComboCodigo.Location = New System.Drawing.Point(75, 43)
        Me.CtlComboCodigo.MaximumSize = New System.Drawing.Size(500, 25)
        Me.CtlComboCodigo.MinimumSize = New System.Drawing.Size(200, 25)
        Me.CtlComboCodigo.Name = "CtlComboCodigo"
        Me.CtlComboCodigo.SelectedIndex = -1
        Me.CtlComboCodigo.SelectedItem = Nothing
        Me.CtlComboCodigo.SelectedText = ""
        Me.CtlComboCodigo.SelectedValue = Nothing
        Me.CtlComboCodigo.Size = New System.Drawing.Size(329, 25)
        Me.CtlComboCodigo.TabIndex = 1
        Me.CtlComboCodigo.ValueMember = Nothing
        '
        'FormInformeDiario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(434, 411)
        Me.Controls.Add(Me.GroupBoxConceptos)
        Me.Controls.Add(Me.GroupBoxGasVar)
        Me.Controls.Add(Me.CheckBoxSoloTotales)
        Me.Controls.Add(Me.CheckBoxRet)
        Me.Controls.Add(Me.RadioButtonPeriodo)
        Me.Controls.Add(Me.RadioButtonFecha)
        Me.Controls.Add(Me.GroupBoxCliPro)
        Me.Controls.Add(Me.GroupBoxComprobantes)
        Me.Controls.Add(Me.DateTimePickerHasta)
        Me.Controls.Add(Me.DateTimePickerPeríodo)
        Me.Controls.Add(Me.DateTimePickerDesde)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LabelPeriodo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormInformeDiario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormArticulo"
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.GroupBoxComprobantes.ResumeLayout(False)
        Me.GroupBoxComprobantes.PerformLayout()
        Me.GroupBoxCliPro.ResumeLayout(False)
        Me.GroupBoxCliPro.PerformLayout()
        Me.GroupBoxGasVar.ResumeLayout(False)
        Me.GroupBoxGasVar.PerformLayout()
        Me.GroupBoxConceptos.ResumeLayout(False)
        Me.GroupBoxConceptos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnReporte As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents DateTimePickerDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxComprobantes As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButtonT As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonP As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonF As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBoxCliPro As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBoxTodos As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CtlComboCodigo As Principal.CtlCustomCombo
    Friend WithEvents CheckBoxDomicilio As System.Windows.Forms.CheckBox
    Friend WithEvents RadioButtonFecha As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonPeriodo As System.Windows.Forms.RadioButton
    Friend WithEvents LabelPeriodo As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerPeríodo As System.Windows.Forms.DateTimePicker
    Friend WithEvents CheckBoxRet As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxSoloTotales As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBoxGasVar As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CtlComboGastosVar As Principal.CtlCustomCombo
    Friend WithEvents CheckBoxTodosGastosVar As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBoxConceptos As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CtlComboConceptos As Principal.CtlCustomCombo
    Friend WithEvents CheckBoxConceptos As System.Windows.Forms.CheckBox
End Class
