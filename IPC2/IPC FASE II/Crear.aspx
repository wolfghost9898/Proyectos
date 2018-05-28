<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Crear.aspx.cs" Inherits="Usuarios_Crear" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
    <div class="principal">
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
                        <asp:ListItem Value="001">Administrador</asp:ListItem>
                        <asp:ListItem Value="002">Basico</asp:ListItem>
                        <asp:ListItem Value="003">Premium</asp:ListItem>
                        </asp:DropDownList>
                    <asp:button id="botontregis" runat="server" Text="Guardar" CssClass="botones" BackColor="#4CAF50" OnClick="botontregis_Click" ></asp:button>
                </div>
            </div> 
    </div>
        </div>
</asp:Content>

