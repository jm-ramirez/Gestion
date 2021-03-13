<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLocalidad
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
        Me.cboProvincia = New Principal.CtlCustomCombo()
        Me.TextBoxNombre = New System.Windows.Forms.TextBox()
        Me.TextBoxCod = New System.Windows.Forms.TextBox()
        Me.BtnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.BtnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.TextBoxId = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStripMenu = New System.Windows.Forms.ToolStrip()
        Me.ToolStripMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboProvincia
        '
        Me.cboProvincia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.cboProvincia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.cboProvincia.BusquedaPorCodigobarra = False
        Me.cboProvincia.ColumnasExtras = Nothing
        Me.cboProvincia.DataSource = Nothing
        Me.cboProvincia.DisplayMember = Nothing
        Me.cboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboProvincia.FormularioDeAlta = Nothing
        Me.cboProvincia.FormularioDeBusqueda = Nothing
        Me.cboProvincia.Location = New System.Drawing.Point(78, 100)
        Me.cboProvincia.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cboProvincia.MaximumSize = New System.Drawing.Size(667, 29)
        Me.cboProvincia.MinimumSize = New System.Drawing.Size(267, 29)
        Me.cboProvincia.Name = "cboProvincia"
        Me.cboProvincia.SelectedIndex = -1
        Me.cboProvincia.SelectedItem = Nothing
        Me.cboProvincia.SelectedText = ""
        Me.cboProvincia.SelectedValue = Nothing
        Me.cboProvincia.Size = New System.Drawing.Size(371, 29)
        Me.cboProvincia.TabIndex = 2
        Me.cboProvincia.ValueMember = Nothing
        '
        'TextBoxNombre
        '
        Me.TextBoxNombre.Location = New System.Drawing.Point(78, 74)
        Me.TextBoxNombre.MaxLength = 80
        Me.TextBoxNombre.Name = "TextBoxNombre"
        Me.TextBoxNombre.Size = New System.Drawing.Size(371, 20)
        Me.TextBoxNombre.TabIndex = 1
        '
        'TextBoxCod
        '
        Me.TextBoxCod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCod.Location = New System.Drawing.Point(78, 48)
        Me.TextBoxCod.MaxLength = 8
        Me.TextBoxCod.Name = "TextBoxCod"
        Me.TextBoxCod.Size = New System.Drawing.Size(102, 20)
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
        Me.TextBoxId.Location = New System.Drawing.Point(236, 23)
        Me.TextBoxId.Name = "TextBoxId"
        Me.TextBoxId.Size = New System.Drawing.Size(60, 20)
        Me.TextBoxId.TabIndex = 43
        Me.TextBoxId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBoxId.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Provincia :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Detalle :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Código :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnGuardar, Me.BtnCancelar})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(498, 25)
        Me.ToolStripMenu.TabIndex = 39
        Me.ToolStripMenu.Text = "ToolStrip1"
        '
        'FormLocalidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(498, 143)
        Me.Controls.Add(Me.cboProvincia)
        Me.Controls.Add(Me.TextBoxNombre)
        Me.Controls.Add(Me.TextBoxCod)
        Me.Controls.Add(Me.TextBoxId)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.KeyPreview = True
        Me.Name = "FormLocalidad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormLocalidad"
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboProvincia As Principal.CtlCustomCombo
   Friend WithEvents TextBoxNombre As System.Windows.Forms.TextBox
   Friend WithEvents TextBoxCod As System.Windows.Forms.TextBox
   Friend WithEvents BtnGuardar As System.Windows.Forms.ToolStripButton
   Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
   Friend WithEvents TextBoxId As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
End Class
