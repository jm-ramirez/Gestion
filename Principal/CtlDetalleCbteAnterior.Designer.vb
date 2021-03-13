<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlDetalleCbteAnterior
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CtlDetalleCbteAnterior))
        Me.TabControlDetalleCbte = New System.Windows.Forms.TabControl()
        Me.TabPageCtasPropias = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanelCtasPropias = New System.Windows.Forms.TableLayoutPanel()
        Me.FOLVCtasPropias = New BrightIdeasSoftware.FastObjectListView()
        Me.PanelCabeceraCtasPropias = New System.Windows.Forms.Panel()
        Me.DateTimePickerEfectivizacion = New System.Windows.Forms.DateTimePicker()
        Me.ComboBoxConceptoBancario = New Principal.CtlCustomCombo()
        Me.ComboBoxCtaBancaria = New Principal.CtlCustomCombo()
        Me.BtnAgregarCtaPropia = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBoxReferencia = New System.Windows.Forms.TextBox()
        Me.TextBoxImporteCtaPropia = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TabPageCartera = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanelCartera = New System.Windows.Forms.TableLayoutPanel()
        Me.FOLVCartera = New BrightIdeasSoftware.FastObjectListView()
        Me.PanelCabeceraCartera = New System.Windows.Forms.Panel()
        Me.DateTimePickerFechaCheque = New System.Windows.Forms.DateTimePicker()
        Me.ComboBoxLocalidad = New Principal.CtlCustomCombo()
        Me.ComboBoxBancos = New Principal.CtlCustomCombo()
        Me.BtnAgregarCheque = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBoxDador = New System.Windows.Forms.TextBox()
        Me.TextBoxCUITLibrador = New System.Windows.Forms.TextBox()
        Me.TextBoxReferenciaCartera = New System.Windows.Forms.TextBox()
        Me.TextBoxImporteCartera = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TabPageArt = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanelArticulos = New System.Windows.Forms.TableLayoutPanel()
        Me.FOLVArticulos = New BrightIdeasSoftware.FastObjectListView()
        Me.PanelCabecera = New System.Windows.Forms.Panel()
        Me.ComboBoxArticulos = New Principal.CtlCustomCombo()
        Me.lblSubtotal = New System.Windows.Forms.Label()
        Me.BtnAgregarArticulo = New System.Windows.Forms.Button()
        Me.lblAlicuota = New System.Windows.Forms.Label()
        Me.TextBoxCantidad = New System.Windows.Forms.TextBox()
        Me.lblDto = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.lblImporte = New System.Windows.Forms.Label()
        Me.TextBoxImporteImpInt = New System.Windows.Forms.TextBox()
        Me.TextBoxImporte = New System.Windows.Forms.TextBox()
        Me.lblCant = New System.Windows.Forms.Label()
        Me.ComboBoxArticuloAlicuota = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TextBoxSubtotalArticulo = New System.Windows.Forms.TextBox()
        Me.TabPageImportes = New System.Windows.Forms.TabPage()
        Me.FOLVImportes = New BrightIdeasSoftware.FastObjectListView()
        Me.TabPageAlicuotas = New System.Windows.Forms.TabPage()
        Me.FOLVAlicuotas = New BrightIdeasSoftware.FastObjectListView()
        Me.TabPageOtros = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanelTributos = New System.Windows.Forms.TableLayoutPanel()
        Me.PanelCabeceraTributos = New System.Windows.Forms.Panel()
        Me.BtnAgregarTributo = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBoxRefTributo = New System.Windows.Forms.TextBox()
        Me.TextBoxBaseTributo = New System.Windows.Forms.TextBox()
        Me.TextBoxImporteTributo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBoxDescTributo = New System.Windows.Forms.ComboBox()
        Me.ComboBoxTributos = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBoxTributoAlic = New System.Windows.Forms.TextBox()
        Me.FOLVOtrosTributos = New BrightIdeasSoftware.FastObjectListView()
        Me.TabPageCompAsoc = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanelAsoc = New System.Windows.Forms.TableLayoutPanel()
        Me.PanelCabeceraAsoc = New System.Windows.Forms.Panel()
        Me.LabelCtaCte = New System.Windows.Forms.Label()
        Me.CheckBoxCtaCte = New System.Windows.Forms.CheckBox()
        Me.CheckBoxVerTodos = New System.Windows.Forms.CheckBox()
        Me.ComboBoxAsoc = New Principal.CtlCustomCombo()
        Me.BtnAgregarAsoc = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBoxImporteAsoc = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.FOLVCompAsoc = New BrightIdeasSoftware.FastObjectListView()
        Me.TabPageObs = New System.Windows.Forms.TabPage()
        Me.TextBoxObservaciones = New System.Windows.Forms.TextBox()
        Me.ImgList = New System.Windows.Forms.ImageList(Me.components)
        Me.TextBoxDto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxImporteFinal = New System.Windows.Forms.TextBox()
        Me.TextBoxSubtotalArticuloFinal = New System.Windows.Forms.TextBox()
        Me.TabControlDetalleCbte.SuspendLayout()
        Me.TabPageCtasPropias.SuspendLayout()
        Me.TableLayoutPanelCtasPropias.SuspendLayout()
        CType(Me.FOLVCtasPropias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelCabeceraCtasPropias.SuspendLayout()
        Me.TabPageCartera.SuspendLayout()
        Me.TableLayoutPanelCartera.SuspendLayout()
        CType(Me.FOLVCartera, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelCabeceraCartera.SuspendLayout()
        Me.TabPageArt.SuspendLayout()
        Me.TableLayoutPanelArticulos.SuspendLayout()
        CType(Me.FOLVArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelCabecera.SuspendLayout()
        Me.TabPageImportes.SuspendLayout()
        CType(Me.FOLVImportes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageAlicuotas.SuspendLayout()
        CType(Me.FOLVAlicuotas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageOtros.SuspendLayout()
        Me.TableLayoutPanelTributos.SuspendLayout()
        Me.PanelCabeceraTributos.SuspendLayout()
        CType(Me.FOLVOtrosTributos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageCompAsoc.SuspendLayout()
        Me.TableLayoutPanelAsoc.SuspendLayout()
        Me.PanelCabeceraAsoc.SuspendLayout()
        CType(Me.FOLVCompAsoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageObs.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControlDetalleCbte
        '
        Me.TabControlDetalleCbte.Controls.Add(Me.TabPageCtasPropias)
        Me.TabControlDetalleCbte.Controls.Add(Me.TabPageCartera)
        Me.TabControlDetalleCbte.Controls.Add(Me.TabPageArt)
        Me.TabControlDetalleCbte.Controls.Add(Me.TabPageImportes)
        Me.TabControlDetalleCbte.Controls.Add(Me.TabPageAlicuotas)
        Me.TabControlDetalleCbte.Controls.Add(Me.TabPageOtros)
        Me.TabControlDetalleCbte.Controls.Add(Me.TabPageCompAsoc)
        Me.TabControlDetalleCbte.Controls.Add(Me.TabPageObs)
        Me.TabControlDetalleCbte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlDetalleCbte.Location = New System.Drawing.Point(0, 0)
        Me.TabControlDetalleCbte.Name = "TabControlDetalleCbte"
        Me.TabControlDetalleCbte.SelectedIndex = 0
        Me.TabControlDetalleCbte.Size = New System.Drawing.Size(852, 251)
        Me.TabControlDetalleCbte.TabIndex = 0
        '
        'TabPageCtasPropias
        '
        Me.TabPageCtasPropias.Controls.Add(Me.TableLayoutPanelCtasPropias)
        Me.TabPageCtasPropias.Location = New System.Drawing.Point(4, 22)
        Me.TabPageCtasPropias.Name = "TabPageCtasPropias"
        Me.TabPageCtasPropias.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageCtasPropias.Size = New System.Drawing.Size(844, 225)
        Me.TabPageCtasPropias.TabIndex = 5
        Me.TabPageCtasPropias.Text = "Cuentas Propias"
        Me.TabPageCtasPropias.UseVisualStyleBackColor = True
        '
        'TableLayoutPanelCtasPropias
        '
        Me.TableLayoutPanelCtasPropias.ColumnCount = 1
        Me.TableLayoutPanelCtasPropias.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelCtasPropias.Controls.Add(Me.FOLVCtasPropias, 0, 1)
        Me.TableLayoutPanelCtasPropias.Controls.Add(Me.PanelCabeceraCtasPropias, 0, 0)
        Me.TableLayoutPanelCtasPropias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelCtasPropias.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanelCtasPropias.Name = "TableLayoutPanelCtasPropias"
        Me.TableLayoutPanelCtasPropias.RowCount = 2
        Me.TableLayoutPanelCtasPropias.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65.0!))
        Me.TableLayoutPanelCtasPropias.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelCtasPropias.Size = New System.Drawing.Size(838, 219)
        Me.TableLayoutPanelCtasPropias.TabIndex = 1
        '
        'FOLVCtasPropias
        '
        Me.FOLVCtasPropias.AlternateRowBackColor = System.Drawing.Color.LightSteelBlue
        Me.FOLVCtasPropias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FOLVCtasPropias.HideSelection = False
        Me.FOLVCtasPropias.Location = New System.Drawing.Point(3, 68)
        Me.FOLVCtasPropias.Name = "FOLVCtasPropias"
        Me.FOLVCtasPropias.ShowGroups = False
        Me.FOLVCtasPropias.ShowHeaderInAllViews = False
        Me.FOLVCtasPropias.Size = New System.Drawing.Size(832, 148)
        Me.FOLVCtasPropias.TabIndex = 1
        Me.FOLVCtasPropias.UseAlternatingBackColors = True
        Me.FOLVCtasPropias.UseCompatibleStateImageBehavior = False
        Me.FOLVCtasPropias.View = System.Windows.Forms.View.Details
        Me.FOLVCtasPropias.VirtualMode = True
        '
        'PanelCabeceraCtasPropias
        '
        Me.PanelCabeceraCtasPropias.Controls.Add(Me.DateTimePickerEfectivizacion)
        Me.PanelCabeceraCtasPropias.Controls.Add(Me.ComboBoxConceptoBancario)
        Me.PanelCabeceraCtasPropias.Controls.Add(Me.ComboBoxCtaBancaria)
        Me.PanelCabeceraCtasPropias.Controls.Add(Me.BtnAgregarCtaPropia)
        Me.PanelCabeceraCtasPropias.Controls.Add(Me.Label12)
        Me.PanelCabeceraCtasPropias.Controls.Add(Me.TextBoxReferencia)
        Me.PanelCabeceraCtasPropias.Controls.Add(Me.TextBoxImporteCtaPropia)
        Me.PanelCabeceraCtasPropias.Controls.Add(Me.Label2)
        Me.PanelCabeceraCtasPropias.Controls.Add(Me.Label10)
        Me.PanelCabeceraCtasPropias.Controls.Add(Me.Label8)
        Me.PanelCabeceraCtasPropias.Controls.Add(Me.Label14)
        Me.PanelCabeceraCtasPropias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelCabeceraCtasPropias.Location = New System.Drawing.Point(3, 3)
        Me.PanelCabeceraCtasPropias.Name = "PanelCabeceraCtasPropias"
        Me.PanelCabeceraCtasPropias.Size = New System.Drawing.Size(832, 59)
        Me.PanelCabeceraCtasPropias.TabIndex = 0
        '
        'DateTimePickerEfectivizacion
        '
        Me.DateTimePickerEfectivizacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerEfectivizacion.Location = New System.Drawing.Point(122, 33)
        Me.DateTimePickerEfectivizacion.Name = "DateTimePickerEfectivizacion"
        Me.DateTimePickerEfectivizacion.Size = New System.Drawing.Size(108, 20)
        Me.DateTimePickerEfectivizacion.TabIndex = 2
        '
        'ComboBoxConceptoBancario
        '
        Me.ComboBoxConceptoBancario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.ComboBoxConceptoBancario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.ComboBoxConceptoBancario.BusquedaPorCodigobarra = False
        Me.ComboBoxConceptoBancario.ColumnasExtras = Nothing
        Me.ComboBoxConceptoBancario.CustomFormatArt = False
        Me.ComboBoxConceptoBancario.DataSource = Nothing
        Me.ComboBoxConceptoBancario.DisplayMember = Nothing
        Me.ComboBoxConceptoBancario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ComboBoxConceptoBancario.FormularioDeAlta = Nothing
        Me.ComboBoxConceptoBancario.FormularioDeBusqueda = Nothing
        Me.ComboBoxConceptoBancario.Location = New System.Drawing.Point(515, 3)
        Me.ComboBoxConceptoBancario.MaximumSize = New System.Drawing.Size(500, 25)
        Me.ComboBoxConceptoBancario.MinimumSize = New System.Drawing.Size(200, 25)
        Me.ComboBoxConceptoBancario.Name = "ComboBoxConceptoBancario"
        Me.ComboBoxConceptoBancario.SelectedIndex = -1
        Me.ComboBoxConceptoBancario.SelectedItem = Nothing
        Me.ComboBoxConceptoBancario.SelectedText = ""
        Me.ComboBoxConceptoBancario.SelectedValue = Nothing
        Me.ComboBoxConceptoBancario.Size = New System.Drawing.Size(235, 25)
        Me.ComboBoxConceptoBancario.TabIndex = 1
        Me.ComboBoxConceptoBancario.ValueMember = Nothing
        '
        'ComboBoxCtaBancaria
        '
        Me.ComboBoxCtaBancaria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.ComboBoxCtaBancaria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.ComboBoxCtaBancaria.BusquedaPorCodigobarra = False
        Me.ComboBoxCtaBancaria.ColumnasExtras = Nothing
        Me.ComboBoxCtaBancaria.CustomFormatArt = False
        Me.ComboBoxCtaBancaria.DataSource = Nothing
        Me.ComboBoxCtaBancaria.DisplayMember = Nothing
        Me.ComboBoxCtaBancaria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ComboBoxCtaBancaria.FormularioDeAlta = Nothing
        Me.ComboBoxCtaBancaria.FormularioDeBusqueda = Nothing
        Me.ComboBoxCtaBancaria.Location = New System.Drawing.Point(122, 3)
        Me.ComboBoxCtaBancaria.MaximumSize = New System.Drawing.Size(500, 25)
        Me.ComboBoxCtaBancaria.MinimumSize = New System.Drawing.Size(200, 25)
        Me.ComboBoxCtaBancaria.Name = "ComboBoxCtaBancaria"
        Me.ComboBoxCtaBancaria.SelectedIndex = -1
        Me.ComboBoxCtaBancaria.SelectedItem = Nothing
        Me.ComboBoxCtaBancaria.SelectedText = ""
        Me.ComboBoxCtaBancaria.SelectedValue = Nothing
        Me.ComboBoxCtaBancaria.Size = New System.Drawing.Size(272, 25)
        Me.ComboBoxCtaBancaria.TabIndex = 0
        Me.ComboBoxCtaBancaria.ValueMember = Nothing
        '
        'BtnAgregarCtaPropia
        '
        Me.BtnAgregarCtaPropia.FlatAppearance.BorderSize = 0
        Me.BtnAgregarCtaPropia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAgregarCtaPropia.Image = Global.Principal.My.Resources.Resources.add
        Me.BtnAgregarCtaPropia.Location = New System.Drawing.Point(671, 33)
        Me.BtnAgregarCtaPropia.Name = "BtnAgregarCtaPropia"
        Me.BtnAgregarCtaPropia.Size = New System.Drawing.Size(79, 21)
        Me.BtnAgregarCtaPropia.TabIndex = 5
        Me.BtnAgregarCtaPropia.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Gainsboro
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Location = New System.Drawing.Point(515, 33)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 20)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Importe"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBoxReferencia
        '
        Me.TextBoxReferencia.Location = New System.Drawing.Point(314, 33)
        Me.TextBoxReferencia.MaxLength = 15
        Me.TextBoxReferencia.Name = "TextBoxReferencia"
        Me.TextBoxReferencia.Size = New System.Drawing.Size(195, 20)
        Me.TextBoxReferencia.TabIndex = 3
        Me.TextBoxReferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxImporteCtaPropia
        '
        Me.TextBoxImporteCtaPropia.Location = New System.Drawing.Point(573, 33)
        Me.TextBoxImporteCtaPropia.Name = "TextBoxImporteCtaPropia"
        Me.TextBoxImporteCtaPropia.Size = New System.Drawing.Size(92, 20)
        Me.TextBoxImporteCtaPropia.TabIndex = 4
        Me.TextBoxImporteCtaPropia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Location = New System.Drawing.Point(400, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 25)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Concepto bancario"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Gainsboro
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Location = New System.Drawing.Point(236, 33)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 20)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Referencia"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Gainsboro
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Location = New System.Drawing.Point(3, 33)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(113, 20)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Efectivización"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Gainsboro
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Location = New System.Drawing.Point(3, 3)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(113, 25)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Cuenta bancaria"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabPageCartera
        '
        Me.TabPageCartera.Controls.Add(Me.TableLayoutPanelCartera)
        Me.TabPageCartera.Location = New System.Drawing.Point(4, 22)
        Me.TabPageCartera.Name = "TabPageCartera"
        Me.TabPageCartera.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageCartera.Size = New System.Drawing.Size(844, 225)
        Me.TabPageCartera.TabIndex = 6
        Me.TabPageCartera.Text = "Cartera"
        Me.TabPageCartera.UseVisualStyleBackColor = True
        '
        'TableLayoutPanelCartera
        '
        Me.TableLayoutPanelCartera.ColumnCount = 1
        Me.TableLayoutPanelCartera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelCartera.Controls.Add(Me.FOLVCartera, 0, 1)
        Me.TableLayoutPanelCartera.Controls.Add(Me.PanelCabeceraCartera, 0, 0)
        Me.TableLayoutPanelCartera.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelCartera.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanelCartera.Name = "TableLayoutPanelCartera"
        Me.TableLayoutPanelCartera.RowCount = 2
        Me.TableLayoutPanelCartera.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanelCartera.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelCartera.Size = New System.Drawing.Size(838, 219)
        Me.TableLayoutPanelCartera.TabIndex = 2
        '
        'FOLVCartera
        '
        Me.FOLVCartera.AlternateRowBackColor = System.Drawing.Color.LightSteelBlue
        Me.FOLVCartera.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FOLVCartera.HideSelection = False
        Me.FOLVCartera.Location = New System.Drawing.Point(3, 103)
        Me.FOLVCartera.Name = "FOLVCartera"
        Me.FOLVCartera.ShowGroups = False
        Me.FOLVCartera.ShowHeaderInAllViews = False
        Me.FOLVCartera.Size = New System.Drawing.Size(832, 113)
        Me.FOLVCartera.TabIndex = 1
        Me.FOLVCartera.UseAlternatingBackColors = True
        Me.FOLVCartera.UseCompatibleStateImageBehavior = False
        Me.FOLVCartera.View = System.Windows.Forms.View.Details
        Me.FOLVCartera.VirtualMode = True
        '
        'PanelCabeceraCartera
        '
        Me.PanelCabeceraCartera.Controls.Add(Me.DateTimePickerFechaCheque)
        Me.PanelCabeceraCartera.Controls.Add(Me.ComboBoxLocalidad)
        Me.PanelCabeceraCartera.Controls.Add(Me.ComboBoxBancos)
        Me.PanelCabeceraCartera.Controls.Add(Me.BtnAgregarCheque)
        Me.PanelCabeceraCartera.Controls.Add(Me.Label13)
        Me.PanelCabeceraCartera.Controls.Add(Me.TextBoxDador)
        Me.PanelCabeceraCartera.Controls.Add(Me.TextBoxCUITLibrador)
        Me.PanelCabeceraCartera.Controls.Add(Me.TextBoxReferenciaCartera)
        Me.PanelCabeceraCartera.Controls.Add(Me.TextBoxImporteCartera)
        Me.PanelCabeceraCartera.Controls.Add(Me.Label15)
        Me.PanelCabeceraCartera.Controls.Add(Me.Label24)
        Me.PanelCabeceraCartera.Controls.Add(Me.Label25)
        Me.PanelCabeceraCartera.Controls.Add(Me.Label16)
        Me.PanelCabeceraCartera.Controls.Add(Me.Label17)
        Me.PanelCabeceraCartera.Controls.Add(Me.Label18)
        Me.PanelCabeceraCartera.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelCabeceraCartera.Location = New System.Drawing.Point(3, 3)
        Me.PanelCabeceraCartera.Name = "PanelCabeceraCartera"
        Me.PanelCabeceraCartera.Size = New System.Drawing.Size(832, 94)
        Me.PanelCabeceraCartera.TabIndex = 0
        '
        'DateTimePickerFechaCheque
        '
        Me.DateTimePickerFechaCheque.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerFechaCheque.Location = New System.Drawing.Point(372, 66)
        Me.DateTimePickerFechaCheque.Name = "DateTimePickerFechaCheque"
        Me.DateTimePickerFechaCheque.Size = New System.Drawing.Size(91, 20)
        Me.DateTimePickerFechaCheque.TabIndex = 5
        '
        'ComboBoxLocalidad
        '
        Me.ComboBoxLocalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.ComboBoxLocalidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.ComboBoxLocalidad.BusquedaPorCodigobarra = False
        Me.ComboBoxLocalidad.ColumnasExtras = Nothing
        Me.ComboBoxLocalidad.CustomFormatArt = False
        Me.ComboBoxLocalidad.DataSource = Nothing
        Me.ComboBoxLocalidad.DisplayMember = Nothing
        Me.ComboBoxLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ComboBoxLocalidad.FormularioDeAlta = Nothing
        Me.ComboBoxLocalidad.FormularioDeBusqueda = Nothing
        Me.ComboBoxLocalidad.Location = New System.Drawing.Point(468, 9)
        Me.ComboBoxLocalidad.MaximumSize = New System.Drawing.Size(500, 25)
        Me.ComboBoxLocalidad.MinimumSize = New System.Drawing.Size(200, 25)
        Me.ComboBoxLocalidad.Name = "ComboBoxLocalidad"
        Me.ComboBoxLocalidad.SelectedIndex = -1
        Me.ComboBoxLocalidad.SelectedItem = Nothing
        Me.ComboBoxLocalidad.SelectedText = ""
        Me.ComboBoxLocalidad.SelectedValue = Nothing
        Me.ComboBoxLocalidad.Size = New System.Drawing.Size(279, 25)
        Me.ComboBoxLocalidad.TabIndex = 1
        Me.ComboBoxLocalidad.ValueMember = Nothing
        '
        'ComboBoxBancos
        '
        Me.ComboBoxBancos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.ComboBoxBancos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.ComboBoxBancos.BusquedaPorCodigobarra = False
        Me.ComboBoxBancos.ColumnasExtras = Nothing
        Me.ComboBoxBancos.CustomFormatArt = False
        Me.ComboBoxBancos.DataSource = Nothing
        Me.ComboBoxBancos.DisplayMember = Nothing
        Me.ComboBoxBancos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ComboBoxBancos.FormularioDeAlta = Nothing
        Me.ComboBoxBancos.FormularioDeBusqueda = Nothing
        Me.ComboBoxBancos.Location = New System.Drawing.Point(74, 9)
        Me.ComboBoxBancos.MaximumSize = New System.Drawing.Size(500, 25)
        Me.ComboBoxBancos.MinimumSize = New System.Drawing.Size(200, 25)
        Me.ComboBoxBancos.Name = "ComboBoxBancos"
        Me.ComboBoxBancos.SelectedIndex = -1
        Me.ComboBoxBancos.SelectedItem = Nothing
        Me.ComboBoxBancos.SelectedText = ""
        Me.ComboBoxBancos.SelectedValue = Nothing
        Me.ComboBoxBancos.Size = New System.Drawing.Size(307, 25)
        Me.ComboBoxBancos.TabIndex = 0
        Me.ComboBoxBancos.ValueMember = Nothing
        '
        'BtnAgregarCheque
        '
        Me.BtnAgregarCheque.FlatAppearance.BorderSize = 0
        Me.BtnAgregarCheque.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAgregarCheque.Image = Global.Principal.My.Resources.Resources.add
        Me.BtnAgregarCheque.Location = New System.Drawing.Point(645, 64)
        Me.BtnAgregarCheque.Name = "BtnAgregarCheque"
        Me.BtnAgregarCheque.Size = New System.Drawing.Size(50, 24)
        Me.BtnAgregarCheque.TabIndex = 7
        Me.BtnAgregarCheque.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Gainsboro
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Location = New System.Drawing.Point(468, 66)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 20)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Importe"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBoxDador
        '
        Me.TextBoxDador.Location = New System.Drawing.Point(74, 40)
        Me.TextBoxDador.MaxLength = 50
        Me.TextBoxDador.Name = "TextBoxDador"
        Me.TextBoxDador.Size = New System.Drawing.Size(307, 20)
        Me.TextBoxDador.TabIndex = 2
        Me.TextBoxDador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxCUITLibrador
        '
        Me.TextBoxCUITLibrador.Location = New System.Drawing.Point(507, 40)
        Me.TextBoxCUITLibrador.MaxLength = 11
        Me.TextBoxCUITLibrador.Name = "TextBoxCUITLibrador"
        Me.TextBoxCUITLibrador.Size = New System.Drawing.Size(134, 20)
        Me.TextBoxCUITLibrador.TabIndex = 3
        Me.TextBoxCUITLibrador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxReferenciaCartera
        '
        Me.TextBoxReferenciaCartera.Location = New System.Drawing.Point(123, 66)
        Me.TextBoxReferenciaCartera.MaxLength = 15
        Me.TextBoxReferenciaCartera.Name = "TextBoxReferenciaCartera"
        Me.TextBoxReferenciaCartera.Size = New System.Drawing.Size(134, 20)
        Me.TextBoxReferenciaCartera.TabIndex = 4
        Me.TextBoxReferenciaCartera.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxImporteCartera
        '
        Me.TextBoxImporteCartera.Location = New System.Drawing.Point(541, 66)
        Me.TextBoxImporteCartera.Name = "TextBoxImporteCartera"
        Me.TextBoxImporteCartera.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxImporteCartera.TabIndex = 6
        Me.TextBoxImporteCartera.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Gainsboro
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Location = New System.Drawing.Point(387, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(75, 25)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Localidad"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Gainsboro
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label24.Location = New System.Drawing.Point(387, 40)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(114, 20)
        Me.Label24.TabIndex = 0
        Me.Label24.Text = "CUIT del Librador"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Gainsboro
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label25.Location = New System.Drawing.Point(15, 40)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(53, 20)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "Dador"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Gainsboro
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Location = New System.Drawing.Point(15, 66)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(102, 20)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Nº de Cheque"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Gainsboro
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Location = New System.Drawing.Point(263, 66)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(103, 20)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Fecha de Cobro"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Gainsboro
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.Location = New System.Drawing.Point(15, 9)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(53, 25)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Banco"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabPageArt
        '
        Me.TabPageArt.Controls.Add(Me.TableLayoutPanelArticulos)
        Me.TabPageArt.Location = New System.Drawing.Point(4, 22)
        Me.TabPageArt.Name = "TabPageArt"
        Me.TabPageArt.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageArt.Size = New System.Drawing.Size(844, 225)
        Me.TabPageArt.TabIndex = 0
        Me.TabPageArt.Text = "Artículos"
        Me.TabPageArt.UseVisualStyleBackColor = True
        '
        'TableLayoutPanelArticulos
        '
        Me.TableLayoutPanelArticulos.ColumnCount = 1
        Me.TableLayoutPanelArticulos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelArticulos.Controls.Add(Me.FOLVArticulos, 0, 1)
        Me.TableLayoutPanelArticulos.Controls.Add(Me.PanelCabecera, 0, 0)
        Me.TableLayoutPanelArticulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelArticulos.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanelArticulos.Name = "TableLayoutPanelArticulos"
        Me.TableLayoutPanelArticulos.RowCount = 2
        Me.TableLayoutPanelArticulos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanelArticulos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelArticulos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanelArticulos.Size = New System.Drawing.Size(838, 219)
        Me.TableLayoutPanelArticulos.TabIndex = 0
        '
        'FOLVArticulos
        '
        Me.FOLVArticulos.AlternateRowBackColor = System.Drawing.Color.LightSteelBlue
        Me.FOLVArticulos.HideSelection = False
        Me.FOLVArticulos.Location = New System.Drawing.Point(3, 53)
        Me.FOLVArticulos.Name = "FOLVArticulos"
        Me.FOLVArticulos.ShowGroups = False
        Me.FOLVArticulos.ShowHeaderInAllViews = False
        Me.FOLVArticulos.Size = New System.Drawing.Size(832, 163)
        Me.FOLVArticulos.TabIndex = 12
        Me.FOLVArticulos.UseAlternatingBackColors = True
        Me.FOLVArticulos.UseCellFormatEvents = True
        Me.FOLVArticulos.UseCompatibleStateImageBehavior = False
        Me.FOLVArticulos.View = System.Windows.Forms.View.Details
        Me.FOLVArticulos.VirtualMode = True
        '
        'PanelCabecera
        '
        Me.PanelCabecera.Controls.Add(Me.TextBoxSubtotalArticuloFinal)
        Me.PanelCabecera.Controls.Add(Me.Label1)
        Me.PanelCabecera.Controls.Add(Me.TextBoxImporteFinal)
        Me.PanelCabecera.Controls.Add(Me.ComboBoxArticulos)
        Me.PanelCabecera.Controls.Add(Me.lblSubtotal)
        Me.PanelCabecera.Controls.Add(Me.BtnAgregarArticulo)
        Me.PanelCabecera.Controls.Add(Me.lblAlicuota)
        Me.PanelCabecera.Controls.Add(Me.TextBoxCantidad)
        Me.PanelCabecera.Controls.Add(Me.lblDto)
        Me.PanelCabecera.Controls.Add(Me.Label27)
        Me.PanelCabecera.Controls.Add(Me.lblImporte)
        Me.PanelCabecera.Controls.Add(Me.TextBoxImporteImpInt)
        Me.PanelCabecera.Controls.Add(Me.TextBoxDto)
        Me.PanelCabecera.Controls.Add(Me.TextBoxImporte)
        Me.PanelCabecera.Controls.Add(Me.lblCant)
        Me.PanelCabecera.Controls.Add(Me.ComboBoxArticuloAlicuota)
        Me.PanelCabecera.Controls.Add(Me.Label19)
        Me.PanelCabecera.Controls.Add(Me.TextBoxSubtotalArticulo)
        Me.PanelCabecera.Location = New System.Drawing.Point(3, 3)
        Me.PanelCabecera.Name = "PanelCabecera"
        Me.PanelCabecera.Size = New System.Drawing.Size(832, 44)
        Me.PanelCabecera.TabIndex = 0
        '
        'ComboBoxArticulos
        '
        Me.ComboBoxArticulos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.ComboBoxArticulos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.ComboBoxArticulos.BusquedaPorCodigobarra = False
        Me.ComboBoxArticulos.ColumnasExtras = Nothing
        Me.ComboBoxArticulos.CustomFormatArt = False
        Me.ComboBoxArticulos.DataSource = Nothing
        Me.ComboBoxArticulos.DisplayMember = Nothing
        Me.ComboBoxArticulos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ComboBoxArticulos.FormularioDeAlta = Nothing
        Me.ComboBoxArticulos.FormularioDeBusqueda = Nothing
        Me.ComboBoxArticulos.Location = New System.Drawing.Point(3, 17)
        Me.ComboBoxArticulos.MaximumSize = New System.Drawing.Size(500, 25)
        Me.ComboBoxArticulos.MinimumSize = New System.Drawing.Size(200, 25)
        Me.ComboBoxArticulos.Name = "ComboBoxArticulos"
        Me.ComboBoxArticulos.SelectedIndex = -1
        Me.ComboBoxArticulos.SelectedItem = Nothing
        Me.ComboBoxArticulos.SelectedText = ""
        Me.ComboBoxArticulos.SelectedValue = Nothing
        Me.ComboBoxArticulos.Size = New System.Drawing.Size(346, 25)
        Me.ComboBoxArticulos.TabIndex = 1
        Me.ComboBoxArticulos.ValueMember = Nothing
        '
        'lblSubtotal
        '
        Me.lblSubtotal.BackColor = System.Drawing.Color.Gainsboro
        Me.lblSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtotal.Location = New System.Drawing.Point(713, 3)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(90, 15)
        Me.lblSubtotal.TabIndex = 5
        Me.lblSubtotal.Text = "Subtotal"
        Me.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnAgregarArticulo
        '
        Me.BtnAgregarArticulo.FlatAppearance.BorderSize = 0
        Me.BtnAgregarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAgregarArticulo.Image = Global.Principal.My.Resources.Resources.add
        Me.BtnAgregarArticulo.Location = New System.Drawing.Point(811, 14)
        Me.BtnAgregarArticulo.Name = "BtnAgregarArticulo"
        Me.BtnAgregarArticulo.Size = New System.Drawing.Size(15, 24)
        Me.BtnAgregarArticulo.TabIndex = 11
        Me.BtnAgregarArticulo.UseVisualStyleBackColor = True
        '
        'lblAlicuota
        '
        Me.lblAlicuota.BackColor = System.Drawing.Color.Gainsboro
        Me.lblAlicuota.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAlicuota.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlicuota.Location = New System.Drawing.Point(509, 3)
        Me.lblAlicuota.Name = "lblAlicuota"
        Me.lblAlicuota.Size = New System.Drawing.Size(62, 15)
        Me.lblAlicuota.TabIndex = 4
        Me.lblAlicuota.Text = "Alic. IVA"
        Me.lblAlicuota.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBoxCantidad
        '
        Me.TextBoxCantidad.Location = New System.Drawing.Point(365, 21)
        Me.TextBoxCantidad.Name = "TextBoxCantidad"
        Me.TextBoxCantidad.Size = New System.Drawing.Size(63, 20)
        Me.TextBoxCantidad.TabIndex = 5
        Me.TextBoxCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblDto
        '
        Me.lblDto.BackColor = System.Drawing.Color.Gainsboro
        Me.lblDto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDto.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDto.Location = New System.Drawing.Point(652, 3)
        Me.lblDto.Name = "lblDto"
        Me.lblDto.Size = New System.Drawing.Size(55, 15)
        Me.lblDto.TabIndex = 4
        Me.lblDto.Text = "Dto. (%)"
        Me.lblDto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Gainsboro
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(764, 32)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(65, 15)
        Me.Label27.TabIndex = 4
        Me.Label27.Text = "Imp. Interno"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label27.Visible = False
        '
        'lblImporte
        '
        Me.lblImporte.BackColor = System.Drawing.Color.Gainsboro
        Me.lblImporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporte.Location = New System.Drawing.Point(434, 3)
        Me.lblImporte.Name = "lblImporte"
        Me.lblImporte.Size = New System.Drawing.Size(69, 15)
        Me.lblImporte.TabIndex = 4
        Me.lblImporte.Text = "Importe"
        Me.lblImporte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBoxImporteImpInt
        '
        Me.TextBoxImporteImpInt.Location = New System.Drawing.Point(764, 50)
        Me.TextBoxImporteImpInt.Name = "TextBoxImporteImpInt"
        Me.TextBoxImporteImpInt.Size = New System.Drawing.Size(65, 20)
        Me.TextBoxImporteImpInt.TabIndex = 5
        Me.TextBoxImporteImpInt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBoxImporteImpInt.Visible = False
        '
        'TextBoxImporte
        '
        Me.TextBoxImporte.Location = New System.Drawing.Point(434, 21)
        Me.TextBoxImporte.Name = "TextBoxImporte"
        Me.TextBoxImporte.Size = New System.Drawing.Size(69, 20)
        Me.TextBoxImporte.TabIndex = 6
        Me.TextBoxImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCant
        '
        Me.lblCant.BackColor = System.Drawing.Color.Gainsboro
        Me.lblCant.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCant.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCant.Location = New System.Drawing.Point(365, 3)
        Me.lblCant.Name = "lblCant"
        Me.lblCant.Size = New System.Drawing.Size(63, 15)
        Me.lblCant.TabIndex = 4
        Me.lblCant.Text = "Cantidad"
        Me.lblCant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBoxArticuloAlicuota
        '
        Me.ComboBoxArticuloAlicuota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxArticuloAlicuota.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxArticuloAlicuota.FormattingEnabled = True
        Me.ComboBoxArticuloAlicuota.Location = New System.Drawing.Point(509, 21)
        Me.ComboBoxArticuloAlicuota.Name = "ComboBoxArticuloAlicuota"
        Me.ComboBoxArticuloAlicuota.Size = New System.Drawing.Size(62, 21)
        Me.ComboBoxArticuloAlicuota.TabIndex = 7
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Gainsboro
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(3, 3)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(95, 14)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Artículo / Descripción"
        '
        'TextBoxSubtotalArticulo
        '
        Me.TextBoxSubtotalArticulo.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxSubtotalArticulo.Location = New System.Drawing.Point(713, 21)
        Me.TextBoxSubtotalArticulo.Name = "TextBoxSubtotalArticulo"
        Me.TextBoxSubtotalArticulo.ReadOnly = True
        Me.TextBoxSubtotalArticulo.Size = New System.Drawing.Size(90, 20)
        Me.TextBoxSubtotalArticulo.TabIndex = 10
        Me.TextBoxSubtotalArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TabPageImportes
        '
        Me.TabPageImportes.Controls.Add(Me.FOLVImportes)
        Me.TabPageImportes.Location = New System.Drawing.Point(4, 22)
        Me.TabPageImportes.Name = "TabPageImportes"
        Me.TabPageImportes.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageImportes.Size = New System.Drawing.Size(844, 225)
        Me.TabPageImportes.TabIndex = 7
        Me.TabPageImportes.Text = "Importes"
        Me.TabPageImportes.UseVisualStyleBackColor = True
        '
        'FOLVImportes
        '
        Me.FOLVImportes.AlternateRowBackColor = System.Drawing.Color.LightSteelBlue
        Me.FOLVImportes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FOLVImportes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FOLVImportes.HideSelection = False
        Me.FOLVImportes.Location = New System.Drawing.Point(3, 3)
        Me.FOLVImportes.Name = "FOLVImportes"
        Me.FOLVImportes.ShowGroups = False
        Me.FOLVImportes.ShowHeaderInAllViews = False
        Me.FOLVImportes.Size = New System.Drawing.Size(838, 219)
        Me.FOLVImportes.TabIndex = 2
        Me.FOLVImportes.UseAlternatingBackColors = True
        Me.FOLVImportes.UseCellFormatEvents = True
        Me.FOLVImportes.UseCompatibleStateImageBehavior = False
        Me.FOLVImportes.View = System.Windows.Forms.View.Details
        Me.FOLVImportes.VirtualMode = True
        '
        'TabPageAlicuotas
        '
        Me.TabPageAlicuotas.Controls.Add(Me.FOLVAlicuotas)
        Me.TabPageAlicuotas.Location = New System.Drawing.Point(4, 22)
        Me.TabPageAlicuotas.Name = "TabPageAlicuotas"
        Me.TabPageAlicuotas.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageAlicuotas.Size = New System.Drawing.Size(844, 225)
        Me.TabPageAlicuotas.TabIndex = 1
        Me.TabPageAlicuotas.Text = "Alícuotas"
        Me.TabPageAlicuotas.UseVisualStyleBackColor = True
        '
        'FOLVAlicuotas
        '
        Me.FOLVAlicuotas.AlternateRowBackColor = System.Drawing.Color.LightSteelBlue
        Me.FOLVAlicuotas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FOLVAlicuotas.HideSelection = False
        Me.FOLVAlicuotas.Location = New System.Drawing.Point(3, 3)
        Me.FOLVAlicuotas.Name = "FOLVAlicuotas"
        Me.FOLVAlicuotas.ShowGroups = False
        Me.FOLVAlicuotas.ShowHeaderInAllViews = False
        Me.FOLVAlicuotas.Size = New System.Drawing.Size(838, 219)
        Me.FOLVAlicuotas.TabIndex = 1
        Me.FOLVAlicuotas.UseAlternatingBackColors = True
        Me.FOLVAlicuotas.UseCompatibleStateImageBehavior = False
        Me.FOLVAlicuotas.View = System.Windows.Forms.View.Details
        Me.FOLVAlicuotas.VirtualMode = True
        '
        'TabPageOtros
        '
        Me.TabPageOtros.Controls.Add(Me.TableLayoutPanelTributos)
        Me.TabPageOtros.Location = New System.Drawing.Point(4, 22)
        Me.TabPageOtros.Name = "TabPageOtros"
        Me.TabPageOtros.Size = New System.Drawing.Size(844, 225)
        Me.TabPageOtros.TabIndex = 2
        Me.TabPageOtros.Text = "Otros Tributos"
        Me.TabPageOtros.UseVisualStyleBackColor = True
        '
        'TableLayoutPanelTributos
        '
        Me.TableLayoutPanelTributos.ColumnCount = 1
        Me.TableLayoutPanelTributos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelTributos.Controls.Add(Me.PanelCabeceraTributos, 0, 0)
        Me.TableLayoutPanelTributos.Controls.Add(Me.FOLVOtrosTributos, 0, 1)
        Me.TableLayoutPanelTributos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelTributos.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanelTributos.Name = "TableLayoutPanelTributos"
        Me.TableLayoutPanelTributos.RowCount = 2
        Me.TableLayoutPanelTributos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanelTributos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelTributos.Size = New System.Drawing.Size(844, 225)
        Me.TableLayoutPanelTributos.TabIndex = 3
        '
        'PanelCabeceraTributos
        '
        Me.PanelCabeceraTributos.Controls.Add(Me.BtnAgregarTributo)
        Me.PanelCabeceraTributos.Controls.Add(Me.Label3)
        Me.PanelCabeceraTributos.Controls.Add(Me.Label4)
        Me.PanelCabeceraTributos.Controls.Add(Me.Label26)
        Me.PanelCabeceraTributos.Controls.Add(Me.Label5)
        Me.PanelCabeceraTributos.Controls.Add(Me.TextBoxRefTributo)
        Me.PanelCabeceraTributos.Controls.Add(Me.TextBoxBaseTributo)
        Me.PanelCabeceraTributos.Controls.Add(Me.TextBoxImporteTributo)
        Me.PanelCabeceraTributos.Controls.Add(Me.Label6)
        Me.PanelCabeceraTributos.Controls.Add(Me.ComboBoxDescTributo)
        Me.PanelCabeceraTributos.Controls.Add(Me.ComboBoxTributos)
        Me.PanelCabeceraTributos.Controls.Add(Me.Label7)
        Me.PanelCabeceraTributos.Controls.Add(Me.TextBoxTributoAlic)
        Me.PanelCabeceraTributos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelCabeceraTributos.Location = New System.Drawing.Point(3, 3)
        Me.PanelCabeceraTributos.Name = "PanelCabeceraTributos"
        Me.PanelCabeceraTributos.Size = New System.Drawing.Size(838, 44)
        Me.PanelCabeceraTributos.TabIndex = 3
        '
        'BtnAgregarTributo
        '
        Me.BtnAgregarTributo.FlatAppearance.BorderSize = 0
        Me.BtnAgregarTributo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAgregarTributo.Image = Global.Principal.My.Resources.Resources.add
        Me.BtnAgregarTributo.Location = New System.Drawing.Point(722, 20)
        Me.BtnAgregarTributo.Name = "BtnAgregarTributo"
        Me.BtnAgregarTributo.Size = New System.Drawing.Size(32, 20)
        Me.BtnAgregarTributo.TabIndex = 6
        Me.BtnAgregarTributo.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Gainsboro
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Location = New System.Drawing.Point(652, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Alicuota (%)"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Gainsboro
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Location = New System.Drawing.Point(572, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Base Imp."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Gainsboro
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label26.Location = New System.Drawing.Point(379, 1)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(107, 16)
        Me.Label26.TabIndex = 4
        Me.Label26.Text = "Referencia"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Gainsboro
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Location = New System.Drawing.Point(492, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Importe"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBoxRefTributo
        '
        Me.TextBoxRefTributo.Location = New System.Drawing.Point(379, 20)
        Me.TextBoxRefTributo.MaxLength = 15
        Me.TextBoxRefTributo.Name = "TextBoxRefTributo"
        Me.TextBoxRefTributo.Size = New System.Drawing.Size(107, 20)
        Me.TextBoxRefTributo.TabIndex = 2
        Me.TextBoxRefTributo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxBaseTributo
        '
        Me.TextBoxBaseTributo.Location = New System.Drawing.Point(572, 20)
        Me.TextBoxBaseTributo.Name = "TextBoxBaseTributo"
        Me.TextBoxBaseTributo.Size = New System.Drawing.Size(74, 20)
        Me.TextBoxBaseTributo.TabIndex = 4
        Me.TextBoxBaseTributo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxImporteTributo
        '
        Me.TextBoxImporteTributo.Location = New System.Drawing.Point(492, 20)
        Me.TextBoxImporteTributo.Name = "TextBoxImporteTributo"
        Me.TextBoxImporteTributo.Size = New System.Drawing.Size(74, 20)
        Me.TextBoxImporteTributo.TabIndex = 3
        Me.TextBoxImporteTributo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Gainsboro
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Location = New System.Drawing.Point(128, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(245, 16)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Descripción"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBoxDescTributo
        '
        Me.ComboBoxDescTributo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDescTributo.FormattingEnabled = True
        Me.ComboBoxDescTributo.Location = New System.Drawing.Point(128, 20)
        Me.ComboBoxDescTributo.Name = "ComboBoxDescTributo"
        Me.ComboBoxDescTributo.Size = New System.Drawing.Size(245, 21)
        Me.ComboBoxDescTributo.TabIndex = 1
        '
        'ComboBoxTributos
        '
        Me.ComboBoxTributos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxTributos.FormattingEnabled = True
        Me.ComboBoxTributos.Location = New System.Drawing.Point(6, 20)
        Me.ComboBoxTributos.Name = "ComboBoxTributos"
        Me.ComboBoxTributos.Size = New System.Drawing.Size(116, 21)
        Me.ComboBoxTributos.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Gainsboro
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Location = New System.Drawing.Point(6, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Tipo tributo"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBoxTributoAlic
        '
        Me.TextBoxTributoAlic.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxTributoAlic.Location = New System.Drawing.Point(652, 20)
        Me.TextBoxTributoAlic.Name = "TextBoxTributoAlic"
        Me.TextBoxTributoAlic.Size = New System.Drawing.Size(64, 20)
        Me.TextBoxTributoAlic.TabIndex = 5
        Me.TextBoxTributoAlic.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'FOLVOtrosTributos
        '
        Me.FOLVOtrosTributos.AlternateRowBackColor = System.Drawing.Color.LightSteelBlue
        Me.FOLVOtrosTributos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FOLVOtrosTributos.HideSelection = False
        Me.FOLVOtrosTributos.Location = New System.Drawing.Point(3, 53)
        Me.FOLVOtrosTributos.Name = "FOLVOtrosTributos"
        Me.FOLVOtrosTributos.ShowGroups = False
        Me.FOLVOtrosTributos.ShowHeaderInAllViews = False
        Me.FOLVOtrosTributos.Size = New System.Drawing.Size(838, 169)
        Me.FOLVOtrosTributos.TabIndex = 2
        Me.FOLVOtrosTributos.UseAlternatingBackColors = True
        Me.FOLVOtrosTributos.UseCompatibleStateImageBehavior = False
        Me.FOLVOtrosTributos.View = System.Windows.Forms.View.Details
        Me.FOLVOtrosTributos.VirtualMode = True
        '
        'TabPageCompAsoc
        '
        Me.TabPageCompAsoc.Controls.Add(Me.TableLayoutPanelAsoc)
        Me.TabPageCompAsoc.Location = New System.Drawing.Point(4, 22)
        Me.TabPageCompAsoc.Name = "TabPageCompAsoc"
        Me.TabPageCompAsoc.Size = New System.Drawing.Size(844, 225)
        Me.TabPageCompAsoc.TabIndex = 3
        Me.TabPageCompAsoc.Text = "Comprobantes Asociados"
        Me.TabPageCompAsoc.UseVisualStyleBackColor = True
        '
        'TableLayoutPanelAsoc
        '
        Me.TableLayoutPanelAsoc.ColumnCount = 1
        Me.TableLayoutPanelAsoc.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelAsoc.Controls.Add(Me.PanelCabeceraAsoc, 0, 0)
        Me.TableLayoutPanelAsoc.Controls.Add(Me.FOLVCompAsoc, 0, 1)
        Me.TableLayoutPanelAsoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelAsoc.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanelAsoc.Name = "TableLayoutPanelAsoc"
        Me.TableLayoutPanelAsoc.RowCount = 2
        Me.TableLayoutPanelAsoc.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanelAsoc.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelAsoc.Size = New System.Drawing.Size(844, 225)
        Me.TableLayoutPanelAsoc.TabIndex = 4
        '
        'PanelCabeceraAsoc
        '
        Me.PanelCabeceraAsoc.Controls.Add(Me.LabelCtaCte)
        Me.PanelCabeceraAsoc.Controls.Add(Me.CheckBoxCtaCte)
        Me.PanelCabeceraAsoc.Controls.Add(Me.CheckBoxVerTodos)
        Me.PanelCabeceraAsoc.Controls.Add(Me.ComboBoxAsoc)
        Me.PanelCabeceraAsoc.Controls.Add(Me.BtnAgregarAsoc)
        Me.PanelCabeceraAsoc.Controls.Add(Me.Label9)
        Me.PanelCabeceraAsoc.Controls.Add(Me.TextBoxImporteAsoc)
        Me.PanelCabeceraAsoc.Controls.Add(Me.Label11)
        Me.PanelCabeceraAsoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelCabeceraAsoc.Location = New System.Drawing.Point(3, 3)
        Me.PanelCabeceraAsoc.Name = "PanelCabeceraAsoc"
        Me.PanelCabeceraAsoc.Size = New System.Drawing.Size(838, 44)
        Me.PanelCabeceraAsoc.TabIndex = 3
        '
        'LabelCtaCte
        '
        Me.LabelCtaCte.AutoSize = True
        Me.LabelCtaCte.Location = New System.Drawing.Point(462, 26)
        Me.LabelCtaCte.Name = "LabelCtaCte"
        Me.LabelCtaCte.Size = New System.Drawing.Size(0, 13)
        Me.LabelCtaCte.TabIndex = 6
        '
        'CheckBoxCtaCte
        '
        Me.CheckBoxCtaCte.AutoSize = True
        Me.CheckBoxCtaCte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxCtaCte.Location = New System.Drawing.Point(620, 3)
        Me.CheckBoxCtaCte.Name = "CheckBoxCtaCte"
        Me.CheckBoxCtaCte.Size = New System.Drawing.Size(201, 19)
        Me.CheckBoxCtaCte.TabIndex = 5
        Me.CheckBoxCtaCte.TabStop = False
        Me.CheckBoxCtaCte.Text = "Visualizar Cuenta Corriente"
        Me.CheckBoxCtaCte.UseVisualStyleBackColor = True
        '
        'CheckBoxVerTodos
        '
        Me.CheckBoxVerTodos.AutoSize = True
        Me.CheckBoxVerTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxVerTodos.Location = New System.Drawing.Point(620, 23)
        Me.CheckBoxVerTodos.Name = "CheckBoxVerTodos"
        Me.CheckBoxVerTodos.Size = New System.Drawing.Size(174, 19)
        Me.CheckBoxVerTodos.TabIndex = 5
        Me.CheckBoxVerTodos.TabStop = False
        Me.CheckBoxVerTodos.Text = "Incluir Cbtes. Saldados"
        Me.CheckBoxVerTodos.UseVisualStyleBackColor = True
        '
        'ComboBoxAsoc
        '
        Me.ComboBoxAsoc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.ComboBoxAsoc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.ComboBoxAsoc.BusquedaPorCodigobarra = False
        Me.ComboBoxAsoc.ColumnasExtras = Nothing
        Me.ComboBoxAsoc.CustomFormatArt = False
        Me.ComboBoxAsoc.DataSource = Nothing
        Me.ComboBoxAsoc.DisplayMember = Nothing
        Me.ComboBoxAsoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ComboBoxAsoc.FormularioDeAlta = Nothing
        Me.ComboBoxAsoc.FormularioDeBusqueda = Nothing
        Me.ComboBoxAsoc.Location = New System.Drawing.Point(3, 16)
        Me.ComboBoxAsoc.MaximumSize = New System.Drawing.Size(500, 25)
        Me.ComboBoxAsoc.MinimumSize = New System.Drawing.Size(200, 25)
        Me.ComboBoxAsoc.Name = "ComboBoxAsoc"
        Me.ComboBoxAsoc.SelectedIndex = -1
        Me.ComboBoxAsoc.SelectedItem = Nothing
        Me.ComboBoxAsoc.SelectedText = ""
        Me.ComboBoxAsoc.SelectedValue = Nothing
        Me.ComboBoxAsoc.Size = New System.Drawing.Size(330, 25)
        Me.ComboBoxAsoc.TabIndex = 0
        Me.ComboBoxAsoc.ValueMember = Nothing
        '
        'BtnAgregarAsoc
        '
        Me.BtnAgregarAsoc.FlatAppearance.BorderSize = 0
        Me.BtnAgregarAsoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAgregarAsoc.Image = Global.Principal.My.Resources.Resources.add
        Me.BtnAgregarAsoc.Location = New System.Drawing.Point(424, 20)
        Me.BtnAgregarAsoc.Name = "BtnAgregarAsoc"
        Me.BtnAgregarAsoc.Size = New System.Drawing.Size(32, 20)
        Me.BtnAgregarAsoc.TabIndex = 2
        Me.BtnAgregarAsoc.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Gainsboro
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Location = New System.Drawing.Point(344, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 18)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Importe"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBoxImporteAsoc
        '
        Me.TextBoxImporteAsoc.Location = New System.Drawing.Point(344, 21)
        Me.TextBoxImporteAsoc.Name = "TextBoxImporteAsoc"
        Me.TextBoxImporteAsoc.Size = New System.Drawing.Size(74, 20)
        Me.TextBoxImporteAsoc.TabIndex = 1
        Me.TextBoxImporteAsoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Gainsboro
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Location = New System.Drawing.Point(3, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(330, 18)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Comprobante asociado"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FOLVCompAsoc
        '
        Me.FOLVCompAsoc.AlternateRowBackColor = System.Drawing.Color.LightSteelBlue
        Me.FOLVCompAsoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FOLVCompAsoc.HideSelection = False
        Me.FOLVCompAsoc.Location = New System.Drawing.Point(3, 53)
        Me.FOLVCompAsoc.Name = "FOLVCompAsoc"
        Me.FOLVCompAsoc.ShowGroups = False
        Me.FOLVCompAsoc.ShowHeaderInAllViews = False
        Me.FOLVCompAsoc.Size = New System.Drawing.Size(838, 169)
        Me.FOLVCompAsoc.TabIndex = 2
        Me.FOLVCompAsoc.UseAlternatingBackColors = True
        Me.FOLVCompAsoc.UseCompatibleStateImageBehavior = False
        Me.FOLVCompAsoc.View = System.Windows.Forms.View.Details
        Me.FOLVCompAsoc.VirtualMode = True
        '
        'TabPageObs
        '
        Me.TabPageObs.Controls.Add(Me.TextBoxObservaciones)
        Me.TabPageObs.Location = New System.Drawing.Point(4, 22)
        Me.TabPageObs.Name = "TabPageObs"
        Me.TabPageObs.Size = New System.Drawing.Size(844, 225)
        Me.TabPageObs.TabIndex = 4
        Me.TabPageObs.Text = "Observaciones"
        Me.TabPageObs.UseVisualStyleBackColor = True
        '
        'TextBoxObservaciones
        '
        Me.TextBoxObservaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxObservaciones.Location = New System.Drawing.Point(165, 56)
        Me.TextBoxObservaciones.MaxLength = 320
        Me.TextBoxObservaciones.Multiline = True
        Me.TextBoxObservaciones.Name = "TextBoxObservaciones"
        Me.TextBoxObservaciones.Size = New System.Drawing.Size(440, 112)
        Me.TextBoxObservaciones.TabIndex = 0
        '
        'ImgList
        '
        Me.ImgList.ImageStream = CType(resources.GetObject("ImgList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImgList.Images.SetKeyName(0, "checked")
        Me.ImgList.Images.SetKeyName(1, "unchecked")
        Me.ImgList.Images.SetKeyName(2, "edit")
        '
        'TextBoxDto
        '
        Me.TextBoxDto.Location = New System.Drawing.Point(652, 21)
        Me.TextBoxDto.Name = "TextBoxDto"
        Me.TextBoxDto.Size = New System.Drawing.Size(55, 20)
        Me.TextBoxDto.TabIndex = 9
        Me.TextBoxDto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(577, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 15)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Importe Final"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBoxImporteFinal
        '
        Me.TextBoxImporteFinal.Location = New System.Drawing.Point(577, 21)
        Me.TextBoxImporteFinal.Name = "TextBoxImporteFinal"
        Me.TextBoxImporteFinal.Size = New System.Drawing.Size(69, 20)
        Me.TextBoxImporteFinal.TabIndex = 8
        Me.TextBoxImporteFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBoxSubtotalArticuloFinal
        '
        Me.TextBoxSubtotalArticuloFinal.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxSubtotalArticuloFinal.Location = New System.Drawing.Point(713, 21)
        Me.TextBoxSubtotalArticuloFinal.Name = "TextBoxSubtotalArticuloFinal"
        Me.TextBoxSubtotalArticuloFinal.ReadOnly = True
        Me.TextBoxSubtotalArticuloFinal.Size = New System.Drawing.Size(90, 20)
        Me.TextBoxSubtotalArticuloFinal.TabIndex = 11
        Me.TextBoxSubtotalArticuloFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CtlDetalleCbteAnterior
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControlDetalleCbte)
        Me.DoubleBuffered = True
        Me.Name = "CtlDetalleCbteAnterior"
        Me.Size = New System.Drawing.Size(852, 251)
        Me.TabControlDetalleCbte.ResumeLayout(False)
        Me.TabPageCtasPropias.ResumeLayout(False)
        Me.TableLayoutPanelCtasPropias.ResumeLayout(False)
        CType(Me.FOLVCtasPropias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelCabeceraCtasPropias.ResumeLayout(False)
        Me.PanelCabeceraCtasPropias.PerformLayout()
        Me.TabPageCartera.ResumeLayout(False)
        Me.TableLayoutPanelCartera.ResumeLayout(False)
        CType(Me.FOLVCartera, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelCabeceraCartera.ResumeLayout(False)
        Me.PanelCabeceraCartera.PerformLayout()
        Me.TabPageArt.ResumeLayout(False)
        Me.TableLayoutPanelArticulos.ResumeLayout(False)
        CType(Me.FOLVArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelCabecera.ResumeLayout(False)
        Me.PanelCabecera.PerformLayout()
        Me.TabPageImportes.ResumeLayout(False)
        CType(Me.FOLVImportes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageAlicuotas.ResumeLayout(False)
        CType(Me.FOLVAlicuotas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageOtros.ResumeLayout(False)
        Me.TableLayoutPanelTributos.ResumeLayout(False)
        Me.PanelCabeceraTributos.ResumeLayout(False)
        Me.PanelCabeceraTributos.PerformLayout()
        CType(Me.FOLVOtrosTributos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageCompAsoc.ResumeLayout(False)
        Me.TableLayoutPanelAsoc.ResumeLayout(False)
        Me.PanelCabeceraAsoc.ResumeLayout(False)
        Me.PanelCabeceraAsoc.PerformLayout()
        CType(Me.FOLVCompAsoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageObs.ResumeLayout(False)
        Me.TabPageObs.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControlDetalleCbte As System.Windows.Forms.TabControl
    Friend WithEvents TabPageArt As System.Windows.Forms.TabPage
    Friend WithEvents BtnAgregarArticulo As System.Windows.Forms.Button
    Friend WithEvents lblSubtotal As System.Windows.Forms.Label
    Friend WithEvents lblAlicuota As System.Windows.Forms.Label
    Friend WithEvents lblImporte As System.Windows.Forms.Label
    Friend WithEvents lblCant As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TextBoxSubtotalArticulo As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxImporte As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxArticuloAlicuota As System.Windows.Forms.ComboBox
    Friend WithEvents TabPageAlicuotas As System.Windows.Forms.TabPage
    Friend WithEvents FOLVAlicuotas As BrightIdeasSoftware.FastObjectListView
    Friend WithEvents TabPageOtros As System.Windows.Forms.TabPage
    Friend WithEvents FOLVOtrosTributos As BrightIdeasSoftware.FastObjectListView
    Friend WithEvents TabPageCompAsoc As System.Windows.Forms.TabPage
    Friend WithEvents TabPageObs As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanelArticulos As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FOLVArticulos As BrightIdeasSoftware.FastObjectListView
    Friend WithEvents PanelCabecera As System.Windows.Forms.Panel
    Friend WithEvents TextBoxCantidad As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxArticulos As Principal.CtlCustomCombo
    Friend WithEvents lblDto As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanelTributos As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents PanelCabeceraTributos As System.Windows.Forms.Panel
    Friend WithEvents BtnAgregarTributo As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBoxBaseTributo As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxImporteTributo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxTributos As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBoxTributoAlic As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxDescTributo As System.Windows.Forms.ComboBox
    Friend WithEvents TableLayoutPanelAsoc As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents PanelCabeceraAsoc As System.Windows.Forms.Panel
    Friend WithEvents BtnAgregarAsoc As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBoxImporteAsoc As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents FOLVCompAsoc As BrightIdeasSoftware.FastObjectListView
    Friend WithEvents ComboBoxAsoc As Principal.CtlCustomCombo
    Friend WithEvents TabPageCtasPropias As System.Windows.Forms.TabPage
    Friend WithEvents TabPageCartera As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanelCtasPropias As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FOLVCtasPropias As BrightIdeasSoftware.FastObjectListView
    Friend WithEvents PanelCabeceraCtasPropias As System.Windows.Forms.Panel
    Friend WithEvents ComboBoxCtaBancaria As Principal.CtlCustomCombo
    Friend WithEvents BtnAgregarCtaPropia As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextBoxImporteCtaPropia As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxConceptoBancario As Principal.CtlCustomCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerEfectivizacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBoxReferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanelCartera As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FOLVCartera As BrightIdeasSoftware.FastObjectListView
    Friend WithEvents PanelCabeceraCartera As System.Windows.Forms.Panel
    Friend WithEvents DateTimePickerFechaCheque As System.Windows.Forms.DateTimePicker
    Friend WithEvents ComboBoxLocalidad As Principal.CtlCustomCombo
    Friend WithEvents ComboBoxBancos As Principal.CtlCustomCombo
    Friend WithEvents BtnAgregarCheque As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextBoxReferenciaCartera As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxImporteCartera As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TextBoxDador As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCUITLibrador As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents ImgList As System.Windows.Forms.ImageList
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TextBoxRefTributo As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TextBoxImporteImpInt As System.Windows.Forms.TextBox
    Friend WithEvents TabPageImportes As System.Windows.Forms.TabPage
    Friend WithEvents FOLVImportes As BrightIdeasSoftware.FastObjectListView
    Friend WithEvents CheckBoxVerTodos As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxCtaCte As System.Windows.Forms.CheckBox
    Friend WithEvents LabelCtaCte As System.Windows.Forms.Label
    Friend WithEvents TextBoxDto As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxImporteFinal As TextBox
    Friend WithEvents TextBoxSubtotalArticuloFinal As TextBox
End Class
