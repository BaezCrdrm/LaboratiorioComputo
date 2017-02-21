
Imports System.Data

Partial Class CarrerasSistema
    Inherits System.Web.UI.Page
    Private ds As DataSet
    Private dt As DataTable
    Private query As String

    Private Sub CarrerasSistema_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("ACTIVE_SESSION") = False Then
            'Inicio de sesión fallido
            Response.Redirect("Login.aspx?status=loginerror")
        Else
            'Inicio de sesión exitoso
            cargaCarreras()
        End If
    End Sub

    Private Sub cargaCarreras()
        Dim tabla As String = ""
        Dim con As New Conexion
        query = "SELECT ID_CARRERA, DESCRIPCION, ABREVIATURA FROM CARRERAS ORDER BY DESCRIPCION"
        ds = con.GetRows(query)
        If ds.Tables.Count = 1 Then
            dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                For r = 0 To dt.Rows.Count - 1
                    Dim dr As DataRow = dt.Rows(r)
                    Dim row As New TableRow
                    For c = 0 To 2
                        Dim tc As New TableCell
                        Select Case c
                            Case 0
                                tc.Controls.Add(New LiteralControl(Convert.ToString(dr("DESCRIPCION"))))
                            Case 1
                                tc.Controls.Add(New LiteralControl(Convert.ToString(dr("ABREVIATURA"))))
                            Case 2
                                Dim bt As New System.Web.UI.WebControls.Button
                                bt.ID = "btn_" & Convert.ToString(dr("ID_CARRERA"))
                                bt.Text = "Modificar"
                                bt.CssClass = "btn_tabla_ver"
                                bt.OnClientClick = "form1.target ='_blank';"
                                AddHandler bt.Click, AddressOf ButtonVer_Click
                                tc.Controls.Add(bt)
                        End Select

                        row.Cells.Add(tc)
                    Next
                    Table1.Rows.Add(row)
                Next
            End If
        End If
    End Sub
    Protected Sub ButtonVer_Click(sender As Object, e As EventArgs)
        Dim bt As Button = DirectCast(sender, Button)
        Dim arrayId() As String = Split(bt.ID, "_")
        Dim id As String = arrayId(1)

        Response.Redirect("MantCarreras.aspx?action=modify&id=" & id)
    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs)
        Response.Redirect("MantCarreras.aspx?action=create")
    End Sub

    Protected Sub btnGoBack_Click(sender As Object, e As ImageClickEventArgs) Handles btnGoBack.Click
        Response.Redirect("MenuAdministrador.aspx")
    End Sub
End Class
