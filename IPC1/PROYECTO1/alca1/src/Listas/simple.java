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
public class simple {
    nodo cabeza, sig;
     int tam;
     public simple(){
     cabeza=null;
     sig=null;
     tam=0;
     
     }
     
     public void enlistar(Object info){
         nodo c= new nodo(); 
         c.setInfo(info);
         if(cabeza==null){
             tam=0;
            c.setSig(cabeza);
            cabeza=c;
            tam++;
            }else {
            c.setSig(cabeza);
            cabeza=c;  
            tam++;
            }
             
          
     }
     public int tamaño(int tam){
     return tam;
     }
     public nodo getcabeza(){
     return cabeza;
     }
     public void mostrar(){
     nodo temp= cabeza;
     while(!(temp==null)){
     
     System.out.println(temp.getInfo()+" ");
     temp = temp.getSig();
     }
}
}