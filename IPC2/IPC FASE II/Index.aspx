<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>LogIn</title>
        <link rel="stylesheet" type="text/css" href="~/css/StyleSheet.css"/> 

</head>
<body class="principal">
    <form id="form1" runat="server">
        <div class="pagina-inicio" >
            <div class="formulario">
                <div class="ingreso-formulario">
                    <asp:TextBox CssClass="introducir" ID="usuario_in" runat="server" placeholder="Usuario"></asp:TextBox>
                    <asp:TextBox CssClass="introducir" ID="contraseña_in" runat="server" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
                    <asp:button id="botoningre" runat="server" Text="Ingresar" CssClass="botones" BackColor="#4CAF50" OnClick="botoningre_Click" ></asp:button>
                    <p class="mensaje">¿No tiene una cuenta?<a href="Registrar.aspx">Registrar</a></p>
                    <p class="mensaje">¿Olvidaste la Contraseña?<a href="contraseña.aspx">Recuperar</a></p>
                </div> 
            </div>
        </div>
    </form>
</body>
</html>
