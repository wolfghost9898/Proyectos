package Nave;

import java.util.ArrayList;

import otros.AuxPosicion;

public class Nave extends AuxPosicion{
	float x;
	float y;
	public AuxPosicion coor1= new AuxPosicion();
	public ArrayList balas= new ArrayList();
	
	public Nave(){
		super();
	}
	
	public Nave(AuxPosicion nueva,float x,float y){
		super(nueva);
		this.x=x;
		this.y=y;
	}
	
	public Nave(Nave nave){
		super(nave);
	}
	
	public void setLugar(AuxPosicion posicion){
		if(this.getY() +posicion.getY()>425 || this.getY() +posicion.getY()<0 ){
			
		}else{
			this.SetX(this.getX()+ posicion.getX());
			this.SetY(this.getY() +posicion.getY());
		}
		
		
	}
	
	public void Mover(AuxPosicion nuevamover){
		setLugar(nuevamover);
		
	}
}
