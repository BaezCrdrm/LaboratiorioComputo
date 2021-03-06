﻿Imports System.Data

Partial Class EntradaMaq
    Inherits System.Web.UI.Page

    Private Sub EntradaMaq_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim con As New Conexion
        If con.TestConnection = False Then
            txtNumUsuario.Enabled = False
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "script",
                                                    String.Format("connectionFailed('{0}', '{1}');",
                                                                  "MenuMaquina.aspx",
                                                                  "No se pudo conectar con la base de datos"), True)
        Else
            cargaMaquinas()
        End If
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

                    Select Case Convert.ToInt32(dr("BANDERA_MAQ"))
                        Case 0
                            img.ImageUrl = "imagenes\machineD.png"
                            img.Enabled = True
                        Case 1
                            img.ImageUrl = "imagenes\machineO.png"
                            img.Enabled = False
                        Case 2
                            img.ImageUrl = "imagenes\machineN.png"
                            img.Enabled = False
                    End Select

                    img.AlternateText = Convert.ToString(dr("NUMERO_MAQ"))
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

    Protected Sub entradaMaquina_Click(sender As Object, e As ImageClickEventArgs)
        Dim btnTemp = DirectCast(sender, ImageButton)
        If btnTemp.Enabled Then
            If Not txtNumUsuario.Text.Trim() = "" And txtNumUsuario.Text.Count > 8 And IsNumeric(txtNumUsuario.Text.Trim()) Then
                'If Not txtNumUsuario.Text.Trim = "" And IsNumeric(txtNumUsuario.Text.Trim()) Then
                Dim tempId As String() = Split(btnTemp.ID, "_")
                Response.Redirect("NavegaEntrada.aspx?id=" & tempId(1) & "&credencial=" & txtNumUsuario.Text.Trim & "&maq=" & btnTemp.AlternateText.ToString())
            Else
                lblNomlabel.Text = "Escriba un número de credencial válido"
            End If
        End If
    End Sub

    Protected Sub btnGoBack_Click(sender As Object, e As ImageClickEventArgs) Handles btnGoBack.Click
        Response.Redirect("MenuMaquina.aspx")
    End Sub
End Class
