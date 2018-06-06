package Auxiliares;

public class Ordenamiento {
	//Ordenar Por dia
	public Object[][] OrdenarPorDia(int inicio,int fin,Object[][] temporal){
		for(int j=inicio; j<fin;j++){
			for(int k=inicio;k<(fin);k++){
				int mes=(int)temporal[j][4];
				int dia=(int)temporal[j][3];
				String name=(String)temporal[j][0];
				int canti=(int)temporal[j][1];
				Double preci=(Double)temporal[j][2];
				
				int mes2=(int)temporal[k][4];
				int dia2=(int)temporal[k][3];
				if(dia>dia2){
					
					int aux=mes;
					int aux2=dia;
					String aux3=name;
					int aux4=canti;
					double aux5=preci;
					
					temporal[j][4]=mes2;
					temporal[j][3]=dia2;
					temporal[j][2]=temporal[k][2];
					temporal[j][1]= temporal[k][1];
					temporal[j][0]= temporal[k][0];
					
					temporal[k][4]=aux;
					temporal[k][3]=aux2;
					temporal[k][2]=aux5;
					temporal[k][1]=aux4;
					temporal[k][0]=aux3;
				}
			}
		}
		return temporal;
	}
	
	//Ordenar por Mes
	public Object[][] OrdenarPorMes(Object[][] temporal){
		for(int j=0; j<temporal.length;j++){
			for(int k=0;k<(temporal.length);k++){
				int mes=(int)temporal[j][4];
				int dia=(int)temporal[j][3];
				String name=(String)temporal[j][0];
				int canti=(int)temporal[j][1];
				Double preci=(Double)temporal[j][2];
				
				int mes2=(int)temporal[k][4];
				int dia2=(int)temporal[k][3];
				if(mes>mes2){
					
					int aux=mes;
					int aux2=dia;
					String aux3=name;
					int aux4=canti;
					double aux5=preci;
					
					temporal[j][4]=mes2;
					temporal[j][3]=dia2;
					temporal[j][2]=temporal[k][2];
					temporal[j][1]= temporal[k][1];
					temporal[j][0]= temporal[k][0];
					
					temporal[k][4]=aux;
					temporal[k][3]=aux2;
					temporal[k][2]=aux5;
					temporal[k][1]=aux4;
					temporal[k][0]=aux3;
				}
			}
		}
		return temporal;
	}
	
	//Ordenar por tipo
	
	public Object[][] OrdenarPorTipo(Object[][] temporal){
		for(int j=0; j<temporal.length;j++){
			for(int k=0;k<(temporal.length);k++){
				String name=(String)temporal[j][0];
				int canti=(int)temporal[j][1];
				int tipo=(int)temporal[j][6];
				int tipo2=(int)temporal[k][6];
				if(tipo<tipo2){
					
					int aux=tipo;
					String aux3=name;
					int aux4=canti;
					temporal[j][6]=tipo2;
					temporal[j][1]= temporal[k][1];
					temporal[j][0]= temporal[k][0];
					
					temporal[k][6]=aux;
					temporal[k][1]=aux4;
					temporal[k][0]=aux3;
				}
			}
		}
		return temporal;
	}
	
	//Ordenamiento por cantidad de tipo
	public Object[][] OrdenarPorCant(int inicio,int fin,Object[][] temporal){
		for(int j=inicio; j<fin;j++){
			for(int k=inicio;k<fin;k++){
				String name=(String)temporal[j][0];
				int canti=(int)temporal[j][1];
				int tipo=(int)temporal[j][6];
				int canti2=(int)temporal[k][1];
				if(canti>canti2){
					
					int aux=canti;
					String aux3=name;
					int aux4=tipo;
					temporal[j][1]=canti2;
					temporal[j][6]= temporal[k][6];
					temporal[j][0]= temporal[k][0];
					
					temporal[k][6]=aux4;
					temporal[k][1]=aux;
					temporal[k][0]=aux3;
				}
			}
		}
		return temporal;
	}
	
	
}
