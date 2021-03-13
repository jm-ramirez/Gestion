Imports Entidades
Imports MySql.Data.MySqlClient
Public Class ConceptobancarioCDat
    Private ExceptionClassObject As New ManejoDeErrores.ExceptionClass
    Private ExceptionErrorFileString As String = My.Application.Info.DirectoryPath & "\ErrorFile.log"
    Private WriteErrorMessageString As String
    Private ErrorMessageString As String
    Public Function Insert(ByVal obj As Conceptobancario) As UInt32
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "INSERT INTO Conceptobancario (Id,Codigo,Nombre,Descripcion,Tipo,Activo,Alicuota,Plazo) VALUES (@Id,@Codigo,@Nombre,@Descripcion,@Tipo,@Activo,@Alicuota,@Plazo)"
                        .Parameters.AddWithValue("@Id", obj.Id)
                        .Parameters.AddWithValue("@Codigo", obj.Codigo)
                        .Parameters.AddWithValue("@Nombre", obj.Nombre)
                        .Parameters.AddWithValue("@Descripcion", obj.Descripcion)
                        .Parameters.AddWithValue("@Tipo", obj.Tipo)
                        .Parameters.AddWithValue("@Activo", obj.Activo)
                        .Parameters.AddWithValue("@Alicuota", obj.Alicuota)
                        .Parameters.AddWithValue("@Plazo", obj.Plazo)
                        .ExecuteNonQuery()
                        Return .LastInsertedId
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Conceptobancario", _
            "Insert", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Public Sub Update(ByVal obj As Conceptobancario)
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "UPDATE Conceptobancario SET Codigo = @Codigo,Nombre = @Nombre,Descripcion = @Descripcion,Tipo = @Tipo,Activo = @Activo,Alicuota = @Alicuota,Plazo=@Plazo WHERE Id = @Id"
                        .Parameters.AddWithValue("@Id", obj.Id)
                        .Parameters.AddWithValue("@Codigo", obj.Codigo)
                        .Parameters.AddWithValue("@Nombre", obj.Nombre)
                        .Parameters.AddWithValue("@Descripcion", obj.Descripcion)
                        .Parameters.AddWithValue("@Tipo", obj.Tipo)
                        .Parameters.AddWithValue("@Activo", obj.Activo)
                        .Parameters.AddWithValue("@Alicuota", obj.Alicuota)
                        .Parameters.AddWithValue("@Plazo", obj.Plazo)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Conceptobancario", _
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
                        .CommandText = "DELETE FROM Conceptobancario WHERE Id = @Id"
                        .Parameters.AddWithValue("@Id", id)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Conceptobancario", _
            "Delete", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Sub
    Public Function GetById(ByVal id As UInt32) As Conceptobancario
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Conceptobancario WHERE Id= @Id"
                        .Parameters.AddWithValue("@Id", id)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Dim obj As New Conceptobancario
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
            "Datos:Conceptobancario", _
            "GetById", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetByCodigo(ByVal codigo As String) As Conceptobancario
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Conceptobancario WHERE Codigo= @Codigo"
                        .Parameters.AddWithValue("@Codigo", codigo)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Dim obj As New Conceptobancario
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
            "Datos:Conceptobancario", _
            "GetByCodigo", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetAll() As List(Of Conceptobancario)
        Try
            Dim lista As New List(Of Conceptobancario)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Conceptobancario"
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New Conceptobancario
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
            "Datos:Conceptobancario", _
            "GetAll", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetConceptosDeudores() As List(Of Conceptobancario)
        Try
            Dim lista As New List(Of Conceptobancario)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Conceptobancario WHERE Tipo=@Tipo AND Activo=1"
                        .Parameters.AddWithValue("@Tipo", CONCEPTO_DEUDOR)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New Conceptobancario
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
            "Datos:Conceptobancario", _
            "GetConceptosDeudores", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetConceptosAcreedores() As List(Of Conceptobancario)
        Try
            Dim lista As New List(Of Conceptobancario)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Conceptobancario WHERE Tipo=@Tipo AND Activo=1"
                        .Parameters.AddWithValue("@Tipo", CONCEPTO_ACREEDOR)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New Conceptobancario
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
            "Datos:Conceptobancario", _
            "GetConceptosAcreedores", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Private Function Populate(ByVal reader As MySqlDataReader) As Conceptobancario
        Dim obj As New Conceptobancario
        Try
            With obj
                .Id = Convert.ToUInt32(reader("Id"))
                .Codigo = Convert.ToString(reader("Codigo"))
                .Nombre = Convert.ToString(reader("Nombre"))
                .Descripcion = Convert.ToString(reader("Descripcion"))
                .Tipo = Convert.ToString(reader("Tipo"))
                .Activo = Convert.ToBoolean(reader("Activo"))
                .Alicuota = Convert.ToDouble(reader("Alicuota"))
                .Plazo = Convert.ToUInt16(reader("Plazo"))

            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function
End Class

