Imports Entidades
Imports System.Text
Imports CapaDatos
Public Class CbtenumeracionCLog

    Private _CbtenumeracionCDat As New CbtenumeracionCDat
    Public ReadOnly mensajes As New StringBuilder()
    Public Sub Save(ByRef obj As Cbtenumeracion)
        Try
            If (IsValid(obj)) Then
                If (_CbtenumeracionCDat.GetById(obj.Id) Is Nothing) Then
                    obj.Id = _CbtenumeracionCDat.Insert(obj)
                Else
                    _CbtenumeracionCDat.Update(obj)
                End If
            End If
        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
        End Try
    End Sub

    Public Sub SaveAll(ByRef objList As List(Of Cbtenumeracion))
        Try

            _CbtenumeracionCDat.SaveAll(objList)

        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
        End Try
    End Sub

    Public Function GetAll() As List(Of Cbtenumeracion)
        Return _CbtenumeracionCDat.GetAll()
    End Function

    Public Function GetAll2() As List(Of Cbtenumeracion)
        Return _CbtenumeracionCDat.GetAll2()
    End Function

    Public Function GetById(ByVal id As UInt32) As Cbtenumeracion
        mensajes.Clear()
        If (id = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            Return _CbtenumeracionCDat.GetById(id)
        Else
            Return Nothing
        End If
    End Function

    Public Function GetByUltimoNroCbte(ByVal ptovta As UInt32, ByVal cbtetipo As UInt32) As Cbtenumeracion
        mensajes.Clear()

        Return _CbtenumeracionCDat.GetByUltimoNroCbte(ptovta, cbtetipo)

    End Function


    Public Sub Delete(ByVal id As UInt32)
        mensajes.Clear()
        If (id = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            _CbtenumeracionCDat.Delete(id)
        End If
    End Sub

    Private Function IsValid(ByVal obj As Cbtenumeracion) As Boolean
        mensajes.Clear()
        'implementar validaciones
        Return (mensajes.Length = 0)
    End Function

    Public Function HasError() As Boolean
        Return Not (mensajes.Length = 0)
    End Function
End Class

