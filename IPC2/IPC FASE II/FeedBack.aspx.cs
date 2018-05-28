using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class FeedBack : System.Web.UI.Page
{
    private int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            id = Convert.ToInt32(Request.QueryString["id"]);
            SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
            conexion.Open();
            SqlCommand cmd = new SqlCommand("Select * from Software where id_software=" + id + "", conexion);
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                nombre.Text = registro.GetString(1);
                BindData();
            }
        }
    }

    private void BindData()
    {
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        SqlDataAdapter adaptador = new SqlDataAdapter("SELECT Retroalimentacion.codso,Metricas.Nombre,ROUND(AVG(CAST(Retro_metricas.puntaje AS FLOAT)), 2) As \"puntuaje\" FROM Metricas JOIN Retro_metricas " +
                                    "ON Retro_metricas.idmetca = Metricas.id_metricas JOIN Retroalimentacion "+ 
                                    "ON Retroalimentacion.id_retroalimentacion = Retro_metricas.idrealim WHERE codso="+id+"  "+
                                    "GROUP BY Retroalimentacion.codso, Metricas.Nombre; ", conexion);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        izquierdo.DataSource = dt;
        izquierdo.DataBind();


        SqlDataAdapter adaptador2 = new SqlDataAdapter("SELECT Usuario.id_usuario,Retroalimentacion.Comentario,Retroalimentacion.fecha FROM Retroalimentacion JOIN Usuario " +
                                                       "ON Usuario.id_usuario = Retroalimentacion.codusuario  WHERE codso=" + id + "  "+
                                                       "GROUP BY Usuario.id_usuario, Retroalimentacion.Comentario,Retroalimentacion.fecha,Retroalimentacion.id_retroalimentacion "+
                                                       "ORDER  BY  Retroalimentacion.id_retroalimentacion DESC", conexion);
        DataTable dt2 = new DataTable();
        adaptador2.Fill(dt2);
        derecho.DataSource = dt2;
        derecho.DataBind();


    }
}