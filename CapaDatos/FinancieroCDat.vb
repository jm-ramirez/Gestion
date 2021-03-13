Imports Entidades
Imports MySql.Data.MySqlClient
Public Class FinancieroCDat
    Private ExceptionClassObject As New ManejoDeErrores.ExceptionClass
    Private ExceptionErrorFileString As String = My.Application.Info.DirectoryPath & "\ErrorFile.log"
    Private WriteErrorMessageString As String
    Private ErrorMessageString As String
    Public Function Insert(ByVal obj As Financiero) As UInt32
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "INSERT INTO Financiero (Id,Origen,Cuenta,Concepto,Beneficiario,Emision,Efectivizacion,Importe,Referencia,Observacion,Usuario,"
                        .CommandText &= "Fecharegistracion,Banco,Cbtevta,Cbtecpra,Cbterecibo,Cbtepago,CbteMovCtas,Tipo,Dador,Sucursal,DocumentoNro,Localidad,Deposito,Egreso,nroctabco,librador) "
                        .CommandText &= "VALUES (@Id,@Origen,@Cuenta,@Concepto,@Beneficiario,@Emision,@Efectivizacion,@Importe,@Referencia,@Observacion,@Usuario,DEFAULT,@Banco,@Cbtevta,@Cbtecpra,@Cbterecibo,@Cbtepago,@CbteMovctas,@Tipo,@Dador,@Sucursal,@DocumentoNro,@Localidad,@Deposito,@Egreso,@nroctabco,@librador)"
                        .Parameters.AddWithValue("@Id", obj.Id)
                        .Parameters.AddWithValue("@Origen", obj.Origen)
                        .Parameters.AddWithValue("@Cuenta", obj.Cuenta)
                        .Parameters.AddWithValue("@Concepto", obj.Concepto)
                        .Parameters.AddWithValue("@Beneficiario", obj.Beneficiario)
                        .Parameters.AddWithValue("@Emision", obj.Emision)
                        .Parameters.AddWithValue("@Efectivizacion", obj.Efectivizacion)
                        .Parameters.AddWithValue("@Importe", obj.Importe)
                        .Parameters.AddWithValue("@Referencia", obj.Referencia)
                        .Parameters.AddWithValue("@Observacion", obj.Observacion)
                        .Parameters.AddWithValue("@Usuario", obj.Usuario)
                        .Parameters.AddWithValue("@Fecharegistracion", obj.Fecharegistracion)
                        .Parameters.AddWithValue("@Banco", obj.Banco)
                        .Parameters.AddWithValue("@Cbtevta", Nothing)
                        .Parameters.AddWithValue("@Cbtecpra", Nothing)
                        .Parameters.AddWithValue("@Cbterecibo", Nothing)
                        .Parameters.AddWithValue("@Cbtepago", Nothing)
                        .Parameters.AddWithValue("@CbteMovCtas", obj.CbteMovCtas)
                        .Parameters.AddWithValue("@Tipo", obj.Tipo)
                        .Parameters.AddWithValue("@Dador", obj.Dador)
                        .Parameters.AddWithValue("@Sucursal", obj.Sucursal)
                        .Parameters.AddWithValue("@DocumentoNro", obj.DocumentoNro)
                        .Parameters.AddWithValue("@Localidad", obj.Localidad)
                        .Parameters.AddWithValue("@Deposito", obj.Deposito)
                        .Parameters.AddWithValue("@Egreso", obj.Egreso)
                        .Parameters.AddWithValue("@NroCtaBco", obj.Nroctabco)
                        .Parameters.AddWithValue("@Librador", obj.Librador)
                        .ExecuteNonQuery()
                        Return .LastInsertedId
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Financiero", _
            "Insert", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function InsertList(ByVal objList As List(Of Financiero)) As UInt32

        Dim transaccion As MySqlTransaction = Nothing
        Dim cnn As MySqlConnection = Nothing
        Dim cmd As MySqlCommand
        Dim lngIdNroMov As Long
        lngIdNroMov = 0

        Try
            cnn = CreateConnection()
            cnn.Open()
            transaccion = cnn.BeginTransaction

            cmd = New MySqlCommand
            With cmd
                .Connection = cnn
                .Transaction = transaccion
                .CommandType = CommandType.Text

                'Actualizo la Numeración del Param
                .CommandText = "SELECT valorpredeterminado FROM parametro WHERE nombre = @nombre FOR UPDATE;"
                .Parameters.Clear()
                .Parameters.AddWithValue("@nombre", "NroMovCuentas")
                lngIdNroMov = Convert.ToInt32(.ExecuteScalar()) + 1

                .CommandText = "UPDATE parametro SET valorpredeterminado=@cbtenumero WHERE nombre = @nombre"
                .Parameters.Clear()
                .Parameters.AddWithValue("@nombre", "NroMovCuentas")
                .Parameters.AddWithValue("@cbtenumero", lngIdNroMov)
                .ExecuteNonQuery()

                .CommandText = "INSERT INTO Financiero (Id,Origen,Cuenta,Concepto,Beneficiario,Emision,Efectivizacion,Importe,Referencia,"
                .CommandText &= "Observacion,Usuario,Fecharegistracion,Banco,Cbtevta,Cbtecpra,Cbterecibo,Cbtepago,CbteMovCtas,Tipo,Dador,Sucursal,"
                .CommandText &= "DocumentoNro,Localidad,Deposito,nroctabco,librador) VALUES (@Id,@Origen,@Cuenta,@Concepto,@Beneficiario,@Emision,@Efectivizacion,"
                .CommandText &= "@Importe,@Referencia,@Observacion,@Usuario,DEFAULT,@Banco,@Cbtevta,@Cbtecpra,@Cbterecibo,@Cbtepago,@CbteMovCtas,@Tipo,@Dador,@Sucursal,@DocumentoNro,@Localidad,@Deposito,@nroctabco,@librador)"

                For Each obj As Financiero In objList

                    .Parameters.Clear()
                    .Parameters.AddWithValue("@Id", obj.Id)
                    .Parameters.AddWithValue("@Origen", obj.Origen)
                    .Parameters.AddWithValue("@Cuenta", obj.Cuenta)
                    .Parameters.AddWithValue("@Concepto", obj.Concepto)
                    .Parameters.AddWithValue("@Beneficiario", obj.Beneficiario)
                    .Parameters.AddWithValue("@Emision", obj.Emision)
                    .Parameters.AddWithValue("@Efectivizacion", obj.Efectivizacion)
                    .Parameters.AddWithValue("@Importe", obj.Importe)
                    .Parameters.AddWithValue("@Referencia", obj.Referencia)
                    .Parameters.AddWithValue("@Observacion", obj.Observacion)
                    .Parameters.AddWithValue("@Usuario", obj.Usuario)
                    .Parameters.AddWithValue("@Fecharegistracion", obj.Fecharegistracion)
                    .Parameters.AddWithValue("@Banco", obj.Banco)

                    'validacion para mov. entre cuentas
                    If obj.Cbtevta = 0 Then
                        .Parameters.AddWithValue("@Cbtevta", Nothing)
                    Else
                        .Parameters.AddWithValue("@Cbtevta", obj.Cbtevta)
                    End If

                    'validacion para mov. entre cuentas
                    If obj.Cbtecpra = 0 Then
                        .Parameters.AddWithValue("@Cbtecpra", Nothing)
                    Else
                        .Parameters.AddWithValue("@Cbtecpra", obj.Cbtecpra)
                    End If

                    'validacion para mov. entre cuentas
                    If obj.CbteMovCtas = 0 Then
                        .Parameters.AddWithValue("@CbteMovCtas", Nothing)
                    Else
                        .Parameters.AddWithValue("@CbteMovCtas", lngIdNroMov)
                    End If

                    .Parameters.AddWithValue("@Cbterecibo", Nothing)
                    .Parameters.AddWithValue("@Cbtepago", Nothing)
                    .Parameters.AddWithValue("@Tipo", obj.Tipo)
                    .Parameters.AddWithValue("@Dador", obj.Dador)
                    .Parameters.AddWithValue("@Sucursal", obj.Sucursal)
                    .Parameters.AddWithValue("@DocumentoNro", obj.DocumentoNro)
                    .Parameters.AddWithValue("@Localidad", obj.Localidad)
                    .Parameters.AddWithValue("@Deposito", obj.Deposito)
                    .Parameters.AddWithValue("@NroCtaBco", obj.Nroctabco)
                    .Parameters.AddWithValue("@Librador", obj.Librador)
                    .ExecuteNonQuery()

                Next

                transaccion.Commit()

                Return lngIdNroMov

            End With
            
        Catch exError As MySqlException

            If transaccion IsNot Nothing Then
                transaccion.Rollback()
            End If

            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Financiero", _
            "InsertList", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function DepositoCartera(ByVal origen As List(Of Financiero), ByVal destino As Entidades.Financiero) As UInt32

        Dim transaccion As MySqlTransaction = Nothing
        Dim cnn As MySqlConnection = Nothing
        Dim cmd As MySqlCommand
        Dim lngIdDeposito As Long
        lngIdDeposito = 0

        Try
            cnn = CreateConnection()
            cnn.Open()
            transaccion = cnn.BeginTransaction

            cmd = New MySqlCommand
            With cmd
                .Connection = cnn
                .Transaction = transaccion
                .CommandType = CommandType.Text

                'Actualizo la Numeración del Param
                .CommandText = "SELECT valorpredeterminado FROM parametro WHERE nombre = @nombre FOR UPDATE;"
                .Parameters.Clear()
                .Parameters.AddWithValue("@nombre", "NroDepositoCartera")
                lngIdDeposito = Convert.ToInt32(.ExecuteScalar()) + 1

                .CommandText = "UPDATE parametro SET valorpredeterminado=@cbtenumero WHERE nombre = @nombre"
                .Parameters.Clear()
                .Parameters.AddWithValue("@nombre", "NroDepositoCartera")
                .Parameters.AddWithValue("@cbtenumero", lngIdDeposito)
                .ExecuteNonQuery()

                'registro el deposito en la cuenta seleccionada
                .CommandText = "INSERT INTO Financiero (Id,Origen,Cuenta,Concepto,Beneficiario,Emision,Efectivizacion,Importe,Referencia,"
                .CommandText &= "Observacion,Usuario,Fecharegistracion,Banco,Tipo,Dador,Sucursal,"
                .CommandText &= "DocumentoNro,Localidad,Deposito,nroctabco,librador) VALUES (@Id,@Origen,@Cuenta,@Concepto,@Beneficiario,@Emision,@Efectivizacion,"
                .CommandText &= "@Importe,@Referencia,@Observacion,@Usuario,DEFAULT,@Banco,@Tipo,@Dador,@Sucursal,@DocumentoNro,@Localidad,@Deposito,@nroctabco,@librador)"

                .Parameters.Clear()
                .Parameters.AddWithValue("@Id", destino.Id)
                .Parameters.AddWithValue("@Origen", destino.Origen)
                .Parameters.AddWithValue("@Cuenta", destino.Cuenta)
                .Parameters.AddWithValue("@Concepto", destino.Concepto)
                .Parameters.AddWithValue("@Beneficiario", destino.Beneficiario)
                .Parameters.AddWithValue("@Emision", destino.Emision)
                .Parameters.AddWithValue("@Efectivizacion", destino.Efectivizacion)
                .Parameters.AddWithValue("@Importe", destino.Importe)
                .Parameters.AddWithValue("@Referencia", destino.Referencia)
                .Parameters.AddWithValue("@Observacion", destino.Observacion)
                .Parameters.AddWithValue("@Usuario", destino.Usuario)
                .Parameters.AddWithValue("@Fecharegistracion", destino.Fecharegistracion)
                .Parameters.AddWithValue("@Banco", destino.Banco)
                .Parameters.AddWithValue("@Tipo", destino.Tipo)
                .Parameters.AddWithValue("@Dador", "* DEPOSITO CARTERA " & Convert.ToString(lngIdDeposito))
                .Parameters.AddWithValue("@Sucursal", destino.Sucursal)
                .Parameters.AddWithValue("@DocumentoNro", destino.DocumentoNro)
                .Parameters.AddWithValue("@Localidad", destino.Localidad)
                .Parameters.AddWithValue("@Deposito", lngIdDeposito)
                .Parameters.AddWithValue("@NroCtaBco", destino.Nroctabco)
                .Parameters.AddWithValue("@Librador", destino.Librador)
                .ExecuteNonQuery()

                'actualizo todos los cheques marcados a depositar
                For Each obj As Financiero In origen

                    .CommandText = "UPDATE Financiero SET Origen = @Origen,Cuenta = @Cuenta,Concepto = @Concepto,Beneficiario = @Beneficiario,"
                    .CommandText &= "Emision = @Emision,Efectivizacion = @Efectivizacion,Importe = @Importe,Referencia = @Referencia,"
                    .CommandText &= "Observacion = @Observacion,Usuario = @Usuario,Fecharegistracion = @Fecharegistracion,Banco = @Banco,"
                    .CommandText &= "Tipo = @Tipo,"
                    .CommandText &= "Dador = @Dador,Sucursal = @Sucursal,DocumentoNro = @DocumentoNro,Localidad = @Localidad, "
                    .CommandText &= "Deposito = @Deposito, Egreso = @Egreso, nroctabco = @nroctabco, librador = @librador WHERE Id = @Id"

                    .Parameters.Clear()
                    .Parameters.AddWithValue("@Id", obj.Id)
                    .Parameters.AddWithValue("@Origen", obj.Origen)
                    .Parameters.AddWithValue("@Cuenta", obj.Cuenta)
                    .Parameters.AddWithValue("@Concepto", obj.Concepto)
                    .Parameters.AddWithValue("@Beneficiario", obj.Beneficiario)
                    .Parameters.AddWithValue("@Emision", obj.Emision)
                    .Parameters.AddWithValue("@Efectivizacion", obj.Efectivizacion)
                    .Parameters.AddWithValue("@Importe", obj.Importe)
                    .Parameters.AddWithValue("@Referencia", obj.Referencia)
                    .Parameters.AddWithValue("@Observacion", obj.Observacion)
                    .Parameters.AddWithValue("@Usuario", obj.Usuario)
                    .Parameters.AddWithValue("@Fecharegistracion", obj.Fecharegistracion)
                    .Parameters.AddWithValue("@Banco", obj.Banco)
                    '.Parameters.AddWithValue("@Cbtevta", obj.Cbtevta)
                    '.Parameters.AddWithValue("@Cbtecpra", obj.Cbtecpra)
                    '.Parameters.AddWithValue("@Cbterecibo", obj.Cbterecibo)
                    '.Parameters.AddWithValue("@Cbtepago", obj.Cbtepago)
                    '.Parameters.AddWithValue("@CbteMovCtas", obj.CbteMovCtas)
                    .Parameters.AddWithValue("@Tipo", obj.Tipo)
                    .Parameters.AddWithValue("@Dador", obj.Dador)
                    .Parameters.AddWithValue("@Sucursal", obj.Sucursal)
                    .Parameters.AddWithValue("@DocumentoNro", obj.DocumentoNro)
                    .Parameters.AddWithValue("@Localidad", obj.Localidad)
                    .Parameters.AddWithValue("@Deposito", lngIdDeposito)
                    .Parameters.AddWithValue("@Egreso", obj.Egreso)
                    .Parameters.AddWithValue("@NroCtaBco", obj.Nroctabco)
                    .Parameters.AddWithValue("@Librador", obj.Librador)
                    .ExecuteNonQuery()

                Next

                transaccion.Commit()

                Return lngIdDeposito

            End With

        Catch exError As MySqlException

            If transaccion IsNot Nothing Then
                transaccion.Rollback()
            End If

            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Financiero", _
            "DepositoCartera", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Sub Update(ByVal obj As Financiero)
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "UPDATE Financiero SET Origen = @Origen,Cuenta = @Cuenta,Concepto = @Concepto,Beneficiario = @Beneficiario,Emision = @Emision,Efectivizacion = @Efectivizacion,Importe = @Importe,Referencia = @Referencia,Observacion = @Observacion,Usuario = @Usuario,Fecharegistracion = @Fecharegistracion,Banco = @Banco,Cbtevta = @Cbtevta,Cbtecpra = @Cbtecpra,Cbterecibo = @Cbterecibo,Cbtepago = @Cbtepago,CbteMovCtas = @CbteMovCtas,Tipo = @Tipo,Dador = @Dador,Sucursal = @Sucursal,DocumentoNro = @DocumentoNro,Localidad = @Localidad, Deposito = @Deposito, nroctabco = @nroctabco, librador = @librador WHERE Id = @Id"
                        .Parameters.AddWithValue("@Id", obj.Id)
                        .Parameters.AddWithValue("@Origen", obj.Origen)
                        .Parameters.AddWithValue("@Cuenta", obj.Cuenta)
                        .Parameters.AddWithValue("@Concepto", obj.Concepto)
                        .Parameters.AddWithValue("@Beneficiario", obj.Beneficiario)
                        .Parameters.AddWithValue("@Emision", obj.Emision)
                        .Parameters.AddWithValue("@Efectivizacion", obj.Efectivizacion)
                        .Parameters.AddWithValue("@Importe", obj.Importe)
                        .Parameters.AddWithValue("@Referencia", obj.Referencia)
                        .Parameters.AddWithValue("@Observacion", obj.Observacion)
                        .Parameters.AddWithValue("@Usuario", obj.Usuario)
                        .Parameters.AddWithValue("@Fecharegistracion", obj.Fecharegistracion)
                        .Parameters.AddWithValue("@Banco", obj.Banco)
                        .Parameters.AddWithValue("@Cbtevta", obj.Cbtevta)
                        .Parameters.AddWithValue("@Cbtecpra", obj.Cbtecpra)
                        .Parameters.AddWithValue("@Cbterecibo", Nothing)
                        .Parameters.AddWithValue("@Cbtepago", Nothing)
                        .Parameters.AddWithValue("@CbteMovCtas", obj.CbteMovCtas)
                        .Parameters.AddWithValue("@Tipo", obj.Tipo)
                        .Parameters.AddWithValue("@Dador", obj.Dador)
                        .Parameters.AddWithValue("@Sucursal", obj.Sucursal)
                        .Parameters.AddWithValue("@DocumentoNro", obj.DocumentoNro)
                        .Parameters.AddWithValue("@Localidad", obj.Localidad)
                        .Parameters.AddWithValue("@Deposito", obj.Deposito)
                        .Parameters.AddWithValue("@NroCtaBco", obj.Nroctabco)
                        .Parameters.AddWithValue("@Librador", obj.Librador)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Financiero", _
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
                        .CommandText = "DELETE FROM Financiero WHERE Id = @Id"
                        .Parameters.AddWithValue("@Id", id)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Financiero", _
            "Delete", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Sub

    Public Sub AnulaMovCtas(ByVal Nro As UInt32)
        Dim transaccion As MySqlTransaction = Nothing
        Dim cnn As MySqlConnection = Nothing
        Dim cmd As MySqlCommand
        Dim lngIdMov As Long
        lngIdMov = 0

        Try
            cnn = CreateConnection()
            cnn.Open()
            transaccion = cnn.BeginTransaction

            cmd = New MySqlCommand
            With cmd
                .Connection = cnn
                .Transaction = transaccion
                .CommandType = CommandType.Text

                .CommandText = "DELETE FROM Financiero WHERE CbteMovCtas = @CbteMovCtas"
                .Parameters.Clear()
                .Parameters.AddWithValue("@CbteMovCtas", Nro)
                .ExecuteNonQuery()
            End With

            transaccion.Commit()

        Catch exError As MySqlException

            If transaccion IsNot Nothing Then
                transaccion.Rollback()
            End If

            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Financiero", _
            "AnulaMovCtas", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Sub

    Public Function GetById(ByVal id As UInt32) As Financiero
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        '.CommandText = "SELECT * FROM Financiero WHERE Id= @Id"
                        .CommandText = "SELECT Financiero.*,IFNULL(`cbtecabecera`.`CbteTipo`,0) CptoVta,IFNULL(`cpracabecera`.`CbteTipo`,0) CptoCpra FROM Financiero LEFT JOIN `cbtecabecera` ON financiero.`CbteVta` = `cbtecabecera`.id"
                        .CommandText &= " LEFT JOIN `cpracabecera` ON financiero.`CbteCpra` = `cpracabecera`.id  WHERE Financiero.Id = @Id "

                        .Parameters.AddWithValue("@Id", id)
                        Using reader As MySqlDataReader = .ExecuteReader
                            If (reader.Read) Then
                                Dim obj As New Financiero
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
            "Datos:Financiero", _
            "GetById", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Public Function GetAll() As List(Of Financiero)
        Try
            Dim lista As New List(Of Financiero)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        '.CommandText = "SELECT * FROM Financiero"
                        .CommandText = "SELECT Financiero.*,IFNULL(`cbtecabecera`.`CbteTipo`,0) CptoVta,IFNULL(`cpracabecera`.`CbteTipo`,0) CptoCpra FROM Financiero LEFT JOIN `cbtecabecera` ON financiero.`CbteVta` = `cbtecabecera`.id"
                        .CommandText &= " LEFT JOIN `cpracabecera` ON financiero.`CbteCpra` = `cpracabecera`.id"

                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New Financiero
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
            "Datos:Financiero", _
            "GetAll", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetAllCheques() As List(Of Financiero)
        Try
            Dim lista As New List(Of Financiero)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text

                        .CommandText = "SELECT f.id,f.`Referencia`,f.`Efectivizacion`,f.`Emision`,f.`Dador`,f.`Importe`,f.`Tipo`,"
                        .CommandText &= " b.`nombre` Banco,l.`nombre` Localidad,f.`DocumentoNro`,f.`Egreso`,f.`Beneficiario`,"
                        .CommandText &= " CONCAT(LPAD(CAST(IFNULL(cb.`CbtePtoVta`,0) AS CHAR),4,'0'),'-',LPAD(CAST(IFNULL(cb.`CbteNumero`,0) AS CHAR),8,'0')) NroRecibo,cb.RazonSocial Cliente, "
                        .CommandText &= " CONCAT(LPAD(CAST(IFNULL(cp.`CbtePtoVta`,0) AS CHAR),4,'0'),'-',LPAD(CAST(IFNULL(cp.`CbteNumero`,0) AS CHAR),8,'0')) NroOP,cp.RazonSocial Proveedor,f.`Observacion`,f.`Concepto`,f.nroctabco,f.librador "
                        .CommandText &= " FROM financiero f LEFT JOIN banco b ON f.banco=b.codigo LEFT JOIN localidad l ON f.localidad=l.id"
                        .CommandText &= " LEFT JOIN cbtecabecera cb ON f.`CbteVta`=cb.`Id` LEFT JOIN cpracabecera cp ON f.`CbteCpra`=cp.`Id`"
                        .CommandText &= " WHERE f.cuenta='cartera'"

                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New Financiero
                                    obj = PopulateCheque(reader)
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
            "Datos:Financiero", _
            "GetAllCheques", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function
    Public Sub Rechazar(ByVal Id As Integer, ByVal Tipo As String)
        Try
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "UPDATE Financiero SET Concepto = '017',Tipo = @Tipo WHERE Id = @Id"
                        .Parameters.AddWithValue("@Id", Id)
                        .Parameters.AddWithValue("@Tipo", Tipo)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Financiero", _
            "Rechazar", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Sub
    Public Function GetByCuenta(ByVal cuenta As String) As List(Of Financiero)
        Try
            Dim lista As New List(Of Financiero)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        '.CommandText = "SELECT Financiero.* FROM Financiero WHERE cuenta = @cuenta"
                        .CommandText = "SELECT Financiero.*,IFNULL(`cbtecabecera`.`CbteTipo`,0) CptoVta,IFNULL(`cpracabecera`.`CbteTipo`,0) CptoCpra FROM Financiero LEFT JOIN `cbtecabecera` ON financiero.`CbteVta` = `cbtecabecera`.id"
                        .CommandText &= " LEFT JOIN `cpracabecera` ON financiero.`CbteCpra` = `cpracabecera`.id  WHERE cuenta = @cuenta"

                        .Parameters.AddWithValue("@cuenta", cuenta)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New Financiero
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
            "Datos:Financiero", _
            "GetAll", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetMovCtas(Optional ByVal pstrWhere As String = "0=0") As List(Of Financiero)
        Try
            Dim lista As New List(Of Financiero)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT Financiero.*,IFNULL(`cbtecabecera`.`CbteTipo`,0) CptoVta,IFNULL(`cpracabecera`.`CbteTipo`,0) CptoCpra FROM Financiero LEFT JOIN `cbtecabecera` ON financiero.`CbteVta` = `cbtecabecera`.id"
                        .CommandText &= " LEFT JOIN `cpracabecera` ON financiero.`CbteCpra` = `cpracabecera`.id  "
                        .CommandText &= "WHERE " & pstrWhere & " "
                        .CommandText &= "GROUP BY CbteMovCtas HAVING CbteMovCtas<>0 ORDER BY CbteMovCtas DESC"
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New Financiero
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
            "Datos:Financiero", _
            "GetMovCtas", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetSaldo(ByVal cuenta As String, ByVal fecha As Date, Optional ByVal todo As Boolean = False) As Double
        Try
            Dim saldo As Double = 0
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        '.CommandText = "SELECT IFNULL(SUM(IF(Tipo='C',Importe*-1,Importe)),0) Saldo FROM Financiero "
                        '.CommandText &= " WHERE cuenta = @cuenta"
                        '.CommandText &= " AND Efectivizacion <= @fecha"
                        '.CommandText &= " GROUP BY Cuenta"

                        .CommandText = "SELECT IFNULL(SUM(IF(financiero.Tipo='C',Importe*-1,Importe)),0) Saldo"
                        .CommandText &= " FROM(Financiero)"
                        .CommandText &= " LEFT JOIN cbtecabecera ON ifnull(financiero.`CbteVta`,0) = `cbtecabecera`.`Id`"
                        .CommandText &= " WHERE cuenta = @cuenta"
                        .CommandText &= " AND Efectivizacion <= @fecha"
                        .CommandText &= " AND ifnull(cbtecabecera.`CbteTipo`,0) NOT IN (991,992)"
                        .CommandText &= " GROUP BY Cuenta"


                        .Parameters.AddWithValue("@cuenta", cuenta)
                        .Parameters.AddWithValue("@fecha", fecha)

                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read

                                    saldo += reader("Saldo")

                                Loop
                                Return saldo
                            End Using
                        Finally
                            saldo = Nothing
                        End Try
                    End With
                End Using
            End Using
        Catch exError As MySqlException
            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Financiero", _
            "GetSaldo", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Private Function Populate(ByVal reader As MySqlDataReader) As Financiero
        Dim obj As New Financiero
        Try
            With obj
                .Id = Convert.ToUInt32(reader("Id"))
                .Origen = Convert.ToString(reader("Origen"))
                .Cuenta = Convert.ToString(reader("Cuenta"))
                .Concepto = Convert.ToString(reader("Concepto"))

                If Not IsDBNull(reader("Beneficiario")) Then
                    .Beneficiario = Convert.ToString(reader("Beneficiario"))
                Else
                    .Beneficiario = ""
                End If

                .Emision = Convert.ToDateTime(reader("Emision"))

                If Not IsDBNull(reader("Egreso")) Then
                    .Egreso = Convert.ToDateTime(reader("Egreso"))
                End If

                .Efectivizacion = Convert.ToDateTime(reader("Efectivizacion"))
                .Importe = Convert.ToDouble(reader("Importe"))

                If Not IsDBNull(reader("Referencia")) Then
                    .Referencia = Convert.ToString(reader("Referencia"))
                End If

                If Not IsDBNull(reader("Observacion")) Then
                    .Observacion = Convert.ToString(reader("Observacion"))
                End If

                .Usuario = Convert.ToUInt32(reader("Usuario"))
                .Fecharegistracion = Convert.ToDateTime(reader("Fecharegistracion"))
                .Banco = Convert.ToUInt32(reader("Banco"))

                If Not IsDBNull(reader("Cbtevta")) Then
                    .Cbtevta = Convert.ToUInt32(reader("Cbtevta"))
                End If

                If Not IsDBNull(reader("Cbtecpra")) Then
                    .Cbtecpra = Convert.ToUInt32(reader("Cbtecpra"))
                End If

                'If Not IsDBNull(reader("Cbterecibo")) Then
                '    .Cbterecibo = Convert.ToUInt32(reader("Cbterecibo"))
                'End If

                'If Not IsDBNull(reader("Cbtepago")) Then
                '    .Cbtepago = Convert.ToUInt32(reader("Cbtepago"))
                'End If

                If Not IsDBNull(reader("CbteMovCtas")) Then
                    .CbteMovCtas = Convert.ToUInt32(reader("CbteMovCtas"))
                End If

                If Not IsDBNull(reader("Localidad")) Then
                    .Localidad = Convert.ToUInt32(reader("Localidad"))
                End If

                .Tipo = Convert.ToString(reader("Tipo"))

                If Not IsDBNull(reader("Dador")) Then
                    .Dador = Convert.ToString(reader("Dador"))
                End If

                .Sucursal = Convert.ToUInt32(reader("Sucursal"))

                If Not IsDBNull(reader("DocumentoNro")) Then
                    .DocumentoNro = reader("DocumentoNro")
                End If

                .Deposito = Convert.ToUInt32(reader("Deposito"))

                If Not IsDBNull(reader("CptoVta")) Then
                    .CptoVta = Convert.ToUInt32(reader("CptoVta"))
                End If

                If Not IsDBNull(reader("CptoCpra")) Then
                    .CptoCpra = Convert.ToUInt32(reader("CptoCpra"))
                End If

                Select Case Trim(Convert.ToString(reader("Concepto")))
                    Case "013"
                        .EstadoDet = "EN CARTERA"
                    Case "014"
                        .EstadoDet = "PASADO"
                    Case "015"
                        .EstadoDet = "DEPOSITADO"
                    Case "017"
                        .EstadoDet = "RECHAZADO"
                    Case Else
                        .EstadoDet = ""
                End Select

                .Nroctabco = Trim(Convert.ToString(reader("nroctabco")))
                .Librador = Trim(Convert.ToString(reader("librador")))

            End With
            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function
    Private Function PopulateCheque(ByVal reader As MySqlDataReader) As Financiero
        Dim obj As New Financiero
        Try
            With obj
                .Id = Convert.ToUInt32(reader("id"))
                .Referencia = Convert.ToString(reader("Referencia"))
                .Efectivizacion = Convert.ToDateTime(reader("Efectivizacion"))
                .Emision = Convert.ToDateTime(reader("Emision"))
                .Dador = Convert.ToString(reader("Dador"))
                .Importe = Convert.ToDouble(reader("Importe"))
                .Tipo = Convert.ToString(reader("Tipo"))
                .NombreBanco = Convert.ToString(reader("Banco"))
                .NombreLocalidad = Convert.ToString(reader("Localidad"))
                If Not IsDBNull(reader("DocumentoNro")) Then
                    .DocumentoNro = reader("DocumentoNro")
                End If
                If Not IsDBNull(reader("Egreso")) Then
                    .Egreso = Convert.ToDateTime(reader("Egreso"))
                End If
                If Not IsDBNull(reader("Beneficiario")) Then
                    .Beneficiario = Convert.ToString(reader("Beneficiario"))
                Else
                    .Beneficiario = ""
                End If
                .NroRecibo = Convert.ToString(reader("NroRecibo"))
                .NroOp = Convert.ToString(reader("NroOP"))
                .Observacion = Convert.ToString(reader("Observacion"))

                .Cliente = Convert.ToString(reader("Cliente"))
                .Proveedor = Convert.ToString(reader("Proveedor"))

                Select Case Trim(Convert.ToString(reader("Concepto")))
                    Case "013"
                        .EstadoDet = "EN CARTERA"
                    Case "014"
                        .EstadoDet = "PASADO"
                    Case "015"
                        .EstadoDet = "DEPOSITADO"
                    Case "017"
                        .EstadoDet = "RECHAZADO"
                    Case Else
                        .EstadoDet = ""
                End Select

                .Nroctabco = Trim(Convert.ToString(reader("nroctabco")))
                .Librador = Trim(Convert.ToString(reader("librador")))

            End With

            Return obj
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        Finally
            obj = Nothing
        End Try
    End Function
    Public Function GetChequesDeposito(ByVal cuenta As String, ByVal concepto As String, ByVal deposito As Int32) As List(Of Financiero)
        Try
            Dim lista As New List(Of Financiero)

            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        '.CommandText = "SELECT Financiero.* FROM Financiero WHERE cuenta = @cuenta"
                        .CommandText = "SELECT Financiero.*,IFNULL(`cbtecabecera`.`CbteTipo`,0) CptoVta,IFNULL(`cpracabecera`.`CbteTipo`,0) CptoCpra FROM Financiero LEFT JOIN `cbtecabecera` ON financiero.`CbteVta` = `cbtecabecera`.id"
                        .CommandText &= " LEFT JOIN `cpracabecera` ON financiero.`CbteCpra` = `cpracabecera`.id  WHERE financiero.cuenta = @cuenta AND financiero.concepto = @concepto AND financiero.deposito=@deposito"

                        .Parameters.Clear()
                        .Parameters.AddWithValue("@concepto", concepto)
                        .Parameters.AddWithValue("@cuenta", cuenta)
                        .Parameters.AddWithValue("@deposito", deposito)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New Financiero
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
            "Datos:Financiero", _
            "GetChequesDeposito", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetDeposito(ByVal deposito As Int32) As List(Of Financiero)
        Try
            Dim lista As New List(Of Financiero)

            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        '.CommandText = "SELECT Financiero.* FROM Financiero WHERE cuenta = @cuenta"
                        .CommandText = "SELECT Financiero.*,IFNULL(`cbtecabecera`.`CbteTipo`,0) CptoVta,IFNULL(`cpracabecera`.`CbteTipo`,0) CptoCpra FROM Financiero LEFT JOIN `cbtecabecera` ON financiero.`CbteVta` = `cbtecabecera`.id"
                        .CommandText &= " LEFT JOIN `cpracabecera` ON financiero.`CbteCpra` = `cpracabecera`.id  WHERE financiero.deposito=@deposito"

                        .Parameters.Clear()
                        .Parameters.AddWithValue("@deposito", deposito)
                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    Dim obj = New Financiero
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
            "Datos:Financiero", _
            "GetDeposito", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function AnulaDepositoCartera(ByVal origen As List(Of Financiero), ByVal destino As Entidades.Financiero) As UInt32

        Dim transaccion As MySqlTransaction = Nothing
        Dim cnn As MySqlConnection = Nothing
        Dim cmd As MySqlCommand

        Try
            cnn = CreateConnection()
            cnn.Open()
            transaccion = cnn.BeginTransaction

            cmd = New MySqlCommand
            With cmd
                .Connection = cnn
                .Transaction = transaccion
                .CommandType = CommandType.Text

                'registro el deposito en la cuenta seleccionada
                .CommandText = "INSERT INTO Financiero (Id,Origen,Cuenta,Concepto,Beneficiario,Emision,Efectivizacion,Importe,Referencia,"
                .CommandText &= "Observacion,Usuario,Fecharegistracion,Banco,Tipo,Dador,Sucursal,"
                .CommandText &= "DocumentoNro,Localidad,Deposito) VALUES (@Id,@Origen,@Cuenta,@Concepto,@Beneficiario,@Emision,@Efectivizacion,"
                .CommandText &= "@Importe,@Referencia,@Observacion,@Usuario,DEFAULT,@Banco,@Tipo,@Dador,@Sucursal,@DocumentoNro,@Localidad,@Deposito)"

                .Parameters.Clear()
                .Parameters.AddWithValue("@Id", destino.Id)
                .Parameters.AddWithValue("@Origen", destino.Origen)
                .Parameters.AddWithValue("@Cuenta", destino.Cuenta)
                .Parameters.AddWithValue("@Concepto", destino.Concepto)
                .Parameters.AddWithValue("@Beneficiario", destino.Beneficiario)
                .Parameters.AddWithValue("@Emision", destino.Emision)
                .Parameters.AddWithValue("@Efectivizacion", destino.Efectivizacion)
                .Parameters.AddWithValue("@Importe", destino.Importe)
                .Parameters.AddWithValue("@Referencia", destino.Referencia)
                .Parameters.AddWithValue("@Observacion", destino.Observacion)
                .Parameters.AddWithValue("@Usuario", destino.Usuario)
                .Parameters.AddWithValue("@Fecharegistracion", destino.Fecharegistracion)
                .Parameters.AddWithValue("@Banco", destino.Banco)
                .Parameters.AddWithValue("@Tipo", destino.Tipo)
                .Parameters.AddWithValue("@Dador", destino.Dador)
                .Parameters.AddWithValue("@Sucursal", destino.Sucursal)
                .Parameters.AddWithValue("@DocumentoNro", destino.DocumentoNro)
                .Parameters.AddWithValue("@Localidad", destino.Localidad)
                .Parameters.AddWithValue("@Deposito", destino.Deposito)
                .ExecuteNonQuery()

                'actualizo todos los cheques marcados a depositar
                For Each obj As Financiero In origen

                    .CommandText = "UPDATE Financiero SET Origen = @Origen,Cuenta = @Cuenta,Concepto = @Concepto,Beneficiario = @Beneficiario,"
                    .CommandText &= "Emision = @Emision,Efectivizacion = @Efectivizacion,Importe = @Importe,Referencia = @Referencia,"
                    .CommandText &= "Observacion = @Observacion,Usuario = @Usuario,Fecharegistracion = @Fecharegistracion,Banco = @Banco,"
                    .CommandText &= "Tipo = @Tipo,"
                    .CommandText &= "Dador = @Dador,Sucursal = @Sucursal,DocumentoNro = @DocumentoNro,Localidad = @Localidad, "
                    .CommandText &= "Deposito = @Deposito, Egreso = @Egreso WHERE Id = @Id"

                    .Parameters.Clear()
                    .Parameters.AddWithValue("@Id", obj.Id)
                    .Parameters.AddWithValue("@Origen", obj.Origen)
                    .Parameters.AddWithValue("@Cuenta", obj.Cuenta)
                    .Parameters.AddWithValue("@Concepto", obj.Concepto)
                    .Parameters.AddWithValue("@Beneficiario", obj.Beneficiario)
                    .Parameters.AddWithValue("@Emision", obj.Emision)
                    .Parameters.AddWithValue("@Efectivizacion", obj.Efectivizacion)
                    .Parameters.AddWithValue("@Importe", obj.Importe)
                    .Parameters.AddWithValue("@Referencia", obj.Referencia)
                    .Parameters.AddWithValue("@Observacion", obj.Observacion)
                    .Parameters.AddWithValue("@Usuario", obj.Usuario)
                    .Parameters.AddWithValue("@Fecharegistracion", obj.Fecharegistracion)
                    .Parameters.AddWithValue("@Banco", obj.Banco)
                    '.Parameters.AddWithValue("@Cbtevta", obj.Cbtevta)
                    '.Parameters.AddWithValue("@Cbtecpra", obj.Cbtecpra)
                    '.Parameters.AddWithValue("@Cbterecibo", obj.Cbterecibo)
                    '.Parameters.AddWithValue("@Cbtepago", obj.Cbtepago)
                    '.Parameters.AddWithValue("@CbteMovCtas", obj.CbteMovCtas)
                    .Parameters.AddWithValue("@Tipo", obj.Tipo)
                    .Parameters.AddWithValue("@Dador", obj.Dador)
                    .Parameters.AddWithValue("@Sucursal", obj.Sucursal)
                    .Parameters.AddWithValue("@DocumentoNro", obj.DocumentoNro)
                    .Parameters.AddWithValue("@Localidad", obj.Localidad)
                    .Parameters.AddWithValue("@Deposito", obj.Deposito)
                    .Parameters.AddWithValue("@Egreso", obj.Egreso)
                    .ExecuteNonQuery()

                Next

                .CommandText = "UPDATE financiero SET AnulacionDeposito = NOW() WHERE deposito=@deposito"
                .Parameters.Clear()
                .Parameters.AddWithValue("@deposito", destino.Deposito)

                .ExecuteNonQuery()

                transaccion.Commit()

                Return .LastInsertedId

            End With

        Catch exError As MySqlException

            If transaccion IsNot Nothing Then
                transaccion.Rollback()
            End If

            ErrorMessageString = ExceptionClassObject.MensajeMySQL(exError.Number, exError.Message)
            Call ExceptionClassObject.WriteExceptionErrorToFile(ExceptionErrorFileString, _
            "Datos:Financiero", _
            "DepositoCartera", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

    Public Function GetNroDepositos() As List(Of UInteger)
        Try
            Dim lista As New List(Of UInteger)
            Using cnn As MySqlConnection = CreateConnection()
                cnn.Open()
                Using cmd As New MySqlCommand
                    With cmd
                        .Connection = cnn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT DISTINCT(f.`Deposito`) Deposito FROM financiero f WHERE f.`Deposito` > 0 AND ISNULL(f.AnulacionDeposito) ORDER BY f.`Deposito` DESC"


                        Try
                            Using reader As MySqlDataReader = .ExecuteReader
                                Do While reader.Read
                                    lista.Add(reader("Deposito"))
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
            "Datos:Financiero", _
            "GetNroDepositos", _
            ErrorMessageString, _
            WriteErrorMessageString)
            Throw New Exception(ErrorMessageString)
        End Try
    End Function

End Class

