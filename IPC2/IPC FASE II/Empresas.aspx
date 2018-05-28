<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Empresas.aspx.cs" Inherits="Empresas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">

    <asp:Button ID="Crear" runat="server" Text="Crear" CssClass="botondesaparece" OnClick="Crear_Click"/>
    <asp:Button ID="Carga_Masiva" runat="server" Text="Carga Masiva" CssClass="botondesaparece" OnClick="CargaMasiva_Click"/>

    <div class="guardar1" runat="server" visible="false" id="div_carga">
        <asp:FileUpload ID="carga_mas" runat="server" />
        <br />
        <asp:Button ID="boton_guardar_carga" CssClass="boton_general" runat="server" Text="Guardar"  BackColor="#D84315" Height="100%" OnClick="boton_guardar_carga_Click" />
    </div>
     <div class="guardar1" runat="server" visible="False" id="div_mostrar">
    <asp:TextBox ID="nombre_me" CssClass="input_gestion" placeholder=" Nombre" runat="server"></asp:TextBox>
     <asp:TextBox ID="web"  CssClass="input_gestion" placeholder="Direccion Web" runat="server"></asp:TextBox>
            <asp:TextBox ID="valor"  CssClass="input_gestion" placeholder="Valor" runat="server"></asp:TextBox>
            <asp:TextBox ID="año"  CssClass="input_gestion" placeholder="Año de Fundacion" runat="server"></asp:TextBox>
            <asp:TextBox ID="url"  CssClass="input_gestion" placeholder="URL" runat="server"></asp:TextBox>
      <asp:Button ID="boton_guardar" CssClass="boton_general" runat="server" Text="Guardar"  BackColor="#D84315" Height="100%" OnClick="boton_guardar_Click" />
    </div>


    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <asp:GridView ID="GridView1" CssClass="mydatagrid" runat="server" AllowPaging="True"
        PagerStyle-CssClass="pager" AutoGenerateColumns = "false" Font-Names = "Arial"
        Font-Size = "11pt"  ShowFooter = "true" 
       HeaderStyle-CssClass="encabezado" RowStyle-CssClass="rows"
        onrowediting="EditCustomer"
        OnRowUpdating="UpdateCustomer"  onrowcancelingedit="CancelEdit" OnPageIndexChanging="datagrid_PageIndexChanging" PageSize="10" >

        <Columns>

<asp:TemplateField ItemStyle-Width = "30px"  HeaderText = "Id">
    <ItemTemplate>
        <asp:Label ID="lblempresa" runat="server"
        Text='<%# Eval("id_Empresa")%>' BackColor="Transparent"></asp:Label>
    </ItemTemplate>
</asp:TemplateField>


<asp:TemplateField ItemStyle-Width = "40px"  HeaderText = "Nombre">
    <ItemTemplate>
        <asp:Label ID="lblnombre" runat="server"
                Text='<%# Eval("nombre")%>' BackColor="Transparent"></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtnombre" runat="server"
            Text='<%# Eval("nombre")%>'></asp:TextBox>
    </EditItemTemplate> 
</asp:TemplateField>


<asp:TemplateField ItemStyle-Width = "40px"  HeaderText = "Sitio Web">
    <ItemTemplate>
        <asp:Label ID="lblsitio" runat="server"
                Text='<%# Eval("sitioweb")%>' BackColor="Transparent"></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtsitio" runat="server"
            Text='<%# Eval("sitioweb")%>'></asp:TextBox>
    </EditItemTemplate> 
</asp:TemplateField>


      <asp:TemplateField ItemStyle-Width = "40px"  HeaderText = "URL">
    <ItemTemplate>
        <asp:Label ID="lblurl" runat="server"
                Text='<%# Eval("Link")%>' BackColor="Transparent"></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txturl" runat="server"
            Text='<%# Eval("Link")%>'></asp:TextBox>
    </EditItemTemplate> 
</asp:TemplateField>


     <asp:TemplateField ItemStyle-Width = "40px"  HeaderText = "Valor">
    <ItemTemplate>
        <asp:Label ID="lblvalor" runat="server"
                Text='<%# Eval("valor")%>' BackColor="Transparent"></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtvalor" runat="server"
            Text='<%# Eval("valor")%>'></asp:TextBox>
    </EditItemTemplate> 
</asp:TemplateField>


    <asp:TemplateField ItemStyle-Width = "40px"  HeaderText = "Año Fundacion">
    <ItemTemplate>
        <asp:Label ID="lblaño" runat="server"
                Text='<%# Eval("año_fundacio")%>' BackColor="Transparent"></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtaño" runat="server"
            Text='<%# Eval("año_fundacio")%>'></asp:TextBox>
    </EditItemTemplate> 
</asp:TemplateField>


<asp:TemplateField>
    <ItemTemplate>
        <asp:LinkButton ID="lnkRemove" runat="server"
            CommandArgument = '<%# Eval("id_Empresa")%>'
         OnClientClick = "return confirm('¿Seguro que quieres eliminar esta Empresa?')"
        Text = "Eliminar" OnClick = "DeleteCustomer"></asp:LinkButton>
    </ItemTemplate>
    
</asp:TemplateField>
<asp:CommandField  ShowEditButton="True" />
</Columns>



    </asp:GridView>
    </ContentTemplate>
    </asp:UpdatePanel>









</asp:Content>

