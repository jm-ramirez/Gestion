Imports Entidades
Imports System.Text
Imports CapaDatos

Public Class ClienteCLog

    Private _ClienteCDat As New ClienteCDat
    Private _repositorioCbtes As New CbtecabeceraCDat
    Public ReadOnly mensajes As New StringBuilder()

    Public Sub Save(ByRef obj As Cliente)
        Try
            If (IsValid(obj)) Then
                If (_ClienteCDat.GetById(obj.Id) Is Nothing) Then
                    obj.Id = _ClienteCDat.Insert(obj)
                Else
                    _ClienteCDat.Update(obj)
                End If
            End If
        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
        End Try
    End Sub

    Public Function GetAll() As List(Of Cliente)
        Return _ClienteCDat.GetAll()
    End Function

    Public Function GetAllOrderByNombre(Optional ByVal soloActivos As Boolean = False) As List(Of Cliente)
        Return _ClienteCDat.GetAllOrderByNombre(soloActivos:=soloActivos)
    End Function

    Public Function GetById(ByVal id As UInt32) As Cliente
        mensajes.Clear()
        If (id = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            Return _ClienteCDat.GetById(id)
        Else
            Return Nothing
        End If
    End Function

    Public Function GetByCodigo(ByVal id As String) As Cliente
        mensajes.Clear()
        If (id = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            Return _ClienteCDat.GetByCodigo(id)
        Else
            Return Nothing
        End If
    End Function

    Public Sub Delete(ByVal id As UInt32)
        mensajes.Clear()

        If (id = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Id válido")
        End If

        If _repositorioCbtes.GetAllByCliente(cliente:=id, cargaAlicuotas:=False, cargaArticulos:=False, cargaAsociados:=False, cargaCtaCte:=False, cargaFinanciero:=False, cargaTributos:=False, ordenDescendete:=False, vertodos:=True).Count > 0 Then
            mensajes.AppendLine("El cliente no puede ser eliminado. Existen comprobantes previamente cargados al cliente.")
        End If

        If (mensajes.Length = 0) Then
            _ClienteCDat.Delete(id)
        End If
    End Sub

    Private Function IsValid(ByVal obj As Cliente) As Boolean
        mensajes.Clear()

        If (obj.Codigo.Length = 0) Then
            mensajes.AppendLine("El campo Código es de ingreso obligatorio")
        End If

        If (obj.Nombre.Length = 0) Then
            mensajes.AppendLine("El campo Nombre es de ingreso obligatorio")
        End If

        If (obj.Domicilio.Length = 0) Then
            mensajes.AppendLine("El campo Domicilio es de ingreso obligatorio")
        End If

        If (obj.Telefono.Length = 0) Then
            mensajes.AppendLine("El campo Telefono es de ingreso obligatorio")
        End If

        If (obj.Provincia = 0) Then
            mensajes.AppendLine("El campo Provincia es de ingreso obligatorio")
        End If

        If (obj.Localidad = 0) Then
            mensajes.AppendLine("El campo Localidad es de ingreso obligatorio")
        End If

        If (obj.Tiporesponsable = 0) Then
            mensajes.AppendLine("El campo Tipo de Responsable es de ingreso obligatorio")
        End If

        If (obj.Tipodocumento = 0) Then
            mensajes.AppendLine("El campo Tipo de Documento es de ingreso obligatorio")
        End If

        If (obj.Vendedor = 0) Then
            mensajes.AppendLine("El campo Vendedor es de ingreso obligatorio")
        End If

        If (obj.Zona = 0) Then
            mensajes.AppendLine("El campo Zona es de ingreso obligatorio")
        End If

        If (obj.Formadepago = 0) Then
            mensajes.AppendLine("El campo Condición de Venta es de ingreso obligatorio")
        End If

        If (obj.Listadeprecio = 0) Then
            mensajes.AppendLine("El campo Lista de precio es de ingreso obligatorio")
        End If

        If Not IsNumeric(obj.Ingresosbrutosalic) Or obj.Ingresosbrutosalic < 0 Or obj.Ingresosbrutosalic > 100 Then
            mensajes.AppendLine("El campo Ret. de IIBB (%) debe estar en el rango de 0-100")
        End If

        If Not IsNumeric(obj.Diasctacte) Or obj.Diasctacte < 0 Or obj.Diasctacte > 365 Then
            mensajes.AppendLine("El campo Días en Cta. Cte. debe estar en el rango de 0-365")
        End If

        'implementar validaciones
        Return (mensajes.Length = 0)
    End Function

    Public Function HasError() As Boolean
        Return Not (mensajes.Length = 0)
    End Function

End Class

