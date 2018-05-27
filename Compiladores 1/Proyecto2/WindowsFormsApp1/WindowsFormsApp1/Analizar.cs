using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;
using System.Collections;
using System.IO;
using System.Drawing;
using WindowsFormsApp1;

namespace Proyectocompi2
{
    class Analizar
    {
        public static ParseTree padre;
        public static ArrayList error;
        public static ArrayList errorSemantico;
        public static ArrayList line;
        public static ArrayList column;
        public static ArrayList print;
        public static ArrayList variablesGlobales;
        public static ArrayList metodosFunciones;
        public static ArrayList variablesLocales;
        public static ArrayList variablesLocalesMain;
        public static ArrayList listaParametros;
        public static ArrayList retornoMetodos;
        public static ArrayList parametrosTemporales;
        public static Boolean continuar = true;
        public static Double diferencia = 0.5;
        public static String graph = "";
        public static ArrayList mostrar;
        public static string mensaje = "";
        public static int conta = 0;
        public static string direccion = "imagenes/";

        public void esCadenaValida(string cadenaEntrada, Grammar gramatica)
        {

            error = new ArrayList();
            line = new ArrayList();
            column = new ArrayList();
            print = new ArrayList();
            errorSemantico = new ArrayList();
            metodosFunciones = new ArrayList();

            variablesGlobales = new ArrayList();
            variablesLocales = new ArrayList();
            variablesLocalesMain = new ArrayList();

            listaParametros = new ArrayList();
            parametrosTemporales = new ArrayList();
            retornoMetodos = new ArrayList();
            mostrar = new ArrayList();

            LanguageData lenguaje = new LanguageData(gramatica);
            Parser p = new Parser(lenguaje);
            ParseTree arbol = p.Parse(cadenaEntrada);
            padre = arbol;
            //return arbol.Root != null;

            if (padre != null)
            {


                for (int i = 0; i < arbol.ParserMessages.Count(); i++)
                {
                    error.Add(arbol.ParserMessages.ElementAt(i).Level.ToString() + arbol.ParserMessages.ElementAt(i).Message);
                    line.Add(arbol.ParserMessages.ElementAt(i).Location.Line);
                    column.Add(arbol.ParserMessages.ElementAt(i).Location.Column);
                    String linea = Analizar.line[i].ToString();
                    String columna = Analizar.column[i].ToString();
                }


            }
        }

        /*-------------------------------------------------------------------------METODO QUE SE ENCARGA DE RECORRER LAS PARTES DEL CUERPO--------------------------
        ----------------------------------------------------------------------------------------------------------------------------------------------------------*/

        public void recorrerArbol(ParseTreeNode raiz)
        {
            String inicio = raiz.ToString();
            ParseTreeNode[] hijos = null;
            if (raiz.ChildNodes.Count > 0) hijos = raiz.ChildNodes.ToArray();
            switch (inicio)
            {


                case "DECLARACION":
                    ParseTreeNode[] tipo = hijos[0].ChildNodes.ToArray();
                    string tip = tipo[0].ToString().Replace(" (Keyword)", "");
                    if (hijos.Length > 3)
                    {
                        declaracionGlobal(raiz, tip, hijos[3]);

                    }
                    else declaracionGlobal(raiz, tip, null);
                    break;




                case "ENCABEZADO":
                    if (hijos != null)
                    {
                        string ope = hijos[0].ToString();
                        ope = ope.Replace(" (Keyword)", "");
                        if (ope.Equals("Definir"))
                        {
                            ParseTreeNode[] operacion = hijos[1].ChildNodes.ToArray();

                            string defin = Convert.ToString(operacion[0]);
                            if (defin.Contains(" (numero)"))
                            {
                                defin = defin.Replace(" (numero)", "");
                                diferencia = Convert.ToDouble(defin);
                            }
                            else
                            {
                                ParseTreeNode[] adrees = hijos[1].ChildNodes.ToArray();
                                direccion = adrees.ToString().Replace(" (tString)", "");
                            }
                        }
                        else if (ope.Equals("Importar"))
                        {
                            
                            string nombre = hijos[1].ToString().Replace(" (id)", "") + ".crl";
                            ImportClase analizar = new ImportClase();
                            if (File.Exists(nombre))
                            {
                                string text = System.IO.File.ReadAllText(nombre);
                                analizar.esCadenaValida(text, new Gramatica());

                                if (ImportClase.error.Count == 0 && ImportClase.padre != null)
                                {
                                    analizar.recorrerArbol(ImportClase.padre.Root);
                                }
                                else
                                {
                                    using (StreamWriter sw = File.CreateText("Errores.html"))
                                    {
                                        TextWriter tw = sw;
                                        tw.WriteLine("<table>");
                                        tw.WriteLine("<tr>");
                                        tw.WriteLine("<td>Descripcion</td><td>Linea</td><td>Columna</td>");
                                        tw.WriteLine("</tr>");
                                        for (int i = 0; i < ImportClase.error.Count; i++)
                                        {
                                            String error = (String)ImportClase.error[i];
                                            String linea = ImportClase.linea[i].ToString();
                                            String columna = ImportClase.columna[i].ToString();
                                            tw.WriteLine("<tr>");
                                            tw.WriteLine("<td>" + error + "</td><td>" + linea + "</td><td>" + columna + "</td>");
                                            tw.Write("</tr>");
                                        }
                                        tw.WriteLine("</table>");
                                        tw.Close();
                                    }
                                }
                            }
                            

                        }
                        //-------------------------------------------------------------importar---------------------------------------------------

                    }
                    break;


                case "ASIGNACION":
                    if (hijos != null)
                    {
                        string nombre = Convert.ToString(hijos[0]);
                        nombre = nombre.Replace(" (id)", "");
                        nombre = nombre.Trim();

                        asignacionVariablesGlobal(nombre, hijos[2]);
                    }
                    break;





                case "FUN":
                    if (hijos != null)
                    {
                        ParseTreeNode[] tipoFun = hijos[0].ChildNodes.ToArray();
                        string tipoFuncion = Convert.ToString(tipoFun[0]);
                        string nombre = hijos[1].ToString().Replace(" (id)", "");
                        nombre = nombre.Trim();
                        ArrayList datos = new ArrayList();
                        datos.Add(tipoFuncion);
                        datos.Add(nombre);
                        datos.Add(hijos[6]);
                        metodosFunciones.Add(datos);
                        guardarParametros(hijos[3], nombre);
                    }
                    break;

                case "METOD":
                    if (hijos != null)
                    {
                        ParseTreeNode[] tipoFun = hijos[0].ChildNodes.ToArray();
                        string tipoFuncion = "Vacio";
                        string nombre = hijos[1].ToString().Replace(" (id)", "");
                        nombre = nombre.Trim();
                        ArrayList datos = new ArrayList();
                        datos.Add(tipoFuncion);
                        datos.Add(nombre);
                        datos.Add(hijos[6]);
                        metodosFunciones.Add(datos);
                        guardarParametros(hijos[3], nombre);
                    }
                    break;

                case "FUNPRIN":
                    if (hijos != null)
                    {
                        cuerpo(hijos[5], "principal");
                    }
                    break;


            }

            if (hijos != null)
            {
                for (int i = 0; i < hijos.Count(); i++)
                {
                    recorrerArbol(hijos[i]);
                }
            }

        }

        //---------------------------------------------------------------------------------Declaracion de Variables Globales--------------------------------------------

