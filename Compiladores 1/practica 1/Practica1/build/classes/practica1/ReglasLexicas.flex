package practica1;
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


L=[a-zA-Z_]
D=[0-9]
Dnega=-[0-9]
LD={L}|{D}
WHITE=([\ |\t|\f]|\n)
cadena="\""({LD}+{WHITE}*{LD}*)+"\""
id=({L}{LD}*)

%%
/*-----------------------------------Expresiones Regulares*/
<YYINITIAL> {WHITE}  {/*no hace nada, aumenta una columna*/}

<YYINITIAL>"<>"     {return new Symbol(sym.DIFERENTE, yyline, yycolumn, yytext());}
<YYINITIAL>">="     {return new Symbol(sym.MAYORIGUAL,yyline, yycolumn, yytext());}
<YYINITIAL>"<="     {return new Symbol(sym.MENORIGUAL,yyline, yycolumn, yytext());}
<YYINITIAL>">"      {return new Symbol(sym.MAYOR,     yyline, yycolumn, yytext());}
<YYINITIAL>"<"      {return new Symbol(sym.MENOR,     yyline, yycolumn, yytext());}
<YYINITIAL>"="      {return new Symbol(sym.IGUAL,    yyline, yycolumn, yytext());}
<YYINITIAL>"+"      {return new Symbol(sym.MAS,    yyline, yycolumn, yytext());}
<YYINITIAL>"-"      {return new Symbol(sym.MENOS,    yyline, yycolumn, yytext());}
<YYINITIAL>"/"      {return new Symbol(sym.DIVISION,    yyline, yycolumn, yytext());}
<YYINITIAL>"*"      {return new Symbol(sym.MULTIPLICACION,    yyline, yycolumn, yytext());}


<YYINITIAL>"Module"      {return new Symbol(sym.MODULE,    yyline, yycolumn, yytext());}
<YYINITIAL>"End"      {return new Symbol(sym.END,    yyline, yycolumn, yytext());}
<YYINITIAL>"As"      {return new Symbol(sym.AS,    yyline, yycolumn, yytext());}
<YYINITIAL>"Console"      {return new Symbol(sym.CONSOLE,    yyline, yycolumn, yytext());}
<YYINITIAL>"ReadLine"      {return new Symbol(sym.READLINE,    yyline, yycolumn, yytext());}
<YYINITIAL>"WriteLine"      {return new Symbol(sym.WRITELINE,    yyline, yycolumn, yytext());}
<YYINITIAL>"Sub"      {return new Symbol(sym.SUB,    yyline, yycolumn, yytext());}
<YYINITIAL>"ByVal"      {return new Symbol(sym.BYVAL,    yyline, yycolumn, yytext());}
<YYINITIAL>"Function"      {return new Symbol(sym.FUNCTION,    yyline, yycolumn, yytext());}
<YYINITIAL>"Return"      {return new Symbol(sym.RETURN,    yyline, yycolumn, yytext());}

<YYINITIAL>"If"      {return new Symbol(sym.IF,    yyline, yycolumn, yytext());}
<YYINITIAL>"Then"      {return new Symbol(sym.THEN,    yyline, yycolumn, yytext());}
<YYINITIAL>"Else"      {return new Symbol(sym.ELSE,    yyline, yycolumn, yytext());}
<YYINITIAL>"ElseIf"      {return new Symbol(sym.ELSELF,    yyline, yycolumn, yytext());}
<YYINITIAL>"While"      {return new Symbol(sym.WHILE,    yyline, yycolumn, yytext());}
<YYINITIAL>"For"      {return new Symbol(sym.FOR,    yyline, yycolumn, yytext());}
<YYINITIAL>"To"      {return new Symbol(sym.TO,    yyline, yycolumn, yytext());}
<YYINITIAL>"Step"      {return new Symbol(sym.STEP,    yyline, yycolumn, yytext());}
<YYINITIAL>"Next"      {return new Symbol(sym.NEXT,    yyline, yycolumn, yytext());}
<YYINITIAL>"Do"      {return new Symbol(sym.DO,    yyline, yycolumn, yytext());}
<YYINITIAL>"Loop"      {return new Symbol(sym.LOOP,    yyline, yycolumn, yytext());}
<YYINITIAL>"Until"      {return new Symbol(sym.UNTIL,    yyline, yycolumn, yytext());}
<YYINITIAL>"Select"      {return new Symbol(sym.SELECT,    yyline, yycolumn, yytext());}
<YYINITIAL>"Case"      {return new Symbol(sym.CASE,    yyline, yycolumn, yytext());}


