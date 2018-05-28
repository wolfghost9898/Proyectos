using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

public partial class MyRetro : System.Web.UI.Page
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
        String usuario = Request.Cookies["UserSettings"]["user"];
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        SqlCommand cmd = new SqlCommand("SELECT Retroalimentacion.id_retroalimentacion, Usuario.id_usuario,Retroalimentacion.Comentario,Software.nombre,Retroalimentacion.fecha FROM Retroalimentacion JOIN Usuario " +
                                        "ON Usuario.id_usuario = Retroalimentacion.codusuario JOIN Software " +
                                        "ON Software.id_software = Retroalimentacion.codso WHERE Usuario.id_usuario='"+usuario +"' "+
                                        "GROUP BY Usuario.id_usuario, Retroalimentacion.Comentario, Retroalimentacion.id_retroalimentacion, " +
                                        "Software.nombre, Retroalimentacion.fecha, Retroalimentacion.id_retroalimentacion "+
                                        "ORDER  BY  Retroalimentacion.id_retroalimentacion DESC");
        GridView1.DataSource = GetData(cmd, conexion);
        GridView1.DataBind();
    }

    protected void DeleteCustomer(object sender, EventArgs e)
    {
        LinkButton lnkRemove = (LinkButton)sender;
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "delete from  Retro_metricas where " +
        "idrealim=@idrealim;delete from RetroAlimentacion where id_retroalimentacion=@idrealim";
        cmd.Parameters.Add("@idrealim", SqlDbType.Int).Value
            = lnkRemove.CommandArgument;
        GridView1.DataSource = GetData(cmd, conexion);
        GridView1.DataBind();
    }

    protected void datagrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView gv = (GridView)sender;
        gv.PageIndex = e.NewPageIndex;
        BindData();
    }

    protected void EditCustomer(object sender, EventArgs e)
    {
        LinkButton lnkEdit = (LinkButton)sender;
        String nombre = lnkEdit.CommandArgument;
        Response.Redirect("Edit_Retroalimentacion.aspx?id=" + nombre);
    }


}