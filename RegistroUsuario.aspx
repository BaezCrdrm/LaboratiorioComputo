<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RegistroUsuario.aspx.vb" Inherits="RegistroUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
    <title>Registrar Usuario</title>
    <link href="Estilo/General.css" rel="stylesheet" />

    <style type="text/css">
        #divDatos {
            width:400px;
            margin-left: auto;
            margin-right: auto;
        }
            .divDatosUsr {
                margin-bottom: 7px !important;
            }

                .inputRegistro {
                    width:220px;
                    float: right;
                }

                #ddlCarreras {
                    width: 224px;
                }

            #lblError {
                color: red;
            }

            #divButtons {
                width: 400px;
                margin-top: 30px;
            }

                .acpCanButton {
                    width:80px;
                    height: 33px;
                }

                #btnGoBack {
                    float:left;
                }

                #btnAdd {
                    float:right;
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
        <form id="form1" runat="server">
            <h1 class="titulo_inicio">
                <asp:Label ID="lblTitulo" Text="Registrar" runat="server" />
            </h1>
            <div id="divDatos">
                <div class="divDatosUsr">
                    <label class="lblInfo">Número de credencial</label>
                    <asp:TextBox ID="txtCredencial" CssClass="inputRegistro" runat="server" />
                </div>
                <div class="divDatosUsr">
                    <label class="lblInfo">Nombre de usuario</label>
                    <asp:TextBox ID="txtNombre" CssClass="inputRegistro" runat="server" />
                </div>
                <div class="divDatosUsr">
                    <label class="lblInfo">Carrera</label>
                    <asp:DropDownList ID="ddlCarreras" CssClass="inputRegistro" runat="server"></asp:DropDownList>
                </div>

                <asp:Label ID="lblError" Text="" runat="server" />
                <div id="divButtons">
                    <asp:Button ID="btnGoBack" CssClass="acpCanButton" runat="server" 
                    AlternateText="Regresar" Text="Cancelar" />
                    <asp:Button ID="btnAdd" CssClass="acpCanButton" Text="Aceptar" runat="server" />
                </div>
            </div>
        </form>
    </section>
</body>
</html>