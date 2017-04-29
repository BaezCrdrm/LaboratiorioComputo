
Partial Class _Default
    Inherits System.Web.UI.Page

    'Protected Sub btnUsuarios_Click(sender As Object, e As EventArgs) Handles btnUsuarios.Click
    '    Response.Redirect("MenuUsuario.aspx")
    'End Sub

    Protected Sub btnAcceso_Click(sender As Object, e As EventArgs) Handles btnAcceso.Click
        Response.Redirect("MenuMaquina.aspx")
    End Sub

    Protected Sub btnAdmSistema_Click(sender As Object, e As EventArgs) Handles btnAdmSistema.Click
        Response.Redirect("Login.aspx")
    End Sub
    Protected Sub btnUsuarios_Click(sender As Object, e As EventArgs) Handles btnUsuarios.Click
        Response.Redirect("MenuUsuario.aspx")
    End Sub
End Class
