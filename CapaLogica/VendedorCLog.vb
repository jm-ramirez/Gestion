Imports Entidades
Imports System.Text
Imports CapaDatos
Public Class VendedorCLog

    Private _VendedorCDat As New VendedorCDat
    Public ReadOnly mensajes As New StringBuilder()
    Public Sub Save(ByRef obj As Vendedor)
        Try
            If (IsValid(obj)) Then
                If (_VendedorCDat.GetById(obj.Id) Is Nothing) Then
                    obj.Id = _VendedorCDat.Insert(obj)
                Else
                    _VendedorCDat.Update(obj)
                End If
            End If
        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
        End Try
    End Sub

    Public Sub UpdateComisionRevendedor(ByRef obj As Vendedor, ByVal comision As Double)
        Try
            mensajes.Clear()
            If (obj.Id = 0) Then
                mensajes.AppendLine("Por favor proporcione un valor de Id válido")
            End If

            If (comision < 0 Or comision > 100) Then
                mensajes.AppendLine("Por favor proporcione un valor de Comisión válido. El valor no puede ser menor que cero y mayor que cien")
            End If

            If (mensajes.Length = 0) Then
                _VendedorCDat.UpdateComisionRevendedor(obj, comision)
            End If
        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
        End Try
    End Sub

    Public Sub UpdateComisionKiosko(ByRef obj As Vendedor, ByVal comision As Double)
        Try
            mensajes.Clear()
            If (obj.Id = 0) Then
                mensajes.AppendLine("Por favor proporcione un valor de Id válido")
            End If

            If (comision < 0 Or comision > 100) Then
                mensajes.AppendLine("Por favor proporcione un valor de Comisión válido. El valor no puede ser menor que cero y mayor que cien")
            End If

            If (mensajes.Length = 0) Then
                _VendedorCDat.UpdateComisionKiosko(obj, comision)
            End If
        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
        End Try
    End Sub

    Public Function GetAll() As List(Of Vendedor)
        Return _VendedorCDat.GetAll()
    End Function

    Public Function GetById(ByVal id As UInt32) As Vendedor
        mensajes.Clear()
        If (id = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            Return _VendedorCDat.GetById(id)
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
            _VendedorCDat.Delete(id)
        End If

    End Sub
    Private Function IsValid(ByVal obj As Vendedor) As Boolean
        mensajes.Clear()

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

        If (obj.Zona = 0) Then
            mensajes.AppendLine("El campo Zona es de ingreso obligatorio")
        End If

        'If (obj.Supervisor = 0) Then
        '    mensajes.AppendLine("El campo Supervisor es de ingreso obligatorio")
        'End If

        'If (obj.Acompaniante = 0) Then
        '    mensajes.AppendLine("El campo Acompañante es de ingreso obligatorio")
        'End If

        'If Not IsNumeric(obj.Comision) Or obj.Comision < 0 Or obj.Comision > 100 Then
        '    mensajes.AppendLine("El campo Comisión (%) debe estar en el rango de 0-100")
        'End If

        Return (mensajes.Length = 0)
    End Function

    Public Function HasError() As Boolean
        Return Not (mensajes.Length = 0)
    End Function
End Class

