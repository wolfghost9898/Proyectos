package Listas;

import Text.copyData;

public class Lista {
	Nodo ultimo;
	Nodo primero;
	Nodo actual;
	public Lista(){
		ultimo=null;
		primero=null;
		actual= new Nodo();

	}
	
	public void ingresarDato(Object[] dato){
		Nodo nuevo= new Nodo();
		nuevo.data=dato;
		Nodo auxiliar=primero;
		nuevo.data=dato;
		if(primero==null){
			primero=nuevo;
			ultimo=primero;
			primero.siguiente=ultimo;
			actual=ultimo;
		}else{
			ultimo.siguiente=nuevo;
			nuevo.siguiente=primero;
			ultimo=nuevo;
			actual=ultimo;
		}
	}
	
	public void Mostrar(){
		Nodo actual2= new Nodo();
		actual2=primero;
		String cadena="";
		do{
			Object[] data=actual2.data;
			cadena=cadena+" "+data[2]+"->";
			actual2=actual2.siguiente;
		}while(actual2!=primero);
		System.out.println(cadena);
	}
	
	public Object[] Ultimo(){
		copyData ccopy= new copyData();
		ccopy.setEstado(false);
		Object[] data= actual.data;
		Nodo prueba= new Nodo();
		Nodo cambiar= new Nodo();
		cambiar=actual;
		prueba=primero;
		do{
			prueba=prueba.siguiente;
			actual=prueba;
		}while(prueba.siguiente!=cambiar);
		return cambiar.data;
	}
	
	public Object[] Primero(){
		copyData ccopy= new copyData();
		ccopy.setEstado(false);
		Nodo prueba= new Nodo();
		Nodo cambiar= new Nodo();
		cambiar=actual;
		prueba=primero;
		do{
			prueba=prueba.siguiente;
			actual=prueba.siguiente;
		}while(prueba!=cambiar);
		Object[] data= actual.siguiente.data;
		return data;
	}

}
