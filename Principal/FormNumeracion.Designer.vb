<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormNumeracion
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
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.TextBoxFilter = New System.Windows.Forms.ToolStripTextBox()
        Me.BtnFiltrar = New System.Windows.Forms.ToolStripButton()
        Me.BtnBorrarFiltro = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnAfip = New System.Windows.Forms.ToolStripButton()
        Me.FOLVRegistros = New BrightIdeasSoftware.FastObjectListView()
        Me.StatusBarNumeracion = New System.Windows.Forms.StatusStrip()
        Me.ToolStripLabelStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripMenu.SuspendLayout()
        CType(Me.FOLVRegistros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusBarNumeracion.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnGuardar, Me.BtnCancelar, Me.ToolStripSeparator3, Me.TextBoxFilter, Me.BtnFiltrar, Me.BtnBorrarFiltro, Me.ToolStripSeparator1, Me.BtnAfip})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(580, 25)
        Me.ToolStripMenu.TabIndex = 0
        Me.ToolStripMenu.Text = "ToolStrip1"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Image = Global.Principal.My.Resources.Resources.disk
        Me.BtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(66, 22)
        Me.BtnGuardar.Text = "Guardar [F12]"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = Global.Principal.My.Resources.Resources.cancel
        Me.BtnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(69, 22)
        Me.BtnCancelar.Text = "Cancelar [Esc]"
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
        'BtnAfip
        '
        Me.BtnAfip.Image = Global.Principal.My.Resources.Resources.server_go
        Me.BtnAfip.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnAfip.Name = "BtnAfip"
        Me.BtnAfip.Size = New System.Drawing.Size(109, 22)
        Me.BtnAfip.Text = "Numeración AFIP"
        '
        'FOLVRegistros
        '
        Me.FOLVRegistros.AlternateRowBackColor = System.Drawing.Color.LightSteelBlue
        Me.FOLVRegistros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FOLVRegistros.EmptyListMsg = "No hay datos para mostrar"
        Me.FOLVRegistros.FullRowSelect = True
        Me.FOLVRegistros.Location = New System.Drawing.Point(0, 25)
        Me.FOLVRegistros.Name = "FOLVRegistros"
        Me.FOLVRegistros.ShowGroups = False
        Me.FOLVRegistros.ShowHeaderInAllViews = False
        Me.FOLVRegistros.Size = New System.Drawing.Size(580, 426)
        Me.FOLVRegistros.TabIndex = 4
        Me.FOLVRegistros.UseAlternatingBackColors = True
        Me.FOLVRegistros.UseCompatibleStateImageBehavior = False
        Me.FOLVRegistros.View = System.Windows.Forms.View.Details
        Me.FOLVRegistros.VirtualMode = True
        '
        'StatusBarNumeracion
        '
        Me.StatusBarNumeracion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabelStatus})
        Me.StatusBarNumeracion.Location = New System.Drawing.Point(0, 429)
        Me.StatusBarNumeracion.Name = "StatusBarNumeracion"
        Me.StatusBarNumeracion.Size = New System.Drawing.Size(580, 22)
        Me.StatusBarNumeracion.TabIndex = 5
        Me.StatusBarNumeracion.Text = "StatusStrip1"
        '
        'ToolStripLabelStatus
        '
        Me.ToolStripLabelStatus.Name = "ToolStripLabelStatus"
        Me.ToolStripLabelStatus.Size = New System.Drawing.Size(0, 17)
        '
        'FormNumeracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(580, 451)
        Me.Controls.Add(Me.StatusBarNumeracion)
        Me.Controls.Add(Me.FOLVRegistros)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormNumeracion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormArticulo"
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        CType(Me.FOLVRegistros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusBarNumeracion.ResumeLayout(False)
        Me.StatusBarNumeracion.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TextBoxFilter As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BtnFiltrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnBorrarFiltro As System.Windows.Forms.ToolStripButton
    Friend WithEvents FOLVRegistros As BrightIdeasSoftware.FastObjectListView
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnAfip As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusBarNumeracion As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripLabelStatus As System.Windows.Forms.ToolStripStatusLabel
End Class
