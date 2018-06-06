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
        private ArrayList cerrar_etiquetas = new ArrayList();
        private String lex;
        private int estado;
        private String token;
        private Object[] data;
        private int llaves_abiertas;
        private int atri_character;
        private Boolean text_titulo;
        //-------------------------------variables de en que estado andamos--------------------
        private Boolean xml;
        private Boolean character;
        private Boolean room;
        private Boolean patterns;
        private Boolean monsters;
        private Boolean look;
        private Boolean posX;
        private Boolean hearts;
        private Boolean item;
        private Boolean atriroom;
        private Boolean enviroment;
        private Boolean rock;
        private Boolean atrirock;
        private Boolean posrock;
        private Boolean spike;
        private Boolean atrispike;
        private Boolean posspike;
        private Boolean exit;
        private Boolean atriexit;
        private Boolean consumables;
        private Boolean heart;
        private Boolean atriheart;
        private Boolean bomb;
        private Boolean atribomb;
        private Boolean coin;
        private Boolean atricoin;
        private Boolean key;
        private Boolean atrikey;
        private Boolean itemC;
        private Boolean atriitemC;
        private Boolean pill;
        private Boolean atripill;
        private Boolean subitemspill;
        private Boolean pattern;
        private Boolean atrimonster;
        private Boolean monster;
        private Boolean itemmonster;
        //--------------------------------Variables aux----------------------------------------
        private String subitecha;
        private String stringpill;
        private int contaRoom;

        public AnalizadorSintactico(ArrayList lista_lexema, ArrayList lista_token, ArrayList lista_errores)
        {
            this.lista_lexema = lista_lexema;
            this.lista_token = lista_token;
            this.lista_errores = lista_errores;
            lex = "";
            token = "";
            estado = 0;
            llaves_abiertas = 0;
            atri_character = 0;
            contaRoom = 0;
            text_titulo = false;
            //---------------------------------------declaracion de estados----------------------
      xml=true;
         character=false;
         room=false;
         patterns=false;
         monsters=false;
         look=false;
         posX=false;
         hearts=false;
         item=false;
         atriroom=false;
         enviroment=false;
         rock=false;
         atrirock=false;
         posrock=false;
         spike=false;
         atrispike=false;
         posspike=false;
         exit=false;
         atriexit=false;
         consumables=false;
         heart=false;
         atriheart=false;
         bomb=false;
         atribomb=false;
         coin=false;
         atricoin=false;
         key=false;
         atrikey=false;
         itemC=false;
         atriitemC=false;
         pill=false;
         atripill=false;
         subitemspill=false;
         pattern=false;
         atrimonster=false;
         monster=false;
         itemmonster=false;

            //-----------------------------------------Fin declaracion de estados---------------------
            AnalisisSintactico();
            generarErrores();
        }

        public void AnalisisSintactico()
        {

            for (int i = 0; i > -1 && i < lista_lexema.Count; i++)
            {
                data = (Object[])lista_lexema[i];
                lex = (String)data[0];
                token = (String)lista_token[i];
                if (xml == true)
                {
                    Automata_XML();
                }
                else if (character == true)
                {
                    Automata_Character();
                }
                else if (look == true)
                {
                    SubAutomata_Look();
                }
                else if (posX == true)
                {
                    SubAutomata_posX();
                }
                else if (hearts == true)
                {
                    SubAutomata_contadores();

                }
                else if (item == true)
                {
                    SubAutomata_Stats();
                }
                else if (room == true)
                {
                    Automata_Room();
                }
                else if (atriroom == true)
                {
                    SubAutomata_Room();
                }
                else if (enviroment == true)
                {
                    Automata_Enviroment();
                }
                else if (rock == true)
                {
                    SubAutomataRock();
                }
                else if (atrirock == true)
                {
                    SubAutomata_rock();
                }
                else if (posrock == true)
                {
                    Automata_posRock();
                }
                else if (spike == true)
                {
                    SubAutomataSpike();
                }
                else if (atrispike == true)
                {
                    SubAutomata_spike();
                }
                else if (posspike == true)
                {
                    Automata_posspike();
                }
                else if (exit == true)
                {
                    SubAutomataExit();
                }
                else if (atriexit == true)
                {
                    SubAutomata_exit();
                }
                else if (consumables == true)
                {
                    Automata_Consumables();
                }
                else if (heart == true)
                {
                    SubAutomataHeart();
                }
                else if (atriheart == true)
                {
                    SubAutomata_heart();
                }
                else if (bomb == true)
                {
                    SubAutomataBomb();
                }
                else if (atribomb == true)
                {
                    SubAutomata_bomb();
                }
                else if (coin == true)
                {
                    SubAutomataCoin();
                }
                else if (atricoin == true)
                {
                    SubAutomata_coin();
                }
                else if (key == true)
                {
                    SubAutomataKey();
                }
                else if (atrikey == true)
                {
                    SubAutomata_key();
                }
                else if (itemC == true)
                {
                    SubAutomataItem();
                }
                else if (atriitemC == true)
                {
                    SubAutomata_item();
                }
                else if (pill == true)
                {
                    SubAutomataPill();
                }
                else if (atripill == true)
                {
                    SubAutomata_pill();
                }
                else if (subitemspill == true)
                {
                    SubItemAutomata_pill();
                }
                else if (patterns == true)
                {
                    Automata_Patters();
                }
                else if (pattern == true)
                {
                    SubAutomata_pattern();
                }
                else if (monsters == true)
                {
                    Automata_Monster();
                }
                else if (atrimonster == true)
                {
                    SubAutomata_Monster();
                }
                else if (monster == true)
                {
                    SubAutomata_mons();
                }
                else if (itemmonster == true)
                {
                    Automata_ItemMonster();
                }

            }
            if (cerrar_etiquetas.Count > 0)
            {
                String mensaje = (String)cerrar_etiquetas[0];
                Error("Hizo Falta Cerrar " + mensaje);
            }


        }



        //----------------------------------------Automatas Individuales--------------------------------------
        //----------------------------------------------------------------------------------------------------

        //-----------------------------------------AUTOMATA XML-------------------------------------------
        //----------------------------------------------------------------------------------------------------
        public void Automata_XML()
        {

            switch (estado)
            {
                //---------------------------------------------------------------------------
                case 0:
                    if (lex == "<")
                    {
                        llaves_abiertas++;
                        estado = 1;
                    }
                    else
                    {
                        Error("Error <");
                    }
                    break;
                //------------------------------------------------------------------------
                case 1:
                    if (lex == "xml")
                    {
                        estado = 2;
                        cerrar_etiquetas.Insert(0, "xml");
                    }
                    else
                    {
                        Error("Error hace falta xml");

                    }
                    break;
                //-------------------------------------------------------------------------
                case 2:
                    if (lex == ">")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Falta >");
                    }
                    break;
                //-------------------------------------------------------------------------
                case 3:
                    if (lex == "<")
                    {
                        Object[] padre = new Object[] { "xml", 4 };
                        lista_padre.Insert(0, padre);
                        estado = 4;
                    }
                    else
                    {
                        Error("Falta <");
                    }

                    break;
                //-------------------------------------------------------------------------------------
                case 4:
                    Redireccionar_xml(lex);
                    break;

                //--------------------------------------------------------------------------------------
                case 5:
                    if (lex == "xml")
                    {
                        estado = 6;
                    }
                    else
                    {
                        Error("Error hace falta xml");

                    }
                    break;
                //-------------------------------------------------------------------------------------
                case 6:
                    if (lex == ">")
                    {
                        cerrar_etiquetas.RemoveAt(0);
                        lista_padre.RemoveAt(0);
                        estado = 500;
                    }
                    else
                    {
                        Error("Error hace falta cerrar xml");

                    }
                    break;
                //--------------------------------------------------------------------------------------

                default: break;
            }
        }

        //-------------------------------------Direccionar xml--------------------

        public void Redireccionar_xml(String objeto)
        {
            if (objeto == "character")
            {
                estado = 0;
                monsters = false;
                patterns = false;
                character = true;
                xml = false;
                room = false;
                cerrar_etiquetas.Insert(0, "Character");
            }
            else if (objeto == "room")
            {
                estado = 0;
                monsters = false;
                patterns = false;
                room = true;
                character = false;
                xml = false;
            }
            else if (objeto == "patterns")
            {
                estado = 0;
                monsters = false;
                patterns = true;
                character = false;
                room = false;
                xml = false;
            }
            else if (objeto == "monsters")
            {
                estado = 0;
                monsters = true;
                patterns = false;
                character = false;
                room = false;
                xml = false;

            }
            else if (objeto == "/")
            {
                estado = 5;
            }
            else
            {
                Error("No se reconoce el item");
            }
        }

        //-----------------------------------------AUTOMATA Character-------------------------------------------
        //----------------------------------------------------------------------------------------------------

        public void Automata_Character()
        {
            switch (estado)
            {
                case 0:
                    if (Atributo_Character(lex) == true)
                    {
                        atri_character++;
                        estado = 0;
                        if (lex == "look")
                        {
                            character = false;
                            look = true;
                        }
                        else if (lex == "posX")
                        {
                            posX = true;
                            character = false;
                        }
                        else if (lex == "posY")
                        {
                            posX = true;
                            character = false;
                        }
                    }
                    else if (lex == ">")
                    {
                        if (atri_character > 2)
                        {
                            estado = 1;
                        }
                        else
                        {
                            Error("Se esperaba los tres atributos en Character");
                        }
                    }
                    else
                    {
                        Error("Se esperaba que se cerrara Character >");
                    }
                    break;

                case 1:
                    if (lex == "<")
                    {
                        hearts = false;
                        item = false;
                        estado = 2;
                    }
                    else
                    {
                        Error("Falto Apertura de Sub Item");
                    }
                    break;

                case 2:
                    if (token.Contains("IT_"))
                    {
                        estado = 0;
                        Items_Character(lex);
                    }
                    else if (lex == "/")
                    {
                        estado = 3;
                    }

                    else
                    {
                        Error("Se esperaba que se cerrara Character o no se reconoce el sub item");
                    }
                    break;


                case 3:
                    if (lex == "character")
                    {
                        estado = 4;
                    }
                    else
                    {
                        Error("Error en cerrar Character");
                    }
                    break;

                case 4:
                    if (lex == ">")
                    {
                        cerrar_etiquetas.RemoveAt(0);
                        estado = 3;
                        hearts = false;
                        item = false;
                        character = false;
                        xml = true;
                    }
                    else
                    {
                        Error("hizo falta cerrar Character");
                    }
                    break;

                default:
                    break;
            }
        }

        public void SubAutomata_Look()
        {
            switch (estado)
            {
                case 0:
                    if (lex == "=")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Hace falta = en atributo Look");
                    }
                    break;

                case 1:
                    if (lex == "\"")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Hace falta \" en atributo Look");
                    }
                    break;

                case 2:
                    if (token == "TX_Cadena")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba una cadena de texto");
                    }
                    break;

                case 3:
                    if (lex == "\"")
                    {
                        estado = 0;
                        look = false;
                        character = true;
                    }
                    else
                    {
                        Error("Se esperaba \" en atributo Look ");
                    }
                    break;

                default: break;
            }
        }

        public void SubAutomata_posX()
        {
            switch (estado)
            {
                case 0:
                    if (lex == "=")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Hace falta = en atributo pos");
                    }
                    break;

                case 1:
                    if (lex == "\"")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Hace falta \" en atributo pos");
                    }
                    break;

                case 2:
                    if (token == "TXT_Number")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba un numero entero");
                    }
                    break;

                case 3:
                    if (lex == "\"")
                    {
                        estado = 0;
                        posX = false;
                        character = true;
                    }
                    else
                    {
                        Error("Se esperaba \" en atributo pos ");
                    }
                    break;

                default: break;
            }
        }

        public Boolean Atributo_Character(String Objeto)
        {
            if (Objeto == "look")
            {

                return true;
            }
            else if (Objeto == "posX")
            {
                return true;
            }
            else if (Objeto == "posY")
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        //-----------------------------------------AUTOMATA ROOM-------------------------------------------
        //----------------------------------------------------------------------------------------------------

        public void Automata_Room()
        {
            switch (estado)
            {
                case 0:
                    if (Atributo_Room(lex) == true)
                    {
                        estado = 0;
                        room = false;
                        atriroom = true;
                    }
                    else if (lex == ">")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Se esperaba que se cerrara Room >");
                    }
                    break;

                case 1:
                    if (lex == "<")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Falto Apertura de Sub Item");
                    }
                    break;

                case 2:
                    if (token.Contains("IT_"))
                    {
                        estado = 0;
                        Items_Room(lex);
                    }
                    else if (lex == "/")
                    {
                        if (contaRoom > 1)
                        {
                            estado = 3;
                        }
                        else
                        {
                            Error("Sub Items enviroment y consumables obligatorios");
                        }
                    }
                    else
                    {
                        Error("Se esperaba que se cerrara Room o no se reconoce el sub item");
                    }
                    break;


                case 3:
                    if (lex == "room")
                    {
                        estado = 4;
                    }
                    else
                    {
                        Error("Error en cerrar room");
                    }
                    break;

                case 4:
                    if (lex == ">")
                    {
                        estado = 3;
                        room = false;
                        xml = true;
                    }
                    else
                    {
                        Error("hizo falta cerrar Room");
                    }
                    break;

                default: break;
            }

        }

        public void SubAutomata_Room()
        {
            switch (estado)
            {
                case 0:
                    if (lex == "=")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Hace falta = en atributo");
                    }
                    break;

                case 1:
                    if (lex == "\"")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Hace falta \" en atributo");
                    }
                    break;

                case 2:
                    if (token == "TX_Cadena" || token == "TXT_Number")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba una cadena de texto");
                    }
                    break;

                case 3:
                    if (lex == "\"")
                    {
                        estado = 0;
                        atriroom = false;
                        room = true;
                    }
                    else
                    {
                        Error("Se esperaba \" en atributo  ");
                    }
                    break;

                default: break;
            }
        }

        public void Items_Room(String objeto)
        {
            if (objeto == "enviroment")
            {
                contaRoom++;
                enviroment = true;
                room = false;
            }
            else if (objeto == "consumables")
            {
                consumables = true;
                room = false;
                contaRoom++;
            }
            else
            {
                Error("No se Reconoce el sub item para Room");
            }
        }

        public Boolean Atributo_Room(String Objeto)
        {
            if (Objeto == "width" || Objeto == "height" || Objeto == "color" || Objeto == "name")
            {
                Object[] padre = new Object[] { "room", 1 };
                lista_padre.Insert(0, padre);
                return true;
            }
            else
            {
                return false;
            }
        }



        //-----------------------------------------AUTOMATA Envirtoment-------------------------------------------
        //----------------------------------------------------------------------------------------------------

        public void Automata_Enviroment()
        {
            switch (estado)
            {
                case 0:
                    if (lex == ">")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Se esperaba que se cerrara Enviroment >");
                    }
                    break;

                case 1:
                    if (lex == "<")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Falto Apertura de Sub Item");
                    }
                    break;

                case 2:
                    if (token.Contains("IT_"))
                    {
                        estado = 0;
                        Items_Enviroment(lex);
                    }
                    else if (lex == "/")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba que se cerrara Enviroment o no se reconoce el sub item");
                    }
                    break;


                case 3:
                    if (lex == "enviroment")
                    {
                        estado = 4;
                    }
                    else
                    {
                        Error("Error en cerrar enviroment");
                    }
                    break;

                case 4:
                    if (lex == ">")
                    {
                        estado = 1;
                        room = true;
                        enviroment = false;
                    }
                    else
                    {
                        Error("hizo falta cerrar Enviroment");
                    }
                    break;

                default: break;
            }

        }

        public void Items_Enviroment(String objeto)
        {
            if (objeto == "rock")
            {
                estado = 0;
                rock = true;
                enviroment = false;
            }
            else if (objeto == "spike")
            {
                estado = 0;
                spike = true;
                enviroment = false;
            }
            else if (objeto == "exit")
            {
                estado = 0;
                exit = true;
                enviroment = false;
            }
            else
            {
                Error("No se Reconoce el sub item para Enviroment");
            }
        }


        //-------------------------------------ROCK-------------------------------------------------------

        public void SubAutomataRock()
        {
            switch (estado)
            {
                case 0:
                    if (Atributo_rock(lex) == true)
                    {
                        estado = 0;
                        rock = false;
                        atrirock = true;
                    }
                    else if (lex == ">")
                    {
                        estado = 1;
                    }
                    else if (lex == "/")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba que se cerrara Rock >");
                    }
                    break;

                case 1:
                    if (lex == "<")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Falto Apertura de Sub Item");
                    }
                    break;

                case 2:
                    if (token.Contains("IT_"))
                    {
                        estado = 0;
                        if (lex == "X" || lex == "Y")
                        {
                            posrock = true;
                            rock = false;
                        }
                        else
                        {
                            Error("No se reconoce el sub item en Rock");
                        }
                    }
                    else if (lex == "/")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba que se cerrara Rock o no se reconoce el sub item");
                    }
                    break;


                case 3:
                    if (lex == "rock")
                    {
                        estado = 4;
                    }
                    else if (lex == ">")
                    {
                        estado = 1;
                        rock = false;
                        enviroment = true;
                    }
                    else
                    {
                        Error("Error en cerrar rock");
                    }
                    break;

                case 4:
                    if (lex == ">")
                    {
                        estado = 1;
                        rock = false;
                        enviroment = true;
                    }
                    else
                    {
                        Error("hizo falta cerrar rock");
                    }
                    break;

                default: break;
            }
        }

        public void SubAutomata_rock()
        {
            switch (estado)
            {
                case 0:
                    if (lex == "=")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Hace falta = en atributo");
                    }
                    break;

                case 1:
                    if (lex == "\"")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Hace falta \" en atributo");
                    }
                    break;

                case 2:
                    if (token == "TX_Cadena" || token == "TXT_Number")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba una cadena de texto");
                    }
                    break;

                case 3:
                    if (lex == "\"")
                    {
                        estado = 0;
                        atrirock = false;
                        rock = true;
                    }
                    else
                    {
                        Error("Se esperaba \" en atributo  ");
                    }
                    break;

                default: break;
            }
        }

        public Boolean Atributo_rock(String objeto)
        {
            if (objeto == "texture" || objeto == "posX" || objeto == "posY")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Automata_posRock()
        {
            switch (estado)
            {
                case 0:
                    if (lex == ">")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Se esperaba >");
                    }
                    break;


                case 1:
                    if (token == "TXT_Number")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Se esperaba un numero");
                    }
                    break;


                case 2:
                    if (lex == "<")
                    {
                        estado = 3;
                    }
                    else if (lex == ",")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("no se reconoce: ");
                    }
                    break;

                case 3:
                    if (lex == "/")
                    {
                        estado = 4;
                    }
                    else
                    {
                        Error("Se esperaba /");
                    }
                    break;


                case 4:
                    if (lex == "X")
                    {
                        estado = 5;
                    }
                    else if (lex == "Y")
                    {
                        estado = 5;
                    }
                    else
                    {
                        Error("Se esperaba que se cerrara la etiqueta");
                    }
                    break;


                case 5:
                    if (lex == ">")
                    {
                        estado = 1;
                        posrock = false;
                        rock = true;
                    }
                    else
                    {
                        Error("Se esperaba >");
                    }
                    break;


                default: break;
            }
        }

        //------------------------------------SPIKE------------------------------------------------------
        public void SubAutomataSpike()
        {
            switch (estado)
            {
                case 0:
                    if (Atributo_spike(lex) == true)
                    {
                        estado = 0;
                        spike = false;
                        atrispike = true;
                    }
                    else if (lex == ">")
                    {
                        estado = 1;
                    }
                    else if (lex == "/")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba que se cerrara Spike >");
                    }
                    break;

                case 1:
                    if (lex == "<")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Falto Apertura de Sub Item");
                    }
                    break;

                case 2:
                    if (token.Contains("IT_"))
                    {
                        estado = 0;
                        if (lex == "X" || lex == "Y")
                        {
                            posspike = true;
                            spike = false;
                        }
                        else
                        {
                            Error("No se reconoce el sub item en Spike");
                        }
                    }
                    else if (lex == "/")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba que se cerrara Spike o no se reconoce el sub item");
                    }
                    break;


                case 3:
                    if (lex == "spike")
                    {
                        estado = 4;
                    }
                    else if (lex == ">")
                    {
                        estado = 1;
                        spike = false;
                        enviroment = true;
                    }
                    else
                    {
                        Error("Error en cerrar rock");
                    }
                    break;

                case 4:
                    if (lex == ">")
                    {
                        estado = 1;
                        spike = false;
                        enviroment = true;
                    }
                    else
                    {
                        Error("hizo falta cerrar spike");
                    }
                    break;

                default: break;
            }
        }

        public void SubAutomata_spike()
        {
            switch (estado)
            {
                case 0:
                    if (lex == "=")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Hace falta = en atributo");
                    }
                    break;

                case 1:
                    if (lex == "\"")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Hace falta \" en atributo");
                    }
                    break;

                case 2:
                    if (token == "TX_Cadena" || token == "TXT_Number")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba una cadena de texto");
                    }
                    break;

                case 3:
                    if (lex == "\"")
                    {
                        estado = 0;
                        atrispike = false;
                        spike = true;
                    }
                    else
                    {
                        Error("Se esperaba \" en atributo  ");
                    }
                    break;

                default: break;
            }
        }

        public Boolean Atributo_spike(String objeto)
        {
            if (objeto == "texture" || objeto == "posX" || objeto == "posY")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Automata_posspike()
        {
            switch (estado)
            {
                case 0:
                    if (lex == ">")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Se esperaba >");
                    }
                    break;


                case 1:
                    if (token == "TXT_Number")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Se esperaba un numero");
                    }
                    break;


                case 2:
                    if (lex == "<")
                    {
                        estado = 3;
                    }
                    else if (lex == ",")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("no se reconoce: ");
                    }
                    break;

                case 3:
                    if (lex == "/")
                    {
                        estado = 4;
                    }
                    else
                    {
                        Error("Se esperaba /");
                    }
                    break;


                case 4:
                    if (lex == "X")
                    {
                        estado = 5;
                    }
                    else if (lex == "Y")
                    {
                        estado = 5;
                    }
                    else
                    {
                        Error("Se esperaba que se cerrara la etiqueta");
                    }
                    break;


                case 5:
                    if (lex == ">")
                    {
                        estado = 1;
                        posspike = false;
                        spike = true;
                    }
                    else
                    {
                        Error("Se esperaba >");
                    }
                    break;


                default: break;
            }
        }


        //-------------------------------------------------------------------EXIT--------------------------------------------------------------

        public void SubAutomataExit()
        {
            switch (estado)
            {
                case 0:
                    if (Atributo_exit(lex) == true)
                    {
                        estado = 0;
                        exit = false;
                        atriexit = true;
                    }
                    else if (lex == "/")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba que se cerrara Exit /");
                    }
                    break;

                case 3:
                    if (lex == ">")
                    {
                        estado = 1;
                        exit = false;
                        enviroment = true;
                    }
                    else
                    {
                        Error("Error en cerrar exit");
                    }
                    break;

                default: break;
            }
        }

        public void SubAutomata_exit()
        {
            switch (estado)
            {
                case 0:
                    if (lex == "=")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Hace falta = en atributo");
                    }
                    break;

                case 1:
                    if (lex == "\"")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Hace falta \" en atributo");
                    }
                    break;

                case 2:
                    if (token == "TX_Cadena" || token == "TXT_Number")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba una cadena de texto");
                    }
                    break;

                case 3:
                    if (lex == "\"")
                    {
                        estado = 0;
                        atriexit = false;
                        exit = true;
                    }
                    else
                    {
                        Error("Se esperaba \" en atributo  ");
                    }
                    break;

                default: break;
            }
        }

        public Boolean Atributo_exit(String objeto)
        {
            if (objeto == "texture" || objeto == "posX" || objeto == "posY")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //-----------------------------------------------------------------AUTOMATA  CONSUMABLES----------------------------------------------
        public void Automata_Consumables()
        {
            switch (estado)
            {
                case 0:
                    if (lex == ">")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Se esperaba que se cerrara Consumable >");
                    }
                    break;

                case 1:
                    if (lex == "<")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Falto Apertura de Sub Item");
                    }
                    break;

                case 2:
                    if (token.Contains("IT_"))
                    {
                        estado = 0;
                        Items_Consumables(lex);
                    }
                    else if (lex == "/")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba que se cerrara Consumable o no se reconoce el sub item");
                    }
                    break;


                case 3:
                    if (lex == "consumables")
                    {
                        estado = 4;
                    }
                    else
                    {
                        Error("Error en cerrar consumable");
                    }
                    break;

                case 4:
                    if (lex == ">")
                    {
                        estado = 1;
                        room = true;
                        consumables = false;
                    }
                    else
                    {
                        Error("hizo falta cerrar consumables");
                    }
                    break;

                default: break;
            }

        }
        public void Items_Consumables(String objeto)
        {
            if (objeto == "heart")
            {
                estado = 0;
                heart = true;
                consumables = false;
            }
            else if (objeto == "coin")
            {
                estado = 0;
                coin = true;
                consumables = false;
            }
            else if (objeto == "bomb")
            {
                estado = 0;
                bomb = true;
                consumables = false;
            }
            else if (objeto == "key")
            {
                estado = 0;
                key = true;
                consumables = false;
            }
            else if (objeto == "item")
            {
                estado = 0;
                itemC = true;
                consumables = false;
            }
            else if (objeto == "pill")
            {
                estado = 0;
                pill = true;
                consumables = false;
            }
            else
            {
                Error("No se Reconoce el sub item para Consumables");
            }
        }


        //-------------------------------------------------------------------Heart--------------------------------------------------------------

        public void SubAutomataHeart()
        {
            switch (estado)
            {
                case 0:
                    if (Atributo_heart(lex) == true)
                    {
                        estado = 0;
                        heart = false;
                        atriheart = true;
                    }
                    else if (lex == "/")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba que se cerrara Heart /");
                    }
                    break;

                case 3:
                    if (lex == ">")
                    {
                        estado = 1;
                        heart = false;
                        consumables = true;
                    }
                    else
                    {
                        Error("Error en cerrar heart");
                    }
                    break;

                default: break;
            }
        }

        public void SubAutomata_heart()
        {
            switch (estado)
            {
                case 0:
                    if (lex == "=")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Hace falta = en atributo");
                    }
                    break;

                case 1:
                    if (lex == "\"")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Hace falta \" en atributo");
                    }
                    break;

                case 2:
                    if (token == "TX_Cadena" || token == "TXT_Number")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba una cadena de texto");
                    }
                    break;

                case 3:
                    if (lex == "\"")
                    {
                        estado = 0;
                        atriheart = false;
                        heart = true;
                    }
                    else
                    {
                        Error("Se esperaba \" en atributo  ");
                    }
                    break;

                default: break;
            }
        }

        public Boolean Atributo_heart(String objeto)
        {
            if (objeto == "texture" || objeto == "posX" || objeto == "posY")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //-------------------------------------------------------------------Bomb--------------------------------------------------------------

        public void SubAutomataBomb()
        {
            switch (estado)
            {
                case 0:
                    if (Atributo_bomb(lex) == true)
                    {
                        estado = 0;
                        bomb = false;
                        atribomb = true;
                    }
                    else if (lex == "/")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba que se cerrara Bomb /");
                    }
                    break;

                case 3:
                    if (lex == ">")
                    {
                        estado = 1;
                        bomb = false;
                        consumables = true;
                    }
                    else
                    {
                        Error("Error en cerrar bomb");
                    }
                    break;

                default: break;
            }
        }

        public void SubAutomata_bomb()
        {
            switch (estado)
            {
                case 0:
                    if (lex == "=")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Hace falta = en atributo");
                    }
                    break;

                case 1:
                    if (lex == "\"")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Hace falta \" en atributo");
                    }
                    break;

                case 2:
                    if (token == "TX_Cadena" || token == "TXT_Number")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba una cadena de texto");
                    }
                    break;

                case 3:
                    if (lex == "\"")
                    {
                        estado = 0;
                        atribomb = false;
                        bomb = true;
                    }
                    else
                    {
                        Error("Se esperaba \" en atributo  ");
                    }
                    break;

                default: break;
            }
        }

        public Boolean Atributo_bomb(String objeto)
        {
            if (objeto == "texture" || objeto == "posX" || objeto == "posY")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //-------------------------------------------------------------------Coin--------------------------------------------------------------

        public void SubAutomataCoin()
        {
            switch (estado)
            {
                case 0:
                    if (Atributo_bomb(lex) == true)
                    {
                        estado = 0;
                        coin = false;
                        atricoin = true;
                    }
                    else if (lex == "/")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba que se cerrara Coin /");
                    }
                    break;

                case 3:
                    if (lex == ">")
                    {
                        estado = 1;
                        coin = false;
                        consumables = true;
                    }
                    else
                    {
                        Error("Error en cerrar Coin");
                    }
                    break;

                default: break;
            }
        }

        public void SubAutomata_coin()
        {
            switch (estado)
            {
                case 0:
                    if (lex == "=")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Hace falta = en atributo");
                    }
                    break;

                case 1:
                    if (lex == "\"")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Hace falta \" en atributo");
                    }
                    break;

                case 2:
                    if (token == "TX_Cadena" || token == "TXT_Number")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba una cadena de texto");
                    }
                    break;

                case 3:
                    if (lex == "\"")
                    {
                        estado = 0;
                        atricoin = false;
                        coin = true;
                    }
                    else
                    {
                        Error("Se esperaba \" en atributo  ");
                    }
                    break;

                default: break;
            }
        }


        //-------------------------------------------------------------------Key--------------------------------------------------------------

        public void SubAutomataKey()
        {
            switch (estado)
            {
                case 0:
                    if (Atributo_bomb(lex) == true)
                    {
                        estado = 0;
                        key = false;
                        atrikey = true;
                    }
                    else if (lex == "/")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba que se cerrara Key /");
                    }
                    break;

                case 3:
                    if (lex == ">")
                    {
                        estado = 1;
                        key = false;
                        consumables = true;
                    }
                    else
                    {
                        Error("Error en cerrar Key");
                    }
                    break;

                default: break;
            }
        }

        public void SubAutomata_key()
        {
            switch (estado)
            {
                case 0:
                    if (lex == "=")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Hace falta = en atributo");
                    }
                    break;

                case 1:
                    if (lex == "\"")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Hace falta \" en atributo");
                    }
                    break;

                case 2:
                    if (token == "TX_Cadena" || token == "TXT_Number")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba una cadena de texto");
                    }
                    break;

                case 3:
                    if (lex == "\"")
                    {
                        estado = 0;
                        atrikey = false;
                        key = true;
                    }
                    else
                    {
                        Error("Se esperaba \" en atributo  ");
                    }
                    break;

                default: break;
            }
        }


        //-------------------------------------------------------------------Item--------------------------------------------------------------

        public void SubAutomataItem()
        {
            switch (estado)
            {
                case 0:
                    if (Atributo_bomb(lex) == true)
                    {
                        estado = 0;
                        itemC = false;
                        atriitemC = true;
                    }
                    else if (lex == "/")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba que se cerrara Item /");
                    }
                    break;

                case 3:
                    if (lex == ">")
                    {
                        estado = 1;
                        itemC = false;
                        consumables = true;
                    }
                    else
                    {
                        Error("Error en cerrar Item");
                    }
                    break;

                default: break;
            }
        }

        public void SubAutomata_item()
        {
            switch (estado)
            {
                case 0:
                    if (lex == "=")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Hace falta = en atributo");
                    }
                    break;

                case 1:
                    if (lex == "\"")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Hace falta \" en atributo");
                    }
                    break;

                case 2:
                    if (token == "TX_Cadena" || token == "TXT_Number")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba una cadena de texto");
                    }
                    break;

                case 3:
                    if (lex == "\"")
                    {
                        estado = 0;
                        atriitemC = false;
                        itemC = true;
                    }
                    else
                    {
                        Error("Se esperaba \" en atributo  ");
                    }
                    break;

                default: break;
            }
        }

        //-------------------------------------------------------------------pills-----------------------------------------------------------
        public void SubAutomataPill()
        {
            switch (estado)
            {
                case 0:
                    if (Atributo_bomb(lex) == true)
                    {
                        estado = 0;
                        pill = false;
                        atripill = true;
                    }
                    else if (lex == ">")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba que se cerrara Pill >");
                    }
                    break;

                case 3:
                    if (lex == "<")
                    {
                        estado = 4;
                       
                    }
                    else
                    {
                        Error("Error en cerrar Pill");
                    }
                    break;


                case 4:
                    Item_Pill(lex);
                    break;

                case 5:
                    if (lex == "<")
                    {
                        estado = 6;
                    }
                    else
                    {
                        Error("Se esperaba <");
                    }
                    break;


                case 6:
                    if (lex == "/")
                    {
                        estado = 7;
                    }
                    else
                    {
                        Error("Se esperaba /");
                    }
                    break;

                case 7:
                    if (lex == "pill")
                    {
                        estado = 8;
                    }
                    else
                    {
                        Error("Se esperaba pill");
                    }
                    break;

                case 8:
                    if (lex == ">")
                    {
                        estado = 1;
                        pill = false;
                        consumables = true;
                    }
                    else
                    {
                        Error("Se esperaba >");
                    }
                    break;
                default: break;
            }
        }

        public void SubAutomata_pill()
        {
            switch (estado)
            {
                case 0:
                    if (lex == "=")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Hace falta = en atributo");
                    }
                    break;

                case 1:
                    if (lex == "\"")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Hace falta \" en atributo");
                    }
                    break;

                case 2:
                    if (token == "TX_Cadena" || token == "TXT_Number")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba una cadena de texto");
                    }
                    break;

                case 3:
                    if (lex == "\"")
                    {
                        estado = 0;
                        atripill = false;
                        pill = true;
                    }
                    else
                    {
                        Error("Se esperaba \" en atributo  ");
                    }
                    break;

                default: break;
            }
        }


        public void Item_Pill(String objeto)
        {
            if(objeto=="action" || objeto=="value" || objeto == "stat")
            {
                estado = 0;
                stringpill = objeto;
                subitemspill = true;
                pill = false;
            }
            else if (objeto == "/")
            {
                estado = 7;
            }
            else
            {
                Error("No se reconoce el sub Item para Pill");
            }
        }

        public void SubItemAutomata_pill()
        {
            switch (estado)
            {

                case 0:
                    if (lex == ">")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Se esperaba que se cerrara > en " + stringpill);
                    }
                    break;

                case 1:
                    if (stringpill == "action")
                    {
                        if(lex=="SUMAR" || lex=="RESTAR" || lex=="MULTIPLICAR" || lex == "DIVIDIR")
                        {
                            estado = 2;
                        }
                        else
                        {
                            Error("No se permite ese valor en Action");
                        }
                    }
                    else if(stringpill == "stat")
                    {
                        if(lex=="hearts" || lex=="coins" || lex=="bombs" || lex=="keys" || lex=="damage" || lex=="range" || lex == "luck")
                        {
                            estado = 2;
                        }
                        else
                        {
                            Error("Stat no reconoce este valor");
                        }
                    }
                    else
                    {
                        if (token == "TXT_Number")
                        {
                            estado = 2;
                        }
                        else
                        {
                            Error("Se esperaba un numero para value");
                        }
                    }
                    
                    break;

                case 2:
                    if (lex == "<")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba < en " + stringpill);
                    }
                    break;

                case 3:
                    if (lex == "/")
                    {
                        estado = 4;
                    }
                    else
                    {
                        Error("Se esperaba / en " + stringpill);
                    }
                    break;


                case 4:
                    if (lex == stringpill)
                    {
                        estado = 5;
                    }
                    else
                    {
                        Error("Se esperaba que se cerrara " + stringpill);
                    }
                    break;

                case 5:
                    if (lex == ">")
                    {
                        estado = 3;
                        subitemspill = false;
                        pill = true;

                    }
                    else
                    {
                        Error("Se esperaba que se utilizara > para cerrar " + stringpill);
                    }
                    break;

                default: break;
            }
        }

        //-------------------------------------------------------- AUTOMATA PATTERS--------------------------------------------------------
        public void Automata_Patters()
        {
            switch (estado)
            {
                case 0:
                     if (lex == ">")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Se esperaba que se cerrara Patterns >");
                    }
                    break;

                case 1:
                    if (lex == "<")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Falto Apertura de Sub Item");
                    }
                    break;

                case 2:
                    if (token.Contains("IT_"))
                    {
                        estado = 0;
                        Items_Patterns(lex);
                    }
                    else if (lex == "/")
                    {
                            estado = 3;                
                    }
                    else
                    {
                        Error("Se esperaba que se cerrara Patterns o no se reconoce el sub item");
                    }
                    break;


                case 3:
                    if (lex == "patterns")
                    {
                        estado = 4;
                    }
                    else
                    {
                        Error("Error en cerrar patterns");
                    }
                    break;

                case 4:
                    if (lex == ">")
                    {
                        estado = 3;
                        patterns = false;
                        xml = true;
                    }
                    else
                    {
                        Error("hizo falta cerrar Patterns");
                    }
                    break;

                default: break;
            }
        }

        public void Items_Patterns(String objeto)
        {
            if (objeto == "pattern")
            {
                estado = 0;
                pattern = true;
                patterns = false;
            }
            else
            {
                Error("No se Reconoce el sub item para Patterns");
            }
        }

        public void SubAutomata_pattern()
        {
            switch (estado)
            {

                case 0:
                    if (lex == "name")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("hace falta el atributo name en pattern");
                    }
                    break;


                case 1:
                    if (lex == "=")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Hace falta = en pattern");
                    }
                    break;


                case 2:
                    if (lex == "\"")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Hace falta \" en patterns");
                    }
                    break;


                case 3:
                    if (token == "TX_Cadena")
                    {
                        estado = 4;
                    }
                    else
                    {
                        Error("Se esperaba una cadena de texto");
                    }
                    break;



                case 4:
                    if (lex == "\"")
                    {
                        estado = 5;
                    }
                    else
                    {
                        Error("Hace falta \" en patterns");
                    }
                    break;



                case 5:
                    if (lex == ">")
                    {
                        estado = 6;
                    }
                    else
                    {
                        Error("Se esperaba >");
                    }
                    break;

                case 6:
                    if (lex == "<")
                    {
                        estado = 7;
                    }
                    else
                    {
                        Error("Se esperaba <");
                    }
                    break;

                case 7:
                    if (lex == "movement")
                    {
                        estado = 8;
                    }
                    else if (lex == "/")
                    {
                        estado = 14;
                    }
                    else
                    {
                        Error("Se esperaba movement o que se cerrara pattern");
                    }
                    break;


                case 8:
                    if (lex == ">")
                    {
                        estado = 9;
                    }
                    else if (lex == "/")
                    {
                            estado = 13;                     
                    }
                    else
                    {
                        Error("Se esperana que se cerrara >");
                    }
                    break;

                case 9:
                    if(lex=="UP" || lex=="DOWN" || lex=="LEFT" || lex == "RIGHT")
                    {
                        estado = 10;
                    }
                    else
                    {
                        Error("No se reconoce el valor se esperaba un string");
                    }
                    break;

                case 10:
                    if (lex == "<")
                    {
                        estado = 11;
                    }
                    else
                    {
                        Error("Se esperaba  <");
                    }
                    break;


                case 11:
                    if (lex == "/")
                    {
                        estado = 12;
                    }
                    else
                    {
                        Error("Se esperaba /");
                    }
                    break;


                case 12:
                    if (lex == "movement")
                    {
                        estado = 13;
                    }
                    else
                    {
                        Error("Se esperaba movement");
                    }
                    break;


                case 13:
                    if (lex == ">")
                    {
                        estado = 6;
                    }
                    else
                    {
                        Error("Se esperaba >");
                    }
                    break;


                case 14:
                    if (lex == "pattern")
                    {
                        estado = 15;
                    }
                    else
                    {
                        Error("Se esperaba pattern");
                    }
                    break;


                case 15:
                    if (lex == ">")
                    {
                        estado = 1;
                        pattern = false;
                        patterns = true;
                    }
                    else
                    {
                        Error("Se esperaba >");
                    }
                    break;
                default:break;
            }
        }

        //---------------------------------------------------------AUTOMATA Monster------------------------------------------------------
        public void Automata_Monster()
        {
            switch (estado)
            {

                case 0:
                    if (Atributo_Monster(lex) == true)
                    {
                        estado = 0;
                        atrimonster = true;
                        monsters = false;
                    }
                    else if (lex == ">")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("No se reconoce el atributo");
                    }
                    break;

                case 2:
                    if (lex == "<")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba <");
                    }
                    break;

                case 3:
                    if (lex == "monster")
                    {
                        estado = 4;
                    }
                    else
                    {
                        Error("No se reconoce el subitem");
                    }
                    break;

                case 4:
                    if (Atributo_Monster(lex) == true)
                    {
                        estado = 0;
                        monster = true;
                        monsters = false;
                    }
                    else if (lex == ">")
                    {
                        estado = 8;
                    }
                    else
                    {
                        Error("No se reconoce el atributo");
                    }
                    break;

                case 8:
                    if (lex == "<")
                    {
                        estado = 9;
                    }
                    else
                    {
                        Error("Se esperaba <");
                    }
                    break;

                case 9:
                    if (lex == "movements")
                    {
                        estado = 10;
                    }
                    else
                    {
                        Error("Se esperaba movements");
                    }
                    break;

                case 10:
                    if (lex == ">")
                    {
                        estado = 11;
                    }
                    else
                    {
                        Error("Se esperaba >");
                    }
                    break;


                case 11:
                    if (token == "TX_Cadena")
                    {
                        estado = 12;
                    }
                    else
                    {
                        Error("Se esperaba una cadena de texto");
                    }
                    break;


                case 12:
                    if (lex == "<")
                    {
                        estado = 13;
                    }
                    else
                    {
                        Error("Se esperaba <");
                    }
                    break;

                case 13:
                    if (lex == "/")
                    {
                        estado = 14;
                    }
                    else
                    {
                        Error("Se esperaba /");
                    }
                    break;

                case 14:
                    if (lex == "movements")
                    {
                        estado = 15;
                    }
                    else
                    {
                        Error("Se esperaba movements");
                    }
                    break;


                case 15:
                    if (lex == ">")
                    {
                        estado = 16;
                    }
                    else
                    {
                        Error("Se esperaba >");
                    }
                    break;


                case 16:
                    if (lex == "<")
                    {
                        estado = 17;
                    }
                    else
                    {
                        Error("se esperaba <");
                    }
                    break;

                case 17:
                    if (lex == "X" || lex=="Y")
                    {
                        estado = 0;
                        itemmonster = true;
                        monsters = false;
                    }
                    else if (lex == "/")
                    {
                        estado = 18;
                    }
                    else
                    {
                        Error("Se esperaba una coordenada o se esperaba /");
                    }
                    break;

                case 18:
                    if (lex == "monster")
                    {
                        estado = 19;
                    }
                    else
                    {
                        Error("se esperaba mosnter");
                    }
                    break;

                case 19:
                    if (lex == ">")
                    {
                        estado = 20;
                    }
                    else
                    {
                        Error("Se esperaba >");
                    }
                    break;

                case 20:
                    if (lex == "<")
                    {
                        estado = 21;
                    }
                    else
                    {
                        Error("se esperaba <");
                    }
                    break;

                case 21:
                    if (lex == "monster")
                    {
                        estado = 4;
                    }
                    else if (lex == "/")
                    {
                        estado = 22;
                    }
                    else
                    {
                        Error("se esperaba monster o /");
                    }
                    break;

                case 22:
                    if (lex == "monsters")
                    {
                        estado = 23;
                    }
                    else
                    {
                        Error("Se esperaba monsters");
                    }
                    break;

                case 23:
                    if (lex == ">")
                    {
                        estado = 3;
                        monsters = false;
                        xml = true;
                    }
                    else
                    {
                        Error("se esperaba > que cerrar monsters");
                    }
                    break;

                default:break;
            }
        }

        public Boolean Atributo_Monster(String objeto)
        {
            if (objeto == "texture" || objeto == "damage")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SubAutomata_Monster()
        {
            switch (estado)
            {
                case 0:
                    if (lex == "=")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Hace falta = en atributo");
                    }
                    break;

                case 1:
                    if (lex == "\"")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Hace falta \" en atributo");
                    }
                    break;

                case 2:
                    if (token == "TX_Cadena" || token == "TXT_Number")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba una cadena de texto");
                    }
                    break;

                case 3:
                    if (lex == "\"")
                    {
                        estado = 0;
                        atrimonster = false;
                        monsters = true;
                    }
                    else
                    {
                        Error("Se esperaba \" en atributo  ");
                    }
                    break;

                default: break;
            }
        }

        public void SubAutomata_mons()
        {
            switch (estado)
            {
                case 0:
                    if (lex == "=")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Hace falta = en atributo");
                    }
                    break;

                case 1:
                    if (lex == "\"")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Hace falta \" en atributo");
                    }
                    break;

                case 2:
                    if (token == "TX_Cadena" || token == "TXT_Number")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba una cadena de texto");
                    }
                    break;

                case 3:
                    if (lex == "\"")
                    {
                        estado = 4;
                        monster = false;
                        monsters = true;
                    }
                    else
                    {
                        Error("Se esperaba \" en atributo  ");
                    }
                    break;

                default: break;
            }
        }

        public void Automata_ItemMonster()
        {
            switch (estado)
            {

                case 0:
                    if (lex == ">")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Se esperaba >");
                    }
                    break;

                case 1:
                    if (token == "TXT_Number")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Se esperaba un numero");
                    }
                    break;

                case 2:
                    if (lex == "<")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("se esperaba <");
                    }
                    break;

                case 3:
                    if (lex == "/")
                    {
                        estado = 4;
                    }
                    else
                    {
                        Error("se esperaba /");
                    }
                    break;

                case 4:
                    if(lex=="X" || lex == "Y")
                    {
                        estado = 5;
                    }
                    else
                    {
                        Error("Se esperaba una coordenada");
                    }
                    break;

                case 5:
                    if (lex == ">")
                    {
                        estado = 16;
                        itemmonster = false;
                        monsters = true;
                    }
                    else
                    {
                        Error("se esperaba >");
                    }
                    break;


                default:break;
            }
        }


        //---------------------------------------------------------------OTROS-------------------------------------------------------------


        public void SubAutomata_contadores()
        {
            switch (estado)
            {

                case 0:
                    if (lex == ">")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Se esperaba que se cerrara > en " + subitecha);
                    }
                    break;

                case 1:
                    if(token== "TXT_Number")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Se esperaba un numero");
                    }
                    break;

                case 2:
                    if (lex == "<")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba < en "+ subitecha);
                    }
                    break;

                case 3:
                    if (lex == "/")
                    {
                        estado = 4;
                    }
                    else
                    {
                        Error("Se esperaba / en " + subitecha);
                    }
                    break;


                case 4:
                    if (lex == subitecha)
                    {
                        estado = 5;
                    }
                    else
                    {
                        Error("Se esperaba que se cerrara " + subitecha);
                    }
                    break;

                case 5:
                    if (lex == ">")
                    {
                        Object[] datos = (Object[])lista_padre[0];
                        estado = (int)datos[1];
                        Redireccionar((String)datos[0]);
                    }
                    else
                    {
                        Error("Se esperaba que se utilizara > para cerrar " + subitecha);
                    }
                    break;

                default:break;
            }
        }


        public void SubAutomata_Stats()
        {
            switch (estado)
            {

                case 0:
                    if (lex == ">")
                    {
                        estado = 1;
                    }
                    else
                    {
                        Error("Se esperaba que se cerrara > en " + subitecha);
                    }
                    break;

                case 1:
                    if (token == "TX_Cadena")
                    {
                        estado = 2;
                    }
                    else
                    {
                        Error("Se esperaba una cadena de texto");
                    }
                    break;

                case 2:
                    if (lex == "<")
                    {
                        estado = 3;
                    }
                    else
                    {
                        Error("Se esperaba < en " + subitecha);
                    }
                    break;

                case 3:
                    if (lex == "/")
                    {
                        estado = 4;
                    }
                    else
                    {
                        Error("Se esperaba / en " + subitecha);
                    }
                    break;


                case 4:
                    if (lex == subitecha)
                    {
                        estado = 5;
                    }
                    else
                    {
                        Error("Se esperaba que se cerrara " + subitecha);
                    }
                    break;

                case 5:
                    if (lex == ">")
                    {
                        Object[] datos = (Object[])lista_padre[0];
                        estado = (int)datos[1];
                        Redireccionar((String)datos[0]);
                    }
                    else
                    {
                        Error("Se esperaba que se utilizara > para cerrar " + subitecha);
                    }
                    break;

                default: break;
            }
        }




        //-------------------------------------Redireccionar Character-------------------------------------------

        public void Items_Character(String objeto)
        {
                if(objeto== "hearts" || objeto == "coins" || objeto == "bombs" || objeto == "keys")
                {

                    hearts = true;
                    character = false;
                    subitecha = objeto;
                    Object[] padre = new Object[] { "character", 1 };
                    lista_padre.Insert(0, padre);
                }
            else if(objeto== "item")
            {
                subitecha = "item";
                Object[] padre = new Object[] { "character", 1 };
                lista_padre.Insert(0, padre);
                item = true;
                character = false;
            }
            else
            {
                Error("Sub Item no permitido en Character");
            }
            
        }





        //-----------------------------------para los errores-------------------------------------
        public void Error(String mensaje)
        {
            Object[] datas = new Object[] { lex, data[1], data[2], "PK_ERROR", mensaje };
            Console.Write(data[1]+" "+data[2]);
            Console.Write(mensaje);
            lista_errores.Add(datas);
            estado = 10000;
            xml = false;
            character = false;
            monsters = false;
            patterns = false;
            room = false;
            look = false;
            posX = false;
            hearts = false;
            item = false;
            atriroom = false;
            enviroment = false;
            rock = false;

        }


        

        //---------------------------------------Redirecciona Todos----------------------------------------------------------------------------------
        public void Redireccionar(String objeto)
        {
            if (objeto == "character")
            {
                monsters = false;
                patterns = false;
                character = true;
                xml = false;
                room = false;
                lista_padre.RemoveAt(0);
            }
            else if (objeto == "room")
            {
                monsters = false;
                patterns = false;
                room = true;
                character = false;
                xml = false;
                lista_padre.RemoveAt(0);
            }
            else if (objeto == "patterns")
            {
                monsters = false;
                patterns = true;
                character = false;
                room = false;
                xml = false;
                lista_padre.RemoveAt(0);
            }
            else if (objeto == "monsters")
            {
                monsters = true;
                patterns = false;
                character = false;
                room = false;
                xml = false;
                lista_padre.RemoveAt(0);

            }
            else if (objeto == "stats")
            {
                estado = 5;
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
