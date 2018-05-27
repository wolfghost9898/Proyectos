using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Irony.Parsing;
using System.IO;
using WINGRAPHVIZLib;
using System.Configuration;
using System.Drawing;

namespace WebApplication1
{
    public class CrearArbol
    {
        public static String graph = "";
        public static void ConstruirArbol(ParseTreeNode raiz)
        {
            StreamWriter f = new StreamWriter(HttpContext.Current.Server.MapPath("~/Arbol.txt"));
            f.Write("digraph lista { \n");
            graph = "";
            Generar(raiz);
            f.Write(graph);
            f.Write("}");
            f.Close();
        }

        public static void Generar(ParseTreeNode raiz)
        {
            graph = graph + "nodo" + raiz.GetHashCode() + "[label=\"" + raiz.ToString().Replace("\"", "\\\"") + " \",  fillcolor=\"LightBlue\" , style =\"filled\" , shape=\"box\"]; \n";
            if (raiz.ChildNodes.Count > 0)
            {
                ParseTreeNode[] hijos = raiz.ChildNodes.ToArray();
                for (int i = 0; i < raiz.ChildNodes.Count; i++)
                {
                    Generar(hijos[i]);
                    graph = graph + "\"nodo" + raiz.GetHashCode() + "\"-> \"nodo" + hijos[i].GetHashCode() + "\" \n";
                }
            }
        }

        public static void GraficarArbol(String filename,String path)
        {
            String text = File.ReadAllText(HttpContext.Current.Server.MapPath("~/Arbol.txt")); 
            WINGRAPHVIZLib.DOT dot = new WINGRAPHVIZLib.DOT();
            WINGRAPHVIZLib.BinaryImage img = dot.ToPNG(text);
            byte[] imageBytes = Convert.FromBase64String(img.ToBase64String());
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image imagen = Image.FromStream(ms, true);
            imagen.Save(HttpContext.Current.Server.MapPath("~/Arbol.png"));
        }

    }


}