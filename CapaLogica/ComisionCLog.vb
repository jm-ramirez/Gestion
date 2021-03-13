Imports Entidades
Imports System.Text
Imports CapaDatos
Public Class ComisionCLog

    Private _ComisionCDat As New ComisionCDat
    Public ReadOnly mensajes As New StringBuilder()
    Public Sub Save(ByRef obj As Comision)
        Try
            If (IsValid(obj)) Then
                If (_ComisionCDat.GetById(obj.Id) Is Nothing) Then
                    obj.Id = _ComisionCDat.Insert(obj)
                Else
                    _ComisionCDat.Update(obj)
                End If
            End If
        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
        End Try
    End Sub

    Public Sub SaveAll(ByRef objList As List(Of Comision))
        Try
            
            _ComisionCDat.SaveAll(objList)
            
        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
        End Try
    End Sub

    Public Function GetAll(ByVal vendedor As UInt32) As List(Of Comision)
        mensajes.Clear()

        If (vendedor = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Vendedor válido")
        End If

        If (mensajes.Length = 0) Then
            Return _ComisionCDat.GetAll(vendedor)
        Else
            Return Nothing
        End If

    End Function
    Public Function GetById(ByVal id As UInt32) As Comision
        mensajes.Clear()
        If (id = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            Return _ComisionCDat.GetById(id)
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
            _ComisionCDat.Delete(id)
        End If
    End Sub
    Private Function IsValid(ByVal obj As Comision) As Boolean
        mensajes.Clear()
        'implementar validaciones
        Return (mensajes.Length = 0)
    End Function
    Public Function HasError() As Boolean
        Return Not (mensajes.Length = 0)
    End Function
End Class

