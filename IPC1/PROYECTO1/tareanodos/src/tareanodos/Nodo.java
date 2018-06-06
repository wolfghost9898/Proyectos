package tareanodos;

public class Nodo {
	
	private int cantidad;
	private Nodo siguiente;
	
	public void Nodo(){
		this.cantidad=0;
		this.siguiente=null;
	}
	
	public int getCantidad(){
		return cantidad;
	}
	
	public void setCantidad(int cantidad){
		this.cantidad=cantidad;
	}
	
	public Nodo getSiguiente(){
		return siguiente;
	}
	
	public void setSiguiente(Nodo siguiente){
		this.siguiente=siguiente;
	}
	

}
