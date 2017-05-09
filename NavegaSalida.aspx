<%@ Page Language="VB" AutoEventWireup="false" CodeFile="NavegaSalida.aspx.vb" Inherits="NavegaSalida" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
    <title>Salida Máquina</title>
    <link href="Estilo/General.css" rel="stylesheet" />
    <style>
        #tbEntrada, #divButtons {
            margin-left: auto;
            margin-right: auto;
        }

            #tbEntrada td{
                padding-top:5px;
            }

                .lblInfo {
                    font-weight: bold;
                    margin-right: 10px;
                }

                .lblDatos {
                    margin-left: 10px;
                }

        #divButtons {
            width: 380px;
            margin-top: 30px;
        }

            #btnGoBack {
                float:right;
            }

            #btnAdd {
                float:left;
            }
    </style>

    <script src="Scripts.js" type="text/javascript"></script>
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
        <h1 class="titulo_inicio">Salida máquina</h1>
        <form id="form1" runat="server">
            <table id="tbEntrada">
                <tr>
                    <td>
                        <asp:Label ID="lblError" Text="" runat="server" />
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <label class="lblInfo">Nombre</label>
                    </td>
                    <td>
                        <asp:Label ID="lblNombre" CssClass="lblDatos" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label class="lblInfo">Numero de credencial</label>
                    </td>
                    <td>
                        <asp:Label ID="lblCredencial" CssClass="lblDatos" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label class="lblInfo">Hora de entrada</label>
                    </td>
                    <td>
                        <asp:Label ID="lblEntrada" CssClass="lblDatos" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label class="lblInfo">Hora de salida</label>
                    </td>
                    <td>
                        <asp:Label ID="lblSalida" CssClass="lblDatos" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label class="lblInfo">Tiempo total</label>
                    </td>
                    <td>
                        <asp:Label ID="lblTiempo" CssClass="lblDatos" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label class="lblInfo">Maquina</label>
                    </td>
                    <td>
                        <asp:Label ID="lblMaquina" CssClass="lblDatos" Text="" runat="server" />
                    </td>
                </tr>
            </table>

            <div id="divButtons">
                <asp:Button ID="btnGoBack" CssClass="formButton" runat="server" 
                AlternateText="Regresar" Text="Cancelar" />
                <asp:Button ID="btnAdd" CssClass="formButton" Text="Aceptar" runat="server" />
            </div>
        </form>
    </section>
</body>
</html>