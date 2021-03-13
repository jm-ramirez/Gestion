<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCfgEmpresa
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
        Me.GroupBoxEmpresa = New System.Windows.Forms.GroupBox()
        Me.CheckBoxIVA = New System.Windows.Forms.CheckBox()
        Me.DateTimePickerInicio = New System.Windows.Forms.DateTimePicker()
        Me.TextBoxWeb = New System.Windows.Forms.TextBox()
        Me.TextBoxEmail = New System.Windows.Forms.TextBox()
        Me.TextBoxIIBB = New System.Windows.Forms.TextBox()
        Me.TextBoxCUIT = New System.Windows.Forms.TextBox()
        Me.TextBoxCondicionIVA = New System.Windows.Forms.TextBox()
        Me.TextBoxDomicilio = New System.Windows.Forms.TextBox()
        Me.TextBoxNombreFantasia = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBoxRazonSocial = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBoxTelefono = New System.Windows.Forms.TextBox()
        Me.ToolStripMenu.SuspendLayout()
        Me.GroupBoxEmpresa.SuspendLayout()
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
        Me.BtnGuardar.Size = New System.Drawing.Size(66, 22)
        Me.BtnGuardar.Text = "Guardar [F12]"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = Global.Principal.My.Resources.Resources.cancel
        Me.BtnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(69, 22)
        Me.BtnCancelar.Text = "Cancelar [Esc]"
        '
        'GroupBoxEmpresa
        '
        Me.GroupBoxEmpresa.Controls.Add(Me.CheckBoxIVA)
        Me.GroupBoxEmpresa.Controls.Add(Me.DateTimePickerInicio)
        Me.GroupBoxEmpresa.Controls.Add(Me.TextBoxTelefono)
        Me.GroupBoxEmpresa.Controls.Add(Me.TextBoxWeb)
        Me.GroupBoxEmpresa.Controls.Add(Me.TextBoxEmail)
        Me.GroupBoxEmpresa.Controls.Add(Me.TextBoxIIBB)
        Me.GroupBoxEmpresa.Controls.Add(Me.TextBoxCUIT)
        Me.GroupBoxEmpresa.Controls.Add(Me.TextBoxCondicionIVA)
        Me.GroupBoxEmpresa.Controls.Add(Me.TextBoxDomicilio)
        Me.GroupBoxEmpresa.Controls.Add(Me.Label10)
        Me.GroupBoxEmpresa.Controls.Add(Me.TextBoxNombreFantasia)
        Me.GroupBoxEmpresa.Controls.Add(Me.Label9)
        Me.GroupBoxEmpresa.Controls.Add(Me.TextBoxRazonSocial)
        Me.GroupBoxEmpresa.Controls.Add(Me.Label8)
        Me.GroupBoxEmpresa.Controls.Add(Me.Label7)
        Me.GroupBoxEmpresa.Controls.Add(Me.Label6)
        Me.GroupBoxEmpresa.Controls.Add(Me.Label5)
        Me.GroupBoxEmpresa.Controls.Add(Me.Label4)
        Me.GroupBoxEmpresa.Controls.Add(Me.Label2)
        Me.GroupBoxEmpresa.Controls.Add(Me.Label1)
        Me.GroupBoxEmpresa.Controls.Add(Me.Label3)
        Me.GroupBoxEmpresa.Location = New System.Drawing.Point(12, 28)
        Me.GroupBoxEmpresa.Name = "GroupBoxEmpresa"
        Me.GroupBoxEmpresa.Size = New System.Drawing.Size(464, 304)
        Me.GroupBoxEmpresa.TabIndex = 0
        Me.GroupBoxEmpresa.TabStop = False
        Me.GroupBoxEmpresa.Text = "Datos de la Empresa"
        '
        'CheckBoxIVA
        '
        Me.CheckBoxIVA.AutoSize = True
        Me.CheckBoxIVA.Location = New System.Drawing.Point(348, 126)
        Me.CheckBoxIVA.Name = "CheckBoxIVA"
        Me.CheckBoxIVA.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBoxIVA.Size = New System.Drawing.Size(110, 17)
        Me.CheckBoxIVA.TabIndex = 9
        Me.CheckBoxIVA.Text = "Inscripto en I.V.A."
        Me.CheckBoxIVA.UseVisualStyleBackColor = True
        '
        'DateTimePickerInicio
        '
        Me.DateTimePickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerInicio.Location = New System.Drawing.Point(163, 178)
        Me.DateTimePickerInicio.Name = "DateTimePickerInicio"
        Me.DateTimePickerInicio.Size = New System.Drawing.Size(102, 20)
        Me.DateTimePickerInicio.TabIndex = 6
        '
        'TextBoxWeb
        '
        Me.TextBoxWeb.Location = New System.Drawing.Point(110, 230)
        Me.TextBoxWeb.Name = "TextBoxWeb"
        Me.TextBoxWeb.Size = New System.Drawing.Size(348, 20)
        Me.TextBoxWeb.TabIndex = 8
        '
        'TextBoxEmail
        '
        Me.TextBoxEmail.Location = New System.Drawing.Point(113, 204)
        Me.TextBoxEmail.Name = "TextBoxEmail"
        Me.TextBoxEmail.Size = New System.Drawing.Size(345, 20)
        Me.TextBoxEmail.TabIndex = 7
        '
        'TextBoxIIBB
        '
        Me.TextBoxIIBB.Location = New System.Drawing.Point(147, 152)
        Me.TextBoxIIBB.Name = "TextBoxIIBB"
        Me.TextBoxIIBB.Size = New System.Drawing.Size(118, 20)
        Me.TextBoxIIBB.TabIndex = 5
        '
        'TextBoxCUIT
        '
        Me.TextBoxCUIT.Location = New System.Drawing.Point(111, 126)
        Me.TextBoxCUIT.Name = "TextBoxCUIT"
        Me.TextBoxCUIT.Size = New System.Drawing.Size(154, 20)
        Me.TextBoxCUIT.TabIndex = 4
        '
        'TextBoxCondicionIVA
        '
        Me.TextBoxCondicionIVA.Location = New System.Drawing.Point(136, 100)
        Me.TextBoxCondicionIVA.Name = "TextBoxCondicionIVA"
        Me.TextBoxCondicionIVA.Size = New System.Drawing.Size(322, 20)
        Me.TextBoxCondicionIVA.TabIndex = 3
        '
        'TextBoxDomicilio
        '
        Me.TextBoxDomicilio.Location = New System.Drawing.Point(113, 74)
        Me.TextBoxDomicilio.Name = "TextBoxDomicilio"
        Me.TextBoxDomicilio.Size = New System.Drawing.Size(345, 20)
        Me.TextBoxDomicilio.TabIndex = 2
        '
        'TextBoxNombreFantasia
        '
        Me.TextBoxNombreFantasia.Location = New System.Drawing.Point(113, 48)
        Me.TextBoxNombreFantasia.Name = "TextBoxNombreFantasia"
        Me.TextBoxNombreFantasia.Size = New System.Drawing.Size(345, 20)
        Me.TextBoxNombreFantasia.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 233)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Sitio Web HTTP://"
        '
        'TextBoxRazonSocial
        '
        Me.TextBoxRazonSocial.Location = New System.Drawing.Point(82, 22)
        Me.TextBoxRazonSocial.Name = "TextBoxRazonSocial"
        Me.TextBoxRazonSocial.Size = New System.Drawing.Size(376, 20)
        Me.TextBoxRazonSocial.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 207)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 13)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Dirección de Email"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 182)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(151, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Fecha de inicio de actividades"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 155)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(135, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Número de Ingresos Brutos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 129)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Número de C.U.I.T."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Condición frente al I.V.A."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Domicilio comercial"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Nombre de fantasía"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Razón Social"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 259)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Teléfono/s"
        '
        'TextBoxTelefono
        '
        Me.TextBoxTelefono.Location = New System.Drawing.Point(72, 256)
        Me.TextBoxTelefono.Name = "TextBoxTelefono"
        Me.TextBoxTelefono.Size = New System.Drawing.Size(193, 20)
        Me.TextBoxTelefono.TabIndex = 8
        '
        'FormCfgEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(488, 344)
        Me.Controls.Add(Me.GroupBoxEmpresa)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormCfgEmpresa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Datos de la Empresa"
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.GroupBoxEmpresa.ResumeLayout(False)
        Me.GroupBoxEmpresa.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBoxEmpresa As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextBoxIIBB As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCUIT As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCondicionIVA As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNombreFantasia As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxWeb As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxIVA As System.Windows.Forms.CheckBox
    Friend WithEvents TextBoxTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
