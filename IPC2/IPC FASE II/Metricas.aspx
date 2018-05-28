<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Metricas.aspx.cs" Inherits="Metricas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">

    <asp:Button ID="Crear" runat="server" Text="Crear" CssClass="botondesaparece" OnClick="Crear_Click"/>

    <div class="guardar1" runat="server" visible="False" id="div_mostrar">
    <asp:TextBox ID="nombre_me" CssClass="input_gestion" placeholder="Ingrese Nombre" runat="server"></asp:TextBox>
     <asp:TextBox ID="descripcion_guardar"  CssClass="input_gestion" placeholder="Ingrese la Descripcion" runat="server" TextMode="MultiLine"></asp:TextBox>
      <asp:Button ID="boton_guardar" CssClass="boton_general" runat="server" Text="Guardar" BackColor="#D84315" Height="100%" OnClick="boton_guardar_Click"  />
    </div>
        

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <asp:GridView ID="GridView1" CssClass="mydatagrid" runat="server" AllowPaging="True"
        PagerStyle-CssClass="pager" AutoGenerateColumns = "false" Font-Names = "Arial"
        Font-Size = "11pt"  ShowFooter = "true" 
       HeaderStyle-CssClass="encabezado" RowStyle-CssClass="rows"
        onrowediting="EditCustomer"
        OnRowUpdating="UpdateCustomer"  onrowcancelingedit="CancelEdit" >

        <Columns>
<asp:TemplateField ItemStyle-Width = "30px"  HeaderText = "Id">
    <ItemTemplate>
        <asp:Label ID="lblmetrica" runat="server"
        Text='<%# Eval("id_metricas")%>' BackColor="Transparent"></asp:Label>
    </ItemTemplate>
</asp:TemplateField>
<asp:TemplateField ItemStyle-Width = "40px"  HeaderText = "Nombre">
    <ItemTemplate>
        <asp:Label ID="lblnombre" runat="server"
                Text='<%# Eval("Nombre")%>' BackColor="Transparent"></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtnombre" runat="server"
            Text='<%# Eval("Nombre")%>'></asp:TextBox>
    </EditItemTemplate> 
</asp:TemplateField>
<asp:TemplateField ItemStyle-Width = "40px"  HeaderText = "Descripcion">
    <ItemTemplate>
        <asp:Label ID="lbldescripcion" runat="server"
                Text='<%# Eval("Descripcion")%>' BackColor="Transparent"></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtdescripcion" runat="server"
            Text='<%# Eval("Descripcion")%>'></asp:TextBox>
    </EditItemTemplate> 
</asp:TemplateField>
<asp:TemplateField>
    <ItemTemplate>
        <asp:LinkButton ID="lnkRemove" runat="server"
            CommandArgument = '<%# Eval("id_metricas")%>'
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

