<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Software_View.aspx.cs" Inherits="Software_View" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">

     <div class="buscar_contenedor">
            <asp:DropDownList ID="categoria" AutoPostBack="true" runat="server" CssClass="listas" OnSelectedIndexChanged="categoria_SelectedIndexChanged" >
            <asp:ListItem Selected>Categoria</asp:ListItem>
        </asp:DropDownList>

                <asp:DropDownList ID="Empresa" AutoPostBack="true" runat="server" CssClass="listas" OnSelectedIndexChanged="Empresa_SelectedIndexChanged">
            <asp:ListItem Selected>Empresa Propietaria</asp:ListItem>
        </asp:DropDownList>

                     <asp:DropDownList ID="Plataforma" AutoPostBack="true" runat="server" CssClass="listas" OnSelectedIndexChanged="Plataforma_SelectedIndexChanged">
            <asp:ListItem Selected> Plataforma</asp:ListItem>
        </asp:DropDownList>

                             <asp:DropDownList ID="Licencia" AutoPostBack="true" runat="server" CssClass="listas" OnSelectedIndexChanged="Licencia_SelectedIndexChanged">
            <asp:ListItem Selected> Licencia</asp:ListItem>
        </asp:DropDownList>

         <asp:TextBox ID="busqueda" CssClass="input_gestion" AutoPostBack="true" runat="server" placeholder="Ingrese el nombre del producto" OnTextChanged="busqueda_TextChanged"></asp:TextBox>
    </div>



    <asp:ListView ID="ListView1" runat="server" OnItemCreated="ListView1_ItemCreated" >
        <ItemTemplate>
<div class="container2">
    <asp:ImageButton CssClass="buttons_userpremiun" ID="share_button" runat="server" ImageUrl="~/imagenes/share.png" CommandArgument = '<%# Eval("id_software")%>' ToolTip="Compartir" Visible="False"  OnClick = "Compartir_Click"/>
    <asp:ImageButton CssClass="buttons_userpremiun" ID="agregar_button" runat="server" ImageUrl="~/imagenes/plus.png" CommandArgument = '<%# Eval("id_software")%>' ToolTip="Agregar a Comparacion" OnClick="Agregar_Click" Visible="False" />
	<img src='<%# Eval("Imagen")%>' alt="image">
	<div class="rate">
		<h3 class="title-card"><%# Eval("nombre")%></h3>
	<p>Año: <%# Eval("Año_Creacion")%></p><br />
    <p>Categoria: <%# Eval("Categoria")%></p>
</div>	
	
<p> Descripcion:
<%# Eval("Descripcion")%>
</p>
	<span class="map">
		<p>Empresa : <%# Eval("empresa")%></p>
	</span>
	
	<span class="map">
		<p>Demo: <%# Eval("Demo")%></p>
	</span>
    	<span class="map">
		<p>Soporte: <%# Eval("Soporte")%></p>
	</span>

    	<span class="map">
		<p>Plataforma: <%# Eval("tipo")%></p>
	</span>

        	<span class="map">
		<p>Licencia: <%# Eval("tipo")%></p>
	</span>

    	<span class="map">
		<p>Link: <%# Eval("Link")%></p>
	</span>
	
    <asp:Button class="boton_soft" ID="Software" runat="server" Text="Calificar" CommandArgument = '<%# Eval("id_software")%>' OnClick = "Software_Click" />	
    <asp:Button class="boton_soft" ID="FeedBack" runat="server" Text="FeedBack" CommandArgument = '<%# Eval("id_software")%>' OnClick="FeedBack_Click"/>	

</div>
          

</ItemTemplate>
</asp:ListView>
         <asp:Label ID="lblHidden" runat="server" Text=""></asp:Label>
   <ajaxToolkit:ModalPopupExtender ID="mpePopUp" runat="server" TargetControlID="lblHidden" PopupControlID="divPopUp" BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>
    <div id="divPopUp" class="pnlBackGround">
     <div id="Header" class="header" >
         Recomendar
         <div id="Divbtncancel" class="buttonCancel_popup">
             <asp:ImageButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" ImageUrl="~/imagenes/close.png" />
         </div>
     </div>
     <div id="main" class="main_popup">
         <asp:TextBox ID="comentario" runat="server" placeholder="Comentario..." TextMode="MultiLine" CssClass="input_popup" ></asp:TextBox>
     </div>
     <div id="buttons_poup" class="main_popup">
              <asp:Button id="btnOk" class="buttonOK_popup" runat="server" text="Recomendar" OnClick="btnOk_Click" />
     </div>
</div>

</asp:Content>

