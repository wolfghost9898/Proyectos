package Game;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.Label;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.io.IOError;
import java.net.URL;
import java.util.ArrayList;
import java.util.Timer;
import java.util.Vector;

import javax.swing.*;
import javax.swing.JPanel;

import Dibujos.AsteroideGrafico;
import Disparo.DisparoGrafico;
import Nave.NaveGrafica;
import otros.AuxPosicion;
import otros.TextoGrafico;


public class Panel extends JPanel implements KeyListener,Runnable{
	Thread hilo,hilo2;
	Vector vector;
	ArrayList ventana;
	ArrayList ast= new ArrayList();
	AuxPosicion movUp= new AuxPosicion(0,-10);
	AuxPosicion movDown= new AuxPosicion(0,10);
	NaveGrafica nave;
	int ContadorAsteroides=1,tiempo=60;
	public AsteroideGrafico Asteroide;
	
	TextoGrafico puntos;
	TextoGrafico vidas;
	TextoGrafico Final;
	boolean estado=true;
	int Score=0;

	
	
	public Panel(ArrayList ventana){
	this.ventana=ventana;
	this.addKeyListener(this);
	setFocusable(true);
	vector= new Vector(20,5);
	setLayout(null);
	
	

	}
		
		
	
	
	public void paint(Graphics g){
		Dimension d= getSize();
		Image imagen= createImage(d.width,d.height);
		Graphics buff= imagen.getGraphics();
		Drawable draw;
		for(int i=0;i<ventana.size();i++){
			draw=(Drawable) ventana.get(i);
			draw.draw(buff);
		}
		g.drawImage(imagen, 0, 0, null);
		
	}

	
	@Override
	public void update(Graphics g){
		paint(g);
	}
	
	@Override
	public void keyPressed(KeyEvent e) {
		int tecla= e.getKeyCode();
		if(tecla==KeyEvent.VK_UP){
			this.nave.Mover(movUp);
			this.nave.pintar(getGraphics(),"arriba");
		}else if(tecla==KeyEvent.VK_DOWN){
			this.nave.Mover(movDown);
			this.nave.pintar(getGraphics(),"abajo");
		}else if(tecla==KeyEvent.VK_C){
			DisparoGrafico bala= nave.Bala();
			nave.balas.add(bala);
			ventana.add(bala);
			
		}
	}
	


	@Override
	public void keyReleased(KeyEvent arg0) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void keyTyped(KeyEvent arg0) {
		// TODO Auto-generated method stub
	}
	
	public void refNave(NaveGrafica nave){
		this.nave=nave;
		ventana.add(nave);
	}
	
	public void RefPuntos(TextoGrafico s){
		this.puntos=s;
	}
	
	
	public void RefFinal(TextoGrafico s){
		this.Final=s;
	}
	
	public void refAstero(AsteroideGrafico a){
		Asteroide=a;
		ast.add(a);
		Object[] asteroide={a,0};
		vector.addElement(asteroide);
		if(hilo==null){
	        hilo=new Thread(this);
	        hilo.start();
	        
	        hilo2=new Thread(this);
	        hilo2.start();
		}
		
	}
	
	
	
	
	public void iniciar(){
		while(estado){
			try{
				if(!nave.balas.isEmpty()){
					nave.Ciclo();
				}
				int rango=Random(250,10);
				for(int i=0;i<ast.size();i++){
					AsteroideGrafico aste=(AsteroideGrafico) ast.get(i);
					aste.Ciclo();
				}
				Colision();
				Thread.sleep(40);
			}catch(InterruptedException rr){
				System.out.println(rr);
			}
			repaint();
			
		}
		
	}
	
	
	public static int Random(int Max,int Min){
		return (int)(Math.random()*(Max-Min));
	}
	
	public void Colision(){
		for(int i=0;i<nave.balas.size();i++){
			DisparoGrafico bala=(DisparoGrafico)nave.balas.get(i);
			for(int j=0;j<ast.size();j++){
				AsteroideGrafico aste=(AsteroideGrafico) ast.get(j);
				AuxPosicion CordBala= new AuxPosicion(bala.getX(),bala.getY());
				AuxPosicion arriba= new AuxPosicion(aste.getX()+4,aste.getY()-1);
				AuxPosicion abajo= new AuxPosicion(aste.getX()-4,aste.getY()+29);
				AuxPosicion medio= new AuxPosicion(aste.getX()+2,aste.getY());
				if(CordBala.getY()>arriba.getY() && CordBala.getY()<abajo.getY() && CordBala.getX()<=arriba.getX() && CordBala.getX()>=abajo.getX() ){
					int valor=0;

						Object[] asteroide=(Object[])vector.elementAt(j);
						valor= (int)asteroide[1];
						Object[] asteroide2={asteroide[0],valor+1};
						vector.setElementAt(asteroide2, j);
						bala.SetX(-100);	
						if((valor+1)>=3){
							aste.SetX(10000);
							vector.remove(j);
							ast.remove(aste);			
							Score=Score +25;
							ventana.remove(puntos);
							String NuevoScore=""+Score;
							TextoGrafico scro= new TextoGrafico(NuevoScore,Color.RED,1200,200);
							scro.setSize(20);
							puntos= scro;
							ventana.add(puntos);
						}
					System.out.println("colision");
					
				}
				if(medio.getX()>nave.getX()+11 && medio.getX()<763 ){
					aste.SetX(10000);
					vector.remove(j);
					ast.remove(aste);	
					System.out.println("fin");
					hilo2.stop();
					hilo.stop();
					estado=false;
					ventana.add(Final);
				}
			}
		}
	}


	

	@Override
	public void run() {
		Thread ct= Thread.currentThread();
		if(ct==hilo){//Hilo 1
			while(true){
				try{
					GenerarEnemigos();
					Thread.sleep(50);
				}catch(InterruptedException rr){
					System.out.println(rr);
				}
			}
		} //Fin hilo 1
		
		if(ct==hilo2){//Hilo 2
			TextoGrafico Lifes= new TextoGrafico("60",Color.red,1200,100);
			Lifes.setSize(20);
			while(true){
				try{
					tiempo=tiempo-1;
					ventana.remove(Lifes);
					String nuevoTiempo=""+tiempo;
					TextoGrafico newLifes= new TextoGrafico(nuevoTiempo,Color.red,1200,100);
					newLifes.setSize(20);
					Lifes=newLifes;
					ventana.add(Lifes);
					Thread.sleep(1000);
				}catch(InterruptedException rr){
					System.out.println(rr);
				}
				if(tiempo<=0){
					ventana.add(Final);
					hilo.stop();
	        		estado=false;
	        		hilo2.stop();
				}
			
			}
		}//Fin Hilo 2
	}
	
	public void GenerarEnemigos(){
		try{
			int seg=(int)(Math.random()*(3)+2);
			
			AsteroideGrafico aste= Asteroide.Asteroide();
			Asteroide.asteroides.add(aste);
			ventana.add(aste);
			ast.add(aste);
			Object[] asteroide={aste,0};
			vector.addElement(asteroide);
			Thread.sleep(seg*1000);
			
		}catch(InterruptedException rr){
			System.out.println(rr);
		}
	}
	
	
}





