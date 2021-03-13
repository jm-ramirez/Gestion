<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormArticulo
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolStripMenu = New System.Windows.Forms.ToolStrip()
        Me.BtnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.BtnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBoxId = New System.Windows.Forms.TextBox()
        Me.TextBoxNombre = New System.Windows.Forms.TextBox()
        Me.TextBoxDescripcion = New System.Windows.Forms.TextBox()
        Me.CheckBoxActivo = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxCodigoBarra = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextBoxCodigo = New System.Windows.Forms.TextBox()
        Me.CheckBoxOferta = New System.Windows.Forms.CheckBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.PanelStock = New System.Windows.Forms.Panel()
        Me.lblExistenciaActual = New System.Windows.Forms.Label()
        Me.lblExistencia = New System.Windows.Forms.Label()
        Me.CheckBoxModifica = New System.Windows.Forms.CheckBox()
        Me.ToolTipAyuda = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label35 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.FileSystemWatcher1 = New System.IO.FileSystemWatcher()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBoxAlicuotas = New System.Windows.Forms.ComboBox()
        Me.numPrecioVta = New System.Windows.Forms.NumericUpDown()
        Me.numPrecioVta2 = New System.Windows.Forms.NumericUpDown()
        Me.numPrecioVta3 = New System.Windows.Forms.NumericUpDown()
        Me.numCoeficienteKg = New System.Windows.Forms.NumericUpDown()
        Me.ComboBoxUnidades = New Principal.CtlCustomCombo()
        Me.ComboBoxRubros = New Principal.CtlCustomCombo()
        Me.CtlComboCategoria = New Principal.CtlCustomCombo()
        Me.ToolStripMenu.SuspendLayout()
        Me.PanelStock.SuspendLayout()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPrecioVta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPrecioVta2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPrecioVta3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCoeficienteKg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnGuardar, Me.BtnCancelar})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(488, 25)
        Me.ToolStripMenu.TabIndex = 0
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(83, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Id"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(55, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Nombre"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(36, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Descripción"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(58, 259)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 13)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "Unidad"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxId
        '
        Me.TextBoxId.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxId.Location = New System.Drawing.Point(105, 42)
        Me.TextBoxId.Name = "TextBoxId"
        Me.TextBoxId.Size = New System.Drawing.Size(75, 20)
        Me.TextBoxId.TabIndex = 0
        Me.TextBoxId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxNombre
        '
        Me.TextBoxNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxNombre.Location = New System.Drawing.Point(105, 97)
        Me.TextBoxNombre.Name = "TextBoxNombre"
        Me.TextBoxNombre.Size = New System.Drawing.Size(356, 20)
        Me.TextBoxNombre.TabIndex = 3
        '
        'TextBoxDescripcion
        '
        Me.TextBoxDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxDescripcion.Location = New System.Drawing.Point(105, 123)
        Me.TextBoxDescripcion.Multiline = True
        Me.TextBoxDescripcion.Name = "TextBoxDescripcion"
        Me.TextBoxDescripcion.Size = New System.Drawing.Size(356, 60)
        Me.TextBoxDescripcion.TabIndex = 4
        '
        'CheckBoxActivo
        '
        Me.CheckBoxActivo.AutoSize = True
        Me.CheckBoxActivo.Location = New System.Drawing.Point(197, 42)
        Me.CheckBoxActivo.Name = "CheckBoxActivo"
        Me.CheckBoxActivo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBoxActivo.Size = New System.Drawing.Size(56, 17)
        Me.CheckBoxActivo.TabIndex = 3
        Me.CheckBoxActivo.TabStop = False
        Me.CheckBoxActivo.Text = "Activo"
        Me.CheckBoxActivo.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(63, 226)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Rubro"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(231, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Código de barras"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxCodigoBarra
        '
        Me.TextBoxCodigoBarra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCodigoBarra.Location = New System.Drawing.Point(324, 71)
        Me.TextBoxCodigoBarra.MaxLength = 13
        Me.TextBoxCodigoBarra.Name = "TextBoxCodigoBarra"
        Me.TextBoxCodigoBarra.Size = New System.Drawing.Size(137, 20)
        Me.TextBoxCodigoBarra.TabIndex = 2
        Me.TextBoxCodigoBarra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(39, 338)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 58
        Me.Label5.Text = "Básico [ 1 ]"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(45, 195)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 13)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "Categoría"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(59, 76)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(40, 13)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "Código"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxCodigo
        '
        Me.TextBoxCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCodigo.Location = New System.Drawing.Point(105, 71)
        Me.TextBoxCodigo.MaxLength = 15
        Me.TextBoxCodigo.Name = "TextBoxCodigo"
        Me.TextBoxCodigo.Size = New System.Drawing.Size(115, 20)
        Me.TextBoxCodigo.TabIndex = 1
        Me.TextBoxCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CheckBoxOferta
        '
        Me.CheckBoxOferta.AutoSize = True
        Me.CheckBoxOferta.Location = New System.Drawing.Point(406, 42)
        Me.CheckBoxOferta.Name = "CheckBoxOferta"
        Me.CheckBoxOferta.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBoxOferta.Size = New System.Drawing.Size(55, 17)
        Me.CheckBoxOferta.TabIndex = 5
        Me.CheckBoxOferta.TabStop = False
        Me.CheckBoxOferta.Text = "Oferta"
        Me.CheckBoxOferta.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(39, 364)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(60, 13)
        Me.Label18.TabIndex = 65
        Me.Label18.Text = "Básico [ 2 ]"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(39, 390)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(60, 13)
        Me.Label19.TabIndex = 72
        Me.Label19.Text = "Básico [ 3 ]"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PanelStock
        '
        Me.PanelStock.BackColor = System.Drawing.Color.LightGreen
        Me.PanelStock.Controls.Add(Me.lblExistenciaActual)
        Me.PanelStock.Controls.Add(Me.lblExistencia)
        Me.PanelStock.Location = New System.Drawing.Point(86, 428)
        Me.PanelStock.Name = "PanelStock"
        Me.PanelStock.Size = New System.Drawing.Size(356, 34)
        Me.PanelStock.TabIndex = 15
        '
        'lblExistenciaActual
        '
        Me.lblExistenciaActual.AutoSize = True
        Me.lblExistenciaActual.Font = New System.Drawing.Font("Lucida Sans Typewriter", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExistenciaActual.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblExistenciaActual.Location = New System.Drawing.Point(205, 7)
        Me.lblExistenciaActual.Name = "lblExistenciaActual"
        Me.lblExistenciaActual.Size = New System.Drawing.Size(38, 18)
        Me.lblExistenciaActual.TabIndex = 1
        Me.lblExistenciaActual.Text = "0.0"
        Me.lblExistenciaActual.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblExistencia
        '
        Me.lblExistencia.AutoSize = True
        Me.lblExistencia.Font = New System.Drawing.Font("Lucida Sans Typewriter", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExistencia.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblExistencia.Location = New System.Drawing.Point(11, 7)
        Me.lblExistencia.Name = "lblExistencia"
        Me.lblExistencia.Size = New System.Drawing.Size(188, 18)
        Me.lblExistencia.TabIndex = 0
        Me.lblExistencia.Text = "Existencia Actual:"
        '
        'CheckBoxModifica
        '
        Me.CheckBoxModifica.AutoSize = True
        Me.CheckBoxModifica.Location = New System.Drawing.Point(259, 42)
        Me.CheckBoxModifica.Name = "CheckBoxModifica"
        Me.CheckBoxModifica.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBoxModifica.Size = New System.Drawing.Size(142, 17)
        Me.CheckBoxModifica.TabIndex = 4
        Me.CheckBoxModifica.TabStop = False
        Me.CheckBoxModifica.Text = "Pcio. de vta. modificable"
        Me.CheckBoxModifica.UseVisualStyleBackColor = True
        '
        'ToolTipAyuda
        '
        Me.ToolTipAyuda.BackColor = System.Drawing.Color.AliceBlue
        Me.ToolTipAyuda.ForeColor = System.Drawing.Color.DarkBlue
        Me.ToolTipAyuda.IsBalloon = True
        Me.ToolTipAyuda.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipAyuda.ToolTipTitle = "Ayuda"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(36, 285)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(63, 13)
        Me.Label35.TabIndex = 33
        Me.Label35.Text = "Coef. en Kg"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'FileSystemWatcher1
        '
        Me.FileSystemWatcher1.EnableRaisingEvents = True
        Me.FileSystemWatcher1.SynchronizingObject = Me
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 311)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 13)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Alícuota de I.V.A."
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboBoxAlicuotas
        '
        Me.ComboBoxAlicuotas.FormattingEnabled = True
        Me.ComboBoxAlicuotas.Location = New System.Drawing.Point(105, 308)
        Me.ComboBoxAlicuotas.Name = "ComboBoxAlicuotas"
        Me.ComboBoxAlicuotas.Size = New System.Drawing.Size(120, 21)
        Me.ComboBoxAlicuotas.TabIndex = 9
        '
        'numPrecioVta
        '
        Me.numPrecioVta.DecimalPlaces = 2
        Me.numPrecioVta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPrecioVta.Location = New System.Drawing.Point(105, 336)
        Me.numPrecioVta.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.numPrecioVta.Name = "numPrecioVta"
        Me.numPrecioVta.Size = New System.Drawing.Size(120, 22)
        Me.numPrecioVta.TabIndex = 10
        '
        'numPrecioVta2
        '
        Me.numPrecioVta2.DecimalPlaces = 2
        Me.numPrecioVta2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPrecioVta2.Location = New System.Drawing.Point(105, 362)
        Me.numPrecioVta2.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.numPrecioVta2.Name = "numPrecioVta2"
        Me.numPrecioVta2.Size = New System.Drawing.Size(120, 22)
        Me.numPrecioVta2.TabIndex = 11
        '
        'numPrecioVta3
        '
        Me.numPrecioVta3.DecimalPlaces = 2
        Me.numPrecioVta3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPrecioVta3.Location = New System.Drawing.Point(105, 387)
        Me.numPrecioVta3.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.numPrecioVta3.Name = "numPrecioVta3"
        Me.numPrecioVta3.Size = New System.Drawing.Size(120, 22)
        Me.numPrecioVta3.TabIndex = 12
        '
        'numCoeficienteKg
        '
        Me.numCoeficienteKg.DecimalPlaces = 2
        Me.numCoeficienteKg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numCoeficienteKg.Location = New System.Drawing.Point(105, 281)
        Me.numCoeficienteKg.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.numCoeficienteKg.Name = "numCoeficienteKg"
        Me.numCoeficienteKg.Size = New System.Drawing.Size(120, 20)
        Me.numCoeficienteKg.TabIndex = 8
        '
        'ComboBoxUnidades
        '
        Me.ComboBoxUnidades.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.ComboBoxUnidades.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.ComboBoxUnidades.BusquedaPorCodigobarra = False
        Me.ComboBoxUnidades.ColumnasExtras = Nothing
        Me.ComboBoxUnidades.CustomFormatArt = False
        Me.ComboBoxUnidades.DataSource = Nothing
        Me.ComboBoxUnidades.DisplayMember = Nothing
        Me.ComboBoxUnidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.ComboBoxUnidades.FormularioDeAlta = Nothing
        Me.ComboBoxUnidades.FormularioDeBusqueda = Nothing
        Me.ComboBoxUnidades.Location = New System.Drawing.Point(105, 251)
        Me.ComboBoxUnidades.MaximumSize = New System.Drawing.Size(500, 25)
        Me.ComboBoxUnidades.MinimumSize = New System.Drawing.Size(200, 25)
        Me.ComboBoxUnidades.Name = "ComboBoxUnidades"
        Me.ComboBoxUnidades.SelectedIndex = -1
        Me.ComboBoxUnidades.SelectedItem = Nothing
        Me.ComboBoxUnidades.SelectedText = ""
        Me.ComboBoxUnidades.SelectedValue = Nothing
        Me.ComboBoxUnidades.Size = New System.Drawing.Size(356, 25)
        Me.ComboBoxUnidades.TabIndex = 7
        Me.ComboBoxUnidades.ValueMember = Nothing
        '
        'ComboBoxRubros
        '
        Me.ComboBoxRubros.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.ComboBoxRubros.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.ComboBoxRubros.BusquedaPorCodigobarra = False
        Me.ComboBoxRubros.ColumnasExtras = Nothing
        Me.ComboBoxRubros.CustomFormatArt = False
        Me.ComboBoxRubros.DataSource = Nothing
        Me.ComboBoxRubros.DisplayMember = Nothing
        Me.ComboBoxRubros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.ComboBoxRubros.FormularioDeAlta = Nothing
        Me.ComboBoxRubros.FormularioDeBusqueda = Nothing
        Me.ComboBoxRubros.Location = New System.Drawing.Point(105, 220)
        Me.ComboBoxRubros.MaximumSize = New System.Drawing.Size(500, 25)
        Me.ComboBoxRubros.MinimumSize = New System.Drawing.Size(200, 25)
        Me.ComboBoxRubros.Name = "ComboBoxRubros"
        Me.ComboBoxRubros.SelectedIndex = -1
        Me.ComboBoxRubros.SelectedItem = Nothing
        Me.ComboBoxRubros.SelectedText = ""
        Me.ComboBoxRubros.SelectedValue = Nothing
        Me.ComboBoxRubros.Size = New System.Drawing.Size(356, 25)
        Me.ComboBoxRubros.TabIndex = 6
        Me.ComboBoxRubros.ValueMember = Nothing
        '
        'CtlComboCategoria
        '
        Me.CtlComboCategoria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlComboCategoria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlComboCategoria.BusquedaPorCodigobarra = False
        Me.CtlComboCategoria.ColumnasExtras = Nothing
        Me.CtlComboCategoria.CustomFormatArt = False
        Me.CtlComboCategoria.DataSource = Nothing
        Me.CtlComboCategoria.DisplayMember = Nothing
        Me.CtlComboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CtlComboCategoria.FormularioDeAlta = Nothing
        Me.CtlComboCategoria.FormularioDeBusqueda = Nothing
        Me.CtlComboCategoria.Location = New System.Drawing.Point(105, 189)
        Me.CtlComboCategoria.MaximumSize = New System.Drawing.Size(500, 25)
        Me.CtlComboCategoria.MinimumSize = New System.Drawing.Size(200, 25)
        Me.CtlComboCategoria.Name = "CtlComboCategoria"
        Me.CtlComboCategoria.SelectedIndex = -1
        Me.CtlComboCategoria.SelectedItem = Nothing
        Me.CtlComboCategoria.SelectedText = ""
        Me.CtlComboCategoria.SelectedValue = Nothing
        Me.CtlComboCategoria.Size = New System.Drawing.Size(356, 25)
        Me.CtlComboCategoria.TabIndex = 5
        Me.CtlComboCategoria.ValueMember = Nothing
        '
        'FormArticulo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(488, 481)
        Me.Controls.Add(Me.numCoeficienteKg)
        Me.Controls.Add(Me.numPrecioVta3)
        Me.Controls.Add(Me.numPrecioVta2)
        Me.Controls.Add(Me.numPrecioVta)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.PanelStock)
        Me.Controls.Add(Me.ComboBoxUnidades)
        Me.Controls.Add(Me.ComboBoxRubros)
        Me.Controls.Add(Me.CtlComboCategoria)
        Me.Controls.Add(Me.ComboBoxAlicuotas)
        Me.Controls.Add(Me.CheckBoxModifica)
        Me.Controls.Add(Me.CheckBoxOferta)
        Me.Controls.Add(Me.CheckBoxActivo)
        Me.Controls.Add(Me.TextBoxDescripcion)
        Me.Controls.Add(Me.TextBoxNombre)
        Me.Controls.Add(Me.TextBoxCodigo)
        Me.Controls.Add(Me.TextBoxCodigoBarra)
        Me.Controls.Add(Me.TextBoxId)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormArticulo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = " "
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.PanelStock.ResumeLayout(False)
        Me.PanelStock.PerformLayout()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPrecioVta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPrecioVta2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPrecioVta3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCoeficienteKg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBoxId As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNombre As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents CheckBoxActivo As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxCodigoBarra As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CtlComboCategoria As Principal.CtlCustomCombo
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxRubros As Principal.CtlCustomCombo
    Friend WithEvents ComboBoxUnidades As Principal.CtlCustomCombo
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TextBoxCodigo As System.Windows.Forms.TextBox
    Friend WithEvents CheckBoxOferta As System.Windows.Forms.CheckBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents PanelStock As System.Windows.Forms.Panel
    Friend WithEvents lblExistenciaActual As System.Windows.Forms.Label
    Friend WithEvents lblExistencia As System.Windows.Forms.Label
    Friend WithEvents CheckBoxModifica As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTipAyuda As System.Windows.Forms.ToolTip
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents FileSystemWatcher1 As System.IO.FileSystemWatcher
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ComboBoxAlicuotas As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents numPrecioVta3 As NumericUpDown
    Friend WithEvents numPrecioVta2 As NumericUpDown
    Friend WithEvents numPrecioVta As NumericUpDown
    Friend WithEvents numCoeficienteKg As NumericUpDown
End Class
