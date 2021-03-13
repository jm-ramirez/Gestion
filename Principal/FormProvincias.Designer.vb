<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProvincias
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
        Me.TextBoxNombre = New System.Windows.Forms.TextBox()
        Me.TextBoxCod = New System.Windows.Forms.TextBox()
        Me.BtnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.BtnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.TextBoxId = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStripMenu = New System.Windows.Forms.ToolStrip()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboPais = New Principal.CtlCustomCombo()
        Me.ToolStripMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBoxNombre
        '
        Me.TextBoxNombre.Location = New System.Drawing.Point(62, 61)
        Me.TextBoxNombre.MaxLength = 40
        Me.TextBoxNombre.Name = "TextBoxNombre"
        Me.TextBoxNombre.Size = New System.Drawing.Size(371, 20)
        Me.TextBoxNombre.TabIndex = 1
        '
        'TextBoxCod
        '
        Me.TextBoxCod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCod.Location = New System.Drawing.Point(62, 35)
        Me.TextBoxCod.MaxLength = 2
        Me.TextBoxCod.Name = "TextBoxCod"
        Me.TextBoxCod.Size = New System.Drawing.Size(59, 20)
        Me.TextBoxCod.TabIndex = 0
        Me.TextBoxCod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Image = Global.Principal.My.Resources.Resources.disk
        Me.BtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(95, 22)
        Me.BtnGuardar.Text = "Guardar [F12]"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = Global.Principal.My.Resources.Resources.cancel
        Me.BtnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(96, 22)
        Me.BtnCancelar.Text = "Cancelar [Esc]"
        '
        'TextBoxId
        '
        Me.TextBoxId.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxId.Location = New System.Drawing.Point(178, 24)
        Me.TextBoxId.Name = "TextBoxId"
        Me.TextBoxId.Size = New System.Drawing.Size(59, 20)
        Me.TextBoxId.TabIndex = 31
        Me.TextBoxId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBoxId.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Detalle :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Código :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnGuardar, Me.BtnCancelar})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(518, 25)
        Me.ToolStripMenu.TabIndex = 28
        Me.ToolStripMenu.Text = "ToolStrip1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "País :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboPais
        '
        Me.cboPais.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.cboPais.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.cboPais.BusquedaPorCodigobarra = False
        Me.cboPais.ColumnasExtras = Nothing
        Me.cboPais.CustomFormatArt = False
        Me.cboPais.DataSource = Nothing
        Me.cboPais.DisplayMember = Nothing
        Me.cboPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboPais.FormularioDeAlta = Nothing
        Me.cboPais.FormularioDeBusqueda = Nothing
        Me.cboPais.Location = New System.Drawing.Point(62, 87)
        Me.cboPais.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cboPais.MaximumSize = New System.Drawing.Size(667, 29)
        Me.cboPais.MinimumSize = New System.Drawing.Size(267, 29)
        Me.cboPais.Name = "cboPais"
        Me.cboPais.SelectedIndex = -1
        Me.cboPais.SelectedItem = Nothing
        Me.cboPais.SelectedText = ""
        Me.cboPais.SelectedValue = Nothing
        Me.cboPais.Size = New System.Drawing.Size(371, 29)
        Me.cboPais.TabIndex = 2
        Me.cboPais.ValueMember = Nothing
        '
        'FormProvincias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(518, 133)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboPais)
        Me.Controls.Add(Me.TextBoxNombre)
        Me.Controls.Add(Me.TextBoxCod)
        Me.Controls.Add(Me.TextBoxId)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.KeyPreview = True
        Me.Name = "FormProvincias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormProvincias"
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBoxNombre As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCod As System.Windows.Forms.TextBox
    Friend WithEvents BtnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents TextBoxId As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboPais As Principal.CtlCustomCombo
End Class
