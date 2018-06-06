using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace AnalizadorJson
{
    public partial class Ventana_Juego : Form
    {
        //----------------------------------------------------VARIABLES-------------------------------------
        private INTERFACES.Campo_JugadorHe campojugador = new INTERFACES.Campo_JugadorHe();
        int x;
        int y;
        Image imagen;
        int hud;
        private ArrayList rocas;
        private ArrayList spikes;
        private ArrayList corazones;
        private ArrayList bombas;
        private ArrayList coin;
        private ArrayList keys;
        private ArrayList items;
        int width;
        int height;
        int xexit;
        int yexit;

        //-----------------------------------------------------Grupo de Imagenes-----------------------------------
        PictureBox[] picturerocas;
        PictureBox[] picturecorazones;
        PictureBox[] picturebombs;
        PictureBox[] picturecoins;
        PictureBox[] picturekeys;
        PictureBox[] pictureitems;
        public Ventana_Juego()
        {
            InitializeComponent();
            width = Convert.ToInt32((campojugador.get_width() + 1.5)) * 30;
            height = ((campojugador.get_height() + 1) * 30) + Convert.ToInt32(campojugador.get_height() * 30 * 0.2);
            this.Size = new Size(width, height);
            Color color = System.Drawing.ColorTranslator.FromHtml(campojugador.get_color());
            //-----------------------------------------imagen de player-----------------------------------
            try
            {
                imagen = Image.FromFile(@campojugador.get_jugador());
                player.Image = imagen;
                //--------------------------------------------Posicion de Player-------------------------------------
                x = campojugador.get_posX() * 30;
                y = campojugador.get_posy() * 30;
                player.Location = new Point(x, y);

            }
            catch (System.ArgumentNullException ee) { }
            //------------------------------------------imagen exit--------------------------------------
            try
            {
                Image exitimg = Image.FromFile(@campojugador.get_textureExit());
                exit.Image = exitimg;
                //-------------------------------------------Posicion de Exit-----------------------------------------
                xexit = campojugador.get_posXExit() * 30;
                yexit = campojugador.get_posYExit() * 30;
                exit.Location = new Point(xexit, yexit);
                exit.BringToFront();
            }
            catch (System.ArgumentNullException ee) { }

            //----------------------------------tamaño de los paneles------------------------------------
            hud = Convert.ToInt32((campojugador.get_height() * 30) * 0.2);
            HUD.Size = new Size(width, hud);

            int body = (campojugador.get_height() * 30);
            BODY.Size = new Size(width, body);
            BODY.BackColor = color;

            Rellenar_HUD();
            AgregarRocas();
            AgregarSpikes();
            AgregarCorazones();
            AgregarBombas();
            AgregarCoins();
            AgregarKeys();
            Agregaritems();

        }

        private void Ventana_Juego_Load(object sender, EventArgs e)
        {

           
        }
        //---------------------------------------------MOVER PLAYER----------------------------------------------
        private void Ventana_Juego_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                //-------------------------------------Izquierda----------------------------------------
                case Keys.Left:
                    if (player.Left> 0)
                    {
                        Boolean mover = true;
                        Boolean daño = false;
                        //---------------------------------------------rocas--------------------------------
                        for(int i = 0; i < rocas.Count; i++)
                        {
                            Object[] ro = (Object[])rocas[i];
                            int xx = (Convert.ToInt32(ro[0]) * 30);
                            int yy = (Convert.ToInt32(ro[1]) * 30);
                            if((player.Left-30)==xx && player.Top == yy)
                            {
                                mover = false;
                            }
                        }
                        //----------------------------------------------spikes------------------------------
                        for (int i = 0; i < spikes.Count; i++)
                        {
                            Object[] ro = (Object[])spikes[i];
                            int xx = (Convert.ToInt32(ro[0]) * 30);
                            int yy = (Convert.ToInt32(ro[1]) * 30);
                            if ((player.Left) == xx && player.Top == yy)
                            {
                                daño = true;
                            }
                        }
                        //------------------------------------------------Corazones------------------------
                        for (int i = 0; i < corazones.Count; i++)
                        {
                            Object[] ro = (Object[])corazones[i];
                            int xx = (Convert.ToInt32(ro[0]) * 30);
                            int yy = (Convert.ToInt32(ro[1]) * 30);
                            if ((player.Left-30) == xx && player.Top == yy)
                            {
                                PictureBox[] temp = new PictureBox[picturecorazones.Length - 1];
                                int temp_int = 0;
                                for(int j = 0; j < picturecorazones.Length; j++)
                                {
                                    if (picturecorazones[j] != picturecorazones[i])
                                    {
                                        temp[temp_int] = picturecorazones[j];
                                        temp_int++;
                                    }
                                }
                                corazones.RemoveAt(i);
                                BODY.Controls.Remove(picturecorazones[i]);
                                picturecorazones = temp;
                                int vid = Convert.ToInt32(vidas.Text)+1;
                                vidas.Text = Convert.ToString(vid);
                            }
                        }
                        //-----------------------------------------------Bombas----------------------------
                        for (int i = 0; i < bombas.Count; i++)
                        {
                            Object[] ro = (Object[])bombas[i];
                            int xx = (Convert.ToInt32(ro[0]) * 30);
                            int yy = (Convert.ToInt32(ro[1]) * 30);
                            if ((player.Left - 30) == xx && player.Top == yy)
                            {
                                PictureBox[] temp = new PictureBox[picturebombs.Length - 1];
                                int temp_int = 0;
                                for (int j = 0; j < picturebombs.Length; j++)
                                {
                                    if (picturebombs[j] != picturebombs[i])
                                    {
                                        temp[temp_int] = picturebombs[j];
                                        temp_int++;
                                    }
                                }
                                bombas.RemoveAt(i);
                                BODY.Controls.Remove(picturebombs[i]);
                                picturebombs = temp;
                                int bombass = Convert.ToInt32(bombs.Text) + 1;
                                bombs.Text = Convert.ToString(bombass);
                            }
                        }
                        //-----------------------------------------------Coins----------------------------
                        for (int i = 0; i < coin.Count; i++)
                        {
                            Object[] ro = (Object[])coin[i];
                            int xx = (Convert.ToInt32(ro[0]) * 30);
                            int yy = (Convert.ToInt32(ro[1]) * 30);
                            if ((player.Left - 30) == xx && player.Top == yy)
                            {
                                PictureBox[] temp = new PictureBox[picturecoins.Length - 1];
                                int temp_int = 0;
                                for (int j = 0; j < picturecoins.Length; j++)
                                {
                                    if (picturecoins[j] != picturecoins[i])
                                    {
                                        temp[temp_int] = picturecoins[j];
                                        temp_int++;
                                    }
                                }
                                coin.RemoveAt(i);
                                BODY.Controls.Remove(picturecoins[i]);
                                picturecoins = temp;
                                int coinss = Convert.ToInt32(coins.Text) + 1;
                                coins.Text = Convert.ToString(coinss);
                            }
                        }
                        //-----------------------------------------------Keys----------------------------
                        for (int i = 0; i < keys.Count; i++)
                        {
                            Object[] ro = (Object[])keys[i];
                            int xx = (Convert.ToInt32(ro[0]) * 30);
                            int yy = (Convert.ToInt32(ro[1]) * 30);
                            if ((player.Left - 30) == xx && player.Top == yy)
                            {
                                PictureBox[] temp = new PictureBox[picturekeys.Length - 1];
                                int temp_int = 0;
                                for (int j = 0; j < picturekeys.Length; j++)
                                {
                                    if (picturekeys[j] != picturekeys[i])
                                    {
                                        temp[temp_int] = picturekeys[j];
                                        temp_int++;
                                    }
                                }
                                keys.RemoveAt(i);
                                BODY.Controls.Remove(picturekeys[i]);
                                picturekeys = temp;
                                int keyss = Convert.ToInt32(key.Text) + 1;
                                key.Text = Convert.ToString(keyss);
                            }
                        }
                        //-----------------------------------------------Items----------------------------
                        for (int i = 0; i < items.Count; i++)
                        {
                            Object[] ro = (Object[])items[i];
                            int xx = (Convert.ToInt32(ro[0]) * 30);
                            int yy = (Convert.ToInt32(ro[1]) * 30);
                            String rutaob = (String)ro[2];
                            if ((player.Left - 30) == xx && player.Top == yy)
                            {
                                PictureBox[] temp = new PictureBox[pictureitems.Length - 1];
                                int temp_int = 0;
                                for (int j = 0; j < pictureitems.Length; j++)
                                {
                                    if (pictureitems[j] != pictureitems[i])
                                    {
                                        temp[temp_int] = pictureitems[j];
                                        temp_int++;
                                    }
                                }
                                items.RemoveAt(i);
                                BODY.Controls.Remove(pictureitems[i]);
                                pictureitems = temp;
                                Image imagen_ob = Image.FromFile(@rutaob);
                                item.Image = imagen_ob;
                            }
                        }
                        if (mover == true)
                        {
                            x -= 30;
                            player.Left = x;
                        }
                        if (daño == true)
                        {
                            int corazones = Convert.ToInt32(vidas.Text);
                            vidas.Text = Convert.ToString(corazones-1);
                        }
                        
                    }                            
                    break;
                //--------------------------------------Arriba---------------------------------------
                case Keys.Up:
                    if (player.Top >0)
                    {
                        Boolean mover = true;
                        Boolean daño = false;
                        //---------------------------------------------------rocas----------------------------
                        for (int i = 0; i < rocas.Count; i++)
                        {
                            Object[] ro = (Object[])rocas[i];
                            int xx = (Convert.ToInt32(ro[0]) * 30);
                            int yy = (Convert.ToInt32(ro[1]) * 30);
                            if ((player.Top - 30) == yy && player.Left == xx)
                            {
                                mover = false;
                            }
                        }
                        //----------------------------------------------spikes------------------------------
                        for (int i = 0; i < spikes.Count; i++)
                        {
                            Object[] ro = (Object[])spikes[i];
                            int xx = (Convert.ToInt32(ro[0]) * 30);
                            int yy = (Convert.ToInt32(ro[1]) * 30);
                            if ((player.Top) == yy && player.Left == xx)
                            {
                                daño = true;
                            }
                        }
                        //------------------------------------------------Corazones------------------------
                        for (int i = 0; i < corazones.Count; i++)
                        {
                            Object[] ro = (Object[])corazones[i];
                            int xx = (Convert.ToInt32(ro[0]) * 30);
                            int yy = (Convert.ToInt32(ro[1]) * 30);
                            if ((player.Top-30) == yy && player.Left == xx)
                            {
                                PictureBox[] temp = new PictureBox[picturecorazones.Length - 1];
                                int temp_int = 0;
                                for (int j = 0; j < picturecorazones.Length; j++)
                                {
                                    if (picturecorazones[j] != picturecorazones[i])
                                    {
                                        temp[temp_int] = picturecorazones[j];
                                        temp_int++;
                                    }
                                }
                                corazones.RemoveAt(i);
                                BODY.Controls.Remove(picturecorazones[i]);
                                picturecorazones = temp;
                                int vid = Convert.ToInt32(vidas.Text) + 1;
                                vidas.Text = Convert.ToString(vid);
                            }
                        }
                        //-----------------------------------------------Bombas----------------------------
                        for (int i = 0; i < bombas.Count; i++)
                        {
                            Object[] ro = (Object[])bombas[i];
                            int xx = (Convert.ToInt32(ro[0]) * 30);
                            int yy = (Convert.ToInt32(ro[1]) * 30);
                            if ((player.Top - 30) == yy && player.Left == xx)
                            {
                                PictureBox[] temp = new PictureBox[picturebombs.Length - 1];
                                int temp_int = 0;
                                for (int j = 0; j < picturebombs.Length; j++)
                                {
                                    if (picturebombs[j] != picturebombs[i])
                                    {
                                        temp[temp_int] = picturebombs[j];
                                        temp_int++;
                                    }
                                }
                                bombas.RemoveAt(i);
                                BODY.Controls.Remove(picturebombs[i]);
                                picturebombs = temp;
                                int bombass = Convert.ToInt32(bombs.Text) + 1;
                                bombs.Text = Convert.ToString(bombass);
                            }
                        }
                        //-----------------------------------------------Coins----------------------------
                        for (int i = 0; i < coin.Count; i++)
                        {
                            Object[] ro = (Object[])coin[i];
                            int xx = (Convert.ToInt32(ro[0]) * 30);
                            int yy = (Convert.ToInt32(ro[1]) * 30);
                            if ((player.Top - 30) == yy && player.Left == xx)
                            {
                                PictureBox[] temp = new PictureBox[picturecoins.Length - 1];
                                int temp_int = 0;
                                for (int j = 0; j < picturecoins.Length; j++)
                                {
                                    if (picturecoins[j] != picturecoins[i])
                                    {
                                        temp[temp_int] = picturecoins[j];
                                        temp_int++;
                                    }
                                }
                                coin.RemoveAt(i);
                                BODY.Controls.Remove(picturecoins[i]);
                                picturecoins = temp;
                                int coinss = Convert.ToInt32(coins.Text) + 1;
                                coins.Text = Convert.ToString(coinss);
                            }
                        }
                        //-----------------------------------------------Keys----------------------------
                        for (int i = 0; i < keys.Count; i++)
                        {
                            Object[] ro = (Object[])keys[i];
                            int xx = (Convert.ToInt32(ro[0]) * 30);
                            int yy = (Convert.ToInt32(ro[1]) * 30);
                            if ((player.Top - 30) == yy && player.Left == xx)
                            {
                                PictureBox[] temp = new PictureBox[picturekeys.Length - 1];
                                int temp_int = 0;
                                for (int j = 0; j < picturekeys.Length; j++)
                                {
                                    if (picturekeys[j] != picturekeys[i])
                                    {
                                        temp[temp_int] = picturekeys[j];
                                        temp_int++;
                                    }
                                }
                                keys.RemoveAt(i);
                                BODY.Controls.Remove(picturekeys[i]);
                                picturekeys = temp;
                                int keyss = Convert.ToInt32(key.Text) + 1;
                                key.Text = Convert.ToString(keyss);
                            }
                        }
                        //-----------------------------------------------Items----------------------------
                        for (int i = 0; i < items.Count; i++)
                        {
                            Object[] ro = (Object[])items[i];
                            int xx = (Convert.ToInt32(ro[0]) * 30);
                            int yy = (Convert.ToInt32(ro[1]) * 30);
                            String rutaob = (String)ro[2];
                            if ((player.Top - 30) == yy && player.Left == xx)
                            {
                                PictureBox[] temp = new PictureBox[pictureitems.Length - 1];
                                int temp_int = 0;
                                for (int j = 0; j < pictureitems.Length; j++)
                                {
                                    if (pictureitems[j] != pictureitems[i])
                                    {
                                        temp[temp_int] = pictureitems[j];
                                        temp_int++;
                                    }
                                }
                                items.RemoveAt(i);
                                BODY.Controls.Remove(pictureitems[i]);
                                pictureitems = temp;
                                Image imagen_ob = Image.FromFile(@rutaob);
                                item.Image = imagen_ob;
                            }
                        }
                        if (mover == true)
                        {
                            y -= 30;
                            player.Top = y;
                        }
                        if (daño == true)
                        {
                            int corazones = Convert.ToInt32(vidas.Text);
                            vidas.Text = Convert.ToString(corazones - 1);
                        }

                    }
                    break;
                //----------------------------------------Derecha-------------------------------------
                case Keys.Right:
                    if (player.Left < campojugador.get_width()*30)
                    {
                        Boolean daño = false;
                        Boolean mover = true;
                        //---------------------------------------------rocas----------------------------------
                        for (int i = 0; i < rocas.Count; i++)
                        {
                            Object[] ro = (Object[])rocas[i];
                            int xx = (Convert.ToInt32(ro[0]) * 30);
                            int yy = (Convert.ToInt32(ro[1]) * 30);
                            if ((player.Left +30) == xx && player.Top == yy)
                            {
                                mover = false;
                            }
                        }
                        //----------------------------------------------spikes------------------------------
                        for (int i = 0; i < spikes.Count; i++)
                        {
                            Object[] ro = (Object[])spikes[i];
                            int xx = (Convert.ToInt32(ro[0]) * 30);
                            int yy = (Convert.ToInt32(ro[1]) * 30);
                            if ((player.Left) == xx && player.Top == yy)
                            {
                                daño = true;
                            }
                        }
                        //-----------------------------------------------Corazones--------------------------
                        for (int i = 0; i < corazones.Count; i++)
                        {
                            Object[] ro = (Object[])corazones[i];
                            int xx = (Convert.ToInt32(ro[0]) * 30);
                            int yy = (Convert.ToInt32(ro[1]) * 30);
                            if ((player.Left + 30) == xx && player.Top == yy)
                            {
                                PictureBox[] temp = new PictureBox[picturecorazones.Length - 1];
                                int temp_int = 0;
                                for (int j = 0; j < picturecorazones.Length; j++)
                                {
                                    if (picturecorazones[j] != picturecorazones[i])
                                    {
                                        temp[temp_int] = picturecorazones[j];
                                        temp_int++;
                                    }
                                }
                                corazones.RemoveAt(i);
                                BODY.Controls.Remove(picturecorazones[i]);
                                picturecorazones = temp;
                                int vid = Convert.ToInt32(vidas.Text) + 1;
                                vidas.Text = Convert.ToString(vid);
                            }
                        }
                        //-----------------------------------------------Bombas----------------------------
                        for (int i = 0; i < bombas.Count; i++)
                        {
                            Object[] ro = (Object[])bombas[i];
                            int xx = (Convert.ToInt32(ro[0]) * 30);
                            int yy = (Convert.ToInt32(ro[1]) * 30);
                            if ((player.Left + 30) == xx && player.Top == yy)
                            {
                                PictureBox[] temp = new PictureBox[picturebombs.Length - 1];
                                int temp_int = 0;
                                for (int j = 0; j < picturebombs.Length; j++)
                                {
                                    if (picturebombs[j] != picturebombs[i])
                                    {
                                        temp[temp_int] = picturebombs[j];
                                        temp_int++;
                                    }
                                }
                                bombas.RemoveAt(i);
                                BODY.Controls.Remove(picturebombs[i]);
                                picturebombs = temp;
                                int bombass = Convert.ToInt32(bombs.Text) + 1;
                                bombs.Text = Convert.ToString(bombass);
                            }
                        }
                        //-----------------------------------------------Coins----------------------------
                        for (int i = 0; i < coin.Count; i++)
                        {
                            Object[] ro = (Object[])coin[i];
                            int xx = (Convert.ToInt32(ro[0]) * 30);
                            int yy = (Convert.ToInt32(ro[1]) * 30);
                            if ((player.Left + 30) == xx && player.Top == yy)
                            {
                                PictureBox[] temp = new PictureBox[picturecoins.Length - 1];
                                int temp_int = 0;
                                for (int j = 0; j < picturecoins.Length; j++)
                                {
                                    if (picturecoins[j] != picturecoins[i])
                                    {
                                        temp[temp_int] = picturecoins[j];
                                        temp_int++;
                                    }
                                }
                                coin.RemoveAt(i);
                                BODY.Controls.Remove(picturecoins[i]);
                                picturecoins = temp;
                                int coinss = Convert.ToInt32(coins.Text) + 1;
                                coins.Text = Convert.ToString(coinss);
                            }
                        }
                        //-----------------------------------------------Keys----------------------------
                        for (int i = 0; i < keys.Count; i++)
                        {
                            Object[] ro = (Object[])keys[i];
                            int xx = (Convert.ToInt32(ro[0]) * 30);
                            int yy = (Convert.ToInt32(ro[1]) * 30);
                            if((player.Left + 30) == xx && player.Top == yy)
                            {
                                PictureBox[] temp = new PictureBox[picturekeys.Length - 1];
                                int temp_int = 0;
                                for (int j = 0; j < picturekeys.Length; j++)
                                {
                                    if (picturekeys[j] != picturekeys[i])
                                    {
                                        temp[temp_int] = picturekeys[j];
                                        temp_int++;
                                    }
                                }
                                keys.RemoveAt(i);
                                BODY.Controls.Remove(picturekeys[i]);
                                picturekeys = temp;
                                int keyss = Convert.ToInt32(key.Text) + 1;
                                key.Text = Convert.ToString(keyss);
                            }
                        }
                        //-----------------------------------------------Items----------------------------
                        for (int i = 0; i < items.Count; i++)
                        {
                            Object[] ro = (Object[])items[i];
                            int xx = (Convert.ToInt32(ro[0]) * 30);
                            int yy = (Convert.ToInt32(ro[1]) * 30);
                            String rutaob = (String)ro[2];
                            if ((player.Left + 30) == xx && player.Top == yy)
                            {
                                PictureBox[] temp = new PictureBox[pictureitems.Length - 1];
                                int temp_int = 0;
                                for (int j = 0; j < pictureitems.Length; j++)
                                {
                                    if (pictureitems[j] != pictureitems[i])
                                    {
                                        temp[temp_int] = pictureitems[j];
                                        temp_int++;
                                    }
                                }
                                items.RemoveAt(i);
                                BODY.Controls.Remove(pictureitems[i]);
                                pictureitems = temp;
                                Image imagen_ob = Image.FromFile(@rutaob);
                                item.Image = imagen_ob;
                            }
                        }
                        if (mover == true)
                        {
                            x += 30;
                            player.Left = x;
                        }
                        if (daño == true)
                        {
                            int corazones = Convert.ToInt32(vidas.Text);
                            vidas.Text = Convert.ToString(corazones - 1);
                        }

                    }
                    break;
                //-----------------------------------------Abajo--------------------------------------
                case Keys.Down:
                    if (player.Top < ((campojugador.get_height() -1) * 30))
                    {
                        //-----------------------------------------rocas---------------------------------------------
                        Boolean mover = true;
                        Boolean daño = false;
                        for (int i = 0; i < rocas.Count; i++)
                        {
                            Object[] ro = (Object[])rocas[i];
                            int xx = (Convert.ToInt32(ro[0]) * 30);
                            int yy = (Convert.ToInt32(ro[1]) * 30);
                            if ((player.Top + 30) == yy && player.Left == xx)
                            {
                                mover = false;
                            }

                        }
                        //----------------------------------------------spikes------------------------------
                        for (int i = 0; i < spikes.Count; i++)
                        {
                            Object[] ro = (Object[])spikes[i];
                            int xx = (Convert.ToInt32(ro[0]) * 30);
                            int yy = (Convert.ToInt32(ro[1]) * 30);
                            if ((player.Top) == yy && player.Left == xx)
                            {
                                daño = true;
                            }
                        }
                        //----------------------------------------------Corazones----------------------------------
                        for (int i = 0; i < corazones.Count; i++)
                        {
                            Object[] ro = (Object[])corazones[i];
                            int xx = (Convert.ToInt32(ro[0]) * 30);
                            int yy = (Convert.ToInt32(ro[1]) * 30);
                            if ((player.Top + 30) == yy && player.Left == xx)
                            {
                                PictureBox[] temp = new PictureBox[picturecorazones.Length - 1];
                                int temp_int = 0;
                                for (int j = 0; j < picturecorazones.Length; j++)
                                {
                                    if (picturecorazones[j] != picturecorazones[i])
                                    {
                                        temp[temp_int] = picturecorazones[j];
                                        temp_int++;
                                    }
                                }
                                corazones.RemoveAt(i);
                                BODY.Controls.Remove(picturecorazones[i]);
                                picturecorazones = temp;
                                int vid = Convert.ToInt32(vidas.Text) + 1;
                                vidas.Text = Convert.ToString(vid);
                            }
                        }
                        //-----------------------------------------------Bombas----------------------------
                        for (int i = 0; i < bombas.Count; i++)
                        {
                            Object[] ro = (Object[])bombas[i];
                            int xx = (Convert.ToInt32(ro[0]) * 30);
                            int yy = (Convert.ToInt32(ro[1]) * 30);
                            if ((player.Top + 30) == yy && player.Left == xx)
                            {
                                PictureBox[] temp = new PictureBox[picturebombs.Length - 1];
                                int temp_int = 0;
                                for (int j = 0; j < picturebombs.Length; j++)
                                {
                                    if (picturebombs[j] != picturebombs[i])
                                    {
                                        temp[temp_int] = picturebombs[j];
                                        temp_int++;
                                    }
                                }
                                bombas.RemoveAt(i);
                                BODY.Controls.Remove(picturebombs[i]);
                                picturebombs = temp;
                                int bombass = Convert.ToInt32(bombs.Text) + 1;
                                bombs.Text = Convert.ToString(bombass);
                            }
                        }
                        //-----------------------------------------------Coins----------------------------
                        for (int i = 0; i < coin.Count; i++)
                        {
                            Object[] ro = (Object[])coin[i];
                            int xx = (Convert.ToInt32(ro[0]) * 30);
                            int yy = (Convert.ToInt32(ro[1]) * 30);
                            if ((player.Top + 30) == yy && player.Left == xx)
                            {
                                PictureBox[] temp = new PictureBox[picturecoins.Length - 1];
                                int temp_int = 0;
                                for (int j = 0; j < picturecoins.Length; j++)
                                {
                                    if (picturecoins[j] != picturecoins[i])
                                    {
                                        temp[temp_int] = picturecoins[j];
                                        temp_int++;
                                    }
                                }
                                coin.RemoveAt(i);
                                BODY.Controls.Remove(picturecoins[i]);
                                picturecoins = temp;
                                int coinss = Convert.ToInt32(coins.Text) + 1;
                                coins.Text = Convert.ToString(coinss);
                            }
                        }
                        //-----------------------------------------------Keys----------------------------
                        for (int i = 0; i < keys.Count; i++)
                        {
                            Object[] ro = (Object[])keys[i];
                            int xx = (Convert.ToInt32(ro[0]) * 30);
                            int yy = (Convert.ToInt32(ro[1]) * 30);
                            if ((player.Top + 30) == yy && player.Left == xx)
                            {
                                PictureBox[] temp = new PictureBox[picturekeys.Length - 1];
                                int temp_int = 0;
                                for (int j = 0; j < picturekeys.Length; j++)
                                {
                                    if (picturekeys[j] != picturekeys[i])
                                    {
                                        temp[temp_int] = picturekeys[j];
                                        temp_int++;
                                    }
                                }
                                keys.RemoveAt(i);
                                BODY.Controls.Remove(picturekeys[i]);
                                picturekeys = temp;
                                int keyss = Convert.ToInt32(key.Text) + 1;
                                key.Text = Convert.ToString(keyss);
                            }
                        }
                        //-----------------------------------------------Items----------------------------
                        for (int i = 0; i < items.Count; i++)
                        {
                            Object[] ro = (Object[])items[i];
                            int xx = (Convert.ToInt32(ro[0]) * 30);
                            int yy = (Convert.ToInt32(ro[1]) * 30);
                            String rutaob = (String)ro[2];
                            if ((player.Top + 30) == yy && player.Left == xx)
                            {
                                PictureBox[] temp = new PictureBox[pictureitems.Length - 1];
                                int temp_int = 0;
                                for (int j = 0; j < pictureitems.Length; j++)
                                {
                                    if (pictureitems[j] != pictureitems[i])
                                    {
                                        temp[temp_int] = pictureitems[j];
                                        temp_int++;
                                    }
                                }
                                items.RemoveAt(i);
                                BODY.Controls.Remove(pictureitems[i]);
                                pictureitems = temp;
                                Image imagen_ob = Image.FromFile(@rutaob);
                                item.Image = imagen_ob;
                            }
                        }
                        if (mover == true)
                        {
                            y += 30;
                            player.Top = y;
                        }
                        if (daño == true)
                        {
                            int corazones = Convert.ToInt32(vidas.Text);
                            vidas.Text = Convert.ToString(corazones - 1);
                        }

                    }
                    break;

                default:
                    break;
            }

        }
        //--------------------------------------------------RELLENAR HUD----------------------------------------------
        private void Rellenar_HUD()
        {
            vidas.Text = Convert.ToString(campojugador.get_lifes());
            key.Text = Convert.ToString(campojugador.get_keys());
            bombs.Text = Convert.ToString(campojugador.get_bombas());
            coins.Text = Convert.ToString(campojugador.get_coins());
            room.Text = campojugador.get_name();

            //---------------------------------Imagen Avatar---------------------------------------
            item.Location = new Point(width - item.Width - 50, item.Top);
            if (campojugador.get_item() != null)
            {
                item.Image = Image.FromFile(@campojugador.get_item());
            }
            else
            {
                item.Image = Image.FromFile(@"Imagenes/noavatar.png");
            }
        }
        //----------------------------------------------AGREGAR ROCAS--------------------------------------------
        private void AgregarRocas()
        {
            rocas = campojugador.get_rock();
            picturerocas = new PictureBox[rocas.Count];
            for (int i = 0; i < picturerocas.Length; i++)
            {
                Object[] ro = (Object[])rocas[i];
                int x = (Convert.ToInt32(ro[0])*30);
                int y =( Convert.ToInt32(ro[1])*30);
                picturerocas[i] = new PictureBox();
                picturerocas[i].Location = new Point(x,y);
                picturerocas[i].Size = new Size(30, 30);
                String ruta = Convert.ToString(ro[2]);
                Bitmap direccion = new Bitmap(ruta);
                direccion.MakeTransparent();
                picturerocas[i].Image = direccion;
                picturerocas[i].SizeMode = PictureBoxSizeMode.StretchImage;
                BODY.Controls.Add(picturerocas[i]);
                picturerocas[i].BringToFront();
            }
        }



        //----------------------------------------------AGREGAR Spikes--------------------------------------------
        private void AgregarSpikes()
        {
            spikes = campojugador.get_spike();
            PictureBox[] picturebox = new PictureBox[spikes.Count];
            for (int i = 0; i < picturebox.Length; i++)
            {
                Object[] ro = (Object[])spikes[i];
                int x = (Convert.ToInt32(ro[0]) * 30);
                int y = (Convert.ToInt32(ro[1]) * 30);
                picturebox[i] = new PictureBox();
                picturebox[i].Location = new Point(x, y);
                picturebox[i].Size = new Size(30, 30);
                String ruta = Convert.ToString(ro[2]);
                Bitmap direccion = new Bitmap(ruta);
                direccion.MakeTransparent();
                picturebox[i].Image = direccion;
                picturebox[i].SizeMode = PictureBoxSizeMode.StretchImage;
                BODY.Controls.Add(picturebox[i]);
                picturebox[i].BringToFront();
            }
        }


        //----------------------------------------------AGREGAR Corazones--------------------------------------------
        private void AgregarCorazones()
        {
            corazones = campojugador.get_corazones();
            picturecorazones = new PictureBox[corazones.Count];
            for (int i = 0; i < picturecorazones.Length; i++)
            {
                Object[] ro = (Object[])corazones[i];
                int x = (Convert.ToInt32(ro[0]) * 30);
                int y = (Convert.ToInt32(ro[1]) * 30);
                picturecorazones[i] = new PictureBox();
                picturecorazones[i].Location = new Point(x, y);
                picturecorazones[i].Size = new Size(30, 30);
                String ruta = Convert.ToString(ro[2]);
                Bitmap direccion = new Bitmap(ruta);
                direccion.MakeTransparent();
                picturecorazones[i].Image = direccion;
                picturecorazones[i].SizeMode = PictureBoxSizeMode.StretchImage;
                BODY.Controls.Add(picturecorazones[i]);
                picturecorazones[i].BringToFront();
            }
        }

        //----------------------------------------------AGREGAR Bombas--------------------------------------------
        private void AgregarBombas()
        {
            bombas = campojugador.get_bomb();
            picturebombs = new PictureBox[bombas.Count];
            for (int i = 0; i < picturebombs.Length; i++)
            {
                Object[] ro = (Object[])bombas[i];
                int x = (Convert.ToInt32(ro[0]) * 30);
                int y = (Convert.ToInt32(ro[1]) * 30);
                picturebombs[i] = new PictureBox();
                picturebombs[i].Location = new Point(x, y);
                picturebombs[i].Size = new Size(30, 30);
                String ruta = Convert.ToString(ro[2]);
                try
                {
                    Bitmap direccion = new Bitmap(ruta);
                    direccion.MakeTransparent();
                    picturebombs[i].Image = direccion;
                    picturebombs[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    BODY.Controls.Add(picturebombs[i]);
                    picturebombs[i].BringToFront();
                }
                catch (System.ArgumentNullException ee) { }
               
                
            }
        }

        //----------------------------------------------AGREGAR Coins--------------------------------------------
        private void AgregarCoins()
        {
            coin = campojugador.get_coin();
            picturecoins = new PictureBox[coin.Count];
            for (int i = 0; i < picturecoins.Length; i++)
            {
                Object[] ro = (Object[])coin[i];
                int x = (Convert.ToInt32(ro[0]) * 30);
                int y = (Convert.ToInt32(ro[1]) * 30);
                picturecoins[i] = new PictureBox();
                picturecoins[i].Location = new Point(x, y);
                picturecoins[i].Size = new Size(30, 30);
                String ruta = Convert.ToString(ro[2]);
                try
                {
                    Bitmap direccion = new Bitmap(ruta);
                    direccion.MakeTransparent();
                    picturecoins[i].Image = direccion;
                    picturecoins[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    BODY.Controls.Add(picturecoins[i]);
                    picturecoins[i].BringToFront();
                }
                catch (System.ArgumentNullException ee) { }


            }
        }

        //----------------------------------------------AGREGAR keys--------------------------------------------
        private void AgregarKeys()
        {
            keys = campojugador.get_key();
            picturekeys = new PictureBox[keys.Count];
            for (int i = 0; i < picturekeys.Length; i++)
            {
                Object[] ro = (Object[])keys[i];
                int x = (Convert.ToInt32(ro[0]) * 30);
                int y = (Convert.ToInt32(ro[1]) * 30);
                picturekeys[i] = new PictureBox();
                picturekeys[i].Location = new Point(x, y);
                picturekeys[i].Size = new Size(30, 30);
                String ruta = Convert.ToString(ro[2]);
                try
                {
                    Bitmap direccion = new Bitmap(ruta);
                    direccion.MakeTransparent();
                    picturekeys[i].Image = direccion;
                    picturekeys[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    BODY.Controls.Add(picturekeys[i]);
                    picturekeys[i].BringToFront();
                }
                catch (System.ArgumentNullException ee) { }


            }
        }
        //----------------------------------------------AGREGAR items--------------------------------------------
        private void Agregaritems()
        {
            items = campojugador.get_items();
            pictureitems = new PictureBox[items.Count];
            for (int i = 0; i < pictureitems.Length; i++)
            {
                Object[] ro = (Object[])items[i];
                int x = (Convert.ToInt32(ro[0]) * 30);
                int y = (Convert.ToInt32(ro[1]) * 30);
                pictureitems[i] = new PictureBox();
                pictureitems[i].Location = new Point(x, y);
                pictureitems[i].Size = new Size(30, 30);
                String ruta = Convert.ToString(ro[2]);
                try
                {
                    Bitmap direccion = new Bitmap(ruta);
                    direccion.MakeTransparent();
                    pictureitems[i].Image = direccion;
                    pictureitems[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    BODY.Controls.Add(pictureitems[i]);
                    pictureitems[i].BringToFront();
                }
                catch (System.ArgumentNullException ee) { }


            }
        }


    }
}
