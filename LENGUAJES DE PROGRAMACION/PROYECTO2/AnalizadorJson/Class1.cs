using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorJson
{
    class PalabrasdelSistema
    {
        String[] Palabras_Reservadas = new String[5];
        String[] atributo = new String[14];
        String[] sub_item = new String[25];

        public String[] PalabrasReservadas()
        {
            Palabras_Reservadas[0] = "xml"; 
            Palabras_Reservadas[1] = "character"; 
            Palabras_Reservadas[2] = "room"; 
            Palabras_Reservadas[3] = "patterns"; 
            Palabras_Reservadas[4] = "monsters"; 
            return Palabras_Reservadas;
        }

        public String[] Atributos()
        {
            atributo[0] = "look";
            atributo[1] = "posX";
            atributo[2] = "posY";
            atributo[3] = "width";
            atributo[4] = "height";
            atributo[5] = "color";
            atributo[6] = "name";
            atributo[7] = "texture";
            atributo[8] = "hearts";
            atributo[9] = "coins";
            atributo[10] = "bombs";
            atributo[11] = "damage";
            atributo[12] = "range";
            atributo[13] = "luck";
            return atributo;
        }

        public String[] Sub_Item()
        {
            sub_item[0] = "hearts";
            sub_item[1] = "coins";
            sub_item[2] = "bombs";
            sub_item[3] = "item";
            sub_item[4] = "enviroment";
            sub_item[5] = "rock";
            sub_item[6] = "spike";
            sub_item[7] = "exit";
            sub_item[8] = "consumables";
            sub_item[9] = "heart";
            sub_item[10] = "coin";
            sub_item[11] = "bomb";
            sub_item[12] = "key";
            sub_item[13] = "item";
            sub_item[14] = "pill";
            sub_item[15] = "action";
            sub_item[16] = "value";
            sub_item[17] = "stat";
            sub_item[18] = "pattern";
            sub_item[19] = "movement";
            sub_item[20] = "monster";
            sub_item[21] = "movements";
            sub_item[22] = "X";
            sub_item[23] = "Y";
            sub_item[24] = "keys";
            return sub_item;
        }
    }
}
