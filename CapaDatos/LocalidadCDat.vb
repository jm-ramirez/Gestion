Imports Entidades
Imports MySql.Data.MySqlClient

Public Class LocalidadCDat

    Private ExceptionClassObject As New ManejoDeErrores.ExceptionClass
    Private ExceptionErrorFileString As String = My.Application.Info.DirectoryPath & "\ErrorFile.log"
    Private WriteErrorMessageString As String
    Private ErrorMessageString As String
    Public Function Insert(ByVal obj As Localidad) As UInt32
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "INSERT INTO Localidad (Id,Nombre,Codigopostal,pcia) VALUES (@Id,@Nombre,@Codigopostal,@Provincia)"
                        .Parameters.AddWithValue("@Id", obj.Id)
                        .Parameters.AddWithValue("@Nombre", obj.Nombre)
                        .Parameters.AddWithValue("@Codigopostal", obj.Codigopostal)
                        .Parameters.AddWithValue("@Provincia", obj.Pcia)
                        .ExecuteNonQuery()
                        Return .LastInsertedId
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Localidad", _
            "Insert", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Public Sub Update(ByVal obj As Localidad)
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "UPDATE Localidad SET Nombre = @Nombre,Codigopostal = @Codigopostal,Pcia = @Provincia WHERE Id = @Id"
                        .Parameters.AddWithValue("@Id", obj.Id)
                        .Parameters.AddWithValue("@Nombre", obj.Nombre)
                        .Parameters.AddWithValue("@Codigopostal", obj.Codigopostal)
                        .Parameters.AddWithValue("@Provincia", obj.Pcia)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Localidad", _
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
                        .CommandText = "DELETE FROM Localidad WHERE Id = @Id"
                        .Parameters.AddWithValue("@Id", id)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Localidad", _
            "Delete", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Sub
    Public Function GetById(ByVal id As UInt32) As Localidad
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT localidad.*,provincias.id IdPcia,provincias.codigo CodPcia,provincias.nombre Provincia,provincias.pais IdPais FROM Localidad LEFT JOIN Provincias ON Localidad.pcia=Provincias.id WHERE Localidad.Id= @Id"
                        .Parameters.AddWithValue("@Id", id)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Dim obj As New Localidad
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
            "Datos:Localidad", _
            "GetById", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Public Function GetAll() As List(Of Localidad)
        Try
            Dim lista As New List(Of Localidad)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT localidad.*,provincias.id IdPcia,provincias.codigo CodPcia,provincias.nombre Provincia,provincias.pais IdPais FROM Localidad LEFT JOIN Provincias ON Localidad.pcia=Provincias.id ORDER BY pcia,Localidad.Nombre"
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New Localidad
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
            "Datos:Localidad", _
            "GetAll", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    'Public Function GetAllByClientes() As List(Of Localidad)
    '    Try
    '        Dim lista As New List(Of Localidad)
    '        Using cnn As MySqlConnection = CreateConnection()
    '            cnn.Open()
    '            Using cmd As New MySqlCommand
    '                With cmd
    '                    .Connection = cnn
    '                    .CommandType = CommandType.Text
    '                    .CommandText = "SELECT * FROM Localidadescliente ORDER BY Provincia,Nombre"
    '                    Try
    '                        Using reader As MySqlDataReader = .ExecuteReader
    '                            Do While reader.Read
    '                                Dim obj = New Localidad
    '                                obj = Populate(reader)
    '                                lista.Add(obj)
    '                                obj = Nothing
    '                            Loop
    '                            Return lista
    '                        End Using
    '                    Finally
    '                        lista = Nothing
    '                    End Try
    '                End With
    '            End Using
    '        End Using
    '    Catch exError As MySqlException
    '        ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
    '        Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
    '        "Datos:Localidad", _
    '        "GetAllByClientes", _
    '        ErrorMessageString, _
    '        WriteErrorMessageString)
    '        Throw New Exception(ErrorMessageString)
    '    End Try
    'End Function

    Public Function GetByProvincia(ByVal provincia As UInt32) As List(Of Localidad)
        Try
            Dim lista As New List(Of Localidad)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT localidad.*,provincias.id IdPcia,provincias.codigo CodPcia,provincias.nombre Provincia,provincias.pais IdPais FROM Localidad LEFT JOIN Provincias ON Localidad.pcia=Provincias.id WHERE pcia = @provincia ORDER BY pcia,Localidad.Nombre"
                        .Parameters.AddWithValue("@provincia", provincia)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New Localidad
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
            "Datos:Localidad", _
            "GetByProvincia", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetProvincias() As List(Of Provincias)
        Try
            Dim lista As New List(Of Provincias)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Provincias"
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New Provincias
                                    obj.Id = reader("id")
                                    obj.Codigo = reader("codigo")
                                    obj.Nombre = reader("nombre")
                                    obj.Pais = reader("pais")
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
            "Datos:Provincia", _
            "GetProvincias", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Private Function Populate(ByVal reader As MySqlDataReader) As Localidad
        Dim obj As New Localidad

        Dim objPcia As New Provincias

        Try
            With obj
                .Id = Convert.ToUInt32(reader("Id"))
                .Nombre = Convert.ToString(reader("Nombre"))
                .Codigopostal = Convert.ToString(reader("Codigopostal"))
                .Pcia = Convert.ToUInt32(reader("IdPcia"))
                .Provincia = Convert.ToString(reader("Provincia"))

                'Esto tarda porque por cada Registro ejecuto el Select de Provincias
                '.EntPcia = GetProvincia(.Pcia)

                'Esto no tarda porque traigo todo en el mismo Select
                objPcia.Id = .Pcia
                objPcia.Codigo = Convert.ToString(reader("CodPcia"))
                objPcia.Nombre = .Provincia
                objPcia.Pais = Convert.ToUInt32(reader("IdPais"))
                .EntPcia = objPcia

            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function

    'Public Function GetProvincia(ByVal id As UInt32) As Provincias
    '    Try
    '        Using cnn As MySqlConnection = CreateConnection()
    '            cnn.Open()
    '            Using cmd As New MySqlCommand
    '                With cmd
    '                    .Connection = cnn
    '                    .CommandType = CommandType.Text
    '                    .CommandText = "SELECT * FROM Provincias WHERE Id=@Id"
    '                    .Parameters.AddWithValue("@Id", id)
    '                    Using reader As MySqlDataReader = .ExecuteReader
    '                        If (reader.Read) Then
    '                            Dim obj As New Provincias
    '                            obj = PopulatePcia(reader)
    '                            Return obj
    '                        Else
    '                            Return Nothing
    '                        End If
    '                    End Using
    '                End With
    '            End Using
    '        End Using
    '    Catch exError As MySqlException
    '        ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
    '        Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
    '        "Datos:Provincias", _
    '        "GetById", _
    '        ErrorMessageString, _
    '        WriteErrorMessageString)
    '        Throw New Exception(ErrorMessageString)
    '    End Try
    'End Function

    'Private Function PopulatePcia(ByVal reader As MySqlDataReader) As Provincias
    '    Dim obj As New Provincias
    '    Try
    '        With obj
    '            .Id = Convert.ToUInt32(reader("Id"))
    '            .Codigo = Convert.ToString(reader("Codigo"))
    '            .Nombre = Convert.ToString(reader("Nombre"))
    '            .Pais = Convert.ToUInt32(reader("Pais"))
    '        End With
    '        Return obj
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message, ex)
    '    Finally
    '        obj = Nothing
    '    End Try
    'End Function

End Class

