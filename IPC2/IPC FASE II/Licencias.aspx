<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Licencias.aspx.cs" Inherits="Licencias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">

    <asp:Button ID="Crear" runat="server" Text="Crear" CssClass="botondesaparece" OnClick="Crear_Click"/>

    <div class="guardar1" runat="server" visible="False" id="div_mostrar">
        <asp:TextBox ID="descripcion_guardar" CssClass="input_gestion" placeholder="Ingrese el nombre de la Licencia" runat="server"></asp:TextBox>
        <asp:Button ID="boton_guardar" runat="server" CssClass="boton_general" Text="Guardar" OnClick="boton_guardar_Click" BackColor="#D84315" Height="100%" />
    </div>




    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <asp:GridView ID="GridView1" CssClass="mydatagrid" runat="server" AllowPaging="True"
        PagerStyle-CssClass="pager" AutoGenerateColumns = "false" Font-Names = "Arial"
        Font-Size = "11pt"  ShowFooter = "true" 
       HeaderStyle-CssClass="encabezado" RowStyle-CssClass="rows"
        onrowediting="EditCustomer"
        OnRowUpdating="UpdateCustomer"  onrowcancelingedit="CancelEdit"  OnPageIndexChanging="datagrid_PageIndexChanging" PageSize="10" >

        <Columns>
<asp:TemplateField ItemStyle-Width = "30px"  HeaderText = "Id">
    <ItemTemplate>
        <asp:Label ID="lbllicencia" runat="server"
        Text='<%# Eval("id_licencia")%>' BackColor="Transparent"></asp:Label>
    </ItemTemplate>
</asp:TemplateField>
<asp:TemplateField ItemStyle-Width = "40px"  HeaderText = "Descripcion">
    <ItemTemplate>
        <asp:Label ID="lbldescripcion" runat="server"
                Text='<%# Eval("descricpcion")%>' BackColor="Transparent"></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtdescripcion" runat="server"
            Text='<%# Eval("descricpcion")%>'></asp:TextBox>
    </EditItemTemplate> 
</asp:TemplateField>
<asp:TemplateField>
    <ItemTemplate>
        <asp:LinkButton ID="lnkRemove" runat="server"
            CommandArgument = '<%# Eval("id_licencia")%>'
         OnClientClick = "return confirm('¿Seguro que quieres eliminar esta Licencia?')"
        Text = "Eliminar" OnClick = "DeleteCustomer"></asp:LinkButton>
    </ItemTemplate>
    
</asp:TemplateField>
<asp:CommandField  ShowEditButton="True" />
</Columns>



    </asp:GridView>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

