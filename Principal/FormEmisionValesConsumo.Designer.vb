<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmisionValesConsumo
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
        Me.BtnCargar = New System.Windows.Forms.ToolStripButton()
        Me.BtnSalir = New System.Windows.Forms.ToolStripButton()
        Me.GroupBoxCDC = New System.Windows.Forms.GroupBox()
        Me.CtlComboImpNegativa = New Principal.CtlCustomCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBoxObservacion = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxVale = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.numCantidad = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.FOLVRegistros = New BrightIdeasSoftware.FastObjectListView()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.CtlComboMaterial = New Principal.CtlCustomCombo()
        Me.DTPFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStripMenu.SuspendLayout()
        Me.GroupBoxCDC.SuspendLayout()
        CType(Me.numCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FOLVRegistros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnCargar, Me.BtnSalir})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(646, 25)
        Me.ToolStripMenu.TabIndex = 0
        Me.ToolStripMenu.Text = "ToolStrip1"
        '
        'BtnCargar
        '
        Me.BtnCargar.Image = Global.Principal.My.Resources.Resources.disk
        Me.BtnCargar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCargar.Name = "BtnCargar"
        Me.BtnCargar.Size = New System.Drawing.Size(100, 22)
        Me.BtnCargar.Text = "Registrar [F12]"
        '
        'BtnSalir
        '
        Me.BtnSalir.Image = Global.Principal.My.Resources.Resources.door_out
        Me.BtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(74, 22)
        Me.BtnSalir.Text = "Salir [Esc]"
        '
        'GroupBoxCDC
        '
        Me.GroupBoxCDC.Controls.Add(Me.CtlComboImpNegativa)
        Me.GroupBoxCDC.Controls.Add(Me.Label5)
        Me.GroupBoxCDC.Controls.Add(Me.TextBoxObservacion)
        Me.GroupBoxCDC.Controls.Add(Me.Label4)
        Me.GroupBoxCDC.Controls.Add(Me.TextBoxVale)
        Me.GroupBoxCDC.Controls.Add(Me.Label3)
        Me.GroupBoxCDC.Controls.Add(Me.numCantidad)
        Me.GroupBoxCDC.Controls.Add(Me.Label6)
        Me.GroupBoxCDC.Controls.Add(Me.FOLVRegistros)
        Me.GroupBoxCDC.Controls.Add(Me.btnQuitar)
        Me.GroupBoxCDC.Controls.Add(Me.btnAgregar)
        Me.GroupBoxCDC.Controls.Add(Me.CtlComboMaterial)
        Me.GroupBoxCDC.Controls.Add(Me.DTPFecha)
        Me.GroupBoxCDC.Controls.Add(Me.Label2)
        Me.GroupBoxCDC.Controls.Add(Me.Label1)
        Me.GroupBoxCDC.Location = New System.Drawing.Point(0, 28)
        Me.GroupBoxCDC.Name = "GroupBoxCDC"
        Me.GroupBoxCDC.Size = New System.Drawing.Size(646, 413)
        Me.GroupBoxCDC.TabIndex = 1
        Me.GroupBoxCDC.TabStop = False
        '
        'CtlComboImpNegativa
        '
        Me.CtlComboImpNegativa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlComboImpNegativa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlComboImpNegativa.BusquedaPorCodigobarra = False
        Me.CtlComboImpNegativa.ColumnasExtras = Nothing
        Me.CtlComboImpNegativa.CustomFormatArt = False
        Me.CtlComboImpNegativa.DataSource = Nothing
        Me.CtlComboImpNegativa.DisplayMember = Nothing
        Me.CtlComboImpNegativa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CtlComboImpNegativa.FormularioDeAlta = Nothing
        Me.CtlComboImpNegativa.FormularioDeBusqueda = Nothing
        Me.CtlComboImpNegativa.Location = New System.Drawing.Point(154, 298)
        Me.CtlComboImpNegativa.MaximumSize = New System.Drawing.Size(500, 25)
        Me.CtlComboImpNegativa.MinimumSize = New System.Drawing.Size(200, 25)
        Me.CtlComboImpNegativa.Name = "CtlComboImpNegativa"
        Me.CtlComboImpNegativa.SelectedIndex = -1
        Me.CtlComboImpNegativa.SelectedItem = Nothing
        Me.CtlComboImpNegativa.SelectedText = ""
        Me.CtlComboImpNegativa.SelectedValue = Nothing
        Me.CtlComboImpNegativa.Size = New System.Drawing.Size(343, 25)
        Me.CtlComboImpNegativa.TabIndex = 8
        Me.CtlComboImpNegativa.ValueMember = Nothing
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(72, 303)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "Imp. de Egreso"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxObservacion
        '
        Me.TextBoxObservacion.Location = New System.Drawing.Point(175, 347)
        Me.TextBoxObservacion.MaxLength = 135
        Me.TextBoxObservacion.Multiline = True
        Me.TextBoxObservacion.Name = "TextBoxObservacion"
        Me.TextBoxObservacion.Size = New System.Drawing.Size(322, 63)
        Me.TextBoxObservacion.TabIndex = 9
        Me.TextBoxObservacion.Tag = "observacion"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(92, 350)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Observaciones"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxVale
        '
        Me.TextBoxVale.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxVale.Location = New System.Drawing.Point(424, 19)
        Me.TextBoxVale.Name = "TextBoxVale"
        Me.TextBoxVale.ReadOnly = True
        Me.TextBoxVale.Size = New System.Drawing.Size(73, 20)
        Me.TextBoxVale.TabIndex = 2
        Me.TextBoxVale.TabStop = False
        Me.TextBoxVale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(355, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Nro de Vale"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'numCantidad
        '
        Me.numCantidad.DecimalPlaces = 2
        Me.numCantidad.Location = New System.Drawing.Point(135, 82)
        Me.numCantidad.Maximum = New Decimal(New Integer() {999999, 0, 0, 131072})
        Me.numCantidad.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numCantidad.Name = "numCantidad"
        Me.numCantidad.Size = New System.Drawing.Size(63, 20)
        Me.numCantidad.TabIndex = 4
        Me.numCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numCantidad.ThousandsSeparator = True
        Me.numCantidad.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(80, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "Cantidad"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FOLVRegistros
        '
        Me.FOLVRegistros.AlternateRowBackColor = System.Drawing.Color.LightSteelBlue
        Me.FOLVRegistros.CellEditEnterChangesRows = True
        Me.FOLVRegistros.EmptyListMsg = "No hay datos para mostrar"
        Me.FOLVRegistros.FullRowSelect = True
        Me.FOLVRegistros.Location = New System.Drawing.Point(12, 160)
        Me.FOLVRegistros.Name = "FOLVRegistros"
        Me.FOLVRegistros.ShowGroups = False
        Me.FOLVRegistros.ShowHeaderInAllViews = False
        Me.FOLVRegistros.Size = New System.Drawing.Size(622, 132)
        Me.FOLVRegistros.TabIndex = 7
        Me.FOLVRegistros.UseAlternatingBackColors = True
        Me.FOLVRegistros.UseCellFormatEvents = True
        Me.FOLVRegistros.UseCompatibleStateImageBehavior = False
        Me.FOLVRegistros.View = System.Windows.Forms.View.Details
        Me.FOLVRegistros.VirtualMode = True
        '
        'btnQuitar
        '
        Me.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQuitar.Location = New System.Drawing.Point(331, 115)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(75, 23)
        Me.btnQuitar.TabIndex = 6
        Me.btnQuitar.Text = "Quitar"
        Me.btnQuitar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.Location = New System.Drawing.Point(184, 115)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregar.TabIndex = 5
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'CtlComboMaterial
        '
        Me.CtlComboMaterial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlComboMaterial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlComboMaterial.BusquedaPorCodigobarra = False
        Me.CtlComboMaterial.ColumnasExtras = Nothing
        Me.CtlComboMaterial.CustomFormatArt = False
        Me.CtlComboMaterial.DataSource = Nothing
        Me.CtlComboMaterial.DisplayMember = Nothing
        Me.CtlComboMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CtlComboMaterial.FormularioDeAlta = Nothing
        Me.CtlComboMaterial.FormularioDeBusqueda = Nothing
        Me.CtlComboMaterial.Location = New System.Drawing.Point(135, 48)
        Me.CtlComboMaterial.MaximumSize = New System.Drawing.Size(500, 25)
        Me.CtlComboMaterial.MinimumSize = New System.Drawing.Size(200, 25)
        Me.CtlComboMaterial.Name = "CtlComboMaterial"
        Me.CtlComboMaterial.SelectedIndex = -1
        Me.CtlComboMaterial.SelectedItem = Nothing
        Me.CtlComboMaterial.SelectedText = ""
        Me.CtlComboMaterial.SelectedValue = Nothing
        Me.CtlComboMaterial.Size = New System.Drawing.Size(362, 25)
        Me.CtlComboMaterial.TabIndex = 3
        Me.CtlComboMaterial.ValueMember = Nothing
        '
        'DTPFecha
        '
        Me.DTPFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFecha.Location = New System.Drawing.Point(135, 19)
        Me.DTPFecha.Name = "DTPFecha"
        Me.DTPFecha.Size = New System.Drawing.Size(95, 20)
        Me.DTPFecha.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(92, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Fecha"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(85, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Material"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FormEmisionValesConsumo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(646, 453)
        Me.Controls.Add(Me.GroupBoxCDC)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormEmisionValesConsumo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Carga de Modelos"
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.GroupBoxCDC.ResumeLayout(False)
        Me.GroupBoxCDC.PerformLayout()
        CType(Me.numCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FOLVRegistros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnCargar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBoxCDC As System.Windows.Forms.GroupBox
    Friend WithEvents DTPFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnQuitar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents FOLVRegistros As BrightIdeasSoftware.FastObjectListView
    Friend WithEvents numCantidad As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxVale As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CtlComboMaterial As Principal.CtlCustomCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CtlComboImpNegativa As Principal.CtlCustomCombo
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
