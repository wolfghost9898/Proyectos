package Disparo;

import java.awt.Graphics;

import javax.swing.ImageIcon;
import javax.swing.JPanel;

import Game.Drawable;
import otros.AuxPosicion;

public class DisparoGrafico extends Disparo implements Drawable {
JPanel panel;
	public DisparoGrafico(AuxPosicion coor,float x,float y,JPanel panel){
		super(coor,x,y);
		this.panel=panel;
	}
	
	@Override
	public void draw(Graphics g) {
		ImageIcon disparo= new ImageIcon(getClass().getResource("/imagenes/shot.png"));
		g.drawImage(disparo.getImage(), (int)this.getX(),(int) this.getY(), null, panel);
		
	}

}
