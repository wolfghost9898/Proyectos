<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registrar.aspx.cs" Inherits="paginas_Registrar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
            <link rel="stylesheet" type="text/css" href="~/css/StyleSheet.css"/> 

    <title>Registrar</title>
</head>
<body class="principal">
    <form id="form1" runat="server">
     <div class="pagina-inicio" >
    <div class="formulario">
                    <div class="registro-formulario">
                    <asp:TextBox CssClass="introducir" ID="usuario_re" runat="server" placeholder="Usuario"></asp:TextBox>
                    <asp:TextBox CssClass="introducir" ID="nombre_re" runat="server" placeholder="Nombre"></asp:TextBox>
                    <asp:TextBox CssClass="introducir" ID="contraseña_re" runat="server" placeholder="Contraseña"></asp:TextBox>
                    <asp:TextBox  CssClass="introducir" ID="profesion" placeholder="Profesion" runat="server"></asp:TextBox>
                    <asp:TextBox CssClass="introducir" ID="email" runat="server" placeholder="Ingrese su correo"></asp:TextBox>
                    <asp:TextBox CssClass="introducir" ID="Fecha" runat="server" placeholder="Fecha de Nacimiento dd/mm/yy"></asp:TextBox>
                    <asp:DropDownList ID="Tipo" runat="server">
                        <asp:ListItem>Tipo de Usuario</asp:ListItem>
                        <asp:ListItem Value="002">Basico</asp:ListItem>
                        <asp:ListItem Value="003">Premium</asp:ListItem>
                        </asp:DropDownList>
                    <asp:button id="botontregis" runat="server" Text="Registrar" CssClass="botones" BackColor="#4CAF50" OnClick="botontregis_Click" ></asp:button>
                    <p class="mensaje">¿Ya tiene una cuenta?<a href="Index.aspx" >Ingresar</a></p>
                </div>
            </div>
         
    </div>
    </form>
</body>
</html>
