/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package Listas;

/**
 *
 * @author HP
 */
public class ListaCircularSE {
     private NodoLista_circular primerNodo;
   private String nombre;  
   private int contador;

   public ListaCircularSE( String cadena )
   {
      nombre = cadena;
      primerNodo = null;
      contador=0;
   }

   public ListaCircularSE() 
   { 
      this( "lista circular simplemente enlazada" ); 
   }  


   public synchronized void insertar( Object elementoAInsertar )
   {
      if ( contador==0) {
         primerNodo = new NodoLista_circular(elementoAInsertar);
         primerNodo.siguiente=primerNodo;
         contador++;
      }
      else {
          contador++;
      	 NodoLista_circular ultimoNodo;
      	 NodoLista_circular actual = primerNodo;
      	 while(actual.siguiente != primerNodo) {
      	 	actual = actual.siguiente;
      	 }
      	 ultimoNodo = actual;
         
         NodoLista_circular desplazado = primerNodo;
         primerNodo = new NodoLista_circular( elementoAInsertar, desplazado );
      	 ultimoNodo.siguiente = primerNodo;
 
      }
   }

   // remueve el primer nodo de la Lista
  

   // retorna true si la Lista esta vacía
   public synchronized boolean estaVacio()
   { 
      return primerNodo == null; 
   }

   public synchronized void imprimir()
   {
      if ( estaVacio() ) {
         System.out.println( "Vacio " + nombre );
         return;
      }

      System.out.print( "La lista " + nombre + " es: " );

      NodoLista_circular actual = primerNodo;
      do {
         System.out.print( actual.info.toString() + " " );
         actual = actual.siguiente;
      } while ( actual != primerNodo );

      System.out.println( "\n" );
   }
}
// public synchronized Object remover()
//      throws ExcepcionListaVacia
//   {
//      Object elementoARemover = null;
//
//      // lanza una excepción si la Lista esta vacía
//      if ( estaVacio() )
//         throw new ExcepcionListaVacia( nombre );
//
//      // recupera el info a ser removido
//      elementoARemover = primerNodo.info;  
//
//      // reinicializa las referencias al primerNodo and ultimoNodo
//      if ( primerNodo == primerNodo.siguiente )
//         primerNodo = null;
//
//      else
//      {
// 
//       	 NodoLista_circular ultimoNodo;
//      	 NodoLista_circular actual = primerNodo;
//      	 while(actual.siguiente != primerNodo) {
//      	 	actual = actual.siguiente;
//      	 }
//      	 ultimoNodo = actual;
//      	 	        
//         primerNodo = primerNodo.siguiente;
//         ultimoNodo.siguiente=primerNodo;
//      }
//
//      // devuelve el info del nodo removido
//      return elementoARemover;  
//   }
