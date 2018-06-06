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
public class Cnodo implements Serializable{
     Cnodo sig;
     Cnodo ante;
    Object info;
    public void setInfo(Object info){
    this.info=info;
    this.sig=null;
    }
    public void setSig(Cnodo sig){
    this.sig=sig;
    }
    
    /**
     * @return the sig 
     */
    public Cnodo getSig() {
        return sig;
    }

    /**
     * @return the ante
     */
    public Cnodo getAnte() {
        return ante;
    }

    /**
     * @return the info
     */
    public Object getInfo() {
        return info;
    }
}
