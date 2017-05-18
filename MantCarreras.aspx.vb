
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
                btnGuardar.Text = "Actualizar"
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

        If Not (carrera.Descripcion = "") And Not (carrera.Abreviatura = "") Then
            If action = "modify" Then
                carrera.ID = Convert.ToInt32(Request.QueryString("id").ToString())
                Try
                    If (carrera.Update(carrera.ID)) Then
                        lblStatus.Text = "Se ha actualizado correctamente"
                        btnGoBack.Text = "Cerrar"
                    End If
                Catch ex As Exception
                    lblStatus.Text = "Excepción producida: " & ex.Message.ToString()
                End Try
            Else
                Try
                    If carrera.Insert() Then
                        lblStatus.Text = "Carrera agregada correctamente"
                        btnGoBack.Text = "Cerrar"
                    Else
                        lblStatus.Text = "No se pudo insertar carrera"
                    End If
                Catch ex As Exception
                    lblStatus.Text = "Excepción producida: " & ex.Message.ToString()
                End Try
            End If
        Else
            lblStatus.Text = "Ingrese un nombre de carrera y abreviatura válido"
        End If
    End Sub
    Protected Sub btnGoBack_Click(sender As Object, e As EventArgs) Handles btnGoBack.Click
        Response.Redirect("CarrerasSistema.aspx")
    End Sub
End Class
