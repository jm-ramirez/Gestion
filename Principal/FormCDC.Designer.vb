<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCDC
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
        Me.BtnConstatar = New System.Windows.Forms.ToolStripButton()
        Me.BtnSalir = New System.Windows.Forms.ToolStripButton()
        Me.GroupBoxCDC = New System.Windows.Forms.GroupBox()
        Me.BtnCodigo = New System.Windows.Forms.Button()
        Me.TextBoxCodigobarra = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBoxRespuesta = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxPtoVta = New System.Windows.Forms.TextBox()
        Me.TextBoxCodAutorizacion = New System.Windows.Forms.TextBox()
        Me.TextBoxImpTotal = New System.Windows.Forms.TextBox()
        Me.TextBoxNumero = New System.Windows.Forms.TextBox()
        Me.TextBoxDocReceptor = New System.Windows.Forms.TextBox()
        Me.TextBoxCuitEmisor = New System.Windows.Forms.TextBox()
        Me.DateTimePickerFecha = New System.Windows.Forms.DateTimePicker()
        Me.ComboBoxTipoDoc = New System.Windows.Forms.ComboBox()
        Me.ComboBoxTipo = New System.Windows.Forms.ComboBox()
        Me.ComboBoxModo = New System.Windows.Forms.ComboBox()
        Me.ToolStripMenu.SuspendLayout()
        Me.GroupBoxCDC.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnConstatar, Me.BtnSalir})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(466, 25)
        Me.ToolStripMenu.TabIndex = 0
        Me.ToolStripMenu.Text = "ToolStrip1"
        '
        'BtnConstatar
        '
        Me.BtnConstatar.Image = Global.Principal.My.Resources.Resources.server_go
        Me.BtnConstatar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnConstatar.Name = "BtnConstatar"
        Me.BtnConstatar.Size = New System.Drawing.Size(75, 22)
        Me.BtnConstatar.Text = "Constatar"
        '
        'BtnSalir
        '
        Me.BtnSalir.Image = Global.Principal.My.Resources.Resources.door_out
        Me.BtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(47, 22)
        Me.BtnSalir.Text = "Salir"
        '
        'GroupBoxCDC
        '
        Me.GroupBoxCDC.Controls.Add(Me.BtnCodigo)
        Me.GroupBoxCDC.Controls.Add(Me.TextBoxCodigobarra)
        Me.GroupBoxCDC.Controls.Add(Me.Label9)
        Me.GroupBoxCDC.Controls.Add(Me.TextBoxRespuesta)
        Me.GroupBoxCDC.Controls.Add(Me.Label10)
        Me.GroupBoxCDC.Controls.Add(Me.Label2)
        Me.GroupBoxCDC.Controls.Add(Me.Label4)
        Me.GroupBoxCDC.Controls.Add(Me.Label6)
        Me.GroupBoxCDC.Controls.Add(Me.Label8)
        Me.GroupBoxCDC.Controls.Add(Me.Label7)
        Me.GroupBoxCDC.Controls.Add(Me.Label5)
        Me.GroupBoxCDC.Controls.Add(Me.Label11)
        Me.GroupBoxCDC.Controls.Add(Me.Label3)
        Me.GroupBoxCDC.Controls.Add(Me.Label1)
        Me.GroupBoxCDC.Controls.Add(Me.TextBoxPtoVta)
        Me.GroupBoxCDC.Controls.Add(Me.TextBoxCodAutorizacion)
        Me.GroupBoxCDC.Controls.Add(Me.TextBoxImpTotal)
        Me.GroupBoxCDC.Controls.Add(Me.TextBoxNumero)
        Me.GroupBoxCDC.Controls.Add(Me.TextBoxDocReceptor)
        Me.GroupBoxCDC.Controls.Add(Me.TextBoxCuitEmisor)
        Me.GroupBoxCDC.Controls.Add(Me.DateTimePickerFecha)
        Me.GroupBoxCDC.Controls.Add(Me.ComboBoxTipoDoc)
        Me.GroupBoxCDC.Controls.Add(Me.ComboBoxTipo)
        Me.GroupBoxCDC.Controls.Add(Me.ComboBoxModo)
        Me.GroupBoxCDC.Location = New System.Drawing.Point(12, 28)
        Me.GroupBoxCDC.Name = "GroupBoxCDC"
        Me.GroupBoxCDC.Size = New System.Drawing.Size(442, 403)
        Me.GroupBoxCDC.TabIndex = 1
        Me.GroupBoxCDC.TabStop = False
        Me.GroupBoxCDC.Text = "Constatación manual de comprobantes electrónicos"
        '
        'BtnCodigo
        '
        Me.BtnCodigo.FlatAppearance.BorderSize = 0
        Me.BtnCodigo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCodigo.Image = Global.Principal.My.Resources.Resources.BarCodeHS
        Me.BtnCodigo.Location = New System.Drawing.Point(23, 24)
        Me.BtnCodigo.Name = "BtnCodigo"
        Me.BtnCodigo.Size = New System.Drawing.Size(44, 20)
        Me.BtnCodigo.TabIndex = 10
        Me.BtnCodigo.UseVisualStyleBackColor = True
        '
        'TextBoxCodigobarra
        '
        Me.TextBoxCodigobarra.Location = New System.Drawing.Point(74, 24)
        Me.TextBoxCodigobarra.Name = "TextBoxCodigobarra"
        Me.TextBoxCodigobarra.Size = New System.Drawing.Size(362, 20)
        Me.TextBoxCodigobarra.TabIndex = 0
        Me.TextBoxCodigobarra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 207)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(118, 13)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Respuesta del servidor:"
        '
        'TextBoxRespuesta
        '
        Me.TextBoxRespuesta.Location = New System.Drawing.Point(6, 223)
        Me.TextBoxRespuesta.Multiline = True
        Me.TextBoxRespuesta.Name = "TextBoxRespuesta"
        Me.TextBoxRespuesta.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxRespuesta.Size = New System.Drawing.Size(430, 174)
        Me.TextBoxRespuesta.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(179, 159)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(92, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Nº Doc. Receptor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(242, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "C.U.I.T. del Emisior"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(274, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Fecha Cbte."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(140, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Número"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(166, 133)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 13)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Cód. de Autorización"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 133)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Imp. Total"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Pto. Vta."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(14, 159)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 13)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Tipo Doc."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Tipo Cbte."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Modo Cbte."
        '
        'TextBoxPtoVta
        '
        Me.TextBoxPtoVta.Location = New System.Drawing.Point(74, 104)
        Me.TextBoxPtoVta.MaxLength = 4
        Me.TextBoxPtoVta.Name = "TextBoxPtoVta"
        Me.TextBoxPtoVta.Size = New System.Drawing.Size(60, 20)
        Me.TextBoxPtoVta.TabIndex = 5
        Me.TextBoxPtoVta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxCodAutorizacion
        '
        Me.TextBoxCodAutorizacion.Location = New System.Drawing.Point(277, 130)
        Me.TextBoxCodAutorizacion.MaxLength = 14
        Me.TextBoxCodAutorizacion.Name = "TextBoxCodAutorizacion"
        Me.TextBoxCodAutorizacion.Size = New System.Drawing.Size(159, 20)
        Me.TextBoxCodAutorizacion.TabIndex = 8
        Me.TextBoxCodAutorizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxImpTotal
        '
        Me.TextBoxImpTotal.Location = New System.Drawing.Point(74, 130)
        Me.TextBoxImpTotal.Name = "TextBoxImpTotal"
        Me.TextBoxImpTotal.Size = New System.Drawing.Size(83, 20)
        Me.TextBoxImpTotal.TabIndex = 7
        Me.TextBoxImpTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxNumero
        '
        Me.TextBoxNumero.Location = New System.Drawing.Point(190, 104)
        Me.TextBoxNumero.MaxLength = 8
        Me.TextBoxNumero.Name = "TextBoxNumero"
        Me.TextBoxNumero.Size = New System.Drawing.Size(133, 20)
        Me.TextBoxNumero.TabIndex = 6
        Me.TextBoxNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxDocReceptor
        '
        Me.TextBoxDocReceptor.Location = New System.Drawing.Point(277, 156)
        Me.TextBoxDocReceptor.MaxLength = 20
        Me.TextBoxDocReceptor.Name = "TextBoxDocReceptor"
        Me.TextBoxDocReceptor.Size = New System.Drawing.Size(159, 20)
        Me.TextBoxDocReceptor.TabIndex = 10
        Me.TextBoxDocReceptor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxCuitEmisor
        '
        Me.TextBoxCuitEmisor.Location = New System.Drawing.Point(345, 50)
        Me.TextBoxCuitEmisor.MaxLength = 11
        Me.TextBoxCuitEmisor.Name = "TextBoxCuitEmisor"
        Me.TextBoxCuitEmisor.Size = New System.Drawing.Size(91, 20)
        Me.TextBoxCuitEmisor.TabIndex = 2
        Me.TextBoxCuitEmisor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DateTimePickerFecha
        '
        Me.DateTimePickerFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerFecha.Location = New System.Drawing.Point(345, 76)
        Me.DateTimePickerFecha.Name = "DateTimePickerFecha"
        Me.DateTimePickerFecha.Size = New System.Drawing.Size(91, 20)
        Me.DateTimePickerFecha.TabIndex = 4
        '
        'ComboBoxTipoDoc
        '
        Me.ComboBoxTipoDoc.FormattingEnabled = True
        Me.ComboBoxTipoDoc.Items.AddRange(New Object() {"CAE", "CAEA", "CAI"})
        Me.ComboBoxTipoDoc.Location = New System.Drawing.Point(74, 156)
        Me.ComboBoxTipoDoc.Name = "ComboBoxTipoDoc"
        Me.ComboBoxTipoDoc.Size = New System.Drawing.Size(99, 21)
        Me.ComboBoxTipoDoc.TabIndex = 9
        '
        'ComboBoxTipo
        '
        Me.ComboBoxTipo.FormattingEnabled = True
        Me.ComboBoxTipo.Items.AddRange(New Object() {"CAE", "CAEA", "CAI"})
        Me.ComboBoxTipo.Location = New System.Drawing.Point(74, 77)
        Me.ComboBoxTipo.Name = "ComboBoxTipo"
        Me.ComboBoxTipo.Size = New System.Drawing.Size(186, 21)
        Me.ComboBoxTipo.TabIndex = 3
        '
        'ComboBoxModo
        '
        Me.ComboBoxModo.FormattingEnabled = True
        Me.ComboBoxModo.Items.AddRange(New Object() {"CAE", "CAEA", "CAI"})
        Me.ComboBoxModo.Location = New System.Drawing.Point(74, 50)
        Me.ComboBoxModo.Name = "ComboBoxModo"
        Me.ComboBoxModo.Size = New System.Drawing.Size(83, 21)
        Me.ComboBoxModo.TabIndex = 1
        '
        'FormCDC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(466, 443)
        Me.Controls.Add(Me.GroupBoxCDC)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormCDC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "."
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.GroupBoxCDC.ResumeLayout(False)
        Me.GroupBoxCDC.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnConstatar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBoxCDC As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxPtoVta As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCodAutorizacion As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxImpTotal As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNumero As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCuitEmisor As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePickerFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents ComboBoxTipo As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxModo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBoxRespuesta As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBoxDocReceptor As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxTipoDoc As System.Windows.Forms.ComboBox
    Friend WithEvents BtnCodigo As System.Windows.Forms.Button
    Friend WithEvents TextBoxCodigobarra As System.Windows.Forms.TextBox
End Class
