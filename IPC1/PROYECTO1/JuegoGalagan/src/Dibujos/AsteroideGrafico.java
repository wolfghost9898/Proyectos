package Dibujos;

import java.awt.Color;
import java.awt.Graphics;

import javax.swing.ImageIcon;
import javax.swing.JPanel;

import Disparo.DisparoGrafico;
import Game.Drawable;
import otros.AuxPosicion;

public class AsteroideGrafico  extends  Asteroide implements Drawable{
	JPanel panel;
	public AsteroideGrafico(AuxPosicion coor,float x,float y,JPanel panel){
		super(coor,x,y);
		this.panel=panel;
	}
	
	
	@Override
	public void draw(Graphics g) {
		ImageIcon disparo= new ImageIcon(getClass().getResource("/imagenes/enemigo.png"));
		g.drawImage(disparo.getImage(), (int)this.getX(),(int) this.getY(), null, panel);
		
	}
	
	public void Ciclo(){
		for(int i=0;i<this.asteroides.size();i++){
			AsteroideGrafico y= (AsteroideGrafico) this.asteroides.get(i);
			float x= y.getX();
			y.SetX(x+=2);
		}
	}
	
	public AsteroideGrafico Asteroide(){
		int ramdon= (int)(Math.random()*(400));
		AuxPosicion salida= new AuxPosicion(this.getX()-10,this.getY()+1);
		AsteroideGrafico aste= new AsteroideGrafico(salida,0,ramdon,panel);
		return aste;
	}
	
	public void DeleteAsteroide(Graphics g,int x,int y){
		g.clearRect(x,y, 30, 30);
	}
	

}
