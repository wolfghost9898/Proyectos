using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Comparaciones_Muro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM Comparaciones "+
                                                      "ORDER BY id_comparacion DESC; ", conexion);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        derecho.DataSource = dt;
        derecho.DataBind();
    }
    protected void Ver_Mas(object sender, EventArgs e)
    {
        LinkButton lnkEdit = (LinkButton)sender;
        String nombre = lnkEdit.CommandArgument;
        Response.Redirect("Ver_Comparacion.aspx?id=" + nombre);
    }

}