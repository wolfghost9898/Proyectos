package proyecto1_cliente;
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
%ignorecase

LETRA=[a-zA-Z_]
NUM=[0-9]
MEN=[-]
DECIM={NUM}+"."{NUM}+
SIM=[_,~@#$|{}\?\\:]
NUMN=-[0-9]
LD={LETRA}|{NUM}|{NUMN}|{SIM}
CAD2=({LD}*{SIM}+)+
WHITE=([\ |\t|\f]|\n)
ESPACIO=[ ]
IDENTIFICADOR=("_"?[:jletter:]+[:jletterdigit:]*)+
CA3="\'"({LD}+{WHITE}*)*"\'"
CAD="\""({LD}+{WHITE}+{LD}*)*"\""
COM="->"({SIM}*{LD}*{ESPACIO}*{CAD}*{SIM}*)+
COMENTARIO="</"({WHITE}*{SIM}*{LD}*{CAD}*{SIM}*)+"/>"

%%


/*-------------------------------------------------COMIENZA EL LENGAUEJE html-creports---------------------------*/
<YYINITIAL> {WHITE}  {/*no hace nada, aumenta una columna*/}

/*--------------------------------lenguajehtml---------------*/
<YYINITIAL>"<html>"     {return new Symbol(sym.OPENHTML,yyline, yycolumn, yytext());}
<YYINITIAL>"</html>"     {return new Symbol(sym.CLOSEHTML,yyline, yycolumn, yytext());}
<YYINITIAL>"head"     {return new Symbol(sym.HEAD,yyline, yycolumn, yytext());}
<YYINITIAL>"</head>"     {return new Symbol(sym.CLOSEHEAD,yyline, yycolumn, yytext());}
<YYINITIAL>"body"     {return new Symbol(sym.BODY,yyline, yycolumn, yytext());}
<YYINITIAL>"</body>"     {return new Symbol(sym.CLOSEBODY,yyline, yycolumn, yytext());}
<YYINITIAL>"h1"     {return new Symbol(sym.H,yyline, yycolumn, yytext());}
<YYINITIAL>"h2"     {return new Symbol(sym.H,yyline, yycolumn, yytext());}
<YYINITIAL>"h3"     {return new Symbol(sym.H,yyline, yycolumn, yytext());}
<YYINITIAL>"h4"     {return new Symbol(sym.H,yyline, yycolumn, yytext());}
<YYINITIAL>"h5"     {return new Symbol(sym.H,yyline, yycolumn, yytext());}
<YYINITIAL>"h6"     {return new Symbol(sym.H,yyline, yycolumn, yytext());}
<YYINITIAL>"title"     {return new Symbol(sym.TITLE,yyline, yycolumn, yytext());}
<YYINITIAL>"</title>"     {return new Symbol(sym.CLOSETITLE,yyline, yycolumn, yytext());}
<YYINITIAL>"table"     {return new Symbol(sym.TABLE,yyline, yycolumn, yytext());}
<YYINITIAL>"</table>"     {return new Symbol(sym.CLOSETABLE,yyline, yycolumn, yytext());}
<YYINITIAL>"th"     {return new Symbol(sym.TH,yyline, yycolumn, yytext());}
<YYINITIAL>"</th>"     {return new Symbol(sym.CLOSETH,yyline, yycolumn, yytext());}
<YYINITIAL>"td"     {return new Symbol(sym.TD,yyline, yycolumn, yytext());}
<YYINITIAL>"</td>"     {return new Symbol(sym.CLOSETD,yyline, yycolumn, yytext());}
<YYINITIAL>"tr"     {return new Symbol(sym.TR,yyline, yycolumn, yytext());}
<YYINITIAL>"</tr>"     {return new Symbol(sym.CLOSETR,yyline, yycolumn, yytext());}
<YYINITIAL>"div"     {return new Symbol(sym.DIV,yyline, yycolumn, yytext());}
<YYINITIAL>"</div>"     {return new Symbol(sym.CLOSEDIV,yyline, yycolumn, yytext());}
<YYINITIAL>"p"     {return new Symbol(sym.P,yyline, yycolumn, yytext());}
<YYINITIAL>"</p>"     {return new Symbol(sym.CLOSEP,yyline, yycolumn, yytext());}
<YYINITIAL>"br"     {return new Symbol(sym.BR,yyline, yycolumn, yytext());}
<YYINITIAL>"</br>"     {return new Symbol(sym.CLOSEBR,yyline, yycolumn, yytext());}
<YYINITIAL>"hr"     {return new Symbol(sym.HR,yyline, yycolumn, yytext());}
<YYINITIAL>"</hr>"     {return new Symbol(sym.CLOSEHR,yyline, yycolumn, yytext());}
<YYINITIAL>"<"     {return new Symbol(sym.MENOR,yyline, yycolumn, yytext());}
<YYINITIAL>">"     {return new Symbol(sym.MAYOR,yyline, yycolumn, yytext());}
<YYINITIAL>"/"      {return new Symbol(sym.DIVISION,    yyline, yycolumn, yytext());}
<YYINITIAL>"color"      {return new Symbol(sym.ACOLOR,    yyline, yycolumn, yytext());}
<YYINITIAL>"align"      {return new Symbol(sym.ALIGN,    yyline, yycolumn, yytext());}
<YYINITIAL>"font"      {return new Symbol(sym.FONT,    yyline, yycolumn, yytext());}
<YYINITIAL>"textcolor"      {return new Symbol(sym.TEXTCOLOR,    yyline, yycolumn, yytext());}
<YYINITIAL>"="      {return new Symbol(sym.IGUAL,    yyline, yycolumn, yytext());}
<YYINITIAL>"\""      {return new Symbol(sym.COMILLAS,    yyline, yycolumn, yytext());}
<YYINITIAL>"\"rojo\""      {return new Symbol(sym.COLORES,    yyline, yycolumn, yytext());}
<YYINITIAL>"\"amarillo\""      {return new Symbol(sym.COLORES,    yyline, yycolumn, yytext());}
<YYINITIAL>"\"azul\""      {return new Symbol(sym.COLORES,    yyline, yycolumn, yytext());}
<YYINITIAL>"\"verde\""      {return new Symbol(sym.COLORES,    yyline, yycolumn, yytext());}
<YYINITIAL>"\"gris\""      {return new Symbol(sym.COLORES,    yyline, yycolumn, yytext());}
<YYINITIAL>"\"anaranjado\""      {return new Symbol(sym.COLORES,    yyline, yycolumn, yytext());}
<YYINITIAL>"\"morado\""      {return new Symbol(sym.COLORES,    yyline, yycolumn, yytext());}
<YYINITIAL>"\"izquierda\""      {return new Symbol(sym.ALINEACION,    yyline, yycolumn, yytext());}
<YYINITIAL>"\"derecha\""      {return new Symbol(sym.ALINEACION,    yyline, yycolumn, yytext());}
<YYINITIAL>"\"centrado\""      {return new Symbol(sym.ALINEACION,    yyline, yycolumn, yytext());}
<YYINITIAL>"("      {return new Symbol(sym.PARA,      yyline, yycolumn, yytext());}
<YYINITIAL>")"      {return new Symbol(sym.PARC,     yyline, yycolumn, yytext());}
<YYINITIAL>"."      {return new Symbol(sym.PUNTO,    yyline, yycolumn, yytext());}
<YYINITIAL>","      {return new Symbol(sym.COMA,    yyline, yycolumn, yytext());}
<YYINITIAL>";"      {return new Symbol(sym.PUNTOCOMA,     yyline, yycolumn, yytext());}
<YYINITIAL>":"     {return new Symbol(sym.DOSPUNTOS,     yyline, yycolumn, yytext());}


/*------------------------------lenguaje cpreport-----------------------*/
<YYINITIAL>"$$"      {return new Symbol(sym.DOLAR,      yyline, yycolumn, yytext());}
<YYINITIAL>"double"      {return new Symbol(sym.DOUBLE,     yyline, yycolumn, yytext());}
<YYINITIAL>"char"      {return new Symbol(sym.CHAR,     yyline, yycolumn, yytext());}
<YYINITIAL>"String"      {return new Symbol(sym.STRING,     yyline, yycolumn, yytext());}
<YYINITIAL>"RESULT"      {return new Symbol(sym.RESULT,     yyline, yycolumn, yytext());}
<YYINITIAL>"["      {return new Symbol(sym.OPEN,      yyline, yycolumn, yytext());}
<YYINITIAL>"]"      {return new Symbol(sym.CLOSE,     yyline, yycolumn, yytext());}
<YYINITIAL>"int"      {return new Symbol(sym.INT,      yyline, yycolumn, yytext());}
<YYINITIAL>"float"      {return new Symbol(sym.FLOAT,      yyline, yycolumn, yytext());}
<YYINITIAL>"boolean"      {return new Symbol(sym.BOOLEAN,      yyline, yycolumn, yytext());}
<YYINITIAL>"\'"      {return new Symbol(sym.APOS,      yyline, yycolumn, yytext());}
<YYINITIAL>"+"      {return new Symbol(sym.MAS,    yyline, yycolumn, yytext());}
<YYINITIAL>"-"      {return new Symbol(sym.MENOS,    yyline, yycolumn, yytext());}
<YYINITIAL>"*"      {return new Symbol(sym.MULTIPLICACION,    yyline, yycolumn, yytext());}
<YYINITIAL>"%"      {return new Symbol(sym.MODULO,    yyline, yycolumn, yytext());}
<YYINITIAL>">="     {return new Symbol(sym.MAYORIGUAL,yyline, yycolumn, yytext());}
<YYINITIAL>"<="     {return new Symbol(sym.MENORIGUAL,yyline, yycolumn, yytext());}
<YYINITIAL>"=="      {return new Symbol(sym.IGUALIGUAL,     yyline, yycolumn, yytext());}
<YYINITIAL>"!="      {return new Symbol(sym.DISTINTO,     yyline, yycolumn, yytext());}
<YYINITIAL>"&&"      {return new Symbol(sym.AND,     yyline, yycolumn, yytext());}
<YYINITIAL>"||"      {return new Symbol(sym.OR,     yyline, yycolumn, yytext());}
<YYINITIAL>"!"      {return new Symbol(sym.NOT,     yyline, yycolumn, yytext());}
<YYINITIAL>"++"      {return new Symbol(sym.INCREMENTO,     yyline, yycolumn, yytext());}
<YYINITIAL>"--"      {return new Symbol(sym.DECREMENTO,     yyline, yycolumn, yytext());}
<YYINITIAL>"print"      {return new Symbol(sym.PRINT,     yyline, yycolumn, yytext());}
<YYINITIAL>"score"      {return new Symbol(sym.SCORE,     yyline, yycolumn, yytext());}
<YYINITIAL>"variables"      {return new Symbol(sym.VARIABLES,     yyline, yycolumn, yytext());}
<YYINITIAL>"nombre"      {return new Symbol(sym.NOMBRE,     yyline, yycolumn, yytext());}
<YYINITIAL>"cantidad"      {return new Symbol(sym.CANTIDAD,     yyline, yycolumn, yytext());}
<YYINITIAL>"metodos"      {return new Symbol(sym.METODOS,     yyline, yycolumn, yytext());}
<YYINITIAL>"clases"      {return new Symbol(sym.CLASES,     yyline, yycolumn, yytext());}
<YYINITIAL>"tipo"      {return new Symbol(sym.TIPO,     yyline, yycolumn, yytext());}
<YYINITIAL>"clase"      {return new Symbol(sym.CLASE,     yyline, yycolumn, yytext());}
<YYINITIAL>"lineas"      {return new Symbol(sym.LINEAS,     yyline, yycolumn, yytext());}
<YYINITIAL>"parametros"      {return new Symbol(sym.PARAMETROS,     yyline, yycolumn, yytext());}



/*--------------------ID DIGITOS Y CADENA-------------------------*/
<YYINITIAL>{IDENTIFICADOR} {return new Symbol(sym.IDENTIFICADOR,     yyline, yycolumn, yytext());}
<YYINITIAL>{MEN}*{NUM}+ {return new Symbol(sym.DIGITO,     yyline, yycolumn, yytext());}
<YYINITIAL>{CAD}  {return new Symbol(sym.CADENA,     yyline, yycolumn, yytext());}  
<YYINITIAL>{CAD2}  {return new Symbol(sym.CADENA2,     yyline, yycolumn, yytext());}
<YYINITIAL>{CA3}  {return new Symbol(sym.CA3,     yyline, yycolumn, yytext());}  
<YYINITIAL>{SIM}  {return new Symbol(sym.SIMBOLO,     yyline, yycolumn, yytext());}  
<YYINITIAL>{COM}  {return new Symbol(sym.COMENTARIO,     yyline, yycolumn, yytext());}
<YYINITIAL>{COMENTARIO}  {return new Symbol(sym.COMENTARIO,     yyline, yycolumn, yytext());}
<YYINITIAL>{DECIM}  {return new Symbol(sym.DECIMAL,     yyline, yycolumn, yytext());}
. 
    {
    Sintactico.errores="error lexico en la fila "+yyline +" y en la columna " + yycolumn;
 System.out.println("error lexico en la fila "+yyline +" y en la columna " + yycolumn);
	          	}