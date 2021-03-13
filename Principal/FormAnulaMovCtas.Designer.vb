<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAnulaMovCtas
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
        Me.TLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.ToolStripMenu = New System.Windows.Forms.ToolStrip()
        Me.TextBoxFilter = New System.Windows.Forms.ToolStripTextBox()
        Me.BtnFiltrar = New System.Windows.Forms.ToolStripButton()
        Me.BtnBorrarFiltro = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnAnular = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnSalir = New System.Windows.Forms.ToolStripButton()
        Me.StatusStripBar = New System.Windows.Forms.StatusStrip()
        Me.StatusLabelRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.OLVRegistros = New BrightIdeasSoftware.ObjectListView()
        Me.ContextMenuStripReq = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItemVisualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemAnular = New System.Windows.Forms.ToolStripMenuItem()
        Me.TLayoutPanel.SuspendLayout()
        Me.ToolStripMenu.SuspendLayout()
        Me.StatusStripBar.SuspendLayout()
        CType(Me.OLVRegistros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripReq.SuspendLayout()
        Me.SuspendLayout()
        '
        'TLayoutPanel
        '
        Me.TLayoutPanel.ColumnCount = 1
        Me.TLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TLayoutPanel.Controls.Add(Me.ToolStripMenu, 0, 0)
        Me.TLayoutPanel.Controls.Add(Me.StatusStripBar, 0, 2)
        Me.TLayoutPanel.Controls.Add(Me.OLVRegistros, 0, 1)
        Me.TLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.TLayoutPanel.Name = "TLayoutPanel"
        Me.TLayoutPanel.RowCount = 3
        Me.TLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TLayoutPanel.Size = New System.Drawing.Size(749, 591)
        Me.TLayoutPanel.TabIndex = 2
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TextBoxFilter, Me.BtnFiltrar, Me.BtnBorrarFiltro, Me.ToolStripSeparator1, Me.BtnImprimir, Me.ToolStripSeparator4, Me.BtnAnular, Me.ToolStripSeparator2, Me.BtnSalir})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(749, 25)
        Me.ToolStripMenu.TabIndex = 0
        Me.ToolStripMenu.Text = "ToolStrip1"
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
        'BtnImprimir
        '
        Me.BtnImprimir.Image = Global.Principal.My.Resources.Resources.printer
        Me.BtnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(94, 22)
        Me.BtnImprimir.Text = "Visualizar [F5]"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'BtnAnular
        '
        Me.BtnAnular.Image = Global.Principal.My.Resources.Resources.delete
        Me.BtnAnular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnAnular.Name = "BtnAnular"
        Me.BtnAnular.Size = New System.Drawing.Size(84, 22)
        Me.BtnAnular.Text = "Anular [Del]"
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
        Me.StatusStripBar.Location = New System.Drawing.Point(0, 561)
        Me.StatusStripBar.Name = "StatusStripBar"
        Me.StatusStripBar.Size = New System.Drawing.Size(749, 30)
        Me.StatusStripBar.TabIndex = 2
        Me.StatusStripBar.Text = "StatusStrip1"
        '
        'StatusLabelRegistros
        '
        Me.StatusLabelRegistros.Name = "StatusLabelRegistros"
        Me.StatusLabelRegistros.Size = New System.Drawing.Size(63, 25)
        Me.StatusLabelRegistros.Text = "Reg. 0 de 0"
        '
        'OLVRegistros
        '
        Me.OLVRegistros.AlternateRowBackColor = System.Drawing.Color.LightSteelBlue
        Me.OLVRegistros.ContextMenuStrip = Me.ContextMenuStripReq
        Me.OLVRegistros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OLVRegistros.EmptyListMsg = "No hay datos para mostrar"
        Me.OLVRegistros.Location = New System.Drawing.Point(3, 33)
        Me.OLVRegistros.MultiSelect = False
        Me.OLVRegistros.Name = "OLVRegistros"
        Me.OLVRegistros.ShowGroups = False
        Me.OLVRegistros.ShowHeaderInAllViews = False
        Me.OLVRegistros.Size = New System.Drawing.Size(743, 525)
        Me.OLVRegistros.TabIndex = 3
        Me.OLVRegistros.UseAlternatingBackColors = True
        Me.OLVRegistros.UseCellFormatEvents = True
        Me.OLVRegistros.UseCompatibleStateImageBehavior = False
        Me.OLVRegistros.View = System.Windows.Forms.View.Details
        '
        'ContextMenuStripReq
        '
        Me.ContextMenuStripReq.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemVisualizar, Me.ToolStripSeparator3, Me.ToolStripMenuItemAnular})
        Me.ContextMenuStripReq.Name = "ContextMenuStripReq"
        Me.ContextMenuStripReq.Size = New System.Drawing.Size(223, 54)
        '
        'ToolStripMenuItemVisualizar
        '
        Me.ToolStripMenuItemVisualizar.Name = "ToolStripMenuItemVisualizar"
        Me.ToolStripMenuItemVisualizar.Size = New System.Drawing.Size(222, 22)
        Me.ToolStripMenuItemVisualizar.Text = "Visualizar comprobante"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(219, 6)
        '
        'ToolStripMenuItemAnular
        '
        Me.ToolStripMenuItemAnular.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItemAnular.Name = "ToolStripMenuItemAnular"
        Me.ToolStripMenuItemAnular.Size = New System.Drawing.Size(222, 22)
        Me.ToolStripMenuItemAnular.Text = "Anular Nota de Devolución"
        '
        'FormAnulaMovCtas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 591)
        Me.Controls.Add(Me.TLayoutPanel)
        Me.KeyPreview = True
        Me.Name = "FormAnulaMovCtas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormAnulaMovCtas"
        Me.TLayoutPanel.ResumeLayout(False)
        Me.TLayoutPanel.PerformLayout()
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.StatusStripBar.ResumeLayout(False)
        Me.StatusStripBar.PerformLayout()
        CType(Me.OLVRegistros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripReq.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents TextBoxFilter As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BtnFiltrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnBorrarFiltro As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStripBar As System.Windows.Forms.StatusStrip
    Friend WithEvents StatusLabelRegistros As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents OLVRegistros As BrightIdeasSoftware.ObjectListView
    Friend WithEvents ContextMenuStripReq As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItemVisualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItemAnular As System.Windows.Forms.ToolStripMenuItem
End Class
