<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MaquinasSistema.aspx.vb" Inherits="MaquinasSistema" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
    <title>Máquinas sistema</title>
    <link href="Estilo/General.css" rel="stylesheet" />
    <link href="Estilo/MaquinasSistema.css" rel="stylesheet" />
    <link href="Estilo/Tables.css" rel="stylesheet" />

    <style type="text/css">
        #divButton {
            width:370px;
            margin-left:auto;
            margin-right:auto;
            margin-top:15px;
            margin-bottom:20px;
        }
    </style>
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
        <h2 class="titulo_pagina">Máquinas sistema</h2>
        <form id="form1" runat="server">
            <div id="divButton">
                <asp:Button ID="btnNuevo" Text="Nueva maquina" runat="server" 
                    OnClick="btnNuevo_Click" OnClientClick="form1.target ='_self';"/>
            </div>
            <asp:Table ID="Table1" runat="server"></asp:Table>

            <br />
            <div ID="divGoToMenu">
                <asp:ImageButton ID="btnGoBack" ImageUrl="imagenes/left_arrow.png" 
                    CssClass="goBack" runat="server" AlternateText="Regresar" 
                    ImageAlign="Top" title="Menú administrador" OnClientClick="form1.target ='_self';"/>
                <%--<asp:Label Text="Menú" CssClass="lblGoToMenu" runat="server" />   --%>             
            </div>
        </form>        
    </section>
</body>
</html>
