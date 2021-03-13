Imports Entidades
Imports System.Text
Imports CapaDatos
Public Class ArticuloCLog

    Private _ArticuloCDat As New ArticuloCDat
    Public ReadOnly mensajes As New StringBuilder()
    Public Sub Save(ByRef obj As Articulo)
        Try
            If (IsValid(obj)) Then
                If (_ArticuloCDat.GetById(obj.Id) Is Nothing) Then
                    obj.Id = _ArticuloCDat.Insert(obj)
                Else
                    _ArticuloCDat.Update(obj)
                End If
            End If
        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
        End Try
    End Sub

    Public Function SaveInventario(ByRef objList As List(Of Articulo), ByVal usuario As Entidades.Personal) As UInt32
        Try

            Return _ArticuloCDat.SaveInventario(objList, usuario)

        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
            Return 0
        End Try
    End Function

    Public Sub UpdatePrecios(ByRef objList As List(Of Articulo), ByVal usuario As Entidades.Personal)
        Try

            _ArticuloCDat.UpdatePrecios(objList, usuario)

        Catch ex As Exception
            mensajes.AppendLine(ex.Message)

        End Try
    End Sub

    Public Sub UpdatePreciosArticulos(ByVal Id As UInt32, ByVal PrecioVenta As Double)
        Try

            _ArticuloCDat.UpdatePreciosArticulo(Id, PrecioVenta)

        Catch ex As Exception
            mensajes.AppendLine(ex.Message)

        End Try
    End Sub
    Public Sub UpdatePreciosClientes(ByVal alicuota As Double, ByVal cliente As String)
        Try

            _ArticuloCDat.UpdatePreciosCliente(alicuota, cliente)

        Catch ex As Exception
            mensajes.AppendLine(ex.Message)

        End Try
    End Sub

    Public Sub UpdatePreciosPorEntornoDeRubro(ByVal rdesde As UInt32, ByVal rhasta As UInt32, ByVal alicuota As Double, Optional ByVal proveedor As UInt32 = 0)
        Try

            mensajes.Clear()

            If (rdesde = 0) Then
                mensajes.AppendLine("Por favor proporcione un valor de Rubro válido")
            End If

            If (rhasta = 0) Then
                mensajes.AppendLine("Por favor proporcione un valor de Rubro válido")
            End If

            If (alicuota <= 0) Then
                mensajes.AppendLine("Por favor proporcione un valor de Alicuota válido")
            End If

            If (mensajes.Length = 0) Then
                _ArticuloCDat.UpdatePreciosPorEntornoDeRubro(rdesde, rhasta, alicuota, proveedor)
            End If


        Catch ex As Exception
            mensajes.AppendLine(ex.Message)
        End Try
    End Sub

    'Public Function GetByCliente(ByVal pstrCliente As String, Optional ByVal pstrOrden As String = "p.codcliente,p.codigo", Optional ByVal blnArtVarios As Boolean = False) As List(Of Articulo)
    '    Return _ArticuloCDat.GetByCliente(pstrCliente, pstrOrden, blnArtVarios)
    'End Function
    Public Function GetByArticulo(ByVal pstrPieza As String, Optional ByVal pstrOrden As String = "p.codcliente,p.codigo") As List(Of Articulo)
        Return _ArticuloCDat.GetByArticulo(pstrPieza, pstrOrden)
    End Function

    Public Function GetNextCodigo() As String
        Return _ArticuloCDat.GetNextCodigo
    End Function
    Public Function GetAll() As List(Of Articulo)
        Return _ArticuloCDat.GetAll()
    End Function



    Public Function GetArticulosConExistencia() As List(Of Articulo)
        Return _ArticuloCDat.GetArticulosConExistencia()
    End Function

    Public Function GetById(ByVal id As UInt32) As Articulo
        mensajes.Clear()
        If (id = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Id válido")
        End If
        If (mensajes.Length = 0) Then
            Return _ArticuloCDat.GetById(id)
        Else
            Return Nothing
        End If
    End Function

    Public Function GetByCodigo(ByVal Codigo As String) As Articulo
        mensajes.Clear()
        If (Codigo = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Codigo válido")
        End If
        If (mensajes.Length = 0) Then
            Return _ArticuloCDat.GetByCodigo(Codigo)
        Else
            Return Nothing
        End If
    End Function

    Public Function GetExistencia(ByVal Codigo As String) As Double
        mensajes.Clear()
        If (Codigo.Length = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Codigo válido")
        End If
        If (mensajes.Length = 0) Then
            Return _ArticuloCDat.GetExistencia(Codigo)
        Else
            Return 0
        End If
    End Function

    Public Function GetByCodigoBarra(ByVal codigo As String, ByVal codCliente As String) As Articulo
        mensajes.Clear()
        If (codigo.Length = 0) Then
            mensajes.AppendLine("Por favor proporcione un valor de Codigo válido")
        End If
        If (mensajes.Length = 0) Then
            Return _ArticuloCDat.GetByCodigoBarra(codigo)
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
            _ArticuloCDat.Delete(id)
        End If
    End Sub

    'Public Sub DeletePlano(ByVal id As UInt32)

    '    Try
    '        mensajes.Clear()
    '        If (id = 0) Then
    '            mensajes.Append("Por favor proporcione un valor de Id válido")
    '        End If
    '        If (mensajes.Length = 0) Then
    '            _ArticuloCDat.DeletePlano(id)
    '        End If
    '    Catch ex As Exception
    '        mensajes.Append(ex.Message)
    '    End Try
    'End Sub

    'Public Sub DeleteFoto(ByVal id As UInt32)

    '    Try
    '        mensajes.Clear()
    '        If (id = 0) Then
    '            mensajes.Append("Por favor proporcione un valor de Id válido")
    '        End If
    '        If (mensajes.Length = 0) Then
    '            _ArticuloCDat.DeleteFoto(id)
    '        End If
    '    Catch ex As Exception
    '        mensajes.Append(ex.Message)
    '    End Try
    'End Sub

    Private Function IsValid(ByVal obj As Articulo) As Boolean
        mensajes.Clear()
        'implementar validaciones
        'If (obj.Codcliente.Trim.Length = 0) Then
        ''    mensajes.AppendLine("El Cliente no puede estar vacío")
        'End If

        If (obj.Codigo.Trim.Length = 0) Then
            mensajes.AppendLine("El Código no puede estar vacío")
        End If

        'If (obj.Plu.Trim.Length = 0) Then
        '    mensajes.AppendLine("El Plu no puede ser 0 (cero)")
        'End If

        If (obj.Nombre.Trim.Length = 0) Then
            mensajes.AppendLine("Debe asignar un nombre al artículo")
        End If

        If (obj.Codcategoria.Trim.Length = 0) Then
            mensajes.AppendLine("Debe asignar una categoría de artículo válida")
        End If

        If (obj.Codrubro.Trim.Length = 0) Then
            mensajes.AppendLine("Debe asignar un rubro de artículo válido")
        End If

        If (obj.Codunidad.Trim.Length = 0) Then
            mensajes.AppendLine("Debe asignar una unidad de artículo válida")
        End If

        'If (obj.Codmaterial.Trim.Length = 0) Then
        '    mensajes.AppendLine("Debe asignar un Material de artículo válido")
        'End If

        If (obj.Alicuotaiva = 0) Then
            mensajes.AppendLine("Debe asignar una alícuota de IVA válida")
        End If

        If obj.Descuento < 0 Or obj.Descuento > 100 Then
            mensajes.AppendLine("Debe asignar una % de descuento [1] válido")
        End If

        If obj.Descuento2 < 0 Or obj.Descuento2 > 100 Then
            mensajes.AppendLine("Debe asignar una % de descuento [2] válido")
        End If

        If obj.Descuento3 < 0 Or obj.Descuento3 > 100 Then
            mensajes.AppendLine("Debe asignar una % de descuento [3] válido")
        End If

        If obj.Descuentocompra1 < 0 Or obj.Descuentocompra1 > 100 Then
            mensajes.AppendLine("Debe asignar una % de descuento de compra [1] válido")
        End If

        If obj.Descuentocompra2 < 0 Or obj.Descuentocompra2 > 100 Then
            mensajes.AppendLine("Debe asignar una % de descuento de compra [2] válido")
        End If

        If obj.Descuentocompra3 < 0 Or obj.Descuentocompra3 > 100 Then
            mensajes.AppendLine("Debe asignar una % de descuento de compra [3] válido")
        End If

        'For Each f As Entidades.Fotos In obj.Fotos
        '    If (f.Ruta.Length > 254) Then
        '        mensajes.AppendLine("La ruta de acceso a la imagen supera el límite válido")
        '    End If
        'Next

        'For Each p As Entidades.Planos In obj.Planos
        '    If (p.Ruta.Length > 254) Then
        '        mensajes.AppendLine("La ruta de acceso al plano supera el límite válido")
        '    End If
        'Next

        Return (mensajes.Length = 0)
    End Function

    Public Function HasError() As Boolean
        Return Not (mensajes.Length = 0)
    End Function
End Class

