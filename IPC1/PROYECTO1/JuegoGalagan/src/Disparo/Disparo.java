package Disparo;

import otros.AuxPosicion;

public class Disparo extends AuxPosicion{
	float x;
	float y;
	public Disparo(){
		super();
	}
	
	public Disparo(AuxPosicion nueva,float x,float y){
		super(nueva);
		this.x=x;
		this.y=y;
	}
	
	public Disparo(Disparo disparo){
		super(disparo);
	}
	
	public AuxPosicion getCentro(){
		AuxPosicion nueva= new AuxPosicion(this.getX(),this.getY());
		return nueva;
	}
}
