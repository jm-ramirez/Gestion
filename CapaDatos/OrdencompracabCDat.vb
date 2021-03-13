Imports Entidades
Imports MySql.Data.MySqlClient
Public Class OrdencompracabCDat
Private ExceptionClassObject As New ManejoDeErrores.ExceptionClass
Private ExceptionErrorFileString As String = My.Application.Info.DirectoryPath & "\ErrorFile.log"
Private WriteErrorMessageString As String
Private ErrorMessageString As String
    Public Function Insert(ByVal obj As Ordencompracab)
        Dim transaccion As MySqlTransaction = Nothing
        Dim id As Long

        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                transaccion = cnn.BeginTransaction
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .Transaction = transaccion
                        .CommandType = CommandType.Text

                        .CommandText = "INSERT INTO Ordencompracab (Id,Codcliente,Numero,Fecha,Observacion) VALUES (@Id,@Codcliente,@Numero,@Fecha,@Observacion)"
                        .Parameters.AddWithValue("@Id", obj.Id)
                        .Parameters.AddWithValue("@Codcliente", obj.Codcliente)
                        .Parameters.AddWithValue("@Numero", obj.Numero)
                        '.Parameters.AddWithValue("@Secuencia", obj.Secuencia)
                        .Parameters.AddWithValue("@Fecha", obj.Fecha)
                        .Parameters.AddWithValue("@Observacion", obj.Observacion)
                        .ExecuteNonQuery()
                        id = .LastInsertedId

                        For Each objOrdencompradet As Entidades.Ordencompradet In obj.Ordencompradet
                            .CommandText = "INSERT INTO Ordencompradet (Id,idordencompra,Articulo,Precio,Cantidad,Cantsaldo,Cantacum,Descarte,Despacho,Kgsxunidad,Kgs,Codunidad,Expedicion,Cbtevta) VALUES (null,@idordencompra,@Articulo,@Precio,@Cantidad,@Cantsaldo,@Cantacum,@Descarte,@Despacho,@Kgsxunidad,@Kgs,@Codunidad,@Expedicion,@Cbtevta)"
                            .Parameters.Clear()
                            .Parameters.AddWithValue("@idordencompra", id)
                            .Parameters.AddWithValue("@Articulo", objOrdencompradet.Articulo)
                            .Parameters.AddWithValue("@Precio", objOrdencompradet.Precio)
                            .Parameters.AddWithValue("@Cantidad", objOrdencompradet.Cantidad)
                            .Parameters.AddWithValue("@Cantsaldo", objOrdencompradet.Cantsaldo)
                            .Parameters.AddWithValue("@Cantacum", objOrdencompradet.Cantacum)
                            .Parameters.AddWithValue("@Descarte", objOrdencompradet.Descarte)
                            .Parameters.AddWithValue("@Despacho", objOrdencompradet.Despacho)
                            .Parameters.AddWithValue("@Kgsxunidad", objOrdencompradet.Kgsxunidad)
                            .Parameters.AddWithValue("@Kgs", objOrdencompradet.Kgs)
                            .Parameters.AddWithValue("@Codunidad", objOrdencompradet.Codunidad)
                            .Parameters.AddWithValue("@Expedicion", objOrdencompradet.Expedicion)
                            .Parameters.AddWithValue("@Cbtevta", objOrdencompradet.Cbtevta)
                            .ExecuteNonQuery()

                            .CommandText = "UPDATE articulos SET preciodeventa = @Precio WHERE codigo=@Articulo "
                            .ExecuteNonQuery()
                        Next
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
            "Datos:Ordencompracab", _
            "Insert", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Public Sub DeleteOrdencompradet(ByVal id As UInt32)
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "DELETE FROM Ordencompradet WHERE Idordencompra = @Id"
                        .Parameters.AddWithValue("@Id", id)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Ordencompradet", _
            "Delete", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Sub
    Public Sub Update(ByVal obj As OrdenCompracab)
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

                        .CommandText = "DELETE FROM ordencompradet WHERE idordencompra = @Id"
                        .Parameters.AddWithValue("@Id", obj.Id)
                        .ExecuteNonQuery()

                        For Each objOrdenCompradet As Entidades.OrdenCompradet In obj.OrdenCompradet

                            .CommandText = "INSERT INTO Ordencompradet "
                            .CommandText &= " (Id,idordencompra,Articulo,Precio,Cantidad,Cantsaldo,Cantacum,Descarte,Despacho,Kgsxunidad,Kgs,Codunidad,Expedicion,Cbtevta) "
                            .CommandText &= " VALUES "
                            .CommandText &= " (null,@idordencompra,@Articulo,@Precio,@Cantidad,@Cantsaldo,@Cantacum,@Descarte,@Despacho,@Kgsxunidad,@Kgs,@Codunidad,@Expedicion,@Cbtevta) "
                            '.CommandText &= " ON DUPLICATE KEY UPDATE "
                            '.CommandText &= " Precio=@Precio,Cantidad=@Cantidad,Kgs=@Kgs "
                            .Parameters.Clear()
                            '.Parameters.AddWithValue("@id", objOrdenCompradet.Id)
                            .Parameters.AddWithValue("@idordencompra", obj.Id)
                            .Parameters.AddWithValue("@Articulo", objOrdenCompradet.Articulo)
                            .Parameters.AddWithValue("@Precio", objOrdenCompradet.Precio)
                            .Parameters.AddWithValue("@Cantidad", objOrdenCompradet.Cantidad)
                            .Parameters.AddWithValue("@Cantsaldo", objOrdenCompradet.Cantsaldo)
                            .Parameters.AddWithValue("@Cantacum", objOrdenCompradet.Cantacum)
                            .Parameters.AddWithValue("@Descarte", objOrdenCompradet.Descarte)
                            .Parameters.AddWithValue("@Despacho", objOrdenCompradet.Despacho)
                            .Parameters.AddWithValue("@Kgsxunidad", objOrdenCompradet.Kgsxunidad)
                            .Parameters.AddWithValue("@Kgs", objOrdenCompradet.Kgs)
                            .Parameters.AddWithValue("@Codunidad", objOrdenCompradet.Codunidad)
                            .Parameters.AddWithValue("@Expedicion", objOrdenCompradet.Expedicion)
                            .Parameters.AddWithValue("@Cbtevta", objOrdenCompradet.Cbtevta)
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
            "Datos:Ordencompracab", _
            "Update", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Sub
    Public Function GetByUltimoNroCbte(ByVal Param As String) As UInt32
        Dim id As UInt32
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT valorpredeterminado FROM Parametro WHERE nombre= @Param"
                        .Parameters.AddWithValue("@Param", Param)

                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                id = reader("valorpredeterminado")

                                Return id
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
            "Datos:Cbtenumeracion", _
            "GetById", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Public Sub UpdateExpedicion(ByVal fDesde As Date, ByVal fHasta As Date, ByVal cDesde As String, ByVal cHasta As String)
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "UPDATE ordencompracab mc LEFT JOIN ordencompradet md ON mc.id=md.idordencompra SET md.expedicion = 1 WHERE mc.`Fecha`>=@fDesde AND mc.`Fecha`<=@fHasta "
                        .CommandText &= "AND mc.`codcliente`>=@cDesde AND mc.`codcliente`<=@cHasta AND md.`expedicion`=0"
                        .Parameters.AddWithValue("@fDesde", fDesde)
                        .Parameters.AddWithValue("@fHasta", fHasta)
                        .Parameters.AddWithValue("@cDesde", cDesde)
                        .Parameters.AddWithValue("@cHasta", cHasta)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Ordencompradet", _
            "UpdateExpedicion", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Sub
    Public Sub ReinicioExpedicion(ByVal fDesde As Date, ByVal fHasta As Date)
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "UPDATE ordencompracab mc LEFT JOIN ordencompradet md ON mc.id=md.idordencompra SET md.expedicion = 0 WHERE mc.`Fecha`>=@fDesde AND mc.`Fecha`<=@fHasta"
                        .Parameters.AddWithValue("@fDesde", fDesde)
                        .Parameters.AddWithValue("@fHasta", fHasta)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Ordencompradet", _
            "UpdateExpedicion", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Sub
    Public Function GetValidarOrdenCompra(ByVal Numero As Integer) As Boolean
        Dim Valida As Boolean
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM ordencompracab WHERE Numero=@Numero"
                        .Parameters.AddWithValue("@Numero", Numero)

                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Valida = True
                            Else
                                Valida = False
                            End If
                        End Using
                    End With
                End Using
                Return Valida
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cbtenumeracion", _
            "GetById", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
