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
public class Node {
    String nombre;
    String nota;
     int carnet;
    Node izquierda,derecha;
    public Node(String nombre,String nota,int carnet){
        this.nombre=nombre;
        this.nota=nota;
        this.carnet=carnet;
        izquierda=derecha=null;
    }
}
