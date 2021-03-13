Imports Entidades
Imports MySql.Data.MySqlClient
Public Class TiporesponsableCDat
Private ExceptionClassObject As New ManejoDeErrores.ExceptionClass
Private ExceptionErrorFileString As String = My.Application.Info.DirectoryPath & "\ErrorFile.log"
Private WriteErrorMessageString As String
Private ErrorMessageString As String
Public Sub Insert(ByVal obj As Tiporesponsable)
    Try
        Using cnn As MySqlConnection = CreateConnection()
            cnn.Open()
            Using cmd As New MySqlCommand
                With cmd
                    .Connection = cnn
                    .CommandType = CommandType.Text
                    .CommandText = "INSERT INTO Tiporesponsable (Id,Codigo,Descripcion) VALUES (@Id,@Codigo,@Descripcion)"
.Parameters.AddWithValue("@Id", obj.Id)
.Parameters.AddWithValue("@Codigo", obj.Codigo)
.Parameters.AddWithValue("@Descripcion", obj.Descripcion)
                    .ExecuteNonQuery()
                End With
            End Using
        End Using
    Catch exError As MySqlException
        ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
        Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
        "Datos:Tiporesponsable", _
        "Insert", _
        ErrorMessageString, _
        WriteErrorMessageString)
        Throw New Exception(ErrorMessageString)
    End Try
End Sub
Public Sub Update(ByVal obj As Tiporesponsable)
    Try
        Using cnn As MySqlConnection = CreateConnection()
            cnn.Open()
            Using cmd As New MySqlCommand
                With cmd
                    .Connection = cnn
                    .CommandType = CommandType.Text
                    .CommandText = "UPDATE Tiporesponsable SET Codigo = @Codigo,Descripcion = @Descripcion WHERE Id = @Id"
.Parameters.AddWithValue("@Id", obj.Id)
.Parameters.AddWithValue("@Codigo", obj.Codigo)
.Parameters.AddWithValue("@Descripcion", obj.Descripcion)
                    .ExecuteNonQuery()
                End With
            End Using
        End Using
    Catch exError As MySqlException
        ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
        Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
        "Datos:Tiporesponsable", _
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
                    .CommandText = "DELETE FROM Tiporesponsable WHERE Id = @Id"
                    .Parameters.AddWithValue("@Id", id)
                    .ExecuteNonQuery()
                End With
            End Using
        End Using
    Catch exError As MySqlException
        ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
        Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
        "Datos:Tiporesponsable", _
        "Delete", _
        ErrorMessageString, _
        WriteErrorMessageString)
        Throw New Exception(ErrorMessageString)
    End Try
End Sub
Public Function GetById(ByVal id As UInt32) As Tiporesponsable
    Try
        Using cnn As MySqlConnection = CreateConnection()
            cnn.Open()
            Using cmd As New MySqlCommand
                With cmd
                    .Connection = cnn
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT * FROM Tiporesponsable WHERE Id= @Id"
                    .Parameters.AddWithValue("@Id", id)
                    Using reader As MySqlDataReader = .ExecuteReader
                        If (reader.Read) Then
                            Dim obj As New Tiporesponsable
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
        "Datos:Tiporesponsable", _
        "GetById", _
        ErrorMessageString, _
        WriteErrorMessageString)
        Throw New Exception(ErrorMessageString)
    End Try
    End Function


    Public Function GetByCodigo(ByVal codigo As UInt32) As Tiporesponsable
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Tiporesponsable WHERE Codigo= @Codigo"
                        .Parameters.AddWithValue("@Codigo", codigo)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Dim obj As New Tiporesponsable
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
            "Datos:Tiporesponsable", _
            "GetByCodigo", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

Public Function GetAll() As List(Of Tiporesponsable)
    Try
        Dim lista As New List(Of Tiporesponsable)
        Using cnn As MySqlConnection = CreateConnection()
            cnn.Open()
            Using cmd As New MySqlCommand
                With cmd
                    .Connection = cnn
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT * FROM Tiporesponsable"
                    Try
                        Using reader As MySqlDataReader = .ExecuteReader
                            Do While reader.Read
                                Dim obj = New Tiporesponsable
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
        "Datos:Tiporesponsable", _
        "GetAll", _
        ErrorMessageString, _
        WriteErrorMessageString)
        Throw New Exception(ErrorMessageString)
    End Try
End Function
Private Function Populate(ByVal reader As MySqlDataReader) As Tiporesponsable
    Dim obj As New Tiporesponsable
    Try
        With obj
.Id = Convert.ToUInt32(reader("Id"))
.Codigo = Convert.ToUInt32(reader("Codigo"))
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

