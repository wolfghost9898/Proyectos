package otros;

import java.awt.Color;
import java.awt.Graphics;
import java.awt.Font;
import Game.Drawable;

public class TextoGrafico implements Drawable {
	String s;
    Color color;
    int anchoV;
    int altoV;
    int size;
    
    public TextoGrafico(String hola, Color unColor, int a, int h) {
        this.s = hola;
        this.color = unColor;
        this.size = 10;
        this.anchoV = a;
        this.altoV = h;
    }
    
    public void Borrartexto(Graphics g,String txt)
    {
        g.setColor(Color.WHITE);
        g.setFont(new Font("Agency FB", Font.PLAIN, this.getSize()));
        int ancho = (int)g.getFontMetrics().getStringBounds(txt, g).getWidth();
        int alto = (int)g.getFontMetrics().getAscent();
        int x = this.anchoV/2 - ancho/2;
        int y = this.altoV/2 + alto/4;        
        g.drawString(txt, x, y);
    }
    
    public void Pintartexto(Graphics g,String txt)
    {
        g.setColor(Color.RED);
        g.setFont(new Font("Algerian", Font.PLAIN, this.getSize()));
        int ancho = (int)g.getFontMetrics().getStringBounds(txt, g).getWidth();
        int alto = (int)g.getFontMetrics().getAscent();
        int x = this.anchoV/2 - ancho/2;
        int y = this.altoV/2 + alto/4;        
        g.drawString(txt, x, y);
    }
    
	@Override
	public void draw(Graphics g) {
			g.setColor(color);
	        g.setFont(new Font("PLAIN", Font.PLAIN, this.getSize()));
	        int ancho = (int)g.getFontMetrics().getStringBounds(s, g).getWidth();
	        int alto = (int)g.getFontMetrics().getAscent();
	        int x = this.anchoV/2 - ancho/2;
	        int y = this.altoV/2 + alto/4;        
	        g.drawString(s, x, y);
		
	}
	
	  public void setSize(int nuevoSize){
	        size = nuevoSize;
	    }
	    
	    public int getSize(){
	        return size;
	    }  
	    
	    public void SetColor(Color a){
	    	this.color=a;
	    }

}