        public void declaracionGlobal(ParseTreeNode raiz, string tipo, ParseTreeNode expresion)
        {
            String inicio = raiz.ToString();
            ParseTreeNode[] hijos = null;
            if (raiz.ChildNodes.Count > 0) hijos = raiz.ChildNodes.ToArray();
            switch (inicio)
            {
                case "VARIOS":
                    ArrayList dato = new ArrayList();
                    dato.Add(tipo);
                    ParseTreeNode[] subHijo = hijos[0].ChildNodes.ToArray();
                    string nombre = Convert.ToString(subHijo[0].ToString().Replace(" (id)", ""));
                    int buscar = buscarVariableGlobal(nombre);
                    var resultado = Expresiones(expresion, "");
                    if (buscar == -1)
                    {
                        if (resultado != null)
                        {
                            //---------------------------------------------casteo automatico para Bool------------------------------------------------------
                            //------------------------------------------------------------------------------------------------------------------------------
                            if (tipo == "Bool")
                            {
                                if (resultado is Boolean)
                                {
                                    dato.Add(nombre);
                                    dato.Add(resultado);
                                    variablesGlobales.Add(dato);
                                }
                                else
                                {
                                    System.Diagnostics.Debug.WriteLine("No se puede Autocastear");
                                    errorSemantico.Add("No se puede Autocastear");
                                }
                                }
                            //----------------------------------------------casteo automatico para Bool-----------------------------------------------------
                            //-------------------------------------------------------------------------------------------------------------------------------
                            else if (tipo == "Double")
                            {
                                //---------------------------------------------------si es double no hay casteo-----------------------------
                                if (resultado is Double)
                                {
                                    dato.Add(nombre);
                                    dato.Add(resultado);
                                    variablesGlobales.Add(dato);
                                }
                                //---------------------------------------------------------si es boolean-------------------------------------------------
                                else if (resultado is Boolean)
                                {
                                    if (resultado == true)
                                    {
                                        dato.Add(nombre);
                                        dato.Add(1);
                                        variablesGlobales.Add(dato);
                                    }
                                    else
                                    {
                                        dato.Add(nombre);
                                        dato.Add(0);
                                        variablesGlobales.Add(dato);
                                    }

                                }
                                else if (resultado is Char)
                                {
                                    Double numero = Convert.ToDouble(resultado);
                                    dato.Add(nombre);
                                    dato.Add(numero);
                                    variablesGlobales.Add(dato);
                                }
                                else
                                {
                                    System.Diagnostics.Debug.WriteLine("No se puede Autocastear");
                                    errorSemantico.Add("No se puede Autocastear");
                                }
                            }
                            //-------------------------------------------------casteo automatico para int-------------------------------------------------
                            //---------------------------------------------------------------------------------------------------------------------------------
                            else if (tipo == "Int")
                            {
                                //---------------------------------------------------si es double no hay casteo-----------------------------
                                if (resultado is Double)
                                {
                                    dato.Add(nombre);
                                    dato.Add(resultado);
                                    variablesGlobales.Add(dato);
                                }
                                //---------------------------------------------------------si es boolean-------------------------------------------------
                                else if (resultado is Boolean)
                                {
                                    if (resultado == true)
                                    {
                                        dato.Add(nombre);
                                        dato.Add(1);
                                        variablesGlobales.Add(dato);
                                    }
                                    else
                                    {
                                        dato.Add(nombre);
                                        dato.Add(0);
                                        variablesGlobales.Add(dato);
                                    }

                                }
                                else if (resultado is Char)
                                {
                                    Double numero = (double)resultado;
                                    dato.Add(nombre);
                                    dato.Add(numero);
                                    variablesGlobales.Add(dato);
                                }
                                else
                                {
                                    System.Diagnostics.Debug.WriteLine("No se puede Autocastear");
                                    errorSemantico.Add("No se puede Autocastear");
                                }

                            }
                            //................................................casteo automatico para String-------------------------------------------------------
                            //--------------------------------------------------------------------------------------------------------------------------------
                            else if (tipo == "String")
                            {
                                String convertir = "";
                                if (resultado is Boolean)
                                {
                                    if (resultado == true) convertir = "1";
                                    else convertir = "0";
                                }
                                else
                                {
                                    convertir = Convert.ToString(resultado);
                                }

                                dato.Add(nombre);
                                dato.Add(convertir);
                                variablesGlobales.Add(dato);
                            }
                            /*-------------------------------------------------CASTEO AUTOMATICO A CHAR-------------------------------------------------------
                             -------------------------------------------------------------------------------------------------------------------------------*/
                            else if (tipo == "Char")
                            {
                                if (resultado is Char)
                                {
                                    string gg = Convert.ToString(resultado);
                                    System.Diagnostics.Debug.WriteLine(gg);
                                    dato.Add(nombre);
                                    dato.Add(resultado);
                                    variablesGlobales.Add(dato);
                                }
                                else if (resultado is Double)
                                {
                                    if (resultado > -1 && resultado < 256)
                                    {
                                        int numero = (int)resultado;
                                        char resu = (char)numero;
                                        dato.Add(nombre);
                                        dato.Add(resu);
                                        variablesGlobales.Add(dato);
                                    }
                                    else
                                    {
                                        System.Diagnostics.Debug.WriteLine("No se puede Autocastear supera el codigo Ascii");
                                        errorSemantico.Add("No se puede Autocastear supera el codigo Ascii");
                                    }
                                }
                                else
                                {
                                    System.Diagnostics.Debug.WriteLine("No se puede Autocastear");
                                    errorSemantico.Add("No se puede Autocastear");
                                }
                            }

                        }
                        else
                        {
                            dato.Add(nombre);
                            dato.Add(null);
                            variablesGlobales.Add(dato);
                        }

                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Error semantico variables globales repetida " + nombre);
                        errorSemantico.Add("Error semantico variables globales repetida " + nombre);
                        errorSemantico.Add("Variable: " + nombre + "ya se encuentra declarada");
                    }
                    break;
            }
            if (hijos != null)
            {
                for (int i = 0; i < hijos.Count(); i++)
                {
                    declaracionGlobal(hijos[i], tipo, expresion);
                }
            }
        }


        //---------------------------------------------------------------------------------Declaracion de Variables Locales--------------------------------------------

        public void declaracionLocal(ParseTreeNode raiz, string tipo, ParseTreeNode expresion, string metodo)
        {
            String inicio = raiz.ToString();
            ParseTreeNode[] hijos = null;
            if (raiz.ChildNodes.Count > 0) hijos = raiz.ChildNodes.ToArray();
            switch (inicio)
            {
                case "VARIOS":
                    ArrayList dato = new ArrayList();
                    dato.Add(metodo);
                    dato.Add(tipo);
                    ParseTreeNode[] subHijo = hijos[0].ChildNodes.ToArray();
                    string nombre = Convert.ToString(subHijo[0].ToString().Replace(" (id)", ""));
                    int buscar = buscarVariableLocal(nombre, metodo);
                    var resultado = Expresiones(expresion, metodo);
                    if (buscar == -1)
                    {
                        if (resultado != null)
                        {
                            //---------------------------------------------casteo automatico para Bool------------------------------------------------------
                            //------------------------------------------------------------------------------------------------------------------------------
                            if (tipo == "Bool")
                            {
                                if (resultado is Boolean)
                                {
                                    dato.Add(nombre);
                                    dato.Add(resultado);
                                    if (metodo == "principal") variablesLocalesMain.Add(dato); else variablesLocales.Add(dato);
                                }
                                else
                                {
                                    System.Diagnostics.Debug.WriteLine("No se puede Autocastear");
                                    errorSemantico.Add("No se puede Autocastear");
                                }
                            }
                            //----------------------------------------------casteo automatico para Bool-----------------------------------------------------
                            //-------------------------------------------------------------------------------------------------------------------------------
                            else if (tipo == "Double")
                            {
                                //---------------------------------------------------si es double no hay casteo-----------------------------
                                if (resultado is Double)
                                {
                                    dato.Add(nombre);
                                    dato.Add(resultado);
                                    if (metodo == "principal") variablesLocalesMain.Add(dato); else variablesLocales.Add(dato);
                                }
                                //---------------------------------------------------------si es boolean-------------------------------------------------
                                else if (resultado is Boolean)
                                {
                                    if (resultado == true)
                                    {
                                        dato.Add(nombre);
                                        dato.Add(1);
                                        if (metodo == "principal") variablesLocalesMain.Add(dato); else variablesLocales.Add(dato);
                                    }
                                    else
                                    {
                                        dato.Add(nombre);
                                        dato.Add(0);
                                        if (metodo == "principal") variablesLocalesMain.Add(dato); else variablesLocales.Add(dato);
                                    }

                                }
                                else if (resultado is Char)
                                {
                                    Double numero = Convert.ToDouble(resultado);
                                    dato.Add(nombre);
                                    dato.Add(numero);
                                    if (metodo == "principal") variablesLocalesMain.Add(dato); else variablesLocales.Add(dato);
                                }
                                else
                                {
                                    System.Diagnostics.Debug.WriteLine("No se puede Autocastear");
                                    errorSemantico.Add("No se puede Autocastear");
                                }
                            }
                            //-------------------------------------------------casteo automatico para int-------------------------------------------------
                            //---------------------------------------------------------------------------------------------------------------------------------
                            else if (tipo == "Int")
                            {
                                //---------------------------------------------------si es double no hay casteo-----------------------------
                                if (resultado is Double)
                                {
                                    dato.Add(nombre);
                                    dato.Add(resultado);
                                    if (metodo == "principal") variablesLocalesMain.Add(dato); else variablesLocales.Add(dato);
                                }
                                //---------------------------------------------------------si es boolean-------------------------------------------------
                                else if (resultado is Boolean)
                                {
                                    if (resultado == true)
                                    {
                                        dato.Add(nombre);
                                        dato.Add(1);
                                        if (metodo == "principal") variablesLocalesMain.Add(dato); else variablesLocales.Add(dato);
                                    }
                                    else
                                    {
                                        dato.Add(nombre);
                                        dato.Add(0);
                                        if (metodo == "principal") variablesLocalesMain.Add(dato); else variablesLocales.Add(dato);
                                    }

                                }
                                else if (resultado is Char)
                                {
                                    Double numero = (double)resultado;
                                    dato.Add(nombre);
                                    dato.Add(numero);
                                    if (metodo == "principal") variablesLocalesMain.Add(dato); else variablesLocales.Add(dato);
                                }
                                else
                                {
                                    System.Diagnostics.Debug.WriteLine("No se puede Autocastear");
                                    errorSemantico.Add("No se puede Autocastear");
                                }
                            }
                            //................................................casteo automatico para String-------------------------------------------------------
                            //--------------------------------------------------------------------------------------------------------------------------------
                            else if (tipo == "String")
                            {
                                String convertir = "";
                                if (resultado is Boolean)
                                {
                                    if (resultado == true) convertir = "1";
                                    else convertir = "0";
                                }
                                else
                                {
                                    convertir = Convert.ToString(resultado);
                                }

                                dato.Add(nombre);
                                dato.Add(convertir);
                                if (metodo == "principal") variablesLocalesMain.Add(dato); else variablesLocales.Add(dato);
                            }
                            /*-------------------------------------------------CASTEO AUTOMATICO A CHAR-------------------------------------------------------
                             -------------------------------------------------------------------------------------------------------------------------------*/
                            else if (tipo == "Char")
                            {
                                if (resultado is Char)
                                {
                                    string gg = Convert.ToString(resultado);
                                    System.Diagnostics.Debug.WriteLine(gg);
                                    dato.Add(nombre);
                                    dato.Add(resultado);
                                    if (metodo == "principal") variablesLocalesMain.Add(dato); else variablesLocales.Add(dato);
                                }
                                else if (resultado is Double)
                                {
                                    if (resultado > -1 && resultado < 256)
                                    {
                                        int numero = (int)resultado;
                                        char resu = (char)numero;
                                        dato.Add(nombre);
                                        dato.Add(resu);
                                        if (metodo == "principal") variablesLocalesMain.Add(dato); else variablesLocales.Add(dato);
                                    }
                                    else
                                    {
                                        System.Diagnostics.Debug.WriteLine("No se puede Autocastear supera el codigo Ascii");
                                        errorSemantico.Add("No se puede Autocastear supera el codigo Ascii");
                                    }

                                }
                                else
                                {
                                    System.Diagnostics.Debug.WriteLine("No se puede Autocastear");
                                    errorSemantico.Add("No se puede Autocastear");
                                }
                            }

                        }
                        else
                        {
                            dato.Add(nombre);
                            dato.Add(null);
                            if (metodo == "principal") variablesLocalesMain.Add(dato); else variablesLocales.Add(dato);
                        }

                    }
                    else
                    {
                        errorSemantico.Add("Error semantico variables Local repetida " + nombre);
                        System.Diagnostics.Debug.WriteLine("Error semantico variables Local repetida " + nombre);

                        errorSemantico.Add("Variable: " + nombre + "ya se encuentra declarada");
                    }
                    break;
            }
            if (hijos != null)
            {
                for (int i = 0; i < hijos.Count(); i++)
                {
                    declaracionLocal(hijos[i], tipo, expresion, metodo);
                }
            }
        }



