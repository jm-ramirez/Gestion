<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInfOrdenCompra
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RadioButtonArticulo = New System.Windows.Forms.RadioButton()
        Me.RadioButtonPedido = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RadioButtonTodas = New System.Windows.Forms.RadioButton()
        Me.RadioButtonSatisfechas = New System.Windows.Forms.RadioButton()
        Me.RadioButtonPendientes = New System.Windows.Forms.RadioButton()
        Me.LabelTituloFiltro = New System.Windows.Forms.Label()
        Me.CtlComboClientesHasta = New Principal.CtlCustomCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CtlComboClientesDesde = New Principal.CtlCustomCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStripMenu.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnReporte, Me.BtnCancelar})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(500, 25)
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
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.LabelTituloFiltro)
        Me.GroupBox1.Controls.Add(Me.CtlComboClientesHasta)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.CtlComboClientesDesde)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(476, 238)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RadioButtonArticulo)
        Me.GroupBox3.Controls.Add(Me.RadioButtonPedido)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(33, 161)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(418, 56)
        Me.GroupBox3.TabIndex = 76
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Agrupar Por : "
        '
        'RadioButtonArticulo
        '
        Me.RadioButtonArticulo.AutoSize = True
        Me.RadioButtonArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonArticulo.Location = New System.Drawing.Point(219, 21)
        Me.RadioButtonArticulo.Name = "RadioButtonArticulo"
        Me.RadioButtonArticulo.Size = New System.Drawing.Size(106, 17)
        Me.RadioButtonArticulo.TabIndex = 6
        Me.RadioButtonArticulo.Text = "Cliente + Artículo"
        Me.RadioButtonArticulo.UseVisualStyleBackColor = True
        '
        'RadioButtonPedido
        '
        Me.RadioButtonPedido.AutoSize = True
        Me.RadioButtonPedido.Checked = True
        Me.RadioButtonPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonPedido.Location = New System.Drawing.Point(97, 21)
        Me.RadioButtonPedido.Name = "RadioButtonPedido"
        Me.RadioButtonPedido.Size = New System.Drawing.Size(102, 17)
        Me.RadioButtonPedido.TabIndex = 5
        Me.RadioButtonPedido.TabStop = True
        Me.RadioButtonPedido.Text = "Cliente + Pedido"
        Me.RadioButtonPedido.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RadioButtonTodas)
        Me.GroupBox2.Controls.Add(Me.RadioButtonSatisfechas)
        Me.GroupBox2.Controls.Add(Me.RadioButtonPendientes)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(33, 99)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(418, 56)
        Me.GroupBox2.TabIndex = 75
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo de Orden : "
        '
        'RadioButtonTodas
        '
        Me.RadioButtonTodas.AutoSize = True
        Me.RadioButtonTodas.Checked = True
        Me.RadioButtonTodas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonTodas.Location = New System.Drawing.Point(70, 19)
        Me.RadioButtonTodas.Name = "RadioButtonTodas"
        Me.RadioButtonTodas.Size = New System.Drawing.Size(55, 17)
        Me.RadioButtonTodas.TabIndex = 2
        Me.RadioButtonTodas.Text = "Todas"
        Me.RadioButtonTodas.UseVisualStyleBackColor = True
        '
        'RadioButtonSatisfechas
        '
        Me.RadioButtonSatisfechas.AutoSize = True
        Me.RadioButtonSatisfechas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonSatisfechas.Location = New System.Drawing.Point(255, 19)
        Me.RadioButtonSatisfechas.Name = "RadioButtonSatisfechas"
        Me.RadioButtonSatisfechas.Size = New System.Drawing.Size(80, 17)
        Me.RadioButtonSatisfechas.TabIndex = 4
        Me.RadioButtonSatisfechas.Text = "Satisfechas"
        Me.RadioButtonSatisfechas.UseVisualStyleBackColor = True
        '
        'RadioButtonPendientes
        '
        Me.RadioButtonPendientes.AutoSize = True
        Me.RadioButtonPendientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonPendientes.Location = New System.Drawing.Point(157, 19)
        Me.RadioButtonPendientes.Name = "RadioButtonPendientes"
        Me.RadioButtonPendientes.Size = New System.Drawing.Size(78, 17)
        Me.RadioButtonPendientes.TabIndex = 3
        Me.RadioButtonPendientes.Text = "Pendientes"
        Me.RadioButtonPendientes.UseVisualStyleBackColor = True
        '
        'LabelTituloFiltro
        '
        Me.LabelTituloFiltro.AutoSize = True
        Me.LabelTituloFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTituloFiltro.Location = New System.Drawing.Point(30, 16)
        Me.LabelTituloFiltro.Name = "LabelTituloFiltro"
        Me.LabelTituloFiltro.Size = New System.Drawing.Size(126, 13)
        Me.LabelTituloFiltro.TabIndex = 69
        Me.LabelTituloFiltro.Text = "Entorno de Clientes :"
        Me.LabelTituloFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CtlComboClientesHasta
        '
        Me.CtlComboClientesHasta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlComboClientesHasta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlComboClientesHasta.BusquedaPorCodigobarra = False
        Me.CtlComboClientesHasta.ColumnasExtras = Nothing
        Me.CtlComboClientesHasta.CustomFormatArt = False
        Me.CtlComboClientesHasta.DataSource = Nothing
        Me.CtlComboClientesHasta.DisplayMember = Nothing
        Me.CtlComboClientesHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CtlComboClientesHasta.FormularioDeAlta = Nothing
        Me.CtlComboClientesHasta.FormularioDeBusqueda = Nothing
        Me.CtlComboClientesHasta.Location = New System.Drawing.Point(94, 68)
        Me.CtlComboClientesHasta.MaximumSize = New System.Drawing.Size(500, 25)
        Me.CtlComboClientesHasta.MinimumSize = New System.Drawing.Size(200, 25)
        Me.CtlComboClientesHasta.Name = "CtlComboClientesHasta"
        Me.CtlComboClientesHasta.SelectedIndex = -1
        Me.CtlComboClientesHasta.SelectedItem = Nothing
        Me.CtlComboClientesHasta.SelectedText = ""
        Me.CtlComboClientesHasta.SelectedValue = Nothing
        Me.CtlComboClientesHasta.Size = New System.Drawing.Size(356, 25)
        Me.CtlComboClientesHasta.TabIndex = 1
        Me.CtlComboClientesHasta.ValueMember = Nothing
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(53, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Hasta"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CtlComboClientesDesde
        '
        Me.CtlComboClientesDesde.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlComboClientesDesde.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlComboClientesDesde.BusquedaPorCodigobarra = False
        Me.CtlComboClientesDesde.ColumnasExtras = Nothing
        Me.CtlComboClientesDesde.CustomFormatArt = False
        Me.CtlComboClientesDesde.DataSource = Nothing
        Me.CtlComboClientesDesde.DisplayMember = Nothing
        Me.CtlComboClientesDesde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CtlComboClientesDesde.FormularioDeAlta = Nothing
        Me.CtlComboClientesDesde.FormularioDeBusqueda = Nothing
        Me.CtlComboClientesDesde.Location = New System.Drawing.Point(94, 37)
        Me.CtlComboClientesDesde.MaximumSize = New System.Drawing.Size(500, 25)
        Me.CtlComboClientesDesde.MinimumSize = New System.Drawing.Size(200, 25)
        Me.CtlComboClientesDesde.Name = "CtlComboClientesDesde"
        Me.CtlComboClientesDesde.SelectedIndex = -1
        Me.CtlComboClientesDesde.SelectedItem = Nothing
        Me.CtlComboClientesDesde.SelectedText = ""
        Me.CtlComboClientesDesde.SelectedValue = Nothing
        Me.CtlComboClientesDesde.Size = New System.Drawing.Size(356, 25)
        Me.CtlComboClientesDesde.TabIndex = 0
        Me.CtlComboClientesDesde.ValueMember = Nothing
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(50, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Desde"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FormInfOrdenCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(500, 278)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormInfOrdenCompra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormInfOrdenCompra"
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnReporte As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CtlComboClientesHasta As Principal.CtlCustomCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CtlComboClientesDesde As Principal.CtlCustomCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LabelTituloFiltro As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButtonSatisfechas As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonPendientes As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButtonArticulo As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonPedido As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonTodas As System.Windows.Forms.RadioButton
End Class
