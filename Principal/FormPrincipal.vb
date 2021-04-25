Imports System.Xml
Imports System.Text

Public Class FormPrincipal

    Private login As FormLogin

    Private Sub ShowForm(ByVal form As Form)
        For Each f As Form In My.Application.OpenForms
            If f.Name = form.Name Then
                f.BringToFront()
                Exit Sub
            End If
        Next
        'form.MdiParent = Me
        form.Show(Me)

    End Sub

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        AddHandlerComprobantes(mnuComprobantes)
        AddHandlerPresupuestos(mnuPresupuestos)
        AddHandlerArchivos(mnuArchivos)
        AddHandlerListados(mnuListados)
        AddHandlerGestionClientes(mnuGestionClientes) 'mnuOrdenesCompra
        AddHandlerOrdenesCompra(mnuOrdenesCompra) 'mnuOrdenesCompra
        AddHandlerGestionProveedores(mnuGestionProveedores)
        'AddHandlerModelos(mnuModelos)
        AddHandlerControlStock(mnuControlStock)
        AddHandlerEstadisticas(mnuEstadisticas)
        AddHandlerFinanciero(mnuFinanciero)
        AddHandlerUtilidades(mnuUtilidades)
    End Sub

    Private Sub AddHandlerArchivos(ByVal menu As ToolStripMenuItem)

        Dim i As ToolStripMenuItem

        Try

            For Each item As Object In menu.DropDownItems

                If item.GetType() = GetType(ToolStripMenuItem) Then

                    i = DirectCast(item, ToolStripMenuItem)

                    If i.HasDropDownItems Then
                        AddHandlerArchivos(i)
                    Else
                        If item.Tag <> "" Then
                            AddHandler i.Click, AddressOf MenuArchivos
                        End If
                    End If

                End If

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub AddHandlerListados(ByVal menu As ToolStripMenuItem)

        Dim i As ToolStripMenuItem

        Try

            For Each item As Object In menu.DropDownItems

                If item.GetType() = GetType(ToolStripMenuItem) Then

                    i = DirectCast(item, ToolStripMenuItem)

                    If i.HasDropDownItems Then
                        AddHandlerListados(i)
                    Else
                        If item.Tag <> "" Then
                            AddHandler i.Click, AddressOf MenuListados
                        End If
                    End If

                End If

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub AddHandlerComprobantes(ByVal menu As ToolStripMenuItem)

        Dim i As ToolStripMenuItem

        Try

            For Each item As Object In menu.DropDownItems

                If item.GetType() = GetType(ToolStripMenuItem) Then

                    i = DirectCast(item, ToolStripMenuItem)

                    If i.HasDropDownItems Then
                        AddHandlerComprobantes(i)
                    Else
                        If item.Tag <> "" Then
                            AddHandler i.Click, AddressOf MenuComprobantes
                        End If
                    End If

                End If

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub AddHandlerPresupuestos(ByVal menu As ToolStripMenuItem)

        Dim i As ToolStripMenuItem

        Try

            For Each item As Object In menu.DropDownItems

                If item.GetType() = GetType(ToolStripMenuItem) Then

                    i = DirectCast(item, ToolStripMenuItem)

                    If i.HasDropDownItems Then
                        AddHandlerComprobantes(i)
                    Else
                        If item.Tag <> "" Then
                            AddHandler i.Click, AddressOf MenuPresupuestos
                        End If
                    End If

                End If

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub AddHandlerEstadisticas(ByVal menu As ToolStripMenuItem)

        Dim i As ToolStripMenuItem

        Try

            For Each item As Object In menu.DropDownItems

                If item.GetType() = GetType(ToolStripMenuItem) Then

                    i = DirectCast(item, ToolStripMenuItem)

                    If i.HasDropDownItems Then
                        AddHandlerEstadisticas(i)
                    Else
                        If item.Tag <> "" Then
                            AddHandler i.Click, AddressOf MenuEstadisticas
                        End If
                    End If

                End If

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub AddHandlerModelos(ByVal menu As ToolStripMenuItem)

        Dim i As ToolStripMenuItem

        Try

            For Each item As Object In menu.DropDownItems

                If item.GetType() = GetType(ToolStripMenuItem) Then

                    i = DirectCast(item, ToolStripMenuItem)

                    If i.HasDropDownItems Then
                        AddHandlerModelos(i)
                    Else
                        If item.Tag <> "" Then
                            AddHandler i.Click, AddressOf MenuModelos
                        End If
                    End If

                End If

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub AddHandlerControlStock(ByVal menu As ToolStripMenuItem)

        Dim i As ToolStripMenuItem

        Try

            For Each item As Object In menu.DropDownItems

                If item.GetType() = GetType(ToolStripMenuItem) Then

                    i = DirectCast(item, ToolStripMenuItem)

                    If i.HasDropDownItems Then
                        AddHandlerControlStock(i)
                    Else
                        If item.Tag <> "" Then
                            AddHandler i.Click, AddressOf MenuControlStock
                        End If
                    End If

                End If

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub AddHandlerFinanciero(ByVal menu As ToolStripMenuItem)

        Dim i As ToolStripMenuItem

        Try

            For Each item As Object In menu.DropDownItems

                If item.GetType() = GetType(ToolStripMenuItem) Then

                    i = DirectCast(item, ToolStripMenuItem)

                    If i.HasDropDownItems Then
                        AddHandlerFinanciero(i)
                    Else
                        If item.Tag <> "" Then
                            AddHandler i.Click, AddressOf MenuFinanciero
                        End If
                    End If

                End If

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub AddHandlerOrdenesCompra(ByVal menu As ToolStripMenuItem)

        Dim i As ToolStripMenuItem

        Try

            For Each item As Object In menu.DropDownItems

                If item.GetType() = GetType(ToolStripMenuItem) Then

                    i = DirectCast(item, ToolStripMenuItem)

                    If i.HasDropDownItems Then
                        AddHandlerOrdenesCompra(i)
                    Else
                        If item.Tag <> "" Then
                            AddHandler i.Click, AddressOf MenuOrdenesCompra
                        End If
                    End If

                End If

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub AddHandlerGestionClientes(ByVal menu As ToolStripMenuItem)

        Dim i As ToolStripMenuItem

        Try

            For Each item As Object In menu.DropDownItems

                If item.GetType() = GetType(ToolStripMenuItem) Then

                    i = DirectCast(item, ToolStripMenuItem)

                    If i.HasDropDownItems Then
                        AddHandlerGestionClientes(i)
                    Else
                        If item.Tag <> "" Then
                            AddHandler i.Click, AddressOf MenuGestionClientes
                        End If
                    End If

                End If

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub AddHandlerGestionProveedores(ByVal menu As ToolStripMenuItem)

        Dim i As ToolStripMenuItem

        Try

            For Each item As Object In menu.DropDownItems

                If item.GetType() = GetType(ToolStripMenuItem) Then

                    i = DirectCast(item, ToolStripMenuItem)

                    If i.HasDropDownItems Then
                        AddHandlerGestionProveedores(i)
                    Else
                        If item.Tag <> "" Then
                            AddHandler i.Click, AddressOf MenuGestionProveedores
                        End If
                    End If

                End If

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub AddHandlerUtilidades(ByVal menu As ToolStripMenuItem)

        Dim i As ToolStripMenuItem

        Try

            For Each item As Object In menu.DropDownItems

                If item.GetType() = GetType(ToolStripMenuItem) Then

                    i = DirectCast(item, ToolStripMenuItem)

                    If i.HasDropDownItems Then
                        AddHandlerUtilidades(i)
                    Else
                        If item.Tag <> "" Then
                            AddHandler i.Click, AddressOf MenuUtilidades
                        End If
                    End If

                End If

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub MenuArchivos(ByVal sender As Object, ByVal e As EventArgs)

        Select Case sender.Tag
            Case "abmClientes" : ShowForm(New FormABMCliente)
            Case "abmCondVta" : ShowForm(New FormABMFormaPago)
            Case "abmProveedores" : ShowForm(New FormABMProveedor)
            Case "abmRubGcias" : ShowForm(New FormABMRubroGcia)
            Case "abmTransportes" : ShowForm(New FormABMTransporte)
            Case "abmVendedores" : ShowForm(New FormABMVendedor)
            Case "abmArticulos" : ShowForm(New FormABMArticulo) 'ShowForm(New FormABMPiezas)
            Case "abmRubArt" : ShowForm(New FormABMRubro)
            Case "abmRubMaestroArt" : ShowForm(New FormABMRubromaestro)
                'Case "abmMateriales" : ShowForm(New FormABMMateriales)
            Case "abmCategorias" : ShowForm(New FormABMCategoria)
            Case "abmLocalidades" : ShowForm(New FormABMLocalidad)
            Case "abmProvincias" : ShowForm(New FormABMProvincias)
            Case "abmZonas" : ShowForm(New FormABMZona)
            Case "abmCtasFi" : ShowForm(New FormABMCuentabancaria)
            Case "abmConcFi" : ShowForm(New FormABMConceptobancario)
            Case "abmBancos" : ShowForm(New FormABMBanco)
                'Case "abmCpraRubros" : ShowForm(New FormABMRubMatCpra)
                'Case "abmcpraGastosV" : ShowForm(New FormABMGastosV)
                'Case "abmcpraGastosF" : ShowForm(New FormABMGastosF)
                'Case "abmImputacion" : ShowForm(New FormABMImputa)
                'Case "abmImputaEg" : ShowForm(New FormABMImputaEg)
                'Case "abmcpraMateriales" : ShowForm(New FormABMMatCpra)
        End Select
    End Sub

    Private Sub MenuListados(ByVal sender As Object, ByVal e As EventArgs)

        Dim f As lstPrimario = Nothing

        Select sender.Tag
            Case "lisClientes"
                f = New lstPrimario
                f.mlngTipoListado = Listados.CLIENTES
                f.Show()
            Case "lisCondVta"
                f = New lstPrimario
                f.mlngTipoListado = Listados.FORMAS_PAGOS
                f.Show()
            Case "lisProveedores"
                f = New lstPrimario
                f.mlngTipoListado = Listados.PROVEEDORES
                f.Show()
            Case "lisRubGcias"
                f = New lstPrimario
                f.mlngTipoListado = Listados.RUBROS_GCIAS
                f.Show()
            Case "lisTransportes"
                f = New lstPrimario
                f.mlngTipoListado = Listados.TRANSPORTES
                f.Show()
            Case "lisVendedores"
                f = New lstPrimario
                f.mlngTipoListado = Listados.VENDEDORES
                f.Show()
            Case "lisArticulos"
                ShowForm(New lstArticulos)
            Case "lisRubArt"
                ShowForm(New lstRubrosArt)
            Case "lisRubMaestroArt"
                f = New lstPrimario
                f.mlngTipoListado = Listados.RUBROS_MAESTRO_ART
                f.Show()
                '    Case "lisMateriales"
                '        f = New lstPrimario
                '        f.mlngTipoListado = Listados.MATERIALES_ART
                '        f.Show()
            Case "lisCategoriaArt"
                f = New lstPrimario
                f.mlngTipoListado = Listados.CATEGORIAS_ART
                f.Show()
            'Case "emisionlistaprecios"
            '    ShowForm(New FormEmisionLstPrecios)
            Case "lisLocalidades"
                ShowForm(New lstLocalidades)
            Case "lisProvincias"
                f = New lstPrimario
                f.mlngTipoListado = Listados.PROVINCIAS
                f.Show()
            Case "lisZonas"
                f = New lstPrimario
                f.mlngTipoListado = Listados.ZONAS
                f.Show()
            Case "lisCuentasFi"
                f = New lstPrimario
                f.mlngTipoListado = Listados.CUENTAS_FINANCIEROS
                f.Show()
            Case "lisConceptosFi"
                f = New lstPrimario
                f.mlngTipoListado = Listados.CONCEPTOS_FINANCIEROS
                f.Show()
            Case "lisBancos"
                f = New lstPrimario
                f.mlngTipoListado = Listados.BANCOS
                f.Show()
                '    Case "liscpraRubros"
                '        f = New lstPrimario
                '        f.mlngTipoListado = Listados.RUBROS_MATERIALES
                '        f.Show()
                '    Case "liscpraGastosV"
                '        f = New lstPrimario
                '        f.mlngTipoListado = Listados.GASTOS_VARIABLES
                '        f.Show()
                '    Case "liscpraGastosF"
                '        f = New lstPrimario
                '        f.mlngTipoListado = Listados.GASTOS_FIJOS
                '        f.Show()
                '    Case "liscpraImputa"
                '        f = New lstPrimario
                '        f.mlngTipoListado = Listados.CODIGOS_IMPUTACION
                '        f.Show()
                '    Case "lisImputaEg"
                '        f = New lstPrimario
                '        f.mlngTipoListado = Listados.CODIGOS_IMPUTACION_EGRESO
                '        f.Show()
                '    Case "liscpraMateriales"
                '        f = New lstPrimario
                '        f.mlngTipoListado = Listados.MATERIALES_CPRA
                '        f.Show()
        End Select
    End Sub

    Private Sub MenuComprobantes(ByVal sender As Object, ByVal e As EventArgs)

        Dim f As FormCbteVenta = Nothing
        Dim fc As FormCbteCobro = Nothing
        Dim fp As FormCbteVentaKiosco = Nothing
        'Dim ff As FormFiscal = Nothing
        'Dim fr As FormCbteRemito = Nothing

        Select Case sender.Tag
            Case "cbteremito"
                ShowForm(New FormCbteRemito)
            Case "consultaremito"
                ShowForm(New FormInformeRemitos)
                '    Case "cbteelectronico"
                '        f = New FormCbteVenta
                '        f.TipoCbte = TipoEmisionCbte.ELECTRONICO
                '        f.ShowDialog()
                '        'Case "cbtefiscal"
                '        '    f = New FormCbteVenta
                '        '    f.TipoCbte = TipoEmisionCbte.FISCAL
                '        '    f.ShowDialog()
            Case "cbtepreimpreso"
                'f = New FormCbteVenta
                'f.TipoCbte = TipoEmisionCbte.PREIMPRESO
                'f.ShowDialog()
                fp = New FormCbteVentaKiosco
                fp.TipoCbte = TipoEmisionCbte.PREIMPRESO
                'fp.Height = 590
                fp.ShowDialog()
            Case "ajustedeudor"
                fc = New FormCbteCobro
                fc.TipoCbte = TipoEmisionCbte.AJUSTE_DEUDOR
                fc.ShowDialog()
            Case "ajusteacreedor"
                fc = New FormCbteCobro
                fc.TipoCbte = TipoEmisionCbte.AJUSTE_ACREEDOR
                fc.ShowDialog()
            Case "cbtepresupuesto"
                fp = New FormCbteVentaKiosco
                fp.TipoCbte = TipoEmisionCbte.PRESUPUESTO
                fp.Height = 590
                fp.ShowDialog()
            Case "recibopresupuesto"
                fc = New FormCbteCobro
                fc.TipoCbte = TipoEmisionCbte.RECIBO_PRESUPUESTO
                fc.ShowDialog()
            Case "recibo"
                fc = New FormCbteCobro
                fc.TipoCbte = TipoEmisionCbte.RECIBO
                fc.ShowDialog()
            Case "recibox"
                fc = New FormCbteCobro
                fc.TipoCbte = TipoEmisionCbte.RECIBO_NO_FISCAL
                fc.ShowDialog()
                '        'Case "cierrez"
                '        '    ff = New FormFiscal
                '        '    ff.Utilidad = UtilidadFiscal.CIERRE_Z
                '        '    ff.ShowDialog()
                '        'Case "cierrex"
                '        '    ff = New FormFiscal
                '        '    ff.Utilidad = UtilidadFiscal.CIERRE_X
                '        '    ff.ShowDialog()
                '        'Case "auditoria"
                '        '    ff = New FormFiscal
                '        '    ff.Utilidad = UtilidadFiscal.AUDITORIA
                '        '    ff.ShowDialog()
            Case "consulta"
                ShowForm(New FormConsultaComprobantes)
            Case "anticipos"
                ShowForm(New FormAplicacionAnticipos)
                'Case "certificadosensayos"
                '    ShowForm(New FormABMEnsayos)
        End Select
    End Sub

    Private Sub MenuPresupuestos(ByVal sender As Object, ByVal e As EventArgs)

        Select Case DirectCast(sender, ToolStripItem).Tag
            Case "CargaPres"
                Dim f As New FormCbteVenta2
                f.TipoCbte = TipoEmisionCbte.PRESUPUESTO
                f.mblnBase = False
                'f.ShowDialog()
                f.Show()
            Case "ConsultaPres"
                Dim f As New FormConCbteVenta2
                f.TipoConsulta = TipoEmisionCbte.PRESUPUESTO
                'f.ShowDialog()
                f.Show()
        End Select
    End Sub

    Private Sub MenuEstadisticas(ByVal sender As Object, ByVal e As EventArgs)

        Dim f As Object = Nothing
        ''Dim fv As FormInformeVentas = Nothing

        Select sender.Tag
            Case "ivaventas"
                f = New FormInformeDiario
                f.ReporteDiario = ReporteDiario.IVAVENTAS
                f.Show()
            Case "ivacompras"
                f = New FormInformeDiario
                f.ReporteDiario = ReporteDiario.IVACOMPRAS
                f.Show()
            Case "cobranzas"
                f = New FormInformeDiario
                f.ReporteDiario = ReporteDiario.COBRANZAS
                f.Show()
            Case "pagos"
                f = New FormInformeDiario
                f.ReporteDiario = ReporteDiario.PAGOS
                f.Show()

            Case "remitos"
                f = New FormInformeDiario
                f.ReporteDiario = ReporteDiario.REMITOS
                f.Show()

                '    Case "subdiariocomprobantes"

            Case "subdiarioingresos"
                ShowForm(New FormInformeSubdiarioIngresos)
            Case "comprasproveedor"
                ShowForm(New FormInformeComprasProveedor)
            Case "comprasarticulosproveedor"
                ShowForm(New FormInformeComprasArtProv)
            Case "comprasrubroarticulos"
                ShowForm(New FormInformeComprasRubArt)
            Case "consumoarticulo"
                ShowForm(New FormInformeConsumoArticulo)
            Case "consumorubro"
                ShowForm(New FormInformeConsumoRubro)
            Case "egresosperiodo"
                ShowForm(New FormInformeEgresosPeriodo)
                '    Case "resumenkilosvendidos"
                '        ShowForm(New FormInformeResKgsVendidos)
            Case "resumenpagosproveedoresctacte"
                ShowForm(New FormPagoProveedorCtaCte)
                '    Case "resumencostos"
                '        ShowForm(New FormResumenCosto)
            Case "resumenpagosproveedores"
                ShowForm(New FormPagoProveedor)
                '    Case "atrasocobranzas"
                '        ShowForm(New FormInformeAtrasoCobranza)

                '        'Case "ranking"
                '        '    ShowForm(New FormInformeRanking)
                '        'Case "infanalisis"
                '        '    ShowForm(New FormInformeAnalisis)
                '        'Case "infcompras"
                '        '    f = New FormInformeCompras
                '        '    f.ReporteDiario = ReporteDiario.COMPRAS_ARTICULOS_PROVEEDOR
                '        '    f.Show()
                '        'Case "infventas"
                '        '    f = New FormInformeVentas
                '        '    f.Show()
                '        'Case "infventasperiodo"
                '        '    f = New FormInformeVentasPeriodo
                '        '    f.Show()
                '        'Case "infventasperiodovendedor"
                '        '    f = New FormInformeVentasPeriodoVendedor
                '        '    f.Show()
                '        'Case "infventastablero"
                '        '    f = New FormInformeVentasTablero
                '        '    f.Show()
                '        'Case "infclientesno"
                '        '    ShowForm(New FormInformeClientes)
                '        'Case "infzonas"
                '        '    f = New FormInformeZonasRubros
                '        '    f.ReporteDiario = ReporteDiario.VENTAS_ZONAS
                '        '    f.Show()
                '        'Case "infrubros"
                '        '    f = New FormInformeZonasRubros
                '        '    f.ReporteDiario = ReporteDiario.VENTAS_RUBROS
                '        '    f.Show()
                '        'Case "infcat"
                '        '    f = New FormInformeZonasRubros
                '        '    f.ReporteDiario = ReporteDiario.VENTAS_CATEGORIAS
                '        '    f.Show()
                '        'Case "comisionvendedor"
                '        '    ShowForm(New FormInformeComisionVendedor)
                '        'Case "comisionsupervisor"
                '        '    ShowForm(New FormInformeComisionSupervisor)
                '        'Case "comisionacompaniante"
                '        '    ShowForm(New FormInformeComisionAcompaniante)
                '        'Case "diariokilos"
                '        '    ShowForm(New FormInformeKilos)
                '        'Case "informedetalladoventas"
                '        '    ShowForm(New FormInformeDetalladoVenta)
                '        'Case "informedetalladocompras"
                '        '    ShowForm(New FormInformeDetalladoCompra)

        End Select
    End Sub

    Private Sub MenuUtilidades(ByVal sender As Object, ByVal e As EventArgs)

        Dim f As FormCfgTerminal = Nothing
        Dim fp As FormABMPerfil = Nothing
        'Dim fa As FormGeneraArchivos = Nothing

        Select sender.Tag
            '    Case "rg3685" : ShowForm(New FormRg3865)
            '    Case "sicore"
            '        fa = New FormGeneraArchivos
            '        fa.TipoArchivo = DesignFile.SICORE
            '        fa.Show()
            Case "parametros" : ShowForm(New FormABMParametro)
            Case "usuarios" : ShowForm(New FormABMPersonal)
            Case "numeracion" : ShowForm(New FormNumeracion)
            Case "constatar" : ShowForm(New FormCDC)
            Case "empresa" : ShowForm(New FormCfgEmpresa)
            Case "cfgterminal"
                f = New FormCfgTerminal

                If f.ShowDialog = Windows.Forms.DialogResult.OK Then
                    DoApariencia()
                End If
            Case "perfiles"
                fp = New FormABMPerfil
                fp.MenuPrincipal = Me.MenuStripPrincipal
                fp.Show()
                '    Case "cambiopcioarticulo"
                '        ShowForm(New FormCambioPrecioArticulo)
                '    Case "cambiopciocliente"
                '        ShowForm(New FormCambioPrecioCliente)

            Case "logout"
                DoLogin()
        End Select
    End Sub

    Private Sub MenuControlStock(ByVal sender As Object, ByVal e As EventArgs)

        Dim f As FormListaStock

        Select sender.Tag
            Case "listas" : ShowForm(New FormListaPrecios)
            Case "inventario" : ShowForm(New FormInventario)
            Case "lstinventarios"
                f = New FormListaStock
                f.TipoReporte = ReporteStock.INVENTARIO
                f.Show()
            Case "existencia"
                f = New FormListaStock
                f.TipoReporte = ReporteStock.EXISTENCIAS
                f.Show()
            Case "ficha"
                f = New FormListaStock
                f.TipoReporte = ReporteStock.FICHA_STOCK
                f.Show()
            Case "faltantes"
                f = New FormListaStock
                f.TipoReporte = ReporteStock.FALTANTES
                f.Show()

        End Select
    End Sub
    Private Sub MenuGestionClientes(ByVal sender As Object, ByVal e As EventArgs)

        Dim f As FormCtaCteCliente = Nothing

        Select sender.Tag
            '    Case "clientes" : ShowForm(New FormABMCliente)
            '    Case "zonas" : ShowForm(New FormABMZona)
            Case "edocta"
                f = New FormCtaCteCliente
                f.ReporteAGenerar = ReporteCtaCte.EDOCTA
                f.Show(Me)
            Case "edoref"
                f = New FormCtaCteCliente
                f.ReporteAGenerar = ReporteCtaCte.EDOREF
                f.Show(Me)
            Case "pendientes"
                f = New FormCtaCteCliente
                f.ReporteAGenerar = ReporteCtaCte.PENDIENTES
                f.Show(Me)
            Case "vencimiento"
                f = New FormCtaCteCliente
                f.ReporteAGenerar = ReporteCtaCte.VENCIMIENTO
                f.Show(Me)
            Case "anticipos"
                f = New FormCtaCteCliente
                f.ReporteAGenerar = ReporteCtaCte.ANTICIPOS
                f.Show(Me)
            Case "saldos"
                f = New FormCtaCteCliente
                f.ReporteAGenerar = ReporteCtaCte.SALDOS
                f.Show(Me)
            Case "mailingclientes"
                ShowForm(New FormInformeMailingClientes)
                '    Case "emisionsobres"
                '        ShowForm(New FormEmisionSobreCliente)

        End Select
    End Sub

    Private Sub MenuGestionProveedores(ByVal sender As Object, ByVal e As EventArgs)

        Dim f As FormCtaCteProveedor = Nothing
        Dim fc As FormCbteCompra = Nothing
        Dim fp As FormCbtePago = Nothing

        Select sender.Tag
            Case "edocta"
                f = New FormCtaCteProveedor
                f.ReporteAGenerar = ReporteCtaCte.EDOCTA
                f.Show(Me)
            Case "edoref"
                f = New FormCtaCteProveedor
                f.ReporteAGenerar = ReporteCtaCte.EDOREF
                f.Show(Me)
            Case "pendientes"
                f = New FormCtaCteProveedor
                f.ReporteAGenerar = ReporteCtaCte.PENDIENTES
                f.Show(Me)
                'vencimiento
            Case "vencimiento"
                f = New FormCtaCteProveedor
                f.ReporteAGenerar = ReporteCtaCte.VENCIMIENTO
                f.Show(Me)
            Case "anticipos"
                f = New FormCtaCteProveedor
                f.ReporteAGenerar = ReporteCtaCte.ANTICIPOS
                f.Show(Me)
            Case "saldos"
                f = New FormCtaCteProveedor
                f.ReporteAGenerar = ReporteCtaCte.SALDOS
                f.Show(Me)
            Case "ajustedeudor"
                fp = New FormCbtePago
                fp.TipoCbte = TipoEmisionCbte.AJUSTE_DEUDOR
                fp.ShowDialog()
            Case "ajusteacreedor"
                fp = New FormCbtePago
                fp.TipoCbte = TipoEmisionCbte.AJUSTE_ACREEDOR
                fp.ShowDialog()
            Case "cbtecompra"
                fc = New FormCbteCompra
                fc.TipoCbte = TipoEmisionCbte.COMPRA
                fc.ShowDialog()
            Case "consulta"
                ShowForm(New FormConsultaCompras)
                '    Case "abmprecios"
                '        ShowForm(New FormABMPrecios)
                '    Case "listaprecios"
                '        ShowForm(New FormInformePrecios)
            Case "periodo"
                ShowForm(New FormPeriodoCompras)
            Case "pago"
                fp = New FormCbtePago
                fp.TipoCbte = TipoEmisionCbte.ORDEN_DE_PAGO
                fp.ShowDialog()
            Case "cbtepresupuesto"
                fc = New FormCbteCompra
                fc.TipoCbte = TipoEmisionCbte.PRESUPUESTO
                fc.ShowDialog()
            Case "pagopresupuesto"
                fp = New FormCbtePago
                fp.TipoCbte = TipoEmisionCbte.PAGO_PRESUPUESTO
                fp.ShowDialog()
            Case "aplicacionanticipos"
                ShowForm(New FormAplicacionAnticiposProveedores)
        End Select
    End Sub

    Private Sub ToolStripButtonCbteElectronico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim f As New FormCbteVenta
        'f.TipoCbte = TipoEmisionCbte.ELECTRONICO
        'f.ShowDialog()
    End Sub

    Private Sub ToolStripButtonCbteMinorista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim f As New FormCbteVenta
        'f.TipoCbte = TipoEmisionCbte.FISCAL
        'f.ShowDialog()
    End Sub

    Private Sub DoLogin()


        Me.StatusUsuario.Text = "Login..."

        login = New FormLogin

        HabilitoGodMode(False)

        If login.ShowDialog(Me) = Windows.Forms.DialogResult.Cancel Then
            If MessageBox.Show("Abandonar la aplicación", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Application.Exit()
            Else
                DoLogin()
            End If
        Else

            Me.StatusUsuario.Text = "Bienvenido " & gUsuario.Nombre & ". Hora de ingreso " & gUsuario.LoginDate
            Me.StatusUsuario.Text &= " - App.Ver. " & My.Application.Info.Version.ToString
            HabilitoMostrador(Not (gUsuario.Perfil = PERFIL_MOSTRADOR))
            HabilitarMenu(gUsuario.Permisos)
            gUsuario.GodMode = True

            HabilitoGodMode(gUsuario.GodMode)
            CargarDatosEmpresa()

            Me.Text = My.Application.Info.Title & " " & My.Application.Info.Version.ToString & " - " & gEmpresa.NombreFantasia

        End If




    End Sub

    Private Sub DoGodMode()
        Dim f As New FormClave

        If f.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            HabilitoGodMode(gUsuario.GodMode)
        End If


    End Sub

    Private Sub FormMenu_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'solicito godmode
        If e.Control And e.Shift And e.KeyCode = Keys.P Then
            If gUsuario IsNot Nothing Then
                If Not gUsuario.GodMode Then
                    DoGodMode()
                Else

                    gUsuario.GodMode = False

                    HabilitoGodMode(gUsuario.GodMode)
                End If

            End If
        End If
    End Sub


    Private Sub FormMenu_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        DoApariencia()

        HabilitoGodMode(False)

        If gUsuario Is Nothing Then
            DoLogin()
        End If

    End Sub

    Private Sub DoApariencia()
        Try
            Me.BackColor = My.Settings.BackgroundColor
            Me.BackgroundImage = Image.FromFile(My.Settings.BackgroundImage)
        Catch ex As Exception
            Try
                Me.BackgroundImage = My.Resources.LOGO
            Catch ex2 As Exception
                Me.BackgroundImage = Nothing
            End Try

        End Try
    End Sub

    Private Sub HabilitoGodMode(ByVal p1 As Boolean)

        Me.mnuPresupuestos2.Visible = p1
        Me.mnuPresupuestoCpra.Visible = p1

    End Sub

    Private Sub ToolStripButtonMovCaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim f As FormMovimiento

        'Try
        '    f = New FormMovimiento
        '    f.ShowDialog()
        'Catch ex As Exception
        '    Debug.Print(ex.Message)
        'Finally
        '    f = Nothing
        'End Try
    End Sub


    Private Sub HabilitoMostrador(ByVal p1 As Boolean)
        mnuGestionClientes.Enabled = p1
        mnuGestionProveedores.Enabled = p1
        mnuEstadisticas.Enabled = p1
        mnuFinanciero.Enabled = p1
        ToolStripMenuItemEmisionRemito.Enabled = p1
        ABMdeParametros.Enabled = p1
        ABMDeUsuarios.Enabled = p1
        CFGTerminal.Enabled = p1
        'EmisiónDeCbtePreimpresoToolStripMenuItem.Enabled = p1
        'ReciboDeCobranzaToolStripMenuItem.Enabled = p1
        CbtesElectrónicosToolStripMenuItem.Enabled = p1
        ConsultaDeComprobantesToolStripMenuItem.Enabled = p1
        AplicaciónDeAnticiposToolStripMenuItem.Enabled = p1
        AFIPToolStripMenuItem.Enabled = p1
        ControlDeNumeraciónToolStripMenuItem.Enabled = p1
        WSCDCToolStripMenuItem.Enabled = p1
        DatosDeLaEmpresaToolStripMenuItem.Enabled = p1
    End Sub


    Private Sub MenuModelos(ByVal sender As Object, ByVal e As EventArgs)
        'Select Case sender.Tag

        '    Case "cargamodelos" : ShowForm(New FormCargaModelos)
        '    Case "devolmodelos" : ShowForm(New FormDevolucionModelos)
        '    Case "listadomodelos" : ShowForm(New FormListaModelos)
        '    Case "informemodelos" : ShowForm(New FormInformeMovModelos)
        'End Select
    End Sub

    Private Sub MenuFinanciero(ByVal sender As Object, ByVal e As EventArgs)
        Select sender.Tag
            Case "consultacheque" : ShowForm(New FormConsultaCheque)
            Case "edocta" : ShowForm(New FormInformeEdoCta)
            Case "cartera" : ShowForm(New FormInformeCartera)
            Case "diariocaja" : ShowForm(New FormDiario)
            Case "simple" : ShowForm(New FormMovimiento)
            Case "entrectas" : ShowForm(New FormMovimientoEntreCtas)
            Case "anulamovctas" : ShowForm(New FormAnulaMovCtas)
            Case "deposito" : ShowForm(New FormDepositoCartera)
            Case "anuladeposito" : ShowForm(New FormAnulacionDepositoCartera)
            Case "saldosconcepto" : ShowForm(New FormInfSaldoConcepto)
            Case "balanceingegr" : ShowForm(New FormInfBalanceIngEgr)
        End Select
    End Sub

    Private Sub MenuOrdenesCompra(ByVal sender As Object, ByVal e As EventArgs)
        Select sender.Tag
            Case "cargaordenescompra" : ShowForm(New FormCbteOrdenCompra)
            Case "cbmordenes" : ShowForm(New FormConsultaOrdenCompra)
            Case "informeordenescompra" : ShowForm(New FormInfOrdenCompra)
                '    Case "expedicion" : ShowForm(New FormExpedicion)
                '    Case "reinicioexpedicion" : ShowForm(New FormReinicioExpedicion)
                '    Case "cargamodifmoldeodesc" : ShowForm(New FormABMMoldeoDescarte)
                '    Case "planmoldeo" : ShowForm(New FormPlanMoldeo)
        End Select
    End Sub

    Private Sub HabilitarMenu(ByVal list As List(Of Entidades.Perfilpermiso))

        Dim hijo As String
        Dim padre As String
        Dim query As IEnumerable(Of Entidades.Perfilpermiso)

        For Each mnuItem As ToolStripMenuItem In Me.MenuStripPrincipal.Items

            hijo = mnuItem.Name
            padre = mnuItem.Name

            query =
            From i As Entidades.Perfilpermiso In list Where (i.Padre.Equals(padre)) And (i.Hijo.Equals(hijo))

            If query.Count <= 0 Then
                mnuItem.Enabled = True
            Else
                For Each obj As Entidades.Perfilpermiso In query
                    mnuItem.Enabled = obj.Activo
                Next
            End If

            If mnuItem.DropDownItems.Count > 0 Then
                RecorrerMenuPermiso(mnuItem, list)
            End If

        Next
    End Sub


    Private Sub RecorrerMenuPermiso(ByRef oMenuItem As ToolStripMenuItem, ByVal list As List(Of Entidades.Perfilpermiso))

        Dim i As ToolStripMenuItem
        Dim query As IEnumerable(Of Entidades.Perfilpermiso)
        Dim hijo As String
        Dim padre As String

        For Each o As Object In oMenuItem.DropDownItems

            If o.GetType Is GetType(ToolStripMenuItem) Then

                i = o

                hijo = i.Name
                padre = oMenuItem.Name

                query =
                From x As Entidades.Perfilpermiso In list Where (x.Padre.Equals(padre)) And (x.Hijo.Equals(hijo))

                If query.Count <= 0 Then
                    i.Enabled = True
                Else
                    For Each obj As Entidades.Perfilpermiso In query
                        i.Enabled = obj.Activo
                    Next
                End If

                If i.DropDownItems.Count > 0 Then
                    RecorrerMenuPermiso(i, list)
                End If

            End If

        Next

    End Sub

    Private Sub ToolStripButtonClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonClientes.Click
        ShowForm(New FormABMCliente)
    End Sub

  
    Private Sub BtnConsultaArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsultaArticulo.Click
        Dim f As New FormABMArticulo
        f.Consulta = True
        f.Show(Me)
    End Sub

    Private Sub btnEmisionCbte_Click(sender As System.Object, e As System.EventArgs) Handles btnEmisionCbte.Click
        Dim f As FormCbteVentaKiosco = Nothing
        f = New FormCbteVentaKiosco
        f.TipoCbte = TipoEmisionCbte.PRESUPUESTO
        f.Height = 590
        f.ShowDialog()
    End Sub

    Private Sub ToolStripButtonDiarioCaja_Click(sender As Object, e As EventArgs) Handles ToolStripButtonDiarioCaja.Click
        Dim f As FormDiario

        Try
            f = New FormDiario
            f.ShowDialog()
        Catch ex As Exception
            Debug.Print(ex.Message)
        Finally
            f = Nothing
        End Try
    End Sub
End Class
