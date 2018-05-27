using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Resultados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < Analizar.salida.Count; i++)
            {
                HtmlGenericControl parrafo = new HtmlGenericControl();
                ArrayList dato = (ArrayList)Analizar.salida[i];
                String tipo = Convert.ToString(dato[1]);
                if (tipo.Equals("imprimir"))
                {
                    String expre = Convert.ToString(dato[0]);
                    mostrar.InnerHtml =mostrar.InnerHtml+"<br>"+ expre ;
                }
                else
                {
                    Bitmap m = (Bitmap)dato[0];
                    System.Drawing.Image mm = (System.Drawing.Image)m;
                    String direccion = HttpContext.Current.Server.MapPath("imagenes/" + i + ".jpg");
                    mm.Save(direccion);
                    mostrar.InnerHtml = mostrar.InnerHtml + "<img src=\"imagenes/"+i+".jpg\" width=\"400\" height=\"400\" /> ";
                }
            }
        }
    }
}