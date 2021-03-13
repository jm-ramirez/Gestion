Public Class FormRubrocia

    'entidad
    Property Entidad As Entidades.Rubrogcia

    'repositorios de tablas
    Private _repositorio As New CapaLogica.RubrogciaCLog

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
            Me.TextBoxDescripcion.Text = Entidad.Descripcion
            Me.NumericUpDownNosujeto.Value = Entidad.Nosujeto
            Me.NumericUpDownMinimo.Value = Entidad.Minimo
            Me.NumericUpDownNoinscripto.Value = Entidad.Noinscripto
            Me.NumericUpDownTope1.Value = Entidad.Tope1
            Me.NumericUpDownTope2.Value = Entidad.Tope2
            Me.NumericUpDownTope3.Value = Entidad.Tope3
            Me.NumericUpDownTope4.Value = Entidad.Tope4
            Me.NumericUpDownTope5.Value = Entidad.Tope5
            Me.NumericUpDownTope6.Value = Entidad.Tope6
            Me.NumericUpDownTope7.Value = Entidad.Tope7
            Me.NumericUpDownTopeAlic1.Value = Entidad.Tope1alic
            Me.NumericUpDownTopeAlic2.Value = Entidad.Tope2alic
            Me.NumericUpDownTopeAlic3.Value = Entidad.Tope3alic
            Me.NumericUpDownTopeAlic4.Value = Entidad.Tope4alic
            Me.NumericUpDownTopeAlic5.Value = Entidad.Tope5alic
            Me.NumericUpDownTopeAlic6.Value = Entidad.Tope6alic
            Me.NumericUpDownTopeAlic7.Value = Entidad.Tope7alic
            Me.CheckBoxActivo.Checked = Me.CheckBoxActivo.Checked

            Me.Text = "Editar registro"

        Else 'nuevo registro, valores por defecto

            Me.Text = "Nuevo registro"
            Me.TextBoxId.Text = "0"
            Me.CheckBoxActivo.Checked = True

        End If

        Me.TextBoxNombre.Focus()

    End Sub

    Private Sub FormRubrogcia_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.TextBoxNombre.Focus()
    End Sub

    Private Sub FormRubrogcia_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'iniciar formulario
        InicializarFormulario()
    End Sub

    Private Sub CustomGotFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = Color.LightGreen

        If sender.GetType = GetType(TextBox) Then
            DirectCast(sender, TextBox).Font = New Font(DirectCast(sender, TextBox).Font, FontStyle.Bold)
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
                Case GetType(TextBox), GetType(CheckBox), GetType(ComboBox), GetType(NumericUpDown)
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
                Entidad = New Entidades.Rubrogcia
            End If


            Entidad.Nombre = Me.TextBoxNombre.Text
            Entidad.Descripcion = Me.TextBoxDescripcion.Text.Trim
            Entidad.Nosujeto = Me.NumericUpDownNosujeto.Value
            Entidad.Minimo = Me.NumericUpDownMinimo.Value
            Entidad.Noinscripto = Me.NumericUpDownNoinscripto.Value
            Entidad.Tope1 = Me.NumericUpDownTope1.Value
            Entidad.Tope2 = Me.NumericUpDownTope2.Value
            Entidad.Tope3 = Me.NumericUpDownTope3.Value
            Entidad.Tope4 = Me.NumericUpDownTope4.Value
            Entidad.Tope5 = Me.NumericUpDownTope5.Value
            Entidad.Tope6 = Me.NumericUpDownTope6.Value
            Entidad.Tope7 = Me.NumericUpDownTope7.Value
            Entidad.Tope1alic = Me.NumericUpDownTopeAlic1.Value
            Entidad.Tope2alic = Me.NumericUpDownTopeAlic2.Value
            Entidad.Tope3alic = Me.NumericUpDownTopeAlic3.Value
            Entidad.Tope4alic = Me.NumericUpDownTopeAlic4.Value
            Entidad.Tope5alic = Me.NumericUpDownTopeAlic5.Value
            Entidad.Tope6alic = Me.NumericUpDownTopeAlic6.Value
            Entidad.Tope7alic = Me.NumericUpDownTopeAlic7.Value
            Entidad.activo = Me.CheckBoxActivo.Checked

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

    

    Private Sub InicializarCombos()
        'Throw New NotImplementedException
    End Sub

  

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F12 : Guardar()
            Case Keys.Escape : Cancelar()
            Case Keys.Return : SendKeys.Send("{TAB}")
        End Select
    End Sub

End Class