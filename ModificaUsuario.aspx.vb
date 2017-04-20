
Imports System.Data

Partial Class ModificaUsuario
    Inherits System.Web.UI.Page
    Private ds As DataSet
    Private dt As DataTable
    Private dr As DataRow

    Private Sub ModificaUsuario_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim id As String = txtCredencial.Text.ToString().Trim()
        If IsNumeric(id) And Not id = "" Then
            cargaDatos(id)
        Else
            lblError.Text = "Ingrese un número de credencial válido"
        End If
    End Sub

    Private Sub cargaDatos(ByVal id As String)
        Dim con As New Conexion
        Dim query As String = String.Format("SELECT USUARIOS.ID_USUARIO, USUARIOS.NOMBRE_USUARIO, " &
                                            "USUARIOS.NUM_CREDENCIAL, USUARIOS.FECHA_REG_USUARIO, " &
                                            "CARRERAS.DESCRIPCION, CARRERAS.ABREVIATURA FROM USUARIOS " &
                                            "INNER JOIN CARRERAS ON CARRERAS.ID_CARRERA = USUARIOS.ID_CARRERA " &
                                            "WHERE USUARIOS.NUM_CREDENCIAL = '{0}'", id)
        ds = con.GetRows(query)
        If ds.Tables.Count = 1 Then
            dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                tableUsuarios.Visible = True
                For r = 0 To dt.Rows.Count - 1
                    Dim dr As DataRow = dt.Rows(r)
                    Dim row As New TableRow
                    For c = 0 To 6
                        Dim tc As New TableCell
                        Select Case c
                            Case 0
                                tc.Controls.Add(New LiteralControl(Convert.ToString(dr("ID_USUARIO"))))
                            Case 1
                                tc.Controls.Add(New LiteralControl(Convert.ToString(dr("NOMBRE_USUARIO"))))
                            Case 2
                                tc.Controls.Add(New LiteralControl(Convert.ToString(dr("NUM_CREDENCIAL"))))
                            Case 3
                                tc.Controls.Add(New LiteralControl(Convert.ToString(dr("FECHA_REG_USUARIO"))))
                            Case 4
                                tc.Controls.Add(New LiteralControl(Convert.ToString(dr("DESCRIPCION"))))
                            Case 5
                                tc.Controls.Add(New LiteralControl(Convert.ToString(dr("ABREVIATURA"))))
                            Case 6
                                Dim lbl As New Label
                                lbl.Text = "<a href='RegistroUsuario.aspx?action=modify&id=" & Convert.ToString(dr("ID_USUARIO")) & "'>Modificar</a>"
                                tc.Controls.Add(lbl)
                        End Select
                        row.Cells.Add(tc)
                    Next
                    tableUsuarios.Rows.Add(row)
                Next
            Else
                tableUsuarios.Visible = False
                lblError.Text = "No se encontró registro"
            End If
        End If
    End Sub
    Protected Sub btnGoBack_Click(sender As Object, e As ImageClickEventArgs) Handles btnGoBack.Click
        Response.Redirect("MenuUsuario.aspx")
    End Sub
End Class
