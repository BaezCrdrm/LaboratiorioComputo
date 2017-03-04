
Partial Class MenuAdministrador
    Inherits System.Web.UI.Page
    Private Sub MenuAdministrador_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("ACTIVE_SESSION") = False Then
            Response.Redirect("Login.aspx?status=loginerror")
        End If
    End Sub

    Protected Sub btnCarreras_Click(sender As Object, e As EventArgs) Handles btnCarreras.Click
        Response.Redirect("CarrerasSistema.aspx")
    End Sub

    Protected Sub btnMaquinas_Click(sender As Object, e As EventArgs) Handles btnMaquinas.Click
        Response.Redirect("MaquinasSistema.aspx")
    End Sub

    Protected Sub btnGoBack_Click(sender As Object, e As ImageClickEventArgs) Handles btnGoBack.Click
        Response.Redirect("Default.aspx")
    End Sub
End Class
