package Helpers;

public class LetterNumbers {
String[][] abecedario= new String[26][2];
private int numero;
	public LetterNumbers() {
		abecedario[0][0]="A";abecedario[0][1]="1";
		abecedario[1][0]="B";abecedario[1][1]="2";
		abecedario[2][0]="C";abecedario[2][1]="3";
		abecedario[3][0]="D";abecedario[3][1]="4";
		abecedario[4][0]="E";abecedario[4][1]="5";
		abecedario[5][0]="F";abecedario[5][1]="6";
		abecedario[6][0]="G";abecedario[6][1]="7";
		abecedario[7][0]="H";abecedario[7][1]="8";
		abecedario[8][0]="I";abecedario[8][1]="9";
		abecedario[9][0]="J";abecedario[9][1]="10";
		abecedario[10][0]="K";abecedario[10][1]="11";
		abecedario[11][0]="L";abecedario[11][1]="12";
		abecedario[12][0]="M";abecedario[12][1]="13";
		abecedario[13][0]="N";abecedario[13][1]="14";
		abecedario[14][0]="O";abecedario[14][1]="15";
		abecedario[15][0]="P";abecedario[15][1]="16";
		abecedario[16][0]="Q";abecedario[16][1]="17";
		abecedario[17][0]="R";abecedario[17][1]="18";
		abecedario[18][0]="S";abecedario[18][1]="19";
		abecedario[19][0]="T";abecedario[19][1]="20";
		abecedario[20][0]="U";abecedario[20][1]="21";
		abecedario[21][0]="V";abecedario[21][1]="22";
		abecedario[22][0]="W";abecedario[22][1]="23";
		abecedario[23][0]="X";abecedario[23][1]="24";
		abecedario[24][0]="Y";abecedario[24][1]="25";
		abecedario[25][0]="Z";abecedario[25][1]="26";
	}
	
	public int convertAB(String letra){
		for(int i=0;i<26;i++){
			if(letra.equals(abecedario[i][0])){
				numero=Integer.parseInt(abecedario[i][1]);
				break;
			}
			
		}
		return numero;
	}

}
