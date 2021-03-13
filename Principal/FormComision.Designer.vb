<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormComision
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
        Me.BtnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxId = New System.Windows.Forms.TextBox()
        Me.TextBoxNombre = New System.Windows.Forms.TextBox()
        Me.TextBoxComRev = New System.Windows.Forms.TextBox()
        Me.TextBoxComKiosko = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BtnKiosko = New System.Windows.Forms.Button()
        Me.BtnRevendedor = New System.Windows.Forms.Button()
        Me.BtnComisionDetalle = New System.Windows.Forms.Button()
        Me.ToolStripMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnCancelar})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(488, 25)
        Me.ToolStripMenu.TabIndex = 0
        Me.ToolStripMenu.Text = "ToolStrip1"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = Global.Principal.My.Resources.Resources.door_out
        Me.BtnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(77, 22)
        Me.BtnCancelar.Text = "Salir [Esc]"
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
        Me.Label2.Location = New System.Drawing.Point(52, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nombre"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.TextBoxNombre.Location = New System.Drawing.Point(105, 68)
        Me.TextBoxNombre.Name = "TextBoxNombre"
        Me.TextBoxNombre.Size = New System.Drawing.Size(371, 20)
        Me.TextBoxNombre.TabIndex = 2
        '
        'TextBoxComRev
        '
        Me.TextBoxComRev.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxComRev.Location = New System.Drawing.Point(105, 95)
        Me.TextBoxComRev.Name = "TextBoxComRev"
        Me.TextBoxComRev.Size = New System.Drawing.Size(67, 20)
        Me.TextBoxComRev.TabIndex = 0
        Me.TextBoxComRev.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxComKiosko
        '
        Me.TextBoxComKiosko.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxComKiosko.Location = New System.Drawing.Point(105, 124)
        Me.TextBoxComKiosko.Name = "TextBoxComKiosko"
        Me.TextBoxComKiosko.Size = New System.Drawing.Size(67, 20)
        Me.TextBoxComKiosko.TabIndex = 0
        Me.TextBoxComKiosko.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Comisión L1"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Comisión L2"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(178, 98)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "%"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(178, 127)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(15, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "%"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnKiosko
        '
        Me.BtnKiosko.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.BtnKiosko.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnKiosko.Image = Global.Principal.My.Resources.Resources.disk
        Me.BtnKiosko.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnKiosko.Location = New System.Drawing.Point(199, 121)
        Me.BtnKiosko.Name = "BtnKiosko"
        Me.BtnKiosko.Size = New System.Drawing.Size(200, 23)
        Me.BtnKiosko.TabIndex = 3
        Me.BtnKiosko.Text = "Actualizar Comisión L2"
        Me.BtnKiosko.UseVisualStyleBackColor = True
        '
        'BtnRevendedor
        '
        Me.BtnRevendedor.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.BtnRevendedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRevendedor.Image = Global.Principal.My.Resources.Resources.disk
        Me.BtnRevendedor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnRevendedor.Location = New System.Drawing.Point(199, 92)
        Me.BtnRevendedor.Name = "BtnRevendedor"
        Me.BtnRevendedor.Size = New System.Drawing.Size(200, 23)
        Me.BtnRevendedor.TabIndex = 3
        Me.BtnRevendedor.Text = "Actualizar Comisión L1"
        Me.BtnRevendedor.UseVisualStyleBackColor = True
        '
        'BtnComisionDetalle
        '
        Me.BtnComisionDetalle.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.BtnComisionDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnComisionDetalle.Image = Global.Principal.My.Resources.Resources.door_in
        Me.BtnComisionDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnComisionDetalle.Location = New System.Drawing.Point(199, 150)
        Me.BtnComisionDetalle.Name = "BtnComisionDetalle"
        Me.BtnComisionDetalle.Size = New System.Drawing.Size(200, 23)
        Me.BtnComisionDetalle.TabIndex = 3
        Me.BtnComisionDetalle.Text = "Actualizar Comisión por Artículo"
        Me.BtnComisionDetalle.UseVisualStyleBackColor = True
        '
        'FormComision
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(488, 207)
        Me.Controls.Add(Me.BtnKiosko)
        Me.Controls.Add(Me.BtnRevendedor)
        Me.Controls.Add(Me.BtnComisionDetalle)
        Me.Controls.Add(Me.TextBoxNombre)
        Me.Controls.Add(Me.TextBoxComKiosko)
        Me.Controls.Add(Me.TextBoxComRev)
        Me.Controls.Add(Me.TextBoxId)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormComision"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FormArticulo"
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxId As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNombre As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxComRev As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxComKiosko As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BtnComisionDetalle As System.Windows.Forms.Button
    Friend WithEvents BtnRevendedor As System.Windows.Forms.Button
    Friend WithEvents BtnKiosko As System.Windows.Forms.Button
End Class
