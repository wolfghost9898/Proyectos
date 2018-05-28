using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Gestionar_Cuenta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // put codes here
        
        String usuario = Request.Cookies["UserSettings"]["user"];
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        conexion.Open();
        SqlCommand cmd = new SqlCommand("Select * from Usuario where id_usuario='" + usuario + "'", conexion);
        SqlDataReader registro = cmd.ExecuteReader();
        if (registro.Read())
        {
                usuario_re.Text = usuario;
            nombre_re.Text = registro.GetString(1);
            Fecha.Text = registro.GetString(2);
            email.Text = registro.GetString(3);
            profesion.Text = registro.GetString(5);      
        }
        }

    }

    protected void botontregis_Click(object sender, EventArgs e)
    {
        String usuario = usuario_re.Text;
        String nombre = nombre_re.Text;
        String profe =  profesion.Text;
        String correo = email.Text;
        String fecha =  Fecha.Text;


        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        conexion.Open();
        SqlCommand cmd = new SqlCommand("UPDATE Usuario SET nombre=@nombre,Fecha_NAc=@fecha,Correo=@correo,Profesion=@profe WHERE id_usuario=@usuario", conexion);
        cmd.Parameters.AddWithValue("@nombre", nombre);
        cmd.Parameters.AddWithValue("@fecha", fecha);
        cmd.Parameters.AddWithValue("@correo", correo);
        cmd.Parameters.AddWithValue("@profe", profe);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        try
        {
            cmd.ExecuteNonQuery();
            string script = "alert(\"Guardado Exitosamente\");";
            ScriptManager.RegisterStartupScript(this, GetType(),
                        "ServerControlScript", script, true);
            conexion.Close();

            Request.Cookies["UserSettings"]["user"] = usuario_re.Text;
            Request.Cookies["UserSettings"]["nombre"] = nombre_re.Text;
            Request.Cookies["UserSettings"]["profesion"] = profesion.Text;
            Request.Cookies["UserSettings"]["correo"] = email.Text;
            Request.Cookies["UserSettings"]["fecha"] = Fecha.Text;

        }
        catch (SqlException ex)
        {
            string script = "alert(\"Error al guardar verifique sus datos \");";
            ScriptManager.RegisterStartupScript(this, GetType(),
                        "ServerControlScript", script, true);
            conexion.Close();

        }
    }
}