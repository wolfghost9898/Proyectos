<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Mis_Comparaciones.aspx.cs" Inherits="Mis_Comparaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <asp:GridView ID="GridView1" CssClass="mydatagrid" runat="server" AllowPaging="True"
        PagerStyle-CssClass="pager" AutoGenerateColumns = "false" Font-Names = "Arial"
        Font-Size = "11pt"  ShowFooter = "true" 
       HeaderStyle-CssClass="encabezado" RowStyle-CssClass="rows"
        OnPageIndexChanging="datagrid_PageIndexChanging" PageSize="10" >

        <Columns>

<asp:TemplateField ItemStyle-Width = "40%"  HeaderText = "App Ganadora">
    <ItemTemplate>
        <asp:Label ID="lblComentario" runat="server"
        Text='<%# Eval("Ap_Ganadora")%>' BackColor="Transparent"></asp:Label>
    </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField ItemStyle-Width = "40%"  HeaderText = "Fecha">
    <ItemTemplate>
        <asp:Label ID="lblfecha" runat="server"
                Text='<%# Eval("Fecha")%>' BackColor="Transparent"></asp:Label>
    </ItemTemplate>
</asp:TemplateField>


<asp:TemplateField>
    <ItemTemplate>
        <asp:LinkButton ID="lnkRemove" runat="server"
            CommandArgument = '<%# Eval("id_comparacion")%>'
         OnClientClick = "return confirm('¿Seguro que quieres eliminar esta comparacion?')"
        Text = "Eliminar" OnClick = "DeleteCustomer"></asp:LinkButton>
    </ItemTemplate>
    
</asp:TemplateField>


</Columns>



    </asp:GridView>
    </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

