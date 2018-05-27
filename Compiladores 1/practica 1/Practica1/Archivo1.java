 import java.util.Scanner;
 public class Archivo1{

	public boolean Var_Boolean;
	private char Var_Char;
	static double Var_Double;
	public long Var_Long;
	static int Mi_nota=100;
	public static void main(String args[]){
		SentenciaSwtich(2);SentenciaIf(63);SentenciaIf(120);
	}
	public void SentenciaSwtich(int nota){
		
	switch(nota){
	case 1:

	System.out.println("Su numero ingresada es 1");
	break;	case 2:

	System.out.println("Su numero ingresada es 2");
	break;	case 3:

	System.out.println("Su numero ingresada es 3");
	break;
	default:

	System.out.println("ES OTRO NUMERO");
	break;
	}
	}
	public void SentenciaIf(int nota){
		
	System.out.println("Sunota es "+nota);
	if(nota<=100 && nota>=0 ){

	if(nota<=100 && nota>=80 ){

	System.out.println("Ufff casi pierde pero gana D");
	}else if(nota<80 && nota>64 ){

	System.out.println("Gana");
	}else if(nota<65 && nota>60 ){

	System.out.println("Gana con buena nota");
	}
	}else {

	System.out.println("La nota no es valida");
	}
	}
	public void TiposDeVariable(){
		
	if(1<5 && "hola"=="hola" && 20<=20 ){

	System.out.println("Declaraciones  y Asignacion Correcta");
	}else {

	System.out.println("Declaraciones  y Asignacion Incorrecta");
	}
	}
}