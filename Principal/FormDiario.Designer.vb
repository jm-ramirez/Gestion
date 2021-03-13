<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDiario
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ToolStripMenu = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ComboBoxCuentas = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ComboBoxFecha = New System.Windows.Forms.ToolStripComboBox()
        Me.ComboBoxCbte = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnConsultar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnBuscar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnSalir = New System.Windows.Forms.ToolStripButton()
        Me.ReportViewer = New GeneradorReportes.Viewer()
        Me.ToolStripMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ComboBoxCuentas, Me.ToolStripLabel2, Me.ComboBoxFecha, Me.ComboBoxCbte, Me.ToolStripSeparator4, Me.BtnConsultar, Me.ToolStripSeparator2, Me.BtnBuscar, Me.ToolStripSeparator1, Me.BtnImprimir, Me.ToolStripSeparator3, Me.BtnSalir})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(932, 25)
        Me.ToolStripMenu.TabIndex = 0
        Me.ToolStripMenu.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(46, 22)
        Me.ToolStripLabel1.Text = "Cuenta:"
        '
        'ComboBoxCuentas
        '
        Me.ComboBoxCuentas.Name = "ComboBoxCuentas"
        Me.ComboBoxCuentas.Size = New System.Drawing.Size(121, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(40, 22)
        Me.ToolStripLabel2.Text = "Fecha:"
        '
        'ComboBoxFecha
        '
        Me.ComboBoxFecha.Name = "ComboBoxFecha"
        Me.ComboBoxFecha.Size = New System.Drawing.Size(121, 25)
        '
        'ComboBoxCbte
        '
        Me.ComboBoxCbte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxCbte.Items.AddRange(New Object() {"TODOS LOS COMPROBANTES", "FACTURAS", "NOTAS DE PEDIDO"})
        Me.ComboBoxCbte.Name = "ComboBoxCbte"
        Me.ComboBoxCbte.Size = New System.Drawing.Size(121, 25)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'BtnConsultar
        '
        Me.BtnConsultar.Image = Global.Principal.My.Resources.Resources.report_magnify
        Me.BtnConsultar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Size = New System.Drawing.Size(109, 22)
        Me.BtnConsultar.Text = "Ver movim. [F12]"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Image = Global.Principal.My.Resources.Resources.find
        Me.BtnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(82, 22)
        Me.BtnBuscar.Text = "Buscar [F3]"
        Me.BtnBuscar.ToolTipText = "Buscar [F3]"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BtnImprimir
        '
        Me.BtnImprimir.Image = Global.Principal.My.Resources.Resources.printer
        Me.BtnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(88, 22)
        Me.BtnImprimir.Text = "Imprimir [F5]"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'BtnSalir
        '
        Me.BtnSalir.Image = Global.Principal.My.Resources.Resources.door_out
        Me.BtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(74, 22)
        Me.BtnSalir.Text = "Salir [Esc]"
        '
        'ReportViewer
        '
        Me.ReportViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.ReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer.dSubReportGetContent = Nothing
        Me.ReportViewer.Folder = Nothing
        Me.ReportViewer.HighlightAll = False
        Me.ReportViewer.HighlightAllColor = System.Drawing.Color.Fuchsia
        Me.ReportViewer.HighlightCaseSensitive = False
        Me.ReportViewer.HighlightItemColor = System.Drawing.Color.Aqua
        Me.ReportViewer.HighlightPageItem = Nothing
        Me.ReportViewer.HighlightText = Nothing
        Me.ReportViewer.Location = New System.Drawing.Point(0, 25)
        Me.ReportViewer.Name = "ReportViewer"
        Me.ReportViewer.PageCurrent = 1
        Me.ReportViewer.Parameters = ""
        Me.ReportViewer.ReportName = Nothing
        Me.ReportViewer.ScrollMode = fyiReporting.RdlViewer.ScrollModeEnum.Continuous
        Me.ReportViewer.SelectTool = False
        Me.ReportViewer.ShowFindPanel = False
        Me.ReportViewer.ShowParameterPanel = False
        Me.ReportViewer.ShowWaitDialog = False
        Me.ReportViewer.Size = New System.Drawing.Size(932, 430)
        Me.ReportViewer.SourceFile = Nothing
        Me.ReportViewer.SourceRdl = Nothing
        Me.ReportViewer.TabIndex = 1
        Me.ReportViewer.UseTrueMargins = True
        Me.ReportViewer.Zoom = 0.8!
        Me.ReportViewer.ZoomMode = fyiReporting.RdlViewer.ZoomEnum.UseZoom
        '
        'FormDiario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(932, 455)
        Me.Controls.Add(Me.ReportViewer)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormDiario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormArticulo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ComboBoxFecha As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ComboBoxCuentas As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ReportViewer As GeneradorReportes.Viewer
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ComboBoxCbte As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
End Class