        int buscarVariableGlobal(string nombre)
        {
            for (int i = 0; i < variablesGlobales.Count; i++)
            {
                ArrayList dato = (ArrayList)variablesGlobales[i];
                string name = Convert.ToString(dato[1]);
                name = name.Trim();
                if (name.Equals(nombre) && dato[2] != null) return i;

            }
            return -1;
        }

        int buscarVariableLocal(string nombre, string metodo)
        {
            if (metodo == "principal")
            {
                for (int i = 0; i < variablesLocalesMain.Count; i++)
                {
                    ArrayList dato = (ArrayList)variablesLocalesMain[i];
                    string met = Convert.ToString(dato[0]);
                    string name = Convert.ToString(dato[2]);
                    name = name.Trim();
                    if (name.Equals(nombre) && (met.Equals(metodo))) return i;

                }
            }
            else
            {
                for (int i = 0; i < variablesLocales.Count; i++)
                {
                    ArrayList dato = (ArrayList)variablesLocales[i];
                    string met = Convert.ToString(dato[0]);
                    string name = Convert.ToString(dato[2]);
                    name = name.Trim();
                    if (name.Equals(nombre) && (met.Equals(metodo))) return i;

                }
            }

            return -1;
        }

        int buscarParametro(string nombre, string metodo)
        {
            for (int i = 0; i < listaParametros.Count; i++)
            {
                ArrayList dato = (ArrayList)listaParametros[i];
                string met = Convert.ToString(dato[0]);
                string name = Convert.ToString(dato[2]);
                name = name.Trim();
                if (name.Equals(nombre) && (met.Equals(metodo))) return i;

            }
            return -1;
        }

