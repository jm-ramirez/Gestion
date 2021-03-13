<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class lstRubrosArt
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboRubroH = New Principal.CtlCustomCombo()
        Me.cboRubroD = New Principal.CtlCustomCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboMaestroH = New Principal.CtlCustomCombo()
        Me.cboMaestroD = New Principal.CtlCustomCombo()
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
        Me.ToolStripMenu.Size = New System.Drawing.Size(568, 25)
        Me.ToolStripMenu.TabIndex = 39
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
        Me.GroupBox1.Location = New System.Drawing.Point(12, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(71, 67)
        Me.GroupBox1.TabIndex = 43
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
        Me.optDetalle.TabIndex = 5
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
        Me.optId.TabIndex = 4
        Me.optId.Text = "Código"
        Me.optId.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(104, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Desde"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboRubroH
        '
        Me.cboRubroH.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.cboRubroH.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.cboRubroH.BusquedaPorCodigobarra = False
        Me.cboRubroH.ColumnasExtras = Nothing
        Me.cboRubroH.CustomFormatArt = False
        Me.cboRubroH.DataSource = Nothing
        Me.cboRubroH.DisplayMember = Nothing
        Me.cboRubroH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboRubroH.FormularioDeAlta = Nothing
        Me.cboRubroH.FormularioDeBusqueda = Nothing
        Me.cboRubroH.Location = New System.Drawing.Point(148, 101)
        Me.cboRubroH.MaximumSize = New System.Drawing.Size(500, 25)
        Me.cboRubroH.MinimumSize = New System.Drawing.Size(200, 25)
        Me.cboRubroH.Name = "cboRubroH"
        Me.cboRubroH.SelectedIndex = -1
        Me.cboRubroH.SelectedItem = Nothing
        Me.cboRubroH.SelectedText = ""
        Me.cboRubroH.SelectedValue = Nothing
        Me.cboRubroH.Size = New System.Drawing.Size(383, 25)
        Me.cboRubroH.TabIndex = 1
        Me.cboRubroH.ValueMember = Nothing
        '
        'cboRubroD
        '
        Me.cboRubroD.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.cboRubroD.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.cboRubroD.BusquedaPorCodigobarra = False
        Me.cboRubroD.ColumnasExtras = Nothing
        Me.cboRubroD.CustomFormatArt = False
        Me.cboRubroD.DataSource = Nothing
        Me.cboRubroD.DisplayMember = Nothing
        Me.cboRubroD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboRubroD.FormularioDeAlta = Nothing
        Me.cboRubroD.FormularioDeBusqueda = Nothing
        Me.cboRubroD.Location = New System.Drawing.Point(148, 70)
        Me.cboRubroD.MaximumSize = New System.Drawing.Size(500, 25)
        Me.cboRubroD.MinimumSize = New System.Drawing.Size(200, 25)
        Me.cboRubroD.Name = "cboRubroD"
        Me.cboRubroD.SelectedIndex = -1
        Me.cboRubroD.SelectedItem = Nothing
        Me.cboRubroD.SelectedText = ""
        Me.cboRubroD.SelectedValue = Nothing
        Me.cboRubroD.Size = New System.Drawing.Size(383, 25)
        Me.cboRubroD.TabIndex = 0
        Me.cboRubroD.ValueMember = Nothing
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(107, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Hasta"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(89, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 13)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Entorno de Rubros :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(104, 175)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "Desde"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboMaestroH
        '
        Me.cboMaestroH.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.cboMaestroH.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.cboMaestroH.BusquedaPorCodigobarra = False
        Me.cboMaestroH.ColumnasExtras = Nothing
        Me.cboMaestroH.CustomFormatArt = False
        Me.cboMaestroH.DataSource = Nothing
        Me.cboMaestroH.DisplayMember = Nothing
        Me.cboMaestroH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboMaestroH.FormularioDeAlta = Nothing
        Me.cboMaestroH.FormularioDeBusqueda = Nothing
        Me.cboMaestroH.Location = New System.Drawing.Point(148, 201)
        Me.cboMaestroH.MaximumSize = New System.Drawing.Size(500, 25)
        Me.cboMaestroH.MinimumSize = New System.Drawing.Size(200, 25)
        Me.cboMaestroH.Name = "cboMaestroH"
        Me.cboMaestroH.SelectedIndex = -1
        Me.cboMaestroH.SelectedItem = Nothing
        Me.cboMaestroH.SelectedText = ""
        Me.cboMaestroH.SelectedValue = Nothing
        Me.cboMaestroH.Size = New System.Drawing.Size(383, 25)
        Me.cboMaestroH.TabIndex = 3
        Me.cboMaestroH.ValueMember = Nothing
        '
        'cboMaestroD
        '
        Me.cboMaestroD.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.cboMaestroD.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.cboMaestroD.BusquedaPorCodigobarra = False
        Me.cboMaestroD.ColumnasExtras = Nothing
        Me.cboMaestroD.CustomFormatArt = False
        Me.cboMaestroD.DataSource = Nothing
        Me.cboMaestroD.DisplayMember = Nothing
        Me.cboMaestroD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboMaestroD.FormularioDeAlta = Nothing
        Me.cboMaestroD.FormularioDeBusqueda = Nothing
        Me.cboMaestroD.Location = New System.Drawing.Point(148, 170)
        Me.cboMaestroD.MaximumSize = New System.Drawing.Size(500, 25)
        Me.cboMaestroD.MinimumSize = New System.Drawing.Size(200, 25)
        Me.cboMaestroD.Name = "cboMaestroD"
        Me.cboMaestroD.SelectedIndex = -1
        Me.cboMaestroD.SelectedItem = Nothing
        Me.cboMaestroD.SelectedText = ""
        Me.cboMaestroD.SelectedValue = Nothing
        Me.cboMaestroD.Size = New System.Drawing.Size(383, 25)
        Me.cboMaestroD.TabIndex = 2
        Me.cboMaestroD.ValueMember = Nothing
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(107, 207)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Hasta"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelTituloFiltro
        '
        Me.LabelTituloFiltro.AutoSize = True
        Me.LabelTituloFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTituloFiltro.Location = New System.Drawing.Point(89, 142)
        Me.LabelTituloFiltro.Name = "LabelTituloFiltro"
        Me.LabelTituloFiltro.Size = New System.Drawing.Size(176, 13)
        Me.LabelTituloFiltro.TabIndex = 40
        Me.LabelTituloFiltro.Text = "Entorno de Rubros Maestros :"
        Me.LabelTituloFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lstRubrosArt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(568, 248)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboRubroH)
        Me.Controls.Add(Me.cboRubroD)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboMaestroH)
        Me.Controls.Add(Me.cboMaestroD)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LabelTituloFiltro)
        Me.KeyPreview = True
        Me.Name = "lstRubrosArt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "lstRubrosArt"
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboRubroH As Principal.CtlCustomCombo
    Friend WithEvents cboRubroD As Principal.CtlCustomCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboMaestroH As Principal.CtlCustomCombo
    Friend WithEvents cboMaestroD As Principal.CtlCustomCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LabelTituloFiltro As System.Windows.Forms.Label
End Class
