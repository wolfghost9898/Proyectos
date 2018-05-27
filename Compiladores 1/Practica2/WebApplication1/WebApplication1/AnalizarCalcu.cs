using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Irony.Parsing;

namespace WebApplication1
{
    public class AnalizarCalcu
    {
        public static ParseTree padre;
        public static Double valor;
        public void analizarOperacion(string entrada, Grammar gramatica)
        {
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser p = new Parser(lenguaje);

            ParseTree arbol = p.Parse(entrada);

            padre = arbol;
        }



        public void Recorrer(ParseTreeNode raiz)
        {
            if (raiz != null)
            {
                String inicio = raiz.ToString();
                ParseTreeNode[] hijos = null;
                hijos = raiz.ChildNodes.ToArray();
                switch (inicio)
                {

                    case "EXPRE":

                        valor = Expresiones(raiz, " vava");
                        hijos = null;
                        break;
                }
                if (hijos != null)
                {
                    for (int i = 0; i < hijos.Count(); i++)
                    {
                        Recorrer(hijos[i]);
                    }
                }
            }
        }



        public Double Expresiones(ParseTreeNode raiz, String metodo)
        {
            string Inicio = raiz.ToString();
            ParseTreeNode[] hijos = null;
            if (raiz.ChildNodes.Count > 0)
            {
                hijos = raiz.ChildNodes.ToArray();
            }
            if (raiz.ChildNodes.Count == 3)
            {
                int prueba1 = 0;
                int prueba2 = 2;
                if (hijos[0].ToString().Equals("( (Key symbol)"))
                {
                    prueba1 = 1;
                    prueba2 = 0;
                    return Expresiones(hijos[1], metodo);
                }
                else
                {

                    var operando1 = Expresiones(hijos[prueba1], metodo);
                    var operando2 = Expresiones(hijos[prueba2], metodo);

                    string operador = hijos[1].ToString().Replace(" (Key symbol)", "");
                    operador = operador.Replace(" (Keyword)", "");
                    switch (operador)
                    {
                        case "+":
                            {
                                return operando1 + operando2;

                            }
                        case "-":
                            {
                                return operando1 - operando2;
                            }
                        case "*":
                            {
                                return operando1 * operando2;
                            }
                        case "/":
                            {
                                return operando1 / operando2;
                            }
                        case "^":
                            {
                                return Math.Pow(operando1, operando2);
                            }
                        default:
                            return 0.0;
                            break;

                    }
                }

            }
            else
            {
                if (hijos[0].ToString().Contains(" (numero)"))
                {
                    String var = hijos[0].ToString().Replace(" (numero)", "");
                    Double numero;

                    Double.TryParse(var, out numero);

                    return numero;
                }
                else
                {
                    return 0.0;
                }
            }
        }
    }
}