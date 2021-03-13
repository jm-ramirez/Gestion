Imports Entidades
Imports MySql.Data.MySqlClient
Public Class ProveedorCDat
    Private ExceptionClassObject As New ManejoDeErrores.ExceptionClass
    Private ExceptionErrorFileString As String = My.Application.Info.DirectoryPath & "\ErrorFile.log"
    Private WriteErrorMessageString As String
    Private ErrorMessageString As String
    Public Function Insert(ByVal obj As Proveedor) As UInt32
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd

                        'ingresosbrutosalic,conveniomultilateral,ganancias,rubrogcia
                        '@ingresosbrutosalic,@conveniomultilateral,@ganancias,@rubrogcia

                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "INSERT INTO Proveedor (Id,Codigo,Nombre,Domicilio,Telefono,Email,Tipodocumento,"
                        .CommandText &= " Documento,Activo,Tiporesponsable,Observacion,Localidad,Provincia,Fechaultimacompra,"
                        .CommandText &= " Diasctacte,Retivaalic,Ingresosbrutosnro,ingresosbrutosalic,conveniomultilateral,"
                        .CommandText &= " ganancias,rubrogcia) VALUES (@Id,@Codigo,@Nombre,@Domicilio,@Telefono,@Email,@Tipodocumento,@Documento,"
                        .CommandText &= " @Activo,@Tiporesponsable,@Observacion,@Localidad,@Provincia,@Fechaultimacompra,@Diasctacte,"
                        .CommandText &= " @Retivaalic,@Ingresosbrutosnro,@ingresosbrutosalic,@conveniomultilateral,@ganancias,@rubrogcia)"
                        .Parameters.AddWithValue("@Id", obj.Id)
                        .Parameters.AddWithValue("@Codigo", obj.Codigo)
                        .Parameters.AddWithValue("@Nombre", obj.Nombre)
                        .Parameters.AddWithValue("@Domicilio", obj.Domicilio)
                        .Parameters.AddWithValue("@Telefono", obj.Telefono)
                        .Parameters.AddWithValue("@Email", obj.Email)
                        .Parameters.AddWithValue("@Tipodocumento", obj.Tipodocumento)
                        .Parameters.AddWithValue("@Documento", obj.Documento)
                        .Parameters.AddWithValue("@Activo", obj.Activo)
                        .Parameters.AddWithValue("@Tiporesponsable", obj.Tiporesponsable)
                        .Parameters.AddWithValue("@Observacion", obj.Observacion)
                        .Parameters.AddWithValue("@Localidad", obj.Localidad)
                        .Parameters.AddWithValue("@Provincia", obj.Provincia)
                        .Parameters.AddWithValue("@Fechaultimacompra", obj.Fechaultimacompra)
                        .Parameters.AddWithValue("@Diasctacte", obj.Diasctacte)
                        .Parameters.AddWithValue("@Ingresosbrutosnro", obj.Ingresosbrutosnro)
                        .Parameters.AddWithValue("@ingresosbrutosalic", obj.ingresosbrutosalic)
                        .Parameters.AddWithValue("@conveniomultilateral", obj.conveniomultilateral)
                        .Parameters.AddWithValue("@ganancias", obj.Ganancias)
                        .Parameters.AddWithValue("@rubrogcia", obj.Rubrogcia)
                        .Parameters.AddWithValue("@Retivaalic", obj.Retivaalic)
                        .ExecuteNonQuery()
                        Return .LastInsertedId
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Proveedor", _
            "Insert", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Public Sub Update(ByVal obj As Proveedor)
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "UPDATE Proveedor SET Codigo = @Codigo,Nombre = @Nombre,Domicilio = @Domicilio,Telefono = @Telefono,Email = @Email,"
                        .CommandText &= " Tipodocumento = @Tipodocumento,Documento = @Documento,Activo = @Activo,"
                        .CommandText &= " Tiporesponsable = @Tiporesponsable,Observacion = @Observacion,Localidad = @Localidad,"
                        .CommandText &= " Provincia = @Provincia,Fechaultimacompra = @Fechaultimacompra,Diasctacte = @Diasctacte,"
                        .CommandText &= " Retivaalic = @Retivaalic,"
                        .CommandText &= " Ingresosbrutosnro = @Ingresosbrutosnro,"

                        .CommandText &= " Ingresosbrutosalic = @Ingresosbrutosalic,"
                        .CommandText &= " Conveniomultilateral = @Conveniomultilateral,"
                        .CommandText &= " ganancias = @ganancias,"
                        .CommandText &= " rubrogcia = @rubrogcia"

                        .CommandText &= " WHERE Id = @Id"

                        .Parameters.AddWithValue("@Id", obj.Id)
                        .Parameters.AddWithValue("@Codigo", obj.Codigo)
                        .Parameters.AddWithValue("@Nombre", obj.Nombre)
                        .Parameters.AddWithValue("@Domicilio", obj.Domicilio)
                        .Parameters.AddWithValue("@Telefono", obj.Telefono)
                        .Parameters.AddWithValue("@Email", obj.Email)
                        .Parameters.AddWithValue("@Tipodocumento", obj.Tipodocumento)
                        .Parameters.AddWithValue("@Documento", obj.Documento)
                        .Parameters.AddWithValue("@Activo", obj.Activo)
                        .Parameters.AddWithValue("@Tiporesponsable", obj.Tiporesponsable)
                        .Parameters.AddWithValue("@Observacion", obj.Observacion)
                        .Parameters.AddWithValue("@Localidad", obj.Localidad)
                        .Parameters.AddWithValue("@Provincia", obj.Provincia)
                        .Parameters.AddWithValue("@Fechaultimacompra", obj.Fechaultimacompra)
                        .Parameters.AddWithValue("@Diasctacte", obj.Diasctacte)
                        .Parameters.AddWithValue("@Ingresosbrutosnro", obj.Ingresosbrutosnro)
                        .Parameters.AddWithValue("@ingresosbrutosalic", obj.Ingresosbrutosalic)
                        .Parameters.AddWithValue("@conveniomultilateral", obj.Conveniomultilateral)
                        .Parameters.AddWithValue("@ganancias", obj.Ganancias)
                        .Parameters.AddWithValue("@rubrogcia", obj.Rubrogcia)
                        .Parameters.AddWithValue("@Retivaalic", obj.Retivaalic)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Proveedor", _
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
                        .CommandText = "DELETE FROM Proveedor WHERE Id = @Id"
                        .Parameters.AddWithValue("@Id", id)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Proveedor", _
            "Delete", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Sub
    Public Function GetById(ByVal id As UInt32) As Proveedor
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Proveedor WHERE Id= @Id"
                        .Parameters.AddWithValue("@Id", id)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Dim obj As New Proveedor
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
            "Datos:Proveedor", _
            "GetById", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetByCodigo(ByVal codigo As String) As Proveedor
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Proveedor WHERE codigo= @Codigo"
                        .Parameters.AddWithValue("@Codigo", codigo)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Dim obj As New Proveedor
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
            "Datos:Proveedor", _
            "GetByCodigo", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetByDocumento(ByVal tipo As UInt32, ByVal documento As String) As Proveedor
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Proveedor WHERE Tipodocumento = @tipo AND Documento = @documento"
                        .Parameters.AddWithValue("@tipo", tipo)
                        .Parameters.AddWithValue("@documento", documento)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Dim obj As New Proveedor
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
            "Datos:Proveedor", _
            "GetByDocumento", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetAll() As List(Of Proveedor)
        Try
            Dim lista As New List(Of Proveedor)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Proveedor"
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New Proveedor
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
            "Datos:Proveedor", _
            "GetAll", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetAllOrderByNombre(Optional ByVal soloActivos As Boolean = False) As List(Of Proveedor)
        Try
            Dim lista As New List(Of Proveedor)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Proveedor "

                        If soloActivos Then
                            .CommandText &= " WHERE Activo=1 "
                        End If

                        .CommandText &= " ORDER BY nombre"
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New Proveedor
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
            "Datos:Proveedor", _
            "GetAllOrderByNombre", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Private Function Populate(ByVal reader As MySqlDataReader) As Proveedor
        Dim obj As New Proveedor
        Try
            With obj
                .Id = Convert.ToUInt32(reader("Id"))
                .Codigo = Convert.ToString(reader("Codigo"))
                .Nombre = Convert.ToString(reader("Nombre"))
                .Domicilio = Convert.ToString(reader("Domicilio"))
                .Telefono = Convert.ToString(reader("Telefono"))
                .Email = Convert.ToString(reader("Email"))
                .Tipodocumento = Convert.ToUInt32(reader("Tipodocumento"))
                .Documento = Convert.ToString(reader("Documento"))
                .Activo = Convert.ToBoolean(reader("Activo"))
                .Tiporesponsable = Convert.ToUInt32(reader("Tiporesponsable"))
                .Observacion = Convert.ToString(reader("Observacion"))
                .Localidad = Convert.ToUInt32(reader("Localidad"))
                .Provincia = Convert.ToUInt32(reader("Provincia"))
                .Fechaultimacompra = Convert.ToDateTime(reader("Fechaultimacompra"))
                .Diasctacte = Convert.ToUInt32(reader("Diasctacte"))
                .Ingresosbrutosnro = Convert.ToString(reader("Ingresosbrutosnro"))
                .Ingresosbrutosalic = Convert.ToDouble(reader("ingresosbrutosalic"))
                .Conveniomultilateral = Convert.ToBoolean(reader("conveniomultilateral"))
                .Ganancias = Convert.ToChar(reader("ganancias"))
                .Rubrogcia = Convert.ToUInt32(reader("Rubrogcia"))
                .Retivaalic = Convert.ToDouble(reader("Retivaalic"))

            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function
End Class

