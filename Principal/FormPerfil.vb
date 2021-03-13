Public Class FormPerfil

    Property MenuPrincipal As MenuStrip = Nothing

    'entidad
    Property Entidad As Entidades.Perfil

    'repositorios de tablas
    Private _repositorio As New CapaLogica.PerfilCLog

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

        LlenaMenu()

        'editar registro
        If Not Entidad Is Nothing Then

            Me.TextBoxId.Text = Entidad.Id
            Me.TextBoxNombre.Text = Entidad.Nombre

            Me.Text = "Editar registro"

            HabilitarMenu(Entidad.Permisos)

        Else 'nuevo registro, valores por defecto

            Me.Text = "Nuevo registro"
            Me.TextBoxId.Text = "0"

        End If





        Me.TextBoxNombre.Focus()

    End Sub

    Private Sub FormPerfil_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.TextBoxNombre.Focus()
    End Sub

    Private Sub FormPerfil_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

    Private Sub Guardar()

        Try

            'actualizo los valores de la entidad que se desea persistir
            If Entidad Is Nothing Then
                Entidad = New Entidades.Perfil
            End If

            Entidad.Nombre = Me.TextBoxNombre.Text.Trim
            Entidad.Permisos = GetPermisos

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

    Private Sub ComboBoxPerfils_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub InicializarCombos()
        'Throw New NotImplementedException
    End Sub

    Private Sub CheckBoxActivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F12 : Guardar()
            Case Keys.Escape : Cancelar()
            Case Keys.Return : SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub LlenaMenu()


        Dim Nodx As TreeNode
        Dim n As TreeNode
        Dim Smenu As String

        TreeViewMenu.CheckBoxes = True
        TreeViewMenu.Nodes.Clear()
        Nodx = New TreeNode("Menú Principal")
        Nodx.Checked = True

        For Each mnuItem As ToolStripMenuItem In Me.MenuPrincipal.Items

            Smenu = Replace(mnuItem.Text, "&", "", 1, Len(mnuItem.Text))

            n = New TreeNode()
            n.Name = mnuItem.Name
            n.Text = mnuItem.Text
            Nodx.Nodes.Add(n)

            If mnuItem.DropDownItems.Count > 0 Then
                RecorrerSubmenu(mnuItem, Nodx.Nodes(Nodx.Nodes.Count - 1))
            End If

            'Nodx.Nodes.Add(mnuItem.Name, Smenu)

        Next

        'inicializo el formulario con todos los nodos chequeados 
        'antes de pasar el perfil
        ChequearMenu(Nodx, True)

        TreeViewMenu.Nodes.Add(Nodx)
        TreeViewMenu.ExpandAll()

    End Sub

    Private Sub RecorrerSubmenu(ByRef oMenuItem As ToolStripMenuItem, ByRef nodo As TreeNode)
        Dim NomMenu As String
        Dim n As TreeNode
        Dim i As ToolStripMenuItem

        For Each o As Object In oMenuItem.DropDownItems

            If o.GetType Is GetType(ToolStripMenuItem) Then

                i = o

                NomMenu = Replace(i.Text, "&", "", 1, Len(i.Text))

                n = New TreeNode
                n.Name = i.Name
                n.Text = i.Text
                nodo.Nodes.Add(n)

                If i.DropDownItems.Count > 0 Then
                    RecorrerSubmenu(i, nodo.Nodes(nodo.Nodes.Count - 1))
                End If
            End If

        Next
        
    End Sub

    Private Sub ChequearMenu(ByVal nodo As TreeNode, ByVal check As Boolean)
        For Each n As TreeNode In nodo.Nodes
            n.Checked = check

            If n.Nodes.Count > 0 Then ChequearMenu(n, check)

        Next
    End Sub

    Private Sub TreeViewMenu_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeViewMenu.AfterCheck
        ChequearMenu(e.Node, e.Node.Checked)
    End Sub

    Private Function GetPermisos() As List(Of Entidades.Perfilpermiso)

        Dim ret As New List(Of Entidades.Perfilpermiso)
        
        RecorrerNodosPermisos(Me.TreeViewMenu.Nodes(0), ret)

        Return ret

    End Function

    Private Sub RecorrerNodosPermisos(ByVal nodo As TreeNode, ByVal permisos As List(Of Entidades.Perfilpermiso))
        Dim p As Entidades.Perfilpermiso

        For Each n As TreeNode In nodo.Nodes
            p = New Entidades.Perfilpermiso
            p.Activo = n.Checked

            If n.Parent.Name.Length = 0 Then
                p.Padre = n.Name
            Else
                p.Padre = n.Parent.Name
            End If

            p.Hijo = n.Name
            p.Perfil = Entidad.Id
            p.Permiso = 0

            permisos.Add(p)

            If n.Nodes.Count > 0 Then RecorrerNodosPermisos(n, permisos)

        Next
    End Sub

    Private Sub HabilitarMenu(ByVal list As List(Of Entidades.Perfilpermiso))

        Dim hijo As String
        Dim padre As String
        Dim query As IEnumerable(Of Entidades.Perfilpermiso)

        For Each mnuItem As TreeNode In Me.TreeViewMenu.Nodes(0).Nodes

            hijo = mnuItem.Name
            padre = mnuItem.Name

            query =
            From i As Entidades.Perfilpermiso In list Where (i.Padre.Equals(padre)) And (i.Hijo.Equals(hijo))

            If query.Count <= 0 Then
                mnuItem.Checked = True
            Else
                For Each obj As Entidades.Perfilpermiso In query
                    mnuItem.Checked = obj.Activo
                Next
            End If

            If mnuItem.Nodes.Count > 0 Then
                RecorrerMenuPermiso(mnuItem, list)
            End If

        Next
    End Sub


    Private Sub RecorrerMenuPermiso(ByRef node As TreeNode, ByVal list As List(Of Entidades.Perfilpermiso))

        Dim query As IEnumerable(Of Entidades.Perfilpermiso)
        Dim hijo As String
        Dim padre As String

        For Each o As TreeNode In node.Nodes

            hijo = o.Name
            padre = node.Name

            query =
            From x As Entidades.Perfilpermiso In list Where (x.Padre.Equals(padre)) And (x.Hijo.Equals(hijo))

            If query.Count <= 0 Then
                o.Checked = True
            Else
                For Each obj As Entidades.Perfilpermiso In query
                    o.Checked = obj.Activo
                Next
            End If

            If o.Nodes.Count > 0 Then
                RecorrerMenuPermiso(o, list)
            End If



        Next

    End Sub

End Class