<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FeedBack.aspx.cs" Inherits="FeedBack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
    <div id="left_feedback">
        <div class="title_left">
            <asp:Label ID="nombre" runat="server"  ForeColor="White" Font-Size="20px" Font-Bold="True"></asp:Label>
        </div>
        <div class="cuerpo_left">
            <asp:ListView ID="izquierdo" runat="server">
                <ItemTemplate>
                    <br />
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Nombre") + ": " %>' Font-Size="18px" ForeColor="Black"></asp:Label>
                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("puntuaje")%>' ForeColor="Black" Font-Size="14px"></asp:Label>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>

    <div id="right_feedback">
        <asp:ListView ID="derecho" runat="server">
            <ItemTemplate>
                <div class="comentarios">
                    <div class="text_comentario">
                          <asp:Label ID="Label7" runat="server" Text='<%# Eval("Comentario")%>'  ForeColor="Black"></asp:Label>
                          
                    </div>
                    <div class="footer_comentario">
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("id_usuario")+ " |   "+ Eval("fecha")%>'></asp:Label>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>

