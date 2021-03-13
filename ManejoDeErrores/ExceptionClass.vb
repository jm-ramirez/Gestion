Imports System.IO

Public Class ExceptionClass
    Inherits ObjectDisposeClass
    Private PositionStreamWriter As StreamWriter

#Region "Metodos"

    Public Sub WriteExceptionErrorToFile(ByVal pFileNamePathString As String, _
                                         ByVal pSourceObjectNameString As String, _
                                         ByVal pProcedureNameString As String, _
                                         ByVal pWriteErrorMessageString As String, _
                                         ByRef pErrorMessageString As String)

        Dim ExceptionMessageString As String
        Try

            Dim ObjectFileStream As New FileStream(pFileNamePathString, _
                                                   FileMode.Append, _
                                                   FileAccess.Write, _
                                                   FileShare.None)
            Dim ObjectStreamWriter As New StreamWriter(ObjectFileStream)
            ExceptionMessageString = "Fecha: [" & Now().ToString & "] - " & _
                                     "Origen: [" & pSourceObjectNameString & "] - " & _
                                     "Procedimiento: [" & pProcedureNameString & "] - " & _
                                     "Mensaje de Error: [" & pWriteErrorMessageString & "]."
            ObjectStreamWriter.WriteLine(Replace(ExceptionMessageString, Chr(13), ""))
            If Not ObjectStreamWriter Is Nothing Then
                ObjectStreamWriter.Flush()
                ObjectStreamWriter.Close()
            End If
            If Not ObjectFileStream Is Nothing Then
                ObjectFileStream.Close()
            End If
        Catch exError As Exception
            pErrorMessageString = "Imposible acceder al archivo de Log de la aplicación. Contacte al administrador de la aplicación." & exError.Message
        End Try
    End Sub

#End Region

#Region "Funciones"
    Public Function MensajeMySQL(ByVal pErrCode As Integer, _
                                 ByVal pErrMsg As String) As String

        Dim strMsgOriginal As String = pErrCode & " - " & pErrMsg
        Dim strMsgRetorno As String = ""

        Try
            Select Case pErrCode
                Case Is = 1062
                    'Duplicate Key
                    strMsgRetorno = "El Cód. Ingresado ya se encuentra cargado."
                Case Is = 1451
                    'Foreign Key Restrict Delete
                    strMsgRetorno = "No se puede Eliminar/Modificar el registro seleccionado, existen otros registros relacionados."
                Case Is = 1452
                    'Foreign Key Restrict Add/Update
                    strMsgRetorno = "No se puede Agregar/Modificar el Registro, el Cód. de Referencia ingresado no existe."
                Case Is = 1042
                    'Unable to Connect to any Mysql Host
                    strMsgRetorno = "No se puede realizar la conexión con la Base de Datos."
                Case Else : strMsgRetorno = "S/V "
            End Select

            Return strMsgRetorno & Chr(13) & _
                                   Chr(13) & _
                                   "Mensaje Original: " & _
                                   strMsgOriginal & _
                                   Chr(13)

        Catch ex As Exception
            Return strMsgOriginal
        End Try

    End Function

#End Region

End Class
