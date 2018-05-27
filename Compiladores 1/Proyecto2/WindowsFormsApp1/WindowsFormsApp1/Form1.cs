using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Irony.Ast;
using Irony.Parsing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyectocompi2;
using System.IO;
using System.Collections;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textErrores.Text = "";
            Analizar analizador = new Analizar();
            String cadena = cuerpo.Text;
            analizador.esCadenaValida(cadena, new Gramatica());
            if (File.Exists("Errores.html"))
            {
                File.Delete("Errores.html");
            }
            if (Analizar.error.Count > 0)
            {
               
                using (StreamWriter sw = File.CreateText("Errores.html"))
                {
                    TextWriter tw = sw;
                    tw.WriteLine("<table>");
                    tw.WriteLine("<tr>");
                    tw.WriteLine("<td>Descripcion</td><td>Linea</td><td>Columna</td>");
                    tw.WriteLine("</tr>");
                    for (int i = 0; i < Analizar.error.Count; i++)
                    {
                        String error = (String)Analizar.error[i];
                        String linea = Analizar.line[i].ToString();
                        String columna = Analizar.column[i].ToString();
                        tw.WriteLine("<tr>");
                        tw.WriteLine("<td>" + error + "</td><td>" + linea + "</td><td>" + columna + "</td>");
                        tw.Write("</tr>");
                    }
                    tw.WriteLine("</table>");
                    tw.Close();
                }
               
            }

            if (Analizar.padre.Root != null && Analizar.error.Count == 0)
            {
                GraficarArbol.ConstruirArbol(Analizar.padre.Root);
                GraficarArbol.graficar("AST.txt", "");
                analizador.recorrerArbol(Analizar.padre.Root);
                for(int i = 0; i < Analizar.metodosFunciones.Count; i++) { 
                    ArrayList var = (ArrayList)Analizar.metodosFunciones[i];
                    System.Diagnostics.Debug.WriteLine("Metodo: " + var[0] );

                }

                for(int i = 0; i < Analizar.errorSemantico.Count; i++)
                {

                    textErrores.AppendText((String)Analizar.errorSemantico[i]);
                    textErrores.AppendText(Environment.NewLine);

                }


                for (int i = 0; i < Analizar.mostrar.Count; i++)
                {

                    textMostrar.AppendText((String)Analizar.mostrar[i]);
                    textMostrar.AppendText(Environment.NewLine);

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cuerpo.Text = "";
        }
        //---------------------------------------------------------------------Subira Imagenes-----------------------------------------
        private void button5_Click(object sender, EventArgs e)
        {
            if(File.Exists(Analizar.direccion + "DibujarEXP.png"))
            subirImagen(Analizar.direccion + "DibujarEXP.png");

            if (File.Exists(Analizar.direccion + "DibujarAst.png"))
                subirImagen(Analizar.direccion + "DibujarAst.png");

        }

        public void subirImagen(string filename)
        {
            using (ServiceReference1.ServiceClient client = new ServiceReference1.ServiceClient())
            {
                string strFile = System.IO.Path.GetFileName(filename);
                FileInfo fInfo = new FileInfo(filename);
                long numBytes = fInfo.Length;
                double dLen = Convert.ToDouble(fInfo.Length / 1000000);
                if (dLen < 4)
                {
                    FileStream fStream = new FileStream(filename,
                FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fStream);

                    // convert the file to a byte array
                    byte[] data = br.ReadBytes((int)numBytes);
                    br.Close();
                    string gg = client.guardarImagen(data, strFile);
                    System.Diagnostics.Debug.WriteLine("Retorno: " + gg);

                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);
                cuerpo.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string path1 = @"imagenes";
            string fullPath;

            fullPath = Path.GetFullPath(path1);
            System.Diagnostics.Process.Start("explorer", fullPath);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string path1 = @"Errores.html";
            string fullPath;
            if (File.Exists("Errores.html"))
            {
                fullPath = Path.GetFullPath(path1);
                System.Diagnostics.Process.Start(fullPath);


            }
            else
            {
                MessageBox.Show("No hay errores que mostrar");
            }
        }
    }
}
