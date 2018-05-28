<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Ver_Comparacion.aspx.cs" Inherits="Ver_Comparacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">

    <asp:ListView ID="ListView1" runat="server" OnItemDataBound="ListView1_ItemDataBound">
        <ItemTemplate>
            <div class="container2" id="contenedor_todo" runat="server">
                <asp:Label ID="nombre_ganadora" runat="server" Text="GANADORA" CssClass="label_ganadora" Visible="false"></asp:Label>
                <asp:Label ID="nombre_soft" runat="server" Text='<%# Eval("nombre")%>' Visible="false"></asp:Label>
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
                    <asp:Chart runat="server" ID="GRAFICO" Width="500px" Height="200px" BorderDashStyle="Solid" BackSecondaryColor="White"
      BackGradientStyle="TopBottom" BorderWidth="2px" backcolor="211, 223, 240"
      BorderColor="#1A3B69">
                        <series ><asp:Series Name="Series" BorderColor="180, 26, 59, 105" ></asp:Series></series>
                        <chartareas><asp:ChartArea Name="ChartArea" BorderColor="64, 64, 64, 64"
 BorderDashStyle="Solid" BackSecondaryColor="White"
 BackColor="64, 165, 191, 228"
 ShadowColor="Transparent" BackGradientStyle="TopBottom">
                            <axisy linecolor="64, 64, 64, 64">
                <labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
                <majorgrid linecolor="64, 64, 64, 64" />
            </axisy>
            <axisx linecolor="64, 64, 64, 64">
                <labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
                <majorgrid linecolor="64, 64, 64, 64" />
            </axisx>

                                    </asp:ChartArea></chartareas>
                    </asp:Chart>
                </div>
         
    </ItemTemplate>
</asp:ListView>

</asp:Content>

