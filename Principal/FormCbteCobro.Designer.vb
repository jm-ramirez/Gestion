<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCbteCobro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCbteCobro))
        Me.TableLayoutPanelBase = New System.Windows.Forms.TableLayoutPanel()
        Me.ToolStripMenu = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonAutorizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonVarios = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabelStatus = New System.Windows.Forms.ToolStripLabel()
        Me.PanelControles = New System.Windows.Forms.Panel()
        Me.LabelTotal = New System.Windows.Forms.Label()
        Me.GroupBoxImporte = New System.Windows.Forms.GroupBox()
        Me.TextBoxImporteRecibido = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CtlCbteDetalle = New Principal.CtlDetalleCbte()
        Me.TextBoxSinAplicar = New System.Windows.Forms.TextBox()
        Me.TextBoxTotal = New System.Windows.Forms.TextBox()
        Me.TextBoxCartera = New System.Windows.Forms.TextBox()
        Me.TextBoxCtasPropias = New System.Windows.Forms.TextBox()
        Me.TextBoxAplicado = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TextBoxOtrosTributos = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBoxComprobante = New System.Windows.Forms.GroupBox()
        Me.ComboBoxTipoCbte = New System.Windows.Forms.ComboBox()
        Me.TextBoxNumero = New System.Windows.Forms.TextBox()
        Me.ComboBoxPtoVta = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DateTimePickerFecha = New System.Windows.Forms.DateTimePicker()
        Me.GroupBoxDatosCliente = New System.Windows.Forms.GroupBox()
        Me.LabelAnticipo = New System.Windows.Forms.Label()
        Me.ComboBoxVendedor = New Principal.CtlCustomCombo()
        Me.ComboBoxCliente = New Principal.CtlCustomCombo()
        Me.TextBoxDomicilio = New System.Windows.Forms.TextBox()
        Me.TextBoxNombre = New System.Windows.Forms.TextBox()
        Me.TextBoxDocumento = New System.Windows.Forms.TextBox()
        Me.ComboBoxResponsabilidadIVA = New System.Windows.Forms.ComboBox()
        Me.ComboBoxDocumento = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanelBase.SuspendLayout()
        Me.ToolStripMenu.SuspendLayout()
        Me.PanelControles.SuspendLayout()
        Me.GroupBoxImporte.SuspendLayout()
        Me.GroupBoxComprobante.SuspendLayout()
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
        Me.TableLayoutPanelBase.Size = New System.Drawing.Size(892, 663)
        Me.TableLayoutPanelBase.TabIndex = 0
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonAutorizar, Me.ToolStripButtonVarios, Me.ToolStripButtonCancelar, Me.ToolStripSeparator1, Me.ToolStripLabelStatus})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStripMenu.Size = New System.Drawing.Size(892, 25)
        Me.ToolStripMenu.TabIndex = 0
        Me.ToolStripMenu.Text = "ToolStrip1"
        '
        'ToolStripButtonAutorizar
        '
        Me.ToolStripButtonAutorizar.Image = Global.Principal.My.Resources.Resources.server_go
        Me.ToolStripButtonAutorizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonAutorizar.Name = "ToolStripButtonAutorizar"
        Me.ToolStripButtonAutorizar.Size = New System.Drawing.Size(130, 22)
        Me.ToolStripButtonAutorizar.Text = "Autorizar Cbte. [F12]"
        Me.ToolStripButtonAutorizar.ToolTipText = "Autorizar Cbte. [F12]"
        '
        'ToolStripButtonVarios
        '
        Me.ToolStripButtonVarios.Image = Global.Principal.My.Resources.Resources.money_add
        Me.ToolStripButtonVarios.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonVarios.Name = "ToolStripButtonVarios"
        Me.ToolStripButtonVarios.Size = New System.Drawing.Size(116, 22)
        Me.ToolStripButtonVarios.Text = "Cobros Varios [F5]"
        '
        'ToolStripButtonCancelar
        '
        Me.ToolStripButtonCancelar.Image = Global.Principal.My.Resources.Resources.cancel
        Me.ToolStripButtonCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonCancelar.Name = "ToolStripButtonCancelar"
        Me.ToolStripButtonCancelar.Size = New System.Drawing.Size(96, 22)
        Me.ToolStripButtonCancelar.Text = "Cancelar [Esc]"
        Me.ToolStripButtonCancelar.ToolTipText = "Cancelar [Esc]"
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
        Me.PanelControles.Controls.Add(Me.GroupBoxImporte)
        Me.PanelControles.Controls.Add(Me.CtlCbteDetalle)
        Me.PanelControles.Controls.Add(Me.TextBoxSinAplicar)
        Me.PanelControles.Controls.Add(Me.TextBoxTotal)
        Me.PanelControles.Controls.Add(Me.TextBoxCartera)
        Me.PanelControles.Controls.Add(Me.TextBoxCtasPropias)
        Me.PanelControles.Controls.Add(Me.TextBoxAplicado)
        Me.PanelControles.Controls.Add(Me.Label25)
        Me.PanelControles.Controls.Add(Me.TextBoxOtrosTributos)
        Me.PanelControles.Controls.Add(Me.Label24)
        Me.PanelControles.Controls.Add(Me.Label17)
        Me.PanelControles.Controls.Add(Me.Label8)
        Me.PanelControles.Controls.Add(Me.Label18)
        Me.PanelControles.Controls.Add(Me.Label7)
        Me.PanelControles.Controls.Add(Me.GroupBoxComprobante)
        Me.PanelControles.Controls.Add(Me.GroupBoxDatosCliente)
        Me.PanelControles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControles.Location = New System.Drawing.Point(3, 33)
        Me.PanelControles.Name = "PanelControles"
        Me.PanelControles.Size = New System.Drawing.Size(886, 627)
        Me.PanelControles.TabIndex = 2
        '
        'LabelTotal
        '
        Me.LabelTotal.BackColor = System.Drawing.Color.LightGreen
        Me.LabelTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelTotal.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LabelTotal.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotal.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelTotal.Location = New System.Drawing.Point(0, 602)
        Me.LabelTotal.Name = "LabelTotal"
        Me.LabelTotal.Size = New System.Drawing.Size(886, 25)
        Me.LabelTotal.TabIndex = 28
        Me.LabelTotal.Text = "0.0"
        Me.LabelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBoxImporte
        '
        Me.GroupBoxImporte.Controls.Add(Me.TextBoxImporteRecibido)
        Me.GroupBoxImporte.Controls.Add(Me.Label10)
        Me.GroupBoxImporte.Location = New System.Drawing.Point(448, 146)
        Me.GroupBoxImporte.Name = "GroupBoxImporte"
        Me.GroupBoxImporte.Size = New System.Drawing.Size(329, 81)
        Me.GroupBoxImporte.TabIndex = 2
        Me.GroupBoxImporte.TabStop = False
        Me.GroupBoxImporte.Text = "Importe"
        '
        'TextBoxImporteRecibido
        '
        Me.TextBoxImporteRecibido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxImporteRecibido.Location = New System.Drawing.Point(109, 45)
        Me.TextBoxImporteRecibido.Name = "TextBoxImporteRecibido"
        Me.TextBoxImporteRecibido.Size = New System.Drawing.Size(129, 22)
        Me.TextBoxImporteRecibido.TabIndex = 0
        Me.TextBoxImporteRecibido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.LightGreen
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label10.Location = New System.Drawing.Point(109, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(129, 19)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "TOTAL"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.CtlCbteDetalle.DescuentoGral = 0.0R
        Me.CtlCbteDetalle.FechaComprobante = New Date(2018, 2, 23, 0, 0, 0, 0)
        Me.CtlCbteDetalle.ListaDePrecio = Principal.CtlDetalleCbte.ListaPrecios.LISTA1
        Me.CtlCbteDetalle.Location = New System.Drawing.Point(9, 233)
        Me.CtlCbteDetalle.MaximoItems = CType(25US, UShort)
        Me.CtlCbteDetalle.Name = "CtlCbteDetalle"
        Me.CtlCbteDetalle.Proveedor = Nothing
        Me.CtlCbteDetalle.Size = New System.Drawing.Size(868, 272)
        Me.CtlCbteDetalle.TabIndex = 4
        Me.CtlCbteDetalle.TipoCargaCbte = Principal.General.TipoEmisionCbte.ELECTRONICO
        Me.CtlCbteDetalle.TipoDeCbte = Principal.CtlDetalleCbte.TipoCbte.CBTEVTA
        Me.CtlCbteDetalle.Vendedor = Nothing
        Me.CtlCbteDetalle.VerCuentaCta = False
        '
        'TextBoxSinAplicar
        '
        Me.TextBoxSinAplicar.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxSinAplicar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxSinAplicar.Location = New System.Drawing.Point(542, 511)
        Me.TextBoxSinAplicar.Name = "TextBoxSinAplicar"
        Me.TextBoxSinAplicar.ReadOnly = True
        Me.TextBoxSinAplicar.Size = New System.Drawing.Size(125, 20)
        Me.TextBoxSinAplicar.TabIndex = 6
        Me.TextBoxSinAplicar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBoxTotal
        '
        Me.TextBoxTotal.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxTotal.Location = New System.Drawing.Point(746, 563)
        Me.TextBoxTotal.Name = "TextBoxTotal"
        Me.TextBoxTotal.ReadOnly = True
        Me.TextBoxTotal.Size = New System.Drawing.Size(125, 20)
        Me.TextBoxTotal.TabIndex = 9
        Me.TextBoxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBoxCartera
        '
        Me.TextBoxCartera.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxCartera.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCartera.Location = New System.Drawing.Point(746, 537)
        Me.TextBoxCartera.Name = "TextBoxCartera"
        Me.TextBoxCartera.ReadOnly = True
        Me.TextBoxCartera.Size = New System.Drawing.Size(125, 20)
        Me.TextBoxCartera.TabIndex = 8
        Me.TextBoxCartera.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBoxCtasPropias
        '
        Me.TextBoxCtasPropias.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxCtasPropias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCtasPropias.Location = New System.Drawing.Point(746, 511)
        Me.TextBoxCtasPropias.Name = "TextBoxCtasPropias"
        Me.TextBoxCtasPropias.ReadOnly = True
        Me.TextBoxCtasPropias.Size = New System.Drawing.Size(125, 20)
        Me.TextBoxCtasPropias.TabIndex = 8
        Me.TextBoxCtasPropias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBoxAplicado
        '
        Me.TextBoxAplicado.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxAplicado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxAplicado.Location = New System.Drawing.Point(542, 563)
        Me.TextBoxAplicado.Name = "TextBoxAplicado"
        Me.TextBoxAplicado.ReadOnly = True
        Me.TextBoxAplicado.Size = New System.Drawing.Size(125, 20)
        Me.TextBoxAplicado.TabIndex = 8
        Me.TextBoxAplicado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(699, 540)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(41, 13)
        Me.Label25.TabIndex = 26
        Me.Label25.Text = "Cartera"
        '
        'TextBoxOtrosTributos
        '
        Me.TextBoxOtrosTributos.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxOtrosTributos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxOtrosTributos.Location = New System.Drawing.Point(542, 537)
        Me.TextBoxOtrosTributos.Name = "TextBoxOtrosTributos"
        Me.TextBoxOtrosTributos.ReadOnly = True
        Me.TextBoxOtrosTributos.Size = New System.Drawing.Size(125, 20)
        Me.TextBoxOtrosTributos.TabIndex = 7
        Me.TextBoxOtrosTributos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(671, 514)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(69, 13)
        Me.Label24.TabIndex = 26
        Me.Label24.Text = "Ctas. Propias"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(693, 566)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(47, 13)
        Me.Label17.TabIndex = 25
        Me.Label17.Text = "TOTAL"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(446, 566)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 13)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Aplicado a Cbtes."
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(479, 514)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(57, 13)
        Me.Label18.TabIndex = 23
        Me.Label18.Text = "Sin Aplicar"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(463, 540)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Otros Tributos"
        '
        'GroupBoxComprobante
        '
        Me.GroupBoxComprobante.Controls.Add(Me.ComboBoxTipoCbte)
        Me.GroupBoxComprobante.Controls.Add(Me.TextBoxNumero)
        Me.GroupBoxComprobante.Controls.Add(Me.ComboBoxPtoVta)
        Me.GroupBoxComprobante.Controls.Add(Me.Label9)
        Me.GroupBoxComprobante.Controls.Add(Me.DateTimePickerFecha)
        Me.GroupBoxComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxComprobante.Location = New System.Drawing.Point(9, 146)
        Me.GroupBoxComprobante.Name = "GroupBoxComprobante"
        Me.GroupBoxComprobante.Size = New System.Drawing.Size(433, 81)
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
        Me.ComboBoxTipoCbte.Size = New System.Drawing.Size(178, 21)
        Me.ComboBoxTipoCbte.TabIndex = 0
        '
        'TextBoxNumero
        '
        Me.TextBoxNumero.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxNumero.Location = New System.Drawing.Point(255, 23)
        Me.TextBoxNumero.Name = "TextBoxNumero"
        Me.TextBoxNumero.ReadOnly = True
        Me.TextBoxNumero.Size = New System.Drawing.Size(101, 20)
        Me.TextBoxNumero.TabIndex = 2
        Me.TextBoxNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ComboBoxPtoVta
        '
        Me.ComboBoxPtoVta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxPtoVta.FormattingEnabled = True
        Me.ComboBoxPtoVta.Location = New System.Drawing.Point(190, 22)
        Me.ComboBoxPtoVta.Name = "ComboBoxPtoVta"
        Me.ComboBoxPtoVta.Size = New System.Drawing.Size(59, 21)
        Me.ComboBoxPtoVta.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(211, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Fecha"
        '
        'DateTimePickerFecha
        '
        Me.DateTimePickerFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerFecha.Location = New System.Drawing.Point(255, 50)
        Me.DateTimePickerFecha.Name = "DateTimePickerFecha"
        Me.DateTimePickerFecha.Size = New System.Drawing.Size(101, 20)
        Me.DateTimePickerFecha.TabIndex = 3
        '
        'GroupBoxDatosCliente
        '
        Me.GroupBoxDatosCliente.Controls.Add(Me.LabelAnticipo)
        Me.GroupBoxDatosCliente.Controls.Add(Me.ComboBoxVendedor)
        Me.GroupBoxDatosCliente.Controls.Add(Me.ComboBoxCliente)
        Me.GroupBoxDatosCliente.Controls.Add(Me.TextBoxDomicilio)
        Me.GroupBoxDatosCliente.Controls.Add(Me.TextBoxNombre)
        Me.GroupBoxDatosCliente.Controls.Add(Me.TextBoxDocumento)
        Me.GroupBoxDatosCliente.Controls.Add(Me.ComboBoxResponsabilidadIVA)
        Me.GroupBoxDatosCliente.Controls.Add(Me.ComboBoxDocumento)
        Me.GroupBoxDatosCliente.Controls.Add(Me.Label2)
        Me.GroupBoxDatosCliente.Controls.Add(Me.Label5)
        Me.GroupBoxDatosCliente.Controls.Add(Me.Label4)
        Me.GroupBoxDatosCliente.Controls.Add(Me.Label3)
        Me.GroupBoxDatosCliente.Controls.Add(Me.Label6)
        Me.GroupBoxDatosCliente.Controls.Add(Me.Label1)
        Me.GroupBoxDatosCliente.Location = New System.Drawing.Point(9, 3)
        Me.GroupBoxDatosCliente.Name = "GroupBoxDatosCliente"
        Me.GroupBoxDatosCliente.Size = New System.Drawing.Size(868, 137)
        Me.GroupBoxDatosCliente.TabIndex = 0
        Me.GroupBoxDatosCliente.TabStop = False
        Me.GroupBoxDatosCliente.Text = "Cliente:"
        '
        'LabelAnticipo
        '
        Me.LabelAnticipo.BackColor = System.Drawing.Color.Salmon
        Me.LabelAnticipo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAnticipo.ForeColor = System.Drawing.Color.DarkRed
        Me.LabelAnticipo.Location = New System.Drawing.Point(445, 14)
        Me.LabelAnticipo.Name = "LabelAnticipo"
        Me.LabelAnticipo.Size = New System.Drawing.Size(417, 25)
        Me.LabelAnticipo.TabIndex = 7
        Me.LabelAnticipo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBoxVendedor
        '
        Me.ComboBoxVendedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.ComboBoxVendedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.ComboBoxVendedor.BusquedaPorCodigobarra = False
        Me.ComboBoxVendedor.ColumnasExtras = Nothing
        Me.ComboBoxVendedor.CustomFormatArt = False
        Me.ComboBoxVendedor.DataSource = Nothing
        Me.ComboBoxVendedor.DisplayMember = Nothing
        Me.ComboBoxVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ComboBoxVendedor.FormularioDeAlta = Nothing
        Me.ComboBoxVendedor.FormularioDeBusqueda = Nothing
        Me.ComboBoxVendedor.Location = New System.Drawing.Point(545, 99)
        Me.ComboBoxVendedor.MaximumSize = New System.Drawing.Size(500, 25)
        Me.ComboBoxVendedor.MinimumSize = New System.Drawing.Size(200, 25)
        Me.ComboBoxVendedor.Name = "ComboBoxVendedor"
        Me.ComboBoxVendedor.SelectedIndex = -1
        Me.ComboBoxVendedor.SelectedItem = Nothing
        Me.ComboBoxVendedor.SelectedText = ""
        Me.ComboBoxVendedor.SelectedValue = Nothing
        Me.ComboBoxVendedor.Size = New System.Drawing.Size(317, 25)
        Me.ComboBoxVendedor.TabIndex = 5
        Me.ComboBoxVendedor.ValueMember = Nothing
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
        Me.TextBoxDomicilio.Location = New System.Drawing.Point(74, 73)
        Me.TextBoxDomicilio.MaxLength = 255
        Me.TextBoxDomicilio.Multiline = True
        Me.TextBoxDomicilio.Name = "TextBoxDomicilio"
        Me.TextBoxDomicilio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxDomicilio.Size = New System.Drawing.Size(341, 51)
        Me.TextBoxDomicilio.TabIndex = 6
        '
        'TextBoxNombre
        '
        Me.TextBoxNombre.Location = New System.Drawing.Point(545, 46)
        Me.TextBoxNombre.MaxLength = 80
        Me.TextBoxNombre.Name = "TextBoxNombre"
        Me.TextBoxNombre.Size = New System.Drawing.Size(317, 20)
        Me.TextBoxNombre.TabIndex = 3
        '
        'TextBoxDocumento
        '
        Me.TextBoxDocumento.Location = New System.Drawing.Point(174, 46)
        Me.TextBoxDocumento.MaxLength = 11
        Me.TextBoxDocumento.Name = "TextBoxDocumento"
        Me.TextBoxDocumento.Size = New System.Drawing.Size(241, 20)
        Me.TextBoxDocumento.TabIndex = 2
        Me.TextBoxDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ComboBoxResponsabilidadIVA
        '
        Me.ComboBoxResponsabilidadIVA.FormattingEnabled = True
        Me.ComboBoxResponsabilidadIVA.Location = New System.Drawing.Point(545, 72)
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Domicilio"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(478, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Vendedor"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(434, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Responsabilidad IVA"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(421, 49)
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
        'FormCbteCobro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 663)
        Me.Controls.Add(Me.TableLayoutPanelBase)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximumSize = New System.Drawing.Size(900, 690)
        Me.MinimumSize = New System.Drawing.Size(900, 690)
        Me.Name = "FormCbteCobro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormCbteElectronico"
        Me.TableLayoutPanelBase.ResumeLayout(False)
        Me.TableLayoutPanelBase.PerformLayout()
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.PanelControles.ResumeLayout(False)
        Me.PanelControles.PerformLayout()
        Me.GroupBoxImporte.ResumeLayout(False)
        Me.GroupBoxImporte.PerformLayout()
        Me.GroupBoxComprobante.ResumeLayout(False)
        Me.GroupBoxComprobante.PerformLayout()
        Me.GroupBoxDatosCliente.ResumeLayout(False)
        Me.GroupBoxDatosCliente.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanelBase As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabelStatus As System.Windows.Forms.ToolStripLabel
    Friend WithEvents PanelControles As System.Windows.Forms.Panel
    Friend WithEvents GroupBoxDatosCliente As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxDocumento As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextBoxNumero As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxPtoVta As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxTipoCbte As System.Windows.Forms.ComboBox
    Friend WithEvents TextBoxNombre As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxResponsabilidadIVA As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxComprobante As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxSinAplicar As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxTotal As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxAplicado As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxOtrosTributos As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ToolStripButtonAutorizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TextBoxCartera As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCtasPropias As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents CtlCbteDetalle As Principal.CtlDetalleCbte
    Friend WithEvents ComboBoxCliente As Principal.CtlCustomCombo
    Friend WithEvents ComboBoxVendedor As Principal.CtlCustomCombo
    Friend WithEvents GroupBoxImporte As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxImporteRecibido As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents LabelTotal As System.Windows.Forms.Label
    Friend WithEvents LabelAnticipo As System.Windows.Forms.Label
    Friend WithEvents ToolStripButtonVarios As System.Windows.Forms.ToolStripButton
End Class
