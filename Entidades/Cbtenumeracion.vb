Public Class Cbtenumeracion

    Property Id As UInt32
    Property Ptovta As UInt32
    Property Cbtetipo As UInt32
    Property Numero As UInt32
    Property NumeroAfip As UInt32

    Private Const FACTURA_A As UInt32 = 1
    Private Const FACTURA_B As UInt32 = 6
    Private Const FACTURA_C As UInt32 = 11
    Private Const FACTURA_M As UInt32 = 51
    Private Const NOTA_DEBITO_A As UInt32 = 2
    Private Const NOTA_DEBITO_C As UInt32 = 12
    Private Const NOTA_CREDITO_C As UInt32 = 13
    Private Const NOTA_DEBITO_B As UInt32 = 7
    Private Const TIQUE_FACTURA_A As UInt32 = 81
    Private Const TIQUE_FACTURA_B As UInt32 = 82
    Private Const TIQUE As UInt32 = 83
    Private Const NOTA_CREDITO_A As UInt32 = 3
    Private Const NOTA_CREDITO_B As UInt32 = 8
    Private Const PRESUPUESTO As UInt32 = 991
    Private Const DEVOLUCION_PRESUPUESTO As UInt32 = 992
    Private Const RECIBO_COBRANZA As UInt32 = 993
    Private Const ORDEN_PAGO As UInt32 = 994
    Private Const RECIBO_PRESUPUESTO As UInt32 = 995
    Private Const PAGO_PRESUPUESTO As UInt32 = 996
    Private Const REMITO As UInt32 = 91
    Private Const TIQUE_NOTA_DE_CREDITO As UInt32 = 110
    Private Const TIQUE_FACTURA_C As UInt32 = 111
    Private Const TIQUE_NOTA_DE_CREDITO_A As UInt32 = 112
    Private Const TIQUE_NOTA_DE_CREDITO_B As UInt32 = 113

    ReadOnly Property Denominacion As String
        Get
            Select Case Cbtetipo

                Case FACTURA_A : Return "FACTURA A"
                Case FACTURA_B : Return "FACTURA B"
                Case FACTURA_C : Return "FACTURA C"
                Case FACTURA_M : Return "FACTURA M"
                Case NOTA_DEBITO_A : Return "NOTA DEBITO A"
                Case NOTA_DEBITO_B : Return "NOTA DEBITO B"
                Case NOTA_DEBITO_C : Return "NOTA DEBITO C"
                Case TIQUE_FACTURA_A : Return "TIQUE FACTURA A"
                Case TIQUE_FACTURA_B : Return "TIQUE FACTURA B"
                Case TIQUE : Return "TIQUE"
                Case NOTA_CREDITO_A : Return "NOTA CREDITO A"
                Case NOTA_CREDITO_B : Return "NOTA CREDITO B"
                Case NOTA_CREDITO_C : Return "NOTA CREDITO C"
                Case PRESUPUESTO : Return "PRESUPUESTO"
                Case DEVOLUCION_PRESUPUESTO : Return "DEVOLUCION P."
                Case RECIBO_COBRANZA : Return "RECIBO"
                Case ORDEN_PAGO : Return "ORDEN DE PAGO"
                Case RECIBO_PRESUPUESTO : Return "RECIBO P."
                Case PAGO_PRESUPUESTO : Return "PAGO P."
                Case REMITO : Return "REMITO"
                Case TIQUE_FACTURA_C : Return "TIQUE FACTURA C"
                Case TIQUE_NOTA_DE_CREDITO : Return "TIQUE NOTA DE CREDITO"
                Case TIQUE_NOTA_DE_CREDITO_A : Return "TIQUE NOTA DE CREDITO A"
                Case TIQUE_NOTA_DE_CREDITO_B : Return "TIQUE NOTA DE CREDITO B"
                Case Else : Return "NO DEFINIDO"

            End Select

        End Get
    End Property

End Class
