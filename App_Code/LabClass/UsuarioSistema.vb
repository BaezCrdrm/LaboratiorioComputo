Imports Microsoft.VisualBasic

Public Class UsuarioSistema : Inherits Usuario
    Private _puesto As String
    Private _idLaboratiorio As Integer
    Private _username As String
    Private _idUsuarioCaptura As String 'Capturado por...

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

End Class
