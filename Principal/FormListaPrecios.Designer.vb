<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormListaPrecios
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePickerEmision = New System.Windows.Forms.DateTimePicker()
        Me.CheckBoxOferta = New System.Windows.Forms.CheckBox()
        Me.CheckBoxSinImp = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CheckBoxRubro = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optDescripcion = New System.Windows.Forms.RadioButton()
        Me.optCodigo = New System.Windows.Forms.RadioButton()
        Me.CtlComboLista = New Principal.CtlCustomCombo()
        Me.CtlComboRubroDesde = New Principal.CtlCustomCombo()
        Me.CtlComboRubroHasta = New Principal.CtlCustomCombo()
        Me.ToolStripMenu.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnReporte, Me.BtnCancelar})
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
        Me.BtnReporte.Size = New System.Drawing.Size(112, 22)
        Me.BtnReporte.Text = "Generar Reporte"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = Global.Principal.My.Resources.Resources.cancel
        Me.BtnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(73, 22)
        Me.BtnCancelar.Text = "Cancelar"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(53, 143)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Rubro hasta"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CheckBoxTodos
        '
        Me.CheckBoxTodos.Location = New System.Drawing.Point(27, 83)
        Me.CheckBoxTodos.Name = "CheckBoxTodos"
        Me.CheckBoxTodos.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBoxTodos.Size = New System.Drawing.Size(110, 17)
        Me.CheckBoxTodos.TabIndex = 1
        Me.CheckBoxTodos.Text = "Todos los Rubros"
        Me.CheckBoxTodos.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(41, 174)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Lista de Precio"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(75, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Emisión"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DateTimePickerEmision
        '
        Me.DateTimePickerEmision.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerEmision.Location = New System.Drawing.Point(124, 57)
        Me.DateTimePickerEmision.Name = "DateTimePickerEmision"
        Me.DateTimePickerEmision.Size = New System.Drawing.Size(90, 20)
        Me.DateTimePickerEmision.TabIndex = 0
        '
        'CheckBoxOferta
        '
        Me.CheckBoxOferta.Location = New System.Drawing.Point(27, 199)
        Me.CheckBoxOferta.Name = "CheckBoxOferta"
        Me.CheckBoxOferta.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBoxOferta.Size = New System.Drawing.Size(110, 17)
        Me.CheckBoxOferta.TabIndex = 5
        Me.CheckBoxOferta.Text = "Ofertas"
        Me.CheckBoxOferta.UseVisualStyleBackColor = True
        '
        'CheckBoxSinImp
        '
        Me.CheckBoxSinImp.Location = New System.Drawing.Point(6, 222)
        Me.CheckBoxSinImp.Name = "CheckBoxSinImp"
        Me.CheckBoxSinImp.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBoxSinImp.Size = New System.Drawing.Size(131, 17)
        Me.CheckBoxSinImp.TabIndex = 6
        Me.CheckBoxSinImp.Text = "Incluye Precios netos"
        Me.CheckBoxSinImp.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(50, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Rubro desde"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CheckBoxRubro
        '
        Me.CheckBoxRubro.Location = New System.Drawing.Point(56, 333)
        Me.CheckBoxRubro.Name = "CheckBoxRubro"
        Me.CheckBoxRubro.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBoxRubro.Size = New System.Drawing.Size(145, 19)
        Me.CheckBoxRubro.TabIndex = 10
        Me.CheckBoxRubro.Text = "Agrupar por Rubros"
        Me.CheckBoxRubro.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optDescripcion)
        Me.GroupBox1.Controls.Add(Me.optCodigo)
        Me.GroupBox1.Location = New System.Drawing.Point(69, 264)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(295, 55)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ordenar Por:"
        '
        'optDescripcion
        '
        Me.optDescripcion.AutoSize = True
        Me.optDescripcion.Location = New System.Drawing.Point(172, 20)
        Me.optDescripcion.Name = "optDescripcion"
        Me.optDescripcion.Size = New System.Drawing.Size(81, 17)
        Me.optDescripcion.TabIndex = 11
        Me.optDescripcion.Text = "Descripción"
        Me.optDescripcion.UseVisualStyleBackColor = True
        '
        'optCodigo
        '
        Me.optCodigo.AutoSize = True
        Me.optCodigo.Checked = True
        Me.optCodigo.Location = New System.Drawing.Point(68, 20)
        Me.optCodigo.Name = "optCodigo"
        Me.optCodigo.Size = New System.Drawing.Size(58, 17)
        Me.optCodigo.TabIndex = 10
        Me.optCodigo.TabStop = True
        Me.optCodigo.Text = "Codigo"
        Me.optCodigo.UseVisualStyleBackColor = True
        '
        'CtlComboLista
        '
        Me.CtlComboLista.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlComboLista.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlComboLista.BusquedaPorCodigobarra = False
        Me.CtlComboLista.ColumnasExtras = Nothing
        Me.CtlComboLista.CustomFormatArt = False
        Me.CtlComboLista.DataSource = Nothing
        Me.CtlComboLista.DisplayMember = Nothing
        Me.CtlComboLista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CtlComboLista.FormularioDeAlta = Nothing
        Me.CtlComboLista.FormularioDeBusqueda = Nothing
        Me.CtlComboLista.Location = New System.Drawing.Point(124, 168)
        Me.CtlComboLista.MaximumSize = New System.Drawing.Size(500, 25)
        Me.CtlComboLista.MinimumSize = New System.Drawing.Size(200, 25)
        Me.CtlComboLista.Name = "CtlComboLista"
        Me.CtlComboLista.SelectedIndex = -1
        Me.CtlComboLista.SelectedItem = Nothing
        Me.CtlComboLista.SelectedText = ""
        Me.CtlComboLista.SelectedValue = Nothing
        Me.CtlComboLista.Size = New System.Drawing.Size(311, 25)
        Me.CtlComboLista.TabIndex = 4
        Me.CtlComboLista.ValueMember = Nothing
        '
        'CtlComboRubroDesde
        '
        Me.CtlComboRubroDesde.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlComboRubroDesde.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlComboRubroDesde.BusquedaPorCodigobarra = False
        Me.CtlComboRubroDesde.ColumnasExtras = Nothing
        Me.CtlComboRubroDesde.CustomFormatArt = False
        Me.CtlComboRubroDesde.DataSource = Nothing
        Me.CtlComboRubroDesde.DisplayMember = Nothing
        Me.CtlComboRubroDesde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CtlComboRubroDesde.FormularioDeAlta = Nothing
        Me.CtlComboRubroDesde.FormularioDeBusqueda = Nothing
        Me.CtlComboRubroDesde.Location = New System.Drawing.Point(124, 106)
        Me.CtlComboRubroDesde.MaximumSize = New System.Drawing.Size(500, 25)
        Me.CtlComboRubroDesde.MinimumSize = New System.Drawing.Size(200, 25)
        Me.CtlComboRubroDesde.Name = "CtlComboRubroDesde"
        Me.CtlComboRubroDesde.SelectedIndex = -1
        Me.CtlComboRubroDesde.SelectedItem = Nothing
        Me.CtlComboRubroDesde.SelectedText = ""
        Me.CtlComboRubroDesde.SelectedValue = Nothing
        Me.CtlComboRubroDesde.Size = New System.Drawing.Size(311, 25)
        Me.CtlComboRubroDesde.TabIndex = 2
        Me.CtlComboRubroDesde.ValueMember = Nothing
        '
        'CtlComboRubroHasta
        '
        Me.CtlComboRubroHasta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlComboRubroHasta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlComboRubroHasta.BusquedaPorCodigobarra = False
        Me.CtlComboRubroHasta.ColumnasExtras = Nothing
        Me.CtlComboRubroHasta.CustomFormatArt = False
        Me.CtlComboRubroHasta.DataSource = Nothing
        Me.CtlComboRubroHasta.DisplayMember = Nothing
        Me.CtlComboRubroHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CtlComboRubroHasta.FormularioDeAlta = Nothing
        Me.CtlComboRubroHasta.FormularioDeBusqueda = Nothing
        Me.CtlComboRubroHasta.Location = New System.Drawing.Point(124, 137)
        Me.CtlComboRubroHasta.MaximumSize = New System.Drawing.Size(500, 25)
        Me.CtlComboRubroHasta.MinimumSize = New System.Drawing.Size(200, 25)
        Me.CtlComboRubroHasta.Name = "CtlComboRubroHasta"
        Me.CtlComboRubroHasta.SelectedIndex = -1
        Me.CtlComboRubroHasta.SelectedItem = Nothing
        Me.CtlComboRubroHasta.SelectedText = ""
        Me.CtlComboRubroHasta.SelectedValue = Nothing
        Me.CtlComboRubroHasta.Size = New System.Drawing.Size(311, 25)
        Me.CtlComboRubroHasta.TabIndex = 3
        Me.CtlComboRubroHasta.ValueMember = Nothing
        '
        'FormListaPrecios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(463, 369)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CheckBoxRubro)
        Me.Controls.Add(Me.DateTimePickerEmision)
        Me.Controls.Add(Me.CheckBoxSinImp)
        Me.Controls.Add(Me.CheckBoxOferta)
        Me.Controls.Add(Me.CheckBoxTodos)
        Me.Controls.Add(Me.CtlComboLista)
        Me.Controls.Add(Me.CtlComboRubroDesde)
        Me.Controls.Add(Me.CtlComboRubroHasta)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormListaPrecios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormArticulo"
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
    Friend WithEvents CtlComboRubroHasta As Principal.CtlCustomCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxTodos As System.Windows.Forms.CheckBox
    Friend WithEvents CtlComboLista As Principal.CtlCustomCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerEmision As System.Windows.Forms.DateTimePicker
    Friend WithEvents CheckBoxOferta As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxSinImp As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CtlComboRubroDesde As Principal.CtlCustomCombo
    Friend WithEvents CheckBoxRubro As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optDescripcion As System.Windows.Forms.RadioButton
    Friend WithEvents optCodigo As System.Windows.Forms.RadioButton
End Class
