﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MantCarreras.aspx.vb" Inherits="MantCarreras" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
    <title>Mantenimiento carreras</title>
    <link href="Estilo/General.css" rel="stylesheet" />
    <link href="Estilo/Mantenimiento.css" rel="stylesheet" />
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
        <h2 class="titulo_pagina">Mantenimiento carreras</h2>

        <form id="form1" runat="server">
            <label class="lblMant">Nombre</label><br />
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox><br />
            <label class="lblMant">Abreviatura</label><br />
            <asp:TextBox ID="txtAbv" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblStatus" runat="server"></asp:Label><br />
            <asp:Button ID="btnGuardar" CssClass="formButton" runat="server" Text="Agregar" />
            <asp:Button ID="btnGoBack" CssClass="formButton" runat="server" 
                AlternateText="Regresar" Text="Cancelar" />
        </form>        
    </section>

    <script src="Scripts.js"></script>
</body>
</html>
