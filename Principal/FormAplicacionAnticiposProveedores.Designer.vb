<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAplicacionAnticiposProveedores
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelTotal = New System.Windows.Forms.Label()
        Me.FOLVCompPendientes = New BrightIdeasSoftware.FastObjectListView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LabelAnticipoSaldo = New System.Windows.Forms.Label()
        Me.LabelAnticipo = New System.Windows.Forms.Label()
        Me.CtlCustomComboProveedor = New Principal.CtlCustomCombo()
        Me.FOLVCompAnticipos = New BrightIdeasSoftware.FastObjectListView()
        Me.ToolStripMenu.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.FOLVCompPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.FOLVCompAnticipos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnGuardar, Me.BtnCancelar})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(700, 25)
        Me.ToolStripMenu.TabIndex = 0
        Me.ToolStripMenu.Text = "ToolStrip1"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Image = Global.Principal.My.Resources.Resources.table_save
        Me.BtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(129, 22)
        Me.BtnGuardar.Text = "Aplicar Anticipo [F12]"
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
        Me.Label2.Size = New System.Drawing.Size(118, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Anticipos del proveedor"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.LabelTotal, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.FOLVCompPendientes, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.FOLVCompAnticipos, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 25)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(700, 435)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'LabelTotal
        '
        Me.LabelTotal.BackColor = System.Drawing.Color.LightGreen
        Me.LabelTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelTotal.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LabelTotal.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotal.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelTotal.Location = New System.Drawing.Point(3, 410)
        Me.LabelTotal.Name = "LabelTotal"
        Me.LabelTotal.Size = New System.Drawing.Size(694, 25)
        Me.LabelTotal.TabIndex = 28
        Me.LabelTotal.Text = "Importe total aplicado $ 0.0"
        Me.LabelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FOLVCompPendientes
        '
        Me.FOLVCompPendientes.AlternateRowBackColor = System.Drawing.Color.LightSteelBlue
        Me.FOLVCompPendientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FOLVCompPendientes.Location = New System.Drawing.Point(3, 192)
        Me.FOLVCompPendientes.Name = "FOLVCompPendientes"
        Me.FOLVCompPendientes.ShowGroups = False
        Me.FOLVCompPendientes.ShowHeaderInAllViews = False
        Me.FOLVCompPendientes.Size = New System.Drawing.Size(694, 209)
        Me.FOLVCompPendientes.TabIndex = 5
        Me.FOLVCompPendientes.UseAlternatingBackColors = True
        Me.FOLVCompPendientes.UseCompatibleStateImageBehavior = False
        Me.FOLVCompPendientes.View = System.Windows.Forms.View.Details
        Me.FOLVCompPendientes.VirtualMode = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LabelAnticipoSaldo)
        Me.Panel1.Controls.Add(Me.LabelAnticipo)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.CtlCustomComboProveedor)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(694, 54)
        Me.Panel1.TabIndex = 4
        '
        'LabelAnticipoSaldo
        '
        Me.LabelAnticipoSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAnticipoSaldo.Location = New System.Drawing.Point(379, 23)
        Me.LabelAnticipoSaldo.Name = "LabelAnticipoSaldo"
        Me.LabelAnticipoSaldo.Size = New System.Drawing.Size(312, 23)
        Me.LabelAnticipoSaldo.TabIndex = 3
        Me.LabelAnticipoSaldo.Text = "Saldo Anticipo"
        Me.LabelAnticipoSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelAnticipo
        '
        Me.LabelAnticipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAnticipo.Location = New System.Drawing.Point(376, 0)
        Me.LabelAnticipo.Name = "LabelAnticipo"
        Me.LabelAnticipo.Size = New System.Drawing.Size(315, 23)
        Me.LabelAnticipo.TabIndex = 3
        Me.LabelAnticipo.Text = "Anticipo Seleccionado"
        Me.LabelAnticipo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CtlCustomComboProveedor
        '
        Me.CtlCustomComboProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlCustomComboProveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlCustomComboProveedor.BusquedaPorCodigobarra = False
        Me.CtlCustomComboProveedor.ColumnasExtras = Nothing
        Me.CtlCustomComboProveedor.CustomFormatArt = False
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
        'FOLVCompAnticipos
        '
        Me.FOLVCompAnticipos.AlternateRowBackColor = System.Drawing.Color.LightSteelBlue
        Me.FOLVCompAnticipos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FOLVCompAnticipos.Location = New System.Drawing.Point(3, 63)
        Me.FOLVCompAnticipos.Name = "FOLVCompAnticipos"
        Me.FOLVCompAnticipos.ShowGroups = False
        Me.FOLVCompAnticipos.ShowHeaderInAllViews = False
        Me.FOLVCompAnticipos.Size = New System.Drawing.Size(694, 123)
        Me.FOLVCompAnticipos.TabIndex = 4
        Me.FOLVCompAnticipos.UseAlternatingBackColors = True
        Me.FOLVCompAnticipos.UseCompatibleStateImageBehavior = False
        Me.FOLVCompAnticipos.View = System.Windows.Forms.View.Details
        Me.FOLVCompAnticipos.VirtualMode = True
        '
        'FormAplicacionAnticiposProveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(700, 460)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormAplicacionAnticiposProveedores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormArticulo"
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.FOLVCompPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.FOLVCompAnticipos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CtlCustomComboProveedor As Principal.CtlCustomCombo
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents FOLVCompAnticipos As BrightIdeasSoftware.FastObjectListView
    Friend WithEvents FOLVCompPendientes As BrightIdeasSoftware.FastObjectListView
    Friend WithEvents LabelTotal As System.Windows.Forms.Label
    Friend WithEvents LabelAnticipoSaldo As System.Windows.Forms.Label
    Friend WithEvents LabelAnticipo As System.Windows.Forms.Label
End Class
