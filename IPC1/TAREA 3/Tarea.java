//Importaciones
import java.util.Scanner;
//Codigo
public class Tarea{
	private static String Texto;
	private static boolean  repetidor;
	public static void main(String[] arg){
		repetidor=true;
		while(repetidor){
			System.out.println("1. Ordenar Numeros");
			System.out.println("2. Verificar si un numero es par");
			System.out.println("3. Numero Capicua");
			System.out.println("4. Mostrar si los numeros son amigos o no");
			System.out.println("5. Salir");
			System.out.println("Escoja una opcion");
			//Adaptador
			Scanner reader= new Scanner(System.in);
			int opcion=reader.nextInt();
			//condiciones
			if((opcion>5)||(opcion<1)){
				repetidor=true;
				System.out.println("opcion incorrecta");
			}else{
				//Control de Opciones
				switch(opcion){
					case 1:
					 	OrdenarNumeros();
					break;
					case 2:
						VerificarPar();
					break;
					case 3:
						NumeroCapicua();
					break;
					case 4:
						NumeroAmigo();
					break;
					case 5:
						repetidor=false;
					break;
				}
				//Fin control de opciones
			}

		}
		//Fin while
	}


		//Funcion encargada de ordenar los numeros
	public static void OrdenarNumeros(){
		//Variables
		int a;
		int b;
		int c;
		String tomar;

		Scanner reader = new Scanner(System.in);
		System.out.println("Ingrese tres numeros numero");
		a=reader.nextInt();
		b=reader.nextInt();
		c=reader.nextInt();
		if(a>b && b>c){
			Texto=a+","+b+","+c;
		}else if(a>c && c>b){
			Texto=a+","+c+","+b;
		}else if(b>a && a>c){
			Texto=b+","+a+","+c;
		}else if(b>c && c>a){
			Texto=b+","+c+","+a;
		}else if(c>a && a>b){
			Texto=c+","+a+","+b;
		}else if(c>b && b>a ){
			Texto=c+","+b+","+a;
		}
		System.out.println(Texto);
		System.out.println("Desea regresar al menu anterior?");
		reader.nextLine();
		tomar=reader.nextLine();
		if(tomar.equals("si")){
			repetidor=true;
		}else{
			repetidor=false;
		}
	}
	//Fin Ordenar Numeros

	//Verificar si es par
	public static void VerificarPar(){
		int numero;
		int resultado;
		String tomar;
		Scanner reader = new Scanner(System.in);
		System.out.println("Ingrese un  numero");
		numero=reader.nextInt();
		resultado=(numero%2);
		if(resultado==0){
			System.out.println("Numero Par: "+(numero*2));
		}else{
			System.out.println("Numero Impar: "+(numero*3));
		}
		System.out.println("Desea regresar al menu anterior?");
		reader.nextLine();
		tomar=reader.nextLine();
		if(tomar.equals("si")){
			repetidor=true;
		}else{
			repetidor=false;
		}
	}
	//Fin Verificar si numero es Par

	//Numero Capicua
	public static void NumeroCapicua(){
		int numero,resto,falta,invertido;
		String tomar;
		Scanner reader = new Scanner(System.in);
		System.out.println("Ingrese un numero");
		numero=reader.nextInt();
		falta=numero;
		invertido=0;
		resto=0;
		while(falta!=0){
			resto=(falta%10);
			invertido=(invertido*10)+resto;
			falta=(int)(falta/10);
		}
		if(invertido==numero){
			System.out.println("Es Capicua");
		}else{
			System.out.println("No es Capicua");
		}
		System.out.println("Desea regresar al menu anterior?");
		reader.nextLine();
		tomar=reader.nextLine();
		if(tomar.equals("si")){
			repetidor=true;
		}else{
			repetidor=false;
		}
	}

	//Fin Numero Capicua

	//Numero Amigo
	public static void NumeroAmigo(){
		int a;
		int b;
		String tomar;
		int resultado;
		Scanner reader= new Scanner(System.in);
		System.out.println("Ingrese dos numeros");
		a=reader.nextInt();
		b=reader.nextInt();
		if(a>=0 && b>=0){
			resultado=RepetidorFor(a);
				if(resultado==b){
				resultado=RepetidorFor(b);
				if(resultado==a){
					System.out.println("Son numeros amigos");
				}
			}else{
				System.out.println("No son numeros amigos");
			}
		}else{
			System.out.println("Ingrese numeros positivos");
		}
		System.out.println("Desea regresar al menu anterior?");
		reader.nextLine();
		tomar=reader.nextLine();
		if(tomar.equals("si")){
			repetidor=true;
		}else{
			repetidor=false;
		}
	}
	//Fin numero amigo

	//Metodo Encargado del For
	public static int RepetidorFor(int numero){
		int suma=0;
		int resultado=0;
		for(int i=1;i<numero;i++){
			resultado=(numero%i);
			if(resultado==0){
				suma=suma+i;
			}
		}
		return suma;
	}
	//Fin metodo
}
