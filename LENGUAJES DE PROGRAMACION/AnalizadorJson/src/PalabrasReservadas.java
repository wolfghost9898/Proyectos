
public class PalabrasReservadas {
	String [][] Palabras_Reservadas= new String[17][2];
	String [][] atributo= new String[9][2];
	public   PalabrasReservadas() {
	}
	
	public String[][] GuardarDatos(){
		Palabras_Reservadas[0][0]="Inicio";Palabras_Reservadas[0][1]="<html>";
		Palabras_Reservadas[1][0]="Encabezado";Palabras_Reservadas[1][1]="<head>";
		Palabras_Reservadas[2][0]="TituloPagina";Palabras_Reservadas[2][1]="<title>";
		Palabras_Reservadas[3][0]="Cuerpo";Palabras_Reservadas[3][1]="<body>";
		Palabras_Reservadas[4][0]="Texto";Palabras_Reservadas[4][1]="caca";
		Palabras_Reservadas[5][0]="Parrafo";Palabras_Reservadas[5][1]="<p>";
		Palabras_Reservadas[6][0]="Centro";Palabras_Reservadas[6][1]="<center>";
		Palabras_Reservadas[7][0]="Izquierda";Palabras_Reservadas[7][1]="<left>";
		Palabras_Reservadas[8][0]="Derecha";Palabras_Reservadas[7][1]="<right>";
		Palabras_Reservadas[9][0]="Negrita";
		Palabras_Reservadas[10][0]="Cursiva";
		Palabras_Reservadas[11][0]="Subrayado";
		Palabras_Reservadas[12][0]="Titulo";
		Palabras_Reservadas[13][0]="Tabla";
		Palabras_Reservadas[14][0]="Fila";
		Palabras_Reservadas[15][0]="Imagen";
		Palabras_Reservadas[16][0]="Color";
		return Palabras_Reservadas;
	}
	
	public String[][] Atributo(){
		atributo[0][0]="Fondo";atributo[0][1]="";
		atributo[1][0]="izquierda";atributo[2][1]="<left>";
		atributo[2][0]="derecha";atributo[3][1]="<right>";
		atributo[3][0]="centro";
		atributo[4][0]="Face";
		atributo[5][0]="Text";
		atributo[6][0]="Tamaño";
		atributo[7][0]="Posicion";
		atributo[8][0]="color";
		return atributo;
		
	}

}
