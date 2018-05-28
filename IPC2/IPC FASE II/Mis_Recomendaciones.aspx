<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Mis_Recomendaciones.aspx.cs" Inherits="Mis_Recomendaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <asp:GridView ID="GridView1" CssClass="mydatagrid" runat="server" AllowPaging="True"
        PagerStyle-CssClass="pager" AutoGenerateColumns = "false" Font-Names = "Arial"
        Font-Size = "11pt"  ShowFooter = "true" 
       HeaderStyle-CssClass="encabezado" RowStyle-CssClass="rows"
        OnPageIndexChanging="datagrid_PageIndexChanging" PageSize="10" >

        <Columns>

<asp:TemplateField ItemStyle-Width = "40%"  HeaderText = "Comentario">
    <ItemTemplate>
        <asp:Label ID="lblComentario" runat="server"
        Text='<%# Eval("Comentario")%>' BackColor="Transparent"></asp:Label>
    </ItemTemplate>
</asp:TemplateField>


<asp:TemplateField ItemStyle-Width = "30%"  HeaderText = "Software">
    <ItemTemplate>
        <asp:Label ID="lblnombre" runat="server"
                Text='<%# Eval("Nombre")%>' BackColor="Transparent"></asp:Label>
    </ItemTemplate>
</asp:TemplateField>


<asp:TemplateField ItemStyle-Width = "10%"  HeaderText = "Fecha">
    <ItemTemplate>
        <asp:Label ID="lblfecha" runat="server"
                Text='<%# Eval("fecha")%>' BackColor="Transparent"></asp:Label>
    </ItemTemplate>
</asp:TemplateField>


<asp:TemplateField>
    <ItemTemplate>
        <asp:LinkButton ID="lnkRemove" runat="server"
            CommandArgument = '<%# Eval("id_recomendacion")%>'
         OnClientClick = "return confirm('¿Seguro que quieres eliminar esta Recomendacion?')"
        Text = "Eliminar" OnClick = "DeleteCustomer"></asp:LinkButton>
    </ItemTemplate>
    
</asp:TemplateField>


</Columns>



    </asp:GridView>
    </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

