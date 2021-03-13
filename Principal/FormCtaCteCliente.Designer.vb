<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCtaCteCliente
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
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnEmail = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CheckBoxTodos = New System.Windows.Forms.CheckBox()
        Me.DateTimePickerDesde = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePickerHasta = New System.Windows.Forms.DateTimePicker()
        Me.LabelHasta = New System.Windows.Forms.Label()
        Me.LabelDesde = New System.Windows.Forms.Label()
        Me.GroupBoxComprobantes = New System.Windows.Forms.GroupBox()
        Me.RadioButtonT = New System.Windows.Forms.RadioButton()
        Me.RadioButtonP = New System.Windows.Forms.RadioButton()
        Me.RadioButtonF = New System.Windows.Forms.RadioButton()
        Me.CtlComboClientes = New Principal.CtlCustomCombo()
        Me.ToolStripMenu.SuspendLayout()
        Me.GroupBoxComprobantes.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnReporte, Me.ToolStripSeparator6, Me.BtnEmail, Me.ToolStripSeparator1, Me.BtnCancelar})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(463, 25)
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
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'BtnEmail
        '
        Me.BtnEmail.Image = Global.Principal.My.Resources.Resources.email_attach
        Me.BtnEmail.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEmail.Name = "BtnEmail"
        Me.BtnEmail.Size = New System.Drawing.Size(79, 22)
        Me.BtnEmail.Text = "Email [F8]"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
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
        Me.Label3.Location = New System.Drawing.Point(64, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Cliente"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CheckBoxTodos
        '
        Me.CheckBoxTodos.AutoSize = True
        Me.CheckBoxTodos.Location = New System.Drawing.Point(13, 95)
        Me.CheckBoxTodos.Name = "CheckBoxTodos"
        Me.CheckBoxTodos.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBoxTodos.Size = New System.Drawing.Size(111, 17)
        Me.CheckBoxTodos.TabIndex = 2
        Me.CheckBoxTodos.Text = "Todos los clientes"
        Me.CheckBoxTodos.UseVisualStyleBackColor = True
        '
        'DateTimePickerDesde
        '
        Me.DateTimePickerDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerDesde.Location = New System.Drawing.Point(109, 43)
        Me.DateTimePickerDesde.Name = "DateTimePickerDesde"
        Me.DateTimePickerDesde.Size = New System.Drawing.Size(122, 20)
        Me.DateTimePickerDesde.TabIndex = 0
        '
        'DateTimePickerHasta
        '
        Me.DateTimePickerHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerHasta.Location = New System.Drawing.Point(109, 69)
        Me.DateTimePickerHasta.Name = "DateTimePickerHasta"
        Me.DateTimePickerHasta.Size = New System.Drawing.Size(122, 20)
        Me.DateTimePickerHasta.TabIndex = 1
        '
        'LabelHasta
        '
        Me.LabelHasta.AutoSize = True
        Me.LabelHasta.Location = New System.Drawing.Point(64, 73)
        Me.LabelHasta.Name = "LabelHasta"
        Me.LabelHasta.Size = New System.Drawing.Size(35, 13)
        Me.LabelHasta.TabIndex = 1
        Me.LabelHasta.Text = "Hasta"
        Me.LabelHasta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelDesde
        '
        Me.LabelDesde.AutoSize = True
        Me.LabelDesde.Location = New System.Drawing.Point(64, 47)
        Me.LabelDesde.Name = "LabelDesde"
        Me.LabelDesde.Size = New System.Drawing.Size(38, 13)
        Me.LabelDesde.TabIndex = 1
        Me.LabelDesde.Text = "Desde"
        Me.LabelDesde.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBoxComprobantes
        '
        Me.GroupBoxComprobantes.Controls.Add(Me.RadioButtonT)
        Me.GroupBoxComprobantes.Controls.Add(Me.RadioButtonP)
        Me.GroupBoxComprobantes.Controls.Add(Me.RadioButtonF)
        Me.GroupBoxComprobantes.Location = New System.Drawing.Point(12, 149)
        Me.GroupBoxComprobantes.Name = "GroupBoxComprobantes"
        Me.GroupBoxComprobantes.Size = New System.Drawing.Size(439, 50)
        Me.GroupBoxComprobantes.TabIndex = 4
        Me.GroupBoxComprobantes.TabStop = False
        Me.GroupBoxComprobantes.Text = "Tipos de comprobantes"
        Me.GroupBoxComprobantes.Visible = False
        '
        'RadioButtonT
        '
        Me.RadioButtonT.AutoSize = True
        Me.RadioButtonT.Location = New System.Drawing.Point(287, 17)
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
        Me.RadioButtonP.Location = New System.Drawing.Point(180, 17)
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
        Me.RadioButtonF.Location = New System.Drawing.Point(96, 17)
        Me.RadioButtonF.Name = "RadioButtonF"
        Me.RadioButtonF.Size = New System.Drawing.Size(66, 17)
        Me.RadioButtonF.TabIndex = 0
        Me.RadioButtonF.TabStop = True
        Me.RadioButtonF.Text = "Facturas"
        Me.RadioButtonF.UseVisualStyleBackColor = True
        '
        'CtlComboClientes
        '
        Me.CtlComboClientes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlComboClientes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlComboClientes.BusquedaPorCodigobarra = False
        Me.CtlComboClientes.ColumnasExtras = Nothing
        Me.CtlComboClientes.CustomFormatArt = False
        Me.CtlComboClientes.DataSource = Nothing
        Me.CtlComboClientes.DisplayMember = Nothing
        Me.CtlComboClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CtlComboClientes.FormularioDeAlta = Nothing
        Me.CtlComboClientes.FormularioDeBusqueda = Nothing
        Me.CtlComboClientes.Location = New System.Drawing.Point(109, 118)
        Me.CtlComboClientes.MaximumSize = New System.Drawing.Size(500, 25)
        Me.CtlComboClientes.MinimumSize = New System.Drawing.Size(200, 25)
        Me.CtlComboClientes.Name = "CtlComboClientes"
        Me.CtlComboClientes.SelectedIndex = -1
        Me.CtlComboClientes.SelectedItem = Nothing
        Me.CtlComboClientes.SelectedText = ""
        Me.CtlComboClientes.SelectedValue = Nothing
        Me.CtlComboClientes.Size = New System.Drawing.Size(342, 25)
        Me.CtlComboClientes.TabIndex = 3
        Me.CtlComboClientes.ValueMember = Nothing
        '
        'FormCtaCteCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(463, 207)
        Me.Controls.Add(Me.GroupBoxComprobantes)
        Me.Controls.Add(Me.DateTimePickerHasta)
        Me.Controls.Add(Me.DateTimePickerDesde)
        Me.Controls.Add(Me.CheckBoxTodos)
        Me.Controls.Add(Me.CtlComboClientes)
        Me.Controls.Add(Me.LabelDesde)
        Me.Controls.Add(Me.LabelHasta)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormCtaCteCliente"
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
    Friend WithEvents CtlComboClientes As Principal.CtlCustomCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxTodos As System.Windows.Forms.CheckBox
    Friend WithEvents DateTimePickerDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePickerHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelHasta As System.Windows.Forms.Label
    Friend WithEvents LabelDesde As System.Windows.Forms.Label
    Friend WithEvents GroupBoxComprobantes As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButtonT As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonP As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonF As System.Windows.Forms.RadioButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnEmail As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
