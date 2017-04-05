
Partial Class MenuUsuario
    Inherits System.Web.UI.Page

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Try
            If (Request.QueryString("retorno").ToString().Trim() = "true") Then
                Response.Redirect("RegistroUsuario.aspx?retorno=true")
            End If
        Catch ex As Exception

        End Try
        Response.Redirect("RegistroUsuario.aspx")
    End Sub

    Protected Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click

    End Sub
End Class
