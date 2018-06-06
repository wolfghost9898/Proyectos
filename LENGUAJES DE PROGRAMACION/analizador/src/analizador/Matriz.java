package analizador;

public class Matriz {
private int[] abecedario;

	public Matriz() {

	}
	
	public int[] signos(){
		abecedario= new int[16];
		abecedario[0]=58;
		abecedario[1]=59;
		abecedario[2]=44;
		abecedario[3]=46;
		abecedario[4]=34;
		abecedario[5]=40;
		abecedario[6]=41;
		abecedario[7]=39;
		abecedario[8]=45;
		abecedario[9]=95;
		abecedario[10]=33;
		abecedario[11]=173;
		abecedario[12]=168;
		abecedario[13]=63;
		abecedario[14]=91;
		abecedario[15]=93;
		return abecedario;
	}

}
