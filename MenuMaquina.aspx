<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MenuMaquina.aspx.vb" Inherits="MenuMaquina" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
    <title>Acceso a laboratorio</title>
    <link href="Estilo/General.css" rel="stylesheet" />
    <link href="Estilo/" rel="stylesheet" />
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
        <h1 class="titulo_inicio">Acceso a laboratorio</h1>
        <form id="form1" runat="server">
            <div class="buttonsForm">
                <asp:Button ID="btnEntrada" CssClass="buttons" runat="server" Text="Entrada máquina" />
                <asp:Button ID="btnSalida" CssClass="buttons" runat="server" Text="Salida máquina" />             
                <asp:Button ID="btnListar" CssClass="buttons" runat="server" Text="Tiempo máquina" />
            </div>

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
