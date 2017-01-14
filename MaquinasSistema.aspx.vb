
Partial Class MaquinasSistema
    Inherits System.Web.UI.Page

    Private Sub MaquinasSistema_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("ACTIVE_SESSION") = False Then
            Response.Redirect("Login.aspx?status=loginerror")
        End If
    End Sub


End Class
