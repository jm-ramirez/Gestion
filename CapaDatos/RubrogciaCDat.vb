Imports Entidades
Imports MySql.Data.MySqlClient
Public Class RubrogciaCDat
    Private ExceptionClassObject As New ManejoDeErrores.ExceptionClass
    Private ExceptionErrorFileString As String = My.Application.Info.DirectoryPath & "\ErrorFile.log"
    Private WriteErrorMessageString As String
    Private ErrorMessageString As String
    Public Function Insert(ByVal obj As Rubrogcia) As UInt32
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "INSERT INTO Rubrogcia (Id,Nombre,Descripcion,Nosujeto,Minimo,Noinscripto,Tope1,Tope2,Tope3,Tope4,Tope5,Tope6,Tope7,Tope1alic,Tope2alic,Tope3alic,Tope4alic,Tope5alic,Tope6alic,Tope7alic) VALUES (@Id,@Nombre,@Descripcion,@Nosujeto,@Minimo,@Noinscripto,@Tope1,@Tope2,@Tope3,@Tope4,@Tope5,@Tope6,@Tope7,@Tope1alic,@Tope2alic,@Tope3alic,@Tope4alic,@Tope5alic,@Tope6alic,@Tope7alic)"
                        .Parameters.AddWithValue("@Id", obj.Id)
                        .Parameters.AddWithValue("@Nombre", obj.Nombre)
                        .Parameters.AddWithValue("@Descripcion", obj.Descripcion)
                        .Parameters.AddWithValue("@Nosujeto", obj.Nosujeto)
                        .Parameters.AddWithValue("@Minimo", obj.Minimo)
                        .Parameters.AddWithValue("@Noinscripto", obj.Noinscripto)
                        .Parameters.AddWithValue("@Tope1", obj.Tope1)
                        .Parameters.AddWithValue("@Tope2", obj.Tope2)
                        .Parameters.AddWithValue("@Tope3", obj.Tope3)
                        .Parameters.AddWithValue("@Tope4", obj.Tope4)
                        .Parameters.AddWithValue("@Tope5", obj.Tope5)
                        .Parameters.AddWithValue("@Tope6", obj.Tope6)
                        .Parameters.AddWithValue("@Tope7", obj.Tope7)
                        .Parameters.AddWithValue("@Tope1alic", obj.Tope1alic)
                        .Parameters.AddWithValue("@Tope2alic", obj.Tope2alic)
                        .Parameters.AddWithValue("@Tope3alic", obj.Tope3alic)
                        .Parameters.AddWithValue("@Tope4alic", obj.Tope4alic)
                        .Parameters.AddWithValue("@Tope5alic", obj.Tope5alic)
                        .Parameters.AddWithValue("@Tope6alic", obj.Tope6alic)
                        .Parameters.AddWithValue("@Tope7alic", obj.Tope7alic)
                        .ExecuteNonQuery()
                        Return .LastInsertedId
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Rubrogcia", _
            "Insert", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Public Sub Update(ByVal obj As Rubrogcia)
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "UPDATE Rubrogcia SET Nombre = @Nombre,Descripcion = @Descripcion,Nosujeto = @Nosujeto,Minimo = @Minimo,Noinscripto = @Noinscripto,Tope1 = @Tope1,Tope2 = @Tope2,Tope3 = @Tope3,Tope4 = @Tope4,Tope5 = @Tope5,Tope6 = @Tope6,Tope7 = @Tope7,Tope1alic = @Tope1alic,Tope2alic = @Tope2alic,Tope3alic = @Tope3alic,Tope4alic = @Tope4alic,Tope5alic = @Tope5alic,Tope6alic = @Tope6alic,Tope7alic = @Tope7alic WHERE Id = @Id"
                        .Parameters.AddWithValue("@Id", obj.Id)
                        .Parameters.AddWithValue("@Nombre", obj.Nombre)
                        .Parameters.AddWithValue("@Descripcion", obj.Descripcion)
                        .Parameters.AddWithValue("@Nosujeto", obj.Nosujeto)
                        .Parameters.AddWithValue("@Minimo", obj.Minimo)
                        .Parameters.AddWithValue("@Noinscripto", obj.Noinscripto)
                        .Parameters.AddWithValue("@Tope1", obj.Tope1)
                        .Parameters.AddWithValue("@Tope2", obj.Tope2)
                        .Parameters.AddWithValue("@Tope3", obj.Tope3)
                        .Parameters.AddWithValue("@Tope4", obj.Tope4)
                        .Parameters.AddWithValue("@Tope5", obj.Tope5)
                        .Parameters.AddWithValue("@Tope6", obj.Tope6)
                        .Parameters.AddWithValue("@Tope7", obj.Tope7)
                        .Parameters.AddWithValue("@Tope1alic", obj.Tope1alic)
                        .Parameters.AddWithValue("@Tope2alic", obj.Tope2alic)
                        .Parameters.AddWithValue("@Tope3alic", obj.Tope3alic)
                        .Parameters.AddWithValue("@Tope4alic", obj.Tope4alic)
                        .Parameters.AddWithValue("@Tope5alic", obj.Tope5alic)
                        .Parameters.AddWithValue("@Tope6alic", obj.Tope6alic)
                        .Parameters.AddWithValue("@Tope7alic", obj.Tope7alic)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Rubrogcia", _
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
                        .CommandText = "DELETE FROM Rubrogcia WHERE Id = @Id"
                        .Parameters.AddWithValue("@Id", id)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Rubrogcia", _
            "Delete", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Sub
    Public Function GetById(ByVal id As UInt32) As Rubrogcia
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Rubrogcia WHERE Id= @Id"
                        .Parameters.AddWithValue("@Id", id)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Dim obj As New Rubrogcia
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
            "Datos:Rubrogcia", _
            "GetById", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Public Function GetAll() As List(Of Rubrogcia)
        Try
            Dim lista As New List(Of Rubrogcia)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Rubrogcia"
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New Rubrogcia
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
            "Datos:Rubrogcia", _
            "GetAll", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Private Function Populate(ByVal reader As MySqlDataReader) As Rubrogcia
        Dim obj As New Rubrogcia
        Try
            With obj
                .Id = Convert.ToUInt32(reader("Id"))
                .Nombre = Convert.ToString(reader("Nombre"))
                .Descripcion = Convert.ToString(reader("Descripcion"))
                .Nosujeto = Convert.ToDouble(reader("Nosujeto"))
                .Minimo = Convert.ToDouble(reader("Minimo"))
                .Noinscripto = Convert.ToDouble(reader("Noinscripto"))
                .Tope1 = Convert.ToDouble(reader("Tope1"))
                .Tope2 = Convert.ToDouble(reader("Tope2"))
                .Tope3 = Convert.ToDouble(reader("Tope3"))
                .Tope4 = Convert.ToDouble(reader("Tope4"))
                .Tope5 = Convert.ToDouble(reader("Tope5"))
                .Tope6 = Convert.ToDouble(reader("Tope6"))
                .Tope7 = Convert.ToDouble(reader("Tope7"))
                .Tope1alic = Convert.ToDouble(reader("Tope1alic"))
                .Tope2alic = Convert.ToDouble(reader("Tope2alic"))
                .Tope3alic = Convert.ToDouble(reader("Tope3alic"))
                .Tope4alic = Convert.ToDouble(reader("Tope4alic"))
                .Tope5alic = Convert.ToDouble(reader("Tope5alic"))
                .Tope6alic = Convert.ToDouble(reader("Tope6alic"))
                .Tope7alic = Convert.ToDouble(reader("Tope7alic"))
            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function
End Class

