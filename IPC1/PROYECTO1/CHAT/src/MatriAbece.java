
public class MatriAbece {
String[][] abecedario;
String cadena;
String descadena;
	public MatriAbece() {
		abecedario= new String[28][2];
		abecedario[0][0]="c";abecedario[0][1]="a";
		abecedario[1][0]="a";abecedario[1][1]="b";
		abecedario[2][0]="r";abecedario[2][1]="c";
		abecedario[3][0]="l";abecedario[3][1]="d";
		abecedario[4][0]="o";abecedario[4][1]="e";
		abecedario[5][0]="s";abecedario[5][1]="f";
		abecedario[6][0]="b";abecedario[6][1]="g";
		abecedario[7][0]="d";abecedario[7][1]="h";
		abecedario[8][0]="e";abecedario[8][1]="i";
		abecedario[9][0]="f";abecedario[9][1]="j";
		abecedario[10][0]="g";abecedario[10][1]="k";
		abecedario[11][0]="h";abecedario[11][1]="l";
		abecedario[12][0]="i";abecedario[12][1]="m";
		abecedario[13][0]="j";abecedario[13][1]="n";
		abecedario[14][0]="k";abecedario[14][1]="ñ";
		abecedario[15][0]="m";abecedario[15][1]="o";
		abecedario[16][0]="n";abecedario[16][1]="p";
		abecedario[17][0]="ñ";abecedario[17][1]="q";
		abecedario[18][0]="p";abecedario[18][1]="r";
		abecedario[19][0]="q";abecedario[19][1]="s";
		abecedario[20][0]="t";abecedario[20][1]="t";
		abecedario[21][0]="u";abecedario[21][1]="u";
		abecedario[22][0]="v";abecedario[22][1]="v";
		abecedario[23][0]="w";abecedario[23][1]="w";
		abecedario[24][0]="x";abecedario[24][1]="x";
		abecedario[25][0]="y";abecedario[25][1]="y";
		abecedario[26][0]="z";abecedario[26][1]="z";
		abecedario[27][0]=" ";abecedario[27][1]=" ";
	}
	
	public String encript(String letra){
		cadena="";
		for(int j=0;j<letra.length();j++){
			for(int i=0;i<28;i++){
					if(abecedario[i][1].equals(String.valueOf(letra.charAt(j)))){
						cadena=cadena+abecedario[i][0];
					}
				
			}
		}
		
		return cadena;
	}
	
	public String descript(String letra){
		descadena="";
		for(int j=0;j<letra.length();j++){
			for(int i=0;i<28;i++){
					if(abecedario[i][0].equals(String.valueOf(letra.charAt(j)))){
						descadena=descadena+abecedario[i][1];
					}
			}
		}
		
		return descadena;
	}

}
