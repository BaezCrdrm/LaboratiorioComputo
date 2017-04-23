
Imports System.Data

Partial Class RegistroUsuario
    Inherits System.Web.UI.Page
    Dim regresaAEntradaMaq As Boolean
    Private ds As DataSet
    Private dr As DataRow
    Private dt As DataTable
    Private reg As Boolean = True

    Shared uNombre As String
    Shared uCredencial As String
    Shared uCarrera As Integer

    Private Sub RegistroUsuario_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim con As New Conexion
            If con.TestConnection = False Then
                ScriptManager.RegisterStartupScript(Me, Page.GetType, "script",
                                                    String.Format("connectionFailed('{0}', '{1}');",
                                                                  "MenuUsuario.aspx",
                                                                  "No se pudo conectar con la base de datos"), True)
            Else
                cargaCarreras()

            End If
        End If
        lblError.Text = ""
        Try
            If (Request.QueryString("retorno").ToString().Trim() = "true") Then
                regresaAEntradaMaq = True
            Else
                regresaAEntradaMaq = False
            End If
        Catch ex As Exception
            regresaAEntradaMaq = False
        End Try

        Try
            If Request.QueryString("action") = "modify" Then
                lblTitulo.Text = "Modificar"
                reg = False

                If Not Page.IsPostBack Then
                    cargaDatosUsuario(Request.QueryString("id").ToString().Trim())

                End If
            Else

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cargaCarreras()
        Dim con As New Conexion
        Dim query As String = "SELECT ID_CARRERA, DESCRIPCION FROM CARRERAS ORDER BY DESCRIPCION"

        ddlCarreras.Items.Clear()
        ddlCarreras.DataSource = con.GetRows(query)
        ddlCarreras.DataTextField = "DESCRIPCION"
        ddlCarreras.DataValueField = "ID_CARRERA"
        ddlCarreras.DataBind()
    End Sub

    Private Function validaUsuario(ByVal numCredencial As String) As Boolean
        Dim con As New Conexion
        Dim query As String = String.Format("SELECT * FROM USUARIOS WHERE NUM_CREDENCIAL = '{0}'",
                                            numCredencial)
        ds = con.GetRows(query)
        If ds.Tables.Count = 1 Then
            dt = ds.Tables(0)
            If dt.Rows.Count = 0 Then
                lblError.Visible = False
                Return True
            Else
                lblError.Visible = True
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Private Sub cargaDatosUsuario(ByVal id As String)
        Dim con As New Conexion
        Dim query As String = String.Format("SELECT USUARIOS.ID_USUARIO, USUARIOS.NOMBRE_USUARIO, USUARIOS.NUM_CREDENCIAL, " &
                                            "CARRERAS.ID_CARRERA, CARRERAS.DESCRIPCION FROM USUARIOS " &
                                            "INNER JOIN CARRERAS ON CARRERAS.ID_CARRERA = USUARIOS.ID_CARRERA WHERE ID_USUARIO = {0}", id)

        ds = con.GetRows(query)
        If ds.Tables.Count = 1 Then
            dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                Dim dr As DataRow = dt.Rows(0)
                txtNombre.Text = Convert.ToString(dr("NOMBRE_USUARIO"))
                txtCredencial.Text = Convert.ToString(dr("NUM_CREDENCIAL"))
                Dim strCarrera = Convert.ToString(dr("DESCRIPCION"))

                For i = 0 To ddlCarreras.Items.Count - 1
                    ddlCarreras.SelectedIndex = i
                    If strCarrera = ddlCarreras.SelectedItem.Text.ToString() Then
                        Return
                    End If
                Next
            End If
        End If
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim carrera As New Carrera
        Dim usr As New Usuario
        Dim strCredencial As String = txtCredencial.Text.ToString().Trim().ToUpper()
        Dim strNombre As String = txtNombre.Text.ToString().Trim().ToUpper()

        If (Not strCredencial = "") And (Not strNombre = "") And IsNumeric(strCredencial) Then
            Dim insertUsuarioValido As Boolean
            If reg = True Then
                insertUsuarioValido = validaUsuario(strCredencial)
            Else
                insertUsuarioValido = True
            End If

            If insertUsuarioValido Then
                If reg = False Then
                    usr.IDUsuario = Request.QueryString("id").ToString().Trim()
                End If
                usr.NombreUsuario = strNombre
                usr.CredencialUsuario = strCredencial
                usr.FechaRegistro = DateTime.Now
                usr.Carrera.ID = Convert.ToInt32(ddlCarreras.SelectedValue.ToString())

                If (reg = True) Then
                    If (usr.Insert()) Then
                        Dim msg As String = "Se agregó al usuario exitosamente"
                        ScriptManager.RegisterStartupScript(Me, Page.GetType, "script",
                                                        String.Format("usuarioAgregado('{0}', '{1}');",
                                                                      "true", msg), True)
                        'If regresaAEntradaMaq = True Then
                        '    Response.Redirect("EntradaMaq.aspx")
                        'Else
                        '    Response.Redirect("MenuUsuario.aspx")
                        'End If
                    End If
                Else
                    If usr.Update() Then
                        lblError.Text = "Se ha actualizado correctamente"
                        ScriptManager.RegisterStartupScript(Me, Page.GetType, "script",
                                                        String.Format("alertMessages('{0}');",
                                                                      "El usuario fue modificado"), True)
                        btnGoBack.Text = "Regresar"
                    End If
                End If
            Else
                    lblError.Text = "El usuario ya se encuentra registrado"
            End If

        Else
            If strCredencial = "" Or Not (IsNumeric(strCredencial)) Then
                lblError.Text = "Numero de credencial no valido"
            ElseIf strNombre = "" Then
                lblError.Text = "Ingresa un nombre de usuario"
            End If
        End If
    End Sub
    Protected Sub btnGoBack_Click(sender As Object, e As EventArgs) Handles btnGoBack.Click
        Try
            If (Request.QueryString("action") = "modify") Then
                Response.Redirect("ModificaUsuario.aspx")
            End If
        Catch ex As Exception

        End Try
        Response.Redirect("MenuUsuario.aspx")
    End Sub
    Protected Sub txtCredencial_TextChanged(sender As Object, e As EventArgs) Handles txtCredencial.TextChanged
        uCredencial = txtCredencial.Text
    End Sub
    Protected Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        uNombre = txtNombre.Text
    End Sub
End Class
