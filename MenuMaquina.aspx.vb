
Partial Class MenuMaquina
    Inherits System.Web.UI.Page

    Protected Sub btnEntrada_Click(sender As Object, e As EventArgs) Handles btnEntrada.Click
        If testConnection() Then
            Response.Redirect("EntradaMaq.aspx")
        End If
    End Sub
    Protected Sub btnGoBack_Click(sender As Object, e As ImageClickEventArgs) Handles btnGoBack.Click
        Response.Redirect("Default.aspx")
    End Sub
    Protected Sub btnSalida_Click(sender As Object, e As EventArgs) Handles btnSalida.Click
        If testConnection() Then
            Response.Redirect("SalidaMaquina.aspx")
        End If
    End Sub
    Protected Sub btnListar_Click(sender As Object, e As EventArgs) Handles btnListar.Click
        If testConnection() Then
            Response.Redirect("TiempoMaq.aspx")
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
End Class
