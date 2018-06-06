using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorJson.INTERFACES
{
    class Campo_JugadorHe : Campo_Jugador
    {
        private static String path1;
        private static int posX1;
        private static int posY1;

        private static int width1;
        private static int height1;
        private static String color1;
        private static String name1;

        private static int vidas;
        private static int fichas;
        private static int bomba;
        private static int llave;
        private static String item;

        private static int posX1rock;
        private static int posY1rock;
        private static String pathrock;
        private static ArrayList rocas = new ArrayList();

        private static int posX1spike;
        private static int posY1spike;
        private static String pathspike;
        private static ArrayList spikes = new ArrayList();


        private static String pathExit;
        private static int posXExit;
        private static int posYExit;

        private static ArrayList corazones = new ArrayList();
        private static String pathCorazon;
        private static int posXHeart;
        private static int posYHeart;

        private static ArrayList bombas = new ArrayList();
        private static String pathBomba;
        private static int posXbomba;
        private static int posYbomba;

        private static ArrayList coin = new ArrayList();
        private static String pathcoin;
        private static int posXcoin;
        private static int posYcoin;

        private static ArrayList key = new ArrayList();
        private static String pathkey;
        private static int posXkey;
        private static int posYkey;

        private static ArrayList items = new ArrayList();
        private static String pathitem;
        private static int posXitem;
        private static int posYitem;


        public int get_bombas()
        {
            return bomba;
        }

        public int get_coins()
        {
            return fichas;
        }

        public string get_color()
        {
            return color1;
        }

        public int get_height()
        {
            return height1;
        }

        public string get_item()
        {
            return item;
        }

        public string get_jugador()
        {
            return path1;
        }

        public int get_keys()
        {
            return llave;
        }

        public int get_lifes()
        {
            return vidas;
        }

        public string get_name()
        {
            return name1;
        }

        public string get_pathrock()
        {
            return pathrock;
        }

        public int get_posX()
        {
            return posX1;
        }

        public int get_posxrock()
        {
            return posX1rock;
        }

        public int get_posy()
        {
            return posY1;
        }

        public int get_posyrock()
        {
            return posY1rock;
        }

        public ArrayList get_rock()
        {
            return rocas;
        }

        public int get_width()
        {
            return width1;
        }

        public void set_bombas(int bombas)
        {
            bomba = bombas;
        }

        public void set_coins(int coins)
        {
            fichas = coins;
        }

        public void set_color(string color)
        {
            color1 = color;
        }

        public void set_height(int height)
        {
            height1 = height;
        }

        public void set_item(string ubicacion)
        {
            item = ubicacion;
        }

        public void set_jugador(string path)
        {
            path1 = path;
        }

        public void set_keys(int key)
        {
            llave = key;
        }

        public void set_lifes(int lifes)
        {
            vidas = lifes;
        }

        public void set_name(string name)
        {
            name1 = name;
        }

        public void set_pathrock(string ubicacion)
        {
            pathrock = ubicacion;
        }

        public void set_posX(int posX)
        {
            posX1 = posX;
        }

        public void set_posxrock(int posx)
        {
            posX1rock = posx;
        }

        public void set_posy(int posY)
        {
            posY1 = posY;
        }

        public void set_posyrock(int posy)
        {
            posY1rock = posy;
        }

        public void set_rock(ArrayList rock)
        {
            rocas = rock;
        }

        public void set_width(int width)
        {
            width1 = width;
        }


        public void set_pathspike(string ubicacion)
        {
            pathspike = ubicacion;
        }

        public string get_pathspike()
        {
            return pathspike;
        }

        public void set_posxspike(int posx)
        {
            posX1spike = posx;
        }

        public int get_posxspike()
        {
            return posX1spike;
        }

        public void set_posyspike(int posy)
        {
            posY1spike = posy;
        }

        public int get_posyspike()
        {
            return posY1spike;
        }

        public void set_spike(ArrayList spike)
        {
            spikes = spike;
        }

        public ArrayList get_spike()
        {
            return spikes;
        }

        public void set_textureExit(string path)
        {
            pathExit = path;
        }

        public string get_textureExit()
        {
            return pathExit;
        }

        public void set_posXExit(int x)
        {
            posXExit = x;
        }

        public int get_posXExit()
        {
            return posXExit;
        }

        public void set_posYExit(int y)
        {
            posYExit = y;
        }

        public int get_posYExit()
        {
            return posYExit;
        }

        public ArrayList get_corazones()
        {
            return corazones;
        }

        public void set_corazones(ArrayList heart)
        {
            corazones = heart;
        }

        public int get_posXheart()
        {
            return posXHeart;
        }

        public void set_posXhear(int x)
        {
            posXHeart = x;
        }

        public int get_posYheart()
        {
            return posYHeart;
        }

        public void set_posYheart(int y)
        {
            posYHeart=y;
        }

        public string get_pathheart()
        {
            return pathCorazon;
        }

        public void set_pathheart(string path)
        {
            pathCorazon = path;
        }


        public ArrayList get_bomb()
        {
            return bombas;
        }

        public void set_bomas(ArrayList heart)
        {
            bombas = heart;
        }

        public int get_posXbombas()
        {
            return posXbomba;
        }

        public void set_posXbombas(int x)
        {
            posXbomba = x;
        }

        public int get_posYbombas()
        {
            return posYbomba;
        }

        public void set_posYbombas(int y)
        {
            posYbomba = y;
        }

        public string get_pathbombas()
        {
            return pathBomba;
        }

        public void set_pathbombas(string path)
        {
            pathBomba = path;
        }

        public ArrayList get_coin()
        {
            return coin;
        }

        public void set_coin(ArrayList heart)
        {
            coin = heart;
        }

        public int get_posXcoin()
        {
            return posXcoin;
        }

        public void set_posXcoin(int x)
        {
            posXcoin = x;
        }

        public int get_posYcoin()
        {
            return posYcoin;
        }

        public void set_posYcoin(int y)
        {
            posYcoin = y;
        }

        public string get_pathcoin()
        {
            return pathcoin;
        }

        public void set_pathcoin(string path)
        {
            pathcoin = path;
        }

        public ArrayList get_key()
        {
            return key;
        }

        public void set_key(ArrayList heart)
        {
            key = heart;
        }

        public int get_posXkey()
        {
            return posXkey;
        }

        public void set_posXkey(int x)
        {
            posXkey = x;
        }

        public int get_posYkey()
        {
            return posYkey;
        }

        public void set_posYkey(int y)
        {
            posYkey = y;
        }

        public string get_pathkey()
        {
            return pathkey;
        }

        public void set_pathkey(string path)
        {
            pathkey = path;
        }

        public ArrayList get_items()
        {
            return items;
        }
        public void set_item(ArrayList heart)
        {
            items = heart;
        }

        public int get_posXitem()
        {
            return posXitem;
        }

        public void set_posXitem(int x)
        {
            posXitem = x;
        }

        public int get_posYitem()
        {
            return posYitem;
        }

        public void set_posYitem(int y)
        {
            posYitem = y;
        }

        public string get_pathitem()
        {
            return pathitem;
        }

        public void set_pathitem(string path)
        {
            pathitem = path;
        }

        public void Dispose()
        {
            rocas.Clear();
            spikes.Clear();
            corazones.Clear();
            bombas.Clear();
            coin.Clear();
            key.Clear();
            items.Clear();
        }
    }
}
