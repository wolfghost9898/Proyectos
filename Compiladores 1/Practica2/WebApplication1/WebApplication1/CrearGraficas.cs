using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using Irony.Ast;
using Irony.Parsing;
namespace WebApplication1
{
    public class CrearGraficas
    {
        float xmin = 0;
        float xmax = 50;
        float ymin = 0;
        float ymax = 50;
        String funcion;
        String variable;
        public CrearGraficas(String funcion2,String variable2,float limite1,float limite2)
        {
            funcion2 = funcion2.Trim();
            variable2 = variable2.Trim();
            this.funcion = funcion2;
            this.variable = variable2;
            if (variable.Equals("x"))
            {
                xmin = F(limite1);
                xmax = F(limite2);
                ymin = limite1;
                ymax = limite2;
            }
            else
            {
                ymin = F(limite1);
                ymax = F(limite2);
                xmin = limite1;
                xmax = limite2;
            }
        }
        public Bitmap MakeGraph()
        {
            // The bounds to draw.


            // Make the Bitmap.
            int wid = 1000;
            int hgt = 1000;
            Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                // Transform to map the graph bounds to the Bitmap.


                RectangleF rect = new RectangleF(
                    xmin, ymin, xmax - xmin, ymax - ymin);
                PointF[] pts =
                {
            new PointF(0, hgt),
            new PointF(wid, hgt),
            new PointF(0, 0),
        };
                gr.Transform = new Matrix(rect, pts);

                // Draw the graph.
                using (Pen graph_pen = new Pen(Color.Blue, 0))
                {
                    // Draw the axes.
                    gr.DrawLine(graph_pen, xmin, 0, xmax, 0);
                    gr.DrawLine(graph_pen, 0, ymin, 0, ymax);
                    for (int x = (int)xmin; x <= xmax; x++)
                    {
                        gr.DrawLine(graph_pen, x, -0.1f, x, 0.1f);
                    }
                    for (int y = (int)ymin; y <= ymax; y++)
                    {
                        gr.DrawLine(graph_pen, -0.1f, y, 0.1f, y);
                    }
                    graph_pen.Color = Color.Red;

                    // See how big 1 pixel is horizontally.
                    Matrix inverse = gr.Transform;
                    inverse.Invert();
                    PointF[] pixel_pts =
                    {
                new PointF(0, 0),
                new PointF(1, 0)
            };
                    inverse.TransformPoints(pixel_pts);
                    float dx = pixel_pts[1].X - pixel_pts[0].X;
                    dx /= 2;

                    // Loop over x values to generate points.
                    List<PointF> points = new List<PointF>();
                    for (float x = xmin; x <= xmax; x += dx)
                    {
                        bool valid_point = false;
                        try
                        {
                            // Get the next point.
                            float y = F(x);

                            // If the slope is reasonable,
                            // this is a valid point.
                            if (points.Count == 0) valid_point = true;
                            else
                            {
                                float dy = y - points[points.Count - 1].Y;
                                if (Math.Abs(dy / dx) < 1000)
                                    valid_point = true;
                            }
                            if (valid_point) points.Add(new PointF(x, y));
                        }
                        catch
                        {
                        }

                        // If the new point is invalid, draw
                        // the points in the latest batch.
                        if (!valid_point)
                        {
                            if (points.Count > 1)
                                gr.DrawLines(graph_pen, points.ToArray());
                            points.Clear();
                        }

                    }

                    // Draw the last batch of points.
                    if (points.Count > 1)
                        gr.DrawLines(graph_pen, points.ToArray());
                }
            }

            // Display the result.
            return bm;
        }

        private float F(float x)
        {
            String expresion = funcion;
            String val = Convert.ToString(x);
            if (variable.Equals("x")){
                expresion = expresion.Replace("y", val);

            }
            else
            {
                expresion = expresion.Replace("x", val);

            }

            AnalizarCalcu analizador = new AnalizarCalcu();
            analizador.analizarOperacion(expresion, new Calculadora());
             analizador.Recorrer(AnalizarCalcu.padre.Root);

            return (float)AnalizarCalcu.valor; 
        }
    }
}