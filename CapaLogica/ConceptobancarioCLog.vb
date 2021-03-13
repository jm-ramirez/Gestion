Imports Entidades
Imports System.Text
Imports CapaDatos
Public Class ConceptobancarioCLog

    Private _ConceptobancarioCDat As New ConceptobancarioCDat
    Public ReadOnly mensajes As New StringBuilder()
    Public Sub Save(ByRef obj As Conceptobancario)
        Try
            If (IsValid(obj)) Then
                If (_ConceptobancarioCDat.GetById(obj.Id) Is Nothing) Then
                    obj.Id = _ConceptobancarioCDat.Insert(obj)
                Else
                    _ConceptobancarioCDat.Update(obj)
                End If
            End If
        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
        End Try
    End Sub

    Public Function GetAll() As List(Of Conceptobancario)
        Return _ConceptobancarioCDat.GetAll()
    End Function

    Public Function GetConceptosDeudores() As List(Of Conceptobancario)
        Return _ConceptobancarioCDat.GetConceptosDeudores()
    End Function

    Public Function GetConceptosAcreedores() As List(Of Conceptobancario)
        Return _ConceptobancarioCDat.GetConceptosAcreedores()
    End Function

    Public Function GetById(ByVal id As UInt32) As Conceptobancario
        mensajes.Clear()
        If (id = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            Return _ConceptobancarioCDat.GetById(id)
        Else
            Return Nothing
        End If
    End Function

    Public Function GetByCodigo(ByVal codigo As String) As Conceptobancario
        mensajes.Clear()
        If (codigo.Length = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Código válido")
        End If
        If (mensajes.Length = 0) Then
            Return _ConceptobancarioCDat.GetByCodigo(codigo)
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
            _ConceptobancarioCDat.Delete(id)
        End If
    End Sub
    Private Function IsValid(ByVal obj As Conceptobancario) As Boolean

        mensajes.Clear()

        If (obj.Codigo.Length = 0) Then
            mensajes.AppendLine("Ingrese un Código válido")
        End If

        If (obj.Nombre.Length = 0) Then
            mensajes.AppendLine("Ingrese un Detalle válido")
        End If

        If obj.Tipo <> "D" And obj.Tipo <> "C" Then
            mensajes.AppendLine("Ingrese un Tipo de Concepto válido")
        End If

        If Not IsNumeric(obj.Plazo) Then
            mensajes.AppendLine("Ingrese un Plazo válido")
        End If

        If Not IsNumeric(obj.Alicuota) Then
            mensajes.AppendLine("Ingrese una Alícuota válida")
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

