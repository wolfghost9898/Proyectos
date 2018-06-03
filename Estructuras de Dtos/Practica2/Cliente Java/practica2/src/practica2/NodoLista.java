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
public class NodoLista {
    int id;
    String nombre;

    String llave;
    String fecha;
    String hora;

    public Node getRaiz() {
        return raiz;
    }
    Node raiz;
    
    NodoLista siguiente,anterior;
    
    public NodoLista(int id,String nombre,String llave,String fecha,String hora,NodoLista anterior,NodoLista siguiente,Node raiz){
       this.id=id;
       this.nombre=nombre;
       this.llave=llave;
       this.fecha=fecha;
       this.hora=hora;
       this.anterior=anterior;
       this.siguiente=siguiente;
       this.raiz=raiz;
    }
    
    public NodoLista getAnterior(){
        return anterior;
    }
    
    public void setAnterior(NodoLista anterior){
        this.anterior=anterior;
    }
    
    public NodoLista getSiguiente(){
        return siguiente;
    }
    
    public void setSiguiente(NodoLista siguiente){
        this.siguiente=siguiente;
    }
    
    public String getNombre(){
        return nombre;
    }
    
    
    public int getId() {
        return id;
    }

    public String getLlave() {
        return llave;
    }

    public String getFecha() {
        return fecha;
    }

    public String getHora() {
        return hora;
    }
    
    
}
