using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Parsing;

namespace Proyectocompi2
{
    class Gramatica : Grammar
    {

        public Gramatica() : base(caseSensitive: true)
        {
            //---------------------> Comentarios
            CommentTerminal COMENTARIO_SIMPLE = new CommentTerminal("comentario_simple", "!!", "\n", "\r\n");
            CommentTerminal COMENTARIO_MULT = new CommentTerminal("comentario_mult", "<<", ">>");
            NonGrammarTerminals.Add(COMENTARIO_SIMPLE);
            NonGrammarTerminals.Add(COMENTARIO_MULT);

            /*--------------------Definir Palabras Reservadas ----------------*/
            MarkReservedWords("Importar");
            MarkReservedWords("Definir");
            MarkReservedWords("Double");
            MarkReservedWords("String");
            MarkReservedWords("Bool");
            MarkReservedWords("Int");
            MarkReservedWords("Char");
            MarkReservedWords("Retorno");
            MarkReservedWords("Vacio");
            MarkReservedWords("Principal");
            MarkReservedWords("Si");
            MarkReservedWords("Sino");
            MarkReservedWords("Selecciona");
            MarkReservedWords("Defecto");
            MarkReservedWords("Para");
            MarkReservedWords("Hasta");
            MarkReservedWords("Mientras");
            MarkReservedWords("Detener");
            MarkReservedWords("Continuar");
            MarkReservedWords("Mostrar");
            MarkReservedWords("DibujarAST");
            MarkReservedWords("DibujarEXP");
            MarkReservedWords("DibujarTS");


            /*--------------------- (Opcional)Definir variables para palabras reservadas--*/

            var mas = ToTerm("+");
            var punto = ToTerm(".");
            var menos = ToTerm("-");
            var por = ToTerm("*");
            var division = ToTerm("/");
            var potencia = ToTerm("^");
            var igual = ToTerm("=");
            var porc = ToTerm("%");

            var allave = ToTerm("{");
            var cllave = ToTerm("}");
            var apar = ToTerm("(");
            var cpar = ToTerm(")");
            var coma = ToTerm(",");
            var dospuntos = ToTerm(":");
            var puntocoma = ToTerm(";");
            var llavea = ToTerm("{");
            var llavec = ToTerm("}");
            var trues = ToTerm("true");
            var falses = ToTerm("false");

            /*-------------relacionales------------------*/
            var igualigual = ToTerm("==");
            var diferente = ToTerm("!=");
            var mayor = ToTerm(">");
            var menor = ToTerm("<");
            var mayorigual = ToTerm(">=");
            var menorigual = ToTerm("<=");
            var incerteza = ToTerm("~");
            var masmas = ToTerm("++");
            var menosmenos = ToTerm("--");
            /*--------------------expresiones logicas---------*/
            var or = ToTerm("||");
            var and = ToTerm("&&");
            var not = ToTerm("!");
            var xor = ToTerm("|&");

            /*----------------------palabras-------*/
            var importar = ToTerm("Importar");
            var definir = ToTerm("Definir");
            var vadouble = ToTerm("Double");
            var vastring = ToTerm("String");
            var varint = ToTerm("Int");
            var vabool = ToTerm("Bool");
            var vachar = ToTerm("Char");
            var retorno = ToTerm("Retorno");
            var vacio = ToTerm("Vacio");
            var principal = ToTerm("Principal");
            var si = ToTerm("Si");
            var sino = ToTerm("Sino");
            var selecciona = ToTerm("Selecciona");
            var defecto = ToTerm("Defecto");
            var para = ToTerm("Para");
            var hasta = ToTerm("Hasta");
            var mientras = ToTerm("Mientras");
            var detener = ToTerm("Detener");
            var continuar = ToTerm("Continuar");
            var mostrar = ToTerm("Mostrar");
            var dibast = ToTerm("DibujarAST");
            var dibexp = ToTerm("DibujarEXP");
            var dibts = ToTerm("DibujarTS");





            /*--------------------- No Terminales --------*/
            var INICIO = new NonTerminal("INICIO");
            var LISTA = new NonTerminal("LISTA");
            var ESTRUC = new NonTerminal("ESTRUC");
            var DECLARACION = new NonTerminal("DECLARACION");
            var DECLARACION2 = new NonTerminal("DECLARACION2");
            var EXPRESION = new NonTerminal("EXPRESION");

            var EXPRESION2 = new NonTerminal("EXPRESION2");
            var CTIPO = new NonTerminal("CTIPO");
            var VARIOS = new NonTerminal("VARIOS");
            var ESTRUCTURA = new NonTerminal("ESTRUCTURA");
            var ENCABEZADO = new NonTerminal("ENCABEZADO");
            var TIPO = new NonTerminal("TIPO");
            var CUERPO = new NonTerminal("CUERPO");
            var ASIGNACION = new NonTerminal("ASIGNACION");
            var ASIGNACION2 = new NonTerminal("ASIGNACION2");
            var FUN = new NonTerminal("FUN");
            var METOD = new NonTerminal("METOD");
            var LISTA2 = new NonTerminal("LISTA2");
            var DECLAPARA = new NonTerminal("DECLAPARA");
            var PARAMETROS = new NonTerminal("PARAMETROS");
            var ESTRUC2 = new NonTerminal("ESTRUC2");
            var FUNPRIN = new NonTerminal("FUNPRIN");
            var LISTA3 = new NonTerminal("LISTA3");
            var ESTRUC3 = new NonTerminal("ESTRUC3");
            var LLAMADAS = new NonTerminal("LLAMADAS");
            var RETORN = new NonTerminal("RETORN");
            var SENTSI = new NonTerminal("SENTSI");
            var SENTSINO = new NonTerminal("SENTSINO");
            var SENTHASTA = new NonTerminal("SENTHASTA");
            var SENTMIENTRAS = new NonTerminal("SENTMIENTRAS");
            var SENTPARA = new NonTerminal("SENTPARA");
            var SENTSELECCIONA = new NonTerminal("SENTSELECCIONA");
            var CASO = new NonTerminal("CASO");
            var DEFECT = new NonTerminal("DEFECT");
            var PRINT = new NonTerminal("PRINT");
            var DIBAST = new NonTerminal("DIBAST");
            var DIBEXP = new NonTerminal("DIBEXP");
            var DIBTS = new NonTerminal("DIBTS");
            var LLAMAR = new NonTerminal("LLAMAR");
            var VARIOS2 = new NonTerminal("VARIOS2");

            //---------------------> Terminales
            var tString = new StringLiteral("tString", "\"", StringOptions.AllowsDoubledQuote);
            var tchar = new StringLiteral("tchar", "\'", StringOptions.AllowsDoubledQuote);
            NumberLiteral numero = TerminalFactory.CreateCSharpNumber("numero");
            IdentifierTerminal id = TerminalFactory.CreateCSharpIdentifier("id");


            //---------------------> No Terminal Inicial
            this.Root = INICIO;

            //---------------------> Producciones ------------------------------------------
            INICIO.Rule = ENCABEZADO + LISTA;

            ENCABEZADO.Rule = importar + id + punto + id + puntocoma + ENCABEZADO 
                | definir + CTIPO + puntocoma + ENCABEZADO|Empty;



            LISTA.Rule = MakeStarRule(LISTA, ESTRUC);

            /*----------------------lo que puede llevar todo el programa-----------------*/
            ESTRUC.Rule = DECLARACION
                          |ASIGNACION
                          |FUN
                          |METOD
                          |FUNPRIN
                          ;




            /*---------------------------lo que llevan las funciones y metodos----------------------*/
            LISTA2.Rule = MakeStarRule(LISTA2, ESTRUC2);

            ESTRUC2.Rule = DECLARACION2
                         | ASIGNACION2
                         |LLAMADAS
                         |RETORN
                         |SENTSI
                         |SENTPARA
                         |SENTMIENTRAS
                         |SENTHASTA
                         |SENTSELECCIONA
                         | DIBEXP
                         | DIBAST
                         | DIBTS|PRINT;


            /*----------------------------puede llevar funcion principal y otros  ---------*/
            LISTA3.Rule = MakeStarRule(LISTA3, ESTRUC3);

            ESTRUC3.Rule = DECLARACION2
                         | ASIGNACION2
                         | LLAMADAS
                         | detener + puntocoma
                         |continuar + puntocoma
                         | SENTSI
                         | SENTPARA
                         | SENTMIENTRAS
                         | SENTHASTA
                         | SENTSELECCIONA
                         |DIBEXP
                         |DIBAST
                         |DIBTS
                         |PRINT
                         |RETORN;



            /*------------------------------DECLArACION y asignacion---------------------------*/


            DECLARACION.Rule = TIPO + VARIOS + igual + EXPRESION + puntocoma
                               |TIPO +VARIOS+puntocoma;


            ASIGNACION.Rule = id + igual + EXPRESION + puntocoma;

            DECLARACION2.Rule = TIPO + VARIOS + igual + EXPRESION + puntocoma
                                | TIPO + VARIOS + puntocoma;


            ASIGNACION2.Rule = id + igual + EXPRESION + puntocoma;

            VARIOS.Rule = CTIPO + coma + VARIOS | CTIPO;
            VARIOS2.Rule = coma+EXPRESION + VARIOS2 | Empty;

            CTIPO.Rule = tString | tchar | numero | id;




            TIPO.Rule = vabool | vachar | vadouble | varint | vastring;


            /*---------------------metodos funciones----------------------*/

            FUN.Rule = TIPO + id + apar + DECLAPARA + cpar + allave + LISTA2 + cllave;

            METOD.Rule = vacio + id + apar + DECLAPARA + cpar + allave + LISTA2 + cllave;

            PARAMETROS.Rule = EXPRESION
                            | EXPRESION + coma + PARAMETROS
                            | Empty;

            DECLAPARA.Rule = TIPO + id + coma + DECLAPARA
                            | TIPO + id
                            | Empty;
            LLAMAR.Rule = id + apar + PARAMETROS + cpar;

            /*-------------------funcion principal----------------------*/

            FUNPRIN.Rule = vacio + principal + apar + cpar + allave + LISTA3 + cllave;



            /*--------------llamdas a funciones ----------*/

            LLAMADAS.Rule = id + apar + PARAMETROS + cpar + puntocoma;


            /*----------------retornar-------------*/

            RETORN.Rule = retorno + EXPRESION + puntocoma | retorno + puntocoma;



            /*----------------------sentencia si---------------*/


            SENTSI.Rule = si + apar + EXPRESION + cpar + allave + LISTA3 + cllave  + SENTSINO;

            SENTSINO.Rule = sino + allave + LISTA3 + cllave | Empty;

            /*-----------------sentencia selecciona-------------*/

            SENTSELECCIONA.Rule = selecciona + apar + EXPRESION + cpar + llavea + CASO + DEFECT + cllave;

            CASO.Rule = EXPRESION + dospuntos + LISTA3+CASO |  Empty;

            DEFECT.Rule = defecto + dospuntos + LISTA3 | Empty;



            /*----------------------sentencia para-------------------*/

            SENTPARA.Rule = para + apar + vadouble + id + igual + EXPRESION + puntocoma + EXPRESION + puntocoma + masmas+cpar+allave+LISTA3+cllave
                    | para + apar + vadouble + id + igual + EXPRESION + puntocoma + EXPRESION + puntocoma + menosmenos + cpar + allave + LISTA3 + cllave;


            /*-------------------------sentencia hasta ------------*/


            SENTHASTA.Rule = hasta + apar + EXPRESION + cpar + allave + LISTA3 + cllave;


            /*------------sentencias mientras ---------------*/


            SENTMIENTRAS.Rule = mientras + apar + EXPRESION + cpar + allave + LISTA3 + cllave;

            /*------------------------mostrar----*/

            PRINT.Rule = mostrar + apar +tString+ VARIOS2 + cpar + puntocoma;

            /*----------------funcion dibujar ast-----------*/

            DIBAST.Rule = dibast + apar + id + cpar+ puntocoma;

            /*--------------------funcion dibujar exp------*/

            DIBEXP.Rule = dibexp + apar + EXPRESION2 + cpar + puntocoma;


            /*------------------------------------------dibujar ts-------------------*/

            DIBTS.Rule = dibts + apar + cpar + puntocoma;

            EXPRESION.Rule = EXPRESION + or + EXPRESION
                           | EXPRESION + and + EXPRESION
                           |  not + EXPRESION
                           | EXPRESION + xor + EXPRESION
                           | EXPRESION + igualigual + EXPRESION
                           | EXPRESION + diferente + EXPRESION
                           | EXPRESION + mayor + EXPRESION
                           | EXPRESION + menor + EXPRESION
                           | EXPRESION + mayorigual + EXPRESION
                           | EXPRESION + menorigual + EXPRESION
                           | EXPRESION + mas + EXPRESION
                           | EXPRESION + menos + EXPRESION
                           | EXPRESION + por + EXPRESION
                           | EXPRESION + potencia + EXPRESION
                           | EXPRESION + division + EXPRESION
                           | EXPRESION + incerteza + EXPRESION
                           | apar + EXPRESION + cpar
                           | EXPRESION + porc + EXPRESION
                           | id
                           | LLAMAR
                           | numero
                           | tString
                           | tchar
                           | trues
                           | falses
                           | menos + EXPRESION;
                          // | distinto + EXPRESION
                           


            /*-----------------para dibujar expresion-----------------*/

            EXPRESION2.Rule = EXPRESION2 + or + EXPRESION2
                           | EXPRESION2 + and + EXPRESION2
                           |  not + EXPRESION2
                           | EXPRESION2 + xor + EXPRESION2
                           | EXPRESION2 + diferente + EXPRESION2
                           | EXPRESION2 + mayor + EXPRESION2
                           | EXPRESION2 + menor + EXPRESION2
                           | EXPRESION2 + mayorigual + EXPRESION2
                           | EXPRESION2 + menorigual + EXPRESION2
                           | EXPRESION2 + mas + EXPRESION2
                           | EXPRESION2 + menos + EXPRESION2
                           | EXPRESION2 + por + EXPRESION2
                           | EXPRESION2 + potencia + EXPRESION2
                           | EXPRESION2 + division + EXPRESION2
                           | EXPRESION2 + incerteza + EXPRESION2
                           | apar + EXPRESION2 + cpar
                           | EXPRESION2 + igualigual + EXPRESION2
                           | EXPRESION2 + porc + EXPRESION2
                           | id
                           | LLAMAR
                           | numero
                           | tString
                           | tchar
                           | trues
                           | falses
                           | menos + EXPRESION;
            // | distinto + EXPRESION
            














            //---------------------> Definir Asociatividad
            RegisterOperators(1, Associativity.Left, "||");                 //OR
            RegisterOperators(2, Associativity.Left, "&&");                 //AND
            RegisterOperators(7, Associativity.Left, "!");                 //NOT
            RegisterOperators(7, Associativity.Left, "|&");                 //NOT
            RegisterOperators(5, Associativity.Left, "+", "-");             //MAS, MENOS
            RegisterOperators(6, Associativity.Left, "*", "/","%");             //POR, DIVIDIR
            RegisterOperators(6, Associativity.Right, "^");             //POTENCIA


            ESTRUC.ErrorRule = SyntaxError + ESTRUC;
            ESTRUC2.ErrorRule = SyntaxError + ESTRUC2;

            ESTRUC3.ErrorRule = SyntaxError + ESTRUC3;
        }
        }
}
