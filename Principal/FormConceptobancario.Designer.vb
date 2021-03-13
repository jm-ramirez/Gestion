<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormConceptobancario
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxId = New System.Windows.Forms.TextBox()
        Me.TextBoxNombre = New System.Windows.Forms.TextBox()
        Me.TextBoxDescripcion = New System.Windows.Forms.TextBox()
        Me.CheckBoxActivo = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxCodigo = New System.Windows.Forms.TextBox()
        Me.GroupBoxTipo = New System.Windows.Forms.GroupBox()
        Me.RadioButtonAcreedor = New System.Windows.Forms.RadioButton()
        Me.RadioButtonDeudor = New System.Windows.Forms.RadioButton()
        Me.NumericUpDownPlazo = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToolStripMenu.SuspendLayout()
        Me.GroupBoxTipo.SuspendLayout()
        CType(Me.NumericUpDownPlazo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnGuardar, Me.BtnCancelar})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(488, 25)
        Me.ToolStripMenu.TabIndex = 0
        Me.ToolStripMenu.Text = "ToolStrip1"
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(80, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Id"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(52, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nombre"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(33, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Descripción"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxId
        '
        Me.TextBoxId.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxId.Location = New System.Drawing.Point(105, 42)
        Me.TextBoxId.Name = "TextBoxId"
        Me.TextBoxId.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxId.TabIndex = 0
        Me.TextBoxId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxNombre
        '
        Me.TextBoxNombre.Location = New System.Drawing.Point(105, 94)
        Me.TextBoxNombre.MaxLength = 45
        Me.TextBoxNombre.Name = "TextBoxNombre"
        Me.TextBoxNombre.Size = New System.Drawing.Size(371, 20)
        Me.TextBoxNombre.TabIndex = 2
        '
        'TextBoxDescripcion
        '
        Me.TextBoxDescripcion.Location = New System.Drawing.Point(105, 120)
        Me.TextBoxDescripcion.MaxLength = 255
        Me.TextBoxDescripcion.Multiline = True
        Me.TextBoxDescripcion.Name = "TextBoxDescripcion"
        Me.TextBoxDescripcion.Size = New System.Drawing.Size(371, 60)
        Me.TextBoxDescripcion.TabIndex = 3
        '
        'CheckBoxActivo
        '
        Me.CheckBoxActivo.AutoSize = True
        Me.CheckBoxActivo.Location = New System.Drawing.Point(211, 44)
        Me.CheckBoxActivo.Name = "CheckBoxActivo"
        Me.CheckBoxActivo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBoxActivo.Size = New System.Drawing.Size(56, 17)
        Me.CheckBoxActivo.TabIndex = 1
        Me.CheckBoxActivo.TabStop = False
        Me.CheckBoxActivo.Text = "Activo"
        Me.CheckBoxActivo.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(56, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Código"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxCodigo
        '
        Me.TextBoxCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCodigo.Location = New System.Drawing.Point(105, 68)
        Me.TextBoxCodigo.MaxLength = 3
        Me.TextBoxCodigo.Name = "TextBoxCodigo"
        Me.TextBoxCodigo.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxCodigo.TabIndex = 0
        Me.TextBoxCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBoxTipo
        '
        Me.GroupBoxTipo.Controls.Add(Me.RadioButtonAcreedor)
        Me.GroupBoxTipo.Controls.Add(Me.RadioButtonDeudor)
        Me.GroupBoxTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxTipo.Location = New System.Drawing.Point(105, 214)
        Me.GroupBoxTipo.Name = "GroupBoxTipo"
        Me.GroupBoxTipo.Size = New System.Drawing.Size(181, 45)
        Me.GroupBoxTipo.TabIndex = 5
        Me.GroupBoxTipo.TabStop = False
        Me.GroupBoxTipo.Text = "Tipo: "
        '
        'RadioButtonAcreedor
        '
        Me.RadioButtonAcreedor.AutoSize = True
        Me.RadioButtonAcreedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonAcreedor.Location = New System.Drawing.Point(88, 19)
        Me.RadioButtonAcreedor.Name = "RadioButtonAcreedor"
        Me.RadioButtonAcreedor.Size = New System.Drawing.Size(68, 17)
        Me.RadioButtonAcreedor.TabIndex = 0
        Me.RadioButtonAcreedor.TabStop = True
        Me.RadioButtonAcreedor.Text = "Acreedor"
        Me.RadioButtonAcreedor.UseVisualStyleBackColor = True
        '
        'RadioButtonDeudor
        '
        Me.RadioButtonDeudor.AutoSize = True
        Me.RadioButtonDeudor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonDeudor.Location = New System.Drawing.Point(22, 19)
        Me.RadioButtonDeudor.Name = "RadioButtonDeudor"
        Me.RadioButtonDeudor.Size = New System.Drawing.Size(60, 17)
        Me.RadioButtonDeudor.TabIndex = 0
        Me.RadioButtonDeudor.TabStop = True
        Me.RadioButtonDeudor.Text = "Deudor"
        Me.RadioButtonDeudor.UseVisualStyleBackColor = True
        '
        'NumericUpDownPlazo
        '
        Me.NumericUpDownPlazo.Location = New System.Drawing.Point(105, 188)
        Me.NumericUpDownPlazo.Name = "NumericUpDownPlazo"
        Me.NumericUpDownPlazo.Size = New System.Drawing.Size(100, 20)
        Me.NumericUpDownPlazo.TabIndex = 4
        Me.NumericUpDownPlazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 190)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Plazo (en días)"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FormConceptobancario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(488, 282)
        Me.Controls.Add(Me.NumericUpDownPlazo)
        Me.Controls.Add(Me.GroupBoxTipo)
        Me.Controls.Add(Me.CheckBoxActivo)
        Me.Controls.Add(Me.TextBoxDescripcion)
        Me.Controls.Add(Me.TextBoxNombre)
        Me.Controls.Add(Me.TextBoxCodigo)
        Me.Controls.Add(Me.TextBoxId)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormConceptobancario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FormArticulo"
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.GroupBoxTipo.ResumeLayout(False)
        Me.GroupBoxTipo.PerformLayout()
        CType(Me.NumericUpDownPlazo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxId As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNombre As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents CheckBoxActivo As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxCodigo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBoxTipo As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButtonAcreedor As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonDeudor As System.Windows.Forms.RadioButton
    Friend WithEvents NumericUpDownPlazo As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
