<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class lstLocalidades
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
        Me.cboLocH = New Principal.CtlCustomCombo()
        Me.cboLocD = New Principal.CtlCustomCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboPciaH = New Principal.CtlCustomCombo()
        Me.cboPciaD = New Principal.CtlCustomCombo()
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
        Me.ToolStripMenu.Size = New System.Drawing.Size(557, 25)
        Me.ToolStripMenu.TabIndex = 27
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
        Me.GroupBox1.Location = New System.Drawing.Point(12, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(71, 67)
        Me.GroupBox1.TabIndex = 31
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
        Me.Label1.Location = New System.Drawing.Point(104, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Desde"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboLocH
        '
        Me.cboLocH.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.cboLocH.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.cboLocH.BusquedaPorCodigobarra = False
        Me.cboLocH.ColumnasExtras = Nothing
        Me.cboLocH.DataSource = Nothing
        Me.cboLocH.DisplayMember = Nothing
        Me.cboLocH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboLocH.FormularioDeAlta = Nothing
        Me.cboLocH.FormularioDeBusqueda = Nothing
        Me.cboLocH.Location = New System.Drawing.Point(148, 102)
        Me.cboLocH.MaximumSize = New System.Drawing.Size(500, 25)
        Me.cboLocH.MinimumSize = New System.Drawing.Size(200, 25)
        Me.cboLocH.Name = "cboLocH"
        Me.cboLocH.SelectedIndex = -1
        Me.cboLocH.SelectedItem = Nothing
        Me.cboLocH.SelectedText = ""
        Me.cboLocH.SelectedValue = Nothing
        Me.cboLocH.Size = New System.Drawing.Size(383, 25)
        Me.cboLocH.TabIndex = 1
        Me.cboLocH.ValueMember = Nothing
        '
        'cboLocD
        '
        Me.cboLocD.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.cboLocD.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.cboLocD.BusquedaPorCodigobarra = False
        Me.cboLocD.ColumnasExtras = Nothing
        Me.cboLocD.DataSource = Nothing
        Me.cboLocD.DisplayMember = Nothing
        Me.cboLocD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboLocD.FormularioDeAlta = Nothing
        Me.cboLocD.FormularioDeBusqueda = Nothing
        Me.cboLocD.Location = New System.Drawing.Point(148, 71)
        Me.cboLocD.MaximumSize = New System.Drawing.Size(500, 25)
        Me.cboLocD.MinimumSize = New System.Drawing.Size(200, 25)
        Me.cboLocD.Name = "cboLocD"
        Me.cboLocD.SelectedIndex = -1
        Me.cboLocD.SelectedItem = Nothing
        Me.cboLocD.SelectedText = ""
        Me.cboLocD.SelectedValue = Nothing
        Me.cboLocD.Size = New System.Drawing.Size(383, 25)
        Me.cboLocD.TabIndex = 0
        Me.cboLocD.ValueMember = Nothing
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(107, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Hasta"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(89, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(149, 13)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Entorno de Localidades :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(104, 176)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Desde"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboPciaH
        '
        Me.cboPciaH.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.cboPciaH.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.cboPciaH.BusquedaPorCodigobarra = False
        Me.cboPciaH.ColumnasExtras = Nothing
        Me.cboPciaH.DataSource = Nothing
        Me.cboPciaH.DisplayMember = Nothing
        Me.cboPciaH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboPciaH.FormularioDeAlta = Nothing
        Me.cboPciaH.FormularioDeBusqueda = Nothing
        Me.cboPciaH.Location = New System.Drawing.Point(148, 202)
        Me.cboPciaH.MaximumSize = New System.Drawing.Size(500, 25)
        Me.cboPciaH.MinimumSize = New System.Drawing.Size(200, 25)
        Me.cboPciaH.Name = "cboPciaH"
        Me.cboPciaH.SelectedIndex = -1
        Me.cboPciaH.SelectedItem = Nothing
        Me.cboPciaH.SelectedText = ""
        Me.cboPciaH.SelectedValue = Nothing
        Me.cboPciaH.Size = New System.Drawing.Size(383, 25)
        Me.cboPciaH.TabIndex = 3
        Me.cboPciaH.ValueMember = Nothing
        '
        'cboPciaD
        '
        Me.cboPciaD.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.cboPciaD.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.cboPciaD.BusquedaPorCodigobarra = False
        Me.cboPciaD.ColumnasExtras = Nothing
        Me.cboPciaD.DataSource = Nothing
        Me.cboPciaD.DisplayMember = Nothing
        Me.cboPciaD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboPciaD.FormularioDeAlta = Nothing
        Me.cboPciaD.FormularioDeBusqueda = Nothing
        Me.cboPciaD.Location = New System.Drawing.Point(148, 171)
        Me.cboPciaD.MaximumSize = New System.Drawing.Size(500, 25)
        Me.cboPciaD.MinimumSize = New System.Drawing.Size(200, 25)
        Me.cboPciaD.Name = "cboPciaD"
        Me.cboPciaD.SelectedIndex = -1
        Me.cboPciaD.SelectedItem = Nothing
        Me.cboPciaD.SelectedText = ""
        Me.cboPciaD.SelectedValue = Nothing
        Me.cboPciaD.Size = New System.Drawing.Size(383, 25)
        Me.cboPciaD.TabIndex = 2
        Me.cboPciaD.ValueMember = Nothing
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(107, 208)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Hasta"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelTituloFiltro
        '
        Me.LabelTituloFiltro.AutoSize = True
        Me.LabelTituloFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTituloFiltro.Location = New System.Drawing.Point(89, 143)
        Me.LabelTituloFiltro.Name = "LabelTituloFiltro"
        Me.LabelTituloFiltro.Size = New System.Drawing.Size(140, 13)
        Me.LabelTituloFiltro.TabIndex = 28
        Me.LabelTituloFiltro.Text = "Entorno de Provincias :"
        Me.LabelTituloFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lstLocalidades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(557, 250)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboLocH)
        Me.Controls.Add(Me.cboLocD)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboPciaH)
        Me.Controls.Add(Me.cboPciaD)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LabelTituloFiltro)
        Me.KeyPreview = True
        Me.Name = "lstLocalidades"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "lstLocalidades"
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
    Friend WithEvents cboLocH As Principal.CtlCustomCombo
    Friend WithEvents cboLocD As Principal.CtlCustomCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboPciaH As Principal.CtlCustomCombo
    Friend WithEvents cboPciaD As Principal.CtlCustomCombo
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents LabelTituloFiltro As System.Windows.Forms.Label
End Class