        int buscarTemporal(string nombre, string metodo)
        {
            for (int i = 0; i < parametrosTemporales.Count; i++)
            {
                ArrayList dato = (ArrayList)parametrosTemporales[i];
                string met = Convert.ToString(dato[0]);
                string name = Convert.ToString(dato[2]);
                name = name.Trim();
                if (name.Equals(nombre) && (met.Equals(metodo)) && dato[3] != null) return i;

            }
            return -1;
        }
        //----------------------------------------------------------------------------Asignacion de variables Globales--------------------------------------------------------------
        public void asignacionVariablesGlobal(string nombre, ParseTreeNode expresion)
        {
            int buscar = buscarVariableGlobal(nombre);
            if (buscar >= 0)
            {
                var resultado = Expresiones(expresion, "");
                if (resultado != null)
                {
                    ArrayList datos = (ArrayList)variablesGlobales[buscar];
                    string tipo = Convert.ToString(datos[0]);
                    ArrayList dato = new ArrayList();
                    dato.Add(tipo);
                    //---------------------------------------------casteo automatico para Bool------------------------------------------------------
                    //------------------------------------------------------------------------------------------------------------------------------
                    if (tipo == "Bool")
                    {
                        if (resultado is Boolean)
                        {
                            dato.Add(nombre);
                            dato.Add(resultado);
                            variablesGlobales[buscar] = dato;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("No se puede Autocastear");
                            errorSemantico.Add("No se puede Autocastear");
                        }

                    }
                    //----------------------------------------------casteo automatico para Bool-----------------------------------------------------
                    //-------------------------------------------------------------------------------------------------------------------------------
                    else if (tipo == "Double")
                    {
                        //---------------------------------------------------si es double no hay casteo-----------------------------
                        if (resultado is Double)
                        {
                            dato.Add(nombre);
                            dato.Add(resultado);
                            variablesGlobales[buscar] = dato;
                        }
                        //---------------------------------------------------------si es boolean-------------------------------------------------
                        else if (resultado is Boolean)
                        {
                            if (resultado == true)
                            {
                                dato.Add(nombre);
                                dato.Add(1);
                                variablesGlobales[buscar] = dato;
                            }
                            else
                            {
                                dato.Add(nombre);
                                dato.Add(0);
                                variablesGlobales[buscar] = dato;
                            }

                        }
                        else if (resultado is Char)
                        {
                            Double numero = Convert.ToDouble(resultado);
                            dato.Add(nombre);
                            dato.Add(numero);
                            variablesGlobales[buscar] = dato;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("No se puede Autocastear");
                            errorSemantico.Add("No se puede Autocastear");
                        }
                    }
                    //-------------------------------------------------casteo automatico para int-------------------------------------------------
                    //---------------------------------------------------------------------------------------------------------------------------------
                    else if (tipo == "Int")
                    {
                        //---------------------------------------------------si es double no hay casteo-----------------------------
                        if (resultado is Double)
                        {
                            dato.Add(nombre);
                            dato.Add(resultado);
                            variablesGlobales[buscar] = dato;
                        }
                        //---------------------------------------------------------si es boolean-------------------------------------------------
                        else if (resultado is Boolean)
                        {
                            if (resultado == true)
                            {
                                dato.Add(nombre);
                                dato.Add(1);
                                variablesGlobales[buscar] = dato;
                            }
                            else
                            {
                                dato.Add(nombre);
                                dato.Add(0);
                                variablesGlobales[buscar] = dato;
                            }

                        }
                        else if (resultado is Char)
                        {
                            Double numero = (double)resultado;
                            dato.Add(nombre);
                            dato.Add(numero);
                            variablesGlobales[buscar] = dato;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("No se puede Autocastear");
                            errorSemantico.Add("No se puede Autocastear");
                        }
                    }
                    //................................................casteo automatico para String-------------------------------------------------------
                    //--------------------------------------------------------------------------------------------------------------------------------
                    else if (tipo == "String")
                    {
                        String convertir = "";
                        if (resultado is Boolean)
                        {
                            if (resultado == true) convertir = "1";
                            else convertir = "0";
                        }
                        else
                        {
                            convertir = Convert.ToString(resultado);
                        }

                        dato.Add(nombre);
                        dato.Add(convertir);
                        variablesGlobales[buscar] = dato;
                    }
                    /*-------------------------------------------------CASTEO AUTOMATICO A CHAR-------------------------------------------------------
                     -------------------------------------------------------------------------------------------------------------------------------*/
                    else if (tipo == "Char")
                    {
                        if (resultado is Char)
                        {
                            string gg = Convert.ToString(resultado);
                            System.Diagnostics.Debug.WriteLine(gg);
                            dato.Add(nombre);
                            dato.Add(resultado);
                            variablesGlobales[buscar] = dato;
                        }
                        else if (resultado is Double)
                        {
                            if (resultado > -1 && resultado < 256)
                            {
                                int numero = (int)resultado;
                                char resu = (char)numero;
                                dato.Add(nombre);
                                dato.Add(resu);
                                variablesGlobales[buscar] = dato;
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine("No se puede Autocastear supera el codigo Ascii");
                                errorSemantico.Add("No se puede Autocastear supera el codigo Ascii");
                            }

                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("No se puede Autocastear");
                            errorSemantico.Add("No se puede Autocastear");
                        }
                    }

                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Metodo: No se encuentra esta variable en este contexto " + nombre);
                errorSemantico.Add("Metodo: No se encuentra esta variable en este contexto " + nombre);
            }
        }

        public void asignacionVariablesLocal(string nombre, ParseTreeNode expresion, string metodo)
        {
            int buscar = buscarVariableLocal(nombre, metodo);
            if (buscar >= 0)
            {
                var resultado = Expresiones(expresion, metodo);
                if (resultado != null)
                {
                    ArrayList datos;
                    if (metodo == "principal") datos = (ArrayList)variablesLocalesMain[buscar];
                    else datos = (ArrayList)variablesLocales[buscar];
                    string tipo = Convert.ToString(datos[1]);
                    ArrayList dato = new ArrayList();
                    dato.Add(metodo);
                    dato.Add(tipo);
                    //---------------------------------------------casteo automatico para Bool------------------------------------------------------
                    //------------------------------------------------------------------------------------------------------------------------------
                    if (tipo == "Bool")
                    {
                        if (resultado is Boolean)
                        {
                            dato.Add(nombre);
                            dato.Add(resultado);
                            if (metodo == "principal") variablesLocalesMain[buscar] = dato; else variablesLocales[buscar] = dato;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("No se puede Autocastear");
                            errorSemantico.Add("No se puede Autocastear");
                        }

                    }
                    //----------------------------------------------casteo automatico para Bool-----------------------------------------------------
                    //-------------------------------------------------------------------------------------------------------------------------------
                    else if (tipo == "Double")
                    {
                        //---------------------------------------------------si es double no hay casteo-----------------------------
                        if (resultado is Double)
                        {
                            dato.Add(nombre);
                            dato.Add(resultado);
                            if (metodo == "principal") variablesLocalesMain[buscar] = dato; else variablesLocales[buscar] = dato;
                        }
                        //---------------------------------------------------------si es boolean-------------------------------------------------
                        else if (resultado is Boolean)
                        {
                            if (resultado == true)
                            {
                                dato.Add(nombre);
                                dato.Add(1);
                                if (metodo == "principal") variablesLocalesMain[buscar] = dato; else variablesLocales[buscar] = dato;
                            }
                            else
                            {
                                dato.Add(nombre);
                                dato.Add(0);
                                if (metodo == "principal") variablesLocalesMain[buscar] = dato; else variablesLocales[buscar] = dato;
                            }

                        }
                        else if (resultado is Char)
                        {
                            Double numero = Convert.ToDouble(resultado);
                            dato.Add(nombre);
                            dato.Add(numero);
                            if (metodo == "principal") variablesLocalesMain[buscar] = dato; else variablesLocales[buscar] = dato;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("No se puede Autocastear");
                            errorSemantico.Add("No se puede Autocastear");

                        }
                    }
                    //-------------------------------------------------casteo automatico para int-------------------------------------------------
                    //---------------------------------------------------------------------------------------------------------------------------------
                    else if (tipo == "Int")
                    {
                        //---------------------------------------------------si es double no hay casteo-----------------------------
                        if (resultado is Double)
                        {
                            dato.Add(nombre);
                            dato.Add(resultado);
                            if (metodo == "principal") variablesLocalesMain[buscar] = dato; else variablesLocales[buscar] = dato;
                        }
                        //---------------------------------------------------------si es boolean-------------------------------------------------
                        else if (resultado is Boolean)
                        {
                            if (resultado == true)
                            {
                                dato.Add(nombre);
                                dato.Add(1);
                                if (metodo == "principal") variablesLocalesMain[buscar] = dato; else variablesLocales[buscar] = dato;
                            }
                            else
                            {
                                dato.Add(nombre);
                                dato.Add(0);
                                if (metodo == "principal") variablesLocalesMain[buscar] = dato; else variablesLocales[buscar] = dato;
                            }

                        }
                        else if (resultado is Char)
                        {
                            Double numero = (double)resultado;
                            dato.Add(nombre);
                            dato.Add(numero);
                            if (metodo == "principal") variablesLocalesMain[buscar] = dato; else variablesLocales[buscar] = dato;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("No se puede Autocastear");
                            errorSemantico.Add("No se puede Autocastear");
                        }

                    }
                    //................................................casteo automatico para String-------------------------------------------------------
                    //--------------------------------------------------------------------------------------------------------------------------------
                    else if (tipo == "String")
                    {
                        String convertir = "";
                        if (resultado is Boolean)
                        {
                            if (resultado == true) convertir = "1";
                            else convertir = "0";
                        }
                        else
                        {
                            convertir = Convert.ToString(resultado);
                        }

                        dato.Add(nombre);
                        dato.Add(convertir);
                        if (metodo == "principal") variablesLocalesMain[buscar] = dato; else variablesLocales[buscar] = dato;
                    }
                    /*-------------------------------------------------CASTEO AUTOMATICO A CHAR-------------------------------------------------------
                     -------------------------------------------------------------------------------------------------------------------------------*/
                    else if (tipo == "Char")
                    {
                        if (resultado is Char)
                        {
                            string gg = Convert.ToString(resultado);
                            System.Diagnostics.Debug.WriteLine(gg);
                            dato.Add(nombre);
                            dato.Add(resultado);
                            if (metodo == "principal") variablesLocalesMain[buscar] = dato; else variablesLocales[buscar] = dato;
                        }
                        else if (resultado is Double)
                        {
                            if (resultado > -1 && resultado < 256)
                            {
                                int numero = (int)resultado;
                                char resu = (char)numero;
                                dato.Add(nombre);
                                dato.Add(resu);
                                if (metodo == "principal") variablesLocalesMain[buscar] = dato; else variablesLocales[buscar] = dato;
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine("No se puede Autocastear supera el codigo Ascii");
                                errorSemantico.Add("No se puede Autocastear supera el codigo Ascii");
                            }

                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("No se puede Autocastear");
                            errorSemantico.Add("No se puede Autocastear ");
                        }

                    }

                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Metodo: No se encuentra esta variable en este contexto " + nombre);
                errorSemantico.Add("Metodo: No se encuentra esta variable en este contexto " + nombre);
            }

        }

        /*--------------------------------------------------------------------------------VARIABLES LOCALES---------------------------------------------------------------
         ---------------------------------------------------------------------------------------------------------------------------------------------------------------*/

        public void guardarParametros(ParseTreeNode raiz, string nombre)
        {
            string Inicio = raiz.ToString();
            ParseTreeNode[] hijos = null;
            if (raiz.ChildNodes.Count > 0) hijos = raiz.ChildNodes.ToArray();
            switch (Inicio)
            {

                case "DECLAPARA":
                    ArrayList dato = new ArrayList();

                    if (hijos != null)
                    {

                        dato.Add(nombre);
                        ParseTreeNode[] subHijo = hijos[0].ChildNodes.ToArray();
                        dato.Add(subHijo[0].ToString().Replace(" (Keyword)", ""));
                        dato.Add(hijos[1].ToString().Replace("(id)", ""));
                        dato.Add(null);
                        listaParametros.Add(dato);

                    }




                    break;
            }
            if (hijos != null)
            {
                for (int i = 0; i < hijos.Count(); i++)
                {
                    guardarParametros(hijos[i], nombre);
                }
            }
        }


        /*----------------------------------------------------------------------CUERPO DEL PROGRAMA---------------------------------------------------------------
         --------------------------------------------------------------------------------------------------------------------------------------------------------*/
        public void cuerpo(ParseTreeNode raiz, string metodo)
        {
            String inicio = raiz.ToString();
            ParseTreeNode[] hijos = null;
            if (raiz.ChildNodes.Count > 0) hijos = raiz.ChildNodes.ToArray();
            switch (inicio)
            {

                //-------------------------------------------------------------RETORNAR-----------------------------------------------------------------
                case "RETORN":
                    if (hijos != null)
                    {

                        if (!(hijos[1].ToString().Contains("; (Key symbol)")))
                        {
                            ArrayList dato = new ArrayList();
                            dato.Add(metodo);
                            dato.Add(Expresiones(hijos[1], metodo));
                            retornoMetodos.Add(dato);
                        }

                        hijos = null;
                    }
                    hijos = null;
                    break;


                //---------------------------------------------------Declaracion y asignacion de variables--------------------------------------------
                case "DECLARACION2":
                    if (hijos != null)
                    {
                        ParseTreeNode[] tipo = hijos[0].ChildNodes.ToArray();
                        string tip = tipo[0].ToString().Replace(" (Keyword)", "");
                        if (hijos.Length > 3)
                        {
                            declaracionLocal(raiz, tip, hijos[3], metodo);

                        }
                        else declaracionLocal(raiz, tip, null, metodo);
                    }
                    break;


                //--------------------------------------------ASIGNACION DE VARIABLES------------------------------------------------------------------
                case "ASIGNACION2":
                    if (hijos != null)
                    {
                        string nombre = Convert.ToString(hijos[0]);
                        nombre = nombre.Replace(" (id)", "");
                        nombre = nombre.Trim();

                        asignacionVariablesLocal(nombre, hijos[2], metodo);
                    }
                    break;



                //---------------------------------------------------PRINT-----------------------------------------------------------------------------------
                case "PRINT":
                    if (hijos != null)
                    {
                        mensaje = hijos[2].ToString().Replace(" (tString)", "");
                        analizarMostrar(raiz, metodo);
                        mostrar.Add(mensaje);
                        //mensaje = "";
                        conta = 0;
                        String sa1 = Convert.ToString(mensaje);
                        System.Diagnostics.Debug.WriteLine("Imprimir puso: " +sa1);
                    }
                    break;


                //--------------------------------------------------------------------PARA EL IF--------------------------------------------
                case "SENTSI":
                    if (hijos != null)
                    {
                        Boolean obtener = Convert.ToBoolean(Expresiones(hijos[2], metodo));
                        if (obtener == true) { cuerpo(hijos[5], metodo); }
                        else
                        {
                            ParseTreeNode[] hijosElse = hijos[7].ChildNodes.ToArray();
                            if (hijosElse.Count() > 0)
                            {
                                cuerpo(hijosElse[2], metodo);
                            }
                        }
                    }
                    hijos = null;

                    break;
                //------------------------------------------------------------------para el for----------------------------------------------
                case "SENTPARA":
                    if (hijos != null)
                    {
                        ArrayList dato = new ArrayList();
                        dato.Add(metodo);
                        dato.Add("Double");
                        dato.Add(hijos[3].ToString().Replace(" (id)", ""));
                        dato.Add(Expresiones(hijos[5], metodo));
                        if (metodo == "principal") variablesLocalesMain.Add(dato);
                        else variablesLocales.Add(dato);
                        string operacion = hijos[9].ToString().Replace(" (Key symbol)", "");


                        while (Expresiones(hijos[7], metodo) == true && continuar)
                        {
                            cuerpo(hijos[12], metodo);
                            if (operacion.Equals("++"))
                            {
                                int buscar = buscarVariableLocal(hijos[3].ToString().Replace(" (id)", ""), metodo);
                                Double actual = 0;
                                if (metodo == "principal")
                                {
                                    ArrayList dats = (ArrayList)variablesLocalesMain[buscar];
                                    actual = Convert.ToDouble(dats[3]);
                                    dats[3] = actual + 1;
                                    variablesLocalesMain.RemoveAt(buscar);
                                    variablesLocalesMain.Insert(buscar, dats);
                                }
                                else
                                {
                                    ArrayList dats = (ArrayList)variablesLocales[buscar];
                                    actual = Convert.ToDouble(dats[3]);
                                    dats[3] = actual + 1;
                                    variablesLocales[buscar] = dats;
                                    dats = (ArrayList)variablesLocales[buscar];
                                }

                            }


                            else
                            {
                                int buscar = buscarVariableLocal(hijos[3].ToString().Replace(" (id)", ""), metodo);
                                if (buscar > -1)
                                {
                                    if (metodo == "principal")
                                    {
                                        ArrayList dats = (ArrayList)variablesLocalesMain[buscar];
                                        dats[3] = Convert.ToDouble(dats[3]) - 1;
                                        variablesLocalesMain[buscar] = dats;
                                    }
                                    else
                                    {
                                        ArrayList dats = (ArrayList)variablesLocales[buscar];
                                        dats[3] = Convert.ToDouble(dats[3]) - 1;
                                        variablesLocales[buscar] = dats;
                                    }
                                }
                                else break;

                            }
                        }
                        continuar = true;
                        hijos = null;
                    }
                    break;


                case "LLAMADAS":
                    if (hijos != null)
                    {
                        String nombeme = Convert.ToString(hijos[0]);
                        nombeme = nombeme.Replace(" (id)", "");
                        nombeme = nombeme.Trim();
                        ParseTreeNode first = buscarCuerpo(nombeme);
                        if (first != null)
                        {
                            setearParametros(hijos[2], nombeme, metodo);
                            resetearParametros(nombeme);
                            resetarVariablesLocales(nombeme);
                            int eliminar = cantidadParametros(nombeme);

                            for (int j = 0; j < eliminar; j++)
                            {
                                parametrosTemporales.RemoveAt(j);
                                eliminar--;
                            }
                            cuerpo(first, nombeme);
                        }
                    }
                    break;


                    /*------------------------------------while-------------------------*/

                case "SENTMIENTRAS":
                    if (hijos != null)
                    {
                        var obtener = Convert.ToBoolean(Expresiones(hijos[2], metodo));///obtiene la posicion de la expresion
                        var a = Expresiones(hijos[2], metodo);
                        while (a == true && continuar)
                        { ///si la condicion es verdadera se sale del ciclo 

                            cuerpo(hijos[5], metodo);// de lo contrario hara todo lo que hay dentro del mientras

                            a = Expresiones(hijos[2], metodo);


                        }

                        hijos = null;
                        continuar = true;
                    }

                    break;

                    /*-------------------------------------do while----------------------------*/

                case "SENTHASTA":

                    if (hijos != null)
                    {

                        Boolean obtener1 = Convert.ToBoolean(Expresiones(hijos[2], metodo));///obtiene la posicion de la expresion
                        var b = Expresiones(hijos[2], metodo);

                        do
                        {

                            b = Expresiones(hijos[2], metodo);

                            cuerpo(hijos[5], metodo);// de lo contrario hara todo lo que hay dentro del mientras


                        }
                        while (b == true && continuar);
                        hijos = null;
                        continuar = true;

                    }
                    break;


                    /********************dibujar expresion-------------------------------*/

                case "DIBEXP":

                    ConstruirArbol(hijos[2]);
                    GraficarArbol("~/Arbol1.txt", direccion+"DibujarEXP");
                    break;

                    //////////////////////////////caso del switch

                case "SENTSELECCIONA":

                    if (hijos != null)
                    {
                        var obtener3 = Convert.ToString(Expresiones(hijos[2], metodo));


                        Case(hijos[5], metodo,obtener3, hijos[6]);

                        hijos = null;
                        continuar = true;
                    }
                    break;

                case "Continuar (Keyword)":
                    raiz = null;
                    return;
                    break;

                case "Detener (Keyword)":
                    continuar = false;
                    raiz = null;
                    break;

                case "DIBAST":
                    ParseTreeNode ra = buscarCuerpo(hijos[2].ToString().Replace(" (id)", ""));
                    if (ra != null)
                    {
                        ConstruirArbol2(ra);
                        GraficarArbol("~/Arbol1.txt", direccion+"DibujarAst");
                    }


                    break;

            }

            if (hijos != null)
            {
                for (int i = 0; i < hijos.Length; i++)
                {
                    cuerpo(hijos[i], metodo);
                }
            }





        }

        /*----------------------------------------------------------------------PRINT---------------------------------------------------------------------------------
         ----------------------------------------------------------------------------------------------------------------------------------------------------------*/

        public void analizarMostrar(ParseTreeNode raiz, string metodo)
        {
            string Inicio = raiz.ToString();
            ParseTreeNode[] hijos = null;
            if (raiz.ChildNodes.Count > 0) hijos = raiz.ChildNodes.ToArray();
            switch (Inicio)
            {

                case "VARIOS2":

                    if (hijos != null)
                    {
                        var obtener = Expresiones(hijos[1], metodo);
                        string nuevo = Convert.ToString(obtener);
                        string repla = "{" + conta + "}";
                        mensaje = mensaje.Replace(repla, nuevo);
                        conta++;
                    }
                    break;
            }
            if (hijos != null)
            {
                for (int i = 0; i < hijos.Count(); i++)
                {
                    analizarMostrar(hijos[i], metodo);
                }
            }
        }


        //------------------------------------------------------------------------------EXPRESIONES-----------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------Encargado de las Expresiones---------------------------------------------------
        public dynamic Expresiones(ParseTreeNode raiz, string metodo)
        {
            if (raiz != null)
            {
                string Inicio = raiz.ToString();
                ParseTreeNode[] hijos = null;
                if (raiz.ChildNodes.Count > 0)
                {
                    hijos = raiz.ChildNodes.ToArray();
                }
                if (hijos != null)
                {


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
                                        //-----------------------------------------No importa si es char o string siempre devuelve string------------------------------
                                        if (operando1 is String && operando2 is String || operando1 is String && operando2 is Char || operando1 is Char && operando2 is String)
                                        {
                                            String sa1 = Convert.ToString(Expresiones(hijos[prueba1], metodo));
                                            String sa2 = Convert.ToString(Expresiones(hijos[prueba2], metodo));

                                            return sa1 + sa2;
                                        }
                                        //-------------------------------------------------------si es un numero o un string siempre string-------------------------------
                                        else if ((operando1 is double && operando2 is String) || (operando1 is String && operando2 is double))
                                        {
                                            String sa1 = Convert.ToString(Expresiones(hijos[prueba1], metodo));
                                            String sa2 = Convert.ToString(Expresiones(hijos[prueba2], metodo));
                                            return sa1 + sa2;

                                        }
                                        //---------------------------------------------------------si es un char y un char siempre char------------------------------
                                        else if (operando1 is Char && operando2 is Char)
                                        {
                                            String sa1 = Convert.ToString(Expresiones(hijos[prueba1], metodo));
                                            String sa2 = Convert.ToString(Expresiones(hijos[prueba2], metodo));
                                            String res = sa1 + sa2;
                                            return Convert.ToChar(res[0]);
                                        }
                                        //-----------------------------------------si es char bool entonces es error-----------------------------------------------
                                        else if ((operando1 is Char && operando2 is Boolean) || (operando1 is Boolean && operando2 is Char))
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede castear bool y char");
                                            errorSemantico.Add("Error Semantico no se puede castear bool y char");

                                            return null;
                                        }
                                        //------------------------------------------------si es bool y bool entonces es un double--------------------------------------
                                        else if (operando1 is Boolean && operando2 is Boolean)
                                        {
                                            Double sa1 = Convert.ToDouble(Expresiones(hijos[prueba1], metodo));
                                            Double sa2 = Convert.ToDouble(Expresiones(hijos[prueba2], metodo));
                                            return sa1 + sa2;
                                        }
                                        //-----------------------------------------------------si es bool Double entonces es double-------------------------------
                                        else if ((operando1 is Boolean && operando2 is Double) || (operando1 is Double && operando2 is Boolean))
                                        {
                                            Double sa1 = Convert.ToDouble(Expresiones(hijos[prueba1], metodo));
                                            Double sa2 = Convert.ToDouble(Expresiones(hijos[prueba2], metodo));
                                            return sa1 + sa2;
                                        }
                                        //-----------------------------------------Si es string y es un boolean es string--------------------------------------------
                                        else if ((operando1 is String && operando2 is Boolean) || (operando1 is Boolean && operando2 is String))
                                        {
                                            String sa1 = Convert.ToString(Expresiones(hijos[prueba1], metodo));
                                            String sa2 = Convert.ToString(Expresiones(hijos[prueba2], metodo));
                                            return sa1 + sa2;
                                        }
                                        //-----------------------------------------si es double y un char entonces double-------------------------------------------
                                        else if ((operando1 is Char && operando2 is Double) || (operando1 is Double && operando2 is Char))
                                        {
                                            Double sa1;
                                            Double sa2;
                                            if (operando1 is Char)
                                            {
                                                sa2 = Convert.ToDouble(Expresiones(hijos[prueba2], metodo));
                                                int valor = (int)Expresiones(hijos[prueba1], metodo);
                                                sa1 = Convert.ToDouble(valor);

                                            }
                                            else
                                            {
                                                sa1 = Convert.ToDouble(Expresiones(hijos[prueba1], metodo));
                                                int valor = (int)Expresiones(hijos[prueba2], metodo);
                                                sa2 = Convert.ToDouble(valor);
                                            }
                                            return sa1 + sa2;
                                        }
                                        else
                                        {
                                            String sa1 = Convert.ToString(Expresiones(hijos[prueba1], metodo));
                                            String sa2 = Convert.ToString(Expresiones(hijos[prueba2], metodo));
                                            Double sa11;
                                            Double sa21;
                                            Double.TryParse(sa1, out sa11);
                                            Double.TryParse(sa2, out sa21);
                                            return sa11 + sa21;
                                        }

                                    }
                                case "-":
                                    {
                                        //-----------------------------------------No importa si es char o string siempre devuelve string------------------------------
                                        if (operando1 is String && operando2 is String || operando1 is String && operando2 is Char || operando1 is Char && operando2 is String)
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede restar string o char");
                                            errorSemantico.Add("Error Semantico no se puede restar string o char");

                                            return null;
                                        }
                                        //-------------------------------------------------------si es un numero o un string siempre string-------------------------------
                                        else if ((operando1 is double && operando2 is String) || (operando1 is String && operando2 is double))
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede restar char");
                                            errorSemantico.Add("Error Semantico no se puede restar char");

                                            return null;

                                        }
                                        //---------------------------------------------------------si es un char y un char siempre char------------------------------
                                        else if (operando1 is Char && operando2 is Char)
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede restar  char");
                                            errorSemantico.Add("Error Semantico no se puede restar  char");

                                            return null;
                                        }
                                        //-----------------------------------------si es char bool entonces es error-----------------------------------------------
                                        else if ((operando1 is Char && operando2 is Boolean) || (operando1 is Boolean && operando2 is Char))
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede castear bool y char");
                                            errorSemantico.Add("Error Semantico no se puede castear bool y char");

                                            return null;
                                        }
                                        //------------------------------------------------si es bool y bool entonces es un double--------------------------------------
                                        else if (operando1 is Boolean && operando2 is Boolean)
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede restar bool y bool");
                                            errorSemantico.Add("Error Semantico no se puede restar bool y bool");

