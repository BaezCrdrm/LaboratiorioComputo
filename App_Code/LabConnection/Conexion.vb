Imports System.Data
Imports System.Data.SqlClient

Public Class Conexion
    Private sqlCnn As String = System.Configuration.ConfigurationManager.AppSettings("cnn")
    'Private _rutaReporte As String = System.Configuration.ConfigurationManager.AppSettings("rutaReporte")
    Private connection As SqlConnection
    Private dataAdapter As SqlDataAdapter
    Private ds As DataSet

    Public Function GetRows(ByVal query As String) As DataSet
        Try
            connection = New SqlConnection(sqlCnn)
            dataAdapter = New SqlDataAdapter(query, connection)
            ds = New DataSet
            dataAdapter.Fill(ds)
            connection.Close()
            Return ds
        Catch ex As Exception
            connection.Close()
            excepcionProducida("GetRows", ex)
            Return Nothing
        End Try
    End Function

    Public Function ExecuteQuery(ByVal query As String) As Boolean
        Try
            Dim cmd As SqlCommand
            connection = New SqlConnection(sqlCnn)
            cmd = New SqlCommand(query, connection)
            connection.Open()
            cmd.ExecuteNonQuery()
            connection.Close()
            Return True
        Catch ex As Exception
            connection.Close()
            excepcionProducida("ExecuteQuery", ex)
            Return False
        End Try
    End Function

    Public Function ExecuteSP(ByVal cmd As SqlCommand) As Boolean
        Try
            connection = New SqlConnection(sqlCnn)
            cmd.Connection = connection
            connection.Open()
            cmd.ExecuteNonQuery()
            connection.Close()
            Return True
        Catch ex As Exception
            connection.Close()
            excepcionProducida("ExecuteSP", ex)
            Return False
        End Try
    End Function

    '
    Public Function Count(ByVal query As String) As Integer
        Try
            Dim cmd As SqlCommand
            connection = New SqlConnection(sqlCnn)
            cmd = New SqlCommand(query, connection)
            connection.Open()
            Dim i As Integer = cmd.ExecuteScalar()
            connection.Close()
            Return i
        Catch ex As Exception
            connection.Close()
            excepcionProducida("Count", ex)
            Return 0
        End Try
    End Function

    Public Function DataReader(ByVal query As String, ByRef obj As Object) As SqlDataReader
        Try
            Dim cmd As SqlCommand
            Dim reader As SqlDataReader
            connection = New SqlConnection(sqlCnn)
            cmd = New SqlCommand(query, connection)
            connection.Open()
            reader = cmd.ExecuteReader()
            connection.Close()
            Return reader
        Catch ex As Exception
            connection.Close()
            excepcionProducida("DataReader", ex)
            Return Nothing
        End Try
    End Function

    Public Function TestConnection() As Boolean
        Try
            connection = New SqlConnection(sqlCnn)
            connection.Open()
            connection.Close()
            Return True
        Catch ex As Exception
            connection.Close()
            Return False
        End Try
    End Function

    Private Sub excepcionProducida(ByVal funcion As String, ByVal excepcion As Exception)
        System.Diagnostics.Debug.WriteLine("Hubo un problema con la función '" + funcion + "'")
        System.Diagnostics.Debug.Write(excepcion.Message.ToString())
    End Sub

    'Public ReadOnly Property RutaReporte() As String
    '    Get
    '        Return _rutaReporte
    '    End Get
    'End Property
End Class
