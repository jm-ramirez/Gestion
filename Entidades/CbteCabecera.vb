Public Class CbteCabecera

    Property Id As UInt32
    Property Concepto As Int32
    Property Clienteid As UInt32
    Property Razonsocial As String
    Property Domicilio As String
    Property Nroremito As String
    Property Documentotipo As Int32
    Property Documentonro As UInt64
    Property Cbtetipo As Int32
    Property Cbteptovta As Int32
    Property Cbtenumero As UInt32
    Property Cbtefecha As String
    Property Formadepago As UInt32
    Property Importetotal As Double
    Property Importetotalconceptos As Double
    Property Importeneto As Double
    Property Importeopexentas As Double
    Property Importeiva As Double
    Property Importetributos As Double
    Property Importectaspropias As Double
    Property Importecartera As Double
    Property Fechaserviciodesde As String
    Property Fechaserviciohasta As String
    Property Fechavtopago As String
    Property Monedaid As String = "PES"
    Property Monedactz As Double = 1
    Property Cae As String
    Property Fechavtocae As String
    Property Observaciones As String = ""
    Property Tiporesponsable As UInt32
    Property Cuitemisor As UInt64
    Property Usuario As UInt32
    'Property Fechatransaccion As Date
    Property Vendedor As UInt32
    Property Sucursal As UInt32
    Property Descuento As Double
    Property Letra As Char
    Property Denominacion As String
    Property Tipo As Char
    Property ObservacionesExtra As String
    Property RemitoId As UInt32
    Property IdCbteFc As UInt32
    Property Kgs As Double
    'estas propiedades no se almacenan en la base de datos, son informativas al momento de autorizar el cbte.
    Property Resultado As String = ""
    Property Reproceso As String = ""
    Property Errores As String = ""
    Property Eventos As String = ""

    'propiedades relacionadas con otras tablas de detalle
    Property CbteAlicuotas As New List(Of Entidades.CbteAlicuota)
    Property CbteTributos As New List(Of Entidades.CbteTributo)
    
    Property CbteArticulos As New List(Of Entidades.CbteArticulo)
    Property CbteAsociados As New List(Of Entidades.CbteAsociado)
    Property CbteDetalleFinanciero As New List(Of Entidades.Financiero)
    Property CbteEstadoCuenta As New List(Of Entidades.CbteAsociado)

    Property Remito As New List(Of Entidades.Remito)

    Private Const FACTURA_A As UInt32 = 1
    Private Const FACTURA_B As UInt32 = 6
    Private Const NOTA_DEBITO_A As UInt32 = 2
    Private Const NOTA_DEBITO_B As UInt32 = 7
    Private Const TIQUE_FACTURA_A As UInt32 = 81
    Private Const TIQUE_FACTURA_B As UInt32 = 82
    Private Const NOTA_CREDITO_A As UInt32 = 3
    Private Const NOTA_CREDITO_B As UInt32 = 8

    Private _cbteDenominacion As String
    ReadOnly Property CbteDenominacion As String
        Get
            _cbteDenominacion = Me.Denominacion & " " & Me.Letra
            _cbteDenominacion &= " " & Me.Cbteptovta.ToString.PadLeft(4, "0")
            _cbteDenominacion &= "-" & Me.Cbtenumero.ToString.PadLeft(8, "0")

            Return _cbteDenominacion
        End Get
    End Property

    ReadOnly Property CbteNumeroFmt As String
        Get
            Return Me.Cbteptovta.ToString.PadLeft(4, "0") & "-" & Me.Cbtenumero.ToString.PadLeft(8, "0")
        End Get
    End Property

    ReadOnly Property FechaEmision
        Get
            Return ParseStringToDate(Me.Cbtefecha)
        End Get
    End Property

    ReadOnly Property FechaVencimiento
        Get
            Return ParseStringToDate(Me.Fechavtopago)
        End Get
    End Property

    Public Function CodigoBarras() As String

        Dim codigobarra As String = ""

        codigobarra = CuitEmisor & CbteTipo.ToString.PadLeft(2, "0") & CbtePtoVta.ToString.PadLeft(4, "0") & CAE & FechaVtoCAE

        codigobarra &= GetDigitoVerificador(codigobarra)

        Return codigobarra

    End Function

    ''' <summary>
    ''' Function para el calculo del dígito verificador
    ''' </summary>
    ''' <param name="codigo"></param>
    ''' <returns>Dígito verificador calculado</returns>
    ''' <remarks></remarks>
    Private Function GetDigitoVerificador(ByVal codigo As String) As Long

        Dim ret As Long = 0

        Dim i As Integer


        Dim impares As Long
        Dim impares3 As Long
        Dim pares As Long
        Dim total As Long

        'Ahora analizo la cadena de caracteres:
        'Tengo que sumar todos los caracteres impares y los pares
        pares = 0 : impares = 0

        For i = 1 To codigo.Length
            If i Mod 2 = 0 Then
                ' Si el valor de I es par entra por aca
                pares = pares + CLng(Mid(codigo, i, 1))
            Else
                'Si el valor de I es impar entra por aca
                impares = impares + CLng(Mid(codigo, i, 1))
            End If
        Next i

        impares3 = 3 * impares
        total = pares + impares3

        ret = 10 - (total Mod 10)

        'Si el Dígito Verificador es 10, como es un Nro. le mando cero porque ya es 10
        If ret = 10 Then
            ret = 0
        End If

        Return ret

    End Function

    Private Function ParseStringToDate(ByVal dateString As String) As String
        Dim format As String
        Dim result As String
        Dim provider As Globalization.CultureInfo = Globalization.CultureInfo.InvariantCulture

        format = "yyyyMMdd"

        Try
            result = Date.ParseExact(dateString, format, provider).Date
            Return result
        Catch e As FormatException
            Return dateString
        End Try

    End Function

    ''' <summary>
    ''' Retorna el saldo de la cuenta corriente
    ''' </summary>
    ''' <returns>Saldo final de la cuenta corriente</returns>
    ''' <remarks></remarks>
    Public Function SaldoEstadoCuenta() As Double

        Dim saldo As Double = Me.Importetotal

        For Each obj As Entidades.CbteAsociado In Me.CbteEstadoCuenta
            saldo += obj.Importe
        Next


        Return Math.Round(saldo, 2)

    End Function

    ''' <summary>
    ''' Retorna el saldo del comprobante segun aplicaciones en ctacte
    ''' </summary>
    ''' <returns>Saldo final de la cuenta corriente</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SaldoAsociado() As Double
        Get

            Dim saldo As Double = Me.Importetotal

            For Each obj As Entidades.CbteAsociado In Me.CbteAsociados
                saldo -= obj.Importe
            Next

            Return Math.Round(saldo, 2)
        End Get
    End Property



    
End Class
