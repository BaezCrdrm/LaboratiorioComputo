﻿
Partial Class Login
    Inherits System.Web.UI.Page
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles Me.Load
        Session("ACTIVE_SESSION") = False
        If Request.QueryString("status") = "loginerror" Then
            lblError.Text = "Es necesario que inicie sesión"
        End If
    End Sub

    Protected Sub btnAccept_Click(sender As Object, e As EventArgs) Handles btnAccept.Click
        If testConnection() Then
            Web.Security.FormsAuthentication.SignOut()
            Dim username As String = txtUsuario.Text.ToString.Trim

            ' FormsAuthentication está obsoleto. Se recomienda ocupar Membership API
            '   Para poder ocuparla es necesario alterar la base de datos
            '   https://msdn.microsoft.com/library/tw292whz.aspx
            If FormsAuthentication.Authenticate(username, txtPass.Text.ToString.Trim) Then
                Dim user As New UsuarioSistema
                user.IDUsuario = user.ValidaUsuario(username)

                If Not IsNothing(user.IDUsuario) Then
                    Session("ID_USUARIOSISTEMA") = user.IDUsuario
                    Session("ACTIVE_SESSION") = True

                    Response.Redirect("MenuAdministrador.aspx")
                Else
                    Session("ID_USUARIOSISTEMA") = Nothing
                    Session("ACTIVE_SESSION") = False
                End If
            End If
        End If
    End Sub

    Protected Sub btnGoBack_Click(sender As Object, e As ImageClickEventArgs) Handles btnGoBack.Click
        Response.Redirect("Default.aspx")
    End Sub

    Private Function testConnection() As Boolean
        Dim con As New Conexion
        If con.TestConnection = False Then
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "script",
                                                String.Format("connectionFailed(null, '{0}');",
                                                              "No se pudo conectar con la base de datos"), True)
            Return False
        Else
            Return True
        End If
    End Function
End Class
