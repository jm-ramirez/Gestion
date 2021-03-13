Public Class NamedDescriptionDecoration
    Inherits BrightIdeasSoftware.AbstractDecoration

    Property ImageList As ImageList
    Property ImageName As String
    Property Title As String
    Property Description As String

    Property TitleFont As Font = New Font("Microsoft Sans Serif", 9, FontStyle.Bold)
    Property TitleColor As Color = Color.FromArgb(255, 32, 32, 32)
    Property DescripionFont As Font = New Font("Microsoft Sans Serif", 8.25)
    Property DescriptionColor As Color = Color.FromArgb(255, 32, 32, 32)
    Property CellPadding As Size = New Size(1, 1)

    Public Overrides Sub Draw(ByVal olv As BrightIdeasSoftware.ObjectListView, ByVal g As Graphics, ByVal r As Rectangle)
        Dim cellBounds As Rectangle = Me.CellBounds
        cellBounds.Inflate(-Me.CellPadding.Width, -Me.CellPadding.Height)
        Dim textBounds As Rectangle = cellBounds

        If Me.ImageList IsNot Nothing AndAlso Me.ImageName.Trim.Length = 0 Then
            g.DrawImage(Me.ImageList.Images(Me.ImageName), cellBounds.Location)
            textBounds.X += Me.ImageList.ImageSize.Width
            textBounds.Width -= Me.ImageList.ImageSize.Width
        End If

        '//g.DrawRectangle(Pens.Red, textBounds);

        '// Draw the title
        Dim fmt As StringFormat = New StringFormat(StringFormatFlags.NoWrap)
        fmt.Trimming = StringTrimming.EllipsisCharacter
        fmt.Alignment = StringAlignment.Near
        fmt.LineAlignment = StringAlignment.Near

        Dim b As SolidBrush

        b = New SolidBrush(Me.TitleColor)

        Using b
            g.DrawString(Me.Title, Me.TitleFont, b, textBounds, fmt)
        End Using

        '// Draw the description
        Dim size As SizeF = g.MeasureString(Me.Title, Me.TitleFont, Int(textBounds.Width), fmt)
        textBounds.Y += Int(size.Height)
        textBounds.Height -= Int(size.Height)
        Dim fmt2 As StringFormat = New StringFormat()
        fmt2.Trimming = StringTrimming.EllipsisCharacter

        b = New SolidBrush(Me.DescriptionColor)

        Using b
            g.DrawString(Me.Description, Me.DescripionFont, b, textBounds, fmt2)
        End Using

    End Sub

End Class