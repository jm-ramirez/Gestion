Imports Entidades
Imports MySql.Data.MySqlClient
Public Class PersonalCDat
    Private ExceptionClassObject As New ManejoDeErrores.ExceptionClass
    Private ExceptionErrorFileString As String = My.Application.Info.DirectoryPath & "\ErrorFile.log"
    Private WriteErrorMessageString As String
    Private ErrorMessageString As String
    Public Function Insert(ByVal obj As Personal) As UInt32
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "INSERT INTO Personal (Id,Nombre,Domicilio,Telefono,Email,Login,Password,Activo,Perfil,notadecredito,descuentogral,descuentotope) VALUES (@Id,@Nombre,@Domicilio,@Telefono,@Email,@Login,md5(@Password),@Activo,@Perfil,@notadecredito,@descuentogral,@descuentotope)"
                        .Parameters.AddWithValue("@Id", obj.Id)
                        .Parameters.AddWithValue("@Nombre", obj.Nombre)
                        .Parameters.AddWithValue("@Domicilio", obj.Domicilio)
                        .Parameters.AddWithValue("@Telefono", obj.Telefono)
                        .Parameters.AddWithValue("@Email", obj.Email)
                        .Parameters.AddWithValue("@Login", obj.Login)
                        .Parameters.AddWithValue("@Password", obj.Password)
                        .Parameters.AddWithValue("@Activo", obj.Activo)
                        .Parameters.AddWithValue("@Perfil", obj.Perfil)
                        .Parameters.AddWithValue("@notadecredito", obj.Notadecredito)
                        .Parameters.AddWithValue("@descuentogral", obj.DescuentoGral)
                        .Parameters.AddWithValue("@descuentotope", obj.DescuentoTope)

                        .ExecuteNonQuery()
                        Return .LastInsertedId
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Personal", _
            "Insert", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Public Sub Update(ByVal obj As Personal)
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "UPDATE Personal SET Nombre = @Nombre,Domicilio = @Domicilio,Telefono = @Telefono,Email = @Email,"
                        .CommandText &= " Login = @Login,Password = IF(Password<>@Password,md5(@Password), @Password),Activo = @Activo,Perfil = @Perfil,"
                        .CommandText &= " notadecredito=@notadecredito,descuentogral=@descuentogral,descuentotope=@descuentotope"
                        .CommandText &= " WHERE Id = @Id"

                        .Parameters.AddWithValue("@Id", obj.Id)
                        .Parameters.AddWithValue("@Nombre", obj.Nombre)
                        .Parameters.AddWithValue("@Domicilio", obj.Domicilio)
                        .Parameters.AddWithValue("@Telefono", obj.Telefono)
                        .Parameters.AddWithValue("@Email", obj.Email)
                        .Parameters.AddWithValue("@Login", obj.Login)
                        .Parameters.AddWithValue("@Password", obj.Password)
                        .Parameters.AddWithValue("@Activo", obj.Activo)
                        .Parameters.AddWithValue("@Perfil", obj.Perfil)
                        .Parameters.AddWithValue("@notadecredito", obj.Notadecredito)
                        .Parameters.AddWithValue("@descuentogral", obj.DescuentoGral)
                        .Parameters.AddWithValue("@descuentotope", obj.DescuentoTope)

                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Personal", _
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
                        .CommandText = "DELETE FROM Personal WHERE Id = @Id"
                        .Parameters.AddWithValue("@Id", id)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Personal", _
            "Delete", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Sub
    Public Function GetById(ByVal id As UInt32) As Personal
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Personal WHERE Id= @Id"
                        .Parameters.AddWithValue("@Id", id)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Dim obj As New Personal
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
            "Datos:Personal", _
            "GetById", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function DoLogin(ByVal login As String, ByVal password As String) As Personal
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Personal WHERE login= @login AND password=md5(@password)"
                        .Parameters.AddWithValue("@login", login)
                        .Parameters.AddWithValue("@password", password)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Dim obj As New Personal
                                obj = Populate(reader)
                                obj.LoginDate = Date.Now
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
            "Datos:Personal", _
            "DoLogin", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GodMode(ByVal password As String) As Boolean
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Parametro WHERE Nombre=@nombre AND valorpredeterminado=md5(@password)"
                        .Parameters.AddWithValue("@nombre", "ClaveMaestra")
                        .Parameters.AddWithValue("@password", password)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Return True
                            Else
                                Return False
                            End If
                        End Using
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Personal", _
            "DoGodMode", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetAll() As List(Of Personal)
        Try
            Dim lista As New List(Of Personal)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM Personal"
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New Personal
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
            "Datos:Personal", _
            "GetAll", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Private Function Populate(ByVal reader As MySqlDataReader) As Personal
        Dim obj As New Personal
        Try
            With obj
                .Id = Convert.ToUInt32(reader("Id"))
                .Nombre = Convert.ToString(reader("Nombre"))
                .Domicilio = Convert.ToString(reader("Domicilio"))
                .Telefono = Convert.ToString(reader("Telefono"))
                .Email = Convert.ToString(reader("Email"))
                .Login = Convert.ToString(reader("Login"))
                .Password = Convert.ToString(reader("Password"))
                .Activo = Convert.ToBoolean(reader("Activo"))
                .Perfil = Convert.ToUInt16(reader("Perfil"))
                '.GodMode = True 'PONGO FIJO PARA QUE NO HAYA QUE PONER LA PASS PARA VENTAS EN NEGRO
                .Notadecredito = Convert.ToBoolean(reader("notadecredito"))
                .DescuentoGral = Convert.ToBoolean(reader("descuentogral"))
                .DescuentoTope = Convert.ToUInt16(reader("descuentotope"))
                .Permisos = GetPermisos(.Perfil)
            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
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

