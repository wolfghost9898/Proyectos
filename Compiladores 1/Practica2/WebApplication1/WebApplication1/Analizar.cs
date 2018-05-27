using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Irony.Parsing;
using System.Collections;
using System.Drawing;

namespace WebApplication1
{
    public class Analizar
    {
        public static ParseTree padre;
        public static ParseTree padrecalcu;
        public static ArrayList error;
        public static ArrayList linea;
        public static ArrayList columna;
        public static ArrayList variables;
        public static ArrayList retonar;
        public static ArrayList metodosFun;
        public static ArrayList salida;
        public void esCadenaValida(string cadenaEntrada, Grammar gramatica)
        {
            error = new ArrayList();
            linea = new ArrayList();
            columna = new ArrayList();
            variables = new ArrayList();
            retonar = new ArrayList();
            metodosFun = new ArrayList();
            salida = new ArrayList();

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

        






        //----------------------------------------------------------Buscar Declaraciones de Variables y o Asignacion--------------------------------------------------------------
        public void RecorrerArbol(ParseTreeNode raiz, String metodo)
        {
            String inicio = raiz.ToString();
            ParseTreeNode[] hijos = null;
            if (raiz.ChildNodes.Count > 0) hijos = raiz.ChildNodes.ToArray();
            switch (inicio)
            {

                case "DECLARACION":
                    Declaracion(raiz, metodo);
                    break;
                case "DECLAASIGNA":
                    DeclaAsignacion(raiz, metodo, hijos[3]);
                    break;
                case "IMPRIMIR":
                    ArrayList datos = new ArrayList();
                    var a = Expresiones(hijos[2], metodo);
                    datos.Add(a);
                    datos.Add("imprimir");
                    salida.Add(datos);
                    break;
                case "RETORNAR":
                    var retu = Expresiones(hijos[1],metodo);
                    String caca = Convert.ToString(retu);

                    ArrayList dato = new ArrayList();
                    metodo = metodo.Trim();
                    dato.Add(metodo);
                    dato.Add(retu);
                    retonar.Add(dato);

                    //------------------------------------------devolver variables locales a null------------------------
                    for (int j = 0; j < variables.Count; j++)
                    {
                        ArrayList dato2 = (ArrayList)variables[j];
                        String met = Convert.ToString(dato2[0]);
                        met = met.Trim();
                        if ((met.Equals(metodo)) && (dato2[2] != null))
                        {
                            dato2[2] = null;
                            variables[j] = dato2;
                        }


                    }

                    break;
                case "LLAMADAFUNC":

                    //-------------------------------------Obtener datos de metodo a buscar--------------------------------------------
                    ParseTreeNode[] hijos2 = null;
                    String nombeme = Convert.ToString(hijos[0]);
                    nombeme = nombeme.Replace(" (id)", "");
                    nombeme = nombeme.Trim();
                    ParseTreeNode first = null;
                    //-----------------------------------------------------Indicar el sub arbol-------------------------------------------------
                    for (int i = 0; i < metodosFun.Count; i++)
                    {
                        ArrayList ge = (ArrayList)metodosFun[i];
                        String meme = Convert.ToString(ge[0]);
                        meme = meme.Trim();
                        if (meme.Equals(nombeme))
                        {
                            first = (ParseTreeNode)ge[1];

                        }
                    }
                    //--------------------------------------------------------Empezar recorrido sub arbol----------------------------------------
                    if (first != null)
                    {
                        //------------------------------------------------------Setear Valores de parametros------------------------------------

                        setearParametros(hijos[2], nombeme, metodo);

                        RecorrerArbol(first, nombeme);

                        //------------------------------------------devolver variables locales a null------------------------
                        for (int j = 0; j < variables.Count; j++)
                        {
                            ArrayList dato2 = (ArrayList)variables[j];
                            String met = Convert.ToString(dato2[0]);
                            met = met.Trim();
                            if ((met.Equals(nombeme)) && (dato2[2] != null))
                            {
                                dato2[2] = null;
                                variables[j] = dato2;
                            }


                        }
                    }


                    break;

                //--------------------------------------------------------------------PARA EL IF--------------------------------------------
                case "CIF":
                    Boolean obtener =Convert.ToBoolean( Expresiones(hijos[2], metodo));
                    if (obtener==true) RecorrerArbol(hijos[5], metodo);
                    else recorrerElseIf(hijos[7],metodo,hijos[8]);
                    hijos = null;
                    break;
                //--------------------------------------------------------------------Graficar--------------------------------------------------
                case "GRAFICAR":
                    graficar(raiz);
                    break;
                case "ASIGNACION":
                    Asignacion(raiz, metodo);
                    break;
                   
            }
            if (hijos != null)
            {
                for (int i = 0; i < hijos.Count(); i++)
                {
                    RecorrerArbol(hijos[i],metodo);
                }
            }

        }

        public void Declaracion(ParseTreeNode raiz,String metodo)
        {
            String inicio = raiz.ToString();
            ParseTreeNode[] hijos = null;
            if (raiz.ChildNodes.Count > 0) hijos = raiz.ChildNodes.ToArray();
            switch (inicio)
            {

                case "MULTIVAR":
                    ArrayList dato = new ArrayList();
                    dato.Add(metodo);
                    dato.Add(hijos[0].ToString().Replace("(id)", ""));
                    dato.Add(null);
                    variables.Add(dato);
                    break;
            }
            if (hijos != null)
            {
                for (int i = 0; i < hijos.Count(); i++)
                {
                    Declaracion(hijos[i], metodo);
                }
            }
        }

        //-------------------------------------------------------------------Metodos y Funciones----------------------------------------------------------
        public void RecorrerMetodos(ParseTreeNode raiz)
        {
            String inicio = raiz.ToString();
            ParseTreeNode[] hijos = null;
            if (raiz.ChildNodes.Count > 0) hijos = raiz.ChildNodes.ToArray();
            switch (inicio)
            {

                case "METOFUNC":
                    String metodo = hijos[1].ToString().Replace("(id)", "");
                    recorrerParametros(hijos[3], metodo);
                    ArrayList dat = new ArrayList();
                    dat.Add(metodo);
                    dat.Add(hijos[6]);
                    metodosFun.Add(dat);
                    break;
                case "MVOID":
                    String metodo2 = hijos[1].ToString().Replace("(id)", "");
                    recorrerParametros(hijos[3], metodo2);
                    ArrayList dat2 = new ArrayList();
                    dat2.Add(metodo2);
                    dat2.Add(hijos[6]);
                    metodosFun.Add(dat2);
                    break;
                case "DECLARACION2":
                    Declaracion(raiz, "principal");
                    break;
                case "DECLAASIGNA2":
                    DeclaAsignacion(raiz, "principal",hijos[3]);
                    break;
            }
            if (hijos != null)
            {
                for (int i = 0; i < hijos.Count(); i++)
                {
                    RecorrerMetodos(hijos[i]);
                }
            }
        }

        //------------------------------------------------------------------DECLARACION Y ASIGNACION-------------------------------------------------
        public void DeclaAsignacion(ParseTreeNode raiz,String metodo,ParseTreeNode expresion)
        {
            String inicio = raiz.ToString();
            ParseTreeNode[] hijos = null;
            if (raiz.ChildNodes.Count > 0) hijos = raiz.ChildNodes.ToArray();
            switch (inicio)
            {

                case "MULTIVAR":
                    ArrayList dato = new ArrayList();
                    dato.Add(metodo);
                    bool encontrado = false;
                    dato.Add(hijos[0].ToString().Replace("(id)", ""));
                    var a = Expresiones(expresion,metodo);
                    String sa1 = hijos[0].ToString().Replace("(id)", "");
                    dato.Add(a);
                    for (int i = 0; i < variables.Count; i++)
                    {
                        ArrayList dato2 = (ArrayList)variables[i];
                        String namemetod = Convert.ToString(dato2[0]);
                        String namevariable = Convert.ToString(dato2[1]);
                        namemetod = namemetod.Trim();
                        namevariable = namevariable.Trim();
                        sa1 = sa1.Trim();
                        metodo = metodo.Trim();
                      

                        if(sa1.Equals(namevariable) && metodo.Equals(namemetod))
                        {
                            encontrado = true;
                            dato2[2] = dato[2];
                            variables[i] = dato2;
                        }
                    }
                    if (encontrado == false)
                    {
                        variables.Add(dato);

                    }
                    break;
            }
            if (hijos != null)
            {
                for (int i = 0; i < hijos.Count(); i++)
                {
                    DeclaAsignacion(hijos[i], metodo,expresion);
                }
            }
        }

        //-----------------------------------------------------------------------SOLO ASIGNACION--------------------------------------------------------
        public void Asignacion(ParseTreeNode raiz, String metodo)
        {
            String inicio = raiz.ToString();
            ParseTreeNode[] hijos = null;
            if (raiz.ChildNodes.Count > 0) hijos = raiz.ChildNodes.ToArray();

            if (hijos != null)
            {

            

                    ArrayList dato = new ArrayList();
                    dato.Add(metodo);
                    bool encontrado = false;
                    dato.Add(hijos[0].ToString().Replace("(id)", ""));
                    var a = Expresiones(hijos[2], metodo);
                    String sa1 = hijos[0].ToString().Replace("(id)", "");
                    dato.Add(a);
                    for (int i = 0; i < variables.Count; i++)
                    {
                        ArrayList dato2 = (ArrayList)variables[i];
                        String namemetod = Convert.ToString(dato2[0]);
                        String namevariable = Convert.ToString(dato2[1]);
                        namemetod = namemetod.Trim();
                        namevariable = namevariable.Trim();
                        sa1 = sa1.Trim();
                        metodo = metodo.Trim();


                        if ((sa1.Equals(namevariable) && metodo.Equals(namemetod))||(sa1.Equals(namevariable) && namemetod.Equals("principal")))
                        {
                            encontrado = true;
                            dato2[2] = dato[2];
                            variables[i] = dato2;
                             hijos = null;
                        }
                    }
                    
            }
            if (hijos != null)
            {
                for (int i = 0; i < hijos.Count(); i++)
                {
                    Asignacion(hijos[i], metodo);
                }
            }
        }
        //------------------------------------------------------------------Encargado de las Expresiones---------------------------------------------------
        public dynamic Expresiones(ParseTreeNode raiz,String metodo)
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
                    return Expresiones(hijos[1],metodo);
                }
                else {

                    var operando1 = Expresiones(hijos[prueba1],metodo);
                    var operando2 = Expresiones(hijos[prueba2],metodo);

                    string operador = hijos[1].ToString().Replace(" (Key symbol)", "");
                    operador = operador.Replace(" (Keyword)", "");
                    switch (operador)
                    {
                        case "+":
                            {
                                if (operando1 is String && operando2 is String)
                                {
                                    String sa1 = Convert.ToString(Expresiones(hijos[prueba1],metodo));
                                    String sa2 = Convert.ToString(Expresiones(hijos[prueba2],metodo));
                                    return sa1 + sa2;
                                }
                                else if ((operando1 is double && operando2 is String) || (operando1 is String && operando2 is double))
                                {
                                    String sa1 = Convert.ToString(Expresiones(hijos[prueba1],metodo));
                                    String sa2 = Convert.ToString(Expresiones(hijos[prueba2],metodo));
                                    return sa1 + sa2;
                                }
                                else
                                {
                                    String sa1 = Convert.ToString(Expresiones(hijos[prueba1],metodo));
                                    String sa2 = Convert.ToString(Expresiones(hijos[prueba2],metodo));
                                    Double sa11;
                                    Double sa21;
                                    Double.TryParse(sa1, out sa11);
                                    Double.TryParse(sa2, out sa21);
                                    return sa11 + sa21;
                                }

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
                        case "<":
                            {
                                return operando1 < operando2;
                            }
                        case ">":
                            {
                                return operando1 > operando2;
                            }

                        case "<=":
                            {
                                return operando1 <= operando2;
                            }
                        case ">=":
                            {
                                return operando1 >= operando2;
                            }
                        case "==":
                            {
                                return operando1 == operando2;
                            }
                        case "OR":
                            {
                                return operando1 || operando2;
                            }
                        case "AND":
                            {
                                return operando1 && operando2;
                            }
                        case "NOT":
                            {
                                return operando1 != operando2;
                            }
                        default:
                            return null;
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
                else if (hijos[0].ToString().Contains(" (tString)")) {
                    String var = hijos[0].ToString().Replace(" (tString)", "");
                    return var;
                }
                else if (hijos[0].ToString().Equals("! (Key symbol)"))
                {
                    return !Expresiones(hijos[1],metodo);
                }
                else if (hijos[0].ToString().Equals("true (Keyword)"))
                {
                    return true;
                }
                else if (hijos[0].ToString().Equals("false (Keyword)"))
                {
                    return false;
                }
                else if (hijos[0].ToString().Contains(" (id)")){

                    String var = hijos[0].ToString().Replace(" (id)", "");
                    var = var.Trim();

                    ArrayList dato = new ArrayList();
                    for(int i = 0; i < variables.Count; i++)
                    {
                        
                        dato =(ArrayList) variables[i];
                        String nombre = Convert.ToString(dato[1]);
                        String met = Convert.ToString(dato[0]);
                        met = met.Trim();
                        nombre = nombre.Trim();
                        metodo = metodo.Trim();
                        if ((var.Equals(nombre) && met.Equals(metodo)) || (var.Equals(nombre) && met.Equals("principal")))
                        {
                            String obtenido = Convert.ToString(dato[2]);
                            return dato[2];
                            break;
                        }
                    }
                    return null;
                    
                }
                else if (hijos[0].ToString().Contains("PARALLAMA")) {
                    //-------------------------------------Obtener datos de metodo a buscar--------------------------------------------
                    ParseTreeNode[] hijos2 = null;
                    hijos2 = hijos[0].ChildNodes.ToArray();
                    String nombeme = Convert.ToString(hijos2[0]);
                    nombeme=nombeme.Replace(" (id)", "");
                    nombeme = nombeme.Trim();
                    ParseTreeNode first = null;
                    //-----------------------------------------------------Indicar el sub arbol-------------------------------------------------
                    for (int i = 0; i < metodosFun.Count; i++) {
                        ArrayList ge = (ArrayList)metodosFun[i];
                        String meme = Convert.ToString(ge[0]);
                        meme = meme.Trim();
                        if (meme.Equals(nombeme))
                        {
                            first = (ParseTreeNode)ge[1];

                        }
                    }
                    //--------------------------------------------------------Empezar recorrido sub arbol----------------------------------------
                    if (first != null)
                    {
                        //------------------------------------------------------Setear Valores de parametros------------------------------------

                        setearParametros(hijos2[2],nombeme,metodo);

                        RecorrerArbol(first, nombeme);
                        
                        for (int i = 0; i < retonar.Count; i++)
                        {
                            ArrayList dato = (ArrayList)retonar[i];
                            String nombre = Convert.ToString(dato[0]);
                            nombre = nombre.Trim();
                            if (nombeme.Equals(nombre))
                            {
                                var ass = dato[1];
                                retonar.RemoveAt(i);
                               
                                return ass;
                            }
                        }



                    }

    
                    return null;
                }
                else if (hijos[0].ToString().Contains("RAIZ")){
                    ParseTreeNode[] hijos2 = null;
                    hijos2 = hijos[0].ChildNodes.ToArray();
                    var para1 = Expresiones(hijos2[2],metodo);
                    var para2 = Expresiones(hijos2[4], metodo);
                    var ex = Math.Pow(para2, -1);
                    return (double)Math.Pow(para1, ex);
                }
                else
                {
                    return null;
                }
            }
            }
            else
            {
                return null;
            }
        }

