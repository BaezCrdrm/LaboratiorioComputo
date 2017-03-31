Imports System.Data
Imports System.Data.SqlClient

Public Class Usuario
    Private _id As Integer
    Private _nombre As String
    Private _fechaRegistro As DateTime
    Private _idUsuarioClase As Integer 'Usuario tipo
    Private _credencial As String

#Region "Propiedades"
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
    Public Property IDUsuarioClase() As Integer
        Get
            Return _idUsuarioClase
        End Get
        Set(ByVal value As Integer)
            _idUsuarioClase = value
        End Set
    End Property
    Public Property CredencialUsuario() As String
        Get
            Return _credencial
        End Get
        Set(ByVal value As String)
            _credencial = value
        End Set
    End Property
#End Region

#Region "Operaciones"
    Public Overridable Sub GetData(ByVal id_usuario As Integer)
        Dim ds As DataSet
        Dim connection As New Conexion
        Dim query As String =
            "SELECT ID_USUARIO, NOMBRE_USUARIO, FECHA_REG_USUARIO, ID_DEPENDENCIA, ID_USUARIOCLASE, ACTIVO " +
            "FROM USUARIOS WHERE ID_USUARIO = " + id_usuario
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
                'Else
                '    CleanData()
                'End If
            End If
        End If
    End Sub

    'Analizar
    Public Function InsertUpdate() As Boolean
        Dim cm As New SqlCommand
        Dim param As SqlParameter
        Dim cnn As New Conexion
        Dim result As Boolean

        cm.CommandType = CommandType.StoredProcedure

        If IDUsuario = 0 Then
            cm.CommandText = "sp_InsertUsuarios"
        Else
            cm.CommandText = "sp_UpdateUsuarios"
        End If

        param = cm.Parameters.Add("@Id_Usuario", SqlDbType.Int)

        If IDUsuario = 0 Then
            param.Direction = ParameterDirection.Output
        Else
            param.Direction = ParameterDirection.Input
            param.Value = IDUsuario
        End If

        param = cm.Parameters.Add("@Nombre_Usuario", SqlDbType.VarChar)
        param.Direction = ParameterDirection.Input
        param.Value = NombreUsuario

        If IDUsuario = 0 Then
            param = cm.Parameters.Add("@Fecha_Reg_Usuario", SqlDbType.DateTime)
            param.Direction = ParameterDirection.Input
            param.Value = FechaRegistro
        End If

        'param = cm.Parameters.Add("@Id_Dependencia", SqlDbType.Int)
        'param.Direction = ParameterDirection.Input
        'param.Value = m_IdDependencia

        If IDUsuario = 0 Then
            param = cm.Parameters.Add("@Id_UsuarioClase", SqlDbType.Int)
            param.Direction = ParameterDirection.Input
            param.Value = IDUsuarioClase
        End If

        'param = cm.Parameters.Add("@Activo", SqlDbType.Bit)
        'param.Direction = ParameterDirection.Input
        'param.Value = m_Activo

        result = cnn.ExecuteSP(cm)

        If result Then
            If IDUsuario = 0 Then
                IDUsuario = cm.Parameters("@Id_Usuario").Value
            End If
        End If

        Return result
    End Function
#End Region
End Class
