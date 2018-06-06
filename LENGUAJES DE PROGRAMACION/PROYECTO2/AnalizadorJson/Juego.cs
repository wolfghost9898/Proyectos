using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorJson
{
    class Juego
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
        //----------------------------------------------------Caracter---------------------------------------------
        private String tipoPos;
        private String itemCa;
        //-----------------------------------------------------room-----------------------------------------------
        private String tipoRoom;
        //------------------------------------------------------exit---------------------------------------------
        private String tipoexit;
        //------------------------------------------------------rock----------------------------------------------
        private String atriroc;
        private String posroc;
        private int xinicio = 0;
        private int yinicio = 0;
        private int xfin = 0;
        private int yfin = 0;
        private Boolean coma;

        //-----------------------------------------------------heart--------------------------------------------
        private String tipoheart;
        //-----------------------------------------------------bomb--------------------------------------------
        private String tipobomb;

        private INTERFACES.Campo_JugadorHe campojugador;



        public Juego(ArrayList lista_lexema, ArrayList lista_token)
        {
            this.lista_lexema = lista_lexema;
            this.lista_token = lista_token;
            campojugador = new INTERFACES.Campo_JugadorHe();
            campojugador.Dispose();
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
            TraducirJuego();
    }


        public void TraducirJuego() {
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
                        llaves_abiertas++;
                        estado = 1;
                    break;
                //------------------------------------------------------------------------
                case 1:
                        estado = 2;
                        cerrar_etiquetas.Insert(0, "xml");
                    break;
                //-------------------------------------------------------------------------
                case 2:
                        estado = 3;
                    break;
                //-------------------------------------------------------------------------
                case 3:
                        Object[] padre = new Object[] { "xml", 4 };
                        lista_padre.Insert(0, padre);
                        estado = 4;
                    break;
                //-------------------------------------------------------------------------------------
                case 4:
                    Redireccionar_xml(lex);
                    break;

                //--------------------------------------------------------------------------------------
                case 5:
                        estado = 6;
                    break;
                //-------------------------------------------------------------------------------------
                case 6:
                        cerrar_etiquetas.RemoveAt(0);
                        lista_padre.RemoveAt(0);
                        estado = 500;
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
                        estado = 0;
                        if (lex == "look")
                        {
                            character = false;
                            look = true;
                        }
                        else if (lex == "posX")
                        {
                            tipoPos = "posX";
                            posX = true;
                            character = false;
                        }
                        else if (lex == "posY")
                        {
                            tipoPos = "posY";
                            posX = true;
                            character = false;
                        }
                    }
                    else if (lex == ">")
                    {
                            estado = 1;
                    }
                     break;

                case 1:
                        hearts = false;
                        item = false;
                    estado = 2;
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
                    break;


                case 3://----------------------------------caracter------------------------------------------------------
                        estado = 4;
                    break;

                case 4://-------------------------------------------------------------->---------------------------------
                        cerrar_etiquetas.RemoveAt(0);
                        estado = 3;
                        hearts = false;
                        item = false;
                        character = false;
                        xml = true;
                    break;

                default:
                    break;
            }
        }

        public void SubAutomata_Look()
        {
            switch (estado)
            {
                case 0: //--------------------------------------=--------------------
                        estado = 1;
                    break;

                case 1: //------------------------------"--------------------------
                        estado = 2;
                    break;

                case 2: //--------------------------------------------------cadena de texto
                        estado = 3;
                        campojugador.set_jugador(lex);
                    break;

                case 3: //--------------------------------"----------------------------------
                        estado = 0;
                        look = false;
                    character = true;
                    break;

                default: break;
            }
        }

        public void SubAutomata_posX()
        {
            switch (estado)
            {
                case 0: //-------------------------------------=------------------------------------
                        estado = 1;
                    break;

                case 1://----------------------------------------------------"------------------------------------------
                        estado = 2;                 
                    break;

                case 2: //----------------------------------------------------valor------------------------------------------------
                    if (token == "TXT_Number")
                    {
                        int posX = Convert.ToInt32(lex);
                        if (tipoPos == "posX")
                        {                          
                            campojugador.set_posX(posX);
                        }
                        else
                        {
                            campojugador.set_posy(posX);
                        }
                    }
                    estado = 3;
                    break;

                case 3://------------------------------------------------------"--------------------------------------------------
                        estado = 0;
                        posX = false;
                        character = true;
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

        public void SubAutomata_contadores()
        {
            switch (estado)
            {

                case 0://--------------------------------------------------------------->-----
                        estado = 1;
                    break;

                case 1:
                    if (token == "TXT_Number")
                    {
                        int cant = Convert.ToInt32(lex);
                        if (itemCa == "hearts")
                        {
                            campojugador.set_lifes(cant);
                        }
                        if (itemCa == "coins")
                        {
                            campojugador.set_coins(cant);
                        }
                        if (itemCa == "bombs")
                        {
                            campojugador.set_bombas(cant);
                        }
                        if (itemCa == "keys")
                        {
                            campojugador.set_keys(cant);
                        }
                       
                    }
                    estado = 2;
                    break;

                case 2://------------------------------------<----------------------------------
                        estado = 3;
                    break;

                case 3://------------------------------------"---------------------------------
                        estado = 4;
                    break;


                case 4://-------------------------------------------------------------------------
                        estado = 5;
                    break;

                case 5://------------------------------->------------------------------------------
                        Object[] datos = (Object[])lista_padre[0];
                        estado = (int)datos[1];
                        Redireccionar((String)datos[0]);
                    break;

                default: break;
            }
        }


        public void Items_Character(String objeto)
        {
            itemCa = objeto;
            if (objeto == "hearts" || objeto == "coins" || objeto == "bombs" || objeto == "keys")
            {
                hearts = true;
                character = false;
                subitecha = objeto;
                Object[] padre = new Object[] { "character", 1 };
                lista_padre.Insert(0, padre);
            }
            else if (objeto == "item")
            {
                subitecha = "item";
                Object[] padre = new Object[] { "character", 1 };
                lista_padre.Insert(0, padre);
                item = true;
                character = false;
            }

        }

        public void SubAutomata_Stats()
        {
            switch (estado)
            {

                case 0://--------------------------------------------->-------------------------------
                      estado = 1;
                    break;

                case 1:
                    if (token == "TX_Cadena")
                    {
                        if (itemCa == "item")
                        {
                            campojugador.set_item(lex);
                        }
                    }
                    estado = 2;
                    break;

                case 2://--------------------------------------<---------------------------------------------
                        estado = 3;
                    break;

                case 3://------------------------------------------"---------------------------------------------
                        estado = 4;
                    break;


                case 4:
                        estado = 5;
                    break;

                case 5://-------------------------------------->------------------------------------------------
                        Object[] datos = (Object[])lista_padre[0];
                        estado = (int)datos[1];
                        Redireccionar((String)datos[0]);
                    break;

                default: break;
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
                    break;

                case 1://---------------------------------------<
                        estado = 2;
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
                    }
                    break;


                case 3:
                        estado = 4;
                    break;

                case 4:
                        estado = 3;
                        room = false;
                        xml = true;
                    break;

                default: break;
            }

        }

        public void SubAutomata_Room()
        {
            switch (estado)
            {
                case 0://-------------------------------------------=-------------------------------------------------------
                        estado = 1;
                    break;

                case 1://-------------------------------------------"-------------------------------------------------------------
                        estado = 2;
                    break;

                case 2:
                    if (token == "TX_Cadena")
                    {
                        if (tipoRoom == "name")
                        {
                            campojugador.set_name(lex);
                        }
                        if (tipoRoom == "color")
                        {
                            campojugador.set_color(lex);
                        }
                    }
                    else if (token == "TXT_Number")
                    {
                        int medida = Convert.ToInt32(lex);
                        if (tipoRoom == "width")
                        {
                            campojugador.set_width(medida);
                        }
                        if(tipoRoom== "height")
                        {
                            campojugador.set_height(medida);
                        }

                        int x = campojugador.get_width();
                        int y = campojugador.get_height();
                    }
                    estado = 3;
                    break;

                case 3://-------------------------------------------"------------------------------------------------------------------
                        estado = 0;
                        atriroom = false;
                        room = true;
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
        }

        public Boolean Atributo_Room(String Objeto)
        {
            if (Objeto == "width" || Objeto == "height" || Objeto == "color" || Objeto == "name")
            {
                tipoRoom = Objeto;
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
                case 0://------------------------------------------------------------>--------------------------------------------------------------------------------
                        estado = 1;
                    break;

                case 1:
                        estado = 2;
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
                    break;


                case 3:
                    if (lex == "enviroment")
                    {
                        estado = 4;
                    }
                    break;

                case 4:
                        estado = 1;
                        room = true;
                        enviroment = false;                
                    break;

                default: break;
            }

        }

        public void Items_Enviroment(String objeto)
        {
            if (objeto == "rock")
            {
                xfin = 0;
                yfin = 0;
                estado = 0;
                rock = true;
                enviroment = false;
            }
            else if (objeto == "spike")
            {
                xfin = 0;
                yfin = 0;
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
                        int posx = campojugador.get_posxrock();
                        int posy = campojugador.get_posyrock();
                        String path = campojugador.get_pathrock();
                        ArrayList rocas = new ArrayList();
                        rocas = campojugador.get_rock();
                        Object[] rocas_ins = new Object[3];
                        rocas_ins[0] = posx;
                        rocas_ins[1] = posy;
                        rocas_ins[2] = path;
                        rocas.Add(rocas_ins);
                        campojugador.set_rock(rocas);
                        estado = 3;
                    }
                    break;

                case 1:
                        estado = 2;
                    break;

                case 2:
                    if (token.Contains("IT_"))
                    {
                        estado = 0;
                        coma = false;
                        posroc = "";
                        if (lex == "X" || lex == "Y")
                        {
                            posroc = lex;
                            posrock = true;
                            rock = false;
                        }

                    }
                    else if (lex == "/")
                    {
                        if (posroc == "X" && xfin != 0)
                        {
                            for (int jj = xinicio; jj <= xfin; jj++)
                            {
                                int posx = jj;
                                int posy = yinicio;
                                String path = campojugador.get_pathrock();
                                ArrayList rocas = new ArrayList();
                                rocas = campojugador.get_rock();
                                Object[] rocas_ins = new Object[3];
                                rocas_ins[0] = posx;
                                rocas_ins[1] = posy;
                                rocas_ins[2] = path;
                                rocas.Add(rocas_ins);
                                campojugador.set_rock(rocas);
                            }
                        }
                        else if (posroc == "X" && xfin == 0)
                        {
                            for (int jj = yinicio; jj <= yfin; jj++)
                            {
                                int posx = xinicio;
                                int posy = jj;
                                String path = campojugador.get_pathrock();
                                ArrayList rocas = new ArrayList();
                                rocas = campojugador.get_rock();
                                Object[] rocas_ins = new Object[3];
                                rocas_ins[0] = posx;
                                rocas_ins[1] = posy;
                                rocas_ins[2] = path;
                                rocas.Add(rocas_ins);
                                campojugador.set_rock(rocas);
                            }
                        }
                        else if (posroc == "Y" && yfin == 0)
                        {
                            for (int jj = xinicio; jj <= xfin; jj++)
                            {
                                int posx = jj;
                                int posy = yinicio;
                                String path = campojugador.get_pathrock();
                                ArrayList rocas = new ArrayList();
                                rocas = campojugador.get_rock();
                                Object[] rocas_ins = new Object[3];
                                rocas_ins[0] = posx;
                                rocas_ins[1] = posy;
                                rocas_ins[2] = path;
                                rocas.Add(rocas_ins);
                                campojugador.set_rock(rocas);
                            }
                        }
                        else if (posroc == "Y" &&  yfin!=0)
                        {
                            for (int jj = yinicio; jj <= yfin; jj++)
                            {
                                int posx = xinicio;
                                int posy = jj;
                                String path = campojugador.get_pathrock();
                                ArrayList rocas = new ArrayList();
                                rocas = campojugador.get_rock();
                                Object[] rocas_ins = new Object[3];
                                rocas_ins[0] = posx;
                                rocas_ins[1] = posy;
                                rocas_ins[2] = path;
                                rocas.Add(rocas_ins);
                                campojugador.set_rock(rocas);
                            }
                        }

                        estado = 3;
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
                    break;

                case 4:
                        estado = 1;
                        rock = false;
                        enviroment = true;
                    break;

                default: break;
            }
        }

        public void SubAutomata_rock()
        {
            switch (estado)
            {
                case 0:
                        estado = 1;
                    break;

                case 1:
                        estado = 2;
                    break;

                case 2:
                    if (token == "TX_Cadena")
                    {
                        campojugador.set_pathrock(lex);
                    }
                    else if(token == "TXT_Number")
                    {
                        if (atriroc == "posX")
                        {
                            campojugador.set_posxrock(Convert.ToInt32(lex));
                        }
                        else
                        {
                            campojugador.set_posyrock(Convert.ToInt32(lex));
                        }
                    }
                    estado = 3;
                    break;

                case 3:
                        estado = 0;
                        atrirock = false;
                        rock = true;
                    break;

                default: break;
            }
        }

        public Boolean Atributo_rock(String objeto)
        {
            if (objeto == "texture" || objeto == "posX" || objeto == "posY")
            {
                atriroc = objeto;
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

                        estado = 1;
                    break;


                case 1:
                    if (token == "TXT_Number")
                    {
                        if (coma == false)
                        {
                            if (posroc == "X")
                            {
                                xinicio = Convert.ToInt32(lex);
                            }
                            else if(posroc=="Y")
                            {
                                yinicio = Convert.ToInt32(lex);
                            }
                        }
                        else
                        {
                            if (posroc == "X")
                            {
                                xfin = Convert.ToInt32(lex);
                            }
                            else if(posroc=="Y")
                            {
                                yfin = Convert.ToInt32(lex);
                            }
                        }
                        
                        
                    }
                    estado = 2;
                    break;


                case 2:
                    if (lex == "<")
                    {   
                        estado = 3;
                    }
                    else if (lex == ",")
                    {
                        estado = 1;
                        coma = true;
                    }
                    break;

                case 3:
                        if (coma == false)
                        {
                            if (posroc == "X")
                            {
                                campojugador.set_posxrock(xinicio);
                            }
                            else
                            {
                                campojugador.set_posyrock(yinicio);
                            }
                        }
                        estado = 4;                
                    break;


                case 4:
                        estado = 5;
                    break;


                case 5:

                        estado = 1;
                        posrock = false;
                        rock = true;
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
                        int posx = campojugador.get_posxspike();
                        int posy = campojugador.get_posyspike();
                        String path = campojugador.get_pathspike();
                        ArrayList spikes = new ArrayList();
                        spikes = campojugador.get_spike();
                        Object[] spikes_ins = new Object[3];
                        spikes_ins[0] = posx;
                        spikes_ins[1] = posy;
                        spikes_ins[2] = path;
                        spikes.Add(spikes_ins);
                        campojugador.set_spike(spikes);
                        estado = 3;
                    }

                    break;


                case 1:
                    estado = 2;
                    break;

                case 2:
                    if (token.Contains("IT_"))
                    {
                        estado = 0;
                        coma = false;
                        posroc = "";
                        if (lex == "X" || lex == "Y")
                        {
                            posroc = lex;
                            posspike = true;
                            spike = false;
                        }

                    }
                    else if (lex == "/")
                    {
                        if (posroc == "X" && xfin != 0)
                        {
                            for (int jj = xinicio; jj <= xfin; jj++)
                            {
                                int posx = jj;
                                int posy = yinicio;
                                String path = campojugador.get_pathspike();
                                ArrayList spikes = new ArrayList();
                                spikes = campojugador.get_spike();
                                Object[] spikes_ins = new Object[3];
                                spikes_ins[0] = posx;
                                spikes_ins[1] = posy;
                                spikes_ins[2] = path;
                                spikes.Add(spikes_ins);
                                campojugador.set_spike(spikes);
                            }
                        }
                        else if (posroc == "X" && xfin == 0)
                        {
                            for (int jj = yinicio; jj <= yfin; jj++)
                            {
                                int posx = xinicio;
                                int posy = jj;
                                String path = campojugador.get_pathspike();
                                ArrayList spikes = new ArrayList();
                                spikes = campojugador.get_spike();
                                Object[] spikes_ins = new Object[3];
                                spikes_ins[0] = posx;
                                spikes_ins[1] = posy;
                                spikes_ins[2] = path;
                                spikes.Add(spikes_ins);
                                campojugador.set_spike(spikes);
                            }
                        }
                        else if (posroc == "Y" && yfin == 0)
                        {
                            for (int jj = xinicio; jj <= xfin; jj++)
                            {
                                int posx = jj;
                                int posy = yinicio;
                                String path = campojugador.get_pathspike();
                                ArrayList spikes = new ArrayList();
                                spikes = campojugador.get_spike();
                                Object[] spikes_ins = new Object[3];
                                spikes_ins[0] = posx;
                                spikes_ins[1] = posy;
                                spikes_ins[2] = path;
                                spikes.Add(spikes_ins);
                                campojugador.set_spike(spikes);
                            }
                        }
                        else if (posroc == "Y" && yfin != 0)
                        {
                            for (int jj = yinicio; jj <= yfin; jj++)
                            {
                                int posx = xinicio;
                                int posy = jj;
                                String path = campojugador.get_pathspike();
                                ArrayList spikes = new ArrayList();
                                spikes = campojugador.get_spike();
                                Object[] spikes_ins = new Object[3];
                                spikes_ins[0] = posx;
                                spikes_ins[1] = posy;
                                spikes_ins[2] = path;
                                spikes.Add(spikes_ins);
                                campojugador.set_spike(spikes);
                            }
                        }

                        estado = 3;
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
                    break;

                case 4:
                        estado = 1;
                        spike = false;
                        enviroment = true;
                    break;

                default: break;
            }
        }

        public void SubAutomata_spike()
        {
            switch (estado)
            {
                case 0:
                        estado = 1;
                    break;

                case 1:
                        estado = 2;
                    break;

                case 2:
                    if (token == "TX_Cadena")
                    {
                        campojugador.set_pathspike(lex);
                    }
                    else if (token == "TXT_Number")
                    {
                        if (atriroc == "posX")
                        {
                            campojugador.set_posxspike(Convert.ToInt32(lex));
                        }
                        else
                        {
                            campojugador.set_posyspike(Convert.ToInt32(lex));
                        }
                    }
                    estado = 3;
                    break;

                case 3:
                        estado = 0;
                        atrispike = false;
                        spike = true;
                    break;

                default: break;
            }
        }

        public Boolean Atributo_spike(String objeto)
        {
            if (objeto == "texture" || objeto == "posX" || objeto == "posY")
            {
                atriroc = objeto;
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
                        estado = 1;
                    break;


                case 1:
                    if (token == "TXT_Number")
                    {
                        if (coma == false)
                        {
                            if (posroc == "X")
                            {
                                xinicio = Convert.ToInt32(lex);
                            }
                            else if (posroc == "Y")
                            {
                                yinicio = Convert.ToInt32(lex);
                            }
                        }
                        else
                        {
                            if (posroc == "X")
                            {
                                xfin = Convert.ToInt32(lex);
                            }
                            else if (posroc == "Y")
                            {
                                yfin = Convert.ToInt32(lex);
                            }
                        }
                    }
                    estado = 2;
                    break;


                case 2:
                    if (lex == "<")
                    {
                        estado = 3;
                    }
                    else if (lex == ",")
                    {
                        estado = 1;
                        coma = true;
                    }
                    break;

                case 3:
                        estado = 4;
                    break;


                case 4:
                        estado = 5;
                    break;


                case 5:
                       estado = 1;
                       posspike = false;
                       spike = true;
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
                        tipoexit = lex;
                        estado = 0;
                        exit = false;
                        atriexit = true;
                    }
                    else if (lex == "/")
                    {
                        estado = 3;
                    }
                    break;

                case 3:
                        estado = 1;
                        exit = false;
                        enviroment = true;
                    break;

                default: break;
            }
        }

        public void SubAutomata_exit()
        {
            switch (estado)
            {
                case 0:
                        estado = 1;
                    break;

                case 1:
                      estado = 2;
                    break;

                case 2:
                    if (token == "TX_Cadena") {
                        if (tipoexit == "texture")
                        {
                            campojugador.set_textureExit(lex);
                        }
                    }
                    else if (token == "TXT_Number")
                    {
                        if (tipoexit == "posX")
                        {
                            campojugador.set_posXExit(Convert.ToInt32(lex));
                        }
                        else
                        {
                            campojugador.set_posYExit(Convert.ToInt32(lex));
                        }

                    }
                    estado = 3;
                    break;

                case 3:
                       
                        estado = 0;
                        atriexit = false;
                        exit = true;
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
                        estado = 1;

                    break;

                case 1:
                        estado = 2;
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
                    
                    break;


                case 3:
                        estado = 4;
                    break;

                case 4:
                        estado = 1;
                        room = true;
                        consumables = false;
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
                    break;

                case 3:
                    int posx = campojugador.get_posXheart();
                    int posy = campojugador.get_posYheart();
                    String path = campojugador.get_pathheart();
                    ArrayList corazon = new ArrayList();
                    corazon = campojugador.get_corazones();
                    Object[] rocas_ins = new Object[3];
                    rocas_ins[0] = posx;
                    rocas_ins[1] = posy;
                    rocas_ins[2] = path;
                    corazon.Add(rocas_ins);
                    campojugador.set_corazones(corazon);
                       estado = 1;
                        heart = false;
                        consumables = true;
                    break;

                default: break;
            }
        }

        public void SubAutomata_heart()
        {
            switch (estado)
            {
                case 0:
                        estado = 1;
                    break;

                case 1:
                        estado = 2;
                    break;

                case 2:
                    if (token == "TX_Cadena")
                    {
                        campojugador.set_pathheart(lex);
                    }
                    else if(token == "TXT_Number")
                    {
                        if (tipoheart == "posX")
                        {
                            campojugador.set_posXhear(Convert.ToInt32(lex));
                        }
                        else
                        {
                            campojugador.set_posYheart(Convert.ToInt32(lex));
                        }
                    }
                    estado = 3;
                    break;

                case 3:
                        estado = 0;
                        atriheart = false;
                        heart = true;
                    break;

                default: break;
            }
        }

        public Boolean Atributo_heart(String objeto)
        {
            if (objeto == "texture" || objeto == "posX" || objeto == "posY")
            {
                tipoheart = objeto;
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
                    break;

                case 3:
                    int posx = campojugador.get_posXbombas();
                    int posy = campojugador.get_posYbombas();
                    String path = campojugador.get_pathbombas();
                    ArrayList bombas = new ArrayList();
                    bombas = campojugador.get_bomb();
                    Object[] rocas_ins = new Object[3];
                    rocas_ins[0] = posx;
                    rocas_ins[1] = posy;
                    rocas_ins[2] = path;
                    bombas.Add(rocas_ins);
                    campojugador.set_bomas(bombas);
                    estado = 1;
                        bomb = false;
                        consumables = true;
                    break;

                default: break;
            }
        }

        public void SubAutomata_bomb()
        {
            switch (estado)
            {
                case 0:
                        estado = 1;
                    break;

                case 1:
                        estado = 2;
                    break;

                case 2:
                    if (token == "TX_Cadena")
                    {
                        campojugador.set_pathbombas(lex);
                    }
                    else if( token == "TXT_Number")
                    {
                        if (tipobomb == "posX")
                        {
                            campojugador.set_posXbombas(Convert.ToInt32(lex));
                        }
                        else
                        {
                            campojugador.set_posYbombas(Convert.ToInt32(lex));
                        }
                    }
                    estado = 3;
                    break;

                case 3:
                        estado = 0;
                        atribomb = false;
                        bomb = true;
                    break;

                default: break;
            }
        }

        public Boolean Atributo_bomb(String objeto)
        {
            if (objeto == "texture" || objeto == "posX" || objeto == "posY")
            {
                tipobomb = objeto;
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
                    break;

                case 3:
                    int posx = campojugador.get_posXcoin();
                    int posy = campojugador.get_posYcoin();
                    String path = campojugador.get_pathcoin();
                    ArrayList coins = new ArrayList();
                    coins = campojugador.get_coin();
                    Object[] rocas_ins = new Object[3];
                    rocas_ins[0] = posx;
                    rocas_ins[1] = posy;
                    rocas_ins[2] = path;
                    coins.Add(rocas_ins);
                    campojugador.set_coin(coins);
                    estado = 1;
                        coin = false;
                        consumables = true;
 
                    break;

                default: break;
            }
        }

        public void SubAutomata_coin()
        {
            switch (estado)
            {
                case 0:
                        estado = 1;
                    break;

                case 1:
                        estado = 2;
                    break;

                case 2:
                    if (token == "TX_Cadena")
                    {
                        campojugador.set_pathcoin(lex);
                    }
                    else if(token == "TXT_Number")
                    {
                        if (tipobomb == "posX")
                        {
                            campojugador.set_posXcoin(Convert.ToInt32(lex));
                        }
                        else
                        {
                            campojugador.set_posYcoin(Convert.ToInt32(lex));

                        }
                    }
                    estado = 3;
                    break;

                case 3:

                        estado = 0;
                        atricoin = false;
                        coin = true;
                   
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
                    break;

                case 3:
                    int posx = campojugador.get_posXkey();
                    int posy = campojugador.get_posYkey();
                    String path = campojugador.get_pathkey();
                    ArrayList keys = new ArrayList();
                    keys = campojugador.get_key();
                    Object[] rocas_ins = new Object[3];
                    rocas_ins[0] = posx;
                    rocas_ins[1] = posy;
                    rocas_ins[2] = path;
                    keys.Add(rocas_ins);
                    campojugador.set_key(keys);
                    estado = 1;
                        key = false;
                        consumables = true;
                   
                    break;

                default: break;
            }
        }

        public void SubAutomata_key()
        {
            switch (estado)
            {
                case 0:
                        estado = 1;
                    break;

                case 1:
                        estado = 2;
                    break;

                case 2:
                    if (token == "TX_Cadena")
                    {
                        campojugador.set_pathkey(lex);
                    }
                    else if (token == "TXT_Number")
                    {
                        if (tipobomb == "posX")
                        {
                            campojugador.set_posXkey(Convert.ToInt32(lex));
                        }
                        else
                        {
                            campojugador.set_posYkey(Convert.ToInt32(lex));

                        }
                    }
                    estado = 3;
                    break;

                case 3:
                        estado = 0;
                        atrikey = false;
                        key = true;
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
                    break;

                case 3:
                    int posx = campojugador.get_posXitem();
                    int posy = campojugador.get_posYitem();
                    String path = campojugador.get_pathitem();
                    ArrayList items = new ArrayList();
                    items = campojugador.get_items();
                    Object[] rocas_ins = new Object[3];
                    rocas_ins[0] = posx;
                    rocas_ins[1] = posy;
                    rocas_ins[2] = path;
                    items.Add(rocas_ins);
                    campojugador.set_item(items);
                    estado = 1;
                        itemC = false;
                        consumables = true;
                    break;

                default: break;
            }
        }

        public void SubAutomata_item()
        {
            switch (estado)
            {
                case 0:
                        estado = 1;                   
                    break;

                case 1:
                        estado = 2;
                    break;

                case 2:
                    if (token == "TX_Cadena")
                    {
                        campojugador.set_pathitem(lex);
                    }
                    else if (token == "TXT_Number")
                    {
                        if (tipobomb == "posX")
                        {
                            campojugador.set_posXitem(Convert.ToInt32(lex));
                        }
                        else
                        {
                            campojugador.set_posYitem(Convert.ToInt32(lex));

                        }
                    }
                    estado = 3;
                    break;

                case 3:
                        estado = 0;
                        atriitemC = false;
                        itemC = true;
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
            if (objeto == "action" || objeto == "value" || objeto == "stat")
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
                        if (lex == "SUMAR" || lex == "RESTAR" || lex == "MULTIPLICAR" || lex == "DIVIDIR")
                        {
                            estado = 2;
                        }
                        else
                        {
                            Error("No se permite ese valor en Action");
                        }
                    }
                    else if (stringpill == "stat")
                    {
                        if (lex == "hearts" || lex == "coins" || lex == "bombs" || lex == "keys" || lex == "damage" || lex == "range" || lex == "luck")
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
                    if (lex == "UP" || lex == "DOWN" || lex == "LEFT" || lex == "RIGHT")
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
                default: break;
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
                    if (lex == "X" || lex == "Y")
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

                default: break;
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
                    if (lex == "X" || lex == "Y")
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


                default: break;
            }
        }




  


   





       





        //-----------------------------------para los errores-------------------------------------
        public void Error(String mensaje)
        {
            Object[] datas = new Object[] { lex, data[1], data[2], "PK_ERROR", mensaje };
            Console.Write(data[1] + " " + data[2]);
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
    





    }
}
