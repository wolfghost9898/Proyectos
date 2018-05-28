<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Recomendaciones.aspx.cs" Inherits="Recomendaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">

    <div id="center_recomendaciones">
        <asp:ListView ID="derecho" runat="server">
            <ItemTemplate>
                <div class="comentarios">
                    <div class="text_comentario">
                          <asp:Label ID="Label7" runat="server" Text='<%# Eval("Comentario")%>'  ForeColor="Black"></asp:Label>
                          
                    </div>
                    <div class="footer_comentario">
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("coduser")+ " |   "+ Eval("fecha")+" |  Aplicacion:  "+ Eval("Nombre")%>'></asp:Label>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>


</asp:Content>

