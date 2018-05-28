using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

         ReportDocument reporte = new ReportDocument();
        reporte.Load(Server.MapPath("Usuario.rpt"));
         CrystalReportViewer1.ReportSource = reporte;

    }


   
    protected void CrystalReportViewer1_Init(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ReportDocument reporte = new ReportDocument();
        reporte.Load(Server.MapPath("Usuario.rpt"));
        CrystalReportViewer1.ReportSource = reporte;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {

        ReportDocument reporte = new ReportDocument();
        reporte.Load(Server.MapPath("PrecioMayor.rpt"));
        CrystalReportViewer1.ReportSource = reporte;
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        ReportDocument reporte = new ReportDocument();
        reporte.Load(Server.MapPath("Compras.rpt"));
        CrystalReportViewer1.ReportSource = reporte;
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        ReportDocument reporte = new ReportDocument();
        reporte.Load(Server.MapPath("Compras3veces.rpt"));
        CrystalReportViewer1.ReportSource = reporte;

    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        ReportDocument reporte = new ReportDocument();
        reporte.Load(Server.MapPath("menosvendidos.rpt"));
        CrystalReportViewer1.ReportSource = reporte;
    }
}