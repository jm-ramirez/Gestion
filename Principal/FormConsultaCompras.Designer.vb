<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormConsultaCompras
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
        Me.BtnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CtlCustomComboProveedor = New Principal.CtlCustomCombo()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FOLVCompAsoc = New BrightIdeasSoftware.FastObjectListView()
        Me.MyContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextMenuItemVer = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ContextMenuItemAnular = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuItemDesaplicar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenu.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.FOLVCompAsoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MyContextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnVer, Me.BtnCancelar})
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
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.FOLVCompAsoc, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 25)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.69741!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.3026!))
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
        Me.Panel1.Size = New System.Drawing.Size(694, 45)
        Me.Panel1.TabIndex = 4
        '
        'FOLVCompAsoc
        '
        Me.FOLVCompAsoc.AlternateRowBackColor = System.Drawing.Color.LightSteelBlue
        Me.FOLVCompAsoc.ContextMenuStrip = Me.MyContextMenu
        Me.FOLVCompAsoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FOLVCompAsoc.Location = New System.Drawing.Point(3, 54)
        Me.FOLVCompAsoc.Name = "FOLVCompAsoc"
        Me.FOLVCompAsoc.ShowGroups = False
        Me.FOLVCompAsoc.ShowHeaderInAllViews = False
        Me.FOLVCompAsoc.Size = New System.Drawing.Size(694, 290)
        Me.FOLVCompAsoc.TabIndex = 4
        Me.FOLVCompAsoc.UseAlternatingBackColors = True
        Me.FOLVCompAsoc.UseCompatibleStateImageBehavior = False
        Me.FOLVCompAsoc.View = System.Windows.Forms.View.Details
        Me.FOLVCompAsoc.VirtualMode = True
        '
        'MyContextMenu
        '
        Me.MyContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContextMenuItemVer, Me.ContextMenuItemDesaplicar, Me.ToolStripSeparator1, Me.ContextMenuItemAnular})
        Me.MyContextMenu.Name = "ContextMenu"
        Me.MyContextMenu.Size = New System.Drawing.Size(247, 98)
        '
        'ContextMenuItemVer
        '
        Me.ContextMenuItemVer.Image = Global.Principal.My.Resources.Resources.report_magnify
        Me.ContextMenuItemVer.Name = "ContextMenuItemVer"
        Me.ContextMenuItemVer.Size = New System.Drawing.Size(246, 22)
        Me.ContextMenuItemVer.Text = "Visualizar comprobante"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(243, 6)
        '
        'ContextMenuItemAnular
        '
        Me.ContextMenuItemAnular.Image = Global.Principal.My.Resources.Resources.delete
        Me.ContextMenuItemAnular.Name = "ContextMenuItemAnular"
        Me.ContextMenuItemAnular.Size = New System.Drawing.Size(246, 22)
        Me.ContextMenuItemAnular.Text = "Anular comprobante seleccionado"
        '
        'ContextMenuItemDesaplicar
        '
        Me.ContextMenuItemDesaplicar.Name = "ContextMenuItemDesaplicar"
        Me.ContextMenuItemDesaplicar.Size = New System.Drawing.Size(246, 22)
        Me.ContextMenuItemDesaplicar.Text = "Desaplicar orden de Pago"
        '
        'FormConsultaCompras
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
        Me.Name = "FormConsultaCompras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormArticulo"
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.FOLVCompAsoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MyContextMenu.ResumeLayout(False)
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
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ContextMenuItemAnular As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuItemDesaplicar As System.Windows.Forms.ToolStripMenuItem
End Class
