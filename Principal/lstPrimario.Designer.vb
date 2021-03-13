<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class lstPrimario
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
        Me.optDetalle = New System.Windows.Forms.RadioButton()
        Me.optId = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CtlComboHasta = New Principal.CtlCustomCombo()
        Me.CtlComboDesde = New Principal.CtlCustomCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LabelTituloFiltro = New System.Windows.Forms.Label()
        Me.ToolStripMenu.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnReporte, Me.BtnCancelar})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(555, 25)
        Me.ToolStripMenu.TabIndex = 18
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
        Me.GroupBox1.Controls.Add(Me.optDetalle)
        Me.GroupBox1.Controls.Add(Me.optId)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(71, 67)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Orden: "
        '
        'optDetalle
        '
        Me.optDetalle.AutoSize = True
        Me.optDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optDetalle.Location = New System.Drawing.Point(7, 43)
        Me.optDetalle.Name = "optDetalle"
        Me.optDetalle.Size = New System.Drawing.Size(58, 17)
        Me.optDetalle.TabIndex = 3
        Me.optDetalle.TabStop = True
        Me.optDetalle.Text = "Detalle"
        Me.optDetalle.UseVisualStyleBackColor = True
        '
        'optId
        '
        Me.optId.AutoSize = True
        Me.optId.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optId.Location = New System.Drawing.Point(7, 19)
        Me.optId.Name = "optId"
        Me.optId.Size = New System.Drawing.Size(58, 17)
        Me.optId.TabIndex = 2
        Me.optId.TabStop = True
        Me.optId.Text = "Código"
        Me.optId.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(104, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Desde"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CtlComboHasta
        '
        Me.CtlComboHasta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlComboHasta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlComboHasta.BusquedaPorCodigobarra = False
        Me.CtlComboHasta.ColumnasExtras = Nothing
        Me.CtlComboHasta.CustomFormatArt = False
        Me.CtlComboHasta.DataSource = Nothing
        Me.CtlComboHasta.DisplayMember = Nothing
        Me.CtlComboHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CtlComboHasta.FormularioDeAlta = Nothing
        Me.CtlComboHasta.FormularioDeBusqueda = Nothing
        Me.CtlComboHasta.Location = New System.Drawing.Point(148, 100)
        Me.CtlComboHasta.MaximumSize = New System.Drawing.Size(500, 25)
        Me.CtlComboHasta.MinimumSize = New System.Drawing.Size(200, 25)
        Me.CtlComboHasta.Name = "CtlComboHasta"
        Me.CtlComboHasta.SelectedIndex = -1
        Me.CtlComboHasta.SelectedItem = Nothing
        Me.CtlComboHasta.SelectedText = ""
        Me.CtlComboHasta.SelectedValue = Nothing
        Me.CtlComboHasta.Size = New System.Drawing.Size(383, 25)
        Me.CtlComboHasta.TabIndex = 1
        Me.CtlComboHasta.ValueMember = Nothing
        '
        'CtlComboDesde
        '
        Me.CtlComboDesde.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlComboDesde.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlComboDesde.BusquedaPorCodigobarra = False
        Me.CtlComboDesde.ColumnasExtras = Nothing
        Me.CtlComboDesde.CustomFormatArt = False
        Me.CtlComboDesde.DataSource = Nothing
        Me.CtlComboDesde.DisplayMember = Nothing
        Me.CtlComboDesde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CtlComboDesde.FormularioDeAlta = Nothing
        Me.CtlComboDesde.FormularioDeBusqueda = Nothing
        Me.CtlComboDesde.Location = New System.Drawing.Point(148, 69)
        Me.CtlComboDesde.MaximumSize = New System.Drawing.Size(500, 25)
        Me.CtlComboDesde.MinimumSize = New System.Drawing.Size(200, 25)
        Me.CtlComboDesde.Name = "CtlComboDesde"
        Me.CtlComboDesde.SelectedIndex = -1
        Me.CtlComboDesde.SelectedItem = Nothing
        Me.CtlComboDesde.SelectedText = ""
        Me.CtlComboDesde.SelectedValue = Nothing
        Me.CtlComboDesde.Size = New System.Drawing.Size(383, 25)
        Me.CtlComboDesde.TabIndex = 0
        Me.CtlComboDesde.ValueMember = Nothing
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(107, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Hasta"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelTituloFiltro
        '
        Me.LabelTituloFiltro.AutoSize = True
        Me.LabelTituloFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTituloFiltro.Location = New System.Drawing.Point(89, 41)
        Me.LabelTituloFiltro.Name = "LabelTituloFiltro"
        Me.LabelTituloFiltro.Size = New System.Drawing.Size(116, 13)
        Me.LabelTituloFiltro.TabIndex = 21
        Me.LabelTituloFiltro.Text = "Entorno de Zonas :"
        Me.LabelTituloFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lstPrimario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(555, 145)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CtlComboHasta)
        Me.Controls.Add(Me.CtlComboDesde)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LabelTituloFiltro)
        Me.KeyPreview = True
        Me.Name = "lstPrimario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "lstConcBanc"
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
    Friend WithEvents optDetalle As System.Windows.Forms.RadioButton
    Friend WithEvents optId As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CtlComboHasta As Principal.CtlCustomCombo
    Friend WithEvents CtlComboDesde As Principal.CtlCustomCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LabelTituloFiltro As System.Windows.Forms.Label
End Class
