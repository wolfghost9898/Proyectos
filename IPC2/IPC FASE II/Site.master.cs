using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Data;

public partial class SiteMaster : MasterPage
{
    private const string AntiXsrfTokenKey = "__AntiXsrfToken";
    private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
    private string _antiXsrfTokenValue;

    protected void Page_Init(object sender, EventArgs e)
    {
        // El código siguiente ayuda a proteger frente a ataques XSRF
        var requestCookie = Request.Cookies[AntiXsrfTokenKey];
        Guid requestCookieGuidValue;
        if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
        {
            // Utilizar el token Anti-XSRF de la cookie
            _antiXsrfTokenValue = requestCookie.Value;
            Page.ViewStateUserKey = _antiXsrfTokenValue;
        }
        else
        {
            // Generar un nuevo token Anti-XSRF y guardarlo en la cookie
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
            Page.ViewStateUserKey = _antiXsrfTokenValue;

            var responseCookie = new HttpCookie(AntiXsrfTokenKey)
            {
                HttpOnly = true,
                Value = _antiXsrfTokenValue
            };
            if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
            {
                responseCookie.Secure = true;
            }
            Response.Cookies.Set(responseCookie);
        }

        Page.PreLoad += master_Page_PreLoad;
    }

    protected void master_Page_PreLoad(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Establecer token Anti-XSRF
            ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
            ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
        }
        else
        {
            // Validar el token Anti-XSRF
            if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
            {
                throw new InvalidOperationException("Error de validación del token Anti-XSRF.");
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //---------------------------------------Verifica que tipo de Usuario es y que puede hacer---------------------------
            if (Request.Cookies["UserSettings"] != null)
            {
                string tipo;
                tipo = Request.Cookies["UserSettings"]["tipo"];
                if (tipo == "1")
                {
                    Gestion_Retro.Visible = false;
                    Recomendaciones.Visible = false;
                    miscompara.Visible = false;
                    vercompara.Visible = false;
                }
                else if (tipo == "2")
                {
                    Usuarios.Visible = false;
                    Gestion.Visible = false;
                    Recomendaciones.Visible = false;
                    Comparaciones.Visible = false;
                    Reporteria.Visible = false;
                }
                else if (tipo == "3")
                {
                    Usuarios.Visible = false;
                    Gestion.Visible = false;
                    Reporteria.Visible = false;

                }
            }
            else
            {
                Response.Redirect("Index.aspx");

            }
        } 
    }

    protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        Context.GetOwinContext().Authentication.SignOut();
    }

    protected void Salir_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["UserSettings"] != null)
        {
            HttpCookie myCookie = new HttpCookie("UserSettings");
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(myCookie);
            Response.Redirect("Index.aspx");
        }
    }

    protected void DeleteCustomer(object sender, EventArgs e)
    {
        string usuario;
        usuario = Request.Cookies["UserSettings"]["user"];
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-2V9EL9OT\\SQLEXPRESS;Initial Catalog=Fase2;Integrated Security=True");
        conexion.Open();
        SqlCommand cmd = new SqlCommand("Delete from Usuario where id_usuario='" + usuario + "'", conexion);
        if(cmd.ExecuteNonQuery()>0)
        {

            if (Request.Cookies["UserSettings"] != null)
            {
                HttpCookie myCookie = new HttpCookie("UserSettings");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
                Response.Redirect("Index.aspx");
            }
        }
        else
        {
            string script = "alert(\"Error al Eliminar Cuenta\");";
            ScriptManager.RegisterStartupScript(this, GetType(),
                                  "ServerControlScript", script, true);
        }
    }
}