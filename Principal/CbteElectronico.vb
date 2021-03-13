Imports Microsoft.VisualBasic.FileIO.FileSystem
Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO
Imports System.Text
Imports System.Security

Public Class CbteElectronico

    Private objWSFEV1 As New wsfev1.Service
    Private FEAuthRequest As New wsfev1.FEAuthRequest
    Private _generationTime As New DateTime
    Private _expirationTime As New DateTime
    Private _token As String = ""
    Private _sign As String = ""
    Private _cuit As String = ""
    Private _conectado As Boolean
    Public ReadOnly mensajes As New StringBuilder()
    Const AFIP_COD_IMPUESTO_INTERNO As Long = 4
    Event Status(ByVal status As String)

    Property AppServerStatus As String
    Property DbServerStatus As String
    Property AuthServerStatus As String

    'Tipo de documento fiscal
    Const FACTURA_FISCAL As String = "F"
    Const NOTA_CREDITO_FISCAL As String = "N"
    Const TIQUE_FACTURA_FISCAL As String = "T"
    Const TIQUE_NOTA_CREDITO_FISCAL As String = "M"

    'Tipo de salida impresa
    Const FORMULARIO_CONTINUO As String = "C"
    Const HOJA_SUELTA As String = "S"

    'Letra del documento fiscal
    Const LETRA_FISCAL_A As String = "A"
    Const LETRA_FISCAL_B As String = "B"
    Const LETRA_FISCAL_C As String = "C"
    Const LETRA_FISCAL_X As String = "X"

    'Tipo de formulario que se utiliza para la factura emitida en hoja suelta
    'o continuo
    Const FORMULARIO_PREIMPRESO As String = "F"
    Const FORMULARIO_IMPRESO As String = "P"
    Const FORMULARIO_AUTOIMPRESOR As String = "A"

    'Densidad de impresion
    Const DENSIDAD_12CPI = "12"
    Const DENSIDAD_17CPI = "17"

    'Responsabilidad frente al IVA
    Const IVA_RESPONSABLE_INSCRITO As String = "I"
    Const IVA_RESPONSABLE_NO_INSCRITO As String = "R"
    Const IVA_NO_RESPONSABLE As String = "N"
    Const IVA_EXENTO As String = "E"
    Const IVA_RESPONSABLE_MONOTRIBUTO As String = "M"
    Const IVA_CONSUMIDOR_FINAL As String = "F"
    Const IVA_SUJETO_NO_CATEGORIZADO As String = "S"
    Const IVA_MONOTRIBUTISTA_SOCIAL As String = "T"
    Const IVA_CONTRIBUYENTE_EVENTUAL As String = "C"
    Const IVA_CONTRIBUYENTE_EVENTUAL_SOCIAL As String = "V"

    'Tipo documento
    Const DOC_CUIL As String = "CUIL"
    Const DOC_CUIT As String = "CUIT"
    Const DOC_DNI As String = "DNI"

    'Formatos Fiscales
    Const FORMATO_CANTIDAD As String = "00000.000"
    Const FORMATO_IMPORTE As String = "0000000.0000"
    Const FORMATO_ALICUOTA As String = "00.00"
    Const FORMATO_IMPUESTO_INTERNO As String = "0000000.00000000"

    Private EpsonOCX As EpsonFPHostControlX.EpsonFPHostControl

    Public Function ConexionConAFIP() As Boolean
        objWSFEV1.Url = My.Settings.UrlWsfe

        Dim RUTATICKETACCESO = My.Settings.WsaaRutaTicket & "\TA.xml"      ' Debe indicar la Ruta de su Ticket de acceso
        Dim tokenBytes As Byte()
        Dim tokenString As String

        mensajes.Clear()

        ' Obtengo del tikcet de acceso los campos token, sign y las CUIT del tag relations
        If FileExists(RUTATICKETACCESO) Then
            Dim xmldCredentials As XmlDocument
            Dim xmlnlCredentials As XmlNodeList
            Dim xmlnCredentials As XmlNode

            Dim xmldHeader As XmlDocument
            Dim xmlnlHeader As XmlNodeList
            Dim xmlnHeader As XmlNode

            xmldHeader = New XmlDocument()
            xmldHeader.Load(RUTATICKETACCESO)
            xmlnlHeader = xmldHeader.SelectNodes("/loginTicketResponse/header")

            For Each xmlnHeader In xmlnlHeader
                _generationTime = Convert.ToDateTime(xmlnHeader.ChildNodes.Item(3).InnerText)
                _expirationTime = Convert.ToDateTime(xmlnHeader.ChildNodes.Item(4).InnerText)
            Next

            xmldCredentials = New XmlDocument()
            xmldCredentials.Load(RUTATICKETACCESO)
            xmlnlCredentials = xmldCredentials.SelectNodes("/loginTicketResponse/credentials")

            For Each xmlnCredentials In xmlnlCredentials
                _token = xmlnCredentials.ChildNodes.Item(0).InnerText
                _sign = xmlnCredentials.ChildNodes.Item(1).InnerText

                tokenBytes = System.Convert.FromBase64String(xmlnCredentials.ChildNodes.Item(0).InnerText)
                tokenString = System.Text.Encoding.UTF8.GetString(tokenBytes)
                Dim xmldToken As XmlDocument
                Dim xmlnlToken As XmlNodeList
                Dim xmlnToken As XmlNode
                xmldToken = New XmlDocument()
                xmldToken.LoadXml(tokenString)
                xmlnlToken = xmldToken.SelectNodes("/sso/operation/login/relations/relation")
                For Each xmlnToken In xmlnlToken
                    _cuit = xmlnToken.Attributes("key").InnerText
                Next
            Next

            FEAuthRequest.Token = _token
            FEAuthRequest.Sign = _sign
            FEAuthRequest.Cuit = _cuit

            If _expirationTime < Date.Now Then
                mensajes.AppendLine("Certificado expirado")
                ShowStatus("Certificado expirado")
                Return False
            End If

        Else
            mensajes.AppendLine("No se encontró el ticket de acceso (Archivo: " + RUTATICKETACCESO + ").")
            ShowStatus("No se encontró el ticket de acceso (Archivo: " + RUTATICKETACCESO + ").")
            Return False
        End If

        ChequearStatusServer()

        Return True

    End Function

    Private Sub ShowStatus(ByVal status As String)
        RaiseEvent Status(status)
    End Sub

    ''' <summary>
    ''' Crear un ticket de acceso con los servidores de AFIP
    ''' </summary>
    ''' <returns>Devuelve cero si no se produjo errores</returns>
    ''' <remarks></remarks>
    Public Function CrearConexionAFIP() As Integer
        Dim wsaa As New AFIPWsaa.WsaaLogin
        Dim ret As Integer
        Dim password As New SecureString

        Try

            For Each character As Char In My.Settings.WsaaCertificadoPassword.ToCharArray
                password.AppendChar(character)
            Next

            With wsaa
                .IdServicioNegocio = My.Settings.WsaaIdServicio
                .OutputFolder = My.Settings.WsaaRutaTicket
                .PasswordSecureString = password
                .Proxy = ""
                .ProxyPassword = ""
                .RutaCertSigner = My.Settings.WsaaCertificado
                .UrlWsaaWsdl = My.Settings.UrlWsaa
                .VerboseMode = True
                ret = .Login()

                If ret < 0 Then Throw New Exception(.Mensajes)

            End With

            Return ret

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return ret
        End Try

    End Function

    Public Function AutorizarCbte(ByVal cbte As Entidades.CbteCabecera) As Entidades.CbteCabecera

        Dim objFECAECabRequest As New wsfev1.FECAECabRequest
        Dim objFECAERequest As New wsfev1.FECAERequest
        Dim objFECAEResponse As New wsfev1.FECAEResponse

        Dim indicemax As Integer = 0
        Dim indice As Integer = 0
        Dim arrayFECAEDetRequest(indicemax) As wsfev1.FECAEDetRequest
        Dim cbteConsulta As New Entidades.CbteCabecera

        Dim ultimoCbte As UInt32 = 0

        Try


            If Not ConexionConAFIP() Then

                CrearConexionAFIP()

                If Not ConexionConAFIP() Then
                    Throw New Exception("No se puede establecer la conexión con el WSAA")
                End If

            End If

            ' Llamo a un servicio nulo, para obtener el estado del servidor (opcional)
            ChequearStatusServer()

            ShowStatus("Estado del servidor de aplicacions -> " & AppServerStatus)

            ShowStatus("Estado del servidor de BD -> " & DbServerStatus)

            ShowStatus("Estado del servidor de Autenticación -> " & AuthServerStatus)

            ultimoCbte = UltimoCbteAutorizado(cbte.CbtePtoVta, cbte.CbteTipo)

            ShowStatus("Ult. Comprobante Autorizado -> " & ultimoCbte)

            ultimoCbte = ultimoCbte + 1

            If cbte.CbteNumero <> ultimoCbte Then

                ShowStatus("Reproceso de comprobante -> " & cbte.CbteNumero)
                '---------------------------------------------------------------------------------------
                '   verifico la integridad del la operacion para asegurarme que el comprobante que
                '   intento registrar no se encuentra registrado con anterioridad
                '---------------------------------------------------------------------------------------
                cbteConsulta = ConsultarCbte(cbte.CbteTipo, cbte.CbtePtoVta, cbte.CbteNumero)

                '   ups! este comprobante ya habia sido registrado
                If cbteConsulta.CAE <> "" Then
                    ShowStatus("Consulta de comprobante, CAE -> " & cbteConsulta.CAE)

                    'CHEQUEO QUE SEA EL MISMO COMPROBANTE
                    If Math.Abs(cbteConsulta.ImporteTotal - cbte.ImporteTotal) > 0.001 Or cbteConsulta.DocumentoNro <> cbte.DocumentoNro Then

                        cbte.CAE = ""
                        cbte.Resultado = "R"
                        Throw New Exception("El Total registrado ($ " & Format(cbteConsulta.ImporteTotal, "0.00") & ") para el CAE Nº: " & cbteConsulta.CAE & " - Fecha: " & cbteConsulta.CbteFecha & " no concuerda con el Total enviado en este comprobante. Documento del cliente:" & cbteConsulta.DocumentoNro)

                    Else


                        cbte.CAE = cbteConsulta.CAE
                        cbte.CbteFecha = cbteConsulta.CbteFecha
                        cbte.FechaVtoCAE = cbteConsulta.FechaVtoCAE
                        cbte.Observaciones = cbteConsulta.Observaciones
                        cbte.Eventos = cbteConsulta.Eventos
                        cbte.Errores = cbteConsulta.Errores
                        cbte.CuitEmisor = FEAuthRequest.Cuit
                        cbte.Resultado = cbteConsulta.Resultado
                        cbte.Reproceso = cbteConsulta.Reproceso
                        'devuelvo el comprobante consultado
                        Return cbte

                    End If


                End If
                '
                '---------------------------------------------------------------------------------------
            End If

            objFECAECabRequest.CantReg = 1
            objFECAECabRequest.CbteTipo = cbte.CbteTipo
            objFECAECabRequest.PtoVta = cbte.CbtePtoVta

            Dim objFECAEDetRequest As New wsfev1.FECAEDetRequest
            With objFECAEDetRequest
                .Concepto = cbte.Concepto
                .DocTipo = cbte.DocumentoTipo
                .DocNro = cbte.DocumentoNro
                .CbteDesde = cbte.CbteNumero
                .CbteHasta = cbte.CbteNumero
                .CbteFch = cbte.CbteFecha
                .ImpTotal = cbte.ImporteTotal
                .ImpTotConc = cbte.ImporteTotalConceptos
                .ImpNeto = cbte.ImporteNeto
                .ImpOpEx = cbte.ImporteOpExentas
                .ImpTrib = cbte.ImporteTributos
                .ImpIVA = cbte.ImporteIVA

                If cbte.Concepto = 2 Or cbte.Concepto = 3 Then
                    .FchServDesde = cbte.FechaServicioDesde
                    .FchServHasta = cbte.FechaServicioHasta
                    .FchVtoPago = cbte.FechaVtoPago
                End If

                .MonId = cbte.MonedaId
                .MonCotiz = cbte.MonedaCtz

                'agrego las alicuotas de iva
                If cbte.CbteAlicuotas.Count > 0 Then
                    Dim arrayIVA(cbte.CbteAlicuotas.Count - 1) As wsfev1.AlicIva
                    Dim iva As wsfev1.AlicIva

                    indice = 0
                    For Each alic In cbte.CbteAlicuotas
                        iva = New wsfev1.AlicIva
                        iva.BaseImp = Math.Round(alic.BaseImponible, 2)
                        iva.Id = alic.Codigo
                        iva.Importe = Math.Round(alic.Importe, 2)
                        arrayIVA(indice) = iva
                        indice += 1
                    Next

                    .Iva = arrayIVA

                End If

                'agrego los tributos
                If cbte.CbteTributos.Count > 0 Then
                    Dim arrayTributos(cbte.CbteTributos.Count - 1) As wsfev1.Tributo
                    Dim tributo As wsfev1.Tributo

                    indice = 0
                    For Each trib In cbte.CbteTributos
                        tributo = New wsfev1.Tributo
                        tributo.Alic = trib.Alicuota
                        tributo.Id = trib.Codigo
                        tributo.Desc = trib.Descripcion
                        tributo.BaseImp = Math.Round(trib.BaseImponible, 2)
                        tributo.Importe = Math.Round(trib.Importe, 2)
                        arrayTributos(indice) = tributo
                        indice += 1
                    Next

                    .Tributos = arrayTributos

                End If

                'agrego los cbtes asoc.
                If cbte.CbteAsociados.Count > 0 Then
                    Dim arrayAsociados(cbte.CbteAsociados.Count - 1) As wsfev1.CbteAsoc
                    Dim asociado As wsfev1.CbteAsoc

                    indice = 0
                    For Each asoc In cbte.CbteAsociados
                        asociado = New wsfev1.CbteAsoc
                        asociado.Nro = asoc.Numero
                        asociado.PtoVta = asoc.PtoVta
                        asociado.Tipo = asoc.Tipo
                        arrayAsociados(indice) = asociado
                        indice += 1
                    Next

                    .CbtesAsoc = arrayAsociados

                End If



            End With

            arrayFECAEDetRequest(0) = objFECAEDetRequest


            With objFECAERequest
                .FeCabReq = objFECAECabRequest
                .FeDetReq = arrayFECAEDetRequest
            End With

            ' Invoco al método FECAESolicitar
            Try

                'si esta aprobado recupero el CAE del archivo                    
                Dim cae As String = "", caefchvto As String = ""
                Dim resultado As String = "", reproceso As String = "", bresultado As Boolean
                Dim observaciones As New StringBuilder, errores As New StringBuilder
                Dim eventos As New StringBuilder

                objFECAEResponse = objWSFEV1.FECAESolicitar(FEAuthRequest, objFECAERequest)
                If objFECAEResponse IsNot Nothing Then

                    'Serialize object to a text file.
                    Dim filename As String = ""
                    filename &= cbte.CbteTipo.ToString.PadLeft(2, "0")
                    filename &= cbte.CbtePtoVta.ToString.PadLeft(4, "0")
                    filename &= cbte.CbteNumero.ToString.PadLeft(8, "0")

                    Dim requestfile As String = My.Settings.WsfeRutaSalidas & "\" & filename & "req.xml"
                    Dim responseFile As String = My.Settings.WsfeRutaSalidas & "\" & filename & "res.xml"

                    'Serialize object to a text file.
                    'Dim requestfile As String = "C:\WSFEV1_objFECAERequest.xml"
                    'Dim responseFile As String = "C:\WSFEV1_objFECAEResponse.xml"

                    Dim objStreamWriter As New StreamWriter(responseFile)
                    Dim x As New XmlSerializer(objFECAEResponse.GetType)
                    x.Serialize(objStreamWriter, objFECAEResponse)
                    objStreamWriter.Close()

                    objStreamWriter = New StreamWriter(requestfile)
                    x = New XmlSerializer(objFECAERequest.GetType)
                    x.Serialize(objStreamWriter, objFECAERequest)
                    objStreamWriter.Close()

                    If objFECAEResponse.FeCabResp.Resultado = "R" Then
                        bresultado = False
                    ElseIf objFECAEResponse.FeCabResp.Resultado = "A" Then
                        bresultado = True
                    End If

                    Dim xmld As XmlDocument
                    Dim nodelist As XmlNodeList

                    'Create the XML Document
                    xmld = New XmlDocument()
                    'Load the Xml file
                    xmld.Load(responseFile)
                    'Get the list of name nodes 
                    nodelist = xmld.SelectNodes("/FECAEResponse")

                    'Loop through the nodes
                    For Each node As XmlNode In nodelist

                        For Each n As XmlNode In node.ChildNodes

                            Select Case n.Name
                                Case "FeCabResp" 'cabecera de comprobante

                                    For Each nFeCab As XmlNode In n.ChildNodes
                                        Select Case nFeCab.Name
                                            Case "Cuit"
                                            Case "PtoVta"
                                            Case "CbteTipo"
                                            Case "FchProceso"
                                            Case "CantReg"
                                            Case "Resultado" : resultado = nFeCab.InnerText
                                            Case "Reproceso" : reproceso = nFeCab.InnerText
                                        End Select
                                    Next nFeCab


                                Case "FeDetResp" 'detalle de comprobante  

                                    For Each nFeDet As XmlNode In n.ChildNodes
                                        If nFeDet.Name = "FECAEDetResponse" Then
                                            For Each nFECADet As XmlNode In nFeDet.ChildNodes

                                                Select Case nFECADet.Name
                                                    Case "Concepto"
                                                    Case "DocTipo"
                                                    Case "DocNro"
                                                    Case "CbteDesde"
                                                    Case "CbteHasta"
                                                    Case "CbteFch"
                                                    Case "Resultado"
                                                    Case "Observaciones"
                                                        For Each nObs As XmlNode In nFECADet.ChildNodes
                                                            observaciones.AppendLine("Cód.: " & nObs.ChildNodes(0).InnerText & " - " & nObs.ChildNodes(1).InnerText)
                                                        Next nObs
                                                    Case "CAE"
                                                        cae = nFECADet.InnerText
                                                    Case "CAEFchVto"
                                                        caefchvto = nFECADet.InnerText
                                                End Select

                                            Next nFECADet
                                        End If
                                    Next nFeDet
                            End Select
                        Next n
                    Next node
                End If

                cbte.CuitEmisor = FEAuthRequest.Cuit
                cbte.CAE = cae
                cbte.FechaVtoCAE = caefchvto
                cbte.Observaciones = observaciones.ToString
                cbte.Resultado = resultado
                cbte.Reproceso = reproceso

                ShowStatus("Resultado -> " & cbte.Resultado)

                ShowStatus("CAE " & cbte.CAE)

                ShowStatus("Vencimiento CAE " & cbte.FechaVtoCAE)

                If objFECAEResponse.Errors IsNot Nothing Then
                    For i = 0 To objFECAEResponse.Errors.Length - 1
                        errores.AppendLine("Cód.: " & objFECAEResponse.Errors(i).Code.ToString & " - " & objFECAEResponse.Errors(i).Msg)
                        'MessageBox.Show("objFECAEResponse.Errors(i).Code: " + objFECAEResponse.Errors(i).Code.ToString + vbCrLf + _
                        '"objFECAEResponse.Errors(i).Msg: " + objFECAEResponse.Errors(i).Msg, "Errores", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Next
                End If

                If objFECAEResponse.Events IsNot Nothing Then
                    For i = 0 To objFECAEResponse.Events.Length - 1
                        eventos.AppendLine("Cód.: " & objFECAEResponse.Events(i).Code.ToString & " - " & objFECAEResponse.Events(i).Msg)
                        'MessageBox.Show("objFECAEResponse.Events(i).Code: " + objFECAEResponse.Events(i).Code.ToString + vbCrLf + _
                        '"objFECAEResponse.Events(i).Msg: " + objFECAEResponse.Events(i).Msg, "Eventos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Next
                End If

                cbte.Errores = errores.ToString
                cbte.Eventos = eventos.ToString

                Return cbte

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Autorizar Cbte.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return cbte
            End Try

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Autorizar Cbte.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return cbte
        End Try

    End Function

    Public Function ConsultarCbte(ByVal cbteTipo As Int32, ByVal cbtePtoVta As Int32, ByVal cbteNumero As Int32) As Entidades.CbteCabecera

        Dim objFECompConsultaReq As New wsfev1.FECompConsultaReq
        Dim objFECompConsultaResponse As New wsfev1.FECompConsultaResponse

        Dim ret As New Entidades.CbteCabecera
        Dim eventos As New StringBuilder
        Dim errores As New StringBuilder
        Dim indice As Integer
        Dim cbteAsoc As Entidades.CbteAsociado = Nothing
        Dim cbteAlic As Entidades.CbteAlicuota = Nothing
        Dim cbteTrib As Entidades.CbteTributo = Nothing

        objFECompConsultaReq.PtoVta = cbtePtoVta
        objFECompConsultaReq.CbteTipo = cbteTipo
        objFECompConsultaReq.CbteNro = cbteNumero

        ' Invoco al método FECompConsultar
        Try
            objFECompConsultaResponse = objWSFEV1.FECompConsultar(FEAuthRequest, objFECompConsultaReq)
            If objFECompConsultaResponse IsNot Nothing Then

                'Creo el XML de respuesta
                Dim filename As String
                filename = objFECompConsultaResponse.ResultGet.CbteTipo.ToString.PadLeft(2, "0")
                filename &= objFECompConsultaResponse.ResultGet.PtoVta.ToString.PadLeft(4, "0")
                filename &= objFECompConsultaResponse.ResultGet.CbteDesde.ToString.PadLeft(8, "0")

                Dim responseFile As String = My.Settings.WsfeRutaSalidas & "\" & filename & "Con.xml"

                Dim objStreamWriter As New StreamWriter(responseFile)
                Dim x As New XmlSerializer(objFECompConsultaResponse.GetType)
                x.Serialize(objStreamWriter, objFECompConsultaResponse)
                objStreamWriter.Close()

                ret.CAE = objFECompConsultaResponse.ResultGet.CodAutorizacion
                ret.CbtePtoVta = objFECompConsultaResponse.ResultGet.PtoVta
                ret.CbteNumero = objFECompConsultaResponse.ResultGet.CbteDesde
                ret.CbteTipo = objFECompConsultaResponse.ResultGet.CbteTipo
                ret.Resultado = objFECompConsultaResponse.ResultGet.Resultado
                ret.FechaVtoCAE = objFECompConsultaResponse.ResultGet.FchVto
                ret.CbteFecha = objFECompConsultaResponse.ResultGet.CbteFch
                ret.Concepto = objFECompConsultaResponse.ResultGet.Concepto
                ret.DocumentoTipo = objFECompConsultaResponse.ResultGet.DocTipo
                ret.DocumentoNro = objFECompConsultaResponse.ResultGet.DocNro
                ret.FechaServicioDesde = objFECompConsultaResponse.ResultGet.FchServDesde
                ret.FechaServicioHasta = objFECompConsultaResponse.ResultGet.FchServHasta
                ret.FechaVtoPago = objFECompConsultaResponse.ResultGet.FchVtoPago
                ret.ImporteIVA = objFECompConsultaResponse.ResultGet.ImpIVA
                ret.ImporteNeto = objFECompConsultaResponse.ResultGet.ImpNeto
                ret.ImporteOpExentas = objFECompConsultaResponse.ResultGet.ImpOpEx
                ret.ImporteTotal = objFECompConsultaResponse.ResultGet.ImpTotal
                ret.ImporteTotalConceptos = objFECompConsultaResponse.ResultGet.ImpTotConc
                ret.ImporteTributos = objFECompConsultaResponse.ResultGet.ImpTrib
                ret.MonedaCtz = objFECompConsultaResponse.ResultGet.MonCotiz
                ret.MonedaId = objFECompConsultaResponse.ResultGet.MonId
                ret.Resultado = objFECompConsultaResponse.ResultGet.Resultado

                If objFECompConsultaResponse.ResultGet.Observaciones IsNot Nothing Then
                    For indice = 0 To objFECompConsultaResponse.ResultGet.Observaciones.Length - 1
                        ret.Observaciones &= objFECompConsultaResponse.ResultGet.Observaciones(indice).Code & " " & _
                        objFECompConsultaResponse.ResultGet.Observaciones(indice).Msg & vbNewLine
                    Next
                End If

                'recupero los comprobantes asociados
                If objFECompConsultaResponse.ResultGet.CbtesAsoc IsNot Nothing Then
                    For indice = 0 To objFECompConsultaResponse.ResultGet.CbtesAsoc.Length - 1
                        cbteAsoc = New Entidades.CbteAsociado
                        cbteAsoc.Numero = objFECompConsultaResponse.ResultGet.CbtesAsoc(indice).Nro
                        cbteAsoc.PtoVta = objFECompConsultaResponse.ResultGet.CbtesAsoc(indice).PtoVta
                        cbteAsoc.Tipo = objFECompConsultaResponse.ResultGet.CbtesAsoc(indice).Tipo
                        ret.CbteAsociados.Add(cbteAsoc)
                    Next
                End If
                'recupero las alicuotas de iva
                If objFECompConsultaResponse.ResultGet.Tributos IsNot Nothing Then
                    For indice = 0 To objFECompConsultaResponse.ResultGet.Iva.Length - 1
                        cbteAlic = New Entidades.CbteAlicuota
                        cbteAlic.BaseImponible = objFECompConsultaResponse.ResultGet.Iva(indice).BaseImp
                        cbteAlic.Codigo = objFECompConsultaResponse.ResultGet.Iva(indice).Id
                        cbteAlic.Importe = objFECompConsultaResponse.ResultGet.Iva(indice).Importe
                        ret.CbteAlicuotas.Add(cbteAlic)
                    Next
                End If

                'recupero otros tributos
                If objFECompConsultaResponse.ResultGet.Tributos IsNot Nothing Then
                    For indice = 0 To objFECompConsultaResponse.ResultGet.Tributos.Length - 1
                        cbteTrib = New Entidades.CbteTributo
                        cbteTrib.BaseImponible = objFECompConsultaResponse.ResultGet.Tributos(indice).BaseImp
                        cbteTrib.Codigo = objFECompConsultaResponse.ResultGet.Tributos(indice).Id
                        cbteTrib.Importe = objFECompConsultaResponse.ResultGet.Tributos(indice).Importe
                        cbteTrib.Alicuota = objFECompConsultaResponse.ResultGet.Tributos(indice).Alic
                        cbteTrib.Descripcion = objFECompConsultaResponse.ResultGet.Tributos(indice).Desc
                        ret.CbteTributos.Add(cbteTrib)
                    Next
                End If
            End If

            If objFECompConsultaResponse.Errors IsNot Nothing Then
                For i = 0 To objFECompConsultaResponse.Errors.Length - 1
                    errores.AppendLine("objFECompConsulta.Errors(i).Code: " + objFECompConsultaResponse.Errors(i).Code.ToString + vbCrLf + _
                    "objFECompConsulta.Errors(i).Msg: " + objFECompConsultaResponse.Errors(i).Msg)
                Next
            End If
            If objFECompConsultaResponse.Events IsNot Nothing Then
                For i = 0 To objFECompConsultaResponse.Events.Length - 1
                    eventos.AppendLine("objFECompConsulta.Events(i).Code: " + objFECompConsultaResponse.Events(i).Code.ToString + vbCrLf + _
                    "objFECompConsulta.Events(i).Msg: " + objFECompConsultaResponse.Events(i).Msg)
                Next
            End If

            ret.Errores = errores.ToString
            ret.Eventos = eventos.ToString

            Return ret

        Catch ex As Exception
            MessageBox.Show("ConsultarCbte Error: " & ex.Message, "ConsultarCbte", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ret
        End Try
    End Function

    'Public Function ConsultarCbte(ByVal cbte As Entidades.CbteCabecera) As Entidades.CbteCabecera

    '    Dim objFECompConsultaReq As New wsfev1.FECompConsultaReq
    '    Dim objFECompConsultaResponse As wsfev1.FECompConsultaResponse

    '    Dim eventos As New StringBuilder
    '    Dim errores As New StringBuilder

    '    objFECompConsultaReq.PtoVta = cbte.CbtePtoVta
    '    objFECompConsultaReq.CbteTipo = cbte.CbteTipo
    '    objFECompConsultaReq.CbteNro = cbte.CbteNumero

    '    ' Invoco al método FECompConsultar
    '    Try
    '        objFECompConsultaResponse = objWSFEV1.FECompConsultar(FEAuthRequest, objFECompConsultaReq)
    '        If objFECompConsultaResponse IsNot Nothing Then

    '            cbte.CAE = objFECompConsultaResponse.ResultGet.CodAutorizacion
    '            cbte.CbtePtoVta = objFECompConsultaResponse.ResultGet.PtoVta
    '            cbte.CbteNumero = objFECompConsultaResponse.ResultGet.CbteDesde
    '            cbte.CbteTipo = objFECompConsultaResponse.ResultGet.CbteTipo
    '            cbte.Resultado = objFECompConsultaResponse.ResultGet.Resultado
    '            cbte.FechaVtoCAE = objFECompConsultaResponse.ResultGet.FchVto
    '            cbte.CbteFecha = objFECompConsultaResponse.ResultGet.CbteFch

    '            'Creo el XML de respuesta
    '            Dim filename As String = ""
    '            filename &= cbte.CbteTipo.ToString.PadLeft(2, "0")
    '            filename &= cbte.CbtePtoVta.ToString.PadLeft(4, "0")
    '            filename &= cbte.CbteNumero.ToString.PadLeft(8, "0")
    '            Dim objStreamWriter As New StreamWriter(My.Settings.WsfeRutaSalidas & "\" & filename & "Con.xml")
    '            Dim x As New XmlSerializer(objFECompConsultaResponse.GetType)
    '            x.Serialize(objStreamWriter, objFECompConsultaResponse)
    '            objStreamWriter.Close()

    '        End If
    '        If objFECompConsultaResponse.Errors IsNot Nothing Then
    '            For i = 0 To objFECompConsultaResponse.Errors.Length - 1
    '                errores.AppendLine("objFECompConsulta.Errors(i).Code: " + objFECompConsultaResponse.Errors(i).Code.ToString + vbCrLf + _
    '                "objFECompConsulta.Errors(i).Msg: " + objFECompConsultaResponse.Errors(i).Msg)
    '            Next
    '        End If
    '        If objFECompConsultaResponse.Events IsNot Nothing Then
    '            For i = 0 To objFECompConsultaResponse.Events.Length - 1
    '                eventos.AppendLine("objFECompConsulta.Events(i).Code: " + objFECompConsultaResponse.Events(i).Code.ToString + vbCrLf + _
    '                "objFECompConsulta.Events(i).Msg: " + objFECompConsultaResponse.Events(i).Msg)
    '            Next
    '        End If

    '        cbte.Errores = errores.ToString
    '        cbte.Eventos = eventos.ToString

    '        Return cbte

    '    Catch ex As Exception
    '        MessageBox.Show("ConsultarCbte Error: " & ex.Message)
    '        Return cbte
    '    End Try
    'End Function


    Public Sub ChequearStatusServer()
        Dim objDummy As New wsfev1.DummyResponse
        ' Invoco al método Dummy
        Try

            If _conectado Then
                RaiseEvent Status("Conectado con AFIP. CUIT " & _cuit & ". Su conexión expira el " & _expirationTime.ToString("dd/MM/yyyy HH:mm:ss"))
            Else
                RaiseEvent Status("Sin conexión con AFIP")
            End If

            objDummy = objWSFEV1.FEDummy

            AppServerStatus = objDummy.AppServer
            DbServerStatus = objDummy.DbServer
            AuthServerStatus = objDummy.AuthServer

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chequear estado de servidores", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Consulta por el último nro. del cbte. registrado según tipo de cbte.
    ''' </summary>
    ''' <param name="ptoVta">Pto. de Vta. a consultar</param>
    ''' <param name="cbteTipo">Tipo de cbte. a consultar</param>
    ''' <returns>Devuelve el último nro. de cbte. registrado</returns>
    ''' <remarks></remarks>
    Public Function UltimoCbteAutorizado(ByVal ptoVta As Int32, ByVal cbteTipo As Int32) As Int32

        Dim ret As Int32 = 0
        Dim objFERecuperaLastCbteResponse As wsfev1.FERecuperaLastCbteResponse

        Dim eventos As New StringBuilder
        Dim errores As New StringBuilder


        If ptoVta = 0 Then
            MessageBox.Show("UltimoCbteAutorizado: Debe seleccionar un punto de venta")
            Return -1
        End If

        If cbteTipo = 0 Then
            MessageBox.Show("UltimoCbteAutorizado: Debe seleccionar un tipo de comprobante")
            Return -1
        End If

        ' Invoco al método FECompUltimoAutorizado
        Try
            objFERecuperaLastCbteResponse = objWSFEV1.FECompUltimoAutorizado(FEAuthRequest, ptoVta, cbteTipo)

            If objFERecuperaLastCbteResponse IsNot Nothing Then
                ret = objFERecuperaLastCbteResponse.CbteNro
            End If

            If objFERecuperaLastCbteResponse.Errors IsNot Nothing Then
                For i = 0 To objFERecuperaLastCbteResponse.Errors.Length - 1
                    errores.AppendLine("objFERecuperaLastCbte.Errors(i).Code: " + objFERecuperaLastCbteResponse.Errors(i).Code.ToString + vbCrLf + _
                    "objFERecuperaLastCbte.Errors(i).Msg: " + objFERecuperaLastCbteResponse.Errors(i).Msg)
                Next
            End If

            If objFERecuperaLastCbteResponse.Events IsNot Nothing Then
                For i = 0 To objFERecuperaLastCbteResponse.Events.Length - 1
                    eventos.AppendLine("objFERecuperaLastCbte.Events(i).Code: " + objFERecuperaLastCbteResponse.Events(i).Code.ToString + vbCrLf + _
                    "objFERecuperaLastCbte.Events(i).Msg: " + objFERecuperaLastCbteResponse.Events(i).Msg)
                Next
            End If

            If eventos.Length <> 0 Then
                MessageBox.Show("Eventos: " & eventos.ToString)
            End If

            If errores.Length <> 0 Then
                MessageBox.Show("Errores: " & errores.ToString)
            End If

            Return ret

        Catch ex As Exception
            MessageBox.Show("UltimoCbteAutorizado Error: " & ex.Message, "UltimoCbteAutorizado", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    Public Function EmitirCbteFiscal(ByVal cbte As Entidades.CbteCabecera) As Long

        Dim sCmd As String
        Dim bAnswer As Boolean
        Dim responsabilidadIVA As String
        Dim tipoDocumento As String
        Dim tipoComprobante As String
        Dim letraComprobante As String
        Dim ret As Long = 0
        Dim subtotalFiscal As Double = 0.0

        Try

            EpsonOCX = New EpsonFPHostControlX.EpsonFPHostControl

            Select Case cbte.Tiporesponsable
                Case 1 : responsabilidadIVA = IVA_RESPONSABLE_INSCRITO
                Case 2 : responsabilidadIVA = IVA_RESPONSABLE_NO_INSCRITO
                Case 3 : responsabilidadIVA = IVA_NO_RESPONSABLE
                Case 4 : responsabilidadIVA = IVA_EXENTO
                Case 5 : responsabilidadIVA = IVA_CONSUMIDOR_FINAL
                Case 6 : responsabilidadIVA = IVA_RESPONSABLE_MONOTRIBUTO
                Case 7 : responsabilidadIVA = IVA_SUJETO_NO_CATEGORIZADO
                Case 12 : responsabilidadIVA = IVA_CONTRIBUYENTE_EVENTUAL
                Case 13 : responsabilidadIVA = IVA_MONOTRIBUTISTA_SOCIAL
                Case 14 : responsabilidadIVA = IVA_CONTRIBUYENTE_EVENTUAL_SOCIAL
                Case Else : Throw New Exception("Condición del IVA del receptor no contemplada")
            End Select

            Select Case cbte.DocumentoTipo
                Case 80 : tipoDocumento = DOC_CUIT
                Case 86 : tipoDocumento = DOC_CUIL
                Case Else : tipoDocumento = DOC_DNI
            End Select

            Select Case cbte.CbteTipo
                Case TIQUE_NOTA_CREDITO_A 'Nota de credito A
                    tipoComprobante = TIQUE_NOTA_CREDITO_FISCAL
                    letraComprobante = LETRA_FISCAL_A
                Case TIQUE_NOTA_CREDITO_B 'Nota de credito B
                    tipoComprobante = TIQUE_NOTA_CREDITO_FISCAL
                    letraComprobante = LETRA_FISCAL_B
                Case TIQUE_FACTURA_A 'Tique factura A
                    tipoComprobante = TIQUE_FACTURA_FISCAL
                    letraComprobante = LETRA_FISCAL_A
                Case TIQUE_FACTURA_B 'Tique factura B
                    tipoComprobante = TIQUE_FACTURA_FISCAL
                    letraComprobante = LETRA_FISCAL_B
                Case NOTA_CREDITO_A 'Nota de credito A
                    tipoComprobante = NOTA_CREDITO_FISCAL
                    letraComprobante = LETRA_FISCAL_A
                Case NOTA_CREDITO_B 'Nota de credito B
                    tipoComprobante = NOTA_CREDITO_FISCAL
                    letraComprobante = LETRA_FISCAL_B
                Case FACTURA_A 'Tique factura A
                    tipoComprobante = FACTURA_FISCAL
                    letraComprobante = LETRA_FISCAL_A
                Case FACTURA_B 'Tique factura B
                    tipoComprobante = FACTURA_FISCAL
                    letraComprobante = LETRA_FISCAL_B
                Case Else : Throw New Exception("Tipo de comprobante no contemplado")
            End Select

            bAnswer = True

            EpsonOCX.ClosePort()

            Call FiscalDelay(EpsonOCX)

            EpsonOCX.CommPort = My.Settings.PuertoCommFiscal

            EpsonOCX.BaudRate = EpsonFPHostControlX.TxBaudRate.br9600

            EpsonOCX.ProtocolType = EpsonFPHostControlX.TxProtocolType.protocol_Compatible

            If Not (EpsonOCX.OpenPort) Then
                Throw New Exception("Error al intentar abrir el puerto de comunicaciones del IF")
            End If

            ShowStatus("Apertura del puerto de comunicaciones nº " & EpsonOCX.CommPort + 1)

            Call FiscalDelay(EpsonOCX)

            'Abrir comprobante
            sCmd = Convert.ToChar(96) 'COMANDO PARA ABRIR UN TIQUET-FISCAL
            If bAnswer Then bAnswer = EpsonOCX.AddDataField(sCmd)
            If bAnswer Then bAnswer = EpsonOCX.AddDataField(tipoComprobante) 'TIPO DE COMPROBANTE
            If bAnswer Then bAnswer = EpsonOCX.AddDataField(FORMULARIO_CONTINUO) 'FORMULARIO CONTINUO
            If bAnswer Then bAnswer = EpsonOCX.AddDataField(letraComprobante) 'LETRA DEL DOCUMENTO FISCAL
            If bAnswer Then bAnswer = EpsonOCX.AddDataField("1") 'CANT. DE COPIAS A IMPRIMIR
            If bAnswer Then bAnswer = EpsonOCX.AddDataField(FORMULARIO_IMPRESO) 'LA IMPRESORA DIBUJA LAS LINEAS
            If bAnswer Then bAnswer = EpsonOCX.AddDataField(DENSIDAD_12CPI) 'DENSIDAD DE IMPRESION
            If bAnswer Then bAnswer = EpsonOCX.AddDataField(IVA_RESPONSABLE_INSCRITO) 'IVA EMISOR
            If bAnswer Then bAnswer = EpsonOCX.AddDataField(responsabilidadIVA) 'IVA COMPRADOR
            If bAnswer Then bAnswer = EpsonOCX.AddDataField(cbte.RazonSocial) 'NOMBRE 1
            If bAnswer Then bAnswer = EpsonOCX.AddDataField("") 'NOMBRE 2
            If bAnswer Then bAnswer = EpsonOCX.AddDataField(tipoDocumento) 'TIPO DE DOCUMENTO, DE SER CUIT O CUIL DEBE VALIDARSE
            If bAnswer Then bAnswer = EpsonOCX.AddDataField(cbte.DocumentoNro) 'NRO DOCUMENTO
            If bAnswer Then bAnswer = EpsonOCX.AddDataField("N") 'BIEN DE USO, VA SIEMPRE N
            If bAnswer Then bAnswer = EpsonOCX.AddDataField(cbte.Domicilio) 'DOMICILIO 1
            If bAnswer Then bAnswer = EpsonOCX.AddDataField("") 'DOMICILIO 2
            If bAnswer Then bAnswer = EpsonOCX.AddDataField("") 'DOMICILIO 3
            If bAnswer Then bAnswer = EpsonOCX.AddDataField(".") 'REMITO 1
            If bAnswer Then bAnswer = EpsonOCX.AddDataField(".") 'REMITO 2
            If bAnswer Then bAnswer = EpsonOCX.AddDataField("C") 'FORMATO PARA ALMACENAR LOS DATOS, SIEMPRE C
            If bAnswer Then bAnswer = EpsonOCX.SendCommand

            ShowStatus("Apertura del comprobante fiscal")

            Call FiscalDelay(EpsonOCX)

            If EpsonOCX.ReturnCode <> 0 Then ShowMsg(EpsonOCX)

            For Each i As Entidades.CbteArticulo In cbte.CbteArticulos

                'CARGA DE ITEMS
                sCmd = Convert.ToChar(98)
                If bAnswer Then bAnswer = EpsonOCX.AddDataField(sCmd)
                'DESCRIPCION DEL ITEM
                If i.ImpuestoInterno <> 0 Then
                    If bAnswer Then bAnswer = EpsonOCX.AddDataField(Microsoft.VisualBasic.Left(i.DescriptorIF, 11))
                Else
                    If bAnswer Then bAnswer = EpsonOCX.AddDataField(Microsoft.VisualBasic.Left(i.DescriptorIF, 18))
                End If
                'CANTIDAD, 5 ENTEROS Y 3 DECIMALES, ENVIAR SIN EL PUNTO
                If bAnswer Then bAnswer = EpsonOCX.AddDataField(i.Cantidad.ToString(FORMATO_CANTIDAD).Replace(".", ""))
                'PRECIO, SI EL COMPRADOR ES RESP. INSCRIPTO ENVIAR SIN IVA
                '7 ENTEROS Y 4 DECIMALES, ENVIAR CON PUNTO PARA MODELOS SUPERIORES A TM 20000
                '7 ENTEROS Y 2 DECIMALES, ENVIAR SIN PUNTO PARA MODELOS TM 20000
                If responsabilidadIVA = IVA_RESPONSABLE_INSCRITO Then
                    'If bAnswer Then bAnswer = EpsonOCX.AddDataField(i.ImporteFinal.ToString(FORMATO_IMPORTE).Replace(".", ""))
                    If bAnswer Then bAnswer = EpsonOCX.AddDataField(i.ImporteFinal.ToString(FORMATO_IMPORTE))
                Else
                    'If bAnswer Then bAnswer = EpsonOCX.AddDataField((i.ImporteConIVA + i.ImpuestoInterno).ToString(FORMATO_IMPORTE).Replace(".", ""))
                    If bAnswer Then bAnswer = EpsonOCX.AddDataField((i.ImporteConIVA + i.ImpuestoInterno).ToString(FORMATO_IMPORTE))
                End If
                'TASA IMPOSITIVA, SE ENVIA SIN PUNTO, 2 ENTEROS Y 2 DECIMALES
                If bAnswer Then bAnswer = EpsonOCX.AddDataField(i.Alicuota.ToString(FORMATO_ALICUOTA).Replace(".", ""))
                'CALIFICADOR DE ITEM
                'M -> MONTO AGREGADO, SUMA
                'm -> ANULA ITEM VENDIDO, RESTO
                'R -> BONIFICACION, RESTA
                'r -> ANULA BONIFICACION, SUMA
                If bAnswer Then bAnswer = EpsonOCX.AddDataField("M")
                'CANTIDAD DE BULTOS, NO SE USA
                If bAnswer Then bAnswer = EpsonOCX.AddDataField("0")
                'TASA DE AJUSTE VARIABLE
                If bAnswer Then bAnswer = EpsonOCX.AddDataField("0")
                'DESCRIPCIONES EXTRA, 3 LINEAS
                If bAnswer Then bAnswer = EpsonOCX.AddDataField("")
                If bAnswer Then bAnswer = EpsonOCX.AddDataField("")
                If bAnswer Then bAnswer = EpsonOCX.AddDataField("")
                'TASA DE ACRECENTAMIENTO, NO SE USA
                If bAnswer Then bAnswer = EpsonOCX.AddDataField("0")
                'MONTO IMPUESTO INTERNO FIJO, 7 ENTEROS Y 8 DECIMALES, ENVIAR SIN EL PUNTO
                If bAnswer Then bAnswer = EpsonOCX.AddDataField(i.ImpuestoInterno.ToString(FORMATO_IMPUESTO_INTERNO).Replace(".", ""))
                'ENVIAR COMANDO
                If bAnswer Then bAnswer = EpsonOCX.SendCommand

                ShowStatus("Enviando item " & i.Descripcion)

                Call FiscalDelay(EpsonOCX)

                If EpsonOCX.ReturnCode <> 0 Then ShowMsg(EpsonOCX)

            Next i



            'COMANDO QUE IDENTIFICA PAGOS/RECARGOS/DESCUENTOS/CANCELAR FACTURA/NOTA CREDITO/ETC.
            'SI EL COMPRADOR ES RI SE ESPERAN IMPORTES SIN IVA

            'If orden.Descuento <> 0 Then

            '    sCmd = Convert.ToChar(100)
            '    If bAnswer Then bAnswer = EpsonOCX.AddDataField(sCmd)
            '    If bAnswer Then bAnswer = EpsonOCX.AddDataField("DESCUENTO") 'LEYENDA PAGOS/RECARGOS/DESCUENTOS/CANCELAR FACTURA/NOTA CREDITO/ETC.
            '    If bAnswer Then bAnswer = EpsonOCX.AddDataField(orden.Descuento.ToString("000000000.00").Replace(".", "")) 'MONTO DEL PAGO, DESCUENTO O RECARGO
            '    'D:DESCUENTO DE MONTO FIJO, 
            '    'R:RECARGO DE MONTO FIJO,
            '    'C:CANCELA COMPROBANTE,
            '    'T:SUMA AL IMPORTE PAGADAO,
            '    't:ANULA PAGO HECHO CON T
            '    If bAnswer Then bAnswer = EpsonOCX.AddDataField("D")
            '    If bAnswer Then bAnswer = EpsonOCX.SendCommand
            '    Call FiscalDelay(EpsonOCX)
            '    If EpsonOCX.ReturnCode <> 0 Then ShowMsg(EpsonOCX)

            'End If

            'COMANDO QUE IDENTIFICA PAGOS/RECARGOS/DESCUENTOS/CANCELAR FACTURA/NOTA CREDITO/ETC.
            'SI EL COMPRADOR ES RI SE ESPERAN IMPORTES SIN IVA
            'sCmd = Convert.ToChar(100)
            'If bAnswer Then bAnswer = EpsonOCX.AddDataField(sCmd)
            'If bAnswer Then bAnswer = EpsonOCX.AddDataField("RECARGO POR MORA") 'LEYENDA PAGOS/RECARGOS/DESCUENTOS/CANCELAR FACTURA/NOTA CREDITO/ETC.
            'If bAnswer Then bAnswer = EpsonOCX.AddDataField("00000000100") 'MONTO DEL PAGO, DESCUENTO O RECARGO
            ''D:DESCUENTO DE MONTO FIJO, 
            ''R:RECARGO DE MONTO FIJO,
            ''C:CANCELA COMPROBANTE,
            ''T:SUMA AL IMPORTE PAGADAO,
            ''t:ANULA PAGO HECHO CON T
            'If bAnswer Then bAnswer = EpsonOCX.AddDataField("R")
            'If bAnswer Then bAnswer = EpsonOCX.SendCommand
            'Call FiscalDelay(EpsonOCX)
            'If EpsonOCX.ReturnCode <> 0 Then ShowMsg(EpsonOCX)

            'COMANDO QUE IDENTIFICA PAGOS/RECARGOS/DESCUENTOS/CANCELAR FACTURA/NOTA CREDITO/ETC.
            'SI EL COMPRADOR ES RI SE ESPERAN IMPORTES SIN IVA
            'sCmd = Convert.ToChar(100)
            'If bAnswer Then bAnswer = EpsonOCX.AddDataField(sCmd)
            'If bAnswer Then bAnswer = EpsonOCX.AddDataField("PAGA CON") 'LEYENDA PAGOS/RECARGOS/DESCUENTOS/CANCELAR FACTURA/NOTA CREDITO/ETC.
            'If bAnswer Then bAnswer = EpsonOCX.AddDataField(orden.GetTotalOrden.ToString("000000000.00").Replace(".", "")) 'MONTO DEL PAGO, DESCUENTO O RECARGO
            ''D:DESCUENTO DE MONTO FIJO, 
            ''R:RECARGO DE MONTO FIJO,
            ''C:CANCELA COMPROBANTE,
            ''T:SUMA AL IMPORTE PAGADAO,
            ''t:ANULA PAGO HECHO CON T
            'If bAnswer Then bAnswer = EpsonOCX.AddDataField("T")
            'If bAnswer Then bAnswer = EpsonOCX.SendCommand
            'Call FiscalDelay(EpsonOCX)
            'If EpsonOCX.ReturnCode <> 0 Then ShowMsg(EpsonOCX)

            'SUBTOTAL DE COMPROBANTE
            'sCmd = Convert.ToChar(99) 'COMANDO DE SUBTOTAL
            'If bAnswer Then bAnswer = EpsonOCX.AddDataField(sCmd)
            'If bAnswer Then bAnswer = EpsonOCX.AddDataField("N") 'P - IMPRIME SUBTOTAL, N -NO IMPRIME SUBTOTAOL
            'If bAnswer Then bAnswer = EpsonOCX.AddDataField("") 'DESCRIPCION OPCIONAL
            'If bAnswer Then bAnswer = EpsonOCX.SendCommand
            'Call FiscalDelay(EpsonOCX)
            'If EpsonOCX.ReturnCode <> 0 Then ShowMsg(EpsonOCX)

            'Debug.Print(EpsonOCX.GetExtraField(2))

            'CIERRE DE COMPROBANTE
            sCmd = Convert.ToChar(101) 'COMANDO DE CIERRE DE FACTURA
            If bAnswer Then bAnswer = EpsonOCX.AddDataField(sCmd)
            If bAnswer Then bAnswer = EpsonOCX.AddDataField(tipoComprobante) 'TIPO DE COMPROBANTE
            If bAnswer Then bAnswer = EpsonOCX.AddDataField(letraComprobante) 'LETRA DEL DOCUMENTO
            If bAnswer Then bAnswer = EpsonOCX.AddDataField("") 'DESCRIPCION OPCIONAL
            If bAnswer Then bAnswer = EpsonOCX.SendCommand

            ShowStatus("Cerrando comprobante")

            Call FiscalDelay(EpsonOCX)
            If EpsonOCX.ReturnCode <> 0 Then ShowMsg(EpsonOCX)

            ret = Val(EpsonOCX.GetExtraField(1))

            ShowStatus("Comprobante generado nº " & ret)

            EpsonOCX.ClosePort()

            Return ret

        Catch ex As Exception

            If Not EpsonOCX Is Nothing Then
                EpsonOCX.ClosePort()
            End If

            MessageBox.Show("Emitir comprobante fiscal error: " & ex.Message, "EmitirComprobante", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function

    Public Sub CancelarCbteFiscal()

        Dim sCmd As String
        Dim bAnswer As Boolean

        Try

            EpsonOCX = New EpsonFPHostControlX.EpsonFPHostControl



            bAnswer = True

            EpsonOCX.ClosePort()

            Call FiscalDelay(EpsonOCX)

            EpsonOCX.CommPort = My.Settings.PuertoCommFiscal

            EpsonOCX.BaudRate = EpsonFPHostControlX.TxBaudRate.br9600

            EpsonOCX.ProtocolType = EpsonFPHostControlX.TxProtocolType.protocol_Compatible

            If Not (EpsonOCX.OpenPort) Then
                Throw New Exception("Error al intentar abrir el puerto de comunicaciones del IF")
            End If

            ShowStatus("Apertura del puerto de comunicaciones nº " & EpsonOCX.CommPort + 1)

            Call FiscalDelay(EpsonOCX)

            sCmd = Convert.ToChar(100)
            If bAnswer Then bAnswer = EpsonOCX.AddDataField(sCmd)
            If bAnswer Then bAnswer = EpsonOCX.AddDataField("CANCELAR FACTURA") 'LEYENDA PAGOS/RECARGOS/DESCUENTOS/CANCELAR FACTURA/NOTA CREDITO/ETC.
            If bAnswer Then bAnswer = EpsonOCX.AddDataField("000000000.00".Replace(".", "")) 'MONTO DEL PAGO, DESCUENTO O RECARGO
            'D:DESCUENTO DE MONTO FIJO, 
            'R:RECARGO DE MONTO FIJO,
            'C:CANCELA COMPROBANTE,
            'T:SUMA AL IMPORTE PAGADAO,
            't:ANULA PAGO HECHO CON T
            If bAnswer Then bAnswer = EpsonOCX.AddDataField("C")
            If bAnswer Then bAnswer = EpsonOCX.SendCommand
            Call FiscalDelay(EpsonOCX)
            If EpsonOCX.ReturnCode <> 0 Then ShowMsg(EpsonOCX)

            ShowStatus("Cancelación del comprobante")

            Call FiscalDelay(EpsonOCX)

            If EpsonOCX.ReturnCode <> 0 Then ShowMsg(EpsonOCX)

            EpsonOCX.ClosePort()

        Catch ex As Exception

            If Not EpsonOCX Is Nothing Then
                EpsonOCX.ClosePort()
            End If

            MessageBox.Show("Cancelar comprobante fiscal error: " & ex.Message, "CancelarCbteFiscal", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Public Sub FiscalDelay(ByRef pFiscal As EpsonFPHostControlX.EpsonFPHostControl)

        Dim Start1 As Double

        Start1 = Microsoft.VisualBasic.Timer

        Do While pFiscal.State = EpsonFPHostControlX.TxFiscalState.EFP_S_Busy
            Do While Microsoft.VisualBasic.Timer < Start1

                Application.DoEvents()

                If Start1 > Microsoft.VisualBasic.Timer Then          '   This is to
                    Exit Do                     '   compensate for the
                End If                          '   AM to PM change
            Loop

            Application.DoEvents()

        Loop                  '
    End Sub

    Public Sub ShowMsg(ByRef pFiscal As EpsonFPHostControlX.EpsonFPHostControl)
        MsgBox("Código de Retorno: " + Format(Hex(pFiscal.ReturnCode), "0000") _
                    + vbCrLf + "Estado Impresora: " + Format(Hex(pFiscal.PrinterStatus), "0000") _
                    + vbCrLf + "Estado Fiscal: " + Format(Hex(pFiscal.FiscalStatus), "0000"), _
                    vbOKOnly + vbExclamation, "Información de respuesta")
    End Sub

    Public Sub CierreZ()
        Dim sCmd As String
        Dim bAnswer As Boolean

        Try

            EpsonOCX = New EpsonFPHostControlX.EpsonFPHostControl

            bAnswer = True

            EpsonOCX.ClosePort()

            Call FiscalDelay(EpsonOCX)

            EpsonOCX.CommPort = My.Settings.PuertoCommFiscal

            EpsonOCX.BaudRate = EpsonFPHostControlX.TxBaudRate.br9600

            EpsonOCX.ProtocolType = EpsonFPHostControlX.TxProtocolType.protocol_Compatible

            If Not (EpsonOCX.OpenPort) Then
                Throw New Exception("Error al intentar abrir el puerto de comunicaciones del IF")
            End If

            ShowStatus("Apertura del puerto de comunicaciones nº " & EpsonOCX.CommPort + 1)

            Call FiscalDelay(EpsonOCX)

            sCmd = Convert.ToChar(57)
            If bAnswer Then bAnswer = EpsonOCX.AddDataField(sCmd)
            If bAnswer Then bAnswer = EpsonOCX.AddDataField("Z")
            If bAnswer Then bAnswer = EpsonOCX.AddDataField("P")
            If bAnswer Then bAnswer = EpsonOCX.SendCommand
            Call FiscalDelay(EpsonOCX)
            If EpsonOCX.ReturnCode <> 0 Then ShowMsg(EpsonOCX)

            ShowStatus("Cierre Zeta")

            Call FiscalDelay(EpsonOCX)

            If EpsonOCX.ReturnCode <> 0 Then ShowMsg(EpsonOCX)

            EpsonOCX.ClosePort()

        Catch ex As Exception

            If Not EpsonOCX Is Nothing Then
                EpsonOCX.ClosePort()
            End If

            MessageBox.Show("Cierre Zeta error: " & ex.Message, "CierreZ", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Public Sub CierreX()
        Dim sCmd As String
        Dim bAnswer As Boolean

        Try

            EpsonOCX = New EpsonFPHostControlX.EpsonFPHostControl

            bAnswer = True

            EpsonOCX.ClosePort()

            Call FiscalDelay(EpsonOCX)

            EpsonOCX.CommPort = My.Settings.PuertoCommFiscal

            EpsonOCX.BaudRate = EpsonFPHostControlX.TxBaudRate.br9600

            EpsonOCX.ProtocolType = EpsonFPHostControlX.TxProtocolType.protocol_Compatible

            If Not (EpsonOCX.OpenPort) Then
                Throw New Exception("Error al intentar abrir el puerto de comunicaciones del IF")
            End If

            ShowStatus("Apertura del puerto de comunicaciones nº " & EpsonOCX.CommPort + 1)

            Call FiscalDelay(EpsonOCX)

            sCmd = Convert.ToChar(57)
            If bAnswer Then bAnswer = EpsonOCX.AddDataField(sCmd)
            If bAnswer Then bAnswer = EpsonOCX.AddDataField("X")
            If bAnswer Then bAnswer = EpsonOCX.AddDataField("P")
            If bAnswer Then bAnswer = EpsonOCX.SendCommand
            Call FiscalDelay(EpsonOCX)
            If EpsonOCX.ReturnCode <> 0 Then ShowMsg(EpsonOCX)

            ShowStatus("Cierre X")

            Call FiscalDelay(EpsonOCX)

            If EpsonOCX.ReturnCode <> 0 Then ShowMsg(EpsonOCX)

            EpsonOCX.ClosePort()

        Catch ex As Exception

            If Not EpsonOCX Is Nothing Then
                EpsonOCX.ClosePort()
            End If

            MessageBox.Show("Cierre X error: " & ex.Message, "CierreX", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Public Sub AuditoriaPorZeta(ByVal desde As Integer, ByVal hasta As Integer)
        Dim sCmd As String
        Dim bAnswer As Boolean

        Try

            EpsonOCX = New EpsonFPHostControlX.EpsonFPHostControl

            bAnswer = True

            EpsonOCX.ClosePort()

            Call FiscalDelay(EpsonOCX)

            EpsonOCX.CommPort = My.Settings.PuertoCommFiscal

            EpsonOCX.BaudRate = EpsonFPHostControlX.TxBaudRate.br9600

            EpsonOCX.ProtocolType = EpsonFPHostControlX.TxProtocolType.protocol_Compatible

            If Not (EpsonOCX.OpenPort) Then
                Throw New Exception("Error al intentar abrir el puerto de comunicaciones del IF")
            End If

            ShowStatus("Apertura del puerto de comunicaciones nº " & EpsonOCX.CommPort + 1)

            Call FiscalDelay(EpsonOCX)

            sCmd = Convert.ToChar(59)
            If bAnswer Then bAnswer = EpsonOCX.AddDataField(sCmd)
            If bAnswer Then bAnswer = EpsonOCX.AddDataField(desde)
            If bAnswer Then bAnswer = EpsonOCX.AddDataField(hasta)
            If bAnswer Then bAnswer = EpsonOCX.AddDataField("D")
            If bAnswer Then bAnswer = EpsonOCX.SendCommand
            Call FiscalDelay(EpsonOCX)
            If EpsonOCX.ReturnCode <> 0 Then ShowMsg(EpsonOCX)

            ShowStatus("Auditoría por Zeta, desde el nº " & desde.ToString & " al nº " & hasta.ToString)

            Call FiscalDelay(EpsonOCX)

            If EpsonOCX.ReturnCode <> 0 Then ShowMsg(EpsonOCX)

            EpsonOCX.ClosePort()

        Catch ex As Exception

            If Not EpsonOCX Is Nothing Then
                EpsonOCX.ClosePort()
            End If

            MessageBox.Show("Auditoría por Zeta error: " & ex.Message, "AuditoriaPorZeta", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Public Sub AuditoriaPorFecha(ByVal desde As Date, ByVal hasta As Date)
        Dim sCmd As String
        Dim bAnswer As Boolean

        Try

            EpsonOCX = New EpsonFPHostControlX.EpsonFPHostControl

            bAnswer = True

            EpsonOCX.ClosePort()

            Call FiscalDelay(EpsonOCX)

            EpsonOCX.CommPort = My.Settings.PuertoCommFiscal

            EpsonOCX.BaudRate = EpsonFPHostControlX.TxBaudRate.br9600

            EpsonOCX.ProtocolType = EpsonFPHostControlX.TxProtocolType.protocol_Compatible

            If Not (EpsonOCX.OpenPort) Then
                Throw New Exception("Error al intentar abrir el puerto de comunicaciones del IF")
            End If

            ShowStatus("Apertura del puerto de comunicaciones nº " & EpsonOCX.CommPort + 1)

            Call FiscalDelay(EpsonOCX)

            sCmd = Convert.ToChar(58)
            If bAnswer Then bAnswer = EpsonOCX.AddDataField(sCmd)
            If bAnswer Then bAnswer = EpsonOCX.AddDataField(desde.ToString("yyMMdd"))
            If bAnswer Then bAnswer = EpsonOCX.AddDataField(hasta.ToString("yyMMdd"))
            If bAnswer Then bAnswer = EpsonOCX.AddDataField("D")
            If bAnswer Then bAnswer = EpsonOCX.SendCommand
            Call FiscalDelay(EpsonOCX)
            If EpsonOCX.ReturnCode <> 0 Then ShowMsg(EpsonOCX)

            ShowStatus("Audítoria por Fecha, desde el " & desde.ToString("dd/MM/yyyy") & " al " & hasta.ToString("dd/MM/yyyy"))

            Call FiscalDelay(EpsonOCX)

            If EpsonOCX.ReturnCode <> 0 Then ShowMsg(EpsonOCX)

            EpsonOCX.ClosePort()

        Catch ex As Exception

            If Not EpsonOCX Is Nothing Then
                EpsonOCX.ClosePort()
            End If

            MessageBox.Show("Auditoria por Fecha error: " & ex.Message, "AuditoriaPorFecha", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Public Function ConstatacionDeComprobante(ByVal cbte As wscdc.CmpDatos) As wscdc.CmpResponse
        Dim objWSCDC As wscdc.Service
        Dim objCDCAuthRequest As wscdc.CmpAuthRequest
        Dim objCDCRequest As wscdc.CmpDatos
        Dim objCDCResponse As wscdc.CmpResponse

        Try

            If Not ConexionConAFIPCDC() Then

                CrearConexionAFIPCDC()

                If Not ConexionConAFIPCDC() Then
                    Throw New Exception("No se puede establecer la conexión con el WSAA")
                End If

            End If

            objWSCDC = New wscdc.Service
            objWSCDC.Url = My.Settings.UrlWscdc

            objCDCAuthRequest = New wscdc.CmpAuthRequest
            objCDCRequest = New wscdc.CmpDatos
            objCDCResponse = New wscdc.CmpResponse

            objCDCAuthRequest.Cuit = _cuit
            objCDCAuthRequest.Sign = _sign
            objCDCAuthRequest.Token = _token

            objCDCRequest = cbte

            objCDCResponse = objWSCDC.ComprobanteConstatar(objCDCAuthRequest, objCDCRequest)

            Return objCDCResponse

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "WS - Constatación de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return Nothing

        Finally
            objWSCDC = Nothing
            objCDCAuthRequest = Nothing
            objCDCRequest = Nothing
            objCDCResponse = Nothing
        End Try

    End Function

    Public Function ConexionConAFIPCDC() As Boolean

        Dim RUTATICKETACCESO = My.Settings.WsaaRutaTicket & "\cdc\TA.xml"      ' Debe indicar la Ruta de su Ticket de acceso
        Dim tokenBytes As Byte()
        Dim tokenString As String

        mensajes.Clear()

        ' Obtengo del tikcet de acceso los campos token, sign y las CUIT del tag relations
        If FileExists(RUTATICKETACCESO) Then
            Dim xmldCredentials As XmlDocument
            Dim xmlnlCredentials As XmlNodeList
            Dim xmlnCredentials As XmlNode

            Dim xmldHeader As XmlDocument
            Dim xmlnlHeader As XmlNodeList
            Dim xmlnHeader As XmlNode

            xmldHeader = New XmlDocument()
            xmldHeader.Load(RUTATICKETACCESO)
            xmlnlHeader = xmldHeader.SelectNodes("/loginTicketResponse/header")

            For Each xmlnHeader In xmlnlHeader
                _generationTime = Convert.ToDateTime(xmlnHeader.ChildNodes.Item(3).InnerText)
                _expirationTime = Convert.ToDateTime(xmlnHeader.ChildNodes.Item(4).InnerText)
            Next

            xmldCredentials = New XmlDocument()
            xmldCredentials.Load(RUTATICKETACCESO)
            xmlnlCredentials = xmldCredentials.SelectNodes("/loginTicketResponse/credentials")

            For Each xmlnCredentials In xmlnlCredentials
                _token = xmlnCredentials.ChildNodes.Item(0).InnerText
                _sign = xmlnCredentials.ChildNodes.Item(1).InnerText

                tokenBytes = System.Convert.FromBase64String(xmlnCredentials.ChildNodes.Item(0).InnerText)
                tokenString = System.Text.Encoding.UTF8.GetString(tokenBytes)
                Dim xmldToken As XmlDocument
                Dim xmlnlToken As XmlNodeList
                Dim xmlnToken As XmlNode
                xmldToken = New XmlDocument()
                xmldToken.LoadXml(tokenString)
                xmlnlToken = xmldToken.SelectNodes("/sso/operation/login/relations/relation")
                For Each xmlnToken In xmlnlToken
                    _cuit = xmlnToken.Attributes("key").InnerText
                Next
            Next

            If _expirationTime < Date.Now Then
                mensajes.AppendLine("Certificado expirado")
                ShowStatus("Certificado expirado")
                Return False
            End If

        Else
            mensajes.AppendLine("No se encontró el ticket de acceso (Archivo: " + RUTATICKETACCESO + ").")
            ShowStatus("No se encontró el ticket de acceso (Archivo: " + RUTATICKETACCESO + ").")
            Return False
        End If

        ChequearStatusServer()

        Return True

    End Function

    Public Function CrearConexionAFIPCDC() As Integer
        Dim wsaa As New AFIPWsaa.WsaaLogin
        Dim ret As Integer
        Dim password As New SecureString

        Try

            For Each character As Char In My.Settings.WsaaCertificadoPassword.ToCharArray
                password.AppendChar(character)
            Next

            With wsaa
                .IdServicioNegocio = My.Settings.WscdcIdServicio
                .OutputFolder = My.Settings.WsaaRutaTicket & "\cdc"

                If Not Directory.Exists(.OutputFolder) Then
                    Directory.CreateDirectory(.OutputFolder)
                End If

                .PasswordSecureString = password
                .Proxy = ""
                .ProxyPassword = ""
                .RutaCertSigner = My.Settings.WsaaCertificado
                .UrlWsaaWsdl = My.Settings.UrlWsaa
                .VerboseMode = True
                ret = .Login()

                If ret < 0 Then Throw New Exception(.Mensajes)

            End With

            Return ret

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return ret
        End Try

    End Function

End Class
