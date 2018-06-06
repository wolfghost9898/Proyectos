using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorJson
{
    class PalabrasdelSistema
    {
        String[] Palabras_Reservadas = new String[18];
        String[] atributo = new String[9];

        public String[] PalabrasReservadas()
        {
            Palabras_Reservadas[0] = "Inicio"; 
            Palabras_Reservadas[1] = "Encabezado"; 
            Palabras_Reservadas[2] = "TituloPagina"; 
            Palabras_Reservadas[3] = "Cuerpo"; 
            Palabras_Reservadas[4] = "Texto"; 
            Palabras_Reservadas[5] = "Parrafo"; 
            Palabras_Reservadas[6] = "Centro"; 
            Palabras_Reservadas[7] = "Izquierda"; 
            Palabras_Reservadas[8] = "Derecha"; 
            Palabras_Reservadas[9] = "Negrita";
            Palabras_Reservadas[10] = "Cursiva";
            Palabras_Reservadas[11] = "Subrayado";
            Palabras_Reservadas[12] = "Titulo";
            Palabras_Reservadas[13] = "Tabla";
            Palabras_Reservadas[14] = "Fila";
            Palabras_Reservadas[15] = "Imagen";
            Palabras_Reservadas[16] = "Color";
            Palabras_Reservadas[17] = "Salto";
            return Palabras_Reservadas;
        }

        public String[] Atributos()
        {
            atributo[0] = "Fondo";
            atributo[1] = "Face";
            atributo[2] = "Text";
            atributo[3] = "Tamaño";
            atributo[4] = "Posicion";
            atributo[5] = "color";
            return atributo;
        }
    }
}
