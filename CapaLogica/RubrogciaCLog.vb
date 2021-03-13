Imports Entidades
Imports System.Text
Imports CapaDatos
Public Class RubrogciaCLog
    Private _RubrogciaCDat As New RubrogciaCDat
    Public ReadOnly mensajes As New StringBuilder()
    Public Sub Save(ByRef obj As Rubrogcia)
        Try
            If (IsValid(obj)) Then
                If (_RubrogciaCDat.GetById(obj.Id) Is Nothing) Then
                    obj.Id = _RubrogciaCDat.Insert(obj)
                Else
                    _RubrogciaCDat.Update(obj)
                End If
            End If
        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
        End Try
    End Sub
    Public Function GetAll() As List(Of Rubrogcia)
        Return _RubrogciaCDat.GetAll()
    End Function
    Public Function GetById(ByVal id As UInt32) As Rubrogcia
        mensajes.Clear()
        If (id = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            Return _RubrogciaCDat.GetById(id)
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
            _RubrogciaCDat.Delete(id)
        End If
    End Sub
    Private Function IsValid(ByVal obj As Rubrogcia) As Boolean
        mensajes.Clear()

        If (obj.Nombre.Length = 0) Then
            mensajes.AppendLine("Ingrese un Detalle válido")
        End If

        If Not IsNumeric(obj.Nosujeto) Then
            mensajes.AppendLine("Ingrese un Importe No Sujeto válido")
        End If

        If Not IsNumeric(obj.Minimo) Then
            mensajes.AppendLine("Ingrese un Importe Mínimo válido")
        End If

        If Not IsNumeric(obj.Noinscripto) Then
            mensajes.AppendLine("Ingrese un Importe No Inscripto válido")
        End If

        If Not IsNumeric(obj.Tope1) Then
            mensajes.AppendLine("Ingrese un Importe Tope 1 válido")
        End If

        If Not IsNumeric(obj.Tope1alic) Then
            mensajes.AppendLine("Ingrese una Alícuota de Tope 1 válida")
        End If

        If Not IsNumeric(obj.Tope2) Then
            mensajes.AppendLine("Ingrese un Importe Tope 2 válido")
        End If

        If Not IsNumeric(obj.Tope2alic) Then
            mensajes.AppendLine("Ingrese una Alícuota de Tope 2 válida")
        End If

        If Not IsNumeric(obj.Tope3) Then
            mensajes.AppendLine("Ingrese un Importe Tope 3 válido")
        End If

        If Not IsNumeric(obj.Tope3alic) Then
            mensajes.AppendLine("Ingrese una Alícuota de Tope 3 válida")
        End If

        If Not IsNumeric(obj.Tope4) Then
            mensajes.AppendLine("Ingrese un Importe Tope 4 válido")
        End If

        If Not IsNumeric(obj.Tope4alic) Then
            mensajes.AppendLine("Ingrese una Alícuota de Tope 4 válida")
        End If

        If Not IsNumeric(obj.Tope5) Then
            mensajes.AppendLine("Ingrese un Importe Tope 5 válido")
        End If

        If Not IsNumeric(obj.Tope5alic) Then
            mensajes.AppendLine("Ingrese una Alícuota de Tope 5 válida")
        End If

        If Not IsNumeric(obj.Tope6) Then
            mensajes.AppendLine("Ingrese un Importe Tope 6 válido")
        End If

        If Not IsNumeric(obj.Tope6alic) Then
            mensajes.AppendLine("Ingrese una Alícuota de Tope 6 válida")
        End If

        If Not IsNumeric(obj.Tope7) Then
            mensajes.AppendLine("Ingrese un Importe Tope 7 válido")
        End If

        If Not IsNumeric(obj.Tope7alic) Then
            mensajes.AppendLine("Ingrese una Alícuota de Tope 7 válida")
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

