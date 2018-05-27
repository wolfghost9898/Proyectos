package proyecto1_servidor;
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
SIM=[!*-+_:;[]{}()=,.]
NUMN=-[0-9]
LD={LETRA}|{NUM}|{NUMN}
WHITE=([\ |\t|\f]|\n)
ESPACIO=[ ]
CAD="\""({SIM}*{LD}+{WHITE}*{SIM}*{LD}*{SIM}*)+"\""
IDENTIFICADOR=({LETRA}{LD}*)
COM="//"({ESPACIO}*{SIM}*{LD}*{CAD}*{SIM}*)+
COMENTARIO="/*"({WHITE}*{SIM}*{LD}*{CAD}*{SIM}*)+"*/"
%%


/*-------------------------------------------------COMIENZA EL LENGAUEJE JAVA----------------------------------------*/

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
<YYINITIAL>"("      {return new Symbol(sym.PARA,      yyline, yycolumn, yytext());}
<YYINITIAL>")"      {return new Symbol(sym.PARC,     yyline, yycolumn, yytext());}
<YYINITIAL>";"      {return new Symbol(sym.PUNTOCOMA,     yyline, yycolumn, yytext());}
<YYINITIAL>":"      {return new Symbol(sym.DOSPUNTOS,     yyline, yycolumn, yytext());}
<YYINITIAL>"{"      {return new Symbol(sym.LLAVEA,     yyline, yycolumn, yytext());}
<YYINITIAL>"}"      {return new Symbol(sym.LLAVEC,     yyline, yycolumn, yytext());}
<YYINITIAL>"++"      {return new Symbol(sym.INCREMENTO,     yyline, yycolumn, yytext());}
<YYINITIAL>"--"      {return new Symbol(sym.DECREMENTO,     yyline, yycolumn, yytext());}

/*-----------------------------------SENTENCIAS-----------------------------------------------*/
<YYINITIAL>"import"     {return new Symbol(sym.IMPORT, yyline, yycolumn, yytext());}
<YYINITIAL>"if"      {return new Symbol(sym.IF,    yyline, yycolumn, yytext());}
<YYINITIAL>"else"      {return new Symbol(sym.ELSE,    yyline, yycolumn, yytext());}
<YYINITIAL>"while"      {return new Symbol(sym.WHILE,    yyline, yycolumn, yytext());}
<YYINITIAL>"for"      {return new Symbol(sym.FOR,    yyline, yycolumn, yytext());}
<YYINITIAL>"do"      {return new Symbol(sym.DO,    yyline, yycolumn, yytext());}
<YYINITIAL>"switch"      {return new Symbol(sym.SWITCH,    yyline, yycolumn, yytext());}
<YYINITIAL>"case"      {return new Symbol(sym.CASE,    yyline, yycolumn, yytext());}
<YYINITIAL>"break"      {return new Symbol(sym.BREAK,    yyline, yycolumn, yytext());}
<YYINITIAL>"return"      {return new Symbol(sym.RETURN,    yyline, yycolumn, yytext());}
<YYINITIAL>"class"      {return new Symbol(sym.CLASS,    yyline, yycolumn, yytext());}
<YYINITIAL>"else if"      {return new Symbol(sym.ELSEIF,    yyline, yycolumn, yytext());}
<YYINITIAL>"default"      {return new Symbol(sym.DEFAULT,    yyline, yycolumn, yytext());}
<YYINITIAL>"new"      {return new Symbol(sym.NEW,    yyline, yycolumn, yytext());}
<YYINITIAL>"System"      {return new Symbol(sym.SYSTEM,    yyline, yycolumn, yytext());}
<YYINITIAL>"out"      {return new Symbol(sym.OUT,    yyline, yycolumn, yytext());}
<YYINITIAL>"println"      {return new Symbol(sym.PRINT,    yyline, yycolumn, yytext());}
/*----------------------------------------------------------VISIBILIDAD--------------------------------------*/
<YYINITIAL>"public"      {return new Symbol(sym.PUBLIC,    yyline, yycolumn, yytext());}
<YYINITIAL>"private"      {return new Symbol(sym.PRIVATE,    yyline, yycolumn, yytext());}
<YYINITIAL>"protected"      {return new Symbol(sym.PROTECTED,    yyline, yycolumn, yytext());}
<YYINITIAL>"final"      {return new Symbol(sym.FINAL,    yyline, yycolumn, yytext());}
<YYINITIAL>"void"      {return new Symbol(sym.VOID,    yyline, yycolumn, yytext());}

/*----------------------------------------------------TIPO DE DATO------------------------------------------------*/
<YYINITIAL>"boolean"      {return new Symbol(sym.BOOLEAN,    yyline, yycolumn, yytext());}
<YYINITIAL>"char"      {return new Symbol(sym.CHAR,    yyline, yycolumn, yytext());}
<YYINITIAL>"double"      {return new Symbol(sym.DOUBLE,    yyline, yycolumn, yytext());}
<YYINITIAL>"int"      {return new Symbol(sym.INT,    yyline, yycolumn, yytext());}
<YYINITIAL>"Object"      {return new Symbol(sym.OBJECT,    yyline, yycolumn, yytext());}
<YYINITIAL>"String"      {return new Symbol(sym.STRING,    yyline, yycolumn, yytext());}

/*------------------------------------------------------OPERADORES---------------------------------------------------*/

<YYINITIAL>"=="      {return new Symbol(sym.IGUALIGUAL,     yyline, yycolumn, yytext());}
<YYINITIAL>"!="      {return new Symbol(sym.DISTINTO,     yyline, yycolumn, yytext());}
<YYINITIAL>"&&"      {return new Symbol(sym.AND,     yyline, yycolumn, yytext());}
<YYINITIAL>"||"      {return new Symbol(sym.OR,     yyline, yycolumn, yytext());}
<YYINITIAL>"!"      {return new Symbol(sym.NOT,     yyline, yycolumn, yytext());}


/*--------------------ID DIGITOS Y CADENA-------------------------*/
<YYINITIAL>{IDENTIFICADOR} {return new Symbol(sym.IDENTIFICADOR,     yyline, yycolumn, yytext());}
<YYINITIAL>{NUM}+ {return new Symbol(sym.DIGITO,     yyline, yycolumn, yytext());}
<YYINITIAL>{NUMN}+ {return new Symbol(sym.DIGITO,     yyline, yycolumn, yytext());}
<YYINITIAL>{CAD}  {return new Symbol(sym.CADENA,     yyline, yycolumn, yytext());}
<YYINITIAL>{COM}  {return new Symbol(sym.COMENTARIO,     yyline, yycolumn, yytext());}
<YYINITIAL>{COMENTARIO}  {return new Symbol(sym.COMENTARIO,     yyline, yycolumn, yytext());}
.		      
            {
            	Sintactico.error="error lexico en la fila "+yyline +" y en la columna " + yycolumn;
              System.out.println("error lexico en la fila "+yyline +" y en la columna " + yycolumn);
	          	}


