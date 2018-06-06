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
public class lista_de_listas {
         nodo_enlazada cabeza, ante, sig, antep;
     int tam;
     public lista_de_listas(){
     cabeza=null;
     ante=null;
     sig=null;
     tam=0;
      
     }
     public nodo_enlazada getcabeza(){
     return cabeza;
     }
     
     public void enlistar(lista info){
         nodo_enlazada c= new nodo_enlazada(); 
         nodo_enlazada w= cabeza;
         c.setInfo(info);
         if(cabeza==null){
             tam=0;
            c.setSig(cabeza);
            w = cabeza;
            cabeza=c;
            tam++;
            }else {
            c.setSig(cabeza);
            cabeza=c;  
       
            tam++;
            }
             
          
     }
}
