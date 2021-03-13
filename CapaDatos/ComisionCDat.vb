Imports Entidades
Imports MySql.Data.MySqlClient
Public Class ComisionCDat
    Private ExceptionClassObject As New ManejoDeErrores.ExceptionClass
    Private ExceptionErrorFileString As String = My.Application.Info.DirectoryPath & "\ErrorFile.log"
    Private WriteErrorMessageString As String
    Private ErrorMessageString As String
    Public Function Insert(ByVal obj As Comision) As UInt32
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "INSERT INTO Comision (Id,Vendedor,Articulo,Comisionprecio1,Comisionprecio2,Comisionprecio3) VALUES (@Id,@Vendedor,@Articulo,@Comisionprecio1,@Comisionprecio2,@Comisionprecio3)"
                        .Parameters.AddWithValue("@Id", obj.Id)
                        .Parameters.AddWithValue("@Vendedor", obj.Vendedor)
                        .Parameters.AddWithValue("@Articulo", obj.Articulo)
                        .Parameters.AddWithValue("@Comisionprecio1", obj.Comisionprecio1)
                        .Parameters.AddWithValue("@Comisionprecio2", obj.Comisionprecio2)
                        .Parameters.AddWithValue("@Comisionprecio3", obj.Comisionprecio3)
                        .ExecuteNonQuery()
                        Return .LastInsertedId
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Comision", _
            "Insert", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Sub SaveAll(ByVal objList As List(Of Comision))

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
                        .CommandText = "UPDATE Comision SET Comisionprecio1 = @Comisionprecio1,Comisionprecio2 = @Comisionprecio2,Comisionprecio3 = @Comisionprecio3 WHERE Id = @Id"

                        For Each obj As Entidades.Comision In objList

                            .Parameters.Clear()
                            .Parameters.AddWithValue("@Id", obj.Id)
                            .Parameters.AddWithValue("@Comisionprecio1", obj.Comisionprecio1)
                            .Parameters.AddWithValue("@Comisionprecio2", obj.Comisionprecio2)
                            .Parameters.AddWithValue("@Comisionprecio3", obj.Comisionprecio3)
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
            "Datos:Comision", _
            "SaveAll", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Sub

    Public Sub Update(ByVal obj As Comision)
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "UPDATE Comision SET Vendedor = @Vendedor,Articulo = @Articulo,Comisionprecio1 = @Comisionprecio1,Comisionprecio2 = @Comisionprecio2,Comisionprecio3 = @Comisionprecio3 WHERE Id = @Id"
                        .Parameters.AddWithValue("@Id", obj.Id)
                        .Parameters.AddWithValue("@Vendedor", obj.Vendedor)
                        .Parameters.AddWithValue("@Articulo", obj.Articulo)
                        .Parameters.AddWithValue("@Comisionprecio1", obj.Comisionprecio1)
                        .Parameters.AddWithValue("@Comisionprecio2", obj.Comisionprecio2)
                        .Parameters.AddWithValue("@Comisionprecio3", obj.Comisionprecio3)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Comision", _
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
                        .CommandText = "DELETE FROM Comision WHERE Id = @Id"
                        .Parameters.AddWithValue("@Id", id)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Comision", _
            "Delete", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Sub
    Public Function GetById(ByVal id As UInt32) As Comision
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Comision WHERE Id= @Id"
                        .Parameters.AddWithValue("@Id", id)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Dim obj As New Comision
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
            "Datos:Comision", _
            "GetById", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetAll(ByVal vendedor As UInt32) As List(Of Comision)
        Try
            Dim lista As New List(Of Comision)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT Articulo.Nombre,Comision.Id,Comision.Vendedor,Comision.Articulo,IFNULL(Comision.ComisionPrecio1,0) ComisionPrecio1,IFNULL(Comision.ComisionPrecio2,0) ComisionPrecio2,"
                        .CommandText &= "IFNULL(Comision.ComisionPrecio3,0) ComisionPrecio3 "
                        .CommandText &= "FROM Articulos,Comision WHERE Articulo.Codigo = Comision.Articulo AND Comision.Vendedor= @Vendedor"
                        .Parameters.AddWithValue("@Vendedor", vendedor)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New Comision
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
            "Datos:Comision", _
            "GetAll", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Private Function Populate(ByVal reader As MySqlDataReader) As Comision
        Dim obj As New Comision
        Try
            With obj
                .Id = Convert.ToUInt32(reader("Id"))
                .Vendedor = Convert.ToUInt32(reader("Vendedor"))
                .Articulo = Convert.ToString(reader("Articulo"))
                .Descripcion = Convert.ToString(reader("Nombre"))
                .Comisionprecio1 = Convert.ToDouble(reader("Comisionprecio1"))
                .Comisionprecio2 = Convert.ToDouble(reader("Comisionprecio2"))
                .Comisionprecio3 = Convert.ToDouble(reader("Comisionprecio3"))
            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function
End Class

