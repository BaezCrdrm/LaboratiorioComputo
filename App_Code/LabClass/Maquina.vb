Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class Maquina
    Private _id As Integer
    Private _numero As Integer
    Private _info As String
    Private _bandera As Integer
    Private _mostrar As Boolean

#Region "Propiedades"
    Public Property Mostrar() As Boolean
        Get
            Return _mostrar
        End Get
        Set(ByVal value As Boolean)
            _mostrar = value
        End Set
    End Property
    Public Property Bandera() As Integer
        Get
            Return _bandera
        End Get
        Set(ByVal value As Integer)
            _bandera = value
        End Set
    End Property
    Public Property Info() As String
        Get
            Return _info
        End Get
        Set(ByVal value As String)
            _info = value
        End Set
    End Property
    Public Property Numero() As Integer
        Get
            Return _numero
        End Get
        Set(ByVal value As Integer)
            _numero = value
        End Set
    End Property
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
#End Region

#Region "Operaciones"
    Public Sub New(ByVal id As Integer)
        If id > 0 Then
            GetData(id)
        End If
    End Sub
    Public Sub New()
    End Sub

    Private Sub GetData(ByVal id As Integer)
        Dim ds As DataSet
        Dim cnn As New Conexion
        Dim query As String = String.Format("SELECT ID_MAQUINA, NUMERO_MAQ, INFORMACION_MAQ, BANDERA_MAQ, MOSTRAR_MAQ " _
                                            & "FROM MAQUINAS " _
                                            & "WHERE ID_MAQUINA = {0}", id)
        ds = cnn.GetRows(query)
        If ds.Tables.Count = 1 Then
            Dim dt As DataTable = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                Dim dr As DataRow = dt.Rows(0)
                Me._id = Convert.ToInt32(dr("ID_MAQUINA"))
                Me._numero = Convert.ToString(dr("NUMERO_MAQ"))
                Me._info = Convert.ToString(dr("INFORMACION_MAQ"))
                Me._bandera = Convert.ToString(dr("BANDERA_MAQ"))
                Me.Mostrar = Convert.ToBoolean(dr("MOSTRAR_MAQ"))
            End If
        End If
    End Sub

    Public Function Insert() As Boolean
        Return InsertUpdate("sp_InsertMaquinas", ParameterDirection.Output)
    End Function

    Public Function Update(ByVal id As Integer) As Boolean
        Return InsertUpdate("sp_UpdateMaquinas", ParameterDirection.Input, id)
    End Function

    Private Function InsertUpdate(ByVal sp As String, ByRef pd As ParameterDirection,
                                  Optional id As Integer = 0) As Boolean
        Dim cmd As New SqlCommand
        Dim param As SqlParameter
        Dim cnn As New Conexion

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = sp

        param = cmd.Parameters.Add("@Id_Maquina", SqlDbType.Int)
        param.Direction = pd
        If Not id = 0 Then
            param.Value = id
        End If

        param = cmd.Parameters.Add("@Numero_Maq", SqlDbType.Int)
        param.Direction = ParameterDirection.Input
        param.Value = Me._numero

        param = cmd.Parameters.Add("@Informacion_Maq", SqlDbType.VarChar)
        param.Direction = ParameterDirection.Input
        param.Value = Me._info

        param = cmd.Parameters.Add("@Bandera_Maq", SqlDbType.Int)
        param.Direction = ParameterDirection.Input
        param.Value = Me._bandera

        param = cmd.Parameters.Add("@Mostrar_Maq", SqlDbType.Bit)
        param.Direction = ParameterDirection.Input
        param.Value = Me._mostrar

        Dim resultado As Boolean = cnn.ExecuteSP(cmd)

        If resultado Then
            If id = 0 Then
                Me._id = cmd.Parameters("@Id_Maquina").Value
            End If
        End If

        Return resultado
    End Function
#End Region
End Class
