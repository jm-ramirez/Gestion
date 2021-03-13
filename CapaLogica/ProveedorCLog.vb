Imports Entidades
Imports System.Text
Imports CapaDatos

Public Class ProveedorCLog

    Private _ProveedorCDat As New ProveedorCDat
    Private _repositorioCbtes As New CpracabeceraCDat
    Public ReadOnly mensajes As New StringBuilder()

    Public Sub Save(ByRef obj As Proveedor)
        Try
            If (IsValid(obj)) Then
                If (_ProveedorCDat.GetById(obj.Id) Is Nothing) Then
                    obj.Id = _ProveedorCDat.Insert(obj)
                Else
                    _ProveedorCDat.Update(obj)
                End If
            End If
        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
        End Try
    End Sub

    Public Function GetAll() As List(Of Proveedor)
        Return _ProveedorCDat.GetAll()
    End Function

    Public Function GetAllOrderByNombre(Optional ByVal soloActivos As Boolean = False) As List(Of Proveedor)
        Return _ProveedorCDat.GetAllOrderByNombre(soloActivos:=soloActivos)
    End Function

    Public Function GetById(ByVal id As UInt32) As Proveedor
        mensajes.Clear()
        If (id = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            Return _ProveedorCDat.GetById(id)
        Else
            Return Nothing
        End If
    End Function

    Public Function GetByCodigo(ByVal codigo As String) As Proveedor
        mensajes.Clear()
        If (codigo.Length = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Código válido")
        End If
        If (mensajes.Length = 0) Then
            Return _ProveedorCDat.GetByCodigo(codigo)
        Else
            Return Nothing
        End If
    End Function

    Public Function GetByDocumento(ByVal tipo As UInt32, ByVal documento As String) As Proveedor
        mensajes.Clear()

        If (tipo = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de tipo de documento válido")
        End If

        If (documento.Length = 0) Then
            mensajes.AppendLine("Por favor proporcione un número de documento válido")
        End If

        If (mensajes.Length = 0) Then
            Return _ProveedorCDat.GetByDocumento(tipo, documento)
        Else
            Return Nothing
        End If
    End Function


    Public Sub Delete(ByVal id As UInt32)
        mensajes.Clear()

        If (id = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Id válido")
        End If

        If _repositorioCbtes.GetAllByProveedor(Proveedor:=id, cargaAlicuotas:=False, cargaArticulos:=False, cargaAsociados:=False, cargaCtaCte:=False, cargaFinanciero:=False, cargaTributos:=False, vertodos:=True).Count > 0 Then
            mensajes.AppendLine("El proveedor no puede ser eliminado. Existen comprobantes previamente cargados al proveedor.")
        End If

        If (mensajes.Length = 0) Then
            _ProveedorCDat.Delete(id)
        End If
    End Sub

    Private Function IsValid(ByVal obj As Proveedor) As Boolean
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

        If (obj.Rubrogcia = 0) Then
            mensajes.AppendLine("El campo Rubro de Ganancias es de ingreso obligatorio")
        End If

        If Not IsNumeric(obj.Ingresosbrutosalic) Or obj.Ingresosbrutosalic < 0 Or obj.Ingresosbrutosalic > 100 Then
            mensajes.AppendLine("El campo Ret. de IIBB (%) debe estar en el rango de 0-100")
        End If

        If Not IsNumeric(obj.Retivaalic) Or obj.Retivaalic < 0 Or obj.Retivaalic > 100 Then
            mensajes.AppendLine("El campo Ret. de IVA (%) debe estar en el rango de 0-100")
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

