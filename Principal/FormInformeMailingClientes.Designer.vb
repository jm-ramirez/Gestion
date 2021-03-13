<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInformeMailingClientes
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
        Me.BtnReporte = New System.Windows.Forms.ToolStripButton()
        Me.BtnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LabelTituloFiltro = New System.Windows.Forms.Label()
        Me.CtlComboClienteHasta = New Principal.CtlCustomCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CtlComboClienteDesde = New Principal.CtlCustomCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStripMenu.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnReporte, Me.BtnCancelar})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(498, 25)
        Me.ToolStripMenu.TabIndex = 0
        Me.ToolStripMenu.Text = "ToolStrip1"
        '
        'BtnReporte
        '
        Me.BtnReporte.Image = Global.Principal.My.Resources.Resources.report
        Me.BtnReporte.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnReporte.Name = "BtnReporte"
        Me.BtnReporte.Size = New System.Drawing.Size(137, 22)
        Me.BtnReporte.Text = "Generar Reporte [F12]"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = Global.Principal.My.Resources.Resources.cancel
        Me.BtnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(96, 22)
        Me.BtnCancelar.Text = "Cancelar [Esc]"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LabelTituloFiltro)
        Me.GroupBox1.Controls.Add(Me.CtlComboClienteHasta)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.CtlComboClienteDesde)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(474, 151)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        '
        'LabelTituloFiltro
        '
        Me.LabelTituloFiltro.AutoSize = True
        Me.LabelTituloFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTituloFiltro.Location = New System.Drawing.Point(22, 25)
        Me.LabelTituloFiltro.Name = "LabelTituloFiltro"
        Me.LabelTituloFiltro.Size = New System.Drawing.Size(126, 13)
        Me.LabelTituloFiltro.TabIndex = 83
        Me.LabelTituloFiltro.Text = "Entorno de Clientes :"
        Me.LabelTituloFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CtlComboClienteHasta
        '
        Me.CtlComboClienteHasta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlComboClienteHasta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlComboClienteHasta.BusquedaPorCodigobarra = False
        Me.CtlComboClienteHasta.ColumnasExtras = Nothing
        Me.CtlComboClienteHasta.CustomFormatArt = False
        Me.CtlComboClienteHasta.DataSource = Nothing
        Me.CtlComboClienteHasta.DisplayMember = Nothing
        Me.CtlComboClienteHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CtlComboClienteHasta.FormularioDeAlta = Nothing
        Me.CtlComboClienteHasta.FormularioDeBusqueda = Nothing
        Me.CtlComboClienteHasta.Location = New System.Drawing.Point(86, 87)
        Me.CtlComboClienteHasta.MaximumSize = New System.Drawing.Size(500, 25)
        Me.CtlComboClienteHasta.MinimumSize = New System.Drawing.Size(200, 25)
        Me.CtlComboClienteHasta.Name = "CtlComboClienteHasta"
        Me.CtlComboClienteHasta.SelectedIndex = -1
        Me.CtlComboClienteHasta.SelectedItem = Nothing
        Me.CtlComboClienteHasta.SelectedText = ""
        Me.CtlComboClienteHasta.SelectedValue = Nothing
        Me.CtlComboClienteHasta.Size = New System.Drawing.Size(356, 25)
        Me.CtlComboClienteHasta.TabIndex = 3
        Me.CtlComboClienteHasta.ValueMember = Nothing
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(45, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 82
        Me.Label2.Text = "Hasta"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CtlComboClienteDesde
        '
        Me.CtlComboClienteDesde.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlComboClienteDesde.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlComboClienteDesde.BusquedaPorCodigobarra = False
        Me.CtlComboClienteDesde.ColumnasExtras = Nothing
        Me.CtlComboClienteDesde.CustomFormatArt = False
        Me.CtlComboClienteDesde.DataSource = Nothing
        Me.CtlComboClienteDesde.DisplayMember = Nothing
        Me.CtlComboClienteDesde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CtlComboClienteDesde.FormularioDeAlta = Nothing
        Me.CtlComboClienteDesde.FormularioDeBusqueda = Nothing
        Me.CtlComboClienteDesde.Location = New System.Drawing.Point(86, 56)
        Me.CtlComboClienteDesde.MaximumSize = New System.Drawing.Size(500, 25)
        Me.CtlComboClienteDesde.MinimumSize = New System.Drawing.Size(200, 25)
        Me.CtlComboClienteDesde.Name = "CtlComboClienteDesde"
        Me.CtlComboClienteDesde.SelectedIndex = -1
        Me.CtlComboClienteDesde.SelectedItem = Nothing
        Me.CtlComboClienteDesde.SelectedText = ""
        Me.CtlComboClienteDesde.SelectedValue = Nothing
        Me.CtlComboClienteDesde.Size = New System.Drawing.Size(356, 25)
        Me.CtlComboClienteDesde.TabIndex = 2
        Me.CtlComboClienteDesde.ValueMember = Nothing
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Desde"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FormInformeMailingClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(498, 192)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormInformeMailingClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormListaPlanilla"
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnReporte As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelTituloFiltro As System.Windows.Forms.Label
    Friend WithEvents CtlComboClienteHasta As Principal.CtlCustomCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CtlComboClienteDesde As Principal.CtlCustomCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
