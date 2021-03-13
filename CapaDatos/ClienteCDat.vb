Imports Entidades
Imports MySql.Data.MySqlClient
Public Class ClienteCDat
    Private ExceptionClassObject As New ManejoDeErrores.ExceptionClass
    Private ExceptionErrorFileString As String = My.Application.Info.DirectoryPath & "\ErrorFile.log"
    Private WriteErrorMessageString As String
    Private ErrorMessageString As String
    Public Function Insert(ByVal obj As Cliente) As UInt32
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "INSERT INTO Cliente (Id,Codigo,Nombre,Domicilio,Telefono,Email,Email2,Email3,Tipodocumento,Documento,"
                        .CommandText &= " Activo,Tiporesponsable,Observacion,Localidad,Provincia,FormadePago,Zona,Vendedor,Fechaultimacompra,"
                        .CommandText &= " Listadeprecio,Diasctacte,Ingresosbrutosnro,Limitecredito,Descuento,Interesmora,Codigoingresosbrutos,Ingresosbrutosalic,Contacto) VALUES (@Id,@Codigo,@Nombre,@Domicilio,"
                        .CommandText &= " @Telefono,@Email,@Email2,@Email3,@Tipodocumento,@Documento,@Activo,@Tiporesponsable,@Observacion,"
                        .CommandText &= " @Localidad,@Provincia,@FormadePago,@Zona,@Vendedor,@Fechaultimacompra,@Listadeprecio,"
                        .CommandText &= " @Diasctacte,@Ingresosbrutosnro,@Limitecredito,@Descuento,@Interesmora,@Codigoingresosbrutos,@Ingresosbrutosalic,@Contacto)"

                        .Parameters.AddWithValue("@Id", obj.Id)
                        .Parameters.AddWithValue("@Codigo", obj.Codigo)
                        .Parameters.AddWithValue("@Nombre", obj.Nombre)
                        .Parameters.AddWithValue("@Domicilio", obj.Domicilio)
                        .Parameters.AddWithValue("@Telefono", obj.Telefono)
                        .Parameters.AddWithValue("@Email", obj.Email)
                        .Parameters.AddWithValue("@Email2", obj.Email2)
                        .Parameters.AddWithValue("@Email3", obj.Email3)
                        .Parameters.AddWithValue("@Tipodocumento", obj.Tipodocumento)
                        .Parameters.AddWithValue("@Documento", obj.Documento)
                        .Parameters.AddWithValue("@Activo", obj.Activo)
                        .Parameters.AddWithValue("@Tiporesponsable", obj.Tiporesponsable)
                        .Parameters.AddWithValue("@Observacion", obj.Observacion)
                        .Parameters.AddWithValue("@Localidad", obj.Localidad)
                        .Parameters.AddWithValue("@Provincia", obj.Provincia)
                        .Parameters.AddWithValue("@Zona", obj.Zona)
                        .Parameters.AddWithValue("@FormadePago", obj.FormadePago)
                        .Parameters.AddWithValue("@Vendedor", obj.Vendedor)
                        .Parameters.AddWithValue("@Fechaultimacompra", obj.Fechaultimacompra)
                        .Parameters.AddWithValue("@Listadeprecio", obj.Listadeprecio)
                        .Parameters.AddWithValue("@Diasctacte", obj.Diasctacte)
                        .Parameters.AddWithValue("@Ingresosbrutosnro", obj.Ingresosbrutosnro)
                        .Parameters.AddWithValue("@Limitecredito", obj.Limitecredito)
                        .Parameters.AddWithValue("@Descuento", obj.Descuento)
                        .Parameters.AddWithValue("@Interesmora", obj.Interesmora)
                        .Parameters.AddWithValue("@Codigoingresosbrutos", obj.Codigoingresosbrutos)
                        .Parameters.AddWithValue("@Ingresosbrutosalic", obj.Ingresosbrutosalic)
                        .Parameters.AddWithValue("@Contacto", obj.Contacto)

                        .ExecuteNonQuery()
                        Return .LastInsertedId
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cliente", _
            "Insert", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Public Sub Update(ByVal obj As Cliente)
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "UPDATE Cliente SET Codigo = @Codigo,Nombre = @Nombre,Domicilio = @Domicilio,Telefono = @Telefono,Email = @Email,Email2 = @Email2,Email3 = @Email3,"
                        .CommandText &= " Tipodocumento = @Tipodocumento,Documento = @Documento,Activo = @Activo,"
                        .CommandText &= " Tiporesponsable = @Tiporesponsable,Observacion = @Observacion,Localidad = @Localidad,"
                        .CommandText &= " Provincia = @Provincia,FormadePago = @FormadePago,Zona = @Zona,Vendedor = @Vendedor,Fechaultimacompra = @Fechaultimacompra,"
                        .CommandText &= " Listadeprecio = @Listadeprecio,Diasctacte = @Diasctacte,"
                        .CommandText &= " Ingresosbrutosnro = @Ingresosbrutosnro,"
                        .CommandText &= " Limitecredito = @Limitecredito,"
                        .CommandText &= " Descuento = @Descuento,Interesmora = @Interesmora,"
                        .CommandText &= " Codigoingresosbrutos = @Codigoingresosbrutos,"
                        .CommandText &= " Ingresosbrutosalic = @Ingresosbrutosalic, Contacto=@Contacto "
                        .CommandText &= " WHERE Id = @Id"

                        .Parameters.AddWithValue("@Id", obj.Id)
                        .Parameters.AddWithValue("@Codigo", obj.Codigo)
                        .Parameters.AddWithValue("@Nombre", obj.Nombre)
                        .Parameters.AddWithValue("@Domicilio", obj.Domicilio)
                        .Parameters.AddWithValue("@Telefono", obj.Telefono)
                        .Parameters.AddWithValue("@Email", obj.Email)
                        .Parameters.AddWithValue("@Email2", obj.Email2)
                        .Parameters.AddWithValue("@Email3", obj.Email3)
                        .Parameters.AddWithValue("@Tipodocumento", obj.Tipodocumento)
                        .Parameters.AddWithValue("@Documento", obj.Documento)
                        .Parameters.AddWithValue("@Activo", obj.Activo)
                        .Parameters.AddWithValue("@Tiporesponsable", obj.Tiporesponsable)
                        .Parameters.AddWithValue("@Observacion", obj.Observacion)
                        .Parameters.AddWithValue("@Localidad", obj.Localidad)
                        .Parameters.AddWithValue("@Provincia", obj.Provincia)
                        .Parameters.AddWithValue("@FormadePago", obj.FormadePago)
                        .Parameters.AddWithValue("@Zona", obj.Zona)
                        .Parameters.AddWithValue("@Vendedor", obj.Vendedor)
                        .Parameters.AddWithValue("@Fechaultimacompra", obj.Fechaultimacompra)
                        .Parameters.AddWithValue("@Listadeprecio", obj.Listadeprecio)
                        .Parameters.AddWithValue("@Diasctacte", obj.Diasctacte)
                        .Parameters.AddWithValue("@Ingresosbrutosnro", obj.Ingresosbrutosnro)
                        .Parameters.AddWithValue("@Limitecredito", obj.Limitecredito)
                        .Parameters.AddWithValue("@Descuento", obj.Descuento)
                        .Parameters.AddWithValue("@Interesmora", obj.Interesmora)
                        .Parameters.AddWithValue("@Codigoingresosbrutos", obj.Codigoingresosbrutos)
                        .Parameters.AddWithValue("@Ingresosbrutosalic", obj.Ingresosbrutosalic)
                        .Parameters.AddWithValue("@Contacto", obj.Contacto)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cliente", _
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
                        .CommandText = "DELETE FROM Cliente WHERE Id = @Id"
                        .Parameters.AddWithValue("@Id", id)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cliente", _
            "Delete", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Sub
    Public Function GetById(ByVal id As UInt32) As Cliente
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT c.*,l.`codigopostal` CodigoPostal,l.`nombre` NombreLocalidad, t.`Descripcion` DescripcionIva FROM Cliente c LEFT JOIN `localidad` l ON c.`localidad`=l.`id` LEFT JOIN tiporesponsable t ON c.`tiporesponsable`=t.`Codigo` WHERE c.Id= @Id"
                        .Parameters.AddWithValue("@Id", id)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Dim obj As New Cliente
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
            "Datos:Cliente", _
            "GetById", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Public Function GetByCodigo(ByVal id As String) As Cliente
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT c.*,l.`codigopostal` CodigoPostal,l.`nombre` NombreLocalidad, t.`Descripcion` DescripcionIva FROM Cliente c LEFT JOIN `localidad` l ON c.`localidad`=l.`id` LEFT JOIN tiporesponsable t ON c.`tiporesponsable`=t.`Codigo` WHERE c.Codigo= @Id"
                        .Parameters.AddWithValue("@Id", id)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Dim obj As New Cliente
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
            "Datos:Cliente", _
            "GetById", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Public Function GetAll() As List(Of Cliente)
        Try
            Dim lista As New List(Of Cliente)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT c.*,l.`codigopostal` CodigoPostal,l.`nombre` NombreLocalidad, t.`Descripcion` DescripcionIva FROM Cliente c LEFT JOIN `localidad` l ON c.`localidad`=l.`id` LEFT JOIN tiporesponsable t ON c.`tiporesponsable`=t.`Codigo`"
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New Cliente
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
            "Datos:Cliente", _
            "GetAll", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetAllOrderByNombre(Optional ByVal soloActivos As Boolean = False) As List(Of Cliente)
        Try
            Dim lista As New List(Of Cliente)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT c.*,l.`codigopostal` CodigoPostal,l.`nombre` NombreLocalidad, t.`Descripcion` DescripcionIva FROM Cliente c LEFT JOIN `localidad` l ON c.`localidad`=l.`id` LEFT JOIN tiporesponsable t ON c.`tiporesponsable`=t.`Codigo` "

                        If soloActivos Then
                            .CommandText &= " WHERE c.Activo=1 "
                        End If

                        .CommandText &= " ORDER BY c.nombre"

                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New Cliente
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
            "Datos:Cliente", _
            "GetAllOrderByNombre", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Private Function Populate(ByVal reader As MySqlDataReader) As Cliente
        Dim obj As New Cliente
        Try
            With obj
                .Id = Convert.ToUInt32(reader("Id"))
                .Codigo = Convert.ToString(reader("Codigo"))
                .Nombre = Convert.ToString(reader("Nombre"))
                .Domicilio = Convert.ToString(reader("Domicilio"))
                .Telefono = Convert.ToString(reader("Telefono"))
                .Email = Convert.ToString(reader("Email"))
                .Email2 = Convert.ToString(reader("Email2"))
                .Email3 = Convert.ToString(reader("Email3"))
                .Tipodocumento = Convert.ToUInt32(reader("Tipodocumento"))
                .Documento = Convert.ToString(reader("Documento"))
                .Activo = Convert.ToBoolean(reader("Activo"))
                .Tiporesponsable = Convert.ToUInt32(reader("Tiporesponsable"))
                .Observacion = Convert.ToString(reader("Observacion"))
                .Localidad = Convert.ToUInt32(reader("Localidad"))
                .Provincia = Convert.ToUInt32(reader("Provincia"))
                .FormadePago = Convert.ToUInt32(reader("FormadePago"))
                .Zona = Convert.ToUInt32(reader("Zona"))
                .Vendedor = Convert.ToUInt32(reader("Vendedor"))
                .Fechaultimacompra = Convert.ToDateTime(reader("Fechaultimacompra"))
                .Listadeprecio = Convert.ToUInt32(reader("Listadeprecio"))
                .Diasctacte = Convert.ToUInt32(reader("Diasctacte"))
                .Ingresosbrutosnro = Convert.ToString(reader("Ingresosbrutosnro"))
                .Limitecredito = Convert.ToDouble(reader("Limitecredito"))
                .Descuento = Convert.ToDouble(reader("Descuento"))
                .Interesmora = Convert.ToDouble(reader("Interesmora"))
                .Codigoingresosbrutos = Convert.ToChar(reader("Codigoingresosbrutos"))
                .Ingresosbrutosalic = Convert.ToDouble(reader("Ingresosbrutosalic"))
                .NombreLocalidad = Convert.ToString(reader("NombreLocalidad"))
                .CodigoPostal = Convert.ToString(reader("CodigoPostal"))
                .DescripcionIva = Convert.ToString(reader("DescripcionIva"))
                .Contacto = Convert.ToString(reader("Contacto"))
            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function
End Class

