Imports System.Windows.Forms

Public Class FormInputDialog

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Function ShowInput(ByVal mensaje As String) As String
        Dim dialog As New FormInputDialog
        dialog.LabelInput.Text = mensaje
        dialog.ShowDialog()

        Return dialog.TextBoxInput.Text.Trim
    End Function

End Class
