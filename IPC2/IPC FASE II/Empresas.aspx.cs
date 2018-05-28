using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Diagnostics;

public partial class Empresas : System.Web.UI.Page
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
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        SqlCommand cmd = new SqlCommand("Select * from Empresa_Propietaria");
        GridView1.DataSource = GetData(cmd, conexion);
        GridView1.DataBind();


    }
    protected void datagrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView gv = (GridView)sender;
        gv.PageIndex = e.NewPageIndex;
        BindData();
    }
    protected void DeleteCustomer(object sender, EventArgs e)
    {
        LinkButton lnkRemove = (LinkButton)sender;
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "delete from  Empresa_Propietaria where " +
        "id_Empresa=@id_Empresa;" +
         "select * from Empresa_Propietaria";
        cmd.Parameters.Add("@id_Empresa", SqlDbType.VarChar).Value
            = lnkRemove.CommandArgument;
        GridView1.DataSource = GetData(cmd, conexion);
        GridView1.DataBind();
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
        int licencia = Convert.ToInt32(((Label)GridView1.Rows[e.RowIndex].FindControl("lblempresa")).Text);
        string Name = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtnombre")).Text;
        string sitio = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtsitio")).Text;
        string url = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txturl")).Text;
        int valor = Convert.ToInt32(((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtvalor")).Text);
        string año = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtaño")).Text;


        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "UPDATE Empresa_Propietaria Set nombre=@Nombre,sitioweb=@sitioweb,Link=@Link,valor=@valor,año_fundacio=@año where id_Empresa=@id_Empresa;" +
         "select * from Empresa_Propietaria";
        cmd.Parameters.Add("@id_Empresa", SqlDbType.Int).Value = licencia;
        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Name;
        cmd.Parameters.Add("@sitioweb", SqlDbType.VarChar).Value = sitio;
        cmd.Parameters.Add("@Link", SqlDbType.VarChar).Value = url;
        cmd.Parameters.Add("@valor", SqlDbType.Int).Value = valor;
        cmd.Parameters.Add("@año", SqlDbType.VarChar).Value = año;
        GridView1.EditIndex = -1;
        GridView1.DataSource = GetData(cmd, conexion);
        GridView1.DataBind();
    }

    protected void boton_guardar_Click(object sender, EventArgs e)
    {
        String nombre = nombre_me.Text;
        String Web = web.Text;
        int Valor = Convert.ToInt32(valor.Text);
        String Año = año.Text;
        String Url = url.Text;

        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        conexion.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO Empresa_Propietaria(nombre,sitioweb,Link,valor,año_fundacio) VALUES('" + nombre + "','" + Web + "','" + Url + "'," + Valor + ",'" + Año + "')", conexion);
        try
        {
            cmd.ExecuteNonQuery();
            Response.Redirect("Empresas.aspx");
        }
        catch (SqlException ee)
        {
            string script = "alert(\"Error al Guardar\");";
            ScriptManager.RegisterStartupScript(this, GetType(),
                        "ServerControlScript", script, true);
            conexion.Close();
        }
    }

    protected void Crear_Click(object sender, EventArgs e)
    {
        div_mostrar.Visible = true;
        div_carga.Visible = false;

    }

    protected void CargaMasiva_Click(object sender, EventArgs e)
    {
        div_mostrar.Visible = false;
        div_carga.Visible = true;

    }


    protected void boton_guardar_carga_Click(object sender, EventArgs e)
    {
        String direccion=Path.GetFileName(carga_mas.PostedFile.FileName);
        carga_mas.PostedFile.SaveAs(Server.MapPath("Archivos_Server/" + direccion) );

        //------------------------------------------Analizar Archivo-----------------------------------------------------------
        string file_name = Server.MapPath("Archivos_Server/" + direccion);
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        conexion.Open();

        try
        {
                using (StreamReader lector = new StreamReader(file_name))
                {
                    while (lector.Peek() > -1)
                    {
                        string linea = lector.ReadLine();
                        if (!String.IsNullOrEmpty(linea))
                        {
                            String[] separacion = linea.Split(',');
                            String nombre = separacion[0];
                            String Web = separacion[1].Trim();
                            int Valor = Convert.ToInt32(Convert.ToDouble(separacion[2]));
                            String Año = separacion[3].Trim();
                            String Url = separacion[5].Trim();
                            SqlCommand cmd = new SqlCommand("INSERT INTO Empresa_Propietaria(nombre,sitioweb,Link,valor,año_fundacio) VALUES('" + nombre + "','" + Web + "','" + Url + "'," + Valor + ",'" + Año + "')", conexion);
                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (SqlException ee)
                            {
                                string script = "alert(\"Error al Guardar\");";
                                ScriptManager.RegisterStartupScript(this, GetType(),
                                            "ServerControlScript", script, true);
                                conexion.Close();
                            }
                        }
                    }
                     BindData();
                }
        }
            catch (Exception ex) { }
        
    }
}