
Imports System.Data

Partial Class TiempoMaq
    Inherits System.Web.UI.Page

    Private Sub TiempoMaq_Load(sender As Object, e As EventArgs) Handles Me.Load
        cargaMaquinas()
    End Sub

    Protected Sub btnGoBack_Click(sender As Object, e As ImageClickEventArgs) Handles btnGoBack.Click
        Response.Redirect("MenuMaquina.aspx")
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
                    img.OnClientClick = "form1.target ='_self';"
                    AddHandler img.Click, AddressOf entradaMaquina_Click

                    lblMaq.Text = Convert.ToString(dr("NUMERO_MAQ"))
                    lblMaq.CssClass = "lblMaqNum"

                    Dim maqData As DataSet = verficaMaq(Convert.ToString(dr("ID_MAQUINA")))
                    Dim fecha As DateTime

                    Select Case Convert.ToInt32(dr("BANDERA_MAQ"))
                        Case 0
                            img.ImageUrl = "imagenes\machineD.png"
                            img.Enabled = False
                        Case 1
                            'img.ImageUrl = "imagenes\machineO.png"
                            If maqData.Tables.Count > 0 Then
                                Dim dataDt As DataTable = maqData.Tables(0)
                                If dataDt.Rows.Count > 0 Then
                                    Dim dataDr As DataRow = dataDt.Rows(0)
                                    fecha = Convert.ToDateTime(dataDr("HORA_ENTRADA"))

                                    Dim ts As System.TimeSpan = DateTime.Now - fecha
                                    If ts.Hours < 2 And ts.Days = 0 Then
                                        img.ImageUrl = "imagenes\machine2H.PNG"
                                    ElseIf ts.Hours < 3 And ts.Days = 0 Then
                                        img.ImageUrl = "imagenes\machine1H.PNG"
                                    ElseIf ts.Hours >= 3 Or ts.Days > 0 Then
                                        img.ImageUrl = "imagenes\machineOc.PNG"
                                    End If

                                    Dim horas As Integer = 0
                                    If ts.Days > 0 Then
                                        horas = ts.Days * 24
                                    End If
                                    horas = horas + ts.Hours

                                    Dim strInfo As String = String.Format("NOMBRE: {0}" & vbNewLine &
                                                                          "TIEMPO:   {1} HORAS {2:%m} MINUTOS",
                                                                          Convert.ToString(dataDr("NOMBRE_USUARIO")),
                                                                          horas, ts)
                                    img.ToolTip = strInfo
                                Else
                                    img.ImageUrl = "imagenes\machineD.png"
                                    img.Enabled = False
                                End If
                            End If

                            'img.Enabled = True
                            'Cambiar de ser necesario navegar a otra pagina
                            img.Enabled = False
                        Case 2
                            img.ImageUrl = "imagenes\machineN.png"
                            img.Enabled = False
                    End Select

                    tc.Controls.Add(img)
                    tc.Controls.Add(New LiteralControl("<br />"))
                    tc.Controls.Add(lblMaq)
                    row.Cells.Add(tc)

                    'Limitado a 69 equipos
                    If r = 9 Or r = 19 Or r = 29 Or r = 39 Or r = 49 Or r = 59 Then
                        Table1.Rows.Add(row)
                        row = New TableRow
                    End If
                Next
                Table1.Rows.Add(row)
            End If
        End If
    End Sub

    Private Sub entradaMaquina_Click(sender As Object, e As ImageClickEventArgs)
        'Dim btnTemp = DirectCast(sender, ImageButton)
        'If btnTemp.Enabled Then
        '    Dim tempId As String() = Split(btnTemp.ID, "_")
        '    Response.Redirect(".aspx?id=" & tempId(1))
        'End If
    End Sub

    Private Function verficaMaq(ByVal id As String) As DataSet
        Dim query As String = String.Format("SELECT MAQUINAS.ID_MAQUINA, UTILIZA.HORA_ENTRADA, " &
                                            "USUARIOS.ID_USUARIO, USUARIOS.NOMBRE_USUARIO, USUARIOS.NUM_CREDENCIAL " &
                                            "FROM UTILIZA INNER JOIN MAQUINAS ON UTILIZA.ID_MAQUINA = MAQUINAS.ID_MAQUINA " &
                                            "INNER JOIN USUARIOS ON UTILIZA.ID_USUARIO = USUARIOS.ID_USUARIO " &
                                            "WHERE MAQUINAS.ID_MAQUINA = {0} ORDER BY NUMERO_MAQ", id)
        Dim c As New Conexion
        Dim data As DataSet = c.GetRows(query)
        Return data
    End Function
End Class
