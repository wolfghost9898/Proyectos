package Dibujos;

import java.util.ArrayList;

import otros.AuxPosicion;

public class Asteroide extends AuxPosicion {
	public ArrayList asteroides= new ArrayList();
	float x;
	float y;
	int disparo;
	
	public Asteroide(){
		
		super();
	}
	public Asteroide(AuxPosicion coor,float x,float y){
		super(coor);
		this.x=x;
		this.y=y;
		disparo=0;
	}
	
	public Asteroide(Asteroide asteroide){
		super(asteroide.getX(),asteroide.getY());
		
	}
	
	public float getX(){
		return x;
	}
	

	public float getY(){
		return y;
	}
	
	public void SetY(float y){
		this.y=y;;
	}
	public void SetX(float x){
		this.x=x;;
	}
	
	public int getDisparo(){
		return disparo;
	}
	
	public void setDisparo(int disparo){
		this.disparo=disparo;
	}
	
}
