<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCbteRemito
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
        Me.ToolStripButtonAutorizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonCancelar = New System.Windows.Forms.ToolStripButton()
        Me.GroupBoxDatosCliente = New System.Windows.Forms.GroupBox()
        Me.ComboBoxVendedores = New Principal.CtlCustomCombo()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBoxLocalidad = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBoxRemito = New System.Windows.Forms.TextBox()
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
        Me.ComboBoxNroOrden = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
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
        Me.GroupBoxDatosTransporte = New System.Windows.Forms.GroupBox()
        Me.RadioButtonRetiraCliente = New System.Windows.Forms.RadioButton()
        Me.RadioButtonNuestroCargo = New System.Windows.Forms.RadioButton()
        Me.RadioButtonDestino = New System.Windows.Forms.RadioButton()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TextBoxBultos = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TextBoxValorDeclarado = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TextBoxLugarEntrega = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextBoxDocumentoTransporte = New System.Windows.Forms.TextBox()
        Me.ComboBoxDocumentoTransporte = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TextBoxDomicilioTransporte = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ComboBoxTranportista = New Principal.CtlCustomCombo()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ToolStripMenu.SuspendLayout()
        Me.GroupBoxDatosCliente.SuspendLayout()
        Me.GroupBoxDatosArticulos.SuspendLayout()
        CType(Me.FOLVArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxDatosTransporte.SuspendLayout()
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
        Me.GroupBoxDatosCliente.Controls.Add(Me.ComboBoxVendedores)
        Me.GroupBoxDatosCliente.Controls.Add(Me.Label14)
        Me.GroupBoxDatosCliente.Controls.Add(Me.TextBoxLocalidad)
        Me.GroupBoxDatosCliente.Controls.Add(Me.Label13)
        Me.GroupBoxDatosCliente.Controls.Add(Me.Label8)
        Me.GroupBoxDatosCliente.Controls.Add(Me.TextBoxRemito)
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
        'ComboBoxVendedores
        '
        Me.ComboBoxVendedores.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.ComboBoxVendedores.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.ComboBoxVendedores.BusquedaPorCodigobarra = False
        Me.ComboBoxVendedores.ColumnasExtras = Nothing
        Me.ComboBoxVendedores.CustomFormatArt = False
        Me.ComboBoxVendedores.DataSource = Nothing
        Me.ComboBoxVendedores.DisplayMember = Nothing
        Me.ComboBoxVendedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ComboBoxVendedores.FormularioDeAlta = Nothing
        Me.ComboBoxVendedores.FormularioDeBusqueda = Nothing
        Me.ComboBoxVendedores.Location = New System.Drawing.Point(539, 16)
        Me.ComboBoxVendedores.MaximumSize = New System.Drawing.Size(500, 25)
        Me.ComboBoxVendedores.MinimumSize = New System.Drawing.Size(200, 25)
        Me.ComboBoxVendedores.Name = "ComboBoxVendedores"
        Me.ComboBoxVendedores.SelectedIndex = -1
        Me.ComboBoxVendedores.SelectedItem = Nothing
        Me.ComboBoxVendedores.SelectedText = ""
        Me.ComboBoxVendedores.SelectedValue = Nothing
        Me.ComboBoxVendedores.Size = New System.Drawing.Size(317, 25)
        Me.ComboBoxVendedores.TabIndex = 4
        Me.ComboBoxVendedores.ValueMember = Nothing
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(473, 21)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 13)
        Me.Label14.TabIndex = 16
        Me.Label14.Text = "Vendedor"
        '
        'TextBoxLocalidad
        '
        Me.TextBoxLocalidad.BackColor = System.Drawing.Color.White
        Me.TextBoxLocalidad.Location = New System.Drawing.Point(539, 99)
        Me.TextBoxLocalidad.MaxLength = 80
        Me.TextBoxLocalidad.Name = "TextBoxLocalidad"
        Me.TextBoxLocalidad.ReadOnly = True
        Me.TextBoxLocalidad.Size = New System.Drawing.Size(317, 20)
        Me.TextBoxLocalidad.TabIndex = 11
        Me.TextBoxLocalidad.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(482, 103)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 13)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Localidad"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(825, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(10, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "-"
        '
        'TextBoxRemito
        '
        Me.TextBoxRemito.Location = New System.Drawing.Point(794, 132)
        Me.TextBoxRemito.MaxLength = 8
        Me.TextBoxRemito.Name = "TextBoxRemito"
        Me.TextBoxRemito.ReadOnly = True
        Me.TextBoxRemito.Size = New System.Drawing.Size(63, 20)
        Me.TextBoxRemito.TabIndex = 3
        Me.TextBoxRemito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(697, 135)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(92, 13)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Nro. de Remito"
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
        Me.TextBoxTelefono.TabIndex = 9
        Me.TextBoxTelefono.TabStop = False
        '
        'ComboBoxDomicilios
        '
        Me.ComboBoxDomicilios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDomicilios.FormattingEnabled = True
        Me.ComboBoxDomicilios.Location = New System.Drawing.Point(74, 74)
        Me.ComboBoxDomicilios.Name = "ComboBoxDomicilios"
        Me.ComboBoxDomicilios.Size = New System.Drawing.Size(336, 21)
        Me.ComboBoxDomicilios.TabIndex = 8
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
        Me.ComboBoxCliente.Size = New System.Drawing.Size(336, 25)
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
        Me.TextBoxDomicilio.TabIndex = 10
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
        Me.TextBoxNombre.TabIndex = 7
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
        Me.TextBoxDocumento.TabIndex = 6
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
        Me.ComboBoxDocumento.TabIndex = 5
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
        Me.GroupBoxDatosArticulos.Controls.Add(Me.ComboBoxNroOrden)
        Me.GroupBoxDatosArticulos.Controls.Add(Me.Label25)
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
        Me.GroupBoxDatosArticulos.Size = New System.Drawing.Size(868, 305)
        Me.GroupBoxDatosArticulos.TabIndex = 4
        Me.GroupBoxDatosArticulos.TabStop = False
        '
        'ComboBoxNroOrden
        '
        Me.ComboBoxNroOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxNroOrden.DropDownWidth = 235
        Me.ComboBoxNroOrden.FormattingEnabled = True
        Me.ComboBoxNroOrden.Location = New System.Drawing.Point(652, 34)
        Me.ComboBoxNroOrden.Name = "ComboBoxNroOrden"
        Me.ComboBoxNroOrden.Size = New System.Drawing.Size(91, 21)
        Me.ComboBoxNroOrden.TabIndex = 18
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Gainsboro
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(652, 16)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(91, 15)
        Me.Label25.TabIndex = 32
        Me.Label25.Text = "Orden Compra"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.FOLVArticulos.Size = New System.Drawing.Size(859, 210)
        Me.FOLVArticulos.TabIndex = 22
        Me.FOLVArticulos.UseAlternatingBackColors = True
        Me.FOLVArticulos.UseCompatibleStateImageBehavior = False
        Me.FOLVArticulos.View = System.Windows.Forms.View.Details
        Me.FOLVArticulos.VirtualMode = True
        '
        'TextBoxUnidad
        '
        Me.TextBoxUnidad.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxUnidad.Location = New System.Drawing.Point(403, 34)
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
        Me.Label9.Location = New System.Drawing.Point(403, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(27, 15)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "U."
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBoxKxU
        '
        Me.TextBoxKxU.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxKxU.Location = New System.Drawing.Point(436, 34)
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
        Me.LabelTotal.Location = New System.Drawing.Point(3, 274)
        Me.LabelTotal.Name = "LabelTotal"
        Me.LabelTotal.Size = New System.Drawing.Size(862, 25)
        Me.LabelTotal.TabIndex = 30
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
        Me.ComboBoxArticulos.Size = New System.Drawing.Size(387, 25)
        Me.ComboBoxArticulos.TabIndex = 12
        Me.ComboBoxArticulos.ValueMember = Nothing
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Gainsboro
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(749, 16)
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
        Me.BtnAgregarArticulo.Location = New System.Drawing.Point(839, 30)
        Me.BtnAgregarArticulo.Name = "BtnAgregarArticulo"
        Me.BtnAgregarArticulo.Size = New System.Drawing.Size(18, 24)
        Me.BtnAgregarArticulo.TabIndex = 21
        Me.BtnAgregarArticulo.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Gainsboro
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(507, 16)
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
        Me.Label27.Location = New System.Drawing.Point(581, 16)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(65, 15)
        Me.Label27.TabIndex = 16
        Me.Label27.Text = "Precio"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBoxPrecio
        '
        Me.TextBoxPrecio.Location = New System.Drawing.Point(581, 34)
        Me.TextBoxPrecio.Name = "TextBoxPrecio"
        Me.TextBoxPrecio.Size = New System.Drawing.Size(65, 20)
        Me.TextBoxPrecio.TabIndex = 17
        Me.TextBoxPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBoxCantidad
        '
        Me.TextBoxCantidad.Location = New System.Drawing.Point(507, 34)
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
        Me.Label7.Location = New System.Drawing.Point(436, 16)
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
        Me.TextBoxSubtotalArticulo.Location = New System.Drawing.Point(749, 34)
        Me.TextBoxSubtotalArticulo.Name = "TextBoxSubtotalArticulo"
        Me.TextBoxSubtotalArticulo.ReadOnly = True
        Me.TextBoxSubtotalArticulo.Size = New System.Drawing.Size(86, 20)
        Me.TextBoxSubtotalArticulo.TabIndex = 20
        Me.TextBoxSubtotalArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBoxDatosTransporte
        '
        Me.GroupBoxDatosTransporte.Controls.Add(Me.RadioButtonRetiraCliente)
        Me.GroupBoxDatosTransporte.Controls.Add(Me.RadioButtonNuestroCargo)
        Me.GroupBoxDatosTransporte.Controls.Add(Me.RadioButtonDestino)
        Me.GroupBoxDatosTransporte.Controls.Add(Me.Label24)
        Me.GroupBoxDatosTransporte.Controls.Add(Me.TextBoxBultos)
        Me.GroupBoxDatosTransporte.Controls.Add(Me.Label22)
        Me.GroupBoxDatosTransporte.Controls.Add(Me.TextBoxValorDeclarado)
        Me.GroupBoxDatosTransporte.Controls.Add(Me.Label18)
        Me.GroupBoxDatosTransporte.Controls.Add(Me.TextBoxLugarEntrega)
        Me.GroupBoxDatosTransporte.Controls.Add(Me.Label17)
        Me.GroupBoxDatosTransporte.Controls.Add(Me.TextBoxDocumentoTransporte)
        Me.GroupBoxDatosTransporte.Controls.Add(Me.ComboBoxDocumentoTransporte)
        Me.GroupBoxDatosTransporte.Controls.Add(Me.Label16)
        Me.GroupBoxDatosTransporte.Controls.Add(Me.TextBoxDomicilioTransporte)
        Me.GroupBoxDatosTransporte.Controls.Add(Me.Label15)
        Me.GroupBoxDatosTransporte.Controls.Add(Me.ComboBoxTranportista)
        Me.GroupBoxDatosTransporte.Controls.Add(Me.Label12)
        Me.GroupBoxDatosTransporte.Location = New System.Drawing.Point(12, 514)
        Me.GroupBoxDatosTransporte.Name = "GroupBoxDatosTransporte"
        Me.GroupBoxDatosTransporte.Size = New System.Drawing.Size(868, 137)
        Me.GroupBoxDatosTransporte.TabIndex = 5
        Me.GroupBoxDatosTransporte.TabStop = False
        '
        'RadioButtonRetiraCliente
        '
        Me.RadioButtonRetiraCliente.AutoSize = True
        Me.RadioButtonRetiraCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonRetiraCliente.Location = New System.Drawing.Point(581, 108)
        Me.RadioButtonRetiraCliente.Name = "RadioButtonRetiraCliente"
        Me.RadioButtonRetiraCliente.Size = New System.Drawing.Size(87, 17)
        Me.RadioButtonRetiraCliente.TabIndex = 32
        Me.RadioButtonRetiraCliente.Text = "Retira cliente"
        Me.RadioButtonRetiraCliente.UseVisualStyleBackColor = True
        '
        'RadioButtonNuestroCargo
        '
        Me.RadioButtonNuestroCargo.AutoSize = True
        Me.RadioButtonNuestroCargo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonNuestroCargo.Location = New System.Drawing.Point(436, 108)
        Me.RadioButtonNuestroCargo.Name = "RadioButtonNuestroCargo"
        Me.RadioButtonNuestroCargo.Size = New System.Drawing.Size(125, 17)
        Me.RadioButtonNuestroCargo.TabIndex = 31
        Me.RadioButtonNuestroCargo.Text = "Flete a nuestro cargo"
        Me.RadioButtonNuestroCargo.UseVisualStyleBackColor = True
        '
        'RadioButtonDestino
        '
        Me.RadioButtonDestino.AutoSize = True
        Me.RadioButtonDestino.Checked = True
        Me.RadioButtonDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonDestino.Location = New System.Drawing.Point(283, 108)
        Me.RadioButtonDestino.Name = "RadioButtonDestino"
        Me.RadioButtonDestino.Size = New System.Drawing.Size(133, 17)
        Me.RadioButtonDestino.TabIndex = 30
        Me.RadioButtonDestino.TabStop = True
        Me.RadioButtonDestino.Text = "Flete a pagar a destino"
        Me.RadioButtonDestino.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(156, 108)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(109, 13)
        Me.Label24.TabIndex = 21
        Me.Label24.Text = "Datos Adicionales"
        '
        'TextBoxBultos
        '
        Me.TextBoxBultos.BackColor = System.Drawing.Color.White
        Me.TextBoxBultos.Location = New System.Drawing.Point(737, 70)
        Me.TextBoxBultos.MaxLength = 80
        Me.TextBoxBultos.Name = "TextBoxBultos"
        Me.TextBoxBultos.Size = New System.Drawing.Size(120, 20)
        Me.TextBoxBultos.TabIndex = 29
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(695, 73)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(36, 13)
        Me.Label22.TabIndex = 19
        Me.Label22.Text = "Bultos"
        '
        'TextBoxValorDeclarado
        '
        Me.TextBoxValorDeclarado.BackColor = System.Drawing.Color.White
        Me.TextBoxValorDeclarado.Location = New System.Drawing.Point(540, 70)
        Me.TextBoxValorDeclarado.MaxLength = 80
        Me.TextBoxValorDeclarado.Name = "TextBoxValorDeclarado"
        Me.TextBoxValorDeclarado.Size = New System.Drawing.Size(120, 20)
        Me.TextBoxValorDeclarado.TabIndex = 28
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(452, 73)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(83, 13)
        Me.Label18.TabIndex = 17
        Me.Label18.Text = "Valor Declarado"
        '
        'TextBoxLugarEntrega
        '
        Me.TextBoxLugarEntrega.BackColor = System.Drawing.Color.White
        Me.TextBoxLugarEntrega.Location = New System.Drawing.Point(539, 13)
        Me.TextBoxLugarEntrega.MaxLength = 80
        Me.TextBoxLugarEntrega.Multiline = True
        Me.TextBoxLugarEntrega.Name = "TextBoxLugarEntrega"
        Me.TextBoxLugarEntrega.Size = New System.Drawing.Size(317, 44)
        Me.TextBoxLugarEntrega.TabIndex = 27
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(448, 17)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(89, 13)
        Me.Label17.TabIndex = 15
        Me.Label17.Text = "Lugar de Entrega"
        '
        'TextBoxDocumentoTransporte
        '
        Me.TextBoxDocumentoTransporte.BackColor = System.Drawing.Color.White
        Me.TextBoxDocumentoTransporte.Location = New System.Drawing.Point(200, 44)
        Me.TextBoxDocumentoTransporte.MaxLength = 11
        Me.TextBoxDocumentoTransporte.Name = "TextBoxDocumentoTransporte"
        Me.TextBoxDocumentoTransporte.Size = New System.Drawing.Size(236, 20)
        Me.TextBoxDocumentoTransporte.TabIndex = 25
        Me.TextBoxDocumentoTransporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ComboBoxDocumentoTransporte
        '
        Me.ComboBoxDocumentoTransporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDocumentoTransporte.DropDownWidth = 235
        Me.ComboBoxDocumentoTransporte.FormattingEnabled = True
        Me.ComboBoxDocumentoTransporte.Location = New System.Drawing.Point(100, 44)
        Me.ComboBoxDocumentoTransporte.Name = "ComboBoxDocumentoTransporte"
        Me.ComboBoxDocumentoTransporte.Size = New System.Drawing.Size(94, 21)
        Me.ComboBoxDocumentoTransporte.TabIndex = 24
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(32, 47)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(62, 13)
        Me.Label16.TabIndex = 12
        Me.Label16.Text = "Documento"
        '
        'TextBoxDomicilioTransporte
        '
        Me.TextBoxDomicilioTransporte.BackColor = System.Drawing.Color.White
        Me.TextBoxDomicilioTransporte.Location = New System.Drawing.Point(100, 70)
        Me.TextBoxDomicilioTransporte.MaxLength = 80
        Me.TextBoxDomicilioTransporte.Name = "TextBoxDomicilioTransporte"
        Me.TextBoxDomicilioTransporte.Size = New System.Drawing.Size(336, 20)
        Me.TextBoxDomicilioTransporte.TabIndex = 26
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(48, 74)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 13)
        Me.Label15.TabIndex = 10
        Me.Label15.Text = "Domicilio"
        '
        'ComboBoxTranportista
        '
        Me.ComboBoxTranportista.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.ComboBoxTranportista.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.ComboBoxTranportista.BusquedaPorCodigobarra = False
        Me.ComboBoxTranportista.ColumnasExtras = Nothing
        Me.ComboBoxTranportista.CustomFormatArt = False
        Me.ComboBoxTranportista.DataSource = Nothing
        Me.ComboBoxTranportista.DisplayMember = Nothing
        Me.ComboBoxTranportista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ComboBoxTranportista.FormularioDeAlta = Nothing
        Me.ComboBoxTranportista.FormularioDeBusqueda = Nothing
        Me.ComboBoxTranportista.Location = New System.Drawing.Point(100, 13)
        Me.ComboBoxTranportista.MaximumSize = New System.Drawing.Size(500, 25)
        Me.ComboBoxTranportista.MinimumSize = New System.Drawing.Size(200, 25)
        Me.ComboBoxTranportista.Name = "ComboBoxTranportista"
        Me.ComboBoxTranportista.SelectedIndex = -1
        Me.ComboBoxTranportista.SelectedItem = Nothing
        Me.ComboBoxTranportista.SelectedText = ""
        Me.ComboBoxTranportista.SelectedValue = Nothing
        Me.ComboBoxTranportista.Size = New System.Drawing.Size(336, 25)
        Me.ComboBoxTranportista.TabIndex = 23
        Me.ComboBoxTranportista.ValueMember = Nothing
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(14, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(81, 13)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Transportista"
        '
        'FormCbteRemito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 651)
        Me.Controls.Add(Me.GroupBoxDatosTransporte)
        Me.Controls.Add(Me.GroupBoxDatosArticulos)
        Me.Controls.Add(Me.GroupBoxDatosCliente)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.KeyPreview = True
        Me.MaximumSize = New System.Drawing.Size(900, 690)
        Me.MinimumSize = New System.Drawing.Size(900, 690)
        Me.Name = "FormCbteRemito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormCbteElectronico"
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.GroupBoxDatosCliente.ResumeLayout(False)
        Me.GroupBoxDatosCliente.PerformLayout()
        Me.GroupBoxDatosArticulos.ResumeLayout(False)
        Me.GroupBoxDatosArticulos.PerformLayout()
        CType(Me.FOLVArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxDatosTransporte.ResumeLayout(False)
        Me.GroupBoxDatosTransporte.PerformLayout()
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
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents TextBoxRemito As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxKxU As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxUnidad As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents FOLVArticulos As BrightIdeasSoftware.FastObjectListView
    Friend WithEvents TextBoxLocalidad As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxVendedores As Principal.CtlCustomCombo
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxDatosTransporte As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBoxTranportista As Principal.CtlCustomCombo
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextBoxDomicilioTransporte As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextBoxLugarEntrega As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TextBoxDocumentoTransporte As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxDocumentoTransporte As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TextBoxBultos As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TextBoxValorDeclarado As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents RadioButtonRetiraCliente As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonNuestroCargo As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonDestino As System.Windows.Forms.RadioButton
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxNroOrden As System.Windows.Forms.ComboBox
End Class
