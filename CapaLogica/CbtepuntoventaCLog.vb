Imports Entidades
Imports System.Text
Imports CapaDatos
Public Class CbtepuntoventaCLog
    Private _CbtepuntoventaCDat As New CbtepuntoventaCDat
    Public ReadOnly mensajes As New StringBuilder()
    Public Sub Save(ByRef obj As Cbtepuntoventa)
        Try
            If (IsValid(obj)) Then
                If (_CbtepuntoventaCDat.GetById(obj.Id) Is Nothing) Then
                    obj.Id = _CbtepuntoventaCDat.Insert(obj)
                Else
                    _CbtepuntoventaCDat.Update(obj)
                End If
            End If
        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
        End Try
    End Sub
    Public Function GetAll() As List(Of Cbtepuntoventa)
        Return _CbtepuntoventaCDat.GetAll()
    End Function

    Public Function GetPtosManuales() As List(Of Cbtepuntoventa)
        Return _CbtepuntoventaCDat.GetPtosManuales
    End Function

    Public Function GetPtosElectronicos() As List(Of Cbtepuntoventa)
        Return _CbtepuntoventaCDat.GetPtosElectronicos
    End Function

    Public Function GetPtosFiscales() As List(Of Cbtepuntoventa)
        Return _CbtepuntoventaCDat.GetPtosFiscales
    End Function

    Public Function GetPtosPresupuestos() As List(Of Cbtepuntoventa)
        Return _CbtepuntoventaCDat.GetPtosPresupuestos
    End Function

    Public Function GetPtosNoFiscales() As List(Of Cbtepuntoventa)
        Return _CbtepuntoventaCDat.GetPtosNoFiscales
    End Function

    Public Function GetById(ByVal id As UInt32) As Cbtepuntoventa
        mensajes.Clear()
        If (id = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            Return _CbtepuntoventaCDat.GetById(id)
        Else
            Return Nothing
        End If
    End Function

    Public Function GetByPtoVta(ByVal ptovta As UInt32) As Cbtepuntoventa
        mensajes.Clear()
        If (ptovta = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Punto de Vta. válido")
        End If
        If (mensajes.Length = 0) Then
            Return _CbtepuntoventaCDat.GetByPtoVta(ptovta)
        Else
            Return Nothing
        End If
    End Function

    Public Function GetByTipo(ByVal tipo As String) As Cbtepuntoventa
        mensajes.Clear()
        If (tipo = "") Then
            mensajes.AppendLine("Por favor proporcione un valor de Punto de Vta. válido")
        End If
        If (mensajes.Length = 0) Then
            Return _CbtepuntoventaCDat.GetByTipo(tipo)
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
            _CbtepuntoventaCDat.Delete(id)
        End If
    End Sub
    Private Function IsValid(ByVal obj As Cbtepuntoventa) As Boolean
        mensajes.Clear()
        'implementar validaciones
        Return (mensajes.Length = 0)
    End Function
    Public Function HasError() As Boolean
        Return Not (mensajes.Length = 0)
    End Function
End Class

