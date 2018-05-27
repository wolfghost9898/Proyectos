using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteWeb
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (ServiceReference1.ServiceClient client = new ServiceReference1.ServiceClient())
            {
                byte[] f = client.getImagenes("DibujarEXP.png");
                MemoryStream ms = new MemoryStream(f);
                FileStream fs = new FileStream
                        (System.Web.Hosting.HostingEnvironment.MapPath
                        ("~/Imagenes/") +
                        "DibujarEXP.png", FileMode.Create);
                ms.WriteTo(fs);
                ms.Close();
                fs.Close();
                fs.Dispose();
                Image1.ImageUrl="~/Imagenes/DibujarEXP.png";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (ServiceReference1.ServiceClient client = new ServiceReference1.ServiceClient())
            {
                byte[] f = client.getImagenes("DibujarAst.png");
                MemoryStream ms = new MemoryStream(f);
                FileStream fs = new FileStream
                        (System.Web.Hosting.HostingEnvironment.MapPath
                        ("~/Imagenes/") +
                        "DibujarAst.png", FileMode.Create);
                ms.WriteTo(fs);
                ms.Close();
                fs.Close();
                fs.Dispose();
                Image1.ImageUrl = "~/Imagenes/DibujarAst.png";
            }
        }
    }
}