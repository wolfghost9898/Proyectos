 import java.util.Scanner;
 public class Archivo2{

	public static void main(String args[]){
		SentenciaCiclos();hacerOperaciones();Matrices();Combinadas(8,6);
	}
	public static void SentenciaCiclos(){
		
	 int opcion=0;while (opcion!=7 ){

	System.out.println("Seleccione una opcion");
	System.out.println("2 For incremental en 1");
	System.out.println("1 For incremental en 3");
	System.out.println("4 For decremental");
	System.out.println("3 While con condicion");
	System.out.println("6 While con break");
	System.out.println("5 Do while");
	System.out.println("8 Salir");
	 Scanner sc = new Scanner(System.in);
	 opcion=sc.nextInt();
	switch(opcion){
	case 2:

	System.out.println("For incremental");
	for(int number=0;number<10;number=number+(1)){

	System.out.println(number+"_");
	}
	break;	case 1:

	System.out.println("For incremental en 3");
	for(int number=0;number<20;number=number+(3)){

	System.out.println(number+"_");
	}
	break;	case 4:

	System.out.println("For decremental");
	for(int number=20;number>0;number=number+(-1)){

	System.out.println(number+"_ ");
	}
	break;	case 3:

	System.out.println("While con condicion");
	System.out.println("Ingrese el limite final");
	int fin=sc.nextInt();
	 int inicio=0;while (inicio<=fin ){

	System.out.println(inicio+"_");
	inicio=inicio+1;
}
	break;	case 6:

	System.out.println("while con break");
	while (true ){

	System.out.println("ingrese un numero");
	int num=sc.nextInt();
	if(num==10 ){
break;
	}else {

	System.out.println(num);
	}
}
	break;	case 5:

	System.out.println("Do while");
	System.out.println("ingrese un numero");
	int num=sc.nextInt();
	do{

	System.out.println(num+"_");
	num=num+1;
	}while(num>10 );
	break;	
	case 8:
break;
	
	default:

	System.out.println("Opcion Incorrecta");
	break;
	}
}
	}public  static int sumar(int op1,int op2){
return op1+op2;
}public static int multiplicar(int op1,int op2){
return op1*op2;
}public static String  concatenar(int valor){
return "El resultado es "+valor;
}
	public static void  hacerOperaciones(){
		
	 int op,operando1,operando2;
	op=0;while (op!=4 ){

	System.out.println("Seleccione una opcion");
	System.out.println("2 Sumar");
	System.out.println("1 Multiplicar");
	System.out.println("4 Salir");
	Scanner sc = new Scanner(System.in);
	 op=sc.nextInt();
	switch(op){
	case 2:

	System.out.println("ingrese el primer operando");
	int op1=sc.nextInt();
	System.out.println("ingrese el segundo operando");
	int op2=sc.nextInt();
	int resultado=sumar(op1,op2);
	 String cadena=concatenar(resultado);
	System.out.println(cadena);
	break;	case 1:

	System.out.println("ingrese el primer operando");
	 op1=sc.nextInt();
	System.out.println("ingrese el segundo operando");
	 op2=sc.nextInt();
	  resultado=multiplicar(op1,op2);
	  cadena=concatenar(resultado);
	System.out.println(cadena);
	break;	case 4:
break;
	
	default:

	System.out.println("Opcion Incorrecta");
	break;
	}
}
	}
	public static void  Matrices(){
		
	 int[][] matriz= new int[5][5];
	for(int i=0;i<5;i=i+(1)){

	for(int j=0;j<5;j=j+(1)){

	matriz[i][j]=i*2;
	}
	}
	System.out.println("Imprimir valores de las matrices");
	for(int i=0;i<5;i=i+(1)){

	for(int j=0;j<5;j=j+(1)){

	System.out.println(matriz[i][j]);
	}
	}
	}
	private static String Combinadas(int num1,int num2){

	double Resultado;
	Resultado=multiplicar(5,num2)/2+10-sumar(10,num2)*4+10;return "El resultado es "+Resultado;
}
}