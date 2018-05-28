using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.HtmlControls;

public partial class Ver_Comparacion : System.Web.UI.Page
{
    private static ArrayList valores;
    private static ArrayList etiquetas;
    private static String nombre_ganadora;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Guardar_Ganadora();
            BindData();
        }
    }

    private void BindData()
    {
        int identificador = Convert.ToInt32(Request.QueryString["id"]);
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        SqlDataAdapter adaptador = new SqlDataAdapter("SELECT Software.id_software, Software.nombre,Software.Descripcion, Software.Link, Software.Demo, Software.Soporte, Software.Año_Creacion, " +
                                                      "Software.Imagen, Empresa_Propietaria.nombre As empresa, Plataforma.tipo, Licencia.descricpcion as Licencia, Categoria = STUFF((SELECT ',' + COALESCE(LTRIM(RTRIM(Categoria.nombre)), '') " +
                                                      "FROM CategoriaSoftware INNER JOIN Categoria ON " +
                                                      "CategoriaSoftware.idcategoria = Categoria.id_venta WHERE  CategoriaSoftware.idsoft = Software.id_software FOR XML PATH('')), 1, 1, '') " +
                                                      "FROM Comparaciones " +
                                                      "JOIN ComparacionSoftware ON ComparacionSoftware.idcompa = Comparaciones.id_comparacion " +
                                                      "JOIN Software ON Software.id_software = ComparacionSoftware.idsoft " +
                                                      "JOIN Empresa_Propietaria " +
                                                      "On codempresa = id_Empresa  JOIN Software_Plataforma " +
                                                      "ON Software_Plataforma.idsoftware = Software.id_software JOIN Plataforma " +
                                                      "ON Software_Plataforma.idplataforma = Plataforma.id_Plataforma JOIN CategoriaSoftware " +
                                                      "ON CategoriaSoftware.idsoft = Software.id_software JOIN Categoria " +
                                                      "ON Categoria.id_venta = CategoriaSoftware.idcategoria JOIN LicenciaSoftware ON " +
                                                      "LicenciaSoftware.idsoftware = Software.id_software JOIN Licencia ON " +
                                                      "Licencia.id_licencia = LicenciaSoftware.idlicencia WHERE Comparaciones.id_comparacion =" + identificador+" "+
                                                      "GROUP BY Software.id_software,Software.nombre,Software.Link,Software.Demo,Licencia.descricpcion,Software.Soporte,Software.Año_Creacion,  "+
                                                      "Software.Imagen,Empresa_Propietaria.nombre,Plataforma.tipo,Software.Descripcion; ", conexion);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        ListView1.DataSource = dt;
        ListView1.DataBind();


    }

    private void Guardar_Ganadora()
    {
        int identificador = Convert.ToInt32(Request.QueryString["id"]);
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        SqlCommand ganadora = new SqlCommand("SELECT * FROM Comparaciones where id_comparacion=" + identificador + ";", conexion);
        conexion.Open();
        SqlDataReader reader = ganadora.ExecuteReader();
        if (reader.Read())
        {
            nombre_ganadora = reader.GetString(1);
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
        Label nombre_sof = (Label)e.Item.FindControl("nombre_soft");
        Label nombre_gg = (Label)e.Item.FindControl("nombre_ganadora");
        HtmlGenericControl div = (HtmlGenericControl)e.Item.FindControl("contenedor_todo");
        if (nombre_sof.Text.Equals(nombre_ganadora))
        {
            nombre_gg.Visible = true;
            div.Style["background"] = "#4CAF50";
        }
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
        for (int i = 0; i < etiquetas.Count; i++)
        {
            et[i] = Convert.ToString(etiquetas[i]);
            val[i] = Convert.ToInt32(valores[i]);
        }
        read.Close();
        conexion.Close();
        grafica.ChartAreas[0].AxisY.Maximum = 5;
        grafica.Series["Series"].Points.DataBindXY(et, val);

    }

}