<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMovimiento
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxImporte = New System.Windows.Forms.TextBox()
        Me.TextBoxObservacion = New System.Windows.Forms.TextBox()
        Me.ComboBoxCta = New Principal.CtlCustomCombo()
        Me.ComboBoxCpto = New Principal.CtlCustomCombo()
        Me.DtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToolStripMenu.SuspendLayout()
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(57, 133)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Importe"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(33, 159)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Observación"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxImporte
        '
        Me.TextBoxImporte.Location = New System.Drawing.Point(105, 130)
        Me.TextBoxImporte.Name = "TextBoxImporte"
        Me.TextBoxImporte.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxImporte.TabIndex = 3
        Me.TextBoxImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBoxObservacion
        '
        Me.TextBoxObservacion.Location = New System.Drawing.Point(105, 156)
        Me.TextBoxObservacion.MaxLength = 255
        Me.TextBoxObservacion.Multiline = True
        Me.TextBoxObservacion.Name = "TextBoxObservacion"
        Me.TextBoxObservacion.Size = New System.Drawing.Size(371, 60)
        Me.TextBoxObservacion.TabIndex = 4
        '
        'ComboBoxCta
        '
        Me.ComboBoxCta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.ComboBoxCta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.ComboBoxCta.BusquedaPorCodigobarra = False
        Me.ComboBoxCta.ColumnasExtras = Nothing
        Me.ComboBoxCta.CustomFormatArt = False
        Me.ComboBoxCta.DataSource = Nothing
        Me.ComboBoxCta.DisplayMember = Nothing
        Me.ComboBoxCta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ComboBoxCta.FormularioDeAlta = Nothing
        Me.ComboBoxCta.FormularioDeBusqueda = Nothing
        Me.ComboBoxCta.Location = New System.Drawing.Point(105, 68)
        Me.ComboBoxCta.MaximumSize = New System.Drawing.Size(500, 25)
        Me.ComboBoxCta.MinimumSize = New System.Drawing.Size(200, 25)
        Me.ComboBoxCta.Name = "ComboBoxCta"
        Me.ComboBoxCta.SelectedIndex = -1
        Me.ComboBoxCta.SelectedItem = Nothing
        Me.ComboBoxCta.SelectedText = ""
        Me.ComboBoxCta.SelectedValue = Nothing
        Me.ComboBoxCta.Size = New System.Drawing.Size(300, 25)
        Me.ComboBoxCta.TabIndex = 1
        Me.ComboBoxCta.ValueMember = Nothing
        '
        'ComboBoxCpto
        '
        Me.ComboBoxCpto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.ComboBoxCpto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.ComboBoxCpto.BusquedaPorCodigobarra = False
        Me.ComboBoxCpto.ColumnasExtras = Nothing
        Me.ComboBoxCpto.CustomFormatArt = False
        Me.ComboBoxCpto.DataSource = Nothing
        Me.ComboBoxCpto.DisplayMember = Nothing
        Me.ComboBoxCpto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ComboBoxCpto.FormularioDeAlta = Nothing
        Me.ComboBoxCpto.FormularioDeBusqueda = Nothing
        Me.ComboBoxCpto.Location = New System.Drawing.Point(105, 99)
        Me.ComboBoxCpto.MaximumSize = New System.Drawing.Size(500, 25)
        Me.ComboBoxCpto.MinimumSize = New System.Drawing.Size(200, 25)
        Me.ComboBoxCpto.Name = "ComboBoxCpto"
        Me.ComboBoxCpto.SelectedIndex = -1
        Me.ComboBoxCpto.SelectedItem = Nothing
        Me.ComboBoxCpto.SelectedText = ""
        Me.ComboBoxCpto.SelectedValue = Nothing
        Me.ComboBoxCpto.Size = New System.Drawing.Size(300, 25)
        Me.ComboBoxCpto.TabIndex = 2
        Me.ComboBoxCpto.ValueMember = Nothing
        '
        'DtpFecha
        '
        Me.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFecha.Location = New System.Drawing.Point(105, 42)
        Me.DtpFecha.Name = "DtpFecha"
        Me.DtpFecha.Size = New System.Drawing.Size(100, 20)
        Me.DtpFecha.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(47, 105)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Concepto"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(59, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Cuenta"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(63, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Fecha"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FormMovimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(488, 243)
        Me.Controls.Add(Me.DtpFecha)
        Me.Controls.Add(Me.ComboBoxCpto)
        Me.Controls.Add(Me.ComboBoxCta)
        Me.Controls.Add(Me.TextBoxObservacion)
        Me.Controls.Add(Me.TextBoxImporte)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormMovimiento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormArticulo"
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxImporte As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxObservacion As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxCta As Principal.CtlCustomCombo
    Friend WithEvents ComboBoxCpto As Principal.CtlCustomCombo
    Friend WithEvents DtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
