Imports Entidades
Imports System.Text
Imports CapaDatos
Public Class CuentabancariaCLog
    Private _CuentabancariaCDat As New CuentabancariaCDat
    Public ReadOnly mensajes As New StringBuilder()

    Public Sub Save(ByRef obj As Cuentabancaria)
        Try
            If (IsValid(obj)) Then
                If (_CuentabancariaCDat.GetById(obj.Id) Is Nothing) Then
                    obj.Id = _CuentabancariaCDat.Insert(obj)
                Else
                    _CuentabancariaCDat.Update(obj)
                End If
            End If
        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
        End Try
    End Sub

    Public Function GetCuentasDisponibles() As List(Of Cuentabancaria)
        Return _CuentabancariaCDat.GetCuentasDisponibles
    End Function

    Public Function GetAll() As List(Of Cuentabancaria)
        Return _CuentabancariaCDat.GetAll
    End Function

    Public Function GetAllWithValue(ByVal value As String) As List(Of Cuentabancaria)
        Return _CuentabancariaCDat.GetAllWithValue(value)
    End Function

    Public Function GetById(ByVal id As UInt32) As Cuentabancaria
        mensajes.Clear()
        If (id = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            Return _CuentabancariaCDat.GetById(id)
        Else
            Return Nothing
        End If
    End Function

    Public Function GetByCodigo(ByVal codigo As String) As Cuentabancaria
        mensajes.Clear()
        If (codigo.Length = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Código válido")
        End If
        If (mensajes.Length = 0) Then
            Return _CuentabancariaCDat.GetByCodigo(codigo)
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
            _CuentabancariaCDat.Delete(id)
        End If
    End Sub
    Private Function IsValid(ByVal obj As Cuentabancaria) As Boolean
        mensajes.Clear()

        If (obj.Codigo.Length = 0) Then
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

