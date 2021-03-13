Imports Entidades
Imports System.Text
Imports CapaDatos
Public Class BancoCLog

    Private _BancoCDat As New BancoCDat
    Public ReadOnly mensajes As New StringBuilder()
    Public Sub Save(ByVal obj As Banco)
        Try
            If (IsValid(obj)) Then
                If (_BancoCDat.GetById(obj.Id) Is Nothing) Then
                    obj.Id = _BancoCDat.Insert(obj)
                Else
                    _BancoCDat.Update(obj)
                End If
            End If
        Catch ex As Exception
            mensajes.Append(ex.Message)
        End Try
    End Sub
    Public Function GetAll() As List(Of Banco)
        Return _BancoCDat.GetAll()
    End Function
    Public Function GetById(ByVal id As UInt32) As Banco
        mensajes.Clear()
        If (id = 0) Then
            mensajes.Append("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            Return _BancoCDat.GetById(id)
        Else
            Return Nothing
        End If
    End Function
    Public Sub Delete(ByVal id As UInt32)
        mensajes.Clear()
        If (id = 0) Then
            mensajes.Append("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            _BancoCDat.Delete(id)
        End If
    End Sub
    Private Function IsValid(ByVal obj As Banco) As Boolean
        mensajes.Clear()

        If Not IsNumeric(obj.Codigo) Then
            mensajes.AppendLine("Ingrese un Código Numérico válido")
        End If

        If Val(obj.Codigo) = 0 Then
            mensajes.AppendLine("Ingrese un Código válido")
        End If

        If (obj.Nombre.Length = 0) Then
            mensajes.AppendLine("Ingrese un Detalle válido")
        End If

        If Not (mensajes.Length = 0) Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function HasError() As Boolean
        Return Not (mensajes.Length = 0)
    End Function
End Class

