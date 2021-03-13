Imports Entidades
Imports MySql.Data.MySqlClient
Public Class OrdencompradetCDat
    Private ExceptionClassObject As New ManejoDeErrores.ExceptionClass
    Private ExceptionErrorFileString As String = My.Application.Info.DirectoryPath & "\ErrorFile.log"
    Private WriteErrorMessageString As String
    Private ErrorMessageString As String
    Public Sub Insert(ByVal obj As OrdenCompradet)
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "INSERT INTO Ordencompradet (Id,Idordencompra,Articulo,Precio,Cantidad,Cantsaldo,Cantacum,Descarte,Despacho,Kgsxunidad,Kgs,Codunidad,Expedicion,Cbtevta) VALUES (@Id,@Idordencompra,@Articulo,@Precio,@Cantidad,@Cantsaldo,@Cantacum,@Descarte,@Despacho,@Kgsxunidad,@Kgs,@Codunidad,@Expedicion,@Cbtevta)"

                        .Parameters.AddWithValue("@Id", obj.Id)
                        .Parameters.AddWithValue("@Idordencompra", obj.IdordenCompra)
                        .Parameters.AddWithValue("@Articulo", obj.Articulo)
                        .Parameters.AddWithValue("@Precio", obj.Precio)
                        .Parameters.AddWithValue("@Cantidad", obj.Cantidad)
                        .Parameters.AddWithValue("@Cantsaldo", obj.Cantsaldo)
                        .Parameters.AddWithValue("@Cantacum", obj.Cantacum)
                        .Parameters.AddWithValue("@Descarte", obj.Descarte)
                        .Parameters.AddWithValue("@Despacho", obj.Despacho)
                        .Parameters.AddWithValue("@Kgsxunidad", obj.Kgsxunidad)
                        .Parameters.AddWithValue("@Kgs", obj.Kgs)
                        .Parameters.AddWithValue("@Codunidad", obj.Codunidad)
                        .Parameters.AddWithValue("@Expedicion", obj.Expedicion)
                        .Parameters.AddWithValue("@Cbtevta", obj.Cbtevta)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Ordencompradet", _
            "Insert", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Sub
    Public Sub Update(ByVal obj As OrdenCompradet)
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "UPDATE ordencompradet SET Idordencompra = @Idordencompra,Articulo = @Articulo,Precio = @Precio,Cantidad = @Cantidad,Cantsaldo = @Cantsaldo,Cantacum = @Cantacum,Descarte = @Descarte,Despacho = @Despacho,Kgsxunidad = @Kgsxunidad,Kgs = @Kgs,Codunidad = @Codunidad,Expedicion = @Expedicion,Cbtevta = @Cbtevta WHERE Id = @Id"
                        .Parameters.AddWithValue("@Id", obj.Id)
                        .Parameters.AddWithValue("@Idordencompra", obj.IdordenCompra)
                        .Parameters.AddWithValue("@Articulo", obj.Articulo)
                        .Parameters.AddWithValue("@Precio", obj.Precio)
                        .Parameters.AddWithValue("@Cantidad", obj.Cantidad)
                        .Parameters.AddWithValue("@Cantsaldo", obj.Cantsaldo)
                        .Parameters.AddWithValue("@Cantacum", obj.Cantacum)
                        .Parameters.AddWithValue("@Descarte", obj.Descarte)
                        .Parameters.AddWithValue("@Despacho", obj.Despacho)
                        .Parameters.AddWithValue("@Kgsxunidad", obj.Kgsxunidad)
                        .Parameters.AddWithValue("@Kgs", obj.Kgs)
                        .Parameters.AddWithValue("@Codunidad", obj.Codunidad)
                        .Parameters.AddWithValue("@Expedicion", obj.Expedicion)
                        .Parameters.AddWithValue("@Cbtevta", obj.Cbtevta)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Ordencompradet", _
            "Update", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Sub
    Public Sub UpdateOrdencompraDescarte(ByVal obj As List(Of OrdenCompradet))
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text

                        For Each objOrdencompraDescarte As Entidades.OrdenCompradet In obj
                            .CommandText = "UPDATE ordencompradet SET Cantacum = @Cantacum,Descarte = @Descarte,Despacho = @Despacho WHERE Id = @Id"
                            .Parameters.Clear()
                            .Parameters.AddWithValue("@Id", objOrdencompraDescarte.Id)
                            .Parameters.AddWithValue("@Cantacum", objOrdencompraDescarte.Cantacum + objOrdencompraDescarte.Lunes + objOrdencompraDescarte.Martes + objOrdencompraDescarte.Miercoles + objOrdencompraDescarte.Jueves + objOrdencompraDescarte.Viernes + objOrdencompraDescarte.Sabado)
                            .Parameters.AddWithValue("@Descarte", objOrdencompraDescarte.Descarte)
                            .Parameters.AddWithValue("@Despacho", objOrdencompraDescarte.Despacho)
                            .ExecuteNonQuery()
                        Next
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Ordencompradet", _
            "Update", _
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
                        .CommandText = "DELETE FROM ordencompradet WHERE Id = @Id"
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
    Public Function GetById(ByVal id As UInt32) As OrdenCompradet
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM ordencompradet WHERE Id= @Id"
                        .Parameters.AddWithValue("@Id", id)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Dim obj As New OrdenCompradet
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
            "Datos:Ordencompradet", _
            "GetById", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Public Function GetOrdencompraDescarte(ByVal Todos As Boolean, ByVal ClienteDesde As String, ByVal ClienteHasta As String) As List(Of OrdenCompradet)
        Try
            Dim lista As New List(Of OrdenCompradet)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT md.`id`,mc.`codcliente`,c.`nombre` NombreCliente,CONCAT(LPAD(CAST(mc.`numero` AS CHAR),8,'0'),'-',LPAD(CAST(mc.`secuencia` AS CHAR),2,'0')) NroPedido, "
                        .CommandText &= "md.`articulo` Articulo,md.`cantidad`,md.`cantacum`,md.`descarte`,md.`despacho` FROM ordencompracab mc LEFT JOIN ordencompradet md ON mc.id=md.idordencompra "
                        .CommandText &= "LEFT JOIN cliente c ON mc.codcliente=c.codigo LEFT JOIN articulos a ON md.articulo=a.codigo WHERE mc.`codcliente`>= @ClienteDesde AND mc.`codcliente`<= @ClienteHasta "

                        If Todos = False Then
                            .CommandText &= "AND (md.`cantidad`-md.`cantacum`)>0 "
                        End If

                        .CommandText &= "ORDER BY md.`id`"

                        .Parameters.AddWithValue("@ClienteDesde", ClienteDesde)
                        .Parameters.AddWithValue("@ClienteHasta", ClienteHasta)

                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New OrdenCompradet
                                    obj = PopulateOrdencompraDescarte(reader)
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
            "GetById", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Public Function GetAll() As List(Of OrdenCompradet)
        Try
            Dim lista As New List(Of OrdenCompradet)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM ordencompradet"
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New OrdenCompradet
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
            "Datos:Ordencompradet", _
            "GetAll", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Private Function Populate(ByVal reader As MySqlDataReader) As OrdenCompradet
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

            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function

    Private Function PopulateOrdencompraDescarte(ByVal reader As MySqlDataReader) As OrdenCompradet
        Dim obj As New OrdenCompradet
        Try
            With obj

                .Id = Convert.ToUInt32(reader("Id"))
                .codcliente = Convert.ToString(reader("codcliente"))
                .NombreCliente = Convert.ToString(reader("NombreCliente"))
                .NroPedido = Convert.ToString(reader("NroPedido"))
                .Articulo = Convert.ToString(reader("Articulo"))
                .Cantidad = Convert.ToDouble(reader("Cantidad"))
                .Cantacum = Convert.ToDouble(reader("Cantacum"))
                .Descarte = Convert.ToDouble(reader("Descarte"))
                .Despacho = Convert.ToDouble(reader("Despacho"))

            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function

End Class

