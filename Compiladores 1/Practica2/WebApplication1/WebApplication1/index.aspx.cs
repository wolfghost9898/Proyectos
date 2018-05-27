using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Irony.Ast;
using Irony.Parsing;
using System.Collections;
using System.IO;

namespace WebApplication1
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            errores.Text = "";
            Analizar analizador = new Analizar();
            String cadena = cuerpo.Text;
            analizador.esCadenaValida(cadena, new Gramatica());

                if (Analizar.error.Count > 0)
                {

                    for(int i = 0; i < Analizar.error.Count; i++)
                    {
                    String error = (String)Analizar.error[i];
                    String linea = Analizar.linea[i].ToString();
                    String columna = Analizar.columna[i].ToString();
                    errores.Text = errores.Text + "\n" + error + " Linea:  " + linea + " Columa: " + columna+ "\n";
                    }
                }
            if (Analizar.padre.Root != null && Analizar.error.Count==0)
            {
                CrearArbol.ConstruirArbol(Analizar.padre.Root);
                CrearArbol.GraficarArbol("~/Arbol.txt", "");
                analizador.RecorrerMetodos(Analizar.padre.Root);
                analizador.clasePrincipal(Analizar.padre.Root);
                for(int i = 0; i < Analizar.variables.Count; i++)
                {
                    ArrayList var = (ArrayList)Analizar.variables[i];
                    System.Diagnostics.Debug.WriteLine("Metodo: "+var[0]+" Nombre: "+var[1]+" Valor: "+var[2]);
                }
                
            }


        }



        protected void Button3_Click(object sender, EventArgs e)
        {
            String direccion = Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.PostedFile.SaveAs(Server.MapPath("cargar/" + direccion));
            string file_name = Server.MapPath("cargar/" + direccion);
            cuerpo.Text = File.ReadAllText(file_name);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Resultados.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            cuerpo.Text = "";
        }
    }
}