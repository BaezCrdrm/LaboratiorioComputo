<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ModificaUsuario.aspx.vb" Inherits="ModificaUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Modificar usuario</title>
    <link href="Estilo/General.css" rel="stylesheet" />
    <link href="Estilo/Tables.css" rel="stylesheet" />
    <link href="Estilo/ListarUsuarios.css" rel="stylesheet" />
    <script type="text/javascript">
        function navigateToPage(page) {
            alert("Correcto");
            window.location.replace = page;
        }
    </script>
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
        <h2 class="titulo_pagina">Modificar usuario</h2>
        
        <form id="form1" runat="server">
            <div class="divData">
                <label for="txtCredencial">Número de credencial</label>
                <asp:TextBox ID="txtCredencial" CssClass="txtData" runat="server" />
                <asp:Button ID="btnBuscar" Text="Buscar" runat="server" /><br />
                <asp:Label ID="lblError" Text="" runat="server" />
            </div>

            <asp:Table ID="tableUsuarios" Visible="false" runat="server">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" CssClass="table_header">ID de usuario</asp:TableCell>
                    <asp:TableCell runat="server" CssClass="table_header">Nombre</asp:TableCell>
                    <asp:TableCell runat="server" CssClass="table_header">Credencial</asp:TableCell>
                    <asp:TableCell runat="server" CssClass="table_header">Fecha</asp:TableCell>
                    <asp:TableCell runat="server" CssClass="table_header">Carrera</asp:TableCell>
                    <asp:TableCell runat="server" CssClass="table_header">Abreviatura</asp:TableCell>
                    <asp:TableCell runat="server" CssClass="table_header"></asp:TableCell>
                </asp:TableRow>
            </asp:Table> 

            <div ID="divGoToMenu">
                <asp:ImageButton ID="btnGoBack" ImageUrl="imagenes/left_arrow.png" 
                    CssClass="goBack" runat="server" AlternateText="Regresar" 
                    ImageAlign="Top" title="Salir" OnClientClick="form1.target ='_self';"/>
                <%--<asp:Label Text="Salir" CssClass="lblGoToMenu" runat="server" />--%>                
            </div>
        </form>      
    </section>
</body>
</html>
