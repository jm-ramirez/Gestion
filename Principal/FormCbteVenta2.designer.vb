<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCbteVenta2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCbteVenta2))
        Me.TableLayoutPanelBase = New System.Windows.Forms.TableLayoutPanel()
        Me.ToolStripMenu = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonAutorizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabelStatus = New System.Windows.Forms.ToolStripLabel()
        Me.PanelControles = New System.Windows.Forms.Panel()
        Me.LabelTotal = New System.Windows.Forms.Label()
        Me.CtlArticulos1 = New Principal.CtlArticulos()
        Me.TextBoxSubtotal = New System.Windows.Forms.TextBox()
        Me.TextBoxTotal = New System.Windows.Forms.TextBox()
        Me.TextBoxNogravado = New System.Windows.Forms.TextBox()
        Me.TextBoxExento = New System.Windows.Forms.TextBox()
        Me.TextBoxIVAFacturado = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TextBoxOtrosTributos = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBoxComprobante = New System.Windows.Forms.GroupBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ComboBoxMoneda = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePickerVigencia = New System.Windows.Forms.DateTimePicker()
        Me.ComboBoxTipoCbte = New System.Windows.Forms.ComboBox()
        Me.TextBoxNumero = New System.Windows.Forms.TextBox()
        Me.ComboBoxPtoVta = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DateTimePickerFecha = New System.Windows.Forms.DateTimePicker()
        Me.GroupBoxPeriodo = New System.Windows.Forms.GroupBox()
        Me.txtNotas = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtObs = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBoxMantenimientoOferta = New System.Windows.Forms.TextBox()
        Me.TextBoxLugarEntrega = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBoxPlazosEntrega = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxCondicionesPago = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBoxDatosCliente = New System.Windows.Forms.GroupBox()
        Me.TextBoxEmail = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBoxContacto = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBoxNombre = New System.Windows.Forms.TextBox()
        Me.ComboBoxCliente = New Principal.CtlCustomCombo()
        Me.TextBoxDomicilio = New System.Windows.Forms.TextBox()
        Me.TextBoxTipoDoc = New System.Windows.Forms.TextBox()
        Me.TextBoxTipoIVA = New System.Windows.Forms.TextBox()
        Me.TextBoxTelefono = New System.Windows.Forms.TextBox()
        Me.TextBoxDocumento = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanelBase.SuspendLayout()
        Me.ToolStripMenu.SuspendLayout()
        Me.PanelControles.SuspendLayout()
        Me.GroupBoxComprobante.SuspendLayout()
        Me.GroupBoxPeriodo.SuspendLayout()
        Me.GroupBoxDatosCliente.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanelBase
        '
        Me.TableLayoutPanelBase.ColumnCount = 1
        Me.TableLayoutPanelBase.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelBase.Controls.Add(Me.ToolStripMenu, 0, 0)
        Me.TableLayoutPanelBase.Controls.Add(Me.PanelControles, 0, 1)
        Me.TableLayoutPanelBase.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanelBase.Name = "TableLayoutPanelBase"
        Me.TableLayoutPanelBase.RowCount = 2
        Me.TableLayoutPanelBase.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanelBase.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelBase.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanelBase.Size = New System.Drawing.Size(1010, 728)
        Me.TableLayoutPanelBase.TabIndex = 0
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonAutorizar, Me.ToolStripButtonCancelar, Me.ToolStripSeparator2, Me.ToolStripButtonSalir, Me.ToolStripSeparator1, Me.ToolStripLabelStatus})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStripMenu.Size = New System.Drawing.Size(1010, 25)
        Me.ToolStripMenu.TabIndex = 0
        Me.ToolStripMenu.Text = "ToolStrip1"
        '
        'ToolStripButtonAutorizar
        '
        Me.ToolStripButtonAutorizar.Image = Global.Principal.My.Resources.Resources.disk
        Me.ToolStripButtonAutorizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonAutorizar.Name = "ToolStripButtonAutorizar"
        Me.ToolStripButtonAutorizar.Size = New System.Drawing.Size(130, 22)
        Me.ToolStripButtonAutorizar.Text = "Registrar Cbte. [F12]"
        '
        'ToolStripButtonCancelar
        '
        Me.ToolStripButtonCancelar.Image = Global.Principal.My.Resources.Resources.cancel
        Me.ToolStripButtonCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonCancelar.Name = "ToolStripButtonCancelar"
        Me.ToolStripButtonCancelar.Size = New System.Drawing.Size(96, 22)
        Me.ToolStripButtonCancelar.Text = "Cancelar [Esc]"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButtonSalir
        '
        Me.ToolStripButtonSalir.Image = Global.Principal.My.Resources.Resources.door_out
        Me.ToolStripButtonSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonSalir.Name = "ToolStripButtonSalir"
        Me.ToolStripButtonSalir.Size = New System.Drawing.Size(74, 22)
        Me.ToolStripButtonSalir.Text = "Salir [Esc]"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabelStatus
        '
        Me.ToolStripLabelStatus.Name = "ToolStripLabelStatus"
        Me.ToolStripLabelStatus.Size = New System.Drawing.Size(38, 22)
        Me.ToolStripLabelStatus.Text = "Status"
        '
        'PanelControles
        '
        Me.PanelControles.Controls.Add(Me.LabelTotal)
        Me.PanelControles.Controls.Add(Me.CtlArticulos1)
        Me.PanelControles.Controls.Add(Me.TextBoxSubtotal)
        Me.PanelControles.Controls.Add(Me.TextBoxTotal)
        Me.PanelControles.Controls.Add(Me.TextBoxNogravado)
        Me.PanelControles.Controls.Add(Me.TextBoxExento)
        Me.PanelControles.Controls.Add(Me.TextBoxIVAFacturado)
        Me.PanelControles.Controls.Add(Me.Label25)
        Me.PanelControles.Controls.Add(Me.TextBoxOtrosTributos)
        Me.PanelControles.Controls.Add(Me.Label24)
        Me.PanelControles.Controls.Add(Me.Label17)
        Me.PanelControles.Controls.Add(Me.Label8)
        Me.PanelControles.Controls.Add(Me.Label18)
        Me.PanelControles.Controls.Add(Me.Label7)
        Me.PanelControles.Controls.Add(Me.GroupBoxComprobante)
        Me.PanelControles.Controls.Add(Me.GroupBoxPeriodo)
        Me.PanelControles.Controls.Add(Me.GroupBoxDatosCliente)
        Me.PanelControles.Location = New System.Drawing.Point(3, 34)
        Me.PanelControles.Name = "PanelControles"
        Me.PanelControles.Size = New System.Drawing.Size(1004, 689)
        Me.PanelControles.TabIndex = 2
        '
        'LabelTotal
        '
        Me.LabelTotal.BackColor = System.Drawing.Color.Azure
        Me.LabelTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelTotal.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotal.ForeColor = System.Drawing.Color.Black
        Me.LabelTotal.Location = New System.Drawing.Point(0, 655)
        Me.LabelTotal.Name = "LabelTotal"
        Me.LabelTotal.Size = New System.Drawing.Size(997, 30)
        Me.LabelTotal.TabIndex = 28
        Me.LabelTotal.Text = "0.0"
        Me.LabelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CtlArticulos1
        '
        Me.CtlArticulos1.DescuentoGral = 0.0R
        Me.CtlArticulos1.idCliente = Nothing
        Me.CtlArticulos1.ListaDePrecio = Principal.CtlArticulos.ListaPrecios.LISTA_A
        Me.CtlArticulos1.Location = New System.Drawing.Point(9, 174)
        Me.CtlArticulos1.MaximoItems = CType(25US, UShort)
        Me.CtlArticulos1.Name = "CtlArticulos1"
        Me.CtlArticulos1.Size = New System.Drawing.Size(998, 315)
        Me.CtlArticulos1.TabIndex = 12
        Me.CtlArticulos1.TipoCargaCbte = Principal.General.TipoEmisionCbte.ELECTRONICO
        Me.CtlArticulos1.TipoDeCbte = Principal.CtlArticulos.TipoCbte.CBTEVTA
        '
        'TextBoxSubtotal
        '
        Me.TextBoxSubtotal.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxSubtotal.Location = New System.Drawing.Point(272, 660)
        Me.TextBoxSubtotal.Name = "TextBoxSubtotal"
        Me.TextBoxSubtotal.ReadOnly = True
        Me.TextBoxSubtotal.Size = New System.Drawing.Size(125, 20)
        Me.TextBoxSubtotal.TabIndex = 6
        Me.TextBoxSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBoxSubtotal.Visible = False
        '
        'TextBoxTotal
        '
        Me.TextBoxTotal.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxTotal.Location = New System.Drawing.Point(864, 493)
        Me.TextBoxTotal.Name = "TextBoxTotal"
        Me.TextBoxTotal.ReadOnly = True
        Me.TextBoxTotal.Size = New System.Drawing.Size(125, 20)
        Me.TextBoxTotal.TabIndex = 6
        Me.TextBoxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBoxNogravado
        '
        Me.TextBoxNogravado.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxNogravado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxNogravado.Location = New System.Drawing.Point(476, 662)
        Me.TextBoxNogravado.Name = "TextBoxNogravado"
        Me.TextBoxNogravado.ReadOnly = True
        Me.TextBoxNogravado.Size = New System.Drawing.Size(125, 20)
        Me.TextBoxNogravado.TabIndex = 10
        Me.TextBoxNogravado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBoxNogravado.Visible = False
        '
        'TextBoxExento
        '
        Me.TextBoxExento.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxExento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxExento.Location = New System.Drawing.Point(476, 664)
        Me.TextBoxExento.Name = "TextBoxExento"
        Me.TextBoxExento.ReadOnly = True
        Me.TextBoxExento.Size = New System.Drawing.Size(125, 20)
        Me.TextBoxExento.TabIndex = 9
        Me.TextBoxExento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBoxExento.Visible = False
        '
        'TextBoxIVAFacturado
        '
        Me.TextBoxIVAFacturado.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxIVAFacturado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxIVAFacturado.Location = New System.Drawing.Point(272, 658)
        Me.TextBoxIVAFacturado.Name = "TextBoxIVAFacturado"
        Me.TextBoxIVAFacturado.ReadOnly = True
        Me.TextBoxIVAFacturado.Size = New System.Drawing.Size(125, 20)
        Me.TextBoxIVAFacturado.TabIndex = 8
        Me.TextBoxIVAFacturado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBoxIVAFacturado.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(405, 665)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(65, 13)
        Me.Label25.TabIndex = 26
        Me.Label25.Text = "No Gravado"
        Me.Label25.Visible = False
        '
        'TextBoxOtrosTributos
        '
        Me.TextBoxOtrosTributos.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxOtrosTributos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxOtrosTributos.Location = New System.Drawing.Point(272, 666)
        Me.TextBoxOtrosTributos.Name = "TextBoxOtrosTributos"
        Me.TextBoxOtrosTributos.ReadOnly = True
        Me.TextBoxOtrosTributos.Size = New System.Drawing.Size(125, 20)
        Me.TextBoxOtrosTributos.TabIndex = 7
        Me.TextBoxOtrosTributos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBoxOtrosTributos.Visible = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(430, 673)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(40, 13)
        Me.Label24.TabIndex = 26
        Me.Label24.Text = "Exento"
        Me.Label24.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(811, 496)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(47, 13)
        Me.Label17.TabIndex = 25
        Me.Label17.Text = "TOTAL"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(191, 661)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 13)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "IVA Facturado"
        Me.Label8.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(192, 669)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(74, 13)
        Me.Label18.TabIndex = 23
        Me.Label18.Text = "Neto Gravado"
        Me.Label18.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(193, 669)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Otros Tributos"
        Me.Label7.Visible = False
        '
        'GroupBoxComprobante
        '
        Me.GroupBoxComprobante.Controls.Add(Me.Label23)
        Me.GroupBoxComprobante.Controls.Add(Me.ComboBoxMoneda)
        Me.GroupBoxComprobante.Controls.Add(Me.Label1)
        Me.GroupBoxComprobante.Controls.Add(Me.DateTimePickerVigencia)
        Me.GroupBoxComprobante.Controls.Add(Me.ComboBoxTipoCbte)
        Me.GroupBoxComprobante.Controls.Add(Me.TextBoxNumero)
        Me.GroupBoxComprobante.Controls.Add(Me.ComboBoxPtoVta)
        Me.GroupBoxComprobante.Controls.Add(Me.Label9)
        Me.GroupBoxComprobante.Controls.Add(Me.DateTimePickerFecha)
        Me.GroupBoxComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxComprobante.Location = New System.Drawing.Point(636, 3)
        Me.GroupBoxComprobante.Name = "GroupBoxComprobante"
        Me.GroupBoxComprobante.Size = New System.Drawing.Size(368, 168)
        Me.GroupBoxComprobante.TabIndex = 1
        Me.GroupBoxComprobante.TabStop = False
        Me.GroupBoxComprobante.Text = "Comprobante Nº"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(279, 120)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(52, 13)
        Me.Label23.TabIndex = 14
        Me.Label23.Text = "Moneda"
        Me.Label23.Visible = False
        '
        'ComboBoxMoneda
        '
        Me.ComboBoxMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxMoneda.FormattingEnabled = True
        Me.ComboBoxMoneda.Location = New System.Drawing.Point(338, 117)
        Me.ComboBoxMoneda.Name = "ComboBoxMoneda"
        Me.ComboBoxMoneda.Size = New System.Drawing.Size(79, 21)
        Me.ComboBoxMoneda.TabIndex = 13
        Me.ComboBoxMoneda.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(191, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Vigencia"
        '
        'DateTimePickerVigencia
        '
        Me.DateTimePickerVigencia.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerVigencia.Location = New System.Drawing.Point(253, 73)
        Me.DateTimePickerVigencia.Name = "DateTimePickerVigencia"
        Me.DateTimePickerVigencia.Size = New System.Drawing.Size(102, 20)
        Me.DateTimePickerVigencia.TabIndex = 11
        '
        'ComboBoxTipoCbte
        '
        Me.ComboBoxTipoCbte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxTipoCbte.DropDownWidth = 250
        Me.ComboBoxTipoCbte.FormattingEnabled = True
        Me.ComboBoxTipoCbte.Location = New System.Drawing.Point(6, 22)
        Me.ComboBoxTipoCbte.Name = "ComboBoxTipoCbte"
        Me.ComboBoxTipoCbte.Size = New System.Drawing.Size(204, 21)
        Me.ComboBoxTipoCbte.TabIndex = 7
        '
        'TextBoxNumero
        '
        Me.TextBoxNumero.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxNumero.Location = New System.Drawing.Point(282, 22)
        Me.TextBoxNumero.Name = "TextBoxNumero"
        Me.TextBoxNumero.Size = New System.Drawing.Size(70, 20)
        Me.TextBoxNumero.TabIndex = 9
        Me.TextBoxNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ComboBoxPtoVta
        '
        Me.ComboBoxPtoVta.FormattingEnabled = True
        Me.ComboBoxPtoVta.Location = New System.Drawing.Point(217, 22)
        Me.ComboBoxPtoVta.Name = "ComboBoxPtoVta"
        Me.ComboBoxPtoVta.Size = New System.Drawing.Size(59, 21)
        Me.ComboBoxPtoVta.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(205, 53)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Fecha"
        '
        'DateTimePickerFecha
        '
        Me.DateTimePickerFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerFecha.Location = New System.Drawing.Point(253, 49)
        Me.DateTimePickerFecha.Name = "DateTimePickerFecha"
        Me.DateTimePickerFecha.Size = New System.Drawing.Size(102, 20)
        Me.DateTimePickerFecha.TabIndex = 10
        '
        'GroupBoxPeriodo
        '
        Me.GroupBoxPeriodo.Controls.Add(Me.txtNotas)
        Me.GroupBoxPeriodo.Controls.Add(Me.Label15)
        Me.GroupBoxPeriodo.Controls.Add(Me.txtObs)
        Me.GroupBoxPeriodo.Controls.Add(Me.Label12)
        Me.GroupBoxPeriodo.Controls.Add(Me.TextBoxMantenimientoOferta)
        Me.GroupBoxPeriodo.Controls.Add(Me.TextBoxLugarEntrega)
        Me.GroupBoxPeriodo.Controls.Add(Me.Label11)
        Me.GroupBoxPeriodo.Controls.Add(Me.TextBoxPlazosEntrega)
        Me.GroupBoxPeriodo.Controls.Add(Me.Label10)
        Me.GroupBoxPeriodo.Controls.Add(Me.Label3)
        Me.GroupBoxPeriodo.Controls.Add(Me.TextBoxCondicionesPago)
        Me.GroupBoxPeriodo.Controls.Add(Me.Label5)
        Me.GroupBoxPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxPeriodo.ForeColor = System.Drawing.Color.Black
        Me.GroupBoxPeriodo.Location = New System.Drawing.Point(3, 510)
        Me.GroupBoxPeriodo.Name = "GroupBoxPeriodo"
        Me.GroupBoxPeriodo.Size = New System.Drawing.Size(1000, 143)
        Me.GroupBoxPeriodo.TabIndex = 2
        Me.GroupBoxPeriodo.TabStop = False
        Me.GroupBoxPeriodo.Text = "Condiciones Generales :"
        '
        'txtNotas
        '
        Me.txtNotas.BackColor = System.Drawing.SystemColors.Info
        Me.txtNotas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotas.Location = New System.Drawing.Point(512, 99)
        Me.txtNotas.MaxLength = 1000
        Me.txtNotas.Multiline = True
        Me.txtNotas.Name = "txtNotas"
        Me.txtNotas.Size = New System.Drawing.Size(483, 37)
        Me.txtNotas.TabIndex = 12
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.SystemColors.Info
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(426, 119)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(85, 13)
        Me.Label15.TabIndex = 13
        Me.Label15.Text = "Anotaciones :"
        '
        'txtObs
        '
        Me.txtObs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObs.Location = New System.Drawing.Point(512, 26)
        Me.txtObs.MaxLength = 1000
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(483, 69)
        Me.txtObs.TabIndex = 11
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(509, 10)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 13)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Observación"
        '
        'TextBoxMantenimientoOferta
        '
        Me.TextBoxMantenimientoOferta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxMantenimientoOferta.Location = New System.Drawing.Point(140, 92)
        Me.TextBoxMantenimientoOferta.MaxLength = 80
        Me.TextBoxMantenimientoOferta.Name = "TextBoxMantenimientoOferta"
        Me.TextBoxMantenimientoOferta.Size = New System.Drawing.Size(367, 20)
        Me.TextBoxMantenimientoOferta.TabIndex = 10
        '
        'TextBoxLugarEntrega
        '
        Me.TextBoxLugarEntrega.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxLugarEntrega.Location = New System.Drawing.Point(140, 43)
        Me.TextBoxLugarEntrega.MaxLength = 80
        Me.TextBoxLugarEntrega.Name = "TextBoxLugarEntrega"
        Me.TextBoxLugarEntrega.Size = New System.Drawing.Size(367, 20)
        Me.TextBoxLugarEntrega.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(4, 95)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(134, 13)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Mantenimiento de la Oferta"
        '
        'TextBoxPlazosEntrega
        '
        Me.TextBoxPlazosEntrega.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPlazosEntrega.Location = New System.Drawing.Point(140, 67)
        Me.TextBoxPlazosEntrega.MaxLength = 80
        Me.TextBoxPlazosEntrega.Name = "TextBoxPlazosEntrega"
        Me.TextBoxPlazosEntrega.Size = New System.Drawing.Size(367, 20)
        Me.TextBoxPlazosEntrega.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(49, 44)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Lugar de Entrega"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(50, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Plazo de Entrega"
        '
        'TextBoxCondicionesPago
        '
        Me.TextBoxCondicionesPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCondicionesPago.Location = New System.Drawing.Point(140, 20)
        Me.TextBoxCondicionesPago.MaxLength = 80
        Me.TextBoxCondicionesPago.Name = "TextBoxCondicionesPago"
        Me.TextBoxCondicionesPago.Size = New System.Drawing.Size(367, 20)
        Me.TextBoxCondicionesPago.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(30, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Condiciones de Pago"
        '
        'GroupBoxDatosCliente
        '
        Me.GroupBoxDatosCliente.Controls.Add(Me.TextBoxEmail)
        Me.GroupBoxDatosCliente.Controls.Add(Me.Label14)
        Me.GroupBoxDatosCliente.Controls.Add(Me.TextBoxContacto)
        Me.GroupBoxDatosCliente.Controls.Add(Me.Label13)
        Me.GroupBoxDatosCliente.Controls.Add(Me.TextBoxNombre)
        Me.GroupBoxDatosCliente.Controls.Add(Me.ComboBoxCliente)
        Me.GroupBoxDatosCliente.Controls.Add(Me.TextBoxDomicilio)
        Me.GroupBoxDatosCliente.Controls.Add(Me.TextBoxTipoDoc)
        Me.GroupBoxDatosCliente.Controls.Add(Me.TextBoxTipoIVA)
        Me.GroupBoxDatosCliente.Controls.Add(Me.TextBoxTelefono)
        Me.GroupBoxDatosCliente.Controls.Add(Me.TextBoxDocumento)
        Me.GroupBoxDatosCliente.Controls.Add(Me.Label2)
        Me.GroupBoxDatosCliente.Controls.Add(Me.Label16)
        Me.GroupBoxDatosCliente.Controls.Add(Me.Label4)
        Me.GroupBoxDatosCliente.Controls.Add(Me.Label6)
        Me.GroupBoxDatosCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxDatosCliente.Location = New System.Drawing.Point(9, 3)
        Me.GroupBoxDatosCliente.Name = "GroupBoxDatosCliente"
        Me.GroupBoxDatosCliente.Size = New System.Drawing.Size(624, 168)
        Me.GroupBoxDatosCliente.TabIndex = 0
        Me.GroupBoxDatosCliente.TabStop = False
        Me.GroupBoxDatosCliente.Text = "Datos del Cliente"
        '
        'TextBoxEmail
        '
        Me.TextBoxEmail.Location = New System.Drawing.Point(33, 117)
        Me.TextBoxEmail.MaxLength = 100
        Me.TextBoxEmail.Name = "TextBoxEmail"
        Me.TextBoxEmail.Size = New System.Drawing.Size(441, 20)
        Me.TextBoxEmail.TabIndex = 7
        '
        'Label14
        '
        Me.Label14.Image = Global.Principal.My.Resources.Resources.email
        Me.Label14.Location = New System.Drawing.Point(3, 120)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(26, 17)
        Me.Label14.TabIndex = 10
        '
        'TextBoxContacto
        '
        Me.TextBoxContacto.Location = New System.Drawing.Point(33, 141)
        Me.TextBoxContacto.MaxLength = 80
        Me.TextBoxContacto.Name = "TextBoxContacto"
        Me.TextBoxContacto.Size = New System.Drawing.Size(441, 20)
        Me.TextBoxContacto.TabIndex = 8
        '
        'Label13
        '
        Me.Label13.Image = Global.Principal.My.Resources.Resources.user_comment
        Me.Label13.Location = New System.Drawing.Point(3, 144)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(26, 17)
        Me.Label13.TabIndex = 8
        '
        'TextBoxNombre
        '
        Me.TextBoxNombre.Location = New System.Drawing.Point(33, 46)
        Me.TextBoxNombre.MaxLength = 80
        Me.TextBoxNombre.Name = "TextBoxNombre"
        Me.TextBoxNombre.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxNombre.Size = New System.Drawing.Size(365, 20)
        Me.TextBoxNombre.TabIndex = 1
        '
        'ComboBoxCliente
        '
        Me.ComboBoxCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.ComboBoxCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.ComboBoxCliente.BusquedaPorCodigobarra = False
        Me.ComboBoxCliente.ColumnasExtras = Nothing
        Me.ComboBoxCliente.CustomFormatArt = False
        Me.ComboBoxCliente.DataSource = Nothing
        Me.ComboBoxCliente.DisplayMember = Nothing
        Me.ComboBoxCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ComboBoxCliente.FormularioDeAlta = Nothing
        Me.ComboBoxCliente.FormularioDeBusqueda = Nothing
        Me.ComboBoxCliente.Location = New System.Drawing.Point(33, 17)
        Me.ComboBoxCliente.MaximumSize = New System.Drawing.Size(500, 25)
        Me.ComboBoxCliente.MinimumSize = New System.Drawing.Size(199, 25)
        Me.ComboBoxCliente.Name = "ComboBoxCliente"
        Me.ComboBoxCliente.SelectedIndex = -1
        Me.ComboBoxCliente.SelectedItem = Nothing
        Me.ComboBoxCliente.SelectedText = ""
        Me.ComboBoxCliente.SelectedValue = Nothing
        Me.ComboBoxCliente.Size = New System.Drawing.Size(365, 25)
        Me.ComboBoxCliente.TabIndex = 0
        Me.ComboBoxCliente.ValueMember = Nothing
        '
        'TextBoxDomicilio
        '
        Me.TextBoxDomicilio.Location = New System.Drawing.Point(33, 70)
        Me.TextBoxDomicilio.MaxLength = 255
        Me.TextBoxDomicilio.Name = "TextBoxDomicilio"
        Me.TextBoxDomicilio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxDomicilio.Size = New System.Drawing.Size(365, 20)
        Me.TextBoxDomicilio.TabIndex = 2
        '
        'TextBoxTipoDoc
        '
        Me.TextBoxTipoDoc.Location = New System.Drawing.Point(478, 94)
        Me.TextBoxTipoDoc.MaxLength = 80
        Me.TextBoxTipoDoc.Name = "TextBoxTipoDoc"
        Me.TextBoxTipoDoc.Size = New System.Drawing.Size(41, 20)
        Me.TextBoxTipoDoc.TabIndex = 5
        Me.TextBoxTipoDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxTipoIVA
        '
        Me.TextBoxTipoIVA.Location = New System.Drawing.Point(299, 94)
        Me.TextBoxTipoIVA.MaxLength = 80
        Me.TextBoxTipoIVA.Name = "TextBoxTipoIVA"
        Me.TextBoxTipoIVA.Size = New System.Drawing.Size(175, 20)
        Me.TextBoxTipoIVA.TabIndex = 4
        Me.TextBoxTipoIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxTelefono
        '
        Me.TextBoxTelefono.Location = New System.Drawing.Point(33, 94)
        Me.TextBoxTelefono.MaxLength = 60
        Me.TextBoxTelefono.Name = "TextBoxTelefono"
        Me.TextBoxTelefono.Size = New System.Drawing.Size(237, 20)
        Me.TextBoxTelefono.TabIndex = 3
        '
        'TextBoxDocumento
        '
        Me.TextBoxDocumento.Location = New System.Drawing.Point(522, 94)
        Me.TextBoxDocumento.MaxLength = 11
        Me.TextBoxDocumento.Name = "TextBoxDocumento"
        Me.TextBoxDocumento.Size = New System.Drawing.Size(97, 20)
        Me.TextBoxDocumento.TabIndex = 6
        Me.TextBoxDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Image = Global.Principal.My.Resources.Resources.book_addresses
        Me.Label2.Location = New System.Drawing.Point(3, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 17)
        Me.Label2.TabIndex = 3
        '
        'Label16
        '
        Me.Label16.Image = Global.Principal.My.Resources.Resources.telephone
        Me.Label16.Location = New System.Drawing.Point(3, 97)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(26, 17)
        Me.Label16.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(270, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "IVA"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Image = Global.Principal.My.Resources.Resources.group
        Me.Label6.Location = New System.Drawing.Point(2, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 17)
        Me.Label6.TabIndex = 3
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Info
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(512, 99)
        Me.TextBox1.MaxLength = 1000
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(483, 37)
        Me.TextBox1.TabIndex = 12
        '
        'FormCbteVenta2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1012, 729)
        Me.Controls.Add(Me.TableLayoutPanelBase)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FormCbteVenta2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormCbteElectronico"
        Me.TableLayoutPanelBase.ResumeLayout(False)
        Me.TableLayoutPanelBase.PerformLayout()
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.PanelControles.ResumeLayout(False)
        Me.PanelControles.PerformLayout()
        Me.GroupBoxComprobante.ResumeLayout(False)
        Me.GroupBoxComprobante.PerformLayout()
        Me.GroupBoxPeriodo.ResumeLayout(False)
        Me.GroupBoxPeriodo.PerformLayout()
        Me.GroupBoxDatosCliente.ResumeLayout(False)
        Me.GroupBoxDatosCliente.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanelBase As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabelStatus As System.Windows.Forms.ToolStripLabel
    Friend WithEvents PanelControles As System.Windows.Forms.Panel
    Friend WithEvents GroupBoxDatosCliente As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxDocumento As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePickerFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextBoxNumero As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxPtoVta As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxTipoCbte As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxComprobante As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxSubtotal As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxTotal As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxIVAFacturado As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxOtrosTributos As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ToolStripButtonAutorizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TextBoxNogravado As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxExento As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxCliente As Principal.CtlCustomCombo
    Friend WithEvents TextBoxDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxTipoDoc As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxTipoIVA As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxPeriodo As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxCondicionesPago As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButtonSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerVigencia As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextBoxMantenimientoOferta As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxLugarEntrega As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBoxPlazosEntrega As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CtlArticulos1 As Principal.CtlArticulos
    Friend WithEvents LabelTotal As System.Windows.Forms.Label
    Friend WithEvents txtObs As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNombre As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextBoxContacto As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents txtNotas As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
