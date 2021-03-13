<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInfSaldoConcepto
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RadioButtonTotalizado = New System.Windows.Forms.RadioButton()
        Me.RadioButtonDetallado = New System.Windows.Forms.RadioButton()
        Me.DateTimePickerHasta = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePickerDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LabelTituloFiltro = New System.Windows.Forms.Label()
        Me.CtlComboCuentasBancariasHasta = New Principal.CtlCustomCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CtlComboConceptoBancHasta = New Principal.CtlCustomCombo()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CtlComboCuentasBancariasDesde = New Principal.CtlCustomCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CtlComboConceptoBancDesde = New Principal.CtlCustomCombo()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ToolStripMenu.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnReporte, Me.BtnCancelar})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(500, 25)
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.DateTimePickerHasta)
        Me.GroupBox1.Controls.Add(Me.DateTimePickerDesde)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.LabelTituloFiltro)
        Me.GroupBox1.Controls.Add(Me.CtlComboCuentasBancariasHasta)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.CtlComboConceptoBancHasta)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.CtlComboCuentasBancariasDesde)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CtlComboConceptoBancDesde)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(476, 315)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RadioButtonTotalizado)
        Me.GroupBox2.Controls.Add(Me.RadioButtonDetallado)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(33, 249)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(418, 56)
        Me.GroupBox2.TabIndex = 75
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo de Informe: "
        '
        'RadioButtonTotalizado
        '
        Me.RadioButtonTotalizado.AutoSize = True
        Me.RadioButtonTotalizado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonTotalizado.Location = New System.Drawing.Point(205, 21)
        Me.RadioButtonTotalizado.Name = "RadioButtonTotalizado"
        Me.RadioButtonTotalizado.Size = New System.Drawing.Size(74, 17)
        Me.RadioButtonTotalizado.TabIndex = 7
        Me.RadioButtonTotalizado.Text = "Totalizado"
        Me.RadioButtonTotalizado.UseVisualStyleBackColor = True
        '
        'RadioButtonDetallado
        '
        Me.RadioButtonDetallado.AutoSize = True
        Me.RadioButtonDetallado.Checked = True
        Me.RadioButtonDetallado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonDetallado.Location = New System.Drawing.Point(107, 21)
        Me.RadioButtonDetallado.Name = "RadioButtonDetallado"
        Me.RadioButtonDetallado.Size = New System.Drawing.Size(70, 17)
        Me.RadioButtonDetallado.TabIndex = 6
        Me.RadioButtonDetallado.TabStop = True
        Me.RadioButtonDetallado.Text = "Detallado"
        Me.RadioButtonDetallado.UseVisualStyleBackColor = True
        '
        'DateTimePickerHasta
        '
        Me.DateTimePickerHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerHasta.Location = New System.Drawing.Point(271, 42)
        Me.DateTimePickerHasta.Name = "DateTimePickerHasta"
        Me.DateTimePickerHasta.Size = New System.Drawing.Size(122, 20)
        Me.DateTimePickerHasta.TabIndex = 1
        '
        'DateTimePickerDesde
        '
        Me.DateTimePickerDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerDesde.Location = New System.Drawing.Point(95, 42)
        Me.DateTimePickerDesde.Name = "DateTimePickerDesde"
        Me.DateTimePickerDesde.Size = New System.Drawing.Size(122, 20)
        Me.DateTimePickerDesde.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(31, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(216, 13)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "Entorno de Fechas de Efectivización"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(231, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "Hasta"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(51, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 72
        Me.Label7.Text = "Desde"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(31, 162)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(201, 13)
        Me.Label6.TabIndex = 71
        Me.Label6.Text = "Entorno de Conceptos Bancarios :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelTituloFiltro
        '
        Me.LabelTituloFiltro.AutoSize = True
        Me.LabelTituloFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTituloFiltro.Location = New System.Drawing.Point(31, 71)
        Me.LabelTituloFiltro.Name = "LabelTituloFiltro"
        Me.LabelTituloFiltro.Size = New System.Drawing.Size(187, 13)
        Me.LabelTituloFiltro.TabIndex = 69
        Me.LabelTituloFiltro.Text = "Entorno de Cuentas Bancarias :"
        Me.LabelTituloFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CtlComboCuentasBancariasHasta
        '
        Me.CtlComboCuentasBancariasHasta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlComboCuentasBancariasHasta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlComboCuentasBancariasHasta.BusquedaPorCodigobarra = False
        Me.CtlComboCuentasBancariasHasta.ColumnasExtras = Nothing
        Me.CtlComboCuentasBancariasHasta.CustomFormatArt = False
        Me.CtlComboCuentasBancariasHasta.DataSource = Nothing
        Me.CtlComboCuentasBancariasHasta.DisplayMember = Nothing
        Me.CtlComboCuentasBancariasHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CtlComboCuentasBancariasHasta.FormularioDeAlta = Nothing
        Me.CtlComboCuentasBancariasHasta.FormularioDeBusqueda = Nothing
        Me.CtlComboCuentasBancariasHasta.Location = New System.Drawing.Point(95, 123)
        Me.CtlComboCuentasBancariasHasta.MaximumSize = New System.Drawing.Size(500, 25)
        Me.CtlComboCuentasBancariasHasta.MinimumSize = New System.Drawing.Size(200, 25)
        Me.CtlComboCuentasBancariasHasta.Name = "CtlComboCuentasBancariasHasta"
        Me.CtlComboCuentasBancariasHasta.SelectedIndex = -1
        Me.CtlComboCuentasBancariasHasta.SelectedItem = Nothing
        Me.CtlComboCuentasBancariasHasta.SelectedText = ""
        Me.CtlComboCuentasBancariasHasta.SelectedValue = Nothing
        Me.CtlComboCuentasBancariasHasta.Size = New System.Drawing.Size(356, 25)
        Me.CtlComboCuentasBancariasHasta.TabIndex = 3
        Me.CtlComboCuentasBancariasHasta.ValueMember = Nothing
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(54, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Hasta"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CtlComboConceptoBancHasta
        '
        Me.CtlComboConceptoBancHasta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlComboConceptoBancHasta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlComboConceptoBancHasta.BusquedaPorCodigobarra = False
        Me.CtlComboConceptoBancHasta.ColumnasExtras = Nothing
        Me.CtlComboConceptoBancHasta.CustomFormatArt = False
        Me.CtlComboConceptoBancHasta.DataSource = Nothing
        Me.CtlComboConceptoBancHasta.DisplayMember = Nothing
        Me.CtlComboConceptoBancHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CtlComboConceptoBancHasta.FormularioDeAlta = Nothing
        Me.CtlComboConceptoBancHasta.FormularioDeBusqueda = Nothing
        Me.CtlComboConceptoBancHasta.Location = New System.Drawing.Point(94, 215)
        Me.CtlComboConceptoBancHasta.MaximumSize = New System.Drawing.Size(500, 25)
        Me.CtlComboConceptoBancHasta.MinimumSize = New System.Drawing.Size(200, 25)
        Me.CtlComboConceptoBancHasta.Name = "CtlComboConceptoBancHasta"
        Me.CtlComboConceptoBancHasta.SelectedIndex = -1
        Me.CtlComboConceptoBancHasta.SelectedItem = Nothing
        Me.CtlComboConceptoBancHasta.SelectedText = ""
        Me.CtlComboConceptoBancHasta.SelectedValue = Nothing
        Me.CtlComboConceptoBancHasta.Size = New System.Drawing.Size(356, 25)
        Me.CtlComboConceptoBancHasta.TabIndex = 5
        Me.CtlComboConceptoBancHasta.ValueMember = Nothing
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(54, 221)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Hasta"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CtlComboCuentasBancariasDesde
        '
        Me.CtlComboCuentasBancariasDesde.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlComboCuentasBancariasDesde.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlComboCuentasBancariasDesde.BusquedaPorCodigobarra = False
        Me.CtlComboCuentasBancariasDesde.ColumnasExtras = Nothing
        Me.CtlComboCuentasBancariasDesde.CustomFormatArt = False
        Me.CtlComboCuentasBancariasDesde.DataSource = Nothing
        Me.CtlComboCuentasBancariasDesde.DisplayMember = Nothing
        Me.CtlComboCuentasBancariasDesde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CtlComboCuentasBancariasDesde.FormularioDeAlta = Nothing
        Me.CtlComboCuentasBancariasDesde.FormularioDeBusqueda = Nothing
        Me.CtlComboCuentasBancariasDesde.Location = New System.Drawing.Point(95, 92)
        Me.CtlComboCuentasBancariasDesde.MaximumSize = New System.Drawing.Size(500, 25)
        Me.CtlComboCuentasBancariasDesde.MinimumSize = New System.Drawing.Size(200, 25)
        Me.CtlComboCuentasBancariasDesde.Name = "CtlComboCuentasBancariasDesde"
        Me.CtlComboCuentasBancariasDesde.SelectedIndex = -1
        Me.CtlComboCuentasBancariasDesde.SelectedItem = Nothing
        Me.CtlComboCuentasBancariasDesde.SelectedText = ""
        Me.CtlComboCuentasBancariasDesde.SelectedValue = Nothing
        Me.CtlComboCuentasBancariasDesde.Size = New System.Drawing.Size(356, 25)
        Me.CtlComboCuentasBancariasDesde.TabIndex = 2
        Me.CtlComboCuentasBancariasDesde.ValueMember = Nothing
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(51, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Desde"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CtlComboConceptoBancDesde
        '
        Me.CtlComboConceptoBancDesde.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlComboConceptoBancDesde.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlComboConceptoBancDesde.BusquedaPorCodigobarra = False
        Me.CtlComboConceptoBancDesde.ColumnasExtras = Nothing
        Me.CtlComboConceptoBancDesde.CustomFormatArt = False
        Me.CtlComboConceptoBancDesde.DataSource = Nothing
        Me.CtlComboConceptoBancDesde.DisplayMember = Nothing
        Me.CtlComboConceptoBancDesde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CtlComboConceptoBancDesde.FormularioDeAlta = Nothing
        Me.CtlComboConceptoBancDesde.FormularioDeBusqueda = Nothing
        Me.CtlComboConceptoBancDesde.Location = New System.Drawing.Point(95, 184)
        Me.CtlComboConceptoBancDesde.MaximumSize = New System.Drawing.Size(500, 25)
        Me.CtlComboConceptoBancDesde.MinimumSize = New System.Drawing.Size(200, 25)
        Me.CtlComboConceptoBancDesde.Name = "CtlComboConceptoBancDesde"
        Me.CtlComboConceptoBancDesde.SelectedIndex = -1
        Me.CtlComboConceptoBancDesde.SelectedItem = Nothing
        Me.CtlComboConceptoBancDesde.SelectedText = ""
        Me.CtlComboConceptoBancDesde.SelectedValue = Nothing
        Me.CtlComboConceptoBancDesde.Size = New System.Drawing.Size(356, 25)
        Me.CtlComboConceptoBancDesde.TabIndex = 4
        Me.CtlComboConceptoBancDesde.ValueMember = Nothing
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(51, 190)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(38, 13)
        Me.Label12.TabIndex = 31
        Me.Label12.Text = "Desde"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FormInfSaldoConcepto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(500, 348)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormInfSaldoConcepto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormListaPlanilla"
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnReporte As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CtlComboCuentasBancariasHasta As Principal.CtlCustomCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CtlComboConceptoBancHasta As Principal.CtlCustomCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CtlComboCuentasBancariasDesde As Principal.CtlCustomCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CtlComboConceptoBancDesde As Principal.CtlCustomCombo
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LabelTituloFiltro As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePickerDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButtonTotalizado As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonDetallado As System.Windows.Forms.RadioButton
End Class
