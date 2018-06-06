

import java.awt.Color;
import java.util.ArrayList;
import java.util.Timer;

import javax.swing.JLabel;
import javax.swing.JOptionPane;

import Dibujos.AsteroideGrafico;
import Disparo.DisparoGrafico;
import Game.Panel;
import Game.Ventana;
import Nave.NaveGrafica;
import otros.AuxPosicion;
import otros.FondoGrafico;
import otros.TextoGrafico;

public class MainActivity  {
	static Panel panel;
	static boolean estado=true;

	public static void main(String[] args){
		
			
	while(estado){      
		Ventana game= new Ventana("Juego Galagan");
		ArrayList ArregloObjetos= new ArrayList();
		 panel= new Panel(ArregloObjetos);
		 
		//Juego Iniciado
		//Nave
		 AuxPosicion coor3= new AuxPosicion(750,200);
			NaveGrafica nave= new NaveGrafica(coor3,10,10,panel);
		//Fondo
		 AuxPosicion fondo= new AuxPosicion(5,5);
		 FondoGrafico fondog= new FondoGrafico(fondo,10,10,panel);
		
		
		int rango=Random(250,10);
		AuxPosicion salida= new AuxPosicion(0,rango);
		AsteroideGrafico Asteroide1= new AsteroideGrafico(salida,0,rango,panel);
		

		ArregloObjetos.add(fondog);
		

		//Texto
		TextoGrafico Vidas= new TextoGrafico("Tiempo",Color.WHITE,1200,50);
		Vidas.setSize(20);
		
		
		
		TextoGrafico Puntos= new TextoGrafico("Puntos",Color.WHITE,1200,150);
		Puntos.setSize(20);
		TextoGrafico Score= new TextoGrafico("0",Color.red,1200,200);
		Score.setSize(20);
		
		TextoGrafico Lost= new TextoGrafico("Game  Over",Color.WHITE,780,550);
		Lost.setSize(60);
		
		
		ArregloObjetos.add(Vidas);
		ArregloObjetos.add(Puntos);
		ArregloObjetos.add(Score);
		
	
		
		panel.refAstero(Asteroide1);	
		panel.refNave(nave);
		
		panel.RefPuntos(Score);
		panel.RefFinal(Lost);
		
		game.add(panel);
		game.setVisible(true);
	
		panel.iniciar();
		
		int ax = JOptionPane.showConfirmDialog(null, "Reiniciar Juego?");
        if(ax == JOptionPane.YES_OPTION){
        	estado=true;
        	game.dispose();
        }else if(ax == JOptionPane.NO_OPTION){
        	estado=false;
			}
		}

	}	
	
	public static int Random(int Max,int Min){
		return (int)(Math.random()*(Max-Min));
	}
	

	
}
