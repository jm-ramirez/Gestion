<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInventario
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
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.TextBoxFilter = New System.Windows.Forms.ToolStripTextBox()
        Me.BtnFiltrar = New System.Windows.Forms.ToolStripButton()
        Me.BtnBorrarFiltro = New System.Windows.Forms.ToolStripButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.FOLVRegistros = New BrightIdeasSoftware.FastObjectListView()
        Me.GroupBoxArticulo = New System.Windows.Forms.GroupBox()
        Me.BtnActualizarArticulo = New System.Windows.Forms.Button()
        Me.CheckBoxTodos = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.NumericUpDownReal = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownActual = New System.Windows.Forms.NumericUpDown()
        Me.CtlComboArticulo = New Principal.CtlCustomCombo()
        Me.ToolStripMenu.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.FOLVRegistros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxArticulo.SuspendLayout()
        CType(Me.NumericUpDownReal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownActual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnGuardar, Me.BtnCancelar, Me.ToolStripSeparator3, Me.TextBoxFilter, Me.BtnFiltrar, Me.BtnBorrarFiltro})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(775, 25)
        Me.ToolStripMenu.TabIndex = 1
        Me.ToolStripMenu.Text = "ToolStrip1"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Image = Global.Principal.My.Resources.Resources.disk
        Me.BtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(98, 22)
        Me.BtnGuardar.Text = "Guardar [F12]"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = Global.Principal.My.Resources.Resources.cancel
        Me.BtnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(101, 22)
        Me.BtnCancelar.Text = "Cancelar [Esc]"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'TextBoxFilter
        '
        Me.TextBoxFilter.Name = "TextBoxFilter"
        Me.TextBoxFilter.Size = New System.Drawing.Size(100, 25)
        '
        'BtnFiltrar
        '
        Me.BtnFiltrar.Image = Global.Principal.My.Resources.Resources.filter
        Me.BtnFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFiltrar.Name = "BtnFiltrar"
        Me.BtnFiltrar.Size = New System.Drawing.Size(57, 22)
        Me.BtnFiltrar.Text = "Filtrar"
        '
        'BtnBorrarFiltro
        '
        Me.BtnBorrarFiltro.Image = Global.Principal.My.Resources.Resources.clearFilter
        Me.BtnBorrarFiltro.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnBorrarFiltro.Name = "BtnBorrarFiltro"
        Me.BtnBorrarFiltro.Size = New System.Drawing.Size(88, 22)
        Me.BtnBorrarFiltro.Text = "Quitar filtro"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.FOLVRegistros, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBoxArticulo, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 25)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.27966!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.72034!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(775, 472)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'FOLVRegistros
        '
        Me.FOLVRegistros.AlternateRowBackColor = System.Drawing.Color.LightSteelBlue
        Me.FOLVRegistros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FOLVRegistros.EmptyListMsg = "No hay datos para mostrar"
        Me.FOLVRegistros.FullRowSelect = True
        Me.FOLVRegistros.Location = New System.Drawing.Point(3, 93)
        Me.FOLVRegistros.Name = "FOLVRegistros"
        Me.FOLVRegistros.ShowGroups = False
        Me.FOLVRegistros.ShowHeaderInAllViews = False
        Me.FOLVRegistros.Size = New System.Drawing.Size(769, 376)
        Me.FOLVRegistros.TabIndex = 1
        Me.FOLVRegistros.UseAlternatingBackColors = True
        Me.FOLVRegistros.UseCompatibleStateImageBehavior = False
        Me.FOLVRegistros.View = System.Windows.Forms.View.Details
        Me.FOLVRegistros.VirtualMode = True
        '
        'GroupBoxArticulo
        '
        Me.GroupBoxArticulo.Controls.Add(Me.BtnActualizarArticulo)
        Me.GroupBoxArticulo.Controls.Add(Me.CheckBoxTodos)
        Me.GroupBoxArticulo.Controls.Add(Me.Label2)
        Me.GroupBoxArticulo.Controls.Add(Me.Label1)
        Me.GroupBoxArticulo.Controls.Add(Me.Label14)
        Me.GroupBoxArticulo.Controls.Add(Me.NumericUpDownReal)
        Me.GroupBoxArticulo.Controls.Add(Me.NumericUpDownActual)
        Me.GroupBoxArticulo.Controls.Add(Me.CtlComboArticulo)
        Me.GroupBoxArticulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxArticulo.Location = New System.Drawing.Point(3, 3)
        Me.GroupBoxArticulo.Name = "GroupBoxArticulo"
        Me.GroupBoxArticulo.Size = New System.Drawing.Size(769, 84)
        Me.GroupBoxArticulo.TabIndex = 0
        Me.GroupBoxArticulo.TabStop = False
        Me.GroupBoxArticulo.Text = "Artículo"
        '
        'BtnActualizarArticulo
        '
        Me.BtnActualizarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnActualizarArticulo.Image = Global.Principal.My.Resources.Resources.add
        Me.BtnActualizarArticulo.Location = New System.Drawing.Point(659, 54)
        Me.BtnActualizarArticulo.Name = "BtnActualizarArticulo"
        Me.BtnActualizarArticulo.Size = New System.Drawing.Size(79, 21)
        Me.BtnActualizarArticulo.TabIndex = 4
        Me.BtnActualizarArticulo.UseVisualStyleBackColor = True
        '
        'CheckBoxTodos
        '
        Me.CheckBoxTodos.Location = New System.Drawing.Point(659, 19)
        Me.CheckBoxTodos.Name = "CheckBoxTodos"
        Me.CheckBoxTodos.Size = New System.Drawing.Size(106, 31)
        Me.CheckBoxTodos.TabIndex = 5
        Me.CheckBoxTodos.TabStop = False
        Me.CheckBoxTodos.Text = "Mostrar todos los artículos"
        Me.CheckBoxTodos.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Location = New System.Drawing.Point(570, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Real"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(481, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Actual"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Gainsboro
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Location = New System.Drawing.Point(6, 28)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(469, 23)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Artículo"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NumericUpDownReal
        '
        Me.NumericUpDownReal.DecimalPlaces = 2
        Me.NumericUpDownReal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericUpDownReal.Location = New System.Drawing.Point(570, 54)
        Me.NumericUpDownReal.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.NumericUpDownReal.Minimum = New Decimal(New Integer() {99999, 0, 0, -2147483648})
        Me.NumericUpDownReal.Name = "NumericUpDownReal"
        Me.NumericUpDownReal.Size = New System.Drawing.Size(83, 22)
        Me.NumericUpDownReal.TabIndex = 2
        Me.NumericUpDownReal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NumericUpDownActual
        '
        Me.NumericUpDownActual.BackColor = System.Drawing.Color.PaleGreen
        Me.NumericUpDownActual.DecimalPlaces = 2
        Me.NumericUpDownActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericUpDownActual.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumericUpDownActual.InterceptArrowKeys = False
        Me.NumericUpDownActual.Location = New System.Drawing.Point(481, 54)
        Me.NumericUpDownActual.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.NumericUpDownActual.Minimum = New Decimal(New Integer() {99999, 0, 0, -2147483648})
        Me.NumericUpDownActual.Name = "NumericUpDownActual"
        Me.NumericUpDownActual.ReadOnly = True
        Me.NumericUpDownActual.Size = New System.Drawing.Size(83, 22)
        Me.NumericUpDownActual.TabIndex = 1
        Me.NumericUpDownActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CtlComboArticulo
        '
        Me.CtlComboArticulo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlComboArticulo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlComboArticulo.BusquedaPorCodigobarra = False
        Me.CtlComboArticulo.ColumnasExtras = Nothing
        Me.CtlComboArticulo.CustomFormatArt = False
        Me.CtlComboArticulo.DataSource = Nothing
        Me.CtlComboArticulo.DisplayMember = Nothing
        Me.CtlComboArticulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CtlComboArticulo.FormularioDeAlta = Nothing
        Me.CtlComboArticulo.FormularioDeBusqueda = Nothing
        Me.CtlComboArticulo.Location = New System.Drawing.Point(6, 54)
        Me.CtlComboArticulo.MaximumSize = New System.Drawing.Size(500, 25)
        Me.CtlComboArticulo.MinimumSize = New System.Drawing.Size(200, 25)
        Me.CtlComboArticulo.Name = "CtlComboArticulo"
        Me.CtlComboArticulo.SelectedIndex = -1
        Me.CtlComboArticulo.SelectedItem = Nothing
        Me.CtlComboArticulo.SelectedText = ""
        Me.CtlComboArticulo.SelectedValue = Nothing
        Me.CtlComboArticulo.Size = New System.Drawing.Size(469, 25)
        Me.CtlComboArticulo.TabIndex = 0
        Me.CtlComboArticulo.Tag = ""
        Me.CtlComboArticulo.ValueMember = Nothing
        '
        'FormInventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(775, 497)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.KeyPreview = True
        Me.Name = "FormInventario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormArticulo"
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.FOLVRegistros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxArticulo.ResumeLayout(False)
        CType(Me.NumericUpDownReal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownActual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TextBoxFilter As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BtnFiltrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnBorrarFiltro As System.Windows.Forms.ToolStripButton
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FOLVRegistros As BrightIdeasSoftware.FastObjectListView
    Friend WithEvents GroupBoxArticulo As System.Windows.Forms.GroupBox
    Friend WithEvents NumericUpDownReal As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDownActual As System.Windows.Forms.NumericUpDown
    Friend WithEvents CtlComboArticulo As Principal.CtlCustomCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxTodos As System.Windows.Forms.CheckBox
    Friend WithEvents BtnActualizarArticulo As System.Windows.Forms.Button
End Class
