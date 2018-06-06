using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorJson.INTERFACES
{
    interface Campo_Jugador
    {

        //---------------------------------------------------Imagen de Jugador---------------------------------------------------------------
        void set_jugador(String path);
        String get_jugador();


        //--------------------------------------------------Posicion en X y en Y del Jugador--------------------------------------------------
        void set_posX(int posX);
        int get_posX();

        void set_posy(int posY);
        int get_posy();

        //--------------------------------------------------tamaño de la ventana y color de fondo---------------------------------------------
        void set_width(int width);
        int get_width();

        void set_height(int height);
        int get_height();

        void set_color(String color);
        String get_color();

        void set_name(String name);
        String get_name();

        //--------------------------------------------------vidas coins bombas  keys----------------------------------------
        void set_bombas(int bombas);
        int get_bombas();

        void set_coins(int coins);
        int get_coins();

        void set_lifes(int lifes);
        int get_lifes();

        void set_keys(int key);

        int get_keys();

        //----------------------------------------------item imagen----------------------------------------
        void set_item(String ubicacion);
        String get_item();

        //---------------------------------------------ROCK-------------------------------------------------
        void set_pathrock(String ubicacion);
        String get_pathrock();

        void set_posxrock(int posx);
        int get_posxrock();

        void set_posyrock(int posy);
        int get_posyrock();

        void set_rock(ArrayList rock);
        ArrayList get_rock();

        //---------------------------------------------Spike-------------------------------------------------
        void set_pathspike(String ubicacion);
        String get_pathspike();

        void set_posxspike(int posx);
        int get_posxspike();

        void set_posyspike(int posy);
        int get_posyspike();

        void set_spike(ArrayList spike);
        ArrayList get_spike();

        //---------------------------------------------Exit------------------------------------------------------
        void set_textureExit(String path);
        String get_textureExit();

        void set_posXExit(int x);
        int get_posXExit();

        void set_posYExit(int y);
        int get_posYExit();

        //-----------------------------------------------Heart---------------------------------------------------
        ArrayList get_corazones();
        void set_corazones(ArrayList heart);

        int get_posXheart();
        void set_posXhear(int x);

        int get_posYheart();
        void set_posYheart(int y);

        String get_pathheart();
        void set_pathheart(String path);

        //-------------------------------------Bomb-----------------------------------------------------------
        ArrayList get_bomb();
        void set_bomas(ArrayList heart);

        int get_posXbombas();
        void set_posXbombas(int x);

        int get_posYbombas();
        void set_posYbombas(int y);

        String get_pathbombas();
        void set_pathbombas(String path);

        //-------------------------------------Coin-----------------------------------------------------------
        ArrayList get_coin();
        void set_coin(ArrayList heart);

        int get_posXcoin();
        void set_posXcoin(int x);

        int get_posYcoin();
        void set_posYcoin(int y);

        String get_pathcoin();
        void set_pathcoin(String path);

        //-------------------------------------key-----------------------------------------------------------
        ArrayList get_key();
        void set_key(ArrayList heart);

        int get_posXkey();
        void set_posXkey(int x);

        int get_posYkey();
        void set_posYkey(int y);

        String get_pathkey();
        void set_pathkey(String path);


        //-------------------------------------items-----------------------------------------------------------
        ArrayList get_items();
        void set_item(ArrayList heart);

        int get_posXitem();
        void set_posXitem(int x);

        int get_posYitem();
        void set_posYitem(int y);

        String get_pathitem();
        void set_pathitem(String path);
    }
}
