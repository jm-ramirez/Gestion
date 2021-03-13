<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormABMConceptobancario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormABMConceptobancario))
        Me.TLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.ToolStripMenu = New System.Windows.Forms.ToolStrip()
        Me.BtnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditar = New System.Windows.Forms.ToolStripButton()
        Me.BtnEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.TextBoxFilter = New System.Windows.Forms.ToolStripTextBox()
        Me.BtnFiltrar = New System.Windows.Forms.ToolStripButton()
        Me.BtnBorrarFiltro = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnSalir = New System.Windows.Forms.ToolStripButton()
        Me.StatusStripBar = New System.Windows.Forms.StatusStrip()
        Me.StatusLabelRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.FOLVRegistros = New BrightIdeasSoftware.FastObjectListView()
        Me.TLayoutPanel.SuspendLayout()
        Me.ToolStripMenu.SuspendLayout()
        Me.StatusStripBar.SuspendLayout()
        CType(Me.FOLVRegistros, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TLayoutPanel.Size = New System.Drawing.Size(725, 365)
        Me.TLayoutPanel.TabIndex = 0
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnNuevo, Me.BtnEditar, Me.BtnEliminar, Me.ToolStripSeparator3, Me.TextBoxFilter, Me.BtnFiltrar, Me.BtnBorrarFiltro, Me.ToolStripSeparator1, Me.BtnImprimir, Me.ToolStripSeparator2, Me.BtnSalir})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(725, 25)
        Me.ToolStripMenu.TabIndex = 0
        Me.ToolStripMenu.Text = "ToolStrip1"
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Image = Global.Principal.My.Resources.Resources.table_add
        Me.BtnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(81, 22)
        Me.BtnNuevo.Text = "Nuevo [F2]"
        '
        'BtnEditar
        '
        Me.BtnEditar.Image = Global.Principal.My.Resources.Resources.table_edit
        Me.BtnEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEditar.Name = "BtnEditar"
        Me.BtnEditar.Size = New System.Drawing.Size(78, 22)
        Me.BtnEditar.Text = "Editar [F3]"
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Image = Global.Principal.My.Resources.Resources.table_delete
        Me.BtnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(89, 22)
        Me.BtnEliminar.Text = "Eliminar [Del]"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'TextBoxFilter
        '
        Me.TextBoxFilter.Name = "TextBoxFilter"
        Me.TextBoxFilter.Size = New System.Drawing.Size(100, 25)
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
        'BtnImprimir
        '
        Me.BtnImprimir.Image = Global.Principal.My.Resources.Resources.printer
        Me.BtnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(88, 22)
        Me.BtnImprimir.Text = "Imprimir [F5]"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
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
        Me.StatusStripBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabelRegistros})
        Me.StatusStripBar.Location = New System.Drawing.Point(0, 335)
        Me.StatusStripBar.Name = "StatusStripBar"
        Me.StatusStripBar.Size = New System.Drawing.Size(725, 30)
        Me.StatusStripBar.TabIndex = 2
        Me.StatusStripBar.Text = "StatusStrip1"
        '
        'StatusLabelRegistros
        '
        Me.StatusLabelRegistros.Name = "StatusLabelRegistros"
        Me.StatusLabelRegistros.Size = New System.Drawing.Size(63, 25)
        Me.StatusLabelRegistros.Text = "Reg. 0 de 0"
        '
        'FOLVRegistros
        '
        Me.FOLVRegistros.AlternateRowBackColor = System.Drawing.Color.LightSteelBlue
        Me.FOLVRegistros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FOLVRegistros.EmptyListMsg = "No hay datos para mostrar"
        Me.FOLVRegistros.FullRowSelect = True
        Me.FOLVRegistros.Location = New System.Drawing.Point(3, 33)
        Me.FOLVRegistros.Name = "FOLVRegistros"
        Me.FOLVRegistros.ShowGroups = False
        Me.FOLVRegistros.ShowHeaderInAllViews = False
        Me.FOLVRegistros.Size = New System.Drawing.Size(719, 299)
        Me.FOLVRegistros.TabIndex = 3
        Me.FOLVRegistros.UseAlternatingBackColors = True
        Me.FOLVRegistros.UseCompatibleStateImageBehavior = False
        Me.FOLVRegistros.View = System.Windows.Forms.View.Details
        Me.FOLVRegistros.VirtualMode = True
        '
        'FormABMConceptobancario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(725, 365)
        Me.Controls.Add(Me.TLayoutPanel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FormABMConceptobancario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ABM de Conceptos bancarios"
        Me.TLayoutPanel.ResumeLayout(False)
        Me.TLayoutPanel.PerformLayout()
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.StatusStripBar.ResumeLayout(False)
        Me.StatusStripBar.PerformLayout()
        CType(Me.FOLVRegistros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnSalir As System.Windows.Forms.ToolStripButton
    'BrightIdeasSoftware.FastObjectListView
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnFiltrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnBorrarFiltro As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStripBar As System.Windows.Forms.StatusStrip
    Friend WithEvents StatusLabelRegistros As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents FOLVRegistros As BrightIdeasSoftware.FastObjectListView
    Friend WithEvents TextBoxFilter As System.Windows.Forms.ToolStripTextBox
End Class
