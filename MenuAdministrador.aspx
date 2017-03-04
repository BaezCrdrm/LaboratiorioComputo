<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MenuAdministrador.aspx.vb" Inherits="MenuAdministrador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
    <title>Menú Administrador</title>
    <link href="Estilo/General.css" rel="stylesheet" />
    <link href="Estilo/Login.css" rel="stylesheet" />
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
        <h2 class="titulo_pagina">Administración del sistema</h2>
        <form id="form1" class="log" runat="server">
            <asp:Button ID="btnCarreras" CssClass="buttons" runat="server" Text="Carreras" OnClick="btnCarreras_Click" /><br />
            <asp:Button ID="btnMaquinas" CssClass="buttons" runat="server" Text="Máquinas" OnClick="btnMaquinas_Click"/>

            <div ID="divGoToMenu">
                <asp:ImageButton ID="btnGoBack" ImageUrl="imagenes/left_arrow.png" 
                    CssClass="goBack" runat="server" AlternateText="Regresar" 
                    ImageAlign="Top" title="Salir" OnClientClick="form1.target ='_self';"/>
                <asp:Label Text="Salir" CssClass="lblGoToMenu" runat="server" />                
            </div>
        </form>
    </section>
</body>
</html>
