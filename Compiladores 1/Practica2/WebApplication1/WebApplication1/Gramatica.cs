using System;
using System.Collections.Generic;
using System.Web;
using Irony.Parsing;
using Irony.Ast;

namespace WebApplication1
{
    public class Gramatica:Grammar
    {
        public Gramatica() : base(caseSensitive: true)
        {
            //------------------------------------------------------------------------Expresiones Regulares-----------------------------------------------
            #region ER
            NumberLiteral numero = TerminalFactory.CreateCSharpNumber("numero");
            IdentifierTerminal id = TerminalFactory.CreateCSharpIdentifier("id");
            #endregion

            //--------------------------------------------------------------------------Palabras Reservadas-----------------------------------------------------------
            #region PalabrasReservadas
            MarkReservedWords("imprimir");
            MarkReservedWords("raiz");
            MarkReservedWords("graficar");
            MarkReservedWords("programa");
            MarkReservedWords("var");
            MarkReservedWords("double");
            MarkReservedWords("string");
            MarkReservedWords("int");
            MarkReservedWords("bool");
            MarkReservedWords("OR");
            MarkReservedWords("AND");
            MarkReservedWords("NOT");
            MarkReservedWords("retornar");
            MarkReservedWords("void");
            MarkReservedWords("principal");
            MarkReservedWords("SI");
            MarkReservedWords("SINO_SI");
            MarkReservedWords("SINO");
            MarkReservedWords("INTERRUMPIR");
            MarkReservedWords("CASO");
            MarkReservedWords("DEFECTO");
            MarkReservedWords("MIENTRAS");
            MarkReservedWords("HACER");
            MarkReservedWords("salir");
            #endregion



            #region Terminales
            var mas = ToTerm("+");
            var menos = ToTerm("-");
            var por = ToTerm("*");
            var division = ToTerm("/");
            var potencia = ToTerm("^");

            var parentesis = ToTerm("(");
            var imprimir = ToTerm("imprimir");
            var raiz = ToTerm("raiz");
            var graficar = ToTerm("graficar");
            var programa = ToTerm("programa");
            var variable = ToTerm("var");
            var vadouble = ToTerm("double");
            var vastring = ToTerm("string");
            var varint = ToTerm("int");
            var vabool = ToTerm("bool");
            var or = ToTerm("OR");
            var and = ToTerm("AND");
            var retornar = ToTerm("retornar");
            var tvoid = ToTerm("void");
            var principal = ToTerm("principal");
            var si = ToTerm("SI");
            var sinosi = ToTerm("SINO_SI");
            var sino = ToTerm("SINO");
            var interruptor = ToTerm("INTERRUMPIR");
            var caso = ToTerm("CASO");
            var defecto = ToTerm("DEFECTO");
            var mientras = ToTerm("MIENTRAS");
            var hacer = ToTerm("HACER");
            var salir = ToTerm("salir");

            var tString = new StringLiteral("tString", "\"", StringOptions.AllowsDoubledQuote);
            var tchar = new StringLiteral("tchar", "\'", StringOptions.AllowsDoubledQuote);

            var mayor = ToTerm(">");
            var menor = ToTerm("<");
            var mayorigual = ToTerm(">=");
            var menorigual = ToTerm("<=");
            var igualigual = ToTerm("==");
            var diferente = ToTerm("!=");

            var asignacion = ToTerm("::=");
            var puntocoma = ToTerm(";");

            var opencorch = ToTerm("[");
            var closecorch = ToTerm("]");
            var openpare = ToTerm("(");
            var closepare = ToTerm(")");
            var coma = ToTerm(",");

            var trues = ToTerm("true");
            var falses = ToTerm("false");
            var negacion = ToTerm("!");
            #endregion


            #region Noterminales
            var INICIO = new NonTerminal("INICIO");
            var CUERPO = new NonTerminal("CUERPO");
            var ESTRUCTURA = new NonTerminal("ESTRUCTURA");
            var CUERPO2 = new NonTerminal("CUERPO2");
            var ESTRUCTURA2 = new NonTerminal("ESTRUCTURA2");
            var IMPRIMIR = new NonTerminal("IMPRIMIR");
            var EXPRESION = new NonTerminal("EXPRESION");
            var LLAMADAFUNC = new NonTerminal("LLAMADAFUNC");
            var RAIZZ = new NonTerminal("RAIZ");
            var GRAFICAR = new NonTerminal("GRAFICAR");
            var DECLARACION = new NonTerminal("DECLARACION");
            var DECLARACION2 = new NonTerminal("DECLARACION2");
            var MULTIVAR = new NonTerminal("MULTIVAR");
            var ASIGNACION = new NonTerminal("ASIGNACION");
            var DECLASIGNA = new NonTerminal("DECLAASIGNA");
            var DECLASIGNA2 = new NonTerminal("DECLAASIGNA2");
            var METOFUNC = new NonTerminal("METOFUNC");
            var TIPO = new NonTerminal("TIPO");
            var CUERPOME = new NonTerminal("CUERPOME");
            var ESTRUCTURAME = new NonTerminal("ESTRUCTURAME");
            var RETORNAR = new NonTerminal("RETORNAR");
            var PARAMETROS = new NonTerminal("PARAMETROS");
            var MVOID = new NonTerminal("MVOID");
            var PRINCIPAL = new NonTerminal("PRINCIPAL");
            var CIF = new NonTerminal("CIF");
            var CONDICION = new NonTerminal("CONDICION");
            var SINOSI = new NonTerminal("SINOSI");
            var SINO = new NonTerminal("SINO");
            var CINTERRUMPIR = new NonTerminal("CINTERRUMPIR");
            var CASO = new NonTerminal("CASO");
            var DEFECTO = new NonTerminal("DEFECTO");
            var CMIENTRAS = new NonTerminal("CMIENTRAS");
            var CHACER = new NonTerminal("CHACER");
            var SALIR = new NonTerminal("SALIR");
            var DECLAPARA = new NonTerminal("DECLAPARA");
            var PARALLAMA = new NonTerminal("PARALLAMA");
            #endregion

            //---------------------------------------------------------------------PRODUCCIONES-----------------------------------------------------------
            #region producciones
            this.Root = INICIO;

            INICIO.Rule = programa + id + opencorch + CUERPO2 + closecorch;

            CUERPO2.Rule = MakeStarRule(CUERPO2, ESTRUCTURA2);


            ESTRUCTURA2.Rule = DECLARACION2
                              | DECLASIGNA2
                              | METOFUNC
                              | MVOID
                              | PRINCIPAL;


            CUERPO.Rule = MakeStarRule(CUERPO, ESTRUCTURA);

            ESTRUCTURA.Rule = IMPRIMIR
                              | GRAFICAR
                              | DECLARACION
                              | ASIGNACION
                              | DECLASIGNA
                              | LLAMADAFUNC
                              | CIF
                              | CINTERRUMPIR
                              | CMIENTRAS
                              | CHACER
                              |RETORNAR;

            CUERPOME.Rule = MakeStarRule(CUERPOME, ESTRUCTURAME);

            ESTRUCTURAME.Rule = IMPRIMIR
                              | GRAFICAR
                              | DECLARACION
                              | ASIGNACION
                              | DECLASIGNA
                              | LLAMADAFUNC
                              | CIF
                              | CINTERRUMPIR
                              | CMIENTRAS
                              | CHACER
                              | RETORNAR
                              | SALIR ;
            //----------------------------------------------------------------IMPRIMIR-----------------------------------------------

            IMPRIMIR.Rule = imprimir + openpare + EXPRESION + closepare + puntocoma;

            //--------------------------------------------------------------RAIZ CUADRADA------------------------------------------------------
            RAIZZ.Rule = raiz + openpare + EXPRESION + coma + EXPRESION + closepare ;

            //-----------------------------------------------------------------GRAFICAR-----------------------------------------------------------

            GRAFICAR.Rule = graficar + openpare + "\"x\"" + coma + EXPRESION + coma + numero + coma + numero + coma +  tString + closepare + puntocoma
                            | graficar + openpare + "\"y\"" + coma + EXPRESION + coma + numero + coma + numero + coma +  tString+  closepare + puntocoma;

            //-----------------------------------------------------------------DECLARACION DE VARIABLES------------------------------------------------
            DECLARACION.Rule = variable + MULTIVAR + puntocoma;
            DECLARACION2.Rule = variable + MULTIVAR + puntocoma;
            MULTIVAR.Rule = id + coma + MULTIVAR | id;
            //-----------------------------------------------------------------ASIGNACION DE VARIABLES----------------------------------------------
            ASIGNACION.Rule = id + asignacion + EXPRESION + puntocoma;
            //------------------------------------------------------------------ASIGNACION Y DECLARACION-----------------------------------------------
            DECLASIGNA.Rule = variable + MULTIVAR + asignacion + EXPRESION + puntocoma;
            DECLASIGNA2.Rule = variable + MULTIVAR + asignacion + EXPRESION + puntocoma;
            //-------------------------------------------------------------------------FUNCIONES------------------------------------------------------
            METOFUNC.Rule = TIPO + id + openpare + DECLAPARA + closepare + opencorch + CUERPOME + closecorch;
            TIPO.Rule = varint | vastring | vadouble;
            PARAMETROS.Rule = EXPRESION
                            | EXPRESION + coma + PARAMETROS
                            | Empty;
            DECLAPARA.Rule = variable + id + coma + DECLAPARA
                            | variable + id
                            | Empty;
            //-----------------------------------------------------------------------METODO VOID-------------------------------------------------------
            MVOID.Rule = tvoid + id + openpare + DECLAPARA + closepare + opencorch + CUERPO + closecorch;


            //----------------------------------------------------------------RETORNAR------------------------------------------------------
            RETORNAR.Rule = retornar + EXPRESION + puntocoma;
            //-------------------------------------------------------------------LLAMADA A FUNCION-------------------------------------------
            LLAMADAFUNC.Rule = id + openpare + PARAMETROS + closepare + puntocoma;
            PARALLAMA.Rule = id + openpare + PARAMETROS + closepare;
            //-------------------------------------------------------------------METODO PRINCIPAL-----------------------------------------------
            PRINCIPAL.Rule = principal + openpare + closepare + opencorch + CUERPO + closecorch;

            //--------------------------------------------------------------------CONTROL IF--------------------------------------------------------
            CIF.Rule = si + openpare + EXPRESION + closepare + opencorch + CUERPO + closecorch + SINOSI + SINO;

            //--------------------------------------------------------------ELSE IF----------------------------------------------------------------
            SINOSI.Rule = sinosi + openpare + EXPRESION + closepare + opencorch + CUERPO + closecorch + SINOSI | Empty;
            //-----------------------------------------------------------------ELSE-------------------------------------------------------------------
            SINO.Rule = sino + opencorch + CUERPO + closecorch | Empty;

            //------------------------------------------------------------------CONTROL SWITCH----------------------------------------------------------
            CINTERRUMPIR.Rule = interruptor + openpare + EXPRESION + closepare + opencorch + CASO + DEFECTO + closecorch;

            //------------------------------------------------------------------- CASE-----------------------------------------------------------------
            CASO.Rule = caso + numero + ":" + CUERPO + CASO
                        | caso + id + ":" + CUERPO + CASO
                        |Empty;

            //-------------------------------------------------------------------------DEFAULT------------------------------------------------------------
            DEFECTO.Rule = defecto + ":" + CUERPO
                           |Empty;

            //----------------------------------------------------------------------------WHILE-----------------------------------------------------------------
            CMIENTRAS.Rule = mientras + openpare + EXPRESION + closepare + opencorch + CUERPOME + closecorch;

            //-----------------------------------------------------------------------DO WHILE-------------------------------------------------------------------
            CHACER.Rule = hacer + opencorch + CUERPOME + closecorch + mientras + openpare + EXPRESION + closepare + puntocoma;

            //-----------------------------------------------------------------------BREAK----------------------------------------------------------------
            SALIR.Rule = salir + puntocoma;

            //-----------------------------------------------------------------------EXPRESION-----------------------------------------------------------------
            EXPRESION.Rule = EXPRESION + or + EXPRESION
                            | EXPRESION + and + EXPRESION
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
                            | openpare + EXPRESION + closepare
                            | negacion + EXPRESION
                            | id
                            | numero
                            | tString
                            | tchar
                            | trues
                            | falses
                            | RAIZZ
                            | PARALLAMA;
            #endregion

            #region comentarios
            //---------------------> Comentarios
            CommentTerminal COMENTARIO_SIMPLE = new CommentTerminal("comentario_simple", "//", "\n", "\r\n");
            CommentTerminal COMENTARIO_MULT = new CommentTerminal("comentario_mult", "/*", "*/");
            NonGrammarTerminals.Add(COMENTARIO_SIMPLE);
            NonGrammarTerminals.Add(COMENTARIO_MULT);
            #endregion

            //---------------------> Definir Asociatividad
            RegisterOperators(1, Associativity.Left, "||");                 //OR
            RegisterOperators(2, Associativity.Left, "&&");                 //AND
            RegisterOperators(3, Associativity.Left, "==", "!=");           //IGUAL, DIFERENTE
            RegisterOperators(4, Associativity.Left, ">", "<", ">=", "<="); //MAYORQUES, MENORQUES
            RegisterOperators(5, Associativity.Left, "+", "-");             //MAS, MENOS
            RegisterOperators(6, Associativity.Left, "*", "/");             //POR, DIVIDIR
            RegisterOperators(6, Associativity.Left, "^");             //POTENCIA
            RegisterOperators(7, Associativity.Right, "!");                 //NOT

            //---------------------------------------------------MANEJO DE ERRORES-------------------------------------------------------------------
            ESTRUCTURA.ErrorRule = SyntaxError + ESTRUCTURA;
            ESTRUCTURA2.ErrorRule = SyntaxError + ESTRUCTURA2;
            ESTRUCTURAME.ErrorRule = SyntaxError + ESTRUCTURAME;
        }
    }
}