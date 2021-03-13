<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPeriodoCompras
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
        Me.components = New System.ComponentModel.Container()
        Me.ToolStripMenu = New System.Windows.Forms.ToolStrip()
        Me.BtnVer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CtlCustomComboProveedor = New Principal.CtlCustomCombo()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FOLVCompAsoc = New BrightIdeasSoftware.FastObjectListView()
        Me.MyContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextMenuItemVer = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBoxPeriodo = New System.Windows.Forms.GroupBox()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePickerPeriodoHasta = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePickerPeriodoDesde = New System.Windows.Forms.DateTimePicker()
        Me.ToolStripMenu.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.FOLVCompAsoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MyContextMenu.SuspendLayout()
        Me.GroupBoxPeriodo.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnVer, Me.ToolStripSeparator2, Me.BtnCancelar})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(700, 25)
        Me.ToolStripMenu.TabIndex = 0
        Me.ToolStripMenu.Text = "ToolStrip1"
        '
        'BtnVer
        '
        Me.BtnVer.Image = Global.Principal.My.Resources.Resources.report
        Me.BtnVer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnVer.Name = "BtnVer"
        Me.BtnVer.Size = New System.Drawing.Size(43, 22)
        Me.BtnVer.Text = "Ver"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = Global.Principal.My.Resources.Resources.door_out
        Me.BtnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(74, 22)
        Me.BtnCancelar.Text = "Salir [Esc]"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(143, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Comprobantes del proveedor"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CtlCustomComboProveedor
        '
        Me.CtlCustomComboProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlCustomComboProveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlCustomComboProveedor.BusquedaPorCodigobarra = False
        Me.CtlCustomComboProveedor.ColumnasExtras = Nothing
        Me.CtlCustomComboProveedor.DataSource = Nothing
        Me.CtlCustomComboProveedor.DisplayMember = Nothing
        Me.CtlCustomComboProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CtlCustomComboProveedor.FormularioDeAlta = Nothing
        Me.CtlCustomComboProveedor.FormularioDeBusqueda = Nothing
        Me.CtlCustomComboProveedor.Location = New System.Drawing.Point(3, 16)
        Me.CtlCustomComboProveedor.MaximumSize = New System.Drawing.Size(500, 25)
        Me.CtlCustomComboProveedor.MinimumSize = New System.Drawing.Size(200, 25)
        Me.CtlCustomComboProveedor.Name = "CtlCustomComboProveedor"
        Me.CtlCustomComboProveedor.SelectedIndex = -1
        Me.CtlCustomComboProveedor.SelectedItem = Nothing
        Me.CtlCustomComboProveedor.SelectedText = ""
        Me.CtlCustomComboProveedor.SelectedValue = Nothing
        Me.CtlCustomComboProveedor.Size = New System.Drawing.Size(367, 25)
        Me.CtlCustomComboProveedor.TabIndex = 2
        Me.CtlCustomComboProveedor.ValueMember = Nothing
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.FOLVCompAsoc, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBoxPeriodo, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 25)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.28986!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.71014!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(700, 347)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.CtlCustomComboProveedor)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(694, 50)
        Me.Panel1.TabIndex = 4
        '
        'FOLVCompAsoc
        '
        Me.FOLVCompAsoc.AlternateRowBackColor = System.Drawing.Color.LightSteelBlue
        Me.FOLVCompAsoc.ContextMenuStrip = Me.MyContextMenu
        Me.FOLVCompAsoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FOLVCompAsoc.Location = New System.Drawing.Point(3, 59)
        Me.FOLVCompAsoc.Name = "FOLVCompAsoc"
        Me.FOLVCompAsoc.ShowGroups = False
        Me.FOLVCompAsoc.ShowHeaderInAllViews = False
        Me.FOLVCompAsoc.Size = New System.Drawing.Size(694, 214)
        Me.FOLVCompAsoc.TabIndex = 4
        Me.FOLVCompAsoc.UseAlternatingBackColors = True
        Me.FOLVCompAsoc.UseCompatibleStateImageBehavior = False
        Me.FOLVCompAsoc.View = System.Windows.Forms.View.Details
        Me.FOLVCompAsoc.VirtualMode = True
        '
        'MyContextMenu
        '
        Me.MyContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContextMenuItemVer})
        Me.MyContextMenu.Name = "ContextMenu"
        Me.MyContextMenu.Size = New System.Drawing.Size(196, 48)
        '
        'ContextMenuItemVer
        '
        Me.ContextMenuItemVer.Image = Global.Principal.My.Resources.Resources.report_magnify
        Me.ContextMenuItemVer.Name = "ContextMenuItemVer"
        Me.ContextMenuItemVer.Size = New System.Drawing.Size(195, 22)
        Me.ContextMenuItemVer.Text = "Visualizar comprobante"
        '
        'GroupBoxPeriodo
        '
        Me.GroupBoxPeriodo.Controls.Add(Me.BtnGuardar)
        Me.GroupBoxPeriodo.Controls.Add(Me.Label3)
        Me.GroupBoxPeriodo.Controls.Add(Me.Label1)
        Me.GroupBoxPeriodo.Controls.Add(Me.DateTimePickerPeriodoHasta)
        Me.GroupBoxPeriodo.Controls.Add(Me.DateTimePickerPeriodoDesde)
        Me.GroupBoxPeriodo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxPeriodo.Location = New System.Drawing.Point(3, 279)
        Me.GroupBoxPeriodo.Name = "GroupBoxPeriodo"
        Me.GroupBoxPeriodo.Size = New System.Drawing.Size(694, 65)
        Me.GroupBoxPeriodo.TabIndex = 0
        Me.GroupBoxPeriodo.TabStop = False
        Me.GroupBoxPeriodo.Text = "Período Facturado"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnGuardar.Image = Global.Principal.My.Resources.Resources.disk
        Me.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGuardar.Location = New System.Drawing.Point(370, 18)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(154, 23)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "Actualizar Período"
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(208, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Hasta:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(45, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Desde:"
        '
        'DateTimePickerPeriodoHasta
        '
        Me.DateTimePickerPeriodoHasta.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DateTimePickerPeriodoHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerPeriodoHasta.Location = New System.Drawing.Point(252, 19)
        Me.DateTimePickerPeriodoHasta.Name = "DateTimePickerPeriodoHasta"
        Me.DateTimePickerPeriodoHasta.Size = New System.Drawing.Size(112, 20)
        Me.DateTimePickerPeriodoHasta.TabIndex = 1
        '
        'DateTimePickerPeriodoDesde
        '
        Me.DateTimePickerPeriodoDesde.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DateTimePickerPeriodoDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerPeriodoDesde.Location = New System.Drawing.Point(90, 19)
        Me.DateTimePickerPeriodoDesde.Name = "DateTimePickerPeriodoDesde"
        Me.DateTimePickerPeriodoDesde.Size = New System.Drawing.Size(112, 20)
        Me.DateTimePickerPeriodoDesde.TabIndex = 0
        '
        'FormPeriodoCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(700, 372)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormPeriodoCompras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormArticulo"
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.FOLVCompAsoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MyContextMenu.ResumeLayout(False)
        Me.GroupBoxPeriodo.ResumeLayout(False)
        Me.GroupBoxPeriodo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnVer As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CtlCustomComboProveedor As Principal.CtlCustomCombo
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents FOLVCompAsoc As BrightIdeasSoftware.FastObjectListView
    Friend WithEvents MyContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ContextMenuItemVer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupBoxPeriodo As System.Windows.Forms.GroupBox
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerPeriodoHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePickerPeriodoDesde As System.Windows.Forms.DateTimePicker
End Class
