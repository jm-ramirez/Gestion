<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormConsultaCheque
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormConsultaCheque))
        Me.TLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.ToolStripMenu = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.TextBoxFilter = New System.Windows.Forms.ToolStripTextBox()
        Me.BtnFiltrar = New System.Windows.Forms.ToolStripButton()
        Me.BtnBorrarFiltro = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnSalir = New System.Windows.Forms.ToolStripButton()
        Me.StatusStripBar = New System.Windows.Forms.StatusStrip()
        Me.StatusLabelRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblSel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.FOLVRegistros = New BrightIdeasSoftware.FastObjectListView()
        Me.MyContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextMenuItemRechazar = New System.Windows.Forms.ToolStripMenuItem()
        Me.TLayoutPanel.SuspendLayout()
        Me.ToolStripMenu.SuspendLayout()
        Me.StatusStripBar.SuspendLayout()
        CType(Me.FOLVRegistros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MyContextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'TLayoutPanel
        '
        Me.TLayoutPanel.ColumnCount = 1
        Me.TLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TLayoutPanel.Controls.Add(Me.ToolStripMenu, 0, 0)
        Me.TLayoutPanel.Controls.Add(Me.StatusStripBar, 0, 2)
        Me.TLayoutPanel.Controls.Add(Me.FOLVRegistros, 0, 1)
        Me.TLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.TLayoutPanel.Name = "TLayoutPanel"
        Me.TLayoutPanel.RowCount = 3
        Me.TLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TLayoutPanel.Size = New System.Drawing.Size(853, 512)
        Me.TLayoutPanel.TabIndex = 0
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.TextBoxFilter, Me.BtnFiltrar, Me.BtnBorrarFiltro, Me.ToolStripSeparator1, Me.BtnSalir})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(853, 25)
        Me.ToolStripMenu.TabIndex = 0
        Me.ToolStripMenu.Text = "ToolStrip1"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'TextBoxFilter
        '
        Me.TextBoxFilter.Name = "TextBoxFilter"
        Me.TextBoxFilter.Size = New System.Drawing.Size(300, 25)
        '
        'BtnFiltrar
        '
        Me.BtnFiltrar.Image = Global.Principal.My.Resources.Resources.filter
        Me.BtnFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFiltrar.Name = "BtnFiltrar"
        Me.BtnFiltrar.Size = New System.Drawing.Size(55, 22)
        Me.BtnFiltrar.Text = "Filtrar"
        '
        'BtnBorrarFiltro
        '
        Me.BtnBorrarFiltro.Image = Global.Principal.My.Resources.Resources.clearFilter
        Me.BtnBorrarFiltro.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnBorrarFiltro.Name = "BtnBorrarFiltro"
        Me.BtnBorrarFiltro.Size = New System.Drawing.Size(82, 22)
        Me.BtnBorrarFiltro.Text = "Quitar filtro"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BtnSalir
        '
        Me.BtnSalir.Image = Global.Principal.My.Resources.Resources.door_out
        Me.BtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(74, 22)
        Me.BtnSalir.Text = "Salir [Esc]"
        '
        'StatusStripBar
        '
        Me.StatusStripBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.StatusStripBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabelRegistros, Me.lblSel})
        Me.StatusStripBar.Location = New System.Drawing.Point(0, 482)
        Me.StatusStripBar.Name = "StatusStripBar"
        Me.StatusStripBar.Size = New System.Drawing.Size(853, 30)
        Me.StatusStripBar.TabIndex = 2
        Me.StatusStripBar.Text = "StatusStrip1"
        '
        'StatusLabelRegistros
        '
        Me.StatusLabelRegistros.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.StatusLabelRegistros.Name = "StatusLabelRegistros"
        Me.StatusLabelRegistros.Size = New System.Drawing.Size(63, 25)
        Me.StatusLabelRegistros.Text = "Reg. 0 de 0"
        '
        'lblSel
        '
        Me.lblSel.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblSel.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSel.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblSel.Name = "lblSel"
        Me.lblSel.Size = New System.Drawing.Size(161, 25)
        Me.lblSel.Text = "ToolStripStatusLabel1"
        '
        'FOLVRegistros
        '
        Me.FOLVRegistros.AlternateRowBackColor = System.Drawing.Color.LightSteelBlue
        Me.FOLVRegistros.ContextMenuStrip = Me.MyContextMenu
        Me.FOLVRegistros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FOLVRegistros.EmptyListMsg = "No hay datos para mostrar"
        Me.FOLVRegistros.FullRowSelect = True
        Me.FOLVRegistros.Location = New System.Drawing.Point(3, 33)
        Me.FOLVRegistros.Name = "FOLVRegistros"
        Me.FOLVRegistros.ShowGroups = False
        Me.FOLVRegistros.ShowHeaderInAllViews = False
        Me.FOLVRegistros.Size = New System.Drawing.Size(847, 446)
        Me.FOLVRegistros.TabIndex = 3
        Me.FOLVRegistros.UseAlternatingBackColors = True
        Me.FOLVRegistros.UseCellFormatEvents = True
        Me.FOLVRegistros.UseCompatibleStateImageBehavior = False
        Me.FOLVRegistros.View = System.Windows.Forms.View.Details
        Me.FOLVRegistros.VirtualMode = True
        '
        'MyContextMenu
        '
        Me.MyContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContextMenuItemRechazar})
        Me.MyContextMenu.Name = "ContextMenu"
        Me.MyContextMenu.Size = New System.Drawing.Size(189, 26)
        '
        'ContextMenuItemRechazar
        '
        Me.ContextMenuItemRechazar.Image = Global.Principal.My.Resources.Resources.delete
        Me.ContextMenuItemRechazar.Name = "ContextMenuItemRechazar"
        Me.ContextMenuItemRechazar.Size = New System.Drawing.Size(188, 22)
        Me.ContextMenuItemRechazar.Text = "Marcar como rechazado"
        '
        'FormConsultaCheque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 512)
        Me.Controls.Add(Me.TLayoutPanel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FormConsultaCheque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Cheques"
        Me.TLayoutPanel.ResumeLayout(False)
        Me.TLayoutPanel.PerformLayout()
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.StatusStripBar.ResumeLayout(False)
        Me.StatusStripBar.PerformLayout()
        CType(Me.FOLVRegistros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MyContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnSalir As System.Windows.Forms.ToolStripButton
    'BrightIdeasSoftware.FastObjectListView
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnFiltrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnBorrarFiltro As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStripBar As System.Windows.Forms.StatusStrip
    Friend WithEvents StatusLabelRegistros As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents FOLVRegistros As BrightIdeasSoftware.FastObjectListView
    Friend WithEvents TextBoxFilter As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents lblSel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MyContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ContextMenuItemRechazar As System.Windows.Forms.ToolStripMenuItem
End Class
