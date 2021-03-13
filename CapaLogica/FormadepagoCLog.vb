Imports Entidades
Imports System.Text
Imports CapaDatos
Public Class FormadepagoCLog
    Private _FormadepagoCDat As New FormadepagoCDat
    Public ReadOnly mensajes As New StringBuilder()
    Public Sub Save(ByRef obj As Formadepago)
        Try
            If (IsValid(obj)) Then
                If (_FormadepagoCDat.GetById(obj.Id) Is Nothing) Then
                    obj.Id = _FormadepagoCDat.Insert(obj)
                Else
                    _FormadepagoCDat.Update(obj)
                End If
            End If
        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
        End Try
    End Sub
    Public Function GetAll() As List(Of Formadepago)
        Return _FormadepagoCDat.GetAll()
    End Function
    Public Function GetById(ByVal id As UInt32) As Formadepago
        mensajes.Clear()
        If (id = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            Return _FormadepagoCDat.GetById(id)
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
            _FormadepagoCDat.Delete(id)
        End If
    End Sub
    Private Function IsValid(ByVal obj As Formadepago) As Boolean
        mensajes.Clear()

        If (obj.Nombre.Length = 0) Then
            mensajes.AppendLine("Ingrese un Detalle válido")
        End If

        If Not IsNumeric(obj.Dias1) Then
            mensajes.AppendLine("Ingrese un Día 1 válido")
        End If

        If Not IsNumeric(obj.Paga1) Then
            mensajes.AppendLine("Ingrese un % de Pago 1 válido")
        End If

        If Not IsNumeric(obj.Dias2) Then
            mensajes.AppendLine("Ingrese un Día 2 válido")
        End If

        If Not IsNumeric(obj.Paga2) Then
            mensajes.AppendLine("Ingrese un % de Pago 2 válido")
        End If

        If Not IsNumeric(obj.Dias3) Then
            mensajes.AppendLine("Ingrese un Día 3 válido")
        End If

        If Not IsNumeric(obj.Paga3) Then
            mensajes.AppendLine("Ingrese un % de Pago 3 válido")
        End If

        If Not IsNumeric(obj.Dias4) Then
            mensajes.AppendLine("Ingrese un Día 4 válido")
        End If

        If Not IsNumeric(obj.Paga4) Then
            mensajes.AppendLine("Ingrese un % de Pago 4 válido")
        End If

        If Not IsNumeric(obj.Dias5) Then
            mensajes.AppendLine("Ingrese un Día 5 válido")
        End If

        If Not IsNumeric(obj.Paga5) Then
            mensajes.AppendLine("Ingrese un % de Pago 5 válido")
        End If

        If Not IsNumeric(obj.Dias6) Then
            mensajes.AppendLine("Ingrese un Día 6 válido")
        End If

        If Not IsNumeric(obj.Paga6) Then
            mensajes.AppendLine("Ingrese un % de Pago 6 válido")
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

