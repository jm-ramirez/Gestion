Imports Entidades
Imports System.Text
Imports CapaDatos
Public Class FinancieroCLog
    Private _FinancieroCDat As New FinancieroCDat
    Public ReadOnly mensajes As New StringBuilder()
    Public Sub Save(ByRef obj As Financiero)
        Try
            If (IsValid(obj)) Then
                If (_FinancieroCDat.GetById(obj.Id) Is Nothing) Then
                    obj.Id = _FinancieroCDat.Insert(obj)
                Else
                    _FinancieroCDat.Update(obj)
                End If
            End If
        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
        End Try
    End Sub

    Public Function DepositoCartera(ByVal origen As List(Of Financiero), ByVal destino As Entidades.Financiero) As UInt32
        Try

            Return _FinancieroCDat.DepositoCartera(origen, destino)

        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
            Return 0
        End Try
    End Function
    Public Sub Rechazar(ByRef Id As Integer, ByVal Tipo As String)
        Try
            ' If (IsValid(obj)) Then

            _FinancieroCDat.Rechazar(Id, Tipo)

            ' End If
        Catch ex As Exception
            mensajes.Append(ex.Message)
        End Try
    End Sub
    Public Function SaveList(ByRef objList As List(Of Financiero))
        Try

            Return _FinancieroCDat.InsertList(objList)

        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
            Return 0
        End Try
    End Function

    Public Function GetAll() As List(Of Financiero)
        Return _FinancieroCDat.GetAll()
    End Function

    Public Function GetAllCheques() As List(Of Financiero)
        Return _FinancieroCDat.GetAllCheques()
    End Function

    Public Function GetSaldo(ByVal cuenta As String, ByVal fecha As Date, Optional ByVal todo As Boolean = False) As Double
        Return _FinancieroCDat.GetSaldo(cuenta, fecha, todo)
    End Function

    Public Function GetByCuenta(ByVal cuenta As String) As List(Of Financiero)
        Return _FinancieroCDat.GetByCuenta(cuenta)
    End Function

    Public Function GetMovctas(Optional ByVal pstrWhere As String = "0=0") As List(Of Financiero)
        Return _FinancieroCDat.GetMovctas(pstrWhere)
    End Function

    Public Function GetById(ByVal id As UInt32) As Financiero
        mensajes.Clear()
        If (id = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            Return _FinancieroCDat.GetById(id)
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
            _FinancieroCDat.Delete(id)
        End If
    End Sub

    Public Sub AnulaMovCtas(ByVal Nro As UInt32)
        mensajes.Clear()
        If (Nro = 0) Then
            mensajes.Append("Por favor proporcione un Nº de Movimiento entre Cuentas válido")
        End If
        If (mensajes.Length = 0) Then
            _FinancieroCDat.AnulaMovCtas(Nro)
        End If
    End Sub

    Private Function IsValid(ByVal obj As Financiero) As Boolean
        mensajes.Clear()
        'implementar validaciones

        If (obj.Cuenta.Length = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Cuenta válido")
        End If

        If (obj.Concepto.Length = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Concepto válido")
        End If

        If (obj.Importe <= 0) Then
            mensajes.AppendLine("Por favor proporcione un Importe válido")
        End If


        Return (mensajes.Length = 0)
    End Function
    Public Function HasError() As Boolean
        Return Not (mensajes.Length = 0)
    End Function

    Public Sub AnulaDepositoCartera(ByVal origen As List(Of Financiero), ByVal destino As Entidades.Financiero)
        Try

            _FinancieroCDat.AnulaDepositoCartera(origen, destino)

        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
        End Try
    End Sub


    Public Function GetNroDepositos() As List(Of UInteger)
        Return _FinancieroCDat.GetNroDepositos()
    End Function

    Public Function GetChequesDeposito(ByVal cuenta As String, ByVal concepto As String, ByVal deposito As Int32) As List(Of Financiero)
        Return _FinancieroCDat.GetChequesDeposito(cuenta, concepto, deposito)
    End Function

    Public Function GetDeposito(ByVal deposito As Int32) As List(Of Financiero)
        Return _FinancieroCDat.GetDeposito(deposito)
    End Function

End Class

