Public Class Articulo
    Property Id As UInt32
    'Property Codcliente As String

    'Property Rev As String
    'Property Moldeo As String
    'Property Colada As String
    'Property Pintura As String
    'Property Material As String
    Property Pesoneto As Double
    Property Pesobruto As Double
    'Property Codmaterial As String
    'Property Cantcajasnoyos As UInt32
    'Property Casillero As UInt32
    'Property Cantmodelostk As UInt32
    'Property Tipomodelo As String
    'Property Detallecajas As String

    Property Observacion As String

    'Property Plu As String
    Property Codigo As String
    Property Codigobarra As String
    Property Nombre As String
    Property Nombrecorto As String
    Property Descripcion As String
    Property Codrubro As String
    Property Alicuotaiva As UInt32
    Property Impinttasanominal As Double
    ''' <summary>
    ''' Básico para Lista 1
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Preciodeventa As Double
    ''' <summary>
    ''' Básico para Lista 2
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Preciodeventa2 As Double
    ''' <summary>
    ''' Básico para Lista 3
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Preciodeventa3 As Double
    Property Preciosugerido As Double
    Property Preciodecosto As Double
    Property Activo As Boolean
    Property Preciomodificable As Boolean
    Property Codunidad As String
    Property Codcategoria As String
    Property Fechaultimacompra As Date
    Property Preciodecompra As Double
    Property Descuento As Double
    Property Descuento2 As Double
    Property Descuento3 As Double
    Property Puntominimo As Double
    Property Oferta As Boolean

    Property ComisionPrecio1 As Double
    Property ComisionPrecio2 As Double
    Property ComisionPrecio3 As Double

    Property Impuestointerno As Double

    Property ExistenciaReal As Double
    Property ExistenciaActual As Double
    'Property ExistenciaDiferencia As Double

    'Property Codproveedor As String

    Property CantidadBulto As Double
    Property Descuentocompra1 As Double
    Property Descuentocompra2 As Double
    Property Descuentocompra3 As Double
    Property Descuentocompra4 As Double
    Property Rentabilidad1 As Double
    Property Rentabilidad2 As Double
    Property Rentabilidad3 As Double

    Property CoeficienteKG As Double
    'Property PreciocostoUS As Double
    'Property Flete As Boolean
    Property Precioventaanterior As Double
    Property Precioventaanterior2 As Double
    Property Precioventaanterior3 As Double
    Property FechaAlta As Date

    'Property Unidaddescripcion As String
    Property Preciomodificado As Boolean

    'Property Planos As List(Of Planos)
    'Property Fotos As List(Of Fotos)
    'Property Cliente As String

    'Property NroPlano1 As String
    'Property NroPlano2 As String
    'Property NroPlano3 As String

    'Property RutaFoto1 As String
    'Property RutaFoto2 As String
    'Property RutaFoto3 As String
    'Property RutaFoto4 As String
    'Property RutaFoto5 As String
    'Property RutaFoto6 As String

    Property NombreUnidad As String
    Property SimboloUnidad As String
    Property NombreRubro As String

    Public ReadOnly Property NombreyCodigo As String
        Get
            Return Me.Nombre & " [" & Me.Codigo & "]"
        End Get
    End Property

    Public ReadOnly Property CodigoyNombre As String
        Get
            Return Me.Codigo & " - " & Me.Nombre
        End Get
    End Property

    Public ReadOnly Property CodigoRev As String
        Get
            Return Me.Codigo '& Me.Rev
        End Get
    End Property

    ReadOnly Property NombreDescripcion As String
        Get
            Return Me.Nombre & vbNewLine & Me.Descripcion
        End Get
    End Property

    ReadOnly Property ExistenciaDiferencia As Double
        Get
            Return Me.ExistenciaReal - Me.ExistenciaActual
        End Get
    End Property

    Private Const CODIGO_ALIC_EXENTO As UInteger = 2
    Private Const CODIGO_ALIC_NOGRAVADO As UInteger = 1

    ReadOnly Property Alicuota As Double
        Get
            Select Case Alicuotaiva
                Case 1, 2, 3 : Return 0
                Case 4 : Return 10.5
                Case 5 : Return 21.0
                Case 6 : Return 27.0
                Case 8 : Return 5.0
                Case 9 : Return 2.5
                Case Else : Return 0
            End Select
        End Get
    End Property

    ReadOnly Property BasicoLista1 As Double
        Get
            Return Me.Preciodeventa
        End Get
    End Property

    ReadOnly Property BasicoLista2 As Double
        Get
            Return Me.Preciodeventa2
        End Get
    End Property

    ReadOnly Property BasicoLista3 As Double
        Get
            Return Me.Preciodeventa3
        End Get
    End Property

    ReadOnly Property ImpuestoInternoLista1 As Double
        Get
            'Return Math.Round(BasicoRevendedor * (Math.Round(((100 * Impinttasanominal) / (100 - Impinttasanominal)) / 100, 5)), 3)
            Return Math.Round(Impuestointerno, 4)
        End Get
    End Property

    ReadOnly Property ImpuestoInternoLista2 As Double
        Get
            'Return Math.Round(BasicoKiosko * (Math.Round(((100 * Impinttasanominal) / (100 - Impinttasanominal)) / 100, 5)), 3)
            Return Math.Round(Impuestointerno, 4)
        End Get
    End Property

    ReadOnly Property ImpuestoInternoLista3 As Double
        Get
            'Return Math.Round(BasicoMostrador * (Math.Round(((100 * Impinttasanominal) / (100 - Impinttasanominal)) / 100, 5)), 3)
            Return Math.Round(Impuestointerno, 4)
        End Get
    End Property

    ReadOnly Property ImporteIVALista1 As Double
        Get
            Return Math.Round(BasicoLista1 * (Alicuota / 100), 3)
        End Get
    End Property

    ReadOnly Property ImporteConIVALista1 As Double
        Get
            Return Math.Round(BasicoLista1 + ImporteIVALista1, 3)
        End Get
    End Property

    ReadOnly Property ImporteFinalLista1 As Double
        Get
            Return Math.Round(ImporteConIVALista1 + ImpuestoInternoLista1, 3)
        End Get
    End Property

    ReadOnly Property ImporteIVALista2 As Double
        Get
            Return Math.Round(BasicoLista2 * (Alicuota / 100), 3)
        End Get
    End Property

    ReadOnly Property ImporteConIVALista2 As Double
        Get
            Return Math.Round(BasicoLista2 + ImporteIVALista2, 3)
        End Get
    End Property

    ReadOnly Property ImporteFinalLista2 As Double
        Get
            Return Math.Round(ImporteConIVALista2 + ImpuestoInternoLista2, 3)
        End Get
    End Property

    ReadOnly Property ImporteIVALista3 As Double
        Get
            Return Math.Round(BasicoLista3 * (Alicuota / 100), 3)
        End Get
    End Property

    ReadOnly Property ImporteConIVALista3 As Double
        Get
            Return Math.Round(BasicoLista3 + ImporteIVALista3, 3)
        End Get
    End Property

    ReadOnly Property ImporteFinalLista3 As Double
        Get
            Return Math.Round(ImporteConIVALista3 + ImpuestoInternoLista3, 3)
        End Get
    End Property

    ReadOnly Property RentabilidadLista1 As Double
        Get
            If BasicoLista1 <> 0 Then
                Return Math.Round(((BasicoLista1 - Preciodecosto) / BasicoLista1) * 100, 2)
            Else
                Return 0.0
            End If
        End Get
    End Property

    ReadOnly Property RentabilidadLista2 As Double
        Get
            If BasicoLista2 <> 0 Then
                Return Math.Round(((BasicoLista2 - Preciodecosto) / BasicoLista2) * 100, 2)
            Else
                Return 0.0
            End If
        End Get
    End Property

    ReadOnly Property RentabilidadLista3 As Double
        Get
            If BasicoLista3 <> 0 Then
                Return Math.Round(((BasicoLista3 - Preciodecosto) / BasicoLista3) * 100, 2)
            Else
                Return 0.0
            End If
        End Get
    End Property

    ReadOnly Property ImporteDescuentoLista1 As Double
        Get
            Return Math.Round(BasicoLista1 * (Descuento / 100), 3)
        End Get
    End Property

    ReadOnly Property ImporteDescuentoLista2 As Double
        Get
            Return Math.Round(BasicoLista2 * (Descuento2 / 100), 3)
        End Get
    End Property

    ReadOnly Property ImporteDescuentoLista3 As Double
        Get
            Return Math.Round(BasicoLista3 * (Descuento3 / 100), 3)
        End Get
    End Property

    ReadOnly Property ImporteFinalConDescuentoLista1 As Double
        Get
            Dim basico As Double = Math.Round(BasicoLista1 - ImporteDescuentoLista1, 3)
            Dim iva As Double = Math.Round(basico * (Alicuota / 100), 3)
            Dim final As Double = Math.Round(basico + iva + ImpuestoInternoLista1, 3)

            Return final
        End Get
    End Property

    ReadOnly Property ImporteFinalConDescuentoLista2 As Double
        Get
            Dim basico As Double = Math.Round(BasicoLista2 - ImporteDescuentoLista2, 3)
            Dim iva As Double = Math.Round(basico * (Alicuota / 100), 3)
            Dim final As Double = Math.Round(basico + iva + ImpuestoInternoLista2, 3)

            Return final
        End Get
    End Property

    ReadOnly Property ImporteFinalConDescuentoLista3 As Double
        Get
            Dim basico As Double = Math.Round(BasicoLista3 - ImporteDescuentoLista3, 3)
            Dim iva As Double = Math.Round(basico * (Alicuota / 100), 3)
            Dim final As Double = Math.Round(basico + iva + ImpuestoInternoLista3, 3)

            Return final
        End Get
    End Property


End Class
