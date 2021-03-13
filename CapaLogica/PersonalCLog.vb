Imports Entidades
Imports System.Text
Imports CapaDatos
Public Class PersonalCLog
    Private _PersonalCDat As New PersonalCDat
    Public ReadOnly mensajes As New StringBuilder()
    Public Sub Save(ByRef obj As Personal)
        Try
            If (IsValid(obj)) Then
                If (_PersonalCDat.GetById(obj.Id) Is Nothing) Then
                    obj.Id = _PersonalCDat.Insert(obj)
                Else
                    _PersonalCDat.Update(obj)
                End If
            End If
        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
        End Try
    End Sub
    Public Function GetAll() As List(Of Personal)
        Return _PersonalCDat.GetAll()
    End Function
    Public Function GetById(ByVal id As UInt32) As Personal
        mensajes.Clear()
        If (id = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            Return _PersonalCDat.GetById(id)
        Else
            Return Nothing
        End If
    End Function

    Public Function DoLogin(ByVal login As String, ByVal password As String) As Personal

        mensajes.Clear()

        If (login.Length = 0) Then
            mensajes.AppendLine("Por favor proporcione un nombre de usuario válido")
        End If

        If (password.Length = 0) Then
            mensajes.AppendLine("Por favor proporcione una contraseña válida")
        End If

        If (mensajes.Length = 0) Then
            Return _PersonalCDat.DoLogin(login, password)
        Else
            Return Nothing
        End If

    End Function

    Public Function GodMode(ByVal password As String) As Boolean

        mensajes.Clear()

        If (password.Length = 0) Then
            mensajes.AppendLine("Por favor proporcione una contraseña válida")
        End If

        If (mensajes.Length = 0) Then
            Return _PersonalCDat.GodMode(password)
        Else
            Return False
        End If

    End Function

    Public Sub Delete(ByVal id As UInt32)
        mensajes.Clear()
        If (id = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            _PersonalCDat.Delete(id)
        End If
    End Sub
    Private Function IsValid(ByVal obj As Personal) As Boolean

        If (obj.Nombre.Length = 0) Then
            mensajes.AppendLine("Por favor proporcione un Nombre válido")
        End If

        If (obj.Login.Length = 0) Then
            mensajes.AppendLine("Por favor proporcione un Login válido")
        End If

        If (obj.Password.Length = 0) Then
            mensajes.AppendLine("Por favor proporcione una Contraseña válida")
        End If

        mensajes.Clear()
        'implementar validaciones
        Return (mensajes.Length = 0)
    End Function

    Public Function HasError() As Boolean
        Return Not (mensajes.Length = 0)
    End Function
End Class

