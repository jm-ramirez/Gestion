Imports System.Windows.Forms
Imports System.Drawing

Public Class FormReportViewer

    Property Reporte As New Reporte
    Dim rdlViewer As New fyiReporting.RdlViewer.RdlViewer
    Property _currentPage As UInt32


    Private Enum Exporta
        Excel = 0
        PDF = 1
    End Enum

    Private Enum NavReporte
        PagSig = 0
        PagAnt = 1
        PagPri = 2
        PagUlt = 3
    End Enum


    Private Sub FormReportViewer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Is = Keys.Escape
                Call Salir()
            Case Is = Keys.F1
                Call Buscar()
            Case Is = Keys.F5
                Call Imprimir()
            Case Is = Keys.F6
                Call Exportar(Exporta.Excel)
            Case Is = Keys.F7
                Call Exportar(Exporta.PDF)
        End Select
    End Sub



    Private Sub FormReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Refresh()
        Call AgregarControl()
        Call CargarReporte()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Call Salir()
    End Sub

#Region "Metodos"
    Private Sub Salir()
        Me.Close()
    End Sub

    Private Sub AgregarControl()
        Try
            With rdlViewer
                .Height = Me.Height - 125
                .Width = Me.Width - 50
                .Top = 75
                .Left = 25
                '.Dock = DockStyle.Fill
                .Anchor = System.Windows.Forms.AnchorStyles.Top Or _
                    System.Windows.Forms.AnchorStyles.Bottom Or _
                    System.Windows.Forms.AnchorStyles.Left Or _
                    System.Windows.Forms.AnchorStyles.Right
                .ZoomMode = fyiReporting.RdlViewer.ZoomEnum.UseZoom
                .Zoom = 1

                .ShowFindPanel = True
            End With

            Me.Controls.Add(rdlViewer)

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")

        End Try

    End Sub

    Private Sub CargarReporte()
        Try
            _currentPage = 1
            rdlViewer.Parameters = Me.Reporte.Parametros.ToString
            rdlViewer.SourceFile = New Uri(Me.Reporte.SourceFile)
            rdlViewer.ReportName = Me.Reporte.Nombre
            rdlViewer.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Exportar(ByVal Salida As Exporta)

        With Me.SaveFileDialog
            .InitialDirectory = "c:\"
            .ValidateNames = True

            If Salida = Exporta.PDF Then
                .Title = "Exportar a PDF"
                .Filter = "Pdf|*.pdf"
                .DefaultExt = "pdf"
            Else
                .Title = "Exportar a Excel"
                .Filter = "Excel|*.xlsx"
                .DefaultExt = "xlsx"
            End If

            .FileName = Me.Reporte.Nombre
            If Not .ShowDialog(Me) = Windows.Forms.DialogResult.Cancel Then

                If .FileName <> "" Then
                    If Salida = Exporta.PDF Then
                        rdlViewer.SaveAs(.FileName, fyiReporting.RDL.OutputPresentationType.PDF)
                    Else
                        rdlViewer.SaveAs(.FileName, fyiReporting.RDL.OutputPresentationType.Excel)
                    End If
                End If

            End If
        End With


    End Sub

    Private Sub Imprimir()


        Dim pd As New Printing.PrintDocument()
        pd.DocumentName = rdlViewer.ReportName
        pd.PrinterSettings.FromPage = 1
        pd.PrinterSettings.ToPage = rdlViewer.PageCount
        pd.PrinterSettings.MaximumPage = rdlViewer.PageCount
        pd.PrinterSettings.MinimumPage = 1

        If (rdlViewer.PageWidth > rdlViewer.PageHeight) Then
            pd.DefaultPageSettings.Landscape = True
        Else
            pd.DefaultPageSettings.Landscape = False
        End If

        Dim dlg As New PrintDialog()
        dlg.Document = pd
        dlg.AllowSelection = True
        dlg.AllowSomePages = True
        If (dlg.ShowDialog() = DialogResult.OK) Then
            Try
                If (pd.PrinterSettings.PrintRange = Printing.PrintRange.Selection) Then
                    pd.PrinterSettings.FromPage = rdlViewer.PageCurrent
                End If

                rdlViewer.Print(pd)

            Catch ex As Exception
                MessageBox.Show("Print error: " + ex.Message)
            End Try

        End If



    End Sub

    Private Sub NavegarReporte(ByVal Direccion As NavReporte)



        With rdlViewer
            If .PageCount = 1 Then Exit Sub
            

            Select Case Direccion
                Case NavReporte.PagPri : _currentPage = 1
                Case NavReporte.PagSig

                    If _currentPage < .PageCount Then
                        _currentPage += 1
                    Else
                        _currentPage = .PageCount
                    End If

                Case NavReporte.PagAnt

                    If _currentPage > 1 Then
                        _currentPage -= 1
                    Else
                        _currentPage = 1
                    End If

                Case NavReporte.PagUlt : _currentPage = .PageCount
            End Select

            .PageCurrent = _currentPage


        End With
    End Sub

#End Region

    

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Call Imprimir()
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Call NavegarReporte(NavReporte.PagAnt)
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Call NavegarReporte(NavReporte.PagSig)
    End Sub

    Private Sub ExportarAPDFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAPDFToolStripMenuItem.Click
        Call Exportar(Exporta.PDF)
    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        Call Exportar(Exporta.Excel)
    End Sub

    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        Call NavegarReporte(NavReporte.PagPri)
    End Sub

    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        Call NavegarReporte(NavReporte.PagUlt)
    End Sub

    Private Sub Buscar()
        Me.rdlViewer.ShowFindPanel = True
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Call Buscar()
    End Sub

   
    Private Sub btnPdf_Click(sender As System.Object, e As System.EventArgs) Handles btnPdf.Click
        Call Exportar(Exporta.PDF)
    End Sub

    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        Call Exportar(Exporta.Excel)
    End Sub
End Class
