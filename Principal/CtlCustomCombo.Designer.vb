<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtlCustomCombo
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.TblLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.ComboBoxDetalle = New System.Windows.Forms.ComboBox()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        Me.TblLayout.SuspendLayout()
        Me.SuspendLayout()
        '
        'TblLayout
        '
        Me.TblLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TblLayout.ColumnCount = 3
        Me.TblLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TblLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TblLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TblLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TblLayout.Controls.Add(Me.ComboBoxDetalle, 0, 0)
        Me.TblLayout.Controls.Add(Me.BtnBuscar, 1, 0)
        Me.TblLayout.Controls.Add(Me.BtnNuevo, 2, 0)
        Me.TblLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TblLayout.Location = New System.Drawing.Point(0, 0)
        Me.TblLayout.Margin = New System.Windows.Forms.Padding(0)
        Me.TblLayout.Name = "TblLayout"
        Me.TblLayout.RowCount = 1
        Me.TblLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TblLayout.Size = New System.Drawing.Size(300, 25)
        Me.TblLayout.TabIndex = 0
        '
        'ComboBoxDetalle
        '
        Me.ComboBoxDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxDetalle.FormattingEnabled = True
        Me.ComboBoxDetalle.ItemHeight = 13
        Me.ComboBoxDetalle.Location = New System.Drawing.Point(2, 2)
        Me.ComboBoxDetalle.Margin = New System.Windows.Forms.Padding(1, 1, 3, 0)
        Me.ComboBoxDetalle.Name = "ComboBoxDetalle"
        Me.ComboBoxDetalle.Size = New System.Drawing.Size(222, 21)
        Me.ComboBoxDetalle.TabIndex = 1
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBuscar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnBuscar.FlatAppearance.BorderSize = 0
        Me.BtnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBuscar.Image = Global.Principal.My.Resources.Resources.find
        Me.BtnBuscar.Location = New System.Drawing.Point(228, 1)
        Me.BtnBuscar.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(35, 23)
        Me.BtnBuscar.TabIndex = 2
        Me.BtnBuscar.TabStop = False
        Me.BtnBuscar.UseVisualStyleBackColor = True
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNuevo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnNuevo.FlatAppearance.BorderSize = 0
        Me.BtnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNuevo.Image = Global.Principal.My.Resources.Resources.table_add
        Me.BtnNuevo.Location = New System.Drawing.Point(264, 1)
        Me.BtnNuevo.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(35, 23)
        Me.BtnNuevo.TabIndex = 3
        Me.BtnNuevo.TabStop = False
        Me.BtnNuevo.UseVisualStyleBackColor = True
        '
        'CtlCustomCombo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TblLayout)
        Me.DoubleBuffered = True
        Me.MaximumSize = New System.Drawing.Size(500, 25)
        Me.MinimumSize = New System.Drawing.Size(200, 25)
        Me.Name = "CtlCustomCombo"
        Me.Size = New System.Drawing.Size(300, 25)
        Me.TblLayout.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TblLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ComboBoxDetalle As System.Windows.Forms.ComboBox
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button

End Class
