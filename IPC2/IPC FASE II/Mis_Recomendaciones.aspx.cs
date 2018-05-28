using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Mis_Recomendaciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }


    private DataTable GetData(SqlCommand cmd, SqlConnection con)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter();
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        con.Open();
        sda.SelectCommand = cmd;
        sda.Fill(dt);
        return dt;
    }

    private void BindData()
    {
        String usuario = Request.Cookies["UserSettings"]["user"];
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        SqlCommand cmd = new SqlCommand("Select Recomendacion.id_recomendacion, Recomendacion.Comentario,Recomendacion.Fecha,Recomendacion.coduser,Software.Nombre From Recomendacion "+
                                        "INNER JOIN Software ON "+
                                        "Software.id_software = Recomendacion.idsoft  WHERE Recomendacion.coduser='" + usuario + "' " +
                                        "ORDER BY Recomendacion.id_recomendacion DESC;");
        GridView1.DataSource = GetData(cmd, conexion);
        GridView1.DataBind();
    }

    protected void DeleteCustomer(object sender, EventArgs e)
    {
        LinkButton lnkRemove = (LinkButton)sender;
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "delete from  Recomendacion where " +
        "id_recomendacion=@idrealim;";
        cmd.Parameters.Add("@idrealim", SqlDbType.Int).Value
            = lnkRemove.CommandArgument;
        GridView1.DataSource = GetData(cmd, conexion);
        GridView1.DataBind();
    }

    protected void datagrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView gv = (GridView)sender;
        gv.PageIndex = e.NewPageIndex;
        BindData();
    }
}