using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;

public partial class Change_Password : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void OnChangingPassword(object sender, LoginCancelEventArgs e)
    {

    }
    //------------------------------------------------------Cambiar Contraseña-------------------------------------------
    protected void cambiar_password_Click(object sender, EventArgs e)
    {
        String old_contraseña = contraseña_actual.Text;
        String new_contraseña = newcontraseña.Text;
        if (newcontraseña.Text == newcontraseña2.Text)//----------------------------Coinciden las dos contraseñas-----------------
        {
            String usuario = Request.Cookies["UserSettings"]["user"];
            SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
            conexion.Open();
            SqlCommand cmd = new SqlCommand("Select Contraseña from Usuario where id_usuario='" + usuario + "'", conexion);
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.Read())
            {
                if (registro.GetString(0) == old_contraseña)//--------------------------Coincide la antigua contraseña con la nueva
                {
                    registro.Close();
                    SqlCommand update = new SqlCommand("UPDATE Usuario SET Contraseña=@Contraseña WHERE id_usuario=@usuario", conexion);
                    update.Parameters.AddWithValue("@Contraseña", new_contraseña);
                    update.Parameters.AddWithValue("@usuario", usuario);
                    try
                    {
                        update.ExecuteNonQuery();
                        lblMessage.ForeColor = Color.Green;
                        lblMessage.Text = "Contraseña cambiada con exito.";
                        conexion.Close();
                    }
                    catch (SqlException ee)
                    {
                        lblMessage.ForeColor = Color.Red;
                        lblMessage.Text = "No se pudo cambiar su contraseña por favor verifique sus datos.";
                        conexion.Close();
                    }
                }
                else
                {
                    lblMessage.ForeColor = Color.Red;
                    lblMessage.Text = "Escriba Correctamente su contraseña";
                }
            }

        }
        else
        {
            lblMessage.ForeColor = Color.Red;
            lblMessage.Text = "No Coinciden las nuevas contraseñas";
        }
    }
}