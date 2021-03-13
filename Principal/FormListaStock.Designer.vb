<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormListaStock
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CheckBoxTodos = New System.Windows.Forms.CheckBox()
        Me.LabelTope = New System.Windows.Forms.Label()
        Me.DateTimePickerTope = New System.Windows.Forms.DateTimePicker()
        Me.GroupBoxComprobantes = New System.Windows.Forms.GroupBox()
        Me.RadioButtonT = New System.Windows.Forms.RadioButton()
        Me.RadioButtonP = New System.Windows.Forms.RadioButton()
        Me.RadioButtonF = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CheckBoxArticulos = New System.Windows.Forms.CheckBox()
        Me.LabelInicial = New System.Windows.Forms.Label()
        Me.DateTimePickeInicial = New System.Windows.Forms.DateTimePicker()
        Me.CtlCustomArticulo = New Principal.CtlCustomCombo()
        Me.CtlComboRubro = New Principal.CtlCustomCombo()
        Me.ToolStripMenu.SuspendLayout()
        Me.GroupBoxComprobantes.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnReporte, Me.BtnCancelar})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(637, 25)
        Me.ToolStripMenu.TabIndex = 0
        Me.ToolStripMenu.Text = "ToolStrip1"
        '
        'BtnReporte
        '
        Me.BtnReporte.Image = Global.Principal.My.Resources.Resources.report
        Me.BtnReporte.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnReporte.Name = "BtnReporte"
        Me.BtnReporte.Size = New System.Drawing.Size(141, 22)
        Me.BtnReporte.Text = "Generar Reporte [F12]"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = Global.Principal.My.Resources.Resources.cancel
        Me.BtnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(101, 22)
        Me.BtnCancelar.Text = "Cancelar [Esc]"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(81, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Rubro"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CheckBoxTodos
        '
        Me.CheckBoxTodos.Location = New System.Drawing.Point(26, 88)
        Me.CheckBoxTodos.Name = "CheckBoxTodos"
        Me.CheckBoxTodos.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBoxTodos.Size = New System.Drawing.Size(110, 17)
        Me.CheckBoxTodos.TabIndex = 2
        Me.CheckBoxTodos.Text = "Todos los Rubros"
        Me.CheckBoxTodos.UseVisualStyleBackColor = True
        '
        'LabelTope
        '
        Me.LabelTope.AutoSize = True
        Me.LabelTope.Location = New System.Drawing.Point(56, 66)
        Me.LabelTope.Name = "LabelTope"
        Me.LabelTope.Size = New System.Drawing.Size(61, 13)
        Me.LabelTope.TabIndex = 1
        Me.LabelTope.Text = "Fecha tope"
        Me.LabelTope.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DateTimePickerTope
        '
        Me.DateTimePickerTope.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerTope.Location = New System.Drawing.Point(123, 62)
        Me.DateTimePickerTope.Name = "DateTimePickerTope"
        Me.DateTimePickerTope.Size = New System.Drawing.Size(90, 20)
        Me.DateTimePickerTope.TabIndex = 1
        '
        'GroupBoxComprobantes
        '
        Me.GroupBoxComprobantes.Controls.Add(Me.RadioButtonT)
        Me.GroupBoxComprobantes.Controls.Add(Me.RadioButtonP)
        Me.GroupBoxComprobantes.Controls.Add(Me.RadioButtonF)
        Me.GroupBoxComprobantes.Location = New System.Drawing.Point(96, 203)
        Me.GroupBoxComprobantes.Name = "GroupBoxComprobantes"
        Me.GroupBoxComprobantes.Size = New System.Drawing.Size(423, 50)
        Me.GroupBoxComprobantes.TabIndex = 7
        Me.GroupBoxComprobantes.TabStop = False
        Me.GroupBoxComprobantes.Text = "Tipos de comprobantes"
        Me.GroupBoxComprobantes.Visible = False
        '
        'RadioButtonT
        '
        Me.RadioButtonT.AutoSize = True
        Me.RadioButtonT.Location = New System.Drawing.Point(298, 17)
        Me.RadioButtonT.Name = "RadioButtonT"
        Me.RadioButtonT.Size = New System.Drawing.Size(55, 17)
        Me.RadioButtonT.TabIndex = 0
        Me.RadioButtonT.TabStop = True
        Me.RadioButtonT.Text = "Todos"
        Me.RadioButtonT.UseVisualStyleBackColor = True
        '
        'RadioButtonP
        '
        Me.RadioButtonP.AutoSize = True
        Me.RadioButtonP.Location = New System.Drawing.Point(191, 17)
        Me.RadioButtonP.Name = "RadioButtonP"
        Me.RadioButtonP.Size = New System.Drawing.Size(89, 17)
        Me.RadioButtonP.TabIndex = 0
        Me.RadioButtonP.TabStop = True
        Me.RadioButtonP.Text = "Presupuestos"
        Me.RadioButtonP.UseVisualStyleBackColor = True
        '
        'RadioButtonF
        '
        Me.RadioButtonF.AutoSize = True
        Me.RadioButtonF.Location = New System.Drawing.Point(107, 17)
        Me.RadioButtonF.Name = "RadioButtonF"
        Me.RadioButtonF.Size = New System.Drawing.Size(66, 17)
        Me.RadioButtonF.TabIndex = 0
        Me.RadioButtonF.TabStop = True
        Me.RadioButtonF.Text = "Facturas"
        Me.RadioButtonF.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(73, 178)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Artículo"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CheckBoxArticulos
        '
        Me.CheckBoxArticulos.Location = New System.Drawing.Point(11, 149)
        Me.CheckBoxArticulos.Name = "CheckBoxArticulos"
        Me.CheckBoxArticulos.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBoxArticulos.Size = New System.Drawing.Size(125, 17)
        Me.CheckBoxArticulos.TabIndex = 4
        Me.CheckBoxArticulos.Text = "Todos los Artículos"
        Me.CheckBoxArticulos.UseVisualStyleBackColor = True
        '
        'LabelInicial
        '
        Me.LabelInicial.AutoSize = True
        Me.LabelInicial.Location = New System.Drawing.Point(51, 40)
        Me.LabelInicial.Name = "LabelInicial"
        Me.LabelInicial.Size = New System.Drawing.Size(66, 13)
        Me.LabelInicial.TabIndex = 1
        Me.LabelInicial.Text = "Fecha inicial"
        Me.LabelInicial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DateTimePickeInicial
        '
        Me.DateTimePickeInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickeInicial.Location = New System.Drawing.Point(123, 36)
        Me.DateTimePickeInicial.Name = "DateTimePickeInicial"
        Me.DateTimePickeInicial.Size = New System.Drawing.Size(90, 20)
        Me.DateTimePickeInicial.TabIndex = 0
        '
        'CtlCustomArticulo
        '
        Me.CtlCustomArticulo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlCustomArticulo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlCustomArticulo.BusquedaPorCodigobarra = False
        Me.CtlCustomArticulo.ColumnasExtras = Nothing
        Me.CtlCustomArticulo.CustomFormatArt = False
        Me.CtlCustomArticulo.DataSource = Nothing
        Me.CtlCustomArticulo.DisplayMember = Nothing
        Me.CtlCustomArticulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CtlCustomArticulo.FormularioDeAlta = Nothing
        Me.CtlCustomArticulo.FormularioDeBusqueda = Nothing
        Me.CtlCustomArticulo.Location = New System.Drawing.Point(123, 172)
        Me.CtlCustomArticulo.MaximumSize = New System.Drawing.Size(500, 25)
        Me.CtlCustomArticulo.MinimumSize = New System.Drawing.Size(200, 25)
        Me.CtlCustomArticulo.Name = "CtlCustomArticulo"
        Me.CtlCustomArticulo.SelectedIndex = -1
        Me.CtlCustomArticulo.SelectedItem = Nothing
        Me.CtlCustomArticulo.SelectedText = ""
        Me.CtlCustomArticulo.SelectedValue = Nothing
        Me.CtlCustomArticulo.Size = New System.Drawing.Size(500, 25)
        Me.CtlCustomArticulo.TabIndex = 5
        Me.CtlCustomArticulo.ValueMember = Nothing
        '
        'CtlComboRubro
        '
        Me.CtlComboRubro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlComboRubro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlComboRubro.BusquedaPorCodigobarra = False
        Me.CtlComboRubro.ColumnasExtras = Nothing
        Me.CtlComboRubro.CustomFormatArt = False
        Me.CtlComboRubro.DataSource = Nothing
        Me.CtlComboRubro.DisplayMember = Nothing
        Me.CtlComboRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CtlComboRubro.FormularioDeAlta = Nothing
        Me.CtlComboRubro.FormularioDeBusqueda = Nothing
        Me.CtlComboRubro.Location = New System.Drawing.Point(123, 111)
        Me.CtlComboRubro.MaximumSize = New System.Drawing.Size(500, 25)
        Me.CtlComboRubro.MinimumSize = New System.Drawing.Size(200, 25)
        Me.CtlComboRubro.Name = "CtlComboRubro"
        Me.CtlComboRubro.SelectedIndex = -1
        Me.CtlComboRubro.SelectedItem = Nothing
        Me.CtlComboRubro.SelectedText = ""
        Me.CtlComboRubro.SelectedValue = Nothing
        Me.CtlComboRubro.Size = New System.Drawing.Size(311, 25)
        Me.CtlComboRubro.TabIndex = 3
        Me.CtlComboRubro.ValueMember = Nothing
        '
        'FormListaStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(637, 263)
        Me.Controls.Add(Me.GroupBoxComprobantes)
        Me.Controls.Add(Me.DateTimePickeInicial)
        Me.Controls.Add(Me.DateTimePickerTope)
        Me.Controls.Add(Me.CheckBoxArticulos)
        Me.Controls.Add(Me.CheckBoxTodos)
        Me.Controls.Add(Me.CtlCustomArticulo)
        Me.Controls.Add(Me.CtlComboRubro)
        Me.Controls.Add(Me.LabelInicial)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LabelTope)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormListaStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormArticulo"
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.GroupBoxComprobantes.ResumeLayout(False)
        Me.GroupBoxComprobantes.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnReporte As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents CtlComboRubro As Principal.CtlCustomCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxTodos As System.Windows.Forms.CheckBox
    Friend WithEvents LabelTope As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerTope As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBoxComprobantes As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButtonT As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonP As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonF As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CtlCustomArticulo As Principal.CtlCustomCombo
    Friend WithEvents CheckBoxArticulos As System.Windows.Forms.CheckBox
    Friend WithEvents LabelInicial As System.Windows.Forms.Label
    Friend WithEvents DateTimePickeInicial As System.Windows.Forms.DateTimePicker
End Class