                                            return null;
                                        }
                                        //-----------------------------------------------------si es bool Double entonces es double-------------------------------
                                        else if ((operando1 is Boolean && operando2 is Double) || (operando1 is Double && operando2 is Boolean))
                                        {
                                            Double sa1 = Convert.ToDouble(Expresiones(hijos[prueba1], metodo));
                                            Double sa2 = Convert.ToDouble(Expresiones(hijos[prueba2], metodo));
                                            return sa1 - sa2;
                                        }
                                        //-----------------------------------------Si es string y es un boolean es string--------------------------------------------
                                        else if ((operando1 is String && operando2 is Boolean) || (operando1 is Boolean && operando2 is String))
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede restar string y un bool");
                                            errorSemantico.Add("Error Semantico no se puede restar string y un bool");

                                            return null;
                                        }
                                        //-----------------------------------------si es double y un char entonces double-------------------------------------------
                                        else if ((operando1 is Char && operando2 is Double) || (operando1 is Double && operando2 is Char))
                                        {
                                            Double sa1;
                                            Double sa2;
                                            if (operando1 is Char)
                                            {
                                                sa2 = Convert.ToDouble(Expresiones(hijos[prueba2], metodo));
                                                int valor = (int)Expresiones(hijos[prueba1], metodo);
                                                sa1 = Convert.ToDouble(valor);

                                            }
                                            else
                                            {
                                                sa1 = Convert.ToDouble(Expresiones(hijos[prueba1], metodo));
                                                int valor = (int)Expresiones(hijos[prueba2], metodo);
                                                sa2 = Convert.ToDouble(valor);
                                            }
                                            return sa1 - sa2;
                                        }
                                        else
                                        {
                                            String sa1 = Convert.ToString(Expresiones(hijos[prueba1], metodo));
                                            String sa2 = Convert.ToString(Expresiones(hijos[prueba2], metodo));
                                            Double sa11;
                                            Double sa21;
                                            Double.TryParse(sa1, out sa11);
                                            Double.TryParse(sa2, out sa21);
                                            return sa11 - sa21;
                                        }
                                    }
                                case "*":
                                    {
                                        //-----------------------------------------No importa si es char o string siempre devuelve string------------------------------
                                        if (operando1 is String && operando2 is String || operando1 is String && operando2 is Char || operando1 is Char && operando2 is String)
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede multiplicar string o char");
                                            errorSemantico.Add("Error Semantico no se puede multiplicar string o char");

                                            return null;
                                        }
                                        //-------------------------------------------------------si es un numero o un string siempre string-------------------------------
                                        else if ((operando1 is double && operando2 is String) || (operando1 is String && operando2 is double))
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede multiplicar char");
                                            errorSemantico.Add("Error Semantico no se puede multiplicar char");

                                            return null;

                                        }
                                        //---------------------------------------------------------si es un char y un char siempre char------------------------------
                                        else if (operando1 is Char && operando2 is Char)
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede multiplicar  char");
                                            errorSemantico.Add("Error Semantico no se puede multiplicar char");

                                            return null;
                                        }
                                        //-----------------------------------------si es char bool entonces es error-----------------------------------------------
                                        else if ((operando1 is Char && operando2 is Boolean) || (operando1 is Boolean && operando2 is Char))
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede castear bool y char");
                                            errorSemantico.Add("Error Semantico no se puede castear bool y char");

                                            return null;
                                        }
                                        //------------------------------------------------si es bool y bool entonces es un double--------------------------------------
                                        else if (operando1 is Boolean && operando2 is Boolean)
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede multiplicar bool y bool");
                                            errorSemantico.Add("Error Semantico no se puede multiplicar bool y bool");

                                            return null;
                                        }
                                        //-----------------------------------------------------si es bool Double entonces es double-------------------------------
                                        else if ((operando1 is Boolean && operando2 is Double) || (operando1 is Double && operando2 is Boolean))
                                        {
                                            Double sa1 = Convert.ToDouble(Expresiones(hijos[prueba1], metodo));
                                            Double sa2 = Convert.ToDouble(Expresiones(hijos[prueba2], metodo));
                                            return sa1 * sa2;
                                        }
                                        //-----------------------------------------Si es string y es un boolean es string--------------------------------------------
                                        else if ((operando1 is String && operando2 is Boolean) || (operando1 is Boolean && operando2 is String))
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede multiplicar string y un bool");
                                            errorSemantico.Add("Error Semantico no se puede multiplicar string y un bool");

                                            return null;
                                        }
                                        //-----------------------------------------si es double y un char entonces double-------------------------------------------
                                        else if ((operando1 is Char && operando2 is Double) || (operando1 is Double && operando2 is Char))
                                        {
                                            Double sa1;
                                            Double sa2;
                                            if (operando1 is Char)
                                            {
                                                sa2 = Convert.ToDouble(Expresiones(hijos[prueba2], metodo));
                                                int valor = (int)Expresiones(hijos[prueba1], metodo);
                                                sa1 = Convert.ToDouble(valor);

                                            }
                                            else
                                            {
                                                sa1 = Convert.ToDouble(Expresiones(hijos[prueba1], metodo));
                                                int valor = (int)Expresiones(hijos[prueba2], metodo);
                                                sa2 = Convert.ToDouble(valor);
                                            }
                                            return sa1 * sa2;
                                        }
                                        else
                                        {
                                            String sa1 = Convert.ToString(Expresiones(hijos[prueba1], metodo));
                                            String sa2 = Convert.ToString(Expresiones(hijos[prueba2], metodo));
                                            Double sa11;
                                            Double sa21;
                                            Double.TryParse(sa1, out sa11);
                                            Double.TryParse(sa2, out sa21);
                                            return sa11 * sa21;
                                        }
                                    }
                                case "/":
                                    {
                                        //-----------------------------------------No importa si es char o string siempre devuelve string------------------------------
                                        if (operando1 is String && operando2 is String || operando1 is String && operando2 is Char || operando1 is Char && operando2 is String)
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede dividir string o char");
                                            errorSemantico.Add("Error Semantico no se puede dividir string o char");

                                            return null;
                                        }
                                        //-------------------------------------------------------si es un numero o un string siempre string-------------------------------
                                        else if ((operando1 is double && operando2 is String) || (operando1 is String && operando2 is double))
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede dividir char");
                                            errorSemantico.Add("Error Semantico no se puede dividir char");

                                            return null;

                                        }
                                        //---------------------------------------------------------si es un char y un char siempre char------------------------------
                                        else if (operando1 is Char && operando2 is Char)
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede dividir  char");
                                            errorSemantico.Add("Error Semantico no se puede dividir char");

                                            return null;
                                        }
                                        //-----------------------------------------si es char bool entonces es error-----------------------------------------------
                                        else if ((operando1 is Char && operando2 is Boolean) || (operando1 is Boolean && operando2 is Char))
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede castear bool y char");
                                            errorSemantico.Add("Error Semantico no se puede castear bool y char");


                                            return null;
                                        }
                                        //------------------------------------------------si es bool y bool entonces es un double--------------------------------------
                                        else if (operando1 is Boolean && operando2 is Boolean)
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede dividir bool y bool");
                                            errorSemantico.Add("Error Semantico no se puede dividir bool y bool");

                                            return null;
                                        }
                                        //-----------------------------------------------------si es bool Double entonces es double-------------------------------
                                        else if ((operando1 is Boolean && operando2 is Double) || (operando1 is Double && operando2 is Boolean))
                                        {
                                            Double sa1 = Convert.ToDouble(Expresiones(hijos[prueba1], metodo));
                                            Double sa2 = Convert.ToDouble(Expresiones(hijos[prueba2], metodo));
                                            return sa1 / sa2;
                                        }
                                        //-----------------------------------------Si es string y es un boolean es string--------------------------------------------
                                        else if ((operando1 is String && operando2 is Boolean) || (operando1 is Boolean && operando2 is String))
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede dividir string y un bool");
                                            errorSemantico.Add("Error Semantico no se puede dividir string y un bool");

                                            return null;
                                        }
                                        //-----------------------------------------si es double y un char entonces double-------------------------------------------
                                        else if ((operando1 is Char && operando2 is Double) || (operando1 is Double && operando2 is Char))
                                        {
                                            Double sa1;
                                            Double sa2;
                                            if (operando1 is Char)
                                            {
                                                sa2 = Convert.ToDouble(Expresiones(hijos[prueba2], metodo));
                                                int valor = (int)Expresiones(hijos[prueba1], metodo);
                                                sa1 = Convert.ToDouble(valor);

                                            }
                                            else
                                            {
                                                sa1 = Convert.ToDouble(Expresiones(hijos[prueba1], metodo));
                                                int valor = (int)Expresiones(hijos[prueba2], metodo);
                                                sa2 = Convert.ToDouble(valor);
                                            }
                                            return sa1 / sa2;
                                        }
                                        else
                                        {
                                            String sa1 = Convert.ToString(Expresiones(hijos[prueba1], metodo));
                                            String sa2 = Convert.ToString(Expresiones(hijos[prueba2], metodo));
                                            Double sa11;
                                            Double sa21;
                                            Double.TryParse(sa1, out sa11);
                                            Double.TryParse(sa2, out sa21);
                                            return sa11 / sa21;
                                        }
                                    }
                                case "^":
                                    {
                                        //-----------------------------------------No importa si es char o string siempre devuelve string------------------------------
                                        if (operando1 is String && operando2 is String || operando1 is String && operando2 is Char || operando1 is Char && operando2 is String)
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede sacar potencia de string o char");
                                            errorSemantico.Add("Error Semantico no se puede sacar potencia de string o char");

                                            return null;
                                        }
                                        //-------------------------------------------------------si es un numero o un string siempre string-------------------------------
                                        else if ((operando1 is double && operando2 is String) || (operando1 is String && operando2 is double))
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede sacar potencia de char");
                                            errorSemantico.Add("Error Semantico no se puede sacar potencia de char");

                                            return null;

                                        }
                                        //---------------------------------------------------------si es un char y un char siempre char------------------------------
                                        else if (operando1 is Char && operando2 is Char)
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede sacar potencia de  char");

                                            errorSemantico.Add("Error Semantico no se puede sacar potencia de  char");

                                            return null;
                                        }
                                        //-----------------------------------------si es char bool entonces es error-----------------------------------------------
                                        else if ((operando1 is Char && operando2 is Boolean) || (operando1 is Boolean && operando2 is Char))
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede castear bool y char");
                                            errorSemantico.Add("Error Semantico no se puede castear bool y char");

                                            return null;
                                        }
                                        //------------------------------------------------si es bool y bool entonces es un double--------------------------------------
                                        else if (operando1 is Boolean && operando2 is Boolean)
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede sacar potencia de bool y bool");
                                            errorSemantico.Add("Error Semantico no se puede sacar potencia de bool y bool");

                                            return null;
                                        }
                                        //-----------------------------------------------------si es bool Double entonces es double-------------------------------
                                        else if ((operando1 is Boolean && operando2 is Double) || (operando1 is Double && operando2 is Boolean))
                                        {
                                            Double sa1 = Convert.ToDouble(Expresiones(hijos[prueba1], metodo));
                                            Double sa2 = Convert.ToDouble(Expresiones(hijos[prueba2], metodo));
                                            return Math.Pow(sa1, sa2);
                                        }
                                        //-----------------------------------------Si es string y es un boolean es string--------------------------------------------
                                        else if ((operando1 is String && operando2 is Boolean) || (operando1 is Boolean && operando2 is String))
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede sacar potencia de string y un bool");
                                            errorSemantico.Add("Error Semantico no se puede sacar potencia de string y un bool");

                                            return null;
                                        }
                                        //-----------------------------------------si es double y un char entonces double-------------------------------------------
                                        else if ((operando1 is Char && operando2 is Double) || (operando1 is Double && operando2 is Char))
                                        {
                                            Double sa1;
                                            Double sa2;
                                            if (operando1 is Char)
                                            {
                                                sa2 = Convert.ToDouble(Expresiones(hijos[prueba2], metodo));
                                                int valor = (int)Expresiones(hijos[prueba1], metodo);
                                                sa1 = Convert.ToDouble(valor);
                                            }
                                            else
                                            {
                                                sa1 = Convert.ToDouble(Expresiones(hijos[prueba1], metodo));
                                                int valor = (int)Expresiones(hijos[prueba2], metodo);
                                                sa2 = Convert.ToDouble(valor);
                                            }
                                            return Math.Pow(sa1, sa2);
                                        }
                                        else
                                        {
                                            if (operando1 is Double && operando2 is Double)
                                                return Math.Pow(operando1, operando2);
                                            else
                                                return null;
                                        }


                                    }
                                case "<":
                                    {
                                        if (operando1 is String && operando2 is String)
                                        {
                                            String sa1 = Convert.ToString(Expresiones(hijos[prueba1], metodo));
                                            String sa2 = Convert.ToString(Expresiones(hijos[prueba2], metodo));
                                            int resultado = String.Compare(sa1, sa2);
                                            if (resultado < 0) return true;
                                            else if (resultado == 0) return false;
                                            else return false;
                                        }
                                        else if (operando1 is Double && operando2 is Double) return operando1 < operando2;
                                        else
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede obtener el menor de dos boolean");
                                            errorSemantico.Add("Error Semantico no se puede obtener el menor de dos boolean");

                                            return null;
                                        }
                                    }
                                case ">":
                                    {
                                        if (operando1 is String && operando2 is String)
                                        {
                                            String sa1 = Convert.ToString(Expresiones(hijos[prueba1], metodo));
                                            String sa2 = Convert.ToString(Expresiones(hijos[prueba2], metodo));
                                            int resultado = String.Compare(sa1, sa2);
                                            if (resultado < 0) return false;
                                            else if (resultado == 0) return false;
                                            else return true;
                                        }
                                        else if (operando1 is Double && operando2 is Double) return operando1 > operando2;
                                        else
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede obtener el mayor de dos boolean");
                                            errorSemantico.Add("Error Semantico no se puede obtener el mayor de dos boolean");

                                            return null;
                                        }
                                    }

                                case "<=":
                                    {
                                        if (operando1 is String && operando2 is String)
                                        {
                                            String sa1 = Convert.ToString(Expresiones(hijos[prueba1], metodo));
                                            String sa2 = Convert.ToString(Expresiones(hijos[prueba2], metodo));
                                            int resultado = String.Compare(sa1, sa2);
                                            if (resultado < 0) return true;
                                            else if (resultado == 0) return true;
                                            else return false;
                                        }
                                        else if (operando1 is Double && operando2 is Double) return operando1 <= operando2;
                                        else
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede obtener el mayor de dos boolean");
                                            errorSemantico.Add("Error Semantico no se puede obtener el mayor de dos boolean");

                                            return null;
                                        }
                                    }
                                case ">=":
                                    {
                                        if (operando1 is String && operando2 is String)
                                        {
                                            String sa1 = Convert.ToString(Expresiones(hijos[prueba1], metodo));
                                            String sa2 = Convert.ToString(Expresiones(hijos[prueba2], metodo));
                                            int resultado = String.Compare(sa1, sa2);
                                            if (resultado < 0) return false;
                                            else if (resultado == 0) return true;
                                            else return true;
                                        }
                                        else if (operando1 is Double && operando2 is Double) return operando1 >= operando2;
                                        else
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede obtener el mayor de dos boolean");
                                            errorSemantico.Add("Error Semantico no se puede obtener el mayor de dos boolean");

                                            return null;
                                        }
                                    }
                                case "==":
                                    {
                                        if (operando1 is String && operando2 is String)
                                        {
                                            String sa1 = Convert.ToString(Expresiones(hijos[prueba1], metodo));
                                            String sa2 = Convert.ToString(Expresiones(hijos[prueba2], metodo));
                                            int resultado = String.Compare(sa1, sa2);
                                            if (resultado < 0) return true;
                                            else if (resultado == 0) return true;
                                            else return false;
                                        }
                                        else if (operando1 is Double && operando2 is Double) return operando1 == operando2;
                                        else if (operando1 is Boolean && operando2 is Boolean) return operando1 == operando2;
                                        else if (operando1 is Char && operando2 is Char) return operando1 == operando2;
                                        else
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no concuerdan los tipos");
                                            errorSemantico.Add("Error Semantico no concuerdan los tipos");

                                            return false;
                                        }

                                    }
                                case "||":
                                    {
                                        if (operando1 is Boolean && operando2 is Boolean) return operando1 || operando2;
                                        else
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no concuerdan los tipos");
                                            errorSemantico.Add("Error Semantico no concuerdan los tipos");

                                            return null;
                                        }
                                    }
                                case "&&":
                                    {
                                        if (operando1 is Boolean && operando2 is Boolean) return operando1 && operando2;
                                        else
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no concuerdan los tipos");
                                            errorSemantico.Add("Error Semantico no concuerdan los tipos");

                                            return null;
                                        }
                                    }
                                case "!=":
                                    {
                                        if (operando1 is Boolean && operando2 is Boolean) return operando1 != operando2;
                                        else
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no concuerdan los tipos");
                                            errorSemantico.Add("Error Semantico no concuerdan los tipos");

                                            return null;
                                        }
                                    }
                                case "|&":
                                    {

                                        if (operando1 is Boolean && operando2 is Boolean)
                                        {

                                            if ((operando1 == false && operando2 == true) || (operando1 == true && operando2 == false)) return true;
                                            else return false;

                                        }
                                        else
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no concuerdan los tipos");
                                            errorSemantico.Add("Error Semantico no concuerdan los tipos");

                                            return null;
                                        }
                                    }
                                case "~":
                                    {

                                        if (operando1 is Double && operando2 is Double)
                                        {

                                            if ((operando1 == (operando2 + diferencia)) || (operando1 == (operando2 - diferencia))) return true;
                                            else return false;

                                        }
                                        else if (operando1 is String && operando2 is String)
                                        {
                                            String palabra1 = Convert.ToString(operando1);
                                            palabra1 = palabra1.Replace(" ", "");
                                            palabra1 = palabra1.ToLower();

                                            String palabra2 = Convert.ToString(operando2);
                                            palabra2 = palabra2.Replace(" ", "");
                                            palabra2 = palabra2.ToLower();
                                            return palabra2 == palabra1;
                                        }
                                        else
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no concuerdan los tipos");
                                            errorSemantico.Add("Error Semantico no concuerdan los tipos");

                                            return null;
                                        }
                                    }
                                default:
                                    return null;

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
                        else if (hijos[0].ToString().Contains(" (tString)"))
                        {
                            String var = hijos[0].ToString().Replace(" (tString)", "");
                            return var;
                        }
                        else if (hijos[0].ToString().Equals("! (Key symbol)"))
                        {
                            if(Expresiones(hijos[1], metodo)!=null)
                                return !Expresiones(hijos[1], metodo);
                            return null;
                        }
                        else if (hijos[0].ToString().Equals("true (Keyword)"))
                        {
                            return true;
                        }
                        else if (hijos[0].ToString().Equals("false (Keyword)"))
                        {
                            return false;
                        }
                        else if (hijos[0].ToString().Contains(" (tchar)"))
                        {
                            String var = hijos[0].ToString().Replace(" (tchar)", "");
                            char res = Convert.ToChar(var[0]);
                            return res;

                        }
                        else if (hijos[0].ToString().Equals("- (Key symbol)"))
                        {
                            if (Expresiones(hijos[1], metodo) != null)
                                return -Expresiones(hijos[1], metodo);
                            else return null;
                        }
                        else if (hijos[0].ToString().Contains("LLAMAR"))
                        {
                            //-------------------------------------Obtener datos de metodo a buscar--------------------------------------------
                            ParseTreeNode[] hijos2 = null;
                            hijos2 = hijos[0].ChildNodes.ToArray();
                            String nombeme = Convert.ToString(hijos2[0]);
                            nombeme = nombeme.Replace(" (id)", "");
                            nombeme = nombeme.Trim();
                            ParseTreeNode first = buscarCuerpo(nombeme);
                            if (first != null)
                            {
                                setearParametros(hijos2[2], nombeme, metodo);
                                resetearParametros(nombeme);
                                resetarVariablesLocales(nombeme);
                                int eliminar = cantidadParametros(nombeme);

                                for (int j = 0; j < eliminar; j++)
                                {
                                    parametrosTemporales.RemoveAt(j);
                                    eliminar--;
                                }
                                cuerpo(first, nombeme);
                                int buscarRe = buscarRetorno(nombeme);
                                ArrayList dato = (ArrayList)retornoMetodos[buscarRe];

                                retornoMetodos.RemoveAt(buscarRe);
                                return dato[1];

                            }
                            return null;
                            //-----------------------------------------------------Indicar el sub arbol-------------------------------------------------

                        }
                        else if (hijos[0].ToString().Contains(" (id)"))
                        {

                            string nom = hijos[0].ToString().Replace(" (id)", "");
                            nom = nom.Trim();
                            int buscarLocal = buscarVariableLocal(nom, metodo);
                            if (buscarLocal > -1)
                            {
                                ArrayList dato;
                                if (metodo == "principal") dato = (ArrayList)variablesLocalesMain[buscarLocal];
                                else dato = (ArrayList)variablesLocales[buscarLocal];
                                if (dato[3] == null)
                                {
                                    System.Diagnostics.Debug.WriteLine("Error la variable Local: " + nom + " no ha sido instanceada");
                                    errorSemantico.Add("Error la variable Local: " + nom + " no ha sido instanceada");

                                }
                                else return dato[3];

                            }
                            else
                            {
                                int buscarParam = buscarParametro(nom, metodo);
                                if (buscarParam > -1)
                                {
                                    ArrayList dato = (ArrayList)listaParametros[buscarParam];
                                    if (dato[3] != null) return dato[3];
                                    else
                                    {
                                        int buscarViejo = buscarTemporal(nom, metodo);
                                        if (buscarViejo > -1)
                                        {
                                            ArrayList dato2 = (ArrayList)parametrosTemporales[buscarParam];
                                            if (dato2[3] != null) return dato2[3];
                                        }
                                    }

                                }
                                else
                                {
                                    int buscarGlobal = buscarVariableGlobal(nom);
                                    if (buscarGlobal > -1)
                                    {
                                        ArrayList dato = (ArrayList)variablesGlobales[buscarGlobal];
                                        if (dato[2] == null)
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error la variable Global: " + nom + " no ha sido instanceada");
                                            errorSemantico.Add("Error la variable Global: " + nom + " no ha sido instanceada");

                                        }
                                        else return dato[2];
                                    }
                                    else System.Diagnostics.Debug.WriteLine("Error no se encuentra la variable: " + nom);
                                    errorSemantico.Add("Error no se encuentra la variable: " + nom);

                                }



                            }

                            return null;

                        }
                    }
                }
                else
                {
                    return null;
                }
                return null;
            }
            return null;

        }



        //-----------------------------------------------------------------Buscar Retorno de un metodo---------------------------------------------------------
        public int buscarRetorno(string metodo)
        {
            for (int i = 0; i < retornoMetodos.Count; i++)
            {
                ArrayList dato = (ArrayList)retornoMetodos[i];
                string nombre = Convert.ToString(dato[0]);
                if (nombre.Equals(metodo)) return i;
            }
            return -1;
        }


        //------------------------------------------------------------------Setea los Parametros en variables locales-----------------------------------------------------------------


        public void setearParametros(ParseTreeNode raiz, String metodo, string buscarvalores)
        {
            string Inicio = raiz.ToString();
            ParseTreeNode[] hijos = null;
            if (raiz.ChildNodes.Count > 0) hijos = raiz.ChildNodes.ToArray();
            switch (Inicio)
            {

                case "PARAMETROS":

                    if (hijos != null)
                    {
                        ArrayList dato = new ArrayList();
                        dato.Add(metodo);
                        var value = Expresiones(hijos[0], buscarvalores);
                        dato.Add(value);
                        parametrosTemporales.Add(dato);
                    }
                    break;
            }
            if (hijos != null)
            {
                for (int i = 0; i < hijos.Count(); i++)
                {
                    setearParametros(hijos[i], metodo, buscarvalores);
                }
            }
        }


        int cantidadParametros(string metodo)
        {
            int devolver = 0;
            for (int i = 0; i < listaParametros.Count; i++)
            {
                ArrayList dato = (ArrayList)listaParametros[i];
                string metodoOb = Convert.ToString(dato[0]);
                if (metodoOb.Equals(metodo)) devolver++;
            }
            return devolver;
        }
        //---------------------------------------------------------------Obtiene el cuerpo de los metodos o funciones---------------------------------------

        public void mostrarTemporal()
        {
            for (int i = 0; i < variablesLocalesMain.Count; i++)
            {
                ArrayList var = (ArrayList)variablesLocalesMain[i];
                System.Diagnostics.Debug.WriteLine("Nombre: " + var[2] + " valor: " + var[3]);




            }
        }


        ParseTreeNode buscarCuerpo(string nombre)
        {
            for (int i = 0; i < metodosFunciones.Count; i++)
            {
                ArrayList datos = (ArrayList)metodosFunciones[i];
                string obtenido = Convert.ToString(datos[1]);
                obtenido = obtenido.Trim();

                if (obtenido.Equals(nombre)) return (ParseTreeNode)datos[2];


            }
            return null;
        }

        public void resetearParametros(string metodo)
        {
            int temp = 0;
            for (int i = 0; i < listaParametros.Count; i++)
            {
                ArrayList dato = (ArrayList)listaParametros[i];
                ArrayList dato2 = (ArrayList)parametrosTemporales[temp];
                string nombe = Convert.ToString(dato[0]);
                if (nombe.Equals(metodo))
                {
                    dato[3] = dato2[1];
                    listaParametros[i] = dato;
                    temp++;
                }
            }
        }

        public void resetarVariablesLocales(string metodo)
        {
            for (int i = 0; i < variablesLocales.Count; i++)
            {
                ArrayList dato = (ArrayList)variablesLocales[i];
                string nombe = Convert.ToString(dato[0]);
                if (nombe.Equals(metodo))
                {
                    variablesLocales.RemoveAt(i);
                }
            }
        }

        public void limpiarTemporal(string metodo)
        {
            for (int i = 0; i < parametrosTemporales.Count; i++)
            {
                ArrayList dato = (ArrayList)parametrosTemporales[i];
                string nombe = Convert.ToString(dato[0]);
                if (nombe.Equals(metodo))
                {
                    parametrosTemporales.RemoveAt(i);
                }
            }
        }

        public static void ConstruirArbol(ParseTreeNode raiz)
        {
            StreamWriter f = new StreamWriter(("Arbol1.txt"));
            f.Write("digraph lista { \n");
            graph = "";
            DibExp(raiz);
            f.Write(graph);
            f.Write("}");
            f.Close();
        }

        public static void ConstruirArbol2(ParseTreeNode raiz)
        {
            StreamWriter f = new StreamWriter(("Arbol1.txt"));
            f.Write("digraph lista { \n");
            graph = "";
            DibExp2(raiz);
            f.Write(graph);
            f.Write("}");
            f.Close();
        }
        public static void DibExp(ParseTreeNode raiz)
        {
            String nombre;

            nombre = raiz.ToString().Replace(" (Key symbol)", "");

            nombre = nombre.ToString().Replace(" (id)", "");
            nombre = nombre.ToString().Replace(" (numero)", "");

            graph = graph + "nodo" + raiz.GetHashCode() + "[label=\"" + nombre + " \", fillcolor=\"LightBlue\", style =\"filled\"]; \n";
            if (raiz.ChildNodes.Count > 0)
            {
                ParseTreeNode[] hijos = raiz.ChildNodes.ToArray();

                for (int i = 0; i < raiz.ChildNodes.Count; i++)
                {
                    DibExp(hijos[i]);

                    graph = graph + "\"nodo" + raiz.GetHashCode() + "\"-> \"nodo" + hijos[i].GetHashCode() + "\" \n";
                }
            }
        }

        public static void DibExp2(ParseTreeNode raiz)
        {
            String nombre;

            nombre = raiz.ToString().Replace(" (Key symbol)", "");

            nombre = nombre.ToString().Replace(" (id)", "");
            nombre = nombre.ToString().Replace(" (numero)", "");
            nombre = nombre.ToString().Replace(" (tString)", "");
            bool estado = true;
            if (nombre.Equals("EXPRESION")) estado=false;
            graph = graph + "nodo" + raiz.GetHashCode() + "[label=\"" + nombre + " \", fillcolor=\"LightBlue\", style =\"filled\"]; \n";
            if (raiz.ChildNodes.Count > 0 && estado)
            {
                ParseTreeNode[] hijos = raiz.ChildNodes.ToArray();

                for (int i = 0; i < raiz.ChildNodes.Count; i++)
                {
                    DibExp(hijos[i]);

                    graph = graph + "\"nodo" + raiz.GetHashCode() + "\"-> \"nodo" + hijos[i].GetHashCode() + "\" \n";
                }
            }
        }

        public static void GraficarArbol(string fileName, string path)
        {

            String text = File.ReadAllText(("Arbol1.txt"));

            WINGRAPHVIZLib.DOT dot = new WINGRAPHVIZLib.DOT();
            WINGRAPHVIZLib.BinaryImage img = dot.ToPNG(text);
            byte[] imageBytes = Convert.FromBase64String(img.ToBase64String());
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image imagen = Image.FromStream(ms, true);
            imagen.Save((path+".png"));

        }


        public void Case(ParseTreeNode raiz, string metodo,string valor, ParseTreeNode elses)
        {
            String inicio = raiz.ToString();
            ParseTreeNode[] hijos = null;
            if (raiz.ChildNodes.Count > 0)
                hijos = raiz.ChildNodes.ToArray();
            switch (inicio)
            {
                case "CASO":

                    if (hijos != null)
                    {
                        string obtener = Convert.ToString(Expresiones(hijos[0], metodo));
                        System.Diagnostics.Debug.WriteLine("select  "+obtener);

                        if (obtener.Equals(valor))
                        {
                            cuerpo(hijos[2], metodo);

                            hijos = null;
                        }
                        else
                        {
                            Case(hijos[3], metodo,valor, elses);

                        }
                    }
                    else
                    {
                        recorrerDefecto(elses, metodo);
                    }
                    break;
            }
        }







        public void recorrerDefecto(ParseTreeNode raiz, String metodo)
        {
            String inicio = raiz.ToString();
            ParseTreeNode[] hijos = null;
            if (raiz.ChildNodes.Count > 0) hijos = raiz.ChildNodes.ToArray();
            switch (inicio)
            {

                case "DEFECT":
                    if (hijos != null)
                    {
                        cuerpo(hijos[2], metodo);
                    }
                    hijos = null;
                    break;
            }
        }

    }


}







