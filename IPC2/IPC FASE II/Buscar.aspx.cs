using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Buscar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void buscar_button_Click(object sender, EventArgs e)
    {
        BindData();
    }

    private DataTable GetData(SqlCommand cmd,SqlConnection con)
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
        String usuario = buscar.Text;
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        SqlCommand cmd = new SqlCommand("Select * from Usuario where id_usuario='" + usuario + "'");
        GridView1.DataSource = GetData(cmd, conexion);
        GridView1.DataBind();
    }

    protected void DeleteCustomer(object sender, EventArgs e)
    {
        LinkButton lnkRemove = (LinkButton)sender;
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "delete from  Usuario where " +
        "id_usuario=@id_usuario;" +
         "select * from Usuario";
        cmd.Parameters.Add("@id_usuario", SqlDbType.VarChar).Value
            = lnkRemove.CommandArgument;
        GridView1.DataSource = GetData(cmd,conexion);
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
        string usuario = ((Label)GridView1.Rows[e.RowIndex].FindControl("lblUsuario")).Text;
        string Name = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtName")).Text;
        string Fecha = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtfecha")).Text;
        string Correo = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtcorreo")).Text;
        string Contraseña = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtcontraseña")).Text;
        string Profesion = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtprofesion")).Text;
        string tipo = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txttipo")).Text;

        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "UPDATE Usuario Set nombre=@Nombre,Fecha_NAc=@Fecha_NAc,Correo=@Correo,Contraseña=@Contraseña,Profesion=@Profesion,idtipousuario=@idtipousuario " +
         "where id_usuario=@id_usuario;" +
         "select * from Usuario";
        cmd.Parameters.Add("@id_usuario", SqlDbType.VarChar).Value = usuario;
        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Name;
        cmd.Parameters.Add("@Fecha_NAc", SqlDbType.VarChar).Value = Fecha;
        cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = Correo;
        cmd.Parameters.Add("@Contraseña", SqlDbType.VarChar).Value = Contraseña;
        cmd.Parameters.Add("@Profesion", SqlDbType.VarChar).Value = Profesion;
        cmd.Parameters.Add("@idtipousuario", SqlDbType.VarChar).Value = tipo;
        GridView1.EditIndex = -1;
        GridView1.DataSource = GetData(cmd,conexion);
        GridView1.DataBind();
    }

   
}