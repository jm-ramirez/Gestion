Imports Entidades
Imports MySql.Data.MySqlClient
Public Class CpracabeceraCDat

    Private ExceptionClassObject As New ManejoDeErrores.ExceptionClass
    Private ExceptionErrorFileString As String = My.Application.Info.DirectoryPath & "\ErrorFile.log"
    Private WriteErrorMessageString As String
    Private ErrorMessageString As String

    Public Const ORIGEN_COMPRA As String = "COMPRA"

    Public Const CONCEPTO_DEUDOR As String = "D"
    Public Const CONCEPTO_ACREEDOR As String = "C"
    Public Const CUENTA_CARTERA As String = "CARTERA"
    Public Const CONCEPTO_CHEQUE_RECIBIDO As String = "013"
    Public Const CONCEPTO_CHEQUE_PASADO As String = "014"
    Public Const CONCEPTO_CHEQUE_DEPOSITADO As String = "015"

    Private Const FP_CONTADO As Integer = 1
    Private Const FP_CTACTE As Integer = 2
    Private Const PTO_VTA_ELECTRONICO As String = "E"
    Private Const PTO_VTA_FISCAL As String = "F"
    Private Const PTO_VTA_MANUAL As String = "M"
    Private Const PTO_VTA_X As String = "X"

    Private Const FACTURA_A As UInt32 = 1
    Private Const FACTURA_B As UInt32 = 6
    Private Const NOTA_DEBITO_A As UInt32 = 2
    Private Const NOTA_DEBITO_B As UInt32 = 7
    Private Const TIQUE_FACTURA_A As UInt32 = 81
    Private Const TIQUE_FACTURA_B As UInt32 = 82
    Private Const NOTA_CREDITO_A As UInt32 = 3
    Private Const NOTA_CREDITO_B As UInt32 = 8
    Private Const PRESUPUESTO As UInt32 = 991
    Private Const DEVOLUCION_PRESUPUESTO As UInt32 = 992
    Private Const RECIBO_COBRANZA As UInt32 = 993
    Private Const ORDEN_PAGO As UInt32 = 994
    Private Const RECIBO_PRESUPUESTO As UInt32 = 995
    Private Const PAGO_PRESUPUESTO As UInt32 = 996


    Public Function Insert(ByVal obj As Cpracabecera) As UInt32

        Dim id As Long
        Dim idIngreso As Long
        Dim transaccion As MySqlTransaction = Nothing
        Dim cnn As MySqlConnection = Nothing
        Dim cmd As MySqlCommand
        Dim ptovta As New CbtepuntoventaCDat

        Try

            cnn = CreateConnection()
            cnn.Open()
            transaccion = cnn.BeginTransaction
            cmd = New MySqlCommand

            With cmd
                .Connection = cnn
                .Transaction = transaccion
                .CommandType = CommandType.Text

                'incremento la numeración de los comprobantes internos
                If obj.Cbtetipo = ORDEN_PAGO Or obj.Cbtetipo = PAGO_PRESUPUESTO Then

                    'actualizo la numeracion interna de comprobantes
                    .CommandText = "SELECT * FROM Cbtenumeracion WHERE ptovta = @ptovta AND cbtetipo = @cbtetipo FOR UPDATE"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@ptovta", obj.Cbteptovta)
                    .Parameters.AddWithValue("@cbtetipo", obj.Cbtetipo)
                    .Parameters.AddWithValue("@cbtenumero", obj.Cbtenumero)
                    .ExecuteNonQuery()

                    'si es un comprobante fiscal no incremento la numeración, registro el n
                    Select Case ptovta.GetByPtoVta(obj.Cbteptovta).Tipo
                        Case PTO_VTA_FISCAL : .CommandText = "UPDATE Cbtenumeracion SET numero = @cbtenumero WHERE ptovta = @ptovta AND cbtetipo = @cbtetipo"
                        Case Else : .CommandText = "UPDATE Cbtenumeracion SET numero = numero + 1 WHERE ptovta = @ptovta AND cbtetipo = @cbtetipo"
                    End Select

                    .ExecuteNonQuery()

                End If

                .CommandText = "INSERT INTO Cpracabecera (Id,Concepto,ProveedorId,Razonsocial,Domicilio,Nroremito,Documentotipo,Documentonro,"
                .CommandText &= "Cbtetipo,Cbteptovta,Cbtenumero,Cbtefecha,Formadepago,Importetotal,Importetotalconceptos,Importeneto,Importeopexentas,"
                .CommandText &= "Importeiva,Importetributos,Fechaserviciodesde,Fechaserviciohasta,Fechavtopago,Monedaid,Monedactz,Cae,Fechavtocae,"
                .CommandText &= "Observaciones,Tiporesponsable,Cuitemisor,Usuario,Vendedor,Sucursal,Descuento,Letra,Denominacion,Tipo,Importectaspropias,Importecartera,ObservacionesExtra,Importenoinscripto,codGastoV,CodImp) VALUES (null,@Concepto,@ProveedorId,@Razonsocial,@Domicilio,@Nroremito,@Documentotipo,@Documentonro,"
                .CommandText &= "@Cbtetipo,@Cbteptovta,@Cbtenumero,@Cbtefecha,@Formadepago,@Importetotal,@Importetotalconceptos,@Importeneto,@Importeopexentas,"
                .CommandText &= "@Importeiva,@Importetributos,@Fechaserviciodesde,@Fechaserviciohasta,@Fechavtopago,@Monedaid,@Monedactz,@Cae,@Fechavtocae,"
                .CommandText &= "@Observaciones,@Tiporesponsable,@Cuitemisor,@Usuario,@Vendedor,@Sucursal,@Descuento,@Letra,@Denominacion,@Tipo,@Importectaspropias,@Importecartera,@ObservacionesExtra,@Importenoinscripto,@codGastoV,@CodImp)"

                .Parameters.Clear()
                '.Parameters.AddWithValue("@Id", obj.Id)
                .Parameters.AddWithValue("@Concepto", obj.Concepto)
                .Parameters.AddWithValue("@ProveedorId", obj.ProveedorId)
                .Parameters.AddWithValue("@Razonsocial", obj.Razonsocial)
                .Parameters.AddWithValue("@Domicilio", obj.Domicilio)
                .Parameters.AddWithValue("@Nroremito", obj.Nroremito)
                .Parameters.AddWithValue("@Documentotipo", obj.Documentotipo)
                .Parameters.AddWithValue("@Documentonro", obj.Documentonro)
                .Parameters.AddWithValue("@Cbtetipo", obj.Cbtetipo)
                .Parameters.AddWithValue("@Cbteptovta", obj.Cbteptovta)
                .Parameters.AddWithValue("@Cbtenumero", obj.Cbtenumero)
                .Parameters.AddWithValue("@Cbtefecha", obj.Cbtefecha)
                .Parameters.AddWithValue("@Formadepago", obj.Formadepago)
                .Parameters.AddWithValue("@Importetotal", obj.Importetotal)
                .Parameters.AddWithValue("@Importetotalconceptos", obj.Importetotalconceptos)
                .Parameters.AddWithValue("@Importeneto", obj.Importeneto)
                .Parameters.AddWithValue("@Importeopexentas", obj.Importeopexentas)
                .Parameters.AddWithValue("@Importeiva", obj.Importeiva)
                .Parameters.AddWithValue("@Importetributos", obj.Importetributos)
                .Parameters.AddWithValue("@Fechaserviciodesde", obj.Fechaserviciodesde)
                .Parameters.AddWithValue("@Fechaserviciohasta", obj.Fechaserviciohasta)
                .Parameters.AddWithValue("@Fechavtopago", obj.Fechavtopago)
                .Parameters.AddWithValue("@Monedaid", obj.Monedaid)
                .Parameters.AddWithValue("@Monedactz", obj.Monedactz)
                .Parameters.AddWithValue("@Cae", obj.Cae)
                .Parameters.AddWithValue("@Fechavtocae", obj.Fechavtocae)
                .Parameters.AddWithValue("@Observaciones", obj.Observaciones)
                .Parameters.AddWithValue("@Tiporesponsable", obj.Tiporesponsable)
                .Parameters.AddWithValue("@Cuitemisor", obj.Cuitemisor)
                .Parameters.AddWithValue("@Usuario", obj.Usuario)
                .Parameters.AddWithValue("@Vendedor", obj.Vendedor)
                .Parameters.AddWithValue("@Sucursal", obj.Sucursal)
                .Parameters.AddWithValue("@Descuento", obj.Descuento)
                .Parameters.AddWithValue("@Letra", obj.Letra)
                .Parameters.AddWithValue("@Denominacion", obj.Denominacion)
                .Parameters.AddWithValue("@Tipo", obj.Tipo)
                .Parameters.AddWithValue("@Importectaspropias", obj.Importectaspropias)
                .Parameters.AddWithValue("@Importecartera", obj.Importecartera)
                .Parameters.AddWithValue("@ObservacionesExtra", obj.ObservacionesExtra)
                .Parameters.AddWithValue("@Importenoinscripto", obj.Importenoinscripto)
                .Parameters.AddWithValue("@codGastoV", obj.CodGastoV)
                .Parameters.AddWithValue("@codImp", obj.CodImp)
                .ExecuteNonQuery()

                'recupero el id de la factura creada
                id = .LastInsertedId

                'registro las alicuotas del combrobante
                For Each objAlic As Entidades.CbteAlicuota In obj.CbteAlicuotas
                    .CommandText = "INSERT INTO Cpraalicuota (Id,Cbteid,Codigo,Descripcion,Importe,Alicuota,Baseimponible) VALUES (null,@Cbteid,@Codigo,@Descripcion,@Importe,@Alicuota,@Baseimponible)"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@Cbteid", id)
                    .Parameters.AddWithValue("@Codigo", objAlic.Codigo)
                    .Parameters.AddWithValue("@Descripcion", objAlic.Descripcion)
                    .Parameters.AddWithValue("@Importe", objAlic.Importe)
                    .Parameters.AddWithValue("@Alicuota", objAlic.Alicuota)
                    .Parameters.AddWithValue("@Baseimponible", objAlic.BaseImponible)
                    .ExecuteNonQuery()
                Next

                'registro los comprobantes asociados
                For Each objAsoc As Entidades.CbteAsociado In obj.CbteAsociados
                    .CommandText = "INSERT INTO Cpraasociado (Id,Cbteid,Numero,Ptovta,Tipo,Importe,Cbtereferencia) VALUES (null,@Cbteid,@Numero,@Ptovta,@Tipo,@Importe,@Cbtereferencia)"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@Cbteid", id)
                    .Parameters.AddWithValue("@Cbtereferencia", objAsoc.CbteReferencia)
                    .Parameters.AddWithValue("@Numero", objAsoc.Numero)
                    .Parameters.AddWithValue("@Ptovta", objAsoc.PtoVta)
                    .Parameters.AddWithValue("@Tipo", objAsoc.Tipo)
                    .Parameters.AddWithValue("@Importe", objAsoc.Importe)
                    .ExecuteNonQuery()
                Next

                'registro los tributos del combrobante
                For Each objTrib As Entidades.CbteTributo In obj.CbteTributos
                    .CommandText = "INSERT INTO Cpratributo (Id,Cbteid,Codigo,Descripcion,Importe,Alicuota,Baseimponible,Referencia) VALUES (null,@Cbteid,@Codigo,@Descripcion,@Importe,@Alicuota,@Baseimponible,@Referencia)"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@Cbteid", id)
                    .Parameters.AddWithValue("@Codigo", objTrib.Codigo)
                    .Parameters.AddWithValue("@Descripcion", objTrib.Descripcion)
                    .Parameters.AddWithValue("@Importe", objTrib.Importe)
                    .Parameters.AddWithValue("@Alicuota", objTrib.Alicuota)
                    .Parameters.AddWithValue("@Baseimponible", objTrib.BaseImponible)
                    .Parameters.AddWithValue("@Referencia", objTrib.Referencia)
                    .ExecuteNonQuery()
                Next

                If obj.Cbtetipo <> ORDEN_PAGO And obj.Cbtetipo <> PAGO_PRESUPUESTO Then
                    'registro la Cabecera del ingreso
                    .CommandText = "INSERT INTO Ingresoscab (id,Fecha,tipo,Codimpeg,Cbte,Observacion,ProveedorId) VALUES (null,@Fecha,@tipo,@Codimpeg,@Cbte,@Observacion,@ProveedorId)"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@Fecha", obj.Cbtefecha)
                    .Parameters.AddWithValue("@tipo", If(obj.Tipo = "D", "I", "E"))
                    .Parameters.AddWithValue("@Codimpeg", "")
                    .Parameters.AddWithValue("@Cbte", 0)
                    .Parameters.AddWithValue("@Observacion", "")
                    .Parameters.AddWithValue("@ProveedorId", obj.ProveedorId)
                    .ExecuteNonQuery()

                    idIngreso = .LastInsertedId
                End If

                'registro los articulos del combrobante y la ficha de stock
                For Each objArt As Entidades.CbteArticulo In obj.CbteArticulos

                    'articulos del comprobante
                    .CommandText = "INSERT INTO Cpraarticulo (Id,Cbteid,Codigo,Descripcion,Cantidad,Importe,ImpIntTasaNominal,Alicuotacodigo,"
                    .CommandText &= "Alicuota,Unidad,Descuento,Listadeprecio,Comision,ImpInterno,rubro) VALUES (null,@Cbteid,@Codigo,@Descripcion,@Cantidad,@Importe,@ImpIntTasaNominal,"
                    .CommandText &= "@Alicuotacodigo,@Alicuota,@Unidad,@Descuento,@Listadeprecio,@Comision,@ImpInterno,@rubro)"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@Cbteid", id)
                    .Parameters.AddWithValue("@Codigo", objArt.Codigo)
                    .Parameters.AddWithValue("@Descripcion", objArt.Descripcion)
                    .Parameters.AddWithValue("@Cantidad", objArt.Cantidad)
                    .Parameters.AddWithValue("@Importe", objArt.Importe)
                    .Parameters.AddWithValue("@ImpIntTasaNominal", objArt.ImpIntTasaNominal)
                    .Parameters.AddWithValue("@Alicuotacodigo", objArt.AlicuotaCodigo)
                    .Parameters.AddWithValue("@Alicuota", objArt.Alicuota)
                    .Parameters.AddWithValue("@Unidad", objArt.Unidad)
                    .Parameters.AddWithValue("@Descuento", objArt.Descuento)
                    .Parameters.AddWithValue("@Listadeprecio", objArt.Listadeprecio)
                    .Parameters.AddWithValue("@Comision", objArt.Comision)
                    .Parameters.AddWithValue("@ImpInterno", objArt.ImpInterno)
                    .Parameters.AddWithValue("@rubro", objArt.Rubro)
                    .ExecuteNonQuery()

                    If obj.Cbtetipo <> ORDEN_PAGO And obj.Cbtetipo <> PAGO_PRESUPUESTO Then
                        'Detalle del ingreso
                        .CommandText = "INSERT INTO Ingresosdet (Id,Idingreso,codarticulo,Cantidad,Precio,Cbtetipo,Cbteptovta,Cbtenumero) VALUES (null,@Idingreso,@codarticulo,@Cantidad,@Precio,@Cbtetipo,@Cbteptovta,@Cbtenumero)"
                        .Parameters.Clear()
                        .Parameters.AddWithValue("@Idingreso", idIngreso)
                        .Parameters.AddWithValue("@codarticulo", objArt.Codigo)
                        .Parameters.AddWithValue("@Cantidad", objArt.Cantidad)
                        .Parameters.AddWithValue("@Precio", objArt.Importe)
                        .Parameters.AddWithValue("@Cbtetipo", obj.Cbtetipo)
                        .Parameters.AddWithValue("@Cbteptovta", obj.Cbteptovta)
                        .Parameters.AddWithValue("@Cbtenumero", obj.Cbtenumero)
                        .ExecuteNonQuery()

                        'actualizacion de campos de Material de Compra
                        '.CommandText = "UPDATE materialcpra SET precioultcompra=@precioultcompra,fechaultimacompra=@fechaultimacompra WHERE codigo=@codigo"
                        '.Parameters.Clear()
                        '.Parameters.AddWithValue("@precioultcompra", objArt.Importe)
                        '.Parameters.AddWithValue("@fechaultimacompra", obj.Cbtefecha.Substring(0, 4) & "/" & obj.Cbtefecha.Substring(4, 2) & "/" & obj.Cbtefecha.Substring(6, 2))
                        ''.Parameters.AddWithValue("@codigo", objArt.Plu)
                        '.ExecuteNonQuery()

                        ''Actualizo y/o Agrego Registro en Precios
                        '.CommandText = "INSERT INTO precioscpra "
                        '.CommandText &= " (id,codmat,idprov,preciolista,fechalista,observacion,precioultcompra,fechaultimacompra) "
                        '.CommandText &= " VALUES "
                        '.CommandText &= " (@id,@codmat,@idprov,@preciolista,@fechalista,@observacion,@precioultcompra,@fechaultimacompra) "
                        '.CommandText &= " ON DUPLICATE KEY UPDATE "
                        '.CommandText &= " codmat=@codmat,idprov=@idprov,preciolista=@preciolista,fechalista=@fechalista,observacion=@observacion,precioultcompra=@precioultcompra,fechaultimacompra=@fechaultimacompra "

                        '.Parameters.Clear()
                        '.Parameters.AddWithValue("@id", Nothing)
                        ''.Parameters.AddWithValue("@codmat", objArt.Plu)
                        '.Parameters.AddWithValue("@idprov", obj.ProveedorId)
                        '.Parameters.AddWithValue("@preciolista", objArt.Importe)
                        '.Parameters.AddWithValue("@fechalista", obj.Cbtefecha)
                        '.Parameters.AddWithValue("@observacion", "")
                        '.Parameters.AddWithValue("@precioultcompra", objArt.Importe)
                        '.Parameters.AddWithValue("@fechaultimacompra", obj.Cbtefecha)
                        '.ExecuteNonQuery()

                        'ficha de stock
                        .CommandText = "INSERT INTO Fichastock (Id,Origen,CbteCpra,Fecha,Articulo,Cantidad,Sucursal,Usuario) VALUES (null,@Origen,@CbteCpra,@Fecha,@Articulo,@Cantidad,@Sucursal,@Usuario)"
                        .Parameters.Clear()
                        .Parameters.AddWithValue("@Origen", ORIGEN_COMPRA)
                        .Parameters.AddWithValue("@CbteCpra", id)
                        .Parameters.AddWithValue("@Fecha", obj.Cbtefechaingreso.Substring(0, 4) & "/" & obj.Cbtefechaingreso.Substring(4, 2) & "/" & obj.Cbtefechaingreso.Substring(6, 2))
                        .Parameters.AddWithValue("@Articulo", objArt.Codigo)

                        Select Case obj.Tipo
                            Case CONCEPTO_DEUDOR
                                .Parameters.AddWithValue("@Cantidad", objArt.Cantidad)
                            Case Else
                                .Parameters.AddWithValue("@Cantidad", (objArt.Cantidad * -1))
                        End Select

                        .Parameters.AddWithValue("@Sucursal", obj.Sucursal)
                        .Parameters.AddWithValue("@Usuario", obj.Usuario)
                        .ExecuteNonQuery()

                        'actualizacion de campos de articulos
                        .CommandText = "UPDATE articulos SET preciodecompra=@preciodecompra,fechaultimacompra=@fechaultimacompra WHERE Codigo=@Codigo"
                        .Parameters.Clear()
                        '.Parameters.AddWithValue("@preciodecosto", objArt.Importe)
                        .Parameters.AddWithValue("@preciodecompra", objArt.Importe)
                        .Parameters.AddWithValue("@fechaultimacompra", obj.Cbtefecha.Substring(0, 4) & "/" & obj.Cbtefecha.Substring(4, 2) & "/" & obj.Cbtefecha.Substring(6, 2))
                        .Parameters.AddWithValue("@Codigo", objArt.Codigo)
                        .ExecuteNonQuery()
                    End If

                Next

                'registro en financiero el ingreso
                If obj.Formadepago = FP_CONTADO Then

                    'ojo! si proviene de un pago, los cheques solo deben cambiar su estado y no generar un nuevo registro
                    For Each objFinanciero As Entidades.Financiero In obj.CbteDetalleFinanciero

                        .Parameters.Clear()

                        If (obj.Cbtetipo = ORDEN_PAGO Or obj.Cbtetipo = PAGO_PRESUPUESTO) And objFinanciero.Cuenta = CUENTA_CARTERA And objFinanciero.Id <> 0 Then

                            .CommandText = "UPDATE Financiero SET Concepto=@Concepto,Beneficiario=@Beneficiario,"
                            .CommandText &= "Cbtecpra=@Cbtecpra,Tipo=@Tipo,Egreso = @Egreso WHERE id=@id"
                            .Parameters.AddWithValue("@id", objFinanciero.Id)

                        Else

                            .CommandText = "INSERT INTO Financiero (Id,Origen,Cuenta,Concepto,Beneficiario,Emision,Efectivizacion,Importe,"
                            .CommandText &= "Referencia,Observacion,Usuario,Fecharegistracion,Banco,Cbtecpra,Tipo,Dador,Sucursal,DocumentoNro,Localidad) VALUES (null,@Origen,@Cuenta,@Concepto,"
                            .CommandText &= "@Beneficiario,@Emision,@Efectivizacion,@Importe,@Referencia,@Observacion,@Usuario,@Fecharegistracion,@Banco,"
                            .CommandText &= "@Cbtecpra,@Tipo,@Dador,@Sucursal,@DocumentoNro,@Localidad)"

                            objFinanciero.Observacion &= obj.CbteDenominacion

                        End If


                        .Parameters.AddWithValue("@Origen", objFinanciero.Origen)
                        .Parameters.AddWithValue("@Cuenta", objFinanciero.Cuenta)
                        .Parameters.AddWithValue("@Concepto", objFinanciero.Concepto)
                        .Parameters.AddWithValue("@Beneficiario", objFinanciero.Beneficiario)
                        .Parameters.AddWithValue("@Dador", objFinanciero.Dador)
                        .Parameters.AddWithValue("@Emision", objFinanciero.Emision)
                        .Parameters.AddWithValue("@Efectivizacion", objFinanciero.Efectivizacion)
                        .Parameters.AddWithValue("@Importe", objFinanciero.Importe)
                        .Parameters.AddWithValue("@Referencia", objFinanciero.Referencia)
                        .Parameters.AddWithValue("@Observacion", objFinanciero.Observacion)
                        .Parameters.AddWithValue("@Usuario", obj.Usuario)
                        .Parameters.AddWithValue("@Fecharegistracion", Nothing)
                        .Parameters.AddWithValue("@Banco", objFinanciero.Banco)
                        .Parameters.AddWithValue("@Tipo", objFinanciero.Tipo)
                        .Parameters.AddWithValue("@Cbtecpra", id)
                        .Parameters.AddWithValue("@Sucursal", obj.Sucursal)
                        .Parameters.AddWithValue("@Documentonro", objFinanciero.DocumentoNro)
                        .Parameters.AddWithValue("@Localidad", objFinanciero.Localidad)
                        .Parameters.AddWithValue("@Egreso", objFinanciero.Emision)
                        .ExecuteNonQuery()

                    Next


                End If

                If obj.Cbtetipo <> ORDEN_PAGO And obj.Cbtetipo <> PAGO_PRESUPUESTO Then
                    'actulizo la ultima fecha de operatoria del cliente/proveedor
                    .CommandText = "UPDATE proveedor SET Fechaultimacompra=@fechaultimacompra WHERE id = @id"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@id", obj.ProveedorId)
                    .Parameters.AddWithValue("@fechaultimacompra", obj.Cbtefecha)
                    .ExecuteNonQuery()
                End If

            End With

            transaccion.Commit()

            Return id

        Catch exError As MySqlException

            If transaccion IsNot Nothing Then
                transaccion.Rollback()
            End If

            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cpracabecera", _
            "Insert", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)

        Finally
            If cnn IsNot Nothing Then
                If cnn.State = ConnectionState.Open Then
                    cnn.Close()
                End If
            End If
        End Try
    End Function

    Public Sub Update(ByVal obj As CpraCabecera)
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "UPDATE Cpracabecera SET Concepto = @Concepto,ProveedorId = @ProveedorId,Razonsocial = @Razonsocial,"
                        .CommandText &= "Domicilio = @Domicilio,Nroremito = @Nroremito,Documentotipo = @Documentotipo,Documentonro = @Documentonro,"
                        .CommandText &= "Cbtetipo = @Cbtetipo,Cbteptovta = @Cbteptovta,Cbtenumero = @Cbtenumero,Cbtefecha = @Cbtefecha,Formadepago = @Formadepago,"
                        .CommandText &= "Importetotal = @Importetotal,Importetotalconceptos = @Importetotalconceptos,Importeneto = @Importeneto,"
                        .CommandText &= "Importeopexentas = @Importeopexentas,Importeiva = @Importeiva,Importetributos = @Importetributos,"
                        .CommandText &= "Fechaserviciodesde = @Fechaserviciodesde,Fechaserviciohasta = @Fechaserviciohasta,Fechavtopago = @Fechavtopago,"
                        .CommandText &= "Monedaid = @Monedaid,Monedactz = @Monedactz,Cae = @Cae,Fechavtocae = @Fechavtocae,"
                        .CommandText &= "Observaciones = @Observaciones,Tiporesponsable = @Tiporesponsable,Cuitemisor = @Cuitemisor,Importenoinscripto=@Importenoinscripto,codGastoV=@codGastoV,codImp=@codImp WHERE Id = @Id"
                        .Parameters.AddWithValue("@Id", obj.Id)
                        .Parameters.AddWithValue("@Concepto", obj.Concepto)
                        .Parameters.AddWithValue("@ProveedorId", obj.ProveedorId)
                        .Parameters.AddWithValue("@Razonsocial", obj.Razonsocial)
                        .Parameters.AddWithValue("@Domicilio", obj.Domicilio)
                        .Parameters.AddWithValue("@Nroremito", obj.Nroremito)
                        .Parameters.AddWithValue("@Documentotipo", obj.Documentotipo)
                        .Parameters.AddWithValue("@Documentonro", obj.Documentonro)
                        .Parameters.AddWithValue("@Cbtetipo", obj.Cbtetipo)
                        .Parameters.AddWithValue("@Cbteptovta", obj.Cbteptovta)
                        .Parameters.AddWithValue("@Cbtenumero", obj.Cbtenumero)
                        .Parameters.AddWithValue("@Cbtefecha", obj.Cbtefecha)
                        .Parameters.AddWithValue("@Formadepago", obj.Formadepago)
                        .Parameters.AddWithValue("@Importetotal", obj.Importetotal)
                        .Parameters.AddWithValue("@Importetotalconceptos", obj.Importetotalconceptos)
                        .Parameters.AddWithValue("@Importeneto", obj.Importeneto)
                        .Parameters.AddWithValue("@Importeopexentas", obj.Importeopexentas)
                        .Parameters.AddWithValue("@Importeiva", obj.Importeiva)
                        .Parameters.AddWithValue("@Importetributos", obj.Importetributos)
                        .Parameters.AddWithValue("@Fechaserviciodesde", obj.Fechaserviciodesde)
                        .Parameters.AddWithValue("@Fechaserviciohasta", obj.Fechaserviciohasta)
                        .Parameters.AddWithValue("@Fechavtopago", obj.Fechavtopago)
                        .Parameters.AddWithValue("@Monedaid", obj.Monedaid)
                        .Parameters.AddWithValue("@Monedactz", obj.Monedactz)
                        .Parameters.AddWithValue("@Cae", obj.Cae)
                        .Parameters.AddWithValue("@Fechavtocae", obj.Fechavtocae)
                        .Parameters.AddWithValue("@Observaciones", obj.Observaciones)
                        .Parameters.AddWithValue("@Tiporesponsable", obj.Tiporesponsable)
                        .Parameters.AddWithValue("@Cuitemisor", obj.Cuitemisor)
                        .Parameters.AddWithValue("@Importenoinscripto", obj.Importenoinscripto)
                        .Parameters.AddWithValue("@codGastoV", obj.CodGastoV)
                        .Parameters.AddWithValue("@codImp", obj.CodImp)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cpracabecera", _
            "Update", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Sub

    Public Sub UpdatePeriodo(ByVal obj As CpraCabecera)
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "UPDATE Cpracabecera SET Fechaserviciodesde = @Fechaserviciodesde,Fechaserviciohasta = @Fechaserviciohasta "
                        .CommandText &= " WHERE Id = @Id"
                        .Parameters.AddWithValue("@Id", obj.Id)
                        .Parameters.AddWithValue("@Fechaserviciodesde", obj.Fechaserviciodesde)
                        .Parameters.AddWithValue("@Fechaserviciohasta", obj.Fechaserviciohasta)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cpracabecera", _
            "UpdatePeriodo", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Sub

    Public Sub Delete(ByVal id As UInt32)
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "DELETE FROM Cpracabecera WHERE Id = @Id"
                        .Parameters.AddWithValue("@Id", id)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cpracabecera", _
            "Delete", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Sub

    Public Function GetById(ByVal id As UInt32, _
                              Optional ByVal cargaCtaCte As Boolean = True, _
                              Optional ByVal cargaAlicuotas As Boolean = True, _
                              Optional ByVal cargaArticulos As Boolean = True, _
                              Optional ByVal cargaFinanciero As Boolean = True, _
                              Optional ByVal cargaTributos As Boolean = True, _
                              Optional ByVal cargaAsociados As Boolean = True) As CpraCabecera
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Cpracabecera WHERE Id= @Id"
                        .Parameters.AddWithValue("@Id", id)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Dim obj As New CpraCabecera
                                'obj = Populate(reader)
                                obj = Populate(reader:=reader, cargaCtaCte:=cargaCtaCte, cargaAlicuotas:=cargaAlicuotas, cargaArticulos:=cargaArticulos, cargaFinanciero:=cargaFinanciero, cargaTributos:=cargaTributos, cargaAsociados:=cargaAsociados)
                                Return obj
                            Else
                                Return Nothing
                            End If
                        End Using
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cpracabecera", _
            "GetById", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Overloads Function GetByNumero(ByVal Proveedor As UInt32, ByVal cbtetipo As UInt32, ByVal cbteptovta As UInt32, ByVal cbtenumero As UInt32, _
                              Optional ByVal cargaCtaCte As Boolean = True, _
                              Optional ByVal cargaAlicuotas As Boolean = True, _
                              Optional ByVal cargaArticulos As Boolean = True, _
                              Optional ByVal cargaFinanciero As Boolean = True, _
                              Optional ByVal cargaTributos As Boolean = True, _
                              Optional ByVal cargaAsociados As Boolean = True) As CpraCabecera
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Cpracabecera WHERE proveedorid = @proveedor AND cbtetipo= @cbtetipo AND cbteptovta = @cbteptovta AND cbtenumero = @cbtenumero"
                        .Parameters.AddWithValue("@cbtetipo", cbtetipo)
                        .Parameters.AddWithValue("@cbteptovta", cbteptovta)
                        .Parameters.AddWithValue("@cbtenumero", cbtenumero)
                        .Parameters.AddWithValue("@proveedor", Proveedor)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Dim obj As New CpraCabecera
                                'obj = Populate(reader)
                                obj = Populate(reader:=reader, cargaCtaCte:=cargaCtaCte, cargaAlicuotas:=cargaAlicuotas, cargaArticulos:=cargaArticulos, cargaFinanciero:=cargaFinanciero, cargaTributos:=cargaTributos, cargaAsociados:=cargaAsociados)
                                Return obj
                            Else
                                Return Nothing
                            End If
                        End Using
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cpracabecera", _
            "GetByNumero", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Overloads Function GetByNumero(ByVal cbtetipo As UInt32, ByVal cbteptovta As UInt32, ByVal cbtenumero As UInt32, _
                              Optional ByVal cargaCtaCte As Boolean = False, _
                              Optional ByVal cargaAlicuotas As Boolean = False, _
                              Optional ByVal cargaArticulos As Boolean = False, _
                              Optional ByVal cargaFinanciero As Boolean = False, _
                              Optional ByVal cargaTributos As Boolean = False, _
                              Optional ByVal cargaAsociados As Boolean = False) As CpraCabecera
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Cpracabecera WHERE cbtetipo= @cbtetipo AND cbteptovta = @cbteptovta AND cbtenumero = @cbtenumero"
                        .Parameters.AddWithValue("@cbtetipo", cbtetipo)
                        .Parameters.AddWithValue("@cbteptovta", cbteptovta)
                        .Parameters.AddWithValue("@cbtenumero", cbtenumero)

                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Dim obj As New CpraCabecera
                                'obj = Populate(reader)
                                obj = Populate(reader:=reader, cargaCtaCte:=cargaCtaCte, cargaAlicuotas:=cargaAlicuotas, cargaArticulos:=cargaArticulos, cargaFinanciero:=cargaFinanciero, cargaTributos:=cargaTributos, cargaAsociados:=cargaAsociados)
                                Return obj
                            Else
                                Return Nothing
                            End If
                        End Using
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cpracabecera", _
            "GetByNumero", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetAll(Optional ByVal cargaCtaCte As Boolean = True, _
                              Optional ByVal cargaAlicuotas As Boolean = True, _
                              Optional ByVal cargaArticulos As Boolean = True, _
                              Optional ByVal cargaFinanciero As Boolean = True, _
                              Optional ByVal cargaTributos As Boolean = True, _
                              Optional ByVal cargaAsociados As Boolean = True) As List(Of CpraCabecera)
        Try
            Dim lista As New List(Of CpraCabecera)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Cpracabecera"
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New CpraCabecera
                                    'obj = Populate(reader)
                                    obj = Populate(reader:=reader, cargaCtaCte:=cargaCtaCte, cargaAlicuotas:=cargaAlicuotas, cargaArticulos:=cargaArticulos, cargaFinanciero:=cargaFinanciero, cargaTributos:=cargaTributos, cargaAsociados:=cargaAsociados)
                                    lista.Add(obj)
                                    obj = Nothing
                                Loop
                                Return lista
                            End Using
                        Finally
                            lista = Nothing
                        End Try
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cpracabecera", _
            "GetAll", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetAllByProveedor(ByVal Proveedor As UInt32, Optional ByVal vertodos As Boolean = False, _
                              Optional ByVal cargaCtaCte As Boolean = True, _
                              Optional ByVal cargaAlicuotas As Boolean = True, _
                              Optional ByVal cargaArticulos As Boolean = True, _
                              Optional ByVal cargaFinanciero As Boolean = True, _
                              Optional ByVal cargaTributos As Boolean = True, _
                              Optional ByVal cargaAsociados As Boolean = True) As List(Of CpraCabecera)
        Try
            Dim lista As New List(Of CpraCabecera)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Cpracabecera WHERE ProveedorId = @Proveedor"

                        If Not vertodos Then
                            .CommandText &= " AND cbtetipo NOT IN (991,992,995,996)"
                        End If

                        .Parameters.AddWithValue("@Proveedor", Proveedor)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New CpraCabecera
                                    'obj = Populate(reader)
                                    obj = Populate(reader:=reader, cargaCtaCte:=cargaCtaCte, cargaAlicuotas:=cargaAlicuotas, cargaArticulos:=cargaArticulos, cargaFinanciero:=cargaFinanciero, cargaTributos:=cargaTributos, cargaAsociados:=cargaAsociados)
                                    lista.Add(obj)
                                    obj = Nothing
                                Loop
                                Return lista
                            End Using
                        Finally
                            lista = Nothing
                        End Try
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cpracabecera", _
            "GetAllByProveedor", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetCbtesCtaCteByProveedor(ByVal Proveedor As UInt32, _
                              Optional ByVal cargaCtaCte As Boolean = True, _
                              Optional ByVal cargaAlicuotas As Boolean = True, _
                              Optional ByVal cargaArticulos As Boolean = True, _
                              Optional ByVal cargaFinanciero As Boolean = True, _
                              Optional ByVal cargaTributos As Boolean = True, _
                              Optional ByVal cargaAsociados As Boolean = True, _
                              Optional ByVal blnVerTodo As Boolean = False) As List(Of CpraCabecera)
        Try
            Dim lista As New List(Of CpraCabecera)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Cpracabecera WHERE ProveedorId = @Proveedor" ' AND FormaDePago<>@formapago"
                        '.CommandText = "SELECT *,CbteReferencia,SUM(Importe) Saldo FROM ( "
                        '.CommandText &= "SELECT r.*,r.`Id` CbteReferencia,IF(r.`Tipo`='C',r.`ImporteTotal`*-1,r.`ImporteTotal`) Importe "
                        '.CommandText &= "FROM `cpracabecera` r,`tipocomprobante` t "
                        '.CommandText &= "WHERE r.`CbteTipo` = t.`Codigo` "
                        '.CommandText &= "AND r.`CbteTipo` IN (1,6,81,82,11,51,83) "
                        '.CommandText &= "AND r.ProveedorId=@proveedor "
                        '.CommandText &= "UNION ALL "
                        '.CommandText &= "SELECT r.*,c.`CbteReferencia`,IF(r.`Tipo`='C',c.`Importe`*-1,c.`Importe`) Importe "
                        '.CommandText &= "FROM `cpracabecera` r,`cpraasociado` c,`tipocomprobante` t "
                        '.CommandText &= "WHERE r.id = c.`CbteId` "
                        '.CommandText &= "AND r.`CbteTipo` = t.`Codigo` "
                        '.CommandText &= "AND r.`CbteTipo` NOT IN (1,6,81,82,11,51,83) "
                        '.CommandText &= "AND r.ProveedorId=@proveedor "
                        '.CommandText &= "ORDER BY proveedorid,CbteTipo,CbteFecha,CbtePtoVta,CbteNumero "
                        '.CommandText &= ") Pendientes "
                        '.CommandText &= "GROUP BY CbteReferencia HAVING (ABS(Saldo) " & IIf(blnVerTodo = False, ">", ">=") & " 0) "
                        '.CommandText &= "ORDER BY ProveedorId,CbteTipo,CbteFecha,CbtePtoVta,CbteNumero"
                        .Parameters.Clear()
                        .Parameters.AddWithValue("@Proveedor", Proveedor)
                        .Parameters.AddWithValue("@formapago", FP_CONTADO)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New CpraCabecera
                                    'obj = Populate(reader)
                                    obj = Populate(reader:=reader, cargaCtaCte:=cargaCtaCte, cargaAlicuotas:=cargaAlicuotas, cargaArticulos:=cargaArticulos, cargaFinanciero:=cargaFinanciero, cargaTributos:=cargaTributos, cargaAsociados:=cargaAsociados)
                                    lista.Add(obj)
                                    obj = Nothing
                                Loop
                                Return lista
                            End Using
                        Finally
                            lista = Nothing
                        End Try
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cpracabecera", _
            "GetCbtesCtaCteByProveedor", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetAlicuotas(ByVal Id As UInt32) As List(Of CbteAlicuota)
        Try
            Dim lista As New List(Of CbteAlicuota)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Cpraalicuota WHERE CbteId = @Id"
                        .Parameters.AddWithValue("@Id", Id)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New CbteAlicuota
                                    obj = PopulateAlicuota(reader)
                                    lista.Add(obj)
                                    obj = Nothing
                                Loop
                                Return lista
                            End Using
                        Finally
                            lista = Nothing
                        End Try
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cpracabecera", _
            "GetAlicuotas", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetTributos(ByVal Id As UInt32) As List(Of CbteTributo)
        Try
            Dim lista As New List(Of CbteTributo)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM CpraTributo WHERE CbteId = @Id"
                        .Parameters.AddWithValue("@Id", Id)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New CbteTributo
                                    obj = PopulateTributo(reader)
                                    lista.Add(obj)
                                    obj = Nothing
                                Loop
                                Return lista
                            End Using
                        Finally
                            lista = Nothing
                        End Try
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cpracabecera", _
            "GetTributos", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetArticulos(ByVal Id As UInt32) As List(Of CbteArticulo)
        Try
            Dim lista As New List(Of CbteArticulo)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM CpraArticulo WHERE CbteId = @Id"
                        .Parameters.AddWithValue("@Id", Id)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New CbteArticulo
                                    obj = PopulateArticulo(reader)
                                    lista.Add(obj)
                                    obj = Nothing
                                Loop
                                Return lista
                            End Using
                        Finally
                            lista = Nothing
                        End Try
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cpracabecera", _
            "GetArticulos", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetCbtesAsociados(ByVal Id As UInt32) As List(Of CbteAsociado)
        Try
            Dim lista As New List(Of CbteAsociado)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM CpraAsociado WHERE CbteId = @Id"
                        .Parameters.AddWithValue("@Id", Id)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New CbteAsociado
                                    obj = PopulateCbteAsociado(reader)
                                    lista.Add(obj)
                                    obj = Nothing
                                Loop
                                Return lista
                            End Using
                        Finally
                            lista = Nothing
                        End Try
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cpracabecera", _
            "GetCbtesAsociados", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetEstadoCuenta(ByVal Id As UInt32) As List(Of CbteAsociado)
        Try
            Dim lista As New List(Of CbteAsociado)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT cpraasociado.cbteid, cpraasociado.CbteReferencia,Cpracabecera.CbteNumero Numero,Cpracabecera.CbtePtoVta PtoVta,Cpracabecera.CbteTipo Tipo, "
                        .CommandText &= "IF(Cpracabecera.tipo='C',cpraasociado.importe*-1,cpraasociado.importe) Importe, "
                        .CommandText &= "Cpracabecera.Denominacion,Cpracabecera.Letra,CAST(Cpracabecera.CbteFecha AS DATE) Fecha "
                        .CommandText &= "FROM(CpraAsociado, Cpracabecera) "
                        .CommandText &= "WHERE(CpraAsociado.cbteid = Cpracabecera.Id) "
                        .CommandText &= "AND CbteReferencia=@Id "
                        .Parameters.AddWithValue("@Id", Id)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New CbteAsociado
                                    obj = PopulateCbteAsociado(reader)
                                    lista.Add(obj)
                                    obj = Nothing
                                Loop
                                Return lista
                            End Using
                        Finally
                            lista = Nothing
                        End Try
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cpracabecera", _
            "GetEstadoDeCuenta", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Private Function Populate(ByVal reader As MySqlDataReader, _
                              Optional ByVal cargaCtaCte As Boolean = True, _
                              Optional ByVal cargaAlicuotas As Boolean = True, _
                              Optional ByVal cargaArticulos As Boolean = True, _
                              Optional ByVal cargaFinanciero As Boolean = True, _
                              Optional ByVal cargaTributos As Boolean = True, _
                              Optional ByVal cargaAsociados As Boolean = True) As CpraCabecera

        Dim obj As New CpraCabecera
        Try
            With obj
                .Id = Convert.ToUInt32(reader("Id"))
                .Concepto = Convert.ToInt32(reader("Concepto"))
                .ProveedorId = Convert.ToUInt32(reader("ProveedorId"))
                .Razonsocial = Convert.ToString(reader("Razonsocial"))
                .Domicilio = Convert.ToString(reader("Domicilio"))
                .Nroremito = Convert.ToString(reader("Nroremito"))
                .Documentotipo = Convert.ToInt32(reader("Documentotipo"))
                .Documentonro = Convert.ToUInt64(reader("Documentonro"))
                .Cbtetipo = Convert.ToInt32(reader("Cbtetipo"))
                .Cbteptovta = Convert.ToInt32(reader("Cbteptovta"))
                .Cbtenumero = Convert.ToUInt32(reader("Cbtenumero"))
                .Cbtefecha = Convert.ToString(reader("Cbtefecha"))
                .Formadepago = Convert.ToUInt32(reader("Formadepago"))
                .Importetotal = Convert.ToDouble(reader("Importetotal"))
                .Importetotalconceptos = Convert.ToDouble(reader("Importetotalconceptos"))
                .Importeneto = Convert.ToDouble(reader("Importeneto"))
                .Importeopexentas = Convert.ToDouble(reader("Importeopexentas"))
                .Importeiva = Convert.ToDouble(reader("Importeiva"))
                .Importetributos = Convert.ToDouble(reader("Importetributos"))
                .Importenoinscripto = Convert.ToDouble(reader("Importenoinscripto"))
                .Fechaserviciodesde = Convert.ToString(reader("Fechaserviciodesde"))
                .Fechaserviciohasta = Convert.ToString(reader("Fechaserviciohasta"))
                .Fechavtopago = Convert.ToString(reader("Fechavtopago"))
                .Monedaid = Convert.ToString(reader("Monedaid"))
                .Monedactz = Convert.ToDouble(reader("Monedactz"))
                .Cae = Convert.ToString(reader("Cae"))
                .Fechavtocae = Convert.ToString(reader("Fechavtocae"))
                .Observaciones = Convert.ToString(reader("Observaciones"))
                .ObservacionesExtra = Convert.ToString(reader("ObservacionesExtra"))
                .Tiporesponsable = Convert.ToUInt32(reader("Tiporesponsable"))
                .Cuitemisor = Convert.ToUInt64(reader("Cuitemisor"))
                .Usuario = Convert.ToUInt32(reader("Usuario"))
                '.Fechatransaccion = Convert.ToDateTime(reader("Fechatransaccion"))
                .Vendedor = Convert.ToUInt32(reader("Vendedor"))
                .Sucursal = Convert.ToUInt32(reader("Sucursal"))
                .Descuento = Convert.ToDouble(reader("Descuento"))
                .Letra = Convert.ToChar(reader("Letra"))
                .Denominacion = Convert.ToString(reader("Denominacion"))
                .Tipo = Convert.ToChar(reader("Tipo"))
                .CodGastoV = Convert.ToString(reader("codGastoV"))
                .CodImp = Convert.ToString(reader("codImp"))

                .Importectaspropias = Convert.ToDouble(reader("Importectaspropias"))
                .Importecartera = Convert.ToDouble(reader("Importecartera"))

                If cargaAlicuotas Then .CbteAlicuotas = GetAlicuotas(.Id)
                If cargaArticulos Then .CbteArticulos = GetArticulos(.Id)
                If cargaTributos Then .CbteTributos = GetTributos(.Id)
                If cargaAsociados Then .CbteAsociados = GetCbtesAsociados(.Id)
                If cargaCtaCte Then .CbteEstadoCuenta = GetEstadoCuenta(.Id)
                If cargaFinanciero Then .CbteDetalleFinanciero = GetCbteDetalleFinanciero(.Id)

            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function

    Private Function PopulateAlicuota(ByVal reader As MySqlDataReader) As CbteAlicuota
        Dim obj As New CbteAlicuota
        Try
            With obj
                .Id = Convert.ToUInt32(reader("Id"))
                '.CbteId = Convert.ToUInt32(reader("Id"))
                .Codigo = Convert.ToString(reader("Codigo"))
                .Descripcion = Convert.ToString(reader("Descripcion"))
                .Importe = Convert.ToDouble(reader("Importe"))
                .Alicuota = Convert.ToDouble(reader("Alicuota"))
                .BaseImponible = Convert.ToDouble(reader("BaseImponible"))
            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function

    Private Function PopulateTributo(ByVal reader As MySqlDataReader) As CbteTributo
        Dim obj As New CbteTributo
        Try
            With obj
                .Id = Convert.ToUInt32(reader("Id"))
                '.CbteId = Convert.ToUInt32(reader("Id"))
                .Referencia = Convert.ToString(reader("Referencia"))
                .Codigo = Convert.ToString(reader("Codigo"))
                .Descripcion = Convert.ToString(reader("Descripcion"))
                .Importe = Convert.ToDouble(reader("Importe"))
                .Alicuota = Convert.ToDouble(reader("Alicuota"))
                .BaseImponible = Convert.ToDouble(reader("BaseImponible"))
            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function

    Private Function PopulateArticulo(ByVal reader As MySqlDataReader) As CbteArticulo
        Dim obj As New CbteArticulo
        Try
            With obj
                .Id = Convert.ToUInt32(reader("Id"))
                '.CbteId = Convert.ToUInt32(reader("Id"))
                '.Plu = Convert.ToString(reader("Codigo"))
                .Descripcion = Convert.ToString(reader("Descripcion"))
                .Cantidad = Convert.ToDouble(reader("Cantidad"))
                .Importe = Convert.ToDouble(reader("Importe"))
                .ImpInterno = Convert.ToDouble(reader("ImpInterno"))
                .ImpIntTasaNominal = Convert.ToDouble(reader("ImpIntTasaNominal"))
                .Alicuota = Convert.ToDouble(reader("Alicuota"))
                .AlicuotaCodigo = Convert.ToInt32(reader("AlicuotaCodigo"))
                .Unidad = Convert.ToString(reader("Unidad"))
                .Rubro = Convert.ToString(reader("Rubro"))
            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function

    Private Function PopulateCbteAsociado(ByVal reader As MySqlDataReader) As CbteAsociado
        Dim obj As New CbteAsociado
        Try
            With obj
                .Id = Convert.ToUInt32(reader("CbteId"))
                '.CbteId = Convert.ToUInt32(reader("Id"))
                .Numero = Convert.ToInt64(reader("Numero"))
                .PtoVta = Convert.ToInt32(reader("PtoVta"))
                .Importe = Convert.ToDouble(reader("Importe"))
                .Tipo = Convert.ToInt32(reader("Tipo"))
                .CbteReferencia = Convert.ToUInt32(reader("CbteReferencia"))
            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function

    Public Function GetAnticiposProveedor(ByVal proveedor As UInt32, Optional ByVal vertodos As Boolean = False, Optional ByVal ordenDescendete As Boolean = False, _
                              Optional ByVal cargaCtaCte As Boolean = True, _
                              Optional ByVal cargaAlicuotas As Boolean = True, _
                              Optional ByVal cargaArticulos As Boolean = True, _
                              Optional ByVal cargaFinanciero As Boolean = True, _
                              Optional ByVal cargaTributos As Boolean = True, _
                              Optional ByVal cargaAsociados As Boolean = True) As List(Of CpraCabecera)
        Try
            Dim lista As New List(Of CpraCabecera)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM cpracabecera WHERE ProveedorId = @proveedor"

                        If Not vertodos Then
                            .CommandText &= " AND cbtetipo IN (993,994)"
                        Else
                            .CommandText &= " AND cbtetipo IN (993,994,995,996)"
                        End If

                        If ordenDescendete Then
                            .CommandText &= " ORDER BY id DESC"
                        End If

                        .Parameters.AddWithValue("@proveedor", proveedor)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New CpraCabecera
                                    'obj = Populate(reader)
                                    obj = Populate(reader:=reader, cargaCtaCte:=cargaCtaCte, cargaAlicuotas:=cargaAlicuotas, cargaArticulos:=cargaArticulos, cargaFinanciero:=cargaFinanciero, cargaTributos:=cargaTributos, cargaAsociados:=cargaAsociados)
                                    lista.Add(obj)
                                    obj = Nothing
                                Loop
                                Return lista
                            End Using
                        Finally
                            lista = Nothing
                        End Try
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cpracabecera", _
            "GetAnticiposProveedor", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function AplicarAnticipo(ByVal objAnticipo As CpraCabecera, ByVal cbtes As List(Of Entidades.CbteAsociado)) As UInt32

        Dim id As Long
        Dim transaccion As MySqlTransaction = Nothing
        Dim cnn As MySqlConnection = Nothing
        Dim cmd As MySqlCommand
        Dim ptovta As New CbtepuntoventaCDat

        Try

            cnn = CreateConnection()
            cnn.Open()
            transaccion = cnn.BeginTransaction
            cmd = New MySqlCommand

            With cmd
                .Connection = cnn
                .Transaction = transaccion
                .CommandType = CommandType.Text

                'registro los comprobantes asociados
                For Each objAsoc As Entidades.CbteAsociado In cbtes
                    .CommandText = "INSERT INTO Cpraasociado (Id,Cbteid,Numero,Ptovta,Tipo,Importe,Cbtereferencia) VALUES (null,@Cbteid,@Numero,@Ptovta,@Tipo,@Importe,@Cbtereferencia)"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@Cbteid", objAnticipo.Id)
                    .Parameters.AddWithValue("@Cbtereferencia", objAsoc.CbteReferencia)
                    .Parameters.AddWithValue("@Numero", objAsoc.Numero)
                    .Parameters.AddWithValue("@Ptovta", objAsoc.PtoVta)
                    .Parameters.AddWithValue("@Tipo", objAsoc.Tipo)
                    .Parameters.AddWithValue("@Importe", objAsoc.Importe)
                    .ExecuteNonQuery()
                Next

            End With

            transaccion.Commit()

            Return id

        Catch exError As MySqlException

            If transaccion IsNot Nothing Then
                transaccion.Rollback()
            End If

            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cpracabecera", _
            "AplicarAnticipo", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)

        Finally
            If cnn IsNot Nothing Then
                If cnn.State = ConnectionState.Open Then
                    cnn.Close()
                End If
            End If
        End Try
    End Function

    Public Function Anular(ByVal obj As CpraCabecera) As UInt32

        Dim id As Long
        Dim transaccion As MySqlTransaction = Nothing
        Dim cnn As MySqlConnection = Nothing
        Dim cmd As MySqlCommand

        Try

            cnn = CreateConnection()
            cnn.Open()
            transaccion = cnn.BeginTransaction
            cmd = New MySqlCommand

            With cmd
                .Connection = cnn
                .Transaction = transaccion
                .CommandType = CommandType.Text

                'elimino las alicuotas
                .CommandText = "DELETE FROM Cpraalicuota WHERE Cbteid=@id"
                .Parameters.Clear()
                .Parameters.AddWithValue("@id", obj.Id)
                .ExecuteNonQuery()

                'elimino los comprobantes asociados
                .CommandText = "DELETE FROM Cpraasociado WHERE Cbteid=@id"
                .Parameters.Clear()
                .Parameters.AddWithValue("@id", obj.Id)
                .ExecuteNonQuery()

                'elimino los tributos del combrobante
                .CommandText = "DELETE FROM Cpratributo WHERE Cbteid=@id"
                .Parameters.Clear()
                .Parameters.AddWithValue("@id", obj.Id)
                .ExecuteNonQuery()

                'elimino los articulos del combrobante
                .CommandText = "DELETE FROM Cpraarticulo WHERE Cbteid=@id"
                .Parameters.Clear()
                .Parameters.AddWithValue("@id", obj.Id)
                .ExecuteNonQuery()

                'elimino los articulos de la ficha de stock
                .CommandText = "DELETE FROM Fichastock WHERE CbteCpra=@id"
                .Parameters.Clear()
                .Parameters.AddWithValue("@id", obj.Id)
                .ExecuteNonQuery()
                
                'ojo! si proviene de un pago, los cheques solo deben cambiar su estado y no generar un nuevo registro
                For Each objFinanciero As Entidades.Financiero In obj.CbteDetalleFinanciero

                    .Parameters.Clear()
                    'CUENTA_CARTERA As String = "CARTERA"
                    'CONCEPTO_CHEQUE_RECIBIDO As String = "013"
                    'CONCEPTO_CHEQUE_PASADO As String = "014"
                    'CONCEPTO_CHEQUE_DEPOSITADO As String = "015"

                    'valido los comprobantes de financiero
                    If objFinanciero.Cuenta = CUENTA_CARTERA Then

                        Select Case objFinanciero.Concepto
                            Case CONCEPTO_CHEQUE_PASADO 'vuelvo el cheque pasado a su estado anterior
                                .CommandText = "UPDATE Financiero SET Concepto=@Concepto,Beneficiario=@Beneficiario,"
                                .CommandText &= "Cbtecpra=@Cbtecpra,Tipo=@Tipo,Egreso = @Egreso WHERE id=@id"
                                .Parameters.AddWithValue("@id", objFinanciero.Id)
                                .Parameters.AddWithValue("@Cbtecpra", Nothing)
                                .Parameters.AddWithValue("@Concepto", CONCEPTO_CHEQUE_RECIBIDO)
                                .Parameters.AddWithValue("@Beneficiario", "")
                                .Parameters.AddWithValue("@Tipo", CONCEPTO_DEUDOR)
                                .Parameters.AddWithValue("@Egreso", Nothing)
                            Case CONCEPTO_CHEQUE_DEPOSITADO
                                Throw New Exception("El comprobante posee cheques ya han sido depositados. Debe anular el deposito correspondiente")
                            Case Else
                                Throw New Exception("El comprobante posee cheques que han cambiado de estado")
                        End Select

                    Else 'para las otras cuentas, elimino los movimientos

                        .CommandText = "DELETE FROM Financiero WHERE id=@id"
                        .Parameters.AddWithValue("@id", objFinanciero.Id)

                    End If

                    .ExecuteNonQuery()

                Next

                'elimino la cabecera al final por la integridad referencia
                .CommandText = "DELETE FROM Cpracabecera WHERE id=@id"
                .Parameters.Clear()
                .Parameters.AddWithValue("@id", obj.Id)
                .ExecuteNonQuery()

            End With

            transaccion.Commit()

            Return id

        Catch exError As MySqlException

            If transaccion IsNot Nothing Then
                transaccion.Rollback()
            End If

            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cpracabecera", _
            "Anular", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)

        Finally
            If cnn IsNot Nothing Then
                If cnn.State = ConnectionState.Open Then
                    cnn.Close()
                End If
            End If
        End Try
    End Function


    Public Function GetCbteDetalleFinanciero(ByVal id As UInt32) As List(Of Financiero)
        Try
            Dim lista As New List(Of Financiero)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        '.CommandText = "SELECT Financiero.* FROM Financiero WHERE cuenta = @cuenta"
                        .CommandText = "SELECT Financiero.*,IFNULL(`cbtecabecera`.`CbteTipo`,0) CptoVta,IFNULL(`cpracabecera`.`CbteTipo`,0) CptoCpra FROM Financiero LEFT JOIN `cbtecabecera` ON financiero.`CbteVta` = `cbtecabecera`.id"
                        .CommandText &= " LEFT JOIN `cpracabecera` ON financiero.`CbteCpra` = `cpracabecera`.id  WHERE CbteCpra = @id"

                        .Parameters.AddWithValue("@id", id)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New Financiero
                                    obj = PopulateFinanciero(reader)
                                    lista.Add(obj)
                                    obj = Nothing
                                Loop
                                Return lista
                            End Using
                        Finally
                            lista = Nothing
                        End Try
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Financiero", _
            "GetCbteDetalleFinanciero", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Private Function PopulateFinanciero(ByVal reader As MySqlDataReader) As Financiero
        Dim obj As New Financiero
        Try
            With obj
                .Id = Convert.ToUInt32(reader("Id"))
                .Origen = Convert.ToString(reader("Origen"))
                .Cuenta = Convert.ToString(reader("Cuenta"))
                .Concepto = Convert.ToString(reader("Concepto"))
                .Beneficiario = Convert.ToString(reader("Beneficiario"))
                .Emision = Convert.ToDateTime(reader("Emision"))

                If Not IsDBNull(reader("Egreso")) Then
                    .Egreso = Convert.ToDateTime(reader("Egreso"))
                End If

                .Efectivizacion = Convert.ToDateTime(reader("Efectivizacion"))
                .Importe = Convert.ToDouble(reader("Importe"))
                .Referencia = Convert.ToString(reader("Referencia"))
                .Observacion = Convert.ToString(reader("Observacion"))
                .Usuario = Convert.ToUInt32(reader("Usuario"))
                .Fecharegistracion = Convert.ToDateTime(reader("Fecharegistracion"))
                .Banco = Convert.ToUInt32(reader("Banco"))

                If Not IsDBNull(reader("Cbtevta")) Then
                    .Cbtevta = Convert.ToUInt32(reader("Cbtevta"))
                End If

                If Not IsDBNull(reader("Cbtecpra")) Then
                    .Cbtecpra = Convert.ToUInt32(reader("Cbtecpra"))
                End If

                'If Not IsDBNull(reader("Cbterecibo")) Then
                '    .Cbterecibo = Convert.ToUInt32(reader("Cbterecibo"))
                'End If

                'If Not IsDBNull(reader("Cbtepago")) Then
                '    .Cbtepago = Convert.ToUInt32(reader("Cbtepago"))
                'End If

                If Not IsDBNull(reader("Localidad")) Then
                    .Localidad = Convert.ToUInt32(reader("Localidad"))
                End If

                .Tipo = Convert.ToString(reader("Tipo"))
                .Dador = Convert.ToString(reader("Dador"))
                .Sucursal = Convert.ToUInt32(reader("Sucursal"))

                If Not IsDBNull(reader("DocumentoNro")) Then
                    .DocumentoNro = Convert.ToString(reader("DocumentoNro"))
                End If

                .Deposito = Convert.ToUInt32(reader("Deposito"))

                If Not IsDBNull(reader("CptoVta")) Then
                    .CptoVta = Convert.ToUInt32(reader("CptoVta"))
                End If

                If Not IsDBNull(reader("CptoCpra")) Then
                    .CptoCpra = Convert.ToUInt32(reader("CptoCpra"))
                End If

            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function

    Public Function DesaplicarPago(ByVal obj As CpraCabecera) As UInt32

        Dim id As Long
        Dim transaccion As MySqlTransaction = Nothing
        Dim cnn As MySqlConnection = Nothing
        Dim cmd As MySqlCommand

        Try

            cnn = CreateConnection()
            cnn.Open()
            transaccion = cnn.BeginTransaction
            cmd = New MySqlCommand

            With cmd
                .Connection = cnn
                .Transaction = transaccion
                .CommandType = CommandType.Text

                'elimino los comprobantes asociados
                .CommandText = "DELETE FROM Cpraasociado WHERE Cbteid=@id"
                .Parameters.Clear()
                .Parameters.AddWithValue("@id", obj.Id)
                .ExecuteNonQuery()

            End With

            transaccion.Commit()

            Return id

        Catch exError As MySqlException

            If transaccion IsNot Nothing Then
                transaccion.Rollback()
            End If

            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cpracabecera", _
            "Desaplicar Pago", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)

        Finally
            If cnn IsNot Nothing Then
                If cnn.State = ConnectionState.Open Then
                    cnn.Close()
                End If
            End If
        End Try
    End Function

    'Public Function a_TotalPagoCtasP(ByVal pstrCuenta As String, ByVal pstrMes As String, ByVal pstrAño As String, ByVal pConcepto) As Double

    '    Dim mstrSql As String

    '    a_TotalPagoCtasP = 0

    '    Dim mobjCtasP As New GenericClass

    '    mstrSql = "SELECT SUM(total_ctap) as Total FROM CUENTASP WHERE Month(fecha_ctap)=" & Val(pstrMes) & _
    '            " AND year(fecha_ctap)=" & Val(pstrAño) & _
    '            " AND id_concepto_ctap = '" & pConcepto & "' " & _
    '            " AND id_proveedor_ctap='" & pstrCuenta & "' " & _
    '            " GROUP BY YEAR(fecha_ctap) and Month(fecha_ctap)"

    '    mobjCtasP.InicializarSQL(gSession.Connection, mstrSql)

    '    If Not (mobjCtasP.BOF And mobjCtasP.EOF) Then
    '        a_TotalPagoCtasP = mobjCtasP.GetProperty("Total")
    '        a_TotalPagoCtasP = a_TotalPagoCtasP / (1 + (getParam("Porcentaje_Iva_1", "dbl") / 100))
    '    End If

    '    mobjCtasP = Nothing

    'End Function

    'Public Function a_TotalPagos(ByVal pstrCuenta As String, ByVal pstrMes As String, ByVal pstrAño As String, ByVal pConcepto As String) As Double

    '    Dim mstrSql As String

    '    a_TotalPagos = 0

    '    Dim mobjPagos As New GenericClass

    '    mstrSql = "SELECT SUM(imp_Ret_Ganancias_pagos) as Total FROM PAGOS WHERE Month(fecha_pagos)=" & Val(pstrMes) & _
    '            " AND year(fecha_pagos)=" & Val(pstrAño) & _
    '            " AND concepto_pagos = '" & pConcepto & "' " & _
    '            " AND id_proveedor_pagos='" & pstrCuenta & "' " & _
    '            " GROUP BY YEAR(fecha_pagos) and Month(fecha_pagos)"

    '    mobjPagos.InicializarSQL(gSession.Connection, mstrSql)

    '    If Not (mobjPagos.BOF And mobjPagos.EOF) Then
    '        a_TotalPagos = mobjPagos.GetProperty("Total")
    '    End If

    '    mobjPagos = Nothing

    'End Function

    Public Function GetTotalIvaCbteRef(ByVal proveedor As UInt32, ByVal pIdCbteRef As UInt64) As Double
        Try
            Dim ret As Double
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT EdoCta.* FROM ( "
                        .CommandText &= " SELECT IF(r.`Tipo`='C',r.ImporteIVA*-1,r.ImporteIVA) Iva,r.id CbteId,r.`Id` CbteReferencia "
                        .CommandText &= " FROM `cpracabecera` r,`tipocomprobante` t, Proveedor "
                        .CommandText &= " WHERE r.`CbteTipo` = t.`Codigo` "
                        .CommandText &= " AND r.`CbteTipo` IN (1,6,81,82,11,51,83,111) "
                        .CommandText &= " AND r.`ProveedorId`=@proveedor "
                        .CommandText &= " UNION ALL "
                        .CommandText &= " SELECT IF(r.`Tipo`='C',r.ImporteIVA*-1,r.ImporteIVA) Iva,r.id CbteId,c.`CbteReferencia` "
                        .CommandText &= " FROM `cpracabecera` r,`cpraasociado` c,`tipocomprobante` t, Proveedor "
                        .CommandText &= " WHERE r.id = c.`CbteId` "
                        .CommandText &= " AND r.`CbteTipo` = t.`Codigo` "
                        .CommandText &= " AND r.`CbteTipo` NOT IN (1,6,81,82,11,51,83,111) "
                        .CommandText &= " AND r.`ProveedorId`=@proveedor "
                        .CommandText &= " ) as EdoCta "
                        .CommandText &= " WHERE EdoCta.`CbteReferencia`=@pIdCbteRef "
                        .CommandText &= " GROUP BY EdoCta.`CbteReferencia`"
                        .Parameters.Clear()
                        .Parameters.AddWithValue("@proveedor", proveedor)
                        .Parameters.AddWithValue("@pIdCbteRef", pIdCbteRef)

                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    ret = Convert.ToDouble(reader("Iva"))
                                Loop

                                Return ret

                            End Using
                        Finally
                            '
                        End Try
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cpracabecera", _
            "GetTotalIvaCbteRef", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetTotalPagosPeriodo(ByVal proveedor As UInt32, ByVal periodo As Date) As Double
        Try
            Dim ret As Double
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT IFNULL(SUM(ImporteTotal),0) total FROM Cpracabecera WHERE ProveedorId= @proveedor"
                        .CommandText &= " AND CbteTipo IN (@cbtetipo) "
                        .CommandText &= " AND DATE_FORMAT(CAST(`cpracabecera`.`CbteFecha` AS DATE),'%Y%m')=@periodo "
                        .Parameters.AddWithValue("@proveedor", proveedor)
                        .Parameters.AddWithValue("@cbtetipo", ORDEN_PAGO)
                        .Parameters.AddWithValue("@periodo", periodo.ToString("yyyyMM"))

                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    ret = Math.Round(Convert.ToDouble(reader("total")) / 1.21, 2)
                                Loop

                                Return ret

                            End Using
                        Finally
                            '
                        End Try
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cpracabecera", _
            "GetPagosPeriodo", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetTotalRetGciasPeriodo(ByVal proveedor As UInt32, ByVal periodo As Date) As Double
        Try
            Dim ret As Double
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT IFNULL(SUM(Cpratributo.Importe),0) total FROM Cpracabecera,Cpratributo "
                        .CommandText &= " WHERE Cpracabecera.Id=Cpratributo.Cbteid "
                        .CommandText &= " AND Cpracabecera.ProveedorId= @proveedor"
                        .CommandText &= " AND Cpracabecera.CbteTipo IN (@cbtetipo) "
                        .CommandText &= " AND DATE_FORMAT(CAST(`cpracabecera`.`CbteFecha` AS DATE),'%Y%m')=@periodo "
                        .CommandText &= " AND Cpratributo.Codigo=1 "
                        .CommandText &= " AND Cpratributo.descripcion LIKE 'Per./Ret. de Impuesto a las Ganancias'"
                        .Parameters.AddWithValue("@proveedor", proveedor)
                        .Parameters.AddWithValue("@cbtetipo", ORDEN_PAGO)
                        .Parameters.AddWithValue("@periodo", periodo.ToString("yyyyMM"))

                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    ret = Convert.ToDouble(reader("total"))
                                Loop

                                Return ret

                            End Using
                        Finally
                            '
                        End Try
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cpracabecera", _
            "GetTotalRetGciasPeriodo", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

End Class

