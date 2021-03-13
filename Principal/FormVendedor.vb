Public Class FormVendedor

    'entidad
    Property Entidad As Entidades.Vendedor

    'repositorios de tablas
    Private _repositorio As New CapaLogica.VendedorCLog
    Private _repositorioZonas As New CapaLogica.ZonaCLog
    Private _repositorioLocalidades As New CapaLogica.LocalidadCLog
    Private _repositorioProvincias As New CapaLogica.ProvinciasCLog
    Private _repositorioDocumentos As New CapaLogica.TipodocumentoCLog
    Private _repositorioCondicionesIVA As New CapaLogica.TiporesponsableCLog
    'Private _repositorioSupervisor As New CapaLogica.SupervisorCLog
    'Private _repositorioAcompaniante As New CapaLogica.AcompanianteCLog

    Private Sub InicializarCombos()
        InicializarComboZonas()
        InicializarComboProvincias()
        InicializarComboLocalidades(0)
        InicializarComboDocumentos()
        InicializarComboCondicionesIVA()
        'InicializarComboSupervisor()
        'InicializarComboAcompaniante()
    End Sub

    Private Sub InicializarComboZonas()
        With Me.cboZonas
            .ValueMember = "Id"
            .DisplayMember = "NombreyCodigo"
            .DataSource = _repositorioZonas.GetAll
            .DropDownStyle = ComboBoxStyle.DropDownList
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .FormularioDeAlta = FormZona
            .Inicializar()
            .SelectedIndex = -1
        End With
    End Sub

    'Private Sub InicializarComboSupervisor()
    '    With Me.cboSupervisor
    '        .ValueMember = "Id"
    '        .DisplayMember = "Nombre"
    '        .DataSource = _repositorioSupervisor.GetAll
    '        .DropDownStyle = ComboBoxStyle.DropDownList
    '        .AutoCompleteMode = AutoCompleteMode.Suggest
    '        .AutoCompleteSource = AutoCompleteSource.ListItems
    '        '.FormularioDeAlta = FormSupervisor
    '        .Inicializar()
    '        .SelectedIndex = -1
    '    End With
    'End Sub

    'Private Sub InicializarComboAcompaniante()
    '    With Me.cboAcompaniante
    '        .ValueMember = "Id"
    '        .DisplayMember = "Nombre"
    '        .DataSource = _repositorioAcompaniante.GetAll
    '        .DropDownStyle = ComboBoxStyle.DropDownList
    '        .AutoCompleteMode = AutoCompleteMode.Suggest
    '        .AutoCompleteSource = AutoCompleteSource.ListItems
    '        '.FormularioDeAlta = FormAcompaniante
    '        .Inicializar()
    '        .SelectedIndex = -1
    '    End With
    'End Sub

    Private Sub InicializarComboLocalidades(ByVal provincia As UInt32)
        Dim c As BrightIdeasSoftware.OLVColumn = Nothing
        Dim cols As New List(Of BrightIdeasSoftware.OLVColumn)

        c = New BrightIdeasSoftware.OLVColumn
        c.Text = "Provincia"
        c.AspectName = "Provincia"
        c.MinimumWidth = 125
        c.TextAlign = HorizontalAlignment.Center
        c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        cols.Add(c)

        With Me.cboLocalidad
            .ColumnasExtras = cols
            .ValueMember = "Id"
            .DisplayMember = "Nombre"
            .DataSource = _repositorioLocalidades.GetByProvincia(provincia)
            .SelectedIndex = -1
            .DropDownStyle = ComboBoxStyle.DropDownList
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .FormularioDeAlta = FormLocalidad
            .Inicializar()
            .SelectedValue = My.Settings.LocalidadDefault
        End With
    End Sub

    Private Sub InicializarComboProvincias()
        'provincias
        With Me.cboProvincia
            .ValueMember = "Id"
            .DisplayMember = "NombreyCodigo"
            .DataSource = _repositorioProvincias.GetAll
            .DropDownStyle = ComboBoxStyle.DropDownList
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .FormularioDeAlta = FormProvincias
            .Inicializar()
            .SelectedValue = -1
        End With
    End Sub

    Private Sub InicializarComboDocumentos()
        'documentos
        With Me.cboTipoDoc
            .ValueMember = "Codigo"
            .DisplayMember = "Descripcion"
            .DataSource = _repositorioDocumentos.GetAll
            .DropDownStyle = ComboBoxStyle.DropDownList
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub InicializarComboCondicionesIVA()
        'responsabilidades
        With Me.cboTipoResp
            .ValueMember = "Codigo"
            .DisplayMember = "Descripcion"
            .DataSource = _repositorioCondicionesIVA.GetAll
            .DropDownStyle = ComboBoxStyle.DropDownList
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .Inicializar()
            .SelectedIndex = -1
        End With
    End Sub
    'inicializo formulario, limpieza o carga de valores
    Private Sub InicializarFormulario()

        'limpieza de controles
        For Each c As Control In Me.Controls
            Select Case c.GetType
                Case GetType(TextBox) : DirectCast(c, TextBox).Text = ""
                Case GetType(ComboBox) : DirectCast(c, ComboBox).SelectedIndex = -1
                Case GetType(CheckBox) : DirectCast(c, CheckBox).Checked = False
                Case GetType(NumericUpDown) : DirectCast(c, NumericUpDown).Value = 0
            End Select
        Next

        InicializarCombos()

        'el campo id no se puede modificar cuando es autoincremental
        Me.TextBoxId.Enabled = False

        'editar registro
        If Not Entidad Is Nothing Then

            Me.TextBoxId.Text = Entidad.Id
            Me.TextBoxNombre.Text = Entidad.Nombre
            Me.TextBoxDomicilio.Text = Entidad.Domicilio
            Me.cboProvincia.SelectedValue = Entidad.Provincia
            Me.cboLocalidad.SelectedValue = Entidad.Localidad
            Me.TextBoxTelefono.Text = Entidad.Telefono
            Me.TextBoxEmail.Text = Entidad.Email
            Me.TextBoxDocumentoNumero.Text = Entidad.Documento
            Me.cboTipoDoc.SelectedValue = Entidad.Tipodocumento
            Me.cboTipoResp.SelectedValue = Entidad.Tiporesponsable
            Me.cboZonas.SelectedValue = Entidad.Zona
            'Me.cboSupervisor.SelectedValue = Entidad.Supervisor
            'Me.cboAcompaniante.SelectedValue = Entidad.Acompaniante
            Me.NumericUpDownComision.Value = Entidad.Comision
            Me.TextBoxObservacion.Text = Entidad.Observacion

            Me.Text = "Editar registro"

        Else 'nuevo registro, valores por defecto

            Me.Text = "Nuevo registro"
            Me.TextBoxId.Text = "0"
            Me.TextBoxDocumentoNumero.Text = "0"
            Me.cboProvincia.SelectedValue = My.Settings.IdProvinciaDefault
            Me.cboTipoDoc.SelectedValue = My.Settings.DocumentoDefault
            Me.cboTipoResp.SelectedValue = My.Settings.ResponsabilidadDefault
            Me.cboZonas.SelectedValue = Convert.ToUInt32(1)
            'Me.cboSupervisor.SelectedValue = Convert.ToUInt32(1)
            'Me.cboAcompaniante.SelectedValue = Convert.ToUInt32(1)
        End If

        Me.TextBoxNombre.Select()

    End Sub

    Private Sub FormVendedor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'iniciar formulario
        InicializarFormulario()
    End Sub

    Private Sub CustomGotFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = Color.LightGreen

        If sender.GetType = GetType(TextBox) Then
            DirectCast(sender, TextBox).Font = New Font(DirectCast(sender, TextBox).Font, FontStyle.Bold)

            If DirectCast(sender, TextBox).Multiline Then
                DirectCast(sender, TextBox).Select(DirectCast(sender, TextBox).Text.Length, 0)
            End If
        ElseIf sender.GetType = GetType(NumericUpDown) Then
            DirectCast(sender, NumericUpDown).Font = New Font(DirectCast(sender, NumericUpDown).Font, FontStyle.Bold)
            DirectCast(sender, NumericUpDown).Select(0, DirectCast(sender, NumericUpDown).Text.Length)
        End If

    End Sub

    Private Sub CustomLostFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = SystemColors.Window

        If sender.GetType = GetType(TextBox) Then
            DirectCast(sender, TextBox).Font = New Font(DirectCast(sender, TextBox).Font, FontStyle.Regular)
        ElseIf sender.GetType = GetType(NumericUpDown) Then
            DirectCast(sender, NumericUpDown).Font = New Font(DirectCast(sender, NumericUpDown).Font, FontStyle.Regular)
        End If

    End Sub

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        For Each c As Control In Me.Controls
            Select Case c.GetType
                Case GetType(TextBox), GetType(ComboBox), GetType(NumericUpDown)
                    AddHandler c.GotFocus, AddressOf CustomGotFocus
                    AddHandler c.LostFocus, AddressOf CustomLostFocus
                    AddHandler c.PreviewKeyDown, AddressOf CustomPreviewKeyDown
                Case GetType(GroupBox)
                    ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
                    For Each d As Control In c.Controls
                        Select Case d.GetType
                            Case GetType(TextBox), GetType(ComboBox), GetType(NumericUpDown)
                                AddHandler d.GotFocus, AddressOf CustomGotFocus
                                AddHandler d.LostFocus, AddressOf CustomLostFocus
                                AddHandler d.PreviewKeyDown, AddressOf CustomPreviewKeyDown
                        End Select
                    Next
            End Select
        Next

        AddHandler Me.KeyDown, AddressOf FormularioKeyDown
        AddHandler Me.NumericUpDownComision.KeyDown, AddressOf FormularioKeyDown
    End Sub

    Private Sub CustomPreviewKeyDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs)
        If e.KeyCode = Keys.Enter Then
            If sender Is cboProvincia Then
                cboLocalidad.Focus()
            ElseIf sender Is cboLocalidad Then
                Me.TextBoxTelefono.Focus()
            End If
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Cancelar()
    End Sub

    Private Sub Cancelar()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Guardar()

        Try
            Select Case DirectCast(Me.cboTipoDoc.SelectedItem, Entidades.Tipodocumento).Codigo
                Case DOCUMENTO_CUIT
                    If Me.TextBoxDocumentoNumero.Text.Length <> 11 Then
                        Throw New Exception("El nro. de CUIT ingresado no es correcto")
                    ElseIf IsNumeric(Me.TextBoxDocumentoNumero.Text) = False Then
                        Throw New Exception("El nro. de CUIT ingresado no es correcto")
                    Else
                        If Not General.VerificaCuit(Me.TextBoxDocumentoNumero.Text) Then
                            Throw New Exception("El nro. de CUIT ingresado no es válido")
                        End If
                    End If
                Case DOCUMENTO_DNI
                    If Me.TextBoxDocumentoNumero.Text.Length = 0 Then
                        Throw New Exception("El nro. de documento ingresado no es correcto")
                    End If
            End Select

            If Not ValidateEmail(Me.TextBoxEmail.Text) Then
                Throw New Exception("El Email ingresado no es válido")
            End If

            'actualizo los valores de la entidad que se desea persistir
            If Entidad Is Nothing Then
                Entidad = New Entidades.Vendedor
            End If

            Entidad.Nombre = Me.TextBoxNombre.Text
            Entidad.Domicilio = Me.TextBoxDomicilio.Text.Trim
            Entidad.Provincia = Convert.ToUInt32(Me.cboProvincia.SelectedValue)
            Entidad.Localidad = Convert.ToUInt32(Me.cboLocalidad.SelectedValue)
            Entidad.Telefono = Me.TextBoxTelefono.Text
            Entidad.Email = Me.TextBoxEmail.Text
            Entidad.Documento = Me.TextBoxDocumentoNumero.Text
            Entidad.Tipodocumento = Convert.ToUInt32(Me.cboTipoDoc.SelectedValue)
            Entidad.Tiporesponsable = Convert.ToUInt32(Me.cboTipoResp.SelectedValue)
            Entidad.Zona = Convert.ToUInt32(Me.cboZonas.SelectedValue)
            'Entidad.Acompaniante = Convert.ToUInt32(Me.cboAcompaniante.SelectedValue)
            'Entidad.Supervisor = Convert.ToUInt32(Me.cboSupervisor.SelectedValue)
            Entidad.Comision = Me.NumericUpDownComision.Value
            Entidad.Observacion = Me.TextBoxObservacion.Text.Trim

            'envio los nuevos datos al repositor para actualizar
            _repositorio.Save(Entidad)

            If _repositorio.HasError Then

                MessageBox.Show(_repositorio.mensajes.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                MessageBox.Show("La operación ha finalizado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                Me.DialogResult = Windows.Forms.DialogResult.OK

                Me.Close()

            End If

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Guardar()
    End Sub

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Enter
                If sender Is Me.NumericUpDownComision Then
                    Me.TextBoxObservacion.Focus()
                ElseIf Me.ActiveControl.Name <> "TextBoxDomicilio" And Me.ActiveControl.Name <> "TextBoxObservacion" Then
                    SendKeys.Send("{TAB}")
                End If
            Case Keys.F12 : Guardar()
            Case Keys.Escape : Cancelar()
        End Select
    End Sub

    Private Sub cboProvincia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProvincia.SelectedIndexChanged
        InicializarComboLocalidades(Me.cboProvincia.SelectedValue)
        cboLocalidad.Focus()
    End Sub

End Class