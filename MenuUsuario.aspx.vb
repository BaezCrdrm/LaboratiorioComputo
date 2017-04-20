
Partial Class MenuUsuario
    Inherits System.Web.UI.Page

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        If testConnection() Then
            Try
                If (Request.QueryString("retorno").ToString().Trim() = "true") Then
                    Response.Redirect("RegistroUsuario.aspx?retorno=true")
                End If
            Catch ex As Exception

            End Try
            Response.Redirect("RegistroUsuario.aspx")
        End If
    End Sub

    Protected Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If testConnection() Then
            Response.Redirect("ModificaUsuario.aspx")
        End If
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
    Protected Sub btnGoBack_Click(sender As Object, e As ImageClickEventArgs) Handles btnGoBack.Click
        Response.Redirect("Default.aspx")
    End Sub
End Class
