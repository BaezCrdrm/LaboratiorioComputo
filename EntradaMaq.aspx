﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EntradaMaq.aspx.vb" Inherits="EntradaMaq" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
    <title>Entrada de Máquinas</title>
    <link href="Estilo/General.css" rel="stylesheet" />
    <link href="Estilo/MaquinasSistema.css" rel="stylesheet" />
    <link href="Estilo/Tables.css" rel="stylesheet" />

    <style type="text/css">
        /***En esta sección se encuentra el estilo aplicado ÚNICAMENTE a esta página.***/
        /***El estilo compartido se encuentra en otros archivos CSS***/

        /*Barra de estado*/
        #divEstados, #divCredencial  {
            width: 380px;
            margin-left:auto;
            margin-right:auto;
        }

        #divCredencial {
            margin-top: 20px;
        }

            #divCredencial > label {
                width: auto;
                float:left;
                font-weight: bold;   
            }

            #txtNumUsuario {
                width: 190px;
                float: right;
            }

        #listaEstados li{
            display:inline-block;
        }

            .divMaquina {
                width:90px;
            }

                .divMaquina img {
                    width:auto;
                    height:35px;
                    margin-left:25px;
                }

        .divMaquina h4 {
            text-align:center;
            margin-bottom:10px;
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
        <h2 class="titulo_pagina">Entrada de Máquinas</h2>
        
        <form id="form1" runat="server">
            <div id="divCredencial">
                <label>Número de credencial</label>
                <asp:TextBox ID="txtNumUsuario" runat="server" /><br />
                <asp:Label ID="lblNomlabel" runat="server" />
            </div><br />

            <div id="divEstados">            
            <ul id="listaEstados">
                <li>
                    <div class="divMaquina">
                        <h3>Estado:</h3>
                    </div> 
                </li>
                <li>
                    <div class="divMaquina">
                        <img src="imagenes/machineD.PNG" alt="Estado: Libre" /><br />
                        <h4>Libre</h4>
                    </div> 
                </li>
                <li>       
                    <div class="divMaquina">
                        <img src="imagenes/machineO.PNG" alt="Estado: Ocupada" /><br />
                        <h4>Ocupada</h4>
                    </div>
                </li>
                <li>
                    <div class="divMaquina">
                        <img src="imagenes/machineN.PNG" alt="Estado: Inhabilitada" /><br />
                        <h4>Inhabilitada</h4>
                    </div>
                </li>
            </ul>
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
