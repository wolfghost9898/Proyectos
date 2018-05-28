using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Plataformas : System.Web.UI.Page
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
        SqlCommand cmd = new SqlCommand("Select * from Plataforma");
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
        foranea.CommandText = "delete from Software_Plataforma where idplataforma=@id_Plataforma; select * from Software_Plataforma";
        foranea.Parameters.Add("@id_Plataforma", SqlDbType.VarChar).Value = lnkRemove.CommandArgument;
        foranea.Connection = conexion;
        conexion.Open();
        foranea.ExecuteNonQuery();
        foranea.Connection.Close();


        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "delete from  Plataforma where " +
        "id_Plataforma=@id_Plataforma;" +
         "select * from Plataforma";
        cmd.Parameters.Add("@id_Plataforma", SqlDbType.VarChar).Value
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
        int id = Convert.ToInt32(((Label)GridView1.Rows[e.RowIndex].FindControl("lblPlataforma")).Text);
        string tipo = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txttipo")).Text;
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "UPDATE Plataforma Set tipo=@tipo where id_Plataforma=@id_Plataforma;" +
         "select * from Plataforma";
        cmd.Parameters.Add("@id_Plataforma", SqlDbType.Int).Value = id;
        cmd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;
        GridView1.EditIndex = -1;
        GridView1.DataSource = GetData(cmd, conexion);
        GridView1.DataBind();
    }

    protected void boton_guardar_Click(object sender, EventArgs e)
    {
        String Tipo = tipo.Text;
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        conexion.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO Plataforma(tipo) VALUES('" + Tipo + "')", conexion);
        try
        {
            cmd.ExecuteNonQuery();
            Response.Redirect("Plataformas.aspx");
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