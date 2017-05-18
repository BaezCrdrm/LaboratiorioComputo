<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
    <title>Login</title>
    <link href="Estilo/General.css" rel="stylesheet" />
    <style type="text/css">
        .log {
            width:180px;
            margin-left:auto;
            margin-right:auto;
            margin-top: 50px;
        }
            .caja {
                width:180px;
            }

            #btnAccept {
                width: 80px;
                height: 30px;
                margin-top: 15px;

                font-weight:bold;
                float:right;
            }

            #lblError {
                color: red;
                clear:both;
            }
    </style>

    <script src="Scripts.js"></script>
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
        <form id="form1" runat="server">
            <div class="log">
                <label for="txtUsuario">Usuario</label><br />
                <asp:TextBox ID="txtUsuario" CssClass="caja" runat="server" /><br />
                <label for="txtPass">Contraseña</label><br />
                <asp:TextBox ID="txtPass" CssClass="caja" runat="server" TextMode="Password" /><br />
                <asp:Button ID="btnAccept" runat="server" Text="Acceder" /><br />
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>

                <div ID="divGoToMenu">
                <asp:ImageButton ID="btnGoBack" ImageUrl="imagenes/left_arrow.png" 
                    CssClass="goBack" runat="server" AlternateText="Regresar" 
                    ImageAlign="Top" title="Menú administrador" OnClientClick="form1.target ='_self';"/>
                <%--<asp:Label Text="Menú" CssClass="lblGoToMenu" runat="server" />   --%>             
            </div>
            </div>
        </form>
    </section>
</body>
</html>
