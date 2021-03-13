<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFpDialog
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.TextBoxReferencia = New System.Windows.Forms.TextBox()
        Me.LabelInput = New System.Windows.Forms.Label()
        Me.LabelImporte = New System.Windows.Forms.Label()
        Me.RadioButtonEfectivo = New System.Windows.Forms.RadioButton()
        Me.RadioButtonTarjeta = New System.Windows.Forms.RadioButton()
        Me.ComboBoxTarjetas = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LabelCbte = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LabelVuelto = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBoxVuelto = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(164, 315)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(246, 29)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'OK_Button
        '
        Me.OK_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OK_Button.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.OK_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OK_Button.ForeColor = System.Drawing.Color.Gainsboro
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(117, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Aceptar"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Cancel_Button.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.Cancel_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cancel_Button.ForeColor = System.Drawing.Color.Gainsboro
        Me.Cancel_Button.Location = New System.Drawing.Point(126, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(117, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancelar"
        '
        'TextBoxReferencia
        '
        Me.TextBoxReferencia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxReferencia.Location = New System.Drawing.Point(278, 287)
        Me.TextBoxReferencia.Name = "TextBoxReferencia"
        Me.TextBoxReferencia.Size = New System.Drawing.Size(130, 20)
        Me.TextBoxReferencia.TabIndex = 3
        Me.TextBoxReferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelInput
        '
        Me.LabelInput.BackColor = System.Drawing.Color.Gainsboro
        Me.LabelInput.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelInput.ForeColor = System.Drawing.Color.DimGray
        Me.LabelInput.Location = New System.Drawing.Point(0, 0)
        Me.LabelInput.Name = "LabelInput"
        Me.LabelInput.Size = New System.Drawing.Size(422, 25)
        Me.LabelInput.TabIndex = 2
        Me.LabelInput.Text = "CONFIRMACION DE PAGO"
        Me.LabelInput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelImporte
        '
        Me.LabelImporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelImporte.BackColor = System.Drawing.Color.LightGreen
        Me.LabelImporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelImporte.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelImporte.Location = New System.Drawing.Point(167, 77)
        Me.LabelImporte.Name = "LabelImporte"
        Me.LabelImporte.Size = New System.Drawing.Size(243, 59)
        Me.LabelImporte.TabIndex = 3
        Me.LabelImporte.Text = "$ 0.00"
        Me.LabelImporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RadioButtonEfectivo
        '
        Me.RadioButtonEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonEfectivo.ForeColor = System.Drawing.Color.Gainsboro
        Me.RadioButtonEfectivo.Image = Global.Principal.My.Resources.Resources.money
        Me.RadioButtonEfectivo.Location = New System.Drawing.Point(15, 55)
        Me.RadioButtonEfectivo.Name = "RadioButtonEfectivo"
        Me.RadioButtonEfectivo.Size = New System.Drawing.Size(118, 27)
        Me.RadioButtonEfectivo.TabIndex = 0
        Me.RadioButtonEfectivo.TabStop = True
        Me.RadioButtonEfectivo.Text = "Efectivo"
        Me.RadioButtonEfectivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.RadioButtonEfectivo.UseVisualStyleBackColor = True
        '
        'RadioButtonTarjeta
        '
        Me.RadioButtonTarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonTarjeta.ForeColor = System.Drawing.Color.Gainsboro
        Me.RadioButtonTarjeta.Image = Global.Principal.My.Resources.Resources.creditcards
        Me.RadioButtonTarjeta.Location = New System.Drawing.Point(15, 240)
        Me.RadioButtonTarjeta.Name = "RadioButtonTarjeta"
        Me.RadioButtonTarjeta.Size = New System.Drawing.Size(118, 26)
        Me.RadioButtonTarjeta.TabIndex = 1
        Me.RadioButtonTarjeta.TabStop = True
        Me.RadioButtonTarjeta.Text = "Tarjeta"
        Me.RadioButtonTarjeta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.RadioButtonTarjeta.UseVisualStyleBackColor = True
        '
        'ComboBoxTarjetas
        '
        Me.ComboBoxTarjetas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxTarjetas.FormattingEnabled = True
        Me.ComboBoxTarjetas.Location = New System.Drawing.Point(12, 287)
        Me.ComboBoxTarjetas.Name = "ComboBoxTarjetas"
        Me.ComboBoxTarjetas.Size = New System.Drawing.Size(260, 21)
        Me.ComboBoxTarjetas.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label1.Location = New System.Drawing.Point(12, 269)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Tarjeta Débito / Crédito"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label2.Location = New System.Drawing.Point(275, 269)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Cupón / Referencia"
        '
        'LabelCbte
        '
        Me.LabelCbte.BackColor = System.Drawing.Color.DimGray
        Me.LabelCbte.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelCbte.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCbte.ForeColor = System.Drawing.Color.White
        Me.LabelCbte.Location = New System.Drawing.Point(0, 25)
        Me.LabelCbte.Name = "LabelCbte"
        Me.LabelCbte.Size = New System.Drawing.Size(422, 25)
        Me.LabelCbte.TabIndex = 7
        Me.LabelCbte.Text = "COMPROBANTE"
        Me.LabelCbte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(167, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(243, 22)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Importe TOTAL"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(167, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(243, 22)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Paga CON"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelVuelto
        '
        Me.LabelVuelto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelVuelto.BackColor = System.Drawing.Color.LightGreen
        Me.LabelVuelto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelVuelto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelVuelto.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelVuelto.Location = New System.Drawing.Point(167, 212)
        Me.LabelVuelto.Name = "LabelVuelto"
        Me.LabelVuelto.Size = New System.Drawing.Size(243, 25)
        Me.LabelVuelto.TabIndex = 3
        Me.LabelVuelto.Text = "$ 0.00"
        Me.LabelVuelto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(167, 190)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(243, 22)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Su VUELTO"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBoxVuelto
        '
        Me.TextBoxVuelto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxVuelto.Location = New System.Drawing.Point(167, 161)
        Me.TextBoxVuelto.Name = "TextBoxVuelto"
        Me.TextBoxVuelto.Size = New System.Drawing.Size(243, 26)
        Me.TextBoxVuelto.TabIndex = 9
        Me.TextBoxVuelto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'FormFpDialog
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(422, 356)
        Me.Controls.Add(Me.TextBoxVuelto)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LabelCbte)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBoxTarjetas)
        Me.Controls.Add(Me.RadioButtonTarjeta)
        Me.Controls.Add(Me.RadioButtonEfectivo)
        Me.Controls.Add(Me.LabelVuelto)
        Me.Controls.Add(Me.LabelImporte)
        Me.Controls.Add(Me.LabelInput)
        Me.Controls.Add(Me.TextBoxReferencia)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormFpDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FormInputDialog"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TextBoxReferencia As System.Windows.Forms.TextBox
    Friend WithEvents LabelInput As System.Windows.Forms.Label
    Friend WithEvents LabelImporte As System.Windows.Forms.Label
    Friend WithEvents RadioButtonEfectivo As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonTarjeta As System.Windows.Forms.RadioButton
    Friend WithEvents ComboBoxTarjetas As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LabelCbte As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LabelVuelto As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBoxVuelto As System.Windows.Forms.TextBox

End Class
