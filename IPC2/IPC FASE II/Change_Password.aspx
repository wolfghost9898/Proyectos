<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Change_Password.aspx.cs" Inherits="Change_Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
    <div id="change_password">
        <div id="title_password">
            <asp:Label ID="Label1" runat="server" Text="Cambiar Contraseña" ForeColor="White"></asp:Label>
        </div>
        <div id="body_password">
            <asp:TextBox ID="contraseña_actual" runat="server" placeholder="Ingrese Contraseña" TextMode="Password" CssClass="input_password"></asp:TextBox>
            <asp:TextBox ID="newcontraseña" runat="server" placeholder="Ingrese la Nueva Contraseña" TextMode="Password" CssClass="input_password"></asp:TextBox>
            <asp:TextBox ID="newcontraseña2" runat="server" placeholder="Ingrese la Nueva Contraseña Nuevamente" TextMode="Password" CssClass="input_password"></asp:TextBox>
        </div>
        <div id="footer_password">
            <asp:Button ID="cambiar_password" runat="server" Text="Guardar" CssClass="button_password" OnClick="cambiar_password_Click" />
        </div>
    <asp:Label ID="lblMessage" runat="server" />
    </div>  
</asp:Content>

