Imports System.Data

Partial Class NavegaEntrada
    Inherits System.Web.UI.Page
    Private con As Conexion
    Private ds As DataSet
    Private dr As DataRow
    Private dt As DataTable
    Private usuario As Usuario
    Dim fecha As Date

    Private Sub NavegaEntrada_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim cuenta As String = Request.QueryString("credencial").ToString().Trim()
            'Verificar estado (ocupado/desocupado) de maquina
            If verificaDisp(Integer.Parse(Request.QueryString("id").ToString().Trim())) Then
                'Verificar alta del usuario
                If validaUsuario(cuenta) Then
                    'Cargar datos del usuario y de máquina
                    usuario = New Usuario
                    usuario = cargaDatosUsuario(cuenta)
                    fecha = Date.Now
                    lblCredencial.Text = cuenta
                    lblNombre.Text = usuario.NombreUsuario
                    lblMaquina.Text = Request.QueryString("maq").ToString().Trim()
                    If validaUsuMaq(cuenta) Then
                        lblFecha.Text = fecha.Date.ToLongDateString()
                        lblEntrada.Text = fecha.ToString("HH:mm:ss")
                    Else
                        Dim msg As String = "El usuario " & usuario.NombreUsuario & " ya ocupa una máquina"
                        lblError.Text = msg
                        btnAdd.Enabled = False
                        ScriptManager.RegisterStartupScript(Me, Page.GetType, "script",
                                                            "alertMaquinaUtilizada('" & msg & "');", True)
                    End If
                Else
                    ScriptManager.RegisterStartupScript(Me, Page.GetType, "script", "alertaErrorUsuario();", True)
                End If
            Else
                Response.Redirect("EntradaMaq.aspx")
            End If
        Catch ex As Exception
            Response.Redirect("EntradaMaq.aspx")
            System.Diagnostics.Debug.Write(ex.Message)
        End Try
    End Sub

    Private Function verificaDisp(ByVal id As Integer) As Boolean
        Dim con As New Conexion
        Dim query As String = "SELECT * FROM UTILIZA WHERE ID_USUARIO = " & id.ToString()
        ds = con.GetRows(query)
        If ds.Tables.Count = 1 Then
            dt = ds.Tables(0)
            If dt.Rows.Count = 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function

    Private Function validaUsuario(ByVal numCredencial As String) As Boolean
        Dim con As New Conexion
        Dim query As String = "SELECT * FROM USUARIOS WHERE NUM_CREDENCIAL = '" & numCredencial & "'"
        ds = con.GetRows(query)
        If ds.Tables.Count = 1 Then
            dt = ds.Tables(0)
            If dt.Rows.Count = 0 Then
                lblError.Visible = True
                Return False
            Else
                lblError.Visible = False
                Return True
            End If
        Else
            Return False
        End If
    End Function

    Private Function validaUsuMaq(credencial As String) As Boolean
        Dim con As New Conexion
        Dim query As String = String.Format("SELECT USUARIOS.ID_USUARIO, UTILIZA.ID_MAQUINA " &
                                            "FROM USUARIOS INNER JOIN UTILIZA " &
                                            "ON UTILIZA.ID_USUARIO=USUARIOS.ID_USUARIO " &
                                            "WHERE USUARIOS.NUM_CREDENCIAL={0}", credencial)
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
            Return True
        End If
    End Function

    Private Function cargaDatosUsuario(ByVal numCredencial As String) As Usuario
        Dim con As New Conexion
        Dim usr As New Usuario
        Dim query As String = "SELECT ID_USUARIO, NOMBRE_USUARIO, NUM_CREDENCIAL FROM USUARIOS WHERE NUM_CREDENCIAL = '" & numCredencial & "'"
        ds = con.GetRows(query)
        If ds.Tables.Count = 1 Then
            dt = ds.Tables(0)
            If dt.Rows.Count = 0 Then
                lblError.Visible = True
                Return Nothing
            Else
                lblError.Visible = False
                Dim dr As DataRow = dt.Rows(0)
                usr.CredencialUsuario = numCredencial
                usr.NombreUsuario = dr("NOMBRE_USUARIO")
                usr.IDUsuario = dr("ID_USUARIO")
                Return usr
            End If
        Else
            Return Nothing
        End If
    End Function

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Dim con As New Conexion
            Dim query As String = "UPDATE MAQUINAS SET BANDERA_MAQ = 1 WHERE ID_MAQUINA = '" & Request.QueryString("id").ToString().Trim() & "'"
            con.ExecuteQuery(query)

            query = String.Format("INSERT INTO UTILIZA (ID_USUARIO, ID_MAQUINA, HORA_ENTRADA) VALUES ({0}, {1}, '{2}')",
                              usuario.IDUsuario, Integer.Parse(Request.QueryString("id").ToString().Trim()), fecha.ToString("dd/MM/yyyy HHH:mm:ss"))
            con.ExecuteQuery(query)
            Response.Redirect("EntradaMaq.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnGoBack_Click(sender As Object, e As EventArgs) Handles btnGoBack.Click
        Response.Redirect("EntradaMaq.aspx")
    End Sub
End Class