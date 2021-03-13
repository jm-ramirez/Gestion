<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRubrocia
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxId = New System.Windows.Forms.TextBox()
        Me.TextBoxNombre = New System.Windows.Forms.TextBox()
        Me.TextBoxDescripcion = New System.Windows.Forms.TextBox()
        Me.NumericUpDownNosujeto = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownMinimo = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownNoinscripto = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.NumericUpDownTope1 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownTope2 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownTope3 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownTope4 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownTope5 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownTope6 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownTope7 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownTopeAlic1 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownTopeAlic2 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownTopeAlic3 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownTopeAlic4 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownTopeAlic5 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownTopeAlic6 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownTopeAlic7 = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.CheckBoxActivo = New System.Windows.Forms.CheckBox()
        Me.ToolStripMenu.SuspendLayout()
        CType(Me.NumericUpDownNosujeto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownMinimo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownNoinscripto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownTope1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownTope2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownTope3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownTope4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownTope5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownTope6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownTope7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownTopeAlic1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownTopeAlic2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownTopeAlic3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownTopeAlic4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownTopeAlic5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownTopeAlic6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownTopeAlic7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnGuardar, Me.BtnCancelar})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(576, 25)
        Me.ToolStripMenu.TabIndex = 0
        Me.ToolStripMenu.Text = "ToolStrip1"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Image = Global.Principal.My.Resources.Resources.disk
        Me.BtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(95, 22)
        Me.BtnGuardar.Text = "Guardar [F12]"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = Global.Principal.My.Resources.Resources.cancel
        Me.BtnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(96, 22)
        Me.BtnCancelar.Text = "Cancelar [Esc]"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(125, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Id"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(97, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nombre"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(78, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Descripción"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxId
        '
        Me.TextBoxId.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxId.Location = New System.Drawing.Point(150, 42)
        Me.TextBoxId.Name = "TextBoxId"
        Me.TextBoxId.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxId.TabIndex = 0
        Me.TextBoxId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxNombre
        '
        Me.TextBoxNombre.Location = New System.Drawing.Point(150, 68)
        Me.TextBoxNombre.MaxLength = 80
        Me.TextBoxNombre.Name = "TextBoxNombre"
        Me.TextBoxNombre.Size = New System.Drawing.Size(371, 20)
        Me.TextBoxNombre.TabIndex = 2
        '
        'TextBoxDescripcion
        '
        Me.TextBoxDescripcion.Location = New System.Drawing.Point(150, 94)
        Me.TextBoxDescripcion.MaxLength = 255
        Me.TextBoxDescripcion.Multiline = True
        Me.TextBoxDescripcion.Name = "TextBoxDescripcion"
        Me.TextBoxDescripcion.Size = New System.Drawing.Size(371, 60)
        Me.TextBoxDescripcion.TabIndex = 3
        '
        'NumericUpDownNosujeto
        '
        Me.NumericUpDownNosujeto.DecimalPlaces = 2
        Me.NumericUpDownNosujeto.Location = New System.Drawing.Point(150, 160)
        Me.NumericUpDownNosujeto.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 131072})
        Me.NumericUpDownNosujeto.Name = "NumericUpDownNosujeto"
        Me.NumericUpDownNosujeto.Size = New System.Drawing.Size(120, 20)
        Me.NumericUpDownNosujeto.TabIndex = 4
        Me.NumericUpDownNosujeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NumericUpDownMinimo
        '
        Me.NumericUpDownMinimo.DecimalPlaces = 2
        Me.NumericUpDownMinimo.Location = New System.Drawing.Point(150, 186)
        Me.NumericUpDownMinimo.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 131072})
        Me.NumericUpDownMinimo.Name = "NumericUpDownMinimo"
        Me.NumericUpDownMinimo.Size = New System.Drawing.Size(120, 20)
        Me.NumericUpDownMinimo.TabIndex = 5
        Me.NumericUpDownMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NumericUpDownNoinscripto
        '
        Me.NumericUpDownNoinscripto.DecimalPlaces = 2
        Me.NumericUpDownNoinscripto.Location = New System.Drawing.Point(150, 212)
        Me.NumericUpDownNoinscripto.Name = "NumericUpDownNoinscripto"
        Me.NumericUpDownNoinscripto.Size = New System.Drawing.Size(120, 20)
        Me.NumericUpDownNoinscripto.TabIndex = 6
        Me.NumericUpDownNoinscripto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 162)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "No Sujeto a Retención"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(49, 188)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Retención Mínima"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(81, 214)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Descripción"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(58, 214)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "% a No Inscripto"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'NumericUpDownTope1
        '
        Me.NumericUpDownTope1.DecimalPlaces = 2
        Me.NumericUpDownTope1.Location = New System.Drawing.Point(150, 238)
        Me.NumericUpDownTope1.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 131072})
        Me.NumericUpDownTope1.Name = "NumericUpDownTope1"
        Me.NumericUpDownTope1.Size = New System.Drawing.Size(120, 20)
        Me.NumericUpDownTope1.TabIndex = 7
        Me.NumericUpDownTope1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NumericUpDownTope2
        '
        Me.NumericUpDownTope2.DecimalPlaces = 2
        Me.NumericUpDownTope2.Location = New System.Drawing.Point(150, 264)
        Me.NumericUpDownTope2.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 131072})
        Me.NumericUpDownTope2.Name = "NumericUpDownTope2"
        Me.NumericUpDownTope2.Size = New System.Drawing.Size(120, 20)
        Me.NumericUpDownTope2.TabIndex = 9
        Me.NumericUpDownTope2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NumericUpDownTope3
        '
        Me.NumericUpDownTope3.DecimalPlaces = 2
        Me.NumericUpDownTope3.Location = New System.Drawing.Point(150, 290)
        Me.NumericUpDownTope3.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 131072})
        Me.NumericUpDownTope3.Name = "NumericUpDownTope3"
        Me.NumericUpDownTope3.Size = New System.Drawing.Size(120, 20)
        Me.NumericUpDownTope3.TabIndex = 11
        Me.NumericUpDownTope3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NumericUpDownTope4
        '
        Me.NumericUpDownTope4.DecimalPlaces = 2
        Me.NumericUpDownTope4.Location = New System.Drawing.Point(150, 316)
        Me.NumericUpDownTope4.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 131072})
        Me.NumericUpDownTope4.Name = "NumericUpDownTope4"
        Me.NumericUpDownTope4.Size = New System.Drawing.Size(120, 20)
        Me.NumericUpDownTope4.TabIndex = 13
        Me.NumericUpDownTope4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NumericUpDownTope5
        '
        Me.NumericUpDownTope5.DecimalPlaces = 2
        Me.NumericUpDownTope5.Location = New System.Drawing.Point(150, 342)
        Me.NumericUpDownTope5.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 131072})
        Me.NumericUpDownTope5.Name = "NumericUpDownTope5"
        Me.NumericUpDownTope5.Size = New System.Drawing.Size(120, 20)
        Me.NumericUpDownTope5.TabIndex = 15
        Me.NumericUpDownTope5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NumericUpDownTope6
        '
        Me.NumericUpDownTope6.DecimalPlaces = 2
        Me.NumericUpDownTope6.Location = New System.Drawing.Point(150, 368)
        Me.NumericUpDownTope6.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 131072})
        Me.NumericUpDownTope6.Name = "NumericUpDownTope6"
        Me.NumericUpDownTope6.Size = New System.Drawing.Size(120, 20)
        Me.NumericUpDownTope6.TabIndex = 17
        Me.NumericUpDownTope6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NumericUpDownTope7
        '
        Me.NumericUpDownTope7.DecimalPlaces = 2
        Me.NumericUpDownTope7.Location = New System.Drawing.Point(150, 394)
        Me.NumericUpDownTope7.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 131072})
        Me.NumericUpDownTope7.Name = "NumericUpDownTope7"
        Me.NumericUpDownTope7.Size = New System.Drawing.Size(120, 20)
        Me.NumericUpDownTope7.TabIndex = 19
        Me.NumericUpDownTope7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NumericUpDownTopeAlic1
        '
        Me.NumericUpDownTopeAlic1.DecimalPlaces = 2
        Me.NumericUpDownTopeAlic1.Location = New System.Drawing.Point(302, 238)
        Me.NumericUpDownTopeAlic1.Name = "NumericUpDownTopeAlic1"
        Me.NumericUpDownTopeAlic1.Size = New System.Drawing.Size(120, 20)
        Me.NumericUpDownTopeAlic1.TabIndex = 8
        Me.NumericUpDownTopeAlic1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NumericUpDownTopeAlic2
        '
        Me.NumericUpDownTopeAlic2.DecimalPlaces = 2
        Me.NumericUpDownTopeAlic2.Location = New System.Drawing.Point(302, 264)
        Me.NumericUpDownTopeAlic2.Name = "NumericUpDownTopeAlic2"
        Me.NumericUpDownTopeAlic2.Size = New System.Drawing.Size(120, 20)
        Me.NumericUpDownTopeAlic2.TabIndex = 10
        Me.NumericUpDownTopeAlic2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NumericUpDownTopeAlic3
        '
        Me.NumericUpDownTopeAlic3.DecimalPlaces = 2
        Me.NumericUpDownTopeAlic3.Location = New System.Drawing.Point(302, 290)
        Me.NumericUpDownTopeAlic3.Name = "NumericUpDownTopeAlic3"
        Me.NumericUpDownTopeAlic3.Size = New System.Drawing.Size(120, 20)
        Me.NumericUpDownTopeAlic3.TabIndex = 12
        Me.NumericUpDownTopeAlic3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NumericUpDownTopeAlic4
        '
        Me.NumericUpDownTopeAlic4.DecimalPlaces = 2
        Me.NumericUpDownTopeAlic4.Location = New System.Drawing.Point(302, 316)
        Me.NumericUpDownTopeAlic4.Name = "NumericUpDownTopeAlic4"
        Me.NumericUpDownTopeAlic4.Size = New System.Drawing.Size(120, 20)
        Me.NumericUpDownTopeAlic4.TabIndex = 14
        Me.NumericUpDownTopeAlic4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NumericUpDownTopeAlic5
        '
        Me.NumericUpDownTopeAlic5.DecimalPlaces = 2
        Me.NumericUpDownTopeAlic5.Location = New System.Drawing.Point(302, 342)
        Me.NumericUpDownTopeAlic5.Name = "NumericUpDownTopeAlic5"
        Me.NumericUpDownTopeAlic5.Size = New System.Drawing.Size(120, 20)
        Me.NumericUpDownTopeAlic5.TabIndex = 16
        Me.NumericUpDownTopeAlic5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NumericUpDownTopeAlic6
        '
        Me.NumericUpDownTopeAlic6.DecimalPlaces = 2
        Me.NumericUpDownTopeAlic6.Location = New System.Drawing.Point(302, 368)
        Me.NumericUpDownTopeAlic6.Name = "NumericUpDownTopeAlic6"
        Me.NumericUpDownTopeAlic6.Size = New System.Drawing.Size(120, 20)
        Me.NumericUpDownTopeAlic6.TabIndex = 18
        Me.NumericUpDownTopeAlic6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NumericUpDownTopeAlic7
        '
        Me.NumericUpDownTopeAlic7.DecimalPlaces = 2
        Me.NumericUpDownTopeAlic7.Location = New System.Drawing.Point(302, 394)
        Me.NumericUpDownTopeAlic7.Name = "NumericUpDownTopeAlic7"
        Me.NumericUpDownTopeAlic7.Size = New System.Drawing.Size(120, 20)
        Me.NumericUpDownTopeAlic7.TabIndex = 20
        Me.NumericUpDownTopeAlic7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(100, 240)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Tope 1"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(100, 266)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Tope 2"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(100, 292)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Tope 3"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(100, 318)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Tope 4"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(100, 344)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 13)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Tope 5"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(100, 370)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 13)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Tope 6"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(100, 396)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 13)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Tope 7"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(281, 240)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(15, 13)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "%"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(281, 266)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(15, 13)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "%"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(281, 292)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(15, 13)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "%"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(281, 318)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(15, 13)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = "%"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(281, 344)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(15, 13)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "%"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(281, 370)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(15, 13)
        Me.Label20.TabIndex = 1
        Me.Label20.Text = "%"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(281, 396)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(15, 13)
        Me.Label21.TabIndex = 1
        Me.Label21.Text = "%"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CheckBoxActivo
        '
        Me.CheckBoxActivo.AutoSize = True
        Me.CheckBoxActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxActivo.Location = New System.Drawing.Point(272, 45)
        Me.CheckBoxActivo.Name = "CheckBoxActivo"
        Me.CheckBoxActivo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBoxActivo.Size = New System.Drawing.Size(56, 17)
        Me.CheckBoxActivo.TabIndex = 21
        Me.CheckBoxActivo.TabStop = False
        Me.CheckBoxActivo.Text = "Activo"
        Me.CheckBoxActivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxActivo.UseVisualStyleBackColor = True
        '
        'FormRubrocia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(576, 425)
        Me.Controls.Add(Me.CheckBoxActivo)
        Me.Controls.Add(Me.NumericUpDownTopeAlic7)
        Me.Controls.Add(Me.NumericUpDownTope7)
        Me.Controls.Add(Me.NumericUpDownTopeAlic6)
        Me.Controls.Add(Me.NumericUpDownTope6)
        Me.Controls.Add(Me.NumericUpDownTopeAlic5)
        Me.Controls.Add(Me.NumericUpDownTope5)
        Me.Controls.Add(Me.NumericUpDownTopeAlic4)
        Me.Controls.Add(Me.NumericUpDownTope4)
        Me.Controls.Add(Me.NumericUpDownTopeAlic3)
        Me.Controls.Add(Me.NumericUpDownTope3)
        Me.Controls.Add(Me.NumericUpDownTopeAlic2)
        Me.Controls.Add(Me.NumericUpDownTope2)
        Me.Controls.Add(Me.NumericUpDownTopeAlic1)
        Me.Controls.Add(Me.NumericUpDownTope1)
        Me.Controls.Add(Me.NumericUpDownNoinscripto)
        Me.Controls.Add(Me.NumericUpDownMinimo)
        Me.Controls.Add(Me.NumericUpDownNosujeto)
        Me.Controls.Add(Me.TextBoxDescripcion)
        Me.Controls.Add(Me.TextBoxNombre)
        Me.Controls.Add(Me.TextBoxId)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormRubrocia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rubro de ganancia"
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        CType(Me.NumericUpDownNosujeto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownMinimo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownNoinscripto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownTope1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownTope2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownTope3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownTope4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownTope5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownTope6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownTope7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownTopeAlic1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownTopeAlic2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownTopeAlic3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownTopeAlic4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownTopeAlic5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownTopeAlic6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownTopeAlic7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxId As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNombre As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxDescripcion As System.Windows.Forms.TextBox
    Private WithEvents NumericUpDownNosujeto As System.Windows.Forms.NumericUpDown
    Private WithEvents NumericUpDownMinimo As System.Windows.Forms.NumericUpDown
    Private WithEvents NumericUpDownNoinscripto As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Private WithEvents NumericUpDownTope1 As System.Windows.Forms.NumericUpDown
    Private WithEvents NumericUpDownTope2 As System.Windows.Forms.NumericUpDown
    Private WithEvents NumericUpDownTope3 As System.Windows.Forms.NumericUpDown
    Private WithEvents NumericUpDownTope4 As System.Windows.Forms.NumericUpDown
    Private WithEvents NumericUpDownTope5 As System.Windows.Forms.NumericUpDown
    Private WithEvents NumericUpDownTope6 As System.Windows.Forms.NumericUpDown
    Private WithEvents NumericUpDownTope7 As System.Windows.Forms.NumericUpDown
    Private WithEvents NumericUpDownTopeAlic1 As System.Windows.Forms.NumericUpDown
    Private WithEvents NumericUpDownTopeAlic2 As System.Windows.Forms.NumericUpDown
    Private WithEvents NumericUpDownTopeAlic3 As System.Windows.Forms.NumericUpDown
    Private WithEvents NumericUpDownTopeAlic4 As System.Windows.Forms.NumericUpDown
    Private WithEvents NumericUpDownTopeAlic5 As System.Windows.Forms.NumericUpDown
    Private WithEvents NumericUpDownTopeAlic6 As System.Windows.Forms.NumericUpDown
    Private WithEvents NumericUpDownTopeAlic7 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxActivo As System.Windows.Forms.CheckBox
End Class
