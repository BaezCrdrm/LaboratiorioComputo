
Imports System.Data

Partial Class ListaUsuario
    Inherits System.Web.UI.Page
    Private ds As DataSet
    Private dt As DataTable
    Private dr As DataRow

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim nombre As String = txtNombre.Text.ToString().Trim().ToUpper()
        If Not nombre = "" And Not IsNumeric(nombre) Then
            cargaDatos(nombre)
        Else
            lblError.Text = "Ingrese un nombre de usuario"
        End If
    End Sub
    Protected Sub btnGoBack_Click(sender As Object, e As ImageClickEventArgs) Handles btnGoBack.Click
        Response.Redirect("MenuUsuario.aspx")
    End Sub

    Private Sub cargaDatos(ByVal nombre As String)
        Dim con As New Conexion
        'Dim query As String = String.Format("SELECT NOMBRE_USUARIO FROM USUARIOS WHERE NOMBRE_USUARIO LIKE '%{0}%'",
        '                                    nombre)

        Dim query As String = String.Format("SELECT USUARIOS.ID_USUARIO, USUARIOS.NOMBRE_USUARIO, " &
                                            "USUARIOS.NUM_CREDENCIAL, USUARIOS.FECHA_REG_USUARIO, " &
                                            "CARRERAS.DESCRIPCION, CARRERAS.ABREVIATURA FROM USUARIOS " &
                                            "INNER JOIN CARRERAS ON CARRERAS.ID_CARRERA = USUARIOS.ID_CARRERA " &
                                            "WHERE NOMBRE_USUARIO LIKE '%{0}%'", nombre)
        ds = con.GetRows(query)
        If ds.Tables.Count = 1 Then
            dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                tableUsuarios.Visible = True
                For r = 0 To dt.Rows.Count - 1
                    Dim dr As DataRow = dt.Rows(r)
                    Dim row As New TableRow
                    For c = 0 To 5
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
End Class
