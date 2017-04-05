<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MenuUsuario.aspx.vb" Inherits="MenuUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
    <title>Menú Usuario</title>
    <link href="Estilo/General.css" rel="stylesheet" />
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
        <h1 class="titulo_inicio">Menú usuario</h1>
        <form id="form1" runat="server">
            <div class="buttonsForm">
                <asp:Button ID="btnRegistrar" CssClass="buttons" runat="server" Text="Registrar" />
                <asp:Button ID="btnModificar" CssClass="buttons" runat="server" Text="Modificar" />             
                <%--<asp:Button ID="btnListar" CssClass="buttons" runat="server" Text="Listar" />--%>
            </div>
        </form>
    </section>
</body>
</html>
