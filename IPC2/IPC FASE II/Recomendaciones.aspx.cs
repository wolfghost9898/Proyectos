using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Recomendaciones : System.Web.UI.Page
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
        SqlDataAdapter adaptador = new SqlDataAdapter("Select Recomendacion.Comentario, Recomendacion.Fecha, Recomendacion.coduser, Software.Nombre From Recomendacion "+
                                                      "INNER JOIN Software ON "+
                                                      "Software.id_software = Recomendacion.idsoft "+
                                                      "ORDER BY Recomendacion.id_recomendacion DESC; ", conexion);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        derecho.DataSource = dt;
        derecho.DataBind();
    }
}