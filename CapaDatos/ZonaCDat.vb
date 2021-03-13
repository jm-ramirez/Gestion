Imports Entidades
Imports MySql.Data.MySqlClient
Public Class ZonaCDat
Private ExceptionClassObject As New ManejoDeErrores.ExceptionClass
Private ExceptionErrorFileString As String = My.Application.Info.DirectoryPath & "\ErrorFile.log"
Private WriteErrorMessageString As String
Private ErrorMessageString As String
Public function Insert(ByVal obj As Zona) as uint32
    Try
        Using cnn As MySqlConnection = CreateConnection()
            cnn.Open()
            Using cmd As New MySqlCommand
                With cmd
                    .Connection = cnn
                    .CommandType = CommandType.Text
                    .CommandText = "INSERT INTO Zona (Id,Nombre,Descripcion) VALUES (@Id,@Nombre,@Descripcion)"
.Parameters.AddWithValue("@Id", obj.Id)
.Parameters.AddWithValue("@Nombre", obj.Nombre)
.Parameters.AddWithValue("@Descripcion", obj.Descripcion)
                    .ExecuteNonQuery()
					   Return .LastInsertedId
                End With
            End Using
        End Using
    Catch exError As MySqlException
        ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
        Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
        "Datos:Zona", _
        "Insert", _
        ErrorMessageString, _
        WriteErrorMessageString)
        Throw New Exception(ErrorMessageString)
    End Try
    End Function
Public Sub Update(ByVal obj As Zona)
    Try
        Using cnn As MySqlConnection = CreateConnection()
            cnn.Open()
            Using cmd As New MySqlCommand
                With cmd
                    .Connection = cnn
                    .CommandType = CommandType.Text
                    .CommandText = "UPDATE Zona SET Nombre = @Nombre,Descripcion = @Descripcion WHERE Id = @Id"
                        .Parameters.AddWithValue("@Id", obj.Id)
                        .Parameters.AddWithValue("@Nombre", obj.Nombre)
                        .Parameters.AddWithValue("@Descripcion", obj.Descripcion)
                    .ExecuteNonQuery()
                End With
            End Using
        End Using
    Catch exError As MySqlException
        ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
        Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
        "Datos:Zona", _
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
                    .CommandText = "DELETE FROM Zona WHERE Id = @Id"
                    .Parameters.AddWithValue("@Id", id)
                    .ExecuteNonQuery()
                End With
            End Using
        End Using
    Catch exError As MySqlException
        ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
        Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
        "Datos:Zona", _
        "Delete", _
        ErrorMessageString, _
        WriteErrorMessageString)
        Throw New Exception(ErrorMessageString)
    End Try
End Sub
Public Function GetById(ByVal id As UInt32) As Zona
    Try
        Using cnn As MySqlConnection = CreateConnection()
            cnn.Open()
            Using cmd As New MySqlCommand
                With cmd
                    .Connection = cnn
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT * FROM Zona WHERE Id= @Id"
                    .Parameters.AddWithValue("@Id", id)
                    Using reader As MySqlDataReader = .ExecuteReader
                        If (reader.Read) Then
                            Dim obj As New Zona
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
        "Datos:Zona", _
        "GetById", _
        ErrorMessageString, _
        WriteErrorMessageString)
        Throw New Exception(ErrorMessageString)
    End Try
End Function
Public Function GetAll() As List(Of Zona)
    Try
        Dim lista As New List(Of Zona)
        Using cnn As MySqlConnection = CreateConnection()
            cnn.Open()
            Using cmd As New MySqlCommand
                With cmd
                    .Connection = cnn
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT * FROM Zona"
                    Try
                        Using reader As MySqlDataReader = .ExecuteReader
                            Do While reader.Read
                                Dim obj = New Zona
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
        "Datos:Zona", _
        "GetAll", _
        ErrorMessageString, _
        WriteErrorMessageString)
        Throw New Exception(ErrorMessageString)
    End Try
End Function
Private Function Populate(ByVal reader As MySqlDataReader) As Zona
    Dim obj As New Zona
    Try
        With obj
.Id = Convert.ToUInt32(reader("Id"))
.Nombre = Convert.ToString(reader("Nombre"))
.Descripcion = Convert.ToString(reader("Descripcion"))
        End With
        Return obj
    Catch ex As Exception
        Throw New Exception(ex.Message, ex)
    Finally
        obj = Nothing
    End Try
End Function
End Class

