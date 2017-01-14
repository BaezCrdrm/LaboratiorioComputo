Imports System.Data
Imports Microsoft.VisualBasic

Public Class UsuarioSistema : Inherits Usuario
    Private _puesto As String
    Private _idLaboratiorio As Integer
    Private _username As String
    Private _idUsuarioCaptura As String 'Capturado por...

#Region "Propiedades"
    Public Property IDUsuarioCaptura() As String
        Get
            Return _idUsuarioCaptura
        End Get
        Set(ByVal value As String)
            _idUsuarioCaptura = value
        End Set
    End Property
    Public Property UserName() As String
        Get
            Return _username
        End Get
        Set(ByVal value As String)
            _username = value
        End Set
    End Property
    Public Property IDLaboratorio() As Integer
        Get
            Return _idLaboratiorio
        End Get
        Set(ByVal value As Integer)
            _idLaboratiorio = value
        End Set
    End Property
    Public Property NewProperty() As String
        Get
            Return _puesto
        End Get
        Set(ByVal value As String)
            _puesto = value
        End Set
    End Property
#End Region

#Region "Funciones"
    Public Function ValidaUsuario(ByVal userName As String) As Integer
        Dim connection As New Conexion
        Dim ds As DataSet
        Dim query As String

        query = String.Format("SELECT ID_USUARIOSISTEMA FROM dbo.USUARIOSSISTEMA WHERE USERNAME = '{0}'",
                              userName)
        ds = connection.GetRows(query)
        If ds.Tables.Count > 0 Then
            Dim dt As DataTable = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                Return Convert.ToInt32(dt.Rows(0)("ID_USUARIOSISTEMA"))
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
    End Function
#End Region

End Class
