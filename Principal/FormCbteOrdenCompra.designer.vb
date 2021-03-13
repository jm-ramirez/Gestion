<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCbteOrdenCompra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCbteOrdenCompra))
        Me.ToolStripMenu = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonAutorizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonCancelar = New System.Windows.Forms.ToolStripButton()
        Me.GroupBoxDatosCliente = New System.Windows.Forms.GroupBox()
        Me.TextBoxNumero = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.DTPFecha = New System.Windows.Forms.DateTimePicker()
        Me.TextBoxTelefono = New System.Windows.Forms.TextBox()
        Me.ComboBoxDomicilios = New System.Windows.Forms.ComboBox()
        Me.ComboBoxCliente = New Principal.CtlCustomCombo()
        Me.TextBoxDomicilio = New System.Windows.Forms.TextBox()
        Me.TextBoxNombre = New System.Windows.Forms.TextBox()
        Me.TextBoxDocumento = New System.Windows.Forms.TextBox()
        Me.ComboBoxDocumento = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBoxDatosArticulos = New System.Windows.Forms.GroupBox()
        Me.FOLVArticulos = New BrightIdeasSoftware.FastObjectListView()
        Me.TextBoxUnidad = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBoxKxU = New System.Windows.Forms.TextBox()
        Me.LabelTotal = New System.Windows.Forms.Label()
        Me.ComboBoxArticulos = New Principal.CtlCustomCombo()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.BtnAgregarArticulo = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TextBoxPrecio = New System.Windows.Forms.TextBox()
        Me.TextBoxCantidad = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TextBoxSubtotalArticulo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBoxObservacion = New System.Windows.Forms.TextBox()
        Me.ToolStripMenu.SuspendLayout()
        Me.GroupBoxDatosCliente.SuspendLayout()
        Me.GroupBoxDatosArticulos.SuspendLayout()
        CType(Me.FOLVArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonAutorizar, Me.ToolStripSeparator1, Me.ToolStripButtonCancelar})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStripMenu.Size = New System.Drawing.Size(884, 25)
        Me.ToolStripMenu.TabIndex = 2
        Me.ToolStripMenu.Text = "ToolStrip1"
        '
        'ToolStripButtonAutorizar
        '
        Me.ToolStripButtonAutorizar.Image = Global.Principal.My.Resources.Resources.server_go
        Me.ToolStripButtonAutorizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonAutorizar.Name = "ToolStripButtonAutorizar"
        Me.ToolStripButtonAutorizar.Size = New System.Drawing.Size(135, 22)
        Me.ToolStripButtonAutorizar.Text = "Autorizar Cbte. [F12]"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButtonCancelar
        '
        Me.ToolStripButtonCancelar.Image = Global.Principal.My.Resources.Resources.cancel
        Me.ToolStripButtonCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonCancelar.Name = "ToolStripButtonCancelar"
        Me.ToolStripButtonCancelar.Size = New System.Drawing.Size(101, 22)
        Me.ToolStripButtonCancelar.Text = "Cancelar [Esc]"
        '
        'GroupBoxDatosCliente
        '
        Me.GroupBoxDatosCliente.Controls.Add(Me.TextBoxNumero)
        Me.GroupBoxDatosCliente.Controls.Add(Me.Label10)
        Me.GroupBoxDatosCliente.Controls.Add(Me.Label11)
        Me.GroupBoxDatosCliente.Controls.Add(Me.DTPFecha)
        Me.GroupBoxDatosCliente.Controls.Add(Me.TextBoxTelefono)
        Me.GroupBoxDatosCliente.Controls.Add(Me.ComboBoxDomicilios)
        Me.GroupBoxDatosCliente.Controls.Add(Me.ComboBoxCliente)
        Me.GroupBoxDatosCliente.Controls.Add(Me.TextBoxDomicilio)
        Me.GroupBoxDatosCliente.Controls.Add(Me.TextBoxNombre)
        Me.GroupBoxDatosCliente.Controls.Add(Me.TextBoxDocumento)
        Me.GroupBoxDatosCliente.Controls.Add(Me.ComboBoxDocumento)
        Me.GroupBoxDatosCliente.Controls.Add(Me.Label20)
        Me.GroupBoxDatosCliente.Controls.Add(Me.Label2)
        Me.GroupBoxDatosCliente.Controls.Add(Me.Label4)
        Me.GroupBoxDatosCliente.Controls.Add(Me.Label3)
        Me.GroupBoxDatosCliente.Controls.Add(Me.Label6)
        Me.GroupBoxDatosCliente.Controls.Add(Me.Label1)
        Me.GroupBoxDatosCliente.Location = New System.Drawing.Point(12, 28)
        Me.GroupBoxDatosCliente.Name = "GroupBoxDatosCliente"
        Me.GroupBoxDatosCliente.Size = New System.Drawing.Size(868, 169)
        Me.GroupBoxDatosCliente.TabIndex = 3
        Me.GroupBoxDatosCliente.TabStop = False
        '
        'TextBoxNumero
        '
        Me.TextBoxNumero.Location = New System.Drawing.Point(761, 132)
        Me.TextBoxNumero.MaxLength = 8
        Me.TextBoxNumero.Name = "TextBoxNumero"
        Me.TextBoxNumero.Size = New System.Drawing.Size(63, 20)
        Me.TextBoxNumero.TabIndex = 2
        Me.TextBoxNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(622, 135)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(133, 13)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Nro. Orden de Compra"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(26, 135)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Fecha"
        '
        'DTPFecha
        '
        Me.DTPFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFecha.Location = New System.Drawing.Point(74, 132)
        Me.DTPFecha.Name = "DTPFecha"
        Me.DTPFecha.Size = New System.Drawing.Size(102, 20)
        Me.DTPFecha.TabIndex = 1
        '
        'TextBoxTelefono
        '
        Me.TextBoxTelefono.BackColor = System.Drawing.Color.White
        Me.TextBoxTelefono.Location = New System.Drawing.Point(539, 74)
        Me.TextBoxTelefono.MaxLength = 80
        Me.TextBoxTelefono.Name = "TextBoxTelefono"
        Me.TextBoxTelefono.ReadOnly = True
        Me.TextBoxTelefono.Size = New System.Drawing.Size(317, 20)
        Me.TextBoxTelefono.TabIndex = 8
        Me.TextBoxTelefono.TabStop = False
        '
        'ComboBoxDomicilios
        '
        Me.ComboBoxDomicilios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDomicilios.FormattingEnabled = True
        Me.ComboBoxDomicilios.Location = New System.Drawing.Point(74, 74)
        Me.ComboBoxDomicilios.Name = "ComboBoxDomicilios"
        Me.ComboBoxDomicilios.Size = New System.Drawing.Size(336, 21)
        Me.ComboBoxDomicilios.TabIndex = 7
        Me.ComboBoxDomicilios.TabStop = False
        '
        'ComboBoxCliente
        '
        Me.ComboBoxCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.ComboBoxCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.ComboBoxCliente.BusquedaPorCodigobarra = False
        Me.ComboBoxCliente.ColumnasExtras = Nothing
        Me.ComboBoxCliente.CustomFormatArt = False
        Me.ComboBoxCliente.DataSource = Nothing
        Me.ComboBoxCliente.DisplayMember = Nothing
        Me.ComboBoxCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ComboBoxCliente.FormularioDeAlta = Nothing
        Me.ComboBoxCliente.FormularioDeBusqueda = Nothing
        Me.ComboBoxCliente.Location = New System.Drawing.Point(74, 16)
        Me.ComboBoxCliente.MaximumSize = New System.Drawing.Size(500, 25)
        Me.ComboBoxCliente.MinimumSize = New System.Drawing.Size(200, 25)
        Me.ComboBoxCliente.Name = "ComboBoxCliente"
        Me.ComboBoxCliente.SelectedIndex = -1
        Me.ComboBoxCliente.SelectedItem = Nothing
        Me.ComboBoxCliente.SelectedText = ""
        Me.ComboBoxCliente.SelectedValue = Nothing
        Me.ComboBoxCliente.Size = New System.Drawing.Size(365, 25)
        Me.ComboBoxCliente.TabIndex = 0
        Me.ComboBoxCliente.ValueMember = Nothing
        '
        'TextBoxDomicilio
        '
        Me.TextBoxDomicilio.BackColor = System.Drawing.Color.White
        Me.TextBoxDomicilio.Location = New System.Drawing.Point(74, 101)
        Me.TextBoxDomicilio.MaxLength = 255
        Me.TextBoxDomicilio.Multiline = True
        Me.TextBoxDomicilio.Name = "TextBoxDomicilio"
        Me.TextBoxDomicilio.ReadOnly = True
        Me.TextBoxDomicilio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxDomicilio.Size = New System.Drawing.Size(336, 25)
        Me.TextBoxDomicilio.TabIndex = 9
        Me.TextBoxDomicilio.TabStop = False
        '
        'TextBoxNombre
        '
        Me.TextBoxNombre.BackColor = System.Drawing.Color.White
        Me.TextBoxNombre.Location = New System.Drawing.Point(540, 48)
        Me.TextBoxNombre.MaxLength = 80
        Me.TextBoxNombre.Name = "TextBoxNombre"
        Me.TextBoxNombre.ReadOnly = True
        Me.TextBoxNombre.Size = New System.Drawing.Size(317, 20)
        Me.TextBoxNombre.TabIndex = 6
        Me.TextBoxNombre.TabStop = False
        '
        'TextBoxDocumento
        '
        Me.TextBoxDocumento.BackColor = System.Drawing.Color.White
        Me.TextBoxDocumento.Location = New System.Drawing.Point(174, 48)
        Me.TextBoxDocumento.MaxLength = 11
        Me.TextBoxDocumento.Name = "TextBoxDocumento"
        Me.TextBoxDocumento.ReadOnly = True
        Me.TextBoxDocumento.Size = New System.Drawing.Size(236, 20)
        Me.TextBoxDocumento.TabIndex = 5
        Me.TextBoxDocumento.TabStop = False
        Me.TextBoxDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ComboBoxDocumento
        '
        Me.ComboBoxDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDocumento.DropDownWidth = 235
        Me.ComboBoxDocumento.FormattingEnabled = True
        Me.ComboBoxDocumento.Location = New System.Drawing.Point(74, 48)
        Me.ComboBoxDocumento.Name = "ComboBoxDocumento"
        Me.ComboBoxDocumento.Size = New System.Drawing.Size(94, 21)
        Me.ComboBoxDocumento.TabIndex = 4
        Me.ComboBoxDocumento.TabStop = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(14, 77)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(54, 13)
        Me.Label20.TabIndex = 3
        Me.Label20.Text = "Domicilios"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Domicilio F."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(485, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Teléfono"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(416, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Nombre / Razón Social"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(22, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Cliente"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Documento"
        '
        'GroupBoxDatosArticulos
        '
        Me.GroupBoxDatosArticulos.Controls.Add(Me.FOLVArticulos)
        Me.GroupBoxDatosArticulos.Controls.Add(Me.TextBoxUnidad)
        Me.GroupBoxDatosArticulos.Controls.Add(Me.Label9)
        Me.GroupBoxDatosArticulos.Controls.Add(Me.TextBoxKxU)
        Me.GroupBoxDatosArticulos.Controls.Add(Me.LabelTotal)
        Me.GroupBoxDatosArticulos.Controls.Add(Me.ComboBoxArticulos)
        Me.GroupBoxDatosArticulos.Controls.Add(Me.Label23)
        Me.GroupBoxDatosArticulos.Controls.Add(Me.BtnAgregarArticulo)
        Me.GroupBoxDatosArticulos.Controls.Add(Me.Label5)
        Me.GroupBoxDatosArticulos.Controls.Add(Me.Label27)
        Me.GroupBoxDatosArticulos.Controls.Add(Me.TextBoxPrecio)
        Me.GroupBoxDatosArticulos.Controls.Add(Me.TextBoxCantidad)
        Me.GroupBoxDatosArticulos.Controls.Add(Me.Label7)
        Me.GroupBoxDatosArticulos.Controls.Add(Me.Label19)
        Me.GroupBoxDatosArticulos.Controls.Add(Me.TextBoxSubtotalArticulo)
        Me.GroupBoxDatosArticulos.Location = New System.Drawing.Point(12, 203)
        Me.GroupBoxDatosArticulos.Name = "GroupBoxDatosArticulos"
        Me.GroupBoxDatosArticulos.Size = New System.Drawing.Size(868, 422)
        Me.GroupBoxDatosArticulos.TabIndex = 4
        Me.GroupBoxDatosArticulos.TabStop = False
        '
        'FOLVArticulos
        '
        Me.FOLVArticulos.AlternateRowBackColor = System.Drawing.Color.LightSteelBlue
        Me.FOLVArticulos.CellEditEnterChangesRows = True
        Me.FOLVArticulos.EmptyListMsg = "No hay datos para mostrar"
        Me.FOLVArticulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FOLVArticulos.FullRowSelect = True
        Me.FOLVArticulos.Location = New System.Drawing.Point(3, 61)
        Me.FOLVArticulos.Name = "FOLVArticulos"
        Me.FOLVArticulos.ShowGroups = False
        Me.FOLVArticulos.ShowHeaderInAllViews = False
        Me.FOLVArticulos.Size = New System.Drawing.Size(859, 330)
        Me.FOLVArticulos.TabIndex = 23
        Me.FOLVArticulos.UseAlternatingBackColors = True
        Me.FOLVArticulos.UseCompatibleStateImageBehavior = False
        Me.FOLVArticulos.View = System.Windows.Forms.View.Details
        Me.FOLVArticulos.VirtualMode = True
        '
        'TextBoxUnidad
        '
        Me.TextBoxUnidad.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxUnidad.Location = New System.Drawing.Point(476, 34)
        Me.TextBoxUnidad.Name = "TextBoxUnidad"
        Me.TextBoxUnidad.ReadOnly = True
        Me.TextBoxUnidad.Size = New System.Drawing.Size(27, 20)
        Me.TextBoxUnidad.TabIndex = 13
        Me.TextBoxUnidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Gainsboro
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(476, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(27, 15)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "U."
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBoxKxU
        '
        Me.TextBoxKxU.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxKxU.Location = New System.Drawing.Point(509, 34)
        Me.TextBoxKxU.Name = "TextBoxKxU"
        Me.TextBoxKxU.ReadOnly = True
        Me.TextBoxKxU.Size = New System.Drawing.Size(65, 20)
        Me.TextBoxKxU.TabIndex = 14
        Me.TextBoxKxU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelTotal
        '
        Me.LabelTotal.BackColor = System.Drawing.Color.LightGreen
        Me.LabelTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelTotal.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotal.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelTotal.Location = New System.Drawing.Point(3, 394)
        Me.LabelTotal.Name = "LabelTotal"
        Me.LabelTotal.Size = New System.Drawing.Size(862, 25)
        Me.LabelTotal.TabIndex = 21
        Me.LabelTotal.Text = "0.00"
        Me.LabelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboBoxArticulos
        '
        Me.ComboBoxArticulos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.ComboBoxArticulos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.ComboBoxArticulos.BusquedaPorCodigobarra = False
        Me.ComboBoxArticulos.ColumnasExtras = Nothing
        Me.ComboBoxArticulos.CustomFormatArt = False
        Me.ComboBoxArticulos.DataSource = Nothing
        Me.ComboBoxArticulos.DisplayMember = Nothing
        Me.ComboBoxArticulos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ComboBoxArticulos.FormularioDeAlta = Nothing
        Me.ComboBoxArticulos.FormularioDeBusqueda = Nothing
        Me.ComboBoxArticulos.Location = New System.Drawing.Point(10, 30)
        Me.ComboBoxArticulos.MaximumSize = New System.Drawing.Size(500, 25)
        Me.ComboBoxArticulos.MinimumSize = New System.Drawing.Size(200, 25)
        Me.ComboBoxArticulos.Name = "ComboBoxArticulos"
        Me.ComboBoxArticulos.SelectedIndex = -1
        Me.ComboBoxArticulos.SelectedItem = Nothing
        Me.ComboBoxArticulos.SelectedText = ""
        Me.ComboBoxArticulos.SelectedValue = Nothing
        Me.ComboBoxArticulos.Size = New System.Drawing.Size(460, 25)
        Me.ComboBoxArticulos.TabIndex = 12
        Me.ComboBoxArticulos.ValueMember = Nothing
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Gainsboro
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(725, 15)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(86, 15)
        Me.Label23.TabIndex = 18
        Me.Label23.Text = "Subtotal"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnAgregarArticulo
        '
        Me.BtnAgregarArticulo.FlatAppearance.BorderSize = 0
        Me.BtnAgregarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAgregarArticulo.Image = Global.Principal.My.Resources.Resources.add
        Me.BtnAgregarArticulo.Location = New System.Drawing.Point(817, 30)
        Me.BtnAgregarArticulo.Name = "BtnAgregarArticulo"
        Me.BtnAgregarArticulo.Size = New System.Drawing.Size(39, 24)
        Me.BtnAgregarArticulo.TabIndex = 19
        Me.BtnAgregarArticulo.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Gainsboro
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(580, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 15)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Cantidad"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Gainsboro
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(654, 15)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(65, 15)
        Me.Label27.TabIndex = 16
        Me.Label27.Text = "Precio"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBoxPrecio
        '
        Me.TextBoxPrecio.Location = New System.Drawing.Point(654, 33)
        Me.TextBoxPrecio.Name = "TextBoxPrecio"
        Me.TextBoxPrecio.Size = New System.Drawing.Size(65, 20)
        Me.TextBoxPrecio.TabIndex = 17
        Me.TextBoxPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBoxCantidad
        '
        Me.TextBoxCantidad.Location = New System.Drawing.Point(580, 33)
        Me.TextBoxCantidad.Name = "TextBoxCantidad"
        Me.TextBoxCantidad.Size = New System.Drawing.Size(68, 20)
        Me.TextBoxCantidad.TabIndex = 16
        Me.TextBoxCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Gainsboro
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(509, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 15)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "K. x U."
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Gainsboro
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(10, 16)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(95, 14)
        Me.Label19.TabIndex = 9
        Me.Label19.Text = "Artículo / Descripción"
        '
        'TextBoxSubtotalArticulo
        '
        Me.TextBoxSubtotalArticulo.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxSubtotalArticulo.Location = New System.Drawing.Point(725, 33)
        Me.TextBoxSubtotalArticulo.Name = "TextBoxSubtotalArticulo"
        Me.TextBoxSubtotalArticulo.ReadOnly = True
        Me.TextBoxSubtotalArticulo.Size = New System.Drawing.Size(86, 20)
        Me.TextBoxSubtotalArticulo.TabIndex = 18
        Me.TextBoxSubtotalArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(15, 633)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 13)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Observación"
        '
        'TextBoxObservacion
        '
        Me.TextBoxObservacion.BackColor = System.Drawing.Color.White
        Me.TextBoxObservacion.Location = New System.Drawing.Point(86, 631)
        Me.TextBoxObservacion.MaxLength = 40
        Me.TextBoxObservacion.Name = "TextBoxObservacion"
        Me.TextBoxObservacion.Size = New System.Drawing.Size(794, 20)
        Me.TextBoxObservacion.TabIndex = 24
        Me.TextBoxObservacion.TabStop = False
        '
        'FormCbteOrdenCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 651)
        Me.Controls.Add(Me.TextBoxObservacion)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.GroupBoxDatosArticulos)
        Me.Controls.Add(Me.GroupBoxDatosCliente)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximumSize = New System.Drawing.Size(900, 690)
        Me.MinimumSize = New System.Drawing.Size(900, 690)
        Me.Name = "FormCbteOrdenCompra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormCbteElectronico"
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.GroupBoxDatosCliente.ResumeLayout(False)
        Me.GroupBoxDatosCliente.PerformLayout()
        Me.GroupBoxDatosArticulos.ResumeLayout(False)
        Me.GroupBoxDatosArticulos.PerformLayout()
        CType(Me.FOLVArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButtonAutorizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButtonCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBoxDatosCliente As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DTPFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextBoxTelefono As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxDomicilios As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxCliente As Principal.CtlCustomCombo
    Friend WithEvents TextBoxDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNombre As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxDocumento As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxDatosArticulos As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBoxArticulos As Principal.CtlCustomCombo
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents BtnAgregarArticulo As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TextBoxPrecio As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TextBoxSubtotalArticulo As System.Windows.Forms.TextBox
    Friend WithEvents LabelTotal As System.Windows.Forms.Label
    Private WithEvents TextBoxNumero As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxKxU As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxUnidad As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents FOLVArticulos As BrightIdeasSoftware.FastObjectListView
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextBoxObservacion As System.Windows.Forms.TextBox
End Class
