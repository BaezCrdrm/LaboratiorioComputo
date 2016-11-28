Imports Microsoft.VisualBasic

Public Class UsuarioTipo : Inherits Usuario
    Private _idTipoUsuario As Integer
    Private _descripcion As String

    Public Property IDTipoUsuario() As Integer
        Get
            Return _idTipoUsuario
        End Get
        Set(ByVal value As Integer)
            _idTipoUsuario = value
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

End Class
