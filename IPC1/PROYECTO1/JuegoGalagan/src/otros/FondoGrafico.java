package otros;

import java.awt.Graphics;

import javax.swing.ImageIcon;
import javax.swing.JPanel;

import Game.Drawable;

public class FondoGrafico extends Fondo implements Drawable{
	JPanel panel;
	
	public FondoGrafico(AuxPosicion coor,float x,float y,JPanel panel){
		super(coor,x,y);
		this.panel=panel;
	}
	
	@Override
	public void draw(Graphics g) {
		ImageIcon disparo= new ImageIcon(getClass().getResource("/imagenes/fondo.jpg"));
		g.drawImage(disparo.getImage(), 0,0, null, panel);
		
	}

}
