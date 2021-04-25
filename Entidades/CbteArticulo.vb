
Public Class CbteArticulo
    Property Id As UInt32
    Property Codigo As String
    Property Codcliente As String
    Property Descripcion As String
    Property DescriptorIF As String
    Property Cantidad As Double
    Property Importe As Double
    Property Descuento As Double
    Property ImpIntTasaNominal As Double
    Property ImpInterno As Double
    Property AlicuotaCodigo As UInt32
    Property Alicuota As Double
    Property Unidad As String
    Property SimboloUnidad As String
    Property Listadeprecio As UInt32
    Property Rubro As UInt32
    'Property Rev As String
    Property Kgsxunidad As Double
    Property Kgs As Double
    Property Numero As UInt32
    'Property Secuencia As UInt32
    Property Subtotal2 As Double
    ''' <summary>
    ''' Comisión del vendedor
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Comision As Double
    ''' <summary>
    ''' Comisión del supervisor
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Comision2 As Double
    ''' <summary>
    ''' Comisión del acompañante
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Comision3 As Double
    Property Modificable As Boolean


    Private Const CODIGO_ALIC_EXENTO As UInteger = 2
    Private Const CODIGO_ALIC_NOGRAVADO As UInteger = 1

    ''' <summary>
    ''' Importe menos los descuentos
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property ImporteFinal As Double
        Get
            'Return Math.Round(Importe - Importe * (Descuento / 100), 3)
            Return Math.Round(Importe - ImporteDescuento, 3)
        End Get
    End Property

    ''' <summary>
    ''' Importe de los descuentos
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property ImporteDescuento As Double
        Get
            Return Math.Round(Importe * (Descuento / 100), 4, MidpointRounding.ToEven)
        End Get
    End Property

    ''' <summary>
    ''' Incluye alicuotas e impuesto interno, sin descuento
    ''' </summary>
    Private _importeBruto As Double
    ReadOnly Property ImporteBruto As Double
        Get
            'importe neto
            _importeBruto = Math.Round(Importe, 3)
            _importeBruto += Math.Round(_importeBruto * (Alicuota / 100), 3)
            'suma del impuesto interno en base a la tasa nominal
            '_importeBruto += Math.Round(Importe * (Math.Round(((100 * ImpIntTasaNominal) / (100 - ImpIntTasaNominal)) / 100, 5)), 3)
            'suma del impuesto interno en base al importe
            _importeBruto += ImpInterno

            Return _importeBruto
        End Get
    End Property


    ''' <summary>
    ''' Propiedad que devuelve el subtotal neto gravado
    ''' </summary>
    ''' <value>Double</value>
    ''' <returns>Subtotal neto gravado</returns>
    ''' <remarks></remarks>
    ReadOnly Property Subtotal As Double
        Get
            If Me.AlicuotaCodigo <> CODIGO_ALIC_EXENTO And Me.AlicuotaCodigo <> CODIGO_ALIC_NOGRAVADO Then
                Return Math.Round(ImporteFinal * IIf(Unidad = "01", Kgs, Cantidad), 3)
            Else
                Return 0.0
            End If
        End Get
    End Property

    ReadOnly Property ImpuestoInterno As Double
        Get
            'Return Math.Round(ImporteFinal * (Math.Round(((100 * ImpIntTasaNominal) / (100 - ImpIntTasaNominal)) / 100, 5)), 3)
            Return Math.Round(ImpInterno, 3)
        End Get
    End Property

    ReadOnly Property SubtotalImpuestoInterno As Double
        Get
            Return Math.Round(ImpuestoInterno * IIf(Unidad = "01", Kgs, Cantidad), 3)
        End Get
    End Property

    ReadOnly Property BaseImponibleImpInterno As Double
        Get
            Return Math.Round((ImporteFinal + ImpuestoInterno) * IIf(Unidad = "01", Kgs, Cantidad), 3)
        End Get
    End Property

    ReadOnly Property ImporteConIVA As Double
        Get
            Return Math.Round(ImporteFinal + ImporteIVA, 3)
        End Get
    End Property

    Private _subtotalSinIVA As Double
    ReadOnly Property SubtotalSinIVA As Double
        Get

            _subtotalSinIVA = Math.Round(ImporteFinal * IIf(Unidad = "01", Kgs, Cantidad), 3)
            _subtotalSinIVA += SubtotalImpuestoInterno
            Return _subtotalSinIVA

        End Get
    End Property

    ReadOnly Property SubtotalConIVA As Double
        Get
            Return Math.Round(ImporteConIVA * IIf(Unidad = "01", Kgs, Cantidad), 3)
        End Get
    End Property

    Private _subtotalFinal As Double
    ReadOnly Property SubtotalFinal As Double
        Get
            _subtotalFinal = Math.Round(ImporteConIVA * IIf(Unidad = "01", Kgs, Cantidad), 3)
            _subtotalFinal += SubtotalImpuestoInterno
            Return _subtotalFinal
        End Get
    End Property

    ReadOnly Property ImporteIVA As Double
        Get
            Return Math.Round(ImporteFinal * (Alicuota / 100), 4, MidpointRounding.ToEven)
        End Get
    End Property

    ReadOnly Property SubtotalIVA As Double
        Get
            Return Math.Round(ImporteIVA * IIf(Unidad = "01", Kgs, Cantidad), 3, MidpointRounding.ToEven)
        End Get
    End Property

    ReadOnly Property SubtotalExento As Double
        Get
            If AlicuotaCodigo = CODIGO_ALIC_EXENTO Then
                Return Math.Round(ImporteFinal * IIf(Unidad = "01", Kgs, Cantidad), 3)
            Else
                Return 0.0
            End If
        End Get
    End Property

    ReadOnly Property SubtotalNoGravado As Double
        Get
            If AlicuotaCodigo = CODIGO_ALIC_NOGRAVADO Then
                Return Math.Round(ImporteFinal * IIf(Unidad = "01", Kgs, Cantidad), 3)
            Else
                Return 0.0
            End If
        End Get
    End Property

    ReadOnly Property Exento As Double
        Get
            If AlicuotaCodigo = CODIGO_ALIC_EXENTO Then
                Return Math.Round(ImporteFinal, 3)
            Else
                Return 0.0
            End If
        End Get
    End Property

    ReadOnly Property NoGravado As Double
        Get
            If AlicuotaCodigo = CODIGO_ALIC_NOGRAVADO Then
                Return Math.Round(ImporteFinal, 3)
            Else
                Return 0.0
            End If
        End Get
    End Property

End Class
