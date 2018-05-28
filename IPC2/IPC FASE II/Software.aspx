<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Software.aspx.cs" Inherits="Software" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">

    <asp:Button ID="Crear" runat="server" Text="Crear" CssClass="botondesaparece" OnClick="Crear_Click"/>
    <div class="guardar1" runat="server" visible="False" id="div_mostrar">
    <asp:TextBox ID="nombre" CssClass="input_gestion" placeholder=" Nombre" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" id="reqName" controltovalidate="nombre" errormessage="Ingrese un nombre!" ForeColor="White" />
        <br />
    <asp:TextBox ID="Descripcion" CssClass="input_gestion" placeholder=" Descripcion" runat="server"></asp:TextBox>
     <asp:TextBox ID="demo"  CssClass="input_gestion" placeholder="Demo" runat="server"></asp:TextBox>
            <asp:TextBox ID="Soporte"  CssClass="input_gestion" placeholder="Soporte" runat="server"></asp:TextBox>
            <asp:TextBox ID="año"  CssClass="input_gestion" placeholder="Año de Fundacion" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" controltovalidate="nombre" errormessage="Ingrese un año!" ForeColor="White" />
        <br />
            <asp:TextBox ID="url"  CssClass="input_gestion" placeholder="URL" runat="server"></asp:TextBox>
        <asp:DropDownList ID="categoria" AutoPostBack="true" runat="server" CssClass="listas" OnTextChanged="categoria_TextChanged" >
            <asp:ListItem Selected>Categoria</asp:ListItem>
        </asp:DropDownList>

                <asp:DropDownList ID="Empresa" runat="server" CssClass="listas">
            <asp:ListItem Selected>Empresa Propietaria</asp:ListItem>
        </asp:DropDownList>

                     <asp:DropDownList ID="Plataforma" runat="server" CssClass="listas">
            <asp:ListItem Selected> Plataforma</asp:ListItem>
        </asp:DropDownList>

                             <asp:DropDownList ID="Licencia" runat="server" CssClass="listas">
            <asp:ListItem Selected> Licencia</asp:ListItem>
        </asp:DropDownList>

        <asp:TextBox  CssClass="input_gestion" ID="Categoria_Seleccionada" runat="server" PlaceHolder="Categorias Seleccionadas"></asp:TextBox>
                <asp:Label  CssClass="input_gestion" ID="Label1" runat="server" Text="Escoja la imagen que desee subir"></asp:Label>
            <asp:FileUpload ID="imagen"  CssClass="image_gestion" runat="server"  />
      <asp:Button ID="boton_guardar" CssClass="boton_general" runat="server" Text="Guardar"  BackColor="#D84315" Height="100%" OnClick="boton_guardar_Click" />

        </div>

    



    <asp:UpdatePanel ID="UpdatePanel1" runat="server" style="margin-left:2%;">
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
        <asp:Label ID="lblsoftware" runat="server"
        Text='<%# Eval("id_software")%>' BackColor="Transparent"></asp:Label>
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


<asp:TemplateField ItemStyle-Width = "40px"  HeaderText = "Sitio Web">
    <ItemTemplate>
        <asp:Label ID="lbllink" runat="server"
                Text='<%# Eval("Link")%>' BackColor="Transparent"></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtlink" runat="server"
            Text='<%# Eval("Link")%>'></asp:TextBox>
    </EditItemTemplate> 
</asp:TemplateField>


      <asp:TemplateField ItemStyle-Width = "40px"  HeaderText = "Demo">
    <ItemTemplate>
        <asp:Label ID="lbldemo" runat="server"
                Text='<%# Eval("Demo")%>' BackColor="Transparent"></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtdemo" runat="server"
            Text='<%# Eval("Demo")%>'></asp:TextBox>
    </EditItemTemplate> 
</asp:TemplateField>


     <asp:TemplateField ItemStyle-Width = "40px"  HeaderText = "Soporte">
    <ItemTemplate>
        <asp:Label ID="lblsoporte" runat="server"
                Text='<%# Eval("Soporte")%>' BackColor="Transparent"></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtsoporte" runat="server"
            Text='<%# Eval("Soporte")%>'></asp:TextBox>
    </EditItemTemplate> 
</asp:TemplateField>


    <asp:TemplateField ItemStyle-Width = "40px"  HeaderText = "Año Fundacion">
    <ItemTemplate>
        <asp:Label ID="lblaño" runat="server"
                Text='<%# Eval("Año_Creacion")%>' BackColor="Transparent"></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtaño" runat="server"
            Text='<%# Eval("Año_Creacion")%>'></asp:TextBox>
    </EditItemTemplate> 
</asp:TemplateField>


    <asp:TemplateField ItemStyle-Width = "40px"  HeaderText = "Imagen">
    <ItemTemplate>
        <asp:Label ID="lblimagen" runat="server"
                Text='<%# Eval("Imagen")%>' BackColor="Transparent"></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtimagen" runat="server"
            Text='<%# Eval("Imagen")%>'></asp:TextBox>
    </EditItemTemplate> 
</asp:TemplateField>


    <asp:TemplateField ItemStyle-Width = "40px"  HeaderText = "Empresa Propietaria">
    <ItemTemplate>
        <asp:Label ID="lblempresa" runat="server"
                Text='<%# Eval("empresa")%>' BackColor="Transparent"></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtempresa" runat="server"
            Text='<%# Eval("empresa")%>'></asp:TextBox>
    </EditItemTemplate> 
</asp:TemplateField>




    <asp:TemplateField ItemStyle-Width = "40px"  HeaderText = "Plataforma">
    <ItemTemplate>
        <asp:Label ID="lbltipo" runat="server"
                Text='<%# Eval("tipo")%>' BackColor="Transparent"></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txttipo" runat="server"
            Text='<%# Eval("tipo")%>'></asp:TextBox>
    </EditItemTemplate> 
</asp:TemplateField>



    <asp:TemplateField ItemStyle-Width = "40px"  HeaderText = "Categoria">
    <ItemTemplate>
        <asp:Label ID="lblcategoria" runat="server"
                Text='<%# Eval("Categoria")%>' BackColor="Transparent"></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtcategoria" runat="server"
            Text='<%# Eval("Categoria")%>'></asp:TextBox>
    </EditItemTemplate> 
</asp:TemplateField>


                <asp:TemplateField ItemStyle-Width = "40px"  HeaderText = "Licencia">
    <ItemTemplate>
        <asp:Label ID="lbllicencia" runat="server"
                Text='<%# Eval("Licencia")%>' BackColor="Transparent"></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtlicencia" runat="server"
            Text='<%# Eval("Licencia")%>'></asp:TextBox>
    </EditItemTemplate> 
</asp:TemplateField>


<asp:TemplateField>
    <ItemTemplate>
        <asp:LinkButton ID="lnkRemove" runat="server"
            CommandArgument = '<%# Eval("id_software")%>'
         OnClientClick = "return confirm('¿Seguro que quieres eliminar este Software?')"
        Text = "Eliminar" OnClick = "DeleteCustomer"></asp:LinkButton>
    </ItemTemplate>
    
</asp:TemplateField>
<asp:CommandField  ShowEditButton="True" />
</Columns>



    </asp:GridView>
    </ContentTemplate>
    </asp:UpdatePanel>











</asp:Content>

