 import java.util.Scanner;
 public class Archivo3{

	public static void main(String args[]){
		TercerArchivo();
	}
	public static void TercerArchivo(){
		
	 int op=0;while (op!=8 ){

	System.out.println("Seleccione una opcion");
	System.out.println("2 Crear Matriz");
	System.out.println("1 Mostrar Transpuesta");
	System.out.println("4 Sumar Matrices");
	System.out.println("3 Serie Fibonacci");
	System.out.println("8 Salir");
	 Scanner sc = new Scanner(System.in);
	 op=sc.nextInt();
	switch(op){
	case 2:

	System.out.println("Ingrese la cantidad de filas");
	int filas=sc.nextInt();
	System.out.println("Ingrese la cantidad de columnas");
	int col=sc.nextInt();
	int[][] matriz= new int[filas][col];
	for(int i=0;i<5;i=i+(1)){

	for(int j=0;j<5;j=j+(1)){

	matriz[i][j]=i*2;
	}
	}
	System.out.println("Imprimir valores de las matrices");
	 String impresionMatriz="_";
	for(int i=0;i<5;i=i+(1)){

	impresionMatriz="_";
	for(int j=0;j<5;j=j+(1)){

	impresionMatriz=impresionMatriz+"_"+matriz[i][j]+"_ ";
	}
	System.out.println(impresionMatriz);
	}
	break;	case 1:

	System.out.println("Ingrese la cantidad de filas");
	 filas=sc.nextInt();
	System.out.println("Ingrese la cantidad de columnas");
	 col=sc.nextInt();
	  matriz= new int[filas][col];
	for(int i=0;i<5;i=i+(1)){

	for(int j=0;j<5;j=j+(1)){

	matriz[i][j]=i*2;
	}
	}
	System.out.println("VALORES MATRIZ");
	  impresionMatriz="_";
	for(int i=0;i<5;i=i+(1)){

	impresionMatriz="_";
	for(int j=0;j<5;j=j+(1)){

	impresionMatriz=impresionMatriz+"_"+matriz[i][j]+"_ ";
	}
	System.out.println(impresionMatriz);
	}
	System.out.println("VALORES TRANSPUESTA");
	 String impresionMatrizT="_";
	for(int i=0;i<5;i=i+(1)){

	impresionMatrizT="_";
	for(int j=0;j<5;j=j+(1)){

	impresionMatrizT=impresionMatrizT+"_"+matriz[j][i]+"_";
	}
	System.out.println(impresionMatrizT);
	}
	break;	case 4:

	System.out.println("Ingrese la cantidad de filas");
	int filas1=sc.nextInt();
	System.out.println("Ingrese la cantidad de columnas");
	 int col1=sc.nextInt();
	 int[][] matriz1= new int[filas1][col1];
	for(int i=0;i<5;i=i+(1)){

	for(int j=0;j<5;j=j+(1)){

	matriz1[i][j]=i*2;
	}
	}
	int[][] matriz2= new int[filas1][col1];
	for(int i=0;i<5;i=i+(1)){

	for(int j=0;j<5;j=j+(1)){

	matriz2[i][j]=i*j;
	}
	}
	System.out.println("MATRIZ1");
    String impresionMatriz1="_";
	for(int i=0;i<5;i=i+(1)){

	impresionMatriz1="_";
	for(int j=0;j<5;j=j+(1)){

	impresionMatriz1=impresionMatriz1+"_"+matriz1[i][j]+"_ ";
	}
	System.out.println(impresionMatriz1);
	}
	System.out.println("MATRIZ2");
	System.out.println("Imprimir valores de las matrices");
    String impresionMatriz2="_";
	for(int i=0;i<5;i=i+(1)){

	impresionMatriz2="_";
	for(int j=0;j<5;j=j+(1)){

	impresionMatriz2=impresionMatriz2+"_"+matriz2[i][j]+"_ ";
	}
	System.out.println(impresionMatriz2);
	}
	for(int i=0;i<5;i=i+(1)){

	impresionMatriz2="_";
	for(int j=0;j<5;j=j+(1)){

	impresionMatriz2=impresionMatriz2+"_"+matriz1[i][j]+matriz2[i][j]+"_ ";
	}
	System.out.println(impresionMatriz2);
	}
	break;	case 3:

	System.out.println("Ingrese el numero limite de la serie");
	int limit=sc.nextInt();
	System.out.println("La serie de "+limit+"es");
	 String res="_";
	for(int i=0;i<8;i=i+(1)){

	if(i==limit ){

	res=res+serieFibonacci(i);
	}else {

	res=res+serieFibonacci(i)+"_";
	}
	}
	System.out.println(res);
	break;
	}
}
	}public static int serieFibonacci(int n){

	 int res=0;
	if(n>1 ){
return serieFibonacci(n)+serieFibonacci(n);
	}else if(n==1 || n==0 ){

	res=n;
	}return res;
}
}