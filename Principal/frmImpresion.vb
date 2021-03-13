Public Class frmImpresion

    Private repoparametros As New CapaLogica.ParametroCLog

    'Tipo Comprobante
    Property mlngTipo As Int32
    'Cantidad de Copias
    Property mstrConcepto As String
    'Número de Prefijo
    Property mlngPrefijo As Long
    'Número de Comprobante
    Property mlngNumero As Long
    'Número de Asiento
    Property mstrAsiento As String
    'Cantidad de Copias
    Property mlngCopias As Double

    'inicializo formulario, limpieza o carga de valores
    Private Sub InicializarFormulario()

        'limpieza de controles
        For Each c As Control In Me.Controls
            Select Case c.GetType
                Case GetType(TextBox) : DirectCast(c, TextBox).Text = ""
                Case GetType(ComboBox) : DirectCast(c, ComboBox).SelectedIndex = -1
                Case GetType(CheckBox) : DirectCast(c, CheckBox).Checked = False
                Case GetType(NumericUpDown) : DirectCast(c, NumericUpDown).Value = DirectCast(c, NumericUpDown).Minimum
            End Select
        Next

        'If mlngTipo = TipoEmisionCbte.MOV_ENTRE_CUENTAS Then
        '    lblTitulo.Text = "MOVIMIENTO ENTRE CUENTAS Nº " + Format(mlngNumero, "00000000")
        '    nudCopias.Value = Convert.ToInt16(repoparametros.GetByNombre("Copias_Impresion_Mov_Cuentas").Valor_param)
        'ElseIf mlngTipo = TipoEmisionCbte.DEPOSITO_CARTERA Then
        '    lblTitulo.Text = "DEPOSITO DE CHEQUES Nº " + Format(mlngNumero, "00000000")
        '    nudCopias.Value = Convert.ToInt16(repoparametros.GetByNombre("Copias_Impresion_Deposito_Cheques").Valor_param)
        'ElseIf mlngTipo = TipoEmisionCbte.CONCILIACION_FINANC Then
        '    lblTitulo.Text = "CONCILIACION BANCARIA Nº " + Format(mlngNumero, "00000000")
        '    nudCopias.Value = Convert.ToInt16(repoparametros.GetByNombre("Copias_Impresion_Conciliacion_Bancaria").Valor_param)

        'ElseIf mstrConcepto = gstrRecibo Then
        '    lblTitulo.Caption = a_DetalleConcepto(mstrConcepto) + " Nº " + Format(mlngPrefijo, "0000") + "-" + Format(mlngNumero, "00000000")
        '    nudCopias.Value = a_CantidadCopias(mstrConcepto)
        'ElseIf mstrConcepto = gstrFacturaA Or mstrConcepto = gstrFacturaB Or _
        '       mstrConcepto = gstrNotaDebitoA Or mstrConcepto = gstrNotaDebitoB Or _
        '       mstrConcepto = gstrNotaCreditoA Or mstrConcepto = gstrNotaCreditoB Or mstrConcepto = gstrNotaCreditoxDev Or _
        '       mstrConcepto = gstrNotaDebitoNAA Or mstrConcepto = gstrNotaDebitoNAB Then

        '    lblTitulo.Caption = a_DetalleConcepto(mstrConcepto) + " Nº " + Format(mlngPrefijo, "0000") + "-" + Format(mlngNumero, "00000000")
        '    nudCopias.Value = a_CantidadCopias(mstrConcepto)
        'ElseIf mstrConcepto = gstrOrdenPago Then
        '    If mlngPrefijo = 0 And mlngNumero = 0 Then
        '        lblTitulo.Caption = a_DetalleConcepto(mstrConcepto)
        '    Else
        '        lblTitulo.Caption = a_DetalleConcepto(mstrConcepto) + " Nº " + Format(mlngPrefijo, "0000") + "-" + Format(mlngNumero, "00000000")
        '    End If
        '    nudCopias.Value = a_CantidadCopias(mstrConcepto)
        'ElseIf mstrConcepto = "ANTC" Then
        '    lblTitulo.Caption = "ANTICIPO DE COBRO" + " Nº " + Format(mlngPrefijo, "0000") + "-" + Format(mlngNumero, "00000000")
        'ElseIf mstrConcepto = "ANTP" Then
        '    lblTitulo.Caption = "ANTICIPO DE PAGO" + " Nº " + Format(mlngPrefijo, "0000") + "-" + Format(mlngNumero, "00000000")
        If mstrConcepto = "CARGA DE MODELOS" Then
            lblTitulo.Text = a_DetalleConcepto(mstrConcepto) + " Nº " + Format(mlngNumero, "00000000")
            nudCopias.Value = Convert.ToInt16(repoparametros.GetByNombre("CopiasCargaModelos").Valorpredeterminado)
        ElseIf mstrConcepto = "DEVOLUCIÓN DE MODELOS" Then
            lblTitulo.Text = a_DetalleConcepto(mstrConcepto) + " Nº " + Format(mlngNumero, "00000000")
            nudCopias.Value = Convert.ToInt16(repoparametros.GetByNombre("CopiasDevolucionModelos").Valorpredeterminado)
        ElseIf mstrConcepto = "EMISIÓN VALE DE CONSUMO" Then
            lblTitulo.Text = a_DetalleConcepto(mstrConcepto) + " Nº " + Format(mlngNumero, "00000000")
            nudCopias.Value = Convert.ToInt16(repoparametros.GetByNombre("CopiasEmisionValeConsumo").Valorpredeterminado)
        ElseIf mstrConcepto = "CERTIFICADO DE ENSAYOS" Then
            lblTitulo.Text = a_DetalleConcepto(mstrConcepto) + " Nº " + Format(mlngNumero, "00000000")
            nudCopias.Value = Convert.ToInt16(repoparametros.GetByNombre("CopiasCertificadosEnsayos").Valorpredeterminado)
        ElseIf mstrConcepto = "CARGA DE ORDEN DE COMPRA" Then
            lblTitulo.Text = a_DetalleConcepto(mstrConcepto) + " Nº " + Format(mlngNumero, "00000000")
            nudCopias.Value = Convert.ToInt16(repoparametros.GetByNombre("CopiasOrdenCompra").Valorpredeterminado)
        ElseIf mstrConcepto = "CARGA DE REMITO" Then
            lblTitulo.Text = a_DetalleConcepto(mstrConcepto) + " Nº " + Format(mlngNumero, "00000000")
            nudCopias.Value = Convert.ToInt16(repoparametros.GetByNombre("CopiasRemito").Valorpredeterminado)
        ElseIf mstrConcepto = "ORDEN DE PAGO" Then
            lblTitulo.Text = a_DetalleConcepto(mstrConcepto) + " Nº " + Format(mlngNumero, "00000000")
            nudCopias.Value = Convert.ToInt16(repoparametros.GetByNombre("CopiasCbtesOrdenPago").Valorpredeterminado)
        ElseIf mstrConcepto = "CARGA DE COMPROBANTE X" Then
            lblTitulo.Text = a_DetalleConcepto(mstrConcepto) + " Nº " + Format(mlngNumero, "00000000")
            nudCopias.Value = Convert.ToInt16(repoparametros.GetByNombre("CopiasCbtesNoFiscal").Valorpredeterminado)
        ElseIf mstrConcepto = "CARGA DE COMPROBANTE" Then
            lblTitulo.Text = a_DetalleConcepto(mstrConcepto) + " Nº " + Format(mlngNumero, "00000000")
            nudCopias.Value = 0 'Convert.ToInt16(repoparametros.GetByNombre("CopiasCbtesNoFiscal").Valorpredeterminado)
        End If

        nudCopias.Select()

    End Sub

    Private Sub frmImpresion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'iniciar formulario
        InicializarFormulario()
    End Sub

    Private Sub CustomGotFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = Color.LightYellow

        Select Case sender.GetType
            Case GetType(TextBox)
                DirectCast(sender, TextBox).Font = New Font(DirectCast(sender, TextBox).Font, FontStyle.Bold)
                DirectCast(sender, TextBox).SelectAll()
            Case GetType(NumericUpDown)
                DirectCast(sender, NumericUpDown).Font = New Font(DirectCast(sender, NumericUpDown).Font, FontStyle.Bold)
                DirectCast(sender, NumericUpDown).Select(0, DirectCast(sender, NumericUpDown).Text.Length)
        End Select

    End Sub

    Private Sub CustomLostFocus(ByVal sender As Object, ByVal e As EventArgs)
        sender.BackColor = SystemColors.Window

        Select Case sender.GetType
            Case GetType(TextBox)
                DirectCast(sender, TextBox).Font = New Font(DirectCast(sender, TextBox).Font, FontStyle.Regular)
            Case GetType(NumericUpDown)
                DirectCast(sender, NumericUpDown).Font = New Font(DirectCast(sender, NumericUpDown).Font, FontStyle.Regular)
        End Select

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

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Cancelar()
    End Sub

    Private Sub Cancelar()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click

        mlngCopias = nudCopias.Value

        If mstrConcepto = "CARGA DE MODELOS" Or mstrConcepto = "DEVOLUCIÓN DE MODELOS" Then
            If Me.nudCopias.Value Mod 2 <> 0 Then
                MsgBox("Las cantidad de copias no puede ser impar", MsgBoxStyle.Critical)
            Else
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        Else
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If

    End Sub

    Private Sub FormularioKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Escape : Cancelar()
            Case Keys.Return : SendKeys.Send("{TAB}")
        End Select
    End Sub

End Class