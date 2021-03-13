Imports Entidades
Imports MySql.Data.MySqlClient
Public Class PerfilCDat
    Private ExceptionClassObject As New ManejoDeErrores.ExceptionClass
    Private ExceptionErrorFileString As String = My.Application.Info.DirectoryPath & "\ErrorFile.log"
    Private WriteErrorMessageString As String
    Private ErrorMessageString As String
    'Public Function Insert(ByVal obj As Perfil) As UInt32
    '    Try
    '        Using cnn As MySqlConnection = CreateConnection()
    '            cnn.Open()
    '            Using cmd As New MySqlCommand
    '                With cmd
    '                    .Connection = cnn
    '                    .CommandType = CommandType.Text
    '                    .CommandText = "INSERT INTO Perfil (Id,Nombre) VALUES (@Id,@Nombre)"
    '                    .Parameters.AddWithValue("@Id", obj.Id)
    '                    .Parameters.AddWithValue("@Nombre", obj.Nombre)
    '                    .ExecuteNonQuery()
    '                    Return .LastInsertedId
    '                End With
    '            End Using
    '        End Using
    '    Catch exError As MySqlException
    '        ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
    '        Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
    '        "Datos:Perfil", _
    '        "Insert", _
    '        ErrorMessageString, _
    '        WriteErrorMessageString)
    '        Throw New Exception(ErrorMessageString)
    '    End Try
    'End Function

    Public Sub Update(ByVal obj As Perfil)

        Dim transaccion As MySqlTransaction = Nothing
        Dim cnn As MySqlConnection = Nothing
        Dim cmd As MySqlCommand
        Dim ptovta As New CbtepuntoventaCDat

        Try

            cnn = CreateConnection()
            cnn.Open()
            transaccion = cnn.BeginTransaction
            cmd = New MySqlCommand

            With cmd
                .Connection = cnn
                .Transaction = transaccion
                .CommandType = CommandType.Text
                .CommandText = "UPDATE Perfil SET Nombre = @Nombre WHERE Id = @Id"
                .Parameters.AddWithValue("@Id", obj.Id)
                .Parameters.AddWithValue("@Nombre", obj.Nombre)
                .ExecuteNonQuery()

                .CommandText = "DELETE FROM perfilpermiso WHERE perfil=@perfil"
                .Parameters.Clear()
                .Parameters.AddWithValue("@perfil", obj.Id)
                .ExecuteNonQuery()

                'registro los tributos del combrobante
                For Each objPermiso As Entidades.Perfilpermiso In obj.Permisos
                    .CommandText = "INSERT INTO perfilpermiso (id,perfil,permiso,activo,padre,hijo) "
                    .CommandText &= " VALUES (null,@perfil,@permiso,@activo,@padre,@hijo) "
                    .Parameters.Clear()
                    '.Parameters.AddWithValue("@id", id)
                    .Parameters.AddWithValue("@perfil", obj.Id)
                    .Parameters.AddWithValue("@permiso", objPermiso.Permiso)
                    .Parameters.AddWithValue("@activo", objPermiso.Activo)
                    .Parameters.AddWithValue("@padre", objPermiso.Padre)
                    .Parameters.AddWithValue("@hijo", objPermiso.Hijo)
                    .ExecuteNonQuery()
                Next

            End With

            transaccion.Commit()

        Catch exError As MySqlException

            If transaccion IsNot Nothing Then
                transaccion.Rollback()
            End If

            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Perfil", _
            "Insert", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)

        Finally
            If cnn IsNot Nothing Then
                If cnn.State = ConnectionState.Open Then
                    cnn.Close()
                End If
            End If
        End Try
    End Sub

    'Public Sub Update(ByVal obj As Perfil)
    '    Try
    '        Using cnn As MySqlConnection = CreateConnection()
    '            cnn.Open()
    '            Using cmd As New MySqlCommand
    '                With cmd
    '                    .Connection = cnn
    '                    .CommandType = CommandType.Text
    '                    .CommandText = "UPDATE Perfil SET Nombre = @Nombre WHERE Id = @Id"
    '                    .Parameters.AddWithValue("@Id", obj.Id)
    '                    .Parameters.AddWithValue("@Nombre", obj.Nombre)
    '                    .ExecuteNonQuery()
    '                End With
    '            End Using
    '        End Using
    '    Catch exError As MySqlException
    '        ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
    '        Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
    '        "Datos:Perfil", _
    '        "Update", _
    '        ErrorMessageString, _
    '        WriteErrorMessageString)
    '        Throw New Exception(ErrorMessageString)
    '    End Try
    'End Sub

    Public Sub Delete(ByVal id As UInt32)
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "DELETE FROM Perfil WHERE Id = @Id"
                        .Parameters.AddWithValue("@Id", id)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Perfil", _
            "Delete", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Sub
    Public Function GetById(ByVal id As UInt32) As Perfil
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Perfil WHERE Id= @Id"
                        .Parameters.AddWithValue("@Id", id)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Dim obj As New Perfil
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
            "Datos:Perfil", _
            "GetById", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Public Function GetAll() As List(Of Perfil)
        Try
            Dim lista As New List(Of Perfil)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Perfil"
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New Perfil
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
            "Datos:Perfil", _
            "GetAll", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Private Function Populate(ByVal reader As MySqlDataReader) As Perfil
        Dim obj As New Perfil
        Try
            With obj
                .Id = Convert.ToUInt32(reader("Id"))
                .Nombre = Convert.ToString(reader("Nombre"))
                .Permisos = GetPermisos(.Id)
            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function


    Public Function Insert(ByVal obj As Perfil) As UInt32

        Dim id As Long
        Dim transaccion As MySqlTransaction = Nothing
        Dim cnn As MySqlConnection = Nothing
        Dim cmd As MySqlCommand
        Dim ptovta As New CbtepuntoventaCDat

        Try

            cnn = CreateConnection()
            cnn.Open()
            transaccion = cnn.BeginTransaction
            cmd = New MySqlCommand

            With cmd
                .Connection = cnn
                .Transaction = transaccion
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO Perfil (Id,Nombre) VALUES (@Id,@Nombre)"
                .Parameters.AddWithValue("@Id", obj.Id)
                .Parameters.AddWithValue("@Nombre", obj.Nombre)
                .ExecuteNonQuery()

                id = .LastInsertedId

                .CommandText = "DELETE FROM perfilpermiso WHERE perfil=@perfil"
                .Parameters.Clear()
                .Parameters.AddWithValue("@perfil", id)
                .ExecuteNonQuery()

                'registro los tributos del combrobante
                For Each objPermiso As Entidades.Perfilpermiso In obj.Permisos
                    .CommandText = "INSERT INTO perfilpermiso (id,perfil,permiso,activo,padre,hijo) "
                    .CommandText &= " VALUES (null,@perfil,@permiso,@activo,@padre,@hijo) "
                    .Parameters.Clear()
                    '.Parameters.AddWithValue("@id", id)
                    .Parameters.AddWithValue("@perfil", id)
                    .Parameters.AddWithValue("@permiso", objPermiso.Permiso)
                    .Parameters.AddWithValue("@activo", objPermiso.Activo)
                    .Parameters.AddWithValue("@padre", objPermiso.Padre)
                    .Parameters.AddWithValue("@hijo", objPermiso.Hijo)
                    .ExecuteNonQuery()
                Next

            End With

            transaccion.Commit()

            Return id

        Catch exError As MySqlException

            If transaccion IsNot Nothing Then
                transaccion.Rollback()
            End If

            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Perfil", _
            "Insert", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)

        Finally
            If cnn IsNot Nothing Then
                If cnn.State = ConnectionState.Open Then
                    cnn.Close()
                End If
            End If
        End Try
    End Function

    Public Function GetPermisos(ByVal Id As UInt32) As List(Of Perfilpermiso)
        Try
            Dim lista As New List(Of Perfilpermiso)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM perfilpermiso WHERE perfil = @Id"
                        .Parameters.AddWithValue("@Id", Id)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New Perfilpermiso
                                    obj = PopulatePermiso(reader)
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
            "Datos:Cpracabecera", _
            "GetAlicuotas", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Private Function PopulatePermiso(ByVal reader As MySqlDataReader) As Perfilpermiso
        Dim obj As New Perfilpermiso
        Try
            With obj
                .Id = Convert.ToUInt32(reader("Id"))
                .Permiso = Convert.ToUInt32(reader("Permiso"))
                .Perfil = Convert.ToUInt32(reader("Perfil"))
                .Padre = Convert.ToString(reader("Padre"))
                .Hijo = Convert.ToString(reader("Hijo"))
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

