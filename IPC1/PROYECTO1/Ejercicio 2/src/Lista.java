
public class Lista {
	Nodo ultimo;
	Nodo primero;
	public Lista(){
		ultimo=null;
		primero=null;
	}
	
	public void ingresarDato(int dato){
		Nodo nuevo= new Nodo();
		nuevo.numero=dato;
		Nodo auxiliar=primero;
		nuevo.numero=dato;
		if(primero==null){
			primero=nuevo;
			ultimo=primero;
			primero.siguiente=ultimo;
		}else{
			do{
				try{
				Nodo actual= auxiliar.siguiente;				
				if(auxiliar.numero<dato && dato<actual.numero){
					nuevo.siguiente=actual;
					auxiliar.siguiente=nuevo;
					
				}					
				auxiliar=auxiliar.siguiente;
				}catch(Exception e){
					
				}
			}while(auxiliar!=primero);
			if(dato>ultimo.numero){
				ultimo.siguiente=nuevo;
				nuevo.siguiente=primero;
				ultimo=nuevo;
				}
			
		}
	}

	public void Mostrar(){
		Nodo actual= new Nodo();
		actual=primero;
		String cadena="";
		do{
			cadena=cadena+" "+actual.numero+"->";
			actual=actual.siguiente;
		}while(actual!=primero);
		System.out.println(cadena);
	}
	
	public void Elimiar(int numero){
		Nodo actual=new Nodo();
		Nodo anterior= new Nodo();
		actual=primero;
		anterior=ultimo;
		do{
			if(actual.numero==numero){
				if(actual==primero){
					primero=primero.siguiente;
					ultimo.siguiente=primero;
				}else if(actual==ultimo){
					anterior.siguiente=ultimo.siguiente;
					ultimo=anterior;
				}else{
					anterior.siguiente=actual.siguiente;
				}
			}
			anterior=actual;
			actual=actual.siguiente;
		}while(actual!=primero);
	}
	
	
}
