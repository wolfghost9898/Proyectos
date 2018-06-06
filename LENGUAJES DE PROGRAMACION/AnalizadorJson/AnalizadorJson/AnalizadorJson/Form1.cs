using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalizadorJson
{

    public partial class Form1 : Form
    {
        //---------------------------------------------------------Declaracion de Variables---------------------------
        private String ruta;
        private int estado = 0;
        private int posicion = 0;
        private String cadena = "";
        private String lexema = "";
        private int fila = 1;
        private int columna = 0;
        private char caracter;
        private String token = "";
        private ArrayList lista_lexema;
        private ArrayList lista_token;
        private ArrayList lista_errores;
        private String[] palabras_reservadas;
        private String[] palabras_atributos;
        private Object[] data;
        private PalabrasdelSistema reservadas = new PalabrasdelSistema();
        //----------------------------------------------------------Fin de declaracion-------------------------------------------------------
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// ----------------------------------------Click en Abrir--------------------------------------------------------
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            String contenido = string.Empty;
            string file_name = string.Empty;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                file_name = openFileDialog1.FileName;
                try
                {
                    using (StreamReader lector = new StreamReader(file_name))
                    {
                        while (lector.Peek() > -1)
                        {
                            string linea = lector.ReadLine();
                            if (!String.IsNullOrEmpty(linea))
                            {
                                contenido += linea + "\n";
                            }
                        }
                        Cuerpo.Text = contenido;
                        ruta = file_name;
                    }
                }
                catch (Exception ex) { }
            }

        }

        //---------------------------------------------------NUEVO--------------------------------------------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            Cuerpo.ResetText();
            ruta = "";
        }

        //-------------------------------------------------GUARDAR------------------------------------------------
        private void button3_Click(object sender, EventArgs e)
        {
            TextWriter archivo;
            archivo = new StreamWriter(ruta);
            archivo.WriteLine(Cuerpo.Text);
            archivo.Close();
        }

        //--------------------------------------------------GUARDAR COMO------------------------------------
        private void button4_Click(object sender, EventArgs e)
        {
            if (Submenu.Height == 100 && Submenu.Width == 159)
            {
                Submenu.Height = 0;
                Submenu.Width = 0;
                Tradu.Location = new Point(-3, 250);
                Salir.Location = new Point(-3, 295);
            }
            else
            {
                Submenu.Height = 100;
                Submenu.Width = 159;
                Tradu.Location = new Point(-3, 318);
                Salir.Location = new Point(-3, 363);

            }
        }
        //---------------------------------------------Guardar como LFP-----------------------------------
        private void button5_MouseClick(object sender, MouseEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                TextWriter archivo;
                archivo = new StreamWriter(saveFileDialog1.FileName);
                archivo.WriteLine(Cuerpo.Text);
                archivo.Close();
            }
        }

        //------------------------------------------------------Guardar Como HTML-----------------------------------
        private void button6_MouseClick(object sender, MouseEventArgs e)
        {
            estado = 0;
            posicion = 0;
            lexema = "";
            lista_lexema = new ArrayList();
            lista_token = new ArrayList();
            lista_errores = new ArrayList();
            fila = 1;
            columna = 0;
            cadena = Cuerpo.Text;
            AnalizadorLexico();
            generarTablas();
            AnalizadorSintactico analizar_sintactico = new AnalizadorSintactico(lista_lexema, lista_token, lista_errores);
            GenerarHtml generarhtml = new GenerarHtml(lista_lexema, lista_token, 1);
        }
        //------------------------------------------------------------Traducir------------------------------------------
        private void Tradu_Click(object sender, EventArgs e)
        {
            estado = 0;
            posicion = 0;
            lexema = "";
            lista_lexema = new ArrayList();
            lista_token = new ArrayList();
            lista_errores = new ArrayList();
            fila = 1;
            columna = 0;
            cadena = Cuerpo.Text;
            AnalizadorLexico();
            generarTablas();
            AnalizadorSintactico analizar_sintactico = new AnalizadorSintactico(lista_lexema, lista_token, lista_errores);
            GenerarHtml generarhtml = new GenerarHtml(lista_lexema, lista_token, 0);
        }
        //------------------------------------------------------------Salir---------------------------------------------
        private void Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }







        //---------------------------------------------------------------FUNCIONES-----------------------------------------------------
        ///---------------------------------------------------------------GENERAR HTML DE SALIDA LEXEMAS,TOKENS-----------------------------------------------------------------------
        private void generarTablas()
        {
            String salida = "";
            salida += "<center><b><h1>Lista de Lexemas y Tokens</h1></b></center><center><table border=\"1\" style=\"BORDER:DOUBLE 10PX Black\">"
                    + "<tr style=\"font-weight:bold\"><td>No.</td><td>Lexema</td><td>Token</td><td>Fila</td><td>Columna</td></tr>";
            for (int i = 0; i < lista_lexema.Count; i++)
            {
                Object[] data = (Object[])lista_lexema[i];
                salida += "<tr><td>" + i + "</td><td>" + data[0] + "</td><td>" + lista_token[i] + "</td><td>" + data[1] + "</td><td>" + data[2] + "</td></tr>";
            }
            salida += "</table></center>";
            TextWriter archivo;
            archivo = new StreamWriter("TOKENS.html");
            archivo.WriteLine(salida);
            archivo.Close();


        }


        ///--------------------------------------------------------Verificar que tipo de Token es------------------------------------------------------- 
        private String typeToken(String lexema)
        {
            int type = 0;
            token = "";
            palabras_reservadas = reservadas.PalabrasReservadas();
            palabras_atributos = reservadas.Atributos();
            for (int i = 0; i < palabras_reservadas.Length; i++)
            {
                if (palabras_reservadas[i] == (lexema))
                {
                    type = 1;
                    token = "PR_" + lexema;
                }
            }
            for (int i = 0; i < palabras_atributos.Length; i++)
            {
                if (palabras_atributos[i] == lexema)
                {
                    token = "AT_" + lexema;
                    type = 2;
                }
            }
            if (type != 1 && type != 2)
            {
                token = "TX_Cadena";
            }
            return token;
        }


        ///----------------------------------------------Guardar en Arrays-------------------------------------------------------------------------------
        private void saveArray(String lexem, int line, int column)
        {
            int num_col = column - lexem.Length;
            Object[] data;
            if (num_col < 0)
            {
                data = new Object[] { lexem, line, 0 };
            }
            else
            {
                data = new Object[] { lexem, line, num_col };
            }
            lista_lexema.Add(data);
        }


        ///---------------------------------------------METODO DE ERROR---------------------------------------------
        private void error()
        {
            data = new Object[] { Char.ToString(caracter), fila, columna - 1, "PK_ERROR", "Error Lexico" };
            saveArray(lexema, fila, columna - 1);
            lista_token.Add(typeToken(lexema));
            lista_errores.Add(data);
            lexema = "";
        }


        ///<sumary>
        ///--------------------------------------------Metodo que Analizar------------------------------------------
        ///</sumary>
        private void AnalizadorLexico()
        {
            for (int i = 0; i < cadena.Length; i++)
            {
                caracter = cadena[posicion];
                switch (estado)
                {
                    case 0: // Para simbolos  
                        if (caracter == '{')
                        {
                            lexema = lexema + Char.ToString(caracter);
                            saveArray(lexema, fila, columna);
                            lista_token.Add("SG_llave_apertura");
                            lexema = "";
                        }
                        else if (caracter == '}')
                        {
                            lexema = lexema + Char.ToString(caracter);
                            saveArray(lexema, fila, columna);
                            lista_token.Add("SG_llave_clausura");
                            lexema = "";
                        }
                        else if (caracter == ':')
                        {
                            lexema = lexema + Char.ToString(caracter);
                            saveArray(lexema, fila, columna);
                            lista_token.Add("SG_dspuntos");
                            lexema = "";
                        }
                        else if (caracter == '.')
                        {
                            lexema = lexema + Char.ToString(caracter);
                            saveArray(lexema, fila, columna);
                            lista_token.Add("SG_punto");
                            lexema = "";
                        }
                        else if (caracter == ',')
                        {
                            saveArray(",", fila, columna);
                            lista_token.Add("SG_coma");
                            lexema = "";
                        }
                        else if (caracter == '[')
                        {
                            lexema = lexema + Char.ToString(caracter);
                            saveArray(lexema, fila, columna);
                            lista_token.Add("SG_corchete_apertura");
                            lexema = "";
                        }
                        else if (caracter == ']')
                        {
                            lexema = lexema + Char.ToString(caracter);
                            saveArray(lexema, fila, columna);
                            lista_token.Add("SG_corchete_clausura");
                            lexema = "";
                        }
                        else if (caracter == '(')
                        {
                            lexema = lexema + Char.ToString(caracter);
                            saveArray(lexema, fila, columna);
                            lista_token.Add("SG_parentesis_apertura");
                            lexema = "";
                        }
                        else if (caracter == ')')
                        {
                            lexema = lexema + Char.ToString(caracter);
                            saveArray(lexema, fila, columna);
                            lista_token.Add("SG_parentesis_clausura");
                            lexema = "";
                        }
                        else if (caracter == '-')
                        {
                            lexema = lexema + Char.ToString(caracter);
                            saveArray(lexema, fila, columna);
                            lista_token.Add("SG_guion");
                            lexema = "";
                        }
                        else if (caracter == '_')
                        {
                            lexema = lexema + Char.ToString(caracter);
                            saveArray(lexema, fila, columna);
                            lista_token.Add("SG_guion_bajo");
                            lexema = "";
                        }
                        else if (caracter == '!')
                        {
                            lexema = lexema + Char.ToString(caracter);
                            saveArray(lexema, fila, columna);
                            lista_token.Add("SG_admiracion_1");
                            lexema = "";
                        }
                        else if (caracter == '¡')
                        {
                            lexema = lexema + Char.ToString(caracter);
                            saveArray(lexema, fila, columna);
                            lista_token.Add("SG_admiracion_0");
                            lexema = "";
                        }
                        else if (caracter == '¿')
                        {
                            lexema = lexema + Char.ToString(caracter);
                            saveArray(lexema, fila, columna);
                            lista_token.Add("SG_pregunta_0");
                            lexema = "";
                        }
                        else if (caracter == '?')
                        {
                            lexema = lexema + Char.ToString(caracter);
                            saveArray(lexema, fila, columna);
                            lista_token.Add("SG_pregunta_1");
                            lexema = "";
                        }
                        else if (caracter == '/')
                        {
                            lexema = lexema + Char.ToString(caracter);
                        }
                        else if (caracter == '\t' || caracter == ' ' || caracter == (int)13)
                        {
                            lexema = "";
                            estado = 0;
                        }
                        else if (caracter == '\n')
                        {
                            estado = 0;
                            lexema = "";
                            fila++;
                            columna = 0;
                        }
                        else if (caracter == '\"')
                        {
                            lexema = lexema + Char.ToString(caracter);
                            saveArray(lexema, fila, columna);
                            lista_token.Add("SG_comillas");
                            lexema = "";
                        }
                        else if (caracter == '\'')
                        {
                            lexema = lexema + Char.ToString(caracter);
                            saveArray(lexema, fila, columna);
                            lista_token.Add("SG_comillas_simples");
                            lexema = "";
                        }
                        else if (Char.IsLetterOrDigit(caracter))
                        {
                            estado = 1;
                            lexema += Char.ToString(caracter);
                        }
                        else
                        {
                            error();
                        }
                        break;

                    case 1: // para letras
                        if (caracter == '{')
                        {
                            saveArray(lexema, fila, columna);
                            lista_token.Add(typeToken(lexema));

                            saveArray(Char.ToString(caracter), fila, columna);
                            lista_token.Add("SG_llave_apertura");
                            lexema = "";
                            estado = 0;
                        }
                        else if (caracter == '}')
                        {
                            saveArray(lexema, fila, columna);
                            lista_token.Add(typeToken(lexema));

                            saveArray(Char.ToString(caracter), fila, columna);
                            lista_token.Add("SG_llave_clausura");
                            lexema = "";
                            estado = 0;
                        }
                        else if (caracter == ':')
                        {
                            lexema = lexema + Char.ToString(caracter);
                        }
                        else if (caracter == '.')
                        {
                            lexema = lexema + Char.ToString(caracter);
                        }
                        else if (caracter == ',')
                        {
                            int prueba = 0;
                            bool valor = int.TryParse(lexema, out prueba);
                            if (valor)
                            {
                                saveArray(lexema, fila, columna);
                                lista_token.Add(typeToken(lexema));

                                saveArray(Char.ToString(caracter), fila, columna);
                                lista_token.Add("SG_Coma");
                                lexema = "";
                                estado = 0;
                            }
                            else
                            {
                                lexema = lexema + Char.ToString(caracter);

                            }
                        }
                        else if (caracter == '[')
                        {
                            saveArray(lexema, fila, columna);
                            lista_token.Add(typeToken(lexema));

                            saveArray(Char.ToString(caracter), fila, columna);
                            lista_token.Add("SG_corchete_apertura");
                            lexema = "";
                            estado = 0;
                        }
                        else if (caracter == ']')
                        {
                            saveArray(lexema, fila, columna);
                            lista_token.Add(typeToken(lexema));

                            saveArray(Char.ToString(caracter), fila, columna);
                            lista_token.Add("SG_corchete_clausura");
                            lexema = "";
                            estado = 0;
                        }
                        else if (caracter == '/')
                        {
                            lexema = lexema + Char.ToString(caracter);
                        }
                        else if (caracter == '\"')
                        {
                            saveArray(lexema, fila, columna - 1);
                            lista_token.Add(typeToken(lexema));

                            saveArray(Char.ToString(caracter), fila, columna);
                            lista_token.Add("SG_comillas");
                            lexema = "";
                            estado = 0;
                        }
                        else if (caracter == '\'')
                        {
                            saveArray(lexema, fila, columna);
                            lista_token.Add(typeToken(lexema));

                            saveArray(Char.ToString(caracter), fila, columna);
                            lista_token.Add("SG_comillas_simples");
                            lexema = "";
                            estado = 0;
                        }
                        else if (caracter == '(')
                        {
                            lexema = lexema + Char.ToString(caracter);
                        }
                        else if (caracter == ')')
                        {
                            lexema = lexema + Char.ToString(caracter);
                        }
                        else if (caracter == '-')
                        {
                            lexema = lexema + Char.ToString(caracter);
                        }
                        else if (caracter == '_')
                        {
                            lexema = lexema + Char.ToString(caracter);
                        }
                        else if (caracter == '!')
                        {
                            lexema = lexema + Char.ToString(caracter);
                        }
                        else if (caracter == '¡')
                        {
                            lexema = lexema + Char.ToString(caracter);
                        }
                        else if (caracter == '¿')
                        {
                            lexema = lexema + Char.ToString(caracter);
                        }
                        else if (caracter == '?')
                        {
                            lexema = lexema + Char.ToString(caracter);
                        }
                        else if (caracter == '\n')
                        {
                            fila++;
                            columna = 0;
                        }
                        else if (caracter == '\t' || caracter == ' ' || (int)caracter == 00 || (int)caracter == 92)
                        {
                            lexema = lexema + Char.ToString(caracter);
                        }
                        else if (Char.IsLetter(caracter) || Char.IsDigit(caracter))
                        {
                            lexema = lexema + Char.ToString(caracter);
                        }

                        else
                        {
                            error();
                        }
                        break;

                    default:
                        break;
                }
                posicion++;
                columna++;
            }
        }

        private void Cuerpo_MouseClick(object sender, MouseEventArgs e)
        {
            int Position = Cuerpo.SelectionStart;
            int Line = Cuerpo.GetLineFromCharIndex(Position)+1;
            int Colunm = Position - Cuerpo.GetFirstCharIndexOfCurrentLine();
            Punto.Text = "Fila: " + Line + "   Columna: " + Colunm;
        }

        private void Cuerpo_KeyUp(object sender, KeyEventArgs e)
        {
            int Position = Cuerpo.SelectionStart;
            int Line = Cuerpo.GetLineFromCharIndex(Position) + 1;
            int Colunm = Position - Cuerpo.GetFirstCharIndexOfCurrentLine();
            Punto.Text = "Fila: " + Line + "   Columna: " + Colunm;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string pdfPath = Path.Combine(Application.StartupPath, "Manual Tecnico.pdf");
            Process.Start(pdfPath);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string pdfPath = Path.Combine(Application.StartupPath, "Manual Usuario.pdf");
            Process.Start(pdfPath);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
