
Partial Class MantMaquinas
    Inherits System.Web.UI.Page
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
                        System.Diagnostics.Debug.Write(ex.Message)
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
            chkMostrar.Checked = maquina.Mostrar
        End If

        If (maquina.Bandera = 1 Or maquina.Bandera = 0) And Not Page.IsPostBack Then
            chkActiva.Checked = True
            If maquina.Bandera = 1 Then
                chkActiva.Text = "La maquina esta siendo utilizada."
                chkActiva.Enabled = False
            End If
        ElseIf maquina.Bandera = 2 Then
            chkActiva.Checked = False
            chkActiva.Text = "Activa"
            chkActiva.Enabled = True
        End If
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Not (txtNumero.Text.Trim() = "") Then
            Dim maquina As New Maquina
            maquina.Numero = txtNumero.Text.Trim()
            maquina.Info = txtInfo.Text.Trim()
            If Not chkActiva.Enabled Then
                maquina.Bandera = 1
            Else
                If chkActiva.Checked = True Then
                    maquina.Bandera = 0
                Else
                    maquina.Bandera = 2
                End If
            End If
            maquina.Mostrar = chkMostrar.Checked

            If Request.QueryString("action") = "modify" Then
                maquina.ID = Convert.ToInt32(Request.QueryString("id"))

                If (maquina.Update(maquina.ID)) Then
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
        Else
            lblStatus.Text = "Ingrese un número de máquina"
        End If
    End Sub
    Protected Sub btnGoBack_Click(sender As Object, e As EventArgs) Handles btnGoBack.Click
        Response.Redirect("MaquinasSistema.aspx")
    End Sub
End Class