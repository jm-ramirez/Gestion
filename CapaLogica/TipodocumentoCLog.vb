Imports Entidades
Imports System.Text
Imports CapaDatos
Public Class TipodocumentoCLog

    Private _TipodocumentoCDat As New TipodocumentoCDat
    Public ReadOnly mensajes As New StringBuilder()
    Public Sub Save(ByRef obj As Tipodocumento)
        Try
            If (IsValid(obj)) Then
                If (_TipodocumentoCDat.GetById(obj.Id) Is Nothing) Then
                    _TipodocumentoCDat.Insert(obj)
                Else
                    _TipodocumentoCDat.Update(obj)
                End If
            End If
        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
        End Try
    End Sub
    Public Function GetAll() As List(Of Tipodocumento)
        Return _TipodocumentoCDat.GetAll()
    End Function
    Public Function GetById(ByVal id As UInt32) As Tipodocumento
        mensajes.Clear()
        If (id = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            Return _TipodocumentoCDat.GetById(id)
        Else
            Return Nothing
        End If
    End Function
    Public Function GetByCodigo(ByVal codigo As UInt32) As Tipodocumento
        mensajes.Clear()
        If (codigo = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Código válido")
        End If
        If (mensajes.Length = 0) Then
            Return _TipodocumentoCDat.GetByCodigo(codigo)
        Else
            Return Nothing
        End If
    End Function
    Public Sub Delete(ByVal id As UInt32)
        mensajes.Clear()
        If (id = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            _TipodocumentoCDat.Delete(id)
        End If
    End Sub
    Private Function IsValid(ByVal obj As Tipodocumento) As Boolean
        mensajes.Clear()
        'implementar validaciones
        Return (mensajes.Length = 0)
    End Function
    Public Function HasError() As Boolean
        Return Not (mensajes.Length = 0)
    End Function
End Class

