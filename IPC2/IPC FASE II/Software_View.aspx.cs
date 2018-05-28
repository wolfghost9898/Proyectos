using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Software_View : System.Web.UI.Page
{
    private static int id_software;
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
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        SqlDataAdapter adaptador = new SqlDataAdapter("SELECT Software.id_software, Software.nombre,Software.Descripcion, Software.Link, Software.Demo, Software.Soporte, Software.Año_Creacion, " +
"Software.Imagen, Empresa_Propietaria.nombre As \"empresa\", Plataforma.tipo,Licencia.descricpcion as \"Licencia\", Categoria=STUFF((SELECT ','+COALESCE(LTRIM(RTRIM(Categoria.nombre)),'') " +
"FROM CategoriaSoftware INNER JOIN Categoria ON " +
"CategoriaSoftware.idcategoria = Categoria.id_venta WHERE  CategoriaSoftware.idsoft = Software.id_software FOR XML PATH('')), 1, 1, '') FROM Software " +
"JOIN Empresa_Propietaria " +
"On codempresa = id_Empresa  JOIN Software_Plataforma " +
"ON Software_Plataforma.idsoftware = Software.id_software JOIN Plataforma " +
"ON Software_Plataforma.idplataforma = Plataforma.id_Plataforma JOIN CategoriaSoftware " +
"ON CategoriaSoftware.idsoft = Software.id_software JOIN Categoria " +
"ON Categoria.id_venta = CategoriaSoftware.idcategoria JOIN LicenciaSoftware ON " +
"LicenciaSoftware.idsoftware = Software.id_software JOIN Licencia ON " +
"Licencia.id_licencia = LicenciaSoftware.idlicencia " +
"GROUP BY Software.id_software,Software.nombre,Software.Link,Software.Demo,Licencia.descricpcion,Software.Soporte,Software.Año_Creacion, " +
"Software.Imagen,Empresa_Propietaria.nombre,Plataforma.tipo,Software.Descripcion; ", conexion);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        ListView1.DataSource = dt;
        ListView1.DataBind();


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


    private void Rellenar()
    {
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True;MultipleActiveResultSets=True");
        conexion.Open();
        //-------------------------------------------------------------------Categorias
        SqlCommand cmd = new SqlCommand("Select * from Categoria;", conexion);
        SqlDataReader registro = cmd.ExecuteReader();
        while (registro.Read())
        {
            categoria.Items.Insert(categoria.Items.Count, new ListItem(registro.GetString(2), Convert.ToString(registro.GetInt32(0))));
        }
        registro.Close();
        //-------------------------------------------------------------------Empresa-------------------------------------------------
        SqlCommand cmd2 = new SqlCommand("Select * from Empresa_Propietaria;", conexion);
        SqlDataReader registro2 = cmd2.ExecuteReader();
        while (registro2.Read())
        {
            Empresa.Items.Insert(Empresa.Items.Count, new ListItem(registro2.GetString(1), Convert.ToString(registro2.GetInt32(0))));
        }
        registro2.Close();
        //-----------------------------------------------------------------Plataforma-------------------------------------------------------
        SqlCommand cmd3 = new SqlCommand("Select * from Plataforma;", conexion);
        SqlDataReader registro3 = cmd3.ExecuteReader();
        while (registro3.Read())
        {
            Plataforma.Items.Insert(Plataforma.Items.Count, new ListItem(registro3.GetString(1), Convert.ToString(registro3.GetInt32(0))));
        }
        registro3.Close();

        SqlCommand cmd4 = new SqlCommand("Select * from Licencia;", conexion);
        SqlDataReader registro4 = cmd4.ExecuteReader();
        while (registro4.Read())
        {
            Licencia.Items.Insert(Licencia.Items.Count, new ListItem(registro4.GetString(1), Convert.ToString(registro4.GetInt32(0))));
        }
        registro4.Close();
        conexion.Close();
    }



    protected void Software_Click(object sender, EventArgs e)
    {
        Button boton = (Button)sender;
        String nombre = boton.CommandArgument;
        Response.Redirect("Retroalimentacion.aspx?id="+nombre);
    }

    protected void FeedBack_Click(object sender, EventArgs e)
    {
        Button boton = (Button)sender;
        String nombre = boton.CommandArgument;
        Response.Redirect("FeedBack.aspx?id=" + nombre);
    }


    //-----------------------------------------------BUSQUEDAS--------------------------------------------------------

    protected void Empresa_SelectedIndexChanged(object sender, EventArgs e)
    {
        String nombre = Empresa.SelectedItem.Text;
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        SqlCommand foranea = new SqlCommand();
        foranea.CommandType = CommandType.Text;
        foranea.CommandText = "SELECT Software.id_software, Software.nombre,Software.Descripcion, Software.Link, Software.Demo, Software.Soporte, Software.Año_Creacion, " +
"Software.Imagen, Empresa_Propietaria.nombre As \"empresa\", Plataforma.tipo,Licencia.descricpcion as \"Licencia\", Categoria=STUFF((SELECT ','+COALESCE(LTRIM(RTRIM(Categoria.nombre)),'') " +
"FROM CategoriaSoftware INNER JOIN Categoria ON " +
"CategoriaSoftware.idcategoria = Categoria.id_venta WHERE  CategoriaSoftware.idsoft = Software.id_software FOR XML PATH('')), 1, 1, '') FROM Software " +
"JOIN Empresa_Propietaria " +
"On codempresa = id_Empresa  JOIN Software_Plataforma " +
"ON Software_Plataforma.idsoftware = Software.id_software JOIN Plataforma " +
"ON Software_Plataforma.idplataforma = Plataforma.id_Plataforma JOIN CategoriaSoftware " +
"ON CategoriaSoftware.idsoft = Software.id_software JOIN Categoria " +
"ON Categoria.id_venta = CategoriaSoftware.idcategoria JOIN LicenciaSoftware ON " +
"LicenciaSoftware.idsoftware = Software.id_software JOIN Licencia ON " +
"Licencia.id_licencia = LicenciaSoftware.idlicencia WHERE Empresa_Propietaria.nombre=@empresa " +
"GROUP BY Software.id_software,Software.nombre,Software.Link,Software.Demo,Licencia.descricpcion,Software.Soporte,Software.Año_Creacion, " +
"Software.Imagen,Empresa_Propietaria.nombre,Plataforma.tipo,Software.Descripcion ; ";
        foranea.Parameters.Add("@empresa", SqlDbType.VarChar).Value = nombre;

        ListView1.DataSource = GetData(foranea, conexion);
        ListView1.DataBind();
    }

    protected void categoria_SelectedIndexChanged(object sender, EventArgs e)
    {
        String nombre = categoria.SelectedItem.Text;
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        SqlCommand foranea = new SqlCommand();
        foranea.CommandType = CommandType.Text;
        foranea.CommandText = "SELECT Software.id_software, Software.nombre,Software.Descripcion, Software.Link, Software.Demo, Software.Soporte, Software.Año_Creacion, " +
"Software.Imagen, Empresa_Propietaria.nombre As \"empresa\", Plataforma.tipo,Licencia.descricpcion as \"Licencia\", Categoria=STUFF((SELECT ','+COALESCE(LTRIM(RTRIM(Categoria.nombre)),'') " +
"FROM CategoriaSoftware INNER JOIN Categoria ON " +
"CategoriaSoftware.idcategoria = Categoria.id_venta WHERE  CategoriaSoftware.idsoft = Software.id_software FOR XML PATH('')), 1, 1, '') FROM Software " +
"JOIN Empresa_Propietaria " +
"On codempresa = id_Empresa  JOIN Software_Plataforma " +
"ON Software_Plataforma.idsoftware = Software.id_software JOIN Plataforma " +
"ON Software_Plataforma.idplataforma = Plataforma.id_Plataforma JOIN CategoriaSoftware " +
"ON CategoriaSoftware.idsoft = Software.id_software JOIN Categoria " +
"ON Categoria.id_venta = CategoriaSoftware.idcategoria JOIN LicenciaSoftware ON " +
"LicenciaSoftware.idsoftware = Software.id_software JOIN Licencia ON " +
"Licencia.id_licencia = LicenciaSoftware.idlicencia WHERE Categoria.nombre=@categoria " +
"GROUP BY Software.id_software,Software.nombre,Software.Link,Software.Demo,Licencia.descricpcion,Software.Soporte,Software.Año_Creacion, " +
"Software.Imagen,Empresa_Propietaria.nombre,Plataforma.tipo,Software.Descripcion ; ";
        foranea.Parameters.Add("@categoria", SqlDbType.VarChar).Value = nombre;

        ListView1.DataSource = GetData(foranea, conexion);
        ListView1.DataBind();
    }

    protected void Plataforma_SelectedIndexChanged(object sender, EventArgs e)
    {

        String nombre = Plataforma.SelectedItem.Text;
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        SqlCommand foranea = new SqlCommand();
        foranea.CommandType = CommandType.Text;
        foranea.CommandText = "SELECT Software.id_software, Software.nombre,Software.Descripcion, Software.Link, Software.Demo, Software.Soporte, Software.Año_Creacion, " +
"Software.Imagen, Empresa_Propietaria.nombre As \"empresa\", Plataforma.tipo,Licencia.descricpcion as \"Licencia\", Categoria=STUFF((SELECT ','+COALESCE(LTRIM(RTRIM(Categoria.nombre)),'') " +
"FROM CategoriaSoftware INNER JOIN Categoria ON " +
"CategoriaSoftware.idcategoria = Categoria.id_venta WHERE  CategoriaSoftware.idsoft = Software.id_software FOR XML PATH('')), 1, 1, '') FROM Software " +
"JOIN Empresa_Propietaria " +
"On codempresa = id_Empresa  JOIN Software_Plataforma " +
"ON Software_Plataforma.idsoftware = Software.id_software JOIN Plataforma " +
"ON Software_Plataforma.idplataforma = Plataforma.id_Plataforma JOIN CategoriaSoftware " +
"ON CategoriaSoftware.idsoft = Software.id_software JOIN Categoria " +
"ON Categoria.id_venta = CategoriaSoftware.idcategoria JOIN LicenciaSoftware ON " +
"LicenciaSoftware.idsoftware = Software.id_software JOIN Licencia ON " +
"Licencia.id_licencia = LicenciaSoftware.idlicencia WHERE Plataforma.tipo=@categoria " +
"GROUP BY Software.id_software,Software.nombre,Software.Link,Software.Demo,Licencia.descricpcion,Software.Soporte,Software.Año_Creacion, " +
"Software.Imagen,Empresa_Propietaria.nombre,Plataforma.tipo,Software.Descripcion ; ";
        foranea.Parameters.Add("@categoria", SqlDbType.VarChar).Value = nombre;

        ListView1.DataSource = GetData(foranea, conexion);
        ListView1.DataBind();
    }

    protected void Licencia_SelectedIndexChanged(object sender, EventArgs e)
    {

        String nombre = Licencia.SelectedItem.Text;
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        SqlCommand foranea = new SqlCommand();
        foranea.CommandType = CommandType.Text;
        foranea.CommandText = "SELECT Software.id_software, Software.nombre,Software.Descripcion, Software.Link, Software.Demo, Software.Soporte, Software.Año_Creacion, " +
"Software.Imagen, Empresa_Propietaria.nombre As \"empresa\", Plataforma.tipo,Licencia.descricpcion as \"Licencia\", Categoria=STUFF((SELECT ','+COALESCE(LTRIM(RTRIM(Categoria.nombre)),'') " +
"FROM CategoriaSoftware INNER JOIN Categoria ON " +
"CategoriaSoftware.idcategoria = Categoria.id_venta WHERE  CategoriaSoftware.idsoft = Software.id_software FOR XML PATH('')), 1, 1, '') FROM Software " +
"JOIN Empresa_Propietaria " +
"On codempresa = id_Empresa  JOIN Software_Plataforma " +
"ON Software_Plataforma.idsoftware = Software.id_software JOIN Plataforma " +
"ON Software_Plataforma.idplataforma = Plataforma.id_Plataforma JOIN CategoriaSoftware " +
"ON CategoriaSoftware.idsoft = Software.id_software JOIN Categoria " +
"ON Categoria.id_venta = CategoriaSoftware.idcategoria JOIN LicenciaSoftware ON " +
"LicenciaSoftware.idsoftware = Software.id_software JOIN Licencia ON " +
"Licencia.id_licencia = LicenciaSoftware.idlicencia WHERE Licencia.descricpcion=@categoria " +
"GROUP BY Software.id_software,Software.nombre,Software.Link,Software.Demo,Licencia.descricpcion,Software.Soporte,Software.Año_Creacion, " +
"Software.Imagen,Empresa_Propietaria.nombre,Plataforma.tipo,Software.Descripcion ; ";
        foranea.Parameters.Add("@categoria", SqlDbType.VarChar).Value = nombre;

        ListView1.DataSource = GetData(foranea, conexion);
        ListView1.DataBind();
    }

    protected void busqueda_TextChanged(object sender, EventArgs e)
    {
        String nombre = busqueda.Text;
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        SqlCommand foranea = new SqlCommand();
        foranea.CommandType = CommandType.Text;
        foranea.CommandText = "SELECT Software.id_software, Software.nombre,Software.Descripcion, Software.Link, Software.Demo, Software.Soporte, Software.Año_Creacion, " +
"Software.Imagen, Empresa_Propietaria.nombre As \"empresa\", Plataforma.tipo,Licencia.descricpcion as \"Licencia\", Categoria=STUFF((SELECT ','+COALESCE(LTRIM(RTRIM(Categoria.nombre)),'') " +
"FROM CategoriaSoftware INNER JOIN Categoria ON " +
"CategoriaSoftware.idcategoria = Categoria.id_venta WHERE  CategoriaSoftware.idsoft = Software.id_software FOR XML PATH('')), 1, 1, '') FROM Software " +
"JOIN Empresa_Propietaria " +
"On codempresa = id_Empresa  JOIN Software_Plataforma " +
"ON Software_Plataforma.idsoftware = Software.id_software JOIN Plataforma " +
"ON Software_Plataforma.idplataforma = Plataforma.id_Plataforma JOIN CategoriaSoftware " +
"ON CategoriaSoftware.idsoft = Software.id_software JOIN Categoria " +
"ON Categoria.id_venta = CategoriaSoftware.idcategoria JOIN LicenciaSoftware ON " +
"LicenciaSoftware.idsoftware = Software.id_software JOIN Licencia ON " +
"Licencia.id_licencia = LicenciaSoftware.idlicencia WHERE Software.nombre LIKE @categoria " +
"GROUP BY Software.id_software,Software.nombre,Software.Link,Software.Demo,Licencia.descricpcion,Software.Soporte,Software.Año_Creacion, " +
"Software.Imagen,Empresa_Propietaria.nombre,Plataforma.tipo,Software.Descripcion ; ";
        foranea.Parameters.Add("@categoria", SqlDbType.VarChar).Value = "%"+nombre+"%";

        ListView1.DataSource = GetData(foranea, conexion);
        ListView1.DataBind();

    }



    protected void ListView1_ItemCreated(object sender, ListViewItemEventArgs e)
    {
        if (Request.Cookies["UserSettings"] != null)
        {
            string tipo;
            tipo = Request.Cookies["UserSettings"]["tipo"];
            if (tipo == "3")
            {
                (e.Item.FindControl("share_button") as ImageButton).Visible = true;
                (e.Item.FindControl("agregar_button") as ImageButton).Visible = true;
            }
        }
    }

    //---------------------------------------------------------------------Compartir y Agregar----------------------------------------------------
    protected void Compartir_Click(object sender, EventArgs e)
    {
        ImageButton boton = (ImageButton)sender;
        String id = boton.CommandArgument;
        id_software = Convert.ToInt32(id);
        mpePopUp.Show();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        mpePopUp.Hide();
    }
    //--------------------------------------------------------------Guardar Recomendacion----------------------------------------------------------------------------
    protected void btnOk_Click(object sender, EventArgs e)
    {
        String comentarios = comentario.Text;
        String fecha = DateTime.Now.ToShortDateString();
        String usuario = Request.Cookies["UserSettings"]["user"];
        int id_softt = id_software;
        
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        conexion.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO Recomendacion(Comentario,fecha,coduser,idsoft) VALUES(\'" + comentarios + "\',\'" + fecha + "\','" + usuario + "',"+id_softt+");", conexion);
        try
        {
            cmd.ExecuteNonQuery();
            string script3 = "alert(\"Recomendacion Realizada\");";
            ScriptManager.RegisterStartupScript(this, GetType(),
                        "ServerControlScript", script3, true);
            mpePopUp.Hide();

        }
        catch (SqlException ee)
        {
            string script2 = "alert(\"Error Al guardar\");";
            ScriptManager.RegisterStartupScript(this, GetType(),
                        "ServerControlScript", script2, true);
        }
        comentario.Text = "";
    }

    //--------------------------------------------------------------Agregar a Comparacion---------------------------------------------------------------------------
    protected void Agregar_Click(object sender, EventArgs e)
    {
        ImageButton boton = (ImageButton)sender;
        String id = boton.CommandArgument;
        id_software = Convert.ToInt32(id);
        String usuario = Request.Cookies["UserSettings"]["user"];

        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        conexion.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO TemporalSoftware(idus,idsoft) VALUES(\'" + usuario + "\'," + id_software + ");", conexion);
        try
        {
            cmd.ExecuteNonQuery();
            string script = "alert(\"Agregado Exitosamente\");";
            ScriptManager.RegisterStartupScript(this, GetType(),
                        "ServerControlScript", script, true);
        }
        catch (SqlException ee)
        {
            string script2 = "alert(\"Error Al Agregar\");";
            ScriptManager.RegisterStartupScript(this, GetType(),
                        "ServerControlScript", script2, true);
        }

    }
}