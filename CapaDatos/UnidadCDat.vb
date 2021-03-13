Imports Entidades
Imports MySql.Data.MySqlClient
Public Class UnidadCDat
Private ExceptionClassObject As New ManejoDeErrores.ExceptionClass
Private ExceptionErrorFileString As String = My.Application.Info.DirectoryPath & "\ErrorFile.log"
Private WriteErrorMessageString As String
Private ErrorMessageString As String
Public Sub Insert(ByVal obj As Unidad)
    Try
        Using cnn As MySqlConnection = CreateConnection()
            cnn.Open()
            Using cmd As New MySqlCommand
                With cmd
                    .Connection = cnn
                    .CommandType = CommandType.Text
                        .CommandText = "INSERT INTO Unidad (Id,Codigo,Nombre,Descripcion,Simbolo) VALUES (@Id,@Codigo,@Nombre,@Descripcion,@Simbolo)"
                        .Parameters.AddWithValue("@Id", obj.Id)
                        .Parameters.AddWithValue("@Codigo", obj.Codigo)
                        .Parameters.AddWithValue("@Nombre", obj.Nombre)
                        .Parameters.AddWithValue("@Descripcion", obj.Descripcion)
                        .Parameters.AddWithValue("@Descripcion", obj.Simbolo)
                    .ExecuteNonQuery()
                End With
            End Using
        End Using
    Catch exError As MySqlException
        ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
        Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
        "Datos:Unidad", _
        "Insert", _
        ErrorMessageString, _
        WriteErrorMessageString)
        Throw New Exception(ErrorMessageString)
    End Try
End Sub
Public Sub Update(ByVal obj As Unidad)
    Try
        Using cnn As MySqlConnection = CreateConnection()
            cnn.Open()
            Using cmd As New MySqlCommand
                With cmd
                    .Connection = cnn
                    .CommandType = CommandType.Text
                        .CommandText = "UPDATE Unidad SET Codigo = @Codigo,Nombre = @Nombre,Descripcion = @Descripcion,Simbolo = @Simbolo WHERE Id = @Id"
                        .Parameters.AddWithValue("@Id", obj.Id)
                        .Parameters.AddWithValue("@Codigo", obj.Codigo)
                        .Parameters.AddWithValue("@Nombre", obj.Nombre)
                        .Parameters.AddWithValue("@Descripcion", obj.Descripcion)
                        .Parameters.AddWithValue("@Simbolo", obj.Simbolo)
                    .ExecuteNonQuery()
                End With
            End Using
        End Using
    Catch exError As MySqlException
        ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
        Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
        "Datos:Unidad", _
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
                    .CommandText = "DELETE FROM Unidad WHERE Id = @Id"
                    .Parameters.AddWithValue("@Id", id)
                    .ExecuteNonQuery()
                End With
            End Using
        End Using
    Catch exError As MySqlException
        ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
        Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
        "Datos:Unidad", _
        "Delete", _
        ErrorMessageString, _
        WriteErrorMessageString)
        Throw New Exception(ErrorMessageString)
    End Try
End Sub
Public Function GetById(ByVal id As UInt32) As Unidad
    Try
        Using cnn As MySqlConnection = CreateConnection()
            cnn.Open()
            Using cmd As New MySqlCommand
                With cmd
                    .Connection = cnn
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT * FROM Unidad WHERE Id= @Id"
                    .Parameters.AddWithValue("@Id", id)
                    Using reader As MySqlDataReader = .ExecuteReader
                        If (reader.Read) Then
                            Dim obj As New Unidad
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
        "Datos:Unidad", _
        "GetById", _
        ErrorMessageString, _
        WriteErrorMessageString)
        Throw New Exception(ErrorMessageString)
    End Try
End Function
Public Function GetAll() As List(Of Unidad)
    Try
        Dim lista As New List(Of Unidad)
        Using cnn As MySqlConnection = CreateConnection()
            cnn.Open()
            Using cmd As New MySqlCommand
                With cmd
                    .Connection = cnn
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT * FROM Unidad"
                    Try
                        Using reader As MySqlDataReader = .ExecuteReader
                            Do While reader.Read
                                Dim obj = New Unidad
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
        "Datos:Unidad", _
        "GetAll", _
        ErrorMessageString, _
        WriteErrorMessageString)
        Throw New Exception(ErrorMessageString)
    End Try
End Function
Private Function Populate(ByVal reader As MySqlDataReader) As Unidad
    Dim obj As New Unidad
    Try
        With obj
                .Id = Convert.ToUInt32(reader("Id"))
                .Codigo = Convert.ToString(reader("Codigo"))
                .Nombre = Convert.ToString(reader("Nombre"))
                .Descripcion = Convert.ToString(reader("Descripcion"))
                .Simbolo = Convert.ToString(reader("Simbolo"))
        End With
        Return obj
    Catch ex As Exception
        Throw New Exception(ex.Message, ex)
    Finally
        obj = Nothing
    End Try
End Function
End Class

