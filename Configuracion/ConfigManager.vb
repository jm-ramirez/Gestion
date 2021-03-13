Imports System
Imports System.Configuration
Imports System.Web.Configuration

Public Class ConfigManager
    Private Shared Function GetConfiguration() As Configuration
        Dim Path As String
        Dim Config As Configuration

        If System.Web.HttpContext.Current Is Nothing Then
            Path = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppDomain.CurrentDomain.FriendlyName)
            Config = ConfigurationManager.OpenExeConfiguration(Path)
        Else
            Path = System.Web.HttpContext.Current.Request.ApplicationPath
            Config = WebConfigurationManager.OpenWebConfiguration(Path)
        End If

        Return Config

    End Function

    Public Shared Function GetValue(ByVal Key As String) As String
        Dim Config As Configuration
        Dim Value As String

        Try
            Config = GetConfiguration()

            Try
                Value = Config.AppSettings.Settings(Key).Value
            Catch ex As Exception
                Throw New Collections.Generic.KeyNotFoundException(String.Format("Error: la clave '{0}' no existe en el archivo de configuracion.", Key), ex)
            End Try

            Return Value

        Finally

            Config = Nothing

        End Try

    End Function

End Class
