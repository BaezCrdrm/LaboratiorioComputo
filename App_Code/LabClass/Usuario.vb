Imports System.Data

Public Class Usuario
    Private _id As Integer
    Private _nombre As String
    Private _fechaRegistro As DateTime
    Private _estado As Boolean
    Private _idUsuarioClase As Integer 'Usuario tipo

    'Preguntar
    'Private m_IdDependencia As Integer = 0

    'Propiedades
    Public Property IDUsuario() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property NombreUsuario() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property
    Public Property FechaRegistro() As DateTime
        Get
            Return _fechaRegistro
        End Get
        Set(ByVal value As DateTime)
            _fechaRegistro = value
        End Set
    End Property
    Public Property EstadoUsuario() As Boolean
        Get
            Return _estado
        End Get
        Set(ByVal value As Boolean)
            _estado = value
        End Set
    End Property
    Public Property IDUsuarioClase() As Integer
        Get
            Return _idUsuarioClase
        End Get
        Set(ByVal value As Integer)
            _idUsuarioClase = value
        End Set
    End Property

    'Operaciones
    Public Overridable Sub GetData(ByVal id_usuario As Integer)
        Dim ds As DataSet
        Dim connection As New Conexion
        Dim query As String =
            "SELECT ID_USUARIO, NOMBRE_USUARIO, FECHA_REG_USUARIO, ID_DEPENDENCIA, ID_USUARIOCLASE, ACTIVO FROM USUARIOS WHERE ID_USUARIO = " + id_usuario
        ds = connection.GetRows(query)

        If ds.Tables.Count = 1 Then
            Dim dt As DataTable = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                Dim dr As DataRow = dt.Rows(0)
                IDUsuario = Convert.ToInt32(dr("ID_USUARIO"))
                NombreUsuario = Convert.ToString(dr("NOMBRE_USUARIO"))
                FechaRegistro = Convert.ToDateTime(dr("FECHA_REG_USUARIO"))
                'm_IdDependencia = Convert.ToInt32(dr("ID_DEPENDENCIA"))
                IDUsuarioClase = Convert.ToInt32(dr("ID_USUARIOCLASE"))
                EstadoUsuario = Convert.ToBoolean(dr("ACTIVO"))
                'Else
                '    CleanData()
                'End If
            End If
        End If
    End Sub
End Class
