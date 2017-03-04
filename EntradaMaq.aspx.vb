
Imports System.Data

Partial Class EntradaMaq
    Inherits System.Web.UI.Page

    Private Sub EntradaMaq_Load(sender As Object, e As EventArgs) Handles Me.Load
        cargaMaquinas()
    End Sub

    Private Sub cargaMaquinas()
        Dim con As New Conexion
        Dim query As String = "SELECT ID_MAQUINA, NUMERO_MAQ, INFORMACION_MAQ, BANDERA_MAQ, MOSTRAR_MAQ FROM MAQUINAS WHERE MOSTRAR_MAQ = 1 ORDER BY NUMERO_MAQ"
        Dim ds As DataSet = con.GetRows(query)
        Dim dt As DataTable

        If ds.Tables.Count = 1 Then
            dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                Dim row As New TableRow
                For r = 0 To dt.Rows.Count - 1
                    Dim dr As DataRow = dt.Rows(r)
                    Dim tc As New TableCell
                    Dim img As New System.Web.UI.WebControls.ImageButton
                    Dim lblMaq As New System.Web.UI.WebControls.Label
                    img.ID = "img_" & Convert.ToString(dr("ID_MAQUINA"))
                    img.CssClass = "maquina"
                    'img.OnClientClick = "MantMaquinas.aspx?id=" & Convert.ToString(dr("ID_MAQUINA"))
                    img.OnClientClick = "form1.target ='_blank';"
                    AddHandler img.Click, AddressOf entradaMaquina_Click

                    lblMaq.Text = Convert.ToString(dr("NUMERO_MAQ"))

                    img.Enabled = True
                    Select Case Convert.ToInt32(dr("BANDERA_MAQ"))
                        Case 0
                            img.ImageUrl = "imagenes\machineD.png"
                        Case 1
                            img.ImageUrl = "imagenes\machineO.png"
                        Case 2
                            img.ImageUrl = "imagenes\machineN.png"
                            img.Enabled = False
                    End Select

                    tc.Controls.Add(img)
                    tc.Controls.Add(lblMaq)
                    row.Cells.Add(tc)

                    If r = 9 Or r = 19 Or r = 29 Or r = 39 Or r = 49 Or r = 59 Then
                        Table1.Rows.Add(row)
                        row = New TableRow
                    End If
                Next
                Table1.Rows.Add(row)
            End If
        End If
    End Sub

    Protected Sub entradaMaquina_Click(sender As Object, e As ImageClickEventArgs)
        Dim tempId As String() = Split((DirectCast(sender, ImageButton)).ID, "_")
        Response.Redirect("NavegaEntrada.aspx?id=" & tempId(1))
    End Sub

    Protected Sub btnGoBack_Click(sender As Object, e As ImageClickEventArgs) Handles btnGoBack.Click
        Response.Redirect("MenuMaquina.aspx")
    End Sub
End Class
