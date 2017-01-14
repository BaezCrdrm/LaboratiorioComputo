Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class Carrera
    Private _id As Integer
    Private _descripcion As String
    Private _abr As String

#Region "Propiedades"
    Public Property Abreviatura() As String
        Get
            Return _abr
        End Get
        Set(ByVal value As String)
            _abr = value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
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
        Try
            GetData(id)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error en el constructor")
            System.Diagnostics.Debug.Write(ex.Message)
        End Try
    End Sub

    Public Sub New()

    End Sub

    Private Sub GetData(ByVal id As Integer)
        Dim ds As DataSet
        Dim cnn As New Conexion
        Dim query As String = String.Format("SELECT DESCRIPCION, ABREVIATURA " &
                                            "FROM CARRERAS WHERE ID_CARRERA = {0}", id)
        ds = cnn.GetRows(query)
        If ds.Tables.Count Then
            Dim dt As DataTable = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                Dim dr As DataRow = dt.Rows(0)
                'Me._id = Convert.ToInt32(dr("ID_CARRERA"))
                Me._descripcion = Convert.ToString(dr("DESCRIPCION"))
                Me._abr = Convert.ToString(dr("ABREVIATURA"))
            End If
        End If
    End Sub

    Public Function Insert() As Boolean
        Return insertUpdate("sp_InsertCarreras", ParameterDirection.Output)
    End Function

    Public Function Update(ByVal id As Integer) As Boolean
        Return insertUpdate("sp_UpdateCarreras", ParameterDirection.Input, id)
    End Function

    Private Function insertUpdate(ByVal sp As String, ByRef pd As ParameterDirection,
                                  Optional id As Integer = 0) As Boolean
        Dim cmd As New SqlCommand
        Dim param As SqlParameter
        Dim cnn As New Conexion
        Dim resultado As Boolean

        cmd.CommandType = CommandType.StoredProcedure

        If id = 0 Then
            cmd.CommandText = "sp_InsertCarreras"
        Else
            cmd.CommandText = "sp_UpdateCarreras"
        End If

        param = cmd.Parameters.Add("@Id_Carrera", SqlDbType.Int)
        param.Direction = pd
        If Not id = 0 Then
            param.Value = id
        End If

        param = cmd.Parameters.Add("@Descripcion", SqlDbType.Char)
        param.Direction = ParameterDirection.Input
        param.Value = Me._descripcion

        param = cmd.Parameters.Add("@Abreviatura", SqlDbType.Char)
        param.Direction = ParameterDirection.Input
        param.Value = Me._abr

        'If id = "" Then
        '    param = cmd.Parameters.Add("@Id_UsuarioSistema", SqlDbType.Int)
        '    param.Direction = ParameterDirection.Input
        '    param.Value = m_IdUsuarioSistema
        'End If

        resultado = cnn.ExecuteSP(cmd)

        If resultado = True Then
            If id = 0 Then
                Me._id = cmd.Parameters("@Id_Carrera").Value
            End If
        End If

        Return resultado
    End Function
#End Region

End Class
