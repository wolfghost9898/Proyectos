using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorJson
{

    class AnalizadorSintactico
    {
        private ArrayList lista_lexema = new ArrayList();
        private ArrayList lista_token = new ArrayList();
        private ArrayList lista_padre = new ArrayList();
        private ArrayList lista_errores = new ArrayList();
        private String lex;
        private int estado;
        private String token;
        private Object[] data;
        private int llaves_abiertas;
        private int llaves_cerradas;
        private Boolean text_titulo;
        //-------------------------------variables de en que estado andamos
        private Boolean inicio;
        private Boolean encabezado;
        private Boolean cuerpo;
        private Boolean texto;
        private Boolean Parrafo;
        private Boolean Orientacion;
        private Boolean Diseño;
        private Boolean Titulo;
        private Boolean Color;
        private Boolean Tabla;
        private Boolean Imagen;
        private Boolean Salto;

        public AnalizadorSintactico(ArrayList lista_lexema, ArrayList lista_token,ArrayList lista_errores)
        {
            this.lista_lexema = lista_lexema;
            this.lista_token = lista_token;
            this.lista_errores = lista_errores;
            lex = "";
            token = "";
            estado = 0;
            llaves_abiertas = 0;
            llaves_cerradas = 0;
            text_titulo = false;
            //---------------------------------------declaracion de estados----------------------
            inicio = true;
            encabezado = false;
            cuerpo = false;
            texto=false;
            Parrafo=false;
             Orientacion=false;
             Diseño=false;
             Titulo=false;
             Color=false;
             Tabla=false;
             Imagen=false;
             Salto=false;

            //-----------------------------------------Fin declaracion de estados---------------------
            AnalisisSintactico();
            generarErrores();
        }

        public void AnalisisSintactico()
        {

                for (int i = 0; i > -1 && i < lista_lexema.Count;i++)
                {
                    data = (Object[])lista_lexema[i];
                    lex = (String)data[0];
                    token = (String)lista_token[i];
                    if (inicio==true)
                    {
                        Automata_Inicio();
                    }
                    else if (encabezado == true)
                    {
                        Automata_Encabezado();
                    }
                    else if (cuerpo == true)
                    {
                        Automata_Cuerpo();
                    }
                    else if (texto == true)
                    {
                    Automata_Texto();
                    }
                    else if (Parrafo == true)
                    {
                    Automata_Parrafo();
                    }else if (Orientacion == true)
                    {
                        Automata_Posicion();
                    }
                    else if (Diseño == true)
                    {
                         Automata_Diseño();
                    }
                    else if (Color == true)
                    {
                        Automata_Color();
                    }
                    else if (Titulo == true)
                    {
                        Automata_Titulo();
                    }
                    else if (Tabla == true)
                    {
                        Automata_Tabla();
                    }
                    else if (Imagen == true)
                    {
                        Automata_Imagen();
                    }else if (Salto == true)
                {
                    Automata_Salto(); 
                }

                }

          
        }



        //----------------------------------------Automatas Individuales--------------------------------------
        //----------------------------------------------------------------------------------------------------

        //-----------------------------------------AUTOMATA INICIO-------------------------------------------
        //----------------------------------------------------------------------------------------------------
        public void Automata_Inicio()
        {

            switch (estado)
            {
                //---------------------------------------------------------------------------
                case 0:
                    if (lex == "{")
                    {
                        llaves_abiertas++;
                        estado = 1;
                    }
                    else
                    {
                        Error("Error {");
                    }
                    break;
                //------------------------------------------------------------------------
                case 1:
                    if (lex == "\"")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Error \" apertura");

                    }
                    break;
                //-------------------------------------------------------------------------
                case 2:
                    if (lex == "Inicio")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Falta Inicio");
                    }
                    break;
                //-------------------------------------------------------------------------
                case 3:
                    if (lex == "\"")
                    {
                        estado = 4;
                    }
                    else
                    {
                        Error("Falta \"");
                    }
                    break;
                //-------------------------------------------------------------------------------------
                case 4:
                    if (lex == ":")
                    {
                        estado = 5;
                    }
                    else
                    {
                        Error("Falta :");
                    }
                    break;
                //---------------------------------------------------------------------------------------
                case 5:
                    if (lex == "{")
                    {
                        llaves_abiertas++;
                        estado = 6;
                    }
                    else
                    {
                        Error("Falta {");
                    }
                    break;
                //---------------------------------------------------------------------------------------
                case 6:
                    if (lex == "\"")
                    {
                        estado = 0;
                        encabezado = true;
                        inicio = false;
                    }else if(lex=="}"){
                        llaves_cerradas++;
                        estado = 8;
                    }
                    else
                    {
                        Error("Se esperaba un objeto");
                    }
                    break;
                //--------------------------------------------------------------------------------------
                case 7:
                    if (lex == "}")
                    {
                        llaves_cerradas++;
                        estado = 8;
                    }
                    else
                    {
                        Error("falta }");
                    }
                    break;
                //--------------------------------------------------------------------------------------
                case 8:
                    if (lex == "}")
                    {
                        llaves_cerradas++;
                        estado = 9;
                    }
                    else
                    {
                        Error("Hace falta }");
                    }
                //--------------------------------------------------------------------------------------
                    break;
                //--------------------------------------------------------------------------------
                case 9:
                    Error("No se reconoce este caracter o esta de mas");
                    break;
                    default: break;
                }
        }


        //-----------------------------------------AUTOMATA ENCABEZADO---------------------------------------
        //---------------------------------------------------------------------------------------------------
        public void Automata_Encabezado()
        {

            switch (estado)
            {
                //---------------------------------------------------------------------------
                case 0:
                    if (lex == "Encabezado")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Falta Encabezado");
                    }
                    break;
                //------------------------------------------------------------------------
                case 1:
                    if (lex == "\"")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Falta \"");
                    }
                    break;
                //-------------------------------------------------------------------------
                case 2:
                    if (lex == ":")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Falta :");
                    }
                    break;
                //-------------------------------------------------------------------------
                case 3:
                    if (lex == "{")
                    {
                        llaves_abiertas++;
                        estado = 4;
                    }
                    else
                    {
                        Error("Falta {");
                    }
                    break;
                //-------------------------------------------------------------------------------------
                case 4:
                    if (lex == "}")
                    {
                        llaves_cerradas++;
                        estado =12;
                        encabezado = false;
                    }
                    else if(lex=="\"")
                    {
                        estado = 5;
                    }else
                    {
                        Error("Hace falta \" de Titulo o no se ha cerrado la palabra reservada");
                    }
                    break;
                //---------------------------------------------------------------------------------------
                case 5:
                    if (lex == "TituloPagina")
                    {
                        estado = 6;
                    }
                    else
                    {
                        Error("Falta Titulo");
                    }
                    break;
                //---------------------------------------------------------------------------------------
                case 6:
                    if (lex == "\"")
                    {
                        estado = 7;
                    }
                    else
                    {
                        Error("Falta \"");
                    }
                    break;
                //--------------------------------------------------------------------------------------
                case 7:
                    if (lex == ":")
                    {
                        estado = 8;
                    }
                    else
                    {
                        Error("falta :");
                    }
                    break;
                //--------------------------------------------------------------------------------------
                case 8:
                    if (lex == "\"")
                    {
                        estado=9;
                    }
                    else
                    {
                        Error("Hace falta \"");
                    }
                    break;
                //--------------------------------------------------------------------------------------
                case 9:
                    if (token == "TX_Cadena")
                    {
                        Boolean verificar = false;
                        for(int j = 0; j < lex.Count(); j++)
                        {
                            char letra = lex[j];
                            if(!(Char.IsLetterOrDigit(letra) || (int)letra == 32 || letra=='_'))
                            {
                                verificar = true;
                            }
                        }
                        if (verificar == true)
                        {
                            Error("Hay un caracter no admitido en Titulo Pagina");
                        }
                        else
                        {
                            estado = 10;
                        }
                    }
                    else
                    {
                        Error("Se esperaba un Texto");
                    }
                    break;
                //---------------------------------------------------------------------------
                case 10:
                    if(lex== "\"")
                    {
                        estado = 11;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //-----------------------------------------------------------------------------------
                case 11:
                    if (lex == "}")
                    {
                        llaves_cerradas++;
                        estado = 12;
                    }
                    else
                    {
                        Error("Se esperaba }");
                    }
                    break;
                //-------------------------------------------------------------------------------
                case 12:
                    if (lex == ",")
                    {
                        estado = 0;
                        encabezado = false;
                        cuerpo = true;
                    }
                    else
                    {
                        Error("Se esperaba ,");
                    }
                    break;
                //-------------------------------------------------------------------------------------
                default: break;
            }
        }

        //----------------------------------------AUTOMATA CUERPO-------------------------------------------
        //--------------------------------------------------------------------------------------------------
        public void Automata_Cuerpo()
        {
            switch (estado)
            {
                //----------------------------------------------------------------------------------------
                case 0:
                    if(lex== "\"")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //---------------------------------------------------------------------------------------
                case 1:
                    if (lex == "Cuerpo")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Se esperaba la palabra reservada Cuerpo");
                    }
                    break;
                //-------------------------------------------------------------------------------------
                case 2:
                    if(lex== "\"")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //------------------------------------------------------------------------------------
                case 3:
                    if (lex == ":")
                    {
                        estado = 4;
                    }
                    else
                    {
                        Error("Se esperaba :");
                    }
                    break;
                //------------------------------------------------------------------------------------
                case 4:
                    if (lex == "{")
                    {
                        llaves_abiertas++;
                        estado = 5;
                    }
                    else
                    {
                        Error("Se esperaba {");
                    }
                    break;
                //-----------------------------------------------------------------------------------
                case 5:
                    if(lex== "\"")
                    {
                        estado = 6;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //----------------------------------------------------------------------------------
                case 6:
                    if (lex == "Fondo")
                    {
                        estado = 7;
                    }
                    else if (lex == "Array")
                    {
                        estado = 13;
                    }
                    else
                    {
                        Error("Se esperaba un atributo o un objeto");
                    }
                    break;
                //----------------------------------------------------------------------------------
                case 7:
                    if(lex== "\"")
                    {
                        estado = 8;
                    }
                    else
                    {
                        Error("Se esperaba \" ");
                    }
                    break;
                //---------------------------------------------------------------------------------
                case 8:
                    if (lex == ":")
                    {
                        estado = 9;
                    }
                    else
                    {
                        Error("Se esperaba :");
                    }
                    break;
                //--------------------------------------------------------------------------------
                case 9:
                    if(lex== "\"")
                    {
                        estado = 10;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //-------------------------------------------------------------------------------
                case 10:
                    if (token == "TX_Cadena")
                    {
                        estado = 11;
                    }
                    else {
                        Error("Se esperaba un color");
                    }
                    break;
                //------------------------------------------------------------------------------
                case 11:
                    if (lex == "\"")
                    {
                        estado = 12;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //-----------------------------------------------------------------------------
                case 12:
                    if (lex == ",")
                    {
                        estado = 5;
                    }
                    else if (lex == "}")
                    {
                        llaves_cerradas++;
                        estado = 7;
                        inicio = true;
                        cuerpo = false;
                    }
                    else
                    {
                        Error("Se esparaba } o ,");
                    }
                    break;
                //------------------------------------------------------------------------------
                case 13:
                    if (lex == "\"")
                    {
                        estado = 14;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //--------------------------------------------------------------------------
                case 14:
                    if (lex == ":")
                    {
                        estado = 15;
                    }
                    else
                    {
                        Error("Se esperaba:");
                    }
                    break;
                //--------------------------------------------------------------------------
                case 15:
                    if (lex == "[")
                    {
                        estado = 16;
                        Object[] padre = new Object[] { "Cuerpo", 22 };
                        lista_padre.Insert(0, padre);
                    }
                    else
                    {
                        Error("Se esperaba [");
                    }
                    break;
                //-------------------------------------------------------------------------
                case 16:
                    if (lex == "{")
                    {
                        llaves_abiertas++;
                        estado = 17;
                       
                    }
                    else
                    {
                        Error("Se esperaba {");
                    }
                    break;
                //------------------------------------------------------------------------
                case 17:
                    if (lex == "\"")
                    {
                        estado = 18;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //-------------------------------------------------------------------------------
                case 18:
                    estado = 0;
                    DireccionarObjeto(lex);          
                    break;
                //------------------------------------------------------------------------------
                case 19:
                     if (lex == "]")
                    {
                        lista_padre.RemoveAt(0);
                        estado = 20;
                    }
                    else if (lex == ",")
                    {
                        estado = 16;
                    }
                    else
                    {
                        Error("No se cerro el array o se esperaba una coma que separa los objetos");
                    }
                    break;
                //-----------------------------------------------------------------------------
                case 20:
                    if (lex == "}")
                    {
                        llaves_cerradas++;
                        estado = 21;
                    }
                    else
                    {
                        Error("Se tiene que cerrar Cuerpo");
                    }
                    break;
                //-----------------------------------------------------------------------------
                case 21:
                    if (lex == "}")
                    {
                        llaves_cerradas++;
                        estado = 8;
                        cuerpo = false;
                        inicio = true;
                    }
                    else
                    {
                        Error("Se esperaba }");
                    }
                    break;
                //-----------------------------------------------------------------------
                case 22:
                    if (lex == "}")
                    {
                        estado = 19;
                    }
                    else
                    {
                        Error("Se esperaba }");
                    }
                        break;
                //------------------------------------------------------------------------
                default:break;

            }
        }

        //----------------------------------------TEXTO---------------------------------------------------
        //------------------------------------------------------------------------------------------------
        public void Automata_Texto()
        {
            switch (estado)
            {
                //----------------------------------------------------------------------------------------
                case 0:
                    if (lex == "\"")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //---------------------------------------------------------------------------------------
                case 1:
                    if (lex == ":")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Se esperaba :");
                    }
                    break;
                //---------------------------------------------------------------------------------------
                case 2:
                    if (lex == "{")
                    {
                        llaves_abiertas++;
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba {");
                    }
                    break;
                //-------------------------------------------------------------------------------------
                case 3:
                    if (lex == "\"")
                    {
                        estado = 4;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //----------------------------------------------------------------------------------------
                case 4:
                    if (token == "TX_Cadena")
                    {
                        estado = 5;
                    }
                    else
                    {
                        Error("Se esperaba el atributo Font");
                    }
                    break;
                //---------------------------------------------------------------------------------------
                case 5:
                    if (lex == "\"")
                    {
                        estado = 6;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //--------------------------------------------------------------------------------------
                case 6:
                    if (lex == ":")
                    {
                        estado = 7;
                    }
                    else
                    {
                        Error("Se esperaba :");
                    }
                    break;
                //--------------------------------------------------------------------------------------
                case 7:
                    if (lex == "\"")
                    {
                        estado = 8;
                    }
                    else if (lex == "{")
                    {
                        Object[] padre = new Object[] { "Texto", 13 };
                        lista_padre.Insert(0, padre);
                        llaves_abiertas++;
                        estado = 15;
                    }
                    else
                    {
                        Error("Se esperaba \" o {");
                    }
                    break;
                //--------------------------------------------------------------------------------------
                case 8:
                    if (token == "TX_Cadena")
                    {
                        estado = 9;
                    }
                    else
                    {
                        Error("Se esperaba un String");
                    }
                    break;
                //--------------------------------------------------------------------------------------
                case 9:
                    if (lex == "\"")
                    {
                        estado = 10;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //--------------------------------------------------------------------------------------
                case 10:
                    if (lex == "}")
                    {
                        llaves_cerradas++;
                        Object[] obtener = (Object[])lista_padre[0];
                        DireccionarObjeto((String)obtener[0]);
                        estado = Convert.ToInt32(obtener[1]);
                    }
                    else
                    {
                        Error("Se esperaba }");
                    }
                    break;
                //---------------------------------------------------------------------------------------------
                case 12:
                    if (ObjetoPermitido(lex))
                    {
                        estado = 0;
                        DireccionarObjeto(lex);
                    }         
                    break;
                //-------------------------------------------------------------------------------------
                case 13:
                    if (lex == ",")
                    {
                        estado = 15;
                    }
                    else if (lex == "}")
                    {
                        llaves_cerradas++;
                        lista_padre.RemoveAt(0);
                        estado = 14;
                    }
                    else
                    {
                        Error("Se esperaba , o }");
                    }
                    break;
                //------------------------------------------------------------------------------------
                case 14:
                    if (lex == "}")
                    {
                        llaves_cerradas++;
                        Object[] obtener = (Object[])lista_padre[0];
                        DireccionarObjeto((String)obtener[0]);
                        estado = Convert.ToInt32(obtener[1]);
                    }
                    else
                    {
                        Error("Se esperaba }");
                    }
                    break;
                //-----------------------------------------------------------------------------------
                case 15:
                    if (lex == "\"")
                    {
                        estado = 12;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                default:break;
            }
        }

        //----------------------------------------Parrafo---------------------------------------------------
        //--------------------------------------------------------------------------------------------------
        public void Automata_Parrafo()
        {
            switch (estado)
            {
                //----------------------------------------------------------------------------------------
                case 0:
                    if (lex == "\"")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //---------------------------------------------------------------------------------------
                case 1:
                    if (lex == ":")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Se esperaba :");
                    }
                    break;
                //---------------------------------------------------------------------------------------
                case 2:
                    if (lex == "\"")
                    {
                        estado = 3;
                    }
                    else if (lex == "{")
                    {
                        Object[] padre = new Object[] { "Parrafo", 6 };
                        lista_padre.Insert(0, padre);
                        llaves_abiertas++;
                        estado = 7;
                    }
                    else
                    {
                        Error("Se esperaba \" o {");
                    }
                    break;
                //--------------------------------------------------------------------------------------
                case 3:
                    if (token == "TX_Cadena")
                    {
                        estado = 4;
                    }
                    else
                    {
                        Error("Se esperaba un String");
                    }
                    break;
                //--------------------------------------------------------------------------------------
                case 4:
                    if (lex == "\"")
                    {
                        Object[] obtener = (Object[])lista_padre[0];
                        DireccionarObjeto((String)obtener[0]);
                        estado = Convert.ToInt32(obtener[1]);
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //--------------------------------------------------------------------------------------
                case 5:
                    if (ObjetoPermitido(lex))
                    {
                        estado = 0;
                        DireccionarObjeto(lex);
                    }
                    break;
                //-------------------------------------------------------------------------------------
                case 6:
                    if (lex == ",")
                    {
                        estado = 7;
                    }
                    else if (lex == "}")
                    {
                        llaves_cerradas++;
                        lista_padre.RemoveAt(0);
                        Object[] obtener = (Object[])lista_padre[0];
                        DireccionarObjeto((String)obtener[0]);
                        estado = Convert.ToInt32(obtener[1]);

                    }
                    else
                    {
                        Error("Se esperaba , o }");
                    }
                    break;
                case 7:
                    if (lex == "\"")
                    {
                        estado = 5;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    //--------------------------------------------------------------------------------------
                    break;
                default: break;
            }
        }

        //---------------------------------------------Centro,Izquierda,Derecha----------------------------
        public void Automata_Posicion()
        {
            switch (estado)
            {
                //----------------------------------------------------------------------------------------
                case 0:
                    if (lex == "\"")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Hace falta \"");
                    }
                    break;
                //-----------------------------------------------------------------------------------------
                case 1:
                    if (lex == ":")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Se esperaba :");
                    }
                    break;
                //------------------------------------------------------------------------------------------
                case 2:
                    if (lex == "{")
                    {
                        Object[] padre = new Object[] { "Orientacion", 5 };
                        lista_padre.Insert(0, padre);
                        llaves_abiertas++;
                        estado = 3;
                    }
                    else
                    {
                        Error("Hace falta {");
                    }
                    break;
                //-------------------------------------------------------------------------------------------
                case 3:
                    if (lex == "\"")
                    {
                        estado = 4;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //--------------------------------------------------------------------------------------------
                case 4:
                    if (ObjetoPermitido2(lex))
                    {
                        estado = 0;
                        DireccionarObjeto(lex);
                    }
                    break;
                //--------------------------------------------------------------------------------------------
                case 5:
                    if (lex == ",")
                    {
                        estado = 3;
                    }else if (lex == "}")
                    {
                        llaves_cerradas++;
                        lista_padre.RemoveAt(0);

                        Object[] obtener = (Object[])lista_padre[0];
                        DireccionarObjeto((String)obtener[0]);
                        estado = Convert.ToInt32(obtener[1]);
                    }
                    else
                    {
                        Error("Hace Falta } o \",\", o que cierre el objeto");
                    }
                    break;
                //--------------------------------------------------------------------------------
                default:break;
            }
        }
        //-----------------------------------------------DISEÑO-------------------------------------------
        public void Automata_Diseño()
        {
            switch (estado)
            {
                //----------------------------------------------------------------------------------------
                case 0:
                    if (lex == "\"")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //---------------------------------------------------------------------------------------
                case 1:
                    if (lex == ":")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Se esperaba :");
                    }
                    break;
                //---------------------------------------------------------------------------------------
                case 2:
                    if (lex == "\"")
                    {
                        estado = 3;
                    }
                    else if (lex == "{")
                    {
                        Object[] padre = new Object[] { "Diseño", 6 };
                        lista_padre.Insert(0, padre);
                        llaves_abiertas++;
                        estado = 7;
                    }
                    else
                    {
                        Error("Se esperaba \" o {");
                    }
                    break;
                //--------------------------------------------------------------------------------------
                case 3:
                    if (token == "TX_Cadena")
                    {
                        estado = 4;
                    }
                    else
                    {
                        Error("Se esperaba un String");
                    }
                    break;
                //--------------------------------------------------------------------------------------
                case 4:
                    if (lex == "\"")
                    {
                        Object[] obtener = (Object[])lista_padre[0];
                        DireccionarObjeto((String)obtener[0]);
                        estado = Convert.ToInt32(obtener[1]);
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //--------------------------------------------------------------------------------------
                case 5:
                    if (ObjetoPermitido3(lex))
                    {
                        estado = 0;
                        DireccionarObjeto(lex);
                    }
                    break;
                //-------------------------------------------------------------------------------------
                case 6:
                    if (lex == ",")
                    {
                        estado = 7;
                    }
                    else if (lex == "}")
                    {
                        llaves_cerradas++;
                        lista_padre.RemoveAt(0);
                        Object[] obtener = (Object[])lista_padre[0];
                        DireccionarObjeto((String)obtener[0]);
                        estado = Convert.ToInt32(obtener[1]);
;
                    }
                    else
                    {
                        Error("Se esperaba , o }");
                    }
                    break;
                case 7:
                    if (lex == "\"")
                    {
                        estado = 5;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    //--------------------------------------------------------------------------------------
                    break;
                default: break;
            }
        }
        //-----------------------------------------------COLOR--------------------------------------------
        public void Automata_Color()
        {
            switch (estado)
            {
                //----------------------------------------------------------------------------------------
                case 0:
                    if (lex == "\"")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //---------------------------------------------------------------------------------------
                case 1:
                    if (lex == ":")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Se esperaba :");
                    }
                    break;
                //---------------------------------------------------------------------------------------
                case 2:
                    if (lex == "{")
                    {
                        llaves_abiertas++;
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba {");
                    }
                    break;
                //-------------------------------------------------------------------------------------
                case 3:
                    if (lex == "\"")
                    {
                        estado = 4;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //----------------------------------------------------------------------------------------
                case 4:
                    if (token == "TX_Cadena")
                    {
                        estado = 5;
                    }
                    else
                    {
                        Error("Se esperaba el atributo Font");
                    }
                    break;
                //---------------------------------------------------------------------------------------
                case 5:
                    if (lex == "\"")
                    {
                        estado = 6;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //--------------------------------------------------------------------------------------
                case 6:
                    if (lex == ":")
                    {
                        estado = 7;
                    }
                    else
                    {
                        Error("Se esperaba :");
                    }
                    break;
                //--------------------------------------------------------------------------------------
                case 7:
                    if (lex == "\"")
                    {
                        estado = 8;
                    }
                    else if (lex == "{")
                    {
                        Object[] padre = new Object[] { "Color", 13 };
                        lista_padre.Insert(0, padre);
                        llaves_abiertas++;
                        estado = 15;
                    }
                    else
                    {
                        Error("Se esperaba \" o {");
                    }
                    break;
                //--------------------------------------------------------------------------------------
                case 8:
                    if (token == "TX_Cadena")
                    {
                        estado = 9;
                    }
                    else
                    {
                        Error("Se esperaba un String");
                    }
                    break;
                //--------------------------------------------------------------------------------------
                case 9:
                    if (lex == "\"")
                    {
                        estado = 10;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //--------------------------------------------------------------------------------------
                case 10:
                    if (lex == "}")
                    {
                        llaves_cerradas++;
                        Object[] obtener = (Object[])lista_padre[0];
                        DireccionarObjeto((String)obtener[0]);
                        estado = Convert.ToInt32(obtener[1]);
                    }
                    else
                    {
                        Error("Se esperaba }");
                    }
                    break;
                //---------------------------------------------------------------------------------------------
                case 12:
                    if (ObjetoPermitido3(lex))
                    {
                        estado = 0;
                        DireccionarObjeto(lex);
                    }
                    break;
                //-------------------------------------------------------------------------------------
                case 13:
                    if (lex == ",")
                    {
                        estado = 15;
                    }
                    else if (lex == "}")
                    {
                        llaves_cerradas++;
                        lista_padre.RemoveAt(0);
                        estado = 14;
                    }
                    else
                    {
                        Error("Se esperaba , o }");
                    }
                    break;
                //------------------------------------------------------------------------------------
                case 14:
                    if (lex == "}")
                    {
                        llaves_cerradas++;
                        Object[] obtener = (Object[])lista_padre[0];
                        DireccionarObjeto((String)obtener[0]);
                        estado = Convert.ToInt32(obtener[1]);
                    }
                    else
                    {
                        Error("Se esperaba }");
                    }
                    break;
                //-----------------------------------------------------------------------------------
                case 15:
                    if (lex == "\"")
                    {
                        estado = 12;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                default: break;
            }
        }
        //-----------------------------------------------TITULO------------------------------------------
        public void Automata_Titulo()
        {
            switch (estado)
            {
                //----------------------------------------------------------------------------------------
                case 0:
                    if (lex == "\"")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //---------------------------------------------------------------------------------------
                case 1:
                    if (lex == ":")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Se esperaba :");
                    }
                    break;
                //---------------------------------------------------------------------------------------
                case 2:
                    if (lex == "{")
                    {
                        llaves_abiertas++;
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba {");
                    }
                    break;
                //-------------------------------------------------------------------------------------
                case 3:
                    if (lex == "\"")
                    {
                        estado = 4;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //----------------------------------------------------------------------------------------
                case 4:
                    if (AtributosTitulo(lex))
                    {
                        if (token.Contains("AT_"))
                        {
                            estado = 5;
                        }
                        else
                        {
                            Error("Se esperaba un atributo");
                        }
                    }
                   
                    break;
                //-----------------------------------------------------------------------------------------
                case 5:
                    if (lex == "\"")
                    {
                        estado = 6;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //-------------------------------------------------------------------------------------------
                case 6:
                    if (lex == ":")
                    {
                        estado = 7;
                    }
                    else
                    {
                        Error("Se esperaba :");
                    }
                    break;
                //---------------------------------------------------------------------------------------------
                case 7:
                    if (lex == "\"")
                    {
                        estado = 8;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //--------------------------------------------------------------------------------------------
                case 8:
                    if (token == "TX_Cadena")
                    {
                        estado = 9;
                    }
                    else
                    {
                        Error("Se esperaba un valor");
                    }
                    break;
                //--------------------------------------------------------------------------------------------
                case 9:
                    if (lex == "\"")
                    {
                        estado = 10;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //--------------------------------------------------------------------------------------------
                case 10:
                    if (lex == ",")
                    {
                        estado = 3;
                    }else if (lex == "}")
                    {
                        if (!(text_titulo))
                        {
                            Error("Atributo Text es obligatorio");
                        }
                        Object[] obtener = (Object[])lista_padre[0];
                        DireccionarObjeto((String)obtener[0]);
                        estado = Convert.ToInt32(obtener[1]);
                    }
                    else
                    {
                        Error("Se esperaba mas atributos o que se cerrara Titulo");
                    }
                    break;
                //-------------------------------------------------------------------------------------------
                default:break;
            }
        }

        //-----------------------------------------------TABLA------------------------------------------
        public void Automata_Tabla()
        {
            switch (estado)
            {
                //----------------------------------------------------------------------------------------
                case 0:
                    if (lex == "\"")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //---------------------------------------------------------------------------------------
                case 1:
                    if (lex == ":")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Se esperaba :");
                    }
                    break;
                //---------------------------------------------------------------------------------------
                case 2:
                    if (lex == "{")
                    {
                        llaves_abiertas++;
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba {");
                    }
                    break;
                //-------------------------------------------------------------------------------------
                case 3:
                    if (lex == "\"")
                    {
                        estado = 4;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //----------------------------------------------------------------------------------------
                case 4:
                    if (lex == "Fila")
                    {
                        estado = 5;
                    }
                    else
                    {
                        Error("Hace falta el Atributo Tabla");
                    }
                    break;
                //----------------------------------------------------------------------------------------
                case 5:
                    if (lex == "\"")
                    {
                        estado = 6;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //----------------------------------------------------------------------------------------
                case 6:
                    if (lex == ":")
                    {
                        estado = 7;
                    }
                    else
                    {
                        Error("Se esperaba :");
                    }
                    break;
                //--------------------------------------------------------------------------------------
                case 7:
                    if (lex == "\"")
                    {
                        estado = 8;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //--------------------------------------------------------------------------------------
                case 8:
                    if (token == "TX_Cadena")
                    {
                        estado = 9;
                    }
                    else
                    {
                        Error("Se esperaba una columna");
                    }
                    break;
                //--------------------------------------------------------------------------------------
                case 9:
                    if (lex == ",")
                    {
                        estado = 8;
                    }
                    else if(lex== "\"")
                    {
                        estado = 10;
                    }
                    else
                    {
                        Error("Se esperaba otra columna o que cerrara la columna");
                    }
                    break;
                //----------------------------------------------------------------------------------------------
                case 10:
                    if (lex == "}")
                    {
                        Object[] obtener = (Object[])lista_padre[0];
                        DireccionarObjeto((String)obtener[0]);
                        estado = Convert.ToInt32(obtener[1]);
                    }
                    else if (lex==",")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba } u otra fila");
                    }
                    break;
                //--------------------------------------------------------------------------------------------
                default:break;
            }
        }
        //-----------------------------------------------IMAGEN----------------------------------------------
        public void Automata_Imagen()
        {
            switch (estado)
            {
                //----------------------------------------------------------------------------------------
                case 0:
                    if (lex == "\"")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //---------------------------------------------------------------------------------------
                case 1:
                    if (lex == ":")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Se esperaba :");
                    }
                    break;
                //---------------------------------------------------------------------------------------
                case 2:
                    if (lex == "\"")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //----------------------------------------------------------------------------------------
                case 3:
                    if (token == "TX_Cadena")
                    {
                        estado = 4;
                    }
                    else
                    {
                        Error("Se esperaba una direccion para la imagen");
                    }
                    break;
                //----------------------------------------------------------------------------------------
                case 4:
                    if (lex == "\"")
                    {
                        Object[] obtener = (Object[])lista_padre[0];
                        DireccionarObjeto((String)obtener[0]);
                        estado = Convert.ToInt32(obtener[1]);
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //--------------------------------------------------------------------------------------------
                default:
                    break;
            }
        }
        //-----------------------------------------------Salto----------------------------------------------
        public void Automata_Salto()
        {
            switch (estado)
            {
                //----------------------------------------------------------------------------------------
                case 0:
                    if (lex == "\"")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Se esperaba \"");
                    }
                    break;
                //---------------------------------------------------------------------------------------
                case 1:
                    if (lex == ":")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Se esperaba :");
                    }
                    break;
                //---------------------------------------------------------------------------------------
                case 2:
                    if (token == "TX_Cadena")
                    {

                        Object[] obtener = (Object[])lista_padre[0];
                        DireccionarObjeto((String)obtener[0]);
                        estado = Convert.ToInt32(obtener[1]);
                    }
                    else
                    {
                        Error("Se esperaba un valor de salto");
                    }
                    break;
                //--------------------------------------------------------------------------------------------
                default:
                    break;
            }
        }








        //-----------------------------------para los errores-------------------------------------
        public void Error(String mensaje)
        {
            Object[] datas = new Object[] { lex, data[1], data[2], "PK_ERROR", mensaje };
            Console.Write(data[1]+" "+data[2]);
            Console.Write(mensaje);
            lista_errores.Add(datas);
            estado = 50;
            inicio = false;
            encabezado = false;
            cuerpo = false;
            texto = false;
            Parrafo = false;
            Diseño = false;
            Orientacion = false;
            Titulo = false;
            Color = false;
            Tabla = false;
            Imagen = false;
            Salto = false;

        }

        //-------------------------------------Para saber que tipo de objeto es--------------------
        public void DireccionarObjeto(String objeto) {
            if (objeto == "Titulo")
            {
                cuerpo = false;
                texto = false;
                Parrafo = false;
                Orientacion = false;
                Diseño = false;
                Titulo = true;
                Color = false;
                Tabla = false;
                Imagen = false;
                Salto = false;

            }
            else if (objeto == "Texto")
            {
                cuerpo = false;
                texto = true;
                Parrafo = false;
                Orientacion = false;
                Diseño = false;
                Titulo = false;
                Color = false;
                Tabla = false;
                Imagen = false;
                Salto = false;

            }
            else if (objeto == "Negrita" || objeto=="Subrayado" || objeto=="Cursiva" || objeto== "Diseño")
            {
                cuerpo = false;
                texto = false;
                Parrafo = false;
                Orientacion = false;
                Diseño = true;
                Titulo = false;
                Color = false;
                Tabla = false;
                Imagen = false;
                Salto = false;

            }
            else if (objeto == "Tabla")
            {
                cuerpo = false;
                texto = false;
                Parrafo = false;
                Orientacion = false;
                Diseño = false;
                Titulo = false;
                Color = false;
                Tabla = true;
                Imagen = false;
                Salto = false;

            }
            else if (objeto == "Salto")
            {
                cuerpo = false;
                texto = false;
                Parrafo = false;
                Orientacion = false;
                Diseño = false;
                Titulo = false;
                Color = false;
                Tabla = false;
                Imagen = false;
                Salto = true;

            }
            else if(objeto=="Centro" || objeto=="Izquierda" || objeto == "Derecha" || objeto == "Orientacion")
            {
                cuerpo = false;
                texto = false;
                Parrafo = false;
                Orientacion = true;
                Diseño = false;
                Titulo = false;
                Color = false;
                Tabla = false;
                Imagen = false;
                Salto = false;
            }
            else if (objeto == "Parrafo")
            {
                cuerpo = false;
                texto = false;
                Parrafo = true;
                Orientacion = false;
                Diseño = false;
                Titulo = false;
                Color = false;
                Tabla = false;
                Imagen = false;
                Salto = false;
            }
            else if (objeto == "Color")
            {
                cuerpo = false;
                texto = false;
                Parrafo = false;
                Orientacion = false;
                Diseño = false;
                Titulo = false;
                Color = true;
                Tabla = false;
                Imagen = false;
                Salto = false;
            }
            else if (objeto == "Imagen")
            {
                cuerpo = false;
                texto = false;
                Parrafo = false;
                Orientacion = false;
                Diseño = false;
                Titulo = false;
                Color = false;
                Tabla = false;
                Imagen = true;
                Salto = false;
            }
            else if (objeto=="Cuerpo")
            {
                cuerpo = true;
                texto = false;
                Parrafo = false;
                Orientacion = false;
                Diseño = false;
                Titulo = false;
                Color = false;
                Tabla = false;
                Imagen = false;
                Salto = false;
            }
            else
            {
                Error("No se reconoce la palabra reservada");
            }

        }

        //-------------------------------------Objeto Permitido(TEXTO,PARRAFO)-------------------------------------
        public Boolean ObjetoPermitido(String objeto)
        {
             if (objeto == "Negrita" || objeto == "Subrayado" || objeto == "Cursiva")
            {
                return true;

            }
            else if (objeto == "Salto")
            {
                return true;
            }
            else if (objeto == "Color")
            {
                return true;
            }
            else
            {
                Error("No se reconoce la palabra reservada o esta palabra no esta permitida");
                return false;
            }

        }
        //-------------------------------------Objeto Permitido (POSICION)-----------------------
        public Boolean ObjetoPermitido2(String objeto) {
             if (objeto == "Texto")
            {
                return true;
            }
            else if (objeto == "Negrita" || objeto == "Subrayado" || objeto == "Cursiva")
            {
                return true;
            }
            else if (objeto == "Tabla")
            {
                return true;
            }
            else if (objeto == "Salto")
            {
                return true;
            }
            else if (objeto == "Centro" || objeto == "Izquierda" || objeto == "Derecha")
            {
                return true;
            }
            else if (objeto == "Parrafo")
            {
                return true;
            }
            else if (objeto == "Color")
            {
                return true;
            }
            else if (objeto == "Imagen")
            {
                return true;
            }
            else
            {
                Error("No se reconoce la palabra reservada o esta palabra no esta permitida");
                return false;
            }
        }
        //-------------------------------------OBJETO PERMITIDO (DISEÑO)-----------------------------------------
        public Boolean ObjetoPermitido3(String objeto)
        {
            if (objeto == "Texto")
            {
                return true;
            }
            else if (objeto == "Negrita" || objeto == "Subrayado" || objeto == "Cursiva")
            {
                return true;
            }
            else if (objeto == "Salto")
            {
                return true;
            }
            else if (objeto == "Centro" || objeto == "Izquierda" || objeto == "Derecha")
            {
                return true;
            }
            else if (objeto == "Parrafo")
            {
                return true;
            }
            else if (objeto == "Color")
            {
                return true;
            }
            else
            {
                Error("No se reconoce la palabra reservada o esta palabra no esta permitida");
                return false;
            }
        }
        //----------------------------------------Atributos permitidos para Titulo-------------------------------
        public Boolean AtributosTitulo(String objeto)
        {
            if (objeto == "Tamaño")
            {
                return true;
            }
            else if (objeto == "Posicion")
            {
                return true;
            }
            else if (objeto == "color")
            {
                return true;
            }
            else if (objeto == "Text")
            {
                text_titulo = true;
                return true;
            }
            else
            {
                Error("Atributo no permitido");
                return false;
            }
        }



        ///---------------------------------------------------------------GENERAR HTML DE SALIDA ERRORES-----------------------------------------------------------------------
        private void generarErrores()
        {
            String salida = "";
            salida += "<center><b><h1>Lista de Errores</h1></b></center><center><table border=\"1\" style=\"BORDER:DOUBLE 10PX Black\">"
                    + "<tr style=\"font-weight:bold\"><td>No.</td><td>Error</td><td>Token</td><td>Fila</td><td>Columna</td><td>Descripcion</td></tr>";
            for (int i = 0; i < lista_errores.Count; i++)
            {
                Object[] data = (Object[])lista_errores[i];
                salida += "<tr><td>" + i + "</td><td>" + data[0] + "</td><td>" + data[3] + "</td><td>" + data[1] + "</td><td>" + data[2] + "</td><td>"+data[4]+"</td></tr>";
            }
            salida += "</table></center>";
            TextWriter archivo;
            archivo = new StreamWriter("ERRORES.html");
            archivo.WriteLine(salida);
            archivo.Close();
        }

    }
}
