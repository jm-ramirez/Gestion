Imports Entidades
Imports MySql.Data.MySqlClient
Public Class TransporteCDat
    Private ExceptionClassObject As New ManejoDeErrores.ExceptionClass
    Private ExceptionErrorFileString As String = My.Application.Info.DirectoryPath & "\ErrorFile.log"
    Private WriteErrorMessageString As String
    Private ErrorMessageString As String
    Public Function Insert(ByVal obj As Transporte) As UInt32
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "INSERT INTO Transporte (Id,Nombre,Domicilio,Telefono,Email,Tipodocumento,Documento,Tiporesponsable,Observacion,Localidad,Provincia,Zona) VALUES (@Id,@Nombre,@Domicilio,@Telefono,@Email,@Tipodocumento,@Documento,@Tiporesponsable,@Observacion,@Localidad,@Provincia,@Zona)"
                        .Parameters.AddWithValue("@Id", obj.Id)
                        .Parameters.AddWithValue("@Nombre", obj.Nombre)
                        .Parameters.AddWithValue("@Domicilio", obj.Domicilio)
                        .Parameters.AddWithValue("@Telefono", obj.Telefono)
                        .Parameters.AddWithValue("@Email", obj.Email)
                        .Parameters.AddWithValue("@Tipodocumento", obj.Tipodocumento)
                        .Parameters.AddWithValue("@Documento", obj.Documento)
                        .Parameters.AddWithValue("@Tiporesponsable", obj.Tiporesponsable)
                        .Parameters.AddWithValue("@Observacion", obj.Observacion)
                        .Parameters.AddWithValue("@Localidad", obj.Localidad)
                        .Parameters.AddWithValue("@Provincia", obj.Provincia)
                        .Parameters.AddWithValue("@Zona", obj.Zona)
                        .ExecuteNonQuery()
                        Return .LastInsertedId
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Transporte", _
            "Insert", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Public Sub Update(ByVal obj As Transporte)
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "UPDATE Transporte SET Nombre = @Nombre,Domicilio = @Domicilio,Telefono = @Telefono,Email=@Email,Tipodocumento=@Tipodocumento,Documento=@Documento,Tiporesponsable=@Tiporesponsable,Observacion=@Observacion,Localidad=@Localidad,Provincia=@Provincia,Zona=@Zona WHERE Id = @Id"
                        .Parameters.AddWithValue("@Id", obj.Id)
                        .Parameters.AddWithValue("@Nombre", obj.Nombre)
                        .Parameters.AddWithValue("@Domicilio", obj.Domicilio)
                        .Parameters.AddWithValue("@Telefono", obj.Telefono)
                        .Parameters.AddWithValue("@Email", obj.Email)
                        .Parameters.AddWithValue("@Tipodocumento", obj.Tipodocumento)
                        .Parameters.AddWithValue("@Documento", obj.Documento)
                        .Parameters.AddWithValue("@Tiporesponsable", obj.Tiporesponsable)
                        .Parameters.AddWithValue("@Observacion", obj.Observacion)
                        .Parameters.AddWithValue("@Localidad", obj.Localidad)
                        .Parameters.AddWithValue("@Provincia", obj.Provincia)
                        .Parameters.AddWithValue("@Zona", obj.Zona)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Transporte", _
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
                        .CommandText = "DELETE FROM Transporte WHERE Id = @Id"
                        .Parameters.AddWithValue("@Id", id)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Transporte", _
            "Delete", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Sub
    Public Function GetById(ByVal id As UInt32) As Transporte
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Transporte WHERE Id= @Id"
                        .Parameters.AddWithValue("@Id", id)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Dim obj As New Transporte
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
            "Datos:Transporte", _
            "GetById", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Public Function GetAll() As List(Of Transporte)
        Try
            Dim lista As New List(Of Transporte)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Transporte"
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New Transporte
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
            "Datos:Transporte", _
            "GetAll", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Private Function Populate(ByVal reader As MySqlDataReader) As Transporte
        Dim obj As New Transporte
        Try
            With obj
                .Id = Convert.ToUInt32(reader("Id"))
                .Nombre = Convert.ToString(reader("Nombre"))
                .Domicilio = Convert.ToString(reader("Domicilio"))
                .Telefono = Convert.ToString(reader("Telefono"))
                .Email = Convert.ToString(reader("Email"))
                .Tipodocumento = Convert.ToUInt32(reader("Tipodocumento"))
                .Documento = Convert.ToString(reader("Documento"))
                .Tiporesponsable = Convert.ToUInt32(reader("Tiporesponsable"))
                .Observacion = Convert.ToString(reader("Observacion"))
                .Localidad = Convert.ToUInt32(reader("Localidad"))
                .Provincia = Convert.ToUInt32(reader("Provincia"))
                .Zona = Convert.ToUInt32(reader("Zona"))
            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function
End Class