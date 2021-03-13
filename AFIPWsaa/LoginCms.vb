
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Xml
Imports System.Net
Imports System.Security
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Pkcs
Imports System.Security.Cryptography.X509Certificates
Imports System.IO
Imports System.Runtime.InteropServices


''' <summary>
''' Clase para crear objetos Login Tickets
''' </summary>
''' <remarks>
''' Ver documentacion: 
'''    Especificacion Tecnica del Webservice de Autenticacion y Autorizacion
'''    Version 1.0
'''    Departamento de Seguridad Informatica - AFIP
''' </remarks>
Class LoginTicket

    Public UniqueId As UInt32 ' Entero de 32 bits sin signo que identifica el requerimiento
    Public GenerationTime As DateTime ' Momento en que fue generado el requerimiento
    Public ExpirationTime As DateTime ' Momento en el que exoira la solicitud
    Public Service As String ' Identificacion del WSN para el cual se solicita el TA
    Public Sign As String ' Firma de seguridad recibida en la respuesta
    Public Token As String ' Token de seguridad recibido en la respuesta

    Public XmlLoginTicketRequest As XmlDocument = Nothing
    Public XmlLoginTicketResponse As XmlDocument = Nothing
    Public RutaDelCertificadoFirmante As String
    Public XmlStrLoginTicketRequestTemplate As String = "<loginTicketRequest><header><uniqueId></uniqueId><generationTime></generationTime><expirationTime></expirationTime></header><service></service></loginTicketRequest>"

    Private _verboseMode As Boolean = True

    Private Shared _globalUniqueID As UInt32 = 0 ' OJO! NO ES THREAD-SAFE

    ''' <summary>
    ''' Construye un Login Ticket obtenido del WSAA
    ''' </summary>
    ''' <param name="argServicio">Servicio al que se desea acceder</param>
    ''' <param name="argUrlWsaa">URL del WSAA</param>
    ''' <param name="argRutaCertX509Firmante">Ruta del certificado X509 (con clave privada) usado para firmar</param>
    ''' <param name="argPassword">Password del certificado X509 (con clave privada) usado para firmar</param>
    ''' <param name="argProxy">IP:port del proxy</param>
    ''' <param name="argProxyUser">Usuario del proxy</param>''' 
    ''' <param name="argProxyPassword">Password del proxy</param>
    ''' <param name="argVerbose">Nivel detallado de descripcion? true/false</param>
    ''' <remarks></remarks>
    Public Function ObtenerLoginTicketResponse( _
    ByVal argServicio As String, _
    ByVal argUrlWsaa As String, _
    ByVal argRutaCertX509Firmante As String, _
    ByVal argPassword As SecureString, _
    ByVal argProxy As String, _
    ByVal argProxyUser As String, _
    ByVal argProxyPassword As String, _
    ByVal argVerbose As Boolean _
    ) As String

        Me.RutaDelCertificadoFirmante = argRutaCertX509Firmante
        Me._verboseMode = argVerbose
        CertificadosX509Lib.VerboseMode = argVerbose

        Dim cmsFirmadoBase64 As String
        Dim loginTicketResponse As String
        Dim xmlNodoUniqueId As XmlNode
        Dim xmlNodoGenerationTime As XmlNode
        Dim xmlNodoExpirationTime As XmlNode
        Dim xmlNodoService As XmlNode
        Dim _mensajes As New StringBuilder

        ' PASO 1: Genero el Login Ticket Request
        Try
            _globalUniqueID += 1

            XmlLoginTicketRequest = New XmlDocument()
            XmlLoginTicketRequest.LoadXml(XmlStrLoginTicketRequestTemplate)

            xmlNodoUniqueId = XmlLoginTicketRequest.SelectSingleNode("//uniqueId")
            xmlNodoGenerationTime = XmlLoginTicketRequest.SelectSingleNode("//generationTime")
            xmlNodoExpirationTime = XmlLoginTicketRequest.SelectSingleNode("//expirationTime")
            xmlNodoService = XmlLoginTicketRequest.SelectSingleNode("//service")

            xmlNodoGenerationTime.InnerText = DateTime.Now.AddMinutes(-10).ToString("s")
            xmlNodoExpirationTime.InnerText = DateTime.Now.AddMinutes(+10).ToString("s")
            xmlNodoUniqueId.InnerText = CStr(_globalUniqueID)
            xmlNodoService.InnerText = argServicio
            Me.Service = argServicio

            If Me._verboseMode Then
                _mensajes.AppendLine(XmlLoginTicketRequest.OuterXml)
            End If

        Catch excepcionAlGenerarLoginTicketRequest As Exception
            Throw New Exception("***Error GENERANDO el LoginTicketRequest : " + excepcionAlGenerarLoginTicketRequest.Message + excepcionAlGenerarLoginTicketRequest.StackTrace)
        End Try

        ' PASO 2: Firmo el Login Ticket Request
        Try
            If Me._verboseMode Then
                _mensajes.appendline("***Leyendo certificado: " & RutaDelCertificadoFirmante)
            End If

            Dim certFirmante As X509Certificate2 = CertificadosX509Lib.ObtieneCertificadoDesdeArchivo(RutaDelCertificadoFirmante, argPassword)

            If Me._verboseMode Then
                _mensajes.appendline("***Firmando: ")
                _mensajes.appendline(XmlLoginTicketRequest.OuterXml)
            End If

            ' Convierto el login ticket request a bytes, para firmar
            Dim EncodedMsg As Encoding = Encoding.UTF8
            Dim msgBytes As Byte() = EncodedMsg.GetBytes(XmlLoginTicketRequest.OuterXml)

            ' Firmo el msg y paso a Base64
            Dim encodedSignedCms As Byte() = CertificadosX509Lib.FirmaBytesMensaje(msgBytes, certFirmante)
            cmsFirmadoBase64 = Convert.ToBase64String(encodedSignedCms)

        Catch excepcionAlFirmar As Exception
            Throw New Exception("***Error FIRMANDO el LoginTicketRequest : " + excepcionAlFirmar.Message)
        End Try

        ' PASO 3: Invoco al WSAA para obtener el Login Ticket Response
        Try
            If Me._verboseMode Then
                _mensajes.appendline("***Llamando al WSAA en URL: " & argUrlWsaa)
                _mensajes.appendline("***Argumento en el request:")
                _mensajes.appendline(cmsFirmadoBase64)
            End If

            Dim servicioWsaa As New wsaa.LoginCMSService()
            servicioWsaa.Url = argUrlWsaa
            If argProxy IsNot Nothing Then
                servicioWsaa.Proxy = New WebProxy(argProxy, True)
                If argProxyUser IsNot Nothing Then
                    Dim Credentials As New NetworkCredential(argProxyUser, argProxyPassword)
                    servicioWsaa.Proxy.Credentials = Credentials
                End If
            End If
            loginTicketResponse = servicioWsaa.loginCms(cmsFirmadoBase64)

            If Me._verboseMode Then
                _mensajes.appendline("***LoguinTicketResponse: ")
                _mensajes.appendline(loginTicketResponse)
            End If

        Catch excepcionAlInvocarWsaa As Exception
            Throw New Exception("***Error INVOCANDO al servicio WSAA : " + excepcionAlInvocarWsaa.Message)
        End Try


        ' PASO 4: Analizo el Login Ticket Response recibido del WSAA
        Try
            XmlLoginTicketResponse = New XmlDocument()
            XmlLoginTicketResponse.LoadXml(loginTicketResponse)

            Me.UniqueId = UInt32.Parse(XmlLoginTicketResponse.SelectSingleNode("//uniqueId").InnerText)
            Me.GenerationTime = DateTime.Parse(XmlLoginTicketResponse.SelectSingleNode("//generationTime").InnerText)
            Me.ExpirationTime = DateTime.Parse(XmlLoginTicketResponse.SelectSingleNode("//expirationTime").InnerText)
            Me.Sign = XmlLoginTicketResponse.SelectSingleNode("//sign").InnerText
            Me.Token = XmlLoginTicketResponse.SelectSingleNode("//token").InnerText
        Catch excepcionAlAnalizarLoginTicketResponse As Exception
            Throw New Exception("***Error ANALIZANDO el LoginTicketResponse : " + excepcionAlAnalizarLoginTicketResponse.Message)
        End Try

        Return loginTicketResponse

    End Function


