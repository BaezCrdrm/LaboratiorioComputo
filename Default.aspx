﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
    <title>LABCOMP</title>
    <link href="Estilo/General.css" rel="stylesheet" />
    <link href="Estilo/Default.css" rel="stylesheet" />
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
        <form id="form1" runat="server">
            <div class="buttonsForm">
                <asp:Button ID="btnUsuarios" CssClass="buttons" runat="server" Text="Usuarios" />
                <asp:Button ID="btnAcceso" CssClass="buttons" runat="server" Text="Acceso a laboratorio" />
                <asp:Button ID="btnAdmSistema" CssClass="buttons" runat="server" Text="Administración sistema" />                
            </div>
        </form>
    </section>
</body>
</html>
