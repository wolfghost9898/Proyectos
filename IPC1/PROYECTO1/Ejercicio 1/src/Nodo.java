
public class Nodo {
	public int dato;
	Nodo siguiente,anterior;
	
	//recien creado
	public Nodo(int elemento){
		this(elemento,null,null);
	}
	
	//ya hay nodos
	public Nodo(int elemento,Nodo s, Nodo a){
		dato=elemento;
		siguiente=s;
		anterior=a;
	}
	

	
	

}
