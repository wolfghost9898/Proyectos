package Auxiliares;

import java.util.Vector;

public class VecCompras {
	private static Vector compras;
	private static Object[] subventas;
	private static int dia,mes;
	private static boolean verificar;
	
	public Vector ComprasDelMes(){
		//Instancias
		compras= new Vector();
		/*
		 * Relleno de Productos
		 */
		String[] productos={"Ricardo Arjona","Rata Blanca","Daddy Yannke","Mago de Oz","Guns and Roses","Ricardo Andrade","La Gran Calabaza",
				"Malacates Trebol Shop","Tambor de la Tribu","Wisin y Yandel","Iphone 7","Samsung Galaxy 6","Moto g 2015","Macbook Air 13","Samsung Galaxy Note III",
				"AlienWare","Macbook Pro 13'","HTC one 9","Sony Xperia M","Procesador i7","Amazon","Play Store","Ebay","Steam","Mercado Libre","Starbucks",
				"Dominos Pizza","Subway","Papa John's","Netflix","Halo: Combat Evolved","FIFA 17","GTA V","Call of Duty 4: Modern Warfare","Fallout 4","Call of Duty: Black Ops III - Standard Edition",
				"Watch Dogs","Far Cry 4","Battlefield 4","Battlefield 3 Premium Edition","Ricardo Arjona","Rata Blanca","Daddy Yannke","Mago de Oz","Guns and Roses","Ricardo Andrade",
				"AlienWare","Macbook Pro 13'","HTC one 9","Sony Xperia M","Battlefield 3 Premium Edition","Ricardo Arjona","Rata Blanca","Daddy Yannke","Mago de Oz","Guns and Roses","Ricardo Andrade",
				"AlienWare","Macbook Pro 13'","HTC one 9","Sony Xperia M","Ricardo Arjona","Rata Blanca","Daddy Yannke","Mago de Oz","Guns and Roses","Ricardo Andrade",
				"Ricardo Arjona","Rata Blanca","Daddy Yannke","Papa John's"};
		Double[] precio={10.5,20.1,30.00,150.00,130.00,200.00,20.5,40.00,45.00,98.00,74.00,45.9,80.5,90.1,90.00,100.00,105.5,101.00,110.00,130.00,125.45,110.00,198.00,170.00,170.5,140.00,200.00,205.00,200.00,
						98.5,100.00,100.5,200.4,305.4,20.00,10.5,20.1,30.00,150.00,130.00,200.00,20.5,40.00,45.00,98.00,74.00,45.9,80.5,90.1,90.00,100.00,51.4,52.3,90.5,100.00,50.00,30.59,85.4,13.9,
						45.9,80.5,90.1,90.00,100.00,105.5,101.00,110.00,200.00,20.5,40.00,45.00};
		//Rellenar con un for

		for(int i=0;i<25;i++){
			verificar=true;
			mes=GenerarMes();
			dia=GenerarDia();
			while(verificar){
				if(mes==3 && dia>15 )dia=GenerarDia();
				else verificar=false;
			}
			int cant=(int)(Math.random()*100)+1;
			Object[] subventas={productos[i],cant,precio[i],dia,mes,(mes+dia)};
			compras.add(subventas);
		}

		return compras;
	}
	
	private int GenerarMes(){
		mes=(int)(Math.random()*3)+1;
		return mes;
	}
	
	private int GenerarDia(){
		dia=(int)(Math.random()*31)+1;
		return dia;
	}
	
}
