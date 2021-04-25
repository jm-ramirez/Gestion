<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCbteVentaKiosco
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCbteVentaKiosco))
        Me.TableLayoutPanelBase = New System.Windows.Forms.TableLayoutPanel()
        Me.ToolStripMenu = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonAutorizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonProforma = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabelStatus = New System.Windows.Forms.ToolStripLabel()
        Me.PanelControles = New System.Windows.Forms.Panel()
        Me.CtlCbteDetalle = New Principal.CtlDetalleCbte2()
        Me.nudDolar = New System.Windows.Forms.NumericUpDown()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.LabelTotal = New System.Windows.Forms.Label()
        Me.TextBoxSubtotal = New System.Windows.Forms.TextBox()
        Me.TextBoxTotal = New System.Windows.Forms.TextBox()
        Me.TextBoxNogravado = New System.Windows.Forms.TextBox()
        Me.TextBoxExento = New System.Windows.Forms.TextBox()
        Me.TextBoxIVAFacturado = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TextBoxOtrosTributos = New System.Windows.Forms.TextBox()
        Me.lblExento = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBoxComprobante = New System.Windows.Forms.GroupBox()
        Me.ComboBoxTipoCbte = New System.Windows.Forms.ComboBox()
        Me.TextBoxNumero = New System.Windows.Forms.TextBox()
        Me.ComboBoxPtoVta = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DateTimePickerFecha = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBoxCAEVto = New System.Windows.Forms.TextBox()
        Me.TextBoxCAE = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBoxPeriodo = New System.Windows.Forms.GroupBox()
        Me.DateTimePickerPeriodoDesde = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePickerVto = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePickerPeriodoHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBoxConceptos = New System.Windows.Forms.GroupBox()
        Me.ComboBoxConceptos = New System.Windows.Forms.ComboBox()
        Me.ComboBoxFormaPago = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBoxDatosCliente = New System.Windows.Forms.GroupBox()
        Me.ComboBoxDomicilios = New System.Windows.Forms.ComboBox()
        Me.ComboBoxCliente = New Principal.CtlCustomCombo()
        Me.TextBoxDomicilio = New System.Windows.Forms.TextBox()
        Me.TextBoxNombre = New System.Windows.Forms.TextBox()
        Me.TextBoxDescuentoGral = New System.Windows.Forms.TextBox()
        Me.TextBoxDocumento = New System.Windows.Forms.TextBox()
        Me.ComboBoxResponsabilidadIVA = New System.Windows.Forms.ComboBox()
        Me.ComboBoxDocumento = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanelBase.SuspendLayout()
        Me.ToolStripMenu.SuspendLayout()
        Me.PanelControles.SuspendLayout()
        CType(Me.nudDolar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxComprobante.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBoxPeriodo.SuspendLayout()
        Me.GroupBoxConceptos.SuspendLayout()
        Me.GroupBoxDatosCliente.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanelBase
        '
        Me.TableLayoutPanelBase.ColumnCount = 1
        Me.TableLayoutPanelBase.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelBase.Controls.Add(Me.ToolStripMenu, 0, 0)
        Me.TableLayoutPanelBase.Controls.Add(Me.PanelControles, 0, 1)
        Me.TableLayoutPanelBase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelBase.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanelBase.Name = "TableLayoutPanelBase"
        Me.TableLayoutPanelBase.RowCount = 2
        Me.TableLayoutPanelBase.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanelBase.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelBase.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanelBase.Size = New System.Drawing.Size(884, 651)
        Me.TableLayoutPanelBase.TabIndex = 0
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonAutorizar, Me.ToolStripButtonCancelar, Me.ToolStripButtonProforma, Me.ToolStripSeparator1, Me.ToolStripLabelStatus})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStripMenu.Size = New System.Drawing.Size(884, 25)
        Me.ToolStripMenu.TabIndex = 1
        Me.ToolStripMenu.Text = "ToolStrip1"
        '
        'ToolStripButtonAutorizar
        '
        Me.ToolStripButtonAutorizar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButtonAutorizar.Image = Global.Principal.My.Resources.Resources.server_go
        Me.ToolStripButtonAutorizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonAutorizar.Name = "ToolStripButtonAutorizar"
        Me.ToolStripButtonAutorizar.Size = New System.Drawing.Size(145, 22)
        Me.ToolStripButtonAutorizar.Text = "Autorizar Cbte. [F12]"
        '
        'ToolStripButtonCancelar
        '
        Me.ToolStripButtonCancelar.Image = Global.Principal.My.Resources.Resources.cancel
        Me.ToolStripButtonCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonCancelar.Name = "ToolStripButtonCancelar"
        Me.ToolStripButtonCancelar.Size = New System.Drawing.Size(101, 22)
        Me.ToolStripButtonCancelar.Text = "Cancelar [Esc]"
        '
        'ToolStripButtonProforma
        '
        Me.ToolStripButtonProforma.Enabled = False
        Me.ToolStripButtonProforma.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButtonProforma.Image = Global.Principal.My.Resources.Resources.report
        Me.ToolStripButtonProforma.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonProforma.Name = "ToolStripButtonProforma"
        Me.ToolStripButtonProforma.Size = New System.Drawing.Size(71, 22)
        Me.ToolStripButtonProforma.Text = "Proforma"
        Me.ToolStripButtonProforma.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabelStatus
        '
        Me.ToolStripLabelStatus.Name = "ToolStripLabelStatus"
        Me.ToolStripLabelStatus.Size = New System.Drawing.Size(39, 22)
        Me.ToolStripLabelStatus.Text = "Status"
        '
        'PanelControles
        '
        Me.PanelControles.Controls.Add(Me.CtlCbteDetalle)
        Me.PanelControles.Controls.Add(Me.nudDolar)
        Me.PanelControles.Controls.Add(Me.Label23)
        Me.PanelControles.Controls.Add(Me.LabelTotal)
        Me.PanelControles.Controls.Add(Me.TextBoxSubtotal)
        Me.PanelControles.Controls.Add(Me.TextBoxTotal)
        Me.PanelControles.Controls.Add(Me.TextBoxNogravado)
        Me.PanelControles.Controls.Add(Me.TextBoxExento)
        Me.PanelControles.Controls.Add(Me.TextBoxIVAFacturado)
        Me.PanelControles.Controls.Add(Me.Label25)
        Me.PanelControles.Controls.Add(Me.TextBoxOtrosTributos)
        Me.PanelControles.Controls.Add(Me.lblExento)
        Me.PanelControles.Controls.Add(Me.lblTotal)
        Me.PanelControles.Controls.Add(Me.Label8)
        Me.PanelControles.Controls.Add(Me.Label18)
        Me.PanelControles.Controls.Add(Me.Label7)
        Me.PanelControles.Controls.Add(Me.GroupBoxComprobante)
        Me.PanelControles.Controls.Add(Me.GroupBox1)
        Me.PanelControles.Controls.Add(Me.GroupBoxPeriodo)
        Me.PanelControles.Controls.Add(Me.GroupBoxConceptos)
        Me.PanelControles.Controls.Add(Me.GroupBoxDatosCliente)
        Me.PanelControles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControles.Location = New System.Drawing.Point(3, 33)
        Me.PanelControles.Name = "PanelControles"
        Me.PanelControles.Size = New System.Drawing.Size(878, 615)
        Me.PanelControles.TabIndex = 0
        '
        'CtlCbteDetalle
        '
        Me.CtlCbteDetalle.AgrupaArticulosDetalle = False
        Me.CtlCbteDetalle.AnularDepositoNro = 0
        Me.CtlCbteDetalle.Cliente = Nothing
        Me.CtlCbteDetalle.CompraANoInscripto = False
        Me.CtlCbteDetalle.CptoBcoEgrPredetermiando = Nothing
        Me.CtlCbteDetalle.CptoBcoIngPredetermiando = Nothing
        Me.CtlCbteDetalle.CtaBcoPredeterminada = Nothing
        Me.CtlCbteDetalle.DescuentoGral = 0R
        Me.CtlCbteDetalle.FechaComprobante = New Date(2021, 4, 11, 0, 0, 0, 0)
        Me.CtlCbteDetalle.ListaDePrecio = Principal.CtlDetalleCbte2.ListaPrecios.LISTA1
        Me.CtlCbteDetalle.Location = New System.Drawing.Point(9, 232)
        Me.CtlCbteDetalle.MaximoItems = CType(25US, UShort)
        Me.CtlCbteDetalle.Name = "CtlCbteDetalle"
        Me.CtlCbteDetalle.Proveedor = Nothing
        Me.CtlCbteDetalle.Size = New System.Drawing.Size(852, 251)
        Me.CtlCbteDetalle.TabIndex = 50
        Me.CtlCbteDetalle.TipoCargaCbte = Principal.General.TipoEmisionCbte.ELECTRONICO
        Me.CtlCbteDetalle.TipoDeCbte = Principal.CtlDetalleCbte2.TipoCbte.CBTEVTA
        Me.CtlCbteDetalle.Vendedor = Nothing
        Me.CtlCbteDetalle.VerCuentaCta = False
        '
        'nudDolar
        '
        Me.nudDolar.DecimalPlaces = 2
        Me.nudDolar.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        Me.nudDolar.Location = New System.Drawing.Point(339, 516)
        Me.nudDolar.Maximum = New Decimal(New Integer() {9999, 0, 0, 131072})
        Me.nudDolar.Name = "nudDolar"
        Me.nudDolar.Size = New System.Drawing.Size(79, 20)
        Me.nudDolar.TabIndex = 48
        Me.nudDolar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(270, 518)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(65, 13)
        Me.Label23.TabIndex = 49
        Me.Label23.Text = "Base Dólar :"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelTotal
        '
        Me.LabelTotal.BackColor = System.Drawing.Color.LightGreen
        Me.LabelTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelTotal.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LabelTotal.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotal.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelTotal.Location = New System.Drawing.Point(0, 590)
        Me.LabelTotal.Name = "LabelTotal"
        Me.LabelTotal.Size = New System.Drawing.Size(878, 25)
        Me.LabelTotal.TabIndex = 27
        Me.LabelTotal.Text = "0.0"
        Me.LabelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxSubtotal
        '
        Me.TextBoxSubtotal.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxSubtotal.Location = New System.Drawing.Point(548, 511)
        Me.TextBoxSubtotal.Name = "TextBoxSubtotal"
        Me.TextBoxSubtotal.ReadOnly = True
        Me.TextBoxSubtotal.Size = New System.Drawing.Size(125, 20)
        Me.TextBoxSubtotal.TabIndex = 6
        Me.TextBoxSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBoxTotal
        '
        Me.TextBoxTotal.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxTotal.Location = New System.Drawing.Point(752, 563)
        Me.TextBoxTotal.Name = "TextBoxTotal"
        Me.TextBoxTotal.ReadOnly = True
        Me.TextBoxTotal.Size = New System.Drawing.Size(125, 20)
        Me.TextBoxTotal.TabIndex = 9
        Me.TextBoxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBoxNogravado
        '
        Me.TextBoxNogravado.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxNogravado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxNogravado.Location = New System.Drawing.Point(752, 537)
        Me.TextBoxNogravado.Name = "TextBoxNogravado"
        Me.TextBoxNogravado.ReadOnly = True
        Me.TextBoxNogravado.Size = New System.Drawing.Size(125, 20)
        Me.TextBoxNogravado.TabIndex = 8
        Me.TextBoxNogravado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBoxExento
        '
        Me.TextBoxExento.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxExento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxExento.Location = New System.Drawing.Point(752, 511)
        Me.TextBoxExento.Name = "TextBoxExento"
        Me.TextBoxExento.ReadOnly = True
        Me.TextBoxExento.Size = New System.Drawing.Size(125, 20)
        Me.TextBoxExento.TabIndex = 8
        Me.TextBoxExento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBoxIVAFacturado
        '
        Me.TextBoxIVAFacturado.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxIVAFacturado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxIVAFacturado.Location = New System.Drawing.Point(548, 563)
        Me.TextBoxIVAFacturado.Name = "TextBoxIVAFacturado"
        Me.TextBoxIVAFacturado.ReadOnly = True
        Me.TextBoxIVAFacturado.Size = New System.Drawing.Size(125, 20)
        Me.TextBoxIVAFacturado.TabIndex = 8
        Me.TextBoxIVAFacturado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(681, 540)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(65, 13)
        Me.Label25.TabIndex = 26
        Me.Label25.Text = "No Gravado"
        '
        'TextBoxOtrosTributos
        '
        Me.TextBoxOtrosTributos.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxOtrosTributos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxOtrosTributos.Location = New System.Drawing.Point(548, 537)
        Me.TextBoxOtrosTributos.Name = "TextBoxOtrosTributos"
        Me.TextBoxOtrosTributos.ReadOnly = True
        Me.TextBoxOtrosTributos.Size = New System.Drawing.Size(125, 20)
        Me.TextBoxOtrosTributos.TabIndex = 7
        Me.TextBoxOtrosTributos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblExento
        '
        Me.lblExento.AutoSize = True
        Me.lblExento.Location = New System.Drawing.Point(706, 514)
        Me.lblExento.Name = "lblExento"
        Me.lblExento.Size = New System.Drawing.Size(40, 13)
        Me.lblExento.TabIndex = 26
        Me.lblExento.Text = "Exento"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(699, 566)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(47, 13)
        Me.lblTotal.TabIndex = 25
        Me.lblTotal.Text = "TOTAL"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(467, 566)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 13)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "IVA Facturado"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(468, 514)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(74, 13)
        Me.Label18.TabIndex = 23
        Me.Label18.Text = "Neto Gravado"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(469, 540)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Otros Tributos"
        '
        'GroupBoxComprobante
        '
        Me.GroupBoxComprobante.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBoxComprobante.Controls.Add(Me.ComboBoxTipoCbte)
        Me.GroupBoxComprobante.Controls.Add(Me.TextBoxNumero)
        Me.GroupBoxComprobante.Controls.Add(Me.ComboBoxPtoVta)
        Me.GroupBoxComprobante.Controls.Add(Me.Label9)
        Me.GroupBoxComprobante.Controls.Add(Me.DateTimePickerFecha)
        Me.GroupBoxComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxComprobante.Location = New System.Drawing.Point(9, 146)
        Me.GroupBoxComprobante.Name = "GroupBoxComprobante"
        Me.GroupBoxComprobante.Size = New System.Drawing.Size(297, 81)
        Me.GroupBoxComprobante.TabIndex = 1
        Me.GroupBoxComprobante.TabStop = False
        Me.GroupBoxComprobante.Text = "Tipo de comprobante y Nº"
        '
        'ComboBoxTipoCbte
        '
        Me.ComboBoxTipoCbte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxTipoCbte.DropDownWidth = 250
        Me.ComboBoxTipoCbte.FormattingEnabled = True
        Me.ComboBoxTipoCbte.Location = New System.Drawing.Point(6, 22)
        Me.ComboBoxTipoCbte.Name = "ComboBoxTipoCbte"
        Me.ComboBoxTipoCbte.Size = New System.Drawing.Size(144, 21)
        Me.ComboBoxTipoCbte.TabIndex = 0
        '
        'TextBoxNumero
        '
        Me.TextBoxNumero.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxNumero.Location = New System.Drawing.Point(221, 22)
        Me.TextBoxNumero.Name = "TextBoxNumero"
        Me.TextBoxNumero.ReadOnly = True
        Me.TextBoxNumero.Size = New System.Drawing.Size(70, 20)
        Me.TextBoxNumero.TabIndex = 2
        Me.TextBoxNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ComboBoxPtoVta
        '
        Me.ComboBoxPtoVta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxPtoVta.FormattingEnabled = True
        Me.ComboBoxPtoVta.Location = New System.Drawing.Point(156, 22)
        Me.ComboBoxPtoVta.Name = "ComboBoxPtoVta"
        Me.ComboBoxPtoVta.Size = New System.Drawing.Size(59, 21)
        Me.ComboBoxPtoVta.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(146, 53)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Fecha"
        '
        'DateTimePickerFecha
        '
        Me.DateTimePickerFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerFecha.Location = New System.Drawing.Point(189, 49)
        Me.DateTimePickerFecha.Name = "DateTimePickerFecha"
        Me.DateTimePickerFecha.Size = New System.Drawing.Size(102, 20)
        Me.DateTimePickerFecha.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBoxCAEVto)
        Me.GroupBox1.Controls.Add(Me.TextBoxCAE)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 511)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(252, 75)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Autorizacíon AFIP"
        '
        'TextBoxCAEVto
        '
        Me.TextBoxCAEVto.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxCAEVto.Location = New System.Drawing.Point(74, 46)
        Me.TextBoxCAEVto.Name = "TextBoxCAEVto"
        Me.TextBoxCAEVto.ReadOnly = True
        Me.TextBoxCAEVto.Size = New System.Drawing.Size(151, 20)
        Me.TextBoxCAEVto.TabIndex = 1
        '
        'TextBoxCAE
        '
        Me.TextBoxCAE.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxCAE.Location = New System.Drawing.Point(74, 19)
        Me.TextBoxCAE.Name = "TextBoxCAE"
        Me.TextBoxCAE.ReadOnly = True
        Me.TextBoxCAE.Size = New System.Drawing.Size(151, 20)
        Me.TextBoxCAE.TabIndex = 0
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(12, 52)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(50, 13)
        Me.Label15.TabIndex = 3
        Me.Label15.Text = "Vto. CAE"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(34, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(28, 13)
        Me.Label14.TabIndex = 3
        Me.Label14.Text = "CAE"
        '
        'GroupBoxPeriodo
        '
        Me.GroupBoxPeriodo.Controls.Add(Me.DateTimePickerPeriodoDesde)
        Me.GroupBoxPeriodo.Controls.Add(Me.DateTimePickerVto)
        Me.GroupBoxPeriodo.Controls.Add(Me.DateTimePickerPeriodoHasta)
        Me.GroupBoxPeriodo.Controls.Add(Me.Label12)
        Me.GroupBoxPeriodo.Controls.Add(Me.Label11)
        Me.GroupBoxPeriodo.Controls.Add(Me.Label10)
        Me.GroupBoxPeriodo.Location = New System.Drawing.Point(588, 146)
        Me.GroupBoxPeriodo.Name = "GroupBoxPeriodo"
        Me.GroupBoxPeriodo.Size = New System.Drawing.Size(289, 81)
        Me.GroupBoxPeriodo.TabIndex = 3
        Me.GroupBoxPeriodo.TabStop = False
        Me.GroupBoxPeriodo.Text = "Período Facturado"
        '
        'DateTimePickerPeriodoDesde
        '
        Me.DateTimePickerPeriodoDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerPeriodoDesde.Location = New System.Drawing.Point(50, 22)
        Me.DateTimePickerPeriodoDesde.Name = "DateTimePickerPeriodoDesde"
        Me.DateTimePickerPeriodoDesde.Size = New System.Drawing.Size(89, 20)
        Me.DateTimePickerPeriodoDesde.TabIndex = 13
        '
        'DateTimePickerVto
        '
        Me.DateTimePickerVto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerVto.Location = New System.Drawing.Point(188, 49)
        Me.DateTimePickerVto.Name = "DateTimePickerVto"
        Me.DateTimePickerVto.Size = New System.Drawing.Size(90, 20)
        Me.DateTimePickerVto.TabIndex = 13
        '
        'DateTimePickerPeriodoHasta
        '
        Me.DateTimePickerPeriodoHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerPeriodoHasta.Location = New System.Drawing.Point(188, 21)
        Me.DateTimePickerPeriodoHasta.Name = "DateTimePickerPeriodoHasta"
        Me.DateTimePickerPeriodoHasta.Size = New System.Drawing.Size(90, 20)
        Me.DateTimePickerPeriodoHasta.TabIndex = 13
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(93, 53)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(89, 13)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "Vto. para el Pago"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(147, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 13)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Hasta"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Desde"
        '
        'GroupBoxConceptos
        '
        Me.GroupBoxConceptos.Controls.Add(Me.ComboBoxConceptos)
        Me.GroupBoxConceptos.Controls.Add(Me.ComboBoxFormaPago)
        Me.GroupBoxConceptos.Controls.Add(Me.Label21)
        Me.GroupBoxConceptos.Controls.Add(Me.Label13)
        Me.GroupBoxConceptos.Location = New System.Drawing.Point(312, 146)
        Me.GroupBoxConceptos.Name = "GroupBoxConceptos"
        Me.GroupBoxConceptos.Size = New System.Drawing.Size(270, 80)
        Me.GroupBoxConceptos.TabIndex = 2
        Me.GroupBoxConceptos.TabStop = False
        Me.GroupBoxConceptos.Text = "Conceptos a incluir / Forma de Pago"
        '
        'ComboBoxConceptos
        '
        Me.ComboBoxConceptos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxConceptos.DropDownWidth = 250
        Me.ComboBoxConceptos.FormattingEnabled = True
        Me.ComboBoxConceptos.Location = New System.Drawing.Point(113, 22)
        Me.ComboBoxConceptos.Name = "ComboBoxConceptos"
        Me.ComboBoxConceptos.Size = New System.Drawing.Size(151, 21)
        Me.ComboBoxConceptos.TabIndex = 0
        '
        'ComboBoxFormaPago
        '
        Me.ComboBoxFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxFormaPago.DropDownWidth = 250
        Me.ComboBoxFormaPago.FormattingEnabled = True
        Me.ComboBoxFormaPago.Location = New System.Drawing.Point(113, 48)
        Me.ComboBoxFormaPago.Name = "ComboBoxFormaPago"
        Me.ComboBoxFormaPago.Size = New System.Drawing.Size(151, 21)
        Me.ComboBoxFormaPago.TabIndex = 10
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(54, 25)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(53, 13)
        Me.Label21.TabIndex = 3
        Me.Label21.Text = "Concepto"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(28, 53)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 13)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Forma de Pago"
        '
        'GroupBoxDatosCliente
        '
        Me.GroupBoxDatosCliente.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBoxDatosCliente.Controls.Add(Me.ComboBoxDomicilios)
        Me.GroupBoxDatosCliente.Controls.Add(Me.ComboBoxCliente)
        Me.GroupBoxDatosCliente.Controls.Add(Me.TextBoxDomicilio)
        Me.GroupBoxDatosCliente.Controls.Add(Me.TextBoxNombre)
        Me.GroupBoxDatosCliente.Controls.Add(Me.TextBoxDescuentoGral)
        Me.GroupBoxDatosCliente.Controls.Add(Me.TextBoxDocumento)
        Me.GroupBoxDatosCliente.Controls.Add(Me.ComboBoxResponsabilidadIVA)
        Me.GroupBoxDatosCliente.Controls.Add(Me.ComboBoxDocumento)
        Me.GroupBoxDatosCliente.Controls.Add(Me.Label20)
        Me.GroupBoxDatosCliente.Controls.Add(Me.Label2)
        Me.GroupBoxDatosCliente.Controls.Add(Me.Label4)
        Me.GroupBoxDatosCliente.Controls.Add(Me.Label19)
        Me.GroupBoxDatosCliente.Controls.Add(Me.Label16)
        Me.GroupBoxDatosCliente.Controls.Add(Me.Label3)
        Me.GroupBoxDatosCliente.Controls.Add(Me.Label6)
        Me.GroupBoxDatosCliente.Controls.Add(Me.Label1)
        Me.GroupBoxDatosCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBoxDatosCliente.Location = New System.Drawing.Point(9, 3)
        Me.GroupBoxDatosCliente.Name = "GroupBoxDatosCliente"
        Me.GroupBoxDatosCliente.Size = New System.Drawing.Size(868, 137)
        Me.GroupBoxDatosCliente.TabIndex = 0
        Me.GroupBoxDatosCliente.TabStop = False
        Me.GroupBoxDatosCliente.Text = "Cliente:"
        '
        'ComboBoxDomicilios
        '
        Me.ComboBoxDomicilios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDomicilios.FormattingEnabled = True
        Me.ComboBoxDomicilios.Location = New System.Drawing.Point(74, 72)
        Me.ComboBoxDomicilios.Name = "ComboBoxDomicilios"
        Me.ComboBoxDomicilios.Size = New System.Drawing.Size(336, 21)
        Me.ComboBoxDomicilios.TabIndex = 6
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
        Me.ComboBoxCliente.Location = New System.Drawing.Point(74, 14)
        Me.ComboBoxCliente.MaximumSize = New System.Drawing.Size(500, 25)
        Me.ComboBoxCliente.MinimumSize = New System.Drawing.Size(200, 25)
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
        Me.TextBoxDomicilio.Location = New System.Drawing.Point(74, 99)
        Me.TextBoxDomicilio.MaxLength = 255
        Me.TextBoxDomicilio.Multiline = True
        Me.TextBoxDomicilio.Name = "TextBoxDomicilio"
        Me.TextBoxDomicilio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxDomicilio.Size = New System.Drawing.Size(336, 25)
        Me.TextBoxDomicilio.TabIndex = 7
        '
        'TextBoxNombre
        '
        Me.TextBoxNombre.Location = New System.Drawing.Point(540, 46)
        Me.TextBoxNombre.MaxLength = 80
        Me.TextBoxNombre.Name = "TextBoxNombre"
        Me.TextBoxNombre.Size = New System.Drawing.Size(317, 20)
        Me.TextBoxNombre.TabIndex = 3
        '
        'TextBoxDescuentoGral
        '
        Me.TextBoxDescuentoGral.Location = New System.Drawing.Point(784, 16)
        Me.TextBoxDescuentoGral.MaxLength = 11
        Me.TextBoxDescuentoGral.Name = "TextBoxDescuentoGral"
        Me.TextBoxDescuentoGral.Size = New System.Drawing.Size(51, 20)
        Me.TextBoxDescuentoGral.TabIndex = 1
        Me.TextBoxDescuentoGral.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxDocumento
        '
        Me.TextBoxDocumento.Location = New System.Drawing.Point(174, 46)
        Me.TextBoxDocumento.MaxLength = 11
        Me.TextBoxDocumento.Name = "TextBoxDocumento"
        Me.TextBoxDocumento.Size = New System.Drawing.Size(236, 20)
        Me.TextBoxDocumento.TabIndex = 2
        Me.TextBoxDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ComboBoxResponsabilidadIVA
        '
        Me.ComboBoxResponsabilidadIVA.FormattingEnabled = True
        Me.ComboBoxResponsabilidadIVA.Location = New System.Drawing.Point(540, 72)
        Me.ComboBoxResponsabilidadIVA.Name = "ComboBoxResponsabilidadIVA"
        Me.ComboBoxResponsabilidadIVA.Size = New System.Drawing.Size(317, 21)
        Me.ComboBoxResponsabilidadIVA.TabIndex = 4
        '
        'ComboBoxDocumento
        '
        Me.ComboBoxDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDocumento.DropDownWidth = 235
        Me.ComboBoxDocumento.FormattingEnabled = True
        Me.ComboBoxDocumento.Location = New System.Drawing.Point(74, 46)
        Me.ComboBoxDocumento.Name = "ComboBoxDocumento"
        Me.ComboBoxDocumento.Size = New System.Drawing.Size(94, 21)
        Me.ComboBoxDocumento.TabIndex = 1
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(14, 75)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(54, 13)
        Me.Label20.TabIndex = 3
        Me.Label20.Text = "Domicilios"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Domicilio F."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(429, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Responsabilidad IVA"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(841, 19)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(16, 13)
        Me.Label19.TabIndex = 3
        Me.Label19.Text = "%"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(679, 19)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(99, 13)
        Me.Label16.TabIndex = 3
        Me.Label16.Text = "Descuento Gral."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(416, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Nombre / Razón Social"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(22, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Cliente"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Documento"
        '
        'FormCbteVentaKiosco
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(884, 651)
        Me.Controls.Add(Me.TableLayoutPanelBase)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximumSize = New System.Drawing.Size(900, 690)
        Me.MinimumSize = New System.Drawing.Size(900, 400)
        Me.Name = "FormCbteVentaKiosco"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormCbteElectronico"
        Me.TableLayoutPanelBase.ResumeLayout(False)
        Me.TableLayoutPanelBase.PerformLayout()
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.PanelControles.ResumeLayout(False)
        Me.PanelControles.PerformLayout()
        CType(Me.nudDolar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxComprobante.ResumeLayout(False)
        Me.GroupBoxComprobante.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBoxPeriodo.ResumeLayout(False)
        Me.GroupBoxPeriodo.PerformLayout()
        Me.GroupBoxConceptos.ResumeLayout(False)
        Me.GroupBoxConceptos.PerformLayout()
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
    Friend WithEvents ComboBoxDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextBoxNumero As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxPtoVta As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxTipoCbte As System.Windows.Forms.ComboBox
    Friend WithEvents TextBoxNombre As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxResponsabilidadIVA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxPeriodo As System.Windows.Forms.GroupBox
    Friend WithEvents DateTimePickerPeriodoDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePickerVto As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePickerPeriodoHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxConceptos As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBoxFormaPago As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxCAE As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxComprobante As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxSubtotal As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxTotal As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxIVAFacturado As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxOtrosTributos As System.Windows.Forms.TextBox
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxConceptos As System.Windows.Forms.ComboBox
    Friend WithEvents TextBoxCAEVto As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripButtonAutorizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TextBoxNogravado As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxExento As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents lblExento As System.Windows.Forms.Label
    Friend WithEvents ComboBoxCliente As Principal.CtlCustomCombo
    Friend WithEvents LabelTotal As System.Windows.Forms.Label
    Friend WithEvents TextBoxDescuentoGral As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxDomicilios As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ToolStripButtonProforma As System.Windows.Forms.ToolStripButton
    Private WithEvents nudDolar As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TextBoxDomicilio As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CtlCbteDetalle As CtlDetalleCbte2
End Class
