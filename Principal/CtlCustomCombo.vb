Public Class CtlCustomCombo
    Property BusquedaPorCodigobarra As Boolean = False
    Property FormularioDeAlta As Object = Nothing
    Property FormularioDeBusqueda As FormBusqueda
    Property ValueMember As String
    Property DisplayMember As String
    Property CustomFormatArt As Boolean
    Property DataSource As Object
    Property AutoCompleteMode As AutoCompleteMode = Windows.Forms.AutoCompleteMode.None
    Property AutoCompleteSource As AutoCompleteSource = Windows.Forms.AutoCompleteSource.None
    Property DropDownStyle As ComboBoxStyle = ComboBoxStyle.DropDown
    Property ColumnasExtras As List(Of BrightIdeasSoftware.OLVColumn) = Nothing
    Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Event AltadeRegistroFinalizada()
    Event CodigobarraEncontrado()
    Private _ejecutaEvento As Boolean
    Event CodigoEncontrado()
    Event CodigoNoEncontrado()
    Event DejarFoco()

    Public Sub FocoDetalle()
        Me.ActiveControl = Me.ComboBoxDetalle
        Me.ComboBoxDetalle.Select()
        Me.ComboBoxDetalle.Focus()
        Application.DoEvents()
    End Sub

    ReadOnly Property Texto As String
        Get
            Return Me.ComboBoxDetalle.Text
        End Get
    End Property

    Public Property SelectedText As String
        Get
            Return Me.ComboBoxDetalle.SelectedText
        End Get

        Set(ByVal value As String)
            Me.ComboBoxDetalle.SelectedText = value
        End Set
    End Property

    Public Property SelectedValue As Object
        Get
            Return Me.ComboBoxDetalle.SelectedValue
        End Get

        Set(ByVal value As Object)
            Me.ComboBoxDetalle.SelectedValue = value
        End Set
    End Property

    Public Property SelectedItem As Object
        Get
            Return Me.ComboBoxDetalle.SelectedItem
        End Get

        Set(ByVal value As Object)
            Me.ComboBoxDetalle.SelectedItem = value
        End Set
    End Property

    Public Property SelectedIndex As Integer
        Get
            Return Me.ComboBoxDetalle.SelectedIndex
        End Get

        Set(ByVal value As Integer)
            Me.ComboBoxDetalle.SelectedIndex = value
        End Set
    End Property

    Public ReadOnly Property Items As ComboBox.ObjectCollection
        Get
            Return Me.ComboBoxDetalle.Items
        End Get
    End Property

    Public Sub Inicializar()

        _ejecutaEvento = False

        With Me.ComboBoxDetalle
            .ValueMember = Me.ValueMember
            .DisplayMember = Me.DisplayMember
            .DataSource = Me.DataSource

            If Me.DropDownStyle = ComboBoxStyle.DropDownList Then
                .DropDownStyle = Me.DropDownStyle
            Else
                .AutoCompleteMode = Me.AutoCompleteMode
                .AutoCompleteSource = Me.AutoCompleteSource
            End If

        End With

        Me.BtnNuevo.Enabled = Not FormularioDeAlta Is Nothing

        _ejecutaEvento = True


    End Sub

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        AddHandler BtnBuscar.Click, AddressOf DesplegarBusqueda
        AddHandler BtnNuevo.Click, AddressOf DesplegarAlta

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().      
        AddHandler Me.ComboBoxDetalle.GotFocus, AddressOf CustomGotFocus
        AddHandler Me.ComboBoxDetalle.LostFocus, AddressOf CustomLostFocus

        AddHandler Me.ComboBoxDetalle.KeyDown, AddressOf CustomKeyDown

    End Sub

    Private Sub CustomGotFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = Color.LightGreen
    End Sub

    Private Sub CustomLostFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = SystemColors.Window
    End Sub

    Private Sub DesplegarBusqueda(ByVal sender As Object, ByVal e As EventArgs)

        FormularioDeBusqueda = New FormBusqueda
        FormularioDeBusqueda.CustomFormatArt = Me.CustomFormatArt
        FormularioDeBusqueda.DataSource = Me.DataSource
        FormularioDeBusqueda.DisplayMember = Me.DisplayMember
        FormularioDeBusqueda.ValueMember = Me.ValueMember
        FormularioDeBusqueda.Columnas = Me.ColumnasExtras

        If FormularioDeBusqueda.ShowDialog(Me) = DialogResult.OK Then
            Me.ComboBoxDetalle.SelectedItem = FormularioDeBusqueda.SelectedItem
        End If

        FormularioDeBusqueda.Dispose()

        Me.ComboBoxDetalle.Focus()

    End Sub

    Private Sub DesplegarAlta(ByVal sender As Object, ByVal e As EventArgs)

        If BtnNuevo.Enabled Then

            FormularioDeAlta.Entidad = Nothing

            If FormularioDeAlta.ShowDialog(Me) = DialogResult.OK Then
                If FormularioDeAlta.Entidad IsNot Nothing Then

                    Me.DataSource.add(FormularioDeAlta.Entidad)
                    Me.ComboBoxDetalle.DataSource = Nothing

                    Inicializar()


                    RaiseEvent AltadeRegistroFinalizada()

                End If
            End If

            Me.ComboBoxDetalle.Focus()

        End If
    End Sub


    Private Sub CustomKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)

        Select Case e.KeyCode
            Case Keys.F1
                If Me.BtnBuscar.Enabled Then
                    e.Handled = True
                    DesplegarBusqueda(sender, Nothing)
                End If
            Case Keys.Enter
                If Me.ComboBoxDetalle.Tag = "YesFocus" Then
                    SendKeys.Send(vbTab)
                End If
                'If Me.ComboBoxDetalle.Text.Length <> 0 Then
                '    'If IsNumeric(Me.ComboBoxDetalle.Text) Then
                '    e.Handled = True
                '    FindValue(Me.ComboBoxDetalle.Text)
                '    'End If
                '    'Else
                '    'SendKeys.Send(vbTab)
                'End If

                If Me.ComboBoxDetalle.SelectedValue IsNot Nothing Then
                    RaiseEvent CodigoEncontrado()

                    '                    SendKeys.Send(vbTab)

                Else
                    If Me.ComboBoxDetalle.Text.Length <> 0 Then
                        'If IsNumeric(Me.ComboBoxDetalle.Text) Then
                        'e.Handled = True
                        FindValue(Me.ComboBoxDetalle.Text)
                        'End If
                        'Else
                        'SendKeys.Send(vbTab)
                    End If
                End If

        End Select

    End Sub

    Private Sub FindValue(ByVal value As String)

        Me.ComboBoxDetalle.SelectedValue = value

        If Me.ComboBoxDetalle.SelectedValue IsNot Nothing Then
            RaiseEvent CodigoEncontrado()
        Else
            RaiseEvent CodigoNoEncontrado()
        End If

        'si es numero convierto al tipo de dato
        If IsNumeric(value) Then

            If Me.BusquedaPorCodigobarra And value.Length >= 7 Then

                Call FindBarcode(value)

            Else

                Me.ComboBoxDetalle.SelectedValue = value

                'If Me.ComboBoxDetalle.SelectedValue IsNot Nothing Then
                'SendKeys.Send(vbTab)
                'End If

            End If


        Else

            'FindCodeValue(value)

            'If Me.ComboBoxDetalle.SelectedItem IsNot Nothing Then
            'SendKeys.Send(vbTab)
            'End If
        End If

    End Sub

    Private Sub ComboBoxDetalle_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxDetalle.LostFocus
        RaiseEvent DejarFoco()
    End Sub

    Private Sub FindBarcode(ByVal value As String)

        Dim query As IEnumerable(Of Entidades.Articulo) =
        From i As Entidades.Articulo In ComboBoxDetalle.Items Where (i.Codigobarra.ToString().ToUpper().Equals(value.ToUpper()))

        For Each obj As Entidades.Articulo In query
            ComboBoxDetalle.SelectedItem = obj
        Next

        'si no encuentro el codigo de barras, busco por codigo
        If Me.ComboBoxDetalle.SelectedValue IsNot Nothing Then
            'SendKeys.Send(vbTab)
            RaiseEvent CodigobarraEncontrado()
            'Else

            '    Me.ComboBoxDetalle.SelectedValue = Convert.ToUInt32(value)

            '    If Me.ComboBoxDetalle.SelectedValue IsNot Nothing Then
            '        'SendKeys.Send(vbTab)
            '    End If

        End If




    End Sub

    'Private Sub FindCodeValue(ByVal value As String)

    '    Dim query As IEnumerable(Of Entidades.Articulo) =
    '    From i As Entidades.Articulo In ComboBoxDetalle.Items Where (i.Codigo.ToString().ToUpper().Equals(value.ToUpper()))

    '    For Each obj As Entidades.Articulo In query
    '        ComboBoxDetalle.SelectedItem = obj
    '    Next


    'End Sub


    Private Sub ComboBoxDetalle_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxDetalle.SelectedIndexChanged
        If _ejecutaEvento Then RaiseEvent SelectedIndexChanged(sender, e)
    End Sub

    'Public Overrides Function ToString() As String
    '    Return Me.ComboBoxDetalle.Text
    'End Function
End Class
