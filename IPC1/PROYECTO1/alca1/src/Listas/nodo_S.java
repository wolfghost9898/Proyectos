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
public class nodo_S {
    nodo sig;
    Object info;
    public void setInfo(Object info){
    this.info=info;
    this.sig=null;
    }
    public void setSig(nodo sig){
    this.sig=sig;
    }
    
    public nodo getSig() {
        return sig;
    }


    /**
     * @return the info
     */
    public Object getInfo() {
        return info;
    }
    
}

    

