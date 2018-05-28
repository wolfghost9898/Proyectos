using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Retroalimentacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
            int id =Convert.ToInt32( Request.QueryString["id"]);
            SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
            conexion.Open();
            SqlCommand cmd = new SqlCommand("Select * from Software where id_software=" + id + "", conexion);
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                nombre.Text = registro.GetString(1);
            }
        }
    }

    private void BindData()
    {
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM Metricas ", conexion);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        lv.DataSource = dt;
        lv.DataBind();
    }

    protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument.ToString());
        id--;
        if (e.CommandName.ToString() == "imgedit1") {
            ImageButton imgedit1 = (ImageButton)lv.Items[id].FindControl("imgedit1");
            imgedit1.ImageUrl = "imagenes/star-fill-lg.png";
            ImageButton imgedit2 = (ImageButton)lv.Items[id].FindControl("imgedit2");
            imgedit2.ImageUrl = "imagenes/star-empty-lg.png";
            ImageButton imgedit3 = (ImageButton)lv.Items[id].FindControl("imgedit3");
            imgedit3.ImageUrl = "imagenes/star-empty-lg.png";
            ImageButton imgedit4 = (ImageButton)lv.Items[id].FindControl("imgedit4");
            imgedit4.ImageUrl = "imagenes/star-empty-lg.png";
            ImageButton imgedit5 = (ImageButton)lv.Items[id].FindControl("imgedit5");
            imgedit5.ImageUrl = "imagenes/star-empty-lg.png";
        }
        if (e.CommandName.ToString() == "imgedit2")
        {
            ImageButton imgedit1 = (ImageButton)lv.Items[id].FindControl("imgedit1");
            imgedit1.ImageUrl = "imagenes/star-fill-lg.png";
            ImageButton imgedit2 = (ImageButton)lv.Items[id].FindControl("imgedit2");
            imgedit2.ImageUrl = "imagenes/star-fill-lg.png";
            ImageButton imgedit3 = (ImageButton)lv.Items[id].FindControl("imgedit3");
            imgedit3.ImageUrl = "imagenes/star-empty-lg.png";
            ImageButton imgedit4 = (ImageButton)lv.Items[id].FindControl("imgedit4");
            imgedit4.ImageUrl = "imagenes/star-empty-lg.png";
            ImageButton imgedit5 = (ImageButton)lv.Items[id].FindControl("imgedit5");
            imgedit5.ImageUrl = "imagenes/star-empty-lg.png";
        }
        if (e.CommandName.ToString() == "imgedit3")
        {
            ImageButton imgedit1 = (ImageButton)lv.Items[id].FindControl("imgedit1");
            imgedit1.ImageUrl = "imagenes/star-fill-lg.png";
            ImageButton imgedit2 = (ImageButton)lv.Items[id].FindControl("imgedit2");
            imgedit2.ImageUrl = "imagenes/star-fill-lg.png";
            ImageButton imgedit3 = (ImageButton)lv.Items[id].FindControl("imgedit3");
            imgedit3.ImageUrl = "imagenes/star-fill-lg.png";
            ImageButton imgedit4 = (ImageButton)lv.Items[id].FindControl("imgedit4");
            imgedit4.ImageUrl = "imagenes/star-empty-lg.png";
            ImageButton imgedit5 = (ImageButton)lv.Items[id].FindControl("imgedit5");
            imgedit5.ImageUrl = "imagenes/star-empty-lg.png";
        }
        if (e.CommandName.ToString() == "imgedit4")
        {
            ImageButton imgedit1 = (ImageButton)lv.Items[id].FindControl("imgedit1");
            imgedit1.ImageUrl = "imagenes/star-fill-lg.png";
            ImageButton imgedit2 = (ImageButton)lv.Items[id].FindControl("imgedit2");
            imgedit2.ImageUrl = "imagenes/star-fill-lg.png";
            ImageButton imgedit3 = (ImageButton)lv.Items[id].FindControl("imgedit3");
            imgedit3.ImageUrl = "imagenes/star-fill-lg.png";
            ImageButton imgedit4 = (ImageButton)lv.Items[id].FindControl("imgedit4");
            imgedit4.ImageUrl = "imagenes/star-fill-lg.png";
            ImageButton imgedit5 = (ImageButton)lv.Items[id].FindControl("imgedit5");
            imgedit5.ImageUrl = "imagenes/star-empty-lg.png";
        }
        if (e.CommandName.ToString() == "imgedit5")
        {
            ImageButton imgedit1 = (ImageButton)lv.Items[id].FindControl("imgedit1");
            imgedit1.ImageUrl = "imagenes/star-fill-lg.png";
            ImageButton imgedit2 = (ImageButton)lv.Items[id].FindControl("imgedit2");
            imgedit2.ImageUrl = "imagenes/star-fill-lg.png";
            ImageButton imgedit3 = (ImageButton)lv.Items[id].FindControl("imgedit3");
            imgedit3.ImageUrl = "imagenes/star-fill-lg.png";
            ImageButton imgedit4 = (ImageButton)lv.Items[id].FindControl("imgedit4");
            imgedit4.ImageUrl = "imagenes/star-fill-lg.png";
            ImageButton imgedit5 = (ImageButton)lv.Items[id].FindControl("imgedit5");
            imgedit5.ImageUrl = "imagenes/star-fill-lg.png";
        }
    }

    protected void save_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
            {
                String usuario = Request.Cookies["UserSettings"]["user"];
            String ventaja = Ventaja.Text;
            String desventaja = Desventaja.Text;
            String comentario = Comentario.Text;
            int frecuencia =Convert.ToInt32( Frecuencia.SelectedValue);
            int software= Convert.ToInt32(Request.QueryString["id"]);
    //----------------------------------------------------------------------Conexion a Base de Datos--------------------------------------------------------------------
            SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True;Integrated Security=True;MultipleActiveResultSets=True");
            conexion.Open();
            int id = 0;
            String fecha = DateTime.Now.ToShortDateString();
            //------------------------------------------------------------------------Guardar en Retroalimentacion--------------------------------------------------------------------
            SqlCommand insert = new SqlCommand("INSERT INTO Retroalimentacion(Ventaja,Desventaja,Comentario,codusuario,fecha,codfrecuencia,codso) VALUES('" + ventaja + "','" + desventaja + "','" + comentario + "','" + usuario + "','"+fecha+"'," + frecuencia + "," + software + ");", conexion);
            try
            {
                //----------------------------------------------------------Verificar Ultimo Guardado------------------------------------------------------

                insert.ExecuteNonQuery();
                SqlCommand cantidad = new SqlCommand("Select count(*) From Retroalimentacion", conexion);
                SqlCommand cmd = new SqlCommand("Select MAX(id_retroalimentacion) from Retroalimentacion", conexion);
                int result = Convert.ToInt32(cantidad.ExecuteScalar());
                if (result > 0)
                {
                    id = Convert.ToInt32(cmd.ExecuteScalar());

                }
                //--------------------------------------------------------------------GUARDAR EN INTERMEDIA RETRO-METRICA------------------------------------------------------------------
                for (int i = 0; i < lv.Items.Count; i++)
                {
                    ImageButton imgedit1 = (ImageButton)lv.Items[i].FindControl("imgedit1");
                    ImageButton imgedit2 = (ImageButton)lv.Items[i].FindControl("imgedit2");
                    ImageButton imgedit3 = (ImageButton)lv.Items[i].FindControl("imgedit3");
                    ImageButton imgedit4 = (ImageButton)lv.Items[i].FindControl("imgedit4");
                    ImageButton imgedit5 = (ImageButton)lv.Items[i].FindControl("imgedit5");
                    Label categoria = (Label)lv.Items[i].FindControl("Label1");
                    SqlCommand categoriab = new SqlCommand("Select * from Metricas where Nombre='" + categoria.Text + "'", conexion); //Buscamos la Metrica
                    SqlDataReader registro_busqueda = categoriab.ExecuteReader();
                    while (registro_busqueda.Read())
                    {
                        int puntaje = 0;
                        if (imgedit5.ImageUrl == "imagenes/star-fill-lg.png")
                        {
                            puntaje = 5;
                        }
                        else if (imgedit4.ImageUrl == "imagenes/star-fill-lg.png")
                        {
                            puntaje = 4;
                        }
                        else if (imgedit3.ImageUrl == "imagenes/star-fill-lg.png")
                        {
                            puntaje = 3;
                        }
                        else if (imgedit2.ImageUrl == "imagenes/star-fill-lg.png")
                        {
                            puntaje = 2;
                        }
                        else if (imgedit1.ImageUrl == "imagenes/star-fill-lg.png")
                        {
                            puntaje = 1;
                        }
                        int idcategoria = registro_busqueda.GetInt32(0);
                        SqlCommand insert_categoria = new SqlCommand("INSERT INTO Retro_metricas(puntaje,idrealim,idmetca) VALUES(" + puntaje + "," + id + ","+idcategoria+");", conexion);
                        try
                        {
                            insert_categoria.ExecuteNonQuery();
                        }
                        catch (SqlException ee)
                        {
                            string script2 = "alert(\"Error Al guardar 2\");";
                            ScriptManager.RegisterStartupScript(this, GetType(),
                                        "ServerControlScript", script2, true);
                        }

                    }


                    

                }

            }
            catch (SqlException ee)
            {
                string script2 = "alert(\"Error Al guardar\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                            "ServerControlScript", script2, true);
            }

            Ventaja.Text = "";
            Desventaja.Text = "";
            Comentario.Text = "";




        }
    }
}