        //-----------------------------------------------------------------Recorre y Guarda Parametros----------------------------------------------------
        public void recorrerParametros(ParseTreeNode raiz,String metodo) {
            string Inicio = raiz.ToString();
            ParseTreeNode[] hijos = null;
            if (raiz.ChildNodes.Count > 0)  hijos = raiz.ChildNodes.ToArray();
            switch (Inicio)
            {

                case "DECLAPARA":
                    ArrayList dato = new ArrayList();

                    if (hijos != null)
                    {
                        dato.Add(metodo);
                        dato.Add(hijos[1].ToString().Replace("(id)", ""));
                        dato.Add(null);
                        variables.Add(dato);
                    }




                    break;
            }
            if (hijos != null)
            {
                for (int i = 0; i < hijos.Count(); i++)
                {
                    recorrerParametros(hijos[i], metodo);
                }
            }

        }
        //-----------------------------------------------------------------Metodo que se encarga de leer la clase principal-----------------------------------------------
        public void clasePrincipal(ParseTreeNode raiz)
        {
            String inicio = raiz.ToString();
            ParseTreeNode[] hijos = null;
            if (raiz.ChildNodes.Count > 0) hijos = raiz.ChildNodes.ToArray();
            switch (inicio)
            {

                case "PRINCIPAL":
                    RecorrerArbol(hijos[4], "main");
                    break;
            
            }
            if (hijos != null)
            {
                for (int i = 0; i < hijos.Count(); i++)
                {
                    clasePrincipal(hijos[i]);
                }
            }
        }



