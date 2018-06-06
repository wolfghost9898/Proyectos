package otros;

import Disparo.Disparo;

public class Fondo extends AuxPosicion {
	float x;
	float y;
	
	public Fondo(){
		super();
	}
	
	public Fondo(AuxPosicion nueva,float x,float y){
		super(nueva);
		this.x=x;
		this.y=y;
	}
	
	public Fondo(Disparo disparo){
		super(disparo);
	}
}
