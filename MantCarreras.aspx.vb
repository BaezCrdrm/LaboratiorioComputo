
Partial Class MantCarreras
    Inherits System.Web.UI.Page
    Private action As String = "new"

    Private Sub MantCarreras_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("ACTIVE_SESSION") = False Then
            'Inicio de sesión fallido
            Response.Redirect("Login.aspx?status=loginerror")
        Else
            'Inicio de sesión exitoso
            If Request.QueryString("action") = "modify" Then
                action = "modify"
                If Not Page.IsPostBack Then
                    cargaDatos(Convert.ToInt32(Request.QueryString("id").ToString()))
                End If
            End If
        End If
    End Sub

    Sub cargaDatos(ByVal id As Integer)
        Dim carrera As New Carrera(id)
        txtNombre.Text = carrera.Descripcion.Trim()
        txtAbv.Text = carrera.Abreviatura.Trim()
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim carrera As New Carrera
        carrera.Descripcion = txtNombre.Text.Trim().ToUpper()
        carrera.Abreviatura = txtAbv.Text.Trim().ToUpper()
        If action = "modify" Then
            carrera.ID = Convert.ToInt32(Request.QueryString("id").ToString())
            Try
                carrera.Update(carrera.ID)
                Response.Redirect("CarrerasSistema.aspx")
            Catch ex As Exception
                lblError.Text = "Excepción producida: " & ex.Message.ToString()
            End Try
        Else
            Try
                If carrera.Insert() Then
                    lblError.Text = "Carrera agregada correctamente"
                Else
                    lblError.Text = "No se pudo insertar carrera"
                End If
            Catch ex As Exception
                lblError.Text = "Excepción producida: " & ex.Message.ToString()
            End Try
        End If
    End Sub
End Class