<YYINITIAL>"And"      {return new Symbol(sym.AND,    yyline, yycolumn, yytext());}
<YYINITIAL>"Or"      {return new Symbol(sym.OR,    yyline, yycolumn, yytext());}
<YYINITIAL>"Not"      {return new Symbol(sym.NOT,    yyline, yycolumn, yytext());}

<YYINITIAL>"Exit"      {return new Symbol(sym.EXIT,    yyline, yycolumn, yytext());}


<YYINITIAL>"Public"      {return new Symbol(sym.PUBLIC,    yyline, yycolumn, yytext());}
<YYINITIAL>"Private"      {return new Symbol(sym.PRIVATE,    yyline, yycolumn, yytext());}
<YYINITIAL>"Dim"      {return new Symbol(sym.DIM,    yyline, yycolumn, yytext());}
<YYINITIAL>"Static"      {return new Symbol(sym.STATIC,    yyline, yycolumn, yytext());}

<YYINITIAL>"Boolean"      {return new Symbol(sym.BOOLEAN,    yyline, yycolumn, yytext());}
<YYINITIAL>"Char"      {return new Symbol(sym.CHAR,    yyline, yycolumn, yytext());}
<YYINITIAL>"Double"      {return new Symbol(sym.DOUBLE,    yyline, yycolumn, yytext());}
<YYINITIAL>"Integer"      {return new Symbol(sym.INTEGER,    yyline, yycolumn, yytext());}
<YYINITIAL>"Long"      {return new Symbol(sym.LONG,    yyline, yycolumn, yytext());}
<YYINITIAL>"String"      {return new Symbol(sym.STRING,    yyline, yycolumn, yytext());}

<YYINITIAL>","      {return new Symbol(sym.COMA,    yyline, yycolumn, yytext());}
<YYINITIAL>"."      {return new Symbol(sym.PUNTO,    yyline, yycolumn, yytext());}
<YYINITIAL>"["      {return new Symbol(sym.OPEN,      yyline, yycolumn, yytext());}
<YYINITIAL>"]"      {return new Symbol(sym.CLOSE,     yyline, yycolumn, yytext());}
<YYINITIAL>"("      {return new Symbol(sym.OPENPA,      yyline, yycolumn, yytext());}
<YYINITIAL>")"      {return new Symbol(sym.CLOSEPA,     yyline, yycolumn, yytext());}
<YYINITIAL>"&"      {return new Symbol(sym.CONCATENAR,     yyline, yycolumn, yytext());}

/*--------------------Simbolos ER-------------------------*/
<YYINITIAL>{id} {return new Symbol(sym.ID,     yyline, yycolumn, yytext());}
<YYINITIAL>{D}+ {return new Symbol(sym.NUMERO,     yyline, yycolumn, yytext());}
<YYINITIAL>{Dnega}+ {return new Symbol(sym.NUMERO,     yyline, yycolumn, yytext());}
<YYINITIAL>{cadena}  {return new Symbol(sym.CADENA,     yyline, yycolumn, yytext());}
.		        {
              System.out.println("error lexico en la fila "+yyline +" y en la columna " + yycolumn);
              analizadosin.errores="error lexico en la fila "+yyline +" y en la columna " + yycolumn;
	          	}
