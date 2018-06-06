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
public class NodoLista_circular {
   Object info;    
   NodoLista_circular siguiente;

   NodoLista_circular( Object objeto ) 
   { 
       this.info=objeto;
       this.siguiente=null;
   }


   NodoLista_circular( Object objeto, NodoLista_circular nodo )
   {
      info = objeto;    
      siguiente = nodo;  
   }

   Object obtenerObjeto() 
   { 
      return info; 
   }

   NodoLista_circular obtenerProximo() 
   { 
      return siguiente; 
   }
}
