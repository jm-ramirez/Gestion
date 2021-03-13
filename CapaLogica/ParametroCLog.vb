Imports Entidades
Imports System.Text
Imports CapaDatos
Public Class ParametroCLog
    Private _ParametroCDat As New ParametroCDat
    Public ReadOnly mensajes As New StringBuilder()
    Public Sub Save(ByRef obj As Parametro)
        Try
            If (IsValid(obj)) Then
                If (_ParametroCDat.GetById(obj.Id) Is Nothing) Then
                    obj.Id = _ParametroCDat.Insert(obj)
                Else
                    _ParametroCDat.Update(obj)
                End If
            End If
        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
        End Try
    End Sub
    Public Function GetAll() As List(Of Parametro)
        Return _ParametroCDat.GetAll()
    End Function
    Public Function GetById(ByVal id As UInt32) As Parametro
        mensajes.Clear()
        If (id = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            Return _ParametroCDat.GetById(id)
        Else
            Return Nothing
        End If
    End Function

    Public Function GetByNombre(ByVal nombre As String) As Parametro
        mensajes.Clear()
        If (nombre.Length = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Nombre válido")
        End If
        If (mensajes.Length = 0) Then
            Return _ParametroCDat.GetByNombre(nombre)
        Else
            Return Nothing
        End If
    End Function

    'MinimoRetIva
    Public Function GetMinimoRetIva() As Double
        mensajes.Clear()
        If (mensajes.Length = 0) Then
            Return _ParametroCDat.GetMinimoRetIva
        Else
            Return 0.0
        End If
    End Function

    'MinimoNoSujetoIIBB
    Public Function GetMinimoNoSujetoIIBB() As Double
        mensajes.Clear()
        If (mensajes.Length = 0) Then
            Return _ParametroCDat.GetMinimoNoSujetoIIBB
        Else
            Return 0.0
        End If
    End Function

    Public Function GetNroCbteRetIva() As UInteger
        mensajes.Clear()
        If (mensajes.Length = 0) Then
            Return _ParametroCDat.GetNroCbteRetIva
        Else
            Return 0
        End If
    End Function

    Public Function GetNroCbteRetIB() As UInteger
        mensajes.Clear()
        If (mensajes.Length = 0) Then
            Return _ParametroCDat.GetNroCbteRetIB
        Else
            Return 0
        End If
    End Function

    Public Function GetNroCbteRetGcia() As UInteger
        mensajes.Clear()
        If (mensajes.Length = 0) Then
            Return _ParametroCDat.GetNroCbteRetGcia
        Else
            Return 0
        End If
    End Function

    Public Sub Delete(ByVal id As UInt32)
        mensajes.Clear()
        If (id = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            _ParametroCDat.Delete(id)
        End If
    End Sub
    Private Function IsValid(ByVal obj As Parametro) As Boolean
        mensajes.Clear()
        'implementar validaciones
        Return (mensajes.Length = 0)
    End Function
    Public Function HasError() As Boolean
        Return Not (mensajes.Length = 0)
    End Function
End Class

