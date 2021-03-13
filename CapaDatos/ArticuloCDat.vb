Imports Entidades
Imports MySql.Data.MySqlClient
Public Class ArticuloCDat

    Private ExceptionClassObject As New ManejoDeErrores.ExceptionClass
    Private ExceptionErrorFileString As String = My.Application.Info.DirectoryPath & "\ErrorFile.log"
    Private WriteErrorMessageString As String
    Private ErrorMessageString As String
    Public Function Insert(ByVal obj As Articulo) As UInt32
        Try
            Dim id As UInteger = 0
            Dim transaccion As MySqlTransaction = Nothing

            'proveedor,cantidadbulto,descuentocompra1,descuentocompra2,descuentocompra3

            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                transaccion = cnn.BeginTransaction
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .Transaction = transaccion
                        .CommandType = CommandType.Text
                        .CommandText = "INSERT INTO Articulos (Id,Codigo,Codigobarra,Nombre,Pesoneto,Pesobruto,Descripcion,Codrubro,Alicuotaiva,Impinttasanominal,Preciodeventa,Preciodecosto,Codunidad,Codcategoria,Fechaultimacompra,Preciodecompra,Descuento,Puntominimo,Oferta,Preciodeventa2,Preciodeventa3,"
                        .CommandText &= "Preciosugerido,Preciomodificable,Impuestointerno,Nombrecorto,Descuento2,Descuento3,Cantidadbulto,Descuentocompra1,Descuentocompra2,Descuentocompra3,Rentabilidad1,Rentabilidad2,Rentabilidad3,Descuentocompra4,Coeficientekg,Precioventaanterior,Precioventaanterior2,Precioventaanterior3,"
                        .CommandText &= "Fechaalta,Preciomodificado,Activo,Observacion) "
                        .CommandText &= "VALUES (@Id,@Codigo,@Codigobarra,@Nombre,@Pesoneto,@Pesobruto,@Descripcion,@Codrubro,@Alicuotaiva,@Impinttasanominal,@Preciodeventa,@Preciodecosto,@Codunidad,@Codcategoria,@Fechaultimacompra,@Preciodecompra,@Descuento,@Puntominimo,@Oferta,@Preciodeventa2,@Preciodeventa3,"
                        .CommandText &= "@Preciosugerido,@Preciomodificable,@Impuestointerno,@Nombrecorto,@Descuento2,@Descuento3,@Cantidadbulto,@Descuentocompra1,@Descuentocompra2,@Descuentocompra3,@Rentabilidad1,@Rentabilidad2,@Rentabilidad3,@Descuentocompra4,@Coeficientekg,@Precioventaanterior,@Precioventaanterior2,@Precioventaanterior3,"
                        .CommandText &= "@Fechaalta,@Preciomodificado,@Activo,@Observacion)"
                        .Parameters.AddWithValue("@Id", obj.Id)
                        '.Parameters.AddWithValue("@Codcliente", obj.Codcliente)
                        .Parameters.AddWithValue("@Codigo", obj.Codigo)
                        .Parameters.AddWithValue("@Codigobarra", obj.Codigobarra)
                        '.Parameters.AddWithValue("@Rev", obj.Rev)
                        '.Parameters.AddWithValue("@Plu", obj.Plu)
                        .Parameters.AddWithValue("@Nombre", obj.Nombre)
                        '.Parameters.AddWithValue("@Moldeo", obj.Moldeo)
                        '.Parameters.AddWithValue("@Colada", obj.Colada)
                        '.Parameters.AddWithValue("@Pintura", obj.Pintura)
                        .Parameters.AddWithValue("@Pesoneto", obj.Pesoneto)
                        .Parameters.AddWithValue("@Pesobruto", obj.Pesobruto)
                        .Parameters.AddWithValue("@Descripcion", obj.Descripcion)
                        .Parameters.AddWithValue("@Codrubro", obj.Codrubro)
                        '.Parameters.AddWithValue("@material", obj.Material)
                        '.Parameters.AddWithValue("@Codmaterial", obj.Codmaterial)
                        .Parameters.AddWithValue("@Alicuotaiva", obj.Alicuotaiva)
                        .Parameters.AddWithValue("@Impinttasanominal", obj.Impinttasanominal)
                        .Parameters.AddWithValue("@Preciodeventa", obj.Preciodeventa)
                        .Parameters.AddWithValue("@Preciodecosto", obj.Preciodecosto)
                        .Parameters.AddWithValue("@Codunidad", obj.Codunidad)
                        .Parameters.AddWithValue("@Codcategoria", obj.Codcategoria)
                        .Parameters.AddWithValue("@Fechaultimacompra", obj.Fechaultimacompra)
                        .Parameters.AddWithValue("@Preciodecompra", obj.Preciodecompra)
                        .Parameters.AddWithValue("@Descuento", obj.Descuento)
                        .Parameters.AddWithValue("@Puntominimo", obj.Puntominimo)
                        .Parameters.AddWithValue("@Oferta", obj.Oferta)
                        .Parameters.AddWithValue("@Preciodeventa2", obj.Preciodeventa2)
                        .Parameters.AddWithValue("@Preciodeventa3", obj.Preciodeventa3)
                        .Parameters.AddWithValue("@Preciosugerido", obj.Preciosugerido)
                        .Parameters.AddWithValue("@Preciomodificable", obj.Preciomodificable)
                        .Parameters.AddWithValue("@Impuestointerno", obj.Impuestointerno)
                        .Parameters.AddWithValue("@Nombrecorto", obj.Nombrecorto)
                        .Parameters.AddWithValue("@Descuento2", obj.Descuento2)
                        .Parameters.AddWithValue("@Descuento3", obj.Descuento3)
                        '.Parameters.AddWithValue("@Codproveedor", obj.Codproveedor)
                        .Parameters.AddWithValue("@Cantidadbulto", obj.CantidadBulto)
                        .Parameters.AddWithValue("@Descuentocompra1", obj.Descuentocompra1)
                        .Parameters.AddWithValue("@Descuentocompra2", obj.Descuentocompra2)
                        .Parameters.AddWithValue("@Descuentocompra3", obj.Descuentocompra3)
                        .Parameters.AddWithValue("@Rentabilidad1", obj.Rentabilidad1)
                        .Parameters.AddWithValue("@Rentabilidad2", obj.Rentabilidad2)
                        .Parameters.AddWithValue("@Rentabilidad3", obj.Rentabilidad3)
                        .Parameters.AddWithValue("@Descuentocompra4", obj.Descuentocompra4)
                        .Parameters.AddWithValue("@Coeficientekg", obj.CoeficienteKG)
                        '.Parameters.AddWithValue("@Preciocostous", obj.PreciocostoUS)
                        '.Parameters.AddWithValue("@Flete", obj.Flete)
                        .Parameters.AddWithValue("@Precioventaanterior", obj.Precioventaanterior)
                        .Parameters.AddWithValue("@Precioventaanterior2", obj.Precioventaanterior2)
                        .Parameters.AddWithValue("@Precioventaanterior3", obj.Precioventaanterior3)
                        .Parameters.AddWithValue("@Fechaalta", obj.FechaAlta)
                        '.Parameters.AddWithValue("@Unidaddescripcion", obj.Unidaddescripcion)
                        .Parameters.AddWithValue("@Preciomodificado", obj.Preciomodificado)
                        .Parameters.AddWithValue("@Activo", obj.Activo)
                        '.Parameters.AddWithValue("@Cantcajasnoyos", obj.Cantcajasnoyos)
                        '.Parameters.AddWithValue("@Casillero", obj.Casillero)
                        '.Parameters.AddWithValue("@Cantmodelostk", obj.Cantmodelostk)
                        '.Parameters.AddWithValue("@Tipomodelo", obj.Tipomodelo)
                        '.Parameters.AddWithValue("@Detallecajas", obj.Detallecajas)
                        .Parameters.AddWithValue("@Observacion", obj.Observacion)

                        .ExecuteNonQuery()

                        'recupero el id de la factura creada
                        id = .LastInsertedId

                        ''registro las fotos
                        'For Each objFotos As Entidades.Fotos In obj.Fotos
                        '    .CommandText = "INSERT INTO Fotos "
                        '    .CommandText &= " (id,idpieza,ruta,Orden) "
                        '    .CommandText &= " VALUES "
                        '    .CommandText &= " (@id,@idpieza,@ruta,@Orden) "
                        '    .CommandText &= " ON DUPLICATE KEY UPDATE "
                        '    .CommandText &= " idpieza=@idpieza,ruta=@ruta,orden=@Orden "

                        '    .Parameters.Clear()

                        '    If objFotos.Id <> 0 Then
                        '        .Parameters.AddWithValue("@id", objFotos.Id)
                        '    Else
                        '        .Parameters.AddWithValue("@id", Nothing)
                        '    End If

                        '    .Parameters.AddWithValue("@idpieza", id)
                        '    .Parameters.AddWithValue("@ruta", objFotos.Ruta)
                        '    .Parameters.AddWithValue("@Orden", objFotos.Orden)
                        '    .ExecuteNonQuery()
                        'Next

                        ''registro los planos
                        'For Each objPlanos As Entidades.Planos In obj.Planos
                        '    .CommandText = "INSERT INTO Planos "
                        '    .CommandText &= " (id,idpieza,numero,observacion,ruta,Orden) "
                        '    .CommandText &= " VALUES "
                        '    .CommandText &= " (@id,@idpieza,@numero,@observacion,@ruta,@Orden) "
                        '    .CommandText &= " ON DUPLICATE KEY UPDATE "
                        '    .CommandText &= " idpieza=@idpieza,numero=@numero,observacion=@observacion,ruta=@ruta,Orden=@Orden "

                        '    .Parameters.Clear()

                        '    If objPlanos.Id <> 0 Then
                        '        .Parameters.AddWithValue("@id", objPlanos.Id)
                        '    Else
                        '        .Parameters.AddWithValue("@id", Nothing)
                        '    End If

                        '    .Parameters.AddWithValue("@idpieza", id)
                        '    .Parameters.AddWithValue("@numero", objPlanos.Numero)
                        '    .Parameters.AddWithValue("@observacion", objPlanos.Observacion)
                        '    .Parameters.AddWithValue("@ruta", objPlanos.Ruta)
                        '    .Parameters.AddWithValue("@Orden", objPlanos.Orden)
                        '    .ExecuteNonQuery()
                        'Next

                    End With
                    transaccion.Commit()

                    'Next
                    Return id
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Articulo", _
            "Insert", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Sub Update(ByVal obj As Articulo)
        Dim id As UInteger = 0
        Dim transaccion As MySqlTransaction = Nothing
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                transaccion = cnn.BeginTransaction
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .Transaction = transaccion
                        .CommandType = CommandType.Text
                        .CommandText = "UPDATE Articulos SET Codigo = @Codigo,Codigobarra = @Codigobarra,Nombre = @Nombre,Pesoneto = @Pesoneto,Pesobruto = @Pesobruto,Descripcion = @Descripcion,Codrubro = @Codrubro,Alicuotaiva = @Alicuotaiva,Impinttasanominal = @Impinttasanominal,Preciodeventa = @Preciodeventa,Preciodecosto = @Preciodecosto,"
                        .CommandText &= "Codunidad = @Codunidad,Codcategoria = @Codcategoria,Fechaultimacompra = @Fechaultimacompra,Preciodecompra = @Preciodecompra,Descuento = @Descuento,Puntominimo = @Puntominimo,Oferta = @Oferta,Preciodeventa2 = @Preciodeventa2,Preciodeventa3 = @Preciodeventa3,Preciosugerido = @Preciosugerido,Preciomodificable = @Preciomodificable,Impuestointerno = @Impuestointerno,Nombrecorto = @Nombrecorto,"
                        .CommandText &= "Descuento2 = @Descuento2,Descuento3 = @Descuento3,Cantidadbulto = @Cantidadbulto,Descuentocompra1 = @Descuentocompra1,Descuentocompra2 = @Descuentocompra2,Descuentocompra3 = @Descuentocompra3,Rentabilidad1 = @Rentabilidad1,Rentabilidad2 = @Rentabilidad2,Rentabilidad3 = @Rentabilidad3,Descuentocompra4 = @Descuentocompra4,Coeficientekg = @Coeficientekg,"
                        .CommandText &= "Precioventaanterior = @Precioventaanterior,Precioventaanterior2 = @Precioventaanterior2,Precioventaanterior3 = @Precioventaanterior3,Fechaalta = @Fechaalta,Preciomodificado = @Preciomodificado,Activo = @Activo,Observacion = @Observacion "
                        .CommandText &= "WHERE Id = @Id"
                        .Parameters.AddWithValue("@Id", obj.Id)
                        '.Parameters.AddWithValue("@Codcliente", obj.Codcliente)
                        .Parameters.AddWithValue("@Codigo", obj.Codigo)
                        .Parameters.AddWithValue("@Codigobarra", obj.Codigobarra)
                        '.Parameters.AddWithValue("@Rev", obj.Rev)
                        '.Parameters.AddWithValue("@Plu", obj.Plu)
                        .Parameters.AddWithValue("@Nombre", obj.Nombre)
                        '.Parameters.AddWithValue("@Moldeo", obj.Moldeo)
                        '.Parameters.AddWithValue("@Colada", obj.Colada)
                        '.Parameters.AddWithValue("@Pintura", obj.Pintura)
                        .Parameters.AddWithValue("@Pesoneto", obj.Pesoneto)
                        .Parameters.AddWithValue("@Pesobruto", obj.Pesobruto)
                        .Parameters.AddWithValue("@Descripcion", obj.Descripcion)
                        .Parameters.AddWithValue("@Codrubro", obj.Codrubro)
                        '.Parameters.AddWithValue("@material", obj.Material)
                        '.Parameters.AddWithValue("@Codmaterial", obj.Codmaterial)
                        .Parameters.AddWithValue("@Alicuotaiva", obj.Alicuotaiva)
                        .Parameters.AddWithValue("@Impinttasanominal", obj.Impinttasanominal)
                        .Parameters.AddWithValue("@Preciodeventa", obj.Preciodeventa)
                        .Parameters.AddWithValue("@Preciodecosto", obj.Preciodecosto)
                        .Parameters.AddWithValue("@Codunidad", obj.Codunidad)
                        .Parameters.AddWithValue("@Codcategoria", obj.Codcategoria)
                        .Parameters.AddWithValue("@Fechaultimacompra", obj.Fechaultimacompra)
                        .Parameters.AddWithValue("@Preciodecompra", obj.Preciodecompra)
                        .Parameters.AddWithValue("@Descuento", obj.Descuento)
                        .Parameters.AddWithValue("@Puntominimo", obj.Puntominimo)
                        .Parameters.AddWithValue("@Oferta", obj.Oferta)
                        .Parameters.AddWithValue("@Preciodeventa2", obj.Preciodeventa2)
                        .Parameters.AddWithValue("@Preciodeventa3", obj.Preciodeventa3)
                        .Parameters.AddWithValue("@Preciosugerido", obj.Preciosugerido)
                        .Parameters.AddWithValue("@Preciomodificable", obj.Preciomodificable)
                        .Parameters.AddWithValue("@Impuestointerno", obj.Impuestointerno)
                        .Parameters.AddWithValue("@Nombrecorto", obj.Nombrecorto)
                        .Parameters.AddWithValue("@Descuento2", obj.Descuento2)
                        .Parameters.AddWithValue("@Descuento3", obj.Descuento3)
                        '.Parameters.AddWithValue("@Codproveedor", obj.Codproveedor)
                        .Parameters.AddWithValue("@Cantidadbulto", obj.CantidadBulto)
                        .Parameters.AddWithValue("@Descuentocompra1", obj.Descuentocompra1)
                        .Parameters.AddWithValue("@Descuentocompra2", obj.Descuentocompra2)
                        .Parameters.AddWithValue("@Descuentocompra3", obj.Descuentocompra3)
                        .Parameters.AddWithValue("@Rentabilidad1", obj.Rentabilidad1)
                        .Parameters.AddWithValue("@Rentabilidad2", obj.Rentabilidad2)
                        .Parameters.AddWithValue("@Rentabilidad3", obj.Rentabilidad3)
                        .Parameters.AddWithValue("@Descuentocompra4", obj.Descuentocompra4)
                        .Parameters.AddWithValue("@Coeficientekg", obj.CoeficienteKG)
                        '.Parameters.AddWithValue("@Preciocostous", obj.PreciocostoUS)
                        '.Parameters.AddWithValue("@Flete", obj.Flete)
                        .Parameters.AddWithValue("@Precioventaanterior", obj.Precioventaanterior)
                        .Parameters.AddWithValue("@Precioventaanterior2", obj.Precioventaanterior2)
                        .Parameters.AddWithValue("@Precioventaanterior3", obj.Precioventaanterior3)
                        .Parameters.AddWithValue("@Fechaalta", obj.FechaAlta)
                        '.Parameters.AddWithValue("@Unidaddescripcion", obj.Unidaddescripcion)
                        .Parameters.AddWithValue("@Preciomodificado", obj.Preciomodificado)
                        .Parameters.AddWithValue("@Activo", obj.Activo)
                        '.Parameters.AddWithValue("@Cantcajasnoyos", obj.Cantcajasnoyos)
                        '.Parameters.AddWithValue("@Casillero", obj.Casillero)
                        '.Parameters.AddWithValue("@Cantmodelostk", obj.Cantmodelostk)
                        '.Parameters.AddWithValue("@Tipomodelo", obj.Tipomodelo)
                        '.Parameters.AddWithValue("@Detallecajas", obj.Detallecajas)
                        .Parameters.AddWithValue("@Observacion", obj.Observacion)

                        .ExecuteNonQuery()

                        'registro las fotos
                        'For Each objFotos As Entidades.Fotos In obj.Fotos
                        '    .CommandText = "INSERT INTO Fotos "
                        '    .CommandText &= " (id,idpieza,ruta,Orden) "
                        '    .CommandText &= " VALUES "
                        '    .CommandText &= " (@id,@idpieza,@ruta,@Orden) "
                        '    .CommandText &= " ON DUPLICATE KEY UPDATE "
                        '    .CommandText &= " idpieza=@idpieza,ruta=@ruta,Orden=@Orden "

                        '    .Parameters.Clear()

                        '    If objFotos.Id <> 0 Then
                        '        .Parameters.AddWithValue("@id", objFotos.Id)
                        '    Else
                        '        .Parameters.AddWithValue("@id", Nothing)
                        '    End If

                        '    .Parameters.AddWithValue("@idpieza", obj.Id)
                        '    .Parameters.AddWithValue("@ruta", objFotos.Ruta)
                        '    .Parameters.AddWithValue("@Orden", objFotos.Orden)
                        '    .ExecuteNonQuery()
                        'Next

                        ''registro los planos
                        'For Each objPlanos As Entidades.Planos In obj.Planos
                        '    .CommandText = "INSERT INTO Planos "
                        '    .CommandText &= " (id,idpieza,numero,observacion,ruta,Orden) "
                        '    .CommandText &= " VALUES "
                        '    .CommandText &= " (@id,@idpieza,@numero,@observacion,@ruta,@Orden) "
                        '    .CommandText &= " ON DUPLICATE KEY UPDATE "
                        '    .CommandText &= " idpieza=@idpieza,numero=@numero,observacion=@observacion,ruta=@ruta,Orden=@Orden "

                        '    .Parameters.Clear()

                        '    If objPlanos.Id <> 0 Then
                        '        .Parameters.AddWithValue("@id", objPlanos.Id)
                        '    Else
                        '        .Parameters.AddWithValue("@id", Nothing)
                        '    End If

                        '    .Parameters.AddWithValue("@idpieza", obj.Id)
                        '    .Parameters.AddWithValue("@numero", objPlanos.Numero)
                        '    .Parameters.AddWithValue("@observacion", objPlanos.Observacion)
                        '    .Parameters.AddWithValue("@ruta", objPlanos.Ruta)
                        '    .Parameters.AddWithValue("@Orden", objPlanos.Orden)
                        '    .ExecuteNonQuery()
                        'Next

                    End With

                    transaccion.Commit()

                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Articulo", _
            "Update", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Sub

    Public Sub UpdatePreciosPorEntornoDeRubro(ByVal rdesde As String, ByVal rhasta As String, ByVal alicuota As Double, Optional ByVal proveedor As String = "")
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "UPDATE Articulos SET Preciodeventa = (Preciodeventa * @alicuota),"
                        .CommandText &= "Preciodeventa2 = (Preciodeventa2 * @alicuota), Preciodeventa3 = (Preciodeventa3 * @alicuota) WHERE codRubro >= @rdesde AND codRubro <= @rhasta"

                        If proveedor > 0 Then
                            .CommandText &= " AND codproveedor=@codproveedor"
                            .Parameters.AddWithValue("@codproveedor", proveedor)
                        End If

                        .Parameters.AddWithValue("@rdesde", rdesde)
                        .Parameters.AddWithValue("@rhasta", rhasta)
                        .Parameters.AddWithValue("@alicuota", alicuota)


                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Articulo", _
            "UpdatePreciosPorEntornoDeRubro", _
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
                        '.CommandText = "DELETE FROM Fotos WHERE Idpieza = @Id"
                        '.Parameters.Clear()
                        '.Parameters.AddWithValue("@Id", id)
                        '.ExecuteNonQuery()

                        '.CommandText = "DELETE FROM Planos WHERE Idpieza = @Id"
                        '.Parameters.Clear()
                        '.Parameters.AddWithValue("@Id", id)
                        '.ExecuteNonQuery()

                        .CommandText = "DELETE FROM Articulos WHERE Id = @Id"
                        .Parameters.Clear()
                        .Parameters.AddWithValue("@Id", id)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Articulo", _
            "Delete", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Sub

    'Public Sub DeletePlano(ByVal id As UInt32)
    '    Try
    '        Using cnn As MySqlConnection = CreateConnection()
    '            cnn.Open()
    '            Using cmd As New MySqlCommand
    '                With cmd
    '                    .Connection = cnn
    '                    .CommandType = CommandType.Text
    '                    .CommandText = "DELETE FROM Planos WHERE Id = @Id"
    '                    .Parameters.AddWithValue("@Id", id)
    '                    .ExecuteNonQuery()
    '                End With
    '            End Using
    '        End Using
    '    Catch exError As MySqlException
    '        ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
    '        Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
    '        "Datos:Planos", _
    '        "DeletePlano", _
    '        ErrorMessageString, _
    '        WriteErrorMessageString)
    '        Throw New Exception(ErrorMessageString)
    '    End Try
    'End Sub

    'Public Sub DeleteFoto(ByVal id As UInt32)
    '    Try
    '        Using cnn As MySqlConnection = CreateConnection()
    '            cnn.Open()
    '            Using cmd As New MySqlCommand
    '                With cmd
    '                    .Connection = cnn
    '                    .CommandType = CommandType.Text
    '                    .CommandText = "DELETE FROM Fotos WHERE Id = @Id"
    '                    .Parameters.AddWithValue("@Id", id)
    '                    .ExecuteNonQuery()
    '                End With
    '            End Using
    '        End Using
    '    Catch exError As MySqlException
    '        ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
    '        Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
    '        "Datos:Fotos", _
    '        "DeleteFoto", _
    '        ErrorMessageString, _
    '        WriteErrorMessageString)
    '        Throw New Exception(ErrorMessageString)
    '    End Try
    'End Sub

    Public Function GetNextCodigo() As String
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT (IFNULL(MAX(Codigo),0)+1) NextCodigo FROM Articulos"

                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Return reader("NextCodigo")
                            Else
                                Return 0
                            End If
                        End Using
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Articulo", _
            "GetNextCodigo", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetById(ByVal id As UInt32) As Articulo
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT p.*,u.`nombre` NombreUnidad,u.`simbolo` SimboloUnidad,r.`nombre` NombreRubro FROM Articulos p "
                        .CommandText &= "LEFT JOIN `unidad` u ON p.`codunidad`=u.`codigo` "
                        .CommandText &= "LEFT JOIN `rubro` r on p.`codrubro`=r.`codigo` "
                        .CommandText &= "WHERE p.Id= @Id"
                        .Parameters.AddWithValue("@Id", id)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Dim obj As New Articulo
                                obj = Populate(reader)
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
            "Datos:Articulo", _
            "GetById", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetByCodigo(ByVal Codigo As String) As Articulo
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT p.*,u.`nombre` NombreUnidad,u.`simbolo` SimboloUnidad,r.`nombre` NombreRubro FROM Articulos p "
                        .CommandText &= "LEFT JOIN `unidad` u ON p.`codunidad`=u.`codigo` "
                        .CommandText &= "LEFT JOIN `rubro` r on p.`codrubro`=r.`codigo` "
                        .CommandText &= "WHERE p.Codigo= @Codigo"
                        .Parameters.AddWithValue("@Codigo", Codigo)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Dim obj As New Articulo
                                obj = Populate(reader)
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
            "Datos:Articulo", _
            "GetByCodigo", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetExistencia(ByVal Codigo As String) As Double
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT IFNULL(GETEXISTENCIA(@Codigo),0) AS Existencia"
                        .Parameters.AddWithValue("@Codigo", Codigo)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Dim existencia As Double
                                existencia = Convert.ToDouble(reader("Existencia"))
                                Return existencia
                            Else
                                Return 0.0
                            End If
                        End Using
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Articulo", _
            "GetExistencia", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetByCodigoBarra(ByVal Codigobarra As String) As Articulo
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT p.*,u.`nombre` NombreUnidad,u.`simbolo` SimboloUnidad,r.`nombre` NombreRubro FROM Articulos p "
                        .CommandText &= "LEFT JOIN `unidad` u ON p.`codunidad`=u.`codigo` "
                        .CommandText &= "LEFT JOIN `rubro` r on p.`codrubro`=r.`codigo` "
                        .CommandText &= "WHERE p.Codigobarra= @Codigobarra"
                        .Parameters.AddWithValue("@Codigobarra", Codigobarra)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Dim obj As New Articulo
                                obj = Populate(reader)
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
            "Datos:Articulo", _
            "GetByCodigoBarra", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetAll() As List(Of Articulo)
        Try
            Dim lista As New List(Of Articulo)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT p.*,u.`nombre` NombreUnidad,u.`simbolo` SimboloUnidad,r.`nombre` NombreRubro FROM Articulos p "
                        .CommandText &= "LEFT JOIN `unidad` u ON p.`codunidad`=u.`codigo` "
                        .CommandText &= "LEFT JOIN `rubro` r on p.`codrubro`=r.`codigo` "
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New Articulo
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
            "Datos:Articulo", _
            "GetAll", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

   

    Public Function GetArticulosConExistencia() As List(Of Articulo)
        Try
            Dim lista As New List(Of Articulo)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT p.*,IFNULL(GETEXISTENCIA(p.Codigo),0) AS Existencia,"
                        .CommandText &= "u.`nombre` NombreUnidad,u.`simbolo` SimboloUnidad,r.`nombre` NombreRubro FROM Articulos p "
                        .CommandText &= "LEFT JOIN `unidad` u ON p.`codunidad`=u.`codigo` "
                        .CommandText &= "LEFT JOIN `rubro` r on p.`codrubro`=r.`codigo` "
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New Articulo
                                    obj = Populate(reader)
                                    obj.ExistenciaActual = Convert.ToDouble(reader("Existencia"))
                                    obj.ExistenciaReal = Convert.ToDouble(reader("Existencia"))
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
            "Datos:Articulo", _
            "GetArticulosConExistencia", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    'Public Function GetByCliente(ByVal pstrCliente As String, ByVal pstrOrden As String, Optional ByVal blnArtVarios As Boolean = False) As List(Of Articulo)
    '    Try
    '        Dim lista As New List(Of Articulo)
    '        Using cnn As MySqlConnection = CreateConnection()
    '            cnn.Open()
    '            Using cmd As New MySqlCommand
    '                With cmd
    '                    .Connection = cnn
    '                    .CommandType = CommandType.Text
    '                    .CommandText = "SELECT p.*,c.codigo CodCliente,c.nombre Cliente,"
    '                    .CommandText &= "u.`nombre` NombreUnidad,u.`simbolo` SimboloUnidad,r.`nombre` NombreRubro FROM Articulos p "
    '                    .CommandText &= "LEFT JOIN CLIENTE c ON p.codcliente=c.codigo "
    '                    .CommandText &= "LEFT JOIN `unidad` u ON p.`codunidad`=u.`codigo` "
    '                    .CommandText &= "LEFT JOIN `rubro` r on p.`codrubro`=r.`codigo` "
    '                    If blnArtVarios = False Then
    '                        .CommandText &= "WHERE p.codcliente=" & pstrCliente & " "
    '                    Else
    '                        .CommandText &= "WHERE (p.codcliente=" & pstrCliente & " "
    '                        .CommandText &= "OR p.codigo='" & ARTICULO_VARIOS & "') "
    '                    End If

    '                    .CommandText &= "ORDER BY " & pstrOrden
    '                    Try
    '                        Using reader As MySqlDataReader = .ExecuteReader
    '                            Do While reader.Read
    '                                Dim obj = New Articulo
    '                                obj = Populate(reader)
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
    '        "Datos:Articulos", _
    '        "GetByCliente", _
    '        ErrorMessageString, _
    '        WriteErrorMessageString)
    '        Throw New Exception(ErrorMessageString)
    '    End Try
    'End Function

    Public Function GetByArticulo(ByVal pstrCodigo As String, ByVal pstrOrden As String) As List(Of Articulo)
        Try
            Dim lista As New List(Of Articulo)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT p.*,u.`nombre` NombreUnidad,u.`simbolo` SimboloUnidad,r.`nombre` NombreRubro FROM Articulos p "
                        .CommandText &= "LEFT JOIN `unidad` u ON p.`codunidad`=u.`codigo` "
                        .CommandText &= "LEFT JOIN `rubro` r on p.`codrubro`=r.`codigo` "
                        .CommandText &= "WHERE p.codigo='" & pstrCodigo & "' "
                        .CommandText &= "ORDER BY " & pstrOrden
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New Articulo
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
            "Datos:Articulos", _
            "GetByPieza", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    'Public Function GetPlanos(ByVal Id As UInt32) As List(Of Planos)
    '    Try
    '        Dim lista As New List(Of Planos)
    '        Using cnn As MySqlConnection = CreateConnection()
    '            cnn.Open()
    '            Using cmd As New MySqlCommand
    '                With cmd
    '                    .Connection = cnn
    '                    .CommandType = CommandType.Text
    '                    .CommandText = "SELECT * FROM Planos WHERE Idpieza = @Id"
    '                    .Parameters.AddWithValue("@Id", Id)
    '                    Try
    '                        Using reader As MySqlDataReader = .ExecuteReader
    '                            Do While reader.Read
    '                                Dim obj = New Planos
    '                                obj = PopulatePlanos(reader)
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
    '        "Datos:Planos", _
    '        "GetPlanos", _
    '        ErrorMessageString, _
    '        WriteErrorMessageString)
    '        Throw New Exception(ErrorMessageString)
    '    End Try
    'End Function

    'Public Function GetFotos(ByVal Id As UInt32) As List(Of Fotos)
    '    Try
    '        Dim lista As New List(Of Fotos)
    '        Using cnn As MySqlConnection = CreateConnection()
    '            cnn.Open()
    '            Using cmd As New MySqlCommand
    '                With cmd
    '                    .Connection = cnn
    '                    .CommandType = CommandType.Text
    '                    .CommandText = "SELECT * FROM Fotos WHERE Idpieza = @Id"
    '                    .Parameters.AddWithValue("@Id", Id)
    '                    Try
    '                        Using reader As MySqlDataReader = .ExecuteReader
    '                            Do While reader.Read
    '                                Dim obj = New Fotos
    '                                obj = PopulateFotos(reader)
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
    '        "Datos:Fotos", _
    '        "GetFotos", _
    '        ErrorMessageString, _
    '        WriteErrorMessageString)
    '        Throw New Exception(ErrorMessageString)
    '    End Try
    'End Function

    Private Function Populate(ByVal reader As MySqlDataReader) As Articulo
        Dim obj As New Articulo

        Try
            With obj

                .Id = Convert.ToUInt32(reader("Id"))
                '.Codcliente = Convert.ToString(reader("Codcliente"))
                .Codigo = Convert.ToString(reader("Codigo"))
                .Codigobarra = Convert.ToString(reader("Codigobarra"))
                '.Rev = Convert.ToString(reader("Rev"))
                '.Plu = Convert.ToString(reader("Plu"))
                .Nombre = Convert.ToString(reader("Nombre"))
                '.Moldeo = Convert.ToString(reader("Moldeo"))
                '.Colada = Convert.ToString(reader("Colada"))
                '.Pintura = Convert.ToString(reader("Pintura"))
                .Pesoneto = Convert.ToDouble(reader("Pesoneto"))
                .Pesobruto = Convert.ToDouble(reader("Pesobruto"))
                .Descripcion = Convert.ToString(reader("Descripcion"))
                .Codrubro = Convert.ToString(reader("Codrubro"))
                '.Codmaterial = Convert.ToString(reader("Codmaterial"))
                '.Material = Convert.ToString(reader("material"))
                .Alicuotaiva = Convert.ToUInt32(reader("Alicuotaiva"))
                .Impinttasanominal = Convert.ToDouble(reader("Impinttasanominal"))
                .Preciodeventa = Convert.ToDouble(reader("Preciodeventa"))
                .Preciodecosto = Convert.ToDouble(reader("Preciodecosto"))
                .Codunidad = Convert.ToString(reader("Codunidad"))
                .Codcategoria = Convert.ToString(reader("Codcategoria"))
                .Fechaultimacompra = Convert.ToDateTime(reader("Fechaultimacompra"))
                .Preciodecompra = Convert.ToDouble(reader("Preciodecompra"))
                .Descuento = Convert.ToDouble(reader("Descuento"))
                .Puntominimo = Convert.ToDouble(reader("Puntominimo"))
                .Oferta = Convert.ToBoolean(reader("Oferta"))
                .Preciodeventa2 = Convert.ToDouble(reader("Preciodeventa2"))
                .Preciodeventa3 = Convert.ToDouble(reader("Preciodeventa3"))
                .Preciosugerido = Convert.ToDouble(reader("Preciosugerido"))
                .Preciomodificable = Convert.ToUInt32(reader("Preciomodificable"))
                .Impuestointerno = Convert.ToDouble(reader("Impuestointerno"))
                .Nombrecorto = Convert.ToString(reader("Nombrecorto"))
                .Descuento2 = Convert.ToDouble(reader("Descuento2"))
                .Descuento3 = Convert.ToDouble(reader("Descuento3"))
                '.Codproveedor = Convert.ToString(reader("Codproveedor"))
                .CantidadBulto = Convert.ToDouble(reader("Cantidadbulto"))
                .Descuentocompra1 = Convert.ToDouble(reader("Descuentocompra1"))
                .Descuentocompra2 = Convert.ToDouble(reader("Descuentocompra2"))
                .Descuentocompra3 = Convert.ToDouble(reader("Descuentocompra3"))
                .Rentabilidad1 = Convert.ToDouble(reader("Rentabilidad1"))
                .Rentabilidad2 = Convert.ToDouble(reader("Rentabilidad2"))
                .Rentabilidad3 = Convert.ToDouble(reader("Rentabilidad3"))
                .Descuentocompra4 = Convert.ToDouble(reader("Descuentocompra4"))
                .CoeficienteKG = Convert.ToDouble(reader("Coeficientekg"))
                '.PreciocostoUS = Convert.ToDouble(reader("Preciocostous"))
                '.Flete = Convert.ToUInt32(reader("Flete"))
                .Precioventaanterior = Convert.ToDouble(reader("Precioventaanterior"))
                .Precioventaanterior2 = Convert.ToDouble(reader("Precioventaanterior2"))
                .Precioventaanterior3 = Convert.ToDouble(reader("Precioventaanterior3"))
                .FechaAlta = Convert.ToDateTime(reader("Fechaalta"))
                '.Unidaddescripcion = Convert.ToString(reader("Unidaddescripcion"))
                .Preciomodificado = Convert.ToBoolean(reader("Preciomodificado"))
                .Activo = Convert.ToBoolean(reader("Activo"))
                '.Cantcajasnoyos = Convert.ToUInt32(reader("Cantcajasnoyos"))
                '.Casillero = Convert.ToUInt32(reader("Casillero"))
                '.Cantmodelostk = Convert.ToUInt32(reader("Cantmodelostk"))
                '.Tipomodelo = Convert.ToString(reader("Tipomodelo"))
                '.Detallecajas = Convert.ToString(reader("Detallecajas"))
                .Observacion = Convert.ToString(reader("Observacion"))

                .NombreUnidad = Convert.ToString(reader("NombreUnidad"))
                .SimboloUnidad = Convert.ToString(reader("SimboloUnidad"))
                .NombreRubro = Convert.ToString(reader("NombreRubro"))

                .ComisionPrecio1 = 0.0
                .ComisionPrecio2 = 0.0
                .ComisionPrecio3 = 0.0
                'Agregados
                '.Cliente = Convert.ToString(reader("Cliente"))
                '.Planos = GetPlanos(.Id)
                '.Fotos = GetFotos(.Id)
                ''Ruta Fotos
                'lngPos = 0
                'For Each p As Entidades.Fotos In .Fotos
                '    Select Case p.Orden
                '        Case 1
                '            .RutaFoto1 = .Fotos(lngPos).Ruta
                '        Case 2
                '            .RutaFoto2 = .Fotos(lngPos).Ruta
                '        Case 3
                '            .RutaFoto3 = .Fotos(lngPos).Ruta
                '        Case 4
                '            .RutaFoto4 = .Fotos(lngPos).Ruta
                '        Case 5
                '            .RutaFoto5 = .Fotos(lngPos).Ruta
                '        Case 6
                '            .RutaFoto6 = .Fotos(lngPos).Ruta
                '    End Select
                '    lngPos = lngPos + 1
                'Next
                ''Nros. de Planos
                'lngPos = 0
                'For Each p As Entidades.Planos In .Planos
                '    Select Case p.Orden
                '        Case 1
                '            .NroPlano1 = .Planos(lngPos).Numero
                '        Case 2
                '            .NroPlano2 = .Planos(lngPos).Numero
                '        Case 3
                '            .NroPlano3 = .Planos(lngPos).Numero
                '    End Select
                '    lngPos = lngPos + 1
                'Next

            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function

    'Private Function PopulatePlanos(ByVal reader As MySqlDataReader) As Planos
    '    Dim obj As New Planos
    '    Try
    '        With obj
    '            .Id = Convert.ToUInt32(reader("Id"))
    '            .Idpieza = Convert.ToUInt32(reader("Idpieza"))
    '            .Numero = Convert.ToString(reader("Numero"))
    '            .Observacion = Convert.ToString(reader("Observacion"))
    '            .Ruta = Convert.ToString(reader("Ruta"))
    '            .Orden = Convert.ToUInt32(reader("Orden"))
    '        End With
    '        Return obj
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message, ex)
    '    Finally
    '        obj = Nothing
    '    End Try
    'End Function

    'Private Function PopulateFotos(ByVal reader As MySqlDataReader) As Fotos
    '    Dim obj As New Fotos
    '    Try
    '        With obj
    '            .Id = Convert.ToUInt32(reader("Id"))
    '            .Idpieza = Convert.ToUInt32(reader("Idpieza"))
    '            .Ruta = Convert.ToString(reader("Ruta"))
    '            .Orden = Convert.ToUInt32(reader("Orden"))
    '        End With
    '        Return obj
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message, ex)
    '    Finally
    '        obj = Nothing
    '    End Try
    'End Function

    Public Function SaveInventario(ByVal objList As List(Of Articulo), ByVal Usuario As Entidades.Personal) As UInt32

        Dim transaccion As MySqlTransaction = Nothing
        Dim id As UInteger

        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                transaccion = cnn.BeginTransaction

                Using cmd As New MySqlCommand
                    With cmd
                        .Transaction = transaccion
                        .Connection = cnn


                        .CommandType = CommandType.Text

                        .CommandText = "SELECT * FROM parametro WHERE nombre = @nombre"
                        .Parameters.Clear()
                        .Parameters.AddWithValue("@nombre", "NroInventario")

                        Using reader As MySqlDataReader = .ExecuteReader
                            Do While reader.Read
                                id = Convert.ToUInt32(reader("Valorpredeterminado")) + 1
                            Loop
                        End Using

                        .CommandText = "INSERT INTO Fichastock (Id,Origen,Cbteajuste,Fecha,Articulo,Cantidad,Sucursal,Usuario,ExistenciaActual,ExistenciaReal) VALUES (null,@Origen,@Cbteajuste,@Fecha,@Articulo,@Cantidad,@Sucursal,@Usuario,@ExistenciaActual,@ExistenciaReal)"

                        For Each obj As Entidades.Articulo In objList

                            If obj.ExistenciaDiferencia <> 0 Then
                                .Parameters.Clear()
                                .Parameters.AddWithValue("@Origen", "INVENTARIO")
                                .Parameters.AddWithValue("@Cbteajuste", id)
                                .Parameters.AddWithValue("@Fecha", Date.Today)
                                .Parameters.AddWithValue("@Articulo", obj.Codigo)
                                .Parameters.AddWithValue("@Cantidad", obj.ExistenciaDiferencia)
                                .Parameters.AddWithValue("@ExistenciaActual", obj.ExistenciaActual)
                                .Parameters.AddWithValue("@ExistenciaReal", obj.ExistenciaReal)
                                .Parameters.AddWithValue("@Sucursal", Usuario.Sucursal)
                                .Parameters.AddWithValue("@Usuario", Usuario.Id)
                                .ExecuteNonQuery()
                            End If

                        Next

                        .CommandText = "UPDATE parametro SET valorpredeterminado = @valor WHERE nombre = @nombre"
                        .Parameters.Clear()
                        .Parameters.AddWithValue("@nombre", "NroInventario")
                        .Parameters.AddWithValue("@valor", id)
                        .ExecuteNonQuery()

                    End With

                End Using

                transaccion.Commit()

            End Using

            Return id

        Catch exError As MySqlException

            If transaccion IsNot Nothing Then
                transaccion.Rollback()
            End If

            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Articulo", _
            "SaveInventario", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Public Sub UpdatePreciosArticulo(ByVal Id As UInt32, ByVal PrecioVenta As Double)

        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn

                        .CommandType = CommandType.Text

                        .CommandText = "UPDATE Articulos SET Preciodeventa = @Preciodeventa,Fechaultimacompra = @Fechaultimacompra WHERE Id = @Id"

                        .Parameters.Clear()
                        .Parameters.AddWithValue("@Id", Id)
                        .Parameters.AddWithValue("@Preciodeventa", PrecioVenta)
                        .Parameters.AddWithValue("@Fechaultimacompra", Now)
                        .ExecuteNonQuery()


                    End With

                End Using


            End Using

        Catch exError As MySqlException


            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Articulo", _
            "UpdatePrecios", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Sub
    Public Sub UpdatePreciosCliente(ByVal alicuota As Double, ByVal cliente As String)
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "UPDATE Articulos SET Preciodeventa = ((Preciodeventa)+(Preciodeventa * (@alicuota/100))),Fechaultimacompra = @Fechaultimacompra WHERE codcliente=@codcliente"

                        .Parameters.AddWithValue("@codcliente", cliente)
                        .Parameters.AddWithValue("@alicuota", alicuota)
                        .Parameters.AddWithValue("@Fechaultimacompra", Now)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Articulo", _
            "UpdatePreciosCliente", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Sub
    Public Sub UpdatePrecios(ByVal objList As List(Of Articulo), ByVal Usuario As Entidades.Personal)

        Dim transaccion As MySqlTransaction = Nothing

        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                transaccion = cnn.BeginTransaction

                Using cmd As New MySqlCommand
                    With cmd
                        .Transaction = transaccion
                        .Connection = cnn

                        .CommandType = CommandType.Text

                        .CommandText = "UPDATE Articulos SET Codigo = @Codigo,Nombre = @Nombre,Descripcion = @Descripcion,codRubro = @Rubro,"
                        .CommandText &= "CantidadBulto = @CantidadBulto,Descuentocompra1 = @Descuentocompra1,Descuentocompra2 = @Descuentocompra2,Descuentocompra3 = @Descuentocompra3,Descuentocompra4 = @Descuentocompra4,"
                        .CommandText &= "Alicuotaiva = @Alicuotaiva,Impinttasanominal = @Impinttasanominal,Preciodeventa = @Preciodeventa,"
                        .CommandText &= "Preciodecosto = @Preciodecosto,Activo = @Activo,codUnidad = @Unidad,codCategoria = @Categoria,"
                        .CommandText &= "Fechaultimacompra = @Fechaultimacompra,Preciodecompra = @Preciodecompra,Descuento = @Descuento,Descuento2 = @Descuento2,Descuento3 = @Descuento3,Puntominimo = @Puntominimo, "
                        .CommandText &= "Oferta = @Oferta,Preciodeventa2 = @Preciodeventa2, Preciodeventa3 = @Preciodeventa3, Preciosugerido = @Preciosugerido,Preciomodificable = @Preciomodificable, Impuestointerno = @Impuestointerno, nombrecorto = @nombrecorto WHERE Id = @Id"
                        
                        For Each obj As Entidades.Articulo In objList

                            .Parameters.Clear()
                            .Parameters.AddWithValue("@Id", obj.Id)
                            .Parameters.AddWithValue("@Codigo", obj.Codigo)
                            .Parameters.AddWithValue("@Nombre", obj.Nombre)
                            .Parameters.AddWithValue("@Descripcion", obj.Descripcion)
                            .Parameters.AddWithValue("@Rubro", obj.Codrubro)
                            .Parameters.AddWithValue("@Alicuotaiva", obj.Alicuotaiva)
                            .Parameters.AddWithValue("@Impinttasanominal", obj.Impinttasanominal)
                            .Parameters.AddWithValue("@Preciodeventa", obj.Preciodeventa)
                            .Parameters.AddWithValue("@Preciodecosto", obj.Preciodecosto)
                            .Parameters.AddWithValue("@Activo", obj.Activo)
                            .Parameters.AddWithValue("@Unidad", obj.Codunidad)
                            .Parameters.AddWithValue("@Categoria", obj.Codcategoria)
                            .Parameters.AddWithValue("@Fechaultimacompra", obj.Fechaultimacompra)
                            .Parameters.AddWithValue("@Preciodecompra", obj.Preciodecompra)
                            .Parameters.AddWithValue("@Descuento", obj.Descuento)
                            .Parameters.AddWithValue("@Descuento2", obj.Descuento2)
                            .Parameters.AddWithValue("@Descuento3", obj.Descuento3)
                            .Parameters.AddWithValue("@CantidadBulto", obj.CantidadBulto)
                            .Parameters.AddWithValue("@Descuentocompra1", obj.Descuentocompra1)
                            .Parameters.AddWithValue("@Descuentocompra2", obj.Descuentocompra2)
                            .Parameters.AddWithValue("@Descuentocompra3", obj.Descuentocompra3)
                            .Parameters.AddWithValue("@Descuentocompra4", obj.Descuentocompra4)

                            .Parameters.AddWithValue("@Puntominimo", obj.Puntominimo)
                            .Parameters.AddWithValue("@Oferta", obj.Oferta)
                            .Parameters.AddWithValue("@Preciodeventa2", obj.Preciodeventa2)
                            .Parameters.AddWithValue("@Preciodeventa3", obj.Preciodeventa3)
                            .Parameters.AddWithValue("@Preciosugerido", obj.Preciosugerido)
                            .Parameters.AddWithValue("@Preciomodificable", obj.Preciomodificable)
                            .Parameters.AddWithValue("@Impuestointerno", obj.Impuestointerno)
                            .Parameters.AddWithValue("@nombrecorto", obj.Nombrecorto)
                            .ExecuteNonQuery()


                        Next

                    End With

                End Using

                transaccion.Commit()

            End Using

        Catch exError As MySqlException

            If transaccion IsNot Nothing Then
                transaccion.Rollback()
            End If

            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Articulo", _
            "UpdatePrecios", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Sub

End Class

