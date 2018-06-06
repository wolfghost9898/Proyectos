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
public class nodo_enlazada implements Serializable{
     nodo_enlazada sig;
      lista info;
    public void setInfo(lista info){
    this.info=info;
    this.sig=null;
    }
    public void setSig(nodo_enlazada sig){
    this.sig=sig;
    }

    
    /**
     * @return the sig
     */
    public nodo_enlazada getSig() {
        return sig;
    }

    /**
     * @return the ante
     */


    /**
     * @return the info
     */
    public lista getInfo() {
        return info;
    }}

