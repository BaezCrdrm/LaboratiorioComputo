<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MantMaquinas.aspx.vb" Inherits="MantMaquinas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
    <title>Mantenimiento Máquinas</title>
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
        <form id="form1" runat="server">
            <label class="lblMant">Número</label><br />
            <asp:TextBox ID="txtNumero" runat="server" /><br />        
            <label class="lblMant">Información</label><br />
            <asp:TextBox ID="txtInfo" runat="server" /><br />
            <asp:CheckBox ID="chkActiva" CssClass="lblMant" Text="Activa" AutoPostBack="true" runat="server" />
            <asp:CheckBox ID="chkMostrar" CssClass="lblMant" Text="Mostrar" AutoPostBack="true" runat="server" />

            <br /><asp:Label ID="lblStatus" runat="server" /><br />
            
            <asp:ImageButton ID="btnGoBack" ImageUrl="imagenes/left_arrow.png" 
                CssClass="goBack" runat="server" AlternateText="Regresar" 
                OnClientClick="closeTab()" ImageAlign="Top" title="Regresar" />
            <asp:Button ID="btnGuardar" Text="Guardar" runat="server" />

        </form>
    </section>
    <script src="Scripts.js"></script>
</body>
</html>
