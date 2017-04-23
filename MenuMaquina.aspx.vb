
Partial Class MenuMaquina
    Inherits System.Web.UI.Page

    Protected Sub btnEntrada_Click(sender As Object, e As EventArgs) Handles btnEntrada.Click
        Response.Redirect("EntradaMaq.aspx")
    End Sub
    Protected Sub btnGoBack_Click(sender As Object, e As ImageClickEventArgs) Handles btnGoBack.Click
        Response.Redirect("Default.aspx")
    End Sub
    Protected Sub btnSalida_Click(sender As Object, e As EventArgs) Handles btnSalida.Click
        Response.Redirect("SalidaMaquina.aspx")
    End Sub
    Protected Sub btnListar_Click(sender As Object, e As EventArgs) Handles btnListar.Click
        Response.Redirect("TiempoMaq.aspx")
    End Sub
End Class
