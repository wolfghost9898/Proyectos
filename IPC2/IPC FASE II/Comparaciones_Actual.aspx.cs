using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Web.UI.DataVisualization.Charting;

public partial class Comparaciones_Actual : System.Web.UI.Page
{
    private static ArrayList valores;
    private static ArrayList etiquetas;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
            Rellenar();
            //---------------------------------------Verifica que tipo de Usuario es y que puede hacer---------------------------
        }
    }

    private void BindData()
    {
        String usuario = Request.Cookies["UserSettings"]["user"];
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        SqlDataAdapter adaptador = new SqlDataAdapter("SELECT Software.id_software, Software.nombre,Software.Descripcion, Software.Link, Software.Demo, Software.Soporte, Software.Año_Creacion, " +
"Software.Imagen, Empresa_Propietaria.nombre As \"empresa\", Plataforma.tipo,Licencia.descricpcion as \"Licencia\", Categoria=STUFF((SELECT ','+COALESCE(LTRIM(RTRIM(Categoria.nombre)),'') " +
"FROM CategoriaSoftware INNER JOIN Categoria ON " +
"CategoriaSoftware.idcategoria = Categoria.id_venta WHERE  CategoriaSoftware.idsoft = Software.id_software FOR XML PATH('')), 1, 1, '') FROM Software " +
"JOIN Empresa_Propietaria " +
"On codempresa = id_Empresa  JOIN Software_Plataforma " +
"ON Software_Plataforma.idsoftware = Software.id_software JOIN TemporalSoftware On Software.id_software=TemporalSoftware.idsoft JOIN Plataforma " +
"ON Software_Plataforma.idplataforma = Plataforma.id_Plataforma JOIN CategoriaSoftware " +
"ON CategoriaSoftware.idsoft = Software.id_software JOIN Categoria " +
"ON Categoria.id_venta = CategoriaSoftware.idcategoria JOIN LicenciaSoftware ON " +
"LicenciaSoftware.idsoftware = Software.id_software JOIN Licencia ON " +
"Licencia.id_licencia = LicenciaSoftware.idlicencia Where  TemporalSoftware.idus='"+usuario +"' "+
"GROUP BY Software.id_software,Software.nombre,Software.Link,Software.Demo,Licencia.descricpcion,Software.Soporte,Software.Año_Creacion, " +
"Software.Imagen,Empresa_Propietaria.nombre,Plataforma.tipo,Software.Descripcion; ", conexion);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        ListView1.DataSource = dt;
        ListView1.DataBind();


    }

    private void Rellenar()
    {
        String usuario = Request.Cookies["UserSettings"]["user"];
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        SqlCommand adaptador = new SqlCommand("SELECT Software.id_software, Software.nombre,Software.Descripcion, Software.Link, Software.Demo, Software.Soporte, Software.Año_Creacion, " +
                                              "Software.Imagen, Empresa_Propietaria.nombre As \"empresa\", Plataforma.tipo,Licencia.descricpcion as \"Licencia\", Categoria=STUFF((SELECT ','+COALESCE(LTRIM(RTRIM(Categoria.nombre)),'') " +
                                              "FROM CategoriaSoftware INNER JOIN Categoria ON " +
                                                "CategoriaSoftware.idcategoria = Categoria.id_venta WHERE  CategoriaSoftware.idsoft = Software.id_software FOR XML PATH('')), 1, 1, '') FROM Software " +
                                                "JOIN Empresa_Propietaria " +
                                                "On codempresa = id_Empresa  JOIN Software_Plataforma " +
                                                "ON Software_Plataforma.idsoftware = Software.id_software JOIN TemporalSoftware On Software.id_software=TemporalSoftware.idsoft JOIN Plataforma " +
                                                "ON Software_Plataforma.idplataforma = Plataforma.id_Plataforma JOIN CategoriaSoftware " +
                                                "ON CategoriaSoftware.idsoft = Software.id_software JOIN Categoria " +
                                                "ON Categoria.id_venta = CategoriaSoftware.idcategoria JOIN LicenciaSoftware ON " +
                                                "LicenciaSoftware.idsoftware = Software.id_software JOIN Licencia ON " +
                                                "Licencia.id_licencia = LicenciaSoftware.idlicencia Where  TemporalSoftware.idus='" + usuario + "' " +
                                                "GROUP BY Software.id_software,Software.nombre,Software.Link,Software.Demo,Licencia.descricpcion,Software.Soporte,Software.Año_Creacion, " +
                                                "Software.Imagen,Empresa_Propietaria.nombre,Plataforma.tipo,Software.Descripcion; ", conexion);
        conexion.Open();
        SqlDataReader registro = adaptador.ExecuteReader();
        while (registro.Read())
        {
            app_ganadora.Items.Insert(app_ganadora.Items.Count,new ListItem(registro.GetString(1),registro.GetString(1)));
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


    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        valores = new ArrayList();
        etiquetas = new ArrayList();
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        Chart grafica = (Chart)e.Item.FindControl("GRAFICO");
        int id = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "id_software").ToString());
        conexion.Open();
        SqlCommand cmd = new SqlCommand("SELECT Retroalimentacion.codso,Metricas.Nombre,ROUND(AVG(CAST(Retro_metricas.puntaje AS FLOAT)), 2) As \"puntuaje\" FROM Metricas JOIN Retro_metricas " +
                            "ON Retro_metricas.idmetca = Metricas.id_metricas JOIN Retroalimentacion " +
                            "ON Retroalimentacion.id_retroalimentacion = Retro_metricas.idrealim WHERE codso=" + id + "  " +
                            "GROUP BY Retroalimentacion.codso, Metricas.Nombre; ", conexion);
        SqlDataReader read = cmd.ExecuteReader();
        while (read.Read())
        {
            valores.Add(read.GetDouble(2));
            etiquetas.Add(read.GetString(1));
        }
        String[] et = new String[etiquetas.Count];
        int[] val = new int[valores.Count];
        for(int i = 0; i < etiquetas.Count; i++)
        {
            et[i] = Convert.ToString(etiquetas[i]);
            val[i] = Convert.ToInt32(valores[i]);
        }
        read.Close();
        conexion.Close();
        grafica.ChartAreas[0].AxisY.Maximum = 5;
        grafica.Series["Series"].Points.DataBindXY(et, val);

    }

    protected void eliminar_comparacion(object sender, EventArgs e)
    {
        ImageButton boton = (ImageButton)sender;
        String nombre = boton.CommandArgument;
        String usuario = Request.Cookies["UserSettings"]["user"];
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        conexion.Open();
        SqlCommand eliminar = new SqlCommand("DELETE FROM TemporalSoftware WHERE idsoft="+nombre+" AND idus='"+usuario+"';",conexion);
        try
        {
            eliminar.ExecuteNonQuery();
            ListView1.DataBind();
        }
        catch (SqlException ee)
        {
            string script2 = "alert(\"Error Al Elminar\");";
            ScriptManager.RegisterStartupScript(this, GetType(),
                        "ServerControlScript", script2, true);
        }
    }

    protected void boton_guardar_Click(object sender, EventArgs e)
    {
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True;Integrated Security=True;MultipleActiveResultSets=True");
        conexion.Open();
        String App_Ganadora =Convert.ToString(app_ganadora.SelectedItem);
        String usuario = Request.Cookies["UserSettings"]["user"];
        String fecha = DateTime.Now.ToShortDateString();
        //----------------------------------------------------------Guardar en Comparacion-------------------------------------------------------
        SqlCommand insert = new SqlCommand("INSERT INTO Comparaciones(Ap_Ganadora,Fecha,idusuario) VALUES('" + App_Ganadora + "','" + fecha + "','" + usuario+ "');", conexion);
        int id = 0;
        try
        {
            insert.ExecuteNonQuery();
            //----------------------------------------------------Verificar el ultimo valor guardado
            SqlCommand cantidad = new SqlCommand("Select count(*) From Comparaciones", conexion);
            SqlCommand cmd = new SqlCommand("Select MAX(id_comparacion) from Comparaciones", conexion);
            int result = Convert.ToInt32(cantidad.ExecuteScalar());
            if (result > 0)
            {
                id = Convert.ToInt32(cmd.ExecuteScalar());
                SqlCommand tabla_temp = new SqlCommand("Select * From TemporalSoftware Where idus='" + usuario + "'", conexion);
                SqlDataReader reader = tabla_temp.ExecuteReader();
                while (reader.Read())
                {
                    SqlCommand ins_compa = new SqlCommand("INSERT INTO ComparacionSoftware(idcompa,idsoft) Values(" + id + "," + reader.GetInt32(2) + ")",conexion);
                    try
                    {
                        ins_compa.ExecuteNonQuery();
                    }
                    catch(SqlException eee) { }
                }
                SqlCommand delete_temp=new SqlCommand("DELETE FROM TemporalSoftware WHERE idus='" + usuario + "'", conexion);
                try
                {
                    delete_temp.ExecuteNonQuery();
                }
                catch (SqlException eeeeee) { }
            }
        }
        catch (SqlException ee)
        {
            string script2 = "alert(\"Error Al guardar\");";
            ScriptManager.RegisterStartupScript(this, GetType(),
                        "ServerControlScript", script2, true);
        }
    }
}