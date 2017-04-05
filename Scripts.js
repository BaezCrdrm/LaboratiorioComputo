function closeTab()
{
    window.close();
}

function goBack(p)
{
    pages = parseInt(p);
    pages = -1;
}

function alertaErrorUsuario()
{
    //alert("El usuario no se encuentra registrado. Se te rediccionará al registro de usuarios.");
    var opc = confirm("El usuario no se encuentra registrado.\n¿Quieres que se te rediccione al registro de usuarios?")

    if(opc==true)
    {
        //Cambiar localización de redireccionamiento
        location.href = "MenuUsuario.aspx?retorno=true";
    }
    else {
        location.href = "EntradaMaq.aspx";
    }

}

function alertMessages(message)
{
    // Mensajes con caracter únicamente informativos
    alert(message);
}

function usuarioAgregado(regreso, msg)
{
    alert(msg);
    if(regreso=='True')
    {
        location.href = "EntradaMaq.aspx";
    }
    else
    {
        location.href = "MenuUsuario.aspx";
    }
}