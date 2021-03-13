<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInformeComprasRubArt
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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LabelTituloFiltro = New System.Windows.Forms.Label()
        Me.CtlComboRubrosHasta = New Principal.CtlCustomCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CtlComboArticulosHasta = New Principal.CtlCustomCombo()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CtlComboRubrosDesde = New Principal.CtlCustomCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CtlComboArticulosDesde = New Principal.CtlCustomCombo()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.DateTimePickerHasta = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePickerDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ToolStripMenu.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnReporte, Me.BtnCancelar})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(498, 25)
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.LabelTituloFiltro)
        Me.GroupBox1.Controls.Add(Me.CtlComboRubrosHasta)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.CtlComboArticulosHasta)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.CtlComboRubrosDesde)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CtlComboArticulosDesde)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.DateTimePickerHasta)
        Me.GroupBox1.Controls.Add(Me.DateTimePickerDesde)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(474, 302)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(22, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(132, 13)
        Me.Label6.TabIndex = 84
        Me.Label6.Text = "Entorno de Artículos :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelTituloFiltro
        '
        Me.LabelTituloFiltro.AutoSize = True
        Me.LabelTituloFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTituloFiltro.Location = New System.Drawing.Point(22, 196)
        Me.LabelTituloFiltro.Name = "LabelTituloFiltro"
        Me.LabelTituloFiltro.Size = New System.Drawing.Size(121, 13)
        Me.LabelTituloFiltro.TabIndex = 83
        Me.LabelTituloFiltro.Text = "Entorno de Rubros :"
        Me.LabelTituloFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CtlComboRubrosHasta
        '
        Me.CtlComboRubrosHasta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlComboRubrosHasta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlComboRubrosHasta.BusquedaPorCodigobarra = False
        Me.CtlComboRubrosHasta.ColumnasExtras = Nothing
        Me.CtlComboRubrosHasta.CustomFormatArt = False
        Me.CtlComboRubrosHasta.DataSource = Nothing
        Me.CtlComboRubrosHasta.DisplayMember = Nothing
        Me.CtlComboRubrosHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CtlComboRubrosHasta.FormularioDeAlta = Nothing
        Me.CtlComboRubrosHasta.FormularioDeBusqueda = Nothing
        Me.CtlComboRubrosHasta.Location = New System.Drawing.Point(86, 258)
        Me.CtlComboRubrosHasta.MaximumSize = New System.Drawing.Size(500, 25)
        Me.CtlComboRubrosHasta.MinimumSize = New System.Drawing.Size(200, 25)
        Me.CtlComboRubrosHasta.Name = "CtlComboRubrosHasta"
        Me.CtlComboRubrosHasta.SelectedIndex = -1
        Me.CtlComboRubrosHasta.SelectedItem = Nothing
        Me.CtlComboRubrosHasta.SelectedText = ""
        Me.CtlComboRubrosHasta.SelectedValue = Nothing
        Me.CtlComboRubrosHasta.Size = New System.Drawing.Size(356, 25)
        Me.CtlComboRubrosHasta.TabIndex = 5
        Me.CtlComboRubrosHasta.ValueMember = Nothing
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(45, 264)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 82
        Me.Label2.Text = "Hasta"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CtlComboArticulosHasta
        '
        Me.CtlComboArticulosHasta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlComboArticulosHasta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlComboArticulosHasta.BusquedaPorCodigobarra = False
        Me.CtlComboArticulosHasta.ColumnasExtras = Nothing
        Me.CtlComboArticulosHasta.CustomFormatArt = False
        Me.CtlComboArticulosHasta.DataSource = Nothing
        Me.CtlComboArticulosHasta.DisplayMember = Nothing
        Me.CtlComboArticulosHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CtlComboArticulosHasta.FormularioDeAlta = Nothing
        Me.CtlComboArticulosHasta.FormularioDeBusqueda = Nothing
        Me.CtlComboArticulosHasta.Location = New System.Drawing.Point(86, 160)
        Me.CtlComboArticulosHasta.MaximumSize = New System.Drawing.Size(500, 25)
        Me.CtlComboArticulosHasta.MinimumSize = New System.Drawing.Size(200, 25)
        Me.CtlComboArticulosHasta.Name = "CtlComboArticulosHasta"
        Me.CtlComboArticulosHasta.SelectedIndex = -1
        Me.CtlComboArticulosHasta.SelectedItem = Nothing
        Me.CtlComboArticulosHasta.SelectedText = ""
        Me.CtlComboArticulosHasta.SelectedValue = Nothing
        Me.CtlComboArticulosHasta.Size = New System.Drawing.Size(356, 25)
        Me.CtlComboArticulosHasta.TabIndex = 3
        Me.CtlComboArticulosHasta.ValueMember = Nothing
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(45, 166)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 81
        Me.Label3.Text = "Hasta"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CtlComboRubrosDesde
        '
        Me.CtlComboRubrosDesde.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlComboRubrosDesde.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlComboRubrosDesde.BusquedaPorCodigobarra = False
        Me.CtlComboRubrosDesde.ColumnasExtras = Nothing
        Me.CtlComboRubrosDesde.CustomFormatArt = False
        Me.CtlComboRubrosDesde.DataSource = Nothing
        Me.CtlComboRubrosDesde.DisplayMember = Nothing
        Me.CtlComboRubrosDesde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CtlComboRubrosDesde.FormularioDeAlta = Nothing
        Me.CtlComboRubrosDesde.FormularioDeBusqueda = Nothing
        Me.CtlComboRubrosDesde.Location = New System.Drawing.Point(86, 227)
        Me.CtlComboRubrosDesde.MaximumSize = New System.Drawing.Size(500, 25)
        Me.CtlComboRubrosDesde.MinimumSize = New System.Drawing.Size(200, 25)
        Me.CtlComboRubrosDesde.Name = "CtlComboRubrosDesde"
        Me.CtlComboRubrosDesde.SelectedIndex = -1
        Me.CtlComboRubrosDesde.SelectedItem = Nothing
        Me.CtlComboRubrosDesde.SelectedText = ""
        Me.CtlComboRubrosDesde.SelectedValue = Nothing
        Me.CtlComboRubrosDesde.Size = New System.Drawing.Size(356, 25)
        Me.CtlComboRubrosDesde.TabIndex = 4
        Me.CtlComboRubrosDesde.ValueMember = Nothing
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 233)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Desde"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CtlComboArticulosDesde
        '
        Me.CtlComboArticulosDesde.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlComboArticulosDesde.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlComboArticulosDesde.BusquedaPorCodigobarra = False
        Me.CtlComboArticulosDesde.ColumnasExtras = Nothing
        Me.CtlComboArticulosDesde.CustomFormatArt = False
        Me.CtlComboArticulosDesde.DataSource = Nothing
        Me.CtlComboArticulosDesde.DisplayMember = Nothing
        Me.CtlComboArticulosDesde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CtlComboArticulosDesde.FormularioDeAlta = Nothing
        Me.CtlComboArticulosDesde.FormularioDeBusqueda = Nothing
        Me.CtlComboArticulosDesde.Location = New System.Drawing.Point(86, 129)
        Me.CtlComboArticulosDesde.MaximumSize = New System.Drawing.Size(500, 25)
        Me.CtlComboArticulosDesde.MinimumSize = New System.Drawing.Size(200, 25)
        Me.CtlComboArticulosDesde.Name = "CtlComboArticulosDesde"
        Me.CtlComboArticulosDesde.SelectedIndex = -1
        Me.CtlComboArticulosDesde.SelectedItem = Nothing
        Me.CtlComboArticulosDesde.SelectedText = ""
        Me.CtlComboArticulosDesde.SelectedValue = Nothing
        Me.CtlComboArticulosDesde.Size = New System.Drawing.Size(356, 25)
        Me.CtlComboArticulosDesde.TabIndex = 2
        Me.CtlComboArticulosDesde.ValueMember = Nothing
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(42, 135)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(38, 13)
        Me.Label12.TabIndex = 79
        Me.Label12.Text = "Desde"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DateTimePickerHasta
        '
        Me.DateTimePickerHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerHasta.Location = New System.Drawing.Point(86, 73)
        Me.DateTimePickerHasta.Name = "DateTimePickerHasta"
        Me.DateTimePickerHasta.Size = New System.Drawing.Size(122, 20)
        Me.DateTimePickerHasta.TabIndex = 1
        '
        'DateTimePickerDesde
        '
        Me.DateTimePickerDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerDesde.Location = New System.Drawing.Point(86, 42)
        Me.DateTimePickerDesde.Name = "DateTimePickerDesde"
        Me.DateTimePickerDesde.Size = New System.Drawing.Size(122, 20)
        Me.DateTimePickerDesde.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(22, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 13)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "Entorno de Fechas :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(45, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "Hasta"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(42, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 72
        Me.Label7.Text = "Desde"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FormInformeComprasRubArt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(498, 342)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormInformeComprasRubArt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormListaPlanilla"
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnReporte As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePickerDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LabelTituloFiltro As System.Windows.Forms.Label
    Friend WithEvents CtlComboRubrosHasta As Principal.CtlCustomCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CtlComboArticulosHasta As Principal.CtlCustomCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CtlComboRubrosDesde As Principal.CtlCustomCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CtlComboArticulosDesde As Principal.CtlCustomCombo
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
