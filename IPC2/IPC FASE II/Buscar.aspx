<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Buscar.aspx.cs" Inherits="Buscar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
    <div style="background:white;">
    <asp:TextBox ID="buscar" runat="server" placeholder="Ingrese Usuario a Buscar" BorderStyle="None"></asp:TextBox>
    <asp:Button ID="buscar_button" runat="server" Text="Buscar" OnClick="buscar_button_Click" />
    <br />
    <br />

            <hr style="background-color:black;"/>


        <div id = "dvGrid" style ="padding:10px;width:100%">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<asp:GridView ID="GridView1" runat="server"  Width = "100%"
AutoGenerateColumns = "false" Font-Names = "Arial"
Font-Size = "11pt" AlternatingRowStyle-BackColor = "#C2D69B" 
HeaderStyle-BackColor = "green" AllowPaging ="true"  ShowFooter = "true" 
onrowediting="EditCustomer"
onrowupdating="UpdateCustomer"  onrowcancelingedit="CancelEdit" >
<Columns>
<asp:TemplateField ItemStyle-Width = "30px"  HeaderText = "Usuario">
    <ItemTemplate>
        <asp:Label ID="lblUsuario" runat="server"
        Text='<%# Eval("id_Usuario")%>'></asp:Label>
    </ItemTemplate>
</asp:TemplateField>
<asp:TemplateField ItemStyle-Width = "40px"  HeaderText = "Nombre">
    <ItemTemplate>
        <asp:Label ID="lblName" runat="server"
                Text='<%# Eval("Nombre")%>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtName" runat="server"
            Text='<%# Eval("Nombre")%>'></asp:TextBox>
    </EditItemTemplate> 

</asp:TemplateField>
<asp:TemplateField ItemStyle-Width = "150px"  HeaderText = "Fecha Nacimiento">
    <ItemTemplate>
        <asp:Label ID="lblfecha" runat="server"
            Text='<%# Eval("Fecha_NAc")%>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtfecha" runat="server"
            Text='<%# Eval("Fecha_NAc")%>'></asp:TextBox>
    </EditItemTemplate> 

</asp:TemplateField>
    <asp:TemplateField ItemStyle-Width = "300px"  HeaderText = "Correo">
    <ItemTemplate>
        <asp:Label ID="lblcorreo" runat="server"
            Text='<%# Eval("Correo")%>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtcorreo" runat="server"
            Text='<%# Eval("Correo")%>'></asp:TextBox>
    </EditItemTemplate> 

</asp:TemplateField>
    <asp:TemplateField ItemStyle-Width = "150px"  HeaderText = "Contraseña">
    <ItemTemplate>
        <asp:Label ID="lblcontraseña" runat="server"
            Text='<%# Eval("Contraseña")%>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtcontraseña" runat="server"
            Text='<%# Eval("Contraseña")%>'></asp:TextBox>
    </EditItemTemplate> 

</asp:TemplateField>
    <asp:TemplateField ItemStyle-Width = "200px"  HeaderText = "Profesion">
    <ItemTemplate>
        <asp:Label ID="lblprofesion" runat="server"
            Text='<%# Eval("Profesion")%>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtprofesion" runat="server"
            Text='<%# Eval("Profesion")%>'></asp:TextBox>
    </EditItemTemplate> 

</asp:TemplateField>

        <asp:TemplateField ItemStyle-Width = "200px"  HeaderText = "Tipo de Usuario">
    <ItemTemplate>
        <asp:Label ID="lbltipo" runat="server"
            Text='<%# Eval("idtipousuario")%>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txttipo" runat="server"
            Text='<%# Eval("idtipousuario")%>'></asp:TextBox>
    </EditItemTemplate> 

</asp:TemplateField>

<asp:TemplateField>
    <ItemTemplate>
        <asp:LinkButton ID="lnkRemove" runat="server"
            CommandArgument = '<%# Eval("id_usuario")%>'
         OnClientClick = "return confirm('¿Seguro que quieres eliminar este usuario?')"
        Text = "Eliminar" OnClick = "DeleteCustomer"></asp:LinkButton>
    </ItemTemplate>
    
</asp:TemplateField>
<asp:CommandField  ShowEditButton="True" />
</Columns>
<AlternatingRowStyle BackColor="#C2D69B"  />
</asp:GridView>
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID = "GridView1" />
</Triggers>
</asp:UpdatePanel>
</div>




    </div>
</asp:Content>

