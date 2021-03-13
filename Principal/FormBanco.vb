Public Class FormBanco

    'entidad
    Property Entidad As Entidades.Banco

    'repositorios de tablas
    Private _repositorio As New CapaLogica.BancoCLog

    'inicializar tablas foraneas
    Private Sub InicializarCombos()

        

    End Sub

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F12 : Guardar()
            Case Keys.Escape : Cancelar()
            Case Keys.Return : SendKeys.Send("{TAB}")
        End Select
    End Sub


    'inicializo formulario, limpieza o carga de valores
    Private Sub InicializarFormulario()

        'limpieza de controles
        For Each c As Control In Me.Controls
            Select Case c.GetType
                Case GetType(TextBox) : DirectCast(c, TextBox).Text = ""
                Case GetType(ComboBox) : DirectCast(c, ComboBox).SelectedIndex = -1
                Case GetType(CheckBox) : DirectCast(c, CheckBox).Checked = False
            End Select
        Next

        InicializarCombos()

        'el campo id no se puede modificar cuando es autoincremental
        Me.TextBoxId.Enabled = False

        'editar registro
        If Not Entidad Is Nothing Then

            Me.TextBoxId.Text = Entidad.Id
            Me.TextBoxCodigo.Text = Entidad.Codigo
            Me.TextBoxNombre.Text = Entidad.Nombre

            Me.Text = "Editar registro"

        Else 'nuevo registro, valores por defecto

            Me.Text = "Nuevo registro"
            Me.TextBoxId.Text = "0"
        End If

        Me.TextBoxNombre.Focus()

    End Sub

    Private Sub FormBanco_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.TextBoxCodigo.Focus()
    End Sub

    Private Sub FormBanco_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'iniciar formulario
        InicializarFormulario()
    End Sub

    Private Sub CustomGotFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = Color.LightGreen

        If sender.GetType = GetType(TextBox) Then
            DirectCast(sender, TextBox).Font = New Font(DirectCast(sender, TextBox).Font, FontStyle.Bold)
        End If

    End Sub

    Private Sub CustomLostFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = SystemColors.Window

        If sender.GetType = GetType(TextBox) Then
            DirectCast(sender, TextBox).Font = New Font(DirectCast(sender, TextBox).Font, FontStyle.Regular)
        End If

    End Sub

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        For Each c As Control In Me.Controls
            Select Case c.GetType
                Case GetType(TextBox), GetType(CheckBox), GetType(ComboBox)
                    AddHandler c.GotFocus, AddressOf CustomGotFocus
                    AddHandler c.LostFocus, AddressOf CustomLostFocus
            End Select
        Next
        AddHandler Me.KeyDown, AddressOf FormularioKeyDown
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
            'actualizo los valores de la entidad que se desea persistir
            If Entidad Is Nothing Then
                Entidad = New Entidades.Banco
            End If

            Entidad.Codigo = Convert.ToUInt16(Me.TextBoxCodigo.Text)
            Entidad.Nombre = Me.TextBoxNombre.Text

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

End Class