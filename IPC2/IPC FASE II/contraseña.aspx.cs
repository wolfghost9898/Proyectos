using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class contraseña : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void verificar_Click(object sender, EventArgs e)
    {
        String correo = Correo.Text;
        String fecha = Fecha.Text;
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        conexion.Open();
        SqlCommand cmd = new SqlCommand("Select * from Usuario where Correo='" + correo + "'", conexion);
        SqlDataReader registro = cmd.ExecuteReader();
        if (registro.Read())
        {
            if (registro.GetString(2) == fecha)
            {
                // string script = "alert(\"" + registro.GetString(0) + "   " + registro.GetString(1) + "\");";
                // ScriptManager.RegisterStartupScript(this, GetType(),
                // "ServerControlScript", script, true);
                Label2.Text = registro.GetString(4);
                Label2.Visible=true;
                Label1.Visible =true;
            }
            else
            {
                string script = "alert(\"No coinciden los datos\");";
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