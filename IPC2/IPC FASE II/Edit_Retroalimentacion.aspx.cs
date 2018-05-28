using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Edit_Retroalimentacion : System.Web.UI.Page
{
    private int identificador;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            identificador = Convert.ToInt32(Request.QueryString["id"]);
            SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SELECT codso, Software.nombre FROM Retroalimentacion "+
                                            "INNER JOIN Software ON "+
                                            "Software.id_software = Retroalimentacion.codso where id_retroalimentacion=" + identificador + "", conexion);
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                software_id.Text =Convert.ToString(registro.GetInt32(0));
                nombre.Text = registro.GetString(1);
                BindData();
                RellenarCampos();
            }
        }
    }

    private void BindData()
    {
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        SqlDataAdapter adaptador = new SqlDataAdapter("SELECT Metricas.id_metricas, Metricas.Nombre FROM Retroalimentacion " +
                                                      "INNER JOIN Retro_metricas ON "+
                                                      "Retro_metricas.idrealim = Retroalimentacion.id_retroalimentacion "+
                                                      "INNER JOIN Metricas ON "+
                                                      "Metricas.id_metricas = Retro_metricas.idmetca where id_retroalimentacion=" + identificador + "", conexion);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        lv.DataSource = dt;
        lv.DataBind();
        conexion.Close();

    }

    protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument.ToString());
        id--;
        if (e.CommandName.ToString() == "imgedit1")
        {
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
           if(DeleteCustomer() == true)
            {
                String usuario = Request.Cookies["UserSettings"]["user"];
                String ventaja = Ventaja.Text;
                String desventaja = Desventaja.Text;
                String comentario = Comentario.Text;
                int frecuencia = Convert.ToInt32(Frecuencia.SelectedValue);
                int software = Convert.ToInt32(software_id.Text);
                //----------------------------------------------------------------------Conexion a Base de Datos--------------------------------------------------------------------
                SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True;Integrated Security=True;MultipleActiveResultSets=True");
                conexion.Open();
                int id = 0;
                String fecha = DateTime.Now.ToShortDateString();
                //------------------------------------------------------------------------Guardar en Retroalimentacion--------------------------------------------------------------------
                SqlCommand insert = new SqlCommand("INSERT INTO Retroalimentacion(Ventaja,Desventaja,Comentario,codusuario,fecha,codfrecuencia,codso) VALUES('" + ventaja + "','" + desventaja + "','" + comentario + "','" + usuario + "','" + fecha + "'," + frecuencia + "," + software + ");", conexion);
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
                            SqlCommand insert_categoria = new SqlCommand("INSERT INTO Retro_metricas(puntaje,idrealim,idmetca) VALUES(" + puntaje + "," + id + "," + idcategoria + ");", conexion);
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

    private Boolean DeleteCustomer()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        String sql1 = "delete from  Retro_metricas where idrealim="+id;
        String sql2= "delete from  Retroalimentacion where id_retroalimentacion=" + id;
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True;MultipleActiveResultSets=True");
        conexion.Open();
        SqlCommand cmds = new SqlCommand (sql1, conexion);
        SqlCommand cmds2 = new SqlCommand(sql2, conexion);
        try
        {
            if (cmds.ExecuteNonQuery() > 0 && cmds2.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (SqlException ee)
        {
            conexion.Close();
            return false;
        }
    }
    //----------------------------------------------------------Mostrar Datos Guardados---------------------------------------------------
    private void RellenarCampos()
    {
        //-----------------------------------------Estrellas--------------------------------------------------------------------------------
        int retro_int = Convert.ToInt32(Request.QueryString["id"]);
        int id = 0;
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True;MultipleActiveResultSets=True");
        conexion.Open();
        SqlCommand cmd = new SqlCommand("SELECT Retro_metricas.puntaje  FROM Retroalimentacion " +
                                                      "INNER JOIN Retro_metricas ON " +
                                                      "Retro_metricas.idrealim = Retroalimentacion.id_retroalimentacion " +
                                                      "INNER JOIN Metricas ON " +
                                                      "Metricas.id_metricas = Retro_metricas.idmetca where id_retroalimentacion=" + retro_int + "", conexion);
        SqlDataReader registro = cmd.ExecuteReader();
        while (registro.Read())
        {
            int puntuaje = registro.GetInt32(0);
            if (puntuaje == 1)
            {
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
            if (puntuaje == 2)
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
            if (puntuaje == 3)
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
            if (puntuaje == 4)
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
            if (puntuaje == 5)
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
            id++;
        }

        //-----------------------------------------------------------Resto de Comentarios-----------------------------------------------------------------
        SqlCommand cmd2 = new SqlCommand("SELECT * FROM Retroalimentacion where id_retroalimentacion=" + retro_int + ";", conexion);
        SqlDataReader registro2 = cmd2.ExecuteReader();
        if (registro2.Read())
        {
            Frecuencia.SelectedIndex = registro2.GetInt32(6);
            Comentario.Text = registro2.GetString(3);
            Ventaja.Text = registro2.GetString(1);
            Desventaja.Text = registro2.GetString(2);
        }
    }
}