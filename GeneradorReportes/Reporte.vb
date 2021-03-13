Imports System.Drawing
Imports System.IO

Public Class Reporte
    Property Nombre As String
    Property SourceFile As String
    Property Parametros As New Parametros

    Private rdl As New fyiReporting.RdlViewer.RdlViewer

    Public Function SaveAsPDF() As String
        Dim filename As String = ""
        Dim path As String = ""
        Try

            path = My.Application.Info.DirectoryPath & "\comprobantes\pdf"
            filename = path & "\" & Me.Nombre & ".pdf"

            If Not Directory.Exists(path) Then
                Directory.CreateDirectory(path)
            End If

            rdl.Parameters = Me.Parametros.ToString
            rdl.SourceFile = New Uri(Me.SourceFile)
            rdl.ReportName = Me.Nombre
            rdl.SaveAs(filename, fyiReporting.RDL.OutputPresentationType.PDF)

            Return filename

        Catch ex As Exception

            Throw New Exception(ex.Message)

            'Return filename

        End Try

    End Function

    Public Sub PrintReport(Optional ByVal copies As Short = 1)
        Dim pd As New Printing.PrintDocument()

        Try
            pd.DocumentName = rdl.ReportName
            pd.PrinterSettings.FromPage = 1
            pd.PrinterSettings.ToPage = rdl.PageCount
            pd.PrinterSettings.MaximumPage = rdl.PageCount
            pd.PrinterSettings.MinimumPage = 1
            pd.PrinterSettings.Copies = copies

            If (rdl.PageWidth > rdl.PageHeight) Then
                pd.DefaultPageSettings.Landscape = True
            Else
                pd.DefaultPageSettings.Landscape = False
            End If



            rdl.Parameters = Me.Parametros.ToString
            rdl.SourceFile = New Uri(Me.SourceFile)
            rdl.ReportName = Me.Nombre

            rdl.Print(pd)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    Public Sub ShowReport()
        Dim a As New FormReportViewer

        With a
            .Text = Me.Nombre
            .Reporte = Me
            .Show()
        End With
    End Sub

    Public Function CrearBarCode(ByVal codigo As String) As String

        Dim b = New BarcodeLib.Barcode()
        Dim ret As String = ""

        Dim path As String = My.Application.Info.DirectoryPath & "\imagenes\barcodes"
        Dim filename As String = path & "\" & codigo & ".png"

        If Not Directory.Exists(path) Then
            Directory.CreateDirectory(path)
        End If

        b.IncludeLabel = True
        b.LabelFont = New Font("Tahoma", 8, FontStyle.Regular)
        b.Encode(BarcodeLib.TYPE.Interleaved2of5, codigo, 300, 50)
        b.SaveImage(filename, BarcodeLib.SaveTypes.PNG)

        Return filename


    End Function

    Public Sub New()
        'al instanciar la clase reporte le asigno el DSN correspondiente
        Me.Parametros.Add(New Parametro("dsn", Configuracion.ConfigManager.GetValue("dsnString")))
    End Sub
End Class
