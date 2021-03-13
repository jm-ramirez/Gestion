Imports MySql.Data
Imports System.Reflection
Imports System.Configuration
Module Conexion

    'Public Function CreateConnection() As MySqlClient.MySqlConnection
    '    Dim oCnn As MySqlClient.MySqlConnection
    '    Dim ConnectionString As String = ""
    '    Try
    '        'Obtenemos el ConnectionString desde el archivo de configuración
    '        ConnectionString = My.Settings.cnnString
    '        'Creamos una conexión
    '        oCnn = New MySqlClient.MySqlConnection
    '        'Asignamos el connectionString que se obtenido del archivo de configuración
    '        oCnn.ConnectionString = ConnectionString
    '        'Retornamos el objeto conexion creado
    '        Return oCnn
    '    Finally
    '        'No nos olvidemos de eliminar las referencias a objetos que no utilicemos
    '        oCnn = Nothing
    '    End Try
    'End Function

    Public Function CreateConnection() As MySqlClient.MySqlConnection
        Dim oCnn As MySqlClient.MySqlConnection
        Dim ConnectionString As String = ""
        Try
            'Obtenemos el ConnectionString desde el archivo de configuración
            ConnectionString = Configuracion.ConfigManager.GetValue("cnnString")

            'Creamos una conexión
            oCnn = New MySqlClient.MySqlConnection

            'Asignamos el connectionString que se obtenido del archivo de configuración
            oCnn.ConnectionString = ConnectionString
            'Retornamos el objeto conexion creado
            Return oCnn

        Finally
            'No nos olvidemos de eliminar las referencias a objetos que no utilicemos
            oCnn = Nothing
        End Try
    End Function

End Module

