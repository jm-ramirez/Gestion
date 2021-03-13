Public Class ObjectDisposeClass
    Implements IDisposable
    Private disposedValue As Boolean = False
    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub
End Class
