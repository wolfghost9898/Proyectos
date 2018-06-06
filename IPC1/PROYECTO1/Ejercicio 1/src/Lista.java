
public class Lista {
	private Nodo inicio,fin;
	
	public Lista(){
		inicio=fin=null;
	}
	
	//Saber si lista esta vacia
	public boolean estado(){
		return inicio==null;
	}
	
	//Agregar nodo al final 
	public void agregarFin(int elemento){
		if(!estado()){
			fin= new Nodo(elemento,null,fin);
			fin.anterior.siguiente=fin;
		}else{
			inicio=fin=new Nodo(elemento);
		}
	}
	
	//Agregar al Inicio
	public void agregarInicio(int elemento){
		if(!estado()){
			inicio= new Nodo(elemento,inicio,null);
			inicio.siguiente.anterior=inicio;
		}else{
			inicio=fin=new Nodo(elemento);
		}
	}
	
	//Mostrar la Lista
	
	public void mostrarDatosInicio(){
		if(!estado()){
			String datos="<=>";
			Nodo auxiliar=inicio;
			while(auxiliar!=null){
				datos=datos+"["+auxiliar.dato+"]<=>";
				auxiliar=auxiliar.siguiente;
			}
			System.out.println(datos);
		}
	}
	
	public void mostrarDatosFin(){
		if(!estado()){
			String datos="<=>";
			Nodo auxiliar=fin;
			while(auxiliar!=null){
				datos=datos+"["+auxiliar.dato+"]<=>";
				auxiliar=auxiliar.anterior;
			}
			System.out.println(datos);
		}
	}
	
	
	//Operaciones
	public int Cantidad(){
		int numero=0;
		Nodo auxiliar=inicio;
		while(auxiliar!=null){
			numero++;
			auxiliar=auxiliar.siguiente;
		}
		return numero;
	}
	
	public void Guardar(int elemento){
		Nodo auxiliar=inicio;
		Nodo guardar= new Nodo(elemento);
		if(!estado()){
			while(auxiliar!=null){
				try{
					
					Nodo aux= auxiliar.siguiente;
					if(auxiliar.dato<elemento && elemento<aux.dato){
						guardar.siguiente=aux;
						auxiliar.siguiente.anterior=guardar;
						auxiliar.siguiente=guardar;
					}else if(auxiliar==inicio && elemento<auxiliar.dato){
						if(elemento!=auxiliar.dato){
							agregarInicio(elemento);
						}
						
					}
					
					auxiliar=auxiliar.siguiente;
				}catch(Exception e){
					agregarFin(elemento);
				}
				
				
			}
		}else{
			inicio=fin=new Nodo(elemento);
		}
	}
	
	
	
	
	public void Borrar(int element){
		Nodo anterior=null;
		Nodo actual=inicio;
		try{
		while(actual!=null){
		  
			if(actual.dato==element){
				if(anterior==null){
					inicio=actual.siguiente;
					inicio.anterior=null;
				}else{
					anterior.siguiente=actual.siguiente;
					Nodo temporal;
					temporal=actual.siguiente;
					temporal.anterior=anterior;
				}	
			}
			anterior=actual;
			actual=actual.siguiente;
		}
		  }catch(Exception x){}
		  	
		  	if(element==fin.dato){
				fin=actual.anterior;
			}  
		
	} 
	
	
}
