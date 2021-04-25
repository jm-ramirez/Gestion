<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class lstArticulos
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ToolStripMenu = New System.Windows.Forms.ToolStrip()
        Me.BtnReporte = New System.Windows.Forms.ToolStripButton()
        Me.BtnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optDetalle = New System.Windows.Forms.RadioButton()
        Me.optId = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LabelTituloFiltro = New System.Windows.Forms.Label()
        Me.cboPH = New Principal.CtlCustomCombo()
        Me.cboPD = New Principal.CtlCustomCombo()
        Me.CheckBoxCategorias = New System.Windows.Forms.CheckBox()
        Me.CtlComboCategorias = New Principal.CtlCustomCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolStripMenu.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnReporte, Me.BtnCancelar})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(574, 25)
        Me.ToolStripMenu.TabIndex = 63
        Me.ToolStripMenu.Text = "ToolStrip1"
        '
        'BtnReporte
        '
        Me.BtnReporte.Image = Global.Principal.My.Resources.Resources.report
        Me.BtnReporte.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnReporte.Name = "BtnReporte"
        Me.BtnReporte.Size = New System.Drawing.Size(141, 22)
        Me.BtnReporte.Text = "Generar Reporte [F12]"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = Global.Principal.My.Resources.Resources.cancel
        Me.BtnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(101, 22)
        Me.BtnCancelar.Text = "Cancelar [Esc]"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optDetalle)
        Me.GroupBox1.Controls.Add(Me.optId)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 31)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(71, 67)
        Me.GroupBox1.TabIndex = 67
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Orden: "
        '
        'optDetalle
        '
        Me.optDetalle.AutoSize = True
        Me.optDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optDetalle.Location = New System.Drawing.Point(7, 19)
        Me.optDetalle.Name = "optDetalle"
        Me.optDetalle.Size = New System.Drawing.Size(58, 17)
        Me.optDetalle.TabIndex = 6
        Me.optDetalle.Text = "Detalle"
        Me.optDetalle.UseVisualStyleBackColor = True
        '
        'optId
        '
        Me.optId.AutoSize = True
        Me.optId.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optId.Location = New System.Drawing.Point(6, 38)
        Me.optId.Name = "optId"
        Me.optId.Size = New System.Drawing.Size(58, 17)
        Me.optId.TabIndex = 7
        Me.optId.Text = "Código"
        Me.optId.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(116, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 66
        Me.Label5.Text = "Desde"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(119, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 65
        Me.Label4.Text = "Hasta"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelTituloFiltro
        '
        Me.LabelTituloFiltro.AutoSize = True
        Me.LabelTituloFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTituloFiltro.Location = New System.Drawing.Point(101, 31)
        Me.LabelTituloFiltro.Name = "LabelTituloFiltro"
        Me.LabelTituloFiltro.Size = New System.Drawing.Size(132, 13)
        Me.LabelTituloFiltro.TabIndex = 64
        Me.LabelTituloFiltro.Text = "Entorno de Artículos :"
        Me.LabelTituloFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboPH
        '
        Me.cboPH.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.cboPH.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.cboPH.BusquedaPorCodigobarra = False
        Me.cboPH.ColumnasExtras = Nothing
        Me.cboPH.CustomFormatArt = False
        Me.cboPH.DataSource = Nothing
        Me.cboPH.DisplayMember = Nothing
        Me.cboPH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboPH.FormularioDeAlta = Nothing
        Me.cboPH.FormularioDeBusqueda = Nothing
        Me.cboPH.Location = New System.Drawing.Point(160, 84)
        Me.cboPH.MaximumSize = New System.Drawing.Size(500, 25)
        Me.cboPH.MinimumSize = New System.Drawing.Size(200, 25)
        Me.cboPH.Name = "cboPH"
        Me.cboPH.SelectedIndex = -1
        Me.cboPH.SelectedItem = Nothing
        Me.cboPH.SelectedText = ""
        Me.cboPH.SelectedValue = Nothing
        Me.cboPH.Size = New System.Drawing.Size(383, 25)
        Me.cboPH.TabIndex = 3
        Me.cboPH.ValueMember = Nothing
        '
        'cboPD
        '
        Me.cboPD.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.cboPD.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.cboPD.BusquedaPorCodigobarra = False
        Me.cboPD.ColumnasExtras = Nothing
        Me.cboPD.CustomFormatArt = False
        Me.cboPD.DataSource = Nothing
        Me.cboPD.DisplayMember = Nothing
        Me.cboPD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboPD.FormularioDeAlta = Nothing
        Me.cboPD.FormularioDeBusqueda = Nothing
        Me.cboPD.Location = New System.Drawing.Point(160, 53)
        Me.cboPD.MaximumSize = New System.Drawing.Size(500, 25)
        Me.cboPD.MinimumSize = New System.Drawing.Size(200, 25)
        Me.cboPD.Name = "cboPD"
        Me.cboPD.SelectedIndex = -1
        Me.cboPD.SelectedItem = Nothing
        Me.cboPD.SelectedText = ""
        Me.cboPD.SelectedValue = Nothing
        Me.cboPD.Size = New System.Drawing.Size(383, 25)
        Me.cboPD.TabIndex = 2
        Me.cboPD.ValueMember = Nothing
        '
        'CheckBoxCategorias
        '
        Me.CheckBoxCategorias.AutoSize = True
        Me.CheckBoxCategorias.Location = New System.Drawing.Point(60, 136)
        Me.CheckBoxCategorias.Name = "CheckBoxCategorias"
        Me.CheckBoxCategorias.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBoxCategorias.Size = New System.Drawing.Size(120, 17)
        Me.CheckBoxCategorias.TabIndex = 4
        Me.CheckBoxCategorias.Text = "Todas las Categoria"
        Me.CheckBoxCategorias.UseVisualStyleBackColor = True
        '
        'CtlComboCategorias
        '
        Me.CtlComboCategorias.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlComboCategorias.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlComboCategorias.BusquedaPorCodigobarra = False
        Me.CtlComboCategorias.ColumnasExtras = Nothing
        Me.CtlComboCategorias.CustomFormatArt = False
        Me.CtlComboCategorias.DataSource = Nothing
        Me.CtlComboCategorias.DisplayMember = Nothing
        Me.CtlComboCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CtlComboCategorias.FormularioDeAlta = Nothing
        Me.CtlComboCategorias.FormularioDeBusqueda = Nothing
        Me.CtlComboCategorias.Location = New System.Drawing.Point(160, 159)
        Me.CtlComboCategorias.MaximumSize = New System.Drawing.Size(500, 25)
        Me.CtlComboCategorias.MinimumSize = New System.Drawing.Size(200, 25)
        Me.CtlComboCategorias.Name = "CtlComboCategorias"
        Me.CtlComboCategorias.SelectedIndex = -1
        Me.CtlComboCategorias.SelectedItem = Nothing
        Me.CtlComboCategorias.SelectedText = ""
        Me.CtlComboCategorias.SelectedValue = Nothing
        Me.CtlComboCategorias.Size = New System.Drawing.Size(324, 25)
        Me.CtlComboCategorias.TabIndex = 5
        Me.CtlComboCategorias.ValueMember = Nothing
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(103, 164)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "Categoria"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(101, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(154, 13)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Ingrese filtro de Categoria"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lstArticulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(574, 217)
        Me.Controls.Add(Me.CheckBoxCategorias)
        Me.Controls.Add(Me.CtlComboCategorias)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboPH)
        Me.Controls.Add(Me.cboPD)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LabelTituloFiltro)
        Me.KeyPreview = True
        Me.Name = "lstArticulos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado de Piezas"
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
    Friend WithEvents cboPH As Principal.CtlCustomCombo
    Friend WithEvents cboPD As Principal.CtlCustomCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LabelTituloFiltro As System.Windows.Forms.Label
    Friend WithEvents CheckBoxCategorias As CheckBox
    Friend WithEvents CtlComboCategorias As CtlCustomCombo
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
