using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class paginas_Registrar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //--------------------------------------------Boton para registrarte------------------------------------------
    protected void botontregis_Click(object sender, EventArgs e)
    {
        String usuario = usuario_re.Text;
        String nombre = nombre_re.Text;
        String contraseña = contraseña_re.Text;
        String profe = profesion.Text;
        String correo = email.Text;
        String fecha = Fecha.Text;
        int tipo = Convert.ToInt32(Tipo.SelectedValue);
        Console.Write(tipo);
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        conexion.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO Usuario(id_usuario,nombre,Fecha_NAc,Correo,Contraseña,Profesion,idtipousuario) VALUES(\'" + usuario + "\',\'" + nombre + "\',\'" + fecha + "\',\'" + correo + "\',\'" + contraseña + "\',\'" + profe + "\',"+tipo+");", conexion);
        try
        {
            cmd.ExecuteNonQuery();
            string script = "alert(\"Guardado Exitosamente\");";
            ScriptManager.RegisterStartupScript(this, GetType(),
                        "ServerControlScript", script, true);
            conexion.Close();
            Response.Redirect("Index.aspx");
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