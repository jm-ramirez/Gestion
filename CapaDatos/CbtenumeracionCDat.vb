Imports Entidades
Imports MySql.Data.MySqlClient
Public Class CbtenumeracionCDat

    Private ExceptionClassObject As New ManejoDeErrores.ExceptionClass
    Private ExceptionErrorFileString As String = My.Application.Info.DirectoryPath & "\ErrorFile.log"
    Private WriteErrorMessageString As String
    Private ErrorMessageString As String

    Public Function Insert(ByVal obj As Cbtenumeracion) As UInt32
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "INSERT INTO Cbtenumeracion (Id,Ptovta,Cbtetipo,Numero) VALUES (@Id,@Ptovta,@Cbtetipo,@Numero)"
                        .Parameters.AddWithValue("@Id", obj.Id)
                        .Parameters.AddWithValue("@Ptovta", obj.Ptovta)
                        .Parameters.AddWithValue("@Cbtetipo", obj.Cbtetipo)
                        .Parameters.AddWithValue("@Numero", obj.Numero)
                        .ExecuteNonQuery()
                        Return .LastInsertedId
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cbtenumeracion", _
            "Insert", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Public Sub Update(ByVal obj As Cbtenumeracion)
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "UPDATE Cbtenumeracion SET Ptovta = @Ptovta,Cbtetipo = @Cbtetipo,Numero = @Numero WHERE Id = @Id"
                        .Parameters.AddWithValue("@Id", obj.Id)
                        .Parameters.AddWithValue("@Ptovta", obj.Ptovta)
                        .Parameters.AddWithValue("@Cbtetipo", obj.Cbtetipo)
                        .Parameters.AddWithValue("@Numero", obj.Numero)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cbtenumeracion", _
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
                        .CommandText = "DELETE FROM Cbtenumeracion WHERE Id = @Id"
                        .Parameters.AddWithValue("@Id", id)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cbtenumeracion", _
            "Delete", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Sub
    Public Function GetById(ByVal id As UInt32) As Cbtenumeracion
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Cbtenumeracion WHERE Id= @Id"
                        .Parameters.AddWithValue("@Id", id)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Dim obj As New Cbtenumeracion
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
            "Datos:Cbtenumeracion", _
            "GetById", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetByUltimoNroCbte(ByVal ptovta As UInt32, ByVal cbtetipo As UInt32) As Cbtenumeracion
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Cbtenumeracion WHERE ptovta= @ptovta AND cbtetipo = @cbtetipo"
                        .Parameters.AddWithValue("@ptovta", ptovta)
                        .Parameters.AddWithValue("@cbtetipo", cbtetipo)

                        Dim obj As Cbtenumeracion

                        'si no existe la numeracion creada, devuelve un cbtenumeracion con los parametros pasados y el numero en 0
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                obj = New Cbtenumeracion
                                obj = Populate(reader)
                                Return obj
                            Else
                                'obj = New Cbtenumeracion
                                'obj.Cbtetipo = cbtetipo
                                'obj.Ptovta = ptovta
                                'obj.Numero = 0
                                Return Nothing
                            End If
                        End Using
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cbtenumeracion", _
            "GetById", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetAll() As List(Of Cbtenumeracion)
        Try
            Dim lista As New List(Of Cbtenumeracion)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Cbtenumeracion ORDER BY ptovta,cbtetipo"
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New Cbtenumeracion
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
            "Datos:Cbtenumeracion", _
            "GetAll", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetAll2() As List(Of Cbtenumeracion)
        Try
            Dim lista As New List(Of Cbtenumeracion)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Cbtenumeracion WHERE ptovta <> 9999 ORDER BY ptovta,cbtetipo"
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New Cbtenumeracion
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
            "Datos:Cbtenumeracion", _
            "GetAll", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Sub SaveAll(ByVal objList As List(Of Cbtenumeracion))

        Dim transaccion As MySqlTransaction = Nothing

        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                transaccion = cnn.BeginTransaction

                Using cmd As New MySqlCommand
                    With cmd
                        .Transaction = transaccion
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "UPDATE Cbtenumeracion SET Cbtetipo = @Cbtetipo,Ptovta = @Ptovta,Numero = @Numero WHERE Id = @Id"

                        For Each obj As Entidades.Cbtenumeracion In objList

                            .Parameters.Clear()
                            .Parameters.AddWithValue("@Id", obj.Id)
                            .Parameters.AddWithValue("@Cbtetipo", obj.Cbtetipo)
                            .Parameters.AddWithValue("@Numero", obj.Numero)
                            .Parameters.AddWithValue("@Ptovta", obj.Ptovta)
                            .ExecuteNonQuery()

                        Next

                    End With

                End Using

                transaccion.Commit()

            End Using

        Catch exError As MySqlException

            If transaccion IsNot Nothing Then
                transaccion.Rollback()
            End If

            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Cbtenumeracion", _
            "SaveAll", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Sub

    Private Function Populate(ByVal reader As MySqlDataReader) As Cbtenumeracion
        Dim obj As New Cbtenumeracion
        Try
            With obj
                .Id = Convert.ToUInt32(reader("Id"))
                .Ptovta = Convert.ToUInt32(reader("Ptovta"))
                .Cbtetipo = Convert.ToUInt32(reader("Cbtetipo"))
                .Numero = Convert.ToUInt32(reader("Numero"))
            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function
End Class

