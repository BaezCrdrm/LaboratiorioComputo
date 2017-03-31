
Partial Class MantMaquinas
    Inherits System.Web.UI.Page
    Shared mostrar As Boolean
    Shared activa As Boolean
    Private action As String = "new"


    Private Sub MantMaquinas_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("ACTIVE_SESSION") = False Then
            'Inicio de sesión fallido
            Response.Redirect("Login.aspx?status=loginerror")
        Else
            'Inicio de sesión exitoso
            If Request.QueryString("action") = "modify" Then
                action = "modify"
                If Not Page.IsPostBack Then
                    Try
                        Dim id As Integer = Convert.ToInt32(Request.QueryString("id"))
                        cargaDatos(id)
                    Catch ex As Exception

                    End Try
                End If
                btnGuardar.Text = "Actualizar"
            End If
        End If
    End Sub

    Private Sub cargaDatos(ByVal id As Integer)
        Dim maquina As New Maquina(id)
        txtNumero.Text = maquina.Numero
        txtInfo.Text = maquina.Info.Trim()
        If Not Page.IsPostBack Then
            mostrar = maquina.Mostrar
            chkMostrar.Checked = mostrar
        End If

        If (maquina.Bandera = 1 Or maquina.Bandera = 0) And Not Page.IsPostBack Then
            activa = True
            chkActiva.Checked = activa
            If maquina.Bandera = 1 Then
                chkActiva.Text = "La maquina esta siendo utilizada."
                chkActiva.Enabled = False
            End If
        ElseIf maquina.Bandera = 2 Then
            activa = False
            chkActiva.Checked = activa
            chkActiva.Text = "Activa"
            chkActiva.Enabled = True
        End If
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim maquina As New Maquina
        maquina.Numero = txtNumero.Text.Trim
        maquina.Info = txtInfo.Text.Trim
        If Not chkActiva.Enabled Then
            maquina.Bandera = 1
        Else
            If activa = False Then
                maquina.Bandera = 0
            Else
                maquina.Bandera = 2
            End If
        End If
        maquina.Mostrar = mostrar

        If Request.QueryString("action") = "modify" Then
            Maquina.ID = Convert.ToInt32(Request.QueryString("id"))

            If (Maquina.Update(Maquina.ID)) Then
                lblStatus.Text = "Se actualizó correctamente"
                btnGoBack.Text = "Cerrar"
                Response.Redirect("MaquinasSistema.aspx")
            Else
                lblStatus.Text = "No se pudo actualizar"
            End If
        Else
            If (maquina.Insert()) Then
                lblStatus.Text = "Se agregó correctamente"
                btnGoBack.Text = "Cerrar"
                Response.Redirect("MaquinasSistema.aspx")
            Else
                lblStatus.Text = "No se pudo agregar"
            End If
        End If
    End Sub
    Protected Sub chkActiva_CheckedChanged(sender As Object, e As EventArgs) Handles chkActiva.CheckedChanged

    End Sub
    Protected Sub chkMostrar_CheckedChanged(sender As Object, e As EventArgs) Handles chkMostrar.CheckedChanged
        mostrar = Not mostrar
        chkMostrar.Checked = mostrar
    End Sub
    Protected Sub btnGoBack_Click(sender As Object, e As EventArgs) Handles btnGoBack.Click
        Response.Redirect("MaquinasSistema.aspx")
    End Sub
End Class