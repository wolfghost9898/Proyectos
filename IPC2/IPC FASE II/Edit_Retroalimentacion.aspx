<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Edit_Retroalimentacion.aspx.cs" Inherits="Edit_Retroalimentacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">


    

<div id="retro_from">   
        <asp:Label CssClass="title_retro" ID="nombre" runat="server"  Font-Bold="True"></asp:Label>
    <br />
    <br />
    <br />  
    <asp:Label ID="software_id" Visible="false" runat="server" Text="Label"></asp:Label>
    <asp:ListView ID="lv" runat="server" OnItemCommand="ListView1_ItemCommand">
        <ItemTemplate>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
           <ContentTemplate>

            <asp:Label ID="Label1" runat="server" CssClass="cate_retro" Text='<%# Eval("Nombre")%>'></asp:Label>
            <asp:ImageButton ID="imgedit1" CausesValidation="False" runat="server"  CommandName="imgedit1" 
                CommandArgument='<%# Bind("id_metricas") %>' ImageUrl="imagenes/star-empty-lg.png" />
            <asp:ImageButton ID="imgedit2" runat="server"  CausesValidation="False" CommandName="imgedit2" 
                CommandArgument='<%# Bind("id_metricas") %>' ImageUrl="imagenes/star-empty-lg.png" />
            <asp:ImageButton ID="imgedit3" runat="server" CausesValidation="False" CommandName="imgedit3"  
                CommandArgument='<%# Bind("id_metricas") %>' ImageUrl="imagenes/star-empty-lg.png" />
            <asp:ImageButton ID="imgedit4" runat="server"  CausesValidation="False" CommandName="imgedit4"
                CommandArgument='<%# Bind("id_metricas") %>' ImageUrl="imagenes/star-empty-lg.png" />
            <asp:ImageButton ID="imgedit5" runat="server" CausesValidation="False"  CommandName="imgedit5" 
                CommandArgument='<%# Bind("id_metricas") %>' ImageUrl="imagenes/star-empty-lg.png" />
            <br />
                </ContentTemplate>
    </asp:UpdatePanel>
        </ItemTemplate>
    </asp:ListView>
    <br />
        <br />
    <asp:DropDownList ID="Frecuencia" runat="server" CssClass="listas_retro">
        <asp:ListItem Selected="True">Frecuencia</asp:ListItem>
        <asp:ListItem Value="1">Diario</asp:ListItem>
        <asp:ListItem Value="2">Mensual</asp:ListItem>
        <asp:ListItem Value="3">Anual</asp:ListItem>
        </asp:DropDownList>
        <br />
         <br />
    <asp:TextBox ID="Comentario" runat="server"  placeholder="Comentario" CssClass="input_retro" TextMode="MultiLine"></asp:TextBox>
       <asp:RequiredFieldValidator runat="server" id="reqName" controltovalidate="Comentario" errormessage="Ingrese un Comentario!" ForeColor="White" />
        <br />
        <br />
        <asp:TextBox ID="Ventaja" runat="server" placeholder="Ventajas" CssClass="input_retro" TextMode="MultiLine"></asp:TextBox>
       <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" controltovalidate="Ventaja" errormessage="Ingrese una Ventaja!" ForeColor="White" />
        <br />
        <br />
        <asp:TextBox ID="Desventaja" runat="server" placeholder="Desventajas" CssClass="input_retro" TextMode="MultiLine"></asp:TextBox>
       <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" controltovalidate="Desventaja" errormessage="Ingrese una Desventaja!" ForeColor="White" />
        <br />
        <br />
        <asp:Button ID="save"  runat="server" Text="Guardar" CssClass="boton_retro" OnClick="save_Click" Width="30%" usesubmitbehavior="false" />
</div>



</asp:Content>

