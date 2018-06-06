package otros;

public class AuxPosicion {
	private float x;
	private float y;
	
	public AuxPosicion(){
		this.x=0;
		this.y=0;
	}
	
	public AuxPosicion(float x,float y){
		this.x=x;
		this.y=y;
	}
	
	public AuxPosicion(AuxPosicion coor){
		this.x=coor.x;
		this.y=coor.y;
	}
	
	public float getX(){
		return x;
	}
	
	public void SetX(float x){
		this.x=x;
	}
	
	public float getY(){
		return y;
	}
	
	public void SetY(float y){
		this.y=y;
	}
	

}
