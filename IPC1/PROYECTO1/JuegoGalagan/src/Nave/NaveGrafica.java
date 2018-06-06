package Nave;

import java.awt.Color;
import java.awt.Graphics;

import javax.swing.ImageIcon;
import javax.swing.JPanel;

import Disparo.DisparoGrafico;
import Game.Drawable;
import otros.AuxPosicion;

public class NaveGrafica extends Nave implements Drawable {
JPanel panel;
ImageIcon disparo;
	
	public NaveGrafica(AuxPosicion coor,float x,float y,JPanel panel){
		super(coor,x,y);
		this.panel=panel;
	}
	@Override
	public void draw(Graphics g) {
		 disparo= new ImageIcon(panel.getClass().getResource("/imagenes/nave.png"));
		g.drawImage(disparo.getImage(), (int)this.getX(), (int)this.getY(), null, disparo.getImageObserver());
		
	}
	
	
	public void pintar(Graphics g,String tipo) {
		if(tipo=="arriba"){
			g.clearRect((int)this.getX(), ((int)this.getY()+10), disparo.getIconWidth(), disparo.getIconHeight());
		}else if(tipo=="abajo"){
			g.clearRect((int)this.getX(), ((int)this.getY()-10), disparo.getIconWidth(), disparo.getIconHeight());
		}
		
		g.drawImage(disparo.getImage(), (int)this.getX(), (int)this.getY(), null, disparo.getImageObserver());
		
		
	}
	
	public DisparoGrafico Bala(){
		AuxPosicion salida= new AuxPosicion(this.getX()-10,this.getY()+12);
		DisparoGrafico bala= new DisparoGrafico(salida,10,10,panel);
		return bala;
	}
	
	public void Ciclo(){
		for(int i=0;i<this.balas.size();i++){
			DisparoGrafico y= (DisparoGrafico) this.balas.get(i);
			float x= y.getX();
			y.SetX(x-=4);
		}
	}

}
