Public Class FormComision

    'entidad
    Property Entidad As Entidades.Vendedor

    'repositorios de tablas
    Private _repositorio As New CapaLogica.VendedorCLog

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
        Me.TextBoxNombre.Enabled = False

        'editar registro
        If Not Entidad Is Nothing Then

            Me.TextBoxId.Text = Entidad.Id
            Me.TextBoxNombre.Text = Entidad.Nombre
            Me.Text = "Editar comisión"
            Me.TextBoxComRev.Text = 0.0
            Me.TextBoxComKiosko.Text = 0.0

        Else 'nuevo registro, valores por defecto

            Me.Text = "Nuevo registro"
            Me.TextBoxId.Text = "0"

        End If

        Me.TextBoxNombre.Select()

    End Sub

    Private Sub FormVendedor_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.TextBoxComRev.Focus()
    End Sub

    Private Sub FormVendedor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
                    AddHandler c.PreviewKeyDown, AddressOf CustomPreviewKeyDown
            End Select
        Next

        AddHandler Me.KeyDown, AddressOf FormularioKeyDown

    End Sub

    Private Sub CustomPreviewKeyDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs)
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Cancelar()
    End Sub

    Private Sub Cancelar()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub InicializarCombos()
        '
    End Sub

    Private Sub CheckBoxActivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Escape : Cancelar()
        End Select
    End Sub

    

    Private Sub BtnRevendedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRevendedor.Click

        Try

            _repositorio.UpdateComisionRevendedor(Entidad, Convert.ToDouble(Me.TextBoxComRev.Text))

            If _repositorio.HasError Then

                MessageBox.Show(_repositorio.mensajes.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                If MessageBox.Show("La operación ha finalizado correctamente. Desea seguir actualizando comisiones?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnKiosko_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKiosko.Click
        Try

            _repositorio.UpdateComisionKiosko(Entidad, Convert.ToDouble(Me.TextBoxComKiosko.Text))

            If _repositorio.HasError Then

                MessageBox.Show(_repositorio.mensajes.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                If MessageBox.Show("La operación ha finalizado correctamente. Desea seguir actualizando comisiones?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnComisionDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnComisionDetalle.Click
        Dim f As New FormComisionDetale
        f.Entidad = Me.Entidad
        If f.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            'If MessageBox.Show("La operación ha finalizado correctamente. Desea seguir actualizando comisiones?", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
            'End If
        End If
    End Sub
End Class