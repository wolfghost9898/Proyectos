<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Report_Aplicacion.aspx.cs" Inherits="Report_Aplicacion" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">

    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="1202px" ReportSourceID="Aplicacion_Reporte" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="1104px" />
<CR:CrystalReportSource ID="Aplicacion_Reporte" runat="server">
    <Report FileName="Aplicacion_Reporte.rpt">
    </Report>
</CR:CrystalReportSource>
</asp:Content>