        //------------------------------------------------------------setear los valores de los parametros-------------------------------------------------------
        public void setearParametros(ParseTreeNode raiz,String metodo,String buscarvalores)
        {
            string Inicio = raiz.ToString();
            ParseTreeNode[] hijos = null;
            if (raiz.ChildNodes.Count > 0) hijos = raiz.ChildNodes.ToArray();
            switch (Inicio)
            {

                case "PARAMETROS":

                    if (hijos != null)
                    {
                        for (int i = 0; i < variables.Count; i++)
                        {
                            ArrayList dato = (ArrayList)variables[i];
                            String met = Convert.ToString(dato[0]);
                            var value = Expresiones(hijos[0], buscarvalores);
                            met = met.Trim();
                            metodo = metodo.Trim();
                            if ((met.Equals(metodo)) && (dato[2]==null))
                            {
                                dato[2] = value;
                                String nana = Convert.ToString(dato[1]);
                                String vava = Convert.ToString(dato[2]);
                                variables[i] = dato;
                                break;
                            }


                        }
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


        //---------------------------------------------------------------Funcion recursiva para ELSE IF---------------------------------------------------------
        public void recorrerElseIf(ParseTreeNode raiz, String metodo,ParseTreeNode elses)
        {
            String inicio = raiz.ToString();
            ParseTreeNode[] hijos = null;
            if (raiz.ChildNodes.Count > 0) hijos = raiz.ChildNodes.ToArray();
            switch (inicio)
            {

                case "SINOSI":
                    if (hijos != null)
                    {
                        Boolean obtener = Convert.ToBoolean(Expresiones(hijos[2], metodo));
                        if (obtener)
                        {
                            RecorrerArbol(hijos[5], metodo);
                            hijos = null;
                        }
                        else
                        {
                            recorrerElseIf(hijos[7], metodo,elses);
                        }

                    }
                    else
                    {
                        recorrerElse(elses, metodo);
                    }
                    break;
            }

        }

        //-----------------------------------------------------------------FUNCION RECURSIVA PARA EL ELSE----------------------------------------------------------------
        public void recorrerElse(ParseTreeNode raiz,String metodo) {
            String inicio = raiz.ToString();
            ParseTreeNode[] hijos = null;
            if (raiz.ChildNodes.Count > 0) hijos = raiz.ChildNodes.ToArray();
            switch (inicio)
            {

                case "SINO":
                    if (hijos != null)
                    {                     
                            RecorrerArbol(hijos[2], metodo);
                    }
                    
                    break;
            }
        }

        //----------------------------------------------------------GRAFICAR----------------------------------------------------------------
        public void graficar(ParseTreeNode raiz)
        {
            string Inicio = raiz.ToString();
            ParseTreeNode[] hijos = null;
            if (raiz.ChildNodes.Count > 0) hijos = raiz.ChildNodes.ToArray();
            if (hijos != null)
            {
                String variable = Convert.ToString(hijos[2]);
                variable = variable.Replace(" (Key symbol)", "");
                variable =variable.Replace("\"", "");
                String expresion = Convert.ToString(Expresiones(hijos[4], " "));
                Double lim1 = Convert.ToDouble(hijos[6].ToString().Replace(" (numero)",""));
                Double lim2 = Convert.ToDouble(hijos[8].ToString().Replace(" (numero)", ""));

                CrearGraficas graph = new CrearGraficas(expresion, variable, (float)lim1, (float)lim2);
                
                Bitmap m = graph.MakeGraph();
                ArrayList datos = new ArrayList();
                datos.Add(m);
                datos.Add("imagen");
                salida.Add(datos);
            }
        }
    }
}