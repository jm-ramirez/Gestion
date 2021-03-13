<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormArticuloAnterior
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
        Me.components = New System.ComponentModel.Container()
        Me.ToolStripMenu = New System.Windows.Forms.ToolStrip()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBoxId = New System.Windows.Forms.TextBox()
        Me.TextBoxNombre = New System.Windows.Forms.TextBox()
        Me.TextBoxDescripcion = New System.Windows.Forms.TextBox()
        Me.CheckBoxActivo = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxCodigoBarra = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBoxPrecioVta = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TextBoxPtoMinimo = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextBoxCodigo = New System.Windows.Forms.TextBox()
        Me.CheckBoxOferta = New System.Windows.Forms.CheckBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TextBoxPrecioVta2 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TextBoxPrecioVta3 = New System.Windows.Forms.TextBox()
        Me.PanelTotales = New System.Windows.Forms.Panel()
        Me.lblFinalMostrador = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblFinalKiosko = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lblFinalRevendedor = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.PanelStock = New System.Windows.Forms.Panel()
        Me.lblExistenciaActual = New System.Windows.Forms.Label()
        Me.lblExistencia = New System.Windows.Forms.Label()
        Me.CheckBoxModifica = New System.Windows.Forms.CheckBox()
        Me.ToolTipAyuda = New System.Windows.Forms.ToolTip(Me.components)
        Me.TextBoxCoeficienteKilo = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.FileSystemWatcher1 = New System.IO.FileSystemWatcher()
        Me.ComboBoxUnidades = New Principal.CtlCustomCombo()
        Me.ComboBoxRubros = New Principal.CtlCustomCombo()
        Me.CtlComboCategoria = New Principal.CtlCustomCombo()
        Me.BtnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.BtnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.LabelSug1 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.LabelSug2 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.LabelSug3 = New System.Windows.Forms.Label()
        Me.TextBoxPrecioVtaSug = New System.Windows.Forms.TextBox()
        Me.TextBoxDescuento = New System.Windows.Forms.TextBox()
        Me.TextBoxRenta1 = New System.Windows.Forms.TextBox()
        Me.TextBoxDescuento2 = New System.Windows.Forms.TextBox()
        Me.TextBoxRenta2 = New System.Windows.Forms.TextBox()
        Me.TextBoxDescuento3 = New System.Windows.Forms.TextBox()
        Me.TextBoxRenta3 = New System.Windows.Forms.TextBox()
        Me.BtnDesglose = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBoxPrecioCosto = New System.Windows.Forms.TextBox()
        Me.BtnMargenes = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TextBoxPrecioCompra = New System.Windows.Forms.TextBox()
        Me.TextBoxDtoCompra1 = New System.Windows.Forms.TextBox()
        Me.TextBoxDtoCompra2 = New System.Windows.Forms.TextBox()
        Me.TextBoxDtoCompra3 = New System.Windows.Forms.TextBox()
        Me.TextBoxDtoCompra4 = New System.Windows.Forms.TextBox()
        Me.TextBoxCantidadBulto = New System.Windows.Forms.TextBox()
        Me.TextBoxImpuestoInterno = New System.Windows.Forms.TextBox()
        Me.TextBoxImpuestoInternoImp = New System.Windows.Forms.TextBox()
        Me.ComboBoxAlicuotas = New System.Windows.Forms.ComboBox()
        Me.DTPUltCompra = New System.Windows.Forms.DateTimePicker()
        Me.ToolStripMenu.SuspendLayout()
        Me.PanelTotales.SuspendLayout()
        Me.PanelStock.SuspendLayout()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnGuardar, Me.BtnCancelar})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(826, 25)
        Me.ToolStripMenu.TabIndex = 0
        Me.ToolStripMenu.Text = "ToolStrip1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(83, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Id"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(55, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Nombre"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(36, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Descripción"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(58, 259)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 13)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "Unidad"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxId
        '
        Me.TextBoxId.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxId.Location = New System.Drawing.Point(105, 42)
        Me.TextBoxId.Name = "TextBoxId"
        Me.TextBoxId.Size = New System.Drawing.Size(75, 20)
        Me.TextBoxId.TabIndex = 0
        Me.TextBoxId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxNombre
        '
        Me.TextBoxNombre.Location = New System.Drawing.Point(105, 97)
        Me.TextBoxNombre.Name = "TextBoxNombre"
        Me.TextBoxNombre.Size = New System.Drawing.Size(356, 20)
        Me.TextBoxNombre.TabIndex = 3
        '
        'TextBoxDescripcion
        '
        Me.TextBoxDescripcion.Location = New System.Drawing.Point(105, 123)
        Me.TextBoxDescripcion.Multiline = True
        Me.TextBoxDescripcion.Name = "TextBoxDescripcion"
        Me.TextBoxDescripcion.Size = New System.Drawing.Size(356, 60)
        Me.TextBoxDescripcion.TabIndex = 4
        '
        'CheckBoxActivo
        '
        Me.CheckBoxActivo.AutoSize = True
        Me.CheckBoxActivo.Location = New System.Drawing.Point(197, 42)
        Me.CheckBoxActivo.Name = "CheckBoxActivo"
        Me.CheckBoxActivo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBoxActivo.Size = New System.Drawing.Size(56, 17)
        Me.CheckBoxActivo.TabIndex = 3
        Me.CheckBoxActivo.TabStop = False
        Me.CheckBoxActivo.Text = "Activo"
        Me.CheckBoxActivo.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(63, 226)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Rubro"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(231, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Código de barras"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxCodigoBarra
        '
        Me.TextBoxCodigoBarra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCodigoBarra.Location = New System.Drawing.Point(324, 71)
        Me.TextBoxCodigoBarra.MaxLength = 13
        Me.TextBoxCodigoBarra.Name = "TextBoxCodigoBarra"
        Me.TextBoxCodigoBarra.Size = New System.Drawing.Size(137, 20)
        Me.TextBoxCodigoBarra.TabIndex = 2
        Me.TextBoxCodigoBarra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(39, 416)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 58
        Me.Label5.Text = "Básico [ 1 ]"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxPrecioVta
        '
        Me.TextBoxPrecioVta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPrecioVta.Location = New System.Drawing.Point(105, 413)
        Me.TextBoxPrecioVta.MaxLength = 13
        Me.TextBoxPrecioVta.Name = "TextBoxPrecioVta"
        Me.TextBoxPrecioVta.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxPrecioVta.TabIndex = 21
        Me.TextBoxPrecioVta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(45, 195)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 13)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "Categoría"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(35, 494)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(64, 13)
        Me.Label16.TabIndex = 79
        Me.Label16.Text = "Pto. Mínimo"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxPtoMinimo
        '
        Me.TextBoxPtoMinimo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPtoMinimo.Location = New System.Drawing.Point(105, 491)
        Me.TextBoxPtoMinimo.MaxLength = 13
        Me.TextBoxPtoMinimo.Name = "TextBoxPtoMinimo"
        Me.TextBoxPtoMinimo.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxPtoMinimo.TabIndex = 33
        Me.TextBoxPtoMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(59, 76)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(40, 13)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "Código"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxCodigo
        '
        Me.TextBoxCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCodigo.Location = New System.Drawing.Point(105, 71)
        Me.TextBoxCodigo.MaxLength = 15
        Me.TextBoxCodigo.Name = "TextBoxCodigo"
        Me.TextBoxCodigo.Size = New System.Drawing.Size(115, 20)
        Me.TextBoxCodigo.TabIndex = 1
        Me.TextBoxCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CheckBoxOferta
        '
        Me.CheckBoxOferta.AutoSize = True
        Me.CheckBoxOferta.Location = New System.Drawing.Point(406, 42)
        Me.CheckBoxOferta.Name = "CheckBoxOferta"
        Me.CheckBoxOferta.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBoxOferta.Size = New System.Drawing.Size(55, 17)
        Me.CheckBoxOferta.TabIndex = 5
        Me.CheckBoxOferta.TabStop = False
        Me.CheckBoxOferta.Text = "Oferta"
        Me.CheckBoxOferta.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(39, 442)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(60, 13)
        Me.Label18.TabIndex = 65
        Me.Label18.Text = "Básico [ 2 ]"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxPrecioVta2
        '
        Me.TextBoxPrecioVta2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPrecioVta2.Location = New System.Drawing.Point(105, 439)
        Me.TextBoxPrecioVta2.MaxLength = 13
        Me.TextBoxPrecioVta2.Name = "TextBoxPrecioVta2"
        Me.TextBoxPrecioVta2.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxPrecioVta2.TabIndex = 25
        Me.TextBoxPrecioVta2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(39, 468)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(60, 13)
        Me.Label19.TabIndex = 72
        Me.Label19.Text = "Básico [ 3 ]"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxPrecioVta3
        '
        Me.TextBoxPrecioVta3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPrecioVta3.Location = New System.Drawing.Point(105, 465)
        Me.TextBoxPrecioVta3.MaxLength = 13
        Me.TextBoxPrecioVta3.Name = "TextBoxPrecioVta3"
        Me.TextBoxPrecioVta3.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxPrecioVta3.TabIndex = 29
        Me.TextBoxPrecioVta3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PanelTotales
        '
        Me.PanelTotales.BackColor = System.Drawing.Color.LightBlue
        Me.PanelTotales.Controls.Add(Me.lblFinalMostrador)
        Me.PanelTotales.Controls.Add(Me.Label23)
        Me.PanelTotales.Controls.Add(Me.lblFinalKiosko)
        Me.PanelTotales.Controls.Add(Me.Label22)
        Me.PanelTotales.Controls.Add(Me.lblFinalRevendedor)
        Me.PanelTotales.Controls.Add(Me.Label21)
        Me.PanelTotales.Location = New System.Drawing.Point(476, 42)
        Me.PanelTotales.Name = "PanelTotales"
        Me.PanelTotales.Size = New System.Drawing.Size(338, 92)
        Me.PanelTotales.TabIndex = 12
        '
        'lblFinalMostrador
        '
        Me.lblFinalMostrador.AutoSize = True
        Me.lblFinalMostrador.Font = New System.Drawing.Font("Lucida Sans Typewriter", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinalMostrador.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblFinalMostrador.Location = New System.Drawing.Point(72, 57)
        Me.lblFinalMostrador.Name = "lblFinalMostrador"
        Me.lblFinalMostrador.Size = New System.Drawing.Size(31, 15)
        Me.lblFinalMostrador.TabIndex = 5
        Me.lblFinalMostrador.Text = "0.0"
        Me.lblFinalMostrador.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Lucida Sans Typewriter", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label23.Location = New System.Drawing.Point(11, 57)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(55, 15)
        Me.Label23.TabIndex = 4
        Me.Label23.Text = "$ [3]:"
        '
        'lblFinalKiosko
        '
        Me.lblFinalKiosko.AutoSize = True
        Me.lblFinalKiosko.Font = New System.Drawing.Font("Lucida Sans Typewriter", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinalKiosko.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblFinalKiosko.Location = New System.Drawing.Point(72, 33)
        Me.lblFinalKiosko.Name = "lblFinalKiosko"
        Me.lblFinalKiosko.Size = New System.Drawing.Size(31, 15)
        Me.lblFinalKiosko.TabIndex = 3
        Me.lblFinalKiosko.Text = "0.0"
        Me.lblFinalKiosko.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Lucida Sans Typewriter", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label22.Location = New System.Drawing.Point(11, 33)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(55, 15)
        Me.Label22.TabIndex = 2
        Me.Label22.Text = "$ [2]:"
        '
        'lblFinalRevendedor
        '
        Me.lblFinalRevendedor.AutoSize = True
        Me.lblFinalRevendedor.Font = New System.Drawing.Font("Lucida Sans Typewriter", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinalRevendedor.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblFinalRevendedor.Location = New System.Drawing.Point(72, 9)
        Me.lblFinalRevendedor.Name = "lblFinalRevendedor"
        Me.lblFinalRevendedor.Size = New System.Drawing.Size(31, 15)
        Me.lblFinalRevendedor.TabIndex = 1
        Me.lblFinalRevendedor.Text = "0.0"
        Me.lblFinalRevendedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Lucida Sans Typewriter", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label21.Location = New System.Drawing.Point(11, 9)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(55, 15)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "$ [1]:"
        '
        'PanelStock
        '
        Me.PanelStock.BackColor = System.Drawing.Color.LightGreen
        Me.PanelStock.Controls.Add(Me.lblExistenciaActual)
        Me.PanelStock.Controls.Add(Me.lblExistencia)
        Me.PanelStock.Location = New System.Drawing.Point(476, 140)
        Me.PanelStock.Name = "PanelStock"
        Me.PanelStock.Size = New System.Drawing.Size(338, 34)
        Me.PanelStock.TabIndex = 15
        '
        'lblExistenciaActual
        '
        Me.lblExistenciaActual.AutoSize = True
        Me.lblExistenciaActual.Font = New System.Drawing.Font("Lucida Sans Typewriter", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExistenciaActual.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblExistenciaActual.Location = New System.Drawing.Point(205, 7)
        Me.lblExistenciaActual.Name = "lblExistenciaActual"
        Me.lblExistenciaActual.Size = New System.Drawing.Size(38, 18)
        Me.lblExistenciaActual.TabIndex = 1
        Me.lblExistenciaActual.Text = "0.0"
        Me.lblExistenciaActual.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblExistencia
        '
        Me.lblExistencia.AutoSize = True
        Me.lblExistencia.Font = New System.Drawing.Font("Lucida Sans Typewriter", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExistencia.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblExistencia.Location = New System.Drawing.Point(11, 7)
        Me.lblExistencia.Name = "lblExistencia"
        Me.lblExistencia.Size = New System.Drawing.Size(188, 18)
        Me.lblExistencia.TabIndex = 0
        Me.lblExistencia.Text = "Existencia Actual:"
        '
        'CheckBoxModifica
        '
        Me.CheckBoxModifica.AutoSize = True
        Me.CheckBoxModifica.Location = New System.Drawing.Point(259, 42)
        Me.CheckBoxModifica.Name = "CheckBoxModifica"
        Me.CheckBoxModifica.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBoxModifica.Size = New System.Drawing.Size(142, 17)
        Me.CheckBoxModifica.TabIndex = 4
        Me.CheckBoxModifica.TabStop = False
        Me.CheckBoxModifica.Text = "Pcio. de vta. modificable"
        Me.CheckBoxModifica.UseVisualStyleBackColor = True
        '
        'ToolTipAyuda
        '
        Me.ToolTipAyuda.BackColor = System.Drawing.Color.AliceBlue
        Me.ToolTipAyuda.ForeColor = System.Drawing.Color.DarkBlue
        Me.ToolTipAyuda.IsBalloon = True
        Me.ToolTipAyuda.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipAyuda.ToolTipTitle = "Ayuda"
        '
        'TextBoxCoeficienteKilo
        '
        Me.TextBoxCoeficienteKilo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCoeficienteKilo.Location = New System.Drawing.Point(105, 282)
        Me.TextBoxCoeficienteKilo.MaxLength = 13
        Me.TextBoxCoeficienteKilo.Name = "TextBoxCoeficienteKilo"
        Me.TextBoxCoeficienteKilo.Size = New System.Drawing.Size(81, 20)
        Me.TextBoxCoeficienteKilo.TabIndex = 8
        Me.TextBoxCoeficienteKilo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(36, 285)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(63, 13)
        Me.Label35.TabIndex = 33
        Me.Label35.Text = "Coef. en Kg"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'FileSystemWatcher1
        '
        Me.FileSystemWatcher1.EnableRaisingEvents = True
        Me.FileSystemWatcher1.SynchronizingObject = Me
        '
        'ComboBoxUnidades
        '
        Me.ComboBoxUnidades.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.ComboBoxUnidades.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.ComboBoxUnidades.BusquedaPorCodigobarra = False
        Me.ComboBoxUnidades.ColumnasExtras = Nothing
        Me.ComboBoxUnidades.CustomFormatArt = False
        Me.ComboBoxUnidades.DataSource = Nothing
        Me.ComboBoxUnidades.DisplayMember = Nothing
        Me.ComboBoxUnidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.ComboBoxUnidades.FormularioDeAlta = Nothing
        Me.ComboBoxUnidades.FormularioDeBusqueda = Nothing
        Me.ComboBoxUnidades.Location = New System.Drawing.Point(105, 251)
        Me.ComboBoxUnidades.MaximumSize = New System.Drawing.Size(500, 25)
        Me.ComboBoxUnidades.MinimumSize = New System.Drawing.Size(200, 25)
        Me.ComboBoxUnidades.Name = "ComboBoxUnidades"
        Me.ComboBoxUnidades.SelectedIndex = -1
        Me.ComboBoxUnidades.SelectedItem = Nothing
        Me.ComboBoxUnidades.SelectedText = ""
        Me.ComboBoxUnidades.SelectedValue = Nothing
        Me.ComboBoxUnidades.Size = New System.Drawing.Size(356, 25)
        Me.ComboBoxUnidades.TabIndex = 7
        Me.ComboBoxUnidades.ValueMember = Nothing
        '
        'ComboBoxRubros
        '
        Me.ComboBoxRubros.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.ComboBoxRubros.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.ComboBoxRubros.BusquedaPorCodigobarra = False
        Me.ComboBoxRubros.ColumnasExtras = Nothing
        Me.ComboBoxRubros.CustomFormatArt = False
        Me.ComboBoxRubros.DataSource = Nothing
        Me.ComboBoxRubros.DisplayMember = Nothing
        Me.ComboBoxRubros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.ComboBoxRubros.FormularioDeAlta = Nothing
        Me.ComboBoxRubros.FormularioDeBusqueda = Nothing
        Me.ComboBoxRubros.Location = New System.Drawing.Point(105, 220)
        Me.ComboBoxRubros.MaximumSize = New System.Drawing.Size(500, 25)
        Me.ComboBoxRubros.MinimumSize = New System.Drawing.Size(200, 25)
        Me.ComboBoxRubros.Name = "ComboBoxRubros"
        Me.ComboBoxRubros.SelectedIndex = -1
        Me.ComboBoxRubros.SelectedItem = Nothing
        Me.ComboBoxRubros.SelectedText = ""
        Me.ComboBoxRubros.SelectedValue = Nothing
        Me.ComboBoxRubros.Size = New System.Drawing.Size(356, 25)
        Me.ComboBoxRubros.TabIndex = 6
        Me.ComboBoxRubros.ValueMember = Nothing
        '
        'CtlComboCategoria
        '
        Me.CtlComboCategoria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.CtlComboCategoria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.CtlComboCategoria.BusquedaPorCodigobarra = False
        Me.CtlComboCategoria.ColumnasExtras = Nothing
        Me.CtlComboCategoria.CustomFormatArt = False
        Me.CtlComboCategoria.DataSource = Nothing
        Me.CtlComboCategoria.DisplayMember = Nothing
        Me.CtlComboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.CtlComboCategoria.FormularioDeAlta = Nothing
        Me.CtlComboCategoria.FormularioDeBusqueda = Nothing
        Me.CtlComboCategoria.Location = New System.Drawing.Point(105, 189)
        Me.CtlComboCategoria.MaximumSize = New System.Drawing.Size(500, 25)
        Me.CtlComboCategoria.MinimumSize = New System.Drawing.Size(200, 25)
        Me.CtlComboCategoria.Name = "CtlComboCategoria"
        Me.CtlComboCategoria.SelectedIndex = -1
        Me.CtlComboCategoria.SelectedItem = Nothing
        Me.CtlComboCategoria.SelectedText = ""
        Me.CtlComboCategoria.SelectedValue = Nothing
        Me.CtlComboCategoria.Size = New System.Drawing.Size(356, 25)
        Me.CtlComboCategoria.TabIndex = 5
        Me.CtlComboCategoria.ValueMember = Nothing
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Image = Global.Principal.My.Resources.Resources.disk
        Me.BtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(98, 22)
        Me.BtnGuardar.Text = "Guardar [F12]"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = Global.Principal.My.Resources.Resources.cancel
        Me.BtnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(101, 22)
        Me.BtnCancelar.Text = "Cancelar [Esc]"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(237, 494)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(85, 13)
        Me.Label20.TabIndex = 81
        Me.Label20.Text = "Sugerido al Pub."
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(211, 416)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(38, 13)
        Me.Label15.TabIndex = 60
        Me.Label15.Text = "% Dto."
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(294, 416)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(36, 13)
        Me.Label29.TabIndex = 63
        Me.Label29.Text = "% Util."
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelSug1
        '
        Me.LabelSug1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSug1.Location = New System.Drawing.Point(382, 413)
        Me.LabelSug1.Name = "LabelSug1"
        Me.LabelSug1.Size = New System.Drawing.Size(79, 20)
        Me.LabelSug1.TabIndex = 24
        Me.LabelSug1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(211, 442)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(38, 13)
        Me.Label26.TabIndex = 67
        Me.Label26.Text = "% Dto."
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(294, 442)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(36, 13)
        Me.Label30.TabIndex = 70
        Me.Label30.Text = "% Util."
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelSug2
        '
        Me.LabelSug2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSug2.Location = New System.Drawing.Point(382, 439)
        Me.LabelSug2.Name = "LabelSug2"
        Me.LabelSug2.Size = New System.Drawing.Size(79, 20)
        Me.LabelSug2.TabIndex = 28
        Me.LabelSug2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(211, 468)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(38, 13)
        Me.Label27.TabIndex = 75
        Me.Label27.Text = "% Dto."
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(294, 468)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(36, 13)
        Me.Label31.TabIndex = 78
        Me.Label31.Text = "% Util."
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelSug3
        '
        Me.LabelSug3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSug3.Location = New System.Drawing.Point(382, 464)
        Me.LabelSug3.Name = "LabelSug3"
        Me.LabelSug3.Size = New System.Drawing.Size(79, 20)
        Me.LabelSug3.TabIndex = 32
        Me.LabelSug3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxPrecioVtaSug
        '
        Me.TextBoxPrecioVtaSug.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPrecioVtaSug.Location = New System.Drawing.Point(361, 491)
        Me.TextBoxPrecioVtaSug.MaxLength = 13
        Me.TextBoxPrecioVtaSug.Name = "TextBoxPrecioVtaSug"
        Me.TextBoxPrecioVtaSug.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxPrecioVtaSug.TabIndex = 34
        Me.TextBoxPrecioVtaSug.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxDescuento
        '
        Me.TextBoxDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxDescuento.Location = New System.Drawing.Point(254, 413)
        Me.TextBoxDescuento.MaxLength = 13
        Me.TextBoxDescuento.Name = "TextBoxDescuento"
        Me.TextBoxDescuento.Size = New System.Drawing.Size(34, 20)
        Me.TextBoxDescuento.TabIndex = 22
        Me.TextBoxDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxRenta1
        '
        Me.TextBoxRenta1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxRenta1.Location = New System.Drawing.Point(329, 413)
        Me.TextBoxRenta1.MaxLength = 13
        Me.TextBoxRenta1.Name = "TextBoxRenta1"
        Me.TextBoxRenta1.Size = New System.Drawing.Size(47, 20)
        Me.TextBoxRenta1.TabIndex = 23
        Me.TextBoxRenta1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxDescuento2
        '
        Me.TextBoxDescuento2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxDescuento2.Location = New System.Drawing.Point(254, 439)
        Me.TextBoxDescuento2.MaxLength = 13
        Me.TextBoxDescuento2.Name = "TextBoxDescuento2"
        Me.TextBoxDescuento2.Size = New System.Drawing.Size(34, 20)
        Me.TextBoxDescuento2.TabIndex = 26
        Me.TextBoxDescuento2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxRenta2
        '
        Me.TextBoxRenta2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxRenta2.Location = New System.Drawing.Point(329, 439)
        Me.TextBoxRenta2.MaxLength = 13
        Me.TextBoxRenta2.Name = "TextBoxRenta2"
        Me.TextBoxRenta2.Size = New System.Drawing.Size(47, 20)
        Me.TextBoxRenta2.TabIndex = 27
        Me.TextBoxRenta2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxDescuento3
        '
        Me.TextBoxDescuento3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxDescuento3.Location = New System.Drawing.Point(254, 465)
        Me.TextBoxDescuento3.MaxLength = 13
        Me.TextBoxDescuento3.Name = "TextBoxDescuento3"
        Me.TextBoxDescuento3.Size = New System.Drawing.Size(34, 20)
        Me.TextBoxDescuento3.TabIndex = 30
        Me.TextBoxDescuento3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxRenta3
        '
        Me.TextBoxRenta3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxRenta3.Location = New System.Drawing.Point(329, 465)
        Me.TextBoxRenta3.MaxLength = 13
        Me.TextBoxRenta3.Name = "TextBoxRenta3"
        Me.TextBoxRenta3.Size = New System.Drawing.Size(47, 20)
        Me.TextBoxRenta3.TabIndex = 31
        Me.TextBoxRenta3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnDesglose
        '
        Me.BtnDesglose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDesglose.FlatAppearance.BorderSize = 0
        Me.BtnDesglose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDesglose.Image = Global.Principal.My.Resources.Resources.coins_add
        Me.BtnDesglose.Location = New System.Drawing.Point(322, 490)
        Me.BtnDesglose.Name = "BtnDesglose"
        Me.BtnDesglose.Size = New System.Drawing.Size(35, 20)
        Me.BtnDesglose.TabIndex = 82
        Me.BtnDesglose.TabStop = False
        Me.ToolTipAyuda.SetToolTip(Me.BtnDesglose, "Calcular precios netos sobre el precio de venta sugerido al público")
        Me.BtnDesglose.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 390)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 13)
        Me.Label7.TabIndex = 53
        Me.Label7.Text = "Precio de Costo"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxPrecioCosto
        '
        Me.TextBoxPrecioCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPrecioCosto.Location = New System.Drawing.Point(105, 387)
        Me.TextBoxPrecioCosto.MaxLength = 13
        Me.TextBoxPrecioCosto.Name = "TextBoxPrecioCosto"
        Me.TextBoxPrecioCosto.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxPrecioCosto.TabIndex = 20
        Me.TextBoxPrecioCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnMargenes
        '
        Me.BtnMargenes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnMargenes.FlatAppearance.BorderSize = 0
        Me.BtnMargenes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMargenes.Image = Global.Principal.My.Resources.Resources.coins_add
        Me.BtnMargenes.Location = New System.Drawing.Point(211, 387)
        Me.BtnMargenes.Name = "BtnMargenes"
        Me.BtnMargenes.Size = New System.Drawing.Size(35, 20)
        Me.BtnMargenes.TabIndex = 55
        Me.BtnMargenes.TabStop = False
        Me.ToolTipAyuda.SetToolTip(Me.BtnMargenes, "Calcular precios netos según alícuotas de rentabilidad")
        Me.BtnMargenes.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 311)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 13)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Alícuota de I.V.A."
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(8, 364)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(91, 13)
        Me.Label13.TabIndex = 46
        Me.Label13.Text = "Precio de Compra"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(215, 364)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(43, 13)
        Me.Label28.TabIndex = 48
        Me.Label28.Text = "% Dtos."
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(213, 338)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 13)
        Me.Label14.TabIndex = 43
        Me.Label14.Text = "Ultima Compra"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(29, 338)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(70, 13)
        Me.Label25.TabIndex = 41
        Me.Label25.Text = "Bulto Compra"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(211, 311)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 13)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Imp.Int. % "
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(326, 311)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(48, 13)
        Me.Label24.TabIndex = 39
        Me.Label24.Text = "Imp.Int.$"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxPrecioCompra
        '
        Me.TextBoxPrecioCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPrecioCompra.Location = New System.Drawing.Point(105, 361)
        Me.TextBoxPrecioCompra.MaxLength = 13
        Me.TextBoxPrecioCompra.Name = "TextBoxPrecioCompra"
        Me.TextBoxPrecioCompra.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxPrecioCompra.TabIndex = 15
        Me.TextBoxPrecioCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBoxDtoCompra1
        '
        Me.TextBoxDtoCompra1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxDtoCompra1.Location = New System.Drawing.Point(263, 361)
        Me.TextBoxDtoCompra1.MaxLength = 13
        Me.TextBoxDtoCompra1.Name = "TextBoxDtoCompra1"
        Me.TextBoxDtoCompra1.Size = New System.Drawing.Size(45, 20)
        Me.TextBoxDtoCompra1.TabIndex = 16
        Me.TextBoxDtoCompra1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxDtoCompra2
        '
        Me.TextBoxDtoCompra2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxDtoCompra2.Location = New System.Drawing.Point(314, 361)
        Me.TextBoxDtoCompra2.MaxLength = 13
        Me.TextBoxDtoCompra2.Name = "TextBoxDtoCompra2"
        Me.TextBoxDtoCompra2.Size = New System.Drawing.Size(45, 20)
        Me.TextBoxDtoCompra2.TabIndex = 17
        Me.TextBoxDtoCompra2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxDtoCompra3
        '
        Me.TextBoxDtoCompra3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxDtoCompra3.Location = New System.Drawing.Point(365, 361)
        Me.TextBoxDtoCompra3.MaxLength = 13
        Me.TextBoxDtoCompra3.Name = "TextBoxDtoCompra3"
        Me.TextBoxDtoCompra3.Size = New System.Drawing.Size(45, 20)
        Me.TextBoxDtoCompra3.TabIndex = 18
        Me.TextBoxDtoCompra3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxDtoCompra4
        '
        Me.TextBoxDtoCompra4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxDtoCompra4.Location = New System.Drawing.Point(416, 361)
        Me.TextBoxDtoCompra4.MaxLength = 13
        Me.TextBoxDtoCompra4.Name = "TextBoxDtoCompra4"
        Me.TextBoxDtoCompra4.Size = New System.Drawing.Size(45, 20)
        Me.TextBoxDtoCompra4.TabIndex = 19
        Me.TextBoxDtoCompra4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxCantidadBulto
        '
        Me.TextBoxCantidadBulto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCantidadBulto.Location = New System.Drawing.Point(105, 335)
        Me.TextBoxCantidadBulto.MaxLength = 13
        Me.TextBoxCantidadBulto.Name = "TextBoxCantidadBulto"
        Me.TextBoxCantidadBulto.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxCantidadBulto.TabIndex = 13
        Me.TextBoxCantidadBulto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxImpuestoInterno
        '
        Me.TextBoxImpuestoInterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxImpuestoInterno.Location = New System.Drawing.Point(273, 308)
        Me.TextBoxImpuestoInterno.MaxLength = 13
        Me.TextBoxImpuestoInterno.Name = "TextBoxImpuestoInterno"
        Me.TextBoxImpuestoInterno.Size = New System.Drawing.Size(42, 20)
        Me.TextBoxImpuestoInterno.TabIndex = 11
        Me.TextBoxImpuestoInterno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxImpuestoInternoImp
        '
        Me.TextBoxImpuestoInternoImp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxImpuestoInternoImp.Location = New System.Drawing.Point(380, 308)
        Me.TextBoxImpuestoInternoImp.MaxLength = 13
        Me.TextBoxImpuestoInternoImp.Name = "TextBoxImpuestoInternoImp"
        Me.TextBoxImpuestoInternoImp.Size = New System.Drawing.Size(81, 20)
        Me.TextBoxImpuestoInternoImp.TabIndex = 12
        Me.TextBoxImpuestoInternoImp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ComboBoxAlicuotas
        '
        Me.ComboBoxAlicuotas.FormattingEnabled = True
        Me.ComboBoxAlicuotas.Location = New System.Drawing.Point(105, 308)
        Me.ComboBoxAlicuotas.Name = "ComboBoxAlicuotas"
        Me.ComboBoxAlicuotas.Size = New System.Drawing.Size(100, 21)
        Me.ComboBoxAlicuotas.TabIndex = 10
        '
        'DTPUltCompra
        '
        Me.DTPUltCompra.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPUltCompra.Location = New System.Drawing.Point(294, 335)
        Me.DTPUltCompra.Name = "DTPUltCompra"
        Me.DTPUltCompra.Size = New System.Drawing.Size(98, 20)
        Me.DTPUltCompra.TabIndex = 14
        '
        'FormArticuloAnterior
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(826, 649)
        Me.Controls.Add(Me.DTPUltCompra)
        Me.Controls.Add(Me.TextBoxCoeficienteKilo)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.BtnDesglose)
        Me.Controls.Add(Me.BtnMargenes)
        Me.Controls.Add(Me.PanelStock)
        Me.Controls.Add(Me.PanelTotales)
        Me.Controls.Add(Me.ComboBoxUnidades)
        Me.Controls.Add(Me.ComboBoxRubros)
        Me.Controls.Add(Me.CtlComboCategoria)
        Me.Controls.Add(Me.ComboBoxAlicuotas)
        Me.Controls.Add(Me.CheckBoxModifica)
        Me.Controls.Add(Me.CheckBoxOferta)
        Me.Controls.Add(Me.CheckBoxActivo)
        Me.Controls.Add(Me.TextBoxDescripcion)
        Me.Controls.Add(Me.TextBoxNombre)
        Me.Controls.Add(Me.TextBoxImpuestoInternoImp)
        Me.Controls.Add(Me.TextBoxImpuestoInterno)
        Me.Controls.Add(Me.TextBoxCantidadBulto)
        Me.Controls.Add(Me.TextBoxPtoMinimo)
        Me.Controls.Add(Me.TextBoxRenta3)
        Me.Controls.Add(Me.TextBoxDescuento3)
        Me.Controls.Add(Me.TextBoxRenta2)
        Me.Controls.Add(Me.TextBoxDescuento2)
        Me.Controls.Add(Me.TextBoxDtoCompra4)
        Me.Controls.Add(Me.TextBoxDtoCompra3)
        Me.Controls.Add(Me.TextBoxDtoCompra2)
        Me.Controls.Add(Me.TextBoxDtoCompra1)
        Me.Controls.Add(Me.TextBoxRenta1)
        Me.Controls.Add(Me.TextBoxDescuento)
        Me.Controls.Add(Me.TextBoxPrecioCosto)
        Me.Controls.Add(Me.TextBoxPrecioCompra)
        Me.Controls.Add(Me.TextBoxPrecioVta2)
        Me.Controls.Add(Me.TextBoxPrecioVtaSug)
        Me.Controls.Add(Me.TextBoxPrecioVta3)
        Me.Controls.Add(Me.TextBoxPrecioVta)
        Me.Controls.Add(Me.TextBoxCodigo)
        Me.Controls.Add(Me.TextBoxCodigoBarra)
        Me.Controls.Add(Me.TextBoxId)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.LabelSug3)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.LabelSug2)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.LabelSug1)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormArticuloAnterior"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = " "
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.PanelTotales.ResumeLayout(False)
        Me.PanelTotales.PerformLayout()
        Me.PanelStock.ResumeLayout(False)
        Me.PanelStock.PerformLayout()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBoxId As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNombre As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents CheckBoxActivo As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxCodigoBarra As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBoxPrecioVta As System.Windows.Forms.TextBox
    Friend WithEvents CtlComboCategoria As Principal.CtlCustomCombo
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxRubros As Principal.CtlCustomCombo
    Friend WithEvents ComboBoxUnidades As Principal.CtlCustomCombo
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TextBoxPtoMinimo As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TextBoxCodigo As System.Windows.Forms.TextBox
    Friend WithEvents CheckBoxOferta As System.Windows.Forms.CheckBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TextBoxPrecioVta2 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TextBoxPrecioVta3 As System.Windows.Forms.TextBox
    Friend WithEvents PanelTotales As System.Windows.Forms.Panel
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblFinalMostrador As System.Windows.Forms.Label
    Friend WithEvents lblFinalKiosko As System.Windows.Forms.Label
    Friend WithEvents lblFinalRevendedor As System.Windows.Forms.Label
    Friend WithEvents PanelStock As System.Windows.Forms.Panel
    Friend WithEvents lblExistenciaActual As System.Windows.Forms.Label
    Friend WithEvents lblExistencia As System.Windows.Forms.Label
    Friend WithEvents CheckBoxModifica As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTipAyuda As System.Windows.Forms.ToolTip
    Friend WithEvents TextBoxCoeficienteKilo As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents FileSystemWatcher1 As System.IO.FileSystemWatcher
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents DTPUltCompra As DateTimePicker
    Friend WithEvents BtnDesglose As Button
    Friend WithEvents BtnMargenes As Button
    Friend WithEvents ComboBoxAlicuotas As ComboBox
    Friend WithEvents TextBoxImpuestoInternoImp As TextBox
    Friend WithEvents TextBoxImpuestoInterno As TextBox
    Friend WithEvents TextBoxCantidadBulto As TextBox
    Friend WithEvents TextBoxRenta3 As TextBox
    Friend WithEvents TextBoxDescuento3 As TextBox
    Friend WithEvents TextBoxRenta2 As TextBox
    Friend WithEvents TextBoxDescuento2 As TextBox
    Friend WithEvents TextBoxDtoCompra4 As TextBox
    Friend WithEvents TextBoxDtoCompra3 As TextBox
    Friend WithEvents TextBoxDtoCompra2 As TextBox
    Friend WithEvents TextBoxDtoCompra1 As TextBox
    Friend WithEvents TextBoxRenta1 As TextBox
    Friend WithEvents TextBoxDescuento As TextBox
    Friend WithEvents TextBoxPrecioCosto As TextBox
    Friend WithEvents TextBoxPrecioCompra As TextBox
    Friend WithEvents TextBoxPrecioVtaSug As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents LabelSug3 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents LabelSug2 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents LabelSug1 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label6 As Label
End Class
