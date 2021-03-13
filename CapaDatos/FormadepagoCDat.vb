Imports Entidades
Imports MySql.Data.MySqlClient
Public Class FormadepagoCDat
    Private ExceptionClassObject As New ManejoDeErrores.ExceptionClass
    Private ExceptionErrorFileString As String = My.Application.Info.DirectoryPath & "\ErrorFile.log"
    Private WriteErrorMessageString As String
    Private ErrorMessageString As String
    Public Function Insert(ByVal obj As Formadepago) As UInt32
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "INSERT INTO Formadepago (Id,Nombre,Descripcion,dias1,paga1,dias2,paga2,dias3,paga3,dias4,paga4,dias5,paga5,dias6,paga6,activo) VALUES (@Id,@Nombre,@Descripcion,@dias1,@paga1,@dias2,@paga2,@dias3,@paga3,@dias4,@paga4,@dias5,@paga5,@dias6,@paga6,@activo)"
                        .Parameters.AddWithValue("@Id", obj.Id)
                        .Parameters.AddWithValue("@Nombre", obj.Nombre)
                        .Parameters.AddWithValue("@Descripcion", obj.Descripcion)
                        .Parameters.AddWithValue("@dias1", obj.Dias1)
                        .Parameters.AddWithValue("@paga1", obj.Paga1)
                        .Parameters.AddWithValue("@dias2", obj.Dias2)
                        .Parameters.AddWithValue("@paga2", obj.Paga2)
                        .Parameters.AddWithValue("@dias3", obj.Dias3)
                        .Parameters.AddWithValue("@paga3", obj.Paga3)
                        .Parameters.AddWithValue("@dias4", obj.Dias4)
                        .Parameters.AddWithValue("@paga4", obj.Paga4)
                        .Parameters.AddWithValue("@dias5", obj.Dias5)
                        .Parameters.AddWithValue("@paga5", obj.Paga5)
                        .Parameters.AddWithValue("@dias6", obj.Dias6)
                        .Parameters.AddWithValue("@paga6", obj.Paga6)
                        .Parameters.AddWithValue("@activo", obj.Activo)
                        .ExecuteNonQuery()
                        Return .LastInsertedId
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Formadepago", _
            "Insert", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Public Sub Update(ByVal obj As Formadepago)
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "UPDATE Formadepago SET Nombre = @Nombre,Descripcion = @Descripcion, dias1 = @dias1, paga1 = @paga1, dias2 = @dias2, paga2 = @paga2, dias3 = @dias3, paga3 = @paga3, dias4 = @dias4, paga4 = @paga4, dias5 = @dias5, paga5 = @paga5, dias6 = @dias6, paga6 = @paga6, activo= @activo WHERE Id = @Id"
                        .Parameters.AddWithValue("@Id", obj.Id)
                        .Parameters.AddWithValue("@Nombre", obj.Nombre)
                        .Parameters.AddWithValue("@Descripcion", obj.Descripcion)
                        .Parameters.AddWithValue("@dias1", obj.Dias1)
                        .Parameters.AddWithValue("@paga1", obj.Paga1)
                        .Parameters.AddWithValue("@dias2", obj.Dias2)
                        .Parameters.AddWithValue("@paga2", obj.Paga2)
                        .Parameters.AddWithValue("@dias3", obj.Dias3)
                        .Parameters.AddWithValue("@paga3", obj.Paga3)
                        .Parameters.AddWithValue("@dias4", obj.Dias4)
                        .Parameters.AddWithValue("@paga4", obj.Paga4)
                        .Parameters.AddWithValue("@dias5", obj.Dias5)
                        .Parameters.AddWithValue("@paga5", obj.Paga5)
                        .Parameters.AddWithValue("@dias6", obj.Dias6)
                        .Parameters.AddWithValue("@paga6", obj.Paga6)
                        .Parameters.AddWithValue("@activo", obj.Activo)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Formadepago", _
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
                        .CommandText = "DELETE FROM Formadepago WHERE Id = @Id"
                        .Parameters.AddWithValue("@Id", id)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Formadepago", _
            "Delete", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Sub
    Public Function GetById(ByVal id As UInt32) As Formadepago
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Formadepago WHERE Id= @Id"
                        .Parameters.AddWithValue("@Id", id)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Dim obj As New Formadepago
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
            "Datos:Formadepago", _
            "GetById", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Public Function GetAll() As List(Of Formadepago)
        Try
            Dim lista As New List(Of Formadepago)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Formadepago"
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New Formadepago
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
            "Datos:Formadepago", _
            "GetAll", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Private Function Populate(ByVal reader As MySqlDataReader) As Formadepago
        Dim obj As New Formadepago
        Try
            With obj
                .Id = Convert.ToUInt32(reader("Id"))
                .Nombre = Convert.ToString(reader("Nombre"))
                .Descripcion = Convert.ToString(reader("Descripcion"))
                .Dias1 = Convert.ToUInt32(reader("Dias1"))
                .Paga1 = Convert.ToDouble(reader("Paga1"))
                .Dias2 = Convert.ToUInt32(reader("Dias2"))
                .Paga2 = Convert.ToDouble(reader("Paga2"))
                .Dias3 = Convert.ToUInt32(reader("Dias3"))
                .Paga3 = Convert.ToDouble(reader("Paga3"))
                .Dias4 = Convert.ToUInt32(reader("Dias4"))
                .Paga4 = Convert.ToDouble(reader("Paga4"))
                .Dias5 = Convert.ToUInt32(reader("Dias5"))
                .Paga5 = Convert.ToDouble(reader("Paga5"))
                .Dias6 = Convert.ToUInt32(reader("Dias6"))
                .Paga6 = Convert.ToDouble(reader("Paga6"))
                .Activo = Convert.ToBoolean(reader("Activo"))
            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function
End Class

