Imports Entidades
Imports MySql.Data.MySqlClient
Public Class CbteCabecera2CDat

    Private ExceptionClassObject As New ManejoDeErrores.ExceptionClass
    Private ExceptionErrorFileString As String = My.Application.Info.DirectoryPath & "\ErrorFile.log"
    Private WriteErrorMessageString As String
    Private ErrorMessageString As String
    
    Private Const CBTE_ABIERTO As String = "ABIERTO"
    Private Const CBTE_FINALIZADO As String = "FINALIZADO"
    Private Const CBTE_CANCELADO As String = "CANCELADO"

    Private Const FP_CONTADO As Integer = 1
    Private Const FP_CTACTE As Integer = 2
    Private Const PTO_VTA_ELECTRONICO As String = "E"
    Private Const PTO_VTA_FISCAL As String = "F"
    Private Const PTO_VTA_MANUAL As String = "M"
    Private Const PTO_VTA_X As String = "X"

    Public Const CONCEPTO_DEUDOR As String = "D"
    Public Const CONCEPTO_ACREEDOR As String = "C"
    Public Const CUENTA_CARTERA As String = "CARTERA"
    Public Const CONCEPTO_CHEQUE_RECIBIDO As String = "013"
    Public Const CONCEPTO_CHEQUE_PASADO As String = "014"
    Public Const CONCEPTO_CHEQUE_DEPOSITADO As String = "015"

    Private Const FACTURA_A As UInt32 = 1
    Private Const FACTURA_B As UInt32 = 6
    Private Const REMITO As UInt32 = 91
    Private Const NOTA_DEBITO_A As UInt32 = 2
    Private Const NOTA_DEBITO_B As UInt32 = 7
    Private Const TIQUE_FACTURA_A As UInt32 = 81
    Private Const TIQUE_FACTURA_B As UInt32 = 82
    Private Const NOTA_CREDITO_A As UInt32 = 3
    Private Const NOTA_CREDITO_B As UInt32 = 8
    Private Const PRESUPUESTO As UInt32 = 991
    Private Const NOTA_PEDIDO As UInt32 = 992
    Private Const NOTA_VENTA As UInt32 = 993
    Private Const DEVOLUCION_PRESUPUESTO As UInt32 = 992
    Private Const RECIBO As UInt32 = 993
    Private Const ORDEN_PAGO As UInt32 = 994
    Private Const RECIBO_NP As UInt32 = 995
    Private Const ORDEN_PAGO_NP As UInt32 = 996

    Public Function Insert(ByVal obj As CbteCabecera2) As UInt32

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

                'actualizo la numeracion interna de comprobantes
                .CommandText = "SELECT * FROM parametro WHERE nombre = @campo_param FOR UPDATE"
                .Parameters.Clear()
                Select Case obj.Cbtetipo
                    Case PRESUPUESTO : .Parameters.AddWithValue("@campo_param", "Ult_Nro_Presupuesto")
                        'Case NOTA_PEDIDO : .Parameters.AddWithValue("@campo_param", "Ult_Nro_Nota_Pedido")
                        'Case NOTA_VENTA : .Parameters.AddWithValue("@campo_param", "Ult_Nro_Nota_venta")
                End Select
                .ExecuteNonQuery()

                .CommandText = "UPDATE parametro SET valorpredeterminado = @cbtenumero WHERE nombre = @campo_param"
                .Parameters.Clear()
                Select Case obj.Cbtetipo
                    Case PRESUPUESTO : .Parameters.AddWithValue("@campo_param", "Ult_Nro_Presupuesto")
                    Case NOTA_PEDIDO : .Parameters.AddWithValue("@campo_param", "Ult_Nro_Nota_Pedido")
                    Case NOTA_VENTA : .Parameters.AddWithValue("@campo_param", "Ult_Nro_Nota_venta")
                End Select
                .Parameters.AddWithValue("@cbtenumero", obj.Cbtenumero)
                .ExecuteNonQuery()

                .CommandText = "INSERT INTO CbteCabecera2 (Id,Concepto,Clienteid,Razonsocial,Domicilio,Contacto,Telefono,Email,Nroremito,Documentotipo,Documentonro,"
                .CommandText &= "Cbtetipo,Cbteptovta,Cbtenumero,Cbtefecha,Formadepago,Importetotal,Importetotalconceptos,Importeneto,Importeopexentas,"
                .CommandText &= "Importeiva,Importetributos,Fechaserviciodesde,Fechaserviciohasta,Fechavtopago,Monedaid,Monedactz,Cae,Fechavtocae,"
                .CommandText &= "Observaciones,Tiporesponsable,Cuitemisor,Usuario,Vendedor,Sucursal,Descuento,Letra,Denominacion,Tipo,Importectaspropias,Importecartera,ObservacionesExtra,Estado,FechaVigencia,"
                .CommandText &= "CondicionesPago,PlazosEntrega,LugarEntrega,MantenimientoOferta"
                .CommandText &= ") VALUES ("
                .CommandText &= " null,@Concepto,@Clienteid,@Razonsocial,@Domicilio,@Contacto,@Telefono,@Email,@Nroremito,@Documentotipo,@Documentonro,"
                .CommandText &= "@Cbtetipo,@Cbteptovta,@Cbtenumero,@Cbtefecha,@Formadepago,@Importetotal,@Importetotalconceptos,@Importeneto,@Importeopexentas,"
                .CommandText &= "@Importeiva,@Importetributos,@Fechaserviciodesde,@Fechaserviciohasta,@Fechavtopago,@Monedaid,@Monedactz,@Cae,@Fechavtocae,"
                .CommandText &= "@Observaciones,@Tiporesponsable,@Cuitemisor,@Usuario,@Vendedor,@Sucursal,@Descuento,@Letra,@Denominacion,@Tipo,@Importectaspropias,@Importecartera,@ObservacionesExtra,@Estado,@FechaVigencia,"
                .CommandText &= "@CondicionesPago,@PlazosEntrega,@LugarEntrega,@MantenimientoOferta)"

                .Parameters.Clear()
                '.Parameters.AddWithValue("@Id", obj.Id)
                .Parameters.AddWithValue("@Concepto", obj.Concepto)
                .Parameters.AddWithValue("@Clienteid", obj.ClienteId)
                .Parameters.AddWithValue("@Razonsocial", obj.RazonSocial)
                .Parameters.AddWithValue("@Domicilio", obj.Domicilio)
                .Parameters.AddWithValue("@Contacto", obj.Contacto)
                .Parameters.AddWithValue("@Telefono", obj.Telefono)
                .Parameters.AddWithValue("@Email", obj.Email)
                .Parameters.AddWithValue("@Nroremito", obj.NroRemito)
                .Parameters.AddWithValue("@Documentotipo", obj.DocumentoTipo)
                .Parameters.AddWithValue("@Documentonro", obj.DocumentoNro)
                .Parameters.AddWithValue("@Cbtetipo", obj.CbteTipo)
                .Parameters.AddWithValue("@Cbteptovta", obj.CbtePtoVta)
                .Parameters.AddWithValue("@Cbtenumero", obj.CbteNumero)
                .Parameters.AddWithValue("@Cbtefecha", obj.CbteFecha)
                .Parameters.AddWithValue("@Formadepago", obj.FormaDePago)
                .Parameters.AddWithValue("@Importetotal", obj.ImporteTotal)
                .Parameters.AddWithValue("@Importetotalconceptos", obj.ImporteTotalConceptos)
                .Parameters.AddWithValue("@Importeneto", obj.ImporteNeto)
                .Parameters.AddWithValue("@Importeopexentas", obj.ImporteOpExentas)
                .Parameters.AddWithValue("@Importeiva", obj.ImporteIVA)
                .Parameters.AddWithValue("@Importetributos", obj.ImporteTributos)
                .Parameters.AddWithValue("@Fechaserviciodesde", obj.FechaServicioDesde)
                .Parameters.AddWithValue("@Fechaserviciohasta", obj.FechaServicioHasta)
                .Parameters.AddWithValue("@Fechavtopago", obj.FechaVtoPago)
                .Parameters.AddWithValue("@Monedaid", obj.MonedaId)
                .Parameters.AddWithValue("@Monedactz", obj.MonedaCtz)
                .Parameters.AddWithValue("@Cae", obj.CAE)
                .Parameters.AddWithValue("@Fechavtocae", obj.FechaVtoCAE)
                .Parameters.AddWithValue("@Observaciones", obj.Observaciones)
                .Parameters.AddWithValue("@Tiporesponsable", obj.Tiporesponsable)
                .Parameters.AddWithValue("@Cuitemisor", obj.CuitEmisor)
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
                .Parameters.AddWithValue("@Estado", obj.Estado)
                .Parameters.AddWithValue("@FechaVigencia", obj.FechaVigencia)
                .Parameters.AddWithValue("@CondicionesPago", obj.CondicionesPago)
                .Parameters.AddWithValue("@PlazosEntrega", obj.PlazosEntrega)
                .Parameters.AddWithValue("@LugarEntrega", obj.LugarEntrega)
                .Parameters.AddWithValue("@MantenimientoOferta", obj.MantenimientoOferta)
                .ExecuteNonQuery()

                'recupero el id de la factura creada
                id = .LastInsertedId

                'registro las alicuotas del combrobante
                For Each objAlic As Entidades.CbteAlicuota2 In obj.CbteAlicuotas2
                    .CommandText = "INSERT INTO Cbtealicuota2 (Id,Cbteid,Codigo,Descripcion,Importe,Alicuota,Baseimponible) VALUES (null,@Cbteid,@Codigo,@Descripcion,@Importe,@Alicuota,@Baseimponible)"
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
                For Each objAsoc As Entidades.CbteAsociado2 In obj.CbteAsociados2
                    .CommandText = "INSERT INTO Cbteasociado2 (Id,Cbteid,Numero,Ptovta,Tipo,Importe,Cbtereferencia) VALUES (null,@Cbteid,@Numero,@Ptovta,@Tipo,@Importe,@Cbtereferencia)"
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
                For Each objTrib As Entidades.CbteTributo2 In obj.CbteTributos2
                    .CommandText = "INSERT INTO Cbtetributo2 (Id,Cbteid,Codigo,Descripcion,Importe,Alicuota,Baseimponible,Referencia) VALUES (null,@Cbteid,@Codigo,@Descripcion,@Importe,@Alicuota,@Baseimponible,@Referencia)"
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

                'registro los articulos del comprobante y la ficha de stock
                For Each objArt As Entidades.CbteArticulo2 In obj.CbteArticulos2
                    .CommandText = "INSERT INTO Cbtearticulo2 (Id,Cbteid,Codigo,Descripcion,Cantidad,Importe,ImpIntTasaNominal,Alicuotacodigo,"
                    .CommandText &= "Alicuota,Unidad,MonedaId,Descuento,Listadeprecio,Comision,ImpInterno,Estado) VALUES (null,@Cbteid,@Codigo,@Descripcion,@Cantidad,@Importe,@ImpIntTasaNominal,"
                    .CommandText &= "@Alicuotacodigo,@Alicuota,@Unidad,@Moneda,@Descuento,@Listadeprecio,@Comision,@ImpInterno,@Estado)"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@Cbteid", id)
                    .Parameters.AddWithValue("@Codigo", objArt.Codigo)
                    .Parameters.AddWithValue("@Descripcion", objArt.Descripcion)
                    '.Parameters.AddWithValue("@Material", objArt.Material)
                    .Parameters.AddWithValue("@Cantidad", objArt.Cantidad)
                    .Parameters.AddWithValue("@Importe", objArt.Importe)
                    .Parameters.AddWithValue("@ImpIntTasaNominal", objArt.ImpIntTasaNominal)
                    .Parameters.AddWithValue("@Alicuotacodigo", objArt.AlicuotaCodigo)
                    .Parameters.AddWithValue("@Alicuota", objArt.Alicuota)
                    .Parameters.AddWithValue("@Unidad", objArt.Unidad)
                    .Parameters.AddWithValue("@Moneda", objArt.Moneda)
                    .Parameters.AddWithValue("@Descuento", objArt.Descuento)
                    .Parameters.AddWithValue("@Listadeprecio", objArt.Listadeprecio)
                    .Parameters.AddWithValue("@Comision", objArt.Comision)
                    .Parameters.AddWithValue("@ImpInterno", objArt.ImpInterno)
                    .Parameters.AddWithValue("@Estado", objArt.Estado)
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
            "Datos:CbteCabecera2", _
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

    Public Function AplicarAnticipo(ByVal objAnticipo As CbteCabecera2, ByVal cbtes As List(Of Entidades.CbteAsociado2)) As UInt32

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
                For Each objAsoc As Entidades.CbteAsociado2 In cbtes
                    .CommandText = "INSERT INTO Cbteasociado2 (Id,Cbteid,Numero,Ptovta,Tipo,Importe,Cbtereferencia) VALUES (null,@Cbteid,@Numero,@Ptovta,@Tipo,@Importe,@Cbtereferencia)"
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
            "Datos:CbteCabecera2", _
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

    Public Function Update(ByVal obj As CbteCabecera2) As UInt32
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
                .CommandText = "UPDATE CbteCabecera2 SET Concepto = @Concepto,Clienteid = @Clienteid,Razonsocial = @Razonsocial,"
                .CommandText &= "Domicilio = @Domicilio,Contacto = @Contacto,Telefono = @Telefono,Email = @Email,Nroremito = @Nroremito,Documentotipo = @Documentotipo,Documentonro = @Documentonro,"
                .CommandText &= "Cbtetipo = @Cbtetipo,Cbteptovta = @Cbteptovta,Cbtenumero = @Cbtenumero,Cbtefecha = @Cbtefecha,Formadepago = @Formadepago,"
                .CommandText &= "Importetotal = @Importetotal,Importetotalconceptos = @Importetotalconceptos,Importeneto = @Importeneto,"
                .CommandText &= "Importeopexentas = @Importeopexentas,Importeiva = @Importeiva,Importetributos = @Importetributos,"
                .CommandText &= "Fechaserviciodesde = @Fechaserviciodesde,Fechaserviciohasta = @Fechaserviciohasta,Fechavtopago = @Fechavtopago,"
                .CommandText &= "Monedaid = @Monedaid,Monedactz = @Monedactz,Cae = @Cae,Fechavtocae = @Fechavtocae,"
                .CommandText &= "Observaciones = @Observaciones,Tiporesponsable = @Tiporesponsable,Cuitemisor = @Cuitemisor,"
                .CommandText &= "Usuario=@Usuario,Vendedor=@Vendedor,Sucursal=@Sucursal,Descuento=@Descuento,Letra=@Letra,"
                .CommandText &= "Denominacion=@Denominacion,Tipo=@Tipo,Importectaspropias=@Importectaspropias,"
                .CommandText &= "Importecartera=@Importecartera,ObservacionesExtra=@ObservacionesExtra,"
                .CommandText &= "Estado=@Estado,FechaVigencia=@FechaVigencia,CondicionesPago=@CondicionesPago,"
                .CommandText &= "PlazosEntrega=@PlazosEntrega,LugarEntrega=@LugarEntrega,MantenimientoOferta=@MantenimientoOferta "
                .CommandText &= "WHERE Id = @Id"

                .Parameters.Clear()
                .Parameters.AddWithValue("@Id", obj.Id)
                .Parameters.AddWithValue("@Concepto", obj.Concepto)
                .Parameters.AddWithValue("@Clienteid", obj.Clienteid)
                .Parameters.AddWithValue("@Razonsocial", obj.Razonsocial)
                .Parameters.AddWithValue("@Domicilio", obj.Domicilio)
                .Parameters.AddWithValue("@Contacto", obj.Contacto)
                .Parameters.AddWithValue("@Telefono", obj.Telefono)
                .Parameters.AddWithValue("@Email", obj.Email)
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
                .Parameters.AddWithValue("@Estado", obj.Estado)
                .Parameters.AddWithValue("@FechaVigencia", obj.FechaVigencia)
                .Parameters.AddWithValue("@CondicionesPago", obj.CondicionesPago)
                .Parameters.AddWithValue("@PlazosEntrega", obj.PlazosEntrega)
                .Parameters.AddWithValue("@LugarEntrega", obj.LugarEntrega)
                .Parameters.AddWithValue("@MantenimientoOferta", obj.MantenimientoOferta)
                .ExecuteNonQuery()

                'recupero el id de la factura creada
                id = obj.Id


                'registro las alicuotas del combrobante
                '**************************************************************
                .CommandText = "DELETE FROM Cbtealicuota2 WHERE Cbteid=@Cbteid"
                .Parameters.Clear()
                .Parameters.AddWithValue("@Cbteid", id)
                .ExecuteNonQuery()
                '**************************************************************
                For Each objAlic As Entidades.CbteAlicuota2 In obj.CbteAlicuotas2
                    .CommandText = "INSERT INTO Cbtealicuota2 (Id,Cbteid,Codigo,Descripcion,Importe,Alicuota,Baseimponible) VALUES (null,@Cbteid,@Codigo,@Descripcion,@Importe,@Alicuota,@Baseimponible)"
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
                '**************************************************************
                .CommandText = "DELETE FROM Cbteasociado2 WHERE Cbteid=@Cbteid"
                .Parameters.Clear()
                .Parameters.AddWithValue("@Cbteid", id)
                .ExecuteNonQuery()
                '**************************************************************
                For Each objAsoc As Entidades.CbteAsociado2 In obj.CbteAsociados2
                    .CommandText = "INSERT INTO Cbteasociado2 (Id,Cbteid,Numero,Ptovta,Tipo,Importe,Cbtereferencia) VALUES (null,@Cbteid,@Numero,@Ptovta,@Tipo,@Importe,@Cbtereferencia)"
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
                '**************************************************************
                .CommandText = "DELETE FROM Cbtetributo2 WHERE Cbteid=@Cbteid"
                .Parameters.Clear()
                .Parameters.AddWithValue("@Cbteid", id)
                .ExecuteNonQuery()
                '**************************************************************
                For Each objTrib As Entidades.CbteTributo2 In obj.CbteTributos2
                    .CommandText = "INSERT INTO Cbtetributo2 (Id,Cbteid,Codigo,Descripcion,Importe,Alicuota,Baseimponible,Referencia) VALUES (null,@Cbteid,@Codigo,@Descripcion,@Importe,@Alicuota,@Baseimponible,@Referencia)"
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

                'registro los articulos del combrobante y la ficha de stock
                '**************************************************************
                .CommandText = "DELETE FROM Cbtearticulo2 WHERE Cbteid=@Cbteid"
                .Parameters.Clear()
                .Parameters.AddWithValue("@Cbteid", id)
                .ExecuteNonQuery()
                '**************************************************************
                'registro los articulos del comprobante y la ficha de stock
                For Each objArt As Entidades.CbteArticulo2 In obj.CbteArticulos2
                    .CommandText = "INSERT INTO Cbtearticulo2 (Id,Cbteid,Codigo,Descripcion,Cantidad,Importe,ImpIntTasaNominal,Alicuotacodigo,"
                    .CommandText &= "Alicuota,Unidad,MonedaId,Descuento,Listadeprecio,Comision,ImpInterno,Estado) VALUES (null,@Cbteid,@Codigo,@Descripcion,@Cantidad,@Importe,@ImpIntTasaNominal,"
                    .CommandText &= "@Alicuotacodigo,@Alicuota,@Unidad,@Moneda,@Descuento,@Listadeprecio,@Comision,@ImpInterno,@Estado)"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@Cbteid", id)
                    .Parameters.AddWithValue("@Codigo", objArt.Codigo)
                    .Parameters.AddWithValue("@Descripcion", objArt.Descripcion)
                    '.Parameters.AddWithValue("@Material", objArt.Material)
                    .Parameters.AddWithValue("@Cantidad", objArt.Cantidad)
                    .Parameters.AddWithValue("@Importe", objArt.Importe)
                    .Parameters.AddWithValue("@ImpIntTasaNominal", objArt.ImpIntTasaNominal)
                    .Parameters.AddWithValue("@Alicuotacodigo", objArt.AlicuotaCodigo)
                    .Parameters.AddWithValue("@Alicuota", objArt.Alicuota)
                    .Parameters.AddWithValue("@Unidad", objArt.Unidad)
                    .Parameters.AddWithValue("@Moneda", objArt.Moneda)
                    .Parameters.AddWithValue("@Descuento", objArt.Descuento)
                    .Parameters.AddWithValue("@Listadeprecio", objArt.Listadeprecio)
                    .Parameters.AddWithValue("@Comision", objArt.Comision)
                    .Parameters.AddWithValue("@ImpInterno", objArt.ImpInterno)
                    .Parameters.AddWithValue("@Estado", objArt.Estado)
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
            "Datos:CbteCabecera2", _
            "Update", _
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

    Public Sub Delete(ByVal id As UInt32)
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
                'elimino las alicuotas del combrobante
                '**************************************************************
                .CommandText = "DELETE FROM Cbtealicuota2 WHERE Cbteid=@Cbteid"
                .Parameters.Clear()
                .Parameters.AddWithValue("@Cbteid", id)
                .ExecuteNonQuery()
                '**************************************************************

                'elimino los comprobantes asociados
                '**************************************************************
                .CommandText = "DELETE FROM Cbteasociado2 WHERE Cbteid=@Cbteid"
                .Parameters.Clear()
                .Parameters.AddWithValue("@Cbteid", id)
                .ExecuteNonQuery()
                '**************************************************************

                'elimino los tributos del combrobante
                '**************************************************************
                .CommandText = "DELETE FROM Cbtetributo2 WHERE Cbteid=@Cbteid"
                .Parameters.Clear()
                .Parameters.AddWithValue("@Cbteid", id)
                .ExecuteNonQuery()
                '**************************************************************

                'elimino los articulos del combrobante y la ficha de stock
                '**************************************************************
                .CommandText = "DELETE FROM Cbtearticulo2 WHERE Cbteid=@Cbteid"
                .Parameters.Clear()
                .Parameters.AddWithValue("@Cbteid", id)
                .ExecuteNonQuery()
                '**************************************************************

                'elimino la cabecera
                '**************************************************************
                .CommandText = "DELETE FROM CbteCabecera2 WHERE Id = @Id"
                .Parameters.Clear()
                .Parameters.AddWithValue("@Id", id)
                .ExecuteNonQuery()
                '**************************************************************
            End With

            transaccion.Commit()

        Catch exError As MySqlException

            If transaccion IsNot Nothing Then
                transaccion.Rollback()
            End If

            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:CbteCabecera2", _
            "Delete", _
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
    End Sub

    Public Function GetById(ByVal id As UInt32, Optional ByVal cargaCtaCte As Boolean = True, _
                              Optional ByVal cargaAlicuotas As Boolean = True, _
                              Optional ByVal cargaArticulos As Boolean = True, _
                              Optional ByVal cargaFinanciero As Boolean = True, _
                              Optional ByVal cargaTributos As Boolean = True, _
                              Optional ByVal cargaAsociados As Boolean = True) As CbteCabecera2
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM CbteCabecera2 WHERE Id= @Id"
                        .Parameters.AddWithValue("@Id", id)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Dim obj As New CbteCabecera2
                                'obj = Populate(reader)
                                obj = Populate(reader, cargaCtaCte, cargaAlicuotas, cargaArticulos, cargaFinanciero, cargaTributos, cargaAsociados)
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
            "Datos:CbteCabecera2", _
            "GetById", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetByNumero(ByVal cbtetipo As UInt32, ByVal cbteptovta As UInt32, ByVal cbtenumero As UInt32, _
                              Optional ByVal cargaCtaCte As Boolean = True, _
                              Optional ByVal cargaAlicuotas As Boolean = True, _
                              Optional ByVal cargaArticulos As Boolean = True, _
                              Optional ByVal cargaFinanciero As Boolean = True, _
                              Optional ByVal cargaTributos As Boolean = True, _
                              Optional ByVal cargaAsociados As Boolean = True) As CbteCabecera2
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM CbteCabecera2 WHERE cbtetipo= @cbtetipo AND cbteptovta = @cbteptovta AND cbtenumero = @cbtenumero"
                        .Parameters.AddWithValue("@cbtetipo", cbtetipo)
                        .Parameters.AddWithValue("@cbteptovta", cbteptovta)
                        .Parameters.AddWithValue("@cbtenumero", cbtenumero)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Dim obj As New CbteCabecera2
                                'obj = Populate(reader)
                                obj = Populate(reader, cargaCtaCte, cargaAlicuotas, cargaArticulos, cargaFinanciero, cargaTributos, cargaAsociados)
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
            "Datos:CbteCabecera2", _
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
                              Optional ByVal cargaAsociados As Boolean = True) As List(Of CbteCabecera2)
        Try
            Dim lista As New List(Of CbteCabecera2)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM CbteCabecera2"
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New CbteCabecera2
                                    'obj = Populate(reader)
                                    obj = Populate(reader, cargaCtaCte, cargaAlicuotas, cargaArticulos, cargaFinanciero, cargaTributos, cargaAsociados)
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
            "Datos:CbteCabecera2", _
            "GetAll", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetAllByCliente(ByVal cliente As UInt32, _
                                    Optional ByVal ordenDescendete As Boolean = False, _
                                    Optional ByVal cargaCtaCte As Boolean = True, _
                                    Optional ByVal cargaAlicuotas As Boolean = True, _
                                    Optional ByVal cargaArticulos As Boolean = True, _
                                    Optional ByVal cargaFinanciero As Boolean = True, _
                                    Optional ByVal cargaTributos As Boolean = True, _
                                    Optional ByVal cargaAsociados As Boolean = True) As List(Of CbteCabecera2)
        Try
            Dim lista As New List(Of CbteCabecera2)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM CbteCabecera2 WHERE ClienteId = @cliente"

                        'If Not vertodos Then
                        '    .CommandText &= " AND cbtetipo NOT IN (991,992,995,996)"
                        'End If

                        If ordenDescendete Then
                            .CommandText &= " ORDER BY id DESC"
                        End If

                        .Parameters.AddWithValue("@cliente", cliente)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New CbteCabecera2
                                    obj = Populate(reader, cargaCtaCte, cargaAlicuotas, cargaArticulos, cargaFinanciero, cargaTributos, cargaAsociados)
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
            "Datos:CbteCabecera2", _
            "GetAllByCliente", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetAllByTipo(ByVal tipo As UInt32, _
                                    Optional ByVal ordenDescendete As Boolean = False, _
                                    Optional ByVal cargaCtaCte As Boolean = True, _
                                    Optional ByVal cargaAlicuotas As Boolean = True, _
                                    Optional ByVal cargaArticulos As Boolean = True, _
                                    Optional ByVal cargaFinanciero As Boolean = True, _
                                    Optional ByVal cargaTributos As Boolean = True, _
                                    Optional ByVal cargaAsociados As Boolean = True) As List(Of CbteCabecera2)
        Try
            Dim lista As New List(Of CbteCabecera2)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM CbteCabecera2 WHERE CbteTipo = @tipo"

                        If ordenDescendete Then
                            .CommandText &= " ORDER BY id DESC"
                        End If

                        .Parameters.AddWithValue("@tipo", tipo)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New CbteCabecera2
                                    obj = Populate(reader, cargaCtaCte, cargaAlicuotas, cargaArticulos, cargaFinanciero, cargaTributos, cargaAsociados)
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
            "Datos:CbteCabecera2", _
            "GetAllByCliente", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetAnticiposCliente(ByVal cliente As UInt32, Optional ByVal vertodos As Boolean = False, Optional ByVal ordenDescendete As Boolean = False, _
                                    Optional ByVal cargaCtaCte As Boolean = True, _
                                    Optional ByVal cargaAlicuotas As Boolean = True, _
                                    Optional ByVal cargaArticulos As Boolean = True, _
                                    Optional ByVal cargaFinanciero As Boolean = True, _
                                    Optional ByVal cargaTributos As Boolean = True, _
                                    Optional ByVal cargaAsociados As Boolean = True) As List(Of CbteCabecera2)
        Try
            Dim lista As New List(Of CbteCabecera2)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM CbteCabecera2 WHERE ClienteId = @cliente"

                        If Not vertodos Then
                            .CommandText &= " AND cbtetipo IN (993,994)"
                        Else
                            .CommandText &= " AND cbtetipo IN (993,994,995,996)"
                        End If

                        If ordenDescendete Then
                            .CommandText &= " ORDER BY id DESC"
                        End If

                        .Parameters.AddWithValue("@cliente", cliente)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New CbteCabecera2
                                    'obj = Populate(reader)
                                    obj = Populate(reader, cargaCtaCte, cargaAlicuotas, cargaArticulos, cargaFinanciero, cargaTributos, cargaAsociados)
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
            "Datos:CbteCabecera2", _
            "GetAnticiposCliente", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetCbtesCtaCteByCliente(ByVal cliente As UInt32, Optional ByVal cargaCtaCte As Boolean = True, _
                              Optional ByVal cargaAlicuotas As Boolean = True, _
                              Optional ByVal cargaArticulos As Boolean = True, _
                              Optional ByVal cargaFinanciero As Boolean = True, _
                              Optional ByVal cargaTributos As Boolean = True, _
                              Optional ByVal cargaAsociados As Boolean = True) As List(Of CbteCabecera2)
        Try
            Dim lista As New List(Of CbteCabecera2)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM CbteCabecera2 WHERE ClienteId = @cliente AND FormaDePago=@formapago"
                        .Parameters.AddWithValue("@cliente", cliente)
                        .Parameters.AddWithValue("@formapago", FP_CTACTE)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New CbteCabecera2
                                    'obj = Populate(reader)
                                    obj = Populate(reader, cargaCtaCte, cargaAlicuotas, cargaArticulos, cargaFinanciero, cargaTributos, cargaAsociados)
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
            "Datos:CbteCabecera2", _
            "GetCbtesCtaCteByCliente", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetAlicuotas(ByVal Id As UInt32) As List(Of CbteAlicuota2)
        Try
            Dim lista As New List(Of CbteAlicuota2)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM CbteAlicuota2 WHERE CbteId = @Id"
                        .Parameters.AddWithValue("@Id", Id)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New CbteAlicuota2
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
            "Datos:CbteCabecera2", _
            "GetAlicuotas", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetTributos(ByVal Id As UInt32) As List(Of CbteTributo2)
        Try
            Dim lista As New List(Of CbteTributo2)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM CbteTributo2 WHERE CbteId = @Id"
                        .Parameters.AddWithValue("@Id", Id)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New CbteTributo2
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
            "Datos:CbteCabecera2", _
            "GetTributos", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetArticulos(ByVal Id As UInt32) As List(Of CbteArticulo2)
        Try
            Dim lista As New List(Of CbteArticulo2)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM CbteArticulo2 WHERE CbteId = @Id ORDER BY id"
                        .Parameters.AddWithValue("@Id", Id)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New CbteArticulo2
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
            "Datos:CbteCabecera2", _
            "GetArticulos", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetCbtesAsociados(ByVal Id As UInt32) As List(Of CbteAsociado2)
        Try
            Dim lista As New List(Of CbteAsociado2)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM CbteAsociado2 WHERE CbteId = @Id"
                        .Parameters.AddWithValue("@Id", Id)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New CbteAsociado2
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
            "Datos:CbteCabecera2", _
            "GetCbtesAsociados", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetEstadoCuenta(ByVal Id As UInt32) As List(Of CbteAsociado2)
        Try
            Dim lista As New List(Of CbteAsociado2)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT cbteasociado2.cbteid, cbteasociado2.CbteReferencia,CbteCabecera2.CbteNumero Numero,CbteCabecera2.CbtePtoVta PtoVta,CbteCabecera2.CbteTipo Tipo, "
                        .CommandText &= "IF(CbteCabecera2.tipo='C',cbteasociado2.importe*-1,cbteasociado2.importe) Importe, "
                        .CommandText &= "CbteCabecera2.Denominacion,CbteCabecera2.Letra,CAST(CbteCabecera2.CbteFecha AS DATE) Fecha "
                        .CommandText &= "FROM(CbteAsociado2, CbteCabecera2) "
                        .CommandText &= "WHERE(CbteAsociado2.cbteid = CbteCabecera2.Id) "
                        .CommandText &= "AND CbteReferencia=@Id "
                        .Parameters.AddWithValue("@Id", Id)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New CbteAsociado2
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
            "Datos:CbteCabecera2", _
            "GetEstadoDeCuenta", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Private Function Populate(ByVal reader As MySqlDataReader, Optional ByVal cargaCtaCte As Boolean = True, _
                              Optional ByVal cargaAlicuotas As Boolean = True, _
                              Optional ByVal cargaArticulos As Boolean = True, _
                              Optional ByVal cargaFinanciero As Boolean = True, _
                              Optional ByVal cargaTributos As Boolean = True, _
                              Optional ByVal cargaAsociados As Boolean = True) As CbteCabecera2

        Dim obj As New CbteCabecera2
        Try
            With obj
                .Id = Convert.ToUInt32(reader("Id"))
                .Concepto = Convert.ToInt32(reader("Concepto"))
                .Clienteid = Convert.ToString(reader("Clienteid"))
                .Razonsocial = Convert.ToString(reader("Razonsocial"))
                .Domicilio = Convert.ToString(reader("Domicilio"))
                .Contacto = Convert.ToString(reader("Contacto"))
                .Telefono = Convert.ToString(reader("Telefono"))
                .Email = Convert.ToString(reader("Email"))
                .Nroremito = Convert.ToString(reader("Nroremito"))
                .Documentotipo = Convert.ToString(reader("Documentotipo"))
                .Documentonro = Convert.ToString(reader("Documentonro"))
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
                .Fechaserviciodesde = Convert.ToString(reader("Fechaserviciodesde"))
                .Fechaserviciohasta = Convert.ToString(reader("Fechaserviciohasta"))
                .Fechavtopago = Convert.ToString(reader("Fechavtopago"))
                .Monedaid = Convert.ToString(reader("Monedaid"))
                .Monedactz = Convert.ToDouble(reader("Monedactz"))
                .Cae = Convert.ToString(reader("Cae"))
                .Fechavtocae = Convert.ToString(reader("Fechavtocae"))
                .Observaciones = Convert.ToString(reader("Observaciones"))
                .ObservacionesExtra = Convert.ToString(reader("ObservacionesExtra"))
                .Tiporesponsable = Convert.ToString(reader("Tiporesponsable"))
                .Cuitemisor = Convert.ToUInt64(reader("Cuitemisor"))
                .Usuario = Convert.ToUInt32(reader("Usuario"))
                '.Fechatransaccion = Convert.ToDateTime(reader("Fechatransaccion"))
                .Vendedor = Convert.ToUInt32(reader("Vendedor"))
                .Sucursal = Convert.ToUInt32(reader("Sucursal"))
                .Descuento = Convert.ToDouble(reader("Descuento"))
                .Letra = Convert.ToChar(reader("Letra"))
                .Denominacion = Convert.ToString(reader("Denominacion"))
                .Tipo = Convert.ToChar(reader("Tipo"))
                .FechaVigencia = Convert.ToDateTime(reader("Fechavigencia"))
                .Estado = Convert.ToString(reader("Estado"))

                .CondicionesPago = Convert.ToString(reader("CondicionesPago"))
                .PlazosEntrega = Convert.ToString(reader("PlazosEntrega"))
                .LugarEntrega = Convert.ToString(reader("LugarEntrega"))
                .MantenimientoOferta = Convert.ToString(reader("MantenimientoOferta"))

                .Importectaspropias = Convert.ToDouble(reader("Importectaspropias"))
                .Importecartera = Convert.ToDouble(reader("Importecartera"))

                If cargaAlicuotas Then .CbteAlicuotas2 = GetAlicuotas(.Id)
                If cargaArticulos Then .CbteArticulos2 = GetArticulos(.Id)
                If cargaTributos Then .CbteTributos2 = GetTributos(.Id)
                If cargaAsociados Then .CbteAsociados2 = GetCbtesAsociados(.Id)
                If cargaCtaCte Then .CbteEstadoCuenta = GetEstadoCuenta(.Id)
                'If cargaFinanciero Then .CbteDetalleFinanciero = GetCbteDetalleFinanciero(.Id)

            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function

    Private Function PopulateAlicuota(ByVal reader As MySqlDataReader) As CbteAlicuota2
        Dim obj As New CbteAlicuota2
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

    Private Function PopulateTributo(ByVal reader As MySqlDataReader) As CbteTributo2
        Dim obj As New CbteTributo2
        Try
            With obj
                .Id = Convert.ToUInt32(reader("Id"))
                '.CbteId = Convert.ToUInt32(reader("Id"))
                .Codigo = Convert.ToString(reader("Codigo"))
                .Referencia = Convert.ToString(reader("Referencia"))
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

    Private Function PopulateArticulo(ByVal reader As MySqlDataReader) As CbteArticulo2
        Dim obj As New CbteArticulo2
        Try
            With obj
                .Id = Convert.ToUInt32(reader("Id"))
                '.CbteId = Convert.ToUInt32(reader("Id"))
                .Codigo = Convert.ToString(reader("Codigo"))
                .Descripcion = Convert.ToString(reader("Descripcion"))
                '.Material = Convert.ToString(reader("Material"))
                .Cantidad = Convert.ToDouble(reader("Cantidad"))
                .Importe = Convert.ToDouble(reader("Importe"))
                .ImpIntTasaNominal = Convert.ToDouble(reader("ImpIntTasaNominal"))
                .ImpInterno = Convert.ToDouble(reader("ImpInterno"))
                .Alicuota = Convert.ToDouble(reader("Alicuota"))
                .AlicuotaCodigo = Convert.ToInt32(reader("AlicuotaCodigo"))
                .Unidad = Convert.ToString(reader("Unidad"))
                .Moneda = Convert.ToString(reader("MonedaId"))
                .Estado = Convert.ToString(reader("Estado"))

            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function

    Private Function PopulateCbteAsociado(ByVal reader As MySqlDataReader) As CbteAsociado2
        Dim obj As New CbteAsociado2
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

    Public Function GetRemitosCliente(ByVal cliente As UInt32, Optional ByVal vertodos As Boolean = False, Optional ByVal ordenDescendete As Boolean = False) As List(Of CbteCabecera2)
        Try
            Dim lista As New List(Of CbteCabecera2)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM CbteCabecera2 WHERE ClienteId = @cliente AND cbtetipo IN (@tipo) "

                        If Not vertodos Then
                            .CommandText &= " AND NroRemito='' "
                        End If

                        If ordenDescendete Then
                            .CommandText &= " ORDER BY id DESC"
                        End If

                        .Parameters.AddWithValue("@cliente", cliente)
                        .Parameters.AddWithValue("@tipo", REMITO)

                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New CbteCabecera2
                                    obj = Populate(reader)
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
            "Datos:CbteCabecera2", _
            "GetRemitosCliente", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function Anular(ByVal obj As CbteCabecera2) As UInt32

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
                .CommandText = "DELETE FROM Cbtealicuota2 WHERE Cbteid=@id"
                .Parameters.Clear()
                .Parameters.AddWithValue("@id", obj.Id)
                .ExecuteNonQuery()

                'elimino los comprobantes asociados
                .CommandText = "DELETE FROM Cbteasociado2 WHERE Cbteid=@id"
                .Parameters.Clear()
                .Parameters.AddWithValue("@id", obj.Id)
                .ExecuteNonQuery()

                'elimino los tributos del combrobante
                .CommandText = "DELETE FROM Cbtetributo2 WHERE Cbteid=@id"
                .Parameters.Clear()
                .Parameters.AddWithValue("@id", obj.Id)
                .ExecuteNonQuery()

                'elimino los articulos del combrobante
                .CommandText = "DELETE FROM Cbtearticulo2 WHERE Cbteid=@id"
                .Parameters.Clear()
                .Parameters.AddWithValue("@id", obj.Id)
                .ExecuteNonQuery()

                'elimino los articulos de la ficha de stock
                .CommandText = "DELETE FROM Fichastock WHERE CbteVta=@id"
                .Parameters.Clear()
                .Parameters.AddWithValue("@id", obj.Id)
                .ExecuteNonQuery()

                ''ojo! si proviene de un pago, los cheques solo deben cambiar su estado y no generar un nuevo registro
                'For Each objFinanciero As Entidades.Financiero In obj.CbteDetalleFinanciero

                '    .Parameters.Clear()
                '    'CUENTA_CARTERA As String = "CARTERA"
                '    'CONCEPTO_CHEQUE_RECIBIDO As String = "013"
                '    'CONCEPTO_CHEQUE_PASADO As String = "014"
                '    'CONCEPTO_CHEQUE_DEPOSITADO As String = "015"

                '    'valido los comprobantes de financiero
                '    If objFinanciero.Cuenta = CUENTA_CARTERA Then

                '        Select Case objFinanciero.Concepto
                '            Case CONCEPTO_CHEQUE_PASADO 'vuelvo el cheque pasado a su estado anterior
                '                Throw New Exception("El comprobante posee cheques que ya han sido pasados. Debe anular el pago correspondiente")
                '            Case CONCEPTO_CHEQUE_DEPOSITADO
                '                Throw New Exception("El comprobante posee cheques que ya han sido depositados. Debe anular el deposito correspondiente")
                '            Case Else
                '                .CommandText = "DELETE FROM Financiero WHERE id=@id"
                '                .Parameters.AddWithValue("@id", objFinanciero.Id)
                '        End Select

                '    Else 'para las otras cuentas, elimino los movimientos

                '        .CommandText = "DELETE FROM Financiero WHERE id=@id"
                '        .Parameters.AddWithValue("@id", objFinanciero.Id)

                '    End If

                '    .ExecuteNonQuery()

                'Next

                'elimino la cabecera al final por la integridad referencia
                .CommandText = "DELETE FROM CbteCabecera2 WHERE id=@id"
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
            "Datos:CbteCabecera2", _
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

    'Public Function GetCbteDetalleFinanciero(ByVal id As UInt32) As List(Of Financiero)
    '    Try
    '        Dim lista As New List(Of Financiero)
    '        Using cnn As MySqlConnection = CreateConnection()
    '            cnn.Open()
    '            Using cmd As New MySqlCommand
    '                With cmd
    '                    .Connection = cnn
    '                    .CommandType = CommandType.Text
    '                    '.CommandText = "SELECT Financiero.* FROM Financiero WHERE cuenta = @cuenta"
    '                    .CommandText = "SELECT Financiero.*,IFNULL(`CbteCabecera2`.`CbteTipo`,0) CptoVta,IFNULL(`cpracabecera`.`CbteTipo`,0) CptoCpra FROM Financiero LEFT JOIN `CbteCabecera2` ON financiero.`CbteVta` = `CbteCabecera2`.id"
    '                    .CommandText &= " LEFT JOIN `cpracabecera` ON financiero.`CbteCpra` = `cpracabecera`.id  WHERE CbteVta = @id"

    '                    .Parameters.AddWithValue("@id", id)
    '                    Try
    '                        Using reader As MySqlDataReader = .ExecuteReader
    '                            Do While reader.Read
    '                                Dim obj = New Financiero
    '                                obj = PopulateFinanciero(reader)
    '                                lista.Add(obj)
    '                                obj = Nothing
    '                            Loop
    '                            Return lista
    '                        End Using
    '                    Finally
    '                        lista = Nothing
    '                    End Try
    '                End With
    '            End Using
    '        End Using
    '    Catch exError As MySqlException
    '        ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
    '        Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
    '        "Datos:Financiero", _
    '        "GetCbteDetalleFinanciero", _
    '        ErrorMessageString, _
    '        WriteErrorMessageString)
    '        Throw New Exception(ErrorMessageString)
    '    End Try
    'End Function

    'Private Function PopulateFinanciero(ByVal reader As MySqlDataReader) As Financiero
    '    Dim obj As New Financiero
    '    Try
    '        With obj
    '            .Id = Convert.ToUInt32(reader("Id"))
    '            .Origen = Convert.ToString(reader("Origen"))
    '            .Cuenta = Convert.ToString(reader("Cuenta"))
    '            .Concepto = Convert.ToString(reader("Concepto"))
    '            .Beneficiario = Convert.ToString(reader("Beneficiario"))
    '            .Emision = Convert.ToDateTime(reader("Emision"))

    '            If Not IsDBNull(reader("Egreso")) Then
    '                .Egreso = Convert.ToDateTime(reader("Egreso"))
    '            End If

    '            .Efectivizacion = Convert.ToDateTime(reader("Efectivizacion"))
    '            .Importe = Convert.ToDouble(reader("Importe"))
    '            .Referencia = Convert.ToString(reader("Referencia"))
    '            .Observacion = Convert.ToString(reader("Observacion"))
    '            .Usuario = Convert.ToUInt32(reader("Usuario"))
    '            .Fecharegistracion = Convert.ToDateTime(reader("Fecharegistracion"))
    '            .Banco = Convert.ToUInt32(reader("Banco"))

    '            If Not IsDBNull(reader("Cbtevta")) Then
    '                .Cbtevta = Convert.ToUInt32(reader("Cbtevta"))
    '            End If

    '            If Not IsDBNull(reader("Cbtecpra")) Then
    '                .Cbtecpra = Convert.ToUInt32(reader("Cbtecpra"))
    '            End If

    '            If Not IsDBNull(reader("Cbterecibo")) Then
    '                .Cbterecibo = Convert.ToUInt32(reader("Cbterecibo"))
    '            End If

    '            If Not IsDBNull(reader("Cbtepago")) Then
    '                .Cbtepago = Convert.ToUInt32(reader("Cbtepago"))
    '            End If

    '            If Not IsDBNull(reader("Localidad")) Then
    '                .Localidad = Convert.ToUInt32(reader("Localidad"))
    '            End If

    '            .Tipo = Convert.ToString(reader("Tipo"))
    '            .Dador = Convert.ToString(reader("Dador"))
    '            .Sucursal = Convert.ToUInt32(reader("Sucursal"))

    '            If Not IsDBNull(reader("DocumentoNro")) Then
    '                .DocumentoNro = Convert.ToString(reader("DocumentoNro"))
    '            End If

    '            .Deposito = Convert.ToUInt32(reader("Deposito"))

    '            If Not IsDBNull(reader("CptoVta")) Then
    '                .CptoVta = Convert.ToUInt32(reader("CptoVta"))
    '            End If

    '            If Not IsDBNull(reader("CptoCpra")) Then
    '                .CptoCpra = Convert.ToUInt32(reader("CptoCpra"))
    '            End If

    '        End With
    '        Return obj
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message, ex)
    '    Finally
    '        obj = Nothing
    '    End Try
    'End Function

    Public Function CambiarEstado(ByVal obj As CbteCabecera2, ByVal nuevoestado As String) As UInt32

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

                .CommandText = "UPDATE CbteCabecera2 SET estado=@nuevoestado WHERE id=@id"
                .Parameters.Clear()
                .Parameters.AddWithValue("@id", obj.Id)
                .Parameters.AddWithValue("@nuevoestado", nuevoestado)
                .ExecuteNonQuery()

                If nuevoestado = CBTE_CANCELADO Then
                    .CommandText = "UPDATE Cbtearticulo2 SET estado = @nuevoestado WHERE Cbteid=@id"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@id", obj.Id)
                    .Parameters.AddWithValue("@nuevoestado", "R")
                    .ExecuteNonQuery()
                Else
                    'registro los comprobantes asociados
                    For Each objArt As Entidades.CbteArticulo2 In obj.CbteArticulos2
                        .CommandText = "UPDATE Cbtearticulo2 SET estado = @nuevoestado WHERE id=@id"
                        .Parameters.Clear()
                        .Parameters.AddWithValue("@id", objArt.Id)
                        .Parameters.AddWithValue("@nuevoestado", objArt.Estado)
                        .ExecuteNonQuery()
                    Next
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
            "Datos:CbteCabecera2", _
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

End Class

