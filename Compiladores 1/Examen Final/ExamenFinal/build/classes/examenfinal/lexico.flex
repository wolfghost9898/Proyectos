package examenfinal;
import java_cup.runtime.*;
import javax.swing.*;
import java.util.*;

%%
%state A
%cupsym sym
%cup

%class Lexico
%public
%line
%char
%column

LETRA=[a-zA-Z_\u00e1\u00e9\u00ed\u00f3\u00fa\u00c1\u00c9\u00cd\u00d3\u00da\u00f1\u00d1]
NUM=[0-9]
SIM=[/*-+_:;[]{}()=,.!\\]

NUMN=-[0-9]
DECIM={NUM}+"."{NUM}+
LD={LETRA}|{NUM}|{NUMN}
WHITE=([\ |\t|\f]|\n)
ESPACIO=[ ]
CAD="\""({SIM}*{ID}*{LD}*{WHITE}*{SIM}*{LD}*)+"\""
ID="\'"({SIM}*{LD}+{WHITE}*{SIM}*{LD}*)+"\'"
IDENTIFICADOR=({LETRA}{LD}*)
COM="!!"({ESPACIO}*{SIM}*{LD}*{CAD}*{SIM}*)+
COMENTARIO="<<"({WHITE}*{SIM}*{LD}*{CAD}*{SIM}*)+">>"

%%

/*-------------------------------------------------COMIENZA EL LENGAUEJE----------------------------------------*/

<YYINITIAL> {WHITE}  {/*no hace nada, aumenta una columna*/}

<YYINITIAL>">="     {return new Symbol(sym.MAYORIGUAL,yyline, yycolumn, yytext());}
<YYINITIAL>"<="     {return new Symbol(sym.MENORIGUAL,yyline, yycolumn, yytext());}
<YYINITIAL>">"      {return new Symbol(sym.MAYOR,     yyline, yycolumn, yytext());}
<YYINITIAL>"<"      {return new Symbol(sym.MENOR,     yyline, yycolumn, yytext());}
<YYINITIAL>"="      {return new Symbol(sym.IGUAL,     yyline, yycolumn, yytext());}
<YYINITIAL>"+"      {return new Symbol(sym.MAS,    yyline, yycolumn, yytext());}
<YYINITIAL>"-"      {return new Symbol(sym.MENOS,    yyline, yycolumn, yytext());}
<YYINITIAL>"/"      {return new Symbol(sym.DIVISION,    yyline, yycolumn, yytext());}
<YYINITIAL>"*"      {return new Symbol(sym.MULTIPLICACION,    yyline, yycolumn, yytext());}
<YYINITIAL>"."      {return new Symbol(sym.PUNTO,    yyline, yycolumn, yytext());}
<YYINITIAL>","      {return new Symbol(sym.COMA,    yyline, yycolumn, yytext());}
<YYINITIAL>"["      {return new Symbol(sym.CORA,      yyline, yycolumn, yytext());}
<YYINITIAL>"]"      {return new Symbol(sym.CORC,     yyline, yycolumn, yytext());}
<YYINITIAL>"("      {return new Symbol(sym.PARAB,      yyline, yycolumn, yytext());}
<YYINITIAL>")"      {return new Symbol(sym.PARC,     yyline, yycolumn, yytext());}
<YYINITIAL>";"      {return new Symbol(sym.PUNTOCOMA,     yyline, yycolumn, yytext());}
<YYINITIAL>":"      {return new Symbol(sym.DOSPUNTOS,     yyline, yycolumn, yytext());}
<YYINITIAL>"{"      {return new Symbol(sym.LLAVEA,     yyline, yycolumn, yytext());}
<YYINITIAL>"}"      {return new Symbol(sym.LLAVEC,     yyline, yycolumn, yytext());}
<YYINITIAL>"++"      {return new Symbol(sym.INCREMENTO,     yyline, yycolumn, yytext());}
<YYINITIAL>"--"      {return new Symbol(sym.DECREMENTO,     yyline, yycolumn, yytext());}
<YYINITIAL>"^"      {return new Symbol(sym.POT,     yyline, yycolumn, yytext());}
<YYINITIAL>"\\"      {return new Symbol(sym.INVERS,     yyline, yycolumn, yytext());}
<YYINITIAL>"=="      {return new Symbol(sym.IGUALIGUAL,     yyline, yycolumn, yytext());}
<YYINITIAL>"!="      {return new Symbol(sym.DISTINTO,     yyline, yycolumn, yytext());}
<YYINITIAL>"&&"      {return new Symbol(sym.AND,     yyline, yycolumn, yytext());}
<YYINITIAL>"||"      {return new Symbol(sym.OR,     yyline, yycolumn, yytext());}
<YYINITIAL>"!"      {return new Symbol(sym.NOT,     yyline, yycolumn, yytext());}
<YYINITIAL>"!&"      {return new Symbol(sym.XOR,     yyline, yycolumn, yytext());}
<YYINITIAL>"%"      {return new Symbol(sym.PORCENTAJE,     yyline, yycolumn, yytext());}
<YYINITIAL>"~"      {return new Symbol(sym.DIFERENCIA,     yyline, yycolumn, yytext());}
<YYINITIAL>"'"      {return new Symbol(sym.APOSTROFE,     yyline, yycolumn, yytext());}

<YYINITIAL>"Importar"     {return new Symbol(sym.IMPORTAR, yyline, yycolumn, yytext());}
<YYINITIAL>"Definir"     {return new Symbol(sym.DEFINIR, yyline, yycolumn, yytext());}
<YYINITIAL>"Bool"      {return new Symbol(sym.BOOL,    yyline, yycolumn, yytext());}
<YYINITIAL>"Char"      {return new Symbol(sym.CHAR,    yyline, yycolumn, yytext());}
<YYINITIAL>"Double"      {return new Symbol(sym.DOUBLE,    yyline, yycolumn, yytext());}
<YYINITIAL>"Int"      {return new Symbol(sym.INT,    yyline, yycolumn, yytext());}
<YYINITIAL>"String"      {return new Symbol(sym.STRING,    yyline, yycolumn, yytext());}
<YYINITIAL>"Vacio"      {return new Symbol(sym.VACIO,    yyline, yycolumn, yytext());}
<YYINITIAL>"Retorno"      {return new Symbol(sym.RETORNO,    yyline, yycolumn, yytext());}
<YYINITIAL>"Principal"      {return new Symbol(sym.PRINCIPAL,    yyline, yycolumn, yytext());}
<YYINITIAL>"Si"      {return new Symbol(sym.SI,    yyline, yycolumn, yytext());}
<YYINITIAL>"Sino"      {return new Symbol(sym.SINO,    yyline, yycolumn, yytext());}
<YYINITIAL>"Selecciona"      {return new Symbol(sym.SELECCIONA,    yyline, yycolumn, yytext());}
<YYINITIAL>"Defecto"      {return new Symbol(sym.DEFECTO,    yyline, yycolumn, yytext());}
<YYINITIAL>"Para"      {return new Symbol(sym.PARA,    yyline, yycolumn, yytext());}
<YYINITIAL>"Hasta"      {return new Symbol(sym.HASTA,    yyline, yycolumn, yytext());}
<YYINITIAL>"Mientras"      {return new Symbol(sym.MIENTRAS,    yyline, yycolumn, yytext());}
<YYINITIAL>"Detener"      {return new Symbol(sym.DETENER,    yyline, yycolumn, yytext());}
<YYINITIAL>"Continuar"      {return new Symbol(sym.CONTINUAR,    yyline, yycolumn, yytext());}
<YYINITIAL>"Mostrar"      {return new Symbol(sym.MOSTRAR,    yyline, yycolumn, yytext());}
<YYINITIAL>"DibujarAST"      {return new Symbol(sym.DIBUJARAST,    yyline, yycolumn, yytext());}
<YYINITIAL>"DibujarEXP"      {return new Symbol(sym.DIBUJAREXP,    yyline, yycolumn, yytext());}
<YYINITIAL>"DibujarTS"      {return new Symbol(sym.DIBUJARTS,    yyline, yycolumn, yytext());}

/*--------------------ID DIGITOS Y CADENA-------------------------*/
<YYINITIAL>{IDENTIFICADOR} {return new Symbol(sym.IDENTIFICADOR,     yyline, yycolumn, yytext());}
<YYINITIAL>{NUM}+ {return new Symbol(sym.DIGITO,     yyline, yycolumn, yytext());}
<YYINITIAL>{NUMN}+ {return new Symbol(sym.DIGITO,     yyline, yycolumn, yytext());}
<YYINITIAL>{CAD}  {return new Symbol(sym.CADENA,     yyline, yycolumn, yytext());}
<YYINITIAL>{COM}  {return new Symbol(sym.COMENTARIO,     yyline, yycolumn, yytext());}
<YYINITIAL>{COMENTARIO}  {return new Symbol(sym.COMENTARIO,     yyline, yycolumn, yytext());}
<YYINITIAL>{ID}  {return new Symbol(sym.ID,     yyline, yycolumn, yytext());}
<YYINITIAL>{DECIM}  {return new Symbol(sym.DECIMAL,     yyline, yycolumn, yytext());}
.		      
            {
          System.out.println("error lexico en la fila "+yyline +" y en la columna " + yycolumn);  /*imprime que error */
Sintactico.error="error lexico en la fila "+yyline +" y en la columna " + yycolumn;
	          	}