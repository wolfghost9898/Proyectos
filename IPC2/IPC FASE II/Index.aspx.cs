using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserSettings"] != null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {

        }
    }

    protected void botoningre_Click(object sender, EventArgs e)
    {
        String usuario = usuario_in.Text;
        String contraseña = contraseña_in.Text;
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        conexion.Open();
        SqlCommand cmd = new SqlCommand("Select * from Usuario where id_usuario='" + usuario + "'", conexion);
        SqlDataReader registro = cmd.ExecuteReader();
        if (registro.Read())
        {
            if (registro.GetString(4) == contraseña)
            {
                Response.Cookies["UserSettings"]["user"] = usuario;
                Response.Cookies["UserSettings"]["contraseña"] = contraseña;
                Response.Cookies["UserSettings"]["nombre"] = registro.GetString(1);
                Response.Cookies["UserSettings"]["fecha"] = registro.GetString(2);
                Response.Cookies["UserSettings"]["correo"] = registro.GetString(3);
                Response.Cookies["UserSettings"]["profesion"] = registro.GetString(5);
                Response.Cookies["UserSettings"]["tipo"] = Convert.ToString(registro.GetInt32(6));
                Response.Cookies["UserSettings"].Expires = DateTime.Now.AddDays(1d);

                // string script = "alert(\"" + registro.GetString(0) + "   " + registro.GetString(1) + "\");";
                // ScriptManager.RegisterStartupScript(this, GetType(),
                // "ServerControlScript", script, true);
                Response.Redirect("Default.aspx");
            }
            else
            {
                string script = "alert(\"Contraseña Incorrecta\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
        }
        else
        {
            string script = "alert(\"No se encontro el usuario\");";
            ScriptManager.RegisterStartupScript(this, GetType(),
                                  "ServerControlScript", script, true);
            registro.Close();
        }
    }
 

}