using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Irony.Parsing;
using System.Threading.Tasks;
using System.Collections;
using Proyectocompi2;

namespace WindowsFormsApp1
{
    class ImportClase
    {
        public static ArrayList error;
        public static ParseTree padre;
        public static ArrayList linea;
        public static ArrayList columna;

        public void esCadenaValida(string cadenaEntrada, Grammar gramatica)
        {
            error = new ArrayList();
            linea = new ArrayList();
            columna = new ArrayList();
           

            LanguageData lenguaje = new LanguageData(gramatica);
            Parser p = new Parser(lenguaje);

            ParseTree arbol = p.Parse(cadenaEntrada);

            padre = arbol;
            if (padre != null)
            {
                for (int i = 0; i < arbol.ParserMessages.Count(); i++)
                {
                    error.Add(arbol.ParserMessages.ElementAt(i).Level.ToString() + arbol.ParserMessages.ElementAt(i).Message);
                    linea.Add(arbol.ParserMessages.ElementAt(i).Location.Line);
                    columna.Add(arbol.ParserMessages.ElementAt(i).Location.Column);
                }
            }
        }


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

                case "ASIGNACION":
                    if (hijos != null)
                    {
                        string nombre = Convert.ToString(hijos[0]);
                        nombre = nombre.Replace(" (id)", "");
                        nombre = nombre.Trim();

                        asignacionVariablesGlobal(nombre, hijos[2]);
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
                        Analizar.metodosFunciones.Add(datos);
                        guardarParametros(hijos[3], nombre);
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
                        Analizar.metodosFunciones.Add(datos);
                        guardarParametros(hijos[3], nombre);
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
                                    Analizar.variablesGlobales.Add(dato);
                                }
                                else System.Diagnostics.Debug.WriteLine("No se puede Autocastear");

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
                                    Analizar.variablesGlobales.Add(dato);
                                }
                                //---------------------------------------------------------si es boolean-------------------------------------------------
                                else if (resultado is Boolean)
                                {
                                    if (resultado == true)
                                    {
                                        dato.Add(nombre);
                                        dato.Add(1);
                                        Analizar.variablesGlobales.Add(dato);
                                    }
                                    else
                                    {
                                        dato.Add(nombre);
                                        dato.Add(0);
                                        Analizar.variablesGlobales.Add(dato);
                                    }

                                }
                                else if (resultado is Char)
                                {
                                    Double numero = Convert.ToDouble(resultado);
                                    dato.Add(nombre);
                                    dato.Add(numero);
                                    Analizar.variablesGlobales.Add(dato);
                                }
                                else
                                {
                                    System.Diagnostics.Debug.WriteLine("No se puede Autocastear");

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
                                    Analizar.variablesGlobales.Add(dato);
                                }
                                //---------------------------------------------------------si es boolean-------------------------------------------------
                                else if (resultado is Boolean)
                                {
                                    if (resultado == true)
                                    {
                                        dato.Add(nombre);
                                        dato.Add(1);
                                        Analizar.variablesGlobales.Add(dato);
                                    }
                                    else
                                    {
                                        dato.Add(nombre);
                                        dato.Add(0);
                                        Analizar.variablesGlobales.Add(dato);
                                    }

                                }
                                else if (resultado is Char)
                                {
                                    Double numero = (double)resultado;
                                    dato.Add(nombre);
                                    dato.Add(numero);
                                    Analizar.variablesGlobales.Add(dato);
                                }
                                else System.Diagnostics.Debug.WriteLine("No se puede Autocastear");
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
                                Analizar.variablesGlobales.Add(dato);
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
                                    Analizar.variablesGlobales.Add(dato);
                                }
                                else if (resultado is Double)
                                {
                                    if (resultado > -1 && resultado < 256)
                                    {
                                        int numero = (int)resultado;
                                        char resu = (char)numero;
                                        dato.Add(nombre);
                                        dato.Add(resu);
                                        Analizar.variablesGlobales.Add(dato);
                                    }
                                    else System.Diagnostics.Debug.WriteLine("No se puede Autocastear supera el codigo Ascii");

                                }
                                else System.Diagnostics.Debug.WriteLine("No se puede Autocastear");
                            }

                        }
                        else
                        {
                            dato.Add(nombre);
                            dato.Add(null);
                            Analizar.variablesGlobales.Add(dato);
                        }

                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Error semantico variables globales repetida " + nombre);

                        Analizar.errorSemantico.Add("Variable: " + nombre + "ya se encuentra declarada");
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


      public void declaracionLocal(ParseTreeNode raiz, string tipo, ParseTreeNode expresion,string metodo)
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
                    int buscar = buscarVariableLocal(nombre,metodo);
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
                                    if (metodo == "principal") Analizar.variablesLocalesMain.Add(dato); else Analizar.variablesLocales.Add(dato);
                                }
                                else System.Diagnostics.Debug.WriteLine("No se puede Autocastear");

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
                                    if (metodo == "principal") Analizar.variablesLocalesMain.Add(dato); else Analizar.variablesLocales.Add(dato);
                                }
                                //---------------------------------------------------------si es boolean-------------------------------------------------
                                else if (resultado is Boolean)
                                {
                                    if (resultado == true)
                                    {
                                        dato.Add(nombre);
                                        dato.Add(1);
                                        if (metodo == "principal") Analizar.variablesLocalesMain.Add(dato); else Analizar.variablesLocales.Add(dato);
                                    }
                                    else
                                    {
                                        dato.Add(nombre);
                                        dato.Add(0);
                                        if (metodo == "principal") Analizar.variablesLocalesMain.Add(dato); else Analizar.variablesLocales.Add(dato);
                                    }

                                }
                                else if (resultado is Char)
                                {
                                    Double numero = Convert.ToDouble(resultado);
                                    dato.Add(nombre);
                                    dato.Add(numero);
                                    if (metodo == "principal") Analizar.variablesLocalesMain.Add(dato); else Analizar.variablesLocales.Add(dato);
                                }
                                else
                                {
                                    System.Diagnostics.Debug.WriteLine("No se puede Autocastear");

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
                                    if (metodo == "principal") Analizar.variablesLocalesMain.Add(dato); else Analizar.variablesLocales.Add(dato);
                                }
                                //---------------------------------------------------------si es boolean-------------------------------------------------
                                else if (resultado is Boolean)
                                {
                                    if (resultado == true)
                                    {
                                        dato.Add(nombre);
                                        dato.Add(1);
                                        if (metodo == "principal") Analizar.variablesLocalesMain.Add(dato); else Analizar.variablesLocales.Add(dato);
                                    }
                                    else
                                    {
                                        dato.Add(nombre);
                                        dato.Add(0);
                                        if (metodo == "principal") Analizar.variablesLocalesMain.Add(dato); else Analizar.variablesLocales.Add(dato);
                                    }

                                }
                                else if (resultado is Char)
                                {
                                    Double numero = (double)resultado;
                                    dato.Add(nombre);
                                    dato.Add(numero);
                                    if (metodo == "principal") Analizar.variablesLocalesMain.Add(dato); else Analizar.variablesLocales.Add(dato);
                                }
                                else System.Diagnostics.Debug.WriteLine("No se puede Autocastear");
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
                                if (metodo == "principal") Analizar.variablesLocalesMain.Add(dato); else Analizar.variablesLocales.Add(dato);
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
                                    if (metodo == "principal") Analizar.variablesLocalesMain.Add(dato); else Analizar.variablesLocales.Add(dato);
                                }
                                else if (resultado is Double)
                                {
                                    if (resultado > -1 && resultado < 256)
                                    {
                                        int numero = (int)resultado;
                                        char resu = (char)numero;
                                        dato.Add(nombre);
                                        dato.Add(resu);
                                        if (metodo == "principal") Analizar.variablesLocalesMain.Add(dato); else Analizar.variablesLocales.Add(dato);
                                    }
                                    else System.Diagnostics.Debug.WriteLine("No se puede Autocastear supera el codigo Ascii");

                                }
                                else System.Diagnostics.Debug.WriteLine("No se puede Autocastear");
                            }

                        }
                        else
                        {
                            dato.Add(nombre);
                            dato.Add(null);
                             if (metodo == "principal") Analizar.variablesLocalesMain.Add(dato);else Analizar.variablesLocales.Add(dato);
                        }

                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Error semantico variables Local repetida " + nombre);

                        Analizar.errorSemantico.Add("Variable: " + nombre + "ya se encuentra declarada");
                    }
                    break;
            }
            if (hijos != null)
            {
                for (int i = 0; i < hijos.Count(); i++)
                {
                    declaracionLocal(hijos[i], tipo, expresion,metodo);
                }
            }
        }




        int buscarVariableGlobal(string nombre)
        {
            for (int i = 0; i < Analizar.variablesGlobales.Count; i++)
            {
                ArrayList dato = (ArrayList)Analizar.variablesGlobales[i];
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
                for (int i = 0; i <Analizar.variablesLocalesMain.Count; i++)
                {
                    ArrayList dato = (ArrayList)Analizar.variablesLocalesMain[i];
                    string met = Convert.ToString(dato[0]);
                    string name = Convert.ToString(dato[2]);
                    name = name.Trim();
                    if (name.Equals(nombre) && (met.Equals(metodo))) return i;

                }
            }
            else
            {
                for (int i = 0; i < Analizar.variablesLocales.Count; i++)
                {
                    ArrayList dato = (ArrayList)Analizar.variablesLocales[i];
                    string met = Convert.ToString(dato[0]);
                    string name = Convert.ToString(dato[2]);
                    name = name.Trim();
                    if (name.Equals(nombre) && (met.Equals(metodo))) return i;

                }
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
                    ArrayList datos = (ArrayList)Analizar.variablesGlobales[buscar];
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
                            Analizar.variablesGlobales[buscar] = dato;
                        }
                        else System.Diagnostics.Debug.WriteLine("No se puede Autocastear");

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
                            Analizar.variablesGlobales[buscar] = dato;
                        }
                        //---------------------------------------------------------si es boolean-------------------------------------------------
                        else if (resultado is Boolean)
                        {
                            if (resultado == true)
                            {
                                dato.Add(nombre);
                                dato.Add(1);
                                Analizar.variablesGlobales[buscar] = dato;
                            }
                            else
                            {
                                dato.Add(nombre);
                                dato.Add(0);
                                Analizar.variablesGlobales[buscar] = dato;
                            }

                        }
                        else if (resultado is Char)
                        {
                            Double numero = Convert.ToDouble(resultado);
                            dato.Add(nombre);
                            dato.Add(numero);
                            Analizar.variablesGlobales[buscar] = dato;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("No se puede Autocastear");

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
                            Analizar.variablesGlobales[buscar] = dato;
                        }
                        //---------------------------------------------------------si es boolean-------------------------------------------------
                        else if (resultado is Boolean)
                        {
                            if (resultado == true)
                            {
                                dato.Add(nombre);
                                dato.Add(1);
                                Analizar.variablesGlobales[buscar] = dato;
                            }
                            else
                            {
                                dato.Add(nombre);
                                dato.Add(0);
                                Analizar.variablesGlobales[buscar] = dato;
                            }

                        }
                        else if (resultado is Char)
                        {
                            Double numero = (double)resultado;
                            dato.Add(nombre);
                            dato.Add(numero);
                            Analizar.variablesGlobales[buscar] = dato;
                        }
                        else System.Diagnostics.Debug.WriteLine("No se puede Autocastear");
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
                        Analizar.variablesGlobales[buscar] = dato;
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
                            Analizar.variablesGlobales[buscar] = dato;
                        }
                        else if (resultado is Double)
                        {
                            if (resultado > -1 && resultado < 256)
                            {
                                int numero = (int)resultado;
                                char resu = (char)numero;
                                dato.Add(nombre);
                                dato.Add(resu);
                                Analizar.variablesGlobales[buscar] = dato;
                            }
                            else System.Diagnostics.Debug.WriteLine("No se puede Autocastear supera el codigo Ascii");

                        }
                        else System.Diagnostics.Debug.WriteLine("No se puede Autocastear");
                    }

                }
            }
            else System.Diagnostics.Debug.WriteLine("Metodo: No se encuentra esta variable en este contexto " + nombre);

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
                    if (metodo == "principal") datos = (ArrayList)Analizar.variablesLocalesMain[buscar];
                    else datos = (ArrayList)Analizar.variablesLocales[buscar];
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
                            if (metodo == "principal") Analizar.variablesLocalesMain[buscar] = dato; else Analizar.variablesLocales[buscar] = dato;
                        }
                        else System.Diagnostics.Debug.WriteLine("No se puede Autocastear");

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
                            if (metodo == "principal") Analizar.variablesLocalesMain[buscar] = dato; else Analizar.variablesLocales[buscar] = dato;
                        }
                        //---------------------------------------------------------si es boolean-------------------------------------------------
                        else if (resultado is Boolean)
                        {
                            if (resultado == true)
                            {
                                dato.Add(nombre);
                                dato.Add(1);
                                if (metodo == "principal") Analizar.variablesLocalesMain[buscar] = dato; else Analizar.variablesLocales[buscar] = dato;
                            }
                            else
                            {
                                dato.Add(nombre);
                                dato.Add(0);
                                if (metodo == "principal") Analizar.variablesLocalesMain[buscar] = dato; else Analizar.variablesLocales[buscar] = dato;
                            }

                        }
                        else if (resultado is Char)
                        {
                            Double numero = Convert.ToDouble(resultado);
                            dato.Add(nombre);
                            dato.Add(numero);
                            if (metodo == "principal") Analizar.variablesLocalesMain[buscar] = dato; else Analizar.variablesLocales[buscar] = dato;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("No se puede Autocastear");

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
                            if (metodo == "principal") Analizar.variablesLocalesMain[buscar] = dato; else Analizar.variablesLocales[buscar] = dato;
                        }
                        //---------------------------------------------------------si es boolean-------------------------------------------------
                        else if (resultado is Boolean)
                        {
                            if (resultado == true)
                            {
                                dato.Add(nombre);
                                dato.Add(1);
                                if (metodo == "principal") Analizar.variablesLocalesMain[buscar] = dato; else Analizar.variablesLocales[buscar] = dato;
                            }
                            else
                            {
                                dato.Add(nombre);
                                dato.Add(0);
                                if (metodo == "principal") Analizar.variablesLocalesMain[buscar] = dato; else Analizar.variablesLocales[buscar] = dato;
                            }

                        }
                        else if (resultado is Char)
                        {
                            Double numero = (double)resultado;
                            dato.Add(nombre);
                            dato.Add(numero);
                            if (metodo == "principal") Analizar.variablesLocalesMain[buscar] = dato; else Analizar.variablesLocales[buscar] = dato;
                        }
                        else System.Diagnostics.Debug.WriteLine("No se puede Autocastear");
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
                        if (metodo == "principal") Analizar.variablesLocalesMain[buscar] = dato; else Analizar.variablesLocales[buscar] = dato;
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
                            if (metodo == "principal") Analizar.variablesLocalesMain[buscar] = dato; else Analizar.variablesLocales[buscar] = dato;
                        }
                        else if (resultado is Double)
                        {
                            if (resultado > -1 && resultado < 256)
                            {
                                int numero = (int)resultado;
                                char resu = (char)numero;
                                dato.Add(nombre);
                                dato.Add(resu);
                                if (metodo == "principal") Analizar.variablesLocalesMain[buscar] = dato; else Analizar.variablesLocales[buscar] = dato;
                            }
                            else System.Diagnostics.Debug.WriteLine("No se puede Autocastear supera el codigo Ascii");

                        }
                        else System.Diagnostics.Debug.WriteLine("No se puede Autocastear");
                    }

                }
            }
            else System.Diagnostics.Debug.WriteLine("Metodo: No se encuentra esta variable en este contexto " + nombre);

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
                        Analizar.listaParametros.Add(dato);

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
                                            return null;
                                        }
                                        //-------------------------------------------------------si es un numero o un string siempre string-------------------------------
                                        else if ((operando1 is double && operando2 is String) || (operando1 is String && operando2 is double))
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede restar char");
                                            return null;

                                        }
                                        //---------------------------------------------------------si es un char y un char siempre char------------------------------
                                        else if (operando1 is Char && operando2 is Char)
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede restar  char");
                                            return null;
                                        }
                                        //-----------------------------------------si es char bool entonces es error-----------------------------------------------
                                        else if ((operando1 is Char && operando2 is Boolean) || (operando1 is Boolean && operando2 is Char))
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede castear bool y char");

                                            return null;
                                        }
                                        //------------------------------------------------si es bool y bool entonces es un double--------------------------------------
                                        else if (operando1 is Boolean && operando2 is Boolean)
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede restar bool y bool");
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
                                            return null;
                                        }
                                        //-------------------------------------------------------si es un numero o un string siempre string-------------------------------
                                        else if ((operando1 is double && operando2 is String) || (operando1 is String && operando2 is double))
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede multiplicar char");
                                            return null;

                                        }
                                        //---------------------------------------------------------si es un char y un char siempre char------------------------------
                                        else if (operando1 is Char && operando2 is Char)
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede multiplicar  char");
                                            return null;
                                        }
                                        //-----------------------------------------si es char bool entonces es error-----------------------------------------------
                                        else if ((operando1 is Char && operando2 is Boolean) || (operando1 is Boolean && operando2 is Char))
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede castear bool y char");

                                            return null;
                                        }
                                        //------------------------------------------------si es bool y bool entonces es un double--------------------------------------
                                        else if (operando1 is Boolean && operando2 is Boolean)
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede multiplicar bool y bool");
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
                                            return null;
                                        }
                                        //-------------------------------------------------------si es un numero o un string siempre string-------------------------------
                                        else if ((operando1 is double && operando2 is String) || (operando1 is String && operando2 is double))
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede dividir char");
                                            return null;

                                        }
                                        //---------------------------------------------------------si es un char y un char siempre char------------------------------
                                        else if (operando1 is Char && operando2 is Char)
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede dividir  char");
                                            return null;
                                        }
                                        //-----------------------------------------si es char bool entonces es error-----------------------------------------------
                                        else if ((operando1 is Char && operando2 is Boolean) || (operando1 is Boolean && operando2 is Char))
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede castear bool y char");

                                            return null;
                                        }
                                        //------------------------------------------------si es bool y bool entonces es un double--------------------------------------
                                        else if (operando1 is Boolean && operando2 is Boolean)
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede dividir bool y bool");
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
                                            return null;
                                        }
                                        //-------------------------------------------------------si es un numero o un string siempre string-------------------------------
                                        else if ((operando1 is double && operando2 is String) || (operando1 is String && operando2 is double))
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede sacar potencia de char");
                                            return null;

                                        }
                                        //---------------------------------------------------------si es un char y un char siempre char------------------------------
                                        else if (operando1 is Char && operando2 is Char)
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede sacar potencia de  char");
                                            return null;
                                        }
                                        //-----------------------------------------si es char bool entonces es error-----------------------------------------------
                                        else if ((operando1 is Char && operando2 is Boolean) || (operando1 is Boolean && operando2 is Char))
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede castear bool y char");

                                            return null;
                                        }
                                        //------------------------------------------------si es bool y bool entonces es un double--------------------------------------
                                        else if (operando1 is Boolean && operando2 is Boolean)
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede sacar potencia de bool y bool");
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
                                            return Math.Pow(operando1, operando2);
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
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no se puede obtener el mayor de dos boolean");

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
                                            return false;
                                        }

                                    }
                                case "||":
                                    {
                                        if (operando1 is Boolean && operando2 is Boolean) return operando1 || operando2;
                                        else
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no concuerdan los tipos");
                                            return null;
                                        }
                                    }
                                case "&&":
                                    {
                                        if (operando1 is Boolean && operando2 is Boolean) return operando1 && operando2;
                                        else
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no concuerdan los tipos");
                                            return null;
                                        }
                                    }
                                case "!=":
                                    {
                                        if (operando1 is Boolean && operando2 is Boolean) return operando1 != operando2;
                                        else
                                        {
                                            System.Diagnostics.Debug.WriteLine("Error Semantico no concuerdan los tipos");
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
                            return !Expresiones(hijos[1], metodo);
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
                            return -Expresiones(hijos[1], metodo);
                        }
                        else if (hijos[0].ToString().Contains(" (id)"))
                        {

                            string nom = hijos[0].ToString().Replace(" (id)", "");
                            nom = nom.Trim();
                            int buscarLocal = buscarVariableLocal(nom, metodo);
                            if (buscarLocal > -1)
                            {
                                ArrayList dato;
                                if (metodo == "principal") dato = (ArrayList)Analizar.variablesLocalesMain[buscarLocal];
                                else dato = (ArrayList)Analizar.variablesLocales[buscarLocal];
                                if (dato[3] == null)
                                {
                                    System.Diagnostics.Debug.WriteLine("Error la variable Local: " + nom + " no ha sido instanceada");
                                }
                                else return dato[3];

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
    }
}
