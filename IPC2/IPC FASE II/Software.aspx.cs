using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

public partial class Software : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Rellenar();
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
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        SqlCommand cmd = new SqlCommand("SELECT Software.id_software, Software.nombre,Software.Descripcion, Software.Link, Software.Demo, Software.Soporte, Software.Año_Creacion, " +
"Software.Imagen, Empresa_Propietaria.nombre As \"empresa\", Plataforma.tipo,Licencia.descricpcion as \"Licencia\", Categoria=STUFF((SELECT ','+COALESCE(LTRIM(RTRIM(Categoria.nombre)),'') " +
"FROM CategoriaSoftware INNER JOIN Categoria ON " +
"CategoriaSoftware.idcategoria = Categoria.id_venta WHERE  CategoriaSoftware.idsoft = Software.id_software FOR XML PATH('')), 1, 1, '') FROM Software " +
"JOIN Empresa_Propietaria " +
"On codempresa = id_Empresa  JOIN Software_Plataforma "+
"ON Software_Plataforma.idsoftware = Software.id_software JOIN Plataforma "+
"ON Software_Plataforma.idplataforma = Plataforma.id_Plataforma JOIN CategoriaSoftware "+
"ON CategoriaSoftware.idsoft = Software.id_software JOIN Categoria "+
"ON Categoria.id_venta = CategoriaSoftware.idcategoria JOIN LicenciaSoftware ON "+
"LicenciaSoftware.idsoftware = Software.id_software JOIN Licencia ON "+
"Licencia.id_licencia = LicenciaSoftware.idlicencia "+
"GROUP BY Software.id_software,Software.nombre,Software.Link,Software.Demo,Licencia.descricpcion,Software.Soporte,Software.Año_Creacion, " +
"Software.Imagen,Empresa_Propietaria.nombre,Plataforma.tipo,Software.Descripcion; ");
         GridView1.DataSource = GetData(cmd, conexion);
        GridView1.DataBind();
    }

    protected void boton_guardar_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {


        String Nombre = nombre.Text;
        String descripcion = Descripcion.Text;
        String Demo = demo.Text;
        String soporte = Soporte.Text;
        int Año = Convert.ToInt32(año.Text);
        String direccion = url.Text;
        String imagen_direccion = Path.GetFileName(imagen.PostedFile.FileName);
        imagen.PostedFile.SaveAs(Server.MapPath("IMAGENES_SERVIDOR/") + imagen_direccion);
            int empresa = Convert.ToInt32(Empresa.SelectedValue);

        int idlicencia = Convert.ToInt32(Licencia.SelectedValue);
        int idplataforma = Convert.ToInt32(Plataforma.SelectedValue);

        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True;Integrated Security=True;MultipleActiveResultSets=True");
        conexion.Open();

        //-----------------------------------------------------------Guardar en Empresa-------------------------------------------
        SqlCommand insert = new SqlCommand("INSERT INTO Software(nombre,Descripcion,Link,Demo,Soporte,Año_Creacion,Imagen,codempresa) VALUES('" + Nombre + "','" + descripcion + "','" + direccion + "','" + Demo + "','" + soporte + "'," + Año + ",'" + "IMAGENES_SERVIDOR/"+imagen_direccion + "'," + empresa + ");", conexion);
        int id = 0;
        try
        {
            insert.ExecuteNonQuery();
            //----------------------------------------------------Verificar el ultimo valor guardado
            SqlCommand cantidad = new SqlCommand("Select count(*) From Software", conexion);
            SqlCommand cmd = new SqlCommand("Select MAX(id_software) from Software", conexion);
            int result = Convert.ToInt32(cantidad.ExecuteScalar());
            if (result > 0)
            {
                id = Convert.ToInt32(cmd.ExecuteScalar()) ;

            }
        }
        catch (SqlException ee)
        {
            string script2 = "alert(\"Error Al guardar\");";
            ScriptManager.RegisterStartupScript(this, GetType(),
                        "ServerControlScript", script2, true);
        }

        //---------------------------------------------------Guardar en Licencia-----------------------------------------------------
        SqlCommand insert_licencia= new SqlCommand("INSERT INTO LicenciaSoftware(idlicencia,idsoftware) VALUES(" + idlicencia + "," + id + ");", conexion);
        try
        {
            insert_licencia.ExecuteNonQuery();
        }
        catch (SqlException ee)
        {
            string script2 = "alert(\"Error Al guardar\");";
            ScriptManager.RegisterStartupScript(this, GetType(),
                        "ServerControlScript", script2, true);
        }

        //---------------------------------------------------Guardar en Plataforma---------------------------------
        SqlCommand insert_plataforma = new SqlCommand("INSERT INTO Software_Plataforma(idsoftware,idplataforma) VALUES(" + id + "," + idplataforma + ");", conexion);
        try
        {
            insert_plataforma.ExecuteNonQuery();
        }
        catch (SqlException ee)
        {
            string script2 = "alert(\"Error Al guardar\");";
            ScriptManager.RegisterStartupScript(this, GetType(),
                        "ServerControlScript", script2, true);
        }

        //--------------------------------------------------Guardar en Categoria------------------------------------------
        String[] separacion = Categoria_Seleccionada.Text.Split(','); //separamos los tipos de categoria
        foreach (var subcadena in separacion) //buscados cada split en categoria para obtener su id
        {
            SqlCommand categoriab = new SqlCommand("Select * from Categoria where Nombre='" + subcadena + "'", conexion); //Buscamos la categoria
            SqlDataReader registro_busqueda = categoriab.ExecuteReader();
            while (registro_busqueda.Read())
            {
                int idcategoria = registro_busqueda.GetInt32(0);//guardamos el id de categoria con el id de producto en la intermedia
                SqlCommand insert_categoria = new SqlCommand("INSERT INTO CategoriaSoftware(idcategoria,idsoft) VALUES(" + idcategoria + "," + id + ");", conexion);
                try
                {
                    insert_categoria.ExecuteNonQuery();
                }
                catch (SqlException ee)
                {
                    string script2 = "alert(\"Error Al guardar\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                "ServerControlScript", script2, true);
                }
            }
        }
            nombre.Text = "";
            Descripcion.Text = "";
            Soporte.Text = "";
            año.Text = "";
            url.Text = "";
        BindData();
        }
            
    }

    protected void DeleteCustomer(object sender, EventArgs e)
    { 

        LinkButton lnkRemove = (LinkButton)sender;
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
            //-----------------------------------------------------------Categoria-----------------------------------------------
            SqlCommand foranea = new SqlCommand();
        foranea.CommandType = CommandType.Text;
        foranea.CommandText = "delete from CategoriaSoftware where idsoft=@id_software;delete from LicenciaSoftware where idsoftware = @id_software;delete from Software_Plataforma where idsoftware=@id_software;delete from Software"+
         " where id_software=@id_software";
        foranea.Parameters.Add("@id_software", SqlDbType.VarChar).Value = lnkRemove.CommandArgument;

        GridView1.DataSource = GetData(foranea, conexion);
        BindData();
    }

    protected void EditCustomer(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindData();
    }

    protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindData();
    }

    protected void UpdateCustomer(object sender, GridViewUpdateEventArgs e)
    {
        int id = Convert.ToInt32(((Label)GridView1.Rows[e.RowIndex].FindControl("lblsoftware")).Text);
        string Name = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtnombre")).Text;
        string Link = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtlink")).Text;
        string demo = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtdemo")).Text;
        string soporte = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtsoporte")).Text;
        int año = Convert.ToInt32(((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtaño")).Text);
        string imagen = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtimagen")).Text;
        string empresa = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtempresa")).Text;
        string plataforma = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txttipo")).Text;
        string categoria = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtcategoria")).Text;
        string licencia = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtlicencia")).Text;
        string descripcion = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtdescripcion")).Text;


        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True;Integrated Security=True;MultipleActiveResultSets=True");
        conexion.Open();
        //-----------------------------------------------------------------Categoria-----------------------------------------------
        SqlCommand cmd = new SqlCommand("DELETE FROM CategoriaSoftware WHERE idsoft = " + id + ";", conexion);
        cmd.ExecuteNonQuery();
        String[] separacion = categoria.Split(','); //separamos los tipos de categoria
        foreach (var subcadena in separacion) //buscados cada split en categoria para obtener su id
        {
            SqlCommand categoriab = new SqlCommand("Select * from Categoria where Nombre='" + subcadena + "'", conexion); //Buscamos la categoria
            SqlDataReader registro_busqueda = categoriab.ExecuteReader();
            while (registro_busqueda.Read())
            {
                int idcategoria = registro_busqueda.GetInt32(0);//guardamos el id de categoria con el id de producto en la intermedia
                SqlCommand insert_categoria = new SqlCommand("INSERT INTO CategoriaSoftware(idcategoria,idsoft) VALUES(" + idcategoria + "," + id + ");", conexion);
                try
                {
                    insert_categoria.ExecuteNonQuery();
                }
                catch (SqlException ee)
                {
                    string script2 = "alert(\"Error Al guardar Categoria\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                "ServerControlScript", script2, true);
                }
            }
        }
        //------------------------------------------------------------------Plataforma--------------------------------------------
        SqlCommand plataformadb = new SqlCommand("Select * from Plataforma where tipo='" + plataforma + "'", conexion); //Buscamos la plataforma
        SqlDataReader  busquedapt= plataformadb.ExecuteReader();
        if (busquedapt.Read())
        {
            int idplata = busquedapt.GetInt32(0);
            SqlCommand updatept = new SqlCommand("UPDATE Software_Plataforma set idplataforma="+ idplata + " WHERE idsoftware="+id+";", conexion);
            updatept.ExecuteNonQuery();

        }
        //-----------------------------------------------------------------LICENCIA-----------------------------------------------
        SqlCommand licenciadb = new SqlCommand("Select * from Licencia where descricpcion='" + licencia + "'", conexion); //Buscamos la plataforma
        SqlDataReader busquedalic = licenciadb.ExecuteReader();
        if (busquedalic.Read())
        {
            int idlicencia = busquedalic.GetInt32(0);
            SqlCommand updatept = new SqlCommand("UPDATE LicenciaSoftware set idlicencia=" + idlicencia + " WHERE idsoftware=" + id + ";", conexion);
            updatept.ExecuteNonQuery();

        }
        //------------------------------------------------------------------Empresa-------------------------------------------------
        SqlCommand empresadb = new SqlCommand("Select * from Empresa_Propietaria where nombre='" + empresa + "'", conexion); //Buscamos la plataforma
        SqlDataReader busquedaem = empresadb.ExecuteReader();
        if (busquedaem.Read())
        {
            int idempresa = busquedaem.GetInt32(0);
            SqlCommand updatept = new SqlCommand("UPDATE Software set nombre='" + Name + "', Descripcion='"+descripcion+"',Link='"+Link+"',"+
                "Demo='"+demo+"',Soporte='"+soporte+"', Año_Creacion="+año+",Imagen='"+imagen+"',codempresa="+idempresa+"  WHERE id_software=" + id + ";", conexion);
            updatept.ExecuteNonQuery();

        }
        conexion.Close();
        GridView1.EditIndex = -1;
        BindData();
    }

    protected void datagrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView gv = (GridView)sender;
        gv.PageIndex = e.NewPageIndex;
        BindData();
    }
















    //-----------------------------------------------RELLENA LOS COMBOBOX CATEGORIA , E,PRESA, PLATAFORMA
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


    protected void categoria_TextChanged(object sender, EventArgs e)
    {
        String cadena = Categoria_Seleccionada.Text + categoria.SelectedItem + ",";
        Categoria_Seleccionada.Text= cadena;
    }



    protected void Crear_Click(object sender, EventArgs e)
    {
        div_mostrar.Visible = true;

    }




}