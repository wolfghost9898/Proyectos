<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Plataformas.aspx.cs" Inherits="Plataformas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">

    <asp:Button ID="Crear" runat="server" Text="Crear" CssClass="botondesaparece" OnClick="Crear_Click"/>

    <div class="guardar1" runat="server" visible="False" id="div_mostrar">
    <asp:TextBox ID="tipo" CssClass="input_gestion" placeholder=" Tipo" runat="server"></asp:TextBox>
      <asp:Button ID="boton_guardar" CssClass="boton_general" runat="server" Text="Guardar"  BackColor="#D84315" Height="100%" OnClick="boton_guardar_Click" />
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
        <asp:Label ID="lblPlataforma" runat="server"
        Text='<%# Eval("id_Plataforma")%>' BackColor="Transparent"></asp:Label>
    </ItemTemplate>
</asp:TemplateField>
<asp:TemplateField ItemStyle-Width = "40px"  HeaderText = "Tipo">
    <ItemTemplate>
        <asp:Label ID="lbltipo" runat="server"
                Text='<%# Eval("tipo")%>' BackColor="Transparent"></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txttipo" runat="server"
            Text='<%# Eval("tipo")%>'></asp:TextBox>
    </EditItemTemplate> 
</asp:TemplateField>

<asp:TemplateField>
    <ItemTemplate>
        <asp:LinkButton ID="lnkRemove" runat="server"
            CommandArgument = '<%# Eval("id_Plataforma")%>'
         OnClientClick = "return confirm('¿Seguro que quieres eliminar esta Metrica?')"
        Text = "Eliminar" OnClick = "DeleteCustomer"></asp:LinkButton>
    </ItemTemplate>
    
</asp:TemplateField>
<asp:CommandField  ShowEditButton="True" />
</Columns>



    </asp:GridView>
    </ContentTemplate>
    </asp:UpdatePanel>





</asp:Content>

