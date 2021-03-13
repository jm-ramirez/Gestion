<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlArticulos
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CtlArticulos))
        Me.ImgList = New System.Windows.Forms.ImageList(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.FOLVArticulos = New BrightIdeasSoftware.FastObjectListView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cboArticulo = New Principal.CtlCustomCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBoxMoneda = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TextBoxSubtotalArticulo = New System.Windows.Forms.TextBox()
        Me.BtnAgregarArticulo = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TextBoxImporte = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.ComboBoxUnidad = New System.Windows.Forms.ComboBox()
        Me.TextBoxCantidad = New System.Windows.Forms.TextBox()
        Me.LabelCantidad = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.FOLVArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImgList
        '
        Me.ImgList.ImageStream = CType(resources.GetObject("ImgList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImgList.Images.SetKeyName(0, "checked")
        Me.ImgList.Images.SetKeyName(1, "unchecked")
        Me.ImgList.Images.SetKeyName(2, "edit")
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(3, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(990, 295)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel2)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(982, 269)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Piezas"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.FOLVArticulos)
        Me.Panel2.Location = New System.Drawing.Point(3, 57)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(973, 208)
        Me.Panel2.TabIndex = 1
        '
        'FOLVArticulos
        '
        Me.FOLVArticulos.AlternateRowBackColor = System.Drawing.Color.LightSteelBlue
        Me.FOLVArticulos.Location = New System.Drawing.Point(0, 4)
        Me.FOLVArticulos.Name = "FOLVArticulos"
        Me.FOLVArticulos.ShowGroups = False
        Me.FOLVArticulos.ShowHeaderInAllViews = False
        Me.FOLVArticulos.Size = New System.Drawing.Size(973, 200)
        Me.FOLVArticulos.TabIndex = 7
        Me.FOLVArticulos.UseAlternatingBackColors = True
        Me.FOLVArticulos.UseCompatibleStateImageBehavior = False
        Me.FOLVArticulos.View = System.Windows.Forms.View.Details
        Me.FOLVArticulos.VirtualMode = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cboArticulo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.ComboBoxMoneda)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.TextBoxSubtotalArticulo)
        Me.Panel1.Controls.Add(Me.BtnAgregarArticulo)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.TextBoxImporte)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.ComboBoxUnidad)
        Me.Panel1.Controls.Add(Me.TextBoxCantidad)
        Me.Panel1.Controls.Add(Me.LabelCantidad)
        Me.Panel1.Location = New System.Drawing.Point(0, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(976, 49)
        Me.Panel1.TabIndex = 0
        '
        'cboArticulo
        '
        Me.cboArticulo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.cboArticulo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.cboArticulo.BusquedaPorCodigobarra = False
        Me.cboArticulo.ColumnasExtras = Nothing
        Me.cboArticulo.CustomFormatArt = False
        Me.cboArticulo.DataSource = Nothing
        Me.cboArticulo.DisplayMember = Nothing
        Me.cboArticulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboArticulo.FormularioDeAlta = Nothing
        Me.cboArticulo.FormularioDeBusqueda = Nothing
        Me.cboArticulo.Location = New System.Drawing.Point(193, 13)
        Me.cboArticulo.MaximumSize = New System.Drawing.Size(500, 25)
        Me.cboArticulo.MinimumSize = New System.Drawing.Size(200, 25)
        Me.cboArticulo.Name = "cboArticulo"
        Me.cboArticulo.SelectedIndex = -1
        Me.cboArticulo.SelectedItem = Nothing
        Me.cboArticulo.SelectedText = ""
        Me.cboArticulo.SelectedValue = Nothing
        Me.cboArticulo.Size = New System.Drawing.Size(412, 25)
        Me.cboArticulo.TabIndex = 0
        Me.cboArticulo.ValueMember = Nothing
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(61, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 25)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Artículo"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Gainsboro
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(748, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 15)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Moneda"
        '
        'ComboBoxMoneda
        '
        Me.ComboBoxMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxMoneda.FormattingEnabled = True
        Me.ComboBoxMoneda.Location = New System.Drawing.Point(749, 23)
        Me.ComboBoxMoneda.Name = "ComboBoxMoneda"
        Me.ComboBoxMoneda.Size = New System.Drawing.Size(55, 21)
        Me.ComboBoxMoneda.TabIndex = 3
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Gainsboro
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(872, 2)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(78, 21)
        Me.Label23.TabIndex = 15
        Me.Label23.Text = "Subtotal"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBoxSubtotalArticulo
        '
        Me.TextBoxSubtotalArticulo.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxSubtotalArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxSubtotalArticulo.Location = New System.Drawing.Point(873, 23)
        Me.TextBoxSubtotalArticulo.MaxLength = 12
        Me.TextBoxSubtotalArticulo.Name = "TextBoxSubtotalArticulo"
        Me.TextBoxSubtotalArticulo.ReadOnly = True
        Me.TextBoxSubtotalArticulo.Size = New System.Drawing.Size(77, 21)
        Me.TextBoxSubtotalArticulo.TabIndex = 5
        Me.TextBoxSubtotalArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnAgregarArticulo
        '
        Me.BtnAgregarArticulo.FlatAppearance.BorderSize = 0
        Me.BtnAgregarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAgregarArticulo.Image = Global.Principal.My.Resources.Resources.add
        Me.BtnAgregarArticulo.Location = New System.Drawing.Point(949, 11)
        Me.BtnAgregarArticulo.Name = "BtnAgregarArticulo"
        Me.BtnAgregarArticulo.Size = New System.Drawing.Size(20, 24)
        Me.BtnAgregarArticulo.TabIndex = 6
        Me.BtnAgregarArticulo.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Gainsboro
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(802, 2)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(68, 21)
        Me.Label21.TabIndex = 14
        Me.Label21.Text = "Importe"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBoxImporte
        '
        Me.TextBoxImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxImporte.Location = New System.Drawing.Point(802, 23)
        Me.TextBoxImporte.MaxLength = 12
        Me.TextBoxImporte.Name = "TextBoxImporte"
        Me.TextBoxImporte.Size = New System.Drawing.Size(69, 21)
        Me.TextBoxImporte.TabIndex = 4
        Me.TextBoxImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Gainsboro
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(697, 2)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(49, 22)
        Me.Label22.TabIndex = 11
        Me.Label22.Text = "Unidad"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBoxUnidad
        '
        Me.ComboBoxUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxUnidad.FormattingEnabled = True
        Me.ComboBoxUnidad.Location = New System.Drawing.Point(697, 22)
        Me.ComboBoxUnidad.Name = "ComboBoxUnidad"
        Me.ComboBoxUnidad.Size = New System.Drawing.Size(49, 23)
        Me.ComboBoxUnidad.TabIndex = 2
        '
        'TextBoxCantidad
        '
        Me.TextBoxCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCantidad.Location = New System.Drawing.Point(638, 24)
        Me.TextBoxCantidad.MaxLength = 4
        Me.TextBoxCantidad.Name = "TextBoxCantidad"
        Me.TextBoxCantidad.Size = New System.Drawing.Size(59, 21)
        Me.TextBoxCantidad.TabIndex = 1
        Me.TextBoxCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelCantidad
        '
        Me.LabelCantidad.BackColor = System.Drawing.Color.Gainsboro
        Me.LabelCantidad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCantidad.Location = New System.Drawing.Point(638, 3)
        Me.LabelCantidad.Name = "LabelCantidad"
        Me.LabelCantidad.Size = New System.Drawing.Size(59, 21)
        Me.LabelCantidad.TabIndex = 6
        Me.LabelCantidad.Text = "Cantidad"
        Me.LabelCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CtlArticulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "CtlArticulos"
        Me.Size = New System.Drawing.Size(994, 295)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.FOLVArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImgList As System.Windows.Forms.ImageList
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnAgregarArticulo As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TextBoxImporte As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxUnidad As System.Windows.Forms.ComboBox
    Friend WithEvents TextBoxCantidad As System.Windows.Forms.TextBox
    Friend WithEvents LabelCantidad As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TextBoxSubtotalArticulo As System.Windows.Forms.TextBox
    Friend WithEvents FOLVArticulos As BrightIdeasSoftware.FastObjectListView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboArticulo As Principal.CtlCustomCombo

End Class
