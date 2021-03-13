Imports Entidades
Imports MySql.Data.MySqlClient
Public Class BancoCDat
Private ExceptionClassObject As New ManejoDeErrores.ExceptionClass
Private ExceptionErrorFileString As String = My.Application.Info.DirectoryPath & "\ErrorFile.log"
Private WriteErrorMessageString As String
Private ErrorMessageString As String
    Public Function Insert(ByVal obj As Banco) As UInt32
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "INSERT INTO Banco (Id,Codigo,Nombre) VALUES (@Id,@Codigo,@Nombre)"
                        .Parameters.AddWithValue("@Id", obj.Id)
                        .Parameters.AddWithValue("@Codigo", obj.Codigo)
                        .Parameters.AddWithValue("@Nombre", obj.Nombre)
                        .ExecuteNonQuery()
                        Return .LastInsertedId
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Banco", _
            "Insert", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
Public Sub Update(ByVal obj As Banco)
    Try
        Using cnn As MySqlConnection = CreateConnection()
            cnn.Open()
            Using cmd As New MySqlCommand
                With cmd
                    .Connection = cnn
                    .CommandType = CommandType.Text
                    .CommandText = "UPDATE Banco SET Codigo = @Codigo,Nombre = @Nombre WHERE Id = @Id"
.Parameters.AddWithValue("@Id", obj.Id)
.Parameters.AddWithValue("@Codigo", obj.Codigo)
.Parameters.AddWithValue("@Nombre", obj.Nombre)
                    .ExecuteNonQuery()
                End With
            End Using
        End Using
    Catch exError As MySqlException
        ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
        Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
        "Datos:Banco", _
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
                    .CommandText = "DELETE FROM Banco WHERE Id = @Id"
                    .Parameters.AddWithValue("@Id", id)
                    .ExecuteNonQuery()
                End With
            End Using
        End Using
    Catch exError As MySqlException
        ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
        Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
        "Datos:Banco", _
        "Delete", _
        ErrorMessageString, _
        WriteErrorMessageString)
        Throw New Exception(ErrorMessageString)
    End Try
End Sub
Public Function GetById(ByVal id As UInt32) As Banco
    Try
        Using cnn As MySqlConnection = CreateConnection()
            cnn.Open()
            Using cmd As New MySqlCommand
                With cmd
                    .Connection = cnn
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT * FROM Banco WHERE Id= @Id"
                    .Parameters.AddWithValue("@Id", id)
                    Using reader As MySqlDataReader = .ExecuteReader
                        If (reader.Read) Then
                            Dim obj As New Banco
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
        "Datos:Banco", _
        "GetById", _
        ErrorMessageString, _
        WriteErrorMessageString)
        Throw New Exception(ErrorMessageString)
    End Try
End Function
Public Function GetAll() As List(Of Banco)
    Try
        Dim lista As New List(Of Banco)
        Using cnn As MySqlConnection = CreateConnection()
            cnn.Open()
            Using cmd As New MySqlCommand
                With cmd
                    .Connection = cnn
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT * FROM Banco"
                    Try
                        Using reader As MySqlDataReader = .ExecuteReader
                            Do While reader.Read
                                Dim obj = New Banco
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
        "Datos:Banco", _
        "GetAll", _
        ErrorMessageString, _
        WriteErrorMessageString)
        Throw New Exception(ErrorMessageString)
    End Try
End Function
Private Function Populate(ByVal reader As MySqlDataReader) As Banco
    Dim obj As New Banco
    Try
        With obj
.Id = Convert.ToUInt32(reader("Id"))
.Codigo = Convert.ToUInt32(reader("Codigo"))
.Nombre = Convert.ToString(reader("Nombre"))
        End With
        Return obj
    Catch ex As Exception
        Throw New Exception(ex.Message, ex)
    Finally
        obj = Nothing
    End Try
End Function
End Class

