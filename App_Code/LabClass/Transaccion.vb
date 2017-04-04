Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class Transaccion
    Private _id As Integer
    Private _idUsuario As Integer
    Private _fechaTrans As DateTime
    Private _idMaquina As Integer

#Region "Propiedades"
    Public Property IdMaquina() As Integer
        Get
            Return _idMaquina
        End Get
        Set(ByVal value As Integer)
            _idMaquina = value
        End Set
    End Property
    Public Property FechaTrans() As DateTime
        Get
            Return _fechaTrans
        End Get
        Set(ByVal value As DateTime)
            _fechaTrans = value
        End Set
    End Property

    Public Property IdUsuario() As Integer
        Get
            Return _idUsuario
        End Get
        Set(ByVal value As Integer)
            _idUsuario = value
        End Set
    End Property
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
#End Region

    Public Sub New(ByVal id As Integer)
        If id > 0 Then
            GetData(id)
        End If
    End Sub

    Public Sub GetData(ByVal id As Integer)
        Dim ds As DataSet
        Dim con As New Conexion
        Dim qs As String = "SELECT ID_TRANS, ID_USUARIO, FECHA_TRANS, ID_MAQUINA FROM TRANSACCIONES WHERE ID_TRANS = " & id
        ds = con.GetRows(qs)
        If ds.Tables.Count = 1 Then
            Dim dt As DataTable = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                Dim dr As DataRow = dt.Rows(0)
                Me._id = Convert.ToInt32(dr("ID_TRANS"))
                Me._idUsuario = Convert.ToInt32(dr("ID_USUARIO"))
                Me._fechaTrans = Convert.ToDateTime(dr("FECHA_TRANS"))
                Me._idMaquina = Convert.ToInt32(dr("ID_MAQUINA"))
            End If
        End If
    End Sub

    Public Function InsertUpdate() As Integer
        Dim cm As New SqlCommand
        Dim param As SqlParameter
        Dim cnn As New Conexion
        Dim result As Boolean

        cm.CommandType = CommandType.StoredProcedure

        If Me.Id = 0 Then
            cm.CommandText = "sp_InsertTransacciones"
        Else
            'Preguntar. No existe procedimiento almacenado
            cm.CommandText = "sp_UpdateTransacciones"
        End If

        param = cm.Parameters.Add("@Id_Trans", SqlDbType.Int)

        If Me.Id = 0 Then
            param.Direction = ParameterDirection.Output
        Else
            param.Direction = ParameterDirection.Input
            param.Value = Me.Id
        End If

        param = cm.Parameters.Add("@Id_Usuario", SqlDbType.Int)
        param.Direction = ParameterDirection.Input
        param.Value = Me.IdUsuario

        'param = cm.Parameters.Add("@Tipo_Servicio", SqlDbType.Int)
        'param.Direction = ParameterDirection.Input
        'param.Value = m_TipoServicio

        param = cm.Parameters.Add("@Id_Maquina", SqlDbType.Int)
        param.Direction = ParameterDirection.Input
        param.Value = Me.IdMaquina

        result = cnn.ExecuteSP(cm)

        If result Then
            If Me.Id = 0 Then
                Me.Id = cm.Parameters("@Id_Trans").Value
            End If
        End If

        Return Me.Id
    End Function
End Class