Imports Entidades
Imports System.Text
Imports CapaDatos
Public Class TipotributoCLog

    Private _TipotributoCDat As New TipotributoCDat
    Public ReadOnly mensajes As New StringBuilder()
    Public Sub Save(ByRef obj As Tipotributo)
        Try
            If (IsValid(obj)) Then
                If (_TipotributoCDat.GetById(obj.Id) Is Nothing) Then
                    _TipotributoCDat.Insert(obj)
                Else
                    _TipotributoCDat.Update(obj)
                End If
            End If
        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
        End Try
    End Sub
    Public Function GetAll() As List(Of Tipotributo)
        Return _TipotributoCDat.GetAll()
    End Function
    Public Function GetById(ByVal id As UInt32) As Tipotributo
        mensajes.Clear()
        If (id = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            Return _TipotributoCDat.GetById(id)
        Else
            Return Nothing
        End If
    End Function
    Public Function GetByCodigo(ByVal codigo As UInt32) As Tipotributo
        mensajes.Clear()
        If (codigo = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Código válido")
        End If
        If (mensajes.Length = 0) Then
            Return _TipotributoCDat.GetByCodigo(codigo)
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
            _TipotributoCDat.Delete(id)
        End If
    End Sub
    Private Function IsValid(ByVal obj As Tipotributo) As Boolean
        mensajes.Clear()
        'implementar validaciones
        Return (mensajes.Length = 0)
    End Function
    Public Function HasError() As Boolean
        Return Not (mensajes.Length = 0)
    End Function
End Class

