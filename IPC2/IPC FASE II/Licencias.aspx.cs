using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Licencias : System.Web.UI.Page
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
        SqlCommand cmd = new SqlCommand("Select * from Licencia");
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
        SqlCommand foranea = new SqlCommand();
        foranea.CommandType = CommandType.Text;
        foranea.CommandText = "delete from LicenciaSoftware where idlicencia=@id_licencia; select * from LicenciaSoftware";
        foranea.Parameters.Add("@id_licencia", SqlDbType.VarChar).Value = lnkRemove.CommandArgument;
        foranea.Connection = conexion;
        conexion.Open();
        foranea.ExecuteNonQuery();
        foranea.Connection.Close();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "delete from  Licencia where " +
        "id_licencia=@id_licencia;" +
         "select * from Licencia";
        cmd.Parameters.Add("@id_licencia", SqlDbType.VarChar).Value
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
        int licencia=Convert.ToInt32( ((Label)GridView1.Rows[e.RowIndex].FindControl("lbllicencia")).Text);
        string Name = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtdescripcion")).Text;
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "UPDATE Licencia Set descricpcion=@Descripcion where id_licencia=@id_licencia;" +
         "select * from Licencia";
        cmd.Parameters.Add("@id_licencia", SqlDbType.Int).Value = licencia;
        cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Name;
        GridView1.EditIndex = -1;
        GridView1.DataSource = GetData(cmd, conexion);
        GridView1.DataBind();
    }

    protected void boton_guardar_Click(object sender, EventArgs e)
    {
        String nombre = descripcion_guardar.Text;
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        conexion.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO Licencia(descricpcion) VALUES('"+nombre+"')", conexion);
        try
        {
            cmd.ExecuteNonQuery();
            string script = "alert(\"Guardado Exitosamente\");";
            ScriptManager.RegisterStartupScript(this, GetType(),
                        "ServerControlScript", script, true);
            conexion.Close();
            nombre = "";
            Response.Redirect("Licencias.aspx");
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

    }
}