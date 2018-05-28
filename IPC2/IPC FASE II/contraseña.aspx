<%@ Page Language="C#" AutoEventWireup="true" CodeFile="contraseña.aspx.cs" Inherits="contraseña" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Forgot Password</title>
         <link rel="stylesheet" type="text/css" href="~/css/contra.css"/> 
</head>
<body>
  <div class="wrapper">
	<div class="container">
		<h1>Recuperar Contraseña</h1>
		
		<form class="form" runat="server">
            <asp:TextBox ID="Correo" runat="server" placeholder="Ingrese su correo" ForeColor="Black"></asp:TextBox>
            <asp:TextBox ID="Fecha" runat="server" placeholder="Ingrese su fecha de nacimiento" ForeColor="Black"></asp:TextBox>
            <asp:Button ID="verificar" runat="server" Text="Verificar" CssClass="login-button" Width="254px" OnClick="verificar_Click"  />
		</form>
        <asp:Label ID="Label1" runat="server" Text="Contraseña: " Visible="False"></asp:Label>
        <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>
	</div>

	<ul class="bg-bubbles">
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
	</ul>
</div>
</body>
</html>
