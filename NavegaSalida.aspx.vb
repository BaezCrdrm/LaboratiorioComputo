
Imports System.Data
Imports System.Globalization

Partial Class NavegaSalida
    Inherits System.Web.UI.Page
    Private con As Conexion
    Private ds As DataSet
    Private dr As DataRow
    Private dt As DataTable
    Private usuario As Usuario
    Private fechaEntrada As DateTime
    Private maquina As Maquina

    Private Sub NavegaSalida_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If getData() Then
                lblCredencial.Text = usuario.CredencialUsuario
                lblNombre.Text = usuario.NombreUsuario
                lblFecha.Text = fechaEntrada.ToString("dd MMMM yyyy")
                lblEntrada.Text = fechaEntrada.ToShortTimeString()
                lblMaquina.Text = maquina.Numero
            Else
                Response.Redirect("SalidaMaquina.aspx")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function getData() As Boolean
        Dim con As New Conexion
        Dim query As String = String.Format("SELECT UTILIZA.ID_UTILIZA, UTILIZA.ID_USUARIO, UTILIZA.ID_MAQUINA, " &
                                            "USUARIOS.NUM_CREDENCIAL, USUARIOS.NOMBRE_USUARIO, UTILIZA.HORA_ENTRADA, " &
                                            "MAQUINAS.NUMERO_MAQ FROM UTILIZA " &
                                            "INNER JOIN MAQUINAS ON MAQUINAS.ID_MAQUINA = UTILIZA.ID_MAQUINA " &
                                            "AND UTILIZA.ID_MAQUINA = {0} INNER JOIN USUARIOS ON USUARIOS.ID_USUARIO = UTILIZA.ID_USUARIO",
                                            Request.QueryString("id").ToString().Trim())
        ds = con.GetRows(query)
        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)
            If dt.Rows.Count = 0 Then
                Return False
            Else
                Dim dr As DataRow = dt.Rows(0)
                Try
                    usuario = New Usuario()
                    maquina = New Maquina()
                    usuario.IDUsuario = Int32.Parse(dr("ID_USUARIO").ToString())
                    usuario.NombreUsuario = dr("NOMBRE_USUARIO")
                    usuario.CredencialUsuario = dr("NUM_CREDENCIAL")
                    Dim culture As New CultureInfo("es-MX")
                    fechaEntrada = Convert.ToDateTime(dr("HORA_ENTRADA"), culture)
                    maquina.ID = Int32.Parse(Request.QueryString("id").ToString().Trim())
                    maquina.Numero = dr("NUMERO_MAQ")
                    Return True
                Catch ex As Exception
                    System.Diagnostics.Debug.Write("Error en getData(): " & ex.Message)
                End Try
            End If
        End If
        Return False
    End Function

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Dim con As New Conexion
            Dim id As String = Request.QueryString("id").ToString().Trim()
            Dim query As String = "UPDATE MAQUINAS SET BANDERA_MAQ = 0 WHERE ID_MAQUINA = '" & id & "'"
            con.ExecuteQuery(query)

            query = String.Format("DELETE FROM UTILIZA WHERE ID_MAQUINA = {0}",
                                  id)
            con.ExecuteQuery(query)
            Response.Redirect("SalidaMaquina.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnGoBack_Click(sender As Object, e As EventArgs) Handles btnGoBack.Click
        Response.Redirect("SalidaMaquina.aspx")
    End Sub
End Class