Public Sub Delete(ByVal id As UInt32)
    Try
        Using cnn As MySqlConnection = CreateConnection()
            cnn.Open()
            Using cmd As New MySqlCommand
                With cmd
                    .Connection = cnn
                    .CommandType = CommandType.Text
                        .CommandText = "DELETE FROM ordencompracab WHERE Id = @Id"
                    .Parameters.AddWithValue("@Id", id)
                    .ExecuteNonQuery()
                End With
            End Using
        End Using
    Catch exError As MySqlException
        ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:ordencompracab", _
            "Delete", _
            ErrorMessageString, _
            WriteErrorMessageString)
        Throw New Exception(ErrorMessageString)
    End Try
End Sub
    Public Function GetById(ByVal id As UInt32) As OrdenCompracab
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT mc.*,c.nombre,c.domicilio DomicilioCliente,l.codigopostal CodpostalCliente,l.nombre LocalidadCliente,c.telefono TelefonoCliente,c.documento CuitCliente "
                        .CommandText &= "FROM ordencompracab mc LEFT JOIN cliente c ON mc.codcliente=c.codigo LEFT JOIN localidad l ON c.localidad=l.id WHERE mc.Id= @Id"
                        .Parameters.AddWithValue("@Id", id)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Dim obj As New OrdenCompracab
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
            "Datos:Ordencompracab", _
            "GetById", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Public Function GetByNroOrden(ByVal Cliente As String, ByVal Articulo As String) As List(Of OrdenCompracab)
        Try
            Dim lista As New List(Of OrdenCompracab)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT mc.id,mc.`numero` FROM ordencompracab mc LEFT JOIN ordencompradet md ON mc.id=md.idordencompra "
                        .CommandText &= "WHERE mc.codcliente=@Cliente AND md.articulo=@Articulo AND (md.`cantidad`-md.`despacho`)> 0 "
                        .CommandText &= "UNION ALL SELECT 0 as id, 0 as numero ORDER BY id"
                        .Parameters.AddWithValue("@Cliente", Cliente)
                        .Parameters.AddWithValue("@Articulo", Articulo)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New OrdenCompracab
                                    obj = PopulateNroOrden(reader)
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
            "Datos:Ordencompracab", _
            "GetAll", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Public Function GetByArticulosPendientes(ByVal Cliente As String, ByVal Articulo As String) As List(Of OrdenCompracab)
        Try
            Dim lista As New List(Of OrdenCompracab)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT mc.id,mc.`numero`,(md.`cantidad`-md.`despacho`) Cantidad FROM ordencompracab mc LEFT JOIN ordencompradet md ON mc.id=md.idordencompra "
                        .CommandText &= "WHERE mc.codcliente=@Cliente AND md.articulo=@Articulo AND (md.`cantidad`-md.`despacho`)> 0 ORDER BY id"
                        .Parameters.AddWithValue("@cliente", Cliente)
                        .Parameters.AddWithValue("@Articulo", Articulo)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New OrdenCompracab
                                    obj = PopulateArticulosPendientes(reader)
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
            "Datos:Ordencompracab", _
            "GetAll", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Public Function GetByCantDespacho(ByVal cliente As String, ByVal Numero As Integer, ByVal Articulo As String) As Double
        Dim id As Double
        id = 0
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT (md.`cantidad`-md.`despacho`) Cantidad FROM ordencompracab mc LEFT JOIN ordencompradet md ON mc.id=md.idordencompra "
                        .CommandText &= "WHERE mc.codcliente=@cliente AND mc.`numero`=@Numero AND md.articulo=@Articulo"
                        .Parameters.AddWithValue("@Numero", Numero)
                        '.Parameters.AddWithValue("@Secuencia", Secuencia)
                        .Parameters.AddWithValue("@Articulo", Articulo)
                        .Parameters.AddWithValue("@Cliente", cliente)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                id = reader("Cantidad")

                                Return id
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
            "Datos:Cbtenumeracion", _
            "GetById", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Public Function GetByNumero(ByVal Id As Integer) As List(Of OrdenCompracab)
        Try
            Dim lista As New List(Of OrdenCompracab)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT id,numero FROM ordencompracab WHERE id=@Id"
                        .Parameters.AddWithValue("@Id", Id)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New OrdenCompracab
                                    obj = PopulateNroOrden(reader)
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
            "Datos:ordencompracab", _
            "GetAll", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Public Function GetAll() As List(Of OrdenCompracab)
        Try
            Dim lista As New List(Of OrdenCompracab)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT mc.*,c.nombre,c.domicilio DomicilioCliente,l.codigopostal CodpostalCliente,l.nombre LocalidadCliente,c.telefono TelefonoCliente,c.documento CuitCliente "
                        .CommandText &= "FROM ordencompracab mc LEFT JOIN cliente c ON mc.codcliente=c.codigo LEFT JOIN localidad l ON c.localidad=l.id ORDER BY mc.`numero`"
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New OrdenCompracab
                                    obj = populate(reader)
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
            "Datos:Ordencompracab", _
            "GetAll", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    
    Public Function GetOrdencompraDetalle(ByVal idOrdencompra As Integer) As List(Of OrdenCompradet)
        Try
            'For Each objSemProd As Entidades.Semana_Producto In obj.Productos
            Dim lista As New List(Of OrdenCompradet)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT md.*,a.nombre NombreArticulo,IF(a.`codunidad`='01',(md.`kgs`*md.`precio`),(md.`cantidad`*md.`precio`)) as Subtotal "
                        .CommandText &= "FROM ordencompradet md LEFT JOIN articulos a ON md.articulo=a.codigo WHERE md.idordencompra=@idOrdencompra"
                        .Parameters.AddWithValue("@idOrdencompra", idOrdencompra)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New OrdenCompradet
                                    obj = Populate_OrdencompraDet(reader)
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
            "Datos:Ordencompradet", _
            "GetOrdencompraDetalle", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Private Function Populate(ByVal reader As MySqlDataReader) As OrdenCompracab
        Dim obj As New OrdenCompracab
        Try
            With obj

                .Id = Convert.ToUInt32(reader("Id"))
                .Codcliente = Convert.ToString(reader("Codcliente"))
                .Numero = Convert.ToUInt32(reader("Numero"))
                '.Secuencia = Convert.ToUInt32(reader("Secuencia"))
                .Fecha = Convert.ToDateTime(reader("Fecha"))
                .Observacion = Convert.ToString(reader("Observacion"))
                .NombreCliente = Convert.ToString(reader("nombre"))
                .DomicilioCliente = Convert.ToString(reader("DomicilioCliente"))
                .CodpostalCliente = Convert.ToString(reader("CodpostalCliente"))
                .LocalidadCliente = Convert.ToString(reader("LocalidadCliente"))
                .TelefonoCliente = Convert.ToString(reader("TelefonoCliente"))
                .CuitCliente = Convert.ToString(reader("CuitCliente"))

            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function
    Private Function Populate_OrdencompraDet(ByVal reader As MySqlDataReader) As OrdenCompradet
        Dim obj As New OrdenCompradet
        Try
            With obj
                .Id = Convert.ToUInt32(reader("Id"))
                .IdordenCompra = Convert.ToUInt32(reader("Idordencompra"))
                .Articulo = Convert.ToString(reader("Articulo"))
                .Precio = Convert.ToDouble(reader("Precio"))
                .Cantidad = Convert.ToDouble(reader("Cantidad"))
                .Cantsaldo = Convert.ToDouble(reader("Cantsaldo"))
                .Cantacum = Convert.ToDouble(reader("Cantacum"))
                .Descarte = Convert.ToDouble(reader("Descarte"))
                .Despacho = Convert.ToDouble(reader("Despacho"))
                .Kgsxunidad = Convert.ToDouble(reader("Kgsxunidad"))
                .Kgs = Convert.ToDouble(reader("Kgs"))
                .Codunidad = Convert.ToString(reader("Codunidad"))
                .Expedicion = Convert.ToBoolean(reader("Expedicion"))
                .Cbtevta = Convert.ToUInt32(reader("Cbtevta"))
                .NombreArticulo = Convert.ToString(reader("NombreArticulo"))
                .Subtotal = Convert.ToDouble(reader("Subtotal"))
            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function
    Private Function PopulateNroOrden(ByVal reader As MySqlDataReader) As OrdenCompracab
        Dim obj As New OrdenCompracab
        Try
            With obj
                .Id = Convert.ToUInt32(reader("Id"))
                .Numero = Convert.ToUInt32(reader("Numero"))
                '.Secuencia = Convert.ToUInt32(reader("Secuencia"))
            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function

    Private Function PopulateArticulosPendientes(ByVal reader As MySqlDataReader) As OrdenCompracab
        Dim obj As New OrdenCompracab
        Try
            With obj
                .Id = Convert.ToUInt32(reader("Id"))
                .Numero = Convert.ToUInt32(reader("Numero"))
                '.Secuencia = Convert.ToUInt32(reader("Secuencia"))
                .Cantidad = Convert.ToDouble(reader("Cantidad"))
            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function
End Class

