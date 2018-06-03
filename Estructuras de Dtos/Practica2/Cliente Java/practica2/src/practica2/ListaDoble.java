/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package practica2;

/**
 *
 * @author wolfghost
 */
public class ListaDoble {
    
    NodoLista primerNodo;
    NodoLista ultimoNodo;
    
    public ListaDoble(){
        this.primerNodo=null;
        this.ultimoNodo=null;
    }
    
    public void insertarNodo(String nombre,String llave,String fecha,String hora,Node raiz){
        if(this.primerNodo==null){
            this.ultimoNodo=new NodoLista(0,nombre,llave,fecha,hora,null,null,raiz);
            this.primerNodo=this.ultimoNodo;
        }else{
            NodoLista nodo=new NodoLista(this.ultimoNodo.getId()+1,nombre,llave,fecha,hora,this.ultimoNodo,null,raiz);
            this.ultimoNodo.setSiguiente(nodo);
            this.ultimoNodo=nodo;
        }
    }
}
