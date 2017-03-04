<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EntradaMaq.aspx.vb" Inherits="EntradaMaq" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
    <title>Entrada de Máquinas</title>
    <link href="Estilo/General.css" rel="stylesheet" />
    <link href="Estilo/MaquinasSistema.css" rel="stylesheet" />
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
        <h2 class="titulo_pagina">Entrada de Máquinas</h2>
        
        <div>
            <h3>Estado</h3>
            <ul>
                <li>
                    <div>
                        <img src="imagenes/machineD.PNG" alt="Estado: Libre" />
                        <label>Libre</label>
                    </div> 
                </li>
                <li>       
                    <div>
                        <img src="imagenes/machineO.PNG" alt="Estado: Ocupada" />
                        <label>Ocupada</label>
                    </div>
                </li>
                <li>
                    <div>
                        <img src="imagenes/machineN.PNG" alt="Estado: Inhabilitada" />
                        <label>Inhabilitada</label>
                    </div>
                </li>
            </ul>
        </div>
        <form id="form1" runat="server">
            <div>
                <label>Número de credencial</label><br />
                <asp:TextBox ID="txtNumUsuario" runat="server" />
            </div><br />
            <asp:Label ID="lblNomlabel" runat="server" />
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
