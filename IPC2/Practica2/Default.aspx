<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Button ID="Button1" runat="server" BackColor="#33CCCC" OnClick="Button1_Click" Text="USUARIOS" />
<asp:Button ID="Button5" runat="server" BackColor="#00CCFF" OnClick="Button5_Click" Text="Productos menos vendidos" />
<asp:Button ID="Button2" runat="server" BackColor="#00CCFF" OnClick="Button2_Click" Text="Prouctos &gt; Q500" />
<asp:Button ID="Button3" runat="server" BackColor="#00CCFF" OnClick="Button3_Click" Text="Clientes Frecuentes" />
<asp:Button ID="Button4" runat="server" BackColor="#00CCFF" OnClick="Button4_Click" Text="Compras mas de tres veces" />
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" BorderColor="Blue" OnInit="CrystalReportViewer1_Init" Width="350px" />

</asp:Content>

