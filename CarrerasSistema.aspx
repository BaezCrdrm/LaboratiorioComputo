<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CarrerasSistema.aspx.vb" Inherits="CarrerasSistema" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
    <title>Carreras</title>
    <link href="Estilo/General.css" rel="stylesheet" />
    <link href="Estilo/CarrerasSistema.css" rel="stylesheet" />
</head>
<body>
    <header>
        <asp:Image CssClass="imagen_portada" ImageUrl="imagenes/unam_negro.png" runat="server" />

        <div>
            <h1>Universidad Nacional Autónoma de México</h1>
            <h2>Facultad de Estudios Superiores Cuautitlán</h2>
        </div>
    </header>

    <section id="principal">
        <h1 class="titulo_inicio">Laboratorio de Cómputo</h1>
        <h2 class="titulo_pagina">Carreras del sistema</h2>

        <form id="form1" runat="server">
            <asp:Button ID="btnNuevo" Text="Nueva carrera" runat="server" 
                OnClick="btnNuevo_Click" OnClientClick="form1.target ='_self';"/>
            <asp:Table ID="Table1" runat="server">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" CssClass="table_header">Nombre</asp:TableCell>
                    <asp:TableCell runat="server" CssClass="table_header">Abreviatura</asp:TableCell>
                    <asp:TableCell runat="server" CssClass="table_header"></asp:TableCell>
                </asp:TableRow>
            </asp:Table>

            <br />
            <div ID="divGoToMenu">
                <asp:ImageButton ID="btnGoBack" ImageUrl="imagenes/left_arrow.png" 
                        CssClass="goBack" runat="server" AlternateText="Regresar" 
                        ImageAlign="Top" title="Menú administrador" OnClientClick="form1.target ='_self';"/>
                <%--<asp:Label Text="Menú" CssClass="lblGoToMenu" runat="server" /> --%>               
            </div>
        </form>
    </section>
</body>
</html>
