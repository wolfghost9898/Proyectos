/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package Listas;

import java.io.Serializable;

/**
 *
 * @author HP
 */
public class nodo implements Serializable{
     nodo sig;
     nodo ante;
    Object info;
    public void setInfo(Object info){
    this.info=info;
    this.sig=null;
    this.ante=null;
    }
    public void setSig(nodo sig){
    this.sig=sig;
    }
    public void setAnte(nodo ante){
    this.ante=ante;
    }
    
    /**
     * @return the sig
     */
    public nodo getSig() {
        return sig;
    }

    /**
     * @return the ante
     */
    public nodo getAnte() {
        return ante;
    }

    /**
     * @return the info
     */
    public Object getInfo() {
        return info;
    }

    
    
}
