
Partial Class MenuMaquina
    Inherits System.Web.UI.Page

    Protected Sub btnEntrada_Click(sender As Object, e As EventArgs) Handles btnEntrada.Click
        Response.Redirect("EntradaMaq.aspx")
    End Sub
    Protected Sub btnGoBack_Click(sender As Object, e As ImageClickEventArgs) Handles btnGoBack.Click
        Response.Redirect("Default.aspx")
    End Sub
End Class
