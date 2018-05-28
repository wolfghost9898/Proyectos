<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Comparaciones_Muro.aspx.cs" Inherits="Comparaciones_Muro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">

    
    <div id="center_recomendaciones">
        <asp:ListView ID="derecho" runat="server">
            <ItemTemplate>
                <div class="comentarios">
                    <div class="text_comentario">
                          <asp:Label ID="Label7" runat="server" Text='<%# "App Ganadora: "+Eval("Ap_Ganadora")%>'  ForeColor="Black"></asp:Label>
                         <asp:LinkButton ID="lnkEdit" runat="server"
                            CommandArgument = '<%# Eval("id_comparacion")%>'
                            Text = "Ver mas" OnClick = "Ver_Mas">
                         </asp:LinkButton>
                    </div>
                    <div class="footer_comentario">
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("idusuario")+ " |   "+ Eval("Fecha")%>'></asp:Label>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>

</asp:Content>