End Class

''' <summary>
''' Libreria de utilidades para manejo de certificados
''' </summary>
''' <remarks></remarks>
Class CertificadosX509Lib

    Public Shared VerboseMode As Boolean = False

    ''' <summary>
    ''' Firma mensaje
    ''' </summary>
    ''' <param name="argBytesMsg">Bytes del mensaje</param>
    ''' <param name="argCertFirmante">Certificado usado para firmar</param>
    ''' <returns>Bytes del mensaje firmado</returns>
    ''' <remarks></remarks>
    Public Shared Function FirmaBytesMensaje( _
    ByVal argBytesMsg As Byte(), _
    ByVal argCertFirmante As X509Certificate2 _
    ) As Byte()
        Try
            ' Pongo el mensaje en un objeto ContentInfo (requerido para construir el obj SignedCms)
            Dim infoContenido As New ContentInfo(argBytesMsg)
            Dim cmsFirmado As New SignedCms(infoContenido)
            Dim _mensajes As New StringBuilder

            ' Creo objeto CmsSigner que tiene las caracteristicas del firmante
            Dim cmsFirmante As New CmsSigner(argCertFirmante)
            cmsFirmante.IncludeOption = X509IncludeOption.EndCertOnly

            If VerboseMode Then
                _mensajes.appendline("***Firmando bytes del mensaje...")
            End If
            ' Firmo el mensaje PKCS #7
            cmsFirmado.ComputeSignature(cmsFirmante)

            If VerboseMode Then
                _mensajes.appendline("***OK mensaje firmado")
            End If

            ' Encodeo el mensaje PKCS #7.
            Return cmsFirmado.Encode()
        Catch excepcionAlFirmar As Exception
            Throw New Exception("***Error al firmar: " & excepcionAlFirmar.Message)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Lee certificado de disco
    ''' </summary>
    ''' <param name="argArchivo">Ruta del certificado a leer.</param>
    ''' <returns>Un objeto certificado X509</returns>
    ''' <remarks></remarks>
    Public Shared Function ObtieneCertificadoDesdeArchivo( _
    ByVal argArchivo As String, _
    ByVal argPassword As SecureString _
    ) As X509Certificate2
        Dim objCert As New X509Certificate2
        Try
            If argPassword.IsReadOnly Then
                objCert.Import(My.Computer.FileSystem.ReadAllBytes(argArchivo), argPassword, X509KeyStorageFlags.PersistKeySet)
            Else
                objCert.Import(My.Computer.FileSystem.ReadAllBytes(argArchivo))
            End If
            Return objCert
        Catch excepcionAlImportarCertificado As Exception
            Throw New Exception(excepcionAlImportarCertificado.Message & " " & excepcionAlImportarCertificado.StackTrace)
            Return Nothing
        End Try
    End Function

End Class

''' <summary>
''' Clase principal
''' </summary>
''' <remarks></remarks>
Public Class WsaaLogin

    ' Valores por defecto, globales en esta clase
    Const DEFAULT_URLWSAAWSDL As String = "https://wsaahomo.afip.gov.ar/ws/services/LoginCms?WSDL"
    Const DEFAULT_SERVICIO As String = "wsfe"
    Const DEFAULT_CERTSIGNER As String = "c:\MiCertificadoConClavePrivada.pfx"
    Const DEFAULT_PROXY As String = Nothing
    Const DEFAULT_PROXY_USER As String = Nothing
    Const DEFAULT_PROXY_PASSWORD As String = ""
    Const DEFAULT_VERBOSE As Boolean = True
    Const DEFAULT_OUTPUTFOLDER As String = "C:"

    Private _urlWsaaWsdl As String = DEFAULT_URLWSAAWSDL
    Public Property UrlWsaaWsdl() As String
        Get
            Return _urlWsaaWsdl
        End Get
        Set(ByVal value As String)
            _urlWsaaWsdl = value
        End Set
    End Property

    Private _idServicioNegocio As String = DEFAULT_SERVICIO
    Public Property IdServicioNegocio() As String
        Get
            Return _idServicioNegocio
        End Get
        Set(ByVal value As String)
            _idServicioNegocio = value
        End Set
    End Property

    Private _rutaCertSigner As String = DEFAULT_CERTSIGNER
    Public Property RutaCertSigner() As String
        Get
            Return _rutaCertSigner
        End Get
        Set(ByVal value As String)
            _rutaCertSigner = value
        End Set
    End Property

    Private _passwordSecureString As New SecureString
    Public WriteOnly Property PasswordSecureString() As SecureString
        Set(ByVal value As SecureString)
            _passwordSecureString = value
            _passwordSecureString.MakeReadOnly()
        End Set
    End Property

    Private _proxy As String = DEFAULT_PROXY
    Public Property Proxy() As String
        Get
            Return _proxy
        End Get
        Set(ByVal value As String)
            _proxy = value

            If _proxy.Length = 0 Then
                _proxy = Nothing
            End If

        End Set
    End Property

    Private _proxyUser As String = DEFAULT_PROXY_USER
    Public Property ProxyUser() As String
        Get
            Return _proxyUser
        End Get
        Set(ByVal value As String)
            _proxyUser = value

            If _proxyUser.Length = 0 Then
                _proxyUser = Nothing
            End If

        End Set
    End Property

    Private _proxyPassword As String = DEFAULT_PROXY_PASSWORD
    Public Property ProxyPassword() As String
        Get
            Return _proxyPassword
        End Get
        Set(ByVal value As String)
            _proxyPassword = value
        End Set
    End Property

    Private _verboseMode As Boolean = DEFAULT_VERBOSE
    Public Property VerboseMode() As Boolean
        Get
            Return _verboseMode
        End Get
        Set(ByVal value As Boolean)
            _verboseMode = value
        End Set
    End Property

    Private _mensajes As New StringBuilder
    Public ReadOnly Property Mensajes() As String
        Get
            Return _mensajes.ToString
        End Get
    End Property

    Private _outputFolder As String = DEFAULT_OUTPUTFOLDER
    Public Property OutputFolder() As String
        Get
            Return _outputFolder
        End Get
        Set(ByVal value As String)
            _outputFolder = value
        End Set
    End Property

    ''' <summary>
    ''' Funcion Login
    ''' </summary>
    ''' <returns>0 si terminó bien, valores negativos si hubieron errores</returns>
    ''' <remarks></remarks>
    Public Function Login() As Integer

        ' Analizo las propiedades     
        If _urlWsaaWsdl.Length = 0 Then
            _mensajes.AppendLine("Error: no se especificó la URL del WSDL del WSAA")
            Return -1
        End If

        If _idServicioNegocio.Length = 0 Then
            _mensajes.AppendLine("Error: no se especificó el ID del servicio de negocio")
            Return -1
        End If

        If _rutaCertSigner.Length = 0 Then
            _mensajes.AppendLine("Error: no se especificó ruta del certificado firmante")
            Return -1
        End If

        If _passwordSecureString.Length = 0 Then
            _mensajes.AppendLine("Error: no se especificó password del certificado firmante")
            Return -1
        End If

        ' Argumentos OK, entonces procesar normalmente...
        Dim objTicketRespuesta As LoginTicket
        Dim strTicketRespuesta As String

        Try

            If VerboseMode Then
                _mensajes.AppendLine("***Servicio a acceder: " & IdServicioNegocio)
                _mensajes.AppendLine("***URL del WSAA: " & UrlWsaaWsdl)
                _mensajes.AppendLine("***Ruta del certificado: " & RutaCertSigner)
                _mensajes.AppendLine("***Modo verbose: " & VerboseMode)
            End If

            objTicketRespuesta = New LoginTicket

            If VerboseMode Then
                _mensajes.AppendLine("***Accediendo a " & UrlWsaaWsdl)
            End If

            strTicketRespuesta = objTicketRespuesta.ObtenerLoginTicketResponse(_idServicioNegocio, _urlWsaaWsdl, _rutaCertSigner, _passwordSecureString, _proxy, _proxyUser, _proxyPassword, _verboseMode)

            If VerboseMode Then
                _mensajes.AppendLine("***CONTENIDO DEL TICKET RESPUESTA:")
                _mensajes.AppendLine("   Token: " & objTicketRespuesta.Token)
                _mensajes.AppendLine("   Sign: " & objTicketRespuesta.Sign)
                _mensajes.AppendLine("   GenerationTime: " & CStr(objTicketRespuesta.GenerationTime))
                _mensajes.AppendLine("   ExpirationTime: " & CStr(objTicketRespuesta.ExpirationTime))
                _mensajes.AppendLine("   Service: " & objTicketRespuesta.Service)
                _mensajes.AppendLine("   UniqueID: " & CStr(objTicketRespuesta.UniqueId))
            End If

            objTicketRespuesta.XmlLoginTicketRequest.Save(OutputFolder & "\RQ.XML")
            objTicketRespuesta.XmlLoginTicketResponse.Save(OutputFolder & "\TA.XML")

        Catch excepcionAlObtenerTicket As Exception

            _mensajes.AppendLine("***EXCEPCION AL OBTENER TICKET:")
            _mensajes.AppendLine(excepcionAlObtenerTicket.Message)
            Return -10

        End Try
        Return 0
    End Function




End Class